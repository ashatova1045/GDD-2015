using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.Facturar
{
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
            reserva.DisplayMember = "Reserva_Codigo";
            reserva.ValueMember = "Reserva_Codigo";
            reserva.DataSource = GestorDeSistema.getReservasPorHabActuales(FrbaHotel.Singleton.Instance.hotel); ;
            reserva.Update();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void ver_Click(object sender, EventArgs e)
        {
            lista.DataSource = GestorDeSistema.getConsumidosAuxiliares(Convert.ToDecimal(reserva.SelectedValue));
            totaltext.Text = GestorDeSistema.getPrecioTotal(Convert.ToDecimal(reserva.SelectedValue)); 
        }

        private void facturarb_Click(object sender, EventArgs e)
        {
            GestorDeSistema.facturar(Convert.ToDecimal(reserva.SelectedValue), Convert.ToDecimal(totaltext.Text));
        }
    }
}
