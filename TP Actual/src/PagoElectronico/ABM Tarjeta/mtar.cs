using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;

namespace PagoElectronico.ABM_Tarjeta
{
    public partial class mtar : Form
    {
        public mtar()
        {
            InitializeComponent();

            actualizar();
        }

        public void actualizar()
        {
            SQLParametros parametros = new SQLParametros();
            parametros.add("Id_cliente", Sesion.cliente_id);

            DataTable tarjetas;

            if (ConexionDB.Procedure("ObtenerTarjetasDeCliente", parametros.get(), out tarjetas))
            {
                cbTarjeta.DisplayMember = "finalnumero";
                cbTarjeta.ValueMember = "Id_tarjeta";
                cbTarjeta.DataSource = tarjetas;
                cbTarjeta.Update();

                if (tarjetas.Rows.Count >= 1)
                {
                    btModificar.Enabled = true;
                    btDesasociar.Enabled = true;
                }
                else
                {
                    btModificar.Enabled = false;
                    btDesasociar.Enabled = false;
                }
            }

        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            new AsociarTarjeta(Convert.ToDecimal(cbTarjeta.SelectedValue)).ShowDialog(this);
            actualizar();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void btDesasociar_Click(object sender, EventArgs e)
        {   
            SQLParametros parametros = new SQLParametros();
            parametros.add("@Id_tarjeta",Convert.ToDecimal(cbTarjeta.SelectedValue));

            if (ConexionDB.Procedure("AlterarEstadoTarjeta", parametros.get()))
            {
                MessageBox.Show("Tarjeta desasociada");
                actualizar();
            }
        }

        protected void btAsociar_Click(object sender, EventArgs e)
        {
            new AsociarTarjeta(0).ShowDialog(this);
            actualizar();
        }
    }
}
