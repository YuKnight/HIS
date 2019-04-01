IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_yf_updatekcmx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yf_updatekcmx]
GO
CREATE PROCEDURE [dbo].[sp_yf_updatekcmx]
(
	@djid UNIQUEIDENTIFIER,
	@Err_Code INTEGER output,
    @Err_Text VARCHAR(200)output,
	@jgbm  bigint
)
as
/*
Modify By Tany 2015-01-09 库存批号增加修改时间
*/
 begin  
 declare @phgl int  --管理批号  
 declare @Sypph varchar(20)--药品批号  
 declare @ncount int --记数  
 declare @dwbl int--拆零单位比例  
 declare @zxdw int --拆零单位  
 declare @kczxdw int--库存单位  
 declare @kcdwbl int--库存单位比例  
   
 declare @deptid int  
 declare @cjid int  
 declare @ypph varchar(30)  
 declare @ypsl decimal(15,3)  
 declare @ydwbl int  
 declare @kwid int  
 declare @ypxq varchar(20)  
 declare @ggid int  
 declare @jhj decimal(15,4)  
 declare @ypkl decimal(15,4)  
 declare @wldw int  
 declare @ypdw int  
 declare @jjgl varchar(10) --跟踪进价和进货金额  
 declare @ywlx varchar(10)  
  
 declare @djh  bigint       --单据号    
 declare @yppch varchar(100) --批次号  
 declare @kcid  uniqueidentifier   
 declare @rjdh bigint --入库单号     
 DECLARE @YPMC VARCHAR(100)  
 declare @djmxid uniqueidentifier   
   
 declare @kcl_temp decimal(15,3)  
   
set @deptid=( select top 1 DEPTID  from Yf_DJ where ID=@djid)  
declare @bpcgl int =0;   --批次号管理  
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--暂时设定为999  
if @bpcgl is null  
 set @bpcgl =0   
  
declare @bqzkc int =0 --强制控制库存  
select @bqzkc=ZT from YK_CONFIG where DEPTID=@deptid and BH=101  
if @bqzkc is null   
 set @bqzkc=0  
  
  
set @Err_Code=-1  
set @Err_Text=''  
  
   
 if @deptid=0   
   begin  
    set @Err_Text='科室ID为零请重新确认'  
    return  
   end  
   
  if @djid=dbo.FUN_GETEMPTYGUID() or @djid is null  
   begin  
    set @Err_Text='发生错误,djID为零'  
    return  
   end   
     
  
set @jjgl=(select config from jc_config where id=8002)  --如果启用了批次号管理，此参数将无效,启用批次管理则必定跟踪进价  
  
update Yf_DJ set sumpfje=coalesce((select SUM(pfje) from Yf_DJMX where DJID=@djid),0) where Yf_DJ.ID=@djid  
update Yf_DJ set SUMJHJE=coalesce((select SUM(jhje) from Yf_DJMX where DJID=@djid),0) where Yf_DJ.ID=@djid  
update Yf_DJ set SUMLSJE=coalesce((select SUM(lsje) from Yf_DJMX where DJID=@djid),0) where Yf_DJ.ID=@djid  
  
set @phgl=(select top 1 zt from yk_config where bh='102' and deptid=@deptid)  
if @phgl is null   
  set @phgl=0  
  
--迭代单据明细，更新kcmx、kcph  
declare t1 cursor local for   
 select a.cjid,a.ypph,dbo.fun_yf_drt(c.ywlx,ypsl) ypsl,a.ydwbl,a.deptid,a.kwid,a.ypxq,b.ggid,round(a.jhj*ydwbl,4) jhj,  
 a.ypkl,c.wldw,b.ypdw ,c.ywlx,  
 a.yppch,a.kcid ,c.djh,a.id,a.yppm    
 from yf_djmx a,vi_yp_ypcd b,yf_dj c    
 where a.cjid=b.cjid and c.id=a.djid  and a.djid=@djid  FOR read only  
  
