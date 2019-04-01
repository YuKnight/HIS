if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_patrec_Change' and type = 'U')
	DROP table jc_gf_patrec_Change
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_patrec_Change](
	id   varchar(50)  PRIMARY KEY,		--区域代码+医疗证号
	ylzh	varchar(50) not null,		--医疗证号
	name [varchar](50) NULL,			--姓名
	pym  [varchar](50) NULL,			
	wbm  [varchar](50) NULL,
	gflx	int not null,				--公费类型（医保类型）
	gfzlx	[varchar](10) not null,		--公费子类型（医保子类型）
	qy		varchar(10),				--医保接口类型的insurecentral
	brlx	varchar(10),				--医保接口类型的ybjklx
	del_bit		char(1) default '0',	--关闭收费
	cfsl_xz		int,					--处方数量限制
	cfslM_xz	int,					--每月处方数量限制
	je_xz		decimal(15,4),			--金额限制
	jcje_xz		decimal(15,4),			--检查金额限制
	zlje_xz		decimal(15,4),			--治疗金额限制
	GRJB	smallint,					--工人级别
	RZQK	smallint,					--任职情况
	ZFBL	decimal(15,4),				--自费比例
	RDWBH	varchar(10),				--单位编号（市公费：医疗证号前3位）
	DWBH	varchar(10),				--单位编号（市公费：医疗证号RDWBH的后2位）
	RRYLB	varchar(10),				--人员类别（市公费：医疗证号第6位）
	RGRBH	varchar(10),				--个人编号（市公费：医疗证号后4伟）
	SFZH	varchar(30) not null,		--身份证号
	xb		varchar(10) not null,		--性别
	memo  [varchar](200) NULL,		
	
	csrq	datetime,					--出生日期
	GZSJ	datetime,					--工作时间
	DDYY1	varchar(200),				--定点医院1
	DDYY2	varchar(200),				--定点医院2
	DDYY3	varchar(200),				--定点医院3
	bzsj	datetime,					--办证时间
	xzsj	datetime,					--销证时间
	DM		varchar(10) ,				--代码（武汉8医院写死为“2”）
	ydsj	datetime,					--异动时间
	ydlb	smallint,					--异动类别
	lxdh	varchar(20) ,				--联系电话
	drsj	datetime,					--导入时间（查询用）
	cxsj	varchar(20),					--导入时间（查询用）
	dr_bit	smallint,					--导入状态(0:insert 1:update 2:none)
	memo_1  [varchar](200) NULL,	
	memo_2  [varchar](200) NULL,	
	memo_3  [varchar](200) NULL,	
	memo_4  [varchar](200) NULL,	
	memo_5  [varchar](200) NULL,			
	opr_date  datetime NULL,			
	opr_man  [varchar](50) NULL,			
	Mod_date  datetime NULL,			
	Mod_man  [varchar](50) NULL
) 

GO