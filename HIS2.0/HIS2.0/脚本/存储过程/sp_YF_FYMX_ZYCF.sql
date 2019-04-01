IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_YF_FYMX_ZYCF]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_YF_FYMX_ZYCF]
GO
CREATE PROCEDURE [dbo].[sp_YF_FYMX_ZYCF]
(
 	@fyid UNIQUEIDENTIFIER,--YF——YF表ID
	@FPH BIGINT , --可不传
	@CFXH UNIQUEIDENTIFIER,--传费用ID
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
	@deptid int,
	@tyid UNIQUEIDENTIFIER,  --可不传
	@ypph varchar(20),
	@Err_Code INTEGER  output,
    @err_Text VARCHAR(250) output,
    
    
    @jhj decimal(15,4),			--进货价
    @jhje decimal(15,3),		--进货金额
    @ypxq char(10),				--效期
    @yppch varchar(100),		--批次号
    @kcid uniqueidentifier,		--kcid
    @bpcgl smallint				--是否进行批次管理	 
) 
as
/*
Modify By Tany 2015-01-09 库存批号增加修改时间
*/
 declare @tpfje decimal(15,3);
 declare @tlsje decimal(15,3);
 declare @fymxid UNIQUEIDENTIFIER ;--发药明细ID
 declare @xpfj decimal(15,3) 
 declare @xlsj decimal(15,3)
 declare @xdwbl int 
 declare @bkc int 
 declare @ckl decimal(15,3);
 declare @dqckl decimal(15,3);
 declare @ys decimal(15,3);
 --declare @jhj decimal(15,4)  --进价
 --declare @jhje decimal(15,3) --进货金额
 
 --set @jhj=0
 --set @jhje=0

 set @Err_Code=-1;
 set @Err_Text='';
 
if @CJID=0 
begin
   	    set @Err_Text='CJID为零';
	    return;
