USE [ArenaDB]
GO

/****** Object:  UserDefinedFunction [dbo].[cust_funct_salc_GetNextDate]    Script Date: 04/13/2012 13:45:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[cust_funct_salc_GetNextDate]
(
	@BeginDate DATE, --any arbitrary date that event occured and will reoccur
	@CurrentDate DATE, --date at which the function will suppose is today
	@Interval INT --in days
)
RETURNS DATE
AS
BEGIN
	DECLARE @NewDate DATE
	DECLARE @StartDate DATE = DATEADD(dd, @Interval * CAST(DATEDIFF(dd, @BeginDate, DATEDIFF(dd, -1, CONVERT(DATE, @CurrentDate))) / @Interval + 1 AS INT), @BeginDate)

	IF @BeginDate > @CurrentDate
		SET @NewDate = @BeginDate
	ELSE
		SET @NewDate = DATEADD(dd, (CEILING(DATEDIFF (dd, @StartDate, @CurrentDate) / @Interval) * @Interval), @StartDate)
	RETURN @NewDate
END
GO

