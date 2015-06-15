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
        private bool salir = true;

        public SeleccionarFuncionalidad()
        {
            InitializeComponent();

            SQLParametros parametros = new SQLParametros();
            parametros.add("@id_rol", Sesion.rol_id);
            DataTable funcionalidadDeRol;

            if (ConexionDB.Procedure("ObtenerFuncionalidadesDeRol", parametros.get(), out funcionalidadDeRol))
            {
                dataGridView1.DataSource = funcionalidadDeRol;
                dataGridView1.Columns[0].Visible = false;
            }

            int tam = (funcionalidadDeRol.Rows.Count * 30) + 3;

            if (tam > 393)
            {
                dataGridView1.Height = 393;
                this.Height = 393 + 150;
                btVolver.Top = 393 + 80;
            }
            else
            {
                dataGridView1.Height = tam;
                this.Height = tam + 150;
                btVolver.Top = 80 + tam;
            }
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            ((DataTable)(dataGridView1.DataSource)).Dispose();

            salir = false;
            Owner.Show();
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Form nuevoForm = null;
           
            switch (dataGridView1.SelectedRows[0].Cells[1].Value.ToString())
            {
                case "ABM Rol":
                    nuevoForm = new ABM_Rol.AdministrarRoles();
                    break;
                case "ABM Usuario":
                    nuevoForm = new ABM_Usuario.Form1();
                    break;
                case "ABM Cliente":
                    nuevoForm = new ABM_Cliente.Nuevo_Cliente();
                    break;
                case "ABM Cuenta":
                    nuevoForm = new ABM_Cuenta.AdministrarCuentas();
                    break;
                case "Asociar/Desasociar Tarjeta de Credito":
                    nuevoForm = new ABM_Tarjeta.mtar();
                    break;
                case "Depositos":
                    nuevoForm = new Depositos.RealizarDeposito();
                    break;
                case "Retiro de Efectivo":
                    nuevoForm = new Retiros.RetiroEfectivo_FRM();
                    break;
                case "Transferencia entre Cuentas":
                    nuevoForm = new Transferencias.Transferencias();
                    break;
                case "Facturacion de Costos":
                    nuevoForm = new Facturacion.Facturacion();
                    break;
                case "Consulta de Saldo de Cuentas":
                    nuevoForm = new Consulta_Saldos.Consultar_Saldo();
                    break;
                case "Listado Estadistico":
                    nuevoForm = new Listados.ListadosEstadisticos();
                    break;
            }

            nuevoForm.Show(this);
            this.Hide();

        }

        private void SeleccionarFuncionalidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }
    }
}