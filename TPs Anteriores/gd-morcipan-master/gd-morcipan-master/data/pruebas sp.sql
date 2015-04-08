
-- USUARIOS, ROLES, FUNCIONES
EXEC GD2C2013.gd_MORCIPAN.spObtenerFuncionesDelUsuarioDeAcuerdoASusRoles 'admin';
EXEC GD2C2013.gd_MORCIPAN.spInsertarOActivarRol 'Petruza5';
EXEC GD2C2013.gd_MORCIPAN.spBuscarRolesPorNombre '- 2'
EXEC GD2C2013.gd_MORCIPAN.spObtenerIdAfiliadoProfesionalPorUsuario 'DNI66665528', 'afiliado' --''

-- LOS COMENTO, DADO QUE LOS CAMBIE TODOS (CAMBIE NOMBRE Y FUNCIONALIDAD EN BASE A LO PEDIDO)
/*
EXEC GD2C2013.gd_MORCIPAN.spObtenerFuncionalidadesXRol 'LALA2'
EXEC GD2C2013.gd_MORCIPAN.spBajaFuncion 'ABM de Rol';
EXEC GD2C2013.gd_MORCIPAN.spAltaFuncion 'ABM de Rol';
EXEC GD2C2013.gd_MORCIPAN.spBajaRol 'LALA2';
EXEC GD2C2013.gd_MORCIPAN.spAltaRol 'LALA2';
EXEC GD2C2013.gd_MORCIPAN.spAltaFuncionXRol 'LALA2', 'ABM de Rol';
EXEC GD2C2013.gd_MORCIPAN.spBajaFuncionXRol 'LALA2', 'ABM de Rol';
EXEC GD2C2013.gd_MORCIPAN.spRolesDelUsuario 'admin3'
EXEC GD2C2013.gd_MORCIPAN.spAltaUsuarioRol  'admin3', 'LALA2'
*/

-- STORE AFILIADOS
EXEC GD2C2013.gd_MORCIPAN.spObtenerSecuenciaAfiliado
-- LIKE por nombre, apellido, direccion, mail
EXEC GD2C2013.gd_MORCIPAN.spBuscarAfiliado 101, '- 2', '- 2', '- 2', -2, '- 2', -2, '- 2', '1900-01-01 00:00:00.000', '- 2', '- 2', -2, '- 2' 
EXEC GD2C2013.gd_MORCIPAN.spBuscarAfiliadoNoHabilitado -2, '- 2', '- 2', '- 2', -2, '- 2', -2, '- 2', '1900-01-01 00:00:00.000', '- 2', '- 2', -2, '- 2'
EXEC GD2C2013.gd_MORCIPAN.spModificarAfiliado 101, 'xxx', 'xxx', 'xxx', 222, 'xxx', 222, '222', '1999-12-12 00:00:00.000', '222', '222', 222, 'Plan Medico 110' 
EXEC GD2C2013.gd_MORCIPAN.spRegistroCambioPlanAfiliado  301, 'Plan Medico 140', 'Plan Medico 150', 'Upgrade'
EXEC GD2C2013.gd_MORCIPAN.spObtenerProximoNroAfiliadoFamilia 101
EXEC GD2C2013.gd_MORCIPAN.spInsertarAfiliado 742801,'nombre','apellido','DNI',33366272,'direccion', 1234567, 'mail', '1987-11-07 00:00:00.000', 'sexo', 'estado civil', 0, 'Plan Medico 110'

DECLARE @lala int
EXEC @lala = GD2C2013.gd_MORCIPAN.fnPatronDelAfiliado 1342501
SELECT @lala

DECLARE @lala int
EXEC @lala = GD2C2013.gd_MORCIPAN.fnAfiliadoRaiz 742802
SELECT @lala

EXEC GD2C2013.gd_MORCIPAN.spObtenerTodosIntegrantesGrupoFamiliarMenosRaiz 742801
SELECT * FROM gd_MORCIPAN.fnObtenerTodosIntegrantesGrupoFamiliarMenosRaiz (742801)

-- STORE PROFESIONALES
-- LIKE por nombre, apellido, direccion, mail
EXEC GD2C2013.gd_MORCIPAN.spBuscarProfesional -2, '- 2', '- 2', '- 2', 94007233, '- 2', -2, '- 2', '1900-01-01 00:00:00.000', '- 2', '- 2'
EXEC GD2C2013.gd_MORCIPAN.spBuscarProfesionalFull -2, '- 2', '- 2', '- 2', -2, '- 2', -2, '- 2', '1900-01-01 00:00:00.000', '- 2', '- 2',10000
EXEC GD2C2013.gd_MORCIPAN.spModificarProfesional 1, 'xxx', 'xxx', 'xxx', 222, 'xxx', 222, 'xxx', '1999-12-12 00:00:00.000', 'xxx', 'xxx'
EXEC GD2C2013.gd_MORCIPAN.spBajaLogicaProfesionalPorId 1
EXEC GD2C2013.gd_MORCIPAN.spAltaLogicaProfesionalPorId 1
EXEC GD2C2013.gd_MORCIPAN.spAltaProfesional 'nombre','apellido','DNI',94007233,'direccion', 1234567, 'mail', '1987-11-07 00:00:00.000', 'sexo', '123'


