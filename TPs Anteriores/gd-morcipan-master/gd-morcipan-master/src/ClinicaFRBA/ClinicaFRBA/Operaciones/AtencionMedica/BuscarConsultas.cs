using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    public partial class BuscarConsultas : Form
    {
        private string ElnomYapeElegido;
        private string ElidElegido = "- 2";

        public string NomYapeEle
        {
            get { return ElnomYapeElegido; }
        }

        public string idEle
        {
            get { return ElidElegido; }
        }

        public BuscarConsultas(int prof_id, DateTime fecha)
        {
            InitializeComponent();

            dtResultado.DataSource = ManejadorNegocio.buscarConsultas(prof_id, fecha);
            dtResultado.Update();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dtResultado.SelectedRows.Count > 0)
            {
                ElidElegido = dtResultado.CurrentRow.Cells["consulta_id"].Value.ToString();
                ElnomYapeElegido = dtResultado.CurrentRow.Cells["afiliado_nombre"].Value.ToString() + ' ' + dtResultado.CurrentRow.Cells["afiliado_apellido"].Value.ToString();
                this.Close();
            }
        }
    }
}
