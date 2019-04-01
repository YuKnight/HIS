using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_jc_gfbl
{
    public partial class FrmSflbMx : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmSflbMx frmmain = null;

        public FrmSflbMx()
        {
            InitializeComponent();
            InitInfo();

            this.dataGridView1.AutoGenerateColumns = false;
        }

        public FrmSflbMx(string chineseName, Form mdiParent)
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
            this.CHECK.ReadOnly = true;
            this.ISCHECK.ReadOnly = true;

            this.Load += new EventHandler(FrmSflbMx_Load);

            btnReadyAll.Click += new EventHandler(btnReadyAll_Click);
            btnReadyRev.Click += new EventHandler(btnReadyRev_Click);
            btnNonAll.Click += new EventHandler(btnNonAll_Click);
            btnNonRev.Click += new EventHandler(btnNonRev_Click);

            cmbReadyItem.Enabled = false;
            chkReadyItem.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbReadyItem.Enabled = chkReadyItem.Checked;
                if (chkReadyItem.Checked)
                {
                    cmbReadyItem.Focus();
                    cmbReadyItem.SelectAll();
                    DoDataFil_Item(cmbReadyItem, dataGridView2);
                }
                else
                {
                    DoDataFil_Item(cmbReadyItem, dataGridView2);
                }
            });

            cmbNonItem.Enabled = false;
            chkNonItem.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbNonItem.Enabled = chkNonItem.Checked;
                if (chkNonItem.Checked)
                {
                    cmbNonItem.Focus();
                    cmbNonItem.SelectAll();
                    DoDataFil_Item(cmbNonItem, dataGridView3);
                }
                else
                {
                    DoDataFil_Item(cmbNonItem, dataGridView3);
                }
            });

            cmbReadyItem.SelectedIndexChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                DoDataFil_Item(cmbReadyItem, dataGridView2);
            });

            cmbNonItem.SelectedIndexChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                DoDataFil_Item(cmbNonItem, dataGridView3);
            });

            chkShowSflb.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                DoDataFil_Sflb();
            });

            dataGridView1.CurrentCellChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                DoDataFil_Sflb();
            });


            txtNonQuery.TextChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                DoFilData(dataGridView3);
            });

            txtReadyQuery.TextChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                DoFilData(dataGridView2);
            });

            dataGridView3.CellClick += new DataGridViewCellEventHandler(dataGridView3_CellClick);

            dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
            //btnQuery.Click += new EventHandler(btnQuery_Click);
            //btnAdd.Click += new EventHandler(btnAdd_Click);
            //btnClose.Click += new EventHandler(btnClose_Click);
            //btnSave.Click += new EventHandler(btnSave_Click);

            //dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            //dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            //dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);

            //txtCode.KeyPress += new KeyPressEventHandler(GotoNext);
            //txtMemo.KeyPress += new KeyPressEventHandler(GotoNext);
            //txtName.KeyPress += new KeyPressEventHandler(GotoNext);
            //txtPym.KeyPress += new KeyPressEventHandler(GotoNext);
            //txtWbm.KeyPress += new KeyPressEventHandler(GotoNext);
            //txtSzm.KeyPress += new KeyPressEventHandler(GotoNext);
            //txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);

        }

        void FrmSflbMx_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = false;
            }
            catch { }

            try
            {
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToDeleteRows = false;
                dataGridView2.ReadOnly = true;
                this.dataGridView2.AutoGenerateColumns = false;
            }
            catch { }

            try
            {
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.AllowUserToDeleteRows = false;
                dataGridView3.ReadOnly = true;
                this.dataGridView3.AutoGenerateColumns = false;
            }
            catch { }

            try
            {
                DoQuery();
                DoQueryReadyItem();
                DoQueryNonItem();

                chkShowSflb.Checked = true;

                DataTable dt = DoQuerySchItem();
                Addcmb(cmbReadyItem, dt, "CODE", "ITEM_NAME");
                DataTable dt1 = dt.Copy();
                Addcmb(cmbNonItem, dt1, "CODE", "ITEM_NAME");
            }
            catch { }
        }

        private void DoQuery()
        {
            try
            {
                DataTable dt = DoQueryDataSflb();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();

                }
            }
            catch { }
        }

        private void DoQueryReadyItem()
        {
            try
            {
                DataTable dt = DoQueryData_ReadyItem();
                if (dt != null)
                {
                    this.dataGridView2.DataSource = dt;
                    (this.dataGridView2.DataSource as DataTable).AcceptChanges();

                }
            }
            catch { }
        }

        private void DoQueryNonItem()
        {
            try
            {
                DataTable dt = DoQueryData_NonItem();
                if (dt != null)
                {
                    this.dataGridView3.DataSource = dt;
                    (this.dataGridView3.DataSource as DataTable).AcceptChanges();

                }
            }
            catch { }
        }

        private DataTable DoQueryDataSflb(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select name,sflb from jc_gf_sflb where del_bit=0 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryData_ReadyItem(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select 'true' as ISCHECK,ITEM_ID as ITEM_CODE,item_name as item_name,c.name  as ITEM_SFLBMC,b.sflb as ITEM_SFLB,a.STATITEM_CODE ,a.PY_CODE,a.WB_CODE  from JC_HSITEMDICTION a inner join jc_gf_sflbmx b on a.ITEM_ID=b.xmid and xmly=2 and b.del_bit=0 inner join jc_gf_sflb c on b.sflb=c.sflb and c.del_bit=0 where a.DELETE_BIT=0 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryData_NonItem(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select 'false' as [CHECK],ITEM_ID as xmid,item_name as xmmc,STATITEM_CODE ,a.PY_CODE,a.WB_CODE  from JC_HSITEMDICTION a where a.DELETE_BIT=0 and not exists (select 1 from jc_gf_sflbmx b where a.ITEM_ID=b.xmid and xmly=2 and b.del_bit=0) ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQuerySchItem(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select * from jc_stat_item", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
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
                    if (myTb.Columns.Contains("ISCHECK"))
                    {
                        myTb.Rows[i]["ISCHECK"] = "false";
                    }
                    else if (myTb.Columns.Contains("CHECK"))
                    {
                        myTb.Rows[i]["CHECK"] = "false";
                    }
                }
                else if (kind == 1)
                {
                    if (myTb.Columns.Contains("ISCHECK"))
                    {
                        myTb.Rows[i]["ISCHECK"] = "true";
                    }
                    else if (myTb.Columns.Contains("CHECK"))
                    {
                        myTb.Rows[i]["CHECK"] = "true";
                    }
                }
                else
                {
                    if (myTb.Columns.Contains("ISCHECK"))
                    {
                        myTb.Rows[i]["ISCHECK"] = myTb.Rows[i]["ISCHECK"].ToString() == "true" ? "false" : "true";
                    }
                    else if (myTb.Columns.Contains("CHECK"))
                    {
                        myTb.Rows[i]["CHECK"] = myTb.Rows[i]["CHECK"].ToString() == "true" ? "false" : "true";
                    }
                }
            }
            myDataGrid.DataSource = myTb;
            (myDataGrid.DataSource as DataTable).AcceptChanges();
        }

        private void DoDataFil_Item(ComboBox cmbFil, DataGridView myDataGrid)
        {
            try
            {
                if (myDataGrid == dataGridView2 ? chkReadyItem.Checked : myDataGrid == dataGridView3 ? chkNonItem.Checked : false)
                {
                    DataTable dtBind = myDataGrid.DataSource as DataTable;

                    if (!string.IsNullOrEmpty(cmbFil.SelectedValue.ToString().Trim()))
                    {
                        DoFilData(myDataGrid);

                    }
                    else
                    {
                        if (myDataGrid == dataGridView2)
                        {
                            DoQueryData_ReadyItem();
                            DoFilData(myDataGrid);
                        }
                        else if (myDataGrid == dataGridView3)
                        {
                            DoQueryData_NonItem();
                            DoFilData(myDataGrid);
                        }
                    }

                    cmbFil.Select();
                }
                else
                {
                    if (myDataGrid == dataGridView2)
                    {
                        DoQueryData_ReadyItem();
                        DoFilData(myDataGrid);
                    }
                    else if (myDataGrid == dataGridView3)
                    {
                        DoQueryData_NonItem();
                        DoFilData(myDataGrid);
                    }
                }
            }
            catch { }
        }

        private void DoDataFil_Sflb()
        {
            try
            {
                DataTable dtSflb = dataGridView1.DataSource as DataTable;
                if (dtSflb == null || dtSflb.Rows.Count <= 0)
                    return;

                DataGridViewRow dgr = dataGridView1.CurrentRow;
                if (dgr == null)
                    return;

                string strItemCode = dgr.Cells["sflb"].Value.ToString();

                if (chkShowSflb.Checked)
                {
                    DataTable dtBind = dataGridView2.DataSource as DataTable;

                    if (!string.IsNullOrEmpty(strItemCode.Trim()))
                    {
                        DoFilData(dataGridView2);
                    }
                }
                else
                {
                    //DoQueryData_ReadyItem();
                    DoFilData(dataGridView2);
                    //wait to do
                }
            }
            catch { }
        }

        private void DoDataFil_ItemName(DataGridView myDataGrid, TextBox txtFil)
        {
            try
            {
                DataTable dtBind = myDataGrid.DataSource as DataTable;

                DoFilData(myDataGrid);

                txtFil.Select();
            }
            catch { }
        }

        private void DoFilData(DataGridView myDataGrid)
        {
            try
            {
                DataTable dtBind = myDataGrid.DataSource as DataTable;
                dtBind.DefaultView.RowFilter = "";
                string strFil = " 1=1 ";

                if (myDataGrid == dataGridView2)    //过滤匹配
                {
                    if (chkShowSflb.Checked)
                    {
                        DataTable dtSflb = dataGridView1.DataSource as DataTable;
                        if (dtSflb != null && dtSflb.Rows.Count > 0)
                        {
                            DataGridViewRow dgr = dataGridView1.CurrentRow;
                            if (dgr != null)
                            {
                                string strItemCode = dgr.Cells["sflb"].Value.ToString();
                                if (!string.IsNullOrEmpty(strItemCode.Trim()))
                                {
                                    strFil += " and ITEM_SFLB  = '" + strItemCode + "'";
                                }
                            }
                        }
                    }

                    if (chkReadyItem.Checked)
                    {
                        if (!string.IsNullOrEmpty(cmbReadyItem.SelectedValue.ToString().Trim()))
                        {
                            strFil += " and STATITEM_CODE  = '" + cmbReadyItem.SelectedValue.ToString().Trim() + "'";
                        }
                    }

                    if (!string.IsNullOrEmpty(txtReadyQuery.Text.Trim()))
                    {
                        strFil += " and (py_code  like '%" + txtReadyQuery.Text.Trim() + "%' or wb_code like '%" + txtReadyQuery.Text.Trim() + "%'or ITEM_SFLBMC  like '%" + txtReadyQuery.Text.Trim() + "%')";
                    }
                }
                else if (myDataGrid == dataGridView3)   //过滤未匹配
                {
                    if (chkNonItem.Checked)
                    {
                        if (!string.IsNullOrEmpty(cmbNonItem.SelectedValue.ToString().Trim()))
                        {
                            strFil += " and STATITEM_CODE  = '" + cmbNonItem.SelectedValue.ToString().Trim() + "'";
                        }
                    }

                    if (!string.IsNullOrEmpty(txtNonQuery.Text.Trim()))
                    {
                        strFil += " and (py_code  like '%" + txtNonQuery.Text.Trim() + "%' or wb_code like '%" + txtNonQuery.Text.Trim() + "%')";
                    }
                }

                dtBind.DefaultView.RowFilter = strFil;
            }
            catch { }
        }

        void btnNonRev_Click(object sender, EventArgs e)
        {

            try
            {
                SelectAll(2, dataGridView3);
            }
            catch { }
        }

        void btnNonAll_Click(object sender, EventArgs e)
        {

            try
            {
                SelectAll(1, dataGridView3);
            }
            catch { }
        }

        void btnReadyRev_Click(object sender, EventArgs e)
        {

            try
            {
                SelectAll(2, dataGridView2);
            }
            catch { }
        }

        void btnReadyAll_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAll(1, dataGridView2);
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //chkNonIsSaveAll.Checked则管理所有的（包括rowfilter过滤掉的）数据，否则只管理界面上显示的数据
                DataTable tbAdd = chkNonIsSaveAll.Checked ? (DataTable)dataGridView3.DataSource : ((DataTable)dataGridView3.DataSource).DefaultView.ToTable();

                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                string strSflb = dgvr.Cells["sflb"].Value.ToString();

                if (string.IsNullOrEmpty(strSflb))
                {
                    MessageBox.Show("请选择具体的收费类别进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("确认进行当前操作吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                FrmMdiMain.Database.BeginTransaction();
                int iReturn = -1;
                string id = "";

                //新增 
                for (int i = 0; i < tbAdd.Rows.Count; i++)
                {
                    //add新增项目
                    if (tbAdd.Rows[i]["CHECK"].ToString() == "true")
                    {
                        DataRow dr = tbAdd.Rows[i];
                        int xmly = 2;//2：项目   1：药品
                        int xmid = Convert.ToInt32(dr["xmid"].ToString());

                        //一个项目只能存在一个方案中  校验该OrderId是否已经存在
                        string valideSql = "select count(1) as NUM from jc_gf_sflbmx where xmly =" + xmly + " and xmid=" + xmid + " and del_bit=0";
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
                            MessageBox.Show(dr["xmmc"].ToString() + "已经匹配，不能操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                        string sql = "insert into jc_gf_sflbmx (sflb,xmly,xmid,del_bit,Opr_man,Opr_time) values ('" + strSflb + "'," + xmly + "," + xmid + ",0,'" + +InstanceForm._currentUser.EmployeeId + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

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

                DoQueryReadyItem();
                DoQueryNonItem();
                DoFilData(dataGridView2);
                DoFilData(dataGridView3);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                FrmMdiMain.Database.RollbackTransaction();
            }
        }

        private void btnCancer_Click(object sender, EventArgs e)
        {
            try
            {
                //chkReadyIsSaveAll.Checked则管理所有的（包括rowfilter过滤掉的）数据，否则只管理界面上显示的数据
                DataTable tb = chkReadyIsSaveAll.Checked ? (DataTable)dataGridView2.DataSource : ((DataTable)dataGridView2.DataSource).DefaultView.ToTable();

                if (MessageBox.Show("确认进行当前操作吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                FrmMdiMain.Database.BeginTransaction();
                int iReturn = -1;
                string id = "";

                //删除 
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //删除tb中未选中的项目
                    if (tb.Rows[i]["ISCHECK"].ToString() == "false")
                    {
                        DataRow dr = tb.Rows[i];
                        string sflb = dr["ITEM_SFLB"].ToString();
                        string xmid = dr["ITEM_CODE"].ToString();
                        string strSql = "update jc_gf_sflbmx set del_bit=1 where sflb='" + sflb + "' and xmly=2 and xmid='" + xmid + "'";
                        iReturn = FrmMdiMain.Database.DoCommand(strSql);
                    }
                }

                FrmMdiMain.Database.CommitTransaction();

                DoQueryReadyItem();
                DoQueryNonItem();
                DoDataFil_Sflb();
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                FrmMdiMain.Database.RollbackTransaction();
            }
        }

        void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                System.Windows.Forms.DataGridViewCheckBoxCell chk = ((System.Windows.Forms.DataGridViewCheckBoxCell)(dataGridView3.Rows[e.RowIndex].Cells["CHECK"]));

                if (((System.Windows.Forms.DataGridViewCell)(chk)).State == DataGridViewElementStates.None || ((System.Windows.Forms.DataGridViewCell)(chk)).State == DataGridViewElementStates.Selected)
                {
                    dataGridView3.Rows[e.RowIndex].Cells["CHECK"].Value = dataGridView3.Rows[e.RowIndex].Cells["CHECK"].Value.ToString().Equals("true") ? "false" : "true";
                    (dataGridView3.DataSource as DataTable).AcceptChanges();
                    dataGridView3.Rows[e.RowIndex].Selected = true;
                }
            }
            catch { }
        }

        void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                System.Windows.Forms.DataGridViewCheckBoxCell chk = ((System.Windows.Forms.DataGridViewCheckBoxCell)(dataGridView2.Rows[e.RowIndex].Cells["ISCHECK"]));

                if (((System.Windows.Forms.DataGridViewCell)(chk)).State == DataGridViewElementStates.None || ((System.Windows.Forms.DataGridViewCell)(chk)).State == DataGridViewElementStates.Selected)
                {
                    dataGridView2.Rows[e.RowIndex].Cells["ISCHECK"].Value = dataGridView2.Rows[e.RowIndex].Cells["ISCHECK"].Value.ToString().Equals("true") ? "false" : "true";
                    (dataGridView2.DataSource as DataTable).AcceptChanges();
                    dataGridView2.Rows[e.RowIndex].Selected = true;
                }
            }
            catch { }
        }

    }
}