

---add by jchl 2014-06-17（联合19004 启用的才使用该参数）
if not exists(select 1 from jc_config where id=6204)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6204','0','住院抗生素权限越级是否进行审批 0=不 1=是  ',6,getdate())