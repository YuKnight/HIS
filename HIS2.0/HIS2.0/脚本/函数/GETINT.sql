IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'GETINT' 
	   AND 	  type = 'FN')
  drop FUNCTION GETINT
go 
CREATE FUNCTION GETINT(@NUM1 float ,  @NUM2 float  )
RETURNS INTEGER as
BEGIN  
DECLARE @NUM3  INTEGER;--

if CAST(@NUM1/@NUM2 AS BIGINT)=@NUM1/@NUM2 
	   set @num3=@NUM1/@NUM2
else
begin
	   if @NUM1>0 
	      set @num3=CAST(@NUM1/@NUM2 AS BIGINT)+1
	   else
	      set @num3=CAST(@NUM1/@NUM2 AS BIGINT)-1

end

  RETURN  @NUM3
END