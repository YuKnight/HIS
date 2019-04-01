using System;

namespace TrasenClasses.GeneralClasses
{
	/// <summary>
	/// 本类实现阿拉伯数字到大写中文的转换
	/// 该类没有对非法数字进行判别
	/// 请调用NumToChn方法
	/// </summary>
	public class Money
	{
		/// <summary>
		/// 金额类
		/// </summary>
		public Money()
		{
		
		}
		private static char chrToNum(char x)
		{
			string chnNames="零壹贰叁肆伍陆柒捌玖";
			string numNames="0123456789";
			return chnNames[numNames.IndexOf(x)];
		}
		private static string TenthousandToNum(string x)
		{
			string[] stringArrayLevelNames=new string[4] {"","拾","佰","仟"};
			string ret="";
			int i;
			for (i=x.Length-1;i>=0;i--)
				if (x[i]=='0')
					ret=chrToNum(x[i])+ret;
				else
					ret=chrToNum(x[i])+stringArrayLevelNames[x.Length-1-i]+ret;
			while ((i=ret.IndexOf("零零"))!=-1)
				ret=ret.Remove(i,1);
			if (ret[ret.Length-1]=='零' && ret.Length>1)
				ret=ret.Remove(ret.Length-1,1);
			//			if (ret.Length>=2 && ret.Substring(0,2)=="壹拾")
			//				ret=ret.Remove(0,1);
			return ret;
		}
		private static string chgIntegerPart(string x)
		{
			int len=x.Length;
			string ret,temp;
			if (len<=4)
				ret=TenthousandToNum(x);
			else if (len<=8)
			{
				ret=TenthousandToNum(x.Substring(0,len-4))+"万";
				temp=TenthousandToNum(x.Substring(len-4,4));
				if (temp.IndexOf("仟")==-1 && temp!="")
					ret+="零"+temp;
				else
					ret+=temp;
			}
			else
			{
				ret=TenthousandToNum(x.Substring(0,len-8))+"亿";
				temp=TenthousandToNum(x.Substring(len-8,4));
				if (temp.IndexOf("仟")==-1 && temp!="")
					ret+="零"+temp;
				else
					ret+=temp;
				ret+="万";
				temp=TenthousandToNum(x.Substring(len-4,4));
				if (temp.IndexOf("仟")==-1 && temp!="")
					ret+="零"+temp;
				else
					ret+=temp;
			}
			int i;
			if ((i=ret.IndexOf("零万"))!=-1)
				ret=ret.Remove(i+1,1);
			while ((i=ret.IndexOf("零零"))!=-1)
				ret=ret.Remove(i,1);
			if (ret[ret.Length-1]=='零' && ret.Length>1)
				ret=ret.Remove(ret.Length-1,1);
			return ret;
		}

		private static string chgDecimalPart(string x)
		{
			string ret="";
			for (int i=0;i<x.Length && i<2;i++)
			{
				switch(i)
				{
					case 0:
						ret+=chrToNum(x[i])+"角";
						break;
					case 1:
						ret+=chrToNum(x[i])+"分";
						break;
				}
			}
			return ret;
		}
		/// <summary>
		/// 将阿拉伯小写金额转换成大写金额
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static string NumToChn(string x)
		{
			if (x.Length==0)
				return "";
			string ret="";
			if (x[0]=='-')
			{
				ret="负";
				x=x.Remove(0,1);
			}
			if (x[0].ToString()==".")
				x="0"+x;
			if (x[x.Length-1].ToString()==".")
				x=x.Remove(x.Length-1,1);
			//if (x.IndexOf(".")>-1) 2005-09-13,Szg,Modify
			if (x.IndexOf(".")>-1)
			{
				if(Convert.ToDecimal("0"+x.Substring(x.IndexOf(".")))>0)
				{
					ret+=chgIntegerPart(x.Substring(0,x.IndexOf(".")))+"元"+chgDecimalPart(x.Substring(x.IndexOf(".")+1));
				}
				else
				{
					ret+=chgIntegerPart(Convert.ToDecimal(x).ToString("0"))+"元整";
				}
			}
			else
			{
				ret+=chgIntegerPart(x)+"元整";
			}
			return ret;
		}
	}
	/* END CLASS DEFINITION Money */
}
