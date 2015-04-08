using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;
using ClinicaFRBA.Utils.Seguridad;

using ClinicaFRBA.ABMs.Afiliados;
using ClinicaFRBA.ABMs.EspecialidadesMedicas;
using ClinicaFRBA.ABMs.Planes;
using ClinicaFRBA.ABMs.Profesionales;
using ClinicaFRBA.ABMs.Roles;

using ClinicaFRBA.Operaciones.AgendaMedico;
using ClinicaFRBA.Operaciones.AtencionMedica;
using ClinicaFRBA.Operaciones.Bonos;
using ClinicaFRBA.Operaciones.Turnos;
using ClinicaFRBA.Operaciones.Estadisticas;

namespace ClinicaFRBA
{
    public partial class Inicial : Form
    {
        private int usuarioLogueado;
        private int rolLogueado;
        private bool fABMRol;
        private bool fABMAfiliados;
        private bool fABMProfesional;
        private bool fABMEspMedicas;
        private bool fABMPlan;
        private bool oAgendaMedica;
        private bool oComprarBonos;
        private bool oRegistrarTurno;
        private bool oAtenMedRegistroLlegada;
        private bool oAtenMedRegistroResultado;
        private bool oAtenMedCancelacion;
        private bool listadoEstadistico;

        public Inicial(int pUsuarioLogueado, int pRolLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = pUsuarioLogueado;
            this.rolLogueado = pRolLogueado;
            this.fABMRol = false;
            this.fABMAfiliados = false;
            this.fABMProfesional = false;
            this.fABMEspMedicas = false;
            this.fABMPlan = false;
            this.oAgendaMedica = false;
            this.oComprarBonos = false;
            this.oRegistrarTurno = false;
            this.oAtenMedRegistroLlegada = false;
            this.oAtenMedRegistroResultado = false;
            this.oAtenMedCancelacion = false;
            this.listadoEstadistico = false;
        }

        private void ProcesarPrivilegios()
        {
            if (this.usuarioLogueado != 0)
            {
                DataTable funcionesDelRol = ManejadorNegocio.obtenerFuncionalidadesPorRol(this.rolLogueado);
                foreach (DataRow funcionDeRol in funcionesDelRol.Rows)
                {
                    switch (funcionDeRol["funcion_nombre"].ToString())
                    {
                        case "ABM de Rol":
                            this.fABMRol = true;
                            break;
                        case "ABM de Afiliados":
                            this.fABMAfiliados = true;
                            break;
                        case "ABM de Profesional":
                            this.fABMProfesional = true;
                            break;
                        case "ABM de Especialidades Médicas":
                            // Comentado dado que no es necesario implementar (por enunciado)
                            // fABMEspMedicas = true;
                            break;
                        case "ABM de Plan":
                            // Comentado dado que no es necesario implementar (por enunciado)
                            // fABMPlan = true;
                            break;
                        case "Registrar Agenda Profesional":
                            this.oAgendaMedica = true;
                            break;
                        case "Compra de Bonos":
                            this.oComprarBonos = true;
                            break;
                        case "Pedido de Turno":
                            this.oRegistrarTurno = true;
                            break;
                        case "Registro de llegada para atención médica":
                            this.oAtenMedRegistroLlegada = true;
                            break;
                        case "Registro de resultado para atención médica":
                            this.oAtenMedRegistroResultado = true;
                            break;
                        case "Cancelacion atención médica":
                            this.oAtenMedCancelacion = true;
                            break;
                        case "Listados Estadísticos":
                            listadoEstadistico = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void AnalizarPrivilegios()
        {
            this.rolToolStripMenuItem.Visible = this.fABMRol;
            this.afiliadosToolStripMenuItem.Visible = this.fABMAfiliados;
            /*
            Comentados dado que no es necesario implementarlos (por enunciado)
            this.espMedicasToolStripMenuItem.Visible = this.fABMEspMedicas;
             * this.planesToolStripMenuItem.Visible = this.fABMPlan;
            */
            this.profesionalesToolStripMenuItem.Visible = this.fABMProfesional;
            this.aBMsToolStripMenuItem.Visible = (this.fABMRol || this.fABMAfiliados || this.fABMEspMedicas || this.fABMProfesional || this.fABMPlan);

            this.agendaMédicoToolStripMenuItem.Visible = this.oAgendaMedica;
            this.registrarLlegadaToolStripMenuItem1.Visible = this.oAtenMedRegistroLlegada;
            this.registrarResultadoToolStripMenuItem1.Visible = this.oAtenMedRegistroResultado;
            this.cancelacionToolStripMenuItem.Visible = this.oAtenMedCancelacion;
            this.atencionMedicaToolStripMenuItem.Visible = (this.oAtenMedRegistroLlegada || this.oAtenMedRegistroResultado || this.oAtenMedCancelacion);
            this.comprarBonosToolStripMenuItem.Visible = this.oComprarBonos;
            this.registrarTurnosToolStripMenuItem.Visible = this.oRegistrarTurno;
            this.operacionesToolStripMenuItem.Visible = (this.oAgendaMedica || (this.oAtenMedRegistroLlegada || this.oAtenMedRegistroResultado || this.oAtenMedCancelacion) || this.oComprarBonos || this.oRegistrarTurno);
            this.cancelacionPorPacienteToolStripMenuItem.Visible = (this.oAtenMedCancelacion && (this.rolLogueado == 1 || this.rolLogueado == 2));
            this.cancelacionPorProfToolStripMenuItem.Visible = (this.oAtenMedCancelacion && (this.rolLogueado == 1 || this.rolLogueado == 3));
            this.listadosEstadísticosToolStripMenuItem.Visible = this.listadoEstadistico;
            this.estadísticasToolStripMenuItem.Visible = this.listadoEstadistico;
        }

        private void Inicial_Load(object sender, EventArgs e)
        {
            this.ProcesarPrivilegios();
            this.AnalizarPrivilegios();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AltaAfiliados frmAltaAfiliados = new AltaAfiliados();
            AltaAfiliadoSeleccion frmAltaAfiliados = new AltaAfiliadoSeleccion();
            frmAltaAfiliados.ShowDialog(this);
        }

        private void bajaYModificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoAfiliados frmListadoAfiliados = new ListadoAfiliados();
            frmListadoAfiliados.ShowDialog(this);
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AltaEspMedicas frmAltaEspMedicas = new AltaEspMedicas();
            frmAltaEspMedicas.ShowDialog(this);
        }

        private void bajaYModificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* NO SE IMPLEMENTA POR ENUNCIADO */
        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /* NO SE IMPLEMENTA POR ENUNCIADO */
        }

        private void bajaYModificaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /* NO SE IMPLEMENTA POR ENUNCIADO */
        }

        private void altaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AltaProfesionales frmAltaProfesionales = new AltaProfesionales();
            frmAltaProfesionales.ShowDialog(this);
        }

