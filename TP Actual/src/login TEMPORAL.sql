drop table logins
drop table usuarios
drop procedure loginProc

CREATE TABLE usuarios(
	id_usuario INT IDENTITY(1,1) PRIMARY KEY,
	usuario NVARCHAR(30) UNIQUE,
	contrasena NVARCHAR(30),
	baja BIT DEFAULT 0,
	habilitado BIT DEFAULT 1
)
INSERT INTO usuarios (usuario,contrasena)
	VALUES ('admin','w23e');
	
CREATE TABLE logins(
	id_usuario INT FOREIGN KEY REFERENCES usuarios(id_usuario),
	fecha DATETIME,
	exito BIT,
	numeroDeFallo INT,
	PRIMARY KEY (id_usuario,fecha)
)	

GO
CREATE PROCEDURE loginProc
    @usu nvarchar(30), 
    @contra nvarchar(30)
AS 
	DECLARE @id_usuario INT
	
	SET @id_usuario = (SELECT id_usuario FROM usuarios WHERE usuario = @usu AND baja = 0)
	IF @id_usuario IS NULL
		BEGIN
			RAISERROR ('No existe ese usuario',16,1)
			RETURN
		END
		
	IF (SELECT habilitado FROM usuarios WHERE id_usuario = @id_usuario) = 0
		BEGIN
			RAISERROR ('Este usuario esta inhabilitado. Contactese con el administrador del sistema.',16,1)
			RETURN
		END
	
	IF (SELECT contrasena FROM usuarios WHERE id_usuario = @id_usuario) = @contra
		BEGIN
			INSERT INTO logins (id_usuario, fecha, exito,numeroDeFallo)
				VALUES (@id_usuario,GETDATE(),1,0)
			SELECT @id_usuario
		END
	ELSE
		BEGIN	
			INSERT INTO logins (id_usuario, fecha, exito,numeroDeFallo)
				VALUES (@id_usuario,GETDATE(),0,(SELECT TOP 1 numeroDeFallo FROM logins WHERE id_usuario = @id_usuario ORDER BY fecha DESC)+1)
				
			RAISERROR ('Contrasena incorrecta',16,1)
			
			IF (SELECT TOP 1 numeroDeFallo FROM logins WHERE id_usuario = @id_usuario ORDER BY fecha DESC) = 3
				BEGIN
					RAISERROR ('Ha introducido su contrasena mal 3 veces, por lo que su cuenta se ha inhabilitado. Contacte a un administrador del sistema.',16,1)
					UPDATE usuarios
						SET habilitado = 0
						WHERE id_usuario = @id_usuario
				END
			RETURN
		END
GO