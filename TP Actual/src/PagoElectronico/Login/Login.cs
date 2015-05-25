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

            Sesion.user_id = Convert.ToDecimal(DTUsuario.Rows[0][0]);
            Sesion.cliente_id = Convert.ToDecimal(DTUsuario.Rows[0][1]); 
            Sesion.usuario = txtUsuario.Text;

            new SeleccionarRol().Show(this);
            this.Hide();
         }

        private void Login_Load(object sender, EventArgs e)
        {

        }
     }
}
