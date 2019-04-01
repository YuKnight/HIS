
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_KSSZB_TJ_QBBR' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_KSSZB_TJ_QBBR
GO
create PROCEDURE [dbo].SP_YP_KSSZB_TJ_QBBR
    @rq1 datetime,
    @rq2 datetime,
	@ksdm INT,
	@ysdm int,
	@tjlx int, --1按科室 2按医生
    @kssdjid int --抗生素等级ID select * from yp_kssdj
AS
BEGIN

  --一类切口手术预防使用抗菌药物比例
  create table #tempYp(cjid int,kssdjid int,hlxs decimal(15,4),ddd decimal(15,4),bzsl int)
  create table #tempSs(inpatient_id UNIQUEIDENTIFIER,deptid int,ysdm int,sno varchar(30),bkss smallint)
  insert into #tempyp(cjid,kssdjid,hlxs,ddd,bzsl) 
  select cjid,kssdjid,hlxs,ddd,bzsl from vi_yp_ypcd where kssdjid>0 and ddd>0
  
  insert into #tempSs(inpatient_id,deptid,ysdm,sno,bkss)
  select a.inpatient_id,a.deptid,a.sqdjczy,a.sno,0
  from ss_apprecord a ,ss_arrrecord b where a.sno=b.sno and a.inpatient_id=
  b.inpatient_id and a.bdelete=0 and b.bdelete=0 and yxssrq>=@rq1 and yxssrq<=@rq2  
  and qklx='一类' 	
  and (@ksdm=0 or (@ksdm>0 and deptid=@ksdm)) 
  and (@ysdm=0 or (@ysdm>0 and sqdjczy=@ysdm))
  
  update #tempSs set bkss=1 where inpatient_id in(
  select c.inpatient_id from zy_fee_speci a inner join #tempyp b  on a.xmly=1 and a.xmid=b.cjid
  inner join #tempSs c on a.inpatient_id=c.inpatient_id
  group by c.inpatient_id)
  
  --.抗菌药物使用量（DDDs）
  --抗菌药物消耗总数X抗菌药物的规格（含量，单位：克）
  ----------------------------------------------------------------------
  --抗菌药物的DDD值
  create table #tempFee(inpatient_id UNIQUEIDENTIFIER,cjid int ,num decimal(15,1),hl_num decimal(15,4),ddds decimal(15,4))
  insert into #tempFee
  select inpatient_id,cjid,sum(num/unitrate)*bzsl,sum(num/unitrate)*bzsl*hlxs ,(sum(num/unitrate)*bzsl*hlxs)/ddd
  from zy_fee_speci a inner join #tempYp b on a.xmly=1 and a.xmid=b.cjid
  where presc_date>=@rq1 and presc_date<=@rq2 and a.delete_bit=0 and 
  ((kssdjid=@kssdjid and @kssdjid>0) or @kssdjid=0)
  group by inpatient_id,cjid,ddd,bzsl,hlxs
  
  --抗菌药物的使用率
  --住院患者中抗菌药物的病例数  X100
  -------------------------------------------------
  --            同期收治患者人数

  
--住院患者使用基本药物品种数
--用基本药物品种次数（累计）   X100   （结果应小于100，目前统计数据大于1000）
-------------------------------------------------------------------
--同期使用药品总品种次数（累计）


--患者使用基本药物品种数create table #tempJbyw(inpatient_id UNIQUEIDENTIFIER,cjid int,zs decimal(15,0),jbywzs decimal(15,0))insert into #tempJbywselect  inpatient_id,XMID,count(*) zs ,count(case when gjjbyw>0 then 1 else null end) jbywzs from zy_fee_speci a inner join vi_yp_ypcd bon a.xmid=b.cjid  and a.xmly=1 and presc_date>=@rq1 and presc_date<=@rq2 group by inpatient_id ,xmid order by inpatient_id,xmid

