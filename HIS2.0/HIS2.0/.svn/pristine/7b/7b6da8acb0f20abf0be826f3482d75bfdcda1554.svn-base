IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_RKSQ' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_RKSQ
GO
CREATE PROCEDURE sp_YF_RKSQ
(
	@ID UNIQUEIDENTIFIER ,
	@YWLX CHAR(3),
	@WLDW INTEGER,
	@JSR INTEGER,
	@DJY INTEGER,
	@DJRQ VARCHAR(30),
	@DJH BIGINT ,
	@DEPTID INTEGER ,
	@BZ VARCHAR(100),
	@BDELETE SMALLINT ,
    @djid UNIQUEIDENTIFIER output,
	@ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(100) output,
	@jgbm bigint
) 
as

 begin

 
 set @Err_Code=-1;
 set @Err_Text='';
--set @djid=0
 
 if @djh=0 
begin
   	    set @err_text='单据号为零请重新确认';
	    return;
end
 
if rtrim(@ywlx)='' 
begin
   	    --set @err_text='业务类型为空请重新确认';
	    --return;
	    set @ywlx='013'
 end
 
  if @wldw=0 
begin
   	    set @err_text='往来单位为空请重新确认';
	    return;
end
 
 IF @id=dbo.FUN_GETEMPTYGUID() or @id is null
begin
	set @djid=dbo.FUN_GETGUID(newid(),getdate())
    insert into YF_RKSQ(id,jgbm,YWLX,WLDW,DJY,DJRQ,DJH,DEPTID,BZ,BDELETE)
    values(@djid,@jgbm,@YWLX,@WLDW,@DJY,@DJRQ,@DJH,@DEPTID,@BZ,@BDELETE);


   if @@rowcount=0 
   begin
	    set @err_text='插入单据头没有成功，影响到数据库0行';
	    return;
   end

    
    if @djid=dbo.FUN_GETEMPTYGUID() OR @djid IS NULL
    begin
	    SET @err_text='@djid为零,请重试'
	    return
    end

	 SET @ERR_TEXT='保存成功';
end


 IF @id<>dbo.FUN_GETEMPTYGUID()
begin
    update YF_RKSQ set WLDW=@wldw,BZ=@bz,BDELETE=@bdelete
   where deptid=@deptid and djh=@djh and id=@id and shbz=0;
    if @@rowcount=0
    begin
	    set @err_text='更新单据头没有成功，影响到数据库0行';
	    return;
    end
    SET @ERR_TEXT='修改成功'
    SET @DJID=@ID
 END 

  SET @ERR_CODE=0;
end;


