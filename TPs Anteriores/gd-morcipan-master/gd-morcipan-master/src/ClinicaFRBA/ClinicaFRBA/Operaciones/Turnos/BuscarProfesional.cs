using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.Turnos
{
    public partial class BuscarProfesional : Form
    {
        RegistroTurno frmPadre;
        public BuscarProfesional(RegistroTurno frmParent)
        {
            InitializeComponent();
            incializarEspecialidades();
            this.frmPadre = frmParent;
        }
        private void incializarEspecialidades()
        {
            List<String> especialidades = ManejadorNegocio.cargarEspecialidadesConNull();
            cBoxEspecialidad.DataSource = especialidades;
            cBoxEspecialidad.Update();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgProfesionales_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.frmPadre.setearDatosProfesional(this.obtenerDatosDeProfesional(dgProfesionales.Rows[e.RowIndex].Cells));
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgProfesionales.Rows.Clear();
            string nombre = "- 2";
            string apellido = "- 2";
            int dni = -2;
            string sexo = "- 2";
            DateTime fechaNac = new DateTime(1900, 01, 01);
            string direccion = "- 2";
            int telefono = -2;
            string matricula = "- 2";
            string especialidad = "- 2";
            string mail = "- 2";
            string tipoDoc = "- 2";

            if (tBoxNombre.Text != string.Empty)
            {
                nombre = tBoxNombre.Text;
            }

            if (tBoxApellido.Text != string.Empty)
            {
                apellido = tBoxApellido.Text;
            }

            if (cBoxEspecialidad.Text != string.Empty)
            {
                especialidad = cBoxEspecialidad.Text;
            }

            DataTable dtResultado = (DataTable)ManejadorNegocio.BuscarProfesional(-2, nombre, apellido, dni, matricula, telefono, direccion, sexo, fechaNac, especialidad, mail, tipoDoc);
            foreach (DataRow dr in dtResultado.Rows)
            {
                dgProfesionales.Rows.Add(dr.ItemArray[0].ToString(),
                                         dr.ItemArray[2].ToString() + ", " + dr.ItemArray[1].ToString(),
                                         dr.ItemArray[5].ToString());

            }
            dgProfesionales.Update();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tBoxNombre.Text = string.Empty;
            tBoxApellido.Text = string.Empty;
            cBoxEspecialidad.Text = string.Empty;
            dgProfesionales.Rows.Clear();
        }

        private void dgProfesionales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                this.frmPadre.setearDatosProfesional(this.obtenerDatosDeProfesional(dgProfesionales.SelectedRows[0].Cells));
                this.Close();
            }
        }

        private List<string> obtenerDatosDeProfesional(DataGridViewCellCollection celdas)
        {
            List<string> datosProf = new List<string>();
            foreach (DataGridViewCell dgvCell in celdas)
            {
                datosProf.Add(dgvCell.Value.ToString());
            }
            return datosProf;
        }

        private void dgProfesionales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.frmPadre.setearDatosProfesional(this.obtenerDatosDeProfesional(dgProfesionales.Rows[e.RowIndex].Cells));
            this.Close();
        }
    }
}
