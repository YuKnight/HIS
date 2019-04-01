
/****** Object:  View [dbo].[VI_pivas_Orderusage]    Script Date: 04/09/2015 10:17:52 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_pivas_Freq]'))
DROP VIEW [dbo].[VI_pivas_Freq]
GO

/****** Object:  View [dbo].[VI_pivas_Orderusage]   Script Date: 04/09/2015 10:17:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE VIEW [dbo].[VI_pivas_Freq]
  AS  
  --通过此处用法过滤pivas医嘱
  select * from JC_FREQUENCY where name in('qd','bid','tid','qid','q2h','q4h','q6h','q12h','qn','q8h')
GO