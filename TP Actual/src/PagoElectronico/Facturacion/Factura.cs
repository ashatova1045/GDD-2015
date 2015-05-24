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

namespace PagoElectronico.Facturacion
{
    public partial class Factura : Form
    {

        public Factura(int user)
        {
            InitializeComponent();
            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@user_id", user));
            listaDeParametros.Add(new SqlParameter("@fecha", Sesion.fecha));

            DataTable datosFactura;
            DataTable itemFacturas;

            datosFactura = ConexionDB.invocarStoreProcedure(Sesion.conexion, "Facturar", listaDeParametros);
            label2.Text = datosFactura.Rows[0][0].ToString();
            label4.Text = datosFactura.Rows[0][2].ToString();
            label6.Text = datosFactura.Rows[0][1].ToString();
            label8.Text = datosFactura.Rows[0][3].ToString();
            label10.Text = datosFactura.Rows[0][4].ToString();

            listaDeParametros.Clear();
            listaDeParametros.Add(new SqlParameter("@id_factura", datosFactura.Rows[0][0]));
            itemFacturas = ConexionDB.invocarStoreProcedure(Sesion.conexion, "itemFactura", listaDeParametros);
            dataGridView1.DataSource = itemFacturas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
