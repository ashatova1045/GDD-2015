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
    public partial class ModifcacionAfiliadoMotivo : Form
    {
        ModificacionAfiliados frmParent;

        public ModifcacionAfiliadoMotivo(ModificacionAfiliados parent)
        {
            InitializeComponent();
            this.frmParent = parent;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rtMotivo.Text.Length > 0)
            {
                this.frmParent.setearMotivoDelCambioDePlan(rtMotivo.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("El motivo es obligatorio!", "Validación de Motivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
