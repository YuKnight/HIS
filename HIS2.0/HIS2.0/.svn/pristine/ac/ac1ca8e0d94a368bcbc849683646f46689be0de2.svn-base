
/****** Object:  View [dbo].[VI_pivas_Orderusage]    Script Date: 04/09/2015 10:17:52 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_pivas_Orderusage]'))
DROP VIEW [dbo].[VI_pivas_Orderusage]
GO

/****** Object:  View [dbo].[VI_pivas_Orderusage]   Script Date: 04/09/2015 10:17:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE VIEW [dbo].[VI_pivas_Orderusage]
  AS  
  select * from JC_USAGEDICTION where NAME ='iv drip'--通过此处用法过滤pivas医嘱
GO