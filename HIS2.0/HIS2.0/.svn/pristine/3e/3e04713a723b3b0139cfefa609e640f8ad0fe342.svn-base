IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_scfymx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_scfymx
GO
CREATE PROCEDURE sp_yf_scfymx
as
declare @errcode int
declare @errtext varchar(100)
declare @djrq varchar(20)
declare @djsj varchar(20)
declare @endrq varchar(20)
declare @deptid int
declare @szjgbm bigint

set @djrq=dbo.fun_getdate(getdate())
set @djsj=convert(nvarchar,getdate(),108)
set @endrq=dbo.fun_getdate(getdate())



declare t1 cursor local for  select deptid,szjgbm from yp_yjks where qybz=1 and kslx='Ò©·¿'
open  t1
fetch next from t1 into @deptid,@szjgbm
while @@FETCH_STATUS=0
begin
   begin tran
   exec SP_YF_fymx_dj @djrq,@djsj,0,@deptid,@endrq,@errcode,@errtext,@szjgbm
   if @@error<>0
   begin
      rollback tran
      return
   end   
   commit tran
   fetch next from t1 into @deptid,@szjgbm
end 




