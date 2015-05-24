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
              //  comboBox1.SelectedValue = 1;
            }
            else
            {
                label6.Visible = true;
                label6.Text = Sesion.usuario;
                comboBox1.Visible = false;
                actualizarCuentas();
            }
        }
        private void actualizarCuentas()
        {
            DataTable cuentas;
            if (Sesion.rol_id == 1)
            {
                try
                {
                    int user = Convert.ToInt32(comboBox1.SelectedValue);
                    cuentas = ConexionDB.correrQuery(Sesion.conexion, "select cue.* from HHHH.cuentas cue, HHHH.clientes cli where cli.Id_cliente = cue.Id_cliente and cli.Id_usuario = " + user);
                    comboBox2.DataSource = cuentas;
                    comboBox2.ValueMember = "Id_cuenta";
                    comboBox2.DisplayMember = "Id_cuenta";
                }
                catch(InvalidCastException) { }
            }
            else
            {
                cuentas = ConexionDB.correrQuery(Sesion.conexion, "select cue.* from HHHH.cuentas cue, HHHH.clientes cli where cli.Id_cliente = cue.Id_cliente and cli.Id_usuario = " + Sesion.user_id);
                comboBox2.DataSource = cuentas;
                comboBox2.ValueMember = "Id_cuenta";
                comboBox2.DisplayMember = "Id_cuenta";
            }
        }

        private void actualizarDepositos()
        {
            try
           {
                DataTable depositos;
                depositos = ConexionDB.correrQuery(Sesion.conexion, "select TOP 5 Id_deposito, Fecha_deposito, HHHH.impconmoneda(Importe,Id_tipo_moneda) AS Importe, Id_tarjeta "+
                                                                    "from HHHH.depositos where Id_cuenta = " +comboBox2.SelectedValue.ToString()+
                                                                    " order by Fecha_deposito DESC");
                dataGridView1.DataSource = depositos;
            }
            catch (SqlException) { }
        }

        private void actualizarRetiros()
        {
            try
            {
                DataTable retiros;
                retiros = ConexionDB.correrQuery(Sesion.conexion, "select TOP 5 Id_retiro, Fecha_retiro, HHHH.impconmoneda(Importe,Id_moneda) AS Importe, Id_cheque "+
                                                                     "from HHHH.retiros where Id_cuenta = "+comboBox2.SelectedValue.ToString()+
                                                                     " order by Fecha_retiro DESC");
                dataGridView2.DataSource = retiros;
            }
            catch (SqlException) { }
        }

        private void actualizarTransferencias()
        {
            try
            {
                DataTable transferencias;
                transferencias = ConexionDB.correrQuery(Sesion.conexion, "select TOP 10 Id_transferencia, Fecha_transferencia, HHHH.impconmoneda(Importe,Id_moneda) AS Importe, Cuenta_destino "+
                                                                            "from HHHH.transferencias where Cuenta_origen = "+comboBox2.SelectedValue.ToString()+
                                                                            " order by Fecha_transferencia DESC");
                dataGridView3.DataSource = transferencias;
            }
            catch (SqlException) { }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarCuentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarDepositos();
            actualizarRetiros();
            actualizarTransferencias();
        }



    }
}
