
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_CX_JYTMDY' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_CX_JYTMDY
GO
CREATE PROCEDURE SP_YF_CX_JYTMDY
 ( 
   @deptid int,
   @RQ1 VARCHAR(30), 
   @RQ2 VARCHAR(30),
   @ksdm int,
   @bed_no varchar(30),
   @inpatient_no varchar(30),
   @bdybz int
 )
as 
begin
declare @sql varchar(4000)
create table #temp(id UNIQUEIDENTIFIER,INPATIENT_ID UNIQUEIDENTIFIER,dept_id int,SL INT,DW VARCHAR(20),
JE DECIMAL(15,2),charge_date datetime,DYSJ DATETIME)

SET @sql='
INSERT INTO #temp
select a.ID, A.INPATIENT_ID,b.DEPT_ID,
sum(b.num) 副数,b.UNIT 单位,SUM(SDVALUE) ,dbo.Fun_GetDate(presc_date),DYSJ from ZY_DECOCT a (nolock)
inner join ZY_FEE_SPECI b(nolock) on   a.ORDER_ID=b.ORDER_ID
and isnull(a.order_id,dbo.FUN_GETEMPTYGUID())!=dbo.FUN_GETEMPTYGUID()
where 1=1'
IF @bdybz=0
	SET @SQL=@SQL+' AND CHARGE_DATE>='''+@RQ1+''' and CHARGE_DATE<='''+@RQ2+''' and b.DELETE_BIT=0 and bdybz=0 '
ELSE
	SET @SQL=@SQL+' AND DYSJ>='''+@RQ1+''' and DYSJ<='''+@RQ2+''' and b.DELETE_BIT=0 and bdybz=1'

SET @SQL=@SQL+' group by a.id,A.INPATIENT_ID,b.DEPT_ID,b.UNIT,dbo.Fun_GetDate(presc_date),a.dysj '

EXEC (@SQL)
--insert into #temp2
--select  a.INPATIENT_ID,a.GROUP_ID, dbo.Fun_GetDate(c.FY_DATE)
--from #temp a inner join ZY_ORDERRECORD b on a.INPATIENT_ID=b.INPATIENT_ID and a.GROUP_ID=b.GROUP_ID and b.XMLY=1
--inner join ZY_FEE_SPECI c on b.ORDER_ID=c.ORDER_ID 
--group by a.INPATIENT_ID,a.GROUP_ID,dbo.Fun_GetDate(c.FY_DATE)

--update a set a.fyrq=b.fyrq from #temp a inner join #temp2 b on a.INPATIENT_ID=b.INPATIENT_ID and a.GROUP_ID=b.GROUP_ID 

set @sql='
select INPATIENT_NO 住院号,NAME 姓名,''[''+d.ward_name+''] ''+dbo.fun_getDeptname(a.DEPT_ID) 开单科室,dbo.FUN_ZY_GETBEDNO(BED_ID) 床号,
SL 数量,rtrim(dw) 单位,je 金额,dbo.Fun_GetDate(charge_date) 处方日期,DYSJ 打印时间,''打印'' 打印,a.id 
from #temp a inner join VI_ZY_VINPATIENT b on 
a.INPATIENT_ID=b.INPATIENT_ID 
inner join JC_WARDRDEPT c on b.dept_id=c.dept_id 
inner join JC_WARD d on c.ward_id=d.ward_id 
where 1=1 and sl>0 '
if @bed_no<>''
  set @sql=@sql+' and dbo.FUN_ZY_GETBEDNO(BED_ID)='''+@bed_no+''''
if @ksdm>0
  set @sql=@sql+' and a.dept_id='+cast(@ksdm as varchar(30))+''
if @inpatient_no<>''
  set @sql=@sql+' and INPATIENT_NO='''+cast(@INPATIENT_NO as varchar(30))+''''
set @sql=@sql+' order by d.ward_id,b.DEPT_ID,dbo.FUN_ZY_GETBEDNO(BED_ID),charge_date '

exec(@sql)
end 


--exec SP_YF_CX_JYTMDY 0,'2013-03-01 00:00:00','2013-03-05 00:00:00',0,'','',0