--切口-------------------------------------------------------------------------
if @tjlx=1
	SELECT dbo.fun_getdeptname(deptid) 科室名称,count(*) 一类切口总数,
	cast(sum(case when bkss=1 then 1.0 else 0.0 end) as float)  使用抗菌药物总数,
	cast(cast(round(sum(case when bkss=1 then 1.0 else 0.0 end)/count(*),4)*100 as float) as varchar(100))+'%' 比例
	FROM #tempSs 
	where (@ksdm=0 or (@ksdm>0 and deptid=@ksdm)) 	and (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) 
	GROUP BY deptid order by deptid
else
	SELECT dbo.fun_getdeptname(deptid) 科室名称,dbo.fun_getempname(ysdm) 医生,
	count(*) 一类切口总数,
	cast(sum(case when bkss=1 then 1.0 else 0.0 end) as float)  使用抗菌药物总数,
	cast(cast(round(sum(case when bkss=1 then 1.0 else 0.0 end)/count(*),4)*100 as float) as varchar(100))+'%' 比例
	FROM #tempSs 
	where (@ysdm=0 or (@ysdm>0 and ysdm=@ysdm)) 
	GROUP BY deptid,ysdm order by deptid,ysdm


--抗菌药物DDDS 及比例-------------------------------------------------------------------------
if @tjlx=1
   select dbo.fun_getdeptname(c.dept_id) 科室名称,b.yppm 品名,b.shh 货号,b.ypgg 规格,cast(sum(num) as float) 用量,dbo.fun_yp_ypdw(bzdw) 单位,
   cast(ddd as float) ddd,cast(cast(hlxs as float) as varchar(10))+dbo.fun_yp_ypdw(hldw)+'/'+dbo.fun_yp_ypdw(bzdw) 规格含量,cast(sum(DDDS) as float) DDDS
    from #tempFee a inner join vi_yp_ypcd b  on a.cjid=b.cjid 
   inner join zy_inpatient c on a.inpatient_id=c.inpatient_id
   where (@ksdm=0 or (@ksdm>0 and c.dept_id=@ksdm)) 
   group by c.dept_id,b.shh,b.yppm,b.ypgg,b.bzdw,ddd,hlxs,hldw,bzsl
   order by c.dept_id,yppm
else
   select dbo.fun_getdeptname(c.dept_id) 科室名称,dbo.fun_getempname(c.zy_doc) 医生,b.yppm 品名,b.shh 货号,b.ypgg 规格,cast(sum(num) as float) 用量,dbo.fun_yp_ypdw(bzdw) 单位,
   cast(ddd as float) ddd,cast(cast(hlxs as float) as varchar(10))+dbo.fun_yp_ypdw(hldw)+'/'+dbo.fun_yp_ypdw(bzdw) 规格含量,cast(sum(DDDS) as float) DDDS
    from #tempFee a inner join vi_yp_ypcd b  on a.cjid=b.cjid 
   inner join zy_inpatient c on a.inpatient_id=c.inpatient_id
   where (@ysdm=0 or (@ysdm>0 and c.zy_doc=@ysdm)) 
   group by c.dept_id,c.zy_doc,b.shh,b.yppm,b.ypgg,b.bzdw,ddd,hlxs,hldw,bzsl 
   order by c.dept_id,c.zy_doc,yppm
   
