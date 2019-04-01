IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'FUN_YK_DRT' 
	   AND 	  type = 'FN')
  drop FUNCTION FUN_YK_DRT
go 

CREATE FUNCTION FUN_YK_DRT(@ywlx char(3),@num numeric(15,3) )
RETURNS numeric(15,3)
BEGIN 
declare @d char(1)
DECLARE @sl numeric(15,3)
 set @d=(select ywfx  from yk_ywlx where ywLX=@ywlx)

if rtrim(@d)='-'
  begin
   set @sl= round(@num*(-1),3)
  end
ELSE
  begin
   set @sl= round(@NUM,3)
  end 
return @sl
END
