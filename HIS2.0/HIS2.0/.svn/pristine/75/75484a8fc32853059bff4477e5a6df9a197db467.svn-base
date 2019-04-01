IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_fymx_ph' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_fymx_ph
GO 
CREATE PROCEDURE sp_yf_fymx_ph
(
	@id uniqueidentifier ,
	@fymxid uniqueidentifier,
	@fph bigint,
	@cfxh uniqueidentifier,
	@cjid int ,
	@ypdw varchar(10),
	@ydwbl int ,
	@ypph varchar(30),
	@ypsl decimal(15,3),
	@cfts int ,
	@deptid int ,
	@tyid uniqueidentifier,
	@yppch varchar(100),
	@kcid uniqueidentifier,
	@ypxq  char(10),
	@jhj decimal(15,3),
	@jhje decimal(15,3) 
)
as 
begin
	declare @ssql varchar(8000)
	if @id<>dbo.FUN_GETEMPTYGUID()
	begin
		set @ssql=dbo.FUN_GETGUID(NEWID(),getdate())
		set @ssql=' insert into yf_fymx_ph(id,fymxid,fph,cfxh,cjid,ypdw,ydwbl,ypph,ypsl,cfts,deptid,tyid,yppch,kcid,ypxq,jhj,jhje) values '
		set @ssql=@ssql+'( @id,@fymxid,@fph,@cfxh,@cjid,@ypdw,@ydwbl,@ypph,@ypsl,@cfts,@deptid,@tyid,@yppch,@kcid,@ypxq,@jhj,@jhje )'
	end
	else
	begin
		set @ssql=' update yf_fymx_ph set id=@id,@fymxid=@fymxid,fph=@fph,cfxh=@cfxh,cjid=@cjid,
				    ypdw=@ypdw,ydwbl=@ydwbl,ypph=@ypph,ypsl=@ypsl,cfts=@cfts,deptid=@deptid,tyid=@tyid,
					kcid=@kcid,ypxq=@ypxq,jhj=@jhj,jhje=@jhje '
	end
	print @ssql
	exec(@ssql)
end
