using System;

namespace TrasenClasses.GeneralClasses
{
	/// <summary>
	/// Convert 的摘要说明。
	/// </summary>
	public class Convertor
	{
		/// <summary>
		/// 将Null值转换为指定值
		/// </summary>
		/// <param name="obj">待判断的值</param>
		/// <param name="nValue">指定值</param>
		/// <returns></returns>
		public static string IsNull(object obj, string nValue)
		{
			try
			{
				return Convert.ToString(obj).Trim()=="" ? nValue:obj.ToString().Trim();
			}
			catch(System.InvalidCastException err)
			{
				err.ToString();
				return "";
			}
			catch(System.Exception err)
			{
				err.ToString();
				return "";
			}		
		}

		/// <summary>
		///判断输入字符串是否为数字
		/// </summary>
		/// <param name="nValue">字符串</param>
		/// <returns></returns>
		public static bool IsNumeric(string nValue)
		{
			int i,iAsc,idecimal=0;
			if(nValue.Trim()=="") return false;
			for(i=0;i<=nValue.Length-1;i++)
			{
				iAsc=(int)Convert.ToChar(nValue.Substring(i,1));
				//'-'45 '.'46 '''0-9' 48-57
				if(iAsc==45)		
				{
					if(nValue.Length ==1)//不能只有一个负号
					{
						return false;
					}
					if(i!=0)			//'-'不能在字符串中间
					{
						return false;
					}
				}
				else if(iAsc==46)
				{
					idecimal++;
					if(idecimal>1)		//如果有两个以上的小数点
						return false;
				}
				else if(iAsc<48 || iAsc>57)
				{
						return false;
				}
			}
			return true;	
		}

		/// <summary>
		///判断输入字符串是否为整数
		/// </summary>
		/// <param name="nValue">字符串</param>
		/// <returns></returns>
		public static bool IsInteger(string nValue)
		{
			int i,iAsc;
			if(nValue.Trim()=="") return false;
			for(i=0;i<=nValue.Length-1;i++)
			{
				iAsc=(int)Convert.ToChar(nValue.Substring(i,1));
				//'-' 45 '0-9' 48-57
				if(iAsc==45)		
				{
					if(nValue.Length ==1)//不能只有一个负号
					{
						return false;
					}
					if(i!=0)			//'-'不能在字符串中间
					{
						return false;
					}
				}
				else if(iAsc<48 || iAsc>57)
				{
					return false;
				}
			}
			return true;	
		}
	}
}
