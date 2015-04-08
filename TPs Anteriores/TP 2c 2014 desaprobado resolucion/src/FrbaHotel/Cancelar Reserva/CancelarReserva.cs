using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class CancelarReserva : Form
    {

        int hotelID;
        decimal reservaCodigo;
        string motivo;
        int codigoRol, usuarioID;
        DateTime fecha;


        public CancelarReserva()
        {
            InitializeComponent();
            lblMotivo.Visible = false;
            txtMotivo.Visible = false;
            btnCancelar.Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Owner.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            reservaCodigo = Convert.ToDecimal(txtNReserva.Text);
            DataTable reserva = GestorDeSistema.obtenerReserva(reservaCodigo);
            if (reserva.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Numero de reserva no encontrado");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Numero de reserva encontrado");
                lblMotivo.Visible = true;
                txtMotivo.Visible = true;
                btnCancelar.Visible = true;
                comboopciones.Visible = true;
                DataRow reservaFila = reserva.Rows[0];
       
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            motivo = txtNReserva.Text;
            usuarioID = FrbaHotel.Singleton.Instance.usuarioID;
            codigoRol = FrbaHotel.Singleton.Instance.rol_cod;
            hotelID = FrbaHotel.Singleton.Instance.hotel;
            string estado = comboopciones.Text;
            fecha = DateTime.Today;
            GestorDeSistema.bajaReserva(reservaCodigo, motivo, hotelID, usuarioID, fecha, codigoRol,estado);
            System.Windows.Forms.MessageBox.Show("Su reserva ha sido dada de baja");
            btnVolver.PerformClick();
        }
    }
}
