---add by jchl 2014-07-10
if not exists(select 1 from jc_config where id=6209)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6209','0','参数控制是否屏蔽会诊申请 0=不 1=是  ',6,getdate())