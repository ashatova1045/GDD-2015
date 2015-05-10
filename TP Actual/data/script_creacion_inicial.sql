USE GD1C2015

BEGIN /* *************** CREACION DEL SCHENMA *************** */
	IF NOT EXISTS (SELECT [name] FROM [sys].[schemas] WHERE [name] = 'HHHH')
		EXECUTE ('CREATE SCHEMA HHHH AUTHORIZATION gd;');
END
GO

BEGIN /* *************** BORRADO DE CONSTRAINTS *************** */

	--Creamos una tabla temporal para las FOREIGN KEY
	CREATE TABLE temporal(
	ID int identity(1,1),
	nombre sysname,
	tabla sysname,
	schem nvarchar(128)
	)
	--Insertamos las CONSTRAINT de tipo FOREIGN KEY en la tabla
	INSERT INTO temporal(nombre,tabla,schem)
		(SELECT CONSTRAINT_NAME, TABLE_NAME, TABLE_SCHEMA
		FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		WHERE CONSTRAINT_TYPE = 'FOREIGN KEY' and
		TABLE_SCHEMA = 'HHHH')


	DECLARE @Contador INT           -- Variable contador
	SET @Contador = 1   
	DECLARE @Regs INT               -- Variable para el Numero de Registros a procesar
	SET @Regs = (SELECT COUNT(*) FROM temporal) --Obtenemos la cantidad de registros a procesar
								
	DECLARE @nombre VARCHAR(50)
	DECLARE @tabla VARCHAR(50)
	DECLARE @schemaa VARCHAR(50)
 
	-- Hacemos el Loop
	WHILE @Contador <= @Regs
		BEGIN
			SELECT @nombre= t.nombre, @tabla = t.tabla, @schemaa = t.schem
			FROM temporal t
			WHERE t.ID = @Contador
 
			-- Borramos el CONSTRAINT de la tabla
			PRINT 'Borrando la CONSTRAINT '+@nombre+' de la tabla '+@schemaa+'.'+@tabla
			EXEC('ALTER TABLE '+@schemaa+'.'+@tabla+' DROP CONSTRAINT '+@nombre);
			SET @Contador = @Contador + 1
 
		END								
	DROP TABLE temporal
		
END

BEGIN /* *************** BORRADO DE TABLAS *************** */

	--Creamos una tabla temporal para las tablas de nuestro schema
	CREATE TABLE temporal(
	ID int identity(1,1),
	tabla sysname,
	schem nvarchar(128)
	)
	
	--Insertamos las tablas que contiene el schema
	INSERT INTO temporal(tabla,schem)
		(SELECT DISTINCT TABLE_NAME, TABLE_SCHEMA
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_SCHEMA = 'HHHH')


	--DECLARE @Contador INT           -- Variable contador
	SET @Contador = 1   
	--DECLARE @Regs INT               -- Variable para el Numero de Registros a procesar
	SET @Regs = (SELECT COUNT(*) FROM temporal) --Obtenemos la cantidad de registros a procesar
							
	--DECLARE @tabla VARCHAR(50)
	--DECLARE @schemaa VARCHAR(50)
 
	-- Hacemos el Loop
	WHILE @Contador <= @Regs
		BEGIN
			SELECT @tabla = t.tabla, @schemaa = t.schem
			FROM temporal t
			WHERE t.ID = @Contador
 
			-- Borramos la tabla de schema
			Print 'Borrando la tabla '+@schemaa+'.'+@tabla
			EXEC('DROP TABLE '+@schemaa+'.'+@tabla);
			SET @Contador = @Contador + 1
		END
										
	DROP TABLE temporal
END
GO

