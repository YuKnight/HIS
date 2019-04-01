
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_Fun_DW_NUM_MZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_Fun_DW_NUM_MZ
GO
CREATE PROCEDURE sp_Fun_DW_NUM_MZ
(
 @dwtype INT ,--单位类型
 @num decimal(18,4),--用量
 @zxcs int,--执行次数  
 @jgts int,--间隔天数
 @ts int,--天数
 @CJID INT,--厂家ID
 @DEPTID INT,--药房代码
 @DWBL INT--原单位比例    
)  
as
 begin
  declare @ggid int;
  declare @yl decimal(10,1);
  declare @unit int;
  declare @price decimal(10,4);
  declare @sdvalue decimal(10,2);
  declare @ydwbl int;
  declare @zxksid int;
  
  --@ggid,X_DWBL,zxdw
  declare @ypdw int;
  declare @xdwbl int;
  declare @zxdw int;
  declare @lsj decimal(10,2);
  declare @hlxs decimal(10,4);
  declare @bzsl int;
  declare @lyfs int ;--领药方式
  declare @pfj decimal(10,2)
  
  declare @kcl decimal(15,2)
  declare @bdelete smallint


begin

select @ggid=a.ggid,@hlxs=hlxs,@bzsl=bzsl,@ypdw=ypdw,@lsj=lsj,@lyfs=lyfs,@pfj=pfj  from yp_ypggd a,yp_ypcjd b where a.ggid=b.ggid and cjid=@cjid;
select @xdwbl=dwbl,@zxdw=zxdw,@kcl=kcl,@bdelete=bdelete  from yf_kcmx where deptid=@deptid and cjid=@cjid; 

if @deptid=35
begin
if exists(select * from yp_ypcl where deptid=34 and cjid=@cjid)
begin
	select @zxdw=zxdw,@kcl=@kcl*dwbl/@xdwbl from yp_ypcl where deptid=34 and cjid=@cjid;
    select @xdwbl=dwbl from yp_ypcl where deptid=34 and cjid=@cjid;
end
ELSE 
begin
   select @zxdw=@ypdw,@kcl=@kcl/@xdwbl 
   set @xdwbl=1
end
end

 
if coalesce(@xdwbl,0)=0 
begin
    set @xdwbl=1;
    set @zxdw=@ypdw;
 end

   --如果开的是含量单位 如果开的是含量单位  如果开的是含量单位  如果开的是含量单位
if @dwtype=1 
begin
	 --如果按包装单位累计取整
	 if @lyfs=1 
	 begin 
	 	--先计算成包装单位
	 	set @yl=dbo.getint(@num,@hlxs);
		--合计有多少个包装单位然后换算成药房单位
		set @yl=dbo.getint(dbo.getint(@yl*@zxcs*@TS/@JGTS,1)*@xdwbl,@bzsl);
	 end
	 --如果是按剂量累计取整
	 if @lyfs=2 
	 	--合计所有用量然后看有多少个包装单位再换算成药房单位
	 	set @yl=dbo.getint((dbo.getint(@num*@zxcs*@ts/@jgts,@hlxs))*@xdwbl,@bzsl);
	 
end
  
   --如果开的是包装单位 如果开的是包装单位 如果开的是包装单位 如果开的是包装单位
if @dwtype=2 
begin
  	 if @lyfs=1 
	    set @yl=dbo.getint(dbo.getint((dbo.getint(@num,1)*@zxcs*@ts/@jgts)*@xdwbl,@bzsl),1);

	 
  	 if @lyfs=2 
		set @yl=dbo.getint(dbo.getint(@num*@hlxs*@zxcs*@ts/@jgts,@hlxs)*@xdwbl,@bzsl);

end
  
    --如果开的是药库单位
if @dwtype=3 
begin
	    set @yl=@num*@zxcs*@ts/@jgts;
		set @zxdw=@ypdw
	    set @xdwbl=1;
end
  
     --如果开的是药房单位
  if @dwtype=4 
	    set @yl=dbo.getint(@num*@zxcs*@ts/@jgts,1);
 

  select  coalesce(@ggid,0) ggid,coalesce(@cjid,0) cjid,cast(coalesce(@yl,0) as decimal(10,1)) yl,dbo.fun_yp_ypdw(@zxdw) unit,
  	  	   cast(round(coalesce(@lsj/@xdwbl,0),4) as decimal(15,4)) price,cast(coalesce(round(@lsj*@yl/@xdwbl,2),0) as decimal(15,3)) sdvalue,coalesce(@xdwbl,0) ydwbl,
		   coalesce(@deptid,0) zxksid,
		 cast(round(coalesce(@pfj/@xdwbl,0),4) as decimal(15,4)) pfj,cast(coalesce(round(@pfj*@yl/@xdwbl,2),0) as decimal(15,3)) pfje,@kcl kcl,@bdelete bdelete

  
  end 
 END;