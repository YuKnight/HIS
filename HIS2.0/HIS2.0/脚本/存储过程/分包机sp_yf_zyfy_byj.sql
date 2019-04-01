IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_zyfy_byj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_zyfy_byj
GO
  
create PROCEDURE [dbo].[sp_yf_zyfy_byj]    
 (    
 @fyid uniqueidentifier,     
 @V_groupid uniqueidentifier    
 )     
as    
set nocount on
--统领发药时调用    
begin    
 DECLARE @tablename varchar(32)    
 DECLARE @stmt varchar(3000) --定义SQL文本    
 declare @v_DoseList varchar(100)--执行时间：用药数量    
 declare @v_execTime varchar(100)--执行时间    
 declare @v_yysl varchar(100)--用药数量    
     
    
 --声明临时表    
     
 create table #tmp_zyfy_BYJ    
 (    
    id  bigint,-- 是 唯一      
  HsptCd    varchar(100),--  医院代码 √     
  DptmtCd    varchar(100),--  部门代码 √     
  WardCd    varchar(100),-- 是 病区代码 √     
  DataClsf varchar(100),-- 是 医嘱文件分类 √ 这里写N    
  InOutClsf varchar(100),-- 是 门诊/住院病人分类 √ 这里写 I     
  OrderDt  varchar(100),-- 是 发送数据的日期 √ format : YYYYMMDD    
  OrderDtm varchar(100),-- 是 发送数据的精确时间 √ format: YYYYMMDDHHMMSS    
  OrderNum uniqueidentifier,-- 是 医嘱编号，唯一 √     
  RoomNum  varchar(100),-- 是 病人床号 √     
  PtntNm  varchar(100),-- 是 病人姓名 √     
  PtntNum  varchar(100),-- 是 病人ID号，唯一 √ -----uniqueidentifier 住院号    
  Sex   varchar(100),-- 是 性别 √ 男，女    
  DoctorNm varchar(100),-- 是 医生姓名 √     
  Birthday varchar(100),--  出生年月 20110304 √ format : YYYYMMDD    
  PtntAddr varchar(100),--  家庭住址 √     
  PtntTel  varchar(100),--  电话 √     
  MedCd  varchar(100),-- 是 药品编码，唯一 √     
  MedNm  varchar(100),-- 是 药品名称 √     
  MedNote  varchar(500),--  药品注意事项 √ 餐前，餐后    
  MedSpec  varchar(100),-- 是 药品规范 √     
  MedUnit  varchar(100),-- 是 药品剂量单位(片，粒 ...) √     
  UseAtcYn varchar(100),-- 是 是否使用包药机  √ 这里都写 Y    
  DoseList varchar(100),-- 是 列出用药次数和数量 √ format: tid 2可写为：0800:2;1200:2;1600:2    
  TakeDays varchar(100),-- 是 用药周期 √ 这里都写1     
  TakeDt  varchar(100),-- 是 病人用药日期  √ format: YYYYMMDD    
  XmlFlag  varchar(100),-- 是 状态标识 √ 这里都写 N    
  drtscd  varchar(100),    
  --isby  int,  --是否包药  His    
  inpatientID uniqueidentifier, --His的inpatient_id    
  groupID  uniqueidentifier,  --发药的GroupID    
  fybid uniqueidentifier,    
  DWLX  int,  --单位类型为1是含量单位    
  NUM   decimal(10,3),  --开药数量    
  HLXS  decimal(10,3),  --含量系数    
  order_id     uniqueidentifier, --医嘱ID    
  FIRST_TIMES varchar(10),--首次执行    
  end_TIMES   varchar(10), --末次执行    
  CF_Date     datetime,--处方日期    
  KS_Date     datetime,--医嘱开始日期    
  TZ_Date     datetime,--停嘱时间    
  fee_num decimal(15,2),--费用记帐的总量    
  fee_unit varchar(30),    
  fee_unitrate int,    
  fymxid uniqueidentifier,    
  MNGTYPE int, --医嘱类型    
  ykdw varchar(30),--药库单位    
  bzsl int,    
  bzdw varchar(30),    
  yfid varchar(50)    
   )     
      
 insert into #tmp_zyfy_BYJ(id,HsptCd,DptmtCd,WardCd,DataClsf,InOutClsf,OrderDt,OrderDtm,    
         OrderNum,RoomNum,PtntNm,PtntNum,Sex,DoctorNm,Birthday,PtntAddr,    
         PtntTel,MedCd,MedNm,MedNote,MedSpec,MedUnit,UseAtcYn,DoseList,    
         TakeDays,TakeDt,XmlFlag,inpatientID,groupID,fybid    
         ,DWLX,NUM,HLXS,order_id,FIRST_TIMES,end_TIMES,CF_Date,KS_Date,TZ_Date,    
         fee_num,fee_unit,fee_unitrate,fymxid,MNGTYPE,ykdw,yfid,bzsl,bzdw)    
 --select d.FYID ID,'001' as HsptCd,d.dept_ly as Dptmtcd,B.WARD_ID as WardCd, 'N' as DataClsf, 'I' as InOutClsf,  
 --Modify By Tany 2015-03-19 病区取病人信息表的病区，跟着病人走
  select d.FYID ID,'001' as HsptCd,d.dept_ly as Dptmtcd,a.WARD_ID as WardCd, 'N' as DataClsf, 'I' as InOutClsf,   
    replace(convert(char(10),fy_date,120),'-','') as OrderDt,    
    --replace(convert(char(10),b.order_bdate,120),'-','') as OrderDt,    
    cast(left(replace(replace(replace(replace(convert(char(19),d.fy_date,120),'-',''),'.',''),' ',''),':',''),14) as varchar(14)) as OrderDtm,    
    b.order_id as OrderNum,    
    (select cast(bed_no as varchar(10)) from dbo.ZY_BEDDICTION where bed_id=a.bed_id) as RoomNum,    
    a.name as PtntNm,a.INPATIENT_NO as PtntNum,--a.patient_id    
    case a.sexcode when 1 then '男'when 2 then '女'when 9 then '未知'else ''end as sex,    
    dbo.fun_getEmpName(b.order_doc) as DoctorNm,    
    replace(convert(char(10),a.birthday,120),'-','') as Birthday,    
    a.home_street as PtntAddr,    
    '' as PtntTel,--a.home_tel    
    e.cjid as MedCd,---    
    b.order_context as MedNm,    
    b.frequency as MedNote,     
    b.order_spec as MedSpec,    
    (case when b.dwlx <>1 then b.unit else dbo.fun_yp_ypdw(e.bzdw) end ) MedUnit,   
    'Y' as UseAtcYn,'' as DoseList,    
    --1 as TakeDays,    
    0 as takedays,    
    replace(CONVERT(char(10),(case when CHARINDEX(d.BZ,'老系统记账')>0 then d.fy_date else d.presc_date end),120),'-','')  as TakeDt,--Modify By Tany 2015-02-08 按处方日期给包药机 --book_date费用产生时间    
    'N' as XmlFlag,---d.book_date, 0 AS isby,
    a.inpatient_ID AS inpatientID,@V_groupid AS groupID,@fyid,
    b.dwlx,b.num,e.hlxs,
    b.ORDER_ID,b.FIRST_TIMES,b.TERMINAL_TIMES,d.PRESC_DATE,b.ORDER_BDATE,b.ORDER_EDATE,d.NUM,d.UNIT,d.UNITRATE,d.ID,MNGTYPE,    
    s_ypdw,d.EXECDEPT_ID,BZSL,dbo.fun_yp_ypdw(bzdw)	
    from dbo.VI_ZY_VINPATIENT_ALL a inner join     --Modify By Tany 2015-03-19 改成_all的
    dbo.zy_orderrecord b on a.inpatient_id=b.inpatient_id and a.BABY_ID=b.BABY_ID    
    inner join dbo.JC_FREQUENCY c on b.frequency=c.name     
    inner join dbo.zy_fee_speci d on b.order_id=d.order_id     
    inner join dbo.vi_yp_ypcd e on d.XMLY=1 and d.XMID=e.cjid     
    where e.cjid in (select cjid from dbo.yp_ypcjd ) --where s_ypjx in('口含片','胶丸','分散片','控释片','片剂','胶囊','软胶囊')    
     and d.delete_bit=0    
    and d.fy_bit=1 and d.group_id=@V_groupid    
    --and cast(convert(varchar(10),PRESC_DATE,120)as datetime) >=cast(convert(varchar(10),getdate(),120)as datetime)----    
    and b.MNGTYPE in(0,1) and d.NUM>0 order by b.serial_no --and ORDER_USAGE like 'po' ----长期医嘱    
        
    
