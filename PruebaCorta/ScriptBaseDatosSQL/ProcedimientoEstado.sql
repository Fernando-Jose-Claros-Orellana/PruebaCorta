USE [PruebaCorta]
GO
/****** Object:  StoredProcedure [dbo].[Estado]    Script Date: 23/6/2024 06:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Estado]
    @Id INT,
	@Estado INT
AS
BEGIN
	UPDATE Preguntas
   SET Estado = @Estado
   WHERE Id = @Id
END
