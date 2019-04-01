using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TrasenClasses;
using TrasenFrame.Classes;
using TszyHIS;
using Ts_zyys_public;
using TrasenClasses.GeneralClasses;

namespace Ts_zyys_public
{
    /// <summary>
    /// PatientBar 的摘要说明。
    /// </summary>
    public class PatientBar : System.Windows.Forms.UserControl
    {
        public DateTime Birthday;
        public bool IsLeave = false;//是否是出院病人
        private DbQuery myQuery = new DbQuery();
        private BorderStyle bStyle = BorderStyle.Raised;

        public System.Windows.Forms.Label lblWard;
        public System.Windows.Forms.Label lblDiag;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblYJJ;
        public System.Windows.Forms.Label lblage;
        public System.Windows.Forms.Label lblSex;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblInpatientNo;
        public System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public PatientBar()
        {
            InitializeComponent();
        }

        public PatientBar(Guid patientID)
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();
            GetPatientData(patientID);

            // TODO: 在 InitializeComponent 调用后添加任何初始化

        }

        /// <summary>
        /// 边框样式
        /// </summary>
        public enum BorderStyle
        {
            /// <summary>
            /// 3D风格
            /// </summary>
            Fixed3D,
            /// <summary>
            /// 单边框
            /// </summary>
            FixedSingle,
            /// <summary>
            /// 凸起
            /// </summary>
            Raised,
            /// <summary>
            /// 无
            /// </summary>
            None
        }

