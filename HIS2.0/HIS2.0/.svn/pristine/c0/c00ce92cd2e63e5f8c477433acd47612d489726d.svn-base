if not exists( select id from syscolumns where id in( select id  from sysobjects where id=OBJECT_ID('JC_FREQUENCY') ) and name='MEMO'  )
	alter table JC_FREQUENCY add MEMO varchar(200)   
	
