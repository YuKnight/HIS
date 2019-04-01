IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_tj_jxcqkb' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_tj_jxcqkb
GO

CREATE PROCEDURE SP_YK_tj_jxcqkb
 (@year int, 
  @month INTEGER,
  @deptid integer,
  @yplx integer,
  @deptid_ck int
 ) 
as


 declare @id int 
 declare @yjid UNIQUEIDENTIFIER 
 declare @count INT 
 declare @sqyear int
 declare @sqmonth int

 --声明临时表
   create TABLE #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
	  wldw int,
   	  xmmc varchar(200),
	  je decimal(18,2),
	  ywlx char(3),
	  sortid int default 0 not null,
	  jdfx int default 0 not null,
	  jhje decimal(18,2) --default 0 not null
	  
   ) 
   
   create  TABLE #TEMP1
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  xmmc varchar(200),
	  je decimal(18,2),
	  jhje decimal(18,2), --default 0 not null,
	  xmmc1 varchar(200),
	  je1 decimal(18,2),
	  jhje1 decimal(18,2), --default 0 not null
	  bdel smallint default 0 not null
   ) 
   
   
  create  TABLE #DJMX
   (
   	  CJID INT,
	  zy varchar(200),
	  wldw int,
	  shrq varchar(50),
	  RCKFS INT,
	  YWLX CHAR(3),
	  YPSL DECIMAL(18,3),
	  ypdw varchar(10),
	  lsje DECIMAL(18,3),
	  lsj decimal(18,4),
	  jhje decimal(18,3)
	  
   ) 
   --保存月结ID
   create TABLE #YJB(YJID UNIQUEIDENTIFIER )

	create table #deptid(deptid int)
	--需要统计的科室
	if (@deptid_ck>0)
	  insert #deptid(deptid)values(@deptid_ck)
	else 
	  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID


     
    set @sqyear=@year;
	set @sqmonth=@month-1;
	if @month=1 
        begin
	    set @sqyear=@sqyear-1;
	    set @sqmonth=12;
	end 

	--如果是查询年报表	
	if @month=0 
	begin
		set @sqyear=@year-1;
		set @sqmonth=12
	end 


--如果是查询年报表	
	if @month=0 
    begin
		insert into #yjb select id from yp_kjqj where kjnf=@year  and deptid in(select deptid from #deptid)
		if year(getdate())=@year insert into #yjb select dbo.FUN_GETEMPTYGUID()
    end
	else
	begin
		insert into #yjb select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid in(select deptid from #deptid)
		if @@rowcount=0 insert into #yjb select dbo.FUN_GETEMPTYGUID()
    end

