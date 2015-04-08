using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicaFRBA.ABMs.Afiliados
{
    public partial class AltaAfiliadoSeleccion : Form
    {
        public AltaAfiliadoSeleccion()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoAfiliado_Click(object sender, EventArgs e)
        {
            AltaAfiliados frmAltaAfiliado = new AltaAfiliados();
            frmAltaAfiliado.ShowDialog(this);
            this.Hide();
        }

        private void btnAgregarAfiliado_Click(object sender, EventArgs e)
        {
            ListadoAfiliadosPadres listadoAfilidos = new ListadoAfiliadosPadres();
            listadoAfilidos.ShowDialog(this);
        }
    }
}
