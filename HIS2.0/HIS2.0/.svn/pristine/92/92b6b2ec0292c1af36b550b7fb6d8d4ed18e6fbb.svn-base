using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// TextBox 的摘要说明:获取焦点后变色，离开焦点后恢复为原背景色
	/// </summary>
	public class DateTimePickerEx : DateTimePicker
	{
		private Color _enterBackColor;
		private Color _oldBackColor;
		private Color _enterForeColor;
		private Color _oldForeColor;
		
		private Control _nextControl;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 自定义TextBox(获取焦点后变色，离开焦点后恢复为原背景色)
		/// </summary>
		/// <param name="container"></param>
		public DateTimePickerEx(System.ComponentModel.IContainer container)
		{
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		///自定义TextBox(获取焦点后变色，离开焦点后恢复为原背景色)
		/// </summary>
		public DateTimePickerEx()
		{
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			InitializeComponent();
			_enterForeColor=SystemColors.WindowText;
			_enterBackColor=SystemColors.Window;
			_oldBackColor=this.BackColor;
			_oldForeColor=this.ForeColor;
			_nextControl=null;
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

		#region 属性
		/// <summary>
		/// 获得焦点后的前景色
		/// </summary>
		[DefaultValue("WindowText"),Description("获取焦点后的前景色"),Category("Appearance")]
		public Color EnterForeColor
		{
			get
			{
				return _enterForeColor;
			}
			set 
			{
				_enterForeColor=value;
			}
		}/// <summary>
		/// 获得焦点后的背景色
		/// </summary>
		[DefaultValue("Window"),Description("获取焦点后的背景色"),Category("Appearance")]
		public Color EnterBackColor
		{
			get
			{
				return _enterBackColor;
			}
			set 
			{
				_enterBackColor=value;
			}
		}
		/// <summary>
		/// 当SelectionStart=SelectionLength时按右方向键跳至该控件
		/// </summary>
		[DefaultValue("NULL"),Description("当SelectionStart=SelectionLength时按右方向键跳至该控件"),Category("Behavior")]
		public Control NextControl
		{
			get
			{
				return _nextControl;
			}
			set 
			{
				_nextControl=value;
			}
		}
		#endregion

		#region 重写事件
		/// <summary>
		/// 重写OnKeyDown事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter && _nextControl!=null && _nextControl.CanFocus)
			{
				_nextControl.Focus();
			}
			base.OnKeyDown (e);
		}
		/// <summary>
		/// 重写OnEnter事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnEnter(EventArgs e)
		{
			this.ForeColor =_enterForeColor;
			this.BackColor =_enterBackColor;
			base.OnEnter (e);
		}
		/// <summary>
		///  重写OnLeave事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLeave(EventArgs e)
		{
			this.ForeColor =_oldForeColor;
			this.BackColor =_oldBackColor;
			base.OnLeave (e);
		}

		#endregion
	}
}
