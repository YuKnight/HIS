


--
-- 菜单点击日志表
--

if exists( select 1 from dbo.sysobjects where name = N'Pub_Menu_ClickLog' )
	drop table Pub_Menu_ClickLog

go
	
create table 	Pub_Menu_ClickLog(
	ID					bigint			identity(1,1)	not null,
	SYSTEM_ID			int				not null,
	FUNCTION_NAME		varchar(50)	not null,
	EMPLOYE_ID			int				not null,
	LOGTIME				datetime		not null	default getdate(),
	CONTENT				TEXT			default ''
	constraint PK_Pub_Menu_ClickLog primary key (ID)
)
go


