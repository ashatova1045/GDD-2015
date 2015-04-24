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
        public static SqlConnection  ConectarDB(string connectionString) //método para conectar a la DB
        {
            SqlConnection conexionDB = new SqlConnection(connectionString);
            if (conexionDB.State != System.Data.ConnectionState.Open)
            {
                conexionDB.Open();
            }
            return conexionDB; 
        }

        public static void DesconectarDB(SqlConnection conexionDB) //método para desconectarse de la DB
        {
            if(conexionDB.State != System.Data.ConnectionState.Closed)
            {
                conexionDB.Close();
            }
        }

        public static object InvocarStoreProcedure(SqlConnection conexionDB, string nombre, int resultadoEsperado, List<SqlParameter> parametros)
        {
            SqlCommand comandoSQL = new SqlCommand();
            comandoSQL.CommandText = nombre;

            // comandoSQL.Connection = conexionDB;
            comandoSQL.Connection = conexionDB;
            comandoSQL.CommandType = CommandType.StoredProcedure;

            object resultadoStoreProcedure = null; 

            if (parametros!=null && parametros.Exists(x => x!=null)) {        
                 foreach(SqlParameter parametro in parametros)
                 {
                    comandoSQL.Parameters.Add(parametro);              
                 }
            }

            switch (resultadoEsperado)
            {
                //NONQUERY
                case 1:
                    resultadoStoreProcedure = comandoSQL.ExecuteNonQuery();
                    break;
                    
                //READER    
                case 2:
                   
                    resultadoStoreProcedure = comandoSQL.ExecuteReader();
                    break;
                    
                    //SCALAR
                case 3:
                    resultadoStoreProcedure = comandoSQL.ExecuteScalar();
                    break;
             }
            
            comandoSQL.Dispose();

            return resultadoStoreProcedure;
        }

    }
}
