using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Cancelar_Reserva;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            GenerarReserva nuevaReserva = new GenerarReserva();
            nuevaReserva.Show(this);
            this.Hide();
        }

        private void btnModificarReserva_Click(object sender, EventArgs e)
        {
            ModificarReserva modificarReserva = new ModificarReserva();
            modificarReserva.Show(this);
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            CancelarReserva nuevaCancelacion = new CancelarReserva();
            nuevaCancelacion.Show(this);
            this.Hide();
        }
    }
}
