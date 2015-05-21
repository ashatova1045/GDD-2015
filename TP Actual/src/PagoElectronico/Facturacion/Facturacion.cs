﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data.SqlClient;

namespace PagoElectronico.Facturacion
{
    public partial class Facturacion : Form
    {
        public Facturacion()
        {
            InitializeComponent();
            string query = "select cu.* from " +
            "HHHH.clientes cli, " +
            "HHHH.cuentas cu Where " +
            Sesion.user_id.ToString() + " = cli.Id_usuario and " +
            "cu.Id_cliente = cli.Id_cliente";

            DataTable cuentasUser;
            cuentasUser = ConexionDB.correrQuery(Sesion.conexion, query);
            listBox1.DataSource = cuentasUser;
            listBox1.DisplayMember = "Id_cuenta";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}