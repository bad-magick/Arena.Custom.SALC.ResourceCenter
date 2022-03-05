USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getbyid_client]    Script Date: 04/13/2012 13:39:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/14/2012
-- Description:	Gets a client based on their PersonID
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getbyid_client]
	-- Add the parameters for the stored procedure here
	@PersonId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 
		(SELECT MAX([date]) 
			FROM dbo.cust_salc_rc_help
				INNER JOIN cust_salc_rc_help_link
					ON cust_salc_rc_help.id = dbo.cust_salc_rc_help_link.help_id
				INNER JOIN cust_salc_rc_clients
					ON cust_salc_rc_clients.id = dbo.cust_salc_rc_help_link.person_id
			WHERE (dbo.cust_salc_rc_help.sub_type = 14
				OR dbo.cust_salc_rc_help.sub_type = 15)
				AND dbo.cust_salc_rc_clients.id = @PersonId
		) AS [Last_Shelter],
		(SELECT MAX([completed_on]) 
			FROM dbo.cust_salc_rc_help
				INNER JOIN cust_salc_rc_help_link
					ON cust_salc_rc_help.id = dbo.cust_salc_rc_help_link.help_id
				INNER JOIN cust_salc_rc_clients
					ON cust_salc_rc_clients.id = dbo.cust_salc_rc_help_link.person_id
			WHERE (dbo.cust_salc_rc_help.sub_type = 14
				OR dbo.cust_salc_rc_help.sub_type = 15)
				AND dbo.cust_salc_rc_clients.id = @PersonId
		) AS [Last_Shelter_Exit],
		*
	FROM cust_salc_rc_clients
	WHERE id = @PersonId
END



GO

