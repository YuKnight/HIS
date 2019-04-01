---add by tany 2015-04-27
if not exists(select 1 from jc_config where id=9100)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('9100','','医生站开出院医嘱时，不验证以下麻醉方式是否有费用未录入（请填写麻醉方式的汉字）',9,getdate())