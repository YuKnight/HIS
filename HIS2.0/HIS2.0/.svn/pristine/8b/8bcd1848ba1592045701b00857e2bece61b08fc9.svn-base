IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_YPMXZ_RQ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_YPMXZ_RQ
GO

CREATE PROCEDURE SP_YF_YPMXZ_RQ
 (@rq1 datetime, 
  @rq2 datetime, 
  @cjid int,
  @deptid int,
  @cfmx smallint
 ) 
as
BEGIN
 declare @zy varchar(200);
 declare @count INT 
 declare @sqyear int;
 declare @sqmonth int;

 DECLARE @stmt varchar(2000); --定义SQL文本

SET @RQ1=@RQ1+' 00:00:00'
SET @RQ2=@RQ2+' 23:59:59'
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
	  ypph varchar(50),
	  ypxq varchar(30),
	  jhj decimal(15,3),
	  ypkl  decimal(10,4),
	  shdh varchar(50),
  	  djrq varchar(30),--单据日期
	  djid bigint,
	  ydwbl int,
	  cjid int,
	  ywlx varchar(10),
	  ywmc varchar(100),
	  pxxh int ,
	  yppch varchar(100),
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
	  lsj decimal(10,4),
	  djh bigint,
	  ypph varchar(50),
	  ypxq varchar(30),
	  jhj decimal(15,3),
	  ypkl  decimal(10,4),
	  shdh varchar(50),
	  djrq varchar(30),
	  ydwbl int,
	  BZ VARCHAR(100),
	  yppch varchar(100),
	  kcid uniqueidentifier 
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
declare   @BZ VARCHAR(100)
declare   @yppch varchar(100) --批次号
declare   @kcid uniqueidentifier 
     
if @cjid=0 return;


declare @yjid UNIQUEIDENTIFIER --上月月结ID
declare @yjdjsj datetime --上月月结登记时间

select @count=count(*) from yp_kjqj where deptid=@deptid and jsrq<=@rq1 
if coalesce(@count,0)<2 
begin
  set @yjid=null
  set @yjdjsj='2001-01-01 00:00:00'
end
else
begin
	select top 1 @yjid=id,@yjdjsj=jsrq from  (
	select top 2 * from yp_kjqj where deptid=@deptid and jsrq<=@rq1  order by id desc
	) a order by id
	IF @YJID IS NULL 
		set @yjid=null
end

--set @yjid=null
--exec SP_Yf_YPMXZ_RQ '2006-12-31','2007-01-10',36,1185,0
--计算结存数量和金额
create TABLE #ymjc (ID int IDENTITY (1, 1) NOT NULL ,CJID INT,ydwbl int,sysl DECIMAL(15,3),syje decimal(15,3),bqsl decimal(15,3),bqje decimal(15,3)) 

if @yjid is null
BEGIN
	INSERT INTO #ymjc(CJID,bqsl,bqje)
	SELECT c.cjid,
	sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
	sum(dbo.fun_YF_drt(a.ywlx,lsje))
	FROM VI_YF_DJ A (nolock),VI_YF_DJMX B (nolock),YF_kcmx c (nolock)
	WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
	( (shbz=1 and a.ywlx not in('001','002') and shrq>=@yjdjsj and shrq<@rq1 ) or 
	( a.ywlx in('002','001') and a.djrq>=@yjdjsj and djrq<@rq1 )
	) and b.cjid=@cjid
	group by c.cjid

	insert into #ymjc(cjid,ydwbl,sysl,syje)
	select b.cjid,ydwbl,round(sum(jcsl*b.dwbl/ydwbl),3),sum(jclsje) from yf_ymjc a (nolock),yf_kcmx b (nolock) 
	where a.cjid=b.cjid and  b.deptid=@deptid and yjid=@yjid and a.cjid=@cjid group by b.CJID,a.YDWBL,b.DWBL
	--select b.cjid,ydwbl,round(jcsl*b.dwbl/ydwbl,3),jclsje from yf_ymjc a,yf_kcmx b  where a.cjid=b.cjid and  b.deptid=@deptid and yjid=@yjid  and a.cjid=@cjid
	--return
