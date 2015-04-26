using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OperacionesDB.ConexionDB;
using System.IO;

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

            string direccionDeLaSolu = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            System.IO.StreamReader file = new StreamReader(Path.Combine(direccionDeLaSolu,"config.txt"));
            string sqlcon = file.ReadLine();
            string fechaF = file.ReadLine();
            file.Close();

            Sesion.conexion = ConexionDB.ConectarDB(sqlcon);
            Sesion.fecha = DateTime.Parse(fechaF);

            Application.Run(new Login.Login());

            ConexionDB.DesconectarDB(Sesion.conexion);
        }
    }
}
