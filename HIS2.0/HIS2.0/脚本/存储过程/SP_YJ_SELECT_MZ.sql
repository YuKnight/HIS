IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[SP_YJ_SELECT_MZ]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE SP_YJ_SELECT_MZ
GO 
CREATE PROCEDURE [dbo].[SP_YJ_SELECT_MZ]            
 (              
 @execdept int,--执行科室            
 @blh varchar(50),--挂号信息ID            
 @BRXXID UNIQUEIDENTIFIER,            
 @RQLX INT,-- 0 收费日期 1确认日期            
 @RQ1 varchar(30),--            
 @RQ2 varchar(30),--            
 @BRXM VARCHAR(50),            
 @FPH VARCHAR(50),            
 @jgbm bigint ,            
 @tmdybz smallint,--条码打印标志            
 @btf int            
 )             
as            
/*-------------            
exec SP_YJ_SELECT_MZ 0,null,null,0,'2010-05-30 00:00:01','2010-05-30 23:00:00','','',1001 ,0,0    
增加标本交接时间查询列 Modify By Daniel 2015-02-03         
-------------*/            
--只显示本执行的项目 onece007 2012-06-20 添加            
declare @yjbz int            
set @yjbz= (select YJ_FLAG from JC_DEPT_PROPERTY where DEPT_ID=@execdept)--end            
declare @s1 varchar(8000)            
declare @s2 varchar(8000)            
set @s1='select null 序号,0 选择,a.blh 门诊号,a.fph 发票号,brxm 姓名,rtrim(pm) 项目名称,gg 规格,            
cast(dj as decimal(15,2)) 单价,cast(cast(sl as float) as varchar(30)) 数量,dw 单位,            
cast(je as decimal(15,2))  金额,a.sfrq 收费时间,dbo.fun_getdeptname(a.ksdm) 开单科室,dbo.fun_getempname(a.ysdm) 开单医生            
,dbo.fun_getdeptname(a.zxks) 默认执行科室,QRSJ 确认时间,dbo.fun_getempname(qrdjy) 确认人,dbo.fun_getdeptname(qrks) 确认科室,a.cfid,cfmxid,tcid,qrks qrksid   ,b.ZT   ,e.kh 卡号       
from mz_cfb a(NOLOCK)  inner join mz_cfb_mx b(NOLOCK)             
on a.cfid=b.cfid inner join mz_fpb c(NOLOCK) on a.fpid=c.fpid    
inner join mz_ghxx d (NOLOCK) on a.ghxxid = d.ghxxid 
inner join YY_KDJB e (NOLOCK) on d.kdjid = e.kdjid        
where  tcid=0  and xmly<>1  and c.bghpbz=0  '            
--只显示本执行的项目 onece007 2012-06-20 添加begin            
if @yjbz=1            
 set @s1=@s1+' and a.zxks='+cast(@execdept as varchar(50))--end            
