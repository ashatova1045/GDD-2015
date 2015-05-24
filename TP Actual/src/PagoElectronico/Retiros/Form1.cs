using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PagoElectronico.OperacionesDB.ConexionDB;

namespace PagoElectronico.Retiros
{
    public partial class RetiroEfectivo_FRM : Form
    {
        readonly DataTable monedas = ConexionDB.correrQuery(Sesion.conexion, "SELECT DISTINCT id_moneda,descripcion FROM HHHH.monedas"); //traigo todas las monedas, no solo las que tiene seteada alguna cuenta
        readonly DataTable cuentas = ConexionDB.correrQuery(Sesion.conexion, "SELECT DISTINCT id_cuenta FROM HHHH.cuentas WHERE Id_cliente =" + Sesion.cliente_id);


        public RetiroEfectivo_FRM()
        {
            InitializeComponent();

            //Se carga el CB "Monedas"

            Moneda_CB.DisplayMember = "descripcion";
            Moneda_CB.ValueMember = "id_moneda";


            //Se carga el CB "Cuentas"

            Cuenta_CB.DisplayMember = "Id_cuenta";
            Cuenta_CB.ValueMember = "id_cuenta";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        
        private void Importe_NUD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RealizarCheque_BTN_Click(object sender, EventArgs e)
        {
           
        }

        private void NoDoc_TXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void Moneda_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Moneda_CB_Click(object sender, EventArgs e)
        {
            Moneda_CB.DataSource = monedas;
            Moneda_CB.Update();
        }

        private void Cuenta_CB_Click(object sender, EventArgs e)
        {
            Cuenta_CB.DataSource = cuentas;
            Cuenta_CB.Update();
        }

        private void Cancelar_BTN_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
