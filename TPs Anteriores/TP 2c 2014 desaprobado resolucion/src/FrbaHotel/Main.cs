using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.OperacionesDB.ModeloSistema;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.ABM_de_Hotel;
using FrbaHotel.ABM_de_Habitacion;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.Listado_Estadistico;
using FrbaHotel.Registrar_Consumible;
using FrbaHotel.Facturar;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel
{
    public partial class Main : Form
    {
        private DataTable funcionalidadesDeRol ;

        public Main()
        {
            InitializeComponent();

           funcionalidadesDeRol = GestorDeSistema.obtenerFuncionalidadesDeRol(FrbaHotel.Singleton.Instance.rol_cod);
           funcionalidades.DisplayMember = "Funcionalidad_Descripcion";
           funcionalidades.ValueMember = "Funcionalidad_Cod";
           funcionalidades.DataSource = funcionalidadesDeRol;
           funcionalidades.Update();
        }

        private void ir_Click(object sender, EventArgs e)
        {
            switch((byte)funcionalidades.SelectedValue)
            {
                case 1:
                    ABMSeleccionU abmU = new ABMSeleccionU();
                    abmU.Show(this);
                    this.Hide();
                    break;
                case 2:
                    ABMSeleccionC abmC = new ABMSeleccionC();
                    abmC.Show(this);
                    this.Hide();
                    break;
                case 3:
                    ABMSeleccionH abmH = new ABMSeleccionH();
                    abmH.Show(this);
                    this.Hide();
                    break;
                case 4:
                    ABMHabitacionVentanaPrincipal abmHa = new ABMHabitacionVentanaPrincipal();
                    abmHa.Show(this);
                    this.Hide();
                    break;
                case 6:
                    VentanaPrincipal res = new VentanaPrincipal();
                    res.Show(this);
                    this.Hide();
                    break;
                case 7:
                    checkin c = new checkin();
                    c.Show(this);
                    this.Hide();
                    break; 
               
                case 8:
                    ABMRolVentanaPrincipal abmR = new ABMRolVentanaPrincipal();
                    abmR.Show(this);
                    this.Hide();
                    break;
                case 9:
                    SeleccionDeListado listado = new SeleccionDeListado();
                    listado.Show(this);
                    this.Hide();
                    break;
                case 10:
                    RegistrarConsumible reg = new RegistrarConsumible();
                    reg.Show(this);
                    this.Hide();
                    break;
                case 11:
                    Facturar.Facturar fac = new Facturar.Facturar();
                    fac.Show(this);
                    this.Hide();
                    break;
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
