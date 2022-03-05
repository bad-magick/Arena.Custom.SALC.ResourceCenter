USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_rprt_shelterlist]    Script Date: 04/13/2012 13:43:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[cust_sp_salc_rc_rprt_shelterlist]
/*
-- =============================================
-- Author:		Den Boice
-- Create date: 03/08/2012
REPORT: cust_sp_salc_rc_rprt_shelterlist
TITLE: Shelter List report
DESCRIPTION:
Returns all clients that are in shelter for a given day
-- =============================================
*/
@StartDate datetime = '1/1/1900',
@EndDate datetime = '1/1/1900',
@OrganizationId int

AS

if (@StartDate = '1/1/1900')
	set @StartDate = GETDATE()

if (@EndDate = '1/1/1900')
	set @EndDate = GETDATE()
	
SET @EndDate = @StartDate
	
SELECT
	[cust_salc_rc_clients].[first_name] + ' ' + [cust_salc_rc_clients].[last_name] AS [Name],
	[cust_salc_rc_help].[id] AS [hid],
	[cust_salc_rc_clients].[id] AS [pid],
	ROW_NUMBER() OVER (ORDER BY [cust_salc_rc_help].[date] ASC, [cust_salc_rc_help].[address] ASC, [cust_salc_rc_clients].[birthday] ASC) AS [Counter]
INTO #tempHelp
FROM [cust_salc_rc_clients] 
	INNER JOIN [cust_salc_rc_help_link]
		ON cust_salc_rc_clients.id = cust_salc_rc_help_link.person_id
	INNER JOIN [cust_salc_rc_help]
		ON [cust_salc_rc_help].id = [cust_salc_rc_help_link].help_id
WHERE 
	(CASE
		WHEN [cust_salc_rc_help].completed_on <= CONVERT(date, '1/1/1901', 101)
			THEN 1
		WHEN [cust_salc_rc_help].completed_on > CONVERT(DATE, '1/1/1901', 101)
			AND @EndDate < [cust_salc_rc_help].completed_on
			THEN 1
		ELSE 0
	END ) = 1
	AND [cust_salc_rc_help].sub_type = 14
	AND @StartDate >= [cust_salc_rc_help].[date]
ORDER BY [Counter] ASC
	
SELECT
	[cust_salc_rc_clients].[first_name] + ' ' + [cust_salc_rc_clients].[last_name] AS [Name],
	CASE
		WHEN birthday > CONVERT(date, '1/1/1901', 101)
		THEN CONVERT(varchar, DATEDIFF(yy, birthday, @StartDate) - CASE WHEN birthday <= DATEADD(yy, DATEDIFF(yy, @StartDate, birthday), @StartDate) THEN 0 ELSE 1 END)
		ELSE ''
	END AS [Age],
	CONVERT(varchar, HELP.[date], 101) AS [Arrival],
	CONVERT(varchar, HELP.[completed_on], 101) AS [Departure],
	HELP.[description] AS [Location],
	HELP.[county] AS [County],
	HELP.[id] AS [id],
	ROW_NUMBER() OVER (ORDER BY HELP.[date] ASC, HELP.[address] ASC, [cust_salc_rc_clients].[birthday] ASC) AS [Count],
	CASE 
		WHEN (
			SELECT TOP 1 Name
			FROM #tempHelp
			WHERE #tempHelp.[hid] = HELP.[id]
		) = [cust_salc_rc_clients].[first_name] + ' ' + [cust_salc_rc_clients].[last_name]
		THEN 1
		ELSE 0
	END AS [Header]
FROM [cust_salc_rc_clients] 
	INNER JOIN [cust_salc_rc_help_link] AS LINK
		ON cust_salc_rc_clients.id = LINK.person_id
	INNER JOIN [cust_salc_rc_help] AS HELP
		ON HELP.id = LINK.help_id
WHERE
	(CASE
		WHEN HELP.completed_on <= CONVERT(date, '1/1/1901', 101)
			THEN 1
		WHEN HELP.completed_on > CONVERT(DATE, '1/1/1901', 101)
			AND @EndDate < HELP.completed_on
			THEN 1
		ELSE 0
	END ) = 1
	AND HELP.sub_type = 14
	AND @StartDate >= HELP.[date]
ORDER BY [Count]



GO

