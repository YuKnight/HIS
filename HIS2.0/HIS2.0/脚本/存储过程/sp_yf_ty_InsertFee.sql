IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_ty_InsertFee' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_ty_InsertFee
GO
CREATE PROCEDURE sp_yf_ty_InsertFee
(
   @inpatient_id UNIQUEIDENTIFIER,
   @presc_no varchar(50),
   @zy_id UNIQUEIDENTIFIER,
   @num decimal(15,3),
   @cfts int,
   @type int, --0退整张处方 1退用量 2退剂数 5 拒绝
   @djy int,
   @deptid int, --药房科室
   @ERR_CODE INTEGER  output,
   @ERR_TEXT VARCHAR(100) output    
)  
as
begin
--病人医保类型
declare @yblx int
set @yblx=0

set @err_code=-1
set @err_text='退费没有成功'

if @type=5 
begin
   update zy_fee_speci set delete_bit=1 ,bz=dbo.fun_getempname(@djy)+'拒绝退药' where id=@zy_id and charge_bit=0 
   if @@rowcount=0
   begin
    set @err_text='该退药信息可能已记费,您不能取消'
    return
   end
    set @err_code=0
	set @err_text='拒绝退药成功'
    return
end

if @type=1 
begin
  if (@zy_id is null or @zy_id=dbo.FUN_GETEMPTYGUID() ) or @num<=0   --退用量 必须要有退费ID和退药量
  begin
     set @err_text='单独退某个药品时，费用明细ID和退药量必填'
     return
  end
end

 set @err_text='aaaa'
--查询原始处方记录
select * into  #temp  from zy_fee_speci where presc_no=@presc_no  and inpatient_id=@inpatient_id and fy_bit=1
AND ((id=@zy_id or cz_id=@zy_id) or ( (@zy_id is null or @zy_id=dbo.FUN_GETEMPTYGUID()) and @presc_no<>'0' )) 
if @@rowcount=0
begin
  set @err_text='没有找到可退药记录'
  return
end


select top 1 * into #b from #temp where discharge_bit=1 
if @@rowcount>0
begin
  set @err_text='结算了的病人不能办理退药'
  return
end 

select @yblx=yblx from zy_inpatient where inpatient_id=@inpatient_id

--退剂数时，按zy_id 合并 产生可退部分。如果在用量只要有可退部分为零的单条记录。。就不再允许退剂数.必须单条处理
if @type=2
begin
	select * into #a from (
	select (b.num+sum((case when abs(a.num)=b.num then 0 else a.num end))) num  from (
	select cz_id zy_id,num,dosage,sdvalue as jzje from #temp where cz_id is not null  union all 
	select id zy_id ,num,dosage,sdvalue as jzje from #temp where cz_id is null
	) a,#temp b where b.dosage>1 and a.zy_id=b.id and ( b.cz_id is null) group by a.zy_id,b.num 
	) a where num=0  
	if @@rowcount>0
	begin
	  set @err_text='系统不支持此操作，请逐个退药'
	  return
	end
end

print 'a'

select a.zy_id,
(b.num+sum((case when abs(a.num)=b.num then 0 else a.num end)))  num,
(case when (b.num+sum( (case when abs(a.num)=b.num then 0 else a.num end)))=0 then 0 else sum(a.num*a.dosage)/(b.num+sum( (case when abs(a.num)=b.num then 0 else a.num end))) end)  dosage,
sum(a.jzje) jzje  into #xxx from (  
select cz_id zy_id,num,dosage,sdvalue as jzje from #temp where cz_id is not null  union all 
select id zy_id,num,dosage,sdvalue as jzje from #temp where  cz_id is null 
) a,#temp b where a.zy_id=b.id and ( b.cz_id is null) group by a.zy_id,b.num 

print 'b'


--计算需要退药的部份
 create table #yyy
   (zy_id UNIQUEIDENTIFIER,num decimal(15,3),dosage int,jzje decimal(15,3)) 

-------------全退-----------------
if @type=0 
   insert into #yyy select zy_id,-num,dosage,-jzje from #xxx where num<>0 and dosage<>0
-------------退单个-----------------
if @type=1 
begin
    declare @sl decimal(15,3)
    select @sl=(num+(-@num)) from #xxx
    if @sl<0 
    begin
       set @err_text='当前退药量大于可退药量，请修改退药量后再试'
       return
    end
    if @sl<>0 and @yblx=1
    begin
       set @err_text='医保病人不能部分退药，必须全退'
       return
    end
    insert into #yyy  select a.zy_id,-@num ,a.dosage , cost_price*a.dosage*(-@num) from #xxx a,#temp b where a.zy_id=b.id
end
-------------退剂数-----------------
if @type=2
begin
    declare @js decimal(15,3)
    select top 1 @js=(dosage+(-@cfts)) from #xxx
    if @js<0 
    begin
       set @err_text='当前退药剂数大于可退剂数，请修改退药剂数后再试'
       return
    end
    if @js<>0 and @yblx=1
    begin
       set @err_text='医保病人不能部分退药，必须全退'
       return
    end
    insert into #yyy  select a.zy_id,-a.num ,@cfts , cost_price*@cfts*(-a.num) from #xxx a,#temp b where a.zy_id=b.id
