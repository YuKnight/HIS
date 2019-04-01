using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// TabControlEx 的摘要说明
	/// 控件的tabPage的text内容显示成竖着的字体
	/// </summary>
	public class TabControlEx : System.Windows.Forms.TabControl
	{
		private Color _tabPageTextForeColor;
		private Color _tabPageTextBackColor;
		private Color _tabPageTextCurBackColor;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 自定义TabControl
		/// </summary>
		/// <param name="container"></param>
		public TabControlEx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			_tabPageTextForeColor=SystemColors.WindowText;
			_tabPageTextBackColor=SystemColors.Control;
			_tabPageTextCurBackColor=SystemColors.Control;

		}
		/// <summary>
		/// 构造函数
		/// </summary>
		public TabControlEx()
		{
			InitializeComponent();
			_tabPageTextForeColor=SystemColors.WindowText;
			_tabPageTextBackColor=SystemColors.Control;
			_tabPageTextCurBackColor=SystemColors.Control;

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


		#region 自定义属性
		/// <summary>
		/// TabPage的Text前景颜色
		/// </summary>
		[DefaultValue("Control"),Description("TabPage的Text前景颜色"),Category("Appearance")]
		public Color TabPageTextForeColor
		{
			get
			{
				return _tabPageTextForeColor;
			}
			set 
			{
				_tabPageTextForeColor=value;
			}
		}
		/// <summary>
		/// TabPage的Text背景颜色
		/// </summary>
		[DefaultValue("Control"),Description("TabPage的Text前景颜色"),Category("Appearance")]
		public Color TabPageTextBackColor
		{
			get
			{
				return _tabPageTextBackColor;
			}
			set 
			{
				_tabPageTextBackColor=value;
			}
		}
		/// <summary>
		/// TabControl当前TabPage的Text背景颜色
		/// </summary>
		[DefaultValue("Control"),Description("TabControl当前TabPage的Text背景颜色"),Category("Appearance")]
		public Color TabPageTextCurBackColor
		{
			get
			{
				return _tabPageTextCurBackColor;
			}
			set 
			{
				_tabPageTextCurBackColor=value;
			}
		}
		#endregion

		#region 重写事件
		/// <summary>
		/// 重写OnDrawItem事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
		{
			Rectangle tabArea;
			RectangleF tabTextArea;
			tabArea = this.GetTabRect(e.Index);			//主要是做个转换来获得TAB项的RECTANGELF
			tabTextArea = (RectangleF)(this.GetTabRect(e.Index));
			StringFormat sf=new StringFormat();			//封装文本布局信息
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;				
			SolidBrush brush=new SolidBrush(_tabPageTextForeColor);  
			//绘制背景的画笔
			SolidBrush backBrush;
			if(this.SelectedIndex==e.Index)				//选中页
			{
				backBrush=new SolidBrush(_tabPageTextCurBackColor);
			}
			else
			{
				backBrush=new SolidBrush(_tabPageTextBackColor);
			}
			e.Graphics.FillRectangle(backBrush,tabArea);
			//绘制文字
			e.Graphics.DrawString(this.TabPages[e.Index].Text,this.Font,brush,tabTextArea,sf);
			base.OnDrawItem (e);
		}

		#endregion
	}
}
