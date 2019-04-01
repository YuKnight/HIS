IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_YP_YPCD]'))
DROP VIEW [dbo].[VI_YP_YPCD]
GO
create view [dbo].[VI_YP_YPCD] as  
select  
  a.[GGID], [YPLX], [YPZLX], [GJBM], [YPPM], [YPSPM], [YPSPMBZ], [YPDW],   
[YLFL], [YPJX], [HLXS], [HLDW], [BZSL], [BZDW], [SYXL], [YPGG], [ZZBZ], a.[BZ],   
a.[BDELETE], [HSITEMID], [STATITEM_CODE], [SYFF], a.[DJSJ], [CFJB], [DJYP], [MZYP],  
 [PSYP], [JSYP], [GZYP], [CFYP], [WyYP],[RSYP], [LYFS], [PYM], [WBM], [TLFL],[HWJXBM],
[HHJSQ],[YPYWM],[XGSJ],[XGR],  
b.cjid,shh,s_yppm,s_ypspm,s_ypgg,s_sccj,s_ypdw,n_yplx,n_ypzlx,s_ypjx,txm,sccj,  
zbj,pfj,zglsj,lsj,pzwh,yxq,yblx,zfbl,mrkl,mrjj,b.bdelete cjbdelete,zbzt,zbqh,b.bz cjbz,b.djsj cjdjsj ,
zt,ddd,kssdjid,gjjbyw ,CGLSH ,gwyp,jsypfl,mrghdw,
DDDJL,DDDJLDW 
,isnull( DDDJL,[HLXS]) HLXS_DDDJL,JBYWLX
from  
   yp_ypggd a(nolock),yp_ypcjd b(nolock) where a.ggid=b.ggid  
  
GO


