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
    public partial class ModificacionRoles : Form
    {
        private int rol_id;
        private string rol_nombre;

        public ModificacionRoles(int rolIdAModificar, string rolNombreAModificar)
        {
            InitializeComponent();
            this.rol_id = rolIdAModificar;
            this.rol_nombre = rolNombreAModificar;
        }

        private void ModificacionRoles_Load(object sender, EventArgs e)
        {
            txtNombre.Text = this.rol_nombre;
            foreach (DataRow funcionalidad in ManejadorNegocio.obtenerFuncionalidades().Rows)
            {
                int indice = Convert.ToInt32(funcionalidad.ItemArray[0]) - 1;
                string nombreFuncionalidad = funcionalidad.ItemArray[1].ToString();
                chkListFunc.Items.Insert(indice, nombreFuncionalidad);
            }
            DataTable funcionalidadesDeRol = ManejadorNegocio.obtenerFuncionalidadesPorRol(this.rol_id);
            foreach (DataRow funcionalidadRol in funcionalidadesDeRol.Rows)
            {
                int indiceASeleccionar = Convert.ToInt32(funcionalidadRol.ItemArray[0]) - 1;
                chkListFunc.SetItemChecked(indiceASeleccionar, true);
            }
            chkListFunc.Update();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool cambioEnNombre()
        {
            return ((txtNombre.Text != String.Empty) && (txtNombre.Text != this.rol_nombre));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.cambioEnNombre())
            {
                ManejadorNegocio.actualizarNombreRol(this.rol_id, txtNombre.Text);
            }
            if (chkListFunc.CheckedIndices.Count > 0)
            {
                List<int> funcionesSeleccionadas = new List<int>();
                foreach (object funcSeleccionada in chkListFunc.CheckedIndices)
                {
                    funcionesSeleccionadas.Add(Convert.ToInt32(funcSeleccionada) + 1);
                }
                if (ManejadorNegocio.actualizarFuncionalidadesRol(this.rol_id, funcionesSeleccionadas) > 0)
                {
                    MessageBox.Show("Rol modificado correctamente!", "Modificación de Rol!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error intentando actualizar el rol. Por favor, vuelva a intentarlo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede haber roles sin funcionalidades, si desea darlo de baja, salga y oprima el botón Borrar del listado anterior.", "Error en datos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
