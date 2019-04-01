using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using System.IO;
using System.Text.RegularExpressions;

namespace ts_jc_tysjwh
{
	/// <summary>
	/// FrmDataMaintenance 的摘要说明。
	/// </summary>
	public class FrmDataMaintenance : System.Windows.Forms.Form
	{
		//自定义变量
		private string _tableName;
		private TableField[] _tableFields;
		private string _selectString;
		private int _curRowIndex;
		private CurrentStatus _status;					//当前状态
		private Control _uniqueKeyFieldctrl;		
		private Type _uniqueKeyFildType;				//唯一索引字段类型
		private Control _pyCodeFieldctrl;
		private Control _wbCodeFieldctrl;
		private Control _deleteFieldctrl;			
		private DataSet _pubDataSet;					//公共数据集
		private FilterType _filterType;					//选项卡条件过滤类别
		private SearchType _searchType;
		private InputLanguage _il;						//默认中文输入法
		private Control _curActivectrl ;				//定位SHOWCARD网格从何处弹出
		private Control _fistVisiblectrl;				//在数据面板上第一个可见控件

		private const int HLEFT=2;						//左边距
		private const int HRIGHT=7;						//右边距
		private const int VINTERVAL=6;					//垂直间距
		private const int TXTINITLEFT=80;				//文本框初始左边距
		private const int PICTUREHEIGHT=84;				//图片框高度
		//自动生成变量
		private System.Windows.Forms.ToolBar tbarMain;
		private System.Windows.Forms.Panel plGrid;
		private System.Windows.Forms.Panel plDetail;
		private System.Windows.Forms.Splitter splitGrid;
		private System.Windows.Forms.ToolBarButton tbbtnDelete;
		private System.Windows.Forms.ToolBarButton tbbtnRefresh;
		private System.Windows.Forms.ToolBarButton tbbtnClose;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.GroupBox gbData;
		private System.Windows.Forms.Splitter splilData;
		private System.Windows.Forms.Label lblCaption;
		private System.Windows.Forms.TextBox txtRemarks;
		private System.Windows.Forms.Panel plLeft;
		private System.Windows.Forms.Panel plData;
		private System.Windows.Forms.ToolBarButton tbbtnNew;
		private System.Windows.Forms.ToolBarButton tbbtnModify;
		private System.Windows.Forms.ImageList img;
		private System.Windows.Forms.ToolBarButton tbbtnSave;
		private System.Windows.Forms.ToolBarButton tbbtnCancel;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.ContextMenu cntPic;
		private System.Windows.Forms.MenuItem mnuModifyPic;
		private System.Windows.Forms.MenuItem mnuDeletePic;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private TrasenClasses.GeneralControls.DataGridEx cardGrid;
		private TrasenClasses.GeneralControls.DataGridEx dtgrdMain;
		private TrasenClasses.GeneralControls.ComboGridSearch cGridSearch;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 构造通用数据维护对象
		/// </summary>
		/// <param name="formText">标题</param>
		/// <param name="tableName">数据库表名</param>
		/// <param name="tableFields">表字段数组</param>
		/// <param name="memo">备注</param>
		/// <param name="selectString">查询字符串</param>
		/// <param name="reportTitle">报表打印标题</param>
		public FrmDataMaintenance(string formText,string tableName,TableField[] tableFields,string memo,string selectString,string reportTitle)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			lblCaption.Text =formText;
			this.Text =formText;
			_tableName =tableName;
			_tableFields=tableFields;
			_selectString=selectString;
			dtgrdMain.GridPrintTitle =reportTitle;
			txtRemarks.Text =memo;
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmDataMaintenance));
			this.tbarMain = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbtnNew = new System.Windows.Forms.ToolBarButton();
			this.tbbtnModify = new System.Windows.Forms.ToolBarButton();
			this.tbbtnDelete = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbbtnSave = new System.Windows.Forms.ToolBarButton();
			this.tbbtnCancel = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.tbbtnRefresh = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.tbbtnClose = new System.Windows.Forms.ToolBarButton();
			this.img = new System.Windows.Forms.ImageList(this.components);
			this.plLeft = new System.Windows.Forms.Panel();
			this.plData = new System.Windows.Forms.Panel();
			this.cardGrid = new TrasenClasses.GeneralControls.DataGridEx();
			this.lblCaption = new System.Windows.Forms.Label();
			this.plGrid = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dtgrdMain = new TrasenClasses.GeneralControls.DataGridEx();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitGrid = new System.Windows.Forms.Splitter();
			this.plDetail = new System.Windows.Forms.Panel();
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.gbData = new System.Windows.Forms.GroupBox();
			this.splilData = new System.Windows.Forms.Splitter();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.cntPic = new System.Windows.Forms.ContextMenu();
			this.mnuModifyPic = new System.Windows.Forms.MenuItem();
			this.mnuDeletePic = new System.Windows.Forms.MenuItem();
			this.cGridSearch = new TrasenClasses.GeneralControls.ComboGridSearch();
			this.plLeft.SuspendLayout();
			this.plData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
			this.plGrid.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgrdMain)).BeginInit();
			this.panel1.SuspendLayout();
			this.plDetail.SuspendLayout();
			this.gbData.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbarMain
			// 
			this.tbarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.tbbtnNew,
																						this.tbbtnModify,
																						this.tbbtnDelete,
																						this.toolBarButton2,
																						this.tbbtnSave,
																						this.tbbtnCancel,
																						this.toolBarButton3,
																						this.tbbtnRefresh,
																						this.toolBarButton4,
																						this.tbbtnClose});
			this.tbarMain.DropDownArrows = true;
			this.tbarMain.ImageList = this.img;
			this.tbarMain.Location = new System.Drawing.Point(0, 0);
			this.tbarMain.Name = "tbarMain";
			this.tbarMain.ShowToolTips = true;
			this.tbarMain.Size = new System.Drawing.Size(814, 41);
			this.tbarMain.TabIndex = 3;
			this.tbarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbarMain_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbtnNew
			// 
			this.tbbtnNew.ImageIndex = 0;
			this.tbbtnNew.Tag = "0";
			this.tbbtnNew.Text = "添加";
			this.tbbtnNew.ToolTipText = "添加新项";
			// 
			// tbbtnModify
			// 
			this.tbbtnModify.ImageIndex = 8;
			this.tbbtnModify.Tag = "1";
			this.tbbtnModify.Text = "修改";
			this.tbbtnModify.ToolTipText = "修改当前项";
			// 
			// tbbtnDelete
			// 
			this.tbbtnDelete.ImageIndex = 9;
			this.tbbtnDelete.Tag = "2";
			this.tbbtnDelete.Text = "删除";
			this.tbbtnDelete.ToolTipText = "删除当前项";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbtnSave
			// 
			this.tbbtnSave.Enabled = false;
			this.tbbtnSave.ImageIndex = 1;
			this.tbbtnSave.Tag = "3";
			this.tbbtnSave.Text = "保存";
			this.tbbtnSave.ToolTipText = "保存当前项";
			// 
			// tbbtnCancel
			// 
			this.tbbtnCancel.ImageIndex = 10;
			this.tbbtnCancel.Tag = "4";
			this.tbbtnCancel.Text = "取消";
			this.tbbtnCancel.ToolTipText = "取消操作";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbtnRefresh
			// 
			this.tbbtnRefresh.ImageIndex = 2;
			this.tbbtnRefresh.Tag = "5";
			this.tbbtnRefresh.Text = "刷新";
			this.tbbtnRefresh.ToolTipText = "刷新网格数据";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbtnClose
			// 
			this.tbbtnClose.ImageIndex = 5;
			this.tbbtnClose.Tag = "11";
			this.tbbtnClose.Text = "关闭";
			this.tbbtnClose.ToolTipText = "关闭窗口";
			// 
			// img
			// 
			this.img.ImageSize = new System.Drawing.Size(16, 16);
			this.img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img.ImageStream")));
			this.img.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// plLeft
			// 
			this.plLeft.AutoScroll = true;
			this.plLeft.BackColor = System.Drawing.SystemColors.Control;
			this.plLeft.Controls.Add(this.plData);
			this.plLeft.Controls.Add(this.lblCaption);
			this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.plLeft.Location = new System.Drawing.Point(3, 17);
			this.plLeft.Name = "plLeft";
			this.plLeft.Size = new System.Drawing.Size(301, 492);
			this.plLeft.TabIndex = 5;
			// 
			// plData
			// 
			this.plData.BackColor = System.Drawing.SystemColors.Window;
			this.plData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.plData.Controls.Add(this.cardGrid);
			this.plData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plData.Location = new System.Drawing.Point(0, 30);
			this.plData.Name = "plData";
			this.plData.Size = new System.Drawing.Size(301, 462);
			this.plData.TabIndex = 15;
			// 
			// cardGrid
			// 
			this.cardGrid.AllowSorting = false;
			this.cardGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.cardGrid.CaptionVisible = false;
			this.cardGrid.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
			this.cardGrid.DataMember = "";
			this.cardGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.cardGrid.Location = new System.Drawing.Point(44, 210);
			this.cardGrid.Name = "cardGrid";
			this.cardGrid.ReadOnly = true;
			this.cardGrid.Size = new System.Drawing.Size(340, 148);
			this.cardGrid.TabIndex = 0;
			this.cardGrid.Visible = false;
			this.cardGrid.DoubleClick += new System.EventHandler(this.cardGrid_DoubleClick);
			this.cardGrid.CurrentCellChanged += new System.EventHandler(this.cardGrid_CurrentCellChanged);
			// 
			// lblCaption
			// 
			this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCaption.Font = new System.Drawing.Font("楷体_GB2312", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCaption.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblCaption.Location = new System.Drawing.Point(0, 0);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(301, 30);
			this.lblCaption.TabIndex = 14;
			this.lblCaption.Text = "数据维护";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// plGrid
			// 
			this.plGrid.Controls.Add(this.panel2);
			this.plGrid.Controls.Add(this.panel1);
			this.plGrid.Controls.Add(this.splitGrid);
			this.plGrid.Controls.Add(this.plDetail);
			this.plGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plGrid.Location = new System.Drawing.Point(308, 17);
			this.plGrid.Name = "plGrid";
			this.plGrid.Size = new System.Drawing.Size(503, 492);
			this.plGrid.TabIndex = 7;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dtgrdMain);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 32);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(503, 386);
			this.panel2.TabIndex = 5;
			// 
			// dtgrdMain
			// 
			this.dtgrdMain.AllowSorting = false;
			this.dtgrdMain.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dtgrdMain.CaptionVisible = false;
			this.dtgrdMain.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
			this.dtgrdMain.DataMember = "";
			this.dtgrdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dtgrdMain.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgrdMain.Location = new System.Drawing.Point(0, 0);
			this.dtgrdMain.Name = "dtgrdMain";
			this.dtgrdMain.ReadOnly = true;
			this.dtgrdMain.Size = new System.Drawing.Size(503, 386);
			this.dtgrdMain.TabIndex = 0;
			this.dtgrdMain.CurrentCellChanged += new System.EventHandler(this.dtgrdMain_CurrentCellChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cGridSearch);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(503, 32);
			this.panel1.TabIndex = 4;
			// 
			// splitGrid
			// 
			this.splitGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitGrid.Location = new System.Drawing.Point(0, 418);
			this.splitGrid.Name = "splitGrid";
			this.splitGrid.Size = new System.Drawing.Size(503, 4);
			this.splitGrid.TabIndex = 2;
			this.splitGrid.TabStop = false;
			// 
			// plDetail
			// 
			this.plDetail.Controls.Add(this.txtRemarks);
			this.plDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.plDetail.Location = new System.Drawing.Point(0, 422);
			this.plDetail.Name = "plDetail";
			this.plDetail.Size = new System.Drawing.Size(503, 70);
			this.plDetail.TabIndex = 0;
			// 
			// txtRemarks
			// 
			this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtRemarks.Location = new System.Drawing.Point(0, 0);
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.Size = new System.Drawing.Size(503, 70);
			this.txtRemarks.TabIndex = 0;
			this.txtRemarks.Text = "备注：";
			// 
			// gbData
			// 
			this.gbData.BackColor = System.Drawing.SystemColors.Control;
			this.gbData.Controls.Add(this.plGrid);
			this.gbData.Controls.Add(this.splilData);
			this.gbData.Controls.Add(this.plLeft);
			this.gbData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbData.Location = new System.Drawing.Point(0, 41);
			this.gbData.Name = "gbData";
			this.gbData.Size = new System.Drawing.Size(814, 512);
			this.gbData.TabIndex = 0;
			this.gbData.TabStop = false;
			// 
			// splilData
			// 
			this.splilData.Location = new System.Drawing.Point(304, 17);
			this.splilData.Name = "splilData";
			this.splilData.Size = new System.Drawing.Size(4, 492);
			this.splilData.TabIndex = 7;
			this.splilData.TabStop = false;
			// 
			// cntPic
			// 
			this.cntPic.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mnuModifyPic,
																				   this.mnuDeletePic});
			// 
			// mnuModifyPic
			// 
			this.mnuModifyPic.Index = 0;
			this.mnuModifyPic.Text = "修改图片(&M)";
			this.mnuModifyPic.Click += new System.EventHandler(this.mnuModifyPic_Click);
			// 
			// mnuDeletePic
			// 
			this.mnuDeletePic.Index = 1;
			this.mnuDeletePic.Text = "删除图片(&D)";
			this.mnuDeletePic.Click += new System.EventHandler(this.mnuDeletePic_Click);
			// 
			// cGridSearch
			// 
			this.cGridSearch.BackColor = System.Drawing.SystemColors.Control;
			this.cGridSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.cGridSearch.Location = new System.Drawing.Point(0, 0);
			this.cGridSearch.MappingDataGrid = this.dtgrdMain;
			this.cGridSearch.Name = "cGridSearch";
			this.cGridSearch.Size = new System.Drawing.Size(503, 30);
			this.cGridSearch.TabIndex = 9;
			this.cGridSearch.TableStyleIndex = 0;
			// 
			// FrmDataMaintenance
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(814, 553);
			this.Controls.Add(this.gbData);
			this.Controls.Add(this.tbarMain);
			this.Name = "FrmDataMaintenance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "数据维护";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmDataMaintenance_Load);
			this.plLeft.ResumeLayout(false);
			this.plData.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
			this.plGrid.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgrdMain)).EndInit();
			this.panel1.ResumeLayout(false);
			this.plDetail.ResumeLayout(false);
			this.gbData.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 方法
		/// <summary>
		/// 刷新数据
		/// </summary>
		private void RefreshData()
		{
			if ( cardGrid.Visible )
				cardGrid.Visible = false;

			try
			{
				if(_selectString!="")
				{
					_pubDataSet.Tables[_tableName].Clear();
					DbDataAdapter ada =InstanceForm.BDatabase.GetAdapter(_selectString);
					ada.Fill(_pubDataSet,_tableName);
					ada.Dispose();
					//将_tableName中后缀为_CN字段替换为子表中NAME字段内容
					for(int i=0;i<_tableFields.Length;i++)
					{
						if(_tableFields[i].ShowCardSql!="")
						{
							for(int j=0;j< _pubDataSet.Tables[_tableName].Rows.Count ;j++)
							{
								string tmpID=Convertor.IsNull(_pubDataSet.Tables[_tableName].Rows[j][_tableFields[i].DatabaseName],"-1");
								_pubDataSet.Tables[_tableName].Rows[j][_tableFields[i].DatabaseName+"_CN"]=Convertor.IsNull(_pubDataSet.Tables[_tableFields[i].DatabaseName+"_TABLE"].Compute("MAX(NAME)","ID="+GetFieldValueByType(_pubDataSet.Tables[_tableName].Columns[_tableFields[i].DatabaseName].DataType,tmpID)),"");
							}
						}
					}
					dtgrdMain.DataSource =_pubDataSet.Tables[_tableName].DefaultView;
					if(_uniqueKeyFieldctrl!=null)
					{
						_pubDataSet.Tables[_tableName].DefaultView.Sort=((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName;
						_uniqueKeyFildType=_pubDataSet.Tables[_tableName].Columns[((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName].DataType;
						if(_pubDataSet.Tables[_tableName].DefaultView.Count>0)
						{
							int i=_pubDataSet.Tables[_tableName].DefaultView.Find(Convertor.IsNull(_uniqueKeyFieldctrl.Text,"-1"));
							if(i<0)
							{
								dtgrdMain_CurrentCellChanged(null,null);
							}
							else
							{
								dtgrdMain.CurrentCell =new DataGridCell(i,0);
							}
						}
					}
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"错误");
			}
		}
		/// <summary>
		/// 创建网格格式
		/// </summary>
		private void CreateGridStyle()
		{	
			int showCardCount=0;
			for(int i=0;i<_tableFields.Length;i++)
			{
				if(_tableFields[i].ShowCardSql!="")
				{
					showCardCount++;
				}
			}
			string[] head=new string[_tableFields.Length+showCardCount];
			string[] colname=new string[_tableFields.Length+showCardCount];
			int[] colwidth=new int[_tableFields.Length+showCardCount];
			for(int i=0,j=0;i<head.Length;i++,j++)
			{
				head[i]=_tableFields[j].ChineseName;
				colname[i]=_tableFields[j].DatabaseName;
				if(_tableFields[j].ShowCardSql!="")
				{
					colwidth[i]=0;
					i++;
					head[i]=_tableFields[j].ChineseName;
					colname[i]=_tableFields[j].DatabaseName+"_CN";
					colwidth[i]=_tableFields[j].ViewWidth;
				}
				else
				{
					colwidth[i]=_tableFields[j].ViewWidth;
				}
			}
			dtgrdMain.CreateTableStyle(head,colname,colwidth,_tableName);
			string[] dhead={"行号","编码","名称","拼音码","五笔码","数字码"};
			string[] dcolname={"rowno","id","name","py_code","wb_code","d_code"};
			int[] dcolwidth={30,60,120,60,60,60};
			cardGrid.CreateTableStyle(dhead,dcolname,dcolwidth,20);

		}
		/// <summary>
		/// 创建初始数据集
		/// </summary>
		private void CreateDataSet()
		{
			DataTable tb=InstanceForm.BDatabase.GetDataTable(_selectString);
			tb.TableName=_tableName;
			_pubDataSet.Tables.Add(tb);
			for(int i=0;i<_tableFields.Length;i++)
			{
				if(_tableFields[i].ShowCardSql!="")
				{
					tb=InstanceForm.BDatabase.GetDataTable(_tableFields[i].ShowCardSql);
					tb.TableName=_tableFields[i].DatabaseName+"_TABLE";	//子表名默认以数据库字段名称加_TABLE
					_pubDataSet.Tables.Add(tb);
					_pubDataSet.Tables[_tableName].Columns.Add(_tableFields[i].DatabaseName+"_CN");
					for(int j=0;j< _pubDataSet.Tables[_tableName].Rows.Count ;j++)
					{
						string tmpID=Convertor.IsNull(_pubDataSet.Tables[_tableName].Rows[j][_tableFields[i].DatabaseName],"-1");
						_pubDataSet.Tables[_tableName].Rows[j][_tableFields[i].DatabaseName+"_CN"]=Convertor.IsNull(_pubDataSet.Tables[_tableFields[i].DatabaseName+"_TABLE"].Compute("MAX(NAME)","ID="+GetFieldValueByType(_pubDataSet.Tables[_tableName].Columns[_tableFields[i].DatabaseName].DataType,tmpID)),"");
					}
				}
			}
			dtgrdMain.DataSource =_pubDataSet.Tables[_tableName].DefaultView;
		}
		/// <summary>
		/// 创建数据面板
		/// </summary>
		private void CreateDataPanel()
		{
			Label lbl;
			Control ctrl;
			TextBox txt;
			PictureBox pic;
			TEXTBOXTAG txtTag;
			int top=VINTERVAL;
			int visibleCount=0;
			DataView dv=(DataView)dtgrdMain.DataSource;
			for(int i=0;i<_tableFields.Length;i++)
			{
				_tableFields[i].FieldType = dv.Table.Columns[_tableFields[i].DatabaseName].DataType;
				//动态生成数据面板内容
				if(dv.Table.Columns[_tableFields[i].DatabaseName].DataType==typeof(System.DateTime))
				{
					ctrl=new DateTimePicker();
					ctrl.Width =plData.Width-TXTINITLEFT-HRIGHT;
					ctrl.Location =new Point(TXTINITLEFT,top);
				}
				else
				{
					if(_tableFields[i].SpeciType ==FieldSpeciType.IMAGE)//图象_tableFields[i].SpeciType ==FieldSpeciType.SOUND未完成
					{
						ctrl=new PictureBox();
						pic=(PictureBox)ctrl;
						pic.SizeMode =PictureBoxSizeMode.StretchImage;
						pic.Height =PICTUREHEIGHT;
						pic.Width =PICTUREHEIGHT;
						pic.Location =new Point(TXTINITLEFT,top);
						pic.BorderStyle =System.Windows.Forms.BorderStyle.Fixed3D;
						pic.DoubleClick +=new EventHandler(pic_DoubleClick);
						pic.ContextMenu =cntPic;
					}
					else
					{
						ctrl=new TextBox();
						ctrl.Text ="";
						if(_tableFields[i].ViewWidth>=100)			//宽度大于100则TextBox高度相应变化，以100为单位逐级增加
						{
							txt=(TextBox)ctrl;
							txt.Multiline =true;
							ctrl.Height =ctrl.Height*(2+(int)((_tableFields[i].ViewWidth-100)/100));
						}
						if(_tableFields[i].SpeciType ==FieldSpeciType.PASSWORD)			//密码框
						{
							txt=(TextBox)ctrl;
							txt.PasswordChar='*';
						}
						ctrl.Width =plData.Width-TXTINITLEFT-HRIGHT;
						ctrl.Location =new Point(TXTINITLEFT,top);
					}
				}
				ctrl.BackColor =SystemColors.Window;
				txtTag=new TEXTBOXTAG();
				txtTag.FieldProperty =_tableFields[i];
				ctrl.Tag =txtTag;
				ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
					| System.Windows.Forms.AnchorStyles.Right)));
				ctrl.KeyUp +=new KeyEventHandler(ctrl_KeyUp);
				ctrl.Enter +=new EventHandler(ctrl_Enter);
				ctrl.Leave +=new EventHandler(ctrl_Leave);
				plData.Controls.Add(ctrl);

				lbl=new Label();
				lbl.Text =_tableFields[i].ChineseName+"：";
				lbl.AutoSize =true;
				lbl.TextAlign =ContentAlignment.MiddleLeft;
				lbl.Location =new Point(HLEFT,top);
				plData.Controls.Add(lbl);	

				if(_tableFields[i].IsUniqueKey)
				{
					_uniqueKeyFieldctrl =ctrl;
				}
				if(_tableFields[i].IsDeleteField)
				{
					_deleteFieldctrl =ctrl;
				}
				if(_tableFields[i].IsPYField)
				{
					_pyCodeFieldctrl =ctrl;
				}
				if(_tableFields[i].IsWBField)
				{
					_wbCodeFieldctrl =ctrl;
				}
				if(_tableFields[i].ViewWidth>0 && !_tableFields[i].IsAutoIncrease && !_tableFields[i].IsDeleteField )
				{
					top+=ctrl.Height+VINTERVAL;
					visibleCount++;
					if(visibleCount==1)
					{
						_fistVisiblectrl=ctrl;
					}
				}
				else
				{
					ctrl.Visible =false;
					lbl.Visible =false;
				}
			}
		}
		/// <summary>
		/// 根据窗体局部变量_status的值控制按钮的可用状态、工具栏显示
		/// </summary>
		private void ChangeByStatus(CurrentStatus status)
		{
			_status=status;
			switch(status)
			{
				case CurrentStatus.查询状态 :
					tbbtnSave.Enabled =false;
					tbbtnNew.Enabled =true;
					tbbtnModify.Enabled =true;
					tbbtnDelete.Enabled =true;
					tbbtnRefresh.Enabled =true;
					foreach(Control ctl in plData.Controls)
					{
						if(!ctl.GetType().IsSubclassOf(typeof(System.Windows.Forms.Label)) && ctl.GetType()!=typeof(System.Windows.Forms.Label))
						{
							ctl.Enabled =false;
						}
					}
					break;
				default:
					tbbtnSave.Enabled =true;
					tbbtnNew.Enabled =false;
					tbbtnModify.Enabled =false;
					tbbtnDelete.Enabled =false;
					tbbtnRefresh.Enabled =false;
					foreach(Control ctl in plData.Controls)
					{
						if(!ctl.GetType().IsSubclassOf(typeof(System.Windows.Forms.Label)) && ctl.GetType()!=typeof(System.Windows.Forms.Label))
						{
							ctl.Enabled =true;
						}
					}
					break;
			}
		}
		/// <summary>
		/// 显示数据
		/// </summary>
		private void DisplayData()
		{
			if ( cardGrid.Visible )
				cardGrid.Visible = false;
			try
			{
				DataView dv=(DataView)dtgrdMain.DataSource;
				DateTimePicker dtp;
				PictureBox pic;
				if(dv.Count>0)
				{
					DataRowView drv=dv[_curRowIndex];
					foreach(Control ctrl in plData.Controls)
					{
						if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || ctrl.GetType()==typeof(System.Windows.Forms.TextBox))
						{
							TEXTBOXTAG txtTag=(TEXTBOXTAG)ctrl.Tag;
							if(txtTag.FieldProperty.ShowCardSql!="")
							{
								ctrl.Text =Convertor.IsNull(drv[txtTag.FieldProperty.DatabaseName+"_CN"],"");
								txtTag.Value =Convertor.IsNull(drv[txtTag.FieldProperty.DatabaseName],"");
								ctrl.Tag =txtTag;
							}
							else if(txtTag.FieldProperty.SpeciType==FieldSpeciType.PASSWORD)
							{

								ctrl.Text =Crypto.Instance().Decrypto(Convertor.IsNull(drv[txtTag.FieldProperty.DatabaseName],""));
							}
							else
							{
								ctrl.Text =Convertor.IsNull(drv[txtTag.FieldProperty.DatabaseName],"");
							}
						}
						else if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.DateTimePicker)) || ctrl.GetType()==typeof(System.Windows.Forms.DateTimePicker))
						{
							dtp=(DateTimePicker)ctrl;
							dtp.Value =Convert.ToDateTime(Convertor.IsNull(drv[((TEXTBOXTAG)ctrl.Tag).FieldProperty.DatabaseName],DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString()));
						}	
						else if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.PictureBox)) || ctrl.GetType()==typeof(System.Windows.Forms.PictureBox))
						{
							pic=(PictureBox)ctrl;
							TEXTBOXTAG txtTag=(TEXTBOXTAG)ctrl.Tag;
							Object obj=drv[txtTag.FieldProperty.DatabaseName];
							if(!Convert.IsDBNull(obj))
							{
								MemoryStream buf=new MemoryStream((byte[])obj);
								Image image=Image.FromStream(buf,true);
								pic.Image=image;
								txtTag.Value =obj;
								pic.Tag =txtTag;
							}
							else
							{
								pic.Image=null;
								txtTag.Value =null;
								pic.Tag =txtTag;
							}
						}	
					}
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}
		/// <summary>
		/// 清空文本框内容
		/// </summary>
		private void ClearControl()
		{
			DateTimePicker dtp;
			PictureBox pic;
			foreach(Control ctrl in plData.Controls)
			{
				if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || ctrl.GetType()==typeof(System.Windows.Forms.TextBox))
				{
					TEXTBOXTAG txtTag=(TEXTBOXTAG)ctrl.Tag;
					ctrl.Text =txtTag.FieldProperty.DefaultValue;
					txtTag.Value =null;
					ctrl.Tag =txtTag;
				}
				else if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.DateTimePicker)) || ctrl.GetType()==typeof(System.Windows.Forms.DateTimePicker))
				{
					dtp=(DateTimePicker)ctrl;
					TEXTBOXTAG txtTag=(TEXTBOXTAG)dtp.Tag;
					txtTag.Value =null;
					dtp.Tag =txtTag;
					dtp.Value =DateTime.Now;
				}
				else if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.PictureBox)) || ctrl.GetType()==typeof(System.Windows.Forms.PictureBox))
				{
					pic=(PictureBox)ctrl;
					TEXTBOXTAG txtTag=(TEXTBOXTAG)pic.Tag;
					txtTag.Value =null;
					pic.Tag =txtTag;
					pic.Image =null;
				}	
			}
		}
		/// <summary>
		/// 根据字段类型得出字段值的保存格式
		/// </summary>
		/// <param name="tableField"></param>
		/// <returns></returns>
		private string GetFieldValueByType(Type fieldType,object fvalue)
		{
			string fieldValue="";
			if(fieldType!=null)
			{
				switch(fieldType.ToString())
				{
					case "System.String" :
						fieldValue="'"+Convert.ToString(fvalue)+"'";
						break;
					case "System.DateTime" :
						fieldValue="'"+Convert.ToString(fvalue)+"'";
						break;
					case "System.Byte[]":
						fieldValue="null";
						break;
					default :
						fieldValue=Convertor.IsNull(fvalue,"-1");	//默认为-1
						if(fieldValue=="")
						{
							fieldValue="-1";
						}
						break;
				}
			}
			else
			{
				fieldValue="'"+Convert.ToString(fvalue)+"'";
			}
			return fieldValue;
		}
		/// <summary>
		/// 根据字段类型得出字段默认值的保存格式
		/// </summary>
		/// <param name="tableField"></param>
		/// <returns></returns>
		private string GetFieldDefaultValueByType(Type fieldType)
		{
			string fieldValue="";
			if(fieldType!=null)
			{
				switch(fieldType.ToString())
				{
					case "System.String" :
						fieldValue="''";
						break;
					case "System.DateTime" :
						fieldValue="'"+DateTime.Now.ToString()+"'";
						break;	
					case "System.Byte[]":
						fieldValue="null";
						break;
					case "System.Byte" :
						fieldValue="0";
						break;
					default :
						fieldValue="1";	//默认为1
						break;
				}
			}
			else
			{
				fieldValue="''";
			}
			return fieldValue;
		}
		/// <summary>
		/// 获取删除字段名
		/// </summary>
		/// <returns></returns>
		private string GetDeleteFieldsName()
		{
			string fieldsName = "delete_bit";
			for( int i=0; i< _tableFields.Length; i ++ )
			{
				if ( _tableFields[i].IsDeleteField )
				{
					fieldsName = _tableFields[i].DatabaseName;
					break;
				}
			}
			return fieldsName;
		}
		/// <summary>
		/// 保存数据
		/// </summary>
		/// <returns></returns>
		private bool SaveData()
		{
			bool beginTransaction=false;
			try
			{
				TEXTBOXTAG txtTag;
				#region 数据校验（每个字段通过正则表达式进行校验，对于不允许重复字段亦进行检验）
				if(_uniqueKeyFieldctrl ==null)
				{
					MessageBox.Show("没有设置唯一索引字段！","提示");
					return false;
				}
				//正则表达式对象
				Regex r;
				foreach(Control ctrl in plData.Controls)
				{
					string fvalue="0";
					object count;
					string filter="";
					if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || ctrl.GetType()==typeof(System.Windows.Forms.TextBox))
					{
						txtTag=(TEXTBOXTAG)ctrl.Tag;
						if(!txtTag.FieldProperty.IsAutoIncrease && !txtTag.FieldProperty.IsDeleteField)
						{
							if(txtTag.FieldProperty.ShowCardSql!="")
							{
								fvalue=Convertor.IsNull(txtTag.Value,"-1");
							}
							else if(txtTag.FieldProperty.SpeciType==FieldSpeciType.PASSWORD)
							{
								fvalue=Crypto.Instance().Encrypto(ctrl.Text.Trim());
							}
							else
							{
								fvalue=ctrl.Text.Trim();
							}
						}
						if(txtTag.FieldProperty.RegularExpressions!="")
						{
							r=new Regex(txtTag.FieldProperty.RegularExpressions);
							if (!r.IsMatch(fvalue)) 
							{
								MessageBox.Show("【"+txtTag.FieldProperty.ChineseName+"】数据不合法，请重新输入！","提示");
								ctrl.Focus();
								return false;
							}
						}	
						if(txtTag.FieldProperty.UnAllowRepeat)	//不允许重复
						{
							filter=txtTag.FieldProperty.DatabaseName+@"="+GetFieldValueByType(_pubDataSet.Tables[_tableName].Columns[txtTag.FieldProperty.DatabaseName].DataType,fvalue)+@" 
									and "+((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName+"<>"+GetFieldValueByType(_uniqueKeyFildType,_uniqueKeyFieldctrl.Text);
							count=_pubDataSet.Tables[_tableName].Compute("count("+txtTag.FieldProperty.DatabaseName+")",filter);
							if(Convert.ToInt32(Convertor.IsNull(count,"0"))>0)
							{
								MessageBox.Show("【"+txtTag.FieldProperty.ChineseName+"】数据重复，请重新输入！","提示");
								ctrl.Focus();
								return false;
							}
						}
					}
					else if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.DateTimePicker)) || ctrl.GetType()==typeof(System.Windows.Forms.DateTimePicker))
					{
						txtTag=(TEXTBOXTAG)ctrl.Tag;
						fvalue=((System.Windows.Forms.DateTimePicker)ctrl).Value.ToString();
						if(txtTag.FieldProperty.RegularExpressions!="")
						{
							r=new Regex(txtTag.FieldProperty.RegularExpressions);
							if (!r.IsMatch(fvalue)) 
							{
								MessageBox.Show("【"+txtTag.FieldProperty.ChineseName+"】数据不合法，请重新输入！","提示");
								return false;
							}
						}	
						if(txtTag.FieldProperty.UnAllowRepeat)	//不允许重复
						{
							filter=txtTag.FieldProperty.DatabaseName+@"="+GetFieldValueByType(_pubDataSet.Tables[_tableName].Columns[txtTag.FieldProperty.DatabaseName].DataType,fvalue)+@" 
									and "+((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName+"<>"+GetFieldValueByType(_uniqueKeyFildType,_uniqueKeyFieldctrl.Text);
							count=_pubDataSet.Tables[_tableName].Compute("count("+txtTag.FieldProperty.DatabaseName+")",filter);
							if(Convert.ToInt32(Convertor.IsNull(count,"0"))>0)
							{
								MessageBox.Show("【"+txtTag.FieldProperty.ChineseName+"】数据重复！","提示");
								return false;
							}
						}
					}
					//数据类型为System.Byte[]的不作判
				}
				r=null;
				#endregion

				string sql;
				if(_status==CurrentStatus.新建状态)
				{
					#region 构造insert SQL语句
					sql=@"Insert into "+_tableName+"(";
					string fieldValue="";
					DataView dv=(DataView)dtgrdMain.DataSource;
					bool hasIdenitityField = false;
					 //判断是否有自增字段
					for(int i=0;i<_tableFields.Length;i++)
					{
						if(_tableFields[i].IsAutoIncrease )
						{
							hasIdenitityField = true;
							break;
						}
					}

					for(int i=0;i<_tableFields.Length;i++)
					{
						if(!_tableFields[i].IsAutoIncrease && !_tableFields[i].IsDeleteField)
						{
							sql+=_tableFields[i].DatabaseName+",";
							if ( hasIdenitityField )
							{
								fieldValue+=GetFieldDefaultValueByType(dv.Table.Columns[_tableFields[i].DatabaseName].DataType)+",";
							}
							else
							{
								if ( _tableFields[i].IsUniqueKey )
								{
									fieldValue += GetFieldValueByType(_uniqueKeyFildType,_uniqueKeyFieldctrl.Text)+"," ;	
								}
								else
								{
									fieldValue +=GetFieldDefaultValueByType(dv.Table.Columns[_tableFields[i].DatabaseName].DataType)+",";
								}
							}
						}
					}
					sql=sql.Substring(0,sql.Length-1)+") Values ("+fieldValue.Substring(0,fieldValue.Length-1)+")";
					#endregion
					try
					{
						InstanceForm.BDatabase.BeginTransaction();
						if ( hasIdenitityField )
						{
							object identity;
							int ret=InstanceForm.BDatabase.InsertRecord(sql,out identity);
							if(ret<=0)
							{
								InstanceForm.BDatabase.RollbackTransaction();
								MessageBox.Show("数据插入失败！","提示");
								return false;
							}
							sql="Select * from "+_tableName+" where "+((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName+"="+GetFieldValueByType(_uniqueKeyFildType,identity.ToString());
						}
						else
						{
							//如果没有自增长字段，插入后用唯一索引键获得记录
							int ret = InstanceForm.BDatabase.DoCommand(sql);
							if ( ret <= 0 )
							{
								InstanceForm.BDatabase.RollbackTransaction();
								MessageBox.Show("数据插入失败！","提示");
								return false;
							}
							sql="Select * from "+_tableName+" where "+((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName+"="+GetFieldValueByType(_uniqueKeyFildType,_uniqueKeyFieldctrl.Text) ;
						}
						InstanceForm.BDatabase.CommitTransaction();
					}
					catch(Exception err)
					{
						MessageBox.Show(err.Message);
						InstanceForm.BDatabase.RollbackTransaction();
						return false;
					}
				}
				else
				{
					sql="Select * from "+_tableName+" where "+((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName+"="+GetFieldValueByType(_uniqueKeyFildType,_uniqueKeyFieldctrl.Text);
				}
				DataSet dataSet=new DataSet();
				//开始事务
				InstanceForm.BDatabase.BeginTransaction();
				beginTransaction=true;
				//主表适配器
				DbDataAdapter ada0=InstanceForm.BDatabase.GetAdapter(sql);
				InstanceForm.BDatabase.CreateCommandBuilder(ada0);
			
				ada0.Fill(dataSet,_tableName);
				//数据内容
				DataRow mRow;
				mRow=dataSet.Tables[_tableName].Rows[0];
				//赋值
				foreach(Control ctrl in plData.Controls)
				{
					if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || ctrl.GetType()==typeof(System.Windows.Forms.TextBox))
					{
						txtTag=(TEXTBOXTAG)ctrl.Tag;
						if(!txtTag.FieldProperty.IsAutoIncrease && !txtTag.FieldProperty.IsDeleteField)
						{
							if(txtTag.FieldProperty.ShowCardSql!="")
							{
								if ( ctrl.Text == "" )
								{
									mRow[txtTag.FieldProperty.DatabaseName]="-1";
								}
								else
								{
									mRow[txtTag.FieldProperty.DatabaseName]=Convertor.IsNull(txtTag.Value,"-1");
								}
							}
							else if(txtTag.FieldProperty.SpeciType==FieldSpeciType.PASSWORD)
							{
								mRow[txtTag.FieldProperty.DatabaseName]=Crypto.Instance().Encrypto(ctrl.Text.Trim());
							}
							else
							{
								if ( ((TableField)txtTag.FieldProperty).FieldType == Type.GetType("System.String") || ((TableField)txtTag.FieldProperty).FieldType == Type.GetType("System.DateTime") )
									mRow[txtTag.FieldProperty.DatabaseName]=ctrl.Text.Trim();
								else
								{
									if ( ctrl.Text == "" )
									{
										mRow[txtTag.FieldProperty.DatabaseName] = DBNull.Value;
									}
									else
									{
										mRow[txtTag.FieldProperty.DatabaseName] = ctrl.Text;
									}
								}
							}
						}
					}
					else if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.DateTimePicker)) || ctrl.GetType()==typeof(System.Windows.Forms.DateTimePicker))
					{
						txtTag=(TEXTBOXTAG)ctrl.Tag;
						mRow[txtTag.FieldProperty.DatabaseName]=((System.Windows.Forms.DateTimePicker)ctrl).Value;
					}
					else if(ctrl.GetType().IsSubclassOf(typeof(System.Windows.Forms.PictureBox)) || ctrl.GetType()==typeof(System.Windows.Forms.PictureBox))
					{
						txtTag=(TEXTBOXTAG)ctrl.Tag;
						if(txtTag.Value!=null)
						{
							mRow[txtTag.FieldProperty.DatabaseName]=txtTag.Value;
						}
						else
						{
							mRow[txtTag.FieldProperty.DatabaseName]=System.DBNull.Value;
						}
					}	
				}
				//更新数据
				ada0.Update(dataSet, _tableName);
				//提交事务
				InstanceForm.BDatabase.CommitTransaction();
				_uniqueKeyFieldctrl.Text=Convertor.IsNull(mRow[((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName],"-1");
				MessageBox.Show("保存成功！","提示");
				//释放资源
				mRow=null;
				ada0.Dispose();
				dataSet.Dispose();
				return true;
			}
			catch(Exception err)
			{
				if(beginTransaction)
				{
					//回滚事务
					InstanceForm.BDatabase.RollbackTransaction();
				}
				MessageBox.Show(err.Message,"错误");
				return false;
			}
		}
		/// <summary>
		/// 测试图片是否为有效图片
		/// </summary>
		/// <param name="image"></param>
		/// <returns></returns>
		private bool TestImageValidate(Image image)
		{
			try
			{
				ImageList img=new ImageList();
				img.Images.Add(image);
				img.Dispose();
				return true;
			}
			catch(Exception err)
			{
				MessageBox.Show("错误原因："+err.Message+"\n请选择其他图片！","错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
		}
		#endregion

		#region 主窗体事件
		private void FrmDataMaintenance_Load(object sender, System.EventArgs e)
		{
			//变量初始化
			_curRowIndex=-1;
			_uniqueKeyFieldctrl=null;
			_deleteFieldctrl=null;
			_pubDataSet=new DataSet();
			_filterType=Constant.CustomFilterType ;
			_searchType=Constant.CustomSearchType ;
			_il=PubStaticFun.GetInputLanguage(Constant.CustomImeMode);

			//初始化网格及数据面板
			CreateGridStyle();
			
			//创建初始数据
			CreateDataSet();
			//创建数据面板
			CreateDataPanel();

			dtgrdMain_CurrentCellChanged(null,null);

			ChangeByStatus(CurrentStatus.查询状态);
		}
		#endregion

		#region 工具栏事件
		private void tbarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			Cursor.Current =Cursors.WaitCursor;
			try
			{
				int buttonTag=Convert.ToInt32(e.Button.Tag);
				DataView dv=(DataView)dtgrdMain.DataSource;
				switch(buttonTag)
				{
					case  0 :			//添加
						ChangeByStatus(CurrentStatus.新建状态);
						ClearControl();
						if(_fistVisiblectrl!=null)
						{
							_fistVisiblectrl.Focus();
						}
						break;
					case  1 :			//修改
						if(dv.Count>0)
						{
							ChangeByStatus(CurrentStatus.修改状态);
						}
						else
						{
							MessageBox.Show("请选择具体行！","提示");
						}
						if(_fistVisiblectrl!=null)
						{
							_fistVisiblectrl.Focus();
						}
						break;
					case  2 :			//删除
						if(_uniqueKeyFieldctrl ==null)
						{
							MessageBox.Show("没有设置唯一索引字段！","提示");
							return ;
						}
						if(dv.Count>0)
						{
							
							string sMessage = "";
							string sql;
							if(_deleteFieldctrl==null)
							{
								sql="Delete from "+_tableName+" where "+((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName+"="+GetFieldValueByType(_uniqueKeyFildType,_uniqueKeyFieldctrl.Text);
								sMessage = "准备执行删除操作。。删除后不可恢复！\n确定要删除吗?";
							}
							else
							{
								sql="Update "+_tableName+" set " + GetDeleteFieldsName() + " =1 where "+((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName+"="+GetFieldValueByType(_uniqueKeyFildType,_uniqueKeyFieldctrl.Text);
								sMessage = "确定要将选择的记录置无效吗？";
							}
								//sql="Update "+_tableName+" set " + GetDeleteFieldsName() + "=1 where "+((TEXTBOXTAG)_uniqueKeyFieldctrl.Tag).FieldProperty.DatabaseName+"="+GetFieldValueByType(_uniqueKeyFildType,_uniqueKeyFieldctrl.Text);
							if(MessageBox.Show( sMessage ,"询问",MessageBoxButtons.YesNo,MessageBoxIcon.Question ,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
							{
								int ret=InstanceForm.BDatabase.DoCommand(sql);
								if(ret>0)
								{
									RefreshData();
								}
								else
								{
									MessageBox.Show("删除失败！","提示");
								}
							}
							
						}
						else
						{
							MessageBox.Show("请选择具体行！","提示");
						}
						break;
					case  3 :			//保存
						if(SaveData())
						{
							ChangeByStatus(CurrentStatus.查询状态);
							RefreshData();
						}
						break;
					case  4 :			//取消
						ChangeByStatus(CurrentStatus.查询状态);
						DisplayData();
						break;
					case  5 :			//刷新
						RefreshData();
						break;
					case  11 :			//关闭窗口
						this.Close();
						break;
				}
				Cursor.Current =Cursors.Default;
			}
			catch(Exception err)
			{
				Cursor.Current =Cursors.Default;
				MessageBox.Show(err.Message,"错误");
			}
		}
		#endregion 

		#region 网格事件
		private void dtgrdMain_CurrentCellChanged(object sender, System.EventArgs e)
		{
			//选中网格
			dtgrdMain.SelectCurrentRow();
			if(_status ==CurrentStatus.查询状态)
			{
				if(_curRowIndex!=dtgrdMain.CurrentRowIndex)
				{
					_curRowIndex=dtgrdMain.CurrentRowIndex;
					//显示数据于左边数据面板
					DisplayData();
				}
			}
			else if(_curRowIndex!=dtgrdMain.CurrentRowIndex)
			{
				dtgrdMain.CurrentCell =new DataGridCell(_curRowIndex,0);
			}
		}
		private void cardGrid_CurrentCellChanged(object sender, System.EventArgs e)
		{
			//选中网格
			cardGrid.SelectCurrentRow();
		}
		private void cardGrid_DoubleClick(object sender, System.EventArgs e)
		{
			if(_curActivectrl!=null)
			{
				_curActivectrl.Focus();
				ctrl_KeyUp(_curActivectrl,new KeyEventArgs(Keys.Enter));
			}
		}
		private void cardGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Enter)
			{
				cardGrid_DoubleClick(null,null);
			}
		}
		private bool cardGrid_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			if(keyData ==Keys.Enter)
			{
				cardGrid_DoubleClick(null,null);
			}
			return false;
		}
		#endregion

		#region 数据面板
		private void ctrl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if(e.KeyValue ==13  && !cardGrid.Visible)
			{
				if(sender.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || sender.GetType()==typeof(System.Windows.Forms.TextBox))
				{
					if(!((TextBox)sender).Multiline)
					{
						SendKeys.Send("{TAB}");
					}
				}
			}
			else
			{
				if(sender.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || sender.GetType()==typeof(System.Windows.Forms.TextBox))
				{
					Control ctrl=(Control)sender;
					TEXTBOXTAG txtTag=(TEXTBOXTAG)ctrl.Tag;
					if(txtTag.FieldProperty.ShowCardSql!="")
					{
						bool respondKey=false;
						_curActivectrl=ctrl;
						DataRow dr=WorkStaticFun.GetCardData(ctrl,e.KeyValue,-1,cardGrid,0,_pubDataSet,txtTag.FieldProperty.DatabaseName+"_TABLE",_filterType,_searchType, ref respondKey,"","");
						if((e.KeyValue ==13 || (e.KeyValue>=48 && e.KeyValue<=57) || (e.KeyValue>=96 && e.KeyValue<=105))  && dr!=null)
						{
							ctrl.Text =Convert.ToString (dr["NAME"]);
							txtTag.Value  =dr["ID"];
							ctrl.Tag =txtTag;
							SendKeys.Send("{TAB}");
						}
					}
				}
			}
		}
		private void ctrl_Enter(object sender, System.EventArgs e)
		{
			if(((TEXTBOXTAG)((Control)sender).Tag).FieldProperty.ShowCardSql!="")
			{
				InputLanguage.CurrentInputLanguage=PubStaticFun.GetInputLanguage("美式键盘");
			}
			else
			{
				InputLanguage.CurrentInputLanguage=_il;
			}
		}
		private void ctrl_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(((TEXTBOXTAG)((Control)sender).Tag).FieldProperty.IsNameField)
				{
					//生成拼音简码与五笔简码
					if(_pyCodeFieldctrl!=null)
					{
						_pyCodeFieldctrl.Text =PubStaticFun.GetPYWBM(((Control)sender).Text,0);
					}
					if(_wbCodeFieldctrl!=null)
					{
						_wbCodeFieldctrl.Text =PubStaticFun.GetPYWBM(((Control)sender).Text,1);
					}
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"错误");
			}
		}
		private void pic_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				this.dlgOpen.Filter = "ICON 图片(*.ico)|*.ico";
				dlgOpen.Title = "请选择图片";
				if(this.dlgOpen.ShowDialog()==DialogResult.OK)
				{
					PictureBox pic=(PictureBox)sender;

					pic.Image=Image.FromFile(this.dlgOpen.FileName);
					FileStream fs=new FileStream(this.dlgOpen.FileName,FileMode.OpenOrCreate,FileAccess.Read);
					byte[] theData=new byte[fs.Length];
					fs.Read(theData,0,System.Convert.ToInt32(fs.Length));
					fs.Close();
					TEXTBOXTAG picTag=(TEXTBOXTAG)pic.Tag;
					picTag.Value =theData;
					pic.Tag =picTag;
					if(!TestImageValidate(pic.Image))
					{
						pic.Image=null;
					}
					theData=null;
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"错误");
			}
		}
		private void mnuModifyPic_Click(object sender, System.EventArgs e)
		{
			pic_DoubleClick((mnuModifyPic.GetContextMenu()).SourceControl,e);
		}

		private void mnuDeletePic_Click(object sender, System.EventArgs e)
		{
			try
			{
				PictureBox pic=(PictureBox)((mnuDeletePic.GetContextMenu()).SourceControl);
				pic.Image =null;
				TEXTBOXTAG picTag=(TEXTBOXTAG)pic.Tag;
				picTag.Value =null;
				pic.Tag =picTag;
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"错误");
			}
		}
		#endregion
	}
}
