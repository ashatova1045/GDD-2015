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
--			PRINT 'Borrando la CONSTRAINT '+@nombre+' de la tabla '+@schemaa+'.'+@tabla
			EXEC('ALTER TABLE '+@schemaa+'.'+@tabla+' DROP CONSTRAINT '+@nombre);
			SET @Contador = @Contador + 1
 
		END								
	DROP TABLE temporal
		
END
GO

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


	DECLARE @Contador INT           -- Variable contador
	SET @Contador = 1   
	DECLARE @Regs INT               -- Variable para el Numero de Registros a procesar
	SET @Regs = (SELECT COUNT(*) FROM temporal) --Obtenemos la cantidad de registros a procesar
							
	DECLARE @tabla VARCHAR(50)
	DECLARE @schemaa VARCHAR(50)
 
	-- Hacemos el Loop
	WHILE @Contador <= @Regs
		BEGIN
			SELECT @tabla = t.tabla, @schemaa = t.schem
			FROM temporal t
			WHERE t.ID = @Contador
 
			-- Borramos la tabla de schema
--			Print 'Borrando la tabla '+@schemaa+'.'+@tabla
			EXEC('DROP TABLE '+@schemaa+'.'+@tabla);
			SET @Contador = @Contador + 1
		END
										
	DROP TABLE temporal
END
GO

