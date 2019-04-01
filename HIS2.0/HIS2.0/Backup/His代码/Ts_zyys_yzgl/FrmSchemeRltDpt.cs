using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmSchemeRltDpt : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        public static FrmSchemeRltDpt frmmain = null;

        int _isAll = 0;//未全选

        public FrmSchemeRltDpt()
        {
            InitializeComponent();
            InitInfo();

            frmmain = this;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
        }

        public FrmSchemeRltDpt(string chineseName, Form mdiParent)
        {
            InitializeComponent();
            InitInfo();

            this._chineseName = chineseName;
            this._mdiParent = mdiParent;
            frmmain = this;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
        }

        public void InitInfo()
        {
            this.Load += new EventHandler(FrmSchemeRltDpt_Load);

            dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);
            dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);

            txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);

            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            btnClose.Click += new EventHandler(btnClose_Click);
            btnSave.Click += new EventHandler(btnSave_Click);

            checkBox1.CheckedChanged += new EventHandler(chk_CheckedChanged);
            checkBox2.CheckedChanged += new EventHandler(chk_CheckedChanged);
            checkBox3.CheckedChanged += new EventHandler(chk_CheckedChanged);
            checkBox4.CheckedChanged += new EventHandler(chk_CheckedChanged);
            checkBox5.CheckedChanged += new EventHandler(chk_CheckedChanged);
            checkBox6.CheckedChanged += new EventHandler(chk_CheckedChanged);
            checkBox7.CheckedChanged += new EventHandler(chk_CheckedChanged);
        }

        void FrmSchemeRltDpt_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;

            DoQueryDeptInfo();

            //DoQueryBindYzType();
        }

        public void DoQueryDeptInfo(params string[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select DEPT_ID,P_DEPT_ID,LAYER,NAME,PY_CODE,WB_CODE from JC_DEPT_PROPERTY where 1=1 and DELETED=0 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);

                dataGridView1.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    //激发单元格切换事件，联动刷新选择的方案信息
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["NAME"];
                }
            }
            catch { }
        }

        public void DoQueryRltDptInfo(params string[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select case when t2.ID IS null then 0 else 1 end as IS_CHECK,t.* from JC_YZQX t left join JC_YZQX_KS t2 on t.ID=t2.QXID and t2.DEPTID='{0}' where t.JLZT=0", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);

                dataGridView2.DataSource = dt;
            }
            catch { }
        }

        #region"事件"

        void txtQuery_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBind = dataGridView1.DataSource as DataTable;

                if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
                {
                    dtBind.DefaultView.RowFilter = " NAME like '%" + txtQuery.Text.Trim() + "%' or PY_CODE like '%" + txtQuery.Text.Trim() + "%' or WB_CODE like '%" + txtQuery.Text.Trim() + "%'";
                }
                else
                {
                    dtBind.DefaultView.RowFilter = "";
                }

                txtQuery.Select();
            }
            catch { }
        }

        void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            List<string> list = new List<string>();

            if ((chk.Tag != null) && (!string.IsNullOrEmpty(chk.Tag.ToString().Trim())))
            {
                foreach (Control ct in groupBox2.Controls)
                {
                    if (ct is CheckBox)
                    {
                        CheckBox chk1 = ct as CheckBox;
                        if (chk1.Tag != null && chk1.Checked)
                        {
                            list.Add(chk1.Tag.ToString());
                        }
                    }
                }

                string strFilter = "";

                strFilter += list.Count > 0 ? " P_DEPT_ID in (" : "";

                list.ForEach(delegate(string strFil)
                {
                    strFilter += "'" + strFil + "',";
                });

                strFilter += list.Count > 0 ? "'-1')" : "";

                DataTable dtBind = dataGridView1.DataSource as DataTable;
                dtBind.DefaultView.RowFilter = strFilter;
            }
        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null)
                    return;
                this.dataGridView1.EndEdit();

                string strDept = dataGridView1.CurrentRow.Cells["DEPT_ID"].Value.ToString();

                if (!string.IsNullOrEmpty(strDept))
                {
                    DoQueryRltDptInfo(strDept);
                }
            }
            catch { }
        }

        void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"].Value = dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"].Value.ToString().Equals("0") ? "1" : "0";
                //(dataGridView2.DataSource as DataTable).AcceptChanges();
                //dataGridView2.Rows[e.RowIndex].Selected = true;

                System.Windows.Forms.DataGridViewCheckBoxCell chk = ((System.Windows.Forms.DataGridViewCheckBoxCell)(dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"]));

                if (((System.Windows.Forms.DataGridViewCell)(chk)).State == DataGridViewElementStates.None)
                {
                    dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"].Value = dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"].Value.ToString().Equals("0") ? "1" : "0";
                    //dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"].Value = dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"].Value.ToString().Equals("0") ? "1" : "0";
                    (dataGridView2.DataSource as DataTable).AcceptChanges();
                    dataGridView2.Rows[e.RowIndex].Selected = true;
                }
            }
            catch { }
        }

        void btnRefresh_Click(object sender, EventArgs e)
        {
            txtQuery.Text = "";
            DoQueryDeptInfo();//刷新科室信息
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            //to do
            try
            {
                //DataTable tb = chkIsSaveAll.Checked ? (DataTable)dataGridView2.DataSource : ((DataTable)dataGridView2.DataSource).DefaultView.ToTable();
                DataTable tb = (DataTable)dataGridView2.DataSource;


                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                string strDept = dgvr.Cells["DEPT_ID"].Value.ToString();
                //string strScheme = cmbScheme.SelectedValue.ToString();
                //string strSchemeName = cmbScheme.Text;

                if (string.IsNullOrEmpty(strDept))
                {
                    MessageBox.Show("请选择具体的 科室 进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("确认进行当前操作吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                FrmMdiMain.Database.BeginTransaction();
                int iReturn = -1;
                string id = "";

                //删除 该科室下所有方案
                string strSql = string.Format("delete from JC_YZQX_KS where DEPTID='{0}' ", strDept);
                iReturn = FrmMdiMain.Database.DoCommand(strSql);

                //新增 选择的所有权限明细到该医嘱类型下
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["IS_CHECK"].ToString() == "1")
                    {
                        DataRow dr = tb.Rows[i];
                        string strID = dr["ID"].ToString();//方案ID
                        id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                        string sql = "insert into JC_YZQX_KS (ID,QXID,DEPTID,DJR,DJSJ) values ('" + id + "','" + strID + "','" + strDept + "','" + +InstanceForm._currentUser.EmployeeId + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                        iReturn = FrmMdiMain.Database.DoCommand(sql);
                        if (iReturn <= 0)
                        {
                            FrmMdiMain.Database.RollbackTransaction();
                            MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                FrmMdiMain.Database.CommitTransaction();

                //DoQueryBindYzMx(strScheme, strYzType);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                FrmMdiMain.Database.RollbackTransaction();
                return;
            }
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}