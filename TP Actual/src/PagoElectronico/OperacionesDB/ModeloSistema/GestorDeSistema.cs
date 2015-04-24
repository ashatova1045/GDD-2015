using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using FrbaHotel.OperacionesDB.Cifrado;
using FrbaHotel.OperacionesDB.ConexionDB;

namespace OperacionesDB.ModeloSistema
{
    class GestorDeSistema
    {
        //Declaración de constantes
        private const int NONQUERY = 1;
        private const int READER = 2;
        private const int SCALAR = 3;

        //Constantes de StoreProcedure
        private const string STORE_LOGINUSUARIO = "ELITE4.spLoginUsuario";
        private const string SP_OBETENER_TODOS_LOS_ROLES = "ELITE4.spRoles";
        private const string SP_OBTENER_ROLES_DEL_SISTEMA = "ELITE4.spRolesUsuario";
        private const string SP_OBTENER_HOTELES_DEL_SISTEMA = "ELITE4.spHotelesUsuario";
        private const string SP_OBTENER_FUNCIONALIDADES_DEL_ROL = "ELITE4.spFuncDelRol";
        private const string SP_OBTENER_REGIMENES_POR_HOTEL = "ELITE4.spRegimenesPorHotel";
        private const string SP_NUEVO_USUARIO = "ELITE4.spNuevoUsuario";
        private const string SP_NUEVO_CLIENTE = "ELITE4.spNuevoCliente";
        private const string SP_NUEVO_HOTEL = "ELITE4.spNuevoHotel";
        private const string SP_OBTENER_TIPOSDEHABITACION = "ELITE4.spTiposDeHab";
        private const string SP_NUEVA_HABITACION = "ELITE4.spNuevaHabitacion";
        private const string SP_OBTENER_FUNCIONALIDADES = "ELITE4.spFunc";
        private const string SP_NUEVO_ROL = "ELITE4.spNuevoRol";
        private const string SP_NUEVA_FUNC_POR_ROL = "ELITE4.spNuevaFuncPorRol";
        private const string SP_NUEVO_ROL_POR_USUARIO = "ELITE4.spNuevoRolPorUsuario";
        private const string SP_MODIFICAR_CLIENTE = "ELITE4.spModificarCliente";
        private const string SP_DAR_BAJA_CLIENTE = "ELITE4.spDarBajaCliente";
        private const string SP_OBETENER_TODOS_LOS_TPAS = "ELITE4.spObetenerTipoPasaportes";
        private const string SP_NUEVO_TIPOPAS = "ELITE4.nuevoTipoPas";
        private const string SP_OBTENER_TIPO_HABITACIONES = "ELITE4.spObtenerTipoDeHabitaciones";
        private const string SP_OBTENER_HABITACIONES_DISPONIBLES = "ELITE4.spObtenerHabitacionesDisponibles";
        private const string SP_OBTENER_CLIENTE = "ELITE4.spObtenerCliente";
        private const string SP_BUSCAR_USUARIOS = "ELITE4.spBuscarUsuarios";
        private const string SP_NUEVA_RESERVA = "ELITE4.spNuevaReserva";
        private const string SP_NUEVA_RESERVA_POR_HABITACION = "ELITE4.spNuevaReservaPorHabitacion";
        private const string SP_MODIFICAR_USUARIO = "ELITE4.spModificarUsuario";
        private const string SP_MODIFICAR_ROL_POR_FUNCIONALIDAD = "ELITE4.spModificarRolPorFuncionalidad";
        private const string SP_MOFICAR_ROL = "ELITE4.spModificarRol";
        private const string SP_OBTENER_RESERVA = "ELITE4.spObtenerReserva";
        private const string SP_MODIFICAR_RESERVA = "ELITE4.spModificarReserva";
        private const string SP_ELIMINAR_RESERVAS_POR_HABITACION = "ELITE4.spEliminarReservasPorHabitacion";
        private const string SP_BAJA_RESERVA = "ELITE4.spBajaReserva";

        public static int loginUsuario(string usuario, string contrasena)
        {
            int usuario_ID;
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter user = new SqlParameter("@usuario", usuario);
            SqlParameter pass = new SqlParameter("@pass", contrasena);
            parametros.Add(user);
            parametros.Add(pass);
            object resultadoStoreProcedure = ConexionDB.ConexionDB.InvocarStoreProcedure(STORE_LOGINUSUARIO, SCALAR, parametros);
            usuario_ID = ((resultadoStoreProcedure != null) ? Convert.ToInt32(resultadoStoreProcedure) : 0);
            return usuario_ID;
        }

        public static DataTable obtenerHotelesParaUsuario(int usuarioId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@usuario_id", usuarioId));
            SqlDataReader readerHotelesUsuario = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_HOTELES_DEL_SISTEMA, READER, parametros);
            DataTable hotelesDeUsuario = new DataTable();
            if (readerHotelesUsuario.HasRows)
            {
                hotelesDeUsuario.Load(readerHotelesUsuario);
            }
            readerHotelesUsuario.Dispose();
            return hotelesDeUsuario;

        }

