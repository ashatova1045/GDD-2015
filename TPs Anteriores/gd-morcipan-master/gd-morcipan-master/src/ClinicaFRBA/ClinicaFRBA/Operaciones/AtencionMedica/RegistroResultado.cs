using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

using ClinicaFRBA.Operaciones.AtencionMedica;

namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    public partial class RegistroResultado : Form
    {
        int idProf = 0;
        int tipoRol = 0;
        public RegistroResultado(int rolLogueado, int usuarioLogueado)
        {
            InitializeComponent();

            lblIdConsulta.Text = string.Empty;
            lblIdProf.Text = string.Empty;

            dtpFecha.Value = ManejadorFechaHora.obtenerFechaDelSistema();
            dtpFechaConsulta.Value = ManejadorFechaHora.obtenerFechaDelSistema();

            lblIdProf.Text = ManejadorNegocio.obtenerProfesionalParaUsuario(usuarioLogueado).ToString();
            
            idProf = Convert.ToInt32(lblIdProf.Text);
            tipoRol = rolLogueado;

            if (tipoRol == 3) // 3 = PROFESIONAL, AFILIADO = 2, ADMIN = 1
            {
                //ES PROFESIONAL
                tBoxNomYApe.Enabled = false;
                tBoxDni.Enabled = false;
                btnBuscarProf.Enabled = false;
                DataTable dtResultado = (DataTable)ManejadorNegocio.BuscarProfesional(Convert.ToInt32(lblIdProf.Text), "- 2", "- 2", -2, "- 2", -2, "- 2", "- 2", DateTime.Parse("1900-01-01 00:00:00.000"), "- 2", "- 2", "- 2");
                tBoxDni.Text = dtResultado.Rows[0]["prof_num_dni"].ToString();
                tBoxNomYApe.Text = dtResultado.Rows[0]["prof_nombre"].ToString() + " " + dtResultado.Rows[0]["prof_apellido"].ToString();
            }
            else
            {
                // ES ADMIN O AFILIADO
                tBoxNomYApe.Enabled = true;
                tBoxDni.Enabled = true;
                btnBuscarProf.Enabled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                string estado;
                DateTime horaAtencion = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, dtpFecha.Value.Day, dtpHora.Value.Hour, dtpHora.Value.Minute, dtpHora.Value.Second);
                if (cBoxConcretada.Checked)
                {
                    //SI SE CONCRETO LA CONSULTA
                    estado = "FINALIZADA";
                    ManejadorNegocio.concluirConsultaMedica(Convert.ToInt32(lblIdConsulta.Text), estado, horaAtencion, tBoxSintomas.Text, tBoxEnfermedades.Text);
                    DialogResult dialogResult = MessageBox.Show("Consulta Cerrada.\nDesea generar una receta?", "Nuevo Receta", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        GenerarReceta frmReceta = new GenerarReceta(Convert.ToInt32(lblIdConsulta.Text));
                        frmReceta.ShowDialog(this);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Desea registrar otra consulta medica?", "Nueva Consulta Medica", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            limpiarCampos();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    //SI NO SE CONCRETO LA CONSULTA
                    estado = "FINALIZADA";
                    ManejadorNegocio.concluirConsultaMedica(Convert.ToInt32(lblIdConsulta.Text), estado, horaAtencion, tBoxSintomas.Text, tBoxEnfermedades.Text);
                    DialogResult dialogResult2 = MessageBox.Show("Desea registrar otra consulta medica?", "Nueva Consulta Medica", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        limpiarCampos();
                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }
        }

        private bool validarDatos()
        {
            string error = "Verifique los siguientes errores.\n";
            bool valido = true;
            if (lblIdProf.Text == "")
            {
                valido = false;
                error = error + "  - Debe elegir un profesional\n";
            }
            if (lblIdConsulta.Text == "")
            {
                valido = false;
                error = error + "  - Debe elegir una consulta medica\n";
            }
            if (cBoxConcretada.Checked)
            {
                if (tBoxEnfermedades.Text == string.Empty)
                {
                    valido = false;
                    error = error + "  - Debe ingresar enfermedades detectadas\n";
                }
                if (tBoxSintomas.Text == string.Empty)
                {
                    valido = false;
                    error = error + "  - Debe ingresar sintomas detectados\n";
                }
                // VERIFICAR QUE SEA EN EL DIA? o.0
            }

            if (!valido)
                MessageBox.Show(error);
            return valido;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            tBoxSintomas.ResetText();
            tBoxPaciente.ResetText();
            dtpFechaConsulta.Value = ManejadorFechaHora.obtenerFechaDelSistema(); // FECHA DE HOY!
            dtpFecha.Value = ManejadorFechaHora.obtenerFechaDelSistema();
            dtpHora.ResetText();
            tBoxEnfermedades.ResetText();
            tBoxSintomas.ResetText();
            cBoxConcretada.Checked = false;
            lblIdConsulta.Text = string.Empty;
            if (tipoRol != 3) //SI NO ES PROFESIONAL
            {
                lblIdProf.Text = string.Empty;
                tBoxDni.ResetText();
                tBoxNomYApe.ResetText();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desa salir?", "Registro Resultado Atencion Medica", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnBuscarProf_Click(object sender, EventArgs e)
        {
            ClinicaFRBA.Operaciones.AgendaMedico.BuscarProfesional formBuscarProf = new ClinicaFRBA.Operaciones.AgendaMedico.BuscarProfesional();
            formBuscarProf.ShowDialog(this);
            tBoxNomYApe.Text = formBuscarProf.NomYapeEle;
            tBoxDni.Text = formBuscarProf.dniEle;
            lblIdProf.Text = formBuscarProf.idEle;
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            if (tBoxDni.Text != string.Empty)
            {
                BuscarConsultas frmConsulta = new BuscarConsultas(Convert.ToInt32(lblIdProf.Text), dtpFechaConsulta.Value);
                frmConsulta.ShowDialog(this);
                if (frmConsulta.idEle.ToString() != "- 2")
                {
                    tBoxPaciente.Text = frmConsulta.NomYapeEle.ToString();
                    lblIdConsulta.Text = frmConsulta.idEle.ToString();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un profesional primero");
            }

        }

        private void cBoxConcretada_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxConcretada.Checked)
            {
                dtpFecha.Enabled = true;
                dtpHora.Enabled = true;
                dtpFecha.Value = ManejadorFechaHora.obtenerFechaDelSistema();
                dtpHora.Text = DateTime.Today.TimeOfDay.ToString();
                tBoxSintomas.Enabled = true;
                tBoxEnfermedades.Enabled = true;
            }
            else
            {
                dtpFecha.Enabled = false;
                dtpFecha.Value = ManejadorFechaHora.obtenerFechaDelSistema();
                dtpHora.Text = DateTime.Today.TimeOfDay.ToString();
                dtpHora.Enabled = false;
                tBoxSintomas.Enabled = false;
                tBoxSintomas.ResetText();
                tBoxEnfermedades.Enabled = false;
                tBoxEnfermedades.ResetText();
            }
        }
    }
}