BEGIN /* *************** CREACION DE TABLAS *************** */
	CREATE TABLE HHHH.usuarios(
		id_usuario numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		usuario NVARCHAR(30) UNIQUE,
		contrasena CHAR(44) NOT NULL,
		intentosFallidos INT DEFAULT 0,
		estado NVARCHAR DEFAULT 'H' CHECK (estado IN ('H','I','B')) -- habilitado, inhabilitado, baja
	)
	
	CREATE TABLE HHHH.paises(
		Codigo numeric(18,0) Primary key,
		Descripcion varchar(250) unique
	)
	
	CREATE TABLE HHHH.clientes( 
		Id_cliente numeric(18,0) IDENTITY(1,1) primary key,
		Id_usuario numeric(18,0) /*unique */CONSTRAINT FK_clientes_usuario FOREIGN KEY REFERENCES HHHH.usuarios(id_usuario),
		Nombre varchar(255)not null,
		Apellido varchar(255)not null,
		Nro_Documento numeric(18,0)not null,
		Id_tipo_documento int not null, --tabla tipo documentos?
		Mail varchar(255) not null,
		Id_pais numeric(18,0) not null CONSTRAINT FK_clientes_pais FOREIGN KEY REFERENCES HHHH.paises (Codigo),
		Altura int,
		Calle varchar(255),
		Piso int,
		Departamento varchar(10),
		Localidad varchar(255),
		Id_nacionalidad numeric(18,0) CONSTRAINT FK_clientes_nacionalidad FOREIGN KEY REFERENCES HHHH.paises (Codigo),
		Fecha_nacimiento datetime,
		Estado NVARCHAR DEFAULT 'H' CHECK (estado IN ('H','I')) -- habilitado, inhabilitado
	)

	CREATE TABLE HHHH.cuentas(
		Id_cuenta numeric(18,0) primary key,
		Id_pais numeric(18,0) CONSTRAINT FK_cuentas_pais FOREIGN KEY REFERENCES HHHH.paises(Codigo),
		Id_moneda numeric(18,0),
		Fecha_apertura datetime,
		Id_tipo_cuenta numeric(18,0),
		Id_cliente numeric(18,0) not null CONSTRAINT FK_cuentas_cliente FOREIGN KEY REFERENCES HHHH.clientes(Id_cliente),
		Estado NVARCHAR DEFAULT 'P' CHECK (estado IN ('P','C','H','I')), -- pend act, cerrada, habilida, inhabilitada
		Saldo numeric(18,0)
	)
	
	CREATE TABLE HHHH.tarjetas(
		Id_tarjeta numeric(18,0) identity(1,1) primary key,
		Numero varchar(16) unique,
		Id_banco numeric(18,0) default 1 /*CONSTRAINT FK_tarjetas_banco FOREIGN KEY REFERENCES HHHH.bancos (Id_baco)*/, --Colocar banco migracion
		Fecha_emision datetime,
		Fecha_vencimiento datetime,
		Codigo_seguridad varchar(3),
		Id_cliente numeric(18,0) CONSTRAINT FK_tarjetas_cliente FOREIGN KEY REFERENCES HHHH.clientes (Id_cliente)
	)
	
	CREATE TABLE HHHH.depositos(
		Id_deposito numeric(18,0) primary key,
		Id_cuenta numeric(18,0) not null CONSTRAINT FK_depositos_cuenta FOREIGN KEY REFERENCES HHHH.cuentas (Id_cuenta),
		Importe numeric(18,2)not null,
		Id_tipo_moneda int,
		Id_tarjeta numeric(18,0) CONSTRAINT FK_depositos_tarjeta FOREIGN KEY REFERENCES HHHH.tarjetas (Id_tarjeta),
		Fecha_deposito datetime
	)

	CREATE TABLE HHHH.logins(
		id_usuario numeric(18,0) CONSTRAINT FK_logins_usuario FOREIGN KEY REFERENCES HHHH.usuarios(id_usuario),
		fecha DATETIME,
		exito BIT,
		numeroDeFallo INT,
		PRIMARY KEY (id_usuario,fecha)
	)
 --CREATE TABLE HHHH.roles(		--Ely
	--)
	
	--CREATE TABLE HHHH.Retiros(	--Ely
	--)
	
	--CREATE TABLE HHHH.Tipos_Documentos(	--Ely
	--)
	
	--CREATE TABLE HHHH.Rel_Rol_Usuario)	--Ely
	--)
	
	--CREATE TABLE HHHH.Bancos(	--Ely
	--)
	
	--CREATE TABLE HHHH.Funcionalidades(		--Ana
	--)

	--CREATE TABLE HHHH.Transferencias(	--Ana
	--)
	
	--CREATE TABLE HHHH.Cheques(	--Ana
	--)
	
	--CREATE TABLE HHHH.Rel_Rol_Funcionalidad(	--Ana
	--)
	
	--CREATE TABLE HHHH.Tipo_Cuenta(	--Ana
	--)
	
	--CREATE TABLE HHHH.Facturas(	--Marian
	--)
	
	--CREATE TABLE HHHH.Movimientos(	--Marian
	--)
	
	--CREATE TABLE HHHH.Monedas(	--Marian
	--)
END
GO

