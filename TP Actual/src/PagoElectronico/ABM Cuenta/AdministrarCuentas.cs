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
        private bool salir = true;

        public AdministrarCuentas()
        {
            InitializeComponent();
        }

        public void actualizarCuentas()
        {
            SQLParametros parametros = new SQLParametros();
            parametros.add("@Id_usuario", Convert.ToDecimal(comboBox1.SelectedValue));

            DataTable cuentas;
            dataGridView1.DataSource = null;
            if (ConexionDB.Procedure("ObtenerCuentas", parametros.get(), out cuentas) && cuentas.Rows.Count != 0)
            {
                dataGridView1.DataSource = cuentas.Select("estado <> 'C'").CopyToDataTable();

                string[] ColOcultas = { "Id_pais", "Id_moneda", "Id_moneda","id_tipo_cuenta"};

                foreach (string i in ColOcultas)
                {
                    dataGridView1.Columns[i].Visible = false;
                }
            }
            button1.Enabled = true;
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            actualizarCuentas();   
        }

        private void AdministrarCuentas_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button1.Enabled = false;

            if (Sesion.rol_id == 1)
            {          
                DataTable Usuarios;

                if (ConexionDB.Procedure("ObtenerUsuariosClientes", null, out Usuarios))
                {
                    comboBox1.DataSource = Usuarios;
                    comboBox1.DisplayMember = "Usuario";
                    comboBox1.ValueMember = "Id_usuario";
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "Elija un usuario";
                }
            }
            else 
            {
                button3.Visible = false;

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
                comboBox1_SelectionChangeCommitted(null, null);

                comboBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir = false;
            Owner.Show();
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            buttonCambiarTipo.Enabled = true;
            button4.Enabled = true;

            try
            {
                decimal tipoCuenta = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["Id_tipo_cuenta"].Value);
                try
                {
                    if ((dataGridView1.SelectedRows[0].Cells["Fecha_cierre"].Value.ToString() != "") || (System.DateTime.Compare(Sesion.fecha, Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["Fecha_cierre"].Value)) < 0))
                    {

                        buttonCambiarTipo.Enabled = false;
                    }
                }
                catch (InvalidCastException) { buttonCambiarTipo.Enabled = true; }

                if (tipoCuenta == 1)
                    btnProlongar.Enabled = false;
                else
                    btnProlongar.Enabled = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                btnProlongar.Enabled = false;
            }

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

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.SelectedRows.Count > 0))
                MessageBox.Show("Seleccione una cuenta para borrar");
            else
            {
                decimal ncuenta = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["Cuenta"].Value);

                SQLParametros parametros = new SQLParametros();
                parametros.add("@cuenta", ncuenta);
                parametros.add("@fecha", Sesion.fecha);

                if (ConexionDB.Procedure("bajaCuenta", parametros.get()))
                {
                    MessageBox.Show("Cuenta borrada");
                    actualizarCuentas();
                }
            }
        }

        private void btnProlongar_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.SelectedRows.Count > 0))
            {
                MessageBox.Show("Seleccione una cuenta para prolongar.");
                return;
            }
            char estado = Convert.ToChar(dataGridView1.SelectedRows[0].Cells["Estado"].Value);

            if (estado == 'P')
            {
                MessageBox.Show("Pague la activacion de su cuenta antes de prolongarla.");
                return;
            }

            new ProlongacionCuentas(dataGridView1.SelectedRows[0].Cells).Show(this);
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdministrarCuentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }

        private void buttonCambiarTipo_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.SelectedRows.Count > 0))
            {
                MessageBox.Show("Seleccione una cuenta para cambiarle el tipo.");
                return;
            }
            char estado = Convert.ToChar(dataGridView1.SelectedRows[0].Cells["Estado"].Value);

            if (estado == 'P')
            {
                MessageBox.Show("Pague la activacion de su cuenta antes de cambiarle el tipo.");
                return;
            }

            new CambiarTipoCuenta(dataGridView1.SelectedRows[0].Cells).Show(this);
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AdministrarCuentas_Shown(object sender, EventArgs e)
        {
            //actualizarCuentas();
        }

        private void AdministrarCuentas_VisibleChanged(object sender, EventArgs e)
        {
           
           // actualizarCuentas();
        }
    }
}