end
if @tyid=dbo.FUN_GETEMPTYGUID()
 set @tyid=null 

 if @bpcgl =0 --不进行批次管理
	begin
		--是否强制控制库存变量
		set @bkc=(select zt from yk_config where bh='101' and deptid=@deptid );
		set @bkc=coalesce(@bkc,0);
		 
		--计算出库量
		set @ckl=(select @ypsl*@CFTS*dwbl/@dwbl from YF_kcmx where cjid=@cjid and deptid=@deptid);
		if @ckl is null 
		begin
 				set @Err_Text='找不到库存记录,发药没有成功';
					set @Err_Code=-1;
				return;
		end
		 
		 --初始余数
		 set @ys=@ckl;
		 
		 --计算调价误差
		select @xpfj=pfj,@xlsj=lsj,@xdwbl=dwbl  from vi_yf_kcmx where cjid=@cjid and deptid=@deptid;
		if @xlsj is null 
		begin
 			 set @Err_Code=-1;
			 set @Err_Text='没有找到库存记录,发药没有成功';
			 return;
		end
		 
		set @tpfje=0;
		set @tlsje=0;
		 
		if (@pfj*@dwbl)-@xpfj<>0 
			set @tpfje=@pfje-round(@xpfj*@ckl/@xdwbl,3);

		 
		if (@lsj*@dwbl)-@xlsj<>0 
			set @tlsje=@lsje-round(@xlsj*@ckl/@xdwbl,3);


		--插入发药明细表
		set @fymxid=dbo.FUN_GETGUID(newid(),getdate())
		insert into yf_FYMX(id,fyid,FPH,CFXH,CJID,YPHH,YPPM,YPSPM,YPGG,YPCJ,YPDW,YDWBL,YPSL,cfts,PFJ,PFJE,LSJ,LSJE,Tpfje,tlsje,deptid,tyid)
		values(@fymxid,@fyid,@FPH,@CFXH,@CJID,@YPHH,@YPPM,@YPSPM,@YPGG,@YPCJ,@YPDW,@DWBL,@YPSL,@CFTS,@PFJ,@PFJE,@LSJ,@LSJE,@tpfje,@tlsje,@deptid,@tyid);
		if @@rowcount=0 or @fymxid=dbo.FUN_GETEMPTYGUID() or @fymxid is null
		begin
				set @Err_Text='插入发药明细表没有成功，影响到数据库0行';
				return;
		end

		 

		declare @t1_id UNIQUEIDENTIFIER
		declare @t1_kcl decimal(15,3)
		declare @t1_ypph varchar(20)
		declare @t1_cjid int
		declare @t1_deptid int
		declare @t1_jhj decimal(15,4)

		declare t1 cursor local for  select id,kcl,ypph,cjid,deptid,round(jhj/dwbl,4) from YF_kcph where cjid=@cjid and deptid=@deptid and    ((@ypsl>0 and kcl>0) or (@ypsl<=0))  and bdelete=0 order by ypxq
		open  t1
		fetch next from t1 into @t1_id,@t1_kcl,@t1_ypph,@t1_cjid,@t1_deptid,@t1_jhj

		while @@FETCH_STATUS=0
		begin
		  set @dqckl=0;
		  if @T1_kcl-(@ys)>=0 or @ys<0
		  begin
			set @dqckl=@ys;
			set @ys=0;
		  end
				  
		  if @T1_kcl-(@ys)<0 
		  begin
			 set @dqckl=@T1_kcl;
			 set @ys=@ys-(@T1_kcl);	 
		  end

		  set @jhje=@jhje+@t1_jhj*@dqckl
			 
		  --更新库存批号表
		  update YF_kcph set kcl=kcl-(@dqckl),xgsj=GETDATE() where  cjid=@T1_cjid and id=@T1_id and deptid=@T1_deptid;
		  if @@ROWCOUNT=0
		  begin
			  set @Err_Text='更新库存批号没有成功，影响到数据库0行a'+cast(@t1_cjid as char(10))+cast(@t1_id as char(10));
			  return;
		  end 

		  fetch next from t1 into @t1_id,@t1_kcl,@t1_ypph,@t1_cjid,@t1_deptid,@t1_jhj
		end

		CLOSE t1
		DEALLOCATE t1
		 
		--如果强控制库存
		if @ys>0 and @bkc=1 
		begin
    			set @Err_Text='[ '+@ypcj+']  生产的 [ '+@ypspm+' ] ' +'库存不够,发药没有成功';
			set @Err_Code=-1;
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

		declare t2 cursor local for  select top 1 id,kcl,ypph,cjid,deptid,round(jhj/dwbl,4) from YF_kcph where cjid=@cjid and deptid=@deptid  order by ypxq desc 
		open  t2
		fetch next from t2 into @t2_id,@t2_kcl,@t2_ypph,@t2_cjid,@t2_deptid,@t2_jhj
		while @@FETCH_STATUS=0
		begin
			set @jhje=@jhje+@t2_jhj*@dqckl
    			 --更新库存批号表
			update YF_kcph set kcl=kcl-(@dqckl),xgsj=GETDATE() where  cjid=@T2_cjid and id=@T2_id and deptid=@T2_deptid;
			if @@rowcount=0 
			begin
	      			set @Err_Text='更新库存批号没有成功，影响到数据库0行b';
	    			return;
    			end 
							 
			 --余数置零
			set @ys=0; 
			
			fetch next from t2 into @t2_id,@t2_kcl,@t2_ypph,@t2_cjid,@t2_deptid,@t2_jhj
		end   
		end

		--CLOSE t2
		--DEALLOCATE t2

		--更新进货金额
		if @ckl<>0
		begin
		update yf_fymx set jhj=round(@jhje/@ckl,4),jhje=round(@jhje,3) where id=@fymxid
		if @@rowcount=0
		begin
			 set @ERR_TEXT='更新进货金额时发生错语，影响到数据库0行';
			 return;
		end  
		end 

		--更新库存表
		update YF_kcmx set kcl=kcl-(@ckl)   where  cjid=@cjid and deptid=@deptid;
		if @@rowcount=0
		begin
				set @Err_Text='更新库存没有成功，影响到数据库0行cjid='+cast(@cjid as char(30))
				return;
		end  
		 

		--如果余数继续为零则报错
		if @ys<>0 
		begin
			set @Err_Text='发药时系统没有更新到库存记录,发药没有成功cjid='+cast(@cjid as varchar(30))+' deptid='+cast(@deptid as varchar(30))+' ys='+cast(@ys as varchar(20))+' bkc='+cast(@bkc as varchar(10))
			set @Err_Code=-1;
			return;
		end 
			 
		  SET @Err_Text='保存成功';
		  SET @Err_Code=0
	end
 else
	begin
		--计算出库量
		set @ckl=(select @ypsl*@CFTS*dwbl/@dwbl from YF_kcmx where cjid=@cjid and deptid=@deptid)
		if @ckl is null 
			begin
 				   set @ERR_TEXT='找不到库存记录,发药没有成功'
				   set @ERR_CODE=-1
				   return
			end

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
		if @fymxid is null or @fymxid=dbo.FUN_GETEMPTYGUID()
			begin
				set @fymxid=dbo.FUN_GETGUID(newid(),getdate())
				insert into yf_FYMX(
					id,fyid,FPH,CFXH,CJID,
					YPHH,YPPM,YPSPM,YPGG,YPCJ,
					YPDW,YDWBL,YPSL,cfts,PFJ,
					PFJE,LSJ,LSJE,Tpfje,tlsje,
					deptid,tyid,
					
					JHJ,JHJE,ypph,ypxq,yppch,KCID
					)
				values(
					@fymxid,@fyid,@FPH,@CFXH,@CJID,
					@YPHH,@YPPM,@YPSPM,@YPGG,@YPCJ,
					@YPDW,@DWBL,@YPSL,@CFTS,@PFJ,
					@PFJE,@LSJ,@LSJE,@tpfje,@tlsje,
					@deptid,@tyid,
					
					@jhj,@jhje,@ypph,@ypxq,@yppch,@kcid				
					 )
 							 
 				if @@rowcount=0 or @fymxid=dbo.FUN_GETEMPTYGUID() or @fymxid is null 
					begin
						set @ERR_TEXT='插入发药明细表没有成功，影响到数据库0行'
						return
					end
					
			    --更新明细库存
			    update YF_KCMX set KCL=KCL-@ckl,XNKCL=XNKCL-@ckl where CJID=@CJID and DEPTID=@deptid and KCL>=@ckl
				if @@ROWCOUNT<=0
					begin
						set @ERR_TEXT=@YPPM+ ' 更新库存明细失败 '+CAST(@ckl as varchar(50))
						set @ERR_CODE=-1
						return
					end
			    
			    --更新批号库存
			     update YF_KCPH set KCL=KCL-@ckl,xgsj=GETDATE() where CJID=@CJID and DEPTID=@deptid and id=@kcid and KCL>=@ckl
				 if @@ROWCOUNT<=0
					begin
						set @ERR_TEXT='更新库存批号失败,批次号:' +@yppch + ',编号:'+ CONVERT(varchar(max),@CJID) + '商品名:'+ @YPSPM + ',出库量:' + CONVERT(varchar(max),@ckl)
						set @ERR_CODE=-1
						return
					end
			 
				SET @ERR_TEXT='保存成功'
				SET @ERR_CODE=0
			end
		else
			begin
				set @ERR_TEXT='修改失败'
				return
			end
  end





GO


