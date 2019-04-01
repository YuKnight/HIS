IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fun_getFirstLevelDeptId]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fun_getFirstLevelDeptId]
GO
CREATE FUNCTION [dbo].[fun_getFirstLevelDeptId](
@deptId int
)
RETURNS int
AS
/*
Create By Tany 2015-06-04
找到科室对应的第一层科室ID，主要用于判断两个科室是不是一个院区的
*/
begin
	declare @dept_id int
	declare @layer int
	
	set @layer=(select layer from jc_dept_property where dept_id=@deptid)
	
	if @layer=3
	begin
		set @dept_id = ( select c.DEPT_ID 
					from JC_DEPT_PROPERTY a
					inner join JC_DEPT_PROPERTY b on a.P_DEPT_ID=b.DEPT_ID and b.LAYER=2
					inner join JC_DEPT_PROPERTY c on b.P_DEPT_ID=c.DEPT_ID and c.LAYER=1
					where a.LAYER=3 and a.DEPT_ID=@deptid )
    end
    
    if @layer=2
	begin
		set @dept_id = ( select b.DEPT_ID 
					from JC_DEPT_PROPERTY a
					inner join JC_DEPT_PROPERTY b on a.P_DEPT_ID=b.DEPT_ID and b.LAYER=1
					where a.LAYER=2 and a.DEPT_ID=@deptid )
    end
    
    if @layer=1
	begin
		set @dept_id = @deptid
    end
    
    set @dept_id=isnull(@dept_id,0)
					
	return @dept_id
end

GO


