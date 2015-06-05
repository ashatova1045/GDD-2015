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
            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@Id_usuario", Convert.ToDecimal(comboBox1.SelectedValue)));

            dataGridView1.DataSource = ConexionDB.invocarStoreProcedure(Sesion.conexion, "ObtenerCuentas", listaDeParametros);

            string[] ColOcultas = { "Id_pais", "Id_moneda", "Id_moneda" };

            foreach (string i in ColOcultas)
            {
                dataGridView1.Columns[i].Visible = false;
            }

        }

        private void AdministrarCuentas_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;

            if (Sesion.rol_id == 1)
            {
                comboBox1.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.usuarios where Id_usuario <> 1");
                comboBox1.DisplayMember = "Usuario";
                comboBox1.ValueMember = "Id_usuario";
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "Elija un usuario";
            }
            else 
            {
                DataTable user = new DataTable();
                user.Columns.Add("usuario");
                user.Columns.Add("id");

                DataRow row = user.NewRow();
                row["usuario"] = Sesion.usuario;
                row["id"] = Sesion.user_id;

                user.Rows.Add(row);

                comboBox1.DataSource = user;
                comboBox1.DisplayMember = "usuario";
                comboBox1.ValueMember = "id";

                comboBox1.SelectedValue = Sesion.user_id.ToString();
                MessageBox.Show(comboBox1.SelectedValue.ToString());
                comboBox1_SelectionChangeCommitted(null, null);

                comboBox1.Enabled = false;
            }
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
                new EdicionCuenta(cell,Convert.ToDecimal(comboBox1.SelectedValue)).Show(this);
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EdicionCuenta(null, Convert.ToDecimal(comboBox1.SelectedValue)).Show(this);
            this.Hide();
        }
    }
}
