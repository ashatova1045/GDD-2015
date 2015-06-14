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

            button1.Enabled = false;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!ValidadorHelper.ValidarLetrasGuiones(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "El nombre de rol no es correcto");
                button1.Enabled = false;
                return;
            }

            button1.Enabled = true;
        }
    }
}
