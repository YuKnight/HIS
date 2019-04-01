using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace ts_mz_txyy
{
    public partial class FrmUrgentOrdMsg : Form
    {

        public static FrmUrgentOrdMsg frmmain = null;

        bool _isAdd = false;

        public FrmUrgentOrdMsg()
        {
            InitializeComponent();
            InitInfo();

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
        }

        public void InitInfo()
        {
            btnQuery.Click += new EventHandler(btnQuery_Click);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnClose.Click += new EventHandler(btnClose_Click);
            btnSave.Click += new EventHandler(btnSave_Click);

            // dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            // dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            //  dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);
            dataGridView2.CurrentCellChanged += new EventHandler(dataGridView2_CurrentCellChanged);

            txtName.KeyPress += new KeyPressEventHandler(GotoNext);
            txtTel.KeyPress += new KeyPressEventHandler(GotoNext);
         //   txtemp_id.KeyPress += new KeyPressEventHandler(GotoNext);
            txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);

        }

        private void FrmUrgentOrdMsg_Load(object sender, EventArgs e)
        {
            //txtName.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoGenerateColumns = false;
            txtName.ReadOnly = true;
            txtName.Enabled = false;
            txtemp_id.Enabled = false;
            txtemp_id.ReadOnly = true;


            DoQuery();
            DoQuery2();
            txtTel.Focus();
        }
        private void DoQuery()
        {
            try
            {
                DataTable dt = DoQueryData();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                    //(this.dataGridView1.DataSource as DataTable).AcceptChanges();


                }
            }
            catch { }
        }

        private DataTable DoQueryData(params object[] args)   //datatable获取数据
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select NAME,PY_CODE,WB_CODE,EMPLOYEE_ID from JC_EMPLOYEE_PROPERTY a where exists(select 1 from JC_EMP_DEPT_ROLE b 
                                        where a.EMPLOYEE_ID=b.EMPLOYEE_ID and b.DEPT_ID in (9,192))and not exists(select 1 from jc_msg_UrgentOrd c where a.EMPLOYEE_ID=c.emp_id)", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private void DoQuery2()
        {
            try
            {
                DataTable dt = DoQueryData2();
                if (dt != null)
                {
                    this.dataGridView2.DataSource = dt;
                    (this.dataGridView2.DataSource as DataTable).AcceptChanges();


                }
            }
            catch { }
        }

        private DataTable DoQueryData2(params object[] args)   //datatable获取数据
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select a.PY_CODE,NAME,emp_id,case when is_send=0 then '发送' else '不发送' end as IsSend,case when yqid=0 then '南京路  后湖' when yqid=1001 then'南京路'when yqid=1002 then'后湖' else  '不发'end as yqid,tel
                                                from JC_EMPLOYEE_PROPERTY a inner join jc_msg_UrgentOrd b on a.EMPLOYEE_ID=b.emp_id where 1=1   ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private void DoChangeColor()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["EMPLOYEE_ID"].Value.ToString().Equals("1"))
                {
                    dr.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void DoGetFocus(string id)
        {
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                if (dr.Cells["emp_id"].Value.ToString().Equals(id))
                {
                    dr.Selected = true;
                }
                else
                {
                    dr.Selected = false;
                }
            }
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                switch (control.Name)
                {
                    default:
                        this.SelectNextControl(control, true, false, true, true);
                        break;
                }

            }
        }

        void txtQuery_TextChanged(object sender, EventArgs e)
        {
            DataTable dtBind = dataGridView1.DataSource as DataTable;
            DataTable dtBind2 = dataGridView2.DataSource as DataTable;


            if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
            {
                dtBind.DefaultView.RowFilter = " PY_CODE like '%" + txtQuery.Text.Trim() + "%'";
                dtBind2.DefaultView.RowFilter = " PY_CODE like '%" + txtQuery.Text.Trim() + "%'";


                DoChangeColor();
            }
            else
            {
                DoQuery();
                DoQuery2();
            }

            txtQuery.Select();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DoQuery();
                DoQuery2();
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtName.Text =  this.dataGridView1.CurrentRow.Cells["name"].Value.ToString();

                chkIssend.Checked = true;

                txtTel.Enabled = true;
                txtTel.Text = "";
                txtTel.Select();

                _isAdd = true;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = string.Empty;
                int iReturn = 0;
                if (string.IsNullOrEmpty(txtTel.Text))
                {
                    MessageBox.Show("请输入电话号码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTel.Focus();
                    return;
                }

                if (!(chkhh.Checked || chknjl.Checked))
                {
                    MessageBox.Show("请为" + txtName.Text + "选择一个院区权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string id = "";

                if (_isAdd)//新增
                {
                    if (this.dataGridView1.CurrentRow == null)
                    {
                        return;
                    }

                    strSql = string.Format(@"select count(1) as NUM from  [jc_msg_UrgentOrd]  where emp_id ='{0}'", txtemp_id.Text);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        return;
                    }
                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        MessageBox.Show(txtName.Text + "的权限名称已存在，请重新命名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string yqid = Chkyqid_chk();
                    string issend = Chkissend_chk();

                    id = dataGridView1.CurrentRow.Cells["EMPLOYEE_ID"].Value.ToString();

                    strSql = string.Format(@"insert into [jc_msg_UrgentOrd](emp_id,is_send,YQID,TEL) VALUES('{0}','{1}',{2},'{3}')", id, issend, yqid, txtTel.Text);//******************
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);
                }
                else//修改
                {
                    if (this.dataGridView2.CurrentRow == null)
                    {
                        return;
                    }

                    id = this.dataGridView2.CurrentRow.Cells["emp_id"].Value.ToString();
                    string name = this.dataGridView2.CurrentRow.Cells["ColName"].Value.ToString();

                    strSql = string.Format(@"select count(1) as NUM from  [jc_msg_UrgentOrd] where emp_id='{0}'", id);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("错误：请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnQuery_Click(null, null);
                        return;
                    }

                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) != 1)
                    {
                        MessageBox.Show(name + "的工号数据异常,请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnQuery_Click(null, null);
                        return;
                    }

                    string yqid = Chkyqid_chk();
                    string issend = Chkissend_chk();

                    strSql = string.Format(@"update   [jc_msg_UrgentOrd] set  
                                            [TEL] = {1},
                                            [is_send] = '{2}',[yqid]='{3}' where emp_id='{0}'", id, txtTel.Text, issend, yqid);
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);
                }

                if (iReturn <= 0)
                {
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DoQuery();
                DoQuery2();
                DoGetFocus(id);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*   private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
           {
               if (e.Button = MouseButtons.Left)
               {
                   this.dataGridView1.Rows[e.RowIndex].Selected = true;
                   this.dataGridView1.CurrentCell=this.dataGridView1.Rows[e.RowIndex ].cell[1];
                   string txname = dataGridView1.CurrentCell.Value.ToString();
                   string txttel = dataGridView1.CurrentCell.Value.ToString();
                   txtName.Text = txtName;
                   txtTel.Text = txtTel;
               }
           }*/

        private string Chkyqid_chk()
        {
            string yqid;
            if (chknjl.Checked)
            {
                if (chkhh.Checked)
                    yqid = "0";

                else
                    yqid = "1001";

            }
            else
            {
                if (chkhh.Checked)
                    yqid = "1002";
                else
                    yqid = "-1";
            }
            return yqid;


        }
        private string Chkissend_chk()
        {
            string issend;
            if (chkIssend.Checked)
                issend = "0";
            else
                issend = "1";
            return issend;

        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null)
                    return;
                this.dataGridView1.EndEdit();

                txtName.Text = this.dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                txtemp_id.Text = this.dataGridView1.CurrentRow.Cells["EMPLOYEE_ID"].Value.ToString();
                chkIssend.Checked = false;
                chkhh.Checked = false;
                chknjl.Checked = false;
                txtTel.Text = "";
                txtTel.Enabled = false;
                _isAdd = false;
            }
            catch { }
        }

        void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentCell == null)
                    return;
                this.dataGridView2.EndEdit();

                txtName.Text = this.dataGridView2.CurrentRow.Cells["ColName"].Value.ToString();
                //IsSend

                chkIssend.Checked = this.dataGridView2.CurrentRow.Cells["IsSend"].Value.ToString().Equals("发送");

                string yqid = this.dataGridView2.CurrentRow.Cells["yqid"].Value.ToString();
                chkhh.Checked = yqid.Equals("后湖") ? true : yqid.Equals("全发") ? true : false;
                chknjl.Checked = yqid.Equals("南京路") ? true : yqid.Equals("全发") ? true : false;

                txtTel.Text = this.dataGridView2.CurrentRow.Cells["tel"].Value.ToString();
                txtemp_id.Text = this.dataGridView2.CurrentRow.Cells["emp_id"].Value.ToString();

                txtTel.Enabled = true;

                _isAdd = false;
            }
            catch { }
        }
        
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                { 
                    e.Handled = true;

                    MessageBox.Show("请输入数字");
                    
                }
            }
        }

       
        

    }
}