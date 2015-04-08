using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.ABMs.Afiliados
{
    public partial class ListadoAfiliadosPadres : Form
    {
        public ListadoAfiliadosPadres()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int afiliado_numero = -2;
            string afiliado_plan_medico = "- 2";
            string afiliado_nombre = "- 2";
            string afiliado_apellido = "- 2";
            string afiliado_tipo_documento = "- 2";
            int afiliado_nro_documento = -2;
            string afiliado_sexo = "- 2";
            string afiliado_estado_civil = "- 2";

            if (cmbPlanMedico.Text != string.Empty)
            {
                afiliado_plan_medico = cmbPlanMedico.Text;
            }

            if (txtNombre.Text != string.Empty)
            {
                afiliado_nombre = txtNombre.Text;
            }

            if (txtApellido.Text != string.Empty)
            {
                afiliado_apellido = txtApellido.Text;
            }

            if (cmbTipoDoc.Text != string.Empty)
            {
                afiliado_tipo_documento = cmbTipoDoc.Text;
            }

            if (txtNroDoc.Text != string.Empty)
            {
                afiliado_nro_documento = Convert.ToInt32(txtNroDoc.Text);
            }

            dtResultado.Rows.Clear();
            dtResultado.Update();
            DataTable afiliadosEncontrados = ManejadorNegocio.buscarAfiliados(
                afiliado_numero,
                afiliado_plan_medico,
                afiliado_nombre,
                afiliado_apellido,
                afiliado_tipo_documento,
                afiliado_nro_documento,
                afiliado_sexo,
                afiliado_estado_civil
            );
            if (afiliadosEncontrados.Rows.Count > 0)
            {
                foreach (DataRow afiliadoEncontrado in afiliadosEncontrados.Rows)
                {
                    dtResultado.Rows.Add(afiliadoEncontrado.ItemArray[0],
                                         (afiliadoEncontrado.ItemArray[2].ToString() + ", " + afiliadoEncontrado.ItemArray[1].ToString()),
                                         (afiliadoEncontrado.ItemArray[3].ToString() + ": " + afiliadoEncontrado.ItemArray[4].ToString()),
                                         afiliadoEncontrado.ItemArray[9],
                                         afiliadoEncontrado.ItemArray[12].ToString(),
                                         "Seleccionar");
                }
                dtResultado.Update();
            }
            else
            {
                MessageBox.Show("No se encontraron afiliados para los filtros aplicados", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.ToString().Length > 0)
            {
                if (e.ColumnIndex == 5)
                {
                    string nroAfiliado = dtResultado.Rows[e.RowIndex].Cells["cNroAfiliado"].Value.ToString();
                    string afiliado = dtResultado.Rows[e.RowIndex].Cells["cAfiliado"].Value.ToString();
                    string planMedico = dtResultado.Rows[e.RowIndex].Cells["cPlanMedico"].Value.ToString();
                    AltaAfiliadoAgregado frmAltaAgregado = new AltaAfiliadoAgregado(nroAfiliado, afiliado, planMedico);
                    frmAltaAgregado.ShowDialog(this);
                    btnBuscar.PerformClick();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNroDoc.Text = string.Empty;
            cmbTipoDoc.Text = string.Empty;
            cmbPlanMedico.Text = string.Empty;
            dtResultado.Rows.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
