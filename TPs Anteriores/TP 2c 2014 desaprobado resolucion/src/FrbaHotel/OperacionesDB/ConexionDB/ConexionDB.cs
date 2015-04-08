using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.OperacionesDB.ConexionDB
{
    static class ConexionDB // Clase que maneja el acceso a DB
    {
        public static SqlConnection conexionDB; // objeto de conexión

        public static SqlConnection  ConectarDB() //método para conectar a la DB
        {
            string datosConexionDB = @"Server=localhost\SQLSERVER2008;Database=GD2C2014;User Id=gd;Password=gd2014;";
         //   string datosConexionDB = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;"+"Integrated Security=True";
            conexionDB = new SqlConnection(datosConexionDB);
            if (conexionDB.State != System.Data.ConnectionState.Open)
            {
                conexionDB.Open();
            }
            return conexionDB; 
        }

        public static void DesconectarDB() //método para desconectarse de la DB
        {
            if(conexionDB.State != System.Data.ConnectionState.Closed)
            {
                conexionDB.Close();
            }
        }

        public static object InvocarStoreProcedure(string nombre, int resultadoEsperado, List<SqlParameter> parametros)
        {
            SqlCommand comandoSQL = new SqlCommand();
            comandoSQL.CommandText = nombre;

            // comandoSQL.Connection = conexionDB;
            comandoSQL.Connection = ConexionDB.ConectarDB();
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
