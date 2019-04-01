IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_YF_TLDMX]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_YF_TLDMX]
GO
create PROCEDURE [dbo].[sp_YF_TLDMX]    
(    
  @GROUPID   UNIQUEIDENTIFIER ,  --统领单头id    
  @CJID      INTEGER,    
  @SHH       VARCHAR(20),    
  @YPPM      VARCHAR(100),    
  @YPSPM     VARCHAR(100),    
  @YPGG      VARCHAR(50),    
  @YPDW      VARCHAR(10),    
  @SCCJ      VARCHAR(100),    
  @KCL   DECIMAL(15, 3),    
  @YPSL      DECIMAL(15, 3),    
  @QysL      DECIMAL(15, 3),    
  @PFJ       DECIMAL(15, 4),    
  @LSJ       DECIMAL(15, 4),    
  @PFJE      DECIMAL(15, 2),    
  @LSJE      DECIMAL(15, 2),    
  @TLFL      VARCHAR(50),    
  @DWBL   INT,    
  @bkc   smallint,    
  @deptid  int,    
  @ypph   VARCHAR(30),    
  @fyid   UNIQUEIDENTIFIER output,    
  @ERR_CODE  INTEGER  output,    
  @ERR_TEXT  VARCHAR(100)   output,    
  @hwh    VARCHAR(50),    
      
  --add by ncq 2014-04-30    
  @jhj decimal(15,4),   --进价    
  @jhje decimal(15,3),   --进货金额    
  @yppch varchar(100),   --批次号    
  @kcid uniqueidentifier,     --kcid    
  @bpcgl smallint,     --是否进行批次管理    
  @ypxq char(10),               --药品效期  
  @ypcjs  DECIMAL(15, 3)  --冲减数量
)    
AS    
/*
Modify By Tany 2015-01-09 库存批号增加修改时间
*/
 begin    
   declare @xpfj decimal(15,3)  --现批发价    
   declare @xlsj decimal(15,3) ;  --现零售价    
   declare @xdwbl int       --现单位比例    
   declare @TPFJE  DECIMAL(15,2) ; --批发金额调价误差    
   declare @TLSJE   DECIMAL(15,2); --零售金额调价误差    
   declare @ckl decimal(15,3);  --出库量    
   declare @dqckl decimal(15,3);  --当前出库量    
   declare @ys decimal(15,3);   --余数    
   --declare @jhj decimal(15,4)    
   --declare @jhje decimal(15,3)    
   declare @kcmx_kcl decimal(15,4) --总库存    
   declare @kcmx_zxdw int    --库存单位    
   declare @bdelete smallint   --库存禁用状态    
   declare @ypjx varchar(50)   --剂型    
    
   set @ERR_CODE=-1;    
   set @ERR_TEXT='';    
   set @fyid=dbo.FUN_GETEMPTYGUID()     
       
   --验证库存存在    
   select @xpfj=pfj,@xlsj=lsj,@xdwbl=dwbl,@kcmx_kcl=kcl,@kcmx_zxdw=zxdw,@bdelete=bdelete_kc,@ypjx=s_ypjx from vi_yf_kcmx where cjid=@cjid and deptid=@deptid;    
   if @xlsj is null     
   begin    
      set @ERR_CODE=-1;    
     set @ERR_TEXT='没有找到库存记录,操作滚回';    
     return;    
   end    
      
   --验证库存禁用    
   if @bdelete=1 and @YPSL>0    
   begin    
      set @ERR_CODE=-1;    
     set @ERR_TEXT=@YPPM+'的库存已禁用,当前库存'+cast(cast(@kcmx_kcl as float) as varchar(30))+dbo.fun_yp_ypdw(@kcmx_zxdw)+' 如果您要发药或退库。请修改禁用状态,当前操作滚回';    
     return;    
   end    
       
   SET @ERR_TEXT='计算调价误差金额';    
   if (@pfj)-(@xpfj/@dwbl)<>0     
    set @tpfje=@pfje-round(@xpfj*@ckl/@xdwbl,3);--批发金额误差    
   if (@lsj)-(@xlsj/@dwbl)<>0     
    set @tlsje=@lsje-round(@xlsj*@ckl/@xdwbl,3);--零售金额误差    
        
   set @tpfje=coalesce(@tpfje,0);    
   set @tlsje=coalesce(@tlsje,0);    
   SET @ERR_TEXT='插入统领单明细表';    
   set @FYID=dbo.FUN_GETGUID(newid(),getdate())    
     
     
  if @bpcgl = 0  --不进行批次管理    
   begin    
     
      set @jhj=0    
      set @jhje=0    
     insert into yf_tldmx(id,GROUPID,CJID,ypjx,SHH,YPPM,YPSPM,YPGG,YPDW,SCCJ,KCL,YPSL,QysL,PFJ,LSJ,PFJE,LSJE,TLFL,yDWBL,TPFJE,TLSJE,hwh,ypcjs)    
     values(@FYID,@GROUPID,@CJID,@ypjx,@SHH,@YPPM,@YPSPM,@YPGG,@YPDW,@SCCJ,@KCL,@YPSL,@QysL,@PFJ,@LSJ,@PFJE,@LSJE,@TLFL,@DWBL,@TPFJE,@TLSJE,@hwh,@ypcjs);    
    
     if @@rowcount=0 or @fyid=dbo.FUN_GETEMPTYGUID() or @fyid is null     
     begin    
      set @ERR_TEXT='插入发药明细表没有成功，影响到数据库0行';    
      set @ERR_CODE=-1;    
      return;    
     end    
         
     --初始余数    
     set @ckl=@ypsl*@xdwbl/@dwbl;    
     set @ys=@ckl;    
         
     SET @ERR_TEXT='更新库存表和库存批号表';    
    
    declare @t1_id UNIQUEIDENTIFIER    
    declare @t1_kcl decimal(15,3)    
    declare @t1_ypph varchar(20)    
    declare @t1_cjid int    
    declare @t1_deptid int    
    declare @t1_jhj decimal(15,4)    
    declare t1 cursor  local  for  select id,kcl,ypph,cjid,deptid,round(jhj/dwbl,4) from YF_kcph where cjid=@cjid and deptid=@deptid and  ( (bdelete=0 and @ypsl>=0) or  (@ypsl<0)   )order by ypxq    
    open  t1    
    fetch next from t1 into @t1_id,@t1_kcl,@t1_ypph,@t1_cjid,@t1_deptid,@t1_jhj    
    while @@FETCH_STATUS=0    
     begin    
         set @dqckl=0;    
       if (@t1_kcl-(@ys))>=0     
      begin    
         set @dqckl=@ys;    
        set @ys=0;    
        end    
      else    
        begin    
         set @dqckl=@t1_kcl;    
        set @ys=@ys-@t1_kcl;      
        end    
           
       set @jhje=@jhje+@dqckl*@t1_jhj    
        update YF_kcph set kcl=kcl-(@dqckl),xgsj=GETDATE() where  cjid=@t1_cjid and id=@t1_id and deptid=@t1_deptid;    
       if @@rowcount=0     
        begin    
                 set @ERR_TEXT='更新库存批号没有成功，影响到数据库0行';    
               return;    
        end    
      fetch next from t1 into @t1_id,@t1_kcl,@t1_ypph,@t1_cjid,@t1_deptid,@t1_jhj    
     end    
    CLOSE t1    
    DEALLOCATE t1    
    
    --如果强控制库存    
    if @ys>0 and @bkc=1     
    begin    
     set @ERR_TEXT='[ '+@sccj+']  生产的 [ '+@YPSPM+' ]  ' + @ypgg+' 货号:'+@shh+' 库存不够,当前库存为[ '+rtrim(cast(cast(@kcmx_kcl as float) as varchar(30)))+rtrim(dbo.fun_yp_ypdw(@kcmx_zxdw)) +' ],操作滚回'    
     set @ERR_CODE=-1;    
     return;    
    end    
       
    --如果不强探制库存    
    if @ys<>0 and @bkc=0     
    begin    
     declare @t2_id UNIQUEIDENTIFIER    
     declare @t2_kcl decimal(15,3)    
     declare @t2_ypph varchar(20)    
     declare @t2_cjid int    
     declare @t2_deptid int    
     declare @t2_jhj decimal(15,4)    
    
     set @dqckl=@ys;    
     declare t2 cursor local for  select top 1 id,kcl,ypph,cjid,deptid,round(jhj/dwbl,4) from YF_kcph where cjid=@cjid and deptid=@deptid  order by ypxq     
     open  t2    
     fetch next from t2 into @t2_id,@t2_kcl,@t2_ypph,@t2_cjid,@t2_deptid,@t2_jhj    
     while @@FETCH_STATUS=0    
      begin    
       set @jhje=@jhje+@dqckl*@t2_jhj    
         --更新库存批号表    
       update YF_kcph set kcl=kcl-(@dqckl),xgsj=GETDATE() where  cjid=@t2_cjid and id=@t2_id and deptid=@t2_deptid;    
       if @@rowcount=0    
       begin    
        set @ERR_TEXT='更新库存批号没有成功，影响到数据库0行';    
        return;    
        end    
               
        --余数置零    
        set @ys=0;     
      fetch next from t2 into @t2_id,@t2_kcl,@t2_ypph,@t2_cjid,@t2_deptid,@t2_jhj    
     end    
     CLOSE t2    
     DEALLOCATE t2    
    end      
    
    --更新进货金额    
    declare @d decimal(15,3)    
    if @ckl=0     
     set @d=1    
    else    
     set @d=@ckl    
          
    update yf_tldmx set jhj=round(@jhje/@d,4),jhje=round(@jhje,3) where id=@FYID    
    if @@rowcount=0    
     begin    
       set @ERR_TEXT='更新进货金额时发生错语，影响到数据库0行';    
       return;    
     end      
    
    --更新库存表    
    update YF_kcmx set kcl=kcl-(@ckl)  where  cjid=@cjid and deptid=@deptid;    
    if @@rowcount=0    
     begin    
       set @ERR_TEXT='更新库存没有成功，影响到数据库0行';    
       return;    
     end      
    
    --如果余数继续为零则报错    
    if @ys<>0     
     begin    
       set @ERR_TEXT=@YPSPM+'余数为'+cast(round(cast(@ys as float),3) as char(20))+',可能没有更新到库存记录'+cast(@bkc as char(2));    
       set @ERR_CODE=-1;    
       return;    
     end    
  end    
  else     --进行批次管理    
   begin    
     --插入统领单明细    
     insert into yf_tldmx(    
     id,GROUPID,CJID,ypjx,SHH,    
     YPPM,YPSPM,YPGG,YPDW,SCCJ,    
     KCL,YPSL,QysL,PFJ,LSJ,    
     PFJE,LSJE,TLFL,yDWBL,TPFJE,    
     TLSJE,hwh,    
     JHJ,JHJE,    
     ypph,ypxq,yppch,kcid,ypcjs)    
     values(    
     @FYID,@GROUPID,@CJID,@ypjx,@SHH,    
     @YPPM,@YPSPM,@YPGG,@YPDW,@SCCJ,    
     @KCL,@YPSL,@QysL,@PFJ,@LSJ,    
     @PFJE,@LSJE,@TLFL,@DWBL,@TPFJE,    
     @TLSJE,@hwh,    
     @jhj,@jhje,    
     @ypph,@ypxq,@yppch,@kcid,@ypcjs);    
     if @@ROWCOUNT<=0    
     begin    
      set @ERR_TEXT='插入发药明细表没有成功，影响到数据库0行';    
         set @ERR_CODE=-1;    
      return    
     end    
         
     --更新库存    
     --更新库存明细    
     update YF_KCMX set KCL=KCL-@YPSL where CJID=@CJID and DEPTID=@deptid and KCL>=@YPSL    
     if @@ROWCOUNT<=0    
     begin    
      set @ERR_TEXT='更新明细库存失败'    
      set @ERR_CODE=-1    
      return    
     end    
         
     --更新库存批号    
     update YF_KCPH set KCL=KCL-@YPSL,xgsj=GETDATE() where CJID=@CJID and DEPTID=@deptid and id=@kcid and yppch=@yppch and KCL>=@YPSL    
     if @@ROWCOUNT<=0    
     begin    
      set @ERR_TEXT='更新批次库存失败'    
      set @ERR_CODE=-1    
      return    
     end    
         
   end    
      
  SET @ERR_TEXT='发药成功';    
  SET @ERR_CODE=0;    
end
GO


