if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_WrkUnit' and type = 'U')
	DROP table jc_gf_WrkUnit
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_WrkUnit](
	id   INT  IDENTITY(1, 1)  PRIMARY KEY,
	name [varchar](50) NULL,
	pym  [varchar](50) NULL,
	wbm  [varchar](50) NULL,
	Wrk_Unit  smallint default 0,		--单位区域    
	fzr		[varchar](50) NULL,			--负责人
	bank		[varchar](50) NULL,		--开户银行
	pay_id		[varchar](50) NULL,		--付款账户
	tel_no	[varchar](50) NULL,			--联系电话
	wrk_addr [varchar](50) NULL,		--地址
	del_bit		char(1) default '0',	--关闭收费
	cfsl_xz		int,					--处方数量限制
	cfslM_xz	int,					--每月处方数量限制
	je_xz		decimal(15,4),			--金额限制
	jcje_xz		decimal(15,4),			--检查金额限制
	zlje_xz		decimal(15,4),			--治疗金额限制
	memo  [varchar](50) NULL,			
	opr_date  datetime NULL,			
	opr_man  [varchar](50) NULL,			
	Mod_date  datetime NULL,			
	Mod_man  [varchar](50) NULL
) 

GO