using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using ClinicaFRBA.Utils.Seguridad;

namespace ClinicaFRBA
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
            ManejadorBD.ConectarBD();
            Application.Run(new Login());
            ManejadorBD.DesconectarBD();
        }
    }
}
