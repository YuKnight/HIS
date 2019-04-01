IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_TJ_EXEC' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_TJ_EXEC
GO

  
CREATE PROCEDURE SP_YK_TJ_EXEC  
 (  @djid UNIQUEIDENTIFIER,  
    @deptid integer,  
    @sdjh VARCHAR(20) output,  
    @ERR_CODE INTEGER output ,  
    @ERR_TEXT VARCHAR(250) output,  
 @jgbm bigint  
 )    
as  
  
declare @ssdjh varchar(20)  
declare @t1_djid UNIQUEIDENTIFIER  
declare @t1_ywlx char(3)  
declare @t1_djh bigint  
declare @t1_tjwh varchar(50)  
declare @t1_djy int  
declare @t1_djrq varchar(30)  
declare @t1_zxrq varchar(30)  
declare @t1_deptid int  
declare @t1_bz varchar(100)  
  
declare @t1_ppbz bit  
declare @t1_whmxid uniqueidentifier  
declare @t1_zglsj decimal(15,4)   
  
declare @t1_bljzx bit  
declare @t1_tjxs decimal(15,4)  
declare @t1_bpltj bit  
  
  
declare @t2_xpfj decimal(15,4)  
declare @t2_xlsj decimal(15,4)  
declare @t2_cjid int  
declare @t2_ytjsl decimal(15,4) --原调价数量  
  
declare @t2_mrjj decimal(15,4)  
  
declare @bpcgl int =0 --是否进行批次管理  
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--暂时设定为999  
  
declare @btjhj varchar ='0' --是否调进价（批次管理下）  
if @bpcgl =1  
begin  
 select @btjhj=config from JC_CONFIG where ID=8056   
end  
  
declare @zxdjid uniqueidentifier --执行单据id  
  
declare @sumlsje decimal(15,4) --零售金额  
declare @sumpfje decimal(15,4) --批发金额  
declare @sumjhje decimal(15,4) --进货金额  
  
declare @count int  
   set @count =0  
  
 set @Err_Code=-1;  
 set @Err_Text='';  
  
  ---- 各科室调价明细  
  CREATE  TABLE #temp_TJ  
   (  
      deptid int,  
   ywlx char(3),   --业务类型  
   djh bigint,    --单据号  
   tjwh varchar(50),   --调价文号  
   djy int,     --登记员  
   djrq varchar(30),   --登记日期  
   zxrq varchar(30),   --执行日期  
   bz varchar(100),    --备注  
      cjid INT,     --cjid  
   tjsl DECIMAL(15,3), --调价数量  
   ypdw varchar(10),   --单位  
   ydwbl int,          --单位比例  
   ypfj DECIMAL(15,4), --原批发价  
     xpfj DECIMAL(15,4), --现零售金额  
   ylsj DECIMAL(15,4), --原零售价  
   xlsj DECIMAL(15,4), --现零售金额  
   tpfje DECIMAL(15,2), --调批发金额  
     tlsje DECIMAL(15,2), --调零售金额  
   djbz varchar(50),    --单据备注  
      ytjsl decimal(15,4), --已调价数量  
        
      ppbz bit,--匹配标志  
      whmxid uniqueidentifier, --文号明细id  
      zglsj  decimal(15,4),     --匹配最高零售价  
        
        
      bljzx bit ,       --立即执行  
      tjxs decimal(15,4),--调价系数  
      bpltj bit,          --批量调价  
        
   yjhj decimal(15,4), --原进货价  
   xjhj decimal(15,4), --现进货价  
   tjhje decimal(15,4) --调进货金额  
   )   
     
  CREATE  TABLE #temp_TJ_ph  
   (  
      deptid int,  
   ywlx char(3),   --业务类型  
   djh bigint,    --单据号  
   tjwh varchar(50),   --调价文号  
   djy int,     --登记员  
   djrq varchar(30),   --登记日期  
   zxrq varchar(30),   --执行日期  
   bz varchar(100),    --备注  
      cjid INT,     --cjid  
   tjsl DECIMAL(15,3), --调价数量  
   ypdw varchar(10),   --单位  
   ydwbl int,          --单位比例  
   ypfj DECIMAL(15,4), --原批发价  
     xpfj DECIMAL(15,4), --现零售金额  
   ylsj DECIMAL(15,4), --原零售价  
   xlsj DECIMAL(15,4), --现零售金额  
   tpfje DECIMAL(15,2), --调批发金额  
     tlsje DECIMAL(15,2), --调零售金额  
   djbz varchar(50),    --单据备注  
      ytjsl decimal(15,4) --已调价数量  
        
      ,ypph varchar(30),--批号  
      ypxq char(10),--效期  
      yppch varchar(100),--批次号  
      kcid uniqueidentifier, --kcid  
        
      yjhj decimal(15,4), --原进货价  
   xjhj decimal(15,4), --现进货价  
   tjhje decimal(15,4) --调进货金额  
   )   
  
  
   
