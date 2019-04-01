---add by jchl 2014-07-10
if not exists(select 1 from jc_config where id=7600)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('7600','1','护士站分配床位是否联动产生床位费，0否，1是  ',6,getdate())