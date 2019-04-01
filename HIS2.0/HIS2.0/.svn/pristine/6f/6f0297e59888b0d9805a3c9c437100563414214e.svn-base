IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_FYMX' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_FYMX
GO
CREATE PROCEDURE sp_YF_FYMX
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
 @ypph varchar(20),  --批号    
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
    @ERR_TEXT VARCHAR(250) output,    
        
    @jhj decimal(15,4),   --进货价    
    @jhje decimal(15,3),  --进货金额    
    @ypxq char(10),    --效期    
    @yppch varchar(100),  --批次号    
    @kcid uniqueidentifier,  --kcid    
    @bpcgl smallint    --是否进行批次管理     
)     
AS    
/*
Modify By Tany 2015-01-09 库存批号增加修改时间
*/
begin    
declare @xpfj decimal(15,3)    
declare @xlsj decimal(15,3)     
declare @xdwbl int    
declare @bkc int     
declare @ckl decimal(15,3)    
declare @dqckl decimal(15,3)    
declare @ys decimal(15,3)    
    
    
--declare @jhj decimal(15,4)  --进价    
--declare @jhje decimal(15,3) --进货金额    
--set @jhj=0    
--set @jhje=0    
     
set @ERR_CODE=-1    
set @ERR_TEXT=''    
    
--select ypph from yf_kcph     
declare @cjid_kc int     
declare @kwid_kc int    
declare @ypph_kc varchar(30)     
declare @ypxq_kc varchar(10)     
declare @jhj_kc decimal(15,4)    
declare @kcl_kc decimal(15,3)    
declare @zxdw_kc varchar(10)      
declare @dwbl_kc int     
declare @yppch_kc varchar(100)    
declare @kcid_kc uniqueidentifier     
    
    
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
     
