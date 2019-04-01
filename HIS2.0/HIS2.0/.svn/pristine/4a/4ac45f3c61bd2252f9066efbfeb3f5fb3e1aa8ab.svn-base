--冲账窗口是否允许取消项目  0允许 1 不允许 默认为0 ADD BY CC 2014-08-11
if not exists(select 1 from jc_config where id=10020) 
insert into jc_config(id,config,note,module_id,cjsj) 
values(10020,0,'冲账窗口是否允许取消项目  0允许 1 不允许 默认为0',10,GETDATE())
