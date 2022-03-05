USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_del_assistance]    Script Date: 04/13/2012 13:35:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Delete Resource Center assistance data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_del_assistance]
	@SubTypeId int
AS
BEGIN
	DELETE
		cust_salc_rc_assistance
	WHERE
		[id] = @SubTypeId		
END



GO

