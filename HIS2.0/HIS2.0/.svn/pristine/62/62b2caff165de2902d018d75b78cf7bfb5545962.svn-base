IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ZYHS_ORDER_EXE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ZYHS_ORDER_EXE]
GO
create PROCEDURE [dbo].[SP_ZYHS_ORDER_EXE]
 (
  @INPATIENTID UNIQUEIDENTIFIER, 
  @BABYID BIGINT, 
  @GROUPID INT, 
  @MNGTYPE INT, 
  @BOOKDATE DATETIME, 
  @EXECDATE DATETIME, 
  @EXEUSER BIGINT,
  @OUTCODE INT OUTPUT,
  @OUTMSG VARCHAR(200) OUTPUT,
  @JGBM BIGINT
 ) 
AS
/*--------------------------------------------------------------------------
作者：TANY
说明：住院护士站-医嘱执行
日期：2006-12-11
参数：
  @INPATIENTID BIGINT, 
  @BABYID BIGINT, 
  @GROUPID BIGINT, 
  @MNGTYPE INTEGER, 
  @BOOKDATE TIMESTAMP, 
  @EXECDATE TIMESTAMP, 
  @EXEUSER
  @OUTCODE 错误代码
  @OUTMSG 错误信息
修改：
  --Modify By Tany 2010-05-04 CONVERT(DECIMAL(18,2),A.PRICE*A.NUM/B.ISANALYZED)*B.ISANALYZED 费用的计算采用单次计算四舍五入后再乘以执行总次数，这样分次冲正就不会出现冲正金额和原总金额不同的情况
--------------------------------------------------------------------------*/
SET NOCOUNT ON

DECLARE @ORDERID UNIQUEIDENTIFIER
DECLARE @FRISTTIMES INT
DECLARE @TERMINALTIMES INT
DECLARE @FREQUENCY VARCHAR(50)
DECLARE @DEPTID BIGINT
DECLARE @DEPTBR BIGINT --ADD BY TANY 2005-08-30 病人所在科室
DECLARE @DEPTLY BIGINT --ADD BY TANY 2005-12-11 领药科室
DECLARE @WARDID CHAR(4)
DECLARE @EXEDEPT BIGINT
DECLARE @NTYPE INT  	
DECLARE @BEGINEXEDATE DATETIME
DECLARE @STOPEXEDATE DATETIME
DECLARE @STATUS_FLAG INT
DECLARE @HOITEMID BIGINT
DECLARE @ITEMCODE VARCHAR(50)
DECLARE @XMLY INT --1药品2项目3物资
DECLARE @CFH DECIMAL(21,6)
DECLARE @EXECBOOKDATE DATETIME 
DECLARE @EXENUM0 INT
DECLARE @EXENUM INT
DECLARE @CYCLEDAY INT --循环天数
DECLARE @CYCLELX INT --循环类型 1=周期执行2=星期执行
DECLARE @ZXR INT --执行日 @CYCLELX=2 时 1=星期日2=星期一3=星期二4=星期三5=星期四6=星期五7=星期六
DECLARE @EXECID UNIQUEIDENTIFIER
DECLARE @NUM DECIMAL(18,3)
DECLARE @ADDFEEID BIGINT
DECLARE @MNGTYPE2 INT --MNGTYPE=5使用
DECLARE @ORDERUNIT VARCHAR(10) --ADD BY TANY 2007-10-29 增加医嘱单位判断单位是不是改变
DECLARE @NOWUNIT VARCHAR(10)--当前单位
DECLARE @ISKDKSLY SMALLINT --是否开单科室领药
DECLARE @GCYS BIGINT --Modify By Tany 2009-12-23 增加管床医生
DECLARE @ts int --add by zouchihua 临时医嘱天数
DECLARE @tempPl int --add by zouchihua 临时医嘱频率
declare @num_new int ---add yaokx 2014-05-22 附加费用每日执行一次
declare @cfg7198 int --add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
declare @hditem_id int ---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
declare @retail_price DECIMAL(18,3)---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
declare @num_fj int ---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
declare @hditem_id1 int ---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
declare @retail_price1 DECIMAL(18,3)---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
declare @num_fj1 int ---add yaokx 2014-05-29 附加费用每日执行一次,剩下的转为续加费用
declare @glxmid int ---add yaokx 2014-05-29 
declare @jd int ---add yaokx 2014-05-29 
declare @xd int---add yaokx 2014-05-29 
declare @cfg7199 varchar(100) ---add yaokx 2014-05-29 
declare @cfg7200 varchar(100)---add yaokx 2014-05-29 
--药品游标使用
DECLARE @TMED_DWLX INT
DECLARE @TMED_NUM DECIMAL(18,3)
DECLARE @TMED_XMLY BIGINT
DECLARE @TMED_EXEC_DEPT BIGINT
DECLARE @TMED_DEPT_ID BIGINT
DECLARE @TMED_MNGTYPE INT
DECLARE @TMED_JZ_FLAG INT
DECLARE @TMED_ID UNIQUEIDENTIFIER
DECLARE @TMED_ORDER_ID UNIQUEIDENTIFIER
DECLARE @TMED_DEPT_BR BIGINT
DECLARE @TMED_ORDER_DOC BIGINT
DECLARE @TMED_HOITEM_ID BIGINT
DECLARE @TMED_ITEM_CODE VARCHAR(50)
DECLARE @TMED_ORDER_SPEC VARCHAR(50) 
DECLARE @TMED_DOSAGE INT
DECLARE @TMED_ORDER_CONTEXT VARCHAR(100)
DECLARE @TMED_NTYPE INT --Add By Tany 2010-07-21 药品的NTYPE可能不一样
DECLARE @TMED_STATCODE varchar(10)  --Add By Zouchihua 2012-07-11 重新获得统计大项目
DECLARE @TEMD_TLFL varchar(10) --Add By Tany 2014-11-24 统领分类
--药品计算使用
DECLARE @TMP_GGID INT
DECLARE @TMP_CJID INT
DECLARE @TMP_YL DECIMAL(10,1)
DECLARE @TMP_UNIT VARCHAR(10)
DECLARE @TMP_PRICE DECIMAL(10,4)
DECLARE @TMP_SDVALUE DECIMAL(10,2)
DECLARE @TMP_YDWBL INT
DECLARE @TMP_ZXKSID INT
DECLARE @TMP_BDELETE SMALLINT
DECLARE @TMP_KCL DECIMAL(15,2) --Add By Tany 2011-03-22 增加计算出的库存量
DECLARE @TMP_YLKC DECIMAL(15,2) --Add By Tany 2011-03-28 增加计算出的用量库存
--医技游标使用
DECLARE @YJ_EXEC_ID UNIQUEIDENTIFIER
DECLARE @YJ_APP_ID UNIQUEIDENTIFIER
DECLARE @YJ_ORDER_ID UNIQUEIDENTIFIER
DECLARE @YJ_JE DECIMAL(18,2)
--自动冲正使用
DECLARE @O1_ORDER_ID UNIQUEIDENTIFIER
DECLARE @O2_ID UNIQUEIDENTIFIER
DECLARE @O2_ORDEREXEC_ID UNIQUEIDENTIFIER
DECLARE @O2_NUM DECIMAL(18,3) 
DECLARE @O2_UNITRATE INT
DECLARE @O2_TLFL VARCHAR(10)
DECLARE @o2_cjid int
DECLARE @o2_execdept_id int
DECLARE @o2_xmly int
DECLARE @o2_PvsScn int--add by jchl (pivas进仓标志)


DECLARE @MED_CHARGE_BIT INT --科室药品记账标记
DECLARE @TMP_CHARGE_BIT INT

DECLARE @CUREXECDATE DATETIME          --当前医嘱日期
DECLARE @LASTEXECDATE DATETIME     --最后一次执行的医嘱时间
DECLARE @LASTVALIDEXECDATE DATETIME --最后一次有效执行时间 ADD BY TANY 2004-11-18

--自动冲正需要的变量
DECLARE @MAXEXECDATE DATETIME--最大执行日期
DECLARE @TMPCZDATE DATETIME--需要冲正的日期
DECLARE @CZZNUM DECIMAL(18,2)--可以冲正的总数
DECLARE @CZZJE DECIMAL(18,2)--可以冲正的金额 Modify By Tany 2010-05-04
DECLARE @CZNUM DECIMAL(18,2)--冲正数量
DECLARE @ZXCS INT--医嘱已经执行的次数

DECLARE @KCL DECIMAL(18,4)--库存量
DECLARE @NEW_CJID INT --新厂家ID，用于自动更换药品

--病人信息，报错时使用
DECLARE @BED_NO VARCHAR(20)   --床号
DECLARE @PAT_NAME VARCHAR(50) --姓名

DECLARE @MED_NAME VARCHAR(200)--药品名称

DECLARE @EXECTIME VARCHAR(300)
--关于口服和针剂预领药参数 Add By Tany 2009-08-12
DECLARE @ISYL BIT --是否需要预领
DECLARE @KFCS VARCHAR(50) --口服参数
DECLARE @ZJCS VARCHAR(50) --针剂参数
DECLARE @YLSJ VARCHAR(10) --预领时间
DECLARE @YLCS INT --预领次数
DECLARE @TLFL VARCHAR(2) --统领分类
DECLARE @TIMES VARCHAR(5) --领药时间点

--add by zouchihua 
declare @tjdxm_cf varchar(50)--处方发药的统计大项目（除了01，02，03）

--add by jchl 
declare @pvsChkBit smallint --pivas审核标志（0：默认药房   1：pivas药房   2：不能执行）
declare @pvsDept varchar(max) --pivas的启用科室
declare @pvsExeDept BIGINT --药房对应的pivas科室
declare @pvsBit smallint --是否进入pivas标志（0：否  1：是 ）
--declare @isPvsType smallint --未审方医嘱是否符合pivas医嘱条件（0：不符合  1：符合）
declare @pvsType varchar(1) --pivas的审方内容（0长嘱、1临嘱、2长临嘱）
DECLARE @cfg7605 VARCHAR(10)--7605 pivas未审方是否允许执行药品医嘱
SET @cfg7605=(SELECT LTRIM(RTRIM(ISNULL(CONFIG,''))) FROM JC_CONFIG WHERE ID=7605)

declare @isPvsDept int --是否执行科室为pivas，主要用于自动冲账时验证 Modify By Tany 2015-06-03

/*--------暂时只进行药品费用拆分逻辑----------
----------Modify By Tany 2015-01-19-----------
费用拆分其实最主要是将需要拆分的费用，在每次执行
的时候，循环实际执行的数量插入医嘱执行表，然后在
生成处方表时本就会根据执行表记录条数来查找，注意
在处方表数量时需要填写是总数量还是拆分后的数量。
这样改写后，执行、领药、自动冲账都暂时未发现问题
---------------------------------------------*/
declare @cfbz smallint --0=不拆 1=拆分 拆分标志，用于标示是否需要拆分记录 Modify By Tany 2015-01-19
declare @cfcs int --拆分次数，用于记录费用拆分的条数 Modify By Tany 2015-01-91

declare @order_usage varchar(50) --Add By Tany 2015-04-20 增加用法

--add by zouchihua 2014-3-12

declare @zhbj int--记录是否是整合标记
 set @zhbj=0
--医嘱允许执行的时间范围
--DECLARE @NOW DATETIME--当前时间
--DECLARE @BEGINTIME VARCHAR(10)
--DECLARE @ENDTIME VARCHAR(10)

SET @OUTCODE=0
SET @OUTMSG='执行成功！'		

--if convert(datetime,'2010-08-07 23:59:59')>=getdate()
--begin
--SET @OUTCODE=-1
--SET @OUTMSG='系统暂时禁用医嘱执行功能，请等待功能开放后再执行！'	
--RETURN
--end

--不在后台判断了，压力太大
--SET @NOW=GETDATE()
--SET @BEGINTIME=(SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7056)
--SET @ENDTIME=(SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7057)
--
----如果当前时间小于可执行开始时间或者大于可执行结束时间，那么退出
--IF @NOW<CONVERT(DATETIME,DBO.FUN_GETDATE(@NOW)+' '+@BEGINTIME)
--	OR @NOW>CONVERT(DATETIME,DBO.FUN_GETDATE(@NOW)+' '+@ENDTIME)
--BEGIN
--	SET @OUTCODE=-1
--	SET @OUTMSG='医嘱执行有效时间为'+@BEGINTIME+'至'+@ENDTIME+'，请在有效时间范围内执行医嘱！'	
--	RETURN
--END

SET @ISYL=0
SET @YLCS=0
SET @ISKDKSLY=0

set @tjdxm_cf=isnull((select config from JC_CONFIG where id=7132),'')

--add by zouchihua 2014-4-4
declare @zcy_zdsc int
  set @zcy_zdsc=isnull((select config from JC_CONFIG where id=7191),0)

 ---获取参数
	set @cfg7198=isnull((select config from JC_CONFIG where id=7198),'')
	set @cfg7199=isnull((select config from JC_CONFIG where id=7199),'')
	set @cfg7200=isnull((select config from JC_CONFIG where id=7200),'')

--ADD BY TANY 交病人处理
IF @MNGTYPE=1
   SET @MNGTYPE2=5
ELSE
   SET @MNGTYPE2=@MNGTYPE
 --add by zouchihua 交病人  
if	@MNGTYPE=5
    SET @MNGTYPE2=1
 
	-------------------add by zouchihua  2014-8-21 使用临时表进行控制
--if exists(	select * from tempdb.dbo.sysobjects where name like '%#temp_zy_orderrecord%')
--     drop table   #temp_zy_orderrecord

