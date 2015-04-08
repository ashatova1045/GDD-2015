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
    public partial class AltaAfiliadoAgregado : Form
    {
        
        public AltaAfiliadoAgregado(string nroAfiliado, string afiliado, string planMedico)
        {
            InitializeComponent();
            inicializarCampos(nroAfiliado, afiliado, planMedico);
        }

        private void inicializarCampos(string nroAfiliado, string afiliado, string planMedico)
        {
            lblNroAfilRefVal.Text = nroAfiliado;
            lblAfiliadoRefVal.Text = afiliado;
            lblPlanMedicoValor.Text = planMedico;
            inicializarCombos();
        }

        private void inicializarCombos()
        {
            cmbSexo.DataSource = ManejadorNegocio.cargarSexosConNull();
            cmbTipoDoc.DataSource = ManejadorNegocio.cargarTipoDocsConNull();
            cmbEstadoCivil.DataSource = ManejadorNegocio.cargarEstadosCivilesConNull();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionDeDatos())
            {
                if (guardarAfiliado())
                {
                    MessageBox.Show("El afiliado se guardo correctamente", "Alta de Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Occurio un error ingresando el Afiliado", "Alta de Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool guardarAfiliado()
        {
            int nroAfiliadoAsignado = ManejadorNegocio.obtenerProximoNroAfiliadoFamilia(Convert.ToInt32(lblNroAfilRefVal.Text));
            int resultadoInsercion = ManejadorNegocio.insertarAfiliado(nroAfiliadoAsignado,
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
                                              0,
                                              lblPlanMedicoValor.Text);

            return (resultadoInsercion != 0);
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

            return resultadoValidacion;
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