BEGIN /* *************** MIGRACION *************** */
	INSERT INTO HHHH.usuarios (usuario,contrasena)
		VALUES ('admin','5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=');
		
	INSERT INTO HHHH.paises(Codigo,Descripcion)
		SELECT DISTINCT Cli_Pais_Codigo, Cli_Pais_Desc
		FROM gd_esquema.Maestra
	UNION
		SELECT DISTINCT Cuenta_Pais_Codigo, Cuenta_Pais_Desc
		FROM gd_esquema.Maestra
		
	INSERT INTO HHHH.clientes(Id_pais, Nombre, Apellido, Id_tipo_documento, Mail,
				 Altura, Calle, Piso, Departamento, Fecha_nacimiento, Nro_Documento)
		SELECT  DISTINCT Cli_Pais_Codigo, Cli_Nombre, Cli_Apellido, 
			Cli_Tipo_Doc_Cod, Cli_Mail,
			Cli_Dom_Nro, Cli_Dom_Calle,
			Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, 
			Cli_Nro_Doc 
		FROM gd_esquema.Maestra

	INSERT INTO HHHH.cuentas(Id_cuenta, Id_pais, Fecha_apertura, Id_cliente)
		SELECT DISTINCT M.Cuenta_Numero, M.Cuenta_Pais_Codigo, M.Cuenta_Fecha_Creacion, 
				C.Id_cliente
		FROM gd_esquema.Maestra M, HHHH.clientes C
		WHERE C.Mail = M.Cli_Mail
		
	INSERT INTO HHHH.tarjetas(Numero, Fecha_emision, Fecha_vencimiento, Codigo_seguridad, Id_cliente)
		SELECT distinct T.Tarjeta_Numero, T.Tarjeta_Fecha_Emision, T.Tarjeta_Fecha_Vencimiento,
			T.Tarjeta_Codigo_Seg, C.id_cliente
		FROM (SELECT DISTINCT Tarjeta_Numero, Tarjeta_Fecha_Emision,
							Tarjeta_Fecha_Vencimiento, Tarjeta_Codigo_Seg, Cuenta_Numero
			  FROM gd_esquema.Maestra
			  WHERE Tarjeta_Numero is not null) T , HHHH.cuentas C
		WHERE T.Cuenta_Numero = C.id_cuenta
		
	INSERT INTO HHHH.depositos(Id_deposito, Id_cuenta, Importe, Id_tarjeta, Fecha_deposito )
		SELECT DISTINCT Deposito_Codigo, Cuenta_Numero, Deposito_Importe, 
				T.Id_tarjeta, Deposito_Fecha
		FROM gd_esquema.Maestra M, HHHH.tarjetas T
		WHERE M.Deposito_Codigo is not null and M.Tarjeta_Numero = T.Numero

END
GO

BEGIN /* *************** BORRADO DE STORED PROCEDURES *************** */
	IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='loginProc')
		DROP PROCEDURE HHHH.loginProc;
END
GO

/* *************** CREACION DE STORED PROCEDURES *************** */
CREATE PROCEDURE HHHH.loginProc
    @usu nvarchar(30), 
    @contra char(44)
AS 
	DECLARE @id_usuario INT
	
	SET @id_usuario = (SELECT id_usuario FROM HHHH.usuarios WHERE usuario = @usu AND estado != 'B')
	IF @id_usuario IS NULL
		BEGIN
			RAISERROR ('No existe ese usuario',16,1)
			RETURN
		END
		
	IF (SELECT estado FROM HHHH.usuarios WHERE id_usuario = @id_usuario) = 'I'
		BEGIN
			RAISERROR ('Este usuario esta inhabilitado. Contacte a un administrador del sistema.',16,1)
			RETURN
		END
	
	IF (SELECT contrasena FROM HHHH.usuarios WHERE id_usuario = @id_usuario) = @contra
		BEGIN
			INSERT INTO HHHH.logins (id_usuario, fecha, exito,numeroDeFallo)
				VALUES (@id_usuario,GETDATE(),1,0)
			UPDATE HHHH.usuarios
				SET intentosFallidos = 0
				WHERE id_usuario = @id_usuario
			SELECT @id_usuario			 --devuelvo el numero de usuario para agregarlo a la sesion
		END
	ELSE
		BEGIN	
			UPDATE HHHH.usuarios
				SET intentosFallidos = intentosFallidos + 1
				WHERE id_usuario = @id_usuario
				
			INSERT INTO HHHH.logins (id_usuario, fecha, exito,numeroDeFallo)
				VALUES (@id_usuario,GETDATE(),0,(SELECT intentosFallidos FROM HHHH.usuarios WHERE id_usuario = @id_usuario))
					
			RAISERROR ('Contrasena incorrecta.',16,1)
			
			IF (SELECT intentosFallidos FROM HHHH.usuarios WHERE id_usuario = @id_usuario) = 3
				BEGIN
					RAISERROR ('Ha introducido su contrasena mal 3 veces, por lo que su cuenta se ha inhabilitado. Contacte a un administrador del sistema.',16,1)
					UPDATE HHHH.usuarios
						SET estado = 'I'
						WHERE id_usuario = @id_usuario
				END
			RETURN
		END
GO