using System;

namespace TrasenClasses.GeneralClasses
{
	/// <summary>
	/// Item 的摘要说明。
	/// </summary>
	public class Item
	{
		private string _text;
		private object _value;
		/// <summary>
		/// 构造一空Item对象
		/// </summary>
		public Item()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			_text="";
			_value=null;
		}
		/// <summary>
		/// 设置或者返回Item对象的Text
		/// </summary>
		public string Text
		{
			get{return _text;}
			set{_text=value;}
		}
		/// <summary>
		/// 设置或者返回Item对象的Value
		/// </summary>
		public object Value
		{
			get{return _value;}
			set{_value=value;}
		}
		/// <summary>
		/// 返回Item对象的Text
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _text;
		}

	}
}
