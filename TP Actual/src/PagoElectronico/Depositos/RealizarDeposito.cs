using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data.SqlClient;

namespace PagoElectronico.Depositos
{
    public partial class RealizarDeposito : Form
    {
        DataTable tablaClientes;
        DataTable tablaCuentas;
        DataTable tablaMonedas;
        DataTable tablaTarjetas;

        decimal nroCuenta;
        string nroTarjeta;
        decimal importeIngresado;
        decimal tipoMoneda;

        public RealizarDeposito()
        {
            InitializeComponent();
            List<SqlParameter> listaParaCuentas = new List<SqlParameter>();
            listaParaCuentas.Add(new SqlParameter("@idUsuarioLogeado", Sesion.user_id));

            List<SqlParameter> listaParaTarjetas = new List<SqlParameter>();
            listaParaTarjetas.Add(new SqlParameter("@idUsuarioLogeado", Sesion.user_id));

            tablaCuentas = ConexionDB.invocarStoreProcedure(Sesion.conexion, "seleccionarCuentas", listaParaCuentas);
            if (tablaCuentas.Rows.Count == 0)
            {
                MessageBox.Show("No tiene cuentas");
                volverFuncionalidades_Click_1(null, null);
            }
            seleccionCuenta.DataSource = tablaCuentas;
            seleccionCuenta.DisplayMember = "Id_cuenta";
            seleccionCuenta.ValueMember = "Id_cuenta";

            tablaTarjetas = ConexionDB.invocarStoreProcedure(Sesion.conexion, "seleccionarTarjetas", listaParaTarjetas);
            if (tablaTarjetas.Rows.Count == 0)
            {
                MessageBox.Show("No tiene tarjetas");
                volverFuncionalidades_Click_1(null, null);
            }
            seleccionTarjeta.DataSource = tablaTarjetas;
            seleccionTarjeta.DisplayMember = "Numero";
            seleccionTarjeta.ValueMember = "Numero";

            tablaMonedas = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.monedas");
            seleccionMoneda.DataSource = tablaMonedas;
            seleccionMoneda.DisplayMember = "Descripcion";
            seleccionMoneda.ValueMember = "Id_moneda";
        }
           
        private void RealizarDeposito_Load(object sender, EventArgs e)
        {
            tablaClientes = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.clientes");
        }

        private void botonConfirmar_Click_1(object sender, EventArgs e)
        {
           
            importeIngresado = seleccionImporte.Value;
            nroCuenta = (decimal)seleccionCuenta.SelectedValue;
            tipoMoneda =  (decimal)seleccionMoneda.SelectedValue;
            nroTarjeta = (string)seleccionTarjeta.SelectedValue;

            List<SqlParameter> listaParaValidar = new List<SqlParameter>();
            listaParaValidar.Add(new SqlParameter("@idUsuarioLogeado", Sesion.user_id));
            listaParaValidar.Add(new SqlParameter("@nroCuenta", nroCuenta));
            listaParaValidar.Add(new SqlParameter("@nroTarjeta", nroTarjeta));
            listaParaValidar.Add(new SqlParameter("@importeIngresado", importeIngresado));
            listaParaValidar.Add(new SqlParameter("@tipoMoneda", tipoMoneda));
            listaParaValidar.Add(new SqlParameter("@fechaAhora", Sesion.fecha));

            try
            {
                DataTable tablaValidacionResultado = ConexionDB.invocarStoreProcedure(Sesion.conexion, "validarDeposito", listaParaValidar);
            }

            catch (Exception errorDeposito)
            {
                MessageBox.Show (errorDeposito.Message);
                return;
            }


        MessageBox.Show("Se ha realizado el deposito correctamente");

        }

        private void seleccionCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionCuenta.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void volverFuncionalidades_Click_1(object sender, EventArgs e)
        {
           
            Owner.Show();
            this.Close();
        }

    }
}
