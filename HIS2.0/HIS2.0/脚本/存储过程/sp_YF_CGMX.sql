IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_CGMX' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_CGMX
GO
CREATE PROCEDURE sp_YF_CGMX
(
	@ID UNIQUEIDENTIFIER ,
	@CJID int ,
	@XQS DECIMAL(15,3),
	@JHS DECIMAL(15,3),
	@YPDW VARCHAR(10),
	@YDWBL INT,
	@CKJJ DECIMAL(15,4),
	@CKKL DECIMAL(15,3),
	@WLDW INTEGER,
	@DJH BIGINT,
	@DEPTID INTEGER,
	@DJID UNIQUEIDENTIFIER,
	@Err_Code INTEGER  output,
    @Err_Text VARCHAR(250) output,
    @SYYL DECIMAL(15,3)
)
AS
 begin


 
 set @Err_Code=-1;
 set @Err_Text='';
 
 if @djh=0 
begin
   	    set @Err_Text='单据号为零请重新确认';
	    return;
end
 
 if @cjid=0 
begin
   	    set @Err_Text='错误,厂家ID为零请重新确认';
	    return;
end
 
 if @YDWBL=0 
begin
   	    set @Err_Text='错误,单位比例为零请重新确认';
	    return;
end
 
 IF @id=dbo.FUN_GETEMPTYGUID() 
begin
    insert into yf_cgmx(id,djid,cjid,xqs,jhs,ypdw,ydwbl,ckjj,ckkl,wldw,SYYL)
    values(dbo.FUN_GETGUID(newid(),getdate()),@djid,@cjid,@xqs,@jhs,@ypdw,@ydwbl,@ckjj,@ckkl,@wldw,@SYYL);

    if @@rowcount=0
    begin
	    set @Err_Text='插入单据明细没有成功，影响到数据库0行';
	    return;
    end 
	SET @Err_Text='保存成功';
end

 
IF @id<>dbo.FUN_GETEMPTYGUID()
begin
    update yf_cgmx set djid=@djid,xqs=@xqs,jhs=@jhs,ypdw=@ypdw,ydwbl=@ydwbl,ckjj=@ckjj,ckkl=@ckkl,wldw=@wldw,SYYL=@SYYL
	 where id=@id;
    if @@rowcount=0
    begin
	    set @Err_Text='更新单据明细没有成功，影响到数据库0行';
	    return;
    end 

	SET @Err_Text='修改成功';
end
 
 SET @Err_Code=0;
   
end;


