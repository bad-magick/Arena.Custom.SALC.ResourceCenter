USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_event]    Script Date: 04/13/2012 13:38:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Den Boice
-- Create date: 3/29/3012
-- Description:	Returns the date and amount of next payday
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_event] 
(
	@StartDate date,
	@EndDate date,
	@PersonId int,
	@HelpSubTypeId int,
	@OrganizationId int
)
AS
BEGIN
	SET DATEFORMAT mdy;
	DECLARE @thisFriday date = dateadd(d, -((datepart(weekday, getdate()) + 1 + @@DATEFIRST) % 7), getdate())
	DECLARE @nextFriday date = dateadd(day, 7, dateadd(d, -((datepart(weekday, getdate()) + 1 + @@DATEFIRST) % 7), getdate()))

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
			--AND @EndDate < [cust_salc_rcclient_help].completed_on
			THEN 1
		ELSE 0
	END ) = 1
	AND (CASE
		WHEN @HelpSubTypeId > 0
		THEN
			CASE
				WHEN @HelpSubTypeId = [cust_salc_rc_help].sub_type
				THEN 1
				ELSE 0
			END
		ELSE 1
	END) = 1
	--AND @StartDate >= [cust_salc_rcclient_help].[date]
	AND [cust_salc_rc_help].[organization_id] = @OrganizationId
ORDER BY [Counter] ASC
	
SELECT
	[cust_salc_rc_clients].id AS [PersonId],
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
INTO #tempLast
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
			--AND @EndDate < HELP.completed_on
			THEN 1
		ELSE 1
	END ) = 1
	AND (CASE
		WHEN @HelpSubTypeId > 0
		THEN
			CASE
				WHEN @HelpSubTypeId = HELP.sub_type
				THEN 1
				ELSE 0
			END
		ELSE 1
	END) = 1
	--AND @StartDate >= HELP.[date]
	AND [cust_salc_rc_clients].[organization_id] = @OrganizationId
