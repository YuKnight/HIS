---add by jchl 2014-07-10
if not exists(select 1 from jc_config where id=6212)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6212','1','参数控制补录医嘱是否允许修改为药库单位 0=不 1=是  ',6,getdate())