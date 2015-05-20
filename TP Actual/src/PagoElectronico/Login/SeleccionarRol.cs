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
        bool cerrar = false;
        public SeleccionarRol()
        {
            InitializeComponent();
            
            string queryRoles = "SELECT r.Id_rol,Nombre_rol FROM HHHH.rel_rol_usuario r,HHHH.roles ro WHERE r.Id_rol=ro.Id_rol AND r.Id_usuario = " + Sesion.user_id;
            DataTable rolesDeUsuario = ConexionDB.correrQuery(Sesion.conexion, queryRoles);

            cbRoles.DisplayMember = "Nombre_rol";
            cbRoles.ValueMember = "Id_rol";
            cbRoles.DataSource = rolesDeUsuario;
            cbRoles.Update();

            if (rolesDeUsuario.Rows.Count == 1) //si solo tiene un rol, entra directo
            {
                cerrar = true;
                btSeleccionar_Click(null,null);
               
            }
        }


        protected override void OnVisibleChanged(EventArgs e) // para poder hacer hide() antes de load()
        {
            base.OnVisibleChanged(e);
            if (cerrar) { this.Visible = false; }
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

            ((DataTable)(cbRoles.DataSource)).Dispose();
        }
    }
}
