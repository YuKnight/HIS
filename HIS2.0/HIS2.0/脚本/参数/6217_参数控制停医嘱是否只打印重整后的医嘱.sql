---add by jchl 2014-07-10
if not exists(select 1 from jc_config where id=6217)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6217','1','参数控制停医嘱是否只打印重整后的医嘱 0=不 1=是  ',6,getdate())