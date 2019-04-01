if exists(select 1 from sys.objects where name = 'SP_YF_SELECT_ZYCF' and type='P')
	drop procedure SP_YF_SELECT_ZYCF
GO


CREATE PROCEDURE SP_YF_SELECT_ZYCF    

 ( @dept_ly int,     

   @INPATIENTID UNIQUEIDENTIFIER,     

   @PRESC_DATE1 VARCHAR(30),     

   @PRESC_DATE2 VARCHAR(30),     

   @CHARGE_DATE1 VARCHAR(30),     

   @CHARGE_DATE2 VARCHAR(30),     

   @FY_DATE1 VARCHAR(30),     

   @FY_DATE2 VARCHAR(30),     

   @FYBZ VARCHAR(2),     

   @BK SMALLINT,     

   @CYDY SMALLINT,     

   @DEPTID INTEGER,    

   @cfh decimal(21,6),    

   @bdybz int    

 )     

as    

    

  BEGIN     

  declare @tlfs varchar(50);    

  declare @table_FEE varchar(50);    

  declare @table_order varchar(50);    

  --declare @dept_ly int;    

  declare @stmt varchar(6000);    

    

    

create TABLE #zy_fee_speci    

   (    

      id UNIQUEIDENTIFIER  ,    

      order_id UNIQUEIDENTIFIER,    

      order_context varchar(200),    

   cost_price decimal(18,4),    

   num decimal(18,4),    

   unit varchar(100),    

   dosage int,    

   unitrate int,    

   sdvalue decimal(18,4),    

   presc_date datetime,    

   charge_bit smallint,    

   CHARGE_DATE datetime,    

   charge_user int,    

   fy_bit smallint,    

   fy_date datetime,    

   fy_user int,    

   py_user int,    

   inpatient_id UNIQUEIDENTIFIER,    

   baby_id bigint,    

   cjid int,    

     DOC_ID INT,    

   DEPT_ID INT,    

   presc_no decimal(21,6),    

   inpatient_no varchar(50),    

   name varchar(50),    

   sex_name varchar(10),    

   age varchar(10),    

   bed_no varchar(10),    

   execdept_id int,    

   discharge_bit smallint,    

   jy varchar(30),    

   order_usage varchar(100),    

   frequency varchar(100),    

   jl decimal(18,3),    

   jldw varchar(50),    

   dept_ly int,    

   apply_id UNIQUEIDENTIFIER,    

   tlfs int,    

   cz_id uniqueidentifier,    

   kcid uniqueidentifier     

   )    

       

set @table_FEE='zy_fee_speci';    

SET @table_order='zy_orderrecord';    

if @bk=1     

begin    

 set @table_FEE='zy_fee_speci_h';    

 SET @table_order='zy_orderrecord_h';    

end    

    

    

create table #temp(presc_no decimal(21,6))    

if @bdybz=0 and @fybz='1'     

begin    

 if len(rtrim(@fy_date1))<=10     

  insert #temp(presc_no)select jssjh from yf_fy     

  where bdybz=0 and jzcfbz=1  and fyrq>=@fy_date1+' 00:00:00' and fyrq<=@fy_date2+' 23:59:59'    

 else    

     insert #temp(presc_no)select jssjh from yf_fy     

  where bdybz=0 and jzcfbz=1  and fyrq>=@fy_date1+'' and fyrq<=@fy_date2+''    

