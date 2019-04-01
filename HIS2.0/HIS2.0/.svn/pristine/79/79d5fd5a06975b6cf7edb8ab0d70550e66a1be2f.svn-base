
--列 增加端口号
IF NOT EXISTS(SELECT * from syscolumns WHERE [NAME]='Login_Port' AND ID IN( select ID from sysobjects where id=object_id('Pub_User')) )
	Alter table Pub_User add Login_Port int default 0
go