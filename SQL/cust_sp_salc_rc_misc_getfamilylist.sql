USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_misc_getfamilylist]    Script Date: 04/13/2012 13:41:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Generates the "family" list
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_misc_getfamilylist]
	@PersonId int, --protype of person to compare against
	@OrganizationID int
AS
BEGIN
	DECLARE @Street varchar(50), @City varchar(50), @Zip varchar(10), @State varchar(2), @County varchar(50), @ID int
	BEGIN
	SELECT TOP 1
		@Street = [street_address],
		@City = [city],
		@Zip = [postal_code],
		@State = [state],
		@County = [county_of_origin]
	FROM
		cust_salc_rc_clients
	WHERE
		cust_salc_rc_clients.id = @PersonId
	END
	
	--get everyone of interest
	SELECT
		birthday AS [Last_Shelter],
		birthday AS [Last_Shelter_Exit],
		*
	FROM 
		cust_salc_rc_clients
	WHERE
		cust_salc_rc_clients.street_address LIKE @Street AND
		cust_salc_rc_clients.city LIKE @City AND
		cust_salc_rc_clients.postal_code LIKE @Zip AND
		cust_salc_rc_clients.state LIKE @State AND
		cust_salc_rc_clients.id <> @PersonId AND
		cust_salc_rc_clients.organization_id = @OrganizationID
END


GO

