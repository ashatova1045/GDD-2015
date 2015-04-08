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
    public partial class ABMSeleccionH : Form
    {
        public ABMSeleccionH()
        {
            InitializeComponent();
        }

        private void CrearRolButton_Click(object sender, EventArgs e)
        {
            DarAltaHotel nuevoHotel= new DarAltaHotel();
            nuevoHotel.Show(this);
            this.Hide();
        }

        private void VolverButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void DarBajaRolButton_Click(object sender, EventArgs e)
        {
            
            
            if (!(hoteles.SelectedRows.Count == 1) )
            {
                MessageBox.Show("Seleccione solo una fila");
                return;
            }
            if(!Convert.ToBoolean(hoteles.CurrentRow.Cells["habilitado"].Value))
            {
                MessageBox.Show("Este hotel ya esta deshabilitado");
                return;
            }
            
            Int32 id = Convert.ToInt32(hoteles.CurrentRow.Cells["id"].Value);

            if (GestorDeSistema.darBajaHotel(id, motivo.Text) == 1)
            {
                MessageBox.Show("Baja exitosa");
                Buscar.PerformClick();
            }
            else
                MessageBox.Show("Hay reservas activas sobre ese hotel");
            
            
        }

        private void ModificarRolButton_Click(object sender, EventArgs e)
        {
            if (hoteles.SelectedRows.Count == 1)
            {
                (new ModificarHotel(hoteles.CurrentRow)).Show(this);
                this.Hide();
            }
        }

        private void Buscar_Click_1(object sender, EventArgs e)
        {
            hoteles.DataSource = GestorDeSistema.buscarHoteles(ciudadt.Text, callet.Text, ncallet.Text, cantes.Text, reccantes.Text, mailt.Text, paist.Text, nombret.Text, telefonot.Text, fechacreacion.Value, fechacheck.Checked,habilitadoch.Checked);
            hoteles.Update();
        }

    }
}
