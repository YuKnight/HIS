using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_jc_gfbl
{
    public partial class FrmGflbMx : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmGflbMx frmmain = null;

        private DataTable _dtYblx = new DataTable();
        private DataTable _dtYbzlx = new DataTable();

        bool _isAdd = false;

        public FrmGflbMx()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;

            InitInfo();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                //DoQuery();
                _dtYblx = DoQueryYblx();
                _dtYbzlx = DoQueryYbzlx();

                DataTable dtYblx = _dtYblx.Copy();
                Addcmb(cmbYblx, dtYblx, "ID", "NAME");

                DataTable dtYbzlx = _dtYbzlx.Copy();
                Addcmb(cmbYbzlx, dtYbzlx, "CODE", "NAME");
            }
            catch { }
        }

        public void InitInfo()
        {
            this.Load += new EventHandler(FrmGflbMx_Load);
            btnYesAllSelect.Click += new EventHandler(btnYesAllSelect_Click);
            btnYesReverse.Click += new EventHandler(btnYesReverse_Click);

            cmbYblx.Enabled = false;
            chkYblx.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbYblx.Enabled = chkYblx.Checked;
                if (chkYblx.Checked)
                {
                    cmbYblx.Focus();
                    cmbYblx.SelectAll();
                }

                //过滤
                DoFilterData(cmbYblx, "yblx_name", chkYblx.Checked);
            });

            cmbYblx.SelectedIndexChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                DoFilterData(cmbYblx, "YBLX_NAME", chkYblx.Checked);
            });

            cmbYbzlx.Enabled = false;
            chkYbzlx.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbYbzlx.Enabled = chkYbzlx.Checked;
                if (chkYbzlx.Checked)
                {
                    cmbYbzlx.Focus();
                    cmbYbzlx.SelectAll();
                    cmbYbzlx_KeyPress(cmbYbzlx, new KeyPressEventArgs('\r'));
                }
                else
                {
                    DoFilterData(cmbYbzlx, "ybzlx_name", chkYbzlx.Checked);
                }
                //cmbYbzlx_KeyPress(cmbYbzlx, new KeyPressEventArgs(32));
            });

            dataGridView1.CurrentCellChanged+=new EventHandler(dataGridView1_CurrentCellChanged);

            dataGridView2.CurrentCellChanged += new EventHandler(dataGridView2_CurrentCellChanged);

            dataGridView3.CellClick+=new DataGridViewCellEventHandler(dataGridView3_CellClick);

            cmbYbzlx.KeyPress += new KeyPressEventHandler(cmbYbzlx_KeyPress);

            txtQuerySflb.TextChanged += new EventHandler(txtQuerySflb_TextChanged);
            txtQueryGf_Sflb.TextChanged += new EventHandler(txtQueryGf_Sflb_TextChanged);
            txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);

            cmbSflb_ld.SelectedIndexChanged += new EventHandler(cmbSflb_ld_SelectedIndexChanged);

            //btnQuery.Click += new EventHandler(btnQuery_Click);
            //btnAdd.Click += new EventHandler(btnAdd_Click);
            //btnClose.Click += new EventHandler(btnClose_Click);
            //btnSave.Click += new EventHandler(btnSave_Click);

            //dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            //dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            //dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);

            //txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);
        }

        void FrmGflbMx_Load(object sender, EventArgs e)
        {
            try
            {
                //txtName.Enabled = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = false;
            }
            catch { }

            try
            {
                //txtName.Enabled = false;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToDeleteRows = false;
                dataGridView2.ReadOnly = true;
                this.dataGridView2.AutoGenerateColumns = false;
            }
            catch { }

            try
            {
                //txtName.Enabled = false;
                this.CHECK.ReadOnly = true;
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.AllowUserToDeleteRows = false;
                dataGridView3.ReadOnly = true;
                this.dataGridView3.AutoGenerateColumns = false;
            }
            catch { }

            try
            {
                DataTable dtSflb =DoQueryData_Sflb();
                Addcmb(cmbSflb_ld, dtSflb, "sflb_code", "sflb_mc");
            }
            catch { }

            try
            {
                DoQueryDataSflb();

                DoQueryData();

            }
            catch { }
            cmbSflb_ld_SelectedIndexChanged(null, null);
        }

        private void DoQueryData()
        {
            try
            {
                DataTable dt = DoQueryData_Gflb();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch { }
        }

        private void DoQueryDataSflb()
        {
            try
            {
                DataTable dt = DoQueryData_Sflb();
                if (dt != null)
                {
                    this.dataGridView2.DataSource = dt;
                    (this.dataGridView2.DataSource as DataTable).AcceptChanges();

                }
            }
            catch { }
        }

        private void DoQueryReadyItem(string ybid, string sflb)
        {
            try
            {
                DataTable dt = DoQueryData_ReadyItem(ybid,sflb);
                if (dt != null)
                {
                    this.dataGridView3.DataSource = dt;
                    (this.dataGridView3.DataSource as DataTable).AcceptChanges();

                }
            }
            catch { }
        }

        private DataTable DoQueryData_Gflb(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select a.id,a.YBLXID,a.ybzlx,b.NAME as  yblx_name,c.NAME as ybzlx_name,d.name as  sflb_name,a.sflb,a.gfbl,a.bcbl,a.xj,a.memo 
                                                from jc_gf_bl a 
                                                inner join JC_YBLX b on a.YBLXID=b.ID and b.DELETE_BIT=0 
                                                inner join JC_YBZLX c on a.ybzlx=c.CODE and c.DELETE_BIT=0
                                                inner join 
                                                (
                                                    select ITEM_NAME as name,CODE as sflb,0 as del_bit  from jc_stat_item where CODE in (01,02,03)
                                                    union all
                                                    select name,sflb,del_bit from jc_gf_sflb 
                                                ) as d on a.sflb=d.sflb and d.del_bit=0
                                                where a.del_bit=0 order by a.YBLXID,a.ybzlx,a.sflb ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryData_Sflb(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select name as sflb_mc,sflb as sflb_code,2 as xmly_sflb from jc_gf_sflb where del_bit=0
                                                union all
                                                select ITEM_NAME as sflb_mc,CODE as sflb_code,1 as xmly_sflb from jc_stat_item where CODE in (01,02,03) ", args);
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
                string strSql = string.Format(@"select case when t.xmid=a.xmid and t.xmly=a.xmly  then 'true' else 'false' end as [CHECK],t.xmly,t.xmid,ISNULL(c.ITEM_NAME,d.S_YPPM) as xmmc,ISNULL(c.WB_CODE,d.WBM) as WBM,ISNULL(c.PY_CODE,d.PYM) as PYM
                                                from vi_jc_gf_sflbmx t 
                                                left join jc_gf_blmx a on t.xmid=a.xmid and t.xmly=a.xmly and a.ybbl_id='{0}' AND a.del_bit=0
                                                left join JC_HSITEMDICTION c on t.xmid=c.ITEM_ID and t.xmly=2 and c.DELETE_BIT=0
                                                left join VI_YP_YPCD d on t.xmid=d.CJID and t.xmly=1 and d.BDELETE=0
                                                where t.sflb='{1}' and t.del_bit=0 order by [CHECK] desc", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryYblx(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select * from JC_YBLX where DELETE_BIT=0 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryYbzlx(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select * from JC_YBZLX where DELETE_BIT=0 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        void btnYesAllSelect_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAll(1, dataGridView3);
            }
            catch { }
        }

        void btnYesReverse_Click(object sender, EventArgs e)
        {

            try
            {
                SelectAll(2, dataGridView3);
            }
            catch { }
        }

        void cmbYbzlx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                ComboBox cmbbs1 = sender as ComboBox;
                if (e.KeyChar == 13)
                {

                    if (cmbbs1.Text == "")
                    {
                        cmbbs1.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select  CODE,NAME from JC_YBZLX where DELETE_BIT=0";

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "CODE", "Name" },
                                                                                       new string[] { "编码", "名称" },
                                                                                       new string[] { "CODE", "Name" },
                                                                                       new int[] { 80, 150 });

                    frmSelectCard.sourceDataTable = InstanceForm._database.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs1;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs1.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs1.Text = "";
                        cmbbs1.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["CODE"]);
                        cmbbs1.Text = frmSelectCard.SelectDataRow["Name"].ToString();
                    }

                    DoFilterData(cmbbs1, "ybzlx_name", chkYbzlx.Checked);
                }
            }
            catch { }
        }

        void txtQuerySflb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!DoFilterData(dataGridView2, "sflb_mc", txtQuerySflb.Text.Trim()))
                {
                    DoQueryDataSflb();
                }
            }
            catch { }
        }

        void txtQueryGf_Sflb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!DoFilterData(dataGridView1, "sflb_name", txtQueryGf_Sflb.Text.Trim()))
                {
                    DoQueryData();
                }
            }
            catch { }
        }

        void txtQuery_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string fil = " xmmc like '%" + txtQuery.Text.Trim() + "%' or wbm like '%" + txtQuery.Text.Trim() + "%' or pym like '%" + txtQuery.Text.Trim() + "%'";
                if (!DoFilterData(dataGridView3, fil))
                {
                    if ((dataGridView1.DataSource as DataTable).Rows.Count <= 0)
                        return;

                    if ((dataGridView2.DataSource as DataTable).Rows.Count <= 0)
                        return;

                    DataGridViewRow dgrYb = dataGridView1.CurrentRow;
                    DataGridViewRow dgr = dataGridView2.CurrentRow;
                    string ybid = dgrYb.Cells["id"].Value.ToString();
                    string strSflb = dgr.Cells["sflb_code"].Value.ToString();
                    DoQueryReadyItem(ybid, strSflb);

                }
            }
            catch { }
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

                if (dataGridView3.Rows[e.RowIndex].Cells["CHECK"].Value.Equals("true"))
                {
                    //if ((dataGridView1.DataSource as DataTable).Rows.Count <= 0)
                    //{
                    //    return;
                    //}

                    //DataGridViewRow dgr = dataGridView1.CurrentRow;
                    //string ybid = dgr.Cells["id"].Value.ToString();
                    //string valideSql = string.Format("select * from jc_gf_blmx where xmid='{1}' and xmly='{2}' and ybbl_id<>'{0}' and del_bit=0", ybid, xmid, xmly);
                    
                    //DataTable dtValid = FrmMdiMain.Database.GetDataTable(valideSql);
                    //int iNumCount = int.Parse(dtValid.Rows[0]["NUM"].ToString());
                    //if (iNumCount > 0)
                    //{
                        
                    //}
                }
            }
            catch { }
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
                        myTb.Rows[i]["ISCHECK"] = myTb.Rows[i]["IS_CHECK"].ToString() == "true" ? "false" : "true";
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

        private void DoFilterData(ComboBox cmbFil, string strName, bool bFil)
        {
            try
            {
                if (bFil)
                {
                    DataTable dtBind = dataGridView1.DataSource as DataTable;

                    if (!string.IsNullOrEmpty(cmbFil.SelectedValue.ToString().Trim()))
                    {
                        dtBind.DefaultView.RowFilter = strName + "  like '%" + cmbFil.Text.Trim() + "%'";
                    }
                    else
                    {
                        DoQueryData();
                    }

                    cmbFil.Select();
                }
                else
                {
                    DataTable dtBind = dataGridView1.DataSource as DataTable;
                    dtBind.DefaultView.RowFilter = "";
                }
            }
            catch { }
        }

        private bool DoFilterData(DataGridView dgv, string strName, string strFil)
        {
            try
            {
                DataTable dtBind = dgv.DataSource as DataTable;

                if (!string.IsNullOrEmpty(strFil.Trim()))
                {
                    dtBind.DefaultView.RowFilter = strName + "  like '%" + strFil.Trim() + "%'";
                    return true;
                }
            }
            catch { }
            return false;
        }

        private bool DoFilterData(DataGridView dgv,  string strFil)
        {
            try
            {
                DataTable dtBind = dgv.DataSource as DataTable;

                if (!string.IsNullOrEmpty(strFil.Trim()))
                {
                    dtBind.DefaultView.RowFilter = strFil;
                    return true;
                }
            }
            catch { }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dataGridView1.DataSource as DataTable).Rows.Count <= 0)
                {
                    MessageBox.Show("请选择一条公费基础信息后再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataGridViewRow dgr = dataGridView1.CurrentRow;
                string ybid = dgr.Cells["id"].Value.ToString();

                DataTable tbAdd = chkIsSaveAll.Checked ? (DataTable)dataGridView3.DataSource : ((DataTable)dataGridView3.DataSource).DefaultView.ToTable();

                if (MessageBox.Show("确认进行当前操作吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                FrmMdiMain.Database.BeginTransaction();
                int iReturn = -1;
                string id = "";
                string user = InstanceForm._currentUser.EmployeeId.ToString();
                string oprTime = DateManager.ServerDateTimeByDBType(InstanceForm._database).ToString("yyyy-MM-dd HH:mm:ss");

                //逻辑删除 该公费类型下所有公费明细
                string strSql = string.Format("update jc_gf_blmx set del_bit=1,Del_man='{0}',Del_time='{1}' where ybbl_id='{2}' and del_bit=0", user, oprTime, ybid);
                iReturn = FrmMdiMain.Database.DoCommand(strSql);

                //新增 
                for (int i = 0; i < tbAdd.Rows.Count; i++)
                {
                    //add新增项目
                    if (tbAdd.Rows[i]["CHECK"].ToString() == "true")
                    {
                        DataRow dr = tbAdd.Rows[i];
                        string xmly = dr["xmly"].ToString();
                        string xmid = dr["xmid"].ToString();

                        //1、一个项目只归属一个收费类别    2、一个医保类型和医保子类型不能匹配同一收费类别两次  
                        ////相同的医嘱类型和医嘱子类型下的 其他公费是否存在该项目明细
                        //string valideSql = string.Format("select count(1) as NUM from jc_gf_blmx where xmid='{0}' and xmly='{1}' and del_bit=0", xmid, xmly);
                        //DataTable dtValid = FrmMdiMain.Database.GetDataTable(valideSql);
                        //if (dtValid != null && dtValid.Rows.Count > 0)
                        //{
                        //    //删除其他标识
                        //    strSql = string.Format("update jc_gf_blmx set del_bit=1,Del_man='{0}',Del_time='{1}' where xmid='{2}' and xmly='{3}' and del_bit=0", user, oprTime, xmid, xmly);
                        //    iReturn = FrmMdiMain.Database.DoCommand(strSql);
                        //}

                        //新增
                        string valideSql = string.Format("select count(1) as NUM from jc_gf_blmx where ybbl_id='{0}' and xmid='{1}' and xmly='{2}'", ybid, xmid, xmly);
                        //dtValid.Clear();
                        DataTable dtValid = FrmMdiMain.Database.GetDataTable(valideSql);
                        int iNumCount = int.Parse(dtValid.Rows[0]["NUM"].ToString());
                        if ( iNumCount> 1)
                        {
                            FrmMdiMain.Database.RollbackTransaction();
                            MessageBox.Show(dr["xmmc"].ToString() + "存在不合理数据，请联系管理员处理！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (iNumCount == 1)
                        {
                            //update
                            strSql = string.Format("update jc_gf_blmx set del_bit=0,Del_man='-1',Del_time='',Opr_man='{0}',Opr_time='{1}' where ybbl_id='{2}' and xmid='{3}' and xmly='{4}'", user, oprTime,ybid ,xmid, xmly);
                            iReturn = FrmMdiMain.Database.DoCommand(strSql);

                            if (iReturn <= 0)
                            {
                                FrmMdiMain.Database.RollbackTransaction();
                                MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else if (iNumCount == 0)
                        {
                            //Insert
                            id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                            string sql = "insert into jc_gf_blmx (ID,ybbl_id,xmly,xmid,del_bit,opr_man,opr_time) values ('" + id + "','" + ybid + "','" + xmly + "','" + xmid + "','" + 0 + "','" + user + "','" + oprTime + "')";
                            iReturn = FrmMdiMain.Database.DoCommand(sql);

                            if (iReturn <= 0)
                            {
                                FrmMdiMain.Database.RollbackTransaction();
                                MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }

                FrmMdiMain.Database.CommitTransaction();

                DoQueryReadyItem(ybid, dataGridView2.Rows[0].Cells["sflb_code"].Value.ToString());

                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                FrmMdiMain.Database.RollbackTransaction();
            }
        }

        void cmbSflb_ld_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBind = dataGridView2.DataSource as DataTable;

                if (dtBind != null)
                {
                    dtBind.DefaultView.RowFilter = "sflb_code ='" + cmbSflb_ld.SelectedValue.ToString() + "'";
                }
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

                cmbSflb_ld.SelectedValue = this.dataGridView1.CurrentRow.Cells["sflb"].Value;
            }
            catch { }

            try
            {

                if (dataGridView2.Rows.Count > 0)
                {
                    DataGridViewRow dgr = dataGridView2.Rows[0];

                    if (dgr == null)
                        return;

                    if ((dataGridView1.DataSource as DataTable).Rows.Count <= 0)
                        return;

                    DataGridViewRow dgrYb = dataGridView1.CurrentRow;
                    string ybid = dgrYb.Cells["id"].Value.ToString();


                    DoQueryReadyItem(ybid, dgr.Cells["sflb_code"].Value.ToString());
                }

            }
            catch { }
        }

        void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            //try
            //{

            //    if (dataGridView2.Rows.Count > 0)
            //    {
            //        DataGridViewRow dgr=dataGridView2.Rows[0];

            //        if (dgr == null)
            //            return;

            //        if ((dataGridView1.DataSource as DataTable).Rows.Count <= 0)
            //            return;

            //        DataGridViewRow dgrYb = dataGridView1.CurrentRow;
            //        string ybid = dgrYb.Cells["id"].Value.ToString();


            //        DoQueryReadyItem(ybid, dgr.Cells["sflb_code"].Value.ToString());
            //    }

            //}
            //catch { }
        }
    }
}