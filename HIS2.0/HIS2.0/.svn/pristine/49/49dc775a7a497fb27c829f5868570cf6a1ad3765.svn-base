

/****** Object:  View [dbo].[VI_ZY_PIVAS_ORDER]    Script Date: 03/31/2015 17:53:34 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_ZY_PIVAS_ORDER]'))
DROP VIEW [dbo].[VI_ZY_PIVAS_ORDER]
GO

/****** Object:  View [dbo].[VI_ZY_PIVAS_ORDER]   Script Date: 03/31/2015 17:53:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE VIEW [dbo].[VI_ZY_PIVAS_ORDER]
  AS  
	--长嘱（第一次药不走pivas，必须执行一次且因为预领药功能不给 开单日期 为当天的处方）
	select cast(a.ORDER_ID as varchar(100)) as recipeid,
	cast(a.GROUP_ID as varchar(10))+'$'+cast(b.INPATIENT_NO as varchar(20)) as groupno,
	'' as recipeno,
	cast(INPATIENT_NO as varchar(20))+'$'+cast(a.BABY_ID as varchar(20)) as patientcode ,
	cast(a.INPATIENT_ID as varchar(100)) as caseid,
	a.ORDER_DOC as doctorcode,dbo.fun_getEmpName(a.ORDER_DOC) as doctorname,a.WARD_ID as wardcode,
	b.BED_NO as bedno,a.HOITEM_ID as drugcode,a.ORDER_CONTEXT as drugname,c.S_YPGG as spec,a.NUM as dosage,
	a.UNIT as dosageunit,a.zsl as quantity,a.zsldw as quantityunit,a.ORDER_USAGE as usagecode,d.MEMO as usagename,
	a.FREQUENCY as freqcode,a.ORDER_BDATE as startdt,a.ORDER_EDATE as enddt,
	'' as tpn,a.DROPSPER as remark,'' as occdt,a.SERIAL_NO as zxh
	from 
	(
		select * from ZY_ORDERRECORD where STATUS_FLAG=2 and MNGTYPE=0 
		and LASTEXECUSER is not null  --长嘱第一次药不走pivas，必须执行一次 
		and exists(select 1 from VI_pivas_Orderusage f where ORDER_USAGE=f.name) -- 用法过滤
		and exists(select 1 from JC_DEPT_DRUGSTORE g where g.is_PvsRel=1 and g.DELETE_BIT=0 and g.DEPT_ID=DEPT_BR) --上线pivas药房过滤
	) a 
	inner join VI_ZY_VINPATIENT_BED b on a.INPATIENT_ID=b.INPATIENT_ID 
	inner join YP_YPCJD c on a.HOITEM_ID=c.CJID and a.XMLY=1
	inner join JC_USAGEDICTION d on a.ORDER_USAGE =d.NAME
	left join JC_CONFIG e on e.ID=7602
	where  e.CONFIG in ('0','2')
	and NOT exists		--kcl<=0的病人的组医嘱过滤
	(
		--select 1 from ZY_ORDERRECORD t,YF_KCMX t1 where t.STATUS_FLAG=2 and t.MNGTYPE=0 and t.LASTEXECUSER is not null
		--and exists(select 1 from VI_pivas_Orderusage f where t.ORDER_USAGE=f.name) -- 用法过滤
		--and exists(select 1 from JC_DEPT_DRUGSTORE g where g.is_PvsRel=1 and g.DELETE_BIT=0 and g.DEPT_ID=t.DEPT_BR) --上线pivas药房过滤
		--and t.EXEC_DEPT=t1.DEPTID and t.XMLY=1 and t.HOITEM_ID=t1.CJID and t1.KCL<=0
		--and t.INPATIENT_ID=a.INPATIENT_ID and t.BABY_ID=a.BABY_ID and t.GROUP_ID=a.GROUP_ID
		select 1 from ZY_ORDERRECORD t
		left join JC_DEPT_DRUGSTORE t2 on t2.is_PvsRel=1 and t2.DELETE_BIT=0 and t2.DEPT_ID=t.DEPT_BR --上线pivas药房过滤
		left join YF_KCMX t1 on t2.DRUGSTORE_ID=t1.DEPTID and t.XMLY=1 and t1.BDELETE=0
		 where t.STATUS_FLAG=2 and t.MNGTYPE=0 and t.LASTEXECUSER is not null
			and exists(select 1 from VI_pivas_Orderusage f where t.ORDER_USAGE=f.name) -- 用法过滤
			and ((t.HOITEM_ID=t1.CJID and t1.KCL<=0) or not exists(select 1 from YF_KCMX t3 where t3.DEPTID=t2.DRUGSTORE_ID and t3.CJID=t.HOITEM_ID and t.XMLY=1 and t3.BDELETE=0 ))
			and t.INPATIENT_ID=a.INPATIENT_ID and t.BABY_ID=a.BABY_ID and t.GROUP_ID=a.GROUP_ID
	)
	/*
	union all
	--临嘱（转抄当天就给pivas审核）
	select cast(a.ORDER_ID as varchar(100)) as recipeid,
	cast(a.GROUP_ID as varchar(10))+'$'+cast(b.INPATIENT_NO as varchar(20)) as groupno,
	'' as recipeno,
	cast(INPATIENT_NO as varchar(20))+'$'+cast(a.BABY_ID as varchar(20)) as patientcode ,
	cast(a.INPATIENT_ID as varchar(100)) as caseid,
	a.ORDER_DOC as doctorcode,dbo.fun_getEmpName(a.ORDER_DOC) as doctorname,a.WARD_ID as wardcode,
	b.BED_NO as bedno,a.HOITEM_ID as drugcode,a.ORDER_CONTEXT as drugname,c.S_YPGG as spec,a.DOSAGE as dosage,
	a.UNIT as dosageunit,a.zsl as quantity,a.zsldw as quantityunit,a.ORDER_USAGE as usagecode,d.MEMO as usagename,
	a.FREQUENCY as freqcode,a.ORDER_BDATE as startdt,a.ORDER_EDATE as enddt,
	'' as tpn,a.MEMO as remark,'' as occdt,a.SERIAL_NO as zxh
	from ZY_ORDERRECORD a 
	inner join VI_ZY_VINPATIENT_BED b on a.INPATIENT_ID=b.INPATIENT_ID 
	inner join YP_YPCJD c on a.HOITEM_ID=c.CJID and a.XMLY=1
	inner join JC_USAGEDICTION d on a.ORDER_USAGE =d.NAME
	left join JC_CONFIG e on e.ID=7602
	where STATUS_FLAG=2 
	and a.MNGTYPE=1 and e.CONFIG in ('1','2')
	--and (a.MNGTYPE = (case e.CONFIG when '0' then 0 when '1' then 1 end) or (e.CONFIG='2' and a.MNGTYPE in (0,1)))
	and exists(select 1 from VI_pivas_Orderusage f where a.ORDER_USAGE=f.name)
	*/
GO


