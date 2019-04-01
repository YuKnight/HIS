
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yp_ypcjd_update_shh' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yp_ypcjd_update_shh
GO

CREATE PROCEDURE sp_yp_ypcjd_update_shh
(
	@GGID INTEGER ,
	@ERR_CODE INTEGER  output,
    	@ERR_TEXT VARCHAR(100)  output  
)
as


create table #TEMP
(
 ID INTEGER IDENTITY (1, 1) NOT NULL ,
  CJID INT,
  GGID INT,
  YPHH VARCHAR(10),
  HHJSQ VARCHAR(10),
  YPLX INT
) 


INSERT INTO #TEMP(CJID,GGID,YPHH,HHJSQ,YPLX) 
SELECT B.CJID,B.GGID,'',HHJSQ,YPLX FROM YP_YPGGD A,YP_YPCJD B WHERE A.GGID=B.GGID AND B.GGID=@GGID order by cjid
UPDATE  A SET A.YPHH=B.YPHH FROM #TEMP A,YP_YPLX B WHERE A.YPLX=B.ID

declare @t2_ggid int
declare @t2_yphh varchar(10)
declare @t2_hhjsq varchar(10)
declare @t2_cjid int


declare @cjbh varchar(10) --厂家编号 如.1
declare @cjjsq int	  --厂家计算器
declare @t1_cjid int
set @cjjsq=0

declare t2 cursor local for select ggid,YPHH,hhjsq,cjid from #TEMP 
open  t2
fetch next from t2 into @t2_ggid,@t2_yphh,@t2_hhjsq,@t2_cjid
while @@FETCH_STATUS=0
begin

	 declare @shh varchar(20)  --新货号
	 SET @shh=(rtrim(@t2_yphh)+rtrim(@t2_hhjsq))
	 if rtrim(@shh)='' 
	 begin
	    set @err_text='产生药品货号时遇到错误'
	    return 
	 end

        
	 update yp_ypcjd set shh=rtrim(@shh) where cjid=@t2_cjid

fetch next from t2 into @t2_ggid,@t2_yphh,@t2_hhjsq,@t2_cjid

end

SET @ERR_CODE=0
set @err_text='保存成功'

GO
