USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_misc_generatehelplinks]    Script Date: 04/13/2012 13:41:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 02/28/2012
-- Description:	Generates help links for a given helpid using a personid as a prototype
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_misc_generatehelplinks]
	@helpid int,  --help to be used
	@personid int --protype of person to compare against
AS
BEGIN
	DECLARE @Street varchar(50), @City varchar(50), @Zip varchar(10), @State varchar(2), @County varchar(50), @ID int
	SELECT TOP 1
		@Street = [street_address],
		@City = [city],
		@Zip = [postal_code],
		@State = [state],
		@County = [county_of_origin]
	FROM
		cust_salc_rc_clients
	WHERE
		cust_salc_rc_clients.id = @personid

	--get everyone of interest
	SELECT * INTO #helptemp FROM cust_salc_rc_clients WHERE
		cust_salc_rc_clients.street_address = @Street AND
		cust_salc_rc_clients.city = @City AND
		cust_salc_rc_clients.postal_code = @Zip AND
		cust_salc_rc_clients.state = @State

	--add them...
	WHILE EXISTS (SELECT * FROM #helptemp)
	BEGIN
		SELECT TOP 1 @ID = id FROM #helptemp

		INSERT INTO cust_salc_rc_help_link
		(
			[person_id],
			[help_id]
		)
		VALUES
		(
			@ID,
			@helpid
		)
		DELETE #helptemp WHERE id = @ID
	END
	
	--update original help entry with address information
	UPDATE cust_salc_rc_help SET
		[address] = @Street,
		[city] = @City,
		[zip] = @Zip,
		[state] = @State,
		[county] = @County
	WHERE
		id = @helpid
END


GO

