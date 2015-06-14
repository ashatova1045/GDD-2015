using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data.SqlClient;

namespace PagoElectronico.ABM_Rol
{
    public partial class AdministrarRoles : Form
    {
        DataTable rolesActuales;
        private void ActualizarRoles()
        {
            if (ConexionDB.Procedure("ObtenerRoles", null, out rolesActuales))
            {
                comboBox1.DataSource = rolesActuales;
                comboBox1.DisplayMember = "Nombre_rol";
                comboBox1.ValueMember = "Id_rol";
                comboBox1.Text = "Elija un Rol";
                comboBox1.Update();
                comboBox1.SelectedIndex = -1;
            }



        }

        public AdministrarRoles()
        {
            InitializeComponent();
        }

        private void AdministrarRoles_Load(object sender, EventArgs e)
        {
            ActualizarRoles();

            DataTable funcionalidades;

            if (ConexionDB.Procedure("ObtenerFuncionalidades", null, out funcionalidades))
            {
                foreach (DataRow row in funcionalidades.Rows)
                {
                    // foreach (DataColumn item in funcionalidades.Columns)
                    //{
                    //   if (item.ToString() == "Descripcion")
                    checkedListBox1.Items.Add(row["Descripcion"].ToString());
                    //  }
                }
                comboBox1.SelectedIndex = -1;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow[] rowRol = rolesActuales.Select("Id_rol = " + comboBox1.SelectedValue);

            resetear();
            try 
            { 
                if(rowRol[0][2].ToString() == "A")
                    checkBox1.Checked = true;
                else
                    checkBox1.Checked = false;
            }
            catch (IndexOutOfRangeException) { }
     
            button1.Enabled = false;

            SQLParametros parametros = new SQLParametros();
            parametros.add("@nombre", comboBox1.SelectedValue);

            DataTable funcsActivas;

            if (ConexionDB.Procedure("funcionesdelrol", parametros.get(), out funcsActivas))
            {
                /*
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }*/

                foreach (DataRow funcAct in funcsActivas.Rows)
                {
                    checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(funcAct["Descripcion"].ToString()), true);
                }
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;

            if (checkBox1.Checked)
            {
                checkBox1.Text = "Habilitado";
            }
            else
            {
                checkBox1.Text = "Deshabilitado";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoNombreRol nvorol = new NuevoNombreRol();
            nvorol.ShowDialog(this);

            resetear();

            this.ActualizarRoles();
         }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (!ValidadorHelper.ValidarLetrasGuiones(comboBox1.Text))
            {
                errorProvider1.SetError(comboBox1, "Elija un Rol");
                return;
            }
            
            string funciones = "";
            string estado = "N";

            if (checkBox1.Checked)
                estado = "A"; else estado = "N";

            button1.Enabled = false;
           
            foreach (Object itemChecked in checkedListBox1.CheckedItems)
            {
                funciones = funciones + "," + itemChecked.ToString();
               
            }

            resetear();

            SQLParametros parametros = new SQLParametros();

            parametros.add("@Rol", comboBox1.Text);
            parametros.add("@ListaFuc", funciones);
            parametros.add("@estado", estado);

            ConexionDB.Procedure("asignarNuevasFuncRol", parametros.get());


            this.ActualizarRoles();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void resetear()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            checkBox1.Checked = false;

            errorProvider1.Clear();
        }
    }
}
