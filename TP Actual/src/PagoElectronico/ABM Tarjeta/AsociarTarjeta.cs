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
        public AsociarTarjeta()
        {
            InitializeComponent();

            DataTable banco = ConexionDB.correrQuery(Sesion.conexion, "select distinct Id_banco,b.Descripcion,p.Descripcion pais,Localidad,Calle,Altura from HHHH.bancos b left join HHHH.paises p on p.Codigo=Id_pais where Id_banco != 1");
            dgBancos.AutoGenerateColumns = false;
            dgBancos.DataSource = banco;
            dgBancos.Update();
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
            if (!ValidadorHelper.validarSoloNumeros(txttarjeta.Text))
            {
                MessageBox.Show("El numero de tarjeta debe contener 16 numeros");
                return;
            }
            List<SqlParameter> listaP = new List<SqlParameter>();
            listaP.Add(new SqlParameter("@idusuario",Sesion.user_id));
            listaP.Add(new SqlParameter("@tarjeta", txttarjeta.Text));
            listaP.Add(new SqlParameter("@emision", dtEmision.Value));
            listaP.Add(new SqlParameter("@vencimiento", dtVencimiento.Value));
            listaP.Add(new SqlParameter("@codigo", txtCodigo.Text));
            listaP.Add(new SqlParameter("@banco",Convert.ToDecimal(dgBancos.SelectedRows[0].Cells["id"].Value)));
            try
            {
                ConexionDB.invocarStoreProcedure(Sesion.conexion, "asociarTarjeta", listaP);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
