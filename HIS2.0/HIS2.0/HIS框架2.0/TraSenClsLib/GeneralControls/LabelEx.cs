using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// LabelEx的摘要说明。
	/// </summary>
	public class LabelEx : Label
	{
		private Color _BackColor1=SystemColors.ControlDarkDark;
		private Color _BackColor2=Color.AliceBlue;
		
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 自定义Label(有渐变的自定义背景色)
		/// </summary>
		/// <param name="container"></param>
		public LabelEx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		/// 自定义Label(有渐变的自定义背景色)
		/// </summary>
		public LabelEx()
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
		
		#region 属性
		/// <summary>
		/// 颜色渐变的第一种颜色
		/// </summary>
		[DefaultValue("ControlDarkDark"),Description("颜色渐变的第一种颜色"),Category("Appearance")]
		public Color BackColor1
		{
			get { return _BackColor1; }
			set 
			{
				_BackColor1 = value; 
				Invalidate();
			}
		}
		/// <summary>
		/// 颜色渐变的第二种颜色
		/// </summary>
		[DefaultValue("AliceBlue"),Description("颜色渐变的第二种颜色"),Category("Appearance")]
		public Color BackColor2
		{
			get { return _BackColor2; }
			set 
			{
				_BackColor2 = value; 
				Invalidate();
			}
		}

		#endregion


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
		/// OnPaint
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			using(Brush MyBrush = new System.Drawing.Drawing2D.LinearGradientBrush( ClientRectangle, _BackColor1,_BackColor2, 10 ))
			{
				e.Graphics.FillRectangle(MyBrush,0,0,this.Size.Width ,this.Size.Height);
			}
			base.OnPaint (e);
		}

	}
}
