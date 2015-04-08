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
    public partial class ModificacionAfiliados : Form
    {
        protected int nroAfiliadoAModificar;
        protected string planMedicoAnterior;
        protected string cambioMotivo;

        public ModificacionAfiliados(int nroAfiliado)
        {
            InitializeComponent();
            this.nroAfiliadoAModificar = nroAfiliado;
            this.cambioMotivo = string.Empty;
            inicializarCombos();
        }

        private void inicializarCombos()
        {
            cmbSexo.DataSource = ManejadorNegocio.cargarSexosConNull();
            cmbTipoDoc.DataSource = ManejadorNegocio.cargarTipoDocsConNull();
            cmbEstadoCivil.DataSource = ManejadorNegocio.cargarEstadosCivilesConNull();
            inicializarPlanesMedicos();
        }

        private void inicializarPlanesMedicos()
        {
            DataTable planesMedicos = ManejadorNegocio.obtenerPlanesMedicos();
            cmbPlanMedico.DisplayMember = "plan_descripcion";
            cmbPlanMedico.ValueMember = "plan_codigo";
            cmbPlanMedico.DataSource = planesMedicos;
            cmbPlanMedico.Update();
        }

        public void setearMotivoDelCambioDePlan(string motivo)
        {
            this.cambioMotivo = motivo;
        }

        private void ModificacionAfiliados_Load(object sender, EventArgs e)
        {
            DataTable afiliadosEncontrados = ManejadorNegocio.buscarAfiliados(this.nroAfiliadoAModificar, "- 2", "- 2", "- 2", "- 2", -2, "- 2", "- 2");
            this.planMedicoAnterior = afiliadosEncontrados.Rows[0].ItemArray[12].ToString();
            txtNroAfiliado.Text = this.nroAfiliadoAModificar.ToString();
            txtNombre.Text = afiliadosEncontrados.Rows[0].ItemArray[1].ToString();
            txtApellido.Text = afiliadosEncontrados.Rows[0].ItemArray[2].ToString();
            cmbTipoDoc.Text = afiliadosEncontrados.Rows[0].ItemArray[3].ToString();
            txtNroDoc.Text = afiliadosEncontrados.Rows[0].ItemArray[4].ToString();
            txtDireccion.Text = afiliadosEncontrados.Rows[0].ItemArray[5].ToString();
            txtTelefono.Text = afiliadosEncontrados.Rows[0].ItemArray[6].ToString();
            txtEmail.Text = afiliadosEncontrados.Rows[0].ItemArray[7].ToString();
            dtFechaNacimiento.Value = Convert.ToDateTime(afiliadosEncontrados.Rows[0].ItemArray[8].ToString());
            cmbSexo.Text = afiliadosEncontrados.Rows[0].ItemArray[9].ToString();
            cmbEstadoCivil.Text = afiliadosEncontrados.Rows[0].ItemArray[10].ToString();
            txtCantHijos.Text = afiliadosEncontrados.Rows[0].ItemArray[11].ToString();
            cmbPlanMedico.Text = this.planMedicoAnterior;
            cmbPlanMedico.TextChanged +=new EventHandler(cmbPlanMedico_TextChanged);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionDeDatos())
            {
                int resultadoActualizacion = ManejadorNegocio.actualizarAfiliado(this.nroAfiliadoAModificar,
                                                  txtNombre.Text,
                                                  txtApellido.Text,
                                                  cmbTipoDoc.SelectedItem.ToString(),
                                                  Convert.ToInt32(txtNroDoc.Text),
                                                  txtDireccion.Text,
                                                  Convert.ToInt32(txtTelefono.Text),
                                                  txtEmail.Text,
                                                  dtFechaNacimiento.Text,
                                                  cmbSexo.SelectedItem.ToString(),
                                                  cmbEstadoCivil.SelectedItem.ToString(),
                                                  Convert.ToInt32(txtCantHijos.Text),
                                                  cmbPlanMedico.Text);

                if (resultadoActualizacion > 0)
                {
                    MessageBox.Show("Afiliado modificado correctamente", "Modificación de Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Ocurrió un error modificando al afiliado", "Error en Modificación!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validacionDeDatos()
        {
            bool resultadoValidacion = true;

            resultadoValidacion = resultadoValidacion && (txtNombre.Text.Length > 0);
            resultadoValidacion = resultadoValidacion && (txtApellido.Text.Length > 0);
            resultadoValidacion = resultadoValidacion && (cmbTipoDoc.SelectedItem != null);
            resultadoValidacion = resultadoValidacion && (txtNroDoc.Text.Length > 0);
            resultadoValidacion = resultadoValidacion && (cmbSexo.SelectedItem != null);
            resultadoValidacion = resultadoValidacion && (cmbEstadoCivil.SelectedItem != null);
            resultadoValidacion = resultadoValidacion && (dtFechaNacimiento.Text.Length > 0);
            resultadoValidacion = resultadoValidacion && (txtDireccion.Text.Length > 0);
            resultadoValidacion = resultadoValidacion && (txtEmail.Text.Length > 0);
            resultadoValidacion = resultadoValidacion && (cmbPlanMedico.SelectedItem != null);
            resultadoValidacion = resultadoValidacion && (txtCantHijos.Text.Length > 0);
            resultadoValidacion = resultadoValidacion && (cambioPlanMedico() && (this.cambioMotivo.Length > 0));

            return resultadoValidacion;
        }

        private bool cambioPlanMedico()
        {
            return (this.planMedicoAnterior != cmbPlanMedico.Text);
        }

        private void cmbPlanMedico_TextChanged(object sender, EventArgs e)
        {
            if (cambioPlanMedico())
            {
                ModifcacionAfiliadoMotivo frmMotivo = new ModifcacionAfiliadoMotivo(this);
                frmMotivo.ShowDialog(this);
                int resCambioPlan = ManejadorNegocio.registroCambioPlanMedico(this.nroAfiliadoAModificar,
                                                                              this.planMedicoAnterior,
                                                                              cmbPlanMedico.Text,
                                                                              this.cambioMotivo);
            }
        }

    }
}
