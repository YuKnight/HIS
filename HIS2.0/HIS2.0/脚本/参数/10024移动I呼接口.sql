--Add By pengyang 2015-6-30
if not exists(select 1 from JC_CONFIG where ID=10024)
INSERT INTO JC_CONFIG(ID,CONFIG,NOTE,MODULE_ID,CJSJ)
VALUES(10024,'0','参数控制住院医技I呼接口是否开启,0=是,1=否,默认为0',10,GETDATE())
