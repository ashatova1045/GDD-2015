using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.Turnos
{
    public partial class RegistroTurno : Form
    {
        private List<string> datosProfesional;
        private List<string> datosAfiliado;

        public RegistroTurno(int rolLogueado, int usuarioLogueado)
        {
            InitializeComponent();
            this.datosProfesional = new List<string>();
            this.datosAfiliado = new List<string>();
            fechaTurno.ValueChanged -= fechaTurno_ValueChanged;
            fechaTurno.Value = ManejadorFechaHora.obtenerFechaDelSistema();
            fechaTurno.ValueChanged += fechaTurno_ValueChanged;
        }

        public void setearDatosProfesional(List<string> datProfesional) {
            this.datosProfesional = datProfesional;
        }

        public void setearDatosAfiliado(List<string> datAfiliados)
        {
            this.datosAfiliado = datAfiliados;
        }

        private void btnBuscarProfesional_Click(object sender, EventArgs e)
        {
            BuscarProfesional frmBuscaProf = new BuscarProfesional(this);
            frmBuscaProf.ShowDialog(this);
            if (this.datosProfesional.Count > 0)
            {
                string strDatosProfesional = this.datosProfesional.Aggregate((a, b) => a + "\n" + b);
                lblProfesionalDatos.Text = strDatosProfesional;
                cargarAgendaProfesional();
            }
        }

        private void cargarAgendaProfesional() {
            string idProfesional = this.datosProfesional[0];
            DataTable rangoFechas = ManejadorNegocio.obtenerRangoFechasAgendaProfesional(Convert.ToInt32(idProfesional));
            if (rangoFechas.Rows.Count > 0)
            {
                DateTime agendaFechaIni = DateTime.Parse(rangoFechas.Rows[0]["agen_fecha_ini"].ToString());
                DateTime agendaFechaFin = DateTime.Parse(rangoFechas.Rows[0]["agen_fecha_fin"].ToString());
                fechaTurno.MinDate = agendaFechaIni;
                fechaTurno.MaxDate = agendaFechaFin;
                fechaTurno.Enabled = true;
                llenarHorasParaDia();
            }
            else
            {
                MessageBox.Show("El profesional no posee una agenda cargada en el sistema", "Agenda de Profesionales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fechaTurno.Text = string.Empty;
                fechaTurno.Enabled = false;
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
                int afiliadoId = Convert.ToInt32(this.datosAfiliado[0]);
                int turnoNumero = Convert.ToInt32(horaTurno.SelectedValue.ToString());
                int resInsercion = ManejadorNegocio.regstrarTurnoAfiliado(afiliadoId, turnoNumero);

                if (resInsercion > 0)
                {
                    MessageBox.Show("Turno Registrado Correctamente!", "Registro de Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error registrando el curso!", "Registro de Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe cargar todos los valores del formulario!", "Registro de Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {
            BuscarAfiliado frmBuscaAfil = new BuscarAfiliado(this);
            frmBuscaAfil.ShowDialog(this);
            if (this.datosAfiliado.Count > 0)
            {
                string strDatosAfiliado = this.datosAfiliado.Aggregate((a, b) => a + "\n" + b);
                lblDatosAfiliado.Text = strDatosAfiliado;
            }
        }

        private bool validarCampos()
        {
            bool res = true;
            res = res && ((this.datosAfiliado.Count > 0) && (this.datosAfiliado[0].Length > 0));
            res = res && (fechaTurno.Text.Length > 0);
            res = res && (horaTurno.Text.Length > 0);
            return res;
        }

        private void llenarHorasParaDia()
        {
            int profesionalId = Convert.ToInt32(this.datosProfesional[0]);
            if (fechaTurno.Text != string.Empty)
            {
                DateTime fecTurno = DateTime.ParseExact(fechaTurno.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                DataTable turnosProf = ManejadorNegocio.listarTurnosProfesionalDia(fecTurno, profesionalId, "libres");
                if (turnosProf.Rows.Count > 0)
                {
                    horaTurno.DisplayMember = "horas_minutos";
                    horaTurno.ValueMember = "turno_numero";
                    horaTurno.DataSource = turnosProf;
                    horaTurno.Update();
                    horaTurno.Enabled = true;
                }
                else
                {
                    MessageBox.Show("El profesional no posee horarios de turnos para la fecha seleccionada", "Agenda de Profesionales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    horaTurno.Text = string.Empty;
                    horaTurno.Enabled = false;
                }
            }
            else
            {
                horaTurno.Enabled = false;
            }
        }

        private void fechaTurno_ValueChanged(object sender, EventArgs e)
        {
            llenarHorasParaDia();
        }

        private void fechaTurno_DropDown(object sender, EventArgs e)
        {
            fechaTurno.ValueChanged -= fechaTurno_ValueChanged;
        }

        private void fechaTurno_CloseUp(object sender, EventArgs e)
        {
            fechaTurno.ValueChanged += fechaTurno_ValueChanged;
            llenarHorasParaDia();
        }
    }
}
