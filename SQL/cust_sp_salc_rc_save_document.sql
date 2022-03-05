USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_rc_save_document]    Script Date: 04/13/2012 13:43:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 03/27/2012
-- Description:	Save Resource Center assistance data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_rc_save_document]
	@DocumentId int,
	@Parent int,
	@ParentId int,
	@Name varchar(50),
	@Mime varchar(50),
	@Size int,
	@Data varbinary(max),
	@UserId varchar(50),
	@ID int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS(
		SELECT * FROM cust_salc_rc_documents
		WHERE [id] = @DocumentId
		)
	BEGIN
		INSERT INTO cust_salc_rc_documents
		(
			[parent],
			[parent_id],
			[name],
			[mime],
			[size],
			[data],
			[created_by],
			[date_created],
			[updated_by],
			[date_updated]
		)
		values
		(
			@Parent,
			@ParentId,
			@Name,
			@Mime,
			@Size,
			@Data,
			@UserId,
			sysdatetimeoffset(),
			@UserId,
			sysdatetimeoffset()
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_rc_documents Set
			[parent] = @Parent,
			[parent_id] = @ParentId,
			[name] = @Name,
			--[mime] = @Mime,
			--[size] = @Size,
			--[data] = @Data,
			[updated_by] = @UserId,
			[date_updated] = sysdatetimeoffset()
		WHERE [id] = @DocumentId
		SET @ID = @DocumentId
	END
END



GO

