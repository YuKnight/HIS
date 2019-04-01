IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_TLD' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_TLD
GO
CREATE PROCEDURE sp_YF_TLD
(
  @DJH       BIGINT       ,
  @DEPTID    INTEGER      ,
  @FYRQ      varchar(50),
  @FYR       INTEGER      ,
  @dept_ly    int    ,
  @NURSEID   INTEGER      ,
  @PYR       INTEGER        ,
  @BZ        VARCHAR(100),
  @SUMPFJE	DECIMAL(15,2)   ,
  @SUMLSJE	DECIMAL(15,2)   ,
  @STYPE		VARCHAR(20),
  @ywlx       char(3),
  @GROUPID UNIQUEIDENTIFIER OUTPUT,
  @ERR_CODE INTEGER OUTPUT,
  @ERR_TEXT VARCHAR(100) OUTPUT,
  @jgbm bigint,
  @wkdz varchar(50),
  @LYLX SMALLINT,
  @sumjhje decimal(15,2)
)
AS
 begin
 
 
 set @ERR_CODE=-1;
 set @ERR_TEXT='';
 
set @GROUPID=dbo.FUN_GETGUID(newid(),getdate())

 SET @ERR_TEXT='插入统领单头表';
 insert into yf_tld(groupid,jgbm,djh,deptid,fyrq,fyr,dept_ly,nurseid,pyr,bz,sumpfje,sumlsje,stype,ywlx,wkdz,LYLX,sumjhje)
 values(@GROUPID,@jgbm,@djh,@deptid,@fyrq,@fyr,@dept_ly,@nurseid,@pyr,@bz,@sumpfje,@sumlsje,@stype,@ywlx,@wkdz,@LYLX,@sumjhje);
 
 --set @GROUPID=@@IDENTITY

if @@rowcount=0 OR @GROUPID=dbo.FUN_GETEMPTYGUID() or @groupid is null 
begin
	    set @ERR_TEXT='插入发药头表没有成功，影响到数据库0行';
	    return;
end
 
  
  SET @ERR_TEXT='发药成功';
  SET @ERR_CODE=0;
end;



