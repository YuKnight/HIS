--启用批次管理的仓库
--如果从没启用批次管理的仓库 调东西到启用批次管理的仓库  则在此处产生kcid？
-- 如果从有批次管理的仓库调东西到没启用批次管理的仓库 则按照原办法进行库存处理
--exec SP_YK_XTDZ '2014-03-30 14:48:54',218  

--假定现在按库房id判断是否启用批次管理  
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_XTDZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_XTDZ
GO

CREATE PROCEDURE SP_YK_XTDZ
 (@JSRQ datetime,
  @deptid integer
 )
as

BEGIN
declare @jcsl decimal(15,3);
declare @jcjhje decimal(15,3); --结存进货金额
declare @jcpfje decimal(15,3);
declare @jclsje decimal(15,3);
declare @bqsl decimal(15,3); 
declare @bqjhje decimal(15,3); --本期进货金额
declare @bqpfje decimal(15,3);
declare @bqlsje decimal(15,3);

declare @yjid UNIQUEIDENTIFIER 
declare @count INT 
declare @year int;
declare @month int;

declare @tx_deptid int--循环多个科室

declare @t1_zxdw int
declare @t1_dwbl int
declare @t1_cjid int
declare @t1_shh varchar(20)
declare @t1_yppm varchar(100)
declare @t1_ypspm varchar(100)
declare @t1_ypgg varchar(50)
declare @t1_sccj varchar(100)
declare @t1_kcl DECIMAL(15,3)
declare @t1_kcjhje decimal(15,3)  
declare @t1_kcpfje DECIMAL(15,3)
declare @t1_kclsje DECIMAL(15,3)

declare @t1_jhj decimal(15,3) 
declare @t1_ypph varchar(30)
declare @t1_ypxq char(10)
declare @t1_yppch varchar(100)
declare @t1_kcid uniqueidentifier



 --单据明细
 create TABLE #DJMX
   (
      ID int IDENTITY (1, 1) NOT NULL ,
   	  CJID INT,
	  YPSL DECIMAL(15,3), --数量
	  jhje decimal(15,3), --进货金额
	  PFJE decimal(15,3),
	  LSJE decimal(15,3),
	  yppch varchar(100), --批次号
	  ypph varchar(30),   --批号
	  ypxq char(10) ,     --效期
	  kcid uniqueidentifier --
   ) 
   
 --库存明细
 create TABLE #KCMX
   (
   	  CJID INT,
	  shh varchar(20),
	  yppm varchar(100),
	  ypspm varchar(100),
	  ypgg varchar(50),
	  sccj varchar(100),
	  --jhj decimal(15,3),  --进货价
	  pfj decimal(15,3),
	  lsj decimal(15,3),
	  KCL DECIMAL(15,3),
	  ZXDW INT,
	  DWBL INT,
	  KCPFJE DECIMAL(15,3),
	  KCLSJE DECIMAL(15,3),
   )
   
 --库存批号
 create table #kcph
 (
	cjid int,
	shh varchar(20),
	yppm varchar(100),
	ypspm varchar(100),
	ypgg varchar(50),
	sccj varchar(100),
	jhj decimal(15,3),  --进货价
	pfj decimal(15,3),
	lsj decimal(15,3),
	kcl decimal(15,3),
	zxdw int,
	dwbl int,
	kcjhje decimal(15,3), 
	kcpfje decimal(15,3),
	kclsje decimal(15,3),
    kcid  uniqueidentifier ,
	yppch varchar(100), --批次号
	ypph varchar(30)    --批号
 )

 --结果表
 create TABLE #temp
   (
   	  cjid INT,
	  deptid int,
	  SHH VARCHAR(20),
	  yppm varchar(100),
	  ypspm varchar(100),
	  ypgg varchar(50),
	  sccj varchar(100),
	  ypdw varchar(10),
	  jcsl DECIMAL(15,3),
	  jcjhje decimal(15,3),  --结存进货金额
  	  jcpfje DECIMAL(15,3),
	  jclsje DECIMAL(15,3),
	  bqsl DECIMAL(15,3),
	  bqjhje decimal(15,3),  --本期进货金额
	  bqpfje DECIMAL(15,3),
  	  bqlsje DECIMAL(15,3),
	  kcsl DECIMAL(15,3),
	  kcjhje decimal(15,3),  --库存进货金额
	  kcpfje DECIMAL(15,3),
	  kclsje DECIMAL(15,3),
	  dwbl int,
	  kcid uniqueidentifier,
	  yppch varchar(100),
	  ypph varchar(30),
   )

