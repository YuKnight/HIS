IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[SP_MZYS_SelectYZxm]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_MZYS_SelectYZxm] 
GO
create PROCEDURE SP_MZYS_SelectYZxm  
 (      
   @all int ,--下载药品和项目  1 下载 0  实时查询 以下各项 @all=0 时有效    
   @xmly int, --0 全部 1 药品 2 项目      
   @zyyf int,--是否查找住院药房 1 查找    
   @execdept int , --执行科室,  
   @deptid int,--当前科室 Modify by Tany 2009-02-09 用于科室药房对应  
   @pym varchar(50),    
   @wbm varchar(50),    
   @itemname varchar(50),  
   @jgbm bigint, --机构编码    
   @kzsj smallint, --控制时间 1表示控制时间  
   @funname varchar(50)  
 )     
as    
/*-------------    
查找项目和药品    
-------------*/    
--exec SP_MZYS_SelectYZxm 1,0,0,0,0,'','','' ,1003 ,1,''  
declare @s1 varchar(5000)    
declare @s2 varchar(5000)    
declare @s3 varchar(5000)    
declare @top varchar(30)    
set @top=''  
declare @strkcl varchar(20)  
declare @jzks smallint  
set @jzks=0  
--Add By Zj 2012-02-29  
declare @xnkclconfig int   
 set @xnkclconfig=0  
--Add By Zj 2012-05-09 限制科室用药  
declare @ksyyxz varchar(200)  
if EXISTS(select CONFIG from JC_CONFIG where ID=3038)  
 set @ksyyxz=(select CONFIG from JC_CONFIG where ID=3038)  
if @ksyyxz='1'  
 set @ksyyxz=' and a.cjid not in ( select cjid from jc_yp_dept where dept_id='+cast(@deptid as varchar(50))+') '  
else  
 set @ksyyxz=''  
if EXISTS(select dept_id from JC_DEPT_TYPE_RELATION where dept_id=@deptid and type_code='003')  
 set @jzks=1  
if @all=0 and (@pym<>'' or @wbm<>'' or @itemname<>'')    
   set @top=' top 50 '    
--门诊医生站是否启用药房虚库存  
  
if EXISTS(select CONFIG from JC_CONFIG where ID=3029)  
   set @xnkclconfig=(select CONFIG from JC_CONFIG where ID=3029)  
--如果不启用虚库存 就是kcl  
if @xnkclconfig=0  
  set @strkcl='kcl'  
else  
  set @strkcl='xnkcl'  
    
