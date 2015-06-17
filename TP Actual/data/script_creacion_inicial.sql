USE GD1C2015

BEGIN /* *************** CREACION DEL SCHENMA *************** */
	IF NOT EXISTS (SELECT [name] FROM [sys].[schemas] WHERE [name] = 'HHHH')
		EXECUTE ('CREATE SCHEMA HHHH AUTHORIZATION gd;');
END
GO

BEGIN /* *************** BORRADO *************** */
DECLARE @sql nvarchar(max)
SET @sql = ''

DECLARE @Schemaa nvarchar(5)
SET @Schemaa = 'HHHH'

SELECT @sql += 'ALTER TABLE '+@schemaa+'.'+ TABLE_NAME+' DROP CONSTRAINT '+ CONSTRAINT_NAME+';'+CHAR(13)
		FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
		WHERE CONSTRAINT_TYPE = 'FOREIGN KEY' AND
		TABLE_SCHEMA = @Schemaa
		
exec sp_executesql @sql; SET @sql = ''
	
SELECT @sql += 'DROP TABLE '+@schemaa+'.'+TABLE_NAME+';'+CHAR(13)
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_SCHEMA = @Schemaa

exec sp_executesql @sql; SET @sql = ''

SELECT @sql += 'DROP '+ROUTINE_TYPE+' '+@Schemaa+'.'+ROUTINE_NAME+';'+CHAR(13)
		 FROM information_schema.routines
		 WHERE (routine_type = 'PROCEDURE' or 
				routine_type = 'FUNCTION') and
				ROUTINE_SCHEMA =@Schemaa

exec sp_executesql @Sql
END
GO

/* *************** CREACION DE FUNCIONES AUXILIARES *************** */
	CREATE FUNCTION HHHH.borrardominio(@mail nvarchar(255))
	RETURNS nvarchar(255)
	AS
	BEGIN 
		RETURN substring(@mail,0,charindex('@gmail.com',@mail))
	END
	go
	
	CREATE FUNCTION HHHH.convertirmoneda(@monedaOriginal numeric(18,0),@monedaConvertida numeric(18,0),@monto numeric(18,2))
	RETURNS numeric(20,4)
	AS
	BEGIN
		declare @valorEnUSD numeric(20,4)=	(select @monto*cambio
												from hhhh.tipo_de_cambio
												where id_moneda=@monedaOriginal)
		declare @valorconvertido numeric(20,4) =(select @valorEnUSD/cambio
													from hhhh.tipo_de_cambio
													where id_moneda = @monedaConvertida)
		RETURN @valorconvertido 
	END
GO
GO

