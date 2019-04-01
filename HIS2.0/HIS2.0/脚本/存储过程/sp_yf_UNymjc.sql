if exists(select 1 from sysobjects where name = 'sp_yf_UNymjc' and type = 'P')
	drop procedure sp_yf_UNymjc
go	


CREATE PROCEDURE sp_yf_UNymjc   
(  
 @deptid integer,  
 @DJSJ VARCHAR(30),  
 @DJY INTEGER,  
 @ERR_CODE INTEGER output ,  
        @ERR_TEXT VARCHAR(100) output  
)  
as  
  
begin  
 declare @yjid UNIQUEIDENTIFIER   
 declare @bbk smallint  
   
 set @yjid=null;  
  
 set @ERR_CODE=-1;  
 set @ERR_TEXT='';  
   
  --取得最后一次月结的ID  
 select TOP 1 @yjid=id,@bbk=bbk from yp_kjqj where deptid=@deptid  order by djsj desc   
 --set @yjid=coalesce(@yjid,0)  
 if @yjid is null  
  set @yjid=dbo.FUN_GETEMPTYGUID()  
 set @bbk=coalesce(@bbk,0)  
  
 if @yjid=dbo.FUN_GETGUID(newid(),getdate()) or @yjid is null  
 BEGIN  
    SET @ERR_TEXT='你的操作错误,因为系统还没进行过月结';  
    return;  
 END  
   
 if @bbk=1   
  BEGIN  
    SET @ERR_TEXT='帐务数据已被转入历史记录表中,不能取消';  
    return;  
 END         
   
/*  
 insert into yf_dj( DJH, DEPTID, YWLX, WLDW, JSR, RQ, DJY, DJRQ, DJSJ, SHBZ, SHY, SHRQ, YJID, FPH, FPRQ, BZ, SHDH, YYDM, SQDH, FKZT, BPRINT, SUMJHJE, SUMPFJE, SUMLSJE)  
 select DJH, DEPTID, YWLX, WLDW, JSR, RQ, DJY, DJRQ, DJSJ, SHBZ, SHY, SHRQ, YJID, FPH, FPRQ, BZ, SHDH, YYDM, SQDH, FKZT, BPRINT, SUMJHJE, SUMPFJE, SUMLSJE  
 from yf_dj_H where yjid=@yjid and deptid=@deptid  
  
 insert into yf_djmx(DJID, CJID, KWID, SHH, YPPM, YPSPM, YPGG, SCCJ, YPPH, YPXQ, YPKL, SQSL, YPSL, YPDW, NYPDW, YDWBL, JHJ, PFJ, LSJ, JHJE, PFJE, LSJE, DJH, DEPTID, YWLX, BZ, SHDH)   
 select B.DJID,B.CJID,B.KWID,B.SHH,B.YPPM,B.YPSPM,B.YPGG,B.SCCJ,B.YPPH,B.YPXQ,B.YPKL,B.SQSL,B.YPSL,B.YPDW,B.NYPDW,B.YDWBL,B.JHJ,B.PFJ,B.LSJ,B.JHJE,B.PFJE,B.LSJE,B.DJH,B.DEPTID,B.YWLX,B.BZ,B.SHDH  
 from yf_dj_H a,yf_djmx_H b where a.id=b.djid and a.yjid=@yjid and a.deptid=@deptid  
   
   
 delete from yf_djmx_H where djid in(select id from yf_dj_H where yjid=@yjid and deptid=@deptid)  
 delete from yf_dj_H where yjid=@yjid AND DEPTID=@DEPTID  
*/  
 --更新单据信息  
 update yf_dj set yjid=null where deptid=@deptid and yjid=@yjid  ;   
 update yf_fy set yjid=null where deptid=@deptid and yjid=@yjid;   
 update yf_tld set yjid=null where deptid=@deptid and yjid=@yjid;   
 delete from yf_ymjc where deptid=@deptid and yjid=@yjid;   
   
 --删除月结记录  
 delete from yp_kjqj where deptid=@deptid and id=@yjid;  
 
 --删除中间表数据
 if exists(select 1 from sysobjects where name = 'YP_TJ_YMJCMX' and type = 'U')
 begin
	delete from YP_TJ_YMJCMX where YJID = @yjid
 end  
   
 set @ERR_CODE=0;  
 set @ERR_TEXT='上次月结已被取消';  
end   
  
  