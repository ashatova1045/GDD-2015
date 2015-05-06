USE GD1C2015

BEGIN /* *************** CREACION DEL SCHENMA *************** */
	IF NOT EXISTS (SELECT [name] FROM [sys].[schemas] WHERE [name] = 'HHHH')
		EXECUTE ('CREATE SCHEMA HHHH AUTHORIZATION gd;');		--nombre del grupo?
END
GO

BEGIN /* *************** BORRADO DE TABLAS *************** */
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HHHH' AND TABLE_NAME = 'logins')
		DROP TABLE HHHH.logins;
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HHHH' AND TABLE_NAME = 'usuarios')
		DROP TABLE HHHH.usuarios;
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HHHH' AND TABLE_NAME = 'paises')
		DROP TABLE HHHH.paises;
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HHHH' AND TABLE_NAME = 'clientes')
		DROP TABLE HHHH.clientes;
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HHHH' AND TABLE_NAME = 'cuentas')
		DROP TABLE HHHH.cuentas;
END
GO

BEGIN /* *************** CREACION DE TABLAS *************** */
	CREATE TABLE HHHH.usuarios(
		id_usuario INT IDENTITY(1,1) PRIMARY KEY,
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
	Id_cliente int IDENTITY(1,1) primary key,
	Id_usuario int,
	Nombre varchar(255),
	Apellido varchar(255),
	Documento varchar(10) not null,
	Id_tipo_documento int not null,
	Mail varchar(255),
	Id_pais numeric(18,0) not null,
	Altura int,
	Calle varchar(255),
	Piso int,
	Departamento varchar(10),
	Id_localidad numeric(18,0),
	Id_nacionalidad numeric(18,0),
	Fecha_nacimiento datetime,
	Estado char(1)
	)
	
	CREATE TABLE HHHH.cuentas(
	id_cuenta numeric(18,0) not null primary key,
	id_pais numeric(18,0),
	id_moneda numeric(18,0),
	fecha_apertura datetime,
	id_tipo_cuenta numeric(18,0),
	id_cliente int not null,
	id_estado char(1),
	saldo numeric(18,0)
	)
	
	
	CREATE TABLE HHHH.logins(
		id_usuario INT FOREIGN KEY REFERENCES HHHH.usuarios(id_usuario),
		fecha DATETIME,
		exito BIT,
		numeroDeFallo INT,
		PRIMARY KEY (id_usuario,fecha)
	)
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
		
	INSERT INTO HHHH.clientes(Id_pais, Nombre, Apellido, Id_tipo_documento, Documento, Mail,
				 Altura, Calle, Piso, Departamento, Fecha_nacimiento)
		SELECT  DISTINCT Cli_Pais_Codigo, Cli_Nombre, Cli_Apellido, 
			Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc, Cli_Mail,
			Cli_Dom_Nro, Cli_Dom_Calle,
			Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac
		FROM gd_esquema.Maestra

	INSERT INTO Cuentas(id_cuenta, id_pais, fecha_apertura, id_cliente, id_estado)
		SELECT DISTINCT M.Cuenta_Numero, M.Cuenta_Pais_Codigo, M.Cuenta_Fecha_Creacion, 
				C.Id_cliente, M.Cuenta_Estado
		FROM gd_esquema.Maestra M, HHHH.clientes C
		WHERE C.Mail = M.Cli_Mail

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
