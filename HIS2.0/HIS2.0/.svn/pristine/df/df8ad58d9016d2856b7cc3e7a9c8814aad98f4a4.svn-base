IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_PD' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_PD
GO
CREATE PROCEDURE sp_YF_PD
(
	@ID UNIQUEIDENTIFIER , 
	@YWLX CHAR(3),
	@DJH BIGINT ,
	@DEPTID INTEGER ,
	@RQ varchar(30),
	@DJY INTEGER ,
	@DJRQ varchar(30) ,
	@BZ VARCHAR(100) ,
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
 
 if @djh=0 
 begin
   	    set @err_text='单据号为零请重新确认';
	    return;
 end

 if rtrim(@ywlx)=''
begin
        set @err_text='业务类型为空请与管理员联系';
		return;
 end 
 
 IF @id=dbo.FUN_GETEMPTYGUID() or @id is null 
begin
	 set @djid=dbo.FUN_GETGUID(newid(),getdate())
     insert into YF_pd(id,jgbm,YWLX,DJH,DEPTID,RQ,DJY,DJRQ,BZ,BDELETE)
     values(@djid,@jgbm,@YWLX,@DJH,@DEPTID,@RQ,@DJY,@DJRQ,@BZ,@BDELETE);
     if @@rowcount=0 
     begin
	    set @err_text='插入单据头没有成功，影响到数据库0行';
	    return;
     end 

    
    if @djid is null or @djid=dbo.FUN_GETEMPTYGUID()
    begin
	    SET @err_text='@djid为零,请重试'
	    return
    end

     SET @ERR_TEXT='插入盘点单表头成功';
	 
     update YF_pdcs set  shbz=1,shrq=@djrq,shy=@djy,shdjh=@djh where shbz=0 and deptid=@deptid and bdelete=0;
     if @@rowcount=0
     begin
	    set @err_text='更新盘点录入数据时没有成功，影响到数据库0行';
	    return;
     end
	 SET @ERR_TEXT='更新盘点录入单的审核状态成功';
end
 
 if @id<>dbo.FUN_GETEMPTYGUID()
begin
   set @err_text='单据ID大于零，请与管理员联系';
   return;
 end 

  SET @ERR_CODE=0;
end;


