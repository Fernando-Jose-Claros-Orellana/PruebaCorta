USE [PruebaCorta]
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 23/6/2024 06:16:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Login]
   @Nombre VARCHAR (50),
   @Contrasena VARCHAR(50),
   @i BIT OUTPUT
AS
BEGIN
	IF exists(SELECT * FROM Usuarios WHERE Nombre = @Nombre AND Contrasena = @Contrasena)
	BEGIN
	SET @i = 1;
	END
	ELSE
	BEGIN
	SET @i = 0;
	END
END
