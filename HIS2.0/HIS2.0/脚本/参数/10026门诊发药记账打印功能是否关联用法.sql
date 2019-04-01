-- 门诊发药  0允许 1不允许 默认为0  add pengyang 2015-7-13
if not exists(select 1 from jc_config where id=10026) 
insert into jc_config(id,config,note,module_id,cjsj) 
values(10026,'1','门诊发药药房记账打印指定用法功能是否启用 0是 1否',10,GETDATE())


 