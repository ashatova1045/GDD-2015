using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Listados
{
    public partial class ListadosEstadisticos : Form

    {
        string anioIngresado;

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

         
        }

        private void volverFuncionalidades_Click_1(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void TListadoCBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form nuevoForm = null;
            switch (TListadoCBox.SelectedIndex)
            {
               
                case 0:
                    nuevoForm = new Listados.Listado0();
                    break;
                case 1:
                    nuevoForm = new Listados.Listado1();
                    break;
                case 2:
                    nuevoForm = new Listados.Listado2();
                    break;
                case 3:
                    nuevoForm = new Listados.Listado3();
                    break;
                case 4:
                    nuevoForm = new Listados.Listado4();
                    break;              
            }

            nuevoForm.Show(this);
            this.Hide();

        }

        private void AnioTextBox_TextChanged(object sender, EventArgs e)
        {
            anioIngresado = AnioTextBox.Text;
     
       }
        private void AnioTextBox_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


    }
}
