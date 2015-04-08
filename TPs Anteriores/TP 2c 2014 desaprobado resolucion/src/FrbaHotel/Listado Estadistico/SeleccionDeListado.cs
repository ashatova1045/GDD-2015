using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.OperacionesDB.ModeloSistema;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class SeleccionDeListado : Form
    {
        public SeleccionDeListado()
        {
            InitializeComponent();
            listado.Columns.Clear();
            listado.AutoGenerateColumns = false;
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void mostrar_Click(object sender, EventArgs e)
        {
            listado.Columns.Clear();
            switch (eleccion.SelectedIndex) 
            {
                case 0:
                case 1:
                case 2:
                    DataGridViewColumn h = new DataGridViewColumn();
                    h.HeaderText = "Nombre del Hotel";
                    h.Name = "Nombre del Hotel";
                    h.DataPropertyName = "Hotel_Nombre";
                    DataGridViewCell cellh = new DataGridViewTextBoxCell();
                    h.CellTemplate = cellh;
                    listado.Columns.Add(h);
                    break;
                case 3:
                    DataGridViewColumn ho = new DataGridViewColumn();
                    ho.HeaderText = "Nombre del Hotel";
                    ho.Name= "Nombre del Hotel";
                    ho.DataPropertyName = "Hotel_Nombre";
                    DataGridViewCell cellho = new DataGridViewTextBoxCell();
                    ho.CellTemplate = cellho;
                    listado.Columns.Add(ho);
                    DataGridViewColumn ha = new DataGridViewColumn();
                    ha.HeaderText = "Numero de la Habitacion";
                    ha.Name = "Numero de la Habitacion";
                    ha.DataPropertyName = "Habitacion_Numero";
                    DataGridViewCell cellha = new DataGridViewTextBoxCell();
                    ha.CellTemplate = cellha;
                    listado.Columns.Add(ha);
                    break;
                case 4:
                    DataGridViewColumn tp = new DataGridViewColumn();
                    tp.HeaderText = "Tipo de Pasaporte";
                    tp.Name = "Tipo de Pasaporte";
                    tp.DataPropertyName = "Pasaporte_Tipo_Descripcion";
                    DataGridViewCell celltp = new DataGridViewTextBoxCell();
                    tp.CellTemplate = celltp;
                    listado.Columns.Add(tp);
                    DataGridViewColumn cn = new DataGridViewColumn();
                    cn.HeaderText = "Numero de pasaporte";
                    cn.Name = "Numero de pasaporte";
                    cn.DataPropertyName = "Cliente_Pasaporte_Numero";
                    DataGridViewCell cellcn = new DataGridViewTextBoxCell();
                    cn.CellTemplate = cellcn;
                    listado.Columns.Add(cn);
                    DataGridViewColumn cm = new DataGridViewColumn();
                    cm.HeaderText = "Mail del cliente";
                    cm.Name = "Mail del cliente";
                    cm.DataPropertyName = "Cliente_Mail";
                    DataGridViewCell cellcm = new DataGridViewTextBoxCell();
                    cm.CellTemplate = cellcm;
                    listado.Columns.Add(cm);
                    break;
            }
            listado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            listado.DataSource= GestorDeSistema.listar(eleccion.SelectedIndex, ano.Value, trimestre.Value);
            
        }
    }
}
