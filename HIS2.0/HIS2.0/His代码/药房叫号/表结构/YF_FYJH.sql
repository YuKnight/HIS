USE [trasen]
GO

/****** Object:  Table [dbo].[YF_FYJH]    Script Date: 12/19/2011 13:56:58 ******/
if not exists (select 1 from  sysobjects where id = object_id('YF_FYJH') and type = 'U') 
DROP TABLE [dbo].[YF_FYJH]
GO

USE [trasen]
GO

/****** Object:  Table [dbo].[YF_FYJH]    Script Date: 12/19/2011 13:56:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[YF_FYJH](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FPID] [uniqueidentifier] NOT NULL,
	[FPH] [varchar](30) NULL,
	[ZJE] [decimal](18, 2) NULL,
	[BRXM] [varchar](30) NULL,
	[DNLSH] [bigint] NULL,
	[BRXXID] [uniqueidentifier] NULL,
	[XSBZ] [int] NULL,
	[TIME] [varchar](50) NULL,
	[PDXH] [varchar](16) NULL,
	[BLH] [varchar](50) NULL,
	[LYCK] [varchar](50) NULL,
	[DEPT] [int] NULL,
	[DEPTNAME] [varchar](50) NULL,
 CONSTRAINT [PK_YF_FYJH] PRIMARY KEY CLUSTERED 
(
	[FPID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


