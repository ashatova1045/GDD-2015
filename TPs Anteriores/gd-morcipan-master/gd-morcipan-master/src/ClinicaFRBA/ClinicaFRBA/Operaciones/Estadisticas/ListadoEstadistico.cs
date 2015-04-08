using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.Estadisticas
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();

            List<String> anios = new List<string>();
            anios.Add("2013");
            anios.Add("2014");
            anios.Add("2015");

            List<String> semestres = new List<String>();
            semestres.Add("Primero");
            semestres.Add("Segundo");

            List<String> listados = new List<String>();
            listados.Add("Especialidades que mas cancelaciones registraron");
            listados.Add("Cantidad total de bonos farmacia vencidos por afiliado");
            listados.Add("Especialidades de médicos con más bonos de farmacia recetados");
            listados.Add("Afiliados que utilizaron bonos que ellos mismos no compraron");
         
            cBoxAnio.DataSource = anios;
            cBoxAnio.Update();
            cBoxSemestre.DataSource = semestres;
            cBoxSemestre.Update();
            cBoxListado.DataSource = listados;
            cBoxListado.Update();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio;
            DateTime fechaFin;
            DataTable resultado = new DataTable();
            if(cBoxSemestre.SelectedIndex == 0 )
            {
                fechaInicio = new DateTime(Convert.ToInt32(cBoxAnio.Text),1,1,0,0,0,0);
                fechaFin = new DateTime(Convert.ToInt32(cBoxAnio.Text), 7, 1, 0, 0, 0, 0);
            }

            else
            {
                fechaInicio = new DateTime(Convert.ToInt32(cBoxAnio.Text), 7, 1, 0, 0, 0, 0);
                fechaFin = new DateTime(Convert.ToInt32(cBoxAnio.Text) + 1, 1, 1, 0, 0, 0, 0);
            }

            switch (cBoxListado.SelectedIndex)

            {
                case 0:
                    resultado = ManejadorNegocio.Listado1(fechaInicio,fechaFin);
                    break;

                case 1:
                    resultado = ManejadorNegocio.Listado2(fechaInicio,fechaFin);
                    break;

                case 2:
                    resultado= ManejadorNegocio.Listado3(fechaInicio,fechaFin);
                    break;

                case 3:
                    resultado = ManejadorNegocio.Listado4(fechaInicio, fechaFin);
                    break;

                default :
                    break;
            }
            if (resultado.Rows.Count > 0)
            {
                if (cBoxSemestre.SelectedIndex == 0)
                {
                    resultado.Columns["mes1"].ColumnName = "Enero";
                    resultado.Columns["mes2"].ColumnName = "Febrero";
                    resultado.Columns["mes3"].ColumnName = "Marzo";
                    resultado.Columns["mes4"].ColumnName = "Abril";
                    resultado.Columns["mes5"].ColumnName = "Mayo";
                    resultado.Columns["mes6"].ColumnName = "Junio";
                }
                else
                {
                    resultado.Columns["mes1"].ColumnName = "Julio";
                    resultado.Columns["mes2"].ColumnName = "Agosto";
                    resultado.Columns["mes3"].ColumnName = "Septiembre";
                    resultado.Columns["mes4"].ColumnName = "Octubre";
                    resultado.Columns["mes5"].ColumnName = "Noviembre";
                    resultado.Columns["mes6"].ColumnName = "Diciembre";
                }
            }
            else
            {
                MessageBox.Show("Sin resultado para los datos ingresados");
            }
            dtResultado.DataSource = resultado;
            dtResultado.Update();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cBoxListado.ResetText();
            dtResultado.DataSource = null;
            dtResultado.Update();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
