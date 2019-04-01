IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ZYHS_ORDERPRINT_cz]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ZYHS_ORDERPRINT_cz]
GO
create PROCEDURE [dbo].[SP_ZYHS_ORDERPRINT_cz]  
 (  
  @INPATIENT_ID UNIQUEIDENTIFIER,  
  @BABY_ID BIGINT,  
  @ORDER_TYPE SMALLINT,  
  @TYPE SMALLINT,  
  @USER_ID BIGINT,  
  @BPAGE_NO INT,  
  @EPAGE_NO INT,  
  @OUTCODE INT OUTPUT,  
  @OUTMSG VARCHAR(50) OUTPUT ,
  @Brow int,--开始行
  @Erow int-- 结束行 
 )  
AS  
  
/*--------------------------------------------------------------------------  
作者：TANY  
说明：住院护士站-生成医嘱打印信息  
日期：2007-01-30  
参数：  
 @INPATIENT_ID  住院号,  
 @BABY_ID      婴儿号 ,  
 @ORDER_TYPE  医嘱类型（0=长期 1=临时）,  
 @TYPE              操作类别（0=生成和更新医嘱 1=查询本次打印医嘱内容 2=打印后更新 3=补打 4=查询本次打印医嘱内容但获得用户的id（1 获得姓名））5=补打医嘱内容但获得用户的id（3 获得姓名））  
 @USER_ID      操作员编号  
 @BPAGE_NO          开始页码号,  --@TYPE=3使用  
 @EPAGE_NO          结束页码号   --@TYPE=3使用  
 @OUTMSG            传出信息  
修改：  
 BY TANY AT 2004-08-24 加入对 ##temporder  DEPT_BR=DEPT_ID  的判断  
 BY TANY AT 2004-09-11 屏蔽部分功能，修改排序方式（改为按照PAGENO,ROWNO和GROUP_ID,ORDER_ID排序）  
 BY TANY AT 2004-09-13 草药不显示明细  
 BY TANY AT 2004-09-14 增加SERIAL_NO排序（即医生录入顺序）  
 BY TANY AT 2004-10-05 增加##temporder表的DELETE_BIT=0的判断  
 BY TANY AT 2004-10-06 增加##temporder表新类型的判断MNGTYPE=5（交病人），连接YK_VYD视图  
 BY TANY AT 2004-10-07 根据医嘱类型设置长度  
 BY TANY AT 2004-10-20 说明性医嘱的用法需要打印  
 BY TANY AT 2005-06-06 把  DEPT_BR=DEPT_ID 改成 DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT)  
 BY TANY AT 2011-01-21 增加##temporder表的DEL_PRINT=0的判断
					   增加##temporder表的SSMZ_PRINT=1的判断
 BY ZOUCHIHUA AT 2011-08-31  增加@TYPE =4的情况，图片签名时表示获得用户id
                              增加@TYPE =5的情况，图片签名时表示获得用户id--------------------------------------------------------------------------*/  
SET NOCOUNT ON  
  
SET @OUTCODE=0  
SET @OUTMSG='执行成功！'  
  
--自定义变量  
DECLARE @COUNTS    INT   --记录数  
DECLARE @LOGROWS  INT   --页面总行数LONGORDER  
DECLARE @TMPROWS  INT   --页面总行数TEMPORDER  
DECLARE @LOGORDERWIDTH INT  --长期医嘱宽度  
DECLARE @TMPORDERWIDTH INT  --临时医嘱宽度  
DECLARE @LOGORDERWIDTH_YP INT  --长期医嘱宽度_药品  
DECLARE @TMPORDERWIDTH_YP INT  --临时医嘱宽度_药品  
DECLARE @LOGORDERWIDTH_XM INT  --长期医嘱宽度_项目  
DECLARE @TMPORDERWIDTH_XM INT  --临时医嘱宽度_项目  
DECLARE @MAXPAGENO INT   --最大页号  
DECLARE @MAXROWNO  INT   --最大行号  
DECLARE @PAGESTATUS INT  --页标志（0=页开始，1=页中间，2=页结束）  
DECLARE @ROWSTATUS INT   --行标志（0=单行，1=折行首行，2=折行其他行）  
DECLARE @GROUPSTATUS INT --组标志（0=单条医嘱，1=组开始，2=组中间，3=组结束）  
DECLARE @PRTSTATUS INT   --打印状态（-1=完全打印 0=未打印 1=已打印开始 2=打印停止 3=打印完成, 4=打印取消【add by zouchihua 2013-11-22】）  
DECLARE @GROUPID   INT   --组号  
DECLARE @GROUPID1  INT   --组号1  
DECLARE @GROUPCOUNT INT  --组成员数  
DECLARE @ROWCOUNT   INT  --折行数  
DECLARE @ROWCOUNTS  INT  --一组的总行数  
DECLARE @I          INT  --计数器（组）  
DECLARE @J          INT  --计数器（行）  
DECLARE @K          INT  --计数器（行）  
DECLARE @M          INT  --计数器（行）  
DECLARE @LEN        INT  --取折行医嘱的长度  
DECLARE @LASTROWS   INT  --剩余行数  
DECLARE @CyyzKsrq  datetime --出院医嘱开始日期 add by  zouchihua
DECLARE @ShYzKsRq datetime --术后医嘱开始日期
DECLARE @ChYzKsRq datetime --产后医嘱开始日期
DECLARE @ZkYzKsRq datetime --转科医嘱开始日期
DECLARE @deptbr bigint --病人科室id  add by zouchihua
declare @old_deptbr bigint
set @old_deptbr=-1--dbo.FUN_GETEMPTYGUID
set @deptbr=0
--游标需要的变量  
DECLARE @CS_INPATIENT_ID UNIQUEIDENTIFIER  
DECLARE @CS_BABY_ID BIGINT  
DECLARE @CS_ORDER_ID UNIQUEIDENTIFIER  
DECLARE @CS_GROUP_ID INT  
DECLARE @CS_ORDER_BDATE DATETIME  
DECLARE @CS_NTYPE INT  
DECLARE @CS_ORDER_CONTEXT VARCHAR(100)  
DECLARE @CS_NUM DECIMAL(18,3)  
DECLARE @CS_DOSAGE INT  
DECLARE @CS_UNIT VARCHAR(50)  
DECLARE @CS_ORDER_SPEC VARCHAR(50)  
DECLARE @CS_ORDER_USAGE VARCHAR(50)  
DECLARE @CS_FREQUENCY VARCHAR(50)  
DECLARE @CS_ORDER_DOC BIGINT  
DECLARE @CS_AUDITING_USER BIGINT  
DECLARE @CS_AUDITING_USER1 BIGINT  
DECLARE @CS_ORDER_EDATE DATETIME  
DECLARE @CS_ORDER_EDOC BIGINT  
DECLARE @CS_ORDER_EUSER BIGINT  
DECLARE @CS_ORDER_EUSER1 BIGINT  
DECLARE @CS_STATUS_FLAG INT  
DECLARE @CS_SERIAL_NO INT  
DECLARE @CS_EXEUSER BIGINT  
DECLARE @CS_EXECDATE DATETIME  
DECLARE @CS_REALEXECDATE DATETIME  
DECLARE @CS_REALEXEUSER BIGINT  
DECLARE @CS_REALEXEUSER1 BIGINT  --add by zouchihua 2012-3-29 双签名
DECLARE @CS_DROPSPER  varchar(20) --add by zouchihua 2011_09_10 滴度 
DECLARE @ROWS  varchar(20) --add by zouchihua 2011_09_10 滴度
declare @old_bdate DATETIME --add by zouchihua 2011_12_26 记录转科后第一条医嘱时间
declare @cs_tcid int
--add by zouchihua 2013-7-12
--declare @cfg7114 varchar
--set @cfg7114=(select cast(isnull(config,1) as int) from jc_config where id=7114)

declare @cfg7171 int
set @cfg7171=(select cast(isnull(config,0) as int) from jc_config where id=7171)

declare @cfg7172 int 
set @cfg7172=(select cast(isnull(config,0) as int) from jc_config where id=7172)

declare @cfg7173 varchar(500)
set @cfg7173=(select  isnull(config,'')  from jc_config where id=7173)
declare @cfg7177 varchar(5)
set @cfg7177=(select  isnull(config,'0')  from jc_config where id=7177)

declare @cfg7178 varchar(10)
set @cfg7178=(select  isnull(config,'0')  from jc_config where id=7178)



declare @zcyxsmc varchar
set @zcyxsmc=(select top 1 isnull(config,0) from JC_CONFIG where ID=6070)--add by zouchihua 2013-8-4 增加中草药的备注
declare @zl decimal(18,3) --add by zouchihua 2012-12-11 总量
declare @zldw varchar(20) --add by zouchihua 2012-12-11 总量单位
declare @mryf varchar(20) --add by zouchihua 2013-5-10 临时医嘱打印：mngtype=5的医嘱用法后面增加的默认用法。例如：交病人
set @mryf='交病人'
select  @mryf=isnull(config,'交病人')  from jc_config where id=7151
--add by zouchihua 2013-7-9 拆零口服药
 declare @clkfy varchar(100) 
 set @clkfy=(select isnull(config,'') from jc_config where id=7155)
 if(@clkfy<>'')
   set @clkfy=','+@clkfy+','
