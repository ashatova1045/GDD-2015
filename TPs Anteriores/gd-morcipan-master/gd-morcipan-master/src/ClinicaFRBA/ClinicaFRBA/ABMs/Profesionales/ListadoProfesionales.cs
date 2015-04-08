using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.ABMs.Profesionales
{
    public partial class ListadoProfesionales : Form
    {
        public ListadoProfesionales()
        {
            InitializeComponent();

            dtpFechaNac.Value = ManejadorFechaHora.obtenerFechaDelSistema();
            btnBaja.Enabled = false;
            btnModificar.Enabled = false;
            incializarEspecialidades();
            List<String> sexos = ManejadorNegocio.cargarSexosConNull();
            List<String> tipoDocs = ManejadorNegocio.cargarTipoDocsConNull();

            cBoxSexo.DataSource = sexos;
            cBoxTipoDoc.DataSource = tipoDocs;
        }

        private void incializarEspecialidades()
        {
            List<String> especialidades = ManejadorNegocio.cargarEspecialidadesConNull();
            cBoxEspecialidad.DataSource = especialidades;
            cBoxEspecialidad.Update();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            tBoxNombre.Clear();
            lblNombre.ForeColor = Color.Black;
            tBoxApellido.Clear();
            lblApellido.ForeColor = Color.Black;
            tBoxDni.Clear();
            lblDni.ForeColor = Color.Black;
            tBoxTelefono.Clear();
            lblTelefono.ForeColor = Color.Black;
            tBoxDireccion.Clear();
            lblDireccion.ForeColor = Color.Black;
            tBoxMatricula.Clear();
            lblMatricula.ForeColor = Color.Black;
            cBoxEspecialidad.ResetText();
            lblEspecialidad.ForeColor = Color.Black;
            cBoxSexo.ResetText();
            lblSexo.ForeColor = Color.Black;
            dtpFechaNac.Value = ManejadorFechaHora.obtenerFechaDelSistema();
            lblFechaNac.ForeColor = Color.Black;
            dtResultado.DataSource = null;
            dtResultado.Update();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desa salir?", "Listado Profesional", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // BUSCAR PROFESIONAL
            string nombre = "- 2";
            string apellido = "- 2";
            int dni = -2;
            string sexo = "- 2";
            string especialidad = "- 2";
            DateTime fechaNac = new DateTime(1900, 01, 01);
            string mail = "- 2";
            string tipoDoc = "- 2";
            string direccion = "- 2";
            int telefono = -2;
            string matricula = "- 2";
            
            if (tBoxNombre.Text != string.Empty)
                nombre = tBoxNombre.Text;

            if (tBoxApellido.Text != string.Empty)
                apellido = tBoxApellido.Text;

            if (tBoxDni.Text != string.Empty)
                dni = Convert.ToInt32(tBoxDni.Text);

            if (tBoxMatricula.Text != string.Empty)
                matricula = tBoxMatricula.Text;

            if (tBoxTelefono.Text != string.Empty)
                telefono = Convert.ToInt32(tBoxTelefono.Text);

            if (tBoxDireccion.Text != string.Empty)
                direccion = tBoxDireccion.Text;

            if (cBoxEspecialidad.Text != string.Empty)
                especialidad = cBoxEspecialidad.Text;

            if (cBoxSexo.Text != string.Empty)
                especialidad = cBoxSexo.Text;

            if (checkFechaNac.Checked)
                fechaNac = dtpFechaNac.Value;

            if (tBoxMail.Text != string.Empty)
                mail = tBoxMail.Text;

            if (cBoxTipoDoc.Text != string.Empty)
                tipoDoc = cBoxTipoDoc.Text;


            dtResultado.DataSource = ManejadorNegocio.BuscarProfesional(-2,nombre, apellido, dni, matricula, telefono, direccion, sexo, fechaNac, especialidad, mail, tipoDoc);
            dtResultado.Update();
            
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            ManejadorNegocio.BajaProfesionalID(Convert.ToInt32(dtResultado.CurrentRow.Cells["prof_id"].Value));
            MessageBox.Show("Profesional dado de baja satisfactoriamente");
            DialogResult dialogResult = MessageBox.Show("Desea realizar otra busqueda?", "Listado Profesional", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                limpiarCampos();
            }
            else
                this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // MODIFICAR PROFESIONAL

            ModificacionProfesionales formModificar = new ModificacionProfesionales(Convert.ToInt32(dtResultado.CurrentRow.Cells["prof_id"].Value.ToString()));
            formModificar.ShowDialog(this);
            DialogResult dialogResult = MessageBox.Show("Desea realizar otra busqueda?", "Listado Profesional", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                limpiarCampos();
            }
            else
                this.Close();

        }

        private void dtResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CUANDO SELECCIONO UNA CELDA ME HABILITA LOS BOTONES
            btnModificar.Enabled = true;
            btnBaja.Enabled = true;
        }

        private void checkFechaNac_CheckedChanged(object sender, EventArgs e)
        {
            // HABILITO O NO LA SELECCION DE FECHA DE NACIMIENTO
            if (checkFechaNac.Checked)
                dtpFechaNac.Enabled = true;
            else
                dtpFechaNac.Enabled = false;
        }

        private void tBoxDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
