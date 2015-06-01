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

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Consultar_Saldo : Form
    {
        public Consultar_Saldo()
        {
            InitializeComponent();
        }

        private void Consultar_Saldo_Load(object sender, EventArgs e)
        {
            if (Sesion.rol_id == 1)
            {
                label6.Visible = false;
                comboBox1.Visible = true;
                DataTable usuarios;
                usuarios = ConexionDB.correrQuery(Sesion.conexion, "select Id_usuario,Usuario from HHHH.usuarios where Id_usuario <> 1");
                comboBox1.DataSource = usuarios;
                comboBox1.ValueMember = "Id_usuario";
                comboBox1.DisplayMember = "Usuario";
                comboBox1.Text = "Elija un usuario";
                comboBox1.TabIndex = 0;
                comboBox2.Enabled = false;
            }
            else
            {
                label6.Visible = true;
                label6.Text = Sesion.usuario;
                comboBox1.Visible = false;
                actualizarCuentas();
                comboBox2.Text = "Elija una cuenta";
                comboBox2.TabIndex = 0;
            }
        }

        private void actualizarCuentas()
        {
            DataTable cuentas;
            decimal user;
            
            
            if (Sesion.rol_id == 1)
            {
                try
                {
                   user = Convert.ToInt32(comboBox1.SelectedValue);
                }
                catch (InvalidCastException) { user = -1; }
            }
            else{ user = Sesion.user_id; }
            {

                cuentas = ConexionDB.correrQuery(Sesion.conexion, "select cue.* from HHHH.cuentas cue, HHHH.clientes cli where cli.Id_cliente = cue.Id_cliente and cli.Id_usuario = " + user);
                comboBox2.DataSource = cuentas;
                comboBox2.ValueMember = "Id_cuenta";
                comboBox2.DisplayMember = "Id_cuenta";
                label8.Text = "";
            }

        }

        private void actualizarDepositos()
        {
            try
            {
                DataTable depositos;
                depositos = ConexionDB.correrQuery(Sesion.conexion, "select TOP 5 Fecha_deposito, HHHH.impconmoneda(Importe,Id_tipo_moneda) AS Importe, 'XXXX-XXXX-XXXX-'+tar.finalnumero as Tarjeta " +
                                                                    "from HHHH.depositos dep, HHHH.tarjetas tar where Id_cuenta = " + comboBox2.SelectedValue + " and dep.Id_tarjeta = tar.Id_tarjeta"+
                                                                    " order by Fecha_deposito DESC");
                dataGridView1.DataSource = depositos;
            }
            catch (SqlException) { dataGridView1.DataSource = null; }
        }

        private void actualizarRetiros()
        {
            try
            {
                DataTable retiros;
                retiros = ConexionDB.correrQuery(Sesion.conexion, "select TOP 5 Fecha_retiro, HHHH.impconmoneda(Importe,Id_moneda) AS Importe, ban.Descripcion " +
                                                                     "from HHHH.retiros, HHHH.bancos ban where Id_cuenta = " + comboBox2.SelectedValue + " and Id_banco = ban.Id_banco" +
                                                                     " order by Fecha_retiro DESC");
                dataGridView2.DataSource = retiros;
            }
            catch (SqlException) { dataGridView2.DataSource = null; }
        }

        private void actualizarTransferencias()
        {
            try
            {
                DataTable transferencias;
                transferencias = ConexionDB.correrQuery(Sesion.conexion, "select TOP 10 Fecha_transferencia, HHHH.impconmoneda(Importe,Id_moneda) AS Importe, Cuenta_destino "+
                                                                            "from HHHH.transferencias where Cuenta_origen = " + comboBox2.SelectedValue +
                                                                            " order by Fecha_transferencia DESC");
                dataGridView3.DataSource = transferencias;
            }
            catch (SqlException) { dataGridView3.DataSource = null; }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            actualizarDepositos();
            actualizarRetiros();
            actualizarTransferencias();

            DataRow[] rowSaldo = ((DataTable)comboBox2.DataSource).Select("Id_cuenta = "+comboBox2.SelectedValue );
            try { label8.Text = rowSaldo[0][7].ToString(); }
            catch (IndexOutOfRangeException) { label8.Text = "Error"; }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            actualizarCuentas();
            comboBox2.Enabled = true;
            comboBox2.Text = "Elija una cuenta";
            comboBox2.TabIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
