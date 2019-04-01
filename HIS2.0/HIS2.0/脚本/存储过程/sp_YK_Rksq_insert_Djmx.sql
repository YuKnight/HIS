IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YK_Rksq_insert_Djmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YK_Rksq_insert_Djmx
GO
create PROCEDURE sp_YK_Rksq_insert_Djmx      
(      
  @djh bigint,--药库出库单号      
 @DEPTID INTEGER,--药库科室ID      
 @sqdh bigint,--领药科室申请单据号      
 @sqks int,--领药科室      
 @ywlx char(3),      
 @DJID UNIQUEIDENTIFIER output,      
 @ERR_CODE INTEGER output,      
    @ERR_TEXT VARCHAR(100) output,      
 @tojgbm bigint, --目的医院      
    @ydjid UNIQUEIDENTIFIER --原单据ID      
)      
/*      
  药库出库单转换成药房药库出库单      
*/      
as      
 begin      
      
declare @ncount int       
  
  
declare @jsr int      
declare @rq varchar(50)      
declare @djy int      
declare @djrq varchar(50)      
declare @djsj varchar(50)      
declare @bz varchar(100)      
      
declare @sumjhje decimal(15,2)      
declare @sumpfje decimal(15,2)      
declare @sumlsje decimal(15,2)      
       
set @Err_Code=-1      
set @Err_Text=''      
       
if @djh=0       
begin      
       set @err_text='单据号为零请重新确认'      
       return      
end      
       
if @deptid=0       
begin      
    set @err_text='科室ID为零请重新确认'      
 return      
end      
       
if rtrim(@ywlx)=''       
begin      
     set @err_text='业务类型为空请重新确认'      
  return      
end      
       
set @err_text='插入表头'      
        
      
--原单据信息      
select @jsr=jsr,@rq=rq,@djy=djy,@djrq=djrq,@djsj=djsj,@bz=bz,@sumjhje=sumjhje,@sumpfje=sumpfje,@sumlsje=sumlsje from yk_dj       
where deptid=@deptid and djh=@djh and ywlx=@ywlx      
      
set @DJID=dbo.FUN_GETGUID(newid(),getdate())      
      
--插入药房单据头 药库出库单      
if @ywlx='003'       
begin      
 --验证药品管理类型      
 if EXISTS(      
 select * from yk_djmx a,yp_ypcjd b where a.cjid=b.cjid and deptid=@deptid and djh=@djh and ywlx=@ywlx      
 and b.n_ypzlx not in(      
 select ypzlx from yp_gllx where deptid=@sqks))      
 begin      
   SET @ERR_TEXT='对方库房管理的药品子类型,不包含上列某些药品,请核实'      
   return      
 end      
     
 update yp_djh set djh=djh+1 where ywlx='016' and deptid=@sqks    
 set @djh=(select djh from yp_djh  where ywlx='016' and deptid=@sqks)    
 --插入单据头      
 insert into yF_dj(ID,jgbm,djh,deptid,ywlx,wldw,jsr,rq,djy,djrq,djsj,bz,sqdh,sumjhje,sumpfje,sumlsje,YDJID)      
 values(@DJID,@tojgbm,@djh,@sqks,'016',@deptid,@jsr,@rq,@djy,@djrq,@djsj,@bz,@sqdh,@sumjhje,@sumpfje,@sumlsje,@ydjid)      
      
 IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL       
 begin      
     SET @ERR_TEXT='DJID为零,请重试'      
     return      
 end      
      
    --插入单据明细      
 set @err_text='插入表明细'      
 insert into yF_djmx(ID,djid,CJID,KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx,BZ,PXXH,yppch,kcid)      
 select dbo.FUN_GETGUID(newid(),getdate()),@djid,CJID,0 KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,@DJH,@SQKS,'016',BZ ,PXXH,yppch,dbo.FUN_GETEMPTYGUID()        
 from yk_djmx where djid=@ydjid --deptid=@deptid and djh=@djh and ywlx=@ywlx   
      
end      
      
--药库同级出库      
if @ywlx='030'       
begin      
      
 --验证药品管理类型      
 if EXISTS(      
 select * from yk_djmx a,yp_ypcjd b where a.cjid=b.cjid and deptid=@deptid and djh=@djh and ywlx=@ywlx      
 and b.n_ypzlx not in(      
 select ypzlx from yp_gllx where deptid=@sqks))      
 begin      
   SET @ERR_TEXT='对方库房管理的药品子类型,不包含上列某些药品,请核实'      
   return      
 end      
      
 update yp_djh set djh=djh+1 where ywlx='031' and deptid=@sqks    
 set @djh=(select djh from yp_djh  where ywlx='031' and deptid=@sqks)    
     
 --插入单据头      
 insert into yk_dj(ID,jgbm,djh,deptid,ywlx,wldw,jsr,rq,djy,djrq,djsj,bz,sqdh,sumjhje,sumpfje,sumlsje,YDJID)      
 values(@DJID,@tojgbm,@djh,@sqks,'031',@deptid,@jsr,@rq,@djy,@djrq,@djsj,@bz,@sqdh,@sumjhje,@sumpfje,@sumlsje,@ydjid)      
      
 IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL       
 begin      
     SET @ERR_TEXT='DJID为零,请重试'      
     return      
 end      
      
 --插入单据明细      
 set @err_text='插入表明细'      
 insert into yk_djmx(ID,djid,CJID,KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx,BZ,PXXH,yppch,kcid)      
 select dbo.FUN_GETGUID(newid(),getdate()),@djid,CJID,0 KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,@DJH,@SQKS,'031',BZ ,PXXH,yppch,dbo.FUN_GETEMPTYGUID()         
 from yk_djmx where djid=@ydjid --deptid=@deptid and djh=@djh and ywlx=@ywlx      
end      
       
 SET @ERR_CODE=0;      
 SET @ERR_TEXT='保存成功'      
end      
      