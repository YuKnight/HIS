using System;
using System.Data;
namespace TrasenFrame.Classes
{
	/// <summary>
	/// Nurse 的摘要说明。
	/// </summary>
	public class Nurse : Employee
	{
		private TrasenClasses.GeneralClasses.NurseType _nurseType; //护士类型 0-普通 1-组长护士 2-护士长
		/// <summary>
		/// 
		/// </summary>
		public Nurse() : base()
		{
			base.EmployeeId = -1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="EmployeeId"></param>
		/// <param name="dataBase"></param>
		public Nurse(int EmployeeId,TrasenClasses.DatabaseAccess.RelationalDatabase dataBase) : base()
		{
			this.Database = dataBase;
			//获取护士级别
			string sql = "select * from jc_role_nurse where employee_id=" + EmployeeId;
			DataRow dr = this.Database.GetDataRow( sql );
			if ( dr == null ) throw new Exception ("该护士不存在！");
			int hsType = Convert.IsDBNull( dr["type"] ) ? 0 : Convert.ToInt32( dr["type"] );
			switch ( hsType )
			{
				case 0 :
					_nurseType = TrasenClasses.GeneralClasses.NurseType.普通护士;
					break;
				case 1:
					_nurseType = TrasenClasses.GeneralClasses.NurseType.组长护士;
					break;
				case 2:
					_nurseType = TrasenClasses.GeneralClasses.NurseType.护士长;
					break;
				default:
					_nurseType = TrasenClasses.GeneralClasses.NurseType.普通护士;
					break;
			}
			base.InitEmployee(EmployeeId);
		}
		/// <summary>
		/// 护士类型
		/// </summary>
		public TrasenClasses.GeneralClasses.NurseType Nurse_Type
		{
			get
			{
				return _nurseType;
			}
			set
			{
				_nurseType = value;
			}
		}
	}
}