if @bpcgl = 0 --不进行批次管理  
    begin  
      insert into #temp_TJ     
   select c.deptid,a.ywlx,a.djh,a.tjwh,a.djy,a.djrq,a.zxrq,a.bz,c.cjid,cast(round((kcl/dwbl),3) as decimal(15,3)) tjsl,    
   b.ypdw,b.ydwbl,b.ypfj,b.xpfj,b.ylsj,b.xlsj,cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xpfj-b.ypfj),    
    cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xlsj-b.ylsj),'' djbz,b.tjsl ytjsl    
   from yf_tj a,    
     yf_tjmx b ,    
     yk_kcmx c    
   where a.id=b.djid and b.cjid=c.cjid  and a.id=@djid    
   --and    
   --(c.deptid=@deptid or c.deptid in(select deptid from yp_yjks_gx where p_deptid=@deptid))    
       
   --调价验证    
   if exists( select * from (select  cjid,ytjsl,sum(tjsl) tjsl from #temp_tj where  (deptid=@deptid or deptid  in(select deptid from yp_yjks_gx where p_deptid=@deptid)) group by  cjid,ytjsl) a     
   where tjsl<>ytjsl   )    
   begin    
      set @err_text='发生错误，调价没有成功。库存可能已变化请重新刷新aa'     
      return    
   end      
   declare t1 cursor for  select ywlx,djh,tjwh,djy,djrq,zxrq,deptid,bz  from #temp_TJ group by ywlx,djh,tjwh,djy,djrq,zxrq,deptid,bz;  
   open  t1  
  
   fetch next from t1 into @t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,@t1_deptid,@t1_bz  
  
   while @@FETCH_STATUS=0  
   begin  
      if @t1_deptid<>@deptid   
      begin  
       --插入调价表头    
      set @t1_djid=dbo.FUN_GETGUID(newid(),getdate())  
      insert into yf_Tj(ID,jgbm,YWLX,DJH,TJWH,DJY,DJRQ,ZXRQ,WCBJ,BDELETE,DEPTID,BZ)values(@t1_djid,@jgbm,@t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,1,0,@t1_deptid,@t1_bz)  
      if @t1_djid=dbo.FUN_GETEMPTYGUID() or @t1_djid is null  
         begin  
          set @err_text='插入调价表出错'  
         return;  
      end  
       
  
        --插入调价明细  
        insert into yf_tjmx(ID,djid,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,tpfje,ylsj,xlsj,tlsje,deptid,djh)  
        select dbo.FUN_GETGUID(newid(),getdate()),@t1_djid,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,tpfje,ylsj,xlsj,tlsje,deptid,djh   
        from #temp_TJ WHERE deptid=@t1_deptid;  
      END  
  
     --生成sdjh单据号  
       UPDATE YP_DJH SET nDJH=nDJH+1 WHERE DEPTID=@t1_deptid AND YWLX=@t1_ywlx;  
       SET @ssDJH=(SELECT sdjh+'--'+rtrim(nDJH) FROM yp_djh where DEPTID=@t1_deptid AND YWLX=@t1_ywlx);  
       if @t1_deptid=@deptid   
       set @sdjh=@ssdjh  
  
     --插入单据表头  
     set @t1_djid=dbo.FUN_GETGUID(newid(),getdate())  
     insert into yk_dj(ID,jgbm,djh,sdjh,deptid,ywlx,wldw,rq,djy,djrq,djsj,bz,shbz,shrq,shy)  
          values(@t1_djid,@jgbm,@t1_djh,@ssdjh,@t1_deptid,@t1_ywlx,@deptid,dbo.fun_getdate(@t1_zxrq),@t1_djy,dbo.fun_getdate(@t1_zxrq),convert(nvarchar,@t1_zxrq,108),  
       @t1_bz,1,@t1_zxrq,@t1_djy);  
     if @t1_djid=dbo.FUN_GETEMPTYGUID() or @t1_djid is null  
      begin  
        set @err_text='插入业务表出错'  
       return;  
     end  
     --插入单据明细  
      insert into yk_djmx(ID,DJID,CJID,shh,yppm,ypspm,ypgg,sccj,KWID,YPPH,YPXQ,YPKL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx,bz)  
        select dbo.FUN_GETGUID(newid(),getdate()),@t1_djid,a.cjid,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,0,'','',0,tjsl,ypdw,0,ydwbl,0,xpfj,xlsj,0,tpfje,tlsje,djh,deptid,ywlx,djbz  
         from #temp_TJ a,yp_ypcjd b where a.cjid=b.cjid and deptid=@t1_deptid;  
  
  
    fetch next from t1 into @t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,@t1_deptid,@t1_bz  
  
      
   end  
   CLOSE t1  
   DEALLOCATE t1  
  
    -----------------------------------药房调价-----------------------------  
   delete from #temp_TJ  
   insert into #temp_TJ  
   select c.deptid,a.ywlx,a.djh,a.tjwh,a.djy,a.djrq,a.zxrq,a.bz,c.cjid,cast(round((kcl/dwbl),3) as decimal(15,3)) tjsl,  
   b.ypdw,b.ydwbl,b.ypfj,b.xpfj,b.ylsj,b.xlsj,cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xpfj-b.ypfj),  
    cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xlsj-b.ylsj),'' djbz,b.tjsl ytjsl  
   from yf_tj a,  
     yf_tjmx b ,  
     yf_kcmx c  
   where a.id=b.djid and b.cjid=c.cjid and a.id=@djid   
      
   declare t2 cursor for  select ywlx,djh,tjwh,djy,djrq,zxrq,deptid,bz from #temp_TJ group by ywlx,djh,tjwh,djy,djrq,zxrq,deptid,bz;  
   open  t2  
  
   fetch next from t2 into @t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,@t1_deptid,@t1_bz  
  
   while @@FETCH_STATUS=0  
   begin  
   if @t1_deptid<>@deptid   
   begin  
     --插入调价表头    
     set @t1_djid=dbo.FUN_GETGUID(newid(),getdate())  
     insert into yf_Tj(ID,jgbm,YWLX,DJH,TJWH,DJY,DJRQ,ZXRQ,WCBJ,BDELETE,DEPTID,BZ)values(@t1_djid,@jgbm,@t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,1,0,@t1_deptid,@t1_bz)  
     if @t1_djid=dbo.FUN_GETEMPTYGUID() or @t1_djid is null  
      begin  
        set @err_text='插入调价表出错'  
       return;  
     end  
     --插入调价明细  
     insert into yf_tjmx(ID,djid,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,tpfje,ylsj,xlsj,tlsje,deptid,djh)  
     select dbo.FUN_GETGUID(newid(),getdate()),@t1_djid,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,tpfje,ylsj,xlsj,tlsje,deptid,djh   
     from #temp_TJ WHERE deptid=@t1_deptid;  
   end  
  
   --生成sdjh单据号  
   UPDATE YP_DJH SET nDJH=nDJH+1 WHERE DEPTID=@t1_deptid AND YWLX=@t1_ywlx;  
   SET @ssDJH=(SELECT sdjh+'--'+rtrim(nDJH) FROM yp_djh where DEPTID=@t1_deptid AND YWLX=@t1_ywlx);  
   if @t1_deptid=@deptid   
        set @sdjh=@ssdjh  
  
   --插入单据表头  
   set @t1_djid=dbo.FUN_GETGUID(newid(),getdate())  
   insert into yf_dj(ID,jgbm,djh,sdjh,deptid,ywlx,wldw,rq,djy,djrq,djsj,bz,shbz,shrq,shy)  
          values(@t1_djid,@jgbm,@t1_djh,@ssdjh,@t1_deptid,@t1_ywlx,@deptid,dbo.fun_getdate(@t1_zxrq),@t1_djy,dbo.fun_getdate(@t1_zxrq),convert(nvarchar,@t1_zxrq,108),  
       @t1_bz,1,@t1_zxrq,@t1_djy);  
   if @t1_djid=dbo.FUN_GETEMPTYGUID() or @t1_djid is null  
    begin  
      set @err_text='插入业务表出错'  
     return;  
   end  
  
   --插入单据明细  
   insert into yf_djmx(ID,DJID,CJID,shh,yppm,ypspm,ypgg,sccj,KWID,YPPH,YPXQ,YPKL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx,bz)  
    select dbo.FUN_GETGUID(newid(),getdate()),@t1_djid,a.cjid,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,0,'','',0,tjsl,ypdw,0,ydwbl,0,xpfj,xlsj,0,tpfje,tlsje,djh,deptid,ywlx,djbz  
     from #temp_TJ a,yp_ypcjd  b where a.cjid=b.cjid and deptid=@t1_deptid;  
  
   fetch next from t2 into @t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,@t1_deptid,@t1_bz  
  
   end  
  
   CLOSE t2  
   DEALLOCATE t2  
  
  
   --declare @t2_mrjj decimal(15,4)  
   --更改药品价格  
   declare t3 cursor for select xpfj,xlsj,cjid,mrjhj from yf_tj a,yf_tjmx b where a.id=b.djid and a.id=@djid   
   open  t3  
  
   fetch next from t3 into @t2_xpfj,@t2_xlsj,@t2_cjid,@t2_mrjj  
  
   while @@FETCH_STATUS=0  
   begin   
       update  yp_ypcjd set pfj=@t2_xpfj,lsj=@t2_xlsj,mrjj=@t2_mrjj where cjid=@t2_cjid;  
       if @@rowcount=0  
        begin  
      set @err_text='更新药品词典没有成功，影响到数据库0行';  
       return;  
       end  
     --  if EXISTS(select * from JC_CONFIG where ID=8033 and CONFIG='1')  
     --  begin  
     --update  yp_ypcjd set mrjj=@t2_xpfj where cjid=@t2_cjid;  
     --  end  
       fetch next from t3 into @t2_xpfj,@t2_xlsj,@t2_cjid,@t2_mrjj  
  
    END  
   CLOSE t3  
   DEALLOCATE t3  
  end  
