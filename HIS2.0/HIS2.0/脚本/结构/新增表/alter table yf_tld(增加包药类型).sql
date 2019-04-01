IF NOT EXISTS(SELECT * from syscolumns WHERE ID IN(select ID from sysobjects where id=object_id('yf_tld')) AND NAME='bylx')
	alter table yf_tld add bylx int --包药类型
	
	
IF NOT EXISTS(SELECT * from syscolumns WHERE ID IN(select ID from sysobjects where id=object_id('YF_TLD_H')) AND NAME='bylx')
	alter table YF_TLD_H add bylx int --包药类型
 
