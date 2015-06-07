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
        decimal idTarjeta;
        decimal importeIngresado;
        decimal tipoMoneda;


        public RealizarDeposito()
        {
            InitializeComponent();
            SQLParametros parametrosCuentas = new SQLParametros();
            parametrosCuentas.add("@idUsuarioLogeado", Sesion.user_id);

            SQLParametros parametrosTarjetas = new SQLParametros();
            parametrosTarjetas.add("@idUsuarioLogeado", Sesion.user_id);




            if (ConexionDB.Procedure("seleccionarCuentas", parametrosCuentas.get(), out tablaCuentas))
            {
                if (tablaCuentas.Rows.Count == 0)
                {
                    MessageBox.Show("No tiene cuentas");
                    botonConfirmar.Enabled = false;
                }
                seleccionCuenta.DataSource = tablaCuentas;
                seleccionCuenta.DisplayMember = "Id_cuenta";
                seleccionCuenta.ValueMember = "Id_cuenta";

                if (ConexionDB.Procedure("seleccionarTarjetas", parametrosTarjetas.get(), out tablaTarjetas))
                {
                    if (tablaTarjetas.Rows.Count == 0)
                    {
                        MessageBox.Show("No tiene tarjetas");
                        botonConfirmar.Enabled = false;
                    }

                    seleccionTarjeta.DataSource = tablaTarjetas;
                    seleccionTarjeta.DisplayMember = "finalnumero";
                    seleccionTarjeta.ValueMember = "Id_tarjeta";

                    if (ConexionDB.Procedure("ObtenerMonedas", null, out tablaMonedas))
                    {
                        seleccionMoneda.DataSource = tablaMonedas;
                        seleccionMoneda.DisplayMember = "Descripcion";
                        seleccionMoneda.ValueMember = "Id_moneda";
                    }
                }
            }
        }
           
        private void RealizarDeposito_Load(object sender, EventArgs e)
        {
            ConexionDB.Procedure("ObtenerClientes", null, out tablaClientes);
        }

        private void botonConfirmar_Click_1(object sender, EventArgs e)
        {
           
            importeIngresado = seleccionImporte.Value;
            nroCuenta = (decimal)seleccionCuenta.SelectedValue;
            tipoMoneda =  (decimal)seleccionMoneda.SelectedValue;
            idTarjeta = (decimal)seleccionTarjeta.SelectedValue;

            SQLParametros parametrosParaValidar = new SQLParametros();

            parametrosParaValidar.add("@idUsuarioLogeado", Sesion.user_id);
            parametrosParaValidar.add("@nroCuenta", nroCuenta);
            parametrosParaValidar.add("@idTarjeta", idTarjeta);
            parametrosParaValidar.add("@importeIngresado", importeIngresado);
            parametrosParaValidar.add("@tipoMoneda", tipoMoneda);
            parametrosParaValidar.add("@fechaAhora", Sesion.fecha);

            DataTable tablaValidacionResultado;

            if (ConexionDB.Procedure("validarDeposito", parametrosParaValidar.get(), out tablaValidacionResultado))
            {
                MessageBox.Show("Se ha realizado el deposito correctamente");
            }

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
