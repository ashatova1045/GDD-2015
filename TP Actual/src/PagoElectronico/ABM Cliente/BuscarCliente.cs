using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PagoElectronico.OperacionesDB.ConexionDB;

namespace PagoElectronico.ABM_Cliente
{
    public partial class BuscarCliente : Form
    {
        public BuscarCliente()
        {
            InitializeComponent();
        }

        private void ActulizarResultados()
        {
            string tipoDoc;
            if (comboBoxTipoDoc.SelectedValue == null)
                tipoDoc = "";
            else
                tipoDoc = comboBoxTipoDoc.SelectedValue.ToString();

            SQLParametros parametros = new SQLParametros();

            parametros.add("@Nombre", textBoxNombre.Text);
            parametros.add("@Apellido", textBoxApellido.Text);
            parametros.add("@Documento", textBoxDoc.Text);
            parametros.add("@TipoDoc", tipoDoc);
            parametros.add("@Mail", textBoxMail.Text);

            DataTable clientesEncontrados;

            if(ConexionDB.Procedure("buscarCliente" ,parametros.get() ,out clientesEncontrados))
            {
                dataGridView1.DataSource = clientesEncontrados;
                labelCantRes.Text = clientesEncontrados.Rows.Count.ToString();

                int[] columnasOcultas = { 0, 4, 7, 10, 11, 12, 13, 14, 15, 20 };
                    foreach(int i in columnasOcultas)
                    {
                        dataGridView1.Columns[i].Visible = false;
                    }
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            ActulizarResultados();
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            ActulizarResultados();
        }

        private void textBoxMail_TextChanged(object sender, EventArgs e)
        {
            ActulizarResultados();
        }

        private void textBoxDoc_TextChanged(object sender, EventArgs e)
        {
            if (ValidarDatos())
                ActulizarResultados();
            else
                dataGridView1.DataSource = null;
        }

        private void comboBoxTipoDoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ActulizarResultados();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool resultado = true;

            if ((!ValidadorHelper.validarSoloNumeros(textBoxDoc.Text)) && textBoxDoc.Text != "")
            {
                errorProvider1.SetError(textBoxDoc, "El Documento solo puede contener numeros");
                resultado = false;
            }

            return resultado;
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            DataTable tipoDoc;

            if(ConexionDB.Procedure("ObtenerTipoDoc",null,out tipoDoc))
            {
                comboBoxTipoDoc.DataSource = tipoDoc;
                comboBoxTipoDoc.DisplayMember = "Descripcion";
                comboBoxTipoDoc.ValueMember = "Id_tipo_documento";
                comboBoxTipoDoc.SelectedIndex = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataGridViewCellCollection cell;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                cell = dataGridView1.SelectedRows[0].Cells;
                Nuevo_Cliente anterior = (Nuevo_Cliente) Owner;
                anterior.recDatos(cell);
                anterior.Show();
                this.Close();
            }
            else
                MessageBox.Show("Debe seleccionar una fila antes");
        }
    }
}
