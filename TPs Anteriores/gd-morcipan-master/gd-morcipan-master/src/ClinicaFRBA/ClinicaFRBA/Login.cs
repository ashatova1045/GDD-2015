using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using System.Configuration;
using ClinicaFRBA.Utils;
using ClinicaFRBA.Utils.Seguridad;

namespace ClinicaFRBA
{
    public partial class Login : Form
    {
        private int cantidadIntentos;
        public Login()
        {
            InitializeComponent();
            ManejadorFechaHora.registrarFechaDelSistema();
            this.cantidadIntentos = 1;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int idUsuario = ManejadorNegocio.usuarioValido(txtUsuario.Text, Encriptador.encriptar(txtContrasenia.Text));
            if (idUsuario > 0)
            {
                LoginSeleccion frmSeleccionRol = new LoginSeleccion(idUsuario);
                frmSeleccionRol.Show(this);
                this.Hide();
            }
            else
            {
                if (cantidadIntentos >= 3)
                {
                    MessageBox.Show("Usted agotó todas las posibilidades de ingresar al sistema. Si corresponde, su usuario será inhabilitado hasta que usted regularice su situación", "Error en Ingreso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ManejadorNegocio.inhabilitarUsuario(txtUsuario.Text);
                    ManejadorBD.DesconectarBD();
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("El usuario o password ingresado es INCORRECTO o el usuario esta BLOQUEADO. Por favor, verifique los datos ingresados.\nIntentos " + this.cantidadIntentos.ToString() + " de 3", "Error de Ingreso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cantidadIntentos++;
                }
            }
        }

        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnIngresar.PerformClick();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            ManejadorBD.DesconectarBD();
        }
    }
}
