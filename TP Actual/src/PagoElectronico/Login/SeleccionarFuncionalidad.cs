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
            Form nuevoForm = null;
            switch (cbFuncionalidad.Text)
            {
                case "ABM Rol":
                    nuevoForm = new ABM_Rol.AdministrarRoles();
                    break;
                case "ABM Usuario":
                    nuevoForm = new ABM_Usuario.Form1();
                    break;
                case "ABM Cliente":
                    nuevoForm = new ABM_Cliente.Form1();
                    break;
                case "ABM Cuenta":
                    nuevoForm = new ABM_Cuenta.Form1();
                    break;
                case "Asociar/Desasociar Tarjeta de Credito":
                    nuevoForm = new ABM_Tarjeta.mtar();
                    break;
                case "Depositos":
                    nuevoForm = new Depositos.Form1();
                    break;
                case "Retiro de Efectivo":
                    nuevoForm = new Retiros.Form1();
                    break;
                case "Transferencia entre Cuentas":
                    nuevoForm = new Transferencias.Transferencias();
                    break;
                case "Facturacion de Costos":
                    nuevoForm = new Facturacion.Facturacion();
                    break;
                case "Consulta de Saldo de Cuentas":
                    nuevoForm = new Consulta_Saldos.Form1();
                    break;
                case "Listado Estadistico":
                    nuevoForm = new Listados.Form1();
                    break;
            }

            nuevoForm.Show(this);
            this.Hide();

        }
    }
}