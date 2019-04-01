
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_YJ_MZSQ]'))
DROP VIEW [dbo].[VI_YJ_MZSQ]
GO



CREATE view [dbo].[VI_YJ_MZSQ] as  
select  
  *  
from  
   YJ_MZSQ(nolock)  
UNION ALL  
select 
  *  
from  
   YJ_MZSQ_H(nolock)  

GO


