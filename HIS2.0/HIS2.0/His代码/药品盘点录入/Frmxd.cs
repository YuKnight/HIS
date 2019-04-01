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
using TrasenFrame.Forms;
using Ts_zyys_public;
namespace ts_yp_pdlr
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmxd : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelf;
		private System.Windows.Forms.Button butdown;
		private System.Windows.Forms.Button butup;
		private System.Windows.Forms.RadioButton rdomb;
		private System.Windows.Forms.RadioButton rdozy;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.ComboBox cmbmb;
		private System.Windows.Forms.RadioButton rdobegin;
		private System.Windows.Forms.RadioButton rdowhmb;
		private MenuTag _menuTag;
		private string _chineseName;
        private Form _mdiParent;
        private DataGridView dataGridView1;
        private Button butsc;
        private Button butusc;
        private DataGridViewTextBoxColumn 仓库名称;
        private DataGridViewTextBoxColumn 帐存表日期;
        private DataGridViewTextBoxColumn 操作员;
        private DataGridViewTextBoxColumn deptid;
        private DataGridViewButtonColumn 生成帐存表;
        private DataGridViewButtonColumn 取消;
        //public bool bpcgl = false;//进行批次管理
        public YpConfig ypconfig;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmxd(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
            if (_menuTag.Function_Name == "Fun_ts_yp_pdlr_sczcb" || _menuTag.Function_Name=="Fun_ts_yp_pdlr_sczcb_yf")
            {
                rdozy.Visible = false;
                rdozy.Checked = false;
                rdobegin.Enabled = true;
                butup.Enabled = false;
                butdown.Enabled = false;
               
            }
            else
            {
                rdozy.Visible = true;
                rdozy.Enabled = true;
                rdozy.Checked = true;
                dataGridView1.Enabled = false;
                butsc.Visible = false;
                butusc.Visible = false;
            }
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

            ypconfig = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rdomb = new System.Windows.Forms.RadioButton();
            this.rdozy = new System.Windows.Forms.RadioButton();
            this.rdobegin = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.butclose = new System.Windows.Forms.Button();
            this.butdown = new System.Windows.Forms.Button();
            this.panelf = new System.Windows.Forms.Panel();
            this.butusc = new System.Windows.Forms.Button();
            this.butsc = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.仓库名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.帐存表日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生成帐存表 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.取消 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbmb = new System.Windows.Forms.ComboBox();
            this.rdowhmb = new System.Windows.Forms.RadioButton();
            this.butup = new System.Windows.Forms.Button();
            this.panelf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdomb
            // 
            this.rdomb.Location = new System.Drawing.Point(37, 212);
            this.rdomb.Name = "rdomb";
            this.rdomb.Size = new System.Drawing.Size(88, 40);
            this.rdomb.TabIndex = 1;
            this.rdomb.Text = "用模板打开";
            this.rdomb.CheckedChanged += new System.EventHandler(this.rdowhmb_CheckedChanged);
            // 
            // rdozy
            // 
            this.rdozy.Location = new System.Drawing.Point(37, 182);
            this.rdozy.Name = "rdozy";
            this.rdozy.Size = new System.Drawing.Size(159, 40);
            this.rdozy.TabIndex = 2;
            this.rdozy.Text = "手动录入方式";
            this.rdozy.CheckedChanged += new System.EventHandler(this.rdowhmb_CheckedChanged);
            // 
            // rdobegin
            // 
            this.rdobegin.BackColor = System.Drawing.SystemColors.Control;
            this.rdobegin.Checked = true;
            this.rdobegin.Enabled = false;
            this.rdobegin.ForeColor = System.Drawing.Color.Blue;
            this.rdobegin.Location = new System.Drawing.Point(37, -4);
            this.rdobegin.Name = "rdobegin";
            this.rdobegin.Size = new System.Drawing.Size(328, 40);
            this.rdobegin.TabIndex = 3;
            this.rdobegin.TabStop = true;
            this.rdobegin.Text = "生成盘点帐存表（只有生成盘点帐存表才能开始盘点）";
            this.rdobegin.UseVisualStyleBackColor = false;
            this.rdobegin.CheckedChanged += new System.EventHandler(this.rdowhmb_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "请选择盘点录入方式";
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(408, 310);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 6;
            this.butclose.Text = "退出(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butdown
            // 
            this.butdown.Location = new System.Drawing.Point(320, 310);
            this.butdown.Name = "butdown";
            this.butdown.Size = new System.Drawing.Size(88, 24);
            this.butdown.TabIndex = 7;
            this.butdown.Text = "下一步(&E)";
            this.butdown.Click += new System.EventHandler(this.butdown_Click);
            // 
            // panelf
            // 
            this.panelf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelf.Controls.Add(this.butusc);
            this.panelf.Controls.Add(this.butsc);
            this.panelf.Controls.Add(this.dataGridView1);
            this.panelf.Controls.Add(this.cmbmb);
            this.panelf.Controls.Add(this.rdozy);
            this.panelf.Controls.Add(this.rdobegin);
            this.panelf.Controls.Add(this.rdomb);
            this.panelf.Controls.Add(this.rdowhmb);
            this.panelf.Location = new System.Drawing.Point(8, 48);
            this.panelf.Name = "panelf";
            this.panelf.Size = new System.Drawing.Size(541, 256);
            this.panelf.TabIndex = 11;
            // 
            // butusc
            // 
            this.butusc.Location = new System.Drawing.Point(398, 69);
            this.butusc.Name = "butusc";
            this.butusc.Size = new System.Drawing.Size(80, 32);
            this.butusc.TabIndex = 22;
            this.butusc.Text = "取消生成";
            this.butusc.Click += new System.EventHandler(this.butusc_Click);
            // 
            // butsc
            // 
            this.butsc.Location = new System.Drawing.Point(398, 31);
            this.butsc.Name = "butsc";
            this.butsc.Size = new System.Drawing.Size(80, 32);
            this.butsc.TabIndex = 21;
            this.butsc.Text = "开始生成";
            this.butsc.Click += new System.EventHandler(this.butsc_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.仓库名称,
            this.帐存表日期,
            this.操作员,
            this.deptid,
            this.生成帐存表,
            this.取消});
            this.dataGridView1.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView1.Location = new System.Drawing.Point(48, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(344, 119);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // 仓库名称
            // 
            this.仓库名称.DataPropertyName = "仓库名称";
            this.仓库名称.HeaderText = "仓库名称";
            this.仓库名称.Name = "仓库名称";
            this.仓库名称.ReadOnly = true;
            this.仓库名称.Width = 80;
            // 
            // 帐存表日期
            // 
            this.帐存表日期.DataPropertyName = "帐存表日期";
            this.帐存表日期.HeaderText = "帐存表日期";
            this.帐存表日期.Name = "帐存表日期";
            this.帐存表日期.ReadOnly = true;
            this.帐存表日期.Width = 120;
            // 
            // 操作员
            // 
            this.操作员.DataPropertyName = "操作员";
            this.操作员.HeaderText = "操作员";
            this.操作员.Name = "操作员";
            this.操作员.ReadOnly = true;
            this.操作员.Width = 70;
            // 
            // deptid
            // 
            this.deptid.DataPropertyName = "deptid";
            this.deptid.HeaderText = "deptid";
            this.deptid.Name = "deptid";
            this.deptid.ReadOnly = true;
            this.deptid.Visible = false;
            this.deptid.Width = 5;
            // 
            // 生成帐存表
            // 
            this.生成帐存表.DataPropertyName = "生成帐存表";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.生成帐存表.DefaultCellStyle = dataGridViewCellStyle1;
            this.生成帐存表.HeaderText = "生成帐存表";
            this.生成帐存表.Name = "生成帐存表";
            this.生成帐存表.ReadOnly = true;
            this.生成帐存表.Visible = false;
            this.生成帐存表.Width = 90;
            // 
            // 取消
            // 
            this.取消.DataPropertyName = "取消";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.取消.DefaultCellStyle = dataGridViewCellStyle2;
            this.取消.HeaderText = "取消";
            this.取消.Name = "取消";
            this.取消.ReadOnly = true;
            this.取消.Visible = false;
            this.取消.Width = 50;
            // 
            // cmbmb
            // 
            this.cmbmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmb.Location = new System.Drawing.Point(131, 223);
            this.cmbmb.Name = "cmbmb";
            this.cmbmb.Size = new System.Drawing.Size(224, 20);
            this.cmbmb.TabIndex = 17;
            // 
            // rdowhmb
            // 
            this.rdowhmb.Location = new System.Drawing.Point(37, 156);
            this.rdowhmb.Name = "rdowhmb";
            this.rdowhmb.Size = new System.Drawing.Size(80, 40);
            this.rdowhmb.TabIndex = 18;
            this.rdowhmb.Text = "维护模板";
            this.rdowhmb.CheckedChanged += new System.EventHandler(this.rdowhmb_CheckedChanged);
            // 
            // butup
            // 
            this.butup.Location = new System.Drawing.Point(232, 310);
            this.butup.Name = "butup";
            this.butup.Size = new System.Drawing.Size(88, 24);
            this.butup.TabIndex = 13;
            this.butup.Text = "上一步(&E)";
            this.butup.Click += new System.EventHandler(this.butup_Click);
            // 
            // Frmxd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(516, 344);
            this.ControlBox = false;
            this.Controls.Add(this.butup);
            this.Controls.Add(this.butdown);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelf);
            this.Name = "Frmxd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 盘点录入向导";
            this.Load += new System.EventHandler(this.Frmxd_Load);
            this.panelf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private bool BegionPd()
		{
            string ssql = "select name 仓库名称,c.djsj 帐存表日期,dbo.fun_getempname(c.djy) 操作员,b.deptid,'生成帐存表' 生成帐存表,'取消' 取消 " +
            " from jc_dept_property a inner join yp_yjks b on a.dept_id=b.deptid left join yf_pdtemp c on b.deptid=c.deptid and c.SHBZ=0 and c.BDELETE=0 " +
                " where  (b.deptid=" + InstanceForm.BCurrentDept.DeptId + " or b.deptid in(select deptid from yp_yjks_gx where p_deptid=" + InstanceForm.BCurrentDept.DeptId + " )) " +
                " group by a.name,c.djsj,c.djy,b.deptid order by b.deptid";

            DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView1.DataSource = tab;


            if (Convertor.IsNull(tab.Rows[0]["帐存表日期"], "") == "")
                return false;
            else
                return true;
		}

		private void butdown_Click(object sender, System.EventArgs e)
		{

            #region 如是维护模板
            if (this.rdowhmb.Checked == true)
            {
                this.Close();
                Frmmbmx f = new Frmmbmx(_menuTag, _chineseName, _mdiParent);
                Point point = new Point(160, 160);
                f.Location = point;
                f.MdiParent = _mdiParent;
                f.Show();
                return;
            }
            #endregion

            #region 如果是打开模板
            if (this.rdomb.Checked == true)
            {
                if (BegionPd() == false) { MessageBox.Show("请先生成盘点帐存表"); return; }
                if (Convert.ToString(this.cmbmb.Text.Trim()) == "")
                {
                    MessageBox.Show("请选择要打开的模板", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    try
                    {
                        this.Cursor = PubStaticFun.WaitCursor(); ;
                        this.Close();
                        if (ypconfig.盘存方式 == "0")
                        {
                            Frmzylr f = new Frmzylr(_menuTag, _chineseName, _mdiParent);
                            Point point = new Point(160, 75);
                            f.txtbz.Text = "模板:" + cmbmb.Text.Trim();
                            f.Location = point;
                            f.MdiParent = _mdiParent;
                            f.Show();
                            f.AddMB(Convert.ToInt32(Convertor.IsNull(this.cmbmb.SelectedValue, "0")));
                        }
                        else
                        {
                            Frmzylr_kcmx f = new Frmzylr_kcmx(_menuTag, _chineseName, _mdiParent);
                            Point point = new Point(160, 75);
                            f.txtbz.Text = "模板:" + cmbmb.Text.Trim();
                            f.Location = point;
                            f.MdiParent = _mdiParent;
                            f.Show();
                            f.AddMB(Convert.ToInt32(Convertor.IsNull(this.cmbmb.SelectedValue, "0")));
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Arrow;
                    }

                }

            }
            #endregion

            #region 手动录入
            if (this.rdozy.Checked == true && this.panelf.Visible == true)
            {
                if (BegionPd() == false) { MessageBox.Show("请先生成盘点帐存表"); return; }
                this.Close();
                if (ypconfig.盘存方式 == "0")
                {
                    Frmzylr f = new Frmzylr(_menuTag, _chineseName, _mdiParent);
                    Point point = new Point(160, 75);
                    f.Location = point;
                    f.MdiParent = _mdiParent;
                    f.Show();
                }
                else
                {
                    Frmzylr_kcmx f = new Frmzylr_kcmx(_menuTag, _chineseName, _mdiParent);
                    Point point = new Point(160, 75);
                    f.Location = point;
                    f.MdiParent = _mdiParent;
                    f.Show();
                }

                return;
            }
            #endregion

		}

		private void butup_Click(object sender, System.EventArgs e)
		{
			this.panelf.Visible=true;
		}

		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Frmxd_Load(object sender, System.EventArgs e)
		{
            cmbmb.Enabled = false;
			//添加模板
            YP_PDMB.AddCmbMb(InstanceForm.BCurrentDept.DeptId, cmbmb, InstanceForm.BDatabase);
			

			//判断是否已开始盘存
            if (BegionPd() == true)
            {
                //this.rdobegin.Enabled = false;
                //this.cmbmb.Enabled = true;
                //this.rdomb.Enabled = true;
                //this.rdomb.Checked = true;
                //this.rdozy.Enabled = true;
                //this.chkdel.Visible=true;
            }
            //else
            //{
                //this.rdobegin.Enabled=true;
                //this.rdobegin.Checked=true;
                //this.cmbmb.Enabled=false;
                //this.rdomb.Enabled=false;
                //this.rdozy.Enabled=false;
                //this.rdozy.Enabled = true;
				//this.chkdel.Visible=false;
			//}


            if (_menuTag.Function_Name == "Fun_ts_yp_pdlr_sczcb_yf" && YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == true)
            {
                butsc.Enabled = false;
                butusc.Enabled = false;
                butdown.Enabled = false;
            }

            if (_menuTag.Function_Name == "Fun_ts_yp_pdlr_sczcb" && YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == false)
            {
                butsc.Enabled = false;
                butusc.Enabled = false;
                butdown.Enabled = false;
            }
            int deptid = InstanceForm.BCurrentDept.DeptId;



		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void rdowhmb_CheckedChanged(object sender, EventArgs e)
        {
            butdown.Enabled = false;
            if (rdobegin.Checked == true && (_menuTag.Function_Name == "Fun_ts_yp_pdlr_sczcb" || _menuTag.Function_Name == "Fun_ts_yp_pdlr_sczcb_yf"))
            {
                butup.Enabled = false;
                butdown.Enabled = false;
                butsc.Enabled = true;
                butsc.Enabled = true;
            }
            if (rdobegin.Checked == false && (_menuTag.Function_Name != "Fun_ts_yp_pdlr_sczcb" && _menuTag.Function_Name != "Fun_ts_yp_pdlr_sczcb_yf"))
            {

                butup.Enabled = true;
                butdown.Enabled = true;
                butsc.Enabled = false;
                butsc.Enabled = false;
            }

            cmbmb.Enabled = rdomb.Checked == true ? true : false;
            if (rdowhmb.Checked == true) butdown.Enabled = true;
        }

        private void butsc_Click(object sender, EventArgs e)
        {
            //当前科室名称
            string deptname = InstanceForm.BCurrentDept.DeptName.Trim();
            //日期
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            #region 权限确认
            try
            {

                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("你没有通过权限确认！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor = Cursors.Default;
                    return;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            string sql = string.Format(@"  select ID,b.YWMC from YK_DJ_TEMP a left join YK_YWLX b on a.YWLX = b.YWLX  where a.SHBZ !=1 and a.DEPTID ={0}
            union select ID,b.YWMC from YK_DJ a left join YK_YWLX b on a.YWLX = b.YWLX  where a.SHBZ !=1 and a.DEPTID ={0}", InstanceForm.BCurrentDept.DeptId);
            DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string ywmc = string.Empty;
                foreach (DataRow tmpRow in dt.Rows)
                {
                    if (!ywmc.Contains(tmpRow[1].ToString().Trim()))
                        ywmc += tmpRow[1].ToString().Trim() + ",";
                }
                ywmc = ywmc.Remove(ywmc.Length - 1, 1);
                ywmc = ywmc[ywmc.Length - 1].ToString().Trim() == "单" ? ywmc : ywmc + "单据";
                MessageBox.Show(string.Format("存在未审核的{0},请处理!", ywmc));
                return;
            }

            sql = string.Format(@"select a.ID,B.YWMC from YF_DJ a left join Yf_YWLX b on a.YWLX = b.YWLX where (a.YWLX = '016' or a.YWLX = '015') and a.SHBZ !=1 and a.DEPTID ={0} ", InstanceForm.BCurrentDept.DeptId);
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string ywmc = string.Empty;
                foreach (DataRow tmpRow in dt.Rows)
                {
                    if (!ywmc.Contains(tmpRow[1].ToString().Trim()))
                        ywmc += tmpRow[1].ToString().Trim() + ",";
                }
                ywmc = ywmc.Remove(ywmc.Length - 1, 1);
                ywmc = ywmc[ywmc.Length - 1].ToString().Trim() == "单" ? ywmc : ywmc + "单据";
                MessageBox.Show(string.Format("存在未审核的{0},请处理!", ywmc));
                return;
            }

            if (_menuTag.Function_Name == "Fun_ts_yp_pdlr_sczcb_yf")
            {
                #region 上传发药明细表的数据
                string stext = this.Text.Trim();
                //上传发药明细表的数据
                this.Cursor = Cursors.WaitCursor;
                this.Text = "正在上传处方发药明细.....";

                try
                {
                    this.Cursor = PubStaticFun.WaitCursor();
                    int err_code = -1;
                    string err_text = "";

                    InstanceForm.BDatabase.BeginTransaction();

                    ParameterEx[] parameters = new ParameterEx[8];
                    parameters[0].Text = "@djrq";
                    parameters[0].Value = Convert.ToDateTime(sDate).ToShortDateString();

                    parameters[1].Text = "@djsj";
                    parameters[1].Value = Convert.ToDateTime(sDate).ToLongTimeString();

                    parameters[2].Text = "@djy";
                    parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[3].Text = "@deptid";
                    parameters[3].Value = InstanceForm.BCurrentDept.DeptId;

                    parameters[4].Text = "@endrq";
                    parameters[4].Value = Convert.ToDateTime(sDate).ToShortDateString();

                    parameters[5].Text = "@err_code";
                    parameters[5].ParaDirection = ParameterDirection.Output;
                    parameters[5].DataType = System.Data.DbType.Int32;
                    parameters[5].ParaSize = 100;

                    parameters[6].Text = "@err_text";
                    parameters[6].ParaDirection = ParameterDirection.Output;
                    parameters[6].ParaSize = 100;

                    parameters[7].Text = "@jgbm";
                    parameters[7].Value = InstanceForm._menuTag.Jgbm;


                    InstanceForm.BDatabase.DoCommand("SP_YF_fymx_dj", parameters, 30);
                    err_code = Convert.ToInt32(parameters[5].Value);
                    err_text = Convert.ToString(parameters[6].Value);

                    //更新处方上传日期
                    string rq = sDate;
                    string ssql = "update yp_yjks set cfscrq='" + rq + "' where deptid=" + InstanceForm.BCurrentDept.DeptId + "";
                    InstanceForm.BDatabase.DoCommand(ssql);


                    InstanceForm.BDatabase.CommitTransaction();

                    this.Text = "上传处方记录成功";


                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("在上传发药明细时发生错误" + err.Message);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
                #endregion

            }
            #region 系统对账


            //系统对账
            this.Text = "正在进行系统对账.....";
            try
            {

                this.Cursor = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "@jsrq";
                parameters[1].Text = "@deptid";
                parameters[0].Value = sDate; //该参数暂时无用
                parameters[1].Value = InstanceForm.BCurrentDept.DeptId; 
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_XTDZ", parameters, 60);
                tb.TableName = "myTb";

                DataRow[] row = tb.Select("数量差值<> 0");
                if (row.Length != 0)
                    throw new Exception("系统检测到帐务数据不平，请到 [系统对帐] 菜单重新进行系统对帐后再进行当前操作");

            }
            catch (System.Exception err)
            {
                MessageBox.Show("出错" + err.Message);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

            #endregion

            #region 生成帐存表

            if (MessageBox.Show("您确定要生成 [" + deptname + "] 盘点帐存表吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            try
            {
                this.Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();

                DataTable tb=(DataTable)dataGridView1.DataSource;

                sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                //插入当前帐面数量到盘点临时表
                InstanceForm.BDatabase.BeginTransaction();

                for (int xxx = 0; xxx <= tb.Rows.Count - 1; xxx++)
                {
                    //仓库id
                    int deptid = Convert.ToInt32(tb.Rows[xxx]["deptid"]);
                    string tablename = "";
                    string tbName_kcmx = "";

                    if (YpConfig.是否药库(deptid, InstanceForm.BDatabase) == true)
                    {
                        tablename = "yk_kcph";
                        tbName_kcmx = "yk_kcmx";
                    }
                    else
                    {
                        tablename = "yf_kcph";
                        tbName_kcmx = "yf_kcmx";
                    }

                    string ssql = "select kcid ncount,djsj from yf_pdtemp where deptid=" + deptid + " and shbz=0  and bdelete=0 ";
                    DataTable tbtemp = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbtemp.Rows.Count > 0) throw new Exception("[" + deptname + "] 帐存数据已生成，不能再次生成！");

                    ssql = "insert into yf_pdtemp(id,kcid,jgbm,ggid,cjid,KWID,jhj,ypph,kcl,zxdw,dwbl,djsj,djy,bdelete,deptid,ypxq,yppch)" +
                        "select dbo.FUN_GETGUID(newid(),getdate()),id,jgbm,ggid,cjid,KWID,jhj,ypph,kcl,zxdw,dwbl,'" + sDate + "'," + InstanceForm.BCurrentUser.EmployeeId + ", bdelete,deptid,ypxq,yppch from " + tablename + " where deptid=" + deptid + "";
                    InstanceForm.BDatabase.DoCommand(ssql);
                }

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("盘点帐存表生成成功,接下来您可以进行盘存单的录入操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool b = BegionPd();
                return;
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
            #endregion
        }

        private void butusc_Click(object sender, EventArgs e)
        {

            #region 权限确认
            try
            {

                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("你没有通过权限确认！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor = Cursors.Default;
                    return;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 如果是删除盘点帐存表
                try
                {
                    if (MessageBox.Show("删除 [" + InstanceForm.BCurrentDept.DeptName + "] 盘点帐存表的操作不可恢复，您确定要这样做吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }

                    DataTable tab = (DataTable)dataGridView1.DataSource;

                    InstanceForm.BDatabase.BeginTransaction();

                    for (int xxx = 0; xxx <= tab.Rows.Count - 1; xxx++)
                    {

                        //仓库id
                        int deptid = Convert.ToInt32(tab.Rows[xxx]["deptid"]);

                        string ssql = "select * from yf_pdcs where bdelete=0 and shbz=0 and deptid=" + deptid + "";
                        DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tb.Rows.Count != 0)
                        {
                            throw new Exception("盘点录入操作已经开始了,您现在不能取消帐存表数据");
                        }
                        ssql = "delete yf_pdtemp where shbz=0 and deptid=" + deptid + "";
                        int iii = InstanceForm.BDatabase.DoCommand(ssql);
                        //if (iii == 0) throw new Exception("没有可删除的帐存数据,可能还没有生成");

                        string str_old = "删除盘点帐存表";
                        SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "删除盘点帐存表", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                        systemLog.Save();
                        systemLog = null;
                    }

                    InstanceForm.BDatabase.CommitTransaction();

                    MessageBox.Show("删除成功");
                    bool b = BegionPd();
                    return;
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            #endregion

        }
    }

}