END
else
	INSERT INTO #ymjc(CJID,bqsl,bqje)
	SELECT c.cjid,
	sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
	sum(dbo.fun_YF_drt(a.ywlx,lsje))
	FROM VI_YF_DJ A (nolock),VI_YF_DJMX B (nolock),YF_kcmx c (nolock)
	WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
	( (shbz=1 and a.ywlx not in('001','002') and shrq<@rq1 ) or 
	(a.ywlx in('002','001') and a.djrq<@rq1  )
	) and b.cjid=@cjid
	group by c.cjid



declare @bqjcsl decimal(15,3)
declare @bqjcje decimal(15,3)
select @bqjcsl=(coalesce(sum((sysl/dwbl*ydwbl)),0)+coalesce(sum(bqsl),0)),@bqjcje=(coalesce(sum(syje),0)+coalesce(sum(bqje),0)) from #ymjc a,yf_kcmx b where a.cjid=b.cjid and deptid=@deptid


--上期结存
--上期结存
insert into #TEMP(ywlx,ywmc,cjid,rq,zy,ypdw,ydwbl,lsj,jcsl,jcje) select '000','上日结存',cjid,'1900-01-1','上日结存',dbo.fun_yp_ypdw(zxdw),dwbl,0,@bqjcsl,@bqjcje from  yF_kcmx (nolock) where deptid=@deptid and cjid=@cjid

insert into #djmx(DJID,cjid,wldw,zy,lsj,shrq,ywlx,ypsl,ypdw,lsje,djh,ypph,ypxq,jhj,ypkl,shdh,djrq,ydwbl,bz,yppch,kcid ) 
	   select A.ID,b.cjid,wldw,dbo.FUN_Yf_YWLX(a.YWLX),lsj,
	   	  case when a.ywlx in('001','002') then (cast(djrq as char(10))+' '+convert(nvarchar,djsj,108)) else (cast(shrq as char(10))+' '+convert(nvarchar,shrq,108)) end,
		  a.ywlx,ypsl,ypdw,lsje,a.djh,ypph,ypxq,jhj,ypkl,b.shdh,a.rq,ydwbl,a.bz,yppch,b.kcid 
	   from VI_Yf_DJ a (nolock),VI_Yf_DJMX b (nolock) where a.djh=b.djh 
	      and a.id=b.djid  and a.deptid=@deptid and 
	( (shbz=1 and a.ywlx not in('001','002') and shrq>=@rq1 and shrq<=@rq2 ) or 
	(a.ywlx in('002','001') and djrq>=@rq1 and djrq<=@rq2  )
	)  and b.cjid=@cjid

