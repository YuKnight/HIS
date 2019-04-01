if exists (select * from sysobjects 
           where name = N'SP_YF_SELECT_MZCF_CX'
           and type = 'P')
   drop proc SP_YF_SELECT_MZCF_CX
go
  /*
  exec SP_YF_SELECT_MZCF_CX 'Fun_ts_yf_mzcfcx',424,'','','',2,'','',0,0,'2014/10/1 0:00:00','2014/10/2 23:59:59',0,1,'',1,0,0
  */
create PROCEDURE [dbo].[SP_YF_SELECT_MZCF_CX]  
 (  
  @functionName varchar(30),--构造函数  
 @deptid INTEGER,--药房代码  
 @blh varchar(50),--病历号  
 @hzxm varchar(12),--忠者姓名  
 @FPH varchar(50),    --发票号  
    @klx int,  
 @kh  varchar(50),  
    @zdmc varchar(50),   
    @je1 decimal(15,1),  
    @je2 decimal(15,1),  
 @QRRQ1 VARCHAR(30),--发药日期  
 @QRRQ2 VARCHAR(30),--发药日期  
 @QRCZYH INT,--发药操作员  
 @fybz smallint,--发药标志  
    @where varchar(500),  
 @bk int,  
    @ksdm int,  
    @ysdm int  
 )   
as  
begin  
    
 declare @table_fy varchar(100);  
 declare @table_fymx varchar(100);  
 declare @ssql varchar(8000);  
 declare @tlfl varchar(30)  
  
 SET @table_fy='vi_YF_FY';  
 SET @table_fymx='vi_YF_FYMX';   
IF @bk=1   
begin  
   SET @table_fy='vi_YF_FY';  
   SET @table_fymx='vi_YF_FYMX'  
end  
  
create table #TEMP  
(  
ID  UNIQUEIDENTIFIER,  
xh UNIQUEIDENTIFIER,  
binid UNIQUEIDENTIFIER,  
fph varchar(50),  
项目 varchar(50),   
zje decimal(15,1),  
jzje decimal(15,1),  
yhje decimal(15,1),  
zfje decimal(15,1),  
hzxm varchar(50),  
blh varchar(50),  
xb varchar(50),  
nl varchar(50),  
zdmc varchar(60),  
ksdm int,  
科室 varchar(50),  
ysdm int,  
医生 varchar(50),  
lrrq datetime,  
czyh int,  
录入员 varchar(20),  
sfrq datetime,  
sfczy int,  
收费员 varchar(20),  
qrrq datetime,  
qrczyh int,  
发药员  varchar(20),  
pyczyh int,  
配药员  varchar(20),  
cflx  varchar(10),  
jssjh  varchar(50),  
patid UNIQUEIDENTIFIER,  
pyckdm  varchar(10),  
fyckdm varchar(10),  
发药 varchar(20),  
煎药  varchar(20)  ,
处方号 varchar(100),
fpid varchar(100),
bz varchar(500),
bz2 varchar(100),
CSRQ datetime
)   
  
  
set @tlfl=(select config from jc_config where id=8017)  
  
