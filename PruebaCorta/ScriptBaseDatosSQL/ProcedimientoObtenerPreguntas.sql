USE [PruebaCorta]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPreguntas]    Script Date: 23/6/2024 06:16:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ObtenerPreguntas]
AS
BEGIN
  SELECT * FROM Preguntas
  ORDER BY Fecha DESC
END
