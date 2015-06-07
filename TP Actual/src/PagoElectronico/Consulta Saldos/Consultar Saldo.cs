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

                if(ConexionDB.Procedure("ObtenerUsuariosClientes",null, out usuarios))
                {
                    comboBox1.DataSource = usuarios;
                    comboBox1.ValueMember = "Id_cliente";
                    comboBox1.DisplayMember = "Usuario";
                    comboBox1.Text = "Elija un usuario";
                    comboBox1.SelectedIndex = -1;
                    comboBox2.Enabled = false;
                }
            }
            else
            {
                label6.Visible = true;
                label6.Text = Sesion.usuario;
                comboBox1.Visible = false;
                actualizarCuentas();
                comboBox2.Text = "Elija una cuenta";
                comboBox2.SelectedIndex = -1;
            }
        }

        private void actualizarCuentas()
        {
            DataTable cuentas;
            decimal cliente;
            
            
            if (Sesion.rol_id == 1)
            {
                try
                {
                   cliente = Convert.ToInt32(comboBox1.SelectedValue);
                }
                catch (InvalidCastException) { cliente = -1; }
            }
            else{ cliente = Sesion.cliente_id; }
            {
                SQLParametros parametros = new SQLParametros();
                parametros.add("@Id_cliente",cliente);

                if(ConexionDB.Procedure("ObtenerCuentasDeCliente",parametros.get(), out cuentas))
                {
                    comboBox2.DataSource = cuentas;
                    comboBox2.ValueMember = "Id_cuenta";
                    comboBox2.DisplayMember = "Id_cuenta";
                    label8.Text = "";
                }
            }

        }

        private void actualizarDepositos()
        {
            SQLParametros parametros = new SQLParametros();
            parametros.add("@Id_cuenta", comboBox2.SelectedValue);

            DataTable depositos;

            if(ConexionDB.Procedure("Ultimos5Depositos",parametros.get(), out depositos))
                dataGridView1.DataSource = depositos;
            else 
                dataGridView1.DataSource = null; 
        }

        private void actualizarRetiros()
        {
            SQLParametros parametros = new SQLParametros();
            parametros.add("@Id_cuenta", comboBox2.SelectedValue);

            DataTable retiros;

            if (ConexionDB.Procedure("Ultimos5Retiros", parametros.get(), out retiros))
                dataGridView2.DataSource = retiros;
            else
                dataGridView2.DataSource = null;
        }

        private void actualizarTransferencias()
        {
            SQLParametros parametros = new SQLParametros();
            parametros.add("@Id_cuenta", comboBox2.SelectedValue);

            DataTable transferencias;

            if (ConexionDB.Procedure("Ultimas5Transferencias", parametros.get(), out transferencias))
                dataGridView3.DataSource = transferencias;
            else
                dataGridView3.DataSource = null;
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
            comboBox2.SelectedText = "Elija una cuenta";
            comboBox2.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
