
--菜单表增加授权码字段
IF NOT EXISTS(SELECT * from syscolumns WHERE [NAME]='AuthCode' AND ID IN( select ID from sysobjects where id=object_id('Pub_Menu')) )
	Alter table Pub_Menu add AuthCode text null default ''
go