BEGIN /* *************** CREACION DE TABLAS *************** */
	CREATE TABLE HHHH.preguntas(
		Id_pregunta numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Pregunta nvarchar(255) not null unique
	)
		
	CREATE TABLE HHHH.usuarios(
		Id_usuario numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
		Usuario NVARCHAR(255) UNIQUE NOT NULL,
		Contrasena CHAR(44) NOT NULL,
		IntentosFallidos INT DEFAULT 0,
		Id_pregunta numeric(18,0) CONSTRAINT FK_usuarios_preguntas FOREIGN KEY REFERENCES HHHH.preguntas(id_pregunta),
		Estado NVARCHAR CHECK (Estado IN ('H','I')) -- habilitado, inhabilitado
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
		Id_usuario numeric(18,0) /*unique*/ CONSTRAINT FK_clientes_usuario FOREIGN KEY REFERENCES HHHH.usuarios(id_usuario),
		Nombre varchar(255)NOT NULL,
		Apellido varchar(255)NOT NULL,
		Nro_Documento numeric(18,0)NOT NULL,
		Id_tipo_documento numeric(18,0) NOT NULL CONSTRAINT FK_clientes_TipoDoc FOREIGN KEY REFERENCES HHHH.tipos_documentos(id_tipo_documento),
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
	
	CREATE TABLE HHHH.Tipo_de_cambio(
		Id_moneda numeric(18,0) PRIMARY KEY references hhhh.Monedas,
		cambio numeric(18,2) NOT NULL
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
		Id_cuenta numeric(18,0) /*IDENTITY(1,1)*/ PRIMARY KEY,
		Id_pais numeric(18,0) CONSTRAINT FK_cuentas_pais FOREIGN KEY REFERENCES HHHH.paises(Codigo),
		Id_moneda numeric(18,0) CONSTRAINT FK_cuentas_moneda FOREIGN KEY REFERENCES HHHH.Monedas(Id_moneda),
		Fecha_apertura datetime,
		Fecha_cierre datetime,
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
		Tipo_movimiento char(1) NOT NULL CHECK (Tipo_movimiento IN ('T','C','P')), --  T transferencia , C cambio de cuenta, P pago cuenta
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
	INSERT INTO HHHH.tipo_de_cambio (Id_moneda,cambio)
		VALUES(1,1);
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
	INSERT INTO HHHH.tipos_documentos(Descripcion)
-		VALUES('Documento Nacional Identidad')
-	INSERT INTO HHHH.tipos_documentos(Descripcion)
-		VALUES('Cedula Identidad')
-	INSERT INTO HHHH.tipos_documentos(Descripcion)
-		VALUES('Libreta Civica')
-	INSERT INTO HHHH.tipos_documentos(Descripcion)
-		VALUES('Libreta de Enrolamiento')
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
				('Bronce', 1,2,20,1,1),
				('Plata', 1,1,15,1,2),
				('Oro', 1,0,10,1,3)
-------------------------------------------------------------------------------------------			
	--SET IDENTITY_INSERT HHHH.cuentas ON
	INSERT INTO HHHH.cuentas(Id_cuenta, Id_pais, Fecha_apertura, Id_cliente,Id_moneda,Estado,Id_tipo_cuenta)
		SELECT DISTINCT M.Cuenta_Numero, M.Cuenta_Pais_Codigo, M.Cuenta_Fecha_Creacion, 
				C.Id_cliente,1,'H',1
			FROM gd_esquema.Maestra M, HHHH.clientes C
			WHERE C.Mail = M.Cli_Mail
	--SET IDENTITY_INSERT HHHH.cuentas OFF
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
		WHERE M.Deposito_Codigo IS NOT NULL AND HashBytes('SHA1',M.Tarjeta_Numero) = T.Numero
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
				--('ABM Usuario'),
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
		VALUES (1,1), (1,2), (1,3), (1,8), (1,9), (1,10),
				(2,3), (2,4), (2,5), (2,6), (2,7), (2,8), (2,9)
-------------------------------------------------------------------------------------------	
	INSERT INTO HHHH.preguntas(Pregunta)
		VALUES('Nombre de la primer mascota')
	INSERT INTO HHHH.preguntas(Pregunta)
		VALUES('Apellido de soltera de la madre')
	INSERT INTO HHHH.preguntas(Pregunta)
		VALUES('Nombre de profesor favorito')
	INSERT INTO HHHH.preguntas(Pregunta)
		VALUES('Profesion del abuelo')
	INSERT INTO HHHH.preguntas(Pregunta)
		VALUES('Libro preferido')
	INSERT INTO HHHH.preguntas(Pregunta)
		VALUES('Pelicula preferida')
END
GO

UPDATE HHHH.cuentas
SET Saldo = Sal.faltaLoquerecibio
FROM HHHH.cuentas cue, 
						(
						SELECT Cuenta_Numero, 
								sum(Deposito_Importe)-sum(Trans_Importe)-sum(Retiro_Importe) as faltaLoquerecibio
						FROM gd_esquema.Maestra
						WHERE Factura_Numero is null
						GROUP BY Cuenta_Numero
						) Sal
WHERE cue.Id_cuenta = Sal.Cuenta_Numero
GO


UPDATE HHHH.cuentas
SET Saldo += TransfRec.transfRec
FROM HHHH.cuentas cue,
						(SELECT Cuenta_Dest_Numero, sum(Trans_Importe) as transfRec
						FROM gd_esquema.Maestra
						WHERE Factura_Numero is null
						GROUP BY Cuenta_Dest_Numero
						) TransfRec
WHERE cue.Id_cuenta = TransfRec.Cuenta_Dest_Numero
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
				SET IntentosFallidos = 0
				WHERE id_usuario = @id_usuario
				
			declare @idcli numeric(18,0)= (SELECT Id_cliente from HHHH.clientes where Id_usuario=@id_usuario)
				SELECT @id_usuario,(select case when @idcli is not null	then @idcli
										else -1
										end)
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
			Rol.Id_rol = @nombre
	GO
	
CREATE PROCEDURE HHHH.agregarNuevoRol
	@nombre nvarchar(255)
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
		VALUES	(@nombre, 'N')
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
	
		DECLARE @Estado char
		SELECT @Estado = cli.Estado 
		FROM HHHH.clientes cli
		JOIN HHHH.cuentas cue
		ON cue.Id_cuenta = @origen and
		   cue.Id_cliente = cli.Id_cliente
		
		IF (@Estado = 'I')
			BEGIN
				RAISERROR('Un cliete inhabilitado no puede realizar transferencias',16,1)
			END
		BEGIN TRANSACTION generarTransferencia
			INSERT INTO HHHH.transferencias(Cuenta_destino,Cuenta_origen,Fecha_transferencia,Id_moneda,Importe,Costo)
				VALUES(@destino,@origen,@fecha,@moneda,@importe,@costo)
			
			INSERT INTO HHHH.movimientos(Id_cuenta,Fecha,Id_moneda,Id_transferencia,Tipo_movimiento,Costo)
				VALUES (@origen,@fecha,@moneda,(SELECT IDENT_CURRENT('HHHH.transferencias')),'T',@costo)
			
			UPDATE HHHH.cuentas
				SET Saldo -= hhhh.convertirmoneda(@moneda,Id_moneda,@importe)
				WHERE Id_cuenta = @origen
			
			UPDATE HHHH.cuentas
				SET Saldo += hhhh.convertirmoneda(@moneda,Id_moneda,@importe)
				WHERE Id_cuenta = @destino
		COMMIT TRANSACTION generarTransferencia
    END				
		
GO


CREATE PROCEDURE HHHH.seleccionarCuentas
	@idUsuarioLogeado int
	
	AS 
		BEGIN
		
		SELECT cue.* FROM HHHH.cuentas cue, HHHH.clientes cli
		WHERE cue.Id_cliente = cli.Id_cliente and cli.Id_usuario = @idUsuarioLogeado
		
		END
		
GO

CREATE PROCEDURE HHHH.seleccionarTarjetas
	@idUsuarioLogeado int
	
	AS 
		BEGIN 
		SELECT tar.Id_tarjeta, 'XXXX-XXXX-XXXX-'+convert(nvarchar(max),tar.finalnumero) AS finalnumero 
		FROM HHHH.tarjetas tar, HHHH.clientes cli
		WHERE tar.Id_cliente = cli.Id_cliente and cli.Id_usuario = @idUsuarioLogeado and tar.estado = 1

		--SELECT tar.* FROM HHHH.tarjetas tar, HHHH.clientes cli
		--WHERE tar.Id_cliente = cli.Id_cliente and cli.Id_usuario = @idUsuarioLogeado
		
		END
		
GO
		
CREATE PROCEDURE HHHH.validarDeposito
	@idUsuarioLogeado numeric (18,0),
	@nroCuenta numeric (18,0),
	@idTarjeta numeric (18,0),
	@importeIngresado numeric (18,2),
	@tipoMoneda numeric (18,0),
	@fechaAhora  datetime
	
	AS
		BEGIN
		
		DECLARE @Estado char
		SELECT @Estado = cli.Estado 
		FROM HHHH.clientes cli
		JOIN HHHH.cuentas cue
		ON cue.Id_cuenta = @nroCuenta and
		   cue.Id_cliente = cli.Id_cliente
		
		IF (@Estado = 'I')
			BEGIN
				RAISERROR('Un cliete inhabilitado no puede realizar depositos',16,1)
			END
	
		DECLARE @estaHabilitadaCuenta nvarchar (1)
		SET @estaHabilitadaCuenta = (SELECT Estado FROM HHHH.cuentas WHERE Id_cuenta = @nroCuenta)
		IF @estaHabilitadaCuenta != 'H'
			BEGIN
				RAISERROR ('La cuenta seleccionada no esta habilitada',16,1)
				RETURN
			END
				DECLARE @esValidaTarjeta numeric (18,0) 
		SET @esValidaTarjeta = (SELECT Id_tarjeta FROM HHHH.tarjetas
								WHERE Id_tarjeta = @idTarjeta AND (Id_cliente = (SElECT Id_cliente 
								FROM HHHH.clientes WHERE Id_usuario = @idUsuarioLogeado))
								AND Fecha_vencimiento >= @fechaAhora)
		IF @esValidaTarjeta IS NULL
			BEGIN 
				RAISERROR ('Tarjeta no valida', 16,1)
				RETURN
			END
		BEGIN TRANSACTION generarDeposito

			INSERT INTO HHHH.depositos(Id_cuenta, Importe, Id_tipo_moneda, Id_tarjeta, Fecha_deposito)
				VALUES (@nroCuenta, @importeIngresado, @tipoMoneda, @esValidaTarjeta, @fechaAhora)	
				
				UPDATE HHHH.cuentas
					SET Saldo = Saldo + hhhh.convertirmoneda(@tipoMoneda,cuentas.Id_moneda,@importeIngresado)
					WHERE Id_cuenta = @nroCuenta	
					
		COMMIT TRANSACTION generarDeposito						
		END		
		

GO

CREATE PROCEDURE HHHH.retiro
	@cuenta numeric(18,0),
	@doc numeric(18,0),
	@importe numeric(18,2),
	@moneda numeric(18,0),
	@fechaRetiro datetime,
	@destinatarioNombre varchar(100),
	@destinatarioApellido varchar(100),
	@banco numeric(18,0)
	
AS
	BEGIN
		DECLARE @Estado char
		SELECT @Estado = cli.Estado 
		FROM HHHH.clientes cli
		JOIN HHHH.cuentas cue
		ON cue.Id_cuenta = @cuenta and
		   cue.Id_cliente = cli.Id_cliente
		
		IF (@Estado = 'I')
			BEGIN
				RAISERROR('Un cliete inhabilitado no puede realizar retiros',16,1)
				RETURN
			END
		
		--si existe un saldo menor, tira error
		IF exists (select saldo from HHHH.cuentas where Id_cuenta=@cuenta and saldo < hhhh.convertirmoneda(@moneda,Id_moneda,@importe))
			BEGIN
				RAISERROR('No tiene dinero suficiente en su cuenta.',16,1)
				RETURN
			END
		BEGIN TRANSACTION generarCheque
			INSERT INTO HHHH.cheques(Fecha_cheque, Importe, Destinatario, Id_banco)
				VALUES(@fechaRetiro, @importe, @destinatarioApellido + ', ' + @destinatarioNombre, @banco)
				
			INSERT INTO HHHH.retiros(Id_cuenta, Importe, Id_cheque, Fecha_retiro, Id_moneda)
				VALUES(@cuenta, @importe, (SELECT IDENT_CURRENT('HHHH.cheques')), @fechaRetiro, @moneda)
		
			UPDATE HHHH.cuentas
				SET Saldo -= hhhh.convertirmoneda(@moneda,Id_moneda,@importe)
				WHERE Id_cuenta = @cuenta
		COMMIT TRANSACTION generarCheque
	END
GO	
	
	

CREATE PROCEDURE HHHH.asociarTarjeta
	@idcliente numeric(18,0),
	@idtarjeta numeric(18,0),
	@tarjeta varchar(16),
	@banco numeric(18,0),
	@emision datetime,
	@vencimiento datetime,
	@modificacion bit,
	@codigo nvarchar(3)
AS
	BEGIN
		IF EXISTS (SELECT 1 from hhhh.tarjetas where ((Numero = HashBytes('SHA1',@tarjeta) and @modificacion = 0) or (Numero = HashBytes('SHA1',@tarjeta) and Id_cliente != @idcliente and @modificacion = 1)))
			BEGIN
				RAISERROR ('Ya existe esa tarjeta',16,1)
				RETURN
			END
		IF @modificacion = 0
			BEGIN
				IF EXISTS (SELECT 1 from hhhh.tarjetas where Numero = HashBytes('SHA1',@tarjeta))
					BEGIN
						RAISERROR ('Ya existe esa tarjeta',16,1)
						RETURN
					END
			INSERT INTO HHHH.tarjetas(Numero,Id_banco,Id_cliente,Fecha_vencimiento,Fecha_emision,Codigo_seguridad,finalnumero)
				VALUES(HashBytes('SHA1',@tarjeta),@banco,@idcliente,@vencimiento,@emision,HashBytes('SHA1',@codigo),RIGHt(@tarjeta,4))
			END
		ELSE
			BEGIN
				IF EXISTS (SELECT 1 from hhhh.tarjetas where Numero = HashBytes('SHA1',@tarjeta) and Id_tarjeta != @idtarjeta)
					BEGIN
						RAISERROR ('Ya existe esa tarjeta',16,1)
						RETURN
					END		
				UPDATE HHHH.tarjetas
					SET Id_banco =@banco,
						Numero=HashBytes('SHA1',@tarjeta),
						Id_cliente=@idcliente,
						Fecha_vencimiento=@vencimiento,
						Fecha_emision=@emision,
						Codigo_seguridad=HashBytes('SHA1',@codigo),
						finalnumero = RIGHt(@tarjeta,4)
					WHERE Id_tarjeta=@idtarjeta
			END
END					
GO

CREATE FUNCTION HHHH.obtenerUser(
@cuenta numeric(18,0))
RETURNS numeric(18,0)
AS
	BEGIN
		DECLARE @usua numeric(18,0)
		SELECT @usua = cli.Id_usuario FROM HHHH.cuentas cue , HHHH.clientes cli 
					WHERE Id_cuenta = @cuenta and cli.id_cliente = cue.Id_cliente
						
		RETURN @usua
	END
GO

CREATE FUNCTION HHHH.GenerarDescripcion(
@tipomov char,
@idTransf numeric(18,0),
@Dcomprados numeric(18,0),
@Tipocambio numeric(18,0))
RETURNS nvarchar(max)
AS
	BEGIN
		IF(@tipomov = 'T')
			BEGIN
				RETURN 'Transferencia de saldo cod.'+convert(nvarchar(max),@idTransf)
			END
		IF(@tipomov = 'P')
			BEGIN
				RETURN 'Costos por apertura de cuenta'
			END
		IF(@tipomov = 'C')
			BEGIN
					DECLARE @Tipocuenta nvarchar(255)
					SELECT @Tipocuenta = Descripcion FROM HHHH.tipo_cuenta WHERE Id_tipo_cuenta = @Tipocambio
				RETURN convert(nvarchar(max),@Dcomprados)+' dias de cuenta tipo: '+@Tipocuenta
			END
			RETURN ''
	END
GO

CREATE FUNCTION HHHH.impconmoneda(
@Importe numeric(18,2),
@Idmoneda numeric(18,0)
)
RETURNS nvarchar(max)
AS
	BEGIN
		IF (@Importe is null)
			RETURN ''
		DECLARE @Descr nvarchar(50)
			SELECT @Descr = Descripcion
				 FROM HHHH.monedas WHERE Id_moneda = @Idmoneda
		RETURN convert(nvarchar(max),@Importe)+' '+@Descr
	END
GO

CREATE PROCEDURE HHHH.movSinFacturar
@user_id numeric(18,0)
AS
	BEGIN
		select convert(date,Fecha) AS Fecha, mov.Id_cuenta AS 'Cuenta' ,HHHH.GenerarDescripcion (mov.Tipo_movimiento,mov.Id_transferencia,mov.Dias_comprados,mov.Cambio_tipo_cuenta) AS Descripcion,
				HHHH.impconmoneda(tr.Importe,mov.Id_moneda) AS Importe,HHHH.impconmoneda(mov.Costo,mov.Id_moneda) AS Costo
			from HHHH.movimientos mov
			LEFT JOIN HHHH.transferencias tr
			ON tr.Id_transferencia = mov.Id_transferencia
			where Id_factura is null 
			 and HHHH.obtenerUser(mov.Id_cuenta) = @user_id
			order by mov.Id_cuenta, Fecha 
	END
GO

CREATE PROCEDURE HHHH.Facturar
@user_id numeric(18,0),
@fecha datetime
AS
		DECLARE @cliente_id int
		SELECT @cliente_id = Id_cliente FROM HHHH.clientes WHERE Id_usuario = @user_id
		
		BEGIN TRANSACTiON generarIDFactura
			INSERT INTO HHHH.facturas(Fecha_factura,Id_cliente)
			SELECT @fecha, @cliente_id
			
			
			DECLARE @FacturaActual numeric(18,0)
			SET @FacturaActual = (SELECT IDENT_CURRENT('HHHH.facturas'))
		COMMIT TRANSACTION generarIDFactura
		
		
		UPDATE HHHH.movimientos
		SET Id_factura = @FacturaActual
		FROM HHHH.movimientos mov
		LEFT JOIN HHHH.transferencias tr
		ON tr.Id_transferencia = mov.Id_transferencia
		WHERE Id_factura is null
			  and HHHH.obtenerUser(mov.Id_cuenta) = @user_id
			  
			 
		UPDATE HHHH.facturas
		SET Monto_total = (SELECT SUM(mov.Costo)
						   FROM HHHH.movimientos mov
						   WHERE mov.Id_factura = @FacturaActual
								 and HHHH.obtenerUser(mov.Id_cuenta) = @user_id)
		WHERE Id_factura = @FacturaActual
--cobrar cambiar estado de cuenta

		UPDATE HHHH.cuentas
		SET Estado = 'H'
		where cuentas.Id_cuenta in(SELECT ID_cuenta from HHHH.movimientos
									where Id_factura = @FacturaActual and Tipo_movimiento = 'P')
/*
		UPDATE HHHH.Cuentas
		SET estado = 'I' FROM 
			(SELECT * FROM
				(SELECT id_cuenta ,COUNT(*) AS cant FROM HHHH.movimientos
				 WHERE Id_factura = @FacturaActual AND
					Tipo_movimiento = 'T' 
				 GROUP BY Id_cuenta) CantMovXCuenta
			WHERE CantMovXCuenta.cant > 5) cue
		WHERE HHHH.Cuentas.Id_cuenta = cue.Id_cuenta */
		
		update HHHH.cuentas
		set estado = 'I'
		WHERE Id_cuenta in (SELECT id_cuenta FROM HHHH.movimientos
								WHERE Id_factura = @FacturaActual AND Tipo_movimiento = 'T' 
								GROUP BY Id_cuenta
								having COUNT(*) > 5)

		SELECT fac.Id_factura, cli.Nombre+' '+cli.Apellido as nombre, us.Usuario, fac.Fecha_factura, fac.Monto_total
		FROM HHHH.facturas fac, HHHH.clientes cli, HHHH.usuarios us
		WHERE fac.Id_factura = @FacturaActual 
			  and fac.Id_cliente = cli.Id_cliente and cli.Id_usuario = us.Id_usuario

GO

CREATE PROCEDURE HHHH.itemFactura(
@id_factura numeric(18,0))
AS
	BEGIN
		SELECT convert(date,mov.Fecha) AS Fecha, mov.Id_cuenta AS 'Cuenta' ,HHHH.GenerarDescripcion (mov.Tipo_movimiento,mov.Id_transferencia,mov.Dias_comprados,mov.Cambio_tipo_cuenta) AS Descripcion,
				HHHH.impconmoneda(tr.Importe,mov.Id_moneda) AS Importe,HHHH.impconmoneda(mov.Costo,mov.Id_moneda) AS Costo_Final
			FROM HHHH.movimientos mov
			LEFT JOIN HHHH.transferencias tr
			ON tr.Id_transferencia = mov.Id_transferencia
			WHERE mov.Id_factura = @id_factura
			order by mov.Id_cuenta, Fecha
				  
	END
GO

CREATE PROCEDURE HHHH.nuevoCliente(
@Nombre varchar(max),
@Apellido varchar(max),
@Documento numeric(18,0),
@TipoDoc int,
@Mail varchar(255),
@Id_pais numeric(18,0),
@Calle varchar(255),
@Altura int,
@Piso int,
@Departamento varchar(10),
@Localidad varchar(255),
@Nacionalidad numeric(18,0),
@FechaNac datetime,
@Usuario nvarchar(255),
@Contrasena nvarchar(255),
@Id_Pregunta nvarchar(255),
@Respuesta nvarchar(255),
@EstadoUsuario char,
@EstadoCliente char)
AS
	BEGIN
	
		DECLARE @error nvarchar(max)
		
		IF EXISTS (SELECT 1 FROM HHHH.usuarios WHERE Usuario = @Usuario)
			BEGIN
				SET @error = 'El usuario '+@usuario+' ya se encuentra registrado. Intente otro'
				RAISERROR(@error,16,1)
				RETURN
			END
			
		IF EXISTS (SELECT 1 FROM HHHH.clientes WHERE Mail = @Mail)
			BEGIN
				SET @error = 'El mail '+@Mail+' ya se encuentra registrado. Intente otro'
				RAISERROR(@error,16,1)
				RETURN
			END
			
		IF EXISTS (SELECT 1 FROM HHHH.clientes WHERE Nro_Documento = @Documento)
			BEGIN
				SET @error = 'El numero de documento '+convert(nvarchar(max),@Documento)+' ya se encuentra registrado'
				RAISERROR(@error,16,1)
				RETURN
			END
		
		BEGIN TRANSACTION nuevoUsuario	
		
			INSERT INTO HHHH.usuarios(Usuario,Contrasena,IntentosFallidos,Estado,Id_pregunta)
				VALUES(@Usuario,@Contrasena,0,@EstadoUsuario,@Id_Pregunta)
				
			INSERT INTO HHHH.rel_rol_usuario(Id_rol,Id_usuario)
				VALUES(2,IDENT_CURRENT('HHHH.usuarios'))
				
			INSERT INTO HHHH.clientes(Id_usuario,Nombre,Apellido,Nro_Documento,Id_tipo_documento,
										Mail,Id_pais,Altura,Calle,Piso,Departamento,Localidad,
										Id_nacionalidad,Fecha_nacimiento,Estado)
				VALUES((SELECT IDENT_CURRENT('HHHH.usuarios')),@Nombre,@Apellido,@Documento,@TipoDoc,
						@Mail,@Id_pais,@Altura,@Calle,@Piso,@Departamento,@Localidad,@Nacionalidad,
						@FechaNac,@EstadoCliente)
						
		COMMIT TRANSACTION nuevoUsuario
	END
GO
 
go
CREATE PROCEDURE HHHH.buscarCliente(
@Nombre varchar(255),
@Apellido varchar(255),
@Documento varchar(255),
@TipoDoc varchar(255),
@Mail varchar(255))
AS
	BEGIN
		SELECT cli.Id_cliente,cli.Nombre, cli.Apellido, cli.Nro_Documento as 'Documento',cli.Id_tipo_documento, tDoc.Descripcion as 'Tipo documento',
				cli.Mail, cli.Id_pais, pa.Descripcion as 'Pais', cli.Estado as 'Estado cliente',cli.Calle, cli.Altura,cli.Piso,cli.Departamento,cli.Localidad,
				cli.Id_nacionalidad, nac.Descripcion as 'Nacionalidad', cli.Fecha_nacimiento as 'Fecha de nacimiento', us.Usuario,us.Estado as 'Estado usuario',
				us.Id_pregunta
			FROM HHHH.clientes cli 
			JOIN HHHH.usuarios us
			ON cli.Id_usuario = us.Id_usuario
			JOIN HHHH.tipos_documentos tDoc
			ON cli.id_tipo_documento = tDoc.Id_tipo_documento
			JOIN HHHH.paises pa
			ON cli.Id_pais = pa.Codigo
			LEFT JOIN HHHH.paises nac
			ON cli.Id_nacionalidad = nac.Codigo
			WHERE cli.Nombre like '%'+@Nombre+'%' and
			cli.Apellido like '%'+@Apellido+'%' and
			cli.Nro_Documento like '%'+@Documento+'%' and
			cli.Id_tipo_documento like '%'+@TipoDoc+'%' and
			cli.Mail like '%'+@Mail+'%'
			
		RETURN
	END
GO

CREATE PROCEDURE HHHH.modificarCliente(
@Id_cliente numeric(18,0),
@Nombre varchar(max),
@Apellido varchar(max),
@Documento numeric(18,0),
@TipoDoc int,
@Mail varchar(255),
@Id_pais numeric(18,0),
@Calle varchar(255),
@Altura int,
@Piso int,
@Departamento varchar(10),
@Localidad varchar(255),
@Nacionalidad numeric(18,0),
@FechaNac datetime,
@EstadoUsuario char,
@EstadoCliente char)
AS
	BEGIN
	
		DECLARE @error nvarchar(max)
				
		IF EXISTS (SELECT 1 FROM HHHH.clientes WHERE Mail = @Mail and Id_cliente != @Id_cliente)
			BEGIN
				SET @error = 'El mail '+@Mail+' ya se encuentra registrado. Intente otro'
				RAISERROR(@error,16,1)
				RETURN
			END
			
		IF EXISTS (SELECT 1 FROM HHHH.clientes WHERE Nro_Documento = @Documento and Id_cliente != @Id_cliente)
			BEGIN
				SET @error = 'El numero de documento '+convert(nvarchar(max),@Documento)+' ya se encuentra registrado'
				RAISERROR(@error,16,1)
				RETURN
			END
			
		
		UPDATE HHHH.clientes
		SET Nombre = @Nombre,
			Apellido = @Apellido,
			Nro_Documento = @Documento,
			Id_tipo_documento = @TipoDoc,
			Mail = @Mail,
			Altura = @Altura,
			Calle = @Calle,
			Piso = @Piso,
			Departamento = @Departamento,
			Localidad = @Localidad,
			Id_nacionalidad = @Nacionalidad,
			Fecha_nacimiento = @FechaNac,
			Estado = @EstadoCliente
			FROM HHHH.clientes
			WHERE Id_cliente = @Id_cliente
			
		UPDATE HHHH.usuarios
		SET Estado = @EstadoUsuario
		FROM HHHH.usuarios US, HHHH.clientes CLI
		WHERE CLI.Id_cliente = @Id_cliente AND
			  US.Id_usuario = CLI.Id_usuario
			
	END
GO

CREATE PROCEDURE HHHH.ObtenerCuentas
@Id_usuario numeric(18,0)

AS
	BEGIN
		SELECT cue.Id_cuenta as 'Cuenta', pa.Descripcion as 'Pais', cue.Id_pais,tp.Id_tipo_cuenta, tp.Descripcion as 'Tipo cuenta', cue.Id_moneda,
				 cue.Fecha_apertura as 'Fecha apertura', mon.Descripcion as 'Moneda', cue.Saldo, cue.Estado, cue.Fecha_cierre
		FROM HHHH.cuentas cue 
		JOIN HHHH.clientes cli 
        ON cli.Id_cliente = cue.Id_cliente and 
	     cli.Id_usuario = @Id_usuario
	    JOIN HHHH.paises pa
	    ON pa.Codigo = cue.Id_pais
	    JOIN HHHH.tipo_cuenta tp
	    on tp.Id_tipo_cuenta = cue.Id_tipo_cuenta
	    JOIN HHHH.Monedas mon
	    ON mon.Id_moneda = cue.Id_moneda
	END
GO

CREATE PROCEDURE HHHH.ModCuenta
@id_usuario numeric(18,0),
@Id_cuenta numeric(18,0),
@Id_pais numeric(18,0),
@Id_moneda numeric(18,0),
@FechaApert datetime,
@id_tipoCta numeric(18,0)
AS
	BEGIN
		UPDATE HHHH.cuentas
		SET Id_pais = @Id_pais,
			Id_moneda = @Id_moneda,
			Fecha_apertura = @FechaApert,
			Id_tipo_cuenta = @id_tipoCta
		WHERE Id_cuenta = @Id_cuenta
	END
GO

CREATE PROCEDURE HHHH.nvaCuenta
@id_usuario numeric(18,0),
@Id_cuenta numeric(18,0),
@Id_pais numeric(18,0),
@Id_moneda numeric(18,0),
@FechaApert datetime,
@id_tipoCta numeric(18,0)
AS
	BEGIN
		DECLARE @Id_cliente numeric(18,0)
		SELECT @Id_cliente = Id_cliente 
		FROM HHHH.clientes
		WHERE Id_usuario = @id_usuario
	
		IF EXISTS (SELECT 1 FROM HHHH.cuentas WHERE Id_cuenta = @Id_cuenta)
			BEGIN
				RAISERROR('Ya existe una cuenta con ese numero. Intente otro',16,1)
			END
		ELSE
			BEGIN
				declare @costoCuenta numeric(18,2)
				declare @duracion int
				select @costoCuenta = hhhh.convertirmoneda(Id_moneda_cuenta,@Id_moneda,Costo_cuenta), @duracion = Duracion 
					from HHHH.tipo_cuenta where Id_tipo_cuenta=@id_tipoCta
				
				declare @fechaDecierre datetime
				
				IF (@id_tipoCta = 1)
					BEGIN
						SET @fechaDecierre = NULL
					END
				ELSE
					BEGIN
						SET @fechaDecierre = dateadd(day,@duracion,@FechaApert)
					END
				
				INSERT HHHH.cuentas(Id_cuenta,Id_cliente,Id_moneda,Id_pais,Id_tipo_cuenta,Fecha_apertura,Saldo,Estado,Fecha_cierre)
					VALUES(@Id_cuenta,@Id_cliente,@Id_moneda,@Id_pais,@id_tipoCta,@FechaApert,0,'P',@fechaDecierre)
				
				INSERT HHHH.movimientos(Tipo_movimiento,Costo,Dias_comprados,Fecha,Id_cuenta,Id_moneda)
					VALUES('P',@costoCuenta,@duracion,@FechaApert,@Id_cuenta,@Id_moneda) 
			END
	END
GO

CREATE PROCEDURE HHHH.bajaCuenta
@cuenta numeric(18,0),
@fecha datetime
AS
	BEGIN

		--si hay una transaccion sin cobrar
		IF EXISTS (select 1 from HHHH.movimientos where Id_factura is null and Id_cuenta = @cuenta)
			BEGIN
				RAISERROR('Tiene transacciones sin cobrar',16,1)
				RETURN
			END
		
		UPDATE HHHH.cuentas
			SET Estado='C',
				fecha_cierre=@fecha
			WHERE Id_cuenta=@cuenta
	END
GO


-----------------LISTADOS ------------------------
CREATE PROCEDURE HHHH.generarListado0

@anio int,
@primerMes int,
@ultimoMes int
AS
	BEGIN
		SELECT cli.Nombre, cli.Apellido, top5.Id_cuenta AS 'Cuenta_Inhabilitada' FROM
			(SELECT TOP 5 cue.Id_cliente, cue.Id_cuenta FROM
				(SELECT mov.Id_cuenta, COUNT (*) AS cantMov FROM HHHH.movimientos mov
					JOIN HHHH.facturas fac
					ON mov.Id_factura = fac.Id_factura
					WHERE fac.Pagado = 0 AND
					YEAR (fac.Fecha_factura) = @anio AND
					MONTH (fac.Fecha_factura) BETWEEN @primerMes AND @ultimoMes
					GROUP BY mov.Id_cuenta) facNoPagas
				JOIN HHHH.cuentas cue
				ON facNoPagas.Id_cuenta = cue.Id_cuenta
				WHERE cue.Estado = 'I' AND
				facNoPagas.cantMov >= 5
				ORDER BY facNoPagas.cantMov) top5
		JOIN HHHH.clientes cli
		ON cli.Id_cliente = top5.Id_cliente
	END
GO 


CREATE PROCEDURE HHHH.generarListado1
@anio int,
@primerMes int,
@ultimoMes int
AS

	BEGIN 
	select cli.Nombre,cli.Apellido,top5.TotalMovFact from(
		select top 5 cue.Id_cliente, sum(movFact.cantMov) as TotalMovFact from
			(select mov.Id_cuenta, COUNT (*)as 
			cantMov from HHHH.movimientos mov
			join HHHH.facturas fac
			on mov.Id_factura = fac.Id_factura
			where mov.Id_factura is not null and
			Year(fac.Fecha_factura)=@anio and
			Month(fac.Fecha_factura) between @primerMes and @ultimoMes
			Group by mov.Id_cuenta) movFact
			join HHHH.cuentas cue
			on cue.Id_cuenta = movFact.Id_cuenta
			group by cue.Id_cliente
			order by TotalMovFact desc) top5
			join HHHH.clientes cli
			on top5.Id_cliente = cli.Id_cliente

		END
GO

CREATE PROCEDURE HHHH.generarListado2

@anio int,
@primerMes int,
@ultimoMes int
AS
	BEGIN

	SELECT cli.Nombre, cli.Apellido, trnsxcli.cantTransac FROM
		(SELECT TOP 5 cue.Id_cliente, COUNT(*) AS cantTransac FROM HHHH.cuentas cue
		JOIN  HHHH.transferencias trans 
		on trans.Cuenta_origen = cue.Id_cuenta and
		YEAR (trans.fecha_transferencia)=@anio and
		MONTH (trans.fecha_transferencia) BETWEEN @primerMes AND @ultimoMes
		where trans.Cuenta_destino = cue.Id_cuenta 
		group by cue.Id_cliente 
		order by cantTransac desc) trnsxcli
			JOIN HHHH.clientes cli
		ON cli.Id_cliente = trnsxcli.Id_cliente

	END
GO

CREATE PROCEDURE HHHH.generarListado3

@anio int,
@primerMes int,
@ultimoMes int
AS
	BEGIN

	SELECT pa.Descripcion AS 'PAIS', pa.Codigo AS 'COD_PAIS', top5.cantMov AS 'CANT MOVIMIENTOS' FROM
		(SELECT top 5 cue.Id_pais, cue.Id_cuenta, cue.Id_cliente, movXcue.cantMov FROM
			(SELECT  mov.Id_cuenta, COUNT (*) AS cantMov FROM HHHH.movimientos mov
				JOIN HHHH.cuentas cue
				ON cue.Id_cuenta = mov.Id_cuenta 
				WHERE YEAR (mov.fecha) = @anio AND
				MONTH (mov.fecha) BETWEEN @primerMes AND @ultimoMes
				GROUP BY mov.Id_cuenta) movXcue
			JOIN HHHH.cuentas cue
			ON movXcue.Id_cuenta = cue.Id_cuenta
			order by movXcue.cantMov desc) top5
		JOIN HHHH.paises pa
		ON top5.Id_pais = pa.Codigo
		
	END
GO

CREATE PROCEDURE HHHH.generarListado4

@anio int,
@primerMes int,
@ultimoMes int
AS
	BEGIN

	SELECT top 5 cueMonTot.Id_cuenta AS 'Cuenta', cueMonTot.MontoTotalxCuenta AS 'MontoTotalFacturado', 
		tcue.Descripcion AS 'TipoCuenta' FROM 
		(SELECT  mov.Id_cuenta, SUM (fac.Monto_total) AS MontoTotalxCuenta FROM HHHH.movimientos mov
		JOIN HHHH.facturas fac
		ON mov.Id_factura = fac.Id_factura
		WHERE mov.Id_factura IS NOT NULL AND
		YEAR (fac.Fecha_factura) = @anio AND
		MONTH (fac.Fecha_factura) BETWEEN @primerMes AND @ultimoMes
		GROUP BY mov.Id_cuenta) cueMonTot
		JOIN HHHH.cuentas cue
		ON cueMonTot.Id_cuenta = cue.Id_cuenta
		JOIN HHHH.tipo_cuenta tcue
		ON tcue.Id_tipo_cuenta=cue.Id_tipo_cuenta
		ORDER BY MontoTotalxCuenta DESC 
		
	END
GO

----------------------------------------------------------------------------------------------
GO







--////////////////////////////////////////


CREATE PROCEDURE HHHH.ObtenerFuncionalidadesDeRol
@id_rol numeric(18,0)
AS
	BEGIN
		SELECT r.Id_funcionalidad,f.Descripcion 
		FROM HHHH.rel_rol_funcionalidad r,HHHH.funcionalidades f 
		WHERE r.Id_funcionalidad=f.Id_funcionalidad AND 
			  r.Id_rol = @id_rol
	END
GO

CREATE PROCEDURE HHHH.ObtenerFuncionalidades
AS
	BEGIN
		SELECT *
		FROM HHHH.funcionalidades
	END
GO

CREATE PROCEDURE HHHH.ObtenerRolesDeUsuario
@Id_usuario numeric(18,0)
AS
	BEGIN
		SELECT r.Id_rol,Nombre_rol 
		FROM HHHH.rel_rol_usuario r,HHHH.roles ro 
		WHERE r.Id_rol=ro.Id_rol AND 
			  ro.Estado = 'A' AND 
			  r.Id_usuario = @Id_usuario
	END
GO

CREATE PROCEDURE HHHH.ObtenerRoles
AS
	BEGIN
		SELECT *
		FROM HHHH.roles
	END
GO

CREATE PROCEDURE HHHH.ObtenerTipoDoc
AS
	BEGIN
		SELECT * 
		FROM HHHH.tipos_documentos
		ORDER BY Descripcion
	END
GO

CREATE PROCEDURE HHHH.ObtenerPaises
AS
	BEGIN
		SELECT * 
		FROM HHHH.paises
		ORDER BY Descripcion
	END
GO

CREATE PROCEDURE HHHH.ObtenerCliente
@Id_cliente numeric(18,0)
AS
	BEGIN
		SELECT * 
		FROM HHHH.clientes
		WHERE Id_cliente = @Id_cliente
	END
GO

CREATE PROCEDURE HHHH.ObtenerClientes
AS
	BEGIN
		SELECT * 
		FROM HHHH.clientes
	END
GO

CREATE PROCEDURE HHHH.ObtenerPreguntas
AS
	BEGIN
		SELECT * 
		FROM HHHH.preguntas
	END
GO

CREATE PROCEDURE HHHH.ObtenerUsuariosClientes
AS
	BEGIN
		SELECT us.*, cli.Id_cliente
		FROM HHHH.usuarios us
		JOIN HHHH.clientes cli
		ON cli.Id_usuario = us.Id_usuario
		ORDER BY us.Usuario
	END
GO

CREATE PROCEDURE HHHH.ObtenerMonedas
AS
	BEGIN
		SELECT * 
		FROM HHHH.Monedas
	END
GO


CREATE PROCEDURE HHHH.ObtenerTipoCuentas
AS
	BEGIN
		SELECT * 
		FROM HHHH.tipo_cuenta
	END
GO

CREATE PROCEDURE HHHH.ObtenerTipoCuentasDistintas
@tipoCuenta varchar(250)
AS
	BEGIN
		SELECT * 
		FROM HHHH.tipo_cuenta
		WHERE Descripcion<>@tipoCuenta
	END
GO

CREATE PROCEDURE HHHH.InformacionTipoCuenta
@cuenta varchar(250)
AS
	BEGIN
		SELECT * 
		FROM HHHH.tipo_cuenta
		WHERE HHHH.tipo_cuenta.Descripcion=@cuenta;
	END
GO

CREATE PROCEDURE HHHH.CalcularCostoProlongacion
@tipoCuenta numeric(18,0),
@suscripciones numeric (4,0)
AS
	BEGIN
	declare @costo numeric (18,2)=((select t.costo_cuenta from HHHH.tipo_cuenta t WHERE t.Id_tipo_cuenta=@tipoCuenta)* @suscripciones )
		select @costo
	END
GO

CREATE PROCEDURE HHHH.ObtenerBancos
@FiltMigracion bit 
AS
	BEGIN
		IF (@FiltMigracion = 1)
			BEGIN
			SELECT DISTINCT Id_banco,b.Descripcion ,b.Calle,b.altura,
								 b.localidad, p.Descripcion DES 
				FROM HHHH.bancos b 
				LEFT JOIN HHHH.paises p 
				ON p.Codigo=Id_pais
				WHERE b.Descripcion <> 'Banco migracion'
			END
		ELSE
			BEGIN
				SELECT DISTINCT Id_banco,b.Descripcion ,b.Calle,b.altura,
								 b.localidad, p.Descripcion DES 
				FROM HHHH.bancos b 
				LEFT JOIN HHHH.paises p 
				ON p.Codigo=Id_pais
			END
	END
GO

CREATE PROCEDURE HHHH.ObtenerTarjeta
@Id_tarjeta numeric(18,0)
AS
	BEGIN
		SELECT Id_banco,Fecha_emision,Fecha_vencimiento 
		FROM hhhh.tarjetas 
		WHERE id_tarjeta = @Id_tarjeta
	END
GO

CREATE PROCEDURE HHHH.ObtenerTarjetasDeCliente
@Id_cliente numeric(18,0)
AS
	BEGIN
		SELECT Id_tarjeta,'XXXX-XXXX-XXXX-'+convert(nvarchar(max),t.finalnumero) AS finalnumero 
		FROM HHHH.tarjetas t 
		WHERE t.estado = 1 and t.Id_cliente= @Id_cliente
	END
GO

CREATE PROCEDURE HHHH.AlterarEstadoTarjeta
@Id_tarjeta numeric(18,0)
AS
	BEGIN
		UPDATE HHHH.tarjetas 
		SET estado = 0 
		WHERE id_tarjeta = @Id_tarjeta
	END
GO

CREATE PROCEDURE HHHH.ObtenerCuentasDeCliente
@Id_cliente numeric(18,0)
AS
	BEGIN

		SELECT cue.*, mon.Descripcion
		FROM HHHH.cuentas cue, HHHH.clientes cli, HHHH.Monedas mon
		WHERE cli.Id_cliente = cue.Id_cliente and 
			  mon.Id_moneda = cue.Id_moneda and
			  cli.Id_cliente = @Id_cliente
	END
GO

CREATE PROCEDURE HHHH.ObtenerTodasCuentas_HoI
AS
	BEGIN

		SELECT DISTINCT c.Id_cuenta,c.Saldo,c.Id_moneda,c.Id_cliente,c.estado,t.Costo_transf,
				t.Id_moneda_transf 
		FROM HHHH.Cuentas c,hhhh.tipo_cuenta t 
		WHERE c.Id_tipo_cuenta = t.Id_tipo_cuenta and c.estado = 'H' or c.estado = 'I'
	END
GO


CREATE PROCEDURE HHHH.Ultimos5Depositos
@Id_cuenta numeric(18,0)
AS
	BEGIN
		SELECT TOP 5 Fecha_deposito, HHHH.impconmoneda(Importe,Id_tipo_moneda) AS Importe,
					 'XXXX-XXXX-XXXX-'+tar.finalnumero AS Tarjeta 
		FROM HHHH.depositos dep, HHHH.tarjetas tar 
		WHERE Id_cuenta = @Id_cuenta and 
				dep.Id_tarjeta = tar.Id_tarjeta
		ORDER BY Fecha_deposito DESC
	END
GO

CREATE PROCEDURE HHHH.Ultimos5Retiros
@Id_cuenta numeric(18,0)
AS
	BEGIN
		SELECT TOP 5 Fecha_retiro, HHHH.impconmoneda(ret.Importe,Id_moneda) AS Importe, ban.Descripcion 
		FROM HHHH.retiros ret
		JOIN HHHH.cheques che
		ON che.Id_cheque = ret.Id_cheque
		JOIN HHHH.bancos ban
		ON che.Id_banco = ban.Id_banco
		WHERE Id_cuenta = @Id_cuenta		
		ORDER BY Fecha_retiro DESC
	END
GO


CREATE PROCEDURE HHHH.Ultimas5Transferencias
@Id_cuenta numeric(18,0)
AS
	BEGIN
		SELECT TOP 10 Fecha_transferencia, HHHH.impconmoneda(Importe,Id_moneda) AS Importe, Cuenta_destino
		FROM HHHH.transferencias 
		WHERE Cuenta_origen = @Id_cuenta
        ORDER BY Fecha_transferencia DESC
    END
GO

CREATE PROCEDURE HHHH.valorParaMiCueneta
@cantPeriodos numeric(3,0),
@cuenta numeric(18,0),
@tipocuenta numeric (18,0)
AS
	BEGIN
		declare @valorenusd numeric (18,2) = (SELECT @cantPeriodos * t.Costo_cuenta
												FROM HHHH.tipo_cuenta t
												where t.Id_tipo_cuenta=@tipocuenta)
		declare @valorMiMon numeric (18,2)=(select HHHH.convertirmoneda(t.Id_moneda_cuenta,c.Id_moneda,@valorenusd) from HHHH.tipo_cuenta t,HHHH.cuentas c)
		select @valorMiMon					
    END
GO


CREATE PROCEDURE HHHH.prolongarCuenta
@Id_cuenta numeric(18,0),
@Cant_suscripcones int,
@fechaActual datetime
AS
	BEGIN
		DECLARE @Duracion int
		DECLARE @Costo numeric(18,2)
		DECLARE @Moneda numeric(18,0)
		DECLARE @tipoCuenta numeric(18,0)
		DECLARE @FechaDeCierre datetime
		
		SELECT @Duracion = tc.Duracion, @Costo = tc.Costo_cuenta,
				@Moneda = cue.Id_moneda, @tipoCuenta = cue.Id_tipo_cuenta,
				@FechaDeCierre = cue.Fecha_cierre
		FROM HHHH.tipo_cuenta tc
		JOIN HHHH.cuentas cue
		ON tc.Id_tipo_cuenta = cue.Id_tipo_cuenta AND
			cue.Id_cuenta = @Id_cuenta

		
		IF (@FechaDeCierre is null or @FechaDeCierre < @fechaActual)
			BEGIN
				UPDATE HHHH.cuentas
				SET Fecha_cierre = DATEADD(day,@Cant_suscripcones * @Duracion,@fechaActual) 
				WHERE Id_cuenta = @Id_cuenta
			END
		ELSE
			BEGIN
				UPDATE HHHH.cuentas
				SET Fecha_cierre = DATEADD(day,@Cant_suscripcones * @Duracion,Fecha_cierre) 
				WHERE Id_cuenta = @Id_cuenta
			END
			
		INSERT INTO HHHH.movimientos(Tipo_movimiento,Costo,Id_moneda,Id_cuenta,Fecha,Dias_comprados,Cambio_tipo_cuenta)
			VALUES('C',@Cant_suscripcones * @Costo, @Moneda, @Id_cuenta, @fechaActual, @Cant_suscripcones * @Duracion,@tipoCuenta)
	END
GO

CREATE PROCEDURE HHHH.cambiarTipoCuenta
@cuenta numeric(18,0),
@tipocuenta numeric (18,0)
AS
	BEGIN
		UPDATE HHHH.cuentas SET Id_tipo_cuenta = @tipocuenta, Fecha_cierre = null
		WHERE Id_cuenta=@cuenta
    END
GO

CREATE PROCEDURE HHHH.cambiarEstadoCuenta
@Id_cuenta numeric(18,0)
AS
	BEGIN
		
		UPDATE HHHH.cuentas
		SET Estado = (select (case when Estado = 'I' then  'H'
									when Estado = 'H' then  'I' 
									else Estado
									end) 
					  from HHHH.cuentas
					  where Id_cuenta = @Id_cuenta)
        WHERE Id_cuenta = @Id_cuenta
	END
GO
