using System;
using TrasenClasses.DatabaseAccess;

namespace TrasenClasses.GeneralClasses
{
	/// <summary>
	/// 定义年龄结构
	/// </summary>
	public class Age
	{
		/// <summary>
		/// 年龄数字
		/// </summary>
		public int AgeNum;	
		/// <summary>
		/// 年龄单位
		/// </summary>
		public AgeUnit Unit;
		/// <summary>
		/// 获取年龄实例
		/// </summary>
		public Age()
		{

		}
		/// <summary>
		/// 根据年龄与单位获取年龄实例
		/// </summary>
		/// <param name="age"></param>
		/// <param name="ageuint"></param>
		public Age(int age,AgeUnit ageuint)
		{
			AgeNum=age;
			Unit=ageuint;
		}
		/// <summary>
		/// 根据生日得到年龄字符串（岁月天格式）
		/// </summary>
		/// <param name="birth">出生日期</param>
		/// <param name="nowDate">当前日期</param>
		/// <param name="type">0表示最多只显示两个时间单位,1表示最多只显示三个时间单位</param>
		/// <returns>年龄字符串</returns>
		public static string GetAgeString(DateTime birth,DateTime nowDate,int type)
		{
			int years=0;
			int months=0;
			int days=0;
			string age="";
			TimeSpan ts;
			DateTime now=nowDate;
			DateTime birthDay=birth;
			years=now.Year -birthDay.Year;
			if(years>=0)
			{
				birthDay=birthDay.AddYears(years);
				months=now.Month -birthDay.Month;
				if(months>0)
				{
					birthDay=birthDay.AddMonths(months);
					ts=now-birthDay;
					days=ts.Days;
					if(days<0)
					{
						ts=now-birthDay.AddMonths(-1);
						months--;
						days=ts.Days;
					}
				}
				else if(months==0)
				{
					ts=now-birthDay;
					days=ts.Days;
					if(days<0)
					{
						birthDay=birthDay.AddMonths(-1);
						years--;
						months=11;
						ts=now-birthDay;
						days=ts.Days;
					}
				}
				else if(months<0)
				{
					birthDay=birthDay.AddMonths(months);
					years--;
					months+=12;
					ts=now-birthDay;
					days=ts.Days;
					if(days<0)
					{
						birthDay=birthDay.AddMonths(-1);
						months--;
						ts=now-birthDay;
						days=ts.Days;
					}
				}
			}
			int num=0;
			if(years>0)
			{
				age+=years.ToString()+"岁";
				num++;
			}
			if(months>0 && num<2)
			{
				age+=months.ToString()+"月";
				num++;
			}
			if(days>0 && (type==0 || num<2))
			{
				age+=days.ToString()+"天";
			}
			return age;
		}
	}
}