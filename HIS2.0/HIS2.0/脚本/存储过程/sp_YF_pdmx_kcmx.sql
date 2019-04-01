IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_pdmx_kcmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_pdmx_kcmx
GO
CREATE PROCEDURE sp_YF_pdmx_kcmx
(
	@ID UNIQUEIDENTIFIER,
	@DJID UNIQUEIDENTIFIER ,
	@CJID INTEGER,
	@KCID UNIQUEIDENTIFIER ,
	@PCS DECIMAL(15,3) ,
	@ZCS DECIMAL(15,3) ,
	@YPDW VARCHAR(10) ,
	@YDWBL INTEGER,
	@PFJ DECIMAL(15,4) ,
	@LSJ DECIMAL(15,4) ,
	@PCPFJE DECIMAL(15,2) ,
	@ZCPFJE DECIMAL(15,2) ,
	@PCLSJE DECIMAL(15,2) ,
	@ZCLSJE DECIMAL(15,2),
	@ERR_CODE INTEGER OUTPUT,
    @ERR_TEXT VARCHAR(250) OUTPUT,
	@pxxh int
) 
AS
 begin

 set @Err_Code=-1;
 set @Err_Text='';
 
if @djid is null or @djid=dbo.FUN_GETEMPTYGUID() 
begin
   	    set @err_text='单据ID为零请重新确认';
	    return;
end
 
if @cjid=0 
begin
   	    set @err_text='错误,厂家ID为零请重新确认';
	    return;
end
 
 -- if @kcid=0 then
 --  	    set err_text='错误,库存ID为零请重新确认';
	--    return;
 --end if ;
 
if @ydwbl=0 
begin
   	    set @err_text='错误,原单位比例为零请重新确认';
	    return;
end
 
IF @id=dbo.FUN_GETEMPTYGUID() or @id is null 
begin
    insert into YF_pdmx_kcmx(id,djid,cjid,kcid,pcs,zcs,ypdw,ydwbl,pfj,lsj,pcpfje,zcpfje,pclsje,zclsje,pxxh)
    values(dbo.FUN_GETGUID(newid(),getdate()),@djid,@cjid,@kcid,@pcs,@zcs,@ypdw,@ydwbl,@pfj,@lsj,@pcpfje,@zcpfje,@pclsje,@zclsje,@pxxh);
    if @@rowcount=0
      begin
	    set @err_text='插入单据明细没有成功，影响到数据库0行';
	    return;
      end
	SET @ERR_TEXT='保存成功';
end

 
IF @id<>dbo.FUN_GETEMPTYGUID() 
begin
	SET @ERR_TEXT='记录在数据库中已存不能再次修改，请和管理员联系';
	return;
end
 
 SET @ERR_CODE=0;
   
end;