--if exists(	select * from tempdb.dbo.sysobjects where name like '%#temp_ZY_ORDEREXEC%')
--     drop table   #temp_ZY_ORDEREXEC
--if exists(	select * from tempdb.dbo.sysobjects where name like '%#ZY_ORDEREXEC%')
--     drop table   #ZY_ORDEREXEC
	SELECT * into #temp_zy_orderrecord FROM ZY_ORDERRECORD
            WHERE GROUP_ID = @GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)
                  AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND DELETE_BIT=0 AND STATUS_FLAG<=5
                  
                   
                 
         SELECT * into #temp_ZY_ORDEREXEC          FROM ZY_ORDEREXEC
    WHERE ORDER_ID  in(select   ORDER_ID from  #temp_zy_orderrecord)
	
	  SELECT * into  #ZY_ORDEREXEC          FROM #temp_ZY_ORDEREXEC
    
	 
	
 
	---------------------------
	--------------------------
	
	
--获得参数  科室药品是否直接记账
IF (SELECT CONFIG FROM JC_CONFIG WHERE ID=7018)='是'
   SET @MED_CHARGE_BIT=1
ELSE
   SET @MED_CHARGE_BIT=0

--|取得医嘱的病人ID，婴儿ID,医嘱号，执行科室，医嘱分类，医嘱频率的执行次数，开始执行时间，医嘱状态，医嘱项目表ID，药品代码，
--|首日执行次数，频率,医嘱类别
SELECT @ORDERID=ORDER_ID,
       @EXEDEPT=EXEC_DEPT, 
       @NTYPE=NTYPE, 
       @EXENUM0=EXECNUM,
       @CYCLEDAY=CYCLEDAY, 
	   @CYCLELX=LX, 
	   @ZXR=ZXR, 
       @BEGINEXEDATE=ORDER_BDATE,
       @STOPEXEDATE=ORDER_EDATE, 
       @STATUS_FLAG=STATUS_FLAG, 
       @HOITEMID=HOITEM_ID,
       @ITEMCODE=ITEM_CODE, 
       @FRISTTIMES=FIRST_TIMES,
       @TERMINALTIMES=TERMINAL_TIMES,
       @FREQUENCY=FREQUENCY,
       @DEPTID=DEPT_ID,
       @WARDID=WARD_ID,
       @DEPTBR=DEPTBR,
       @XMLY=XMLY,
       @BED_NO=BED_NO,
       @PAT_NAME=NAME,
	   @ISKDKSLY=ISKDKSLY,
	   @EXECTIME=EXECTIME,
	   @ts=(case  when ts is null then 1 else ts end),
	   @tempPl= (case  when ts is null then 1 else EXECNUMtmp end),--临时医嘱执行次数
	   @GCYS=CASE WHEN ZY_DOC<=0 OR ZY_DOC IS NULL THEN ORDER_DOC ELSE ZY_DOC END,
	  @zhbj=isnull(zhbj,0) 
	  ,@pvsChkBit=is_PvsChk		--add by jchl
	  ,@order_usage=order_usage --Add By Tany 2015-04-20
FROM (SELECT TOP 1 A.ORDER_ID,A.EXEC_DEPT, A.NTYPE,
        CASE WHEN B.EXECNUM IS NULL OR MNGTYPE IN (1,3,5) THEN 1 ELSE B.EXECNUM END EXECNUM,
        CASE WHEN B.EXECNUM IS NULL THEN 1 ELSE B.EXECNUM END EXECNUMtmp,
        CASE WHEN B.CYCLEDAY IS NULL THEN 1 ELSE B.CYCLEDAY END CYCLEDAY,
		CASE WHEN B.LX IS NULL THEN 1 ELSE B.LX END LX,
		CASE WHEN B.ZXR IS NULL THEN 1234567 ELSE B.ZXR END ZXR,
        A.ORDER_BDATE, A.ORDER_EDATE, A.STATUS_FLAG,
		A.HOITEM_ID, ITEM_CODE,
		CASE WHEN A.FIRST_TIMES > CASE WHEN B.EXECNUM IS NULL THEN 1 ELSE B.EXECNUM END
		THEN CASE WHEN B.EXECNUM IS NULL THEN 1 ELSE B.EXECNUM END
		ELSE A.FIRST_TIMES END AS FIRST_TIMES,--Modify By Tany 2010-09-02
		CASE WHEN A.TERMINAL_TIMES > CASE WHEN B.EXECNUM IS NULL THEN 1 ELSE B.EXECNUM END
		THEN CASE WHEN B.EXECNUM IS NULL THEN 1 ELSE B.EXECNUM END
		ELSE A.TERMINAL_TIMES END AS TERMINAL_TIMES,
		LTRIM(RTRIM(B.EXECTIME)) EXECTIME,--Modify By Tany
		A.FREQUENCY, A.DEPT_ID,C.WARD_ID,C.DEPT_ID DEPTBR,A.XMLY,
		C.BED_NO,C.NAME,A.UNIT,A.DWLX,A.ISKDKSLY,C.ZY_DOC,A.ORDER_DOC,A.ts,a.zhbj
		,a.is_PvsChk	--add by jchl
		,a.ORDER_USAGE  --Add By Tany 2015-04-20
      FROM #temp_zy_orderrecord  A
      INNER JOIN VI_ZY_VINPATIENT_BED C ON A.INPATIENT_ID=C.INPATIENT_ID AND A.BABY_ID=C.BABY_ID --病人所在科室、病区判断病人信息表最准确
      LEFT JOIN JC_FREQUENCY B
      ON UPPER(A.FREQUENCY)=UPPER(B.NAME) ORDER BY A.EXEC_DEPT DESC) TMP

--Modify By Tany 2015-04-20 提到前面
--Modify by jchl 2015-03-13 pivas逻辑判断
--@pvsChkBit 为0走默认流程，为1走pivas流程，为2拒绝执行
set @pvsBit=0
--set @isPvsType=0
if(@XMLY=1 and @NTYPE in (1,2) and exists(select 1 from JC_DEPT_DRUGSTORE where DEPT_ID=@DEPTBR and is_pvsrel=1 and  DELETE_BIT=0 ))
begin
	--得到领药科室对应的pivas药房(一个科室不可对应多个pivas)
	--select @pvsExeDept=pvs_Dpt from jc_pvs_YfDpt where yf_dpt=@DEPTBR 
	--该领药科室启用了pivas
	select top 1 @pvsExeDept=DRUGSTORE_ID from JC_DEPT_DRUGSTORE where DEPT_ID=@DEPTBR and is_pvsrel=1 and  DELETE_BIT=0 
	
	if(@pvsChkBit=2)
	BEGIN
		SET @OUTCODE=-1
		SET @OUTMSG='该医嘱pivas审方未通过，请通知医生停嘱！'	
		RETURN
	END
	--1、先判断该领药科室是否进入pivas管理（JC_DEPT_DRUGSTORE）  2、判断医嘱审方标记    3、判断pivas的审方内容（0长嘱、1临嘱、2长临嘱）7602
	select @pvsType=rtrim(ltrim(config)) from JC_CONFIG where id=7602 --3、判断pivas的审方内容（0长嘱、1临嘱、2长临嘱）7602
	--这里要判断用法，还要判断一下这一组是否有多个医嘱，才进pivas Modify By Tany
	--该医嘱是否符合pivas条件   (处理未审方医嘱)
	if((@pvsType='0' and @MNGTYPE=0) 
		or (@pvsType='1' and @MNGTYPE in (1))
		or (@pvsType='2' and @MNGTYPE in (0,1)))--Modify By Tany 2015-04-20 类型为5的暂时不管
		and @order_usage in (select name from VI_pivas_Orderusage) --Modify By tany 2015-04-20 增加用法过滤
		and (select count(1) from #temp_zy_orderrecord where INPATIENT_ID=@INPATIENTID and @BABYID=@BABYID and GROUP_ID=@GROUPID)>1 --同一组的医嘱数量要大于1条医嘱
		and (select count(1) from #temp_zy_orderrecord where INPATIENT_ID=@INPATIENTID and @BABYID=@BABYID and GROUP_ID=@GROUPID and (HOITEM_ID<=0 or EXEC_DEPT<=0))<=0 --同一组里面不能有自备药
	begin
		/******************在之前就要验证库存，如果有一个药的库存不能通过，则这组药就不能去pivas***************************/
		DECLARE TMED1_CURSOR CURSOR FOR
		SELECT A.ORDER_ID,A.DEPT_ID,A.DEPT_BR,@pvsExeDept,--A.EXEC_DEPT, Modify By Tany 2015-04-20 如果是pivas并且不是第一天的医嘱，则转向pivas药房
		   case when @MNGTYPE in(1,5) then isnull(A.zsl,a.num) else A.NUM end ,  --Modify by zouchihua 2012-6-21 单位类型
		   A.HOITEM_ID,A.ITEM_CODE,A.XMLY,A.DWLX, case when @MNGTYPE in(1,5) then isnull(a.zsldw,a.unit) else A.UNIT end, --Modify by zouchihua 2012-6-21 单位类型
		   A.ORDER_SPEC, A.DOSAGE ,A.MNGTYPE,A.JZ_FLAG,A.ORDER_CONTEXT,A.NTYPE--TLFL Add By Tany 2014-11-24
		FROM (SELECT * FROM #temp_zy_orderrecord WHERE DELETE_BIT=0 AND EXEC_DEPT>0  --没有执行科室的药品不产生记录 MODIFY BY TANY 2005-09-25
				AND GROUP_ID = @GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)
				AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND HOITEM_ID>0) A
   
		OPEN TMED1_CURSOR

		FETCH TMED1_CURSOR INTO @TMED_ORDER_ID,@TMED_DEPT_ID,@TMED_DEPT_BR,@TMED_EXEC_DEPT,
							   @TMED_NUM,@TMED_HOITEM_ID,@TMED_ITEM_CODE,@TMED_XMLY,
							   @TMED_DWLX,@ORDERUNIT,@TMED_ORDER_SPEC,@TMED_DOSAGE,@TMED_MNGTYPE,
							   @TMED_JZ_FLAG,@TMED_ORDER_CONTEXT,@TMED_NTYPE
		WHILE @@FETCH_STATUS=0
		BEGIN--WHILE
		
			set @NOWUNIT='' --Add By Tany 2015-04-20 清空单位，因为没找到数据时，会默认上一条医嘱的单位
			--判断药品的单位是否发生变化 ADD BY TANY 2007-10-29
			IF @TMED_DWLX=1
				SELECT @NOWUNIT=B.DWMC,@KCL=A.KCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.HLDW=B.ID WHERE CJID=@TMED_HOITEM_ID AND @TMED_XMLY=1 AND DEPTID=@TMED_EXEC_DEPT
			ELSE IF @TMED_DWLX=2
				SELECT @NOWUNIT=B.DWMC,@KCL=A.KCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.BZDW=B.ID WHERE CJID=@TMED_HOITEM_ID AND @TMED_XMLY=1 AND DEPTID=@TMED_EXEC_DEPT
			ELSE IF @TMED_DWLX=3
				SELECT @NOWUNIT=B.DWMC,@KCL=A.KCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.YPDW=B.ID WHERE CJID=@TMED_HOITEM_ID AND @TMED_XMLY=1 AND DEPTID=@TMED_EXEC_DEPT
			ELSE IF @TMED_DWLX=4
				SELECT @NOWUNIT=B.DWMC,@KCL=A.KCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.ZXDW=B.ID WHERE CJID=@TMED_HOITEM_ID AND @TMED_XMLY=1 AND DEPTID=@TMED_EXEC_DEPT
        
			--增加判断 Modify By Tany 2015-04-20
			IF @NOWUNIT=''
			BEGIN
				set @pvsBit=0
				break
			END
			IF LTRIM(RTRIM(@NOWUNIT))<>LTRIM(RTRIM(@ORDERUNIT))
			BEGIN
				set @pvsBit=0
				break
			END
			--只判断库存是不是为0，为0才不允许去pivas Modify BY Tany 2015-04-22
			IF ISNULL(@KCL,0)<=0
			BEGIN
				set @pvsBit=0
				break
			END

			/* Modify By Tany 2015-04-22 暂时屏蔽，不需要这么复杂的验证
			CREATE TABLE #TMPMED1
			(
			 GGID BIGINT,
			 CJID BIGINT,
			 YL DECIMAL(18,1),
			 UNIT VARCHAR(10),
			 PRICE DECIMAL(18,4),
			 SDVALUE DECIMAL(18,3),
			 YDWBL INT,
			 ZXKSID BIGINT,
			 PFJ DECIMAL(18,4),
			 PFJE DECIMAL(18,3),
			 KCL DECIMAL(15,2),
			 BDELETE SMALLINT,
			 YLKC DECIMAL(15,2) --用量库存 Add By Tany 2011-03-28
			)

			--调用药品计算SP返回结果集。
			INSERT INTO #TMPMED1
			EXEC SP_FUN_DW_NUM @TMED_DWLX,@TMED_NUM,1,1,1,@TMED_HOITEM_ID,@TMED_EXEC_DEPT,0
			IF @@ERROR<>0            
			BEGIN            
				set @pvsBit=0
				break           
			END

			SELECT @TMP_GGID=GGID,
				   @TMP_CJID=CJID,
				   @TMP_YL=YL,
				   @TMP_UNIT=UNIT,
				   @TMP_PRICE=PRICE,
				   @TMP_SDVALUE=SDVALUE,
				   @TMP_YDWBL=YDWBL,
				   @TMP_ZXKSID=ZXKSID,
				   @TMP_BDELETE=BDELETE,
				   @TMP_KCL=isnull(KCL,0), --Add By Tany 2011-03-22 Modify By Tany 2015-04-20 如果为null则为0
				   @TMP_YLKC=isnull(YLKC,0) --Add By Tany 2011-03-28 Modify By Tany 2015-04-20 如果为null则为0
			FROM #TMPMED1

			DROP TABLE #TMPMED1

			--如果药品规格=0 MODIFY BY TANY 2006-12-11 药品数量或单价计算错误，回滚退出 ADD BY TANY 2006-03-16
			IF @TMP_GGID=0 OR @TMP_YL=0 OR @TMP_BDELETE=1
			BEGIN
				set @pvsBit=0
				break
			END
      
			--药品数量判断 ADD BY TANY 2007-08-30
			SET @KCL=@TMP_YLKC--Modify By Tany 2011-03-28 不再重复计算，使用过程计算出的用量库存量(SELECT KCL FROM YF_KCMX WHERE CJID=@TMED_HOITEM_ID AND DEPTID=@TMED_EXEC_DEPT AND BDELETE=0)
			IF @TMP_YL*@EXENUM0*@TMED_DOSAGE>@KCL --Modify By Tany 2015-04-20 这里执行次数默认为频率的执行次数，不再做计算
			BEGIN
				set @pvsBit=0
				break
			END
			*/

			--如果这些都走完了，则赋值为1
			set @pvsBit=1
			
			FETCH TMED1_CURSOR INTO @TMED_ORDER_ID,@TMED_DEPT_ID,@TMED_DEPT_BR,@TMED_EXEC_DEPT,
					@TMED_NUM,@TMED_HOITEM_ID,@TMED_ITEM_CODE,@TMED_XMLY,
					@TMED_DWLX,@ORDERUNIT,@TMED_ORDER_SPEC,@TMED_DOSAGE,@TMED_MNGTYPE,
					@TMED_JZ_FLAG,@TMED_ORDER_CONTEXT,@TMED_NTYPE
		END--WHILE
		CLOSE TMED1_CURSOR  
		DEALLOCATE TMED1_CURSOR
		/*********************************************/
		if @pvsBit=1
		begin
			set @EXEDEPT=@pvsExeDept
		end
	end
	
	/*
	--else if (@pvsChkBit=1)
	if (@pvsChkBit=1)
	begin
		--判断pivas流程
		--declare @pvsType varchar(1)
		--select @pvsType=rtrim(ltrim(config)) from JC_CONFIG where id=7602 
		if((@pvsType='0' and @MNGTYPE=0) 
			or (@pvsType='1' and @MNGTYPE=1)
			or (@pvsType='2' and (@MNGTYPE=0 or @MNGTYPE=1)))
		begin
				set @EXEDEPT=@pvsExeDept
				set @pvsBit=1
		end
	end
	else if(@pvsChkBit=2)
	BEGIN
		SET @OUTCODE=-1
		SET @OUTMSG='该医嘱pivas审方未通过，请通知医生停嘱！'	
		RETURN
	END
	--@pvsChkBit为0 则不处理
	*/
end

--add by zouchihua 2015-1-20 要放到前来，便于冲正用
	set @cfbz=0
	--是否进行拆分的判断，放在这里
	if @XMLY=1 and @NTYPE in (1,2) and @HOITEMID>0 and @pvsBit=1 --Modify By Tany 2015-04-20 只有pivas的药品才拆分
		--and @MNGTYPE=0 这里由@pvsBit来判断拆哪种类型医嘱
	begin
		set @cfbz=1
	end

--- 手术麻醉 更改dept_br
if (exists (select * from SS_DEPT where DEPTID=@DEPTID) and isnull((select config from JC_CONFIG where id=9010),'')='1' )
    begin
            SELECT @DEPTBR=DEPT_BR FROM #temp_zy_orderrecord
            WHERE GROUP_ID = @GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)
                  AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
    end 



--|没有转抄的医嘱或已经停止的医嘱不发送
IF (@STATUS_FLAG<2  OR  @STATUS_FLAG=5)
   RETURN
	
--临时医嘱、账单
--ADD BY TANY 2006-01-12
IF (@MNGTYPE=1 OR @MNGTYPE=5 OR @MNGTYPE=3)
BEGIN
   --如果已经执行过则不再执行，不管状态如何
   IF EXISTS (SELECT 1 FROM #temp_ZY_ORDEREXEC WHERE ORDER_ID=@ORDERID)
   BEGIN
       --MODIFY BY TANY 2007-08-31 如果临嘱已经执行过但是状态还没有改变，则重新去更新状态
       IF @STATUS_FLAG=2
       BEGIN
	   BEGIN TRAN
   	   GOTO NEXT_DAY
       END
       ELSE
       BEGIN
       	   RETURN
       END
   END
END

--|准备执行医嘱==============================================================================	

--如果开单科室是手术麻醉，则把病区改成手术麻醉
--或者如果是开单科室领药
IF EXISTS (SELECT 1 FROM SS_DEPT WHERE DEPTID=@DEPTID) OR @ISKDKSLY=1
BEGIN
	SET @WARDID=(SELECT WARD_ID FROM JC_WARDRDEPT WHERE DEPT_ID=@DEPTID)
	--获得领药科室
	SET @DEPTLY=(SELECT DEPT_ID FROM JC_WARD WHERE WARD_ID=@WARDID)
END
ELSE
BEGIN
	--获得领药科室
	SET @DEPTLY=(SELECT DEPT_ID FROM JC_WARD WHERE WARD_ID=@WARDID)
	--如果该病人所在科室是单独领药，也需要独立出来
	--Modify By Tany 2009-09-20
	IF EXISTS (SELECT 1 FROM JC_DEPT_TYPE_RELATION WHERE DEPT_ID=@DEPTBR AND TYPE_CODE='009')
	BEGIN
		SET @DEPTLY=@DEPTBR
	END
END

IF @DEPTLY IS NULL
BEGIN
	--Modify By Tany 2009-09-20
	IF @ISKDKSLY=1
		SET @DEPTLY=@DEPTID
	ELSE
		SET @DEPTLY=@DEPTBR
--    SET @OUTCODE=-1
--    SET @OUTMSG='该科室没有设置成病区，请与系统管理员联系！'	
--    RETURN   	
END

--add by zouchihua 2012-12-12 如果@ISKDKSLY=-1 有些特殊治疗科室不需要领药
if @ISKDKSLY=-1
   set @DEPTLY=-1

--|取开始执行日期 = 当前服务器时间 MODIFY BY TANY 2006-03-23
--Modify By Tany 2009-11-06 默认开始时间为医嘱开始时间
SET @CUREXECDATE=@BEGINEXEDATE
declare @Cqyz_zxcs int --add by zouchihua 2012-02-01
declare @zxid UNIQUEIDENTIFIER   --add by zouchihua 2012-02-01
set @Cqyz_zxcs=0;
IF ((@MNGTYPE=0) OR (@MNGTYPE=2))
BEGIN
    SELECT @LASTEXECDATE=MAX(EXECDATE)
    FROM #temp_ZY_ORDEREXEC
    WHERE ORDER_ID = @ORDERID

    SELECT @LASTVALIDEXECDATE=MAX(EXECDATE)
    FROM #temp_ZY_ORDEREXEC
    WHERE ORDER_ID = @ORDERID AND ISANALYZED>0 --取执行次数>0的记录 MODIFY BY TANY 2004-11-18
     --Modify by zouchihua 2012-02-01
    --set @Cqyz_zxcs=ISNULL((select top 1 ISANALYZED from ZY_ORDEREXEC where EXECDATE=@LASTEXECDATE ),0)
    set @Cqyz_zxcs= isnull((select SUM(ISANALYZED) from #temp_ZY_ORDEREXEC where  ORDER_ID=@ORDERID and  CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,EXECDATE)))=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE)))),0)
    
    IF (@LASTEXECDATE IS NOT NULL )  
     begin
         --执行次数小于频次,当前执行时间日期不变 Modify by zouchihua 2012-02-01
         if @Cqyz_zxcs<@EXENUM0 and @BEGINEXEDATE!=@LASTEXECDATE                               --1
           SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
         --日期加一天 Modify by zouchihua 2012-02-01
         else
           SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,1,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
           --如果是出院医嘱等，就
           if @ntype=0
             SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
      end 
    ELSE
        SET @CUREXECDATE=@BEGINEXEDATE
        
    --Modify By Tany 2010-08-30
    --7070长期医嘱执行是否跳过原来未执行日期的医嘱（如1号开的，2号未执行，3号执行时是否执行2号的） 0=不是 1=是
    --暂时屏蔽，不用跳过日期的方式，如果不执行，还是写zy_orderexec表，类似于隔天执行的方式 Modify By tany 2010-09-05
--    IF (SELECT CONFIG FROM JC_CONFIG WHERE ID=7070)='1'
--    BEGIN
--    	SET @EXECBOOKDATE=GETDATE()--Modify By tany 2010-08-30 操作日期就是当前日期
--    	
--    	--如果当天大于应当执行的日期
--    	IF CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECBOOKDATE))>CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) 
--    	BEGIN
--    		--如果当天小于需要执行的日期，那么当前日期从当天开始
--    		IF CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECBOOKDATE))<CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE))
--    		BEGIN
--    			SET @CUREXECDATE=@EXECBOOKDATE
--    		END	
--			ELSE--如果当天大于需要执行的日期，那么则只执行需要执行的日期那天
--			BEGIN
--				SET @CUREXECDATE=@EXECDATE
--			END    			
--    	END
--    END
END
	
--BEGIN            
--    SET @OUTCODE=-1
--    SET @OUTMSG=DBO.FUN_GETDATE(@CUREXECDATE)+DBO.FUN_GETDATE(@EXECDATE)
--    RETURN            
--END

--Add By Tany 2015-04-29 如果医嘱已经停转抄，并且停止日期大于执行日期，则将执行日期调整到停止日期那天
--这样做可以避免提前停医嘱时，护士需要选择到停日期那天执行的麻烦
--这个要放在下面这句话之前
IF 1=1
BEGIN
	IF @STATUS_FLAG=4 AND CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE)) < CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE))
	BEGIN
		SET @EXECDATE = CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE))
	END
