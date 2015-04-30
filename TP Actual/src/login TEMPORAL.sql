drop table logins
drop table usuarios
drop procedure loginProc

CREATE TABLE usuarios(
	id_usuario INT IDENTITY(1,1) PRIMARY KEY,
	usuario NVARCHAR(30) UNIQUE,
	contrasena NVARCHAR(30)
)
INSERT INTO usuarios (usuario,contrasena)
	VALUES ('admin','w23e');
	
CREATE TABLE logins(
	id_usuario INT FOREIGN KEY REFERENCES usuarios(id_usuario),
	fecha DATETIME,
	exito BIT,
	PRIMARY KEY (id_usuario,fecha)
)	
	

GO
CREATE PROCEDURE loginProc
    @usu nvarchar(30), 
    @contra nvarchar(30)
AS 
	DECLARE @id_usuario INT
	
	SET @id_usuario = (SELECT id_usuario FROM usuarios WHERE usuario = @usu)
	IF @id_usuario IS NULL
		BEGIN
			RAISERROR ('No existe ese usuario',16,-1)
			RETURN
		END
	
	IF EXISTS (SELECT 1 FROM usuarios WHERE id_usuario = @id_usuario AND contrasena = @contra) 
		INSERT INTO logins (id_usuario, fecha, exito)
				VALUES (@id_usuario,GETDATE(),1)
	ELSE
		BEGIN	
			INSERT INTO logins (id_usuario, fecha, exito)
				VALUES (@id_usuario,GETDATE(),0)
			RAISERROR ('Contrasena incorrecta',16,-1)
			RETURN
		END
GO