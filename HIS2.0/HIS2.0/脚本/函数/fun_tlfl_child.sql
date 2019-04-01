
alter  FUNCTION fun_tlfl_child(@fid bigint) 
  RETURNS  @t_level table([id] bigint,[flmc] varchar(100),[fid] bigint,[yjdbz] smallint,[level] int)
as
  BEGIN 

declare @level int
set @level=1
insert into @t_level select @fid,'',0,0,@level
while @@rowcount>0
begin
	set @level=@level+1
	insert into @t_level select a.id,a.flmc,a.fid,a.yjdbz,@level
                   from yp_ylfl a,@t_level b
                   where a.fid=b.[id]
                   and    b.[level]=@level-1
end 
delete from @t_level  where id=0
return
end

go