-- STORE ESPECIALIDADES
EXEC GD2C2013.gd_MORCIPAN.spObtenerEspecialidadesProfesional 2
EXEC GD2C2013.gd_MORCIPAN.spAltaEspecialidadPorProfesional 2,'Cardiología'
EXEC GD2C2013.gd_MORCIPAN.spBajaEspecialidadPorProfesional 2,'Cardiología'

-- STORE BONOS
EXEC GD2C2013.gd_MORCIPAN.spInsertarBonoConsulta 101,'Plan Medico 120'
EXEC GD2C2013.gd_MORCIPAN.spInsertarBonoFarmacia 353601,'Plan Medico 120'
EXEC GD2C2013.gd_MORCIPAN.spInsertarCompraTotal 91401, 20, 10, 108.99  -- consulta, farmacia

DECLARE @lala INT
EXEC @lala = GD2C2013.gd_MORCIPAN.fnObtenerPrerciosBonos 'Plan Medico 110', 'FARMACIA'
SELECT @lala

DECLARE @lala INT
EXEC @lala = GD2C2013.gd_MORCIPAN.fnVerificarBonoGrupoFamiliar 91401, 75757, 'FARMACIA'
SELECT @lala

EXEC GD2C2013.gd_MORCIPAN.spVerificarBonoValidoFarmacia 123 , 75757 --consulta_id, bono_farmacia_numero --91404, 75757

-- STORE TURNOS
EXEC GD2C2013.gd_MORCIPAN.spDiaOcupadoAgenda '2013-12-02 00:00:00.000', 23
EXEC GD2C2013.gd_MORCIPAN.spListarTurnosProfesionalDia '2013-11-14 00:00:00.000', 1, 'ocupados'  --'libres'/'ocupados'
EXEC GD2C2013.gd_MORCIPAN.spCancelarTurnoAfiliado 181365, 'TipoCancelacion', 'Por Paja'
EXEC GD2C2013.gd_MORCIPAN.spCancelarTurnoProfesionalDia 10, '2013-06-18 00:00:00.000', 'TipoCancelacion', 'Le pinto al doctor'
EXEC GD2C2013.gd_MORCIPAN.spListarTurnosProfesionalDiaSinConsulta '2013-11-14 00:00:00.000', 1, 'ocupados'  --'libres'/'ocupados'

--	STORE AGENDA
declare @lala BIT
EXEC @lala = GD2C2013.gd_MORCIPAN.fnVerificarCreacionAgenda '2013-12-01 00:00:00.000', '2013-12-15 00:00:00.000', 1
SELECT @lala

EXEC GD2C2013.gd_MORCIPAN.spDarDeBajaAgendaProfesional 1

EXEC GD2C2013.gd_MORCIPAN.spCrearAgendaProfesional
		'2014-01-15 00:00:00.000', '2014-01-31 00:00:00.000', 1, -- fecha_ini, fecha_fin, prof_id
		0, 0, 1, 0, 0, 0,	-- dias, habilitado/deshabilitado
		'09:30:00.0000', '10:30:00.0000',	--hora ini fin lunes
		'09:30:00.0000', '10:30:00.0000',	--hora ini fin martes
		'09:30:00.0000', '10:30:00.0000',	--hora ini fin miercoles
		'09:30:00.0000', '10:30:00.0000',	--hora ini fin jueves
		'09:30:00.0000', '10:30:00.0000',	--hora ini fin viernes
		'09:30:00.0000', '10:30:00.0000'	--hora ini fin sabado

EXEC GD2C2013.gd_MORCIPAN.spDarDeBajaTurnosProfesionalDesdeHasta 1, '2013-01-01 08:00:00.000', '2013-01-01 11:30:00.000'


-- STORE CONSULTAS MEDICAS
EXEC GD2C2013.gd_MORCIPAN.spInsertarConsultaMedica 56565, 91401, 46494
EXEC GD2C2013.gd_MORCIPAN.spListarConsultasMedicasAbiertasProfesionalDia  1, '2013-11-14 00:00:00.000'
EXEC GD2C2013.gd_MORCIPAN.spConfirmarConsultaMedica 108312, 'LALA', '2013-11-14 00:00:00.000', 'dolor anal', 'travieso'


