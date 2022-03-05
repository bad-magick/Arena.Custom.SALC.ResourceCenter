USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_meal]    Script Date: 04/13/2012 13:38:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/12/2012
-- Description:	Returns all meals from the meals table
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_meal]
	@StartDate date,
	@EndDate date,
	@OrganizationId int
AS
BEGIN
	SELECT
		*
	FROM [cust_salc_rc_meals]
	WHERE [date] BETWEEN @StartDate AND @EndDate
		AND @OrganizationId = [organization_id]
	ORDER BY [Date] DESC
END


GO

