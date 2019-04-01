IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_select_MZCF_REF' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_select_MZCF_REF
GO
CREATE PROCEDURE sp_yf_select_MZCF_REF 
(
 	@functionName varchar(30),
	@deptid INTEGER,
	@rq1 varchar(30),
    @rq2 varchar(30),
	@FYCK VARCHAR(30),
	@bk int,
	@fybz int
)

/*
  查找配药处方
*/
--exec sp_yf_select_MZCF_REF 'Fun_ts_yf_mzpy',39,'','',0,0,1
--select * from yp_yjks

as
begin
declare @table_CFB varchar(100);
declare @table_FPB varchar(100);
declare @ssql varchar(2000);
set @table_CFB='mz_cfb';
set @table_FPB='mz_FPB';
if @bk=1 
begin
 	 set @table_CFB='mz_cfb_H';
	 set @table_FPB='mz_FPB_H';
end  

DECLARE @cs int
set @cs=(select CONFIG from jc_config where id=8027)

declare @pyms int
set @pyms=(select zt from YK_CONFIG where DEPTID=@deptid and BH=106)
if @pyms is null set @pyms=0

declare @qzpy int
set @qzpy=(select zt from YK_CONFIG where DEPTID=@deptid and BH=107)
if @qzpy is null set @qzpy=0

if @cs=1
begin
	set @ssql='select 0 选择,  ''0'' 序号,a.BRXM 姓名,A.fph 发票号,A.zje 金额,a.brxxid,
	 (case when b.bdybz is null then 0 else 1 end) 打印,a.fpid  '+
	' from '+ rtrim(@table_FPB) +' a (nolock)  LEFT JOIN YF_FYJH B(NOLOCK) '+
	' ON A.FPID=B.FPID  where a.JLZT=0 AND A.BSCBZ=0  
	  and a.fpid in(select fpid  from '+RTRIM(@table_CFB)+' b(nolock) where B.XMLY=1 and B.BSCBZ=0 '+
	' and b.ZXKS='+cast(@deptid as VARCHAR(20)) +'  '   
	if rtrim(@rq1)<>'' and @fybz=0 
		 set @ssql=@ssql+' AND BFYBZ=0 and SFRQ>='''+@rq1+' 00:00:00'' and SFRQ<='''+@rq2+' 23:59:59''';
	if rtrim(@rq1)<>'' and @fybz=1 
		 set @ssql=@ssql+' AND BFYBZ=1 and FYRQ>='''+@rq1+' 00:00:00'' and FYRQ<='''+@rq2+' 23:59:59''';
	if @pyms=1 and rtrim(@FYCK)<>'' 
		 set @ssql=@ssql+' and fyck='''+@fyck+''' '
	if @qzpy=1
		 set @ssql=@ssql+' and bpybz=1 ' 
	set @ssql=@ssql+') ' 
	set @ssql=@ssql+' order by a.fph';
end
else
begin
	set @ssql='select 0 选择, ''0'' 序号,a.BRXM 姓名,'''' 发票号,sum(A.zje) 金额,a.brxxid,
	(case when b.bdybz is null then 0 else 1 end) 打印,null fpid  '+
	' from '+ rtrim(@table_FPB) +' a (nolock) LEFT JOIN YF_FYJH B(NOLOCK) '+
	' ON A.FPID=B.FPID  where a.JLZT=0 AND A.BSCBZ=0  
	  and a.fpid in(select fpid  from '+RTRIM(@table_CFB)+' b(nolock) where B.XMLY=1 and B.BSCBZ=0 '+
	' and b.ZXKS='+cast(@deptid as VARCHAR(20)) +' and b.bfybz=0 '   
	if rtrim(@rq1)<>'' and @fybz=0
		 set @ssql=@ssql+' AND BFYBZ=0 and SFRQ>='''+@rq1+' 00:00:00'' and SFRQ<='''+@rq2+' 23:59:59''';
	if rtrim(@rq1)<>'' and @fybz=1
		 set @ssql=@ssql+' AND BFYBZ=1 and FYRQ>='''+@rq1+' 00:00:00'' and FYRQ<='''+@rq2+' 23:59:59''';
	if @pyms=1 and rtrim(@FYCK)<>''
		 set @ssql=@ssql+' and fyck='''+@fyck+''' '
	if @qzpy=1
		 set @ssql=@ssql+' and bpybz=1 '
	set @ssql=@ssql+') '
	set @ssql=@ssql+' group by a.brxm,a.brxxid,BDYBZ';
end
   
print @ssql
exec(@ssql)
end 