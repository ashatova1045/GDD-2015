using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;
using FrbaHotel.Login;


namespace FrbaHotel.ABM_de_Usuario
{
    public partial class ABMSeleccionU : Form
    {
        public Usuario usuarioSeleccionado;

        public ABMSeleccionU()
        {
            InitializeComponent();

            
            usuarioSeleccionado = new Usuario();
 
            TipoDoccomboBox.DisplayMember = "Pasaporte_Tipo_Descripcion";
            TipoDoccomboBox.ValueMember = "Pasaporte_Tipo";
            TipoDoccomboBox.DataSource = GestorDeSistema.ObtenerTodosLosTipoDePasaporte();
            TipoDoccomboBox.Update();
            this.clear();
            nombreHotelLabel.Text = FrbaHotel.Singleton.Instance.hotel_nombre;

      
        }

        private void CrearRolButton_Click(object sender, EventArgs e)
        {
            DarAltaUsuario nuevoUsuario = new DarAltaUsuario(FrbaHotel.Singleton.Instance.hotel);
            nuevoUsuario.Show(this);
            this.Hide();
        }

        private void VolverButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void ABMSeleccionU_Load(object sender, EventArgs e)
        {

            int IdHotelSeleccionado = FrbaHotel.Singleton.Instance.hotel; 

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            apellidoTextBox.Text = String.Empty;
            nombretextBox.Text = String.Empty;
            mailTextBox.Text = String.Empty;
            nroDocTextBox.Text = String.Empty;
            TipoDoccomboBox.DisplayMember = String.Empty;
            usernameTextBox.Text = String.Empty;
            datagridViewUsuario.Rows.Clear();
            datagridViewUsuario.Update();
        }

        private void buscarBoton_Click(object sender, EventArgs e)
        {
            
            datagridViewUsuario.Update();
            string apellido = apellidoTextBox.Text;
            string nombre = nombretextBox.Text;
            string mail = mailTextBox.Text;
            string username = usernameTextBox.Text;
            string nrodoc = nroDocTextBox.Text;
            string userId = UsuarioIDTextBox.Text;
            string direccion = direcciont.Text;

            datagridViewUsuario.DataSource = GestorDeSistema.buscarUsuarios(direccion,nombre, apellido, mail, username, nrodoc,(int)TipoDoccomboBox.SelectedValue, userId, FrbaHotel.Singleton.Instance.hotel);
            datagridViewUsuario.Update();
       }

        private void DarBajaRolButton_Click(object sender, EventArgs e)
        {
            if (!(datagridViewUsuario.SelectedRows.Count == 1))
            {
                MessageBox.Show("Seleccione solo una fila");
                return;
            }
            if (!Convert.ToBoolean(datagridViewUsuario.CurrentRow.Cells["chabilitado"].Value))
            {
                MessageBox.Show("Este usuario ya esta deshabilitado");
                return;
            }

            Int32 id = Convert.ToInt32(datagridViewUsuario.CurrentRow.Cells["cid"].Value);

            GestorDeSistema.darBajaUsuario(id);

            MessageBox.Show("Baja exitosa");
            buscarBoton.PerformClick();
        }

        private void ModificarRolButton_Click(object sender, EventArgs e)
        {
            if (datagridViewUsuario.SelectedRows.Count == 1)
            {
               (new MoficarUsuario(datagridViewUsuario.SelectedRows[0])).Show(this);
                this.Hide();
            }
            buscarBoton.PerformClick();
        }

        private void LimpiarBoton_Click(object sender, EventArgs e)
        {
            this.clear();
        }

        private void clear()
        {
            usernameTextBox.Clear();
            nombretextBox.Clear();
            apellidoTextBox.Clear();
            mailTextBox.Clear();
            nroDocTextBox.Clear();
            direcciont.Clear();
            UsuarioIDTextBox.Clear();
            datagridViewUsuario.Update();
         }
        

    }
}
