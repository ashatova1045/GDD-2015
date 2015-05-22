using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data.SqlClient;

namespace PagoElectronico.Transferencias
{
    public partial class Transferencias : Form
    {
        private DataTable cuentasActivas;
        private DataRow cuentaSeleccionada;
        readonly DataTable monedas = ConexionDB.correrQuery(Sesion.conexion, "SELECT DISTINCT id_moneda,descripcion FROM HHHH.monedas"); //traigo todas las monedas, no solo las que tiene seteada alguna cuenta


        public Transferencias()
        {
            InitializeComponent();
            actualizarCuentas();
        }

        private void actualizarCuentas()
        {
            string queryCuentasActivas = "SELECT DISTINCT cu.Id_cuenta,cu.Saldo,cu.Id_moneda,u.id_usuario,cu.estado,tc.costo_transf,tc.id_moneda_transf FROM HHHH.Cuentas cu, HHHH.clientes cl,HHHH.usuarios u ,HHHH.tipo_cuenta tc WHERE tc.id_tipo_cuenta = cu.id_tipo_cuenta and cu.Id_cliente = cl.Id_cliente AND u.Id_usuario = cl.Id_usuario"; //traigo todos los datos de todas las cuentas
            cuentasActivas = ConexionDB.correrQuery(Sesion.conexion, queryCuentasActivas);

            cbOrigen.DisplayMember = "Id_cuenta";
            cbOrigen.ValueMember = "Id_cuenta";
            cbOrigen.DataSource = cuentasActivas.Select("estado = 'H' and id_usuario = " + Sesion.user_id).CopyToDataTable();
            cbOrigen.Update();

            cbDestino.DisplayMember = "Id_cuenta";
            cbDestino.ValueMember = "Id_cuenta";
            cbDestino.DataSource = cuentasActivas;
            cbDestino.Update();

            cbImporteMoneda.DisplayMember = "descripcion";
            cbImporteMoneda.ValueMember = "id_moneda";
            cbImporteMoneda.DataSource = monedas;
            cbImporteMoneda.Update();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void cbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDestino.Text != "") //la primera vez que corre no lo tiene en cuenta
            {   
                actualizarCuentaSeleccionada();
            }
        }

        private void actualizarCuentaSeleccionada()
        {
            cuentaSeleccionada = cuentasActivas.Select("[id_cuenta] = " + cbOrigen.Text)[0];
            txtSaldo.Text = Convert.ToString(cuentaSeleccionada["saldo"]);
            txtMoneda.Text = Convert.ToString(monedas.Select("id_moneda = " + cuentaSeleccionada["id_moneda"])[0]["descripcion"]);
            var a =cuentasActivas.Select("[id_cuenta] = " + cbOrigen.Text)[0]["id_usuario"];
            var b = cuentasActivas.Select("[id_cuenta] = " + cbDestino.Text)[0]["id_usuario"];
            if (Convert.ToString(cuentasActivas.Select("[id_cuenta] = "+ cbOrigen.Text)[0]["id_usuario"]).Equals(Convert.ToString(cuentasActivas.Select("[id_cuenta] = "+ cbDestino.Text)[0]["id_usuario"])))
            {
                txtCosto.Text = "0"; //si son del mismo usuario no les cobro
            }
            else
            {
                txtCosto.Text = Convert.ToString(cuentaSeleccionada["costo_transf"]);
            }
            txtMoneda2.Text = Convert.ToString(monedas.Select("id_moneda = " + cuentaSeleccionada["id_moneda_transf"])[0]["descripcion"]);

        }

        private void btTransferir_Click(object sender, EventArgs e)
        {
            if (nImporte.Value + Convert.ToDecimal(txtCosto.Text) > Convert.ToDecimal(cuentaSeleccionada["saldo"]))
            {
                MessageBox.Show("La suma entre importe a transferir y costo no puede superar a su saldo actual");
                return;
            }

            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@origen", cuentaSeleccionada["Id_cuenta"]));
            listaDeParametros.Add(new SqlParameter("@destino", cbDestino.SelectedValue));
            listaDeParametros.Add(new SqlParameter("@moneda", cbImporteMoneda.SelectedValue));
            listaDeParametros.Add(new SqlParameter("@importe", nImporte.Value));
            listaDeParametros.Add(new SqlParameter("@fecha", Sesion.fecha));
            listaDeParametros.Add(new SqlParameter("@costo", Convert.ToDecimal(txtCosto.Text)));
            ConexionDB.invocarStoreProcedure(Sesion.conexion,"transferencia",listaDeParametros);
            MessageBox.Show("Se han descontado de su cuenta " + nImporte.Value + " " + cbImporteMoneda.Text + " y " + cuentaSeleccionada["costo_transf"] + " " + cbImporteMoneda.Text + " de comision.");
            actualizarCuentas();
            actualizarCuentaSeleccionada();
        }

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarCuentaSeleccionada();
        }

    }
}
