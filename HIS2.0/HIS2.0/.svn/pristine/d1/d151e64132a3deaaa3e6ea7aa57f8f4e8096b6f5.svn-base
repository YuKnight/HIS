
/****** Object:  View [dbo].[VI_YP_YPCD_pivas]    Script Date: 04/09/2015 10:17:52 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_YP_YPCD_pivas]'))
DROP VIEW [dbo].[VI_YP_YPCD_pivas]
GO 

/****** Object:  View [dbo].[VI_YP_YPCD_pivas]    Script Date: 04/09/2015 10:17:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE VIEW [dbo].[VI_YP_YPCD_pivas]
  AS  
	select cjid,YPPM,YPSPM,YPGG,HLXS,dbo.fun_yp_ypdw(HLDW) as hldw,PSYP from VI_YP_YPCD
GO