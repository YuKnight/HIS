IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_UPDATE_ZYFY' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_UPDATE_ZYFY
GO
CREATE PROCEDURE SP_YF_UPDATE_ZYFY 
 ( 
	@id uniqueidentifier,
	@kcid uniqueidentifier, 
	@err_text  varchar(100) output,
	@err_code int output 
 )
as
BEGIN
	set @err_code=-1
	set @err_text=''
	declare @ssql  varchar(200)
	update zy_fee_speci set kcid =@kcid where id =@id
	if @@rowcount = 0
	begin
		set @err_text='回填费用表中批次失败'
		return
	end
	
	set @err_code = 0 
	set @err_text='更新成功'
	
END