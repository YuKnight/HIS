 if not exists 
(select * from  sys.columns where name ='BBJJSJ' and object_id in (select id from sys.sysobjects where xtype ='U' and name='YJ_ZYSQ'))
 alter table YJ_ZYSQ add BBJJSJ datetime null
  if not exists 
(select * from  sys.columns where name ='BBJJSJ' and object_id in (select id from sys.sysobjects where xtype ='U' and name='YJ_ZYSQ_H'))
 alter table YJ_ZYSQ_H add BBJJSJ datetime null