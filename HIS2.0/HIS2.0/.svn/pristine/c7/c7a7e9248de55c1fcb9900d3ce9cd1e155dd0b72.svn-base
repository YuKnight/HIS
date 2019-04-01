
--列 -- 下载文件夹
IF NOT EXISTS(SELECT * from syscolumns WHERE ID IN(
select ID from sysobjects where id=object_id('pub_systemupdate')) AND NAME='Download_Folder')
alter table pub_systemupdate add Download_Folder varchar(200) default ''
go