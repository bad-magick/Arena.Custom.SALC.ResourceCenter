USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_addresses]    Script Date: 04/13/2012 12:54:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_rc_addresses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[street] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[zip] [varchar](5) NULL,
	[state] [varchar](2) NULL,
	[from] [date] NULL,
	[to] [date] NULL,
 CONSTRAINT [PK_cust_salc_rcclient_address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

