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
    public partial class ModificarHabitacion : Form
    {
        private bool hab;
        private decimal habNum;
        public ModificarHabitacion(DataGridViewRow habitacion)
        {
            InitializeComponent();

            TipoNuevaHabitacioncomboBox1.DisplayMember = "Habitacion_Tipo_Descripcion";
            TipoNuevaHabitacioncomboBox1.ValueMember = "Habitacion_Tipo_Codigo";
            TipoNuevaHabitacioncomboBox1.DataSource = GestorDeSistema.obtenerTiposHabitacion();
            TipoNuevaHabitacioncomboBox1.Update();

            hab = Convert.ToBoolean(habitacion.Cells["habilitado"].Value);
            habNum = Convert.ToDecimal(habitacion.Cells["nroHabitacion"].Value);

            HabitacionHabilitadacheckBox.Checked = hab;
            frente.Checked = Convert.ToString(habitacion.Cells["frente"].Value)=="S";
            PisoHabiAModificartextBox.Text = Convert.ToString(habitacion.Cells["pisoHabitacion"].Value);
            TipoNuevaHabitacioncomboBox1.SelectedValue = GestorDeSistema.obtenernrotipodehabconnombre(Convert.ToString(habitacion.Cells["tipoHabitacion"].Value));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void GuardarCambiosHabAModificarbutton_Click(object sender, EventArgs e)
        {
            if (hab && !HabitacionHabilitadacheckBox.Checked)
            {
                MessageBox.Show("Para deshabilitar una habitacion, vuelva  a la pantalla anterior y borrela");
                return;
            }
            if (!hab && HabitacionHabilitadacheckBox.Checked)
                FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.habilitarHabitacion(habNum,FrbaHotel.Singleton.Instance.hotel);

            FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.modificarHabitacion(habNum, FrbaHotel.Singleton.Instance.hotel,PisoHabiAModificartextBox.Text, Convert.ToInt32(TipoNuevaHabitacioncomboBox1.SelectedValue), frente.Checked);
            MessageBox.Show("Habitacion modificada");
            button1.PerformClick();
        }
    }
}