BEGIN /* *************** CREACION DE TABLAS *************** */
	CREATE TABLE HHHH.usuarios(
		id_usuario numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		usuario NVARCHAR(255) UNIQUE not null,
		contrasena CHAR(44) NOT NULL,
		intentosFallidos INT DEFAULT 0,
		estado NVARCHAR DEFAULT 'H' CHECK (estado IN ('H','I','B')) -- habilitado, inhabilitado, baja
	)
	
	CREATE TABLE HHHH.paises(
		Codigo numeric(18,0) Primary key,
		Descripcion varchar(250) unique
	)
	
	CREATE TABLE HHHH.bancos(
		Id_banco numeric(18,0) PRIMARY KEY,
		Descripcion varchar(250),
		Id_pais numeric(18,0) FOREIGN KEY REFERENCES HHHH.paises(Codigo),
		Localidad varchar(250),
		Calle varchar(250),
		Altura numeric(10,0)
	)
	
	CREATE TABLE HHHH.cheques(
		Id_cheque numeric(18,0) PRIMARY KEY,
		Fecha_cheque datetime,
		Importe numeric(18,2) NOT NULL,
		Destinatario varchar(250),
		Id_banco numeric(18,0) FOREIGN KEY REFERENCES HHHH.bancos(Id_banco)
	)
	
	CREATE TABLE HHHH.tipos_documentos(
		Id_tipo_documento numeric(18,0) PRIMARY KEY,
		Descripcion varchar(250) UNIQUE
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
		Id_cuenta numeric(18,0) identity(1,1) primary key,
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
	
	CREATE TABLE HHHH.Monedas(
		Id_moneda numeric(18,0) identity(1,1) primary key,
		Descripcion nvarchar(30) not null
	)
	
	CREATE TABLE HHHH.retiros(
		Id_retiro numeric(18,0) PRIMARY KEY,
		Id_cuenta numeric(18,0) FOREIGN KEY REFERENCES HHHH.cuentas(Id_cuenta),
		importe numeric(18,2) NOT NULL,
		Id_cheque numeric(18,0) FOREIGN KEY REFERENCES HHHH.cheques(Id_cheque),
		fecha_retiro datetime,
		Id_moneda numeric(18,0) FOREIGN KEY REFERENCES HHHH.monedas(Id_moneda)
	)
	
	CREATE TABLE HHHH.depositos(
		Id_deposito numeric(18,0) identity(1,1) primary key,
		Id_cuenta numeric(18,0) not null CONSTRAINT FK_depositos_cuenta FOREIGN KEY REFERENCES HHHH.cuentas (Id_cuenta),
		Importe numeric(18,2)not null,
		Id_tipo_moneda numeric(18,0) references HHHH.Monedas(Id_Moneda),
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
	
	CREATE TABLE HHHH.roles(
		Id_rol numeric(18,0) PRIMARY KEY IDENTITY(1,1),
		Nombre_rol 	varchar(20),
		Estado nvarchar DEFAULT 'A' CHECK (Estado IN ('A','N')) --Activo, No activo
	)
	
	CREATE TABLE HHHH.rel_rol_usuario(
		Id_rol numeric(18,0) FOREIGN KEY REFERENCES HHHH.roles(Id_rol),
		Id_usuario INT FOREIGN KEY REFERENCES HHHH.usuarios(id_usuario)
		CONSTRAINT Claves_primarias
		PRIMARY KEY CLUSTERED(
			Id_rol,
			Id_usuario
		)
	)
	
	CREATE TABLE HHHH.Facturas(
		Id_factura numeric(18,0) identity(1,1) primary key,
		Fecha_factura datetime,
		id_cliente numeric(18,0) references HHHH.clientes(Id_cliente),
		Monto_total numeric(18,2),
		id_moneda numeric(18,0) references HHHH.Monedas(Id_moneda),
		Pagado BIT DEFAULT 0,
	)
	
	CREATE TABLE HHHH.Movimientos(
		Id_movimiento numeric(18,0) identity(1,1) primary key,
		Id_factura numeric(18,0) references HHHH.Facturas(Id_factura),
		Tipo_movimiento char(1) not null, -- T transferencia , C cambio de cuenta
		Costo numeric(18,2) not null,
		Id_moneda numeric(18,0) references HHHH.Monedas(Id_moneda),
		Id_cuenta numeric(18,0) references HHHH.Cuentas(Id_cuenta),
		Fecha datetime not null,
		Id_transferencia numeric(18,0),-- references HHHH.Transferencias,
		Dias_comprados numeric(18,0),
		Cambio_tipo_cuenta numeric(18,0)-- references HHHH.Tipo_Cuenta,
	)
	
	--CREATE TABLE HHHH.Funcionalidades(		--Ana
	--)

	--CREATE TABLE HHHH.Transferencias(	--Ana
	--)
	
	
	--CREATE TABLE HHHH.Rel_Rol_Funcionalidad(	--Ana
	--)
	
	--CREATE TABLE HHHH.Tipo_Cuenta(	--Ana
	--)
	
END
GO

BEGIN /* *************** MIGRACION *************** */
	INSERT INTO HHHH.Monedas (Descripcion)
		VALUES('USD');
		
	INSERT INTO HHHH.paises(Codigo,Descripcion)
		SELECT DISTINCT Cli_Pais_Codigo, Cli_Pais_Desc
		FROM gd_esquema.Maestra
	UNION
		SELECT DISTINCT Cuenta_Pais_Codigo, Cuenta_Pais_Desc
		FROM gd_esquema.Maestra
		
	INSERT INTO HHHH.bancos(Id_banco, Descripcion)
		SELECT DISTINCT M.Banco_Cogido, M.Banco_Nombre
		FROM gd_esquema.Maestra M
		WHERE M.Banco_Cogido IS NOT NULL
		
	INSERT INTO HHHH.cheques(Id_cheque, Fecha_cheque, Importe, Id_banco)
		SELECT DISTINCT M.Cheque_Numero, M.Cheque_Fecha, M.Cheque_Importe,M.Banco_Cogido
	FROM gd_esquema.Maestra M
	WHERE M.Cheque_Numero IS NOT NULL
	
	INSERT INTO HHHH.tipos_documentos(Id_tipo_documento, Descripcion)
		SELECT DISTINCT Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc
		FROM gd_esquema.Maestra
		
	INSERT INTO HHHH.clientes(Id_pais, Nombre, Apellido, Id_tipo_documento, Mail,
				 Altura, Calle, Piso, Departamento, Fecha_nacimiento, Nro_Documento)
		SELECT  DISTINCT Cli_Pais_Codigo, Cli_Nombre, Cli_Apellido, 
			Cli_Tipo_Doc_Cod, Cli_Mail,
			Cli_Dom_Nro, Cli_Dom_Calle,
			Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, 
			Cli_Nro_Doc 
		FROM gd_esquema.Maestra
		
	INSERT INTO HHHH.usuarios (usuario,contrasena)
		SELECT DISTINCT Mail,'10/w7o2juYBrGMh32/KbveULW9jk2tejpyUAD+uC6PE=' --contrasena: pass
			FROM HHHH.clientes
	
	UPDATE HHHH.clientes
		SET Id_usuario = usuarios.id_usuario
		FROM HHHH.usuarios
			where usuarios.usuario=clientes.Mail
		
	INSERT INTO HHHH.usuarios (usuario,contrasena)
		VALUES ('admin','5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=');

	SET IDENTITY_INSERT HHHH.cuentas ON
	INSERT INTO HHHH.cuentas(Id_cuenta, Id_pais, Fecha_apertura, Id_cliente)
		SELECT DISTINCT M.Cuenta_Numero, M.Cuenta_Pais_Codigo, M.Cuenta_Fecha_Creacion, 
				C.Id_cliente
		FROM gd_esquema.Maestra M, HHHH.clientes C
		WHERE C.Mail = M.Cli_Mail
	SET IDENTITY_INSERT HHHH.cuentas OFF
	
	INSERT INTO HHHH.retiros(Id_retiro, Id_cuenta, importe, Id_cheque, fecha_retiro)
		SELECT DISTINCT M.Retiro_Codigo, M.Cuenta_Numero, M.Retiro_Importe, M.Cheque_Numero, M.Retiro_Fecha
		FROM gd_esquema.Maestra M
		WHERE M.Retiro_Codigo is not null
	
	UPDATE HHHH.retiros SET Id_moneda = 1
	
	INSERT INTO HHHH.tarjetas(Numero, Fecha_emision, Fecha_vencimiento, Codigo_seguridad, Id_cliente)
		SELECT distinct T.Tarjeta_Numero, T.Tarjeta_Fecha_Emision, T.Tarjeta_Fecha_Vencimiento,
			T.Tarjeta_Codigo_Seg, C.id_cliente
		FROM (SELECT DISTINCT Tarjeta_Numero, Tarjeta_Fecha_Emision,
							Tarjeta_Fecha_Vencimiento, Tarjeta_Codigo_Seg, Cuenta_Numero
			  FROM gd_esquema.Maestra
			  WHERE Tarjeta_Numero is not null) T , HHHH.cuentas C
		WHERE T.Cuenta_Numero = C.id_cuenta
	
	SET IDENTITY_INSERT HHHH.depositos ON	
	INSERT INTO HHHH.depositos(Id_deposito, Id_cuenta, Importe, Id_tarjeta, Fecha_deposito,Id_tipo_moneda)
		SELECT DISTINCT Deposito_Codigo, Cuenta_Numero, Deposito_Importe, 
				T.Id_tarjeta, Deposito_Fecha,1
		FROM gd_esquema.Maestra M, HHHH.tarjetas T
		WHERE M.Deposito_Codigo is not null and M.Tarjeta_Numero = T.Numero
	SET IDENTITY_INSERT HHHH.depositos OFF
	
	INSERT INTO HHHH.roles(Nombre_rol, Estado)
		VALUES ('Administrador', 'A')
	
	INSERT INTO HHHH.roles(Nombre_rol, Estado)
		VALUES ('Cliente', 'A')
		
	INSERT INTO HHHH.rel_rol_usuario(Id_rol, Id_usuario)
		VALUES (1,1)
	
	SET IDENTITY_INSERT HHHH.Facturas ON
	INSERT INTO HHHH.Facturas(Id_factura,id_cliente,Fecha_factura,Monto_total,id_moneda,Pagado)
		SELECT Factura_Numero,c.Id_cliente, Factura_Fecha,Item_Factura_Importe,1 ,1		--cada factura de la tabla maestra tiene solo 1 item
			FROM gd_esquema.Maestra m,HHHH.clientes c
			WHERE m.Cli_Mail = c.Mail
				AND Factura_Numero IS NOT NULL
	SET IDENTITY_INSERT HHHH.Facturas OFF

	INSERT INTO HHHH.Movimientos(Id_factura,Tipo_movimiento,Costo,Id_moneda,Id_cuenta,Fecha,Id_transferencia,Dias_comprados,Cambio_tipo_cuenta)
		SELECT Factura_Numero,'T',Item_Factura_Importe,1,Cuenta_Numero,Transf_Fecha,null,null,null	--en la tabla maestra solo hay movimientos de comision
			FROM gd_esquema.Maestra m,HHHH.clientes c --todavia no hay tabla de transferencias, por lo que falta el campo id_transferencia
			WHERE m.Cli_Mail = c.Mail
				AND Factura_Numero IS NOT NULL
	
END
GO

BEGIN /* *************** BORRADO DE STORED PROCEDURES *************** */

	--Creamos una tabla temporal para los procedimientos y funciones de nuestro schema
	CREATE TABLE temporal(
	ID int identity(1,1),
	nombre sysname,
	schem nvarchar(128),
	tipo nvarchar(20)
	)
	
	--Insertamos los procedimientos o funciones del schema
	INSERT INTO temporal(schem,nombre,tipo)
		(SELECT ROUTINE_SCHEMA, ROUTINE_NAME, ROUTINE_TYPE
		 FROM information_schema.routines
		 WHERE routine_type = 'PROCEDURE' or 
				routine_type = 'FUNCTION')


	DECLARE @Contador INT           -- Variable contador
	SET @Contador = 1   
	DECLARE @Regs INT               -- Variable para el Numero de Registros a procesar
	SET @Regs = (SELECT COUNT(*) FROM temporal) --Obtenemos la cantidad de registros a procesar
							
	DECLARE @nombre VARCHAR(50)
	DECLARE @tipo VARCHAR(20);
	DECLARE @schemaa VARCHAR(50)
 
	-- Hacemos el Loop
	WHILE @Contador <= @Regs
		BEGIN
			SELECT @nombre = t.nombre, @schemaa = t.schem, @tipo = t.tipo
			FROM temporal t
			WHERE t.ID = @Contador
 
			-- Borramos el procedimiento o funcion
--			Print 'Borrando '+@tipo+' '+@schemaa+'.'+@nombre
			IF @tipo = 'PROCEDURE'
				EXEC('DROP PROCEDURE '+@schemaa+'.'+@nombre)
			IF @tipo = 'FUNCTION'
				EXEC('DROP FUNCTION '+@schemaa+'.'+@nombre)
			SET @Contador = @Contador + 1
		END
										
	DROP TABLE temporal
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
			INSERT INTO HHHH.logins (id_usuario, fecha, exito,numeroDeFallo)
				VALUES (@id_usuario,GETDATE(),0,(SELECT intentosFallidos FROM HHHH.usuarios WHERE id_usuario = @id_usuario))
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
