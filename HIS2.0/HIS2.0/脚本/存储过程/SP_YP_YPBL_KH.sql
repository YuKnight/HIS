IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_YPBL_KH' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_YPBL_KH
GO

create proc SP_YP_YPBL_KH
(
  @Year INT,
  @Month INT,
  @jgbm int
)
--生成每日医生药品比例中间表
-- exec SP_YP_YPBL_KH 2013,2,1001
as

DECLARE @KSRQ DATETIME
DECLARE @JSRQ DATETIME

set @KSRQ=CAST(@year as varchar(20))+'-'+CAST(@Month as varchar(20))+'-01'
if @Month=MONTH(GETDATE())
	set @jsrq=GETDATE()
else
	set @jsrq=(SELECT DATEADD(Day,-1,CONVERT(char(8),DATEADD(Month,1,@KSRQ),120)+'1') )
	
	
------------------------------------门诊-------------------------------------------
create table #tempYpitem(ksdm int,ysdm int,zje float,xyje float,cyje float,zyje float,qz_clje float,qz_zzyje float) 

--如果有门诊相关表的设置就生成中间数据
IF EXISTS(SELECT * FROM JC_YPKHBL WHERE BZYBZ=0 and BQYBZ=1 and khlxid=1 )
begin

    --先删除原来的数据
	delete from YP_YPKHBL_YWSJ where NF=@Year and YF=@Month and JCID in(select ID from JC_YPKHBL where khlxid=1 and BZYBZ=0 ) 
	
	insert into #tempYpitem(ksdm,ysdm,zje,xyje,cyje,zyje,qz_clje,qz_zzyje) 
	select KSDM,ysdm,
	SUM(je),
	sum(case when xmdm in('01') then je else 0 end) xyje,
	sum(case when xmdm in('02') then je else 0 end) cyje, 
	sum(case when xmdm in('03') then je else 0 end) zyje, 
	sum(case when xmdm in('25','26')then je else 0 end) qz_clje,
	0 qz_zzyje
	from vi_mz_fpb A INNER JOIN vi_mz_fpb_dxmmx B ON A.FPID=B.FPID
	WHERE 
	YEAR(sfrq)=@Year and MONTH(SFRQ)=@month and A.JGBM=@jgbm
	group by ksdm,ysdm
	
	insert into #tempYpitem(ksdm,ysdm,zje,xyje,cyje,zyje,qz_clje,qz_zzyje)     
	select  
	KSDM, YSDM,      
	0  ,0,0,0,0,SUM(je)
	from mz_cfb A INNER JOIN mz_cfb_mx B ON A.CFID=B.CFID 
	inner join 
	(select cjid from vi_yp_ypcd where YPLX<>2 AND  ypzlx in (select id from yp_ypzlx where mc like '%自制%')) c     
	ON B.XMID=C.CJID AND A.XMLY=1      
	WHERE YEAR(sfrq)=@Year and MONTH(SFRQ)=@month and JGBM=@jgbm and a.BSCBZ=0 
	group by ksdm,ysdm
end



--按科室生成
IF EXISTS(SELECT * FROM JC_YPKHBL WHERE BZYBZ=0 AND KSDM>0 AND YSDM=0  and khlxid=1 and BQYBZ=1)
begin
  INSERT INTO YP_YPKHBL_YWSJ(JCID,NF,YF,YPBL,KSRQ,JSRQ,djsj)
  select b.id,@Year,@Month,
  (case when (sum(zje)-sum(qz_clje))<>0 then cast(((sum(xyje)+sum(cyje)-sum(qz_zzyje))/(sum(zje)-sum(qz_clje))*100)AS decimal(10,2)) else 0 end) YPBL,
  @KSRQ,@JSRQ,GETDATE()
  from #tempYpitem a inner join JC_YPKHBL b  on a.ksdm=b.KSDM
  where BZYBZ=0 and b.ksdm>0 and b.ysdm=0 and khlxid=1 and BQYBZ=1 group by b.ID ,a.ksdm
end
--按医生生成
IF EXISTS(SELECT * FROM JC_YPKHBL WHERE BZYBZ=0 AND YSDM>0 AND KSDM=0  and khlxid=1 and BQYBZ=1)
begin
  INSERT INTO YP_YPKHBL_YWSJ(JCID,NF,YF,YPBL,KSRQ,JSRQ,DJSJ)
  select b.id,@Year,@Month,
  (case when (sum(zje)-sum(qz_clje))<>0 then cast(((sum(xyje)+sum(cyje)-sum(qz_zzyje))/(sum(zje)-sum(qz_clje))*100)AS decimal(10,2)) else 0 end) YPBL,
  @KSRQ,@JSRQ,GETDATE()
  from #tempYpitem a inner join JC_YPKHBL b  on a.ysdm=b.YSDM
  where BZYBZ=0 and b.ysdm>0 and b.KSDM=0 and khlxid=1 and BQYBZ=1 group by b.ID ,a.ysdm
end
--按科室和医生生成
IF EXISTS(SELECT * FROM JC_YPKHBL WHERE BZYBZ=0 AND YSDM>0 AND KSDM>0  and khlxid=1 and BQYBZ=1 )
begin
  INSERT INTO YP_YPKHBL_YWSJ(JCID,NF,YF,YPBL,KSRQ,JSRQ,DJSJ)
  select b.id,@Year,@Month,
  (case when (sum(zje)-sum(qz_clje))<>0 then cast(((sum(xyje)+sum(cyje)-sum(qz_zzyje))/(sum(zje)-sum(qz_clje))*100)AS decimal(10,2)) else 0 end) YPBL,
  @KSRQ,@JSRQ,GETDATE()
  from #tempYpitem a inner join JC_YPKHBL b  on a.ksdm=b.KSDM and a.ysdm=b.YSDM
  where BZYBZ=0 and b.ysdm>0 and b.KSDM>0 and khlxid=1 and BQYBZ=1 group by b.ID ,a.ksdm,a.ysdm