END

--在今天执行医嘱以后再次执行这组医嘱，判断一下是否需要停止
--ADD BY TANY 2004-10-05
--执行时间已经大于等于停止时间的才判断
--MODIFY BY TANY 2006-03-23
IF (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) > CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE))--不需要大于执行时间，只需要大于停止日期就行 Modify By Tany 2009-11-10  |CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE)) 
    AND @STATUS_FLAG=4 AND CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE)) >= CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE)))
BEGIN
   BEGIN TRAN
   GOTO NEXT_DAY
END

--Add By Tany 2009-08-12
--是否使用预领药功能
IF (SELECT CONFIG FROM JC_CONFIG WHERE ID=7052)='1'
BEGIN
	--循环开始前先看看是否需要预领药，如果需要，那么执行时间+1天
	--如果是药品，并且是长嘱
	IF @XMLY=1 AND @MNGTYPE=0
	BEGIN
		SET @TLFL = (SELECT LTRIM(RTRIM(ISNULL(TLFL,'00'))) FROM VI_YP_YPCD A WHERE A.CJID=@HOITEMID)
		SET @KFCS = (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7048) --口服参数
		--如果口服参数不等于空并且统领分类在参数范围内
		IF @KFCS <> '' AND CHARINDEX(@TLFL,@KFCS) > 0
		BEGIN
			SET @YLSJ = (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7049) --预领时间
			IF @YLSJ <> '' AND @EXECTIME <> ''
			BEGIN
				--如果领药时间有/，则有多条，循环取值
				WHILE CHARINDEX('/',@EXECTIME) > 0
				BEGIN
					SET @TIMES = SUBSTRING(@EXECTIME,1,5)
					IF @TIMES = '24:00'
					BEGIN
						SET @TIMES = '23:59'
					END
					IF CONVERT(DATETIME,@YLSJ)>=CONVERT(DATETIME,@TIMES)
					BEGIN
						SET @YLCS = @YLCS + 1
						SET @ISYL = 1
					END
					--每次循环截取掉已经判断过的数据
					SET @EXECTIME = SUBSTRING(@EXECTIME,7,LEN(@EXECTIME))
				END
				--如果领药时间没有/，则只有单条，单条判断
				IF @EXECTIME = '24:00'
				BEGIN
					SET @EXECTIME = '23:59'
				END
				IF CONVERT(DATETIME,@YLSJ)>=CONVERT(DATETIME,@EXECTIME)
				BEGIN
					SET @YLCS = @YLCS + 1
					SET @ISYL = 1
				END
			END
		END
		ELSE
		BEGIN
			SET @ZJCS = (SELECT CONFIG FROM JC_CONFIG WHERE ID=7050)--针剂参数
			IF @ZJCS <> '' AND CHARINDEX(@TLFL,@ZJCS) > 0
			BEGIN
				SET @YLSJ = (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7051) --预领时间
				IF @YLSJ <> '' AND @EXECTIME <> ''
				BEGIN
					WHILE CHARINDEX('/',@EXECTIME) > 0
					BEGIN
						SET @TIMES = SUBSTRING(@EXECTIME,1,5)
						IF @TIMES = '24:00'
						BEGIN
							SET @TIMES = '23:59'
						END
						IF CONVERT(DATETIME,@YLSJ)>=CONVERT(DATETIME,@TIMES)
						BEGIN
							SET @YLCS = @YLCS + 1
							SET @ISYL = 1
						END
						SET @EXECTIME = SUBSTRING(@EXECTIME,7,LEN(@EXECTIME))
					END
					IF @EXECTIME = '24:00'
					BEGIN
						SET @EXECTIME = '23:59'
					END
					IF CONVERT(DATETIME,@YLSJ)>=CONVERT(DATETIME,@EXECTIME)
					BEGIN
						SET @YLCS = @YLCS + 1
						SET @ISYL = 1
					END
				END
			END
		END
		IF @YLCS > @EXENUM0
		BEGIN
			SET @YLCS = @EXENUM0
		END
	END
END
--这里需要修改 —————————————————————————————————————————————————————————————————————— 
--最后一次执行的次数大于频率次数
--add by zouchihua 2012-02-01
--如果预领标志=1并且预领次数>0则把执行时间加一天 最后一次执行的次数大于频率次数                                               且不是第一次执行
IF @ISYL = 1 AND @YLCS > 0 --and isnull((select top 1 ISANALYZED from ZY_ORDEREXEC where EXECDATE =@LASTEXECDATE),0)=@EXENUM0 and @BEGINEXEDATE!=@LASTEXECDATE
BEGIN
	SET @EXECDATE = DATEADD(DD,1,@EXECDATE)
END

