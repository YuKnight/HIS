IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_PDCS' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_PDCS
GO

CREATE PROCEDURE sp_YF_PDCS
(
	@ID UNIQUEIDENTIFIER ,
	@DJH BIGINT ,
	@DEPTID INTEGER ,
	@DJRQ varchar(30),
	@DJY INTEGER ,
	@BDELETE SMALLINT ,
	@BZ VARCHAR(100) ,
    @djid UNIQUEIDENTIFIER output,
	@ERR_CODE INTEGER output ,
    @ERR_TEXT VARCHAR(100) output,
	@jgbm bigint
) 
as
 begin

 
set @Err_Code=-1;
set @Err_Text='';
 
if @djh=0 
begin
   	    set @err_text='单据号为零请重新确认';
	    return;
end

 
IF @id=dbo.FUN_GETEMPTYGUID() or @id is null 
begin
	set @djid=dbo.FUN_GETGUID(newid(),getdate())
    insert into YF_pdcs(id,jgbm,DJH,DEPTID,DJRQ,DJY,BDELETE,BZ)
    values(@djid,@jgbm,@DJH,@DEPTID,@DJRQ,@DJY,@BDELETE,@BZ);
    if @@rowcount=0
    begin
	    set @err_text='插入单据头没有成功，影响到数据库0行';
	    return;
    end

    IF @djid=dbo.FUN_GETEMPTYGUID() OR @djid IS NULL
	  begin
	    SET @err_text='@djid为零,请重试'
	    return
	  end

    SET @ERR_TEXT='保存成功';
 END

 
 IF @id<>dbo.FUN_GETEMPTYGUID()
 begin
    update YF_pdcs set BDELETE=@bdelete,BZ=@bz
    where deptid=@deptid and djh=@djh and id=@id and shbz=0
    if @@rowcount=0 
    begin
	    set @err_text='更新单据头没有成功，影响到数据库0行'
	    return;
    end 
    set @djid=@id
    SET @ERR_TEXT='修改成功';
 END

  SET @ERR_CODE=0
end


