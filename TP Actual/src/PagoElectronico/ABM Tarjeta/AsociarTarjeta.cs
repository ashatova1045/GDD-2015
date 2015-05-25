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
        public AsociarTarjeta(decimal idtarjeta)
        {
            InitializeComponent();

            DataTable banco = ConexionDB.correrQuery(Sesion.conexion, "select distinct Id_banco,b.Descripcion ,b.Calle,b.altura,b.localidad, p.Descripcion des from HHHH.bancos b left join HHHH.paises p on p.Codigo=Id_pais");
            dgBanco.DataSource = banco;
            dgBanco.Update();

            if (idtarjeta != 0)
            {
                DataRow tarjeta = ConexionDB.correrQuery(Sesion.conexion, "select Id_banco,Fecha_emision,Fecha_vencimiento from hhhh.tarjetas where id_tarjeta =" + idtarjeta).Rows[0];
                foreach (DataGridViewRow r in dgBanco.Rows)
                {
                    if (Convert.ToDecimal(r.Cells["id"].Value)==Convert.ToDecimal(tarjeta["Id_banco"]))
                    {
                        dgBanco.CurrentCell = dgBanco.Rows[r.Index].Cells[0];
                    }
                }
                dtEmision.Value=Convert.ToDateTime(tarjeta["Fecha_emision"]);
                dtVencimiento.Value = Convert.ToDateTime(tarjeta["Fecha_vencimiento"]);
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
            List<SqlParameter> listaP = new List<SqlParameter>();
            listaP.Add(new SqlParameter("@idusuario",Sesion.user_id));
            listaP.Add(new SqlParameter("@tarjeta", txttarjeta.Text));
            listaP.Add(new SqlParameter("@emision", dtEmision.Value));
            listaP.Add(new SqlParameter("@vencimiento", dtVencimiento.Value));
            listaP.Add(new SqlParameter("@codigo", txtCodigo.Text));
            listaP.Add(new SqlParameter("@banco",Convert.ToDecimal(dgBanco.SelectedRows[0].Cells["id"].Value)));
            try
            {
                ConexionDB.invocarStoreProcedure(Sesion.conexion, "asociarTarjeta", listaP);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Tarjeta agregada correctamente");
            btVolver.PerformClick();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
