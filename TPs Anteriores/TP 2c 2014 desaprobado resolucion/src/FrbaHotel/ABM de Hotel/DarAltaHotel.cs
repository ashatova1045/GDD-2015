using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class DarAltaHotel : Form
    {
        public DarAltaHotel()
        {
            InitializeComponent();
        }

        private void DarAltaClienteBoton_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                GestorDeSistema.nuevoHotel(tciudad.Text, tcalle.Text, Convert.ToDecimal(tncalle.Text), Convert.ToDecimal(ncantestrella.Text), Convert.ToDecimal(rece.Text), tpais.Text, tnombre.Text, tmail.Text, Convert.ToDecimal(ttelefono.Text));

                foreach (Control control in this.Controls)
                {
                    TextBox box = control as TextBox;
                    if (box != null)
                    {
                        box.Clear();
                    }
                }
                MessageBox.Show("Hotel agregado");
            }
            
        }

        private bool validar()
        {
            foreach (Control control in this.Controls)
            {
                TextBox box = control as TextBox;
                if (box != null)
                {
                    if (box.Text == "")
                    {
                        MessageBox.Show("Faltan datos");
                        return false;
                    }
                }
            }
            if (GestorDeSistema.getHotelesRepetidos(tciudad.Text, tcalle.Text, Convert.ToDecimal(tncalle.Text), tpais.Text, tnombre.Text, tmail.Text, Convert.ToDecimal(ttelefono.Text)))
            {
                MessageBox.Show("Datos repetidos");
                return false;
            }
            return true;
        }

        private void VolverBoton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }
    }
}
