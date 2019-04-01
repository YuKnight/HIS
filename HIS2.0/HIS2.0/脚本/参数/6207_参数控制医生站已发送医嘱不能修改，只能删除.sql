---add by jchl 2014-07-23
if not exists(select 1 from jc_config where id=6207)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6207','0','参数控制医生站已发送（状态为1）医嘱不能修改，只能删除 0=不 1=是  ',6,getdate())