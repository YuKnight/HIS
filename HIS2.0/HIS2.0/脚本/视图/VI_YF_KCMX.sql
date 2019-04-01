IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'VI_YF_KCMX' 
	   AND 	  type = 'V')
  drop view VI_YF_KCMX
go 
create VIEW VI_YF_KCMX
 (
  GGID,YPLX,YPZLX,GJBM,YPPM,YPSPM,YPSPMBZ,YPDW,YLFL,YPJX,HLXS,HLDW,BZSL,BZDW,SYXL,YPGG,
ZZBZ,BZ_GG,BDELETE_GG,HSITEMID,STATITEM_CODE,SYFF,DJSJ_GG,CFJB,spym,ypywm,cjid,SHH,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw,n_yplx,n_ypzlx,s_ypjx,TXM,SCCJ,ZBJ,PFJ,ZGLSJ,LSJ,PZWH,
YXQ,YBLX,ZFBL,MRKL,MRJJ,BDELETE_CJ,DJYP,MZYP,PSYP,JSYP,GZYP,CFYP,
WYYP,rsyp,ZBZT,ZBDW,ZBQH,BZ_CJ,LYFS,DJSJ_CJ,KCL,ZXDW,DWBL,DJSJ_KC,BDELETE_KC,DEPTID,
SCJJ,SCKL,GHDW,CFWZ,kslx2,tlfl,zt,xnkcl,kssdjid,CGLSH ,jsypfl,mrghdw
 )
  AS select a.GGID,YPLX,YPZLX,GJBM,YPPM,YPSPM,YPSPMBZ,YPDW,YLFL,YPJX,HLXS,HLDW,BZSL,BZDW,SYXL,YPGG,
ZZBZ,a.bz BZ_GG,a.bdelete BDELETE_GG,HSITEMID,STATITEM_CODE,SYFF,A.DJSJ,CFJB,pym,ypywm,b.cjid,SHH,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw,n_yplx,n_ypzlx,s_ypjx,TXM,SCCJ,ZBJ,PFJ,ZGLSJ,LSJ,PZWH,
YXQ,YBLX,ZFBL,MRKL,MRJJ,b.bdelete BDELETE_CJ,DJYP,MZYP,PSYP,JSYP,GZYP,CFYP
,WYYP,rsyp,ZBZT,ZBDW,ZBQH,b.bz BZ_CJ,LYFS,B.DJSJ,KCL,ZXDW,DWBL,C.DJSJ,c.bdelete BDELETE_KC,c.DEPTID,
SCJJ,SCKL,GHDW,CFWZ, kslx2,tlfl,zt,xnkcl,kssdjid,CGLSH ,jsypfl,mrghdw from 
yp_ypggd a,yp_ypcjd b ,yf_kcmx c ,yp_yjks d 
where a.ggid=b.ggid and b.cjid=c.cjid and c.deptid=d.deptid

