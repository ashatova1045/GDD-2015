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
        public ListadoGenerado(int anioIngresado, int tListado, int trimestre)
        {
            InitializeComponent();

            List<SqlParameter> listaParaListados = new List<SqlParameter>();
            listaParaListados.Add(new SqlParameter("@anio", anioIngresado));
            listaParaListados.Add(new SqlParameter("@primerMes", 1 + (trimestre*3)));
            listaParaListados.Add(new SqlParameter("@ultimoMes", 3 + (trimestre * 3)));

            string procToCall = "generarListado" + tListado.ToString();

            dataGridView1.DataSource = ConexionDB.invocarStoreProcedure(Sesion.conexion, procToCall, listaParaListados);
        }

        

        private void volver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
