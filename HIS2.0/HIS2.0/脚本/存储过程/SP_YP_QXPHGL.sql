IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_QXPHGL' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_QXPHGL
GO
CREATE PROCEDURE SP_YP_QXPHGL
 (
   @deptid integer
 ) 
as
BEGIN



DECLARE @KSLX VARCHAR(10)
SELECT @KSLX=RTRIM(KSLX) FROM YP_YJKS where deptid=@deptid

IF rtrim(@KSLX)='药库' 
begin
     delete  from yk_kcph where deptid=@deptid
     insert into yk_kcph(id,jgbm,ggid,cjid,kwid,ypph,ypxq,jhj,kcl,zxdw,dwbl,djsj,bdelete,deptid)
     select dbo.fun_getguid(newid(),getdate()),jgbm,ggid,cjid,0,'无批号','1900-01-01',0,kcl,zxdw,dwbl,djsj,bdelete,deptid from yk_kcmx where deptid=@deptid
     update yk_config set zt=0 where deptid=@deptid and bh=102
end 
IF rtrim(@KSLX)='药房' 
begin
     delete  from yf_kcph where deptid=@deptid
     insert into yf_kcph(id,jgbm,ggid,cjid,kwid,ypph,ypxq,jhj,kcl,zxdw,dwbl,djsj,bdelete,deptid)
     select dbo.fun_getguid(newid(),getdate()),jgbm,ggid,cjid,0,'无批号','1900-01-01',0,kcl,zxdw,dwbl,djsj,bdelete,deptid from yf_kcmx where deptid=@deptid
     update yk_config set zt=0 where deptid=@deptid and bh=102
end 
end 



