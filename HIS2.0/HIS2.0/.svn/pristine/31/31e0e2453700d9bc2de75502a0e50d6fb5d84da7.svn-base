IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_CFPD_SELECTCF' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_CFPD_SELECTCF
GO

  
CREATE PROCEDURE SP_YP_CFPD_SELECTCF 
 (    
 @execdept int,--执行科室  
 @zdmc varchar(30),--诊断名称
 @KDKS VARCHAR(1000),--开方科室
 @KDYS VARCHAR(1000),--开方医生
 @FUNNAME VARCHAR(30),--
 @CFRQ1 VARCHAR(30),--处方日期
 @CFRQ2 VARCHAR(30),
 @SHBZ INT,--审核标志
 @jgbm bigint --机构编码
 )   
as  
/*-------------  
查找处方  
-------------*/  

declare @ss varchar(8000)

--验证门诊数据转移天数
declare @ts int
declare @table varchar(30)
declare @table1 varchar(30)
set @table='mz_hjb'
set @table1='mz_hjb_mx'
set @ts=(select cast(config as int) from jc_config where id=13)
if DATEADD(DD,-1*@ts,getdate())>@CFRQ1
begin
  set @table='vi_mz_hjb'
  set @table1='vi_mz_hjb_mx'
end



set @ss=' select '''' 序号,1 选择 , '''' 组,zdmc 诊断名称,'''' 开嘱时间, yzmc+''  ''+gg as 医嘱内容,
cast(cast(cast(yl as float) as varchar(30))+rtrim(yldw) as varchar(15)) as 用量,
rtrim(pcmc)  频次 ,yfmc 用法,cast(ts as float) 天数,zt 嘱托,
dbo.fun_getempname(ysdm) 开嘱医生,
cast(cast(dj as float) as varchar(30)) 单价,cast(js as varchar(10)) 剂数,
cast(cast(sl as float) as varchar(30))+'' ''+dw 数量,cast(je as float)  金额,
dbo.fun_getdeptname(zxks) 执行科室,
(case when bsfbz=1 then ''√'' else '''' end) 收费,''通过'' as 通过,''不通过'' 不通过,bpsbz 皮试标志,
bzby 自备药,fzxh 处方分组序号,
pxxh 排序序号,cfrq as 划价日期,a.hjid,xmid as 项目id,dbo.fun_getdeptname(a.ksdm) 开单科室,
dbo.fun_getempname(HJY) 划价员,brxm 患者姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,
dbo.fun_zy_age(csrq,3,getdate()) 年龄,jtdz 家庭住址,brlxfs 联系方式
  from '+@table+' a inner join '+@table1+' b  
 on a.hjid=b.hjid inner join mzys_jzjl c on a.jzid=c.jzid
 inner join yy_brxx d on a.brxxid=d.brxxid
where cfrq>='''+@cfrq1+''' and cfrq<='''+@cfrq2+''' and a.BSCBZ=0  and xmly=1   '
if @kdks<>''
  set @ss=@ss+' and ksdm in('+@kdks+')'
if @KDYS<>''
  set @ss=@ss+' and ysdm in('+@KDYS+')'
if @zdmc<>''
  set @ss=@ss+' and zdmc like ''%'+@zdmc+'%'''

set @ss=@ss+' order by a.ghxxid,a.hjid,pxxh'
print @ss
exec(@ss)