-- RECETAS MEDICAS
-- devuelve receta_id generada
EXEC GD2C2013.gd_MORCIPAN.spInsertarRecetaMedica 123 --consulta_id
EXEC GD2C2013.gd_MORCIPAN.spAsociarRecetaBonosFarmaciaMedicamentos 
					-- receta_id, consulta_id, bono_farmacia_numero, med_1, cant_1, ...
					-- fecha_prescrip					
					108313, 123, 184071, 1, 1, 
					2, 1, 3, 1, 
					4, 0, 5, 0,
					'2013-11-14 00:00:00.000'
-- 108313 receta_id
-- 353601 afi

-- STORE MEDICAMENTOS
EXEC GD2C2013.gd_MORCIPAN.spListarMedicamentosLike '-4'

-- STORE LISTADOS ESTADISTICOS

-- spListado1
declare @lala INT
EXEC @lala = GD2C2013.gd_MORCIPAN.fnCancelacionesEspecialidadMes 'Reumatología', '2013-06-14 00:00:00.000'
SELECT @lala
EXEC GD2C2013.gd_MORCIPAN.spListado1 '2013-01-01 00:00:00.000', '2013-07-01 00:00:00.000'

-- spListado2
declare @lala INT
EXEC @lala = GD2C2013.gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado 247701, '2013-12-01 00:00:00.000'
SELECT @lala
EXEC GD2C2013.gd_MORCIPAN.spListado2 '2013-07-01 00:00:00.000', '2014-01-01 00:00:00.000'


-- spListado3
declare @lala INT
EXEC @lala = GD2C2013.gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes 'Rehabilitación', '2013-12-01 00:00:00.000'
SELECT @lala
EXEC GD2C2013.gd_MORCIPAN.spListado3 '2013-07-01 00:00:00.000', '2014-01-01 00:00:00.000'


-- spListado4
declare @lala INT
EXEC @lala = GD2C2013.gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes 742802, '2014-01-01 00:00:00.000'
SELECT @lala

declare @lala INT
EXEC @lala = GD2C2013.gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorSemestre 742803, '2014-01-01 00:00:00.000', '2014-07-01 00:00:00.000'
SELECT @lala

EXEC GD2C2013.gd_MORCIPAN.spListado4 '2014-01-01 00:00:00.000', '2014-07-01 00:00:00.000'









-- STORE FECHA
EXEC GD2C2013.gd_MORCIPAN.spInsertarFechaFuncionamiento '2013-01-01 00:00:00.000'
DECLARE @fecha DATETIME
EXEC @fecha = GD2C2013.gd_MORCIPAN.fnDevolverFechaSistema
SELECT @fecha

-- TABLAS
select * from gd_esquema.Maestra 
select * from gd_MORCIPAN.fechaSistema
select * from gd_MORCIPAN.usuarios where usuario_id =7432
select * from gd_MORCIPAN.roles
select * from gd_MORCIPAN.roles_usuarios where usuario_id = 7458
select * from gd_MORCIPAN.funciones
select * from gd_MORCIPAN.funciones_roles
select * from gd_MORCIPAN.afiliados
select * from gd_MORCIPAN.planes
select * from gd_MORCIPAN.afiliados_cambios_planes
select * from gd_MORCIPAN.especialidades
select * from gd_MORCIPAN.tipo_especialidades
select * from gd_MORCIPAN.profesionales
select * from gd_MORCIPAN.especialidades_profesionales
select * from gd_MORCIPAN.turnos where prof_id = 2
select * from gd_MORCIPAN.tablas_secuencias
select * from gd_MORCIPAN.bonos_consulta where afiliado_numero = 102
select * from gd_MORCIPAN.bonos_farmacia where afiliado_numero = 102
select * from gd_MORCIPAN.compras_bonos_afiliados
select * from gd_MORCIPAN.consultas_medicas
select * from gd_MORCIPAN.recetas_medicas
select * from gd_MORCIPAN.bonosFarmacia_recetas
select * from gd_MORCIPAN.agendas_profesionales
select * from gd_MORCIPAN.cancelacion_turnos
select * from gd_MORCIPAN.medicamentos
select * from gd_MORCIPAN.bonosFarmacia_medicamentos
select * from gd_MORCIPAN.tablas_secuencias


UPDATE gd_MORCIPAN.usuarios
SET habilitado = 1

DELETE FROM gd_MORCIPAN.bonos_farmacia
WHERE bono_farmacia_numero = 184069
