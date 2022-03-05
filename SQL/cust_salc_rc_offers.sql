USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_offers]    Script Date: 04/13/2012 12:56:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_rc_offers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[person_id] [int] NOT NULL,
	[givento_id] [int] NULL,
	[call_id] [int] NULL,
	[date] [datetime] NOT NULL,
	[type] [int] NOT NULL,
	[description] [varchar](50) NULL,
	[size] [int] NULL,
	[amount] [decimal](18, 0) NULL,
	[status] [int] NULL,
	[name] [varchar](50) NULL,
	[phone] [varchar](20) NULL,
	[notes] [text] NULL,
	[created_by] [varchar](50) NOT NULL,
	[date_created] [date] NOT NULL,
	[updated_by] [varchar](50) NOT NULL,
	[date_updated] [date] NOT NULL,
	[organization_id] [int] NOT NULL,
 CONSTRAINT [PK_cust_salc_rc_offers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_salc_rc_offers] ADD  CONSTRAINT [DF_cust_salc_rc_offers_organiztion_id]  DEFAULT ((1)) FOR [organization_id]
GO

