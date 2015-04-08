using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;
using System.Data.SqlClient;
using FrbaHotel.OperacionesDB.ConexionDB;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ModificarRol : Form
    {
        private bool hab;
        private int rol_cod;
        public ModificarRol(int codigo_rol,string nombre_rol,bool habilitado)
        {
            InitializeComponent();

            hab=habilitado;
            rol_cod = codigo_rol;

            NombreDelRolAModificarLabel.Text = nombre_rol;
            rolHabilitadoCheckbox.Checked = habilitado;

            funcionalidades.DataSource = GestorDeSistema.obtenerFuncionalidades();
            funcionalidades.DisplayMember = "Funcionalidad_Descripcion";
            funcionalidades.ValueMember = "Funcionalidad_Cod";
            funcionalidades.Update();

            List<byte> listaDeFuncionalidadesHabilitadas = GestorDeSistema.getfuncporrolhab(codigo_rol);

            for (int count = 0; count < funcionalidades.Items.Count; count++)
            {
                funcionalidades.SetItemChecked(count, false);
                if (listaDeFuncionalidadesHabilitadas.Contains((byte)(((DataRowView)funcionalidades.Items[count])["Funcionalidad_Cod"])))
                {
                    funcionalidades.SetItemChecked(count, true);
                }
            }

         }

        private void VolverButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (hab && !rolHabilitadoCheckbox.Checked)
                {MessageBox.Show("Para deshabilitar un rol vuelva a la pantalla anterior y dele la baja"); return; }
            GestorDeSistema.habdeshabrol(rol_cod,(byte)((rolHabilitadoCheckbox.Checked)?1:0));
            foreach (DataRowView view in funcionalidades.Items)
                GestorDeSistema.habODeshabFuncporRol(NombreDelRolAModificarLabel.Text, Convert.ToInt32(view["Funcionalidad_Cod"]), 0);
            foreach (DataRowView view in funcionalidades.CheckedItems)
                GestorDeSistema.habODeshabFuncporRol(NombreDelRolAModificarLabel.Text, Convert.ToInt32(view["Funcionalidad_Cod"]),1);
            Owner.Show();
            this.Hide();
        }

    }
}
