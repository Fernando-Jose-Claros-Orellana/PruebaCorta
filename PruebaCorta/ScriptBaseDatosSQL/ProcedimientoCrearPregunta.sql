USE [PruebaCorta]
GO
/****** Object:  StoredProcedure [dbo].[CrearPregunta]    Script Date: 23/6/2024 06:15:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CrearPregunta]
    @Nombre VARCHAR(50),
    @Pregunta TEXT,
	@Estado INT
AS
BEGIN
	DECLARE @FechaActual DATETIME;
    SET @FechaActual = GETDATE();

	 INSERT INTO Preguntas (Fecha, Nombre, Pregunta, Estado)
    VALUES (@FechaActual, @Nombre, @Pregunta, @Estado)
END