open  t1  
  
fetch next from t1 into @cjid,@ypph,@ypsl,@ydwbl,@deptid,@kwid,@ypxq,@ggid,@jhj,@ypkl,@wldw,@ypdw,@ywlx,@yppch,@kcid,@djh,@djmxid ,@ypmc 
while @@FETCH_STATUS=0  
begin  
 if @bpcgl =0  
  begin  
     --查找库存是否存在该药品  
   SET @KCZXDW=0  
   SET @KCDWBL=0  
   SET @DWBL=0  
   SET @ZXDW=0  
   set @ncount=0  
     select @ncount=cjid,@kcdwbl=dwbl,@kczxdw=zxdw from yf_kcmx where cjid=@cjid and deptid=@deptid  
  
   --查找药品的拆零系数  
   select @dwbl=dwbl,@zxdw=zxdw  from yp_ypcl where cjid=@cjid and deptid=@deptid  
  
   if @dwbl=0 or @dwbl is null   
            begin  
   set @dwbl=1  
   set @zxdw=@ypdw   
     end  
      
    --如果库存拆零系数和拆零表中的系数不一样  
    if (@dwbl<>@kcdwbl or @zxdw<> @kczxdw) and @ncount>0   
               begin  
         set @Err_Text='发生错误,库存拆零系数和拆零表中的系数不一样,更新库存没有成功' +cast(@zxdw as char(10))+'  '+cast(@kczxdw as char(10)) + ' cjid='+cast(@cjid as varchar(30))  
    return  
        end   
  
   if @ncount=0 or @ncount is null  
  begin  
         insert into yf_kcmx(id,jgbm,ggid,cjid,kcl,xnkcl,zxdw,dwbl,djsj,bdelete,deptid,scjj,sckl,ghdw)values(dbo.FUN_GETGUID(newid(),getdate()),@jgbm,@ggid,@cjid,@ypsl*@dwbl/@ydwbl,@ypsl*@dwbl/@ydwbl,@zxdw,@dwbl,convert(nvarchar,getdate(),120),0,@deptid,@jhj,@ypkl,@wldw)  
        end  
   else  
         begin  
            update yf_kcmx set kcl=kcl+((@ypsl*dwbl)/@Ydwbl),xnkcl=xnkcl+((@ypsl*dwbl)/@Ydwbl),scjj=(case when @jhj>0 then @jhj else scjj end),  
       sckl=(case when @ypkl>0 then @ypkl else sckl end),ghdw=(case when @wldw>0 then @wldw else ghdw end ),  
    bdelete=(case when @ywlx not in('000') then bdelete else 0 end) where ggid=@ggid and cjid=@cjid and deptid=@deptid  
    if @@rowcount=0  
    begin  
      set @ERR_TEXT='更新库存时发生错误，影响到数据库0行';  
      return;  
    end    
         end  
    SET @Sypph=@ypph  
    if rtrim(@sypph)=''   
             --  begin  
             set @Sypph='无批号'  
             --  end  
  
  --如果不跟踪进价和进货金额，在此将进价更新为零  
  if @jjgl='0' or @jjgl is null   
     set @jhj=0  
  
   set @ncount=0  
   set @ncount=(select cjid from yf_kcph where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid and jhj=@jhj and deptid=@deptid)  
   IF @ncount=0 or @ncount is null   
      begin   
     if @phgl=0  
                     begin  
          set @Sypph='无批号'  
       set @ncount=(select CJID from yf_kcph where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid and jhj=@jhj and deptid=@deptid)  
       if coalesce(@ncount,0)>0   
          begin  
            update yf_kcph set kcl=kcl+((@ypsl*dwbl)/@Ydwbl),  
      bdelete=(case when @ywlx not in('000') then bdelete else 0 end),xgsj=GETDATE()  
            where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid and jhj=@jhj and deptid=@deptid  
      if @@rowcount=0  
      begin  
        set @ERR_TEXT='更新进货价时发生错误，影响到数据库0行';  
        return;  
      end    
                                     end  
       else  
               insert into yf_kcph(id,jgbm,ggid,cjid,kwid,ypph,ypxq,jhj,kcl,zxdw,dwbl,djsj,bdelete,deptid,xgsj)  
                  values(dbo.FUN_GETGUID(newid(),getdate()),@jgbm,@ggid,@cjid,@kwid,@Sypph,@ypxq,@jhj,@ypsl*@dwbl/@ydwbl,@ZXDW,@dwbl,convert(nvarchar,getdate(),120),0,@deptid,GETDATE())  
       end  
     else  
       begin  
          insert into yf_kcph(id,jgbm,ggid,cjid,kwid,ypph,ypxq,jhj,kcl,zxdw,dwbl,djsj,bdelete,deptid,xgsj)  
          values(dbo.FUN_GETGUID(newid(),getdate()),@jgbm,@ggid,@cjid,@kwid,@Sypph,@ypxq,@jhj,@ypsl*@dwbl/@ydwbl,@ZXDW,@dwbl,convert(nvarchar,getdate(),120),0,@deptid,GETDATE())  
             end  
   
     end  
   ELSE  
      begin --不管管理批号与否 只要找到了该批号就直接更新  
         update yf_kcph set kcl=kcl+((@ypsl*dwbl)/@Ydwbl),  
   bdelete=(case when @ywlx not in('000') then bdelete else 0 end),xgsj=GETDATE()  
        where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid and jhj=@jhj  and deptid=@deptid  
   if @@rowcount=0  
   begin  
     set @ERR_TEXT='更新进货价时发生错误，影响到数据库0行';  
     return;  
   end    
      end   
