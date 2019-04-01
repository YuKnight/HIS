IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YK_TJ' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YK_TJ
GO
CREATE PROCEDURE sp_YK_TJ
(
	@ID UNIQUEIDENTIFIER ,
	@YWLX CHAR(3),
	@DJH BIGINT ,
	@TJWH VARCHAR(50),
	@DJY INT ,
	@DJSJ VARCHAR(30) ,
	@ZXRQ VARCHAR(30) ,
	@WCBJ SMALLINT ,
	@BDELETE SMALLINT ,
	@DEPTID INT ,
	@BZ VARCHAR(100), 
	@djid UNIQUEIDENTIFIER output,
	@ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(100) output,
	@jgbm bigint
	,@BLJZX bit--add by ncq 立即执行标志
	,@TJXS decimal(15,4) --调价系数
	,@BPLTJ bit 
)
as
 begin
 set @djid=dbo.FUN_GETEMPTYGUID()
 set @ERR_CODE=-1
 set @ERR_TEXT=''
 
if @djh=0 
begin
   	    set @ERR_TEXT='单据号为零请重新确认'
	    return
end
 
if rtrim(@ywlx)='' 
begin
   	    set @ERR_TEXT='业务类型为空请重新确认'
	    return
end
 
if rtrim(@tjwh)=''
begin
        set @ERR_TEXT='请输入调价文号'
		return
end
 
 IF @id=dbo.FUN_GETEMPTYGUID() OR @ID IS NULL 
begin
	   SET @DJID=dbo.FUN_GETGUID(newid(),getdate())
       insert into yF_Tj(ID,jgbm,YWLX,DJH,TJWH,DJY,DJRQ,ZXRQ,WCBJ,BDELETE,DEPTID,BZ,   bljzx,tjxs,bpltj)
   	   values(@DJID,@jgbm,@YWLX,@DJH,@TJWH,@DJY,@DJSJ,@ZXRQ,@WCBJ,@BDELETE,@DEPTID,@BZ, @BLJZX,@TJXS,@BPLTJ)
      
      if @@rowcount=0 
      begin
         set @ERR_TEXT='插入单据头没有成功，影响到数据库0行'
		 SET @DJID=dbo.FUN_GETEMPTYGUID()
         return
      end

	 --set @djid=@@IDENTITY
       if @djid=dbo.FUN_GETEMPTYGUID() or @djid is null 
       begin
          set @err_text='发生错误，单据ID为零，请和管理员联系'
		  SET @DJID=dbo.FUN_GETEMPTYGUID()
          return
       end

      SET @ERR_TEXT='调价单头表保存成功'
end

ELSE
begin
       update yF_Tj set TJWH=@tjwh,ZXRQ=@ZXRQ,WCBJ=@WCBJ,BDELETE=@BDELETE,BZ=@BZ 
       ,bljzx=@BLJZX,tjxs=@TJXS,bpltj=@BPLTJ
   	   WHERE ID=@ID AND DEPTID=@DEPTID
	   if @@rowcount=0 
           begin
			  set @ERR_TEXT='更新单据头没有成功，影响到数据库0行'
			  return
           end
	   set @djid=@id
	   SET @ERR_TEXT='调价单头表保存成功'
end
 
 
  SET @ERR_CODE=0
end


