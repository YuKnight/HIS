IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YJ_APPLYREADX]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YJ_APPLYREADX]
GO
CREATE  PROCEDURE [dbo].[SP_YJ_APPLYREADX]        
 (        
  @JGBM bigint,         
  @ZXKS int,        
  @txm varchar(50),      
  @zyh varchar(30),      
  @sqks int,      
  @BRXM VARCHAR(30),      
  @YZXMID BIGINT ,      
  @cwh varchar(30),      
  @type int --Add By Tany 2010-11-26 查询方式-1=全部0=正费用1=负费用      
 )         
        
         
AS        
        
BEGIN        
DECLARE @SS VARCHAR(8000)      
DECLARE @SS1 VARCHAR(8000)      
      
SET @SS='      
    SELECT '''' 序号,      
		AA.YJSQID,      
		AA.YZID,        
		AA.ZXID AS YZZXID,      
		CAST(0 AS SMALLINT) AS SELECTED,      
		NAME BRXM,      
		dbo.FUN_ZY_SEEKSEXNAME(xb) XB,        
		INPATIENT_NO,      
		dbo.FUN_ZY_GETBEDNO(CC.BED_ID) as bedno,      
		dbo.FUN_ZY_SEEKJSFSNAME(DISCHARGETYPE) DISCHARGETYPES,        
		'''' as djlx ,      
		dbo.FUN_ZY_SEEKDEPTNAME(AA.SQKS) AS SQKS,        
		AA.SQRQ,      
		dbo.FUN_ZY_SEEKEMPLOYEENAME(AA.sqr) as SQR,      
		AA.SQNR,AA.JE as je,''费用'' AS FEE ,AA.TXM,zxks,btfbz       
    FROM YJ_ZYSQ AA inner join  zy_orderrecord BB  ON AA.YZID=BB.ORDER_ID INNER JOIN       
    (select b.inpatient_no,b.inpatient_id,(case when baby_id is null then 0 else baby_id end) baby_id,b.flag, BRXM as name,xb,b.YBLX,b.DISCHARGETYPE,b.BED_ID,A.PYM,A.WBM     
     from YY_BRXX a inner join ZY_INPATIENT b on a.BRXXID=b.PATIENT_ID    
    left join ZY_INPATIENT_BABY c on b.INPATIENT_ID=c.INPATIENT_ID)  CC        
    ON (BB.INPATIENT_ID=CC.INPATIENT_ID 
		AND BB.BABY_ID=CC.BABY_ID) or  (BB.INPATIENT_ID=CC.INPATIENT_ID)      
     WHERE CC.flag not in(2,6,10) and AA.BSCBZ=0 AND AA.BTFBZ=0 AND BJSBZ=0 and ZXR>0 '  --    
IF @JGBM>0       
	SET @SS=@SS+' AND AA.JGBM='+CAST(@JGBM AS VARCHAR(30))+''      
IF @ZXKS>0       
	SET @SS=@SS+' AND AA.ZXKS='+CAST(@ZXKS AS VARCHAR(30))+''      
