USE [ArenaDB]
GO

/****** Object:  UserDefinedFunction [dbo].[cust_funct_salc_RemoveNonAlphanumericChar]    Script Date: 04/13/2012 13:45:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[cust_funct_salc_RemoveNonAlphanumericChar]
(
    @BadString nvarchar(50)
)
RETURNS nvarchar(50)
AS
BEGIN

            DECLARE @nPos INTEGER
            SELECT @nPos = PATINDEX('%[^a-zA-Z0-9_]%', @BadString)

            WHILE @nPos > 0
            BEGIN
                        SELECT @BadString = STUFF(@BadString, @nPos, 1, '')
                        SELECT @nPos = PATINDEX('%[^a-zA-Z0-9_]%', @BadString)
            END

            RETURN @BadString
END
GO

