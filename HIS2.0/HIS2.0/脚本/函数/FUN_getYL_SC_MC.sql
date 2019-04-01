
if exists (select 1 from dbo.sysobjects where type='FN' and name ='FUN_getYL_SC_MC')
	drop function FUN_getYL_SC_MC
go
create FUNCTION dbo.FUN_getYL_SC_MC
(@str varchar(200),
@first_end int,  --1 是首次执行，2 是末次执行，0 未普通执行
@execNum int  --当@first_end=1 或者@first_end=2时的  执行次数
)RETURNS varchar(200)
as
begin
declare @retValue varchar(200)
DECLARE @pos int  --临时变量 位置 
DECLARE @i int  --临时变量 计数
declare @str_len int--字符出现的总次数
declare @str_sumLen int
--set @str='9:00/16:00/18:00/21:00'
--set @first_end=1
--set @execNum=3
select @str_len= len(@str)-len(replace(@str, '/', ''))+1
set @str_sumLen=@str_len
set @retValue=''
set @i=1
if(@first_end=1 or @first_end=2 )
begin
	while @str_len>0
		begin
			SET @pos = charindex('/', @str);
			if(@pos>=0)
			begin
				if((@first_end=1 and @i>@str_sumLen-@execNum)or(@first_end=2 and @i<=@execNum))
				begin
					set @retValue = @retValue+LEFT(@str, @pos)	
					if(@pos=0)
					begin
						set @retValue=@retValue+@str;
					end					
				end
			end				
			set @str = SUBSTRING(@str,@pos+1,len(@str))--STUFF(@str, 1, @pos, '') 
			
			--select @pos,@str
			set @i=@i+1
			set @str_len=@str_len-1; 			
		end
end
--select SUBSTRING(@retValue,LEN(@retValue),1)
if(SUBSTRING(@retValue,LEN(@retValue),1)='/')
	set @retValue=STUFF(@retValue, LEN(@retValue), 1, '')
return rtrim(@retValue) 
end


--select dbo.FUN_getYL_SC_MC('9:00/16:00/18:00/21:00',1,4)