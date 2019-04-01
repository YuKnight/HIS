
/****** Object:  View [dbo].[VI_ZY_VINPATIENT_pivas]    Script Date: 04/09/2015 10:17:52 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VI_ZY_VINPATIENT_pivas]'))
DROP VIEW [dbo].[VI_ZY_VINPATIENT_pivas]
GO
 
/****** Object:  View [dbo].[VI_ZY_VINPATIENT_pivas]    Script Date: 04/09/2015 10:17:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE VIEW [dbo].[VI_ZY_VINPATIENT_pivas]
  AS  
  select cast(INPATIENT_NO as varchar(20))+'$'+cast(BABY_ID as varchar(20)) as INPATIENT_NO,NAME,WARD_ID,BED_NO,AGE,BIRTHDAY,SEXCODE from VI_ZY_VINPATIENT_BED
GO