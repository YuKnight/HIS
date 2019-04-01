using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes.SendMessage
{
	/// <summary>
	/// FrmInform 的摘要说明。
	/// </summary>
	public class FrmInform : System.Windows.Forms.Form
	{
		/// <summary>
		/// 通知列表
		/// </summary>
		public DataTable dt=new DataTable();
		private long YS=0;
		private string temText="";
		private bool settle=false;//通知显示是否停留一段时间
		private int djs=0;

		private System.Windows.Forms.Button bt_Save;
		private System.Windows.Forms.Button bt_Close;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.Label lb_ddsj;
		private System.Windows.Forms.Timer timer_djs;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 通知窗体
		/// </summary>
		/// <param name="txt"></param>
		public FrmInform(string txt)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			settle=true;
			lb_ddsj.Visible=true;				

			if(txt.Trim()!="")
			{
				this.temText=txt;
				richTextBox1.Text=this.temText;
			}

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		/// <summary>
		/// 通知窗体
		/// </summary>
		/// <param name="mType">通知的归属类型（0=全院，1=，2=，3= (模块ID)）</param>
		/// <param name="deptID">通知归属的科室ID</param>
		/// <param name="ysID">操作用户ID</param>
		public FrmInform(int mType,long deptID,long ysID)
		{
			this.dt=upForm.selMessage(SendMessageType.通知,mType,deptID);
			this.YS=ysID;
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.bt_Save = new System.Windows.Forms.Button();
			this.bt_Close = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.lb_ddsj = new System.Windows.Forms.Label();
			this.timer_djs = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// bt_Save
			// 
			this.bt_Save.BackColor = System.Drawing.Color.Turquoise;
			this.bt_Save.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bt_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bt_Save.ForeColor = System.Drawing.Color.DarkBlue;
			this.bt_Save.Location = new System.Drawing.Point(512, 216);
			this.bt_Save.Name = "bt_Save";
			this.bt_Save.TabIndex = 1;
			this.bt_Save.Text = "另存(&S)";
			this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
			// 
			// bt_Close
			// 
			this.bt_Close.BackColor = System.Drawing.Color.Turquoise;
			this.bt_Close.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bt_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bt_Close.ForeColor = System.Drawing.Color.DarkBlue;
			this.bt_Close.Location = new System.Drawing.Point(608, 216);
			this.bt_Close.Name = "bt_Close";
			this.bt_Close.TabIndex = 2;
			this.bt_Close.Text = "关闭(&C)";
			this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "txt";
			this.saveFileDialog1.FileName = "通知.txt";
			this.saveFileDialog1.Filter = "文本文件(*.txt)|*.txt|RTF格式文件(*.rtf)|*.rtf|所有文件|*.*";
			this.saveFileDialog1.RestoreDirectory = true;
			this.saveFileDialog1.Title = "保存通知";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.dataGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(736, 176);
			this.panel1.TabIndex = 3;
			// 
			// dataGrid1
			// 
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGrid1.CaptionText = "通知";
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dataGrid1.HeaderFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(736, 176);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "发布时间";
			this.dataGridTextBoxColumn1.MappingName = "发布时间";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 120;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "截止时间";
			this.dataGridTextBoxColumn2.MappingName = "结束时间";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 120;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "主题";
			this.dataGridTextBoxColumn3.MappingName = "主题";
			this.dataGridTextBoxColumn3.Width = 500;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 176);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(736, 3);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.LightCyan;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.richTextBox1.Location = new System.Drawing.Point(0, 179);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBox1.Size = new System.Drawing.Size(736, 173);
			this.richTextBox1.TabIndex = 6;
			this.richTextBox1.Text = "";
			// 
			// lb_ddsj
			// 
			this.lb_ddsj.AutoSize = true;
			this.lb_ddsj.BackColor = System.Drawing.Color.LightCyan;
			this.lb_ddsj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lb_ddsj.Location = new System.Drawing.Point(536, 328);
			this.lb_ddsj.Name = "lb_ddsj";
			this.lb_ddsj.Size = new System.Drawing.Size(77, 19);
			this.lb_ddsj.TabIndex = 7;
			this.lb_ddsj.Text = "等待时间：";
			this.lb_ddsj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lb_ddsj.Visible = false;
			// 
			// timer_djs
			// 
			this.timer_djs.Interval = 1000;
			this.timer_djs.Tick += new System.EventHandler(this.timer_djs_Tick);
			// 
			// FrmInform
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(736, 352);
			this.Controls.Add(this.lb_ddsj);
			this.Controls.Add(this.bt_Close);
			this.Controls.Add(this.bt_Save);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmInform";
			this.ShowInTaskbar = false;
			this.Text = "通知";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Resize += new System.EventHandler(this.FrmInform_Resize);
			this.Load += new System.EventHandler(this.FrmInform_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void bt_Close_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void bt_Save_Click(object sender, System.EventArgs e)
		{
			if(this.saveFileDialog1.ShowDialog()==DialogResult.OK)
			{
				string editingFileName = saveFileDialog1.FileName;
				System.IO.FileInfo efInfo = new System.IO.FileInfo(editingFileName);
				string fext = efInfo.Extension.ToUpper();
				if (fext.Equals(".RTF"))
					richTextBox1.SaveFile(editingFileName, RichTextBoxStreamType.RichText);
				else
					richTextBox1.SaveFile(editingFileName, RichTextBoxStreamType.PlainText);				
			}
		}

		private void FrmInform_Resize(object sender, System.EventArgs e)
		{
			this.bt_Save.Top=this.Height-80;
			this.bt_Close.Top=this.Height-80;
			this.lb_ddsj.Top=this.Height-100;
			this.bt_Save.Left=this.Width-200;
			this.bt_Close.Left=this.Width-100;
			this.lb_ddsj.Left=this.Width-125;
		
		}

		private void FrmInform_Load(object sender, System.EventArgs e)
		{
			this.dataGrid1.Focus();
			this.dataGrid1.DataSource=dt;
			if(dt.Rows.Count==0) return;
			DelTextBoxFromDataGrid(this.dataGrid1);
			dataGrid1.CurrentCell=new DataGridCell(dt.Rows.Count-1,0);
			dataGrid1.Select(dt.Rows.Count-1);//选中最后一条记录
			ReadRTF(dt,dt.Rows.Count-1);

			if(settle)
			{
				djs=Convert.ToInt32(dt.Rows[dt.Rows.Count-1]["tlsj"]);
				lb_ddsj.Text="等待时间："+djs.ToString()+" 秒";
				bt_Close.Enabled=false;
				timer_djs.Enabled=true;
			}
		}

		#region 去除 DataGrid中的TextBox
		private void DelTextBoxFromDataGrid(DataGrid myDataGrid)
		{
			for(int n=0;n<myDataGrid.TableStyles[0].GridColumnStyles.Count;n++)
			{
				DataGridTextBoxColumn dgtb=(DataGridTextBoxColumn)myDataGrid.TableStyles[0].GridColumnStyles[n];
				dgtb.TextBox.Parent.Controls.Remove(dgtb.TextBox);
			}
		}
		#endregion

		#region 显示通知(rtf文本)
		private void ReadRTF(DataTable myTb,int nrow)
		{
			MemoryStream buf=null;
			try
			{	
				if(myTb.Rows[nrow]["通知内容"]!=System.DBNull.Value)
				{
					object obj=myTb.Rows[nrow]["通知内容"];
					Byte[] rtf=(byte[])obj;
					buf=new MemoryStream((byte[])obj);
					System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
					richTextBox1.Rtf = encoding.GetString(rtf, 0,Convert.ToInt32(buf.Length)); 
				}
				else richTextBox1.Rtf=null;
			}
			catch(Exception ex) 
			{ 
				MessageBox.Show(ex.Message); 
			} 
			finally
			{ 
				if ( buf != null ) buf.Close(); 
			} 
		}
		#endregion

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			DataTable myTb=(DataTable)dataGrid1.DataSource;
			if(myTb.Rows.Count==0)return;
			int nrow=dataGrid1.CurrentCell.RowNumber;
			if(nrow<myTb.Rows.Count) dataGrid1.Select(nrow);
			ReadRTF(dt,nrow);
		}

		private void timer_djs_Tick(object sender, System.EventArgs e)
		{
			if(djs==0) 
			{
				timer_djs.Enabled=false;
				bt_Close.Enabled=true;
				lb_ddsj.Visible=false;
			}
			else
			{
				djs--;
				lb_ddsj.Text="等待时间："+djs.ToString()+" 秒";
			}
		
		}


	}
}


