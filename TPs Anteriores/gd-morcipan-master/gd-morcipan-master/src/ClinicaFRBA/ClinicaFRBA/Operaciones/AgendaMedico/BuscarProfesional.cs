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
    public partial class BuscarProfesional : Form
    {
        private string ElnomYapeElegido;
        private string EldniElegido;
        private string ElidElegido;

        public string NomYapeEle
        {
            get{ return ElnomYapeElegido; }
        }
        public string dniEle
        {
            get { return EldniElegido; }
        }

        public string idEle
        {
            get { return ElidElegido; }
        }

        public BuscarProfesional()
        {
            InitializeComponent();

            dtpFechaNac.Value = ManejadorFechaHora.obtenerFechaDelSistema();

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
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(dtResultado.SelectedRows.Count > 0)
            {
                ElidElegido = dtResultado.CurrentRow.Cells["prof_id"].Value.ToString();
                EldniElegido = dtResultado.CurrentRow.Cells["prof_num_dni"].Value.ToString();
                ElnomYapeElegido = dtResultado.CurrentRow.Cells["prof_nombre"].Value.ToString() + ' ' + dtResultado.CurrentRow.Cells["prof_apellido"].Value.ToString();
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
            DateTime fechaNac = new DateTime(1900,01,01);
            string direccion = "- 2";
            int telefono = -2;
            string matricula = "- 2";
            string mail = "- 2";
            string tipoDoc = "- 2";

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

            dtResultado.DataSource = ManejadorNegocio.BuscarProfesional(-2,nombre, apellido, dni, matricula, telefono, direccion, sexo, fechaNac, especialidad,mail,tipoDoc);
            dtResultado.Update();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desa salir?", "Listado Profesional", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
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
