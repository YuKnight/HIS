using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// 显示模式
	/// </summary>
	public enum ViewMode
	{
		/// <summary>
		/// 大图标
		/// </summary>
		LargeIcon,
		/// <summary>
		/// 小图标
		/// </summary>
		SmallIcon
	}
	/// <summary>
	/// ListViewEx 的摘要说明。
	/// ListView的四个角是圆弧，可改变圆弧的大小
	/// </summary>
	public class ListImage : System.Windows.Forms.Panel
	{
		private System.Windows.Forms.ImageList _largeImageList;
		private System.Windows.Forms.ImageList _smallImageList;
		private System.Windows.Forms.ImageList _captionImageList;
		private int _captionImageIndex;
		private ListImagetemCollection _items;
		private ListImageItem _selectedItem;
		private Color _selectedBackColor;
		private Color _selectedForeColor;
		private int _selectedIndex;
		private int _vInterval=5;		//垂直间隔
		private int _hInterval=20;		//水平间隔
		private ViewMode _view;
		private string _captionText;
		private Color _captionBackColor;
		private Color _captionForeColor;
		private Font _captionFont;
		private bool _captionVisible;
		private const int MARGIN=5;				//边距
		private const int INTERVAL=2;			//图片与文字间隔
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 自定义ListView
		/// </summary>
		/// <param name="container"></param>
		public ListImage(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			_largeImageList=null;
			_smallImageList=null;
			_captionImageList=null;
			_captionImageIndex=-1;
			_items=new ListImagetemCollection();
			_selectedItem=null;
			_selectedIndex=-1;
			_items.InsertComplete+=new TrasenClasses.GeneralControls.ListImagetemCollection.ItemChangedEventHandler(Items_InsertComplete);
			_items.RemoveComplete+=new TrasenClasses.GeneralControls.ListImagetemCollection.ItemChangedEventHandler(Items_RemoveComplete);
			_items.ClearComplete +=new EventHandler(Items_ClearComplete);
			this.AutoScroll =true;
			this.BackColor =SystemColors.Window;
			_selectedBackColor=SystemColors.Window;
			_selectedForeColor=SystemColors.WindowText;
			_view=ViewMode.LargeIcon;
			_captionText="";
			_captionBackColor=SystemColors.Control;
			_captionForeColor=SystemColors.WindowText;
			_captionFont=this.Font;
			_captionVisible=false;
			InitializeComponent();
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		public ListImage()
		{
			_largeImageList=null;
			_smallImageList=null;
			_captionImageList=null;
			_captionImageIndex=-1;
			_items=new ListImagetemCollection();
			_selectedItem=null;
			_selectedIndex=-1;
			_items.InsertComplete+=new TrasenClasses.GeneralControls.ListImagetemCollection.ItemChangedEventHandler(Items_InsertComplete);
			_items.RemoveComplete+=new TrasenClasses.GeneralControls.ListImagetemCollection.ItemChangedEventHandler(Items_RemoveComplete);
			_items.ClearComplete +=new EventHandler(Items_ClearComplete);
			this.AutoScroll =true;
			this.BackColor =SystemColors.Window;
			_selectedBackColor=SystemColors.Window;
			_selectedForeColor=SystemColors.WindowText;
			_view=ViewMode.LargeIcon;
			_captionText="";
			_captionBackColor=SystemColors.Control;
			_captionForeColor=SystemColors.WindowText;
			_captionFont=this.Font;
			_captionVisible=false;
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

		#region 事件
		/// <summary>
		/// 在更改SelectedValue属性的索引值激发的事件
		/// </summary>
		public event EventHandler SelectedIndexChanged;
		/// <summary>
		/// 在双击子项目激发的事件
		/// </summary>
		public event EventHandler ItemDoubleClick;
		#endregion

		#region 属性
		/// <summary>
		/// 获取或设置显示模式为大图标时ImageList控件
		/// </summary>
		[DefaultValue("无"),Description("获取或设置显示模式为大图标时ImageList控件"),Category("Behavior")]
		public System.Windows.Forms.ImageList LargeImageList
		{
			get
			{
				return _largeImageList;
			}
			set
			{
				_largeImageList=value;
				for(int i=0;i<_items.Count;i++)
				{
					_items[i].LargeImageList =_largeImageList;
				}
				this.Refresh();
			}
		}
		/// <summary>
		/// 获取或设置显示模式为小图标时ImageList控件
		/// </summary>
		[DefaultValue("无"),Description("获取或设置显示模式为小图标时ImageList控件"),Category("Behavior")]
		public System.Windows.Forms.ImageList SmallImageList
		{
			get
			{
				return _smallImageList;
			}
			set
			{
				_smallImageList=value;
				for(int i=0;i<_items.Count;i++)
				{
					_items[i].SmallImageList =_smallImageList;
				}
				this.Refresh();
			}
		}
		/// <summary>
		/// 获取包含该控件中所有项的集合
		/// </summary>
		[Description("ListImage中的ListImageItem"),DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ListImagetemCollection Items
		{
			get
			{
				return _items;
			}
		}
		/// <summary>
		/// 项目与项目之间在垂直方向上的间隔
		/// </summary>
		[DefaultValue("5"),Description("项目与项目之间在垂直方向上的间隔"),Category("Behavior")]
		public int VerticalInterval
		{
			get
			{
				return _vInterval;
			}
			set
			{
				_vInterval =value;
				for(int i=0;i<_items.Count;i++)
				{
					if(i==0)
					{
						_items[i].Top =_vInterval;
					}
					else
					{
						_items[i].Top =_vInterval+_items[i-1].Top+_items[i-1].Height;
					}
				}
			}
		}
		/// <summary>
		/// 项目与边框在水平方向上的间隔
		/// </summary>
		[DefaultValue("15"),Description("项目与边框在水平方向上的间隔"),Category("Behavior")]
		public int HorizontalInterval
		{
			get
			{
				return _hInterval;
			}
			set
			{
				_hInterval =value;
				for(int i=0;i<_items.Count;i++)
				{
					_items[i].Width =this.Width-_hInterval*2;
					_items[i].Left =_hInterval;
				}
			}
		}
		/// <summary>
		/// 获得焦点后的背景色
		/// </summary>
		[DefaultValue("Window"),Description("Item选中后的背景色"),Category("Appearance")]
		public Color SelectedBackColor
		{
			get
			{
				return _selectedBackColor;
			}
			set 
			{
				_selectedBackColor=value;
			}
		}
		/// <summary>
		/// 获得焦点后的背景色
		/// </summary>
		[DefaultValue("WindowText"),Description("Item选中后的前景色"),Category("Appearance")]
		public Color SelectedForeColor
		{
			get
			{
				return _selectedForeColor;
			}
			set 
			{
				_selectedForeColor=value;
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
				for(int i=0;i<_items.Count;i++)
				{
					_items[i].View =_view;
				}
			}
		}
		/// <summary>
		/// 获取或设置选中项目
		/// </summary>
		[DefaultValue(""),Description("获取或设置选中项目"),Category("Data"),Browsable(false)]
		public ListImageItem SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem=value;
				this.SelectedIndex =_items.IndexOf(_selectedItem);
			}
		}
		/// <summary>
		/// 获取或设置选中项目的索引
		/// </summary>
		[DefaultValue(""),Description("获取或设置选中项目的索引"),Category("Data"),Browsable(false)]
		public int SelectedIndex
		{
			get
			{
				return _selectedIndex;
			}
			set
			{
				_selectedIndex=value;
				if(_items.Count>0 && _selectedIndex<_items.Count && _selectedIndex>=0)
				{
					//选中后的样式设置
					SetSelectItem(_selectedIndex);
					if(SelectedIndexChanged!=null)
					{
						SelectedIndexChanged(this,null);
					}
				}
				else
				{
					_selectedIndex=-1;
				}
			}
		}
		/// <summary>
		/// 标题前景色
		/// </summary>
		[DefaultValue("WindowText"),Description("标题前景色"),Category("Appearance")]
		public Color CaptionForeColor
		{
			get
			{
				return _captionForeColor;
			}
			set 
			{
				_captionForeColor=value;
				this.Refresh();
			}
		}
		/// <summary>
		/// 标题背景色
		/// </summary>
		[DefaultValue("Control"),Description("标题背景色"),Category("Appearance")]
		public Color CaptionBackColor
		{
			get
			{
				return _captionBackColor;
			}
			set 
			{
				_captionBackColor=value;
				this.Refresh();
			}
		}
		/// <summary>
		/// 标题内容
		/// </summary>
		[DefaultValue(""),Description("标题内容"),Category("Appearance")]
		public string CaptionText
		{
			get
			{
				return _captionText;
			}
			set 
			{
				_captionText=value;
				this.Refresh();
			}
		}
		/// <summary>
		/// 标题字体
		/// </summary>
		[DefaultValue(""),Description("标题字体"),Category("Appearance")]
		public Font CaptionFont
		{
			get
			{
				return _captionFont;
			}
			set 
			{
				_captionFont=value;
				this.Refresh();
			}
		}
		/// <summary>
		/// 是否显示标题
		/// </summary>
		[DefaultValue(""),Description("是否显示标题"),Category("Appearance")]
		public bool CaptionVisible
		{
			get
			{
				return _captionVisible;
			}
			set 
			{
				_captionVisible=value;
				this.Refresh();
			}
		}
		/// <summary>
		/// 获取或设置标题ImageList控件
		/// </summary>
		[DefaultValue("无"),Description("获取或设置标题ImageList控件"),Category("Behavior")]
		public System.Windows.Forms.ImageList CaptionImageList
		{
			get
			{
				return _captionImageList;
			}
			set 
			{
				_captionImageList=value;
				this.Refresh();
			}
		}
		/// <summary>
		/// 获取或设置标题ImageList控件图象索引
		/// </summary>
		[DefaultValue("-1"),Description("获取或设置标题ImageList控件图象索引"),Category("Behavior")]
		public int CaptionImageIndex
		{
			get
			{
				return _captionImageIndex;
			}
			set 
			{
				_captionImageIndex=value;
				this.Refresh();
			}
		}
		#endregion

		#region 方法
		/// <summary>
		/// 设定选中后的样式
		/// </summary>
		/// <param name="selectIndex">要选取项目的索引</param>
		private void SetSelectItem(int selectIndex)
		{
			for(int i=0;i<_items.Count;i++)
			{
				if(i==selectIndex)
				{
					_items[i].BackColor =_selectedBackColor;
					_items[i].ForeColor =_selectedForeColor;
					_items[i].BorderStyle =System.Windows.Forms.BorderStyle.FixedSingle;
					_items[i].Selected =true;
					_selectedItem=_items[i];
				}
				else
				{
					_items[i].BackColor =this.BackColor;
					_items[i].BorderStyle =System.Windows.Forms.BorderStyle.None;
					_items[i].Selected =false;
				}
			}
		}
		/// <summary>
		/// 设置项目位置
		/// </summary>
		private void SetItemLocation()
		{
			for(int i=0;i<_items.Count;i++)
			{
				_items[i].Width =this.Width-_hInterval*2;
				_items[i].Left =_hInterval;
				if(i==0)
				{
					if(_captionVisible)
					{
						_items[i].Top=_vInterval+_captionFont.Height+2;
					}
					else
					{
						_items[i].Top =_vInterval;
					}
				}
				else
				{
					_items[i].Top =_vInterval+_items[i-1].Top+_items[i-1].Height;
				}
			}
		}
		#endregion

		#region 重写事件
		/// <summary>
		/// 重写OnResize，根据控件大小调整ListeViewEx项目位置
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			SetItemLocation();
			base.OnResize(e);
		}
		/// <summary>
		/// 重写OnPaint，绘制Caption
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			SetItemLocation();
			if(_captionVisible)
			{
				RectangleF textArea;						//绘制文本区域
				StringFormat sf=new StringFormat();			//封装文本布局信息
				sf.LineAlignment = StringAlignment.Center;			 
				sf.Alignment = StringAlignment.Near;	
				SolidBrush brush=new SolidBrush(_captionForeColor); 
				SolidBrush backBrush=new SolidBrush(_captionBackColor); 
				e.Graphics.DrawRectangle(Pens.Black,0,0,this.Width,_captionFont.Height+_vInterval);	//画框
				e.Graphics.FillRectangle(backBrush,0,0,this.Width,_captionFont.Height+_vInterval);	//用背景颜色填充
				//图像及标题文本
				if(_captionImageList!=null && _captionImageIndex>=0 && _captionImageIndex<_captionImageList.Images.Count)
				{
					e.Graphics.DrawImage(_captionImageList.Images[_captionImageIndex],MARGIN*2,INTERVAL,_captionImageList.ImageSize.Width,_captionImageList.ImageSize.Height);
					textArea=new RectangleF(MARGIN*2+_captionImageList.ImageSize.Width+INTERVAL,INTERVAL,this.Width-MARGIN-_captionImageList.ImageSize.Width,_captionFont.Height+_vInterval);
				}
				else
				{
					textArea=new RectangleF(MARGIN,INTERVAL,this.Width,_captionFont.Height+_vInterval);
				}
				e.Graphics.DrawString(_captionText,_captionFont,brush,textArea,sf);
			}
			base.OnPaint (e);
		}

		#endregion

		#region 执行
		private void Items_InsertComplete(object sender,ItemChangedEventArgs e)
		{
			if(this.LargeImageList!=null)
			{
				e.Item.LargeImageList =this.LargeImageList;
			}
			if(this.SmallImageList!=null)
			{
				e.Item.SmallImageList =this.SmallImageList;
			}
			e.Item.View =_view;
			e.Item.Width =this.Width-_hInterval*2;
			e.Item.Left =_hInterval;
			e.Item.ForeColor =this.ForeColor;
			if(e.Index==0)
			{
				if(_captionVisible)
				{
					e.Item.Top=_vInterval+_captionFont.Height+2;
				}
				else
				{
					e.Item.Top =_vInterval;
				}
			}
			else
			{
				e.Item.Top =_vInterval+_items[e.Index-1].Top+_items[e.Index-1].Height;
			}
			if(e.Index !=_items.Count-1)		//如果是不是插入到最后
			{
				for(int i=e.Index+1;i<_items.Count-1;i++)
				{
					_items[i].Top =_vInterval+_items[i-1].Top+_items[i-1].Height;
				}
			}
			e.Item.Click+=new EventHandler(Item_Click);
			if(ItemDoubleClick!=null)
			{
				e.Item.DoubleClick +=ItemDoubleClick;
			}
			this.Controls.Add(e.Item);
		}

		private void Items_RemoveComplete(object sender,ItemChangedEventArgs e)
		{
			this.Controls.Remove(e.Item);
		}

		private void Items_ClearComplete(object sender,EventArgs e)
		{
			this.Controls.Clear();
		}
		private void Item_Click(object sender,EventArgs e)
		{
			this.SelectedItem=(ListImageItem)sender;
		}
		#endregion
	}

	#region Class ListImagetemCollection
	//先定义一个数据参数类
	#region class ItemChangedEventArgs
	/// <summary>
	/// 事件参数类
	/// </summary>
	public class ItemChangedEventArgs : EventArgs
	{
		private int _index;
		private ListImageItem _item;
		/// <summary>
		/// 构造一参数对象
		/// </summary>
		public ItemChangedEventArgs()
		{

		}
		/// <summary>
		/// 构造一参数对象
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public ItemChangedEventArgs(int index,ListImageItem item)
		{
			_index=index;
			_item=item;
		}
		/// <summary>
		/// Item索引
		/// </summary>
		public int Index
		{
			get
			{
				return _index;
			}
			set
			{
				_index=value;
			}
		}
		/// <summary>
		/// Item对象
		/// </summary>
		public ListImageItem Item
		{
			get
			{
				return _item;
			}
			set
			{
				_item=value;
			}
		}
	}
	#endregion
	/// <summary>
	/// ListImageItem集合
	/// </summary>
	public class ListImagetemCollection : CollectionBase,IEnumerable
	{
		/// <summary>
		/// ListImageItem集合
		/// </summary>
		public ListImagetemCollection()
		{

		}
		/// <summary>
		/// 定义一个事件的委托，e 为事先定义的事件参数类
		/// </summary>
		public delegate void ItemChangedEventHandler(object sender,ItemChangedEventArgs e);
		/// <summary>
		/// 声明InsertComplete事件
		/// </summary>
		public event ItemChangedEventHandler InsertComplete;
		/// <summary>
		/// 声明RemoveComplete事件
		/// </summary>
		public event ItemChangedEventHandler RemoveComplete;
		/// <summary>
		/// 声明ClearComplete事件
		/// </summary>
		public event EventHandler ClearComplete;

		
		/// <summary>
		/// 添加一TrasenClasses.GeneralControls.ListImageItem到集合中
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int Add(ListImageItem item)
		{
			if(Contains(item)) 
			{
				return -1;
			}
			int index = InnerList.Add(item);
			if(InsertComplete!=null)
			{
				ItemChangedEventArgs e=new ItemChangedEventArgs(index,item);
				InsertComplete(this,e);
			}
			return index;
		}
		/// <summary>
		/// 判断集合中是否包含指定ListImageItem
		/// </summary>
		/// <param name="item">指定ListImageItem</param>
		/// <returns></returns>
		public bool Contains(ListImageItem item)
		{
			return InnerList.Contains(item);
		}
		/// <summary>
		/// 获取指定ListImageItem在集合中的索引
		/// </summary>
		/// <param name="item">指定ListImageItem</param>
		/// <returns></returns>
		public int IndexOf(ListImageItem item)
		{
			return InnerList.IndexOf(item);
		}
		/// <summary>
		/// 从集合中移除指定项
		/// </summary>
		/// <param name="item">指定ListImageItem</param>
		public void Remove(ListImageItem item)
		{
			if(RemoveComplete!=null)
			{
				ItemChangedEventArgs e=new ItemChangedEventArgs(IndexOf(item),item);
				RemoveComplete(this,e);
			}
			InnerList.Remove(item);
		}
		/// <summary>
		/// 向集合中插入指定项
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void Insert(int index, ListImageItem item)
		{
			InnerList.Insert(index, item);
			if(InsertComplete!=null)
			{
				ItemChangedEventArgs e=new ItemChangedEventArgs(index,item);
				InsertComplete(this,e);
			}
		}
		/// <summary>
		/// 根据索引获取指定项
		/// </summary>
		public ListImageItem this[int index]
		{
			get { return (ListImageItem) InnerList[index]; }
			set {  InnerList[index] = value; }
		}
		/// <summary>
		/// 重写OnInsertComplete，插入集合完成后将控件加入父控件
		/// </summary>
		/// <param name="index">从零开始的索引，在该处插入 value</param>
		/// <param name="value">在 index 处的元素的新值</param>
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			if(InsertComplete!=null)
			{
				ItemChangedEventArgs e=new ItemChangedEventArgs(index,(ListImageItem)value);
				InsertComplete(this,e);
			}
		}
		/// <summary>
		/// 重写OnInsertComplete，移除集合完成后将控件从父控件中移除
		/// </summary>
		/// <param name="index">从零开始的索引，可在该位置找到 value</param>
		/// <param name="value">要从 index 移除的元素的值</param>
		protected override void OnRemoveComplete(int index, object value)
		{
			if(RemoveComplete!=null)
			{
				ItemChangedEventArgs e=new ItemChangedEventArgs(index,(ListImageItem)value);
				RemoveComplete(this,e);
			}
			base.OnRemoveComplete (index, value);
		}
		/// <summary>
		/// 重写OnClearComplete，清除集合完成后将控件从父控件中清除
		/// </summary>
		protected override void OnClearComplete()
		{
			if(ClearComplete!=null)
			{
				ClearComplete(this,null);
			}
			base.OnClearComplete ();
		}

	}
	#endregion
}