-------抗菌药物的使用率-----------------------------------------------------------------
if @tjlx=1 
    select dbo.fun_getdeptname(a.dept_id) 科室名称,
   cast(sum(case when b.inpatient_id is not null then 1.0 else 0.0 end) as float)  抗菌药物病例数 ,
   count(*) 同期收治患者人数,
   cast(cast(round(sum(case when b.inpatient_id is not null then 1.0 else 0.0 end) /count(*),4)*100 as float) as varchar(30))+'%' 
   抗菌药物使用率
   from zy_inpatient a
   left join 
   (select inpatient_id from #tempFee group by inpatient_id) b on a.inpatient_id=b.inpatient_id
   where in_date>=@rq1 and in_date<=@rq2 and flag<>10
   and (@ksdm=0 or (@ksdm>0 and a.dept_id=@ksdm)) 
   group by a.dept_id
   order by a.dept_id
 else
    select dbo.fun_getdeptname(a.dept_id) 科室名称,dbo.fun_getempname(a.zy_doc) 医生,
   cast(sum(case when b.inpatient_id is not null then 1.0 else 0.0 end) as float)  抗菌药物病例数 ,
   count(*) 同期收治患者人数,
   cast(cast(round(sum(case when b.inpatient_id is not null then 1.0 else 0.0 end) /count(*),4)*100 as float) as varchar(30))+'%' 
   抗菌药物使用率
   from zy_inpatient a
   left join 
   (select inpatient_id from #tempFee group by inpatient_id) b on a.inpatient_id=b.inpatient_id
   where in_date>=@rq1 and in_date<=@rq2 and flag<>10  
   and (@ysdm=0 or (@ysdm>0 and a.zy_doc=@ysdm)) 
   group by a.dept_id,a.zy_doc
   order by a.dept_id
------------------------基本药物总数-----------------------------------------------------
if @tjlx=1
	SELECT dbo.fun_getdeptname(dept_id) 科室名称,
	cast(sum(jbywzs) as float)  用基本药物品种次数,
	cast(sum(zs) as float) 同期使用药品总品种次数,
	cast(cast(round(sum(jbywzs)/sum(zs),4)*100 as float) as varchar(100))+'%' 基本药物使用率
	FROM #tempJbyw a inner join zy_inpatient b on a.inpatient_id=b.inpatient_id
	where  (@ksdm=0 or (@ksdm>0 and dept_id=@ksdm)) 
	GROUP BY dept_id order by dept_id
else
	SELECT dbo.fun_getdeptname(dept_id) 科室名称,dbo.fun_getempname(zy_doc) 医生,
	cast(sum(jbywzs) as float) 用基本药物品种次数,
	cast(sum(zs) as float) 同期使用药品总品种次数,
	cast(cast(round(sum(jbywzs)/sum(zs),4)*100 as float) as varchar(100))+'%' 基本药物使用率
	FROM #tempJbyw a inner join zy_inpatient b on a.inpatient_id=b.inpatient_id
	where (@ysdm=0 or (@ysdm>0 and zy_doc=@ysdm)) 
	GROUP BY dept_id,zy_doc order by dept_id

   

--备注信息
select '备注:(I类切口手术预防使用抗菌药物病例数/同期I类切口手术病例数)*100  在院和出院病人都算在内按手术日期统计 只有进行了术后补录才能统计到结果,请注意。此条件包含了全部等级的抗生素' bz1,
'备注:(抗菌药物消耗总数X抗菌药物的规格含量)/抗菌药物的DDD值 在院和出院病人都算在内 按实际开具处方日期不区分是否发药 根据选择的抗生素等级进行统计' bz2,
'备注:(住院患者中使用抗菌药物的病例数/同期收治患者人数)*100 在院和出院病人都算在内 确良按实际开具处方日期不区分是否发药  根据选择的抗生素等级进行统计  同期收治患者人数按入院日期统计' bz3,
'备注:( 用基本药物品种次数(累计)/同期使用药品总品种次数(累计) )*100 在院和出院病人都算在内 按实际开具处方日期不区分是否发药' bz4
END

--exec SP_YP_KSSZB_TJ_QBBR '2011-08-01 00:00:00','2011-08-11 23:00:00',0,0,1,1
--select * from ss_arrrecord
--select * from base_dept 

--select * from zy_fee_speci where inpatient_id='1A05FB3E-2DFF-4E82-8C0D-9F1700A95C7A' 
--and xmly=1

--update yp_ypggd set gjjbyw=1 where ggid in(select ggid from yp_ypcjd where cjid in(683,685))