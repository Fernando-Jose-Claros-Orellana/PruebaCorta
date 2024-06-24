USE [PruebaCorta]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerRespuestas]    Script Date: 23/6/2024 06:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ObtenerRespuestas]
   @IdPregunta INT
AS
BEGIN
	SELECT * FROM Respuestas 
	WHERE IdPregunta = @IdPregunta
	ORDER BY Fecha DESC
END
