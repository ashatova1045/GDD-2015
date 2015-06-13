using System;
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
        public ProlongacionCuentas(DataGridViewCellCollection cuenta)
        {
            InitializeComponent();
            cargarDatos(cuenta);
        }

        private void cargarDatos(DataGridViewCellCollection cuenta)
        {
            txtCuenta.Text = cuenta["Cuenta"].Value.ToString();
            txtEstado.Text = cuenta["Estado"].Value.ToString();
            txtTipo.Text = cuenta["Tipo cuenta"].Value.ToString();
            txtDuracion.Text = cuenta["duracion"].Value.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
