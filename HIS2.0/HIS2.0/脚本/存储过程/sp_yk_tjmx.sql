--要修改
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YK_TJMX' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YK_TJMX
GO
CREATE PROCEDURE sp_YK_TJMX
(
	@ID UNIQUEIDENTIFIER ,
	@DJID UNIQUEIDENTIFIER,
	@CJID INTEGER ,
	@TJSL DECIMAL(10,3) ,
	@YPDW VARCHAR(10) ,
	@YDWBL INTEGER ,
	@YPFJ DECIMAL(15,4) ,
	@XPFJ DECIMAL(15,4),
	@TPFJE DECIMAL(15,2) ,
	@YLSJ DECIMAL(15,4) ,
	@XLSJ DECIMAL(15,4) ,
	@TLSJE DECIMAL(15,2) ,
	@DEPTID INTEGER ,
	@DJH BIGINT ,
	@ywlx char(3),
	@mrjj decimal(15,4),
	@scjj decimal(15,4),
	@scghdw varchar(100),
	@ERR_CODE INTEGER OUTPUT,
	@ERR_TEXT VARCHAR(250) OUTPUT
	
	,@PPBZ bit,   --匹配标志 0否 1是
	@WHMXID uniqueidentifier,--文号明细id
	@ZGLSJ decimal(15,4) --最高零售价
)	
AS
 begin

 set @ERR_CODE=-1;
 set @ERR_TEXT='';
 
 
if @djh=0 
begin
   	    set @ERR_TEXT='单据号为零请重新确认';
	    return;
end
 
if @cjid=0 
begin
   	    set @ERR_TEXT='错误,厂家ID为零请重新确认';
	    return;
end
 
 
declare @bpcgl int =0 --是否进行批次管理
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--暂时设定为999

declare @btjhj varchar ='0' --是否调进价（批次管理下）
if @bpcgl =1
begin
	select @btjhj=config from JC_CONFIG where ID=8056 
end
 
 IF @id=dbo.FUN_GETEMPTYGUID() or @id is null
	begin
		insert into yF_tjmx(ID,djid,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,tpfje,ylsj,xlsj,tlsje,deptid,djh,mrjhj,scjhj,scghdw    
								,ppbz,whmxid,zglsj,
								TJHJE )
		values(dbo.FUN_GETGUID(newid(),getdate()),@djid,@cjid,@tjsl,@ypdw,@ydwbl,@ypfj,@xpfj,@tpfje,@ylsj,@xlsj,@tlsje,@deptid,@djh,@mrjj,@scjj,@scghdw
								,@PPBZ,@WHMXID,@ZGLSJ,
								(case @btjhj when '1' then ((@mrjj-@scjj)*@TJSL) else  0 end))
		
		if @@rowcount=0
		begin
			set @ERR_TEXT='插入单据明细没有成功，影响到数据库0行';
			return;
		end
		SET @ERR_TEXT='保存成功';
	end
 
ELSE
	begin
		   update yF_tjmx set cjid=@cjid,tjsl=@tjsl,ypdw=@ypdw,ydwbl=@ydwbl,ypfj=@ypfj,xpfj=@xpfj,tpfje=@tpfje,ylsj=@ylsj,xlsj=@xlsj,tlsje=@tlsje,
		     mrjhj=@mrjj,scjhj=@scjj,scghdw=@scghdw
		     ,ppbz=@PPBZ,whmxid=@WHMXID,zglsj=@ZGLSJ  
		     ,TJHJE=(@mrjj-@scjj)*@TJSL
			where id=@id and deptid=@deptid;
		if @@rowcount=0
			begin
			  set @ERR_TEXT='更新单据明细没有成功，影响到数据库0行';
			  return;
			end
		   SET @ERR_TEXT='更新成功';
	end
 
 SET @ERR_CODE=0;
 SET @ERR_TEXT='调价单保存成功';
   
end;