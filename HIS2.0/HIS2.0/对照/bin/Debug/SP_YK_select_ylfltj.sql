IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_select_ylfltj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_select_ylfltj
GO
CREATE PROCEDURE SP_YK_select_ylfltj
 (
    @deptid integer,
    @dtp1 datetime,
    @dtp2 datetime,
    @fid bigint,--统计的节点
    @functionname varchar(100), --采购入库分类统计 1 出库单分类统计
	@deptid_ck int
 ) 
as

--exec SP_YK_select_ylfltj 1148,'2006-01-01','2008-01-01',1,'Fun_ts_yk_tjbb_ylfltj_rk'
--select * from dbo.fun_tlfl_child(1)


begin

create table #deptid(deptid int)
--需要统计的科室
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID

declare @ss varchar(4000)
declare @sumje decimal(15,2)   --整个统计其间的金额
declare @sumflje decimal(15,2)--药理分类总金额

set @sumje=0
--统计分类包含的药品
select b.ylfl,b.cjid,b.s_ypspm,b.s_yppm,b.s_ypgg,s_ypdw,b.s_sccj,b.lsj,s_ypjx into #ypcd from dbo.fun_tlfl_child(@fid) a,vi_yp_ypcd b where a.id=b.ylfl

create table #temp(cjid int,ypsl decimal(15,2) ,lsje decimal(15,2)) 

if @functionname='Fun_ts_yk_tjbb_ylfltj_rk'
begin

	set @sumje=(select sum(lsje) from vi_yk_dj a,vi_yk_djmx b where djrq>=@dtp1 and djrq<=@dtp2 and
	a.id=b.djid and a.ywlx in('001','002') and a.deptid in(select deptid from #deptid)  ) --总金额

      

	insert into #temp(cjid,ypsl,lsje)
	select b.cjid,sum(ypsl/ydwbl) ypsl,sum(lsje) lsje  from vi_yk_dj a,vi_yk_djmx b,#ypcd c where djrq>=@dtp1 and djrq<=@dtp2 and
	a.id=b.djid and b.cjid=c.cjid and a.ywlx in('001','002') and a.deptid in(select deptid from #deptid)
	group by b.cjid--单个药品数量、金额

end 

if @functionname='Fun_ts_yk_tjbb_ylfltj_ck'
begin

	set @sumje=(select sum(lsje) from vi_yk_dj a,vi_yk_djmx b where djrq>=@dtp1 and djrq<=@dtp2 and
	a.id=b.djid and a.ywlx in('003','004') and a.deptid in(select deptid from #deptid) ) --总金额

	insert into #temp(cjid,ypsl,lsje)
	select b.cjid,sum(ypsl/ydwbl) ypsl,sum(lsje) lsje  from vi_yk_dj a,vi_yk_djmx b,#ypcd c where djrq>=@dtp1 and djrq<=@dtp2 and
	a.id=b.djid and b.cjid=c.cjid and a.ywlx in('003','004') and a.deptid in(select deptid from #deptid) and shbz=1
	group by b.cjid--单个药品数量、金额

end 

set @sumflje=(select sum(lsje) from #temp)

 --输出明细结果
select b.cjid,s_yppm 品名,s_ypgg 规格 ,s_sccj 厂家 ,b.lsj 零售价,cast(ypsl as float) 数量 ,s_ypdw 单位,cast(lsje as float) 金额,cast(cast(round(lsje/@sumflje,4)*100 as float) as varchar(100))+'%' 百分比,@sumje 总金额 from #temp a,#ypcd b where a.cjid=b.cjid 

--输出汇总结果  
 create table #ok(id bigint,name varchar(100),lsje decimal(15,2),bfbl varchar(100)) 

declare @lsje decimal(15,2)
declare @id bigint
declare @name varchar(100)
declare t1 cursor for select id,flmc from yp_ylfl where fid=@fid--select ylfl,sum(lsje) lsje from #temp a,#ypcd b where a.cjid=b.cjid group by ylfl  
open t1
fetch next from t1 into @id,@name
while @@FETCH_STATUS=0
begin
   
    set @lsje=(select sum(lsje) lsje from dbo.fun_tlfl_child(@id) a,#ypcd b,#temp c where a.id=b.ylfl and b.cjid=c.cjid)
    insert into #ok(id,name,lsje,bfbl)values(@id,@name,@lsje,0)

fetch next from t1 into @id,@name
end
CLOSE t1
DEALLOCATE t1

insert into #ok(name,lsje,bfbl) select '合计',sum(lsje),'100%' from #temp

select name 名称,lsje 金额,cast(cast(round(lsje/@sumflje,4)*100 as float) as varchar(100))+'%' 百分比,@sumje 总金额,id from #ok


if @functionname='Fun_ts_yk_tjbb_ylfltj_rk'
begin
	select (case a.ywlx when '001' then '入库' when '002' then '退货' else '' end) 类型 ,s_ypjx 剂型,s_yppm 品名,s_ypgg 规格 ,s_sccj 厂家 ,b.jhj 进价,cast(ypsl as float) 数量 ,s_ypdw 单位,cast(jhje as float) 进货金额,dbo.fun_yp_ghdw(wldw) 往来单位,a.djh 单据号 from vi_yk_dj a,vi_yk_djmx b,#ypcd c where djrq>=@dtp1 and djrq<=@dtp2 and
	a.id=b.djid and b.cjid=c.cjid and a.ywlx in('001','002') and a.deptid in(select deptid from #deptid)
	order by djrq,djsj
end
if @functionname='Fun_ts_yk_tjbb_ylfltj_ck'
begin
	select(case a.ywlx when '003' then '出库' when '004' then '退库' else '' end) 类型 ,s_ypjx 剂型,s_yppm 品名,s_ypgg 规格 ,s_sccj 厂家 ,b.lsj 零售价,cast(ypsl as float) 数量 ,s_ypdw 单位,cast(lsje as float) 零售金额,dbo.fun_getdeptname(wldw) 往来单位,a.djh 单据号  from vi_yk_dj a,vi_yk_djmx b,#ypcd c where djrq>=@dtp1 and djrq<=@dtp2 and
	a.id=b.djid and b.cjid=c.cjid and a.ywlx in('003','004') and a.deptid in(select deptid from #deptid) and shbz=1
	order by djrq,djsj
end

end


