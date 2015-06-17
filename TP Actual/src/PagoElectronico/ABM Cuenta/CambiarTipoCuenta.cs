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
    public partial class CambiarTipoCuenta : Form
    {

        private bool salir = true;

        private DataTable tipoCuentas;

        decimal costoCuenta;

        public CambiarTipoCuenta(DataGridViewCellCollection cuenta)
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
            txtEstadoCuenta.Text = cuenta["Estado"].Value.ToString();
            txtTipoCuentaActual.Text = cuenta["Tipo cuenta"].Value.ToString();
            

            param = new SQLParametros();
            param.add("@tipoCuenta", cuenta["Tipo cuenta"].Value.ToString());            
            ConexionDB.Procedure("ObtenerTipoCuentasDistintas", param.get(), out tipoCuentas);

            
            cbNuevoTipoCuenta.DisplayMember = "Descripcion";
            cbNuevoTipoCuenta.ValueMember = "Id_tipo_cuenta";
            cbNuevoTipoCuenta.Text = "";          
        }

        private void bnVolver_Click(object sender, EventArgs e)
        {
            salir = false;
            Owner.Show();
            this.Close();
        }

        private void CambiarTipoCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }

        private void calcularPrecio(object sender, EventArgs e)
        {

            txtPrecioTotal.Text = (txtSuscripciones.Value * costoCuenta).ToString();
        }


        private void txtSuscripciones_KeyUp(object sender, KeyEventArgs e)
        {
            calcularPrecio(null, null);
        }

        private void cbNuevoTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNuevoTipoCuenta.Text != "")
            {
                DataTable infoTipoCuenta;
               SQLParametros parametro = new SQLParametros();
                parametro.add("@cuenta", cbNuevoTipoCuenta.Text);
                ConexionDB.Procedure("InformacionTipoCuenta", parametro.get(), out infoTipoCuenta);
                costoCuenta = Convert.ToDecimal(infoTipoCuenta.Rows[0]["costo_cuenta"]);
                txtCosto.Text = costoCuenta.ToString();
                txtDuracion.Text = infoTipoCuenta.Rows[0]["duracion"].ToString();
                txtPrecioTotal.Text = costoCuenta.ToString();

            }
        }

        private void cbNuevoTipoCuenta_Click(object sender, EventArgs e)
        {
            cbNuevoTipoCuenta.DataSource = tipoCuentas;
            cbNuevoTipoCuenta.Update();
        }

        private void bnCambiarTipoCuenta_Click(object sender, EventArgs e)
        {
            SQLParametros paramAct = new SQLParametros();

            paramAct.add("@cuenta", Convert.ToDecimal(txtCuenta.Text));
            paramAct.add("@tipocuenta",Convert.ToInt32(cbNuevoTipoCuenta.SelectedValue));

            if(ConexionDB.Procedure("cambiarTipoCuenta", paramAct.get()))
            {
                if(Convert.ToInt32(cbNuevoTipoCuenta.SelectedValue) != 1)
                {
                    SQLParametros parametros = new SQLParametros();

                    parametros.add("@Id_cuenta", Convert.ToDecimal(txtCuenta.Text));
                    parametros.add("@Cant_suscripcones", Convert.ToInt32(txtSuscripciones.Value));
                    parametros.add("@fechaActual", Sesion.fecha);

                    ConexionDB.Procedure("prolongarCuenta", parametros.get()); 
                }   
            }
            salir = false;
            ((AdministrarCuentas)Owner).actualizarCuentas();
            Owner.Show();
            this.Close();
        }
    }
}
