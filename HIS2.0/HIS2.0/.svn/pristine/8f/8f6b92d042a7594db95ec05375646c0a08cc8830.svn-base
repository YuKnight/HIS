--Add By Tany 2015-05-25 基本药物字典
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JC_JBYWZD]') AND type in (N'U'))
CREATE TABLE [dbo].[JC_JBYWZD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[pym] [varchar](50) NULL,
	[wbm] [varchar](50) NULL,
 CONSTRAINT [PK_JC_JBYWZD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/*
insert into JC_JBYWZD(name,pym,wbm) values('国家基本药物',dbo.GETPYWB('国家基本药物',0),dbo.GETPYWB('国家基本药物',1))
insert into JC_JBYWZD(name,pym,wbm) values('省级基本药物',dbo.GETPYWB('省级基本药物',0),dbo.GETPYWB('省级基本药物',1))
*/