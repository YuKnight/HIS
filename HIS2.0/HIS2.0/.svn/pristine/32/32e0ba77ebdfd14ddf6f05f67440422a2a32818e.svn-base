
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_ClearData' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_ClearData
GO
CREATE PROCEDURE [dbo].[SP_YF_ClearData]  
 (  
   @deptid integer  
 )   
as  
BEGIN  
   declare @kslx2 varchar(20);  
   delete from yF_cgmx where djid in(select id from yf_cg where deptid=@deptid);  
   delete from yF_cg where deptid=@deptid;  
   
   delete from YF_djmx where deptid=@deptid;   
   delete from YF_dj where deptid=@deptid;  
    
   delete from YF_djmx_h where deptid=@deptid;  
   delete from YF_dj_h where deptid=@deptid;  
  
  
   delete from YF_kcmx where deptid=@deptid;  
   delete from YF_kcph where deptid=@deptid;  
  
   delete from yf_pdtemp where deptid=@deptid  
  
   delete from YF_pdmx where djid in(select id from yf_pd where deptid=@deptid);  
   delete from YF_pd where deptid=@deptid;  
  
   delete from YF_pdcsmx where deptid=@deptid;  
   delete from YF_pdcs where deptid=@deptid;          
  
   delete from YF_rksqmx where deptid=@deptid;  
   delete from YF_rksq where deptid=@deptid;  
  
   delete from YF_tjmx where deptid=@deptid;  
   delete from YF_tj where deptid=@deptid;  
  
   delete from yp_djh where deptid=@deptid;  
   insert into yp_djh(ywlx,djh,deptid) select ywlx,0,@deptid from yf_ywlx;  
   insert into yp_djh(ywlx,djh,deptid)values('100',0,@deptid);  
   update  yP_djh set djh=0,sdjh='',ndjh=0  where deptid=@deptid;  
  
     
   delete from YF_ymjc where deptid=@deptid;  
   delete from yp_kjqj where deptid=@deptid;  
   delete from yk_config where deptid=@deptid;  
   
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('100','采购入库是否保存即增加库存',0,'1 不可以使用 0 可使用',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('101','强制控制库存',0,'0 正常 1 开始',@deptid);  
--   insert into yk_config(bh,mc,zt,bz,deptid)values('102','管理批号',0,'0 不管 1 管理',@deptid);  
--   insert into yk_config(bh,mc,zt,bz,deptid)values('103','库位管理',0,'0 不管 1 管理',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('104','系统启用',1,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('105','禁用系统',0,'0 否 1 是',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('106','配药模式',1,'0 否 1 是',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('107','配药模式下强制配药',1,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('108','业务单据接受方是否可以手工办理单据',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('109','是否允许对没有库存记录的药品进行盘存',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('110','是否允许对没有库存记录的药品进行调价',0,'0 否 1 是',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('112','网络内容显示商品名',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('113','打印单据时单据显示商品名',0,'0 打印品名 1 打印商品名',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('114','统领单领药和退药是否分开',0,'0 不分开 1 分开',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('115','门诊发药和退药时默认打印小票',0,'0 不允许 1 允许',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('116','门诊配药时打印清单',0,'0 不打 1 打印',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('117','门诊配药时打印处方',0,'0 不打 1 打印',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('118','门诊配药时打印注射单',0,'0 不打 1 打印',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('119','门诊发药时打印清单',0,'0 不打 1 打印',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('120','门诊发药时打印处方',0,'0 不打 1 打印',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('121','门诊发药时打印注射单',0,'0 不打 1 打印',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('122','门诊发药时默认打印处方',0,'0 不打 1 打印',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('123','当统领单领退分开时(参数114=1时),退药明细默认不选择',0,'1 不选择 0 选择',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('124','门诊发药时回车,发药按钮是否立即获得焦点',1,'1 不选择 0 选择',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('151','门诊发药后才能打印处方',0,'1 不选择 0 选择',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('153','控制是否使用分包机',0,'0否 1是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('999','是否启用批次管理',0,'0-不启用,1-启用',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('998','盘存方式',0,'0-按批次库存盘存,1-按总库存盘存',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('997','是否启用快发接口',0,'0-不启用,1-启用',@deptid);
   set @kslx2=(select rtrim(kslx2) from yp_yjks where deptid=@deptid );  
   if (@kslx2 is null)   
      set @kslx2='';  
  
   if rtrim(@kslx2)='门诊药房'   
   begin  
   insert into yk_config(bh,mc,zt,bz,deptid)values('106','配药模式',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('107','配药模式下强制配药',0,'0 否 1 是',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('152','门诊收费分配发药窗口时是否验证发药窗口的使用状态',0,'0 不验证 1 验证在用状态',@deptid);  
   end   
  
        
  
   delete from yf_fy where deptid=@deptid;  
   delete from yf_fy_h where deptid=@deptid;  
   delete from yf_fymx where deptid=@deptid;  
   delete from yf_fymx_h where deptid=@deptid;  
   delete from yf_fymx_ph where deptid=@deptid;  
   delete from yf_fymx_ph_h where deptid=@deptid;  
     
   delete from yf_tldmx where groupid in(select groupid from  yf_tld where deptid=@deptid);  
   delete from yf_tldmx_h where groupid in(select groupid from  yf_tld_h where deptid=@deptid);  
   delete from yf_tld where deptid=@deptid;  
   delete from yf_tld_h where deptid=@deptid;  
   
   delete from yf_zyfymx where deptid=@deptid  
     
   delete from YF_PD where DEPTID=@deptid  
   delete from YF_PDCS where DEPTID=@deptid   
   delete from YF_PDCSMX_KCMX where DEPTID=@deptid;--盘点录入明细（库存明细）  
   delete from YF_PDMX_KCMX where DJID in ( select id from yf_pd where deptid=@deptid) --盘点审核明细（库存明细）  
   delete from YF_PDTEMP_KCMX where DEPTID=@deptid;--盘点帐存（库存明细）  
   delete from YF_DJ_H where DEPTID =@deptid --药房单据临时表  
   delete from YF_DJMX_H where DEPTID=@deptid--药房单据明细临时表  
   delete from YF_DJ_H where DEPTID=@deptid --药库单据临时表  
   delete from YF_DJMX_H where DEPTID=@deptid --药库单据明细临时表  
   delete from yf_tldmx_fee   where zxks=@deptid   
     
  
  
   update yp_yjks set qybz=1,qysj=getdate() where deptid=@deptid;  
  
end ;