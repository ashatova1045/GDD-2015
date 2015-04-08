using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    class NuevaReserva
    {
        public NuevaReserva(int hotelSeleccionado, decimal tipoHabSeleccionada, int codigoRegimen, DateTime fechaDesde, DateTime fechaHasta, int codigoCliente, System.Windows.Forms.DataGridViewSelectedCellCollection habitacionesSeleccionadas)
        {
            decimal habitacionActual;
            int cantidadDeHabs = habitacionesSeleccionadas.Count;
            System.Data.DataTable reserva = FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.nuevaReserva(hotelSeleccionado, fechaDesde, fechaHasta, codigoRegimen, codigoCliente);
            System.Data.DataRow reservaFila = reserva.Rows[0];
            decimal reservaNumero = (decimal) reservaFila[0];          
           
            int i;
            for (i = 0; i < cantidadDeHabs; i++)
            {
                habitacionActual = Convert.ToDecimal(habitacionesSeleccionadas[i].Value);
                FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.nuevaReservaPorHabitacion(reservaNumero, habitacionActual, hotelSeleccionado);
                
            }
            string mensajeAMostrar = "Su reserva ha sido efectuada correctamente. El numero de la misma es: " + reservaNumero.ToString();
            System.Windows.Forms.MessageBox.Show(mensajeAMostrar);
        }
    }
}
