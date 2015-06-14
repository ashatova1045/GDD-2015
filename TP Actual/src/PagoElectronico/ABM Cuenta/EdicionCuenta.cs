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
        private bool salir = true;
        decimal user;
        public EdicionCuenta(DataGridViewCellCollection cell, decimal usuario)
        {
            InitializeComponent();
            user = usuario;
            Inicio();
            if (cell != null)
            {
                cargarDatos(cell);
                button1.Click += new System.EventHandler(modCuenta);
            }
            else
            {
                button1.Click += new System.EventHandler(nuevaCuenta);
                dateTimePicker1.Value = Sesion.fecha;
            }

        }
        private void cargarDatos(DataGridViewCellCollection cell)
        {
            textBoxNumero.Enabled = false;
            textBoxNumero.Text = cell["Cuenta"].Value.ToString();
            comboBoxPais.SelectedValue = cell["Id_pais"].Value;
            comboBoxMoneda.SelectedValue = cell["Id_moneda"].Value;
            dateTimePicker1.Value = (DateTime)cell["Fecha apertura"].Value;
            comboBoxTipoCuenta.SelectedValue = cell["Id_moneda"].Value;
        }

        private void Inicio()
        {
            DataTable paises;

            if (ConexionDB.Procedure("ObtenerPaises", null, out paises))
            {
                comboBoxPais.DataSource = paises;
                comboBoxPais.DisplayMember = "Descripcion";
                comboBoxPais.ValueMember = "Codigo";
                comboBoxPais.SelectedIndex = -1;
            }
            
             DataTable monedas;

             if (ConexionDB.Procedure("ObtenerMonedas", null, out monedas))
             {

                 comboBoxMoneda.DataSource = monedas;
                 comboBoxMoneda.DisplayMember = "Descripcion";
                 comboBoxMoneda.ValueMember = "Id_moneda";
                 comboBoxMoneda.SelectedIndex = -1;
             }

             DataTable tipoCuentas;

             if (ConexionDB.Procedure("ObtenerTipoCuentas", null, out tipoCuentas))
             {
                 comboBoxTipoCuenta.DataSource = tipoCuentas;
                 comboBoxTipoCuenta.DisplayMember = "Descripcion";
                 comboBoxTipoCuenta.ValueMember = "Id_tipo_cuenta";
                 comboBoxTipoCuenta.SelectedIndex = -1;
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir = false;
            ((AdministrarCuentas)Owner).actualizarCuentas();
            Owner.Show();
            this.Close();
        }

        private bool validarDatos()
        {
            errorProvider1.Clear();
            bool correcto = true;

            if(!ValidadorHelper.validarSoloNumeros( textBoxNumero.Text ))
            {
                errorProvider1.SetError(textBoxNumero, "El numero de tarjeta no es valido");
                correcto = false;
            }

            if (comboBoxPais.SelectedValue == null)
            {
                errorProvider1.SetError(comboBoxPais,"Elija un pais");
                correcto = false;
            }

            if (comboBoxMoneda.SelectedValue == null)
            {
                errorProvider1.SetError(comboBoxMoneda, "Elija una moneda");
                correcto = false;
            }

            if (comboBoxTipoCuenta.SelectedValue == null)
            {
                errorProvider1.SetError(comboBoxTipoCuenta, "Elija un tipo de cuenta");
                correcto = false;
            }
            

            return correcto;
        }

        private List<SqlParameter> cargarLista()
        {
            SQLParametros parametros = new SQLParametros();

            parametros.add("@Id_usuario", user);
            parametros.add("@Id_cuenta", Convert.ToDecimal(textBoxNumero.Text));
            parametros.add("@Id_pais", comboBoxPais.SelectedValue);
            parametros.add("@Id_moneda", comboBoxMoneda.SelectedValue);
            parametros.add("@FechaApert", dateTimePicker1.Value);
            parametros.add("@id_tipoCta", comboBoxTipoCuenta.SelectedValue);

            return parametros.get();

        }

        private void modCuenta(object sender, EventArgs e)
        {

            if(validarDatos() && ConexionDB.Procedure("ModCuenta", cargarLista()))
            {
                MessageBox.Show("Cuenta modificada exitosamente");
                button2_Click(null, null);

            }
        }

        private void nuevaCuenta(object sender, EventArgs e)
        {
            if (validarDatos() && ConexionDB.Procedure("nvaCuenta", cargarLista()))
            {
                MessageBox.Show("Cuenta creada exitosamente");
                button2_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void EdicionCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }

    }
}

