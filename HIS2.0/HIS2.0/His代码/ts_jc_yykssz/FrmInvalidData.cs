using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace ts_jc_yykssz
{
	/// <summary>
	/// FrmInvalidData 的摘要说明。
	/// </summary>
	public class FrmInvalidData : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnResume;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.ListView lvwDept;
		private System.Windows.Forms.ListView lvwEmployee;
		private System.Windows.Forms.ImageList imageList2;
		private System.ComponentModel.IContainer components;

		public FrmInvalidData()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvalidData));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwDept = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwEmployee = new System.Windows.Forms.ListView();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 344);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwDept);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(600, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "科室";
            // 
            // lvwDept
            // 
            this.lvwDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDept.HideSelection = false;
            this.lvwDept.LargeImageList = this.imageList2;
            this.lvwDept.Location = new System.Drawing.Point(0, 0);
            this.lvwDept.Name = "lvwDept";
            this.lvwDept.Size = new System.Drawing.Size(600, 318);
            this.lvwDept.SmallImageList = this.imageList2;
            this.lvwDept.TabIndex = 0;
            this.lvwDept.UseCompatibleStateImageBehavior = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvwEmployee);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(600, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "人员";
            // 
            // lvwEmployee
            // 
            this.lvwEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwEmployee.HideSelection = false;
            this.lvwEmployee.LargeImageList = this.imageList2;
            this.lvwEmployee.Location = new System.Drawing.Point(0, 0);
            this.lvwEmployee.Name = "lvwEmployee";
            this.lvwEmployee.Size = new System.Drawing.Size(600, 318);
            this.lvwEmployee.SmallImageList = this.imageList2;
            this.lvwEmployee.TabIndex = 0;
            this.lvwEmployee.UseCompatibleStateImageBehavior = false;
            // 
            // btnResume
            // 
            this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResume.Location = new System.Drawing.Point(424, 352);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 1;
            this.btnResume.Text = "恢复";
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(512, 352);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "关闭";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmInvalidData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(608, 382);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmInvalidData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "被置无效的数据";
            this.Load += new System.EventHandler(this.FrmInvalidData_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        /// <summary>
        /// jianqg 2014-6-30 增加，将人事，医务权限分离
        /// </summary>
        private void Init_function_Name()
        {
            string function_Name = InstanceForm._menuTag.Function_Name;
            switch (function_Name)
            {
                case "Fun_ts_jc_yykssz_yw_ry"://医务

                    btnResume.Enabled = false;
                    break;
                case "Fun_ts_jc_yykssz_rs_ksry"://人事
                    break;
            }

        }
		private void LoadInvalidDept()
		{
			string sql = "select dept_id,name from jc_dept_property where deleted=1";
			DataTable table = InstanceForm.BDatabase.GetDataTable(sql);
			for(int i =0;i<table.Rows.Count;i++)
			{
				ListViewItem item = new ListViewItem();
				item.Text = table.Rows[i]["name"].ToString().Trim();
				item.ImageIndex = 1;
				item.Tag = Convert.ToInt32(table.Rows[i]["dept_id"]);
				this.lvwDept.Items.Add(item	);
			}
		}
		private void LoadIvalidEmployee()
		{
			string sql = "select employee_id,name from jc_employee_property where delete_bit=1";
			DataTable table = InstanceForm.BDatabase.GetDataTable(sql);
			for(int i =0;i<table.Rows.Count;i++)
			{
				ListViewItem item = new ListViewItem();
				item.Text = table.Rows[i]["name"].ToString().Trim();
				item.ImageIndex = 0;
				item.Tag = Convert.ToInt32(table.Rows[i]["employee_id"]);
				this.lvwEmployee.Items.Add(item	);
			}
		}

		private void ResumeDept()
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

			if ( this.lvwDept.SelectedItems.Count == 0) return;
			if ( MessageBox.Show("确定要恢复该数据吗？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question ) == DialogResult.Yes)
			{
				DataRow dr = InstanceForm.BDatabase.GetDataRow("select * from jc_dept_property where name='" + lvwDept.SelectedItems[0].Text + "' and deleted=0");
				if ( dr != null )
				{
					if ( MessageBox.Show("已经有相同的名称存在，是否继续操作？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No )
						return;
				}

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    string sql = "update jc_dept_property set deleted=0 where dept_id=" + lvwDept.SelectedItems[0].Tag.ToString();
                    InstanceForm.BDatabase.DoCommand(sql);

                    //三院数据处理
                    string bz = "恢复停用的科室:【" + lvwDept.SelectedItems[0].Text + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_科室修改, bz, "jc_dept_property", "dept_id", lvwDept.SelectedItems[0].Tag.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    throw err;
                }

				lvwDept.Items.Remove( lvwDept.SelectedItems[0]);


                //三院数据处理
                try
                {
                    string errtext = "";
                    ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_科室修改, InstanceForm.BDatabase);
                    if (ty.Bzx == 1)
                    {
                        tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                    }
                    if (errtext != "") throw new Exception(errtext);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("恢复成功 ." + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

			}

		}
		private void ResumeEmployee()
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

			if ( this.lvwEmployee.SelectedItems.Count == 0) return;
			if ( MessageBox.Show("确定要恢复该数据吗？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question ) == DialogResult.Yes)
			{
				DataRow dr = InstanceForm.BDatabase.GetDataRow("select * from jc_employee_property where name='" + lvwEmployee.SelectedItems[0].Text + "' and delete_bit=0");
				if ( dr != null )
				{
					if ( MessageBox.Show("已经有相同的名称存在，是否继续操作？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No )
						return;
				}
                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    string sql = "update jc_employee_property set delete_bit=0 where employee_id=" + lvwEmployee.SelectedItems[0].Tag.ToString();
                    InstanceForm.BDatabase.DoCommand(sql);

                    //三院数据处理
                    string bz = "恢复停用人员:【" + lvwEmployee.SelectedItems[0].Text + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_人员修改, bz, "jc_employee_property", "employee_id", lvwEmployee.SelectedItems[0].Tag.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    throw err;
                }

				lvwEmployee.Items.Remove( lvwEmployee.SelectedItems[0]);


                //三院数据处理
                try
                {
                    string errtext = "";
                    ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_人员修改, InstanceForm.BDatabase);
                    if (ty.Bzx == 1 && log_djid != Guid.Empty)
                    {
                        tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                    }
                    if (errtext != "") throw new Exception(errtext);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FrmInvalidData_Load(object sender, System.EventArgs e)
		{
            Init_function_Name();
			this.LoadInvalidDept();
			this.LoadIvalidEmployee();
            
		}

		private void btnResume_Click(object sender, System.EventArgs e)
		{
			if ( this.tabControl1.SelectedIndex == 0 )
				this.ResumeDept();
			else
				this.ResumeEmployee();
		}
	}
}
