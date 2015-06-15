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

namespace PagoElectronico.Listados
{
    public partial class ListadoGenerado : Form
    {
        private bool salir = true;

        public ListadoGenerado(int anioIngresado, int tListado, int trimestre)
        {
            InitializeComponent();

            SQLParametros parametros = new SQLParametros();

            parametros.add("@anio", anioIngresado);
            parametros.add("@primerMes", 1 + (trimestre * 3));
            parametros.add("@ultimoMes", 3 + (trimestre * 3));

            string procToCall = "generarListado" + tListado.ToString();
            DataTable listado;

            if (ConexionDB.Procedure(procToCall, parametros.get(), out listado))
            {
                dataGridView1.DataSource = listado;
            }
        }

        

        private void volver_Click(object sender, EventArgs e)
        {
            salir = false;
            Owner.Show();
            this.Close();
        }

        private void ListadoGenerado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }
    }
}
