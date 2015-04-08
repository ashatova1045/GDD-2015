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
    public partial class AltaAfiliadosFamiliar : Form
    {
        private int numeroAfiliadoAUtilizar;
        private string queEstoyCargando;
        private AltaAfiliados padreFamilia;

        public AltaAfiliadosFamiliar(string queSeCarga, AltaAfiliados padre)
        {
            InitializeComponent();
            this.padreFamilia = padre;
            inicializarCombos();
            establecerValores(queSeCarga);
        }

        private void inicializarCombos()
        {
            cmbSexo.DataSource = ManejadorNegocio.cargarSexosConNull();
            cmbTipoDoc.DataSource = ManejadorNegocio.cargarTipoDocsConNull();
            cmbEstadoCivil.DataSource = ManejadorNegocio.cargarEstadosCivilesConNull();
        }

        private void establecerValores(string queSeCarga)
        {
            lblPlanMedicoValor.Text = this.padreFamilia.getPlanMedico();
            txtDireccion.Text = this.padreFamilia.getDireccion();
            txtTelefono.Text = this.padreFamilia.getTelefono();
            this.queEstoyCargando = queSeCarga;
            int numeroAfiliadoAnterior = this.padreFamilia.getNumeroAfiliadoParentesco();
            switch (queSeCarga)
            {
                case "CONYUGE":
                    this.numeroAfiliadoAUtilizar = numeroAfiliadoAnterior + 1;
                    cmbEstadoCivil.SelectedIndex = this.padreFamilia.getEstadoCivil();
                    break;
                case "HIJO":
                    this.numeroAfiliadoAUtilizar = (numeroAfiliadoAnterior.ToString().EndsWith("2") ? (numeroAfiliadoAnterior + 2) : (numeroAfiliadoAnterior + 1));
                    txtApellido.Text = this.padreFamilia.getApellido();
                    break;
                default:
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionDeDatos())
            {
                if (guardarAfiliado())
                {
                    this.padreFamilia.actualizarNumeroAfiliadoParentesco(this.numeroAfiliadoAUtilizar);
                    MessageBox.Show("El afiliado se guardo correctamente", "Alta de Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Occurio un error ingresando el Afiliado", "Alta de Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            return resultadoValidacion;
        }

        private bool guardarAfiliado()
        {
            int resultadoInsercion = ManejadorNegocio.insertarAfiliado(
                                              this.numeroAfiliadoAUtilizar,
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
                                              ((this.queEstoyCargando == "CONYUGE") ? Convert.ToInt32(this.padreFamilia.getCantHijos()) : 0),
                                              lblPlanMedicoValor.Text);

            return (resultadoInsercion != 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
