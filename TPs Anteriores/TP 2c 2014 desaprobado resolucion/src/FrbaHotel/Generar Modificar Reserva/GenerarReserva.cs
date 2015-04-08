using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class GenerarReserva : Form
    {
        private int hotel;
        public GenerarReserva()
        {
            

            InitializeComponent();

            DataTable hoteles = GestorDeSistema.obtenerHotelesParaReserva(FrbaHotel.Singleton.Instance.usuarioID);
            hotelcmb.DisplayMember = "Hotel_Nombre";
            hotelcmb.ValueMember = "Hotel_ID";
            hotelcmb.DataSource = hoteles;
            hotelcmb.Update();

            if (FrbaHotel.Singleton.Instance.rol_cod != 3) 
            {
                hotel = FrbaHotel.Singleton.Instance.hotel;
                hotelcmb.Text = FrbaHotel.Singleton.Instance.hotel_nombre;
                hotelcmb.Enabled = false;
            }
            else
                hotel = (int)hotelcmb.SelectedValue;

            actualizarcosas();

        }

        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            hotel = (int)hotelcmb.SelectedValue;
            actualizarcosas();

        }

        private void actualizarcosas()
        {
            DataTable regimenes = GestorDeSistema.obtenerRegimenesPorHotel(hotel);
            cmbRegimen.DisplayMember = "Regimen_Descripcion";
            cmbRegimen.ValueMember = "Regimen_Cod";
            cmbRegimen.DataSource = regimenes;

            cmbRegimen.Update();

            DataTable tiposDeHab = GestorDeSistema.obtenerTipoDeHabitacionesParaReserva(hotel);
            cmbTipoHab.DisplayMember = "Habitacion_Tipo_Descripcion";
            cmbTipoHab.ValueMember = "Habitacion_Tipo_Codigo";
            cmbTipoHab.DataSource = tiposDeHab;

            cmbTipoHab.Update();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
   

            decimal tipoHabSeleccionada = (decimal)cmbTipoHab.SelectedValue;
            int codigoRegimen = (int)cmbRegimen.SelectedValue;         
            
            DateTime fechaDesdeSeleccionada = calendarioDesde.SelectionStart;
            DateTime fechaHastaSeleccionada = calendarioHasta.SelectionStart;

            DataTable habitacionesDisponibles = GestorDeSistema.obtenerHabitacionesDisponibles(hotel, tipoHabSeleccionada, fechaDesdeSeleccionada, fechaHastaSeleccionada,0);

            ResultGridHabitacionesBuscadas.DataSource = habitacionesDisponibles;
            ResultGridHabitacionesBuscadas.Update();

            valor.Text = GestorDeSistema.getPrecioHabitacion(tipoHabSeleccionada, codigoRegimen, hotel).ToString();
        }

        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            if (ResultGridHabitacionesBuscadas.SelectedCells.Count < 1)
                { MessageBox.Show("Seleccione las habitaciones que quiera"); return; }
            decimal tipoHabSeleccionada = Convert.ToDecimal(cmbTipoHab.SelectedValue);
            int codigoRegimen = (int)cmbRegimen.SelectedValue;
            int hotelSeleccionado = hotel;
            DateTime fechaDesdeSeleccionada = calendarioDesde.SelectionStart;
            DateTime fechaHastaSeleccionada = calendarioHasta.SelectionStart;
            DataGridViewSelectedCellCollection habitacionesSeleccionadas = ResultGridHabitacionesBuscadas.SelectedCells;
                      
            ConfirmarReserva confirmarReserva = new ConfirmarReserva(hotelSeleccionado, tipoHabSeleccionada, codigoRegimen, fechaDesdeSeleccionada, fechaHastaSeleccionada, habitacionesSeleccionadas);
            confirmarReserva.Show(this);
            this.Hide();
            
            
  

        }
     }

  

       
    
}
