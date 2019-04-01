
---add by jchl 2014-06-17
if not exists(select 1 from jc_config where id=6202)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6202','0','住院医生站临时医嘱参数控制药品是否必须输入频率 0=不 1=是  ',6,getdate())