end  
  
 else  --进行批次管理  
  begin  
 --查找库存是否存在该药品  
   SET @KCZXDW=0  
   SET @KCDWBL=0  
   SET @DWBL=0  
   SET @ZXDW=0  
   set @ncount=0  
     
    if(LTRIM(RTRIM(@yppch))='' or @yppch is null)  
    begin  
   set @Err_Text='批次有误,不能为空,请修改['+@YPMC+'] 批号:'+isnull(@ypph,'')+' 数量:'+cast(@ypsl as varchar(50))  
   return   
    end  
     
   --查找药品的拆零系数  
   select @dwbl=dwbl,@zxdw=zxdw  from yp_ypcl where cjid=@cjid and deptid=@deptid  
  
   if @dwbl=0 or @dwbl is null   
        begin  
   set @dwbl=1  
   set @zxdw=@ypdw   
     end  
      
    --如果库存拆零系数和拆零表中的系数不一样  
    if (@dwbl<>@kcdwbl or @zxdw<> @kczxdw) and @ncount>0   
          begin  
        set @Err_Text='发生错误,库存拆零系数和拆零表中的系数不一样,更新库存没有成功' +cast(@zxdw as char(10))+'  '+cast(@kczxdw as char(10)) + ' cjid='+cast(@cjid as varchar(30))  
    return  
        end   
  --更新或插入kcmx  
  select @ncount=cjid,@kcdwbl=dwbl,@kczxdw=zxdw from yf_kcmx where cjid=@cjid and deptid=@deptid  
   if @ncount=0 or @ncount is null  
   begin  
          insert into yf_kcmx(id,jgbm,ggid,cjid,kcl,xnkcl,zxdw,dwbl,djsj,bdelete,deptid,scjj,sckl,ghdw)values(dbo.FUN_GETGUID(newid(),getdate()),@jgbm,@ggid,@cjid,@ypsl*@dwbl/@ydwbl,@ypsl*@dwbl/@ydwbl,@zxdw,@dwbl,convert(nvarchar,getdate(),120),0,@deptid,
@jhj,@ypkl,@wldw)  
          if @@ROWCOUNT=0  
             begin  
             set @ERR_TEXT='插入药库库存明细发生错误，影响到数据库0行';  
      return  
             end  
   end  
   else  
         begin  
            update yf_kcmx set kcl=kcl+((@ypsl*dwbl)/@Ydwbl),xnkcl=xnkcl+((@ypsl*dwbl)/@Ydwbl),scjj=(case when @jhj>0 then @jhj else scjj end),  
       sckl=(case when @ypkl>0 then @ypkl else sckl end),ghdw=(case when @wldw>0 then @wldw else ghdw end ),  
    bdelete=(case when @ywlx not in('000') then bdelete else 0 end) where ggid=@ggid and cjid=@cjid and deptid=@deptid  
    if @@rowcount=0  
    begin  
      set @ERR_TEXT='更新库存明细时发生错误，影响到数据库0行';  
      return;  
    end    
         end   
  
 declare @kcid_temp uniqueidentifier  
 set @kcid_temp=dbo.FUN_GETGUID(NEWID(),getdate())  
   
 ---更新或插入kcph  
 if (@ywlx in ('001','009','019'))  
 -- yppch/rkdh/maxsl/maxdwbl/rkdjmxid  
  begin  
   if RTRIM(@ypph)='' set @ypph='无批号'  
   insert into YF_KCPH (ID,JGBM,GGID,CJID,KWID,  
        YPPH,YPXQ,JHJ,KCL,ZXDW,  
        DWBL,DJSJ,BDELETE,DEPTID,yppch,  
        rkdh,rkdjmxid,maxsl,YJHJ,xgsj) values  
   (@kcid_temp,@jgbm,@ggid,@cjid,@kwid,  
   @ypph,@ypxq,  
   @jhj,  
   (@ypsl*@dwbl)/@ydwbl,@zxdw,  
   @dwbl,CONVERT(nvarchar,GETDATE(),120),0,@deptid,@yppch,  
   @djh,@kcid,((@ypsl*@dwbl))/@ydwbl,  
   @jhj,GETDATE())  
   if @@rowcount=0  
    begin  
      set @ERR_TEXT='插入库存时发生错误1，影响到数据库0行';  
      return;  
    end   
   --回填djmx中的kcid  
   update yf_djmx set kcid=@kcid_temp where id=@djmxid  
   if @@rowcount=0  
    begin  
      set @ERR_TEXT='回填单据明细时发生错误2，影响到数据库0行';  
      return;  
    end   
  end  
 else  
  begin  
    --查找kcph表中是否存在该该数据  
    set @ncount=0   
   select @ncount=cjid,@kcdwbl=dwbl,@kczxdw=zxdw,@kcid_temp=ID,@kcl_temp=KCL from YF_KCPH where cjid=@cjid and deptid=@deptid and yppch =@yppch  
   if @ncount=0 or @ncount is null --如果不存在则直接插入kcph  
    begin  
      if(@bqzkc=1 and @ypsl<0) --控制库存  
       begin  
        set @Err_Text='库房不允许批次库存为负数,请修改['+@YPMC+'] 批号:'+isnull(@ypph,'')+' 数量:'+cast(@ypsl as varchar(50))  
        return   
       end  
         
      if RTRIM(@ypph)='' set @ypph='无批号'  
        
      --获取原进货价  
      declare @yjhj decimal(15,4) --原进货价  
      if @ywlx in ('015','016') --015药品调入 016药库出库  
      begin  
       if @ywlx='016'  
        select @yjhj=YJHJ from YK_KCPH where yppch=@yppch and CJID=@cjid  
       else  
        select @yjhj=YJHJ from YF_KCPH where yppch=@yppch and CJID=@cjid   
      end  
        
      insert into YF_KCPH (ID,JGBM,GGID,CJID,KWID,  
        YPPH,YPXQ,JHJ,KCL,ZXDW,  
        DWBL,DJSJ,BDELETE,DEPTID,yppch,  
        rkdh,YJHJ,xgsj) values  
        (@kcid_temp,@jgbm,@ggid,@cjid,@kwid,  
        @ypph,@ypxq,  
        @jhj,  
        (@ypsl*@dwbl)/@ydwbl,@zxdw,  
        @dwbl,CONVERT(nvarchar,GETDATE(),120),0,@deptid,@yppch,  
       @djh,@yjhj,GETDATE())   
      if @@rowcount=0  
       begin  
        set @ERR_TEXT='插入批次库存时发生错误，影响到数据库0行';  
        return;  
       end    
        
      --回填单据明细中kcid  
      update yf_djmx set kcid=@kcid_temp where id=@djmxid  
      if @@rowcount=0  
       begin  
         set @ERR_TEXT='回填单据明细kcid时发生错误，影响到数据库0行';  
         return;  
       end   
        
    end  
   else   
    begin  --如果存在则进行更新kcph  
      --set @Err_Text='aa' +cast(@ypsl as varchar(50)) 
      --return
     if (@bqzkc=1 and ((@kcl_temp+((@ypsl*@kcdwbl)/@Ydwbl)) <0)) --强制控制库存  
      begin  
       set @Err_Text='库房不允许批次库存为负数,请修改['+isnull(@YPMC,'')+'] 批号:'+isnull(@ypph,'')+' 数量:'+cast(@ypsl as varchar(50))  
       return   
      end  

     if(@ywlx in ('002'))--如果为退货单，需要更新maxsl、maxdwbl字段   
      begin  
       update YF_KCPH set KCL=KCL+((@ypsl*DWBL)/@ydwbl),  
       BDELETE =(case when @ywlx not in('000') then bdelete else 0 end),  
       maxsl=maxsl+((@ypsl*DWBL)/@ydwbl),xgsj=GETDATE()  
       where GGID=@ggid and CJID =@cjid --and RTRIM(YPPH)=RTRIM(@ypph)   
       and KWID=@kwid   
       and DEPTID=@deptid    --拆零则会发生进价对不上 故取消查询条件中的进价   
       and yppch=@yppch   
       if @@rowcount=0  
        begin  
         set @ERR_TEXT='更新批次库存时发生错误，影响到数据库0行';  
         return;  
        end   
      end  
     else  
      begin  

       update YF_KCPH set KCL=KCL+((@ypsl*DWBL)/@ydwbl),  
       BDELETE =(case when @ywlx not in('000') then bdelete else 0 end),xgsj=GETDATE()  
       where GGID=@ggid and CJID =@cjid   
       --and RTRIM(YPPH)=RTRIM(@ypph)   
       and KWID=@kwid   
       and DEPTID=@deptid    --拆零则会发生进价对不上 故取消查询条件中的进价   
       and yppch=@yppch   
       if @@rowcount=0  
        begin  
         set @ERR_TEXT='更新批次库存时发生错误，影响到数据库0行';  
         return;  
        end   
       if(( @ywlx ='015' or @ywlx='016') and @kcid=dbo.FUN_GETEMPTYGUID()) --药品调入单 药库出库单  
        begin  
         update YF_DJMX set kcid=@kcid_temp where id=@djmxid   
         if @@rowcount=0  
         begin   
           set @ERR_TEXT='回填单据明细kcid时发生错误015,016，影响到数据库0行';  
           return;  
         end  
        end  
      end   
    end  
  end  
 end  
   
 fetch next from t1 into @cjid,@ypph,@ypsl,@ydwbl,@deptid,@kwid,@ypxq,@ggid,@jhj,@ypkl,@wldw,@ypdw,@ywlx,@yppch,@kcid,@djh,@djmxid  ,@ypmc
end  
  
   
CLOSE t1  
DEALLOCATE t1  
  
 SET @Err_Code=0  
 SET @Err_Text='保存成功'  
end
GO


