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

namespace PagoElectronico.Retiros
{
    public partial class RetiroEfectivo_FRM : Form
    {
        readonly DataTable monedas = ConexionDB.correrQuery(Sesion.conexion, "SELECT DISTINCT id_moneda,descripcion FROM HHHH.monedas"); //Traigo todas las monedas
        readonly DataTable cuentas = ConexionDB.correrQuery(Sesion.conexion, "SELECT DISTINCT id_cuenta,estado,saldo FROM HHHH.cuentas WHERE Id_cliente =" + Sesion.cliente_id);
        readonly DataTable bancos = ConexionDB.correrQuery(Sesion.conexion, "SELECT DISTINCT id_banco,descripcion FROM HHHH.bancos where descripcion <> 'Banco migracion'"); //Traigo todos los bancos
        DataTable cliente = ConexionDB.correrQuery(Sesion.conexion, "SELECT DISTINCT Nombre, Apellido, Nro_Documento FROM HHHH.clientes WHERE Id_cliente =" + Sesion.cliente_id);


        public RetiroEfectivo_FRM()
        {
            InitializeComponent();

            //Se carga el CB "Monedas"

            Moneda_CB.DisplayMember = "descripcion";
            Moneda_CB.ValueMember = "id_moneda";


            //Se carga el CB "Cuentas"

            Cuenta_CB.DisplayMember = "Id_cuenta";
            Cuenta_CB.ValueMember = "id_cuenta";

            //Se carga el CB "Bancos"

            Banco_CB.DisplayMember = "Descripcion";
            Banco_CB.ValueMember = "Id_banco";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        
        private void Importe_NUD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RealizarCheque_BTN_Click(object sender, EventArgs e)
        {
            
            if (Validaciones_FN())
            {

                //Guardar el contenido de los combo box en variables

                List<SqlParameter> listaDeParametros = new List<SqlParameter>();
                listaDeParametros.Add(new SqlParameter("@cuenta", Cuenta_CB.SelectedValue));
                listaDeParametros.Add(new SqlParameter("@doc", NoDoc_TXT.Text));
                listaDeParametros.Add(new SqlParameter("@importe", Importe_NUD.Value));
                listaDeParametros.Add(new SqlParameter("@moneda", Moneda_CB.SelectedValue));
                listaDeParametros.Add(new SqlParameter("@fechaRetiro", Sesion.fecha));
                listaDeParametros.Add(new SqlParameter("@destinatarioNombre", cliente.Rows[0]["Nombre"].ToString()));
                listaDeParametros.Add(new SqlParameter("@destinatarioApellido", cliente.Rows[0]["Apellido"].ToString()));
                listaDeParametros.Add(new SqlParameter("@banco", Banco_CB.SelectedValue));

                //Llamo al procedimiento que actualiza la BD
                try
                {
                    ConexionDB.invocarStoreProcedure(Sesion.conexion, "retiro", listaDeParametros);
                    MessageBox.Show("El cheque se ha generado correctamente por la suma de" + " " + Importe_NUD.Value + " " + Moneda_CB.Text);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Limpio los campos para la proxima operacion

                Cuenta_CB.SelectedIndex = -1;
                NoDoc_TXT.Text = "";
                Importe_NUD.Value = 0;
                Moneda_CB.SelectedIndex = -1;
                Banco_CB.SelectedIndex = -1;
            }

            else
            {
                MessageBox.Show("Los datos ingresados no son válidos");
            }

        }

        private void NoDoc_TXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void Moneda_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Moneda_CB_Click(object sender, EventArgs e)
        {
            Moneda_CB.DataSource = monedas;
            Moneda_CB.Update();
        }

        private void Cuenta_CB_Click(object sender, EventArgs e)
        {
            Cuenta_CB.DataSource = cuentas;
            Cuenta_CB.Update();
        }

        private void Cancelar_BTN_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Banco_CB_Click(object sender, EventArgs e)
        {
            Banco_CB.DataSource = bancos;
            Banco_CB.Update();
        }

        private bool Validaciones_FN()
        {
            bool correcto = true;
            errorProvider1.Clear();

            if (Cuenta_CB.Text == "")
            {
                correcto = false;
                errorProvider1.SetError(Cuenta_CB, "Seleccione una cuenta");
            }

            if ((Cuenta_CB.FindString(Cuenta_CB.Text)) == -1)//La cuenta debe ser del cliente
            {
                correcto = false;
                errorProvider1.SetError(Cuenta_CB, "La cuenta ingresada no es válida");
            }
            
            if ((NoDoc_TXT.Text != cliente.Rows[0]["Nro_Documento"].ToString()))//El documento debe ser el del cliente
            {
                correcto = false;
                errorProvider1.SetError(NoDoc_TXT, "El Nro de Documento no es válido");
            }

            if (Importe_NUD.Value <= 0)//El importe debe ser mayor a cero
            {
                correcto = false;
                errorProvider1.SetError(Importe_NUD, "El importe debe ser mayor a cero");
            }

            if ((Moneda_CB.Text == ""))//Debe seleccionarse una moneda
            {
                correcto = false;
                errorProvider1.SetError(Moneda_CB, "Seleccione una moneda");
            }

            if ((Banco_CB.Text == ""))//Debe seleccionarse un banco
            {
                correcto = false;
                errorProvider1.SetError(Banco_CB, "Seleccione un banco");
            }

            if (( Cuenta_CB.SelectedIndex != -1) && (cuentas.Rows[Cuenta_CB.SelectedIndex]["estado"].ToString()) != "H")//La cuenta debe estar habilitada
            {
                correcto = false;
                errorProvider1.SetError(Cuenta_CB, "La cuenta no se encuentra habiitada");
            }

            if ((Cuenta_CB.SelectedIndex != -1) &&(decimal.Parse((cuentas.Rows[Cuenta_CB.SelectedIndex]["saldo"]).ToString()) <= 0))//La cuenta debe tener saldo
            {
                correcto = false;
                errorProvider1.SetError(Cuenta_CB, "La cuenta no tiene saldo");
            }

            if ((Cuenta_CB.SelectedIndex != -1) && (decimal.Parse((cuentas.Rows[Cuenta_CB.SelectedIndex]["saldo"]).ToString())) < Importe_NUD.Value)//El importe debe ser menor al saldo de la cuenta
            {
                correcto = false;
                errorProvider1.SetError(Importe_NUD, "La cuenta no tiene suficiente saldo");
            }

            if (Moneda_CB.Text != "USD")//El importe debe ser en dólares
            {
                correcto = false;
                errorProvider1.SetError(Moneda_CB, "El importe debe ser en USD"); 
            }

            return correcto;
        }

        private void RetiroEfectivo_FRM_Load(object sender, EventArgs e)
        {

        }
    }
}
