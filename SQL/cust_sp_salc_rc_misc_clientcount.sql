USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_misc_clientcount]    Script Date: 04/13/2012 13:41:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Den Boice
-- Create date: 3/24/3012
-- Description:	Returns the number of RC clients with the same address
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_misc_clientcount] 
(
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@Street VARCHAR(50),
	@ZipCode VARCHAR(50),
	@Exclude INT,
	@COUNT INT OUTPUT
)
AS
BEGIN
	DECLARE @ResultVar INT
	
	IF @FirstName = ''
		SET @FirstName = '%'
	IF @LastName = ''
		SET @LastName = '%'
	IF @Street = ''
		SET @Street = '%'
	IF @ZipCode = ''
		SET @ZipCode = '%'

	SET @COUNT =
	(
		SELECT
			COUNT(*) 
		FROM cust_salc_rc_clients C 
		WHERE
			C.street_address LIKE @Street
			AND C.postal_code LIKE @ZipCode
			AND C.first_name LIKE @FirstName
			AND C.last_name LIKE @LastName
			AND C.id <> @Exclude
	)

END

GO

