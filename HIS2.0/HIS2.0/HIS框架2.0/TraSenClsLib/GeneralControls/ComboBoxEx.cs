using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// 具有下拉网格的组合框
	/// </summary>
	public class ComboBoxEx : TextBoxEx
	{
		//私有变量
		private DataTable _dataSource;
		private string _displayMember;
		private string _displayMemberCaption;
		private string _valueMember;
		private string _valueMemberCaption;
		private int _dropDownWidth;
		private int _dropDownHeight;
		private object _selectedValue;
		private int _selectedIndex;
		private int _gridCurrentRowNumber;
		private bool _textChangedVailid;

		private const int BUTTONWIDTH=16;
		private const int OFFSET=4;

		private DataGridEx cardGrid;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private Button dropButton;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 具有下拉网格的组合框
		/// </summary>
		/// <param name="container"></param>
		public ComboBoxEx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			_dataSource=null;
			_displayMember="";
			_displayMemberCaption="";
			_valueMember="";
			_valueMemberCaption="";
			_dropDownWidth=180;
			_dropDownHeight=160;
			_selectedValue=null;
			_selectedIndex=-1;
			_gridCurrentRowNumber=-1;
			_textChangedVailid=true;
			InitializeComponent();
		}
		/// <summary>
		/// 具有下拉网格的组合框
		/// </summary>
		public ComboBoxEx()
		{
			_dataSource=null;
			_displayMember="";
			_displayMemberCaption="";
			_valueMember="";
			_valueMemberCaption="";
			_dropDownWidth=180;
			_dropDownHeight=160;
			_selectedValue=null;
			_selectedIndex=-1;
			_gridCurrentRowNumber=-1;
			_textChangedVailid=true;
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

		#region 自定义事件
		/// <summary>
		/// 组合框下拉激发的事件
		/// </summary>
		public event EventHandler DropDown;
		/// <summary>
		/// 在更改SelectValue属性的值激发的事件
		/// </summary>
		public event EventHandler SelectedValueChanged;
		/// <summary>
		/// 在更改SelectedValue属性的索引值激发的事件
		/// </summary>
		public event EventHandler SelectedIndexChanged;
		#endregion

		#region 自定义方法
		/// <summary>
		/// 选取特定值
		/// </summary>
		/// <param name="selValue">要选取的值</param>
		public void SetSelectItem(object selValue)
		{
			if(_dataSource!=null)
			{
				
				string valueStr;
				for(int i=0;i<_dataSource.Rows.Count;i++)
				{
					valueStr=_dataSource.Rows[i][_valueMember].ToString();
					if(valueStr.Trim()==selValue.ToString())
					{
						_selectedValue =Convertor.IsNull(_dataSource.Rows[i][_valueMember],"-1");
						_selectedIndex=i;
						_textChangedVailid=false;
						this.Text =Convertor.IsNull(_dataSource.Rows[i][_displayMember],"");
						_textChangedVailid=true;
						if(_gridCurrentRowNumber!=_selectedIndex)
						{
							_gridCurrentRowNumber=_selectedIndex;
							if(SelectedIndexChanged!=null)
							{
								SelectedIndexChanged(this,null);
							}
							if(SelectedValueChanged!=null)
							{
								SelectedValueChanged(this,null);
							}
						}
						return;
					}
				}
				//没有查找到匹配的项目
				_selectedIndex=-1;
				_textChangedVailid=false;
				this.Text ="";
				_textChangedVailid=true;

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
			this.cardGrid = new TrasenClasses.GeneralControls.DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dropButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// cardGrid
			// 
			this.cardGrid.AllowSorting = false;
			this.cardGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.cardGrid.CaptionVisible = false;
			this.cardGrid.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
			this.cardGrid.DataMember = "";
			this.cardGrid.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cardGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.cardGrid.Location = new System.Drawing.Point(133, 0);
			this.cardGrid.Name = "cardGrid";
			this.cardGrid.ReadOnly = true;
			this.cardGrid.RowHeaderWidth = 0;
			this.cardGrid.TabIndex = 1;
			this.cardGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.dataGridTableStyle1});
			this.cardGrid.Visible = false;
			this.cardGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cardGrid_KeyDown);
			this.cardGrid.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.cardGrid_myKeyDown);
			this.cardGrid.Click += new System.EventHandler(this.cardGrid_Click);
			this.cardGrid.CurrentCellChanged += new System.EventHandler(this.cardGrid_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.DataGrid = this.cardGrid;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "ITEM_DB";
			this.dataGridTableStyle1.ReadOnly = true;
			this.dataGridTableStyle1.RowHeaderWidth = 0;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "编码";
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 60;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "名称";
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.NullText = "";
			// 
			// dropButton
			// 
			this.dropButton.BackColor = System.Drawing.SystemColors.Control;
			this.dropButton.Cursor = System.Windows.Forms.Cursors.Default;
			this.dropButton.Location = new System.Drawing.Point(20, 0);
			this.dropButton.Name = "dropButton";
			this.dropButton.Size = new System.Drawing.Size(20, 20);
			this.dropButton.TabIndex = 0;
			this.dropButton.Click += new System.EventHandler(this.dropButton_Click);
			// 
			// ComboBoxEx
			// 
			this.Controls.Add(this.dropButton);
			this.Controls.Add(this.cardGrid);
			((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region 属性
		/// <summary>
		/// 指示该控件将用来获取其项的列表
		/// </summary>
		[DefaultValue("无"),Description("指示该控件将用来获取其项的列表"),Category("Data")]
		public DataTable DataSource
		{
			get
			{
				return _dataSource;
			}
			set
			{
				if(value!=null)
				{
					_dataSource=value.Clone();
					DataRow[] rows=value.Select("",_valueMember);	//排序
					for(int i=0;i<rows.Length;i++)
					{
						_dataSource.Rows.Add(rows[i].ItemArray);
					}
					_dataSource.TableName ="ITEM_DB";
					this.cardGrid.DataSource =_dataSource;
					PubStaticFun.ModifyDataGridStyle(this.cardGrid,0);
				}
			}
		}
		/// <summary>
		/// 指示要为该控件中的项显示的属性
		/// </summary>
		[DefaultValue(""),Description("指示要为该控件中的项显示的属性"),Category("Data")]
		public string DisplayMember
		{
			get
			{
				return _displayMember;
			}
			set
			{
				_displayMember=value;
				this.dataGridTextBoxColumn2.MappingName = _displayMember;
			}
		}
		/// <summary>
		/// 指示要为该控件中的项显示的属性
		/// </summary>
		[DefaultValue(""),Description("指示用作该控件中项的实际值的属性"),Category("Data")]
		public string ValueMember
		{
			get
			{
				return _valueMember;
			}
			set
			{
				_valueMember=value;
				this.dataGridTextBoxColumn1.MappingName = _valueMember;
			}
		}
		/// <summary>
		/// 指示要为该控件中的项显示的属性的列标头
		/// </summary>
		[DefaultValue(""),Description("指示要为该控件中的项显示的属性的列标头"),Category("Data")]
		public string DisplayMemberCaption
		{
			get
			{
				return _displayMemberCaption;
			}
			set
			{
				_displayMemberCaption=value;
				this.dataGridTextBoxColumn2.HeaderText =_displayMemberCaption;
			}
		}
		/// <summary>
		/// 指示用作该控件中项的实际值的属性的列标头
		/// </summary>
		[DefaultValue(""),Description("指示用作该控件中项的实际值的属性的列标头"),Category("Data")]
		public string ValueMemberCaption
		{
			get
			{
				return _valueMemberCaption;
			}
			set
			{
				_valueMemberCaption=value;
				this.dataGridTextBoxColumn1.HeaderText =_valueMemberCaption;
			}
		}
		/// <summary>
		/// 获取或设置由ValueMember属性指定的成员属性的值
		/// </summary>
		[DefaultValue(""),Description("获取或设置由ValueMember属性指定的成员属性的值"),Category("Data"),Browsable(false)]
		public object SelectedValue
		{
			get
			{
				return _selectedValue;
			}
			set
			{
				SetSelectItem(value);
			}
		}
		/// <summary>
		/// 获取或设置由ValueMember属性指定的成员属性的索引
		/// </summary>
		[DefaultValue(""),Description("获取或设置由ValueMember属性指定的成员属性的索引"),Category("Data"),Browsable(false)]
		public int SelectedIndex
		{
			get
			{
				return _selectedIndex;
			}
			set
			{
				_selectedIndex=value;
				if(_dataSource!=null && _selectedIndex>=0)
				{
					_selectedValue =Convertor.IsNull(_dataSource.Rows[_selectedIndex][_valueMember],"-1");
					_textChangedVailid=false;
					this.Text =Convertor.IsNull(_dataSource.Rows[_selectedIndex][_displayMember],"");
					_textChangedVailid=true;
					if(_gridCurrentRowNumber!=_selectedIndex)
					{
						_gridCurrentRowNumber=_selectedIndex;
						if(SelectedIndexChanged!=null)
						{
							SelectedIndexChanged(this,null);
						}
						if(SelectedValueChanged!=null)
						{
							SelectedValueChanged(this,null);
						}
					}
				}
				else
				{
					_selectedValue="-1";
					_textChangedVailid=false;
					this.Text ="";
					_textChangedVailid=true;
				}
			}
		}
		/// <summary>
		/// 指示要为该控件中的项显示的属性的列宽
		/// </summary>
		[DefaultValue("100"),Description("指示要为该控件中的项显示的属性的列宽"),Category("Behavior")]
		public int DisplayMemberWidth
		{
			get
			{
				return this.dataGridTextBoxColumn2.Width;
			}
			set
			{
				this.dataGridTextBoxColumn2.Width =value;
			}
		}
		/// <summary>
		/// 指示用作该控件中项的实际值的属性的列宽
		/// </summary>
		[DefaultValue("60"),Description("指示用作该控件中项的实际值的属性的列宽"),Category("Behavior")]
		public int ValueMemberWidth
		{
			get
			{
				return this.dataGridTextBoxColumn1.Width;
			}
			set
			{
				this.dataGridTextBoxColumn1.Width =value;
			}
		}
		/// <summary>
		/// 获取和设置下拉网格宽度
		/// </summary>
		[DefaultValue("180"),Description("获取和设置下拉网格宽度"),Category("Behavior")]
		public int DropDownWidth
		{
			get
			{
				return _dropDownWidth;
			}
			set 
			{
				_dropDownWidth=value;
				cardGrid.Width =_dropDownWidth;
			}
		}
		/// <summary>
		/// 获取和设置下拉网格宽度
		/// </summary>
		[DefaultValue("150"),Description("获取和设置下拉网格高度"),Category("Behavior")]
		public int DropDownHeight
		{
			get
			{
				return _dropDownHeight;
			}
			set 
			{
				_dropDownHeight=value;
				cardGrid.Height=_dropDownHeight;
			}
		}
		#endregion

		#region 重写事件
		/// <summary>
		///  重写OnEnter事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnEnter(EventArgs e)
		{
			this.SelectAll();
			base.OnEnter (e);
		}
		/// <summary>
		///  重写OnLeave事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLeave(EventArgs e)
		{
			if(!this.cardGrid.Focused && !this.dropButton.Focused)
			{
				this.cardGrid.Visible =false;
			}
			base.OnLeave (e);
		}

		/// <summary>
		///  重写OnKeyDown事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(_dataSource!=null && this.cardGrid.Visible)
			{
				if(this.cardGrid.CurrentRowIndex<_dataSource.Rows.Count)
				{
					switch(e.KeyCode)
					{
						case Keys.Up :
							if(cardGrid.CurrentRowIndex>0)
							{
								cardGrid.CurrentRowIndex-=1;
							}
							else
							{
								cardGrid.CurrentRowIndex=_dataSource.Rows.Count-1;
							}
							break;
						case Keys.Down :
							if(cardGrid.CurrentRowIndex<_dataSource.Rows.Count-1)
							{
								cardGrid.CurrentRowIndex+=1;
							}
							else
							{
								cardGrid.CurrentRowIndex=0;
							}
							break;
						case Keys.Enter :
							if (this.cardGrid.CurrentRowIndex == -1 ) return;
							_selectedValue =Convertor.IsNull(_dataSource.Rows[this.cardGrid.CurrentRowIndex][_valueMember],"-1");
							_textChangedVailid=false;
							this.Text =Convertor.IsNull(_dataSource.Rows[this.cardGrid.CurrentRowIndex][_displayMember],"");
							_textChangedVailid=true;
							_gridCurrentRowNumber=this.cardGrid.CurrentRowIndex;
							if(_selectedIndex!=_gridCurrentRowNumber)
							{
								_selectedIndex=_gridCurrentRowNumber;
								if(SelectedIndexChanged!=null)
								{
									SelectedIndexChanged(this,null);
								}
								if(SelectedValueChanged!=null)
								{
									SelectedValueChanged(this,(EventArgs)e);
								}
							}
							this.cardGrid.Visible =false;
							break;
						case Keys.Escape :
							this.cardGrid.Visible=false;
							break;
						default :
							break;
					}
					this.SelectionStart =this.Text.Length;
				}
			}
			base.OnKeyDown (e);
		}


		/// <summary>
		/// 重写OnTextChanged事件,定位相应数据行
		/// </summary>
		/// <param name="e"></param>
		protected override void OnTextChanged(EventArgs e)
		{
			if(_dataSource!=null && _textChangedVailid)
			{
				ViewDataGrid();
				if(this.cardGrid.Visible)
				{
					string valueStr;
					int cols=this.cardGrid.TableStyles[0].GridColumnStyles.Count;
					for(int i=0;i<_dataSource.Rows.Count;i++)
					{
						valueStr=Convertor.IsNull(_dataSource.Rows[i][_valueMember],"-1");
						if(valueStr.ToLower().IndexOf(this.Text.Trim().ToLower())>=0)
						{
							this.cardGrid.CurrentCell =new DataGridCell(i,cols-1);
							return;
						}
					}
				}
			}
			base.OnTextChanged (e);
		}

		/// <summary>
		/// 重写OnCreateControl事件：定位BUTTON
		/// </summary>
		protected override void OnCreateControl()
		{
			this.dropButton.Size =new Size(BUTTONWIDTH,this.Height-OFFSET);
			this.dropButton.Location=new Point(this.Width-this.dropButton.Width-OFFSET,0);
			this.cardGrid.Font =this.Font;
			this.cardGrid.Width=_dropDownWidth>this.Width ? _dropDownWidth:this.Width;
			this.cardGrid.Height=_dropDownHeight;
			base.OnCreateControl ();
		}
		/// <summary>
		/// 重写OnCreateControl事件：重新定位BUTTON
		/// </summary>
		/// <param name="e"></param>
		protected override void OnSizeChanged(EventArgs e)
		{
			this.dropButton.Size =new Size(BUTTONWIDTH,this.Height-OFFSET);
			this.dropButton.Location=new Point(this.Width-this.dropButton.Width-OFFSET,0);
			base.OnSizeChanged (e);
		}
		
		#endregion

		#region SHOWCARD网格
		private void cardGrid_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid grid=(DataGrid)sender;
			for(int i=0;i<((DataTable)grid.DataSource).Rows.Count;i++)
			{
				grid.UnSelect(i);
			}
			grid.Select(grid.CurrentCell.RowNumber);
		}

		private void cardGrid_Click(object sender, System.EventArgs e)
		{
			this.Focus();
			this.OnKeyDown(new KeyEventArgs(Keys.Enter));
		}
		private void cardGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Enter)
			{
				cardGrid_Click(null,null);
			}
		}
		private bool cardGrid_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			if(keyData ==Keys.Enter)
			{
				cardGrid_Click(null,null);
			}
			return false;
		}
		#endregion

		#region 按钮
		private void dropButton_Click(object sender, System.EventArgs e)
		{
			if(this.cardGrid.Visible)
			{
				this.cardGrid.Visible =false;
			}
			else
			{
				ViewDataGrid();
				int cols=this.cardGrid.TableStyles[0].GridColumnStyles.Count;
				if(_gridCurrentRowNumber>=0)
				{
					this.cardGrid.CurrentCell =new DataGridCell(_gridCurrentRowNumber,cols-1);
				}
				if(DropDown!=null)
				{
					DropDown(sender,e);
				}
			}
		}
		#endregion

		#region 显示网格
		private void ViewDataGrid()
		{
			if(_dataSource!=null)
			{
				PubStaticFun.SetCardGridTopAndLeft(this,cardGrid,this.Parent,this.Top,this.Left);
				cardGrid.Visible =true;
				this.Focus();
				this.SelectionStart =this.Text.Length;
			}
		}
		#endregion
	}
}
