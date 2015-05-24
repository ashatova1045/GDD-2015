USE GD1C2015

BEGIN /* *************** CREACION DEL SCHENMA *************** */
	IF NOT EXISTS (SELECT [name] FROM [sys].[schemas] WHERE [name] = 'HHHH')
		EXECUTE ('CREATE SCHEMA HHHH AUTHORIZATION gd;');
END
GO

BEGIN /* *************** BORRADO DE CONSTRAINTS *************** */

	--Creamos una tabla temporal para las FOREIGN KEY
	CREATE TABLE temporal(
	ID int IDENTITY(1,1),
	nombre sysname,
	tabla sysname,
	schem nvarchar(128)
	)
	--Insertamos las CONSTRAINT de tipo FOREIGN KEY en la tabla
	INSERT INTO temporal(nombre,tabla,schem)
		(SELECT CONSTRAINT_NAME, TABLE_NAME, TABLE_SCHEMA
		FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		WHERE CONSTRAINT_TYPE = 'FOREIGN KEY' AND
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
--			PRINT 'BorrANDo la CONSTRAINT '+@nombre+' de la tabla '+@schemaa+'.'+@tabla
			EXEC('ALTER TABLE '+@schemaa+'.'+@tabla+' DROP CONSTRAINT '+@nombre);
			SET @Contador = @Contador + 1
 
		END								
	DROP TABLE temporal
		
END
GO

BEGIN /* *************** BORRADO DE TABLAS *************** */

	--Creamos una tabla temporal para las tablas de nuestro schema
	CREATE TABLE temporal(
	ID int IDENTITY(1,1),
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
--			Print 'BorrANDo la tabla '+@schemaa+'.'+@tabla
			EXEC('DROP TABLE '+@schemaa+'.'+@tabla);
			SET @Contador = @Contador + 1
		END
										
	DROP TABLE temporal
END
GO

BEGIN /* *************** BORRADO DE STORED PROCEDURES *************** */

	--Creamos una tabla temporal para los procedimientos y funciones de nuestro schema
	CREATE TABLE temporal(
	ID int IDENTITY(1,1),
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

/* *************** CREACION DE FUNCIONES AUXILIARES *************** */
	CREATE FUNCTION HHHH.borrardominio(@mail nvarchar(255))
	RETURNS nvarchar(255)
	AS
	BEGIN 
		RETURN substring(@mail,0,charindex('@gmail.com',@mail))
	END
GO

BEGIN /* *************** CREACION DE TABLAS *************** */
	CREATE TABLE HHHH.usuarios(
		Id_usuario numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Usuario NVARCHAR(255) UNIQUE NOT NULL,
		Contrasena CHAR(44) NOT NULL,
		IntentosFallidos INT DEFAULT 0,
		Estado NVARCHAR CHECK (Estado IN ('H','I','B')) -- habilitado, inhabilitado, baja
	)
	
	CREATE TABLE HHHH.paises(
		Codigo numeric(18,0) PRIMARY KEY,
		Descripcion varchar(250) UNIQUE
	)
	
	CREATE TABLE HHHH.bancos(
		Id_banco numeric(18,0) PRIMARY KEY IDENTITY(1,1),
		Descripcion varchar(250),
		Id_pais numeric(18,0) CONSTRAINT FK_bancos_paises FOREIGN KEY REFERENCES HHHH.paises(Codigo),
		Localidad varchar(250),
		Calle varchar(250),
		Altura numeric(10,0)
	)
	
	CREATE TABLE HHHH.cheques(
		Id_cheque numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Fecha_cheque datetime,
		Importe numeric(18,2) NOT NULL,
		Destinatario varchar(250),
		Id_banco numeric(18,0) CONSTRAINT FK_cheques_bancos FOREIGN KEY REFERENCES HHHH.bancos(Id_banco)
	)
	
	CREATE TABLE HHHH.tipos_documentos(
		Id_tipo_documento numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Descripcion varchar(250) UNIQUE
	)
	
	CREATE TABLE HHHH.clientes( 
		Id_cliente numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Id_usuario numeric(18,0) /*unique */CONSTRAINT FK_clientes_usuario FOREIGN KEY REFERENCES HHHH.usuarios(id_usuario),
		Nombre varchar(255)NOT NULL,
		Apellido varchar(255)NOT NULL,
		Nro_Documento numeric(18,0)NOT NULL,
		Id_tipo_documento int NOT NULL,
		Mail varchar(255) NOT NULL,
		Id_pais numeric(18,0) NOT NULL CONSTRAINT FK_clientes_pais FOREIGN KEY REFERENCES HHHH.paises (Codigo),
		Altura int,
		Calle varchar(255),
		Piso int,
		Departamento varchar(10),
		Localidad varchar(255),
		Id_nacionalidad numeric(18,0) CONSTRAINT FK_clientes_nacionalidad FOREIGN KEY REFERENCES HHHH.paises (Codigo),
		Fecha_nacimiento datetime,
		Estado NVARCHAR CHECK (Estado IN ('H','I')) -- habilitado, inhabilitado
	)
	
	CREATE TABLE HHHH.Monedas(
		Id_moneda numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Descripcion nvarchar(30) NOT NULL
	)

	CREATE TABLE HHHH.tipo_cuenta(	
		Id_tipo_cuenta numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Descripcion nvarchar(255),
		Id_moneda_cuenta numeric(18,0) CONSTRAINT FK_tipo_cuenta__monedas_cuenta REFERENCES HHHH.monedas (Id_moneda),
		Costo_transf numeric(18,2),
		Duracion int, 
		Id_moneda_transf numeric(18,0) CONSTRAINT FK_tipo_cuenta__monedas_transf REFERENCES HHHH.monedas (Id_moneda),
		Costo_cuenta numeric(18,2),
	)
	
	CREATE TABLE HHHH.cuentas(
		Id_cuenta numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Id_pais numeric(18,0) CONSTRAINT FK_cuentas_pais FOREIGN KEY REFERENCES HHHH.paises(Codigo),
		Id_moneda numeric(18,0),
		Fecha_apertura datetime,
		Id_tipo_cuenta numeric(18,0) CONSTRAINT FK_cuentas_tc FOREIGN KEY REFERENCES HHHH.tipo_cuenta(Id_tipo_cuenta),
		Id_cliente numeric(18,0) NOT NULL CONSTRAINT FK_cuentas_cliente FOREIGN KEY REFERENCES HHHH.clientes(Id_cliente),
		Estado NVARCHAR DEFAULT 'P' CHECK (Estado IN ('P','C','H','I')), -- pend act, cerrada, habilida, inhabilitada
		Saldo numeric(18,2)
	)
	
	CREATE TABLE HHHH.tarjetas(
		Id_tarjeta numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Numero binary(20) unique,
		finalnumero char(4) not null,
		Id_banco numeric(18,0) CONSTRAINT FK_tarjetas_banco FOREIGN KEY REFERENCES HHHH.bancos(Id_banco),
		Fecha_emision datetime,
		Fecha_vencimiento datetime,
		Codigo_seguridad binary(20),
		estado bit default 1,
		Id_cliente numeric(18,0) CONSTRAINT FK_tarjetas_cliente FOREIGN KEY REFERENCES HHHH.clientes (Id_cliente)
	)
	
	CREATE TABLE HHHH.retiros(
		Id_retiro numeric(18,0) PRIMARY KEY IDENTITY(1,1),
		Id_cuenta numeric(18,0) CONSTRAINT FK_retiros_cuentas FOREIGN KEY REFERENCES HHHH.cuentas(Id_cuenta),
		Importe numeric(18,2) NOT NULL,
		Id_cheque numeric(18,0) CONSTRAINT FF_retiros_cheques FOREIGN KEY REFERENCES HHHH.cheques(Id_cheque),
		Fecha_retiro datetime,
		Id_moneda numeric(18,0) CONSTRAINT FK_cuentas_monedas FOREIGN KEY REFERENCES HHHH.monedas(Id_moneda)
	)
	
	CREATE TABLE HHHH.depositos(
		Id_deposito numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Id_cuenta numeric(18,0) NOT NULL CONSTRAINT FK_depositos_cuenta FOREIGN KEY REFERENCES HHHH.cuentas (Id_cuenta),
		Importe numeric(18,2)NOT NULL,
		Id_tipo_moneda numeric(18,0) CONSTRAINT FK_depositos_monedas FOREIGN KEY REFERENCES HHHH.Monedas(Id_Moneda),
		Id_tarjeta numeric(18,0) CONSTRAINT FK_depositos_tarjeta FOREIGN KEY REFERENCES HHHH.tarjetas (Id_tarjeta),
		Fecha_deposito datetime
	)

	CREATE TABLE HHHH.logins(
		Id_usuario numeric(18,0) CONSTRAINT FK_logins_usuario FOREIGN KEY REFERENCES HHHH.usuarios(id_usuario),
		Fecha datetime,
		Exito bit,
		NumeroDeFallo bit,
		PRIMARY KEY (Id_usuario,Fecha)
	)
	
	CREATE TABLE HHHH.roles(
		Id_rol numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Nombre_rol 	varchar(20) UNIQUE,
		Estado nvarchar DEFAULT 'A' CHECK (Estado IN ('A','N')) --Activo, No activo
	)
	
	CREATE TABLE HHHH.rel_rol_usuario(
		Id_rol numeric(18,0) CONSTRAINT FK_rel_rol_usuario__roles FOREIGN KEY REFERENCES HHHH.roles(Id_rol),
		Id_usuario numeric(18,0) CONSTRAINT FK_rel_rol_usuario__usuarios FOREIGN KEY REFERENCES HHHH.usuarios(id_usuario)
		PRIMARY KEY (Id_rol, Id_usuario	)
	)
	
	CREATE TABLE HHHH.facturas(
		Id_factura numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Fecha_factura datetime,
		Id_cliente numeric(18,0) CONSTRAINT FK_facturas_clientes REFERENCES HHHH.clientes(Id_cliente),
		Monto_total numeric(18,2),
		Id_moneda numeric(18,0) CONSTRAINT FK_facturas_monedas REFERENCES HHHH.monedas(Id_moneda),
		Pagado bit DEFAULT 0
	)
	

	CREATE TABLE HHHH.funcionalidades(	
		Id_funcionalidad numeric(18,0) IDENTITY(1,1) PRIMARY KEY, 
		Descripcion nvarchar(255)
	)

	CREATE TABLE HHHH.transferencias(
		Id_transferencia numeric(18,0) IDENTITY (1,1) PRIMARY KEY,
		Cuenta_origen numeric(18,0) CONSTRAINT FK_transferencias_cuentas_origen REFERENCES HHHH.cuentas (Id_cuenta),
		Cuenta_destino numeric(18,0) CONSTRAINT FK_transferencias_cuentas_destino REFERENCES HHHH.cuentas (Id_cuenta),
		Importe numeric(18,2),
		Fecha_transferencia datetime, 
		Costo numeric(18,2),
		Id_moneda numeric(18,0) CONSTRAINT FK_transferencias_monedas REFERENCES HHHH.monedas (Id_moneda)	
	)
	
	
	CREATE TABLE HHHH.rel_rol_funcionalidad(	
		Id_rol numeric(18,0) CONSTRAINT FK_rel_rol_funcionalidad__roles REFERENCES HHHH.roles (Id_rol),
		Id_funcionalidad numeric(18,0) CONSTRAINT FK_rel_rol_funcionalidad__funcionalidades REFERENCES HHHH.funcionalidades(Id_funcionalidad),
		PRIMARY KEY (Id_rol, Id_funcionalidad)
	)
	
	CREATE TABLE HHHH.movimientos(
		Id_movimiento numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Id_factura numeric(18,0) CONSTRAINT FK_movimientos_facturas REFERENCES HHHH.facturas(Id_factura),
		Tipo_movimiento char(1) NOT NULL CHECK (Tipo_movimiento IN ('T','C')), --  T transferencia , C cambio de cuenta 
		Costo numeric(18,2) NOT NULL,
		Id_moneda numeric(18,0) CONSTRAINT FK_movimientos_monedas REFERENCES HHHH.monedas(Id_moneda),
		Id_cuenta numeric(18,0) CONSTRAINT FK_movimientos_cuentas REFERENCES HHHH.cuentas(Id_cuenta),
		Fecha datetime NOT NULL,
		Id_transferencia numeric(18,0) CONSTRAINT FK_movimientos_transferencias REFERENCES HHHH.transferencias (Id_transferencia),
		Dias_comprados numeric(18,0),
		Cambio_tipo_cuenta numeric(18,0) CONSTRAINT FK_movimientos__tipo_cuenta REFERENCES HHHH.tipo_cuenta (Id_tipo_cuenta)
	)
	
END
GO

BEGIN /* *************** MIGRACION *************** */
	INSERT INTO HHHH.Monedas (Descripcion)
		VALUES('USD');
-------------------------------------------------------------------------------------------			
	INSERT INTO HHHH.paises(Codigo,Descripcion)
		SELECT DISTINCT Cli_Pais_Codigo, Cli_Pais_Desc
			FROM gd_esquema.Maestra
	UNION
		SELECT DISTINCT Cuenta_Pais_Codigo, Cuenta_Pais_Desc
			FROM gd_esquema.Maestra
-------------------------------------------------------------------------------------------	
	INSERT INTO HHHH.bancos(Descripcion)
		VALUES('Banco migracion')	
	SET IDENTITY_INSERT HHHH.bancos ON
	INSERT INTO HHHH.bancos(Id_banco, Descripcion)
		SELECT DISTINCT M.Banco_Cogido, M.Banco_Nombre
			FROM gd_esquema.Maestra M
			WHERE M.Banco_Cogido IS NOT NULL
	SET IDENTITY_INSERT HHHH.bancos OFF
-------------------------------------------------------------------------------------------			
	SET IDENTITY_INSERT HHHH.cheques ON	
	INSERT INTO HHHH.cheques(Id_cheque, Fecha_cheque, Importe, Id_banco)
		SELECT DISTINCT M.Cheque_Numero, M.Cheque_Fecha, M.Cheque_Importe,M.Banco_Cogido
			FROM gd_esquema.Maestra M
			WHERE M.Cheque_Numero IS NOT NULL
	SET IDENTITY_INSERT HHHH.cheques OFF
-------------------------------------------------------------------------------------------		
	SET IDENTITY_INSERT HHHH.tipos_documentos ON
	INSERT INTO HHHH.tipos_documentos(Id_tipo_documento, Descripcion)
		SELECT DISTINCT Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc
			FROM gd_esquema.Maestra
	SET IDENTITY_INSERT HHHH.tipos_documentos OFF
-------------------------------------------------------------------------------------------			
	INSERT INTO HHHH.clientes(Id_pais, Nombre, Apellido, Id_tipo_documento, Mail,
				 Altura, Calle, Piso, Departamento, Fecha_nacimiento, Nro_Documento, Estado)
		SELECT  DISTINCT Cli_Pais_Codigo, Cli_Nombre, Cli_Apellido, 
			Cli_Tipo_Doc_Cod, Cli_Mail,
			Cli_Dom_Nro, Cli_Dom_Calle,
			Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, 
			Cli_Nro_Doc, 'H' 
			FROM gd_esquema.Maestra
-------------------------------------------------------------------------------------------			
	INSERT INTO HHHH.usuarios(usuario,contrasena,Estado)
		VALUES ('admin','5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=','H');
		
	INSERT INTO HHHH.usuarios(usuario,contrasena,Estado)
		SELECT DISTINCT HHHH.borrardominio(Mail),'10/w7o2juYBrGMh32/KbveULW9jk2tejpyUAD+uC6PE=', 'H' --contrasena: pass
			FROM HHHH.clientes
-------------------------------------------------------------------------------------------		
	UPDATE HHHH.clientes
		SET Id_usuario = usuarios.id_usuario
		FROM HHHH.usuarios
			WHERE usuarios.usuario = HHHH.borrardominio(clientes.Mail)
-------------------------------------------------------------------------------------------	
	INSERT INTO HHHH.Tipo_Cuenta(Descripcion, Id_moneda_cuenta, Costo_transf, Duracion, Id_moneda_transf, Costo_cuenta)
		VALUES ('Gratuita', 1,3,30,1,0),
				('Bronce', 1,2,30,1,1),
				('Plata', 1,1,30,1,2),
				('Oro', 1,0,30,1,3)
-------------------------------------------------------------------------------------------			
	SET IDENTITY_INSERT HHHH.cuentas ON
	INSERT INTO HHHH.cuentas(Id_cuenta, Id_pais, Fecha_apertura, Id_cliente,Id_moneda,Saldo,Estado,Id_tipo_cuenta)
		SELECT DISTINCT M.Cuenta_Numero, M.Cuenta_Pais_Codigo, M.Cuenta_Fecha_Creacion, 
				C.Id_cliente,1,100,'H',1
			FROM gd_esquema.Maestra M, HHHH.clientes C
			WHERE C.Mail = M.Cli_Mail
	SET IDENTITY_INSERT HHHH.cuentas OFF
-------------------------------------------------------------------------------------------	
	SET IDENTITY_INSERT HHHH.retiros ON
	INSERT INTO HHHH.retiros(Id_retiro, Id_cuenta, importe, Id_cheque, fecha_retiro, Id_moneda)
		SELECT DISTINCT M.Retiro_Codigo, M.Cuenta_Numero, M.Retiro_Importe, M.Cheque_Numero, M.Retiro_Fecha, 1
			FROM gd_esquema.Maestra M
			WHERE M.Retiro_Codigo IS NOT NULL
	SET IDENTITY_INSERT HHHH.retiros OFF
-------------------------------------------------------------------------------------------	
	INSERT INTO HHHH.tarjetas(Numero, Fecha_emision, Fecha_vencimiento, Codigo_seguridad, Id_cliente,finalnumero, Id_banco)
		SELECT distinct HashBytes('SHA1',T.Tarjeta_Numero), T.Tarjeta_Fecha_Emision, T.Tarjeta_Fecha_Vencimiento,
			HashBytes('SHA1',T.Tarjeta_Codigo_Seg), C.id_cliente,RIGHT(T.Tarjeta_Numero,4),1 --Banco Migracion
		FROM (SELECT DISTINCT Tarjeta_Numero, Tarjeta_Fecha_Emision,
							Tarjeta_Fecha_Vencimiento, Tarjeta_Codigo_Seg, Cuenta_Numero
			  FROM gd_esquema.Maestra
			  WHERE Tarjeta_Numero IS NOT NULL) T , HHHH.cuentas C
		WHERE T.Cuenta_Numero = C.id_cuenta
-------------------------------------------------------------------------------------------	
	SET IDENTITY_INSERT HHHH.depositos ON	
	INSERT INTO HHHH.depositos(Id_deposito, Id_cuenta, Importe, Id_tarjeta, Fecha_deposito,Id_tipo_moneda)
		SELECT DISTINCT Deposito_Codigo, Cuenta_Numero, Deposito_Importe, 
				T.Id_tarjeta, Deposito_Fecha,1
		FROM gd_esquema.Maestra M, HHHH.tarjetas T
		WHERE M.Deposito_Codigo IS NOT NULL AND M.Tarjeta_Numero = T.Numero
	SET IDENTITY_INSERT HHHH.depositos OFF
-------------------------------------------------------------------------------------------	
	INSERT INTO HHHH.roles(Nombre_rol, Estado)
		VALUES	('Administrador', 'A'),
				('Cliente', 'A')
-------------------------------------------------------------------------------------------		
	INSERT INTO HHHH.rel_rol_usuario(Id_rol, Id_usuario)
		VALUES (1,1)
		
	INSERT INTO HHHH.rel_rol_usuario(Id_rol, Id_usuario)
		SELECT 2,Id_usuario
			FROM HHHH.usuarios
			WHERE Usuario != 'admin'
-------------------------------------------------------------------------------------------	
	SET IDENTITY_INSERT HHHH.facturas ON
	INSERT INTO HHHH.Facturas(Id_factura,id_cliente,Fecha_factura,Monto_total,id_moneda,Pagado)
		SELECT Factura_Numero,c.Id_cliente, Factura_Fecha,Item_Factura_Importe,1 ,1		--cada factura de la tabla maestra tiene solo 1 item
			FROM gd_esquema.Maestra m,HHHH.clientes c
			WHERE m.Cli_Mail = c.Mail
				AND Factura_Numero IS NOT NULL
	SET IDENTITY_INSERT HHHH.Facturas OFF
-------------------------------------------------------------------------------------------	
	create table HHHH.temporal(
		Id_transferencia numeric (18,0) IDENTITY (1,1) PRIMARY KEY,
		Cuenta_origen numeric (18,0) REFERENCES HHHH.cuentas (Id_cuenta),
		Cuenta_destino numeric (18,0) REFERENCES HHHH.cuentas (Id_cuenta),
		Importe numeric (18,2),
		Fecha_transferencia datetime, 
		Costo numeric (18,2),
		Id_factura numeric(18,0) REFERENCES HHHH.Facturas(Id_factura),
		Id_cuenta numeric(18,0) REFERENCES HHHH.Cuentas(Id_cuenta)
	)
		
	insert into HHHH.temporal(Cuenta_origen,Cuenta_destino,Importe,Fecha_transferencia,Costo,Id_factura)
		SELECT Cuenta_Numero,Cuenta_Dest_Numero,Trans_Importe,Transf_Fecha,Item_Factura_Importe,Factura_Numero
			FROM gd_esquema.Maestra m 
			WHERE Factura_Numero IS NOT NULL 
-------------------------------------------------------------------------------------------		
	SET IDENTITY_INSERT HHHH.transferencias ON		
	INSERT INTO HHHH.Transferencias(Id_transferencia,Cuenta_origen , Cuenta_destino, Importe, Fecha_transferencia, Costo, Id_moneda)
		SELECT Id_transferencia,Cuenta_origen, Cuenta_destino, Importe, Fecha_transferencia, Costo, 1 
			FROM HHHH.temporal
	SET IDENTITY_INSERT HHHH.Transferencias OFF		
-------------------------------------------------------------------------------------------
	INSERT INTO HHHH.movimientos(Id_factura,Tipo_movimiento,Costo,Id_moneda,Id_cuenta,Fecha,Id_transferencia,Dias_comprados,Cambio_tipo_cuenta)
		SELECT Id_factura,'T',Costo,1,Cuenta_origen,Fecha_transferencia,Id_transferencia,null,null	--en la tabla maestra solo hay movimientos de comision
			FROM HHHH.temporal
-------------------------------------------------------------------------------------------	
	DROP TABLE HHHH.temporal
-------------------------------------------------------------------------------------------				
	INSERT INTO HHHH.funcionalidades(Descripcion)
		VALUES	('ABM Rol'),
				('ABM Usuario'),
				('ABM Cliente'),
				('ABM Cuenta'),
				('Asociar/Desasociar Tarjeta de Credito'),
				('Depositos'),
				('Retiro de Efectivo'),
				('Transferencia entre Cuentas'),
				('Facturacion de Costos'),
				('Consulta de Saldo de Cuentas'),
				('Listado Estadistico')
-------------------------------------------------------------------------------------------				
	INSERT INTO HHHH.Rel_Rol_Funcionalidad(Id_rol, Id_funcionalidad)
		VALUES (1,1), (1,2), (1,3), (1,4), (1,9), (1,10), (1,11),
				(2,4), (2,5), (2,6), (2,7), (2,8), (2,9), (2,10)
				
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
			SELECT @id_usuario,Id_cliente from HHHH.clientes where Id_usuario=@id_usuario			 --devuelvo el numero de usuario para agregarlo a la sesion
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

CREATE PROCEDURE HHHH.funcionesdelrol
	@nombre nvarchar(255)
AS

	SELECT Rol.Nombre_rol, Fun.Descripcion, Fun.Id_funcionalidad
		FROM HHHH.funcionalidades Fun, HHHH.roles Rol, HHHH.rel_rol_funcionalidad Rel
		WHERE Rel.Id_rol = Rol.Id_rol AND
			Rel.Id_funcionalidad = Fun.Id_funcionalidad AND
			Rol.Nombre_rol = @nombre
	GO
	
CREATE PROCEDURE HHHH.agregarNuevoRol
	@nombre nvarchar(255),
	@estado nvarchar
AS
BEGIN
	DECLARE @existeRol nvarchar(255)
	SET @existeRol = (SELECT Nombre_rol FROM HHHH.roles WHERE Nombre_rol = @nombre)
	IF @existeRol IS NOT NULL
		BEGIN
			RAISERROR ('El nombre de rol ya existe, intente otro nombre',16,1)
			RETURN
		END
	INSERT INTO HHHH.roles(Nombre_rol, Estado)
		VALUES	(@nombre, @estado)
END		
GO


CREATE PROCEDURE HHHH.asignarNuevasFuncRol
	@Rol nvarchar(255),
	@ListaFuc nvarchar(255),
	@estado char
AS
	BEGIN
		DELETE FROM HHHH.rel_rol_funcionalidad
			   FROM HHHH.rel_rol_funcionalidad Rel
				inner join HHHH.roles R
				on R.Nombre_rol = @Rol AND
					R.Id_rol = Rel.Id_rol
					
		UPDATE HHHH.roles
		SET Estado = @estado
		FROM HHHH.roles
			WHERE Nombre_rol = @Rol
		
		DECLARE @strlist NVARCHAR(max), @pos INT, @delim CHAR, @lstr NVARCHAR(max)
		SET @strlist = ISNULL(@ListaFuc,'')
		SET @delim = ','

		WHILE ((len(@strlist) > 0) and (@strlist <> ''))
			BEGIN
				SET @pos = charindex(@delim, @strlist)
        
				IF @pos > 0
					BEGIN
						SET @lstr = substring(@strlist, 1, @pos-1)
						SET @strlist = ltrim(substring(@strlist,charindex(@delim, @strlist)+1, 8000))
					END
				ELSE
					BEGIN
						SET @lstr = @strlist
						SET @strlist = ''
					END
			
			
			INSERT INTO HHHH.rel_rol_funcionalidad(Id_rol,Id_funcionalidad)
				SELECT R.Id_rol, F.Id_funcionalidad 
					FROM HHHH.roles R, HHHH.funcionalidades F
					WHERE R.Nombre_rol = @Rol AND
						  F.Descripcion = @lstr
			END
        RETURN 
    END
GO
		
CREATE PROCEDURE HHHH.transferencia
	@origen numeric(18,0),
	@destino numeric(18,0),
	@moneda numeric(18,0),
	@importe numeric(18,2),
	@costo numeric(18,2),
	@fecha datetime 
AS
	BEGIN
		INSERT INTO HHHH.transferencias(Cuenta_destino,Cuenta_origen,Fecha_transferencia,Id_moneda,Importe,Costo)
			VALUES(@destino,@origen,@fecha,@moneda,@importe,@costo)
		
		INSERT INTO HHHH.movimientos(Id_cuenta,Fecha,Id_moneda,Id_transferencia,Tipo_movimiento,Costo)
			VALUES (@origen,@fecha,@moneda,(SELECT IDENT_CURRENT('HHHH.transferencias')),'T',@costo+@importe)
		
		UPDATE HHHH.cuentas
			SET Saldo -= @importe +@costo
			WHERE Id_cuenta = @origen
		
		UPDATE HHHH.cuentas
			SET Saldo += @importe
			WHERE Id_cuenta = @destino
    END				
		
GO

CREATE PROCEDURE HHHH.asociarTarjeta
	@idusuario numeric(18,0),
	@tarjeta varchar(16),
	@banco numeric(18,0),
	@emision datetime,
	@vencimiento datetime,
	@codigo nvarchar(3)
AS
	BEGIN
		IF EXISTS (SELECT 1 from hhhh.tarjetas where Id_tarjeta = @tarjeta)
			BEGIN
				RAISERROR ('Ya existe esa tarjeta',16,1)
				RETURN
			END
		INSERT INTO HHHH.tarjetas(Numero,Id_banco,Id_cliente,Fecha_vencimiento,Fecha_emision,Codigo_seguridad,finalnumero)
			VALUES(HashBytes('SHA1',@tarjeta),@banco,(select Id_cliente from HHHH.clientes where Id_usuario=@idusuario),@vencimiento,@emision,HashBytes('SHA1',@codigo),RIGHt(@tarjeta,4))
    END				
		
GO

 