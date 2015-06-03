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

namespace PagoElectronico.ABM_Cuenta
{
    public partial class EdicionCuenta : Form
    {
        decimal user;
        public EdicionCuenta(DataGridViewCellCollection cell, decimal usuario)
        {
            InitializeComponent();
            user = usuario;
            Inicio();
            if(cell != null)
                cargarDatos(cell);

        }
        private void cargarDatos(DataGridViewCellCollection cell)
        {
            textBox1.Text = cell[0].Value.ToString();
            comboBox1.SelectedValue = cell[1].Value;
            comboBox2.SelectedValue = cell[2].Value;
            dateTimePicker1.Value = (DateTime)cell[3].Value;
            comboBox3.SelectedValue = cell[4].Value;
        }

        private void Inicio()
        {
            comboBox1.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.paises");
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "Codigo";
            comboBox1.SelectedIndex = -1;

            comboBox2.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.monedas");
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "Id_moneda";
            comboBox2.SelectedIndex = -1;

            comboBox3.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.tipo_cuenta");
            comboBox3.DisplayMember = "Descripcion";
            comboBox3.ValueMember = "Id_tipo_cuenta";
            comboBox3.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@Id_usuario", user));
            listaDeParametros.Add(new SqlParameter("@Id_cuenta", Convert.ToDecimal(textBox1.Text)));
            listaDeParametros.Add(new SqlParameter("@Id_pais", comboBox1.SelectedValue ));
            listaDeParametros.Add(new SqlParameter("@FecApertura", dateTimePicker1.Value));
            listaDeParametros.Add(new SqlParameter("@Id_moneda", comboBox2.SelectedValue));
            listaDeParametros.Add(new SqlParameter("@Id_tipo_cuenta", comboBox3.SelectedValue));

            try
            {
                ConexionDB.invocarStoreProcedure(Sesion.conexion,"nvaCuenta",listaDeParametros);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

