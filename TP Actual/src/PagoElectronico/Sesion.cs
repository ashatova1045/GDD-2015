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

        public static int rol_id;
        public static string rol_nombre;
        public static int user_id;
        public static string usuario;
    }
}
