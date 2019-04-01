IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_hh' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_hh
GO
--重新生货号
CREATE PROCEDURE sp_hh
(
  @yplx int
)
as

declare @ggid int
declare @err_code int
declare @err_text varchar(100)
declare @n int
declare @hhjsq varchar(10)
update  yp_ypggd set hhjsq=0  where yplx=@yplx
update yp_yplx set hhjsq=0 where id=@yplx

set @n=0
declare t1 cursor local for  select ggid from  yp_ypggd where yplx=@yplx and ggid in(select ggid from yp_ypcjd) order by ggid
open  t1
fetch next from t1 into @ggid
while @@FETCH_STATUS=0
begin
	set @n=@n+1
        set @hhjsq=(select (left('0000',(4-len(rtrim(cast(@n as char(4))))))+rtrim(cast(@n  AS char(4)))))
   	update yp_ypggd set hhjsq=@hhjsq where ggid=@ggid
	exec sp_yp_ypcjd_update_shh @ggid,@err_code,@err_text

	fetch next from t1 into @ggid
end

update yp_yplx set hhjsq=@hhjsq where id=@yplx



