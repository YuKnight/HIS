--2014-03-15 ncq 添加批次管理 月末结存
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_ymjc' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_ymjc
GO
CREATE PROCEDURE sp_YF_ymjc 
(
	@year INTEGER ,
	@month integer,
	@deptid integer,
	@ksrq varchar(30),
	@jsrq varchar(30),
	@DJSJ VARCHAR(30),
	@DJY INTEGER,
	@Err_Code INTEGER output ,
    @Err_Text VARCHAR(100)output
)
as

begin
 declare @yjid UNIQUEIDENTIFIER 

 set @yjid=dbo.FUN_GETEMPTYGUID();
 set @Err_Code=-1;
 set @Err_Text='';
 
declare @bpcgl int =0; --库房是否进行批次管理  
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--暂时设定为999

if EXISTS(select * from yp_kjqj where deptid=@deptid)
begin
	declare @nday int
	set @nday=DATEDIFF(DAY, cast(@ksrq as datetime), getdate()) 
	if @nday<=15 
	begin
	  set @err_text='上次月结日期为'+@ksrq+',您不能过于频繁的进行月结操作'
	  return;
	end 
end
set @yjid=dbo.FUN_GETGUID(newid(),getdate())


if (@bpcgl =0 or @bpcgl is null ) --不进行批次管理
begin
	--插入操作记录
	insert into yp_kjqj(id,kjnf,kjyf,ksrq,jsrq,djsj,djy,deptid) 
	values(@yjid,@year,@month,@ksrq,@jsrq,@djsj,@djy,@deptid);
	--set @yjid=@@IDENTITY;
	if @@rowcount=0
		begin
		   SET @Err_Text='月结记录没有插入成功,零行';
		   set @yjid=dbo.FUN_GETEMPTYGUID()
	   return;
	end

	if @yjid=dbo.FUN_GETEMPTYGUID()
	begin
	   SET @Err_Text='月结ID为零，月结失败';
	   return;
	end 

		--实时结帐法
	/*
		update YF_dj set yjid=@yjid where  deptid=@deptid and (yjid<=0 or yjid is null) and (shbz=1 or (shbz=0 and (ywlx='001' or ywlx='002')))  ;
		update yf_fy set yjid=@yjid where deptid=@deptid and (yjid<=0 or yjid is null); 
		update yf_tld set yjid=@yjid where deptid=@deptid and (yjid<=0 or yjid is null);
		
		insert into YF_YMJC(nf,yf,cjid,ypdw,ydwbl,pfj,lsj,jcsl,jcpfje,jclsje,jcjhje,djsj,deptid,yjid)
		select @year,@month,a.cjid,dbo.fun_yp_ypdw(a.zxdw) ypdw,a.dwbl,round(b.pfj/a.dwbl,4) pfj,round(b.lsj/a.dwbl,4) lsj,
		kcl jcsl,round(pfj*kcl/dwbl,2) jcpfje,round(lsj*kcl/dwbl,2) jclsje,
		(select round(sum(jhj*kcl/dwbl),2) from yf_kcph where cjid=b.cjid and deptid=@deptid),
		@djsj,@deptid,@yjid
		 from YF_kcmx a,vi_yp_ypcd b where a.cjid=b.cjid and deptid=@deptid;

		
		insert into yf_dj_h select * from yf_dj where yjid=@yjid and deptid=@deptid;
		insert into yf_djmx_h select b.* from yf_dj a,yf_djmx b where a.id=b.djid and a.yjid=@yjid and a.deptid=@deptid;

		delete from yf_djmx where djid in(select id from yf_dj where yjid=@yjid and deptid=@deptid);
		delete from yf_dj where yjid=@yjid AND DEPTID=@DEPTID;
	*/
	   --时间段结帐法

	--上期会计年份和月份
	declare @sqyear int;
	declare @sqmonth int;
	set @sqyear=@year;
	set @sqmonth=@month-1;
	if @month=1 
	begin
	  set @sqyear=@sqyear-1;
	  set @sqmonth=12;
	end 

	--更新本次月结记录
	update YF_dj set yjid=@yjid where  deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null) and 
	( (shbz=1 and ywlx not in('001','002') and shrq<=@jsrq ) or 
		(ywlx in('002','001') and djrq<=@jsrq  and djrq+convert(nvarchar,djsj,108)<=@jsrq   )
		)    ;
	update yf_fy set yjid=@yjid where deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)
	and djid in(select id from yf_dj where yjid=@yjid); 

	update yf_tld set yjid=@yjid where deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)
	and djid in(select id from yf_dj where yjid=@yjid); ;



	--上期结存数
	create table #qc(cjid int,sqsl decimal(15,3),sqpfje decimal(15,3),sqlsje decimal(15,3),sqjhje decimal(15,3))
	insert into #qc(cjid,sqsl,sqpfje,sqlsje,sqjhje) 
	select a.cjid,(jcsl*dwbl/ydwbl) jcsl,jcpfje,jclsje,jcjhje
	from YF_YMJC  a (nolock),yf_kcmx b  where a.cjid=b.cjid and  a.deptid=b.deptid and 
	nf=@sqyear and yf=@sqmonth and a.deptid=@deptid;

	--本期发生数
	create table #bq(cjid int,bqsl decimal(15,3),bqpfje decimal(15,3),bqlsje decimal(15,3),bqjhje decimal(15,3))
	INSERT INTO #bq(CJID,bqsl,bqpfje,bqlsje,bqjhje)
		SELECT c.cjid,
		sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
		sum(dbo.fun_YF_drt(a.ywlx,pfje)),
		round(sum(dbo.fun_YF_drt(a.ywlx,lsje)),2),
		sum(dbo.fun_YF_drt(a.ywlx,jhje))
		FROM YF_DJ A (nolock),YF_DJMX B (nolock),YF_kcmx c (nolock)
		WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and  yjid=@yjid and A.DEPTID=@DEPTID 
		group by c.cjid	

	insert into #qc (cjid,sqsl,sqpfje,sqlsje,sqjhje)
	select cjid,0,0,0,0 from  #bq where cjid not in(select cjid from #qc)


	--计算结存数
	create table #jc(cjid int,jcsl decimal(15,3),jcpfje decimal(15,2),jclsje decimal(15,2),jcjhje decimal(15,2))
	insert into #jc (cjid,jcsl,jcpfje,jclsje,jcjhje)
	select a.cjid,(sqsl+coalesce(bqsl,0)),round(sqpfje+coalesce(bqpfje,0),2),
	round(sqlsje+coalesce(bqlsje,0),2),round(sqjhje+coalesce(bqjhje,0),2)
	 from #qc a left join #bq b on a.cjid=b.cjid  

	--插入结存表
	insert into YF_YMJC(id,nf,yf,cjid,ypdw,ydwbl,pfj,lsj,jcsl,jcpfje,jclsje,jcjhje,djsj,deptid,yjid)
	select dbo.FUN_GETGUID(newid(),getdate()),@year,@month,a.cjid,dbo.fun_yp_ypdw(b.zxdw) ypdw,b.dwbl,round(b.pfj/b.dwbl,4) pfj,round(b.lsj/b.dwbl,4) lsj,
	jcsl,jcpfje,jclsje,
	jcjhje,
	@djsj,@deptid,@yjid
	 from #jc a,vi_yf_kcmx b where a.cjid=b.cjid and deptid=@deptid;
		set @Err_Code=0;
		set @Err_Text='月结成功';
