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
        public EdicionCuenta(DataGridViewCellCollection cell)
        {
            InitializeComponent();
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

    }
}
