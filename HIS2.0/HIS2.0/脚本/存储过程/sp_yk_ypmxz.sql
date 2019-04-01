IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_YPMXZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_YPMXZ
GO

CREATE PROCEDURE SP_YK_YPMXZ
 (@year int, 
  @month INTEGER,
  @CJID INTEGER,
  @deptid integer,
  @cfmx int,
  @deptid_ck integer
 ) 
as

BEGIN
 declare @zy varchar(200)
 declare @yjid UNIQUEIDENTIFIER 
 declare @count INT 
 declare @sqyear int
 declare @sqmonth int

 DECLARE @ss varchar(5000) --定义SQL文本


 --声明临时表
   create table #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  rq datetime,
	  zy varchar(100),
	  ypdw varchar(10),
	  lsj decimal(15,4),
	  jfsl decimal(15,3),
	  jfje decimal(15,2),
	  dfsl decimal(15,3),
	  dfje decimal(15,2),
	  jcsl decimal(15,3),
	  jcje decimal(15,2),
	  ypph varchar(50), --批号
	  ypxq varchar(30), --效期
	  jhj decimal(15,3),--进货价
	  ypkl  decimal(10,4),
	  shdh varchar(50),
  	  djrq varchar(30),--单据日期
	  djid UNIQUEIDENTIFIER,
	  ydwbl int,
	  cjid int,
	  yppch varchar(100), --批次号
	  kcid uniqueidentifier 
   ) 
   
  create table #DJMX
   (
   	  DJID UNIQUEIDENTIFIER,
   	  CJID INT,
	  zy varchar(100),
	  wldw int,
	  shrq varchar(30),
	  YWLX CHAR(3),
	  YPSL DECIMAL(15,3),
	  ypdw varchar(10),
	  lsje DECIMAL(15,3),
	  lsj decimal(15,4),
	  djh bigint,
	  ypph varchar(50), --批号
	  ypxq varchar(30), --效期
	  jhj decimal(15,3),
	  ypkl  decimal(10,4),
	  shdh varchar(50),
	  djrq varchar(30),
	  ydwbl int, 
	  yppch varchar(100), --批次号
	  kcid uniqueidentifier --库存id
   ) 


declare   @DJID UNIQUEIDENTIFIER
declare   @t1_zy varchar(100)
declare   @wldw int
declare   @shrq varchar(30)
declare   @YWLX CHAR(3)
declare   @YPSL DECIMAL(15,3)
declare   @ypdw varchar(10)
declare   @lsje DECIMAL(15,3)
declare   @lsj decimal(10,4)
declare   @djh bigint
declare   @ypph varchar(50)
declare   @ypxq varchar(30)
declare   @jhj decimal(15,3)
declare   @ypkl  decimal(10,4)
declare   @shdh varchar(50)
declare   @djrq varchar(30)  
declare   @ydwbl int 
declare   @yppch varchar(100)  --批次号
declare   @kcid uniqueidentifier    
  

if @cjid=0  return

create table #tempYjid(yjid UNIQUEIDENTIFIER)
create table #deptid(deptid int)

