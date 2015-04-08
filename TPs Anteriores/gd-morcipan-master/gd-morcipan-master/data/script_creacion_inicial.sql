USE GD2C2013
GO

SET LANGUAGE Spanish

/* ******************************************************************************************************************** */
/*	****************************************	CREACION DEL SCHENMA	*********************************************** */
IF NOT EXISTS (SELECT [schema_id] FROM [sys].[schemas] WHERE [name] = 'gd_MORCIPAN')
BEGIN
	EXECUTE ('CREATE SCHEMA gd_MORCIPAN AUTHORIZATION gd;');
END
GO

/* ******************************************************************************************************************** */
/*	****************************************	FECHA DEL SISTEMA	*************************************************** */

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'fechaSistema')
BEGIN 
	PRINT 'La tabla fechaSistema ya existia, SE BORRARA';
	DROP TABLE gd_MORCIPAN.fechaSistema;
END

/* 	TABLA: fechaSistema
	DESCRIPCION: fechas del sistema
*/
CREATE TABLE gd_MORCIPAN.fechaSistema (
		fechaSistema	DATETIME NOT NULL
);

/* PROCEDURE: spRegistrarFechaDelSistema
   DESCRIPCION: Establece la fecha del sistema
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spRegistrarFechaDelSistema')
	DROP PROCEDURE gd_MORCIPAN.spRegistrarFechaDelSistema
GO
CREATE PROCEDURE gd_MORCIPAN.spRegistrarFechaDelSistema
	@fecha DATETIME
AS
BEGIN
	--IF NOT EXISTS(SELECT fechaSistema FROM gd_MORCIPAN.fechaSistema)
	IF @fecha is NULL
			INSERT gd_MORCIPAN.fechaSistema (fechaSistema) VALUES (GETDATE())
	ELSE
			INSERT gd_MORCIPAN.fechaSistema (fechaSistema) VALUES (@fecha)
END;
GO

/* PROCEDURE: fnDevolverFechaSistema
   DESCRIPCION: Devuelve la fecha del sistema
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnDevolverFechaSistema')
	DROP FUNCTION gd_MORCIPAN.fnDevolverFechaSistema
GO
CREATE FUNCTION gd_MORCIPAN.fnDevolverFechaSistema()
RETURNS DATETIME
AS
	BEGIN
	DECLARE @fecha DATETIME
	SELECT TOP 1 @fecha = fechaSistema FROM gd_MORCIPAN.fechaSistema
	RETURN @fecha
	END
GO

EXEC gd_MORCIPAN.spRegistrarFechaDelSistema '2014-01-01 00:00:00.000' --NULL

/* PROCEDURE: spInsertarFechaFuncionamiento
   DESCRIPCION: Actualiza la fecha del sistema
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spInsertarFechaFuncionamiento')
	DROP PROCEDURE gd_MORCIPAN.spInsertarFechaFuncionamiento
GO
CREATE PROCEDURE gd_MORCIPAN.spInsertarFechaFuncionamiento
	@fecha DATETIME
AS
BEGIN
	UPDATE gd_MORCIPAN.fechaSistema
	SET fechaSistema = @fecha
END;
GO


/* ******************************************************************************************************************** */
/*	****************************************	BORRO TABLAS DEL SISTEMA	******************************************* */

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'tablas_secuencias')
BEGIN 
	PRINT 'La tabla tablas_secuencias ya existia, SE BORRARA';
	DROP TABLE gd_MORCIPAN.tablas_secuencias;
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'roles_usuarios')
BEGIN 
	PRINT 'La tabla roles_usuarios ya existia, SE BORRARA';
	DROP TABLE gd_MORCIPAN.roles_usuarios;
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'funciones_roles')
BEGIN 
	PRINT 'La tabla funciones_roles ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.funciones_roles
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'roles')
BEGIN 
	PRINT 'La tabla roles ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.roles
END
	
IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'funciones')
BEGIN
	Print 'La tabla funciones ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.funciones
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'afiliados_cambios_planes')
BEGIN
	Print 'La tabla afiliados_cambios_planes ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.afiliados_cambios_planes
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'consultas_medicas')
BEGIN
	Print 'La tabla consultas_medicas ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.consultas_medicas
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'cancelacion_turnos')
BEGIN
	Print 'La tabla cancelacion_turnos ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.cancelacion_turnos
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'turnos')
BEGIN
	Print 'La tabla turnos ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.turnos
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'bonos_consulta')
BEGIN
	Print 'La tabla bonos_consultas ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.bonos_consulta
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'bonosFarmacia_recetas')
BEGIN
	Print 'La tabla bonosFarmacia_recetas ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.bonosFarmacia_recetas
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'recetas_medicas')
BEGIN
	Print 'La tabla recetas_medicas ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.recetas_medicas
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'bonosFarmacia_medicamentos')
BEGIN
	Print 'La tabla bonosFarmacia_medicamentos ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.bonosFarmacia_medicamentos
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'bonos_farmacia')
BEGIN
	Print 'La tabla bonos_farmacia ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.bonos_farmacia
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'medicamentos')
BEGIN
	Print 'La tabla medicamentos ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.medicamentos
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'compras_bonos_afiliados')
BEGIN
	Print 'La tabla compras_bonos_afiliados ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.compras_bonos_afiliados
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'afiliados')
BEGIN
	Print 'La tabla afiliados ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.afiliados
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'planes')
BEGIN
	Print 'La tabla planes ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.planes
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'especialidades_profesionales')
BEGIN
	Print 'La tabla especialidades_profesionales ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.especialidades_profesionales
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'especialidades')
BEGIN
	Print 'La tabla especialidades ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.especialidades
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'tipo_especialidades')
BEGIN
	Print 'La tabla tipo_especialidades ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.tipo_especialidades
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'agendas_profesionales')
BEGIN
	Print 'La tabla agendas_profesionales ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.agendas_profesionales
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'profesionales')
BEGIN
	Print 'La tabla profesionales ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.profesionales
END

IF EXISTS (SELECT 1 AS existe FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'gd_MORCIPAN' AND  TABLE_NAME = 'usuarios')
BEGIN 
	PRINT 'La tabla usuarios ya existe, SE BORRARA';
	DROP TABLE gd_MORCIPAN.usuarios;
END

/* ******************************************************************************************************************** */
/*	********************************************	CREACION DE TABLAS	*********************************************** */

BEGIN TRAN CreacionTablas

/* 	TABLA: tablas_secuencias
	DESCRIPCION: Números de secuencia por tabla, para tablas que no se pueden manejar con 
				 IDENTITY
	CAMPOS: tabla_nombre, tabla_secuencia_valor
*/
CREATE TABLE gd_MORCIPAN.tablas_secuencias (
	tabla_nombre VARCHAR(255) NOT NULL,
	tabla_secuencia_valor INT,
	PRIMARY KEY(tabla_nombre)
);

/* 	TABLA: usuarios
	DESCRIPCION: Datos de cada usuario. Se relacionará con la tabla roles_usuarios
	CAMPOS: usuario_id, usuario, usuario_password, habilitado
*/
CREATE TABLE gd_MORCIPAN.usuarios (
	usuario_id INT IDENTITY(1,1) NOT NULL,
	usuario_nombre NVARCHAR(255) NOT NULL UNIQUE,
	usuario_password NVARCHAR(255) NOT NULL,
	habilitado BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (usuario_id)
);

/* 	TABLA: roles
	DESCRIPCION: Establece los roles del sistema con un id único. Se relaciona con la tabla funciones_rol.
	CAMPOS: rol_id, rol, habilitado
*/
CREATE TABLE gd_MORCIPAN.roles (
	rol_id		INT IDENTITY(1, 1) NOT NULL,
	rol_nombre	NVARCHAR(255) NOT NULL,
	habilitado	BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (rol_id)
);

/* 	TABLA: roles_usuarios
	DESCRIPCION: Esta tabla almacena mediante las relaciones correspondientes los roles que cada usuario posee.
	CAMPOS: id, rol_id, usuario_id
*/
CREATE TABLE gd_MORCIPAN.roles_usuarios (
	rol_id INT NOT NULL,
	usuario_id INT NOT NULL,
	PRIMARY KEY (rol_id, usuario_id),
	FOREIGN KEY (rol_id) REFERENCES gd_MORCIPAN.roles (rol_id),
	FOREIGN KEY (usuario_id) REFERENCES gd_MORCIPAN.usuarios (usuario_id)
);

/* 	TABLA: funciones
	DESCRIPCION: Un registro por cada función que tiene el sistema. Esta tabla es estática, ya que el sistema tiene una cantidad fija de funciones.
	CAMPOS: funcion_id , funcion_nom
*/
CREATE TABLE gd_MORCIPAN.funciones (
	funcion_id INT IDENTITY (1, 1) NOT NULL,
	funcion_nombre NVARCHAR(255) NOT NULL,
	habilitada BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (funcion_id)
);

/* 	TABLA: funciones_roles
	DESCRIPCION: Contendrá un registro por cada función que tenga un determinado rol.
	CAMPOS: id, rol_id, funcion_id
*/
CREATE TABLE gd_MORCIPAN.funciones_roles (
	rol_id INT NOT NULL,
	funcion_id INT NOT NULL,
	PRIMARY KEY (funcion_id, rol_id),
	FOREIGN KEY (funcion_id) REFERENCES gd_MORCIPAN.funciones (funcion_id),
	FOREIGN KEY (rol_id) REFERENCES gd_MORCIPAN.roles (rol_id)
);

/* 	TABLA: planes
	DESCRIPCION: Datos de planes médicos.
	CAMPOS: plan_id, plan_descripcion, plan_precio_bono_consulta, plan_precio_bono_farmacia, habilitado
*/
CREATE TABLE gd_MORCIPAN.planes (
	plan_codigo NUMERIC(18,0) NOT NULL,
	plan_descripcion VARCHAR(255),
	plan_precio_bono_consulta NUMERIC(18,0) NOT NULL,
	plan_precio_bono_farmacia NUMERIC(18,0) NOT NULL,
	habilitado BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (plan_codigo)
);

/* 	TABLA: afiliados
	DESCRIPCION: Datos de afiliados
	CAMPOS: afiliado_id, afiliado_numero, afiliado_nombre, afiliado_apellido, afiliado_tipo_documento,
			afiliado_nro_documento, afiliado_direccion, afiliado_telefono, afiliado_email,
			afiliado_fecha_nacimiento, afiliado_sexo, afiliado_estado_civil, 
			afiliado_cant_familiares_cargo, afiliado_plan_medico, habilitado
*/
CREATE TABLE gd_MORCIPAN.afiliados (
	afiliado_numero					INT NOT NULL,
	afiliado_nombre					VARCHAR(255) NOT NULL,
	afiliado_apellido				VARCHAR(255) NOT NULL,
	afiliado_tipo_documento			VARCHAR(10) NOT NULL DEFAULT 'DNI',
	afiliado_nro_documento			NUMERIC(18,0) NOT NULL,
	afiliado_direccion				VARCHAR(255) NOT NULL,
	afiliado_telefono				NUMERIC(18,0) NOT NULL,
	afiliado_email					VARCHAR(255) NOT NULL,
	afiliado_fecha_nacimiento		DATETIME NOT NULL,
	afiliado_sexo					VARCHAR(50) NOT NULL DEFAULT 'No Aportado',-- NOT NULL, -- ES MUY DIFICIL CREAR UN ALGORITMO QUE POR NOMBRE SAQUE EL SEXO
	afiliado_estado_civil			VARCHAR(255) NOT NULL DEFAULT 'No Aportado',
	afiliado_cant_familiares_cargo	INT NOT NULL DEFAULT 0,
	afiliado_plan_medico_codigo		NUMERIC(18,0) NOT NULL,
	fecha_baja_logica				DATETIME DEFAULT NULL,
	habilitado						BIT NOT NULL DEFAULT 1,
	usuario_id						INT,
	UNIQUE (afiliado_tipo_documento, afiliado_nro_documento),
	PRIMARY KEY (afiliado_numero),
	FOREIGN KEY (afiliado_plan_medico_codigo) REFERENCES gd_MORCIPAN.planes (plan_codigo),
	FOREIGN KEY (usuario_id) REFERENCES gd_MORCIPAN.usuarios (usuario_id)
);

/* 	TABLA: afiliados_cambios_planes
	DESCRIPCION: Tabla que mantendrá el histórico de los cambios de planes de afiliados.
	CAMPOS: fecha_modificacion, afiliado_id, plan_id
*/
CREATE TABLE gd_MORCIPAN.afiliados_cambios_planes (
	cambio_id					INT IDENTITY(1,1) NOT NULL,
	cambio_fecha_modificacion	DATETIME NOT NULL,
	afiliado_numero				INT NOT NULL,
	plan_codigo_ant				NUMERIC(18,0) NOT NULL,
	plan_codigo_act				NUMERIC(18,0) NOT NULL,
	cambio_motivo				NVARCHAR(255) NOT NULL,
	PRIMARY KEY (cambio_id),
	FOREIGN KEY (afiliado_numero) REFERENCES gd_MORCIPAN.afiliados (afiliado_numero),
	FOREIGN KEY (plan_codigo_ant) REFERENCES gd_MORCIPAN.planes (plan_codigo),
	FOREIGN KEY (plan_codigo_act) REFERENCES gd_MORCIPAN.planes (plan_codigo)
);

/* 	TABLA: tipo de especialidades
	DESCRIPCION: Tabla de tipo de especialidades medicas
*/
CREATE TABLE gd_MORCIPAN.tipo_especialidades(
	tipo_esp_codigo NUMERIC(18,0) UNIQUE NOT NULL,
	tipo_esp_descrip  VARCHAR(255) NOT NULL,
	habilitado BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (tipo_esp_codigo)
);

/* 	TABLA: especialidades
	DESCRIPCION: Tabla de especialidades medicas
*/
CREATE TABLE gd_MORCIPAN.especialidades(
	especialidad_codigo NUMERIC(18,0) UNIQUE NOT NULL,
	especialidad_descrip  VARCHAR(255) NOT NULL,
	tipo_esp_codigo NUMERIC(18,0) NOT NULL,
	habilitado BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (especialidad_codigo),
	FOREIGN KEY (tipo_esp_codigo) REFERENCES gd_MORCIPAN.tipo_especialidades (tipo_esp_codigo)
);

/* 	TABLA: profesionales
	DESCRIPCION: Tabla de profesionales
*/
CREATE TABLE gd_MORCIPAN.profesionales(
	prof_id			INT IDENTITY (1,1) NOT NULL,
	prof_nombre		VARCHAR(255) NOT NULL,
	prof_apellido	NVARCHAR(255) NOT NULL,
	prof_tipo_doc	VARCHAR(10) NOT NULL DEFAULT 'DNI',
	prof_num_dni	NUMERIC(18,0) UNIQUE NOT NULL,
	prof_direccion	VARCHAR(255) NOT NULL,
	prof_telefono	NUMERIC(18,0) NOT NULL,
	prof_mail		VARCHAR(255) NOT NULL,
	prof_fechaNac	DATETIME NOT NULL,
	prof_sex		NVARCHAR(100) NOT NULL DEFAULT 'No Aportado',
	prof_matr		NVARCHAR(100) NOT NULL DEFAULT 'No Aportado',
	habilitado		BIT NOT NULL DEFAULT 1,
	usuario_id		INT, -- NULL por migracion, pero no deberia
	PRIMARY KEY (prof_id),
	FOREIGN KEY (usuario_id) REFERENCES gd_MORCIPAN.usuarios (usuario_id)
);

/* 	TABLA: especialidades_profesionales
	DESCRIPCION: Tabla con las especialidades que poseen los porfesionales
*/
CREATE TABLE gd_MORCIPAN.especialidades_profesionales(

	especialidad_codigo		NUMERIC(18,0) NOT NULL,
	prof_id					INT NOT NULL,
	PRIMARY KEY (especialidad_codigo, prof_id),
	FOREIGN KEY (especialidad_codigo) REFERENCES gd_MORCIPAN.especialidades (especialidad_codigo),
	FOREIGN KEY (prof_id) REFERENCES gd_MORCIPAN.profesionales (prof_id)	
);

/* 	TABLA: agendas_profesionales
	DESCRIPCION: Tabla con las agenda de los profesionales
*/
CREATE TABLE gd_MORCIPAN.agendas_profesionales(

	agenda_id						INT IDENTITY(1,1) NOT NULL,
	agen_fecha_ini					DATETIME NOT NULL,
	agen_fecha_fin					DATETIME NOT NULL,
	prof_id							INT NOT NULL,
	habilitada						BIT DEFAULT 1,				
	PRIMARY KEY (agenda_id),
	FOREIGN KEY (prof_id) REFERENCES gd_MORCIPAN.profesionales (prof_id)
);

/* 	TABLA: turnos
	DESCRIPCION: Tabla de los turnos del sistema
*/
CREATE TABLE gd_MORCIPAN.turnos(

	turno_numero			NUMERIC(18,0) NOT NULL,
	turno_fecha				DATETIME NOT NULL,
	afiliado_numero			INT, -- TURNO LIBRE
	prof_id					INT NOT NULL,
	cancelado				BIT DEFAULT 0,	-- registro si cancelan el turno, el turno sigue disponible
	habilitado				BIT DEFAULT 1,	-- baja logica del turno, baja profesional
	--agenda_id				INT,-- NOT NULL, -- agenda a la que pertenece, SACO NOT NULL por MIGRACION
	PRIMARY KEY (turno_numero),
	FOREIGN KEY (afiliado_numero) REFERENCES gd_MORCIPAN.afiliados (afiliado_numero),
	FOREIGN KEY (prof_id) REFERENCES gd_MORCIPAN.profesionales (prof_id)
	--FOREIGN KEY (agenda_id) REFERENCES gd_MORCIPAN.agendas_profesionales (agenda_id)
);

/* 	TABLA: cancelacion_turnos
	DESCRIPCION: Registro de porque se cancelo el turno
*/
CREATE TABLE gd_MORCIPAN.cancelacion_turnos(

	cancelacion_id				INT IDENTITY (1,1) NOT NULL,
	turno_numero				NUMERIC(18,0) NOT NULL,
	tipo_cancelacion			NVARCHAR(50),
	cancelacion_motivo			NVARCHAR(255),				
	PRIMARY KEY (cancelacion_id),
	FOREIGN KEY (turno_numero) REFERENCES gd_MORCIPAN.turnos (turno_numero)	
);

/* 	TABLA: bonos_consulta
	DESCRIPCION: Tabla de los bonos consulta que tiene un usuario
*/
CREATE TABLE gd_MORCIPAN.bonos_consulta(

	bono_consulta_numero			NUMERIC(18,0) NOT NULL,
	bono_consulta_fecha_impresion	DATETIME NOT NULL,
	bono_compra_fecha				DATETIME NOT NULL,
	afiliado_numero					INT NOT NULL,
	afiliado_utilizo				INT, -- puede estar sin usar
	plan_codigo						NUMERIC(18,0) NOT NULL,
	habilitado						BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (bono_consulta_numero),
	FOREIGN KEY (afiliado_numero) REFERENCES gd_MORCIPAN.afiliados (afiliado_numero),
	FOREIGN KEY (afiliado_utilizo) REFERENCES gd_MORCIPAN.afiliados (afiliado_numero),
	FOREIGN KEY (plan_codigo) REFERENCES gd_MORCIPAN.planes (plan_codigo)

);

/* 	TABLA: medicamentos
	DESCRIPCION: Tabla de los posibles medicamentos (export Maestra)
*/
CREATE TABLE gd_MORCIPAN.medicamentos(

	medicamento_id						INT IDENTITY(1,1) NOT NULL,
	medicamento_descp					VARCHAR(255),
	PRIMARY KEY (medicamento_id)
);

/* 	TABLA: bonos_farmacia
	DESCRIPCION: Tabla de los bonos farmacia que tiene un usuario
*/
CREATE TABLE gd_MORCIPAN.bonos_farmacia(

	bono_farmacia_numero			NUMERIC(18,0) NOT NULL,
	bono_farmacia_fecha_impresion	DATETIME NOT NULL,
	bono_farmacia_fecha_vencimiento	DATETIME NOT NULL,
	bono_compra_fecha				DATETIME NOT NULL,
	afiliado_numero					INT NOT NULL,
	afiliado_utilizo				INT, -- puede estar sin usar
	plan_codigo						NUMERIC(18,0) NOT NULL,
	habilitado						BIT NOT NULL DEFAULT 1,
	fecha_prescrip_med				DATETIME,
	PRIMARY KEY (bono_farmacia_numero),
	FOREIGN KEY (afiliado_numero) REFERENCES gd_MORCIPAN.afiliados (afiliado_numero),
	FOREIGN KEY (afiliado_utilizo) REFERENCES gd_MORCIPAN.afiliados (afiliado_numero),
	FOREIGN KEY (plan_codigo) REFERENCES gd_MORCIPAN.planes (plan_codigo)

);

/* 	TABLA: bonosFarmacia_medicamentos
	DESCRIPCION: Tabla que guarda la relacion de un bono farmacia con sus medicamentos
*/
CREATE TABLE gd_MORCIPAN.bonosFarmacia_medicamentos(

	bono_farmacia_numero			NUMERIC(18,0) NOT NULL,
	medicamento_id					INT NOT NULL,
	cantidad						INT NOT NULL,
	--UNIQUE (bono_farmacia_numero, medicamento_id), NO HACE FALTA POR PK
	PRIMARY KEY (bono_farmacia_numero, medicamento_id),
	FOREIGN KEY (bono_farmacia_numero) REFERENCES gd_MORCIPAN.bonos_farmacia (bono_farmacia_numero),
	FOREIGN KEY (medicamento_id) REFERENCES gd_MORCIPAN.medicamentos (medicamento_id),
);

/* 	TABLA: compras_bonos_afiliados
	DESCRIPCION: Registra la compra de bonos
*/
CREATE TABLE gd_MORCIPAN.compras_bonos_afiliados(

	compra_id						INT IDENTITY(1,1) NOT NULL,
	compra_fecha					DATETIME NOT NULL,
	afiliado_numero					INT NOT NULL,
	cantidad_bonos_con				INT, -- puede ser null, compra un solo tipo de bono
	cantidad_bonos_far				INT, -- puede ser null, compra un solo tipo de bono	
	monto_total						NUMERIC(18,2) NOT NULL,	
	PRIMARY KEY (compra_id),
	FOREIGN KEY (afiliado_numero) REFERENCES gd_MORCIPAN.afiliados(afiliado_numero)
);

/* 	TABLA: recetas_medicas
	DESCRIPCION: Tabla de los bonos farmacia que tiene un usuario
*/
CREATE TABLE gd_MORCIPAN.recetas_medicas(

	receta_id						INT IDENTITY(1,1) NOT NULL,
	receta_fecha					DATETIME NOT NULL
	PRIMARY KEY (receta_id)
	
);

/* 	TABLA: bonosFarmacia_recetas
	DESCRIPCION: Tabla que guarda la relacion entre varios bonos farmacias
	con una receta
*/
CREATE TABLE gd_MORCIPAN.bonosFarmacia_recetas(

	receta_id						INT NOT NULL,
	bono_farmacia_numero			NUMERIC(18,0) NOT NULL,
	PRIMARY KEY (receta_id, bono_farmacia_numero),
	FOREIGN KEY (receta_id) REFERENCES gd_MORCIPAN.recetas_medicas (receta_id),
	FOREIGN KEY (bono_farmacia_numero) REFERENCES gd_MORCIPAN.bonos_farmacia (bono_farmacia_numero)
);

/* 	TABLA: consultas_medicas
	DESCRIPCION: Tabla que asocia los turnos con los bonos utilizados por el afiliado
*/
CREATE TABLE gd_MORCIPAN.consultas_medicas(

	consulta_id						INT IDENTITY (1,1) NOT NULL,
	turno_numero					NUMERIC(18,0) NOT NULL,
	afiliado_numero					INT NOT NULL,
	bono_consulta_numero			NUMERIC(18,0) NOT NULL UNIQUE,
	receta_id						INT, -- puede ser null, consulta no requiere receta
	estado							VARCHAR(50) NOT NULL,
	registro_llegada				DATETIME DEFAULT NULL,
	registro_atencion				DATETIME DEFAULT NULL,
	consulta_sintomas				VARCHAR(255),
	consulta_enfermedades			VARCHAR(255),
	habilitada						BIT NOT NULL DEFAULT 1, -- se utiliza para cuando se da de baja logica un afiliado, migracion en el diome, futuras consultas medicas ya creadas 
	PRIMARY KEY (consulta_id, turno_numero),		--no puede haber un turno dos veces 
	FOREIGN KEY (afiliado_numero) REFERENCES gd_MORCIPAN.afiliados (afiliado_numero),
	FOREIGN KEY (bono_consulta_numero) REFERENCES gd_MORCIPAN.bonos_consulta (bono_consulta_numero),
	FOREIGN KEY (turno_numero) REFERENCES gd_MORCIPAN.turnos (turno_numero),
	FOREIGN KEY (receta_id) REFERENCES gd_MORCIPAN.recetas_medicas (receta_id)
);

COMMIT TRAN CreacionTablas

/* ******************************************************************************************************************** */
/* ***************************************** INICIALIZACION DE DATOS ************************************************** */

