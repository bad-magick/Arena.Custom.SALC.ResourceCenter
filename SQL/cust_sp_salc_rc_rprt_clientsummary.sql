USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_rprt_clientsummary]    Script Date: 04/13/2012 13:42:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[cust_sp_salc_rc_rprt_clientsummary]
/*
-- =============================================
-- Author:		Den Boice
-- Create date: 03/08/2012
REPORT: cust_sp_salc_rc_rprt_helpsummary
TITLE: Help Summary report
DESCRIPTION:
Returns sums of all data for the specified help type
-- =============================================
*/
@StartDate datetime = '1/1/1900',
@EndDate datetime = '1/1/1900',
@AssistanceType int = 17,
@Direction int = 0,
@OrganizationId int = 1

AS

if (@StartDate = '1/1/1900')
	set @StartDate = GETDATE()

if (@EndDate = '1/1/1900')
	set @EndDate = GETDATE()
	
SELECT
	CASE
		--DATEDIFF(yy, [cust_salc_rc_clients].birthday, [cust_salc_rc_help].[date]) - CASE WHEN [cust_salc_rc_clients].birthday <= DATEADD(yy, DATEDIFF(yy, [cust_salc_rc_help].[date], [cust_salc_rc_clients].birthday), [cust_salc_rc_help].[date]) THEN 0 ELSE 1 END
		WHEN DATEDIFF(yy, [cust_salc_rc_clients].birthday, [cust_salc_rc_help].[date]) - CASE WHEN [cust_salc_rc_clients].birthday <= DATEADD(yy, DATEDIFF(yy, [cust_salc_rc_help].[date], [cust_salc_rc_clients].birthday), [cust_salc_rc_help].[date]) THEN 0 ELSE 1 END >= 18
			THEN 'A'
		ELSE 'C'
	END AS [LegalStanding],
	[cust_salc_rc_help].id AS [help_id],
	[cust_salc_rc_help].[address] AS [address],
	DATEDIFF(yy, [cust_salc_rc_clients].birthday, [cust_salc_rc_help].[date]) - CASE WHEN [cust_salc_rc_clients].birthday <= DATEADD(yy, DATEDIFF(yy, [cust_salc_rc_help].[date], [cust_salc_rc_clients].birthday), [cust_salc_rc_help].[date]) THEN 0 ELSE 1 END AS [Age]
INTO #clients
FROM [cust_salc_rc_clients]
	INNER JOIN [cust_salc_rc_help_link]
		ON cust_salc_rc_clients.id = cust_salc_rc_help_link.person_id
	INNER JOIN [cust_salc_rc_help]
		ON [cust_salc_rc_help].id = [cust_salc_rc_help_link].help_id
WHERE 
	(CASE
		WHEN @Direction = 0 AND
			[cust_salc_rc_help].date <= @EndDate
			AND [cust_salc_rc_help].date >= @StartDate
			THEN 1
		WHEN @Direction = 1 AND
			[cust_salc_rc_help].completed_on <= @EndDate
			AND [cust_salc_rc_help].completed_on >= @StartDate
			THEN 1
		WHEN @Direction = 2 AND
			(([cust_salc_rc_help].date <= @EndDate
			AND [cust_salc_rc_help].date >= @StartDate)
			OR
			([cust_salc_rc_help].completed_on <= @EndDate
			AND [cust_salc_rc_help].completed_on >= @StartDate))
			THEN 1
		WHEN @Direction = 3 AND
			[cust_salc_rc_help].date <= @EndDate
			AND [cust_salc_rc_help].date >= @StartDate
			AND [cust_salc_rc_help].completed_on <= @EndDate
			AND [cust_salc_rc_help].completed_on >= @StartDate
			THEN 1
		WHEN @Direction = 4
			AND (
			   ([cust_salc_rc_help].date BETWEEN @StartDate AND @EndDate)
			OR ([cust_salc_rc_help].completed_on BETWEEN @StartDate AND @EndDate)
			OR (@EndDate BETWEEN [cust_salc_rc_help].date AND CASE WHEN CONVERT(date, '1/1/1901', 101) < [cust_salc_rc_help].completed_on THEN [cust_salc_rc_help].completed_on ELSE @EndDate END)
			OR (@StartDate BETWEEN [cust_salc_rc_help].date AND CASE WHEN CONVERT(date, '1/1/1901', 101) < [cust_salc_rc_help].completed_on THEN [cust_salc_rc_help].completed_on ELSE @EndDate END)
			)
			THEN 1
		ELSE 0
	END) = 1 AND
	(CASE
		WHEN @AssistanceType > 0 AND
			[cust_salc_rc_help].sub_type = @AssistanceType
			THEN 1
		WHEN @AssistanceType = 0
			THEN 1
		ELSE 0
	END) = 1

