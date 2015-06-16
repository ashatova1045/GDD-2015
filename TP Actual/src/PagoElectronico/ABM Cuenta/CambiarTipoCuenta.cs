﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class CambiarTipoCuenta : Form
    {
        private bool salir = true;
        DataGridViewCellCollection cuentaG;
        private DataTable tipoCuentas;
        public CambiarTipoCuenta(DataGridViewCellCollection cuenta)
        {
            InitializeComponent();
            cuentaG = cuenta;
            cargarDatos(cuenta);
        }

        private void cargarDatos(DataGridViewCellCollection cuenta)
        {
            SQLParametros param = new SQLParametros();
            param.add("@cuenta", cuenta["Tipo cuenta"].Value.ToString());
            DataTable infoCuenta;
            ConexionDB.Procedure("InformacionTipoCuenta", param.get(), out infoCuenta);

            txtCuenta.Text = cuenta["Cuenta"].Value.ToString();
            txtEstadoCuenta.Text = cuenta["Estado"].Value.ToString();
            txtTipoCuentaActual.Text = cuenta["Tipo cuenta"].Value.ToString();
            //txtDuracion.Text = infoCuenta.Rows[0]["duracion"].ToString();

            param = new SQLParametros();
            param.add("@tipoCuenta", cuenta["Tipo cuenta"].Value.ToString());            
            ConexionDB.Procedure("ObtenerTipoCuentasDistintas", param.get(), out tipoCuentas);

            
            cbNuevoTipoCuenta.DisplayMember = "Descripcion";
            cbNuevoTipoCuenta.ValueMember = "Id_tipo_cuenta";
            //cbNuevoTipoCuenta.SelectedIndex = -1;
            cbNuevoTipoCuenta.Text = "";

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void bnVolver_Click(object sender, EventArgs e)
        {
            salir = false;
            Owner.Show();
            this.Close();
        }

        private void CambiarTipoCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }

        private void bnCalcularPrecio_Click(object sender, EventArgs e)
        {
            txtPrecioTotal.Text= (decimal.Parse(txtCosto.Text)*(txtSuscripciones.Value)).ToString();
        }

        private void cbNuevoTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNuevoTipoCuenta.Text != "")
            {
                DataTable infoTipoCuenta;
               SQLParametros parametro = new SQLParametros();
                parametro.add("@cuenta", cbNuevoTipoCuenta.Text);
                ConexionDB.Procedure("InformacionTipoCuenta", parametro.get(), out infoTipoCuenta);
                txtCosto.Text = infoTipoCuenta.Rows[0]["costo_cuenta"].ToString();
                txtDuracion.Text = infoTipoCuenta.Rows[0]["duracion"].ToString();

            }
        }

        private void cbNuevoTipoCuenta_Click(object sender, EventArgs e)
        {
            cbNuevoTipoCuenta.DataSource = tipoCuentas;
            cbNuevoTipoCuenta.Update();
        }

        private void bnCambiarTipoCuenta_Click(object sender, EventArgs e)
        {
            SQLParametros parametros = new SQLParametros();

            parametros.add("@Id_cuenta", cuentaG["Cuenta"].Value.ToString());
            parametros.add("@Cant_suscripcones", Convert.ToInt32(txtSuscripciones.Value));
            parametros.add("@fechaActual", Sesion.fecha);
            SQLParametros paramAct = new SQLParametros();
            paramAct.add("@cuenta",cuentaG["Cuenta"].Value.ToString());
            paramAct.add("@tipocuenta",cbNuevoTipoCuenta.SelectedValue);
            if ((ConexionDB.Procedure("prolongarCuenta", parametros.get())) && (ConexionDB.Procedure("cambiarTipoCuenta", paramAct.get())))
            {
                salir = false;
                Owner.Show();
                this.Close();
            }
        }
    }
}
