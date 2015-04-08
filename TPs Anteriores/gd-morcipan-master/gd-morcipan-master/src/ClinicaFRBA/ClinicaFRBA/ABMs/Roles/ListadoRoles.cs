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
    public partial class ListadoRoles : Form
    {
        public ListadoRoles()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNom.Text = String.Empty;
            dgRoles.Rows.Clear();
            dgRoles.Update();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgRoles.Rows.Clear();
            dgRoles.Update();
            DataTable rolesEncontrados = ManejadorNegocio.buscarRolesPorNombre(((txtNom.Text.Length > 0) ? txtNom.Text : "- 2"));
            foreach (DataRow rolEncontrado in rolesEncontrados.Rows)
            {
                dgRoles.Rows.Add(rolEncontrado.ItemArray[0], rolEncontrado.ItemArray[1], "Modificar", "Borrar");
            }
            dgRoles.Update();
        }

        private void dgRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string rol_id = dgRoles.Rows[e.RowIndex].Cells["rolId"].Value.ToString();
            string rol_nombre = dgRoles.Rows[e.RowIndex].Cells["rolNombre"].Value.ToString();
            if (e.ColumnIndex == 3)
            {
                if (ManejadorNegocio.eliminarRol(Convert.ToInt32(rol_id)) > 0)
                {
                    MessageBox.Show("Rol eliminado correctamente!", "Eliminación de Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBuscar.PerformClick();
                }
            }
            else if (e.ColumnIndex == 2)
            {
                ModificacionRoles frmModificacion = new ModificacionRoles(Convert.ToInt32(rol_id), rol_nombre);
                frmModificacion.ShowDialog(this);
                btnBuscar.PerformClick();
            }
        }
    }
}