BEGIN TRAN InicializacionDeDatos

	/* INSERTAMOS USUARIOS admins */
	INSERT INTO gd_MORCIPAN.usuarios (usuario_nombre, usuario_password) VALUES ('admin', '5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=');
	INSERT INTO gd_MORCIPAN.usuarios (usuario_nombre, usuario_password) VALUES ('admin2', '5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=');
	INSERT INTO gd_MORCIPAN.usuarios (usuario_nombre, usuario_password) VALUES ('admin3', '5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=');
	INSERT INTO gd_MORCIPAN.usuarios (usuario_nombre, usuario_password) VALUES ('admin4', '5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=');
	
	/*	INSERTAMOS ROLES	*/
	INSERT INTO gd_MORCIPAN.roles (rol_nombre) VALUES ('Administrativo');
	INSERT INTO gd_MORCIPAN.roles (rol_nombre) VALUES ('Afiliado');
	INSERT INTO gd_MORCIPAN.roles (rol_nombre) VALUES ('Profesional');
	
	/*	INSERTAMOS FUNCIONES	*/
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('ABM de Rol');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('ABM de Afiliados');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('ABM de Profesional');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('Registrar Agenda Profesional');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('Compra de Bonos');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('Pedido de Turno');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('Registro de llegada para atención médica');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('Registro de resultado para atención médica');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('Cancelacion atención médica');
	INSERT INTO gd_MORCIPAN.funciones (funcion_nombre) VALUES ('Listados Estadísticos');
	
	/*	INSERTAMOS FUNCIONALIDADES A ROLES	*/
	--admin
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (1, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (2, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (3, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (4, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (5, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (6, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (7, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (8, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (9, 1)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (10, 1)

	--afiliado
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (5, 2)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (6, 2)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (9, 2)
		
	--profesional
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (4, 3)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (8, 3)
	INSERT INTO gd_MORCIPAN.funciones_roles (funcion_id, rol_id) VALUES (9, 3)
	
	/*	INSERTAMOS ROLES A USUARIOS	*/
	INSERT INTO gd_MORCIPAN.roles_usuarios (rol_id, usuario_id) VALUES (1, 1)
	INSERT INTO gd_MORCIPAN.roles_usuarios (rol_id, usuario_id) VALUES (1, 2)
	INSERT INTO gd_MORCIPAN.roles_usuarios (rol_id, usuario_id) VALUES (1, 3)
	INSERT INTO gd_MORCIPAN.roles_usuarios (rol_id, usuario_id) VALUES (1, 4)
	
COMMIT TRAN InicializacionDeDatos

/* ******************************************************************************************************************** */
/* ***************************************** MIGRACION DE DATOS ******************************************************* */

/* PROCEDURE: spObtenerNuevaSecuenciaTabla
   DESCRIPCION: Obtiene una secuencia de la tabla de secuencias.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerNuevaSecuenciaTabla')
	DROP PROCEDURE gd_MORCIPAN.spObtenerNuevaSecuenciaTabla
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerNuevaSecuenciaTabla
	@nombre_tabla	VARCHAR(255),
	@retornar		BIT,
	@inicial		INT,
	@incremento		INT
AS
BEGIN
	DECLARE @valor_secuencia INT
	
	IF EXISTS(SELECT tabla_secuencia_valor 
		      FROM gd_MORCIPAN.tablas_secuencias 
		      WHERE tabla_nombre = @nombre_tabla)
	BEGIN
		SELECT @valor_secuencia = tabla_secuencia_valor 
		FROM gd_MORCIPAN.tablas_secuencias
		WHERE tabla_nombre = @nombre_tabla;
		
		SET @valor_secuencia=@valor_secuencia+@incremento;
	
		UPDATE gd_MORCIPAN.tablas_secuencias 
		SET tabla_secuencia_valor = @valor_secuencia 
		WHERE tabla_nombre = @nombre_tabla;
	END
	ELSE
	BEGIN
		SET @valor_secuencia = @inicial;
		
		INSERT INTO gd_MORCIPAN.tablas_secuencias 
		(tabla_nombre, tabla_secuencia_valor)
		VALUES
		(@nombre_tabla, @valor_secuencia);
	END
	IF @retornar = 0
	BEGIN
		SELECT @valor_secuencia;
	END
	ELSE
	BEGIN
		RETURN @valor_secuencia;
	END
END;
GO

/*	MIGRACION PLANES	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionPlanes')
	DROP PROCEDURE gd_MORCIPAN.spMigracionPlanes;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionPlanes
AS
BEGIN
	IF NOT EXISTS (SELECT plan_codigo FROM gd_MORCIPAN.planes WHERE plan_codigo 
											IN (SELECT DISTINCT Plan_Med_Codigo FROM gd_esquema.Maestra))
		BEGIN
			INSERT INTO gd_MORCIPAN.planes 
			(plan_codigo,plan_descripcion,plan_precio_bono_consulta, plan_precio_bono_farmacia) 
			SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
			FROM gd_esquema.Maestra
		END
END
GO
EXEC gd_MORCIPAN.spMigracionPlanes;
GO

/*	MIGRACION TIPO ESPECIALIDADES	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionTipoEspecialidades')
	DROP PROCEDURE gd_MORCIPAN.spMigracionTipoEspecialidades;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionTipoEspecialidades
AS
BEGIN
	IF NOT EXISTS (SELECT tipo_esp_codigo FROM gd_MORCIPAN.tipo_especialidades WHERE tipo_esp_codigo
											IN (SELECT DISTINCT Tipo_Especialidad_Codigo FROM gd_esquema.Maestra))
		BEGIN
			INSERT INTO gd_MORCIPAN.tipo_especialidades 
			(tipo_esp_codigo,tipo_esp_descrip)
			SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
			FROM gd_esquema.Maestra WHERE Tipo_Especialidad_Codigo IS NOT NULL 
			AND Tipo_Especialidad_Descripcion IS NOT NULL
		END
END
GO
EXEC gd_MORCIPAN.spMigracionTipoEspecialidades;
GO

/*	MIGRACION ESPECIALIDADES	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionEspecialidades')
	DROP PROCEDURE gd_MORCIPAN.spMigracionEspecialidades;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionEspecialidades
AS
BEGIN
	IF NOT EXISTS (SELECT especialidad_codigo FROM gd_MORCIPAN.especialidades WHERE especialidad_codigo
											IN (SELECT DISTINCT Especialidad_Codigo FROM gd_esquema.Maestra))
		BEGIN
			INSERT INTO gd_MORCIPAN.especialidades 
			(especialidad_codigo,especialidad_descrip, tipo_esp_codigo)
			SELECT DISTINCT Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
			FROM gd_esquema.Maestra WHERE Especialidad_Codigo IS NOT NULL 
			AND Especialidad_Descripcion IS NOT NULL
		END
END
GO
EXEC gd_MORCIPAN.spMigracionEspecialidades;
GO

/*	MIGRACION AFILIADOS	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionAfiliadosCustom')
	DROP PROCEDURE gd_MORCIPAN.spMigracionAfiliadosCustom;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionAfiliadosCustom
AS
BEGIN
	DECLARE cursorAfiliados CURSOR FOR  
		SELECT DISTINCT Paciente_Apellido, 
						Paciente_Nombre, 
						Paciente_Dni, 
						Paciente_Fecha_Nac, 
						Paciente_Mail, 
						Paciente_Direccion, 
						Paciente_Telefono, 
						Plan_Med_Codigo
		FROM gd_esquema.Maestra
		
	OPEN cursorAfiliados
	DECLARE @afiliado_apellido VARCHAR(255)
	DECLARE @afiliado_nombre VARCHAR(255)
	DECLARE @afiliado_nro_documento INT
	DECLARE @afiliado_fecha_nacimiento DATETIME
	DECLARE @afiliado_email VARCHAR(255)
	DECLARE @afiliado_direccion VARCHAR(255)
	DECLARE @afiliado_telefono INT
	DECLARE @afiliado_plan_medico_codigo INT
	FETCH NEXT FROM cursorAfiliados INTO 
		@afiliado_apellido,
		@afiliado_nombre,
		@afiliado_nro_documento,
		@afiliado_fecha_nacimiento,
		@afiliado_email,
		@afiliado_direccion,
		@afiliado_telefono,
		@afiliado_plan_medico_codigo
		
	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		DECLARE @afiliado_numero INT
		EXEC @afiliado_numero = GD2C2013.gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'afiliado',1, 101, 100
		 
		 INSERT INTO gd_MORCIPAN.usuarios
		 (usuario_nombre, usuario_password)
		 VALUES
		 ('DNI' + CONVERT(NVARCHAR, @afiliado_nro_documento), 'GurrpL2/iQdjhDS2BQSxA3wBkFvsKU+yzVNIck8vpk8=')
		 
		 DECLARE @usuario_id INT
		 SELECT @usuario_id = SCOPE_IDENTITY()
		 
		INSERT INTO gd_MORCIPAN.afiliados 
		(afiliado_numero,afiliado_apellido,afiliado_nombre,afiliado_nro_documento,afiliado_fecha_nacimiento,
		 afiliado_email, afiliado_direccion, afiliado_telefono, afiliado_plan_medico_codigo, usuario_id)
		VALUES
		(@afiliado_numero,@afiliado_apellido,@afiliado_nombre,@afiliado_nro_documento,@afiliado_fecha_nacimiento,
		 @afiliado_email, @afiliado_direccion, @afiliado_telefono, @afiliado_plan_medico_codigo, @usuario_id)		 
		 
		 INSERT INTO gd_MORCIPAN.roles_usuarios
		 (rol_id, usuario_id)
		 VALUES
		 (2, @usuario_id)
		 
	   FETCH NEXT FROM cursorAfiliados INTO 
			@afiliado_apellido,
			@afiliado_nombre,
			@afiliado_nro_documento,
			@afiliado_fecha_nacimiento,
			@afiliado_email,
			@afiliado_direccion,
			@afiliado_telefono,
			@afiliado_plan_medico_codigo
	END   

	CLOSE cursorAfiliados
	DEALLOCATE cursorAfiliados
	
END
GO
EXEC gd_MORCIPAN.spMigracionAfiliadosCustom;
GO
/*
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionAfiliadosCustom')
	DROP PROCEDURE gd_MORCIPAN.spMigracionAfiliadosCustom;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionAfiliadosCustom
AS
BEGIN
	DECLARE cursorAfiliados CURSOR FOR  
		SELECT DISTINCT Paciente_Apellido, 
						Paciente_Nombre, 
						Paciente_Dni, 
						Paciente_Fecha_Nac, 
						Paciente_Mail, 
						Paciente_Direccion, 
						Paciente_Telefono, 
						Plan_Med_Codigo
		FROM gd_esquema.Maestra
		
	OPEN cursorAfiliados
	DECLARE @afiliado_apellido VARCHAR(255)
	DECLARE @afiliado_nombre VARCHAR(255)
	DECLARE @afiliado_nro_documento INT
	DECLARE @afiliado_fecha_nacimiento DATETIME
	DECLARE @afiliado_email VARCHAR(255)
	DECLARE @afiliado_direccion VARCHAR(255)
	DECLARE @afiliado_telefono INT
	DECLARE @afiliado_plan_medico_codigo INT
	FETCH NEXT FROM cursorAfiliados INTO 
		@afiliado_apellido,
		@afiliado_nombre,
		@afiliado_nro_documento,
		@afiliado_fecha_nacimiento,
		@afiliado_email,
		@afiliado_direccion,
		@afiliado_telefono,
		@afiliado_plan_medico_codigo
		
	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		DECLARE @afiliado_numero INT
		EXEC @afiliado_numero = GD2C2013.gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'afiliado',1, 101, 100
		
		INSERT INTO gd_MORCIPAN.afiliados 
		(afiliado_numero,afiliado_apellido,afiliado_nombre,afiliado_nro_documento,afiliado_fecha_nacimiento,
		 afiliado_email, afiliado_direccion, afiliado_telefono, afiliado_plan_medico_codigo)
		VALUES
		(@afiliado_numero,@afiliado_apellido,@afiliado_nombre,@afiliado_nro_documento,@afiliado_fecha_nacimiento,
		 @afiliado_email, @afiliado_direccion, @afiliado_telefono, @afiliado_plan_medico_codigo)
		 
	   FETCH NEXT FROM cursorAfiliados INTO 
			@afiliado_apellido,
			@afiliado_nombre,
			@afiliado_nro_documento,
			@afiliado_fecha_nacimiento,
			@afiliado_email,
			@afiliado_direccion,
			@afiliado_telefono,
			@afiliado_plan_medico_codigo
	END   

	CLOSE cursorAfiliados
	DEALLOCATE cursorAfiliados
	
END
GO

EXEC gd_MORCIPAN.spMigracionAfiliadosCustom;
GO


IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionAfiliados')
	DROP PROCEDURE gd_MORCIPAN.spMigracionAfiliados;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionAfiliados
AS
BEGIN
	IF NOT EXISTS (SELECT afiliado_nro_documento FROM gd_MORCIPAN.afiliados WHERE afiliado_nro_documento 
											IN (SELECT DISTINCT Paciente_Dni FROM gd_esquema.Maestra))
		BEGIN
			INSERT INTO gd_MORCIPAN.afiliados 
			(afiliado_apellido,afiliado_nombre,afiliado_nro_documento,afiliado_fecha_nacimiento,
			afiliado_email, afiliado_direccion, afiliado_telefono, afiliado_plan_medico_codigo) 
			
			SELECT DISTINCT Paciente_Apellido, Paciente_Nombre, Paciente_Dni, Paciente_Fecha_Nac, Paciente_Mail, Paciente_Direccion, Paciente_Telefono, Plan_Med_Codigo
			FROM gd_esquema.Maestra
		END

	-- alteramos la tabla para que no falle los inserts de los familiares a cargo
	ALTER TABLE gd_MORCIPAN.afiliados ALTER COLUMN afiliado_numero INT NOT NULL

END
GO

EXEC gd_MORCIPAN.spMigracionAfiliados;
GO
*/

/*	MIGRACION PROFESIONALES	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionProfesionales')
	DROP PROCEDURE gd_MORCIPAN.spMigracionProfesionales;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionProfesionales
AS
BEGIN
	DECLARE cursorProfesionales CURSOR FOR  
		SELECT DISTINCT Medico_Nombre, 
						Medico_Apellido, 
						Medico_Dni, 
						Medico_Direccion, 
						Medico_Telefono, 
						Medico_Mail, 
						Medico_Fecha_Nac
		FROM gd_esquema.Maestra WHERE Medico_Dni IS NOT NULL
	OPEN cursorProfesionales
	DECLARE @prof_nombre VARCHAR(255)
	DECLARE @prof_apellido VARCHAR(255)
	DECLARE @prof_num_dni INT
	DECLARE @prof_direccion VARCHAR(255)
	DECLARE @prof_telefono INT
	DECLARE @prof_mail VARCHAR(255)
	DECLARE @prof_fechaNac DATETIME
	FETCH NEXT FROM cursorProfesionales INTO 
		@prof_nombre,
		@prof_apellido,
		@prof_num_dni,
		@prof_direccion,
		@prof_telefono,
		@prof_mail,
		@prof_fechaNac
		
	WHILE @@FETCH_STATUS = 0   
	BEGIN
		 
		INSERT INTO gd_MORCIPAN.usuarios
		(usuario_nombre, usuario_password)
		VALUES
		('DNI' + CONVERT(NVARCHAR, @prof_num_dni), 'JK/kfQvTAq5CZDxYSNmbaDJkAmzRLMmY4F4QC78tww0=')
		 
		DECLARE @usuario_id INT
		SELECT @usuario_id = SCOPE_IDENTITY()
		  
		INSERT INTO gd_MORCIPAN.profesionales 
		(prof_nombre, prof_apellido, prof_num_dni,prof_direccion, prof_telefono, prof_mail, prof_fechaNac, usuario_id)
		VALUES
		(@prof_nombre, @prof_apellido, @prof_num_dni, @prof_direccion, @prof_telefono, @prof_mail, @prof_fechaNac, @usuario_id)

		 
		INSERT INTO gd_MORCIPAN.roles_usuarios
		(rol_id, usuario_id)
		VALUES
		(3, @usuario_id)
		 
		FETCH NEXT FROM cursorProfesionales INTO 
			@prof_nombre,
			@prof_apellido,
			@prof_num_dni,
			@prof_direccion,
			@prof_telefono,
			@prof_mail,
			@prof_fechaNac
	END   

	CLOSE cursorProfesionales
	DEALLOCATE cursorProfesionales
END
GO
EXEC gd_MORCIPAN.spMigracionProfesionales;
GO
/*
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionProfesionales')
	DROP PROCEDURE gd_MORCIPAN.spMigracionProfesionales;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionProfesionales
AS
BEGIN
	IF NOT EXISTS (SELECT prof_num_dni FROM gd_MORCIPAN.profesionales WHERE prof_num_dni
											IN (SELECT DISTINCT Medico_Dni FROM gd_esquema.Maestra))
		BEGIN
			INSERT INTO gd_MORCIPAN.profesionales 
				(prof_nombre, prof_apellido, prof_num_dni,prof_direccion, prof_telefono, prof_mail, prof_fechaNac)	
			SELECT DISTINCT Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
			FROM gd_esquema.Maestra WHERE Medico_Dni IS NOT NULL
		END
END
GO
EXEC gd_MORCIPAN.spMigracionProfesionales;
GO
*/
/*	MIGRACION ESPECIALIDADES PROFESIONALES	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionEspecialidadesProfesionales')
	DROP PROCEDURE gd_MORCIPAN.spMigracionEspecialidadesProfesionales;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionEspecialidadesProfesionales
AS
BEGIN
	/*IF NOT EXISTS (SELECT especialidad_codigo,prof_id  FROM gd_MORCIPAN.especialidades_profesionales WHERE (especialidad_codigo, prof_id)
											IN (SELECT DISTINCT Medico_Dni FROM gd_esquema.Maestra))*/
		BEGIN
			INSERT INTO gd_MORCIPAN.especialidades_profesionales 
				(especialidad_codigo, prof_id)	
						
			SELECT DISTINCT

			-- especialidad_codigo
			(SELECT MA.Especialidad_Codigo) as especialidad_codigo,
			
			-- prof_id
			(SELECT prof_id FROM gd_Morcipan.profesionales WHERE prof_num_dni = MA.Medico_DNI)
			
			FROM gd_esquema.Maestra MA WHERE MA.Especialidad_Codigo IS NOT NULL AND MA.Medico_DNI IS NOT NULL 
		END
END
GO
EXEC gd_MORCIPAN.spMigracionEspecialidadesProfesionales;
GO

/*	MIGRACION TURNOS	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionTurnos')
	DROP PROCEDURE gd_MORCIPAN.spMigracionTurnos;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionTurnos
AS
BEGIN
	IF NOT EXISTS (SELECT turno_numero  FROM gd_MORCIPAN.turnos WHERE (turno_numero)
											IN (SELECT DISTINCT Turno_Numero FROM gd_esquema.Maestra))
		BEGIN
			INSERT INTO gd_MORCIPAN.turnos 
				(turno_numero, turno_fecha, afiliado_numero, prof_id)	
						
			SELECT DISTINCT

			-- turno_numero
			(SELECT MA.Turno_Numero) as turno_numero,
			
			-- turno_fecha
			(SELECT MA.Turno_Fecha) as turno_fecha,
			
			-- afiliado_numero
			(SELECT afiliado_numero FROM gd_MORCIPAN.afiliados WHERE afiliado_nro_documento = MA.Paciente_Dni),
			
			-- prof_id
			(SELECT prof_id FROM gd_MORCIPAN.profesionales WHERE prof_num_dni = MA.Medico_Dni)
			
			FROM gd_esquema.Maestra MA WHERE MA.Turno_Numero IS NOT NULL
			
			INSERT INTO gd_MORCIPAN.tablas_secuencias (tabla_nombre, tabla_secuencia_valor)
			VALUES
			('turnos', (SELECT TOP 1 turno_numero FROM gd_MORCIPAN.turnos ORDER BY turno_numero DESC))			
		END
END
GO
EXEC gd_MORCIPAN.spMigracionTurnos;
GO

/*	MIGRACION BONOS CONSULTA	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionBonosConsulta')
	DROP PROCEDURE gd_MORCIPAN.spMigracionBonosConsulta;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionBonosConsulta
AS
BEGIN
	IF NOT EXISTS (SELECT bono_consulta_numero  FROM gd_MORCIPAN.bonos_consulta WHERE (bono_consulta_numero)
											IN (SELECT DISTINCT Bono_Consulta_Numero FROM gd_esquema.Maestra))
		BEGIN
			INSERT INTO gd_MORCIPAN.bonos_consulta
				(bono_consulta_numero, bono_consulta_fecha_impresion, bono_compra_fecha, afiliado_numero, afiliado_utilizo, plan_codigo) --, habilitado)	
						
			SELECT DISTINCT

			-- bono_consulta_numero
			(SELECT MA.Bono_Consulta_Numero) as bono_consulta_numero,
			
			-- bono_consulta_fecha_impresion
			(SELECT MA.Bono_Consulta_Fecha_Impresion) as bono_consulta_fecha_impresion,
			
			-- bono_compra_fecha
			(SELECT MA.Compra_Bono_Fecha) as bono_compra_fecha,			
			
			-- afiliado_numero
			(SELECT afiliado_numero FROM gd_MORCIPAN.afiliados WHERE afiliado_nro_documento = MA.Paciente_Dni) as afiliado_numero,
						
			-- afiliado_utilizo
			(SELECT NULL) as afiliado_utilizo,--(SELECT afiliado_numero FROM gd_MORCIPAN.afiliados WHERE afiliado_nro_documento = MA.Paciente_Dni) as afiliado_utilizo,

			-- plan_cogigo
			(SELECT MA.Plan_Med_Codigo AS plan_cogigo)
			
			-- habilitado, bono utilizado
			--(SELECT 0) AS habilitado	
						
			FROM gd_esquema.Maestra MA WHERE MA.Bono_Consulta_Numero IS NOT NULL AND MA.Compra_Bono_Fecha IS NOT NULL
			
			INSERT INTO gd_MORCIPAN.tablas_secuencias (tabla_nombre, tabla_secuencia_valor)
			VALUES
			('bonos_consulta', (SELECT TOP 1 bono_consulta_numero FROM gd_MORCIPAN.bonos_consulta ORDER BY bono_consulta_numero DESC))	
			
		END
END
GO
EXEC gd_MORCIPAN.spMigracionBonosConsulta;
GO

/*	MIGRACION MEDICAMENTOS	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionMedicamentos')
	DROP PROCEDURE gd_MORCIPAN.spMigracionMedicamentos;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionMedicamentos
AS
BEGIN
		BEGIN
			INSERT INTO gd_MORCIPAN.medicamentos
				(medicamento_descp)	
						
			SELECT DISTINCT Bono_Farmacia_Medicamento	
			FROM gd_esquema.Maestra MA WHERE MA.Bono_Farmacia_Medicamento IS NOT NULL

		END
END
GO
EXEC gd_MORCIPAN.spMigracionMedicamentos;
GO

/*	MIGRACION BONOS FARMACIA	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionBonosFarmacia')
	DROP PROCEDURE gd_MORCIPAN.spMigracionBonosFarmacia;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionBonosFarmacia
AS
BEGIN
	IF NOT EXISTS (SELECT bono_farmacia_numero  FROM gd_MORCIPAN.bonos_farmacia WHERE (bono_farmacia_numero)
											IN (SELECT DISTINCT Bono_Farmacia_Numero FROM gd_esquema.Maestra))
		BEGIN
			INSERT INTO gd_MORCIPAN.bonos_farmacia
				(bono_farmacia_numero, bono_farmacia_fecha_impresion, bono_farmacia_fecha_vencimiento, afiliado_numero, afiliado_utilizo, bono_compra_fecha, plan_codigo)--, habilitado)	
						
			SELECT DISTINCT

			-- bono_farmacia_numero
			(SELECT MA.Bono_Farmacia_Numero) as bono_farmacia_numero,
			
			-- bono_farmacia_fecha_impresion
			(SELECT MA.Bono_Farmacia_Fecha_Impresion) as bono_farmacia_fecha_impresion,

			-- bono_farmacia_fecha_vencimiento
			(SELECT MA.Bono_Farmacia_Fecha_Vencimiento) as bono_farmacia_fecha_vencimiento,
									
			-- afiliado_numero
			(SELECT afiliado_numero FROM gd_MORCIPAN.afiliados WHERE afiliado_nro_documento = MA.Paciente_Dni) as afiliado_numero,

			-- afiliado_utilizo
			(SELECT NULL) as afiliado_utilizo, --(SELECT afiliado_numero FROM gd_MORCIPAN.afiliados WHERE afiliado_nro_documento = MA.Paciente_Dni) as afiliado_utilizo,

			-- bono_compra_fecha
			(SELECT MA.Compra_Bono_Fecha) as bono_compra_fecha,
									
			-- plan_cogigo
			(SELECT MA.Plan_Med_Codigo AS plan_cogigo)
			
			-- habilitado, bono utilizado
			--(SELECT 0) AS habilitado					
									
			FROM gd_esquema.Maestra MA WHERE MA.Bono_Farmacia_Numero IS NOT NULL AND MA.Compra_Bono_Fecha IS NOT NULL

			INSERT INTO gd_MORCIPAN.tablas_secuencias (tabla_nombre, tabla_secuencia_valor)
			VALUES
			('bonos_farmacia', (SELECT TOP 1 bono_farmacia_numero FROM gd_MORCIPAN.bonos_farmacia ORDER BY bono_farmacia_numero DESC))	


			-- updeteamos los medicamentos
			INSERT INTO gd_MORCIPAN.bonosFarmacia_medicamentos
			(bono_farmacia_numero, medicamento_id, cantidad)
			SELECT DISTINCT
			
			-- bono_farmacia_numero
			(SELECT MA.Bono_Farmacia_Numero) as bono_farmacia_numero,
			
			(SELECT medicamento_id FROM gd_MORCIPAN.medicamentos WHERE medicamento_descp = MA.Bono_Farmacia_Medicamento),
			
			(SELECT 1) as cantidad
			
			FROM gd_esquema.Maestra MA WHERE MA.Bono_Farmacia_Numero IS NOT NULL AND MA.Bono_Farmacia_Medicamento IS NOT NULL

			
			/*UPDATE gd_MORCIPAN.bonos_farmacia
			SET 
			medicamento_1 = MED.medicamento_id,
			cantidad_1 = 1
			FROM  gd_esquema.Maestra MA
			JOIN gd_MORCIPAN.medicamentos MED ON MA.Bono_Farmacia_Medicamento = MED.medicamento_descp
			WHERE MA.Bono_Farmacia_Medicamento is not null
			AND  MA.Bono_Farmacia_Numero = bonos_farmacia.bono_farmacia_numero*/

		END
END
GO
EXEC gd_MORCIPAN.spMigracionBonosFarmacia;
GO

/*	FUNCTION: fnObtenerPreciosBonos
	DESCRIPCION: Devuelve el precio de un bono dependiendo del plan.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnObtenerPreciosBonos')
	DROP FUNCTION gd_MORCIPAN.fnObtenerPreciosBonos
GO
CREATE FUNCTION gd_MORCIPAN.fnObtenerPreciosBonos(
	@afiliado_plan_medico		VARCHAR(255),
	@tipo_bono	VARCHAR(255)
)
RETURNS INT
AS
BEGIN
	DECLARE @res INT

	IF @tipo_bono = 'FARMACIA'
	BEGIN
		SELECT @res = P.plan_precio_bono_farmacia
		FROM gd_MORCIPAN.planes P
		WHERE P.plan_descripcion LIKE '%' + @afiliado_plan_medico + '%'
	END
	ELSE
	BEGIN
		SELECT @res = P.plan_precio_bono_consulta
		FROM gd_MORCIPAN.planes P
		WHERE P.plan_descripcion LIKE '%' + @afiliado_plan_medico + '%'
	END
	
	RETURN @res
END;
GO

/*	MIGRACION COMPRA BONOS AFILIADOS	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionCompraBonosAfiliados')
	DROP PROCEDURE gd_MORCIPAN.spMigracionCompraBonosAfiliados;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionCompraBonosAfiliados
AS
BEGIN
	--IF NOT EXISTS (SELECT bono_farmacia_numero  FROM gd_MORCIPAN.bonos_farmacia WHERE (bono_farmacia_numero)
	--										IN (SELECT DISTINCT Bono_Farmacia_Numero FROM gd_esquema.Maestra))
		--BEGIN
		
			DECLARE @tmp TABLE (
			compra_fecha			DATETIME,
			afiliado_numero			INT,
			plan_med_descripcion	VARCHAR(255),
			bono_consulta_numero	NUMERIC(18,0),
			bono_farmacia_numero	NUMERIC(18,0)
			)
			
			INSERT INTO @tmp
			(compra_fecha, afiliado_numero, plan_med_descripcion, bono_consulta_numero, bono_farmacia_numero)
			
			SELECT DISTINCT

			-- compra_fecha
			(SELECT MA.Compra_Bono_Fecha) as compra_fecha,

			-- afiliado_numero
			(SELECT afiliado_numero FROM gd_MORCIPAN.afiliados WHERE afiliado_nro_documento = MA.Paciente_Dni),
			
			-- plan_med_descripcion
			(SELECT MA.Plan_Med_Descripcion) as plan_med_descripcion,
						
			-- bono_consulta_numero
			(SELECT MA.Bono_Consulta_Numero) as bono_consulta_numero,

			-- bono_farmacia_numero
			(SELECT MA.Bono_Farmacia_Numero) as bono_farmacia_numero			
									
			FROM gd_esquema.Maestra MA WHERE MA.Compra_Bono_Fecha IS NOT NULL
			
			
			-- pasamos a nuestro modelo
			DECLARE @monto INT
			DECLARE @paso INT
			DECLARE @hayBonoCon INT
			DECLARE @hayBonoFar INT
			
			DECLARE compraBonosCursor CURSOR FOR
			SELECT compra_fecha, afiliado_numero, plan_med_descripcion, bono_consulta_numero, bono_farmacia_numero FROM @tmp
			DECLARE @compra_fecha DATETIME, @afiliado_numero INT, @plan_med_descripcion VARCHAR(255), @bono_consulta_numero	NUMERIC(18,0), 
			@bono_farmacia_numero NUMERIC(18,0), @compra_bono_fecha DATETIME		
			
			OPEN compraBonosCursor;
			FETCH NEXT FROM compraBonosCursor INTO @compra_fecha, @afiliado_numero, @plan_med_descripcion, @bono_consulta_numero, @bono_farmacia_numero
				WHILE @@FETCH_STATUS = 0
					BEGIN
					SET @monto = 0
					SET @paso = 0
					SET @hayBonoCon = 0
					SET @hayBonoFar = 0
					
					IF(@bono_consulta_numero is not null)
						BEGIN
						SET @hayBonoCon = 1
						EXEC @monto = gd_MORCIPAN.fnObtenerPreciosBonos @plan_med_descripcion, 'CONSULTA'
						END
						
					IF(@bono_farmacia_numero is not null)
						BEGIN
						SET @hayBonoFar = 1
						EXEC @paso = gd_MORCIPAN.fnObtenerPreciosBonos @plan_med_descripcion, 'FARMACIA'
						SET @monto = @monto + @paso
						END						
						
					INSERT INTO gd_MORCIPAN.compras_bonos_afiliados(compra_fecha, afiliado_numero,cantidad_bonos_con, cantidad_bonos_far, monto_total)
					VALUES (@compra_fecha, @afiliado_numero, @hayBonoCon, @hayBonoFar, @monto)
					FETCH NEXT FROM compraBonosCursor INTO @compra_fecha, @afiliado_numero, @plan_med_descripcion, @bono_consulta_numero, @bono_farmacia_numero
					END;
			CLOSE compraBonosCursor;
			DEALLOCATE compraBonosCursor;

END
GO
EXEC gd_MORCIPAN.spMigracionCompraBonosAfiliados;
GO

/*	MIGRACION CONSULTAS MEDICAS	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionConsultasMedicas')
	DROP PROCEDURE gd_MORCIPAN.spMigracionConsultasMedicas;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionConsultasMedicas
AS
BEGIN
	/*IF NOT EXISTS (SELECT turno_numero  FROM gd_MORCIPAN.turnos WHERE (turno_numero)
											IN (SELECT DISTINCT Turno_Numero FROM gd_esquema.Maestra))*/
											
											
		DECLARE @tmp TABLE (
		
		turno_numero NUMERIC (18,0), 
		afiliado_numero INT, 
		bono_consulta_numero NUMERIC (18,0), 
		bono_farmacia_numero NUMERIC (18,0),		
		estado VARCHAR(50), 
		registro_llegada datetime, 
		consulta_sintomas VARCHAR(255), 
		consulta_enfermedades VARCHAR(255)
		)
											
											
		INSERT INTO @tmp 
			(turno_numero, afiliado_numero, bono_consulta_numero, bono_farmacia_numero, estado, registro_llegada, consulta_sintomas, consulta_enfermedades)	
					
		SELECT DISTINCT

		-- turno_numero
		(SELECT MA.Turno_Numero) as turno_numero,
		
		-- afiliado_numero
		(SELECT afiliado_numero FROM gd_MORCIPAN.afiliados WHERE afiliado_nro_documento = MA.Paciente_Dni),
					
		-- bono_consulta_numero
		(SELECT MA.Bono_Consulta_Numero) AS bono_consulta_numero,
					
		-- bono_farmacia_numero
		(SELECT MA.Bono_Farmacia_Numero) AS bono_farmacia_numero,
		
		-- estado
		(SELECT 'FINALIZADA') AS estado,
		
		-- registro_llegada SE PONE LA FECHA DEL TURNO
		(SELECT MA.Turno_Fecha) AS registro_llegada,
		
		-- consulta_sintomas
		(SELECT MA.Consulta_Sintomas) AS consulta_sintomas,
		
		-- consulta_enfermedades
		(SELECT MA.Consulta_Enfermedades) AS consulta_enfermedades
					
		FROM gd_esquema.Maestra MA WHERE MA.Turno_Numero IS NOT NULL
		AND MA.Bono_Consulta_Numero IS NOT NULL -- una consulta va acompañada de un bono consulta siempre
				
														
		INSERT INTO gd_MORCIPAN.consultas_medicas 
			(turno_numero, afiliado_numero, bono_consulta_numero, estado, registro_llegada, consulta_sintomas, consulta_enfermedades)	
					
		SELECT turno_numero, afiliado_numero, bono_consulta_numero, estado, registro_llegada, consulta_sintomas, consulta_enfermedades
		FROM @tmp TMP

		-- cursor recetas, updeteamos consultas
		DECLARE @fecha DATETIME
		DECLARE @receta_id_res INT
		DECLARE @bono_farmacia NUMERIC(18,0)
		
		EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
		
		DECLARE bonoFarmaciaReceta CURSOR FOR
		SELECT turno_numero, bono_consulta_numero, receta_id FROM gd_MORCIPAN.consultas_medicas FOR UPDATE OF receta_id
		DECLARE @turno_numero NUMERIC(18,0), @bono_consulta_numero	NUMERIC(18,0), @receta_id INT	
		
		OPEN bonoFarmaciaReceta;
		FETCH NEXT FROM bonoFarmaciaReceta INTO @turno_numero, @bono_consulta_numero, @receta_id
			WHILE @@FETCH_STATUS = 0
				BEGIN
			
				INSERT INTO gd_MORCIPAN.recetas_medicas (receta_fecha) VALUES (@fecha)
				SELECT @receta_id_res = SCOPE_IDENTITY()
				UPDATE gd_MORCIPAN.consultas_medicas SET receta_id = @receta_id_res WHERE CURRENT OF bonoFarmaciaReceta
					
				FETCH NEXT FROM bonoFarmaciaReceta INTO @turno_numero, @bono_consulta_numero, @receta_id
				END;
		CLOSE bonoFarmaciaReceta;
		DEALLOCATE bonoFarmaciaReceta;
		
		-- recetas que tienen bonos
		INSERT INTO gd_MORCIPAN.bonosFarmacia_recetas (receta_id, bono_farmacia_numero)
		SELECT 
		-- receta_id
		(SELECT receta_id FROM gd_MORCIPAN.consultas_medicas WHERE turno_numero = TMP.turno_numero),
		-- bono_farmacia_numero
		(SELECT TMP.bono_farmacia_numero) as bono_farmacia_numero
		FROM @tmp TMP
		
		-- bonos_consulta se pasan a utilizados
		UPDATE gd_MORCIPAN.bonos_consulta
		SET afiliado_utilizo = afiliado_numero
		WHERE bono_consulta_numero IN (SELECT bono_consulta_numero FROM @tmp) 
		
		-- bonos_farmacia se pasan a utilizados
		UPDATE gd_MORCIPAN.bonos_farmacia
		SET afiliado_utilizo = afiliado_numero
		WHERE bono_farmacia_numero IN (SELECT bono_farmacia_numero FROM @tmp) 

END
GO
EXEC gd_MORCIPAN.spMigracionConsultasMedicas;
GO

/*	MIGRACION AGENDAS PROFESIONALES	*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spMigracionAgendasProfesionales')
	DROP PROCEDURE gd_MORCIPAN.spMigracionAgendasProfesionales;
GO
CREATE PROCEDURE gd_MORCIPAN.spMigracionAgendasProfesionales
AS
BEGIN
											
		DECLARE @tmp TABLE (
		
		prof_id INT, 
		comienzo_agen DATETIME, 
		fin_agen DATETIME
		)
											
											
		INSERT INTO @tmp 
			(prof_id, comienzo_agen, fin_agen)	
					
		SELECT prof_id, MIN(turno_fecha), MAX(turno_fecha) from gd_MORCIPAN.turnos
		group by prof_id

		DECLARE @agenda_id		INT
		DECLARE @agen_lun		BIT
		DECLARE @agen_mar		BIT
		DECLARE @agen_mie		BIT
		DECLARE @agen_jue		BIT
		DECLARE @agen_vie		BIT
		DECLARE @agen_sab		BIT
		DECLARE @agen_lun_ini	TIME
		DECLARE @agen_lun_fin	TIME
		DECLARE @agen_mar_ini	TIME
		DECLARE @agen_mar_fin	TIME
		DECLARE @agen_mie_ini	TIME
		DECLARE @agen_mie_fin	TIME
		DECLARE @agen_jue_ini	TIME
		DECLARE @agen_jue_fin	TIME
		DECLARE @agen_vie_ini	TIME
		DECLARE @agen_vie_fin	TIME
		DECLARE @agen_sab_ini	TIME
		DECLARE @agen_sab_fin	TIME										
		DECLARE @dia_cuenta		INT
		DECLARE @fecha_aux_ini	DATETIME
		DECLARE @fecha_aux_max	DATETIME
		DECLARE @fecha_corrida	DATETIME
		DECLARE @hora_aux		INT
		DECLARE @min_aux		INT
		DECLARE @hora_final_aux	TIME
		DECLARE @nom_dia		NVARCHAR(50)
		
		DECLARE agendaCursor CURSOR FOR
			SELECT prof_id, comienzo_agen, fin_agen FROM @tmp
			DECLARE @prof_id INT, @comienzo_agen DATETIME, @fin_agen DATETIME	
			
			OPEN agendaCursor;
			FETCH NEXT FROM agendaCursor INTO @prof_id, @comienzo_agen, @fin_agen
				WHILE @@FETCH_STATUS = 0
					BEGIN
					
					SET @fecha_corrida = @comienzo_agen
					SET @dia_cuenta = 1
					SET @agen_lun = 0
					SET @agen_mar = 0
					SET @agen_mie = 0
					SET @agen_jue = 0
					SET @agen_vie = 0
					SET @agen_sab = 0
					SET @agen_lun_ini = NULL
					SET @agen_lun_fin = NULL
					SET @agen_mar_ini = NULL
					SET @agen_mar_fin = NULL
					SET @agen_mie_ini = NULL
					SET @agen_mie_fin = NULL
					SET @agen_jue_ini = NULL
					SET @agen_jue_fin = NULL
					SET @agen_vie_ini = NULL
					SET @agen_vie_fin = NULL
					SET @agen_sab_ini = NULL
					SET @agen_sab_fin = NULL				
																																									
					SELECT @nom_dia = DATENAME(weekday, @fecha_corrida)
					
					WHILE(@dia_cuenta <= 7) -- una semana
						BEGIN 	
					
						if(@nom_dia = 'Monday' or @nom_dia = 'Lunes')		-- LUNES
							BEGIN
							
							SET @fecha_aux_ini = NULL
							SET @fecha_aux_max = NULL	
							SELECT @fecha_aux_ini = MIN(turno_fecha), @fecha_aux_max = MAX(turno_fecha) 
							FROM gd_MORCIPAN.turnos
							WHERE prof_id = @prof_id AND
							DATEDIFF(DAY, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(MONTH, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(YEAR, @fecha_corrida, turno_fecha) = 0
							group by prof_id
							
							IF(@fecha_aux_ini IS NOT NULL AND @fecha_aux_max IS NOT NULL)
								BEGIN
								SET @agen_lun = 1

								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_ini)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_ini)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @agen_lun_ini = @hora_final_aux
								
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_max)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_max)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE, 30, @hora_final_aux) -- sumamos 30 de la ultima consulta
								SET @agen_lun_fin = @hora_final_aux
								END
							END
					
						if(@nom_dia = 'Tuesday' or @nom_dia = 'Martes')	-- MARTES
							BEGIN

							SET @fecha_aux_ini = NULL
							SET @fecha_aux_max = NULL							
							SELECT @fecha_aux_ini = MIN(turno_fecha), @fecha_aux_max = MAX(turno_fecha) 
							FROM gd_MORCIPAN.turnos
							WHERE prof_id = @prof_id AND
							DATEDIFF(DAY, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(MONTH, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(YEAR, @fecha_corrida, turno_fecha) = 0
							group by prof_id
							
							IF(@fecha_aux_ini IS NOT NULL AND @fecha_aux_max IS NOT NULL)
								BEGIN
								SET @agen_mar = 1

								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_ini)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_ini)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @agen_mar_ini = @hora_final_aux
								
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_max)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_max)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE, 30, @hora_final_aux) -- sumamos 30 de la ultima consulta
								SET @agen_mar_fin = @hora_final_aux	
								END						
							END					
					
						if(@nom_dia = 'Wednesday' or @nom_dia = 'Miércoles')	-- MIERCOLES
							BEGIN

							SET @fecha_aux_ini = NULL
							SET @fecha_aux_max = NULL
							SELECT @fecha_aux_ini = MIN(turno_fecha), @fecha_aux_max = MAX(turno_fecha) 
							FROM gd_MORCIPAN.turnos
							WHERE prof_id = @prof_id AND
							DATEDIFF(DAY, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(MONTH, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(YEAR, @fecha_corrida, turno_fecha) = 0
							group by prof_id

							IF(@fecha_aux_ini IS NOT NULL AND @fecha_aux_max IS NOT NULL)
								BEGIN
								SET @agen_mie = 1
							
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_ini)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_ini)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @agen_mie_ini = @hora_final_aux
								
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_max)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_max)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE, 30, @hora_final_aux) -- sumamos 30 de la ultima consulta
								SET @agen_mie_fin = @hora_final_aux							
								END
							END					

						if(@nom_dia = 'Thursday' or @nom_dia = 'Jueves')	-- JUEVES
							BEGIN
							
							SET @fecha_aux_ini = NULL
							SET @fecha_aux_max = NULL
							SELECT @fecha_aux_ini = MIN(turno_fecha), @fecha_aux_max = MAX(turno_fecha) 
							FROM gd_MORCIPAN.turnos
							WHERE prof_id = @prof_id AND
							DATEDIFF(DAY, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(MONTH, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(YEAR, @fecha_corrida, turno_fecha) = 0
							group by prof_id
							
							IF(@fecha_aux_ini IS NOT NULL AND @fecha_aux_max IS NOT NULL)
								BEGIN
								SET @agen_jue = 1
							
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_ini)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_ini)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @agen_jue_ini = @hora_final_aux
								
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_max)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_max)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE, 30, @hora_final_aux) -- sumamos 30 de la ultima consulta
								SET @agen_jue_fin = @hora_final_aux							
								END
							END					

						if(@nom_dia = 'Friday' or @nom_dia = 'Viernes')		-- VIERNES
							BEGIN
							
							SET @fecha_aux_ini = NULL
							SET @fecha_aux_max = NULL							
							SELECT @fecha_aux_ini = MIN(turno_fecha), @fecha_aux_max = MAX(turno_fecha) 
							FROM gd_MORCIPAN.turnos
							WHERE prof_id = @prof_id AND
							DATEDIFF(DAY, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(MONTH, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(YEAR, @fecha_corrida, turno_fecha) = 0
							group by prof_id
							
							IF(@fecha_aux_ini IS NOT NULL AND @fecha_aux_max IS NOT NULL)
								BEGIN
								SET @agen_vie = 1
															
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_ini)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_ini)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @agen_vie_ini = @hora_final_aux
								
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_max)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_max)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE, 30, @hora_final_aux) -- sumamos 30 de la ultima consulta
								SET @agen_vie_fin = @hora_final_aux							
								END
							END					

						if(@nom_dia = 'Saturday' or @nom_dia = 'Sábado')	-- SABADO
							BEGIN

							SET @fecha_aux_ini = NULL
							SET @fecha_aux_max = NULL					
							SELECT @fecha_aux_ini = MIN(turno_fecha), @fecha_aux_max = MAX(turno_fecha) 
							FROM gd_MORCIPAN.turnos
							WHERE prof_id = @prof_id AND
							DATEDIFF(DAY, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(MONTH, @fecha_corrida, turno_fecha) = 0 AND
							DATEDIFF(YEAR, @fecha_corrida, turno_fecha) = 0
							group by prof_id

							IF(@fecha_aux_ini IS NOT NULL AND @fecha_aux_max IS NOT NULL)
								BEGIN
								SET @agen_sab = 1							
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_ini)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_ini)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @agen_sab_ini = @hora_final_aux
								
								SET @hora_final_aux = '00:00:00.000'
								SET @hora_aux = DATEPART(HOUR, @fecha_aux_max)
								SET @min_aux = DATEPART(MINUTE, @fecha_aux_max)
								SET @hora_final_aux = DATEADD(HOUR,@hora_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE,@min_aux,@hora_final_aux)
								SET @hora_final_aux = DATEADD(MINUTE, 30, @hora_final_aux) -- sumamos 30 de la ultima consulta
								SET @agen_sab_fin = @hora_final_aux	
								END												
							END					

						--	sumamos un dia mas
						SELECT @fecha_corrida = DATEADD(day,1,@fecha_corrida)
						--	nombre del nuevo dia
						SELECT @nom_dia = DATENAME(weekday, @fecha_corrida)
						SET @dia_cuenta = @dia_cuenta + 1
						END

					INSERT INTO gd_MORCIPAN.agendas_profesionales
					(agen_fecha_ini, agen_fecha_fin, prof_id)
					VALUES
					(@comienzo_agen, @fin_agen, @prof_id)

					-- insertamos agenda
					/*INSERT INTO gd_MORCIPAN.agendas_profesionales(agen_fecha_ini, agen_fecha_fin, prof_id,
					agen_lun, agen_mar, agen_mie, agen_jue, agen_vie, agen_sab,
					agen_lun_ini, agen_lun_fin, agen_mar_ini, agen_mar_fin, agen_mie_ini, agen_mie_fin,
					agen_jue_ini, agen_jue_fin, agen_vie_ini, agen_vie_fin, agen_sab_ini, agen_sab_fin)
					VALUES(@comienzo_agen, @fin_agen, @prof_id, 
					@agen_lun, @agen_mar, @agen_mie, @agen_jue, @agen_vie, @agen_sab,
					@agen_lun_ini, @agen_lun_fin, @agen_mar_ini, @agen_mar_fin, @agen_mie_ini, @agen_mie_fin,
					@agen_jue_ini, @agen_jue_fin, @agen_vie_ini, @agen_vie_fin, @agen_sab_ini, @agen_sab_fin)*/
					
					-- updeteamos todos los turnos
					/*SELECT @agenda_id = SCOPE_IDENTITY()
					UPDATE gd_MORCIPAN.turnos
					SET agenda_id = @agenda_id
					WHERE prof_id = @prof_id*/
		
					FETCH NEXT FROM agendaCursor INTO @prof_id, @comienzo_agen, @fin_agen
					END;
			CLOSE agendaCursor;
			DEALLOCATE agendaCursor;

END
GO
EXEC gd_MORCIPAN.spMigracionAgendasProfesionales;
GO


-- DESPUES DE TODAS LAS MIGRACIONES
-- afiliado_numero 101, primer afiliado DNI 54181898, usuario_id 5, perfil admin
INSERT INTO gd_MORCIPAN.roles_usuarios (rol_id, usuario_id) VALUES (1, 5)
-- prof_id 1, primer profesional DNI 94007233, usuario_id 7432, perfil admin
INSERT INTO gd_MORCIPAN.roles_usuarios (rol_id, usuario_id) VALUES (1, 7432)
GO

/* ******************************************************************************************************************** */
/* ****************************************** STORED PROCEDURE ******************************************************** */

/*	PROCEDURE: spBuscarAfiliado 
	DESCRIPCION: Obtiene el/los afiliados que macheen con la busqueda
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spBuscarAfiliado')
	DROP PROCEDURE gd_MORCIPAN.spBuscarAfiliado
GO
CREATE PROCEDURE gd_MORCIPAN.spBuscarAfiliado

	@afiliado_numero					INT,
	@afiliado_nombre					VARCHAR(255),
	@afiliado_apellido					VARCHAR(255),
	@afiliado_tipo_documento			VARCHAR (10),
	@afiliado_nro_documento				NUMERIC(18,0),
	@afiliado_direccion					VARCHAR(255),
	@afiliado_telefono					NUMERIC(18,0), 
	@afiliado_email						VARCHAR(255),
	@afiliado_fecha_nacimiento			DATETIME,
	@afiliado_sexo						VARCHAR(50),
	@afiliado_estado_civil				VARCHAR(255),
	@afiliado_cant_familiares_cargo		INT,
	@afiliado_plan_medico_codigo		VARCHAR(255)

AS
BEGIN

	-- BUSQUEDA SIN FILTROS
	IF 	@afiliado_numero = -2 AND @afiliado_nombre = '- 2' AND	@afiliado_apellido = '- 2' AND @afiliado_tipo_documento = '- 2' AND
		@afiliado_nro_documento = -2 AND @afiliado_direccion = '- 2' AND @afiliado_telefono = -2 AND @afiliado_fecha_nacimiento = '1900-01-01 00:00:00.000' AND
		@afiliado_sexo = '- 2' AND @afiliado_estado_civil = '- 2' AND @afiliado_cant_familiares_cargo = -2 AND @afiliado_plan_medico_codigo = '- 2'
		BEGIN
		SELECT AFI.afiliado_numero, AFI.afiliado_nombre, AFI.afiliado_apellido, AFI.afiliado_tipo_documento, AFI.afiliado_nro_documento,
		AFI.afiliado_direccion, AFI.afiliado_telefono, AFI.afiliado_email, AFI.afiliado_fecha_nacimiento, AFI.afiliado_sexo, AFI.afiliado_estado_civil, AFI.afiliado_cant_familiares_cargo,
		PL.plan_descripcion
		FROM gd_MORCIPAN.afiliados AFI
		JOIN gd_MORCIPAN.planes PL ON PL.plan_codigo = AFI.afiliado_plan_medico_codigo
		WHERE AFI.habilitado = 1 AND PL.habilitado = 1
		END

	ELSE
		BEGIN	
		
		IF @afiliado_nombre = '- 2'
			SET @afiliado_nombre = '%%'
		ELSE	
			SELECT @afiliado_nombre = '%' + RTRIM(@afiliado_nombre) + '%';
		
		IF @afiliado_apellido = '- 2'
			SET @afiliado_apellido = '%%'
		ELSE	
			SELECT @afiliado_apellido = '%' + RTRIM(@afiliado_apellido) + '%';
		
		IF @afiliado_direccion = '- 2'
			SET @afiliado_direccion = '%%'
		ELSE	
			SELECT @afiliado_direccion = '%' + RTRIM(@afiliado_direccion) + '%';

		IF @afiliado_email = '- 2'
			SET @afiliado_email = '%%'
		ELSE	
			SELECT @afiliado_email = '%' + RTRIM(@afiliado_email) + '%';

		DECLARE @tmp_busqueda TABLE (
			afiliado_numero					INT,
			afiliado_nombre					VARCHAR(255),
			afiliado_apellido				VARCHAR(255),
			afiliado_tipo_documento			VARCHAR (10),
			afiliado_nro_documento			NUMERIC(18,0),
			afiliado_direccion				VARCHAR(255),
			afiliado_telefono				NUMERIC(18,0), 
			afiliado_email					VARCHAR(255),
			afiliado_fecha_nacimiento		DATETIME,
			afiliado_sexo					VARCHAR(50),
			afiliado_estado_civil			VARCHAR(255),
			afiliado_cant_familiares_cargo	INT,
			afiliado_plan_medico_codigo		VARCHAR(255)
		);
		
		INSERT INTO @tmp_busqueda 
		SELECT
		AFI.afiliado_numero as afiliado_numero, 
		AFI.afiliado_nombre as afiliado_nombre,
		AFI.afiliado_apellido as afiliado_apellido, 
		AFI.afiliado_tipo_documento as afiliado_tipo_documento,
		AFI.afiliado_nro_documento as afiliado_nro_documento,
		AFI.afiliado_direccion as afiliado_direccion, 
		AFI.afiliado_telefono as afiliado_telefono, 
		AFI.afiliado_email as afiliado_email,
		AFI.afiliado_fecha_nacimiento as afiliado_fecha_nacimiento,
		AFI.afiliado_sexo as afiliado_sexo, 
		AFI.afiliado_estado_civil as afiliado_estado_civil, 
		AFI.afiliado_cant_familiares_cargo as afiliado_cant_familiares_cargo,
		(SELECT plan_descripcion FROM gd_MORCIPAN.planes WHERE AFI.afiliado_plan_medico_codigo = plan_codigo) as afiliado_plan_medico_codigo 
		FROM gd_MORCIPAN.afiliados AFI
		WHERE
		AFI.habilitado = 1 
		-- todos los like primero
		AND AFI.afiliado_nombre LIKE @afiliado_nombre
		AND AFI.afiliado_apellido LIKE @afiliado_apellido
		AND AFI.afiliado_direccion LIKE @afiliado_direccion
		AND AFI.afiliado_email LIKE @afiliado_email

		--	afiliado_numero
		IF @afiliado_numero != -2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_numero NOT LIKE @afiliado_numero;
			END

		--	afiliado_tipo_documento
		IF @afiliado_tipo_documento != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_tipo_documento != @afiliado_tipo_documento;
			END

		--	afiliado_nro_documento
		IF @afiliado_nro_documento != - 2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_nro_documento != @afiliado_nro_documento;
			END

		--	afiliado_telefono			
		IF @afiliado_telefono != - 2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_telefono != @afiliado_telefono;
			END

		-- afiliado_fecha_nacimiento
		IF @afiliado_fecha_nacimiento != '1900-01-01 00:00:00.000'
			BEGIN
			DELETE FROM @tmp_busqueda
			WHERE 
			DATEDIFF (DAY, afiliado_fecha_nacimiento, @afiliado_fecha_nacimiento) != 0 OR 
			DATEDIFF (MONTH, afiliado_fecha_nacimiento, @afiliado_fecha_nacimiento) != 0  OR
			DATEDIFF (YEAR, afiliado_fecha_nacimiento, @afiliado_fecha_nacimiento) != 0
			END
		
		--	afiliado_sexo
		IF @afiliado_sexo != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_sexo != @afiliado_sexo;
			END
			
		--	afiliado_estado_civil
		IF @afiliado_estado_civil != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_estado_civil != @afiliado_estado_civil;
			END

		--	afiliado_cant_familiares_cargo
		IF @afiliado_cant_familiares_cargo != -2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_cant_familiares_cargo != @afiliado_cant_familiares_cargo;
			END
	
		--	afiliado_plan_medico_codigo
		IF @afiliado_plan_medico_codigo != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_plan_medico_codigo != @afiliado_plan_medico_codigo;
			END
			
		--	resultado
		SELECT *
		FROM @tmp_busqueda

	END
END;
GO

/*	PROCEDURE: spBuscarAfiliadoNoHabilitado 
	DESCRIPCION: Obtiene el/los afiliados que macheen con la busqueda
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spBuscarAfiliadoNoHabilitado')
	DROP PROCEDURE gd_MORCIPAN.spBuscarAfiliadoNoHabilitado
GO
CREATE PROCEDURE gd_MORCIPAN.spBuscarAfiliadoNoHabilitado

	@afiliado_numero					INT,
	@afiliado_nombre					VARCHAR(255),
	@afiliado_apellido					VARCHAR(255),
	@afiliado_tipo_documento			VARCHAR (10),
	@afiliado_nro_documento				NUMERIC(18,0),
	@afiliado_direccion					VARCHAR(255),
	@afiliado_telefono					NUMERIC(18,0), 
	@afiliado_email						VARCHAR(255),
	@afiliado_fecha_nacimiento			DATETIME,
	@afiliado_sexo						VARCHAR(50),
	@afiliado_estado_civil				VARCHAR(255),
	@afiliado_cant_familiares_cargo		INT,
	@afiliado_plan_medico_codigo		VARCHAR(255)

AS
BEGIN

	-- BUSQUEDA SIN FILTROS
	IF 	@afiliado_numero = -2 AND @afiliado_nombre = '- 2' AND	@afiliado_apellido = '- 2' AND @afiliado_tipo_documento = '- 2' AND
		@afiliado_nro_documento = -2 AND @afiliado_direccion = '- 2' AND @afiliado_telefono = -2 AND @afiliado_fecha_nacimiento = '1900-01-01 00:00:00.000' AND
		@afiliado_sexo = '- 2' AND @afiliado_estado_civil = '- 2' AND @afiliado_cant_familiares_cargo = -2 AND @afiliado_plan_medico_codigo = '- 2'
		BEGIN
		SELECT AFI.afiliado_numero, AFI.afiliado_nombre, AFI.afiliado_apellido, AFI.afiliado_tipo_documento, AFI.afiliado_nro_documento,
		AFI.afiliado_direccion, AFI.afiliado_telefono, AFI.afiliado_email, AFI.afiliado_fecha_nacimiento, AFI.afiliado_sexo, AFI.afiliado_estado_civil, AFI.afiliado_cant_familiares_cargo,
		PL.plan_descripcion
		FROM gd_MORCIPAN.afiliados AFI
		JOIN gd_MORCIPAN.planes PL ON PL.plan_codigo = AFI.afiliado_plan_medico_codigo
		WHERE AFI.habilitado = 0 AND PL.habilitado = 1
		END

	ELSE
		BEGIN	
		
		IF @afiliado_nombre = '- 2'
			SET @afiliado_nombre = '%%'
		ELSE	
			SELECT @afiliado_nombre = '%' + RTRIM(@afiliado_nombre) + '%';
		
		IF @afiliado_apellido = '- 2'
			SET @afiliado_apellido = '%%'
		ELSE	
			SELECT @afiliado_apellido = '%' + RTRIM(@afiliado_apellido) + '%';
		
		IF @afiliado_direccion = '- 2'
			SET @afiliado_direccion = '%%'
		ELSE	
			SELECT @afiliado_direccion = '%' + RTRIM(@afiliado_direccion) + '%';

		IF @afiliado_email = '- 2'
			SET @afiliado_email = '%%'
		ELSE	
			SELECT @afiliado_email = '%' + RTRIM(@afiliado_email) + '%';

		DECLARE @tmp_busqueda TABLE (
			afiliado_numero					INT,
			afiliado_nombre					VARCHAR(255),
			afiliado_apellido				VARCHAR(255),
			afiliado_tipo_documento			VARCHAR (10),
			afiliado_nro_documento			NUMERIC(18,0),
			afiliado_direccion				VARCHAR(255),
			afiliado_telefono				NUMERIC(18,0), 
			afiliado_email					VARCHAR(255),
			afiliado_fecha_nacimiento		DATETIME,
			afiliado_sexo					VARCHAR(50),
			afiliado_estado_civil			VARCHAR(255),
			afiliado_cant_familiares_cargo	INT,
			afiliado_plan_medico_codigo		VARCHAR(255)
		);
		
		INSERT INTO @tmp_busqueda 
		SELECT
		AFI.afiliado_numero as afiliado_numero, 
		AFI.afiliado_nombre as afiliado_nombre,
		AFI.afiliado_apellido as afiliado_apellido, 
		AFI.afiliado_tipo_documento as afiliado_tipo_documento,
		AFI.afiliado_nro_documento as afiliado_nro_documento,
		AFI.afiliado_direccion as afiliado_direccion, 
		AFI.afiliado_telefono as afiliado_telefono, 
		AFI.afiliado_email as afiliado_email,
		AFI.afiliado_fecha_nacimiento as afiliado_fecha_nacimiento,
		AFI.afiliado_sexo as afiliado_sexo, 
		AFI.afiliado_estado_civil as afiliado_estado_civil, 
		AFI.afiliado_cant_familiares_cargo as afiliado_cant_familiares_cargo,
		(SELECT plan_descripcion FROM gd_MORCIPAN.planes WHERE AFI.afiliado_plan_medico_codigo = plan_codigo) as afiliado_plan_medico_codigo 
		FROM gd_MORCIPAN.afiliados AFI
		WHERE
		AFI.habilitado = 0 
		-- todos los like primero
		AND AFI.afiliado_nombre LIKE @afiliado_nombre
		AND AFI.afiliado_apellido LIKE @afiliado_apellido
		AND AFI.afiliado_direccion LIKE @afiliado_direccion
		AND AFI.afiliado_email LIKE @afiliado_email

		--	afiliado_numero
		IF @afiliado_numero != -2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_numero NOT LIKE @afiliado_numero;
			END

		--	afiliado_tipo_documento
		IF @afiliado_tipo_documento != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_tipo_documento != @afiliado_tipo_documento;
			END

		--	afiliado_nro_documento
		IF @afiliado_nro_documento != - 2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_nro_documento != @afiliado_nro_documento;
			END

		--	afiliado_telefono			
		IF @afiliado_telefono != - 2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_telefono != @afiliado_telefono;
			END

		-- afiliado_fecha_nacimiento
		IF @afiliado_fecha_nacimiento != '1900-01-01 00:00:00.000'
			BEGIN
			DELETE FROM @tmp_busqueda
			WHERE 
			DATEDIFF (DAY, afiliado_fecha_nacimiento, @afiliado_fecha_nacimiento) != 0 OR 
			DATEDIFF (MONTH, afiliado_fecha_nacimiento, @afiliado_fecha_nacimiento) != 0  OR
			DATEDIFF (YEAR, afiliado_fecha_nacimiento, @afiliado_fecha_nacimiento) != 0
			END
		
		--	afiliado_sexo
		IF @afiliado_sexo != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_sexo != @afiliado_sexo;
			END
			
		--	afiliado_estado_civil
		IF @afiliado_estado_civil != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_estado_civil != @afiliado_estado_civil;
			END

		--	afiliado_cant_familiares_cargo
		IF @afiliado_cant_familiares_cargo != -2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_cant_familiares_cargo != @afiliado_cant_familiares_cargo;
			END
	
		--	afiliado_plan_medico_codigo
		IF @afiliado_plan_medico_codigo != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE afiliado_plan_medico_codigo != @afiliado_plan_medico_codigo;
			END
			
		--	resultado
		SELECT *
		FROM @tmp_busqueda

	END
END;
GO

/*	PROCEDURE: spAltaLogicaAfiliadoPorId 
	DESCRIPCION: Da de alta logica a un afiliado dado de baja. Limpio, sin bonos
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spAltaLogicaAfiliadoPorId')
	DROP PROCEDURE gd_MORCIPAN.spAltaLogicaAfiliadoPorId
GO
CREATE PROCEDURE gd_MORCIPAN.spAltaLogicaAfiliadoPorId
	@afiliado_numero		INT
AS	

	ALTER TABLE gd_MORCIPAN.afiliados DISABLE TRIGGER trBajaLogicaAfiliado

	UPDATE gd_MORCIPAN.afiliados
	SET habilitado = 1
	WHERE afiliado_numero = @afiliado_numero 
	
	ALTER TABLE gd_MORCIPAN.afiliados ENABLE TRIGGER trBajaLogicaAfiliado
GO

/*	PROCEDURE: spModificarAfiliado 
	DESCRIPCION: Modifica todos los parametros de un afiliado dado su numero de afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spModificarAfiliado')
	DROP PROCEDURE gd_MORCIPAN.spModificarAfiliado
GO
CREATE PROCEDURE gd_MORCIPAN.spModificarAfiliado

	@afiliado_numero					INT,
	@afiliado_nombre					VARCHAR(255),
	@afiliado_apellido					VARCHAR(255),
	@afiliado_tipo_documento			VARCHAR (10),
	@afiliado_nro_documento				NUMERIC(18,0),
	@afiliado_direccion					VARCHAR(255),
	@afiliado_telefono					NUMERIC(18,0), 
	@afiliado_email						VARCHAR(255),
	@afiliado_fecha_nacimiento			DATETIME,
	@afiliado_sexo						VARCHAR(50),
	@afiliado_estado_civil				VARCHAR(255),
	@afiliado_cant_familiares_cargo		INT,
	@afiliado_plan_medico_codigo		VARCHAR(255)

AS
BEGIN

	DECLARE @plan_medico INT
	SELECT @plan_medico = plan_codigo FROM gd_MORCIPAN.planes WHERE @afiliado_plan_medico_codigo = plan_descripcion

	UPDATE gd_MORCIPAN.afiliados
	SET 
	afiliado_nombre = @afiliado_nombre,
	afiliado_apellido = @afiliado_apellido,
	afiliado_tipo_documento = @afiliado_tipo_documento,
	afiliado_nro_documento = @afiliado_nro_documento,	
	afiliado_direccion = @afiliado_direccion,
	afiliado_telefono = @afiliado_telefono,
	afiliado_email = @afiliado_email,
	afiliado_fecha_nacimiento = @afiliado_fecha_nacimiento,
	afiliado_sexo = @afiliado_sexo,
	afiliado_estado_civil = @afiliado_estado_civil,
	afiliado_cant_familiares_cargo = @afiliado_cant_familiares_cargo,
	afiliado_plan_medico_codigo = @plan_medico
	WHERE afiliado_numero = @afiliado_numero

END;
GO

/*	PROCEDURE: spEliminarAfiliadoPorId 
	DESCRIPCION: Da de baja lógica un Afiliado.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spEliminarAfiliadoPorId')
	DROP PROCEDURE gd_MORCIPAN.spEliminarAfiliadoPorId
GO
CREATE PROCEDURE gd_MORCIPAN.spEliminarAfiliadoPorId
	@afiliado_numero		INT
AS	
	DECLARE @fecha DATETIME
	EXEC @fecha = GD2C2013.gd_MORCIPAN.fnDevolverFechaSistema

	-- trigger mata turnos 
	UPDATE gd_MORCIPAN.afiliados
	SET habilitado = 0, fecha_baja_logica = @fecha
	WHERE afiliado_numero = @afiliado_numero 
	
	-- es el raiz, hay que dar de baja todos los hijos
	IF(gd_MORCIPAN.fnAfiliadoRaiz(@afiliado_numero)=1)
		BEGIN
		
		-- se dan de baja todos menos el raiz
		UPDATE gd_MORCIPAN.afiliados
		SET habilitado = 0, fecha_baja_logica = @fecha
		WHERE afiliado_numero IN ( SELECT * FROM gd_MORCIPAN.fnObtenerTodosIntegrantesGrupoFamiliarMenosRaiz (@afiliado_numero))
		AND afiliado_numero != @afiliado_numero
		
		-- DESHABILITAMOS LOS BONOS CONSULTA DE TODOS
		UPDATE gd_MORCIPAN.bonos_consulta
		SET habilitado = 0
		WHERE afiliado_numero = @afiliado_numero OR
		afiliado_numero IN ( SELECT * FROM gd_MORCIPAN.fnObtenerTodosIntegrantesGrupoFamiliarMenosRaiz (@afiliado_numero))
		
		-- DESHABILITAMOS LOS BONOS FARMACIA DE TODOS
		UPDATE gd_MORCIPAN.bonos_farmacia
		SET habilitado = 0
		WHERE afiliado_numero = @afiliado_numero OR
		afiliado_numero IN ( SELECT * FROM gd_MORCIPAN.fnObtenerTodosIntegrantesGrupoFamiliarMenosRaiz (@afiliado_numero))
		
		END	
GO

/*	PROCEDURE: spBuscarProfesional 
	DESCRIPCION: Obtiene el/los profesionales que macheen con la busqueda
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spBuscarProfesional')
	DROP PROCEDURE gd_MORCIPAN.spBuscarProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spBuscarProfesional

	@prof_id				INT,
	@prof_nombre			VARCHAR(255),
	@prof_apellido			NVARCHAR(255),
	@prof_tipo_doc			VARCHAR(10),
	@prof_num_dni			NUMERIC(18,0),
	@prof_direccion			VARCHAR(255),
	@prof_telefono			NUMERIC(18,0),
	@prof_mail				VARCHAR(255),
	@prof_fechaNac			DATETIME,
	@prof_sex				NVARCHAR(100),
	@prof_matr				NVARCHAR(100)

AS
BEGIN

	-- BUSQUEDA SIN FILTROS
	IF 	@prof_id = -2 AND @prof_nombre = '- 2' AND	@prof_apellido = '- 2' AND @prof_tipo_doc = '- 2' AND
		@prof_num_dni = -2 AND @prof_direccion = '- 2' AND @prof_telefono = -2 AND @prof_mail = '- 2' AND 
		@prof_fechaNac = '1900-01-01 00:00:00.000' AND @prof_sex = '- 2' AND @prof_matr = '- 2'
		BEGIN
		SELECT * FROM gd_MORCIPAN.profesionales
		WHERE habilitado = 1
		END

	ELSE
		BEGIN	
		
		IF @prof_nombre = '- 2'
			SET @prof_nombre = '%%'
		ELSE	
			SELECT @prof_nombre = '%' + RTRIM(@prof_nombre) + '%';
		
		IF @prof_apellido = '- 2'
			SET @prof_apellido = '%%'
		ELSE	
			SELECT @prof_apellido = '%' + RTRIM(@prof_apellido) + '%';
		
		IF @prof_direccion = '- 2'
			SET @prof_direccion = '%%'
		ELSE	
			SELECT @prof_direccion = '%' + RTRIM(@prof_direccion) + '%';

		IF @prof_mail = '- 2'
			SET @prof_mail = '%%'
		ELSE	
			SELECT @prof_mail = '%' + RTRIM(@prof_mail) + '%';

		DECLARE @tmp_busqueda TABLE (
			prof_id				INT,
			prof_nombre			VARCHAR(255),
			prof_apellido		NVARCHAR(255),
			prof_tipo_doc		VARCHAR(10),
			prof_num_dni		NUMERIC(18,0),
			prof_direccion		VARCHAR(255),
			prof_telefono		NUMERIC(18,0),
			prof_mail			VARCHAR(255),
			prof_fechaNac		DATETIME,
			prof_sex			NVARCHAR(100),
			prof_matr			NVARCHAR(100)
		);
		
		INSERT INTO @tmp_busqueda 
		SELECT prof_id, prof_nombre, prof_apellido, prof_tipo_doc, prof_num_dni, prof_direccion,
		prof_telefono, prof_mail, prof_fechaNac, prof_sex, prof_matr
		FROM gd_MORCIPAN.profesionales
		WHERE
		habilitado = 1 
		-- todos los like primero
		AND prof_nombre LIKE @prof_nombre
		AND prof_apellido LIKE @prof_apellido
		AND prof_direccion LIKE @prof_direccion
		AND prof_mail LIKE @prof_mail

		--	prof_id
		IF @prof_id != -2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_id NOT LIKE @prof_id;
			END

		--	prof_tipo_doc
		IF @prof_tipo_doc != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_tipo_doc != @prof_tipo_doc;
			END

		--	prof_num_dni
		IF @prof_num_dni != - 2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_num_dni != @prof_num_dni;
			END

		--	prof_telefono			
		IF @prof_telefono != - 2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_telefono != @prof_telefono;
			END

		-- prof_fechaNac
		IF @prof_fechaNac != '1900-01-01 00:00:00.000'
			BEGIN
			DELETE FROM @tmp_busqueda
			WHERE 
			DATEDIFF (DAY, prof_fechaNac, @prof_fechaNac) != 0 OR 
			DATEDIFF (MONTH, prof_fechaNac, @prof_fechaNac) != 0  OR
			DATEDIFF (YEAR, prof_fechaNac, @prof_fechaNac) != 0
			END
		
		--	prof_sex
		IF @prof_sex != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_sex != @prof_sex;
			END
			
		--	prof_matr
		IF @prof_matr != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_matr != @prof_matr;
			END
					
		--	resultado
		SELECT *
		FROM @tmp_busqueda

	END
END;
GO

/*	PROCEDURE: spBuscarProfesionalFull 
	DESCRIPCION: Obtiene el/los profesionales que macheen con la busqueda
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spBuscarProfesionalFull')
	DROP PROCEDURE gd_MORCIPAN.spBuscarProfesionalFull
GO
CREATE PROCEDURE gd_MORCIPAN.spBuscarProfesionalFull

	@prof_id				INT,
	@prof_nombre			VARCHAR(255),
	@prof_apellido			NVARCHAR(255),
	@prof_tipo_doc			VARCHAR(10),
	@prof_num_dni			NUMERIC(18,0),
	@prof_direccion			VARCHAR(255),
	@prof_telefono			NUMERIC(18,0),
	@prof_mail				VARCHAR(255),
	@prof_fechaNac			DATETIME,
	@prof_sex				NVARCHAR(100),
	@prof_matr				NVARCHAR(100),
	@prof_esp_descr			NVARCHAR(100)

AS
BEGIN

	-- BUSQUEDA SIN FILTROS
	IF 	@prof_id = -2 AND @prof_nombre = '- 2' AND	@prof_apellido = '- 2' AND @prof_tipo_doc = '- 2' AND
		@prof_num_dni = -2 AND @prof_direccion = '- 2' AND @prof_telefono = -2 AND @prof_mail = '- 2' AND 
		@prof_fechaNac = '1900-01-01 00:00:00.000' AND @prof_sex = '- 2' AND @prof_matr = '- 2' AND @prof_esp_descr = '- 2'
		BEGIN
		SELECT * FROM gd_MORCIPAN.profesionales
		WHERE habilitado = 1
		END

	ELSE
		BEGIN	
		
		IF @prof_nombre = '- 2'
			SET @prof_nombre = '%%'
		ELSE	
			SELECT @prof_nombre = '%' + RTRIM(@prof_nombre) + '%';
		
		IF @prof_apellido = '- 2'
			SET @prof_apellido = '%%'
		ELSE	
			SELECT @prof_apellido = '%' + RTRIM(@prof_apellido) + '%';
		
		IF @prof_direccion = '- 2'
			SET @prof_direccion = '%%'
		ELSE	
			SELECT @prof_direccion = '%' + RTRIM(@prof_direccion) + '%';

		IF @prof_mail = '- 2'
			SET @prof_mail = '%%'
		ELSE	
			SELECT @prof_mail = '%' + RTRIM(@prof_mail) + '%';

		DECLARE @tmp_busqueda TABLE (
			prof_id				INT,
			prof_nombre			VARCHAR(255),
			prof_apellido		NVARCHAR(255),
			prof_tipo_doc		VARCHAR(10),
			prof_num_dni		NUMERIC(18,0),
			prof_direccion		VARCHAR(255),
			prof_telefono		NUMERIC(18,0),
			prof_mail			VARCHAR(255),
			prof_fechaNac		DATETIME,
			prof_sex			NVARCHAR(100),
			prof_matr			NVARCHAR(100)
		);
		
		INSERT INTO @tmp_busqueda 
		SELECT prof_id, prof_nombre, prof_apellido, prof_tipo_doc, prof_num_dni, prof_direccion,
		prof_telefono, prof_mail, prof_fechaNac, prof_sex, prof_matr
		FROM gd_MORCIPAN.profesionales
		WHERE
		habilitado = 1 
		-- todos los like primero
		AND prof_nombre LIKE @prof_nombre
		AND prof_apellido LIKE @prof_apellido
		AND prof_direccion LIKE @prof_direccion
		AND prof_mail LIKE @prof_mail

		--	prof_id
		IF @prof_id != -2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_id NOT LIKE @prof_id;
			END

		--	prof_tipo_doc
		IF @prof_tipo_doc != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_tipo_doc != @prof_tipo_doc;
			END

		--	prof_num_dni
		IF @prof_num_dni != - 2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_num_dni != @prof_num_dni;
			END

		--	prof_telefono			
		IF @prof_telefono != - 2
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_telefono != @prof_telefono;
			END

		-- prof_fechaNac
		IF @prof_fechaNac != '1900-01-01 00:00:00.000'
			BEGIN
			DELETE FROM @tmp_busqueda
			WHERE 
			DATEDIFF (DAY, prof_fechaNac, @prof_fechaNac) != 0 OR 
			DATEDIFF (MONTH, prof_fechaNac, @prof_fechaNac) != 0  OR
			DATEDIFF (YEAR, prof_fechaNac, @prof_fechaNac) != 0
			END
		
		--	prof_sex
		IF @prof_sex != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_sex != @prof_sex;
			END
			
		--	prof_matr
		IF @prof_matr != '- 2'
			BEGIN
			DELETE FROM @tmp_busqueda 
			WHERE prof_matr != @prof_matr;
			END
					
		-- prof_esp_descr
		IF @prof_esp_descr != '- 2'
			BEGIN
				DELETE FROM @tmp_busqueda
				WHERE prof_id NOT IN (SELECT ESPPROF.prof_id
							      FROM especialidades_profesionales ESPPROF
							      JOIN especialidades ESP ON ESP.especialidad_codigo = ESPPROF.especialidad_codigo
							      WHERE ESP.especialidad_descrip = @prof_esp_descr)
			END
		--	resultado
		SELECT *
		FROM @tmp_busqueda

	END
END;
GO

/*	PROCEDURE: spAltaProfesional 
	DESCRIPCION: De de alta un profesional
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spAltaProfesional')
	DROP PROCEDURE gd_MORCIPAN.spAltaProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spAltaProfesional

	@prof_nombre			VARCHAR(255),
	@prof_apellido			NVARCHAR(255),
	@prof_tipo_doc			VARCHAR(10),
	@prof_num_dni			NUMERIC(18,0),
	@prof_direccion			VARCHAR(255),
	@prof_telefono			NUMERIC(18,0),
	@prof_mail				VARCHAR(255),
	@prof_fechaNac			DATETIME,
	@prof_sex				NVARCHAR(100),
	@prof_matr				NVARCHAR(100)

AS
BEGIN	
	
	BEGIN TRY -- insertar un profesional con el mismo DNI
		INSERT INTO gd_MORCIPAN.profesionales
		(prof_nombre, prof_apellido, prof_tipo_doc, prof_num_dni, prof_direccion, prof_telefono,
		prof_mail, prof_fechaNac, prof_sex, prof_matr)
		VALUES
		(@prof_nombre, @prof_apellido, @prof_tipo_doc, @prof_num_dni, @prof_direccion, @prof_telefono,
		@prof_mail, @prof_fechaNac, @prof_sex, @prof_matr)
		
		DECLARE @prof_id INT
		SELECT @prof_id = SCOPE_IDENTITY()		
		-- para devolver
		SELECT SCOPE_IDENTITY() as prof_id		

		DECLARE @usuario_id INT
		-- no existe el usuario en el sistema
		IF NOT EXISTS(SELECT usuario_id FROM gd_MORCIPAN.usuarios WHERE usuario_nombre = @prof_tipo_doc + CONVERT(NVARCHAR, @prof_num_dni))
		BEGIN
			-- insertamos el usuario al sistema
			INSERT INTO gd_MORCIPAN.usuarios
			(usuario_nombre, usuario_password)
			VALUES
			(@prof_tipo_doc + CONVERT(NVARCHAR, @prof_num_dni), 'JK/kfQvTAq5CZDxYSNmbaDJkAmzRLMmY4F4QC78tww0=')
			
			-- le ponemos rol profesional
			SELECT @usuario_id = SCOPE_IDENTITY()
			INSERT INTO gd_MORCIPAN.roles_usuarios
			(usuario_id, rol_id)
			VALUES
			(@usuario_id, 3)
			
			-- actualizamos el profesional insertado con el usuario_id
			UPDATE gd_MORCIPAN.profesionales
			SET usuario_id = @usuario_id
			WHERE prof_id = @prof_id 
			
		END
		
		-- ya existe dicho usuario, agregamos el perfil
		ELSE
			BEGIN
			
			SELECT @usuario_id = usuario_id FROM gd_MORCIPAN.usuarios
			WHERE usuario_nombre = @prof_tipo_doc + CONVERT(NVARCHAR, @prof_num_dni)
			INSERT INTO gd_MORCIPAN.roles_usuarios
			(usuario_id, rol_id)
			VALUES
			(@usuario_id, 3) 
			
			-- actualizamos el profesional con el usuario (ya era afiliado)
			UPDATE gd_MORCIPAN.profesionales
			SET usuario_id = @usuario_id
			WHERE prof_id = @prof_id 
			END	
	END TRY	
	BEGIN CATCH
	SELECT 0
	END CATCH

END;
GO

/*	PROCEDURE: spModificarProfesional 
	DESCRIPCION: Modifica los datos del profesional de acuerdo a su id
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spModificarProfesional')
	DROP PROCEDURE gd_MORCIPAN.spModificarProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spModificarProfesional

	@prof_id				INT,
	@prof_nombre			VARCHAR(255),
	@prof_apellido			NVARCHAR(255),
	@prof_tipo_doc			VARCHAR(10),
	@prof_num_dni			NUMERIC(18,0),
	@prof_direccion			VARCHAR(255),
	@prof_telefono			NUMERIC(18,0),
	@prof_mail				VARCHAR(255),
	@prof_fechaNac			DATETIME,
	@prof_sex				NVARCHAR(100),
	@prof_matr				NVARCHAR(100)

AS
BEGIN

	UPDATE gd_MORCIPAN.profesionales
	SET		
	prof_nombre = @prof_nombre,			
	prof_apellido = @prof_apellido,
	prof_tipo_doc = @prof_tipo_doc,
	prof_num_dni = @prof_num_dni,
	prof_direccion = @prof_direccion,
	prof_telefono = @prof_telefono,
	prof_mail = @prof_mail,
	prof_fechaNac = @prof_fechaNac,
	prof_sex = @prof_sex,
	prof_matr = @prof_matr
	WHERE prof_id = @prof_id
	
END;
GO

/*	PROCEDURE: spBajaLogicaProfesionalPorId 
	DESCRIPCION: Da de baja lógica un profesional.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spBajaLogicaProfesionalPorId')
	DROP PROCEDURE gd_MORCIPAN.spBajaLogicaProfesionalPorId
GO
CREATE PROCEDURE gd_MORCIPAN.spBajaLogicaProfesionalPorId
	@prof_id		INT
AS	
	UPDATE gd_MORCIPAN.profesionales
	SET habilitado = 0
	WHERE prof_id = @prof_id 
GO

/*	PROCEDURE: spAltaLogicaProfesionalPorId 
	DESCRIPCION: Da de alta logica a un profesional dado de baja. NO VUELVEN LOS TURNOS
	SE DEBEN CREAR DE NUEVO LA AGENDA
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spAltaLogicaProfesionalPorId')
	DROP PROCEDURE gd_MORCIPAN.spAltaLogicaProfesionalPorId
GO
CREATE PROCEDURE gd_MORCIPAN.spAltaLogicaProfesionalPorId
	@prof_id		INT
AS	

	ALTER TABLE gd_MORCIPAN.Profesionales DISABLE TRIGGER trBajaLogicaProfesional

	UPDATE gd_MORCIPAN.profesionales
	SET habilitado = 1
	WHERE prof_id = @prof_id 
	
	ALTER TABLE gd_MORCIPAN.Profesionales ENABLE TRIGGER trBajaLogicaProfesional
GO

/*	PROCEDURE: spObtenerEspecialidadesProfesional 
	DESCRIPCION: Obtiene las especialidades de un profesional
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spObtenerEspecialidadesProfesional')
	DROP PROCEDURE gd_MORCIPAN.spObtenerEspecialidadesProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerEspecialidadesProfesional
	@prof_id		INT
AS	

	SELECT ESP.especialidad_descrip FROM gd_MORCIPAN.especialidades ESP
	JOIN especialidades_profesionales ESP_P ON ESP_P.especialidad_codigo = ESP.especialidad_codigo
	JOIN profesionales P ON P.prof_id = ESP_P.prof_id
	WHERE @prof_id = ESP_P.prof_id AND P.habilitado = 1
GO

/*	PROCEDURE: spAltaEspecialidadPorProfesional 
	DESCRIPCION: Da de alta una especialidad a un profesional
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spAltaEspecialidadPorProfesional')
	DROP PROCEDURE gd_MORCIPAN.spAltaEspecialidadPorProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spAltaEspecialidadPorProfesional
	@prof_id				INT,
	@especialidad_descrip	VARCHAR(255)
AS	

	DECLARE @esp_cod INT
	SELECT @esp_cod = especialidad_codigo FROM gd_MORCIPAN.especialidades WHERE especialidad_descrip = @especialidad_descrip

	BEGIN TRY
	INSERT INTO gd_MORCIPAN.especialidades_profesionales (prof_id, especialidad_codigo)
	VALUES
	(@prof_id, @esp_cod)
	END TRY
	BEGIN CATCH
	END CATCH
GO

/*	PROCEDURE: spBajaEspecialidadPorProfesional 
	DESCRIPCION: Da de baja una especialidad a un profesional
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spBajaEspecialidadPorProfesional')
	DROP PROCEDURE gd_MORCIPAN.spBajaEspecialidadPorProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spBajaEspecialidadPorProfesional
	@prof_id				INT,
	@especialidad_descrip	VARCHAR(255)
AS	

	DECLARE @esp_cod INT
	SELECT @esp_cod = especialidad_codigo FROM gd_MORCIPAN.especialidades WHERE especialidad_descrip = @especialidad_descrip

	DELETE FROM gd_MORCIPAN.especialidades_profesionales
	WHERE prof_id = @prof_id AND especialidad_codigo = @esp_cod
GO

/*	PROCEDURE: spObtenerPlanesMedicos
	DESCRIPCION: Obtiene todos los planes médicos
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerPlanesMedicos')
	DROP PROCEDURE gd_MORCIPAN.spObtenerPlanesMedicos
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerPlanesMedicos
AS
BEGIN
	SELECT plan_codigo, plan_descripcion
	FROM gd_MORCIPAN.planes
	WHERE habilitado = 1
	ORDER BY plan_codigo ASC, plan_descripcion ASC
END;
GO

/* PROCEDURE: spObtenerProximoNroAfiliadoFamilia
   DESCRIPCION: Obtiene una secuencia de la tabla de secuencias.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerProximoNroAfiliadoFamilia')
	DROP PROCEDURE gd_MORCIPAN.spObtenerProximoNroAfiliadoFamilia
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerProximoNroAfiliadoFamilia
	@afiliado_numero INT
AS
BEGIN
	SELECT TOP 1 (afiliado_numero + 1) AS afiliado_numero_nuevo
	FROM gd_MORCIPAN.afiliados
	WHERE gd_MORCIPAN.fnPatronDelAfiliado(afiliado_numero) = gd_MORCIPAN.fnPatronDelAfiliado(@afiliado_numero)
	ORDER BY afiliado_numero DESC
END;
GO

/* PROCEDURE: spObtenerTodosIntegrantesGrupoFamiliarMenosRaiz
   DESCRIPCION: obtiene todos los integrantes del grupo familiar dado su numero de afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerTodosIntegrantesGrupoFamiliarMenosRaiz')
	DROP PROCEDURE gd_MORCIPAN.spObtenerTodosIntegrantesGrupoFamiliarMenosRaiz
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerTodosIntegrantesGrupoFamiliarMenosRaiz
	@afiliado_numero INT
AS
BEGIN
	SELECT afiliado_numero FROM gd_MORCIPAN.afiliados
	WHERE gd_MORCIPAN.fnPatronDelAfiliado(afiliado_numero) = gd_MORCIPAN.fnPatronDelAfiliado(@afiliado_numero)
	AND afiliado_numero != @afiliado_numero
	ORDER BY afiliado_numero DESC
END;
GO

/* FUNCTION: fnObtenerTodosIntegrantesGrupoFamiliarMenosRaiz
   DESCRIPCION: obtiene todos los integrantes del grupo familiar dado su numero de afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnObtenerTodosIntegrantesGrupoFamiliarMenosRaiz')
	DROP FUNCTION gd_MORCIPAN.fnObtenerTodosIntegrantesGrupoFamiliarMenosRaiz
GO
CREATE FUNCTION gd_MORCIPAN.fnObtenerTodosIntegrantesGrupoFamiliarMenosRaiz(
	@afiliado_numero INT)
RETURNS @table TABLE (afiliado_numero INT)
AS
BEGIN
	
	DECLARE @tmp TABLE (afiliado_numero INT)

	INSERT INTO @tmp (afiliado_numero) 
	SELECT afiliado_numero FROM gd_MORCIPAN.afiliados
	WHERE gd_MORCIPAN.fnPatronDelAfiliado(afiliado_numero) = gd_MORCIPAN.fnPatronDelAfiliado(@afiliado_numero)
	AND afiliado_numero != @afiliado_numero
	ORDER BY afiliado_numero DESC
	
	INSERT INTO @table SELECT afiliado_numero FROM @tmp
	RETURN
END;
GO

/* PROCEDURE: spInsertarAfiliado
   DESCRIPCION: Inserta un nuevo afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spInsertarAfiliado')
	DROP PROCEDURE gd_MORCIPAN.spInsertarAfiliado
GO
CREATE PROCEDURE gd_MORCIPAN.spInsertarAfiliado
	@afiliado_numero INT,
	@afiliado_nombre VARCHAR(255),
	@afiliado_apellido VARCHAR(255),
	@afiliado_tipo_documento VARCHAR(10),
	@afiliado_nro_documento NUMERIC(18,0),
	@afiliado_direccion VARCHAR(255),
	@afiliado_telefono NUMERIC(18,0),
	@afiliado_email VARCHAR(255),
	@afiliado_fecha_nacimiento DATETIME,
	@afiliado_sexo VARCHAR(50),
	@afiliado_estado_civil VARCHAR(255),
	@afiliado_cant_familiares_cargo INT,
	@afiliado_plan_medico VARCHAR(255)
AS
BEGIN
	DECLARE @afiliado_plan_medico_codigo INT
	
	SELECT @afiliado_plan_medico_codigo = plan_codigo FROM gd_MORCIPAN.planes WHERE plan_descripcion = @afiliado_plan_medico
	
	BEGIN TRY -- insertar un afiliado con el mismo dni
		INSERT INTO gd_MORCIPAN.afiliados
		(afiliado_numero,afiliado_nombre,afiliado_apellido,afiliado_tipo_documento,afiliado_nro_documento,
		 afiliado_direccion,afiliado_telefono,afiliado_email,afiliado_fecha_nacimiento,afiliado_sexo,
		 afiliado_estado_civil,afiliado_cant_familiares_cargo, afiliado_plan_medico_codigo)
		 VALUES
		(@afiliado_numero,@afiliado_nombre,@afiliado_apellido,@afiliado_tipo_documento,@afiliado_nro_documento,
		 @afiliado_direccion,@afiliado_telefono,@afiliado_email,@afiliado_fecha_nacimiento,@afiliado_sexo,
		 @afiliado_estado_civil,@afiliado_cant_familiares_cargo, @afiliado_plan_medico_codigo)
		 
		 -- esta todo peola, devuelvo afiliado_numero
		 SELECT @afiliado_numero as afiliado_numero
		 
		 DECLARE @usuario_id INT
		 -- no existe dicho usuario
		 IF NOT EXISTS(SELECT usuario_id FROM gd_MORCIPAN.usuarios WHERE usuario_nombre = @afiliado_tipo_documento + CONVERT(NVARCHAR, @afiliado_nro_documento))
			BEGIN
			-- insertamos el nuevo usuario
			 INSERT INTO gd_MORCIPAN.usuarios
			 (usuario_nombre, usuario_password)
			 VALUES
			 (@afiliado_tipo_documento + CONVERT(NVARCHAR, @afiliado_nro_documento), 'GurrpL2/iQdjhDS2BQSxA3wBkFvsKU+yzVNIck8vpk8=')
			 
			-- le ponemos rol afiliado
			SELECT @usuario_id = SCOPE_IDENTITY()
			INSERT INTO gd_MORCIPAN.roles_usuarios
			(usuario_id, rol_id)
			VALUES
			(@usuario_id, 2) 
			
			-- actualizamos el usuario_id del afiliado	
			UPDATE gd_MORCIPAN.afiliados
			SET usuario_id = @usuario_id
			WHERE afiliado_numero = @afiliado_numero
			
			END
		 
		 -- ya existe dicho usuario (es un profesional), agregamos el perfil
		 ELSE
			BEGIN
			
			SELECT @usuario_id = usuario_id FROM gd_MORCIPAN.usuarios
			WHERE usuario_nombre = @afiliado_tipo_documento + CONVERT(NVARCHAR, @afiliado_nro_documento)
			INSERT INTO gd_MORCIPAN.roles_usuarios
			(usuario_id, rol_id)
			VALUES
			(@usuario_id, 2) 
			
			-- actualizamos el usuario_id del afiliado	
			UPDATE gd_MORCIPAN.afiliados
			SET usuario_id = @usuario_id
			WHERE afiliado_numero = @afiliado_numero
			
			END
	 END TRY
	 BEGIN CATCH
	 END CATCH
END;
GO

/*	PROCEDURE: spBuscarRolesPorNombre
	DESCRIPCION: Busqueda de roles disponibles por nombre
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spBuscarRolesPorNombre')
	DROP PROCEDURE gd_MORCIPAN.spBuscarRolesPorNombre
GO
CREATE PROCEDURE gd_MORCIPAN.spBuscarRolesPorNombre
	@rol		NVARCHAR (255)
AS
BEGIN
	SELECT @rol = '%' + RTRIM(@rol) + '%';
	SELECT rol_id, rol_nombre
	FROM gd_MORCIPAN.roles
	WHERE rol_nombre LIKE (COALESCE(NULLIF(@rol,'%- 2%'), rol_nombre))
	AND habilitado = 1
	ORDER BY rol_nombre ASC
END;
GO

/*	PROCEDURE: spObtenerAfiliadoParaUsuario 
	DESCRIPCION: Obtiene el afiliado para un usuario id
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spObtenerAfiliadoParaUsuario')
	DROP PROCEDURE gd_MORCIPAN.spObtenerAfiliadoParaUsuario
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerAfiliadoParaUsuario 
	@usuario_id INT
AS
BEGIN
	SELECT afiliado_numero
	FROM gd_MORCIPAN.afiliados
	WHERE (afiliado_tipo_documento + CONVERT(NVARCHAR, afiliado_nro_documento)) = (SELECT usuario_nombre FROM gd_MORCIPAN.usuarios WHERE usuario_id = @usuario_id)
END
GO

/*	PROCEDURE: spObtenerProfesionalParaUsuario 
	DESCRIPCION: Obtiene el afiliado para un usuario id
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spObtenerProfesionalParaUsuario')
	DROP PROCEDURE gd_MORCIPAN.spObtenerProfesionalParaUsuario
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerProfesionalParaUsuario 
	@usuario_id INT
AS
BEGIN
	SELECT prof_id
	FROM gd_MORCIPAN.profesionales
	WHERE (prof_tipo_doc + CONVERT(NVARCHAR, prof_num_dni)) = (SELECT usuario_nombre FROM gd_MORCIPAN.usuarios WHERE usuario_id = @usuario_id)
END
GO

/*	PROCEDURE: spObtenerRolesDelSistema
	DESCRIPCION: Obtiene todos los roles del sistema.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerRolesDelSistema')
	DROP PROCEDURE gd_MORCIPAN.spObtenerRolesDelSistema
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerRolesDelSistema
AS
BEGIN
	SELECT ROL.rol_id, ROL.rol_nombre
	FROM gd_MORCIPAN.roles ROL
	WHERE habilitado = 1
	ORDER BY ROL.rol_nombre ASC
END;
GO

/*	PROCEDURE: spObtenerRolesUsuario
	DESCRIPCION: Obtiene los roles de un Usuario.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerRolesUsuario')
	DROP PROCEDURE gd_MORCIPAN.spObtenerRolesUsuario
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerRolesUsuario
	@usuario_id			INT
AS
BEGIN
	SELECT ROL.rol_id, ROL.rol_nombre
	FROM gd_MORCIPAN.roles_usuarios ROLUSU
	JOIN gd_MORCIPAN.roles ROL ON ROLUSU.rol_id = ROL.rol_id
	WHERE ROLUSU.usuario_id = @usuario_id
	ORDER BY ROL.rol_nombre ASC
END;
GO

/*	PROCEDURE: spObtenerFuncionesDelUsuarioDeAcuerdoASusRoles
	DESCRIPCION: Obtiene las funciones de un Usuario de acuerdo a los Roles que tiene asignados.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerFuncionesDelUsuarioDeAcuerdoASusRoles')
	DROP PROCEDURE gd_MORCIPAN.spObtenerFuncionesDelUsuarioDeAcuerdoASusRoles
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerFuncionesDelUsuarioDeAcuerdoASusRoles
	@usuario			NVARCHAR (255)
AS
BEGIN
	DECLARE @idUsuario int
	SELECT @idUsuario = usuario_id FROM gd_MORCIPAN.usuarios WHERE usuario_nombre = @usuario

	SELECT FUN.funcion_nombre FROM gd_MORCIPAN.funciones FUN 
	INNER JOIN gd_MORCIPAN.funciones_roles FR ON FR.funcion_id = FUN.funcion_id 
	INNER JOIN gd_MORCIPAN.roles R ON R.rol_id = FR.rol_id
	INNER JOIN gd_MORCIPAN.roles_usuarios RU ON RU.rol_id = R.rol_id
	INNER JOIN gd_MORCIPAN.usuarios USU ON USU.usuario_id = RU.usuario_id
	WHERE USU.usuario_id = @idUsuario AND FUN.habilitada = 1 AND R.habilitado = 1
	ORDER BY FUN.funcion_nombre ASC
END;
GO

/*	PROCEDURE: spObtenerFuncionalidades
	DESCRIPCION: devuelve todas las funcionalidades
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerFuncionalidades')
	DROP PROCEDURE gd_MORCIPAN.spObtenerFuncionalidades
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerFuncionalidades
AS
BEGIN
	SELECT F.funcion_id, F.funcion_nombre
	FROM gd_MORCIPAN.funciones F
	ORDER BY F.funcion_id ASC
END;
GO

/*	PROCEDURE: spObtenerFuncionalidadesPorRolId
	DESCRIPCION: devuelve las funcionalidades de un rol
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerFuncionalidadesPorRolId')
	DROP PROCEDURE gd_MORCIPAN.spObtenerFuncionalidadesPorRolId
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerFuncionalidadesPorRolId
	@rol_id		INT
AS
BEGIN
	SELECT F.funcion_id, F.funcion_nombre
	FROM gd_MORCIPAN.funciones F
	JOIN gd_MORCIPAN.funciones_roles FR ON FR.funcion_id = F.funcion_id
	JOIN gd_MORCIPAN.roles R ON FR.rol_id = R.rol_id
	WHERE FR.rol_id = @rol_id AND R.habilitado = 1 AND F.habilitada = 1

END;
GO

/*	PROCEDURE: spEliminarRolPorId 
	DESCRIPCION: Da de baja lógica un Rol.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spEliminarRolPorId')
	DROP PROCEDURE gd_MORCIPAN.spEliminarRolPorId
GO
CREATE PROCEDURE gd_MORCIPAN.spEliminarRolPorId
	@rol_id		INT
AS	
	UPDATE gd_MORCIPAN.roles
	SET habilitado = 0
	WHERE @rol_id = rol_id 
GO

/*	PROCEDURE: spEliminarFuncionalidadesDeRolPorId 
	DESCRIPCION: Da de baja lógica un Rol.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spEliminarFuncionalidadesDeRolPorId')
	DROP PROCEDURE gd_MORCIPAN.spEliminarFuncionalidadesDeRolPorId
GO
CREATE PROCEDURE gd_MORCIPAN.spEliminarFuncionalidadesDeRolPorId
	@rol_id		INT
AS	
	DELETE FROM gd_MORCIPAN.funciones_roles
	WHERE rol_id = @rol_id
GO


/*	PROCEDURE: spActualizarNombreRol 
	DESCRIPCION: Agrega una Funcionalidad dependiendo del Rol recibido como parámetro.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spActualizarNombreRol')
	DROP PROCEDURE gd_MORCIPAN.spActualizarNombreRol
GO
CREATE PROCEDURE gd_MORCIPAN.spActualizarNombreRol 
	@rol_id			INT,
	@rol_nombre		NVARCHAR(255)
AS
BEGIN
	UPDATE gd_MORCIPAN.roles 
	SET rol_nombre = @rol_nombre
	WHERE rol_id = @rol_id
END;
GO

/*	PROCEDURE: spAgregarFuncionalidadARolPorId 
	DESCRIPCION: Agrega una Funcionalidad dependiendo del Rol recibido como parámetro.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spAgregarFuncionalidadARolPorId')
	DROP PROCEDURE gd_MORCIPAN.spAgregarFuncionalidadARolPorId
GO
CREATE PROCEDURE gd_MORCIPAN.spAgregarFuncionalidadARolPorId 
	@rol_id			INT,
	@funcion		NVARCHAR(255)
AS
BEGIN
	DECLARE @fkfuncion INT
	SELECT @fkfuncion = funcion_id FROM gd_MORCIPAN.funciones WHERE funcion_nombre = @funcion AND habilitada = 1

	INSERT INTO gd_MORCIPAN.funciones_roles (rol_id, funcion_id) VALUES (@rol_id, @fkfuncion)

END;
GO

/*	PROCEDURE: spAgregarFuncionalidadIdARolPorId 
	DESCRIPCION: Agrega una Funcionalidad dependiendo del Rol recibido como parámetro.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spAgregarFuncionalidadIdARolPorId')
	DROP PROCEDURE gd_MORCIPAN.spAgregarFuncionalidadIdARolPorId
GO
CREATE PROCEDURE gd_MORCIPAN.spAgregarFuncionalidadIdARolPorId 
	@rol_id			INT,
	@funcion_id		INT
AS
BEGIN
	INSERT INTO gd_MORCIPAN.funciones_roles 
	(rol_id, funcion_id) 
	VALUES 
	(@rol_id, @funcion_id)
END;
GO

/*	PROCEDURE: spInsertarOActivarRol 
	DESCRIPCION: Inserta un nuevo Rol, en caso de que exista lo habilita
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spInsertarOActivarRol')
	DROP PROCEDURE gd_MORCIPAN.spInsertarOActivarRol
GO
CREATE PROCEDURE gd_MORCIPAN.spInsertarOActivarRol
	@rol_nombre		NVARCHAR(255)
AS
BEGIN
	
	DECLARE @rol_id INT
	SELECT @rol_id = rol_id FROM gd_MORCIPAN.roles WHERE rol_nombre = @rol_nombre
	
	IF @rol_id IS NULL -- ROL NUEVO
		BEGIN
			INSERT INTO gd_MORCIPAN.roles(rol_nombre) VALUES (@rol_nombre)
			SELECT SCOPE_IDENTITY()
		END
		
	ELSE -- SE HABILITA EL ROL
		BEGIN
			UPDATE gd_MORCIPAN.roles
			SET habilitado = 1 
			WHERE rol_nombre = @rol_nombre	
			SELECT @rol_id
		END	
END;
GO

/*	PROCEDURE: spEsUsuarioValido 
	DESCRIPCION: Valida existencia de un usuario
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spEsUsuarioValido')
	DROP PROCEDURE gd_MORCIPAN.spEsUsuarioValido
GO
CREATE PROCEDURE gd_MORCIPAN.spEsUsuarioValido 
	@usuario NVARCHAR(100),
	@password NVARCHAR(100)
AS
BEGIN
	SELECT usuario_id
	FROM gd_MORCIPAN.usuarios 
	WHERE usuario_nombre = @usuario 
	AND usuario_password = @password
	AND habilitado = 1
END
GO

/*	PROCEDURE: spEsRolValidoParaUsuario 
	DESCRIPCION: Valida la existencia de un rol para un usuario
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spEsRolValidoParaUsuario')
	DROP PROCEDURE gd_MORCIPAN.spEsRolValidoParaUsuario
GO
CREATE PROCEDURE gd_MORCIPAN.spEsRolValidoParaUsuario 
	@usuario_id INT,
	@rol_id INT
AS
BEGIN
	SELECT COUNT(*)
	FROM gd_MORCIPAN.roles_usuarios
	WHERE rol_id = @rol_id
	AND usuario_id = @usuario_id
END
GO

/*	PROCEDURE: spObtenerPreciosBonos
	DESCRIPCION: Devuelve el precio de un bono dependiendo del plan.
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerPreciosBonos')
	DROP PROCEDURE gd_MORCIPAN.spObtenerPreciosBonos
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerPreciosBonos
	@afiliado_plan_medico		VARCHAR(255),
	@tipo_bono	VARCHAR(255)
AS
BEGIN
	IF @tipo_bono = 'FARMACIA'
	BEGIN
		SELECT P.plan_precio_bono_farmacia
		FROM gd_MORCIPAN.planes P
		WHERE P.plan_descripcion LIKE '%' + @afiliado_plan_medico + '%'
	END
	ELSE
	BEGIN
		SELECT P.plan_precio_bono_consulta
		FROM gd_MORCIPAN.planes P
		WHERE P.plan_descripcion LIKE '%' + @afiliado_plan_medico + '%'
	END
END;
GO

/*	PROCEDURE: spInactivarUsuario 
	DESCRIPCION: Inactiva lógicamente un usuario
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spInactivarUsuario')
	DROP PROCEDURE gd_MORCIPAN.spInactivarUsuario
GO
CREATE PROCEDURE gd_MORCIPAN.spInactivarUsuario 
	@usuario NVARCHAR(100)
AS
BEGIN
	UPDATE gd_MORCIPAN.usuarios 
	SET habilitado = 0 
	WHERE usuario_nombre = @usuario
END
GO

/*	FUNCTION: fnPatronDelAfiliado
	DESCRIPCION: Obtiene el patron del afiliado en base a su número
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnPatronDelAfiliado')
	DROP FUNCTION gd_MORCIPAN.fnPatronDelAfiliado
GO
CREATE FUNCTION gd_MORCIPAN.fnPatronDelAfiliado(
	@afiliado_numero	INT
)
RETURNS INT
AS
BEGIN
	DECLARE @resultado INT
	SELECT @resultado = CONVERT("INT",LEFT(CONVERT("NVARCHAR",@afiliado_numero), LEN(CONVERT("NVARCHAR",@afiliado_numero)) - 2))
	RETURN @resultado
END	
GO

/*	FUNCTION: fnAfiliadoRaiz
	DESCRIPCION: Devuelve si el afiliado es el raiz
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnAfiliadoRaiz')
	DROP FUNCTION gd_MORCIPAN.fnAfiliadoRaiz
GO
CREATE FUNCTION gd_MORCIPAN.fnAfiliadoRaiz(
	@afiliado_numero	INT
)
RETURNS BIT
AS
BEGIN
	DECLARE @aux NVARCHAR(20)
	
	SELECT @aux = RIGHT(CONVERT("NVARCHAR",@afiliado_numero),2)
	
	IF(@aux = '01')
		RETURN 1
		
	RETURN 0
END	
GO

/*	PROCEDURE: spObtenerBonosAfiliado
	DESCRIPCION: Obtiene todos los bonos de un afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerBonosAfiliado')
	DROP PROCEDURE gd_MORCIPAN.spObtenerBonosAfiliado
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerBonosAfiliado
	@afiliado_numero	INT,
	@tipo_bono			NVARCHAR(100)
AS
BEGIN
	IF @tipo_bono = 'consulta'
		BEGIN
			SELECT bono_consulta_numero
			FROM gd_MORCIPAN.bonos_consulta
			WHERE gd_MORCIPAN.fnPatronDelAfiliado(afiliado_numero) = gd_MORCIPAN.fnPatronDelAfiliado(@afiliado_numero)
			AND habilitado = 1 AND afiliado_utilizo IS NULL
		END
	ELSE
		BEGIN
			SELECT bono_farmacia_numero
			FROM gd_MORCIPAN.bonos_farmacia
			WHERE gd_MORCIPAN.fnPatronDelAfiliado(afiliado_numero) = gd_MORCIPAN.fnPatronDelAfiliado(@afiliado_numero)	
			AND habilitado = 1 AND afiliado_utilizo IS NULL
		END
END;
GO

/*	
	PROCEDURE: spObtenerTurnosAfiliado
	DESCRIPCION: Obtiene todos los turnos de un afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerTurnosAfiliado')
	DROP PROCEDURE gd_MORCIPAN.spObtenerTurnosAfiliado
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerTurnosAfiliado
	@afiliado_numero	INT
AS
BEGIN
	
	DECLARE @fechaSis DATETIME
	EXEC @fechaSis = GD2C2013.gd_MORCIPAN.fnDevolverFechaSistema

	SELECT turno_numero, turno_fecha 
	FROM gd_MORCIPAN.turnos
	WHERE afiliado_numero = @afiliado_numero
	AND turno_fecha > @fechaSis
	ORDER BY turno_fecha ASC
END;
GO

/*	
	PROCEDURE: spObtenerTurnosAfiliadoSinConsulta
	DESCRIPCION: Obtiene todos los turnos de un afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerTurnosAfiliadoSinConsulta')
	DROP PROCEDURE gd_MORCIPAN.spObtenerTurnosAfiliadoSinConsulta
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerTurnosAfiliadoSinConsulta
	@afiliado_numero	INT
AS
BEGIN
	
	DECLARE @fechaSis DATETIME
	EXEC @fechaSis = GD2C2013.gd_MORCIPAN.fnDevolverFechaSistema

	SELECT TU.turno_numero, TU.turno_fecha 
	FROM gd_MORCIPAN.turnos TU
	LEFT JOIN gd_MORCIPAN.consultas_medicas CM ON CM.turno_numero = TU.turno_numero
	WHERE TU.afiliado_numero = @afiliado_numero
	AND DATEDIFF(DAY,@fechaSis,turno_fecha) > 1 
	AND CM.turno_numero is NULL
	ORDER BY turno_fecha ASC
END;
GO

/*	PROCEDURE: spInsertarBonoConsulta 
	DESCRIPCION: inserta un bono consulta a un afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spInsertarBonoConsulta')
	DROP PROCEDURE gd_MORCIPAN.spInsertarBonoConsulta
GO
CREATE PROCEDURE gd_MORCIPAN.spInsertarBonoConsulta 
	@afiliado_numero	INT,
	@plan				NVARCHAR(255)
AS
BEGIN
	
	DECLARE @bono_numero INT
	EXEC @bono_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'bonos_consulta', 1, 0, 1

	DECLARE @plan_id INT
	SELECT @plan_id = plan_codigo FROM gd_MORCIPAN.planes WHERE plan_descripcion = @plan

	DECLARE @fecha DATETIME
	EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
	
	INSERT INTO gd_MORCIPAN.bonos_consulta 
	(bono_consulta_numero, bono_consulta_fecha_impresion, bono_compra_fecha, afiliado_numero, plan_codigo)
	VALUES
	(@bono_numero, @fecha, @fecha, @afiliado_numero, @plan_id)
	
END
GO

/*	PROCEDURE: spObtenerEspecialidades
	DESCRIPCION: Obtiene todos las especialidades
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerEspecialidades')
	DROP PROCEDURE gd_MORCIPAN.spObtenerEspecialidades
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerEspecialidades
AS
BEGIN
	SELECT especialidad_codigo, especialidad_descrip
	FROM gd_MORCIPAN.especialidades
	WHERE habilitado = 1
	ORDER BY especialidad_descrip ASC
END;
GO

/*	PROCEDURE: spObtenerRangoFechasAgendaProfesional
	DESCRIPCION: Obener rango fechas agenda profesional
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spObtenerRangoFechasAgendaProfesional')
	DROP PROCEDURE gd_MORCIPAN.spObtenerRangoFechasAgendaProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerRangoFechasAgendaProfesional
	@profesional_id		INT
AS
BEGIN
	SELECT agen_fecha_ini, agen_fecha_fin
	FROM gd_MORCIPAN.agendas_profesionales
	WHERE prof_id = @profesional_id
	AND habilitada = 1
END;
GO

/*	PROCEDURE: spInsertarBonoFarmacia
	DESCRIPCION: inserta un bono farmacia a un afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spInsertarBonoFarmacia')
	DROP PROCEDURE gd_MORCIPAN.spInsertarBonoFarmacia
GO
CREATE PROCEDURE gd_MORCIPAN.spInsertarBonoFarmacia
	@afiliado_numero	INT,
	@plan				NVARCHAR(255)
AS
BEGIN
	
	DECLARE @bono_numero INT
	EXEC @bono_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'bonos_farmacia', 1, 0, 1

	DECLARE @plan_id INT
	SELECT @plan_id = plan_codigo FROM gd_MORCIPAN.planes WHERE plan_descripcion = @plan

	DECLARE @fecha DATETIME
	EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
	
	DECLARE @fechaVecimiento DATETIME
	SELECT @fechaVecimiento = DATEADD(DAY, 60, @fecha)
	
	INSERT INTO gd_MORCIPAN.bonos_farmacia 
	(bono_farmacia_numero, bono_farmacia_fecha_impresion, bono_farmacia_fecha_vencimiento,
	bono_compra_fecha, afiliado_numero, plan_codigo)
	VALUES
	(@bono_numero, @fecha, @fechaVecimiento, @fecha, @afiliado_numero, @plan_id)
	
END
GO

/*	PROCEDURE: spRegistrarTurnoAfiliado
	DESCRIPCION: registra un turno para un afiliado y un profesional
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spRegistrarTurnoAfiliado')
	DROP PROCEDURE gd_MORCIPAN.spRegistrarTurnoAfiliado
GO
CREATE PROCEDURE gd_MORCIPAN.spRegistrarTurnoAfiliado
	@afiliado_numero	INT,
	@turno_numero		INT
AS
BEGIN
	UPDATE gd_MORCIPAN.turnos
	SET afiliado_numero = @afiliado_numero
	WHERE turno_numero = @turno_numero
END
GO

/*	PROCEDURE: trCreacionTurnosAgenda
	DESCRIPCION: Crea los turnos de la agenda al darla de alta
*/
/*IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='trCreacionTurnosAgenda')
	DROP TRIGGER gd_MORCIPAN.trCreacionTurnosAgenda
GO
CREATE TRIGGER trCreacionTurnosAgenda
ON gd_MORCIPAN.agendas_profesionales
AFTER INSERT 
AS 
BEGIN
SET NOCOUNT ON;

	DECLARE @flag			BIT
	DECLARE @turno_numero	INT
	DECLARE @nom_dia		NVARCHAR(50)
	DECLARE @fecha_ini		DATETIME
	DECLARE @fecha_fin		DATETIME
	DECLARE @fecha_turno	DATETIME
	DECLARE @hora_ini		TIME
	DECLARE @hora_fin		TIME
	DECLARE @prof_id		INT
	DECLARE @hora_parte		INT
	DECLARE @min_parte		INT
	DECLARE @agenda_id		INT
	
	SELECT @fecha_ini = agen_fecha_ini FROM inserted 
	SELECT @fecha_fin = agen_fecha_fin FROM inserted
	SELECT @agenda_id = agenda_id FROM inserted
	SELECT @nom_dia = DATENAME(weekday, @fecha_ini)

	WHILE(@fecha_ini<=@fecha_fin)
		BEGIN 
		
				
		if(@nom_dia = 'Monday' or @nom_dia = 'Lunes')	-- LUNES
			BEGIN
			SELECT @flag = agen_lun FROM inserted 
			if(@flag = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SELECT @hora_ini = agen_lun_ini FROM inserted 
				SELECT @hora_fin = agen_lun_fin FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id) --, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END
		

		if(@nom_dia = 'Tuesday' or @nom_dia = 'Martes')	-- MARTES
			BEGIN
			SELECT @flag = agen_mar FROM inserted 
			if(@flag = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SELECT @hora_ini = agen_mar_ini FROM inserted 
				SELECT @hora_fin = agen_mar_fin FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id) --, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id) --, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END


		if(@nom_dia = 'Wednesday' or @nom_dia = 'Miércoles')	-- MIERCOLES
			BEGIN
			SELECT @flag = agen_mie FROM inserted 
			if(@flag = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SELECT @hora_ini = agen_mie_ini FROM inserted 
				SELECT @hora_fin = agen_mie_fin FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id)--, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END


		if(@nom_dia = 'Thursday' or @nom_dia = 'Jueves')	-- JUEVES
			BEGIN
			SELECT @flag = agen_jue FROM inserted 
			if(@flag = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SELECT @hora_ini = agen_jue_ini FROM inserted 
				SELECT @hora_fin = agen_jue_fin FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id)--, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END


		if(@nom_dia = 'Friday' or @nom_dia = 'Viernes')	-- VIERNES
			BEGIN
			SELECT @flag = agen_vie FROM inserted 
			if(@flag = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SELECT @hora_ini = agen_vie_ini FROM inserted 
				SELECT @hora_fin = agen_vie_fin FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id)--, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END
			
			
		if(@nom_dia = 'Saturday' or @nom_dia = 'Sábado')	-- SABADO
			BEGIN
			SELECT @flag = agen_vie FROM inserted 
			if(@flag = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SELECT @hora_ini = agen_vie_ini FROM inserted 
				SELECT @hora_fin = agen_vie_fin FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id)--, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END
					
		
		--	sumamos un dia mas
		SELECT @fecha_ini = DATEADD(day,1,@fecha_ini)
		--	nombre del nuevo dia
		SELECT @nom_dia = DATENAME(weekday, @fecha_ini)
		END

END
GO*/

/*	FUNCTION: fnVerificarCreacionAgenda
	DESCRIPCION: Verifica que la agenda sea posible de crear, no exista turnos entre las
	fechas inicio y fin de la misma
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnVerificarCreacionAgenda')
	DROP FUNCTION gd_MORCIPAN.fnVerificarCreacionAgenda
GO
CREATE FUNCTION gd_MORCIPAN.fnVerificarCreacionAgenda(
	@fecha_ini			DATETIME,
	@fecha_fin			DATETIME,
	@prof_id			INT
)
RETURNS BIT
AS
BEGIN

	IF EXISTS ( SELECT * FROM gd_MORCIPAN.turnos
							WHERE prof_id = @prof_id  
							AND turno_fecha >= @fecha_ini
							AND turno_fecha <= @fecha_fin
							AND habilitado = 1)
							BEGIN
							RETURN 0
							END
	RETURN 1

END	
GO

/*	PROCEDURE: spCrearAgendaProfesional
	DESCRIPCION: Crea la agenda y los turnos del profesional dado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spCrearAgendaProfesional')
	DROP PROCEDURE gd_MORCIPAN.spCrearAgendaProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spCrearAgendaProfesional
	@agen_fecha_ini		DATETIME,
	@agen_fecha_fin		DATETIME,
	@prof_id			INT,
	@agen_lun			BIT,
	@agen_mar			BIT,
	@agen_mie			BIT,
	@agen_jue			BIT,
	@agen_vie			BIT,
	@agen_sab			BIT,
	@agen_lun_ini		TIME,
	@agen_lun_fin		TIME,	
	@agen_mar_ini		TIME,
	@agen_mar_fin		TIME,
	@agen_mie_ini		TIME,
	@agen_mie_fin		TIME,
	@agen_jue_ini		TIME,
	@agen_jue_fin		TIME,
	@agen_vie_ini		TIME,
	@agen_vie_fin		TIME,
	@agen_sab_ini		TIME,
	@agen_sab_fin		TIME		
AS
BEGIN

	declare @flag BIT
	EXEC @flag = GD2C2013.gd_MORCIPAN.fnVerificarCreacionAgenda @agen_fecha_ini, @agen_fecha_fin, @prof_id

	-- las fechas de las agendas se solapan, se deshabilitan los turnos entre esas fechas
	if(@flag = 0)
		EXEC GD2C2013.gd_MORCIPAN.spDarDeBajaTurnosProfesionalDesdeHasta @prof_id, @agen_fecha_ini, @agen_fecha_fin


	-- creacion de turnos

	--DECLARE @flag			BIT
	DECLARE @turno_numero	INT
	DECLARE @nom_dia		NVARCHAR(50)
	DECLARE @fecha_ini		DATETIME
	DECLARE @fecha_fin		DATETIME
	DECLARE @fecha_turno	DATETIME
	DECLARE @hora_ini		TIME
	DECLARE @hora_fin		TIME
	--DECLARE @prof_id		INT
	DECLARE @hora_parte		INT
	DECLARE @min_parte		INT
	DECLARE @agenda_id		INT
	
	SET @fecha_ini = @agen_fecha_ini --FROM inserted 
	SET @fecha_fin = @agen_fecha_fin --FROM inserted
	--SELECT @agenda_id = agenda_id FROM inserted
	SELECT @nom_dia = DATENAME(weekday, @fecha_ini)

	WHILE(@fecha_ini<=@fecha_fin)
		BEGIN 
		
				
		if(@nom_dia = 'Monday' or @nom_dia = 'Lunes')	-- LUNES
			BEGIN
			--SELECT @flag = agen_lun FROM inserted 
			if(@agen_lun = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SET @hora_ini = @agen_lun_ini --FROM inserted 
				SET @hora_fin = @agen_lun_fin --FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				--SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id) --, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END
		

		if(@nom_dia = 'Tuesday' or @nom_dia = 'Martes')	-- MARTES
			BEGIN
			--SELECT @flag = agen_mar FROM inserted 
			if(@agen_mar = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SET @hora_ini = @agen_mar_ini --FROM inserted 
				SET @hora_fin = @agen_mar_fin --FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				--SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id) --, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id) --, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END


		if(@nom_dia = 'Wednesday' or @nom_dia = 'Miércoles')	-- MIERCOLES
			BEGIN
			--SELECT @flag = agen_mie FROM inserted 
			if(@agen_mie = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SET @hora_ini = @agen_mie_ini --FROM inserted 
				SET @hora_fin = @agen_mie_fin --FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				--SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id)--, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END


		if(@nom_dia = 'Thursday' or @nom_dia = 'Jueves')	-- JUEVES
			BEGIN
			--SELECT @flag = agen_jue FROM inserted 
			if(@agen_jue = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SET @hora_ini = @agen_jue_ini --FROM inserted 
				SET @hora_fin = @agen_jue_fin --FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				--SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id)--, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END


		if(@nom_dia = 'Friday' or @nom_dia = 'Viernes')	-- VIERNES
			BEGIN
			--SELECT @flag = agen_vie FROM inserted 
			if(@agen_vie = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SET @hora_ini = @agen_vie_ini --FROM inserted 
				SET @hora_fin = @agen_vie_fin --FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				--SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id)--, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END
			
			
		if(@nom_dia = 'Saturday' or @nom_dia = 'Sábado')	-- SABADO
			BEGIN
			--SELECT @flag = agen_vie FROM inserted 
			if(@agen_vie = 1)  -- esta habilitado??
				BEGIN
				
				SELECT @fecha_turno = @fecha_ini
				SET @hora_ini = @agen_vie_ini --FROM inserted 
				SET @hora_fin = @agen_vie_fin --FROM inserted
				SELECT @hora_parte = DATEPART(HOUR, @hora_ini)
				SELECT @min_parte = DATEPART(MINUTE, @hora_ini)
				SELECT @fecha_turno = DATEADD(HOUR,@hora_parte,@fecha_turno)
				SELECT @fecha_turno = DATEADD(MINUTE,@min_parte,@fecha_turno)
				--SELECT @prof_id = prof_id FROM inserted
								
				WHILE (@hora_ini < @hora_fin)				
					BEGIN
					EXEC @turno_numero = gd_MORCIPAN.spObtenerNuevaSecuenciaTabla 'turnos', 1, 0, 1
					INSERT INTO gd_MORCIPAN.turnos
					(turno_numero, turno_fecha ,afiliado_numero, prof_id)--, agenda_id)
					VALUES
					(@turno_numero, @fecha_turno, null, @prof_id)--, @agenda_id)
					SELECT @hora_ini = DATEADD(minute,30,@hora_ini)
					SELECT @fecha_turno = DATEADD(minute,30,@fecha_turno)
					END
				END						
			END
					
		
		--	sumamos un dia mas
		SELECT @fecha_ini = DATEADD(day,1,@fecha_ini)
		--	nombre del nuevo dia
		SELECT @nom_dia = DATENAME(weekday, @fecha_ini)
		END


	-- actualizacion de agenda
	-- ya existia
	IF EXISTS (SELECT * FROM gd_MORCIPAN.agendas_profesionales WHERE prof_id = @prof_id)
		BEGIN 
		
		DECLARE @fecha_ini_prof DATETIME
		DECLARE @fecha_fin_prof DATETIME
		SELECT @fecha_ini_prof=agen_fecha_ini, @fecha_fin_prof=agen_fecha_fin
		FROM agendas_profesionales WHERE prof_id = @prof_id
		
		IF (@agen_fecha_ini < @fecha_ini_prof)
			BEGIN
			UPDATE gd_MORCIPAN.agendas_profesionales
			SET agen_fecha_ini = @agen_fecha_ini
			WHERE prof_id = @prof_id
			END
			
		IF (@agen_fecha_fin > @fecha_fin_prof)
			BEGIN		
			UPDATE gd_MORCIPAN.agendas_profesionales
			SET agen_fecha_fin = @agen_fecha_fin
			WHERE prof_id = @prof_id
			END
		
		END

	-- no tenia agenda
	ELSE
		BEGIN 
		INSERT INTO gd_MORCIPAN.agendas_profesionales 
		(prof_id, agen_fecha_ini, agen_fecha_fin)
		VALUES
		(@prof_id, @agen_fecha_ini, @agen_fecha_fin)
		END

END
GO

/*	PROCEDURE: spDarDeBajaAgendaProfesional
	DESCRIPCION: Da de baja una agenda y sus respectivos turnos
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spDarDeBajaAgendaProfesional')
	DROP PROCEDURE gd_MORCIPAN.spDarDeBajaAgendaProfesional
GO
CREATE PROCEDURE gd_MORCIPAN.spDarDeBajaAgendaProfesional
	@prof_id			INT
AS
BEGIN
		DECLARE @fecha DATETIME
		EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
		
		/*DECLARE @agenda_id INT
		SELECT @agenda_id = agenda_id FROM agendas_profesionales
		WHERE prof_id = @prof_id
		AND habilitada = 1*/

		UPDATE gd_MORCIPAN.turnos
		SET habilitado = 0
		WHERE prof_id = @prof_id 
		AND turno_fecha >= @fecha
END
GO


/*	PROCEDURE: spDarDeBajaTurnosProfesionalDesdeHasta
	DESCRIPCION: Da de baja los turnos del profesional en determinadas fechas
	teniendo en cuenta la fecha del sistema
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spDarDeBajaTurnosProfesionalDesdeHasta')
	DROP PROCEDURE gd_MORCIPAN.spDarDeBajaTurnosProfesionalDesdeHasta
GO
CREATE PROCEDURE gd_MORCIPAN.spDarDeBajaTurnosProfesionalDesdeHasta
	@prof_id			INT,
	@fecha_ini			DATETIME,
	@fecha_fin			DATETIME
AS
BEGIN
		DECLARE @fecha DATETIME
		EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
		
		-- al venir en hora 00:00:00.000, no se cancelan los turnos
		-- del ultimo dia
		DECLARE @fecha_fin_aux DATETIME
		SELECT @fecha_fin_aux = DATEADD(DAY,1,@fecha_fin)

		UPDATE gd_MORCIPAN.turnos
		SET habilitado = 0
		WHERE prof_id = @prof_id 
		AND turno_fecha >= @fecha_ini
		AND turno_fecha <  @fecha_fin_aux
		AND turno_fecha >= @fecha
END
GO

/*	FUNCTION: fnVerificacionTurnoRepetido
	DESCRIPCION: Verifica que un turno querido ya no este asignado
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnVerificacionTurnoRepetido')
	DROP FUNCTION gd_MORCIPAN.fnVerificacionTurnoRepetido
GO
CREATE FUNCTION gd_MORCIPAN.fnVerificacionTurnoRepetido(
	@fechaHora_turno	DATETIME,
	@prof_id			INT
)
RETURNS BIT
AS
BEGIN

	IF EXISTS ( SELECT * FROM gd_MORCIPAN.turnos
							WHERE turno_fecha = @fechaHora_turno AND prof_id = @prof_id)
							BEGIN
							RETURN 1
							END
							
	RETURN 0

END	
GO

/*	PROCEDURE: spListarTurnosProfesionalDia
	DESCRIPCION: lista los turnos libres u ocupados de un profesional para una
	fecha dada
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spListarTurnosProfesionalDia')
	DROP PROCEDURE gd_MORCIPAN.spListarTurnosProfesionalDia
GO
CREATE PROCEDURE gd_MORCIPAN.spListarTurnosProfesionalDia
	@fecha				DATETIME,
	@prof_id			INT,
	@cond				NVARCHAR(50)
AS
BEGIN

	IF(@cond = 'libres')
		BEGIN
		SELECT *, 
			   RIGHT('00'+CONVERT(NVARCHAR(2),DATEPART(HH, turno_fecha)),2) +  ':' + RIGHT('00'+CONVERT(NVARCHAR(2),DATEPART(MI, turno_fecha)),2) AS horas_minutos
		FROM gd_MORCIPAN.turnos
		WHERE	prof_id = @prof_id AND		
				DATEDIFF (DAY, turno_fecha, @fecha) = 0 AND 
				DATEDIFF (MONTH, turno_fecha, @fecha) = 0  AND
				DATEDIFF (YEAR, turno_fecha, @fecha) = 0	AND
				afiliado_numero IS NULL AND
				habilitado = 1
		END
	 
	IF(@cond = 'ocupados')
		BEGIN
		SELECT *, 
			   RIGHT('00'+CONVERT(NVARCHAR(2),DATEPART(HH, turno_fecha)),2) +  ':' + RIGHT('00'+CONVERT(NVARCHAR(2),DATEPART(MI, turno_fecha)),2) AS horas_minutos
		FROM gd_MORCIPAN.turnos
		WHERE	prof_id = @prof_id AND		
				DATEDIFF (DAY, turno_fecha, @fecha) = 0 AND 
				DATEDIFF (MONTH, turno_fecha, @fecha) = 0  AND
				DATEDIFF (YEAR, turno_fecha, @fecha) = 0	AND
				afiliado_numero IS NOT NULL AND 
				habilitado = 1
		END

END
GO

/*	PROCEDURE: spListarTurnosProfesionalDiaSinConsulta
	DESCRIPCION: lista los turnos libres u ocupados de un profesional para una
	fecha dada
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spListarTurnosProfesionalDiaSinConsulta')
	DROP PROCEDURE gd_MORCIPAN.spListarTurnosProfesionalDiaSinConsulta
GO
CREATE PROCEDURE gd_MORCIPAN.spListarTurnosProfesionalDiaSinConsulta
	@fecha				DATETIME,
	@prof_id			INT,
	@cond				NVARCHAR(50)
AS
BEGIN

	IF(@cond = 'libres')
		BEGIN
		SELECT TU.turno_numero, TU.turno_fecha, TU.afiliado_numero, TU.prof_id, TU.cancelado, TU.habilitado, 
			   RIGHT('00'+CONVERT(NVARCHAR(2),DATEPART(HH, turno_fecha)),2) +  ':' + RIGHT('00'+CONVERT(NVARCHAR(2),DATEPART(MI, turno_fecha)),2) AS horas_minutos
		FROM gd_MORCIPAN.turnos TU
		LEFT JOIN gd_MORCIPAN.consultas_medicas CM ON CM.turno_numero = TU.turno_numero
		WHERE	TU.prof_id = @prof_id AND		
				DATEDIFF (DAY, TU.turno_fecha, @fecha) = 0 AND 
				DATEDIFF (MONTH, TU.turno_fecha, @fecha) = 0  AND
				DATEDIFF (YEAR, TU.turno_fecha, @fecha) = 0	AND
				TU.afiliado_numero IS NULL AND
				TU.habilitado = 1 AND CM.turno_numero is NULL
		END
	 
	IF(@cond = 'ocupados')
		BEGIN
		SELECT TU.turno_numero, TU.turno_fecha, TU.afiliado_numero, TU.prof_id, TU.cancelado, TU.habilitado, 
			   RIGHT('00'+CONVERT(NVARCHAR(2),DATEPART(HH, turno_fecha)),2) +  ':' + RIGHT('00'+CONVERT(NVARCHAR(2),DATEPART(MI, turno_fecha)),2) AS horas_minutos
		FROM gd_MORCIPAN.turnos TU
		LEFT JOIN gd_MORCIPAN.consultas_medicas CM ON CM.turno_numero = TU.turno_numero
		WHERE	TU.prof_id = @prof_id AND		
				DATEDIFF (DAY, TU.turno_fecha, @fecha) = 0 AND 
				DATEDIFF (MONTH, TU.turno_fecha, @fecha) = 0  AND
				DATEDIFF (YEAR, TU.turno_fecha, @fecha) = 0	AND
				TU.afiliado_numero IS NOT NULL AND
				TU.habilitado = 1 AND CM.turno_numero is NULL
		END

END
GO

/*	PROCEDURE: spDiaOcupadoAgenda
	DESCRIPCION: devuelve si el dia esta completo ocupado o no
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spDiaOcupadoAgenda')
	DROP PROCEDURE gd_MORCIPAN.spDiaOcupadoAgenda
GO
CREATE PROCEDURE gd_MORCIPAN.spDiaOcupadoAgenda
	@fecha				DATETIME,
	@prof_id			INT
AS
BEGIN

	IF EXISTS (SELECT * FROM gd_MORCIPAN.turnos WHERE prof_id = @prof_id
				AND DATEDIFF(YEAR,turno_fecha, @fecha) = 0
				AND DATEDIFF(MONTH,turno_fecha, @fecha) = 0
				AND DATEDIFF(DAY,turno_fecha, @fecha) = 0
				AND afiliado_numero is NULL)
		SELECT 0
	ELSE 
		SELECT 1

END
GO

/*	PROCEDURE: spCancelarTurnoAfiliado
	DESCRIPCION: cancela un turno
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spCancelarTurnoAfiliado')
	DROP PROCEDURE gd_MORCIPAN.spCancelarTurnoAfiliado
GO
CREATE PROCEDURE gd_MORCIPAN.spCancelarTurnoAfiliado
	@turno_numero		NUMERIC(18,0),
	@tipo_cance			NVARCHAR(50),
	@motivo				NVARCHAR(255)
AS
BEGIN

	UPDATE gd_MORCIPAN.turnos
	SET cancelado = 1, 
		afiliado_numero = NULL
	WHERE turno_numero = @turno_numero
	
	INSERT INTO gd_MORCIPAN.cancelacion_turnos 
	(turno_numero, tipo_cancelacion, cancelacion_motivo)
	VALUES 
	(@turno_numero, @tipo_cance, @motivo)

END
GO

/*	PROCEDURE: spCancelarTurnoProfesionalDia
	DESCRIPCION: cancela todos los turnos de un profesional para un dia dado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spCancelarTurnoProfesionalDia')
	DROP PROCEDURE gd_MORCIPAN.spCancelarTurnoProfesionalDia
GO
CREATE PROCEDURE gd_MORCIPAN.spCancelarTurnoProfesionalDia
	@prof_id		INT,
	@fecha			DATETIME,
	@tipo_canc		NVARCHAR(50),
	@motivo			NVARCHAR(255)
AS
BEGIN

	UPDATE gd_MORCIPAN.turnos
	SET cancelado = 1, habilitado = 0
	WHERE prof_id = @prof_id AND
	DATEDIFF (DAY, turno_fecha, @fecha) = 0 AND 
	DATEDIFF (MONTH, turno_fecha, @fecha) = 0  AND
	DATEDIFF (YEAR, turno_fecha, @fecha) = 0
	
	INSERT INTO gd_MORCIPAN.cancelacion_turnos (turno_numero, tipo_cancelacion, cancelacion_motivo)
	SELECT
	
	-- turno_numero	
	(SELECT TUR.turno_numero) AS turno_numero,
		
	-- tipo_cancelacion	
	(SELECT @tipo_canc) AS tipo_cancelacion,
		
	-- cancelacion motivo
	(SELECT @motivo) AS cancelacion_motivo
	
	FROM gd_MORCIPAN.turnos TUR
	WHERE prof_id = @prof_id AND
	DATEDIFF (DAY, turno_fecha, @fecha) = 0 AND 
	DATEDIFF (MONTH, turno_fecha, @fecha) = 0  AND
	DATEDIFF (YEAR, turno_fecha, @fecha) = 0 AND
	cancelado = 1 AND habilitado = 0
	
	SELECT COUNT (*) as 'Turnos Dados de Baja' FROM gd_MORCIPAN.turnos
	WHERE prof_id = @prof_id AND
	DATEDIFF (DAY, turno_fecha, @fecha) = 0 AND 
	DATEDIFF (MONTH, turno_fecha, @fecha) = 0  AND
	DATEDIFF (YEAR, turno_fecha, @fecha) = 0

END
GO

/*	PROCEDURE: trBajaLogicaProfesional
	DESCRIPCION: Da de Baja Logica a un profesional
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='trBajaLogicaProfesional')
	DROP TRIGGER gd_MORCIPAN.trBajaLogicaProfesional
GO
CREATE TRIGGER trBajaLogicaProfesional
ON gd_MORCIPAN.profesionales
FOR UPDATE 
AS 
BEGIN
SET NOCOUNT ON;

	-- se cancelan los turnos de hoy en adelante
	IF UPDATE (habilitado)
		BEGIN
		--PRINT 'lala'
		DECLARE @fecha DATETIME
		EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
		
		DECLARE @prof_id INT
		SELECT @prof_id = prof_id FROM INSERTED

		DECLARE @usuario_id INT
		SELECT @usuario_id = usuario_id FROM INSERTED
		
		UPDATE gd_MORCIPAN.turnos
		SET habilitado = 0
		WHERE prof_id = @prof_id AND
		turno_fecha >= @fecha
		
		SELECT COUNT (*) as 'Turnos Dados de Baja' FROM gd_MORCIPAN.turnos
		WHERE prof_id = @prof_id AND
		turno_fecha >= @fecha
		
		--se cancelan todas las consultas abiertas no finalizadas
		UPDATE consultas_medicas
		SET habilitada = 0
		FROM consultas_medicas CM
		JOIN gd_MORCIPAN.turnos TU ON TU.turno_numero = CM.turno_numero
		WHERE TU.prof_id = @prof_id AND
		CM.estado = 'ABIERTA'
		
		--se cancela la agenda del profesional
		/*UPDATE agendas_profesionales
		SET habilitada=0
		WHERE prof_id = @prof_id*/
		
		--se cancela el usuario
		UPDATE gd_MORCIPAN.usuarios
		SET habilitado = 0
		WHERE usuario_id = @usuario_id
		
	END
	
END
GO

/*	PROCEDURE: trBajaLogicaAfiliado
	DESCRIPCION: Da de Baja Logica a un afiliado, solo los turnos
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='trBajaLogicaAfiliado')
	DROP TRIGGER gd_MORCIPAN.trBajaLogicaAfiliado
GO
CREATE TRIGGER trBajaLogicaAfiliado
ON gd_MORCIPAN.afiliados
FOR UPDATE 
AS 
BEGIN
SET NOCOUNT ON;
 
	IF UPDATE (habilitado)
		BEGIN
		DECLARE @fecha DATETIME
		EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
		
		DECLARE @afiliado_numero INT
		SELECT @afiliado_numero = afiliado_numero FROM INSERTED
		
		DECLARE @usuario_id INT
		SELECT @usuario_id = usuario_id FROM INSERTED
		
		
		-- se liberan todos los turnos del afiliado
		UPDATE gd_MORCIPAN.turnos
		SET afiliado_numero = NULL
		WHERE afiliado_numero = @afiliado_numero AND
		turno_fecha >= @fecha
		
		-- se cancela el usuario
		UPDATE gd_MORCIPAN.usuarios
		SET habilitado = 0
		WHERE usuario_id = @usuario_id
		
	END
	
END
GO

/*	PROCEDURE: spListarConsultasMedicasAbiertasProfesionalDia
	DESCRIPCION: Lista las consultas abiertas de un profesional para determinado dia
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spListarConsultasMedicasAbiertasProfesionalDia')
	DROP PROCEDURE gd_MORCIPAN.spListarConsultasMedicasAbiertasProfesionalDia
GO
CREATE PROCEDURE gd_MORCIPAN.spListarConsultasMedicasAbiertasProfesionalDia
	@prof_id		INT,
	@fecha			DATETIME
AS
BEGIN

	SELECT CON.consulta_id, AFI.afiliado_numero, AFI.afiliado_nombre, AFI.afiliado_apellido 
	FROM gd_MORCIPAN.consultas_medicas CON
	JOIN gd_MORCIPAN.afiliados AFI ON AFI.afiliado_numero = CON.afiliado_numero
	JOIN gd_MORCIPAN.turnos TUR ON TUR.turno_numero = CON.turno_numero
	JOIN gd_MORCIPAN.profesionales PRO ON TUR.prof_id = PRO.prof_id
	WHERE PRO.prof_id = @prof_id AND
	DATEDIFF (DAY, CON.registro_llegada, @fecha) = 0 AND 
	DATEDIFF (MONTH, CON.registro_llegada, @fecha) = 0 AND
	DATEDIFF (YEAR, CON.registro_llegada, @fecha) = 0 AND
	CON.estado = 'ABIERTA'

END
GO

/*	PROCEDURE: spInsertarConsultaMedica
	DESCRIPCION: Inserta una nueva consulta medica a un afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spInsertarConsultaMedica')
	DROP PROCEDURE gd_MORCIPAN.spInsertarConsultaMedica
GO
CREATE PROCEDURE gd_MORCIPAN.spInsertarConsultaMedica
	@turno_numero			NUMERIC(18,0), 
	@afiliado_numero		INT, 
	@bono_consulta_numero	NUMERIC(18,0)		
AS
BEGIN

	-- fechaSitema
	DECLARE @fecha DATETIME
	EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema

	INSERT INTO gd_MORCIPAN.consultas_medicas 
		(turno_numero, afiliado_numero, bono_consulta_numero, estado, registro_llegada)
	VALUES
		(@turno_numero, @afiliado_numero, @bono_consulta_numero, 'ABIERTA', @fecha)

	-- actualizamos bono consulta usuario utilizo
	UPDATE gd_MORCIPAN.bonos_consulta
	SET afiliado_utilizo = @afiliado_numero --, habilitado = 0
	WHERE bono_consulta_numero = @bono_consulta_numero

END
GO

/*	PROCEDURE: spConfirmarConsultaMedica
	DESCRIPCION: Confirma la consulta medica por el doctor
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spConfirmarConsultaMedica')
	DROP PROCEDURE gd_MORCIPAN.spConfirmarConsultaMedica
GO
CREATE PROCEDURE gd_MORCIPAN.spConfirmarConsultaMedica
	@consulta_id			INT, 
	@estado					VARCHAR(50), 
	@registro_atencion		DATETIME,		
	@consulta_sintomas		VARCHAR(255),
	@consulta_enfermedades	VARCHAR(255)

AS
BEGIN
	UPDATE gd_MORCIPAN.consultas_medicas
	SET estado = @estado, registro_atencion = @registro_atencion,
	consulta_sintomas = @consulta_sintomas, consulta_enfermedades = @consulta_enfermedades
	WHERE consulta_id = @consulta_id
END
GO

/*	FUNCTION: fnVerificarBonoGrupoFamiliar
	DESCRIPCION: Devuelve si true/false si un bono lo puede utilizar un afiliado (Por grupo familiar)
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnVerificarBonoGrupoFamiliar')
	DROP FUNCTION gd_MORCIPAN.fnVerificarBonoGrupoFamiliar
GO
CREATE FUNCTION gd_MORCIPAN.fnVerificarBonoGrupoFamiliar(
	@afiliado_numero		INT,
	@bono_numero			NUMERIC(18,0),
	@bono_tipo				VARCHAR(50)
)
RETURNS BIT
AS
BEGIN

	DECLARE @afiliado_compra INT

	IF(@bono_tipo = 'FARMACIA')
		SELECT @afiliado_compra = afiliado_numero FROM gd_MORCIPAN.bonos_farmacia WHERE bono_farmacia_numero = @bono_numero
		
		
	IF(@bono_tipo = 'CONSULTA')
		SELECT @afiliado_compra = afiliado_numero FROM gd_MORCIPAN.bonos_consulta WHERE bono_consulta_numero = @bono_numero
		
		
	IF(@afiliado_compra = @afiliado_numero)
		RETURN 1	
	
	IF((ABS(@afiliado_compra - @afiliado_numero))<=98)	-- diferencia cantidad de afiliados dentro de un grupo
		RETURN 1
		
	RETURN 0

END	
GO

/*	PROCEDURE: spVerificarBonoValidoFarmacia
	DESCRIPCION: Verifica que el bono de farmacia este en condiciones para ser usado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spVerificarBonoValidoFarmacia')
	DROP PROCEDURE gd_MORCIPAN.spVerificarBonoValidoFarmacia
GO
CREATE PROCEDURE gd_MORCIPAN.spVerificarBonoValidoFarmacia
	@consulta_id			INT,
	@bono_numero			NUMERIC(18,0)
AS
BEGIN

	DECLARE @fecha DATETIME
	EXEC @fecha = GD2C2013.gd_MORCIPAN.fnDevolverFechaSistema
	DECLARE @fecha_venc DATETIME
	
	DECLARE @afiliado_numero INT
	SELECT @afiliado_numero = afiliado_numero FROM consultas_medicas
	WHERE consulta_id = @consulta_id

	-- bono valido grupo familiar
	DECLARE @res INT
	EXEC @res = GD2C2013.gd_MORCIPAN.fnVerificarBonoGrupoFamiliar @afiliado_numero, @bono_numero, 'FARMACIA'

	-- bono no vencido	
	IF(@res = 1)
		BEGIN
		SELECT @fecha_venc = bono_farmacia_fecha_vencimiento FROM gd_MORCIPAN.bonos_farmacia
		WHERE bono_farmacia_numero = @bono_numero
		
		IF(@fecha > @fecha_venc)
			SELECT 0
			
		ELSE
			SELECT 1
		
		END
		
	ELSE	
		SELECT 0

END
GO

/*	PROCEDURE: spInsertarCompraTotal
	DESCRIPCION: Registra la compra con la cantidad de bonos consulta/farmacia para un afiliado
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spInsertarCompraTotal')
	DROP PROCEDURE gd_MORCIPAN.spInsertarCompraTotal
GO
CREATE PROCEDURE gd_MORCIPAN.spInsertarCompraTotal
	@afiliado_numero		INT, 
	@cantiadad_bono_con		INT, 
	@cantiadad_bono_far		INT,	
	@monto_total			NUMERIC(18,2)

AS
BEGIN
	
	-- fechaSitema
	DECLARE @fecha DATETIME
	EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
	
	INSERT INTO gd_MORCIPAN.compras_bonos_afiliados 
			(compra_fecha, afiliado_numero, cantidad_bonos_con, cantidad_bonos_far, monto_total)
	VALUES
			(@fecha, @afiliado_numero, @cantiadad_bono_con, @cantiadad_bono_far, @monto_total)
			
END
GO

/*	PROCEDURE: spInsertarRecetaMedica
	DESCRIPCION: Inserta una nueva receta medica, la asocia a una consulta medica
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spInsertarRecetaMedica')
	DROP PROCEDURE gd_MORCIPAN.spInsertarRecetaMedica
GO
CREATE PROCEDURE gd_MORCIPAN.spInsertarRecetaMedica
	@consulta_id		INT
AS
BEGIN
	
	-- fechaSitema
	DECLARE @fecha DATETIME
	EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
	
	DECLARE @receta_id_res INT
	INSERT INTO gd_MORCIPAN.recetas_medicas (receta_fecha) VALUES (@fecha)
	SELECT @receta_id_res = SCOPE_IDENTITY()
	
	UPDATE gd_MORCIPAN.consultas_medicas
	SET receta_id = @receta_id_res
	WHERE consulta_id = @consulta_id
	
	SELECT @receta_id_res as receta_id
			
END
GO

/*	PROCEDURE: spAsociarRecetaBonosFarmaciaMedicamentos
	DESCRIPCION: Asocia una receta con un bono de farmacia junto con sus medicamentos
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spAsociarRecetaBonosFarmaciaMedicamentos')
	DROP PROCEDURE gd_MORCIPAN.spAsociarRecetaBonosFarmaciaMedicamentos
GO
CREATE PROCEDURE gd_MORCIPAN.spAsociarRecetaBonosFarmaciaMedicamentos
	@receta_id				INT,
	@consulta_id			INT,
	@bono_farmacia_numero	NUMERIC(18,0),
	@medicamento_id_1		INT,
	@cant_1					INT,	
	@medicamento_id_2		INT,
	@cant_2					INT,
	@medicamento_id_3		INT,
	@cant_3					INT,
	@medicamento_id_4		INT,
	@cant_4					INT,
	@medicamento_id_5		INT,
	@cant_5					INT,
	@fecha_prescrip_med		DATETIME
AS
BEGIN

	BEGIN TRY -- si quieren asociar un bono con un med mas de una vez
	INSERT INTO gd_MORCIPAN.bonosFarmacia_recetas (receta_id, bono_farmacia_numero)
	VALUES (@receta_id, @bono_farmacia_numero)
	
	DECLARE @afiliado_numero INT
	SELECT @afiliado_numero = afiliado_numero FROM gd_MORCIPAN.consultas_medicas WHERE consulta_id = @consulta_id
		
	UPDATE gd_MORCIPAN.bonos_farmacia
	SET afiliado_utilizo = @afiliado_numero,
	fecha_prescrip_med = @fecha_prescrip_med
	WHERE bono_farmacia_numero = @bono_farmacia_numero	
		
	IF(@cant_1 > 0)
		BEGIN
		INSERT INTO gd_MORCIPAN.bonosFarmacia_medicamentos (bono_farmacia_numero, medicamento_id, cantidad)
		VALUES
		(@bono_farmacia_numero, @medicamento_id_1, @cant_1)
		END
		
	IF(@cant_2 > 0)
		BEGIN
		INSERT INTO gd_MORCIPAN.bonosFarmacia_medicamentos (bono_farmacia_numero, medicamento_id, cantidad)
		VALUES
		(@bono_farmacia_numero, @medicamento_id_2, @cant_2)
		END
				
	IF(@cant_3 > 0)
		BEGIN
		INSERT INTO gd_MORCIPAN.bonosFarmacia_medicamentos (bono_farmacia_numero, medicamento_id, cantidad)
		VALUES
		(@bono_farmacia_numero, @medicamento_id_3, @cant_3)
		END
		
	IF(@cant_4 > 0)
		BEGIN
		INSERT INTO gd_MORCIPAN.bonosFarmacia_medicamentos (bono_farmacia_numero, medicamento_id, cantidad)
		VALUES
		(@bono_farmacia_numero, @medicamento_id_4, @cant_4)
		END
		
	IF(@cant_5 > 0)
		BEGIN
		INSERT INTO gd_MORCIPAN.bonosFarmacia_medicamentos (bono_farmacia_numero, medicamento_id, cantidad)
		VALUES
		(@bono_farmacia_numero, @medicamento_id_5, @cant_5)
		END
	END TRY
	
	BEGIN CATCH
	END CATCH
END
GO


/*	PROCEDURE: spListarMedicamentosLike
	DESCRIPCION: lista los medicamentos por like
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spListarMedicamentosLike')
	DROP PROCEDURE gd_MORCIPAN.spListarMedicamentosLike
GO
CREATE PROCEDURE gd_MORCIPAN.spListarMedicamentosLike
	@string			NVARCHAR(50)
AS
BEGIN
	
	IF(@string = '-4')
		SELECT * FROM gd_MORCIPAN.medicamentos

	ELSE
		BEGIN
		SELECT @string = '%' + RTRIM(@string) + '%';
		SELECT * FROM medicamentos
		WHERE medicamento_descp like @string
		END
END
GO

/*	PROCEDURE: spRegistroCambioPlanAfiliado 
	DESCRIPCION: registra en el sistema porque el cambio de plan
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spRegistroCambioPlanAfiliado')
	DROP PROCEDURE gd_MORCIPAN.spRegistroCambioPlanAfiliado
GO
CREATE PROCEDURE gd_MORCIPAN.spRegistroCambioPlanAfiliado
	@afiliado_numero		INT,
	@plan_descripcion_ant	VARCHAR(255),
	@plan_descripcion_act	VARCHAR(255),
	@cambio_motivo			NVARCHAR(255)
AS
BEGIN
	
	DECLARE @fecha DATETIME
	EXEC @fecha = GD2C2013.gd_MORCIPAN.fnDevolverFechaSistema
	
	DECLARE @plan_cod_ant NUMERIC(18,0)
	DECLARE @plan_cod_act NUMERIC(18,0)
	
	SELECT @plan_cod_ant = plan_codigo FROM gd_MORCIPAN.planes
	WHERE plan_descripcion = @plan_descripcion_ant

	SELECT @plan_cod_act = plan_codigo FROM gd_MORCIPAN.planes
	WHERE plan_descripcion = @plan_descripcion_act
	
	INSERT INTO gd_MORCIPAN.afiliados_cambios_planes
	(cambio_fecha_modificacion, afiliado_numero, plan_codigo_ant, plan_codigo_act, cambio_motivo)
	VALUES
	(@fecha, @afiliado_numero, @plan_cod_ant, @plan_cod_act,@cambio_motivo)
	
	UPDATE gd_MORCIPAN.afiliados
	SET afiliado_plan_medico_codigo = @plan_cod_act
	WHERE afiliado_numero = @afiliado_numero

END
GO

/*	PROCEDURE: spObtenerIdAfiliadoProfesionalPorUsuario 
	DESCRIPCION: devuelve el id de un afiliado/profesional segun su usuario_nombre
*/
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name = 'spObtenerIdAfiliadoProfesionalPorUsuario')
	DROP PROCEDURE gd_MORCIPAN.spObtenerIdAfiliadoProfesionalPorUsuario
GO
CREATE PROCEDURE gd_MORCIPAN.spObtenerIdAfiliadoProfesionalPorUsuario
	@usuario_nombre			VARCHAR(255),
	@rol_nombre				VARCHAR(255)
AS
BEGIN
	
	DECLARE @usuario_id INT
	SELECT @usuario_id = usuario_id FROM gd_MORCIPAN.usuarios
	WHERE usuario_nombre = @usuario_nombre
	
	IF(@rol_nombre = 'afiliado')
		BEGIN
		SELECT afiliado_numero FROM gd_MORCIPAN.afiliados
		WHERE usuario_id = @usuario_id
		END
	
	IF(@rol_nombre = 'profesional')
		BEGIN
		SELECT prof_id FROM gd_MORCIPAN.profesionales
		WHERE usuario_id = @usuario_id
		END
END
GO

--	*********************************************************
				/*	LISTADOS ESTADISTICOS	*/
--	*********************************************************


-- Top 5 de las especialidades que más se registraron cancelaciones, tanto de pacientes como de profesionales 
	
IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spListado1')
	DROP PROCEDURE gd_MORCIPAN.spListado1
GO
CREATE PROCEDURE gd_MORCIPAN.spListado1
	@inicio_semestre DATETIME,
	@fin_semestre DATETIME
AS

	DECLARE @mes1_nom	NVARCHAR(50)
	DECLARE @mes2_nom	NVARCHAR(50)
	DECLARE @mes3_nom	NVARCHAR(50)
	DECLARE @mes4_nom	NVARCHAR(50)
	DECLARE @mes5_nom	NVARCHAR(50)
	DECLARE @mes6_nom	NVARCHAR(50)
	
	DECLARE @mes2_date	DATETIME
	DECLARE @mes3_date	DATETIME
	DECLARE @mes4_date	DATETIME
	DECLARE @mes5_date	DATETIME
	DECLARE @mes6_date	DATETIME
	
	SELECT @mes2_date = DATEADD(MONTH,1,@inicio_semestre)
	SELECT @mes3_date = DATEADD(MONTH,2,@inicio_semestre)
	SELECT @mes4_date = DATEADD(MONTH,3,@inicio_semestre)
	SELECT @mes5_date = DATEADD(MONTH,4,@inicio_semestre)
	SELECT @mes6_date = DATEADD(MONTH,5,@inicio_semestre)
	
	SELECT @mes1_nom = DATENAME(MONTH, @inicio_semestre)
	SELECT @mes2_nom = DATENAME(MONTH, @mes2_date)
	SELECT @mes3_nom = DATENAME(MONTH, @mes3_date)
	SELECT @mes4_nom = DATENAME(MONTH, @mes4_date)
	SELECT @mes5_nom = DATENAME(MONTH, @mes5_date)
	SELECT @mes5_nom = DATENAME(MONTH, @mes6_date)
	
	DECLARE @sql NVARCHAR(3000)
	
	--SET @sql =
	SELECT TOP 5 ESP.especialidad_descrip AS Especialidad, ISNULL(COUNT (*),0) AS TurnosCancelados,
	GD2C2013.gd_MORCIPAN.fnCancelacionesEspecialidadMes(ESP.especialidad_descrip, @inicio_semestre) AS mes1,
	GD2C2013.gd_MORCIPAN.fnCancelacionesEspecialidadMes(ESP.especialidad_descrip, @mes2_date) AS mes2,
	GD2C2013.gd_MORCIPAN.fnCancelacionesEspecialidadMes(ESP.especialidad_descrip, @mes3_date) AS mes3,
	GD2C2013.gd_MORCIPAN.fnCancelacionesEspecialidadMes(ESP.especialidad_descrip, @mes4_date) AS mes4,
	GD2C2013.gd_MORCIPAN.fnCancelacionesEspecialidadMes(ESP.especialidad_descrip, @mes5_date) AS mes5,
	GD2C2013.gd_MORCIPAN.fnCancelacionesEspecialidadMes(ESP.especialidad_descrip, @mes6_date) AS mes6 
	FROM gd_MORCIPAN.especialidades ESP
	JOIN gd_MORCIPAN.especialidades_profesionales ESP_PRO ON ESP_PRO.especialidad_codigo = ESP.especialidad_codigo
	JOIN gd_MORCIPAN.profesionales PRO ON PRO.prof_id = ESP_PRO.prof_id
	JOIN gd_MORCIPAN.turnos TUR ON TUR.prof_id = PRO.prof_id
	WHERE ESP.habilitado = 1 AND
	(TUR.cancelado = 1 OR TUR.habilitado = 0) AND
	TUR.turno_fecha >= @inicio_semestre AND TUR.turno_fecha < @fin_semestre
	GROUP BY ESP.especialidad_descrip
	ORDER BY 2 DESC
	
	--EXEC sp_executesql @sql
GO

/*	FUNCTION: fnCancelacionesEspecialidadMes
	DESCRIPCION: Devuelve la cantidad de cancelaciones para una especialidad
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnCancelacionesEspecialidadMes')
	DROP FUNCTION gd_MORCIPAN.fnCancelacionesEspecialidadMes
GO
CREATE FUNCTION gd_MORCIPAN.fnCancelacionesEspecialidadMes(
	@especialidad_descrip	VARCHAR(255),
	@fecha					DATETIME
)
RETURNS INT
AS
BEGIN
		DECLARE @res INT
		SELECT @res = ISNULL(COUNT (*),0) FROM gd_MORCIPAN.turnos TUR
		JOIN gd_MORCIPAN.profesionales PRO ON TUR.prof_id = PRO.prof_id
		JOIN gd_MORCIPAN.especialidades_profesionales ESP_PRO ON ESP_PRO.prof_id = PRO.prof_id
		JOIN gd_MORCIPAN.especialidades ESP ON ESP.especialidad_codigo = ESP_PRO.especialidad_codigo
		WHERE 
		DATEDIFF (MONTH, TUR.turno_fecha, @fecha) = 0 AND 
		DATEDIFF (YEAR, TUR.turno_fecha, @fecha) = 0 AND
		(TUR.cancelado = 1 OR TUR.habilitado = 0) AND
		ESP.especialidad_descrip = @especialidad_descrip AND
		ESP.habilitado = 1
		RETURN @res

END	
GO


-- Top 5 de la cantidad total de bonos farmacia vencidos por afiliado.

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spListado2')
	DROP PROCEDURE gd_MORCIPAN.spListado2
GO
CREATE PROCEDURE gd_MORCIPAN.spListado2
	@inicio_semestre DATETIME,
	@fin_semestre DATETIME
AS

	DECLARE @mes1_nom	NVARCHAR(50)
	DECLARE @mes2_nom	NVARCHAR(50)
	DECLARE @mes3_nom	NVARCHAR(50)
	DECLARE @mes4_nom	NVARCHAR(50)
	DECLARE @mes5_nom	NVARCHAR(50)
	DECLARE @mes6_nom	NVARCHAR(50)
	
	DECLARE @mes2_date	DATETIME
	DECLARE @mes3_date	DATETIME
	DECLARE @mes4_date	DATETIME
	DECLARE @mes5_date	DATETIME
	DECLARE @mes6_date	DATETIME
	
	SELECT @mes2_date = DATEADD(MONTH,1,@inicio_semestre)
	SELECT @mes3_date = DATEADD(MONTH,2,@inicio_semestre)
	SELECT @mes4_date = DATEADD(MONTH,3,@inicio_semestre)
	SELECT @mes5_date = DATEADD(MONTH,4,@inicio_semestre)
	SELECT @mes6_date = DATEADD(MONTH,5,@inicio_semestre)
	
	SELECT @mes1_nom = DATENAME(MONTH, @inicio_semestre)
	SELECT @mes2_nom = DATENAME(MONTH, @mes2_date)
	SELECT @mes3_nom = DATENAME(MONTH, @mes3_date)
	SELECT @mes4_nom = DATENAME(MONTH, @mes4_date)
	SELECT @mes5_nom = DATENAME(MONTH, @mes5_date)
	SELECT @mes5_nom = DATENAME(MONTH, @mes6_date)
	
	-- fechaSitema
	DECLARE @fecha DATETIME
	EXEC @fecha = gd_MORCIPAN.fnDevolverFechaSistema
	
	SELECT TOP 5 AFI.afiliado_numero, ISNULL(COUNT (*),0) AS Bonos_Vencidos,
	GD2C2013.gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado(AFI.afiliado_numero, @inicio_semestre) AS mes1,
	GD2C2013.gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado(AFI.afiliado_numero, @mes2_date) AS mes2,
	GD2C2013.gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado(AFI.afiliado_numero, @mes3_date) AS mes3,
	GD2C2013.gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado(AFI.afiliado_numero, @mes4_date) AS mes4,
	GD2C2013.gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado(AFI.afiliado_numero, @mes5_date) AS mes5,
	GD2C2013.gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado(AFI.afiliado_numero, @mes6_date) AS mes6 
	FROM gd_MORCIPAN.afiliados AFI
	JOIN gd_MORCIPAN.bonos_farmacia BF ON AFI.afiliado_numero = BF.afiliado_numero
	WHERE AFI.habilitado = 1 AND --BF.habilitado = 1 AND, habilitado 0 porque estan usados 
	BF.bono_compra_fecha >= @inicio_semestre AND BF.bono_compra_fecha < @fin_semestre AND
	BF.bono_farmacia_fecha_vencimiento < @fecha
	GROUP BY AFI.afiliado_numero
	ORDER BY 2 DESC
	
GO

/*	FUNCTION: fnVencimientoPorMesBonosAfiliado
	DESCRIPCION: Devuelve la cantidad de bonos vencidos por afiliado en un determinado mes
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnVencimientoPorMesBonosAfiliado')
	DROP FUNCTION gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado
GO
CREATE FUNCTION gd_MORCIPAN.fnVencimientoPorMesBonosAfiliado(
	@afiliado_numero		INT,
	@fecha					DATETIME
)
RETURNS INT
AS
BEGIN
		DECLARE @res INT

		-- fechaSitema
		DECLARE @fechaSis DATETIME
		EXEC @fechaSis = gd_MORCIPAN.fnDevolverFechaSistema

		SELECT @res = ISNULL(COUNT (*),0) FROM gd_MORCIPAN.bonos_farmacia BF
		JOIN gd_MORCIPAN.afiliados AFI ON AFI.afiliado_numero = BF.afiliado_numero
		WHERE AFI.habilitado = 1 AND
		DATEDIFF (MONTH, BF.bono_compra_fecha, @fecha) = 0 AND 
		DATEDIFF (YEAR, BF.bono_compra_fecha, @fecha) = 0 AND
		BF.bono_farmacia_fecha_vencimiento < @fechaSis AND
		AFI.afiliado_numero = @afiliado_numero
		RETURN @res

END	
GO


-- Top 5 de las especialidades de médicos con más bonos de farmacia recetados.

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spListado3')
	DROP PROCEDURE gd_MORCIPAN.spListado3
GO
CREATE PROCEDURE gd_MORCIPAN.spListado3
	@inicio_semestre DATETIME,
	@fin_semestre DATETIME
AS

	DECLARE @mes1_nom	NVARCHAR(50)
	DECLARE @mes2_nom	NVARCHAR(50)
	DECLARE @mes3_nom	NVARCHAR(50)
	DECLARE @mes4_nom	NVARCHAR(50)
	DECLARE @mes5_nom	NVARCHAR(50)
	DECLARE @mes6_nom	NVARCHAR(50)
	
	DECLARE @mes2_date	DATETIME
	DECLARE @mes3_date	DATETIME
	DECLARE @mes4_date	DATETIME
	DECLARE @mes5_date	DATETIME
	DECLARE @mes6_date	DATETIME
	
	SELECT @mes2_date = DATEADD(MONTH,1,@inicio_semestre)
	SELECT @mes3_date = DATEADD(MONTH,2,@inicio_semestre)
	SELECT @mes4_date = DATEADD(MONTH,3,@inicio_semestre)
	SELECT @mes5_date = DATEADD(MONTH,4,@inicio_semestre)
	SELECT @mes6_date = DATEADD(MONTH,5,@inicio_semestre)
	
	SELECT @mes1_nom = DATENAME(MONTH, @inicio_semestre)
	SELECT @mes2_nom = DATENAME(MONTH, @mes2_date)
	SELECT @mes3_nom = DATENAME(MONTH, @mes3_date)
	SELECT @mes4_nom = DATENAME(MONTH, @mes4_date)
	SELECT @mes5_nom = DATENAME(MONTH, @mes5_date)
	SELECT @mes5_nom = DATENAME(MONTH, @mes6_date)
	
	SELECT TOP 5 ESP.especialidad_descrip AS Especialidad, ISNULL(COUNT (*),0) AS BonosFarmaciasRecetados,
	GD2C2013.gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes(ESP.especialidad_descrip, @inicio_semestre) AS mes1,
	GD2C2013.gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes(ESP.especialidad_descrip, @mes2_date) AS mes2,
	GD2C2013.gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes(ESP.especialidad_descrip, @mes3_date) AS mes3,
	GD2C2013.gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes(ESP.especialidad_descrip, @mes4_date) AS mes4,
	GD2C2013.gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes(ESP.especialidad_descrip, @mes5_date) AS mes5,
	GD2C2013.gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes(ESP.especialidad_descrip, @mes6_date) AS mes6 
	FROM gd_MORCIPAN.especialidades ESP
	LEFT JOIN gd_MORCIPAN.especialidades_profesionales ESP_PRO ON ESP_PRO.especialidad_codigo = ESP.especialidad_codigo
	LEFT JOIN gd_MORCIPAN.profesionales PRO ON PRO.prof_id = ESP_PRO.prof_id
	LEFT JOIN gd_MORCIPAN.turnos TUR ON TUR.prof_id = PRO.prof_id
	LEFT JOIN gd_MORCIPAN.consultas_medicas CM ON CM.turno_numero = TUR.turno_numero
	LEFT JOIN gd_MORCIPAN.recetas_medicas RM ON CM.receta_id = RM.receta_id
	LEFT JOIN gd_MORCIPAN.bonosFarmacia_recetas BFR ON BFR.receta_id = RM.receta_id
	LEFT JOIN gd_MORCIPAN.bonos_farmacia BF ON BFR.bono_farmacia_numero = BF.bono_farmacia_numero	
	WHERE ESP.habilitado = 1 AND
	CM.registro_llegada >= @inicio_semestre AND CM.registro_llegada < @fin_semestre
	GROUP BY ESP.especialidad_descrip
	ORDER BY 2 DESC

GO


/*	FUNCTION: fnEspecialidadesBonosFarmaciaRecetasPorMes
	DESCRIPCION: Devuelve la cantidad de bonos vencidos por afiliado en un determinado mes
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnEspecialidadesBonosFarmaciaRecetasPorMes')
	DROP FUNCTION gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes
GO
CREATE FUNCTION gd_MORCIPAN.fnEspecialidadesBonosFarmaciaRecetasPorMes(
	@especialidad_descrip	VARCHAR(255),
	@fecha					DATETIME
)
RETURNS INT
AS
BEGIN
		DECLARE @res INT

		SELECT @res = ISNULL(COUNT (*),0) FROM gd_MORCIPAN.bonos_farmacia BF
		LEFT JOIN gd_MORCIPAN.bonosFarmacia_recetas BFR ON BFR.bono_farmacia_numero = BF.bono_farmacia_numero		
		LEFT JOIN gd_MORCIPAN.recetas_medicas RM ON RM.receta_id = BFR.receta_id
		LEFT JOIN gd_MORCIPAN.consultas_medicas CM ON RM.receta_id = CM.receta_id		
		LEFT JOIN gd_MORCIPAN.turnos TUR ON CM.turno_numero = TUR.turno_numero
		LEFT JOIN gd_MORCIPAN.profesionales PRO ON TUR.prof_id = PRO.prof_id
		LEFT JOIN gd_MORCIPAN.especialidades_profesionales ESP_PRO ON PRO.prof_id = ESP_PRO.prof_id
		LEFT JOIN gd_MORCIPAN.especialidades ESP ON ESP_PRO.especialidad_codigo = ESP.especialidad_codigo
		WHERE ESP.habilitado = 1 AND
		ESP.especialidad_descrip = @especialidad_descrip AND 
		DATEDIFF (MONTH, CM.registro_llegada, @fecha) = 0 AND 
		DATEDIFF (YEAR, CM.registro_llegada, @fecha) = 0
		RETURN @res

END	
GO


-- Top 10 de los afiliados que utilizaron bonos que ellos mismo no compraron

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='spListado4')
	DROP PROCEDURE gd_MORCIPAN.spListado4
GO
CREATE PROCEDURE gd_MORCIPAN.spListado4
	@inicio_semestre DATETIME,
	@fin_semestre DATETIME
AS
BEGIN
	
	DECLARE @mes2_date	DATETIME
	DECLARE @mes3_date	DATETIME
	DECLARE @mes4_date	DATETIME
	DECLARE @mes5_date	DATETIME
	DECLARE @mes6_date	DATETIME
	
	SELECT @mes2_date = DATEADD(MONTH,1,@inicio_semestre)
	SELECT @mes3_date = DATEADD(MONTH,2,@inicio_semestre)
	SELECT @mes4_date = DATEADD(MONTH,3,@inicio_semestre)
	SELECT @mes5_date = DATEADD(MONTH,4,@inicio_semestre)
	SELECT @mes6_date = DATEADD(MONTH,5,@inicio_semestre)


	DECLARE @tmp_aux TABLE (
		afiliado_numero				INT
	)

	DECLARE @tmp TABLE (
	
		afiliado_numero				INT,
		CantidadBonosNoComprados	INT,
		mes1						INT,
		mes2						INT,
		mes3						INT,
		mes4						INT,			
		mes5						INT,
		mes6						INT
	)	
	
	-- bonos consulta
	INSERT INTO @tmp_aux (afiliado_numero)
	SELECT BC.afiliado_utilizo FROM gd_MORCIPAN.bonos_consulta BC
	JOIN gd_MORCIPAN.consultas_medicas CM ON  BC.bono_consulta_numero = CM.bono_consulta_numero
	WHERE BC.afiliado_numero != BC.afiliado_utilizo AND
	CM.registro_llegada >= @inicio_semestre AND CM.registro_llegada < @fin_semestre
	
	-- bonos farmacia
	INSERT INTO @tmp_aux (afiliado_numero)
	SELECT BF.afiliado_utilizo FROM gd_MORCIPAN.bonos_farmacia BF
	JOIN gd_MORCIPAN.bonosFarmacia_recetas BFR ON BF.bono_farmacia_numero = BFR.bono_farmacia_numero
	JOIN gd_MORCIPAN.recetas_medicas RM ON BFR.receta_id = RM.receta_id
	JOIN gd_MORCIPAN.consultas_medicas CM ON CM.receta_id = RM.receta_id
	WHERE BF.afiliado_numero != BF.afiliado_utilizo AND
	CM.registro_llegada >= @inicio_semestre AND CM.registro_llegada < @fin_semestre		
	
	INSERT INTO @tmp (afiliado_numero)
	SELECT DISTINCT afiliado_numero FROM @tmp_aux
	
	DECLARE tmpCursor CURSOR FOR
		SELECT afiliado_numero FROM @tmp
		DECLARE @afiliado_numero INT, @mes1 INT, @mes2 INT, @mes3 INT, @mes4 INT, @mes5 INT, @mes6 INT
		
		OPEN tmpCursor;
		FETCH NEXT FROM tmpCursor INTO @afiliado_numero
			WHILE @@FETCH_STATUS = 0
				BEGIN

				SET @mes1 = GD2C2013.gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes(@afiliado_numero, @inicio_semestre)
				SET @mes2 = GD2C2013.gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes(@afiliado_numero, @mes2_date)
				SET @mes3 = GD2C2013.gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes(@afiliado_numero, @mes3_date)
				SET @mes4 = GD2C2013.gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes(@afiliado_numero, @mes4_date)
				SET @mes5 = GD2C2013.gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes(@afiliado_numero, @mes5_date)
				SET @mes6 = GD2C2013.gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes(@afiliado_numero, @mes6_date)
	
				UPDATE @tmp
				SET 
				mes1 = @mes1,
				mes2 = @mes2,
				mes3 = @mes3,
				mes4 = @mes4,
				mes5 = @mes5,
				mes6 = @mes6,
				CantidadBonosNoComprados = @mes1 + @mes2 + @mes3 + @mes4 + @mes5 + @mes6
				WHERE current of tmpCursor
				FETCH NEXT FROM tmpCursor INTO @afiliado_numero
				END;
		CLOSE tmpCursor;
		DEALLOCATE tmpCursor;
	
	SELECT * FROM @tmp

END
GO

/*	FUNCTION: fnCantidadDeBonosNoCompradosUsadosPorMes
	DESCRIPCION: Devuelve la cantidad de bonos utilizados no comprados por mes
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnCantidadDeBonosNoCompradosUsadosPorMes')
	DROP FUNCTION gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes
GO
CREATE FUNCTION gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorMes(
	@afiliado_numero		INT,
	@fecha					DATETIME
)
RETURNS INT
AS
BEGIN
		DECLARE @res INT
		
		SELECT @res = ISNULL(COUNT (*),0) FROM gd_MORCIPAN.bonos_consulta BC
		JOIN gd_MORCIPAN.consultas_medicas CM ON  BC.bono_consulta_numero = CM.bono_consulta_numero
		WHERE BC.afiliado_numero != @afiliado_numero AND BC.afiliado_utilizo = @afiliado_numero AND
		DATEDIFF (MONTH, CM.registro_llegada, @fecha) = 0 AND
		DATEDIFF (YEAR, CM.registro_llegada, @fecha) = 0 		
		
		SELECT @res+= ISNULL(COUNT (*),0) FROM gd_MORCIPAN.bonos_farmacia BF
		JOIN gd_MORCIPAN.bonosFarmacia_recetas BFR ON BF.bono_farmacia_numero = BFR.bono_farmacia_numero
		JOIN gd_MORCIPAN.recetas_medicas RM ON BFR.receta_id = RM.receta_id
		JOIN gd_MORCIPAN.consultas_medicas CM ON CM.receta_id = RM.receta_id
		WHERE BF.afiliado_numero != @afiliado_numero AND BF.afiliado_utilizo = @afiliado_numero AND
		DATEDIFF (MONTH, CM.registro_llegada, @fecha) = 0 AND
		DATEDIFF (YEAR, CM.registro_llegada, @fecha) = 0 		
		
		RETURN @res

END	
GO

/*	FUNCTION: fnCantidadDeBonosNoCompradosUsadosPorSemestre
	DESCRIPCION: Devuelve la cantidad de bonos utilizados no comprados por semestre
*/

IF EXISTS (SELECT id FROM sys.sysobjects WHERE name='fnCantidadDeBonosNoCompradosUsadosPorSemestre')
	DROP FUNCTION gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorSemestre
GO
CREATE FUNCTION gd_MORCIPAN.fnCantidadDeBonosNoCompradosUsadosPorSemestre(
	@afiliado_numero		INT,
	@inicio_semestre DATETIME,
	@fin_semestre DATETIME
)
RETURNS INT
AS
BEGIN
		DECLARE @res INT
		
		SELECT @res = ISNULL(COUNT (*),0) FROM gd_MORCIPAN.bonos_consulta BC
		JOIN gd_MORCIPAN.consultas_medicas CM ON  BC.bono_consulta_numero = CM.bono_consulta_numero
		WHERE BC.afiliado_numero != @afiliado_numero AND BC.afiliado_utilizo = @afiliado_numero AND
		CM.registro_llegada >= @inicio_semestre AND CM.registro_llegada < @fin_semestre
		
		SELECT @res+= ISNULL(COUNT (*),0) FROM gd_MORCIPAN.bonos_farmacia BF
		JOIN gd_MORCIPAN.bonosFarmacia_recetas BFR ON BF.bono_farmacia_numero = BFR.bono_farmacia_numero
		JOIN gd_MORCIPAN.recetas_medicas RM ON BFR.receta_id = RM.receta_id
		JOIN gd_MORCIPAN.consultas_medicas CM ON CM.receta_id = RM.receta_id
		WHERE BF.afiliado_numero != @afiliado_numero AND BF.afiliado_utilizo = @afiliado_numero AND
		CM.registro_llegada >= @inicio_semestre AND CM.registro_llegada < @fin_semestre	
		
		RETURN @res

END	
GO