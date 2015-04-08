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
    public partial class AltaAfiliados : Form
    {
        private int numeroAfiliado;
        private int numeroAfiliadoParentesco;

        public AltaAfiliados()
        {
            InitializeComponent();
            inicializarCampos();
        }

        private void inicializarCampos()
        {
            inicializarNumeroDeAfiliado();
            inicializarCombos();
        }

        private void inicializarCombos()
        {
            cmbSexo.DataSource = ManejadorNegocio.cargarSexosConNull();
            cmbTipoDoc.DataSource = ManejadorNegocio.cargarTipoDocsConNull();
            cmbEstadoCivil.DataSource = ManejadorNegocio.cargarEstadosCivilesConNull();
            inicializarPlanesMedicos();
        }

        private void inicializarNumeroDeAfiliado()
        {
            int nuevoNumeroAfiliado = ManejadorNegocio.obtenerNuevaSecuenciaDeTabla("afiliado",101,100);
            this.numeroAfiliado = nuevoNumeroAfiliado;
            this.numeroAfiliadoParentesco = nuevoNumeroAfiliado;
            lblNroAfiliado.Text = (this.numeroAfiliado).ToString();
        }

        private void inicializarPlanesMedicos()
        {
            DataTable planesMedicos = ManejadorNegocio.obtenerPlanesMedicos();
            cmbPlanMedico.DisplayMember = "plan_descripcion";
            cmbPlanMedico.ValueMember = "plan_codigo";
            cmbPlanMedico.DataSource = planesMedicos;
            cmbPlanMedico.Update();
        }

        public int getNumeroAfiliadoParentesco()
        {
            return (this.numeroAfiliadoParentesco);
        }

        public void actualizarNumeroAfiliadoParentesco(int numeroAfiliadoParentesco)
        {
            this.numeroAfiliadoParentesco = numeroAfiliadoParentesco;
        }

        public string getApellido()
        {
            return (txtApellido.Text);
        }

        public string getPlanMedico()
        {
            return (cmbPlanMedico.Text);
        }

        public string getDireccion()
        {
            return (txtDireccion.Text);
        }

        public int getEstadoCivil() {
            return (cmbEstadoCivil.SelectedIndex);
        }

        public string getTelefono()
        {
            return (txtTelefono.Text);
        }

        public string getCantHijos()
        {
            return (txtCantHijos.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionDeDatos())
            {
                if (guardarAfiliado())
                {
                    MessageBox.Show("El afiliado se guardo correctamente", "Alta de Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    validarIngresoDeConyuge();
                    validarIngresoDeHijos();
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
            resultadoValidacion = resultadoValidacion && (cmbPlanMedico.SelectedItem != null);
            resultadoValidacion = resultadoValidacion && (txtCantHijos.Text.Length > 0);

            return resultadoValidacion;
        }

        private bool guardarAfiliado()
        {
            int resultadoInsercion = ManejadorNegocio.insertarAfiliado(this.numeroAfiliado,
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

            return (resultadoInsercion != 0);
        }

        private void validarIngresoDeConyuge()
        {
            string estadoCivilSeleccionado = cmbEstadoCivil.SelectedItem.ToString();
            if ((estadoCivilSeleccionado == "CASADO/A") || (estadoCivilSeleccionado == "CONCUBINATO"))
            {
                DialogResult registraConyuge = MessageBox.Show("¿Desea cargar a su cónyuge como Afiliado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (registraConyuge == DialogResult.Yes)
                {
                    AltaAfiliadosFamiliar frmConyuge = new AltaAfiliadosFamiliar("CONYUGE", this);
                    frmConyuge.ShowDialog(this);
                }
            }
        }

        private void validarIngresoDeHijos()
        {
            int cantHijos = Convert.ToInt32(txtCantHijos.Text);
            if (cantHijos > 0)
            {
                for (int nroHijo = 1; nroHijo <= cantHijos; nroHijo++)
                {
                    DialogResult registraHijos = MessageBox.Show("¿Desea cargar a su hijo numero " + nroHijo.ToString() + " ?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (registraHijos == DialogResult.Yes)
                    {
                        AltaAfiliadosFamiliar frmHijo = new AltaAfiliadosFamiliar("HIJO", this);
                        frmHijo.ShowDialog(this);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCantHijos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
