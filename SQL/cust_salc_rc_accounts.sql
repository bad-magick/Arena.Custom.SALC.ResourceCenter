USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_accounts]    Script Date: 04/13/2012 12:54:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cust_salc_rc_accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[help_id] [int] NULL,
	[amount] [decimal](18, 0) NULL,
	[date] [date] NULL,
	[note] [text] NULL,
	[organization_id] [int] NOT NULL,
 CONSTRAINT [PK_cust_salc_rc_accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[cust_salc_rc_accounts] ADD  CONSTRAINT [DF_cust_salc_rc_accounts_organization_id]  DEFAULT ((1)) FOR [organization_id]
GO

