USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_client]    Script Date: 04/13/2012 13:37:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/15/2012
-- Description:	Returns all clients from the clients table based on search criteria
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_client]
	@FirstName VARCHAR(50) = '',
	@LastName VARCHAR(50) = '',
	@Phone VARCHAR(20) = '',
	@Street VARCHAR(50) = '',
	@ZipCode VARCHAR(50) = '',
	@HelpIdExclude INT = 1,
	@OrganizationId INT = 1
AS
BEGIN
	IF @FirstName = '' 
		SET @FirstName = '%'
	ELSE
		SET @FirstName = '%' + @FirstName + '%'
	IF @LastName = '' 
		SET @LastName = '%'
	ELSE
		SET @LastName = '%' + @LastName + '%'
	IF @Street = ''
		SET @Street = '%'
	IF @ZipCode = ''
		SET @ZipCode = '%'
		
	SET @Phone = dbo.cust_funct_salc_RemoveNonNumericChar(@Phone)
	IF @Phone = '' 
		SET @Phone = '%'
	ELSE
		SET @Phone = '%' + @Phone + '%'
	SELECT
		birthday AS [Last_Shelter],
		birthday AS [Last_Shelter_Exit],
		*
	FROM [cust_salc_rc_clients]
	WHERE [first_name] LIKE @FirstName
		AND [last_name] LIKE @LastName
		AND ((
			(dbo.cust_funct_salc_RemoveNonNumericChar([phone_home]) LIKE @Phone AND [phone_home] <> '')
			OR (dbo.cust_funct_salc_RemoveNonNumericChar([phone_mobile]) LIKE @Phone AND [phone_mobile] <> '')
			OR (dbo.cust_funct_salc_RemoveNonNumericChar([phone_other]) LIKE @Phone AND [phone_other] <> '')
			OR (dbo.cust_funct_salc_RemoveNonNumericChar([phone_work]) LIKE @Phone AND [phone_work] <> '')
		) OR (
			phone_mobile = '' AND
			phone_home = '' AND
			phone_work = '' AND
			phone_other = ''
		))
		AND street_address LIKE @Street
		AND postal_code LIKE @ZipCode
		AND (CASE
			WHEN @HelpIdExclude > 0
			THEN
				CASE
					WHEN NOT EXISTS (SELECT 1 FROM cust_salc_rc_help_link WHERE cust_salc_rc_clients.id = cust_salc_rc_help_link.person_id AND cust_salc_rc_help_link.help_id = @HelpIdExclude)
					THEN 1
					ELSE 0
				END
			ELSE 1
		END) = 1
		AND @OrganizationId = [organization_id]
	ORDER BY [last_name] ASC, [first_name] ASC
END


GO

