using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.AgendaMedico
{
    public partial class RegistroAgendaMedico : Form
    {
        int idProf = 0;
        int tipoRol = 0;
 
        public RegistroAgendaMedico(int rolLogueado, int usuarioLogueado)
        {
            InitializeComponent();

            dtpDesde.Value = ManejadorFechaHora.obtenerFechaDelSistema();
            dtpHasta.Value = ManejadorFechaHora.obtenerFechaDelSistema().AddDays(1);

            

            lblIDProf.Text = ManejadorNegocio.obtenerProfesionalParaUsuario(usuarioLogueado).ToString();

            idProf = Convert.ToInt32(lblIDProf.Text);

            tipoRol = rolLogueado;

            if (tipoRol == 3) // 3 = PROFESIONAL
            {
                //ES PROFESIONAL
                tBoxNomYApe.Enabled = false;
                tBoxDni.Enabled = false;
                btnBuscarProf.Enabled = false;
                DataTable dtResultado = (DataTable)ManejadorNegocio.BuscarProfesional(Convert.ToInt32(lblIDProf.Text), "- 2", "- 2", -2, "- 2", -2, "- 2", "- 2", DateTime.Parse("1900-01-01 00:00:00.000"), "- 2", "- 2", "- 2");
                tBoxDni.Text = dtResultado.Rows[0]["prof_num_dni"].ToString();
                tBoxNomYApe.Text = dtResultado.Rows[0]["prof_nombre"].ToString() + " " + dtResultado.Rows[0]["prof_apellido"].ToString();
            }
            else
            {
                //ES ADMIN O AFILIADO
                tBoxNomYApe.Enabled = true;
                tBoxDni.Enabled = true;
                btnBuscarProf.Enabled = true;
            }
        }

        private void checkLunes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLunes.Checked)
            {
                horarioInicial lunesInicial = new horarioInicial("lunes");
                lunesInicial.ShowDialog(this);
                tBoxDesdeLunes.Text = lunesInicial.horarioElegido.ToString();

                if (tBoxDesdeLunes.Text != "00:00")
                {
                    horarioFinal lunesFinal = new horarioFinal("lunes", lunesInicial.horarioElegido);
                    lunesFinal.ShowDialog(this);
                    tBoxHastaLunes.Text = lunesFinal.horarioElegido.ToString();

                    TimeSpan horarioNulo = new TimeSpan(0);
                    if (lunesInicial.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkLunes.Checked = false;
                    }
                    if (lunesFinal.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkLunes.Checked = false;
                    }
                }
                else
                {
                    tBoxDesdeLunes.ResetText();
                    tBoxHastaLunes.ResetText();
                    checkLunes.Checked = false;
                }
            }
            else
            {
                tBoxDesdeLunes.ResetText();
                tBoxHastaLunes.ResetText();
                checkLunes.Checked = false;
            }
        }

        private void checkMartes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMartes.Checked)
            {
                horarioInicial martesInicial = new horarioInicial("martes");
                martesInicial.ShowDialog(this);
                tBoxDesdeMartes.Text = martesInicial.horarioElegido.ToString();

                if (tBoxDesdeMartes.Text != "00:00")
                {
                    horarioFinal martesFinal = new horarioFinal("martes", martesInicial.horarioElegido);
                    martesFinal.ShowDialog(this);
                    tBoxHastaMartes.Text = martesFinal.horarioElegido.ToString();

                    TimeSpan horarioNulo = new TimeSpan(0);
                    if (martesInicial.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkMartes.Checked = false;
                    }
                    if (martesFinal.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkMartes.Checked = false;
                    }
                }
                else
                {
                    tBoxDesdeMartes.ResetText();
                    tBoxHastaMartes.ResetText();
                    checkMartes.Checked = false;
                }
            }
            else
            {
                tBoxDesdeMartes.ResetText();
                tBoxHastaMartes.ResetText();
                checkMartes.Checked = false;
            }
        }

        private void checkMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMiercoles.Checked)
            {
                horarioInicial miercolesInicial = new horarioInicial("miercoles");
                miercolesInicial.ShowDialog(this);
                tBoxDesdeMiercoles.Text = miercolesInicial.horarioElegido.ToString();

                if (tBoxDesdeMiercoles.Text != "00:00")
                {
                    horarioFinal miercolesFinal = new horarioFinal("miercoles", miercolesInicial.horarioElegido);
                    miercolesFinal.ShowDialog(this);
                    tBoxHastaMiercoles.Text = miercolesFinal.horarioElegido.ToString();

                    TimeSpan horarioNulo = new TimeSpan(0);
                    if (miercolesInicial.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkMiercoles.Checked = false;
                    }
                    if (miercolesFinal.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkMiercoles.Checked = false;
                    }
                }
                else
                {
                    tBoxDesdeMiercoles.ResetText();
                    tBoxHastaMiercoles.ResetText();
                    checkMiercoles.Checked = false;
                }
            }
            else
            {
                tBoxDesdeMiercoles.ResetText();
                tBoxHastaMiercoles.ResetText();
                checkMiercoles.Checked = false;
            }
        }

        private void checkJueves_CheckedChanged(object sender, EventArgs e)
        {
            if (checkJueves.Checked)
            {
                horarioInicial juevesInicial = new horarioInicial("jueves");
                juevesInicial.ShowDialog(this);
                tBoxDesdeJueves.Text = juevesInicial.horarioElegido.ToString();

                if (tBoxDesdeJueves.Text != "00:00")
                {


                    horarioFinal juevesFinal = new horarioFinal("jueves", juevesInicial.horarioElegido);
                    juevesFinal.ShowDialog(this);
                    tBoxHastaJueves.Text = juevesFinal.horarioElegido.ToString();

                    TimeSpan horarioNulo = new TimeSpan(0);
                    if (juevesInicial.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkJueves.Checked = false;
                    }
                    if (juevesFinal.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkJueves.Checked = false;
                    }
                }
                else
                {
                    tBoxDesdeJueves.ResetText();
                    tBoxHastaJueves.ResetText();
                    checkJueves.Checked = false;
                }
            }
            else
            {
                tBoxDesdeJueves.ResetText();
                tBoxHastaJueves.ResetText();
                checkJueves.Checked = false;
            }
        }

        private void checkViernes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkViernes.Checked)
            {
                horarioInicial viernesInicial = new horarioInicial("viernes");
                viernesInicial.ShowDialog(this);
                tBoxDesdeViernes.Text = viernesInicial.horarioElegido.ToString();

                if (tBoxDesdeViernes.Text != "00:00")
                {
                    horarioFinal viernesFinal = new horarioFinal("viernes", viernesInicial.horarioElegido);
                    viernesFinal.ShowDialog(this);
                    tBoxHastaViernes.Text = viernesFinal.horarioElegido.ToString();

                    TimeSpan horarioNulo = new TimeSpan(0);
                    if (viernesInicial.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkViernes.Checked = false;
                    }
                    if (viernesFinal.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkViernes.Checked = false;
                    }
                }
                else
                {
                    tBoxDesdeViernes.ResetText();
                    tBoxHastaViernes.ResetText();
                    checkViernes.Checked = false;
                }
            }
            else
            {
                tBoxDesdeViernes.ResetText();
                tBoxHastaViernes.ResetText();
                checkViernes.Checked = false;
            }
        }

        private void checkSabado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSabado.Checked)
            {
                horarioInicial sabadoInicial = new horarioInicial("sabado");
                sabadoInicial.ShowDialog(this);
                tBoxDesdeSabado.Text = sabadoInicial.horarioElegido.ToString();

                if (tBoxDesdeSabado.Text != "00:00")
                {
                    horarioFinal sabadoFinal = new horarioFinal("sabado", sabadoInicial.horarioElegido);
                    sabadoFinal.ShowDialog(this);
                    tBoxHastaSabado.Text = sabadoFinal.horarioElegido.ToString();

                    TimeSpan horarioNulo = new TimeSpan(0);
                    if (sabadoInicial.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkSabado.Checked = false;
                    }
                    if (sabadoFinal.horarioElegido.CompareTo(horarioNulo) == 0)
                    {
                        MessageBox.Show("Se insertaron horarios invalidos");
                        checkSabado.Checked = false;
                    }
                }
                else
                {
                    tBoxDesdeSabado.ResetText();
                    tBoxHastaSabado.ResetText();
                    checkSabado.Checked = false;
                }
            }
            else
            {
                tBoxDesdeSabado.ResetText();
                tBoxHastaSabado.ResetText();
                checkSabado.Checked = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verifacarDatos())
            {
                TimeSpan horasSemanales = new TimeSpan(0);
                TimeSpan desdeLunes = new TimeSpan(0);
                TimeSpan hastaLunes = new TimeSpan(0);
                TimeSpan desdeMartes = new TimeSpan(0);
                TimeSpan hastaMartes = new TimeSpan(0);
                TimeSpan desdeMiercoles = new TimeSpan(0);
                TimeSpan hastaMiercoles = new TimeSpan(0);
                TimeSpan desdeJueves = new TimeSpan(0);
                TimeSpan hastaJueves = new TimeSpan(0);
                TimeSpan desdeViernes = new TimeSpan(0);
                TimeSpan hastaViernes = new TimeSpan(0);
                TimeSpan desdeSabado = new TimeSpan(0);
                TimeSpan hastaSabado = new TimeSpan(0);
                if (checkLunes.Checked)
                {
                    TimeSpan horasLunes = TimeSpan.Parse(tBoxHastaLunes.Text).Subtract(TimeSpan.Parse(tBoxDesdeLunes.Text));
                    horasSemanales = horasSemanales.Add(horasLunes);
                    desdeLunes = TimeSpan.Parse(tBoxDesdeLunes.Text);
                    hastaLunes = TimeSpan.Parse(tBoxHastaLunes.Text);
                }
                if (checkMartes.Checked)
                {
                    TimeSpan horasMartes = TimeSpan.Parse(tBoxHastaMartes.Text).Subtract(TimeSpan.Parse(tBoxDesdeMartes.Text));
                    horasSemanales = horasSemanales.Add(horasMartes);
                    desdeMartes = TimeSpan.Parse(tBoxDesdeMartes.Text);
                    hastaMartes = TimeSpan.Parse(tBoxHastaMartes.Text);
                }
                if (checkMiercoles.Checked)
                {
                    TimeSpan horasMiercoles = TimeSpan.Parse(tBoxHastaMiercoles.Text).Subtract(TimeSpan.Parse(tBoxDesdeMiercoles.Text));
                    horasSemanales = horasSemanales.Add(horasMiercoles);
                    desdeMiercoles = TimeSpan.Parse(tBoxDesdeMiercoles.Text);
                    hastaMiercoles = TimeSpan.Parse(tBoxHastaMiercoles.Text);
                }
                if (checkJueves.Checked)
                {
                    TimeSpan horasJueves = TimeSpan.Parse(tBoxHastaJueves.Text).Subtract(TimeSpan.Parse(tBoxDesdeJueves.Text));
                    horasSemanales = horasSemanales.Add(horasJueves);
                    desdeJueves = TimeSpan.Parse(tBoxDesdeJueves.Text);
                    hastaJueves = TimeSpan.Parse(tBoxHastaJueves.Text);
                }
                if (checkViernes.Checked)
                {
                    TimeSpan horasViernes = TimeSpan.Parse(tBoxHastaViernes.Text).Subtract(TimeSpan.Parse(tBoxDesdeViernes.Text));
                    horasSemanales = horasSemanales.Add(horasViernes);
                    desdeViernes = TimeSpan.Parse(tBoxDesdeViernes.Text);
                    hastaViernes = TimeSpan.Parse(tBoxHastaViernes.Text);
                }
                if (checkSabado.Checked)
                {
                    TimeSpan horasSabado = TimeSpan.Parse(tBoxHastaSabado.Text).Subtract(TimeSpan.Parse(tBoxDesdeSabado.Text));
                    horasSemanales = horasSemanales.Add(horasSabado);
                    desdeSabado = TimeSpan.Parse(tBoxDesdeSabado.Text);
                    hastaSabado = TimeSpan.Parse(tBoxHastaSabado.Text);
                }
                if (horasSemanales.TotalHours > 48)
                {
                    MessageBox.Show("La carga horaria maxima para un profesional es de 48 horas semanales");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Si existen turnos para el nuevo intervalo de fechas, estos se cancelaran.\n Caso contrario los nuevos turnos se generaran correctamente.\n", "Atencion Agenda", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                     //   string inicio = ManejadorNegocio.darFormatoFecha(dtpDesde.Value);
                     //   string fin = ManejadorNegocio.darFormatoFecha(dtpHasta.Value);
                        ManejadorNegocio.AltaAgendaProfesional(dtpDesde.Value, dtpHasta.Value, Convert.ToInt32(lblIDProf.Text), checkLunes.Checked, checkMartes.Checked, checkMiercoles.Checked, checkJueves.Checked, checkViernes.Checked, checkSabado.Checked, desdeLunes, hastaLunes, desdeMartes, hastaMartes, desdeMiercoles, hastaMiercoles, desdeJueves, hastaJueves, desdeViernes, hastaViernes, desdeSabado, hastaSabado);
                        MessageBox.Show("Agenda creada correctamente");
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //nada
                    }
                }
            }
        }

        private bool verifacarDatos()
        {
            bool valido = true;
            string error = "Corrija los siguientes errores:\n";
            if(lblIDProf.Text == string.Empty)
            {
                error = error + "  - Seleccione un profesional\n";
                valido = false;
            }
            if(!checkLunes.Checked && !checkMartes.Checked && !checkMiercoles.Checked && !checkJueves.Checked && !checkViernes.Checked && !checkSabado.Checked)
            {
                error = error + "  - Al menos tiene que elegir un dia de trabajo\n";
                valido = false;
            }
            if (dtpDesde.Value.CompareTo(dtpHasta.Value) > 0) // si dtpDesde es mas adelante que dtpHasta no vale
            {
                error = error + "  - Fecha de inicio de agenda posterior o igual a la fecha final de agenda.\n";
                valido = false;
            }
            if (dtpHasta.Value.Subtract(dtpDesde.Value).TotalDays > 180)
            {
                error = error + "  - La agenda no puede durar mas de 180 dias.\n";
                valido = false;
            }
            if (dtpDesde.Value.CompareTo(ManejadorFechaHora.obtenerFechaDelSistema()) < 0  )
            {
                error = error + "  - La nueva agenda tiene que ser apartir de hoy.\n";
                valido = false;
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
            if ( tipoRol != 3 ) //SI NO ES PROFESIONAL
            {
                lblIDProf.Text = string.Empty;
                tBoxDni.ResetText();
                tBoxNomYApe.ResetText();
            }
            checkLunes.Checked = false;
            checkMartes.Checked = false;
            checkMiercoles.Checked = false;
            checkJueves.Checked = false;
            checkViernes.Checked = false;
            checkSabado.Checked = false;
            tBoxDesdeLunes.ResetText();
            tBoxHastaLunes.ResetText();
            tBoxDesdeMartes.ResetText();
            tBoxHastaMartes.ResetText();
            tBoxDesdeMiercoles.ResetText();
            tBoxHastaMiercoles.ResetText();
            tBoxDesdeJueves.ResetText();
            tBoxHastaJueves.ResetText();
            tBoxDesdeViernes.ResetText();
            tBoxHastaViernes.ResetText();
            tBoxDesdeSabado.ResetText();
            tBoxHastaSabado.ResetText();
            dtpDesde.Value = ManejadorFechaHora.obtenerFechaDelSistema(); // DIA DE HOY!
            dtpHasta.Value = ManejadorFechaHora.obtenerFechaDelSistema().AddDays(1); // DIA DE MAÑANA
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desa salir?", "Listado Profesional", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnBuscarProf_Click(object sender, EventArgs e)
        {
            BuscarProfesional formBuscarProf = new BuscarProfesional();
            formBuscarProf.ShowDialog(this);
            tBoxNomYApe.Text = formBuscarProf.NomYapeEle;
            tBoxDni.Text = formBuscarProf.dniEle;
            lblIDProf.Text = formBuscarProf.idEle;
        }
    }
}