--查询明细情况
if @yplx=0 
begin
    insert into #DJMX(wldw,ywlx,lsje,jhje) 
    select a.wldw,a.ywlx,sum(lsje),sum(jhje)
    from vi_yk_dj a(nolock),vi_yk_djmx b(nolock) 
    where a.id=b.djid and isnull(yjid,dbo.FUN_GETEMPTYGUID()) IN(SELECT YJID FROM #YJB)  and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002')))  
	and a.deptid in(select deptid from #deptid)
    group by a.wldw,a.ywlx
end
else
begin
    insert into #DJMX(wldw,ywlx,lsje,jhje) 
    select a.wldw,a.ywlx,sum(lsje),sum(jhje)
    from vi_yk_dj a(nolock),vi_yk_djmx b(nolock),yp_ypcjd c (nolock)
    where a.id=b.djid and b.cjid=c.cjid and c.n_yplx=@yplx and isnull(yjid,dbo.FUN_GETEMPTYGUID()) IN(SELECT YJID FROM #YJB)  and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002')))  
	and a.deptid in(select deptid from #deptid)
    group by a.wldw,a.ywlx
end
	
 
	
--上期结存
set @count=(select count(*) from Yp_kjqj where  kjnf=@sqyear and kjyf=@sqmonth and  deptid in(select deptid from #deptid) );
if coalesce(@count,0)=0 
	insert into #TEMP(xmmc,je,ywlx,sortid,jdfx,jhje)values('上期结存',0,'000',0,0,0);
else
begin
	if @yplx=0 
	   	insert into #TEMP(xmmc,je,ywlx,sortid,jdfx,jhje) select '上期结存',sum(jclsje),'000',0,0,sum(jcjhje) from YK_YMJC where  nf=@sqyear and yf=@sqmonth  and deptid in(select deptid from #deptid)
	else
	    insert into #TEMP(xmmc,je,ywlx,sortid,jdfx,jhje) select '上期结存',sum(jclsje),'000',0,0,sum(jcjhje) from YK_YMJC a,vi_yp_ypcd b where a.cjid=b.cjid and b.yplx=@yplx and nf=@sqyear and yf=@sqmonth and deptid in(select deptid from #deptid)
end

insert into #TEMP(wldw,xmmc,je,jhje,ywlx) select 0, ywmc,0,0,ywlx from yk_ywlx where ywzt=1;

declare @t_wldw int
declare @t_ywlx char(3)
declare @t_je decimal(15,3)
declare @t_jhje decimal(15,3)
declare t cursor local for
     select wldw,ywlx,round(sum(lsje),2) je,round(sum(jhje),2) jhje from #DJMX where ywlx<>'008' group by wldw,ywlx
open  t
fetch next from t into @t_wldw,@t_ywlx,@t_je,@t_jhje
while @@FETCH_STATUS=0
begin
   if @t_ywlx='001' or @t_ywlx='002' or  @t_ywlx='005' or @t_ywlx='006' or
	 @t_ywlx='007' or @t_ywlx='008' or @t_ywlx='012' or @t_ywlx='009' or @t_ywlx='017' or @t_ywlx='018' -- or @t_ywlx='014'
   begin
       update #TEMP set je=je+@t_je,jhje=jhje+@t_jhje where ywlx=@t_ywlx;
   end
   else
     begin
        insert into #TEMP(wldw,xmmc,je,ywlx,jhje)values(@t_wldw,dbo.fun_yk_ywlx(@t_ywlx),@t_je,@t_ywlx,@t_jhje);
     end
fetch next from t into @t_wldw,@t_ywlx,@t_je,@t_jhje
end

--如果是查询年报表	
if @month=0
begin
  --if year(getdate())=@year
   --  set @month=month(getdate())
  --else
     set @month=12
end 

  --本期结存
set @count=0;
set @count=(select count(*) from Yp_kjqj where kjnf=@year and kjyf=@month and deptid in(select deptid from #deptid) );
if @count is null 
set @count=0;


if @count=0 
begin
  
    if @yplx=0 
		insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '本期结存',cast(sum(round(kcl*lsj/dwbl,2)) as decimal(15,2)),cast(sum(round(kcl*jhj/dwbl,2)) as decimal(15,2)),'999',1000,1  from yk_kcph a,yp_ypcjd b 
		where a.cjid=b.cjid  and a.deptid in(select deptid from #deptid)
    else
		insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '本期结存',cast(sum(round(kcl*lsj/dwbl,2)) as decimal(15,2)),cast(sum(round(kcl*jhj/dwbl,2)) as decimal(15,2)),'999',1000,1  from yk_kcph a,yp_ypcjd b 
		where a.cjid=b.cjid  and b.n_yplx=@yplx and a.deptid in(select deptid from #deptid)
    
end
else
begin
    if @yplx=0 
	   	insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '本期结存',sum(jclsje),sum(jcjhje),'999',1000,1 from YK_YMJC 
		where nf=@year and yf=@month  and deptid in(select deptid from #deptid)
    else
	   	insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '本期结存',sum(jclsje),sum(jcjhje),'999',1000,1 from YK_YMJC a,vi_yp_ypcd b 
		where a.cjid=b.cjid and b.yplx=@yplx and nf=@year and yf=@month and deptid in(select deptid from #deptid)
end 


update #TEMP set xmmc='期初录入',je=je,sortid=1,jdfx=0 where ywlx='009';
update #TEMP set xmmc='药品采购',je=je,jhje=jhje,sortid=2,jdfx=0 where ywlx='001';
update #TEMP set xmmc='药品退货',je=je*(-1),jhje=jhje*(-1),sortid=3,jdfx=0 where ywlx='002';
update #TEMP set xmmc=dbo.fun_getdeptname(wldw)+'退库',je=je,sortid=4,jdfx=0 where ywlx='004';
update #TEMP set xmmc=dbo.fun_yp_ghdw(wldw)+'入库',je=je,sortid=5,jdfx=0 where ywlx='016';
update a set xmmc=b.ywjc,je=je,sortid=6,jdfx=0 from  #TEMP a inner join YK_YWLX b on a.ywlx=b.YWLX where a.ywlx='007';
update #TEMP set xmmc='调价升溢',je=je,sortid=7,jdfx=0 where ywlx='005' and je>0;
update #TEMP set xmmc='账务调整增加',je=je,sortid=8,jdfx=0 where ywlx='012' and je>0;
insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '药品盘盈',sum(lsje) je,sum(jhje),'008',9,0 from #DJMX where ywlx='008' and lsje>0;
update #TEMP set xmmc=dbo.fun_getdeptname(wldw)+'调入',je=je,sortid=10,jdfx=0 where ywlx='031';
update #TEMP set xmmc='制剂加工成品入库',je=ABS(je),sortid=28,jdfx=0 where ywlx='033' --ncq 20140210

update #TEMP set xmmc=dbo.fun_getdeptname(wldw)+'出库',je=je,sortid=20,jdfx=1 where ywlx='003';
update #TEMP set xmmc=isnull(dbo.fun_getdeptname(wldw)+'领药',dbo.fun_yf_ywlx(ywlx)),je=je,sortid=21,jdfx=1 where ywlx='014';
update #TEMP set xmmc=dbo.fun_getdeptname(wldw)+'外用药领药',je=je,sortid=21,jdfx=1 where ywlx='022';
update #TEMP set xmmc='处方出库',je=je,sortid=21,jdfx=1 where ywlx='017';
update #TEMP set xmmc='处方补录出库',je=je,sortid=22,jdfx=1 where ywlx='020';
update #TEMP set xmmc='门诊记帐处方补录出库',je=je,sortid=24,jdfx=1 where ywlx='018';
update #TEMP set xmmc='药品报损',je=je,sortid=25,jdfx=1 where ywlx='006';
update a set   xmmc=b.ywjc,je=je,sortid=25,jdfx=1 from #TEMP a inner join YK_YWLX b on a.ywlx=b.ywlx where a.ywlx='006';
update #TEMP set xmmc='调价损失',je=abs(je),sortid=26,jdfx=1 where ywlx='005' and je<0;
update #TEMP set xmmc='账务调整减少',je=abs(je),sortid=27,jdfx=1 where ywlx='012' and je<0;

update #TEMP set xmmc='原料消耗出库',je=ABS(je),sortid=28,jdfx=1 where ywlx='032' ----ncq 20140210

insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '药品盘亏',abs(sum(lsje)) je,abs(sum(jhje)),'008',28,1 from #DJMX where ywlx='008' and lsje<0;
update #TEMP set xmmc=dbo.fun_getdeptname(wldw)+'调出',je=je,sortid=29,jdfx=1 where ywlx='030';
--插入借方数据 
insert into #TEMP1(xmmc,je,jhje) select xmmc,je,coalesce(jhje,0) from #TEMP where (je<>0 and jdfx=0)  or ywlx='000' or  (je=0 and jhje<>0) order by sortid


declare @i int
set @i=0    
while(@i<=80)
begin
set @i=@i+1
insert into #temp1(xmmc,je,xmmc1,je1)values('',0,'',0);    
end

insert into #TEMP1(xmmc,je,jhje,xmmc1,je1,jhje1) 
select '借方小计',sum(je),sum(jhje),'',0,0 from #TEMP where jdfx=0 and ywlx<>'000'


--插入贷方数据
declare @t2_xmmc varchar(200)
declare @t2_je decimal(18,2)
declare @t2_jhje decimal(18,2)
set @id=1;
declare t2 cursor for select xmmc,je,coalesce(jhje,0) from #TEMP where (je<>0 and jdfx=1) or ywlx='999' or (je=0 and jhje<>0) order by sortid
open t2
fetch next from t2 into @t2_xmmc,@t2_je,@t2_jhje
while @@FETCH_STATUS=0
begin
      set @id=@id+1;
      update #TEMP1 set xmmc1=@t2_xmmc,je1=@t2_je,jhje1=@t2_jhje where id=@id;
      if @t2_xmmc<>'本期结存'
	update #TEMP1 set xmmc1='贷方小计',je1=je1+@t2_je,jhje1=jhje1+@t2_jhje where xmmc='借方小计';
      fetch next from t2 into @t2_xmmc,@t2_je,@t2_jhje
end 
CLOSE t2
DEALLOCATE t2



--求借方的合计数
insert into #TEMP1(xmmc,je,jhje)select '合计',coalesce(sum(je),0),coalesce(sum(jhje),0) from #TEMP1 where xmmc<>'借方小计';

--求贷方的合计数，并更新
declare @je1 decimal(18,2)
declare @jhje1 decimal(18,2)
select @je1=sum(coalesce(je1,0)),@jhje1=sum(coalesce(jhje1,0)) from #TEMP1 where xmmc1<>'贷方小计'

update #TEMP1 set xmmc1='合计',je1=coalesce(@je1,0),jhje1=coalesce(@jhje1,0) where xmmc='合计';

--select (case when (xmmc='药品采购' or xmmc='药品退货') then rtrim(xmmc)+'(进销差额:'+rtrim(coalesce(je,0)-coalesce(jhje,0))+')' else xmmc end ) 项目1,(case when xmmc='' then null else coalesce(je,0) end) 金额1,xmmc1 项目2,(case when xmmc1 is null then null else coalesce(je1,0) end) 金额2 from #TEMP1 where xmmc<>'' or (xmmc='' and xmmc1<>'') order by id
select  
xmmc 项目1,
jhje 进货金额1,
(case when xmmc='' then null else coalesce(je,0) end) 零售金额1,
(case when xmmc='' then null else (coalesce(je,0)-coalesce(jhje,0)) end) 进零差额1,
xmmc1 项目2,
jhje1 进货金额2,
(case when xmmc1 is null then null else coalesce(je1,0) end) 零售金额2, 
(case when xmmc1 is null then null else (coalesce(je1,0)-coalesce(jhje1,0)) end) 进零差额2
from #TEMP1 where xmmc<>'' or (xmmc='' and xmmc1<>'') order by id




GO



