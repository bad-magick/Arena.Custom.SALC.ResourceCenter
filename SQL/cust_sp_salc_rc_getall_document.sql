USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_getall_document]    Script Date: 04/13/2012 13:38:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Returns all assistance types
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_getall_document]
	@Parent int,
	@ParentId int
AS
BEGIN
	SELECT
		[id],
		[parent],
		[parent_id],
		[name],
		[mime],
		[size],
		null as [data],
		[created_by],
		[date_created],
		[updated_by],
		[date_updated]
	FROM [cust_salc_rc_documents]
	WHERE 
		[parent] = @Parent
		AND [parent_id] = @ParentId
	ORDER BY [date_created] ASC
END


GO