declare t1 cursor local for  select djid,rtrim(zy),wldw,shrq,ywlx,ypsl,ypdw,lsje,lsj,djh,ypph,ypxq,jhj,ypkl,shdh,djrq,ydwbl,bz,yppch,kcid from #DJmx order by shrq
open t1
fetch next from t1 into @djid,@t1_zy,@wldw,@shrq,@ywlx,@ypsl,@ypdw,@lsje,@lsj,@djh,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@ydwbl,@bz,@yppch,@kcid
while @@FETCH_STATUS=0
begin	
	   set @zy='';
	   --借方
	   --采购入库、
	   if @ywlx in('001') 
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') '+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );
	   end 
	   --退货
	   if @ywlx in('002') 
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
	   	  values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl*(-1),@lsje*(-1),@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );
	   end 
	   
	   --药房退库单
	   if @ywlx in('004') 
	   begin
	      set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,(@ypsl)*(-1),(@lsje)*(-1) ,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );
	   end
	   
	   --期初录入
	   if @ywlx in('009') 
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
	   	  values(@ywlx,@t1_zy,@shrq,'期初录入'+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);

	   --调盈
	   if @ywlx in('005') and @lsje>0  
	      insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	      values(@ywlx,@t1_zy,@shrq,'调盈'+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );

	   --报溢
	   if @ywlx in('007') and @lsje>0  
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,@t1_zy+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);

	   if @ywlx in('008') and @lsje>0  --盘盈
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
	   	  values(@ywlx,@t1_zy,@shrq,'盘盈'+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid ,@yppch,@kcid,@ypph,@ypxq,@jhj );

	   
	   if @ywlx in('012') and @lsje>0  --调整
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,'账务调整'+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );

	   
	   if @ywlx in('015')  --药品调入单
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
	   	  values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);
	   end

	   if @ywlx in('016')  --药品入库单
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
	   	  values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );
	   end

	   
   	   if @ywlx in('019','024')  --其他入库 小药柜入库
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );
	   end 
	   
	   --贷方
	   --药品调出单
	   if @ywlx in('003') 
	   begin
	      set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);
	   end 

	      
	   if @ywlx in('005') and @lsje<0  --调亏
	      insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	      values(@ywlx,@t1_zy,@shrq,'调亏'+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,abs(@lsje),@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );

	
	   if @ywlx in('006')  --报损
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
	   	  values(@ywlx,@t1_zy,@shrq,@t1_zy +'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,(@ypsl) ,(@lsje),@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );

	      
	   if @ywlx in('007') and @lsje<0  --报溢
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,@t1_zy+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,abs(@ypsl) ,abs(@lsje),@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);

	   if @ywlx in('008') and @lsje<0  --盘亏
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,'盘亏'+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,abs(@ypsl) ,abs(@lsje),@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );

	   
	   if @ywlx in('012') and @lsje<0  --调整
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,'账务调整'+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,abs(@lsje),@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);
  
	   
	  if @ywlx in('014','022','023')  --其它领药
	  begin
	      set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	  values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje ,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );
	 end
	   
	   if @ywlx in('017')  --处方出库
	  begin
	      if @cfmx=0 
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
	   	   values(@ywlx,@t1_zy,@shrq,@t1_zy+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);

	   end
	   if @ywlx in('018')  --处方补录出库
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	   values(@ywlx,@t1_zy,@shrq,@t1_zy+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);

	   
	   if @ywlx in('020')  --住院处方出库
	   begin
	      if rtrim(@BZ)<>'病人处方统领发药' and  @cfmx=0 
	   	    insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
	   	    values(@ywlx,@t1_zy,@shrq,@t1_zy+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);
	   end 
	   if @ywlx in('021')  --住院处方补录出库
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	   values(@ywlx,@t1_zy,@shrq,@t1_zy+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);

	   
	   if @ywlx in('025')  --保健处方记帐
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	   values(@ywlx,@t1_zy,@shrq,@t1_zy+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq,@jhj );

	   if @ywlx in('026')  --财务科记帐
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
	   	   values(@ywlx,@t1_zy,@shrq,@t1_zy+'[单据:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@ypph,@ypxq ,@jhj);

	   
	   
fetch next from t1 into @djid,@t1_zy,@wldw,@shrq,@ywlx,@ypsl,@ypdw,@lsje,@lsj,@djh,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@ydwbl,@bz,@yppch,@kcid 
	   
end
CLOSE t1
DEALLOCATE t1
 
  --门诊处方明细
  	if @cfmx=1 --and @yjid=0 
		insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
		select '017','处方出库',b.fyrq,'处方出库'+'('+rtrim(b.hzxm)+' 发票:'+rtrim(cast(b.fph as varchar(50)))+')',c.lsj,c.ypdw,c.ypsl*c.cfts,c.lsje,c.Ydwbl,c.cjid ,
		c.yppch,c.kcid,c.ypph,c.ypxq ,jhj
		from  vi_YF_FY B (nolock),vi_yf_fymx c (nolock)
		WHERE  b.id=c.fyid AND b.ywlx ='017'  and scbz=1 and   b.deptid=@deptid and c.cjid=@cjid    
    	AND DJID IN(SELECT DJID FROM #DJMX WHERE YWLX='017')     
     	
  --住院处方明细
  	if @cfmx=1 --and @yjid=0 
		insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq ,jhj)
		select '020','处方出库',b.fyrq,'处方出库'+'('+rtrim(b.hzxm)+' 住院号:'+rtrim(cast(b.patientno as varchar(50)))+')',c.lsj,c.ypdw,c.ypsl*c.cfts,c.lsje,c.Ydwbl,c.cjid,c.yppch,c.kcid,c.ypph,c.ypxq ,JHJ
		from  vi_YF_FY B (nolock),vi_yf_fymx c (nolock)
		WHERE  b.id=c.fyid AND b.ywlx ='020'  and scbz=1 and   b.deptid=@deptid and c.cjid=@cjid    
    	AND DJID IN(SELECT DJID FROM #DJMX WHERE YWLX='020')  

  --住院统领单
   		insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
		select '020','住院统领单',b.fyrq,dbo.fun_getdeptname(dept_ly)+'统领出库('+'单号:' +rtrim(cast(b.djh as varchar(50)))+')',c.lsj,c.ypdw,c.ypsl,c.lsje,c.YDWBL,c.cjid ,c.yppch,c.kcid,c.ypph,c.ypxq ,JHJ
		from vi_YF_tld B (nolock),
		vi_yf_tldmx c (nolock)
		WHERE  b.groupid=c.groupid and b.ywlx ='020'  AND SCBZ=1 and b.deptid=@deptid and c.cjid=@cjid 
		AND DJID IN(SELECT DJID FROM #DJMX WHERE YWLX='020')       

	
  --本期结存
 --本期结存



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
set @ymjcdwbl=0

declare @pxxh int
set @pxxh=0
declare t2 cursor local for  select coalesce(jcsl,0),coalesce(jcje,0),coalesce(jfsl,0),coalesce(jfje,0),coalesce(dfsl,0),coalesce(dfje,0),ydwbl,a.id,zxdw,dwbl from #temp a,yf_kcmx b (nolock) where a.cjid=b.cjid and deptid=@deptid order by RQ
open t2
fetch next from t2 into @t2_jcsl,@t2_jcje,@t2_jfsl,@t2_jfje,@t2_dfsl,@t2_dfje,@t2_ydwbl,@t2_id,@t2_xzxdw,@t2_xdwbl
while @@FETCH_STATUS=0
begin
   set @pxxh=@pxxh+1
   if @t2_id>1 
	begin

		set @ymjcsl=@ymjcsl*@t2_ydwbl/@ymjcdwbl
		set @ymjcsl=round(@ymjcsl,2)+ round(@t2_jfsl,2) + round(@t2_dfsl*(-1),2)
	
		set @ymjcje=@ymjcje+@t2_jfje+@t2_dfje*(-1)
		update #temp set jcsl=@ymjcsl,jcje=@ymjcje,pxxh=@pxxh where id=@t2_id
		set @ymjcdwbl=@t2_ydwbl
	end
    else
	begin
		set @ymjcsl=@t2_jcsl
		set @ymjcje=@t2_jcje
                set @ymjcdwbl=@t2_ydwbl
	end
    
fetch next from t2 into @t2_jcsl,@t2_jcje,@t2_jfsl,@t2_jfje,@t2_dfsl,@t2_dfje,@t2_ydwbl,@t2_id,@t2_xzxdw,@t2_xdwbl
end 


insert into #TEMP(ywlx,ywmc,cjid,rq,zy,ypdw,ydwbl,lsj,jcsl,jcje)
values( '999','本日结存',@cjid,getdate(),'本日结存',dbo.fun_yp_ypdw(@t2_xzxdw),@t2_xdwbl,0,round(@ymjcsl*@t2_xdwbl/@t2_ydwbl,2) ,@ymjcje)

	
select id 序号,rq 日期,zy 摘要,ypdw 单位,lsj 零售价,jfsl 借方数量,jfje 借方金额,dfsl 贷方数量,dfje 贷方金额,cast(jcsl as float) 结存数量,cast(jcje as float) 结存金额,
 kcid , 
ypph 批号,ypxq 效期,jhj 进价 , yppch 批次号,ypkl 扣率,shdh 送货单号,djrq 单据日期 from #TEMP order by rq     
select '0' 序号 ,zy 业务名称,cast(round(sum(ypsl*dwbl/ydwbl),1) as float) 数量,dbo.fun_yp_ypdw(zxdw) 单位, 
cast(sum(lsje) as float) 金额  
from 
(--select ywlx,zy,cjid,ypsl,lsje,ydwbl from #djmx  union all
select ywlx,ywmc as zy,cjid,jfsl ypsl,jfje lsje,ydwbl,yppch from #temp union all
 select ywlx,ywmc,cjid,dfsl ypsl,dfje lsje,ydwbl,yppch from #temp --where ywlx not in('017','020')
union all  select ywlx,ywmc,cjid,jcsl ypsl,jcje lsje,ydwbl,yppch from #temp where ywlx in('000','999')) a,
yf_kcmx b (nolock) where a.cjid=b.cjid and deptid=@deptid group by ywlx,zy,zxdw order by ywlx

end


--exec SP_Yf_YPMXZ_rq @rq1=N'2014-05-07',@rq2=N'2014-05-07',@cjid=4,@deptid=215,@cfmx=0