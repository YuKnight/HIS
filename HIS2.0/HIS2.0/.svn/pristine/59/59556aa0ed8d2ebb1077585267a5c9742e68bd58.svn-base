IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[VI_JMPZ_FYMX_SMYZ]') AND OBJECTPROPERTY(id, N'IsView') = 1) 


 drop view VI_JMPZ_FYMX_SMYZ
go
CREATE VIEW VI_JMPZ_FYMX_SMYZ 
  AS   select '住院' as kslx,a.EXEC_DEPT as yfid,a.group_id as grouptag,   
    d.brxxid as patientid,a.inpatient_id as visitid, d.brxm as patientname  
    ,dbo.FUN_ZY_SEEKSEXNAME(xb) as sex,csrq,dbo.FUN_ZY_AGE(csrq,3,getdate()) as nianl,order_usage  
    as routename, a.DEPT_ID as department_no,dbo.fun_getDeptname(a.DEPT_ID)   
    departmentname,dbo.FUN_ZY_GETBEDNO(bed_id) bed,ORDER_DOC as doctor_no, dbo.fun_GetDoctorName  
    (ORDER_DOC) as doctor,(  
    case  
      when mngtype=0  
        then 0  
      else 1   
    end) ordertype,a.BOOK_DATE as create_date, '' as pzfyjch,a.BOOK_DATE as   
    start_date,a.BOOK_DATE as end_date,frequency,frequency as zhujian,1 as   
    freq_interval,'' as freq_interval_unit,  dbo.fun_getdiseasename(in_diagnosis,c.YBLX) freq_detail,   
    inpatient_no,a.order_id as yzxh,a.HOITEM_ID as spid,yppm as spmch,yppm,ypgg as  
    shpgg,s_ypjx jixing,hlxs as bzjl, s_sccj as shengccj, a.num as singledose,  
    a.unit as usedw,a.num as shl,a.unit as dw,e.lsj as costs_dj, '' as   
    sjap,'' as beizhu,'' as ccfs,(  
    case  
      when ps_flag in(0,1,2)  
        then '皮试'  
      else ''  
    end) as pishi,dropsper as disu,1 as fybz,getdate() fy_date,  
    --HOITEM_ID,--医嘱项目ID  
    a.BABY_ID,  
    a.ORDER_DOC,dbo.FUN_GETEMPTYGUID() as fee_id,dbo.FUN_GETEMPTYGUID() cz_id ,e.GGID,a.ORDER_BDATE,dbo.fun_getDeptname(c.DEPT_ID) deptname
  from zy_orderrecord a
    --inner join zy_fee_speci b
    --on a.order_id=b.order_id
    inner join zy_inpatient c
    on a.inpatient_id=c.inpatient_id
    inner join yy_brxx d--base_patient_property
    on c.patient_id=d.BRXXID--patient_id
    inner join vi_yp_ypcd e
    on a.HOITEM_ID=e.cjid
  where a.HOITEM_ID>0 and a.xmly=1
    and a.delete_bit=0
    and ORDER_USAGE in ('静滴','i.v','续滴')
    --and a.EXEC_DEPT=40 
    and 
	  cast(convert(varchar(10),ORDER_BDATE,120)as datetime) >cast(convert(varchar(10),getdate()-40,120)as datetime) 
    and a.MNGTYPE=0 and a.DEPT_id in(416,418)
	and ORDER_CONTEXT like '%自备%'
go


