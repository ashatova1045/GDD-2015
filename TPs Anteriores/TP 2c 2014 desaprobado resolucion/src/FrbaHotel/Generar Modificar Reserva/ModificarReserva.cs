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
    public partial class ModificarReserva : Form
    {
        decimal nReservaAModificar, tipoHabitacionAModificar, habitacionNumeroAModificar; //<----- esto va a ser una coleccion en algun momento
        DateTime fechaDesdeAModificar, fechaHastaAModificar;
        int codigoRegimenAModificar, hotelIDAModificar;

        public ModificarReserva()
        {
            InitializeComponent();
            Desde.Visible = false;
            Hasta.Visible = false;
            calendarioDesde.Visible = false;
            calendarioHasta.Visible = false;
            Hotel.Visible = false;
            cmbHotel.Visible = false;
            Regimen.Visible = false;
            cmbRegimen.Visible = false;

            tipoHabitacion.Visible = false;
            cmbTipoHab.Visible = false;
            HabitacionesDisponibles.Visible = false;
            ResultGridHabitacionesBuscadas.Visible = false;
            modificarb.Visible = false;
            btnConsultar.Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void btnBuscarReserva_Click(object sender, EventArgs e)
        {
            DataTable reserva = GestorDeSistema.obtenerReserva(Convert.ToDecimal(txtNReserva.Text));
            if (reserva.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Numero de reserva no encontrado");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Numero de reserva encontrado, procesando tu reserva");
                DataRow reservaFila = reserva.Rows[0];
                nReservaAModificar = (decimal)reservaFila[0];
                fechaDesdeAModificar = Convert.ToDateTime(reservaFila[1]);
                fechaHastaAModificar = Convert.ToDateTime(reservaFila[2]);
                hotelIDAModificar = (int)reservaFila[3];
                codigoRegimenAModificar = (int)reservaFila[4];
                habitacionNumeroAModificar = (decimal)reservaFila[5];
                tipoHabitacionAModificar = (decimal)reservaFila[6];

                actualizarItems();

            }
        }

        private void actualizarItems()
        {
            Desde.Visible = true;
            Hasta.Visible = true;
            calendarioDesde.Visible = true;
            calendarioHasta.Visible = true;
            Hotel.Visible = true;
            cmbHotel.Visible = true;
            Regimen.Visible = true;
            cmbRegimen.Visible = true;


            tipoHabitacion.Visible = true;
            cmbTipoHab.Visible = true;
            HabitacionesDisponibles.Visible = true;
            ResultGridHabitacionesBuscadas.Visible = true;
            modificarb.Visible = true;
            btnConsultar.Visible = true;


            calendarioDesde.SetDate(fechaDesdeAModificar);
            calendarioHasta.SetDate(fechaHastaAModificar);

            cmbHotel.Items.Clear();
            DataTable hoteles = GestorDeSistema.obtenerHotelesParaReserva(FrbaHotel.Singleton.Instance.usuarioID);
            cmbHotel.DisplayMember = "Hotel_Nombre";
            cmbHotel.ValueMember = "Hotel_ID";
            cmbHotel.DataSource = hoteles;
            cmbHotel.SelectedValue = hotelIDAModificar;
            cmbHotel.Update();

            DataTable regimenes = GestorDeSistema.obtenerRegimenesPorHotel(hotelIDAModificar);
            cmbRegimen.DisplayMember = "Regimen_Descripcion";
            cmbRegimen.ValueMember = "Regimen_Cod";
            cmbRegimen.DataSource = regimenes;
            cmbRegimen.Update();

            cmbRegimen.SelectedValue = codigoRegimenAModificar;

            DataTable tiposDeHab = GestorDeSistema.obtenerTipoDeHabitacionesParaReserva(hotelIDAModificar);
            cmbTipoHab.DisplayMember = "Habitacion_Tipo_Descripcion";
            cmbTipoHab.ValueMember = "Habitacion_Tipo_Codigo";
            cmbTipoHab.DataSource = tiposDeHab;
            cmbTipoHab.Update();

            cmbTipoHab.SelectedValue = tipoHabitacionAModificar;


        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable habitacionesDisponibles = GestorDeSistema.obtenerHabitacionesDisponibles((int)cmbHotel.SelectedValue, (decimal)cmbTipoHab.SelectedValue, calendarioDesde.SelectionStart, calendarioHasta.SelectionStart, Convert.ToDecimal(txtNReserva.Text));

            ResultGridHabitacionesBuscadas.DataSource = habitacionesDisponibles;
            ResultGridHabitacionesBuscadas.Update();

            if (habitacionesDisponibles.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No se encontraron habitaciones disponibles con los valores elegidos");
            }
        }

        private void modificarb_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedCellCollection habitacionesSeleccionadas = ResultGridHabitacionesBuscadas.SelectedCells;
            GestorDeSistema.modificarReserva(nReservaAModificar, (int)cmbHotel.SelectedValue, calendarioDesde.SelectionStart, calendarioHasta.SelectionStart, (int)cmbRegimen.SelectedValue);
            GestorDeSistema.eliminarReservaPorHabitacion(nReservaAModificar);
            decimal habitacionActual;
            int cantidadDeHabs = habitacionesSeleccionadas.Count;
            int i;
            for (i = 0; i < cantidadDeHabs; i ++)
            {
                habitacionActual = Convert.ToDecimal(habitacionesSeleccionadas[i].Value);
                FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.nuevaReservaPorHabitacion(nReservaAModificar, habitacionActual, (int)cmbHotel.SelectedValue);
                
            }
            string mensajeAMostrar = "Su reserva ha sido modificada correctamente";
            System.Windows.Forms.MessageBox.Show(mensajeAMostrar);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }
    }
}
