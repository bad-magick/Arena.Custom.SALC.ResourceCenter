USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_account]    Script Date: 04/13/2012 13:37:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Returns all accounts for a helpId
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_account]
	@HelpId int
AS
BEGIN
	SELECT
		*
	FROM [cust_salc_rc_accounts]
	WHERE 
		[help_id] = @HelpId
	ORDER BY [date] DESC
END


GO

