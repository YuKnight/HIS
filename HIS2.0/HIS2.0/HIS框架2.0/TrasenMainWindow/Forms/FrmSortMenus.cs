using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
namespace TrasenMainWindow
{
	/// <summary>
	/// FrmSortMenus 的摘要说明。
	/// </summary>
	public class FrmSortMenus : System.Windows.Forms.Form
	{
		private int parentMenuId = -1;
		private int systemId = 0;
        /// <summary>
        /// 本窗体的数据库连接
        /// </summary>
        private RelationalDatabase db;//Add By Tany 2010-01-30
        /// <summary>
        /// 本窗体连接的机构编码
        /// </summary>
        private int jgbm;//Add By Tany 2010-01-30

		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListView lvwOld;
		private System.Windows.Forms.ListView lvwNew;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FrmSortMenus(int SystemId, int pMenuId, RelationalDatabase _db, int _jgbm)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            db = _db;
            jgbm = _jgbm;
            this.Text += "【" + jgbm + "】";
			this.parentMenuId = pMenuId;
			this.systemId = SystemId;
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

		private void LoadMenu()
		{
			this.lvwOld.Items.Clear();
			string sql = @"select sys_menu_id,name,sort_id 
							from pub_system_menu a 
							left join pub_menu b on a.menu_id=b.menu_id 
							where parent_id=" +this.parentMenuId+ " and system_id=" + this.systemId + " order by a.sort_id";
			DataTable tableMenu = db.GetDataTable(sql);
			for( int i=0;i< tableMenu.Rows.Count; i ++)
			{
				ListViewItem item =new ListViewItem();
				item.Text = tableMenu.Rows[i]["sort_id"].ToString().Trim();
				item.SubItems.Add(tableMenu.Rows[i]["name"].ToString().Trim());
				item.Tag = tableMenu.Rows[i]["sys_menu_id"].ToString().Trim();

                this.lvwOld.Items.Add(item);
			}
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.lvwOld = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lvwNew = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwOld
            // 
            this.lvwOld.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwOld.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwOld.FullRowSelect = true;
            this.lvwOld.Location = new System.Drawing.Point(24, 56);
            this.lvwOld.MultiSelect = false;
            this.lvwOld.Name = "lvwOld";
            this.lvwOld.Size = new System.Drawing.Size(294, 356);
            this.lvwOld.TabIndex = 0;
            this.lvwOld.UseCompatibleStateImageBehavior = false;
            this.lvwOld.View = System.Windows.Forms.View.Details;
            this.lvwOld.ItemActivate += new System.EventHandler(this.lvwOld_ItemActivate);
            this.lvwOld.SelectedIndexChanged += new System.EventHandler(this.lvwOld_SelectedIndexChanged);
            this.lvwOld.DoubleClick += new System.EventHandler(this.lvwOld_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "菜单名称";
            this.columnHeader2.Width = 220;
            // 
            // lvwNew
            // 
            this.lvwNew.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvwNew.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwNew.FullRowSelect = true;
            this.lvwNew.Location = new System.Drawing.Point(388, 56);
            this.lvwNew.MultiSelect = false;
            this.lvwNew.Name = "lvwNew";
            this.lvwNew.Size = new System.Drawing.Size(294, 356);
            this.lvwNew.TabIndex = 1;
            this.lvwNew.UseCompatibleStateImageBehavior = false;
            this.lvwNew.View = System.Windows.Forms.View.Details;
            this.lvwNew.DoubleClick += new System.EventHandler(this.lvwNew_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "序号";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "菜单名称";
            this.columnHeader4.Width = 164;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "原顺序";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(392, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "新顺序";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(474, 436);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(590, 436);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(326, 142);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 34);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = ">>";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemove.Location = new System.Drawing.Point(326, 205);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(54, 34);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "<<";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FrmSortMenus
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(702, 489);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwNew);
            this.Controls.Add(this.lvwOld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSortMenus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单排序";
            this.Load += new System.EventHandler(this.FrmSortMenus_Load);
            this.ResumeLayout(false);

		}
		#endregion


		private void FrmSortMenus_Load(object sender, System.EventArgs e)
		{
			LoadMenu();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if ( lvwOld.SelectedItems.Count == 0 ) return;

            //加入后移除 item_old 2013-2-19 jianqg
            ListViewItem item_old = (ListViewItem)lvwOld.SelectedItems[0];
            lvwOld.Items.Remove(item_old); //移除


            ListViewItem item = (ListViewItem)item_old.Clone();


            foreach (ListViewItem _item in this.lvwNew.Items)
            {
                if (Convert.ToInt64(_item.Tag) == Convert.ToInt64(item.Tag))
                {
                    return;
                }
            }
			item.Text = Convert.ToString(lvwNew.Items.Count+1);
			lvwNew.Items.Add(item);
            
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if ( lvwNew.SelectedItems.Count == 0 ) return;
			ListViewItem item = (ListViewItem)lvwNew.SelectedItems[0].Clone();
			lvwNew.Items.Remove(lvwNew.SelectedItems[0]);
            for (int i = 1; i < lvwNew.Items.Count + 1; i++)
                lvwNew.Items[i - 1].Text = i.ToString();


          

            // 移除后 加入到 item_old 2013-2-19 jianqg
            ListViewItem item_old = (ListViewItem)item.Clone();
            foreach (ListViewItem _item in this.lvwOld.Items)
            {
                if (Convert.ToInt64(_item.Tag) == Convert.ToInt64(item.Tag))
                {
                    return;
                }
            }
            int xh = 0;
            if (lvwOld.Items.Count > 0) xh = int.Parse(lvwOld.Items[lvwOld.Items.Count - 1].Text);
            xh += 1;
            item_old.Text = xh.ToString() ;
            lvwOld.Items.Add(item_old);


			
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if ( lvwNew.Items.Count == 0 ) return;
			try
			{
                //定义多院操作日志 Modify By Tany 2010-01-29
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                Guid log_djid = Guid.Empty;

				db.BeginTransaction();
				foreach(ListViewItem item in this.lvwNew.Items)
				{
					string sql = "update pub_system_menu set sort_id=" + item.Text + " where sys_menu_id=" + item.Tag.ToString();
					db.DoCommand(sql);
				}
                //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                string cznr = "修改系统菜单:【system_id=" + systemId.ToString().Trim() + "】";
                ts.Save_log(ts_HospData_Share.czlx.jc_系统菜单修改, cznr, "pub_system_menu", "system_id", systemId.ToString(), jgbm, -999, "", out log_djid, db);
				db.CommitTransaction();

                try
                {
                    //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_系统菜单修改, db);
                    if (ty.Bzx == 1 && log_djid != Guid.Empty)
                    {
                        //立即执行该操作 Modify By Tany 2010-01-29
                        ts.Pexec_log(log_djid, db, out errtext);
                    }
                    if (errtext != "")
                    {
                        throw new Exception(errtext);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

				this.Close();
			}
			catch(Exception err)
			{
				db.RollbackTransaction();
				MessageBox.Show(err.Message);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void lvwOld_DoubleClick(object sender, System.EventArgs e)
		{
			if ( lvwOld.SelectedItems.Count > 0 )
				btnAdd_Click(null,null);
		}

		private void lvwNew_DoubleClick(object sender, System.EventArgs e)
		{
			if ( lvwNew.SelectedItems.Count > 0 )
				btnRemove_Click(null,null);
		}

        private void lvwOld_ItemActivate(object sender, EventArgs e)
        {
            if ( lvwOld.SelectedItems.Count > 0 )
            {
                if (lvwOld.SelectedItems[0].ForeColor == SystemColors.Control)
                {
                    lvwOld.SelectedItems[0].ForeColor = SystemColors.Control;
                    
                }

            }
        }

        private void lvwOld_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		
	}
}
