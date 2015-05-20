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

            cbRoles.Items.Clear();
            cbRoles.DisplayMember = "Hotel_Nombre";
            cbRoles.ValueMember = "Id_rol";

            string queryRoles = "SELECT Id_rol FROM HHHH.rel_rol_usuario r,HHHH.usuarios u WHERE r.Id_usuario=u.Id_usuario AND r.Id_usuario = " + Sesion.user_id;
            DataTable rolesDeUsuario = ConexionDB.correrQuery(Sesion.conexion, queryRoles);

            cbRoles.DataSource = rolesDeUsuario;
            rolesDeUsuario.Dispose();

            cbRoles.Update();
        }
    }
}
