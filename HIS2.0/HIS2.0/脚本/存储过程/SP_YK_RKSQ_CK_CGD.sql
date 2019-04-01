IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YK_RKSQ_CK_CGD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YK_RKSQ_CK_CGD]
GO
CREATE PROCEDURE [dbo].[SP_YK_RKSQ_CK_CGD]
(
	@DJID UNIQUEIDENTIFIER ,
	@DEPTID INTEGER,
	@functionname varchar(50)
) 
as
/*
采购入库单转出库单
*/
 begin

declare @bpcgl int =0 --是否进行批次管理
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--暂时设定为999

if EXISTS(select * from jc_config where id=8002 and config='0')
	SELECT 0 序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,s_sccj 厂家,
	a.yppch 批次号,a.kcid ,
	a.ypph 批号,YPXQ 效期,HWMC 库位,
	cast(round((b.pfj/ydwbl),3) as decimal(15,3)) 批发价,
	cast(round((b.lsj/ydwbl),4) as decimal(15,4)) 零售价,b.KCL 总库存,0 申请量,ypsl 数量,
	dbo.fun_yp_ypdw(a.nypdw) 单位,cast(round((b.pfj*ypsl/ydwbl),2) as decimal(15,2)) 批发金额,
	cast(round((b.lsj*ypsl/ydwbl),2) as decimal(15,2)) 零售金额,
	cast(round((b.lsj*ypsl/ydwbl),2) as decimal(15,2))-cast(round((b.pfj*ypsl/ydwbl),2) as decimal(15,2)) 批零差额,
	( case @bpcgl when 0 then '0' else A.JHJ end ) 进价,(case @bpcgl when 0 then '0.00' else  a.JHJ*A.YPSL end) 进货金额,case A.zbzt when 1 then '是' else '否' end as 中标状态,
	b.shh 货号,a.cjid,a.ydwbl dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id 
	FROM yk_djmx A inner join vi_yk_kcmx B on A.CJID=B.CJID and b.deptid=@deptid
   left join yp_hwsz C on   B.GGID=C.GGID AND B.DEPTID=C.DEPTID
   where a.djid=@djid order by a.pxxh
else
	SELECT 0 序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,s_sccj 厂家,
	a.yppch 批次号 ,a.kcid ,
	a.ypph 批号,YPXQ 效期,HWMC 库位,
	cast(round((b.pfj/ydwbl),3) as decimal(15,3)) 批发价,
	cast(round((b.lsj/ydwbl),4) as decimal(15,4)) 零售价,b.kcl 总库存,0 申请量,ypsl 数量,
	dbo.fun_yp_ypdw(a.nypdw) 单位,cast(round((b.pfj*ypsl/ydwbl),2) as decimal(15,2)) 批发金额,
	cast(round((b.lsj*ypsl/ydwbl),2) as decimal(15,2)) 零售金额,
	cast(round((b.lsj*ypsl/ydwbl),2) as decimal(15,2))-cast(round((b.pfj*ypsl/ydwbl),2) as decimal(15,2)) 批零差额,
	jhj 进价,cast(round((a.jhj*ypsl/ydwbl),2) as decimal(15,2)) 进货金额,
	b.shh 货号,a.cjid,a.ydwbl dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id 
	FROM yk_djmx A inner join vi_yk_kcmx B on A.CJID=B.CJID and b.deptid=@deptid
   left join yp_hwsz C on   B.GGID=C.GGID AND B.DEPTID=C.DEPTID
   where a.djid=@djid order by a.pxxh
end



GO


