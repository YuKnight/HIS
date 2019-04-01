
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_KSSZB' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_KSSZB
GO
create PROCEDURE [dbo].[SP_YP_KSSZB]
	@rq1 datetime,
    @lx int --0重新生成 1 如果有就不再生成
AS

BEGIN

declare @sql varchar(8000)
--验证数据转移天数
declare @mz_ts int
declare @zy_ts int
set @mz_ts=(select cast(config as int) from jc_config where id=13)
set @zy_ts=(select cast(config as int) from jc_config where id=14)
--if exists(select * from yp_kss_rtj where rq=@rq1) or @lx=0
--begin
 delete from yp_kss_rtj where rq=@rq1
 delete from YP_KSS_RTJ_ZYYP where rq=@rq1
 delete from YP_KSS_RTJ_MZYP where rq=@rq1
 delete from YP_KSS_RTJ_CYBR where  out_date between @rq1+' 00:00:00' and  @rq1+ ' 23:59:59'
--end
---------------------------------------------门诊--------------------------------------------------
----提取数据--IF   EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TEMP_MZYPKSS]') AND type in (N'U'))
--	begin
--	DROP TABLE  TEMP_MZYPKSS
--end 
----if DATEADD(DD,-1*@mz_ts,getdate())>@rq1--	select ghxxid,xmid,sum(je) je into TEMP_MZYPKSS from vi_MZ_CFB a inner join vi_MZ_CFB_MX b on a.cfid=b.cfid --	where XMLY=1 and sfrq>=@RQ1+' 00:00:00' and sfrq<=@rq1+' 23:59:59' group by a.ghxxid,b.xmid--ELSE-- 	select ghxxid,xmid,sum(je) je into TEMP_MZYPKSS from VI_MZ_CFB a inner join VI_MZ_CFB_MX b on a.cfid=b.cfid --	where XMLY=1 and sfrq>=@RQ1+' 00:00:00' and sfrq<=@rq1+' 23:59:59' group by a.ghxxid,b.xmid------计算同期就诊总人次--declare @jzzrc decimal(15,2)--set @jzzrc=(select count(*) from (select count(ghxxid) ghxxid from MZYS_JZJL where jssj>=@rq1+' 00:00:00' and jssj<=@rq1+' 23:59:59' and bscbz=0 group by ghxxid) a ) --if @jzzrc is null set @jzzrc=0 ------计算同期就诊总金额--declare @zje decimal(15,2)--set @zje=(select sum(je) from TEMP_MZYPKSS)--if @zje is null set @zje=0 ------就诊用药总品种数之和--declare @rjljsumpzs decimal(15,2)--set @rjljsumpzs=(select count(*) from TEMP_MZYPKSS)--if @rjljsumpzs is null set @rjljsumpzs=0 ------使用抗菌药物人次 金额--declare @kjywrc decimal(15,2)--declare @kjywje decimal(15,2)--select @kjywrc=count(*),@kjywje=sum(je) from --			(select ghxxid,sum(je) je from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and kssdjid>0 group by ghxxid) a--if @kjywrc is null set  @kjywrc=0 --if @kjywje is null set @kjywje=0 ----使用抗菌药物总品种数--declare @rjljkjywpzs decimal(15,2)--set @rjljkjywpzs=(select count(*) from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and b.kssdjid>0) --if @rjljkjywpzs is null set @rjljkjywpzs=0 ------使用注射药物人次--declare @zsywrc decimal(15,2)--declare @zsywje decimal(15,2)--select @zsywrc=count(*),@zsywje=sum(je) from --			(select ghxxid,sum(je) je from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and tlfl in('02','03') group by ghxxid) a--if @zsywrc is null set @zsywrc=0 --if @zsywje is null set @zsywje=0 ------使用注射药物总品种数--declare @rjljzsywpzs decimal(15,2)--set @rjljzsywpzs=(select count(*) from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and tlfl in('02','03')) --if @rjljzsywpzs is null set @rjljzsywpzs=0 --------使用基本药物人次 金额--declare @jbywrc decimal(15,2)--declare @jbywje decimal(15,2)--select @jbywrc=count(*),@jbywje=sum(je) from --			(select ghxxid,sum(je) je from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and b.gjjbyw=1 group by ghxxid) a --if @jbywrc is null set @jbywrc=0 --if @jbywje is null set @jbywje=0 ------使用基本药物总品种数--declare @rjljjbywpzs decimal(15,2)--set @rjljjbywpzs=(select count(*) from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and b.gjjbyw=1)--if @rjljjbywpzs is null set @rjljjbywpzs=0--------使用西药药物人次 金额--declare @xyrc decimal(15,2)--declare @xyje decimal(15,2)--select @xyrc=count(*),@xyje=sum(je) from --(select ghxxid,sum(je) je from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and statitem_code='01' group by ghxxid) a--if @xyrc is null set @xyrc=0  --if @xyje is null set @xyje=0 ------使用成药药物人次 金额--declare @cyrc decimal(15,2)--declare @cyje decimal(15,2)--select @cyrc=count(*),@cyje=sum(je) from --(select ghxxid,sum(je) je from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and statitem_code='02' group by ghxxid) a--if @cyrc is null set @cyrc=0  --if @cyje is null set @cyje=0 ------使用中药药物人次 金额--declare @zyrc decimal(15,2)--declare @zyje decimal(15,2)--select @zyrc=count(*),@zyje=sum(je) from --(select ghxxid,sum(je) je from TEMP_MZYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid and statitem_code='03' group by ghxxid) a--if @zyrc is null set @zyrc=0  --if @zyje is null set @zyje=0 
--
--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_jzzrc',@jzzrc,'同期就诊总人次',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_zje',@zje,'同期就诊总金额',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_rjljypzs',@rjljsumpzs,'人均累计就诊用药总品种数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_kjywrc',@kjywrc,'使用抗菌药物人次',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_kjywje',@kjywje,'使用抗菌药物金额',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_rjljkjywpzs',@rjljkjywpzs,'人均累计使用抗菌药物品种数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_zsywrc',@zsywrc,'使用注射药物人次',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_zsywje',@zsywje,'使用注射药物金额',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_rjljzsywpzs',@rjljzsywpzs,'人均累计使用注射药物品种数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_jbywrc',@jbywrc,'使用基本药物人次',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_jbywje',@jbywje,'使用基本药物金额',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_rjljjbywpzs',@rjljjbywpzs,'人均累计使用基本药物品种数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_xyrc',@xyrc,'使用西药药物人次',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_xyje',@xyje,'使用西药药物金额',GETDATE())
--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_cyrc',@Cyrc,'使用成药药物人次',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_cyje',@Cyje,'使用成药药物金额',GETDATE())
--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_zyrc',@Zyrc,'使用中药药物人次',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'mz_zyje',@Zyje,'使用中药药物金额',GETDATE())
--
--
--
----屏蔽科室ID 201
---------------------------------------------住院--------------------------------------------------
--
----提取数据--IF   EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TEMP_ZYYPKSS]') AND type in (N'U'))
-- DROP TABLE TEMP_ZYYPKSS
----if DATEADD(DD,-1*@zy_ts,getdate())>@rq1--	select a.inpatient_id,b.xmid,sum(b.sdvalue) sdvalue,sum(round((num*bzsl)/unitrate,3)) xhsl,null kssdjid,null jbyw,null ddd into TEMP_ZYYPKSS from zy_inpatient a 
--	inner join vi_zy_fee_speci b on a.inpatient_id=b.inpatient_id 
--	inner join vi_yp_ypcd c on b.xmid=c.cjid 
--	where a.flag in (2,5,6) and CHARGE_BIT=1 and DELETE_BIT=0  and b.xmly=1  --	and OUT_DATE>=@rq1+' 00:00:00' and OUT_DATE<=@rq1+' 23:59:59' AND A.DEPT_ID<>201--   group by a.inpatient_id,b.xmid --else--	select a.inpatient_id,b.xmid,sum(b.sdvalue) sdvalue,sum(round((num*bzsl)/unitrate,3)) xhsl,null kssdjid,null jbyw,null ddd into TEMP_ZYYPKSS from zy_inpatient a 
--	inner join vi_zy_fee_speci b on a.inpatient_id=b.inpatient_id 
--	inner join vi_yp_ypcd c on b.xmid=c.cjid and b.xmly=1
--	where a.flag in (2,5,6) and CHARGE_BIT=1 and DELETE_BIT=0  and b.xmly=1  --	and OUT_DATE>=@rq1+' 00:00:00' and OUT_DATE<=@rq1+' 23:59:59' AND A.DEPT_ID<>201  group by a.inpatient_id,b.xmid ----update a set a.kssdjid=b.kssdjid,a.jbyw=b.gjjbyw,a.ddd=b.ddd from TEMP_ZYYPKSS  a,vi_yp_ypcd b where a.xmid=b.cjid------------ 出院患者用药总品种数--declare @zyhzyyrjljpzs decimal(15,2)--set @zyhzyyrjljpzs=(select count(*) from TEMP_ZYYPKSS)	--if @zyhzyyrjljpzs is null set @zyhzyyrjljpzs=0 ----出院患者药物总费用--declare @zyhzywzfy decimal(15,2)--set @zyhzywzfy=(select sum(sdvalue) from TEMP_ZYYPKSS) --if @zyhzywzfy is null set @zyhzywzfy=0 ----出院病人抗菌药物总品种数--declare @kjywzrjljpzs decimal(15,2)--set @kjywzrjljpzs=(select count(*) from TEMP_ZYYPKSS where kssdjid>0) --if @kjywzrjljpzs is null set @kjywzrjljpzs=0 ----出院病人抗菌药物总费用--declare @kjywzfy decimal(15,2)--set @kjywzfy=(select sum(sdvalue) from TEMP_ZYYPKSS where kssdjid>0) --if @kjywzfy is null set @kjywzfy=0 ----抗菌药物出院总人数--declare @kjywcyzrs decimal(15,2)--set @kjywcyzrs=(select count(*) from (select inpatient_id from TEMP_ZYYPKSS where kssdjid>0 group by inpatient_id) a)--if @kjywcyzrs is null set @kjywcyzrs=0 ----总出院人数--declare @tqzcyrs decimal(15,2)--set @tqzcyrs=(select  COUNT(*) from zy_inpatient where flag in(2,5,6) and out_date>=@rq1+' 00:00:00' and out_date<=@rq1+' 23:59:59'  AND DEPT_ID<>201 ) --if @tqzcyrs is null set @tqzcyrs=0-- ----住院患者使用基本药物品种数--declare @zyhzjbywrjljpzs decimal(15,2)--set @zyhzjbywrjljpzs=(select count(*) from  TEMP_ZYYPKSS where jbyw=1 ) --if @zyhzjbywrjljpzs is null set @zyhzjbywrjljpzs=0  ------住院患者使用基本药物金额--declare @zyhzjbywje decimal(15,2)--set @zyhzjbywje=(select sum(sdvalue) from TEMP_ZYYPKSS where jbyw=1 ) --if @zyhzjbywje is null set @zyhzjbywje=0 --------抗菌药物消耗量（累计DDD值）--declare @kjywljddd decimal(15,3)--set @kjywljddd=(--select sum(round(sl/ddd,3)) from (--select xmid,sum(a.xhsl*hlxs) sl from TEMP_ZYYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid group by xmid )a,--vi_yp_ypcd b where a.xmid=b.cjid and b.kssdjid>0 and b.ddd>0--) ------出院病人累计住院天数(同期收治患者人天数)--declare @tqszhzts decimal(15,2)--set @tqszhzts=(select  cast(round(avg(datediff(day,in_DATE,OUT_DATE)),2)as float)*COUNT(*) from-- zy_inpatient where flag in(2,5,6) and out_date>=@rq1+' 00:00:00' and out_date<=@rq1+' 23:59:59'  AND DEPT_ID<>201 ) --if @tqszhzts is null set @tqszhzts=0 ------特殊抗菌药物累计DDD值--declare @kjywtsljddd decimal(15,2)--set @kjywtsljddd=(--select sum(round(sl/ddd,3)) from (--select xmid,sum(a.xhsl*hlxs) sl from TEMP_ZYYPKSS a,vi_yp_ypcd b where a.xmid=b.cjid group by xmid )a,--vi_yp_ypcd b where a.xmid=b.cjid and b.kssdjid=3 and b.ddd>0--) -- --if @kjywtsljddd is null set @kjywtsljddd=0 ----抗菌药物患者病原学检查人数--declare @byxjcrs decimal(15,2)--if DATEADD(DD,-1*@zy_ts,getdate())>@rq1--	set @byxjcrs=(select count(*) from (select a.inpatient_id from TEMP_ZYYPKSS a,ZY_FEE_SPECI_H b where a.inpatient_id=b.inpatient_id and b.XMID=256 group by a.inpatient_id) a )--else--	set @byxjcrs=(select count(*) from (select a.inpatient_id from TEMP_ZYYPKSS a,ZY_FEE_SPECI b where a.inpatient_id=b.inpatient_id and b.XMID=256 group by a.inpatient_id) a )--if @byxjcrs is null set @byxjcrs=0 
--
--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'zyhzyyrjljpzs',@zyhzyyrjljpzs,'出院患者人均累计用药总品种数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'zyhzywzfy',@zyhzywzfy,'出院患者药物总费用',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'kjywrjljzpzs',@kjywzrjljpzs,'出院患者抗菌药物人均累计总品种数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'kjywzfy',@kjywzfy,'出院患者抗菌药物总费用',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'kjywcyzrs',@kjywcyzrs,'抗菌药物出院总人数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'tqzcyrs',@tqzcyrs,'总出院人数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'zyhzjbywrjljpzs',@zyhzjbywrjljpzs,'出院患者使用基本药物人均累计品种数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'zyhzjbywje',@zyhzjbywje,'出院患者使用基本药物金额',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'kjywljddd',@kjywljddd,'出院病人抗菌药物累计DDD值',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'tqszhzts',@tqszhzts,'同期收治患者人天数',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'kjywtsljddd',@kjywtsljddd,'特殊抗菌药物累计DDD值',GETDATE())--INSERT INTO YP_KSS_RTJ(RQ,ZBDM,ZBJG,ZBBZ,DJSJ)VALUES(@RQ1,'byxjcrs',@byxjcrs,'抗菌药物患者病原学检查人数',GETDATE())--
--