--科室级循环
declare tx cursor local for  select dept_id from jc_dept_property  where dept_id=@deptid or dept_id in(select deptid from yp_yjks_gx where p_deptid=@deptid)
open  tx
fetch next from tx into  @tx_deptid
while @@FETCH_STATUS=0
begin
     --首先判断该库房是否进行批次管理  
	declare @bpcgl int =0;
	select @bpcgl = zt from yk_config where deptid =@tx_deptid and bh =999--暂时设定为999
	if(@bpcgl=0 or @bpcgl is null)
		begin
			TRUNCATE TABLE #djmx
			TRUNCATE TABLE #KCMX
			set @yjid=dbo.FUN_GETEMPTYGUID();
			set @year=0;
			set @month=0;
			 --初始化上期会计年、月、YJID 变量
			SELECT top 1 @yjid=id,@year=kjnf,@month=kjyf FROM YP_KJQJ WHERE DEPTID=@tx_deptid  order by kjnf desc ,kjyf desc 
			if @yjid is null 
			begin
				  set @yjid=dbo.FUN_GETEMPTYGUID();
				  set @year=0;
				  set @month=0;
			end
		
			--汇总本期单据的发生数量和金额
			INSERT INTO #DJMX(CJID,YPSL,PFJE,LSJE)
			SELECT c.cjid,
			sum(case when a.ywlx='005' then 0 else dbo.fun_yk_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
			sum(dbo.fun_Yk_drt(a.ywlx,pfje)),
			sum(dbo.fun_yk_drt(a.ywlx,lsje))
			FROM YK_DJ A,YK_DJMX B,yk_kcmx c 
			WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=C.deptid and A.DEPTID=@tx_deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null) and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002'))) group by c.cjid;
				
			--汇总当前库存数量和金额
			insert into #kcmx(cjid,shh,yppm,ypspm,ypgg,sccj,pfj,lsj,kcl,zxdw,dwbl,kcpfje,kclsje) 
			select a.cjid,shh,yppm,ypspm,ypgg,s_sccj,pfj,lsj,kcl,zxdw,dwbl,cast(round(pfj*kcl/a.dwbl,3) as decimal(15,3)),cast(round(lsj*kcl/a.dwbl,3) as decimal(15,3)) from Yk_kcmx a,vi_yp_ypcd b 
			where a.cjid=b.cjid and a.deptid=@tx_deptid;
		
			declare t1 cursor local for  select cjid,shh,yppm,ypspm,ypgg,sccj,kcl,zxdw,dwbl,kcjhje,kcpfje,kclsje,kcid  from #kcph  
			open  t1
			fetch next from t1 into @t1_cjid,@t1_shh,@t1_yppm,@t1_ypspm,@t1_ypgg,@t1_sccj,@t1_kcl,@t1_zxdw,@t1_dwbl,@t1_kcjhje,@t1_kcpfje,@t1_kclsje,@t1_kcid 
			while @@FETCH_STATUS=0
			begin
				   set @jcsl=0;
				   set @jcpfje=0;
				   set @jclsje=0;
				   set @bqsl=0;
				   set @bqpfje=0;
				   set @bqlsje=0;
				   --初始当前药品的上期结存
				   select @jcsl=(jcsl*@t1_dwbl)/ydwbl,@jcpfje=jcpfje,@jclsje=jclsje 
				   from YK_YMJC where deptid=@tx_deptid and cjid=@t1_cjid and nf=@year and yf=@month and kcid =@t1_kcid ; 
				   set @jcsl=coalesce(@jcsl,0);
				   set @jcpfje=coalesce(@jcpfje,0);
				   set @jclsje=coalesce(@jclsje,0);
				   
				   --初始单据变量
				   select @bqsl=ypsl,@bqpfje=pfje,@bqlsje=lsje  from #djmx where cjid=@t1_cjid 
				   set @bqsl=coalesce(@bqsl,0);
				   set @bqpfje=coalesce(@bqpfje,0);
				   set @bqlsje=coalesce(@bqlsje,0);
				   --插入结果
				   insert into #temp(deptid,cjid,shh,yppm,ypspm,ypgg,sccj,ypdw,jcsl,jcpfje,jclsje,bqsl,bqpfje,bqlsje,kcsl,kcpfje,kclsje,dwbl)values
				   (@tx_deptid,@t1_cjid,@t1_shh,@t1_yppm,@t1_ypspm,@t1_ypgg,@t1_sccj,dbo.fun_yp_ypdw(@t1_zxdw),@jcsl,@jcpfje,@jclsje,@bqsl,@bqpfje,@bqlsje,
				   @t1_kcl,@t1_kcpfje,@t1_kclsje,@t1_dwbl);

				   fetch next from t1 into  @t1_cjid,@t1_shh,@t1_yppm,@t1_ypspm,@t1_ypgg,@t1_sccj,@t1_kcl,@t1_zxdw,@t1_dwbl,@t1_kcpfje,@t1_kclsje
			end  
			CLOSE t1
			DEALLOCATE t1  
	end   
	else   --进行批次管理  
	   begin
			TRUNCATE TABLE #djmx
			TRUNCATE TABLE #KCMX
			set @yjid=dbo.FUN_GETEMPTYGUID();
			set @year=0;
			set @month=0;
			 --初始化上期会计年、月、YJID 变量
			SELECT top 1 @yjid=id,@year=kjnf,@month=kjyf FROM YP_KJQJ WHERE DEPTID=@tx_deptid  order by kjnf desc ,kjyf desc 
			if @yjid is null 
			begin
				  set @yjid=dbo.FUN_GETEMPTYGUID();
				  set @year=0;
				  set @month=0;
			end
		
			--汇总本期单据的发生数量和金额
			INSERT INTO #DJMX(CJID,YPSL,jhje,PFJE,LSJE,kcid,yppch,ypph,ypxq)
			SELECT c.cjid,
			sum(case when a.ywlx='005' then 0 else dbo.fun_yk_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,--数量
			sum(dbo.fun_yk_drt(a.ywlx,jhje)), --进货金额
			sum(dbo.fun_Yk_drt(a.ywlx,pfje)), --批发金额
			sum(dbo.fun_yk_drt(a.ywlx,lsje)), --零售金额
			c.ID,
			c.yppch,
			c.ypph ,
			c.YPXQ 
			FROM YK_DJ A inner join YK_DJMX B on A.ID=b.DJID
			inner join yk_kcph c on b.kcid=c.ID and b.CJID=c.CJID and c.DEPTID=b.DEPTID 
			WHERE  A.DEPTID=@tx_deptid  
			and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null) and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002')))  
			group by c.cjid,c.ID,c.yppch,c.YPPH,c.YPXQ;  --增加kcid
				
			
			--获取当前批号库存数量和金额  --只取数量大于0的批号库存
			insert into #kcph(cjid,shh,yppm,ypspm,ypgg,sccj,jhj,pfj,lsj,kcl,zxdw,dwbl,kcjhje,kcpfje,kclsje,kcid,yppch,ypph) 
			select a.cjid,shh,yppm,ypspm,ypgg,s_sccj,a.jhj,pfj,lsj,kcl,zxdw,dwbl,
			cast(round(jhj*kcl/a.dwbl,3) as decimal(15,3)),
			cast(round(pfj*kcl/a.dwbl,3) as decimal(15,3)),cast(round(lsj*kcl/a.dwbl,3) as decimal(15,3)),
			ID,yppch,ypph   
			from yk_kcph a,vi_yp_ypcd b 
			where a.cjid=b.cjid  and a.deptid=@tx_deptid
			and KCL>0 
			;  
			
		    --这个地方的循环就有点大了 可以考虑只循环 上期有结存,或者本期有库存,或者本期有单据明细的库存 
			declare t1 cursor local for  select a.cjid,a.shh,a.yppm,a.ypspm,a.ypgg,a.sccj,a.kcl,a.zxdw,a.dwbl,a.kcjhje,a.kcpfje,a.kclsje,a.kcid  from #kcph a  
						where a.kcid in 
						(
							--汇总上期结存数量>0 + 本期单据明细 +当前库存数量>0 的kcid 
							select kcid from #kcph union select kcid from #DJMX union select kcid from YK_YMJC  where
																		 deptid=@tx_deptid and cjid=@t1_cjid and nf=@year and yf=@month and jcsl>0
						)							
			open  t1
			fetch next from t1 into @t1_cjid,@t1_shh,@t1_yppm,@t1_ypspm,@t1_ypgg,@t1_sccj,@t1_kcl,@t1_zxdw,@t1_dwbl,@t1_kcjhje,@t1_kcpfje,@t1_kclsje,@t1_kcid
			while @@FETCH_STATUS=0
			begin
				   set @jcsl=0;   --结存数量
				   set @jcjhje=0;
				   set @jcpfje=0;
				   set @jclsje=0;
				   set @bqsl=0;   --本期数量
				   set @bqjhje=0; --本期进货金额
				   set @bqpfje=0; --本期批发金额
				   set @bqlsje=0; --本期零售金额
				   --初始当前药品的上期结存
				   select @jcsl=(jcsl*@t1_dwbl)/ydwbl,
				   @jcjhje=jcjhje,
				   @jcpfje=jcpfje,
				   @jclsje=jclsje  
				   from YK_YMJC where deptid=@tx_deptid and cjid=@t1_cjid and nf=@year and yf=@month
				     and kcid =@t1_kcid  ; 
				   set @jcsl=coalesce(@jcsl,0);
				   set @jcjhje=coalesce(@jcjhje,0);
				   set @jcpfje=coalesce(@jcpfje,0);
				   set @jclsje=coalesce(@jclsje,0);
				   
				   --初始单据变量
				   select @bqsl=ypsl, @bqjhje=jhje ,
				    @bqpfje=pfje,@bqlsje=lsje  from #djmx where cjid=@t1_cjid and kcid=@t1_kcid 
				   set @bqsl=coalesce(@bqsl,0);
				   set @bqjhje=coalesce(@bqjhje,0);
				   set @bqpfje=coalesce(@bqpfje,0);
				   set @bqlsje=coalesce(@bqlsje,0);
				  
				   --插入结果
				   insert into #temp(deptid,cjid,shh,yppm,ypspm,ypgg,sccj,ypdw,jcsl,jcjhje,jcpfje,jclsje,bqsl,bqjhje,bqpfje,bqlsje,kcsl,kcjhje,kcpfje,kclsje,dwbl,
				   kcid,yppch,ypph)values
				   (@tx_deptid,@t1_cjid,@t1_shh,@t1_yppm,@t1_ypspm,@t1_ypgg,@t1_sccj,dbo.fun_yp_ypdw(@t1_zxdw),@jcsl,@jcjhje,@jcpfje,@jclsje,@bqsl,@bqjhje,@bqpfje,@bqlsje,
				   @t1_kcl,@t1_kcjhje,@t1_kcpfje,@t1_kclsje,@t1_dwbl,
				   @t1_kcid,@t1_yppch,@t1_ypph );

				  fetch next from t1 into @t1_cjid,@t1_shh,@t1_yppm,@t1_ypspm,@t1_ypgg,@t1_sccj,@t1_kcl,@t1_zxdw,@t1_dwbl,@t1_kcjhje,@t1_kcpfje,@t1_kclsje,@t1_kcid
			end  
			CLOSE t1
			DEALLOCATE t1
	   end
			
