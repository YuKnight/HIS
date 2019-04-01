--add by jiangzf 2014-08-07  门诊医生站，无处方级别的医生需开此药品 0有提示,但可以开 1要上级审核 2不准开 默认0
if not exists(select 1 from jc_config where id=3126)
INSERT INTO dbo.JC_CONFIG ( ID , CONFIG , NOTE ,CJSJ ,MODULE_ID ,CSJB ,RWBZ ,BLBZ)
VALUES  ( 3126 ,'0' ,'门诊医生站，无处方级别的医生需开此药品 0有提示,但可以开 1要上级审核 2不准开 默认0',GETDATE(),3 , 0 , 0 , 0  )
GO