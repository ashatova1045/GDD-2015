using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA
{
    public partial class LoginSeleccion : Form
    {
        private int usuarioId;
        //private int rolId;

        public LoginSeleccion(int pUsuarioId)
        {
            InitializeComponent();
            this.usuarioId = pUsuarioId;
            //this.rolId = 0;
            cargarRolesDeUsuario(pUsuarioId);
        }

        private void cargarRolesDeUsuario(int usuarioId)
        {
            if (usuarioId != 0)
            {
                DataTable rolesDeUsuario = ManejadorNegocio.obtenerRolesParaUsuario(usuarioId);
                cmbRolAUtilizar.DisplayMember = "rol_nombre";
                cmbRolAUtilizar.ValueMember = "rol_id";
                cmbRolAUtilizar.DataSource = rolesDeUsuario;
            }
            else
            {
                cmbRolAUtilizar.Items.Clear();
            }
            cmbRolAUtilizar.Update();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbRolAUtilizar.SelectedValue.ToString().Length > 0)
            {
                int rolId = Convert.ToInt32(cmbRolAUtilizar.SelectedValue.ToString());
                Inicial frmInicial = new Inicial(this.usuarioId, rolId);
                frmInicial.Show(this);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol para ingresar al sistema!", "Error en Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRolAUtilizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSeleccionar.PerformClick();
            }
        }


    }
}
