

--菜单点击日志表增加字段 IP
IF NOT EXISTS(SELECT * from syscolumns WHERE [NAME]='IP' AND ID IN( select ID from sysobjects where id=object_id('Pub_Menu_ClickLog')) )
	Alter table Pub_Menu_ClickLog add IP varchar(20) null
go


--菜单点击日志表增加字段 Mac
IF NOT EXISTS(SELECT * from syscolumns WHERE [NAME]='Mac' AND ID IN( select ID from sysobjects where id=object_id('Pub_Menu_ClickLog')) )
	Alter table Pub_Menu_ClickLog add Mac varchar(50) null
go