else  
 begin--进行批次管理   
  -----------------------------------药库调价-----------------------------    
  insert into #temp_TJ(deptid,ywlx,djh,tjwh,djy,djrq,zxrq,bz,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,ylsj,xlsj,tpfje,tlsje,djbz,ytjsl,  
  ppbz,whmxid,zglsj,         bljzx,tjxs,bpltj,   
   yjhj,  
   xjhj,  
   tjhje)  
  select c.deptid,a.ywlx,a.djh,a.tjwh,a.djy,a.djrq,a.zxrq,a.bz,c.cjid,cast(round((c.kcl/c.dwbl),3) as decimal(15,3)) tjsl,    
  b.ypdw,b.ydwbl,b.ypfj,b.xpfj,b.ylsj,b.xlsj,  
  cast(round((c.kcl/c.dwbl),3) as decimal(15,3))*(b.xpfj-b.ypfj),    
   cast(round((c.kcl/c.dwbl),3) as decimal(15,3))*(b.xlsj-b.ylsj),  
   '' djbz,b.tjsl ytjsl  
   ,b.PPBZ,b.WHMXID,b.ZGLSJ,   a.BLJZX,a.TJXS,a.BPLTJ     
   ,  
   (case @btjhj when '1' then b.SCJHJ else 0 end ), --原进货价  
   (case @btjhj when '1' then b.MRJHJ else 0 end ), --现进货价  
   (case @btjhj when '1' then (cast(round((c.kcl/c.dwbl),3) as decimal(15,3))*(b.MRJHJ-b.SCJHJ)) else 0 end) --调进货金额  
  from yf_tj a,   
    yf_tjmx b ,    
    yk_kcmx c    
  where a.id=b.djid and b.cjid=c.cjid  and a.id=@djid   
   --and  (c.deptid=@deptid or c.deptid in (select deptid from yp_yjks_gx where p_deptid=@deptid))  
    
  insert into #temp_TJ_ph   
  select c.deptid,a.ywlx,a.djh,a.tjwh,a.djy,a.djrq,a.zxrq,a.bz,c.cjid,  
  cast(round((c.KCL/c.dwbl),3) as decimal(15,3)) tjsl,    
  b.ypdw,b.ydwbl,b.ypfj,b.xpfj,b.ylsj,b.xlsj,  
  cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xpfj-b.ypfj),    
  cast(round((c.kcl/c.dwbl),3) as decimal(15,3))*(b.xlsj-b.ylsj),'' djbz,  
  cast(round((c.kcl/c.dwbl),3) as decimal(15,3)) tjsl           --b.tjsl ytjsl  
   ,c.YPPH,c.YPXQ,c.yppch,c.ID kcid   
     ,(case @btjhj when '1' then b.SCJHJ else 0 end ), --原进货价  
      (case @btjhj when '1' then b.MRJHJ else 0 end ),  --现进货价  
      (case @btjhj when '1' then (cast(round((kcl/dwbl),3) as decimal(15,3))*(b.MRJHJ-b.SCJHJ)) else 0 end) --调进货金额  
  from yf_tj a,    
    yf_tjmx b ,    
    yk_kcph c    
  where a.id=b.djid and b.cjid=c.cjid  and a.id=@djid   
  and c.KCL<>0   
    
  --调价验证    
  if exists( select * from (select  cjid,ytjsl,sum(tjsl) tjsl from #temp_tj   
  where  (deptid=@deptid or deptid  in(select deptid from yp_yjks_gx where p_deptid=@deptid)) group by  cjid,ytjsl) a     
  where tjsl<>ytjsl   )    
  begin    
     set @err_text='发生错误，调价没有成功。库存可能已变化请重新刷新aa'     
     return    
  end     
    
  --调价验证    
  if exists(   
     select 1  from YF_TJ a inner join YF_TJMX b on a.ID=b.DJID  
           inner join YF_KCMX c on b.CJID=c.CJID  
           where c.KCL/c.DWBL<>b.TJSL/b.YDWBL and b.DEPTID=c.DEPTID and b.DEPTID=@deptid         
        )    
  begin    
     set @err_text='发生错误，调价没有成功。库存可能已变化请重新刷新(药库)'     
     return    
  end     
    
  
  declare t1 cursor for  select ywlx,djh,tjwh,djy,djrq,zxrq,deptid,bz, bljzx,tjxs,bpltj    
     from #temp_TJ group by ywlx,djh,tjwh,djy,djrq,zxrq,deptid,bz   ,bljzx,tjxs,bpltj  ;  
  open  t1  
  fetch next from t1 into @t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,@t1_deptid,@t1_bz,  @t1_bljzx,@t1_tjxs,@t1_bpltj  
  while @@FETCH_STATUS=0  
  begin  
    if @t1_deptid<>@deptid   
    begin  
      --插入调价表头    
      set @t1_djid=dbo.FUN_GETGUID(newid(),getdate())  
      insert into yf_Tj(ID,jgbm,YWLX,DJH,TJWH,  
         DJY,DJRQ,ZXRQ,WCBJ,BDELETE,  
         DEPTID,BZ  
         ,BLJZX,TJXS,BPLTJ)values(  
         @t1_djid,@jgbm,@t1_ywlx,@t1_djh,@t1_tjwh,  
         @t1_djy,@t1_djrq,@t1_zxrq,1,0,  
         @t1_deptid,@t1_bz  
         ,@t1_bljzx,@t1_tjxs,@t1_bpltj)  
      if @t1_djid=dbo.FUN_GETEMPTYGUID() or @t1_djid is null  
         begin  
        set @err_text='插入调价表出错'  
        return;  
       end  
       
      --插入调价明细  
      insert into yf_tjmx(ID,djid,cjid,tjsl,ypdw,  
          ydwbl,ypfj,xpfj,tpfje,ylsj,  
          xlsj,tlsje,deptid,djh,  
          PPBZ,WHMXID,ZGLSJ  
          ,  
          SCJHJ, --原进货价  
          MRJHJ, --现进货价  
          TJHJE --调进货金额  
          )  
        select dbo.FUN_GETGUID(  
          newid(),getdate()),@t1_djid,cjid,sum(tjsl),ypdw,  
           ydwbl,ypfj,xpfj,sum(tpfje),ylsj,  
           xlsj,sum(tlsje),deptid,djh,  
           ppbz,whmxid,zglsj    
           ,yjhj,--原进货价  
           xjhj, --现进货价  
           sum(tjhje) --调进货金额  
          from #temp_TJ     
          WHERE deptid=@t1_deptid  group by cjid,ypdw,ydwbl,ypfj,xpfj,ylsj,xlsj,deptid,djh  
                   ,yjhj,xjhj   
          ,ppbz,whmxid,zglsj     
        end   
    else  
    begin  
     set @t1_djid=@djid  
    end     
  
    --生成sdjh单据号  
       UPDATE YP_DJH SET nDJH=nDJH+1 WHERE DEPTID=@t1_deptid AND YWLX=@t1_ywlx;  
       SET @ssDJH=(SELECT sdjh+'--'+rtrim(nDJH) FROM yp_djh where DEPTID=@t1_deptid AND YWLX=@t1_ywlx);  
       if @t1_deptid=@deptid   
    set @sdjh=@ssdjh  
       
    --插入单据表头  
    set @zxdjid=dbo.FUN_GETGUID(newid(),getdate())  
    insert into yk_dj(  
      ID,jgbm,djh,sdjh,deptid,  
      ywlx,wldw,rq,djy,djrq,  
      djsj,bz,shbz,shrq,shy  
      )  
     values(  
      @zxdjid,@jgbm,@t1_djh,@ssdjh,@t1_deptid,  
      @t1_ywlx,@deptid,dbo.fun_getdate(@t1_zxrq),@t1_djy,dbo.fun_getdate(@t1_zxrq),  
      convert(nvarchar,@t1_zxrq,108),@t1_bz,1,@t1_zxrq,@t1_djy  
      )  
    if @@ROWCOUNT=0  
    begin  
      set @err_text='插入业务表出错'  
      return  
    end  
      
    --回填yf_tj表中yid  
    if(@t1_deptid<>@deptid)  
    begin  
     update YF_TJ set yid= @djid where ID=@t1_djid  
     if @@ROWCOUNT=0  
     begin  
      set @err_text='回填调价头表yid失败'  
      return  
      end  
    end  
     
    --插入单据明细  
   insert into yk_djmx(  
        ID,DJID,CJID,shh,yppm,  
        ypspm,ypgg,sccj,KWID,YPPH,  
        YPXQ,YPKL,YPSL,YPDW,NYPDW,  
        YDWBL,  
        JHJ,PFJ,LSJ,  
        JHJE,  
        PFJE,LSJE,DJH,DEPTID,ywlx,  
        bz,yppch,kcid  
        )  
        select   
        dbo.FUN_GETGUID(newid(),getdate()),@zxdjid,a.cjid,shh,s_yppm,  
        s_ypspm,s_ypgg,s_sccj,0, ypph,  
        ypxq,  0,tjsl,ypdw,0,  
        ydwbl,  
        xjhj,  --现进货价  
        xpfj,xlsj,  
        tjhje,  --调进货金额  
        tpfje,tlsje,djh,deptid,ywlx,  
        djbz,yppch,kcid      
      from #temp_TJ_ph a,yp_ypcjd b where a.cjid=b.cjid and a.deptid=@t1_deptid    
     
   --更新yk_dj表中金额 回填yf_tj表中zxdjid  
   select @sumpfje=sum(PFJE),@sumlsje=sum(LSJE),@sumjhje=SUM(JHJE),@count=COUNT(*) from YK_DJMX where DJID=@zxdjid   
   if @count<>0  
    begin  
     update YK_DJ set SUMPFJE=@sumpfje,SUMLSJE=@sumlsje,SUMJHJE=@sumjhje where ID=@zxdjid  
       
     update YF_TJ set zxdjid=@zxdjid where ID=@t1_djid  
      if @@ROWCOUNT =0  
      begin  
       set @err_text='回填调价头表zxdjid失败'  
        return  
      end   
    end  
   else  
    delete YK_DJ where ID=@zxdjid   
     
      
   fetch next from t1 into @t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,@t1_deptid,@t1_bz,  @t1_bljzx,@t1_tjxs,@t1_bpltj  
  end  
  CLOSE t1  
  DEALLOCATE t1  
    
     -----------------------------------药房调价--------------------------------  
  delete from #temp_TJ  
  insert into #temp_TJ(deptid,ywlx,djh,tjwh,djy,djrq,zxrq,bz,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,ylsj,xlsj,tpfje,tlsje,djbz,ytjsl,  
  ppbz,whmxid,zglsj,         bljzx,tjxs,bpltj  
  , yjhj,xjhj,tjhje --原进货价、现进货价、调进货金额  
   )  
  select c.deptid,a.ywlx,a.djh,a.tjwh,a.djy,a.djrq,a.zxrq,a.bz,c.cjid,cast(round((kcl/dwbl),3) as decimal(15,3)) tjsl,  
  b.ypdw,b.ydwbl,b.ypfj,b.xpfj,b.ylsj,b.xlsj,cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xpfj-b.ypfj),  
   cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xlsj-b.ylsj),'' djbz,b.tjsl ytjsl  
   ,b.PPBZ,b.WHMXID,b.ZGLSJ,   a.BLJZX,a.TJXS,a.BPLTJ   
   ,(case @btjhj when '1' then b.SCJHJ else 0 end),  
   (case @btjhj when '1' then b.MRJHJ else 0 end ),  
   (case @btjhj when '1' then (cast(round((kcl/dwbl),3) as decimal(15,3))*(b.MRJHJ-b.SCJHJ)) else 0 end) --原进货价、现进货价、调进货金额  
  from yf_tj a,  
    yf_tjmx b ,  
    YF_KCMX c  
  where a.id=b.djid and b.cjid=c.cjid and a.id=@djid   
    
  delete from #temp_TJ_ph  
  insert into #temp_TJ_ph  
  select c.deptid,a.ywlx,a.djh,a.tjwh,a.djy,a.djrq,a.zxrq,a.bz,c.cjid,  
  cast(round((kcl/dwbl),3) as decimal(15,3)) tjsl,  
  b.ypdw,b.ydwbl,b.ypfj,b.xpfj,b.ylsj,b.xlsj,cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xpfj-b.ypfj),  
  cast(round((kcl/dwbl),3) as decimal(15,3))*(b.xlsj-b.ylsj),'' djbz,  
  cast(round((kcl/dwbl),3) as decimal(15,3)) tjsl --b.tjsl ytjsl  
  ,c.YPPH,c.YPXQ,c.yppch,c.ID    
  , (case @btjhj when '1' then b.SCJHJ else 0 end ),  
  (case @btjhj when '1' then b.MRJHJ else 0 end),  
   (case @btjhj when '1' then (cast(round((kcl/dwbl),3) as decimal(15,3))*(b.MRJHJ-b.SCJHJ)) else 0 end) --原进货价、现进货价、调进货金额  
  from yf_tj a,  
    yf_tjmx b ,  
    YF_KCPH c  
  where a.id=b.djid and b.cjid=c.cjid and a.id=@djid   
  and c.KCL<>0   
   
     
  declare t2 cursor for  select ywlx,djh,tjwh,djy,djrq,zxrq,deptid,bz , bljzx,tjxs,bpltj  from #temp_TJ  
   group by ywlx,djh,tjwh,djy,djrq,zxrq,deptid,bz ,bljzx,tjxs,bpltj;  
  open  t2  
  
  fetch next from t2 into @t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,@t1_deptid,@t1_bz, @t1_bljzx,@t1_tjxs,@t1_bpltj  
  
  while @@FETCH_STATUS=0  
  begin  
   if @t1_deptid<>@deptid   
   begin  
     --插入调价表头    
     set @t1_djid=dbo.FUN_GETGUID(newid(),getdate())  
     insert into yf_Tj(ID,jgbm,YWLX,DJH,TJWH,DJY,DJRQ,ZXRQ,WCBJ,BDELETE,DEPTID,BZ  
     ,BLJZX,TJXS,BPLTJ)values  
     (@t1_djid,@jgbm,@t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,1,0,@t1_deptid,@t1_bz  
     ,@t1_bljzx,@t1_tjxs,@t1_bpltj)  
     if @t1_djid=dbo.FUN_GETEMPTYGUID() or @t1_djid is null  
      begin  
        set @err_text='插入调价表出错'  
       return;  
     end  
       
     --插入调价明细  
     insert into yf_tjmx(ID,djid,cjid,tjsl,ypdw,ydwbl,ypfj,xpfj,tpfje,ylsj,xlsj,tlsje,deptid,djh  
          ,PPBZ,WHMXID,ZGLSJ ,  
          SCJHJ,MRJHJ,TJHJE )  --原进货价、现进货价、调进货金额  
          select dbo.FUN_GETGUID(  
           newid(),getdate()),@t1_djid,cjid,sum(tjsl),ypdw,  
           ydwbl,ypfj,xpfj,sum(tpfje),ylsj,  
           xlsj,sum(tlsje),deptid,djh  
           ,ppbz,whmxid,zglsj    
           ,yjhj,  
           xjhj,  
           SUM(tjhje) --原进货价、现进货价、调进货金额  
          from #temp_TJ     
          WHERE deptid=@t1_deptid  group by cjid,ypdw,ydwbl,ypfj,xpfj,ylsj,xlsj,deptid,djh  
                ,yjhj,xjhj    
           ,ppbz,whmxid,zglsj    
     if @@ROWCOUNT=0  
      begin  
       set @ERR_CODE=-1  
       set @ERR_TEXT='插入调价明细失败'  
       return  
      end  
   end  
  
   --生成sdjh单据号  
   UPDATE YP_DJH SET nDJH=nDJH+1 WHERE DEPTID=@t1_deptid AND YWLX=@t1_ywlx;  
   SET @ssDJH=(SELECT sdjh+'--'+rtrim(nDJH) FROM yp_djh where DEPTID=@t1_deptid AND YWLX=@t1_ywlx);  
   if @t1_deptid=@deptid   
     set @sdjh=@ssdjh  
  
   --插入单据表头  
   set @zxdjid=dbo.FUN_GETGUID(newid(),getdate())  
   insert into yf_dj(ID,jgbm,djh,sdjh,deptid,ywlx,wldw,rq,djy,djrq,djsj,bz,shbz,shrq,shy)  
          values(@zxdjid,@jgbm,@t1_djh,@ssdjh,@t1_deptid,@t1_ywlx,@deptid,dbo.fun_getdate(@t1_zxrq),@t1_djy,dbo.fun_getdate(@t1_zxrq),convert(nvarchar,@t1_zxrq,108),  
       @t1_bz,1,@t1_zxrq,@t1_djy);  
   if @@ROWCOUNT=0  
    begin  
      set @err_text='插入业务表出错'  
     return;  
   end  
     
  
     --回填yf_tj表中yid  
    if(@t1_deptid<>@deptid)  
    begin  
     update YF_TJ set yid= @djid where ID=@t1_djid  
     if @@ROWCOUNT=0  
     begin  
      set @err_text='回填调价头表yid失败'  
      return  
      end  
    end  
  
   --插入单据明细  
   insert into yf_djmx(ID,DJID,CJID,shh,yppm,ypspm,ypgg,sccj,KWID,YPPH,YPXQ,YPKL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx,bz  
      ,yppch,kcid  
      )  
    select dbo.FUN_GETGUID(newid(),getdate()),@zxdjid,a.cjid,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,0,    
     ypph,ypxq,  0,tjsl,ypdw,0,ydwbl,  
        a.xjhj ,  
     xpfj,xlsj,  
     a.tjhje,  
     tpfje,tlsje,djh,deptid,ywlx,djbz  
     ,yppch,kcid   
     from #temp_TJ_ph a,yp_ypcjd  b where a.cjid=b.cjid and deptid=@t1_deptid;  
       
       
   --更新yf_dj表中金额 回填yf_tj表中zxdjid  
   select @sumpfje=sum(PFJE),@sumlsje=sum(LSJE),@sumjhje=SUM(jhje),@count=COUNT(*) from YF_DJMX where DJID=@zxdjid   
   if @count<>0  
    begin  
     update YF_DJ set SUMPFJE=@sumpfje,SUMLSJE=@sumlsje,SUMJHJE=@sumjhje where ID=@zxdjid   
       
      update YF_TJ set zxdjid=@zxdjid where ID=@t1_djid  
      if @@ROWCOUNT =0  
      begin  
       set @err_text='回填调价头表zxdjid失败'  
        return  
      end  
    end  
   else  
    delete YF_DJ where ID=@zxdjid   
  
   fetch next from t2 into @t1_ywlx,@t1_djh,@t1_tjwh,@t1_djy,@t1_djrq,@t1_zxrq,@t1_deptid,@t1_bz , @t1_bljzx,@t1_tjxs,@t1_bpltj  
  
  end  
  
  CLOSE t2  
  DEALLOCATE t2  
  
  
  --declare @t2_mrjj decimal(15,4)  
  --更改药品价格  
  declare t3 cursor for select xpfj,xlsj,cjid,mrjhj from yf_tj a,yf_tjmx b where a.id=b.djid and a.id=@djid   
  open  t3  
  
  fetch next from t3 into @t2_xpfj,@t2_xlsj,@t2_cjid,@t2_mrjj  
  
  while @@FETCH_STATUS=0  
  begin   
      update  yp_ypcjd set pfj=@t2_xpfj,lsj=@t2_xlsj,mrjj=@t2_mrjj where cjid=@t2_cjid;  
      if @@rowcount=0  
       begin  
      set @err_text='更新药品词典没有成功，影响到数据库0行';  
      return;  
      end  
      fetch next from t3 into @t2_xpfj,@t2_xlsj,@t2_cjid,@t2_mrjj  
        
      if @btjhj ='1' --如果调进货价 就更新kcph表中进货价  
      begin  
       --更改kcph表中jhj    
       update YK_KCPH set JHJ=@t2_mrjj where CJID = @t2_cjid  
       update YF_KCPH set JHJ=@t2_mrjj where CJID = @t2_cjid   
      end  
        
   END  
  CLOSE t3  
  DEALLOCATE t3    
 end   
   
   
  
 set @Err_Code=0;  
 set @Err_Text='调价执行成功'