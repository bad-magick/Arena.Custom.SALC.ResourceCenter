USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_save_meal]    Script Date: 04/13/2012 13:44:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/10/2012
-- Description:	Save Resource Center meal data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_save_meal]
	-- Add the parameters for the stored procedure here
	@MealId int,
	@UserId varchar(50),
	@Date date,
	@Served int,
	@Meals int,
	@Dist int,
	@Pounds int,
	@ID int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    DECLARE @UpdateDateTime DateTime SET @UpdateDateTime = GETDATE()
    
    IF NOT EXISTS(
		SELECT * FROM cust_salc_rc_meals
		WHERE [id] = @MealId
		)
	BEGIN
		INSERT INTO cust_salc_rc_meals
		(
			[date],
			[served],
			[meals],
			[dist],
			[pounds],
			[date_created],
			[created_by],
			[date_updated],
			[updated_by]
		)
		values
		(
			@Date,
			@Served,
			@Meals,
			@Dist,
			@Pounds,
			@UpdateDateTime,
			@UserId,
			@UpdateDateTime,
			@UserId
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_rc_meals Set
			[date] = @Date,
			[served] = @Served,
			[meals] = @Meals,
			[dist] = @Dist,
			[pounds] = @Pounds,
			[date_updated] = @UpdateDateTime,
			[updated_by] = @UserId
		WHERE [id] = @MealId
		SET @ID = @MealId
	END
END



GO

