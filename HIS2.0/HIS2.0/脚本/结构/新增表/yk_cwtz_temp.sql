IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[yk_cwtz_temp]') AND type in (N'U'))
CREATE TABLE [dbo].[yk_cwtz_temp](
	[id] [uniqueidentifier] NOT NULL,--id
	[djh] [bigint] NULL, --原单据号
	[djid] [uniqueidentifier] NULL,--原单据ID
	[djmxid] [uniqueidentifier] NULL,--原单据明细ID
	[wldw] [int] NULL, --往来单位
	[deptid] [int] NULL,--科室
	[RQ] [datetime] NULL,--日期
	[tzjg] [decimal](18, 3) NULL,--调整价格
	[tzsl] [decimal](18, 3) NULL,--调整数量
	[tzje] [decimal](18, 3) NULL,--调整金额
	[kcid] [uniqueidentifier] NULL,--kcid
	[yppch] [varchar](100) NULL, --批次号
	[cjid] [int] NULL,--厂家ID
	[SHH] [varchar](20) NULL, --货号
	[SHDH] [varchar](50) NULL,--送货单号
	[YPDW] [varchar](10) NULL,--药品单位
	[FPH] [varchar](30) NULL, --原发票
	[FPRQ] [char](10) NULL, --现发票日期
	[djy] [int] NULL,  --登记员
	[djrq] [datetime] NULL,--登记日期
	[shr] [int] NULL, --审核人
	[shrq] [datetime] NULL,--审核日期
	[cjr] [int] NULL,--帐务创建人
	[cjrq] [datetime] NULL,--创建日期
	[ywlx] [char](3) NULL,--业务类型
	[ypph] [varchar](30) NULL,--药品批号
	[jgbm] [bigint] NULL,--机构编码
	[xdjh] [bigint] NULL,--现单据号
	[xfph] [varchar](30) null,--现发票号
	[xdjid] [uniqueidentifier] NULL,现单据ID
 CONSTRAINT [PK_yk_cwtz_temp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


