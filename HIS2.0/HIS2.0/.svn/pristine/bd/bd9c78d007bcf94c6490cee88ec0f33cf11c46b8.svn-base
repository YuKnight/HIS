using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// 边框样式
	/// </summary>
	public enum BorderStyle
	{
		/// <summary>
		/// 3D风格
		/// </summary>
		Fixed3D,
		/// <summary>
		/// 单边框
		/// </summary>
		FixedSingle,
		/// <summary>
		/// 凸起
		/// </summary>
		Raised,
		/// <summary>
		/// 无
		/// </summary>
		None
	}        
	/// <summary>
	/// 显示的外观样式
	/// </summary>
	public enum ShowFaceStyle//
	{
		/// <summary>
		/// 颜色从左至右渐变
		/// </summary>
		Horizontal,
		/// <summary>
		/// 颜色从上至下渐变
		/// </summary>
		Vertical ,  
		/// <summary>
		/// 渐变移动
		/// </summary>
		Shadow 
	} 
	/// <summary>
	/// 进度条的类型（横向、纵向）
	/// </summary>
	public enum ShowGuageType
	{
		/// <summary>
		/// 水平方向
		/// </summary>
		Horizontal,
		/// <summary>
		/// 垂直方向
		/// </summary>
		Vertical
	}
	/// <summary>
	/// 进度条 的摘要说明。
	/// </summary>
	public class GuageBarEx : System.Windows.Forms.UserControl
	{
		private Color m_Color1 = Color.Black;  // First default color.
		private Color m_Color2 = Color.Gold;   // Second default color.
		private float myWidth=0; //进度的长度
		private float tempWidth; //保存进度条的总长
		private float maximum=100;//使用范围的上限
		private float minimum=0;  //使用范围的下限
		private float step=10;  //控件当前值的增量
		private float m_value=0;
        private TrasenClasses.GeneralControls.BorderStyle bStyle = TrasenClasses.GeneralControls.BorderStyle.None;
		private Color borderColor=Color.Black;
		private Color percentColor=Color.Black;
		private bool showPercent=true;
		private Label lb_Percent;
		private ShowFaceStyle showStyle=ShowFaceStyle.Horizontal;
		private ShowGuageType showType=ShowGuageType.Horizontal;
        private int shadowSize=30;

		
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 进度条
		/// </summary>
		public GuageBarEx()
		{			
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();            
			// TODO: 在 InitComponent 调用后添加任何初始化
			tempWidth=this.Size.Width;
		}
		#region 属性
		/// <summary>
		/// 第一种颜色
		/// </summary> 
		[DefaultValue("Black"),Description("颜色渐变的第一种颜色"),Category("Appearance")]
		public Color BackColor1
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
		[DefaultValue("Gold"),Description("颜色渐变的第二种颜色"),Category("Appearance")]
		public Color BackColor2
		{
			get { return m_Color2; }
			set 
			{
				m_Color2 = value; 
				Invalidate();
			}
		}

		/// <summary>
		/// 使用范围的上限
		/// </summary>
		[DefaultValue("100"),Description("使用范围的上限"),Category("Behavior")]
		public float Maximum
		{
			get{return maximum;}
			set
			{
				if(value<=minimum) maximum=minimum;
				else maximum=value;
				if(m_value>maximum) m_value=maximum;
				myWidth=tempWidth * (m_value/maximum);
				Invalidate();
//				lb_Percent.Text=Convert.ToString(Math.Round(100*m_value/maximum))+"%";
				PercentShow();
			}
		}

		/// <summary>
		/// 使用范围的下限
		/// </summary>
		[DefaultValue("0"),Description("使用范围的下限"),Category("Behavior")]
		public float Minimum
		{
			get{return minimum;}
			set
			{
				if(value>=maximum) minimum=maximum;
				else minimum=value;
				if(m_value<minimum) m_value=minimum;
				myWidth=tempWidth * (m_value/maximum);
				Invalidate();
//				lb_Percent.Text=Convert.ToString(Math.Round(100*m_value/maximum))+"%";
				PercentShow();
			}
		}
		/// <summary>
		/// 当调用Step()方法时，控件当前值的增量
		/// </summary>
		[DefaultValue("10"),Description("当调用PerformStep()方法时，控件当前值的增量"),Category("Behavior")]
		public float Step
		{
			get{return step;}
			set{step=value;}
		}

		/// <summary>
		/// 进度栏的当前位置
		/// </summary>
		[DefaultValue("0"),Description("进度栏的当前位置"),Category("Behavior")]
		public float Value
		{
			get{return m_value;}
			set
			{
				if(value>=maximum) m_value=maximum;
				else if(value<=minimum) m_value=minimum;
				else m_value=value;
				myWidth=tempWidth * (m_value/maximum);
				Invalidate();
//				lb_Percent.Text=Convert.ToString(Math.Round(100*m_value/maximum))+"%";
				PercentShow();
			}
		}

		/// <summary>
		/// 是否具有可见的边框
		/// </summary>
		[DefaultValue("None"),Description("是否具有可见的边框"),Category("Appearance")]
		public BorderStyle BorderType
		{
			get{return bStyle;}
			set
			{
				bStyle=value;
                if ( value != TrasenClasses.GeneralControls.BorderStyle.FixedSingle )
					borderColor=Color.Black;
				Invalidate();
			}
		}
		/// <summary>
		/// 如果是单行边框，可设置边框颜色，否则默认是黑色
		/// </summary>
		[DefaultValue("Black"),Description("如果是边框类型是FixedSingle，可设置边框颜色，否则默认是黑色"),Category("Appearance")] 
		public Color BorderColor
		{
			get{return borderColor;}
			set
			{
				borderColor=value;
				Invalidate();
			}
		}
		/// <summary>
		/// 进度栏百分比的字体颜色
		/// </summary>
		[DefaultValue("Black"),Description("进度栏百分比的字体颜色"),Category("Appearance")]
		public Color PercentColor
		{
			get{return percentColor;}
			set
			{
				percentColor=value;
				lb_Percent.ForeColor=percentColor;	
			}
		}
		/// <summary>
		/// 是否显示百分比
		/// </summary>
		[DefaultValue(true),Description("是否显示百分比"),Category("Behavior")]
		public bool ShowPercent
		{
			get{return showPercent;}
			set
			{
				showPercent=value;
				PercentShow();
			}
		}

		/// <summary>
		/// 进度条的颜色外观样式
		/// </summary>
		[DefaultValue("Horizontal"),Description("进度条的颜色外观样式"),Category("Appearance")]
		public ShowFaceStyle FaceStyle
		{
			get{return showStyle;}
			set
			{
				showStyle=value;
				Invalidate();
			}
		}

		/// <summary>
		/// 获取和设置进度条的类型（横向、纵向）
		/// </summary>
		[DefaultValue("Horizontal"),Description("获取和设置进度条的类型（横向、纵向）"),Category("Appearance")]
		public ShowGuageType GuageType
		{
			get{return showType;}
			set
			{
				showType=value;
				int height=this.Size.Height;
				int width=this.Size.Width;
				Point point=new Point(this.Left,this.Top);
				if(value==ShowGuageType.Vertical)
				{					
					this.Top=point.Y-width;					
//					showPercent=false;
					tempWidth=width;
				}
				else
				{
					this.Top=point.Y+height;		
//					showPercent=true;
					tempWidth=height;
				}
				this.Width=height;
				this.Height=width;
				myWidth=tempWidth * (m_value/maximum);
				PercentShow();
				Invalidate();
			}
		}

		/// <summary>
		/// 阴影渐变的宽度大小，只有进度条类型是Horizontal且进度条颜色外观样式是Horizontal才有效
		/// </summary>
		[DefaultValue("30"),Description("阴影渐变的宽度大小，只有进度条类型是Horizontal且进度条颜色外观样式是Horizontal才有效"),Category("Appearance")]
		public int ShadowSize
		{
			get{return shadowSize;}
			set
			{	
				if(value<0) shadowSize=0;
				else shadowSize=value;
				Invalidate();
			}
		}
		#endregion

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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
			this.lb_Percent = new Label();
			this.SuspendLayout();
			// 
			// lb_Percent
			// 
			this.lb_Percent.AutoSize = true;
			this.lb_Percent.BackColor = System.Drawing.Color.Transparent;
			this.lb_Percent.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lb_Percent.ForeColor = System.Drawing.Color.Black;
			this.lb_Percent.Location = new System.Drawing.Point(88, 4);
			this.lb_Percent.Name = "lb_Percent";
			this.lb_Percent.Size = new System.Drawing.Size(0, 19);
			this.lb_Percent.TabIndex = 0;
			this.lb_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GuageBar
			// 
			this.Controls.Add(this.lb_Percent);
			this.Name = "GuageBarEx";
			this.Size = new System.Drawing.Size(208, 24);
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// 按照Step属性的数量增加进度栏的当前位置
		/// </summary>
		public void PerformStep()
		{
			float ff=m_value+step;
			if(ff>=maximum) m_value=maximum;
			else if(ff<=minimum) m_value=minimum;
			else m_value=ff;
			myWidth=tempWidth * (m_value/maximum);			
			Invalidate();
			PercentShow();
		}

		private void PercentShow()
		{
			if(showPercent && showType==ShowGuageType.Horizontal)//横向才能显示百分比
			{
				lb_Percent.Text=Convert.ToString(Math.Round(100*m_value/maximum))+"%";
				lb_Percent.Font= new System.Drawing.Font(Font.Name,(Height*3)/4,System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				lb_Percent.ForeColor=percentColor;	
				lb_Percent.Left=(this.Size.Width-lb_Percent.Width)/2;
				lb_Percent.Top=(this.Size.Height-lb_Percent.Height)/2;
			}
			else 
			{
					lb_Percent.Text="";
			}
			//刷新
			Refresh();
		}
		/// <summary>
		/// OnPaint
		/// </summary>
		/// <param name="pe"></param>
		protected override void OnPaint( PaintEventArgs pe )
		{	
			if(showType==ShowGuageType.Horizontal)//横向
			{
				if(showStyle==ShowFaceStyle.Horizontal)
				{
					using(Brush MyBrush = new System.Drawing.Drawing2D.LinearGradientBrush( ClientRectangle, m_Color1, m_Color2, 10 ))
					{
						pe.Graphics.FillRectangle(MyBrush,0,0,myWidth-1,this.Size.Height-1);
					}
				}
				else if(showStyle==ShowFaceStyle.Vertical)
				{
					Rectangle rec=new Rectangle(0,0,Convert.ToInt32(myWidth)-1,this.Size.Height-1);
					//申明渐变的轨迹
					float[] relativeIntensities = {0.9f,0.45f, 1.0f}; 
					float[] relativePositions = {0.0f,0.55f, 1.0f};
					//定义渐变对象
					Blend blend=new Blend();
					blend.Factors=relativeIntensities;
					blend.Positions=relativePositions;
					//定义渐变的画刷
					using(LinearGradientBrush brushBackground=
							  new LinearGradientBrush( ClientRectangle,m_Color2,m_Color1,LinearGradientMode.Vertical))
					{
						brushBackground.Blend=blend;
						//绘制窗口区域
						pe.Graphics.FillRectangle(brushBackground,rec);
					}
				}
				else
				{
//					Rectangle rec=new Rectangle(0,0,this.Size.Width-1,this.Size.Height-1);
//					//申明渐变的轨迹
//					float[] relativeIntensities = {1.0f,0.0f, 1.0f}; 
//					float[] relativePositions = {0.0f,m_value/maximum, 1.0f};
//					//定义渐变对象
//					Blend blend=new Blend();
//					blend.Factors=relativeIntensities;
//					blend.Positions=relativePositions;
//					//定义渐变的画刷
//					using(LinearGradientBrush brushBackground=
//							  new LinearGradientBrush( ClientRectangle,m_Color2,m_Color1,LinearGradientMode.Horizontal))
//					{					
//						brushBackground.Blend=blend;
//						//绘制窗口区域
//						pe.Graphics.FillRectangle(brushBackground,rec);
//					}
					

					bool useLeftBrush = false;
					bool useRightBrush = false;
					
					Rectangle left = ClientRectangle;
					Rectangle right = ClientRectangle;
					Rectangle leftFill = ClientRectangle;
					Rectangle rightFill = ClientRectangle;
					Rectangle partialLeft = ClientRectangle;
					Rectangle partialRight = ClientRectangle;

					int gradientSize = (int)((float)(shadowSize/2)*((float)ClientRectangle.Width/100));//默认使用30宽度

					left.Width = gradientSize;
					left.X = (int)myWidth - gradientSize;
					right.X = (int)myWidth;
					right.Width = gradientSize;
					leftFill.Width = (int)myWidth - gradientSize;
					rightFill.X = (int)myWidth + gradientSize;
					rightFill.Width = ClientRectangle.Width - ((int)myWidth + gradientSize);
			
					if ( (myWidth + gradientSize) > ClientRectangle.Width )
					{
						useRightBrush = true;
						partialRight.X = -(ClientRectangle.Width - (int)myWidth + ClientRectangle.Left);
						partialRight.Width = gradientSize;
						leftFill.X = partialRight.X + gradientSize;
						leftFill.Width -= (partialRight.X + gradientSize);
					}

					if ( myWidth < gradientSize )
					{
						useLeftBrush = true;
						partialLeft.X = (ClientRectangle.Width - gradientSize) + (int)myWidth;
						partialLeft.Width = gradientSize;
						rightFill.X = right.X + gradientSize;
						rightFill.Width = partialLeft.X - rightFill.X;
					}

					if ( useRightBrush )
					{
						using ( Brush b = new LinearGradientBrush(partialRight, m_Color2, m_Color1, 0, true) )
						{
							pe.Graphics.FillRectangle(b, partialRight);
							//左右两个用LinearGradientBrush填充后之间交界处有一竖线空白，用开始的颜色划上
							using ( Pen p = new Pen(m_Color2) )
							{
								pe.Graphics.DrawLine(p, partialRight.Left, partialRight.Top, partialRight.Left, partialRight.Bottom);
							}
						}
					}

					if ( useLeftBrush )
					{
						using ( Brush b = new LinearGradientBrush(partialLeft, m_Color1, m_Color2, 0, true) )
						{
							pe.Graphics.FillRectangle(b, partialLeft);

							using ( Pen p = new Pen(m_Color1) )
							{
								pe.Graphics.DrawLine(p, partialLeft.Left, partialLeft.Top, partialLeft.Left, partialLeft.Bottom);
							}
						}
					}

					using ( Brush b = new SolidBrush(m_Color1) )
					{
						pe.Graphics.FillRectangle(b, leftFill);
					}

					if ( left.Width > 0 )
					{
						using ( Brush b = new LinearGradientBrush(left, m_Color1, m_Color2, LinearGradientMode.Horizontal) )
						{
							pe.Graphics.FillRectangle(b, left);

							using ( Pen p = new Pen(m_Color1) )
							{
								pe.Graphics.DrawLine(p, left.Left, left.Top, left.Left, left.Bottom);
							}
						}
					}
		
					if ( right.Width > 0 )
					{
						using ( Brush b = new LinearGradientBrush(right, m_Color2, m_Color1, 0, true) )
						{
							pe.Graphics.FillRectangle(b, right);

							using ( Pen p = new Pen(m_Color2) )
							{
								pe.Graphics.DrawLine(p, right.Left, right.Top, right.Left, right.Bottom);
							}
						}
					}

					using ( Brush b = new SolidBrush(m_Color1) )
					{
						pe.Graphics.FillRectangle(b, rightFill);
					}
				}
					
			}
			else //纵向
			{
				if(showStyle==ShowFaceStyle.Horizontal)
				{
					using(Brush MyBrush = new System.Drawing.Drawing2D.LinearGradientBrush( ClientRectangle, m_Color2, m_Color1,100 ))
					{
						pe.Graphics.FillRectangle(MyBrush,0,this.Size.Height-myWidth,this.Size.Width-1,myWidth-1);
					}
				}
				else if(showStyle==ShowFaceStyle.Vertical)
				{
					Rectangle rec=new Rectangle(0,this.Size.Height-Convert.ToInt32(myWidth),this.Size.Width-1,Convert.ToInt32(myWidth)-1);
					//申明渐变的轨迹
					float[] relativeIntensities = {0.9f,0.45f, 1.0f}; 
					float[] relativePositions = {0.0f,0.55f, 1.0f};
					//定义渐变对象
					Blend blend=new Blend();
					blend.Factors=relativeIntensities;
					blend.Positions=relativePositions;
					//定义渐变的画刷
					using(LinearGradientBrush brushBackground=
							  new LinearGradientBrush( ClientRectangle,m_Color2,m_Color1,LinearGradientMode.Horizontal))
					{
						brushBackground.Blend=blend;
						//绘制窗口区域
						pe.Graphics.FillRectangle(brushBackground,rec);
					}
				}
				else
				{
					Rectangle rec=new Rectangle(0,0,this.Size.Width-1,this.Size.Height-1);
					//申明渐变的轨迹
					float[] relativeIntensities = {1.0f,0.0f, 1.0f}; 
					float[] relativePositions = {0.0f,1-m_value/maximum, 1.0f};
					//定义渐变对象
					Blend blend=new Blend();
					blend.Factors=relativeIntensities;
					blend.Positions=relativePositions;
					//定义渐变的画刷
					using(LinearGradientBrush brushBackground=
							  new LinearGradientBrush( ClientRectangle,m_Color2,m_Color1,LinearGradientMode.Vertical))
					{					
						brushBackground.Blend=blend;
						//绘制窗口区域
						pe.Graphics.FillRectangle(brushBackground,rec);
					}
				}
			}
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
                case TrasenClasses.GeneralControls.BorderStyle.Raised:
					pe.Graphics.DrawLine(new Pen(Color.White),0,0,this.Size.Width-1,0);
					pe.Graphics.DrawLine(new Pen(Color.White),0,0,0,this.Size.Height-2);
					pe.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace,2),this.Size.Width-1,0,this.Size.Width-1,this.Size.Height-1);
					pe.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace,2),1,this.Size.Height-1,this.Size.Width,this.Size.Height-1);
					break;
                case TrasenClasses.GeneralControls.BorderStyle.None:
					break;
			}
			base.OnPaint (pe);
		}
		/// <summary>
		/// OnResize
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{	
			if(showType==ShowGuageType.Horizontal) tempWidth=this.Size.Width;
			else tempWidth=this.Size.Height;
			myWidth=tempWidth * (m_value/maximum);
			Invalidate();
			PercentShow();
			base.OnResize (e);
		}

	}
}
