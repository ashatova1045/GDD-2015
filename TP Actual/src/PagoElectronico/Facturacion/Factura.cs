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

        public Factura(decimal user)
        {
            InitializeComponent();

            SQLParametros parametros = new SQLParametros();
            parametros.add("@user_id", user);
            parametros.add("@fecha", Sesion.fecha);

            DataTable datosFactura;
            DataTable itemFacturas;

            if(ConexionDB.Procedure("Facturar", parametros.get(), out datosFactura))
            {
                label2.Text = datosFactura.Rows[0][0].ToString();
                label4.Text = datosFactura.Rows[0][2].ToString();
                label6.Text = datosFactura.Rows[0][1].ToString();
                label8.Text = datosFactura.Rows[0][3].ToString();
                label10.Text = datosFactura.Rows[0][4].ToString();

                parametros.Clear();
                parametros.add("@id_factura", datosFactura.Rows[0][0]);

                if (ConexionDB.Procedure("itemFactura", parametros.get(), out itemFacturas))
                {
                    dataGridView1.DataSource = itemFacturas;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
