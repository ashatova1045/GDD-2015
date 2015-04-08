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

namespace ClinicaFRBA
{
    public partial class SelectorRol : Form
    {
        private string usuarioParaSeleccion;

        public SelectorRol(string pUsuarioParaSeleccion)
        {
            InitializeComponent();
            this.usuarioParaSeleccion = pUsuarioParaSeleccion;
        }

        private void SelectorRol_Load(object sender, EventArgs e)
        {
            DataTable rolesDeUsuario = ManejadorNegocio.obtenerRolesDeUsuario(this.usuarioParaSeleccion);
            cmbRolesUsuario.DisplayMember = "rol_nombre";
            cmbRolesUsuario.ValueMember = "rol_id";
            cmbRolesUsuario.DataSource = rolesDeUsuario;
            cmbRolesUsuario.Update();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataRowView filaSelecionada = (DataRowView)cmbRolesUsuario.SelectedItem;
            if (filaSelecionada["rol_nombre"].ToString() != String.Empty)
            {
                Inicial frmInicial = new Inicial(this.usuarioParaSeleccion, cmbRolesUsuario.SelectedValue.ToString());
                frmInicial.Show(this);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar al menos un rol para poder continuar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ManejadorBD.DesconectarBD();
            Application.Exit();
        }

        private void cmbRolesUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }
    }
}
