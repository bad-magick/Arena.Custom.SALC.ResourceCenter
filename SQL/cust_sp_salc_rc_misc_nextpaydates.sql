USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_misc_nextpaydates]    Script Date: 04/13/2012 13:42:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Den Boice
-- Create date: 3/28/3012
-- Description:	Returns the date and amount of next payday
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_misc_nextpaydates] 
(
	@Date date,
	@DayCount int,
	@PersonId int
)
AS
BEGIN
	DECLARE @thisFriday date = dateadd(d, -((datepart(weekday, getdate()) + 1 + @@DATEFIRST) % 7), getdate())
	DECLARE @nextFriday date = dateadd(day, 7, dateadd(d, -((datepart(weekday, getdate()) + 1 + @@DATEFIRST) % 7), getdate()))
	
	;WITH Calendar AS
		(
			SELECT @Date AS [Date]
			UNION ALL
			SELECT DATEADD(d, 1, [Date])
			FROM Calendar
			WHERE [Date] < DATEADD(d, @DayCount, @Date)
		)
	SELECT
		[first_name] + ' ' + [last_name] AS [Name],
		[Date] AS [Date],
		(CASE
			WHEN [income_mfip] > 0
			THEN 
				CASE
					WHEN CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])) + '/' + CONVERT(varchar, [mfip_day]) + '/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101) >= CONVERT(date, CONVERT(varchar, MONTH(Calendar.[Date])) + '/' + CONVERT(varchar, DAY(Calendar.[Date])) + '/' + CONVERT(varchar, YEAR(Calendar.[Date])), 101)
					THEN CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])) + '/' + CONVERT(varchar, [mfip_day]) + '/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101)
					ELSE CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])+1) + '/' + CONVERT(varchar, [mfip_day]) + '/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101)
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
					ELSE CONVERT(date, CONVERT(varchar, DATEPART(month, Calendar.[Date])+1) + '/1/' + CONVERT(varchar, DATEPART(year, Calendar.[Date])), 101)
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
	WHERE id = @PersonId
	
	OPTION(MAXRECURSION 0);
	
	SELECT DISTINCT
		[Name] AS [Name],
		'Employment' AS [Type],
		[employment_amount] AS [Amount],
		[employment_date] AS [Date]
	FROM #tempDates
	WHERE [employment_date] >= @Date
	
	UNION

	SELECT DISTINCT
		[Name] AS [Name],
		'MFIP' AS [Type],
		[mfip_amount] AS [Amount],
		[mfip_date] AS [Date]
	FROM #tempDates
	WHERE [mfip_date] >= @Date
	
	UNION

	SELECT DISTINCT
		[Name] AS [Name],
		'Unemployment' AS [Type],
		[unemployment_amount] AS [Amount],
		[unemployment_date] AS [Date]
	FROM #tempDates
	WHERE [unemployment_date] >= @Date

	UNION

	SELECT DISTINCT
		[Name] AS [Name],
		'Child Support' AS [Type],
		[childsupport_amount] AS [Amount],
		[childsupport_date] AS [Date]
	FROM #tempDates
	WHERE [childsupport_date] >= @Date

	UNION

	SELECT DISTINCT
		[Name] AS [Name],
		'Other' AS [Type],
		[other_amount] AS [Amount],
		[other_date] AS [Date]
	FROM #tempDates
	WHERE [other_date] >= @Date
	
	ORDER BY [Date]
END

GO