BEGIN     
	--kslx2 修改为  ''门诊药房'' kslx2（whzxyy【不改前台，此处写死】）
  set @s1=' select '+@top+' null 序号,0 套餐,(rtrim(a.yppm)+isnull(ypspmbz,'''') +''  ''+s_ypgg) 项目内容,s_ypjx 剂型 , a.ggid as  yzid,a.yppm as yzmc,   
  lsj 单价,rtrim(s_ypdw) 单位,rtrim(cast(cast('+@strkcl+' as float) as varchar(50)))+rtrim(dbo.fun_yp_ypdw(zxdw)) 库存,    
  '''' 医保比例,dbo.fun_getdeptname(deptid) 执行科室,deptid zxksid,b.pym 拼音码,b.wbm 五笔码,a.cjid 项目id,1 项目来源 ,  
  statitem_code,''门诊药房'' kslx2,a.ggid,len(pym) bmcd   
 from VI_YF_KCMX a (nolock),yp_ypbm b  (nolock)     
    where a.ggid=b.ggid and a.bdelete_kc=0 '    
   if rtrim(@funname)='Fun_ts_mzys_blcflr' set @s1=@s1+ ' and '+@strkcl+'>0 ' --如果不等于门诊医生病历处方录入 就不控制库存量等于0的医嘱  
   if rtrim(@pym)<>'' set @s1=@s1+' and b.pym like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s1=@s1+' and wbm like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s1=@s1+' and ypbm like ''%'+@itemname+'%'''    
   --Add By Zj 2012-05-10   
   if RTRIM(@ksyyxz)<>'' set @s1=@s1+@ksyyxz  
     
   if @execdept>0 and @zyyf=0    
  set @s1=@s1+' and deptid='+cast(@execdept as varchar(10))+''    
   if @all<>1 --不是下载时    
   begin    
   if @zyyf=1    
        set @s1=@s1+' and kslx2=''住院药房'''    
   else     
       set @s1=@s1+' and kslx2=''门诊药房'''    
   end    
  
   --根据当前科室的药房对应关系来查找可以划价的药房  
    
   set @s1=@s1+' and deptid in (select drugstore_id from   
 jc_dept_drugstore where delete_bit=0 and dept_id='+cast(@deptid as varchar(10))+' and  convert(nvarchar,getdate(),108)>=convert(nvarchar,kssj,108)  
  and convert(nvarchar,getdate(),108)<=convert(nvarchar,jssj,108) )'    
  
    
   set @s2='select distinct '+@top+' null 序号,0 套餐,rtrim(c.order_name)+'' ''+isnull(c.bz,'''') as  项目内容,'''' 剂型, c.order_id as yzid,c.order_name as yzmc,    
   E.price 单价,rtrim(item_unit) 单位,null 库存,    
   '''' 医保比例,dbo.fun_getdeptname(f.exec_dept) 执行科室,f.exec_dept as zxksid,rtrim(c.py_code) 拼音码,rtrim(c.wb_code) 五笔码,a.item_id 项目id,2 项目来源 ,  
   statitem_code,'''' kslx2 ,0 ggid ,len(c.py_code) bmcd  
   from jc_hsitem a(nolock) inner join  jc_hoi_hdi b(nolock) on a.item_id=b.hditem_id and b.tc_flag=0  
   inner join jc_hoitemdiction c(nolock) on b.hoitem_id=c.order_id   
   inner join JC_STAT_ITEM d on a.statitem_code=d.code   
   inner join jc_hsitemprice e(nolock) on a.item_id=e.hsitemid  
   left join (select a.*,jgbm from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id  ) f on c.order_id=f.order_id  
   where c.delete_bit=0 and  (  
 (f.JGBM is null and e.jgbm='+cast(@jgbm as varchar(30))+') or (f.jgbm='+cast(@jgbm as varchar(30))+' and e.jgbm='+cast(@jgbm as varchar(30))+')   
 )'  
  
   if rtrim(@pym)<>'' set @s2=@s2+' and  c.py_code like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s2=@s2+' and c.wb_code like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s2=@s2+' and c.order_name like ''%'+@itemname+'%'''    
   if @execdept>0    
   set @s2=@s2+' and f.exec_dept='+cast(@execdept as varchar(10))+''    
  
    set @s2=@s2+'union all select distinct '+@top+' null 序号,0 套餐,rtrim(c.order_name)+'' ''+isnull(c.bz,'''') as  项目内容,'''' 剂型, c.order_id as yzid,c.order_name as yzmc,    
   E.price 单价,rtrim(item_unit) 单位,null 库存,    
   '''' 医保比例,dbo.fun_getdeptname(f.exec_dept) 执行科室,f.exec_dept as zxksid,rtrim(c.py_code) 拼音码,rtrim(c.wb_code) 五笔码,a.item_id 项目id,2 项目来源 ,  
   statitem_code,'''' kslx2 ,0 ggid ,len(c.py_code) bmcd  
   from jc_hsitem a(nolock) inner join  jc_hoi_hdi b(nolock) on a.item_id=b.hditem_id and b.tc_flag=0  
   inner join jc_hoitemdiction c(nolock) on b.hoitem_id=c.order_id   
   inner join JC_STAT_ITEM d on a.statitem_code=d.code   
   inner join jc_hsitemprice e(nolock) on a.item_id=e.hsitemid  
   left join (select a.*,jgbm from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id  ) f on c.order_id=f.order_id  
   where c.delete_bit=0 and  (  
   (  
 f.jgbm <>'+cast(@jgbm as varchar(30))+' and e.jgbm<>'+cast(@jgbm as varchar(30))+' and f.order_id not in(select order_id from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id and b.jgbm='+cast(@jgbm as varchar(30))+')  
 )   
 )'  
  
   if rtrim(@pym)<>'' set @s2=@s2+' and  c.py_code like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s2=@s2+' and c.wb_code like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s2=@s2+' and c.order_name like ''%'+@itemname+'%'''    
   if @execdept>0    
   set @s2=@s2+' and f.exec_dept='+cast(@execdept as varchar(10))+''    
  
  
    
   set @s3='select distinct '+@top+' null 序号,item_id 套餐,''[套餐] ''+rtrim(order_name) 项目内容,'''' 剂型, c.order_id as yzid,c.order_name as yzmc,    
   e.price 单价,rtrim(item_unit) 单位,null 库存,    
   '''' 医保比例,dbo.fun_getdeptname(f.exec_dept) 执行科室,f.exec_dept as zxksid,rtrim(c.py_code) 拼音码,rtrim(c.wb_code) 五笔码,item_id 项目id,2 项目来源,  
   '''' statitem_code, '''' kslx2,0 ggid  ,len(c.py_code) bmcd  
   from jc_tc_t a(nolock) inner join  jc_hoi_hdi b(nolock) on a.item_id=b.hditem_id and b.tc_flag=1  
   inner join jc_hoitemdiction c(nolock) on b.hoitem_id=c.order_id   
   inner join jc_tcprice e on a.item_id=e.tcid  
   left join (select a.*,jgbm from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id  ) f on c.order_id=f.order_id  
    where c.delete_bit=0 and  (  
 (f.JGBM is null and e.jgbm='+cast(@jgbm as varchar(30))+') or (f.jgbm='+cast(@jgbm as varchar(30))+' and e.jgbm='+cast(@jgbm as varchar(30))+')   
  )'  
     
 if rtrim(@pym)<>'' set @s3=@s3+' and  c.py_code like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s3=@s3+' and c.wb_code like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s3=@s3+' and c.order_name like ''%'+@itemname+'%'''    
   if @execdept>0    
      set @s3=@s3+' and f.exec_dept='+cast(@execdept as varchar(10))+''    
  
     set @s3=@s3+' union all select distinct '+@top+' null 序号,item_id 套餐,''[套餐] ''+rtrim(order_name) 项目内容,'''' 剂型, c.order_id as yzid,c.order_name as yzmc,    
   e.price 单价,rtrim(item_unit) 单位,null 库存,    
   '''' 医保比例,dbo.fun_getdeptname(f.exec_dept) 执行科室,f.exec_dept as zxksid,rtrim(c.py_code) 拼音码,rtrim(c.wb_code) 五笔码,item_id 项目id,2 项目来源,  
   '''' statitem_code, '''' kslx2,0 ggid  ,len(c.py_code) bmcd  
   from jc_tc_t a(nolock) inner join  jc_hoi_hdi b(nolock) on a.item_id=b.hditem_id and b.tc_flag=1  
   inner join jc_hoitemdiction c(nolock) on b.hoitem_id=c.order_id   
   inner join jc_tcprice e on a.item_id=e.tcid  
   left join (select a.*,jgbm from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id  ) f on c.order_id=f.order_id  
    where c.delete_bit=0 and  (  
 (  
 f.jgbm <>'+cast(@jgbm as varchar(30))+' and e.jgbm<>'+cast(@jgbm as varchar(30))+' and f.order_id not in(select order_id from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id and b.jgbm='+cast(@jgbm as varchar(30))+')  
 ) )'  
     
 if rtrim(@pym)<>'' set @s3=@s3+' and  c.py_code like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s3=@s3+' and c.wb_code like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s3=@s3+' and c.order_name like ''%'+@itemname+'%'''    
   if @execdept>0    
      set @s3=@s3+' and f.exec_dept='+cast(@execdept as varchar(10))+''    
  
    
  
if @all=1     
begin    
 exec(@s1+' union all '+@s2+' union all '+@s3+' ORDER BY STATITEM_CODE ASC')    
 print @s1+' union all '+@s2+' union all '+@s3    
 return    
end     
    
if @xmly=1    
begin    
  exec(@s1)    
  --print(@s1)    
  return    
end    
    
if @xmly=2    
begin    
 exec(@s2+' union all '+@s3+' ORDER BY STATITEM_CODE ASC')    
 --print(@s2+' union all '+@s3)    
 return    
end    
    
if @xmly=0    
begin    
 exec(@s1+' union all '+@s2+' union all '+@s3+' ORDER BY STATITEM_CODE ASC')    
 --print @s1+' union all '+@s2+' union all '+@s3    
 return    
end    
END  
    
    