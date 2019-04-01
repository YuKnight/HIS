---add by tany 2015-05-12
if not exists(select 1 from jc_config where id=7805)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('7805','0','单条费用冲正金额限制（0=不限制 大于0则超过此数额后限制，参数受限于7073、7075）',7,getdate())