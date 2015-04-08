using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFRBA.Utils.Seguridad
{
    static class ManejadorBD
    {
        private static SqlConnection conexionBD;

        public static void ConectarBD() {
            string strDeConexionBD = ConfigurationSettings.AppSettings["stringDeConexionBD"].ToString();
            conexionBD = new SqlConnection(strDeConexionBD);
            if (conexionBD.State != System.Data.ConnectionState.Open)
            {
                conexionBD.Open();
            }
        }

        public static object EjecutarSP(string spNombre, List<SqlParameter> spParameters, string spTipoResultado)
        {
            SqlCommand comandoAEjecutar = new SqlCommand();
            comandoAEjecutar.CommandTimeout = 500;
            comandoAEjecutar.Connection = conexionBD;
            comandoAEjecutar.CommandType = CommandType.StoredProcedure;
            comandoAEjecutar.CommandText = spNombre;

            if ((spParameters != null) && (spParameters.Count > 0)) {
                foreach(SqlParameter spParameter in spParameters) 
                {
                    comandoAEjecutar.Parameters.Add(spParameter);
                }
            }

            object resultado = null;

            switch (spTipoResultado.ToUpper())
            {
                case "ESCALAR":
                    resultado = comandoAEjecutar.ExecuteScalar();
                    break;
                case "READER":
                    resultado = comandoAEjecutar.ExecuteReader();
                    break;
                case "NON_QUERY":
                    resultado = comandoAEjecutar.ExecuteNonQuery();
                    break;
                default:
                    break;
            }

            if ((spParameters != null) && (spParameters.Count > 0))
            {
                comandoAEjecutar.Parameters.Clear();
            }
            comandoAEjecutar.Dispose();

            return resultado;
        }
        public static void DesconectarBD()
        {
            if (conexionBD.State != System.Data.ConnectionState.Closed)
            {
                conexionBD.Close();
            }
        }
    }
}
