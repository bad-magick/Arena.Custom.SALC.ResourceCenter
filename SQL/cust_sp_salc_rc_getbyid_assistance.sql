USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getbyid_assistance]    Script Date: 04/13/2012 13:39:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Gets an assistance file with the specified ID
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getbyid_assistance]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM cust_salc_rc_assistance WHERE id = @id
END


GO

