


--
-- 菜单点击日志表
--

if exists( select 1 from dbo.sysobjects where name = N'Pub_User_CA_Certificate' )
	drop table Pub_User_CA_Certificate

go
	
create table 	Pub_User_CA_Certificate(
	ID					bigint			identity(1,1)	not null,
	EMPLOYEE_ID			int				not null,
	KEY_ID              varchar(50)    not null,
	CERTIFICATE		    varchar(max)	not null,
	IMAGEDATA           
	constraint PK_Pub_Menu_ClickLog primary key (ID)
)
go


