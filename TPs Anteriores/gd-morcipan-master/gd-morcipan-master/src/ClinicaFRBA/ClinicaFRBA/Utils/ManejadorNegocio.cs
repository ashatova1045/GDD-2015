using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

using System.Globalization;
using ClinicaFRBA.Utils.Seguridad;

namespace ClinicaFRBA.Utils
{
    static class ManejadorNegocio
    {
        #region Constantes

        #region Nombres SP
        private const string SP_REGISTRAR_FECHA_DEL_SISTEMA = "gd_MORCIPAN.spInsertarFechaFuncionamiento";
        private const string SP_ES_USUARIO_VALIDO = "gd_MORCIPAN.spEsUsuarioValido";
        private const string SP_ES_ROL_VALIDO_PARA_USUARIO = "gd_MORCIPAN.spEsRolValidoParaUsuario";
        private const string SP_OBTENER_ROLES_PARA_USUARIO = "gd_MORCIPAN.spObtenerRolesParaUsuario";
        private const string SP_INACTIVAR_USUARIO = "gd_MORCIPAN.spInactivarUsuario";
        private const string SP_OBTENER_ROLES_DEL_SISTEMA = "gd_MORCIPAN.spObtenerRolesUsuario";
        private const string SP_OBTENER_AFILIADO_PARA_USUARIO = "gd_MORCIPAN.spObtenerAfiliadoParaUsuario";
        private const string SP_OBTENER_PROFESIONAL_PARA_USUARIO = "gd_MORCIPAN.spObtenerProfesionalParaUsuario";
        private const string SP_OBTENER_FUNCIONALIDADES = "gd_MORCIPAN.spObtenerFuncionalidades";
        private const string SP_OBTENER_FUNCIONALIDADES_POR_ROL_ID = "gd_MORCIPAN.spObtenerFuncionalidadesPorRolId";
        private const string SP_BUSCAR_ROLES_POR_NOMBRE = "gd_MORCIPAN.spBuscarRolesPorNombre";
        private const string SP_ELIMINAR_FUNCIONALIDADES_POR_ROL_ID = "gd_MORCIPAN.spEliminarFuncionalidadesDeRolPorId";
        private const string SP_AGREGAR_FUNCIONALIDAD_ID_A_ROL_POR_ID = "gd_MORCIPAN.spAgregarFuncionalidadIdARolPorId";
        private const string SP_ACTUALIZAR_NOMBRE_ROL = "gd_MORCIPAN.spActualizarNombreRol";
        private const string SP_REGISTRO_CAMBIO_PLAN_AFILIADO = "gd_MORCIPAN.spRegistroCambioPlanAfiliado";
        private const string SP_ELIMINAR_ROL_POR_ID = "gd_MORCIPAN.spEliminarRolPorId";
        private const string SP_INSERTAR_O_ACTIVAR_ROL = "gd_MORCIPAN.spInsertarOActivarRol";
        private const string SP_ALTA_PROFESIONAL = "gd_MORCIPAN.spAltaProfesional";
        private const string SP_ALTA_ESPECIALIDAD_X_PROFESIONAL = "gd_MORCIPAN.spAltaEspecialidadPorProfesional";
        private const string SP_BAJA_ESPECIALIDAD_X_PROFESIONAL = "gd_MORCIPAN.spBajaEspecialidadPorProfesional";
        private const string SP_OBTENER_ID_ESPECIALIDAD = "gd_MORCIPAN.spObtenerIDespecialidad";
        //private const string SP_BUSCAR_PROFESIONALES = "gd_MORCIPAN.spBuscarProfesional";
        private const string SP_BUSCAR_PROFESIONALES = "gd_MORCIPAN.spBuscarProfesionalFull";
        private const string SP_BAJA_PROFESIONAL = "gd_MORCIPAN.spBajaLogicaProfesionalPorId";
        private const string SP_OBTENER_NUEVA_SECUENCIA_DE_TABLA = "gd_MORCIPAN.spObtenerNuevaSecuenciaTabla";
        private const string SP_OBTENER_PROXIMO_NRO_AFILIADO_FAMILIA = "gd_MORCIPAN.spObtenerProximoNroAfiliadoFamilia";
        private const string SP_OBTENER_PLANES_MEDICOS = "gd_MORCIPAN.spObtenerPlanesMedicos";
        private const string SP_INSERTAR_AFILIADO = "gd_MORCIPAN.spInsertarAfiliado";
        private const string SP_BUSCAR_AFILIADO = "gd_MORCIPAN.spBuscarAfiliado";
        private const string SP_ELIMINAR_AFILIADO_POR_ID = "gd_MORCIPAN.spEliminarAfiliadoPorId";
        private const string SP_CANCELAR_TURNO_AFILIADO = "gd_MORCIPAN.spCancelarTurnoAfiliado";
        private const string SP_CANCELAR_PROFESIONAL_DIA = "gd_MORCIPAN.spCancelarTurnoProfesionalDia";
        private const string SP_MODIFICAR_AFILIADO = "gd_MORCIPAN.spModificarAfiliado";
        private const string SP_INSERTAR_BONO_CONSULTA = "gd_MORCIPAN.spInsertarBonoConsulta";
        private const string SP_INSERTAR_BONO_FARMACIA = "gd_MORCIPAN.spInsertarBonoFarmacia";
        private const string SP_INSERTAR_COMPRA_TOTAL = "gd_MORCIPAN.spInsertarCompraTotal";
        private const string SP_INSERTAR_CONSULTA_MEDICA = "gd_MORCIPAN.spInsertarConsultaMedica";
        private const string SP_OBTENER_PRECIOS_BONOS = "gd_MORCIPAN.spObtenerPreciosBonos";
        private const string SP_OBTENER_BONOS_AFILIADO = "gd_MORCIPAN.spObtenerBonosAfiliado";
        private const string SP_OBTENER_TURNOS_AFILIADO = "gd_MORCIPAN.spObtenerTurnosAfiliado";
        private const string SP_OBTENER_TURNOS_AFILIADO_SIN_CONSULTA = "gd_MORCIPAN.spObtenerTurnosAfiliadoSinConsulta";
        private const string SP_OBTENER_ESPECIALIDADES = "gd_MORCIPAN.spObtenerEspecialidades";
        private const string SP_OBTENER_ESPECIALIDADES_POR_PROFESIONAL = "gd_MORCIPAN.spObtenerEspecialidadesProfesional";
        private const string SP_OBTENER_RANGO_FECHAS_AGENDA_PROFESIONAL = "gd_MORCIPAN.spObtenerRangoFechasAgendaProfesional";
        private const string SP_LISTAR_TURNOS_PROFESIONAL_DIA = "gd_MORCIPAN.spListarTurnosProfesionalDia";
        private const string SP_LISTAR_TURNOS_PROFESIONAL_DIA_SIN_CONSULTAS = "gd_MORCIPAN.spListarTurnosProfesionalDiaSinConsulta";
        private const string SP_MODIFICAR_PROFESIONAL = "gd_MORCIPAN.spModificarProfesional";
        private const string SP_REGISTRAR_TURNO_AFILIADO = "gd_MORCIPAN.spRegistrarTurnoAfiliado";
        private const string SP_CREAR_AGENDA_PROFESIONAL = "gd_MORCIPAN.spCrearAgendaProfesional";
        private const string SP_LISTADO_1 = "gd_MORCIPAN.spListado1";
        private const string SP_LISTADO_2 = "gd_MORCIPAN.spListado2";
        private const string SP_LISTADO_3 = "gd_MORCIPAN.spListado3";
        private const string SP_LISTADO_4 = "gd_MORCIPAN.spListado4";
        private const string SP_LISTAR_CONSULTAS_MEDICAS_ABIERTAS = "gd_MORCIPAN.spListarConsultasMedicasAbiertasProfesionalDia";
        private const string SP_CONCLUIR_CONSULTA_MEDICA = "gd_MORCIPAN.spConfirmarConsultaMedica";
        private const string SP_BUSCAR_MEDICAMENTOS = "gd_MORCIPAN.spListarMedicamentosLike";
        private const string SP_INSERTAR_RECETA = "gd_MORCIPAN.spInsertarRecetaMedica";
        private const string SP_ASOCIAR_BONO_CON_MEDICAMENTOS = "gd_MORCIPAN.spAsociarRecetaBonosFarmaciaMedicamentos";
        private const string SP_VERIFICAR_BONO_FARMACIA = "gd_MORCIPAN.spVerificarBonoValidoFarmacia";
        #endregion

