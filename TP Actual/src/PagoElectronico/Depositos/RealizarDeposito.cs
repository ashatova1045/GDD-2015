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
            seleccionCuenta.DataSource = tablaCuentas;
            seleccionCuenta.DisplayMember = "Id_cuenta";
            seleccionCuenta.ValueMember = "Id_cuenta";

            tablaTarjetas = ConexionDB.invocarStoreProcedure(Sesion.conexion, "seleccionarTarjetas", listaParaTarjetas);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }


        private void botonConfirmar_Click(object sender, EventArgs e)
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
            }


        MessageBox.Show("Se ha realizado el deposito correctamente");

        }

        private void seleccionCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionCuenta.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void seleccionImporte_ValueChanged(object sender, EventArgs e)
        {        
        }

        private void seleccionTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void seleccionMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void volverFuncionalidades_Click(object sender, EventArgs e)
        {
           
            Owner.Show();
            this.Close();
        }


    }
}
