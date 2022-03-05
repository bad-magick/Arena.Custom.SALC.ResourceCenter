USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_save_account]    Script Date: 04/13/2012 13:43:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Save Resource Center assistance data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_save_account]
	@AccountId int,
	@HelpId int,
	@Amount decimal,
	@Date date,
	@Note text,
	@OrganizationId int,
	@ID int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS(
		SELECT * FROM cust_salc_rc_accounts
		WHERE [id] = @AccountId
		)
	BEGIN
		INSERT INTO cust_salc_rc_accounts
		(
			[help_id],
			[amount],
			[date],
			[note],
			[organization_id]
		)
		values
		(
			@HelpId,
			@Amount,
			@Date,
			@Note,
			@OrganizationId
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_rc_accounts Set
			[help_id] = @HelpId,
			[amount] = @Amount,
			[date] = @Date,
			[note] = @Note,
			[organization_id] = @OrganizationId
		WHERE [id] = @AccountId
		SET @ID = @AccountId
	END
END



GO

