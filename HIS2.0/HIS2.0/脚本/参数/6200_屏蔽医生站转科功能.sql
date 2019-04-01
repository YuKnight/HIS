---add by jchl 2014-06-17
if not exists(select 1 from jc_config where id=6200)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6200','0','屏蔽医生站转科功能 0=不 1=是  ',6,getdate())