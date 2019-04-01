if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_bl' and type = 'U')
	DROP table jc_gf_bl
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_bl]( 
	id [uniqueidentifier] NOT NULL,
	YBLXID int not NULL,			--医保类型
	ybzlx [varchar](10) NULL,		--医保子类型
	sflb varchar(8) NULL,			--收费类别
	gfbl decimal(15,4),				--公费比例
	bcbl decimal(15,4),				--公费补充比例
	xj	decimal(15,4),				--限价
	Opr_man [varchar](50) NULL,		--操作人
	Opr_time [datetime] NULL,		--操作时间
	Mod_man [varchar](50) NULL,		--编辑人
	Mod_time [datetime] NULL,		--编辑时间
	memo [varchar](50) NULL,		--备注
	memo1 [varchar](50) NULL,
	memo2 [varchar](50) NULL,
	memo3 [varchar](50) NULL,
	memo4 [varchar](50) NULL,
	del_bit	int						--删除标志
) 

GO