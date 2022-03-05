USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_rc_clients]    Script Date: 04/13/2012 12:55:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_rc_clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_created] [date] NOT NULL,
	[date_updated] [date] NOT NULL,
	[created_by] [varchar](50) NOT NULL,
	[updated_by] [varchar](50) NOT NULL,
	[num_adults] [int] NULL,
	[num_children] [int] NULL,
	[county_of_origin] [varchar](50) NOT NULL,
	[help_requested] [int] NOT NULL,
	[notes] [text] NULL,
	[nick_name] [varchar](50) NULL,
	[first_name] [varchar](50) NOT NULL,
	[middle_name] [varchar](50) NULL,
	[last_name] [varchar](50) NOT NULL,
	[suffix] [varchar](10) NULL,
	[birthday] [date] NULL,
	[gender] [varchar](1) NULL,
	[email] [varchar](50) NULL,
	[street_address] [varchar](100) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](2) NULL,
	[postal_code] [varchar](10) NULL,
	[ssn] [varchar](11) NULL,
	[school_district] [varchar](50) NULL,
	[income_employment] [decimal](18, 0) NULL,
	[income_unemployment] [decimal](18, 0) NULL,
	[income_mfip] [decimal](18, 0) NULL,
	[income_ma] [decimal](18, 0) NULL,
	[income_childsupport] [decimal](18, 0) NULL,
	[income_ssissdi] [decimal](18, 0) NULL,
	[income_other] [decimal](18, 0) NULL,
	[cash_on_hand] [decimal](18, 0) NULL,
	[issues] [int] NULL,
	[last_date_worked] [date] NULL,
	[mstatus] [int] NULL,
	[dlicense] [int] NULL,
	[ebt] [int] NULL,
	[food_support] [decimal](18, 0) NULL,
	[applied_assistance] [date] NULL,
	[food_shelf] [varchar](50) NULL,
	[food_shelf_visit] [date] NULL,
	[casemgr_1_name] [varchar](50) NULL,
	[casemgr_1_agency] [varchar](50) NULL,
	[casemgr_1_phone] [varchar](20) NULL,
	[casemgr_1_notes] [varchar](50) NULL,
	[casemgr_2_name] [varchar](50) NULL,
	[casemgr_2_agency] [varchar](50) NULL,
	[casemgr_2_phone] [varchar](20) NULL,
	[casemgr_2_notes] [varchar](50) NULL,
	[emgassist_1_agency] [varchar](50) NULL,
	[emgassist_1_casemgr] [varchar](50) NULL,
	[emgassist_1_phone] [varchar](20) NULL,
	[emgassist_1_date] [date] NULL,
	[emgassist_1_amount] [decimal](18, 0) NULL,
	[emgassist_1_status] [int] NULL,
	[emgassist_2_agency] [varchar](50) NULL,
	[emgassist_2_casemgr] [varchar](50) NULL,
	[emgassist_2_phone] [varchar](20) NULL,
	[emgassist_2_date] [date] NULL,
	[emgassist_2_amount] [decimal](18, 0) NULL,
	[emgassist_2_status] [int] NULL,
	[past_shelter] [int] NULL,
	[past_shelter_date] [date] NULL,
	[past_unsheltered] [int] NULL,
	[past_unsheltered_date] [date] NULL,
	[past_chemical] [int] NULL,
	[past_chemical_date] [date] NULL,
	[past_transitional] [int] NULL,
	[past_transitional_date] [date] NULL,
	[past_doubled] [int] NULL,
	[past_doubled_date] [date] NULL,
	[past_eviction] [int] NULL,
	[past_eviction_date] [date] NULL,
	[past_foreclosure] [int] NULL,
	[past_foreclosure_date] [date] NULL,
	[phone_home] [varchar](20) NULL,
	[phone_work] [varchar](20) NULL,
	[phone_mobile] [varchar](20) NULL,
	[phone_other] [varchar](20) NULL,
	[employment_frequency] [int] NULL,
	[employment_date] [date] NULL,
	[mfip_day] [int] NULL,
	[childsupport_date] [date] NULL,
	[othersources_date] [date] NULL,
	[message] [varchar](50) NULL,
	[flag] [int] NULL,
	[organization_id] [int] NOT NULL,
 CONSTRAINT [PK_cust_salc_rcclient] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_salc_rc_clients] ADD  CONSTRAINT [DF_cust_salc_rcclient_OrganizationId]  DEFAULT ((1)) FOR [organization_id]
GO

