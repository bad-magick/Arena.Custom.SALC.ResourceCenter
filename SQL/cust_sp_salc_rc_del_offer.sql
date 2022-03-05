USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_del_offer]    Script Date: 04/13/2012 13:36:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Den Boice
-- Create date: 03/18/2012
-- Description:	Delete Resource Center donation data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_del_offer]
	-- Add the parameters for the stored procedure here
	@OfferId int
AS
BEGIN
	DELETE
		cust_salc_rc_offers
	WHERE
		[id] = @OfferId		
END




GO

