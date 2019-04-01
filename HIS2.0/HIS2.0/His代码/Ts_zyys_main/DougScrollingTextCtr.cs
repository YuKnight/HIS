using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Ts_zyys_main
{
	/// <summary>
	/// DougScrollingTextCtr 的摘要说明。
	/// </summary>
	public class DougScrollingTextCtr : System.Windows.Forms.UserControl
	{
		private Color m_Color1 = Color.Black;  // First default color.
		private Color m_Color2 = Color.Gold;   // Second default color.
		private bool Stop=false;
		private Font m_MyFont;   // For the font.
		protected Timer m_Timer;             // Timer for text animation.
		protected string sScrollText = null;   // Text to be displayed in the control.
		private float X;
		private ScrollingTypes sType=ScrollingTypes.NoContinuum;//默认不连续
		private WayTypes wType=WayTypes.Left;//默认向左滚动
		private BorderStyle bStyle=BorderStyle.None;
		private Color borderColor=Color.Black;
		public enum ScrollingTypes//滚动类型
		{
			Continuum,   //Text连续
			NoContinuum  //不连续
		}
		public enum WayTypes//滚动方向类型
		{
			Left,//向左
			Right//向右
		}

		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DougScrollingTextCtr()
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
				if(value!=BorderStyle.FixedSingle)
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
			// DougScrollingTextCtr
			// 
			this.Name = "DougScrollingTextCtr";
			this.Size = new System.Drawing.Size(200, 32);

		}
		#endregion

		void Animate( object sender, EventArgs e )
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
		void StartStop( object sender, EventArgs e )
		{
			m_Timer.Enabled = !m_Timer.Enabled;
		}

		protected override void OnTextChanged( EventArgs e )
		{
			sScrollText = null;
			base.OnTextChanged( e );
		}
		protected override void OnClick( EventArgs e )
		{
			m_Timer.Enabled = !m_Timer.Enabled;
			base.OnClick( e );
		}
		protected override void OnMouseEnter( EventArgs e )
		{
			m_Timer.Enabled=false;
			Cursor=Cursors.Hand;
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave( EventArgs e )
		{
			m_Timer.Enabled=true;
			Cursor=Cursors.Arrow;
			base.OnMouseLeave(e);
		}
		protected override void OnPaint( PaintEventArgs pe )
		{
			Brush MyBrush = new System.Drawing.Drawing2D.LinearGradientBrush( ClientRectangle, m_Color1, m_Color2, 10 );
			m_MyFont = new Font( Font.Name,(Height*3)/4, Font.Style, GraphicsUnit.Pixel );

			pe.Graphics.DrawString( sScrollText, m_MyFont, MyBrush,X, 4 );

			switch(bStyle)
			{
				case BorderStyle.FixedSingle:
					pe.Graphics.DrawRectangle(new Pen(borderColor),0,0,this.Size.Width-1,this.Size.Height-1);
					break;
				case BorderStyle.Fixed3D:
					pe.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace),0,0,this.Size.Width-1,0);
					pe.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace),0,0,0,this.Size.Height-1);
					pe.Graphics.DrawLine(new Pen(Color.White),this.Size.Width-1,0,this.Size.Width-1,this.Size.Height-1);
					pe.Graphics.DrawLine(new Pen(Color.White),0,this.Size.Height-1,this.Size.Width-1,this.Size.Height-1);
					break;
				case BorderStyle.None:
					break;
			}

			base.OnPaint (pe);

			MyBrush.Dispose(); 
			m_MyFont.Dispose();
		}
	}
}