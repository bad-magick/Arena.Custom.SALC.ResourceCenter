USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_help]    Script Date: 04/13/2012 12:56:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_rc_help](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[type] [int] NULL,
	[amount] [decimal](18, 0) NULL,
	[size] [int] NULL,
	[description] [varchar](50) NULL,
	[sub] [int] NULL,
	[sub_recieved] [decimal](18, 0) NULL,
	[sub_source] [varchar](50) NULL,
	[vendor] [varchar](50) NULL,
	[complete] [varchar](50) NULL,
	[assistant] [varchar](50) NULL,
	[completed_on] [date] NULL,
	[resolution] [text] NULL,
	[sub_type] [int] NULL,
	[notes] [text] NULL,
	[address] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[zip] [varchar](10) NULL,
	[state] [varchar](2) NULL,
	[county] [varchar](50) NULL,
	[date_created] [date] NULL,
	[created_by] [varchar](50) NULL,
	[date_updated] [date] NULL,
	[updated_by] [varchar](50) NULL,
	[organization_id] [int] NOT NULL,
 CONSTRAINT [PK_cust_salc_rcclient_help] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_salc_rc_help] ADD  CONSTRAINT [DF_cust_salc_rcclient_help_OrganizationId]  DEFAULT ((1)) FOR [organization_id]
GO

