IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_SELECT_DW' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_SELECT_DW
GO
CREATE PROCEDURE SP_YF_SELECT_DW
 ( @CJID INTEGER, 
   @DEPTID INTEGER
 ) 
as
begin
		declare @hldw int;
		declare @bzdw int;
		declare @dw int;
		declare @zxdw int;
		DECLARE @DWBL int;
		declare @kcl decimal(15,0);
		declare @s_zxdw varchar(10);
		Create table 
		#temp(
		rowno int,
		cjid int,--厂家ID
		dwlx int,--单位类型
		ypdw int,--药品单位
		kcl decimal(15,0),--库存量
		kcdw int,--库存单位
		deptid int,--药房
		s_ypdw varchar(10),--药品单位中文
		s_kcdw varchar(10),--库存单位中文
		DWBL INT--单位比例
		)  

	
	
BEGIN

			   
		  select @hldw=hldw,@bzdw=bzdw,@dw=ypdw,@zxdw=zxdw,@dwbl=dwbl,@kcl=kcl from vi_yf_kcmx where cjid=@cjid  and deptid=@deptid
		  
		  if @dw<>0 
                  begin
  		  	   set @s_zxdw=(select dbo.fun_yp_ypdw(@zxdw));
 			  --含量单位
 			   insert into #temp(rowno,cjid,dwlx,ypdw,kcl,kcdw,deptid,s_ypdw,s_kcdw,dwbl) values(1,@cjid,1,@hldw,@kcl,@zxdw,@deptid,(dbo.fun_yp_ypdw(@hldw)),@s_zxdw,@dwbl);
 			  --包装单位
 			   insert into #temp(rowno,cjid,dwlx,ypdw,kcl,kcdw,deptid,s_ypdw,s_kcdw,dwbl) values(2,@cjid,2,@bzdw,@kcl,@zxdw,@deptid,(dbo.fun_yp_ypdw(@bzdw)),@s_zxdw,@dwbl);
 			  --药库单位
 			   insert into #temp(rowno,cjid,dwlx,ypdw,kcl,kcdw,deptid,s_ypdw,s_kcdw,dwbl) values(3,@cjid,3,@dw,@kcl,@zxdw,@deptid,(dbo.fun_yp_ypdw(@dw)),@s_zxdw,1);
  			  --药房单位
 			   insert into #temp(rowno,cjid,dwlx,ypdw,kcl,kcdw,deptid,s_ypdw,s_kcdw,dwbl) values(4,@cjid,4,@zxdw,@kcl,@zxdw,@deptid,@s_zxdw,@s_zxdw,@dwbl);
		  end 
		  
		 
		   select rowno,cjid,dwlx,ypdw,kcl,kcdw,deptid,s_ypdw,s_kcdw,dwbl,(rtrim(cast(kcl as char(15)))+s_kcdw) as kcsl,
			   		  'A' as py_code,'A' as wb_code ,'0' d_code from #temp;
  end 

end 



