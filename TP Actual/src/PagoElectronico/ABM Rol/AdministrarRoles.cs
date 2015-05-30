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
            rolesActuales = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.roles");
            comboBox1.DataSource = rolesActuales;
            comboBox1.DisplayMember = "Nombre_rol";
            comboBox1.ValueMember = "Id_rol";
            comboBox1.Text = "Elija un Rol";
            comboBox1.Update();

        }

        public AdministrarRoles()
        {
            InitializeComponent();

            this.ActualizarRoles();
            DataTable funcionalidades = ConexionDB.correrQuery(Sesion.conexion, "select * from HHHH.funcionalidades");
            foreach (DataRow row in funcionalidades.Rows)
            {
               // foreach (DataColumn item in funcionalidades.Columns)
                //{
                 //   if (item.ToString() == "Descripcion")
                        checkedListBox1.Items.Add(row["Descripcion"].ToString());
                 //  }
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (DataRow rol in rolesActuales.Rows)
            {
                if(rol["Nombre_rol"].ToString() == comboBox1.Text)
                {
                    if (rol["Estado"].ToString() == "A")
                    {
                        checkBox1.Checked = true;
                        checkBox1.Text = "Habilitado";
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        checkBox1.Text = "Deshabilitado";
                    }
                }
            
            }
            button1.Enabled = false;

            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@nombre", comboBox1.Text));
            DataTable funcsActivas = ConexionDB.invocarStoreProcedure(Sesion.conexion, "funcionesdelrol", listaDeParametros);

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            foreach (DataRow funcAct in funcsActivas.Rows)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(funcAct["Descripcion"].ToString()), true);
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
            this.ActualizarRoles();
         }

        private void button1_Click(object sender, EventArgs e)
        {
            string funciones = "";
            string estado = "N";

            if (checkBox1.Checked)
                estado = "A"; else estado = "N";

            button1.Enabled = false;
           
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                funciones = funciones + "," + itemChecked.ToString();
            }

            List<SqlParameter> listaDeParametros = new List<SqlParameter>();
            listaDeParametros.Add(new SqlParameter("@Rol", comboBox1.Text));
            listaDeParametros.Add(new SqlParameter("@ListaFuc", funciones));
            listaDeParametros.Add(new SqlParameter("@estado", estado));
            ConexionDB.invocarStoreProcedure(Sesion.conexion, "asignarNuevasFuncRol", listaDeParametros);

            this.ActualizarRoles();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void AdministrarRoles_Load(object sender, EventArgs e)
        {

        }
    }
}
