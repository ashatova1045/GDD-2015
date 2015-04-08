using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
using System.Configuration;

namespace ClinicaFRBA.Utils
{
    static class ManejadorFechaHora
    {
        public static void registrarFechaDelSistema()
        {
            ManejadorNegocio.registrarFechaDelSistema(ManejadorFechaHora.obtenerFechaDelSistema());
        }

        public static DateTime obtenerFechaDelSistema()
        {
            DateTime fechaParseada;
            if (!DateTime.TryParseExact(ConfigurationSettings.AppSettings["stringFechaSistema"].ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out fechaParseada))
            {
                fechaParseada = DateTime.Now;
            }
            return fechaParseada;
        }
    }
}
