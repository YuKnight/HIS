IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_select_PYCF' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_select_PYCF
GO
CREATE PROCEDURE sp_yf_select_PYCF 
(
 	@functionName varchar(30),--构造函数
	@deptid INTEGER,--药房代码
	@hzxm varchar(12),--忠者姓名
	@FPH bigint,	   --发票号
	@klx int,
	@tmk varchar(30),
	@mzh varchar(12),
	@pyckh varchar(100),
	@pyrq1 varchar(30),
    @pyrq2 varchar(30),
	@bk int,
	@sfrq1 varchar(30),
	@sfrq2 varchar(30)
)

/*
  查找配药处方
*/
--exec sp_yf_select_pyCF 'Fun_ts_yf_mzpy',35,'',0,0,'','','','','',0
--select * from gh_ghzdk

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


set @ssql='select top 50 ''0'' 序号,A.fph 发票号,A.zje 金额,a.BRXM 姓名,'+
' A.blh 门诊号,'''' 发药窗口, FPID,DNLSH 发票流水号 from '+ rtrim(@table_FPB) +' a (nolock) '+
' where a.JLZT=0 AND A.BSCBZ=0  
  and fpid in(select fpid  from '+RTRIM(@table_CFB)+' b(nolock) where B.XMLY=1 and B.BSCBZ=0 '+
' and b.ZXKS='+cast(@deptid as VARCHAR(20)) +' and B.Bpybz=0 and b.bfybz=0 '

if rtrim(@pyckh)=''
	set @ssql=@ssql+' and (fyck is null or fyck='''' or fyck=''0'')'
else
set @ssql=@ssql+' and fyck in(select fyckdm from JC_pfdyk(nolock) where pyckdm='''+@pyckh+''' and yfdm='+cast(@deptid as varchar(12))+') ';


set @ssql=@ssql+' and b.sfrq>='''+@sfrq1+' 00:00:00'' and b.sfrq<='''+@sfrq2+' 23:59:59'''
   
   
if @fph>0 
     set @ssql=@ssql+' and b.fph='+cast(@fph as varchar(20))+' ';
   
   
if rtrim(@PYRQ1)<>'' 
     set @ssql=@ssql+' and pyrq>='''+@PYRQ1+' 00:00:00'' and pyrq<='''+@PYRQ2+' 23:59:59''';

set @ssql=@ssql+') '
if rtrim(@hzxm)<>''
   	  set @ssql=@ssql+' and A.brxm like ''%'+@hzxm+'%''';

  
set @ssql=@ssql+' order by brxxid,a.fph';

   
print @ssql
exec(@ssql)
end 