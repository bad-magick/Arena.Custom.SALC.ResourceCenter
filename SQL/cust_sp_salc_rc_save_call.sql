USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_save_call]    Script Date: 04/13/2012 13:43:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/13/2012
-- Description:	Save Resource Center call data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_save_call]
	-- Add the parameters for the stored procedure here
	@CallId int,
	@UserId varchar(50),
	@Date datetime,
	@Name VARCHAR(50),
	@Phone VARCHAR(20),
	@County VARCHAR(50),
	@MessageFor VARCHAR(50),
	@HH INT,
	@Recieve INT,
	@CallType INT,
	@ReqFood INT,
	@ReqShelter INT,
	@ReqRent INT,
	@ReqUtility INT,
	@ReqFurn INT,
	@ReqOther INT,
	@Notes text,
	@Status INT,
	@PersonId int,
	@OrganizationId int,
	@ID int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    DECLARE @UpdateDateTime DateTime SET @UpdateDateTime = GETDATE()
    
    IF NOT EXISTS(
		SELECT * FROM cust_salc_rc_calls
		WHERE [id] = @CallId
		)
	BEGIN
		INSERT INTO cust_salc_rc_calls
		(
			[date],
			[name],
			[phone],
			[county],
			[msg_for],
			[hh],
			[recieve],
			[call_type],
			[req_food],
			[req_shelter],
			[req_rent],
			[req_utility],
			[req_furn],
			[req_other],
			[notes],
			[completed],
			[person_id],
			[organization_id],
			[date_created],
			[created_by],
			[date_updated],
			[updated_by]
		)
		values
		(
			@Date,
			@Name,
			@Phone,
			@County,
			@MessageFor,
			@HH,
			@Recieve,
			@CallType,
			@ReqFood,
			@ReqShelter,
			@ReqRent,
			@ReqUtility,
			@ReqFurn,
			@ReqOther,
			@Notes,
			@Status,
			@PersonId,
			@OrganizationId,
			@UpdateDateTime,
			@UserId,
			@UpdateDateTime,
			@UserId
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_rc_calls Set
			[date] = @Date,
			[name] = @Name,
			[phone] = @Phone,
			[county] = @County,
			[msg_for] = @MessageFor,
			[hh] = @HH,
			[recieve] = @Recieve,
			[call_type] = @CallType,
			[req_food] = @ReqFood,
			[req_shelter] = @ReqShelter,
			[req_rent] = @ReqRent,
			[req_utility] = @ReqUtility,
			[req_furn] = @ReqFurn,
			[req_other] = @ReqFurn,
			[notes] = @Notes,
			[completed] = @Status,
			[person_id] = @PersonId,
			[organization_id] = @OrganizationId,
			[date_updated] = @UpdateDateTime,
			[updated_by] = @UserId
		WHERE [id] = @CallId
		SET @ID = @CallId
	END
END



GO

