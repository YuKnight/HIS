using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace TrasenClasses.GeneralControls
{
	/// <summary>滚动类型</summary>
	public enum ScrollingTypes
	{
		/// <summary>Text连续</summary>
		Continuum,   
		/// <summary>不连续</summary>
		NoContinuum 
	}
	/// <summary>滚动方向类型</summary>
	public enum WayTypes
	{

		/// <summary>向左</summary>
		Left,
		/// <summary>向右</summary>
		Right
	}
	/// <summary>
	/// XcjwDougScrollingTextCtr 的摘要说明。
	/// </summary>
	public class DougScrollingTextCtrEx : System.Windows.Forms.UserControl
	{
		private Color m_Color1 = Color.Black;  // First default color.
		private Color m_Color2 = Color.Gold;   // Second default color.
		private bool Stop=false;
		private Font m_MyFont;   // For the font.
		private float X;
		private ScrollingTypes sType=ScrollingTypes.NoContinuum;//默认不连续
		private WayTypes wType=WayTypes.Left;//默认向左滚动
		private BorderStyle bStyle=TrasenClasses.GeneralControls.BorderStyle.None;
		private Color borderColor=Color.Black;
		/// <summary>Timer for text animation.</summary>
		protected Timer m_Timer;  
		/// <summary>Text to be displayed in the control.</summary>
		protected string sScrollText = null;   

		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public DougScrollingTextCtrEx()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			
			// TODO: 在 InitializeComponent 调用后添加任何初始化
			X=this.Size.Width;
			m_Timer = new Timer();
			m_Timer.Interval = 100;
			m_Timer.Enabled = true;
			m_Timer.Tick += new EventHandler( Animate );
		}
		#region 属性
		/// <summary>
		/// 第一种颜色
		/// </summary> 
		public Color DougScrollingTextColor1
		{
			get { return m_Color1; }
			set 
			{
				m_Color1 = value; 
				Invalidate();
			}
		}
		/// <summary>
		/// 第二种颜色
		/// </summary>
		public Color DougScrollingTextColor2
		{
			get { return m_Color2; }
			set 
			{
				m_Color2 = value; 
				Invalidate();
			}
		}
		/// <summary>
		/// 是否停止滚动
		/// </summary>
		public bool IsStop
		{
			get { return Stop; }
			set 
			{
				Stop = value;	
				if(Stop==true) this.m_Timer.Enabled=false;
				else this.m_Timer.Enabled=true;
			}
		}
		/// <summary>
		/// 显示的文本
		/// </summary>
		public string ShowText
		{
			get{return Text.Trim();}
			set{Text=value;}
		}
		/// <summary>
		/// 滚动类型属性
		/// </summary>
		public ScrollingTypes ScrollingType
		{
			get{return sType;}
			set
			{
				sType=value;
				if(sType==ScrollingTypes.Continuum) m_Timer.Interval=250;
				else m_Timer.Interval=100;
			}
		}
		/// <summary>
		/// 滚动方向类型
		/// </summary>
		public WayTypes Waytype
		{
			get{return wType;}
			set{wType=value;}
		}
		/// <summary>
		/// 是否具有可见的边框
		/// </summary>
		public BorderStyle BorderType
		{
			get{return bStyle;}
			set
			{
				bStyle=value;
                if ( value != TrasenClasses.GeneralControls.BorderStyle.FixedSingle )
					borderColor=Color.Black;
			}
		}
		/// <summary>
		/// 如果是单行边框，可设置边框颜色，否则默认是黑色
		/// </summary>
		public Color BorderColor
		{
			get{return borderColor;}
			set{borderColor=value;}
		}
		#endregion

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
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// XcjwDougScrollingTextCtr
			// 
			this.Name = "XcjwDougScrollingTextCtr";
			this.Size = new System.Drawing.Size(200, 32);

		}
		#endregion

		private void Animate( object sender, EventArgs e )
		{
			if( sScrollText == null )
			{
				if(Text=="") Text=" ";
				sScrollText =Text + " ";
			}

			if(wType==WayTypes.Left)//向左滚动
			{
				if(sType==ScrollingTypes.Continuum)
				{
					sScrollText = sScrollText.Substring( 1, sScrollText.Length-1 ) + sScrollText.Substring(0, 1 );
					X=0;
				}
				else
				{
					sScrollText=Text;
					if(X>-((Height*3*Text.Length)/5)) X-=3;
					else X=this.Size.Width;
				}
			}
			else//向右滚动
			{
				if(sType==ScrollingTypes.Continuum)
				{
					sScrollText = sScrollText.Substring(sScrollText.Length-1, 1 ) + sScrollText.Substring( 0, sScrollText.Length-1 );
					X=this.Size.Width-((Height*3*Text.Length)/5);
				}
				else
				{
					sScrollText=Text;
					if(X<this.Size.Width+((Height*3*Text.Length)/5)) X+=3;
					else X=0;
				}
			}
			Invalidate();
		}
		private void StartStop( object sender, EventArgs e )
		{
			m_Timer.Enabled = !m_Timer.Enabled;
		}
		/// <summary>
		/// 重写TextChanged
		/// </summary>
		/// <param name="e"></param>
		protected override void OnTextChanged( EventArgs e )
		{
			sScrollText = null;
			base.OnTextChanged( e );
		}
		/// <summary>
		/// 重写OnClick
		/// </summary>
		/// <param name="e"></param>
		protected override void OnClick( EventArgs e )
		{
			m_Timer.Enabled = !m_Timer.Enabled;
			base.OnClick( e );
		}
		/// <summary>
		/// 重写OnMouseEnte
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseEnter( EventArgs e )
		{
			m_Timer.Enabled=false;
			Cursor=Cursors.Hand;
			base.OnMouseEnter(e);
		}
		/// <summary>
		/// 重写OnMouseLeave
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave( EventArgs e )
		{
			m_Timer.Enabled=true;
			Cursor=Cursors.Arrow;
			base.OnMouseLeave(e);
		}
		/// <summary>
		/// 重写OnPaint
		/// </summary>
		/// <param name="pe"></param>
		protected override void OnPaint( PaintEventArgs pe )
		{
			Brush MyBrush = new System.Drawing.Drawing2D.LinearGradientBrush( ClientRectangle, m_Color1, m_Color2, 10 );
			m_MyFont = new Font( Font.Name,(Height*3)/4, Font.Style, GraphicsUnit.Pixel );

			pe.Graphics.DrawString( sScrollText, m_MyFont, MyBrush,X, 4 );

			switch(bStyle)
			{
                case TrasenClasses.GeneralControls.BorderStyle.FixedSingle:
					pe.Graphics.DrawRectangle(new Pen(borderColor),0,0,this.Size.Width-1,this.Size.Height-1);
					break;
                case TrasenClasses.GeneralControls.BorderStyle.Fixed3D:
					pe.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace),0,0,this.Size.Width-1,0);
					pe.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace),0,0,0,this.Size.Height-1);
					pe.Graphics.DrawLine(new Pen(Color.White),this.Size.Width-1,0,this.Size.Width-1,this.Size.Height-1);
					pe.Graphics.DrawLine(new Pen(Color.White),0,this.Size.Height-1,this.Size.Width-1,this.Size.Height-1);
					break;
                case TrasenClasses.GeneralControls.BorderStyle.None:
					break;
			}

			base.OnPaint (pe);

			MyBrush.Dispose(); 
			m_MyFont.Dispose();
		}
	}
}