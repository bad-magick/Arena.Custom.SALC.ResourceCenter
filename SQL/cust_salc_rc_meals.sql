USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_meals]    Script Date: 04/13/2012 12:56:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_rc_meals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[served] [int] NULL,
	[meals] [int] NULL,
	[dist] [int] NULL,
	[pounds] [int] NULL,
	[date_created] [date] NULL,
	[created_by] [varchar](50) NULL,
	[date_updated] [date] NULL,
	[updated_by] [varchar](50) NULL,
	[organization_id] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_salc_rc_meals] ADD  CONSTRAINT [DF_cust_salc_rcclient_meal_OrganizationId]  DEFAULT ((1)) FOR [organization_id]
GO

