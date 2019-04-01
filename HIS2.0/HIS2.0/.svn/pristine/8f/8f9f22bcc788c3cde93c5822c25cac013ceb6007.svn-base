IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_select_patient' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_select_patient
GO
CREATE PROCEDURE sp_yf_select_patient
(
 @inpatient_no varchar(30) ,
 @inpatient_id UNIQUEIDENTIFIER
)  
as

declare @ss varchar(8000)
declare @ltbz int

begin

if @inpatient_no<>'' 
   select top 1 * from vi_yy_brxx a,zy_inpatient b where a.brxxid=b.patient_id and inpatient_no=@inpatient_no order by in_date desc 
if @inpatient_id<>dbo.FUN_GETEMPTYGUID()
    select top 1 * from vi_yy_brxx a,zy_inpatient b where a.brxxid=b.patient_id and inpatient_id=@inpatient_id order by intimes desc 

END


--exec sp_yf_select_message '',0,0,'',0