using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;

namespace PagoElectronico.Transferencias
{
    public partial class Transferencias : Form
    {
        private decimal cuentaSeleccionada;
        private decimal saldo;
        private decimal moneda;

        public Transferencias()
        {
            InitializeComponent();

            string queryCuentasActivasDelUsuario = "SELECT cu.Id_cuenta,cl.Id_cliente FROM HHHH.Cuentas cu, HHHH.clientes cl,HHHH.usuarios	u WHERE cu.Id_cliente = cl.Id_cliente AND u.Id_usuario = cl.Id_usuario AND cu.Estado = 'H' AND u.Id_usuario = " + Sesion.user_id;
            DataTable cuentasActivasDelUsuario = ConexionDB.correrQuery(Sesion.conexion, queryCuentasActivasDelUsuario);
            cbOrigen.DisplayMember = "Id_cuenta";
            cbOrigen.ValueMember = "Id_cuenta";
            cbOrigen.DataSource = cuentasActivasDelUsuario;
            cbOrigen.Update();

            string queryCuentasActivas = "SELECT cu.Id_cuenta FROM HHHH.Cuentas cu WHERE cu.Estado = 'H'";
            DataTable cuentasActivas = ConexionDB.correrQuery(Sesion.conexion, queryCuentasActivas);
            cbDestino.DisplayMember = "Id_cuenta";
            cbDestino.ValueMember = "Id_cuenta";
            cbDestino.DataSource = cuentasActivas;
            cbDestino.Update();

            string monedas = "SELECT id_moneda,descripcion FROM HHHH.monedas";
            DataTable dtmonedas = ConexionDB.correrQuery(Sesion.conexion, monedas);
            cbImporteMoneda.DisplayMember = "descripcion";
            cbImporteMoneda.ValueMember = "id_moneda";
            cbImporteMoneda.DataSource = dtmonedas;
            cbImporteMoneda.Update();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void cbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cuentaSeleccionada = Convert.ToDecimal(cbOrigen.Text);

            string querySaldo = "SELECT Saldo,Descripcion,c.id_moneda FROM HHHH.Cuentas c,HHHH.Monedas m WHERE c.id_Moneda = m. id_moneda AND Id_cuenta = " + cuentaSeleccionada;
            DataTable dtsaldo = ConexionDB.correrQuery(Sesion.conexion, querySaldo);

            saldo = Convert.ToDecimal(dtsaldo.Rows[0]["Saldo"]);
            moneda = Convert.ToDecimal(dtsaldo.Rows[0]["id_moneda"]);

            txtSaldo.Text = saldo + " " + Convert.ToString(dtsaldo.Rows[0]["Descripcion"]);
        }

        private void btTransferir_Click(object sender, EventArgs e)
        {

        }
    }
}
