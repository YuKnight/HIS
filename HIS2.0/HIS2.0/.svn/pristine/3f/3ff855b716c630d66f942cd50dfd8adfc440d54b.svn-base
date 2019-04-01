IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_TY_select_CF' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_TY_select_CF
GO
CREATE PROCEDURE sp_yf_TY_select_CF --发药查找处方
(
	@deptid INTEGER,
	@patid UNIQUEIDENTIFIER,
	@cfrq1 varchar(30),
	@cfrq2 varchar(30),
	@mzh varchar(50),
    @dnlsh bigint,
    @fph varchar(30),
	@fyid UNIQUEIDENTIFIER
)
as
begin
 declare @ssql varchar(2000);
 
  SET @SSQL='select 0 序号,cast(1 as smallint) 发药,fph 发票号,a.patientno 病历号,hzxm 姓名,'+
'  xb 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,'+
  ''''' 项目,zje 金额,jzje 记帐金额,yhje 优惠金额,zfje 自付金额,dbo.fun_getdeptname(ksdm) 科室,'+
  ' dbo.fun_getempname(ysdm) 医生,cfts 剂数,skrq 收费日期,dbo.fun_getempname(sky) 收费员,dbo.fun_getempname(pyr) 配药人,'+
  ' pyckh 配药窗口,dbo.fun_getdeptname(deptid) 发药科室,fyrq 发药日期,dbo.fun_getempname(fyr) 发药人,'+
  ' cast(JSSJH as bigint) jssjh,cfxh XH, patid,YSDM,KSDM,sky,PYCKH,cflx,ID,ghxh from '+
  ' yf_fy a where id is not null  ';--and B.patid='+CAST(@patid AS CHAR(12))+' ';--and deptid='+cast(@deptid as char(10));
  
	if EXISTS(select * from JC_CONFIG where ID=8020 and CONFIG='0')
	  set @ssql=@ssql+' and deptid='+cast(@deptid as char(50));
    if @patid<>dbo.FUN_GETEMPTYGUID()
	  set @ssql=@ssql+' and patid='''+ cast(@patid as varchar(100))+''''  ;
   if @cfrq1<>''
	  set @ssql=@ssql+' and lrrq>='''+ @cfrq1+''' and lrrq<='''+@cfrq2+''''  
    if @mzh<>''
	  set @ssql=@ssql+' and patientno='''+ @mzh+''''  ;
    if @dnlsh>0
	  set @ssql=@ssql+' and jssjh='''+ cast(@dnlsh as varchar(50))+''''  ;
   if @fph<>'0'
	  set @ssql=@ssql+' and fph='+ cast(cast(@fph as bigint) as varchar(30)) ;
    if @fyid<>dbo.FUN_GETEMPTYGUID()
	  set @ssql=@ssql+' and id='''+ cast(@fyid as varchar(100))+''''  ;


	
  SET @SSQL=@ssql+' union all select 0 序号,cast(1 as smallint) 发药,fph 发票号,patientno 病历号,hzxm 姓名,'+
  '  xb 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,'+
  'dbo.fun_gettjdxm(cflx) 项目,zje 金额,jzje 记帐金额,yhje 优惠金额,zfje 自付金额,dbo.fun_getdeptname(ksdm) 科室,'+
  ' dbo.fun_getempname(ysdm) 医生,cfts 剂数,skrq 收费日期,dbo.fun_getempname(sky) 收费员,dbo.fun_getempname(pyr) 配药人,'+
  ' pyckh 配药窗口,dbo.fun_getdeptname(deptid) 发药科室,fyrq 发药日期,dbo.fun_getempname(fyr) 发药人,'+
  ' cast(JSSJH as bigint) jssjh,cfxh XH,patid,YSDM,KSDM,sky,PYCKH,cflx,ID,ghxh from '+
  ' yf_fy_h a where id is not null  '--and B.patid='+CAST(@patid AS CHAR(12))+' ';--and deptid='+cast(@deptid as char(10));
  
	if EXISTS(select * from JC_CONFIG where ID=8020 and CONFIG='0')
	  set @ssql=@ssql+' and deptid='+cast(@deptid as char(50));
    if @patid<>dbo.FUN_GETEMPTYGUID()
	  set @ssql=@ssql+' and patid='''+ cast(@patid as varchar(100))+''''  ;
   if @cfrq1<>''
	  set @ssql=@ssql+' and lrrq>='''+ @cfrq1+''' and lrrq<='''+@cfrq2+''''  
    if @mzh<>''
	  set @ssql=@ssql+' and patientno='''+ @mzh+''''  ;
    if @dnlsh>0
	  set @ssql=@ssql+' and jssjh='''+ cast(@dnlsh as varchar(50))+''''  ;
    if @fph<>'0'
	  set @ssql=@ssql+' and fph='+ cast(cast(@fph as bigint) as varchar(30)) ;
    if @fyid<>dbo.FUN_GETEMPTYGUID()
	  set @ssql=@ssql+' and id='''+ cast(@fyid as varchar(100))+''''  ;

 set @ssql=@ssql+' order by id';
 
 exec(@ssql)
end 