--声明临时表 记录医嘱记录
declare @TABLENAME1 varchar(100)  
set @TABLENAME1='##temporder'
EXEC('IF EXISTS(SELECT NAME FROM TEMPDB..SYSOBJECTS WHERE  NAME = ''' +@TABLENAME1+ ''')
	 DROP TABLE [' + @TABLENAME1 +']')
select * into ##temporder from  (select ORDER_ID,GROUP_ID,INPATIENT_ID,DEPT_ID,WARD_ID,MNGTYPE,NTYPE,ORDER_DOC,HOITEM_ID,ITEM_CODE,XMLY,
				case when (@cfg7177=0 or XMLY=2 ) 
				/*
               Modify by jchl
               then  ORDER_CONTEXT 
               else substring(ORDER_SPEC,1,CHARINDEX('%',ORDER_SPEC))+ORDER_CONTEXT  
               end ORDER_CONTEXT,
               */
               then 
				 case when CHARINDEX( '【取消】',ORDER_CONTEXT)>0
					 then
					 substring(ORDER_CONTEXT,CHARINDEX( '【取消】',ORDER_CONTEXT),4)+isnull((select top 1 YPSPMBZ  from VI_YP_YPCD d where d.cjid=a.HOITEM_ID and xmly=1),'')+substring(ORDER_CONTEXT,5,LEN(ORDER_CONTEXT)-4)+( case when ORDER_USAGE like '%皮试%' and rtrim(ORDER_SPEC)!='' then  '('+ORDER_SPEC+')'  else '' end)
					 else 
					 isnull((select top 1 YPSPMBZ  from VI_YP_YPCD d where d.cjid=a.HOITEM_ID and xmly=1),'')+ORDER_CONTEXT+( case when ORDER_USAGE like '%皮试%' and rtrim(ORDER_SPEC)!='' then  '('+ORDER_SPEC+')'  else '' end) end
                else 
                 isnull((select top 1 YPSPMBZ  from VI_YP_YPCD d where d.cjid=a.HOITEM_ID and xmly=1),'')+substring(ORDER_SPEC,1,CHARINDEX('%',ORDER_SPEC))+ORDER_CONTEXT 
                end ORDER_CONTEXT ,
            NUM,
			DOSAGE,UNIT,ORDER_SPEC,BOOK_DATE,ORDER_BDATE,FIRST_TIMES,
			 ORDER_USAGE,
			 case 
				when exists (select * from JC_FREQUENCY where name=A.FREQUENCY and isprint=1)  
				then isnull((select top 1 printname from JC_FREQUENCY where name=A.FREQUENCY and LTRIM(RTRIM(printname))<>''), FREQUENCY)
				else ''  end FREQUENCY,
			OPERATOR,DELETE_BIT,STATUS_FLAG,
			BABY_ID,DEPT_BR,EXEC_DEPT,DROPSPER,SERIAL_NO,PS_FLAG,PS_ORDERID,DWLX,JZ_FLAG,JGBM,ISKDKSLY ,Apply_type,jsd,
			ts,
			case when  @clkfy='' or ( a.xmly=1 and  CHARINDEX(  ','+(select top 1 TLFL  from VI_YP_YPCD d where d.cjid=a.HOITEM_ID )+',',@clkfy )>0 ) then  zsl else null end zsl,
			case when @clkfy='' or (  a.xmly=1 and  CHARINDEX( ','+(select top 1 TLFL  from VI_YP_YPCD d where d.cjid=a.HOITEM_ID)+',',@clkfy )>0 )  then  zsldw else null end zsldw,
			jldwlx,ssmz_print,DEL_PRINT,MEMO,MEMO1,MEMO2,IsprintYPGG,ORDER_EDATE
			,WZX_FLAG ,AUDITING_USER,AUDITING_USER1, ORDER_EDOC ,ORDER_EUSER,ORDER_EUSER1,0 tcid 
			 from ZY_ORDERRECORD A  
			 where INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID and mngtype in(0,1,5) and delete_bit=0
			     and a.STATUS_FLAG in (1,2)--modify by jchl(未转抄也能打印)
union all select ORDER_ID,GROUP_ID,INPATIENT_ID,DEPT_ID,WARD_ID,MNGTYPE,NTYPE,ORDER_DOC,HOITEM_ID,ITEM_CODE,XMLY,
				case when (@cfg7177=0 or XMLY=2 ) 
				/*
               Modify by jchl
               then  ORDER_CONTEXT 
               else substring(ORDER_SPEC,1,CHARINDEX('%',ORDER_SPEC))+ORDER_CONTEXT  
               end ORDER_CONTEXT,
               */
               then 
				 case when CHARINDEX( '【取消】',ORDER_CONTEXT)>0
					 then
					 substring(ORDER_CONTEXT,CHARINDEX( '【取消】',ORDER_CONTEXT),4)+isnull((select top 1 YPSPMBZ  from VI_YP_YPCD d where d.cjid=a.HOITEM_ID and xmly=1),'')+substring(ORDER_CONTEXT,5,LEN(ORDER_CONTEXT)-4)+( case when ORDER_USAGE like '%皮试%' and rtrim(ORDER_SPEC)!='' then  '('+ORDER_SPEC+')'  else '' end)
					 else 
					 isnull((select top 1 YPSPMBZ  from VI_YP_YPCD d where d.cjid=a.HOITEM_ID and xmly=1),'')+ORDER_CONTEXT+( case when ORDER_USAGE like '%皮试%' and rtrim(ORDER_SPEC)!='' then  '('+ORDER_SPEC+')'  else '' end) end
                else 
                 isnull((select top 1 YPSPMBZ  from VI_YP_YPCD d where d.cjid=a.HOITEM_ID and xmly=1),'')+substring(ORDER_SPEC,1,CHARINDEX('%',ORDER_SPEC))+ORDER_CONTEXT 
                end ORDER_CONTEXT ,
NUM,
			DOSAGE,UNIT,ORDER_SPEC,BOOK_DATE,ORDER_BDATE,FIRST_TIMES,
			 ORDER_USAGE,
			 case 
				when exists (select * from JC_FREQUENCY where name=A.FREQUENCY and isprint=1)  
				then isnull((select top 1 printname from JC_FREQUENCY where name=A.FREQUENCY and LTRIM(RTRIM(printname))<>''), FREQUENCY)
				else ''  end FREQUENCY,
			OPERATOR,DELETE_BIT,STATUS_FLAG,
			BABY_ID,DEPT_BR,EXEC_DEPT,DROPSPER,SERIAL_NO,PS_FLAG,PS_ORDERID,DWLX,JZ_FLAG,JGBM,ISKDKSLY ,Apply_type,jsd,
			ts,
			case when @clkfy='' or (  xmly=1 and  CHARINDEX( ','+(select top 1 TLFL  from VI_YP_YPCD d where cjid=HOITEM_ID)+',',@clkfy )>0)  then  zsl else null end zsl,
			case when @clkfy='' or (  xmly=1 and  CHARINDEX( ','+(select top 1 TLFL  from VI_YP_YPCD d where cjid=HOITEM_ID)+',',@clkfy )>0 ) then  zsldw else null end zsldw,
			jldwlx,ssmz_print,DEL_PRINT,MEMO,MEMO1,MEMO2,IsprintYPGG,ORDER_EDATE 
			,WZX_FLAG ,AUDITING_USER,AUDITING_USER1, ORDER_EDOC ,ORDER_EUSER,ORDER_EUSER1 ,0 tcid
			from  ZY_ORDERRECORD_H A where INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID and mngtype in(0,1,5) and delete_bit=0 
			and a.STATUS_FLAG in (1,2)) a  --modify by jchl(未转抄也能打印) 
            ORDER BY ORDER_BDATE,GROUP_ID,SERIAL_NO,ORDER_ID  
            
declare @dymx varchar
set @dymx=(select isnull(config,0) from jc_config where id=7147)

 --------------------------------------去掉不需要打印的开单科室id
  --add by zouchihua 2012-5-30 那些开单科室不打印
 declare @cfg_7126 varchar(50)
 set @cfg_7126=isnull( (select CONFIG from jc_config where id=7126) ,'-1')
    declare @str_7126 int
  if @cfg_7126 is not null
  begin
     WHILE CHARINDEX(',',@cfg_7126) > 0
     begin
        set @str_7126=LEFT(@cfg_7126,CHARINDEX(',',@cfg_7126)-1)
        set @cfg_7126=right(@cfg_7126,LEN(@cfg_7126)- CHARINDEX(',',@cfg_7126))
        delete from ##temporder where dept_id=@str_7126
     end
      delete from ##temporder where dept_id=@cfg_7126
  end
 ---------------------------------------

  if rtrim(@dymx)='1'
  --处理套餐
  begin
           declare @tcorderid UNIQUEIDENTIFIER
           declare @tctcid bigint 
            IF EXISTS(SELECT NAME FROM TEMPDB..SYSOBJECTS WHERE  NAME = '##tc_order')
	                DROP TABLE ##tc_order
			--查出所有套餐id
			select a.ORDER_ID,c.HOITEM_ID  into ##tc_order  from ##temporder a 
			left join JC_HOITEMDICTION b  on a.HOITEM_ID=b.ORDER_ID
			left join  JC_HOI_HDI c on b.ORDER_ID=c.HOITEM_ID 
			 where a.INPATIENT_ID=@INPATIENT_ID   and a.XMLY=2 and isnull(c.TCID,-1)>0
             --声明游标
             DECLARE TcCur CURSOR FOR    select ORDER_ID,HOITEM_ID from ##tc_order a
              open TcCur
              FETCH NEXT FROM TcCur into  @tcorderid,@tctcid
            WHILE @@FETCH_STATUS = 0  
            begin
                  --根据医嘱找出套餐
                  insert into  ##temporder
			 select a.ORDER_ID,GROUP_ID,INPATIENT_ID,DEPT_ID,WARD_ID,MNGTYPE,NTYPE,ORDER_DOC,d.MAINITEM_ID,ITEM_CODE,XMLY,
			 (case when WZX_FLAG>0 then '【取消】' else '' end )+(select top 1 ITEM_NAME from JC_HSITEM where ITEM_ID=d.SUBITEM_ID)  ORDER_CONTEXT,a.NUM*c.NUM*d.NUM,
			DOSAGE,UNIT,a.ORDER_SPEC,BOOK_DATE,ORDER_BDATE,FIRST_TIMES,ORDER_USAGE,FREQUENCY,OPERATOR,a.DELETE_BIT,STATUS_FLAG,
			BABY_ID,DEPT_BR,EXEC_DEPT,DROPSPER,SERIAL_NO,PS_FLAG,PS_ORDERID,DWLX,JZ_FLAG,JGBM,ISKDKSLY ,Apply_type,jsd,
			ts,zsl,zsldw,jldwlx,ssmz_print,DEL_PRINT,MEMO,MEMO1,MEMO2,IsprintYPGG,ORDER_EDATE
			,WZX_FLAG ,AUDITING_USER,AUDITING_USER1, ORDER_EDOC ,ORDER_EUSER,ORDER_EUSER1,c.TCID from ##temporder a left join JC_HOITEMDICTION b  on a.HOITEM_ID=b.ORDER_ID
			left join  JC_HOI_HDI c on b.ORDER_ID=c.HOITEM_ID 
			left join JC_TC_MX d on d.MAINITEM_ID=c.TCID
			 where a.ORDER_ID= @tcorderid and a.HOITEM_ID= @tctcid  and XMLY=2 and isnull(c.TCID,-1)>0
             --删除原来套餐医嘱
              delete from  ##temporder where order_id=@tcorderid  and  HOITEM_ID=@tctcid and xmly=2
              
              FETCH NEXT FROM TcCur into  @tcorderid,@tctcid
            end 
            
            
            CLOSE TcCur  
            DEALLOCATE TcCur 
end
--处理套餐





set @old_bdate=getdate()
--set @Tsapply_id= 
 --add by zouchihua 
 --医嘱打印转科，术后，出院自动停医嘱是否打印，0=打印，1=不打印 
 if  isnull((select config from jc_config where id=7800),0)=1
  begin
 select @CyyzKsrq=ORDER_BDATE from ##temporder where NTYPE=0 and (ORDER_CONTEXT like '%出院%' or ORDER_CONTEXT like '%死亡%') and INPATIENT_ID=@INPATIENT_ID  and BABY_ID=@BABY_ID and  delete_bit=0 
 select @ZkYzKsRq=ORDER_BDATE from ##temporder where NTYPE=0 and ORDER_CONTEXT like '%转%' and  INPATIENT_ID=@INPATIENT_ID  and BABY_ID=@BABY_ID and  delete_bit=0
     --order by ORDER_BDATE desc
    -- and order_id not in(select ORDER_ID from ZY_LOGORDERPRT where  INPATIENT_ID=@INPATIENT_ID  and BABY_ID=@BABY_ID)
 select @ShYzKsRq=ORDER_BDATE from ##temporder where NTYPE=0 and ( ORDER_CONTEXT like '%术后医嘱%'or ORDER_CONTEXT like '%产后医嘱%')   and  INPATIENT_ID=@INPATIENT_ID  and BABY_ID=@BABY_ID and  delete_bit=0
 --order by ORDER_BDATE desc
     --and order_id not in(select ORDER_ID from ZY_LOGORDERPRT where  INPATIENT_ID=@INPATIENT_ID  and BABY_ID=@BABY_ID)
 end
 
 --add by zouchihua 2011-12-07
 DECLARE @jy_dept int
 set @jy_dept=-1
 select @jy_dept=dept_id from jc_dept_property where name='检验科'
 
 --add by zouchihua 2012-5-30 那些开单科室不打印
 declare @cfg7126 varchar(50)
 set @cfg7126=isnull( (select CONFIG from jc_config where id=7126) ,'-1')
set @cfg7126=-1
 --add by zouchihua 2012-11-12临时医嘱打印：项目数量为1时是否打印数量和单位
 declare @cfg7139 varchar(50)
 set @cfg7139=isnull( (select CONFIG from jc_config where id=7139) ,'0')
  
 
 declare @cfg7138 varchar(50)
     set @cfg7138=isnull( (select CONFIG from jc_config where id=7138) ,'0')
   --add by zouchihua 医嘱打印是否打印中草药明细0=否，1=是
  declare @cs7136 varchar(5)
  set  @cs7136=(select top 1 isnull(config,0) from jc_config where id=7136)
  
 
declare @TABLENAME varchar(50)
set @TABLENAME='##temp_cy_order'
 declare @cy_orderid UNIQUEIDENTIFIER 
  declare @flagcount int
  declare @csgroupid int
   declare @csoldgroupid int
  declare @mysql varchar(200)
  EXEC('IF EXISTS(SELECT NAME FROM TEMPDB..SYSOBJECTS WHERE  NAME = ''' +@TABLENAME+ ''')
	 DROP TABLE [' + @TABLENAME +']')
 select order_id,group_id into ##temp_cy_order from ##temporder  where 1=2--获得临时表结构
-- print CAST (@CyyzKsrq as varchar(100))
/*************************************************************************************  
***********************************过 程 主 体****************************************  
*************************************************************************************/  

IF @TYPE=0     
BEGIN  
 --变量附初值  
 SELECT @LOGROWS=X FROM ZY_ORDERPRTCFG WHERE ID=32  
 SELECT @TMPROWS=X FROM ZY_ORDERPRTCFG WHERE ID=49  
 SELECT @LOGORDERWIDTH_YP=X FROM ZY_ORDERPRTCFG WHERE ID=33 --药品长度  
 SELECT @TMPORDERWIDTH_YP=X FROM ZY_ORDERPRTCFG WHERE ID=34 --药品长度  
 SELECT @LOGORDERWIDTH_XM=X FROM ZY_ORDERPRTCFG WHERE ID=39 --项目长度  
 SELECT @TMPORDERWIDTH_XM=X FROM ZY_ORDERPRTCFG WHERE ID=40 --项目长度  
 SET @ROWSTATUS=0   --行标志（0=单行，1=折行首行，2=折行其他行）  
 SET @GROUPSTATUS=0 --组标志（0=单条医嘱，1=组开始，2=组中间，3=组结束）  
 SET @PRTSTATUS=0  
 SET @GROUPID=0  
 SET @GROUPCOUNT=0  --组成员数  
 SET @ROWCOUNT=0  
 SET @ROWCOUNTS=0  
 SET @I=1  
 SET @J=1  
 SET @K=1  
 SET @M=1  

 IF @ORDER_TYPE=0--长期医嘱  
 BEGIN    
  IF (SELECT COUNT(*)  
      FROM ZY_LOGORDERPRT  
      WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID)=0  
  BEGIN  
   SET @MAXPAGENO=1  
   SET @MAXROWNO=1  
   SET @PAGESTATUS=0  --页标志（0=页开始，1=页中间，2=页结束）  
  END  
  ELSE  
  BEGIN  
   SELECT @MAXPAGENO=MAX(PAGENO)     --取最大页数  
   FROM ZY_LOGORDERPRT  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   SELECT @MAXROWNO=MAX(ROWNO) --取最大行数  
   FROM ZY_LOGORDERPRT  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO=@MAXPAGENO  
   --如果当前行是最后一行，则换页  
   IF @MAXROWNO=@LOGROWS  
   BEGIN  
    SET @MAXPAGENO=@MAXPAGENO+1  
    SET @MAXROWNO=1  
    SET @PAGESTATUS=0  
   END  
   ELSE IF @LOGROWS=@MAXROWNO+1  
   BEGIN  
    SET @MAXROWNO=@MAXROWNO+1  
    SET @PAGESTATUS=2  
   END  
   ELSE  
   BEGIN  
    SET @MAXROWNO=@MAXROWNO+1  
    SET @PAGESTATUS=1  
   END  
  END  
   
   
   
  --如果有未审核的医嘱在审核了的医嘱之前，则返回不处理  
  IF(SELECT COUNT(*)  
     FROM  ##temporder  
     WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND STATUS_FLAG IN (1)   
    AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept  and dept_id not in (@cfg7126) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0 
                         AND ORDER_BDATE < (SELECT MAX(ORDER_BDATE) AS ORDER_ID FROM ##temporder  
                           WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND STATUS_FLAG NOT IN (0,1,9)   
                                               AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126)  AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
                                               AND ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID)) )<>0  
  BEGIN  
   SET @OUTCODE=-1  
   SET @OUTMSG='该病人有未转抄的长期医嘱，请转抄后再打印！'  
     ------------------------
   SELECT CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
    ORDER_CONTEXT,  
    CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
    CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
    CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
    CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
    ORDER_ID,0 prt_status
   FROM ZY_LOGORDERPRT  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   ORDER BY PAGENO,ROWNO   
  
   RETURN -1  
  END  
   -------------------如果有未核对或者没有皮试结果
    if  @cfg7178='1'
    begin
   IF(SELECT COUNT(*)  
     FROM  ##temporder  
     WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND STATUS_FLAG >1
       and (isnull(AUDITING_USER1,0)<=0 or  (status_flag>=3 and  isnull(ORDER_EUSER1,0)<=0 ))  
    --AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept  and dept_id not in (@cfg7126) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0 
    --                     AND ORDER_BDATE < (SELECT MAX(ORDER_BDATE) AS ORDER_ID FROM ##temporder  
    --                       WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND STATUS_FLAG NOT IN (0,1,9)   
    --                                           AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126)  AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
    --                                           AND ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID)) 
                                               )<>0  
   begin
      SET @OUTCODE=-1  
   SET @OUTMSG='该病人有未核对的长期医嘱，请核对后再打印！'  
    SELECT CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
    ORDER_CONTEXT,  
    CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
    CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
    CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
    CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
    CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
    ORDER_ID,0 prt_status
   FROM ZY_LOGORDERPRT  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   ORDER BY PAGENO,ROWNO  
   
   return -1
   end
    end
   
   ----------------------如果有未核对或者没有皮试结果

     --add by zouchihua 处理草药
  -------------------  --add by zouchihua 2011-12-07
  delete from ##temp_cy_order
  set @flagcount=0;
  DECLARE Tt2 CURSOR FOR    select order_id,GROUP_ID from ##temporder a
  WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND STATUS_FLAG NOT IN (0,1,9) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126)   AND  
  -- ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID) AND  
  -- GROUP_ID NOT IN (SELECT GROUP_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID GROUP BY GROUP_ID) AND  
   NTYPE =3 AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
  order BY order_bdate,GROUP_ID
  open Tt2
   FETCH NEXT FROM Tt2 into  @cy_orderid,@csgroupid
   WHILE @@FETCH_STATUS = 0  
   begin
       if @flagcount=0
         begin 
          insert into ##temp_cy_order(order_id,group_id) values (@cy_orderid,@csgroupid)
          set @csoldgroupid=@csgroupid
          set @flagcount=1
          end
       else
          if @csgroupid<>@csoldgroupid
            begin
             insert into ##temp_cy_order(order_id,group_id) values (@cy_orderid,@csgroupid)
            set @csoldgroupid=@csgroupid
            end
    FETCH NEXT FROM Tt2 into  @cy_orderid,@csgroupid  
   end
  CLOSE Tt2  
  DEALLOCATE Tt2  

  
  if (@cs7136='0')
  --插入新的医嘱  
  --草药不显示明细 ADD BY TANY 20040913  
  --判断用法是否用于打印显示 MODIFY BY TANY 2004-10-10  
  DECLARE T1 CURSOR FOR  
  SELECT INPATIENT_ID,BABY_ID,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,LTRIM(RTRIM(ORDER_CONTEXT))+(case when a.WZX_FLAG>0 and @cfg7138='1' then '【原因：'+memo2+'】' else '' end)    ORDER_CONTEXT,NUM,DOSAGE,UNIT,case when isprintypgg is null or isprintypgg=0 then '' else LTRIM(RTRIM(ORDER_SPEC)) end ORDER_SPEC, --modify by zouchihua 2011-11-30 规格是否打印
   CASE B.IS_PRINT 
   WHEN 0 
   THEN case when LTRIM(RTRIM(isnull(printname,'')))='' then ORDER_USAGE else  printname end   --THEN LTRIM(RTRIM(isnull(B.printname, ORDER_USAGE)))
   +CASE WHEN PS_FLAG=1 THEN ' (-)' WHEN PS_FLAG=2 THEN ' (+)' WHEN PS_FLAG=21 THEN ' (++)' WHEN PS_FLAG=22 THEN ' (+++)' ELSE '' END 
   ELSE '' END ORDER_USAGE,  
   FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,ORDER_EDATE,ORDER_EDOC,ORDER_EUSER,ORDER_EUSER1,STATUS_FLAG,SERIAL_NO,dropsper,tcid  --滴度 
  FROM ##temporder A LEFT JOIN(SELECT NAME,IS_PRINT,printname FROM JC_USAGEDICTION WHERE NAME <> '') B ON A.ORDER_USAGE=B.NAME  
  WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND STATUS_FLAG NOT IN (0,9) -- AND STATUS_FLAG NOT IN (0,1,9) Modify by jchl
   AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND  
 --  ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID and PRT_STATUS not in(3,4)) AND  
   NTYPE <>3 AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
  UNION ALL  
  SELECT INPATIENT_ID,BABY_ID,ORDER_ID ORDER_ID,GROUP_ID,ORDER_BDATE ORDER_BDATE,NTYPE,case when wzx_flag>0 then  '【取消】中草药处方'+(case when a.WZX_FLAG>0 and @cfg7138='1' then '【原因：'+memo2+'】' else '' end) 
  else 
    '中草药处方' +case when @zcyxsmc='0' then '' else  (case when rtrim(isnull(MEMO,''))!=''   then '【'+isnull(MEMO,'')+'】' else isnull((select top 1 '【'+MBMC+'】' from  jc_cfmb where MBXH=A.PS_ORDERID),'') end  )   end
  end  AS ORDER_CONTEXT,  
   0 NUM,DOSAGE,'付' UNIT,ORDER_SPEC,LTRIM(RTRIM(isnull((select printname from JC_USAGEDICTION D where D.NAME=ORDER_USAGE and LTRIM(RTRIM(printname))<>'' and D.IS_PRINT=0), ORDER_USAGE))) as ORDER_USAGE,FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,  
   ORDER_EDATE ORDER_EDATE,ORDER_EDOC,ORDER_EUSER,ORDER_EUSER1,STATUS_FLAG,0 SERIAL_NO,dropsper ,tcid --滴度 
  FROM ##temporder  a
  WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND STATUS_FLAG NOT IN (0,9)-- AND STATUS_FLAG NOT IN (0,1,9) Modify by jchl
  AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND  
   --ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID and PRT_STATUS not in(3,4)) AND  
   --GROUP_ID NOT IN (SELECT GROUP_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID and PRT_STATUS not in(3,4) GROUP BY GROUP_ID) AND  
   NTYPE =3 AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0 
    and  order_id in(select order_id  from ##temp_cy_order) --add by zouchihua  处理草药
--  GROUP BY INPATIENT_ID,BABY_ID,GROUP_ID,NTYPE,NUM,DOSAGE,ORDER_SPEC,ORDER_USAGE,FREQUENCY,  
--   ORDER_DOC,AUDITING_USER,AUDITING_USER1,ORDER_EDOC,ORDER_EUSER,ORDER_EUSER1,STATUS_FLAG  
  ORDER BY ORDER_BDATE,GROUP_ID,SERIAL_NO,ORDER_ID  
    else
      begin
       DECLARE T1 CURSOR FOR  
	  SELECT INPATIENT_ID,BABY_ID,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,LTRIM(RTRIM(ORDER_CONTEXT))+(case when a.WZX_FLAG>0 and @cfg7138='1' then '【原因：'+memo2+'】' else '' end) ORDER_CONTEXT,NUM,DOSAGE,UNIT,case when isprintypgg is null or isprintypgg=0 then '' else LTRIM(RTRIM(ORDER_SPEC)) end ORDER_SPEC, --modify by zouchihua 2011-11-30 规格是否打印
	   CASE B.IS_PRINT 
	   WHEN 0 
	   THEN case when LTRIM(RTRIM(isnull(printname,'')))='' then ORDER_USAGE else  printname end   --THEN LTRIM(RTRIM(isnull(B.printname, ORDER_USAGE)))
	   +CASE WHEN PS_FLAG=1 THEN ' (-)' WHEN PS_FLAG=2 THEN ' (+)' WHEN PS_FLAG=21 THEN ' (++)' WHEN PS_FLAG=22 THEN ' (+++)' ELSE '' END 
	   ELSE '' END ORDER_USAGE,  
	   FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,ORDER_EDATE,ORDER_EDOC,ORDER_EUSER,ORDER_EUSER1,STATUS_FLAG,SERIAL_NO,dropsper ,tcid --滴度 
	  FROM ##temporder A LEFT JOIN(SELECT NAME,IS_PRINT,printname FROM JC_USAGEDICTION WHERE NAME <> '') B ON A.ORDER_USAGE=B.NAME  
	  WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND STATUS_FLAG NOT IN (0,9)-- AND STATUS_FLAG NOT IN (0,1,9) Modify by jchl
	   AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND  
	  -- ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID and PRT_STATUS not in(3,4) ) AND  
	     DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0 
	     ORDER BY ORDER_BDATE,GROUP_ID,SERIAL_NO,ORDER_ID 
      end
      
  OPEN T1  
    
  FETCH NEXT FROM T1   
  INTO @CS_INPATIENT_ID,@CS_BABY_ID,@CS_ORDER_ID,@CS_GROUP_ID,  
   @CS_ORDER_BDATE,@CS_NTYPE,@CS_ORDER_CONTEXT,@CS_NUM,  
   @CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,  
   @CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,  
   @CS_AUDITING_USER1,@CS_ORDER_EDATE,@CS_ORDER_EDOC,  
   @CS_ORDER_EUSER,@CS_ORDER_EUSER1,@CS_STATUS_FLAG,@CS_SERIAL_NO,@CS_DROPSPER,  --滴速
   @cs_tcid--套餐
    
  WHILE @@FETCH_STATUS = 0  
  BEGIN  
   --根据医嘱类型设置长度  
   IF @CS_NTYPE IN (1,2,3)  
    SET @LOGORDERWIDTH=@LOGORDERWIDTH_YP  
   ELSE  
    SET @LOGORDERWIDTH=@LOGORDERWIDTH_XM  
  
  --如果是说明医嘱 add by zouchihua 2013-11-19
    if (@CS_NTYPE=7 or @CS_NTYPE=0 ) and rtrim(@CS_FREQUENCY)='' and rtrim(@CS_ORDER_USAGE)=''
      set @LOGORDERWIDTH=(select TOp 1( case when isnull(X,0)=0  then @LOGORDERWIDTH_XM else X end)  from ZY_ORDERPRTCFG where id=91)
  
   --如果医嘱已经停止或执行完成，则打印状态=-1  
   IF @CS_STATUS_FLAG=4 OR @CS_STATUS_FLAG=5  
    SET @PRTSTATUS=-1  
   ELSE  
    SET @PRTSTATUS=0  
  
   --根据组号判断这一组到底有多少项目  
   SET @GROUPID1=@CS_GROUP_ID  
  
   --草药算一条记录 ADD BY TANY 20040914  
   SELECT @GROUPCOUNT=COUNT(*) FROM ##temporder  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1)  and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND GROUP_ID=@GROUPID1  
         AND (case when @cs7136='0' then NTYPE else 1 end )<>3 AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0   
  
   --根据组号判断这一组的项目占多少行  
   SELECT @ROWCOUNTS=SUM(CASE   
                          WHEN (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @LOGORDERWIDTH = 0) OR  
              (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @LOGORDERWIDTH = 1 AND  
       (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) % @LOGORDERWIDTH) = 0)  
     THEN 1  
     WHEN (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @LOGORDERWIDTH <> 0 AND  
          (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) % @LOGORDERWIDTH) <> 0)  
     THEN (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @LOGORDERWIDTH)+1  
     ELSE (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @LOGORDERWIDTH) END)  
   FROM ##temporder  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE=0 AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND GROUP_ID=@GROUPID1 AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0   
    AND ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_LOGORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID  
           AND BABY_ID=@BABY_ID AND GROUP_ID=@GROUPID1)  
  
   --设置组状态  
   --当组的一半先插入表，然后再续插另一半，程序将不能判断。但这种情况不应该出现。  
   IF @GROUPCOUNT=0  
    SET @GROUPCOUNT=1  
  
   IF @GROUPCOUNT=1  
   BEGIN  
       SET @GROUPSTATUS=0  
       SET @I=0  
                        END  
   ELSE IF @CS_GROUP_ID<>@GROUPID  
   BEGIN  
       SET @GROUPSTATUS=1  
   END  
   ELSE IF @CS_GROUP_ID=@GROUPID AND @GROUPCOUNT=@I  
   BEGIN  
       SET @GROUPSTATUS=3  
       SET @I=0    END  
   ELSE  
   BEGIN  
              SET @GROUPSTATUS=2  
   END  
  
   SET @GROUPID=@CS_GROUP_ID--保留这一次的组号留给下一组判断是否发生变化  
   SET @I=@I+1--用来判断是不是组的最后一行了  
  
   --如果剩余的行不够打一组医嘱的行数，则打印竖线并换页  
   --设置折行状态  
   --小于等于一行  
   IF (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @LOGORDERWIDTH = 0) OR  
   (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @LOGORDERWIDTH = 1 AND  
      (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) % @LOGORDERWIDTH) = 0)  
   BEGIN  
       SET @ROWCOUNT=1  
   END  
   ELSE IF (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @LOGORDERWIDTH <> 0 AND  
          (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) % @LOGORDERWIDTH) <> 0)  
   BEGIN  
       SET @ROWCOUNT=(LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @LOGORDERWIDTH)+1  
     END  
   ELSE  
   BEGIN  
       SET @ROWCOUNT=(LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @LOGORDERWIDTH)  
   END  
  
  
 
    --如果不够折行插入，则打空行换页  
     --/* 医院不需要此需求 MODIFY BY zouchihua 2011-11-17  
     set @ROWS=@LOGROWS
     IF @ROWS-@MAXROWNO+1 < @ROWCOUNTS and  (case when @cs7136='0' then @CS_NTYPE else 1 end ) !=3  --@ROWCOUNT
        and isnull(@cs_tcid,0)<=0 and @cfg7172=0
     --THEN 
     begin 
     --set @OUTMSG='dfsdfsd';
      SET @LASTROWS=@ROWS-@MAXROWNO+1  
      WHILE @J <= @LASTROWS 
      begin 
          SET @ROWSTATUS=0  
         --   INSERT INTO ZY_LOGORDERPRT  
         -- VALUES (@cs_INPATIENT_ID,@cs_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,0,@PRTSTATUS,  
         --      @cs_ORDER_ID,@cs_GROUP_ID,@cs_ORDER_BDATE,@CS_NTYPE,'      ┃',@cs_NUM,@cs_DOSAGE,@cs_UNIT,@cs_ORDER_SPEC,@cs_ORDER_USAGE,  
         --@cs_FREQUENCY,@cs_ORDER_DOC,@cs_AUDITING_USER,@cs_ORDER_EDATE,@cs_ORDER_EDOC,@cs_ORDER_EUSER,@USER_ID,'',@CS_DROPSPER)  
           INSERT INTO ZY_LOGORDERPRT  
             VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
                   @CS_ORDER_ID,0,@CS_ORDER_BDATE,null,case when @cfg7173='' then '      ┃' else  @cfg7173 end ,  
       null,null,null,null,null,null,null,null,null,null,  
       null,null,null,null,'',null)   
       SET @J=@J+1  
       --换行换页  
         IF @MAXROWNO=@ROWS
         begin  
           --THEN  
               SET @MAXPAGENO=@MAXPAGENO+1  
               SET @MAXROWNO=1  
               SET @PAGESTATUS=0  
          end
          ELSE IF @ROWS=@MAXROWNO+1  
           --THEN 
           begin 
                 SET @MAXROWNO=@MAXROWNO+1  
                 SET @PAGESTATUS=2 
             end 
          ELSE  
           begin
              SET @MAXROWNO=@MAXROWNO+1  
              SET @PAGESTATUS=1  
            end
          --END IF  
        END-- WHILE 
   END --IF 
    --*/  

	---------------------------------add by zouchihua 2011-12-26 转科医嘱换页-----------------------
--Modify By Tany 2014-10-23 转科医嘱的判断改写，转科医嘱有可能写在临时医嘱也有可能写在长期医嘱
--所以长期和临时使用一样的方式
--
--------------------------------------转科医嘱换页处理开始---------------------------------------
 declare @Sccqflag int
    set @Sccqflag=0
  if isnull((select config from jc_config where id=7100),0)=1 or isnull((select config from jc_config where id=7100),0)=2
  begin
      --if @CS_NTYPE=0 and charindex('转',@CS_ORDER_CONTEXT)>0 --转科医嘱换页
	  --if exists(select 1 from #temporder where NTYPE=0 and ORDER_CONTEXT like '%转%' and  INPATIENT_ID=@INPATIENT_ID  and BABY_ID=@BABY_ID and  delete_bit=0)
	  DECLARE @cs_cqzkrq datetime
       DECLARE Tcqzk CURSOR FOR 
       select ORDER_BDATE from ##temporder where NTYPE=0 and ORDER_CONTEXT like '%转%' 
       and  INPATIENT_ID=@INPATIENT_ID  and BABY_ID=@BABY_ID and  delete_bit=0
       --需要增加判断在转科记录表里面transtype Modify By Tany 2014-12-04
       and ORDER_ID in (select order_id from ZY_TRANSFER_DEPT where INPATIENT_ID=@INPATIENT_ID and Trans_type<>1)
        open Tcqzk
       FETCH NEXT FROM Tcqzk into @cs_cqzkrq
       WHILE @@FETCH_STATUS = 0 
        begin
        declare @cqbdate datetime 
        set @cqbdate=(select top 1 ORDER_BDATE from ##temporder where INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (0) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126)  
              AND DELETE_BIT=0 AND DEL_PRINT=0 and ORDER_BDATE>=@cs_cqzkrq order by ORDER_BDATE asc)
        if @cs_cqzkrq<=@CS_ORDER_BDATE and @CS_ORDER_BDATE=@cqbdate and @Sccqflag=0 and @old_bdate!=@CS_ORDER_BDATE
          begin
         set @Sccqflag=1
         set @old_bdate=@cqbdate
      --begin
        set @ROWS=@LOGROWS
     IF 1=1 --@ROWCOUNT
     --THEN 
     begin 
     --set @OUTMSG='dfsdfsd';
	 if not((@cfg7171=1 and @MAXROWNO=2) or @MAXROWNO=1)
	  begin----Modify By Tany 2014-10-24 如果当前行是第一行，或者是包含了转科医嘱字样的第二行，证明这是另外一页，则不需要划竖线
      SET @LASTROWS=@ROWS-@MAXROWNO+1 
      set @j=1 
      WHILE @J <= @LASTROWS 
      begin 
          SET @ROWSTATUS=0  
         --   INSERT INTO ZY_LOGORDERPRT  
         -- VALUES (@cs_INPATIENT_ID,@cs_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,0,@PRTSTATUS,  
         --      @cs_ORDER_ID,@cs_GROUP_ID,@cs_ORDER_BDATE,@CS_NTYPE,'      ┃',@cs_NUM,@cs_DOSAGE,@cs_UNIT,@cs_ORDER_SPEC,@cs_ORDER_USAGE,  
         --@cs_FREQUENCY,@cs_ORDER_DOC,@cs_AUDITING_USER,@cs_ORDER_EDATE,@cs_ORDER_EDOC,@cs_ORDER_EUSER,@USER_ID,'',@CS_DROPSPER)  
       --    INSERT INTO ZY_LOGORDERPRT  
       --      VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
       --            @CS_ORDER_ID,0,@CS_ORDER_BDATE,@CS_NTYPE,'      ┃',  
       --@CS_NUM,@CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,@CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,@CS_AUDITING_USER1,@CS_ORDER_EDATE,  
       --@CS_ORDER_EDOC,@CS_ORDER_EUSER,@CS_ORDER_EUSER1,@USER_ID,'',@CS_DROPSPER)  
       INSERT INTO ZY_LOGORDERPRT  
             --VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
             --      @CS_ORDER_ID,0,@CS_ORDER_BDATE,null,case when @cfg7173='' then '      ┃' else  @cfg7173 end ,  
             --Modify By Tany 2014-09-12 插空行时不要插入医嘱ID和组状态
             VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,0,@PRTSTATUS,  
                   dbo.FUN_GETEMPTYGUID(),0,@CS_ORDER_BDATE,null,case when @cfg7173='' then '      ┃' else  @cfg7173 end ,   
       null,null,null,null,null,null,null,null,null,null,  
       null,null,null,null,'',null)    
       SET @J=@J+1  
       --换行换页  
         IF @MAXROWNO=@ROWS
         begin  
           --THEN  
               SET @MAXPAGENO=@MAXPAGENO+1  
               SET @MAXROWNO=1  
               SET @PAGESTATUS=0  
          end
          ELSE IF @ROWS=@MAXROWNO+1  
           --THEN 
           begin 
                 SET @MAXROWNO=@MAXROWNO+1  
                 SET @PAGESTATUS=2 
             end 
          ELSE  
           begin
              SET @MAXROWNO=@MAXROWNO+1  
              SET @PAGESTATUS=1  
            end
          --END IF  
        END-- WHILE 
		end---tany
        ------add by zouchihua 2013-9-24  如果转科，换页以后第一行显示转科医嘱四个字
        if(@cfg7171=1 and @MAXROWNO=1)--Modify By Tany 2014-10-24 只有第一行才写转科医嘱
       begin
         INSERT INTO ZY_LOGORDERPRT  
             VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
                   dbo.FUN_GETEMPTYGUID(),0,null,7,'转科医嘱',  
       0,null,null,null,null,null,null,null,null,null,  
       null,null,null,null,'',null)
        SET @MAXROWNO=@MAXROWNO+1  
              SET @PAGESTATUS=1  
              end
       ----------
       
        
   END --IF 
      end
	FETCH NEXT FROM Tcqzk into @cs_cqzkrq
    end --while
     CLOSE Tcqzk  
  DEALLOCATE Tcqzk 
  end
  ------------------------------------转科医嘱换页处理结束------------------------------------  

   --如果折行则分成几行插入  
   IF @ROWCOUNT>1  
   BEGIN  
   
    --插入数据  
    SET @ROWSTATUS=1 --折行首行  
  
    WHILE @K <= @ROWCOUNT   
                                BEGIN  
     --判断医嘱内容截位的长度  
     IF LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT)))-((@K-1)*@LOGORDERWIDTH) >= @LOGORDERWIDTH  
        SET @LEN=@LOGORDERWIDTH  
     ELSE  
        SET @LEN=LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT)))-((@K-1)*@LOGORDERWIDTH)  
  
     IF @ROWSTATUS=1  
     BEGIN  
      INSERT INTO ZY_LOGORDERPRT  
             VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
                   @CS_ORDER_ID,@CS_GROUP_ID,@CS_ORDER_BDATE,@CS_NTYPE,SUBSTRING(LTRIM(RTRIM(@CS_ORDER_CONTEXT)),1+((@K-1)*@LOGORDERWIDTH),@LEN),  
       @CS_NUM,@CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,@CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,@CS_AUDITING_USER1,@CS_ORDER_EDATE,  
       @CS_ORDER_EDOC,@CS_ORDER_EUSER,@CS_ORDER_EUSER1,@USER_ID,'',@CS_DROPSPER)  
     END  
     ELSE --折行前面加空行  
       --改变折行的组标志  
                        /*MODIFY BY TANY 2004-12-12  
          CASE @GROUPSTATUS  
          WHEN 1  
           THEN SET @GROUPSTATUS=2  
          WHEN 3  
           THEN SET @GROUPSTATUS=0  
         END CASE  
                        */  
                                        BEGIN  
                         IF @GROUPSTATUS=1  
          SET @GROUPSTATUS=2  
             ELSE IF @GROUPSTATUS=3  
          SET @GROUPSTATUS=0  
   
      INSERT INTO ZY_LOGORDERPRT  
             VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
                    @CS_ORDER_ID,@CS_GROUP_ID,@CS_ORDER_BDATE,@CS_NTYPE,'   '+SUBSTRING(LTRIM(RTRIM(@CS_ORDER_CONTEXT)),1+((@K-1)*@LOGORDERWIDTH),@LEN),  
        @CS_NUM,@CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,@CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,@CS_AUDITING_USER1,@CS_ORDER_EDATE,  
        @CS_ORDER_EDOC,@CS_ORDER_EUSER,@CS_ORDER_EUSER1,@USER_ID,'',@CS_DROPSPER)  
     END    
     
     SET @ROWSTATUS=2  
     SET @K=@K+1  
     --换行换页  
     IF @MAXROWNO=@LOGROWS  
          BEGIN  
           SET @MAXPAGENO=@MAXPAGENO+1  
       SET @MAXROWNO=1  
          SET @PAGESTATUS=0  
     END  
        ELSE IF @LOGROWS=@MAXROWNO+1  
          BEGIN  
              SET @MAXROWNO=@MAXROWNO+1  
          SET @PAGESTATUS=2  
      END  
        ELSE  
     BEGIN  
          SET @MAXROWNO=@MAXROWNO+1  
          SET @PAGESTATUS=1  
     END  
    END-- WHILE  
   END  
   ELSE  
   BEGIN  
    SET @ROWSTATUS=0   
           
    INSERT INTO ZY_LOGORDERPRT  
    VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
     @CS_ORDER_ID,@CS_GROUP_ID,@CS_ORDER_BDATE,@CS_NTYPE,LTRIM(RTRIM(@CS_ORDER_CONTEXT)),@CS_NUM,@CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,  
     @CS_ORDER_USAGE,@CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,@CS_AUDITING_USER1,@CS_ORDER_EDATE,@CS_ORDER_EDOC,@CS_ORDER_EUSER,@CS_ORDER_EUSER1,@USER_ID,'',@CS_DROPSPER)  
  
    --换行换页  
    IF @MAXROWNO=@LOGROWS  
    BEGIN  
     SET @MAXPAGENO=@MAXPAGENO+1  
     SET @MAXROWNO=1  
     SET @PAGESTATUS=0  
    END  
    ELSE IF @LOGROWS=@MAXROWNO+1  
    BEGIN  
     SET @MAXROWNO=@MAXROWNO+1  
     SET @PAGESTATUS=2  
    END  
    ELSE  
    BEGIN  
     SET @MAXROWNO=@MAXROWNO+1  
     SET @PAGESTATUS=1  
    END  
   END   
     

   --附初值  
   SET @J=1  
   SET @K=1  
   SET @M=1  
     
   FETCH NEXT FROM T1   
                        INTO @CS_INPATIENT_ID,@CS_BABY_ID,@CS_ORDER_ID,@CS_GROUP_ID,  
    @CS_ORDER_BDATE,@CS_NTYPE,@CS_ORDER_CONTEXT,@CS_NUM,  
    @CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,  
    @CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,  
    @CS_AUDITING_USER1,@CS_ORDER_EDATE,@CS_ORDER_EDOC,  
    @CS_ORDER_EUSER,@CS_ORDER_EUSER1,@CS_STATUS_FLAG,@CS_SERIAL_NO,@CS_DROPSPER,@cs_tcid
  
   END--WHILE  
   --COMMIT  
  
  CLOSE T1  
  DEALLOCATE T1  
  
  --更新已经审核的停止医嘱信息  
  DECLARE T11 CURSOR FOR  
  SELECT A.INPATIENT_ID,A.BABY_ID,A.ORDER_ID,A.GROUP_ID,A.ORDER_EDATE,A.ORDER_EDOC,A.ORDER_EUSER  
  FROM ##temporder A,ZY_LOGORDERPRT B  
  WHERE A.INPATIENT_ID=B.INPATIENT_ID AND A.BABY_ID=B.BABY_ID AND A.ORDER_ID=B.ORDER_ID AND A.GROUP_ID=B.GROUP_ID AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND  
   (CASE WHEN A.ORDER_EDATE IS NULL THEN '' ELSE CONVERT(CHAR,A.ORDER_EDATE) END<>CASE WHEN B.ORDER_EDATE IS NULL THEN '' ELSE CONVERT(CHAR,B.ORDER_EDATE) END OR  
   CASE WHEN A.ORDER_EDOC IS NULL THEN '' ELSE CONVERT(CHAR,A.ORDER_EDOC) END<>CASE WHEN B.ORDER_EDOC IS NULL THEN '' ELSE CONVERT(CHAR,B.ORDER_EDOC) END OR  
   CASE WHEN A.ORDER_EUSER IS NULL THEN '' ELSE CONVERT(CHAR,A.ORDER_EUSER) END<>CASE WHEN B.ORDER_EUSER IS NULL THEN '' ELSE CONVERT(CHAR,B.ORDER_EUSER) END)  
   AND A.INPATIENT_ID=@INPATIENT_ID AND A.BABY_ID=@BABY_ID AND A.MNGTYPE=0 AND A.STATUS_FLAG IN (4,5) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
  ORDER BY A.ORDER_BDATE,A.GROUP_ID,A.ORDER_ID  
  
  OPEN T11  
    
  FETCH NEXT FROM T11  
  INTO @CS_INPATIENT_ID,@CS_BABY_ID,@CS_ORDER_ID,@CS_GROUP_ID,@CS_ORDER_EDATE,@CS_ORDER_EDOC,@CS_ORDER_EUSER  
    
  WHILE @@FETCH_STATUS = 0  
  BEGIN  
   UPDATE ZY_LOGORDERPRT SET ORDER_EDATE=@CS_ORDER_EDATE,ORDER_EDOC=@CS_ORDER_EDOC,ORDER_EUSER=@CS_ORDER_EUSER,  
    PRT_STATUS=2  
   WHERE INPATIENT_ID=@CS_INPATIENT_ID AND BABY_ID=@CS_BABY_ID AND ORDER_ID=@CS_ORDER_ID AND GROUP_ID=@CS_GROUP_ID AND  
    PRT_STATUS NOT IN (0,-1)  and  (  ISNULL(MEMO,'')!='取消')--取消的不再更新 
   UPDATE ZY_LOGORDERPRT SET ORDER_EDATE=@CS_ORDER_EDATE,ORDER_EDOC=@CS_ORDER_EDOC,ORDER_EUSER=@CS_ORDER_EUSER,  
    PRT_STATUS=-1  
   WHERE INPATIENT_ID=@CS_INPATIENT_ID AND BABY_ID=@CS_BABY_ID AND ORDER_ID=@CS_ORDER_ID AND GROUP_ID=@CS_GROUP_ID AND  
    PRT_STATUS IN (0,-1)  
     
   FETCH NEXT FROM T11  
   INTO @CS_INPATIENT_ID,@CS_BABY_ID,@CS_ORDER_ID,@CS_GROUP_ID,@CS_ORDER_EDATE,@CS_ORDER_EDOC,@CS_ORDER_EUSER  
  END--WHILE  
    
  CLOSE T11  
  DEALLOCATE T11  
  
  --每次更新复核人  
  --ADD BY TANY 2004-12-15  
  UPDATE ZY_LOGORDERPRT SET AUDITING_USER1=B.AUDITING_USER1,ORDER_EUSER1=B.ORDER_EUSER1  
  FROM ZY_LOGORDERPRT A,##temporder B  
  WHERE A.ORDER_ID=B.ORDER_ID AND B.MNGTYPE=0  
        AND A.INPATIENT_ID=@INPATIENT_ID AND A.BABY_ID=@BABY_ID  
  
   ----COMMIT  
  
  SELECT CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
   CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
   ORDER_CONTEXT,  
   CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
   CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
   CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
   CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
   CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
   CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
   CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR
,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
   CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
   CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
   CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
   ORDER_ID,prt_status,pageno,rowno --add by zouchihua 2011-12-29
  FROM ZY_LOGORDERPRT  
  WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
  ORDER BY PAGENO,ROWNO   
  
 END--END长期医嘱  
 /******************************************************************************************************/  
 ELSE--临时医嘱  ***************************************************************************************/  
 /******************************************************************************************************/  
 BEGIN  
  IF (SELECT COUNT(*)  
      FROM ZY_TMPORDERPRT  
      WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID)=0  
  BEGIN  
   SET @MAXPAGENO=1  
   SET @MAXROWNO=1  
   SET @PAGESTATUS=0  --页标志（0=页开始，1=页中间，2=页结束）  
  END  
  ELSE  
                BEGIN  
   SELECT @MAXPAGENO=MAX(PAGENO) --取最大页数  
   FROM ZY_TMPORDERPRT  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
  
   SELECT @MAXROWNO=MAX(ROWNO) --取最大行数  
   FROM ZY_TMPORDERPRT  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO=@MAXPAGENO  
   
   --如果当前行是最后一行，则换页  
   IF @MAXROWNO=@TMPROWS  
   BEGIN  
    SET @MAXPAGENO=@MAXPAGENO+1  
    SET @MAXROWNO=1  
    SET @PAGESTATUS=0  
   END  
   ELSE IF @TMPROWS=@MAXROWNO+1  
   BEGIN  
    SET @MAXROWNO=@MAXROWNO+1  
    SET @PAGESTATUS=2  
   END  
   ELSE  
   BEGIN  
    SET @MAXROWNO=@MAXROWNO+1  
    SET @PAGESTATUS=1  
   END  
  END  
  
  --如果有未审核的医嘱在审核了的医嘱之前，则返回不处理  
  IF(SELECT COUNT(*)  
     FROM ##temporder  
     WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND STATUS_FLAG IN (1) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0 
		AND ORDER_BDATE < (SELECT MAX(ORDER_BDATE) AS ORDER_ID FROM ##temporder  
                                       WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND STATUS_FLAG NOT IN (0,1,9) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND  
                               ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID)) )<>0  
  BEGIN  
   SET @OUTCODE=-1  
   SET @OUTMSG='该病人有未转抄的临时医嘱，请转抄后再打印！'  
  
   SELECT CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS EXECTIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END)) END EXECUSER,  
             ORDER_ID , 0 prt_status ,DROPSPER --滴速 
   FROM ZY_TMPORDERPRT  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   ORDER BY PAGENO,ROWNO  
  
   RETURN -1  
  END  
  -------------------如果有未核对或者没有皮试结果
   if  @cfg7178='1'
   begin
IF(SELECT COUNT(*)  
    FROM ##temporder  
     WHERE  isnull(AUDITING_USER1,0)<=0 and  INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND STATUS_FLAG >1 AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0 
		--AND ORDER_BDATE < (SELECT MAX(ORDER_BDATE) AS ORDER_ID FROM ##temporder  
  --                                     WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND STATUS_FLAG NOT IN (0,1,9) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND  
  --                             ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID))
                                )<>0  
    begin
    SET @OUTCODE=-1  
     SET @OUTMSG='该病人有未核对的临时医嘱，请核对后再打印！'  
       
    end
    
    IF(SELECT COUNT(*)  
    FROM ##temporder  
     WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND STATUS_FLAG>=2 
     and NTYPE in(1,2) and PS_FLAG=0  and XMLY=2 and ORDER_USAGE='皮试'
  --   AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0 
		--AND ORDER_BDATE < (SELECT MAX(ORDER_BDATE) AS ORDER_ID FROM ##temporder  
  --                                     WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND STATUS_FLAG NOT IN (0,1,9) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND  
  --                             ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID)) 
                               )<>0  
    begin
    SET @OUTCODE=-1  
     SET @OUTMSG='该病人有未标皮试结果临时医嘱，请标结果后再打印！'  
       
    end
    
    if(@OUTCODE=-1  )
      begin
 SELECT CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS EXECTIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END)) END EXECUSER,  
             ORDER_ID , 0 prt_status ,DROPSPER --滴速 
   FROM ZY_TMPORDERPRT  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   ORDER BY PAGENO,ROWNO  
   return -1
      end
      end
      ------------------------------------如果有未核对或者没有皮试结果
   --add by zouchihua
  -------------------  --add by zouchihua 2011-12-07

--EXEC('IF EXISTS(SELECT NAME FROM TEMPDB..SYSOBJECTS WHERE  NAME = ''' +@TABLENAME+ ''')
--	 DROP TABLE [' + @TABLENAME +']')
-- select order_id,group_id into ##temp_cy_order from ##temporder  where 1=2--获得临时表结构

  --declare @cy_orderid UNIQUEIDENTIFIER 
  --declare @flagcount int
  --declare @csgroupid int
  -- declare @csoldgroupid int
  --declare @mysql varchar(200)
  delete from ##temp_cy_order
  set @flagcount=0;
  DECLARE Tt2 CURSOR FOR    select order_id,GROUP_ID from ##temporder a
   WHERE A.INPATIENT_ID=@INPATIENT_ID AND A.BABY_ID=@BABY_ID AND A.MNGTYPE IN (1,5) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 ) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND STATUS_FLAG NOT IN (0,1,9)  
   AND NTYPE=3 AND A.ORDER_ID NOT IN(SELECT ORDER_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID)  
   AND A.GROUP_ID NOT IN(SELECT GROUP_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID GROUP BY GROUP_ID) 
   AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0   
  order BY order_bdate,GROUP_ID
  open Tt2
   FETCH NEXT FROM Tt2 into  @cy_orderid,@csgroupid
   WHILE @@FETCH_STATUS = 0  
   begin
       if @flagcount=0
         begin 
          insert into ##temp_cy_order(order_id,group_id) values (@cy_orderid,@csgroupid)
          set @csoldgroupid=@csgroupid
          set @flagcount=1
          end
       else
          if @csgroupid<>@csoldgroupid
            begin
             insert into ##temp_cy_order(order_id,group_id) values (@cy_orderid,@csgroupid)
            set @csoldgroupid=@csgroupid
            end
    FETCH NEXT FROM Tt2 into  @cy_orderid,@csgroupid  
   end
  CLOSE Tt2  
  DEALLOCATE Tt2  

  ---------------------------------------------------------
  
  if (@cs7136='0')
  --草药不显示明细 ADD BY TANY 20040913  
  --判断用法是否用于打印显示 MODIFY BY TANY 2004-10-10  
  DECLARE T2 CURSOR FOR  
  SELECT A.INPATIENT_ID,A.BABY_ID,A.ORDER_ID ORDER_ID,A.GROUP_ID,A.ORDER_BDATE,NTYPE,  
   (CASE MNGTYPE WHEN 5 THEN  
   CASE WHEN CHARINDEX(A.ORDER_CONTEXT,'(交病人)')>0  
   THEN SUBSTRING(A.ORDER_CONTEXT,1,CHARINDEX(A.ORDER_CONTEXT,'(交病人)')-1)  
   ELSE LTRIM(RTRIM(A.ORDER_CONTEXT)) END  
   --+CASE WHEN C.S_YPGG IS NULL  
   --THEN ''  
   --ELSE '('+C.S_YPGG+')' END  
   ELSE LTRIM(RTRIM(A.ORDER_CONTEXT)) END)+(case when a.WZX_FLAG>0 and @cfg7138='1' then '【原因：'+memo2+'】' else '' end) AS ORDER_CONTEXT,  
   NUM,DOSAGE,LTRIM(RTRIM(UNIT)) UNIT, case when isprintypgg is null or isprintypgg=0 then '' else LTRIM(RTRIM(ORDER_SPEC)) end ORDER_SPEC, --modify by zouchihua 2011-11-30 规格是否打印  
      CASE D.IS_PRINT WHEN 0 
      THEN case when LTRIM(RTRIM(isnull(printname,'')))='' then ORDER_USAGE else  printname end   --THEN LTRIM(RTRIM(isnull(printname, ORDER_USAGE)))
      +CASE WHEN PS_FLAG=1 THEN ' (-)' WHEN PS_FLAG=2 THEN ' (+)' ELSE '' END ELSE '' END+CASE MNGTYPE WHEN 5 THEN @mryf ELSE '' END ORDER_USAGE,  
   LTRIM(RTRIM(A.FREQUENCY)) FREQUENCY,A.ORDER_DOC,A.AUDITING_USER,A.AUDITING_USER1,0 EXEUSER,A.ORDER_EDATE EXECDATE,A.STATUS_FLAG,SERIAL_NO,DROPSPER --滴速 
   ,A.zsl,A.zsldw,tcid 
  FROM ##temporder A --LEFT JOIN YP_YPCJD C ON A.CJID=C.CJID --只有西药需要规格 MODIFY BY TANY 2005-01-14  
  LEFT JOIN(SELECT NAME,IS_PRINT,printname FROM JC_USAGEDICTION WHERE NAME <> '') D ON A.ORDER_USAGE=D.NAME  
  WHERE A.INPATIENT_ID=@INPATIENT_ID AND A.BABY_ID=@BABY_ID AND A.MNGTYPE IN (1,5) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126)  AND STATUS_FLAG NOT IN (0,1,9)  
   AND NTYPE<>3 AND A.ORDER_ID NOT IN(SELECT ORDER_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID  
   AND BABY_ID=@BABY_ID) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
  UNION ALL  
  SELECT   A.INPATIENT_ID,A.BABY_ID,A.ORDER_ID ORDER_ID,A.GROUP_ID,A.ORDER_BDATE ORDER_BDATE,NTYPE,case when wzx_flag>0 then  '【取消】中草药处方'+(case when a.WZX_FLAG>0 and @cfg7138='1' then '【原因：'+memo2+'】' else '' end) 
  else 
  '中草药处方' +case when @zcyxsmc='0' then '' else  (case when rtrim(isnull(MEMO,''))!=''   then '【'+isnull(MEMO,'')+'】' else isnull((select top 1 '【'+MBMC+'】' from  jc_cfmb where MBXH=A.PS_ORDERID),'') end  )   end
  end  AS ORDER_CONTEXT,  
   0 NUM,DOSAGE,'付' UNIT,/*LTRIM(RTRIM(ORDER_SPEC))*/'' ORDER_SPEC,LTRIM(RTRIM(isnull((select printname from JC_USAGEDICTION D where D.NAME=ORDER_USAGE and LTRIM(RTRIM(printname))<>'' and D.IS_PRINT=0), ORDER_USAGE)))+CASE MNGTYPE WHEN 5 THEN @mryf ELSE '' END ORDER_USAGE,  
   LTRIM(RTRIM(A.FREQUENCY)) FREQUENCY,A.ORDER_DOC,A.AUDITING_USER,A.AUDITING_USER1,0 EXEUSER,/*MIN(B.EXECDATE)*/A.ORDER_EDATE EXECDATE,A.STATUS_FLAG,0 SERIAL_NO,DROPSPER --滴速
   ,A.zsl,A.zsldw ,tcid 
  FROM ##temporder A /*LEFT JOIN VI_ZY_ORDEREXEC B ON A.ORDER_ID=B.ORDER_ID*/  
  WHERE A.INPATIENT_ID=@INPATIENT_ID AND A.BABY_ID=@BABY_ID AND A.MNGTYPE IN (1,5) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND STATUS_FLAG NOT IN (0,1,9)  
   AND NTYPE=3 AND A.ORDER_ID NOT IN(SELECT ORDER_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID)  
   AND A.GROUP_ID NOT IN(SELECT GROUP_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID GROUP BY GROUP_ID) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
   and  order_id in(select order_id  from ##temp_cy_order) --add by zouchihua  
--  GROUP BY A.INPATIENT_ID,A.BABY_ID,A.GROUP_ID,NTYPE,DOSAGE/*,ORDER_SPEC*/,A.ORDER_USAGE,A.FREQUENCY,  
--   A.ORDER_DOC,A.AUDITING_USER,A.AUDITING_USER1/*,B.EXEUSER*/,A.STATUS_FLAG,A.MNGTYPE  
  ORDER BY ORDER_BDATE,GROUP_ID,SERIAL_NO,ORDER_ID  
    else
      begin
       DECLARE T2 CURSOR FOR  
          SELECT A.INPATIENT_ID,A.BABY_ID,A.ORDER_ID ORDER_ID,A.GROUP_ID,A.ORDER_BDATE,NTYPE,  
  ( CASE MNGTYPE WHEN 5 THEN  
   CASE WHEN CHARINDEX(A.ORDER_CONTEXT,'(交病人)')>0  
   THEN SUBSTRING(A.ORDER_CONTEXT,1,CHARINDEX(A.ORDER_CONTEXT,'(交病人)')-1)  
   ELSE LTRIM(RTRIM(A.ORDER_CONTEXT)) END  
   --+CASE WHEN C.S_YPGG IS NULL  
   --THEN ''  
   --ELSE '('+C.S_YPGG+')' END  
   ELSE LTRIM(RTRIM(A.ORDER_CONTEXT)) END)+(case when a.WZX_FLAG>0 and @cfg7138='1' then '【原因：'+memo2+'】' else '' end) AS ORDER_CONTEXT,  
   NUM,DOSAGE,LTRIM(RTRIM(UNIT)) UNIT, case when isprintypgg is null or isprintypgg=0 then '' else LTRIM(RTRIM(ORDER_SPEC)) end ORDER_SPEC, --modify by zouchihua 2011-11-30 规格是否打印  
   CASE D.IS_PRINT WHEN 0 
   THEN case when LTRIM(RTRIM(isnull(printname,'')))='' then ORDER_USAGE else  printname end --THEN LTRIM(RTRIM(isnull(printname, ORDER_USAGE)))
   +CASE WHEN PS_FLAG=1 THEN ' (-)' WHEN PS_FLAG=2 THEN ' (+)' ELSE '' END ELSE '' END+CASE MNGTYPE WHEN 5 THEN @mryf ELSE '' END ORDER_USAGE,  
   LTRIM(RTRIM(A.FREQUENCY)) FREQUENCY,A.ORDER_DOC,A.AUDITING_USER,A.AUDITING_USER1,0 EXEUSER,A.ORDER_EDATE EXECDATE,A.STATUS_FLAG,SERIAL_NO,DROPSPER --滴速 
   ,A.zsl,A.zsldw ,tcid 
  FROM ##temporder A --LEFT JOIN YP_YPCJD C ON A.CJID=C.CJID --只有西药需要规格 MODIFY BY TANY 2005-01-14  
  LEFT JOIN(SELECT NAME,IS_PRINT,printname FROM JC_USAGEDICTION WHERE NAME <> '') D ON A.ORDER_USAGE=D.NAME  
  WHERE A.INPATIENT_ID=@INPATIENT_ID AND A.BABY_ID=@BABY_ID AND A.MNGTYPE IN (1,5) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126)  AND STATUS_FLAG NOT IN (0,1,9)  
     AND A.ORDER_ID NOT IN(SELECT ORDER_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID  
   AND BABY_ID=@BABY_ID) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0 
   ORDER BY ORDER_BDATE,GROUP_ID,SERIAL_NO,ORDER_ID  
      end
  OPEN T2  
  
  FETCH NEXT FROM T2  
  INTO @CS_INPATIENT_ID,@CS_BABY_ID,@CS_ORDER_ID,@CS_GROUP_ID,  
   @CS_ORDER_BDATE,@CS_NTYPE,@CS_ORDER_CONTEXT,@CS_NUM,  
   @CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,  
   @CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,  
   @CS_AUDITING_USER1,@CS_EXEUSER,@CS_EXECDATE,@CS_STATUS_FLAG,@CS_SERIAL_NO,@CS_DROPSPER --滴速  
   ,@zl,@zldw,@cs_tcid
    
  WHILE @@FETCH_STATUS = 0  
  BEGIN  
   --根据医嘱类型设置长度  
   IF @CS_NTYPE IN (1,2,3)  
    SET @TMPORDERWIDTH=@TMPORDERWIDTH_YP  
   ELSE  
    SET @TMPORDERWIDTH=@TMPORDERWIDTH_XM  
  
    --如果是说明医嘱 add by zouchihua 2013-11-19
    if (@CS_NTYPE=7 or @CS_NTYPE=0) and rtrim(@CS_FREQUENCY)='' and rtrim(@CS_ORDER_USAGE)=''
      set @TMPORDERWIDTH=(select TOp 1( case when isnull(X,0)=0  then @TMPORDERWIDTH else X end)  from ZY_ORDERPRTCFG where id=92)
  
   --如果医嘱已经执行完成，则打印状态=-1  
   IF @CS_STATUS_FLAG=5  
    SET @PRTSTATUS=-1  
   ELSE  
    SET @PRTSTATUS=0  
  
   --根据组号判断这一组到底有多少项目  
   SET @GROUPID1=@CS_GROUP_ID  
  
   --草药算一条记录  
   SELECT @GROUPCOUNT=COUNT(*) FROM ##temporder  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1 )  and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND GROUP_ID=@GROUPID1  
    AND (case when @cs7136='0' then NTYPE else 1 end )<>3 AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
          --如果是打中草药明细 
   --根据组号判断这一组的项目占多少行  
   SELECT @ROWCOUNTS=SUM(CASE  
      WHEN (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @TMPORDERWIDTH = 0) OR  
         (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @TMPORDERWIDTH = 1 AND  
              (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) % @TMPORDERWIDTH) = 0)  
      THEN 1  
      WHEN (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @TMPORDERWIDTH <> 0 AND  
               (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) % @TMPORDERWIDTH) <> 0)  
      THEN (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @TMPORDERWIDTH)+1  
      ELSE (LEN(LTRIM(RTRIM(ORDER_CONTEXT))) / @TMPORDERWIDTH) END)  
   FROM ##temporder  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126) AND GROUP_ID=@GROUPID1  
     AND ORDER_ID NOT IN (SELECT ORDER_ID FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@INPATIENT_ID  
                          AND BABY_ID=@BABY_ID AND GROUP_ID=@GROUPID1) AND DELETE_BIT=0 AND DEL_PRINT=0 --ADD BY TANY 2011-01-21 DEL_PRINT=0  
   --设置组状态  
   --当组的一半先插入表，然后再续插另一半，程序将不能判断。但这种情况不应该出现。  
   IF @GROUPCOUNT=0  
   BEGIN  
    SET @GROUPCOUNT=1  
   END  
   IF @GROUPCOUNT=1  
   BEGIN  
    SET @GROUPSTATUS=0  
    SET @I=0  
   END  
   ELSE IF @CS_GROUP_ID<>@GROUPID  
   BEGIN  
    SET @GROUPSTATUS=1  
   END  
   ELSE IF @CS_GROUP_ID=@GROUPID AND @GROUPCOUNT=@I  
   BEGIN  
    SET @GROUPSTATUS=3  
    SET @I=0  
   END  
   ELSE  
   BEGIN  
    SET @GROUPSTATUS=2  
   END  
   SET @GROUPID=@CS_GROUP_ID--保留这一次的组号留给下一组判断是否发生变化  
   SET @I=@I+1--用来判断是不是组的最后一行了  
   
   --设置折行状态  
   --小于等于一行  
   IF (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @TMPORDERWIDTH = 0) OR  
      (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @TMPORDERWIDTH = 1 AND  
      (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) % @TMPORDERWIDTH) = 0)  
   BEGIN  
    SET @ROWCOUNT=1  
   END  
   ELSE IF (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @TMPORDERWIDTH <> 0 AND  
           (LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) % @TMPORDERWIDTH) <> 0)  
   BEGIN  
    SET @ROWCOUNT=(LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @TMPORDERWIDTH)+1  
   END  
   ELSE  
   BEGIN  
    SET @ROWCOUNT=(LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT))) / @TMPORDERWIDTH)  
   END  
    
     
    
     --如果不够折行插入，则打空行换页  
     --要放到外面来
     --/* 医院不需要此需求 MODIFY BY zouchihua 2011-11-17 20040911  
   IF @TMPROWS-@MAXROWNO+1< @ROWCOUNTS and (case when @cs7136='0' then @CS_NTYPE else 1 end ) !=3--  组占的行数  @ROWS-@MAXROWNO+1 < @ROWCOUNT
      and isnull(@cs_tcid,0)<=0  and @cfg7172=0
    --IF @ROWS-@L
     --THEN 
     begin 
      SET @LASTROWS=@LOGROWS-@MAXROWNO+1  
      set @J=1--@MAXROWNO --add by zouchihua
      WHILE @J <=@LASTROWS
      begin 
          SET @ROWSTATUS=0  
         --   INSERT INTO ZY_LOGORDERPRT  
         -- VALUES (@cs_INPATIENT_ID,@cs_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,0,@PRTSTATUS,  
         --      @cs_ORDER_ID,@cs_GROUP_ID,@cs_ORDER_BDATE,@CS_NTYPE,'      ┃',@cs_NUM,@cs_DOSAGE,@cs_UNIT,@cs_ORDER_SPEC,@cs_ORDER_USAGE,  
         --@cs_FREQUENCY,@cs_ORDER_DOC,@cs_AUDITING_USER,@cs_ORDER_EDATE,@cs_ORDER_EDOC,@cs_ORDER_EUSER,@USER_ID,'',@CS_DROPSPER)  
           INSERT INTO ZY_TMPORDERPRT (INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,GROUP_STATUS,PRT_STATUS,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,EXEUSER,EXECDATE,[USER],MEMO,DROPSPER,exec_Duser
           ,zl,zldw) 
      VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
       @CS_ORDER_ID,0,@CS_ORDER_BDATE,null,case when @cfg7173='' then '      ┃' else  @cfg7173 end, 
       null,null,null,null,null,null,null,null,null,null,null,  
       null,'',null,0,null,null)    
       SET @J=@J+1  
       --换行换页  
         IF @MAXROWNO=@LOGROWS--@ROWS
         begin  
           --THEN  
               SET @MAXPAGENO=@MAXPAGENO+1  
               SET @MAXROWNO=1  
               SET @PAGESTATUS=0  
          end
          ELSE IF @LOGROWS=@MAXROWNO+1  --@ROWS=@MAXROWNO+1  
           --THEN 
           begin 
                 SET @MAXROWNO=@MAXROWNO+1  
                 SET @PAGESTATUS=2 
             end 
          ELSE  
           begin
              SET @MAXROWNO=@MAXROWNO+1  
              SET @PAGESTATUS=1  
            end
          --END IF  
        END-- WHILE 
   END --IF  
   
   
   --如果折行则分成几行插入   且不是手术说明医嘱 modify fy by zouchihua 2011-12-27 医院不需要 Modify by zouchihua 2012-11-19  
   IF @ROWCOUNT>1 --and  (@CS_NTYPE!=7 or @CS_ORDER_CONTEXT not like '%拟%')  ----------------------医院不需要 MO
   BEGIN  
   --SELECT @ROWS=ISNULL(ROWNO,0)+1 FROM ZY_TMPORDERPRT WHERE INPATIENT_ID=@CS_INPATIENT_ID AND BABY_ID=@CS_BABY_ID AND PAGENO=@MAXPAGENO
   -- SET @ROWS=@LASTROWS+ @ROWCOUNT
  --插入数据  
    SET @ROWSTATUS=1 --折行首行  
    WHILE @K <= @ROWCOUNT   
    BEGIN  
     --判断医嘱内容截位的长度  
     IF LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT)))-((@K-1)*@TMPORDERWIDTH) >= @TMPORDERWIDTH  
     BEGIN  
        SET @LEN=@TMPORDERWIDTH  
     END  
     ELSE  
     BEGIN  
        SET @LEN=LEN(LTRIM(RTRIM(@CS_ORDER_CONTEXT)))-((@K-1)*@TMPORDERWIDTH)  
     END  
     IF @ROWSTATUS=1  
     BEGIN  
      INSERT INTO ZY_TMPORDERPRT (INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,GROUP_STATUS,PRT_STATUS,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,EXEUSER,EXECDATE,[USER],MEMO,DROPSPER,exec_Duser
      ,zl,zldw)   
      VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
       @CS_ORDER_ID,@CS_GROUP_ID,@CS_ORDER_BDATE,@CS_NTYPE,SUBSTRING(LTRIM(RTRIM(@CS_ORDER_CONTEXT)),1+((@K-1)*@TMPORDERWIDTH),@LEN),  
       @CS_NUM,@CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,@CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,@CS_AUDITING_USER1,@CS_EXEUSER,@CS_EXECDATE,  
       @USER_ID,'',@CS_DROPSPER,0,@zl,@zldw)  
     END  
     ELSE --折行前面加空行  
     BEGIN  
      --改变折行的组标志  
      IF @GROUPSTATUS=1  
      BEGIN  
       SET @GROUPSTATUS=2  
      END  
      ELSE IF @GROUPSTATUS=3  
      BEGIN  
       SET @GROUPSTATUS=0  
      END  
      INSERT INTO ZY_TMPORDERPRT (INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,GROUP_STATUS,PRT_STATUS,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,EXEUSER,EXECDATE,[USER],MEMO,DROPSPER,exec_Duser
      ,zl,zldw) 
      VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
       @CS_ORDER_ID,@CS_GROUP_ID,@CS_ORDER_BDATE,@CS_NTYPE,'   '+SUBSTRING(LTRIM(RTRIM(@CS_ORDER_CONTEXT)),1+((@K-1)*@TMPORDERWIDTH),@LEN),  
       @CS_NUM,@CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,@CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,@CS_AUDITING_USER,@CS_EXEUSER,@CS_EXECDATE,  
       @USER_ID,'',@CS_DROPSPER,0,@zl,@zldw)  
     END       
     SET @ROWSTATUS=2  
     SET @K=@K+1  
     --换行换页  
     IF @MAXROWNO=@TMPROWS  
          BEGIN  
           SET @MAXPAGENO=@MAXPAGENO+1  
       SET @MAXROWNO=1  
          SET @PAGESTATUS=0  
     END  
        ELSE IF @TMPROWS=@MAXROWNO+1  
          BEGIN  
      SET @MAXROWNO=@MAXROWNO+1  
      SET @PAGESTATUS=2  
     END  
        ELSE  
     BEGIN  
      SET @MAXROWNO=@MAXROWNO+1  
      SET @PAGESTATUS=1  
     END  
    END--WHILE  
   END  
   ELSE  
   BEGIN  
       SET @ROWSTATUS=0            
    INSERT INTO ZY_TMPORDERPRT (INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,GROUP_STATUS,PRT_STATUS,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,EXEUSER,EXECDATE,[USER],MEMO,DROPSPER,exec_Duser
    ,zl,zldw)   
    VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
     @CS_ORDER_ID,@CS_GROUP_ID,@CS_ORDER_BDATE,@CS_NTYPE,LTRIM(RTRIM(@CS_ORDER_CONTEXT)),@CS_NUM,@CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,  
     @CS_ORDER_USAGE,@CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,@CS_AUDITING_USER,@CS_EXEUSER,@CS_EXECDATE,@USER_ID,'',@CS_DROPSPER,0
     ,@zl,@zldw)  
    --换行换页  
    IF @MAXROWNO=@TMPROWS  
    BEGIN  
     SET @MAXPAGENO=@MAXPAGENO+1  
     SET @MAXROWNO=1  
     SET @PAGESTATUS=0  
    END  
    ELSE IF @TMPROWS=@MAXROWNO+1  
    BEGIN  
     SET @MAXROWNO=@MAXROWNO+1  
     SET @PAGESTATUS=2  
    END  
    ELSE  
    BEGIN  
     SET @MAXROWNO=@MAXROWNO+1  
     SET @PAGESTATUS=1  
    END  
   END   
  
 ---------------------------------add by zouchihua 2011-12-26 临时转科医嘱换页
    declare @Scflag int
    set @Scflag=0
  if isnull((select config from jc_config where id=7100),0)=1 or isnull((select config from jc_config where id=7100),0)=3
  begin
      DECLARE @cs_zkrq datetime
       DECLARE Tzk CURSOR FOR 
       select ORDER_BDATE from ##temporder where NTYPE=0 and ORDER_CONTEXT like '%转%' 
       and  INPATIENT_ID=@INPATIENT_ID  and BABY_ID=@BABY_ID and  delete_bit=0
       --需要增加判断在转科记录表里面transtype Modify By Tany 2014-12-04
       and ORDER_ID in (select order_id from ZY_TRANSFER_DEPT where INPATIENT_ID=@INPATIENT_ID and Trans_type<>1)
        open Tzk
       FETCH NEXT FROM Tzk into @cs_zkrq
       WHILE @@FETCH_STATUS = 0 
        begin
        declare @bdate datetime 
        set @bdate=(select top 1 ORDER_BDATE from ##temporder where INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND MNGTYPE IN (1,5) AND (DEPT_ID NOT IN (SELECT DEPTID FROM SS_DEPT) OR SSMZ_PRINT=1) and DEPT_ID<>@jy_dept and dept_id not in (@cfg7126)  
              AND DELETE_BIT=0 AND DEL_PRINT=0 and ORDER_BDATE>=@cs_zkrq order by ORDER_BDATE asc)
        if @cs_zkrq<=@CS_ORDER_BDATE and @CS_ORDER_BDATE=@bdate and @Scflag=0 and @old_bdate!=@CS_ORDER_BDATE
          begin
         set @Scflag=1
         set @old_bdate=@bdate
        -- select @CS_ORDER_BDATE as 'sdf',@cs_zkrq 'zk'
        set @ROWS=@TMPROWS--@LOGROWS Modify By Tany 2014-09-13 应该@TMPROWS
     IF 1=1 --@ROWCOUNT
     --THEN 
     begin 
     --set @OUTMSG='dfsdfsd';
      SET @LASTROWS=@ROWS-@MAXROWNO+1  
       set @J=1
      WHILE @J <= @LASTROWS 
      begin 
          SET @ROWSTATUS=0  
         --   INSERT INTO ZY_LOGORDERPRT  
         -- VALUES (@cs_INPATIENT_ID,@cs_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,0,@PRTSTATUS,  
         --      @cs_ORDER_ID,@cs_GROUP_ID,@cs_ORDER_BDATE,@CS_NTYPE,'      ┃',@cs_NUM,@cs_DOSAGE,@cs_UNIT,@cs_ORDER_SPEC,@cs_ORDER_USAGE,  
         --@cs_FREQUENCY,@cs_ORDER_DOC,@cs_AUDITING_USER,@cs_ORDER_EDATE,@cs_ORDER_EDOC,@cs_ORDER_EUSER,@USER_ID,'',@CS_DROPSPER)  
      --     INSERT INTO ZY_TMPORDERPRT (INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,GROUP_STATUS,PRT_STATUS,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,EXEUSER,EXECDATE,[USER],MEMO,DROPSPER,exec_Duser
      --     ,zl,zldw)   
      --VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
      -- @CS_ORDER_ID,0,@CS_ORDER_BDATE,@CS_NTYPE,'      ┃', 
      -- @CS_NUM,@CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,@CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,@CS_AUDITING_USER1,@CS_EXEUSER,@CS_EXECDATE,  
      -- @USER_ID,'',@CS_DROPSPER,0,@zl,@zldw) 
      INSERT INTO ZY_TMPORDERPRT (INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,GROUP_STATUS,PRT_STATUS,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,EXEUSER,EXECDATE,[USER],MEMO,DROPSPER,exec_Duser
           ,zl,zldw) 
      --VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
      -- @CS_ORDER_ID,0,@CS_ORDER_BDATE,null,case when @cfg7173='' then '      ┃' else  @cfg7173 end, 
             --Modify By Tany 2014-09-12 插空行时不要插入医嘱ID和组状态
             VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,0,@PRTSTATUS,  
                   dbo.FUN_GETEMPTYGUID(),0,@CS_ORDER_BDATE,null,case when @cfg7173='' then '      ┃' else  @cfg7173 end ,   
       null,null,null,null,null,null,null,null,null,null,null,  
       null,'',null,0,null,null)     
       SET @J=@J+1  
       --换行换页  
         IF @MAXROWNO=@ROWS
         begin  
           --THEN  
               SET @MAXPAGENO=@MAXPAGENO+1  
               SET @MAXROWNO=1  
               SET @PAGESTATUS=0  
          end
          ELSE IF @ROWS=@MAXROWNO+1  
           --THEN 
           begin 
                 SET @MAXROWNO=@MAXROWNO+1  
                 SET @PAGESTATUS=2 
             end 
          ELSE  
           begin
              SET @MAXROWNO=@MAXROWNO+1  
              SET @PAGESTATUS=1  
            end
          --END IF  
        END-- WHILE 
        
        ------add by zouchihua 2013-9-24  如果转科，换页以后第一行显示转科医嘱四个字
         if(@cfg7171=1)
         begin
         INSERT INTO ZY_TMPORDERPRT (INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,GROUP_STATUS,PRT_STATUS,ORDER_ID,GROUP_ID,ORDER_BDATE,NTYPE,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_SPEC,ORDER_USAGE,FREQUENCY,ORDER_DOC,AUDITING_USER,AUDITING_USER1,EXEUSER,EXECDATE,[USER],MEMO,DROPSPER,exec_Duser
           ,zl,zldw)   
      VALUES (@CS_INPATIENT_ID,@CS_BABY_ID,@MAXPAGENO,@MAXROWNO,@PAGESTATUS,@ROWSTATUS,@GROUPSTATUS,@PRTSTATUS,  
       @CS_ORDER_ID,0,null,7,'转科医嘱', 
       null,null,null,null,null,null,null,null,null,null,null,  
       null,'',null,0,null,null) 
        SET @MAXROWNO=@MAXROWNO+1  
              SET @PAGESTATUS=1  
              end
       ----------
   END --IF 
    
      end
      FETCH NEXT FROM Tzk into @cs_zkrq
    end --while
     CLOSE Tzk  
  DEALLOCATE Tzk
   end 
  ------------------------------------------------------------------------  
  
   --附初值  
   SET @J=1  
   SET @K=1  
   SET @M=1  
  
  
  
   FETCH NEXT FROM T2  
   INTO @CS_INPATIENT_ID,@CS_BABY_ID,@CS_ORDER_ID,@CS_GROUP_ID,  
    @CS_ORDER_BDATE,@CS_NTYPE,@CS_ORDER_CONTEXT,@CS_NUM,  
    @CS_DOSAGE,@CS_UNIT,@CS_ORDER_SPEC,@CS_ORDER_USAGE,  
    @CS_FREQUENCY,@CS_ORDER_DOC,@CS_AUDITING_USER,  
    @CS_AUDITING_USER1,@CS_EXEUSER,@CS_EXECDATE,@CS_STATUS_FLAG,@CS_SERIAL_NO ,@CS_DROPSPER ,@zl,@zldw,@cs_tcid
  
  END--WHILE  
  
  CLOSE T2  
  DEALLOCATE T2  
  
  -------------无条件将PRT_STATUS=2 的更新为3
  update ZY_TMPORDERPRT set PRT_STATUS=3 
    
  FROM VI_ZY_ORDEREXEC A,ZY_TMPORDERPRT B    
  WHERE A.ORDER_ID=B.ORDER_ID AND B.INPATIENT_ID=@INPATIENT_ID AND B.BABY_ID=@BABY_ID AND --A.REALEXECDATE IS not NULL --Modify by zouchihua 2012-6-7   
  ( (CASE WHEN A.REALEXECDATE IS NULL THEN '' ELSE CONVERT(CHAR,A.REALEXECDATE) END='' and 
   ( CASE WHEN B.EXECDATE IS NULL THEN '' ELSE CONVERT(CHAR,B.EXECDATE) END )='')
     OR    
  ( CASE WHEN A.REALEXEUSER IS NULL THEN '' ELSE CONVERT(CHAR,A.REALEXEUSER) END='' and
    (CASE WHEN B.EXEUSER IS NULL THEN '' ELSE CONVERT(CHAR,B.EXEUSER) END)='' )
    )    
  and  PRT_STATUS=2
  ---------------------
  
  --add by zouchihua 2013-11-19 把EXEUSER=0 更改为null 防止打空白页
  update ZY_TMPORDERPRT set   EXEUSER=null
  WHERE   INPATIENT_ID=@INPATIENT_ID and BABY_ID=@BABY_ID and  EXEUSER=0
  
  --COMMIT  
  
  DECLARE T22 CURSOR FOR  
  SELECT A.ORDER_ID,A.REALEXECDATE,A.REALEXEUSER ,a.REALEXEUSERDb 
  FROM VI_ZY_ORDEREXEC A,ZY_TMPORDERPRT B  
  WHERE A.ORDER_ID=B.ORDER_ID AND B.INPATIENT_ID=@INPATIENT_ID AND B.BABY_ID=@BABY_ID AND --A.REALEXECDATE IS not NULL --Modify by zouchihua 2012-6-7 
  (CASE WHEN A.REALEXECDATE IS NULL THEN '' ELSE CONVERT(CHAR,A.REALEXECDATE) END<>CASE WHEN B.EXECDATE IS NULL THEN '' ELSE CONVERT(CHAR,B.EXECDATE) END OR  
   CASE WHEN A.REALEXEUSER IS NULL THEN '' ELSE CONVERT(CHAR,A.REALEXEUSER) END<>CASE WHEN B.EXEUSER IS NULL THEN '' ELSE CONVERT(CHAR,B.EXEUSER) END) 
   --and  B.EXEUSER<>0 --并且执行
  ORDER BY B.ORDER_BDATE,B.GROUP_ID,B.ORDER_ID   
  
  OPEN T22  
    
  FETCH NEXT FROM T22  
  INTO @CS_ORDER_ID,@CS_REALEXECDATE,@CS_REALEXEUSER,@CS_REALEXEUSER1  
    
  WHILE @@FETCH_STATUS = 0  
  BEGIN  
   UPDATE ZY_TMPORDERPRT SET EXECDATE=@CS_REALEXECDATE,EXEUSER=@CS_REALEXEUSER,exec_duser=@CS_REALEXEUSER1,  PRT_STATUS=2  
   WHERE ORDER_ID=@CS_ORDER_ID AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS NOT IN (0,-1) 
   and    ( ISNULL(MEMO,'')!='取消')--取消的不再更新 
   UPDATE ZY_TMPORDERPRT SET EXECDATE=@CS_REALEXECDATE,EXEUSER=@CS_REALEXEUSER,exec_duser=@CS_REALEXEUSER1,PRT_STATUS=-1  
   WHERE ORDER_ID=@CS_ORDER_ID AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (0,-1)  
  
   FETCH NEXT FROM T22  
   INTO @CS_ORDER_ID,@CS_REALEXECDATE,@CS_REALEXEUSER ,@CS_REALEXEUSER1 
  END  
  
  CLOSE T22  
  DEALLOCATE T22  
    
  --每次更新复核人  
  --ADD BY TANY 2004-12-15  
  UPDATE ZY_TMPORDERPRT SET AUDITING_USER1=B.AUDITING_USER1  
  FROM ZY_TMPORDERPRT A,##temporder B  
  WHERE A.ORDER_ID=B.ORDER_ID AND B.MNGTYPE IN (1,5)  
        AND A.INPATIENT_ID=@INPATIENT_ID AND A.BABY_ID=@BABY_ID  
    
  --COMMIT  
  
  SELECT CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS EXECTIME,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END))+DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN exec_duser IS NULL THEN -1 ELSE exec_duser END)  END EXECUSER,  
            ORDER_ID,prt_status,pageno,rowno,  --add by zouchihua 2011-12-29 
           CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
  FROM ZY_TMPORDERPRT  
  WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
  ORDER BY PAGENO,ROWNO  
 END--END临时医嘱  
END  --END @TYPE=0  
  
--查询  
IF @TYPE=1   
BEGIN  
 IF @ORDER_TYPE=0   
        BEGIN  
  IF (SELECT ISPRINT FROM ZY_ORDERPRTCFG WHERE ID=11)=0 AND (SELECT ISPRINT FROM ZY_ORDERPRTCFG WHERE ID=12)=0   
  BEGIN  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq  and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60 )
            THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER1 IS NULL 
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN -1 ELSE ORDER_EUSER1 END) END ORDER_EUSER1,  
             ORDER_ID ,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速  
             ,GROUP_ID,
             --CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格
               ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
         ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID ,
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速  
         ,GROUP_ID,
         --CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格
            ORDER_SPEC --药品规格
         ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
       UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,  
       ' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60  ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL 
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60   )
           THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER1 IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq   and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN -1 ELSE ORDER_EUSER1 END) END ORDER_EUSER1,  
             ORDER_ID ,
             '' AS DROPSPER --滴速   
             ,GROUP_ID,
             '' AS ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=2 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID   
   --add by prt_status=4
    UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,  
       ' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
             '' AS EDATE,  
          '' ETIME,  
          '' ORDER_EDOC,  
           '' ORDER_EUSER,  
             '' ORDER_EUSER1,  
             ORDER_ID ,
             '【取消】' DROPSPER --滴速   
             ,GROUP_ID,
             '' ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=4 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID   
   
   ORDER BY PAGENO,ROWNO  
  END  
  ELSE  
  BEGIN  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq  and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL 
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq   and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
           THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER1 IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN -1 ELSE ORDER_EUSER1 END) END ORDER_EUSER1,  
             ORDER_ID ,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速
             ,GROUP_ID,
            -- CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格 
                  ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
             ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID,
              CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速 
              ,GROUP_ID ,
              --CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格
                ORDER_SPEC --药品规格
              ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   ORDER BY PAGENO,ROWNO   
  END  
 END  
 ELSE  
 BEGIN  
  IF (SELECT ISPRINT FROM ZY_ORDERPRTCFG WHERE ID=25)=0  
  BEGIN  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE (case when CONVERT(char,EXECDATE,112)!=CONVERT(char,ORDER_BDATE,112) then SUBSTRING(CONVERT(char,EXECDATE,120),1,16) else SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) end) END END AS ETIME,  --执行时间与开遗嘱时间不同时。要打印日期--SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END)))+','+DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN exec_duser IS NULL THEN -1 ELSE exec_duser END)  END EXECUSER,  
             ORDER_ID ,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速  
             ,GROUP_ID ,
            -- CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格
               ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly ,
              CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
       ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID,
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速   
       ,GROUP_ID,
       --CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格
        ORDER_SPEC --药品规格
       ,case when ntype in(1,2,3) then 1 else 2 end xmly,
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
             ' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,  
       ' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE (case when CONVERT(char,EXECDATE,112)!=CONVERT(char,ORDER_BDATE,112) then SUBSTRING(CONVERT(char,EXECDATE,120),1,16) else SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) end) END END AS ETIME,  --执行时间与开遗嘱时间不同时。要打印日期--SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END))+','+DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN exec_duser IS NULL THEN -1 ELSE exec_duser END)  END EXECUSER,  
             ORDER_ID ,
            '' AS DROPSPER  --滴速 
             ,GROUP_ID  ,
            -- CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格
             '' ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly ,
             -- CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
             '' zldw --Modify by zouchihua 2013-5-30 总量单位不应该打印
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=2 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID     
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
             ' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,  
       ' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
      '' ETIME,  --执行时间与开遗嘱时间不同时。要打印日期--SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
       '' EXECUSER,  
             ORDER_ID ,
       '【取消】'  DROPSPER  --滴速 
             ,GROUP_ID  ,
         '' AS ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly ,
             -- CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
             '' zldw --Modify by zouchihua 2013-5-30 总量单位不应该打印
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=4 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   ORDER BY PAGENO,ROWNO  
  END  
  ELSE  
  BEGIN  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END))+','+DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN exec_duser IS NULL THEN -1 ELSE exec_duser END)  END EXECUSER,  
             ORDER_ID,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速  
             ,GROUP_ID,
           --  CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格
              ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly ,
              CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13   
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
       ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID,
      CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速   
      ,GROUP_ID ,
      --CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_SPEC ELSE ' ' END END AS ORDER_SPEC --药品规格
       ORDER_SPEC --药品规格
      ,case when ntype in(1,2,3) then 1 else 2 end xmly ,
       CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13  
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   ORDER BY PAGENO,ROWNO  
  END  
 END  
END  
  
--更新  
IF @TYPE=2   
BEGIN  
 IF (@BPAGE_NO=0 AND @EPAGE_NO=0)  
 BEGIN  
  IF @ORDER_TYPE=0  
  BEGIN  
   UPDATE ZY_LOGORDERPRT SET PRT_STATUS = 3  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (-1,2,4)  --如果是4 无条件更新为3
   UPDATE ZY_LOGORDERPRT SET PRT_STATUS = 1  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (0)  
    
  END  
  ELSE  
  BEGIN  
   UPDATE ZY_TMPORDERPRT SET PRT_STATUS = 3  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (-1,2,4)  
   UPDATE ZY_TMPORDERPRT SET PRT_STATUS = 1  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (0)  
  END  
 END  
 ELSE  
 BEGIN  
  IF @ORDER_TYPE=0  
  BEGIN  
   UPDATE ZY_LOGORDERPRT SET PRT_STATUS = 3  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (-1,2,4)
   --AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO --add by zouchihua 2012-5-28 重打只更新重打的页面
   and  ( (PAGENO=@BPAGE_NO and ROWNO>=@Brow) or PAGENO>@BPAGE_NO) --Modify by zouchihua  重打只更新重打的页面和页号
   and (  (PAGENO=@EPAGE_NO and ROWNO<=(case when @Erow=-1 then 990 else @Erow end  )) or PAGENO<@EPAGE_NO)  
   UPDATE ZY_LOGORDERPRT SET PRT_STATUS = 1  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (0)  
    --AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
    and  (  (PAGENO=@BPAGE_NO and ROWNO>=@Brow) or PAGENO>@BPAGE_NO)--Modify by zouchihua  重打只更新重打的页面和页号
   and (  (PAGENO=@EPAGE_NO and ROWNO<=(case when @Erow=-1 then 990 else @Erow end  )) or PAGENO<@EPAGE_NO)
  END  
  ELSE  
  BEGIN  
   UPDATE ZY_TMPORDERPRT SET PRT_STATUS = 3  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (-1,2,4) --如果是4 无条件更新为3
   --AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO --add by zouchihua 2012-5-28 重打只更新重打的页面 
   and  (  (PAGENO=@BPAGE_NO and ROWNO>=@Brow) or PAGENO>@BPAGE_NO)--Modify by zouchihua  重打只更新重打的页面和页号
   and ( (PAGENO=@EPAGE_NO and ROWNO<=(case when @Erow=-1 then 990 else @Erow end  )) or PAGENO<@EPAGE_NO)
   UPDATE ZY_TMPORDERPRT SET PRT_STATUS = 1  
   WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PRT_STATUS IN (0)  
    --AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO   
    and  ( (PAGENO=@BPAGE_NO and ROWNO>=@Brow) or PAGENO>@BPAGE_NO)--Modify by zouchihua  重打只更新重打的页面和页号
   and (  (PAGENO=@EPAGE_NO and ROWNO<=(case when @Erow=-1 then 990 else @Erow end  )) or PAGENO<@EPAGE_NO)
  END  
 END  
 --COMMIT  
END  
  
--补打  
IF @TYPE=3  
BEGIN  
 IF @ORDER_TYPE=0  
 BEGIN  
  --add by zouchihua 
 --select * from ##temporder where MNGTYPE=0 and ORDER_CONTEXT like '%术后医嘱%' 
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' 
            ELSE 
              CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL or
                     (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  ) then ''
                    ELSE   RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END
            END AS EDATE,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL 
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
         THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq  and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER1 IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
            THEN -1 ELSE ORDER_EUSER1 END) END ORDER_EUSER1,  
            ORDER_ID,
            CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速 
            ,GROUP_ID ,
            ORDER_SPEC --药品规格 
            ,case when ntype in(1,2,3) then 1 else 2 end xmly
  FROM ZY_LOGORDERPRT  
  WHERE PRT_STATUS IN (-1,2,3) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
        
  UNION ALL  
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
            ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID,
            CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速  
            ,GROUP_ID ,
           ORDER_SPEC --药品规格
            ,case when ntype in(1,2,3) then 1 else 2 end xmly
  FROM ZY_LOGORDERPRT  
  WHERE PRT_STATUS IN(0,1) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
  UNION ALL  
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
            ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID,
            CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速  
            ,GROUP_ID ,
          ORDER_SPEC --药品规格
            ,case when ntype in(1,2,3) then 1 else 2 end xmly
  FROM ZY_LOGORDERPRT  
  WHERE PRT_STATUS IN(4) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
  ORDER BY PAGENO,ROWNO  
 END  
 ELSE  
 BEGIN  
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE (case when CONVERT(char,EXECDATE,112)!=CONVERT(char,ORDER_BDATE,112) then SUBSTRING(CONVERT(char,EXECDATE,120),1,16) else SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) end) END END AS ETIME,  --执行时间与开遗嘱时间不同时。要打印日期--SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END))+','+DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN exec_duser IS NULL THEN -1 ELSE exec_duser END)  END EXECUSER,  
            ORDER_ID ,
            CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速
            ,GROUP_ID ,
          ORDER_SPEC --药品规格
            ,case when ntype in(1,2,3) then 1 else 2 end xmly ,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
  FROM ZY_TMPORDERPRT  
  WHERE PRT_STATUS IN (-1,2,3) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
  UNION ALL  
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
      ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID,
       CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速
       ,GROUP_ID ,
      ORDER_SPEC --药品规格
       ,case when ntype in(1,2,3) then 1 else 2 end xmly,
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13 
  FROM ZY_TMPORDERPRT  
  WHERE PRT_STATUS IN (0,1,4) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO   
  
  ORDER BY PAGENO,ROWNO  
 END  
 --COMMIT  
END  
--add by zouchihua 2011-08-31
--查询 （ 查询医嘱打印时获得用户的id) 而 TYPE=1获得用户姓名
IF @TYPE=4  
BEGIN  
 IF @ORDER_TYPE=0   
        BEGIN  
  IF (SELECT ISPRINT FROM ZY_ORDERPRTCFG WHERE ID=11)=0 AND (SELECT ISPRINT FROM ZY_ORDERPRTCFG WHERE ID=12)=0   
  BEGIN  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
            THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL 
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60  ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
         THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EDOC IS NULL
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN '-1' ELSE convert(char,ORDER_EDOC) END) END ORDER_EDOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EUSER IS NULL
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN '-1' ELSE convert(char,ORDER_EUSER) END) END ORDER_EUSER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EUSER1 IS NULL
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN '-1' ELSE convert(char,ORDER_EUSER1) END) END ORDER_EUSER1,  
             ORDER_ID ,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速 
             ,GROUP_ID ,
              ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly 
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL 
         THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
         ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID,
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速 
         ,GROUP_ID ,
         ORDER_SPEC --药品规格
         ,case when ntype in(1,2,3) then 1 else 2 end xmly  
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
       UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,  
       ' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL 
           or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EDOC IS NULL 
           or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN '-1' ELSE convert(char,ORDER_EDOC) END) END ORDER_EDOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EUSER IS NULL
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN '-1' ELSE convert(char,ORDER_EUSER) END) END ORDER_EUSER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EUSER1 IS NULL
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq   and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN '-1' ELSE convert(char,ORDER_EUSER1) END) END ORDER_EUSER1,  
             ORDER_ID ,
             --CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速  
             '' DROPSPER  --滴速  
             ,GROUP_ID,
             ''  ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=2 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID
   union all
   --增加取消 =4
    SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,  
       ' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
             '' AS EDATE,  
          '' ETIME,  
          '' ORDER_EDOC,  
           '' ORDER_EUSER,  
             '' ORDER_EUSER1,  
             ORDER_ID ,
             '【取消】' DROPSPER --滴速   
             ,GROUP_ID,
             '' ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=4 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID   
   
   ORDER BY PAGENO,ROWNO  
  END  
  ELSE  
  BEGIN  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL 
           or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EDOC IS NULL 
           or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN '-1' ELSE convert(char,ORDER_EDOC) END) END ORDER_EDOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EUSER IS NULL
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq   and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN '-1' ELSE convert(char,ORDER_EUSER) END) END ORDER_EUSER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE (CASE WHEN ORDER_EUSER1 IS NULL
              or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
              THEN '-1' ELSE convert(char,ORDER_EUSER1) END) END ORDER_EUSER1,  
             ORDER_ID  ,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速
             ,GROUP_ID ,
             ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly     
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
             ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID ,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER  --滴速   
             ,GROUP_ID ,
            ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly
   FROM ZY_LOGORDERPRT  
   WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   
   ORDER BY PAGENO,ROWNO   
  END  
 END  
 ELSE  
 BEGIN  
  IF (SELECT ISPRINT FROM ZY_ORDERPRTCFG WHERE ID=25)=0  
  BEGIN  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE (case when CONVERT(char,EXECDATE,112)!=CONVERT(char,ORDER_BDATE,112) then SUBSTRING(CONVERT(char,EXECDATE,120),1,16) else SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) end) END END AS ETIME,  --执行时间与开遗嘱时间不同时。要打印日期--SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN EXEUSER IS NULL THEN '-1' ELSE convert(char,EXEUSER)+','+convert(char,isnull(exec_duser,'-1')) END) END EXECUSER,  
             ORDER_ID ,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速
             ,GROUP_ID ,
      ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly,
              CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
       ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID,
       CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速 
       ,GROUP_ID  ,
  ORDER_SPEC --药品规格
       ,case when ntype in(1,2,3) then 1 else 2 end xmly,
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
             ' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,  
       ' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE (case when CONVERT(char,EXECDATE,112)!=CONVERT(char,ORDER_BDATE,112) then SUBSTRING(CONVERT(char,EXECDATE,120),1,16) else SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) end) END END AS ETIME,  --执行时间与开遗嘱时间不同时。要打印日期--SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN EXEUSER IS NULL THEN '-1' ELSE convert(char,EXEUSER)+','+convert(char,isnull(exec_duser,'-1')) END) END EXECUSER,  
             ORDER_ID ,
        '' DROPSPER --滴速 
             ,GROUP_ID ,
        '' ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly,
             -- CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
            '' zldw --Modify by zouchihua 2013-5-30 总量单位不应该打印
           --增加了总量打印 add by zouchihua 2012-12-13 
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=2 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
             ' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,  
       ' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
      '' ETIME,  --执行时间与开遗嘱时间不同时。要打印日期--SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
       '' EXECUSER,  
             ORDER_ID ,
       '【取消】'  DROPSPER  --滴速 
             ,GROUP_ID  ,
         '' AS ORDER_SPEC --药品规格
             ,case when ntype in(1,2,3) then 1 else 2 end xmly ,
             -- CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
             '' zldw --Modify by zouchihua 2013-5-30 总量单位不应该打印
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=4 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID     
   ORDER BY PAGENO,ROWNO  
  END  
  ELSE  
  BEGIN  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE (case when CONVERT(char,EXECDATE,112)!=CONVERT(char,ORDER_BDATE,112) then SUBSTRING(CONVERT(char,EXECDATE,120),1,16) else SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) end) END END AS ETIME,  --执行时间与开遗嘱时间不同时。要打印日期--SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN EXEUSER IS NULL THEN '-1' ELSE convert(char,EXEUSER)+','+convert(char,isnull(exec_duser,'-1')) END) END EXECUSER,  
             ORDER_ID ,
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速 
          ,GROUP_ID ,
             ORDER_SPEC --药品规格
          ,case when ntype in(1,2,3) then 1 else 2 end xmly,
           CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT  
   WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   UNION ALL  
   SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
       CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
          ORDER_CONTEXT,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT
))))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
             CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
          CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
             CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
       ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID ,
       CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速
       ,GROUP_ID ,
        ORDER_SPEC --药品规格
       ,case when ntype in(1,2,3) then 1 else 2 end xmly,
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
   FROM ZY_TMPORDERPRT     
   WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
   ORDER BY PAGENO,ROWNO  
  END  
 END  
END  
--add by zouchihua 2011-08-31
--查询 （ 查询医嘱打印时获得用户的id) 而 TYPE=3获得用户姓名
IF @TYPE=5  
BEGIN  
 IF @ORDER_TYPE=0  
 BEGIN  
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN  ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
             THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq   and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
          THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EDOC IS NULL 
          or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
         THEN '-1' ELSE convert(char,ORDER_EDOC) END) END ORDER_EDOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EUSER IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq  and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
            THEN '-1' ELSE convert(char,ORDER_EUSER) END) END ORDER_EUSER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_EUSER1 IS NULL 
             or  (ORDER_BDATE<=@CyyzKsrq and ORDER_EDATE>=@CyyzKsrq) or (ORDER_BDATE<=@ZkYzKsRq  and ORDER_EDATE>=@ZkYzKsRq   and  DATEDIFF(ss,@ZkYzKsRq,ORDER_EDATE)<60 ) or
                         (ORDER_BDATE<=@ShYzKsRq  and ORDER_EDATE>=@ShYzKsRq and  DATEDIFF(ss,@ShYzKsRq,ORDER_EDATE)<60  )
            THEN '-1' ELSE convert(char,ORDER_EUSER1) END) END ORDER_EUSER1,  
            ORDER_ID ,
           CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速
          , GROUP_ID,
           ORDER_SPEC --药品规格
          ,case when ntype in(1,2,3) then 1 else 2 end xmly
  FROM ZY_LOGORDERPRT  
  WHERE PRT_STATUS IN (-1,2,3) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
  UNION ALL  
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND  @cfg7139='0' and  num<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
            ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID  ,
            CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS DROPSPER --滴速
            ,GROUP_ID,
       ORDER_SPEC --药品规格
            ,case when ntype in(1,2,3) then 1 else 2 end xmly
  FROM ZY_LOGORDERPRT  
  WHERE PRT_STATUS IN(0,1,4) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
  ORDER BY PAGENO,ROWNO  
 END  
 ELSE  
 BEGIN  
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE (CASE WHEN AUDITING_USER1  IS NULL THEN '-1' ELSE convert(char,AUDITING_USER1) END) END ORDER_USER1,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE (case when CONVERT(char,EXECDATE,112)!=CONVERT(char,ORDER_BDATE,112) then SUBSTRING(CONVERT(char,EXECDATE,120),1,16) else SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) end) END END AS ETIME,  --执行时间与开遗嘱时间不同时。要打印日期
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN EXEUSER IS NULL THEN '-1' ELSE convert(char,EXEUSER)+','+convert(char,isnull(exec_duser,'-1')) END) END EXECUSER,  
            ORDER_ID,
            CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS  DROPSPER --滴速  
            ,GROUP_ID,
  ORDER_SPEC --药品规格
            ,case when ntype in(1,2,3) then 1 else 2 end xmly,
             CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
  FROM ZY_TMPORDERPRT  
  WHERE PRT_STATUS IN (-1,2,3) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
  UNION ALL  
  SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
      CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
         ORDER_CONTEXT,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN (NTYPE=3 and  @cs7136='0') THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT)
)))+LTRIM(RTRIM(UNIT)) END AS NUMUNIT,  
            CASE WHEN GROUP_STATUS=0 OR (case when @cs7136='0' then NTYPE else 1 end ) NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR NTYPE NOT IN (1,2,3,7)*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
         CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
         CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN '-1' ELSE convert(char,ORDER_DOC) END) END ORDER_DOC,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER IS NULL THEN '-1' ELSE convert(char,AUDITING_USER) END) END ORDER_USER,  
            CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN AUDITING_USER1 IS NULL THEN '-1' ELSE convert(char,EXEUSER)+','+convert(char,isnull(exec_duser,'-1')) END) END ORDER_USER1,  
      ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID,
      CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 /*OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD')*/ THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN DROPSPER ELSE ' ' END END AS  DROPSPER --滴速 
      ,GROUP_ID ,
     ORDER_SPEC --药品规格
      ,case when ntype in(1,2,3) then 1 else 2 end xmly,
       CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE  not IN (1,2,3)  THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CONVERT(CHAR,CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(zl AS FLOAT))))+LTRIM(RTRIM(zldw)) END AS zldw
           --增加了总量打印 add by zouchihua 2012-12-13
  FROM ZY_TMPORDERPRT  
  WHERE PRT_STATUS IN (0,1,4) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO   
  ORDER BY PAGENO,ROWNO  
 END  
 --COMMIT  
END  

/******************************废代码  
 --@TYPE=0  
 --生成新的医嘱，生成停止医嘱  
 DECLARE @LOGORDERINFO VARCHAR(1024)  
 SELECT CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
  CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
  ORDER_CONTEXT,  
  CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM(RTRIM
(UNIT)) END AS NUMUNIT,  
  CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
  CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
  CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
  CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE  (CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
  CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
  CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,
DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
  CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
  CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
  CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
  ORDER_ID  
 FROM ZY_LOGORDERPRT  
 WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 ORDER BY PAGENO,ROWNO   
   
 DECLARE @TMPORDERINFO  VARCHAR(1024)  
 SELECT CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS EXECTIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END)) END EXECUSER,  
           ORDER_ID  
 FROM ZY_TMPORDERPRT  
 WHERE INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 ORDER BY PAGENO,ROWNO  
   
 --@TYPE=1  
 --查询需要打印的医嘱  
 DECLARE @LOGORDERPRT  VARCHAR(1024)  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONV
ERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER1 IS NULL THEN -1 ELSE ORDER_EUSER1 END) END ORDER_EUSER1,  
           ORDER_ID  
 FROM ZY_LOGORDERPRT  
 WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 UNION ALL  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
           ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID  
 FROM ZY_LOGORDERPRT  
 WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
     UNION ALL  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,  
     ' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONV
ERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER1 IS NULL THEN -1 ELSE ORDER_EUSER1 END) END ORDER_EUSER1,  
           ORDER_ID  
 FROM ZY_LOGORDERPRT  
 WHERE PRT_STATUS=2 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID   
 ORDER BY PAGENO,ROWNO  
  
 --不打印停止日期时间  
 DECLARE @LOGORDERPRT2 VARCHAR(1024)  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONV
ERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER1 IS NULL THEN -1 ELSE ORDER_EUSER1 END) END ORDER_EUSER1,  
           ORDER_ID  
 FROM ZY_LOGORDERPRT  
 WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 UNION ALL  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
           ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID  
 FROM ZY_LOGORDERPRT  
 WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 ORDER BY PAGENO,ROWNO   
    
 DECLARE @TMPORDERPRT VARCHAR(1024)  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END)) END EXECUSER,  
           ORDER_ID  
 FROM ZY_TMPORDERPRT  
 WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 UNION ALL  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
     ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID  
 FROM ZY_TMPORDERPRT  
 WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 UNION ALL  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
           ' ' AS BDATE,' ' AS BTIME,' ' AS ORDER_CONTEXT,' ' AS NUMUNIT,' ' AS GROUP_STATUS ,' ' AS ORDER_USAGE,  
     ' ' AS FREQUENCY,' ' AS ORDER_DOC,' ' AS ORDER_USER,' ' AS ORDER_USER1,  
          CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END)) END EXECUSER,  
           ORDER_ID  
 FROM ZY_TMPORDERPRT  
 WHERE PRT_STATUS=2 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID     
 ORDER BY PAGENO,ROWNO  
   
 --不打印执行时间  
 DECLARE @TMPORDERPRT2 VARCHAR(1024)  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END)) END EXECUSER,  
           ORDER_ID  
 FROM ZY_TMPORDERPRT  
 WHERE PRT_STATUS=-1 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 UNION ALL  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
     ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID  
 FROM ZY_TMPORDERPRT  
 WHERE PRT_STATUS=0 AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID  
 ORDER BY PAGENO,ROWNO  
  
 --@TYPE=3  
 --  
 DECLARE @RLOGORDERPRT VARCHAR(1024)  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_EDATE))) IS NULL THEN ' ' ELSE RTRIM(CONVERT(CHAR,DATEPART(MM,ORDER_EDATE)))+'-'+RTRIM(CONV
ERT(CHAR,DATEPART(DD,ORDER_EDATE))) END END AS EDATE,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_EDATE,108),1,5) END END AS ETIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EDOC IS NULL THEN -1 ELSE ORDER_EDOC END) END ORDER_EDOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER IS NULL THEN -1 ELSE ORDER_EUSER END) END ORDER_EUSER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_EUSER1 IS NULL THEN -1 ELSE ORDER_EUSER1 END) END ORDER_EUSER1,  
           ORDER_ID  
 FROM ZY_LOGORDERPRT  
 WHERE PRT_STATUS IN (-1,2,3) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
 UNION ALL  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
           ' ' AS EDATE,' ' AS ETIME,' ' AS ORDER_EDOC,' ' AS ORDER_EUSER,' ' AS ORDER_EUSER1,ORDER_ID  
 FROM ZY_LOGORDERPRT  
 WHERE PRT_STATUS IN(0,1) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
 ORDER BY PAGENO,ROWNO  
    
 DECLARE @RTMPORDERPRT VARCHAR(1024)  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE CASE WHEN SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) IS NULL THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,EXECDATE,108),1,5) END END AS ETIME,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE rtrim(DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN EXEUSER IS NULL THEN -1 ELSE EXEUSER END)) END EXECUSER,  
           ORDER_ID  
 FROM ZY_TMPORDERPRT  
 WHERE PRT_STATUS IN (-1,2,3) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO  
 UNION ALL  
 SELECT PAGENO,ROWNO,PAGE_STATUS,ROW_STATUS,PRT_STATUS,ORDER_ID,  
     CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE RTRIM(SUBSTRING( CONVERT(varchar, ORDER_BDATE, 120 ),0,8))+'-'+RTRIM(CONVERT(CHAR,DATEPART(DD,ORDER_BDATE))) END AS BDATE,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE SUBSTRING(CONVERT(CHAR,ORDER_BDATE,108),1,5) END AS BTIME,  
        ORDER_CONTEXT,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND (case when @cfg7139='1' then 3 else num end)<=1) OR (NUM=0 AND NTYPE<>3) THEN ' ' WHEN NTYPE=3 THEN LTRIM(RTRIM(CHAR(CONVERT(INT,DOSAGE))))+'付' ELSE LTRIM(RTRIM(CONVERT(CHAR,CAST(NUM AS FLOAT))))+LTRIM
(RTRIM(UNIT)) END AS NUMUNIT,  
           CASE WHEN GROUP_STATUS=0 OR NTYPE NOT IN (1,2) THEN ' ' WHEN GROUP_STATUS=1 THEN '┓' WHEN GROUP_STATUS=2 THEN '┃' WHEN GROUP_STATUS=3 THEN '┛' END AS GROUP_STATUS,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR NTYPE NOT IN (1,2,3,7) THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN ORDER_USAGE ELSE ' ' END END AS ORDER_USAGE,  
        CASE WHEN LTRIM(RTRIM(ORDER_CONTEXT))='┃' OR ROW_STATUS=2 OR (NTYPE NOT IN (1,2,3) AND UPPER(FREQUENCY)='QD') THEN ' ' ELSE CASE WHEN (GROUP_STATUS=0 OR GROUP_STATUS=1) THEN FREQUENCY ELSE ' ' END END AS FREQUENCY,  
        CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN ORDER_DOC IS NULL THEN -1 ELSE ORDER_DOC END) END ORDER_DOC,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER IS NULL THEN -1 ELSE AUDITING_USER END) END ORDER_USER,  
           CASE LTRIM(RTRIM(ORDER_CONTEXT)) WHEN '┃' THEN ' ' ELSE DBO.FUN_ZY_SEEKEMPLOYEENAME(CASE WHEN AUDITING_USER1 IS NULL THEN -1 ELSE AUDITING_USER1 END) END ORDER_USER1,  
     ' ' AS ETIME,' ' AS EXECUSER,ORDER_ID  
 FROM ZY_TMPORDERPRT  
 WHERE PRT_STATUS IN (0,1) AND INPATIENT_ID=@INPATIENT_ID AND BABY_ID=@BABY_ID AND PAGENO BETWEEN @BPAGE_NO AND @EPAGE_NO   
 ORDER BY PAGENO,ROWNO  
******************************/  
  
  /* 0=时候 核对护士不打印。 改成2的时候打印核对护士
  */

GO