--循环开始执行整组医嘱
WHILE CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))<=CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE))
BEGIN--WHILE
--每次循环作为一个事务
BEGIN TRAN

	--|开始执行时间和停止时间的判断	
	IF (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) < CONVERT(DATETIME,DBO.FUN_GETDATE(@BEGINEXEDATE)))
        BEGIN
	    GOTO NEXT_DAY  
	END

    --|执行次数的确定
    SET @EXENUM=@EXENUM0
	IF (@MNGTYPE=0 OR @MNGTYPE=2)
    BEGIN
	    --先判断末次，如果当天开当天停判断末次        
	    IF (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) = CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE)) AND @STATUS_FLAG=4) --MODIFY BY TANY 2005-03-16 护士站确实已经转抄了
        BEGIN
	        --|如果为最后一次执行医嘱（长期医嘱或长期账单） ,执行次数为末日执行次数
	          if @LASTEXECDATE=@STOPEXEDATE --上次执行时间为停止时间
	           set @EXENUM=@TERMINALTIMES-@Cqyz_zxcs
	          else
	           SET @EXENUM=@TERMINALTIMES
	         if @EXENUM<0
	           set @EXENUM=0
        END
	    ELSE IF (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) = CONVERT(DATETIME,DBO.FUN_GETDATE(@BEGINEXEDATE)))
        BEGIN
	        --|如果为第一次执行医嘱（长期医嘱或长期账单） ,执行次数为首日执行次数
	        SET @EXENUM=@FRISTTIMES
        END
		--如果需要预执行，并且执行时间为第一次执行的第二天，执行次数为预领次数
		ELSE IF @ISYL = 1 --AND (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) = CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,1,@BEGINEXEDATE))))
		BEGIN
		    --上次执行日期等于当前日期 ,且不等于循环最后一天 本来执行次数-上次执行的次数
		    if CONVERT(DATETIME,DBO.FUN_GETDATE(@LASTEXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))
		        and  CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE))!=CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))
			    set @EXENUM=@EXENUM0-@Cqyz_zxcs
			else 
			    begin--当前执行时间等于最后一天（循环最后一次）
			     if CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) 
			        begin
			            ---最后一天执行过 最后一天为零
			         if @Cqyz_zxcs>0 and CONVERT(DATETIME,DBO.FUN_GETDATE(@LASTEXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))
			          set @EXENUM=0
			         else --预领药次数
			          set @EXENUM=@YLCS
			        end ---
			      else
			          set @EXENUM=@EXENUM0 
			     end
			 
		END
	    ELSE IF (CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE)) > CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE)) AND @STATUS_FLAG=4) --MODIFY BY TANY 2005-03-16 护士站确实已经转抄了
        BEGIN
	        SET @EXENUM=0
	    END 
	      --如果当前执行时间等于@EXECDATE 且上次执行过
	      ----if CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) 
	      ----    and @Cqyz_zxcs>0
	      ----    SET @EXENUM=0
	          
	    --判断是否跳过执行放在这里
	    --Modify By Tany 2015-04-22 长嘱和长期账单的参数分开
	    IF ((SELECT CONFIG FROM JC_CONFIG WHERE ID=7070)='1' AND @MNGTYPE=0)
			OR ((SELECT CONFIG FROM JC_CONFIG WHERE ID=7804)='1' AND @MNGTYPE=2)
		BEGIN
    		--如果当天小于应当执行的日期并且小于今天，那么当天执行等于无效
    		IF CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))<CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE))
    			AND CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))<CONVERT(DATETIME,DBO.FUN_GETDATE(GETDATE()))
    		BEGIN
    			SET @EXENUM=0
    		END
		END
	END

	--|执行天数的判断
	--|如果是周期执行
	IF @CYCLELX=1
	BEGIN
		--|如果循环天数大于1并且上次有效执行过（也就是说第一次肯定是执行的）并且是长嘱
		IF ((@CYCLEDAY>1) AND (@LASTVALIDEXECDATE IS NOT NULL) AND (@MNGTYPE=0 OR @MNGTYPE=2))
		BEGIN
			IF (DATEDIFF(DD,CONVERT(DATETIME,DBO.FUN_GETDATE(@LASTVALIDEXECDATE)),CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))))<>@CYCLEDAY
			BEGIN
				SET @EXENUM=0
			END
		END--TANY DAY(@CUREXECDATE-@LASTVALIDEXECDATE)<>@CYCLEDAY
	END
	--|如果是星期执行，并且是长嘱（临嘱判断星期没有含义）
	ELSE IF (@CYCLELX=2 AND (@MNGTYPE=0 OR @MNGTYPE=2))
	BEGIN
		IF (CHARINDEX(CONVERT(VARCHAR,DATEPART(WEEKDAY,@CUREXECDATE)),CONVERT(VARCHAR,@ZXR))=0)
		BEGIN
			SET @EXENUM=0
		END
	END

    --CFH
    SET @CFH=CONVERT(DECIMAL(21,6),CONVERT(VARCHAR,GETDATE(),112)+CONVERT(VARCHAR,DATEPART(HH,GETDATE()))+CONVERT(VARCHAR,DATEPART(MI,GETDATE()))+CONVERT(VARCHAR,DATEPART(SS,GETDATE()))+'.'+CONVERT(VARCHAR,DATEPART(MS,GETDATE())))

	--|事先得到一个数据库唯一的时间戳
    SET @EXECBOOKDATE=GETDATE()--Modify By tany 2010-08-30 操作日期就是当前日期
	
	declare @order_execid  UNIQUEIDENTIFIER
	set @order_execid=DBO.FUN_GETGUID(NEWID(),GETDATE())
	
	--------先插入到临时表
	--清空表里数据
	 delete from #ZY_ORDEREXEC
	
	-----tany 2015-01-19 费用拆分修改，这里循环插入-------
	--拆分标志放到前面赋值，这里屏蔽 Modify By Tany 2015-04-20
	--set @cfbz=0
	----是否进行拆分的判断，放在这里
	--if @XMLY=1 and @NTYPE in (1,2) and @HOITEMID>0
	--	and @MNGTYPE=0
	--begin
	--	set @cfbz=1
	--end
	set @cfcs=(case when @cfbz=1 and @XMLY=1 and @EXENUM>0 then 1 else @EXENUM end)
	while @cfcs<=@EXENUM
	begin
		INSERT INTO #ZY_ORDEREXEC (ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh)--Modify by jchl （频率拆分序号逻辑加入）
		--SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@EXECBOOKDATE, ORDER_ID,@EXEUSER,@CUREXECDATE,@EXENUM ,@CFH,@INPATIENTID,@BABYID,@JGBM
		SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@EXECBOOKDATE, ORDER_ID,@EXEUSER,@CUREXECDATE,(case when @cfbz=1 and @XMLY=1 and @EXENUM>0 then 1 else @EXENUM end),@CFH,@INPATIENTID,@BABYID,@JGBM,(case when @cfbz=1 and @XMLY=1 and @EXENUM>0 then @cfcs else -1 end)  --Modify by jchl （频率拆分序号逻辑加入）
		FROM #temp_zy_orderrecord
		WHERE INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND GROUP_ID=@GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2) AND DELETE_BIT=0
		-----tany 2015-01-19-----------------------------
		IF @@ROWCOUNT=0
		BEGIN
			SET @OUTCODE=-1
			SET @OUTMSG='插入医嘱执行表没有数据，请检查！'	
			ROLLBACK TRAN
			RETURN   	
		END
		set @cfcs=@cfcs+1
    end
	--------------------
    --|将这一组医嘱的医嘱ID、事先得到一个数据库唯一的时间戳、次数， 一起放入到医嘱执行表
    INSERT INTO ZY_ORDEREXEC (ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh)--Modify by jchl （频率拆分序号逻辑加入）
    select   ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh from  #ZY_ORDEREXEC
   IF @@ROWCOUNT=0
    BEGIN
	    SET @OUTCODE=-1
	    SET @OUTMSG='插入医嘱执行表没有数据，请检查！'	
	    ROLLBACK TRAN
	    RETURN   	
    END
    -------------同时要插入临时表
      INSERT INTO #temp_ZY_ORDEREXEC (ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh)--Modify by jchl （频率拆分序号逻辑加入）
    select   ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh from  #ZY_ORDEREXEC
   --------------- 
	IF @@ROWCOUNT=0
    BEGIN
	    SET @OUTCODE=-1
	    SET @OUTMSG='插入医嘱执行表没有数据，请检查！'	
	    ROLLBACK TRAN
	    RETURN   	
    END
	IF @@ERROR<>0            
	BEGIN            
	    SET @OUTCODE=@@ERROR
	    SET @OUTMSG='插入医嘱执行表出错！'
	    ROLLBACK TRAN
	    RETURN            
	END

	UPDATE ZY_ORDERRECORD SET LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER
    WHERE INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND GROUP_ID=@GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2) AND DELETE_BIT=0
   
   ----add by zouchihua 2014 同事更新临时表
  UPDATE   #temp_zy_orderrecord  set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER
    WHERE INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND GROUP_ID=@GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2) AND DELETE_BIT=0
  -------    
	IF @@ERROR<>0            
	BEGIN            
	    SET @OUTCODE=@@ERROR
	    SET @OUTMSG='更新医嘱表执行时间出错！'
	    ROLLBACK TRAN
	    RETURN            
	END

    --|如果是大于停止时间或在执行的周期之间，则只写ZY_ORDEREXEC，但次数为空。
    IF  @EXENUM=0
        GOTO NEXT_DAY

    --|已时间戳为索引，遍厉医嘱执行表，得到要插入的处方表的记录
    --|药需要循环算数量和价格 MODIFY BY TANY 2005-09-11
    IF @NTYPE<=3 AND @NTYPE<>0 AND @XMLY=1 AND @HOITEMID>0
    BEGIN
    DECLARE TMED_CURSOR CURSOR FOR
    SELECT B.ID,A.ORDER_ID,A.DEPT_ID,A.DEPT_BR,case when @pvsBit=1 and DATEDIFF(DAY,a.order_bdate,B.EXECDATE)>=1 then @EXEDEPT else A.EXEC_DEPT end,--A.EXEC_DEPT, Modify By Tany 2015-04-20 如果是pivas并且不是第一天的医嘱，则转向pivas药房
       A.ORDER_DOC,case when @MNGTYPE in(1,5) then isnull(A.zsl,a.num) else A.NUM end ,  --Modify by zouchihua 2012-6-21 单位类型
	   A.HOITEM_ID,A.ITEM_CODE,A.XMLY,A.DWLX, case when @MNGTYPE in(1,5) then isnull(a.zsldw,a.unit) else A.UNIT end, --Modify by zouchihua 2012-6-21 单位类型
	   A.ORDER_SPEC, A.DOSAGE ,A.MNGTYPE,A.JZ_FLAG,A.ORDER_CONTEXT,A.NTYPE,c.STATITEM_CODE,c.TLFL--TLFL Add By Tany 2014-11-24
    FROM (SELECT * FROM #temp_zy_orderrecord WHERE DELETE_BIT=0 AND EXEC_DEPT>0  --没有执行科室的药品不产生记录 MODIFY BY TANY 2005-09-25
			AND GROUP_ID = @GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)
			AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND HOITEM_ID>0) A
    INNER JOIN
    (SELECT * FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE) B
    ON A.ORDER_ID=B.ORDER_ID
    left join VI_YP_YPCD c on A.HOITEM_ID=c.cjid --add by zouchiua 2012-7-11 获得统计大项目
   
    OPEN TMED_CURSOR

    FETCH TMED_CURSOR INTO @TMED_ID,@TMED_ORDER_ID,@TMED_DEPT_ID,@TMED_DEPT_BR,@TMED_EXEC_DEPT,
                           @TMED_ORDER_DOC,@TMED_NUM,@TMED_HOITEM_ID,@TMED_ITEM_CODE,@TMED_XMLY,
                           @TMED_DWLX,@ORDERUNIT,@TMED_ORDER_SPEC,@TMED_DOSAGE,@TMED_MNGTYPE,
						   @TMED_JZ_FLAG,@TMED_ORDER_CONTEXT,@TMED_NTYPE,@TMED_STATCODE,@TEMD_TLFL --Add By Tany 2010-07-21 药品的NTYPE可能不一样 2014-11-24 增加统领分类
    WHILE @@FETCH_STATUS=0
    BEGIN--WHILE
		
		set @NOWUNIT='' --Add By Tany 2015-04-20 清空单位，因为没找到数据时，会默认上一条医嘱的单位
		--判断药品的单位是否发生变化 ADD BY TANY 2007-10-29
		IF @TMED_DWLX=1
			SELECT @NOWUNIT=B.DWMC FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.HLDW=B.ID WHERE CJID=@TMED_HOITEM_ID AND @TMED_XMLY=1 AND DEPTID=@TMED_EXEC_DEPT
		ELSE IF @TMED_DWLX=2
			SELECT @NOWUNIT=B.DWMC FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.BZDW=B.ID WHERE CJID=@TMED_HOITEM_ID AND @TMED_XMLY=1 AND DEPTID=@TMED_EXEC_DEPT
		ELSE IF @TMED_DWLX=3
			SELECT @NOWUNIT=B.DWMC FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.YPDW=B.ID WHERE CJID=@TMED_HOITEM_ID AND @TMED_XMLY=1 AND DEPTID=@TMED_EXEC_DEPT
		ELSE IF @TMED_DWLX=4
			SELECT @NOWUNIT=B.DWMC FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.ZXDW=B.ID WHERE CJID=@TMED_HOITEM_ID AND @TMED_XMLY=1 AND DEPTID=@TMED_EXEC_DEPT
        
		--增加判断 Modify By Tany 2015-04-20
		IF @NOWUNIT=''
        BEGIN
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 该种药品:'+RTRIM(@TMED_ORDER_CONTEXT)+'(CJID='+CONVERT(VARCHAR,@TMED_HOITEM_ID)+')在【'+dbo.fun_getDeptname(@TMED_EXEC_DEPT)+'】没有找到库存信息，请重新开立医嘱！'
		    CLOSE TMED_CURSOR  
	    	DEALLOCATE TMED_CURSOR
		    ROLLBACK TRAN
		    RETURN 
		END
		IF LTRIM(RTRIM(@NOWUNIT))<>LTRIM(RTRIM(@ORDERUNIT))
        BEGIN
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 该种药品:'+RTRIM(@TMED_ORDER_CONTEXT)+'(CJID='+CONVERT(VARCHAR,@TMED_HOITEM_ID)+')的单位('+LTRIM(RTRIM(@NOWUNIT))+')与医嘱的单位('+LTRIM(RTRIM(@ORDERUNIT))+')不同，请重新开立医嘱！'
		    CLOSE TMED_CURSOR  
	    	DEALLOCATE TMED_CURSOR
		    ROLLBACK TRAN
		    RETURN 
		END

		CREATE TABLE #TMPMED
		(
		 GGID BIGINT,
		 CJID BIGINT,
		 YL DECIMAL(18,1),
		 UNIT VARCHAR(10),
		 PRICE DECIMAL(18,4),
		 SDVALUE DECIMAL(18,3),
		 YDWBL INT,
		 ZXKSID BIGINT,
		 PFJ DECIMAL(18,4),
		 PFJE DECIMAL(18,3),
		 KCL DECIMAL(15,2),
		 BDELETE SMALLINT,
		 YLKC DECIMAL(15,2) --用量库存 Add By Tany 2011-03-28
		)

        --调用药品计算SP返回结果集。
		INSERT INTO #TMPMED
		EXEC SP_FUN_DW_NUM @TMED_DWLX,@TMED_NUM,1,1,1,@TMED_HOITEM_ID,@TMED_EXEC_DEPT,0
		IF @@ERROR<>0            
		BEGIN            
		    SET @OUTCODE=@@ERROR
		    SET @OUTMSG='插入临时表药品计算信息出错！'
		    CLOSE TMED_CURSOR  
	    	    DEALLOCATE TMED_CURSOR
		    ROLLBACK TRAN
		    RETURN            
		END

		SELECT @TMP_GGID=GGID,
		       @TMP_CJID=CJID,
		       @TMP_YL=YL,
		       @TMP_UNIT=UNIT,
		       @TMP_PRICE=PRICE,
		       @TMP_SDVALUE=SDVALUE,
		       @TMP_YDWBL=YDWBL,
		       @TMP_ZXKSID=ZXKSID,
			   @TMP_BDELETE=BDELETE,
			   @TMP_KCL=isnull(KCL,0), --Add By Tany 2011-03-22 Modify By Tany 2015-04-20 如果为null则为0
			   @TMP_YLKC=isnull(YLKC,0) --Add By Tany 2011-03-28 Modify By Tany 2015-04-20 如果为null则为0
        FROM #TMPMED

		DROP TABLE #TMPMED

		--如果药品规格=0 MODIFY BY TANY 2006-12-11 药品数量或单价计算错误，回滚退出 ADD BY TANY 2006-03-16
		IF @TMP_GGID=0 OR @TMP_YL=0 OR @TMP_BDELETE=1
        BEGIN
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 的医嘱 '+RTRIM(@TMED_ORDER_CONTEXT)+'(CJID='+CONVERT(VARCHAR,@TMP_CJID)+')，该种药品被禁用或找不到该种药品信息或药品数量计算=0'
		    CLOSE TMED_CURSOR  
	    	DEALLOCATE TMED_CURSOR
		    ROLLBACK TRAN
		    RETURN 
		END


       --add by zouchihua  虚拟库存的判断 2012-02-21
       --参数开启 并且开医嘱时间不等于当前执行的时间
       if isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=6035),0)='1'
           and  (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) != CONVERT(DATETIME,DBO.FUN_GETDATE(@BEGINEXEDATE)))
          begin
               SELECT  @TMP_YLKC=xnKCL FROM YF_KCMX WHERE CJID=@TMED_HOITEM_ID AND DEPTID=@TMED_EXEC_DEPT AND BDELETE=0
               --减虚拟库存
               declare @ypsl decimal(15,3)
               declare @errtext1 varchar(200)  
               declare @errcode1 int  
               set @errtext1='' 
               set @errcode1=-1
               set @ypsl=-1*@TMP_YL*@EXENUM*@TMED_DOSAGE
               EXEC sp_yf_updatekcmx_xnkcl  @TMP_CJID,@ypsl,@TMP_YDWBL,@TMP_ZXKSID,@errcode1 output,@errtext1 output
               if  @errcode1=-1
               begin   
                   set @OUTCODE=-1
                   set @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 的医嘱 '+RTRIM(@TMED_ORDER_CONTEXT)+'减掉虚拟库存时错误:'+@errtext1
                  -- CLOSE TMED_CURSOR  
	    			--DEALLOCATE TMED_CURSOR
					--ROLLBACK TRAN
					--RETURN   不回滚
               end
          end
       
		--Modify By Tany 2009-12-22
		--医嘱执行时是否限制库存量不足的药品不能发送 0=不是 1=是
		IF (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7059)='1'
		BEGIN
			--药品数量判断 ADD BY TANY 2007-08-30
			SET @KCL=@TMP_YLKC--Modify By Tany 2011-03-28 不再重复计算，使用过程计算出的用量库存量(SELECT KCL FROM YF_KCMX WHERE CJID=@TMED_HOITEM_ID AND DEPTID=@TMED_EXEC_DEPT AND BDELETE=0)
			IF @TMP_YL*@EXENUM*@TMED_DOSAGE>@KCL
			BEGIN
				--医嘱执行药品库存量不足时是否自动替换同规格不同厂家有库存的药品 0=不是 1=是
				IF (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7060)='0'
				BEGIN
					SET @OUTCODE=-1
					SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 的医嘱 '+RTRIM(@TMED_ORDER_CONTEXT)+'(CJID='+CONVERT(VARCHAR,@TMP_CJID)+')在【'+dbo.fun_getDeptname(@TMED_EXEC_DEPT)+'】的库存量为：'+CONVERT(VARCHAR,@KCL)+',本次执行数量为：'+CONVERT(VARCHAR,@TMP_YL*@EXENUM*@TMED_DOSAGE)+'，数量不够，不能执行！'
					CLOSE TMED_CURSOR  
	    			DEALLOCATE TMED_CURSOR
					ROLLBACK TRAN
					RETURN 
				END
				ELSE
				BEGIN
					--查找同规格的药品是否有库存，如果有则替换，如果没有，则提示
					declare @xnkcqy int
					set  @xnkcqy=isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=6035),0)
					SELECT TOP 1 @KCL=ISNULL((case when @xnkcqy=0 then KCL else xnkcl end),0), 
						@NEW_CJID=ISNULL(CJID,0)
					FROM YF_KCMX 
					WHERE GGID=@TMP_GGID AND DEPTID=@TMED_EXEC_DEPT AND BDELETE=0
						AND CJID<>@TMED_HOITEM_ID
					ORDER BY KCL DESC

					IF @TMP_YL*@EXENUM*@TMED_DOSAGE>@KCL
					BEGIN
						SET @OUTCODE=-1
						SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 的医嘱 '+RTRIM(@TMED_ORDER_CONTEXT)+'在【'+dbo.fun_getDeptname(@TMED_EXEC_DEPT)+'】 库存量不足，并且没有可以更换的药品，不能执行！'
						CLOSE TMED_CURSOR  
	    				DEALLOCATE TMED_CURSOR
						ROLLBACK TRAN
						RETURN
					END
					ELSE
					BEGIN
						SET @OUTCODE=-1
						SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 的医嘱 '+RTRIM(@TMED_ORDER_CONTEXT)+' 在【'+dbo.fun_getDeptname(@TMED_EXEC_DEPT)+'】因库存量不足，自动更换成同规格不同厂家的药品，请重新执行！'
						CLOSE TMED_CURSOR  
	    				DEALLOCATE TMED_CURSOR
						ROLLBACK TRAN
						--首先回滚原来执行的记录，然后再更新医嘱，需要护士重新执行
						UPDATE ZY_ORDERRECORD SET HOITEM_ID=@NEW_CJID WHERE ORDER_ID=@TMED_ORDER_ID
						---add by zouchihua 2014-8-21 同事更新临时表
						
						UPDATE #temp_zy_orderrecord SET HOITEM_ID=@NEW_CJID WHERE ORDER_ID=@TMED_ORDER_ID
						--------
						
						RETURN
					END
				END
			END
		END
		
		--如果是本科室的药，判断是否直接记账
		IF @TMED_EXEC_DEPT=@DEPTLY
		   SET @TMP_CHARGE_BIT=@MED_CHARGE_BIT
		ELSE
		   SET @TMP_CHARGE_BIT=0
				
		--如果是手术麻醉开的药，直接记账
		IF (SELECT COUNT(1) FROM SS_DEPT WHERE DEPTID=@TMED_DEPT_ID)>0
		   SET @TMP_CHARGE_BIT=1 			   
		
		--如果是出院带药，则直接记账
		IF @TMED_MNGTYPE=5 AND @TMED_JZ_FLAG=1
		   SET @TMP_CHARGE_BIT=1

		--参数控制是否直接记帐
		--MODIFY BY TANY 2007-08-29
		--INSERT INTO JC_CONFIG(ID,CONFIG,NOTE) VALUES('7031','否','药品医嘱是否直接记帐')
		IF (SELECT CONFIG FROM JC_CONFIG WHERE ID=7031)='是'
		   SET @TMP_CHARGE_BIT=1
			
		--如果是大输液，直接记账,武汉中心医院项目 Modify By Tany 2014-11-24
		IF (@TEMD_TLFL='03')
		   SET @TMP_CHARGE_BIT=1
		
		-----tany 2015-01-19 费用拆分修改，这里次数进行判断即可------- 
		INSERT INTO ZY_PRESCRIPTION
			(ID,INPATIENT_ID,BABY_ID,BOOK_DATE,BOOK_USER,
			 PRESC_NO,PRESC_DATE,
			 SOURCE_ID,ORDER_ID,TYPE,
			 DEPT_ID,EXECDEPT_ID,PRESC_DOC,
			 HDITEM_ID,XMLY,STATITEM_CODE,SUBCODE,STANDARD,DOSAGE,                		
			 UNIT,UNITRATE,PRICE,AGIO,
			 NUM,CHARGE_BIT,JGBM)
		VALUES (DBO.FUN_GETGUID(NEWID(),GETDATE()),@INPATIENTID,@BABYID,@EXECBOOKDATE,@EXEUSER,
		        @CFH,@CUREXECDATE,
		        @TMED_ID,@TMED_ORDER_ID,1,
		        @TMED_DEPT_BR,@TMED_EXEC_DEPT,@TMED_ORDER_DOC,
		        @TMED_HOITEM_ID,@TMED_XMLY,@TMED_STATCODE, --Modify by zouchihua 2012-7-11  --CASE @TMED_NTYPE WHEN 1 THEN '01' WHEN 2 THEN '02' WHEN 3 THEN '03' END,--Modify By Tany 2010-07-21 药品的NTYPE可能不一样
				@TMED_ITEM_CODE,'',@TMED_DOSAGE,--@TMED_ORDER_SPEC,@TMED_DOSAGE, Modify By Tany 2010-04-06 不写STANDARD字段，和医嘱表的大小不一致
		        @TMP_UNIT,@TMP_YDWBL,@TMP_PRICE,1,
		        --@TMP_YL*@EXENUM,@TMP_CHARGE_BIT,@JGBM)
		        @TMP_YL*(case when @cfbz=1 and @XMLY=1 and @EXENUM>0 then 1 else @EXENUM end),@TMP_CHARGE_BIT,@JGBM) 

		IF @@ROWCOUNT=0 AND @NTYPE NOT IN (0,6,7)--出院转科、手术、说明不判断是否有记录插入 Modify By Tany 2009-11-07
	    BEGIN
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入处方表药品信息没有数据，请检查！'	
			CLOSE TMED_CURSOR  
	    	DEALLOCATE TMED_CURSOR
		    ROLLBACK TRAN
		    RETURN   	
	    END

		IF @@ERROR<>0            
		BEGIN            
		    SET @OUTCODE=@@ERROR
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入处方表药品信息出错！'
		    CLOSE TMED_CURSOR  
	    	DEALLOCATE TMED_CURSOR
		    ROLLBACK TRAN
		    RETURN            
		END
			
		FETCH TMED_CURSOR INTO @TMED_ID,@TMED_ORDER_ID,@TMED_DEPT_ID,@TMED_DEPT_BR,@TMED_EXEC_DEPT,
               @TMED_ORDER_DOC,@TMED_NUM,@TMED_HOITEM_ID,@TMED_ITEM_CODE,@TMED_XMLY,
               @TMED_DWLX,@ORDERUNIT,@TMED_ORDER_SPEC,@TMED_DOSAGE,@TMED_MNGTYPE,
			   @TMED_JZ_FLAG,@TMED_ORDER_CONTEXT,@TMED_NTYPE,@TMED_STATCODE,@TEMD_TLFL
    END--WHILE
    CLOSE TMED_CURSOR  
    DEALLOCATE TMED_CURSOR 
    END


    --|诊疗项目
    --MODIFY BY TANY 2004-10-24 如果医嘱记录表里面的单价不为0则保存处方表的时候用此单价
    IF (@NTYPE >3 /*OR @NTYPE=0*/ OR @XMLY=2) AND @HOITEMID>0 
    BEGIN
		INSERT INTO ZY_PRESCRIPTION
        (ID,SOURCE_ID,INPATIENT_ID,PRESC_NO,DEPT_ID,EXECDEPT_ID,HDITEM_ID,XMLY,STATITEM_CODE,TCID,TC_FLAG,PRESC_DATE,PRESC_DOC,
		 STANDARD,UNIT,UNITRATE,PRICE,AGIO,NUM,DOSAGE,BABY_ID,SUBCODE,CHARGE_BIT,
		 BOOK_DATE,BOOK_USER,ORDER_ID,TYPE,JGBM
		)
		SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),B.ID,@INPATIENTID,@CFH,A.DEPT_BR,A.EXEC_DEPT,R.HDITEM_ID,A.XMLY,H.BIGITEMCODE,R.TCID,R.TC_FLAG,@CUREXECDATE,A.ORDER_DOC,
			A.ORDER_SPEC,H.UNIT,1,CASE ISNULL(A.PRICE,0) WHEN 0 THEN H.PRICE ELSE A.PRICE END PRICE,1,R.NUM*(case when @MNGTYPE in(1,5) then isnull(A.zsl,a.num) else A.NUM end)*@EXENUM ,--2012-6-21 单位类型
			A.DOSAGE,@BABYID,A.ITEM_CODE,
			CASE WHEN ((A.EXEC_DEPT=A.DEPT_ID) OR (A.EXEC_DEPT<>A.DEPT_ID AND S.ISJZ=1) OR (A.JZ_FLAG=1) OR @NTYPE<>5) THEN 1 ELSE 0 END ,--MODIFY BY TANY 2005-01-14 D2字段如果=1则直接记账 2005-12-14 不是医技项目也直接记账
			@EXECBOOKDATE,@EXEUSER,A.ORDER_ID,1,@JGBM
		FROM (SELECT * FROM #temp_zy_orderrecord WHERE GROUP_ID = @GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)
		      AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND DELETE_BIT=0 AND HOITEM_ID>0  and EXEC_DEPT>0) A  --add by zouchihua  2012-2-29 EXEC_DEPT>0过滤掉执行科室为-1的
		INNER JOIN
		(SELECT ORDER_ID,ID FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE) AS B 
		ON A.ORDER_ID=B.ORDER_ID
		INNER JOIN
		JC_HOI_HDI R
		ON R.HOITEM_ID =A.HOITEM_ID
		INNER JOIN
		VI_JC_ITEMS H
		ON H.ITEMID=R.HDITEM_ID AND H.TCID=R.TCID AND CASE WHEN A.EXEC_DEPT<=0 THEN A.JGBM ELSE DBO.FUN_GETDEPTJGBM(A.EXEC_DEPT) END=H.JGBM--Modify By Tany 2010-07-05 读取执行科室对应机构编码的价格
		LEFT JOIN
		JC_DEPT_PROPERTY S
		ON A.EXEC_DEPT=S.DEPT_ID
                        
                      --执行科室不等于-1
		IF @@ROWCOUNT=0 AND @NTYPE NOT IN (0,6,7)  and @EXEDEPT>0--出院转科、手术、说明不判断是否有记录插入 Modify By Tany 2009-11-07
	    BEGIN
	   
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入处方表没有查询出项目信息，请检查数据！'	
		    ROLLBACK TRAN
		    RETURN   	
	    END

		IF @@ERROR<>0
		BEGIN            
		    SET @OUTCODE=@@ERROR
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入处方表项目信息出错！'
		    ROLLBACK TRAN
		    RETURN            
		END
	END
		 
	--|医嘱附加费用的执行(执行地点为开医嘱所在科室)
    --交病人不收取附加费用 MODIFY BY TANY 2004-11-03
    SELECT @ADDFEEID=COUNT(ID)
    FROM (SELECT * FROM #temp_zy_orderrecord WHERE ORDER_ID=@ORDERID AND DELETE_BIT=0 AND MNGTYPE<>5 AND LTRIM(RTRIM(ORDER_USAGE))<>'') A
    INNER JOIN
    JC_USEAGE_FEE B
    ON A.ORDER_USAGE=B.USE_NAME
   
  
  declare @sffy int 
  set  @sffy=0
	--|如果有附加费用
    IF ((@ADDFEEID IS NOT NULL) AND (@ADDFEEID>=1))
	BEGIN
	SELECT @EXECID=ID
		FROM #temp_ZY_ORDEREXEC
		WHERE EXECDATE=@CUREXECDATE AND ORDER_ID=@ORDERID
	
	---获取xmid是否是静滴，还是续滴
	SELECT @glxmid=B.HSITEM_ID
    FROM (SELECT * FROM #temp_zy_orderrecord WHERE ORDER_ID=@ORDERID AND DELETE_BIT=0 AND MNGTYPE<>5 AND LTRIM(RTRIM(ORDER_USAGE))<>'') A
    INNER JOIN
    JC_USEAGE_FEE B
    ON A.ORDER_USAGE=B.USE_NAME
	
	--初始化默认值
	set @jd=0
	set @xd=0
	set @hditem_id=0
	set @hditem_id1=0
	 IF ((@glxmid IS NOT NULL) AND (@glxmid !=''))
	 begin
		if(CHARINDEX(','+CAST(@glxmid as varchar)+',',','+@cfg7199+',')>0 and  charindex(',',','+@cfg7199+',')>0)
		begin --获取静滴
		  set @jd=substring(@cfg7199,0,charindex(',',@cfg7199))
		  set @xd=substring(@cfg7199,charindex(',',@cfg7199)+1,len(@cfg7199)-charindex(',',@cfg7199)) 
		end
		else
		  begin --获取小儿静滴
	     	 if(CHARINDEX(','+CAST(@glxmid as varchar)+',',','+@cfg7200+',')>0 and  charindex(',',','+@cfg7200+',')>0)
				begin
				  set @jd=substring(@cfg7200,0,charindex(',',@cfg7200))
				  set @xd=substring(@cfg7200,charindex(',',@cfg7200)+1,len(@cfg7200)-charindex(',',@cfg7200))
				end
		  end
	 end
	 
	  
    if(@cfg7198='1' and    @jd!=0 and @xd !=0)
       and ( CHARINDEX(','+CAST(@glxmid as varchar)+',',','+@cfg7199+',')>0 and  charindex(',',','+@cfg7199+',')>0)  
    begin
        set @sffy=1
		if EXISTS(select ACVALUE from ZY_FEE_SPECI(nolock) where INPATIENT_ID=@INPATIENTID and BABY_ID=@BABYID and  DELETE_BIT=0 and 
		(PRESC_DATE >= CONVERT(varchar(100), @CUREXECDATE, 23)+' 00:00:00' and PRESC_DATE < CONVERT(varchar(100), @CUREXECDATE, 23)+' 23:59:59') and XMID=@jd
		group by ACVALUE
		having sum(ACVALUE)>0)--该病人在当天的费用表里是否存在静滴/小儿静滴
		  BEGIN
			set @hditem_id=@xd  --如果存在把所有的静滴附加费用转为续滴的附加费用，这里续滴项目id、价格、数量赋值，数量为执行的次数
			set @retail_price=(select RETAIL_PRICE from JC_HSITEMDICTION where ITEM_ID=@xd and DELETE_BIT=0 and JGBM=@JGBM)
			set @num_fj=@EXENUM   
		  END
		ELSE
		  BEGIN
			set @hditem_id=@jd --如果不存在生成一次的静滴付加费用，例如：开个tid，一天三次，把一次生成静滴附加费用，2次生成续滴附加费用。这里静滴项目id、价格、数量赋值，数量默认为1
			set @retail_price=(select RETAIL_PRICE from JC_HSITEMDICTION where ITEM_ID=@jd and DELETE_BIT=0 and JGBM=@JGBM)
			set @num_fj=1
			
			set @hditem_id1=@xd --如果不存在生成一次的静滴付加费用，例如：开个tid，一天三次，把一次生成静滴附加费用，2次生成续滴附加费用.这里续滴项目id、价格、数量赋值，数量默认为执行次数-1
			set @retail_price1=(select RETAIL_PRICE from JC_HSITEMDICTION where ITEM_ID=@xd and DELETE_BIT=0 and JGBM=@JGBM)
			set @num_fj1=case when @EXENUM<=1 then @EXENUM else @EXENUM-1 end
		if @EXENUM>1 ---当第一次给病人开静滴时候，如果次数<=1，不附加续滴滴附加费用，则反之
		BEGIN
        
		 
		INSERT INTO ZY_PRESCRIPTION
		(ID,SOURCE_ID,INPATIENT_ID,PRESC_NO,DEPT_ID,EXECDEPT_ID,HDITEM_ID,XMLY,STATITEM_CODE,PRESC_DATE,PRESC_DOC,
		 STANDARD,UNIT,UNITRATE,PRICE,AGIO,NUM,DOSAGE,BABY_ID,CHARGE_BIT,BOOK_DATE,BOOK_USER,
		 ORDER_ID,TYPE,JGBM)
	    SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@EXECID,@INPATIENTID,@CFH,A.DEPT_ID,A.DEPT_ID,
	     case when @cfg7198 ='1'  then @hditem_id1 else B.HSITEM_ID end,2,R.STATITEM_CODE,@CUREXECDATE,A.ORDER_DOC,
		   R.ITEM_DESCRIBE,R.ITEM_UNIT,1,case when @cfg7198 ='1'then @retail_price1 else R.RETAIL_PRICE end,1,
		   case when @cfg7198 ='1'then  
		     case when A.MNGTYPE IN (1,5) then  B.NUM*@num_fj1*(@ts*@tempPl) else B.NUM*@num_fj1 end
		    else 
		     case when A.MNGTYPE IN (1,5) then  B.NUM*@EXENUM*(@ts*@tempPl) else B.NUM*@EXENUM end end,
		   
		   1,@BABYID,1,@EXECBOOKDATE,@EXEUSER,
		   @ORDERID,2,A.JGBM                              --Modify by  zouchihua  2012-6-23 临时医嘱附加费用处理
	    FROM (SELECT * FROM #temp_zy_orderrecord WHERE ORDER_ID=@ORDERID AND DELETE_BIT=0) A
            INNER JOIN
            JC_USEAGE_FEE B
            ON A.ORDER_USAGE=B.USE_NAME
            INNER JOIN
            JC_HSITEMDICTION R
            ON B.HSITEM_ID=R.ITEM_ID AND CASE WHEN A.EXEC_DEPT<=0 THEN A.JGBM ELSE DBO.FUN_GETDEPTJGBM(A.EXEC_DEPT) END=R.JGBM
		  END
		END
		 
    end
  
	    INSERT INTO ZY_PRESCRIPTION
		(ID,SOURCE_ID,INPATIENT_ID,PRESC_NO,DEPT_ID,EXECDEPT_ID,HDITEM_ID,XMLY,STATITEM_CODE,PRESC_DATE,PRESC_DOC,
		 STANDARD,UNIT,UNITRATE,PRICE,AGIO,NUM,DOSAGE,BABY_ID,CHARGE_BIT,BOOK_DATE,BOOK_USER,
		 ORDER_ID,TYPE,JGBM)
	    SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@EXECID,@INPATIENTID,@CFH,A.DEPT_ID,A.DEPT_ID,
	     case when @cfg7198 ='1' and @sffy=1 then @hditem_id else B.HSITEM_ID end,2,R.STATITEM_CODE,@CUREXECDATE,A.ORDER_DOC,
		   R.ITEM_DESCRIBE,R.ITEM_UNIT,1,case when @cfg7198 ='1' and @sffy=1 then @retail_price else R.RETAIL_PRICE end,1,
		case when @cfbz!=1 then  ( case 
		      when @cfg7198 ='1' and @sffy=1   then  
		            case when A.MNGTYPE IN (1,5) then  B.NUM*@num_fj*(@ts*@tempPl) else B.NUM*@num_fj end
		    else 
		           case when A.MNGTYPE IN (1,5) then  B.NUM*@EXENUM*(@ts*@tempPl) else B.NUM*@EXENUM end
		    end)  else 1 end,
		   
		   1,@BABYID,1,@EXECBOOKDATE,@EXEUSER,
		   @ORDERID,2,A.JGBM                              --Modify by  zouchihua  2012-6-23 临时医嘱附加费用处理
	    FROM (SELECT * FROM #temp_zy_orderrecord WHERE ORDER_ID=@ORDERID AND DELETE_BIT=0) A
	    INNER JOIN
		(SELECT ORDER_ID,ID FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE) AS Bb 
		ON A.ORDER_ID=Bb.ORDER_ID
            INNER JOIN
            JC_USEAGE_FEE B
            ON A.ORDER_USAGE=B.USE_NAME
            INNER JOIN
            JC_HSITEMDICTION R
            ON B.HSITEM_ID=R.ITEM_ID AND CASE WHEN A.EXEC_DEPT<=0 THEN A.JGBM ELSE DBO.FUN_GETDEPTJGBM(A.EXEC_DEPT) END=R.JGBM--Modify By Tany 2010-07-05 读取执行科室对应机构编码的价格
	   
	  
	   
	    IF @@ROWCOUNT=0 AND @NTYPE NOT IN (0,6,7)--出院转科、手术、说明不判断是否有记录插入 Modify By Tany 2009-11-07
        BEGIN
         
            
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入处方表附加项目信息没有数据，请检查！'	
		    ROLLBACK TRAN
		    RETURN   	
        END

	    IF @@ERROR<>0 
	    BEGIN            
	        SET @OUTCODE=@@ERROR
	        SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入处方表附加项目信息出错！'
	        ROLLBACK TRAN
	        RETURN            
	    END

         -----------------------------ZY_FEE_SPECI---------------------------------
		 set @num_new=isnull((select config from JC_CONFIG where id=7197),'')	
	    --|附加费用没有写PRICE_ID
	    --|附加费用直接使用HSITEM_ID
	    INSERT INTO ZY_FEE_SPECI
		(ID,INPATIENT_ID,BABY_ID,
			ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
			PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
			STATITEM_CODE,XMID,XMLY,
			ITEM_NAME,SUBCODE,UNIT,UNITRATE,
			COST_PRICE,RETAIL_PRICE,
			NUM,DOSAGE,
			SDVALUE,AGIO,ACVALUE,
			CHARGE_BIT,CHARGE_DATE,CHARGE_USER,
			DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
			DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,TYPE,DEPT_LY,JGBM,GCYS
		       )		
	    SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@INPATIENTID,@BABYID,
			@ORDERID,A.SOURCE_ID,A.ID,
			A.PRESC_NO,A.PRESC_DATE,A.BOOK_DATE,A.BOOK_USER,
			R.STATITEM_CODE,A.HDITEM_ID,A.XMLY,
			R.ITEM_NAME,R.STD_CODE,R.ITEM_UNIT,A.UNITRATE,
			A.PRICE,A.PRICE,
			case when @num_new='1' then 1 else A.NUM end,A.DOSAGE,
			--A.PRICE*A.NUM,A.AGIO,A.PRICE*A.NUM,--Modify By Tany 2010-04-30 CONVERT(DECIMAL(18,2),A.PRICE*A.NUM/B.ISANALYZED)*B.ISANALYZED 费用的计算采用单次计算四舍五入后再乘以执行总次数，这样分次冲正就不会出现冲正金额和原总金额不同的情况
			case when @cfg7198='1' then
			CONVERT(DECIMAL(18,2),A.PRICE*(case when @num_new='1' then 1 else A.NUM end)/A.NUM)*A.NUM
			else	
			CONVERT(DECIMAL(18,2),A.PRICE*(case when @num_new='1' then 1 else A.NUM end)/B.ISANALYZED)*B.ISANALYZED end,
			A.AGIO,
			case when @cfg7198='1' then
			CONVERT(DECIMAL(18,2),A.PRICE*(case when @num_new='1' then 1 else A.NUM end)/A.NUM)*A.NUM
			else	
			CONVERT(DECIMAL(18,2),A.PRICE*(case when @num_new='1' then 1 else A.NUM end)/B.ISANALYZED)*B.ISANALYZED end,
			1,GETDATE(),@EXEUSER,
			0,0,0,
			A.PRESC_DOC,@DEPTID,@DEPTBR,A.EXECDEPT_ID,A.TYPE,@DEPTLY,@JGBM,@GCYS
	    FROM (SELECT * FROM ZY_PRESCRIPTION WHERE TYPE=2) A
	    INNER JOIN
	    (SELECT * FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE AND ORDER_ID=@ORDERID) B
	    ON A.SOURCE_ID=B.ID
	    INNER JOIN
	    JC_HSITEMDICTION R
	    ON A.HDITEM_ID=R.ITEM_ID AND A.JGBM=R.JGBM


    --  ------
       
    -- ------ 
	    IF @@ROWCOUNT=0 AND @NTYPE NOT IN (0,6,7)--出院转科、手术、说明不判断是否有记录插入 Modify By Tany 2009-11-07
        BEGIN
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' dd插入费用表附加项目信息没有数据，请检查！'	
		    ROLLBACK TRAN
		    RETURN   	
        END

	    IF @@ERROR<>0 
	    BEGIN            
	        SET @OUTCODE=@@ERROR
	        SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入费用表附加项目信息出错！'
	        ROLLBACK TRAN
	        RETURN            
	    END 	 		
	END

	--|药品
	--|药品需要多填写一些信息
	IF @NTYPE<=3 AND @NTYPE<>0 AND @XMLY=1 AND @HOITEMID>0 AND @EXEDEPT>0
        BEGIN
	    INSERT INTO ZY_FEE_SPECI
		(	ID,INPATIENT_ID,BABY_ID,
			ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
			PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
			STATITEM_CODE,XMID,XMLY,
			ITEM_NAME,SUBCODE,UNIT,UNITRATE,
			COST_PRICE,RETAIL_PRICE,
			NUM,DOSAGE,
			SDVALUE,AGIO,ACVALUE,
			CHARGE_BIT,CHARGE_DATE,CHARGE_USER,
			DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
			DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,
			TLFS,
			DEPT_LY,JGBM,
			GG,CJ,GCYS,ZFBL,--ZFBL Add By Tany 2014-11-24
			FY_BIT,--Add By Tany 2014-11-24 如果是大输液，发药标志为5
			pvs_xh--Add By jchl 2015-04-04 医嘱拆分序号逻辑
		)
	    SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@INPATIENTID,@BABYID,
			C.ORDER_ID,A.SOURCE_ID,A.ID,
			A.PRESC_NO,A.PRESC_DATE,A.BOOK_DATE,A.BOOK_USER,
			A.STATITEM_CODE,A.HDITEM_ID,A.XMLY,  --药品代码
			C.ORDER_CONTEXT,A.SUBCODE,A.UNIT,A.UNITRATE,
			A.PRICE,A.PRICE,
			A.NUM,A.DOSAGE,
			--A.PRICE*A.NUM*A.DOSAGE,A.AGIO,A.PRICE*A.NUM*A.DOSAGE,
			CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,A.AGIO,CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
			--A.CHARGE_BIT, Modify by jchl (pivas大输液药品处理)
			case when @pvsBit=1 and DATEDIFF(DAY,c.order_bdate,B.EXECDATE)>=1 then 0 else A.CHARGE_BIT end,--Modify by jchl 使用pivas科室
			CASE WHEN A.CHARGE_BIT=1 and (@pvsBit=0 or DATEDIFF(DAY,c.order_bdate,B.EXECDATE)=0 ) THEN A.BOOK_DATE ELSE NULL END,
			CASE WHEN A.CHARGE_BIT=1 and (@pvsBit=0 or DATEDIFF(DAY,c.order_bdate,B.EXECDATE)=0 ) THEN A.BOOK_USER ELSE NULL END,
			0,0,0,
			A.PRESC_DOC,@DEPTID,@DEPTBR,
			A.EXECDEPT_ID,--Modify by Tany 2015-04-20 执行科室还是跟随处方表，在处方表确定在哪个执行科室领药
			--case when @pvsBit=1 and DATEDIFF(DAY,c.order_bdate,B.EXECDATE)>=1 then @EXEDEPT else A.EXECDEPT_ID end,--Modify by jchl 使用pivas科室
		    CASE WHEN C.MNGTYPE=5 AND C.JZ_FLAG=1 THEN 3
			WHEN
			  isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7206),0)='0'
			 and
			 (
			 C.NTYPE=3 OR D.DJYP=1 OR  ( D.MZYP=1 and (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7101)='0' )--
			OR (D.MZYP=1 and (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7101)='1' and not EXISTS (SELECT 1 FROM SS_DEPT WHERE DEPTID=@DEPTLY) ) --Modify by zouchihua 2012-01-31 麻醉药品且7101参数开启且是手术麻醉 手术麻醉的麻醉药品是否统领
			OR D.JSYP=1 OR D.GZYP=1 OR D.RSYP=1 OR (C.MNGTYPE=5 AND (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7091)='1') 
			OR a.STATITEM_CODE in (@tjdxm_cf)  ) THEN 5 --Modify By Tany 2011-06-19 7091所有临时药品医嘱是否处方领药 0=不是 1=是
			when  (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7206)='1' and ( D.MZYP=1  OR C.NTYPE=3 )  then 5 ---yaokx 2014-06-24 住院处方发药里医院是否只要麻醉药品
			ELSE 0 END,--出院带药TLFS=3 --处方药TLFS=5 毒麻精贵草妊娠
			@DEPTLY,@JGBM, 
			D.S_YPGG,D.S_SCCJ,@GCYS,isnull(C.zfbl,1),--ZFBL Add By Tany 2014-11-24
			case when (@pvsBit=0 or DATEDIFF(DAY,c.order_bdate,B.EXECDATE)=0) and D.TLFL='03' and C.DEPT_ID not in (SELECT DEPTID FROM SS_DEPT) then 5 else 0 end,--Add By Tany 2014-11-24 如果是大输液，并且不是手术麻醉科开的，发药标志为5  --Mpdify by jchl @pvsBit pivas逻辑加入
			B.pvs_xh	--Mpdify by jchl  pivas频率拆分序号
	    FROM (SELECT * FROM ZY_PRESCRIPTION WHERE TYPE=1) A
	    INNER JOIN
	    (SELECT * FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE) B
	    ON A.SOURCE_ID=B.ID
	    INNER JOIN
	    (SELECT * FROM #temp_zy_orderrecord WHERE GROUP_ID = @GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)
	     AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND DELETE_BIT=0 AND HOITEM_ID>0 AND EXEC_DEPT>0
	     and	( @cfg7605='1' or
					 (
						(
							(@pvsType=0 and (MNGTYPE=0 or is_PvsChk=1)) or
							(@pvsType=1 and (MNGTYPE=1 or is_PvsChk=1)) or
							(@pvsType=2 and is_PvsChk=1)
						)--Modify by jchl  @pvsType
					 )
				)
	     ) C
	    ON B.ORDER_ID=C.ORDER_ID AND A.INPATIENT_ID=C.INPATIENT_ID AND A.BABY_ID=C.BABY_ID
		INNER JOIN VI_YP_YPCD D ON C.HOITEM_ID=D.CJID

	    IF @@ROWCOUNT=0 AND @NTYPE NOT IN (0,6,7)--出院转科、手术、说明不判断是否有记录插入 Modify By Tany 2009-11-07
        BEGIN
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入费用表药品信息没有数据，请检查！'	
		    ROLLBACK TRAN
		    RETURN   	
        END

	    IF @@ERROR<>0 
	    BEGIN            
	        SET @OUTCODE=@@ERROR
	        SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入费用表药品信息出错！'
	        ROLLBACK TRAN
	        RETURN            
	    END
	END

	 --|诊疗项目
	--MODIFY BY TANY 2004-10-24 如果医嘱记录表里面的单价不为0则保存处方表的时候用此单价
	IF (@NTYPE >3 /*OR @NTYPE=0*/ OR @XMLY=2) AND @HOITEMID>0
        BEGIN
		--如果不是套餐HDITEM_ID=HSITEM_ID
		INSERT INTO ZY_FEE_SPECI
			 (  ID,INPATIENT_ID,BABY_ID,
				ORDER_ID,ORDEREXEC_ID,PRESCRIPTION_ID,
				PRESC_NO,PRESC_DATE,BOOK_DATE,BOOK_USER,
				STATITEM_CODE,XMID,XMLY,TCID,TC_FLAG,
				ITEM_NAME,SUBCODE,UNIT,UNITRATE,
				COST_PRICE,RETAIL_PRICE,
				NUM,DOSAGE,
				SDVALUE,AGIO,ACVALUE,
				CHARGE_BIT,CHARGE_DATE,CHARGE_USER,
				DELETE_BIT,CZ_FLAG,DISCHARGE_BIT,
				DOC_ID,DEPT_ID,DEPT_BR,EXECDEPT_ID,DEPT_LY,JGBM,GCYS,
				ZFBL--ZFBL Add By Tany 2014-11-24
			 )
		SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@INPATIENTID,@BABYID,
				C.ORDER_ID,A.SOURCE_ID,A.ID,
				A.PRESC_NO,A.PRESC_DATE,A.BOOK_DATE,A.BOOK_USER,
				R.STATITEM_CODE,A.HDITEM_ID,A.XMLY,A.TCID,A.TC_FLAG,
				R.ITEM_NAME,R.STD_CODE,R.ITEM_UNIT,A.UNITRATE,
				A.PRICE,A.PRICE,
				A.NUM,A.DOSAGE,
				--A.PRICE*A.NUM,A.AGIO,A.PRICE*A.NUM,
				CONVERT(DECIMAL(18,2),A.PRICE*A.NUM/B.ISANALYZED)*B.ISANALYZED,A.AGIO,CONVERT(DECIMAL(18,2),A.PRICE*A.NUM/B.ISANALYZED)*B.ISANALYZED,
				A.CHARGE_BIT,CASE WHEN A.CHARGE_BIT=1 THEN A.BOOK_DATE ELSE NULL END,CASE WHEN A.CHARGE_BIT=1 THEN A.BOOK_USER ELSE NULL END,
				0,0,0,
				A.PRESC_DOC,@DEPTID,@DEPTBR,A.EXECDEPT_ID,@DEPTLY,@JGBM,@GCYS,
				isnull(C.zfbl,1)--ZFBL Add By Tany 2014-11-24
		FROM (SELECT * FROM ZY_PRESCRIPTION WHERE TYPE=1) A
		INNER JOIN
		(SELECT * FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE) B
		ON A.SOURCE_ID=B.ID
		INNER JOIN
		(SELECT * FROM #temp_zy_orderrecord WHERE GROUP_ID = @GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)
		 AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND DELETE_BIT=0 AND HOITEM_ID>0) C
		ON B.ORDER_ID=C.ORDER_ID AND A.INPATIENT_ID=C.INPATIENT_ID AND A.BABY_ID=C.BABY_ID
		INNER JOIN
		JC_HSITEMDICTION R
		ON A.HDITEM_ID=R.ITEM_ID AND A.JGBM=R.JGBM
		WHERE A.TCID=-1 AND A.TC_FLAG=0
		UNION ALL
		--如果是套餐，则连接套餐明细表
		SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@INPATIENTID,@BABYID,
				C.ORDER_ID,A.SOURCE_ID,A.ID,
				A.PRESC_NO,A.PRESC_DATE,A.BOOK_DATE,A.BOOK_USER,
				R.STATITEM_CODE,T.SUBITEM_ID,A.XMLY,A.TCID,A.TC_FLAG,
				R.ITEM_NAME,R.STD_CODE,R.ITEM_UNIT,A.UNITRATE,
				R.COST_PRICE,R.RETAIL_PRICE,
				A.NUM*T.NUM,A.DOSAGE,
				R.COST_PRICE*A.NUM*T.NUM,A.AGIO,R.RETAIL_PRICE*A.NUM*T.NUM,
				A.CHARGE_BIT,CASE WHEN A.CHARGE_BIT=1 THEN A.BOOK_DATE ELSE NULL END,CASE WHEN A.CHARGE_BIT=1 THEN A.BOOK_USER ELSE NULL END,
				0,0,0,
				A.PRESC_DOC,@DEPTID,@DEPTBR,A.EXECDEPT_ID,@DEPTLY,@JGBM,@GCYS,
				isnull(C.zfbl,1)--ZFBL Add By Tany 2014-11-24 套餐先按头表的比例写入，等待费用传输的时候更新
		FROM (SELECT * FROM ZY_PRESCRIPTION WHERE TYPE=1) A
		INNER JOIN
		(SELECT * FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE) B
		ON A.SOURCE_ID=B.ID
		INNER JOIN
		JC_TC_MX T
		ON A.TCID=T.MAINITEM_ID
		INNER JOIN
		(SELECT * FROM #temp_zy_orderrecord WHERE GROUP_ID = @GROUPID AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)
		 AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID AND DELETE_BIT=0) C
		ON B.ORDER_ID=C.ORDER_ID AND A.INPATIENT_ID=C.INPATIENT_ID AND A.BABY_ID=C.BABY_ID
		INNER JOIN
		JC_HSITEMDICTION R
		ON T.SUBITEM_ID=R.ITEM_ID AND CASE WHEN C.EXEC_DEPT<=0 THEN C.JGBM ELSE DBO.FUN_GETDEPTJGBM(C.EXEC_DEPT) END=R.JGBM--Modify By Tany 2010-07-05 读取执行科室对应机构编码的价格
		WHERE A.TCID>=0 AND A.TC_FLAG=1

	    IF @@ROWCOUNT=0 AND @NTYPE NOT IN (0,6,7)--出院转科、手术、说明不判断是否有记录插入 Modify By Tany 2009-11-07
        BEGIN
		    SET @OUTCODE=-1
		    SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入费用表项目信息没有数据，请检查！'	
		    ROLLBACK TRAN
		    RETURN   	
        END

        IF @@ERROR<>0 
        BEGIN            
            SET @OUTCODE=@@ERROR
            SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入费用表项目信息出错！'
            ROLLBACK TRAN
            RETURN            
        END
		
		--医技申请
		IF @NTYPE=5 --@NTYPE >3 OR @NTYPE=0 OR @XMLY=2 Modify By Tany 2009年9月13日
        BEGIN
			--Modify By Tany 2010-01-23 医技申请改由医嘱执行时生成，方便长期医嘱产生申请记录
			--首先插入医技申请
			--YJ_ZYSQ表YZID,ZXID列应该联合起来作为唯一索引
			INSERT INTO YJ_ZYSQ 
			( 
				YJSQID, JGBM, BRXXID, INPATIENT_ID, 
				SQRQ, SQR, SQKS, 
				SQNR, 
				JE, LCZD, ZXKS, BSJC, 
				BBMC, ZYSX, BJJBZ, YZID, YZXMID,
				ZXR, ZXSJ, ZXID, DJLX--Modify By Tany 2010-11-16 登记类型,1化验2检查
			)	
			SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@JGBM,B.PATIENT_ID,A.INPATIENT_ID,
				E.PRESC_DATE, A.ORDER_DOC, A.DEPT_ID, --A.ORDER_BDATE Modify By tany 2011-07-12 长期医嘱的申请日期应该是处方日期
				CASE WHEN (UPPER(A.UNIT)='U' OR A.UNIT='ML') THEN RTRIM(ORDER_CONTEXT )+ ' '+ DBO.FUN_ZY_CHGDECIMALTOCHAR(A.NUM) + RTRIM(A.UNIT) ELSE ORDER_CONTEXT END,
				SUM(E.ACVALUE),--(DBO.FUN_ZY_SEEKHOITEMPRICE(A.HOITEM_ID,@JGBM))*A.NUM*(CASE WHEN DOSAGE IS NULL OR DOSAGE <=0 THEN 1 ELSE DOSAGE END), 
				ISNULL(A.MEMO1,''), A.EXEC_DEPT, '',
				C.SAMP_NAME, '', 0, A.ORDER_ID, A.HOITEM_ID,
				@EXEUSER,GETDATE(),D.ID,
				case isnull(isnull(i.class_type,j.class_type),-1) when 0 then 2 when 1 then 1 else 0 end 
			FROM 
			(SELECT * FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE) D
			INNER JOIN
			(SELECT * FROM #temp_zy_orderrecord WHERE INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
			AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2) AND DELETE_BIT=0 AND GROUP_ID = @GROUPID) A
			ON D.ORDER_ID=A.ORDER_ID 
			INNER JOIN ZY_INPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID	
			INNER JOIN ZY_FEE_SPECI E ON A.ORDER_ID=E.ORDER_ID AND D.ID=E.ORDEREXEC_ID AND E.TYPE=1
			LEFT JOIN LS_AS_SAMPLE C ON A.DWLX=C.SAMP_CODE
			--Modify By tany 2010-11-16
			left join JC_ASSAY g on a.HOITEM_ID=g.yzid
			left join JC_JC_ITEM h on a.HOITEM_ID=h.yzid
			left join JC_JCCLASSDICTION i on g.hylxid=i.id
			left join JC_JCCLASSDICTION j on h.jclxid=j.id
			GROUP BY B.PATIENT_ID,A.INPATIENT_ID,E.PRESC_DATE, A.ORDER_DOC, A.DEPT_ID,--,A.ORDER_BDATE
				A.UNIT,A.ORDER_CONTEXT,A.NUM,A.MEMO1,A.EXEC_DEPT,C.SAMP_NAME,A.ORDER_ID, 
				A.HOITEM_ID,D.ID,i.class_type,j.class_type
			IF @@ROWCOUNT=0
			BEGIN
				SET @OUTCODE=-1
				SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入医技申请表没有数据，请检查！'	
				ROLLBACK TRAN
				RETURN   	
			END
			IF @@ERROR<>0            
			BEGIN            
				SET @OUTCODE=@@ERROR
				SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 插入医技申请表出错！'
				ROLLBACK TRAN
				RETURN            
			END

			--确认医技 ADD BY TANY 2009-09-13
			--Modify By Tany 2010-11-26 暂不使用
			--医技项目发送直接记账后是否进行医技确认操作（0=不确认 1=确认）
--			IF (SELECT CONFIG FROM JC_CONFIG WHERE ID=7072)='1'
--			BEGIN
				--Modify By Tany 2010-08-12 不管是否需要退费确认，都进行确认验证
				--使用游标，来确认费用
				DECLARE YJ_CURSOR CURSOR FOR
				SELECT B.ID EXEC_ID,D.YJSQID APP_ID,C.ORDER_ID,D.JE
				FROM 
				(SELECT * FROM #temp_ZY_ORDEREXEC WHERE EXECDATE=@CUREXECDATE) B
				INNER JOIN
				(SELECT * FROM #temp_zy_orderrecord WHERE INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
				AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2) AND DELETE_BIT=0 AND GROUP_ID = @GROUPID) C
				ON B.ORDER_ID=C.ORDER_ID
				INNER JOIN
				YJ_ZYSQ D
				ON D.YZID=C.ORDER_ID AND D.ZXID=B.ID
				
				OPEN YJ_CURSOR
				FETCH YJ_CURSOR INTO @YJ_EXEC_ID,@YJ_APP_ID,@YJ_ORDER_ID,@YJ_JE
				WHILE @@FETCH_STATUS=0
				BEGIN
					--如果已经记账了才需要确认医技
					IF (SELECT TOP 1 CHARGE_BIT FROM ZY_FEE_SPECI WHERE ORDER_ID=@YJ_ORDER_ID AND ORDEREXEC_ID=@YJ_EXEC_ID AND TYPE=1)=1
					BEGIN
						DECLARE @NEWYJSQID UNIQUEIDENTIFIER
						DECLARE @ERRCODE INT
						DECLARE @ERRTEXT VARCHAR(50)

						SET @NEWYJSQID = DBO.FUN_GETEMPTYGUID()
						SET @ERRCODE = -1
						SET @ERRTEXT = ''

						EXEC SP_YJ_SAVE_QRJL @YJ_ORDER_ID,@YJ_APP_ID,@YJ_JE,@DEPTID,@EXECBOOKDATE,@EXEUSER,1,@EXECBOOKDATE,0,'',@NEWYJSQID OUTPUT,@ERRCODE OUTPUT,@ERRTEXT OUTPUT,@YJ_EXEC_ID,0
						IF @ERRCODE<>0 OR @@ERROR<>0
						BEGIN            
							SET @OUTCODE=@ERRCODE
							SET @OUTMSG=@BED_NO+' 床病人 '+@PAT_NAME+' 医技确费出错：'+@ERRTEXT
							ROLLBACK TRAN
							RETURN            
						END
					END

					FETCH YJ_CURSOR INTO @YJ_EXEC_ID,@YJ_APP_ID,@YJ_ORDER_ID,@YJ_JE
				END
				CLOSE YJ_CURSOR  
				DEALLOCATE YJ_CURSOR 
--			END
		END
	END
	--先屏蔽	
	--SET @LASTEXECDATE=@CUREXECDATE
	--ADD BY TANY 2004-12-08
	SELECT @LASTVALIDEXECDATE=MAX(EXECDATE)
	FROM #temp_ZY_ORDEREXEC
	WHERE ORDER_ID = @ORDERID AND ISANALYZED>0 --取执行次数>0的记录
  
   
NEXT_DAY:
	--|打上医嘱执行标志
	--|临时医嘱、账单执行一次就停止
	IF (@MNGTYPE=1 OR @MNGTYPE=5 OR @MNGTYPE=3)
        BEGIN--01
		--|临时医嘱、临时帐单则自动停止
		--如果还没有执行则不更改状态 MODIFY BY TANY 2004-11-08
		IF EXISTS(SELECT 1 FROM ZY_ORDEREXEC B
		          INNER JOIN
		          (SELECT * FROM #temp_zy_orderrecord
		           WHERE GROUP_ID=@GROUPID
		                 AND INPATIENT_ID=@INPATIENTID
		                 AND BABY_ID=@BABYID
		                 AND STATUS_FLAG =2
		                 AND (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2) --MODIFY BY TANY 2004-12-03
		          ) A
		          ON A.ORDER_ID=B.ORDER_ID)
		BEGIN--0101
		        UPDATE ZY_ORDERRECORD
		        SET STATUS_FLAG=5,ORDER_EDATE=@EXECBOOKDATE
		        WHERE GROUP_ID=@GROUPID AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
		            AND STATUS_FLAG =2  AND (@MNGTYPE in(1,5) and (MNGTYPE in(1,5)) or (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2)) --Modify by zouchihua 交病人医嘱和临时医嘱开在一起时 状态没有改变 --MODIFY BY TANY 2004-12-03
		        ----同事更新临时表#temp_zy_orderrecord
		        UPDATE #temp_zy_orderrecord
		        SET STATUS_FLAG=5,ORDER_EDATE=@EXECBOOKDATE
		        WHERE GROUP_ID=@GROUPID AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
		            AND STATUS_FLAG =2  AND (@MNGTYPE in(1,5) and (MNGTYPE in(1,5)) or (MNGTYPE=@MNGTYPE OR MNGTYPE=@MNGTYPE2))
		        ----
		        
		        IF @@ERROR<>0 
		        BEGIN            
		            SET @OUTCODE=@@ERROR
		            SET @OUTMSG='更新医嘱表临时医嘱停止信息出错！'
			    ROLLBACK TRAN 
		            RETURN            
		        END
		END--0101

		COMMIT
		RETURN
        END--01
	--MODIFY BY TANY 2004-10-05 如果当天开的医嘱执行后当天停，程序允许[ELSE  IF DATE(@CUREXECDATE) = DATE(@STOPEXEDATE) THEN]
	--长期医嘱、账单
	ELSE
        BEGIN--02
        --add by zouchihua 
        declare @ls_termtimes int --记录医嘱冲正次数
        set @ls_termtimes=@TERMINALTIMES
        --如果是整合领的话，那么就不自动冲正
        if @zhbj=1
            begin
                COMMIT
			    RETURN 
           end 
		--如果执行日期大于等于停止日期 MODIFY BY TANY 2006-03-23
		IF CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) >= CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE))
            BEGIN--0201	
		   --停医嘱自动冲正费用 ADD BY TANY 2005-11-30
		   --7055 是否启用停医嘱自动冲正 0=不是 1=是 ADD BY TANY 2009-09-18
		   IF @STATUS_FLAG=4 AND (SELECT CONFIG FROM JC_CONFIG WHERE ID=7055)='1'
            BEGIN--020101
			DECLARE @CFG_KFTLFL VARCHAR(100)
			DECLARE @CFG_ISCLYPCZ varchar(200) --Modify By Tany 2015-06-04 改成字符串型
			--Modify By tany 2011-03-16 冲正未发药的消息是否自动删除该消息
			DECLARE @CFG_7026 VARCHAR(10)
			
			--Modify By jchl 2015-03-23 pivas以扫描药品是否允许冲减 0否 1是
			DECLARE @cfg7603 VARCHAR(10)
            
           -- declare @
            
			--Modify By Tany 2009-10-21 自动冲正也判断药品退药是否直接记账
			DECLARE @CZ_CHARGEBIT SMALLINT
			DECLARE @CZ_USER BIGINT
			DECLARE @CZ_DATE DATETIME

			SET @CZ_CHARGEBIT=1

			--如果是药品,并且冲正药品不直接记账
			IF(@NTYPE<=3 AND @NTYPE<>0 AND @XMLY=1 
				AND (SELECT LTRIM(RTRIM(ISNULL(CONFIG,''))) FROM JC_CONFIG WHERE ID=7025)='否')
			BEGIN
				SET @CZ_CHARGEBIT=0
			END
			
			 	     if  @XMLY=2
          begin
              --他科室是否不允许冲正
               if EXISTS ( select * from jc_config where id=7212 and config='1') and  EXISTS(   SELECT * FROM ZY_ORDERRECORD
                  a join JC_HOITEMDICTION  b on a.HOITEM_ID=b.ORDER_ID
 WHERE GROUP_ID=@GROUPID AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID and a.XMLY=2 and (isbks=1 or isryks=1))
              set @CZ_CHARGEBIT=0  
              
          end
			
             --add by zouchihua 2013-3-19 医技是否冲正计费 医院还是要求自动记账
             if(@NTYPE=5 AND  @XMLY=2 AND  (SELECT LTRIM(RTRIM(ISNULL(CONFIG,'0'))) FROM JC_CONFIG WHERE ID=7053)='1')
                 SET @CZ_CHARGEBIT=2--2 为不记账
                 
			SET @CFG_KFTLFL=(SELECT LTRIM(RTRIM(ISNULL(CONFIG,''))) FROM JC_CONFIG WHERE ID=7048)
			SET @CFG_ISCLYPCZ=(SELECT ISNULL(CONFIG,'1') FROM JC_CONFIG WHERE ID=7054)
			--Modify By Tany 2011-03-16
			SET @CFG_7026=(SELECT LTRIM(RTRIM(ISNULL(CONFIG,''))) FROM JC_CONFIG WHERE ID=7026)
			
			--Modify By jchl 2015-03-23
			SET @cfg7603=(SELECT LTRIM(RTRIM(ISNULL(CONFIG,''))) FROM JC_CONFIG WHERE ID=7603)
			
			--add by zouchihua 2013-3-1
			declare @CFG_7142 varchar(3)
			set @CFG_7142=(SELECT LTRIM(RTRIM(ISNULL(CONFIG,'0'))) FROM JC_CONFIG WHERE ID=7142)
		      --得到ORDER_ID
			  --FOR O1 AS 
            DECLARE O1 CURSOR FOR
			      SELECT ORDER_ID FROM #temp_zy_orderrecord WHERE GROUP_ID=@GROUPID AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID 
			      AND ( case when @CFG_7142='0' then NTYPE else 1 end)<>5 --医技项目不冲正 --add by zouchihua 2013-3-1 如果参数打开，那么是允许冲正医技医嘱的
			OPEN O1
			FETCH O1 INTO @O1_ORDER_ID
			WHILE @@FETCH_STATUS=0
			BEGIN--O1
			     --得到这条医嘱在费用表里面的最大执行日期
			     SET @MAXEXECDATE=(SELECT MAX(PRESC_DATE) FROM ZY_FEE_SPECI WHERE ORDER_ID=@O1_ORDER_ID)
			     WHILE CONVERT(DATETIME,DBO.FUN_GETDATE(@MAXEXECDATE))>=CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE))
                BEGIN
				--得到TYPE，正常费用和附加费用要区分
				--FOR O2 AS
				if  @cfg7198='1'
				begin
				DECLARE O2 CURSOR scroll FOR 
				SELECT A.ID,A.ORDEREXEC_ID,A.NUM,A.UNITRATE,ISNULL(B.TLFL,''),A.EXECDEPT_ID,XMID as cjid,xmly,A.is_PvsScn
				FROM ZY_FEE_SPECI A  
				LEFT JOIN VI_YP_YPCD B ON A.XMID=B.CJID AND A.XMLY=1
