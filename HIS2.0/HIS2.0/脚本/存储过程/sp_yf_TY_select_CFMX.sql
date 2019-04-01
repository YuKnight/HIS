IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[sp_yf_TY_select_CFMX]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yf_TY_select_CFMX]
go
create PROCEDURE sp_yf_TY_select_CFMX --发药查找处方明细  
(  
  @cfxh UNIQUEIDENTIFIER,  
  @fph bigint,  
  @fyid UNIQUEIDENTIFIER
)  
as  
begin  
  declare @ssql varchar(2000);  
  
		 SET @SSQL='select 0,a.psbz 皮试,a.YPpm 药品名称,a.ypgg 规格,a.YPCJ 厂家,'+  
			'a.pfj 批发价,cast(a.lsj as float) 零售价,cast(a.ypsl as float) 用量,a.ypdw 单位,(a.PFJE) 批发金额,cast(a.LSJE as float) 零售金额,'+  
			'a.cfxh,a.cjid ypid,a.Ydwbl,a.YPHH 货号,0 调价差额,a.cfts,a.id,a.FYID,a.tyid,a.deptid,a.CFMXID,  
		  (case when ypsl>0 then (ypsl+isnull((select sum(ypsl) from yf_fymx where tyid=a.id),0)) else 0 end) tysl,a.syff 用法,a.zt  嘱托
		  ,a.ypph 批号,a.ypxq 效期,a.yppch 批次号,a.jhj 进价,a.jhje 进货金额  ,a.kcid,hjb.byscf
		   from Yf_FYMX a left join YF_FY fy on a.fyid = fy.id 
		   left join MZ_CFB cfb on cfb.cfid = fy.CFXH
		   left join MZ_HJB hjb on hjb.HJID = cfb.HJID  where 1>0 '  
		   if @fph>0  
			set @ssql=@ssql+' and a.fph='+cast(@fph as varchar(50)) + '';  
		   if @cfxh<>dbo.FUN_GETEMPTYGUID()    
			set @ssql=@ssql+' and a.cfxh='''+cast(@cfxh as varchar(50))+''''  
			if @fyid<>dbo.FUN_GETEMPTYGUID()    
			  set @ssql=@ssql +' and (a.fyid='''+cast(@fyid as varchar(50))+''' or a.fyid=dbo.FUN_GETEMPTYGUID())';  
		--set @ssql=@ssql +' and fyid='''+cast(@fyid as varchar(50))+'''';  
		 
		set @ssql=@ssql+' union all select 0,a.psbz 皮试,a.YPmc 药品名称,a.ypgg 规格,a.YPCJ 厂家,'+  
			'a.pfj 批发价,cast(a.lsj as float) 零售价,cast(a.ypsl as float) 用量,a.ypdw 单位,(a.PFJE) 批发金额,cast(a.LSJE as float) 零售金额,'+  
			'a.cfxh,a.cjid ypid,a.Ydwbl,a.YPHH 货号,0 调价差额,a.cfts,a.id,a.FYID,a.tyid,a.deptid,a.CFMXID,  
		  (case when ypsl>0 then (ypsl+isnull((select sum(ypsl) from yf_fymx_h where tyid=a.id),0))
			else 0 end) tysl,a.syff 用法,a.zt  嘱托 
			,a.ypph 批号,a.ypxq 效期,a.yppch 批次号,a.jhj 进价,a.jhje 进货金额,a.kcid,hjb.byscf
		   from Yf_FYMX_h a left join YF_FY fy on a.fyid = fy.id 
		   left join MZ_CFB cfb on cfb.cfid = fy.CFXH
		   left join MZ_HJB hjb on hjb.HJID = cfb.HJID  where 1>0 '   
		   if @fph>0  
			set @ssql=@ssql+' and a.fph='+cast(@fph as varchar(50)) + '';  
		   if @cfxh<>dbo.FUN_GETEMPTYGUID()    
			set @ssql=@ssql+' and a.cfxh='''+cast(@cfxh as varchar(50))+''''  
			if @fyid<>dbo.FUN_GETEMPTYGUID()    
			  set @ssql=@ssql +' and (a.fyid='''+cast(@fyid as varchar(50))+''' or a.fyid=dbo.FUN_GETEMPTYGUID())';  
		 set @ssql=@ssql+' order by id';
		 exec(@ssql)  
		  
		if @@rowcount=0  
		begin  
		   SET @SSQL=@ssql+'  select 0 序号,a.psbz 皮试,a.YPpm 药品名称,a.ypgg 规格,a.YPCJ 厂家,'+  
			'a.pfj 批发价,a.lsj 零售价,a.ypsl 用量,a.ypdw 单位,a.(PFJE) 批发金额,a.(LSJE) 零售金额,'+  
			'a.cfxh,a.cjid ypid,a.Ydwbl,a.YPHH 货号,0 调价差额,a.cfts,a.id,a.FYID,a.tyid,a.deptid,a.CFMXID,  
		  (case when ypsl>0 then (ypsl+isnull((select sum(ypsl) from yf_fymx where tyid=a.id),0)) else 0 end) tysl,a.syff 用法,a.zt  嘱托 
		  ,a.ypph 批号,a.ypxq 效期,a.yppch 批次号,a.jhj 进价,a.jhje 进货金额  ,a.kcid,a.hjb.byscf
		  from Yf_FYMX_h a left join YF_FY fy on a.fyid = fy.id 
		   left join MZ_CFB cfb on cfb.cfid = fy.CFXH
		   left join MZ_HJB hjb on hjb.HJID = cfb.HJID  where 1>0 '   
		   if @fph>0  
			set @ssql=@ssql+' and a.fph='+cast(@fph as varchar(50)) + '';  
		   if @cfxh<>dbo.FUN_GETEMPTYGUID()    
			set @ssql=@ssql+' and a.cfxh='''+cast(@cfxh as varchar(50))+''''  
			if @fyid<>dbo.FUN_GETEMPTYGUID()   
			  set @ssql=@ssql +' and a.fyid='''+cast(@fyid as varchar(50))+''' or a.fyid=dbo.FUN_GETEMPTYGUID())';  
		--set @ssql=@ssql +' and fyid='''+cast(@fyid as varchar(50))+'''';  
		  set @ssql=@ssql+' order by id';  
		end  
end 