--门诊发药药房记账功能参数控制 0允许 1 不允许 默认为0  add pengyang 2015-7-10
if not exists(select 1 from jc_config where id=10025) 
insert into jc_config(id,config,note,module_id,cjsj) 
values(10025,'207','门诊发药药房记账功能参数控制',10,GETDATE())


 select * from JC_CONFIG where ID = 10025