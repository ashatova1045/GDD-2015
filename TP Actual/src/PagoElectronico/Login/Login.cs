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
            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@usu",txtUsuario.Text));
            listaDeParametros.Add(new SqlParameter("@contra",txtContrasena.Text));

            try
            {
                SqlDataReader DRUsuario = ConexionDB.invocarStoreProcedure(Sesion.conexion, "loginProc", listaDeParametros);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            SeleccionarRol selecRol = new SeleccionarRol();
            selecRol.Show(this);
            this.Hide();
         }
     }
}


