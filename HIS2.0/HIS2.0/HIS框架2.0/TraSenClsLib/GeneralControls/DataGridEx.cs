using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace TrasenClasses.GeneralControls
{
    /// <summary>
    /// 定义一委托
    /// </summary>
    public delegate bool myDelegate(ref Message msg, Keys keyData);
    /// <summary>
    /// 自定义DataGrid,支持网格内TextBox的KeyDown事件响应
    /// </summary>
    public class DataGridEx : System.Windows.Forms.DataGrid
    {
        /// <summary>
        /// 在网格DataCell有焦点的情况下按下键时发生
        /// </summary>
        public event myDelegate myKeyDown;
        /// <summary>
        /// 在网格DataCell值发生改变时发生
        /// </summary>
        public event DataGridEnableTextBoxColumn.EnableCellEventHandler CellValuesChanged;
        private System.ComponentModel.Container components = null;
        //private GoldPrinter.MisGoldPrinter _misGoldPrinter;
        private Color _cellSelectedBackColor;
        private string _gridPrintTitle;
        private string _gridPrintCaption;
        private string _gridPrintTop;
        private string _gridPrintBottom;
        /// <summary>
        /// 是否显示行头ID
        /// </summary>
        private bool _isShowRowHeadId = false;

        /// <summary>
        /// 实例化
        /// </summary>
        public DataGridEx()
        {
            _cellSelectedBackColor = Color.SkyBlue;
            //申明并实例化，可用带参构造函数指明默认横向显示/打印。
            //_misGoldPrinter = new GoldPrinter.MisGoldPrinter(true);

            _gridPrintTitle = "";
            _gridPrintCaption = "";
            _gridPrintTop = "";
            _gridPrintBottom = "";

            InitializeComponent();
        }
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            //			if ( _misGoldPrinter != null )
            //			{
            //				_misGoldPrinter.Dispose();
            //				_misGoldPrinter = null;		
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
                //				}
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.Name = "DataGridEx";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        #region 属性
        /// <summary>
        /// 水平滚动条
        /// </summary>
        public ScrollBar HScrollBar
        {
            get
            {
                return this.HorizScrollBar;
            }
        }
        /// <summary>
        /// 垂直滚动条
        /// </summary>
        public ScrollBar VScrollBar
        {
            get
            {
                return this.VertScrollBar;
            }
        }
        /// <summary>
        /// 网格单元格选中后背景颜色
        /// </summary>
        [DefaultValue("Window"), Description("网格单元格选中后背景颜色"), Category("Appearance")]
        public Color CellSelectedBackColor
        {
            get
            {
                return _cellSelectedBackColor;
            }
            set
            {
                _cellSelectedBackColor = value;
            }
        }
        /// <summary>
        /// 网格打印主标题
        /// </summary>
        [DefaultValue(""), Description("网格打印主标题"), Category("Behavior")]
        public string GridPrintTitle
        {
            get
            {
                return _gridPrintTitle;
            }
            set
            {
                _gridPrintTitle = value;
            }
        }
        /// <summary>
        /// 网格打印子标题
        /// </summary>
        [DefaultValue(""), Description("网格打印子标题"), Category("Behavior")]
        public string GridPrintCaption
        {
            get
            {
                return _gridPrintCaption;
            }
            set
            {
                _gridPrintCaption = value;
            }
        }
        /// <summary>
        /// 网格打印页顶（可以是以'|'分隔的字符串或一维数组）
        /// </summary>
        [DefaultValue(""), Description("网格打印页顶"), Category("Behavior")]
        public string GridPrintTop
        {
            get
            {
                return _gridPrintTop;
            }
            set
            {
                _gridPrintTop = value;
            }
        }
        /// <summary>
        /// 网格打印页底（可以是以'|'分隔的字符串或一维数组）
        /// </summary>
        [DefaultValue(""), Description("网格打印页底"), Category("Behavior")]
        public string GridPrintBottom
        {
            get
            {
                return _gridPrintBottom;
            }
            set
            {
                _gridPrintBottom = value;
            }
        }
        /// <summary>
        /// 是否显示行头序号
        /// </summary>
        [DefaultValue(false), Description("是否显示行头序号"), Category("Behavior")]
        public bool isShowRowHeadId
        {
            get
            {
                return _isShowRowHeadId;
            }
            set
            {
                _isShowRowHeadId = value;
            }
        }
        #endregion

        #region 方法

        #region 创建网格显示格式
        /// <summary>
        /// 创建网格显示格式
        /// </summary>
        /// <param name="headerText">列标题字符集</param>
        /// <param name="columnMappingName">列匹配字段名称字符集</param>
        /// <param name="columnWidth">列宽度集合</param>
        public void CreateTableStyle(string[] headerText, string[] columnMappingName, int[] columnWidth)
        {
            if (headerText != null && columnMappingName != null && columnWidth != null)
            {
                if (headerText.Length == columnMappingName.Length && headerText.Length == columnWidth.Length)
                {
                    //先清空现有格式
                    this.TableStyles.Clear();
                    DataGridTextBoxColumn aColumnTextColumn;
                    DataGridTableStyle dtgrdTbStyle = new DataGridTableStyle();

                    dtgrdTbStyle.AllowSorting = this.AllowSorting;
                    dtgrdTbStyle.ReadOnly = this.ReadOnly;
                    this.TableStyles.Add(dtgrdTbStyle);
                    for (int i = 0; i < headerText.Length; i++)
                    {
                        aColumnTextColumn = new DataGridTextBoxColumn();
                        aColumnTextColumn.NullText = "";
                        aColumnTextColumn.HeaderText = headerText[i];
                        aColumnTextColumn.MappingName = columnMappingName[i];
                        aColumnTextColumn.Width = columnWidth[i];
                        this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    }

                }
            }
        }
        /// <summary>
        /// 创建网格显示格式
        /// </summary>
        /// <param name="headerText">列标题字符集</param>
        /// <param name="columnMappingName">列匹配字段名称字符集</param>
        /// <param name="columnWidth">列宽度集合</param>
        /// <param name="isCheckBoxStyle">列式样集合（true：CheckBoxStyle,false：TextBoxStyle）</param>
        public void CreateTableStyle(string[] headerText, string[] columnMappingName, int[] columnWidth, bool[] isCheckBoxStyle)
        {
            if (headerText != null && columnMappingName != null && columnWidth != null)
            {
                if (headerText.Length == columnMappingName.Length && headerText.Length == columnWidth.Length)
                {
                    //先清空现有格式
                    this.TableStyles.Clear();
                    DataGridTextBoxColumn aColumnTextColumn;
                    DataGridTableStyle dtgrdTbStyle = new DataGridTableStyle();

                    dtgrdTbStyle.AllowSorting = this.AllowSorting;
                    dtgrdTbStyle.ReadOnly = this.ReadOnly;
                    this.TableStyles.Add(dtgrdTbStyle);
                    for (int i = 0; i < headerText.Length; i++)
                    {
                        if (!isCheckBoxStyle[i])
                        {
                            aColumnTextColumn = new DataGridTextBoxColumn();
                            aColumnTextColumn.NullText = "";
                            aColumnTextColumn.HeaderText = headerText[i];
                            aColumnTextColumn.MappingName = columnMappingName[i];
                            aColumnTextColumn.Width = columnWidth[i];
                            this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                        }
                        else
                        {
                            DataGridBoolColumn colBool = new DataGridBoolColumn();
                            colBool.HeaderText = headerText[i];
                            colBool.MappingName = columnMappingName[i];
                            colBool.NullValue = (short)0;
                            colBool.TrueValue = (short)1;
                            colBool.FalseValue = (short)0;
                            colBool.Width = columnWidth[i];
                            this.TableStyles[0].GridColumnStyles.Add(colBool);
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 创建网格显示格式
        /// </summary>
        /// <param name="headerText">列标题字符集</param>
        /// <param name="columnMappingName">列匹配字段名称字符集</param>
        /// <param name="columnWidth">列宽度集合</param>
        /// <param name="mappingName">匹配的表名</param>
        public void CreateTableStyle(string[] headerText, string[] columnMappingName, int[] columnWidth, string mappingName)
        {
            if (headerText != null && columnMappingName != null && columnWidth != null)
            {
                if (headerText.Length == columnMappingName.Length && headerText.Length == columnWidth.Length)
                {
                    //先清空现有格式
                    this.TableStyles.Clear();
                    DataGridTextBoxColumn aColumnTextColumn;
                    DataGridTableStyle dtgrdTbStyle = new DataGridTableStyle();

                    dtgrdTbStyle.AllowSorting = this.AllowSorting;
                    dtgrdTbStyle.ReadOnly = this.ReadOnly;
                    dtgrdTbStyle.MappingName = mappingName;
                    this.TableStyles.Add(dtgrdTbStyle);
                    for (int i = 0; i < headerText.Length; i++)
                    {
                        aColumnTextColumn = new DataGridTextBoxColumn();
                        aColumnTextColumn.NullText = "";
                        aColumnTextColumn.HeaderText = headerText[i];
                        aColumnTextColumn.MappingName = columnMappingName[i];
                        aColumnTextColumn.Width = columnWidth[i];
                        this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    }

                }
            }
        }
        /// <summary>
        /// 创建网格显示格式
        /// </summary>
        /// <param name="headerText">列标题字符集</param>
        /// <param name="columnMappingName">列匹配字段名称字符集</param>
        /// <param name="columnWidth">列宽度集合</param>
        /// <param name="rowHeaderWidth">行标头宽度</param>
        public void CreateTableStyle(string[] headerText, string[] columnMappingName, int[] columnWidth, int rowHeaderWidth)
        {
            if (headerText != null && columnMappingName != null && columnWidth != null)
            {
                if (headerText.Length == columnMappingName.Length && headerText.Length == columnWidth.Length)
                {
                    //先清空现有格式
                    this.TableStyles.Clear();
                    DataGridTextBoxColumn aColumnTextColumn;
                    DataGridTableStyle dtgrdTbStyle = new DataGridTableStyle();
                    dtgrdTbStyle.RowHeaderWidth = rowHeaderWidth;
                    this.RowHeaderWidth = rowHeaderWidth;
                    dtgrdTbStyle.AllowSorting = this.AllowSorting;
                    dtgrdTbStyle.ReadOnly = this.ReadOnly;

                    this.TableStyles.Add(dtgrdTbStyle);
                    for (int i = 0; i < headerText.Length; i++)
                    {
                        aColumnTextColumn = new DataGridTextBoxColumn();
                        aColumnTextColumn.NullText = "";
                        aColumnTextColumn.HeaderText = headerText[i];
                        aColumnTextColumn.MappingName = columnMappingName[i];
                        aColumnTextColumn.Width = columnWidth[i];
                        this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    }

                }
            }
        }
        /// <summary>
        /// 创建网格显示格式
        /// </summary>
        /// <param name="headerText">列标题字符集</param>
        /// <param name="columnMappingName">列匹配字段名称字符集</param>
        /// <param name="columnWidth">列宽度集合</param>
        /// <param name="rowHeaderWidth">行标头宽度</param>
        /// <param name="mappingName">匹配的表名</param>
        public void CreateTableStyle(string[] headerText, string[] columnMappingName, int[] columnWidth, int rowHeaderWidth, string mappingName)
        {
            if (headerText != null && columnMappingName != null && columnWidth != null)
            {
                if (headerText.Length == columnMappingName.Length && headerText.Length == columnWidth.Length)
                {
                    //先清空现有格式
                    this.TableStyles.Clear();
                    DataGridTextBoxColumn aColumnTextColumn;
                    DataGridTableStyle dtgrdTbStyle = new DataGridTableStyle();
                    dtgrdTbStyle.RowHeaderWidth = rowHeaderWidth;
                    this.RowHeaderWidth = rowHeaderWidth;
                    dtgrdTbStyle.AllowSorting = this.AllowSorting;
                    dtgrdTbStyle.ReadOnly = this.ReadOnly;
                    dtgrdTbStyle.MappingName = mappingName;

                    this.TableStyles.Add(dtgrdTbStyle);
                    for (int i = 0; i < headerText.Length; i++)
                    {
                        aColumnTextColumn = new DataGridTextBoxColumn();
                        aColumnTextColumn.NullText = "";
                        aColumnTextColumn.HeaderText = headerText[i];
                        aColumnTextColumn.MappingName = columnMappingName[i];
                        aColumnTextColumn.Width = columnWidth[i];
                        this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    }

                }
            }
        }
        /// <summary>
        /// 创建网格显示格式
        /// </summary>
        /// <param name="headerText">列标题字符集</param>
        /// <param name="columnMappingName">列匹配字段名称字符集</param>
        /// <param name="columnWidth">列宽度集合</param>
        /// <param name="rowHeaderWidth">行标头宽度</param>
        /// <param name="columnuColorChangeable">列颜色是否可以更改</param>
        public void CreateTableStyle(string[] headerText, string[] columnMappingName, int[] columnWidth, int rowHeaderWidth, bool columnuColorChangeable)
        {
            if (headerText != null && columnMappingName != null && columnWidth != null)
            {
                if (headerText.Length == columnMappingName.Length && headerText.Length == columnWidth.Length)
                {
                    //先清空现有格式
                    this.TableStyles.Clear();
                    DataGridTableStyle dtgrdTbStyle = new DataGridTableStyle();
                    dtgrdTbStyle.RowHeaderWidth = rowHeaderWidth;
                    this.RowHeaderWidth = rowHeaderWidth;
                    dtgrdTbStyle.AllowSorting = this.AllowSorting;
                    dtgrdTbStyle.ReadOnly = this.ReadOnly;

                    this.TableStyles.Add(dtgrdTbStyle);
                    if (columnuColorChangeable && CellValuesChanged != null)
                    {
                        DataGridEnableTextBoxColumn aColumnTextColumn;
                        for (int i = 0; i < headerText.Length; i++)
                        {
                            aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                            aColumnTextColumn.CheckCellEnabled += CellValuesChanged;
                            aColumnTextColumn.NullText = "";
                            aColumnTextColumn.HeaderText = headerText[i];
                            aColumnTextColumn.MappingName = columnMappingName[i];
                            aColumnTextColumn.Width = columnWidth[i];
                            this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                        }

                    }
                    else
                    {
                        DataGridTextBoxColumn aColumnTextColumn;
                        for (int i = 0; i < headerText.Length; i++)
                        {
                            aColumnTextColumn = new DataGridTextBoxColumn();
                            aColumnTextColumn.NullText = "";
                            aColumnTextColumn.HeaderText = headerText[i];
                            aColumnTextColumn.MappingName = columnMappingName[i];
                            aColumnTextColumn.Width = columnWidth[i];
                            this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 创建网格显示格式
        /// </summary>
        /// <param name="headerText">列标题字符集</param>
        /// <param name="columnMappingName">列匹配字段名称字符集</param>
        /// <param name="columnWidth">列宽度集合</param>
        /// <param name="rowHeaderWidth">行标头宽度</param>
        /// <param name="mappingName">匹配的表名</param>
        /// <param name="columnuColorChangeable">列颜色是否可以更改</param>
        public void CreateTableStyle(string[] headerText, string[] columnMappingName, int[] columnWidth, int rowHeaderWidth, string mappingName, bool columnuColorChangeable)
        {
            if (headerText != null && columnMappingName != null && columnWidth != null)
            {
                if (headerText.Length == columnMappingName.Length && headerText.Length == columnWidth.Length)
                {
                    //先清空现有格式
                    this.TableStyles.Clear();
                    DataGridTableStyle dtgrdTbStyle = new DataGridTableStyle();
                    dtgrdTbStyle.RowHeaderWidth = rowHeaderWidth;
                    this.RowHeaderWidth = rowHeaderWidth;
                    dtgrdTbStyle.AllowSorting = this.AllowSorting;
                    dtgrdTbStyle.ReadOnly = this.ReadOnly;
                    dtgrdTbStyle.MappingName = mappingName;

                    this.TableStyles.Add(dtgrdTbStyle);
                    if (columnuColorChangeable && CellValuesChanged != null)
                    {
                        DataGridEnableTextBoxColumn aColumnTextColumn;
                        for (int i = 0; i < headerText.Length; i++)
                        {
                            aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                            aColumnTextColumn.CheckCellEnabled += CellValuesChanged;
                            aColumnTextColumn.NullText = "";
                            aColumnTextColumn.HeaderText = headerText[i];
                            aColumnTextColumn.MappingName = columnMappingName[i];
                            aColumnTextColumn.Width = columnWidth[i];
                            this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                        }

                    }
                    else
                    {
                        DataGridTextBoxColumn aColumnTextColumn;
                        for (int i = 0; i < headerText.Length; i++)
                        {
                            aColumnTextColumn = new DataGridTextBoxColumn();
                            aColumnTextColumn.NullText = "";
                            aColumnTextColumn.HeaderText = headerText[i];
                            aColumnTextColumn.MappingName = columnMappingName[i];
                            aColumnTextColumn.Width = columnWidth[i];
                            this.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                        }
                    }

                }
            }
        }

        #endregion

        #region 选中当前行
        /// <summary>
        /// 选中当前行
        /// </summary>
        public void SelectCurrentRow()
        {
            if (this.DataSource != null)
            {
                if (this.DataSource.GetType().IsSubclassOf(typeof(System.Data.DataTable)) || this.DataSource.GetType() == typeof(System.Data.DataTable))
                {
                    if (((DataTable)this.DataSource).Rows.Count > 0)
                    {
                        for (int i = 0; i < ((DataTable)this.DataSource).DefaultView.Count; i++)
                        {
                            this.UnSelect(i);
                        }
                        this.Select(this.CurrentCell.RowNumber);
                    }
                }
                else if (this.DataSource.GetType().IsSubclassOf(typeof(System.Data.DataView)) || this.DataSource.GetType() == typeof(System.Data.DataView))
                {
                    if (((DataView)this.DataSource).Count > 0)
                    {
                        for (int i = 0; i < ((DataView)this.DataSource).Count; i++)
                        {
                            this.UnSelect(i);
                        }
                        this.Select(this.CurrentCell.RowNumber);
                    }
                }
                else if ((this.DataSource.GetType().IsSubclassOf(typeof(System.Data.DataSet)) || this.DataSource.GetType() == typeof(System.Data.DataSet)) && this.DataMember != "")
                {
                    if (((DataSet)this.DataSource).Tables[this.DataMember].DefaultView.Count > 0)
                    {
                        for (int i = 0; i < ((DataSet)this.DataSource).Tables[this.DataMember].DefaultView.Count; i++)
                        {
                            this.UnSelect(i);
                        }
                        this.Select(this.CurrentCell.RowNumber);
                    }
                }
            }
        }
        #endregion

        //Add By Tany 2010-09-28 滚动到当前行
        /// <summary>
        /// 滚动到当前行
        /// </summary>
        /// <param name="row">行号（需大于0）</param>
        public void ScollRow(int row)
        {
            if (row >= 0)
            {
                base.GridVScrolled(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, row));
            }
        }

        #region 设置打印格式
        /*
		/// <summary>
		/// 设置打印格式
		/// </summary>
		public void PageSetup()
		{
			_misGoldPrinter.PageSetup();
		}
		//#endregion

		#region 打印网格内容
		/// <summary>
		/// 打印网格内容
		/// </summary>
		/// <param name="directPrint">true直接打印false预览</param>
		public void Print(bool directPrint)
		{
			try
			{
				#region 设置表头
				_misGoldPrinter.Title = this.GridPrintTitle;										//主标题（C#用\n表示换行）	
				_misGoldPrinter.Caption =_gridPrintCaption;
				_misGoldPrinter.Top =_gridPrintTop;
				#endregion
			
				#region 设置表体：设置数据源、网格标题、列宽
				if(this.DataSource.GetType()==typeof(System.Data.DataTable))
				{
					_misGoldPrinter.DataSource = this.DataSource;								
				}
				else if(this.DataSource.GetType()==typeof(System.Data.DataView))
				{
					_misGoldPrinter.DataSource =((DataView)this.DataSource).Table;	
				}
				else if(this.DataSource.GetType()==typeof(System.Data.DataSet) && this.DataMember!="")
				{
					_misGoldPrinter.DataSource =((DataSet)this.DataSource).Tables[this.DataMember];	
				}
				else
				{
					throw new Exception("网格打印错误：\n没有设置网格的数据源！");
				}
				MultiHeader multiHeader=null;
				int validColumn=0;				//有效宽度列数目
				int[] columnuWidth =new int[1];	
				if(this.TableStyles.Count>0)
				{
					string tableName=((DataTable)_misGoldPrinter.DataSource).TableName;
					int mappingIndex=-1;			
					for(int i=0;i<this.TableStyles.Count;i++)
					{
						if(this.TableStyles[i].MappingName.Trim()==tableName.Trim())
						{
							mappingIndex=i;
							break;
						}
					}
					if(mappingIndex>=0)		//匹配成功
					{
						for(int i=0;i<this.TableStyles[mappingIndex].GridColumnStyles.Count;i++)
						{
							if(this.TableStyles[mappingIndex].GridColumnStyles[i].Width>0)
							{
								validColumn++;	
							}
						}
						if(validColumn>0)
						{	
							multiHeader=new MultiHeader(1,validColumn);
							columnuWidth=new int[validColumn];
							validColumn=0;
							//重新设置打印对象的数据源，去掉没有与GridColumnStyles的Columnu及宽度为0的列\列宽
							DataTable tb=((DataTable)_misGoldPrinter.DataSource).Copy();
							bool validcol=false;
							foreach(DataColumn col in ((DataTable)_misGoldPrinter.DataSource).Columns)
							{
								validcol=false;
								for(int i=0;i<this.TableStyles[mappingIndex].GridColumnStyles.Count;i++)
								{
									if(this.TableStyles[mappingIndex].GridColumnStyles[i].MappingName.Trim().ToUpper()==col.ColumnName.Trim().ToUpper()
										&& this.TableStyles[mappingIndex].GridColumnStyles[i].Width>0)
									{
										multiHeader.SetText(0,validColumn,this.TableStyles[mappingIndex].GridColumnStyles[i].HeaderText);
										columnuWidth[validColumn]=this.TableStyles[mappingIndex].GridColumnStyles[i].Width;
										validColumn++;	
										validcol=true;
										break;
									}
								}
								if(!validcol)
								{
									tb.Columns.Remove(col.ColumnName);
								}
							}
							_misGoldPrinter.DataSource =tb;

						}
						else
						{
							throw new Exception("网格打印错误：\n请设置可见列！");
						}
					}
					else
					{
						validColumn=((DataTable)_misGoldPrinter.DataSource).Columns.Count;		
						multiHeader=new MultiHeader(1,validColumn);
						columnuWidth=new int[validColumn];
						for(int i=0;i<validColumn;i++)
						{
							multiHeader.SetText(0,i,((DataTable)_misGoldPrinter.DataSource).Columns[i].ColumnName);
							columnuWidth[i]=75;	//默认宽度
						}
					}
				}
				else
				{
					validColumn=((DataTable)_misGoldPrinter.DataSource).Columns.Count;		
					multiHeader=new MultiHeader(1,validColumn);
					columnuWidth=new int[validColumn];
					for(int i=0;i<validColumn;i++)
					{
						multiHeader.SetText(0,i,((DataTable)_misGoldPrinter.DataSource).Columns[i].ColumnName);
						columnuWidth[i]=75;	//默认宽度
					}
				}
				if(multiHeader!=null)
				{
					multiHeader.ColsWidth = columnuWidth;
					_misGoldPrinter.MultiHeader = multiHeader;
					((GoldPrinter.Body)(_misGoldPrinter.Body)).ColsWidth =columnuWidth;
				}
				((GoldPrinter.Body)(_misGoldPrinter.Body)).IsAverageColsWidth = false;	//指明平均列宽
				((GoldPrinter.Body)(_misGoldPrinter.Body)).Font =this.Font;
				#endregion

				#region 设置表尾
				if(_gridPrintBottom!="")
				{
					_misGoldPrinter.Bottom = _gridPrintBottom+"|打印日期：" + System.DateTime.Now.ToLongDateString();		//结尾，说明同抬头
				}
				else
				{
					_misGoldPrinter.Bottom ="打印日期：" + System.DateTime.Now.ToLongDateString();		//结尾，说明同抬头
				}
				#endregion

				#region 打印或预览
				if (directPrint)
				{
					_misGoldPrinter.Print();											//打印
				}
				else
				{
					_misGoldPrinter.Preview();											//预览
				}
				#endregion
			}
			catch(Exception err)
			{
				throw new Exception("网格打印错误：\n"+err.Message);
			}
		}
		#endregion

		//#region  输出为Excel格式
		/// <summary>
		/// 输出为Excel格式
		/// </summary>
		/// <param name="printPreview">true打印预览false显示Excel</param>
		public void ExportExcel(bool printPreview)
		{
			DataTable tb=null;
			try
			{
				if(this.DataSource.GetType()==typeof(System.Data.DataTable))
				{
					tb=((DataTable)this.DataSource).Copy();								
				}
				else if(this.DataSource.GetType()==typeof(System.Data.DataView))
				{
					tb=((DataView)this.DataSource).Table.Copy();	
				}
				else if(this.DataSource.GetType()==typeof(System.Data.DataSet) && this.DataMember!="")
				{
					tb=((DataSet)this.DataSource).Tables[this.DataMember].Copy();	
				}
				else
				{
					throw new Exception("网格导出Excel错误：\n没有设置网格的数据源！");
				}
				//用Excel打印，步骤为：打开、写数据、打印预览、关闭						
				ExcelAccess excel = new ExcelAccess();	
				excel.Open();

				#region 打印网格及网格线
				int validColumn=0;				//有效宽度列数目
				if(this.TableStyles.Count>0)
				{
					int mappingIndex=-1;			
					for(int i=0;i<this.TableStyles.Count;i++)
					{
						if(this.TableStyles[i].MappingName.Trim()==tb.TableName.Trim())
						{
							mappingIndex=i;
							break;
						}
					}
					if(mappingIndex>=0)		//匹配成功
					{
						for(int i=0;i<this.TableStyles[mappingIndex].GridColumnStyles.Count;i++)
						{
							if(this.TableStyles[mappingIndex].GridColumnStyles[i].Width>0)
							{
								validColumn++;	
							}
						}
						if(validColumn>0)
						{	
							//去掉没有与GridColumnStyles的Columnu及宽度为0的列\列宽
							validColumn=0;
							bool validcol=false;
							DataTable tbTmp=tb.Clone();
							foreach(DataColumn col in tbTmp.Columns)
							{
								validcol=false;
								for(int i=0;i<this.TableStyles[mappingIndex].GridColumnStyles.Count;i++)
								{
									if(this.TableStyles[mappingIndex].GridColumnStyles[i].MappingName.Trim().ToUpper()==col.ColumnName.Trim().ToUpper()
										&& this.TableStyles[mappingIndex].GridColumnStyles[i].Width>0)
									{
										//写列标题
										validColumn++;
										excel.SetCellText(2,validColumn,this.TableStyles[mappingIndex].GridColumnStyles[i].HeaderText);
										validcol=true;
										break;
									}
								}
								if(!validcol)
								{
									tb.Columns.Remove(col.ColumnName);
								}
							}
						}
						else
						{
							throw new Exception("网格导出Excel错误：\n请设置可见列！");
						}
					}
					else
					{
						//将DataTable列名作为标题内容写入网格
						for(int i=0;i<tb.Rows.Count;i++)
						{
							excel.SetCellText(2,i+1,tb.Columns[i].ColumnName);
						}
					}
				}
				else
				{
					//将DataTable列名作为标题内容写入网格
					for(int i=0;i<tb.Rows.Count;i++)
					{
						excel.SetCellText(2,i+1,tb.Columns[i].ColumnName);
					}
				}
				excel.FormCaption = this.GridPrintTitle;		
				excel.MergeCells(1,1,1,tb.Columns.Count);		//合并单元格写标题，并设置字体
				excel.SetCellText(1,1,1,tb.Columns.Count,this.GridPrintTitle);
				excel.SetBordersEdge(2,1,2,tb.Columns.Count,false);
				//将DataTable内容写入网格
				excel.SetCellText(tb,3,1,true);
				#endregion

				#region 可以在打印预览时单击“页边距”，调整每列的宽。单击“设置\页边距”，选择水平居中方式
				if (printPreview)
				{
					excel.PrintPreview();
					excel.Close();
				}
				else
				{
					excel.ShowExcel();
				}	
				#endregion
			}
			catch(Exception err)
			{
				throw new Exception("网格导出Excel错误：\n"+err.Message);
			}
			finally
			{
				if(tb!=null)
				{
					tb.Dispose();
					tb=null;
				}
			}
		}
		*/
        #endregion

        #endregion

        #region 重写事件
        /// <summary>
        /// UserControl1.ProcessCmdKey 实现
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="keyData">键值</param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (myKeyDown != null)
            {
                if (myKeyDown(ref msg, keyData) == true)
                {
                    return true;
                }
            }
            // TODO:  添加 UserControl1.ProcessCmdKey 实现
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// 重写CurrentCellChanged事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCurrentCellChanged(EventArgs e)
        {
            if (this.TableStyles.Count > 0)
            {
                Type _type = this.TableStyles[0].GridColumnStyles[this.CurrentCell.ColumnNumber].GetType();
                if (_type == typeof(DataGridTextBoxColumn) || _type == typeof(TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn))
                {
                    DataGridTextBoxColumn aColumnTextColumn = (DataGridTextBoxColumn)this.TableStyles[0].GridColumnStyles[this.CurrentCell.ColumnNumber];
                    if (!this.ReadOnly && !this.TableStyles[0].ReadOnly && !this.TableStyles[0].GridColumnStyles[this.CurrentCell.ColumnNumber].ReadOnly)
                    {
                        aColumnTextColumn.TextBox.BackColor = _cellSelectedBackColor;
                    }
                    else
                    {
                        aColumnTextColumn.TextBox.BackColor = SystemColors.Control;
                    }
                }
            }
            base.OnCurrentCellChanged(e);
        }

        /// <summary>
        /// 重写OnPaint，让行头加上序号
        /// Modify By Tany 2009-11-25
        /// </summary>
        /// <param name="e"></param>
        override protected void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            try
            {

                if (_isShowRowHeadId && this.DataSource != null)
                {
                    int yDelta;

                    System.Drawing.Rectangle cell = this.GetCellBounds(0, 0);

                    int y = cell.Top + 2;

                    e.Graphics.DrawString("序号", this.Font, new SolidBrush(Color.Black), 2, y - 20); //

                    if (this.VisibleRowCount > 0)//只在有记录集时在表格中显示序号
                    {

                        CurrencyManager cm;

                        cm = (CurrencyManager)this.BindingContext[this.DataSource, this.DataMember];

                        if (cm.Count > 0)
                        {

                            int nRow = -1;

                            y = 23;           //为第一行默认高度

                            while (nRow < 0)
                            {

                                nRow = this.HitTest(8, y).Row;

                                y++;

                            }

                            int nCount = 0;

                            while (y < this.Height && nCount < this.VisibleRowCount)
                            {

                                string text = string.Format("{0}", nRow + nCount + 1);

                                e.Graphics.DrawString(text, this.Font, new SolidBrush(Color.Black), 4, y);

                                yDelta = this.GetCellBounds(nRow + nCount, 0).Height + 1;//****表示一行高度的参数

                                y += yDelta;

                                //如果下面有子行显示序号的区分显示   

                                if (this.IsExpanded(nRow + nCount) && nRow + nCount + 1 < cm.Count)
                                {

                                    y += this.GetCellBounds(nRow + nCount + 1, 0).Height + 3;

                                }

                                nCount++;

                            }

                        }

                    }

                }

            }

            catch

            { }

        }
        #endregion

    }
}
