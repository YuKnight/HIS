IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_SELECT_CGJH' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_SELECT_CGJH
GO

CREATE PROCEDURE SP_YP_SELECT_CGJH
 (
 	@ORDER VARCHAR(100),
 	@DEPTID INT,
 	@KCTABLE VARCHAR(30),
 	@JSLX INT,
 	@WHERE VARCHAR(8000)
 ) 
as
begin
  
declare @dept_jgbm int
select @dept_jgbm=JGBM from JC_DEPT_PROPERTY where DEPT_ID=@DEPTID
if @dept_jgbm=null set @dept_jgbm=-1

declare @ssql varchar(8000);
create table #TEMP(CJID INT,YPSL DECIMAL(15,3)) 
--上期会计年份和月份
declare @year INTEGER 
declare	@month integer
declare @sqyear int;
declare @sqmonth int;

set @year=YEAR(getdate())
set @month=month(getdate())
set @sqyear=@year;
set @sqmonth=@month-1;
if @month=1 
begin
  set @sqyear=@sqyear-1;
  set @sqmonth=12;
end 


IF ltrim(rtrim(@KCTABLE))='yf_kcmx'
  INSERT INTO #TEMP(CJID,YPSL)
  SELECT CJID,round(SUM(ypsl/ydwbl),3) FROM YF_DJ A,YF_DJMX B
  WHERE A.ID=B.DJID AND A.YWLX IN('014','017','018','020','021','022','023','025','026') AND SHBZ=1
  and YEAR(shrq)=@sqyear and MONTH(shrq)=@sqmonth and A.DEPTID=@DEPTID group by CJID
else
  INSERT INTO #TEMP(CJID,YPSL)
  SELECT CJID,round(SUM(ypsl/ydwbl),3) FROM YF_DJ A,YF_DJMX B
  WHERE A.ID=B.DJID AND A.YWLX IN('014','017','018','020','021','022','023','025','026') AND SHBZ=1
  and YEAR(shrq)=@sqyear and MONTH(shrq)=@sqmonth  group by CJID --and A.DEPTID=@DEPTID
  --INSERT INTO #TEMP(CJID,YPSL)
  --SELECT CJID,round(SUM(ypsl/ydwbl),3) FROM YK_DJ A,Yk_DJMX B
  --WHERE A.ID=B.DJID AND A.YWLX IN('003','004','014','017','018','020','022','030') AND SHBZ=1
  --and YEAR(shrq)=@sqyear and MONTH(shrq)=@sqmonth group by CJID
  
declare @s varchar(30)
IF EXISTS (select * from JC_CONFIG where ID=8039 and CONFIG='1')
  set @s=' a.ghdw '
else
  set @s=' b.mrghdw '
    
if @JSLX=0
	--低于下限以上限为计划数
    SET @ssql = 'select 0 序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,s_sccj 厂家,
         pfj 批发价,lsj 零售价,zkc 全院库存,fykc 本院库存,cast(round(a.kcl/a.dwbl,2) as float) 库存数,
         cast(kcsx  as float) 需求数,cast(ypsl as float) 上月用量,cast(kcsx  as float) 计划数,dbo.fun_yp_ypdw(b.ypdw) 单位,
         cast(a.scjj as float) 参考进价,dbo.fun_yp_ghdw('+@s+') 进货单位,cast(mrjj as float) 默认进价,'+@s+' 进货单位id,b.shh 货号,
         1 ydwbl,a.cjid,dbo.FUN_GETEMPTYGUID() id,dbo.fun_yp_ylfl(ylfl) 药理分类, (case when gjjbyw=1 then ''√'' else '''' end) 基本药物,hwmc 货位名称 from '+ 
         @KCTABLE+' a inner join vi_yp_ypcd b on a.cjid=b.cjid inner join yp_kcsxx c 
         on b.cjid=c.cjid and c.deptid='+CAST(@DEPTID AS VARCHAR(30))+'
          left join yp_ypjx d on b.ypjx=d.id 
          left join YP_HWSZ X on a.ggid=x.ggid and a.deptid=x.deptid
          inner join (select cjid,cast(round(sum(kcl/dwbl),2) as float) zkc,cast(round(sum(case when '+cast(@dept_jgbm as varchar(20))+'=b.jgbm then kcl/dwbl else 0 end),2) as float) fykc from vi_yp_kcmx a,jc_dept_property b where a.deptid=b.dept_id group by cjid) 
          e on a.cjid=e.cjid 
          left join #temp f on a.cjid=f.cjid  where  
         a.deptid='+CAST(@DEPTID AS VARCHAR(30))+' and (kcxx*(a.dwbl/ydwbl)-a.kcl)>=0 and
          kcxx<>0 and kcsx<>0 and cjbdelete=0 and a.bdelete=0 '  
else
     --以上限和库存差值为计划数
     SET @ssql = 'select 0 序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,s_sccj 厂家,
         pfj 批发价,lsj 零售价,zkc 全院库存,fykc 本院库存,cast(round(a.kcl/a.dwbl,3) as float) 库存数,
         cast(round((kcsx/ydwbl-round(a.kcl/a.dwbl,3)),3) as float) 需求数,
         cast(ypsl as float) 上月用量,
        (case when STATITEM_CODE=''03'' then cast(round((kcsx/ydwbl-round(a.kcl/a.dwbl,3)),3) AS float) else dbo.getint( (kcsx/ydwbl-round(a.kcl/a.dwbl,3)),1) end) 计划数,dbo.fun_yp_ypdw(b.ypdw) 单位,
         cast(a.scjj as float) 参考进价,dbo.fun_yp_ghdw('+@s+') 进货单位,cast(mrjj as float) 默认进价,'+@s+' 进货单位id,b.shh 货号,
         1 ydwbl,a.cjid,dbo.FUN_GETEMPTYGUID() id,dbo.fun_yp_ylfl(ylfl) 药理分类,(case when gjjbyw=1 then ''√'' else '''' end) 基本药物,hwmc 货位名称 from '+
         @KCTABLE+' a inner join vi_yp_ypcd b on a.cjid=b.cjid inner join yp_kcsxx c 
         on b.cjid=c.cjid and c.deptid='+CAST(@DEPTID AS VARCHAR(30))+' 
         left join yp_ypjx d on b.ypjx=d.id 
         left join YP_HWSZ X on a.ggid=x.ggid and a.deptid=x.deptid
         inner join (select cjid,cast(round(sum(kcl/dwbl),2) as float) zkc,cast(round(sum(case when '+cast(@dept_jgbm as varchar(20))+'=b.jgbm then kcl/dwbl else 0 end),2) as float) fykc from vi_yp_kcmx a,jc_dept_property b where a.deptid=b.dept_id group by cjid ) 
         e on a.cjid=e.cjid 
         left join #temp f on a.cjid=f.cjid where  
         a.deptid='+CAST(@DEPTID AS VARCHAR(30))+' and (kcsx*(a.dwbl/ydwbl)-a.kcl)>0 and kcsx<>0  and cjbdelete=0 and a.bdelete=0  '
 if @WHERE<>'' 
     set @ssql=@ssql+'  '+@WHERE
set @ssql=@ssql+@ORDER;
print @ssql
exec (@ssql)


end



