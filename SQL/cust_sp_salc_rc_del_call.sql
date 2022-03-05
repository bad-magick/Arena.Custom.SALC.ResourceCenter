USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_del_call]    Script Date: 04/13/2012 13:35:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/13/2012
-- Description:	Delete Resource Center call data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_del_call]
	-- Add the parameters for the stored procedure here
	@CallId int
AS
BEGIN
	DELETE
		cust_salc_rc_calls
	WHERE
		[id] = @CallId		
END



GO

