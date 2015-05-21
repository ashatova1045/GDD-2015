using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data.SqlClient;

namespace PagoElectronico.ABM_Rol
{
    public partial class NuevoNombreRol : Form
    {
        public NuevoNombreRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@nombre", textBox1.Text));
            listaDeParametros.Add(new SqlParameter("@estado", "N"));
            try
            {
                ConexionDB.invocarStoreProcedure(Sesion.conexion, "agregarNuevoRol", listaDeParametros);
                Owner.Show();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
