BEGIN /* *************** CREACION DEL SCHENMA *************** */
	IF NOT EXISTS (SELECT [name] FROM [sys].[schemas] WHERE [name] = 'nuestrogrupo')
		EXECUTE ('CREATE SCHEMA nuestrogrupo AUTHORIZATION gd;');		--nombre del grupo?
END
GO

BEGIN /* *************** BORRADO DE TABLAS *************** */
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'logins')
		DROP TABLE logins;
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'usuarios')
		DROP TABLE usuarios;
END
GO

BEGIN /* *************** CREACION DE TABLAS *************** */
	CREATE TABLE usuarios(
		id_usuario INT IDENTITY(1,1) PRIMARY KEY,
		usuario NVARCHAR(30) UNIQUE,
		contrasena CHAR(44) NOT NULL,
		intentosFallidos INT DEFAULT 0,
		estado NVARCHAR DEFAULT 'H' CHECK (estado IN ('H','I','B')) -- habilitado, inhabilitado, baja
	)

	CREATE TABLE logins(
		id_usuario INT FOREIGN KEY REFERENCES usuarios(id_usuario),
		fecha DATETIME,
		exito BIT,
		numeroDeFallo INT,
		PRIMARY KEY (id_usuario,fecha)
	)
END
GO

BEGIN /* *************** MIGRACION *************** */
	INSERT INTO usuarios (usuario,contrasena)
		VALUES ('admin','5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=');
END
GO

BEGIN /* *************** BORRADO DE STORED PROCEDURES *************** */
	IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='loginProc')
		DROP PROCEDURE loginProc;
END
GO

/* *************** CREACION DE STORED PROCEDURES *************** */
CREATE PROCEDURE loginProc
    @usu nvarchar(30), 
    @contra char(44)
AS 
	DECLARE @id_usuario INT
	
	SET @id_usuario = (SELECT id_usuario FROM usuarios WHERE usuario = @usu AND estado != 'B')
	IF @id_usuario IS NULL
		BEGIN
			RAISERROR ('No existe ese usuario',16,1)
			RETURN
		END
		
	IF (SELECT estado FROM usuarios WHERE id_usuario = @id_usuario) = 'I'
		BEGIN
			RAISERROR ('Este usuario esta inhabilitado. Contacte a un administrador del sistema.',16,1)
			RETURN
		END
	
	IF (SELECT contrasena FROM usuarios WHERE id_usuario = @id_usuario) = @contra
		BEGIN
			INSERT INTO logins (id_usuario, fecha, exito,numeroDeFallo)
				VALUES (@id_usuario,GETDATE(),1,0)
			UPDATE usuarios
				SET intentosFallidos = 0
				WHERE id_usuario = @id_usuario
			SELECT @id_usuario			 --devuelvo el numero de usuario para agregarlo a la sesion
		END
	ELSE
		BEGIN	
			UPDATE usuarios
				SET intentosFallidos = intentosFallidos + 1
				WHERE id_usuario = @id_usuario
				
			INSERT INTO logins (id_usuario, fecha, exito,numeroDeFallo)
				VALUES (@id_usuario,GETDATE(),0,(SELECT intentosFallidos FROM usuarios WHERE id_usuario = @id_usuario))
					
			RAISERROR ('Contrasena incorrecta.',16,1)
			
			IF (SELECT intentosFallidos FROM usuarios WHERE id_usuario = @id_usuario) = 3
				BEGIN
					RAISERROR ('Ha introducido su contrasena mal 3 veces, por lo que su cuenta se ha inhabilitado. Contacte a un administrador del sistema.',16,1)
					UPDATE usuarios
						SET estado = 'I'
						WHERE id_usuario = @id_usuario
				END
			RETURN
		END
GO