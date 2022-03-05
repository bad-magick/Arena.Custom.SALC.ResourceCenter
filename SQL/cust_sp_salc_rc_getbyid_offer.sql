USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getbyid_offer]    Script Date: 04/13/2012 13:41:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/18/2012
-- Description:	Gets a donation file with the specified ID
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getbyid_offer]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		*
	FROM cust_salc_rc_offers 
		INNER JOIN dbo.core_person
		ON core_person.person_id = cust_salc_rc_offers.person_id
	WHERE cust_salc_rc_offers.id = @id
END



GO

