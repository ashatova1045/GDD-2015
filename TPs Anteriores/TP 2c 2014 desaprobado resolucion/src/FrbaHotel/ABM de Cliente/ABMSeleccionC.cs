using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ABMSeleccionC : Form

     {

        List<Int32> tiposDoc {get;set;}

        private Cliente clienteSeleccionado { get; set; }

        public ABMSeleccionC()
        {
            
            InitializeComponent();
            clienteSeleccionado = new Cliente();


            TipoPasaporteComboBox.Items.Clear();
            DataTable TiposPasaporte = GestorDeSistema.ObtenerTodosLosTipoDePasaporte();
            DataRow row = TiposPasaporte.NewRow();
            row[0] = -1;
            row[1] = "Elegir";
            TiposPasaporte.Rows.InsertAt(row, 0);
            TipoPasaporteComboBox.DisplayMember = "Pasaporte_Tipo_Descripcion";
            TipoPasaporteComboBox.ValueMember = "Pasaporte_Tipo";
            TipoPasaporteComboBox.DataSource = TiposPasaporte;
            TipoPasaporteComboBox.Update();
           }




        private void DarAltaClienteBoton_Click(object sender, EventArgs e)
        {
            DarAltaCliente nuevoCliente = new DarAltaCliente();
            nuevoCliente.Show(this);
            this.Hide();
        }


      
        
        private void ModificarClienteBoton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ModificarClientes modificarClienteWindow = new ModificarClientes();
              
                Cliente cliente=new Cliente();
                Int32 id =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                cliente=GestorDeSistema.buscarClienteSeleccionado(id);
                modificarClienteWindow.Show(this);
                modificarClienteWindow.cargarDatosClienteSeleccionado(cliente);
                this.Hide();
            }
           else
           {
               MessageBox.Show("Seleccione el cliente que desee modificar");
           }
            
        }

        private void ApellidoLabel_Click(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void BuscarClientesBoton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GestorDeSistema.buscarClientes(NombreTextBox.Text, ApellidoTextBox.Text, TipoPasaporteComboBox.SelectedValue.ToString(), NroDocTextBox.Text, MailtextBox.Text);
        }

        private void ModificarClienteBoton_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                ModificarClientes modificarClienteWindow = new ModificarClientes();
                Cliente cliente = new Cliente();
                Int32 id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                cliente = GestorDeSistema.buscarClienteSeleccionado(id);
                modificarClienteWindow.Show(this);
                modificarClienteWindow.cargarDatosClienteSeleccionado(cliente);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione el cliente que desee modificar");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DarBajaClienteBoton_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
               
                GestorDeSistema.darBajaCliente(id);
            }
          

        }

        private void TipoPasaporteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarBusquedaBoton_Click(object sender, EventArgs e)
        {
            NombreTextBox.Clear();
            ApellidoTextBox.Clear();
            NroDocTextBox.Clear();
            MailtextBox.Clear();
        }

      

    }
}
