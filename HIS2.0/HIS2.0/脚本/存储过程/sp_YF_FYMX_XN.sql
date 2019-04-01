


IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_FYMX_XN' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_FYMX_XN
GO
CREATE PROCEDURE sp_YF_FYMX_XN
(
 	@fyid UNIQUEIDENTIFIER,
	@FPH BIGINT ,
	@CFXH UNIQUEIDENTIFIER,
	@CJID INT ,
	@YPHH VARCHAR(20),
	@YPPM VARCHAR(100),
	@YPSPM VARCHAR(100),
	@YPGG VARCHAR(50),
	@YPCJ VARCHAR(100),
	@YPDW VARCHAR(10),
	@DWBL INT ,
	@YPSL DECIMAL(15,3) ,
	@CFTS INT ,
	@PFJ DECIMAL(15,4) ,
	@PFJE DECIMAL(15,3) ,
	@LSJ DECIMAL(15,4) ,
	@LSJE DECIMAL(15,3) ,
	@Tlsje DECIMAL(15,3) ,
	@Tpfje DECIMAL(15,3) ,
	@deptid int,
	@tyid UNIQUEIDENTIFIER,
	@ypph varchar(20),
	@id UNIQUEIDENTIFIER,
	@cfmxid UNIQUEIDENTIFIER,
	@psbz varchar(20),--皮试结果
	@syff varchar(50),--用法
	@zt varchar(50),--嘱托
	@yf varchar(50),
	@pc varchar(50),
	@jl varchar(50),
	@jldw varchar(50),
	@ts decimal(10,1),
	@zbz int,
	@pxxh int,
	@fymxid UNIQUEIDENTIFIER output,
	@ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(250) output
) 
AS
 begin
 --declare @fymxid bigint default 0--发药明细ID
declare @xpfj decimal(15,3)
declare @xlsj decimal(15,3) 
declare @xdwbl int
declare @bkc int 
declare @ckl decimal(15,3)
declare @dqckl decimal(15,3)
declare @ys decimal(15,3)

 declare @jhj decimal(15,4)  --进价
 declare @jhje decimal(15,3) --进货金额
 set @jhj=0
 set @jhje=0
 
set @ERR_CODE=-1
set @ERR_TEXT=''
--set @fymxid=0
 
if @CJID=0 
begin
   	    set @ERR_TEXT='CJID为零'
	    return
end
 
if @cfxh=dbo.FUN_GETEMPTYGUID() or @cfxh is null
begin
   	    set @ERR_TEXT='处方序号为零'
	    return
end  
 
 
----是否强制控制库存变量
--set @bkc=(select zt from yk_config where bh='101' and deptid=@deptid )
--set @bkc=coalesce(@bkc,0)
 
-- --计算出库量
--set @ckl=(select @ypsl*@CFTS*dwbl/@dwbl from YF_kcmx where cjid=@cjid and deptid=@deptid)
--if @ckl is null 
--begin
-- 	   set @ERR_TEXT='找不到库存记录,发药没有成功'
--	   set @ERR_CODE=-1
--	   return
--end

----初始余数
--set @ys=@ckl
 
-- --计算调价误差
--select @xpfj=pfj,@xlsj=lsj,@xdwbl=dwbl  from vi_yf_kcmx where cjid=@cjid and deptid=@deptid
--if @xlsj is null 
--begin
-- 	 set @ERR_CODE=-1
--	 set @ERR_TEXT='没有找到库存记录,发药没有成功'
--	 return
--end 
 
set @tpfje=0
set @tlsje=0
 
--if (@pfj*@dwbl)-@xpfj<>0 
--   set @tpfje=@pfje-round(@xpfj*@ckl/@xdwbl,3)

 
--if (@lsj*@dwbl)-@xlsj<>0 
--   set @tlsje=@lsje-round(@xlsj*@ckl/@xdwbl,3)

 
  --插入发药明细表
 --如果当前明细ID为零就插入
if @id=dbo.FUN_GETEMPTYGUID() or @id is null
begin
	set @fymxid=dbo.FUN_GETGUID(newid(),getdate())
 	insert into yf_FYMX(id,fyid,FPH,CFXH,CJID,YPHH,YPPM,YPSPM,YPGG,YPCJ,YPDW,YDWBL,YPSL,cfts,PFJ,PFJE,LSJ,LSJE,Tpfje,tlsje,deptid,tyid,cfmxid,CFMXIDBK,psbz,syff,zt,
				yf,pc,jl,jldw,ts,zbz,pxxh)
 	values(@fymxid,@fyid,@FPH,@CFXH,@CJID,@YPHH,@YPPM,@YPSPM,@YPGG,@YPCJ,@YPDW,@DWBL,@YPSL,@CFTS,@PFJ,@PFJE,@LSJ,@LSJE,@tpfje,@tlsje,@deptid,@tyid,@cfmxid,@cfmxid,@psbz,@syff,@zt,
				@yf,@pc,@jl,@jldw,@ts,@zbz,@pxxh)
 	
 	if @@rowcount=0 or @fymxid=dbo.FUN_GETEMPTYGUID() or @fymxid is null 
	begin
	    set @ERR_TEXT='插入发药明细表没有成功，影响到数据库0行'
	    return
	end
 end
 --如果头ID没有则不更新库存记录
if @fyid=dbo.FUN_GETEMPTYGUID() OR @FYID IS NULL 
begin
         SET @ERR_TEXT='保存成功'
	 SET @ERR_CODE=0
	 return
end
 
	 
SET @ERR_TEXT='保存成功'
SET @ERR_CODE=0

end