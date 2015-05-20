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

    }
}
