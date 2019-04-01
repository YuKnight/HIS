IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_YPBL_KH_TS' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_YPBL_KH_TS
GO

create proc SP_YP_YPBL_KH_TS
@ksdm int,--科室代码
@ysdm int,--医生代码
@type int,--0门诊 1住院
@tsInfo int,--0提示 1控制
@err_code int out,
@err_text varchar(200) out
as

declare @rq_year int,@rq_month int
set @rq_month=MONTH(GETDATE())
set @rq_year=YEAR(GETDATE())

declare @jcid bigint
declare @khbl float
declare @yjbl float
declare @dqbl float
declare @ksrq datetime
declare @jsrq datetime
--生成数据的最后时间
declare @zhsj datetime

set @err_code=0;

if @type=0
begin
  select top 1 @jcid=ID,@khbl=khbl,@yjbl=yjbl from JC_YPKHBL where BZYBZ=0 and YSDM=@ysdm and ksdm=0 and bqybz=1 and khlxid=1
  if @jcid is null
	select  top 1 @jcid=ID,@khbl=khbl,@yjbl=yjbl from JC_YPKHBL where BZYBZ=0 and YSDM=@ysdm and ksdm=@ksdm and bqybz=1 and khlxid=1
  if @jcid is null
	select  top 1 @jcid=ID,@khbl=khbl,@yjbl=yjbl from JC_YPKHBL where BZYBZ=0 and KSDM=@ksdm and YSDM=0 and bqybz=1 and khlxid=1
end
if @type=1
begin
  select  top 1 @jcid=ID,@khbl=khbl,@yjbl=yjbl from JC_YPKHBL where BZYBZ=1 and YSDM=@ysdm and ksdm=0 and bqybz=1 and khlxid=1
  if @jcid is null
	select  top 1 @jcid=ID,@khbl=khbl,@yjbl=yjbl from JC_YPKHBL where BZYBZ=1 and YSDM=@ysdm and ksdm=@ksdm and bqybz=1 and khlxid=1
  if @jcid is null
	select  top 1 @jcid=ID,@khbl=khbl,@yjbl=yjbl from JC_YPKHBL where BZYBZ=1 and KSDM=@ksdm and YSDM=0 and bqybz=1 and khlxid=1
end

--提示	
if(@tsInfo=0) 
begin
    select top 1 @dqbl=ypbl,@zhsj=@jsrq from YP_YPKHBL_YWSJ  where nf=@rq_year and yf=@rq_month  and jcid=@jcid
	select @jcid jcid,@rq_year nf,@rq_month yf,@khbl khbl,@yjbl yjbl,@dqbl dqbl
	select JCID,NF,YF,KSSJ,JSSJ,BQYBZ,DJSJ,DJY ,BZ from yp_ypkhbl_zj where jcid=@jcid and KSSJ<GETDATE() and JSSJ>GETDATE() and  BQYBZ=1
end
	

--控制	
if @tsInfo=1
begin
   
	select top 1 @dqbl=ypbl,@zhsj=jsrq from YP_YPKHBL_YWSJ  where nf=@rq_year and yf=@rq_month  and jcid=@jcid
	select top 1 @ksrq=KSSJ,@jsrq=JSSJ from yp_ypkhbl_zj where jcid=@jcid and KSSJ<=dbo.Fun_GetDate(GETDATE()) and JSSJ>=dbo.Fun_GetDate(GETDATE()) and  BQYBZ=1
	 select @dqbl,@khbl,@ksrq
	--当前比例大于考核比例 且没有延长权限
	if @dqbl>=@khbl and  @ksrq is null
	begin
	  set @err_code=-1
	  set @err_text='截至'+dbo.Fun_GetDate(@zhsj)+' 您的药占比达到' + cast(cast(@dqbl as float) as varchar(50))+
	  '%,已超过考核比例 '+cast(cast(@khbl as float) as varchar(50))+',系统已取消您的药品处方权限。请和医务部门联系'
	end
end


