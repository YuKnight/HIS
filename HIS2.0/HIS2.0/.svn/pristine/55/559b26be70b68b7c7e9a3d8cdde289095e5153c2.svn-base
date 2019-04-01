IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_SELECT_CX_ZYCFCX' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_SELECT_CX_ZYCFCX
GO
 
CREATE PROCEDURE [dbo].[SP_YF_SELECT_CX_ZYCFCX]
 (
 	@functionName varchar(30),--构造函数
	@deptid INTEGER,--药房代码
	@inpatient_id varchar(100),--病历号
	@lyks int,
	@mbid int,
    @cjid int,
	@QRRQ1 VARCHAR(30),--发药日期
	@QRRQ2 VARCHAR(30),--发药日期
	@QRCZYH INT,--发药操作员
	@fybz smallint,--发药标志
    @where varchar(3000),
	@bk int,
		@tlfs int,
	@type varchar(30)
 ) 
as
begin
  
 declare @table varchar(100)
 declare @ssql varchar(8000)

 SET @table='zy_fee_speci ';
IF @bk=1 
   SET @table='zy_fee_speci_h'
IF @bk=2
   SET @table='vi_zy_fee_speci'


create TABLE #zy_fee_speci
   (
      inpatient_id UNIQUEIDENTIFIER,
	  baby_id bigint,
	  cost_price decimal(18,4),
	  num decimal(18,4),
	  unit varchar(100),
	  dosage int,
	  unitrate int,
	  sdvalue decimal(18,4),
	  presc_date datetime,
	  CHARGE_DATE datetime,
	  charge_user int,
	  fy_bit smallint,
	  fy_date datetime,
	  fy_user int,
	  cjid int,
	  presc_no decimal(21,6),
	  tlfs int,
      dept_ly int,
	  execdept_id int
   )

set @ssql='insert into #zy_fee_speci(
inpatient_id,baby_id,cost_price,num,unit,dosage,unitrate,sdvalue,presc_date,charge_date,charge_user,fy_bit,fy_date,fy_user,
cjid,presc_no,tlfs,dept_ly,execdept_id)
select  
inpatient_id,baby_id,cost_price,num,unit,dosage,unitrate,sdvalue,presc_date,charge_date,charge_user,fy_bit,fy_date,fy_user,
xmid,presc_no,tlfs,dept_ly,execdept_id from  '+@table+' a (nolock) '
if @mbid>0 
  set @ssql=@ssql+' inner join yp_yptjmbmx b on a.xmly=1 and a.xmid=b.cjid and  mbid='+cast(@mbid as varchar(20))+' '

