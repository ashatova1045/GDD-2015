using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.OperacionesDB.ModeloSistema;
using FrbaHotel.OperacionesDB.Cifrado;
using FrbaHotel.OperacionesDB.ConexionDB;

namespace FrbaHotel.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            int usuarioid = GestorDeSistema.loginUsuario(usuario.Text, Cifrador.Cifrar(contrasena.Text));
            FrbaHotel.Singleton.Instance.usuarioID = usuarioid;
            if (usuarioid == 1)
            {
                FrbaHotel.Singleton.Instance.rol_cod = 3;
                Generar_Modificar_Reserva.VentanaPrincipal gestionReserva = new Generar_Modificar_Reserva.VentanaPrincipal();
                gestionReserva.Show(this);
                this.Hide();
            }
            else
            {
                if (usuarioid >1)
                {
                    LoginSeleccionRol frmSeleccionRol = new LoginSeleccionRol();
                    frmSeleccionRol.Show(this);

                    foreach (Control control in this.Controls)
                    {
                        TextBox box = control as TextBox;
                        if (box != null)
                        {
                            box.Clear();
                        }
                    }
                    this.Hide();
                }
                else
                    System.Windows.Forms.MessageBox.Show("Fallo el login");
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConexionDB.DesconectarDB();
        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            usuario.Text = "guest";
            contrasena.Text = "guest";
            ingresar.PerformClick();
        }

        private void contrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            { 
                ingresar.PerformClick();
            }
        }


    }
}
