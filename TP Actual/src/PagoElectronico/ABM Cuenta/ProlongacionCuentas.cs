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
    public partial class ProlongacionCuentas : Form
    {
        DataGridViewCellCollection cuentaG;
        public ProlongacionCuentas(DataGridViewCellCollection cuenta)
        {
            InitializeComponent();
            cargarDatos(cuenta);
            cuentaG = cuenta;
        }

        private void cargarDatos(DataGridViewCellCollection cuenta)
        {
            txtCuenta.Text = cuenta["Cuenta"].Value.ToString();
            txtEstado.Text = cuenta["Estado"].Value.ToString();
            txtTipo.Text = cuenta["Tipo cuenta"].Value.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void btnProlongar_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            SQLParametros param = new SQLParametros();
            param.add("@cantPeriodos", nuuSuscripciones.Value);
            param.add("@cuenta", txtCuenta.Text);
            param.add("@tipocuenta", cuentaG["Tipo Id_moneda"].Value.ToString());
            DataTable tipoCuentas;
            ConexionDB.Procedure("ObtenerTipoCuentas", param.get(), out tipoCuentas);
        }
    }
}