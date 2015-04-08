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
    public partial class RegistroLlegada : Form
    {
        private List<string> datosProfesional;
        private int nroAfiliado;

        public RegistroLlegada()
        {
            InitializeComponent();
            lblDatosAfiliado.Text = string.Empty;
            cmbBonosConsulta.Enabled = false;
        }

        public void setearDatosProfesional(List<string> datProfesional)
        {
            this.datosProfesional = datProfesional;
        }

        private void btnBuscarProfesional_Click(object sender, EventArgs e)
        {
            BuscarProfesional frmBuscaProf = new BuscarProfesional(this);
            frmBuscaProf.ShowDialog(this);
            if ((this.datosProfesional != null) && (this.datosProfesional.Count > 0))
            {
                string strDatosProfesional = this.datosProfesional.Aggregate((a, b) => a + "\n" + b);
                lblProfesionalDatos.Text = strDatosProfesional;
                cargarTurnosProfesional(this.datosProfesional[0]);
                txtNroAfiliado.Enabled = true;
                btnValidarAfiliado.Enabled = true;
            } else {
                txtNroAfiliado.Enabled = false;
                btnValidarAfiliado.Enabled = false;
            }
        }

        private void cargarTurnosProfesional(string profesionalId) {
            DateTime fechaParseada = ManejadorFechaHora.obtenerFechaDelSistema();
            DataTable turnosProfesional = ManejadorNegocio.listarTurnosProfesionalDiaSinConsulta(fechaParseada, Convert.ToInt32(profesionalId),"ocupados");
            if (turnosProfesional.Rows.Count > 0)
            {
                foreach (DataRow dr in turnosProfesional.Rows)
                {
                    dgTurnos.Rows.Add(dr.ItemArray[0], dr.ItemArray[2], dr.ItemArray[dr.ItemArray.Length - 1]);
                }
                dgTurnos.Update();
                dgTurnos.ClearSelection();
            }
            else
            {
                MessageBox.Show("El profesional no posee horarios para el día de hoy", "Registro de Llegada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnValidarAfiliado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Al validar el Afiliado automáticamente se seleccionará, si tiene, el turno en la tabla de Turnos (no es necesario que usted seleccione el turno).","Atención!",MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (!this.buscarAfiliadoEnTurnos(txtNroAfiliado.Text))
                    {
                        MessageBox.Show("El afiliado no tiene un turno registrado para este dia", "Registro de Llegada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgTurnos.ClearSelection();
                        btnGuardar.Enabled = false;
                    }
                    else
                    {
                        DataTable bonosAfiliado = ManejadorNegocio.obtenerBonosConsultaParaAfiliado(nroAfiliado);
                        if (bonosAfiliado.Rows.Count > 0)
                        {
                            foreach (DataRow dr in bonosAfiliado.Rows)
                            {
                                cmbBonosConsulta.Items.Add(dr.ItemArray[0].ToString());
 
                            }
                            cmbBonosConsulta.Update();
                            cmbBonosConsulta.Enabled = true;
                            btnGuardar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("El afiliado no tiene bonos consulta disponibles.\nPor favor, solicitele la compra de los mismos", "Registro de Llegada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmbBonosConsulta.DataSource = new DataTable();
                            cmbBonosConsulta.Update();
                            cmbBonosConsulta.Text = string.Empty;
                            cmbBonosConsulta.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro un afiliado con ese Nro.", "Registro de Llegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgTurnos.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un Nro. de Afiliado para validar!", "Validación de Afiliado!", MessageBoxButtons.OK);
            }
            lblDatosAfiliado.Text = datosAfiliado;
        }

        private bool buscarAfiliadoEnTurnos(string nroAfiliado)
        {
            foreach (DataGridViewRow dgRow in dgTurnos.Rows)
            {
                if (dgRow.Cells["idAfiliado"].Value.ToString().Equals(nroAfiliado))
                {
                    dgRow.Selected = true;
                    MessageBox.Show("Se encontró el turno: " + dgRow.Cells[2].Value.ToString(), "Turno encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                int turnoNumero = Convert.ToInt32(dgTurnos.SelectedRows[0].Cells["idTurno"].Value.ToString());
                int bonoConsultaNumero = Convert.ToInt32(cmbBonosConsulta.SelectedItem.ToString());
                int resultado = ManejadorNegocio.insertarConsultaMedica(turnoNumero, this.nroAfiliado, bonoConsultaNumero);
                if (resultado > 0)
                {
                    MessageBox.Show("Registro de llegada satisfactorio!", "Registro de Llegada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error registrando la llegada!", "Registro de Llegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, valide los campos y la selección de Turnos", "Registro de Llegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarCampos()
        {
            bool resultado = true;
            resultado = resultado && (dgTurnos.SelectedRows.Count > 0);
            resultado = resultado && (cmbBonosConsulta.Text.Length > 0);
            resultado = resultado && this.nroAfiliado > 0;
            return resultado;
        }
    }
}
