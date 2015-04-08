using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class RegistrarConsumible : Form
    {
        private DataTable reservas;
        public RegistrarConsumible()
        {
            InitializeComponent();

            consumible.DisplayMember = "Consumible_Descripcion";
            consumible.ValueMember = "Consumible_Codigo";
            consumible.DataSource = GestorDeSistema.getConsumibles();
            consumible.Update();

            reservas = GestorDeSistema.getReservasPorHabActuales(FrbaHotel.Singleton.Instance.hotel);
            reserva.DisplayMember = "Reserva_Codigo";
            reserva.ValueMember = "Reserva_Codigo";
            reserva.DataSource = reservas;
            reserva.Update();
        
            reserva.SelectedIndex = 0;
            actualizarHabitaciones();
        }

        private void actualizarHabitaciones()
        {

            habitacion.DisplayMember = "Habitacion_Numero";
            habitacion.ValueMember = "Habitacion_Numero";
            habitacion.DataSource = GestorDeSistema.getHabReservasActuales(Convert.ToDecimal(reserva.SelectedValue));
            habitacion.Update();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void reserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarHabitaciones();
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            GestorDeSistema.registrarConsumible(Convert.ToDecimal(reserva.SelectedValue), Convert.ToDecimal(habitacion.SelectedValue), Convert.ToDecimal(consumible.SelectedValue), Convert.ToInt32(cantidad.Value),FrbaHotel.Singleton.Instance.hotel);
            MessageBox.Show("Consumible registrado");
        }
    }
}
