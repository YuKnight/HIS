if exists ( select 1 from sys.objects where name ='SP_YP_TJ_YPMXFLZ' and type='P')
	drop procedure SP_YP_TJ_YPMXFLZ
go


--药库明细分类账  
/*  
 declare @deptid int
 declare @yk int
 declare @jhjetj int --(1-进价 2-批发价 3-零售价  
 declare @year int  
 declare @month int  
 declare @cjid int   
 declare @errcode int
 declare @errtext varchar(200)
 
 set @deptid = 94
 set @yk = 1
 set @jhjetj = 1  
 set @year = 2014  
 set @month = 7  
 set @cjid = 1262  
 exec SP_YP_TJ_YPMXFLZ @deptid,@yk,@jhjetj,@year,@month,@cjid ,@errcode out ,@errtext out
*/  
create procedure SP_YP_TJ_YPMXFLZ(  
@deptid		int,   --科室id
@yk			int,   --药房药库标志 0：药房 1：药库
@jhjetj		int,   --进价统计标志 0：否(按零售价) 1：是
@year		int,   --统计年份  
@month		int,   --统计月份  
@cjid		int ,  --药品ID 
@ERR_CODE	INTEGER output,
@ERR_TEXT	VARCHAR(250) output
)  
as  
begin  
	create table #account(rowno int identity(1,1), [year] int,[month] int ,[day] int , summary varchar(200),  
							debit_amount decimal(18,2),debit_price decimal(18,2),debit_money decimal(18,2),  
							credit_amount decimal(18,2),credit_price decimal(18,2),credit_money decimal(18,2),  
							balance_amount decimal(18,2),balance_price decimal(18,2),balance_money decimal(18,2) , rowflag int )  
	
	create table #list ([year] int ,[month] int, ywlx varchar(10), ywlxmc varchar(20), tjlx varchar(10), ypsl decimal(18,2),ypdw varchar(max),ydwbl int,jhj decimal(18,2),jhje decimal(18,2), lsj decimal(18,2),lsje decimal(18,2),pfj decimal(18,2),pfje decimal(18,2) )
	
	create table #ywlx (ywlx varchar(10),ywmc varchar(20),tjlx varchar(20),YK  int)		
	
	declare @start_month int  --起始月
	declare @end_month int    --截止月
	declare @day int
	declare @count int 
	
	declare @balance_amount decimal(18,2)
	declare @balance_price decimal(18,2)
	declare @balance_money decimal(18,2)
	
	declare @amountA decimal(18,2)
	declare @moneyA decimal(18,2)
	declare @priceA decimal(18,2)
	declare @amountB decimal(18,2)
	declare @moneyB decimal(18,2)
	declare @priceB decimal(18,2)
	declare @rowno int
	
	insert into #ywlx(ywlx,ywmc,tjlx,YK) select YWLX,YWMC,TJLX , 1 as YK from YK_YWLX union all select YWLX,YWMC,TJLX , 0 as YK from YF_YWLX
	
	set @start_month = @month
    set @end_month = @month
	if @month = 0 
	begin
		set @start_month = 1  --起始月份设置为1
		--获取截止月
		select @end_month=max(kjyf) from YP_KJQJ where KJNF =@year and DEPTID=@deptid
	end
	set @count = 0
	 
	set @balance_amount = 0	
	set @balance_money = 0
	
	while(@start_month<=@end_month)
	begin
		truncate table #list
		--计算月末天数
		declare @tempRq datetime
		set @tempRq = CONVERT(datetime,  convert(varchar(max),@year) +'-' +CONVERT(varchar(max),@start_month) + '-01')
		set @tempRq = DATEADD(DAY,-1,  DATEADD(MONTH,1,@tempRq))
		set @day = DAY(@tempRq)
		
		insert into #list
		select b.KJNF,b.KJYF, a.YWLX,c.ywmc, c.tjlx, a.YPSL,a.YPDW,a.YDWBL,a.JHJ,a.JHJE,a.LSJ,a.LSJE,a.PFJ,a.PFJE
		from YP_TJ_YMJCMX a
		left join YP_KJQJ b on a.YJID = b.ID and a.DEPTID = b.DEPTID
		left join ( select * from #ywlx where YK=@yk ) c on a.YWLX = c.ywlx
		where b.KJNF = @year and b.KJYF=@start_month and a.DEPTID=@deptid and a.CJID = @cjid 
		
		--上期结余
		if @count= 0
		begin
			insert into #account([year],[month],[day],summary,balance_amount,balance_price,balance_money ,rowflag)  
			select @year,@start_month,1,'上年转结', ypsl ,(case when ypsl = 0 then 0 else ypdj end),ypje , 0
			from
			(
				select sum(ypsl) as ypsl,(case when @jhjetj=1 then jhj else lsj end) as ypdj,sum(case when @jhjetj=1 then jhje else lsje end) as ypje
				from #list where ywlx='000' and ypsl<>0 group by (case when @jhjetj=1 then jhj else lsj end)
			) a		
			if @@ROWCOUNT = 0
				insert into #account([year],[month],[day],summary,rowflag) values (@year,@month,1,'上年转结',0)
			select @balance_amount=isnull(sum(isnull(balance_amount,0)),0),@balance_money=isnull(SUM(isnull(balance_money,0)),0) from #account where rowflag = 0 --计算结余
		end
		--本期 
		--购入(借方)
		insert into #account([year],[month],[day],summary,debit_amount ,debit_price ,debit_money , rowflag )
		select @year,@start_month,@day,'购入', ypsl,(case when ypsl = 0 then 0 else dj end),je , 1
		from
		(
			select SUM(ypsl) as ypsl, (case when @jhjetj=1 then jhj else lsj end) as dj, SUM(case when @jhjetj=1 then jhje else lsje end)  as je
			from #list where ywlx in ('001','002') 
			group by (case when @jhjetj=1 then jhj else lsj end)
		 )a
		 if @@ROWCOUNT = 0
			insert into #account([year],[month],[day],summary,balance_amount,balance_money) values( @year,@start_month,@day, '购入',@balance_amount,@balance_money)	
		 else
		 begin
			declare t0 cursor for select rowno,debit_amount,debit_money,debit_price from #account where [year]=@year and [month]=@start_month and rowflag=1
			open t0
			fetch next from t0 into @rowno,@amountA, @moneyA ,@priceA
			while @@FETCH_STATUS=0
			begin
				set @balance_amount = @balance_amount + isnull(@amountA,0)  
				set @balance_money = @balance_money + isnull(@moneyA,0) 
				update #account set balance_amount=@balance_amount,balance_price=@priceA, balance_money = @balance_money where rowno = @rowno
				fetch next from t0 into @rowno,@amountA, @moneyA ,@priceA
			end
			close t0
			deallocate t0
		end	
		
		--发出
		insert into #account([year],[month],[day],summary,credit_amount,credit_price,credit_money ,rowflag )
		select @year,@start_month,@day,'发出', ypsl , dj ,je, 2
		from
		(
			select sum(case when tjlx='本期增加' then ypsl * (-1) else ypsl end) as ypsl ,dj,sum(case when tjlx='本期增加' then je *(-1) else je end) as je			      
			from
			(
				select tjlx,ypsl,(case when @jhjetj=1 then jhj else lsj end) as dj,(case when @jhjetj=1 then jhje else lsje end) as je
				from #list where ywlx not in ('001','002') and tjlx in ('本期增加','本期减少')
						
			) a group by tjlx,dj 
		) b
		if @@ROWCOUNT = 0
			insert into #account([year],[month],[day],summary,balance_amount,balance_money) values( @year,@start_month,@day ,'发出',@balance_amount,@balance_money)
		else
		begin
			declare t1 cursor for select rowno, credit_amount, credit_price, credit_money from #account where [year]=@year and [month]=@start_month and rowflag=2
			open t1
			fetch next from t1 into @rowno,@amountA,@priceA,@moneyA 
			while @@FETCH_STATUS=0
			begin
				set @balance_amount = @balance_amount - isnull(@amountA,0)  
				set @balance_money = @balance_money - isnull(@moneyA,0)  
				update #account set balance_amount=@balance_amount,balance_price=@priceA, balance_money = @balance_money where rowno = @rowno
				fetch next from t1 into @rowno,@amountA,@priceA,@moneyA 
			end
			close t1
			deallocate t1
		end	
			
		--其他
		insert into #account([year],[month],[day],summary,debit_amount,debit_price,debit_money,   credit_amount,credit_price,credit_money , rowflag )
		select @year,@start_month,@day,'其他', sum(case when sl > 0 then sl else 0 end),dj,sum(case when sl> 0 then je else 0 end),
										 sum(case when sl< 0 then sl else 0 end),dj,sum(case when sl<0 then je else 0 end), 3
		from ( 
				select SUM(ypsl) as sl ,(case when @jhjetj=1 then jhj else lsj end) as dj ,
						sum(case when @jhjetj=1  then jhje else lsje end) as je
				from #list where ywlx not in ('001','002','005') and tjlx = '本期其他'
				group by (case when @jhjetj=1 then jhj else lsj end)		
		) a group by dj having sum(case when sl > 0 then sl else null end)<> 0 or sum(case when sl< 0 then sl else null end)<>0
		
		--调价
		insert into #account([year],[month],[day],summary,debit_money, credit_money ,rowflag )
		select @year,@start_month,@day,'调价',(case when tjje> 0 then tjje else null end),(case when tjje<0 then (tjje *-1) else null end)  ,4
		from
		(
			select sum(case when @jhjetj=1  then jhje else lsje end) as tjje from #list where ywlx in ('005') and tjlx='本期其他'
			group by (case when @jhjetj=1 then jhj else lsj end)
		) tj
			
		--本月合计
		insert into #account(summary,debit_amount,debit_money , credit_amount,credit_money , rowflag)
		select '本月合计', sum(debit_amount),sum(debit_money) , sum(credit_amount),sum(credit_money) , 5
		from #account where rowflag in (1,2) and [year]=@year and [month]=@start_month
			
		--本年累计
		insert into #account( summary,debit_amount,debit_money , credit_amount,credit_money , balance_amount,balance_money, rowflag)
		select  '本年累计', sum(debit_amount),sum(debit_money) , sum(credit_amount),sum(credit_money) ,@balance_amount,@balance_money, 6
		from #account where rowflag in (1,2)  
		
		set @start_month = @start_month + 1
		set @count = @count + 1
		
	end
	alter table #account drop column rowno
	select * from #account
end  



  
  


