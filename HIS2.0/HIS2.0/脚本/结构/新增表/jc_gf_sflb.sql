if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_sflb' and type = 'U')
	DROP table jc_gf_sflb
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_sflb]( 
	id   INT  IDENTITY(1, 1)  PRIMARY KEY,
	name [varchar](50) NULL,		--收费类别	
	sflb varchar(8) NULL,			--收费类别编码
	wbm varchar(50) NULL,			--五笔码
	pym varchar(50) NULL,			--拼音码
	szm varchar(50) NULL,			--数字码
	Opr_man [varchar](50) NULL,		--操作人
	Opr_time [datetime] NULL,		--操作时间
	memo [varchar](50) NULL,		--备注
	del_bit	int						--删除标志
) 

GO