IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_Fun_DW_NUM_TS' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_Fun_DW_NUM_TS
GO
CREATE PROCEDURE sp_Fun_DW_NUM_TS  
(
 @dwtype INT ,--单位类型
 @num decimal(10,4),--用量
 @zxcs int,--执行次数
 @jgts int,--间隔天数
 @CJID INT,--厂家ID
 @DEPTID INT,--药房代码
 @DWBL INT,--原单位比例
 @ypsl decimal(10,1)--药品数量,    
 --OUT @ts int
)  
as
 begin
  declare @ts decimal(10,1);
  declare @yl int;
  declare @ggid int;
  declare @ypdw int;
  declare @xdwbl int;
  declare @zxdw int;
  declare @lsj decimal(10,2);
  declare @hlxs decimal(10,4);
  declare @bzsl int;
  declare @lyfs int ;--领药方式
  


begin
  
 --select a.ggid,hlxs,bzsl,ypdw,lsj,lyfs into @ggid,@hlxs,@bzsl,@ypdw,@lsj,@lyfs from yp_ypggd a,yp_ypcjd b where a.ggid=b.ggid and cjid=@cjid;
 --select dwbl,zxdw into @xdwbl,@zxdw from yp_ypcl where deptid=@deptid and cjid=@cjid; 
 select @ggid=a.ggid,@hlxs=hlxs,@bzsl=bzsl,@ypdw=ypdw,@lsj=lsj,@lyfs=lyfs  from yp_ypggd a,yp_ypcjd b where a.ggid=b.ggid and cjid=@cjid;
 select @xdwbl=dwbl,@zxdw=zxdw  from yp_ypcl where deptid=@deptid and cjid=@cjid; 
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
	 	set @yl=dbo.getint(@num,@hlxs);
		set @ts=cast(((@ypsl*@bzsl/@dwbl)/@yl)*@jgts/@zxcs as int)
	 end 
	  --如果是按剂量累计取整
	 if @lyfs=2 
	 begin
		set @yl=@ypsl*@bzsl*@hlxs/@dwbl;
		set @ts=cast((@yl/@num)*@jgts/@zxcs as int)
	 end 
end
  
   --如果开的是包装单位 如果开的是包装单位 如果开的是包装单位 如果开的是包装单位
if @dwtype=2 
begin
  	 if @lyfs=1 
	 begin
	    	set @yl=cast(@ypsl*@bzsl/@dwbl as int)/dbo.getint(@num,1);
		set @ts=cast(@yl*@jgts/@zxcs as int);
	 end
	 
	 if @lyfs=2
	 begin
	 	set @yl=cast(((@ypsl*@bzsl/@dwbl)*@hlxs)/(@num*@hlxs) as int);
		set @ts=cast(@yl*@jgts/@zxcs as int);
	 end 
end
  
    --如果开的是药库单位
 if @dwtype=3 
begin
		set @yl=@num;
		set @ts=((@ypsl*@xdwbl)/@yl)*@jgts/@zxcs; 
end
  
     --如果开的是药房单位
  if @dwtype=4 
begin
	    set @yl=@num;
		set @ts=((@ypsl*@xdwbl/@dwbl)/@yl)*@jgts/@zxcs;
end
  
  
       select top 1 coalesce(cast(round(@lsj/@dwbl,4) as decimal(10,4)),0) price,coalesce(cast(round(@lsj*@ypsl/@dwbl,2) as decimal(10,2)),0) sdvalue,
	 coalesce(cast(@ts as decimal(10,0)),0) ts from yp_yjks 
 end 
 END;