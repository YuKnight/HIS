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

namespace ts_zyhs_wclxmcx
{
    /// <summary>
    /// 未执行项目查询 的摘要说明。
    /// </summary>
    public class frmWCLXM : System.Windows.Forms.Form
    {
        //自定义变量
        private Guid _inpatinet_id = Guid.Empty;
        private long _baby_id = 0;
        private string BedNo = "";
        private string BinName = "";

        //Add By Tany 2015-05-27
        private SystemCfg cfg7806; //未处理项目是否可以取消药品 0=否 1=是（受限于参数7081）
        private SystemCfg cfg7807; //未处理项目是否可以取消项目 0=否 1=是（受限于参数7081）

        private BaseFunc myFunc = new BaseFunc();

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmWCLXM(Guid _inpatientId, long _babyId)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            _inpatinet_id = _inpatientId;
            _baby_id = _babyId;

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
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 459);
            this.panel1.TabIndex = 1;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "未处理项目";
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
            this.myDataGrid1.Size = new System.Drawing.Size(750, 459);
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
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 459);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 56);
            this.panel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.Location = new System.Drawing.Point(600, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.ImageIndex = 0;
            this.btnExit.Location = new System.Drawing.Point(670, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 24);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.button3.Location = new System.Drawing.Point(592, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 40);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 515);
            this.panel3.TabIndex = 3;
            // 
            // frmWCLXM
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(750, 515);
            this.Controls.Add(this.panel3);
            this.Name = "frmWCLXM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "未处理项目查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmWzxxm_Load);
            this.Activated += new System.EventHandler(this.frmWCLXM_Activated);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void ShowData(Guid inpat_id, long baby_id)
        {
            string sSql = "exec sp_zyhs_selwclxm '" + inpat_id + "'," + baby_id;
            myFunc.ShowGrid(0, sSql, this.myDataGrid1);
            DataTable myTb = GetPatInfo(_inpatinet_id, _baby_id);

            if (myTb.Rows.Count > 0)
            {
                BedNo = myTb.Rows[0]["bed_no"].ToString();
                BinName = myTb.Rows[0]["name"].ToString();
            }

            string[] GrdMappingName1 ={ "类型", "内容", "数量", "单位", "金额", "执行科室", "开单科室", "录入人", "录入时间", "ID" };
            int[] GrdWidth1 ={ 10, 25, 6, 10, 8, 12, 12, 6, 10, 0 };
            int[] Alignment1 ={ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

            myDataGrid1.CaptionText = "未处理项目查询（床号：" + BedNo.Trim() + " 姓名：" + BinName.Trim() + "）";

        }

        private void frmWzxxm_Load(object sender, System.EventArgs e)
        {
            if (_inpatinet_id == null || _inpatinet_id == Guid.Empty)
            {
                MessageBox.Show("请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //7081未处理项目查询是否允许取消未记账的费用 0=不是 1=是
            if (new SystemCfg(7081).Config == "1")
            {
                btnCancel.Visible = true;
            }
            else
            {
                btnCancel.Visible = false;
            }

            //Add By Tany 2015-05-27
            cfg7806 = new SystemCfg(7806);
            cfg7807 = new SystemCfg(7807);
        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            int nrow = myFunc.SelRow(this.myDataGrid1);

            //Modify By Tany 2015-05-27
            //7806未处理项目是否可以取消药品 0=否 1=是（受限于参数7081）
            //7807未处理项目是否可以取消项目 0=否 1=是（受限于参数7081）
            if ((myDataGrid1[nrow, 0].ToString().Trim() == "药品" && cfg7806.Config == "1")
                || (myDataGrid1[nrow, 0].ToString().Trim() == "费用" && cfg7807.Config == "1"))
            {
                btnCancel.Enabled = true;
            }
            else
            {
                btnCancel.Enabled = false;
            }
        }

        private DataTable GetPatInfo(Guid inpatient_id, long baby_id)
        {
            //获取病人的基本信息
            string sqlStr = "";
            DataTable dbTb = new DataTable();
            sqlStr = @"select a.name,a.cur_dept_name,a.bed_no,a.inpatient_no,b.ward_name from VI_ZY_VINPATIENT_BED a,JC_WARD b where a.ward_id=b.ward_id and a.inpatient_id='" + inpatient_id + "' and a.baby_id=" + baby_id;
            dbTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
            return dbTb;
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmWCLXM_Activated(object sender, System.EventArgs e)
        {
            ShowData(_inpatinet_id, _baby_id);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            int nrow = myDataGrid1.CurrentCell.RowNumber;
            DataTable tab = (DataTable)this.myDataGrid1.DataSource;
            if (myDataGrid1[nrow, 0].ToString().Trim() != "药品" && myDataGrid1[nrow, 0].ToString().Trim() != "费用")
            {
                return;
            }

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false)
                {
                    return;
                }
            }
            if (!myFunc.IsHSZ(InstanceForm.BCurrentUser.EmployeeId))
            {
                MessageBox.Show("对不起，只有护士长能够取消费用和药品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sSql = "";
            if (Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["数量"], "0")) > 0)
            {
                //Modify By Tany 2015-03-20 只要有冲账，就不能取消
                sSql = "select * from zy_fee_speci where cz_id='" + myDataGrid1[nrow, 9].ToString() + "' and discharge_bit=0 and delete_bit=0";//and charge_bit=0 
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show("对不起，该记录已被冲正，请先取消相应的冲正记录，才能取消该记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //Modify by jchl【校验该费用如果是检查或者检验   需要同步删除检查、检验申请】
            string feeid = myDataGrid1[nrow, 9].ToString();
            sSql = string.Format(@"select b.INPATIENT_ID,b.GROUP_ID,b.NTYPE from ZY_FEE_SPECI a 
                                    inner join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID and b.DELETE_BIT=0
                                    where a.ID='{0}' and a.DELETE_BIT=0", feeid);

            DataTable dt = InstanceForm.BDatabase.GetDataTable(sSql);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("该费用对应的医嘱不存在有效记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InstanceForm.BDatabase.BeginTransaction();
            try
            {
                string NTYPE = dt.Rows[0]["NTYPE"].ToString().Trim();

                //医技特殊处理
                if (NTYPE.Trim().Equals("5"))
                {
                    //医技的取消需要同步删除zy_jy_print或zy_jc_apply
                    string InpId = dt.Rows[0]["INPATIENT_ID"].ToString().Trim();
                    string GrpId = dt.Rows[0]["GROUP_ID"].ToString().Trim();


                    sSql = string.Format(@"select COUNT(1) as num from ZY_JC_RECORD where INPATIENT_ID='{0}' and GROUP_ID='{1}' and DELETE_BIT=0", InpId, GrpId);
                    int iRet = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sSql).ToString());
                    if (iRet > 0)
                    {
                        sSql = string.Format(@"update  ZY_JC_RECORD set DELETE_BIT=1 where INPATIENT_ID='{0}' and GROUP_ID='{1}' and DELETE_BIT=0 ", InpId, GrpId);
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                    else
                    {
                        //如果确定是检查  就不可能是检验了
                        sSql = string.Format(@"select COUNT(1) as num from zy_jy_print where INPATIENT_ID='{0}' and GROUP_ID='{1}' and DELETE_BIT=0", InpId, GrpId);

                        iRet = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sSql).ToString());
                        if (iRet > 0)
                        {
                            sSql = string.Format(@"update  zy_jy_print set DELETE_BIT=1 where INPATIENT_ID='{0}' and GROUP_ID='{1}' and DELETE_BIT=0 ", InpId, GrpId);
                            InstanceForm.BDatabase.DoCommand(sSql);
                        }
                    }

                    sSql = string.Format(@"update zy_fee_speci set delete_bit=1 
                                            from zy_fee_speci a inner join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID and b.INPATIENT_ID='{0}' and b.GROUP_ID='{1}'
                                            where a.DISCHARGE_BIT=0 and a.charge_bit=0", InpId, GrpId);
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
                else
                {

                    sSql = "update zy_fee_speci set delete_bit=1 where discharge_bit=0 and charge_bit=0 and id='" + myDataGrid1[nrow, 9].ToString() + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                }

                InstanceForm.BDatabase.CommitTransaction();
            }
            catch (Exception ex)
            {
                InstanceForm.BDatabase.RollbackTransaction();

                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ShowData(_inpatinet_id, _baby_id);

                return;
            }

            //写日志 Add By Tany 2005-10-08
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "删除费用记录", "将 " + _inpatinet_id + " 病人的 ZY_FEE_SPECI.ID=" + myDataGrid1[nrow, 9].ToString().Trim() + " 的记录删除", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            ShowData(_inpatinet_id, _baby_id);



            MessageBox.Show("取消成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
