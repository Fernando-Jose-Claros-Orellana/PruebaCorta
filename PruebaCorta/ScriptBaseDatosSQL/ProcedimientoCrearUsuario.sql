USE [PruebaCorta]
GO
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 23/6/2024 06:16:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CrearUsuario]
    @Nombre VARCHAR(50),
	@Contrasena VARCHAR(50),
	@i BIT OUTPUT
AS
BEGIN
	IF exists(SELECT * FROM Usuarios WHERE Nombre = @Nombre)
    BEGIN
	SET @i = 0;
	END
	ELSE
	BEGIN
	INSERT INTO Usuarios (Nombre, Contrasena)
    VALUES (@Nombre, @Contrasena)
	SET @i = 1;
	END
END
