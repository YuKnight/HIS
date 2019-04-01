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
using System.Data.SqlClient;
using TszyHIS;

namespace ts_zyhs_dycy
{
    /// <summary>
    /// Form2 的摘要说明。
    /// </summary>
    public class frmDYCY : System.Windows.Forms.Form
    {
        private BaseFunc myFunc;
        private bool _isAll = false;//是否所有病区
        SystemCfg cfg7205 = new SystemCfg(7205);//yaokx2014-06-27
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button bt定义出院;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Button btnWzx;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrint;
        private Button btRePrint;
        private Button btCheckJszt;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmDYCY(string _formText)
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

            _isAll = false;
        }

        public frmDYCY(string _formText, bool isAll)
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

            _isAll = isAll;
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
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCheckJszt = new System.Windows.Forms.Button();
            this.btRePrint = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnWzx = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.bt定义出院 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 512);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1044, 460);
            this.panel3.TabIndex = 2;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "申请出院清单";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(1044, 460);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Tag = "";
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 460);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1044, 4);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btCheckJszt);
            this.panel2.Controls.Add(this.btRePrint);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnWzx);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.bt定义出院);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 464);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 48);
            this.panel2.TabIndex = 0;
            // 
            // btCheckJszt
            // 
            this.btCheckJszt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCheckJszt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCheckJszt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheckJszt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCheckJszt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCheckJszt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCheckJszt.ImageIndex = 0;
            this.btCheckJszt.Location = new System.Drawing.Point(251, 12);
            this.btCheckJszt.Name = "btCheckJszt";
            this.btCheckJszt.Size = new System.Drawing.Size(155, 24);
            this.btCheckJszt.TabIndex = 13;
            this.btCheckJszt.Text = "同步新老系统结算状态";
            this.btCheckJszt.UseVisualStyleBackColor = false;
            this.btCheckJszt.Click += new System.EventHandler(this.btCheckJszt_Click);
            // 
            // btRePrint
            // 
            this.btRePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRePrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btRePrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRePrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRePrint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btRePrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRePrint.ImageIndex = 0;
            this.btRePrint.Location = new System.Drawing.Point(438, 12);
            this.btRePrint.Name = "btRePrint";
            this.btRePrint.Size = new System.Drawing.Size(122, 24);
            this.btRePrint.TabIndex = 12;
            this.btRePrint.Text = "补打出院通知单(&B)";
            this.btRePrint.UseVisualStyleBackColor = false;
            this.btRePrint.Click += new System.EventHandler(this.btRePrint_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.Location = new System.Drawing.Point(567, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 24);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印出院通知单(&P)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(694, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 24);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnWzx
            // 
            this.btnWzx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWzx.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWzx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWzx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWzx.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnWzx.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWzx.ImageIndex = 0;
            this.btnWzx.Location = new System.Drawing.Point(765, 12);
            this.btnWzx.Name = "btnWzx";
            this.btnWzx.Size = new System.Drawing.Size(96, 24);
            this.btnWzx.TabIndex = 9;
            this.btnWzx.Text = "未处理项目(&W)";
            this.btnWzx.UseVisualStyleBackColor = false;
            this.btnWzx.Click += new System.EventHandler(this.btnWzx_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(963, 12);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // bt定义出院
            // 
            this.bt定义出院.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt定义出院.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt定义出院.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt定义出院.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt定义出院.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt定义出院.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt定义出院.ImageIndex = 0;
            this.bt定义出院.Location = new System.Drawing.Point(868, 12);
            this.bt定义出院.Name = "bt定义出院";
            this.bt定义出院.Size = new System.Drawing.Size(88, 24);
            this.bt定义出院.TabIndex = 7;
            this.bt定义出院.Text = "定义出院(&D)";
            this.bt定义出院.UseVisualStyleBackColor = false;
            this.bt定义出院.Click += new System.EventHandler(this.bt定义出院_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(429, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(607, 40);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // frmDYCY
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1044, 512);
            this.Controls.Add(this.panel1);
            this.Name = "frmDYCY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "定义出院";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmDYCY_Activated);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmDYCY_Load(object sender, System.EventArgs e)
        {
            string sSql = "";

            if (_isAll)
            {
                sSql = " select a.ward_id 病区,dbo.fun_getdate(b.in_date) 入院日期,dbo.fun_getdate(b.out_date) 出院日期,convert(char,b.out_date,108) 出院时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别," +
                    "  case b.out_mode when 1 then '治愈' when 2 then '好转' when 3 then '未愈' when 4 then '死亡' when 9 then '其他' else '' end 出院方式, case when c.name IS not null then c.name else (select top 1 NAME from jc_disease t where t.coding=a.out_diagnosis) end as  出院诊断 ,a.inpatient_id,a.baby_id,d.isMYTS" +
                    "  from vi_zy_vinpatient_bed a left join jc_disease c on a.out_diagnosis=c.coding and ( case when isnull(a.ybjklx,0)<=0 then 0 else a.ybjklx end) =c.ybjklx , " +
                    "  (select inpatient_id,0 baby_id,in_date,out_date,out_mode,out_diagnosis from zy_inpatient " +
                    "          where flag=4 " +
                    "          union all " +
                    "         select inpatient_id,baby_id,in_date,out_date,out_mode,out_diagnosis from zy_inpatient_baby " +
                    "          where flag=4 ) b left join ZY_BEDDICTION d on d.inpatient_id=b.inpatient_id  " +
                    "  where a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id order by a.ward_id,b.out_date";
            }
            else
            {
                sSql = " select a.ward_id 病区,dbo.fun_getdate(b.in_date) 入院日期,dbo.fun_getdate(b.out_date) 出院日期,convert(char,b.out_date,108) 出院时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别," +
                    "        case b.out_mode when 1 then '治愈' when 2 then '好转' when 3 then '未愈' when 4 then '死亡' when 9 then '其他' else '' end 出院方式, case when c.name IS not null then c.name else (select top 1 NAME from jc_disease t where t.coding=a.out_diagnosis) end as  出院诊断  ,a.inpatient_id,a.baby_id,d.isMYTS" +
                    "   from vi_zy_vinpatient_bed a left join jc_disease c on a.out_diagnosis=c.coding and ( case when isnull(a.ybjklx,0)<=0 then 0 else a.ybjklx end) =c.ybjklx , " +
                    "   (select inpatient_id,0 baby_id,in_date,out_date,out_mode,out_diagnosis from zy_inpatient " +
                    "          where flag=4 and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                    "          union all " +
                    "         select inpatient_id,baby_id,in_date,out_date,out_mode,out_diagnosis from zy_inpatient_baby " +
                    "          where flag=4 and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')) b left join ZY_BEDDICTION d on d.inpatient_id=b.inpatient_id  " +
                    "  where a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id order by a.ward_id,b.out_date";
            }
            myFunc.ShowGrid(0, sSql, this.myDataGrid1);

            string[] GrdMappingName1 ={ "病区", "入院日期", "出院日期", "出院时间", "床号", "住院号", "姓名", "性别", "出院方式", "出院诊断", "inpatient_id", "baby_id", "isMYTS" };
            int[] GrdWidth1 ={ 8, 10, 10, 8, 8, 9, 12, 4, 8, 24, 0, 0, 0 };
            int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb.Rows.Count != 0)
            {
                this.bt定义出院.Enabled = true;
                this.btnPrint.Enabled = true;
                this.myDataGrid1.Enabled = true;

                myFunc.SelectBin(false, this.myDataGrid1, 7, 8, 0, 0);
            }
            else
            {
                this.bt定义出院.Enabled = false;
                this.btnPrint.Enabled = false;
                this.myDataGrid1.Enabled = false;
            }

            btnPrint.Visible = FrmMdiMain.CurrentUser.IsAdministrator;

            //Add By Tany 2016-04-13
            btCheckJszt.Visible = FrmMdiMain.CurrentUser.IsAdministrator;
        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }

        private void bt定义出院_Click(object sender, System.EventArgs e)
        {

            SystemCfg cfg7130 = new SystemCfg(7130);
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            Guid BinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
            int BabyID = Convert.ToInt32(myTb.Rows[nrow]["baby_id"].ToString().Trim());
            int isMYTS = 0;

            if (myTb.Rows[nrow]["isMYTS"].ToString().Trim() != "")
            {
                isMYTS = Convert.ToInt16(myTb.Rows[nrow]["isMYTS"]);
            }

            //Modify By Tany 2015-03-25 WS接口作了修改，已经不需要此限制
            //if (DateTime.Parse(myTb.Rows[nrow]["出院日期"].ToString().Trim()).Date > DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date)
            //{
            //    MessageBox.Show("对不起，当前日期还未到出院日期，不能操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //判断是否是婴儿先转科
            if (isMYTS != 0 && Convert.ToInt16(BabyID) == 0 && cfg7205.Config == "0")
            {
                MessageBox.Show(this, "对不起，请先将婴儿定义出院！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //判断是否有未停止的医嘱、判断是否有未记帐的费用
            string sMsg = "";
            string sSql = "select sum(id1) as id1,sum(id2) as id2 " +
                " from (select count(a.order_id) id1,0 id2 " +
                "  from zy_orderrecord a " +
                "  where a.status_flag<5 and a.delete_bit=0  " +//and ntype<>0Modify By Tany 20070413 ntype=0的医嘱不用管
                "  and a.inpatient_id='" + BinID + "' and a.baby_id=" + BabyID +
                " union all" +
                " select 0 id1,count(b.id) id2 " +
                "  from zy_fee_speci b " +
                "  where b.charge_bit=0 and b.delete_bit=0 " +
                "  and b.inpatient_id='" + BinID + "' and b.baby_id=" + BabyID + ") b";
            DataTable tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
            if (Convert.ToInt16(tempTb.Rows[0]["id1"]) > 0)
            {
                sMsg = "有未停止的医嘱";
            }
            if (Convert.ToInt32(tempTb.Rows[0]["id2"]) > 0)
            {
                sMsg += sMsg == "" ? "有" : "和";
                sMsg = "未记帐的费用";
            }
            if (cfg7130.Config.Trim() == "0")
            {
                DataTable tb = InstanceForm.BDatabase.GetDataTable("select  * from  zy_fee_speci where  STATITEM_CODE IN ('01','02','03') AND FY_BIT=0 and CHARGE_BIT=1 AND DELETE_BIT=0 AND INPATIENT_ID='" + BinID + "'  AND BABY_ID=" + BabyID + " ");
                if (tb != null && tb.Rows.Count > 0)
                {
                    sMsg += sMsg == "" ? "有" : "和";
                    sMsg = "未发药的费用";
                }
            }
            //add by zouchihua 2013-10-21 有未核对的医嘱控制
            if ((new SystemCfg(7176).Config.Trim()) == "0")
            {
                string sql = " select order_id from ZY_ORDERRECORD b where DELETE_BIT=0  and MNGTYPE in(0,1,5)  and  (isnull(AUDITING_USER1,0)<=0  or  ((status_flag>=3 and  isnull(ORDER_EUSER1,0)<=0 and MNGTYPE=0 )))   and B.INPATIENT_ID='" + BinID + "'  AND B.BABY_ID=" + BabyID + " and b.DEPT_ID not in(select DEPTID from SS_DEPT  )";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                if (tb != null && tb.Rows.Count > 0)
                {
                    sMsg += sMsg == "" ? "有" : "和";
                    sMsg += "有未核对的医嘱";
                }
            }
            if (sMsg != "")
            {
                MessageBox.Show(this, "对不起，该病人" + sMsg + "，不允许定义出院！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnWzx_Click(null, null);
                return;
            }
            else
            {
                //add by yaokx 2014-4-16 有未核对的医嘱提示
                if ((new SystemCfg(7176).Config.Trim()) == "2")
                {
                    string sql = " select order_id from ZY_ORDERRECORD b where DELETE_BIT=0  and MNGTYPE in(0,1,5)  and  (isnull(AUDITING_USER1,0)<=0  or  ((status_flag>=3 and  isnull(ORDER_EUSER1,0)<=0 and MNGTYPE=0 )))   and B.INPATIENT_ID='" + BinID + "'  AND B.BABY_ID=" + BabyID + " and b.DEPT_ID not in(select DEPTID from SS_DEPT  )";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        sMsg += sMsg == "" ? "有" : "和";
                        sMsg += "有未核对的医嘱";
                    }
                }
                if (sMsg != "")
                {
                    if (MessageBox.Show(this, "对不起，该病人" + sMsg + "，不允许定义出院，是否继续定义出院？", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            sSql = "Select 1 from zy_BedDiction where inpatient_id='" + BinID + "' and isbf=1";
            tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
            if (tempTb.Rows.Count > 0)
            {
                MessageBox.Show(this, "对不起，该病人有包床，请取消包床后再定义出院！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Modify By Tany 2011-01-19
            //7084定义出院时是否需要录入电话号码 0=不是 1=是
            if (new SystemCfg(7084).Config == "1")
            {
                sSql = "Select * from vi_zy_vinpatient where inpatient_id='" + BinID + "'";
                tempTb = InstanceForm.BDatabase.GetDataTable(sSql);

                string _tel = Convertor.IsNull(tempTb.Rows[0]["home_tel"], "");
                if (_tel == "")
                {
                    DlgInputBox inputBox = new DlgInputBox("", "请输入病人的家庭电话", "");
                    inputBox.ShowDialog();
                    if (!DlgInputBox.DlgResult)
                    {
                        return;
                    }
                    _tel = DlgInputBox.DlgValue.Trim();
                    if (_tel == "")
                    {
                        MessageBox.Show(this, "对不起，请先录入病人的家庭电话后再定义出院！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    sSql = "update yy_brxx set jtdh='" + _tel + "' where brxxid='" + tempTb.Rows[0]["patient_id"].ToString() + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
            }

            //Modify By tany 2010-04-02 如果有特殊治疗申请没有完成，提示
            sSql = "Select *,dbo.fun_getdeptname(ts_dept) tsdept_name from ZY_TS_APPLY where inpatient_id='" + BinID + "' and status_flag=1 and delete_bit=0";
            tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
            if (tempTb.Rows.Count > 0)
            {
                string ss = "";
                for (int i = 0; i < tempTb.Rows.Count; i++)
                {
                    ss += "申请时间：" + tempTb.Rows[i]["apply_date"].ToString() + "   科室：" + tempTb.Rows[i]["tsdept_name"].ToString() + "   内容：" + tempTb.Rows[i]["content"].ToString() + "\r\n";
                }
                //add by zouchihua 2012-8-2 有特殊治疗未完成是否强制不能出院 0=否 1=是
                SystemCfg cfg7133 = new SystemCfg(7133);
                if (cfg7133.Config.Trim() == "0")
                {
                    if (MessageBox.Show(this, "该病人还有未完成的特殊治疗申请，是否继续进行出院操作？\r\n\r\n" + ss, "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "该病人还有未完成的特殊治疗申请，将不能进行出院操作\r\n\r\n" + ss, "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    return;
                }
            }

            #region  yaokx 2014-06-07 病案首页未录入病人，不能出院
            if (new SystemCfg(7201).Config.Trim() == "1")
            {
                SqlConnection sqlcnn = null;

                try
                {

                    string clientConfigFile = Constant.ApplicationDirectory + "\\PatientConfig\\ClientConfig.ini";
                    string HOSTNAME = Crypto.Instance().Decrypto(TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SQLSERVER", "HOSTNAME", clientConfigFile));//("SQLSERVER3", "NAME", clientConfigFile);
                    string DATASOURCE = Crypto.Instance().Decrypto(TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SQLSERVER", "DATASOURCE", clientConfigFile));//("SQLSERVER3", "NAME", clientConfigFile);
                    string USER_ID = Crypto.Instance().Decrypto(TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SQLSERVER", "USER_ID", clientConfigFile));//("SQLSERVER3", "NAME", clientConfigFile);
                    string PASSWORD = Crypto.Instance().Decrypto(TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SQLSERVER", "PASSWORD", clientConfigFile));//("SQLSERVER3", "NAME", clientConfigFile);
                    if (HOSTNAME == "" || DATASOURCE == "" || USER_ID == "")
                    {
                        System.Windows.Forms.MessageBox.Show("ClientConfig.ini没有设置连接病案首页数据库请配置", "错误");
                        return;
                    }
                    string connectionString = "packet size=4096;user id=" + USER_ID + ";password=" + PASSWORD + ";data source=" + HOSTNAME + ";persist security info=True;initial catalog=" + DATASOURCE + "";
                    sqlcnn = new SqlConnection(connectionString);
                    sqlcnn.Open();
                    SqlCommand sqlcmm = new SqlCommand();
                    sqlcmm.Connection = sqlcnn;
                    sqlcmm.CommandText = "select unique_id from pat_index  where unique_id ='" + BinID + "'";

                    // sqlcmm.Parameters.AddWithValue("@inpatient_id", BinID);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt == null)
                    {
                        MessageBox.Show("病案首页未录入，不能定义出院！");
                        return;
                    }
                    if (dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("病案首页未录入，不能定义出院！");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                finally
                {
                    sqlcnn.Close();
                }

            }

            #endregion

            //判断大人的状态
            if (BabyID == 0)
            {
                sSql = "Select flag,zy_doc from zy_inpatient where inpatient_id='" + BinID + "'";
                tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                int _flag = Convert.ToInt32(tempTb.Rows[0]["flag"]);
                string _doc = Convertor.IsNull(tempTb.Rows[0]["zy_doc"], "-1");
                if (_flag == 3)
                {
                    MessageBox.Show(this, "对不起，该病人还未开出院医嘱！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmDYCY_Load(sender, e);
                    return;
                }
                else if (_flag == 2 || _flag == 5 || _flag == 6)
                {
                    MessageBox.Show(this, "对不起，该病人已经定义出院！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmDYCY_Load(sender, e);
                    return;
                }
                if (Convert.ToInt32(_doc) <= 0)//Modify By Tany 2015-02-02 不能只判断-1，还有0的情况
                {
                    MessageBox.Show(this, "对不起，该病人没有指定住院医生，请指定住院医生后再定义出院！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmDYCY_Load(sender, e);
                    return;
                }
            }

            //增加一段专门验证老系统的数据
            string zyh = myTb.Rows[nrow]["住院号"].ToString();
            try
            {
                //验证老系统手术麻醉是否记账完成后才能出院 Modify By Tany 2015-03-17
                TrasenHIS.BLL.OutHosp.isSSMZChargeFee(zyh, InstanceForm.BDatabase);

                //验证老系统是不是有责任医生 Modify By Tany 2015-04-01
                TrasenHIS.BLL.SyncPatientInfo.SyncDoc(BinID, InstanceForm.BDatabase);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            //验证病人是否有床位费未补
            //try
            //{
            //    sSql = "select  ID,jz_date  from zy_cw_scLog  where finish_bit=0 and delete_bit=0 and inpatient_id='" + BinID + "'";
            //    DataTable bftb = InstanceForm.BDatabase.GetDataTable(sSql);
            //    if (bftb.Rows.Count > 0)
            //    {
            //        string msg = "";
            //        for (int m = 0; m < bftb.Rows.Count;m++ )
            //        {
            //            msg += bftb.Rows[m]["jz_date"].ToString();
            //        }
            //        MessageBox.Show("该病人\n" + msg+"\n床位费未记");
            //        return;
            //    }
            //}
            //catch (Exception err)
            //{
            //    throw err;
            //}



            //验证完了后，再验证接口是不是已经完成了费用传递 Modify By Tany 2015-03-13
            #region 验证床位费用传递
            try
            {
                sSql = "select * from EVENTLOG_FEE where EVENT='n2oFyxx_cw.HIS' and FINISH=0 and BIZID in (select ID from ZY_FEE_SPECI where INPATIENT_ID='" + BinID + "')";
                DataTable fyTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (fyTb != null && fyTb.Rows.Count > 0)
                {
                    MessageBox.Show("该病人在新系统中还有【" + fyTb.Rows.Count + "】条床位费用未传，系统将尝试修复老系统数据！\r\n\r\n点击确定后将继续操作......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TrasenHIS.TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                    ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
                    //ws.Url = "http://192.168.0.23:89/TrasenWS.asmx";
                    string strXML = "";
                    string msg = "";
                    FrmProgressBar frmPB = new FrmProgressBar();
                    try
                    {
                        frmPB.progressBar.Value = 0;
                        frmPB.progressBar.Maximum = fyTb.Rows.Count;
                        frmPB.progressBar.Step = 1;
                        frmPB.Show();
                        for (int i = 0; i < fyTb.Rows.Count; i++)
                        {
                            strXML = ws.GetXml("n2oFyxx_cw.HIS", fyTb.Rows[i]["bizid"].ToString());
                            strXML = ws.ExeWebService("n2oFyxx_cw.HIS", strXML);
                            DataSet dset = TrasenHIS.BLL.HisFunctions.ConvertXmlToDataSet(strXML);
                            if (dset.Tables["HEAD"].Rows.Count > 0)
                            {
                                if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                                {
                                    msg += "调用费用传输时出现错误，BIZID：" + fyTb.Rows[i]["bizid"].ToString() + "\r\n";
                                }
                            }
                            frmPB.progressBar.Value += 1;
                        }
                    }
                    catch (Exception err)
                    {
                        throw err;
                    }
                    finally
                    {
                        frmPB.Close();
                    }

                    if (msg.Trim() == "")
                    {
                        MessageBox.Show("老系统数据修复完成，请重新操作定义出院！");
                    }
                    else
                    {
                        MessageBox.Show(msg);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            #endregion


            #region 验证费用传递
            try
            {
                sSql = "select * from EVENTLOG_FEE where EVENT='n2oFyxx.HIS' and FINISH=0 and BIZID in (select ID from ZY_FEE_SPECI where INPATIENT_ID='" + BinID + "')";
                DataTable fyTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (fyTb != null && fyTb.Rows.Count > 0)
                {
                    MessageBox.Show("该病人在新系统中还有【" + fyTb.Rows.Count + "】条费用未传，系统将尝试修复老系统数据！\r\n\r\n点击确定后将继续操作......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TrasenHIS.TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                    ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
                    //ws.Url = "http://192.168.0.23:89/TrasenWS.asmx";
                    string strXML = "";
                    string msg = "";
                    FrmProgressBar frmPB = new FrmProgressBar();
                    try
                    {
                        frmPB.progressBar.Value = 0;
                        frmPB.progressBar.Maximum = fyTb.Rows.Count;
                        frmPB.progressBar.Step = 1;
                        frmPB.Show();
                        for (int i = 0; i < fyTb.Rows.Count; i++)
                        {
                            strXML = ws.GetXml("n2oFyxx.HIS", fyTb.Rows[i]["bizid"].ToString());
                            strXML = ws.ExeWebService("n2oFyxx.HIS", strXML);
                            DataSet dset = TrasenHIS.BLL.HisFunctions.ConvertXmlToDataSet(strXML);
                            if (dset.Tables["HEAD"].Rows.Count > 0)
                            {
                                if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                                {
                                    msg += "调用费用传输时出现错误，BIZID：" + fyTb.Rows[i]["bizid"].ToString() + "\r\n";
                                }
                            }
                            frmPB.progressBar.Value += 1;
                        }
                    }
                    catch (Exception err)
                    {
                        throw err;
                    }
                    finally
                    {
                        frmPB.Close();
                    }

                    if (msg.Trim() == "")
                    {
                        MessageBox.Show("老系统数据修复完成，请重新操作定义出院！");
                    }
                    else
                    {
                        MessageBox.Show(msg);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            #endregion

            //定义出院
            if (MessageBox.Show(this, "确认“" + myTb.Rows[nrow]["姓名"].ToString().Trim() + "”定义出院吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            string _outmsg = "";
            if (myFunc.isMYTSBaby(isMYTS, Convert.ToInt32(BabyID)))
            {
                //减少母亲的母婴同室数量
                _outmsg = myFunc.ApplyOut("", 2, BinID, BabyID, InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);
            }
            else
            {
                _outmsg = myFunc.ApplyOut("", 1, BinID, BabyID, InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);
            }

            if (_outmsg.Trim() != "")
            {
                MessageBox.Show(_outmsg);
            }

            //Modify By Tany 2015-10-28 老系统出区直接调用
            OldHISCQ(BinID.ToString());

            frmDYCY_Load(sender, e);

            string msg_wardid = FrmMdiMain.CurrentDept.WardId;
            long msg_deptid = 0;
            long msg_empid = 0;
            string msg_sender = FrmMdiMain.CurrentDept.WardName + "：" + FrmMdiMain.CurrentUser.Name;
            string msg_msg = "有出区病人！\r\n住院号：" + myTb.Rows[nrow]["住院号"].ToString().Trim() + "\r\n姓名：" + myTb.Rows[nrow]["姓名"].ToString().Trim();
            try
            {
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.入出院管理, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
            }
            catch { }

            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "定义出院", "将“" + myTb.Rows[nrow]["姓名"].ToString().Trim() + " " + BinID + " " + BabyID + "”定义出院，出院日期：" + myTb.Rows[nrow]["出院日期"].ToString().Trim(), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            //打印出院通知
            myFunc.PrintOutNotice(BinID, BabyID);
        }

        private void btnWzx_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            string sBinID = myTb.Rows[nrow]["inpatient_id"].ToString().Trim();
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();

            object[] _communicates = new object[2];
            _communicates[0] = sBinID;
            _communicates[1] = sBabyID;
            WorkStaticFun.InstanceFormEx("ts_zyhs_wclxmcx", "Fun_ts_zyhs_wclxmcx", "未处理项目查询", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase, ref _communicates);
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            frmDYCY_Load(null, null);
        }

        private void frmDYCY_Activated(object sender, System.EventArgs e)
        {
            frmDYCY_Load(null, null);
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            Guid BinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
            int BabyID = Convert.ToInt32(myTb.Rows[nrow]["baby_id"].ToString().Trim());

            myFunc.PrintOutNotice(BinID, BabyID);
        }

        //Add By Tany 2015-02-11 补打出院通知单
        private void btRePrint_Click(object sender, EventArgs e)
        {
            Guid inpatientId = Guid.Empty;
            int babyId = 0;

            DlgInpatients dlgInpatients = new DlgInpatients();
            if (InstanceForm.BCurrentDept.WardId.Trim() != "")
                dlgInpatients = new DlgInpatients(InstanceForm.BCurrentDept.WardId);
            else
                dlgInpatients = new DlgInpatients();

            dlgInpatients.tabControl1.SelectedTab = dlgInpatients.tpDept;
            dlgInpatients.cmbDept.SelectedIndex = -1;
            dlgInpatients.rbAll.Enabled = true;
            dlgInpatients.rbOutWard.Checked = true;

            dlgInpatients.ShowDialog();

            inpatientId = DlgInpatients.SelectedInpatientID;
            babyId = DlgInpatients.SelectedBabyID;
            if (inpatientId != Guid.Empty)
            {
                try
                {
                    //验证一下病人是否出院病人
                    string sql = "select * from zy_inpatient where inpatient_id='" + inpatientId + "' and flag in (2,5,6)";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        MessageBox.Show("请确认该病人已经出区或出院后才能补打出院通知单！");
                        return;
                    }

                    //验证老系统的出院时间是否和新系统一致，如果不一致，提示是否修改 Modify By Tany 2015-03-11
                    RelationalDatabase oldDB = TrasenHIS.DAL.BaseDal.GetDb_InFormix();
                    sql = "select * from zy_zybrxx where zyh='" + Convert.ToInt64(tb.Rows[0]["inpatient_no"]) + "'";
                    DataTable oldPat = oldDB.GetDataTable(sql);
                    if (oldPat == null || oldPat.Rows.Count == 0)
                    {
                        MessageBox.Show("在老系统数据库中未发现该病人信息！");
                        return;
                    }
                    //Modify By Tany 2015-03-19 老系统cyrq有可能为空值
                    if (Convertor.IsNull(oldPat.Rows[0]["cyrq"], "") != "")
                    {
                        DateTime newOutDate = Convert.ToDateTime(tb.Rows[0]["out_date"]);
                        DateTime oldOutDate = Convert.ToDateTime(oldPat.Rows[0]["cyrq"]);
                        if (newOutDate != oldOutDate)
                        {
                            string msg = "系统检测到老系统的出院时间与新系统的不同，是否需要更新新系统出院时间？\r\n\r\n";
                            msg += "新系统出院时间为：" + newOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                            msg += "老系统出院时间为：" + oldOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n\r\n";
                            msg += "注意：该更新操作只更新病人出院时间，不会更新出院医嘱时间！！！";
                            if (MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                sql = "update zy_inpatient set out_date='" + oldOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "' where inpatient_id='" + inpatientId + "'";
                                InstanceForm.BDatabase.DoCommand(sql);
                            }
                        }
                    }

                    myFunc.PrintOutNotice(inpatientId, babyId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                return;
            }
        }

        //Modify By Tany 2015-10-28
        /// <summary>
        /// 调用WS病人出区
        /// </summary>
        /// <param name="bizid"></param>
        private void OldHISCQ(string bizid)
        {
            try
            {
                TrasenHIS.TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                string strXML = "";

                strXML = ws.GetXml("n2oCq.HIS", bizid);
                strXML = ws.ExeWebService("n2oCq.HIS", strXML);
                DataSet dset = TrasenHIS.BLL.HisFunctions.ConvertXmlToDataSet(strXML);
                if (dset.Tables["HEAD"].Rows.Count > 0)
                {
                    if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                    {
                        throw new Exception("调用病人出区WS时出现错误，BIZID：" + bizid);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add By Tany 2016-04-13
        private void btCheckJszt_Click(object sender, EventArgs e)
        {
            TrasenFrame.Forms.DlgInputBox dlgInput = new TrasenFrame.Forms.DlgInputBox("", "请输入住院号：", "同步病人结算状态");
            dlgInput.NumCtrl = true;
            dlgInput.ShowDialog();
            if (DlgInputBox.DlgResult)
            {
                string zyh = DlgInputBox.DlgValue;
                TrasenHIS.BLL.CheckPatientInfo.CheckPatJszt(zyh, InstanceForm.BDatabase);
            }
        }


    }
}
