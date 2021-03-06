USE GD2C2014
GO

SET LANGUAGE Spanish

/*	****************************************	CREACION DEL SCHENMA	*********************************************** */

IF NOT EXISTS (SELECT 1 FROM [sys].[schemas] WHERE [name] = 'ELITE4')
	EXECUTE ('CREATE SCHEMA ELITE4 AUTHORIZATION gd;');
GO

/*	****************************************	BORRADO DE OBJETOS	******************************************* */

--Tienen FK a alguna tabla
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND TABLE_NAME = 'Rol_Por_Funcionalidad')
	DROP TABLE ELITE4.Rol_Por_Funcionalidad;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Funcionalidad')
	DROP TABLE ELITE4.Funcionalidad;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Baja_Hotel')
	DROP TABLE ELITE4.Baja_Hotel;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Regimen_Por_Hotel')
	DROP TABLE ELITE4.Regimen_Por_Hotel;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND TABLE_NAME = 'Cliente_Por_Estadia')
	DROP TABLE ELITE4.Cliente_Por_Estadia;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Historial_De_Modificacion_De_Reservas')
	DROP TABLE ELITE4.Historial_De_Modificacion_De_Reservas;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Facturacion_Por_Consumible')
	DROP TABLE ELITE4.Facturacion_Por_Consumible;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4'	 AND  TABLE_NAME = 'Consumible_Por_Estadia')
	DROP TABLE ELITE4.Consumible_Por_Estadia;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Estadia_Por_Habitacion')
	DROP TABLE ELITE4.Estadia_Por_Habitacion;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Reserva_Por_Habitacion_Por_Estadia')
	DROP TABLE ELITE4.Reserva_Por_Habitacion_Por_Estadia;	
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Reserva_Cancelada')
	DROP TABLE ELITE4.Reserva_Cancelada;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Usuario_Por_Hotel_Rol')
	DROP TABLE ELITE4.Usuario_Por_Hotel_Rol;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Usuario')
	DROP TABLE ELITE4.Usuario;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Estado_Reserva')
	DROP TABLE ELITE4.Estado_Reserva;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Rol')
	DROP TABLE ELITE4.Rol;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Item_Factura')
	DROP TABLE ELITE4.Item_Factura;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Factura')
	DROP TABLE ELITE4.Factura;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Estadia')
	DROP TABLE ELITE4.Estadia;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Item_Facturaaux')
	DROP TABLE ELITE4.Item_Facturaaux;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Reserva_Por_Habitacion')
	DROP TABLE ELITE4.Reserva_Por_Habitacion
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Habitacion')
	DROP TABLE ELITE4.Habitacion;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Habitacion_Tipo')
	DROP TABLE ELITE4.Habitacion_Tipo;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Reserva')
	DROP TABLE ELITE4.Reserva;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Regimen') 
	DROP TABLE ELITE4.Regimen;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Consumible')
	DROP TABLE ELITE4.Consumible;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Cliente')
	DROP TABLE ELITE4.Cliente;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Pasaporte_Tipo')
	DROP TABLE ELITE4.Pasaporte_Tipo;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'ELITE4' AND  TABLE_NAME = 'Hotel')
	DROP TABLE ELITE4.Hotel;
GO


/*	****************************************	CREACION DE LAS TABLAS	*********************************************** */

	
CREATE TABLE ELITE4.Pasaporte_Tipo
   (Pasaporte_Tipo				INT IDENTITY(1,1),
   Pasaporte_Tipo_Descripcion	nvarchar(10),
   PRIMARY KEY(Pasaporte_Tipo));	
	


CREATE TABLE ELITE4.Hotel(
	Hotel_ID 					INT IDENTITY(1,1),
	Hotel_Ciudad 				NVARCHAR(255),
	Hotel_Calle 				NVARCHAR(255),
	Hotel_Nro_Calle 			NUMERIC(18,0),									
	Hotel_CantEstrella 			NUMERIC(18,0),
	Hotel_Recarga_Estrella 		NUMERIC(18,0),
	Hotel_Fecha_Creacion 		DATETIME,
	Hotel_Pais 					NVARCHAR(60) DEFAULT 'ARGENTINA',
	Hotel_Nombre 				NVARCHAR(60),
	Hotel_Mail 					NVARCHAR(60),
	Hotel_Telefono 				NUMERIC(18,0),
	Hotel_Habilitado			BIT DEFAULT 1 NOT NULL,
	PRIMARY KEY (Hotel_ID)
	);

CREATE TABLE ELITE4.Habitacion_Tipo(
	Habitacion_Tipo_Codigo 		NUMERIC(18,0),
	Habitacion_Tipo_Descripcion NVARCHAR(255) NOT NULL,
	Habitacion_Tipo_Porcentual 	NUMERIC(18,2) NOT NULL,
	Habitacion_Tipo_Habilitado	BIT DEFAULT 1 ,
	PRIMARY KEY (Habitacion_Tipo_Codigo)
	);

CREATE TABLE ELITE4.Habitacion(
	Habitacion_Numero 			NUMERIC(18,0),
	Hotel_ID					INT, 
	Habitacion_Piso 			NUMERIC(18,0),
	Habitacion_Habilitada 		BIT DEFAULT 1,
	Habitacion_Tipo_Codigo 		NUMERIC(18,0) NOT NULL, 
	Habitacion_Frente 			NVARCHAR(50),
	PRIMARY KEY (Habitacion_Numero, Hotel_ID),
	FOREIGN KEY (Hotel_ID) REFERENCES ELITE4.Hotel(Hotel_ID) ,
	FOREIGN KEY (Habitacion_Tipo_Codigo) REFERENCES ELITE4.Habitacion_Tipo(Habitacion_Tipo_Codigo)
	);
	
CREATE TABLE ELITE4.Cliente(
	Cliente_id					INT IDENTITY(1,1),
	Pasaporte_Tipo 				INT  NOT NULL DEFAULT 1,
	Cliente_Pasaporte_Numero	NUMERIC(18,0) NOT NULL,
	Cliente_Mail 				NVARCHAR(255) NOT NULL,
	Cliente_Apellido 			NVARCHAR(255) NOT NULL,
	Cliente_Nombre 				NVARCHAR(255) NOT NULL,
	Cliente_Fecha_Nac			DATETIME NOT NULL,     					
	Cliente_Dom_Calle 			NVARCHAR(255) NOT NULL,
	Cliente_Nro_Calle 			NUMERIC(18,0) NOT NULL,
	Cliente_Piso 				NUMERIC(18,0),
	Cliente_Depto 				NVARCHAR(50),
	Cliente_Nacionalidad 		NVARCHAR(255) NOT NULL,
	Cliente_Ciudad 				NVARCHAR(255),
	Cliente_Pais_Residencia 	NVARCHAR(255),
	Cliente_Tarjeta_Credito 	NUMERIC(18,0),
	Cliente_Habilitado			BIT DEFAULT 1,
	PRIMARY KEY (Cliente_id),
	FOREIGN KEY (Pasaporte_Tipo) REFERENCES ELITE4.Pasaporte_Tipo(Pasaporte_Tipo),
	);

CREATE TABLE ELITE4.Rol(
	Rol_Cod 					INT IDENTITY(1,1),
	Rol_Nombre					NVARCHAR(50) NOT NULL,					
	Rol_Habilitado				BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (Rol_Cod)
	);
	
CREATE TABLE ELITE4.Funcionalidad(
	Funcionalidad_Cod			TINYINT ,
	Funcionalidad_Descripcion	NVARCHAR(50) NOT NULL,
	Funcionalidad_Habilitada	BIT DEFAULT 1 NOT NULL,
	PRIMARY KEY (Funcionalidad_Cod)
	);

CREATE TABLE ELITE4.Rol_Por_Funcionalidad(
	Rol_Cod								INT,
	Funcionalidad_Cod					TINYINT,
	Rol_Por_Funcionalidad_Habilitado	BIT DEFAULT 1,	
	PRIMARY KEY (Rol_Cod, Funcionalidad_Cod),
	FOREIGN KEY (Rol_Cod) REFERENCES ELITE4.Rol(Rol_Cod),
	FOREIGN KEY (Funcionalidad_Cod) REFERENCES ELITE4.Funcionalidad(Funcionalidad_Cod)
	);

CREATE TABLE ELITE4.Usuario(
	Usuario_ID 					INT IDENTITY(0,1),
	Usuario_Username			NVARCHAR(30) NOT NULL,
	Usuario_Contrasena			CHAR(44) NOT NULL,
	Pasaporte_Tipo 				INT DEFAULT 1, 
	Usuario_Numero_Doc 			NUMERIC(18,0),
	Usuario_Direccion 			NVARCHAR(60),
	Usuario_Fecha_Nacimiento 	DATETIME,
	Usuario_Habilitado			BIT NOT NULL DEFAULT 1,
	Usuario_Nombre				NVARCHAR(30),
	Usuario_Apellido			NVARCHAR(30),
	Usuario_mail				NVARCHAR(30),
	Usuario_Telefono			NUMERIC(18,0)	
	PRIMARY KEY (Usuario_ID),
	FOREIGN KEY(Pasaporte_Tipo) REFERENCES ELITE4.Pasaporte_Tipo(Pasaporte_Tipo),
	UNIQUE (Usuario_Username),
	UNIQUE (Pasaporte_Tipo,Usuario_Numero_Doc)
	);
	
CREATE TABLE ELITE4.Usuario_Por_Hotel_Rol(
	Usuario_ID 					INT,
	Rol_Cod						INT,
	Hotel_ID 					INT,
	Habilitado					BIT DEFAULT 1
	PRIMARY KEY(Usuario_ID,Rol_Cod,Hotel_ID),
	FOREIGN KEY (Usuario_ID) REFERENCES ELITE4.Usuario(Usuario_ID),
	FOREIGN KEY (Rol_Cod) REFERENCES ELITE4.Rol(Rol_Cod),
	FOREIGN KEY (Hotel_ID) REFERENCES ELITE4.Hotel(Hotel_ID)
	);
		
CREATE TABLE ELITE4.Regimen (
	Regimen_Cod 				INT IDENTITY(1,1),
	Regimen_Precio 				NUMERIC(18,2) NOT NULL,
	Regimen_Descripcion 		NVARCHAR(255) NOT NULL,
	Regimen_Habilitado 			BIT NOT NULL DEFAULT 1
	PRIMARY KEY (Regimen_Cod)
	);

CREATE TABLE ELITE4.Reserva (
	Reserva_Codigo 				NUMERIC(18,0) IDENTITY(1,1),
	Hotel_ID 					INT,
	Reserva_Fecha_Inicio 		DATETIME NOT NULL,
	Reserva_Fecha_Fin	 		DATETIME NOT NULL,				
	Reserva_Estado_Descripcion 	NVARCHAR(60) DEFAULT 'Reserva correcta',			
	Regimen_Cod 				INT,
	Cliente						INT NOT NULL,
	PRIMARY KEY (Reserva_Codigo),
	FOREIGN KEY (Hotel_ID) REFERENCES ELITE4.Hotel(Hotel_ID),
	FOREIGN KEY (Regimen_Cod) REFERENCES ELITE4.Regimen(Regimen_Cod),
	FOREIGN KEY (Cliente) REFERENCES ELITE4.Cliente(Cliente_ID)
	);

CREATE TABLE ELITE4.Historial_De_Modificacion_De_Reservas(
	Reserva_Codigo 				NUMERIC(18,0),
	Hotel_ID					INT,
	Modificacion_Fecha	 		DATETIME NOT NULL,
	Usuario_ID_Que_Modifico 	INT,
	PRIMARY KEY (Reserva_Codigo),
	FOREIGN KEY (Reserva_Codigo) REFERENCES ELITE4.Reserva(Reserva_Codigo),
	FOREIGN KEY (Usuario_ID_Que_Modifico) REFERENCES ELITE4.Usuario(Usuario_ID),
	);
	
CREATE TABLE ELITE4.Estadia (
	Reserva_Codigo 				NUMERIC(18,0) NOT NULL,
	Estadia_Fecha_Fin	 		DATETIME,
	PRIMARY KEY (Reserva_Codigo),
	FOREIGN KEY (Reserva_Codigo) REFERENCES ELITE4.Reserva(Reserva_Codigo)
	);

