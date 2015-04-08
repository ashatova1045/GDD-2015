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
    public partial class CrearHabitacion : Form
    {
        public CrearHabitacion()
        {
            InitializeComponent();
            
            hotelnombre.Text = FrbaHotel.Singleton.Instance.hotel_nombre;

            TipoNuevaHabitacioncomboBox1.Items.Clear();
            DataTable tiposH = GestorDeSistema.obtenerTiposHabitacion();
            TipoNuevaHabitacioncomboBox1.DisplayMember = "Habitacion_Tipo_Descripcion";
            TipoNuevaHabitacioncomboBox1.ValueMember = "Habitacion_Tipo_Codigo";
            TipoNuevaHabitacioncomboBox1.DataSource = tiposH;
            TipoNuevaHabitacioncomboBox1.Update();
        }

        private void CrearHabitacionBoton_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                GestorDeSistema.nuevaHabitacion(Convert.ToDecimal(numerotb.Text), Convert.ToDecimal(pisotb.Text), Convert.ToDecimal(TipoNuevaHabitacioncomboBox1.SelectedValue), Frente.Checked, habilitada.Checked, FrbaHotel.Singleton.Instance.hotel);

                numerotb.Clear();
                pisotb.Clear();
                MessageBox.Show("Habitacion agregada");
            }
        }

        private bool validar()
        {
            if (numerotb.Text == "" || pisotb.Text == "")
            {
                MessageBox.Show("Faltan datos");
                return false;
            }

            if (GestorDeSistema.obtenerHabitacionExistente(Convert.ToDecimal(numerotb.Text), Convert.ToDecimal(pisotb.Text),FrbaHotel.Singleton.Instance.hotel))
            {
                MessageBox.Show("La habitacion ya existe");
                return false;
            }
            return true;
        }

        private void HabitacionNuevaVolverBoton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

    }
}
