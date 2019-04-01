using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
namespace ts_yp_xtwh
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmaddlyks : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.Button butquit;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.ComboBox cmbyjks;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.ComboBox cmbkstype;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.ComponentModel.IContainer components;

		public Frmaddlyks(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;

            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
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
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmaddlyks));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbkstype = new System.Windows.Forms.ComboBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(405, 454);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(623, 31);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 300;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "双击左边列表的科室添加，然后保存数据";
            this.statusBarPanel2.Width = 1001;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butdel);
            this.groupBox1.Controls.Add(this.butsave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(405, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 83);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(107, 31);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(149, 23);
            this.cmbyjks.TabIndex = 7;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "药剂科室";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(597, 21);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(128, 41);
            this.butquit.TabIndex = 4;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(459, 21);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(128, 41);
            this.butdel.TabIndex = 3;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(320, 21);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(128, 41);
            this.butsave.TabIndex = 3;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 485);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "全院科室";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 21);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(399, 461);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(405, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(7, 371);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbkstype);
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(412, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 371);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "领药科室";
            // 
            // cmbkstype
            // 
            this.cmbkstype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbkstype.Location = new System.Drawing.Point(149, 288);
            this.cmbkstype.Name = "cmbkstype";
            this.cmbkstype.Size = new System.Drawing.Size(171, 23);
            this.cmbkstype.TabIndex = 1;
            this.cmbkstype.Visible = false;
            this.cmbkstype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbkstype_KeyPress);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 21);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(610, 347);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "科室名称";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 300;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "科室类别";
            this.dataGridTextBoxColumn5.Width = 150;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "dyksid";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "code";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = null;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "科室名称";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 150;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "dyksid";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // Frmaddlyks
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(1028, 485);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox3);
            this.KeyPreview = true;
            this.Name = "Frmaddlyks";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmsccj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]


		private void Frmsccj_Load(object sender, System.EventArgs e)
		{
			try
			{
				//初始化
				DataTable myTb=new DataTable();
			
				for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
				{	
					if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
					else
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
				}

				myTb.TableName="Tb";
				this.myDataGrid1.DataSource=myTb;
				this.myDataGrid1.TableStyles[0].MappingName ="Tb";
				this.AddData("");
                Yp.AddcmbYjks(cmbyjks, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
				if (InstanceForm.BCurrentUser.IsAdministrator==false){cmbyjks.SelectedValue=InstanceForm.BCurrentDept.DeptId;cmbyjks.Enabled=false;}
				addlyks(Convert.ToInt32(cmbyjks.SelectedValue));
				addlyksType(cmbkstype);
				
                
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

	
		private void AddData(string ss)
		{
			this.treeView1.Nodes.Clear();
			this.treeView1.ImageList=this.imageList1;
			TreeNode node = treeView1.Nodes.Add("选择科室");
			node.Tag="0";
			node.ImageIndex=0;
			AddTreeViewNode(node);
			//this.treeView1.ExpandAll();

		}


		private void AddTreeViewNode(TreeNode treeNode)
		{
			
			DataTable tb=new DataTable();
			string ssql="";
			ssql="select dept_id,0 rowno, name, py_code, wb_code from jc_dept_property  where p_dept_id="+Convert.ToInt64(Convertor.IsNull(treeNode.Tag,"-10"))+" order by p_dept_id ";
			tb=InstanceForm.BDatabase.GetDataTable(ssql);
			if (tb.Rows.Count==0) treeNode.ImageIndex=1;
			treeNode.Nodes.Clear();
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				TreeNode Cnode = treeNode.Nodes.Add(tb.Rows[i]["name"].ToString());
				Cnode.Tag=tb.Rows[i]["dept_id"];
				Cnode.ImageIndex=0;
				AddTreeViewNode(Cnode);
			}
		}


		private void butdel_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource ;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				if (nrow>tb.Rows.Count-1) return;
				int dyksid=Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["dyksid"],"0"));

                long id = 0;
                string ssql = "select *  from yp_lyks where dyksid=" + dyksid + " and deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + "";
                DataTable tbdel = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbdel.Rows.Count > 0) id = Convert.ToInt64(tbdel.Rows[0]["id"]);

                Guid log_djid = Guid.Empty;

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    ssql = "delete from yp_lyks where dyksid=" + dyksid + " and deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + "";
                    InstanceForm.BDatabase.DoCommand(ssql);


                    //三院数据处理_____保存日志 

                    if (id > 0)
                    {
                        string bz = "删除" + cmbyjks.Text + "的所有往来科室 [" + Convertor.IsNull(tb.Rows[nrow]["科室名称"], "0") + "]";

                        ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                        ts.Save_log(ts_HospData_Share.czlx.yp_药品基础数据单表修改, bz, "yp_lyks", "id", id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("发生错误" + err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                //三院数据处理___执行同步操作 
                string errtext = "";
                ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药品基础数据单表修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1) //只有当立即执行标志为1时才执行
                    tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);


                MessageBox.Show("删除成功"+errtext);

				DataRow row=tb.Rows[nrow];
				tb.Rows.Remove(row);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butsave_Click(object sender, System.EventArgs e)
		{

			try
			{
				this.butsave.Enabled=false;
				InstanceForm.BDatabase.BeginTransaction();

				string ssql="";
				string code="";
				int dyksid=0;
				int deptid=Convert.ToInt32(cmbyjks.SelectedValue);
                 DataTable tb=(DataTable)this.myDataGrid1.DataSource;

				ssql="delete  from yp_lyks where deptid="+deptid+"";
				InstanceForm.BDatabase.DoCommand(ssql);

                string[] ss = new string[tb.Rows.Count+1];

                //三院数据处理_____保存日志 
                string bz = "删除"+cmbyjks.Text +"的所有往来科室 ";
                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                ts.Save_log(ts_HospData_Share.czlx.yp_药品基础数据单表修改, bz, "yp_lyks", "deptid", deptid.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
                ss[0] = log_djid.ToString();

				
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{

					dyksid=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["dyksid"],"0"));
					code=tb.Rows[i]["code"].ToString().Trim();
					if (code.Trim()=="") throw new Exception("请为"+tb.Rows[i]["科室名称"].ToString().Trim()+"选择科室类别");
					ssql="insert into yp_lyks(dyksid,code,deptid) values("+dyksid+",'"+code+"',"+deptid+")";
					InstanceForm.BDatabase.DoCommand(ssql);

                    long id = Convert.ToInt64(InstanceForm.BDatabase.GetDataTable("select @@IDENTITY").Rows[0][0]);

                    //三院数据处理_____保存日志 
                    log_djid = Guid.Empty;
                    bz = "添加" + cmbyjks.Text + "的往来科室 ['"+tb.Rows[i]["科室名称"].ToString().Trim()+"'] ";
                    ts.Save_log(ts_HospData_Share.czlx.yp_药品基础数据单表修改, bz, "yp_lyks", "id", id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
                    ss[i+1] = log_djid.ToString();

				}

				InstanceForm.BDatabase.CommitTransaction();

                //三院数据处理___执行同步操作 
                string msg = "";
                for (int i = 0; i <= ss.Length - 1; i++)
                {
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药品基础数据单表修改, InstanceForm.BDatabase);
                    if (ty.Bzx == 1 && ss[i]!="") //只有当立即执行标志为1时才执行
                    {
                        ts.Pexec_log(new Guid(ss[i]), InstanceForm.BDatabase, out errtext);
                    }
                    msg = msg + errtext;
                }

                MessageBox.Show("保存成功" + msg);
				this.butsave.Enabled=true;
				
			}
			catch(System.Exception err)
			{
				this.butsave.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show("发生错误"+err.Message);
                return;
			}
		}

		private void treeView1_DoubleClick(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			for (int i=0;i<=tb.Rows.Count-1;i++)
			{
				if (this.treeView1.SelectedNode.Tag.ToString().Trim()==tb.Rows[i]["dyksid"].ToString().Trim())
				{
					MessageBox.Show("这个科室已添加了!");
					return;
				}
			}
			if (this.treeView1.SelectedNode.ImageIndex==0) return;
			DataRow row=tb.NewRow();
			row["科室名称"]=this.treeView1.SelectedNode.Text;
			row["dyksid"]=this.treeView1.SelectedNode.Tag.ToString();
			tb.Rows.Add(row);
		}


		private void addlyks(long deptid)
		{
			string ssql="select name 科室名称,(select mc from yp_lykslx where code= b.code) 科室类别, dyksid,b.code  from jc_dept_property a,yp_lyks b  where a.dept_id=b.dyksid and b.deptid="+deptid+" ";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			tb.TableName="Tb";
			this.myDataGrid1.DataSource=tb;
			this.myDataGrid1.TableStyles[0].MappingName="Tb";
		}


		private void cmbyjks_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbyjks.Text.Trim()!="" && cmbyjks.Text.Trim()!="System.Data.DataRowView"  && Convertor.IsNumeric(cmbyjks.Text)==false )
			{
				this.cmbkstype.Visible=false;
				addlyks(Convert.ToInt32(cmbyjks.SelectedValue));
			}
		}


		public static void addlyksType(System.Windows.Forms.ComboBox cmb)
		{
			string ssql="select * from yp_lykslx";
			DataTable tb= InstanceForm.BDatabase.GetDataTable(ssql);
			cmb.DataSource=tb;
			cmb.ValueMember="CODE";
			cmb.DisplayMember ="MC";
		}

		private static string SeekType(string  code)
		{
			string ssql="select mc from yp_lykslx where code='"+code.Trim()+"'";
			return Convert.ToString(InstanceForm.BDatabase.DoCommand(ssql));
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			int ncol=this.myDataGrid1.CurrentCell.ColumnNumber ;
			string columnName=this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].HeaderText.Trim();
			this.cmbkstype.Visible=false;
			if (columnName.Trim()=="科室类别")
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (nrow>tb.Rows.Count-1) return;

				this.cmbkstype.Visible=true;
				this.cmbkstype.Left=this.myDataGrid1.GetCellBounds(nrow,ncol).Left+this.myDataGrid1.Left;
				this.cmbkstype.Top=this.myDataGrid1.GetCellBounds(nrow,ncol).Top+this.myDataGrid1.Top;
				this.cmbkstype.Width=this.myDataGrid1.GetCellBounds(nrow,ncol).Width ;
				
				string code=Convert.ToString(tb.Rows[nrow]["code"]);
				if (code.Trim()!="") cmbkstype.Text=SeekType(code);
				cmbkstype.Focus();
				return;
			}
		}


		private void cmbkstype_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			int ncol=this.myDataGrid1.CurrentCell.ColumnNumber ;
			string columnName=this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].HeaderText.Trim();
			if (columnName.Trim()=="科室类别")
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				tb.Rows[nrow][ncol]=cmbkstype.Text;
				tb.Rows[nrow]["code"]=cmbkstype.SelectedValue;
				this.myDataGrid1.CurrentCell=new DataGridCell(nrow+1,ncol);
				if (nrow==tb.Rows.Count ) this.cmbkstype.Visible=false;
				return;
			}
			this.cmbkstype.Visible=false;
		
		}


	}
}
