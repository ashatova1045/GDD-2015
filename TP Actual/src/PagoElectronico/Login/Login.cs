using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OperacionesDB.Cifrado;
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
            listaDeParametros.Add(new SqlParameter("@contra",Cifrador.Cifrar(txtContrasena.Text))); //enctrìpto la contrasena para pasarsela a la db
            SqlDataReader DRUsuario;

            try
            {
                DRUsuario = ConexionDB.invocarStoreProcedure(Sesion.conexion, "loginProc", listaDeParametros);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DRUsuario.Read();
            Sesion.user_id = DRUsuario.GetInt32(0);  //guardo el user en la sesion
            Sesion.usuario = txtUsuario.Text;
            DRUsuario.Close();

            SeleccionarRol selecRol = new SeleccionarRol();
            selecRol.Show(this);
            this.Hide();
         }
     }
}
