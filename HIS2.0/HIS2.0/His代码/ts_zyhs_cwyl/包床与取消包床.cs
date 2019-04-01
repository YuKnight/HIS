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

namespace ts_zyhs_cwyl
{
    /// <summary>
    /// Form2 的摘要说明。
    /// </summary>
    public class frmBC : System.Windows.Forms.Form
    {
        private BaseFunc myFunc;
        private bool isBC = true;   //true 包床 false 取消包床
        private Guid old_bed_id = Guid.Empty;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private RadioButton rbDqfj;
        private RadioButton rbSyfj;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmBC(bool _isBC)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            myFunc = new BaseFunc();
            isBC = _isBC;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rbDqfj = new System.Windows.Forms.RadioButton();
            this.rbSyfj = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 8);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // btExit
            // 
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(128, 90);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(64, 24);
            this.btExit.TabIndex = 12;
            this.btExit.Text = "退出(&E)";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(32, 90);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(64, 24);
            this.btOK.TabIndex = 11;
            this.btOK.Text = "确认(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "选择床号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(80, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 20);
            this.comboBox1.TabIndex = 14;
            // 
            // rbDqfj
            // 
            this.rbDqfj.AutoSize = true;
            this.rbDqfj.Location = new System.Drawing.Point(21, 12);
            this.rbDqfj.Name = "rbDqfj";
            this.rbDqfj.Size = new System.Drawing.Size(71, 16);
            this.rbDqfj.TabIndex = 15;
            this.rbDqfj.Text = "当前房间";
            this.rbDqfj.UseVisualStyleBackColor = true;
            this.rbDqfj.CheckedChanged += new System.EventHandler(this.frmBC_Load);
            // 
            // rbSyfj
            // 
            this.rbSyfj.AutoSize = true;
            this.rbSyfj.Checked = true;
            this.rbSyfj.Location = new System.Drawing.Point(105, 12);
            this.rbSyfj.Name = "rbSyfj";
            this.rbSyfj.Size = new System.Drawing.Size(71, 16);
            this.rbSyfj.TabIndex = 16;
            this.rbSyfj.TabStop = true;
            this.rbSyfj.Text = "所有房间";
            this.rbSyfj.UseVisualStyleBackColor = true;
            // 
            // frmBC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(240, 119);
            this.Controls.Add(this.rbSyfj);
            this.Controls.Add(this.rbDqfj);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(248, 146);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(248, 146);
            this.Name = "frmBC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "包床";
            this.Load += new System.EventHandler(this.frmBC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmBC_Load(object sender, System.EventArgs e)
        {
            string sSql = "";
            int i = 0;
            //Modify by Tany 2005-02-24
            //增加停用标志
            sSql = @"select bed_id,ISBF,ROOM_NO from zy_BedDiction " +
                " where isinuse=0 and ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                "   and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
            DataTable tempTab1 = InstanceForm.BDatabase.GetDataTable(sSql);

            if (tempTab1 == null || tempTab1.Rows.Count < 1)
            {
                MessageBox.Show(this, "对不起，没有找到该病人的床位信息，请重新选择！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.old_bed_id = new Guid(tempTab1.Rows[0]["bed_id"].ToString());

            if (this.isBC)
            {
                rbDqfj.Visible = true;
                rbSyfj.Visible = true;

                this.Text = "包床";
                sSql = "select bed_no,bed_id from zy_beddiction" +
                     " where isinuse=0 and ward_id='" + InstanceForm.BCurrentDept.WardId + "' ";
                if (rbDqfj.Checked)
                {
                    sSql += " and room_no='" + tempTab1.Rows[0]["ROOM_NO"].ToString() + "' ";
                }
                sSql += " and inpatient_id is null and isbf=0 order by bed_no";
                DataTable tempTab2 = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tempTab2.Rows.Count < 1)
                {
                    MessageBox.Show(this, "对不起，该房间没有空床！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                else
                {
                    this.comboBox1.Items.Clear();
                    for (i = 0; i <= tempTab2.Rows.Count - 1; i++)
                    {
                        this.comboBox1.Items.Add(tempTab2.Rows[i]["bed_no"].ToString());
                    }
                    this.comboBox1.Text = tempTab2.Rows[0]["bed_no"].ToString();
                }
            }
            else
            {
                rbDqfj.Visible = false;
                rbSyfj.Visible = false;

                this.Text = "取消包床";
                sSql = "select bed_no,bed_id from zy_beddiction" +
                    " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                    "       and bf_id='" + tempTab1.Rows[0]["bed_id"].ToString() + "'" +
                    " and inpatient_id is null order by bed_no";
                DataTable tempTab3 = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tempTab3.Rows.Count < 1)
                {
                    MessageBox.Show(this, "对不起，该病人没有包床！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                else
                {
                    this.comboBox1.Items.Clear();
                    for (i = 0; i <= tempTab3.Rows.Count - 1; i++)
                    {
                        this.comboBox1.Items.Add(tempTab3.Rows[i]["bed_no"].ToString());
                    }
                    this.comboBox1.Text = tempTab3.Rows[0]["bed_no"].ToString();
                }
            }
        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            string sSql = "";
            int i = 0;
            string _outmsg = "";
            sSql = @"select bed_id from zy_BedDiction " +
                " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                "   and rtrim(bed_no)='" + this.comboBox1.Text.Trim() + "'";
            DataTable tempTab1 = InstanceForm.BDatabase.GetDataTable(sSql);
            if (tempTab1.Rows.Count < 1) return;

            string OperType = "";
            string OperContens = "";

            if (isBC)
            {
                //床位有效性判断
                //Add By Tany 2005-02-24
                string isInuse = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select isinuse from zy_beddiction where bed_id='" + tempTab1.Rows[0]["bed_id"].ToString() + "'"), "");
                if (isInuse == "1")
                {
                    MessageBox.Show("该张床位已经被停用，请退出后重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //包床
                if (MessageBox.Show(this, "确认包" + this.comboBox1.Text.Trim() + "号床吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                _outmsg = myFunc.ChangeBed("", 5, this.old_bed_id, new Guid(tempTab1.Rows[0]["bed_id"].ToString()), InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);
                OperType = "包床";
                OperContens = _outmsg + old_bed_id.ToString() + "床包" + this.comboBox1.Text.Trim() + "号床";
            }
            else
            {
                //取消包床
                if (MessageBox.Show(this, "确认不包" + this.comboBox1.Text.Trim() + "号床吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                _outmsg = myFunc.ChangeBed("", 6, this.old_bed_id, new Guid(tempTab1.Rows[0]["bed_id"].ToString()), InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);
                OperType = "取消包床";
                OperContens = _outmsg + old_bed_id.ToString() + "床不包" + this.comboBox1.Text.Trim() + "号床";
            }

            if (_outmsg.Trim() != "")
            {
                MessageBox.Show(_outmsg);
            }

            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, OperType, OperContens, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            this.Close();
        }
    }
}
