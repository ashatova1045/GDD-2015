using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.ABMs.Roles
{
    public partial class AltaRoles : Form
    {
        public AltaRoles()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaRoles_Load(object sender, EventArgs e)
        {
            foreach (DataRow funcionalidad in ManejadorNegocio.obtenerFuncionalidades().Rows) {
                int indice = Convert.ToInt32(funcionalidad.ItemArray[0]) - 1;
                string nombreFuncionalidad = funcionalidad.ItemArray[1].ToString();
                chkListFunc.Items.Insert(indice, nombreFuncionalidad);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int nuevo_rol_id = 0;
            if (txtNombre.Text != String.Empty)
            {
                nuevo_rol_id = ManejadorNegocio.insertarOActivarRol(txtNombre.Text);
            }

            if (nuevo_rol_id != 0)
            {
                if (chkListFunc.SelectedIndices.Count > 0)
                {
                    List<int> funcionesSeleccionadas = new List<int>();
                    foreach (object funcSeleccionada in chkListFunc.CheckedIndices)
                    {
                        funcionesSeleccionadas.Add(Convert.ToInt32(funcSeleccionada) + 1);
                    }
                    if (ManejadorNegocio.actualizarFuncionalidadesRol(nuevo_rol_id, funcionesSeleccionadas) > 0)
                    {
                        MessageBox.Show("Rol agregado correctamente!", "Alta de Rol!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar al menos una funcionalidad para el rol en cuestión.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
