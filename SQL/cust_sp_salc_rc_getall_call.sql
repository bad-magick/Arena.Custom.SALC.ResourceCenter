USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_call]    Script Date: 04/13/2012 13:37:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/13/2012
-- Description:	Returns all calls from the calls table based on search criteria
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_call]
	@StartDate DATE,
	@EndDate DATE,
	@MessageFor VARCHAR(50),
	@Search VARCHAR(50),
	@Status int,
	@PersonId int,
	@OrganizationId int
AS
BEGIN
	IF @MessageFor = '' SET @MessageFor = '%'
	IF @Search = '' SET @Search = '%'
	IF @StartDate IS NULL SET @StartDate = CONVERT(DATETIME, CONVERT(VARCHAR, GETDATE(), 101), 101)
	IF @EndDate IS NULL SET @EndDate = DATEADD(d, 1, CONVERT(DATETIME, CONVERT(VARCHAR, GETDATE(), 101), 101))
	SELECT
		[msg_for] AS [MessageFor],
		*
	FROM [cust_salc_rc_calls]
		LEFT JOIN cust_salc_rc_clients ON cust_salc_rc_clients.id = cust_salc_rc_calls.person_id
	WHERE [date] BETWEEN @StartDate AND @EndDate
		AND [msg_for] LIKE @MessageFor
		AND (
			[phone] LIKE @Search
			OR [county] LIKE @Search
			OR cust_salc_rc_calls.[notes] LIKE @Search
			OR (CASE
				WHEN [cust_salc_rc_calls].[person_id] > 0
				THEN
					CASE
						WHEN cust_salc_rc_clients.first_name LIKE @Search OR cust_salc_rc_clients.last_name LIKE @Search
						THEN 1
						ELSE 0
					END
				ELSE
					CASE
						WHEN [name] LIKE @Search
						THEN 1
						ELSE 0
					END
				END) = 1
		) AND (
			CASE 
				WHEN @Status <> 0 AND @Status = [completed]
				THEN 1
				WHEN @Status = 0
				THEN 1
				WHEN @Status = 1024 AND [completed] = 0
				THEN 1
				WHEN @Status = 1025 AND [completed] = 2
				THEN 1
				WHEN @Status = 1026 AND [completed] = 1
				THEN 1
				ELSE 0
			END
		) = 1
		AND (CASE 
			WHEN @PersonId = 0
			THEN
				CASE
					WHEN @OrganizationId = cust_salc_rc_calls.[organization_id]
					THEN 1
					ELSE 0
				END
			ELSE
				CASE
					WHEN @PersonId = [person_id]
					THEN 1
					ELSE 0
				END
		END) = 1
	ORDER BY [Date] DESC
END


GO

