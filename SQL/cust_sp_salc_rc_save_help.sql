USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_save_help]    Script Date: 04/13/2012 13:44:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 02/08/2012
-- Description:	Save Resource Center client data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_save_help]
	-- Add the parameters for the stored procedure here
	@HelpId int,
	@UserId varchar(50),
	@Date date,
	@Type int,
	@Amount decimal,
	@Size int,
	@Description varchar(50),
	@Subsidized int,
	@SubAmount decimal,
	@SubSource varchar(50),
	@Vendor varchar(50),
	@Complete varchar(50),
	@Assistant varchar(50),
	@DateCompleted date,
	@Resolution text,
	@SubType int,
	@Notes text,
	@Address varchar(50),
	@City varchar(50),
	@Zip varchar(10),
	@State varchar(2),
	@County varchar(50),
	@ID int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    DECLARE @UpdateDateTime DateTime SET @UpdateDateTime = GETDATE()
    
    IF NOT EXISTS(
		SELECT * FROM cust_salc_rc_help
		WHERE [id] = @HelpId
		)
	BEGIN
		INSERT INTO cust_salc_rc_help
		(
			[date],
			[type],
			[amount],
			[size],
			[description],
			[sub],
			[sub_recieved],
			[sub_source],
			[vendor],
			[complete],
			[assistant],
			[completed_on],
			[resolution],
			[sub_type],
			[notes],
			[address],
			[city],
			[zip],
			[state],
			[county],
			[date_created],
			[created_by],
			[date_updated],
			[updated_by]
		)
		values
		(
			@Date,
			@Type,
			@Amount,
			@Size,
			@Description,
			@Subsidized,
			@SubAmount,
			@SubSource,
			@Vendor,
			@Complete,
			@Assistant,
			@DateCompleted,
			@Resolution,
			@SubType,
			@Notes,
			@Address,
			@City,
			@Zip,
			@State,
			@County,
			@UpdateDateTime,
			@UserId,
			@UpdateDateTime,
			@UserId
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_rc_help Set
			[date] = @Date,
			[type] = @Type,
			[amount] = @Amount,
			[size] = @Size,
			[description] = @Description,
			[sub] = @Subsidized,
			[sub_recieved] = @SubAmount,
			[sub_source] = @SubSource,
			[vendor] = @Vendor,
			[complete] = @Complete,
			[assistant] = @Assistant,
			[completed_on] = @DateCompleted,
			[resolution] = @Resolution,
			[sub_type] = @SubType,
			[notes] = @Notes,
			[address] = @Address,
			[city] = @City,
			[zip] = @Zip,
			[state] = @State,
			[date_updated] = @UpdateDateTime,
			[updated_by] = @UserId
		WHERE [id] = @HelpId
		SET @ID = @HelpId
	END
END



GO

