using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data.SqlClient;

namespace PagoElectronico.Transferencias
{
    public partial class Transferencias : Form
    {
        private DataTable cuentas;
        private DataRow cuentaSeleccionada;
        readonly DataTable monedas; //traigo todas las monedas, no solo las que tiene seteada alguna cuenta

        public Transferencias()
        {
            InitializeComponent();
            ConexionDB.Procedure("ObtenerMonedas", null, out monedas);
            actualizarCuentas();
        }

        private void actualizarCuentas()
        {
            if (ConexionDB.Procedure("ObtenerTodasCuentas_HoI",null, out cuentas))
            {
                cbOrigen.DisplayMember = "Id_cuenta";
                cbOrigen.ValueMember = "Id_cuenta";
                cbOrigen.DataSource = cuentas.Select("estado = 'H' and Id_cliente = " + Sesion.cliente_id).CopyToDataTable();
                cbOrigen.Update();

                cbDestino.DisplayMember = "Id_cuenta";
                cbDestino.ValueMember = "Id_cuenta";
                cbDestino.DataSource = cuentas;
                cbDestino.Update();

                cbImporteMoneda.DisplayMember = "descripcion";
                cbImporteMoneda.ValueMember = "id_moneda";
                cbImporteMoneda.DataSource = monedas;
                cbImporteMoneda.Update();
            }
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
            cuentaSeleccionada = cuentas.Select("[id_cuenta] = " + cbOrigen.Text)[0];
            var cuentaDestino = cuentas.Select("[id_cuenta] = " + cbDestino.Text)[0];
            txtSaldo.Text = Convert.ToString(cuentaSeleccionada["saldo"]);
            txtMoneda.Text = Convert.ToString(monedas.Select("id_moneda = " + cuentaSeleccionada["id_moneda"])[0]["descripcion"]);
            if (Convert.ToString(cuentaSeleccionada["id_cliente"]).Equals(Convert.ToString(cuentaDestino["id_cliente"])))
            {
                txtCosto.Text = "0"; //si son del mismo usuario no les cobro
            }
            else
            {
                //lo que cuesta transferir expresado en la moneda de la cuenta
                txtCosto.Text = Convert.ToString(ConexionDB.correrQuery(Sesion.conexion, "select hhhh.convertirmoneda (" + cuentaSeleccionada["Id_moneda_transf"] + "," + cuentaSeleccionada["Id_moneda"] + "," + cuentaSeleccionada["Costo_transf"].ToString().Replace(',', '.') + ")").Rows[0][0]);
            }
            
            txtMoneda2.Text = txtMoneda.Text;
            txtMonedaATransferir.Text = txtMoneda.Text;

        }

        private void btTransferir_Click(object sender, EventArgs e)
        {
            actualizarImporteATransferir();
            if (Convert.ToDecimal(txtCosto.Text) + Convert.ToDecimal(txtImporteConvertido.Text) > Convert.ToDecimal(cuentaSeleccionada["saldo"]))
            {
                MessageBox.Show("La suma entre importe a transferir y costo no puede superar a su saldo actual");
                return;
            }

            SQLParametros parametros = new SQLParametros();

            parametros.add("@origen", cuentaSeleccionada["Id_cuenta"]);
            parametros.add("@destino", cbDestino.SelectedValue);
            parametros.add("@moneda", cbImporteMoneda.SelectedValue);
            parametros.add("@importe", nImporte.Value);
            parametros.add("@fecha", Sesion.fecha);
            parametros.add("@costo", Convert.ToDecimal(txtCosto.Text));

            if(ConexionDB.Procedure("transferencia",parametros.get()))
            {
                MessageBox.Show("Se han descontado de su cuenta " + nImporte.Value + " " + txtMonedaATransferir.Text + " y " + cuentaSeleccionada["costo_transf"] + " " + txtMoneda2.Text + " de comision.");
                actualizarCuentas();
                actualizarCuentaSeleccionada();
            }
        }

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarCuentaSeleccionada();
        }

        private void actualizarImporteATransferir()
        {
            var valorImporte = ConexionDB.correrQuery(Sesion.conexion, "SELECT HHHH.convertirmoneda(" + cbImporteMoneda.SelectedValue + "," + cuentaSeleccionada["id_moneda"] + "," + nImporte.Text.Replace(',', '.') + ")").Rows[0][0];
            txtImporteConvertido.Text = Convert.ToString(valorImporte);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            actualizarImporteATransferir();
        }

    }
}