CREATE TABLE ELITE4.Reserva_Por_Habitacion(
	Reserva_Codigo		NUMERIC(18,0) NOT NULL,
	Habitacion_Numero	NUMERIC(18,0) NOT NULL,
	Hotel_ID			INT	NOT NULL,
	Checkin				BIT NOT NULL DEFAULT 0,
	PRIMARY KEY (Reserva_Codigo,Habitacion_Numero,Hotel_ID),
	FOREIGN KEY(Reserva_Codigo) REFERENCES ELITE4.Reserva(Reserva_Codigo),
	FOREIGN KEY (Habitacion_Numero,Hotel_ID) REFERENCES ELITE4.Habitacion(Habitacion_Numero,Hotel_ID)
	);

CREATE TABLE ELITE4.Regimen_Por_Hotel (
	Hotel_ID 					INT,
	Regimen_Codigo 				INT,
	PRIMARY KEY (Hotel_Id,Regimen_Codigo),
	FOREIGN KEY (Hotel_ID) REFERENCES ELITE4.Hotel(Hotel_ID),
	FOREIGN KEY (Regimen_Codigo) REFERENCES ELITE4.Regimen(Regimen_Cod)
	);
	
CREATE TABLE ELITE4.Factura(
	Factura_Numero 				NUMERIC(18,0) IDENTITY(1,1),
	Reserva_Codigo 				NUMERIC(18,0) NOT NULL,
	Factura_Fecha 				DATETIME NOT NULL,
	Factura_Total				NUMERIC(18,0) DEFAULT 0,
	Cliente						INT NOT NULL,
	PRIMARY KEY (Factura_Numero),
	FOREIGN KEY(Cliente) REFERENCES ELITE4.Cliente(Cliente_ID),
	FOREIGN KEY (Reserva_Codigo) REFERENCES ELITE4.Estadia(Reserva_Codigo)
	);

CREATE TABLE ELITE4.Consumible(
	Consumible_Codigo			NUMERIC(18,0) NOT NULL,
	Consumible_Precio 			NUMERIC(18,2) NOT NULL,
	Consumible_Descripcion 		NVARCHAR(255) NOT NULL,
	PRIMARY KEY(Consumible_Codigo)
	);

CREATE TABLE ELITE4.Item_Factura(
	Item_id						INT IDENTITY(1,1),
	Factura						NUMERIC(18,0),
	--consumible, si es null es porque es una estadia
	Consumible_Codigo 			NUMERIC(18,0),
	
	--estadia
	Reserva_Codigo				NUMERIC(18,0) NOT NULL,
	Habitacion_Numero			NUMERIC(18,0) NOT NULL,
	Hotel_ID					INT NOT NULL,
	
	Precio			 			NUMERIC(18,2) NOT NULL,
	Cantidad					NUMERIC(18,0) NOT NULL DEFAULT 1,
	PRIMARY KEY(Item_id),
	FOREIGN KEY(Reserva_Codigo,Habitacion_Numero,Hotel_ID) REFERENCES ELITE4.Reserva_Por_Habitacion(Reserva_Codigo,Habitacion_Numero,Hotel_ID),
	FOREIGN KEY(Consumible_Codigo) REFERENCES ELITE4.Consumible(Consumible_Codigo),
	FOREIGN KEY(Factura) REFERENCES ELITE4.Factura(Factura_Numero)
	);
	
CREATE TABLE ELITE4.Item_FacturaAux(
	Item_id						INT IDENTITY(1,1),
	Consumible_Codigo 			NUMERIC(18,0),
	
	--estadia
	Reserva_Codigo				NUMERIC(18,0) NOT NULL,
	Habitacion_Numero			NUMERIC(18,0) NOT NULL,
	Hotel_ID					INT NOT NULL,
	
	Precio			 			NUMERIC(18,2) NOT NULL,
	Cantidad					NUMERIC(18,0) NOT NULL DEFAULT 1,
	PRIMARY KEY(Item_id),
	FOREIGN KEY(Reserva_Codigo,Habitacion_Numero,Hotel_ID) REFERENCES ELITE4.Reserva_Por_Habitacion(Reserva_Codigo,Habitacion_Numero,Hotel_ID),
	FOREIGN KEY(Consumible_Codigo) REFERENCES ELITE4.Consumible(Consumible_Codigo),
	);

CREATE TABLE ELITE4.Baja_Hotel (
	Hotel_ID 				INT,
	Baja_Hotel_Fecha 			DATETIME,
	Fin_Baja_Hotel_Fecha 		DATETIME,
	Baja_Hotel_Descripcion 		NVARCHAR(100),
	PRIMARY KEY (Hotel_ID,Baja_Hotel_Fecha),
	FOREIGN KEY (Hotel_ID) REFERENCES ELITE4.Hotel(Hotel_ID)
	);

CREATE TABLE ELITE4.Reserva_Cancelada (
	Reserva_Codigo 				NUMERIC(18,0),
	Reserva_Cancelada_Desc 		NVARCHAR(100) NOT NULL,
	Hotel_ID 					INT ,
	Usuario_ID 					INT ,
	Reserva_Cancelada_Fecha 	DATETIME NOT NULL,
	Rol_Cod 					INT,
	PRIMARY KEY (Reserva_Codigo),
	FOREIGN KEY (Reserva_Codigo) REFERENCES ELITE4.Reserva(Reserva_Codigo),
	FOREIGN KEY (Usuario_ID,Rol_Cod,Hotel_ID) REFERENCES ELITE4.Usuario_Por_Hotel_Rol(Usuario_ID,Rol_Cod,Hotel_ID)
	);
		
GO


IF OBJECT_ID (N'ELITE4.menorfecha', N'FN') IS NOT NULL
    DROP FUNCTION ELITE4.menorfecha;
go
CREATE FUNCTION ELITE4.menorfecha (@fecha1 DATETIME,@fecha2 DATETIME)
	RETURNS DATETIME
	AS
	BEGIN
		DECLARE @fecha DATETIME;
		IF @fecha1<@fecha2
			SET @fecha =@fecha1;
		ELSE
			SET @fecha =@fecha2;
	RETURN @fecha;
	END;
go
 
IF OBJECT_ID (N'ELITE4.mayorfecha', N'FN') IS NOT NULL
    DROP FUNCTION ELITE4.mayorfecha;
go
CREATE FUNCTION ELITE4.mayorfecha (@fecha1 DATETIME,@fecha2 DATETIME)
	RETURNS DATETIME
	AS
	BEGIN
		DECLARE @fecha DATETIME;
		IF @fecha1>@fecha2
			SET @fecha =@fecha1;
		ELSE
			SET @fecha =@fecha2;
	RETURN @fecha;
	END;
go
--FUNCIONES:----------------------------------------------------------------------------------------------------
/*IF OBJECT_ID (N'ELITE4.monto_Total_Facturacion', N'IF') IS NOT NULL
-- deletes function
    DROP FUNCTION ELITE4.monto_Total_Facturacion;
go
---FUNCION PARA CALCULAR EL MONTO TOTAL DE LA FACTURA: HAY QUE HACER LA IMPLEMENTACION CUIDADOSAMENTE VIENDO CON QUE ITEMS CALCULAR LA SUMA

CREATE FUNCTION ELITE4.monto_Total_Facturacion(@reservaCod NUMERIC(18,0))

	
RETURNS NUMERIC(18,0)
AS
BEGIN

	DECLARE @montoEstadia NUMERIC (18,0),@total NUMERIC(18,0);
	
	--SELECT @montoEstadia=
	--FROM ELITE4.Estadia
	RETURN 0;
END;
go
*/

/*	****************************************	VIEWS 	******************************************* */
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE  TABLE_NAME  = 'habitaciones_habilitadas')
	DROP VIEW ELITE4.habitaciones_habilitadas;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE  TABLE_NAME  = 'Rol_Por_Funcionalidad_habilitados')
	DROP VIEW ELITE4.Rol_Por_Funcionalidad_habilitados;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE  TABLE_NAME  = 'Usuario_Por_Hotel_Rol_habilitados')
	DROP VIEW ELITE4.Usuario_Por_Hotel_Rol_habilitados;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE  TABLE_NAME  = 'Reservas_activas')
	DROP VIEW ELITE4.Reservas_activas;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE  TABLE_NAME  = 'Clientes_Habilitados')
	DROP VIEW ELITE4.Clientes_Habilitados;
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE  TABLE_NAME  = 'Reservasxhab_activas')
	DROP VIEW ELITE4.Reservasxhab_activas;
GO


CREATE VIEW ELITE4.habitaciones_habilitadas AS
	SELECT Habitacion_Numero,ELITE4.Hotel.Hotel_ID,Habitacion_Piso,Habitacion_Tipo_Codigo,Habitacion_Frente
		FROM ELITE4.Habitacion,ELITE4.Hotel
		WHERE ELITE4.Habitacion.Hotel_ID = ELITE4.Hotel.Hotel_ID
		AND ELITE4.Habitacion.Habitacion_Habilitada =1
		AND ELITE4.Hotel.Hotel_Habilitado =1;
GO

CREATE VIEW ELITE4.Rol_Por_Funcionalidad_habilitados AS
	SELECT ELITE4.Rol.Rol_Cod,Funcionalidad_Cod
		FROM ELITE4.Rol_Por_Funcionalidad,ELITE4.Rol
		WHERE ELITE4.Rol_Por_Funcionalidad.Rol_Cod = ELITE4.Rol.Rol_Cod
		AND ELITE4.Rol.Rol_Habilitado = 1;
GO

CREATE VIEW ELITE4.Usuario_Por_Hotel_Rol_habilitados AS
	SELECT ELITE4.Usuario_Por_Hotel_Rol.Hotel_ID,ELITE4.Usuario_Por_Hotel_Rol.Rol_Cod,ELITE4.Usuario_Por_Hotel_Rol.Usuario_ID
		FROM ELITE4.Usuario_Por_Hotel_Rol,ELITE4.Usuario,ELITE4.Hotel,ELITE4.Rol
		WHERE ELITE4.Usuario_Por_Hotel_Rol.Rol_Cod = ELITE4.Rol.Rol_Cod
		AND ELITE4.Usuario_Por_Hotel_Rol.Hotel_ID = ELITE4.Hotel.Hotel_ID
		AND ELITE4.Usuario_Por_Hotel_Rol.Usuario_ID = ELITE4.Usuario.Usuario_ID
		AND ELITE4.Rol.Rol_Habilitado = 1
		AND ELITE4.Hotel.Hotel_Habilitado = 1
		AND ELITE4.Usuario.Usuario_Habilitado = 1;
GO

CREATE VIEW ELITE4.Reservas_activas AS
	SELECT Reserva_Estado_Descripcion,Hotel_ID,Regimen_Cod,Reserva_Codigo,Reserva_Fecha_Fin,Reserva_Fecha_Inicio
		FROM ELITE4.Reserva
		WHERE Reserva_Fecha_Inicio >= GETDATE()
		AND Reserva_Estado_Descripcion NOT LIKE 'Reserva cancelada%';
GO

CREATE VIEW ELITE4.Reservasxhab_activas AS
	SELECT Reserva_Por_Habitacion.Hotel_ID,Reserva_Por_Habitacion.Habitacion_Numero
		FROM ELITE4.Reserva_Por_Habitacion,ELITE4.Reservas_activas
		WHERE Reserva_Por_Habitacion.Reserva_Codigo=Reservas_activas.Reserva_Codigo
		
GO


CREATE VIEW ELITE4.Clientes_Habilitados AS
	SELECT Pasaporte_Tipo,Cliente_Pasaporte_Numero,Cliente_Apellido,Cliente_Nombre,Cliente_Mail,Cliente_Nacionalidad,Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Depto,Cliente_Piso,Cliente_Ciudad,Cliente_Pais_Residencia,Cliente_Fecha_Nac,Cliente_Tarjeta_Credito, Cliente_id
	FROM ELITE4.Cliente
	WHERE Cliente_Habilitado=1;
GO


/* ***************************************** CREACION DE TRIGGERS************************************************** */
/*IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'mail_repetido' AND type = 'TR')
	DROP TRIGGER ELITE4.mail_repetido;*/
IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'delete_habitacion' AND type = 'TR')
	DROP TRIGGER ELITE4.delete_habitacion;
IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'delete_usuario' AND type = 'TR')
	DROP TRIGGER ELITE4.delete_usuario;
IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'delete_rol' AND type = 'TR')
	DROP TRIGGER ELITE4.delete_rol;
IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'delete_reserva' AND type = 'TR')
	DROP TRIGGER ELITE4.delete_reserva; 
GO

