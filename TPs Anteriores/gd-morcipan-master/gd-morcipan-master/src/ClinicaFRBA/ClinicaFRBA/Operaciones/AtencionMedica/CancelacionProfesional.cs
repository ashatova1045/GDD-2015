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
    public partial class CancelacionProfesional : Form
    {
        private int nroProf;
        private int usuarioLogueado;
        private int rolLogueado;

        public CancelacionProfesional(int rolLogueado, int usuarioLogueado)
        {
            InitializeComponent();
            lblDatosProf.Text = String.Empty;
            this.rolLogueado = rolLogueado;
            this.usuarioLogueado = usuarioLogueado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNroProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnValidarProf.PerformClick();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                int resCancelacion = -1;
                bool todosOK = true;
                for (DateTime current = dateTimePicker1.Value; current <= dateTimePicker2.Value; current = current.AddDays(1))
                {
                    try
                    {
                        resCancelacion += ManejadorNegocio.cancelarProfesionalDia(this.nroProf,
                                                                                  current,
                                                                                  cmbTipoCancelacion.Text,
                                                                                  richTextBox1.Text);
                    }
                    catch (Exception ex)
                    {
                        todosOK = false;
                        MessageBox.Show("Ocurrió un error cancelando el día: " + current.ToString() + " del profesional.\n" + ex.Message, "Cancelación de Profesional", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }
                if (todosOK)
                {
                    MessageBox.Show("Turnos desde  " + dateTimePicker1.Value.ToString() + " hasta " + dateTimePicker2.Value.ToString() + " cancelados correctamente", "Cancelación de Turnos Profesional", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            } else {
                MessageBox.Show("No se puede guardar la información ingresada.\nPor favor, verifique que los datos ingresados sean correctos.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarCampos()
        {
            bool resultado = true;
            resultado = resultado && (dateTimePicker1.Text.Length > 0);
            resultado = resultado && (dateTimePicker2.Text.Length > 0);
            if (dateTimePicker1.Value.CompareTo(dateTimePicker2.Value) > 0)
            {
                MessageBox.Show("Verifique las fechas ingresadas. La fecha Desde debe ser menor que la fecha Hasta.", "Cancelacion de Profesional", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = resultado && false;
            }
            resultado = resultado && (cmbTipoCancelacion.Text.Length > 0);
            resultado = resultado && (richTextBox1.Text.Length > 0);

            return resultado;
        }

        private void btnValidarProf_Click(object sender, EventArgs e)
        {
            string datosProfesional = string.Empty;
            if (txtNroProf.Text.Length > 0)
            {
                int nroProf = Convert.ToInt32(txtNroProf.Text);
                DataTable profEncontrados = ManejadorNegocio.BuscarProfesional(nroProf, "- 2", "- 2",-2, "- 2",-2,"- 2","- 2", new DateTime(1900, 01, 01), "- 2", "- 2", "- 2");
                if (profEncontrados.Rows.Count > 0)
                {
                    this.nroProf = Convert.ToInt32(profEncontrados.Rows[0].ItemArray[0]);
                    datosProfesional = "Profesional: " + profEncontrados.Rows[0].ItemArray[2].ToString() + ", " + profEncontrados.Rows[0].ItemArray[1].ToString() + "\n";
                    datosProfesional += "Documento: " + profEncontrados.Rows[0].ItemArray[3].ToString() + " " + profEncontrados.Rows[0].ItemArray[4].ToString() + "\n";
                    datosProfesional += "Dirección: " + profEncontrados.Rows[0].ItemArray[5].ToString() + "\n";
                    datosProfesional += "Teléfono: " + profEncontrados.Rows[0].ItemArray[6].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontro un profesional con ese Nro.", "Validación de Profesional", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un Nro. de Profesional para validar!", "Validación de Profesional", MessageBoxButtons.OK);
            }
            lblDatosProf.Text = datosProfesional;
        }

        private void CancelacionProfesional_Load(object sender, EventArgs e)
        {
            if (this.rolLogueado == 3)
            {
                txtNroProf.Text = ManejadorNegocio.obtenerProfesionalParaUsuario(this.usuarioLogueado).ToString();
                btnValidarProf.PerformClick();
                if (txtNroProf.Text == "0")
                {
                    txtNroProf.Enabled = true;
                    btnValidarProf.Enabled = true;
                }
                else
                {
                    txtNroProf.Enabled = false;
                    btnValidarProf.Enabled = false;
                }
            }
            else
            {
                txtNroProf.Enabled = true;
                btnValidarProf.Enabled = true;
            }
        }
    }
}
