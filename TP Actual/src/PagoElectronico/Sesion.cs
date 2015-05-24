using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace PagoElectronico
{
    public static class Sesion
    {
        public static SqlConnection conexion;
        public static DateTime fecha;

        public static decimal rol_id;
        public static string rol_nombre;
        public static decimal user_id;
        public static string usuario;
        public static decimal cliente_id;
    }
}
