IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_pd_insert_dj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_pd_insert_dj
GO
CREATE PROCEDURE sp_YF_pd_insert_dj
(
 	@djh bigint,
	@DEPTID INTEGER,
	@sdjh varchar(20),
	@djid UNIQUEIDENTIFIER output ,
	@ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(100) output,
	@jgbm bigint
)

as
 begin
declare @ncount int ;
declare @ywlx char(3)
declare @rq varchar(30)
declare @djy int
declare @djrq varchar(30)
declare @djsj varchar(30)
declare @bz varchar(100)
declare @kslx varchar(10)
 set @Err_Code=-1;
 set @Err_Text='';
 
 if @djh=0 
begin
   	    set @err_text='单据号为零请重新确认';
	    return;
end
 
 if @deptid=0 
begin
   	    set @err_text='科室ID为零请重新确认';
	    return;
end

set @kslx=(select kslx from yp_yjks where deptid=@deptid)
set @djid=dbo.FUN_GETEMPTYGUID()
--保存单据头表fg
 declare t1 cursor local for 
           select ywlx,rq,djy,dbo.fun_getdate(djrq) djrq,convert(nvarchar,djrq,114) djsj,bz from YF_pd  where  deptid=@deptid and djh=@djh 
           --and id in(select djid from yf_pdmx where deptid=@deptid and djh=@djh and  pcs<>zcs)
open  t1
fetch next from t1 into @ywlx,@rq,@djy,@djrq,@djsj,@bz
while @@FETCH_STATUS=0
begin
	set @DJID=dbo.FUN_GETGUID(newid(),getdate())
	if rtrim(@kslx)='药库'
	begin
		  insert into Yk_dj(id,jgbm,djh,sdjh,deptid,ywlx,rq,djy,djrq,djsj,bz)
		  values(@djid,@jgbm,@djh,@sdjh,@deptid,@ywlx,@rq,@djy,@djrq,@djsj,@bz) 
	end
 	else
	begin
	  insert into YF_dj(id,jgbm,djh,SDJH,deptid,ywlx,rq,djy,djrq,djsj,bz)
	  values(@djid,@jgbm,@djh,@SDJH,@deptid,@ywlx,@rq,@djy,@djrq,@djsj,@bz) 
	 end
	
	if @@rowcount=0
	begin
		  set @err_text='插入单据表没有成功，影响到数据库0行'+char(@@rowcount);
		  return;
	end


	IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL 
	begin
		  SET @ERR_TEXT='DJID为零,请重试';
		  return;
	end
		
	
	--保存单据明细
	if rtrim(@kslx)='药库'
	begin
		insert into YK_djmx(id,djid,CJID,KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,YPSL,YPDW,NYPDW,
						YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx,YPPCH,KCID)
		select dbo.FUN_GETGUID(newid(),getdate()),@djid,b.cjid,kwid,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,
		ypph,YPXQ,0 ,(pcs-zcs),ypdw,0 ,ydwbl,jhj,b.pfj,b.lsj,round(jhj*(pcs-zcs),3) jhje,(pcpfje-zcpfje),
		(pclsje-zclsje),a.djh,a.deptid,ywlx,YPPCH,KCID 
		from YF_pd a,YF_pdmx b,yp_ypcjd c where a.id=b.djid and b.cjid=c.cjid and a.djh=@djh and a.deptid=@deptid and pcs<>zcs;
	end
        else
	begin
		insert into YF_djmx(id,djid,CJID,KWID,shh,yppm,ypspm,ypgg,sccj,
		YPPH,YPXQ,YPKL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx ,yppch,KCID)
		select dbo.FUN_GETGUID(newid(),getdate()),@djid,b.cjid,kwid,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,
		ypph,YPXQ,0 ,(pcs-zcs),ypdw,0 ,ydwbl,jhj,b.pfj,b.lsj,round(jhj*(pcs-zcs),3) jhje,
		(pcpfje-zcpfje),(pclsje-zclsje),a.djh,a.deptid,ywlx,YPPCH,KCID 
		from YF_pd a,YF_pdmx b,yp_ypcjd c where a.id=b.djid and b.cjid=c.cjid and a.djh=@djh and a.deptid=@deptid and pcs<>zcs;
	end
	--if @@rowcount=0 
	--begin
	--	    set @err_text='插入单据明细表没有成功，影响到数据库0行'+@kslx
	--	    return;
	--end


    fetch next from t1 into @ywlx,@rq,@djy,@djrq,@djsj,@bz
end 

CLOSE t1
DEALLOCATE t1


SET @ERR_CODE=0;
SET @ERR_TEXT='保存成功';
end;