if @bpcgl = 0   --不进行批次管理      
 begin    
     set @jhj=0    
  set @jhje=0    
  --是否强制控制库存变量    
  set @bkc=(select zt from yk_config where bh='101' and deptid=@deptid )    
  set @bkc=coalesce(@bkc,0)    
       
  --计算出库量    
  set @ckl=(select @ypsl*@CFTS*dwbl/@dwbl from YF_kcmx where cjid=@cjid and deptid=@deptid)    
  if @ckl is null     
   begin    
        set @ERR_TEXT='找不到库存记录,发药没有成功'    
       set @ERR_CODE=-1    
       return    
   end    
    
  --初始余数    
  set @ys=@ckl    
       
  --计算调价误差    
  select @xpfj=pfj,@xlsj=lsj,@xdwbl=dwbl  from vi_yf_kcmx where cjid=@cjid and deptid=@deptid    
  if @xlsj is null     
   begin    
      set @ERR_CODE=-1    
     set @ERR_TEXT='没有找到库存记录,发药没有成功'    
     return    
   end      
  set @tpfje=0    
  set @tlsje=0    
  --调批发价     
  if (@pfj*@dwbl)-@xpfj<>0     
     set @tpfje=@pfje-round(@xpfj*@ckl/@xdwbl,3)    
  --调零售价    
  if (@lsj*@dwbl)-@xlsj<>0     
     set @tlsje=@lsje-round(@xlsj*@ckl/@xdwbl,3)    
         
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
       
  --如果是发药    
  if @tyid=dbo.FUN_GETEMPTYGUID() or @tyid is null     
   begin    
    declare @t1_id UNIQUEIDENTIFIER    
    declare @t1_kcl decimal(15,3)    
    declare @t1_ypph varchar(20)    
    declare @t1_cjid int    
    declare @t1_deptid int    
    declare @t1_jhj decimal(15,4)    
    declare t1 cursor for  select id,kcl,ypph,cjid,deptid,round(jhj/dwbl,4) from YF_kcph where cjid=@cjid and deptid=@deptid and ((@ypsl>0 and kcl>0) or (@ypsl<=0)) and bdelete=0 order by ypxq    
    open  t1    
    fetch next from t1 into @t1_id,@t1_kcl,@t1_ypph,@t1_cjid,@t1_deptid,@t1_jhj    
    while @@FETCH_STATUS=0    
     begin    
           set @dqckl=0    
         if @T1_kcl-@ys>=0     
         begin    
            set @dqckl=@ys    
           set @ys=0    
         end    
             
        if @T1_kcl-@ys<0     
         begin    
             set @dqckl=@t1_kcl    
          set @ys=@ys-@t1_kcl      
         end     
           
        set @jhje=@jhje+@t1_jhj*@dqckl    
    
        --更新库存批号表    
         update YF_kcph set kcl=kcl-(@dqckl),xgsj=GETDATE() where  cjid=@T1_cjid and id=@t1_id and deptid=@T1_deptid    
        if @@rowcount=0     
         begin    
                 set @ERR_TEXT='更新库存批号没有成功，影响到数据库0行'    
               return    
            end    
            
        --插入当前出库的批次明细    
       IF @dqckl<>0     
         insert into yf_fymx_ph(id,fymxid,fph,cfxh,cjid,ypdw,Ydwbl,ypph,ypsl,deptid,tyid)    
         values(dbo.FUN_GETGUID(newid(),getdate()),@fymxid,@fph,@cfxh,@cjid,@ypdw,@dwbl,@t1_ypph,@dqckl,@deptid,@tyid)    
    
          
         --更新库存表    
        update YF_kcmx set kcl=kcl-(@dqckl)  where  cjid=@T1_cjid and deptid=@T1_deptid    
        if @@rowcount=0     
         begin    
                 set @ERR_TEXT='更新库存没有成功，影响到数据库0行'    
               return    
            end     
      fetch next from t1 into @t1_id,@t1_kcl,@t1_ypph,@t1_cjid,@t1_deptid ,@t1_jhj     
     end    
    CLOSE t1    
    DEALLOCATE t1    
    
    --如果强控制库存    
    if @ys>0 and @bkc=1     
     begin    
      set @ERR_TEXT='[ '+@ypcj+']  生产的 [ '+@ypspm+' ] ' +'库存不够,发药没有成功'    
      set @ERR_CODE=-1    
      return    
     end    
    
    --如果不强探制库存    
    if @ys>0 and @bkc=0     
     begin    
      declare @t2_id UNIQUEIDENTIFIER    
      declare @t2_kcl decimal(15,3)    
      declare @t2_ypph varchar(20)    
      declare @t2_cjid int    
      declare @t2_deptid int    
      declare @t2_jhj decimal(15,4)    
    
      set @dqckl=@ys    
      declare t2 cursor for  select top 1 id,kcl,ypph,cjid,deptid,round(jhj/dwbl,4) from YF_kcph where cjid=@cjid and deptid=@deptid  order by ypxq desc     
      open  t2    
      fetch next from t2 into @t2_id,@t2_kcl,@t2_ypph,@t2_cjid,@t2_deptid,@t2_jhj    
      while @@FETCH_STATUS=0    
       begin    
        set @jhje=@jhje+@t2_jhj*@dqckl    
            --更新库存批号表    
        update YF_kcph set kcl=kcl-(@dqckl),xgsj=GETDATE() where  cjid=@t2_cjid and id=@t2_id and deptid=@t2_deptid    
        if @@rowcount=0    
         begin    
           set @ERR_TEXT='更新库存批号没有成功，影响到数据库0行'    
           return    
         end     
                 
        --插入当前出库的批次明细    
        IF @dqckl<>0     
         begin    
           insert into yf_fymx_ph(id,fymxid,fph,cfxh,cjid,ypdw,Ydwbl,ypph,ypsl,deptid,tyid)    
             values(dbo.FUN_GETGUID(newid(),getdate()),@fymxid,@fph,@cfxh,@cjid,@ypdw,@dwbl,@t2_ypph,@dqckl,@deptid,@tyid)    
                  
          --更新库存表    
            update YF_kcmx set kcl=kcl-(@dqckl)  where  cjid=@t2_cjid and deptid=@t2_deptid    
          if @@rowcount=0    
           begin    
                    set @ERR_TEXT='更新库存没有成功，影响到数据库0行'    
                  return    
           end    
         end     
                 
        --余数置零    
        set @ys=0     
        fetch next from t2 into @t2_id,@t2_kcl,@t2_ypph,@t2_cjid,@t2_deptid,@t2_jhj    
       end    
       CLOSE t2    
       DEALLOCATE t2    
       end    
   end    
    
  --如果为退药    
  if @tyid<> dbo.FUN_GETEMPTYGUID()      
   begin    
    declare @t3_id UNIQUEIDENTIFIER    
    declare @t3_kcl decimal(15,3)    
    declare @t3_ypph varchar(20)    
    declare @t3_cjid int    
    declare @t3_deptid int    
    declare @t3_jhj decimal(15,4)    
    declare @fymx_id UNIQUEIDENTIFIER    
    set @dqckl=@ys    
    
    declare t3 cursor for  select id,kcl,ypph,cjid,deptid,round(jhj/dwbl,4) from YF_kcph where cjid=@cjid and deptid=@deptid and ypph=rtrim(@ypph)    
    open  t3    
    fetch next from t3 into @t3_id,@t3_kcl,@t3_ypph,@t3_cjid,@t3_deptid,@t3_jhj    
     while @@FETCH_STATUS=0    
      begin    
       set @jhje=@jhje+@t3_jhj*@dqckl    
    
       --更新库存批号表    
          update YF_kcph set kcl=kcl-(@dqckl),xgsj=GETDATE() where  cjid=@t3_cjid and id=@t3_id and deptid=@t3_deptid    
              
       if @@rowcount=0    
        begin    
               set @ERR_TEXT='更新库存批号没有成功，影响到数据库0行'    
             return    
        end    
               
        --插入当前出库的批次明细    
       IF @dqckl<>0     
        begin    
         if @fymxid is null or @fymxid=dbo.FUN_GETEMPTYGUID()     
          set @fymx_id=@id    
         else     
          set @fymx_id=@fymxid    
           insert into yf_fymx_ph(id,fymxid,fph,cfxh,cjid,ypdw,Ydwbl,ypph,ypsl,deptid,tyid)    
             values(dbo.FUN_GETGUID(newid(),getdate()),@fymx_id,@fph,@cfxh,@cjid,@ypdw,@dwbl,@ypph,@dqckl*(-1),@deptid,@tyid)    
        end    
    
       --更新库存表    
       update YF_kcmx set kcl=kcl-(@dqckl),xnkcl=xnkcl-(@dqckl)  where  cjid=@t3_cjid and deptid=@t3_deptid    
       if @@rowcount=0    
        begin    
              set @ERR_TEXT='更新库存没有成功，影响到数据库0行'    
            return    
           end     
              
       --余数置零    
       set @ys=0      
           
       fetch next from t3 into @t3_id,@t3_kcl,@t3_ypph,@t3_cjid,@t3_deptid,@t3_jhj    
      end    
      CLOSE t3    
      DEALLOCATE t3    
   end     
       
  --更新进货金额    
  if @ckl<>0    
   begin    
    update yf_fymx set jhj=round(@jhje/@ckl,4),jhje=round(@jhje,3) where id=@fymxid    
    if @@rowcount=0 and @fymxid<>dbo.FUN_GETEMPTYGUID()     
     begin    
       set @ERR_TEXT='更新进货金额时发生错语，影响到数据库0行'+cast(@fymxid as varchar(100));    
       return;    
     end      
   end    
       
  --如果余数继续为零则报错    
  if @ys<>0     
   begin    
     set @ERR_TEXT='发药时系统没有更新到库存记录,发药没有成功'    
     set @ERR_CODE=-1    
     return    
   end    
        
  SET @ERR_TEXT='保存成功'    
  SET @ERR_CODE=0    
       
 end    
