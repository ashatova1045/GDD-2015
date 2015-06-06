using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data.SqlClient;

namespace PagoElectronico.Login
{
    public partial class SeleccionarRol : Form
    {
        public SeleccionarRol()
        {
            InitializeComponent();

            SQLParametros parametros = new SQLParametros();
            parametros.add("@Id_usuario",Sesion.user_id);

            DataTable rolesDeUsuario;

            if (ConexionDB.Procedure("ObtenerRoles", parametros.get(), out rolesDeUsuario))
            {
                cbRoles.DisplayMember = "Nombre_rol";
                cbRoles.ValueMember = "Id_rol";
                cbRoles.DataSource = rolesDeUsuario;
                cbRoles.Update();

                Shown += SeleccionarRol_Shown;
            }
        }

        private void SeleccionarRol_Shown(Object sender, EventArgs e)
        {
            if (cbRoles.Items.Count == 1) //si solo tiene un rol, entra directo
            {
                this.Hide();
                btSeleccionar_Click(null, null);
            }
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            ((DataTable)(cbRoles.DataSource)).Dispose();

            Owner.Show();
            this.Close();
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            Sesion.rol_nombre = cbRoles.SelectedText;
            Sesion.rol_id = Convert.ToInt32(cbRoles.SelectedValue);

            new SeleccionarFuncionalidad().Show(this);
            this.Hide();
        }
    }
}
