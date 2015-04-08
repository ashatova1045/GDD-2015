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
    public partial class ModificacionProfesionales : Form
    {
        public static int id_amodificar = 0;
        public ModificacionProfesionales(int prof_id)
        {
            InitializeComponent();

            dtpFechaNac.Value = ManejadorFechaHora.obtenerFechaDelSistema();
            id_amodificar = prof_id;

            List<string> especialidades = ManejadorNegocio.cargarEspecialidades();
            foreach (string especialidad in especialidades)
            {
                cListEspecialidades.Items.Add(especialidad);
            }

            List<String> sexos = ManejadorNegocio.cargarSexos();
            List<String> tipoDocs = ManejadorNegocio.cargarTipoDocs();

            cBoxSexo.DataSource = sexos;
            cBoxTipoDoc.DataSource = tipoDocs;

            DataTable tabla = ManejadorNegocio.BuscarProfesional(prof_id,"- 2","- 2",-2,"- 2",-2,"- 2","- 2", new DateTime(1900,01,01), "- 2", "- 2", "- 2");
            if( tabla.Rows.Count >= 1 )
            {
                tBoxApellido.Text = tabla.Rows[0]["prof_apellido"].ToString();
                tBoxDireccion.Text = tabla.Rows[0]["prof_direccion"].ToString();
                tBoxMatricula.Text = tabla.Rows[0]["prof_matr"].ToString();
                tBoxNombre.Text = tabla.Rows[0]["prof_nombre"].ToString();
                tBoxNumeroDoc.Text = tabla.Rows[0]["prof_num_dni"].ToString();
                tBoxTelefono.Text = tabla.Rows[0]["prof_telefono"].ToString();
                cBoxSexo.Text = tabla.Rows[0]["prof_sex"].ToString();
                dtpFechaNac.Value = Convert.ToDateTime(tabla.Rows[0]["prof_fechaNac"]);
                tBoxMail.Text = tabla.Rows[0]["prof_mail"].ToString();
                cBoxSexo.Text = tabla.Rows[0]["prof_sex"].ToString();
                cBoxTipoDoc.Text = tabla.Rows[0]["prof_tipo_doc"].ToString();

                List<String> especialidadesProf = ManejadorNegocio.ObtenerEspecialidadesPorProfesional(Convert.ToInt32(tabla.Rows[0]["prof_id"].ToString()));
                foreach (string especialidad in especialidadesProf)
                {
                    cListEspecialidades.SetItemChecked(cListEspecialidades.Items.IndexOf(especialidad),true);
                }
            }                
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ( verificarDatos() )
            {
                ManejadorNegocio.ModificarProfesional(id_amodificar, tBoxNombre.Text, tBoxApellido.Text,
                                                    Convert.ToInt32(tBoxNumeroDoc.Text), cBoxSexo.Text, dtpFechaNac.Value,
                                                    tBoxDireccion.Text, Convert.ToInt32(tBoxTelefono.Text), tBoxMatricula.Text,
                                                    tBoxMail.Text, cBoxTipoDoc.Text, cListEspecialidades);

                MessageBox.Show("Profesional modificado satisfactoriamente");
                this.Close();
            }
        }

        private bool verificarDatos()
        {
            bool valido = true;
            string error = "Verifique los siguientes errores:\n";
            if (tBoxNombre.Text == string.Empty)
            {
                error = error + "  - Falta el nombre.\n";
                lblNombre.ForeColor = Color.Red;
                valido = false;
            }
            else
                lblNombre.ForeColor = Color.Black;

            if (tBoxApellido.Text == string.Empty)
            {
                error = error + "  - Falta el apellido.\n";
                lblApellido.ForeColor = Color.Red;
                valido = false;
            }
            else
                lblApellido.ForeColor = Color.Black;

            if (tBoxNumeroDoc.Text == string.Empty)
            {
                error = error + "  - Falta el numero de documento.\n";
                lblDocumento.ForeColor = Color.Red;
                valido = false;
            }
            else
                lblDocumento.ForeColor = Color.Black;

            if (tBoxDireccion.Text == string.Empty)
            {
                error = error + "  - Falta la direccion.\n";
                lblDireccion.ForeColor = Color.Red;
                valido = false;
            }
            else
                lblDireccion.ForeColor = Color.Black;

            if (tBoxTelefono.Text == string.Empty)
            {
                error = error + "  - Falta el telefono.\n";
                lblTelefono.ForeColor = Color.Red;
                valido = false;
            }
            else
                lblTelefono.ForeColor = Color.Black;

            if (tBoxMatricula.Text == string.Empty)
            {
                error = error + "  - Falta la matricula.\n";
                lblMatricula.ForeColor = Color.Red;
                valido = false;
            }
            else
                lblMatricula.ForeColor = Color.Black;

            if (cListEspecialidades.CheckedIndices.Count < 1)
            {
                error = error + "  - Debe elegir al menos una especialidad .\n";
                lblEspecialidades.ForeColor = Color.Red;
                valido = false;
            }

            if (tBoxMail.Text == string.Empty)
            {
                error = error + "  - Falta el mail.\n";
                lblMail.ForeColor = Color.Red;
                valido = false;
            }
            if (valido)
                return valido;
            else
            {
                MessageBox.Show(error);
                return valido;
            }
        }

        private void tBoxNumeroDoc_KeyPress(object sender, KeyPressEventArgs e)
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
