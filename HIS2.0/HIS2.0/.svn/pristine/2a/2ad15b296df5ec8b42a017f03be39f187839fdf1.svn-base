
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_YF_FY]') AND type in (N'P', N'PC'))
DROP PROC sp_YF_FY
GO
CREATE PROCEDURE [dbo].[sp_YF_FY]  
(  
  @CFLX char(2) ,  
 @JSSJH decimal(21,6),  
 @FPH BIGINT ,  
 @ZJE DECIMAL(15,3) ,  
 @JZJE DECIMAL(15,3) ,  
 @YHJE DECIMAL(15,3) ,  
 @ZFJE DECIMAL(15,3) ,  
 @CFTS INT ,  
 @CFXH UNIQUEIDENTIFIER ,  
 @PATID UNIQUEIDENTIFIER ,  
 @PATIENTNO varchar(50),  
 @HZXM VARCHAR(12),  
 @YSDM INTEGER ,  
 @KSDM INTEGER ,  
 @SKRQ datetime,  
 @SKY INTEGER ,  
 @FYRQ datetime,  
 @FYR INT ,  
 @PYR INT ,  
 @PYCKH CHAR(2) ,  
 @FYCKH CHAR(2) ,  
 @DEPTID INT ,  
 @TFBZ SMALLINT,  
 @YWLX CHAR(3),  
 @tfqrbz smallint,  
 @wkdz varchar(50),  
 @FYID UNIQUEIDENTIFIER output,  
 @ERR_CODE INTEGER  output,  
     @ERR_TEXT VARCHAR(100) output,  
 @jgbm bigint,  
 @TYYY varchar(50)  
)  
AS  
 begin  
 declare @ispy smallint  --是否已配药标志  
 DECLARE @cfk_pyr int;      --处方库的配药人  
 declare @cfk_pyck char(2);  --处方库的配药窗口号  
 declare @pyms int  --是否配药模式  
 declare @qzpy int  --配药模式下强制配药标志  
 declare @sffy int --收费即发药  
  
 declare @ghxh UNIQUEIDENTIFIER  --挂号序号  
 declare @xb varchar(10)--性别  
 declare @csrq datetime --出生日期   
 declare @zdmc varchar(100) --诊断名称  
 declare @lrrq datetime --录入日期  
 declare @lry int --录入操作员  
 declare @pyrq datetime --配药日期  
  
 set @ERR_CODE=-1;  
 set @ERR_TEXT='';  
 --set @fyid=0;  
 set @ispy=0;  
   
--if @fph=0   
--begin  
--        set @ERR_TEXT='发票号为零';  
--     return;  
--end   
   
if @cfxh=dbo.FUN_GETEMPTYGUID()   
begin  
        set @ERR_TEXT='处方序号为零';  
     return;  
end  
  
   
SET @ERR_TEXT='读取强制配药标志';  
   
 --读取是否配药模式  
set @pyms=(select zt from yk_config where bh='106' AND DEPTID=@DEPTID);  
if @pyms is null   
  set @pyms=0;  
  
if @pyms=1   
begin  
  --如果是配药模式则读取否强制配药  
  set @qzpy=(select zt from yk_config where bh='107' AND DEPTID=@DEPTID);  
  if @qzpy is null   
 begin  
     set @qzpy=0;  
  end   
end  
else  
    set @qzpy=0;  
      
--读取收费自动发药标志  
set @sffy=(select config from jc_config where id='8013' );  
if @sffy is null   
begin  
   set @sffy=0;  
end   
  
    
 SET @ERR_TEXT='读取是否已配药';  
-- select @ispy=bpybz,@cfk_pyr=pyr,@cfk_pyck=PYCK,@ghxh=a.ghxxid,@xb=dbo.FUN_ZY_SEEKSEXNAME(xb),@csrq=csrq,@zdmc=zdmc,@lrrq=a.hjrq,@lry=a.hjy,@pyrq=pyrq   
--from mz_cfb a (nolock),yy_brxx b(nolock) ,mz_ghxx c(nolock)   
--         where a.brxxid=c.brxxid and b.brxxid=c.brxxid and  c.ghxxid=@patid and a.fph=@fph ;  
 select @ispy=bpybz,@cfk_pyr=pyr,@cfk_pyck=PYCK,@patid=a.brxxid,@ghxh=a.ghxxid,@xb=dbo.FUN_ZY_SEEKSEXNAME(xb),@csrq=csrq,@zdmc=zdmc,@lrrq=a.hjrq,@lry=a.hjy,@pyrq=pyrq   
from mz_cfb a (nolock),yy_brxx b(nolock) ,vi_mz_ghxx c(nolock)   
         where a.brxxid=c.brxxid and b.brxxid=c.brxxid and a.cfid=@cfxh ;  
  
if @ghxh is null  
begin  
select @ispy=bpybz,@cfk_pyr=pyr,@cfk_pyck=PYCK,@patid=a.brxxid,@ghxh=a.ghxxid,@xb=dbo.FUN_ZY_SEEKSEXNAME(xb),@csrq=csrq,@zdmc=zdmc,@lrrq=a.hjrq,@lry=a.hjy,@pyrq=pyrq   
from mz_cfb_h a (nolock),yy_brxx b(nolock) ,vi_mz_ghxx  c(nolock)   
         where a.brxxid=c.brxxid and b.brxxid=c.brxxid and a.cfid=@cfxh ;  
end  
  
if @ghxh is null   
begin  
  set @ispy=0;  
 set @cfk_pyck='';  
 set @cfk_pyr=0;  
 end  
   
  
  
 --如果强制配药而处方没有配药  
 if @qzpy=1 and @ispy=0   
