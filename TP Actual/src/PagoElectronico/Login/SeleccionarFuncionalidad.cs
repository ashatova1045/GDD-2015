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
    public partial class SeleccionarFuncionalidad : Form
    {
        public SeleccionarFuncionalidad()
        {
            InitializeComponent();

            string queryFuncionalidad = "SELECT r.Id_funcionalidad,f.Descripcion FROM HHHH.rel_rol_funcionalidad r,HHHH.funcionalidades f WHERE r.Id_funcionalidad=f.Id_funcionalidad AND r.Id_rol = " + Sesion.rol_id;
            DataTable funcionalidadDeRol = ConexionDB.correrQuery(Sesion.conexion, queryFuncionalidad);

            cbFuncionalidad.DisplayMember = "Descripcion";
            cbFuncionalidad.ValueMember = "Id_funcionalidad";
            cbFuncionalidad.DataSource = funcionalidadDeRol;
            cbFuncionalidad.Update();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            ((DataTable)(cbFuncionalidad.DataSource)).Dispose();

            Owner.Show();
            this.Close();
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            switch (cbFuncionalidad.Text)
            {
                case "ABM Rol":
                    ABM_Rol.AdministrarRoles AdmRol = new ABM_Rol.AdministrarRoles();
                    AdmRol.Show(this);
                    this.Hide();
                    break;
            }

        }
    }
}