declare  @DptmtCd    varchar(100)--  部门代码 √  Modify by jchl，判断科室是否上his，处理首末次
declare @T1_ID bigint--发药ID    
declare @T1_MedCd varchar(100)--药品编码    
declare @T1_MedNote varchar(500)--MedNote药品用法    
declare @T1_DWLX int    
declare @T1_NUM decimal(10,3)--剂量    
declare @T1_HLXS decimal(10,3)--含量系数    
declare @T1_fristCX varchar(10)--首次    
declare @T1_endCX   varchar(10)--末次    
declare @T1_CFDate datetime--处方日期    
declare @T1_KSDate datetime--开嘱日期    
declare @T1_TZDate datetime--停嘱日期    
declare @t1_fee_num decimal(15,2)    
declare @t1_fee_unit varchar(30)    
declare @t1_fee_unitrate int    
declare @t1_mednm varchar(200)    
declare @str_CFDate varchar(10)---    
declare @str_KSDate varchar(10)    
declare @str_TZDate varchar(10)    
declare @execnum decimal(15,2) --医嘱执行次数    
declare @jl decimal(15,2) --老系统中的剂量     
declare @jldw varchar(30)--老系统中的剂量单位     
declare @dh varchar(50) --老系统的DH    
declare @drtscd2 varchar(100)    
declare @orderid varchar(100)    
declare @jgts int    
declare @t1_fymxid uniqueidentifier    
declare @t1_mngtype int    
declare @t1_ykdw varchar(30)    
declare @t1_bzsl int    
declare @t1_bzdw varchar(30)    
declare @t1_orderid uniqueidentifier --Add By Tany 2015-02-05
 
