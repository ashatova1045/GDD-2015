using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicaFRBA.Operaciones.AgendaMedico
{
    public partial class horarioFinal : Form
    {
        private TimeSpan horarioInicial = new TimeSpan(0);

        private TimeSpan horarioFin = new TimeSpan(0);  // Backing store

        public TimeSpan horarioElegido
        {
            get
            {
                return horarioFin;
            }
        }

        public horarioFinal(string dia, TimeSpan horarioInic)
        {
            InitializeComponent();
            tBoxDia.Text = dia;
            int hora;
            List<string> horas = new List<string>();
            if (dia == "sabado")
            {
                hora = 10;
                while (hora <= 15)
                {
                    horas.Add(hora.ToString());
                    hora++;
                }        
            }
            else
            {
                hora = 7;
                while (hora <= 20)
                {
                    horas.Add(hora.ToString());
                    hora++;
                }
                cBoxHora.DataSource = horas;
            }
            cBoxHora.DataSource = horas;

            List<string> minutos = new List<string>();
            minutos.Add("00");
            minutos.Add("30");

            cBoxMinutos.DataSource = minutos;
           
            horarioInicial = horarioInic;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TimeSpan horarioInic = TimeSpan.FromHours(7);
            TimeSpan horarioFinal = TimeSpan.FromHours(20);
            TimeSpan horarioInicialSabado = TimeSpan.FromHours(10);
            TimeSpan horarioFinalSabado = TimeSpan.FromHours(15);

            string horario = cBoxHora.Text + ':' + cBoxMinutos.Text;
            TimeSpan span = new TimeSpan();
            if (TimeSpan.TryParse(horario, out span))
            {
                if (tBoxDia.Text == "sabado")
                {
                    if (span.CompareTo(horarioInicialSabado) < 0)
                    {
                        // HORARIO ANTERIOR AL INICIAL
                        MessageBox.Show("Horario de apertura del hospital: 10:00");
                    }
                    else if (span.CompareTo(horarioFinalSabado) > 0)
                    {
                        // HORARIO DESPUES DEL FINAL
                        MessageBox.Show("Horario de cierre del hospital: 15:00");
                    }
                    else
                    {
                        // HORARIO CORRECTO
                        if (horarioInicial.CompareTo(span) < 0)
                        {
                            horarioFin = span;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El horario final es igual o anterior al horario inicial");
                        }
                    }
                }
                else
                {
                    if (span.CompareTo(horarioInic) < 0)
                    {
                        // HORARIO ANTERIOR AL INICIAL
                        MessageBox.Show("Horario de apertura del hospital: 07:00");
                    }
                    else if (span.CompareTo(horarioFinal) > 0)
                    {
                        // HORARIO DESPUES DEL FINAL
                        MessageBox.Show("Horario de cierre del hospital: 20:00");
                    }
                    else
                    {
                        // HORARIO CORRECTO
                        if (horarioInicial.CompareTo(span) < 0)
                        {
                            horarioFin = span;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El horario final es igual o anterior al horario inicial");
                        }
                    }
                }
            }
        }
    }
}
