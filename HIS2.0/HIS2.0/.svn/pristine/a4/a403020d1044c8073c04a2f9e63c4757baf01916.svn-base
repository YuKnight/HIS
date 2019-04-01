using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace TrasenFrame.Forms
{
	/// <summary>
	/// FrmMessage 的摘要说明。
	/// </summary>
	public class FrmMessage : System.Windows.Forms.Form
	{
		private int msgId = 0;
		private bool isAdmin = false;
        private int showType = 0;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnRelease;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.RichTextBox txtReleaseContent;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.ListView lvwTitle;
		private System.Windows.Forms.RichTextBox txtMessage;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.ListView lvwSystem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDay;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Button btnCenter;
		private System.Windows.Forms.Button btnRight;
		private System.Windows.Forms.Button btnLeft;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button btnColor;
		private System.Windows.Forms.Button btnFont;
		private System.Windows.Forms.Button btnSelectAll;
		private System.Windows.Forms.Button btnUnSelect;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnNew;
		private System.ComponentModel.IContainer components;

		public FrmMessage(bool IsAdmin,int type)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            showType = type;
			isAdmin = IsAdmin;
			if ( ! IsAdmin )
			{
				this.tabControl1.TabPages.RemoveAt(1);
				this.btnDelete.Visible = false;
			}
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
            this.components = new System.ComponentModel.Container( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmMessage ) );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.tabControl1 = new System.Windows.Forms.TabControl( );
            this.tabPage1 = new System.Windows.Forms.TabPage( );
            this.panel3 = new System.Windows.Forms.Panel( );
            this.txtMessage = new System.Windows.Forms.RichTextBox( );
            this.splitter1 = new System.Windows.Forms.Splitter( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.lvwTitle = new System.Windows.Forms.ListView( );
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader( );
            this.panel4 = new System.Windows.Forms.Panel( );
            this.btnDelete = new System.Windows.Forms.Button( );
            this.dtpDate = new System.Windows.Forms.DateTimePicker( );
            this.label1 = new System.Windows.Forms.Label( );
            this.tabPage2 = new System.Windows.Forms.TabPage( );
            this.btnNew = new System.Windows.Forms.Button( );
            this.label5 = new System.Windows.Forms.Label( );
            this.btnUnSelect = new System.Windows.Forms.Button( );
            this.btnSelectAll = new System.Windows.Forms.Button( );
            this.panel7 = new System.Windows.Forms.Panel( );
            this.btnColor = new System.Windows.Forms.Button( );
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.btnFont = new System.Windows.Forms.Button( );
            this.panel8 = new System.Windows.Forms.Panel( );
            this.btnLeft = new System.Windows.Forms.Button( );
            this.btnRight = new System.Windows.Forms.Button( );
            this.btnCenter = new System.Windows.Forms.Button( );
            this.txtDay = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.lvwSystem = new System.Windows.Forms.ListView( );
            this.btnRelease = new System.Windows.Forms.Button( );
            this.txtReleaseContent = new System.Windows.Forms.RichTextBox( );
            this.txtTitle = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.panel1.SuspendLayout( );
            this.tabControl1.SuspendLayout( );
            this.tabPage1.SuspendLayout( );
            this.panel3.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.panel4.SuspendLayout( );
            this.tabPage2.SuspendLayout( );
            this.panel7.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.tabControl1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 701 , 402 );
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point( 0 , 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 701 , 402 );
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler( this.tabControl1_SelectedIndexChanged );
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.panel3 );
            this.tabPage1.Controls.Add( this.splitter1 );
            this.tabPage1.Controls.Add( this.panel2 );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size( 693 , 377 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查阅";
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.txtMessage );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point( 294 , 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 399 , 377 );
            this.panel3.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point( 0 , 0 );
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size( 399 , 377 );
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point( 291 , 0 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 3 , 377 );
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.lvwTitle );
            this.panel2.Controls.Add( this.panel4 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point( 0 , 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 291 , 377 );
            this.panel2.TabIndex = 0;
            // 
            // lvwTitle
            // 
            this.lvwTitle.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3} );
            this.lvwTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTitle.FullRowSelect = true;
            this.lvwTitle.HideSelection = false;
            this.lvwTitle.Location = new System.Drawing.Point( 0 , 31 );
            this.lvwTitle.MultiSelect = false;
            this.lvwTitle.Name = "lvwTitle";
            this.lvwTitle.Size = new System.Drawing.Size( 291 , 346 );
            this.lvwTitle.TabIndex = 1;
            this.lvwTitle.UseCompatibleStateImageBehavior = false;
            this.lvwTitle.View = System.Windows.Forms.View.Details;
            this.lvwTitle.DoubleClick += new System.EventHandler( this.lvwTitle_DoubleClick );
            this.lvwTitle.SelectedIndexChanged += new System.EventHandler( this.lvwTitle_SelectedIndexChanged );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "主题";
            this.columnHeader1.Width = 129;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "发布人";
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.btnDelete );
            this.panel4.Controls.Add( this.dtpDate );
            this.panel4.Controls.Add( this.label1 );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point( 0 , 0 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 291 , 31 );
            this.panel4.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point( 175 , 5 );
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 46 , 23 );
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point( 44 , 5 );
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowCheckBox = true;
            this.dtpDate.Size = new System.Drawing.Size( 129 , 21 );
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler( this.dtpDate_ValueChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12 , 8 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 29 , 12 );
            this.label1.TabIndex = 1;
            this.label1.Text = "时间";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.btnNew );
            this.tabPage2.Controls.Add( this.label5 );
            this.tabPage2.Controls.Add( this.btnUnSelect );
            this.tabPage2.Controls.Add( this.btnSelectAll );
            this.tabPage2.Controls.Add( this.panel7 );
            this.tabPage2.Controls.Add( this.txtDay );
            this.tabPage2.Controls.Add( this.label4 );
            this.tabPage2.Controls.Add( this.label3 );
            this.tabPage2.Controls.Add( this.lvwSystem );
            this.tabPage2.Controls.Add( this.btnRelease );
            this.tabPage2.Controls.Add( this.txtReleaseContent );
            this.tabPage2.Controls.Add( this.txtTitle );
            this.tabPage2.Controls.Add( this.label2 );
            this.tabPage2.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size( 693 , 377 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "发布";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point( 521 , 345 );
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size( 76 , 27 );
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "重置";
            this.btnNew.Click += new System.EventHandler( this.btnNew_Click );
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point( 139 , 352 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 250 , 17 );
            this.label5.TabIndex = 14;
            this.label5.Text = "提示:在查阅窗口中双击消息标题可进行修改";
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point( 139 , 234 );
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size( 39 , 23 );
            this.btnUnSelect.TabIndex = 13;
            this.btnUnSelect.Text = "反选";
            this.btnUnSelect.Click += new System.EventHandler( this.btnUnSelect_Click );
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point( 98 , 234 );
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size( 39 , 23 );
            this.btnSelectAll.TabIndex = 12;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.Click += new System.EventHandler( this.btnSelectAll_Click );
            // 
            // panel7
            // 
            this.panel7.Controls.Add( this.btnColor );
            this.panel7.Controls.Add( this.btnFont );
            this.panel7.Controls.Add( this.panel8 );
            this.panel7.Controls.Add( this.btnLeft );
            this.panel7.Controls.Add( this.btnRight );
            this.panel7.Controls.Add( this.btnCenter );
            this.panel7.Location = new System.Drawing.Point( 520 , 231 );
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size( 172 , 26 );
            this.panel7.TabIndex = 11;
            // 
            // btnColor
            // 
            this.btnColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnColor.ImageIndex = 3;
            this.btnColor.ImageList = this.imageList1;
            this.btnColor.Location = new System.Drawing.Point( 122 , 0 );
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size( 29 , 26 );
            this.btnColor.TabIndex = 19;
            this.btnColor.Click += new System.EventHandler( this.btnColor_Click );
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList1.ImageStream" ) ) );
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName( 0 , "" );
            this.imageList1.Images.SetKeyName( 1 , "" );
            this.imageList1.Images.SetKeyName( 2 , "" );
            this.imageList1.Images.SetKeyName( 3 , "" );
            this.imageList1.Images.SetKeyName( 4 , "" );
            // 
            // btnFont
            // 
            this.btnFont.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFont.ImageIndex = 2;
            this.btnFont.ImageList = this.imageList1;
            this.btnFont.Location = new System.Drawing.Point( 93 , 0 );
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size( 29 , 26 );
            this.btnFont.TabIndex = 18;
            this.btnFont.Click += new System.EventHandler( this.btnFont_Click );
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point( 87 , 0 );
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size( 6 , 26 );
            this.panel8.TabIndex = 17;
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLeft.ImageIndex = 4;
            this.btnLeft.ImageList = this.imageList1;
            this.btnLeft.Location = new System.Drawing.Point( 58 , 0 );
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size( 29 , 26 );
            this.btnLeft.TabIndex = 16;
            this.btnLeft.Click += new System.EventHandler( this.btnLeft_Click );
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRight.ImageIndex = 0;
            this.btnRight.ImageList = this.imageList1;
            this.btnRight.Location = new System.Drawing.Point( 29 , 0 );
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size( 29 , 26 );
            this.btnRight.TabIndex = 11;
            this.btnRight.Click += new System.EventHandler( this.btnRight_Click );
            // 
            // btnCenter
            // 
            this.btnCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCenter.ImageIndex = 1;
            this.btnCenter.ImageList = this.imageList1;
            this.btnCenter.Location = new System.Drawing.Point( 0 , 0 );
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size( 29 , 26 );
            this.btnCenter.TabIndex = 10;
            this.btnCenter.Click += new System.EventHandler( this.btnCenter_Click );
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point( 65 , 349 );
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size( 63 , 21 );
            this.txtDay.TabIndex = 8;
            this.txtDay.Text = "1";
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtDay_KeyPress );
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point( 6 , 350 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 100 , 23 );
            this.label4.TabIndex = 7;
            this.label4.Text = "有效天数";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 8 , 235 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 82 , 11 );
            this.label3.TabIndex = 6;
            this.label3.Text = "可接收的系统";
            // 
            // lvwSystem
            // 
            this.lvwSystem.CheckBoxes = true;
            this.lvwSystem.Location = new System.Drawing.Point( 2 , 258 );
            this.lvwSystem.Name = "lvwSystem";
            this.lvwSystem.Size = new System.Drawing.Size( 689 , 85 );
            this.lvwSystem.TabIndex = 5;
            this.lvwSystem.UseCompatibleStateImageBehavior = false;
            this.lvwSystem.View = System.Windows.Forms.View.List;
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point( 600 , 345 );
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size( 76 , 27 );
            this.btnRelease.TabIndex = 4;
            this.btnRelease.Text = "发布";
            this.btnRelease.Click += new System.EventHandler( this.btnRelease_Click );
            // 
            // txtReleaseContent
            // 
            this.txtReleaseContent.Location = new System.Drawing.Point( 1 , 30 );
            this.txtReleaseContent.Name = "txtReleaseContent";
            this.txtReleaseContent.Size = new System.Drawing.Size( 690 , 200 );
            this.txtReleaseContent.TabIndex = 2;
            this.txtReleaseContent.Text = "";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point( 43 , 6 );
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size( 637 , 21 );
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10 , 11 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 29 , 12 );
            this.label2.TabIndex = 0;
            this.label2.Text = "标题";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.Location = new System.Drawing.Point( 609 , 406 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 83 , 26 );
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // FrmMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 701 , 440 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.panel1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息窗口";
            this.Load += new System.EventHandler( this.FrmMessage_Load );
            this.panel1.ResumeLayout( false );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            this.panel4.PerformLayout( );
            this.tabPage2.ResumeLayout( false );
            this.tabPage2.PerformLayout( );
            this.panel7.ResumeLayout( false );
            this.ResumeLayout( false );

		}
		#endregion

		private void LoadMessageTitle()
		{
			try
			{
                string sql = "select top 20 msgid,title,releaseDate,recivesystem,dbo.fun_getempname(releaseor) as releaseor from pub_message where deletebit=0 order by sort desc,releaseDate desc";//Modify By Tany 2012-04-17 增加置顶排序
                //if ( this.dtpDate.Checked )
                //{
                //    sql ="select msgid,title,releaseDate,recivesystem,dbo.fun_getempname(releaseor) as releaseor from pub_message where deletebit=0 and releasedate between '" + dtpDate.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpDate.Value.ToString("yyyy-MM-dd")  + " 23:59:59' order by releaseDate desc";
                //}
                //if ( showType == 1 )
                //{
                //    //如果是启动的时候，只显示有效天数内的消息
                //    sql = "select msgid,title,releaseDate,recivesystem,dbo.fun_getempname(releaseor) as releaseor from pub_message where deletebit=0 and datediff(d,releasedate,getdate())<=invalidday order by releaseDate desc";

                //}
				DataTable table = FrmMdiMain.Database.GetDataTable( sql );
				this.lvwTitle.Items.Clear();
				for( int i=0;i<table.Rows.Count;i++)
				{
					bool show = false;
					if ( FrmMdiMain.CurrentUser.IsAdministrator )
					{
						show = true;
					}
					else
					{
						string[] sys = table.Rows[i]["recivesystem"].ToString().Split(",".ToCharArray());
						if ( sys.Length == 0 )
						{	show = true;}
						else
						{
							for(int j = 0 ;j < sys.Length;j ++ )
							{
								if ( Convert.ToInt32(sys[j]) == FrmMdiMain.CurrentSystem.SystemId )
								{
									show = true;
									break;
								}
							}
						}
					}
					if ( show )
					{
						ListViewItem item = new ListViewItem();
						item.Text = table.Rows[i]["title"].ToString();
						item.SubItems.Add( Convert.ToDateTime(table.Rows[i]["releaseDate"]).ToString("yyyy-MM-dd hh:ss:mm"));
						item.SubItems.Add( table.Rows[i]["releaseor"].ToString().Trim());
						item.Tag = Convert.ToInt32( table.Rows[i]["msgid"] );
						this.lvwTitle.Items.Add( item );
					}
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void LoadMessageContent(int MsgId)
		{
			try
			{
				MemoryStream ms=null;
				string sql = "select Content from pub_message where msgid=" + MsgId;
				object objContent = FrmMdiMain.Database.GetDataResult( sql );
				Byte[] rtf=(byte[])objContent;
				ms=new MemoryStream((byte[])objContent);
				System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
				this.txtMessage.Rtf = encoding.GetString(rtf, 0,Convert.ToInt32(ms.Length)); 
			}
			catch(Exception err)
			{
				MessageBox.Show("显示消息错误\n" + err.Message,"");
			}
		}

		private void LoadSystem()
		{
			string sql = "select system_id,name from pub_system where delete_bit=0";
			DataTable table = FrmMdiMain.Database.GetDataTable( sql );
			for ( int i=0;i< table.Rows.Count;i ++ )
			{
				ListViewItem item = new ListViewItem();
				item.Text = table.Rows[i]["name"].ToString().Trim();
				item.Tag = Convert.ToInt32(table.Rows[i]["system_id"]);
				this.lvwSystem.Items.Add(item);
			}
		}

		private string GetSystemList()
		{
			string systemlist="";
			foreach(ListViewItem item in this.lvwSystem.Items )
			{
				if ( item.Checked )
				{
					systemlist += item.Tag.ToString() + ",";
				}
			}
			systemlist = systemlist.Remove(systemlist.Length-1,1);
			return systemlist;
		}

		private Byte[] GetRTF()
		{
			System.IO.MemoryStream ms=new MemoryStream();
			this.txtReleaseContent.SaveFile(ms,RichTextBoxStreamType.RichText);



			int size = Convert.ToInt32(ms.Length);
			Byte[] rtf = new Byte[size]; 
			ms.Position=0;
			ms.Read(rtf, 0, size); 
			ms.Close();
			return rtf;		
		}
		private void SaveMessage()
		{
			try
			{
				string sql = "insert into pub_message(title,content,releasedate,invalidDay,ReciveSystem,Releaseor)";
				sql += "values (@title,@content,@date,@days,@systems,@czy)";
			
				IDbCommand cmd = FrmMdiMain.Database.GetCommand();
				cmd.CommandText = sql;
				IDbDataParameter par = cmd.CreateParameter();
				par.ParameterName = "@title";
				par.Value = this.txtTitle.Text;
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@content";
				par.Value = GetRTF();
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@date";
				par.Value = this.dtpDate.Value;
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@days";
				par.Value = this.txtDay.Text;
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@systems";
				par.Value = GetSystemList();
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@czy";
				par.Value = FrmMdiMain.CurrentUser.EmployeeId;
				cmd.Parameters.Add( par );

				int ret = cmd.ExecuteNonQuery();
				if ( ret == 0 )
				{
					MessageBox.Show("发布失败!");
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void UpdateMessage()
		{
			try
			{
				string sql = "update pub_message set title=@title,content=@content,invalidDay=@days,ReciveSystem=@systems,Releaseor=@czy where msgId=@msgId";
							
				IDbCommand cmd = FrmMdiMain.Database.GetCommand();
				cmd.CommandText = sql;
				IDbDataParameter par = cmd.CreateParameter();
				par.ParameterName = "@title";
				par.Value = this.txtTitle.Text;
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@content";
				par.Value = GetRTF();
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@date";
				par.Value = this.dtpDate.Value;
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@days";
				par.Value = this.txtDay.Text;
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@systems";
				par.Value = GetSystemList();
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@czy";
				par.Value = FrmMdiMain.CurrentUser.EmployeeId;
				cmd.Parameters.Add( par );

				par = cmd.CreateParameter();
				par.ParameterName = "@msgId";
				par.Value = this.msgId;
				cmd.Parameters.Add( par );

				int ret = cmd.ExecuteNonQuery();
				if ( ret == 0 )
				{
					MessageBox.Show("发布失败!");
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void FrmMessage_Load(object sender, System.EventArgs e)
		{
			LoadSystem();
			LoadMessageTitle();
			if ( lvwTitle.Items.Count != 0 )
			{
				lvwTitle.Items[0].Selected = true;
				//LoadMessageContent( Convert.ToInt32(lvwTitle.Items[0].Tag));
			}
		}

		private void btnRelease_Click(object sender, System.EventArgs e)
		{
			if (txtTitle.Text.Trim() == "" )
			{
				MessageBox.Show("标题不能为空");
				return;
			}
			if ( txtReleaseContent.Text.Trim() == "")
			{
				MessageBox.Show("内容不能为空");
				return;
			}
			if ( ! TrasenClasses.GeneralClasses.Convertor.IsInteger( txtDay.Text ))
			{
				MessageBox.Show("有效天数请填写数字");
				return;
			}
			bool checkSys = false;
			foreach(ListViewItem item in this.lvwSystem.Items )
			{
				if ( item.Checked ) 
				{
					checkSys = true;
					break;
				}
			}
			if ( !checkSys )
			{
				MessageBox.Show("请选择要接收消息的系统","");
				return;
			}
			try
			{
				if ( msgId == 0 )
					SaveMessage();
				else
					UpdateMessage();
				this.txtDay.Text  = "";
				this.msgId = 0;
				this.txtReleaseContent.Text ="";
				this.txtTitle.Text = "";
				this.tabControl1.SelectedIndex = 0;
				foreach( ListViewItem item in this.lvwSystem.Items )
					item.Checked = false;
			}
			catch
			{
			}
		}

		private void lvwTitle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( lvwTitle.SelectedItems.Count == 0 ) return;
			LoadMessageContent( Convert.ToInt32( lvwTitle.SelectedItems[0].Tag ));
		}

		private void dtpDate_ValueChanged(object sender, System.EventArgs e)
		{
			LoadMessageTitle();
		}

		private void btnCenter_Click(object sender, System.EventArgs e)
		{
			this.txtReleaseContent.SelectionAlignment = HorizontalAlignment.Center;
		}

		private void btnRight_Click(object sender, System.EventArgs e)
		{
			this.txtReleaseContent.SelectionAlignment = HorizontalAlignment.Right;
		}

		private void btnFont_Click(object sender, System.EventArgs e)
		{
			FontDialog dlg = new FontDialog();
			if (dlg.ShowDialog() == DialogResult.OK )
			{
				this.txtReleaseContent.SelectionFont = dlg.Font;
			}
		}

		private void btnColor_Click(object sender, System.EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			if ( dlg.ShowDialog() == DialogResult.OK )
			{
				this.txtReleaseContent.SelectionColor = dlg.Color;
			}
		}

		private void btnLeft_Click(object sender, System.EventArgs e)
		{
			this.txtReleaseContent.SelectionAlignment = HorizontalAlignment.Left;
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if ( this.lvwTitle.SelectedItems.Count == 0 ) return;
			if ( MessageBox.Show("是否删除该消息?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question )==DialogResult.Yes )
			{
				FrmMdiMain.Database.DoCommand("delete from pub_message where msgid=" + lvwTitle.SelectedItems[0].Tag.ToString());
				lvwTitle.Items.Remove( lvwTitle.SelectedItems[0]);
				this.txtMessage.Text = "";
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( this.tabControl1.SelectedIndex == 0 )
			{
				this.LoadMessageTitle();
				if ( lvwTitle.Items.Count != 0 )
				{
					lvwTitle.Items[0].Selected = true;
				}
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void lvwTitle_DoubleClick(object sender, System.EventArgs e)
		{
			if ( this.lvwTitle.SelectedItems.Count == 0 ) return;
			if ( !FrmMdiMain.CurrentUser.IsAdministrator ) return;
			this.msgId = Convert.ToInt32(lvwTitle.SelectedItems[0].Tag);
			try
			{
				MemoryStream ms=null;
				string sql = "select * from pub_message where msgid=" + msgId;
				DataRow dr = FrmMdiMain.Database.GetDataRow( sql );
				Byte[] rtf=(byte[])dr["content"];
				ms=new MemoryStream((byte[])dr["content"]);
				System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
				this.txtReleaseContent.Rtf = encoding.GetString(rtf, 0,Convert.ToInt32(ms.Length)); 
				this.txtTitle.Text = dr["title"].ToString().Trim();
				this.txtDay.Text = Convert.ToString(dr["invalidday"]);

				string[] sys = dr["recivesystem"].ToString().Trim().Split( ",".ToCharArray() );
				for( int i =0;i<sys.Length;i++)
				{
					foreach(ListViewItem item in this.lvwSystem.Items )
					{
						if ( Convert.ToInt32(sys[i]) == Convert.ToInt32(item.Tag) )
						{
							item.Checked = true;
							break;
						}
					}
				}
				tabControl1.SelectedIndex = 1;
			}
			catch(Exception err)
			{
				MessageBox.Show("显示消息错误\n" + err.Message,"");
			}
		}

		private void txtDay_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar >=48 && (int)e.KeyChar<=57 || (int)e.KeyChar== 8 )
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}

		private void btnSelectAll_Click(object sender, System.EventArgs e)
		{
			foreach(ListViewItem item in this.lvwSystem.Items )
			{
				item.Checked = true;
			}
		}

		private void btnUnSelect_Click(object sender, System.EventArgs e)
		{
			foreach(ListViewItem item in this.lvwSystem.Items )
			{
				item.Checked = item.Checked ? false:true;
			}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			this.txtDay.Text  = "";
			this.msgId = 0;
			this.txtReleaseContent.Text ="";
			this.txtTitle.Text = "";
			foreach( ListViewItem item in this.lvwSystem.Items )
				item.Checked = false;
			this.txtTitle.Focus();
		}
	}
}
