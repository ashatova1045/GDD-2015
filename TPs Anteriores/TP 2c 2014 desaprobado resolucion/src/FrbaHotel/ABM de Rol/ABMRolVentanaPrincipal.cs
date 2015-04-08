using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;
using FrbaHotel.ABM_de_Rol;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ABMRolVentanaPrincipal : Form
    {
        public ABMRolVentanaPrincipal()
        {
            InitializeComponent();
        }

        private void CrearRolButton_Click(object sender, EventArgs e)
        {
            CrearRol nuevoRol = new CrearRol();
            nuevoRol.Show(this);
            this.Hide();
        }

        private void VolverButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void BuscarRolesButton_Click(object sender, EventArgs e)
        {
            dgvRoles.Rows.Clear();
            dgvRoles.Update();
            DataTable roles = GestorDeSistema.buscarRoles(RolCodTextBox.Text,nombreRolTextBox.Text);

            foreach (DataRow rol in roles.Rows)
            {
                dgvRoles.Rows.Add(rol.ItemArray[0], rol.ItemArray[1], rol.ItemArray[2], "Modificar", "Borrar");
            }
            dgvRoles.Update();
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod_rol = Convert.ToInt32(dgvRoles.Rows[e.RowIndex].Cells["Rol_Cod"].Value);
            string nombre_rol = dgvRoles.Rows[e.RowIndex].Cells["Rol_Nombre"].Value.ToString();
            bool habilitado = Convert.ToBoolean(dgvRoles.Rows[e.RowIndex].Cells["Rol_Habilitado"].Value);

            switch (e.ColumnIndex)
            {
                case 4:
                    if (!habilitado)
                        {MessageBox.Show("El Rol seleccionado ya se encontraba inhabilitado", "Baja lógica de Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);return;}

                    GestorDeSistema.habdeshabrol(cod_rol,0);
                    MessageBox.Show("Se ha dado de baja el Rol seleccionado", "Baja lógica de Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BuscarRolesButton.PerformClick();                       

                    break;

                case 3:
                    {
                        ModificarRol formularioModificacion = new ModificarRol(cod_rol, nombre_rol,habilitado);
                        formularioModificacion.ShowDialog(this);
                        BuscarRolesButton.PerformClick();

                    }
                    break;
            }
        }

        private void LimpiarBusquedaButton_Click(object sender, EventArgs e)
        {
            RolCodTextBox.Text = String.Empty;
            nombreRolTextBox.Text = String.Empty;
            dgvRoles.Rows.Clear();
            dgvRoles.Update();
        }

    }
}
