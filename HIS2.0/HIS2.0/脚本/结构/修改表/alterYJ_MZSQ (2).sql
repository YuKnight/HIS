 if not exists 
(select * from  sys.columns where name ='BBJJSJ' and object_id in (select id from sys.sysobjects where xtype ='U' and name='YJ_MZSQ'))
 alter table YJ_MZSQ add BBJJSJ datetime null
 if not exists 
(select * from  sys.columns where name ='BBJJSJ' and object_id in (select id from sys.sysobjects where xtype ='U' and name='YJ_MZSQ_H'))
 alter table YJ_MZSQ_H add BBJJSJ datetime null
