USE [ArenaDB]
GO

/****** Object:  UserDefinedFunction [dbo].[cust_funct_salc_RemoveNonNumericChar]    Script Date: 04/13/2012 13:46:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Den Boice
-- Create date: 03/15/2012
-- Description:	Remove non-numeric characters from varchar
-- =============================================
create function [dbo].[cust_funct_salc_RemoveNonNumericChar](@str varchar(500))  
returns varchar(500)  
begin  
declare @startingIndex int  
set @startingIndex=0  
while 1=1  
begin  
    set @startingIndex= patindex('%[^0-9]%',@str)  
    if @startingIndex <> 0  
    begin  
        set @str = replace(@str,substring(@str,@startingIndex,1),'')  
    end  
    else    break;   
end  
return @str  
end


GO

