IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YP_TJ_YMJCMX' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YP_TJ_YMJCMX
GO
CREATE PROCEDURE sp_YP_TJ_YMJCMX 
(
	@YJID uniqueidentifier,
    @ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(250) output
)
as

/*
declare @err_code int
declare @err_text varchar(300)
exec sp_YP_TJ_YMJCMX @YJID='5AC80911-B051-47F9-849B-A36100C31F95',@err_code=@err_code output,@err_text=@err_text output
select @err_code,@err_text

select * from yp_kjqj
*/
begin
 
declare @deptid int
declare @YK SMALLINT --药库
declare @SCYJID uniqueidentifier --上次月结ID
declare @jsrq datetime --本月结帐结束日期
declare @jgbm bigint

SET @ERR_CODE=-1
select @YK = (CASE when KSLX='药库' then 1 else 0 end),@jsrq=JSRQ,@deptid=A.DEPTID,@jgbm=SZJGBM
from YP_YJKS A inner join YP_KJQJ b on a.deptid=b.deptid where  b.id=@YJID

IF @YK is null
begin
 set @ERR_TEXT='没有找到月结记录'  
 return
end

--获得上次月结的ID
select top 1 @SCYJID=id 
from   YP_KJQJ   where  DEPTID=@deptid and JSRQ<@jsrq order by JSRQ desc

--如果存在就删除
IF EXISTS (select * from YP_TJ_YMJCMX where yjid=@YJID)
	delete  YP_TJ_YMJCMX where yjid=@YJID
		

-------------------------------------------------------药库---------------------------------------------------------------------------
if @YK=1 
begin
	--汇总上月结存记录
	insert into YP_TJ_YMJCMX(DEPTID,YJID,YWLX,WLDWLX,WLDW,WLDWMC,KCID,CJID,YPSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJY,DJSJ,JGBM)
	select DEPTID,@YJID,'000' as ywlx,0 as wldwlx,0 wldw,'' wldwmc,KCID,CJID,JCSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JCJHJE,JCPFJE,JCLSJE,0,GETDATE(),@jgbm
	from YK_YMJC where YJID=@SCYJID
	if @@ROWCOUNT=0
		insert into YP_TJ_YMJCMX(DEPTID,YJID,YWLX,WLDWLX,WLDW,WLDWMC,KCID,CJID,YPSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJY,DJSJ,JGBM)
		select @DEPTID,@YJID,'000' as ywlx,0 as wldwlx,0 wldw,'' wldwmc,null,0 CJID,0 JCSL,'' YPDW,1 YDWBL,0 JHJ,0 PFJ,0 LSJ,0 JCJHJE,0 JCPFJE,0 JCLSJE,0,GETDATE(),@jgbm
		
	--汇总当月发生
	insert into YP_TJ_YMJCMX(DEPTID,YJID,YWLX,WLDWLX,WLDW,WLDWMC,KCID,CJID,YPSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJY,DJSJ,JGBM,SHDH)
	SELECT A.DEPTID,A.YJID,A.YWLX,
			(case when A.YWLX in('001','002','016') then 1  else 2 end) as wldwlx,
			a.WLDW,(case when A.YWLX in('001','002','016') then dbo.fun_yp_ghdw(a.wldw)  else dbo.fun_getDeptname(a.wldw) end) as wldwmc,
			b.KCID,b.CJID,SUM((ypsl*c.DWBL)/b.ydwbl) as ypsl,dbo.fun_yp_ypdw(c.ZXDW) as ypdw,c.DWBL as ydwbl,
			round(b.JHJ*b.YDWBL/c.DWBL,4) as jhj,round(b.pfj*b.YDWBL/c.DWBL,4) as pfj,round(b.lsj*b.YDWBL/c.DWBL,4) as lsj,
			sum(b.JHJE),sum(b.PFJE),sum(b.LSJE),0,GETDATE(),@jgbm ,B.SHDH
			FROM Yk_DJ A (nolock),Yk_DJMX B (nolock),Yk_KCPH c (nolock)
			WHERE a.id=b.djid AND b.KCID=c.ID  and  yjid=@yjid  
			group by A.DEPTID,A.YJID,A.YWLX,A.WLDW,b.kcid,b.cjid,B.SHDH,c.ZXDW,c.DWBL,round(b.JHJ*b.YDWBL/c.DWBL,4),
			round(b.pfj*b.YDWBL/c.DWBL,4),round(b.lsj*b.YDWBL/c.DWBL,4)

	--汇总本月结存
	insert into YP_TJ_YMJCMX(DEPTID,YJID,YWLX,WLDWLX,WLDW,WLDWMC,KCID,CJID,YPSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJY,DJSJ,JGBM)
	select DEPTID,@YJID,'999' as ywlx,0 as wldwlx,0 wldw,'' wldwmc,KCID,CJID,JCSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JCJHJE,JCPFJE,JCLSJE,0,GETDATE(),@jgbm
	from YK_YMJC where YJID=@YJID