/*CREATE TRIGGER ELITE4.mail_repetido
ON ELITE4.Cliente
INSTEAD OF INSERT AS
	BEGIN
		DECLARE @cpre AS BIT,@cmre AS TINYINT;
		DECLARE Cursor_trigger_mail_repetido CURSOR FOR
		SELECT Pasaporte_Tipo,Cliente_Pasaporte_Numero, Cliente_Mail,Cliente_Apellido,Cliente_Nombre,Cliente_Fecha_Nac,Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,Cliente_Nacionalidad,Cliente_Ciudad,Cliente_Pais_Residencia,Cliente_Tarjeta_Credito,Cliente_Puntos FROM inserted
		DECLARE @ctp AS INT,@cpn AS NUMERIC(18,0),@cm AS NVARCHAR(255),@ca AS NVARCHAR(255),@cn AS NVARCHAR(255),@cfn AS DATETIME,@cdm AS NVARCHAR(255),@cnc AS NUMERIC(18,0),@cp AS NUMERIC(18,0),@cd AS NVARCHAR(50),@cna AS NVARCHAR(255),@cc AS NVARCHAR(255),@cpr AS NVARCHAR(255),@ctc AS NUMERIC(18,0),@cpu AS INT
		OPEN Cursor_trigger_mail_repetido;
			FETCH NEXT FROM Cursor_trigger_mail_repetido INTO @ctp,@cpn,@cm,@ca,@cn,@cfn,@cdm,@cnc,@cp,@cd,@cna,@cc,@cpr,@ctc,@cpu
			WHILE @@FETCH_STATUS = 0
			
			
			BEGIN	
				SET @cmre = (SELECT MAX(Cliente_Mail_Repetido)			
							FROM ELITE4.Cliente
							WHERE Cliente_Mail = @cm);
				IF @cmre IS NULL			
					SET @cmre = 0;
				ELSE
					SET @cmre = @cmre +1; 

				IF NOT EXISTS (SELECT 1		
							FROM ELITE4.Cliente
							WHERE Pasaporte_Tipo = @ctp AND  Cliente_Pasaporte_Numero = @cpn)	
					SET @cpre = 0;
				ELSE
					SET @cpre = 1;
					
				INSERT INTO ELITE4.Cliente(Pasaporte_Tipo,Cliente_Pasaporte_Numero, Cliente_Mail,Cliente_Apellido,Cliente_Nombre,Cliente_Fecha_Nac,Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,Cliente_Nacionalidad,Cliente_Ciudad,Cliente_Pais_Residencia,Cliente_Tarjeta_Credito,Cliente_Puntos,Cliente_Pasaporte_repetido,Cliente_Mail_Repetido) VALUES
						(@ctp,@cpn,@cm,@ca,@cn,@cfn,@cdm,@cnc,@cp,@cd,@cna,@cc,@cpr,@ctc,@cpu,@cpre,@cmre);
				
				
				FETCH NEXT FROM Cursor_trigger_mail_repetido INTO @ctp,@cpn,@cm,@ca,@cn,@cfn,@cdm,@cnc,@cp,@cd,@cna,@cc,@cpr,@ctc,@cpu
			END;
			
		CLOSE Cursor_trigger_mail_repetido;
		DEALLOCATE Cursor_trigger_mail_repetido;
	END;
GO
*/

/*-cuando borro un hotel se supone que las habitaciones de ese hotel se deshabilitan.
pero si lo vuelvo a habilitar, no puedo habilitar todas las habitaciones de ese hotel
(no se cuales se deshabilitaron porque borre el hotel y cuales estaban deshabilitadas de antes)
podria poner un bit que me indique si esta deshabilitada porque se borro el hotel,
pero me parece mas simple fijarme en la tabla hoteles si el hotel esta deshabilitado
(ni siquiera tengo que hacer un join, ya tengo el Hotel_ID)
*/


CREATE TRIGGER ELITE4.delete_habitacion
ON ELITE4.Habitacion
INSTEAD OF DELETE AS
	UPDATE ELITE4.Habitacion SET Habitacion_Habilitada = 0
		FROM ELITE4.Habitacion,deleted
		WHERE ELITE4.Habitacion.Habitacion_Numero = deleted.Habitacion_Numero AND ELITE4.Habitacion.Hotel_ID = deleted.Hotel_ID;
GO

CREATE TRIGGER ELITE4.delete_rol
ON ELITE4.Rol
INSTEAD OF DELETE AS
	BEGIN
		UPDATE ELITE4.Rol SET Rol_Habilitado = 0
			FROM ELITE4.Rol,deleted
			WHERE ELITE4.Rol.Rol_Cod = deleted.Rol_Cod;
		
		DELETE ELITE4.Rol_Por_Funcionalidad
			FROM ELITE4.Rol_Por_Funcionalidad,deleted
			WHERE ELITE4.Rol_Por_Funcionalidad.Rol_Cod = deleted.Rol_Cod;
	END;
GO

CREATE TRIGGER ELITE4.delete_usuario
ON ELITE4.Usuario
INSTEAD OF DELETE AS
	BEGIN
		UPDATE ELITE4.Usuario SET Usuario_habilitado = 0
			FROM ELITE4.Usuario,deleted
			WHERE ELITE4.Usuario.Usuario_ID = deleted.Usuario_ID;
	END;
GO


CREATE TRIGGER ELITE4.delete_reserva
ON ELITE4.Reserva
INSTEAD OF DELETE AS
	BEGIN
		INSERT INTO ELITE4.Reserva_Cancelada (Reserva_Codigo/*,Reserva_Cancelada_Desc*/,Hotel_ID/*,Usuario_ID*/,Reserva_Cancelada_Fecha/*,Rol_Cod*/)
			SELECT Reserva_Codigo/*,Reserva_Cancelada_Desc*/,Hotel_ID,/*,Usuario_ID,*/GETDATE()/*,Rol_Cod*/
			FROM deleted;
	END;
GO

/*	****************************************	MIGRACION 	******************************************* */
INSERT INTO ELITE4.Pasaporte_Tipo(Pasaporte_Tipo_Descripcion) VALUES
	('ARGENTINO'),
	('ITALIANO'),
	('COLOMBIA'),
	('ESPANA');

INSERT INTO ELITE4.Hotel (Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella, Hotel_Recarga_Estrella)
SELECT  DISTINCT Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella, Hotel_Recarga_Estrella
FROM gd_esquema.Maestra;
UPDATE ELITE4.Hotel set Hotel_Nombre ='Hotel ' + CAST(Hotel_ID as nvarchar(5));
--select * from ELITE4.Hotel

