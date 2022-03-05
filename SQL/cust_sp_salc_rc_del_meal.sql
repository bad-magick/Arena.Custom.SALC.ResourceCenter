USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_del_meal]    Script Date: 04/13/2012 13:36:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/12/2012
-- Description:	Delete Resource Center meal data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_del_meal]
	-- Add the parameters for the stored procedure here
	@MealId int
AS
BEGIN
	DELETE
		cust_salc_rc_meals
	WHERE
		[id] = @MealId		
END



GO

