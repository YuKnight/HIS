---add by jchl 2014-07-10
if not exists(select 1 from jc_config where id=6210)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6210','0','参数控制长期医嘱是否允许开立中草药处方 0=不 1=是  ',6,getdate())