------------------------------------------------------------生成住院药品日数据----------------------
if DATEADD(DD,-1*@mz_ts,getdate())>@rq1
	insert into YP_KSS_RTJ_ZYYP(rq,inpatient_id,xmid,ksdm,ysdm,ypsl,ypdw,JE,djsj)
	select @rq1,c.inpatient_id,b.cjid,a.dept_id,zy_doc,
	sum(round((num*bzsl)/unitrate,3)) ykdwsl,dbo.fun_yp_ypdw(bzdw),SUM(SDVALUE),GETDATE()
	from vi_zy_fee_speci a inner join 
	vi_yp_ypcd b on a.xmid=b.cjid  inner join zy_inpatient c on a.inpatient_id=c.inpatient_id
	where c.flag in (2,5,6) and OUT_DATE>=@rq1+' 00:00:00' and OUT_DATE<=@rq1+' 23:59:59'
	 and CHARGE_BIT=1 and a.DELETE_BIT=0 and a.xmly=1 
	group by c.inpatient_id,b.cjid,a.dept_id,zy_doc,BZDW
ELSE
	insert into YP_KSS_RTJ_ZYYP(rq,inpatient_id,xmid,ksdm,ysdm,ypsl,ypdw,JE,djsj)
	select @rq1,c.inpatient_id,b.cjid,a.dept_id,zy_doc,
	sum(round((num*bzsl)/unitrate,3)) ykdwsl,dbo.fun_yp_ypdw(bzdw),SUM(SDVALUE),GETDATE()
	from vi_zy_fee_speci a inner join 
	vi_yp_ypcd b on a.xmid=b.cjid inner join zy_inpatient c on a.inpatient_id=c.inpatient_id
	where c.flag in (2,5,6) and OUT_DATE>=@rq1+' 00:00:00' and OUT_DATE<=@rq1+' 23:59:59'
	and CHARGE_BIT=1 and a.DELETE_BIT=0 and a.xmly=1 
	group by c.inpatient_id,b.cjid,a.dept_id,zy_doc,BZDW


