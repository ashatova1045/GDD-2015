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

namespace PagoElectronico.ABM_Cuenta
{
    public partial class AdministrarCuentas : Form
    {
        public AdministrarCuentas()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ConexionDB.correrQuery(Sesion.conexion,"select cue.* from HHHH.cuentas cue join HHHH.clientes cli "+
                                                                                "on cli.Id_cliente = cue.Id_cliente and "+
	                                                                            "cli.Id_usuario = "+comboBox1.SelectedValue.ToString());

        }

        private void AdministrarCuentas_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;

            comboBox1.DataSource = ConexionDB.correrQuery(Sesion.conexion,"select * from HHHH.usuarios where Id_usuario <> 1");
            comboBox1.DisplayMember = "Usuario";
            comboBox1.ValueMember = "Id_usuario";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "Elija un usuario";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cell;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                cell = dataGridView1.SelectedRows[0].Cells;
                new EdicionCuenta(cell).Show(this);
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EdicionCuenta(null).Show(this);
            this.Hide();
        }
    }
}
