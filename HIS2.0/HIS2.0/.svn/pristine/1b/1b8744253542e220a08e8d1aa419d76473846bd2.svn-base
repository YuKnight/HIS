
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_SaveDJmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_SaveDJmx
GO

CREATE PROCEDURE sp_YF_SaveDJmx
(
	@ID UNIQUEIDENTIFIER ,
	@DJID UNIQUEIDENTIFIER,
	@CJID INTEGER,
	@KWID BIGINT,
	@shh varchar(20),
	@yppm varchar(100),
	@YPSPM varchar(100),
	@YPGG varchar(50),
	@sccj varchar(100),
	@YPPH VARCHAR(30),
	@YPXQ CHAR(20),
	@YPKL DECIMAL(15,3),
	@sqsl DECIMAL(15,3) ,
	@YPSL DECIMAL(15,3) ,
	@YPDW VARCHAR(10) ,
	@NYPDW INTEGER,
	@YDWBL INTEGER,
	@JHJ DECIMAL(15,4) ,
	@PFJ DECIMAL(15,4) ,
	@LSJ DECIMAL(15,4) ,
	@JHJE DECIMAL(15,2) ,
	@PFJE DECIMAL(15,3) ,
	@LSJE DECIMAL(15,3) ,
	@DJH BIGINT ,
	@DEPTID INTEGER ,
	@YWLX CHAR(3),
	@bz varchar(200),
	@shdh varchar(50),
	@ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(250)output  ,
    @PXXH INT,
    @returnNewID UNIQUEIDENTIFIER output,
    @YPPCH varchar(100),
    @kcid UNIQUEIDENTIFIER,
    @ymxid uniqueidentifier 
)
as
 begin

 
 set @Err_Code=-1
 set @Err_Text=''
 
 if RTRIM(@YWLX)='' 
  begin
   	    set @Err_Text='业务类型为空'
	    return
  end
 
 IF @DJID=dbo.FUN_GETEMPTYGUID() 
  begin
 		SET @Err_Text='DJID为零,请重新确认'
		return
  end
 
 if @djh=0
  begin
   	    set @Err_Text='单据号为零请重新确认'
	    return
  end
 
 if @cjid=0 
  begin
   	    set @Err_Text='错误,厂家ID为零请重新确认'
	    return
  end
 
  if @nypdw=0 
  begin
   	    set @Err_Text='错误,单位ID为零'
	    return
  end
 
 if rtrim(@ypph)='' 
  begin
   	    set @ypph='无批号'
  end
 
-- if rtrim(@shdh)='' then
--   	    set @Err_Text='错误,送货单号必填'
--	    return
-- end if 



if EXISTS(select * from JC_CONFIG where ID=8033 and CONFIG='1' )and @YWLX='001'
begin
 set @PFJ=@JHJ
 set @PFJE=round(@JHJ*@YPSL,2)
 update yp_ypcjd set PFJ=@JHJ where CJID=@CJID
end


--付款比例 
declare @FKBL decimal(15,4)
SET @FKBL=1;
if @YWLX in ('001','002')
begin
	select @FKBL=FKBL from YP_YPCJD where CJID=@CJID
end


 
 IF @id=dbo.FUN_GETEMPTYGUID() 
  begin
	declare @NewID UNIQUEIDENTIFIER 
	SET @NewID=dbo.FUN_GETGUID(newid(),getdate())
	
	--如果管理批号，对于业务类型为 001 009 019的业务类型，将id写入kcid
    declare @bpcgl int =0;   --批次号管理
	select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--暂时设定为999
    if @bpcgl=1
    begin
		if @YWLX in ('001','009','019')
		 set @kcid=@NewID 
	end
    insert into YF_djmx(id,djid,cjid,kwid,shh,yppm,ypspm,ypgg,sccj,ypph,ypxq,ypkl,sqsl,ypsl,ypdw,nypdw,ydwbl,jhj,pfj,lsj,jhje,pfje,lsje,djh,deptid,ywlx,bz,shdh,PXXH,FKBL,YPPCH,kcid)
    values(@NewID,@djid,@cjid,@kwid,@shh,@yppm,@ypspm,@ypgg,@sccj,@ypph,@ypxq,@ypkl,@sqsl,@ypsl,@ypdw,@nypdw,@ydwbl,@jhj,@pfj,@lsj,@jhje,@pfje,@lsje,@djh,@deptid,@ywlx,@bz,@shdh,@PXXH,@FKBL,@YPPCH,@kcid)

    if @@rowcount=0
        begin
	    set @Err_Text='插入单据明细没有成功，影响到数据库0行'
	    return
        end
	SET @Err_Text='保存成功'
	set @err_code=0
  end

 
 IF @id<>dbo.FUN_GETEMPTYGUID() 
  begin
      update YF_djmx set cjid=@cjid,kwid=@kwid,shh=@shh,yppm=@yppm,ypspm=@ypspm,ypgg=@ypgg,sccj=@sccj,ypph=@ypph,ypxq=@ypxq,ypkl=@ypkl,sqsl=@sqsl,
             ypsl=@ypsl,ypdw=@ypdw,nypdw=@nypdw,ydwbl=@ydwbl,jhj=@jhj,pfj=@pfj,lsj=@lsj,jhje=@jhje,pfje=@pfje,lsje=@lsje,djh=@djh,bz=@bz,shdh=@shdh,
			 PXXH=@PXXH,YPPCH=@YPPCH,kcid=@kcid
	 where deptid=@deptid and djh=@djh and id=@id
  
    if @@rowcount=0 
      begin
	        update YF_djmx_h set cjid=@cjid,kwid=@kwid,shh=@shh,yppm=@yppm,ypspm=@ypspm,ypgg=@ypgg,sccj=@sccj,ypph=@ypph,ypxq=@ypxq,ypkl=@ypkl,sqsl=@sqsl,
	             ypsl=@ypsl,ypdw=@ypdw,nypdw=@nypdw,ydwbl=@ydwbl,jhj=@jhj,pfj=@pfj,lsj=@lsj,jhje=@jhje,pfje=@pfje,lsje=@lsje,djh=@djh,bz=@bz,shdh=@shdh,
				 PXXH=@PXXH,yppch=@yppch,kcid=@kcid 
			where deptid=@deptid and djh=@djh and id=@id
			if @@rowcount=0 
			begin
				set @Err_Text='更新单据明细没有成功，影响到数据库0行'
    			return
		   end
      end
     set @NewID=@id
	 SET @Err_Text='保存成功'
	 SET @Err_Code=0
  end
 

   
end


