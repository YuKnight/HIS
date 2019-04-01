if exists(select 1 from sysobjects where name = 'sp_yk_UNymjc' and type = 'P')
	drop procedure sp_yk_UNymjc
go	

CREATE PROCEDURE sp_yk_UNymjc  --取消月末结存  
(  
 @deptid integer,  
 @DJSJ VARCHAR(30),  
 @DJY INTEGER,  
 @ERR_CODE INTEGER output,  
    @ERR_TEXT VARCHAR(100) output  
)  
as  
  
p1:begin  
 declare @yjid UNIQUEIDENTIFIER   
 declare @bbk smallint  
  
 set @yjid=dbo.FUN_GETEMPTYGUID();  
 set @Err_Code=-1;  
 set @Err_Text='';  
   
declare @tx_deptid int--循环多个科室  
  
create table #temp(deptid int)  
insert into #temp  
select dept_id from jc_dept_property where dept_id in(select deptid from yp_yjks_gx where p_deptid=@deptid)  
if @@rowcount=0  
  insert into #temp select @deptid  
--科室级循环  
declare tx cursor local for  select deptid from #temp  
open  tx  
fetch next from tx into  @tx_deptid  
while @@FETCH_STATUS=0  
begin  
   --取得最后一次月结的ID  
  select TOP 1 @yjid=id,@bbk=bbk from yp_kjqj where deptid=@tx_deptid  order by id desc   
  if @yjid is null  
   set @yjid=dbo.FUN_GETEMPTYGUID()  
  set @bbk=coalesce(@bbk,0)  
  if @yjid=dbo.FUN_GETEMPTYGUID() or @yjid is null  
   begin  
     SET @ERR_TEXT='你的操作错误,因为系统还没进行过月结';  
     return;  
  end  
  
  if @bbk=1   
   BEGIN  
     SET @ERR_TEXT=dbo.fun_getdeptname(@tx_deptid)+'帐务数据已被转入历史记录表中,不能取消';  
     return;  
  END       
    
  --更新单据信息  
  update yk_dj set yjid=null where deptid=@tx_deptid and yjid=@yjid  ;   
  update yf_fy set yjid=null where deptid=@tx_deptid and yjid=@yjid;   
  update yf_tld set yjid=null where deptid=@tx_deptid and yjid=@yjid;   
  delete from yk_ymjc where deptid=@tx_deptid and yjid=@yjid;   
  --删除月结记录  
  delete from yp_kjqj where deptid=@tx_deptid and id=@yjid;  
    
   --删除中间表数据
   if exists(select 1 from sysobjects where name = 'YP_TJ_YMJCMX' and type = 'U')
   begin
	 delete from YP_TJ_YMJCMX where YJID = @yjid
   end 
 
  set @err_code=0;  
  set @err_text='上次月结已被取消';  
fetch next from tx into  @tx_deptid  
end   
  
end   
  