ORDER BY [Count]

	;WITH Calendar AS
		(
			SELECT @StartDate AS [Date]
			UNION ALL
			SELECT DATEADD(d, 1, [Date])
			FROM Calendar
			WHERE [Date] < @EndDate
		)
	SELECT
		[cust_salc_rc_clients].[id] AS [person_id],
		[first_name] + ' ' + [last_name] AS [name],
		[date] AS [date],
		(CASE
			WHEN [income_mfip] > 0
			THEN 
				CASE
					WHEN CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])) + '/' + CONVERT(varchar, [mfip_day]) + '/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101) >= CONVERT(date, CONVERT(varchar, MONTH(Calendar.[Date])) + '/' + CONVERT(varchar, DAY(Calendar.[Date])) + '/' + CONVERT(varchar, YEAR(Calendar.[Date])), 101)
					THEN CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])) + '/' + CONVERT(varchar, [mfip_day]) + '/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101)
					ELSE DATEADD(mm, 1, CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])) + '/' + CONVERT(varchar, [mfip_day]) + '/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101))
				END
			ELSE CONVERT(date, '1/1/1901', 101)
		END) AS [mfip_date],
		income_mfip AS [mfip_amount],					
		(CASE
			WHEN [income_ssissdi] > 0
			THEN 
				CASE
					WHEN CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])) + '/1/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101) >= CONVERT(date, CONVERT(varchar, MONTH(Calendar.[Date])) + '/' + CONVERT(varchar, DAY(Calendar.[Date])) + '/' + CONVERT(varchar, YEAR(Calendar.[Date])), 101)
					THEN CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])) + '/1/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101)
					ELSE DATEADD(mm, 1, CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])) + '/1/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101))
				END
			ELSE CONVERT(date, '1/1/1901', 101)
		END) AS [ssi_date],
		income_ssissdi AS [ssi_amount],
		(CASE
			WHEN [income_childsupport] > 0 AND [childsupport_date] >= CONVERT(date, CONVERT(varchar, MONTH(Calendar.[Date])) + '/' + CONVERT(varchar, DAY(Calendar.[Date])) + '/' + CONVERT(varchar, YEAR(Calendar.[Date])), 101)
			THEN [childsupport_date]
			ELSE CONVERT(date, '1/1/1901', 101)
		END) AS [childsupport_date],
		(CASE
			WHEN [income_childsupport] > 0 AND [childsupport_date] >= CONVERT(date, CONVERT(varchar, MONTH(Calendar.[Date])) + '/' + CONVERT(varchar, DAY(Calendar.[Date])) + '/' + CONVERT(varchar, YEAR(Calendar.[Date])), 101)
			THEN [income_childsupport]
			ELSE 0
		END) AS [childsupport_amount],

		(CASE
			WHEN [income_other] > 0 AND [othersources_date] >= CONVERT(date, CONVERT(varchar, MONTH(Calendar.[Date])) + '/' + CONVERT(varchar, DAY(Calendar.[Date])) + '/' + CONVERT(varchar, YEAR(Calendar.[Date])), 101)
			THEN [othersources_date]
			ELSE CONVERT(date, '1/1/1901', 101)
		END) AS [other_date],
		(CASE
			WHEN [income_other] > 0 AND [othersources_date] >= CONVERT(date, CONVERT(varchar, MONTH(Calendar.[Date])) + '/' + CONVERT(varchar, DAY(Calendar.[Date])) + '/' + CONVERT(varchar, YEAR(Calendar.[Date])), 101)
			THEN [income_other]
			ELSE 0
		END) AS [other_amount],
		(CASE
			WHEN [income_unemployment] > 0 
			THEN CASE
				WHEN @thisFriday >= CONVERT(date, CONVERT(varchar, MONTH(Calendar.[Date])) + '/' + CONVERT(varchar, DAY(Calendar.[Date])) + '/' + CONVERT(varchar, YEAR(Calendar.[Date])), 101)
				THEN @thisFriday
				ELSE @nextFriday
			END
			ELSE CONVERT(date, '1/1/1901', 101)
		END) AS [unemployment_date],
		([income_unemployment] / 4) AS [unemployment_amount],
		(CASE
			WHEN [income_employment] > 0
			THEN dbo.cust_funct_salc_GetNextDate([employment_date], Calendar.[Date], [employment_frequency])
			ELSE CONVERT(date, '1/1/1901', 101)
		END) AS [employment_date],
		ROUND(([income_employment] / 28 * [employment_frequency]), 2) AS [employment_amount]
	INTO #tempDates
	FROM Calendar
		FULL JOIN cust_salc_rc_clients
			ON Calendar.[Date] <> [birthday]
		INNER JOIN #tempLast
			ON #tempLast.PersonId = cust_salc_rc_clients.id
	WHERE 
		(CASE 
			WHEN @PersonId > 1
			THEN 
				CASE 
					WHEN cust_salc_rc_clients.id = @PersonId
					THEN 1
					ELSE 0
				END
			ELSE 1
		END) = 1
	OPTION(MAXRECURSION 0);
	
	SELECT DISTINCT
		[person_id],
		[Name] AS [Name],
		'Employment' AS [Type],
		[employment_amount] AS [Amount],
		[employment_date] AS [Date]
	FROM #tempDates
	WHERE [employment_date] >= @StartDate
		AND [employment_date] <= @EndDate
	
	UNION

	SELECT DISTINCT
		[person_id],
		[Name] AS [Name],
		'MFIP' AS [Type],
		[mfip_amount] AS [Amount],
		[mfip_date] AS [Date]
	FROM #tempDates
	WHERE [mfip_date] >= @StartDate
		AND [mfip_date] <= @EndDate
	
	UNION

	SELECT DISTINCT
		[person_id],
		[Name] AS [Name],
		'Unemployment' AS [Type],
		[unemployment_amount] AS [Amount],
		[unemployment_date] AS [Date]
	FROM #tempDates
	WHERE [unemployment_date] >= @StartDate
		AND [unemployment_date] <= @EndDate

	UNION

	SELECT DISTINCT
		[person_id],
		[Name] AS [Name],
		'Child Support' AS [Type],
		[childsupport_amount] AS [Amount],
		[childsupport_date] AS [Date]
	FROM #tempDates
	WHERE [childsupport_date] >= @StartDate
		AND [childsupport_date] <= @EndDate

	UNION

	SELECT DISTINCT
		[person_id],
		[Name] AS [Name],
		'Other' AS [Type],
		[other_amount] AS [Amount],
		[other_date] AS [Date]
	FROM #tempDates
	WHERE [other_date] >= @StartDate
		AND [other_date] <= @EndDate
	
	ORDER BY [Date]
END

GO

