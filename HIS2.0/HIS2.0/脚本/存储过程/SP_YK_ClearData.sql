CREATE PROCEDURE SP_YK_ClearData  
 (  
    @deptid integer  
 )   
as  
BEGIN  
   delete from yf_cgmx where djid in(select id from yf_cg where deptid=@deptid);  
   delete from yf_cg where deptid=@deptid;  
  
   delete from yk_djmx where deptid=@deptid;  
   delete from yk_djmx_h where deptid=@deptid;  
  
   delete from yk_dj where deptid=@deptid;  
   delete from yk_dj_h where deptid=@deptid;  
  
   delete from yk_kcmx where deptid=@deptid;  
   delete from yk_kcph where deptid=@deptid;  
  
   delete from yf_pdmx where djid in(select id from yf_pd where deptid=@deptid);  
   delete from yf_pd where deptid=@deptid;  
  
   delete from yf_pdcsmx where deptid=@deptid;  
   delete from yf_pdcs where deptid=@deptid;  
  
   delete from yf_rksqmx where deptid=@deptid;  
   delete from yf_rksq where deptid=@deptid;  
  
   delete from yf_tjmx where deptid=@deptid;  
   delete from yf_tj where deptid=@deptid;  
  
   delete from yF_fymx_ph where deptid=@deptid;  
   delete from yF_fymx_ph_h where deptid=@deptid;  
     
   delete from yF_fymx where deptid=@deptid;  
   delete from yF_fy where deptid=@deptid;  
  
   delete from yF_fymx_h where deptid=@deptid;  
   delete from yF_fy_h where deptid=@deptid;  
  
   delete from yp_djh where deptid=@deptid;  
   insert into yp_djh(ywlx,djh,deptid) select ywlx,0,@deptid from yk_ywlx;  
   update  yP_djh set djh=0  where deptid=@deptid;  
     
   --delete from yp_gllx where deptid=@deptid;  
     
   delete from yK_ymjc where deptid=@deptid;  
   delete from yp_kjqj where deptid=@deptid;  
     
   --add by ncq 2014-05-23   
   delete from YF_PD where DEPTID=@deptid  
   delete from YF_PDCS where DEPTID=@deptid    
   delete from Yf_PDCSMX_KCMX where DEPTID=@deptid;--盘点录入明细（库存明细）  
   delete from Yf_PDMX_KCMX where DJID in ( select id from yf_pd where deptid=@deptid) --盘点审核明细（库存明细）  
   delete from Yf_PDTEMP_KCMX where DEPTID=@deptid;--盘点帐存（库存明细）  
   delete from YK_DJ_H where DEPTID =@deptid --药房单据临时表  
   delete from YK_DJMX_H where DEPTID=@deptid--药房单据明细临时表  
   delete from YK_DJ_H where DEPTID=@deptid --药库单据临时表  
   delete from YK_DJMX_H where DEPTID=@deptid --药库单据明细临时表  
     
   delete YP_KCSXX where DEPTID=@deptid   
    
     
     
     
     
   delete from yk_config where deptid=@deptid;  
   --insert into yk_config(bh,mc,zt,bz,deptid)values('100','采购入库是否保存即增加库存',0,'1 不可以使用 0 可使用',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('101','强制控制库存',0,'0 正常 1 开始',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('102','管理批号',1,'0 不管 1 管理',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('103','库位管理',0,'0 不管 1 管理',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('104','系统启用',1,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('105','禁用系统',0,'0 否 1 是',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('106','配药模式',1,'0 否 1 是',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('107','配药模式下强制配药',1,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('108','业务单据接受方是否可以手工办理单据',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('109','是否允许对没有库存记录的药品进行盘存',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('110','是否允许对没有库存记录的药品进行调价',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('111','直接录入批发价',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('112','网络内容显示商品名',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('113','打印单据时单据显示商品名',0,'0 打印品名 1 打印商品名',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('114','入库汇总统计区分业务员',0,'0 不区分 1 区分',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('125','采购入库单显示批发价和批发金额',0,'0 不显示 1 显示',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('125','采购入库单显示批发价和批发金额',0,'0 不显示 1 显示',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('999','是否启用批次管理',0,'0-不启用,1-启用',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('998','盘存方式',0,'0-按批次库存盘存,1-按总库存盘存',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('997','是否启用快发接口',0,'0-不启用,1-启用',@deptid);
   update yp_yjks set qybz=1,qysj=getdate() where deptid=@deptid;  
  
end ;  
  
  
  