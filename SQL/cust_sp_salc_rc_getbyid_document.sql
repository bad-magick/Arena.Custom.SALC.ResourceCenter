USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getbyid_document]    Script Date: 04/13/2012 13:40:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Gets an account file with the specified ID
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getbyid_document]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM cust_salc_rc_documents WHERE id = @id
END


GO

