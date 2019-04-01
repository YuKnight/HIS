---add by jchl 2014-07-10
if not exists(select 1 from jc_config where id=6218)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6218','1','参数控制医嘱DC是否在医嘱内容中体现操作人和操作时间 0=不 1=是  ',6,getdate())