--需要统计的科室
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID
--需要统计的会计月
if @year>0
begin
    insert into #tempYjid(yjid) 
	select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid in(select deptid from #deptid)
	if @@rowcount=0
      insert into #tempYjid(yjid)values(dbo.FUN_GETEMPTYGUID()) 
end


set @sqyear=@year
set @sqmonth=@month-1
if @month=1 
begin
  set @sqyear=@sqyear-1
  set @sqmonth=12
end
	
--上期结存
set @count=(select count(*) from YK_YMJC where cjid=@cjid and nf=@sqyear and yf=@sqmonth and deptid in(select deptid from #deptid) )
if @count=0 
   insert into #TEMP(cjid,ydwbl,rq,zy,jcsl,jcje)values(@cjid,1,'1900-01-01','上期结存',0,0)
else
   insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jcsl,jcje) select @cjid,@ydwbl,'1900-01-01','上期结存',ypdw,lsj,sum(jcsl),sum(jclsje) from YK_YMJC where cjid=@cjid and nf=@sqyear and yf=@sqmonth and deptid in(select deptid from #deptid) group by ypdw,lsj

--本月发生明细
insert into #djmx(djid,cjid,wldw,zy,lsj,shrq,ywlx,ypsl,ypdw,lsje,djh,ypph,ypxq,jhj,ypkl,shdh,djrq,ydwbl,yppch,kcid ) 
select A.ID,b.cjid,wldw,dbo.FUN_YK_YWLX(a.YWLX),lsj,
 case when a.ywlx in('001','002') then (cast(djrq as char(10))+' '+convert(nvarchar,djsj,108)) else (cast(shrq as char(10))+' '+convert(nvarchar,shrq,108) ) end,
 a.ywlx,ypsl,ypdw,lsje,a.djh,ypph,ypxq,jhj,ypkl,b.shdh,a.rq,ydwbl,b.yppch,b.kcid 
from vi_yk_dj a,vi_yk_djmx b where  
  a.id=b.djid and a.deptid in(select deptid from #deptid) and  isnull(yjid,dbo.FUN_GETEMPTYGUID()) in(select yjid from #tempYjid) and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002'))) and cjid=@cjid 

	
declare t1 cursor for  select djid,rtrim(zy),wldw,shrq,ywlx,ypsl,ypdw,lsje,lsj,djh,ypph,ypxq,jhj,ypkl,shdh,djrq,ydwbl,yppch,kcid from #DJmx order by shrq
open t1
fetch next from t1 into @djid,@t1_zy,@wldw,@shrq,@ywlx,@ypsl,@ypdw,@lsje,@lsj,@djh,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@ydwbl,@yppch,@kcid 
while @@FETCH_STATUS=0
begin
	   set @zy=''
	   --借方
	   --采购入库、
	   if @ywlx in('001') 
		begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid )values(@cjid,@ydwbl,@shrq,@zy,@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )
		end

	   --退库
	   if @ywlx in('002') 
		begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid )values(@cjid,@ydwbl,@shrq,@zy,@ypdw,@lsj,@ypsl*(-1),@lsje*(-1),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )
		end

	   
	   --期初录入
	   if @ywlx in('009') 
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,'期初录入 '+'[单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)

	   --调盈
	   if @ywlx in('005') and @lsje>0  
	      insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,'调盈' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)

	   --报溢
	   if @ywlx in('007') and @lsje>0  
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@t1_zy +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)

	   if @ywlx in('008') and @lsje>0  --盘盈
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,'盘盈' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@ypsl ,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )

	   
	   if @ywlx in('012') and @lsje>0  --调整
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,'账务调整' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )

	   
	   if @ywlx in('016')  --其他入库
		begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+')' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@zy,@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)
                end
	   
	   --贷方
	   --出库单
	   if @ywlx in('003','014','022') 
		begin
        	      set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@zy,@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )
		end

	   --药房退库单
	   if @ywlx in('004') 
		begin
     	          set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@zy,@ypdw,@lsj,(@ypsl)*(-1),(@lsje)*(-1),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid ,@yppch,@kcid)
		end

	      
	   if @ywlx in('005') and @lsje<0  --调亏
	      insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,'调亏' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,abs(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )
	  
	
	   if @ywlx in('006')  --报损
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@t1_zy +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@ypsl ,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)

	      
	   if @ywlx in('007') and @lsje<0  --报溢
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@t1_zy +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,abs(@ypsl) ,abs(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)

	   if @ywlx in('008') and @lsje<0  --盘亏
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,'盘亏' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,abs(@ypsl) ,abs(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)

	   
	   if @ywlx in('012') and @lsje<0  --调整
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,'账务调整' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,abs(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )

	   
	   if @ywlx in('017')  --处方出库
           begin
	      if @cfmx=0 
	   	   insert into #TEMP(cjid,ydwbl,rq,zy,lsj,ypdw,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@t1_zy +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)

 	   end
	   
	   if @ywlx in('018')  --记账处方补录
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@t1_zy +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)

	   
	   if @ywlx in('020')  --处方补录
           begin
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@t1_zy +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)
	   end

	   if @ywlx in('030')  --同级调出
           begin
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)
	   end
	   if @ywlx in('031')  --同级调入
           begin
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid)values(@cjid,@ydwbl,@shrq,@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid)
	   end
	   
	       if @YWLX in ('032') --制剂加工原料消耗出库
	   begin
			set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')'+' [单据:'+RTRIM(CAST(@djh as CHAR(20)))+']'
			insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid) values
			(@CJID,@ydwbl,@shrq,@zy,@ypdw,@lsj,@YPSL,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@DJID,@yppch,@kcid)
	   end
	   
	   if @YWLX in ('033') --制剂加工成品入库
	   begin
			set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')'+' [单据:'+RTRIM(CAST(@djh as CHAR(20)))+']'
			insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid) values
			(@CJID,@ydwbl,@shrq,@zy,@ypdw,@lsj,@YPSL,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@DJID,@yppch,@kcid)
	   end
	   
	    if @YWLX in ('034') --批次调整
	    begin
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid )values(@cjid,@ydwbl,@shrq,@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [单据:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )
	   end

fetch next from t1 into @djid,@t1_zy,@wldw,@shrq,@ywlx,@ypsl,@ypdw,@lsje,@lsj,@djh,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@ydwbl,@yppch,@kcid
	   
end
CLOSE t1
DEALLOCATE t1


	
  --本期结存
    set @count=0
  	set @count=(select count(*) from #tempyjid 
        where isnull(yjid,dbo.FUN_GETEMPTYGUID())<>dbo.FUN_GETEMPTYGUID())
    if @count is null 
	   set @count=0

	if @count=0
	   insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jcsl,jcje) 
	   select @cjid,1,getdate(),'本期结存',s_ypdw,cast(round(lsj,4) as decimal(15,4)),sum(kcl/dwbl),cast(round(sum(lsj*kcl/dwbl),2) as decimal(15,2)) from yk_kcmx a,vi_yp_ypcd b 
	   where a.cjid=b.cjid and a.cjid=@cjid  
	   and deptid in(select deptid from #deptid) group by b.cjid,b.s_ypdw,lsj
    else 
   	   insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jcsl,jcje) 
	   select @cjid,1,getdate(),'本期结存',ypdw,lsj,sum(jcsl) ,sum(jclsje)
	   from YK_YMJC where cjid=@cjid and nf=@year and yf=@month 
		and deptid in(select deptid from #deptid) group by cjid,ypdw,lsj


declare @t2_jcsl decimal(15,2)
declare @t2_jcje decimal(15,2)
declare @t2_jfsl decimal(15,2)
declare @t2_jfje decimal(15,2)
declare @t2_dfsl decimal(15,2)
declare @t2_dfje decimal(15,2)
declare @t2_ydwbl int
declare @t2_id int
declare @t2_xzxdw int
declare @t2_xdwbl int

declare @ymjcsl decimal(15,2)
declare @ymjcje decimal(15,2)
declare @ymjcdwbl int
set @ymjcsl=0
set @ymjcje=0
set @ymjcdwbl=1


declare @sumsl decimal(15,2)
declare @sumje decimal(15,2)

declare t2 cursor local for  select cast(coalesce(jcsl,0) as decimal(15,2)),cast(coalesce(jcje,0) as decimal(15,2)),
cast(coalesce(jfsl,0) as decimal(15,2)),cast(coalesce(jfje,0) as decimal(15,2)),cast(coalesce(dfsl,0) as decimal(15,2)),
cast(coalesce(dfje,0) as decimal(15,2)),(case when ydwbl=0 then 1 else ydwbl end) ydwbl,a.id,1 from #temp a  order by a.rq
open t2
fetch next from t2 into @t2_jcsl,@t2_jcje,@t2_jfsl,@t2_jfje,@t2_dfsl,@t2_dfje,@t2_ydwbl,@t2_id,@t2_xdwbl
while @@FETCH_STATUS=0
begin
   
   if @t2_id>1 
	begin
		set @sumsl=(@ymjcsl*@t2_ydwbl)/coalesce(@ymjcdwbl,1)
		set @sumsl=((round(@sumsl,2))+ (round(@t2_jfsl,2)) + (round(@t2_dfsl*(-1),2)))
		set @sumje=(@ymjcje+@t2_jfje+@t2_dfje*(-1))
	        
		update #temp set jcsl=@sumsl,jcje=@sumje where id=@t2_id
		set @ymjcsl=coalesce((select jcsl from #temp where id=@t2_id),0)
		set @ymjcdwbl=coalesce((select ydwbl from #temp where id=@t2_id),1)
		set @ymjcje=coalesce((select jcje from #temp where id=@t2_id),0)
		
	end
    if @t2_id=1
	begin
		set @ymjcsl=@t2_jcsl
		set @ymjcje=@t2_jcje
                set @ymjcdwbl=@t2_ydwbl
		--update #temp set zy=cast(@t2_id as varchar(10))+'w '+cast(@ymjcsl as varchar(15))+'a'+cast(@t2_jfsl as varchar(15))+'b'+cast(@t2_dfsl as varchar(15)) where id=@t2_id
	end

      fetch next from t2 into @t2_jcsl,@t2_jcje,@t2_jfsl,@t2_jfje,@t2_dfsl,@t2_dfje,@t2_ydwbl,@t2_id,@t2_xdwbl

end 


--借贷合计
insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,dfsl,dfje) 
select @cjid,1,getdate(),'小计',s_ypdw,null,
sum(jfsl/ydwbl),cast(round(sum(jfje),2) as decimal(15,2)),
sum(dfsl/ydwbl),cast(round(sum(dfje),2) as decimal(15,2)) from #TEMP a,yp_ypcjd b
where a.cjid=b.cjid  group by s_ypdw


	
select id 序号,rq 日期,zy 摘要,ypdw 单位,lsj 零售价,cast(jfsl as float) 借方数量,jfje 借方金额,cast(dfsl as float) 贷方数量,dfje 贷方金额,cast(jcsl as float) 结存数量,cast(jcje as float) 结存金额,
yppch 批次号,kcid,
ypph 批号,ypxq 效期,jhj 进价,ypkl 扣率,shdh 送货单号,djrq 单据日期,djid,cjid from #TEMP order by rq

select id 序号,rq 日期,zy 摘要,ypdw 单位,cast(lsj as decimal(15,2)) 零售价,cast(jfsl as float) 借方数量,
jfje 借方金额,cast(dfsl as float) 贷方数量,dfje 贷方金额,cast(jcsl as float) 结存数量,cast(jcje as float) 结存金额,
yppch 批次号,kcid,
ypph 批号,ypxq 效期,
(case when jhj=0 then null else jhj end) 进价,(case when ypkl=0 then null else ypkl end) 扣率,
shdh 送货单号,dbo.Fun_GetDate( djrq) 单据日期,djid,cjid from #TEMP where dfje is null or zy='小计' order by id

select id 序号,rq 日期,zy 摘要,ypdw 单位,cast(lsj as decimal(15,2)) 零售价,cast(jfsl as float) 借方数量,
jfje 借方金额,cast(dfsl as float) 贷方数量,dfje 贷方金额,cast(jcsl as float) 结存数量,cast(jcje as float) 结存金额,
yppch 批次号,kcid,
ypph 批号,ypxq 效期,
(case when jhj=0 then null else jhj end) 进价,(case when ypkl=0 then null else ypkl end) 扣率,
shdh 送货单号,dbo.Fun_GetDate( djrq) 单据日期,djid,cjid from #TEMP where jfje is null or zy='小计' order by id


end
 
 
