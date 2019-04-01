 using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes.SendMessage
{
	/// <summary>
	/// FrmMessage 的摘要说明。
	/// </summary>
	public class FrmMessage : System.Windows.Forms.Form
	{
		/// <summary>
		/// 消息列表
		/// </summary>
		public DataTable myTb=new DataTable();
		/// <summary>
		/// 操作用户ID
		/// </summary>
		public long YS=0;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 显示消息窗体
		/// </summary>
		public FrmMessage()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 显示消息窗体
		/// </summary>		
		/// <param name="mType">消息的归属类型（0=所有模块 1= 2= 3= 模块ID）</param>
		/// <param name="deptID">消息归属的科室ID</param>
		/// <param name="ysID">操作用户ID</param>
		public FrmMessage(int mType,long deptID,long ysID)
		{
			this.myTb=upForm.selMessage(SendMessageType.消息,mType,deptID);
			this.YS=ysID;
			InitializeComponent();

		}
		/// <summary>
		/// 显示消息窗体
		/// </summary>
		/// <param name="ysID">操作用户ID</param>
		public FrmMessage(long ysID)
		{
			this.myTb=upForm.selMessage(0);
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.Color.Azure;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
			this.listView1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(424, 152);
			this.listView1.TabIndex = 1;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "序号";
			this.columnHeader1.Width = 23;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "主题";
			this.columnHeader2.Width = 345;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "内容";
			this.columnHeader3.Width = 0;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "是否已读";
			this.columnHeader4.Width = 50;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "消息ID";
			this.columnHeader5.Width = 0;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 152);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(424, 4);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.Azure;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.richTextBox1.Location = new System.Drawing.Point(0, 156);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(424, 177);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			// 
			// FrmMessage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(424, 333);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.listView1);
			this.Name = "FrmMessage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "新消息";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmMessage_Closing);
			this.Load += new System.EventHandler(this.FrmMessage_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmMessage_Load(object sender, System.EventArgs e)
		{
			this.listView1.Items.Clear();
			if(myTb.Rows.Count>0)
			{				
				for(int i=0;i<myTb.Rows.Count;i++)
				{
					ListViewItem litem=new ListViewItem();
					litem.Text=Convert.ToDecimal(i+1).ToString();	//序号				
					litem.SubItems.Add(myTb.Rows[i]["主题"].ToString().Trim());//主题
					litem.SubItems.Add(myTb.Rows[i]["内容"].ToString().Trim());//内容
					litem.SubItems.Add(myTb.Rows[i]["状态"].ToString().Trim());//是否已读
                    litem.SubItems.Add(myTb.Rows[i]["ID"].ToString().Trim());//消息ID				 
					this.listView1.Items.Add(litem);
				}
				for(int j=myTb.Rows.Count-1;j>=0;j--)
				{
					if(myTb.Rows[j]["状态"].ToString().Trim()=="未读")
					{
						this.listView1.Items[j].Selected=true;
						this.listView1.Items[j].SubItems[3].Text="已读";
						break;
					}
				}
					
			}

		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count>0)
			{
				this.richTextBox1.Text=this.listView1.SelectedItems[0].SubItems[2].Text.Trim();
				this.listView1.SelectedItems[0].SubItems[3].Text="已读";
			}
		}

		private void FrmMessage_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			for(int i=0;i<this.listView1.Items.Count;i++)
			{
				if(this.listView1.Items[i].SubItems[3].Text.Trim()!=myTb.Rows[i][2].ToString().Trim())
				{
					ChangeFlag(this.listView1.Items[i].SubItems[4].Text.Trim());

				}
			}
		}
		private void ChangeFlag(string ID)
		{
			try
			{
				string sSql="update MZ_MESSAGE set flag=1 ,reader="+YS.ToString()+",read_date=getdate() where ID="+ID+" and flag=0";
				TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sSql);
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"错误提示：",MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			
		}

	

	}
}
