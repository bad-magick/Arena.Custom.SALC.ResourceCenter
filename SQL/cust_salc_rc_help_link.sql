USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_help_link]    Script Date: 04/13/2012 12:56:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cust_salc_rc_help_link](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[person_id] [int] NOT NULL,
	[help_id] [int] NOT NULL,
	[OrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_cust_salc_rcclient_help_link] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[cust_salc_rc_help_link] ADD  CONSTRAINT [DF_cust_salc_rcclient_help_link_OrganizationId]  DEFAULT ((1)) FOR [OrganizationId]
GO

