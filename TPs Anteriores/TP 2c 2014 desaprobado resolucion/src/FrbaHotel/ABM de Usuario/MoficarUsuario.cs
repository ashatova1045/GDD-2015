using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;
using FrbaHotel.OperacionesDB.Cifrado;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class MoficarUsuario : Form
    {
        Boolean cambiosOk;
        private bool estabahab;
        public Usuario usuarioSeleccionado { get; set; }

        public MoficarUsuario(DataGridViewRow usuario)
        {
            InitializeComponent();
            cambiosOk = true;
            DataTable TiposPasaporte = GestorDeSistema.ObtenerTodosLosTipoDePasaporte();
            TipoPasComboBox.DisplayMember = "Pasaporte_Tipo_Descripcion";
            TipoPasComboBox.ValueMember = "Pasaporte_Tipo";
            TipoPasComboBox.DataSource = TiposPasaporte;
            
            estabahab = Convert.ToBoolean(usuario.Cells["chabilitado"].Value);
            

            ValorIDLabel.Text = Convert.ToString((usuario.Cells["cid"].Value));
            UsernametextBox.Text = usuario.Cells["cusername"].Value.ToString();
            TipoPasComboBox.SelectedValue = Convert.ToInt32(usuario.Cells["cpasdes"].Value);
            NumeroPastextBox.Text = Convert.ToString(usuario.Cells["cndoc"].Value);
            DirecciontextBox.Text = usuario.Cells["cdireccion"].Value.ToString();
            NombretextBox.Text = usuario.Cells["cnombre"].Value.ToString();
            ApellidotextBox.Text = usuario.Cells["capellido"].Value.ToString();
            MailtextBox.Text = usuario.Cells["cmail"].Value.ToString();
            TelefonotextBox.Text = Convert.ToString(usuario.Cells["ctelefono"].Value);
            habilitadoCheckBox.Checked = estabahab;
        }

        private void VolverButon_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void GuardarCambiosbutton_Click(object sender, EventArgs e)
        {
            cambiosOk = true;

 

            if (NumeroPastextBox.Text.Length <= 17 || TelefonotextBox.Text.Length <= 17)
            {
                this.validacionCampoNumerico(NumeroPastextBox);
                this.validacionCampoNumerico(TelefonotextBox);
            }
            else
            {
                MessageBox.Show("ha superado la longitud maxima para este campo", "Error por Ingreso de datos no validos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cambiosOk = false;
            }
            this.validacionCaracteres(NombretextBox);
            this.validacionCaracteres(ApellidotextBox);



            if (cambiosOk == true)
            {
                Usuario usuario = new Usuario();
                usuario.id = Convert.ToInt32(ValorIDLabel.Text);
                usuario.username = UsernametextBox.Text;
                usuario.contrasena = ContraseñaTextBox.Text == string.Empty ? null : Cifrador.Cifrar(ContraseñaTextBox.Text);
                usuario.tipoPasaporte = Convert.ToInt32(TipoPasComboBox.SelectedValue);
                if (NumeroPastextBox.Text == String.Empty)
                { MessageBox.Show("Debe introducir numero de pasaporte"); return; }
                usuario.numeroPasaporte = Convert.ToDecimal(NumeroPastextBox.Text);

                usuario.direccion = DirecciontextBox.Text;
                if (estabahab && !habilitadoCheckBox.Checked)
                { MessageBox.Show("Para deshabilitar un usuario, vuelva  a la pantalla anterior y borrelo"); return; }
                usuario.habilitado = habilitadoCheckBox.Checked;
                usuario.nombre = NombretextBox.Text;
                usuario.apellido = ApellidotextBox.Text;
                usuario.mail = MailtextBox.Text;
                if (TelefonotextBox.Text == "")
                {
                    usuario.telefono = -1;
                }
                else
                    usuario.telefono = Convert.ToDecimal(TelefonotextBox.Text);

                GestorDeSistema.modificarUsuarios(usuario);


                MessageBox.Show("Usuario modificado");


                Owner.Show();
                this.Hide();
            }

        }

        private void NombretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarCamposConCaracteres(sender, e, NumeroPastextBox);


        }

        private void NumeroPastextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarYvalidarCamposNumericos(sender, e, NumeroPastextBox);

        }



        public void ingresarYvalidarCamposNumericos(object sender, KeyPressEventArgs e, TextBox textBox)
        {
            if (NumeroPastextBox.Text.Length < 18)
            {

                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }

                else
                {
                    MessageBox.Show("No se pueden Ingresar letras,por favor, ingrese numeros y sin espacios", "Error por Ingreso de Datos no validos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox.Focus();
                    e.Handled = false;
                }
            }
            else
            {
                MessageBox.Show("ha superado la longitud maxima para este campo", "Error por Ingreso de datos no validos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox.Focus();
                e.Handled = false;
            }
        }
        public void validarCamposConCaracteres(object sender, KeyPressEventArgs e, TextBox textBox)
        {


            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Space) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se pueden Ingresar Numeros", "Error por Ingreso de Datos no validos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NombretextBox.Focus();
                e.Handled = true;
            }
        }


        private void TelefonotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarYvalidarCamposNumericos(sender, e, TelefonotextBox);
        }
        public void validacionCampoNumerico(TextBox textBox)
        {
            String cadena = textBox.Text;
            Char c;

            for (int i = 0; i <= textBox.Text.Length-1;i++ )
            {
               
                c =Convert.ToChar(cadena[i]);
                

                if (Char.IsDigit(c))
                {


                }
                else
                {
                    this.cambiosOk = false;
                    MessageBox.Show("Por favor revise los datos ingresados, al parecer son invalidos", "Error por Ingreso de Datos no validos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox.Focus();
                }

            }
        }
        private void validacionCaracteres(TextBox textBox)
        {
            String cadena = textBox.Text;
            Char c;

            for (int i = 0; i <= textBox.Text.Length - 1; i++)
            {

                c = Convert.ToChar(cadena[i]);


                if ((char.IsLetter(c)))
                {


                }
                else
                {
                    this.cambiosOk = false;
                    MessageBox.Show("Por favor revise los datos ingresados, al parecer son invalidos", "Error por Ingreso de Datos no validos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox.Focus();
                }

            }
        }
    }


}