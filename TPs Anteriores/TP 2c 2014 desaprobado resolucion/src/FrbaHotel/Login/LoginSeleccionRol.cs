using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.Login
{
    public partial class LoginSeleccionRol : Form
    {

        public LoginSeleccionRol()
        {
            InitializeComponent();

            Hoteles.Items.Clear();
            DataTable hotelesDeUsuario = GestorDeSistema.obtenerHotelesParaUsuario(FrbaHotel.Singleton.Instance.usuarioID);
            Hoteles.DisplayMember = "Hotel_Nombre";
            Hoteles.ValueMember = "Hotel_ID";
            Hoteles.DataSource = hotelesDeUsuario;

            Hoteles.Update();
        }

        private void seleccionarHotel_Click(object sender, EventArgs e)
        {
            FrbaHotel.Singleton.Instance.hotel = (int) Hoteles.SelectedValue;
            FrbaHotel.Singleton.Instance.hotel_nombre = Hoteles.Text;

            DataTable rolesDeUsuario = GestorDeSistema.obtenerRolesParaUsuario(FrbaHotel.Singleton.Instance.usuarioID, FrbaHotel.Singleton.Instance.hotel);
            roles.DisplayMember = "Rol_Nombre";
            roles.ValueMember = "Rol_Cod";
            roles.DataSource = rolesDeUsuario;

            roles.Update();

            roles.Visible = true;
            seleccionarRol.Visible = true;
            label1.Visible = true;
        }

        private void seleccionarRol_Click(object sender, EventArgs e)
        {
            FrbaHotel.Singleton.Instance.rol_cod = (int)roles.SelectedValue;

            Main frmMainMenu = new Main();
            frmMainMenu.Show(this);
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void Hoteles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoginSeleccionRol_Load(object sender, EventArgs e)
        {

        }
    }
}
