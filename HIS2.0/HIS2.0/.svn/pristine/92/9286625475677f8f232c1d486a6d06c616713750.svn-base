IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YF_SELECT_MZCF]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YF_SELECT_MZCF]
GO
CREATE PROCEDURE [dbo].[SP_YF_SELECT_MZCF]      
 (      
  @functionName varchar(30),--构造函数      
 @deptid INTEGER,--药房代码      
 @ghxh UNIQUEIDENTIFIER,  --挂号序号      
 @hzxm varchar(12),--忠者姓名      
 @FPH varchar(50),    --发票号      
 @jssjh decimal(21),--结算收据号      
 @QRRQ1 VARCHAR(30),--发药日期      
 @QRRQ2 VARCHAR(30),--发药日期      
 @QRCZYH INT,--发药操作员      
 @fybz smallint,--发药标志      
 @FYCKH VARCHAR(10),--发药窗口号      
 @SFRQ1 VARCHAR(30),--收费日期      
 @SFRQ2 VARCHAR(30),--收费日期      
 @SFCZY INT,--收费操作员      
 @PYRQ1 VARCHAR(30),--配药日期      
 @PYRQ2 VARCHAR(30),--配药日期      
 @PYCZYH INT,--配药操作员      
 @PYBZ INT,--配药标志      
 @PYCKH varchar(10),--配药窗口      
 @LRRQ1 VARCHAR(30),--录入日期1        
 @LRRQ2 VARCHAR(30),--录入日期2      
 @LRCZYH INT,--录入操作员号,      
 @yblx char(4), --医保类型,      
 @bk int,      
    @fpid UNIQUEIDENTIFIER,      
    @brxxid UNIQUEIDENTIFIER      
 )       
as      
begin      
        
 declare @table_mzcfk varchar(100);      
 declare @table_mzcfmxk varchar(100);      
 declare @table_ghzdk varchar(100);      
 declare @table_brxxk varchar(100);      
 declare @table_hjcfk varchar(100);      
 declare @table_fpb varchar(100);      
 declare @tlfl varchar(30)      
      
 declare @ssql varchar(8000);      
      
 SET @table_mzcfk='MZ_CFB';      
 SET @table_mzcfmxk='MZ_CFB_MX';       
 set @table_ghzdk='VI_MZ_GHXX'      
 set @table_brxxk='YY_BRXX'      
 set @table_hjcfk='MZ_HJB'      
 set @table_fpb='MZ_FPB'      
IF @bk=1       
begin      
   SET @table_mzcfk='MZ_CFB_h';      
   SET @table_mzcfmxk='MZ_CFB_MX_h'      
   set @table_ghzdk='MZ_GHXX_h'      
   set @table_brxxk='YY_BRXX'      
   set @table_hjcfk='MZ_HJB_H'      
   set @table_fpb='MZ_FPB_H'      
end      
      
      
create table #TEMP      
(      
--ID INTEGER IDENTITY (1, 1) NOT NULL ,      
xh UNIQUEIDENTIFIER,      
binid UNIQUEIDENTIFIER,      
fph varchar(60),      
项目 varchar(50),       
zje decimal(15,1),      
jzje decimal(15,1),      
yhje decimal(15,1),      
zfje decimal(15,1),      
hzxm varchar(50),      
blh varchar(50),      
xb varchar(50),      
nl varchar(50),      
zdmc varchar(200),      
ksdm int,      
科室 varchar(50),      
ysdm int,      
医生 varchar(50),      
lrrq datetime,      
czyh int,      
录入员 varchar(30),      
sfrq datetime,      
sfczy int,      
收费员 varchar(30),      
qrrq datetime,      
qrczyh int,      
发药员  varchar(30),      
pyczyh int,      
配药员  varchar(20),      
cflx  varchar(20),      
jssjh  varchar(100),      
patid UNIQUEIDENTIFIER,      
pyckdm  varchar(20),      
fyckdm varchar(20),      
发药 varchar(20),      
煎药  varchar(20),      
处方号 varchar(100),      
fpid varchar(100),      
bz varchar(500),      
bz2 varchar(100),      
CSRQ datetime,  
byscf int       
)       
      
set @tlfl=(select config from jc_config where id=8017)      
      
