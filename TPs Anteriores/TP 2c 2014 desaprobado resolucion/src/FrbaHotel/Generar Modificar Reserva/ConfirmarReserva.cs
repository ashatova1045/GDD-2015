using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class ConfirmarReserva : Form
    {

        DataGridViewSelectedCellCollection habitacionesAReservar;
        int hotelAReservar, codigoRegimenAReservar, codigoClienteAReservar;
        decimal tipoHabAReservar;
        DateTime fechaDesdeAReservar, fechaHastaAReservar;

       public ConfirmarReserva(int hotelSeleccionado, decimal tipoHabSeleccionada, int codigoRegimen, DateTime fechaDesde, DateTime fechaHasta, DataGridViewSelectedCellCollection habitacionesSeleccionadas)
        {
            InitializeComponent();
            hotelAReservar = hotelSeleccionado;
            tipoHabAReservar = tipoHabSeleccionada;
            codigoRegimenAReservar = codigoRegimen;
            fechaDesdeAReservar = fechaDesde;
            fechaHastaAReservar = fechaHasta;
            habitacionesAReservar = habitacionesSeleccionadas;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Cliente.DarAltaCliente nuevoCliente = new FrbaHotel.ABM_de_Cliente.DarAltaCliente(hotelAReservar, tipoHabAReservar, codigoRegimenAReservar, fechaDesdeAReservar, fechaHastaAReservar, habitacionesAReservar);
            nuevoCliente.Show(this);
            this.Hide();
        }

        private void opcionNo_CheckedChanged(object sender, EventArgs e)
        {
            lblComplete.Visible = false;
            lblTDoc.Visible = false;
            cmbTDoc.Visible = false;
            lblNDoc.Visible = false;
            txtNDoc.Visible = false;
            lblMail.Visible = false;
            txtMail.Visible = false;
            btnBuscar.Visible = false;
            btnRegistrarse.Visible = true;
            
        }

        private void opcionSi_CheckedChanged(object sender, EventArgs e)
        {
            lblComplete.Visible = true;
            lblTDoc.Visible = true;
            cmbTDoc.Visible = true;
            lblNDoc.Visible = true;
            txtNDoc.Visible = true;
            lblMail.Visible = true;
            txtMail.Visible = true;
            btnBuscar.Visible = true;
            btnRegistrarse.Visible = false;

            DataTable tDoc = FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.ObtenerTodosLosTipoDePasaporte();
            cmbTDoc.DisplayMember = "Pasaporte_Tipo_Descripcion";
            cmbTDoc.ValueMember = "Pasaporte_Tipo";
            cmbTDoc.DataSource = tDoc;

            cmbTDoc.Update();

        }

        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int tDocumento = Convert.ToInt32(cmbTDoc.SelectedValue);
            decimal nDocumento;
            
            if(txtNDoc.Text.Length != 0)
            {
                nDocumento = Convert.ToInt32(txtNDoc.Text);
            } 
            else
            {
                nDocumento = 0;
            }
            string mail = txtMail.Text;

            DataTable cliente = FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.obtenerCliente(tDocumento, nDocumento, mail);

            if (cliente.Rows.Count == 1)
            {
                DataRow filaCliente = cliente.Rows[0];
                codigoClienteAReservar = (int) filaCliente[3];
                System.Windows.Forms.MessageBox.Show("Cliente encontrado, procesando tu reserva");
                FrbaHotel.Generar_Modificar_Reserva.NuevaReserva reserva = new NuevaReserva(hotelAReservar, tipoHabAReservar, codigoRegimenAReservar, fechaDesdeAReservar, fechaHastaAReservar, codigoClienteAReservar, habitacionesAReservar);
                btnVolver.PerformClick();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Cliente no encontrado o con algun problema, registrese o consulte a un recepcionista");
            }

        }

        private void txtNDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnBuscar.PerformClick();
            }
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnBuscar.PerformClick();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
                Owner.Show();
                this.Hide();
        }
       
     }
}
