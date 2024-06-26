USE [PruebaCorta]
GO
/****** Object:  StoredProcedure [dbo].[CrearRespuesta]    Script Date: 23/6/2024 06:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CrearRespuesta]
    @IdPregunta VARCHAR(50),
	@Nombre VARCHAR(50),
    @Respuesta TEXT
AS
BEGIN
 DECLARE @FechaActual DATETIME;
    SET @FechaActual = GETDATE();

	 INSERT INTO Respuestas (Fecha, IdPregunta, Nombre, Respuesta)
    VALUES (@FechaActual, @IdPregunta, @Nombre, @Respuesta)
END
