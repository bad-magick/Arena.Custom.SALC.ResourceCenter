USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_save_donation]    Script Date: 04/13/2012 13:44:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/31/2012
-- Description:	Save Resource Center assistance data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_save_donation]
	@DonationId int,
	@UserId varchar(50),
	@PersonId int,
	@Date date,
	@Type int,
	@Description varchar(50),
	@Size int,
	@Amount decimal,
	@Notes text,
	@OrganizationId int,
	@ID int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS(
		SELECT * FROM cust_salc_rc_donations
		WHERE [id] = @DonationId
		)
	BEGIN
		INSERT INTO cust_salc_rc_donations
		(
			[date_created],
			[date_updated],
			[created_by],
			[updated_by],
			[person_id],
			[date],
			[type],
			[description],
			[size],
			[amount],
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
			@Date,
			@Type,
			@Description,
			@Size,
			@Amount,
			@Notes,
			@OrganizationId
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_rc_donations Set
			[updated_by] = @UserId,
			[date_updated] = convert(date, getdate()),
			[person_id] = @PersonId,
			[date] = @Date,
			[type] = @Type,
			[description] = @Description,
			[size] = @Size,
			[amount] = @Amount,
			[notes] = @Notes,
			[organization_id] = @OrganizationId
		WHERE [id] = @DonationId
		SET @ID = @DonationId
	END
END



GO

