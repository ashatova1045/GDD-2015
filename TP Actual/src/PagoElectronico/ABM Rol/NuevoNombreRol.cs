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
            SQLParametros parametros = new SQLParametros();
            parametros.add("@nombre", textBox1.Text);

            if (ConexionDB.Procedure("agregarNuevoRol", parametros.get()))
            {
                Owner.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void NuevoNombreRol_Load(object sender, EventArgs e)
        {

        }
    }
}
