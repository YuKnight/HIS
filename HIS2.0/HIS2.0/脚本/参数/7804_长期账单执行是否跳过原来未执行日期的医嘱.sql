---add by tany 2015-04-22
if not exists(select 1 from jc_config where id=7804)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('7804','0','长期账单执行是否跳过原来未执行日期的医嘱（如1号开的，2号未执行，3号执行时是否跳过执行2号的） 0=不是 1=是',7,getdate())