declare T1 cursor for select ID,MedCd,MedNote,DWLX,NUM,HLXS,    
FIRST_TIMES,end_TIMES,CF_Date,KS_Date,TZ_Date,fee_num,fee_unit,fee_unitrate,fymxid,mngtype,ykdw,bzsl,bzdw,mednm,DptmtCd,OrderNum  
from #tmp_zyfy_BYJ where   groupID=@V_groupid    
open T1    
fetch next from T1 into @T1_ID,@T1_MedCd,@T1_MedNote,@T1_DWLX,@T1_NUM,@T1_HLXS,@T1_fristCX,@T1_endCX,@T1_CFDate,@T1_KSDate,@T1_TZDate,@t1_fee_num,@t1_fee_unit,@t1_fee_unitrate,@t1_fymxid,@t1_mngtype,@t1_ykdw,@t1_bzsl,@t1_bzdw,@t1_mednm,@DptmtCd,@t1_orderid  
while @@fetch_status = 0    
begin       
   set @str_CFDate=CONVERT(varchar(10),@T1_CFDate,23)    
   set @str_KSDate=CONVERT(varchar(10),@T1_KSDate,23)    
   set @str_TZDate=CONVERT(varchar(10),@T1_TZDate,23)    
   set @v_DoseList='';    
   select @v_execTime=replace(exectime,':',''),@execnum=execnum from dbo.JC_FREQUENCY where name=@T1_MedNote;    
   --------如果exectime 为空 如：中餐时      
     
   --Modify by jchl       
   if(@v_execTime='')    
    set @v_execTime=@T1_MedNote    
   --------    
   else   
    --Modify By Tany 2015-02-04 上了新HIS的科室，需要更新首末次
    if (exists (select 1 from dbo.vi_zy_newhishsz where deptid=@DptmtCd)) 
    begin    
     if(@T1_fristCX>0 and @str_CFDate=@str_KSDate)--首次执行医嘱  
      begin    
       select @v_execTime=dbo.FUN_getYL_SC_MC(@v_execTime,1,@T1_fristCX)    
      end    
     else if(@T1_endCX>0 and @str_CFDate=@str_TZDate)--末次执行医嘱  
      begin    
       select @v_execTime=dbo.FUN_getYL_SC_MC(@v_execTime,1,@T1_endCX)    
      end    
          
    end    
        
   --select top 1 @jl=jl,@jldw=jldw,@jgts=isnull(jgts,0),@dh=dh  from whzxyy_yw_zyfymx where fymxid=@t1_fymxid  
   --Modify By Tany 2015-02-05 没有考虑新系统产生费用的问题，先改一下
   if (not exists (select 1 from dbo.vi_zy_newhishsz where deptid=@DptmtCd))     
   begin 
		select top 1 @jl=jl,@jldw=jldw,@jgts=isnull(jgts,0),@dh=dh  from whzxyy_yw_zyfymx where fymxid=@t1_fymxid    
   end
   else
   begin
		select @jl=cast(
   		(case when DWLX<>1 and MNGTYPE IN(1,5) then cast(a.zsl as varchar(50))	 --临时医嘱 使用总数量
   		 when dwlx=1 and MNGTYPE IN(1,5) then cast(a.zsl/b.HLXS as varchar(50))  --Modify By Tany 2015-03-30 临嘱的总量单位如果是剂量单位的话，也要换算
		 when dwlx=1 AND MNGTYPE NOT IN(1,5) then cast(a.NUM/b.HLXS as varchar(50))  --长期医嘱 开含量转换  长期医嘱应该判断dwlx而不是jldwlx Modify By tany 2014-10-15
		 when jldwlx=1 AND MNGTYPE IN(1,5) then cast(a.NUM/b.HLXS as varchar(50))  --临时医嘱 开含量转换 Modify By tany 2014-10-15	
		 else cast(a.NUM as varchar(50)) end) as decimal(15,4)),
		@jldw=(case when DWLX<>1 and MNGTYPE IN(1,5) then a.zsldw	 --临时医嘱 使用总数量
		 when dwlx=1 and MNGTYPE IN(1,5) then dbo.fun_yp_ypdw(BZDW)
		 when dwlx=1 AND MNGTYPE NOT IN(1,5) then dbo.fun_yp_ypdw(BZDW)  --长期医嘱 开含量转换  长期医嘱应该判断dwlx而不是jldwlx Modify By tany 2014-10-15
		 when jldwlx=1 AND MNGTYPE IN(1,5) then dbo.fun_yp_ypdw(BZDW) else a.UNIT end),
		@jgts=1 
		from ZY_ORDERRECORD a inner join VI_YP_YPCD b on a.HOITEM_ID=b.cjid where ORDER_ID=@t1_orderid    
   end
     
   if @jl is null set @jl=0    
   --如果是临时医嘱,且剂量单位与药库单位相同    
   if @t1_mngtype=1 and  RTRIM(@jldw)=RTRIM(@t1_ykdw)    
   begin    
      set @jl=CAST(@jl*@t1_bzsl AS DECIMAL(15,2))    
      SET @jldw=@t1_bzdw    
   end    
          
   set @v_DoseList=replace(@v_execTime,'/',':'+cast(@jl as varchar(50))+';');    
   set @v_DoseList=@v_DoseList+':'+cast(@jl as varchar(50));    
        
   if @t1_mngtype=1    
      SET @jgts=1    
          
   set @drtscd2=''    
   if @T1_MedNote='qod' and @jgts>1    
    set @drtscd2=@T1_MedNote+' '+@t1_mednm+' '+cast(cast(@jl as float) as varchar(50))+@jldw     
       
       
   if @jl>0    
   begin    
    if @jgts=0 or @jgts is null    
      set @jgts=1    
    update #tmp_zyfy_BYJ set  TakeDays=@jgts,MedUnit=@jldw, DoseList=@v_DoseList,drtscd=@drtscd2  where id=@T1_ID;--,OrderNum=@dh    
   end    
   else    
    update #tmp_zyfy_BYJ set  MedUnit=@jldw,DoseList=@v_DoseList,TakeDays=0,drtscd=@drtscd2 where id=@T1_ID;--,OrderNum=@dh    
   ----if @t1_mngtype=0--长期医嘱要计算使用天数    
   ----begin    
   ---- if @jl>0    
   ---- begin    
   ----    if @jl<1 and (rtrim(@T1_MedNote)='qd' or rtrim(@T1_MedNote)='qn' or rtrim(@T1_MedNote)='qod' )  --如果剂量小于1 且是QD QN 单次计量算1后,再除执行次数    
   ----    begin    
   ----   --set @jl= dbo.GETINT(@jl,1)    
   ----   update #tmp_zyfy_BYJ set MedUnit=@jldw, DoseList=@v_DoseList,TakeDays=cast((@t1_fee_num/(@jl*@execnum)) as int) where id=@T1_ID;    
   ----    end    
   ----    else    
   ----   --update #tmp_zyfy_BYJ set MedUnit=@jldw, DoseList=@v_DoseList,    
   ----   --TakeDays=cast((@t1_fee_num/ (@jl*@execnum)  ) as int) where id=@T1_ID;    
   ----   update #tmp_zyfy_BYJ set MedUnit=@jldw, DoseList=@v_DoseList,    
   ----   TakeDays=cast((@t1_fee_num/ cast( dbo.GETINT((@jl*@execnum),1) as decimal(15,2))  ) as int) where id=@T1_ID;    
   ---- end    
   ---- else    
   ----  update #tmp_zyfy_BYJ set  MedUnit=@jldw,DoseList=@v_DoseList,TakeDays=0 where id=@T1_ID;    
   ----end    
   ----else    
   ----begin    
   ----     update #tmp_zyfy_BYJ set  TakeDays=1,MedUnit=@jldw, DoseList=@v_DoseList where id=@T1_ID;    
   ----end    
        
