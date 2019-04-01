IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TLDMX_FEE' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TLDMX_FEE
GO
CREATE PROCEDURE SP_YF_TLDMX_FEE 
 ( 
   @ID  uniqueidentifier,
   @FYID uniqueidentifier ,
   @CJID int,
   @YPHH	varchar(20) ,		--货号
   @YPPM	varchar(100),		--品名5
   
   @YPYWM	varchar(100),		--英文名
   @YPSPM	varchar(100),		--商品名
   @YPGG	varchar(50),		--规格
   @YPCJ	varchar(100),		--生产厂家
   @YPDW	varchar(10),		--单位10
   
   @YDWBL	int,				--单位比例
   @YPSL	decimal(15,3),		--药品数量
   @CFTS	int,				--剂数
   @KCID	uniqueidentifier,   --KCID
   @YPPCH	varchar(100),		--批次号15
   
   @YPPH	varchar(50) ,		--批号
   @YPXQ    varchar(10),		--效期
   @JHJ		decimal(18,4),		--进货价
   @PFJ		decimal(15,4),		--批发价
   @LSJ		decimal(15,4),		--零售价20
   
   @JHJE	decimal(18,3),		--进货金额
   @PFJE    decimal(15,3),		--批发金额
   @LSJE	decimal(15,3),		--零售金额
   @ZYMXID   uniqueidentifier,  --费用明细id
   @TZYMXID  uniqueidentifier,  --退费用明细id25
   
   @ZYJLID	uniqueidentifier,   --住院记录id
   @HZXM	varchar(50),		--患者姓名
   @BLH		varchar(50),		--病理号（住院号or门诊号）
   @ZYYEID   int,			    --婴儿id
   @YZNR	varchar(200),		--医嘱内容30
   
   @CFRQ	datetime,			--处方日期
   @BRKS	int,				--病人科室
   @KDKS	int ,				--开单科室
   @KDYS    int,			    --开单医生
   @GCYS   int ,				--管床医生35
   
   @ZXKS	int ,				--执行科室
   @SFRQ   datetime,			--收费日期
   @SFY		int,				--收费员
   @YF		varchar(50),		--用法
   @ZT     varchar(100),		--嘱托40
   
   @PC		varchar(50),		--频次
   @JL		varchar(50),		--剂量
   @JLDW   varchar(50),			--剂量单位
   @ZBZ		int,				--组标志
   @PXXH	int,				--排序序号45
   
   @DJY		int,				--登记员
   @DJSJ   datetime,			--登记时间
   @XGR    int,					--修改员
   @XGSJ   datetime,			--修改时间
   @JGBM   bigint,				--机构编码50
   
   @ERR_CODE	int output ,
   @ERR_TEXT   varchar(100) output
 )
as
BEGIN
	set @err_code=-1
	if @ID=dbo.FUN_GETEMPTYGUID()
	begin
		set @ID=dbo.FUN_GETGUID(newid(),getdate())
		insert into YF_TLDMX_FEE(
									id,fyid,cjid,yphh,yppm,
									ypywm,ypspm,ypgg,ypcj,ypdw,
									ydwbl,ypsl,cfts,kcid,yppch,
									ypph,ypxq,jhj,pfj,lsj,
									jhje,pfje,lsje,zymxid,tzymxid,
									zyjlid,hzxm,blh,zyyeid,yznr,
									cfrq,brks,kdks,kdys,gcys,
									zxks,sfrq,sfy,yf,zt,
									pc,jl,jldw,zbz,pxxh,
									djy,djsj,xgr,xgsj,jgbm 
								) 
					    values (
								@ID,@FYID,@CJID,@YPHH,@YPPM,
								@YPYWM,@YPSPM,@YPGG,@YPCJ,@YPDW,
								@YDWBL,@YPSL,@CFTS,@KCID,@YPPCH,
								@YPPH,@YPXQ,@JHJ,@PFJ,@LSJ,
								@JHJE,@PFJE,@LSJE,@ZYMXID,@TZYMXID,
								@ZYJLID,@HZXM,@BLH,@ZYYEID,@YZNR,
								@CFRQ,@BRKS,@KDKS,@KDYS,@GCYS,
								@ZXKS,@SFRQ,@SFY,@YF,@ZT,
								@PC,@JL,@JLDW,@ZBZ,@PXXH,
								@DJY,@DJSJ,@XGR,@XGSJ,@JGBM 
								)
		if @@ROWCOUNT = 0
			 begin
				set @ERR_CODE=-1
				set @ERR_TEXT='插入统领单明细费用失败'
				return
			 end
		 set @ERR_CODE=0
		 set @ERR_TEXT='保存成功'
	end
END