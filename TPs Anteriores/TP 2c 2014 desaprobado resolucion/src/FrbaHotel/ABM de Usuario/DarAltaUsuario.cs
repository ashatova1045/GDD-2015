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
    public partial class DarAltaUsuario : Form
    {
        public DarAltaUsuario(int hotel)
        {
            InitializeComponent();
            actualizarcombos();
        }

        private void actualizarcombos()
        {
            DataTable rolessinguest = GestorDeSistema.ObtenerTodosLosRoles();
            DataRow[] rows = rolessinguest.Select("Rol_Nombre = 'Guest'");
            foreach (DataRow r in rows)
                r.Delete();

            roles.DataSource = rolessinguest;
            roles.DisplayMember = "Rol_Nombre";
            roles.ValueMember = "Rol_Cod";
            roles.Update();

            tiposdoc.DataSource = GestorDeSistema.ObtenerTodosLosTipoDePasaporte();
            tiposdoc.DisplayMember = "Pasaporte_Tipo_Descripcion";
            tiposdoc.ValueMember = "Pasaporte_Tipo";
            tiposdoc.Update();
        }

        private void DarAltaClienteBoton_Click(object sender, EventArgs e)
        {
            if (validar())
            {

                GestorDeSistema.nuevoUsuario((radioButton1.Checked) ? GestorDeSistema.obtenerDescripcionPas(TipoDocTextBox.Text) : Convert.ToInt32(tiposdoc.SelectedValue), Convert.ToDecimal(nrodoc.Text), user.Text, Cifrador.Cifrar(pass.Text), dateTimePicker1.Value, direccion.Text,mailt.Text,nombret.Text,apellidot.Text,Convert.ToDecimal(telefonot.Text));
                GestorDeSistema.nuevoRolPorUsuario((int)roles.SelectedValue, FrbaHotel.Singleton.Instance.hotel, user.Text);

                foreach (Control control in this.Controls)
                {
                    TextBox box = control as TextBox;
                    if (box != null)
                    {
                        box.Clear();
                    }
                }
                actualizarcombos();
                MessageBox.Show("Usuario agregado");
            }
        }

        private bool validar()
        {
            foreach (Control control in this.Controls)
            {
                TextBox box = control as TextBox;
                if (box != null)
                {
                    if (box.Text == "" && !(box == TipoDocTextBox && radioButton2.Checked))
                    {
                        MessageBox.Show("Faltan datos");
                        return false;
                    }
                }
            }

            if (radioButton1.Checked) 
            {
                GestorDeSistema.nuevoTipoPas(TipoDocTextBox.Text);
            }
            if (GestorDeSistema.obtenerUsuariosRepetidos((radioButton1.Checked) ? GestorDeSistema.obtenerDescripcionPas(TipoDocTextBox.Text) : Convert.ToInt32(tiposdoc.SelectedValue), Convert.ToDecimal(nrodoc.Text), user.Text,mailt.Text))
            {
                MessageBox.Show("Documento o nombre de usuario repetido");
                return false;
            }
            return true;
        }



        private void VolverBoton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
         if (radioButton1.Checked)
            {
                tiposdoc.Enabled = false;
                TipoDocTextBox.Enabled = true;
                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                tiposdoc.Enabled = true;
                TipoDocTextBox.Enabled = false;
                radioButton1.Checked = false;
            }

        }

    }
}
