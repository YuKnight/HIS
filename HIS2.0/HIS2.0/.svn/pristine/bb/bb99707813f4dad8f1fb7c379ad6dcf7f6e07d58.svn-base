
create table EventType(id int  IDENTITY(1,1),
event varchar(100),eventname varchar(100),GetXml varchar(100),WebService varchar(100),Pid int not null default 0,memo varchar(3000),pxxh int not null default 0,
delete_bit int not null default 0,djsj datetime not null default getdate(),url varchar(500))

 

--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('','药品事件','','',0,'',1)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('FYZT','回填老系统住院发药状态','FYZT','SaveFyzt',1,'',2)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('MZFYZT','门诊发药状态','MZFYZT','SaveMzFyzt',1,'',3)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('MZQXFYZT','门诊取消发药','MZQXFYZT','SaveMzQxFyzt',1,'',4)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('KCBH','药房库存变化','KCBH','SaveKcph',1,'',5)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('YKKCBH','药库库存变化','YKKCBH','SaveKcph',1,'',6)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('YF_DJ','药房单据同步','YF_DJ','SaveDjmx',1,'',7)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('YK_DJ','药库单据同步','YK_DJ','SaveDjmx',1,'',8)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('YPTJ','药品调价','YPTJ','SaveTjxx',1,'',9)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('YP_YPCJD','同步HIS药品目录','YP_YPCJD','SaveYpzd',1,'',10)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('YP_YPCJD_KF','同步快发药品目录','YP_YPCJD_KF','YP_YPCJD_KF',1,'',11)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('YP_HWSZ_KF','同步快发货位','YP_HWSZ_KF','YP_HWSZ_KF',1,'',12)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('yf_tld_tsbyj','汤山包药机数据推送','yf_tld_tsbyj','SaveTsByj',1,'',12)

--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('','住院事件','','',0,'',12)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('NewOrder.HIS','向老HIS同步医嘱','NewOrder.HIS','SaveOrder',12,'',13)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('StopOrder.HIS','向老HIS停医嘱','StopOrder.HIS','StopOrder',12,'',14)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('CancelNewOrder.HIS','取消老HIS停医嘱','CancelNewOrder.HIS','CancelOrder',12,'',15)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('NewOrder.HIS.ZCY','向老HIS同步中药医嘱','NewOrder.HIS.ZCY','SaveZCYCF',12,'',16)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('CancelNewOrder.HIS.ZCY','取消老HIS停中药医嘱','CancelNewOrder.HIS.ZCY','CancelZCYCF',12,'',17)

--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('','EMR\ECG','','',0,'',18)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('NewOrder.EMR','向EMR同步医嘱','NewOrder.EMR','NewOrder.EMR',18,'',19)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('CancelNewOrder.EMR','取消EMR医嘱','CancelNewOrder.EMR','CancelNewOrder.EMR',18,'',20)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('StopOrder.EMR','停EMR医嘱','StopOrder.EMR','StopOrder.EMR',18,'StopOrder.EMR',21)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('UNStopOrder.EMR','取消停EMR医嘱','UNStopOrder.EMR','UNStopOrder.EMR',18,'',22)

--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('NewExamOrder.EMR','向EMR同步检验申请','NewExamOrder.EMR','NewExamOrder.EMR',18,'',23)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('CancelNewExamOrder.EMR','取消EMR检验申请','CancelNewExamOrder.EMR','CancelNewExamOrder.EMR',18,'',24)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('NewCheckOrder.EMR','向EMR同步检查申请','NewCheckOrder.EMR','NewCheckOrder.EMR',18,'',25)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('CancelNewCheckOrder.EMR','取消EMR检查申请','CancelNewCheckOrder.EMR','CancelNewCheckOrder.EMR',18,'',26)


--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('NewCheckOrder.ECG','向ECG同步医嘱','NewCheckOrder.ECG','NewCheckOrder.ECG',18,'',27)
--insert into EventType(event,eventname,getxml,WebService,pid,memo,pxxh)values('CancelNewCheckOrder.ECG','取消ECG医嘱','CancelNewCheckOrder.ECG','CancelNewCheckOrder.ECG',18,'',28)

--update EventType set url='http://192.168.0.90:88/TrasenWS.asmx'  

--update EventType set WebService='YP_HWSZ_KF' where event='YP_HWSZ_KF'

update EventType set url='http://192.168.0.90:88/TrasenWS.asmx'  where [event]='yf_tld_tsbyj'