        public Guid PatientID
        {
            set
            {
                GetPatientData(value);
            }
        }
        /// <summary>
        /// 是否具有可见的边框
        /// </summary>
        [DefaultValue("Raised"), Description("是否具有可见的边框"), Category("Appearance")]
        public BorderStyle BorderType
        {
            get { return bStyle; }
            set
            {
                bStyle = value;
                Invalidate();
            }
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

        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWard = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDiag = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblYJJ = new System.Windows.Forms.Label();
            this.lblage = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblInpatientNo = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWard
            // 
            this.lblWard.BackColor = System.Drawing.Color.Gainsboro;
            this.lblWard.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblWard.Location = new System.Drawing.Point(44, 38);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(88, 20);
            this.lblWard.TabIndex = 72;
            this.lblWard.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(12, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 71;
            this.label10.Text = "病区";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiag
            // 
            this.lblDiag.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDiag.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDiag.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblDiag.Location = new System.Drawing.Point(180, 38);
            this.lblDiag.Name = "lblDiag";
            this.lblDiag.Size = new System.Drawing.Size(176, 20);
            this.lblDiag.TabIndex = 70;
            this.lblDiag.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTotal.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotal.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTotal.Location = new System.Drawing.Point(600, 38);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(140, 20);
            this.lblTotal.TabIndex = 69;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblYJJ
            // 
            this.lblYJJ.BackColor = System.Drawing.Color.Gainsboro;
            this.lblYJJ.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblYJJ.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblYJJ.Location = new System.Drawing.Point(426, 38);
            this.lblYJJ.Name = "lblYJJ";
            this.lblYJJ.Size = new System.Drawing.Size(104, 20);
            this.lblYJJ.TabIndex = 68;
            this.lblYJJ.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblage
            // 
            this.lblage.BackColor = System.Drawing.Color.Gainsboro;
            this.lblage.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblage.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblage.Location = new System.Drawing.Point(308, 12);
            this.lblage.Name = "lblage";
            this.lblage.Size = new System.Drawing.Size(48, 20);
            this.lblage.TabIndex = 67;
            this.lblage.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblSex
            // 
            this.lblSex.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSex.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblSex.Location = new System.Drawing.Point(180, 12);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(64, 20);
            this.lblSex.TabIndex = 66;
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Gainsboro;
            this.lblName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblName.Location = new System.Drawing.Point(44, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 20);
            this.lblName.TabIndex = 65;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblInpatientNo
            // 
            this.lblInpatientNo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblInpatientNo.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInpatientNo.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblInpatientNo.Location = new System.Drawing.Point(600, 12);
            this.lblInpatientNo.Name = "lblInpatientNo";
            this.lblInpatientNo.Size = new System.Drawing.Size(140, 20);
            this.lblInpatientNo.TabIndex = 64;
            this.lblInpatientNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblBedNo
            // 
            this.lblBedNo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblBedNo.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedNo.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblBedNo.Location = new System.Drawing.Point(426, 12);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(104, 20);
            this.lblBedNo.TabIndex = 63;
            this.lblBedNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(144, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 62;
            this.label8.Text = "诊断";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(548, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 61;
            this.label7.Text = "已消耗";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(374, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 60;
            this.label6.Text = "预交金";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(276, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 59;
            this.label5.Text = "年龄";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(144, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 58;
            this.label4.Text = "性别";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 57;
            this.label3.Text = "姓名";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(548, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 56;
            this.label2.Text = "住院号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(374, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 55;
            this.label1.Text = "床  号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PatientBar
            // 
            this.Controls.Add(this.lblWard);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblDiag);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblYJJ);
            this.Controls.Add(this.lblage);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblInpatientNo);
            this.Controls.Add(this.lblBedNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PatientBar";
            this.Size = new System.Drawing.Size(752, 72);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void GetPatientData(Guid binID)
        {
            Inpatient Inpt = new Inpatient(binID);
            //			FrmYZGL yzgl = new FrmYZGL(binID);
            Patient pt = new Patient(Inpt.PatientID);
            lblName.Text = pt.Name.Trim();
            lblInpatientNo.Text = Inpt.InpatientNo.Trim();
            lblSex.Text = (pt.Sex.ToString() == "1") ? "男" : "女";

            lblage.Text = GetRealAge(pt.Birthday);// Convert.ToString(System.DateTime.Now.Year - pt.Birthday.Year); Modify by jchl 2016-07-29

            lblYJJ.Text = "￥" + Inpt.GetDeposits(true).ToString("0.00");
            lblTotal.Text = "￥" + Inpt.GetFee().ToString("0.00");
            lblDiag.Text = TrasenClasses.GeneralClasses.Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select ryzd from vi_zy_vinpatient_all where inpatient_id='" + Inpt.InpatientID + "' and baby_id=0"), "");//Modify By tany 2011-04-26 TrasenClasses.GeneralClasses.Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select a.name from jc_disease a inner join jc_yblx b on a.ybjklx=b.ybjklx where a.coding='" + Inpt.In_Diagnosis + "' and b.id=" + Inpt.YBLX), "");
            lblWard.Text = TrasenClasses.GeneralClasses.Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select CUR_DEPT_NAME from vi_zy_vinpatient_all where inpatient_id='" + Inpt.InpatientID + "' and baby_id=0"), "");//myQuery.GetDeptName(Inpt.In_dept);//Modify by zouchihua 2012-12-13 改为当前科室
            Birthday = pt.Birthday;
            lblBedNo.Text = Inpt.Bed_NO;
            try
            {
                Refresh();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            if (Inpt.Flag == 2 || Inpt.Flag >= 4)
            {
                //MessageBox.Show("注意，该病人不是在院病人，不允许再进行申请！");modify by jchl
                IsLeave = true;
            }
            if (Inpt.DischargeType == DischargeMode.Insure_DischargeMode)
                lblName.ForeColor = Color.Red;
            else
                lblName.ForeColor = Color.Navy;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            switch (bStyle)
            {
                case BorderStyle.FixedSingle:
                    e.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0, this.Size.Width - 1, this.Size.Height - 1);
                    break;
                case BorderStyle.Fixed3D:
                    e.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace), 0, 0, this.Size.Width - 1, 0);
                    e.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace), 0, 0, 0, this.Size.Height - 1);
                    e.Graphics.DrawLine(new Pen(Color.White), this.Size.Width - 1, 0, this.Size.Width - 1, this.Size.Height - 1);
                    e.Graphics.DrawLine(new Pen(Color.White), 0, this.Size.Height - 1, this.Size.Width - 1, this.Size.Height - 1);
                    break;
                case BorderStyle.Raised:
                    e.Graphics.DrawLine(new Pen(Color.White), 0, 0, this.Size.Width - 1, 0);
                    e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, this.Size.Height - 2);
                    e.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace, 2), this.Size.Width - 1, 0, this.Size.Width - 1, this.Size.Height - 1);
                    e.Graphics.DrawLine(new Pen(SystemColors.AppWorkspace, 2), 1, this.Size.Height - 1, this.Size.Width, this.Size.Height - 1);
                    break;
                case BorderStyle.None:
                    break;
            }
            base.OnPaint(e);
        }

        /// <summary>
        /// Modify by jchl 2016-07-19
        /// </summary>
        /// <returns></returns>
        private string GetRealAge(DateTime birth)
        {

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));


            int dob = int.Parse(birth.ToString("yyyyMMdd"));

            string dif = (now - dob).ToString();

            string age = "0";

            if (dif.Length > 4)
                age = dif.Substring(0, dif.Length - 4);

            return age;
        }

    }
}
