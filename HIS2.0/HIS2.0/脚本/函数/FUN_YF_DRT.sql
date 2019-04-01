IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'FUN_YF_DRT' 
	   AND 	  type = 'FN')
  drop FUNCTION FUN_YF_DRT
go 
CREATE FUNCTION FUN_YF_DRT(@ywlx char(3),@num decimal(15,3) )
RETURNS decimal(15,3)
BEGIN 
declare @d char(1)
DECLARE @sl decimal(15,3)
 set @d=(select ywfx  from yf_ywlx where ywLX=@ywlx)

if @d='-'
   set @sl= round(@num*(-1),3)
ELSE
  begin
   set @sl= round(@NUM,3)
  end 
return @sl
END




