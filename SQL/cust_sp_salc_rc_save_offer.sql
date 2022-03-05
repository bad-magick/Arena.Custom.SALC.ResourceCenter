USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_save_offer]    Script Date: 04/13/2012 13:44:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Den Boice
-- Create date: 03/31/2012
-- Description:	Save Resource Center assistance data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_save_offer]
	@OfferId int,
	@UserId varchar(50),
	@PersonId int,
	@GivenToId int,
	@CallId int,
	@Date date,
	@Type int,
	@Description varchar(50),
	@Size int,
	@Amount decimal,
	@Status int,
	@Name varchar(50),
	@Phone varchar(20),
	@Notes text,
	@OrganizationId int,
	@ID int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS(
		SELECT * FROM cust_salc_rc_offers
		WHERE [id] = @OfferId
		)
	BEGIN
		INSERT INTO cust_salc_rc_offers
		(
			[date_created],
			[date_updated],
			[created_by],
			[updated_by],
			[person_id],
			[givento_id],
			[call_id],
			[date],
			[type],
			[description],
			[size],
			[amount],
			[status],
			[name],
			[phone],
			[notes],
			[organization_id]
		)
		values
		(
			convert(date, getdate()),
			convert(date, getdate()),
			@UserId,
			@UserId,
			@PersonId,
			@GivenToId,
			@CallId,
			@Date,
			@Type,
			@Description,
			@Size,
			@Amount,
			@Status,
			@Name,
			@Phone,
			@Notes,
			@OrganizationId
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_rc_offers Set
			[updated_by] = @UserId,
			[date_updated] = convert(date, getdate()),
			[person_id] = @PersonId,
			[givento_id] = @GivenToId,
			[call_id] = @CallId,
			[date] = @Date,
			[type] = @Type,
			[description] = @Description,
			[size] = @Size,
			[amount] = @Amount,
			[status] = @Status,
			[name] = @Name,
			[phone] = @Phone,
			[notes] = @Notes,
			[organization_id] = @OrganizationId
		WHERE [id] = @OfferId
		SET @ID = @OfferId
	END
END




GO