fetch next from tx into  @tx_deptid
end	

if(@bpcgl=0 or @bpcgl is null) --不进行批次管理
begin
	 --select cjid,dbo.fun_getdeptname(deptid) 仓库名称,shh 货号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,ypdw 单位,jcsl 上期数量,jcpfje 上期批发金额,jclsje 上期零售金额,
	 --bqsl 发生数量,bqpfje 发生批发金额,bqlsje 发生零售金额,
	 --kcsl 库存数量,kcpfje 库存批发金额,kclsje 库存零售金额,(jcsl+bqsl-kcsl) 数量差值,
	 --(jcpfje+bqpfje-kcpfje) 批发金额差值,CAST((jclsje+bqlsje-kclsje) AS DECIMAL(15,3)) 零售金额差值,dwbl ,deptid
	 -- from #temp where (jcsl+bqsl-kcsl)<>0  or (jclsje+bqlsje-kclsje)<>0  or (jcpfje+bqpfje-kcpfje)<>0  --where (jcsl+bqsl-kcsl)<>0 or (jcpfje+bqpfje-kcpfje)<>0 or (jclsje+bqlsje-kclsje)<>0
	 
	 	 select cjid,dbo.fun_getdeptname(deptid) 仓库名称,shh 货号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,ypdw 单位,
	 jcsl 上期数量, 0 上期进货金额, jcpfje 上期批发金额,jclsje 上期零售金额,
	 bqsl 发生数量, 0 发生进货金额, bqpfje 发生批发金额,bqlsje 发生零售金额,
	 kcsl 库存数量,0 库存进货金额,kcpfje 库存批发金额,kclsje 库存零售金额,
	 (jcsl+bqsl-kcsl) 数量差值,
	  0 进货金额差值,
	 (jcpfje+bqpfje-kcpfje) 批发金额差值,
	 CAST((jclsje+bqlsje-kclsje) AS DECIMAL(15,3)) 零售金额差值,dwbl ,deptid,
	 null 批次号,
	 null 批号,
	 null kcid 
	 from #temp where (jcsl+bqsl-kcsl)<>0 or( jcjhje+bqjhje-kcjhje)<>0  or (jclsje+bqlsje-kclsje)<>0  or (jcpfje+bqpfje-kcpfje)<>0  --where (jcsl+bqsl-kcsl)<>0 or (jcpfje+bqpfje-kcpfje)<>0 or (jclsje+bqlsje-kclsje)<>0
