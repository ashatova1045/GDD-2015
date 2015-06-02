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
            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@user_id", userID));
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            try 
            {
            movSinFacturar = ConexionDB.invocarStoreProcedure(Sesion.conexion, "movSinFacturar",listaDeParametros);
            dataGridView1.DataSource = movSinFacturar;
            dataGridView1.Visible = true;
            label4.Visible = false;
            button2.Enabled = true;
            }
            catch(SqlException ex)
            {
                dataGridView1.Visible = false;
                label4.Text = ex.Message;
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
                usuarios = ConexionDB.correrQuery(Sesion.conexion, "select Id_usuario,Usuario from HHHH.usuarios where Id_usuario <> 1");
                comboBox1.DataSource = usuarios;
                comboBox1.ValueMember = "Id_usuario";
                comboBox1.DisplayMember = "Usuario";
                comboBox1.Text = "Elija un usuario";
                comboBox1.SelectedIndex = -1;
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
            }
            
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int user = Convert.ToInt32(comboBox1.SelectedValue);
                actualizarMov(comboBox1.SelectedText, user);
            }
            catch (NullReferenceException) { }
            catch (InvalidCastException) { }
        }
    }
}
