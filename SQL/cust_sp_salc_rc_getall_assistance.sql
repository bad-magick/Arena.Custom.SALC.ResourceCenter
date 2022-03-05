USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_assistance]    Script Date: 04/13/2012 13:37:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Returns all assistance types
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_assistance]
	@Enabled int,
	@OrganizationId int
AS
BEGIN
	SELECT
		*
	FROM [cust_salc_rc_assistance]
	WHERE 
		[organization_id] = @OrganizationId
		AND [enabled] >= @Enabled
	ORDER BY name ASC
END


GO

