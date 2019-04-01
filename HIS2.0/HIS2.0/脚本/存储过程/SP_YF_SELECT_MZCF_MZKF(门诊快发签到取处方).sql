IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_SELECT_MZCF_MZKF' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_SELECT_MZCF_MZKF
GO
create PROCEDURE [dbo].[SP_YF_SELECT_MZCF_MZKF]        
 (        
 -- @functionName varchar(30),--构造函数        
 --@deptid INTEGER,--药房代码        
 --@ghxh UNIQUEIDENTIFIER,  --挂号序号        
 --@hzxm varchar(12),--忠者姓名        
 --@FPH varchar(50),    --发票号        
 --@jssjh decimal(21),--结算收据号        
 --@QRRQ1 VARCHAR(30),--发药日期        
 --@QRRQ2 VARCHAR(30),--发药日期        
 --@QRCZYH INT,--发药操作员        
 --@fybz smallint,--发药标志        
 --@FYCKH VARCHAR(10),--发药窗口号        
 --@SFRQ1 VARCHAR(30),--收费日期        
 --@SFRQ2 VARCHAR(30),--收费日期        
 --@SFCZY INT,--收费操作员        
 --@PYRQ1 VARCHAR(30),--配药日期        
 --@PYRQ2 VARCHAR(30),--配药日期        
 --@PYCZYH INT,--配药操作员        
 --@PYBZ INT,--配药标志        
 --@PYCKH varchar(10),--配药窗口        
 --@LRRQ1 VARCHAR(30),--录入日期1          
 --@LRRQ2 VARCHAR(30),--录入日期2        
 --@LRCZYH INT,--录入操作员号,        
 --@yblx char(4), --医保类型,        
 --@bk int,        
 --@fpid UNIQUEIDENTIFIER,   
 @KH VARCHAR(30)     
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
 declare @brxxid UNIQUEIDENTIFIER;          
 declare @ssql varchar(8000);        
        
 SET @table_mzcfk='MZ_CFB';        
 SET @table_mzcfmxk='MZ_CFB_MX';         
 set @table_ghzdk='MZ_GHXX'        
 set @table_brxxk='YY_BRXX'        
 set @table_hjcfk='MZ_HJB'        
 set @table_fpb='MZ_FPB'        
       
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
zxks varchar(30),       
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
patid varchar(50),        
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
set @brxxid=(select top 1 BRXXID from YY_KDJB where ZFBZ=0  and KH=@KH)       
set @tlfl=(select config from jc_config where id=8017)        
        
set @ssql='insert into #temp(xh,binid,fph,项目,zje,jzje,yhje,zfje,hzxm,blh,xb,nl,zxks,zdmc,ksdm,科室,ysdm,医生,lrrq,czyh,录入员,sfrq,sfczy,收费员,        
qrrq,qrczyh,发药员,pyczyh,配药员,cflx,jssjh,patid,pyckdm,fyckdm,发药,煎药,处方号,fpid,bz,byscf,bz2,csrq)        
select a.CFID,a.GHXXID,a.fph ,'''' 项目,a.zje ,0,0,0, C.BRXM ,a.blh ,dbo.FUN_ZY_SEEKSEXNAME(xb) xb ,        
dbo.fun_zy_age(csrq,3,a.SFRQ) nl,a.zxks,b.zdmc ,a.KSDM ,KSMC 科室,a.ysdm,YSXM 医生,        
a.HJRQ,a.HJY,HJYXM 录入员,a.sfrq,a.SFY,SFYXM 记费员,a.FYRQ,a.FYR,FYRXM 发药员,pyR,PYRXM 配药员,'''' cflx,a.dnlsh,a.blh patid,        
coalesce(PYCK,'''') pyckdm,coalesce(fyck,'''') fyckdm,(case when a.Bfybz=0 then '''' else ''√'' end) 发药,'''' 煎药 ,a.hjid,a.fpid        
,d.bz,d.byscf,(case when e.yblx>0 then dbo.fun_getYblxmc(e.yblx) else ''自费'' end) bz2,csrq 
from '+rtrim(@table_mzcfk)+' a         
inner join '+rtrim(@table_ghzdk)+' B on a.ghxxid=B.ghxxid       
inner join '+rtrim(@table_brxxk)+' C on B.BRXXID=C.BRxxid         
inner join '+rtrim(@table_HJCFK)+' D on A.HJID=D.HJID         
inner join '+RTRIM(@table_fpb)+' E ON A.FPID=E.FPID         
WHERE a.XMLY=1 AND A.bsfbz=1 and A.bscbz=0 '        
        
     
if @brxxid is null
set @brxxid=dbo.FUN_GETEMPTYGUID()        
     set @ssql=@ssql+' and A.brxxid='''+cast(@brxxid as varchar(100))+''' ';        
     --set @ssql=@ssql+' and a.bfybz=0 and a.sfrq>=''2014-7-22 00:00:00'' and a.sfrq<=''2014-7-22 23:59:59'''  
     set @ssql=@ssql+' and a.bfybz=0 '  
     --set @ssql=@ssql+' and a.sfrq>='''+CONVERT(nvarchar(10),GETDATE(),120)+' 00:00:00'' and a.sfrq<='''+CONVERT(nvarchar(10),GETDATE(),120)+' 23:59:59''';   
      
print @ssql        
exec(@ssql)        
        
        
        
set @ssql='select ''0'' 序号,jsd as 警示灯, 发药,        
(case when bpsbz=0 then ''皮试'' when Bpsbz=1 then ''【-】'' when bpsbz=2 then ''【+】'' when bpsbz=3 then ''【免试】'' else '''' end) 皮试,        
fph 发票号, 项目,zje 总金额,hzxm 姓名,s_ypjx 剂型,BM 货号,b.pm+isnull(ypspmbz,'''') 品名,SPM 商品名,        
GG 规格,CJ 厂家,cast(b.DJ as float) 单价,cast(cast(kcl as float) as varchar(50))+dbo.fun_yp_ypdw(zxdw) 库存,        
(case when (d.tlfl=''03'' and  a.zxks not in (378,207) and YFMC in(''iv drip'',''H'',''iv'',''im'',''皮下注射'',''iv pump'')) or b.xmid=6902  then 0 else cast(b.SL as float) end) 用量,b.JS 剂数,b.DW 单位,      
(case when (d.tlfl=''03'' and a.zxks not in (378,207) and YFMC in(''iv drip'',''H'',''iv'',''im'',''皮下注射'',''iv pump''))   or b.xmid=6902  then 0 else cast(round(JE,3) as float) end) 金额,        
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
b.tyid,isnull(c.dwbl,1) dwbl ,  
  (case when (d.tlfl=''03'' and a.zxks not in (378,207) and YFMC in(''iv drip'',''H'',''iv'',''im'',''皮下注射'',''iv pump'') )  or b.xmid=6902 then 0 else isnull(b.sl*b.js*c.dwbl/b.ydwbl,0) end) ypsl,  
  a.hzxm as hzxm,a.byscf ,zxks           
  from #temp a inner join '+RTRIM(@table_mzcfmxk)+' b on a.XH=b.CFID         
 left join yf_kcmx c on b.xmid=c.cjid  and c.deptid=a.zxks        
 inner join vi_yp_ypcd d on b.xmid=d.cjid     
order by a.fph,处方号,pxxh '        
-- inner join vi_yp_ypcd c on b.xmid=c.cjid        
print @ssql        
EXEC (@SSQL)        
        
        
        
end 