INSERT INTO ELITE4.Habitacion_Tipo (Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra;
--select * from ELITE4.Habitacion_Tipo

INSERT INTO ELITE4.Habitacion (Hotel_ID, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, Habitacion_Tipo_Codigo)
SELECT DISTINCT Hotel_ID, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, Habitacion_Tipo_Codigo
FROM gd_esquema.Maestra JOIN ELITE4.Hotel
	ON (gd_esquema.Maestra.Hotel_Calle = ELITE4.Hotel.Hotel_Calle
		AND gd_esquema.Maestra.Hotel_Nro_Calle = ELITE4.Hotel.Hotel_Nro_Calle);
--select * from ELITE4.Habitacion

INSERT INTO ELITE4.Consumible (Consumible_Codigo, Consumible_Precio, Consumible_Descripcion)
SELECT  DISTINCT Consumible_Codigo, Consumible_Precio, Consumible_Descripcion
FROM gd_esquema.Maestra
WHERE Consumible_Codigo IS NOT NULL;
--select * from ELITE4.Consumible

INSERT INTO ELITE4.Regimen(Regimen_Descripcion, Regimen_Precio)
SELECT  DISTINCT Regimen_Descripcion, Regimen_Precio
FROM gd_esquema.Maestra;
--select * from ELITE4.Regimen

INSERT INTO ELITE4.Regimen_Por_Hotel (Hotel_ID,Regimen_Codigo)
SELECT DISTINCT Hotel_ID,Regimen_Cod
FROM ELITE4.Hotel,ELITE4.Regimen,gd_esquema.Maestra
WHERE ELITE4.Regimen.Regimen_Descripcion = gd_esquema.Maestra.Regimen_Descripcion
	AND ELITE4.Hotel.Hotel_Nro_Calle = gd_esquema.Maestra.Hotel_Nro_Calle
	AND ELITE4.Hotel.Hotel_Calle = gd_esquema.Maestra.Hotel_Calle;
--SELECT * FROM ELITE4.Regimen_Por_Hotel



INSERT INTO ELITE4.Cliente(Cliente_Pasaporte_Numero,Pasaporte_Tipo, Cliente_Mail,Cliente_Apellido,Cliente_Nombre,Cliente_Fecha_Nac,Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,Cliente_Nacionalidad) 
SELECT DISTINCT Cliente_Pasaporte_Nro,ELITE4.Pasaporte_Tipo.Pasaporte_Tipo,Cliente_Mail,Cliente_Apellido,Cliente_Nombre,Cliente_Fecha_Nac,Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,Cliente_Nacionalidad
FROM gd_esquema.Maestra,ELITE4.Pasaporte_Tipo
WHERE ELITE4.Pasaporte_Tipo.Pasaporte_Tipo_Descripcion=gd_esquema.Maestra.Cliente_Nacionalidad;

--SELECT*FROM ELITE4.Cliente
/*100688 numero de pasaporte distintos
87316 mails distintos

hay 52 numeros de pasaporte repetidos, pero ninguno esta 3 veces
1652782 es un ejemplo de numero de pasaporte repetido con 2 personas

hay 11782 mails repetidos, pero ninguno esta 7 veces
'yenien_Ruiz@gmail.com' es un ejemplo de mail repetido con 6 numeros de pasaporte
*/

SET IDENTITY_INSERT ELITE4.Reserva ON;
INSERT INTO ELITE4.Reserva(Reserva_Codigo, Hotel_ID,Reserva_Fecha_Inicio,Reserva_Fecha_Fin,Regimen_Cod,Cliente) 
SELECT DISTINCT Reserva_Codigo, Hotel_ID,Reserva_Fecha_Inicio,DATEADD(DAY,Reserva_Cant_Noches,Reserva_Fecha_Inicio),ELITE4.Regimen.Regimen_Cod,ELITE4.Cliente.Cliente_id
FROM gd_esquema.Maestra, ELITE4.Hotel,ELITE4.Regimen,ELITE4.Cliente 
WHERE gd_esquema.Maestra.Hotel_Calle=ELITE4.Hotel.Hotel_Calle
	AND gd_esquema.Maestra.Hotel_Nro_Calle=ELITE4.Hotel.Hotel_Nro_Calle
	AND gd_esquema.Maestra.Regimen_Descripcion = ELITE4.Regimen.Regimen_Descripcion
	AND gd_esquema.Maestra.Cliente_Pasaporte_Nro = ELITE4.Cliente.Cliente_Pasaporte_Numero
	AND gd_esquema.Maestra.Cliente_Apellido = ELITE4.Cliente.Cliente_Apellido
	AND gd_esquema.Maestra.Cliente_Mail = ELITE4.Cliente.Cliente_Mail;
SET IDENTITY_INSERT ELITE4.Reserva OFF;
--select * from ELITE4.Reserva

INSERT INTO ELITE4.Estadia(Reserva_Codigo,Estadia_Fecha_Fin) 
SELECT DISTINCT r.Reserva_Codigo,DATEADD(DAY,Estadia_Cant_Noches,m.Estadia_Fecha_Inicio) as fecha_fin_estadia
FROM gd_esquema.Maestra m,ELITE4.Reserva r
WHERE m.Reserva_Codigo=r.Reserva_Codigo AND Estadia_Fecha_Inicio IS NOT NULL
--GROUP BY r.Reserva_Codigo

UPDATE ELITE4.Reserva
	SET Reserva_Estado_Descripcion = 'Reserva cancelada por No-Show'
	FROM ELITE4.Reserva LEFT JOIN ELITE4.Estadia
		ON ELITE4.Reserva.Reserva_Codigo = ELITE4.Estadia.Reserva_Codigo
	WHERE ELITE4.Estadia.Reserva_Codigo IS NULL;
	
INSERT INTO ELITE4.Reserva_Cancelada (Reserva_Codigo,Reserva_Cancelada_Desc,Reserva_Cancelada_Fecha)
	SELECT Reserva_Codigo,Reserva_Estado_Descripcion,Reserva_Fecha_Fin
		FROM ELITE4.Reserva
		WHERE Reserva_Estado_Descripcion = 'Reserva cancelada por No-Show';

INSERT INTO ELITE4.Reserva_Por_Habitacion(Reserva_Codigo,Habitacion_Numero,Hotel_ID)
SELECT DISTINCT r.Reserva_Codigo,h.Habitacion_Numero,h.Hotel_ID
FROM ELITE4.Reserva r,ELITE4.Habitacion h,gd_esquema.Maestra m
WHERE r.Reserva_Codigo=m.Reserva_Codigo AND h.Habitacion_Numero=m.Habitacion_Numero AND h.Hotel_ID=r.Hotel_ID;

UPDATE ELITE4.Reserva_Por_Habitacion
	SET Checkin = 1
	FROM ELITE4.Reserva_Por_Habitacion,ELITE4.Estadia
	WHERE ELITE4.Reserva_Por_Habitacion.Reserva_Codigo = ELITE4.Estadia.Reserva_Codigo;

/*
select * from ELITE4.Reserva
select * from ELITE4.Estadia
select * from ELITE4.Reserva_Por_Habitacion
select * from ELITE4.Reserva_Por_Habitacion where Checkin=1*/

/*INSERT INTO ELITE4.Reserva_Por_Habitacion_Por_Estadia(Habitacion_Numero,Reserva_Codigo,Hotel_ID)
SELECT  h.Habitacion_Numero,e.Reserva_Codigo,r.Hotel_ID
FROM /*gd_esquema.Maestra m,*/ELITE4.Estadia e,ELITE4.Reserva r,ELITE4.Habitacion h
WHERE  h.Hotel_ID=r.Hotel_ID AND r.Reserva_Codigo is not null AND e.Reserva_Codigo=r.Reserva_Codigo
order by r.Hotel_ID,h.Habitacion_Numero,e.Reserva_Codigo;
*/
--select*
--from ELITE4.Reserva_Por_Habitacion_Por_Estadia

SET IDENTITY_INSERT ELITE4.Factura ON;
INSERT INTO ELITE4.Factura(Factura_Numero,Reserva_Codigo,Factura_Fecha,Cliente)
	SELECT DISTINCT Factura_Nro,Reserva_Codigo,Factura_Fecha,ELITE4.Cliente.Cliente_id
		FROM gd_esquema.Maestra,ELITE4.Cliente
		WHERE ELITE4.Cliente.Cliente_Pasaporte_Numero = gd_esquema.Maestra.Cliente_Pasaporte_Nro
			AND ELITE4.Cliente.Cliente_Mail =gd_esquema.Maestra.Cliente_Mail
			AND ELITE4.Cliente.Cliente_Apellido =gd_esquema.Maestra.Cliente_Apellido --no se cuanto de esto se necesita
			AND Factura_Nro IS NOT NULL; 
SET IDENTITY_INSERT ELITE4.Factura OFF;

INSERT INTO ELITE4.Item_Factura(Factura,Consumible_Codigo,Reserva_Codigo,Habitacion_Numero,Hotel_ID,Precio,Cantidad) --agrego los consumibles
	SELECT Factura_Nro,Consumible_Codigo,Reserva_Codigo,Habitacion_Numero,ELITE4.Hotel.Hotel_ID,Consumible_Precio,Item_Factura_Cantidad
		FROM gd_esquema.Maestra,ELITE4.Hotel
		WHERE gd_esquema.Maestra.Hotel_Calle =ELITE4.Hotel.Hotel_Calle
			AND gd_esquema.Maestra.Hotel_Nro_Calle =ELITE4.Hotel.Hotel_Nro_Calle
			AND Factura_Nro IS NOT NULL
			AND Consumible_Codigo IS NOT NULL
			AND Estadia_Fecha_Inicio IS NOT NULL;
			
SELECT Reserva_Codigo,SUM(Cantidad*Precio) total
		INTO #aux 	
		FROM ELITE4.Item_Factura
		GROUP BY Reserva_Codigo	;	

UPDATE ELITE4.Factura
	SET Factura_Total = total
	FROM ELITE4.Factura,#aux
		WHERE Factura.Reserva_Codigo = #aux.Reserva_Codigo;
		
DROP TABLE #aux;
	
INSERT INTO ELITE4.Item_Factura(Factura,Reserva_Codigo,Habitacion_Numero,Hotel_ID,Precio,Cantidad) --agrego las estadias
	SELECT DISTINCT Factura_Nro,Reserva_Codigo,Habitacion_Numero,ELITE4.Hotel.Hotel_ID,Item_Factura_Monto,Estadia_Cant_Noches
		FROM gd_esquema.Maestra,ELITE4.Hotel
		WHERE gd_esquema.Maestra.Hotel_Calle =ELITE4.Hotel.Hotel_Calle
			AND gd_esquema.Maestra.Hotel_Nro_Calle =ELITE4.Hotel.Hotel_Nro_Calle
			and Factura_Nro IS NOT NULL
			AND Consumible_Codigo IS NULL
			AND Estadia_Fecha_Inicio IS NOT NULL;

--select * from ELITE4.Item_Factura

GO
/* ***************************************** INICIALIZACION DE DATOS ************************************************** */


SET IDENTITY_INSERT ELITE4.Rol ON;
INSERT INTO ELITE4.Rol (Rol_Cod,Rol_Nombre) VALUES 
	(1,'Administrador'),
	(2,'Recepcionista'),
	(3,'Guest');				--hardcodeo los codigos para hacer mas simple el insert de funcionalidad
SET IDENTITY_INSERT ELITE4.Rol OFF;

INSERT INTO ELITE4.Funcionalidad(Funcionalidad_Cod,Funcionalidad_Descripcion) VALUES 
	(1,'ABM de Usuario'),
	(2,'ABM de Cliente'),
	(3,'ABM de Hotel'),
	(4,'ABM de Habitacion'),
	(6,'ABM de Reserva'),
	(7,'Check In'),
	(8,'ABM de Rol'),
	(9,'Listados Estadisticos'),
	(10,'Registrar consumibles'),
	(11,'Facturar/Checkout');

INSERT INTO ELITE4.Rol_Por_Funcionalidad (Rol_Cod, Funcionalidad_Cod) VALUES
	(1,1),
	(2,2),
	(1,3),
	(1,4),
	(2,6),
	(3,6),
	(2,7),
	(1,8),
	(1,9),
	(2,10),
	(2,11);
	
SET IDENTITY_INSERT ELITE4.Usuario ON;
INSERT INTO ELITE4.Usuario (Usuario_ID,Usuario_Username,Usuario_Contrasena,Usuario_Numero_Doc,Pasaporte_Tipo) VALUES 
	(1,'guest','hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=',456,1), --contrasena guest
	(2,'admin','5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=',123,1); --contrasena w23e
SET IDENTITY_INSERT ELITE4.Usuario OFF;

INSERT INTO ELITE4.Usuario_Por_Hotel_Rol (Hotel_ID,Rol_Cod,Usuario_ID) 
	SELECT DISTINCT Hotel_ID,1,2
		FROM ELITE4.Hotel
INSERT INTO ELITE4.Usuario_Por_Hotel_Rol (Hotel_ID,Rol_Cod,Usuario_ID) 
		SELECT DISTINCT Hotel_ID,3,1
		FROM ELITE4.Hotel
GO

/* ***************************************** STORED PROCEDURES ************************************************** */
IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spNuevoHotel')
	DROP PROCEDURE ELITE4.spNuevoHotel;
IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spTiposDeHab')
	DROP PROCEDURE ELITE4.spTiposDeHab;
IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spNuevoRol')
	DROP PROCEDURE ELITE4.spNuevoRol;
IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spNuevoRolPorUsuario')
	DROP PROCEDURE ELITE4.spNuevoRolPorUsuario;
IF EXISTS (SELECT 1 FROM SYS.sysobjects WHERE name= 'spModificarCliente')
	DROP PROCEDURE ELITE4.spModificarCliente;
IF EXISTS (SELECT 1 FROM SYS.sysobjects WHERE name= 'spModificarHabitacion')
	DROP PROCEDURE ELITE4.spModificarHabitacion;
IF EXISTS (SELECT 1 FROM SYS.sysobjects WHERE name= 'spRoles')
	DROP PROCEDURE ELITE4.spRoles;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spLoginUsuario')
	DROP PROCEDURE ELITE4.spLoginUsuario;
go
CREATE PROCEDURE ELITE4.spLoginUsuario
    @usuario nvarchar(30), 
    @pass char(44) 
AS 
    SELECT Usuario_ID
		FROM ELITE4.Usuario
		WHERE Usuario_Username = @usuario AND Usuario_Contrasena = @pass AND Usuario_Habilitado = 1;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spHotelesUsuario')
	DROP PROCEDURE ELITE4.spHotelesUsuario;
go
CREATE PROCEDURE ELITE4.spHotelesUsuario
    @usuario_id INT
AS 
    SELECT ELITE4.Usuario_Por_Hotel_Rol_habilitados.Hotel_ID,Hotel_Nombre
		FROM ELITE4.Usuario_Por_Hotel_Rol_habilitados,ELITE4.Hotel
		WHERE ELITE4.Usuario_Por_Hotel_Rol_habilitados.Usuario_ID = @usuario_id
		AND ELITE4.Usuario_Por_Hotel_Rol_habilitados.Hotel_ID=ELITE4.Hotel.Hotel_ID;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spRolesUsuario')
	DROP PROCEDURE ELITE4.spRolesUsuario;
go
CREATE PROCEDURE ELITE4.spRolesUsuario
    @usuario_id INT,
    @hotel_id INT
AS 
    SELECT ELITE4.Usuario_Por_Hotel_Rol_habilitados.Rol_Cod,Rol_Nombre
		FROM ELITE4.Usuario_Por_Hotel_Rol_habilitados,ELITE4.Rol
		WHERE ELITE4.Usuario_Por_Hotel_Rol_habilitados.Usuario_ID = @usuario_id
		AND ELITE4.Usuario_Por_Hotel_Rol_habilitados.Hotel_ID=@hotel_id
		AND ELITE4.Usuario_Por_Hotel_Rol_habilitados.Rol_Cod=ELITE4.Rol.Rol_Cod;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spObtenerTipoDeHabitaciones')
	DROP PROCEDURE ELITE4.spObtenerTipoDeHabitaciones;
GO
CREATE PROCEDURE ELITE4.spObtenerTipoDeHabitaciones
    @hotel_id INT
AS 
	SELECT DISTINCT Habitacion_Tipo_Descripcion, habitaciones_habilitadas.Habitacion_Tipo_Codigo
	FROM ELITE4.habitaciones_habilitadas JOIN ELITE4.Habitacion_Tipo ON (habitaciones_habilitadas.Habitacion_Tipo_Codigo = Habitacion_Tipo.Habitacion_Tipo_Codigo)
	WHERE Hotel_ID = @hotel_id
GO


IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spFuncDelRol')
	DROP PROCEDURE ELITE4.spFuncDelRol;
go
CREATE PROCEDURE ELITE4.spFuncDelRol
    @rol INT
AS 
    SELECT Funcionalidad.Funcionalidad_Descripcion,Funcionalidad.Funcionalidad_Cod
		FROM ELITE4.Rol_Por_Funcionalidad_habilitados,ELITE4.Funcionalidad
		WHERE ELITE4.Rol_Por_Funcionalidad_habilitados.Rol_Cod = @rol
		AND ELITE4.Rol_Por_Funcionalidad_habilitados.Funcionalidad_Cod=ELITE4.Funcionalidad.Funcionalidad_Cod;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spFunc')
	DROP PROCEDURE ELITE4.spFunc;
go
CREATE PROCEDURE ELITE4.spFunc
AS 
    SELECT Funcionalidad_Descripcion,Funcionalidad_Cod
		FROM ELITE4.Funcionalidad;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spNuevoUsuario')
	DROP PROCEDURE ELITE4.spNuevoUsuario;
go
CREATE PROCEDURE ELITE4.spNuevoUsuario
    @tipodoc				INT,
    @ndoc					NUMERIC(18,0),
    @user					NVARCHAR(30),
    @pass					CHAR(44),
    @nac					DATETIME,
    @direccion				NVARCHAR(60),
    @mail					NVARCHAR(30),
    @nombre					NVARCHAR(30),
    @apellido				NVARCHAR(30),
    @telefono				NUMERIC(18,0)
AS 
    INSERT INTO ELITE4.Usuario (Pasaporte_Tipo,Usuario_Numero_Doc,Usuario_Username,Usuario_Contrasena,Usuario_Fecha_Nacimiento,Usuario_Direccion,Usuario_mail,Usuario_Nombre,Usuario_Apellido,Usuario_Telefono)
		VALUES (@tipodoc,@ndoc,@user,@pass,@nac,@direccion,@mail,@nombre,@apellido,@telefono);
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spNuevoCliente')
	DROP PROCEDURE ELITE4.spNuevoCliente;
go
CREATE PROCEDURE ELITE4.spNuevoCliente
    @tipodoc				INT,
    @ndoc					NUMERIC(18,0),
    @apellido				NVARCHAR(255),
    @nombre					NVARCHAR(255),
    @mail					NVARCHAR(255),
    @tcred					NUMERIC(18,0),
    @nacimiento				DATETIME,
    @paisN					NVARCHAR(255),
    @paisR					NVARCHAR(255),
    @ciudad					NVARCHAR(255),
    @calle					NVARCHAR(255),
    @ncalle					NUMERIC(18,0),
    @depto					NVARCHAR(50),
    @piso					NUMERIC(18,0)
AS 
    INSERT INTO ELITE4.Cliente(Pasaporte_Tipo,Cliente_Pasaporte_Numero,Cliente_Apellido,Cliente_Nombre,Cliente_Mail,Cliente_Tarjeta_Credito,Cliente_Fecha_Nac,Cliente_Nacionalidad,Cliente_Pais_Residencia,Cliente_Ciudad,Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Depto,Cliente_Piso)
		VALUES (@tipodoc,@ndoc,@apellido,@nombre,@mail,@tcred,@nacimiento,@paisN,@paisR,@ciudad,@calle,@ncalle,@depto,@piso);
GO

CREATE PROCEDURE ELITE4.spNuevoHotel
    @ciudad				NVARCHAR(255),
    @calle				NVARCHAR(255),
    @ncalle				NUMERIC(18,0),
    @estrellas			NUMERIC(18,0),
    @restrellas			NUMERIC(18,0),
    @pais				NVARCHAR(60),
    @nombre				NVARCHAR(60),
    @mail				NVARCHAR(60),
    @telefono			NUMERIC(18,0)
AS 
    INSERT INTO ELITE4.Hotel (Hotel_Ciudad,Hotel_Calle,Hotel_Nro_Calle,Hotel_CantEstrella,Hotel_Recarga_Estrella,Hotel_Pais,Hotel_Nombre,Hotel_Mail,Hotel_Telefono,Hotel_Fecha_Creacion)
		VALUES (@ciudad,@calle,@ncalle,@estrellas,@restrellas,@pais,@nombre,@mail,@telefono,GETDATE());
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'nuevoTipoPas')
	DROP PROCEDURE ELITE4.nuevoTipoPas;
