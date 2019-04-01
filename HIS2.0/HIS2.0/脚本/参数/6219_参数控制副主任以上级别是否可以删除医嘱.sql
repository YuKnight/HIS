---add by jchl 2014-07-10
if not exists(select 1 from jc_config where id=6219)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6219','1','参数控制副主任以上级别是否可以删除医嘱 0=不 1=是  ',6,getdate())