IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_SELECT_WLDW' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_SELECT_WLDW
GO
CREATE PROCEDURE sp_YF_SELECT_WLDW
(
	@functionname varchar(30),
	@deptid int,
	@ss varchar(3000) output
)
as
begin
 declare @ssql varchar(3000);
 --基本的SQL语名

 --请领入库单——一级药房请领
 if @functionname='Fun_ts_yf_ypqlrk'  
 begin
 	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property '+
			 ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and  code=''01'' )';
 end	
  --请领入库单 ——二级药房请领
if @functionname='Fun_ts_yf_ypqlrk_xyg'  
begin
   set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property '+
	        ' WHERE dept_id in(select a.deptid  from yp_yjks a,yp_lyks b where a.deptid=b.deptid and b.dyksid='+cast(@deptid as char(10))
			+' and qybz=1 and a.kslx=''药房'' and a.kslx2  in(''住院药房'',''门诊药房''))' ;
end	
 
 
 --药库药品出库单
if @functionname='Fun_ts_yf_ypptrk_sh' 
begin
 	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     'WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code=''01'')';
end
 --药品调入单
if @functionname='Fun_ts_yf_ypptrk_drd' 
begin
 	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code=''02'')';
end
 
  --期初入库单
if @functionname='Fun_ts_yf_ypptrk_qc' 
begin
 	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+')';
end
 
 --药品调出单
if @functionname='Fun_ts_yf_ypck' 
begin
  	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code=''02'')';
end
 
  --药房退库单
if @functionname='Fun_ts_yf_ypck_tk' 
begin
  	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code=''01'')';
end
 
   --其它领药单
if @functionname='Fun_ts_yf_ypck_qtly' or @functionname='Fun_ts_yf_ypck_wyylyd' 
begin
  	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code=''04'')';
end
 --外用药领药单
if  @functionname='Fun_ts_yf_ypck_wyylyd' 
begin
  	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property where dept_id<>0 ';
end
 
    --其它领药单
if @functionname='Fun_ts_yf_ypck_xygck' 
begin
  	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code in(''03'',''04''))';
end
 
 --门诊大输液基数补充
if @functionname='Fun_ts_yf_mzdsy' or @functionname='Fun_ts_yf_zydsy' 
begin
  	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     ' WHERE dept_id in(select deptid from yp_yjks where kslx2=''住院药房'')';
end
 
  --所有
if @functionname='' 
begin
  	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+')';
end
 
 
 
 set @ss=rtrim(@ssql);
 return;
 
 end 
 
 
 