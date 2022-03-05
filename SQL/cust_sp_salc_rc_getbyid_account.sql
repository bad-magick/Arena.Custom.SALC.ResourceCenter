USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getbyid_account]    Script Date: 04/13/2012 13:39:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Gets an account file with the specified ID
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getbyid_account]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM cust_salc_rc_accounts WHERE id = @id
END


GO