        private void bajaYModificaciónToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ListadoProfesionales frmListadoProfesionales = new ListadoProfesionales();
            frmListadoProfesionales.ShowDialog(this);
        }

        private void altaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AltaRoles frmAltaRoles = new AltaRoles();
            frmAltaRoles.ShowDialog(this);
        }

        private void bajaYModificaciónToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ListadoRoles frmListadoRoles = new ListadoRoles();
            frmListadoRoles.ShowDialog(this);
        }

        private void agendaMédicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroAgendaMedico frmRegistroAgendaMedico = new RegistroAgendaMedico(this.rolLogueado,this.usuarioLogueado);
            frmRegistroAgendaMedico.ShowDialog(this);
        }

        private void registrarLlegadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistroLlegada frmRegistroLlegada = new RegistroLlegada();
            frmRegistroLlegada.ShowDialog(this);
        }

        private void registrarResultadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistroResultado frmRegistroResultado = new RegistroResultado(this.rolLogueado,this.usuarioLogueado);
            frmRegistroResultado.ShowDialog(this);
        }

        private void comprarBonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompraBonos frmCompraBonos = new CompraBonos(this.usuarioLogueado);
            frmCompraBonos.ShowDialog(this);
        }

        private void registrarTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroTurno frmRegistroTurno = new RegistroTurno(this.rolLogueado, this.usuarioLogueado);
            frmRegistroTurno.ShowDialog(this);
        }

        private void listadosEstadísticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoEstadistico frmListadoEstadistico = new ListadoEstadistico();
            frmListadoEstadistico.ShowDialog(this);
        }

        private void Inicial_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManejadorBD.DesconectarBD();
            Application.Exit();
        }

        private void cancelacionPorProfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelacionProfesional frmProf = new CancelacionProfesional(this.rolLogueado, this.usuarioLogueado);
            frmProf.ShowDialog(this);
        }

        private void cancelacionPorPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelacionPaciente frmPac = new CancelacionPaciente(this.rolLogueado, this.usuarioLogueado);
            frmPac.ShowDialog(this);
        }
    }
}
