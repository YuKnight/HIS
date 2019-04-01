IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_fymx_dj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_fymx_dj
GO
create PROCEDURE SP_YF_fymx_dj  
 ( @djrq VARCHAR(20),  
   @DJSJ VARCHAR(20),  
   @DJY INT,  
   @deptid integer,  
   @endrq varchar(30),  
   @ERR_CODE INTEGER output,  
   @ERR_TEXT VARCHAR(100) output,  
   @jgbm bigint  
 )    
as  
BEGIN  
  
  
  
  
 declare @djid UNIQUEIDENTIFIER ;  
 DECLARE @KSLX CHAR(2);  
 DECLARE @DJH BIGINT ;  
 declare @tpfje decimal(15,3);  
 declare @tlsje decimal(15,3);  
   
declare @t1_ywlx char(3)  
declare @t1_fyrq varchar(30)  
declare @t1_pfje decimal(15,3)  
declare @t1_lsje decimal(15,3)  
declare @t1_jhje decimal(15,3)  

declare @t1_fyrq_time varchar(30)
   
 set @Err_Code=-1;  
 set @Err_Text='aaa';  
   
  
--set @kslx=(select kslx from yp_yjks where deptid=@deptid);  
--if @kslx='药库' then  
--  return;  
--end if ;  
  
   
 --单据明细  
   create TABLE #DJMX  
   (  
       ID INTEGER IDENTITY (1, 1) NOT NULL ,  
	   FYID UNIQUEIDENTIFIER,  
       CJID INT,  
	   YPDW VARCHAR(10),  
	   DWBL INT,  
	   YPSL DECIMAL(15,3),  
	   CFTS INT,  
	   pfj decimal(15,4),  
	   lsj decimal(15,4),  
	   PFJE decimal(15,3),  
	   LSJE decimal(15,3),  
	   TPFJE DECIMAL(15,3),  
	   TLSJE decimal(15,3),  
	   FYRQ VARCHAR(30),  
	   ywlx char(3),  
	   jhj decimal(15,4),  
	   jhje decimal(15,3),
	   fyrq2 datetime,
	   
	   ypph varchar(30), --add by ncq 2014-05-14
	   ypxq char(10),
	   yppch varchar(100),
	   kcid uniqueidentifier,
	   pxxh int
   )  
    
  --添加发药明细  
INSERT INTO #DJMX(FYID,CJID,YPDW,DWBL,YPSL,CFTS,pfj,lsj,PFJE,LSJE,tpfje,tlsje,FYRQ,ywlx,jhj,jhje,fyrq2, 
					ypph,ypxq,yppch,kcid)  
SELECT A.ID,CJID,YPDW,YDWBL,YPSL,B.CFTS,pfj,lsj,PFJE,LSJE,tpfje,tlsje,convert(nvarchar,fyrq,112),A.ywlx,b.jhj,b.jhje,fyrq
					,b.ypph,b.ypxq,b.yppch,b.kcid 
						FROM YF_FY A,YF_FYMX B   
					WHERE A.ID=B.FYID AND A.SCBZ=0 and a.deptid=@deptid and fyrq<=rtrim(@endrq)+' 23:59:59' and KCID<>'00000000-0000-0000-0000-000000000000';  
--select * from #DJMX 
  
