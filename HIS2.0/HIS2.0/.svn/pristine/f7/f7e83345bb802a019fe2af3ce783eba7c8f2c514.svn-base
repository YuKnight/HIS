using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// ListImageItemEx 的摘要说明。
	/// </summary>
	public class ListImageItem :System.Windows.Forms.Panel
	{
		private System.Windows.Forms.ImageList _largeImageList;
		private System.Windows.Forms.ImageList _smallImageList;
		private const int MARGIN=5;				//边距
		private const int INTERVAL=2;			//图片与文字间隔
		private int _imageIndex;
		private bool _selected;
		private ViewMode _view;					//显示模式
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		#region 构造函数
		/// <summary>
		/// 自定义ListViewItem
		/// </summary>
		/// <param name="container"></param>
		public ListImageItem(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			this.Text ="";
			_largeImageList=null;
			_smallImageList=null;
			_imageIndex=-1;
			_selected=false;
			InitializeComponent();
		}
		/// <summary>
		/// 自定义ListViewItem
		/// </summary>
		public ListImageItem()
		{
			this.Text ="";
			_largeImageList=null;
			_smallImageList=null;
			_imageIndex=-1;
			_selected=false;
			InitializeComponent();
		}
		/// <summary>
		/// 自定义ListViewItem
		/// </summary>
		/// <param name="itemText">该项文本</param>
		public ListImageItem(string itemText)
		{
			this.Text =itemText;
			_largeImageList=null;
			_smallImageList=null;
			_imageIndex=-1;
			_selected=false;
			InitializeComponent();
		}
		/// <summary>
		/// 自定义ListViewItem
		/// </summary>
		/// <param name="itemText">该项文本</param>
		/// <param name="imageIndex">图像索引</param>
		/// <param name="tag">与该控件关联的数据对象</param>
		public ListImageItem(string itemText,int imageIndex,object tag)
		{
			this.Text =itemText;
			_largeImageList=null;
			_smallImageList=null;
			_imageIndex=imageIndex;
			this.Tag =tag;
			_selected=false;
			InitializeComponent();
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
		/// 获取或设置该项的文本
		/// </summary>
		[DefaultValue(""),Description("获取或设置该项的文本"),Category("Behavior")]
		public string ItemText
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				this.Refresh();
			}
		}

		/// <summary>
		/// 获取或设置该项的大图标ImageList控件
		/// </summary>
		[DefaultValue("无"),Description("获取或设置该项的大图标ImageList控件"),Category("Behavior")]
		public System.Windows.Forms.ImageList LargeImageList
		{
			get
			{
				return _largeImageList;
			}
			set
			{
				_largeImageList=value;
				SetControlHeight();
				this.Refresh();
			}
		}
		/// <summary>
		/// 获取或设置该项的小图标ImageList控件
		/// </summary>
		[DefaultValue("无"),Description("获取或设置该项的小图标ImageList控件"),Category("Behavior")]
		public System.Windows.Forms.ImageList SmallImageList
		{
			get
			{
				return _smallImageList;
			}
			set
			{
				_smallImageList=value;
				SetControlHeight();
				this.Refresh();
			}
		}
		/// <summary>
		/// 指示要为该控件中的项显示的属性
		/// </summary>
		[DefaultValue(""),Description("获取或设置该项的ImageList控件图像索引"),Category("Behavior")]
		public int ImageIndex
		{
			get
			{
				return _imageIndex;
			}
			set
			{
				_imageIndex=value;
				SetControlHeight();
				this.Refresh();
			}
		}
		/// <summary>
		/// 指示要为该控件中的项显示的属性
		/// </summary>
		[DefaultValue("false"),Description("获取该项是否处于选中状态"),Category("Behavior"),Browsable(false)]
		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected=value;
			}
		}
		/// <summary>
		/// 显示模式
		/// </summary>
		[DefaultValue("LargeIcon"),Description("显示模式"),Category("Appearance")]
		public ViewMode View
		{
			get
			{
				return _view;
			}
			set 
			{
				_view=value;
				SetControlHeight();
				this.Refresh();
			}
		}
		#endregion

		#region 方法
		/// <summary>
		/// 设置控件高度
		/// </summary>
		private void SetControlHeight()
		{
			int height=0;
			if(_view==ViewMode.LargeIcon)
			{
				if(_largeImageList!=null && _imageIndex>=0)
				{
					height+=_largeImageList.ImageSize.Height;
				}
				this.Height =height+this.Font.Height+MARGIN*2+INTERVAL;
			}
			else
			{
				this.Height =height+this.Font.Height+INTERVAL*4;
			}
		}
		#endregion

		#region 重写事件
		/// <summary>
		/// 重写OnCreateControl，根据Imagelist图像高度及字体设置该控件高度
		/// </summary>
		protected override void OnCreateControl()
		{
			SetControlHeight();
			base.OnCreateControl();
		}

		/// <summary>
		/// 重写OnPaint事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			RectangleF textArea;						//绘制文本区域
			StringFormat sf=new StringFormat();			//封装文本布局信息
			sf.LineAlignment = StringAlignment.Center;			
			SolidBrush brush=new SolidBrush(this.ForeColor);  
			if(_view==ViewMode.LargeIcon)
			{
				sf.Alignment = StringAlignment.Center;	
				if(_largeImageList!=null && _imageIndex>=0 && _imageIndex<_largeImageList.Images.Count)
				{
					e.Graphics.DrawImage(_largeImageList.Images[_imageIndex],(this.Width-_largeImageList.ImageSize.Width)/2,MARGIN,_largeImageList.ImageSize.Width,_largeImageList.ImageSize.Height);
					textArea=new RectangleF(0,_largeImageList.ImageSize.Height+MARGIN*2,this.Width,this.Font.Height+INTERVAL);
					e.Graphics.DrawString(this.ItemText,this.Font,brush,textArea,sf);
				}
				else
				{
					textArea=new RectangleF(0,0,this.Width,this.Height);
					e.Graphics.DrawString(this.ItemText,this.Font,brush,textArea,sf);
				}
			}
			else
			{
				sf.Alignment = StringAlignment.Near;	
				if(_smallImageList!=null && _imageIndex>=0 && _imageIndex<_smallImageList.Images.Count)
				{
					e.Graphics.DrawImage(_smallImageList.Images[_imageIndex],MARGIN*2,INTERVAL,_smallImageList.ImageSize.Width,_smallImageList.ImageSize.Height);
					textArea=new RectangleF(MARGIN*2+_smallImageList.ImageSize.Width+INTERVAL,INTERVAL,this.Width-MARGIN-_smallImageList.ImageSize.Width,this.Height);
					e.Graphics.DrawString(this.ItemText,this.Font,brush,textArea,sf);
				}
				else
				{
					textArea=new RectangleF(MARGIN,0,this.Width,this.Height);
					e.Graphics.DrawString(this.ItemText,this.Font,brush,textArea,sf);
				}
			}
			base.OnPaint (e);
		}
		/// <summary>
		/// 重写OnMouseEnter，当鼠标滑到控件上时显示控件边框
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseEnter(EventArgs e)
		{
			this.Cursor =Cursors.Hand;
			base.OnMouseEnter (e);
		}
		/// <summary>
		/// 重写OnMouseLeave，当鼠标滑到控件上时不显示控件边框
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			this.Cursor =Cursors.Default;
			base.OnMouseLeave (e);
		}

		#endregion

	}
}
