USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_misc_bulkchangeaddress]    Script Date: 04/13/2012 13:41:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 02/28/2012
-- Description:	Changes al address that match that od @PersonId
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_misc_bulkchangeaddress]
	@PersonId int,
	@UserId varchar(50),
	@Street varchar(50),
	@City varchar(50),
	@Zip varchar(10),
	@State varchar(2),
	@County varchar(50)
AS
BEGIN
	DECLARE @OldStreet varchar(50), @OldCity varchar(50), @OldZip varchar(10), @OldState varchar(2), @OldCounty varchar(50), @ID int
	SELECT TOP 1
		@OldStreet = [street_address],
		@OldCity = [city],
		@OldZip = [postal_code],
		@OldState = [state],
		@OldCounty = [county_of_origin]
	FROM
		cust_salc_rc_clients
	WHERE
		cust_salc_rc_clients.id = @PersonId

	--get everyone of interest
	SELECT * INTO #bulktemp FROM cust_salc_rc_clients WHERE
		cust_salc_rc_clients.street_address = @OldStreet AND
		cust_salc_rc_clients.city = @OldCity AND
		cust_salc_rc_clients.postal_code = @OldZip AND
		cust_salc_rc_clients.state = @OldState

	--change them...
	WHILE EXISTS (SELECT * FROM #bulktemp)
	BEGIN
		SELECT TOP 1 @ID = id FROM #bulktemp

		UPDATE cust_salc_rc_clients SET
			[street_address] = @Street,
			[city] = @City,
			[postal_code] = @Zip,
			[state] = @State,
			[county_of_origin] = @County,
			[date_updated] = GETDATE(),
			[updated_by] = @UserId
		WHERE cust_salc_rc_clients.id = @ID

		DELETE #bulktemp WHERE id = @ID
	END	
END


GO

