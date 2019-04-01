if not exists( select id from syscolumns where id in( select id  from sysobjects where id=OBJECT_ID('JC_USAGEDICTION') ) and name='MEMO'  )
	alter table JC_USAGEDICTION add MEMO varchar(200)   
	