go
CREATE PROCEDURE ELITE4.nuevoTipoPas
    @pas				NVARCHAR(255)
AS 
    IF NOT EXISTS (SELECT 1 FROM ELITE4.Pasaporte_Tipo WHERE Pasaporte_Tipo_Descripcion = @pas)
		INSERT INTO ELITE4.Pasaporte_Tipo(Pasaporte_Tipo_Descripcion)
			VALUES (@pas);
GO


CREATE PROCEDURE ELITE4.spTiposDeHab
AS 
    SELECT Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion 
		FROM ELITE4.Habitacion_Tipo;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spObetenerTipoPasaportes')
	DROP PROCEDURE ELITE4.spObetenerTipoPasaportes;
go

CREATE PROCEDURE ELITE4.spObetenerTipoPasaportes
AS 
    SELECT Pasaporte_Tipo,Pasaporte_Tipo_Descripcion
		FROM ELITE4.Pasaporte_Tipo;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spNuevaHabitacion')
	DROP PROCEDURE ELITE4.spNuevaHabitacion;
GO

CREATE PROCEDURE ELITE4.spNuevaHabitacion
    @numero				NUMERIC(18,0),
    @piso				NUMERIC(18,0),
    @tipo				NUMERIC(18,0),
    @frente				BIT,
    @habilitado			BIT,
    @hotel				INT
AS 
	DECLARE @frentenvarchar AS NVARCHAR(50);	--para que quede con el mismo formato que la maestra
	IF @frente = 1
		SET @frentenvarchar = 'S'
	ELSE
		SET @frentenvarchar = 'N'
		
    INSERT INTO ELITE4.Habitacion(Habitacion_Numero,Hotel_ID,Habitacion_Piso,Habitacion_Habilitada,Habitacion_Tipo_Codigo,Habitacion_Frente)
		VALUES (@numero,@hotel,@piso,@habilitado,@tipo,@frentenvarchar);
GO

CREATE PROCEDURE ELITE4.spNuevoRol
    @nombre				NVARCHAR(50),
    @activo				BIT
AS 
	INSERT INTO ELITE4.Rol(Rol_Nombre,Rol_Habilitado)
		VALUES (@nombre,@activo);
	
	INSERT INTO ELITE4.Rol_Por_Funcionalidad (Funcionalidad_Cod,Rol_Cod,Rol_Por_Funcionalidad_Habilitado)
		SELECT Funcionalidad_Cod,Rol_Cod,0
			FROM ELITE4.Rol,ELITE4.Funcionalidad
			WHERE Rol_Nombre=@nombre;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'habODeshabFuncporRol')
	DROP PROCEDURE ELITE4.habODeshabFuncporRol;
go
CREATE PROCEDURE ELITE4.habODeshabFuncporRol
    @nombre				NVARCHAR(50),
    @funcionalidad		TINYINT,
    @habilitado			BIT
AS 
	UPDATE ELITE4.Rol_Por_Funcionalidad
		SET Rol_Por_Funcionalidad_Habilitado=@habilitado
		WHERE Rol_Cod = (SELECT Rol_Cod FROM ELITE4.ROL WHERE ROL_NOMBRE =@nombre)
			AND Funcionalidad_Cod = @funcionalidad;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spRoles')
	DROP PROCEDURE ELITE4.spRoles;
go

CREATE PROCEDURE ELITE4.spRoles
AS 
    SELECT Rol_Cod,Rol_Nombre
		FROM ELITE4.Rol
		WHERE ELITE4.Rol.Rol_Habilitado =1;
GO

CREATE PROCEDURE ELITE4.spNuevoRolPorUsuario
@rol			INT,
@hotel_actual	INT,
@nombreUsuario	NVARCHAR(30)
AS 
    INSERT INTO ELITE4.Usuario_Por_Hotel_Rol (Hotel_ID,Rol_Cod,Usuario_ID)
		SELECT @hotel_actual,@rol, Usuario_ID
			FROM ELITE4.Usuario
			WHERE ELITE4.Usuario.Usuario_Username=@nombreUsuario;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spRegimenesPorHotel')
	DROP PROCEDURE ELITE4.spRegimenesPorHotel;
GO
CREATE PROCEDURE ELITE4.spRegimenesPorHotel
    @hotel_id INT
AS 
    SELECT ELITE4.Regimen.Regimen_Descripcion,Regimen.Regimen_Cod
	FROM ELITE4.Regimen_Por_Hotel JOIN ELITE4.Regimen ON (Regimen_Por_Hotel.Regimen_Codigo = Regimen.Regimen_Cod)
	WHERE ELITE4.Regimen_Por_Hotel.Hotel_ID = @hotel_id AND ELITE4.Regimen.Regimen_Habilitado = 1
GO

--MODICICACIONES:
CREATE PROCEDURE ELITE4.spModificarCliente
	@clienteID				INT,
	@tipodoc				INT,
	@ndoc					NUMERIC(18,0),
	@apellido				NVARCHAR(255),
	@nombre					NVARCHAR(255),
	@mail					NVARCHAR(255),
	@nacimiento				DATETIME,
	@paisN					NVARCHAR(255),
	@paisR					NVARCHAR(255),
	@ciudad					NVARCHAR(255),
	@calle					NVARCHAR(255),
	@ncalle					NUMERIC(18,0),
	@depto					NVARCHAR(50),
	@piso					NUMERIC(18,0),
	@tarjetaCredito			NUMERIC(18,0),
	@habilitado				BIT
AS
	BEGIN
	
	
	
		UPDATE Cliente
		SET Cliente_Nombre=@nombre,
			Cliente_Apellido=@apellido,
			Cliente_Mail=@mail,
			Cliente_Fecha_Nac=@nacimiento,
			Cliente_Nacionalidad=@paisN,
			Cliente_Pais_Residencia=@paisR,
			Cliente_Ciudad=@ciudad,
			Cliente_Dom_Calle=@ncalle,
			Cliente_Piso=@piso,
			Cliente_Tarjeta_Credito=@tarjetaCredito,
			Cliente_Habilitado=@habilitado
			
		WHERE Cliente_id=@clienteID 
	END;
GO

CREATE PROCEDURE ELITE4.spModificarHabitacion
	@numhab			NUMERIC(18,0),
	@piso			NUMERIC(18,0),
	@tipo			NUMERIC(18,0),
	@frente			BIT,
	@habilitado		BIT,
	@hotel			INT
	
AS 
	BEGIN
		
		UPDATE ELITE4.Habitacion 
		
		SET	  Habitacion_Piso=@piso,
			  Habitacion_Tipo_Codigo=@tipo,
			  Habitacion_Frente=@frente,
			  Habitacion_Habilitada=@habilitado
		
		WHERE Habitacion_Numero=@numhab AND
			  Hotel_ID=@hotel;
			  
		 
	END;

go

IF EXISTS (SELECT 1 FROM SYS.sysobjects WHERE name= 'getfuncporrolhab')
	DROP PROCEDURE ELITE4.getfuncporrolhab;	
go
CREATE PROCEDURE ELITE4.getfuncporrolhab
			@codigo_rol INT
AS 
	SELECT Funcionalidad_Cod 
		FROM ELITE4.Rol_Por_Funcionalidad
		WHERE Rol_Por_Funcionalidad_Habilitado=1
			AND Rol_Cod=@codigo_rol;
go

IF EXISTS (SELECT 1 FROM SYS.sysobjects WHERE name= 'spDarBajaCliente')
	DROP PROCEDURE ELITE4.spDarBajaCliente;	
go
CREATE PROCEDURE ELITE4.spDarBajaCliente
			@clienteid INT
AS 
	BEGIN
	
	DECLARE @estaHabilitado BIT;
	
	SELECT @estaHabilitado=cliente_Habilitado
	FROM ELITE4.Cliente
	WHERE @clienteid=Cliente_id
	
	IF @estaHabilitado=1	
		BEGIN
	
			UPDATE ELITE4.Cliente
			SET Cliente_Habilitado=0
			WHERE @clienteid=Cliente_id
		END;
		
	END;
go
	
IF EXISTS (SELECT 1 FROM SYS.sysobjects WHERE name= 'ObtenerPasDescripcion')
	DROP PROCEDURE ELITE4.ObtenerPasDescripcion;	
go
CREATE PROCEDURE ELITE4.ObtenerPasDescripcion
			@pasDes nvarchar(10)
AS 
	SELECT Pasaporte_Tipo
	FROM ELITE4.Pasaporte_Tipo
	WHERE @pasDes=Pasaporte_Tipo_Descripcion;		
go

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'ObtenerClientesRepetidos')
	DROP PROCEDURE ELITE4.ObtenerClientesRepetidos;
GO
CREATE PROCEDURE ELITE4.ObtenerClientesRepetidos
    @tdoc	INT,
    @ndoc	NUMERIC(18,0),
    @mail	NVARCHAR(255)
AS 
    SELECT 1
		FROM ELITE4.Cliente
		WHERE (ELITE4.Cliente.Pasaporte_Tipo = @tdoc
			AND ELITE4.Cliente.Cliente_Pasaporte_Numero = @ndoc)
			OR ELITE4.Cliente.Cliente_Mail = @mail
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'ObtenerUsuariosRepetidos')
	DROP PROCEDURE ELITE4.ObtenerUsuariosRepetidos;
GO
CREATE PROCEDURE ELITE4.ObtenerUsuariosRepetidos
    @tdoc	INT,
    @ndoc	NUMERIC(18,0),
    @user	NVARCHAR(30),
    @mail	NVARCHAR(30)
AS 
    SELECT 1
		FROM ELITE4.Usuario
		WHERE (ELITE4.Usuario.Pasaporte_Tipo = @tdoc
			AND ELITE4.Usuario.Usuario_Numero_Doc = @ndoc)
			OR ELITE4.Usuario.Usuario_Username= @user
			OR ELITE4.Usuario.Usuario_mail= @mail;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'ObtenerHabitacionesRepetidas')
	DROP PROCEDURE ELITE4.ObtenerHabitacionesRepetidas;
GO
CREATE PROCEDURE ELITE4.ObtenerHabitacionesRepetidas
    @n	NUMERIC(18,0),
    @p	NUMERIC(18,0),
    @h	INT
