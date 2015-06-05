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
            textBoxNumero.Text = cell["Cuenta"].Value.ToString();
            comboBoxPais.SelectedValue = cell["Id_pais"].Value;
            comboBoxMoneda.SelectedValue = cell["Id_moneda"].Value;
            dateTimePicker1.Value = (DateTime)cell["Fecha apertura"].Value;
            comboBoxTipoCuenta.SelectedValue = cell["Id_moneda"].Value;
        }

        private void Inicio()
        {
            comboBoxPais.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.paises");
            comboBoxPais.DisplayMember = "Descripcion";
            comboBoxPais.ValueMember = "Codigo";
            comboBoxPais.SelectedIndex = -1;

            comboBoxMoneda.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.monedas");
            comboBoxMoneda.DisplayMember = "Descripcion";
            comboBoxMoneda.ValueMember = "Id_moneda";
            comboBoxMoneda.SelectedIndex = -1;

            comboBoxTipoCuenta.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.tipo_cuenta");
            comboBoxTipoCuenta.DisplayMember = "Descripcion";
            comboBoxTipoCuenta.ValueMember = "Id_tipo_cuenta";
            comboBoxTipoCuenta.SelectedIndex = -1;
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
            listaDeParametros.Add(new SqlParameter("@Id_cuenta", Convert.ToDecimal(textBoxNumero.Text)));
            listaDeParametros.Add(new SqlParameter("@Id_pais", comboBoxPais.SelectedValue ));
            listaDeParametros.Add(new SqlParameter("@FecApertura", dateTimePicker1.Value));
            listaDeParametros.Add(new SqlParameter("@Id_moneda", comboBoxMoneda.SelectedValue));
            listaDeParametros.Add(new SqlParameter("@Id_tipo_cuenta", comboBoxTipoCuenta.SelectedValue));

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

