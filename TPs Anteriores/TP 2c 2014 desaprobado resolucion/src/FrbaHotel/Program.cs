using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using FrbaHotel.OperacionesDB.ConexionDB;
using FrbaHotel.Login;

namespace FrbaHotel
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
            ConexionDB.ConectarDB();
            Application.Run(new Login.Login());
            ConexionDB.DesconectarDB();
        }
    }
}
