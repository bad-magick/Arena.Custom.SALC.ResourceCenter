USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getbyid_meal]    Script Date: 04/13/2012 13:40:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/11/2012
-- Description:	Gets a meal file with the specified ID
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getbyid_meal]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM cust_salc_rc_meals WHERE cust_salc_rc_meals.id = @id
END


GO