end
--------------------------------------------------------------------------------------------------------




------------------------------------住院-------------------------------------------
truncate  table #tempYpitem
IF EXISTS(SELECT * FROM JC_YPKHBL WHERE BZYBZ=1 and BQYBZ=1  and khlxid=1 )
begin

    --先删除原来的数据
	delete from YP_YPKHBL_YWSJ where NF=@Year and YF=@Month and JCID in(select ID from JC_YPKHBL where khlxid=1 and BZYBZ=1 ) 
	
	insert into #tempYpitem(ksdm,ysdm,zje,xyje,cyje,zyje,qz_clje,qz_zzyje) 
	select  dept_id,DOC_ID,
	SUM(SDVALUE),
	sum(case when STATITEM_CODE in('01') then SDVALUE else 0 end) xyje,
	sum(case when STATITEM_CODE in('02') then SDVALUE else 0 end) cyje, 
	sum(case when STATITEM_CODE in('03') then SDVALUE else 0 end) zyje, 
	sum(case when STATITEM_CODE in('25','26')then SDVALUE else 0 end) qz_clje,
	SUM(case when b.ggid is null then 0 else sdvalue end) qz_zzyje
	from ZY_FEE_SPECI  a left join 
	(select cjid,GGID from vi_yp_ypcd where YPLX<>2 AND  ypzlx in (select id from yp_ypzlx where mc like '%自制%')) b   on a.XMID=b.cjid and a.XMLY=1 
	WHERE 
	YEAR(CHARGE_DATE)=@Year and MONTH(CHARGE_DATE)=@month and DELETE_BIT=0 and CHARGE_BIT=1 and A.JGBM=@jgbm
	group by dept_id,DOC_ID

	insert into #tempYpitem(ksdm,ysdm,zje,xyje,cyje,zyje,qz_clje,qz_zzyje)     
	select  
	KSDM, YSDM,      
	0  ,0,0,0,0,SUM(je)
	from mz_cfb A INNER JOIN mz_cfb_mx B ON A.CFID=B.CFID 
	inner join 
	(select cjid from vi_yp_ypcd where YPLX<>2 AND  ypzlx in (select id from yp_ypzlx where mc like '%自制%')) c     
	ON B.XMID=C.CJID AND A.XMLY=1      
	WHERE YEAR(sfrq)=@Year and MONTH(SFRQ)=@month and JGBM=@jgbm and a.BSCBZ=0 
	group by ksdm,ysdm
end

--按科室生成
IF EXISTS(SELECT * FROM JC_YPKHBL WHERE BZYBZ=0 AND KSDM>0 AND YSDM=0  and khlxid=1 and BQYBZ=1)
begin
  INSERT INTO YP_YPKHBL_YWSJ(JCID,NF,YF,YPBL,KSRQ,JSRQ,djsj)
  select b.id,@Year,@Month,
  (case when (sum(zje)-sum(qz_clje))<>0 then cast(((sum(xyje)+sum(cyje)-sum(qz_zzyje))/(sum(zje)-sum(qz_clje))*100)AS decimal(10,2)) else 0 end) YPBL,
  @KSRQ,@JSRQ,GETDATE()
  from #tempYpitem a inner join JC_YPKHBL b  on a.ksdm=b.KSDM
  where BZYBZ=1 and b.ksdm>0 and b.ysdm=0  and khlxid=1 and BQYBZ=1  group by b.ID ,a.ksdm
end
--按医生生成
IF EXISTS(SELECT * FROM JC_YPKHBL WHERE BZYBZ=0 AND YSDM>0 AND KSDM=0  and khlxid=1 and BQYBZ=1)
begin
  INSERT INTO YP_YPKHBL_YWSJ(JCID,NF,YF,YPBL,KSRQ,JSRQ,DJSJ)
  select b.id,@Year,@Month,
(case when (sum(zje)-sum(qz_clje))<>0 then cast(((sum(xyje)+sum(cyje)-sum(qz_zzyje))/(sum(zje)-sum(qz_clje))*100)AS decimal(10,2)) else 0 end) YPBL,
  @KSRQ,@JSRQ,GETDATE()
  from #tempYpitem a inner join JC_YPKHBL b  on a.ysdm=b.YSDM
  where BZYBZ=1 and b.ysdm>0 and b.KSDM=0 and khlxid=1 and BQYBZ=1  group by b.ID ,a.ysdm
end
--按科室和医生生成
IF EXISTS(SELECT * FROM JC_YPKHBL WHERE BZYBZ=0 AND YSDM>0 AND KSDM>0  and khlxid=1 and BQYBZ=1 )
begin
  INSERT INTO YP_YPKHBL_YWSJ(JCID,NF,YF,YPBL,KSRQ,JSRQ,djsj)
  select b.id,@Year,@Month,
(case when (sum(zje)-sum(qz_clje))<>0 then cast(((sum(xyje)+sum(cyje)-sum(qz_zzyje))/(sum(zje)-sum(qz_clje))*100)AS decimal(10,2)) else 0 end) YPBL,
  @KSRQ,@JSRQ,GETDATE()
  from #tempYpitem a inner join JC_YPKHBL b  on a.ksdm=b.KSDM and a.ysdm=b.YSDM
  where BZYBZ=1 and b.ysdm>0 and b.KSDM>0 and khlxid=1 and BQYBZ=1 group by b.ID ,a.ksdm,a.ysdm
end
--------------------------------------------------------------------------------------------------------

