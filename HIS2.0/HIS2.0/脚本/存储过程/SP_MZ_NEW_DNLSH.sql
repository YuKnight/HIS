IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_MZ_NEW_DNLSH]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_MZ_NEW_DNLSH]
GO
create procedure [dbo].[SP_MZ_NEW_DNLSH](
@jgbm int,
@dnlsh varchar(20) output
)
as
begin
	if not exists(select 1 from jc_identity where rowtype=9)
	begin
		insert into jc_identity(rowtype,name,no) values ( 9 , '门诊电脑流水号',1)
	end
	declare @no bigint

	set @no = (select no from jc_identity where rowtype=9)
	update jc_identity set no=no+1 where rowtype=9

	declare @s1 varchar(8)
	declare @s2 varchar(4)
	declare @s3 varchar(12)
	set @s1 = right( cast(year(getdate()) as char(4)) ,4)
	set @s1 = @s1 + right('0' + cast(month(getdate()) as varchar) ,2)
	set @s1 = @s1 + right('0' + cast(day(getdate()) as varchar) ,2)
 set @s2 = (select top 1 yybm  from jc_jgbm where jgbm=@jgbm)  
	set @s3 = right('000000' + cast(@no as varchar) , 7)
	set @dnlsh = @s1+@s2+@s3
end



/*
declare @dnlsh varchar(20)
exec SP_MZ_NEW_DNLSH 1001,@dnlsh out
print @dnlsh
*/

--select cast('201012031001000025' as bigint)
GO


