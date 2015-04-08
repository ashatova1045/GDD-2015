using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;
using FrbaHotel.Generar_Modificar_Reserva;


namespace FrbaHotel.ABM_de_Cliente
{
    public partial class DarAltaCliente : Form
    {
        bool provenienteDeReserva;
        DataGridViewSelectedCellCollection habitacionesAReservar;
        int hotelAReservar, codigoRegimenAReservar,  codigoClienteAReservar;
        DateTime fechaDesdeAReservar, fechaHastaAReservar;
        decimal tipoHabAReservar;



        public DarAltaCliente()
        {
            InitializeComponent();
            actualizartipoDoc();
        }

        public DarAltaCliente(int hotel, decimal tipoHab, int codigoRegimen, DateTime fechaDesde, DateTime fechaHasta, DataGridViewSelectedCellCollection habitaciones)
        {
            InitializeComponent();
            actualizartipoDoc();
            provenienteDeReserva = true;
            hotelAReservar = hotel;
            tipoHabAReservar = tipoHab;
            codigoRegimenAReservar = codigoRegimen;
            fechaDesdeAReservar = fechaDesde;
            fechaHastaAReservar = fechaHasta;
            habitacionesAReservar = habitaciones;
        }


        private void actualizartipoDoc()
        {
            tiposdoc.DataSource = GestorDeSistema.ObtenerTodosLosTipoDePasaporte();
            tiposdoc.DisplayMember = "Pasaporte_Tipo_Descripcion";
            tiposdoc.ValueMember = "Pasaporte_Tipo";
            tiposdoc.Update();
        }

        private void DarAltaClienteBoton_Click(object sender, EventArgs e)
        {   
            if (validar())
            {
                GestorDeSistema.nuevoCliente((radioButton1.Checked) ? GestorDeSistema.obtenerDescripcionPas(TipoDocTextBox.Text) : Convert.ToInt32(tiposdoc.SelectedValue), Convert.ToDecimal(nrodoc.Text), ApellidotextBox1.Text, NombretextBox1.Text, MailTextBox.Text, Convert.ToDecimal(TarjetaCreditotextBox.Text), dateTimePicker1.Value, nacion.Text, PaisResidenciatextBox.Text, ciudad1.Text, calle.Text, Convert.ToDecimal(NroCalletextBox.Text), DeptotextBox.Text, Convert.ToDecimal(pisotext.Text));
                int numeroDocCliente = Convert.ToInt32(nrodoc.Text);
                int tipoDocCliente = Convert.ToInt32(tiposdoc.SelectedValue);
                string mailCliente = MailTextBox.Text;
                foreach (Control control in this.Controls)
                {
                    TextBox box = control as TextBox;
                    if (box != null)
                     {
                             box.Clear();
                      }
                }
                actualizartipoDoc();
                MessageBox.Show("Cliente agregado");
                if (provenienteDeReserva == true)
                {

                    DataTable cliente = FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.obtenerCliente(tipoDocCliente, numeroDocCliente, mailCliente);
                    DataRow filaCliente = cliente.Rows[0];
                    codigoClienteAReservar = (int)filaCliente[3];
                    FrbaHotel.Generar_Modificar_Reserva.NuevaReserva reserva = new NuevaReserva(hotelAReservar, tipoHabAReservar, codigoRegimenAReservar, fechaDesdeAReservar, fechaHastaAReservar, codigoClienteAReservar, habitacionesAReservar);

                    Owner.Show();
                    this.Hide();
                }
            }
        }

        private bool validar()
        {
            foreach (Control control in this.Controls)
            {
                TextBox box = control as TextBox;
                if (box != null)
                {
                    if (box.Text == "" && !(box == TipoDocTextBox && radioButton2.Checked))
                    {
                        MessageBox.Show("Faltan datos");
                        return false;
                    }
                }
            }

            if (radioButton1.Checked)   //crea el tipoppas si no existia
            {
                GestorDeSistema.nuevoTipoPas(TipoDocTextBox.Text);
            }

            if (GestorDeSistema.obtenerClientesRepetidos((radioButton1.Checked) ? GestorDeSistema.obtenerDescripcionPas(TipoDocTextBox.Text) : Convert.ToInt32(tiposdoc.SelectedValue),Convert.ToDecimal(nrodoc.Text),MailTextBox.Text))
            {
                MessageBox.Show("Cliente o mail repetido");
                return false;
            }
            return true;
        }

        private void VolverBoton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                tiposdoc.Enabled = true;
                TipoDocTextBox.Enabled = false;
                radioButton1.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                tiposdoc.Enabled = false;
                TipoDocTextBox.Enabled = true;
                radioButton2.Checked = false;
            }
        }

    }
}
