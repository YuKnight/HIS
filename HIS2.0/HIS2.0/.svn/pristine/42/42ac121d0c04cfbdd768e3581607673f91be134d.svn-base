IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_pdcsmx_kcmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_pdcsmx_kcmx
GO

CREATE PROCEDURE sp_YF_pdcsmx_kcmx
(
	@ID UNIQUEIDENTIFIER ,
	@DJH BIGINT ,
	@DJID UNIQUEIDENTIFIER,
	@CJID INTEGER,
	@PFJ DECIMAL(15,4) ,
	@LSJ DECIMAL(15,4) ,
	@zcsl decimal(15,3),
	@PCSL DECIMAL(15,3) ,
	@YPDW VARCHAR(10) ,
	@YDWBL INTEGER ,
	@KCID UNIQUEIDENTIFIER,
	@DEPTID INTEGER ,
	@ERR_CODE INTEGER OUTPUT,
    @ERR_TEXT VARCHAR(250) OUTPUT,
	@pxxh int
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
 
declare @yklsj decimal(15,2)
select @yklsj=lsj from yp_ypcjd where cjid=@cjid

IF @id=dbo.FUN_GETEMPTYGUID() or @id is null 
begin
    insert into YF_PDCSMX_KCMX(id,djid,djh,cjid,pfj,lsj,zcsl,pcsl,ypdw,ydwbl,KCID,deptid,pxxh)
    values(dbo.FUN_GETGUID(newid(),getdate()),@djid,@djh,@cjid,@pfj,@lsj,@zcsl,@pcsl,@ypdw,@ydwbl,@kcid,@deptid,@pxxh);
    if @@rowcount=0 
    begin
	    set @Err_Text='插入单据明细没有成功，影响到数据库0行';
	    return;
    end
    SET @Err_Text='保存成功';
END


IF @id<>dbo.FUN_GETEMPTYGUID()
begin
    update YF_PDCSMX_KCMX set cjid=@cjid,pfj=@pfj,lsj=@lsj,zcsl=@zcsl,pcsl=@pcsl,ypdw=@ypdw,kcid=@kcid,ydwbl=@ydwbl,pxxh=@pxxh
	 where deptid=@deptid and djh=@djh and id=@id;
    if @@rowcount=0 
    begin
	    set @Err_Text='更新单据明细没有成功，影响到数据库0行';
	    return;
    end
	SET @Err_Text='修改成功';
END
 
 SET @Err_Code=0;
   
end;


