IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_bb_yp_tjhztj]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_bb_yp_tjhztj]
GO
create proc sp_bb_yp_tjhztj
 ( 

   @RQ1 datetime, 

   @RQ2 datetime

 )

as 
select isnull(d.GHDWMC,'其他') 供货商,a.YPPM 药品名,
SUM(yfsl) 药房数量,SUM(yksl) 药库数量,sum(a.yfsl+a.yksl) 总数量,
SUM(a.yfjhje) 药房进货金额,SUM(a.ykjhje) 药库进货金额,sum(a.yfjhje+a.ykjhje) 进货金额
from
(
select b.CJID,b.YPPCH,b.YPPM,b.YPSL yfsl,b.JHJE yfjhje,0 yksl,0 ykjhje
from VI_YF_DJ a
inner join VI_YF_DJMX b on a.ID=b.DJID
where a.YWLX='005'
and a.SHRQ between @RQ1 and @RQ2
union all
select b.CJID,b.YPPCH,b.YPPM,0 yfsl,0 yfjhje,b.YPSL yksl,b.JHJE ykjhje
from VI_YK_DJ a
inner join VI_YK_DJMX b on a.ID=b.DJID
where a.YWLX='005'
and a.SHRQ between @RQ1 and @RQ2
) a
left join YK_DJMX b on a.CJID=b.CJID and a.YPPCH=b.YPPCH and b.YWLX='001'
left join YK_DJ c on b.DJID=c.ID
left join YP_GHDW d on c.WLDW=d.ID
--left join YP_YPCJD e on a.CJID=e.CJID
group by d.GHDWMC,a.YPPM--,e.N_YPLX
order by d.GHDWMC--e.N_YPLX