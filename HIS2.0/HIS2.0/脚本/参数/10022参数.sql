--Add By Daniel 2015-01-31
if not exists(select 1 from JC_CONFIG where ID=10022)
INSERT INTO JC_CONFIG(ID,CONFIG,NOTE,MODULE_ID,CJSJ)
VALUES(10022,'1','门诊费用确认界面是否只显示默认执行科室为当前科室的医嘱项目,0=是,1=否,默认为1',10,GETDATE())
