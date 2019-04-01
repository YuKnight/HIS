using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_zyhs_brzk
{
    public partial class FrmZkChk : Form
    {
        private DataTable _dtDept = new DataTable();

        public FrmZkChk()
        {
            InitializeComponent();
            DoInit();
        }

        private void DoInit()
        {
            try
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = false;
            }
            catch
            { }

            this.Load += new EventHandler(FrmZkChk_Load);

            cmbSDept.Enabled = cmbDDept.Enabled = dtpStart.Enabled = dtpEnd.Enabled = false;

            chkSDept.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbSDept.Enabled = chkSDept.Checked;
            });

            chkDDept.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbDDept.Enabled = chkDDept.Checked;
            });

            chkStatus.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbStatus.Enabled = chkStatus.Checked;
            });

            chkFinishBit.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbFinishBit.Enabled = chkFinishBit.Checked;
            });

            chkDjDate.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                dtpStart.Enabled = dtpEnd.Enabled = chkDjDate.Checked;
            });

            btnQuery.Click += new EventHandler(btnQuery_Click);

            btnRefuse.Click += new EventHandler(btnRefuse_Click);

            btnCheck.Click += new EventHandler(btnCheck_Click);

            cmbSDept.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbSDept.Text == "")
                    {
                        cmbSDept.SelectedIndex = 0;
                        return;
                    }

                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm from JC_DEPT_PROPERTY a where a.DELETED=0 ";
                    ssql = ssql + " and  a.jgbm=" + FrmMdiMain.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Name", "pym", "wbm" },
                                                                                       new string[] { "编号", "名称", "拼音码", "五笔码" },
                                                                                       new string[] { "dept_id", "Name", "PYM", "WBM" },
                                                                                       new int[] { 80, 150, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbSDept;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbSDept.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbSDept.Text = "";
                        cmbSDept.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };

            cmbDDept.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbDDept.Text == "")
                    {
                        cmbDDept.SelectedIndex = 0;
                        return;
                    }

                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm from JC_DEPT_PROPERTY a where a.DELETED=0 ";
                    ssql = ssql + " and  a.jgbm=" + FrmMdiMain.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Name", "pym", "wbm" },
                                                                                       new string[] { "编号", "名称", "拼音码", "五笔码" },
                                                                                       new string[] { "dept_id", "Name", "PYM", "WBM" },
                                                                                       new int[] { 80, 150, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbDDept;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbDDept.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbDDept.Text = "";
                        cmbDDept.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };
        }

        void FrmZkChk_Load(object sender, EventArgs e)
        {
            //string[] GrdMappingName1 ={ "转科日期", "转科时间", "床号", "住院号", "姓名", "性别", "源科室", "目标科室", "医生", "登记日期", 
            //                            "inpatient_id", "baby_id", "isMYTS", "d_Dept_id", "s_Dept_id", "order_id", "id", "bed_id",
            //                            "chk_bit", "chk_man", "chk_Time", "ref_memo" };
            //int[] GrdWidth1 ={ 10, 8, 4, 9, 12, 4, 12, 12, 8, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6 };
            //int[] Alignment1 ={ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6 };
            //int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6 };

            try
            {
                _dtDept = DoQueryDept();

                if (_dtDept != null && _dtDept.Rows.Count > 0)
                {
                    DataTable dtS = _dtDept.Copy();
                    Addcmb(cmbSDept, dtS, "dept_id", "name");

                    DataTable dtD = _dtDept.Copy();
                    Addcmb(cmbDDept, dtD, "dept_id", "name");
                }
            }
            catch { }

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CODE", typeof(string));
                dt.Columns.Add("NAME", typeof(string));
                dt.Rows.Add(new object[] { "0", "未审核" });
                dt.Rows.Add(new object[] { "1", "审核" });
                dt.Rows.Add(new object[] { "2", "拒绝" });

                dt.AcceptChanges();

                Addcmb(cmbStatus, dt, "CODE", "NAME");

                cmbStatus.SelectedIndex = 0;
            }
            catch { }

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CODE", typeof(string));
                dt.Columns.Add("NAME", typeof(string));
                dt.Rows.Add(new object[] { "0", "未完成" });
                dt.Rows.Add(new object[] { "1", "已完成" });

                dt.AcceptChanges();

                Addcmb(cmbFinishBit, dt, "CODE", "NAME");

                cmbFinishBit.SelectedIndex = 0;
            }
            catch { }

        }

        private DataTable DoQuery(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();

                string sSql = string.Format(@"select dbo.fun_getdate(Transfer_date) 转科日期,convert(char,Transfer_date,108) 转科时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,
                                            a.SEX_NAME 性别,dbo.FUN_ZY_SEEKDEPTNAME(d.s_Dept_id) 源科室,dbo.FUN_ZY_SEEKDEPTNAME(d.d_Dept_id) 目标科室,
                                            dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) 医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,b.isMYTS,
                                            d.d_Dept_id,d.s_Dept_id,d.order_id,d.id ,b.bed_id,d.chk_bit,dbo.fun_getEmpName(d.chk_man) as chk_man,d.chk_Time,d.ref_memo 
                                            from ZY_TRANSFER_dept d 
                                            left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a
                                            where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id 
                                            and {0}={1}
                                            and {2}>={3}
                                            and {4}<={5}
                                            and {6}={7}
                                            and {8}={9}
                                            and {10}={11}
                                            and {12}={13}
                                            and a.DISCHARGETYPE<>0
                                            and d.cancel_bit=0 
                                            and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)={14}
                                            and not exists (select 1 from ZY_ZKGX where S_DEPT=d.s_Dept_id and D_DEPT=d.d_Dept_id)", args);

                dt = FrmMdiMain.Database.GetDataTable(sSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryDept()
        {
            string strSql = "select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm from JC_DEPT_PROPERTY a where a.DELETED=0";
            return InstanceForm.BDatabase.GetDataTable(strSql);
        }

        private void DoQuery()
        {
            try
            {
                //DataTable dt = DoQuery(string.IsNullOrEmpty(txtZyh.Text.Trim()) ? "1" : "a.INPATIENT_NO", string.IsNullOrEmpty(txtZyh.Text.Trim()) ? "1" : "'" + txtZyh.Text.Trim() + "'",
                //    string.IsNullOrEmpty(txtZyh.Text.Trim()) ? "1" : "a.INPATIENT_NO", string.IsNullOrEmpty(txtZyh.Text.Trim()) ? "1" : "'" + txtZyh.Text.Trim() + "'",
                //    chkSDept.Checked ? "1" : "d.s_Dept_id", chkSDept.Checked ? "1" : "'" + cmbSDept.SelectedValue.ToString() + "'",
                //    chkDDept.Checked ? "1" : "d.D_DEPT_ID", chkDDept.Checked ? "1" : "'" + cmbDDept.SelectedValue.ToString() + "'",
                //    chkStatus.Checked ? "1" : "d.chk_bit", chkStatus.Checked ? "1" : "'" + cmbStatus.SelectedValue.ToString() + "'",
                //    InstanceForm.BCurrentDept.Jgbm);

                DataTable dt = DoQuery(
                    string.IsNullOrEmpty(txtZyh.Text.Trim()) ? "1" : "a.INPATIENT_NO", string.IsNullOrEmpty(txtZyh.Text.Trim()) ? "1" : "'" + txtZyh.Text.Trim() + "'",
                    chkDjDate.Checked ? "book_date" : "1", chkDjDate.Checked ? "'" + dtpStart.Value.ToString("yyyy-MM-dd") + " 00:00:00'" : "1",
                    chkDjDate.Checked ? "book_date" : "1", chkDjDate.Checked ? "'" + dtpEnd.Value.ToString("yyyy-MM-dd") + " 23:59:59'" : "1",
                    chkSDept.Checked ? "d.s_Dept_id" : "1", chkSDept.Checked ? cmbSDept.SelectedValue.ToString() : "1",
                    chkDDept.Checked ? "d.D_DEPT_ID" : "1", chkDDept.Checked ? cmbDDept.SelectedValue.ToString() : "1",
                    chkStatus.Checked ? "d.chk_bit" : "1", chkStatus.Checked ? cmbStatus.SelectedValue.ToString() : "1",
                    chkFinishBit.Checked ? "d.FINISH_BIT" : "1", chkFinishBit.Checked ? cmbFinishBit.SelectedValue.ToString() : "1",
                    InstanceForm.BCurrentDept.Jgbm);

                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch { }
        }

        void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        void btnCheck_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgrv = dataGridView1.CurrentRow;

            if (dgrv == null)
                return;

            if (MessageBox.Show("是否确认操作！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            string id = dgrv.Cells["id"].Value.ToString();


            string strSql = string.Format(@"select count(1) from ZY_TRANSFER_DEPT where id='{0}' and CANCEL_BIT=0 and FINISH_BIT=0 and chk_bit=0", id);

            int i = int.Parse(InstanceForm.BDatabase.GetDataResult(strSql).ToString());

            if (i <= 0)
            {
                MessageBox.Show("只能操作 未取消、未完成、待审核 的转科医嘱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = string.Format(@"update ZY_TRANSFER_DEPT set chk_bit=1,chk_man={0},chk_Time='{1}' where ID='{2}'",
                InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), id);
            InstanceForm.BDatabase.DoCommand(sql);

            MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DoQuery();
        }

        void btnRefuse_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgrv = dataGridView1.CurrentRow;

            if (dgrv == null)
                return;

            string strMes = "";
            if (string.IsNullOrEmpty(txtMemo.Text.Trim()))
            {
                strMes = "是否确认 不输入拒绝原因，直接拒绝该转科请求！";
            }
            else
            {
                strMes = "是否确认拒绝该转科请求！";
            }

            if (MessageBox.Show(strMes, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                txtMemo.Focus();
                return;
            }

            string id = dgrv.Cells["id"].Value.ToString();


            string strSql = string.Format(@"select count(1) from ZY_TRANSFER_DEPT where id='{0}' and CANCEL_BIT=0 and FINISH_BIT=0 and chk_bit=0", id);

            int i = int.Parse(InstanceForm.BDatabase.GetDataResult(strSql).ToString());

            if (i <= 0)
            {
                MessageBox.Show("只能操作 未取消、未完成、待审核 的转科医嘱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //已经审核的转科医嘱不能拒绝
            string sql = string.Format(@"update ZY_TRANSFER_DEPT set chk_bit=2,chk_man={0},chk_Time='{1}',ref_memo='{2}' where ID='{3}'",
                InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), txtMemo.Text.Trim(), id);
            InstanceForm.BDatabase.DoCommand(sql);

            MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DoQuery();
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }


    }
}