begin  
  set @ERR_TEXT='系统设置要求必须先配药才能发药,请先配药';  
 return;  
end  
   
 if @qzpy=1 and rtrim(@fyckh)=''   
begin  
    set @ERR_TEXT='系统处于配药模式，但当前发药窗口没有设置，请先设置发药窗口';  
 return;  
end  
   
 --更新处方表头 如果已配药则不更新配药信息    
  
if @TFBZ=0  --如果是发药  
begin  
   if @ispy=0 and @sffy=0  
   update mz_cfb set bpybz=1,pyr=@pyr,pyrxm=dbo.fun_getempname(@pyr),pyrq=@fyrq,bfybz=1,fyrq=@FYRQ,fyr=@FYR,fyrxm=dbo.fun_getempname(@fyr),zxks=@deptid,zxksmc=dbo.fun_getdeptname(@deptid),fyck=@fyckh where cfid=@CFXH and bfybz=0 and bscbz=0;  
   else  
   update mz_cfb set bfybz=1,fyrq=@FYRQ,fyr=@FYR,fyrxm=dbo.fun_getempname(@fyr),zxks=@deptid,zxksmc=dbo.fun_getdeptname(@deptid)/*,fyck=@fyckh*/ where cfid=@CFXH and bfybz=0 and bscbz=0;  
  
    if @@rowcount=0  
    begin  
       if @ispy=0 and @sffy=0  
       update mz_cfb_h set bpybz=1,pyr=@pyr,pyrxm=dbo.fun_getempname(@pyr),pyrq=@fyrq,bfybz=1,fyrq=@FYRQ,fyr=@FYR,fyrxm=dbo.fun_getempname(@fyr),zxks=@deptid,zxksmc=dbo.fun_getdeptname(@deptid),fyck=@fyckh where cfid=@CFXH and bfybz=0 and bscbz=0;  
        else  
        update mz_cfb_h set bfybz=1,fyrq=@FYRQ,fyr=@FYR,fyrxm=dbo.fun_getempname(@fyr),zxks=@deptid,zxksmc=dbo.fun_getdeptname(@deptid),fyck=@fyckh where cfid=@CFXH and bfybz=0 and bscbz=0;  
     if @@rowcount=0  
     begin  
     SET @ERR_TEXT='没有更新到处方记录,这个处方可能已经发药';  
     return;  
     end   
    end  
end  
   
 SET @ERR_TEXT='插入发药表';  
 --插入发药表 如果已配药则引用处方头库的配药人  
 set @fyid=dbo.FUN_GETGUID(newid(),getdate())  
 if @ispy=0   
  insert into yf_FY(id,jgbm,cflx,JSSJH,FPH,zje,JZJE,YHJE,ZFJE,cfts,CFXH,PATID,PATIENTNO,HZXM,YSDM,KSDM,SKRQ,SKY,FYRQ,FYR,PYR,PYCKH,FYCKH,DEPTID,TFBZ,YWLX,tfqrbz,ghxh,xb,zdmc,csrq,lrrq,lry,pyrq,wkdz,TYYY)  
  values(@fyid,@jgbm,@cflx,@JSSJH,@FPH,@zje,@JZJE,@YHJE,@ZFJE,@cfts,@CFXH,@PATID,@PATIENTNO,@HZXM,@YSDM,@KSDM,@SKRQ,@SKY,@FYRQ,@FYR,@PYR,@PYCKH,@FYCKH,@DEPTID,@TFBZ,@YWLX,@tfqrbz,@ghxh,@xb,@zdmc,@csrq,@lrrq,@lry,@fyrq,@wkdz,@TYYY);  
 else  
 begin  
  if @cfk_pyr=0 or @cfk_pyr is null   
  begin  
     set @ERR_TEXT='处方的配药状态为已配,但配药人为空,请和管理员联系！';  
     return;  
  end   
    
  insert into yf_FY(id,jgbm,cflx,JSSJH,FPH,zje,JZJE,YHJE,ZFJE,cfts,CFXH,PATID,PATIENTNO,HZXM,YSDM,KSDM,SKRQ,SKY,FYRQ,FYR,PYR,PYCKH,FYCKH,DEPTID,TFBZ,YWLX,tfqrbz,ghxh,xb,zdmc,csrq,lrrq,lry,pyrq,wkdz,TYYY)  
  values(@fyid,@jgbm,@cflx,@JSSJH,@FPH,@zje,@JZJE,@YHJE,@ZFJE,@cfts,@CFXH,@PATID,@PATIENTNO,@HZXM,@YSDM,@KSDM,@SKRQ,@SKY,@FYRQ,@FYR,@cfk_PYR,@cfk_PYCK,@FYCKH,@DEPTID,@TFBZ,@YWLX,@tfqrbz,@ghxh,@xb,@zdmc,@csrq,@lrrq,@lry,@pyrq,@wkdz,@TYYY);  
  end  
   
-- set @FYID=@@IDENTITY;  
  
if  @FYID=dbo.FUN_GETEMPTYGUID() or @fyid is null    
begin  
     set @ERR_TEXT='插入发药头表没有成功，影响到数据库0行';  
     return;  
end  
   
--更发药处方张数 只针对已配药处方  
--if @zje>0   
--begin  
   --update SF_FYCKDMK set fpzs=fpzs-1 where ckdm=@FYCKH;  
--end  
   
       
  SET @ERR_TEXT='发药成功';  
  SET @ERR_CODE=0;  
end;  
  
  