end 
else --进行批次管理
begin
	 select cjid,dbo.fun_getdeptname(deptid) 仓库名称,shh 货号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,ypdw 单位,
	 jcsl 上期数量, jcjhje 上期进货金额, jcpfje 上期批发金额,jclsje 上期零售金额,
	 bqsl 发生数量, bqjhje 发生进货金额, bqpfje 发生批发金额,bqlsje 发生零售金额,
	 kcsl 库存数量,kcjhje 库存进货金额,kcpfje 库存批发金额,kclsje 库存零售金额,
	 (jcsl+bqsl-kcsl) 数量差值,
	 (jcjhje+bqjhje-kcjhje) 进货金额差值,
	 (jcpfje+bqpfje-kcpfje) 批发金额差值,
	 CAST((jclsje+bqlsje-kclsje) AS DECIMAL(15,3)) 零售金额差值,dwbl ,deptid,
	 yppch 批次号,
	 ypph 批号,
	  kcid 
	  from #temp where (jcsl+bqsl-kcsl)<>0 or( jcjhje+bqjhje-kcjhje)<>0  or (jclsje+bqlsje-kclsje)<>0  or (jcpfje+bqpfje-kcpfje)<>0  --where (jcsl+bqsl-kcsl)<>0 or (jcpfje+bqpfje-kcpfje)<>0 or (jclsje+bqlsje-kclsje)<>0
	  
	--select * from #DJMX 
	--select * from YK_YMJC where deptid=@tx_deptid and cjid=@t1_cjid and nf=@year and yf=@month
	
	--select * from #temp 
end

end
 
 
 

