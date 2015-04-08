using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClinicaFRBA.Utils;

namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    public partial class GenerarReceta : Form
    {
        DataTable dataTMedicamentos = new DataTable("Tabla Medicamentos");
        DataTable dataTBonos = new DataTable("Tabla Bonos");
        int cantBonos = 0;
        float cantMedicamentos = 0;
        private int id_consulta = -2;

        public GenerarReceta(int consulta_id)
        {
            InitializeComponent();

            lblIdMed.Text = "-2";
            id_consulta = consulta_id;
            List<String> cantidades = new List<String>();
            cantidades.Add("1(UNO)");
            cantidades.Add("2(DOS)");
            cantidades.Add("3(TRES)");
            cBoxCantidad.DataSource = cantidades;
            cBoxCantidad.Update();
            dataTMedicamentos.Columns.Add("ID");
            dataTMedicamentos.Columns.Add("Medicamento");
            dataTMedicamentos.Columns.Add("Cantidad");
            dataTMedicamentos.Columns.Add("En letras");
            dataTBonos.Columns.Add("Bono Numero");
        }

        private bool verificarDatosMedicamento()
        {
            string error = "Verifique los siguientes errores.\n";
            bool valido = true;
            if (!noSeRepiteMedicamento())
            {
                error = error + "No se puede ingresar otro medicamento igual.\n";
                valido = false;
            }
            if (tBoxMedicamento.Text == string.Empty)
            {
                error = error + "Ingrese algun medicamento.\n";
                valido = false;
            }
            if (!valido)
                MessageBox.Show(error);
            return valido;
        }

        private bool noSeRepiteMedicamento()
        {
            bool valido = true;
            for (int i = 0; i < cantMedicamentos; i++)
            {
                if (dtMedicamentos.Rows[i].Cells["Medicamento"].Value.ToString() == tBoxMedicamento.Text)
                {
                    valido = false;
                }
            }
            return valido;
        }

        private void btnAgregarBono_Click(object sender, EventArgs e)
        {
            if ( cantBonos * 5 == cantMedicamentos)
            {
                if (noSeRepiteBono())
                {
                    if (tBoxNbono.Text != string.Empty)
                    {
                        if (ManejadorNegocio.verificarBonoFarmacia(id_consulta,Convert.ToInt32(tBoxNbono.Text)) == 1)
                        {
                            //AGREGAR A LA TABLA BONOS
                            dataTBonos.Rows.Add(tBoxNbono.Text);
                            dtBonos.DataSource = dataTBonos;
                            dtBonos.Update();
                            MessageBox.Show("Bono confirmado");
                            cantBonos++;
                        }
                        else
                        {
                            MessageBox.Show("Bono vencido o ya utilizado");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bono Repetido");
                }

            }
            else
            {
                MessageBox.Show("Minimo 5(Cinco) medicamentos por Bono Farmacia");
            }
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            if (cantBonos * 5 > cantMedicamentos )
            {
                if (verificarDatosMedicamento())
                {
                    //AGREGAR A TABLA MEDICAMENTOS
                    cantMedicamentos++;
                    string enLetras = "Cero";
                    int cantidad = cBoxCantidad.SelectedIndex+1;
                    switch(cBoxCantidad.SelectedIndex)
                    {
                        case 0:
                            enLetras = "Uno";
                            break;
                        case 1:
                            enLetras = "Dos";
                            break;
                        case 2:
                            enLetras = "Tres";
                            break;
                        default:
                            break;
                    }
                    dataTMedicamentos.Rows.Add(lblIdMed.Text,tBoxMedicamento.Text, cBoxCantidad.SelectedIndex+1, enLetras);
                    dtMedicamentos.DataSource = dataTMedicamentos;
                    dtMedicamentos.Update();
                }
            }
            else
            {
                    MessageBox.Show("Debe ingresar un nuevo bono para seguir agregando medicamentos");
            }
        }

        private bool noSeRepiteBono()
        {
            bool valido = true;
            for(int i=0; i < cantBonos; i++)
            {
                if (Convert.ToInt32(dtBonos.Rows[i].Cells["Bono Numero"].Value.ToString()) == Convert.ToInt32(tBoxNbono.Text))
                {
                    valido = false;
                }
            }
            return valido;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cantBonos > 0 && cantMedicamentos > 0 )
            {
                int medicamentosRegistrados = 0;
                int receta_id = ManejadorNegocio.GenerarReceta(id_consulta);   
                for (int i = 0; i < cantBonos; i++)
                {
                    if (dtMedicamentos.Rows.Count >= 5)
                    {
                        ManejadorNegocio.AsociarBonoConMedicamentos(receta_id,id_consulta, Convert.ToInt32(dtBonos.Rows[i].Cells["Bono Numero"].Value),
                                        Convert.ToInt32(dtMedicamentos.Rows[0].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[0].Cells["Cantidad"].Value),
                                        Convert.ToInt32(dtMedicamentos.Rows[1].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[1].Cells["Cantidad"].Value),
                                        Convert.ToInt32(dtMedicamentos.Rows[2].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[2].Cells["Cantidad"].Value),
                                        Convert.ToInt32(dtMedicamentos.Rows[3].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[3].Cells["Cantidad"].Value),
                                        Convert.ToInt32(dtMedicamentos.Rows[4].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[4].Cells["Cantidad"].Value));
                        dtMedicamentos.Rows.RemoveAt(4);
                        dtMedicamentos.Rows.RemoveAt(3);
                        dtMedicamentos.Rows.RemoveAt(2); // BORRO MEDICAMENTOS DE LA TABLA
                        dtMedicamentos.Rows.RemoveAt(1);
                        dtMedicamentos.Rows.RemoveAt(0);
                        medicamentosRegistrados = medicamentosRegistrados + 5;
                    }
                    else
                    {
                        switch (Convert.ToInt32(cantMedicamentos) - medicamentosRegistrados)
                        {
                            case 1:
                                ManejadorNegocio.AsociarBonoConMedicamentos(receta_id,id_consulta, Convert.ToInt32(dtBonos.Rows[i].Cells["Bono Numero"].Value.ToString()), Convert.ToInt32(dtMedicamentos.Rows[0].Cells["ID"].Value.ToString()), Convert.ToInt32(dtMedicamentos.Rows[0].Cells["Cantidad"].Value.ToString()), 0, 0, 0, 0, 0, 0, 0, 0);
                                break;
                            case 2:
                                ManejadorNegocio.AsociarBonoConMedicamentos(receta_id,id_consulta, Convert.ToInt32(dtBonos.Rows[i].Cells["Bono Numero"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[0].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[0].Cells["Cantidad"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[1].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[1].Cells["Cantidad"].Value), 0, 0, 0, 0, 0, 0);
                                break;
                            case 3:
                                ManejadorNegocio.AsociarBonoConMedicamentos(receta_id,id_consulta, Convert.ToInt32(dtBonos.Rows[i].Cells["Bono Numero"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[0].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[0].Cells["Cantidad"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[1].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[1].Cells["Cantidad"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[2].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[2].Cells["Cantidad"].Value), 0, 0, 0, 0);
                                break;
                            case 4:
                                ManejadorNegocio.AsociarBonoConMedicamentos(receta_id,id_consulta, Convert.ToInt32(dtBonos.Rows[i].Cells["Bono Numero"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[0].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[0].Cells["Cantidad"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[1].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[1].Cells["Cantidad"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[2].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[2].Cells["Cantidad"].Value),
                                    Convert.ToInt32(dtMedicamentos.Rows[3].Cells["ID"].Value), Convert.ToInt32(dtMedicamentos.Rows[3].Cells["Cantidad"].Value), 0, 0);
                                break;
                            default:
                                break;
                        }
                    }                    
                }
                MessageBox.Show("Receta ingresada correctamente");
                this.Close();
            }
            else
                MessageBox.Show("Ingrese al menos un medicamento");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarMedicamento frmBuscarMed = new BuscarMedicamento();
            frmBuscarMed.ShowDialog();
            lblIdMed.Text = frmBuscarMed.idEle;
            if (Convert.ToInt32(lblIdMed.Text) > 0)
            {
                tBoxMedicamento.Text = frmBuscarMed.NomYapeEle;
            }
            else
            {
                tBoxMedicamento.Text = "";
                lblIdMed.Text = "-2";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Esta seguro que desea cancelar la receta?", "Cancelar receta", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult2 == DialogResult.No)
            {
                //NADA
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            tBoxMedicamento.Text = string.Empty;
            tBoxNbono.Text = string.Empty;
            cBoxCantidad.SelectedIndex = 0;
            lblIdMed.Text = "-2";
            dtBonos.DataSource = null;
            dtBonos.Update();
            dtMedicamentos.DataSource = null;
            dtMedicamentos.Update();
        }
    }
}
