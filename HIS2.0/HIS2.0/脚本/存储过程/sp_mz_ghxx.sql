IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_mz_ghxx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_mz_ghxx
GO
--exec sp_mz_ghxx 0,0,'','23',0
CREATE  PROCEDURE sp_mz_ghxx  
 (
  @binid UNIQUEIDENTIFIER,--病人信息ID
  @ghxh UNIQUEIDENTIFIER,--病人挂号序号
  @blh varchar(20),--门诊号
  @fph bigint,--发票号
  @bk int --0 当前表,1 备份表
 )  
AS 
declare  @table_ghzdk varchar(20)

declare @ss varchar(4000)
declare @ssbk varchar(4000)

if @bk=0 
 begin
   set @table_ghzdk='MZ_GHXX'
 end 
else
 begin
   set @table_ghzdk='MZ_GHXX_H'
 end

set @ss='select BRXXID as binid,GHXXID as ghxh,blh 门诊号,'+
'b.ghSJ 挂号日期,b.GHKS 挂号科室代码,DBO.FUN_GETDEPTNAME(GHKS) 挂号科室名称,GHJB 挂号医生级别,b.GHYS 挂号医生代码,DBO.FUN_GETEMPNAME(GHYS) 挂号医生姓名,'+
'zdBM 诊断代码,zdmc 诊断名称,'''' 体温,'+
''''' 体重,0 当前看病科室代码,'''' 当前看病科室名称,0 当前看病医生代码,'''' 当前看病医生姓名,ghlb 挂号类别代码 from  '+@table_ghzdk+' b (nolock) where BQXGHBZ<> 9 '

if @binid=dbo.FUN_GETEMPTYGUID() and @ghxh=dbo.FUN_GETEMPTYGUID() and @fph=0 and @blh=''
 set @ss=@ss+' and BRXXID=dbo.FUN_GETEMPTYGUID()'

set @ssbk=@ss

if @binid<>dbo.FUN_GETEMPTYGUID() 
set @ss=@ss+' and BRXXID='''+cast(@binid as varchar(100))+''''
if @blh<>''
set @ss=@ss+' and blh='''+@blh+''''

if @fph>0 and @ghxh=dbo.FUN_GETEMPTYGUID()
begin
  set @ghxh=(select top 1 GHXXID from MZ_FPB where fph=@fph order by GHXXID desc )
  if isnull(@ghxh,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()
    set @ghxh=(select top 1 GHXXID from MZ_FPB_H where fph=@fph order by GHXXID desc )
end 

if isnull(@ghxh,dbo.FUN_GETEMPTYGUID())<>dbo.FUN_GETEMPTYGUID() 
set @ss=@ss+' and GHXXID='''+cast(@ghxh as varchar(100))+''''

set @ss=@ss+' order by ghsj desc'
exec(@ss)
print @ss







GO
