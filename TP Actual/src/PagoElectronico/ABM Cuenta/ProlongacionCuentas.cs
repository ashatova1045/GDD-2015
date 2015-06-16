using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class ProlongacionCuentas : Form
    {
        private bool salir = true;

        private decimal costoCuenta;

        public ProlongacionCuentas(DataGridViewCellCollection cuenta)
        {
            InitializeComponent();
            cargarDatos(cuenta);
        }

        private void cargarDatos(DataGridViewCellCollection cuenta)
        {
            SQLParametros param = new SQLParametros();
            param.add("@cuenta", cuenta["Tipo cuenta"].Value.ToString());
            DataTable infoCuenta;
            ConexionDB.Procedure("InformacionTipoCuenta", param.get(), out infoCuenta);
            
            txtCuenta.Text = cuenta["Cuenta"].Value.ToString();
            txtEstado.Text = cuenta["Estado"].Value.ToString();
            txtTipo.Text = cuenta["Tipo cuenta"].Value.ToString();
            txtDuracion.Text = infoCuenta.Rows[0]["duracion"].ToString();

            costoCuenta = Convert.ToDecimal(infoCuenta.Rows[0]["Costo_cuenta"]);

            txtPrecio.Text = costoCuenta.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            salir = false;
            Owner.Show();
            this.Close();
        }

        private void nuuSuscripciones_ValueChanged(object sender, EventArgs e)
        {
            txtPrecio.Text = (nuuSuscripciones.Value * costoCuenta).ToString();
        }

        private void nuuSuscripciones_KeyUp(object sender, KeyEventArgs e)
        {
            txtPrecio.Text = (nuuSuscripciones.Value * costoCuenta).ToString();
        }

        private void btnProlongar_Click(object sender, EventArgs e)
        {
            SQLParametros parametros = new SQLParametros();

            parametros.add("@Id_cuenta", Convert.ToDecimal(txtCuenta.Text));
            parametros.add("@Cant_suscripcones", Convert.ToInt32(nuuSuscripciones.Value));
            parametros.add("@fechaActual", Sesion.fecha);

            if(ConexionDB.Procedure("prolongarCuenta", parametros.get()))
            {
                salir = false;
                Owner.Show();
                this.Close();
            }
        }

        private void ProlongacionCuentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }
/* 
// 
        //
 */
        //

        //

        //

        //
    }
}
