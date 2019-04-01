---add by tany 2015-05-27
if not exists(select 1 from jc_config where id=7806)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('7806','0','未处理项目是否可以取消药品 0=否 1=是（受限于参数7081）',7,getdate())
	
if not exists(select 1 from jc_config where id=7807)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('7807','1','未处理项目是否可以取消项目 0=否 1=是（受限于参数7081）',7,getdate())