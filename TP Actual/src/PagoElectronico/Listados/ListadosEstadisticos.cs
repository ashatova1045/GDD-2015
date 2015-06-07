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
    public partial class ListadosEstadisticos : Form

    {
        int anioIngresado;
        int tListado;
        int trimestre;

        public ListadosEstadisticos()
        {
            InitializeComponent();

            TListadoCBox.Items.Add("Clientes con cuentas inhabilitados por falta de pago de transacciones");
            TListadoCBox.Items.Add("Cliente con mayor cantidad de comisiones facturadas en todas sus cuentas");
            TListadoCBox.Items.Add("Clientes con mayor cantidad de transacciones ralizadas entre cuentas propias");
            TListadoCBox.Items.Add("Paises con mayor cantidad de movimientos tanto ingresos como egresos");
            TListadoCBox.Items.Add("Total facturado para distintos tipos de cuentas");

            TrimestreCBox.Items.Add("Enero-Febrero-Marzo");
            TrimestreCBox.Items.Add("Abril-Mayo-Junio");
            TrimestreCBox.Items.Add("Julio-Agosto-Septiembre");
            TrimestreCBox.Items.Add("Octubre-Noviembre-Diciembre");

            TListadoCBox.SelectedIndex = 0;
            TrimestreCBox.SelectedIndex = 0;

            generarB.Enabled = false;
         
        }

        
        private void AnioTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ValidadorHelper.validarSoloNumeros(AnioTextBox.Text) && AnioTextBox.Text.Length > 3)
            {
                errorProvider1.Clear();
                anioIngresado = Convert.ToInt32(AnioTextBox.Text);
                generarB.Enabled = true;
            }
            else
            {  
                errorProvider1.SetError(AnioTextBox, "El año ingresado no es correcto");
                generarB.Enabled = false;
            }

            
        }


        private void TrimestreCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            trimestre = TrimestreCBox.SelectedIndex; //le asigno el index
        }


        private void TListadoCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tListado = TListadoCBox.SelectedIndex; //Le asigno el index
        }


        private void volverFuncionalidades_Click_1(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }


        private void generarB_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoGenerado(anioIngresado, tListado, trimestre).Show(this);
        }


    }
}