        #region Tipos de Comandos
        private const string EXECUTE_NON_QUERY = "NON_QUERY";
        private const string EXECUTE_ESCALAR = "ESCALAR";
        private const string EXECUTE_READER = "READER";
        #endregion

        #endregion

        public static void registrarFechaDelSistema(DateTime fechaARegistrar)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@fecha", fechaARegistrar));
            int fechaRegistrada = (int)ManejadorBD.EjecutarSP(SP_REGISTRAR_FECHA_DEL_SISTEMA, parametrosSP, EXECUTE_NON_QUERY);
        }

        public static int usuarioValido(string usuario, string password)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@usuario", usuario));
            parametrosSP.Add(new SqlParameter("@password", password));
            object res = ManejadorBD.EjecutarSP(SP_ES_USUARIO_VALIDO, parametrosSP, EXECUTE_ESCALAR);
            int idUsuario = ((res != null) ? Convert.ToInt32(res) : 0);
            return idUsuario;
        }

        public static DataTable obtenerRolesParaUsuario(int usuario_id)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@usuario_id", usuario_id));
            SqlDataReader readerRolesUsuario = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_ROLES_DEL_SISTEMA, parametrosSP, EXECUTE_READER);
            DataTable rolesDeUsuario = new DataTable();
            if (readerRolesUsuario.HasRows)
            {
                rolesDeUsuario.Load(readerRolesUsuario);
            }
            readerRolesUsuario.Dispose();
            return rolesDeUsuario;
        }
        public static bool rolValidoParaUsuario(int usuario_id, int rol_id)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@usuario_id", usuario_id));
            parametrosSP.Add(new SqlParameter("@rol_id", rol_id));
            int cantRolDeUsuarios = (int)ManejadorBD.EjecutarSP(SP_ES_ROL_VALIDO_PARA_USUARIO, parametrosSP, EXECUTE_ESCALAR);
            return (cantRolDeUsuarios > 0);
        }
        public static void inhabilitarUsuario(string usuario)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@usuario", usuario));
            int usuarioInactivado = (int)ManejadorBD.EjecutarSP(SP_INACTIVAR_USUARIO, parametrosSP, EXECUTE_NON_QUERY);
        }

        public static int obtenerAfiliadoParaUsuario(int usuario_id)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@usuario_id", usuario_id));
            object res = ManejadorBD.EjecutarSP(SP_OBTENER_AFILIADO_PARA_USUARIO, parametrosSP, EXECUTE_ESCALAR);
            int nroAfiliado = ((res != null) ? Convert.ToInt32(res) : 0);
            return nroAfiliado;
        }

        public static int obtenerProfesionalParaUsuario(int usuario_id)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@usuario_id", usuario_id));
            object res = ManejadorBD.EjecutarSP(SP_OBTENER_PROFESIONAL_PARA_USUARIO, parametrosSP, EXECUTE_ESCALAR);
            int profId = ((res != null) ? Convert.ToInt32(res) : 0);
            return profId;
        }

        public static DataTable obtenerRolesDelSistema()
        {
            SqlDataReader readerRolesDelSistema = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_ROLES_DEL_SISTEMA, null, EXECUTE_READER);
            DataTable rolesDelSistema = new DataTable();
            if (readerRolesDelSistema.HasRows)
            {
                rolesDelSistema.Load(readerRolesDelSistema);
            }
            readerRolesDelSistema.Dispose();
            return rolesDelSistema;
        }

        public static DataTable obtenerFuncionalidadesPorRol(int rol_id)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@rol_id", rol_id));
            SqlDataReader readerFuncionalidadesDelRol = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_FUNCIONALIDADES_POR_ROL_ID, parametrosSP, EXECUTE_READER);
            DataTable funcionesDelRol = new DataTable();
            if (readerFuncionalidadesDelRol.HasRows)
            {
                funcionesDelRol.Load(readerFuncionalidadesDelRol);
            }
            readerFuncionalidadesDelRol.Dispose();
            return funcionesDelRol;
        }

        public static DataTable obtenerFuncionalidades()
        {
            SqlDataReader readerFuncionalidades = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_FUNCIONALIDADES, null, EXECUTE_READER);
            DataTable funcionalidades = new DataTable();
            if (readerFuncionalidades.HasRows)
            {
                funcionalidades.Load(readerFuncionalidades);
            }
            readerFuncionalidades.Dispose();
            return funcionalidades;
        }

        public static DataTable buscarRolesPorNombre(string rol_nombre)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            if (rol_nombre == String.Empty)
            {
                rol_nombre = "-2";
            }
            parametrosSP.Add(new SqlParameter("@rol", rol_nombre));
            SqlDataReader readerRoles = (SqlDataReader)ManejadorBD.EjecutarSP(SP_BUSCAR_ROLES_POR_NOMBRE, parametrosSP, EXECUTE_READER);
            DataTable roles = new DataTable();
            if (readerRoles.HasRows)
            {
                roles.Load(readerRoles);
            }
            readerRoles.Dispose();
            return roles;
        }

        public static int actualizarFuncionalidadesRol(int rol_id, List<int> funciones_ids)
        {
            int resultadoActualizacion = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@rol_id", rol_id));

            // ELIMINO TODAS LAS FUNCIONALIDADES DEL ROL
            resultadoActualizacion += (int)ManejadorBD.EjecutarSP(SP_ELIMINAR_FUNCIONALIDADES_POR_ROL_ID, parametrosSP, EXECUTE_NON_QUERY);
            // INSERTO LAS FUNCIONALIDADES SELECCIONADAS
            foreach (int funcion_id in funciones_ids)
            {
                parametrosSP.Add(new SqlParameter("@funcion_id", funcion_id));
                resultadoActualizacion += (int)ManejadorBD.EjecutarSP(SP_AGREGAR_FUNCIONALIDAD_ID_A_ROL_POR_ID, parametrosSP, EXECUTE_NON_QUERY);
                parametrosSP.RemoveAt(parametrosSP.Count - 1);
            }

            return resultadoActualizacion;
        }

        public static int actualizarNombreRol(int rol_id, string rol_nombre)
        {
            int resultadoActualizacion = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@rol_id", rol_id));
            parametrosSP.Add(new SqlParameter("@rol_nombre", rol_nombre));

            resultadoActualizacion += (int)ManejadorBD.EjecutarSP(SP_ACTUALIZAR_NOMBRE_ROL, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoActualizacion;
        }

        public static int eliminarRol(int rol_id)
        {
            int resultadoEliminacion = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@rol_id", rol_id));

            resultadoEliminacion = (int)ManejadorBD.EjecutarSP(SP_ELIMINAR_ROL_POR_ID, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoEliminacion;
        }

        public static int insertarOActivarRol(string rol_nombre)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@rol_nombre", rol_nombre));
            object res = ManejadorBD.EjecutarSP(SP_INSERTAR_O_ACTIVAR_ROL, parametrosSP, EXECUTE_ESCALAR);
            int resultadoArgegar = ((res != null) ? Convert.ToInt32(res) : 0);
            return resultadoArgegar;
        }

        public static int obtenerNuevaSecuenciaDeTabla(string nombreDeTabla, int valorInicial, int valorIncremento)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@nombre_tabla", nombreDeTabla));
            parametrosSP.Add(new SqlParameter("@retornar", "0"));
            parametrosSP.Add(new SqlParameter("@inicial", valorInicial));
            parametrosSP.Add(new SqlParameter("@incremento", valorIncremento));
            int secuenciaAfiliado = (int)ManejadorBD.EjecutarSP(SP_OBTENER_NUEVA_SECUENCIA_DE_TABLA, parametrosSP, EXECUTE_ESCALAR);
            return secuenciaAfiliado;
        }

        public static int obtenerProximoNroAfiliadoFamilia(int afiliado_numero)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            int secuenciaAfiliado = (int)ManejadorBD.EjecutarSP(SP_OBTENER_PROXIMO_NRO_AFILIADO_FAMILIA, parametrosSP, EXECUTE_ESCALAR);
            return secuenciaAfiliado;
        }

        public static DataTable obtenerPlanesMedicos()
        {
            SqlDataReader readerPlanesMedicos = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_PLANES_MEDICOS, null, EXECUTE_READER);
            DataTable planesMedico = new DataTable();
            if (readerPlanesMedicos.HasRows)
            {
                planesMedico.Load(readerPlanesMedicos);
            }
            readerPlanesMedicos.Dispose();
            return planesMedico;
        }

        public static int insertarAfiliado(int afiliado_numero, 
                                           string afiliado_nombre,
                                           string afiliado_apellido,
                                           string afiliado_tipo_documento,
                                           int afiliado_nro_documento,
                                           string afiliado_direccion,
                                           int afiliado_telefono,
                                           string afiliado_email,
                                           string afiliado_fecha_nacimiento,
                                           string afiliado_sexo,
                                           string afiliado_estado_civil,
                                           int afiliado_cant_familiares_cargo,
                                           string afiliado_plan_medico) 
        {
            int resultadoArgegar = 0;

            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@afiliado_nombre", afiliado_nombre));
            parametrosSP.Add(new SqlParameter("@afiliado_apellido", afiliado_apellido));
            parametrosSP.Add(new SqlParameter("@afiliado_tipo_documento", afiliado_tipo_documento));
            parametrosSP.Add(new SqlParameter("@afiliado_nro_documento", afiliado_nro_documento));
            parametrosSP.Add(new SqlParameter("@afiliado_direccion", afiliado_direccion));
            parametrosSP.Add(new SqlParameter("@afiliado_telefono", afiliado_telefono));
            parametrosSP.Add(new SqlParameter("@afiliado_email", afiliado_email));
            parametrosSP.Add(new SqlParameter("@afiliado_fecha_nacimiento", DateTime.ParseExact(afiliado_fecha_nacimiento,"dd/MM/yyyy",CultureInfo.CurrentCulture)));
            parametrosSP.Add(new SqlParameter("@afiliado_sexo", afiliado_sexo));
            parametrosSP.Add(new SqlParameter("@afiliado_estado_civil", afiliado_estado_civil));
            parametrosSP.Add(new SqlParameter("@afiliado_cant_familiares_cargo", afiliado_cant_familiares_cargo));
            parametrosSP.Add(new SqlParameter("@afiliado_plan_medico", afiliado_plan_medico));

            resultadoArgegar = (int)ManejadorBD.EjecutarSP(SP_INSERTAR_AFILIADO, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoArgegar;
        }

        public static DataTable buscarAfiliados(int afiliado_numero,
                                                string afiliado_plan_medico,
                                                string afiliado_nombre,
                                                string afiliado_apellido,
                                                string afiliado_tipo_documento,
                                                int afiliado_nro_documento,
                                                string afiliado_sexo,
                                                string afiliado_estado_civil)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@afiliado_plan_medico_codigo", afiliado_plan_medico));
            parametrosSP.Add(new SqlParameter("@afiliado_nombre", afiliado_nombre));
            parametrosSP.Add(new SqlParameter("@afiliado_apellido", afiliado_apellido));
            parametrosSP.Add(new SqlParameter("@afiliado_tipo_documento", afiliado_tipo_documento));
            parametrosSP.Add(new SqlParameter("@afiliado_nro_documento", afiliado_nro_documento));
            parametrosSP.Add(new SqlParameter("@afiliado_direccion", "- 2"));
            parametrosSP.Add(new SqlParameter("@afiliado_telefono", -2));
            parametrosSP.Add(new SqlParameter("@afiliado_email", "- 2"));
            parametrosSP.Add(new SqlParameter("@afiliado_fecha_nacimiento", Convert.ToDateTime("1900-01-01 00:00:00.000")));
            parametrosSP.Add(new SqlParameter("@afiliado_sexo", afiliado_sexo));
            parametrosSP.Add(new SqlParameter("@afiliado_estado_civil", afiliado_estado_civil));
            parametrosSP.Add(new SqlParameter("@afiliado_cant_familiares_cargo", -2));
            SqlDataReader readerAfiliados = (SqlDataReader)ManejadorBD.EjecutarSP(SP_BUSCAR_AFILIADO, parametrosSP, EXECUTE_READER);
            DataTable afiliados = new DataTable();
            if (readerAfiliados.HasRows)
            {
                afiliados.Load(readerAfiliados);
            }
            readerAfiliados.Dispose();
            return afiliados;
        }

        public static int registroCambioPlanMedico(int afiliado_numero,
                                                   string plan_descripcion_ant,
                                                   string plan_descripcion_act,
                                                   string cambio_motivo)
        {
            int resultadoActualizacion = 0;

            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@plan_descripcion_ant", plan_descripcion_ant));
            parametrosSP.Add(new SqlParameter("@plan_descripcion_act", plan_descripcion_act));
            parametrosSP.Add(new SqlParameter("@cambio_motivo", cambio_motivo));

            resultadoActualizacion = (int)ManejadorBD.EjecutarSP(SP_REGISTRO_CAMBIO_PLAN_AFILIADO, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoActualizacion;
        }

        public static int actualizarAfiliado(int afiliado_numero,
                                           string afiliado_nombre,
                                           string afiliado_apellido,
                                           string afiliado_tipo_documento,
                                           int afiliado_nro_documento,
                                           string afiliado_direccion,
                                           int afiliado_telefono,
                                           string afiliado_email,
                                           string afiliado_fecha_nacimiento,
                                           string afiliado_sexo,
                                           string afiliado_estado_civil,
                                           int afiliado_cant_familiares_cargo,
                                           string afiliado_plan_medico)
        {
            int resultadoActualizacion = 0;

            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@afiliado_nombre", afiliado_nombre));
            parametrosSP.Add(new SqlParameter("@afiliado_apellido", afiliado_apellido));
            parametrosSP.Add(new SqlParameter("@afiliado_tipo_documento", afiliado_tipo_documento));
            parametrosSP.Add(new SqlParameter("@afiliado_nro_documento", afiliado_nro_documento));
            parametrosSP.Add(new SqlParameter("@afiliado_direccion", afiliado_direccion));
            parametrosSP.Add(new SqlParameter("@afiliado_telefono", afiliado_telefono));
            parametrosSP.Add(new SqlParameter("@afiliado_email", afiliado_email));
            parametrosSP.Add(new SqlParameter("@afiliado_fecha_nacimiento", DateTime.ParseExact(afiliado_fecha_nacimiento, "dd/MM/yyyy", CultureInfo.CurrentCulture)));
            parametrosSP.Add(new SqlParameter("@afiliado_sexo", afiliado_sexo));
            parametrosSP.Add(new SqlParameter("@afiliado_estado_civil", afiliado_estado_civil));
            parametrosSP.Add(new SqlParameter("@afiliado_cant_familiares_cargo", afiliado_cant_familiares_cargo));
            parametrosSP.Add(new SqlParameter("@afiliado_plan_medico_codigo", afiliado_plan_medico));

            resultadoActualizacion = (int)ManejadorBD.EjecutarSP(SP_MODIFICAR_AFILIADO, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoActualizacion;
        }

        public static int eliminarAfiliado(int afiliado_numero)
        {
            int resultadoEliminacion = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));

            resultadoEliminacion = (int)ManejadorBD.EjecutarSP(SP_ELIMINAR_AFILIADO_POR_ID, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoEliminacion;
        }

        public static int cancelarTurnoAfiliado(int turno_numero,
                                                string tipo_cancelacion,
                                                string motivo_cancelacion)
        {
            int resultadoCancelcion = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@turno_numero", turno_numero));
            parametrosSP.Add(new SqlParameter("@tipo_cance", tipo_cancelacion));
            parametrosSP.Add(new SqlParameter("@motivo", motivo_cancelacion));

            resultadoCancelcion = (int)ManejadorBD.EjecutarSP(SP_CANCELAR_TURNO_AFILIADO, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoCancelcion;
        }

        public static int cancelarProfesionalDia(int prof_id,
                                                 DateTime fecha,
                                                 string tipo_cancelacion,
                                                 string motivo_cancelacion)
        {
            int resultadoCancelcion = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
            parametrosSP.Add(new SqlParameter("@fecha", fecha));
            parametrosSP.Add(new SqlParameter("@tipo_canc", tipo_cancelacion));
            parametrosSP.Add(new SqlParameter("@motivo", motivo_cancelacion));

            resultadoCancelcion = (int)ManejadorBD.EjecutarSP(SP_CANCELAR_PROFESIONAL_DIA, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoCancelcion;
        }

        public static decimal obtenerPrecioBonoConsulta(string planAfiliado)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_plan_medico", planAfiliado));
            parametrosSP.Add(new SqlParameter("@tipo_bono", "CONSULTA"));
            decimal precioBonoConsulta = (decimal)ManejadorBD.EjecutarSP(SP_OBTENER_PRECIOS_BONOS, parametrosSP, EXECUTE_ESCALAR);
            return precioBonoConsulta;
        }

        public static decimal obtenerPrecioBonoFarmacia(string planAfiliado)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_plan_medico", planAfiliado));
            parametrosSP.Add(new SqlParameter("@tipo_bono", "FARMACIA"));
            decimal precioBonoFarmacia = (decimal)ManejadorBD.EjecutarSP(SP_OBTENER_PRECIOS_BONOS, parametrosSP, EXECUTE_ESCALAR);
            return precioBonoFarmacia;
        }

        public static DataTable obtenerTurnosAfiliado(int afiliado_numero)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            SqlDataReader readerTurnosAfiliado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_TURNOS_AFILIADO, parametrosSP, EXECUTE_READER);
            DataTable turnosAfiliado = new DataTable();
            if (readerTurnosAfiliado.HasRows)
            {
                turnosAfiliado.Load(readerTurnosAfiliado);
            }
            readerTurnosAfiliado.Dispose();
            return turnosAfiliado;
        }

        public static DataTable obtenerTurnosAfiliadoSinConsulta(int afiliado_numero)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            SqlDataReader readerTurnosAfiliado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_TURNOS_AFILIADO_SIN_CONSULTA, parametrosSP, EXECUTE_READER);
            DataTable turnosAfiliado = new DataTable();
            if (readerTurnosAfiliado.HasRows)
            {
                turnosAfiliado.Load(readerTurnosAfiliado);
            }
            readerTurnosAfiliado.Dispose();
            return turnosAfiliado;
        }


        public static DataTable obtenerBonosConsultaParaAfiliado(int afiliado_numero)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@tipo_bono", "consulta"));
            SqlDataReader readerBonosAfiliado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_BONOS_AFILIADO, parametrosSP, EXECUTE_READER);
            DataTable bonosAfiliado = new DataTable();
            if (readerBonosAfiliado.HasRows)
            {
                bonosAfiliado.Load(readerBonosAfiliado);
            }
            readerBonosAfiliado.Dispose();
            return bonosAfiliado;
        }

        public static int insertarCompraTotal(int afiliado_numero,
                                              int cantidad_bonos_consulta,
                                              int cantidad_bonos_farmacia,
                                              decimal monto_total)
        {
            int resultadoArgegar = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@cantiadad_bono_con", cantidad_bonos_consulta));
            parametrosSP.Add(new SqlParameter("@cantiadad_bono_far", cantidad_bonos_farmacia));
            parametrosSP.Add(new SqlParameter("@monto_total", monto_total));

            resultadoArgegar = (int)ManejadorBD.EjecutarSP(SP_INSERTAR_COMPRA_TOTAL, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoArgegar;
        }

        public static int insertarBonoConsulta(int afiliado_numero,
                                               string afiliado_plan)
        {
            int resultadoArgegar = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@plan", afiliado_plan));

            resultadoArgegar = (int)ManejadorBD.EjecutarSP(SP_INSERTAR_BONO_CONSULTA, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoArgegar;
        }

        public static int insertarBonoFarmacia(int afiliado_numero,
                                               string afiliado_plan)
        {
            int resultadoArgegar = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@plan", afiliado_plan));

            resultadoArgegar = (int)ManejadorBD.EjecutarSP(SP_INSERTAR_BONO_FARMACIA, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoArgegar;
        }

        public static int insertarConsultaMedica(int turno_numero, int afiliado_numero, int bono_consulta_numero)
        {
            int resultadoArgegar = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@turno_numero", turno_numero));
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@bono_consulta_numero", bono_consulta_numero));

            resultadoArgegar = (int)ManejadorBD.EjecutarSP(SP_INSERTAR_CONSULTA_MEDICA, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoArgegar;
        }

        public static DataTable obtenerRangoFechasAgendaProfesional(int profesional_id)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@profesional_id", profesional_id));
            SqlDataReader readerRangoFechas = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_RANGO_FECHAS_AGENDA_PROFESIONAL, parametrosSP, EXECUTE_READER);
            DataTable rangoFechas = new DataTable();
            if (readerRangoFechas.HasRows)
            {
                rangoFechas.Load(readerRangoFechas);
            }
            readerRangoFechas.Dispose();
            return rangoFechas;
        }

        public static DataTable listarTurnosProfesionalDia(DateTime fecha, 
                                                           int profesional_id,
                                                           string condicion)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@fecha", fecha));
            parametrosSP.Add(new SqlParameter("@prof_id", profesional_id));
            parametrosSP.Add(new SqlParameter("@cond", condicion));
            SqlDataReader readerTurnosProfesional = (SqlDataReader)ManejadorBD.EjecutarSP(SP_LISTAR_TURNOS_PROFESIONAL_DIA, parametrosSP, EXECUTE_READER);
            DataTable turnosFechas = new DataTable();
            if (readerTurnosProfesional.HasRows)
            {
                turnosFechas.Load(readerTurnosProfesional);
            }
            readerTurnosProfesional.Dispose();
            return turnosFechas;
        }

        public static int regstrarTurnoAfiliado(int afiliado_numero,
                                                int turno_numero)
        {
            int resultadoRegistrar = 0;
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@afiliado_numero", afiliado_numero));
            parametrosSP.Add(new SqlParameter("@turno_numero", turno_numero));

            resultadoRegistrar = (int)ManejadorBD.EjecutarSP(SP_REGISTRAR_TURNO_AFILIADO, parametrosSP, EXECUTE_NON_QUERY);

            return resultadoRegistrar;
        }

        internal static int AltaProfesional(string nombre, string apellido,string tipoDoc, string dni, string sexo, DateTime fechaNac, string direccion, string telefono, string matricula,string mail, System.Windows.Forms.CheckedListBox cListEspecialidades)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@prof_nombre", nombre));
            parametrosSP.Add(new SqlParameter("@prof_apellido", apellido));
            parametrosSP.Add(new SqlParameter("@prof_num_dni", dni));
            parametrosSP.Add(new SqlParameter("@prof_sex", sexo));
            parametrosSP.Add(new SqlParameter("@prof_fechaNac", fechaNac));
            parametrosSP.Add(new SqlParameter("@prof_direccion", direccion));
            parametrosSP.Add(new SqlParameter("@prof_telefono", telefono));
            parametrosSP.Add(new SqlParameter("@prof_matr", matricula));
            parametrosSP.Add(new SqlParameter("@prof_mail", mail));
            parametrosSP.Add(new SqlParameter("@prof_tipo_doc", tipoDoc));

            object res = ManejadorBD.EjecutarSP(SP_ALTA_PROFESIONAL, parametrosSP, EXECUTE_ESCALAR);
            int id_prof = ((res != null) ? Convert.ToInt32(res) : 0);
            if( id_prof > 0 )
            {
                agregarEspecialidadesAProfesional(id_prof, cListEspecialidades);
            }
            return id_prof;
        }

        private static void agregarEspecialidadesAProfesional(int prof_id, CheckedListBox cListEspecialidades)
        {          
            foreach( int indice in cListEspecialidades.CheckedIndices)
            {
                List<SqlParameter> parametrosSP = new List<SqlParameter>();
                parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
                string hola = cListEspecialidades.Items[indice].ToString();
                parametrosSP.Add(new SqlParameter("@especialidad_descrip", cListEspecialidades.Items[indice].ToString()));
                ManejadorBD.EjecutarSP(SP_ALTA_ESPECIALIDAD_X_PROFESIONAL, parametrosSP, EXECUTE_NON_QUERY);
            }
            return;
        }

        internal static DataTable BuscarProfesional(int prof_id, string nombre, string apellido, int dni, string matricula, int telefono, string direccion, string sexo, DateTime fechaNac, string especialidad, string mail, string tipoDoc)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
            parametrosSP.Add(new SqlParameter("@prof_nombre", nombre));
            parametrosSP.Add(new SqlParameter("@prof_apellido", apellido));
            parametrosSP.Add(new SqlParameter("@prof_tipo_doc", "- 2"));
            parametrosSP.Add(new SqlParameter("@prof_num_dni", Convert.ToInt32(dni) ));
            parametrosSP.Add(new SqlParameter("@prof_matr", matricula));
            parametrosSP.Add(new SqlParameter("@prof_direccion", direccion));
            parametrosSP.Add(new SqlParameter("@prof_telefono", Convert.ToInt32(telefono) ));
            parametrosSP.Add(new SqlParameter("@prof_mail", "- 2"));
            parametrosSP.Add(new SqlParameter("@prof_sex", sexo));
            parametrosSP.Add(new SqlParameter("@prof_fechaNac", fechaNac));
            parametrosSP.Add(new SqlParameter("@prof_esp_descr", especialidad));
            SqlDataReader readerProfesionales = (SqlDataReader)ManejadorBD.EjecutarSP(SP_BUSCAR_PROFESIONALES, parametrosSP, EXECUTE_READER);
            DataTable profesionales = new DataTable();
            if (readerProfesionales.HasRows)
            {
                profesionales.Load(readerProfesionales);
            }
            readerProfesionales.Dispose();
            return profesionales;
        }

        internal static void BajaProfesionalID(int prof_id)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
            ManejadorBD.EjecutarSP(SP_BAJA_PROFESIONAL, parametrosSP, EXECUTE_NON_QUERY);
            return;
        }

        internal static List<string> cargarEspecialidades()
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            SqlDataReader readerEspecialidades = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_ESPECIALIDADES, parametrosSP, EXECUTE_READER);
            List<String> especialidades = new List<String>();
            while(readerEspecialidades.Read())
            {
                especialidades.Add(readerEspecialidades["especialidad_descrip"].ToString());
            }
            readerEspecialidades.Dispose();
            return especialidades;
        }

        internal static List<string> cargarEspecialidadesConNull()
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            SqlDataReader readerEspecialidades = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_ESPECIALIDADES, parametrosSP, EXECUTE_READER);
            List<String> especialidades = new List<String>();
            especialidades.Add("");
            while (readerEspecialidades.Read())
            {
                especialidades.Add(readerEspecialidades["especialidad_descrip"].ToString());
            }
            readerEspecialidades.Dispose();
            return especialidades;
        }

        internal static List<string> cargarSexosConNull()
        {
            List<String> sexos = new List<String>();
            sexos.Add("");
            sexos.Add("M");
            sexos.Add("F");
            return sexos;
        }

        internal static List<string> cargarSexos()
        {
            List<String> sexos = new List<String>();
            sexos.Add("M");
            sexos.Add("F");
            return sexos;
        }

        internal static List<string> cargarTipoDocsConNull()
        {
            List<String> tipoDocs = new List<String>();
            tipoDocs.Add("");
            tipoDocs.Add("DNI");
            tipoDocs.Add("CI");
            tipoDocs.Add("LC");
            return tipoDocs;
        }

        internal static List<string> cargarTipoDocs()
        {
            List<String> tipoDocs = new List<String>();
            tipoDocs.Add("DNI");
            tipoDocs.Add("CI");
            tipoDocs.Add("LC");
            return tipoDocs;
        }

        public static List<string> cargarEstadosCivilesConNull()
        {
            List<string> estadosCiviles = new List<string>();
            estadosCiviles.Add("");
            estadosCiviles.Add("SOLTERO/A");
            estadosCiviles.Add("CASADO/A");
            estadosCiviles.Add("VIUDO/A");
            estadosCiviles.Add("CONCUBINATO");
            estadosCiviles.Add("DIVORCIADO/A");
            return estadosCiviles;
        }

        public static List<string> cargarEstadosCiviles()
        {
            List<string> estadosCiviles = new List<string>();
            estadosCiviles.Add("SOLTERO/A");
            estadosCiviles.Add("CASADO/A");
            estadosCiviles.Add("VIUDO/A");
            estadosCiviles.Add("CONCUBINATO");
            estadosCiviles.Add("DIVORCIADO/A");
            return estadosCiviles;
        }

        internal static List<string> ObtenerEspecialidadesPorProfesional(int prof_id)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
            SqlDataReader readerEspecialidades = (SqlDataReader)ManejadorBD.EjecutarSP(SP_OBTENER_ESPECIALIDADES_POR_PROFESIONAL, parametrosSP, EXECUTE_READER);
            List<String> especialidades = new List<String>();
            while (readerEspecialidades.Read())
            {
                especialidades.Add(readerEspecialidades["especialidad_descrip"].ToString());
            }
            readerEspecialidades.Dispose();
            return especialidades;
        }

        internal static void ModificarProfesional(int prof_id, string nombre, string apellido, int dni, string sexo, DateTime fechaNac, string direccion, int telefono, string matricula, string mail, string tipoDoc, System.Windows.Forms.CheckedListBox cListEspecialidades)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
            parametrosSP.Add(new SqlParameter("@prof_nombre", nombre));
            parametrosSP.Add(new SqlParameter("@prof_apellido", apellido));
            parametrosSP.Add(new SqlParameter("@prof_num_dni", dni));
            parametrosSP.Add(new SqlParameter("@prof_sex", sexo));
            parametrosSP.Add(new SqlParameter("@prof_fechaNac", fechaNac));
            parametrosSP.Add(new SqlParameter("@prof_direccion", direccion));
            parametrosSP.Add(new SqlParameter("@prof_telefono", telefono));
            parametrosSP.Add(new SqlParameter("@prof_matr", matricula));
            parametrosSP.Add(new SqlParameter("@prof_mail", mail));
            parametrosSP.Add(new SqlParameter("@prof_tipo_doc", tipoDoc));

            ManejadorBD.EjecutarSP(SP_MODIFICAR_PROFESIONAL, parametrosSP, EXECUTE_NON_QUERY);

            ModificarEspecialidadesAProfesional(prof_id, cListEspecialidades);

            return;
        }

        private static void ModificarEspecialidadesAProfesional(int prof_id, CheckedListBox cListEspecialidades)
        {
            
            for (int indice = 0; indice < cListEspecialidades.Items.Count; indice++ )
            {
                List<SqlParameter> parametrosSP = new List<SqlParameter>();
                parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
                parametrosSP.Add(new SqlParameter("@especialidad_descrip", cListEspecialidades.Items[indice].ToString()));
                if ( cListEspecialidades.GetItemCheckState(indice) == CheckState.Checked )
                    ManejadorBD.EjecutarSP(SP_ALTA_ESPECIALIDAD_X_PROFESIONAL, parametrosSP, EXECUTE_NON_QUERY);
                else
                    ManejadorBD.EjecutarSP(SP_BAJA_ESPECIALIDAD_X_PROFESIONAL, parametrosSP, EXECUTE_NON_QUERY);
            }
            return;
        }

        internal static string AltaAgendaProfesional(DateTime agen_fecha_ini, DateTime agen_fecha_fin, int prof_id, bool agen_lun, bool agen_mar, bool agen_mie, bool agen_jue, bool agen_vie, bool agen_sab, TimeSpan agen_lun_ini, TimeSpan agen_lun_fin, TimeSpan agen_mar_ini, TimeSpan agen_mar_fin, TimeSpan agen_mie_ini, TimeSpan agen_mie_fin, TimeSpan agen_jue_ini, TimeSpan agen_jue_fin, TimeSpan agen_vie_ini, TimeSpan agen_vie_fin, TimeSpan agen_sab_ini, TimeSpan agen_sab_fin)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@agen_fecha_ini", agen_fecha_ini));
            parametrosSP.Add(new SqlParameter("@agen_fecha_fin", agen_fecha_fin));
            parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
            parametrosSP.Add(new SqlParameter("@agen_lun", agen_lun));
            parametrosSP.Add(new SqlParameter("@agen_mar", agen_mar));
            parametrosSP.Add(new SqlParameter("@agen_mie", agen_mie));
            parametrosSP.Add(new SqlParameter("@agen_jue", agen_jue));
            parametrosSP.Add(new SqlParameter("@agen_vie", agen_vie));
            parametrosSP.Add(new SqlParameter("@agen_Sab", agen_sab));
            parametrosSP.Add(new SqlParameter("@agen_lun_ini", agen_lun_ini));
            parametrosSP.Add(new SqlParameter("@agen_lun_fin", agen_lun_fin));
            parametrosSP.Add(new SqlParameter("@agen_mar_ini", agen_mar_ini));
            parametrosSP.Add(new SqlParameter("@agen_mar_fin", agen_mar_fin));
            parametrosSP.Add(new SqlParameter("@agen_mie_ini", agen_mie_ini));
            parametrosSP.Add(new SqlParameter("@agen_mie_fin", agen_mie_fin));
            parametrosSP.Add(new SqlParameter("@agen_jue_ini", agen_jue_ini));
            parametrosSP.Add(new SqlParameter("@agen_jue_fin", agen_jue_fin));
            parametrosSP.Add(new SqlParameter("@agen_vie_ini", agen_vie_ini));
            parametrosSP.Add(new SqlParameter("@agen_vie_fin", agen_vie_fin));
            parametrosSP.Add(new SqlParameter("@agen_sab_ini", agen_sab_ini));
            parametrosSP.Add(new SqlParameter("@agen_sab_fin", agen_sab_fin));
            return (string)ManejadorBD.EjecutarSP(SP_CREAR_AGENDA_PROFESIONAL, parametrosSP, EXECUTE_ESCALAR);
        }

        internal static DataTable Listado1(DateTime fechaInicio, DateTime fechaFin)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@inicio_semestre", fechaInicio));
            parametrosSP.Add(new SqlParameter("@fin_semestre", fechaFin));
            SqlDataReader readerListado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_LISTADO_1, parametrosSP, EXECUTE_READER);
            DataTable listado = new DataTable();
            if (readerListado.HasRows)
            {
                listado.Load(readerListado);
            }
            readerListado.Dispose();
            return listado;
        }

        internal static DataTable Listado2(DateTime fechaInicio, DateTime fechaFin)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@inicio_semestre", fechaInicio));
            parametrosSP.Add(new SqlParameter("@fin_semestre", fechaFin));
            SqlDataReader readerListado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_LISTADO_2, parametrosSP, EXECUTE_READER);
            DataTable listado = new DataTable();
            if (readerListado.HasRows)
            {
                listado.Load(readerListado);
            }
            readerListado.Dispose();
            return listado;
        }

        internal static DataTable Listado3(DateTime fechaInicio, DateTime fechaFin)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@inicio_semestre", fechaInicio));
            parametrosSP.Add(new SqlParameter("@fin_semestre", fechaFin));
            SqlDataReader readerListado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_LISTADO_3, parametrosSP, EXECUTE_READER);
            DataTable listado = new DataTable();
            if (readerListado.HasRows)
            {
                listado.Load(readerListado);
            }
            readerListado.Dispose();
            return listado;
        }

        internal static DataTable Listado4(DateTime fechaInicio, DateTime fechaFin)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@inicio_semestre", fechaInicio));
            parametrosSP.Add(new SqlParameter("@fin_semestre", fechaFin));
            SqlDataReader readerListado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_LISTADO_4, parametrosSP, EXECUTE_READER);
            DataTable listado = new DataTable();
            if (readerListado.HasRows)
            {
                listado.Load(readerListado);
            }
            readerListado.Dispose();
            return listado;
        }

        internal static void concluirConsultaMedica(int consulta_id, string estado, DateTime horaAtencion, string sintomas, string enfermedades)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@consulta_id", consulta_id));
            parametrosSP.Add(new SqlParameter("@estado", estado));
            parametrosSP.Add(new SqlParameter("@registro_atencion", horaAtencion));
            parametrosSP.Add(new SqlParameter("@consulta_sintomas", sintomas));
            parametrosSP.Add(new SqlParameter("@consulta_enfermedades", enfermedades));
            ManejadorBD.EjecutarSP(SP_CONCLUIR_CONSULTA_MEDICA, parametrosSP, EXECUTE_NON_QUERY);
            return;
        }

        internal static object buscarConsultas(int prof_id, DateTime fecha)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@prof_id", prof_id));
            parametrosSP.Add(new SqlParameter("@fecha", fecha));
            SqlDataReader readerListado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_LISTAR_CONSULTAS_MEDICAS_ABIERTAS, parametrosSP, EXECUTE_READER);
            DataTable listado = new DataTable();
            if (readerListado.HasRows)
            {
                listado.Load(readerListado);
            }
            readerListado.Dispose();
            return listado;
        }

        internal static int verificarBonoFarmacia(int consulta_id, int bono_numero)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@consulta_id", consulta_id));
            parametrosSP.Add(new SqlParameter("@bono_numero", bono_numero));
            object res = ManejadorBD.EjecutarSP(SP_VERIFICAR_BONO_FARMACIA, parametrosSP, EXECUTE_ESCALAR);
            int receta_id = ((res != null) ? (int)res : 0);
            return receta_id;
        }

        internal static object buscarMedicamentos(string medicamento)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@string", medicamento));
            SqlDataReader readerListado = (SqlDataReader)ManejadorBD.EjecutarSP(SP_BUSCAR_MEDICAMENTOS, parametrosSP, EXECUTE_READER);
            DataTable listado = new DataTable();
            if (readerListado.HasRows)
            {
                listado.Load(readerListado);
            }
            readerListado.Dispose();
            return listado;
        }

        internal static int GenerarReceta(int id_consulta)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@consulta_id", id_consulta));
            object res = ManejadorBD.EjecutarSP(SP_INSERTAR_RECETA, parametrosSP, EXECUTE_ESCALAR);
            int receta_id = ((res != null) ? (int)res : 0);
            return receta_id;
        }

        internal static void AsociarBonoConMedicamentos(int receta_id, int consulta_id, int bono_id, int medicamento1, int cant1, int medicamento2, int cant2, int medicamento3, int cant3, int medicamento4, int cant4, int medicamento5, int cant5)
        {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@receta_id", receta_id));
            parametrosSP.Add(new SqlParameter("@consulta_id", consulta_id));
            parametrosSP.Add(new SqlParameter("@bono_farmacia_numero", bono_id));
            parametrosSP.Add(new SqlParameter("@medicamento_id_1", medicamento1));
            parametrosSP.Add(new SqlParameter("@cant_1", cant1));
            parametrosSP.Add(new SqlParameter("@medicamento_id_2", medicamento2));
            parametrosSP.Add(new SqlParameter("@cant_2", cant2));
            parametrosSP.Add(new SqlParameter("@medicamento_id_3", medicamento3));
            parametrosSP.Add(new SqlParameter("@cant_3", cant3));
            parametrosSP.Add(new SqlParameter("@medicamento_id_4", medicamento4));
            parametrosSP.Add(new SqlParameter("@cant_4", cant4));
            parametrosSP.Add(new SqlParameter("@medicamento_id_5", medicamento5));
            parametrosSP.Add(new SqlParameter("@cant_5", cant5));
            parametrosSP.Add(new SqlParameter("@fecha_prescrip_med", ManejadorFechaHora.obtenerFechaDelSistema()));

            ManejadorBD.EjecutarSP(SP_ASOCIAR_BONO_CON_MEDICAMENTOS, parametrosSP, EXECUTE_NON_QUERY);
            return;
        }

        internal static DataTable listarTurnosProfesionalDiaSinConsulta(DateTime fecha, int profesional_id, string condicion)
       {
            List<SqlParameter> parametrosSP = new List<SqlParameter>();
            parametrosSP.Add(new SqlParameter("@fecha", fecha));
            parametrosSP.Add(new SqlParameter("@prof_id", profesional_id));
            parametrosSP.Add(new SqlParameter("@cond", condicion));
            SqlDataReader readerTurnosProfesional = (SqlDataReader)ManejadorBD.EjecutarSP(SP_LISTAR_TURNOS_PROFESIONAL_DIA_SIN_CONSULTAS, parametrosSP, EXECUTE_READER);
            DataTable turnosFechas = new DataTable();
            if (readerTurnosProfesional.HasRows)
            {
                turnosFechas.Load(readerTurnosProfesional);
            }
            readerTurnosProfesional.Dispose();
            return turnosFechas;
        }
    }
}
