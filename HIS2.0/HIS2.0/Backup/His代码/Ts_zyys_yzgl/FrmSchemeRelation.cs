using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace Ts_zyys_yzgl
{
    public partial class FrmSchemeRelation : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmSchemeRelation frmmain = null;

        int _isAll = 0;//未全选

        public FrmSchemeRelation()
        {
            InitializeComponent();
            InitInfo();

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
        }

        public FrmSchemeRelation(string chineseName, Form mdiParent)
        {
            InitializeComponent();
            InitInfo();

            this._chineseName = chineseName;
            this._mdiParent = mdiParent;
            frmmain = this;
            this.dataGridView1.AutoGenerateColumns = false;
        }

        public void InitInfo()
        {
            this.Load += new EventHandler(FrmSchemeRelation_Load);

            dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);
            dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
            dataGridView3.CellClick += new DataGridViewCellEventHandler(dataGridView3_CellClick);

            cmbScheme.SelectedIndexChanged += new EventHandler(cmbScheme_SelectedIndexChanged);

            txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);

            btnClose.Click += new EventHandler(btnClose_Click);
            btnYesAllSelect.Click += new EventHandler(btnAllSelect_Click);
            btnYesReverse.Click += new EventHandler(btnReverse_Click);

            btnNonAllSelect.Click += new EventHandler(btnNonAllSelect_Click);
            btnNoneReverse.Click += new EventHandler(btnNoneReverse_Click);

            btnSave.Click += new EventHandler(btnSave_Click);
        }

        void FrmSchemeRelation_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;

            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;

            DoQueryBindScheme();

            DoQueryBindYzType();

            string strYzType = dataGridView1.CurrentRow.Cells["CODE"].Value.ToString();
            string strScheme = cmbScheme.SelectedValue.ToString();
            try
            {
                //查询绑定已匹配项目
                if (string.IsNullOrEmpty(strYzType) && string.IsNullOrEmpty(strScheme))
                {
                    DoQueryBindYzMx(1, strScheme, strYzType);
                }
                //DoQueryBindYzMx(cmbScheme.SelectedValue.ToString(),
            }
            catch { }

            try
            {
                //查询绑定未匹配项目
                if (string.IsNullOrEmpty(strYzType) && string.IsNullOrEmpty(strScheme))
                {
                    DoQueryBindYzMx(0, strScheme, strYzType);
                }
                //DoQueryBindYzMx(cmbScheme.SelectedValue.ToString(),
            }
            catch { }
        }

        private void DoQueryBindScheme(params string[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select [ID],[QXMC],[JGBM],[BZ],[DEPTID],[JLZT] from [JC_YZQX] where 1=1 and JLZT=0", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);

                cmbScheme.DataSource = dt;
                cmbScheme.DisplayMember = "QXMC";
                cmbScheme.ValueMember = "ID";
                cmbScheme.SelectedIndex = 0;
            }
            catch { return; }
        }

        private void DoQueryBindYzType(params string[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select CODE,NAME,DEPT_ID from JC_ORDERTYPE where code not in ('1','2','3') ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);

                dt.Rows.Add(new object[] { "0", "0-全部", null });
                dt.DefaultView.Sort = "CODE ASC";
                DataTable dtTemp = dt.DefaultView.ToTable();

                dataGridView1.DataSource = dtTemp;
            }
            catch { }
        }

        /// <summary>
        /// 根据ID和医嘱类型查询医嘱明细
        /// </summary>
        /// <param name="iType">0：未匹配   1：已匹配</param>
        /// <param name="args">t2.ID='{0}' and t1.ORDER_TYPE='{1}'</param>
        private void DoQueryBindYzMx(int iType, params string[] args)
        {
            try
            {
                if (args.Length != 2)
                    return;

                DataTable dt = new DataTable();
                string strSql = "";

                //if (args[1].Equals("1")||args[1].Equals("2")||args[1].Equals("3"))
                if (iType == 0)
                {
                    strSql = string.Format(@"select case when t2.ID IS null then '0' else '1' end as IS_CHECK,t1.ORDER_ID,t1.ORDER_NAME,t1.ORDER_UNIT,
                                            t1.ORDER_SPEC,t1.ORDER_TYPE,t1.PY_CODE,t1.WB_CODE,t1.D_CODE
                                            --,dbo.FUN_ZY_SEEKHOITEMPRICE(t1.ORDER_ID,1000) as price 
                                            ,0 as price 
                                            from (select * from JC_HOITEMDICTION where DELETE_BIT=0) t1
                                            left join JC_YZQXMX t2 on t1.ORDER_ID=t2.ORDER_ID and t2.QXID='{0}' 
                                           where  " + (args[1].ToString().Equals("0") ? "t1.ORDER_TYPE in ('4','5','6','7','8','9')" : "t1.ORDER_TYPE like '%{1}'") + 
                                        " and t1.DELETE_BIT=0 and not exists (select 1 from JC_YZQXMX t3 where t1.ORDER_ID=t3.ORDER_ID) order by ORDER_ID", args);

                    dt = FrmMdiMain.Database.GetDataTable(strSql);

                    dataGridView3.DataSource = dt;
                }
                else if (iType == 1)
                {
                    strSql = string.Format(@"select case when t2.ID IS null then '0' else '1' end as IS_CHECK,t1.ORDER_ID,t1.ORDER_NAME,t1.ORDER_UNIT,
                                                t1.ORDER_SPEC,t1.ORDER_TYPE,t1.PY_CODE,t1.WB_CODE,t1.WB_CODE,t1.D_CODE
                                                --,dbo.FUN_ZY_SEEKHOITEMPRICE(t1.ORDER_ID,1000) as price  
                                                    ,0 as price 
                                                    from (select * from JC_HOITEMDICTION where DELETE_BIT=0) t1
                                                    inner join JC_YZQXMX t2 on t1.ORDER_ID=t2.ORDER_ID and t2.QXID='{0}' 
                                                    where " + (args[1].ToString().Equals("0") ? "t1.ORDER_TYPE in ('4','5','6','7','8','9')" : "t1.ORDER_TYPE='{1}'") + 
                                                    " and t1.DELETE_BIT=0 order by ORDER_ID", args);

                    dt = FrmMdiMain.Database.GetDataTable(strSql);

                    dataGridView2.DataSource = dt;
                }

                txtQuery.Text = "";
                _isAll = 0;
            }
            catch { }
        }

        private void SelectAll(int kind, DataGridView myDataGrid)
        {
            DataTable myTb = ((DataTable)myDataGrid.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (kind == 0)
                {
                    myTb.Rows[i]["IS_CHECK"] = "0";
                }
                else if (kind == 1)
                {
                    myTb.Rows[i]["IS_CHECK"] = "1";
                }
                else
                {
                    myTb.Rows[i]["IS_CHECK"] = myTb.Rows[i]["IS_CHECK"].ToString() == "1" ? "0" : "1";
                }
            }
            myDataGrid.DataSource = myTb;
            (myDataGrid.DataSource as DataTable).AcceptChanges();
        }

        void txtQuery_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBind = dataGridView2.DataSource as DataTable;

                if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
                {
                    dtBind.DefaultView.RowFilter = " ORDER_NAME like '%" + txtQuery.Text.Trim() + "%' or PY_CODE like '%" + txtQuery.Text.Trim() + "%' or WB_CODE like '%" + txtQuery.Text.Trim() + "%'";
                }
                else
                {
                    dtBind.DefaultView.RowFilter = "";
                }

                txtQuery.Select();
            }
            catch { }

            try
            {
                DataTable dtBind = dataGridView3.DataSource as DataTable;

                if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
                {
                    dtBind.DefaultView.RowFilter = " ORDER_NAME like '%" + txtQuery.Text.Trim() + "%' or PY_CODE like '%" + txtQuery.Text.Trim() + "%' or WB_CODE like '%" + txtQuery.Text.Trim() + "%'";
                }
                else
                {
                    dtBind.DefaultView.RowFilter = "";
                }

                txtQuery.Select();
            }
            catch { }
        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null)
                    return;
                this.dataGridView1.EndEdit();

                string strYzType = dataGridView1.CurrentRow.Cells["CODE"].Value.ToString();
                string strScheme = cmbScheme.SelectedValue.ToString();

                if ((!string.IsNullOrEmpty(strYzType)) && (!string.IsNullOrEmpty(strScheme)))
                {
                    DoQueryBindYzMx(1, strScheme, strYzType);
                    DoQueryBindYzMx(0, strScheme, strYzType);
                }
            }
            catch { }
        }

        void cmbScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //改变激活行
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["NAME"];

                    string strYzType = dataGridView1.CurrentRow.Cells["CODE"].Value.ToString();
                    string strScheme = cmbScheme.SelectedValue.ToString();

                    if ((!string.IsNullOrEmpty(strYzType)) && (!string.IsNullOrEmpty(strScheme)))
                    {
                        DoQueryBindYzMx(1, strScheme, strYzType);
                        DoQueryBindYzMx(0, strScheme, strYzType);
                    }
                }
            }
            catch { }
        }

        void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                System.Windows.Forms.DataGridViewCheckBoxCell chk = ((System.Windows.Forms.DataGridViewCheckBoxCell)(dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"]));
                ////是否点击CheckBox
                //if ((Convert.ToBoolean(chk.EditedFormattedValue) == true && Convert.ToBoolean(chk.FormattedValue) == false) || (Convert.ToBoolean(chk.EditedFormattedValue) == false && Convert.ToBoolean(chk.FormattedValue) == false))
                //    return;

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

        void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                System.Windows.Forms.DataGridViewCheckBoxCell chk = ((System.Windows.Forms.DataGridViewCheckBoxCell)(dataGridView3.Rows[e.RowIndex].Cells["IS_CHECK_Y"]));
                ////是否点击CheckBox
                //if ((Convert.ToBoolean(chk.EditedFormattedValue) == true && Convert.ToBoolean(chk.FormattedValue) == false) || (Convert.ToBoolean(chk.EditedFormattedValue) == false && Convert.ToBoolean(chk.FormattedValue) == false))
                //    return;

                if (((System.Windows.Forms.DataGridViewCell)(chk)).State == DataGridViewElementStates.None)
                {
                    dataGridView3.Rows[e.RowIndex].Cells["IS_CHECK_Y"].Value = dataGridView3.Rows[e.RowIndex].Cells["IS_CHECK_Y"].Value.ToString().Equals("0") ? "1" : "0";
                    //dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"].Value = dataGridView2.Rows[e.RowIndex].Cells["IS_CHECK"].Value.ToString().Equals("0") ? "1" : "0";
                    (dataGridView3.DataSource as DataTable).AcceptChanges();
                    dataGridView3.Rows[e.RowIndex].Selected = true;
                }
            }
            catch { }
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnReverse_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAll(2, dataGridView2);
            }
            catch { }
        }

        void btnAllSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    _isAll = _isAll == 0 ? 1 : 0;
                    SelectAll(_isAll, dataGridView2);
                }
            }
            catch { }
        }

        void btnNoneReverse_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAll(2, dataGridView3);
            }
            catch { }
        }

        void btnNonAllSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.Rows.Count > 0)
                {
                    _isAll = _isAll == 0 ? 1 : 0;
                    SelectAll(_isAll, dataGridView3);
                }
            }
            catch { }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //chkIsSaveAll.Checked则管理所有的（包括rowfilter过滤掉的）数据，否则只管理界面上显示的数据
                DataTable tb = chkIsSaveAll.Checked ? (DataTable)dataGridView2.DataSource : ((DataTable)dataGridView2.DataSource).DefaultView.ToTable();
                DataTable tbAdd = chkIsSaveAll.Checked ? (DataTable)dataGridView3.DataSource : ((DataTable)dataGridView3.DataSource).DefaultView.ToTable();

                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                string strYzType = dgvr.Cells["CODE"].Value.ToString();
                string strScheme = cmbScheme.SelectedValue.ToString();
                string strSchemeName = cmbScheme.Text;

                if (string.IsNullOrEmpty(strScheme))
                {
                    MessageBox.Show("请选择具体的方案进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (string.IsNullOrEmpty(strYzType))
                {
                    MessageBox.Show("请选择具体的医嘱类型进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("确认进行当前操作吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                FrmMdiMain.Database.BeginTransaction();
                int iReturn = -1;
                string id = "";

                ////删除 该医嘱类型下所有权限明细
                //string strSql = string.Format("delete from JC_YZQXMX where ORDER_TYPE='{0}' and QXID='{1}'", strYzType, strScheme);
                //iReturn = FrmMdiMain.Database.DoCommand(strSql);

                //删除 
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //删除tb中未选中的项目
                    if (tb.Rows[i]["IS_CHECK"].ToString() == "0")
                    {
                        DataRow dr = tb.Rows[i];
                        string strID = dr["ORDER_ID"].ToString();
                        string strSql = string.Format("delete from JC_YZQXMX where ORDER_TYPE='{0}' and QXID='{1}' and order_ID='{2}'", strYzType, strScheme, strID);
                        iReturn = FrmMdiMain.Database.DoCommand(strSql);
                    }
                    //if (tb.Rows[i]["IS_CHECK"].ToString() == "1")
                    //{
                    //    DataRow dr = tb.Rows[i];
                    //    string strID = dr["ORDER_ID"].ToString();
                    //    string strOrderType = dr["ORDER_TYPE"].ToString();
                    //    id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                    //    string sql = "insert into JC_YZQXMX (ID,QXID,QXMC,ORDER_ID,ORDER_TYPE,DJR,DJSJ) values ('" + id + "','" + strScheme + "','" + strSchemeName + "','" + strID + "','" + strOrderType + "','" + +InstanceForm._currentUser.EmployeeId + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    //    iReturn = FrmMdiMain.Database.DoCommand(sql);
                    //    if (iReturn <= 0)
                    //    {
                    //        FrmMdiMain.Database.RollbackTransaction();
                    //        MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //}
                }

                //新增 
                for (int i = 0; i < tbAdd.Rows.Count; i++)
                {
                    //add新增项目
                    if (tbAdd.Rows[i]["IS_CHECK"].ToString() == "1")
                    {
                        DataRow dr = tbAdd.Rows[i];
                        string strID = dr["ORDER_ID"].ToString();
                        string strOrderType = dr["ORDER_TYPE"].ToString();

                        //一个项目只能存在一个方案中  校验该OrderId是否已经存在
                        string valideSql = "select count(1) as NUM from JC_YZQXMX where order_id =" + strID;
                        DataTable dtValid = FrmMdiMain.Database.GetDataTable(valideSql);
                        if (dtValid == null || dtValid.Rows.Count <= 0)
                        {
                            FrmMdiMain.Database.RollbackTransaction();
                            MessageBox.Show("校验明细数量出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (int.Parse(dtValid.Rows[0]["NUM"].ToString()) > 0)
                        {
                            FrmMdiMain.Database.RollbackTransaction();
                            MessageBox.Show(dr["ORDER_ID"].ToString() + "已经匹配，不能操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                        string sql = "insert into JC_YZQXMX (ID,QXID,QXMC,ORDER_ID,ORDER_TYPE,DJR,DJSJ) values ('" + id + "','" + strScheme + "','" + strSchemeName + "','" + strID + "','" + strOrderType + "','" + +InstanceForm._currentUser.EmployeeId + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

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

                DoQueryBindYzMx(1, strScheme, strYzType);
                DoQueryBindYzMx(0, strScheme, strYzType);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                FrmMdiMain.Database.RollbackTransaction();
                return;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }
    }
}