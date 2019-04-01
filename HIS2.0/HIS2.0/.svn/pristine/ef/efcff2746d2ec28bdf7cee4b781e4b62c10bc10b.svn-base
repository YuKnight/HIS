IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YK_SaveDJ' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YK_SaveDJ
GO

CREATE PROCEDURE sp_YK_SaveDJ
(
 	@id UNIQUEIDENTIFIER,
	@DJH BIGINT ,
	@DEPTID INTEGER ,
	@YWLX CHAR(3),
	@WLDW INTEGER ,
	@JSR INTEGER ,
	@RQ varchar(30) ,
	@DJY INTEGER,
	@DJRQ varchar(30),
	@DJSJ varchar(30),
	@FPH VARCHAR(30),
	@FPRQ varchar(10),
	@BZ VARCHAR(100) ,
   	@SHDH VARCHAR(50) ,
	@yydm int,
	@sqdh bigint,
	@jhje decimal(15,2),
	@pfje decimal(15,2),
	@lsje decimal(15,2),
	@sdjh varchar(20),
	@djid UNIQUEIDENTIFIER output,
	@ERR_CODE INTEGER  output,
    @ERR_TEXT VARCHAR(100)  output,
	@jgbm bigint
)
--sp_yk_saveDJ保存药库业务单据头表
--@id   单据头ID   0 表示新单据  大于0表示修改单据
--@DJH  单据号
--@ywlx 业务类型
--@wldw 往来单位
--@jsr  经手人
--@rq   日期
--@djy  登记员
--@djrq 登记日期
--@djsj 登记时间
--@fph  发票号
--@fprq 发票日期
--@bz   备注
--@shdh 送货单号
--@jhje 进货金额
--@pfje 批发金额
--@lsje 零售金额
--@djid 返回当前插入所产生的单据头ID 如果是修改单据此DJID也要填值
--@err_code 0 表示成功
--@err_text 提示信息文本
--*********************************2006-11-19 王先知
as
 begin

 SET @djid=dbo.FUN_GETEMPTYGUID()
 set @err_code=-1
 set @err_text=''
 
 if @djh=0 
   begin
   	set @err_text='单据号为零请重新确认'
	return
   end
 
 if rtrim(@ywlx)='' 
   begin
   	set @err_text='业务类型为空请重新确认'
	return
   end 
 
  if @wldw=0 
   begin
   	set @err_text='往来单位为空请重新确认'
	return
   end

 IF @id=dbo.FUN_GETEMPTYGUID() OR @ID IS NULL 
  begin
		SET @DJID=dbo.FUN_GETGUID(newid(),getdate())
        insert into yk_dj(ID,jgbm,djh,deptid,ywlx,wldw,jsr,rq,djy,djrq,djsj,fph,fprq,bz,shdh,yydm,sqdh,sumjhje,sumpfje,sumlsje,sdjh)
        values(@DJID,@jgbm,@djh,@deptid,@ywlx,@wldw,@jsr,@rq,@djy,@djrq,@djsj,@fph,@fprq,@bz,@shdh,@yydm,@sqdh,@jhje,@pfje,@lsje,@sdjh)
	
        if @@rowcount=0
	  begin
	    set @err_text='插入单据头没有成功，影响到数据库0行'
		SET @DJID=dbo.FUN_GETEMPTYGUID()
	    return
 	  end

	--set @djid=@@IDENTITY
        IF @djid=dbo.FUN_GETEMPTYGUID() OR @djid IS NULL
	  begin
	    SET @err_text='@djid为零,请重试'
	    return
	  end
	
        SET @err_text='保存成功'
        set @err_code=0
   end 

 
 IF @id<> dbo.FUN_GETEMPTYGUID() 
  begin
        update yk_dj set wldw=@wldw,jsr=@jsr,rq=@rq,fph=@fph,fprq=@fprq,bz=@bz,shdh=@shdh,yydm=@yydm,sumjhje=@jhje,sumpfje=@pfje,sumlsje=@lsje
        where deptid=@deptid and djh=@djh and id=@id and shbz=0 --isnull(yjid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()
        if @@rowcount=0
	begin
	     update yk_dj_h set wldw=@wldw,jsr=@jsr,rq=@rq,fph=@fph,fprq=@fprq,bz=@bz,shdh=@shdh,yydm=@yydm,sumjhje=@jhje,sumpfje=@pfje,sumlsje=@lsje
		    where deptid=@deptid and djh=@djh and id=@id and shbz=0 --isnull(yjid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()
	     if @@rowcount=0
	     begin
	      	  set @err_text='更新单据头没有成功，影响到数据库0行'
	   	  return
             end 
        end 

	set @djid=@id
	SET @err_text='保存成功'
	SET @err_code=0
 end


end



