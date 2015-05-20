using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.Cifrador;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data;

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
            listaDeParametros.Add(new SqlParameter("@contra",Cifrador.Cifrar(txtContrasena.Text))); //enctrìpto la contrasena para pasarsela a la db
            DataTable DTUsuario;

            try
            {
                DTUsuario = ConexionDB.invocarStoreProcedure(Sesion.conexion, "loginProc", listaDeParametros);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Sesion.user_id = (int)DTUsuario.Rows[0][0];  //guardo el user en la sesion (es el unico dato que devolvi por lo que esta en la fila 0 columna 0)
            Sesion.usuario = txtUsuario.Text;
            DTUsuario.Dispose();

            new SeleccionarRol().Show(this);
            this.Hide();
         }
     }
}