------------------------------------------------------------生成门诊药品日数据----------------------
if DATEADD(DD,-1*@mz_ts,getdate())>@rq1
	insert into YP_KSS_RTJ_MZYP(rq,ghxxid,xmid,ksdm,ysdm,ypsl,ypdw,JE,djsj)
	select @rq1,a.ghxxid,b.XMID,KSDM,YSDM,
	sum(round((sl*bzsl)/ydwbl,3)) ykdwsl,dbo.fun_yp_ypdw(bzdw),SUM(JE),GETDATE()
	from  vi_MZ_CFB a inner join vi_MZ_CFB_MX B ON A.CFID=B.CFID INNER JOIN
	vi_yp_ypcd C on B.xmid=C.cjid where SFRQ between @rq1+' 00:00:00' and  @rq1+ ' 23:59:59' 
	and xmly=1 AND a.BSCBZ=0  
	group by a.ghxxid,b.XMID,KSDM,YSDM,BZDW
ELSE
	insert into YP_KSS_RTJ_MZYP(rq,ghxxid,xmid,ksdm,ysdm,ypsl,ypdw,JE,djsj)
	select @rq1,a.ghxxid,b.XMID,KSDM,YSDM,
	sum(round((sl*bzsl)/ydwbl,3)) ykdwsl,dbo.fun_yp_ypdw(bzdw),SUM(JE),GETDATE()
	from vi_MZ_CFB a inner join vi_MZ_CFB_MX B ON A.CFID=B.CFID INNER JOIN
	vi_yp_ypcd C on B.xmid=C.cjid where SFRQ between @rq1+' 00:00:00' and  @rq1+ ' 23:59:59' 
	and xmly=1 AND a.BSCBZ=0  
	group by a.ghxxid,b.XMID,KSDM,YSDM,BZDW
END


------------------------------------------------------------生成出院明细数据----------------------
insert into YP_KSS_RTJ_CYBR(inpatient_id,zy_doc,clinic_doc,dept_id,in_date,out_date)
select inpatient_id,zy_doc,clinic_doc,dept_id,in_date,out_date from zy_inpatient
where out_date between @rq1+' 00:00:00' and  @rq1+ ' 23:59:59'  and flag in(2,5,6)

--select * from YP_KSS_RTJ_CYBR

--生成汇总数据
--declare @rq1 datetime
--declare @rq2 datetime
--declare @ndate datetime
--set @rq1='2011-07-01 00:00:00'
--set @rq2='2011-07-15 00:00:00'
--set @ndate = @rq1--while @ndate <= @rq2--begin--    EXec SP_YP_KSSZB @ndate,0--	set @ndate = DBO.Fun_GetDate(dateadd(day,1,@ndate))--    PRINT @NDATE--end