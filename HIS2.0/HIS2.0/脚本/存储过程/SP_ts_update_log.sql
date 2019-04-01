IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_ts_update_log' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_ts_update_log
GO


CREATE  PROCEDURE [dbo].SP_ts_update_log  
 (  
	@id UNIQUEIDENTIFIER,
	@czlx int,
    @czks int,
    @czry int,
    @cznr varchar(300),
    @ymc varchar(100),
    @yzj varchar(200),
    @djsj varchar(30),
    @djy int,
    @djjgbm bigint,
    @mbjgbm bigint,
    @mbks int,
    @bz varchar(300),
	@err_code INT OUTPUT,
	@err_text varchar(50) OUTPUT,
    @ylm varchar(30),
    @DJID UNIQUEIDENTIFIER OUTPUT
 )   
  
   
AS  
  
BEGIN  
set @err_code=-1
set @err_text='log日志没有保存成功'
declare @mbjgbmX bigint

SET @DJID=dbo.FUN_GETGUID(newid(),getdate())

if not exists(select * from ts_update_type where czlx=@czlx and bscbz=0)
begin
	set @err_code=0
	set @err_text='保存成功'
    return
end

--如果登记的机构是中心,则向所有的服务器发送消息日志
if @mbjgbm<=0
begin
	if exists(select * from jc_jgbm where jgbm=@djjgbm and yybm=0) or @mbks=-999  
		insert into ts_update_log(id,czlx,czks,czry,cznr,ymc,ylm,yzj,djsj,djy,djjgbm,mbjgbm,bz,DJID)
		select dbo.FUN_GETGUID(newid(),getdate()),
		@czlx,@czks,@czry,@cznr,@ymc,@ylm,@yzj,@djsj,@djy,@djjgbm,jgbm,@bz,@DJID
		 from jc_jgbm where jgbm<>@djjgbm and (ipaddr<>'' and ipaddr is not null and len(ipaddr)>5) 
	else 
	begin
	   set @mbjgbmX=(select jgbm from jc_dept_property where dept_id=@mbks)
	   if @mbjgbmX=0 or @mbjgbmX is null  or @mbjgbmX=-1
	   begin 
			SET @DJID=DBO.FUN_GETEMPTYGUID()
			set @err_code=0
			set @err_text='保存成功'
			return
	   end
	   if exists(select * from jc_jgbm where jgbm=@mbjgbmX and jgbm<>@djjgbm)
		   insert into ts_update_log(id,czlx,czks,czry,cznr,ymc,ylm,yzj,djsj,djy,djjgbm,mbjgbm,bz,DJID)
		   values(dbo.FUN_GETGUID(newid(),getdate()),@czlx,@czks,@czry,@cznr,@ymc,@ylm,@yzj,@djsj,@djy,@djjgbm,@mbjgbmX,@bz,@DJID)
	end
end
else 
		insert into ts_update_log(id,czlx,czks,czry,cznr,ymc,ylm,yzj,djsj,djy,djjgbm,mbjgbm,bz,DJID)
		select dbo.FUN_GETGUID(newid(),getdate()),
		@czlx,@czks,@czry,@cznr,@ymc,@ylm,@yzj,@djsj,@djy,@djjgbm,@mbjgbm,@bz,@DJID



set @err_code=0
set @err_text='保存成功'
	
END  
  
   
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  