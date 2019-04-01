if exists (select * from sysobjects 
           where name = N'SP_YF_TJ_SfFyCftj'
           and type = 'P')
   drop proc SP_YF_TJ_SfFyCftj 
go
create PROCEDURE SP_YF_TJ_SfFyCftj  
 ( @RQ1 VARCHAR(30),   
   @RQ2 VARCHAR(30),  
   @yplx int, 
   @ksGroup int --0 不按科室分组，1 按可分组 jianqg 20013-4-24
 )  
  
----SP_YF_TJ_SfFyCftj '2009-09-26 00:00:00','2011-09-26 23:59:59',0  
  
as   
-- 对比门诊每天收费发药处方的张数和金额 

--declare @RQ1 VARCHAR(30)  
--declare @RQ2 VARCHAR(30)
--declare @yplx int 

--select @rq1=N'2013/4/23 00:00:00',@rq2=N'2013/4/23 23:59:59',@yplx=13
 
declare @ss varchar(8000)  
  
  create TABLE #sf  
   (  
      ID INTEGER not null IDENTITY (1,1),  
   sfrq varchar(20),  
   cflx char(2),  
   sfzs bigint,  
      sfje decimal(15,1),  
   tfzs bigint,  
      tfje decimal(15,1),  
   brfyzs bigint,  
   brfyje decimal(15,1),  
   wrfyzs bigint,  
   wrfyje decimal(15,1),  
   wfyzs bigint,  
   wfyje decimal(15,1) , 
   ksdm int
   )   
  
  
insert into #sf(sfrq,sfzs,sfje,brfyzs,brfyje,wrfyzs,wrfyje,wfyzs,wfyje,ksdm)   
select sfrq,  
sum(1) sfzs,  
sum(je) sfje,  
sum(case when sfrq=fyrq then 1 else 0 end) brfyzs,  
sum(case when sfrq=fyrq then je else 0 end) brfyje,  
0 wrfyzs,  
0 wrfyje,  
sum(case when  bfybz=0 then 1 else 0 end) wfyzs,  
sum(case when  bfybz=0 then je else 0 end) wfyje 
,ksdm 
from   
(  
select hjid,bfybz,convert(nvarchar,a.sfrq,23) sfrq,convert(nvarchar,a.fyrq,23)  fyrq,sum(zje) je,ksdm from  
vi_mz_cfb a  (nolock)  
where  a.sfrq>=@rq1 and a.sfrq<=@rq2 and ((zxks=@yplx  and @yplx<>0)  or ( @yplx=0)) and xmly=1  
group by hjid,bfybz,convert(nvarchar,a.sfrq,23),convert(nvarchar,a.fyrq,23),ksdm   
) aa  
group by  sfrq,ksdm  
  
  
  
insert into #sf(sfrq,sfzs,sfje,brfyzs,brfyje,wrfyzs,wrfyje,wfyzs,wfyje,ksdm)   
select sfrq,  
0 sfzs,  
0 sfje,  
0 brfyzs,  
0 brfyje,  
sum(case when sfrq<>fyrq then 1 else 0 end) wrfyzs,  
sum(case when sfrq<>fyrq then je else 0 end) wrfyje,  
0 wfyzs,  
0 wfyje
,ksdm  
from   
(  
select hjid,bfybz,convert(nvarchar,a.sfrq,23) sfrq,convert(nvarchar,a.fyrq,23)  fyrq,sum(zje) je,ksdm from  
vi_mz_cfb a  (nolock)  
where  a.fyrq>=@rq1 and a.fyrq<=@rq2 and ((zxks=@yplx  and @yplx<>0)  or ( @yplx=0)) and xmly=1  
and convert(nvarchar,fyrq,23)<>convert(nvarchar,sfrq,23)  
group by hjid,bfybz,convert(nvarchar,a.sfrq,23),convert(nvarchar,a.fyrq,23),ksdm   
) aa  
group by  sfrq,ksdm  
  
if (@ksGroup=0)

	select coalesce(sfrq,'合计') 日期,sum(sfzs) 收费张数,sum(sfje) 收费金额,sum(brfyzs) 本日发药张数,sum(brfyje) 本日发药金额,sum(wrfyzs) 往日发药张数,sum(wrfyje) 往日发药金额,sum(wfyzs) 未发药张数,sum(wfyje) 未发药金额   
	from #sf 
	where cast(sfrq as datetime)>=@RQ1 and cast(sfrq as datetime)<=@RQ2
	group by sfrq WITH ROLLUP  
else
	select coalesce(dbo.fun_getDeptname(ksdm),'合计') 科室,
	sum(brfyzs) 本日发药张数,sum(brfyje) 本日发药金额 
	from #sf 
	where cast(sfrq as datetime)>=@RQ1 and cast(sfrq as datetime)<=@RQ2
	group by ksdm WITH ROLLUP  
drop table #sf