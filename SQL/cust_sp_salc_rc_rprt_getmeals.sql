USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_rprt_getmeals]    Script Date: 04/13/2012 13:42:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/12/2012
-- Description:	Returns all meals from the meals table
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_rprt_getmeals]
	@StartDate DATE,
	@EndDate DATE,
	@OrganizationId int
AS
BEGIN
	SELECT
		[date],
		[meals],
		[served],
		[dist],
		[pounds]
	FROM [cust_salc_rc_meals]
	WHERE [date] BETWEEN @StartDate AND @EndDate
	ORDER BY [Date] ASC
END


GO

