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
        DataGridViewCellCollection cuentaG;
        public ProlongacionCuentas(DataGridViewCellCollection cuenta)
        {
            InitializeComponent();
            cargarDatos(cuenta);
            cuentaG = cuenta;
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
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            salir = false;
            Owner.Show();
            this.Close();
        }

        private void btnProlongar_Click(object sender, EventArgs e)
        {
            SQLParametros parametros = new SQLParametros();

            parametros.add("@Id_cuenta", cuentaG["Cuenta"].Value.ToString());
            parametros.add("@Cant_suscripcones", Convert.ToInt32(nuuSuscripciones.Value));
            parametros.add("@fechaActual", Sesion.fecha);

            if(ConexionDB.Procedure("prolongarCuenta", parametros.get()))
            {
                salir = false;
                Owner.Show();
                this.Close();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            SQLParametros param = new SQLParametros();
            param.add("@suscripciones", nuuSuscripciones.Value);
            //param.add("@cuenta", txtCuenta.Text);
            param.add("@tipoCuenta", cuentaG["Id_tipo_cuenta"].Value.ToString());
            DataTable costo;
            ConexionDB.Procedure("CalcularCostoProlongacion", param.get(), out costo);
            txtPrecio.Text = costo.Rows[0][0].ToString();
        }

        private void ProlongacionCuentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }

        private void ProlongacionCuentas_Load(object sender, EventArgs e)
        {

        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
