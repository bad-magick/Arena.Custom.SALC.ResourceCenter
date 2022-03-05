USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_save_assistance]    Script Date: 04/13/2012 13:43:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Save Resource Center assistance data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_save_assistance]
	@SubTypeId int,
	@Name varchar(50),
	@Units varchar(50),
	@Quantity int,
	@Amount int,
	@Enabled int,
	@OrganizationId int,
	@ID int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS(
		SELECT * FROM cust_salc_rc_assistance
		WHERE [id] = @SubTypeId
		)
	BEGIN
		INSERT INTO cust_salc_rc_assistance
		(
			[name],
			[text],
			[quantity],
			[amount],
			[enabled],
			[organization_id]
		)
		values
		(
			@Name,
			@Units,
			@Quantity,
			@Amount,
			@Enabled,
			@OrganizationId
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_rc_assistance Set
			[name] = @Name,
			[text] = @Units,
			[quantity] = @Quantity,
			[amount] = @Amount,
			[enabled] = @Enabled,
			[organization_id] = @OrganizationId
		WHERE [id] = @SubTypeId
		SET @ID = @SubTypeId
	END
END



GO

