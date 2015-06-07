using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PagoElectronico.OperacionesDB.ConexionDB;
using System.Data.SqlClient;

namespace PagoElectronico.ABM_Tarjeta
{
    public partial class AsociarTarjeta : Form
    {
        bool modificacion = false;
        decimal idt;
        public AsociarTarjeta(decimal idtarjeta)
        {
            InitializeComponent();

            DataTable banco;
            SQLParametros parametros = new SQLParametros();
            parametros.add("@FiltMigracion",0);

            if (ConexionDB.Procedure("ObtenerBancos", parametros.get(), out banco))
            {

                dgBanco.DataSource = banco;
                dgBanco.Update();

                if (idtarjeta != 0)
                {
                    modificacion = true;
                    idt = idtarjeta;

                    parametros.Clear();
                    parametros.add("Id_tarjeta", idtarjeta);

                    DataTable tarjetaTabla;

                    if (ConexionDB.Procedure("ObtenerTarjeta", parametros.get(), out tarjetaTabla))
                    {
                        DataRow tarjeta =  tarjetaTabla.Rows[0];
                        foreach (DataGridViewRow r in dgBanco.Rows)
                        {
                            if (Convert.ToDecimal(r.Cells["id"].Value) == Convert.ToDecimal(tarjeta["Id_banco"]))
                            {
                                dgBanco.CurrentCell = dgBanco.Rows[r.Index].Cells[0];
                            }
                        }
                        dtEmision.Value = Convert.ToDateTime(tarjeta["Fecha_emision"]);
                        dtVencimiento.Value = Convert.ToDateTime(tarjeta["Fecha_vencimiento"]);
                    }
                }
            }
        }

        private void dtEmision_ValueChanged(object sender, EventArgs e)
        {
            dtVencimiento.MinDate = dtEmision.Value;
        }

        private void dtVencimiento_ValueChanged(object sender, EventArgs e)
        {
            dtEmision.MaxDate= dtVencimiento.Value;
        }

        private void btAsociar_Click(object sender, EventArgs e)
        {
            if (!ValidadorHelper.validar16Numeros(txttarjeta.Text))
            {
                MessageBox.Show("El numero de tarjeta debe contener 16 numeros");
                return;
            }
            if (!ValidadorHelper.validarSoloNumeros(txtCodigo.Text))
            {
                MessageBox.Show("El codigo debe contener 3 numeros");
                return;
            }
            SQLParametros parametros = new SQLParametros();

            parametros.add("@idcliente",Sesion.cliente_id);
            parametros.add("@idtarjeta", idt);
            parametros.add("@tarjeta", txttarjeta.Text);
            parametros.add("@emision", dtEmision.Value);
            parametros.add("@vencimiento", dtVencimiento.Value);
            parametros.add("@codigo", txtCodigo.Text);
            parametros.add("@modificacion", (modificacion?1:0));
            parametros.add("@banco",Convert.ToDecimal(dgBanco.SelectedRows[0].Cells["id"].Value));

            if(ConexionDB.Procedure("asociarTarjeta", parametros.get()))
            {
                MessageBox.Show("Tarjeta "+ (modificacion?"modificada":"agregada") +" correctamente");
                btVolver.PerformClick();
            }
            
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
