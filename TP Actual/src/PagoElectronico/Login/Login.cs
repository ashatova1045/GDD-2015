using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OperacionesDB.ConexionDB;

namespace PagoElectronico.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool loginExitoso =false;
            SqlDataReader DRUsuario = ConexionDB.correrQuery(Sesion.conexion,"SELECT id_usuario FROM usuarios WHERE user =" + txtUsuario.Text + "AND contra =" + txtContrasena.Text);
            if (DRUsuario.HasRows)
            {
                DRUsuario.Read();
                Sesion.user_id = DRUsuario.GetInt32(0);
                DRUsuario.Close();

                loginExitoso = true;
            }
            else
            {
                MessageBox.Show("Error de login");
                SqlDataReader cantfall = ConexionDB.correrQuery(Sesion.conexion, "SELECT cantdeloginsfallidosdeesteuser");
                if (cantfall.HasRows && cantfall.GetInt32(0) >= 2) 
                { 
                    //bloquear el user
                }

                cantfall.Close();
            }

            ConexionDB.correrQuery(Sesion.conexion, "INSERT datosdellogin INTO login").Close();

            if (loginExitoso)
            {
                SeleccionarRol selecRol = new SeleccionarRol();
                selecRol.Show(this);
                this.Hide();
            }
        }
    }
}
