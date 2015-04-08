using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FrbaHotel.ABM_de_Hotel
{
    public partial class ModificarHotel : Form
    {
        private Int32 idhotel;
        private bool hab;
        public ModificarHotel(DataGridViewRow hotel)
        {
            InitializeComponent();
            
            idhotel=Convert.ToInt32(hotel.Cells["id"].Value);
            hab= Convert.ToBoolean(hotel.Cells["habilitado"].Value);

            ciudadt.Text = Convert.ToString(hotel.Cells["ciudad"].Value);
            callet.Text = Convert.ToString(hotel.Cells["calle"].Value);
            ncallet.Text = Convert.ToString(hotel.Cells["nrocalle"].Value);
            cantes.Text = Convert.ToString(hotel.Cells["cante"].Value);
            reccantes.Text = Convert.ToString(hotel.Cells["recarga"].Value);
            mailt.Text = Convert.ToString(hotel.Cells["mail"].Value);
            paist.Text = Convert.ToString(hotel.Cells["pais"].Value);
            nombret.Text = Convert.ToString(hotel.Cells["nombre"].Value);
            telefonot.Text = Convert.ToString(hotel.Cells["telefono"].Value);
            habilitado.Checked = hab;
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if (hab && !habilitado.Checked)
            {
                MessageBox.Show("Para deshabilitar un hotel, vuelva  a la pantalla anterior y borrelo");
                return;
            }
            if (!hab && habilitado.Checked)
                FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.habilitarHotel(idhotel);

            FrbaHotel.OperacionesDB.ModeloSistema.GestorDeSistema.modificarHotel(idhotel, ciudadt.Text, callet.Text,ncallet.Text, cantes.Text, reccantes.Text, mailt.Text, paist.Text, nombret.Text, telefonot.Text);
            MessageBox.Show("Hotel modificado");
            volver.PerformClick();
        }
    }
}
