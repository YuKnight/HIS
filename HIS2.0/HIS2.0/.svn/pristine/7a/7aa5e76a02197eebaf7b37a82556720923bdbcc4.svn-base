
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YK_SaveDJmx_temp' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YK_SaveDJmx_temp
GO

CREATE PROCEDURE sp_YK_SaveDJmx_temp
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
	@JHJE DECIMAL(15,3) ,
	@PFJE DECIMAL(15,3) ,
	@LSJE DECIMAL(15,3) ,
	@DJH BIGINT ,
	@DEPTID INTEGER ,
	@YWLX CHAR(3),
	@bz varchar(200),
	@shdh varchar(50),
	@zbzt smallint,
	@ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(250)output,
	@pxxh int,
	@returnNewID UNIQUEIDENTIFIER output,
	@yppch varchar(100),
	@kcid uniqueidentifier 
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
 
 IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL 
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

 IF cast(@JHJ*@YPSL as int)<>cast(@JHJE as  int)
 BEGIN
	   SET @ERR_TEXT='进货金额不等于进价乘以药品数量'
	   return;
 END
 
-- if rtrim(@shdh)='' then
--   	    set @Err_Text='错误,送货单号必填'
--	    return
-- end if 

if EXISTS(select * from JC_CONFIG where ID=8033 and CONFIG='1') and @YWLX in('001','002')
begin
 set @PFJ=@JHJ
 set @PFJE=round(@JHJ*@YPSL,2)
 if @ywlx='001'
   update yp_ypcjd set PFJ=@JHJ where CJID=@CJID
end


--付款比例 
--问题：退货时应该取库存批号表中 付款比例 但是没有退货代码
declare @FKBL decimal(15,4)
SET @FKBL=1;
if @YWLX in ('001','002')
begin
	select @FKBL=FKBL from YP_YPCJD where CJID=@CJID
end

 
 IF @id=dbo.FUN_GETEMPTYGUID() OR @ID IS NULL
  begin
	declare @NewID UNIQUEIDENTIFIER 
	SET @NewID=dbo.FUN_GETGUID(newid(),getdate())
    insert into yk_djmx_temp(ID,djid,cjid,kwid,shh,yppm,ypspm,ypgg,sccj,ypph,ypxq,ypkl,sqsl,ypsl,ypdw,nypdw,ydwbl,jhj,pfj,lsj,jhje,pfje,lsje,djh,deptid,ywlx,bz,shdh,PXXH,FKBL,yppch,kcid,zbzt)
    values(@NewID,@djid,@cjid,@kwid,@shh,@yppm,@ypspm,@ypgg,@sccj,@ypph,@ypxq,@ypkl,@sqsl,@ypsl,@ypdw,@nypdw,@ydwbl,@jhj,@pfj,@lsj,@jhje,@pfje,@lsje,@djh,@deptid,@ywlx,@bz,@shdh,@PXXH,@FKBL,@yppch,@kcid,@zbzt)

    if @@rowcount=0
        begin
	    set @Err_Text='插入单据明细没有成功，影响到数据库0行'
	    return
        end
  end

 
 IF @id<>dbo.FUN_GETEMPTYGUID() 
  begin
      update yk_djmx_temp set cjid=@cjid,kwid=@kwid,shh=@shh,yppm=@yppm,ypspm=@ypspm,ypgg=@ypgg,sccj=@sccj,ypph=@ypph,ypxq=@ypxq,ypkl=@ypkl,sqsl=@sqsl,
             ypsl=@ypsl,ypdw=@ypdw,nypdw=@nypdw,ydwbl=@ydwbl,jhj=@jhj,pfj=@pfj,lsj=@lsj,jhje=@jhje,pfje=@pfje,lsje=@lsje,djh=@djh,bz=@bz,shdh=@shdh
			 ,PXXH=@PXXH,yppch=@yppch,kcid=@kcid,zbzt=@zbzt
	 where deptid=@deptid and djh=@djh and id=@id
  
    if @@rowcount=0 
      begin
	  --   update yk_djmx_h set cjid=@cjid,kwid=@kwid,shh=@shh,yppm=@yppm,ypspm=@ypspm,ypgg=@ypgg,sccj=@sccj,ypph=@ypph,ypxq=@ypxq,ypkl=@ypkl,sqsl=@sqsl,
	  --           ypsl=@ypsl,ypdw=@ypdw,nypdw=@nypdw,ydwbl=@ydwbl,jhj=@jhj,pfj=@pfj,lsj=@lsj,jhje=@jhje,pfje=@pfje,lsje=@lsje,djh=@djh,bz=@bz,shdh=@shdh
			--	 ,PXXH=@PXXH
		 --where deptid=@deptid and djh=@djh and id=@id
		if @@rowcount=0 
		begin
			Set @Err_Text='更新单据明细没有成功，影响到数据库0行'
			return
        end
      end
  set @NewID=@id
  end
 
--是否直接录入批发价
declare @bpfj int 
set @bpfj=(select zt from yk_config where bh='111' and deptid=@deptid )
set @bpfj=coalesce(@bpfj,0)
if @bpfj=1 
begin
   update yp_ypcjd set pfj=@pfj where cjid=@cjid
end

set @returnNewID=@NewID;
SET @Err_Text='保存成功'
set @err_code=0
   
end


