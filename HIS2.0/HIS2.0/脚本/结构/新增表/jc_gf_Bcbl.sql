if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_Bcbl' and type = 'U')
	DROP table jc_gf_Bcbl
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_Bcbl]( 
	id [uniqueidentifier] NOT NULL,
	gfid [uniqueidentifier] NOT NULL,	--公费id
	bcbl decimal(15,4),				--公费补充比例
	xj	decimal(15,4),				--限价
	Opr_man [varchar](50) NULL,		--操作人
	Opr_time [datetime] NULL,		--操作时间
	Mod_man [varchar](50) NULL,		--编辑人
	Mod_time [datetime] NULL,		--编辑时间
	memo [varchar](50) NULL,		--备注
	del_bit	int						--删除标志
) 

GO