end    

      

     set @stmt='insert into #zy_fee_speci(id,order_id,order_context,cost_price,num,dosage,unit,unitrate,sdvalue,presc_date,charge_bit,'+    

  'charge_date,charge_user,fy_bit,fy_date,fy_user,py_user,inpatient_id,baby_id,cjid,doc_id,dept_id,presc_no,execdept_id,discharge_bit,jy,order_usage,frequency,jl,jldw,dept_ly,apply_id,tlfs    

    ,cz_id,kcid )'+    

  'select a.id,a.order_id,(case when order_context is null then a.item_name else order_context end),cost_price,a.num,a.dosage,rtrim(a.unit),a.unitrate,a.sdvalue,presc_date,a.charge_bit,'+    

  'a.charge_date,a.charge_user,fy_bit,fy_date,fy_user,'+    

  'py_user,a.inpatient_id,a.baby_id,a.xmid,a.doc_id,a.dept_ly dept_id,a.presc_no,execdept_id,discharge_bit,'+    

  ' (case when (select top 1  inpatient_id from ZY_DECOCT where inpatient_id=a.inpatient_id and group_id=coalesce(d.group_id,0) and isnull(order_id,dbo.FUN_GETEMPTYGUID())!=dbo.FUN_GETEMPTYGUID() ) is not null then ''代煎'' else '''' end) jy, '+    

  'rtrim(order_usage),rtrim(frequency),d.num,rtrim(d.unit),a.dept_ly,apply_id,tlfs  ,cz_id,kcid '+    

  'from '+@table_FEE+' a '+    

  ' left join '+@table_order +' d on a.order_id=d.order_id where  a.delete_bit=0  and a.xmly=1 ';    

      

  if @cydy=1     

    set @tlfs=' and tlfs=3 ';    

  else    

    set @tlfs=' and tlfs=5 ';    

    

      

  if @deptid>0     

       set @stmt=@stmt+' and a.execdept_id='+cast(@deptid as char(10))+'';    

    

      

  --处方日期    

  if rtrim(@presc_date1)<>''     

        set @stmt=@stmt+' and presc_date>='''+rtrim(@presc_date1)+ ' 00:00:01'' and presc_date<='''+ rtrim(@presc_date2)+ ' 23:59:59''';    

    

  --记费日期    

  if rtrim(@charge_date1)<>''     

        set @stmt=@stmt+' and  charge_date>='''+@charge_date1+ ' 00:00:01'' and charge_date<='''+ @charge_date2+ ' 23:59:59''';    

    

    

  --发药标志    

  if rtrim(@fybz)='0' or rtrim(@fybz)='1'     

        set @stmt=@stmt+' and fy_bit='+cast(@fybz as char(10))+' and coalesce(py_user,0)<>-999 ';    

  else     

         set @stmt=@stmt+' and py_user=-999';    

    

  --发药日期    

  if rtrim(@fy_date1)<>''     

     begin    

  if len(rtrim(@fy_date1))<=10 set @fy_date1=@fy_date1+' 00:00:01'    

  if len(rtrim(@fy_date2))<=10 set @fy_date2=@fy_date2+' 23:59:59'    

        set @stmt=@stmt+' and fy_bit=1 and  fy_date>='''+rtrim(@fy_date1)+ ''' and fy_date<='''+ rtrim(@fy_date2)+ '''';    

     end    

      

  --病区ID    

   if @dept_ly>0     

       set @stmt=@stmt+' and a.dept_ly ='+cast(@dept_ly as char(10))--+' and execdept_id in(95,96,97) ';    

    

      

  --病人    

  if @inpatientid<>dbo.FUN_GETEMPTYGUID() and @inpatientid is not null    

      set @stmt=@stmt+' and a.inpatient_id='''+cast(@inpatientid as varchar(50))+'''';    

    

  if @cfh>0     

  set @stmt=@stmt+' and cast(presc_no as bigint)='+cast(cast(@cfh as bigint) as varchar(30))    

    

  if @bdybz=0 and @fybz='1'    

     set @stmt=@stmt+' and presc_no in(select presc_no from #temp) '    

   print @stmt    

  exec(@stmt)    

      

       

begin    

    

  set @stmt='select 0 序号,(case when fy_bit=0 then '''' else ''√'' end) 发药,    

  dbo.fun_jc_deptname(dept_ly) 领药科室,coalesce(d.bed_no,'''') 床号,c.name 姓名,    

  c.inpatient_no 住院号,c.sex_name 性别,dbo.fun_zy_age(BIRTHDAY,3,GETDATE()) 年龄,    

  s_ypjx 剂型,(case when STATITEM_CODE=''03'' then order_context+isnull(ypspmbz,'''') else yppm+isnull(ypspmbz,'''') end) 品名,    

  (case when STATITEM_CODE=''03'' then order_context else ypspm end) 商品名,ypgg 规格,'+    

  's_sccj 厂家,cost_price 单价,cast(kcl as float) 库存数,cast(a.num as float) 数量,a.unit 单位,    

  a.dosage 剂数,cast(round(sdvalue,3) as decimal(15,3)) 金额,jy 煎药,order_usage 用法,frequency 频次,    

  jl 剂量,jldw 剂量单位,isnull(shh,'''') 货号,presc_date 处方日期,charge_date 记费日期,'+    

  'dbo.fun_getempname(charge_user) 记费员,'+    

  'fy_date 发药日期,dbo.fun_getempname(fy_user) 发药员,    

  dbo.fun_getempname(py_user) 配药员,cast(cast(presc_no as decimal(21,5)) as varchar(100)) 处方号,    

  a.id zy_id,a.cjid,a.dept_id,a.doc_id,'+    

  'unitrate,cast(num*b.dwbl*dosage/unitrate as float) ypsl,zxdw,dwbl,a.inpatient_id,b.pfj/unitrate 批发价,    

  (b.pfj*num*dosage/unitrate) 批发金额,dbo.fun_getdeptname(execdept_id) 发药科室,charge_bit,discharge_bit,dbo.fun_getempname(cast(doc_id as int)) 医生,apply_id,tlfs,    

  a.dept_ly,dbo.fun_getdiseasename(in_diagnosis,c.yblx) 诊断,    

  replace(dbo.fun_getdiseasename(zyzd,c.yblx),''未知诊断'','''') 中医诊断,    

  replace(dbo.fun_getdiseasename(zx,c.yblx),''未知诊断'','''') 中医症型,STATITEM_CODE,jtdz 家庭地址,    

  brlxfs 联系方式,sfzh 身份证,e.hwmc as hwh     

  ,a.cz_id,kcid,execdept_id   from #zy_fee_speci a inner join'+    

  ' vi_yf_kcmx b on a.cjid=b.cjid inner join VI_ZY_VINPATIENT_INFO c  on      

  a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id

  left join YP_HWSZ e on b.ggid=e.ggid and b.DEPTID=e.DEPTID left join zy_beddiction d on c.bed_id=d.bed_id where   '+    

  '  b.deptid='+cast(@deptid as char(10))+' '+rtrim(@tlfs)+    

  ' and isnull(apply_id,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()  order by a.inpatient_id,presc_no,a.id '    

      

    

  if @deptid=0     

    set @stmt='select 0 序号,(case when fy_bit=0 then '''' else ''√'' end) 发药,    

    dbo.fun_jc_deptname(dept_ly) 领药科室,coalesce(d.bed_no,'''') 床号,c.name 姓名,    

    c.inpatient_no 住院号,c.sex_name 性别,dbo.fun_zy_age(BIRTHDAY,3,GETDATE()) 年龄,    

    s_ypjx 剂型,(case when STATITEM_CODE=''03'' then order_context+isnull(ypspmbz,'''') else yppm+isnull(ypspmbz,'''') end) 品名,    

    (case when STATITEM_CODE=''03'' then order_context else ypspm end) 商品名,ypgg 规格,'+    

   's_sccj 厂家,cost_price 单价,cast(kcl as float) 库存数,cast(num as float) 数量,unit 单位,dosage 剂数,    

   cast(round(sdvalue,3) as decimal(15,3)) 金额,jy 煎药,order_usage 用法,frequency 频次,jl 剂量,jldw 剂量单位,    

   isnull(shh,'''') 货号,presc_date 处方日期,charge_date 记费日期,dbo.fun_getempname(charge_user) 记费员,'+    

   'fy_date 发药日期,dbo.fun_getempname(fy_user) 发药员,dbo.fun_getempname(py_user) 配药员,    

   cast(cast(presc_no as decimal(21,5)) as varchar(100)) 处方号,a.id zy_id,a.cjid,a.dept_id,a.doc_id,'+    

   'unitrate,num ypsl,0 zxdw,1 dwbl,a.inpatient_id,b.pfj/unitrate 批发价,    

   (b.pfj*num*dosage/unitrate) 批发金额,dbo.fun_getdeptname(execdept_id) 发药科室,    

   charge_bit,discharge_bit,dbo.fun_getempname(cast(doc_id as int)) 医生,    

   apply_id,tlfs    

   ,a.dept_ly ,dbo.fun_getdiseasename(in_diagnosis,c.yblx) 诊断,replace(dbo.fun_getdiseasename(zyzd,c.yblx),''未知诊断'','''') 中医诊断,    

   replace(dbo.fun_getdiseasename(zx,c.yblx),''未知诊断'','''') 中医症型,STATITEM_CODE,jtdz 家庭地址,brlxfs 联系方式,sfzh 身份证,e.hwmc as hwh       '    

   +' ,a.cz_id ,kcid,execdept_id '      

   +    

   ' from #zy_fee_speci a inner join '+    

   ' vi_yf_kcmx b on a.cjid=b.cjid and a.execdept_id=b.deptid '+rtrim(@tlfs)+' and isnull(apply_id,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()     

   inner join VI_ZY_VINPATIENT_INFO c on  a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id 

     left join YP_HWSZ e on b.ggid=e.ggid and b.DEPTID=e.DEPTID left join zy_beddiction d on c.bed_id=d.bed_id  '+    

   '  order by a.inpatient_id,presc_no,a.id '    

          

        

  exec(@stmt)    

  print @stmt    

end     

     

       

       

    

 END;