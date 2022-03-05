USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_misc_getclientsonhelp]    Script Date: 04/13/2012 13:41:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 02/18/2012
-- Description:	Gets all help entries for a person_id
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_misc_getclientsonhelp]
	@HelpId int
AS
BEGIN
	SET NOCOUNT ON;

SELECT
	[cust_salc_rc_help].[date] AS [Last_Shelter],
	[birthday] AS [Last_Shelter_Exit],
	*
FROM
  cust_salc_rc_clients
  INNER JOIN cust_salc_rc_help_link
    ON cust_salc_rc_clients.id = cust_salc_rc_help_link.person_id
  INNER JOIN cust_salc_rc_help
    ON cust_salc_rc_help_link.help_id = cust_salc_rc_help.id
WHERE
  cust_salc_rc_help_link.help_id = @HelpId
ORDER BY [date] DESC
END


GO