declare t1 cursor local for   select ywlx,fyrq,sum(pfje) pfje,sum(lsje) lsje,sum(jhje) jhje from #DJMX group by ywlx,fyrq  
open  t1  
fetch next from t1 into  @t1_ywlx,@t1_fyrq,@t1_pfje,@t1_lsje,@t1_jhje  
while @@FETCH_STATUS=0  
begin  
  
 UPDATE YP_DJH SET DJH=DJH+1 WHERE DEPTID=@DEPTID AND YWLX=@t1_ywlx;  
 SET @DJH=(SELECT DJH FROM yp_djh where DEPTID=@DEPTID AND YWLX=@t1_ywlx);  
 
 set @t1_fyrq_time=(select top 1 convert(nvarchar,fyrq2,108) from #DJMX where FYRQ=@T1_fyrq and ywlx=@t1_ywlx order by fyrq2 desc)
 set @DJID=dbo.FUN_GETGUID(newid(),getdate())  
 insert into YF_dj(id,jgbm,djh,deptid,ywlx,wldw,jsr,rq,djy,djrq,djsj,shbz,shY,shrq,shdh,bz,SUMPFJE,SUMLSJE,sumjhje)  
 values(@DJID,@jgbm,@DJH,@DEPTID,@t1_ywlx,0,0,@t1_fyrq,@djy,@djrq,@djsj,1,@djy,rtrim(cast(@t1_fyrq as char(30)))+' '+ @t1_fyrq_time,'','病人处方发药',@t1_pfje,@t1_lsje,@t1_jhje);--@djrq+' '+@djsj  
 IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL   
 begin  
        SET @Err_Text='DJID为零,请重试';  
        return;  
 end  
   
  
  
 insert into YF_djmx(id,djid,CJID,shh,yppm,ypspm,ypgg,sccj,YPSL,YPDW,NYPDW,YDWBL,jhj,PFJ,LSJ,jhje,PFJE,LSJE,DJH,DEPTID,ywlx,BZ
			 ,ypph,ypxq,yppch,kcid ,PXXH	)  
      select dbo.FUN_GETGUID(newid(),getdate()),@djid,a.cjid,shh,yppm,ypspm,ypgg,s_sccj,sum(ypsl*cfts) ypsl,a.ypdw ,  
      0 nypdw,dwbl ydwbl,a.jhj,a.pfj,a.lsj,sum(jhje),sum(pfje),sum(lsje),@djh,@deptid,@t1_ywlx,'病人处方发药'  
      , (case when ypph is null then '' else ypph end),ypxq,yppch,kcid ,row_number()over( order by a.lsj )
      from #DJMX a,vi_yp_ypcd b   
         where a.cjid=b.cjid  and FYRQ=@T1_fyrq and ywlx=@t1_ywlx  
      group by a.cjid,shh,yppm,ypspm,ypgg,b.s_sccj,a.ypdw,a.dwbl,a.pfj,a.lsj,a.jhj
			,a.ypph,a.ypxq,a.yppch,a.kcid	;  
      
 --更新发药表的单据ID  
 UPDATE YF_FY SET DJID=@DJID,SCBZ=1 where id in(select fyid from #djmx where ywlx=@t1_ywlx and fyrq=@t1_fyrq) and scbz=0;  
 if @@rowcount=0   
    begin  
  SET @Err_Text='上传失败，请您稍后重试，可能别人正在上传';  
  return  
    end   
 --对调价误差作账务调整  
 select @tpfje=sum(tpfje),@tlsje=sum(tlsje) from #djmx where ywlx=@t1_ywlx and  fyrq=@t1_fyrq;  
 set @tpfje=coalesce(@tpfje,0);  
 set @tlsje=coalesce(@tlsje,0);  
 if @tpfje<>0 or @tlsje<>0   
    begin  
		--set @djid=0;  
		UPDATE YP_DJH SET DJH=DJH+1 WHERE DEPTID=@DEPTID AND YWLX='012';  
		   SET @DJH=(SELECT DJH FROM yp_djh where DEPTID=@DEPTID AND YWLX='012');  
	     
		set @DJID=dbo.FUN_GETGUID(newid(),getdate())  
		insert into YF_dj(id,jgbm,djh,deptid,ywlx,
						  wldw,jsr,rq,djy,djrq,
						  djsj,shbz,shY,shrq,shdh,
						  bz,SUMPFJE,SUMLSJE)  
					values(@djid,@jgbm,@DJH,@DEPTID,'012',
						   0,0,@t1_fyrq,@djy,@djrq,
						   @djsj,1,@djy,rtrim(cast(@t1_fyrq as char(30)))+' '+@t1_fyrq_time,'',
						   '处方因调价引起的账务调整',@tpfje,@tlsje);  
		 if @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL   
			 begin  
				SET @Err_Text='DJID为零,请重试';  
				return;  
			end   
	     
	   insert into YF_djmx(id,djid,CJID,shh,yppm,
						   ypspm,ypgg,sccj,YPSL,YPDW,
						   NYPDW,YDWBL,PFJ,LSJ,PFJE,
						   LSJE,DJH,DEPTID,ywlx,BZ,
						   YPPH,YPXQ,yppch,KCID ,PXXH
						    )  
	   select dbo.FUN_GETGUID(newid(),getdate()),@djid,b.cjid,shh,s_yppm,
							s_ypspm,s_ypgg,s_sccj,0,'',
							0,1,0,0,tpfje,
							tlsje,@djh,@deptid,'012','处方因调价引起的账务调整'    
							,(case when ypph is null then '' else ypph end),ypxq,yppch,kcid  ,row_number()over( order by b.cjid )
							from #djmx a inner join yp_ypcjd b on a.cjid=b.cjid
       where (tpfje<>0 or tlsje<>0) AND YWLX=@T1_YWLX AND FYRQ=@T1_FYRQ;  
	end  
  
     fetch next from t1 into  @t1_ywlx,@t1_fyrq,@t1_pfje,@t1_lsje,@t1_jhje  
  end  
   
CLOSE t1  
DEALLOCATE t1  
  
  --上传统领单  
    
   create TABLE #TLD  
   (  
    GROUPID UNIQUEIDENTIFIER ,  
    DJH       BIGINT    ,  
    DEPTID    INTEGER      ,  
    FYRQ      DATETIME,  
    FYR       INTEGER       ,  
    dept_ly   int    ,  
    NURSEID   INTEGER       ,  
    PYR       INTEGER       ,  
    BZ        VARCHAR(100),  
    DJID      UNIQUEIDENTIFIER    ,  
    YJID      UNIQUEIDENTIFIER       ,  
    SUMPFJE      DECIMAL(18,2)  ,  
    SUMLSJE      DECIMAL(18,2)  ,  
    STYPE VARCHAR(20),  
    YWLX CHAR(3)  ,
    sumjhje decimal(18,2) --进货金额
  )   
   
declare @t2_groupid UNIQUEIDENTIFIER  
declare @t2_fyrq datetime  
declare @t2_fyr int  
declare @t2_dept_ly  int  
declare @t2_sumpfje decimal(15,2)  
declare @t2_sumlsje decimal(15,2)  
declare @t2_sumjhje decimal(15,2) 
declare @t2_ywlx char(3)  
  
INSERT INTO #TLD(GROUPID,DJH,DEPTID,FYRQ,FYR,
				dept_ly,NURSEID,PYR,BZ,DJID,
				YJID,SUMPFJE,SUMLSJE,STYPE,YWLX
			    ,sumjhje)  
			 SELECT GROUPID,DJH,DEPTID,FYRQ,FYR,
			    dept_ly,NURSEID,PYR,BZ,DJID,
			    YJID,SUMPFJE,SUMLSJE,STYPE,YWLX,
			    sumjhje FROM YF_TLD   
WHERE FYRQ<=rtrim(@ENDRQ)+' 23:59:59'  and scbz=0 AND DEPTID=@DEPTID;  
  
declare t2 cursor local for  select groupid,fyrq,fyr,dept_ly,sumpfje,sumlsje,ywlx,sumjhje from  #TLD  
open  t2  
  
fetch next from t2 into  @t2_groupid,@t2_fyrq,@t2_fyr,@t2_dept_ly,@t2_sumpfje,@t2_sumlsje,@t2_ywlx,@t2_sumjhje   
  
while @@FETCH_STATUS=0  
begin  
    UPDATE YP_DJH SET DJH=DJH+1 WHERE DEPTID=@DEPTID AND YWLX=@t2_ywlx;   --更新单据号计数器
    SET @DJH=(SELECT DJH FROM yp_djh where DEPTID=@DEPTID AND YWLX=@t2_ywlx);  
      
    set @DJID=dbo.FUN_GETGUID(newid(),getdate())   
    --插入单据头表
    insert into YF_dj(id,jgbm,djh,deptid,ywlx,
					wldw,jsr,rq,djy,djrq,
					djsj,shbz,shY,shrq,shdh,
					bz,SUMPFJE,SUMLSJE
					,sumjhje)  
				values(@djid,@jgbm,@DJH,@DEPTID,@t2_ywlx,
						0,0,dbo.Fun_GetDate(@t2_fyrq),@t2_fyr,dbo.Fun_GetDate(@t2_fyrq),
						Convert(nvarchar,@t2_fyrq,108),1,@t2_fyr,@t2_fyrq,'',
						'病人处方统领发药',@t2_SUMPFJE,@t2_sumlsje,
						@t2_sumjhje);--@djrq+' '+@djsj  
    IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL   
           begin  
				SET @Err_Text='DJID为零,请重试';  
		   return;  
    END   
    --插入单据明细表
    insert into YF_djmx(id,djid,CJID,shh,yppm,
						ypspm,ypgg,sccj,YPSL,YPDW,
						NYPDW,YDWBL,jhj,PFJ,LSJ,
						jhje,PFJE,LSJE,DJH,DEPTID,
						ywlx,BZ 
						,ypph,ypxq,yppch,kcid ,PXXH)  
	select dbo.FUN_GETGUID(newid(),getdate()),@djid,cjid,shh,yppm,
						ypspm,ypgg,sccj,ypsl,ypdw , 
					    0 nypdw,ydwbl,jhj,pfj,lsj,
					    jhje,pfje,lsje,@djh,@deptid,
					    @T2_YWLX,'病人处方统领发药'  
						,ypph,ypxq,yppch,kcid ,row_number()over( order by lsj )
     from yf_tldmx   
     where GROUPid=@t2_GROUPID  ;  
  
     --更新发药表的单据ID    
     UPDATE YF_TLD SET DJID=@DJID,SCBZ=1 where GROUPID =@T2_GROUPID and scbz=0;  
	 if @@rowcount=0   
        begin  
			SET @Err_Text='上传失败，请您稍后重试，可能别人正在上传';  
			return  
        end   
  
  --对调价误差作账务调整  
  select @tpfje=sum(tpfje),@tlsje=sum(tlsje) from #TLD A,YF_TLDMX B  where A.GROUPID=B.GROUPID AND A.GROUPID=@T2_GROUPID;  
  set @tpfje=coalesce(@tpfje,0);  
  set @tlsje=coalesce(@tlsje,0);  
  if @tpfje<>0 or @tlsje<>0   
  begin  
         --set @djid=0;  
         UPDATE YP_DJH SET DJH=DJH+1 WHERE DEPTID=@DEPTID AND YWLX='012';  
            SET @DJH=(SELECT DJH FROM yp_djh where DEPTID=@DEPTID AND YWLX='012');  
    
         set @DJID=dbo.FUN_GETGUID(newid(),getdate())  
         insert into YF_dj(id,jgbm,djh,deptid,ywlx,
						  wldw,jsr,rq,djy,djrq,
						  djsj,shbz,shY,shrq,shdh,
						  bz,SUMPFJE,SUMLSJE)  
					values(@djid,@jgbm,@DJH,@DEPTID,'012',
							0,0,@djrq,@djy,@djrq,
							@djsj,1,@djy,@t2_fyrq,
							'','处方因调价引起的账务调整',@tpfje,@tlsje);  
         IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL   
         begin  
                SET @Err_Text='DJID为零,请重试';  
                return;  
         END  
     
        insert into YF_djmx(id,djid,CJID,shh,yppm,
							ypspm,ypgg,sccj,YPSL,YPDW,
							NYPDW,YDWBL,PFJ,LSJ,PFJE,
							LSJE,DJH,DEPTID,ywlx,BZ
							,ypph,ypxq,yppch,kcid,JHJ ,PXXH)  
        select dbo.FUN_GETGUID(newid(),getdate()),@djid,b.cjid,shh,s_yppm,
					s_ypspm,s_ypgg,s_sccj,0,'',
					0,1,0,0,tpfje,
					tlsje,@djh,@deptid,'012','处方因调价引起的账务调整'   
					,ypph,ypxq,yppch,kcid,jhj,row_number()over( order by b.cjid ) 
		from #djmx a inner join yp_ypcjd b on a.cjid=b.cjid 
		where (tpfje<>0 or tlsje<>0)  AND YWLX=@T2_YWLX AND FYRQ=@T2_FYRQ;  
  end  
 fetch next from t2 into  @t2_groupid,@t2_fyrq,@t2_fyr,@t2_dept_ly,@t2_sumpfje,@t2_sumlsje,@t2_ywlx,@t2_sumjhje    
 end  
   
CLOSE T2  
DEALLOCATE T2   
   
 set @Err_Code=0;  
 set @Err_Text='上传成功';  
 END;  
   
   