        public static DataTable obtenerHotelesParaReserva(int usuarioId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@usuario_id", usuarioId));
            SqlDataReader readerHotelesReserva = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_HOTELES_DEL_SISTEMA, READER, parametros);
            DataTable hotelesReserva = new DataTable();
            if (readerHotelesReserva.HasRows)
            {
                hotelesReserva.Load(readerHotelesReserva);
            }
            readerHotelesReserva.Dispose();
            return hotelesReserva;

        }

        public static DataTable obtenerTipoDeHabitacionesParaReserva(int hotelId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@hotel_id", hotelId));
            SqlDataReader readerTiposDeHab = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_TIPO_HABITACIONES, READER, parametros);
            DataTable tiposDeHab = new DataTable();
            if (readerTiposDeHab.HasRows)
            {
                tiposDeHab.Load(readerTiposDeHab);
            }
            readerTiposDeHab.Dispose();
            return tiposDeHab;

        }

        public static DataTable obtenerRegimenesPorHotel(int hotelId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@hotel_id", hotelId));
            SqlDataReader readerRegimenesPorHotel = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_REGIMENES_POR_HOTEL, READER, parametros);
            DataTable regimenesHotel = new DataTable();
            if (readerRegimenesPorHotel.HasRows)
            {
                regimenesHotel.Load(readerRegimenesPorHotel);
            }
            readerRegimenesPorHotel.Dispose();
            return regimenesHotel;

        }

        internal static DataTable obtenerRolesParaUsuario(int usuarioId, int hotel)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@usuario_id", usuarioId));
            parametros.Add(new SqlParameter("@hotel_id", hotel));
            SqlDataReader readerRolesUsuario = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_ROLES_DEL_SISTEMA, READER, parametros);
            DataTable rolesDeUsuario = new DataTable();
            if (readerRolesUsuario.HasRows)
            {
                rolesDeUsuario.Load(readerRolesUsuario);
            }
            readerRolesUsuario.Dispose();
            return rolesDeUsuario;
        }

        internal static DataTable obtenerFuncionalidadesDeRol(int rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@rol", rol));
            SqlDataReader funcRol = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_FUNCIONALIDADES_DEL_ROL, READER, parametros);
            DataTable funcDeRol = new DataTable();
            if (funcRol.HasRows)
            {
                funcDeRol.Load(funcRol);
            }
            funcRol.Dispose();
            return funcDeRol;
        }

        internal static void nuevoUsuario(int tipodoc, decimal ndoc, string user, string pass, DateTime nac, string direccion, string mail, string nombre, string apellido, decimal telefono)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipodoc", tipodoc));
            parametros.Add(new SqlParameter("@ndoc", ndoc));
            parametros.Add(new SqlParameter("@user", user));
            parametros.Add(new SqlParameter("@pass", pass));
            parametros.Add(new SqlParameter("@nac", nac));
            parametros.Add(new SqlParameter("@direccion", direccion));
            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@apellido", apellido));
            parametros.Add(new SqlParameter("@telefono", telefono));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVO_USUARIO, NONQUERY, parametros);
        }

        //CLIENTES

        internal static void nuevoCliente(int tipodoc, Decimal ndoc, string apellido, string nombre, string mail, Decimal tcred, DateTime nacimiento, string paisN, string paisR, string ciudad, string calle, Decimal ncalle, String depto, Decimal piso)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipodoc", tipodoc));
            parametros.Add(new SqlParameter("@ndoc", ndoc));
            parametros.Add(new SqlParameter("@apellido", apellido));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@tcred", tcred));
            parametros.Add(new SqlParameter("@nacimiento", nacimiento));
            parametros.Add(new SqlParameter("@paisN", paisN));
            parametros.Add(new SqlParameter("@paisR", paisR));
            parametros.Add(new SqlParameter("@ciudad", ciudad));
            parametros.Add(new SqlParameter("@calle", calle));
            parametros.Add(new SqlParameter("@ncalle", ncalle));
            parametros.Add(new SqlParameter("@depto", depto));
            parametros.Add(new SqlParameter("@piso", piso));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVO_CLIENTE, NONQUERY, parametros);


        }

        internal static void modificarCliente(Int32 id, Int32 ndoc, Int32 tipodoc, string apellido, string nombre, string mail/*, Decimal tcred*/, DateTime nacimiento, string paisN, string paisR, string ciudad, string calle, Int32 ncalle, string depto, Int32 piso, Boolean habilitado, Int32 tarjetaCredito/*,Int32 puntos*/)
        {


            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("ClienteID", id));
            parametros.Add(new SqlParameter("@tipodoc", tipodoc));
            parametros.Add(new SqlParameter("@ndoc", ndoc));
            parametros.Add(new SqlParameter("@apellido", apellido));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@nacimiento", nacimiento));
            parametros.Add(new SqlParameter("@paisN", paisN));
            parametros.Add(new SqlParameter("@paisR", paisR));
            parametros.Add(new SqlParameter("@ciudad", ciudad));
            parametros.Add(new SqlParameter("@calle", calle));
            parametros.Add(new SqlParameter("@ncalle", ncalle));
            parametros.Add(new SqlParameter("@depto", depto));
            parametros.Add(new SqlParameter("@piso", piso));
            parametros.Add(new SqlParameter("@habilitado", habilitado));
            parametros.Add(new SqlParameter("@tarjetaCredito", tarjetaCredito));


            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_MODIFICAR_CLIENTE, NONQUERY, parametros);
        }


        internal static void modificarCliente(Cliente cliente)
        {


            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@clienteID", Convert.ToInt32(cliente.id)));
            parametros.Add(new SqlParameter("@tipodoc", Convert.ToInt32(cliente.tipoPasaporte)));
            parametros.Add(new SqlParameter("@ndoc", Convert.ToDecimal(cliente.pasaporteNumero)));
            parametros.Add(new SqlParameter("@apellido", cliente.apellido));
            parametros.Add(new SqlParameter("@nombre", cliente.nombre));
            parametros.Add(new SqlParameter("@mail", cliente.mail));
            parametros.Add(new SqlParameter("@nacimiento", cliente.fechaNacimiento));
            parametros.Add(new SqlParameter("@paisN", cliente.nacionalidad));
            parametros.Add(new SqlParameter("@paisR", cliente.paisResidencia));
            parametros.Add(new SqlParameter("@ciudad", cliente.ciudadResidencia));
            parametros.Add(new SqlParameter("@calle", cliente.calleDomicilio));
            parametros.Add(new SqlParameter("@ncalle", Convert.ToDecimal(cliente.numeroCalle)));
            parametros.Add(new SqlParameter("@depto", cliente.depto));
            parametros.Add(new SqlParameter("@piso", Convert.ToDecimal(cliente.piso)));
            parametros.Add(new SqlParameter("@habilitado", cliente.habilitado));
            parametros.Add(new SqlParameter("@tarjetaCredito", Convert.ToDecimal(cliente.tarjetaDeCredito)));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_MODIFICAR_CLIENTE, NONQUERY, parametros);


        }





        internal static void darBajaCliente(Int32 clienteId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@clienteid", clienteId));


            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_DAR_BAJA_CLIENTE, NONQUERY, parametros);
        }


        public static List<Cliente> buscarClientes(string nombre, string apellido, string tipoPasaporte, string nroPasaporte, string mail)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection conexionBD = ConexionDB.ConexionDB.ConectarDB())
            {

                SqlCommand instruccionSql = new SqlCommand(string.Format("SELECT Cliente_id,Pasaporte_Tipo,Cliente_Pasaporte_Numero,Cliente_Mail,Cliente_Apellido,Cliente_Nombre,Cliente_Fecha_Nac,Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,Cliente_Nacionalidad,Cliente_Ciudad,Cliente_Pais_Residencia,Cliente_Tarjeta_Credito,Cliente_Habilitado FROM ELITE4.Cliente WHERE Pasaporte_Tipo like '{0}%' AND Cliente_Pasaporte_Numero LIKE '{1}%'  AND Cliente_Apellido LIKE '%{2}%' AND Cliente_Nombre LIKE '%{3}%' AND Cliente_Mail LIKE '%{4}%' ", tipoPasaporte, nroPasaporte, apellido, nombre, mail), conexionBD);


                SqlDataReader reader = instruccionSql.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.id = Convert.ToString(reader.GetInt32(0));
                    cliente.tipoPasaporte = Convert.ToString(reader.GetInt32(1));
                    cliente.pasaporteNumero = Convert.ToString(reader.GetDecimal(2));
                    cliente.mail = reader.GetString(3);
                    cliente.apellido = reader.GetString(4);
                    cliente.nombre = reader.GetString(5);
                    cliente.calleDomicilio = reader.GetString(7);
                    cliente.fechaNacimiento = reader.GetDateTime(6);
                    cliente.numeroCalle = Convert.ToString(reader.GetDecimal(8));
                    if (reader.IsDBNull(9))
                    {

                        cliente.piso = "";

                    }
                    else
                    {

                        cliente.piso = Convert.ToString(reader.GetDecimal(9));
                    }
                    if (reader.IsDBNull(10))
                    {
                        cliente.depto = "";
                    }
                    else
                    {
                        cliente.depto = reader.GetString(10);
                    }
                    if (reader.IsDBNull(11))
                    {
                        cliente.nacionalidad = "";
                    }
                    else
                    {
                        cliente.nacionalidad = reader.GetString(11);
                    }
                    if (reader.IsDBNull(12))
                    {
                        cliente.paisResidencia = "";
                    }
                    else
                    {
                        cliente.ciudadResidencia = reader.GetString(12);
                    }
                    if (reader.IsDBNull(13))
                    {
                        cliente.ciudadResidencia = "";
                    }
                    else
                    {
                        cliente.ciudadResidencia = reader.GetString(13);
                    }
                    if (reader.IsDBNull(14))
                    {

                        cliente.tarjetaDeCredito = "0";
                    }
                    else
                    {
                        cliente.tarjetaDeCredito = Convert.ToString(reader.GetDecimal(14));
                    }

                    cliente.habilitado = reader.GetBoolean(15);

                    clientes.Add(cliente);

                }
                conexionBD.Close();

                return clientes;
            }

        }

        public static Cliente buscarClienteSeleccionado(Int32 id)
        {


            Cliente cliente = new Cliente();
            using (SqlConnection conexionBD = ConexionDB.ConexionDB.ConectarDB())
            {

                SqlCommand instruccionSql = new SqlCommand(string.Format("SELECT Cliente_id,Pasaporte_Tipo,Cliente_Pasaporte_Numero,Cliente_Mail,Cliente_Apellido,Cliente_Nombre,Cliente_Fecha_Nac,Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,Cliente_Nacionalidad,Cliente_Ciudad,Cliente_Pais_Residencia,Cliente_Tarjeta_Credito,Cliente_Habilitado FROM ELITE4.Cliente WHERE Cliente_id= '{0}'", id), conexionBD);


                SqlDataReader reader = instruccionSql.ExecuteReader();

                while (reader.Read())
                {

                    cliente.id = Convert.ToString(reader.GetInt32(0));
                    cliente.tipoPasaporte = Convert.ToString(reader.GetInt32(1));
                    cliente.pasaporteNumero = Convert.ToString(reader.GetDecimal(2));
                    cliente.mail = reader.GetString(3);
                    cliente.apellido = reader.GetString(4);
                    cliente.nombre = reader.GetString(5);
                    cliente.calleDomicilio = reader.GetString(7);
                    cliente.fechaNacimiento = reader.GetDateTime(6);
                    cliente.numeroCalle = Convert.ToString(reader.GetDecimal(8));
                    if (reader.IsDBNull(9))
                    {

                        cliente.piso = "";

                    }
                    else
                    {

                        cliente.piso = Convert.ToString(reader.GetDecimal(9));
                    }
                    if (reader.IsDBNull(10))
                    {
                        cliente.depto = "";
                    }
                    else
                    {
                        cliente.depto = reader.GetString(10);
                    }
                    if (reader.IsDBNull(11))
                    {
                        cliente.nacionalidad = "";
                    }
                    else
                    {
                        cliente.nacionalidad = reader.GetString(11);
                    }
                    if (reader.IsDBNull(12))
                    {
                        cliente.paisResidencia = "";
                    }
                    else
                    {
                        cliente.ciudadResidencia = reader.GetString(12);
                    }
                    if (reader.IsDBNull(13))
                    {
                        cliente.ciudadResidencia = "";
                    }
                    else
                    {
                        cliente.ciudadResidencia = reader.GetString(13);
                    }
                    if (reader.IsDBNull(14))
                    {

                        cliente.tarjetaDeCredito = "0";
                    }
                    else
                    {
                        cliente.tarjetaDeCredito = Convert.ToString(reader.GetDecimal(14));
                    }

                    cliente.habilitado = reader.GetBoolean(15);



                }


                conexionBD.Close();
                return cliente;

            }

        }


        //HOTELES
        internal static void nuevoHotel(string ciudad, string calle, decimal ncalle, decimal estrellas, decimal restrellas, string pais, string nombre, string mail, decimal telefono)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ciudad", ciudad));
            parametros.Add(new SqlParameter("@calle", calle));
            parametros.Add(new SqlParameter("@ncalle", ncalle));
            parametros.Add(new SqlParameter("@estrellas", estrellas));
            parametros.Add(new SqlParameter("@restrellas", restrellas));
            parametros.Add(new SqlParameter("@pais", pais));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@telefono", telefono));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVO_HOTEL, NONQUERY, parametros);


        }


        //HABITACIONES
        internal static DataTable obtenerTiposHabitacion()
        {
            SqlDataReader th = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_TIPOSDEHABITACION, READER, null);
            DataTable tiposh = new DataTable();
            if (th.HasRows)
            {
                tiposh.Load(th);
            }
            th.Dispose();
            return tiposh;
        }

        internal static void nuevaHabitacion(decimal numero, decimal piso, decimal tipo, bool frente, bool habilitado, int hotel)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numero", numero));
            parametros.Add(new SqlParameter("@piso", piso));
            parametros.Add(new SqlParameter("@tipo", tipo));
            parametros.Add(new SqlParameter("@frente", frente));
            parametros.Add(new SqlParameter("@habilitado", habilitado));
            parametros.Add(new SqlParameter("@hotel", hotel));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVA_HABITACION, NONQUERY, parametros);
        }


        internal static DataTable obtenerFuncionalidades()
        {
            SqlDataReader funcRol = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_FUNCIONALIDADES, READER, null);
            DataTable funcDeRol = new DataTable();
            if (funcRol.HasRows)
            {
                funcDeRol.Load(funcRol);
            }
            funcRol.Dispose();
            return funcDeRol;
        }

        internal static void nuevoRol(string nombre, bool activo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@activo", activo));
            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVO_ROL, NONQUERY, parametros);
        }

        internal static void nuevaFuncionalidadPorRol(string nombreRol, Byte funcionalidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nombreRol));
            parametros.Add(new SqlParameter("@funcionalidad", funcionalidad));
            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVA_FUNC_POR_ROL, NONQUERY, parametros);
        }

        internal static DataTable ObtenerTodosLosRoles()
        {
            SqlDataReader funcRol = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBETENER_TODOS_LOS_ROLES, READER, null);
            DataTable funcDeRol = new DataTable();
            if (funcRol.HasRows)
            {
                funcDeRol.Load(funcRol);
            }
            funcRol.Dispose();
            return funcDeRol;
        }

        internal static void nuevoRolPorUsuario(int rol, int hotel_actual, string nombreUsuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@rol", rol));
            parametros.Add(new SqlParameter("@hotel_actual", hotel_actual));
            parametros.Add(new SqlParameter("@nombreUsuario", nombreUsuario));
            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVO_ROL_POR_USUARIO, NONQUERY, parametros);
        }

        //ABM ROL


        internal static DataTable buscarRoles(string rol_cod, string rol_nombre)
        {


            using (SqlConnection conexionBD = ConexionDB.ConexionDB.ConectarDB())
            {
                SqlCommand instruccionSql;

                if (rol_nombre == String.Empty & rol_cod == String.Empty)
                {
                    instruccionSql = new SqlCommand(string.Format("SELECT Rol_Cod,Rol_Nombre,Rol_Habilitado FROM ELITE4.Rol"), conexionBD);
                }
                else
                {
                    if (rol_nombre == String.Empty)
                    {
                        instruccionSql = new SqlCommand(string.Format("SELECT Rol_Cod,Rol_Nombre,Rol_Habilitado FROM ELITE4.Rol WHERE Rol_Cod = {0} ", rol_cod), conexionBD);
                    }
                    else
                    {
                        if (rol_cod == String.Empty)
                        {
                            instruccionSql = new SqlCommand(string.Format("SELECT Rol_Cod,Rol_Nombre,Rol_Habilitado FROM ELITE4.Rol WHERE Rol_Nombre like '%{0}%' ", rol_nombre), conexionBD);
                        }
                        else
                        {
                            instruccionSql = new SqlCommand(string.Format("SELECT Rol_Cod,Rol_Nombre,Rol_Habilitado FROM ELITE4.Rol WHERE Rol_Cod ='{0}' AND Rol_Nombre like '%{1}%' ", rol_cod, rol_nombre), conexionBD);
                        }
                    }
                }



                SqlDataReader readerRol = instruccionSql.ExecuteReader();


                DataTable roles = new DataTable();
                if (readerRol.HasRows)
                {
                    roles.Load(readerRol);
                }
                readerRol.Dispose();
                conexionBD.Close();
                return roles;
            }

        }

        public static void habdeshabrol(int rolCod,byte hab)
        {
            List<SqlParameter> parametrosStore = new List<SqlParameter>();
            parametrosStore.Add(new SqlParameter("@Rol_Cod", rolCod));
            parametrosStore.Add(new SqlParameter("@hab", hab));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.spBajaLogicaRol", NONQUERY, parametrosStore);
        }

        internal static DataTable ObtenerTodosLosTipoDePasaporte()
        {
            SqlDataReader pasaportereader = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBETENER_TODOS_LOS_TPAS, READER, null);
            DataTable pasaportetable = new DataTable();
            if (pasaportereader.HasRows)
            {
                pasaportetable.Load(pasaportereader);
            }
            pasaportereader.Dispose();
            return pasaportetable;
        }



        internal static void nuevoTipoPas(string p)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pas", p));
            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVO_TIPOPAS, NONQUERY, parametros);
        }

        internal static int obtenerDescripcionPas(string p)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pasDes", p));

            object resultadoStoreProcedure = ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.ObtenerPasDescripcion", SCALAR, parametros);
            return ((resultadoStoreProcedure != null) ? Convert.ToInt32(resultadoStoreProcedure) : 0);
        }

        internal static bool obtenerClientesRepetidos(int tdoc, decimal ndoc, string mail)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tdoc", tdoc));
            parametros.Add(new SqlParameter("@ndoc", ndoc));
            parametros.Add(new SqlParameter("@mail", mail));

            object resultadoStoreProcedure = ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.ObtenerClientesRepetidos", SCALAR, parametros);
            return ((resultadoStoreProcedure != null) ? true : false);
        }

        internal static bool obtenerUsuariosRepetidos(int tdoc, decimal ndoc, string user, string mail)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tdoc", tdoc));
            parametros.Add(new SqlParameter("@ndoc", ndoc));
            parametros.Add(new SqlParameter("@user", user));
            parametros.Add(new SqlParameter("@mail", mail));

            object resultadoStoreProcedure = ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.ObtenerUsuariosRepetidos", SCALAR, parametros);
            return ((resultadoStoreProcedure != null) ? true : false);
        }



        internal static bool obtenerHabitacionExistente(decimal n, decimal p, int h)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@n", n));
            parametros.Add(new SqlParameter("@p", p));
            parametros.Add(new SqlParameter("@h", h));

            object resultadoStoreProcedure = ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.ObtenerHabitacionesRepetidas", SCALAR, parametros);
            return ((resultadoStoreProcedure != null) ? true : false);
        }


        internal static bool getHotelesRepetidos(string ciudad, string calle, decimal ncalle, string pais, string nombre, string mail, decimal telefono)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ciudad", ciudad));
            parametros.Add(new SqlParameter("@calle", calle));
            parametros.Add(new SqlParameter("@ncalle", ncalle));
            parametros.Add(new SqlParameter("@pais", pais));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@telefono", telefono));

            object resultadoStoreProcedure = ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.ObtenerHotelesRepetidos", SCALAR, parametros);
            return ((resultadoStoreProcedure != null) ? true : false);
        }

        internal static int getRolPorNombre(string nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nomrol", nombre));

            return (int)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.getrolpornombre", SCALAR, parametros);
        }

        internal static DataTable listar(int eleccion, decimal ano, decimal trimestre)
        {
            List<SqlParameter> parametrosStore = new List<SqlParameter>();
            parametrosStore.Add(new SqlParameter("@ano", ano));
            parametrosStore.Add(new SqlParameter("@trimestre", trimestre));
            parametrosStore.Add(new SqlParameter("@eleccion", eleccion));
            SqlDataReader readerLista = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.SP_listar", READER, parametrosStore);
            DataTable listaTable = new DataTable();
            if (readerLista.HasRows)
            {
                listaTable.Load(readerLista);
            }
            readerLista.Dispose();
            return listaTable;
        }

        internal static DataTable obtenerHabitacionesDisponibles(int hotelId, decimal habitacionTipoCodigo, DateTime fechaDesde, DateTime fechaHasta,decimal reservaai)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@hotel_id", hotelId));
            parametros.Add(new SqlParameter("@habitacion_tipo_codigo", habitacionTipoCodigo));
            parametros.Add(new SqlParameter("@fechaDesde", fechaDesde));
            parametros.Add(new SqlParameter("@fechaHasta", fechaHasta));
            parametros.Add(new SqlParameter("@reservaAignorar", reservaai));
            SqlDataReader readerHabitacionesDisponibles = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_HABITACIONES_DISPONIBLES, READER, parametros);
            DataTable habitacionesDisponibles = new DataTable();
            if (readerHabitacionesDisponibles.HasRows)
            {
                habitacionesDisponibles.Load(readerHabitacionesDisponibles);
            }
            readerHabitacionesDisponibles.Dispose();
            return habitacionesDisponibles;
        }

        public static DataTable obtenerCliente(int pasaporteTipo, decimal pasaportenumero, string clienteMail)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Pasaporte_Tipo", pasaporteTipo));
            parametros.Add(new SqlParameter("@Cliente_Pasaporte_Numero", pasaportenumero));
            parametros.Add(new SqlParameter("@Cliente_Mail", clienteMail));
            SqlDataReader readerObtenerCliente = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_CLIENTE, READER, parametros);
            DataTable cliente = new DataTable();
            if (readerObtenerCliente.HasRows)
            {
                cliente.Load(readerObtenerCliente);
            }
            readerObtenerCliente.Dispose();
            return cliente;

        }

 

       internal static void modificarUsuarios(String idUsuario, String username, String contrasena, String tipoPas, String nroDoc, String direccion, DateTime fecNac, Boolean habilitado, String nombre, String apellido, String mail, String telefono, String hotelId, String rolId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Id", idUsuario.ToString()));
            parametros.Add(new SqlParameter("@username", username));
            parametros.Add(new SqlParameter("@contrasena", contrasena));
            parametros.Add(new SqlParameter("@tipoPas", tipoPas.ToString()));
            parametros.Add(new SqlParameter("@nroDoc", nroDoc.ToString()));
            parametros.Add(new SqlParameter("@direccion", direccion));
            parametros.Add(new SqlParameter("@fecNac", fecNac));
            parametros.Add(new SqlParameter("@habilitado", habilitado));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@apellido", apellido));
            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@telefono", telefono.ToString()));
            parametros.Add(new SqlParameter("@hotelId", hotelId.ToString()));
            parametros.Add(new SqlParameter("rolId", rolId.ToString()));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_MODIFICAR_USUARIO, NONQUERY, parametros);

        }

        public static void modificarUsuarios3(Usuario usuario, String rolId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Id", Convert.ToInt32(usuario.id)));
            parametros.Add(new SqlParameter("@username", usuario.username));
            parametros.Add(new SqlParameter("@contrasena", usuario.contrasena));
            parametros.Add(new SqlParameter("@tipoPas", (usuario.tipoPasaporte)));
            parametros.Add(new SqlParameter("@nroDoc", (usuario.numeroPasaporte)));
            parametros.Add(new SqlParameter("@direccion", usuario.direccion));
            parametros.Add(new SqlParameter("@fecNac", Convert.ToDateTime(usuario.fecNac)));
            parametros.Add(new SqlParameter("@habilitado", usuario.habilitado));
            parametros.Add(new SqlParameter("@nombre", usuario.nombre));
            parametros.Add(new SqlParameter("@apellido", usuario.apellido));
            parametros.Add(new SqlParameter("@mail", usuario.mail));
            parametros.Add(new SqlParameter("@telefono", (usuario.telefono)));
            parametros.Add(new SqlParameter("@hotelId", Convert.ToInt32(FrbaHotel.Singleton.Instance.hotel)));
            parametros.Add(new SqlParameter("rolId", rolId));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_MODIFICAR_USUARIO, NONQUERY, parametros);
        }


        public static void modificarUsuarios(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Id", (usuario.id)));
            parametros.Add(new SqlParameter("@username", usuario.username));
            parametros.Add(new SqlParameter("@contrasena", usuario.contrasena));
            parametros.Add(new SqlParameter("@tipoPas", (usuario.tipoPasaporte)));
            parametros.Add(new SqlParameter("@nroDoc", (usuario.numeroPasaporte)));
            parametros.Add(new SqlParameter("@direccion", usuario.direccion));
            parametros.Add(new SqlParameter("@habilitado", usuario.habilitado));
            parametros.Add(new SqlParameter("@nombre", usuario.nombre));
            parametros.Add(new SqlParameter("@apellido", usuario.apellido));
            parametros.Add(new SqlParameter("@mail", usuario.mail));
            if (usuario.telefono==-1)
                parametros.Add(new SqlParameter("@telefono", null));
            else
                parametros.Add(new SqlParameter("@telefono", (usuario.telefono)));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_MODIFICAR_USUARIO, NONQUERY, parametros);
        }

        internal static DataTable buscarUsuarios(string direccion,String nombre, String apellido, String mail, String username, String nrodoc, int tipoDoc, String userId, Int32 hotelId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@apellido", apellido));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@direccion", direccion));
            parametros.Add(new SqlParameter("@nro_doc", nrodoc));
            parametros.Add(new SqlParameter("@username", username));
            parametros.Add(new SqlParameter("tipoDoc", tipoDoc));
            parametros.Add(new SqlParameter("@userId", userId));
            parametros.Add(new SqlParameter("@hotelID", hotelId));

            SqlDataReader readerUsuarios = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_BUSCAR_USUARIOS, READER, parametros);
            DataTable usuarios = new DataTable();
            if (readerUsuarios.HasRows)
            {
                usuarios.Load(readerUsuarios);
            }
            readerUsuarios.Dispose();
            return usuarios;

        }

    

        internal static DataTable buscarHabitacion(string codHabitacion, string pisoHabitacion, int hotelId, int tipoHabitacion, bool habi)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codHabitacion", codHabitacion));
            parametros.Add(new SqlParameter("@pisoHabitacion", pisoHabitacion));
            parametros.Add(new SqlParameter("@hotelId", hotelId));
            parametros.Add(new SqlParameter("@tipoHabitacion", tipoHabitacion));
            parametros.Add(new SqlParameter("@habi", habi ? 1 : 0));

            SqlDataReader readerHabitacion = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.spBuscarHabitacion", READER, parametros);
            DataTable habitaciones = new DataTable();
            if (readerHabitacion.HasRows)
            {
                habitaciones.Load(readerHabitacion);
            }
            readerHabitacion.Dispose();
            return habitaciones;

        }

        internal static DataTable nuevaReserva(int hotel_ID, DateTime reservaFechaInicio, DateTime reservaFechaFin, int regimenCod, int clienteID)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Hotel_ID", hotel_ID));
            parametros.Add(new SqlParameter("@Reserva_Fecha_Inicio", reservaFechaInicio));
            parametros.Add(new SqlParameter("@Reserva_Fecha_Fin", reservaFechaFin));
            parametros.Add(new SqlParameter("@Regimen_Cod", regimenCod));
            parametros.Add(new SqlParameter("@Cliente", clienteID));


            //    ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVA_RESERVA, NONQUERY, parametros);

            SqlDataReader readerReserva = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVA_RESERVA, READER, parametros);
            DataTable reserva = new DataTable();
            if (readerReserva.HasRows)
            {
                reserva.Load(readerReserva);
            }
            readerReserva.Dispose();
            return reserva;
        }

        internal static void nuevaReservaPorHabitacion(decimal reservaCodigo, decimal habNumero, int hotelID)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Reserva_Codigo", reservaCodigo));
            parametros.Add(new SqlParameter("@Habitacion_Numero", habNumero));
            parametros.Add(new SqlParameter("@Hotel_ID", hotelID));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_NUEVA_RESERVA_POR_HABITACION, NONQUERY, parametros);
        }

        internal static DataTable getReservasPorHabActuales(int hotel)
        {
            List<SqlParameter> parametrosStore = new List<SqlParameter>();
            parametrosStore.Add(new SqlParameter("@hotel", hotel));

            SqlDataReader readerReserva = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.getReservasActuales", READER, parametrosStore);
            DataTable reserva = new DataTable();
            if (readerReserva.HasRows)
            {
                reserva.Load(readerReserva);
            }
            readerReserva.Dispose();
            return reserva;

        }

        internal static DataTable getConsumibles()
        {
            SqlDataReader readerReserva = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.getConsumibles", READER, null);
            DataTable reserva = new DataTable();
            if (readerReserva.HasRows)
            {
                reserva.Load(readerReserva);
            }
            readerReserva.Dispose();
            return reserva;
        }

        internal static object getHabReservasActuales(decimal r)
        {
            List<SqlParameter> parametrosStore = new List<SqlParameter>();
            parametrosStore.Add(new SqlParameter("@reserva", r));

            SqlDataReader readerReserva = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.getHabReservasActuales", READER, parametrosStore);
            DataTable reserva = new DataTable();
            if (readerReserva.HasRows)
            {
                reserva.Load(readerReserva);
            }
            readerReserva.Dispose();
            return reserva;
        }

        internal static void registrarConsumible(decimal reserva, decimal hab, decimal con, int can, int hotel)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@reserva", reserva));
            parametros.Add(new SqlParameter("@hab", hab));
            parametros.Add(new SqlParameter("@con", con));
            parametros.Add(new SqlParameter("@can", can));
            parametros.Add(new SqlParameter("@hotel", hotel));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.registrarcon", NONQUERY, parametros);
        }

        internal static DataTable getConsumidosAuxiliares(decimal r)
        {
            List<SqlParameter> parametrosStore = new List<SqlParameter>();
            parametrosStore.Add(new SqlParameter("@reserva", r));

            SqlDataReader readerReserva = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.getconsaux", READER, parametrosStore);
            DataTable reserva = new DataTable();
            if (readerReserva.HasRows)
            {
                reserva.Load(readerReserva);
            }
            readerReserva.Dispose();
            return reserva;
        }

        internal static string getPrecioTotal(decimal r)
        {
            string total;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@reserva", r));
            object resultadoStoreProcedure = ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.CalcularTotalAux", SCALAR, parametros);
            total = ((resultadoStoreProcedure != null) ? Convert.ToString(resultadoStoreProcedure) : "");
            return total;
        }

        internal static void facturar(decimal reserva, decimal total)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@reserva", reserva));
            parametros.Add(new SqlParameter("@total", total));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.facturar", NONQUERY, parametros);
        }

        internal static DataTable getReservasActualesSinCheckin(int h)
        {
            List<SqlParameter> parametrosStore = new List<SqlParameter>();
            parametrosStore.Add(new SqlParameter("@h", h));

            SqlDataReader readerReserva = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.getresactsinchec", READER, parametrosStore);
            DataTable reserva = new DataTable();
            if (readerReserva.HasRows)
            {
                reserva.Load(readerReserva);
            }
            readerReserva.Dispose();
            return reserva;
        }

        internal static void checkearHabitacion(int hotel, decimal habitacion, decimal reserva)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@reserva", reserva));
            parametros.Add(new SqlParameter("@hotel", hotel));
            parametros.Add(new SqlParameter("@habitacion", habitacion));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.checkin", NONQUERY, parametros);
        }

        internal static void crearEstadia(decimal reserva)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@reserva", reserva));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.crearEstadia", NONQUERY, parametros);
        }

        public static DataTable obtenerReserva(decimal codigoReserva)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigoReserva", codigoReserva));
            SqlDataReader readerReserva = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure(SP_OBTENER_RESERVA, READER, parametros);
            DataTable reserva = new DataTable();
            if (readerReserva.HasRows)
            {
                reserva.Load(readerReserva);
            }
            readerReserva.Dispose();
            return reserva;

        }

        internal static DataTable buscarHoteles(string ciudad, string calle, string ncalle, string cantes, string recantes, string mail, string pais, string nombre, string telefono, DateTime fecha, bool usarfecha, bool hab)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ciudad", ciudad));
            parametros.Add(new SqlParameter("@calle", calle));
            parametros.Add(new SqlParameter("@ncalle", ncalle));
            parametros.Add(new SqlParameter("@cantes", cantes));
            parametros.Add(new SqlParameter("@recantes", recantes));
            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@pais", pais));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@telefono", telefono));
            if (usarfecha)
                parametros.Add(new SqlParameter("@fecha", fecha));
            else
                parametros.Add(new SqlParameter("@fecha", DBNull.Value));
            parametros.Add(new SqlParameter("@habilitado", hab ? 1 : 0));

            SqlDataReader readerhoteles = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.buscarhoteles", READER, parametros);
            DataTable tablahoteles = new DataTable();
            if (readerhoteles.HasRows)
            {
                tablahoteles.Load(readerhoteles);
            }
            readerhoteles.Dispose();
            return tablahoteles;
        }

        internal static int darBajaHotel(int id, string motivo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            parametros.Add(new SqlParameter("@motivo", motivo));

            return Convert.ToInt32(ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.bajaHotel", SCALAR, parametros));
        }

        public static int darBajaHabitacion(decimal nroHabitacion, int hotel)
        {
            List<SqlParameter> parametrosStore = new List<SqlParameter>();
            parametrosStore.Add(new SqlParameter("@Nro_Habitacion", nroHabitacion));
            parametrosStore.Add(new SqlParameter("@Hotel", hotel));

            return Convert.ToInt32(ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.bajaHabitacion", SCALAR, parametrosStore));
        }

        internal static void modificarHotel(int idhotel, string ciudad, string calle, string ncalle, string cantes, string reccantes, string mail, string pais, string nombre, string telefono)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idhotel", idhotel));
            parametros.Add(new SqlParameter("@ciudad", ciudad));
            parametros.Add(new SqlParameter("@calle", calle));

            if (ncalle == "")
                parametros.Add(new SqlParameter("@ncalle", null));
            else
                parametros.Add(new SqlParameter("@ncalle", Convert.ToDecimal(ncalle)));

            if (cantes == "")
                parametros.Add(new SqlParameter("@cantes", null));
            else
                parametros.Add(new SqlParameter("@cantes", Convert.ToDecimal(cantes)));

            if (reccantes == "")
                parametros.Add(new SqlParameter("@reccantes", null));
            else
                parametros.Add(new SqlParameter("@reccantes", Convert.ToDecimal(reccantes)));

            if (telefono == "")
                parametros.Add(new SqlParameter("@telefono", null));
            else
                parametros.Add(new SqlParameter("@telefono", Convert.ToDecimal(telefono)));

            parametros.Add(new SqlParameter("@mail", mail));
            parametros.Add(new SqlParameter("@pais", pais));
            parametros.Add(new SqlParameter("@nombre", nombre));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.ModificarHotel", NONQUERY, parametros);
        }

        internal static void modificarHabitacion(decimal habNum, int hotel, string piso, int tipo, bool frente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@habNum", habNum));
            parametros.Add(new SqlParameter("@hotel", hotel));

            if (piso == "")
                parametros.Add(new SqlParameter("@piso", null));
            else
                parametros.Add(new SqlParameter("@piso", Convert.ToDecimal(piso)));

            parametros.Add(new SqlParameter("@tipo", tipo));
            parametros.Add(new SqlParameter("@frente", frente ? "S" : "N"));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.ModificarHabitacion", NONQUERY, parametros);
        }

        internal static void habilitarHabitacion(decimal habNum, int hotel)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idhotel", hotel));
            parametros.Add(new SqlParameter("@habNum", habNum));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.habilitarHabitacion", NONQUERY, parametros);
        }

        internal static void habilitarHotel(int idhotel)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idhotel", idhotel));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.habilitarHotel", NONQUERY, parametros);
        }

        internal static int obtenernrotipodehabconnombre(string nombre)
        {
            List<SqlParameter> parametrosStore = new List<SqlParameter>();
            parametrosStore.Add(new SqlParameter("@nombre", nombre));

            return Convert.ToInt32(ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.obtenernrotipodehabconnombre", SCALAR, parametrosStore));
        }

        internal static void modificarReserva(decimal reservaCodigo, int hotelID, DateTime fechaDesde, DateTime fechaHasta, int regimenCodigo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@reservaCodigo", reservaCodigo));
            parametros.Add(new SqlParameter("@hotelID", hotelID));
            parametros.Add(new SqlParameter("@fechaInicio", fechaDesde));
            parametros.Add(new SqlParameter("@fechaFin", fechaHasta));
            parametros.Add(new SqlParameter("@regimenCodigo", regimenCodigo));
            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_MODIFICAR_RESERVA, NONQUERY, parametros);
        }

        internal static void eliminarReservaPorHabitacion(decimal reservaCodigo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@reservaCodigo", reservaCodigo));
            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_ELIMINAR_RESERVAS_POR_HABITACION, NONQUERY, parametros);
        }

        internal static void darBajaUsuario(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));

          ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.bajaUsuario", NONQUERY, parametros);
 
        }

        internal static void bajaReserva(decimal reservaCodigo, string motivo, int hotelID, int usuarioID, DateTime fecha, int rolCodigo,string estado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@reservaCodigo", reservaCodigo));
            parametros.Add(new SqlParameter("@motivoCancelacion", motivo));
            parametros.Add(new SqlParameter("@hotelID", hotelID));
            parametros.Add(new SqlParameter("@usuarioID", usuarioID));
            parametros.Add(new SqlParameter("@fechaCancelacion", fecha));
            parametros.Add(new SqlParameter("@rolCod", rolCodigo));
            parametros.Add(new SqlParameter("@estado", estado));

            ConexionDB.ConexionDB.InvocarStoreProcedure(SP_BAJA_RESERVA, NONQUERY, parametros);

        }

        internal static void habODeshabFuncporRol(string nombre, int func, int hab)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@funcionalidad", func));
            parametros.Add(new SqlParameter("@habilitado", hab));

            ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.habODeshabFuncporRol", NONQUERY, parametros);

        }

        internal static List<byte> getfuncporrolhab(int codigo_rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo_rol", codigo_rol));

            SqlDataReader readerhoteles = (SqlDataReader)ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.getfuncporrolhab", READER, parametros);
            List<byte> lista = new List<byte>();
            while (readerhoteles.Read())
                lista.Add((byte)readerhoteles["Funcionalidad_Cod"]);
            readerhoteles.Dispose();
            return lista;
        }

        internal static int getPrecioHabitacion(decimal tipoHabSeleccionada, int codigoRegimen,int hotel)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipoHabSeleccionada", tipoHabSeleccionada));
            parametros.Add(new SqlParameter("@codigoRegimen", codigoRegimen));
            parametros.Add(new SqlParameter("@hotelcod", hotel));

            object resultadoStoreProcedure = ConexionDB.ConexionDB.InvocarStoreProcedure("ELITE4.getPrecioHabitacion", SCALAR, parametros);
            return ((resultadoStoreProcedure != null) ? Convert.ToInt32(resultadoStoreProcedure) : 0);
        }
    }
}