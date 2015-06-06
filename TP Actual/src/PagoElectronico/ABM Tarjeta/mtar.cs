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
            DataTable tarjetas = ConexionDB.correrQuery(Sesion.conexion, "select Id_tarjeta,finalnumero from HHHH.tarjetas t where t.estado = 1 and t.Id_cliente=" + Sesion.cliente_id);
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
            ConexionDB.correrQuery(Sesion.conexion, "update HHHH.tarjetas set estado=0 where id_tarjeta = " + Convert.ToDecimal(cbTarjeta.SelectedValue));
            MessageBox.Show("Tarjeta desasociada");
            actualizar();
        }

        protected void btAsociar_Click(object sender, EventArgs e)
        {
            new AsociarTarjeta(0).ShowDialog(this);
            actualizar();
        }

        private void mtar_Load(object sender, EventArgs e)
        {

        }
    }
}
