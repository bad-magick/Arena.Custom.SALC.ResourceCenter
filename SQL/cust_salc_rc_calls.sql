USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_calls]    Script Date: 04/13/2012 12:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_rc_calls](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NULL,
	[name] [varchar](50) NULL,
	[phone] [varchar](20) NULL,
	[county] [varchar](50) NULL,
	[msg_for] [varchar](50) NULL,
	[hh] [int] NULL,
	[recieve] [int] NULL,
	[call_type] [int] NULL,
	[req_food] [int] NULL,
	[req_shelter] [int] NULL,
	[req_rent] [int] NULL,
	[req_utility] [int] NULL,
	[req_furn] [int] NULL,
	[req_other] [int] NULL,
	[notes] [text] NULL,
	[created_by] [varchar](50) NULL,
	[date_created] [datetime] NULL,
	[updated_by] [varchar](50) NULL,
	[date_updated] [datetime] NULL,
	[organization_id] [int] NOT NULL,
	[completed] [int] NOT NULL,
	[person_id] [int] NULL,
 CONSTRAINT [PK_cust_salc_rc_calls] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_salc_rc_calls] ADD  CONSTRAINT [DF_cust_salc_rc_calls_OrganizationId]  DEFAULT ((1)) FOR [organization_id]
GO

ALTER TABLE [dbo].[cust_salc_rc_calls] ADD  CONSTRAINT [DF_cust_salc_rc_calls_completed]  DEFAULT ((0)) FOR [completed]
GO