AS 
    SELECT 1
		FROM ELITE4.Habitacion
		WHERE Habitacion_Numero = @n
			AND Habitacion_Piso = @p
			AND Hotel_ID= @h;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'ObtenerHotelesRepetidos')
	DROP PROCEDURE ELITE4.ObtenerHotelesRepetidos;
GO
CREATE PROCEDURE ELITE4.ObtenerHotelesRepetidos
	@ciudad			NVARCHAR(255),
	@calle			NVARCHAR(255),
	@ncalle			NUMERIC(18,0),
	@pais			NVARCHAR(60),
	@nombre			NVARCHAR(60),
	@mail			NVARCHAR(60),
	@telefono		NUMERIC(18,0)
	
AS 
    SELECT 1
		FROM ELITE4.Hotel
		WHERE (@ciudad = Hotel_Ciudad
			AND @calle = Hotel_Calle
			AND @ncalle = Hotel_Nro_Calle
			AND @pais = Hotel_Pais)
			OR @nombre = Hotel_Nombre
			OR @mail = Hotel_Mail
			OR @telefono = Hotel_Telefono
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'SP_listar')
	DROP PROCEDURE ELITE4.SP_listar;
GO
CREATE PROCEDURE ELITE4.SP_listar
	@ano			INT,
	@trimestre		INT,
	@eleccion		INT
AS				
	DECLARE @FECHAINICIO DATETIME;
	DECLARE @FECHAFIN DATETIME;
	DECLARE @CANTDIAS TINYINT;
	DECLARE @MESINICIAL TINYINT;
	DECLARE @MESFINAL TINYINT;
	SET @MESFINAL = @trimestre*3;
	SET @MESINICIAL = (@trimestre-1)*3+1;
	SET @CANTDIAS = CASE	WHEN @MESFINAL IN (1,3,5,7,8,10,12) THEN 31
							WHEN @MESFINAL IN (4,6,9,11) THEN 30
							ELSE 28
					END;
	SET @FECHAINICIO = CAST(RTRIM(@ano*10000+@MESINICIAL*100+1)AS DATETIME)
	SET @FECHAFIN = CAST(RTRIM(@ano*10000+@MESFINAL*100+@CANTDIAS)AS DATETIME)
	
    IF @eleccion =0									--no me deja usar case
		SELECT TOP 5 Hotel_Nombre
			FROM ELITE4.Reserva_Cancelada rc,ELITE4.Hotel h,ELITE4.Reserva r
			WHERE rc.Reserva_Codigo=r.Reserva_Codigo
				AND h.Hotel_ID=r.Hotel_ID
				AND Reserva_Cancelada_Fecha BETWEEN @FECHAINICIO AND @FECHAFIN
			GROUP BY Hotel_Nombre
			ORDER BY COUNT(DISTINCT rc.Reserva_Codigo) DESC;
			
	IF @eleccion =1
		SELECT TOP 5 Hotel.Hotel_Nombre
			FROM ELITE4.Item_Factura,ELITE4.Factura,ELITE4.Hotel
			WHERE Hotel.Hotel_ID=Item_Factura.Hotel_ID
				AND Factura_Fecha BETWEEN @FECHAINICIO AND @FECHAFIN
				AND Item_Factura.Factura=Factura.Factura_Numero
				AND Item_Factura.Consumible_Codigo IS NULL
			GROUP BY Hotel_Nombre
			ORDER BY COUNT(Item_id) DESC; 
		
	IF @eleccion =2
		BEGIN
			SELECT TOP 5 Hotel.Hotel_Nombre
				FROM ELITE4.Hotel,ELITE4.Baja_Hotel b
				WHERE Hotel.Hotel_ID=b.Hotel_ID
					AND @FECHAINICIO <= Fin_Baja_Hotel_Fecha
					AND	@FECHAFIN >= Baja_Hotel_Fecha	
				GROUP BY Hotel_Nombre
				ORDER BY SUM(DATEDIFF(DAY,ELITE4.menorfecha(@FECHAINICIO,Baja_Hotel_Fecha),ELITE4.mayorfecha(@FECHAFIN,Fin_Baja_Hotel_Fecha))							)
					DESC;
		END;
		
	IF @eleccion =3	
		SELECT TOP 5 Habitacion_Numero,Hotel_Nombre
			FROM ELITE4.Reserva_Por_Habitacion,ELITE4.Reserva,ELITE4.Estadia,ELITE4.Hotel
			WHERE Reserva.Hotel_ID=Hotel.Hotel_ID
				AND Reserva.Reserva_Codigo=Reserva_Por_Habitacion.Reserva_Codigo
				AND Estadia.Reserva_Codigo=Reserva.Reserva_Codigo
				AND Hotel.Hotel_ID=Reserva.Hotel_ID
				AND Checkin =1
				AND @FECHAINICIO <= Estadia_Fecha_Fin
				AND @FECHAFIN >= Reserva_Fecha_Inicio	
			GROUP BY Habitacion_Numero,Hotel.Hotel_Nombre
			ORDER BY SUM(DATEDIFF(DAY,ELITE4.menorfecha(@FECHAINICIO,Reserva_Fecha_Inicio),ELITE4.menorfecha(@FECHAINICIO,Reserva_Fecha_Inicio)))
				DESC;
		
	IF @eleccion =4	
		BEGIN
			SELECT Cliente_id,Cantidad*Precio/10 puntos		--meto los puntos de las estadias
				INTO #puntos
				FROM ELITE4.Item_Factura,ELITE4.Factura,ELITE4.Cliente
				WHERE Factura_Fecha BETWEEN @FECHAINICIO AND @FECHAFIN
					AND Item_Factura.Factura=Factura.Factura_Numero
					AND Factura.Cliente=Cliente.Cliente_id
					AND Item_Factura.Consumible_Codigo IS NULL
			UNION ALL
			SELECT Cliente_id,Cantidad*Precio/5 puntos		--meto los puntos de los consumibles
				FROM ELITE4.Item_Factura,ELITE4.Factura,ELITE4.Cliente
				WHERE Factura_Fecha BETWEEN @FECHAINICIO AND @FECHAFIN
					AND Item_Factura.Factura=Factura.Factura_Numero
					AND Factura.Cliente=Cliente.Cliente_id
					AND Item_Factura.Consumible_Codigo IS NOT NULL				
				
			SELECT TOP 5 Pasaporte_Tipo.Pasaporte_Tipo_Descripcion,Cliente_Pasaporte_Numero,Cliente_Mail
				FROM ELITE4.Pasaporte_Tipo,ELITE4.Cliente,#puntos
				WHERE Cliente.Pasaporte_Tipo = Pasaporte_Tipo.Pasaporte_Tipo
					AND #puntos.Cliente_id=Cliente.Cliente_id
				GROUP BY Pasaporte_Tipo.Pasaporte_Tipo_Descripcion,Cliente_Pasaporte_Numero,Cliente_Mail
				ORDER BY SUM(#puntos.puntos) DESC; 
			
			DROP TABLE #puntos
		END
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spBajaLogicaRol')
	DROP PROCEDURE ELITE4.spBajaLogicaRol;
GO

CREATE PROCEDURE ELITE4.spBajaLogicaRol
			@Rol_Cod INT,
			@hab		BIT
AS 
	UPDATE ELITE4.Rol
		SET Rol_Habilitado=@hab
		WHERE @Rol_Cod=Rol_Cod

go

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spObtenerCliente')
	DROP PROCEDURE ELITE4.spObtenerCliente;
GO

CREATE PROCEDURE ELITE4.spObtenerCliente
			@Pasaporte_Tipo INT, 
			@Cliente_Pasaporte_Numero NUMERIC,
			@Cliente_Mail NVARCHAR(255) 

AS 

IF @Cliente_Pasaporte_Numero = 0

BEGIN

SELECT Pasaporte_Tipo, Cliente_Pasaporte_Numero, Cliente_Mail, Cliente_id
FROM ELITE4.Clientes_Habilitados
WHERE Pasaporte_Tipo = @Pasaporte_Tipo AND Cliente_Mail = @Cliente_Mail

END

ELSE

BEGIN

SELECT Pasaporte_Tipo, Cliente_Pasaporte_Numero, Cliente_Mail, Cliente_id
FROM ELITE4.Clientes_Habilitados
WHERE Pasaporte_Tipo = @Pasaporte_Tipo AND Cliente_Pasaporte_Numero = @Cliente_Pasaporte_Numero OR Cliente_Mail = @Cliente_Mail	

END

GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spNuevaReserva')
	DROP PROCEDURE ELITE4.spNuevaReserva;
GO
CREATE PROCEDURE ELITE4.spNuevaReserva
    @Hotel_ID INT,
    @Reserva_Fecha_Inicio DATETIME,
    @Reserva_Fecha_Fin DATETIME,
    @Regimen_Cod INT,
    @Cliente INT
AS 
INSERT INTO ELITE4.Reserva (Hotel_ID, Reserva_Fecha_Inicio, Reserva_Fecha_Fin, Reserva_Estado_Descripcion, Regimen_Cod, Cliente) VALUES
							(@Hotel_ID, @Reserva_Fecha_Inicio, @Reserva_Fecha_Fin, 'Reserva correcta', @Regimen_Cod, @Cliente)
SELECT Reserva_Codigo
FROM ELITE4.Reserva
WHERE Hotel_ID = @Hotel_ID AND Reserva_Fecha_Inicio = @Reserva_Fecha_Inicio AND Reserva_Fecha_Fin = @Reserva_Fecha_Fin AND Regimen_Cod = @Regimen_Cod AND Cliente = @Cliente
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spNuevaReservaPorHabitacion')
	DROP PROCEDURE ELITE4.spNuevaReservaPorHabitacion;
GO
CREATE PROCEDURE ELITE4.spNuevaReservaPorHabitacion
	@Reserva_Codigo NUMERIC(18,0),
	@Habitacion_Numero NUMERIC(18,0),
	@Hotel_ID INT
AS
INSERT INTO ELITE4.Reserva_Por_Habitacion (Reserva_Codigo, Habitacion_Numero, Hotel_ID, Checkin) VALUES
											(@Reserva_Codigo, @Habitacion_Numero, @Hotel_ID, 0)
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spModificarRol')
	DROP PROCEDURE ELITE4.spModificarRol;
GO

CREATE PROCEDURE ELITE4.spModificarRol
		@rolCod INT,
		@rolNombre NVARCHAR(120),
		@habilitado BIT
AS
	BEGIN
	
		UPDATE ELITE4.Rol
		SET	ELITE4.Rol.Rol_Nombre=@rolNombre,Rol_Habilitado=@habilitado
		WHERE @rolCod=ELITE4.Rol.Rol_Cod
	 
	END;
GO	
	
IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spModificarRolPorFuncionalidad')
	DROP PROCEDURE ELITE4.spModificarRolPorFuncionalidad;
GO


CREATE PROCEDURE ELITE4.spModificarRolPorFuncionalidad
		@rolCod INT,
		@funcionalidadCod TINYINT,
		@habilitado BIT
		
	AS
	
BEGIN
		IF EXISTS(SELECT 1 FROM ELITE4.Rol_Por_Funcionalidad WHERE Rol_Cod=@rolCod AND Funcionalidad_Cod=@funcionalidadCod) 
		
			BEGIN
			
				UPDATE ELITE4.Rol_Por_Funcionalidad
				SET Rol_Por_Funcionalidad_Habilitado=@habilitado 
				WHERE Rol_Cod=@rolCod AND Funcionalidad_Cod=@funcionalidadCod
			END;
		ELSE
			BEGIN
				INSERT INTO ELITE4.Rol_Por_Funcionalidad(Rol_Cod,Funcionalidad_Cod,Rol_Por_Funcionalidad_Habilitado)
				VALUES(@rolCod,@funcionalidadCod,@habilitado);
			END;
END;

GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'getReservasActuales')
	DROP PROCEDURE ELITE4.getReservasActuales;
GO

CREATE PROCEDURE ELITE4.getReservasActuales
@hotel	int
AS
SELECT Reserva.Reserva_Codigo
	FROM ELITE4.Reserva_Por_Habitacion,ELITE4.Reserva
	WHERE Reserva_Por_Habitacion.Reserva_Codigo=Reserva.Reserva_Codigo
		AND Reserva.Hotel_ID=@hotel
		AND Reserva.Reserva_Estado_Descripcion NOT LIKE 'Reserva cancelada%'
		AND GETDATE() BETWEEN Reserva_Fecha_Inicio AND Reserva_Fecha_Fin
		AND Reserva_Por_Habitacion.Checkin=1;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'getHabReservasActuales')
	DROP PROCEDURE ELITE4.getHabReservasActuales;
