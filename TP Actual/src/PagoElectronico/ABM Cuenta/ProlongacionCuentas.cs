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

            DataTable tipoCuentas;
            ConexionDB.Procedure("ObtenerTipoCuentas", null, out tipoCuentas);
            cbTipo.DataSource = tipoCuentas;
            cbTipo.DisplayMember = "Descripcion";
            cbTipo.ValueMember = "Id_tipo_cuenta";

            if (txtEstado.Text != "I")
            {
                cbTipo.Enabled = false;
                cbTipo.Text = "Inhabilitado";
    //            MessageBox.Show("Solo puede cambiar su tipo de cuenta cuando esta inhabilitada. Espere a que se acabe su tiempo con esta cuenta.");
            }
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

    }
}
