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
    public partial class AltaProfesionales : Form
    {
        public AltaProfesionales()
        {
            InitializeComponent();

            dtpFechaNac.Value = ManejadorFechaHora.obtenerFechaDelSistema();

            List<string> especialidades = ManejadorNegocio.cargarEspecialidades();
            foreach( string especialidad in especialidades )
            {
                cListEspecialidades.Items.Add(especialidad);
            }
            List<String> sexos = ManejadorNegocio.cargarSexos();
            List<String> tipoDocs = ManejadorNegocio.cargarTipoDocs();

            cBoxSexo.DataSource = sexos;
            cBoxTipoDoc.DataSource = tipoDocs;
        }
        private void limpiarCampos()
        {
            tBoxApellido.Clear();
            tBoxDireccion.Clear();
            tBoxMatricula.Clear();
            tBoxNombre.Clear();
            tBoxNumeroDoc.Clear();
            tBoxTelefono.Clear();
            dtpFechaNac.Value = ManejadorFechaHora.obtenerFechaDelSistema();
            foreach (int indice in cListEspecialidades.CheckedIndices)
            {
                cListEspecialidades.SetItemCheckState(indice, CheckState.Unchecked);
            }
            lblApellido.ForeColor = Color.Black;
            lblDireccion.ForeColor = Color.Black;
            lblMatricula.ForeColor = Color.Black;
            lblNombre.ForeColor = Color.Black;
            lblDocumento.ForeColor = Color.Black;
            lblTelefono.ForeColor = Color.Black;
            lblEspecialidades.ForeColor = Color.Black;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            /* SALIR */
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificarDatos())
            {
                int resultado = ManejadorNegocio.AltaProfesional(tBoxNombre.Text, tBoxApellido.Text,cBoxTipoDoc.Text,
                                                tBoxNumeroDoc.Text, cBoxSexo.Text,
                                                dtpFechaNac.Value, tBoxDireccion.Text,
                                                tBoxTelefono.Text, tBoxMatricula.Text,tBoxMail.Text,
                                                cListEspecialidades);
                if (resultado != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Profesional agregado satisfactoriamente.\nDesea agregar un nuevo profesional?", "Nuevo profesional", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        limpiarCampos();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo dar de alta porque ya existe un profesional con ese TIPO y NRO DOCUMENTO\n");
                }
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

            if(valido)
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