GO

CREATE PROCEDURE ELITE4.getHabReservasActuales
@reserva	numeric(18,0)
AS
SELECT Reserva_Por_Habitacion.Habitacion_Numero
	FROM ELITE4.Reserva_Por_Habitacion
	WHERE Reserva_Por_Habitacion.Reserva_Codigo=@reserva;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'getConsumibles')
	DROP PROCEDURE ELITE4.getConsumibles;
GO

CREATE PROCEDURE ELITE4.getConsumibles
AS
SELECT Consumible_Codigo,Consumible_Descripcion
	FROM ELITE4.Consumible;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'checkin')
	DROP PROCEDURE ELITE4.checkin;
GO

CREATE PROCEDURE ELITE4.checkin
@hotel	INT,
@habitacion NUMERIC(18,0),
@reserva NUMERIC(18,0)
AS
	UPDATE ELITE4.Reserva_Por_Habitacion
		SET Checkin=1
		WHERE Reserva_Codigo=@reserva
			AND Habitacion_Numero=@habitacion
			AND	Hotel_ID=@hotel;
			
	INSERT INTO ELITE4.Item_FacturaAux (Reserva_Codigo,Consumible_Codigo,Hotel_ID,Habitacion_Numero,Precio) VALUES
		(@reserva,NULL,@hotel,@habitacion,
		(SELECT Habitacion_Tipo_Porcentual FROM ELITE4.Habitacion_Tipo,ELITE4.Habitacion WHERE Habitacion.Habitacion_Tipo_Codigo=Habitacion_Tipo.Habitacion_Tipo_Codigo AND Habitacion.Hotel_ID=@hotel AND Habitacion.Habitacion_Numero=@habitacion)
		*
		(SELECT Regimen_Precio FROM ELITE4.Reserva,ELITE4.Regimen WHERE Reserva.Regimen_Cod=Regimen.Regimen_Cod AND Reserva.Reserva_Codigo=@reserva)
		+
		(SELECT Hotel_CantEstrella*Hotel_Recarga_Estrella FROM ELITE4.Hotel WHERE Hotel_ID=@hotel));
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'registrarcon')
	DROP PROCEDURE ELITE4.registrarcon;
GO

CREATE PROCEDURE ELITE4.registrarcon
@reserva	numeric(18,0),
@hab		numeric(18,0),
@con		numeric(18,0),
@can		int,
@hotel		int
AS
	INSERT INTO ELITE4.Item_FacturaAux (Reserva_Codigo,Habitacion_Numero,Hotel_ID,Consumible_Codigo,Cantidad,Precio) VALUES
		(@reserva,@hab,@hotel,@con,@can,(select Consumible_Precio from ELITE4.Consumible where Consumible_Codigo = @con));
		
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'crearEstadia')
	DROP PROCEDURE ELITE4.crearEstadia;
GO

CREATE PROCEDURE ELITE4.crearEstadia
@reserva	numeric(18,0)
AS
	INSERT INTO ELITE4.Estadia(Reserva_Codigo,Estadia_Fecha_Fin) VALUES
		(@reserva,NULL);
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spModificarUsuario')
	DROP PROCEDURE ELITE4.spModificarUsuario;
GO

CREATE PROCEDURE ELITE4.spModificarUsuario
		@Id INT,
		@username Nvarchar(30),
		@contrasena char(44)=NULL,
		@tipoPas	INT,
		@nroDoc		numeric(18,0),
		@direccion	nvarchar(60),
		@habilitado BIT,
		@nombre		nvarchar(30),
		@apellido   nvarchar(30),
		@mail		nvarchar(30),
		@telefono	numeric(18,0)=NULL
AS
	DECLARE @NUEVAPASS CHAR(44);
	IF @contrasena IS NOT NULL
		SET @NUEVAPASS = @contrasena
	ELSE
		SET @NUEVAPASS = (SELECT Usuario_Contrasena FROM ELITE4.Usuario WHERE Usuario_ID=@Id);
		
	UPDATE ELITE4.Usuario
		SET Usuario_Username=@username,
			Usuario_Contrasena=@NUEVAPASS,
			Pasaporte_Tipo=@tipoPas,
			Usuario_Numero_Doc=@nroDoc,
			Usuario_Direccion=@direccion,
			Usuario_Habilitado=@habilitado,
			Usuario_Nombre=@nombre,
			Usuario_Apellido=@apellido,
			Usuario_mail=@mail,
			Usuario_Telefono=@telefono
		WHERE Usuario_ID=@Id;
GO	
	
IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spModificarRolPorUsuarioPorHotel')
	DROP PROCEDURE ELITE4.spModificarRolPorUsuarioPorHotel;
GO

CREATE PROCEDURE ELITE4.spModificarRolPorUsuarioPorHotel
		@rolId INT,
		@usuarioId INT,
		@hotelId   INT,
		@habilitado BIT
AS
	BEGIN
		
		UPDATE ELITE4.Usuario_Por_Hotel_Rol
		SET Habilitado=@habilitado
		WHERE Usuario_ID=@usuarioId AND
			  Rol_Cod=@rolId AND
			  Hotel_ID=@hotelId;
				
		
	END;
GO			

/*select* from ELITE4.Usuario				
				
exec ELITE4.spBuscarUsuarios  null,null,null,null,null,null,null*/

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='getconsaux')
		DROP PROCEDURE ELITE4.getconsaux;

GO

CREATE PROCEDURE ELITE4.getconsaux
			@reserva numeric(18,0)
AS
	UPDATE ELITE4.Item_FacturaAux
		SET Cantidad = DATEDIFF(DAY,Reserva.Reserva_Fecha_Inicio,GETDATE())
		FROM ELITE4.Item_FacturaAux,ELITE4.Reserva
		WHERE Item_FacturaAux.Reserva_Codigo=@reserva
			AND Item_FacturaAux.Reserva_Codigo=Reserva.Reserva_Codigo
			AND Consumible_Codigo IS NULL;
			
	DELETE 
		FROM ELITE4.Item_FacturaAux
		WHERE Reserva_Codigo=@reserva
			AND Precio <0;
	
	IF EXISTS (SELECT 1 FROM ELITE4.Reserva WHERE Reserva_Codigo=@reserva AND Regimen_Cod=3)
		INSERT INTO ELITE4.Item_FacturaAux (Reserva_Codigo,Precio,Cantidad,Hotel_ID,Habitacion_Numero,Consumible_Codigo)
			SELECT Reserva_Codigo,Precio*(-1),Cantidad,Hotel_ID,Habitacion_Numero,Consumible_Codigo
				FROM ELITE4.Item_FacturaAux
				WHERE Reserva_Codigo=@reserva
					AND Consumible_Codigo IS NOT NULL
			
	SELECT Consumible_Descripcion,Precio,Cantidad,Habitacion_Numero,Hotel.Hotel_Nombre
		FROM ELITE4.Item_FacturaAux,ELITE4.Consumible,ELITE4.Hotel
		WHERE Item_FacturaAux.Reserva_Codigo = @reserva
			AND Item_FacturaAux.Consumible_Codigo=Consumible.Consumible_Codigo
			AND Item_FacturaAux.Hotel_ID=Hotel.Hotel_ID		
GO
--select * from ELITE4.Item_Factura where Factura = 2396745
IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='CalcularTotalAux')
		DROP PROCEDURE ELITE4.CalcularTotalAux;
GO

CREATE PROCEDURE ELITE4.CalcularTotalAux
			@reserva numeric(18,0)
AS
	SELECT SUM(Precio*Cantidad) total
		FROM ELITE4.Item_FacturaAux
		WHERE Item_FacturaAux.Reserva_Codigo = @reserva
		
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='facturar')
		DROP PROCEDURE ELITE4.facturar;
GO

CREATE PROCEDURE ELITE4.facturar
			@reserva	numeric(18,0),
			@total		numeric(18,2)
AS
	INSERT INTO ELITE4.Factura (Cliente,Factura_Fecha,Factura_Total,Reserva_Codigo)
		SELECT Cliente_id,GETDATE(),@total,@reserva
			FROM ELITE4.cliente;	
			
	UPDATE ELITE4.Estadia 
		SET Estadia_Fecha_Fin=GETDATE()
		WHERE Reserva_Codigo=@reserva;
			
	INSERT INTO ELITE4.Item_Factura(Hotel_ID,Habitacion_Numero,Precio,Cantidad,Reserva_Codigo,Consumible_Codigo,Factura)
		SELECT Hotel_ID,Habitacion_Numero,Precio,Cantidad,@reserva,Consumible_Codigo,SCOPE_IDENTITY()
			FROM ELITE4.Item_FacturaAux;
			
	DELETE FROM ELITE4.Item_FacturaAux WHERE Reserva_Codigo=@reserva;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='getresactsinchec')
		DROP PROCEDURE ELITE4.getresactsinchec;
GO

CREATE PROCEDURE ELITE4.getresactsinchec
			@h	int
AS
	SELECT reservas.Reserva_Codigo
	 FROM ELITE4.Reserva_Por_Habitacion,(SELECT reserva.Reserva_Codigo FROM ELITE4.Reserva LEFT JOIN ELITE4.Estadia ON (Reserva.Reserva_Codigo=Estadia.Reserva_Codigo) WHERE GETDATE() = Reserva.Reserva_Fecha_Inicio AND Estadia.Reserva_Codigo IS NULL) reservas --agarro solo las que no tienen estadia y se puden checkear ahora
	 WHERE Reserva_Por_Habitacion.Hotel_ID=@h
		AND Reservas.Reserva_Codigo=Reserva_Por_Habitacion.Reserva_Codigo
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='spObtenerReserva')
		DROP PROCEDURE ELITE4.spObtenerReserva;
GO
CREATE PROCEDURE ELITE4.spObtenerReserva
	@codigoReserva NUMERIC
AS
BEGIN
SELECT Reserva.Reserva_Codigo, Reserva.Reserva_Fecha_Inicio, Reserva.Reserva_Fecha_Fin, Reserva.Hotel_ID, Reserva.Regimen_Cod, Reserva_Por_Habitacion.Habitacion_Numero, habitacion.Habitacion_Tipo_Codigo
FROM ELITE4.Reserva JOIN ELITE4.Reserva_Por_Habitacion ON (Reserva.Reserva_Codigo = Reserva_Por_Habitacion.Reserva_Codigo)
					JOIN ELITE4.Habitacion ON (Reserva_Por_Habitacion.Habitacion_Numero = Habitacion.Habitacion_Numero AND Reserva.Hotel_ID = Habitacion.Hotel_ID)
WHERE Reserva.Reserva_Codigo = @codigoReserva
END
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spBuscarHabitacion')
	DROP PROCEDURE ELITE4.spBuscarHabitacion;
GO
CREATE PROCEDURE ELITE4.spBuscarHabitacion
(
    @codHabitacion          NVARCHAR(18) ,
    @pisoHabitacion         NVARCHAR(18) ,
    @hotelId				INT ,
    @tipoHabitacion			INT,
    @habi					BIT
  )

AS
	SELECT h.Habitacion_Numero,h.Habitacion_Piso,h.Habitacion_Habilitada,h.Habitacion_Frente,t.Habitacion_Tipo_Descripcion
		FROM ELITE4.Habitacion h, ELITE4.Habitacion_Tipo t 
		WHERE h.Habitacion_Tipo_Codigo = t.Habitacion_Tipo_Codigo
			AND (@codHabitacion ='' OR @codHabitacion = CONVERT(NVARCHAR(18),h.Habitacion_Numero))
			AND (@pisoHabitacion ='' OR @pisoHabitacion= CONVERT(NVARCHAR(18),h.Habitacion_Piso))
			AND h.Hotel_ID = @hotelId
			AND (@tipoHabitacion IS NULL OR t.Habitacion_Tipo_Codigo = @tipoHabitacion)
			AND h.Habitacion_Habilitada=@habi;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='buscarhoteles')
		DROP PROCEDURE ELITE4.buscarhoteles;
