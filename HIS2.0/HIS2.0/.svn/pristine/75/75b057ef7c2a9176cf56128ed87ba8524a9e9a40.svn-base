using System;

namespace TrasenFrame.Classes
{
	/// <summary>
	/// CheckListBoxItem 的摘要说明。
	/// </summary>
	public class CheckListBoxItem
	{
		public CheckListBoxItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _itemId;
		private string _itemName;
		private bool _checked;
		public int ItemId
		{
			get
			{
				return _itemId;
			}
			set
			{
				_itemId = value;
			}
		}
		public string ItemName
		{
			get
			{
				return _itemName.Trim();
			}
			set
			{
				_itemName = value.Trim();
			}
		}
		public bool Checked
		{
			get
			{
				return _checked;
			}
			set
			{
				_checked = value;
			}
		}
		
		public override string ToString()
		{
			if ( _itemName != null )
				return _itemName.Trim();
			else
				return "";
		}

	}
}
