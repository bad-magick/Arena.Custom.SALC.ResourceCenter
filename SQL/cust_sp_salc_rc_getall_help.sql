USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_help]    Script Date: 04/13/2012 13:38:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 02/18/2012
-- Description:	Gets all help entries for a person_id
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_help]
	@PersonId INT, 
	@OrganizationId INT
AS
BEGIN
	SET NOCOUNT ON;

SELECT
	*
FROM
	cust_salc_rc_help
		INNER JOIN cust_salc_rc_help_link
			ON cust_salc_rc_help.id = cust_salc_rc_help_link.help_id
		INNER JOIN cust_salc_rc_clients
			ON cust_salc_rc_help_link.person_id = cust_salc_rc_clients.id
WHERE
	cust_salc_rc_help_link.person_id = @PersonId
	AND cust_salc_rc_clients.organization_id = @OrganizationId
ORDER BY [date] DESC
END


GO