set @ssql='insert into #temp(ID,xh,binid,fph,项目,zje,jzje,yhje,zfje,hzxm,blh,xb,nl,zdmc,ksdm,科室,ysdm,医生,lrrq,czyh,录入员,sfrq,sfczy,收费员,  
qrrq,qrczyh,发药员,pyczyh,配药员,cflx,jssjh,patid,pyckdm,fyckdm,发药,煎药,处方号,fpid,bz,bz2,csrq)  
select A.ID,cfxh,patid,a.fph ,coalesce(dbo.fun_gettjdxm(cflx),'''') 项目,a.zje ,a.jzje,a.yhje,a.zfje, hzxm ,patientno ,xb ,  
dbo.fun_zy_age(csrq,3,skrq) nl,b.zdmc ,a.ksdm ,coalesce(dbo.fun_getdeptname(a.ksdm),'''') 科室,a.ysdm,coalesce(dbo.fun_getempname(a.ysdm),'''') 医生,  
a.skrq,a.sky,'''' 录入员,a.skrq,a.sky, '''' 收费员,a.fyrq,a.fyr,dbo.fun_getempname(a.fyr) 发药员,pyr,dbo.fun_getempname(a.pyr) 配药员,cflx,a.jssjh,a.patid,  
coalesce(pyckh,'''') pyckdm,coalesce(fyckh,'''') fyckdm, ''√'' 发药,'''' 煎药   
,a.cfxh,a.cfxh
,null,null,null
from '+ RTRIM(@table_fy)+' a(nolock) left join MZYS_JZJL b on a.PATID=b.BRXXID and  a.YSDM=b.JSYSDM  and a.ghxh=b.ghxxid where jzcfbz=0 '  
  --inner join MZYS_JZJL->left join MZYS_JZJL  Modify by jchl
if @deptid>0  
  set @ssql=@ssql+' and a.deptid='+cast(@deptid as varchar(20))  
  
if @blh<>''  
     set @ssql=@ssql+' and a.patientno='''+cast(@blh as varchar(50))+''' ';  
  
if rtrim(@hzxm)<>''  
      set @ssql=@ssql+' and (A.hzxm like ''%'+@hzxm+'%'' or dbo.getpywb(A.hzxm,0)='''+@hzxm+'''  or dbo.getpywb(A.hzxm,1)='''+@hzxm+''' )';  
  
if @fph<>''  
     set @ssql=@ssql+' and A.fph='''+cast(@fph as varchar(30))+''' '  
  
if @klx>0 and @kh<>''  
      set @ssql=@ssql+' and A.ghxh in (select ghxxid from vi_mz_ghxx a,yy_kdjb b where a.brxxid=b.brxxid and b.klx='+cast(@klx as varchar(10))+' and kh='''+cast(@kh as varchar(40))+''')';  
     
if rtrim(@zdmc)<>''   
     set @ssql=@ssql+' and b.zdmc like ''%'+@zdmc+'%''';  
  
if @je1>0  
     set @ssql=@ssql+' and zje>='+cast(@je1 as varchar(20))+' ';  
if @je2>0  
     set @ssql=@ssql+' and zje<='+cast(@je2 as varchar(20))+' ';  
     
if rtrim(@QRRQ1)<>''   
     set @ssql=@ssql+'  and a.fyrq>='''+@QRRQ1+''' and a.fyrq<='''+@QRRQ2+'''';  
  
if @QRCZYH<>0   
     set @ssql=@ssql+' and a.fyr='+cast(@QRCZYH as char(12))+' ';  
  
if @ksdm<>0   
     set @ssql=@ssql+' and a.ksdm='+cast(@ksdm as char(12))+' ';  
  
if @ysdm<>0   
     set @ssql=@ssql+' and a.ysdm='+cast(@ysdm as char(12))+' ';  
  
--set @ssql=@ssql+' order by a.fph';  
--set @ssql=@ssql+' and a.ksdm not in (50,56,138)';  
     
exec(@ssql)  
  
print @ssql  
  
set @ssql='select ''0'' 序号, 发药,  
psbz 皮试,  
a.fph 发票号, 项目,cast(zje as float) 总金额,hzxm 姓名,s_ypjx 剂型,yphh 货号,c.s_yppm+isnull(ypspmbz,'''') 品名,b.ypspm 商品名,  
b.ypgg 规格,ypcj 厂家,b.lsj 单价,0 库存,cast(ypsl as float) 用量,cfts 剂数,b.ypdw 单位,cast(round(lsje,3) as float)金额,  
(case when lsje>0 then yf+'' ''+cast((case when Isnumeric(jl)=0 then  '''' else cast(jl as float) end) as varchar(100))+coalesce(jldw,'''')+''/次  ''+pc else '''' end) 使用方法,  
blh 门诊号,xb 性别,coalesce(nl,'''') 年龄,coalesce(zdmc,'''') 诊断,科室, 医生,煎药,yf 用法,  
pc 频次,(case when jl='''' then ''0'' else jl end) 剂量,jldw 剂量单位,ts 天数,  
zbz 组标志,pxxh 排序序号,  
lrrq 录入日期, 录入员,sfrq 收费日期, 收费员,qrrq 发药日期,  发药员, 配药员,a.id 处方号, a.cflx,a.jssjh,b.cfxh,   
patid,ksdm,ysdm,coalesce(sfczy,0) sfczy,coalesce(qrczyh,0) qrczyh ,coalesce(pyczyh,0) pyczyh ,coalesce(pyckdm,'''') 配药窗口,coalesce(fyckdm,'''') 发药窗口,a.jzje 记帐金额,a.yhje 优惠金额,a.zfje 自付金额,b.cjid as ypid,ydwbl,cfmxid,b.zt 嘱托,  
b.pfj 批发价,cast(round(pfje,3) as decimal(15,3)) 批发金额,  
(select RTRIM(cast(execnum as char(10)))+''次/''+RTRIM(cast(cycleday as char(10)))+''天'' from JC_FREQUENCY where name=pc ) 使用频次,  
zje,  
cast(cast(hlxs as float) as varchar(30))+dbo.fun_yp_ypdw(hldw)+''*''+cast(cast((ypsl/ydwbl)*bzsl as float) as varchar(20))+dbo.fun_yp_ypdw(bzdw) 单位规格,  
(case when c.tlfl in '+@tlfl+' then 1 else 0 end) zsyp 
,s_ypjx 剂型,fpid,jssjh 发票流水号
,a.bz 中药备注,bz2 备注2,jsypfl 备注3
from #temp a inner join '+RTRIM(@table_fymx)+' b(nolock) on a.ID=b.fyid   
inner join vi_yp_ypcd c (nolock) on b.cjid=c.cjid  where c.cjid>0 '  
--if @where<>''  
--   set @ssql=@ssql+' and  ('+@where +')'  
  
if @where<>''  
   set @ssql=@ssql+' and a.id in(select fyid from #temp a  
   inner join '+RTRIM(@table_fymx)+' b(nolock) on a.ID=b.fyid   
   inner join vi_yp_ypcd c (nolock) on b.cjid=c.cjid  and ( '+@where+')) '    
  
--set @ssql=@ssql+' order by a.fph,a.id,pxxh'  
set @ssql=@ssql+' order by 科室,hzxm'  
  
  
print @ssql  
EXEC (@SSQL)  
  
  
  
  
end  
  
  
  