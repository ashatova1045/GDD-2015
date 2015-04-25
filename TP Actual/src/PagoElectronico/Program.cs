using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OperacionesDB.ConexionDB;

namespace PagoElectronico
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.IO.StreamReader file = new System.IO.StreamReader("\\config.txt");
            string sqlcon = file.ReadLine();
            string fechaF = file.ReadLine(); 
            file.Close();

            Sesion.conexion = ConexionDB.ConectarDB(sqlcon);
            Sesion.fecha = DateTime.Parse(fechaF);

            Application.Run(new Form1());

            ConexionDB.DesconectarDB(Sesion.conexion);
        }
    }
}
