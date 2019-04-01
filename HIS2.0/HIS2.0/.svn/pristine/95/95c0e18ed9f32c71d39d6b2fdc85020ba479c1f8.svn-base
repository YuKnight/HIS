--八医院请单独修改
IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YP_KCMX' 
	   AND 	  type = 'V')
  drop view VI_YP_KCMX
go 
CREATE VIEW VI_YP_KCMX  
 (  
  GGID,YPLX,YPZLX,GJBM,YPPM,YPSPM,YPSPMBZ,YPDW,YLFL,YPJX,HLXS,HLDW,BZSL,BZDW,SYXL,YPGG,  
ZZBZ,BZ_GG,BDELETE_GG,HSITEMID,STATITEM_CODE,SYFF,DJSJ_GG,CFJB,spym,ypywm,cjid,SHH,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw,n_yplx,n_ypzlx,s_ypjx,TXM,SCCJ,ZBJ,PFJ,ZGLSJ,LSJ,PZWH,  
YXQ,YBLX,ZFBL,MRKL,MRJJ,BDELETE_CJ,DJYP,MZYP,PSYP,JSYP,GZYP,  
WYYP,rsyp,ZBZT,ZBDW,ZBQH,BZ_CJ,LYFS,DJSJ_CJ,KCL,ZXDW,DWBL,DJSJ_KC,BDELETE_KC,  
DEPTID,SCJJ,SCKL,GHDW,CFWZ,kslx2,tlfl,zt,jgbm ,CGLSH ,gwyp
 )  
  AS  select a.GGID,YPLX,YPZLX,GJBM,YPPM,YPSPM,YPSPMBZ,YPDW,YLFL,YPJX,HLXS,HLDW,BZSL,BZDW,SYXL,YPGG,  
ZZBZ,a.bz BZ_GG,a.bdelete BDELETE_GG,HSITEMID,STATITEM_CODE,SYFF,A.DJSJ,CFJB,pym,ypywm,b.cjid,SHH,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw,n_yplx,n_ypzlx,s_ypjx,TXM,SCCJ,ZBJ,PFJ,ZGLSJ,LSJ,PZWH,  
YXQ,YBLX,ZFBL,MRKL,MRJJ,b.bdelete BDELETE_CJ,DJYP,MZYP,PSYP,JSYP,GZYP  
,WYYP,rsyp,ZBZT,ZBDW,ZBQH,b.bz BZ_CJ,LYFS,B.DJSJ,KCL,ZXDW,DWBL,C.DJSJ,  
c.bdelete BDELETE_KC,DEPTID,SCJJ,SCKL,GHDW,CFWZ,'' kslx2,tlfl,zt,c.jgbm,CGLSH,GWYP  from   
yp_ypggd a,yp_ypcjd b ,yK_kcmx c  ,
jc_dept_property d  
where a.ggid=b.ggid and b.cjid=c.cjid  and c.deptid=d.dept_id
union all 
select a.GGID,YPLX,YPZLX,GJBM,YPPM,YPSPM,YPSPMBZ,YPDW,YLFL,YPJX,HLXS,HLDW,BZSL,BZDW,SYXL,YPGG,  
ZZBZ,a.bz BZ_GG,a.bdelete BDELETE_GG,HSITEMID,STATITEM_CODE,SYFF,A.DJSJ,CFJB,pym,ypywm,b.cjid,SHH,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw,n_yplx,n_ypzlx,s_ypjx,TXM,SCCJ,ZBJ,PFJ,ZGLSJ,LSJ,PZWH,  
YXQ,YBLX,ZFBL,MRKL,MRJJ,b.bdelete BDELETE_CJ,DJYP,MZYP,PSYP,JSYP,GZYP  
,WYYP,rsyp,ZBZT,ZBDW,ZBQH,b.bz BZ_CJ,LYFS,B.DJSJ,KCL,ZXDW,DWBL,C.DJSJ,  
c.bdelete BDELETE_KC,DEPTID,SCJJ,SCKL,GHDW,CFWZ,'' kslx2,tlfl,zt,c.jgbm,CGLSH,GWYP  from   
yp_ypggd a,yp_ypcjd b ,yf_kcmx c  ,
jc_dept_property d  
where a.ggid=b.ggid and b.cjid=c.cjid  and c.deptid=d.dept_id