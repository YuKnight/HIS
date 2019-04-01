IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ts_zdybb_cydyhztj]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_ts_zdybb_cydyhztj]
GO
CREATE proc [dbo].[sp_ts_zdybb_cydyhztj]
(
@bdate datetime,
@edate datetime,
@empid int
)
as
/*
自定义报表——出院带药汇总统计
Create By Tany 2015-04-08
*/
begin

select b.YPPM 品名,b.YPGG 规格,sum(a.NUM) 数量,a.UNIT 单位,dbo.fun_getDeptname(a.EXECDEPT_ID) 药房名称
from VI_ZY_FEE_SPECI a
inner join VI_YP_YPCD b on a.XMID=b.cjid
where a.XMLY=1 and a.CHARGE_BIT=1 and a.DELETE_BIT=0
and a.FY_BIT=1 and a.TLFS=3
and a.FY_DATE between @bdate and @edate
and a.FY_USER=@empid
group by b.YPPM,b.YPGG,a.UNIT,a.EXECDEPT_ID

end
GO