end

-------------------------------------------------------药房---------------------------------------------------------------------------
if @YK=0
begin
	--汇总上月结存记录
	insert into YP_TJ_YMJCMX(DEPTID,YJID,YWLX,WLDWLX,WLDW,WLDWMC,KCID,CJID,YPSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJY,DJSJ,JGBM)
	select DEPTID,@YJID,'000' as ywlx,0 as wldwlx,0 wldw,'' wldwmc,KCID,CJID,JCSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JCJHJE,JCPFJE,JCLSJE,0,GETDATE(),@jgbm
	from YF_YMJC where YJID=@SCYJID
	
   if @@ROWCOUNT=0
		insert into YP_TJ_YMJCMX(DEPTID,YJID,YWLX,WLDWLX,WLDW,WLDWMC,KCID,CJID,YPSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJY,DJSJ,JGBM)
		select @DEPTID,@YJID,'000' as ywlx,0 as wldwlx,0 wldw,'' wldwmc,null,0 CJID,0 JCSL,'' YPDW,1 YDWBL,0 JHJ,0 PFJ,0 LSJ,0 JCJHJE,0 JCPFJE,0 JCLSJE,0,GETDATE(),@jgbm
		

	--汇总当月发生
	insert into YP_TJ_YMJCMX(DEPTID,YJID,YWLX,WLDWLX,WLDW,WLDWMC,KCID,CJID,YPSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJY,DJSJ,JGBM,SHDH)
	SELECT A.DEPTID,A.YJID,A.YWLX,
			(case when A.YWLX in('001','002','016') then 1  else 2 end) as wldwlx,
			a.WLDW,(case when A.YWLX in('001','002','016') then dbo.fun_yp_ghdw(a.wldw)  else dbo.fun_getDeptname(a.wldw) end) as wldwmc,
			b.KCID,b.CJID,SUM((ypsl*c.dwbl)/b.ydwbl) as ypsl,dbo.fun_yp_ypdw(c.ZXDW) as ypdw,c.DWBL as ydwbl,
			round(b.JHJ*b.YDWBL/c.DWBL,4) as jhj,round(b.pfj*b.YDWBL/c.DWBL,4) as pfj,round(b.lsj*b.YDWBL/c.DWBL,4) as lsj,
			sum(b.JHJE),sum(b.PFJE),sum(b.LSJE),0,GETDATE(),@jgbm ,B.SHDH
			FROM YF_DJ A (nolock),YF_DJMX B (nolock),YF_KCPH c (nolock)
			WHERE a.id=b.djid AND b.KCID=c.ID  and  yjid=@yjid  
			group by A.DEPTID,A.YJID,A.YWLX,A.WLDW,b.kcid,b.cjid,B.SHDH,c.ZXDW,c.DWBL,round(b.JHJ*b.YDWBL/c.DWBL,4),
			round(b.pfj*b.YDWBL/c.DWBL,4),round(b.lsj*b.YDWBL/c.DWBL,4)

	--汇总本月结存
	insert into YP_TJ_YMJCMX(DEPTID,YJID,YWLX,WLDWLX,WLDW,WLDWMC,KCID,CJID,YPSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJY,DJSJ,JGBM)
	select DEPTID,@YJID,'999' as ywlx,0 as wldwlx,0 wldw,'' wldwmc,KCID,CJID,JCSL,YPDW,YDWBL,JHJ,PFJ,LSJ,JCJHJE,JCPFJE,JCLSJE,0,GETDATE(),@jgbm
	from YF_YMJC where YJID=@YJID

end


set @ERR_CODE=0
set @ERR_TEXT='保存成功'  

end 