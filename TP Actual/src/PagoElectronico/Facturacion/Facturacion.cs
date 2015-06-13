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
    public partial class Facturacion : Form
    {
        private void actualizarMov(string usuario, decimal userID)
        {
            label3.Text = usuario;

            DataTable movSinFacturar;
            SQLParametros parametros = new SQLParametros();
            parametros.add("@user_id", userID);

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            if (ConexionDB.Procedure("movSinFacturar", parametros.get(), out movSinFacturar) && movSinFacturar.Rows.Count > 0)
            {
                dataGridView1.DataSource = movSinFacturar;
                dataGridView1.Visible = true;
                label4.Visible = false;
                button2.Enabled = true;
            }
            else
            {
                dataGridView1.Visible = false;
                label4.Text = "No hay item para mostrar";
                label4.Visible = true;
                button2.Enabled = false;
                return;
            }
        }
        public Facturacion()
        {
            InitializeComponent();
            if (Sesion.rol_id == 1)
            {
                label3.Visible = false;
                comboBox1.Visible = true;
                DataTable usuarios;

                if (ConexionDB.Procedure("ObtenerUsuariosClientes", null, out usuarios))
                {
                    comboBox1.DataSource = usuarios;
                    comboBox1.ValueMember = "Id_usuario";
                    comboBox1.DisplayMember = "Usuario";
                    comboBox1.Text = "Elija un usuario";
                    comboBox1.SelectedIndex = -1;
                }
            }
            else
            {
                actualizarMov(Sesion.usuario,Sesion.user_id);
            }
            
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (Sesion.rol_id != 1)
            {
                new Factura(Sesion.user_id).Show(Owner);
                this.Close();
            }
            else 
            {
                new Factura(Convert.ToInt32(comboBox1.SelectedValue)).Show(this);
                this.Hide();
                actualizarMov(comboBox1.SelectedText, Convert.ToDecimal(comboBox1.SelectedValue));
            }
            
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal user = Convert.ToDecimal(comboBox1.SelectedValue);
                actualizarMov(comboBox1.SelectedText, user);
            }
            catch (NullReferenceException) { }
            catch (InvalidCastException) { }
        }
    }
}
