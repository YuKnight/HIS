
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_CFPD_KSYS' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_CFPD_KSYS
GO
CREATE PROCEDURE SP_YP_CFPD_KSYS
 ( 
   @DLKS int,
   @FUNNAME VARCHAR(300)
 )
as 
begin
	select a.dept_id as id,name,0 as fid from jc_dept_property a 
	where dept_id in(select dept_id from jc_dept_type_relation
	where type_code in('001','002','003')) union all
	select a.employee_id as id,a.name,dept_id as fid
	from jc_employee_property a 
	 inner join jc_role_doctor b on a.employee_id=b.employee_id 
	inner join JC_EMP_DEPT_ROLE c on a.employee_id=c.employee_id
	where a.delete_bit=0
end


