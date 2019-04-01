
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_updatekcmx_xnkcl' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_updatekcmx_xnkcl
GO

CREATE PROCEDURE sp_yf_updatekcmx_xnkcl
(
	@cjid int,
	@ypsl decimal(15,3),
	@ydwbl int,
    @deptid int,
    @err_code int output,
    @Err_Text VARCHAR(200)output
)

as

begin
 
set @Err_Code=-1
set @Err_Text=''

declare @yppm varchar(100)
declare @ypgg varchar(100)
declare @sccj varchar(100)
declare @kcl decimal(15,3)
declare @xnkcl decimal(15,3)
declare @ypdw varchar(10)

update yf_kcmx set xnkcl=xnkcl+((@ypsl*dwbl)/@Ydwbl) 
where   deptid=@deptid and cjid=@cjid and  xnkcl+((@ypsl*dwbl)/@Ydwbl) >=0
if @@rowcount=0
begin
	 select @yppm=s_yppm,@ypgg=s_ypgg,@sccj=s_sccj,@kcl=kcl,@xnkcl=xnkcl,@ypdw=dbo.fun_yp_ypdw(zxdw)
	 from yp_ypcjd a,yf_kcmx b  where a.cjid=b.cjid and a.cjid=@cjid and b.deptid=@deptid
	 
	 set @ERR_TEXT=@yppm+' '+@ypgg +' 库存量不足,帐面库存为:'+cast(cast(@kcl as float) as varchar(30))
	 +@ypdw+' 虚库存为:'+cast(cast(@xnkcl as float) as varchar(30))+@ypdw;
	 return;
end  


SET @Err_Code=0
SET @Err_Text='保存成功'

end