IF @txm<>''      
	SET @SS=@SS+' AND AA.TXM='''+CAST(@txm AS VARCHAR(50))+''''      
IF @ZYH<>''      
	SET @SS=@SS+' AND CC.INPATIENT_NO='''+CAST(@ZYH AS VARCHAR(30))+''''      
IF @SQKS<>''      
begin      
    if  exists(select 1 from jc_config where id=10015 and CONFIG='1')      
		SET @SS=@SS+' AND AA.SQKS in(select b.dept_id from jc_ward a inner join JC_WARDRDEPT b on a.ward_id=b.ward_id  where a.dept_id= '''+CAST(@SQKS AS VARCHAR(50))+''')'      
    else      
        SET @SS=@SS+' AND AA.SQKS='+CAST(@sqks as varchar(30))      
end      
IF @YZXMID>0      
	SET @SS=@SS+' AND AA.YZXMID='''+CAST(@YZXMID AS VARCHAR(50))+''''      
IF @BRXM<>''      
	SET @SS=@SS+' AND ( CC.name like ''%'+CAST(@BRXM AS VARCHAR(30))+'%'' or CC.pym='''+@brxm+'''  or CC.wbm='''+@brxm+''')'      
if @cwh<>''      
	set @ss=@ss+' and dbo.FUN_ZY_GETBEDNO(bed_id)='''+@cwh+''''      
      
SET @SS1='        
    SELECT '''' 序号,      
		AA.YJSQID,      
		AA.YZID,        
		AA.ZXID AS YZZXID,      
		CAST(0 AS SMALLINT) AS SELECTED,      
		NAME BRXM,      
		dbo.FUN_ZY_SEEKSEXNAME(xb) XB,        
		INPATIENT_NO,      
		dbo.FUN_ZY_GETBEDNO(CC.BED_ID) as bedno,      
		dbo.FUN_ZY_SEEKJSFSNAME(DISCHARGETYPE) DISCHARGETYPES,        
		'''' as djlx ,      
		dbo.FUN_ZY_SEEKDEPTNAME(AA.SQKS) AS SQKS,        
		AA.SQRQ,      
		dbo.FUN_ZY_SEEKEMPLOYEENAME(AA.sqr) as SQR,      
		AA.SQNR,AA.TFJE as je,''费用'' AS FEE ,AA.TXM,zxks ,btfbz      
    FROM YJ_ZYSQ AA inner join  zy_orderrecord BB  ON AA.YZID=BB.ORDER_ID INNER JOIN       
    (select b.inpatient_no,b.inpatient_id,(case when baby_id is null then 0 else baby_id end) baby_id,b.flag, BRXM as name,xb,b.YBLX,b.DISCHARGETYPE,b.BED_ID ,A.PYM,A.WBM     
     from YY_BRXX a inner join ZY_INPATIENT b on a.BRXXID=b.PATIENT_ID    
    left join ZY_INPATIENT_BABY c on b.INPATIENT_ID=c.INPATIENT_ID)  CC        
    ON (BB.INPATIENT_ID=CC.INPATIENT_ID 
	AND BB.BABY_ID=CC.BABY_ID) or  (BB.INPATIENT_ID=CC.INPATIENT_ID)    
    WHERE CC.flag not in(2,6,10) and AA.BSCBZ=0 AND AA.BTFBZ=1 AND BJSBZ=1  '      
IF @JGBM>0       
	SET @SS1=@SS1+' AND AA.JGBM='+CAST(@JGBM AS VARCHAR(30))+''      
IF @ZXKS>0       
	SET @SS1=@SS1+' AND AA.ZXKS='+CAST(@ZXKS AS VARCHAR(30))+''      
IF @txm<>''      
	SET @SS1=@SS1+' AND AA.TXM='''+CAST(@txm AS VARCHAR(50))+''''      
IF @ZYH<>''      
	SET @SS1=@SS1+' AND CC.INPATIENT_NO='''+CAST(@ZYH AS VARCHAR(30))+''''      
IF @SQKS<>''      
begin      
	if  exists(select 1 from jc_config where id=10015 and CONFIG='1')      
		SET @SS1=@SS1+' AND AA.SQKS in(select b.dept_id from jc_ward a inner join JC_WARDRDEPT b on a.ward_id=b.ward_id  where a.dept_id= '''+CAST(@SQKS AS VARCHAR(50))+''')'      
	else      
		SET @SS1=@SS1+' AND AA.SQKS='+CAST(@sqks as varchar(30))      
end      
    
IF @YZXMID>0      
	SET @SS1=@SS1+' AND AA.YZXMID='''+CAST(@YZXMID AS VARCHAR(50))+''''      
IF @BRXM<>''      
	SET @SS1=@SS1+' AND ( CC.name like ''%'+CAST(@BRXM AS VARCHAR(30))+'%'' or CC.pym='''+@brxm+'''  or CC.wbm='''+@brxm+''')'      
if @cwh<>''      
	set @SS1=@SS1+' and dbo.FUN_ZY_GETBEDNO(bed_id)='''+@cwh+''''      
  
--Modify By Tany 2010-11-26      
if @type=0      
	EXEC(@SS+' order by SQKS,INPATIENT_NO')      
else if @type=1      
	EXEC(@SS1)      
else      
	EXEC(@SS+' union ALL'+@SS1+' order by SQKS,INPATIENT_NO')      
  
print (@SS+' union ALL'+@SS1+' order by SQKS,INPATIENT_NO')      
      
-- SELECT '' 序号,      
-- AA.YJSQID,      
-- AA.YZID,        
--    AA.ZXID AS YZZXID,      
--    CAST(0 AS SMALLINT) AS SELECTED,      
-- NAME BRXM,      
-- sex XB,        
--    INPATIENT_NO,      
-- dbo.FUN_ZY_GETBEDNO(BB.BED_ID) as bedno,      
-- dbo.FUN_ZY_SEEKJSFSNAME(DISCHARGETYPE) DISCHARGETYPES,        
--    '' as djlx ,      
-- dbo.FUN_ZY_SEEKDEPTNAME(AA.SQKS) AS SQKS,        
--    AA.SQRQ,      
-- dbo.FUN_ZY_SEEKEMPLOYEENAME(AA.sqr) as SQR,      
-- AA.SQNR,AA.JE as je,'费用' AS FEE ,AA.TXM,zxks,btfbz       
--    FROM YJ_ZYSQ AA inner join         
--    vi_zy_vinpatient  BB        
--    ON AA.INPATIENT_ID=BB.INPATIENT_ID WHERE AA.BSCBZ=0 AND AA.BTFBZ=0 AND BJSBZ=0 and ZXR>0  AND AA.JGBM=1003 AND AA.ZXKS=14 AND AA.SQKS in(select b.dept_id from jc_ward a inner join JC_WARDRDEPT b on a.ward_id=b.ward_id  where a.dept_id= '275') UNION 
 
     
       
--    SELECT '' 序号,      
-- AA.YJSQID,      
-- AA.YZID,        
-- AA.ZXID AS YZZXID,      
--    CAST(0 AS SMALLINT) AS SELECTED,      
-- NAME BRXM,      
-- sex XB,        
--    INPATIENT_NO,      
-- dbo.FUN_ZY_GETBEDNO(BB.BED_ID) as bedno,      
-- dbo.FUN_ZY_SEEKJSFSNAME(DISCHARGETYPE) DISCHARGETYPES,        
--    '' as djlx ,      
-- dbo.FUN_ZY_SEEKDEPTNAME(AA.SQKS) AS SQKS,        
--    AA.SQRQ,      
-- dbo.FUN_ZY_SEEKEMPLOYEENAME(AA.sqr) as SQR,      
-- AA.SQNR,AA.TFJE as je,'费用' AS FEE ,AA.TXM,zxks ,btfbz      
--    FROM YJ_ZYSQ AA inner join         
--    vi_zy_vinpatient  BB        
--    ON AA.INPATIENT_ID=BB.INPATIENT_ID WHERE AA.BSCBZ=0 AND AA.BTFBZ=1 AND BJSBZ=1   AND AA.JGBM=1003 AND AA.ZXKS=14 AND AA.SQKS in(select b.dept_id from jc_ward a inner join JC_WARDRDEPT b on a.ward_id=b.ward_id  where a.dept_id= '275')      
      
      
 END    
   
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
GO


