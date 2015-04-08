using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using System.Configuration;
using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    public partial class CancelacionPaciente : Form
    {
        private int nroAfiliado;
        private int usuarioLogueado;
        private int rolLogueado;

        public CancelacionPaciente(int rolLogueado, int usuarioLogueado)
        {
            InitializeComponent();
            this.rolLogueado = rolLogueado;
            this.usuarioLogueado = usuarioLogueado;
            lblDatosAfiliado.Text = string.Empty;
            cmbTurnosAfiliado.Enabled = false;
        }

        private void btnValidarAfiliado_Click(object sender, EventArgs e)
        {
            string datosAfiliado = string.Empty;
            if (txtNroAfiliado.Text.Length > 0)
            {
                int nroAfiliado = Convert.ToInt32(txtNroAfiliado.Text);
                DataTable afiliadosEncontrados = ManejadorNegocio.buscarAfiliados(nroAfiliado, "- 2", "- 2", "- 2", "- 2", -2, "- 2", "- 2");
                if (afiliadosEncontrados.Rows.Count > 0)
                {
                    this.nroAfiliado = Convert.ToInt32(afiliadosEncontrados.Rows[0].ItemArray[0]);
                    datosAfiliado = "Afiliado: " + afiliadosEncontrados.Rows[0].ItemArray[2].ToString() + ", " + afiliadosEncontrados.Rows[0].ItemArray[1].ToString() + "\n";
                    datosAfiliado += "Documento: " + afiliadosEncontrados.Rows[0].ItemArray[3].ToString() + " " + afiliadosEncontrados.Rows[0].ItemArray[4].ToString() + "\n";
                    datosAfiliado += "Plan: " + afiliadosEncontrados.Rows[0].ItemArray[12].ToString();
                    DataTable turnosAfiliado = ManejadorNegocio.obtenerTurnosAfiliadoSinConsulta(this.nroAfiliado);
                    cmbTurnosAfiliado.DisplayMember = "turno_fecha";
                    cmbTurnosAfiliado.ValueMember = "turno_numero";
                    cmbTurnosAfiliado.DataSource = turnosAfiliado;
                    cmbTurnosAfiliado.Update();
                    cmbTurnosAfiliado.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontro un afiliado con ese Nro.", "Cancelación de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTurnosAfiliado.DataSource = new DataTable();
                    cmbTurnosAfiliado.Update();
                    cmbTurnosAfiliado.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un Nro. de Afiliado para validar!", "Validación de Afiliado!", MessageBoxButtons.OK);
            }
            lblDatosAfiliado.Text = datosAfiliado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                int turnoNro = Convert.ToInt32(cmbTurnosAfiliado.SelectedValue.ToString());
                int resCancelacion = ManejadorNegocio.cancelarTurnoAfiliado(turnoNro,
                                                                            cmbTipoCancelacion.Text,
                                                                            richTextBox1.Text);
                if (resCancelacion > 0)
                {
                    MessageBox.Show("Turno cancelado correctamente!", "Cancelación de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error cancelando el turno del afiliado.", "Cancelación de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se puede guardar la información ingresada.\nPor favor, verifique que los datos ingresados sean correctos.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarCampos()
        {
            bool resultado = true;
            resultado = resultado && (cmbTurnosAfiliado.Text.Length > 0);
            resultado = resultado && (cmbTipoCancelacion.Text.Length > 0);
            resultado = resultado && (richTextBox1.Text.Length > 0);
            return resultado;
        }

        private void txtNroAfiliado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnValidarAfiliado.PerformClick();
                }
            }
        }

        private void CancelacionPaciente_Load(object sender, EventArgs e)
        {
            if (this.rolLogueado == 2)
            {
                txtNroAfiliado.Text = ManejadorNegocio.obtenerAfiliadoParaUsuario(this.usuarioLogueado).ToString();
                btnValidarAfiliado.PerformClick();
                if (txtNroAfiliado.Text == "0")
                {
                    txtNroAfiliado.Enabled = true;
                    btnValidarAfiliado.Enabled = true;
                }
                else
                {
                    txtNroAfiliado.Enabled = false;
                    btnValidarAfiliado.Enabled = false;
                }
            }
            else
            {
                txtNroAfiliado.Enabled = true;
                btnValidarAfiliado.Enabled = true;
            }
        }
    }
}
