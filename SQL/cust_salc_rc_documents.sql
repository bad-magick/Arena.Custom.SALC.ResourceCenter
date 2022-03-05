USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_documents]    Script Date: 04/13/2012 12:55:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_rc_documents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent] [int] NOT NULL,
	[parent_id] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[mime] [varchar](50) NOT NULL,
	[size] [int] NOT NULL,
	[data] [varbinary](max) NOT NULL,
	[created_by] [varchar](50) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[updated_by] [varchar](50) NOT NULL,
	[date_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_cust_salc_rc_documents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

