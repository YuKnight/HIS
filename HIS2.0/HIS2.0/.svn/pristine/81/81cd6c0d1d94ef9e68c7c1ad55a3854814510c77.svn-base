using System;
using TrasenClasses.DatabaseAccess;

namespace TrasenClasses.GeneralClasses
{
	/// <summary>
	/// ServerDate 的摘要说明。
	/// </summary>
	public class DateManager
	{
		private static DateTime dtServer;
		/// <summary>
		/// 自定义时间类
		/// </summary>
		public DateManager()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 取得服务器时间
		/// </summary>
		/// <param name="database">数据访问对象</param>
		/// <returns></returns>
		public static DateTime ServerDateTimeByDBType(RelationalDatabase database)
		{
            RelationalDatabase _db = database.GetCopy();
            try
            {
                _db.Open();
                //dtServer = Convert.ToDateTime( database.GetDataResult( database.GetServerTimeString() ) );
                dtServer = Convert.ToDateTime( _db.GetDataResult( _db.GetServerTimeString() ) );
                return dtServer;
            }
            catch
            {
                throw new Exception( "void ServerDateTimeByDBType Exception" );
            }
            finally
            {
                _db.Close();
                _db.Dispose();
            }
			
		}
		/// <summary>
		/// 把年龄转换成日期
		/// </summary>
		/// <param name="age"></param>
		/// <param name="database">数据访问对象</param>
		/// <returns></returns>
		public static DateTime AgeToDate(Age age,RelationalDatabase database)
		{
			DateTime date;
			switch(age.Unit)
			{
				case AgeUnit.岁:
					date=DateManager.ServerDateTimeByDBType(database).AddYears((-1)*age.AgeNum);
					break;
				case AgeUnit.月:
					date=DateManager.ServerDateTimeByDBType(database).AddMonths((-1)*age.AgeNum);
					break;
				case AgeUnit.天:
					date=DateManager.ServerDateTimeByDBType(database).AddDays((-1)*age.AgeNum);
					break;
				case AgeUnit.小时:
					date=DateManager.ServerDateTimeByDBType(database).AddHours((-1)*age.AgeNum);
					break;
				default:
					date=DateManager.ServerDateTimeByDBType(database);
					break;
			}
			return date;
		}
		/// <summary>
		/// 把日期转换成年龄
		/// </summary>
		/// <param name="birthday"></param>
		/// <param name="database">数据访问对象</param>
		/// <returns></returns>
		public static Age DateToAge(DateTime birthday,RelationalDatabase database)
		{
			Age age=new Age();
			DateTime current=ServerDateTimeByDBType(database);
			TimeSpan ts;
			if(birthday.Year!=current.Year && birthday.Date.AddYears(1)<=current.Date)
			{
				age.Unit=AgeUnit.岁;
				age.AgeNum= current.Year-birthday.Year;
			}
			else if(birthday.Month!=current.Month && birthday.Date.AddMonths(1)<=current.Date)
			{
				age.Unit=AgeUnit.月;
				age.AgeNum= current.Month-birthday.Month;
				if(age.AgeNum<0)
				{
					age.AgeNum +=12;
				}
			}
			else if(birthday.Day!=current.Day && birthday.Date.AddDays(1)<=current.Date)
			{
				age.Unit=AgeUnit.天;
				ts= current-birthday;
				age.AgeNum=ts.Days;
			}
			else  if(birthday.Hour!=current.Hour && birthday.AddHours(1)<=current)
			{
				age.Unit=AgeUnit.小时;
				ts= current-birthday;
				age.AgeNum= ts.Hours;
			}
			else
			{
				age.Unit=AgeUnit.小时;
				age.AgeNum=0;
			}
			return age;
		}
	}
}
