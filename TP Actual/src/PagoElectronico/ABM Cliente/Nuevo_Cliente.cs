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
using PagoElectronico.OperacionesDB.Cifrador;

namespace PagoElectronico.ABM_Cliente
{
    public partial class Nuevo_Cliente : Form
    {
        public Nuevo_Cliente()
        {
            InitializeComponent();
        }
        
        private bool validacion()
        {
            errorProvider1.Clear();
            bool correcto = true;

            if (!ValidadorHelper.validarMail(textBoxMail.Text))
            {
                errorProvider1.SetError(textBoxMail, "Mail no válido");
                correcto = false;
            }

            if (!ValidadorHelper.ValidarFrase(textBoxNombre.Text))
            {
                errorProvider1.SetError(textBoxNombre, "Nombre no válido");
                correcto = false;
            }

            if (!ValidadorHelper.ValidarFrase(textBoxApellido.Text))
            {
                errorProvider1.SetError(textBoxApellido, "Apellido no válido");
                correcto = false;
            }

            if (!ValidadorHelper.validarSoloNumeros(textBoxDocumento.Text))
            {
                errorProvider1.SetError(textBoxDocumento, "Documento no válido");
                correcto = false;
            }

            if (comboBoxTipoDoc.SelectedValue == null)
            {
                errorProvider1.SetError(comboBoxTipoDoc, "Elija un tipo de documento");
                correcto = false;
            }

            if (comboBoxPais.SelectedValue == null)
            {
                errorProvider1.SetError(comboBoxPais, "Elija un pais");
                correcto = false;
            }

            if (!ValidadorHelper.ValidarFrase(textBoxCalle.Text))
            {
                errorProvider1.SetError(textBoxCalle, "Calle no válida");
                correcto = false;
            }

            if (!ValidadorHelper.validarSoloNumeros(textBoxAltura.Text))
            {
                errorProvider1.SetError(textBoxAltura, "Altura no válida");
                correcto = false;
            }

            if (!ValidadorHelper.validarSoloNumeros(textBoxPiso.Text))
            {
                errorProvider1.SetError(textBoxPiso, "Piso no válido");
                correcto = false;
            }

            if (!ValidadorHelper.validarSoloLetras(textBoxDepto.Text) || textBoxDepto.Text.Length > 10)
            {
                errorProvider1.SetError(textBoxDepto, "Departamento no válido");
                correcto = false;
            }

            if (comboBoxNac.SelectedValue == null)
            {
                errorProvider1.SetError(comboBoxNac, "Elija un pais");
                correcto = false;
            }

            if (textBoxUser.Enabled)
            {

                if (!ValidadorHelper.ValidarLetrasGuiones(textBoxUser.Text))
                {
                    errorProvider1.SetError(textBoxUser, "Usuario no válido");
                    correcto = false;
                }

                if (!ValidadorHelper.validarSoloLetras(textBoxPW.Text))
                {
                    errorProvider1.SetError(textBoxPW, "Password no válido");
                    correcto = false;
                }

                if (!ValidadorHelper.validarSoloLetras(textBoxPreg.Text))
                {
                    errorProvider1.SetError(textBoxPreg, "Pregunta no válida");
                    correcto = false;
                }

                if (!ValidadorHelper.ValidarFrase(textBoxRes.Text))
                {
                    errorProvider1.SetError(textBoxRes, "Respuesta no válida");
                    correcto = false;
                }
            }

            return correcto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validacion())
            {
                List<SqlParameter> listaDeParametros = new List<SqlParameter>();
                listaDeParametros.Add(new SqlParameter("@Nombre", textBoxNombre.Text));
                listaDeParametros.Add(new SqlParameter("@Apellido", textBoxApellido.Text));
                listaDeParametros.Add(new SqlParameter("@Documento", Convert.ToDecimal(textBoxDocumento.Text)));
                listaDeParametros.Add(new SqlParameter("@tipoDoc", Convert.ToInt32(comboBoxTipoDoc.SelectedValue)));
                listaDeParametros.Add(new SqlParameter("@Mail", textBoxMail.Text));
                listaDeParametros.Add(new SqlParameter("@Id_pais", Convert.ToDecimal(comboBoxPais.SelectedValue)));
                listaDeParametros.Add(new SqlParameter("@Calle", textBoxCalle.Text));
                listaDeParametros.Add(new SqlParameter("@Altura", Convert.ToInt32(textBoxAltura.Text)));
                listaDeParametros.Add(new SqlParameter("@Piso", Convert.ToInt32(textBoxPiso.Text)));
                listaDeParametros.Add(new SqlParameter("@Departamento", textBoxDepto.Text));
                listaDeParametros.Add(new SqlParameter("@Localidad", textBox9.Text));
                listaDeParametros.Add(new SqlParameter("@Nacionalidad", Convert.ToDecimal(comboBoxNac.SelectedValue)));
                listaDeParametros.Add(new SqlParameter("@FechaNac", dateTimePicker1.Value));
                listaDeParametros.Add(new SqlParameter("@Usuario", textBoxUser.Text));
                listaDeParametros.Add(new SqlParameter("@Contrasena", Cifrador.Cifrar(textBoxPW.Text)));
                listaDeParametros.Add(new SqlParameter("@Pregunta", textBoxPreg.Text));
                listaDeParametros.Add(new SqlParameter("@Respuesta", Cifrador.Cifrar(textBoxRes.Text)));
                listaDeParametros.Add(new SqlParameter("@Estado", checkBoxEstado.Checked ? "H" : "I"));

                try
                {
                    ConexionDB.invocarStoreProcedure(Sesion.conexion, "nuevoCliente", listaDeParametros);
                    MessageBox.Show("El usuario "+textBoxUser.Text+" ha sido dado de alta satisfactoriamente");
                    button4_Click(null, null);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void Nuevo_Cliente_Load(object sender, EventArgs e)
        {
            comboBoxTipoDoc.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.tipos_documentos");
            comboBoxTipoDoc.DisplayMember = "Descripcion";
            comboBoxTipoDoc.ValueMember = "Id_tipo_documento";
            comboBoxTipoDoc.SelectedIndex = -1;

            DataTable paises = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.paises");
            
            comboBoxPais.DataSource = paises;
            comboBoxPais.DisplayMember = "Descripcion";
            comboBoxPais.ValueMember = "Codigo";
            comboBoxPais.SelectedIndex = -1;

            comboBoxNac.DataSource = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.paises");
            comboBoxNac.DisplayMember = "Descripcion";
            comboBoxNac.ValueMember = "Codigo";
            comboBoxNac.SelectedIndex = -1;

            dateTimePicker1.Value = Sesion.fecha;
            dateTimePicker1.MaxDate = Sesion.fecha;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BuscarCliente().Show(this);
        }

        private decimal idCliente;

        public void recDatos(DataGridViewCellCollection cell)
        {
            textBoxNombre.Text = cell["Nombre"].Value.ToString();
            textBoxApellido.Text =cell["Apellido"].Value.ToString();
            textBoxDocumento.Text = cell["Documento"].Value.ToString();
            comboBoxTipoDoc.SelectedValue = cell["Id_tipo_documento"].Value;
            textBoxMail.Text = cell["Mail"].Value.ToString();
            comboBoxPais.SelectedValue = cell["Id_pais"].Value;
            textBoxAltura.Text = cell["Altura"].Value.ToString();
            textBoxCalle.Text = cell["Calle"].Value.ToString();
            textBoxPiso.Text = cell["Piso"].Value.ToString();
            textBoxDepto.Text = cell["Departamento"].Value.ToString();
            textBox9.Text = cell["Localidad"].Value.ToString();
            comboBoxNac.SelectedValue = cell["id_nacionalidad"].Value;
            dateTimePicker1.Value = (DateTime)cell["Fecha de nacimiento"].Value;
            textBoxUser.Text = cell["Usuario"].Value.ToString();
            textBoxUser.Enabled = false;
            textBoxPW.Text = "******";
            textBoxPW.Enabled = false;
            textBoxPreg.Enabled = false;
            textBoxRes.Text = "******";
            textBoxRes.Enabled = false;

            if (cell["Estado cuenta"].Value.ToString() == "H")
                checkBoxEstado.Checked = true;
            else
                checkBoxEstado.Checked = false;

            idCliente = Convert.ToDecimal(cell["id_cliente"].Value);
            button1.Text = "Modificar cliente";
            button1.Click -=new EventHandler(button1_Click);
            button1.Click += new EventHandler(button1_Click_Modificar);


        }

        private void button1_Click_Modificar(object sender, EventArgs e)
        {
            if (validacion())
            {
                List<SqlParameter> listaDeParametros = new List<SqlParameter>();
                listaDeParametros.Add(new SqlParameter("@Id_cliente", idCliente));
                listaDeParametros.Add(new SqlParameter("@Nombre", textBoxNombre.Text));
                listaDeParametros.Add(new SqlParameter("@Apellido", textBoxApellido.Text));
                listaDeParametros.Add(new SqlParameter("@Documento", Convert.ToDecimal(textBoxDocumento.Text)));
                listaDeParametros.Add(new SqlParameter("@tipoDoc", Convert.ToInt32(comboBoxTipoDoc.SelectedValue)));
                listaDeParametros.Add(new SqlParameter("@Mail", textBoxMail.Text));
                listaDeParametros.Add(new SqlParameter("@Id_pais", Convert.ToDecimal(comboBoxPais.SelectedValue)));
                listaDeParametros.Add(new SqlParameter("@Calle", textBoxCalle.Text));
                listaDeParametros.Add(new SqlParameter("@Altura", Convert.ToInt32(textBoxAltura.Text)));
                listaDeParametros.Add(new SqlParameter("@Piso", Convert.ToInt32(textBoxPiso.Text)));
                listaDeParametros.Add(new SqlParameter("@Departamento", textBoxDepto.Text));
                listaDeParametros.Add(new SqlParameter("@Localidad", textBox9.Text));
                listaDeParametros.Add(new SqlParameter("@Nacionalidad", Convert.ToDecimal(comboBoxNac.SelectedValue)));
                listaDeParametros.Add(new SqlParameter("@FechaNac", dateTimePicker1.Value));
                listaDeParametros.Add(new SqlParameter("@Estado", checkBoxEstado.Checked ? "H" : "I"));

                try
                {
                    ConexionDB.invocarStoreProcedure(Sesion.conexion, "modificarCliente", listaDeParametros);
                    MessageBox.Show("El usuario " + textBoxUser.Text + " ha sido modificado satisfactoriamente");
                    button4_Click(null, null);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Nuevo_Cliente().Show(Owner);
            this.Close();
        }

        private void checkBoxEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEstado.Checked)
                checkBoxEstado.Text = "Habilitada";
            else
                checkBoxEstado.Text = "Deshabilitada";
        }
    }
}
