
/****** Object:  View [dbo].[VI_ZY_PIVAS_Med]    Script Date: 03/31/2015 17:53:34 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_ZY_PIVAS_Med]'))
DROP VIEW [dbo].[VI_ZY_PIVAS_Med]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE VIEW [dbo].[VI_ZY_PIVAS_Med]
  AS  
	select cast(a.ORDER_ID as varchar(50)) as recipeid,
	cast(a.GROUP_ID as varchar(10))+'$'+cast(b.INPATIENT_NO as varchar(20)) as groupno,
	t.pvs_xh as recipeno,
	cast(INPATIENT_NO as varchar(20))+'$'+cast(a.BABY_ID as varchar(20)) as patientcode,
	cast(a.INPATIENT_ID as varchar(50)) as caseid,
	a.ORDER_DOC as doctorcode,dbo.fun_getEmpName(a.ORDER_DOC) as doctorname,a.WARD_ID as wardcode,
	b.BED_NO as bedno,a.HOITEM_ID as drugcode,a.ORDER_CONTEXT as drugname,c.S_YPGG as spec,a.DOSAGE as dosage,
	a.UNIT as dosageunit,a.zsl as quantity,a.zsldw as quantityunit,a.ORDER_USAGE as usagecode,d.MEMO as usagename,
	a.FREQUENCY as freqcode,a.ORDER_BDATE as startdt,a.ORDER_EDATE as enddt,
	cast(t.ID as varchar(50)) as tpn,
	a.MEMO as remark,t.PRESC_DATE as occdt,t.pvs_xh as zxh
	from (select * from ZY_ORDERRECORD a where a.is_PvsChk=1 and LASTEXECUSER is not null and a.DELETE_BIT=0) a 
	inner join VI_ZY_VINPATIENT_BED b on a.INPATIENT_ID=b.INPATIENT_ID 
	inner join YP_YPCJD c on a.HOITEM_ID=c.CJID and a.XMLY=1
	inner join JC_USAGEDICTION d on a.ORDER_USAGE =d.NAME
	inner join ZY_FEE_SPECI t on a.ORDER_ID=t.ORDER_ID and t.CZ_FLAG=0 and t.FY_BIT=1 and t.is_PvsScn=0 and t.DELETE_BIT=0 
	--left join JC_CONFIG e on e.ID=7602
	where exists(select 1 from JC_DEPT_DRUGSTORE g where g.is_PvsRel=1 and g.DELETE_BIT=0 and g.DEPT_ID=a.DEPT_BR and t.EXECDEPT_ID=g.DRUGSTORE_ID)
	--a.is_PvsChk=1 and LASTEXECUSER is not null and 
	--and (a.MNGTYPE = (case e.CONFIG when '0' then 0 when '1' then 1 end) or e.CONFIG='2')
GO


