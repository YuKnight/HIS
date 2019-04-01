
/****** Object:  View [dbo].[VI_YP_YPDW_pivas]    Script Date: 04/09/2015 10:17:52 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_YP_YPDW_pivas]'))
DROP VIEW [dbo].[VI_YP_YPDW_pivas]
GO

/****** Object:  View [dbo].[VI_YP_YPDW_pivas]    Script Date: 04/09/2015 10:17:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE VIEW [dbo].[VI_YP_YPDW_pivas]
  AS  
	select ID,DWMC,PYM,WBM from YP_YPDW
GO


