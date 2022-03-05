USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getbyid_call]    Script Date: 04/13/2012 13:39:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/13/2012
-- Description:	Gets a call file with the specified ID
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getbyid_call]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM cust_salc_rc_calls WHERE cust_salc_rc_calls.id = @id
END


GO