GO
CREATE PROCEDURE ELITE4.buscarhoteles
@ciudad		NVARCHAR(255),
@calle		NVARCHAR(255),
@ncalle		NVARCHAR(18),
@cantes		NVARCHAR(18),
@recantes	NVARCHAR(18),
@mail		NVARCHAR(60),
@pais		NVARCHAR(60),
@nombre		NVARCHAR(60),
@fecha		DATETIME,
@telefono	NVARCHAR(18),
@habilitado BIT            
AS
	SELECT Hotel_ID,Hotel_Ciudad,Hotel_Calle,Hotel_Nro_Calle,Hotel_CantEstrella,Hotel_Fecha_Creacion,Hotel_Pais,Hotel_Nombre,Hotel_Mail,Hotel_Telefono,Hotel_Habilitado,Hotel_Recarga_Estrella
		FROM ELITE4.Hotel
		WHERE (@ciudad='' OR @ciudad LIKE RTRIM(Hotel_Ciudad)+'%')
			AND (@calle='' OR @calle LIKE RTRIM(Hotel_Calle)+'%')
			AND (@ncalle='' OR @ncalle = CONVERT(NVARCHAR(18),Hotel_Nro_Calle))
			AND (@cantes='' OR @cantes = CONVERT(NVARCHAR(18),Hotel_CantEstrella))
			AND (@recantes='' OR @recantes = CONVERT(NVARCHAR(18),Hotel_Recarga_Estrella))
			AND (@mail='' OR @mail LIKE RTRIM(Hotel_Mail)+'%')
			AND (@pais='' OR @pais LIKE RTRIM(Hotel_Pais)+'%')
			AND (@nombre='' OR @nombre LIKE RTRIM(Hotel_Nombre)+'%')
			AND (@telefono='' OR @telefono = CONVERT(NVARCHAR(18),Hotel_Telefono))
			AND (@habilitado = Hotel_Habilitado)
			AND (@fecha IS NULL OR @fecha = Hotel_Fecha_Creacion);
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='spBuscarUsuarios')
		DROP PROCEDURE ELITE4.spBuscarUsuarios;

GO

CREATE PROCEDURE ELITE4.spBuscarUsuarios
			@apellido	nvarchar(30),
			@nombre		nvarchar(30),
			@mail		nvarchar(30),
			@nro_doc	NVarchar(18),
			@username	NVARCHAR(30),
			@tipoDoc	INT,
			@userId		NVARCHAR(10),
			@hotelID	INT,
			@direccion	NVARCHAR(60)
AS
	SELECT DISTINCT u.Usuario_ID,u.Usuario_Username,u.Pasaporte_Tipo,u.Usuario_Numero_Doc,u.Usuario_Direccion,u.Usuario_Fecha_Nacimiento,u.Usuario_Nombre,u.Usuario_Apellido,u.Usuario_mail,u.Usuario_Telefono,u.Usuario_Habilitado
		FROM ELITE4.Usuario u,ELITE4.Usuario_Por_Hotel_Rol ur
		WHERE u.Usuario_ID = ur.Usuario_ID
			AND ur.Hotel_ID=@hotelID
			AND (@apellido ='' OR  @apellido LIKE RTRIM(U.Usuario_Apellido)+'%')
			AND (@nombre ='' OR @nombre LIKE RTRIM(U.Usuario_Nombre)+'%')
			AND (@mail = ''  OR @mail LIKE RTRIM(U.Usuario_mail)+'%')
			AND (@nro_doc ='' OR @nro_doc = CONVERT(NVARCHAR(18),U.Usuario_Numero_Doc))
			AND (@username ='' OR @username LIKE RTRIM(U.Usuario_Username)+'%')
			AND (@tipoDoc =  u.Pasaporte_Tipo )
			AND (@userId ='' OR @userId = CONVERT(int,U.Usuario_ID))
			AND (@direccion ='' OR @direccion LIKE RTRIM(U.Usuario_Direccion)+'%');
GO


IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='bajaHotel')
		DROP PROCEDURE ELITE4.bajaHotel;
GO

CREATE PROCEDURE ELITE4.bajaHotel
@id		INT,     
@motivo NVARCHAR(100)
AS
		IF NOT EXISTS(SELECT 1 FROM ELITE4.Reservas_activas WHERE ELITE4.Reservas_activas.Hotel_ID = @id)
			BEGIN
				UPDATE ELITE4.Hotel SET Hotel_Habilitado = 0
					FROM ELITE4.Hotel
					WHERE ELITE4.Hotel.Hotel_ID = @id;
				
				INSERT INTO ELITE4.Baja_Hotel (Hotel_ID,Baja_Hotel_Fecha,Baja_Hotel_Descripcion) VALUES
					(@id,GETDATE(),@motivo);
				SELECT 1;
			END;
		ELSE
			SELECT 0;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='bajaUsuario')
		DROP PROCEDURE ELITE4.bajaUsuario;
GO

CREATE PROCEDURE ELITE4.bajaUsuario
@id		INT
AS
	UPDATE ELITE4.Usuario SET Usuario_Habilitado = 0
		WHERE Usuario_ID=@id;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'bajaHabitacion')
	DROP PROCEDURE ELITE4.bajaHabitacion;
GO
CREATE PROCEDURE ELITE4.bajaHabitacion
@Nro_Habitacion		INT,
@Hotel				INT
AS 
	IF NOT EXISTS(SELECT 1 FROM ELITE4.Reservasxhab_activas WHERE Hotel_ID = @Hotel AND Habitacion_Numero= @Nro_Habitacion)
		BEGIN
			UPDATE ELITE4.Habitacion 
				SET Habitacion_Habilitada = 0
				WHERE Hotel_ID = @Hotel	
					AND  Habitacion_Numero= @Nro_Habitacion;
				
			SELECT 1;
		END;
	ELSE
		SELECT 0;
go

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='habilitarHotel')
		DROP PROCEDURE ELITE4.habilitarHotel;
GO
CREATE PROCEDURE ELITE4.habilitarHotel
@idhotel		INT
AS
	UPDATE ELITE4.Hotel
		SET Hotel_Habilitado=1
		WHERE Hotel_ID=@idhotel;
	UPDATE ELITE4.Baja_Hotel
		SET Fin_Baja_Hotel_Fecha = GETDATE()
		WHERE Hotel_ID=@idhotel;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='habilitarHabitacion')
		DROP PROCEDURE ELITE4.habilitarHabitacion;
GO
CREATE PROCEDURE ELITE4.habilitarHabitacion
@idhotel		INT,
@habNum			NUMERIC(18,0)
AS
	UPDATE ELITE4.Habitacion
		SET Habitacion_Habilitada=1
		WHERE Hotel_ID=@idhotel
			AND Habitacion_Numero=@habNum;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='ModificarHotel')
		DROP PROCEDURE ELITE4.ModificarHotel;
GO
CREATE PROCEDURE ELITE4.ModificarHotel
@idhotel		INT,
@ciudad		NVARCHAR(255),
@calle		NVARCHAR(255),
@ncalle		NUMERIC(18,0)=null,
@cantes		NUMERIC(18,0)=null,
@reccantes	NUMERIC(18,0)=null,
@mail		NVARCHAR(60),
@pais		NVARCHAR(60),
@nombre		NVARCHAR(60),
@telefono	NUMERIC(18,0) =null
AS
	UPDATE ELITE4.Hotel
		SET Hotel_Ciudad=@ciudad,
			Hotel_Calle=@calle,
			Hotel_Nro_Calle=@ncalle,
			Hotel_CantEstrella=@cantes,
			Hotel_Recarga_Estrella=@reccantes,
			Hotel_Mail=@mail,
			Hotel_Pais=@pais,
			Hotel_Nombre=@nombre,
			Hotel_Telefono=@telefono
		WHERE Hotel_ID=@idhotel;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='ModificarHabitacion')
		DROP PROCEDURE ELITE4.ModificarHabitacion;
GO
CREATE PROCEDURE ELITE4.ModificarHabitacion
@habNum		NUMERIC(18,0),
@hotel		INT,
@frente		NVARCHAR(50),
@piso		NUMERIC(18,0)=null,
@tipo		INT
AS
	UPDATE ELITE4.Habitacion
		SET Habitacion_Frente=@frente,
			Habitacion_Piso=@piso,
			Habitacion_Tipo_Codigo=@tipo
		WHERE Habitacion_Numero=@habNum
			AND Hotel_ID=@hotel;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='obtenernrotipodehabconnombre')
		DROP PROCEDURE ELITE4.obtenernrotipodehabconnombre;
GO
CREATE PROCEDURE ELITE4.obtenernrotipodehabconnombre
@nombre		NVARCHAR(255)
AS
	SELECT Habitacion_Tipo_Codigo
		FROM ELITE4.Habitacion_Tipo
		WHERE Habitacion_Tipo_Descripcion=@nombre;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='spModificarReserva')
		DROP PROCEDURE ELITE4.spModificarReserva;
GO
CREATE PROCEDURE ELITE4.spModificarReserva
	@reservaCodigo	NUMERIC,
	@hotelID		INT,
	@fechaInicio	DATETIME,
	@fechaFin		DATETIME,
	@regimenCodigo	INT
AS
	UPDATE ELITE4.Reserva
		SET Hotel_ID = @hotelID,
			Reserva_Fecha_Inicio = @fechaInicio,
			Reserva_Fecha_Fin = @fechaFin,
			Reserva_Estado_Descripcion = 'Reserva modificada',
			Regimen_Cod = @regimenCodigo
		--	Cliente = @clienteiD	
		WHERE Reserva_Codigo=@reservaCodigo;
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='spEliminarReservasPorHabitacion')
		DROP PROCEDURE ELITE4.spEliminarReservasPorHabitacion;
GO
CREATE PROCEDURE ELITE4.spEliminarReservasPorHabitacion
	@reservaCodigo	NUMERIC
AS
	DELETE ELITE4.Reserva_Por_Habitacion
	WHERE Reserva_Codigo = @reservaCodigo
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='spBajaReserva')
		DROP PROCEDURE ELITE4.spBajaReserva;
GO
CREATE PROCEDURE ELITE4.spBajaReserva
	@reservaCodigo		NUMERIC(18,0),
	@motivoCancelacion	NVARCHAR(100),
	@hotelID			INT,
	@usuarioID			INT,
	@fechaCancelacion	DATETIME,
	@rolCod				INT,
	@estado				nvarchar(60)
	
AS
	UPDATE ELITE4.Reserva
		SET Reserva_Estado_Descripcion = @estado
		WHERE Reserva_Codigo=@reservaCodigo;
		
	DELETE ELITE4.Reserva_Por_Habitacion
		WHERE Reserva_Codigo = @reservaCodigo;
		
	INSERT INTO ELITE4.Reserva_Cancelada (Reserva_Codigo, Reserva_Cancelada_Desc, Hotel_ID, Usuario_ID, Reserva_Cancelada_Fecha, Rol_Cod)
		VALUES (@reservaCodigo, @motivoCancelacion, @hotelID, @usuarioID, @fechaCancelacion, @rolCod)
	
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='spObtenerHabitacionesDisponibles')
		DROP PROCEDURE ELITE4.spObtenerHabitacionesDisponibles;
GO
CREATE PROCEDURE ELITE4.spObtenerHabitacionesDisponibles
@hotel_id					INT,
@habitacion_tipo_codigo		NUMERIC(18,0),
@fechaDesde					DATETIME,
@fechaHasta					DATETIME,
@reservaAignorar			NUMERIC(18,0)
AS
	SELECT ha.Habitacion_Numero
		FROM ELiTE4.habitaciones_habilitadas ha
		WHERE ha.Hotel_ID=@hotel_id		
			AND HA.Habitacion_Tipo_Codigo=@habitacion_tipo_codigo
	EXCEPT 
	SELECT rh.Habitacion_Numero
		FROM ELITE4.Reserva_Por_Habitacion rh,ELITE4.Reserva r
			WHERE R.Reserva_Codigo=rh.Reserva_Codigo	
				AND r.Reserva_Codigo != @reservaAignorar
				AND r.Hotel_ID=@hotel_id		
				AND NOT(R.Reserva_Fecha_Inicio > @fechaHasta OR R.Reserva_Fecha_Fin < @fechaDesde);
GO

IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name='getPrecioHabitacion')
		DROP PROCEDURE ELITE4.getPrecioHabitacion;
GO
CREATE PROCEDURE ELITE4.getPrecioHabitacion
@tipoHabSeleccionada	NUMERIC(18,0),
@codigoRegimen			INT,
@hotelcod				INT
AS
	SELECT 
		(SELECT Regimen_Precio
			FROM ELITE4.Regimen
			WHERE Regimen_Cod=@codigoRegimen)
		*
		(SELECT Habitacion_Tipo_Porcentual
			FROM ELITE4.Habitacion_Tipo
			WHERE Habitacion_Tipo_Codigo=@tipoHabSeleccionada)
		+
		(SELECT Hotel_CantEstrella*Hotel_Recarga_Estrella
			FROM ELITE4.Hotel
			WHERE Hotel_ID=@hotelcod);
GO