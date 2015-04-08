using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.Turnos
{
    public partial class BuscarAfiliado : Form
    {
        RegistroTurno frmPadre;

        public BuscarAfiliado(RegistroTurno frmParent)
        {
            InitializeComponent();
            inicializarPlanesMedicos();
            this.frmPadre = frmParent;
        }

        private void inicializarPlanesMedicos()
        {
            DataTable planesMedicos = ManejadorNegocio.obtenerPlanesMedicos();
            planesMedicos.Rows.Add(-2, "");
            cmbPlanMedico.DisplayMember = "plan_descripcion";
            cmbPlanMedico.ValueMember = "plan_codigo";
            cmbPlanMedico.DataSource = planesMedicos;
            cmbPlanMedico.SelectedIndex = (cmbPlanMedico.Items.Count - 1);
            cmbPlanMedico.Update();
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

            if (txtNroAfiliado.Text != string.Empty)
            {
                afiliado_numero = Convert.ToInt32(txtNroAfiliado.Text);
            }

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

            if (cmbSexo.Text != string.Empty)
            {
                afiliado_sexo = cmbSexo.Text;
            }

            if (cmbEstadoCivil.Text != string.Empty)
            {
                afiliado_estado_civil = cmbEstadoCivil.Text;
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
            foreach (DataRow afiliadoEncontrado in afiliadosEncontrados.Rows)
            {
                dtResultado.Rows.Add(afiliadoEncontrado.ItemArray[0],
                                     (afiliadoEncontrado.ItemArray[2].ToString() + ", " + afiliadoEncontrado.ItemArray[1].ToString()),
                                     (afiliadoEncontrado.ItemArray[3].ToString() + ": " + afiliadoEncontrado.ItemArray[4].ToString()),
                                     afiliadoEncontrado.ItemArray[7],
                                     afiliadoEncontrado.ItemArray[9],
                                     afiliadoEncontrado.ItemArray[12]);
            }
            dtResultado.Update();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNroAfiliado.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNroDoc.Text = string.Empty;
            cmbTipoDoc.Text = string.Empty;
            cmbEstadoCivil.Text = string.Empty;
            cmbPlanMedico.Text = string.Empty;
            cmbSexo.Text = string.Empty;
            dtResultado.Rows.Clear();
        }

        private void dtResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                this.frmPadre.setearDatosAfiliado(this.obtenerDatosDeAfiliado(dtResultado.SelectedRows[0].Cells));
                this.Close();
            }
        }

        private void dtResultado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.frmPadre.setearDatosAfiliado(this.obtenerDatosDeAfiliado(dtResultado.Rows[e.RowIndex].Cells));
            this.Close();
        }

        private List<string> obtenerDatosDeAfiliado(DataGridViewCellCollection celdas)
        {
            List<string> datosAfil = new List<string>();
            foreach (DataGridViewCell dgvCell in celdas)
            {
                if (dgvCell.ColumnIndex != 5 && dgvCell.ColumnIndex != 6)
                {
                    datosAfil.Add(dgvCell.Value.ToString());
                }
            }
            return datosAfil;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtResultado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.frmPadre.setearDatosAfiliado(this.obtenerDatosDeAfiliado(dtResultado.Rows[e.RowIndex].Cells));
            this.Close();
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNroAfiliado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