end



insert into zy_fee_speci([id],[INPATIENT_ID],[BABY_ID],[ORDER_ID],[ORDEREXEC_ID]
      ,[PRESCRIPTION_ID],[PRESC_NO],[PRESC_DATE],[BOOK_DATE],[BOOK_USER],[STATITEM_CODE],[TCID],[TC_FLAG]
      ,[XMID],[XMLY],[SUBCODE],[ITEM_NAME],[GG] ,[CJ],[UNIT],[UNITRATE] ,[COST_PRICE]
      ,[RETAIL_PRICE] ,[NUM] ,[DOSAGE],[SDVALUE],[AGIO],[ACVALUE],[QDRQ]
      ,[CHARGE_BIT],[CHARGE_DATE],[CHARGE_USER],[DELETE_BIT],[CZ_FLAG],[CZ_ID],[TYPE]
      ,[DISCHARGE_BIT],[DISCHARGE_ID],[SCBZ],[DOC_ID],[DEPT_ID],[DEPT_BR],[EXECDEPT_ID],[DEPT_LY]
      ,[GROUP_ID],[TLFS],[APPLY_ID],[FY_BIT],[FY_DATE],[FY_USER],[PY_USER],[BZ],[JGBM])
select
	dbo.FUN_GETGUID(newid(),getdate()) as [ID],[INPATIENT_ID],[BABY_ID],[ORDER_ID],[ORDEREXEC_ID]
      ,[PRESCRIPTION_ID],[PRESC_NO],[PRESC_DATE],[BOOK_DATE],[BOOK_USER],[STATITEM_CODE],[TCID],[TC_FLAG]
      ,[XMID],[XMLY],[SUBCODE],[ITEM_NAME],[GG] ,[CJ],[UNIT],[UNITRATE] ,[COST_PRICE]
      ,[RETAIL_PRICE] ,b.num as [NUM] ,b.dosage as [DOSAGE],b.jzje as [SDVALUE],[AGIO],b.jzje as [ACVALUE],[QDRQ]
      ,1 as [CHARGE_BIT],getdate() as [CHARGE_DATE],@djy as [CHARGE_USER],[DELETE_BIT],2 [CZ_FLAG],b.zy_id as [CZ_ID],[TYPE]
      ,[DISCHARGE_BIT],[DISCHARGE_ID],0 as [SCBZ],[DOC_ID],[DEPT_ID],[DEPT_BR],[EXECDEPT_ID],[DEPT_LY]
      ,null as [GROUP_ID],[TLFS],null [APPLY_ID],1 as [FY_BIT],getdate() as [FY_DATE],@djy as [FY_USER],[PY_USER],[BZ],[JGBM]
 from #temp a,#yyy b where 
a.id=b.zy_id and ( a.cz_id is null) and b.num<0 and b.dosage>0

if @@rowcount=0 
begin
	set @err_text='没有可退的药品，请刷新后再确认'
        return
end

update zy_fee_speci set cz_flag=1 
where id in(select b.zy_id from #temp a,#yyy b where 
a.id=b.zy_id and ( a.cz_id is null) and b.num<0 and b.dosage>0)

select '退' 序号,(case when fy_bit=0 then '' else '√' end) 发药,'' 床号,c.name 姓名,c.inpatient_no 住院号,'' 性别,'' 年龄,s_ypjx 剂型,yppm 品名,ypspm 商品名,ypgg 规格,
 s_sccj 厂家,cost_price 单价,cast(kcl as float) 库存数,cast(d.num as float) 数量,a.unit 单位,d.dosage 剂数,cast(round(d.jzje,3) as decimal(15,3)) 金额,'' 煎药,'' 用法,'' 频次,'' 剂量,'' 剂量单位,shh 货号,getdate() 处方日期,getdate() 记费日期,
 dbo.fun_getempname(@djy) 记费员,
 getdate() 发药日期,dbo.fun_getempname(@djy) 发药员,'' 配药员,cast(cast(presc_no as float) as varchar(100)) 处方号,a.id zy_id,b.cjid,a.dept_id,a.doc_id,
 a.unitrate ,cast(d.num*b.dwbl*d.dosage/a.unitrate as float) ypsl,zxdw,b.dwbl,a.inpatient_id,b.pfj/a.unitrate 批发价,(b.pfj*d.num*d.dosage/a.unitrate) 批发金额,dbo.fun_getdeptname(@deptid) 发药科室,1,0,dbo.fun_getempname(cast(doc_id as int)) 医生,null apply_id 
from #temp a inner join vi_yf_kcmx b on a.xmid=b.cjid  and a.xmly=1 
 inner join VI_ZY_VINPATIENT c  on  a.inpatient_id=c.inpatient_id 
inner join #yyy d on a.id=d.zy_id
where  b.deptid=@deptid  order by a.inpatient_id,presc_no,a.zy_id 

set @err_code=0
set @err_text='退费成功'


end






