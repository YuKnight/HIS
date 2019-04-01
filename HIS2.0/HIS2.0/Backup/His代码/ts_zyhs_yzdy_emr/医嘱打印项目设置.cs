using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_yzdy
{
	/// <summary>
	/// 医嘱打印项目设置 的摘要说明。
	/// </summary>
	public class frmYZDYSZ : System.Windows.Forms.Form
	{
		//自定义变量
		private DataTable dbTb = new DataTable();
		
		private string sqlStr;

		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btUse;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGrid dgPrtcfg;
		private System.Windows.Forms.Button btRefresh;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmYZDYSZ()
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
			this.dgPrtcfg = new System.Windows.Forms.DataGrid();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.btCancel = new System.Windows.Forms.Button();
			this.btUse = new System.Windows.Forms.Button();
			this.btOK = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.btRefresh = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgPrtcfg)).BeginInit();
			this.SuspendLayout();
			// 
			// dgPrtcfg
			// 
			this.dgPrtcfg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgPrtcfg.CaptionVisible = false;
			this.dgPrtcfg.ContextMenu = this.contextMenu1;
			this.dgPrtcfg.DataMember = "";
			this.dgPrtcfg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgPrtcfg.Location = new System.Drawing.Point(8, 8);
			this.dgPrtcfg.Name = "dgPrtcfg";
			this.dgPrtcfg.Size = new System.Drawing.Size(688, 432);
			this.dgPrtcfg.TabIndex = 0;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "删除";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btCancel.ImageIndex = 0;
			this.btCancel.Location = new System.Drawing.Point(616, 464);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(64, 24);
			this.btCancel.TabIndex = 55;
			this.btCancel.Text = "取消(&E)";
			// 
			// btUse
			// 
			this.btUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btUse.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btUse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btUse.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btUse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btUse.ImageIndex = 0;
			this.btUse.Location = new System.Drawing.Point(472, 464);
			this.btUse.Name = "btUse";
			this.btUse.Size = new System.Drawing.Size(64, 24);
			this.btUse.TabIndex = 54;
			this.btUse.Text = "应用(&Y)";
			this.btUse.Click += new System.EventHandler(this.btUse_Click);
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOK.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btOK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btOK.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btOK.ImageIndex = 0;
			this.btOK.Location = new System.Drawing.Point(400, 464);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(64, 24);
			this.btOK.TabIndex = 53;
			this.btOK.Text = "确定(&O)";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button4.Enabled = false;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
			this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button4.ImageIndex = 0;
			this.button4.Location = new System.Drawing.Point(392, 456);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(296, 40);
			this.button4.TabIndex = 56;
			// 
			// btRefresh
			// 
			this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btRefresh.ImageIndex = 0;
			this.btRefresh.Location = new System.Drawing.Point(544, 464);
			this.btRefresh.Name = "btRefresh";
			this.btRefresh.Size = new System.Drawing.Size(64, 24);
			this.btRefresh.TabIndex = 57;
			this.btRefresh.Text = "刷新(&R)";
			this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(16, 464);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 23);
			this.label1.TabIndex = 58;
			this.label1.Text = "请不要随意修改ID和NAME";
			// 
			// frmYZDYSZ
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(704, 509);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btRefresh);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btUse);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.dgPrtcfg);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(712, 536);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(712, 536);
			this.Name = "frmYZDYSZ";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "医嘱打印项目设置";
			this.Load += new System.EventHandler(this.frmOrderPrtCfg_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgPrtcfg)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmOrderPrtCfg_Load(object sender, System.EventArgs e)
		{
			InitGrd();
		}

		private void InitGrd()
		{
			try
			{
				sqlStr = "select * from ZY_ORDERPRTCFG order by id";
				dbTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
				dgPrtcfg.SetDataBinding(dbTb,null);
			}
			catch(Exception err)
			{
				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btRefresh_Click(object sender, System.EventArgs e)
		{
			frmOrderPrtCfg_Load(sender,e);
		}

		private void btUse_Click(object sender, System.EventArgs e)
		{

//			myFunc.myUpdate(sqlStr,dbTb);
			MessageBox.Show("OK!");
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			btUse_Click(sender,e);
			this.Close();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			DataRow myDr = dbTb.Rows[dgPrtcfg.CurrentRowIndex];
			myDr.Delete();
		}
	}
}
