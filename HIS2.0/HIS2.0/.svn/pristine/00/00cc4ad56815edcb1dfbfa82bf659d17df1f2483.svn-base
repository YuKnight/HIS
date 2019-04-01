IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ZYYS_SHOW_ORDERS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ZYYS_SHOW_ORDERS]
GO
CREATE PROCEDURE [dbo].[SP_ZYYS_SHOW_ORDERS]      
 (      
	@SIGN INTEGER,       
	@BINID UNIQUEIDENTIFIER,      
	@JGBM BIGINT      
 )       
AS      
------------------------------------------------------------------------      
-- SQL 存储过程      
-- BINID      
------------------------------------------------------------------------      
BEGIN      
 -- 该住院病人的检验医嘱      
 IF @SIGN = 0      
 BEGIN       
        SELECT DISTINCT ID, 申请时间, 医嘱号, 检验项目, 执行科室,DBO.FUN_ZY_SEEKHOITEMPRICE(CAST(A.HID AS BIGINT),@JGBM) AS 检验费, 医嘱状态, 下嘱医生,申请号    
        FROM (SELECT o.ORDER_ID AS ID, HOITEM_ID AS HID, BOOK_DATE AS "申请时间",o.GROUP_ID AS "医嘱号", o.ORDER_CONTEXT AS "检验项目",DBO.FUN_ZY_SEEKDEPTNAME(o.EXEC_DEPT) AS "执行科室",      
                     (CASE WHEN STATUS_FLAG = 0 THEN '未发送' WHEN STATUS_FLAG = 1 THEN '已发送' WHEN STATUS_FLAG = 2 THEN '已审核' WHEN STATUS_FLAG = 5 THEN '已执行' END) AS "医嘱状态",      
                     (SELECT NAME FROM JC_EMPLOYEE_PROPERTY WHERE o.ORDER_DOC = EMPLOYEE_ID) AS "下嘱医生" ,b.ID as jcxmid,b.NAME as jclxname,o.EXEC_DEPT,c.apply_no 申请号    
               FROM VI_ZY_ORDERRECORD o inner join    
     JC_ASSAY a  on o.HOITEM_ID=a.YZID    
     join JC_JCCLASSDICTION  b on a.HYLXID=b.ID   
     left join ZY_JY_PRINT c on o.ORDER_ID=c.ORDER_ID   
               WHERE o.INPATIENT_ID =@BINID AND NTYPE = 5 AND o.DELETE_BIT=0 --Modify By Tany 2015-04-13 这段话不知道什么意思 AND o.EXEC_DEPT IN (SELECT o.EXEC_DEPT FROM JC_ASSAY WHERE o.DELETE_BIT=0)  
             ) AS A       
        ORDER BY 申请时间      
 END      
      
    -- 该病人的检查医嘱      
    IF @SIGN = 1      
 BEGIN       
        SELECT DISTINCT ID, 申请时间, 医嘱号, 检查项目, 执行科室,((JSNUM) * (DBO.FUN_ZY_SEEKHOITEMPRICE(CAST(A.HID AS BIGINT),@JGBM))) AS 检查费,医嘱状态, 下嘱医生 , jcxmid, jclxname,HID,EXEC_DEPT,bbmc,DW,IN_DIAGNOSIS,zysx,JSNUM,JC_NO      
        FROM (SELECT ORDER_ID AS ID, t.HOITEM_ID AS HID, BOOK_DATE AS "申请时间",t.GROUP_ID AS "医嘱号", ORDER_CONTEXT AS "检查项目",DBO.FUN_ZY_SEEKDEPTNAME(EXEC_DEPT) AS "执行科室",      
                     (CASE WHEN STATUS_FLAG = 0 THEN '未发送' WHEN STATUS_FLAG = 1 THEN '已发送' WHEN STATUS_FLAG = 2 THEN '已审核' WHEN STATUS_FLAG = 5 THEN '已执行' END) AS "医嘱状态",      
                     (SELECT NAME FROM JC_EMPLOYEE_PROPERTY WHERE ORDER_DOC = EMPLOYEE_ID) AS "下嘱医生",NUM AS JSNUM  ,b.ID as jcxmid,b.NAME as jclxname ,EXEC_DEPT,'' as bbmc,c.IN_DIAGNOSIS,c.zysx,UNIT as DW ,JC_NO   
              FROM VI_ZY_ORDERRECORD t inner join    
     JC_JC_ITEM a  on HOITEM_ID=a.YZID    
     inner join ZY_JC_RECORD c on t.INPATIENT_ID=c.INPATIENT_ID and t.GROUP_ID=c.GROUP_ID
     join JC_JCCLASSDICTION  b on a.JCLXID=b.ID      
              WHERE t.INPATIENT_ID =@BINID AND NTYPE = 5 AND t.DELETE_BIT=0 AND EXEC_DEPT IN(SELECT EXEC_DEPT FROM JC_JC_ITEM WHERE t.DELETE_BIT=0)-- and exists(select 1 from zy_jc_record t1 where t1.ID=ORDER_ID and t1.GROUP_ID=GROUP_ID and t1.DELETE_BIT=0)    
       
              ) AS A      
        ORDER BY 申请时间      
 END      
     
 ---门诊病人的检查医嘱    
     IF @SIGN = 2      
 BEGIN       
        SELECT DISTINCT ID, 申请时间, 医嘱号, 检查项目, 执行科室,((JSNUM) * (DBO.FUN_ZY_SEEKHOITEMPRICE(CAST(A.HID AS BIGINT),@JGBM))) AS 检查费,医嘱状态, 下嘱医生 , jcxmid, jclxname,HID,EXEC_DEPT,BBMC,DW,JSNUM    
        FROM (SELECT m.YJSQID AS ID, m.YZXMID AS HID, m.SQRQ AS "申请时间",0 AS "医嘱号", m.SQNR AS "检查项目",DBO.FUN_ZY_SEEKDEPTNAME(ZXKS) AS "执行科室",      
                    CASE WHEN BSFBZ = 0 THEN '未收费' else '已收费' end AS "医嘱状态",      
                    dbo.fun_getEmpName(SQR) AS "下嘱医生",SL AS JSNUM  ,b.ID as jcxmid,b.NAME as jclxname ,ZXKS as EXEC_DEPT,m.BBMC,m.DW    
              FROM YJ_MZSQ m inner join    
     JC_JC_ITEM a  on m.YZXMID=a.YZID    
     join JC_JCCLASSDICTION  b on a.JCLXID=b.ID      
              WHERE m.GHXXID =@BINID AND  m.DJLX=2  AND BSCBZ=0       
              ) AS A      
        ORDER BY 申请时间     
 END     
END       

GO


