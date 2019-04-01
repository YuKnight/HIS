if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_blmx' and type = 'U')
	DROP table jc_gf_blmx
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_blmx]( 
	id [uniqueidentifier] NOT NULL,
	ybbl_id [uniqueidentifier] NOT NULL,	--医保比例id
	xmly   INT,								--项目来源
	xmid INT,								--项目id
	Opr_man [varchar](50) NULL,				--操作人
	Opr_time [datetime] NULL,				--操作时间
	Del_man [varchar](50) NULL,				--删除人
	Del_time [datetime] NULL,				--删除时间
	del_bit	int								--删除标志
) 

GO