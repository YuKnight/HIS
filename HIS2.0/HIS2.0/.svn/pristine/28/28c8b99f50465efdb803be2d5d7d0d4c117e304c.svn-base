

/*******************************************************************************************/
/*用于系统运行过程中，存放各个子系统之间发送的消息                                         */
/*******************************************************************************************/

if exists( select 1 from dbo.sysobjects where name = N'Pub_Message_Record' )
	drop table Pub_Message_Record

go

create table Pub_Message_Record(
	MsgId           uniqueidentifier     not null,
	Summary         varchar(1000)        not null,                        --消息摘要，用于显示的简要信息,消息发送端填写
	SendTime        datetime			 not null default getdate(),      --消息发送时间
	SendStaff       int                  not null                  ,      --消息发送人ID
	SendByIP        varchar(20)          not null                  ,      --消息发送时的机器IP
	FontColor       varchar(20)          not null                  ,      --字体                            （*）
	ShowType        smallint             not null default 0      ,      --消息显示方式 0:气泡 1:弹出窗体   （*）气泡弹出的消息认为是非强制读取的，窗口的则为强制读取
	ShowTime        int                  not null default 0       ,      --显示时间                        （*）只对气泡弹出的消息有效
	ReciveSystem    int                  not null default 0       ,      --能接收消息的系统模块             （*）
	ReciveStaff     int                  not null default 0       ,      --能接收消息的操作员                （*）
	ReciveDept      int                  not null default 0       ,      --能接收消息的科室                  （*）
	ReciveWard      varchar(10)         not null default ''      ,      --能接收科室的病区                  （*）
	DealStatus      smallint             not null default 0      ,      --处理状态 （0，未处理，1、仅标记为已读，2、已做处理)
	FirstReader     int                  not null default 0       ,      --第一个阅读的人ID
	ReadTime        DateTime             null                      ,      --阅读时间
	ReadByIP        varchar(20)          not null default ''     ,      --阅读消息时的机器IP
	DllName         varchar(100)         null                      ,      --显示消息内容时需要调用的DLL模块,如果是气泡提示，不需要填写
	FuncationName   varchar(100)         null                      ,      --调用函数名
	FormText        varchar(100)         null                      ,      --窗体标题名
	FuncationTag    varchar(100)         null                      ,      --函数附加值
	InvokMethod     varchar(100)         null                      ,      --窗体加载后的回调函数名
	Parameter       varchar(1000)        null default ''           ,      --传递给目标窗体的参数(开发人员自定义)
	constraint PK_PUB_MESSAGE_RECORD primary key  (MsgId) 
)

go