
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_MoveData' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_MoveData
GO
CREATE PROCEDURE sp_yf_MoveData
as
declare @errcode int
declare @errtext varchar(100)
declare @djrq varchar(20)
declare @djsj varchar(20)
declare @endrq varchar(20)
declare @yjid UNIQUEIDENTIFIER

set @djrq=dbo.fun_getdate(getdate())
set @djsj=convert(nvarchar,getdate(),108)

declare @day int    
set @day=convert(int,isnull((select config from jc_config where id=13),'120'))   
set @day=@day+60    
set @endrq=convert(datetime,dateadd(dd,-@day,getdate()))     
    
    
declare t1 cursor local for  select top 3 a.id from yp_kjqj A,yp_yjks b 
where a.deptid=b.deptid and b.kslx='药房'  and  bbk=0 and djsj<@endrq order by a.id 
open t1--修改于2012-11-7 在此之前没有打开游标， 运行过程报错。
fetch next from t1 into @yjid
while @@FETCH_STATUS=0
begin

print '--开始月结ID为'+cast(@yjid as varchar(50))+' 的事务'
   begin tran

print ' --发药头表'
   insert into yf_fy_h select * from yf_fy (nolock) where yjid=@yjid 
   if @@error<>0
   begin
      rollback tran
      return
   end 


print ' --发药明细表'
   insert into yf_fymx_h select b.* from yf_fy a (nolock) ,yf_fymx b (nolock)  where a.id=b.fyid and a.yjid=@yjid 
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --发药明细批号'
   insert into yf_fymx_ph_h  select c.* from yf_fy a (nolock) ,yf_fymx b (nolock)  ,yf_fymx_ph c (nolock)  where a.id=b.fyid and b.id=c.fymxid  and a.yjid=@yjid 
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --统领单'
   insert into yf_tld_h select * from yf_tld (nolock)  where yjid=@yjid
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --统领明细'
   insert into yf_tldmx_h select b.* from yf_tld a (nolock) ,yf_tldmx b (nolock)  where a.groupid=b.groupid and yjid=@yjid
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --单据头表'
   insert into yf_dj_h select * from yf_dj (nolock)  where yjid=@yjid 
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --单据明细表'
   insert into yf_djmx_h select b.* from yf_dj a (nolock) ,yf_djmx b (nolock)  where a.id=b.djid and a.yjid=@yjid 
   if @@error<>0
   begin
      rollback tran
      return
   end 


print ' --删除发药明细批号明细表'
   delete from yf_fymx_ph  where fymxid in(select b.id from yf_fy a (nolock) ,yf_fymx b (nolock)  where a.id=b.fyid and a.yjid=@yjid)
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --删除发药明细'
   delete from yf_fymx  where fyid in(select id from yf_fy (nolock)  where yjid=@yjid)
   if @@error<>0
   begin
      rollback tran
      return
   end 
print ' --删除发药头表'
   delete from yf_fy where yjid=@yjid 
   if @@error<>0
   begin
      rollback tran
      return
   end 



print ' --删除统领单明细'
   delete from yf_tldmx where groupid in(select groupid from yf_tld (nolock)  where yjid=@yjid)
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --删除统领单'
   delete from yf_tld where yjid=@yjid 
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --删除单据明细'
   delete from yf_djmx where djid in(select id from yf_dj (nolock)  where yjid=@yjid)
   if @@error<>0
   begin
      rollback tran
      return
   end 

print ' --删除单据头'
   delete from yf_dj where yjid=@yjid
   if @@error<>0
   begin
      rollback tran
      return
   end 
    
print ' --更新月结标记'
   update yp_kjqj set bbk=1 where id=@yjid
   if @@error<>0
   begin
      rollback tran
      return
   end 

   commit tran

print '--结束月结ID为'+cast(@yjid as varchar(50))+' 的事务'
   fetch next from t1 into @yjid
end 


--exec sp_yf_MoveDate

