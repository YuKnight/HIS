IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_JzFyCftj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_JzFyCftj
GO
CREATE PROCEDURE SP_YF_TJ_JzFyCftj
 ( @RQ1 VARCHAR(30), 
   @RQ2 VARCHAR(30),
   @yplx int
 )

--SP_YF_TJ_JzFyCftj '2008-01-01 00:00:00','2011-01-30 23:59:59',0

as 
-- 对比住院每天收费发药处方的张数和金额
declare @ss varchar(8000)
declare @cflx varchar(3)
set @cflx=''
if @yplx=1 set @cflx='01'
if @yplx=2 set @cflx='02'
if @yplx=3 set @cflx='03'

  create TABLE #sf
   (
      ID INTEGER not null IDENTITY (1,1),
	  sfrq varchar(20),
	  cflx char(2),
	  sfzs bigint,
   	  sfje decimal(15,2),
	  tfzs bigint,
   	  tfje decimal(15,2),
	  brfyzs bigint,
	  brfyje decimal(15,2),
	  wrfyzs bigint,
	  wrfyje decimal(15,2),
	  wfyzs bigint,
	  wfyje decimal(15,2)
   ) 
insert into #sf(sfrq,cflx,sfzs,sfje,tfzs,tfje,brfyzs,brfyje,wrfyzs,wrfyje,wfyzs,wfyje) 
select jzrq,'',
count(*) sfzs,sum(je)  sfje,0 tfzs,0 tfje,
sum(case when fy_bit=1  and convert(nvarchar,a.jzrq,112) =convert(nvarchar,fyrq,112) then 1 else 0 end ) brfyzs,
sum(case when fy_bit=1  and convert(nvarchar,a.jzrq,112) =convert(nvarchar,fyrq,112) then je else 0 end ) brfyje,
0,
0,
sum(case when fy_bit=0 then 1 else 0 end),
sum(case when fy_bit=0 then je else 0 end)
from 
(
select convert(nvarchar,a.charge_date,112)jzrq,convert(nvarchar,fy_date,112) fyrq,presc_no,sum(sdvalue) je,fy_bit
from zy_fee_speci a (nolock)
where  XMID>0 AND XMLY=1 and a.charge_date>=@rq1 and a.charge_date<=@rq2 and charge_bit=1 and delete_bit=0 and ((execdept_id=@yplx  and @yplx<>0)  or ( @yplx=0))
group by  convert(nvarchar,a.charge_date,112),convert(nvarchar,fy_date,112),presc_no,fy_bit,execdept_id
union all
select convert(nvarchar,a.charge_date,112) jzrq,convert(nvarchar,fy_date,112) fyrq,presc_no,sum(sdvalue) je,fy_bit
from zy_fee_speci_h a  (nolock)
where  XMID>0 AND XMLY=1  and a.charge_date>=@rq1 and a.charge_date<=@rq2 and charge_bit=1 and delete_bit=0   and ((execdept_id=@yplx  and @yplx<>0)  or ( @yplx=0))
group by  convert(nvarchar,a.charge_date,112),convert(nvarchar,fy_date,112),presc_no,fy_bit,execdept_id
) a group by jzrq


insert into #sf(sfrq,cflx,sfzs,sfje,tfzs,tfje,brfyzs,brfyje,wrfyzs,wrfyje,wfyzs,wfyje) 
select fyrq,'',
0 sfzs,0  sfje,0 tfzs,0 tfje,
0,
0,
count(*) wrfyzs,
sum(je) wrfyje,
0,
0
from 
(
select convert(nvarchar,fy_date,112) fyrq,presc_no,sum(sdvalue) je,fy_bit
from zy_fee_speci a  (nolock)
where  XMID>0 AND XMLY=1  and a.fy_date>=@rq1 and a.fy_date<=@rq2 and fy_bit=1 and delete_bit=0 and 
convert(nvarchar,fy_date,112)<>convert(nvarchar,charge_date,112)  and ((execdept_id=@yplx  and @yplx<>0)  or ( @yplx=0))
group by  convert(nvarchar,a.charge_date,112),convert(nvarchar,fy_date,112),presc_no,fy_bit,execdept_id
union all
select convert(nvarchar,fy_date,112) fyrq,presc_no,sum(sdvalue) je,fy_bit
from zy_fee_speci_h a  (nolock)
where  XMID>0 AND XMLY=1 AND a.fy_date>=@rq1 and a.fy_date<=@rq2 and fy_bit=1 and delete_bit=0 and 
convert(nvarchar,fy_date,112)<>convert(nvarchar,charge_date,112)  and ((execdept_id=@yplx  and @yplx<>0)  or ( @yplx=0))
group by  convert(nvarchar,fy_date,112),presc_no,fy_bit,execdept_id
) a group by fyrq



select coalesce(sfrq,'合计') 日期,sum(sfzs-tfzs) 收费张数,sum(sfje-tfje) 收费金额,sum(brfyzs) 本日发药张数,sum(brfyje) 本日发药金额,sum(wrfyzs) 往日发药张数,sum(wrfyje) 往日发药金额,sum(wfyzs) 未发药张数,sum(wfyje) 未发药金额 
from #sf group by sfrq WITH ROLLUP




