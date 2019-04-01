IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_yp_tj_ckmxtj]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yp_tj_ckmxtj]
GO
CREATE PROCEDURE [dbo].[sp_yp_tj_ckmxtj] 

(

	@deptid int,

	@yk int,

	@jhjetj int,

	@year int,

	@month int,

    @ERR_CODE INTEGER output,

    @ERR_TEXT VARCHAR(250) output

)

as



/*

declare @err_code int

declare @err_text varchar(300)

exec sp_yp_tj_ckmxtj @deptid=94,@yk=1,@jhjetj=1,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output

select @err_code,@err_text





declare @err_code int

declare @err_text varchar(300)

exec sp_yp_tj_ckmxtj @deptid=142,@yk=0,@jhjetj=1,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output

select @err_code,@err_text



*/

begin



create table #ywlx(ywlx varchar(30),ywmc varchar(50),ywzt varchar(10),ywfx varchar(10),ywjc varchar(30),tjlx varchar(50),ywlxpxfs int,wldwhz int,wldwlx int)





--准备本月或本年月结记录ID 

create table #tempyjjl(yjid uniqueidentifier,kjnf int ,kjyf int,deptid int,qc smallint ,qm smallint)

if @yk=1 

begin

	insert into #tempyjjl(yjid,kjnf,kjyf,deptid)

	select b.ID,KJNF,KJYF,a.DEPTID from YP_YJKS a left join YP_KJQJ b 

	on a.DEPTID=b.DEPTID and KJNF=@year and ((KJYF=@month and @month>0) or @month=0) where a.KSLX='药库' and a.DEPTID =@deptid and QYBZ=1

	insert into #ywlx(ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx) select ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx from yk_ywlx

end

else

begin

	insert into #tempyjjl(yjid,kjnf,kjyf,deptid)

	select b.ID,KJNF,KJYF,a.DEPTID from YP_YJKS a left join YP_KJQJ b 

	on a.DEPTID=b.DEPTID and KJNF=@year and ((KJYF=@month and @month>0) or @month=0)  where a.KSLX='药房' and a.DEPTID =@deptid and QYBZ=1

	insert into #ywlx(ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx) select ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx from yf_ywlx

end





--药库

if @yk=1

   if @jhjetj=0

			select a.CJID 编码,S_YPPM 品名,S_YPGG 规格,S_YPDW 单位,a.LSJ 单价,cast(SUM(dbo.FUN_YK_DRT(a.ywlx,YPSL))*(-1) as float) 数量, 

			sum(dbo.FUN_YK_DRT(a.ywlx,lsje))*(-1) 金额 

			from YP_TJ_YMJCMX a inner join #tempyjjl b on a.YJID=b.yjid inner join #ywlx c on a.YWLX=c.ywlx

			inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='本期减少'  --and a.YWLX in('003','014')

			group by a.CJID,d.SHH,S_YPPM,S_YPGG,S_YPDW,a.LSJ order by a.CJID 

   else

			select a.CJID 编码,S_YPPM 品名,S_YPGG 规格,S_YPDW 单位,a.JHJ 单价,cast(SUM(dbo.FUN_YK_DRT(a.ywlx,YPSL))*(-1) as float) 数量, 

			sum(dbo.FUN_YK_DRT(a.ywlx,JHJE))*(-1) 金额 

			from YP_TJ_YMJCMX a inner join #tempyjjl b on a.YJID=b.yjid inner join #ywlx c on a.YWLX=c.ywlx

			inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='本期减少'  --and a.YWLX in('003','014')

			group by a.CJID,d.SHH,S_YPPM,S_YPGG,S_YPDW,a.JHJ order by a.CJID 

else

   if @jhjetj=0

			select a.CJID 编码,S_YPPM 品名,S_YPGG 规格,S_YPDW 单位,a.LSJ 单价,cast(SUM(dbo.FUN_Yf_DRT(a.ywlx,YPSL))*(-1) as float) 数量, 

			sum(dbo.FUN_Yf_DRT(a.ywlx,lsje))*(-1) 金额 

			from YP_TJ_YMJCMX a inner join #tempyjjl b on a.YJID=b.yjid inner join #ywlx c on a.YWLX=c.ywlx

			inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='本期减少'  --and a.YWLX in('003','014')

			group by a.CJID,d.SHH,S_YPPM,S_YPGG,S_YPDW,a.LSJ order by a.CJID 

   else

			select a.CJID 编码,S_YPPM 品名,S_YPGG 规格,S_YPDW 单位,a.JHJ 单价,cast(SUM(dbo.FUN_Yf_DRT(a.ywlx,YPSL))*(-1) as float) 数量, 

			sum(dbo.FUN_Yf_DRT(a.ywlx,JHJE))*(-1) 金额 

			from YP_TJ_YMJCMX a inner join #tempyjjl b on a.YJID=b.yjid inner join #ywlx c on a.YWLX=c.ywlx

			inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='本期减少'  --and a.YWLX in('003','014')

			group by a.CJID,d.SHH,S_YPPM,S_YPGG,S_YPDW,a.JHJ order by a.CJID 

set @ERR_CODE=0

set @ERR_TEXT='保存成功'  

end 
GO


