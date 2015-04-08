using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class CrearRol : Form
    {
        public CrearRol()
        {
            InitializeComponent();
            
            funcionalidades.DataSource = GestorDeSistema.obtenerFuncionalidades();
            funcionalidades.DisplayMember = "Funcionalidad_Descripcion";
            funcionalidades.ValueMember = "Funcionalidad_Cod";
            funcionalidades.Update();
        }

        private void VolverButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void CrearButton_Click(object sender, EventArgs e)
        {
            if (NombreTextBox.Text == "")
                {MessageBox.Show("Ingrese un nombre para el nuevo rol");return;}
            if (GestorDeSistema.buscarRoles("",NombreTextBox.Text).Rows.Count>1)
                {MessageBox.Show("Ingrese un nombre para el nuevo rol");return;}
                
            GestorDeSistema.nuevoRol(NombreTextBox.Text, RolActivoCheckBox.Checked);

            foreach(DataRowView view in funcionalidades.CheckedItems)
                GestorDeSistema.habODeshabFuncporRol(NombreTextBox.Text, Convert.ToInt32(view["Funcionalidad_Cod"]), 1);

            MessageBox.Show("Rol creado");
        }

    }
}
