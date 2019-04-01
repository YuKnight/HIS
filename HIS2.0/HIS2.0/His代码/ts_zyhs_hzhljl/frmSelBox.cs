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

namespace ts_zyhs_hzhljl
{
    /// <summary>
    /// frmSelHLModel 的摘要说明。
    /// </summary>
    public class frmSelBox : System.Windows.Forms.Form
    {
        //自定义变量
        private BaseFunc myFunc;
        private string sqlStr = "";
        private DataTable myTb = new DataTable();
        public DataRow myDr;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label 输入;
        private System.Windows.Forms.DataGrid dgShow;
        private System.Windows.Forms.RadioButton rdoPY;
        private System.Windows.Forms.RadioButton rdoWB;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmSelBox()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            myFunc = new BaseFunc();
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
            this.rdoPY = new System.Windows.Forms.RadioButton();
            this.rdoWB = new System.Windows.Forms.RadioButton();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.输入 = new System.Windows.Forms.Label();
            this.dgShow = new System.Windows.Forms.DataGrid();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgShow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoPY);
            this.groupBox1.Controls.Add(this.rdoWB);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(368, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拼音五笔码";
            // 
            // rdoPY
            // 
            this.rdoPY.Checked = true;
            this.rdoPY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoPY.Location = new System.Drawing.Point(8, 24);
            this.rdoPY.Name = "rdoPY";
            this.rdoPY.Size = new System.Drawing.Size(96, 24);
            this.rdoPY.TabIndex = 0;
            this.rdoPY.TabStop = true;
            this.rdoPY.Text = "拼音码(&P)";
            // 
            // rdoWB
            // 
            this.rdoWB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoWB.Location = new System.Drawing.Point(104, 24);
            this.rdoWB.Name = "rdoWB";
            this.rdoWB.Size = new System.Drawing.Size(96, 24);
            this.rdoWB.TabIndex = 1;
            this.rdoWB.Text = "五笔码(&W)";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInput.Location = new System.Drawing.Point(56, 40);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(304, 26);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyUp);
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // 输入
            // 
            this.输入.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.输入.Location = new System.Drawing.Point(8, 45);
            this.输入.Name = "输入";
            this.输入.Size = new System.Drawing.Size(40, 16);
            this.输入.TabIndex = 2;
            this.输入.Text = "输入";
            // 
            // dgShow
            // 
            this.dgShow.AllowSorting = false;
            this.dgShow.BackgroundColor = System.Drawing.Color.White;
            this.dgShow.CaptionVisible = false;
            this.dgShow.ContextMenu = this.contextMenu1;
            this.dgShow.DataMember = "";
            this.dgShow.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgShow.Location = new System.Drawing.Point(8, 80);
            this.dgShow.Name = "dgShow";
            this.dgShow.ReadOnly = true;
            this.dgShow.RowHeadersVisible = false;
            this.dgShow.Size = new System.Drawing.Size(568, 352);
            this.dgShow.TabIndex = 5;
            this.dgShow.DoubleClick += new System.EventHandler(this.dgShow_DoubleClick);
            this.dgShow.Enter += new System.EventHandler(this.dgShow_Enter);
            this.dgShow.CurrentCellChanged += new System.EventHandler(this.dgShow_CurrentCellChanged);
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
            // frmSelBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(584, 445);
            this.Controls.Add(this.dgShow);
            this.Controls.Add(this.输入);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择";
            this.Load += new System.EventHandler(this.frmSelHLModel_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmSelHLModel_Load(object sender, System.EventArgs e)
        {

        }

        public void InitGrid(string v_SqlStr)
        {
            sqlStr = v_SqlStr;
            myTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
            dgShow.DataSource = myTb;
            if (myTb != null && myTb.Rows.Count != 0) dgShow.Select(0);
            txtInput.Focus();
        }

        private void dgShow_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //			if (e.KeyChar==13)
            //			{
            //				myDr=myTb.Rows[dgShow.CurrentRowIndex];
            //				DialogResult=DialogResult.OK;
            //			}
        }

        private void dgShow_DoubleClick(object sender, System.EventArgs e)
        {
            myDr = myTb.Rows[dgShow.CurrentRowIndex];
            DialogResult = DialogResult.OK;
        }

        private void dgShow_CurrentCellChanged(object sender, System.EventArgs e)
        {
            dgShow.Select(dgShow.CurrentRowIndex);
            txtInput.Focus();
            txtInput.Select(txtInput.TextLength, 0);
        }

        private void txtInput_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (myTb != null && myTb.Rows.Count > 0)
                {
                    if (dgShow.CurrentRowIndex >= 0)
                    {
                        myDr = myTb.Rows[dgShow.CurrentRowIndex];
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void txtInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 38)
            {
                dgShow.UnSelect(dgShow.CurrentRowIndex);
                dgShow.BindingContext[dgShow.DataSource].Position = dgShow.BindingContext[dgShow.DataSource].Position - 1;
                dgShow.Select(dgShow.CurrentRowIndex);
                txtInput.Focus();
            }
            if (e.KeyValue == 40)
            {
                dgShow.UnSelect(dgShow.CurrentRowIndex);
                dgShow.BindingContext[dgShow.DataSource].Position = dgShow.BindingContext[dgShow.DataSource].Position + 1;
                dgShow.Select(dgShow.CurrentRowIndex);
                txtInput.Focus();
            }
        }

        private void txtInput_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 38 || e.KeyValue == 40)
            {
                txtInput.Select(txtInput.TextLength, 0);
            }
        }

        private void dgShow_Enter(object sender, System.EventArgs e)
        {
            txtInput.Focus();
            txtInput.Select(txtInput.TextLength, 0);
        }

        private void txtInput_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                string StrSql;

                if (txtInput.Text.Trim() == "") InitGrid(sqlStr);

                if (rdoPY.Checked)
                {
                    StrSql = sqlStr + " and py like '" + txtInput.Text.Trim() + "%'";
                }
                else
                {
                    StrSql = sqlStr + " and wb like '" + txtInput.Text.Trim() + "%'";
                }
                myTb = InstanceForm.BDatabase.GetDataTable(StrSql);
                dgShow.DataSource = myTb;
                if (myTb != null && myTb.Rows.Count != 0) dgShow.Select(0);
                txtInput.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {

            try
            {
                if (MessageBox.Show(this, "记录删除将不能恢复，确认删除这条记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                string strSql = @"delete from ZY_HLJLMODEL where id=" + dgShow[dgShow.CurrentCell.RowNumber, 0].ToString();

                InstanceForm.BDatabase.DoCommand(strSql);

                //写日志 Add By Tany 2005-06-21
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "删除护理记录模板", "将 " + dgShow[dgShow.CurrentCell.RowNumber, 0].ToString() + " 号护理记录模板删除", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                MessageBox.Show(this, "删除成功！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);

                strSql = @"select id,name 名称,model_text 内容,py 拼音码,wb 五笔码,case model_type when 0 then '全院共用' when 1 then '病区使用' when 2 then '科室使用' " +
                    @"when 3 then '个人使用' end 类型 from ZY_HLJLMODEL where mng_type in (0,1) and " +
                    @"((model_type=0) or (model_type=1 and ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                    @" or (model_type=2 and dept_id=" + InstanceForm.BCurrentDept.DeptId + ")" +
                    @" or (model_type=3 and user_id=" + InstanceForm.BCurrentUser.EmployeeId + "))";
                InitGrid(strSql);
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "保存一般患者护理记录错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