--				LEFT JOIN YP_YPJX C ON B.YPJX=C.ID 
				WHERE ORDER_ID=@O1_ORDER_ID AND CZ_FLAG<>2 AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE(@MAXEXECDATE))
				  and isnull(YBJS_BIT,0)=0 --add by zouchihua  2013-2-19 过滤已经医保结算的
				  order by xmly,(case when xmly=2 
				  and 
				  (charindex(','+cast(xmid as varchar(20))+',',','+@cfg7199+',')>0 
				  or charindex(','+cast(xmid as varchar(20))+',',','+@cfg7200+',')>0 )
				  then num else a.xmid end),num desc-- 多条冲正时先满足大的
				  end
				  ---
				  else
				  begin
				  DECLARE O2 CURSOR scroll FOR 
				SELECT A.ID,A.ORDEREXEC_ID,A.NUM,A.UNITRATE,ISNULL(B.TLFL,''),A.EXECDEPT_ID,XMID as cjid,xmly,A.is_PvsScn
				FROM ZY_FEE_SPECI A  
				LEFT JOIN VI_YP_YPCD B ON A.XMID=B.CJID AND A.XMLY=1
--				LEFT JOIN YP_YPJX C ON B.YPJX=C.ID 
				WHERE ORDER_ID=@O1_ORDER_ID AND CZ_FLAG<>2 AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE(@MAXEXECDATE))
				  and isnull(YBJS_BIT,0)=0 --add by zouchihua  2013-2-19 过滤已经医保结算的
				  order by xmly,xmid, num,pvs_xh desc-- 多条冲正时先满足大的 按pvs_xh倒序排序 Modify By Tany 2015-04-22
				  ---------------------------------
				  end
				  
				OPEN O2  
				FETCH O2 INTO @O2_ID,@O2_ORDEREXEC_ID,@O2_NUM,@O2_UNITRATE,@O2_TLFL,@o2_execdept_id ,@o2_cjid,@o2_xmly,@o2_PvsScn--Modify by jchl 新增@o2_PvsScn
				WHILE @@FETCH_STATUS=0
				BEGIN--O2
					--如果是口服药，并且拆零，并且不允许退拆零口服药，跳出去执行下一条
					--拆零口服药判断原来是@CFG_ISCLYPCZ=0，现在改为不等于1，用于参数可以设置住院号来单独开启冲减 Modify By Tany 2015-06-04
					IF @CFG_KFTLFL<>'' AND @CFG_ISCLYPCZ<>'1' AND CHARINDEX(@O2_TLFL,@CFG_KFTLFL)>0 AND @O2_UNITRATE>1
					BEGIN
						FETCH O2 INTO @O2_ID,@O2_ORDEREXEC_ID,@O2_NUM,@O2_UNITRATE,@O2_TLFL,@o2_execdept_id ,@o2_cjid,@o2_xmly,@o2_PvsScn
						CONTINUE
					END
					
					--modify by jchl 2015-03-23
					--如果是pivas已经进仓扫描并且7603（pivas以扫描药品是否允许冲减 0否 1是）为0，跳出去执行下一条
					IF @cfg7603=0 AND @o2_PvsScn=1
					BEGIN
						FETCH O2 INTO @O2_ID,@O2_ORDEREXEC_ID,@O2_NUM,@O2_UNITRATE,@O2_TLFL,@o2_execdept_id ,@o2_cjid,@o2_xmly,@o2_PvsScn
						CONTINUE
					END
					
				 	--看这天的费用是否已经冲正过，这个数字=当前可以冲正的总数
					SELECT @CZZNUM=SUM(NUM),
						@CZZJE=SUM(ACVALUE)
					FROM ZY_FEE_SPECI WHERE DELETE_BIT=0 AND (ID=@O2_ID OR CZ_ID=@O2_ID)
					--如果还有没有冲正的
					IF @CZZNUM>0
                    BEGIN--02010101
					   SET @CZNUM=@CZZNUM
					   
					   --Add By tany 2015-06-03 记录每条医嘱的执行科室是否pivas科室
					   set @isPvsDept=(select COUNT(1) from JC_DEPT_DRUGSTORE where DRUGSTORE_ID=@o2_execdept_id and is_pvsrel=1 and DELETE_BIT=0)
						   
			  		   --如果最大执行日期大于停止日期，则把那天没有冲正的数据全部冲正
			  		   IF CONVERT(DATETIME,DBO.FUN_GETDATE(@MAXEXECDATE))>CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE))
                       BEGIN--0201010101						
						  --Modify By Tany 2010-05-04 冲正金额=总金额-已经冲正的金额
					   	  INSERT INTO ZY_FEE_SPECI
				          (ID,ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,BOOK_DATE,BOOK_USER,
						   PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
						   ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
						   AGIO, EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT,
						   NUM,SDVALUE,ACVALUE,TYPE,TLFS,
						   CHARGE_BIT,CHARGE_USER,CHARGE_DATE,BZ,JGBM,GG,CJ,GCYS,FY_BIT,pvs_xh)				 												
						  SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,GETDATE(),@EXEUSER,
						   PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
						   ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
						   AGIO,EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,2,A.ID,0,0,		   
						   ---1*@CZNUM,-1*@CZNUM*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END),-1*@CZNUM*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END),TYPE,TLFS,
						   -1*@CZNUM,-1*@CZZJE,-1*@CZZJE,TYPE,TLFS,
						   --如果是大输液，直接记账,武汉中心医院项目 Modify By Tany 2014-11-24
						   --如果是pivas的大输液，不直接记账，根据其他标志判断 Modify By Tany 2015-06-03
						   CASE WHEN (@O2_TLFL='03' and @isPvsDept=0) OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN 1 ELSE 0 END,
						   CASE WHEN (@O2_TLFL='03' and @isPvsDept=0) OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN @EXEUSER ELSE NULL END,
						   CASE WHEN (@O2_TLFL='03' and @isPvsDept=0) OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN GETDATE() ELSE NULL END,'【系统自动冲正】',@JGBM,GG,CJ,GCYS,
						   CASE WHEN @O2_TLFL='03' and @isPvsDept=0 THEN 5 ELSE 0 END,pvs_xh --大输液不发药 Modify By Tany 2014-11-27 如果是pivas的大输液是要发药的 Modify By Tany 2015-04-22
		                  FROM ZY_FEE_SPECI A WHERE ID=@O2_ID
		                  
		                  --更新医技记录表  add by zouchihua 2012-3-19
		                  if(@NTYPE=5 and @XMLY=2)
		                  begin
		                     update yj_zysq set btfbz=1,tfje=TFJE-1*@CZZJE where yzid=@O1_ORDER_ID and zxid=@O2_ORDEREXEC_ID;
		                  end 
		                  
		                  ----add by zouchihua 2012-2-21 虚拟库存
		                   if isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=6035),0)='1'
		                       and @xmly=1
						  begin
							   --SELECT  @TMP_YLKC=KCL FROM YF_KCMX WHERE CJID=@TMED_HOITEM_ID AND DEPTID=@TMED_EXEC_DEPT AND BDELETE=0
							   --减虚拟库存
							   --declare @ypsl decimal(15,3)
							  -- set @ypsl=@CZNUM,@o2_execdept_id ,@o2_cjid
							   EXEC sp_yf_updatekcmx_xnkcl  @o2_cjid,@CZNUM,@O2_UNITRATE,@o2_execdept_id,0,''
						  end
		                  ---------------------------------------
				          IF @@ERROR<>0 
				          BEGIN            
							SET @OUTCODE=@@ERROR
							SET @OUTMSG='插入费用表自动冲帐信息出错！'
							CLOSE O1
							DEALLOCATE O1
							CLOSE O2
							DEALLOCATE O2 
							ROLLBACK TRAN
							RETURN            
				          END
						  
						  UPDATE ZY_FEE_SPECI SET CZ_FLAG=1 WHERE ID=@O2_ID
						  IF @@ERROR<>0 
						  BEGIN            
							SET @OUTCODE=@@ERROR
							SET @OUTMSG='更新费用表自动冲帐信息出错！'
							CLOSE O1
							DEALLOCATE O1
							CLOSE O2
							DEALLOCATE O2 
							ROLLBACK TRAN
							RETURN            
						  END
						  --Modify By tany 2011-03-16 增加自动冲账后7026参数的判断
						  IF @CFG_7026='是'
						  BEGIN
							IF EXISTS(SELECT 1 FROM ZY_FEE_SPECI a left join #temp_zy_orderrecord b on a.ORDER_ID=b.ORDER_ID WHERE FY_BIT=0 AND SCBZ=0
										AND (CHARGE_BIT=0 OR (CHARGE_BIT=1 AND DBO.FUN_GETDATE(CHARGE_DATE)=DBO.FUN_GETDATE(GETDATE())))
										AND ID=@O2_ID  )--医技不自动删除 and b.NTYPE<>5 
										--医技还是要删除 add by zouchihua 2013-6-25
							BEGIN
								IF (SELECT ISNULL(SUM(NUM),0) FROM ZY_FEE_SPECI WHERE    DELETE_BIT=0 AND (ID=@O2_ID OR CZ_ID=@O2_ID))=0
								BEGIN
									IF NOT EXISTS(SELECT 1 FROM ZY_FEE_SPECI WHERE  ((@zcy_zdsc=1 and TLFS=9) or (@zcy_zdsc=0  )) and  (FY_BIT=1 OR SCBZ=1) AND DELETE_BIT=0 AND CZ_ID=@O2_ID)
									BEGIN
										UPDATE ZY_FEE_SPECI SET DELETE_BIT=1,BZ=ISNULL(BZ,'')+'自动冲账删除' WHERE FY_BIT=0 AND SCBZ=0 
										AND (ID=@O2_ID OR CZ_ID=@O2_ID)  
										IF @@ERROR<>0 
										BEGIN            
											SET @OUTCODE=@@ERROR
											SET @OUTMSG='更新费用表自动冲帐删除信息出错！'
											CLOSE O1
											DEALLOCATE O1
											CLOSE O2
											DEALLOCATE O2 
											ROLLBACK TRAN
											RETURN            
										END
									END
								END
							END
						  END
                        END--0201010101
			  		   ELSE
                        BEGIN--0201010102
					   	  --如果最大执行日期等于停止日期，则冲正次数=<执行次数-末次执行次数>
						  IF CONVERT(DATETIME,DBO.FUN_GETDATE(@MAXEXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE(@STOPEXEDATE))
                            BEGIN--020101010201
					          --已经执行的次数
					           
								SET @ZXCS=(SELECT ISANALYZED FROM #temp_ZY_ORDEREXEC WHERE ID=@O2_ORDEREXEC_ID)
							  --(@ZXCS-@TERMINALTIMES)=已经执行的比末次多出来的次数
							  --(@O2_NUM/@ZXCS)=单次执行的数量
							  --@CZZNUM=当前可以冲正的总数
							  --如果当前可以冲正的总数-多出来的数量>=0表示还可以再冲
							  --可冲的数量就是=(@ZXCS-@TERMINALTIMES)*(@O2_NUM/@ZXCS)
							  --可冲的次数就是可冲总数量/单次的数量-末次的次数，如果大于0，那就还可以冲
							  IF @ZXCS>0 --AND (@CZZNUM/(@O2_NUM/@ZXCS))-@TERMINALTIMES>0--这里不应该判断可冲正数量，而应该判断可冲正次数 Modify By tany 2010-09-05
--							  IF @CZZNUM-((@ZXCS-@TERMINALTIMES)*(@O2_NUM/@ZXCS))>=0 
                                BEGIN--02010101020101  (1/(1)/1) -2                       
							     SET @CZNUM=((@CZZNUM/(@O2_NUM/@ZXCS))-@TERMINALTIMES)*(@O2_NUM/@ZXCS)
							    ---------**********add by zouchihua 2012-02-01
							   
							    DECLARE @O2_ID_temp UNIQUEIDENTIFIER
								DECLARE @O2_ORDEREXEC_ID_temp UNIQUEIDENTIFIER
								DECLARE @O2_NUM_temp DECIMAL(18,3) 
								DECLARE @O2_UNITRATE_temp INT
								DECLARE @O2_TLFL_temp VARCHAR(10)
								declare @o2_execdept_id_temp int
								declare @o2_cjid_temp int
								declare @o2_xmly_temp int
								declare @o2_PvsScn_temp int--modify by jchl
								declare @czznum_temp int
								set @czznum_temp=0
							     FETCH O2 INTO @O2_ID_temp,@O2_ORDEREXEC_ID_temp,@O2_NUM_temp,@O2_UNITRATE_temp,@O2_TLFL_temp,@o2_execdept_id_temp,@o2_cjid_temp,@o2_xmly_temp,@o2_PvsScn_temp--modify by jchl
							     if @@FETCH_STATUS=0
							     begin
							        SELECT @czznum_temp=ISNULL(SUM(NUM),0)
					                FROM ZY_FEE_SPECI WHERE DELETE_BIT=0 AND (ID=@O2_ID_temp OR CZ_ID=@O2_ID_temp)
					               
					               -- fetch o2 prior --向上移动
		                         end
		                           
		                           if @czznum_temp>0  and @o2_cjid_temp=@o2_cjid  and @o2_xmly_temp=@o2_xmly --说明有多条费用(一般情况下是两条)
		                            begin 
		                              set @CZNUM=(((@CZZNUM+@czznum_temp )/(@O2_NUM/@ZXCS))-@TERMINALTIMES)*(@O2_NUM/@ZXCS)
		                               if   @cfbz=1 --[如果是拆分的，都必须上移动]Modify by zouchihua 2015-1-20
		                                   fetch   prior from o2 --向上移动 有多条也上移
		                             end 
		                           else--没有多条
		                               begin
		                                  fetch   prior from o2 --向上移动 
		                                  set @czznum_temp=0
		                               end 
		                            
		                    if  (  (charindex(','+cast(@o2_cjid as varchar(20))+',',','+@cfg7199+',')>0 
				  or charindex(','+cast(@o2_cjid as varchar(20))+',',','+@cfg7200+',')>0 )  ) and @o2_xmly=2
				  begin
				                         set @CZNUM=ceiling(@CZNUM ) --无条件先取整数
		                                 set @CZZNUM=ceiling(@CZZNUM) --无条件先取整数
		                                   
		            end 
		           
		          
   if  (  (charindex(','+cast(@o2_cjid as varchar(20))+',',','+@cfg7199+',')=1 
				  or charindex(','+cast(@o2_cjid as varchar(20))+',',','+@cfg7200+',')=1  )  ) and @o2_xmly=2
				    and @TERMINALTIMES>0
				  begin
				                         set @CZNUM=0 --如果是静滴或者小二静滴，并且末次要》1
		                                 
		                                   
		            end    
		           --如果是拆分，那么就要重新计算数量
		            if   @cfbz=1 and @CZNUM<=0
		           begin 
		          declare @czznum_temp1 int
		            SELECT @czznum_temp1=ISNULL(SUM(NUM),0)
					                FROM ZY_FEE_SPECI WHERE DELETE_BIT=0 AND (XMID=@o2_cjid  and XMLY=@o2_xmly)
					               and ORDER_ID=@O1_ORDER_ID  
					                and   CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE(@MAXEXECDATE))
		                   set  @CZNUM= (((@czznum_temp1 )/(@O2_NUM/@ZXCS))-@TERMINALTIMES)*(@O2_NUM/@ZXCS)
		                 -- update ZY_FEE_SPECI set BZ=ISNULL(bz,'')+cast(@CZNUM as varchar)+'  ss'+cast(@czznum_temp1 as varchar) where ID=@O2_ID
		                 -- break 
		            end 
		                           --*************************************		
					              --@CZZNUM>@CZNUM*(@O2_NUM/@ZXCS)
								 IF   @CZNUM>0 --去掉判断
                                 BEGIN--0201010102010101
                                     if @CZZNUM<@CZNUM--*(@O2_NUM/@ZXCS)-- and @czznum_temp>0 --不满足冲正 被冲正《冲正数量
                                        set @CZNUM=@CZZNUM
                                     --else
                                      --SET @OUTMSG='更新费用表自动冲帐信息出错！' 
						   	  	   INSERT INTO ZY_FEE_SPECI
				          	       (ID,ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,BOOK_DATE,BOOK_USER,
						   	   	    PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
						   	   	    ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
						   	   	    AGIO, EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT,
						   	   	    NUM,
									SDVALUE,
									ACVALUE,
									TYPE,TLFS,
									CHARGE_BIT,CHARGE_USER,CHARGE_DATE,BZ,JGBM,GG,CJ,GCYS,FY_BIT,pvs_xh)				 												
						  	       SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,GETDATE(),@EXEUSER,
						   	   	        PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
						   	   	  	ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
						   	   	  	AGIO,EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,2,A.ID,0,0,		   
						   	   	  	-1*@CZNUM,
									case when @cznum=a.num then -a.sdvalue else -1*convert(decimal(18,2),@CZNUM*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END)) end,---1*convert(decimal(18,2),@CZNUM/(@ZXCS-@TERMINALTIMES)*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END))*(@ZXCS-@TERMINALTIMES),
									case when @cznum=a.num then -a.acvalue else -1*convert(decimal(18,2),@CZNUM*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END)) end,--Modify By Tany 2011-07-26 金额直接就是冲正数量*单价即可
									TYPE,TLFS,--Modify By Tany 2010-05-04 首先得到单次要冲正金额的四舍五入再乘以冲正次数
									--如果是大输液，直接记账,武汉中心医院项目 Modify By Tany 2014-11-24
									--如果是pivas的大输液，不直接记账，根据其他标志判断 Modify By Tany 2015-06-03
									CASE WHEN (@O2_TLFL='03' and @isPvsDept=0) OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN 1 ELSE 0 END,
									CASE WHEN (@O2_TLFL='03' and @isPvsDept=0) OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN @EXEUSER ELSE NULL END,
									CASE WHEN (@O2_TLFL='03' and @isPvsDept=0) OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN GETDATE() ELSE NULL END,'【系统自动冲正】',@JGBM,GG,CJ,GCYS,
									CASE WHEN @O2_TLFL='03' and @isPvsDept=0 THEN 5 ELSE 0 END,pvs_xh --大输液不发药 Modify By Tany 2014-11-27 如果是pivas的大输液是要发药的 Modify By Tany 2015-04-22
		                  	       FROM ZY_FEE_SPECI A WHERE ID=@O2_ID
		                  	        --更新医技记录表  add by zouchihua 2012-3-19
		                  if(@NTYPE=5 and @XMLY=2)
		                  begin
		                     update yj_zysq set btfbz=1,tfje=TFJE+1*(select top 1 case when @cznum=a.num then -a.sdvalue else -1*convert(decimal(18,2),@CZNUM*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END)) end  FROM ZY_FEE_SPECI A WHERE ID=@O2_ID )
		                      where yzid=@O1_ORDER_ID and zxid=@O2_ORDEREXEC_ID;
		                  end 
		                  	        ----add by zouchihua 2012-2-21 虚拟库存
		                   if isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=6035),0)='1'
		                    and @xmly=1
						  begin
							   --SELECT  @TMP_YLKC=KCL FROM YF_KCMX WHERE CJID=@TMED_HOITEM_ID AND DEPTID=@TMED_EXEC_DEPT AND BDELETE=0
							   --减虚拟库存
							   --declare @ypsl decimal(15,3)
							  -- set @ypsl=@CZNUM,@o2_execdept_id ,@o2_cjid
							   EXEC sp_yf_updatekcmx_xnkcl  @o2_cjid,@CZNUM,@O2_UNITRATE,@o2_execdept_id,0,''
						  end
		                  ---------------------------------------
		                  	                     
		                 
		                  	       
		                  	       -------------************-add by zouchihua 2012-02-02
		                  	       --第一次不够冲
		                  	       set @CZNUM=(((@CZZNUM+@czznum_temp )/(@O2_NUM/@ZXCS))-@TERMINALTIMES)*(@O2_NUM/@ZXCS)
		                  	         if  (  (charindex(','+cast(@o2_cjid as varchar(20))+',',','+@cfg7199+',')>0 
				  or charindex(','+cast(@o2_cjid as varchar(20))+',',','+@cfg7200+',')>0 )  ) and @o2_xmly=2
				  begin
				                      
				                     if (ceiling((((@CZZNUM+@czznum_temp )/(@O2_NUM/@ZXCS))-@TERMINALTIMES)*(@O2_NUM/@ZXCS))-@CZZNUM)<0
				                        set @czznum_temp=0 --说明以及被冲调，不再重新冲减
		                                   
		            end 
		                  	       
		                  	       if @CZZNUM<@CZNUM and @czznum_temp>0  and @o2_cjid_temp=@o2_cjid--多条记录--*(@O2_NUM/@ZXCS) 
		                  	          begin --冲正次数 
		                  	          set @CZNUM=(((@CZZNUM+@czznum_temp )/(@O2_NUM/@ZXCS))-@TERMINALTIMES)*(@O2_NUM/@ZXCS)-@CZZNUM
		                  	          INSERT INTO ZY_FEE_SPECI
				          	       (ID,ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,BOOK_DATE,BOOK_USER,
						   	   	    PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
						   	   	    ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
						   	   	    AGIO, EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT,
						   	   	    NUM,
									SDVALUE,
									ACVALUE,
									TYPE,TLFS,
									CHARGE_BIT,CHARGE_USER,CHARGE_DATE,BZ,JGBM,GG,CJ,GCYS,FY_BIT,pvs_xh)				 												
						  	       SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),ORDER_ID,PRESCRIPTION_ID,ORDEREXEC_ID,PRESC_DATE,GETDATE(),@EXEUSER,
						   	   	        PRESC_NO,STATITEM_CODE,XMID,TCID,TC_FLAG,INPATIENT_ID,BABY_ID,
						   	   	  	ITEM_NAME,SUBCODE,XMLY,UNIT,UNITRATE,DOSAGE,COST_PRICE, RETAIL_PRICE, 
						   	   	  	AGIO,EXECDEPT_ID,DEPT_ID,DEPT_BR,DEPT_LY,DOC_ID,2,A.ID,0,0,		   
						   	   	  	-1*@CZNUM,
									case when @cznum=a.num then -a.sdvalue else -1*convert(decimal(18,2),@CZNUM*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END)) end,---1*convert(decimal(18,2),@CZNUM/(@ZXCS-@TERMINALTIMES)*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END))*(@ZXCS-@TERMINALTIMES),
									case when @cznum=a.num then -a.acvalue else -1*convert(decimal(18,2),@CZNUM*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END)) end,--Modify By Tany 2011-07-26 金额直接就是冲正数量*单价即可
									TYPE,TLFS,--Modify By Tany 2010-05-04 首先得到单次要冲正金额的四舍五入再乘以冲正次数
									--如果是大输液，直接记账,武汉中心医院项目 Modify By Tany 2014-11-24
									CASE WHEN @O2_TLFL='03' OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN 1 ELSE 0 END,
									CASE WHEN @O2_TLFL='03' OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN @EXEUSER ELSE NULL END,
									CASE WHEN @O2_TLFL='03' OR @CZ_CHARGEBIT=1 OR (XMLY=2 and @CZ_CHARGEBIT!=2) THEN GETDATE() ELSE NULL END,'【系统自动冲正】',@JGBM,GG,CJ,GCYS,
									CASE WHEN @O2_TLFL='03' and not exists(select 1 from JC_DEPT_DRUGSTORE where DRUGSTORE_ID=A.EXECDEPT_ID and is_pvsrel=1 and DELETE_BIT=0) THEN 5 ELSE 0 END,pvs_xh --大输液不发药 Modify By Tany 2014-11-27 如果是pivas的大输液是要发药的 Modify By Tany 2015-04-22
		                  	       FROM ZY_FEE_SPECI A WHERE ID=@O2_ID_temp
		                  	         
		                  	         
		                  	          --更新医技记录表  add by zouchihua 2012-3-19
		                  if(@NTYPE=5 and @XMLY=2)
		                  begin
		                     update yj_zysq set btfbz=1,tfje=TFJE+1*(select top 1 case when @cznum=a.num then -a.sdvalue else -1*convert(decimal(18,2),@CZNUM*RETAIL_PRICE*(CASE WHEN DOSAGE<1 THEN 1 ELSE DOSAGE END)) end  FROM ZY_FEE_SPECI A WHERE ID=@O2_ID )
		                      where yzid=@O1_ORDER_ID and zxid=@O2_ORDEREXEC_ID;
		                  end 
		                  	         ------------------------------****************************
		                  			----add by zouchihua 2012-2-21 虚拟库存
								   if isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=6035),0)='1'
								     and @xmly=1
								     begin
									   --SELECT  @TMP_YLKC=KCL FROM YF_KCMX WHERE CJID=@TMED_HOITEM_ID AND DEPTID=@TMED_EXEC_DEPT AND BDELETE=0
									   --减虚拟库存
									   --declare @ypsl decimal(15,3)
									  -- set @ypsl=@CZNUM,@o2_execdept_id ,@o2_cjid
									   EXEC sp_yf_updatekcmx_xnkcl  @o2_cjid,@CZNUM,@O2_UNITRATE,@o2_execdept_id,0,''
								     end
						         end
								  ------------------------------*********************************
						           IF @@ERROR<>0 
						           BEGIN            
									SET @OUTCODE=@@ERROR
									SET @OUTMSG='插入费用表自动冲帐信息出错！'+CONVERT(VARCHAR,@ZXCS)+CONVERT(VARCHAR,@TERMINALTIMES)
									CLOSE O1
									DEALLOCATE O1
									CLOSE O2
									DEALLOCATE O2 
									ROLLBACK TRAN
									RETURN            
						           END
								   
								   UPDATE ZY_FEE_SPECI SET CZ_FLAG=1 WHERE ID in (@O2_ID,@O2_ID_temp)--Modify By Tany 2015-04-29 要同时更新两个医嘱ID，否则有可能冲的第一条医嘱cz_flag会是0
								   IF @@ERROR<>0 
								   BEGIN            
									SET @OUTCODE=@@ERROR
									SET @OUTMSG='更新费用表自动冲帐信息出错！'
									CLOSE O1
									DEALLOCATE O1
									CLOSE O2
									DEALLOCATE O2 
									ROLLBACK TRAN
									RETURN            
								   END
								   --Modify By tany 2011-03-16 增加自动冲账后7026参数的判断
								   IF @CFG_7026='是'
								   BEGIN
									IF EXISTS(SELECT 1 FROM ZY_FEE_SPECI a left join #temp_zy_orderrecord b on a.ORDER_ID=b.ORDER_ID  WHERE FY_BIT=0 AND SCBZ=0
												AND ( (CHARGE_BIT=0)
												       OR (CHARGE_BIT=1 AND DBO.FUN_GETDATE(CHARGE_DATE)=DBO.FUN_GETDATE(GETDATE()))
												     )
												AND (ID=@O2_ID) and DISCHARGE_BIT=0)--  and b.NTYPE<>5
										 --医技不自动删除 --医技还是要删除 add by zouchihua 2013-6-25
												
												
									BEGIN
										IF (SELECT ISNULL(SUM(NUM),0) FROM ZY_FEE_SPECI WHERE   DELETE_BIT=0 AND (ID=@O2_ID or CZ_ID=@O2_ID ))=0
										BEGIN
											IF NOT EXISTS(SELECT 1 FROM ZY_FEE_SPECI WHERE  ((@zcy_zdsc=1 and TLFS=9) or (@zcy_zdsc=0  ))   and (FY_BIT=1 OR SCBZ=1) AND DELETE_BIT=0 AND (CZ_ID=@O2_ID ))
											BEGIN
												UPDATE ZY_FEE_SPECI SET DELETE_BIT=1,BZ=ISNULL(BZ,'')+'自动冲账删除' WHERE FY_BIT=0 AND SCBZ=0 AND (ID=@O2_ID OR CZ_ID=@O2_ID) and DISCHARGE_BIT=0
												IF @@ERROR<>0 
												BEGIN            
													SET @OUTCODE=@@ERROR
													SET @OUTMSG='更新费用表自动冲帐删除信息出错！'
													CLOSE O1
													DEALLOCATE O1
													CLOSE O2
													DEALLOCATE O2 
													ROLLBACK TRAN
													RETURN            
												END
											END
										END
										
									END
							 ---------------
								IF EXISTS(SELECT 1 FROM ZY_FEE_SPECI WHERE FY_BIT=0 AND SCBZ=0
												AND (CHARGE_BIT=0 OR (CHARGE_BIT=1 AND DBO.FUN_GETDATE(CHARGE_DATE)=DBO.FUN_GETDATE(GETDATE())))
												AND (ID=@O2_ID_temp) and DISCHARGE_BIT=0)
								begin
									-----------
										IF (SELECT ISNULL(SUM(NUM),0) FROM ZY_FEE_SPECI WHERE   DELETE_BIT=0 AND (ID=@O2_ID_temp or CZ_ID=@O2_ID_temp))=0
										BEGIN
											IF NOT EXISTS(SELECT 1 FROM ZY_FEE_SPECI WHERE ((@zcy_zdsc=1 and TLFS=9) or (@zcy_zdsc=0  )) and (FY_BIT=1 OR SCBZ=1) AND DELETE_BIT=0 AND (CZ_ID=@O2_ID_temp ))
											BEGIN
												UPDATE ZY_FEE_SPECI SET DELETE_BIT=1,BZ=ISNULL(BZ,'')+'自动冲账删除' WHERE FY_BIT=0 AND SCBZ=0 AND (ID=@O2_ID_temp OR CZ_ID=@O2_ID_temp) and DISCHARGE_BIT=0
												IF @@ERROR<>0 
												BEGIN            
													SET @OUTCODE=@@ERROR
													SET @OUTMSG='更新费用表自动冲帐删除信息出错！'
													CLOSE O1
													DEALLOCATE O1
													CLOSE O2
													DEALLOCATE O2 
													ROLLBACK TRAN
													RETURN            
												END
											END
										END
									-------------
							    end
								-------------------	
								   END
								 END--0201010102010101 		                         		 
							  END--02010101020101
						   END--020101010201
					    END--0201010102
                      END--02010101

                    FETCH O2 INTO @O2_ID,@O2_ORDEREXEC_ID,@O2_NUM,@O2_UNITRATE,@O2_TLFL,@o2_execdept_id ,@o2_cjid,@o2_xmly,@o2_PvsScn--modify by jchl
				  END--WHILE O2
			          CLOSE O2
			          DEALLOCATE O2
					
				  --最大执行日期-1天
				  SET @MAXEXECDATE=DATEADD(DD,-1,@MAXEXECDATE)

			     END--WHILE

                FETCH O1 INTO @O1_ORDER_ID
			  END--WHILE O1
		          CLOSE O1
		          DEALLOCATE O1
                   END--020101
	
		   --|长期 如果NTYPE=0(出院、转科)则直接置为5 BY TANY 2004-10-09
		   UPDATE ZY_ORDERRECORD
		   SET STATUS_FLAG=5,LASTEXECDATE=GETDATE()--mod by jchl 2015-05-29[停嘱记录操作时间]
		   WHERE GROUP_ID=@GROUPID AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
		         AND (STATUS_FLAG=4 OR (STATUS_FLAG=2 AND NTYPE=0)) AND (MNGTYPE=0 OR MNGTYPE=2)
		   IF @@ERROR<>0 
	           BEGIN            
	               SET @OUTCODE=@@ERROR
	               SET @OUTMSG='更新医嘱表停止医嘱信息出错！'
	               ROLLBACK TRAN
	               RETURN            
	           END
             -------同时更新临时表
             
              UPDATE #temp_zy_orderrecord
		   SET STATUS_FLAG=5,LASTEXECDATE=GETDATE()--mod by jchl 2015-05-29[停嘱记录操作时间]
		   WHERE GROUP_ID=@GROUPID AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
		         AND (STATUS_FLAG=4 OR (STATUS_FLAG=2 AND NTYPE=0)) AND (MNGTYPE=0 OR MNGTYPE=2)
             ------
		   COMMIT
		   RETURN
                END--0201   
		ELSE
                BEGIN--0202
		   --如果当前日期大于
		     IF (LTRIM(RTRIM(@FREQUENCY))='1') AND (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) >= CONVERT(DATETIME,DBO.FUN_GETDATE(@BEGINEXEDATE)))
                     BEGIN--020201
			--|长期，只需执行一次的
			UPDATE ZY_ORDERRECORD
			SET STATUS_FLAG=5,ORDER_EDATE=(case when ORDER_CONTEXT like '%转%'then null else  @EXECBOOKDATE end),
			ORDER_EDOC=(case when ORDER_CONTEXT like '%转%'then null else  order_doc end) --add by zouchihua 2012-8-6 增加停嘱医生
			,LASTEXECDATE=GETDATE()--mod by jchl 2015-05-29[停嘱记录操作时间]
			WHERE GROUP_ID=@GROUPID AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
			      AND (MNGTYPE=0 OR MNGTYPE=2) AND NTYPE = 0   --MODIFY BY TANY 2004-12-31 只有0和7的医嘱
		        IF @@ERROR<>0 
	                BEGIN            
	                    SET @OUTCODE=@@ERROR
	                    SET @OUTMSG='更新医嘱表出院医嘱信息出错！'
	                    ROLLBACK TRAN
	                    RETURN            
	                END
			      -------同时更新临时表
             
             UPDATE #temp_zy_orderrecord
			SET STATUS_FLAG=5,ORDER_EDATE=(case when ORDER_CONTEXT like '%转%'then null else  @EXECBOOKDATE end),
			ORDER_EDOC=(case when ORDER_CONTEXT like '%转%'then null else  order_doc end) --add by zouchihua 2012-8-6 增加停嘱医生
			,LASTEXECDATE=GETDATE()--mod by jchl 2015-05-29[停嘱记录操作时间]
			WHERE GROUP_ID=@GROUPID AND INPATIENT_ID=@INPATIENTID AND BABY_ID=@BABYID
			      AND (MNGTYPE=0 OR MNGTYPE=2) AND NTYPE = 0   --MODIFY BY TANY 2004-12-31 只有0和7的医嘱
             ------
			
			
			COMMIT
			RETURN
		     END--020201
                END--0202
	END--02
	
    SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,1,@CUREXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)

COMMIT
END--WHILE
	drop table   #ZY_ORDEREXEC
	drop table   #temp_zy_orderrecord
	drop table   #temp_ZY_ORDEREXEC
 
 




GO


