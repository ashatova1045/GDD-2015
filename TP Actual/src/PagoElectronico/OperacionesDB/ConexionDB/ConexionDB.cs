using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperacionesDB.ConexionDB
{
    static class ConexionDB // Clase que maneja el acceso a DB
    {
        public static SqlConnection ConectarDB(string connectionString) //metodo para conectar a la DB
        {
            SqlConnection conexionDB = new SqlConnection(connectionString);
            if (conexionDB.State != System.Data.ConnectionState.Open)
            {
                conexionDB.Open();
            }
            return conexionDB;
        }

        public static void DesconectarDB(SqlConnection conexionDB) //metodo para desconectarse de la DB
        {
            if (conexionDB.State != System.Data.ConnectionState.Closed)
            {
                conexionDB.Close();
            }
        }

        //invocar storeProcedures en la DB
        public static SqlDataReader invocarStoreProcedure(SqlConnection conexionDB, string nombreProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comandoSQL = new SqlCommand("HHHH."+nombreProcedure, conexionDB);
            comandoSQL.CommandType = CommandType.StoredProcedure;

            if (parametros != null && parametros.Exists(x => x != null))
            {
                foreach (SqlParameter parametro in parametros)
                {
                    comandoSQL.Parameters.Add(parametro);
                }
            }

            return comandoSQL.ExecuteReader();
        }

        //correrQuery
        public static SqlDataReader correrQuery(SqlConnection conexionDB, string query)
        {
            SqlCommand comandoSQL = new SqlCommand("HHHH."+query, conexionDB);

            return comandoSQL.ExecuteReader();
        }

   }
}
