using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmSpecialKssChk : Form
    {
        private DataTable _dtDept = new DataTable();

        public FrmSpecialKssChk()
        {
            InitializeComponent();

            DoInit();
        }

        public void DoInit()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoGenerateColumns = false;

            txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);
            //txtSerchSh.TextChanged += new EventHandler(txtSerchSh_TextChanged);
        }

        private void FrmSpecialKssChk_Load(object sender, EventArgs e)
        {
            try
            {
                //
                string strSql = string.Format(@"select DEPT_ID,NAME,PY_CODE,WB_CODE from JC_DEPT_PROPERTY WHERE DELETED=0 AND ZY_FLAG=1");
                _dtDept = InstanceForm._database.GetDataTable(strSql);

                txtDept.Text = InstanceForm._currentDept.DeptName;
                txtDept.Tag = InstanceForm._currentDept.DeptId;

                //Addcmb(cmbDept, dt, "DEPT_ID", "NAME");

                //cmbDept.SelectedValue = InstanceForm._currentDept.DeptId;

                //cmbDept.Enabled = false;
            }
            catch
            { }

            DoQuery();
        }

        //待赋权
        private DataTable DoQueryAll()
        {
            try
            {
                string deptid = txtDept.Tag == null ? "" : txtDept.Tag.ToString().Trim();
                string ssql = string.Format(@"
                                        select a.EMPLOYEE_ID,b.NAME as employee_name,b.PY_CODE,b.WB_CODE
                                        from JC_ROLE_DOCTOR a
                                        inner join JC_EMPLOYEE_PROPERTY b on a.EMPLOYEE_ID=b.EMPLOYEE_ID and b.DELETE_BIT=0
                                        inner join JC_EMP_DEPT_ROLE c on a.EMPLOYEE_ID=c.EMPLOYEE_ID and DEPT_ID='{0}'
                                        where not exists(select 1  from jc_kss_tsshr d where a.EMPLOYEE_ID=d.employee_id and d.dept_id='{0}')
                                        ", deptid); 
                DataTable dt = InstanceForm._database.GetDataTable(ssql);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        //已赋权
        private DataTable DoQueryAlready()
        {
            try
            {
                string deptid = txtDept.Tag == null ? "" : txtDept.Tag.ToString().Trim();
                string ssql = string.Format(@"select a.EMPLOYEE_ID,b.NAME as employee_name,b.PY_CODE,b.WB_CODE
                                                from jc_kss_tsshr a
                                                inner join JC_EMPLOYEE_PROPERTY b on a.EMPLOYEE_ID=b.EMPLOYEE_ID and b.DELETE_BIT=0
                                                inner join JC_EMP_DEPT_ROLE c on a.EMPLOYEE_ID=c.EMPLOYEE_ID and c.dept_id='{0}'
                                              where a.dept_id='{0}'
                                        ", deptid);
                DataTable dt = InstanceForm._database.GetDataTable(ssql);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        private void DoQuery()
        {

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            try
            {
                DataTable dtAll = DoQueryAll();

                if (dtAll != null && dtAll.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dtAll;

                    (dataGridView2.DataSource as DataTable).AcceptChanges();
                }
            }
            catch
            { }

            try
            {
                DataTable dtAlReady = DoQueryAlready();

                if (dtAlReady != null && dtAlReady.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtAlReady;

                    (dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch
            { }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请在【抗菌药物管理小组会诊专家组】中选择一名待添加权限的医生后,在进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            this.dataGridView1.EndEdit();

            DataGridViewRow dgvr = dataGridView1.CurrentRow;

            try
            {
                string deptid = txtDept.Tag == null ? "" : txtDept.Tag.ToString().Trim();
                if (string.IsNullOrEmpty(deptid))
                {
                    MessageBox.Show("请确认输入科室后,在进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }


                string strSql = string.Format("select COUNT(1) as num from jc_kss_tsshr where employee_id='{0}'  and dept_id='{1}'", dgvr.Cells["employee_id"].Value.ToString(), deptid);

                int iNum = int.Parse(InstanceForm._database.GetDataResult(strSql).ToString());

                if (iNum <= 0)
                {
                    DoQuery();
                    return;
                }

                if (MessageBox.Show("是否确认【移除权限】操作", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }

                strSql = string.Format("delete from jc_kss_tsshr where employee_id='{0}' and dept_id='{1}' ", dgvr.Cells["employee_id"].Value.ToString(), deptid);

                InstanceForm._database.DoCommand(strSql);

                DoQuery();

                MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("请在【医生列表】中选择一名待添加权限的医生后,在进行操作","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.dataGridView2.EndEdit();

            DataGridViewRow dgvr = dataGridView2.CurrentRow;

            try
            {
                string deptid = txtDept.Tag == null ? "" : txtDept.Tag.ToString().Trim();
                if (string.IsNullOrEmpty(deptid))
                {
                    MessageBox.Show("请确认输入科室后,在进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string strSql = string.Format("select COUNT(1) as num from jc_kss_tsshr where employee_id='{0}' and dept_id='{1}' ", dgvr.Cells["employee_idys"].Value.ToString(), deptid);

                int iNum = int.Parse(InstanceForm._database.GetDataResult(strSql).ToString());

                if (iNum > 0)
                {
                    DoQuery();
                    return;
                }

                if (MessageBox.Show("是否确认【新增权限】操作", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }

                strSql = string.Format(@"insert into jc_kss_tsshr (id,employee_id,dept_id,opr_man,opr_date) 
                                            values ({0},'{1}','{2}','{3}','{4}') ",
                                            "newid()",
                                            dgvr.Cells["employee_idys"].Value.ToString(),
                                            deptid,
                                            InstanceForm._currentUser.EmployeeId,
                                            DateTime.Now);

                InstanceForm._database.DoCommand(strSql);

                DoQuery();

                MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void txtQuery_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBind = dataGridView2.DataSource as DataTable;

                if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
                {
                    //dtBind.DefaultView.RowFilter = " employee_id like '%" + txtQuery.Text.Trim() + "%' or PY_CODE like '%" + txtQuery.Text.Trim() + "%' or WB_CODE like '%" + txtQuery.Text.Trim() + "%'";
                    dtBind.DefaultView.RowFilter = " PY_CODE like '%" + txtQuery.Text.Trim() + "%' or WB_CODE like '%" + txtQuery.Text.Trim() + "%'";
                }
                else
                {
                    dtBind.DefaultView.RowFilter = "";
                }

                txtQuery.Select();
            }
            catch { }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        private void txtDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                int nkey = (int)e.KeyChar;
                if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
                if (nkey == 13)
                {
                    if (string.IsNullOrEmpty(control.Text.Trim()))
                    {
                        control.Text = "";
                        control.Tag = "";

                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;

                        return;
                    }
                    else
                    {
                        DoQuery();
                    }
                }
                if ((int)e.KeyChar != 13)
                {
                    string[] headtext = new string[] { "科室", "拼音码", "五笔码" };
                    string[] mappingname = new string[] { "name", "PY_CODE", "WB_CODE" };
                    string[] searchfields = new string[] { "name", "PY_CODE", "WB_CODE" };
                    int[] colwidth = new int[] { 150, 100, 100 };

                    TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);

                    f.sourceDataTable = _dtDept;

                    f.WorkForm = this;

                    f.srcControl = control;
                    f.Font = control.Font;
                    f.Width = 400;
                    f.ReciveString = e.KeyChar.ToString();
                    e.Handled = true;
                    if (f.ShowDialog() == DialogResult.Cancel)
                    {
                        control.Focus();
                        return;
                    }
                    else
                    {
                        control.Tag = f.SelectDataRow["DEPT_ID"].ToString().Trim();
                        control.Text = f.SelectDataRow["name"].ToString().Trim();
                        txtDept.SelectAll();

                        if (string.IsNullOrEmpty(control.Text.Trim()))
                        {
                            control.Text = "";
                            control.Tag = "";

                            dataGridView1.DataSource = null;
                            dataGridView2.DataSource = null;

                            return;
                        }
                        else
                        {
                            DoQuery();
                        }
                    }
                }
            }
            catch { }
        }
    }
}