fetch next from T1 into @T1_ID,@T1_MedCd,@T1_MedNote,@T1_DWLX,@T1_NUM,@T1_HLXS,@T1_fristCX,@T1_endCX,@T1_CFDate,@T1_KSDate,@T1_TZDate,@t1_fee_num,@t1_fee_unit,@t1_fee_unitrate,@t1_fymxid,@t1_mngtype,@t1_ykdw,@t1_bzsl,@t1_bzdw,@t1_mednm,@DptmtCd,@t1_orderid   
end     
CLOSE T1    
DEALLOCATE T1    
    
      
insert into dbo.zy_fy_byj    
   (id,HsptCd,DptmtCd,WardCd,DataClsf,InOutClsf,OrderDt,OrderDtm,    
 OrderNum,RoomNum,PtntNm,PtntNum,Sex,DoctorNm,Birthday,PtntAddr,    
 PtntTel,MedCd,MedNm,MedNote,MedSpec,MedUnit,UseAtcYn,DoseList,    
 TakeDays,TakeDt,XmlFlag,inpatientID,groupID,fybid,yfid,DrtsCd)--isby    
select id,HsptCd,DptmtCd,WardCd,DataClsf,InOutClsf,OrderDt,OrderDtm,    
 OrderNum,RoomNum,PtntNm,PtntNum,Sex,DoctorNm,Birthday,PtntAddr,    
 PtntTel,MedCd,MedNm,MedNote,MedSpec,MedUnit,    
    (case when takedays=0 or MedUnit='盒' or MedUnit='瓶'  then 'N' else UseAtcYn end) UseAtcYn,DoseList,    
 TakeDays,TakeDt,XmlFlag,inpatientID,groupID,fybid,yfid,    
  DrtsCd--(case when medcd=1287 then '单独服用' else DrtsCd end) as    
   from #tmp_zyfy_BYJ    
end;