if @fybz=1 
  set @ssql=@ssql+' where xmly=1 and fy_date>='''+@qrrq1+''' and fy_date<='''+@qrrq2+''' and fy_bit=1 and delete_bit=0 '
else
  set @ssql=@ssql+' where xmly=1 and presc_date>='''+@qrrq1+''' and presc_date<='''+@qrrq2+''' and fy_bit=0  and delete_bit=0  '

if @deptid>0 
	      set @ssql=@ssql+' and execdept_id='+cast(@deptid as char(10))+'';

if @inpatient_id<>''
  set @ssql=@ssql+' and inpatient_id='''+@inpatient_id+''''

if @lyks>0 
  set @ssql=@ssql+' and dept_ly='+cast(@lyks as varchar(20))+'';

--if @mbid>0 
--  set @ssql=@ssql+'  and xmid in (select cjid from yp_yptjmbmx where mbid='+cast(@mbid as varchar(20))+') '

if @cjid>0 
  set @ssql=@ssql+' and xmly=1 and  xmid='+cast(@cjid as varchar(20))+'';
exec(@ssql)
print @ssql

set @ssql='select 0 序号,
dbo.fun_getdeptname(a.dept_ly) 领药科室,
(case when tlfs=3 then ''出院带药'' when tlfs=5 then ''处方发药'' when tlfs=9 then ''暂存''  else ''统领'' end) 类型,
dbo.FUN_ZY_GETBEDNO(bed_id) 床号,
c.name 姓名,
c.inpatient_no 住院号,
c.sex_name 性别,
c.age 年龄,
s_ypjx 剂型,
yppm+isnull(ypspmbz,'''') 品名,
ypspm 商品名,
ypgg 规格,'+'s_sccj 厂家,
cast(cost_price as float) 单价,
cast(kcl as float) 库存数,
cast(a.num as float) 数量,
a.unit 单位,
a.dosage 剂数,
cast(round(sdvalue,3) as decimal(15,3)) 金额,
isnull(shh,'''') 货号,
dbo.fun_getdeptname(execdept_id) 执行科室,
presc_date 处方日期,
charge_date 记费日期,
'+'dbo.fun_getempname(charge_user) 记费员,
'+'fy_date 发药日期,
dbo.fun_getempname(fy_user) 发药员,
cast(cast(presc_no as decimal(21,5)) as varchar(100)) 处方号'+' ,
cast(num*b.dwbl*dosage/unitrate as float) ypsl 
from #zy_fee_speci a 
inner join'+' vi_yf_kcmx b(nolock) on a.cjid=b.cjid and a.execdept_id=b.deptid
inner join VI_ZY_VINPATIENT_INFO c(nolock)  on  a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id '
--inner join vi_yp_ypcd d (nolock) on a.cjid=d.cjid   '  
if @where<>'' 
  set @ssql=@ssql+' and ('+@where+')'
if @tlfs<>-1
  set @ssql=@ssql+' and tlfs='+cast(@tlfs as char(10))+'';
if @type='冲减'
  set @ssql=@ssql+' and a.num <=0';  
if @type='统领'
  set @ssql=@ssql+' and a.num >=0';  
set @ssql=@ssql+' order by dept_ly,c.inpatient_no'

print @ssql
EXEC (@SSQL)


set @ssql='select 0 序号,
rtrim(s_ypjx) 剂型,
 rtrim(yppm) 品名,
  rtrim(ypspm) 商品名,
   rtrim(ypgg) 规格,
 rtrim(s_sccj) 厂家,
 cost_price 单价,
 cast(sum(num*b.dwbl*dosage/unitrate) as float) 领药数,
 dbo.fun_yp_ypdw(zxdw) 单位,
 cast(cast(round(sum(num*b.dwbl*dosage/unitrate)/dwbl,3) as float) as varchar(30))+s_ypdw 药库单位,
cast(round(sum(sdvalue),3) as decimal(15,3)) 金额,
shh 货号,
dbo.fun_getdeptname(dept_ly) 领药科室 
 from #zy_fee_speci a 
 inner join'+' vi_yf_kcmx b(nolock) on a.cjid=b.cjid and a.execdept_id=b.deptid
inner join VI_ZY_VINPATIENT_INFO c(nolock)  on  a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id '
--inner join vi_yp_ypcd d (nolock) on a.cjid=d.cjid   '  
if @where<>'' 
  set @ssql=@ssql+' and ('+@where+')'
if @tlfs<>-1
  set @ssql=@ssql+' and tlfs='+cast(@tlfs as char(10))+'';
if @type='冲减'
  set @ssql=@ssql+' and num <=0' 
if @type='统领'
  set @ssql=@ssql+' and num >=0'
set @ssql=@ssql+' group by s_ypjx,yppm,ypspm,ypgg,s_sccj,cost_price,zxdw,dwbl,s_ypdw,shh,dept_ly '
 
set @ssql=@ssql+'  order by 货号,领药科室'
print @ssql
EXEC (@SSQL)


set @ssql='select row_number() over(order by shh asc) 序号,
rtrim(s_ypjx) 剂型,
 rtrim(yppm) 品名,
  rtrim(ypspm) 商品名,
   rtrim(ypgg) 规格,
 rtrim(s_sccj) 厂家,
 cost_price 单价,
 cast(sum(num*b.dwbl*dosage/unitrate) as float) 领药数,
 cast(kcl as float) 库存数,
 cast(kcl as float)- cast(sum(num*b.dwbl*dosage/unitrate) as float) as 差额,
 dbo.fun_yp_ypdw(zxdw) 单位,
cast(round(sum(sdvalue),3) as decimal(15,3)) 金额,
shh 货号 
 from #zy_fee_speci a 
 inner join'+' vi_yf_kcmx b(nolock) on a.cjid=b.cjid and a.execdept_id=b.deptid
inner join VI_ZY_VINPATIENT_INFO c(nolock)  on  a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id '
--inner join vi_yp_ypcd d (nolock) on a.cjid=d.cjid   '  
if @where<>'' 
  set @ssql=@ssql+' and ('+@where+')'
if @tlfs<>-1
  set @ssql=@ssql+' and tlfs='+cast(@tlfs as char(10))+'';
if @type='冲减'
  set @ssql=@ssql+' and num <=0';  
if @type='统领'
  set @ssql=@ssql+' and num >=0';  
set @ssql=@ssql+' group by s_ypjx,yppm,kcl,ypspm,ypgg,s_sccj,cost_price,zxdw,dwbl,shh '

set @ssql=@ssql+'  order by 货号'
print @ssql
EXEC (@SSQL)
end




 