if @blh<>''            
 set @s1=@s1+' and a.blh='''+@blh+''''            
if @brxxid<>dbo.FUN_GETEMPTYGUID()            
 set @s1=@s1+' and a.brxxid='''+cast(@brxxid  as varchar(100))+''''            
if @rqlx=0                
 set @s1=@s1+' and bqrbz=0 and a.sfrq>='''+@RQ1+''' and a.sfrq<='''+@rq2+''' and             
  (a.zxks='+cast(@execdept as varchar(20))+'  or a.zxks<=0 ) '            
else             
begin            
 if @rqlx=1            
 set @s1=@s1+' and bqrbz=1 and QRSJ>='''+@RQ1+''' and QRSJ<='''+@rq2+'''  and qrks='+cast(@execdept as varchar(20))            
 else             
    set @s1=@s1+' and bqrbz=1 and QRSJ>='''+@RQ1+''' and QRSJ<='''+@rq2+''' and qrks<>'+cast(@execdept as varchar(20))            
end             
IF @BRXM<>'' AND @BRXM LIKE '%[0-9a-zA-Z]%'            
    SET @S1=@S1+' AND ( C.BRXM like ''%'+CAST(@BRXM AS VARCHAR(30))+'%'' or dbo.GETPYWB(C.BRXM,0) like ''%'+@brxm+'%''  or  dbo.GETPYWB(C.BRXM,1) like ''%'+@brxm+'%'')'            
IF @BRXM<>'' AND @BRXM NOT LIKE '%[0-9a-zA-Z]%'        
 SET @s1 = @s1 + ' AND ( C.BRXM like ''%' + CAST(@BRXM AS VARCHAR(30)) + '%'')'         
IF @FPH<>''            
  set @s1=@s1+' and A.FPH='''+cast(@FPH  as varchar(30))+''''            
if @btf=1             
    set @s1=@s1+' and je<0 '            
set @s2='select null 序号,0 选择,a.blh 门诊号,a.fph 发票号,brxm 姓名,rtrim(item_name) 项目名称,null 规格,            
cast(cast(sum(je)/js as float) as decimal(15,2)) 单价,cast(cast(b.js as float) as varchar(30)) 数量,rtrim(item_unit) 单位,            
cast(sum(je) as decimal(15,2))  金额,a.sfrq 收费时间,dbo.fun_getdeptname(a.ksdm) 开单科室,dbo.fun_getempname(a.ysdm) 开单医生            
,dbo.fun_getdeptname(a.zxks) 默认执行科室,QRSJ 确认时间,dbo.fun_getempname(qrdjy) 确认人,dbo.fun_getdeptname(qrks) 确认科室,a.cfid,dbo.FUN_GETEMPTYGUID() cfmxid,tcid,qrks qrksid ,b.ZT ,f.kh 卡号               
from mz_cfb a(NOLOCK)  inner join mz_cfb_mx b (NOLOCK)            
on a.cfid=b.cfid inner join mz_fpb c(NOLOCK) on a.fpid=c.fpid left join jc_tc_t d(NOLOCK) on b.tcid=d.item_id   
inner join mz_ghxx e (NOLOCK) on a.ghxxid = e.ghxxid 
inner join YY_KDJB f (NOLOCK) on e.kdjid = f.kdjid              
where  tcid>0  and xmly<>1   '            
if @blh<>''            
 set @s2=@s2+' and a.blh='''+@blh+''''            
if @brxxid<>dbo.FUN_GETEMPTYGUID()            
 set @s2=@s2+' and a.brxxid='''+cast(@brxxid as varchar(100))+''''            
if @rqlx=0            
 set @s2=@s2+' and bqrbz=0 and a.sfrq>='''+@RQ1+''' and a.sfrq<='''+@rq2+''' and             
   (a.zxks='+cast(@execdept as varchar(20))+'  or a.zxks<=0 ) '            
else             
begin            
  if @rqlx=1            
 set @s2=@s2+' and bqrbz=1  and QRSJ>='''+@RQ1+''' and QRSJ<='''+@rq2+'''  and qrks='+cast(@execdept as varchar(20))            
  else             
    set @s2=@s2+' and bqrbz=1  and QRSJ>='''+@RQ1+''' and QRSJ<='''+@rq2+''' and qrks<>'+cast(@execdept as varchar(20))            
end         
IF @BRXM<>'' AND @BRXM LIKE '%[0-9a-zA-Z]%'            
    SET @S2=@S2+' AND ( C.BRXM like ''%'+CAST(@BRXM AS VARCHAR(30))+'%'' or dbo.GETPYWB(C.BRXM,0) like ''%'+@brxm+'%''  or  dbo.GETPYWB(C.BRXM,1) like ''%'+@brxm+'%'')'            
IF @BRXM<>'' AND @BRXM NOT LIKE '%[0-9a-zA-Z]%'        
 SET @S2 = @S2 + ' AND ( C.BRXM like ''%' + CAST(@BRXM AS VARCHAR(30)) + '%'')'            
--IF @BRXM<>''            
--  SET @S2=@S2+' AND ( C.BRXM like ''%'+CAST(@BRXM AS VARCHAR(30))+'%'' or  dbo.GETPYWB(C.BRXM,0)like ''%'+@brxm+'%''  or  dbo.GETPYWB(C.BRXM,1) like ''%'+@brxm+'%'')'            
IF @FPH<>''            
  set @s2=@s2+' and A.FPH='''+cast(@FPH  as varchar(30))+''''            
set @s2=@s2+' group by a.cfid,tcid,a.blh,a.fph,brxm,item_name,js,item_unit,a.ksdm,a.ysdm,a.zxks,a.sfrq,QRSJ,qrks,qrdjy ,b.ZT ,f.kh '            
            
if @btf=1            
  set @s2=@s2+' having sum(je)<0 '         
  PRINt(@s1+' union all '+@s2 +' order by 发票号 ')    
exec(@s1+' union all '+@s2 +' order by 发票号 ')            
declare @jyks varchar(50)            
declare @qfks varchar(50)            
set @jyks=(select config from jc_config where id=10005)            
set @qfks=(select config from jc_config where id=10004)            
if  PATINDEX('%'+rtrim(@execdept)+'%',@qfks)>0  and  (@blh<>'' or @brxxid<>dbo.FUN_GETEMPTYGUID() or @FPH<>'')            
begin            
DECLARE @LGBR VARCHAR(225)          
SET @LGBR = (SELECT CONFIG FROM dbo.JC_CONFIG WHERE id=10018)           
IF(@LGBR='0')          
begin          
  set @s1='            
   select '''' 序号,blh 门诊号,brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,            
   dbo.fun_zy_age(csrq,3,getdate()) 年龄,(case when item_alias='''' or item_alias is null then sqnr else item_alias end)  项目名称,sl 数量,dw 单位,je 金额    
   ,dbo.fun_getdeptname(zxks) 执行科室,SQRQ as 申请时间,a.BQSBZ,            
   (            
   CASE color.COLOR             
   WHEN ''red'' then ''红色''            
   WHEN ''brown'' then ''褐色''            
   WHEN ''blue'' then ''蓝色''            
   WHEN ''black'' then ''黑色''            
   WHEN ''purple'' then ''紫色''            
   WHEN ''green'' then ''绿色''            
   WHEN ''gray'' THEN ''灰色''              
   WHEN ''orange'' THEN ''橘红色''             
   WHEN ''yellow'' THEN ''黄色''             
   ELSE  color.COLOR  END            
   ) COLOR,              
   rtrim(d.name) AS 检验类型,        
   rtrim(isnull(case when rtrim(a.bbmc)='''' then null else  rtrim(a.bbmc) end,SAMP_NAME)) 标本,        
   isnull(cast(e.flid as varchar(100)),a.yjsqid) as 组号,txm 条码,  a.BBCJSJ as 标本采集时间, a.BBJJSJ as 标本交接时间,         
   (case when txm is null  then cast(1 as smallint) else cast(0 as smallint) end) 选择,yjsqid,a.brxxid,dbo.fun_getdeptname(sqks) 科室            
   from yj_mzsq  a inner join yy_brxx b on a.brxxid=b.brxxid             
   left join (select b.COLOR,a.YZXMID from JC_JYBBFLMX a inner join  JC_JYBBFL b on a.FLID = b.ID) color on a.yzxmid=color.yzxmid            
   left join (select a.*,b.SAMP_NAME from jc_assay a left join LS_AS_SAMPLE b on a.bbid=b.SAMP_code) c on a.yzxmid=c.yzid            
   left join jc_jcclassdiction d on c.hylxid=d.id             
   left join JC_JYBBFLMX e on a.yzxmid=e.yzxmid            
   left join jc_jyxm_bm F on a.yzxmid=f.hoitem_id and f.delete_bit=0           
   where zxks in( '+cast(@jyks as varchar(30)) +') and sfrq>='''+@rq1+''' and sfrq<='''+@rq2+''' and bsfbz=1 and bqxsfbz=0 and a.bscbz=0 '          
   if @blh<>''--and e.flid is not null            
  set @s1=@s1+' and blh='''+@blh+''''            
   if @BRXXID<>dbo.FUN_GETEMPTYGUID()            
  set @s1=@s1+' and b.brxxid='''+cast(@BRXXID as varchar(100))+''''            
   if @FPH<>''            
        set @s1=@s1+' and A.yzid in(select hjid from mz_cfb where fph='''+cast(@FPH  as varchar(30))+''')'            
   if @tmdybz=0            
  set @s1=@s1+' and txm is null '            
   else            
       set @s1=@s1+' and txm is not null '    
        PRINt(@s1+' order by b.brxxid,txm,e.flid,d.name,SAMP_NAME')        
   exec(@s1+' order by b.brxxid,txm,e.flid,d.name,SAMP_NAME')           
end            
ELSE           
BEGIN          
SET @s1='select DISTINCT * from (          
   select '''' 序号,blh 门诊号,brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,            
   dbo.fun_zy_age(csrq,3,getdate()) 年龄,(case when item_alias='''' or item_alias is null then sqnr else item_alias end)  项目名称,sl 数量,dw 单位,je 金额,dbo.fun_getdeptname(zxks) 执行科室,SQRQ as 申请时间,a.BQSBZ,            
   (            
   CASE color.COLOR             
   WHEN ''red'' then ''红色''            
   WHEN ''brown'' then ''褐色''            
   WHEN ''blue'' then ''蓝色''            
   WHEN ''black'' then ''黑色''            
   WHEN ''purple'' then ''紫色''            
   WHEN ''green'' then ''绿色''            
   WHEN ''gray'' THEN ''灰色''              
   WHEN ''orange'' THEN ''橘红色''             
   WHEN ''yellow'' THEN ''黄色''             
   ELSE  color.COLOR  END            
   ) COLOR,             
   rtrim(d.name) AS 检验类型,        
   rtrim(isnull(case when rtrim(a.bbmc)='''' then null else  rtrim(a.bbmc) end,SAMP_NAME)) 标本,      
   isnull(cast(e.flid as varchar(100)),a.yjsqid) as 组号,txm 条码,            
   (case when txm is null  then cast(1 as smallint) else cast(0 as smallint) end) 选择,yjsqid,a.brxxid,dbo.fun_getdeptname(sqks) 科室            
   from yj_mzsq  a inner join yy_brxx b on a.brxxid=b.brxxid             
   left join (select b.COLOR,a.YZXMID from JC_JYBBFLMX a inner join  JC_JYBBFL b on a.FLID = b.ID) color on a.yzxmid=color.yzxmid            
   left join (select a.*,b.SAMP_NAME from jc_assay a left join LS_AS_SAMPLE b on a.bbid=b.SAMP_code) c on a.yzxmid=c.yzid            
   left join jc_jcclassdiction d on c.hylxid=d.id             
   left join JC_JYBBFLMX e on a.yzxmid=e.yzxmid            
   left join jc_jyxm_bm F on a.yzxmid=f.hoitem_id and f.delete_bit=0           
   where zxks in( '+cast(@jyks as varchar(30)) +') and sfrq>='''+@rq1+''' and sfrq<='''+@rq2+''' and bsfbz=1 and bqxsfbz=0 and a.bscbz=0            
   union all           
   select '''' 序号,a.blh 门诊号,brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,            
   dbo.fun_zy_age(csrq,3,getdate()) 年龄,(case when item_alias='''' or item_alias is null then sqnr else item_alias end)  项目名称,sl 数量,dw 单位,je 金额,dbo.fun_getdeptname(zxks) 执行科室,SQRQ as 申请时间,a.BQSBZ,            
   (            
   CASE color.COLOR             
   WHEN ''red'' then ''红色''            
   WHEN ''brown'' then ''褐色''            
   WHEN ''blue'' then ''蓝色''            
   WHEN ''black'' then ''黑色''            
   WHEN ''purple'' then ''紫色''            
   WHEN ''green'' then ''绿色''            
   WHEN ''gray'' THEN ''灰色''              
   WHEN ''orange'' THEN ''橘红色''             
   WHEN ''yellow'' THEN ''黄色''             
   ELSE  color.COLOR  END            
   ) COLOR,             
   rtrim(d.name) AS 检验类型,        
   rtrim(isnull(case when rtrim(a.bbmc)='''' then null else  rtrim(a.bbmc) end,SAMP_NAME)) 标本,        
           
   isnull(cast(e.flid as varchar(100)),a.yjsqid) as 组号,txm 条码,            
   (case when txm is null  then cast(1 as smallint) else cast(0 as smallint) end) 选择,yjsqid,a.brxxid,dbo.fun_getdeptname(sqks) 科室            
   from yj_mzsq  a inner join yy_brxx b on a.brxxid=b.brxxid             
   left join (select b.COLOR,a.YZXMID from JC_JYBBFLMX a inner join  JC_JYBBFL b on a.FLID = b.ID) color on a.yzxmid=color.yzxmid            
   left join (select a.*,b.SAMP_NAME from jc_assay a left join LS_AS_SAMPLE b on a.bbid=b.SAMP_code) c on a.yzxmid=c.yzid            
   left join jc_jcclassdiction d on c.hylxid=d.id             
   left join JC_JYBBFLMX e on a.yzxmid=e.yzxmid            
   left join jc_jyxm_bm F on a.yzxmid=f.hoitem_id and f.delete_bit=0           
   INNER JOIN MZ_QUARTERS h ON a.GHXXID = h.GHXXID AND h.STATE=0          
   where zxks in( '+cast(@jyks as varchar(30)) +') and a.bscbz=0) aa where 1=1 '            
   if @blh<>''--and e.flid is not null            
  set @s1=@s1+' and 门诊号='''+@blh+''''            
   if @BRXXID<>dbo.FUN_GETEMPTYGUID()            
  set @s1=@s1+' and brxxid='''+cast(@BRXXID as varchar(100))+''''            
   if @FPH<>''            
        set @s1=@s1+' and yzid in(select hjid from mz_cfb where fph='''+cast(@FPH  as varchar(30))+''')'            
   if @tmdybz=0            
  set @s1=@s1+' and 条码 is null '            
   else            
        set @s1=@s1+' and 条码 is not null '           
     PRINT(@s1+' order by  brxxid,条码')        
   exec(@s1+' order by  brxxid,条码')              
 end          
             
end 