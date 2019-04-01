IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_FY_ZYCF' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_FY_ZYCF
GO
CREATE PROCEDURE sp_YF_FY_ZYCF
(
 	@CFLX char(2) ,
	@JSSJH DECIMAL(21,6),--传处方号
	@FPH BIGINT ,		  --可不传
	@ZJE DECIMAL(15,3) ,--处方金额
	@CFTS INT ,--处方贴数
	@CFXH UNIQUEIDENTIFIER ,		 --可不传
	@PATID UNIQUEIDENTIFIER ,
	@PATIENTNO varchar(50),--住院号
	@HZXM VARCHAR(12),--病人姓名
	@YSDM INTEGER ,--医生
	@KSDM INTEGER ,--科室
	@SKRQ datetime,--记费日期
	@SKY INTEGER ,--记费员
	@FYRQ datetime,--发药日期
	@FYR INT ,--发药员
	@PYR INT ,--配药员
	@PYCKH CHAR(2) ,--可不传
	@FYCKH CHAR(2) ,--可不传
	@DEPTID INT ,--药房ID
	@TFBZ SMALLINT,--可不传
	@YWLX CHAR(3),
	@wkdz varchar(50),
	@FYID UNIQUEIDENTIFIER output,
	@ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(100) output,
	@jgbm bigint
)
as
 begin


 
set @Err_Code=-1;
set @Err_Text='';
--set @fyid=0;
if @CFXH=dbo.FUN_GETEMPTYGUID()
set @cfxh=null 
 
set @err_text='插入';
set @fyid=dbo.FUN_GETGUID(newid(),getdate())
insert into yf_FY(id,jgbm,cflx,JSSJH,FPH,zje,cfts,CFXH,PATID,PATIENTNO,HZXM,YSDM,KSDM,SKRQ,SKY,FYRQ,FYR,PYR,PYCKH,FYCKH,DEPTID,JZCFBZ,TFBZ,YWLX,wkdz)
values(@fyid,@jgbm,@cflx,@JSSJH,@FPH,@zje,@cfts,@CFXH,@PATID,@PATIENTNO,@HZXM,@YSDM,@KSDM,@SKRQ,@SKY,@FYRQ,@FYR,@PYR,@PYCKH,@FYCKH,@DEPTID,1,@TFBZ,@YWLX,@wkdz);
 
--set @FYID=@@IDENTITY;

if @@rowcount=0 OR @FYID=dbo.FUN_GETEMPTYGUID() or @fyid is null  
begin
	    set @err_text='插入发药头表没有成功，影响到数据库0行';
	    return;
end

  
  SET @ERR_TEXT='发药成功'+CAST(@FYID AS CHAR(50));
  SET @ERR_CODE=0;
end;