else --进行批次管理    
 begin    
     declare @ljfy varchar(10)    
     set @ljfy=(select config from JC_CONFIG where ID=8013) -- 门诊处方收费时是否立即发药 0 否 1 是    
     if @ljfy is null or @ljfy='0'    
   set @ljfy='0'       
  if( @ljfy='1' and @kcid=dbo.FUN_GETEMPTYGUID() and @ypxq='1900-01-01') --门诊收费时发药    
   begin    
    set @ERR_CODE =-1     
    set @ERR_TEXT='暂时不支持'    
      return     
        
    --计算出库量    
    set @ckl=(select @ypsl*@CFTS*dwbl/@dwbl from YF_kcmx where cjid=@cjid and deptid=@deptid)    
    if @ckl is null     
     begin    
          set @ERR_TEXT='找不到库存记录,发药没有成功'    
         set @ERR_CODE=-1    
         return    
     end    
        
    select @xpfj=pfj,@xlsj=lsj,@xdwbl=dwbl  from vi_yf_kcmx where cjid=@cjid and deptid=@deptid    
    if @xlsj is null     
     begin    
        set @ERR_CODE=-1    
       set @ERR_TEXT='没有找到库存记录,发药没有成功'    
       return    
     end      
        
    --计算调价误差     
    set @tpfje=0    
    set @tlsje=0    
    --调批发价     
    if (@pfj*@dwbl)-@xpfj<>0     
       set @tpfje=@pfje-round(@xpfj*@ckl/@xdwbl,3)    
    --调零售价    
    if (@lsj*@dwbl)-@xlsj<>0     
       set @tlsje=@lsje-round(@xlsj*@ckl/@xdwbl,3)    
           
    declare @sl decimal(15,3)         
    --分配批次库存 游标循环    
    declare dx cursor for  select cjid,kwid,ypph,ypxq,jhj,kcl,zxdw,dwbl,yppch,id kcid     
            from yf_kcph where deptid=@deptid and cjid=@cjid and bdelete = 0 and kcl > 0    
    open dx    
    fetch next from dx into @cjid_kc,@kwid_kc,@ypph_kc,@ypxq_kc,@jhj_kc,@kcl_kc,@zxdw_kc,@dwbl_kc,@yppch_kc,@kcid_kc    
    while @@FETCH_STATUS=0    
    begin    
     if @kcl_kc>=@ckl    
      begin    
       set @sl=@ckl     
       set @ys=0     
      end    
     else    
      begin    
       set @sl=@kcl_kc     
       set @ys=@ckl-@sl     
      end    
          
      set @ypph=@ypph_kc    
      set @ypxq=@ypxq_kc    
      set @yppch=@yppch_kc     
          
      --插入发药明细    
      set @fymxid=dbo.FUN_GETGUID(newid(),getdate())    
       insert into yf_FYMX(    
             id,fyid,FPH,CFXH,CJID,    
             YPHH,YPPM,YPSPM,YPGG,YPCJ,    
             YPDW,YDWBL,YPSL,cfts,PFJ,    
             PFJE,LSJ,LSJE,Tpfje,tlsje,    
             deptid,tyid,cfmxid,CFMXIDBK,psbz,    
             syff,zt,yf,pc,jl,    
             jldw,ts,zbz,pxxh,    
             jhj,jhje,ypxq,yppch,kcid,ypph     
            )    
          values(    
             @fymxid,@fyid,@FPH,@CFXH,@CJID,    
             @YPHH,@YPPM,@YPSPM,@YPGG,@YPCJ,    
             @YPDW,@DWBL,@YPSL,@CFTS,@PFJ,    
             @PFJE,@LSJ,@LSJE,@tpfje,@tlsje,    
             @deptid,@tyid,@cfmxid,@cfmxid,@psbz,    
             @syff,@zt,@yf,@pc,@jl,    
             @jldw,@ts,@zbz,@pxxh,    
             @jhj,@jhje,@ypxq,@yppch,@kcid,@ypph    
            )    
       if @@rowcount=0 or @fymxid=dbo.FUN_GETEMPTYGUID() or @fymxid is null     
       begin    
        set @ERR_TEXT='插入发药明细表没有成功，影响到数据库0行'    
        return    
       end    
           
      --更新明细库存    
      update YF_KCMX set KCL=KCL-@ckl where CJID=@CJID and DEPTID=@deptid and KCL>=@ckl    
      if @@ROWCOUNT<=0    
       begin    
        set @ERR_TEXT='更新明细库存失败'    
        set @ERR_CODE=-1    
        return    
       end    
             
      --更新批号库存    
       update YF_KCPH set KCL=KCL-@ckl,xgsj=GETDATE() where CJID=@CJID and DEPTID=@deptid and id=@kcid and yppch=@yppch and KCL>=@ckl    
       if @@ROWCOUNT<=0    
       begin    
        set @ERR_TEXT='更新批次库存失败'    
        set @ERR_CODE=-1    
        return    
       end    
      if @ys<=0    
       break     
         
     fetch next from dx into @cjid_kc,@kwid_kc,@ypph_kc,@ypxq_kc,@jhj_kc,@kcl_kc,@zxdw_kc,@dwbl_kc,@yppch_kc,@kcid_kc    
    end    
    close dx    
    deallocate dx    
        
    --如果余数依然大于0 则报错    
    if @ys>0    
     begin    
      set @ERR_CODE=-1    
      set @ERR_TEXT= @YPPM+' '+@YPGG+  '库存不足'      
      return     
     end    
        
   end    
  else    
   begin    
    --计算出库量    
    set @ckl=(select @ypsl*@CFTS*dwbl/@dwbl from YF_kcmx where cjid=@cjid and deptid=@deptid)    
    if @ckl is null  and @ckl<>0    
     begin    
          set @ERR_TEXT='找不到库存记录,发药没有成功'    
         set @ERR_CODE=-1    
         return    
     end    
    
    --计算调价误差    
    select @xpfj=pfj,@xlsj=lsj,@xdwbl=dwbl  from vi_yf_kcmx where cjid=@cjid and deptid=@deptid    
    if @xlsj is null  and @ckl<>0    
     begin    
        set @ERR_CODE=-1    
       set @ERR_TEXT='没有找到库存记录,发药没有成功'    
       return    
     end      
    set @tpfje=0    
    set @tlsje=0    
    --调批发价     
    if (@pfj*@dwbl)-@xpfj<>0     
       set @tpfje=@pfje-round(@xpfj*@ckl/@xdwbl,3)    
    --调零售价    
    if (@lsj*@dwbl)-@xlsj<>0     
       set @tlsje=@lsje-round(@xlsj*@ckl/@xdwbl,3)    
        
    --插入发药明细表    
    --如果当前明细ID为零就插入    
    if @id=dbo.FUN_GETEMPTYGUID() or @id is null    
     begin    
      set @fymxid=dbo.FUN_GETGUID(newid(),getdate())    
       insert into yf_FYMX(    
             id,fyid,FPH,CFXH,CJID,    
             YPHH,YPPM,YPSPM,YPGG,YPCJ,    
             YPDW,YDWBL,YPSL,cfts,PFJ,    
             PFJE,LSJ,LSJE,Tpfje,tlsje,    
             deptid,tyid,cfmxid,CFMXIDBK,psbz,    
             syff,zt,yf,pc,jl,    
             jldw,ts,zbz,pxxh,    
             jhj,jhje,ypxq,yppch,kcid,ypph     
            )    
          values(    
             @fymxid,@fyid,@FPH,@CFXH,@CJID,    
             @YPHH,@YPPM,@YPSPM,@YPGG,@YPCJ,    
             @YPDW,@DWBL,@YPSL,@CFTS,@PFJ,    
             @PFJE,@LSJ,@LSJE,@tpfje,@tlsje,    
             @deptid,@tyid,@cfmxid,@cfmxid,@psbz,    
             @syff,@zt,@yf,@pc,@jl,    
             @jldw,@ts,@zbz,@pxxh,    
             @jhj,@jhje,@ypxq,@yppch,@kcid,@ypph    
            )    
   if @@rowcount=0 or @fymxid=dbo.FUN_GETEMPTYGUID() or @fymxid is null     
       begin    
        set @ERR_TEXT='插入发药明细表没有成功，影响到数据库0行'    
        return    
       end    
          
      if   @ckl<>0     
      begin    
       --更新明细库存    
       update YF_KCMX set KCL=KCL-@ckl where CJID=@CJID and DEPTID=@deptid and KCL>=@ckl    
       if @@ROWCOUNT<=0    
        begin    
         set @ERR_TEXT='更新明细库存失败,' + @YPSPM + '(' + @YPPM + ')' + @YPGG+'库存不足,CJID：'  +  CONVERT(varchar(max),@cjid )    
         set @ERR_CODE=-1    
         return    
        end    
              
       --更新批号库存    
        update YF_KCPH set KCL=KCL-@ckl,xgsj=GETDATE() where CJID=@CJID and DEPTID=@deptid and id=@kcid and yppch=@yppch and KCL>=@ckl    
        if @@ROWCOUNT<=0    
        begin    
         set @ERR_TEXT='更新批次库存失败,批次号为:' + @yppch + '的药品' + @YPSPM + '(' + @YPPM + ')' + @YPGG+'库存不足,当前出库量:'+ CONVERT(varchar(max), @ckl) +',CJID：'  +  CONVERT(varchar(max),@cjid )      
         set @ERR_CODE=-1    
         return    
        end    
      end     
      end    
    else    
     begin    
      set @ERR_TEXT='修改失败'    
      return    
     end    
          
    SET @ERR_TEXT='保存成功'    
    SET @ERR_CODE=0    
       
   end    
 end    
    
end