IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_zyhs_tlxxsc_auto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_zyhs_tlxxsc_auto]
GO
create proc [dbo].[sp_zyhs_tlxxsc_auto]
 
as  
/*
创建一个新的自动生成，主要是扫描没有被生成的统领信息，将其生成
这个和sp_zyhs_tlxxsc的区别是，sp_zyhs_tlxxsc里面用charge_user作为统领人
是老系统过来的数据才有
但是新系统产生的肯定没有charge_user，这里用book_user代替
这个频率不宜太高
Modify By Tany 2015-10-08
*/
declare @by_ypjx varchar(500)
declare @by_ypyf varchar(500)

select @by_ypjx=YPJX,@by_ypyf=YPYF from JC_YPLYFLK where BYBZ=1
set @by_ypjx=','+@by_ypjx+','
set @by_ypyf=','+@by_ypyf+','
 --先查询需要产生消息的统领消息的药品
--select top 20 a.dept_ly,a.execdept_id , apply_id,a.ID,
--(case when charindex(( ','+cast(YPJX as varchar(20))+','),@by_ypjx)>0 and  charindex((','+cast(d.id as varchar(20))+','),@by_ypyf)>0 then 1
--else  0  end  ) Bybz,--摆药标志
--case when ACVALUE>0 then 0 else 1 end tybz --退药标志

---- into #ZY_FEE_SPECI_TL 
--from ZY_FEE_SPECI  a(NOLOCK)   --join ZY_YPTL b on A.ID=b.FEEID AND A.XMLY=1 
--      left join  zy_orderrecord c(NOLOCK)   on a.order_id=c.order_id
--      LEFT JOIN JC_USAGEDICTION d ON c.ORDER_USAGE=d.NAME
--      join vi_yp_ypcd e(NOLOCK)   on a.XMID=e.CJID  --AND b.EXECDEPT_ID=e.DEPTID
-- where a.TLFS in(0,2) and a.delete_bit=0
--and (apply_id is null or apply_id=dbo.FUN_GETEMPTYGUID()) and a.FY_BIT=0 order by a.DEPT_LY,a.EXECDEPT_ID



select top 5000 DEPT_LY,EXECDEPT_ID,APPLY_ID,a.ID,  
(case when 
charindex(( ','+cast(YPJX as varchar(20))+','),@by_ypjx)>0 and 
 charindex((','+cast(usageid as varchar(20))+','),@by_ypyf)>0 
 and (STATITEM_CODE<>'02' or XMID in(2102,1895,1836)) and UNIT<>'盒' and UNIT<>'瓶' and  UNIT<>'袋'
  and XMID not in ('6849','5042','4288','4825' ,'4778','6869','7013','4900','6591','4719','415','6523','2804','2217','33','379','4296','312','1420','6966','6561','435','4946','4957','7011') 
 then 1  else  0  end  ) Bybz ,tybz   ,CHARGE_USER
into #ZY_FEE_SPECI_TL    
from  
(  
 select isnull(CHARGE_USER,BOOK_USER) CHARGE_USER,UNIT,STATITEM_CODE, order_id,xmid,DEPT_LY,EXECDEPT_ID,APPLY_ID,ID ,(case when ACVALUE>0 then 0 else 1 end) as tybz ,(select top 1 YPJX from VI_YP_YPCD where cjid = ZY_FEE_SPECI.XMID   ) as YPJX  
 from ZY_FEE_SPECI   
 where XMLY=1 and (APPLY_ID is null or APPLY_ID=dbo.FUN_GETEMPTYGUID())  and FY_BIT=0  and DELETE_BIT=0
 ) a    
 inner join (select FEEID,TLFS,FY_BIT from ZY_YPTL where  TLFS in (0,2) and FY_BIT = 0 and DELETE_BIT=0) b on a.ID = b.FEEID   
 left join  (select a.ORDER_ID,b.NAME,b.ID as usageid from zy_orderrecord a left join JC_USAGEDICTION b on a.ORDER_USAGE=b.NAME) c 
 on a.ORDER_ID = c.ORDER_ID  
order by a.DEPT_LY,a.EXECDEPT_ID
      
 
declare @Bybz int
declare @tybz int
declare @deptly int
declare @exec_dept int
declare @apply_id UNIQUEIDENTIFIER
declare @charge_user int

 DECLARE Cursor_tl CURSOR FOR 
select Bybz,tybz,dept_ly,execdept_id,charge_user from #ZY_FEE_SPECI_TL  group by Bybz,tybz,dept_ly ,EXECDEPT_ID,charge_user
 open Cursor_tl
   FETCH NEXT FROM Cursor_tl into  @Bybz,@tybz, @deptly,@exec_dept,@charge_user
   WHILE @@FETCH_STATUS = 0  
     begin
     BEGIN   try
		--begin  tran
			set @apply_id=newid()
			insert into dbo.ZY_APPLY_DRUG( APPLY_ID, APPLY_DATE, APPLY_NURSE, EXECDEPT_ID, GROUP_ID, DELETE_BIT, MSG_TYPE, LYFLCODE, MEMO, JGBM, DEPT_LY)
			values (@apply_id,getdate(),@charge_user, @exec_dept,null,0,@tybz ,case when @Bybz=1 then '01' else '02' end,'',1000,@deptly)
			update #ZY_FEE_SPECI_TL  set APPLY_ID=@apply_id where DEPT_LY=@deptly
			  and EXECDEPT_ID=@exec_dept and bybz=@Bybz and tybz=@tybz
			  update a set a.apply_id=b.apply_id from  ZY_FEE_SPECI a inner join #ZY_FEE_SPECI_TL b on a.ID=b.id
        --commit tran
      END  try
  begin catch  
			--rollback tran  
	  end catch  
         FETCH NEXT FROM Cursor_tl into  @Bybz,@tybz, @deptly,@exec_dept,@charge_user
     end
  CLOSE Cursor_tl  
  DEALLOCATE Cursor_tl   

 
GO


