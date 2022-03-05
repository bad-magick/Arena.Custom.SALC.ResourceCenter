USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_create_helplink]    Script Date: 04/13/2012 13:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 02/29/2012
-- Description:	Generates help link for a given helpid using a personid
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_create_helplink]
	@helpid int,  --help to be used
	@personid int --protype of person to compare against
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM cust_salc_rcclient_help_link WHERE help_id = @helpid AND person_id = @personid)
	BEGIN
		INSERT INTO cust_salc_rcclient_help_link
		(
			[person_id],
			[help_id]
		)
		VALUES
		(
			@personid,
			@helpid
		)
	END
END


GO

