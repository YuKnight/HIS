
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_YJ_ZYSQ]'))
DROP VIEW [dbo].[VI_YJ_ZYSQ]
GO


CREATE view [dbo].[VI_YJ_ZYSQ] as  
select  
  *  
from  
   YJ_ZYSQ(nolock)  
UNION ALL  
select 
  *  
from  
   YJ_ZYSQ_H(nolock)  
GO


