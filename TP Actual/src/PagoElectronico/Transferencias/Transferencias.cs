using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;

namespace PagoElectronico.Transferencias
{
    public partial class Transferencias : Form
    {
        private DataTable cuentasActivas;

        public Transferencias()
        {
            InitializeComponent();

            string queryCuentasActivas = "SELECT cu.Id_cuenta,cu.Saldo,cu.Id_moneda,m.descripcion,u.id_usuario FROM HHHH.Cuentas cu, HHHH.clientes cl,HHHH.usuarios u ,HHHH.Monedas m WHERE cu.Id_cliente = cl.Id_cliente AND u.Id_usuario = cl.Id_usuario AND cu.Estado = 'H' AND cu.Id_moneda = m.Id_moneda"; //traigo todos los datos de todas las cuentas habilitadas
            cuentasActivas = ConexionDB.correrQuery(Sesion.conexion, queryCuentasActivas);

            cbDestino.DisplayMember = "Id_cuenta";
            cbDestino.ValueMember = "Id_cuenta";
            cbDestino.DataSource = cuentasActivas;
            cbDestino.Update();

            cbOrigen.DisplayMember = "Id_cuenta";
            cbOrigen.ValueMember = "Id_cuenta";
            cbOrigen.DataSource = cuentasActivas.Select("id_usuario = " + Sesion.user_id).CopyToDataTable();
            cbOrigen.Update();

            DataTable monedas = ConexionDB.correrQuery(Sesion.conexion, "SELECT id_moneda,descripcion FROM HHHH.monedas"); //traigo todas las monedas, no solo las que tiene seteada alguna cuenta
            cbImporteMoneda.DisplayMember = "descripcion";
            cbImporteMoneda.ValueMember = "id_moneda";
            cbImporteMoneda.DataSource = monedas;
            cbImporteMoneda.Update();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void cbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable saldoSeleccionado = cuentasActivas.Select("id_cuenta = " + cbOrigen.Text).CopyToDataTable();
            txtSaldo.Text = saldoSeleccionado.Rows[0]["saldo"] + " " + saldoSeleccionado.Rows[0]["descripcion"];
        }

        private void btTransferir_Click(object sender, EventArgs e)
        {

        }
    }
}