SELECT DISTINCT
	(SELECT COUNT(*) AS [Children]
	FROM #clients
	WHERE [cust_salc_rc_help].id = #clients.help_id
		AND #clients.LegalStanding = 'C') AS [Children],
	(SELECT COUNT(*) AS [Adults]
	FROM #clients
	WHERE [cust_salc_rc_help].id = #clients.help_id
		AND #clients.LegalStanding = 'A') AS [Adults],
	--CASE
	--	WHEN @AssistanceType = 14
	--	THEN 
	--		CASE
	--			WHEN [cust_salc_rc_help].completed_on > CONVERT(date, '1/2/1901', 101)
	--			THEN DATEDIFF("d", CASE WHEN [cust_salc_rc_help].date < @StartDate THEN @StartDate ELSE [cust_salc_rc_help].date END, CASE WHEN [cust_salc_rc_help].completed_on > @EndDate THEN @EndDate ELSE [cust_salc_rc_help].completed_on END)
	--			ELSE DATEDIFF("d", CASE WHEN [cust_salc_rc_help].date < @StartDate THEN @StartDate ELSE [cust_salc_rc_help].date END, @EndDate)
	--		END
	--	ELSE [cust_salc_rc_help].size
	--END AS [Size],
	--[cust_salc_rc_help].amount AS [Amount],
	--[cust_salc_rc_help].id AS [help_id],
	--(SELECT TOP 1 [id]
	--	FROM [dbo].[cust_salc_rc_clients]
	--	WHERE [dbo].[cust_salc_rc_clients].[id] = [cust_salc_rc_help_link].person_id
	--	ORDER BY [birthday] DESC
	--) AS [main_id],
	#clients.[address] AS [address],
	(SELECT COUNT(*) AS [FamilySize] FROM #clients WHERE [address]=cust_salc_rc_help.[address] AND [help_id]=dbo.cust_salc_rc_help.id) AS [FamilySize],
	--CASE
	--	WHEN [cust_salc_rc_help].completed_on > CONVERT(date, '1/2/1901', 101)
	--	THEN DATEDIFF("d", CASE WHEN [cust_salc_rc_help].date < @StartDate THEN @StartDate ELSE [cust_salc_rc_help].date END, CASE WHEN [cust_salc_rc_help].completed_on > @EndDate THEN @EndDate ELSE [cust_salc_rc_help].completed_on END)
	--	ELSE DATEDIFF("d", CASE WHEN [cust_salc_rc_help].date < @StartDate THEN @StartDate ELSE [cust_salc_rc_help].date END, @EndDate)
	--END AS [Days],
	--[cust_salc_rc_help].county AS [County],
	(SELECT SUM(Age) FROM #clients WHERE [cust_salc_rc_help].id = #clients.help_id) AS [Years],
	(SELECT SUM(Age) FROM #clients WHERE [cust_salc_rc_help].id = #clients.help_id AND #clients.LegalStanding = 'A') AS [AdultYears],
	(SELECT SUM(Age) FROM #clients WHERE [cust_salc_rc_help].id = #clients.help_id AND #clients.LegalStanding = 'C') AS [ChildYears]
	--[cust_salc_rc_clients].first_name + ' ' + [cust_salc_rc_clients].last_name AS [Name]
INTO #totals
FROM #clients 
	INNER JOIN [dbo].[cust_salc_rc_help]
		ON dbo.cust_salc_rc_help.id = #clients.help_id
	INNER JOIN [cust_salc_rc_help_link]
		ON cust_salc_rc_help.id = cust_salc_rc_help_link.help_id
	INNER JOIN [cust_salc_rc_clients]
		ON [cust_salc_rc_clients].id = [cust_salc_rc_help_link].person_id
WHERE
	(CASE
		WHEN @Direction = 0 AND
			[cust_salc_rc_help].date <= @EndDate
			AND [cust_salc_rc_help].date >= @StartDate
			THEN 1
		WHEN @Direction = 1 AND
			[cust_salc_rc_help].completed_on <= @EndDate
			AND [cust_salc_rc_help].completed_on >= @StartDate
			THEN 1
		WHEN @Direction = 2 AND
			(([cust_salc_rc_help].date <= @EndDate
			AND [cust_salc_rc_help].date >= @StartDate)
			OR
			([cust_salc_rc_help].completed_on <= @EndDate
			AND [cust_salc_rc_help].completed_on >= @StartDate))
			THEN 1
		WHEN @Direction = 3 AND
			[cust_salc_rc_help].date <= @EndDate
			AND [cust_salc_rc_help].date >= @StartDate
			AND [cust_salc_rc_help].completed_on <= @EndDate
			AND [cust_salc_rc_help].completed_on >= @StartDate
			THEN 1
		WHEN @Direction = 4
			AND (
			   ([cust_salc_rc_help].date BETWEEN @StartDate AND @EndDate)
			OR ([cust_salc_rc_help].completed_on BETWEEN @StartDate AND @EndDate)
			OR (@EndDate BETWEEN [cust_salc_rc_help].date AND CASE WHEN CONVERT(date, '1/1/1901', 101) < [cust_salc_rc_help].completed_on THEN [cust_salc_rc_help].completed_on ELSE @EndDate END)
			OR (@StartDate BETWEEN [cust_salc_rc_help].date AND CASE WHEN CONVERT(date, '1/1/1901', 101) < [cust_salc_rc_help].completed_on THEN [cust_salc_rc_help].completed_on ELSE @EndDate END)
			)
			THEN 1
		ELSE 0
	END) = 1 AND
	(CASE
		WHEN @AssistanceType > 0 AND
			[cust_salc_rc_help].sub_type = @AssistanceType
			THEN 1
		WHEN @AssistanceType = 0
			THEN 1
		ELSE 0
	END) = 1
ORDER BY [address]

DELETE FROM #totals WHERE [FamilySize] < (SELECT MAX(FamilySize) FROM #totals New WHERE #totals.[address] = New.[address])
DELETE FROM #totals WHERE [Years] > (SELECT MIN(Years) FROM #totals New WHERE #totals.[address] = New.[address])

SELECT DISTINCT
	*
FROM #totals

GO

