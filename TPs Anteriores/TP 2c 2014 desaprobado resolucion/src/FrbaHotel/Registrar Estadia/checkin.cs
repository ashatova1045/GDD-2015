using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class checkin : Form
    {
        public checkin()
        {
            InitializeComponent();

            cargarreservas();
        }

        private void cargarreservas()
        {
            reserva.DisplayMember = "Reserva_Codigo";
            reserva.ValueMember = "Reserva_Codigo";
            reserva.DataSource = GestorDeSistema.getReservasActualesSinCheckin(FrbaHotel.Singleton.Instance.hotel);
            reserva.Update();
        }

        private void reserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ListBox)habitaciones).DataSource = GestorDeSistema.getHabReservasActuales(Convert.ToDecimal(reserva.Text));
            ((ListBox)habitaciones).DisplayMember = "Habitacion_Numero";
            ((ListBox)habitaciones).ValueMember = "Habitacion_Numero";
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void Checking_Click(object sender, EventArgs e)
        {
            foreach (DataRowView habitacion in habitaciones.CheckedItems)
            {
                GestorDeSistema.checkearHabitacion(FrbaHotel.Singleton.Instance.hotel, habitacion.Row.Field<decimal>("Habitacion_Numero"), Convert.ToDecimal(reserva.Text));
            }
            GestorDeSistema.crearEstadia(Convert.ToDecimal(reserva.Text));
            cargarreservas();
            MessageBox.Show("Check in exitoso");
        }
    }
}
