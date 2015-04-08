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
    public partial class BuscarMedicamento : Form
    {
        private string ElMedicamentoElegido = "";
        private string ElidElegido = "-2";

        public string NomYapeEle
        {
            get { return ElMedicamentoElegido; }
        }

        public string idEle
        {
            get { return ElidElegido; }
        }

        public BuscarMedicamento()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dtResultado.SelectedRows.Count > 0)
            {
                ElidElegido = dtResultado.CurrentRow.Cells["medicamento_id"].Value.ToString();
                ElMedicamentoElegido = dtResultado.CurrentRow.Cells["medicamento_descp"].Value.ToString();
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string medicamento = "-4";
            if (tBoxMedicamento.Text != string.Empty)
                medicamento = tBoxMedicamento.Text;
            dtResultado.DataSource = ManejadorNegocio.buscarMedicamentos(medicamento);
            dtResultado.Update();
        }
    }
}
