USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_del_account]    Script Date: 04/13/2012 13:35:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Delete Resource Center account data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_del_account]
	@AccountId int
AS
BEGIN
	DELETE
		cust_salc_rc_accounts
	WHERE
		[id] = @AccountId		
END



GO

