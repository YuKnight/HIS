using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace Ts_zyys_yzgl
{
    /// <summary>
    /// 停医嘱时间 的摘要说明。
    /// </summary>
    public class FrmStopGroup : System.Windows.Forms.Form
    {
        public User YS = null;
        public long YS_ID = 0;
        public Guid BinID = Guid.Empty;
        public long BabyID = 0;
        public long GroupID = 0;
        public Guid OrderID = Guid.Empty;
        public bool IsStop = false;
        public string Frequency = "";
        private DbQuery myQuery = new DbQuery();
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radBt1;
        private System.Windows.Forms.RadioButton radBt2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmStopGroup()
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
            this.btnOk = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.radBt1 = new System.Windows.Forms.RadioButton();
            this.radBt2 = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(69, 116);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(64, 25);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown1.Location = new System.Drawing.Point(194, 81);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 24);
            this.numericUpDown1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "末日执行次数";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(189, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "取消(&C)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radBt1
            // 
            this.radBt1.Location = new System.Drawing.Point(130, 52);
            this.radBt1.Name = "radBt1";
            this.radBt1.Size = new System.Drawing.Size(64, 24);
            this.radBt1.TabIndex = 7;
            this.radBt1.Text = "默认值";
            this.radBt1.CheckedChanged += new System.EventHandler(this.radBt1_CheckedChanged);
            // 
            // radBt2
            // 
            this.radBt2.Checked = true;
            this.radBt2.Location = new System.Drawing.Point(130, 81);
            this.radBt2.Name = "radBt2";
            this.radBt2.Size = new System.Drawing.Size(64, 24);
            this.radBt2.TabIndex = 8;
            this.radBt2.TabStop = true;
            this.radBt2.Text = "修改值";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 23);
            this.dateTimePicker1.TabIndex = 32;
            this.dateTimePicker1.Value = new System.DateTime(2004, 6, 25, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 31;
            this.label4.Text = "停 嘱 时 间";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmStopGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(328, 161);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radBt2);
            this.Controls.Add(this.radBt1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(344, 199);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(344, 199);
            this.Name = "FrmStopGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "停医嘱";
            this.Load += new System.EventHandler(this.停医嘱时间_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            int iDays = ((TimeSpan)(dateTimePicker1.Value - DateManager.ServerDateTimeByDBType(InstanceForm._database))).Days;

            if (MessageBox.Show(this, "停止日期与当前日期相差：【" + iDays + "天】\r\r您确认停止医嘱吗?", "停医嘱", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(6023).Config == "0")
            {
                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm._currentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("你没有通过权限确认，不能发送医嘱！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int num = 0;
            if (radBt1.Checked == true) num = -1;
            else num = Convert.ToInt16(this.numericUpDown1.Value);
            if (this.OrderID == Guid.Empty)
            {
                myQuery.StopOrders(YS_ID, this.dateTimePicker1.Value, num, GroupID, OrderID, BinID, BabyID, 0);//停一组
            }
            else
            {
                myQuery.StopOrders(YS_ID, this.dateTimePicker1.Value, num, GroupID, OrderID, BinID, BabyID, 2);//停一条
            }
            IsStop = true;
            MessageBox.Show("停医嘱成功！");

            string binSql = "select * from vi_zy_vinpatient_bed where inpatient_id='" + BinID + "' and baby_id=" + BabyID;
            DataTable binTb = FrmMdiMain.Database.GetDataTable(binSql);
            string msg_wardid = InstanceForm._currentDept.WardId;
            long msg_deptid = 0;
            long msg_empid = 0;
            string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
            string msg_msg = binTb.Rows[0]["bed_no"].ToString().Trim() + " 床 " + binTb.Rows[0]["name"].ToString().Trim() + " 有停医嘱，请处理！";
            TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院护士站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);

            this.Close();
        }

        private void 停医嘱时间_Load(object sender, System.EventArgs e)
        {
            string strcfg = (new SystemCfg(6007)).Config;
            int cfg = Convert.ToInt16(strcfg);
            this.dateTimePicker1.Value = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            this.dateTimePicker1.MaxDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).AddDays(cfg);
            //string longtimes = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToLongTimeString();
            string longtimes = "00:00:00";
            this.dateTimePicker1.MinDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).AddDays(-cfg).ToString("yyyy-MM-dd") + " " + longtimes);

            //获得频率的次数
            //string sql = @"select * from JC_FREQUENCY where NAME='" + Frequency + @"'"; Modify By Tany 2015-05-18 重新根据医嘱表的频率来得到执行次数，避免选择了界面上一组医嘱的第二条，传进来的频率是空值
            string sql = "select b.EXECNUM from ZY_ORDERRECORD a left join JC_FREQUENCY b on upper(a.FREQUENCY)=upper(b.NAME) where a.INPATIENT_ID='" + BinID + "' and a.BABY_ID=" + BabyID + " and a.GROUP_ID=" + GroupID;
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                if (Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["EXECNUM"], "0")) > 0)
                {
                    numericUpDown1.Maximum = int.Parse(tb.Rows[0]["EXECNUM"].ToString());
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            IsStop = false;
            this.Close();
        }

        private void radBt1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radBt1.Checked == true) this.numericUpDown1.Enabled = false;
            else this.numericUpDown1.Enabled = true;
        }
    }
}
