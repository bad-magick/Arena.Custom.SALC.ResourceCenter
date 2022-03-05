USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_del_help]    Script Date: 04/13/2012 13:36:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 02/08/2012
-- Description:	Save Resource Center client data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_del_help]
	-- Add the parameters for the stored procedure here
	@helpId int,
	@personId int,
	@CODE int OUTPUT
AS
BEGIN
	DELETE
		cust_salc_rc_help_link
	WHERE
		[help_id] = @helpId AND
		[person_id] = @personId
		
	IF NOT EXISTS (SELECT * FROM cust_salc_rc_help_link WHERE help_id = @helpId)
	BEGIN
		DELETE
			cust_salc_rc_help
		WHERE
			[id] = @helpId
			
		DELETE
			cust_salc_rc_accounts
		WHERE
			[help_id] = @helpId
			
		SET @CODE = 0
	END
	ELSE
	BEGIN
		SET @CODE = 1
	END
END



GO

