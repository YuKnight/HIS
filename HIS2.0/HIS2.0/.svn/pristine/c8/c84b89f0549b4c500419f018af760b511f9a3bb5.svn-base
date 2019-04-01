IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[VI_JMPZ_FYMX]') AND OBJECTPROPERTY(id, N'IsView') = 1) 


 drop view VI_JMPZ_FYMX
go
CREATE VIEW VI_JMPZ_FYMX 
  AS   select '住院' as kslx,b.execdept_id as yfid,a.group_id as grouptag,   
    d.brxxid as patientid,a.inpatient_id as visitid, d.brxm as patientname  
    ,dbo.FUN_ZY_SEEKSEXNAME(xb) as sex,csrq,dbo.FUN_ZY_AGE(csrq,3,getdate()) as nianl,order_usage  
    as routename, b.dept_ly as department_no,dbo.fun_getDeptname(b.dept_ly)   
    departmentname,dbo.FUN_ZY_GETBEDNO(bed_id) bed,doc_id as doctor_no, dbo.fun_GetDoctorName  
    (doc_id) as doctor,(  
    case  
      when mngtype=0  
        then 0  
      else 1   
    end) ordertype,b.book_date as create_date, '' as pzfyjch,presc_date as   
    start_date,presc_date as end_date,frequency,frequency as zhujian,1 as   
    freq_interval,'' as freq_interval_unit,  dbo.fun_getdiseasename(in_diagnosis,c.YBLX) freq_detail,   
    inpatient_no,a.order_id as yzxh,b.xmid as spid,yppm as spmch,yppm,ypgg as  
    shpgg,s_ypjx jixing,hlxs as bzjl, s_sccj as shengccj, a.num as singledose,  
    a.unit as usedw,b.num as shl,b.unit as dw,b.cost_price as costs_dj, '' as   
    sjap,'' as beizhu,'' as ccfs,(  
    case  
      when ps_flag in(0,1,2)  
        then '皮试'  
      else ''  
    end) as pishi,dropsper as disu,fy_bit as fybz,fy_date,  
    --HOITEM_ID,--医嘱项目ID  
    a.BABY_ID,  
    b.book_user  ,b.id as fee_id,b.cz_id ,e.GGID,a.ORDER_BDATE,dbo.fun_getDeptname(c.DEPT_ID) deptname
  from zy_orderrecord a
    inner join zy_fee_speci b
    on a.order_id=b.order_id
    inner join zy_inpatient c
    on a.inpatient_id=c.inpatient_id
    inner join yy_brxx d--base_patient_property
    on c.patient_id=d.BRXXID--patient_id
    inner join vi_yp_ypcd e
    on b.xmid=e.cjid
  where b.xmid>0 and b.xmly=1
    and b.delete_bit=0
    and fy_bit=1
    and ORDER_USAGE in ('静滴','i.v','续滴')
    and b.execdept_id=40 and fy_user>0--40
    and 
	  (
	  cast(convert(varchar(10),PRESC_DATE,120)as datetime) >cast(convert(varchar(10),getdate(),120)as datetime) or 
	  (
	   cast(convert(varchar(10),PRESC_DATE,120)as datetime)=cast(convert(varchar(10),getdate(),120)as datetime) and
	   cast(convert(varchar(10),a.order_bdate,120)as datetime) =cast(convert(varchar(10),getdate()-1,120)as datetime)
	  )
	  or 
	  	  (
	   cast(convert(varchar(10),PRESC_DATE,120)as datetime)=cast(convert(varchar(10),getdate(),120)as datetime) and
	   cast(convert(varchar(10),a.order_bdate,120)as datetime) <cast(convert(varchar(10),getdate()-1,120)as datetime) and b.NUM<0
	  )
	  )
    and a.MNGTYPE=0 and DEPT_LY in(416,418)
    --处方日期大于等于当前的日期 getdate()
    --and f.LYFLCODE in ('99')    
	--and a.MNGTYPE=0
--select lyflcode,* from ZY_APPLY_DRUG
--select  * from zy_inpatient where FLAG in(1,3,4)
go


