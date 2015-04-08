using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class ABMHabitacionVentanaPrincipal : Form
    {
        public ABMHabitacionVentanaPrincipal()
        {
            InitializeComponent();
          
            TipoNuevaHabitacioncomboBox1.DisplayMember = "Habitacion_Tipo_Descripcion";
            TipoNuevaHabitacioncomboBox1.ValueMember = "Habitacion_Tipo_Codigo";
            TipoNuevaHabitacioncomboBox1.DataSource = GestorDeSistema.obtenerTiposHabitacion();
            TipoNuevaHabitacioncomboBox1.Update();
            
            HotelNombreTextBox.Text = FrbaHotel.Singleton.Instance.hotel_nombre;
        }

        private void NuevaHabitacionBoton_Click(object sender, EventArgs e)
        {
            CrearHabitacion nuevaHabitacion = new CrearHabitacion();
            nuevaHabitacion.Show(this);
            this.Hide();
        }

        private void VentanaPrincipalHabitacionVolverBoton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void BuscarHabitacionBoton_Click(object sender, EventArgs e)
        {        
            dgvHabitacion.DataSource = GestorDeSistema.buscarHabitacion(CodHabitacionTextBox.Text, PisoHabitacionTextBox.Text, FrbaHotel.Singleton.Instance.hotel, Convert.ToInt32(TipoNuevaHabitacioncomboBox1.SelectedValue),habilitadach.Checked);
            dgvHabitacion.Update();
        }

        private void LimpiarBusquedaBoton_Click(object sender, EventArgs e)
        {

            CodHabitacionTextBox.Text = String.Empty;
            PisoHabitacionTextBox.Text = String.Empty;
            PisoHabitacionTextBox.Text = String.Empty;
            TipoNuevaHabitacioncomboBox1.SelectedIndex = 0;
            dgvHabitacion.Update();
        }

        private void DarBajaHabitacionBoton_Click(object sender, EventArgs e)
        {

            if (!(dgvHabitacion.SelectedRows.Count == 1))
            {
                MessageBox.Show("Seleccione solo una fila");
                return;
            }
            if (!Convert.ToBoolean(dgvHabitacion.CurrentRow.Cells["habilitado"].Value))
            {
                MessageBox.Show("Esta habitacion ya esta deshabilitada");
                return;
            }


           if (GestorDeSistema.darBajaHabitacion(Convert.ToDecimal(dgvHabitacion.CurrentRow.Cells["nroHabitacion"].Value), FrbaHotel.Singleton.Instance.hotel) == 1)
           {
               MessageBox.Show("Baja exitosa");
               BuscarHabitacionBoton.PerformClick();
           }
           else
               MessageBox.Show("Hay reservas activas sobre esa habitacion");   
            
              
        }

        private void ModificarHabitacionBoton_Click(object sender, EventArgs e)
        {
            if (dgvHabitacion.SelectedRows.Count == 1)
            {
                (new ModificarHabitacion(dgvHabitacion.CurrentRow)).Show(this);
                this.Hide();
            }
        }

    }
}