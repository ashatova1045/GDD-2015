using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ModificarClientes : Form
    {

        Cliente clienteSeleccionado;


        public ModificarClientes()
        {
            InitializeComponent();

       
        }

 

        public void cargarDatosClienteSeleccionado(Cliente cliente)
        {
            
            clienteSeleccionado = cliente;
            ValorIDLabel.Text=Convert.ToString(cliente.id);
            TipoPasaportetextBox.Text = Convert.ToString(cliente.tipoPasaporte);
            
            NroPasaportetextBox.Text = Convert.ToString(cliente.pasaporteNumero);
            MailTextBox.Text = Convert.ToString(cliente.mail);
            ApellidotextBox.Text = Convert.ToString(cliente.apellido);
            NombreTextBox.Text = Convert.ToString(cliente.nombre);
            FechaNacdateTimePicker1.Value= cliente.fechaNacimiento;
            CalleDomtextBox.Text = Convert.ToString(cliente.calleDomicilio);
            NroCalletextBox.Text = Convert.ToString(cliente.numeroCalle);
            PisoTextBox.Text = Convert.ToString(cliente.piso);
            DeptotextBox.Text = Convert.ToString(cliente.depto);
            NacionalidadtextBox.Text = Convert.ToString(cliente.nacionalidad);
            CiudadtextBox.Text = Convert.ToString(cliente.ciudadResidencia);
            PaisResidenciaTextBox.Text = Convert.ToString(cliente.paisResidencia);
            TarjetaCreditoTextBox.Text = Convert.ToString(cliente.tarjetaDeCredito);
           
            ClienteHabilitadocheckBox.Checked = Convert.ToBoolean(cliente.habilitado);


        }


 

        private void ClienteHabilitadocheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ClienteHabilitadocheckBox.Checked)
            {
                ClienteHabilitadocheckBox.Text = "Habilitado";
            }
            else
            {
                ClienteHabilitadocheckBox.Text="Ihabilitado";
            }
        }

        private void ConfirmarCambiosBoton_Click_1(object sender, EventArgs e)
        {
            Cliente unCliente = new Cliente();
            unCliente.id = ValorIDLabel.Text;
            unCliente.tipoPasaporte = TipoPasaportetextBox.Text;
            unCliente.pasaporteNumero = NroPasaportetextBox.Text;
            unCliente.apellido = ApellidotextBox.Text;
            unCliente.nombre = NombreTextBox.Text;
            unCliente.mail = MailTextBox.Text;
            unCliente.fechaNacimiento = FechaNacdateTimePicker1.Value;
            unCliente.nacionalidad = NacionalidadtextBox.Text;
            unCliente.paisResidencia = PaisResidenciaTextBox.Text;
            unCliente.ciudadResidencia = CiudadtextBox.Text;
            unCliente.calleDomicilio = CalleDomtextBox.Text;
            unCliente.numeroCalle = NroCalletextBox.Text;
            unCliente.depto = DeptotextBox.Text;
            unCliente.piso = PisoTextBox.Text;
            unCliente.habilitado = ClienteHabilitadocheckBox.Checked;
            unCliente.tarjetaDeCredito = clienteSeleccionado.tarjetaDeCredito;
            GestorDeSistema.modificarCliente(unCliente);


            
            Owner.Show();
            this.Hide();
        }

        private void VolverBoton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }
    }
}