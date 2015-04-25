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

        //lo dejo en 2 metodos separados para evitar confusion de si se esta corriendo un stopro o una query y que nombre se le debe pasar

        //invocar storeProcedures en la DB
        public static SqlDataReader invocarStoreProcedure(SqlConnection conexionDB, string nombreProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comandoSQL = new SqlCommand(nombreProcedure, conexionDB);
            comandoSQL.CommandType = CommandType.StoredProcedure;

            return correrSQL(comandoSQL, parametros);
        }

        //correrQuery
        public static SqlDataReader correrQuery(SqlConnection conexionDB, string query, List<SqlParameter> parametros)
        {
            SqlCommand comandoSQL = new SqlCommand(query, conexionDB);

            return correrSQL(comandoSQL, parametros);

        }

        private static SqlDataReader correrSQL(SqlCommand comando, List<SqlParameter> parametros)
        {
            if (parametros != null && parametros.Exists(x => x != null))
            {
                foreach (SqlParameter parametro in parametros)
                {
                    comando.Parameters.Add(parametro);
                }
            }
            return comando.ExecuteReader();
        }
    }
}
