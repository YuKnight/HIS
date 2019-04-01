if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_sflbmx' and type = 'U')
	DROP table jc_gf_sflbmx
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_sflbmx]( 
	id   INT  IDENTITY(1, 1)  PRIMARY KEY,
	sflb varchar(8) NULL,			--收费类别编码
	xmly   INT,						--项目来源
	xmid INT,						--项目id
	Opr_man [varchar](50) NULL,		--操作人
	Opr_time [datetime] NULL,		--操作时间
	del_bit	int						--删除标志
) 

GO