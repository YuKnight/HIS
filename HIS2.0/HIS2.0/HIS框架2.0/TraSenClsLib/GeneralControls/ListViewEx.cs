using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// ListViewEx 的摘要说明。
	/// </summary>
	public class ListViewEx : System.Windows.Forms.ListView
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// ListViewEx
		/// </summary>
		/// <param name="container"></param>
		public ListViewEx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}
		/// <summary>
		/// 构造ListViewEx
		/// </summary>
		public ListViewEx()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
		
		/// <summary>
		/// 重写OnColumnClick
		/// </summary>
		/// <param name="e"></param>
		protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
		{
			string headerText=null;
			int endIndex;
			int upIndex=this.Columns[e.Column].Text.LastIndexOf("↑");
			int downIndex=this.Columns[e.Column].Text.LastIndexOf("↓");
			//先去掉其他列的排序箭头
			for(int i=0;i<this.Columns.Count;i++)
			{
				headerText=this.Columns[i].Text;
				endIndex=headerText.LastIndexOf("↑");
				if(endIndex<0)
				{
					endIndex=headerText.LastIndexOf("↓");
				}
				if(endIndex>0)
				{
					this.Columns[i].Text=headerText.Substring(0,endIndex);
					break;
				}
			}
			if(upIndex<0 && downIndex<0)
			{
				this.ListViewItemSorter=new ListViewItemUpComparer(e.Column);
				this.Columns[e.Column].Text =this.Columns[e.Column].Text+"↑";
			}
			else
			{
				if(upIndex>0)
				{
					this.ListViewItemSorter=new ListViewItemDownComparer(e.Column);
					this.Columns[e.Column].Text =this.Columns[e.Column].Text+"↓";
				}
				else
				{
					this.ListViewItemSorter=new ListViewItemUpComparer(e.Column);
					this.Columns[e.Column].Text =this.Columns[e.Column].Text+"↑";
				}
			}
			this.Sort();
			base.OnColumnClick (e);
		}
	}
	/// <summary>
	/// 正向排序IComparer
	/// </summary>
	public class ListViewItemUpComparer : IComparer 
	{
		private int col;
		/// <summary>
		/// 构造函数
		/// </summary>
		public ListViewItemUpComparer() 
		{
			col=0;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="column"></param>
		public ListViewItemUpComparer(int column) 
		{
			col=column;
		}
		/// <summary>
		/// 排序比较
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y) 
		{
			string yText=((ListViewItem)y).SubItems[col].Text;
			string xText=((ListViewItem)x).SubItems[col].Text;
			if(Convertor.IsNumeric(yText) && Convertor.IsNumeric(xText))
			{
				decimal result=Convert.ToDecimal(xText)-Convert.ToDecimal(yText);
				if(result>0)
					return 1;
				else if(result==0)
					return 0;
				else 
					return -1;
			}
			else
			{
				return String.Compare(xText,yText);
			}
		}
	}
	/// <summary>
	/// 逆向排序IComparer
	/// </summary>
	public class ListViewItemDownComparer : IComparer 
	{
		private int col;
		/// <summary>
		/// 构造函数
		/// </summary>
		public ListViewItemDownComparer() 
		{
			col=0;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="column"></param>
		public ListViewItemDownComparer(int column) 
		{
			col=column;
		}
		/// <summary>
		/// 排序比较
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y) 
		{
			string yText=((ListViewItem)y).SubItems[col].Text;
			string xText=((ListViewItem)x).SubItems[col].Text;
			if(Convertor.IsNumeric(yText) && Convertor.IsNumeric(xText))
			{
				decimal result=Convert.ToDecimal(yText)-Convert.ToDecimal(xText);
				if(result>0)
					return 1;
				else if(result==0)
					return 0;
				else 
					return -1;
			}
			else
			{
				return String.Compare(yText, xText);
			}
		}
	}
}
