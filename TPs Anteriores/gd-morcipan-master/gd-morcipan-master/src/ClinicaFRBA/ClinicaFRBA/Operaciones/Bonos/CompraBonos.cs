using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.Bonos
{
    public partial class CompraBonos : Form
    {
        private int numeroAfiliado;
        private string planAfiliado;
        private decimal precioTotConsulta;
        private decimal precioTotFarmacia;
        private decimal precioTotal;

        public CompraBonos(int usuarioLogueado)
        {
            InitializeComponent();
            this.numeroAfiliado = ManejadorNegocio.obtenerAfiliadoParaUsuario(usuarioLogueado);
        }

        private void incializarCampos()
        {
            lblDatosAfiliado.Text = String.Empty;
            this.precioTotConsulta = 0;
            this.precioTotFarmacia = 0;
            this.precioTotal = 0;
            if (this.numeroAfiliado != 0)
            {
                txtNroAfiliado.Text = this.numeroAfiliado.ToString();
                txtNroAfiliado.Enabled = false;
                btnValidarAfiliado.PerformClick();
                btnValidarAfiliado.Enabled = false;
            }
        }

        private void btnValidarAfiliado_Click(object sender, EventArgs e)
        {
            string datosAfiliado = string.Empty;
            if (txtNroAfiliado.Text.Length > 0)
            {
                DataTable afiliadosEncontrados = ManejadorNegocio.buscarAfiliados(Convert.ToInt32(txtNroAfiliado.Text), "- 2", "- 2", "- 2", "- 2", -2, "- 2", "- 2");
                if (afiliadosEncontrados.Rows.Count > 0)
                {
                    this.planAfiliado = afiliadosEncontrados.Rows[0].ItemArray[12].ToString();
                    datosAfiliado = "Afiliado: " + afiliadosEncontrados.Rows[0].ItemArray[2].ToString() + ", " + afiliadosEncontrados.Rows[0].ItemArray[1].ToString() + "\n";
                    datosAfiliado += "Documento: " + afiliadosEncontrados.Rows[0].ItemArray[3].ToString() + " " + afiliadosEncontrados.Rows[0].ItemArray[4].ToString() + "\n";
                    datosAfiliado += "Plan: " + this.planAfiliado;
                    txtCantBonosConsulta.Enabled = true;
                    txtCantBonosFarmacia.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontro un afiliado con ese Nro.", "Compra de Bonos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantBonosConsulta.Enabled = false;
                    txtCantBonosFarmacia.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un Nro. de Afiliado para validar!", "Validación de Afiliado!", MessageBoxButtons.OK);
            }
            lblDatosAfiliado.Text = datosAfiliado;
        }

        private void txtNroAfiliado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnValidarAfiliado.PerformClick();
                }
            }
        }

        private void txtCantBonosConsulta_Leave(object sender, EventArgs e)
        {
            if (txtCantBonosConsulta.Text.Length > 0)
            {
                decimal precioBonoConsulta = (int)ManejadorNegocio.obtenerPrecioBonoConsulta(this.planAfiliado);
                int cantidadBonosConsulta = Convert.ToInt32(txtCantBonosConsulta.Text);
                this.precioTotConsulta = (precioBonoConsulta * cantidadBonosConsulta);
                lblTotBonosCon.Text = "Total Bonos Consulta: " + this.precioTotConsulta.ToString();
                actualizarPrecioTotal();
            }
        }

        private void txtCantBonosFarmacia_Leave(object sender, EventArgs e)
        {
            if (txtCantBonosFarmacia.Text.Length > 0)
            {
                decimal precioBonoConsulta = (int)ManejadorNegocio.obtenerPrecioBonoFarmacia(this.planAfiliado);
                int cantidadBonosFarmacia = Convert.ToInt32(txtCantBonosFarmacia.Text);
                this.precioTotFarmacia = (precioBonoConsulta * cantidadBonosFarmacia);
                lblTotBonosFarm.Text = "Total Bonos Farmacia: " + this.precioTotFarmacia.ToString();
                actualizarPrecioTotal();
            }
        }

        private void actualizarPrecioTotal()
        {
            this.precioTotal = this.precioTotConsulta + this.precioTotFarmacia;
            lblTotGral.Text = "Total General: " + this.precioTotal.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarCampos()
        {
            bool res = true;
            res = res && (txtNroAfiliado.Text.Length > 0);
            res = res && (txtCantBonosConsulta.Text.Length > 0);
            res = res && (txtCantBonosFarmacia.Text.Length > 0);
            return res;
        }

        private bool procesarBonosConsulta()
        {
            bool res = true;
            for (int bConsulta = 0; bConsulta < Convert.ToInt32(txtCantBonosConsulta.Text); bConsulta++)
            {
                int resInsercion = ManejadorNegocio.insertarBonoConsulta(Convert.ToInt32(txtNroAfiliado.Text), this.planAfiliado);
                res = res && (resInsercion > 0);
            }
            return res;
        }

        private bool procesarBonosFarmacia()
        {
            bool res = true;
            for (int bFarmacia = 0; bFarmacia < Convert.ToInt32(txtCantBonosFarmacia.Text); bFarmacia++)
            {
                int resInsercion = ManejadorNegocio.insertarBonoFarmacia(Convert.ToInt32(txtNroAfiliado.Text), this.planAfiliado);
                res = res && (resInsercion > 0);
            }
            return res;
        }

        private bool procesarCompra()
        {
            int resInsercion = ManejadorNegocio.insertarCompraTotal(Convert.ToInt32(txtNroAfiliado.Text),
                                                                    Convert.ToInt32(txtCantBonosConsulta.Text),
                                                                    Convert.ToInt32(txtCantBonosFarmacia.Text),
                                                                    this.precioTotal);
            return (resInsercion > 0);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                bool resultado = procesarCompra();
                resultado = resultado && procesarBonosConsulta();
                resultado = resultado && procesarBonosFarmacia();

                if (resultado)
                {
                    MessageBox.Show("Compra y asignacion realizada correctamente!", "Compra de Bonos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error procesando la compra!", "Compra de Bonos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, valide los datos ingresados!", "Compra de Bonos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCantBonosConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCantBonosFarmacia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CompraBonos_Load(object sender, EventArgs e)
        {
            incializarCampos();
        }
    }
}
