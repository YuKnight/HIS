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

namespace ts_zyhs_qxyjjc
{
    /// <summary>
    /// Form2 的摘要说明。
    /// </summary>
    public class frmQXYJJC : System.Windows.Forms.Form
    {
        //自定义变量
        private BaseFunc myFunc;
        private string qSql = "";
        private bool isSSMZ = false;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button bt刷新;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bt确认;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb未安排;
        private System.Windows.Forms.RadioButton rb取消安排;
        private System.Windows.Forms.RadioButton rb冲正;
        private System.Windows.Forms.RadioButton rb全部;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Splitter splitter1;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmQXYJJC(string _formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            isSSMZ = false;
        }

        //手术麻醉使用
        public frmQXYJJC(string _formText, string sSql)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            qSql = sSql;
            isSSMZ = true;
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb全部 = new System.Windows.Forms.RadioButton();
            this.rb冲正 = new System.Windows.Forms.RadioButton();
            this.rb取消安排 = new System.Windows.Forms.RadioButton();
            this.rb未安排 = new System.Windows.Forms.RadioButton();
            this.bt确认 = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.bt刷新 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 533);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.bt确认);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.bt刷新);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 468);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(752, 65);
            this.panel3.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(752, 10);
            this.progressBar1.TabIndex = 66;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rb全部);
            this.groupBox1.Controls.Add(this.rb冲正);
            this.groupBox1.Controls.Add(this.rb取消安排);
            this.groupBox1.Controls.Add(this.rb未安排);
            this.groupBox1.Location = new System.Drawing.Point(200, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 48);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "状态";
            // 
            // rb全部
            // 
            this.rb全部.Location = new System.Drawing.Point(216, 16);
            this.rb全部.Name = "rb全部";
            this.rb全部.Size = new System.Drawing.Size(48, 24);
            this.rb全部.TabIndex = 3;
            this.rb全部.Text = "全部";
            this.rb全部.Click += new System.EventHandler(this.bt刷新_Click);
            // 
            // rb冲正
            // 
            this.rb冲正.Location = new System.Drawing.Point(160, 16);
            this.rb冲正.Name = "rb冲正";
            this.rb冲正.Size = new System.Drawing.Size(48, 24);
            this.rb冲正.TabIndex = 2;
            this.rb冲正.Text = "冲正";
            this.rb冲正.Click += new System.EventHandler(this.bt刷新_Click);
            // 
            // rb取消安排
            // 
            this.rb取消安排.Location = new System.Drawing.Point(80, 16);
            this.rb取消安排.Name = "rb取消安排";
            this.rb取消安排.Size = new System.Drawing.Size(72, 24);
            this.rb取消安排.TabIndex = 1;
            this.rb取消安排.Text = "取消安排";
            this.rb取消安排.Click += new System.EventHandler(this.bt刷新_Click);
            // 
            // rb未安排
            // 
            this.rb未安排.Checked = true;
            this.rb未安排.Location = new System.Drawing.Point(8, 16);
            this.rb未安排.Name = "rb未安排";
            this.rb未安排.Size = new System.Drawing.Size(64, 24);
            this.rb未安排.TabIndex = 0;
            this.rb未安排.TabStop = true;
            this.rb未安排.Text = "未安排";
            this.rb未安排.Click += new System.EventHandler(this.bt刷新_Click);
            // 
            // bt确认
            // 
            this.bt确认.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt确认.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt确认.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt确认.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.bt确认.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt确认.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt确认.ImageIndex = 0;
            this.bt确认.Location = new System.Drawing.Point(560, 29);
            this.bt确认.Name = "bt确认";
            this.bt确认.Size = new System.Drawing.Size(104, 24);
            this.bt确认.TabIndex = 64;
            this.bt确认.Text = "确认取消(&C)";
            this.bt确认.Click += new System.EventHandler(this.bt确认_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(672, 29);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 63;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // bt刷新
            // 
            this.bt刷新.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt刷新.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt刷新.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt刷新.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.bt刷新.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt刷新.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt刷新.ImageIndex = 0;
            this.bt刷新.Location = new System.Drawing.Point(488, 29);
            this.bt刷新.Name = "bt刷新";
            this.bt刷新.Size = new System.Drawing.Size(64, 24);
            this.bt刷新.TabIndex = 62;
            this.bt刷新.Text = "刷新(&S)";
            this.bt刷新.Click += new System.EventHandler(this.bt刷新_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(480, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(264, 40);
            this.button3.TabIndex = 61;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 468);
            this.panel2.TabIndex = 0;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "取消医技检查";
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(752, 468);
            this.myDataGrid1.TabIndex = 27;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 465);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(752, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // frmQXYJJC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(752, 533);
            this.Controls.Add(this.panel1);
            this.Name = "frmQXYJJC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "取消医技检查";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCancel_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmCancel_Load(object sender, System.EventArgs e)
        {
            string[] GrdMappingName ={"说明","床号","住院号","姓名","申请日期","项目名称","数量","单价","金额","取消日期","取消者",
                                     "xh","applycode","baby_id","applydate","id","hditem_id","order_id","mngtype"};
            int[] GrdWidth ={ 8, 6, 9, 10, 10, 30, 4, 8, 8, 10, 8, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Alignment ={ 0, 1, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);

            this.bt确认.Enabled = false;

            //			this.Show_Date();
        }

        #region Old Show_Date
        /*
		private void Show_Date()
		{
            Cursor.Current=new Cursor(ClassStatic.Static_cur); 
			#region 废代码
			*
			string sSql="with tmp(xh,applydate,cancel_date,cancel_user,applycode,id) as ( "+						
				//申请表没有安排的，没有cancel的
				"    select 1,applydate,cancel_date,cancel_user,applycode,id"+
				"      from yj_applyrecord "+
				"     where isarrange=0 and cancel_bit=0 and applycode is not null "+
				"            and applydept in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"')"+
				"   union all "+
				//已安排，但没有记帐的，安排被取消的
				"    select 2,a.applydate,b.cancel_date,b.cancel_user,a.applycode,b.id"+
				"      from yj_applyrecord a "+
				"             inner join  yj_arrangequeue b on b.applyid=a.id and b.affirm_bit=0 and b.cancel_bit=1 and b.affirm_user=-1"+
				"     where a.isarrange=1 and a.cancel_bit=0 "+
				"            and a.applydept in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"')"+
				"   union all "+
				//已安排已记帐，但被冲正的
				"    select 3,a.applydate,b.cancel_date,b.cancel_user,a.applycode,b.id"+
				"      from yj_applyrecord a "+
				"             inner join  yj_arrangequeue b on b.applyid=a.id and b.affirm_bit=0 and b.cancel_bit=1 and b.affirm_user<>-1 and b.affirm_user<>-2"+
				"     where a.isarrange=1 and a.cancel_bit=0 "+
				"            and a.applydept in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"')"+
				" ) select case a.xh when 0 then '未发送' when 1 then '未安排' when 2 then '取消安排' when 3 then '冲正' end as 说明, "+
				"          c.bed_no 床号,c.inpatient_no 住院号,c.name 姓名,"+
				"          date(a.applydate) 申请日期,"+
				"          d.item_name 项目名称,b.num 数量,b.price 单价 ,b.price*b.num 金额 ,"+
				"          date(a.cancel_date) 取消日期,SeekEmployeeName(a.cancel_user) 取消者, "+
				"          a.xh,a.applycode,b.baby_id,a.applydate,a.id,b.hditem_id,e.order_id,e.mngtype"+
				"     from tmp a inner join zy_prescription b "+
				"                           inner join zy_vinpatient_bed c on b.inpatient_id=c.inpatient_id and b.baby_id=c.baby_id  "+
				"                           inner join jc_vhditemdiction d on b.hditem_id=d.hditem_id "+
				"                           inner join zy_orderrecord e on b.order_id=e.order_id "+ 
				"    				 on a.applycode=b.id       "+
				"      order by a.xh,c.bed_no,b.baby_id,a.applydate";
			*
			#endregion

			int nType=1;

			if(rb未安排.Checked)
				nType=1;
			else if(rb取消安排.Checked)
				nType=2;
			else if(rb冲正.Checked)
				nType=3;
			else
				nType=0;

			string sSql="call hs_selcancelyj('"+InstanceForm.BCurrentDept.WardId+"',"+nType+")";

			myFunc.ShowGrid(0,sSql,this.myDataGrid1);
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;		

			if (myTb.Rows.Count!=0)
			{
				for (int i=myTb.Rows.Count-1;i>=0;i--)
				{
//					myTb.Rows[i]["数量"]=string.Format("{0:F0}",myTb.Rows[i]["数量"].ToString());
//					myTb.Rows[i]["单价"]=string.Format("{0:F2}",myTb.Rows[i]["单价"].ToString());
//					myTb.Rows[i]["金额"]=string.Format("{0:F2}",myTb.Rows[i]["金额"].ToString());
					if (i>0 && myTb.Rows[i]["xh"].ToString()==myTb.Rows[i-1]["xh"].ToString())
					{
						myTb.Rows[i]["说明"]=System.DBNull.Value;
					}
				}
				this.bt确认.Enabled=true;
			}
			else this.bt确认.Enabled=false;
	
			Cursor.Current=Cursors.Default;		
			myFunc.SelRow(this.myDataGrid1);
		}
		*/
        #endregion

        private void Show_Date()
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            int nType = 1;

            if (rb未安排.Checked)
                nType = 1;
            else if (rb取消安排.Checked)
                nType = 2;
            else if (rb冲正.Checked)
                nType = 3;
            else
                nType = 0;

            DataTable patTb = new DataTable();
            DataTable myTb = new DataTable();
            DataTable tmpTb = new DataTable();
            string procName = "";
            string binSql = "";

            if (isSSMZ)
            {
                binSql = qSql;
                procName = "sp_zyhs_selcancelyj_inpatient_ssmz";
            }
            else
            {
                binSql = "select inpatient_id,baby_id from vi_zy_vinpatient_bed where ward_id='" + InstanceForm.BCurrentDept.WardId + "' order by bed_no";
                procName = "sp_zyhs_selcancelyj_inpatient";
            }

            patTb = InstanceForm.BDatabase.GetDataTable(binSql);

            progressBar1.Maximum = patTb.Rows.Count;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;

            //循环病区病人
            for (int i = 0; i < patTb.Rows.Count; i++)
            {
                tmpTb.Clear();

                string sSql = "exec " + procName + " '" + new Guid(patTb.Rows[i]["inpatient_id"].ToString()) + "'," + nType;

                tmpTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (i == 0)
                    myTb = tmpTb.Clone();

                for (int j = 0; j < tmpTb.Rows.Count; j++)
                {
                    myTb.Rows.Add(tmpTb.Rows[j].ItemArray);
                }

                progressBar1.Value += 1;
            }

            if (myTb.Rows.Count != 0)
            {
                for (int i = myTb.Rows.Count - 1; i >= 0; i--)
                {
                    if (i > 0 && myTb.Rows[i]["xh"].ToString() == myTb.Rows[i - 1]["xh"].ToString())
                    {
                        myTb.Rows[i]["说明"] = System.DBNull.Value;
                    }
                }
                this.bt确认.Enabled = true;
            }
            else this.bt确认.Enabled = false;

            myDataGrid1.BeginInit();
            myDataGrid1.DataSource = myTb;
            myDataGrid1.EndInit();
            myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            progressBar1.Value = 0;
            Cursor.Current = Cursors.Default;
            myFunc.SelRow(this.myDataGrid1);
        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }


        private void bt刷新_Click(object sender, System.EventArgs e)
        {
            this.Show_Date();
        }

        private void bt确认_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

            //			if(!myOldTb.Equals(myTb))
            //			{
            //				MessageBox.Show("网格已经更新，请重新确认！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //				return;
            //			}

            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            string sSql = "";

            if (MessageBox.Show(this, "确认该项目不执行了吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
                f1.Close();
            }

            InstanceForm.BDatabase.BeginTransaction();

            try
            {
                string _lisGroup = "-1";
                switch (Convert.ToInt16(myTb.Rows[nrow]["xh"]))
                {
                    case 1: //未安排 安排表cancel 
                        //看看是否有lis组合
                        //sSql="select lis_group from yj_applyrecord "+
                        //    "  where id="+myTb.Rows[nrow]["id"].ToString()+" and isarrange=0";
                        //_lisGroup=InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim();
                        //if(_lisGroup!="-1" && _lisGroup!="")
                        //{
                        //    sSql="update yj_applyrecord set lis_group=-1 where lis_group="+_lisGroup;
                        //    InstanceForm.BDatabase.DoCommand(sSql);
                        //}
                        sSql = "update YJ_ZYSQ " +
                            "    set bscbz=1,scsj=getdate() ,scr=" + InstanceForm.BCurrentUser.EmployeeId +
                            "  where yjsqid='" + myTb.Rows[nrow]["id"].ToString() + "' and bjsbz=0";
                        if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                            throw new Exception("未找到需要更新的记录，请重新确认！");

                        sSql = "update zy_fee_speci " +
                            "    set delete_bit=  " +
                            "  (select 1 from zy_fee_speci a,VI_jc_ITEMS b " +
                            "   where a.hditem_id=b.itemid and a.tcid=b.tcid " +
                            "         and a.hditem_id=" + myTb.Rows[nrow]["hditem_id"].ToString() +
                            "   ) where prescription_id='" + myTb.Rows[nrow]["applycode"].ToString() + "' and charge_bit=0";
                        if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                            throw new Exception("未找到需要更新的记录，请重新确认！");

                        break;
                    case 2: //已安排，未记帐
                        //sSql="update yj_arrangequeue set affirm_user=-2 where id="+myTb.Rows[nrow]["id"].ToString();
                        //if(InstanceForm.BDatabase.DoCommand(sSql)==0)
                        //    throw new Exception("未找到需要更新的记录，请重新确认！");

                        sSql = "update zy_fee_speci " +
                            "    set delete_bit=  " +
                            "  (select 1 from zy_fee_speci a,VI_jc_ITEMS b " +
                            "   where a.hditem_id=b.itemid and a.tcid=b.tcid " +
                            "         and a.hditem_id=" + myTb.Rows[nrow]["hditem_id"].ToString() +
                            "   ) where prescription_id='" + myTb.Rows[nrow]["applycode"].ToString() + "' and charge_bit=0";
                        if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                            throw new Exception("未找到需要更新的记录，请重新确认！");

                        break;
                    case 3: //冲正
                        //sSql="update yj_arrangequeue set affirm_user=-2 where id="+myTb.Rows[nrow]["id"].ToString();
                        //if(InstanceForm.BDatabase.DoCommand(sSql)==0)
                        //    throw new Exception("未找到需要更新的记录，请重新确认！");

                        sSql = "update zy_fee_speci " +
                            "    set charge_bit=1,charge_date=getdate(),charge_user=" + InstanceForm.BCurrentUser.EmployeeId + "  " +
                            " from zy_fee_speci a,VI_jc_ITEMS b " +
                            "   where a.hditem_id=b.itemid and a.tcid=b.tcid " +
                            "         and a.hditem_id=" + myTb.Rows[nrow]["hditem_id"].ToString() +
                            "         and a.cz_flag=2 and a.prescription_id='" + myTb.Rows[nrow]["applycode"].ToString() + "' and a.charge_bit=0";
                        if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                            throw new Exception("未找到需要更新的记录，请重新确认！");

                        break;
                }

                if (Convert.ToInt16(myTb.Rows[nrow]["xh"]) == 1 || Convert.ToInt16(myTb.Rows[nrow]["xh"]) == 2)
                {
                    //如果是临嘱，且不是冲账，均打上未执行标志
                    if (Convert.ToInt16(myTb.Rows[nrow]["mngtype"]) == 1 || Convert.ToInt16(myTb.Rows[nrow]["mngtype"]) == 5)
                    {
                        //Modify by Tany 2005-02-21 order_edate=getdate()
                        sSql = "update zy_orderrecord set wzx_flag=" + InstanceForm.BCurrentUser.EmployeeId + ",order_edate=getdate() where order_id='" + myTb.Rows[nrow]["order_id"].ToString() + "'";
                        if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                            throw new Exception("未找到需要更新的记录，请重新确认！");
                    }

                    //取消检查打印 Add By Tany 2004-12-02
                    sSql = "update zy_jy_print set delete_bit=1 where order_id='" + myTb.Rows[nrow]["order_id"].ToString() + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);//Modify By Tany 2004-12-08
                }

                InstanceForm.BDatabase.CommitTransaction();

                //更新lis条形码表  暂时没有lis连接屏蔽 Modify By Tany 2006-12-04
                //				if(_lisGroup!="-1" && _lisGroup!="")
                //				{
                //					sSql="update ls_as_txm set delete_bit=1 where id="+_lisGroup;
                //					InstanceForm.BDatabase.DoCommand(sSql);
                //				}
            }
            catch (Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                //				database.Close();

                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "取消医技检查错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myDataGrid1.DataSource = null;
                return;
            }

            //			database.Close();

            MessageBox.Show("取消成功！");
            myDataGrid1.DataSource = null;
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
