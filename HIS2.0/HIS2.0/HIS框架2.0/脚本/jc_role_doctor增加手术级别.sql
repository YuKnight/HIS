
--增加手术级别2013-8-13
IF NOT EXISTS(SELECT * from syscolumns WHERE ID IN(
select ID from sysobjects where id=object_id('jc_role_doctor')) AND NAME='OPERATERATE_TYPE')
alter table jc_role_doctor add OPERATERATE_TYPE SMALLINT  NOT NULL DEFAULT 0
go