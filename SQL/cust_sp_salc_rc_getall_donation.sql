USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_donation]    Script Date: 04/13/2012 13:38:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/18/2012
-- Description:	Returns all donation from the donations table based on search criteria
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_donation]
	@StartDate DATE,
	@EndDate DATE,
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@Type INT = -1,
	@OrganizationId INT = 1
AS
BEGIN
	IF @FirstName = '' SET @FirstName = '%' ELSE SET @FirstName = '%' + @FirstName + '%'
	IF @LastName = '' SET @LastName = '%' ELSE SET @LastName = '%' + @LastName + '%'
	IF @StartDate IS NULL SET @StartDate = CONVERT(DATETIME, '1/1/1901', 101)
	IF @EndDate IS NULL SET @EndDate = DATEADD(d, 1, CONVERT(DATETIME, '12/31/2199', 101))
	SELECT
		*
	FROM [cust_salc_rc_donations]
		LEFT JOIN core_person ON core_person.person_id = cust_salc_rc_donations.person_id
	WHERE [date] BETWEEN @StartDate AND @EndDate
		AND (CASE
			WHEN cust_salc_rc_donations.person_id > 0
			THEN
				CASE
					WHEN core_person.first_name LIKE @FirstName AND core_person.last_name LIKE @LastName
					THEN 1
					ELSE 1
				END
			ELSE
				CASE
					WHEN 'Anonymous' LIKE @FirstName AND 'Anonymous' LIKE @LastName
					THEN 1
					ELSE 0
				END
			END) = 1
		AND (CASE
			WHEN @Type < 0
				THEN 1
			WHEN @Type < 0 AND @Type = [type]
				THEN 1
			ELSE 0
		END) = 1
		AND @OrganizationId = cust_salc_rc_donations.organization_id
	ORDER BY [Date] DESC
END


GO

