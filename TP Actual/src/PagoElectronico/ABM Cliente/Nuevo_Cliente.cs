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
        private bool salir = true;

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

            if (!ValidadorHelper.validarSoloNumeros(textBoxPiso.Text) /*&& textBoxPiso.Text != ""*/)
            {
                errorProvider1.SetError(textBoxPiso, "Piso no válido");
                correcto = false;
            }

            if ((!ValidadorHelper.validarSoloLetras(textBoxDepto.Text) || textBoxDepto.Text.Length > 10) /*&& textBoxDepto.Text != ""*/)
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
                else
                {
                    if (TXT_RepetirPassword.Text != textBoxPW.Text)
                    {
                        errorProvider1.SetError(TXT_RepetirPassword, "Las password no coinciden");
                        correcto = false;
                    }
                }

                if (comboBoxPreg.SelectedValue == null)
                {
                    errorProvider1.SetError(comboBoxPreg, "Elija una pregunta");
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
                SQLParametros parametros = new SQLParametros();

                parametros.add("@Nombre", textBoxNombre.Text);
                parametros.add("@Apellido", textBoxApellido.Text);
                parametros.add("@Documento", Convert.ToDecimal(textBoxDocumento.Text));
                parametros.add("@tipoDoc", Convert.ToInt32(comboBoxTipoDoc.SelectedValue));
                parametros.add("@Mail", textBoxMail.Text);
                parametros.add("@Id_pais", Convert.ToDecimal(comboBoxPais.SelectedValue));
                parametros.add("@Calle", textBoxCalle.Text);
                parametros.add("@Altura", Convert.ToInt32(textBoxAltura.Text));
                parametros.add("@Piso", Convert.ToInt32(textBoxPiso.Text));
                parametros.add("@Departamento", textBoxDepto.Text);
                parametros.add("@Localidad", textBox9.Text);
                parametros.add("@Nacionalidad", Convert.ToDecimal(comboBoxNac.SelectedValue));
                parametros.add("@FechaNac", dateTimePicker1.Value);
                parametros.add("@Usuario", textBoxUser.Text);
                parametros.add("@Contrasena", Cifrador.Cifrar(textBoxPW.Text));
                parametros.add("@Id_pregunta", Convert.ToDecimal(comboBoxPreg.SelectedValue));
                parametros.add("@Respuesta", Cifrador.Cifrar(textBoxRes.Text));
                parametros.add("@Estado", checkBoxEstado.Checked ? "H" : "I");

                if (ConexionDB.Procedure("nuevoCliente", parametros.get()))
                {
                    MessageBox.Show("El usuario " + textBoxUser.Text + " ha sido dado de alta satisfactoriamente");
                    button4_Click(null, null);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            salir = false;
            Owner.Show();
            this.Close();
        }

        private void Nuevo_Cliente_Load(object sender, EventArgs e)
        {
            DataTable tiposDoc;

            if (ConexionDB.Procedure("ObtenerTipoDoc", null, out tiposDoc))
            {
                comboBoxTipoDoc.DataSource = tiposDoc;
                comboBoxTipoDoc.DisplayMember = "Descripcion";
                comboBoxTipoDoc.ValueMember = "Id_tipo_documento";
                comboBoxTipoDoc.SelectedIndex = -1;
            }

            DataTable paises;

            if (ConexionDB.Procedure("ObtenerPaises", null, out paises))
            {
                comboBoxPais.DataSource = paises;
                comboBoxPais.DisplayMember = "Descripcion";
                comboBoxPais.ValueMember = "Codigo";
                comboBoxPais.SelectedIndex = -1;
            }

            DataTable nacionalidades;

            if (ConexionDB.Procedure("ObtenerPaises", null, out nacionalidades))
            {
                comboBoxNac.DataSource = nacionalidades;
                comboBoxNac.DisplayMember = "Descripcion";
                comboBoxNac.ValueMember = "Codigo";
                comboBoxNac.SelectedIndex = -1;
            }

            dateTimePicker1.Value = Sesion.fecha;
            dateTimePicker1.MaxDate = Sesion.fecha;

            DataTable preguntas;

            if (ConexionDB.Procedure("ObtenerPreguntas", null, out preguntas))
            {
                comboBoxPreg.DataSource = preguntas;
                comboBoxPreg.DisplayMember = "Pregunta";
                comboBoxPreg.ValueMember = "Id_pregunta";
                comboBoxPreg.SelectedIndex = -1;
            }
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
            TXT_RepetirPassword.Enabled = false;
            TXT_RepetirPassword.Text = "******";
            comboBoxPreg.SelectedValue = cell["id_pregunta"].Value;
            comboBoxPreg.Enabled = false;
            textBoxRes.Text = "******";
            textBoxRes.Enabled = false;

            checkBoxEstado.Checked = (cell["Estado usuario"].Value.ToString() == "H");
            checkBoxCliente.Checked = (cell["Estado cliente"].Value.ToString() == "H");

            idCliente = Convert.ToDecimal(cell["id_cliente"].Value);
            button1.Text = "Modificar cliente";
            button1.Click -=new EventHandler(button1_Click);
            button1.Click += new EventHandler(button1_Click_Modificar);

            buttonTarjetas.Enabled = true;


        }

        private void button1_Click_Modificar(object sender, EventArgs e)
        {
            if (validacion())
            {
                SQLParametros parametros = new SQLParametros();
                
                parametros.add("@Id_cliente", idCliente);
                parametros.add("@Nombre", textBoxNombre.Text);
                parametros.add("@Apellido", textBoxApellido.Text);
                parametros.add("@Documento", Convert.ToDecimal(textBoxDocumento.Text));
                parametros.add("@tipoDoc", Convert.ToInt32(comboBoxTipoDoc.SelectedValue));
                parametros.add("@Mail", textBoxMail.Text);
                parametros.add("@Id_pais", Convert.ToDecimal(comboBoxPais.SelectedValue));
                parametros.add("@Calle", textBoxCalle.Text);
                parametros.add("@Altura", Convert.ToInt32(textBoxAltura.Text));
                parametros.add("@Piso", Convert.ToInt32(textBoxPiso.Text));
                parametros.add("@Departamento", textBoxDepto.Text);
                parametros.add("@Localidad", textBox9.Text);
                parametros.add("@Nacionalidad", Convert.ToDecimal(comboBoxNac.SelectedValue));
                parametros.add("@FechaNac", dateTimePicker1.Value);
                parametros.add("@EstadoUsuario", checkBoxEstado.Checked ? "H" : "I");
                parametros.add("@EstadoCliente", checkBoxCliente.Checked ? "H" : "I");

                if(ConexionDB.Procedure("modificarCliente", parametros.get()))
                {
                    MessageBox.Show("El usuario " + textBoxUser.Text + " ha sido modificado satisfactoriamente");
                    button4_Click(null, null);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            salir = false;
            new Nuevo_Cliente().Show(Owner);
            this.Close();
        }

        private void checkBoxEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEstado.Checked)
                checkBoxEstado.Text = "Habilitado";
            else
                checkBoxEstado.Text = "Deshabilitado";
        }

        private void checkBoxCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCliente.Checked)
                checkBoxCliente.Text = "Habilitado";
            else
                checkBoxCliente.Text = "Deshabilitado";
        }

        private void buttonTarjetas_Click(object sender, EventArgs e)
        {
            new ABM_Tarjeta.mtar(idCliente).Show(this);
            this.Hide();

        }

        private void Nuevo_Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
