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
    public partial class ListadoAfiliados : Form
    {
        public ListadoAfiliados()
        {
            InitializeComponent();
            incializarCombos();
        }

        private void incializarCombos()
        {
            cmbSexo.DataSource = ManejadorNegocio.cargarSexosConNull();
            cmbTipoDoc.DataSource = ManejadorNegocio.cargarTipoDocsConNull();
            cmbEstadoCivil.DataSource = ManejadorNegocio.cargarEstadosCivilesConNull();
            inicializarPlanesMedicos();
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
            if (afiliadosEncontrados.Rows.Count > 0)
            {
                foreach (DataRow afiliadoEncontrado in afiliadosEncontrados.Rows)
                {
                    dtResultado.Rows.Add(afiliadoEncontrado.ItemArray[0],
                                         (afiliadoEncontrado.ItemArray[2].ToString() + ", " + afiliadoEncontrado.ItemArray[1].ToString()),
                                         (afiliadoEncontrado.ItemArray[3].ToString() + ": " + afiliadoEncontrado.ItemArray[4].ToString()),
                                         afiliadoEncontrado.ItemArray[7],
                                         afiliadoEncontrado.ItemArray[9],
                                         afiliadoEncontrado.ItemArray[12].ToString(),
                                         "Modificar",
                                         "Borrar");
                }
                dtResultado.Update();
            }
            else
            {
                MessageBox.Show("No se encontraron afiliados para los filtros aplicados", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.ToString().Length > 0)
            {
                int nroAfiliado = Convert.ToInt32(dtResultado.Rows[e.RowIndex].Cells["cNroAfiliado"].Value.ToString());
                if (e.ColumnIndex == 6)
                {
                    ModificacionAfiliados frmModAfiliado = new ModificacionAfiliados(nroAfiliado);
                    frmModAfiliado.ShowDialog(this);
                    btnBuscar.PerformClick();
                }
                else if (e.ColumnIndex == 7)
                {
                    string afiliado = dtResultado.Rows[e.RowIndex].Cells["cAfiliado"].Value.ToString();
                    DialogResult res = MessageBox.Show("Desea borrar al afiliado: " + afiliado + "?\nTenga en cuenta que si el afiliado es Padre de Familia, serán borrados todos los afiliados relacionados con el mismo.", "Atención!!", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        int resultadoBorrar = ManejadorNegocio.eliminarAfiliado(nroAfiliado);
                        if (resultadoBorrar > 0)
                        {
                            MessageBox.Show("Afiliado eliminado correctamente!", "Eliminación de Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnBuscar.PerformClick();
                        }
                    }
                }
            }
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
    }
}
