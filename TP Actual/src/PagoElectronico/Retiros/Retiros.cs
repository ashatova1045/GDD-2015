﻿using System;
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
        private bool salir = true;

        readonly DataTable monedas;
        readonly DataTable cuentas;
        readonly DataTable bancos;
        DataTable cliente; 



        public RetiroEfectivo_FRM()
        {
            InitializeComponent();
            
            //Se carga el CB "Monedas"
            
            if (ConexionDB.Procedure("ObtenerMonedas", null, out monedas))
            {
                Moneda_CB.DisplayMember = "descripcion";
                Moneda_CB.ValueMember = "id_moneda";
            }


            //Se carga el CB "Cuentas"

            SQLParametros parametros = new SQLParametros();
            parametros.add("@Id_cliente", Sesion.cliente_id);
            
            try
            {
                
                if (ConexionDB.Procedure("ObtenerCuentasDeCliente", parametros.get(), out cuentas))
                {
                    cuentas = cuentas.Select("Estado <> 'C'").CopyToDataTable();
                    Cuenta_CB.DisplayMember = "Id_cuenta";
                    Cuenta_CB.ValueMember = "id_cuenta";
                }

            }
            catch(InvalidOperationException) { }

            //Se carga el CB "Bancos"

            parametros.Clear();
            parametros.add("@FiltMigracion", 1);
            if (ConexionDB.Procedure("ObtenerBancos", parametros.get(), out bancos))
            {
                Banco_CB.DisplayMember = "Descripcion";
                Banco_CB.ValueMember = "Id_banco";
            }

            // Carga tabla cliente

            parametros.Clear();
            parametros.add("@Id_cliente", Sesion.cliente_id);
            ConexionDB.Procedure("ObtenerCliente", parametros.get(), out cliente);
        }

       

        private void RealizarCheque_BTN_Click(object sender, EventArgs e)
        {
            
            if (Validaciones_FN())
            {

                //Guardar el contenido de los combo box en variables

                SQLParametros parametros = new SQLParametros();
                parametros.add("@cuenta", Cuenta_CB.SelectedValue);
                parametros.add("@doc", NoDoc_TXT.Text);
                parametros.add("@importe", Importe_NUD.Value);
                parametros.add("@moneda", Moneda_CB.SelectedValue);
                parametros.add("@fechaRetiro", Sesion.fecha);
                parametros.add("@destinatarioNombre", cliente.Rows[0]["Nombre"].ToString());
                parametros.add("@destinatarioApellido", cliente.Rows[0]["Apellido"].ToString());
                parametros.add("@banco", Banco_CB.SelectedValue);

                //Llamo al procedimiento que actualiza la BD
                if(ConexionDB.Procedure("retiro",parametros.get()))
                {
                    MessageBox.Show("El cheque se ha generado correctamente por la suma de" + " " + Importe_NUD.Value + " " + Moneda_CB.Text);
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
            salir = false;
            Owner.Show();
            this.Close();
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
                errorProvider1.SetError(Cuenta_CB, "La cuenta no se encuentra habilitada");
            }

            if ((Cuenta_CB.SelectedIndex != -1) &&(decimal.Parse((cuentas.Rows[Cuenta_CB.SelectedIndex]["saldo"]).ToString()) <= 0))//La cuenta debe tener saldo
            {
                correcto = false;
                errorProvider1.SetError(Cuenta_CB, "La cuenta no tiene saldo");
            }

            if (Moneda_CB.Text != "USD")//El importe debe ser en dólares
            {
                correcto = false;
                errorProvider1.SetError(Moneda_CB, "El importe debe ser en USD");
            }
            

            return correcto;
        }

        private void RetiroEfectivo_FRM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }

        private void Cuenta_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