set @ssql='insert into #temp(xh,binid,fph,项目,zje,jzje,yhje,zfje,hzxm,blh,xb,nl,zdmc,ksdm,科室,ysdm,医生,lrrq,czyh,录入员,sfrq,sfczy,收费员,      
qrrq,qrczyh,发药员,pyczyh,配药员,cflx,jssjh,patid,pyckdm,fyckdm,发药,煎药,处方号,fpid,bz,byscf,bz2,csrq)      
select a.CFID,a.GHXXID,a.fph ,'''' 项目,a.zje ,0,0,0, C.BRXM ,a.blh ,dbo.FUN_ZY_SEEKSEXNAME(xb) xb ,      
dbo.fun_zy_age(csrq,3,a.SFRQ) nl,b.zdmc ,a.KSDM ,KSMC 科室,a.ysdm,YSXM 医生,      
a.HJRQ,a.HJY,HJYXM 录入员,a.sfrq,a.SFY,SFYXM 记费员,a.FYRQ,a.FYR,FYRXM 发药员,pyR,PYRXM 配药员,'''' cflx,a.dnlsh,A.ghxxid patid,      
coalesce(PYCK,'''') pyckdm,coalesce(fyck,'''') fyckdm,(case when a.Bfybz=0 then '''' else ''√'' end) 发药,'''' 煎药 ,a.hjid,a.fpid      
,d.bz,d.byscf,(case when e.yblx>0 then dbo.fun_getYblxmc(e.yblx) else ''自费'' end) bz2,csrq from '+rtrim(@table_mzcfk)+' a       
inner join '+rtrim(@table_ghzdk)+' B on a.ghxxid=B.ghxxid        
inner join '+rtrim(@table_brxxk)+' C on B.BRXXID=C.BRxxid       
inner join '+rtrim(@table_HJCFK)+' D on A.HJID=D.HJID       
inner join '+RTRIM(@table_fpb)+' E ON A.FPID=E.FPID       
WHERE a.XMLY=1 AND A.bsfbz=1 and A.bscbz=0 '      
      
if @fpid<>dbo.FUN_GETEMPTYGUID()      
     set @ssql=@ssql+' and A.fpid='''+cast(@fpid as varchar(100))+'''';      
if @brxxid<>dbo.FUN_GETEMPTYGUID()      
     set @ssql=@ssql+' and A.brxxid='''+cast(@brxxid as varchar(100))+''' ';      
      
if @ghxh<>dbo.FUN_GETEMPTYGUID()       
     set @ssql=@ssql+' and A.ghxxid='''+cast(@ghxh as varchar(200))+''' ';      
      
if rtrim(@hzxm)<>''      
      set @ssql=@ssql+' and (c.brxm like ''%'+@hzxm+'%'' or c.pym='''+@hzxm+''' or c.pym='''+@hzxm+''' )';      
      
if len(@fph)>=1 or @jssjh>0      
     set @ssql=@ssql+' and A.fph='''+cast(@fph as varchar(50))+''''--+' and a.zxks='+cast(@deptid as varchar(12))+' '      
else      
     set @ssql=@ssql+' and a.zxks='+cast(@deptid as varchar(12))+' '      
         
      
if @jssjh<>0       
      set @ssql=@ssql+' and A.dnlsh='+cast(@jssjh as varchar(40))+'';      
         
if rtrim(@PYRQ1)<>''       
     set @ssql=@ssql+' and pyrq>='''+rtrim(@PYRQ1)+''' and pyrq<='''+@PYRQ2+'''';      
      
if @pyczyh<>0       
     set @ssql=@ssql+' and pyr='+cast(@pyczyh as char(12))+' ';      
      
if @pybz=1       
     set @ssql=@ssql+' and bpybz='+cast(@pybz as char(12))+' ';      
        
if rtrim(@PYCKH)<>''       
      set @ssql=@ssql+' and pyck='''+cast(@PYCKH as char(10))+'''';      
         
if rtrim(@sfRQ1)<>''       
     set @ssql=@ssql+' and a.sfrq>='''+@sfRQ1+' 00:00:00'' and a.sfrq<='''+@sfRQ2+' 23:59:59''';      
         
if @sfczy<>0       
      set @ssql=@ssql+' and sfy='+cast(@sfczy as char(12))+' ';      
         
if rtrim(@QRRQ1)<>'' and @fybz=1       
     set @ssql=@ssql+'  and a.fyrq>='''+@QRRQ1+' 00:00:00'' and a.fyrq<='''+@QRRQ2+' 23:59:59''';      
      
if @fybz=0      
     set @ssql=@ssql+' and a.bfybz='+cast(@fybz as varchar(10))      
      
if @QRCZYH<>0       
     set @ssql=@ssql+' and a.fyr='+cast(@QRCZYH as char(12))+' ';      
      
if @fybz=1       
     set @ssql=@ssql+' and a.bfybz='+cast(@fybz as char(12))+' ';      
      
      
if rtrim(@fYCKH)<>''       
      set @ssql=@ssql+' and fyck='''+cast(@fYCKH as char(10))+'''';      
         
if @lrczyh<>0       
      set @ssql=@ssql+' and a.hjy='+cast(@lrczyh as char(12))+' ';      
         
if rtrim(@LRRQ1)<>''       
begin      
      set @ssql=@ssql+' and a.hjrq>='''+@LRRQ1+' 00:00:00'' and a.hjrq<='''+@LRRQ2+' 23:59:59''';      
      set @ssql=@ssql+' order by a.hjrq';      
end      
else      
      set @ssql=@ssql+' order by a.fph';      
      
      
print @ssql      
exec(@ssql)      
      
      
      
set @ssql='select ''0'' 序号,jsd as 警示灯, 发药,      
(case when bpsbz=0 then ''皮试'' when Bpsbz=1 then ''【-】'' when bpsbz=2 then ''【+】'' when bpsbz=3 then ''【免试】'' else '''' end) 皮试,      
fph 发票号, 项目,zje 总金额,hzxm 姓名,s_ypjx 剂型,BM 货号,
case when d.gwypjb=1 
then ''【高危】''+b.pm+isnull(ypspmbz,'''') 
else b.pm+isnull(ypspmbz,'''') end as 品名,
d.ypspm 商品名,d.bz as tsyf,        
GG 规格,CJ 厂家,cast(b.DJ as float) 单价,cast(cast(kcl as float) as varchar(50))+dbo.fun_yp_ypdw(zxdw) 库存,      
(case when (d.tlfl=''03'' and '+cast(@deptid as varchar(20))+' not in (378,841) and YFMC in(''iv drip'',''H'',''iv'',''im'',''皮下注射'',''iv pump'',''静脉泵入'')) or b.xmid=6902  then 0 else cast(b.SL as float) end) 用量,b.JS 剂数,b.DW 单位,    
(case when (d.tlfl=''03'' and '+cast(@deptid as varchar(20))+' not in (378,841) and YFMC in(''iv drip'',''H'',''iv'',''im'',''皮下注射'',''iv pump'',''静脉泵入''))   or b.xmid=6902  then 0 else cast(round(JE,3) as float) end) 金额,      
blh 门诊号,xb 性别,coalesce(nl,'''') 年龄,coalesce(zdmc,'''') 诊断,科室, 医生,煎药,YFMC 用法,      
coalesce(dbo.Fun_getFreqName(cast(coalesce(PCID,0) as smallint)),'''') 频次,      
coalesce(YL,0) 剂量,coalesce(YLdw,'''') 剂量单位,coalesce(b.ts,0) 天数,      
fzxh 组标志,pxxh 排序序号,lrrq 录入日期, 录入员,      
sfrq 收费日期, 收费员 as 记费员,qrrq 发药日期,  发药员, 配药员, 处方号,tjdxmdm cflx,jssjh,B.CFID cfxh,       
patid,ksdm,ysdm,coalesce(sfczy,0) sfczy,      
coalesce(qrczyh,0) qrczyh ,coalesce(pyczyh,0) pyczyh ,      
coalesce(pyckdm,'''') 配药窗口,coalesce(fyckdm,'''') 发药窗口,      
0 记帐金额,0 优惠金额,0 自付金额,B.XMID ypid,b.YDWBL,cfmxid,B.ZT 嘱托,      
b.pfj  批发价, b.pfje 批发金额,dbo.fun_getcfyf(cast(coalesce(PCID,0) as int)) 使用频次,      
'''' 单位规格,(case when d.tlfl in '+@tlfl+' then 1 else 0 end) zsyp,      
s_ypjx 剂型,fpid,jssjh 发票流水号      
,a.bz 中药备注,bz2 备注2,jsypfl 备注3,      
b.tyid,isnull(c.dwbl,1) dwbl      
  ,
  (case when (d.tlfl=''03'' and '+cast(@deptid as varchar(20))+' not in (378,841) and YFMC in(''iv drip'',''H'',''iv'',''im'',''皮下注射'',''iv pump'',''静脉泵入'') )  or b.xmid=6902 then 0 else isnull(b.sl*b.js*c.dwbl/b.ydwbl,0) end) ypsl,
  f.hwmc as hwmc,a.byscf,b.SL/b.YDWBL*b.JS*d.bzsl*d.HLXS 剂量单位数量        
  from #temp a inner join '+RTRIM(@table_mzcfmxk)+' b on a.XH=b.CFID       
 left join yf_kcmx c on b.xmid=c.cjid and c.deptid='+cast(@deptid as varchar(20))+'      
 inner join vi_yp_ypcd d on b.xmid=d.cjid  left join YP_HWSZ f on d.ggid=f.ggid and f.deptid='+cast(@deptid as varchar(20))+'   
order by a.fph,处方号,pxxh      
'      
--Modify By Tany 2014-07-21 花桥的大输液按照正常药品发送
--Modify By Tany 2016-01-11 增加便民药房大输液正常发送
-- inner join vi_yp_ypcd c on b.xmid=c.cjid      
print @ssql      
EXEC (@SSQL)      
      
      
      
end 




GO


