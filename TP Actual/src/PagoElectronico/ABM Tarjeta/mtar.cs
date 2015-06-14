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
        private bool salir = true;

        private decimal ID_cliente;

        public mtar()
        {
            InitializeComponent();

            ID_cliente = Sesion.cliente_id;

            actualizar();

        }

        public mtar(decimal id_cliente)
        {
            InitializeComponent();

            ID_cliente = id_cliente;

            actualizar();

        }

        public void actualizar()
        {
            SQLParametros parametros = new SQLParametros();
            parametros.add("Id_cliente", ID_cliente);

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
            new AsociarTarjeta(Convert.ToDecimal(cbTarjeta.SelectedValue),ID_cliente).ShowDialog(this);
            actualizar();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            salir = false;
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
            new AsociarTarjeta(0,ID_cliente).ShowDialog(this);
            actualizar();
        }

        private void mtar_Load(object sender, EventArgs e)
        {

        }

        private void mtar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir)
            {
                Application.Exit();
            }
        }
    }
}
