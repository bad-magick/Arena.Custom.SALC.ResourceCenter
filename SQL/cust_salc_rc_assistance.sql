USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_assistance]    Script Date: 04/13/2012 12:54:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_rc_assistance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[text] [varchar](50) NULL,
	[quantity] [int] NULL,
	[amount] [int] NULL,
	[enabled] [int] NULL,
	[organization_id] [int] NOT NULL,
 CONSTRAINT [PK_cust_salc_rc_assistance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_salc_rc_assistance] ADD  CONSTRAINT [DF_cust_salc_rc_assistance_oganization_id]  DEFAULT ((1)) FOR [organization_id]
GO