end

else
begin   --进行批次管理
	--插入操作记录
	insert into yp_kjqj(id,kjnf,kjyf,ksrq,jsrq,djsj,djy,deptid) 
	values(@yjid,@year,@month,@ksrq,@jsrq,@djsj,@djy,@deptid);
	--set @yjid=@@IDENTITY;
	if @@rowcount=0
		begin
		   SET @Err_Text='月结记录没有插入成功,零行';
		   set @yjid=dbo.FUN_GETEMPTYGUID()
	   return;
	end

	if @yjid=dbo.FUN_GETEMPTYGUID()
	begin
	   SET @Err_Text='月结ID为零，月结失败';
	   return;
	end 

		--实时结帐法
	/*
		update YF_dj set yjid=@yjid where  deptid=@deptid and (yjid<=0 or yjid is null) and (shbz=1 or (shbz=0 and (ywlx='001' or ywlx='002')))  ;
		update yf_fy set yjid=@yjid where deptid=@deptid and (yjid<=0 or yjid is null); 
		update yf_tld set yjid=@yjid where deptid=@deptid and (yjid<=0 or yjid is null);
		
		insert into YF_YMJC(nf,yf,cjid,ypdw,ydwbl,pfj,lsj,jcsl,jcpfje,jclsje,jcjhje,djsj,deptid,yjid)
		select @year,@month,a.cjid,dbo.fun_yp_ypdw(a.zxdw) ypdw,a.dwbl,round(b.pfj/a.dwbl,4) pfj,round(b.lsj/a.dwbl,4) lsj,
		kcl jcsl,round(pfj*kcl/dwbl,2) jcpfje,round(lsj*kcl/dwbl,2) jclsje,
		(select round(sum(jhj*kcl/dwbl),2) from yf_kcph where cjid=b.cjid and deptid=@deptid),
		@djsj,@deptid,@yjid
		 from YF_kcmx a,vi_yp_ypcd b where a.cjid=b.cjid and deptid=@deptid;

		
		insert into yf_dj_h select * from yf_dj where yjid=@yjid and deptid=@deptid;
		insert into yf_djmx_h select b.* from yf_dj a,yf_djmx b where a.id=b.djid and a.yjid=@yjid and a.deptid=@deptid;

		delete from yf_djmx where djid in(select id from yf_dj where yjid=@yjid and deptid=@deptid);
		delete from yf_dj where yjid=@yjid AND DEPTID=@DEPTID;
	*/
	   --时间段结帐法

	--上期会计年份和月份
	declare @sqyear_pc int;
	declare @sqmonth_pc int;
	set @sqyear_pc=@year;
	set @sqmonth_pc=@month-1;
	if @month=1 
	begin
	  set @sqyear_pc=@sqyear-1;
	  set @sqmonth_pc=12;
	end 

	--更新本次月结记录
	update YF_dj set yjid=@yjid where  deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null) and 
	( (shbz=1 and ywlx not in('001','002') and shrq<=@jsrq ) or 
		(ywlx in('002','001') and djrq<=@jsrq  and djrq+convert(nvarchar,djsj,108)<=@jsrq   )
		)    ;
	update yf_fy set yjid=@yjid where deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)
	and djid in(select id from yf_dj where yjid=@yjid); 

	update yf_tld set yjid=@yjid where deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)
	and djid in(select id from yf_dj where yjid=@yjid); 



	--上期结存数
	create table #qc_pc(cjid int,sqsl decimal(15,3),sqpfje decimal(15,3),sqlsje decimal(15,3),sqjhje decimal(15,3)
	,kcid uniqueidentifier)  --kcid 
	insert into #qc_pc(cjid,sqsl,sqpfje,sqlsje,sqjhje,kcid) 
	select a.cjid,(jcsl*dwbl/ydwbl) jcsl,jcpfje,jclsje,jcjhje
	,b.id  
	from YF_YMJC  a (nolock),YF_KCPH b  where a.cjid=b.cjid and  a.deptid=b.deptid and 
	nf=@sqyear_pc and yf=@sqmonth_pc and a.deptid=@deptid 
	and a.kcid=b.id ; 

	--本期发生数
	create table #bq_pc(cjid int,bqsl decimal(15,3),bqpfje decimal(15,3),bqlsje decimal(15,3),bqjhje decimal(15,3)
	,kcid uniqueidentifier) --kcid
	INSERT INTO #bq_pc(CJID,bqsl,bqpfje,bqlsje,bqjhje
	,kcid)
		SELECT c.cjid,
		sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
		sum(dbo.fun_YF_drt(a.ywlx,pfje)),
		round(sum(dbo.fun_YF_drt(a.ywlx,lsje)),2),
		sum(dbo.fun_YF_drt(a.ywlx,jhje))
		,c.ID 
		FROM YF_DJ A (nolock),YF_DJMX B (nolock),YF_KCPH c (nolock)
		WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and  yjid=@yjid and A.DEPTID=@DEPTID 
		and b.kcid=c.ID 
		group by c.cjid,c.id 

	insert into #qc_pc (cjid,sqsl,sqpfje,sqlsje,sqjhje,kcid )
	select cjid,0,0,0,0,kcid from  #bq_pc where kcid not in(select kcid from #qc_pc)


	--计算结存数
	create table #jc_pc(cjid int,jcsl decimal(15,3),jcpfje decimal(15,2),jclsje decimal(15,2),jcjhje decimal(15,2)
	,kcid uniqueidentifier )
	insert into #jc_pc (cjid,jcsl,jcpfje,jclsje,jcjhje
	,kcid )
	select a.cjid,(sqsl+coalesce(bqsl,0)),round(sqpfje+coalesce(bqpfje,0),2),
	round(sqlsje+coalesce(bqlsje,0),2),round(sqjhje+coalesce(bqjhje,0),2)
	,a.kcid 
	 from #qc_pc a left join #bq_pc b on a.cjid=b.cjid and a.kcid=b.kcid 

	--插入结存表
	insert into YF_YMJC(id,nf,yf,cjid,ypdw,ydwbl,pfj,lsj,jcsl,jcpfje,jclsje,jcjhje,djsj,deptid,yjid,jhj,kcid )
	select dbo.FUN_GETGUID(newid(),getdate()),@year,@month,a.cjid,dbo.fun_yp_ypdw(b.zxdw) ypdw,b.dwbl,round(b.pfj/b.dwbl,4) pfj,round(b.lsj/b.dwbl,4) lsj,
	jcsl,jcpfje,jclsje,
	jcjhje,
	@djsj,@deptid,@yjid ,round(b.jhj/b.dwbl,4),a.kcid 
	 from #jc_pc a,vi_yf_kcph b where a.cjid=b.cjid and deptid=@deptid
	 and a.kcid=b.kcid  
		set @Err_Code=0;
		set @Err_Text='月结成功';
end



end 