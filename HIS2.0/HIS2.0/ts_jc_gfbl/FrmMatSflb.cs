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
    public partial class FrmMatSflb : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;

        public FrmMatSflb()
        {
            InitializeComponent();
            InitInfo();

            this.dataGridView1.AutoGenerateColumns = false;
        }

        public FrmMatSflb(string chineseName, Form mdiParent)
        {
            InitializeComponent();
            InitInfo();

            this._chineseName = chineseName;
            this._mdiParent = mdiParent;

            this.dataGridView1.AutoGenerateColumns = false;
        }

        public void InitInfo()
        {
            this.Check.ReadOnly = true;

            this.Load += new EventHandler(FrmMatSflb_Load);


            btnClose.Click += new EventHandler(delegate(object sender, EventArgs args)
            {
                this.Close();
            });

            btnQuery.Click += new EventHandler(btnQuery_Click);

            btnSave.Click += new EventHandler(btnSave_Click);

            dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);

            dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);

        }

        void FrmMatSflb_Load(object sender, EventArgs e)
        {
            try
            {
                DoBindDSflb();
            }
            catch { }
        }

        private void DoBindDSflb()
        {
            try
            {
                DataTable dt = DoQueryDSflb();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch { }
        }

        private void DoBindSflb(string sfdlb)
        {
            try
            {
                DataTable dt = DoQuerySflb(sfdlb);
                if (dt != null)
                {
                    this.dataGridView2.DataSource = dt;
                    (this.dataGridView2.DataSource as DataTable).AcceptChanges();
                }
            }
            catch { }
        }

        private DataTable DoQueryDSflb(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select sfdlb,name,xe from jc_gf_dsflb where del_bit=0 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQuerySflb(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select case isnull(t2.sflb,-1) when -1 then 'false' else 'true' end as [CHECK] ,
		                                            t1.sflb,name,wbm,pym,
		                                            case when EXISTS(select 1 from jc_gf_ppdsflb  t3 where t1.sflb=t3.sflb and t3.del_bit=0) then '√' else '×' end as ISMATCH  
                                                    from jc_gf_sflb t1 
                                                    left join jc_gf_ppdsflb t2 on t1.sflb=t2.sflb and t2.sfdlb='{0}' and t2.del_bit=0 
                                                 where t1.del_bit=0", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        #region"Event"

        void btnQuery_Click(object sender, EventArgs e)
        {
            DoBindDSflb();
            dataGridView1_CurrentCellChanged(null, null);
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource == null || (dataGridView1.DataSource as DataTable).Rows.Count <= 0)
                    return;

                if (dataGridView2.DataSource == null || (dataGridView2.DataSource as DataTable).Rows.Count <= 0)
                    return;

                DataGridViewRow dgvr = dataGridView1.CurrentRow;

                DataTable dt = dataGridView2.DataSource as DataTable;

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CHECK"].ToString().Trim().ToUpper().Equals("TRUE"))
                    {
                        if (dr["ISMATCH"].ToString().Trim().ToUpper().Equals("√"))
                        {
                            MessageBox.Show(dr["name"].ToString() + " 已经匹配，请取消该收费类别匹配后再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                if (MessageBox.Show("确认进行操作吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;

                FrmMdiMain.Database.BeginTransaction();

                string strSfdlb = dgvr.Cells["sfdlb"].Value.ToString().Trim();
                string empId=InstanceForm._currentUser.EmployeeId.ToString();
                DateTime date=DateManager.ServerDateTimeByDBType(InstanceForm._database);
                string strSql = string.Format("update jc_gf_ppdsflb set del_bit=1,Mod_man='{1}',Mod_time='{2}' where sfdlb='{0}'", strSfdlb, empId, date);
                FrmMdiMain.Database.DoCommand(strSql);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CHECK"].ToString().Trim().ToUpper().Equals("TRUE"))
                    {
                        //是否已经匹配过
                        string valideSql = string.Format("select count(1) as NUM from jc_gf_ppdsflb where sflb='{0}' and del_bit=0", dr["sflb"].ToString().Trim());

                        int iNumCount = int.Parse(FrmMdiMain.Database.GetDataResult(valideSql).ToString());
                        if (iNumCount >= 1)
                        {
                            FrmMdiMain.Database.RollbackTransaction();
                            MessageBox.Show(dr["name"].ToString() + " 已经匹配，请取消该收费类别匹配后再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        } 
                        
                        //
                        valideSql = string.Format("select count(1) as NUM from jc_gf_ppdsflb where sflb='{0}' and sfdlb='{1}' and del_bit=1", dr["sflb"].ToString().Trim(), strSfdlb);

                         iNumCount = int.Parse(FrmMdiMain.Database.GetDataResult(valideSql).ToString());

                        if (iNumCount == 0)
                        {
                            strSql = string.Format("insert into jc_gf_ppdsflb(sfdlb,sflb,Opr_man,Opr_time,del_bit) values ('{0}','{1}','{2}','{3}','{4}')", strSfdlb, dr["sflb"].ToString().Trim(), empId, date,"0");
                            FrmMdiMain.Database.DoCommand(strSql);
                        }
                        else if (iNumCount == 1)
                        {
                            strSql = string.Format("update jc_gf_ppdsflb set del_bit=0,Mod_man='{2}',Mod_time='{3}' where sflb='{0}' and sfdlb='{1}' and del_bit=1", dr["sflb"].ToString().Trim(), strSfdlb, empId, date);
                            FrmMdiMain.Database.DoCommand(strSql);
                        }
                    }
                }

                FrmMdiMain.Database.CommitTransaction();
                //DoQueryReadyItem(ybid, dataGridView2.Rows[0].Cells["sflb_code"].Value.ToString());
                DoBindDSflb();
                DoGetFocus(strSfdlb);

                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                FrmMdiMain.Database.RollbackTransaction();
            }
        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && (dataGridView1.DataSource as DataTable).Rows.Count > 0)
            {
                string strSfdlb = dataGridView1.CurrentRow.Cells["sfdlb"].ToString().Trim();
                DoQuerySflb(strSfdlb);
            }
        }

        void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                System.Windows.Forms.DataGridViewCheckBoxCell chk = ((System.Windows.Forms.DataGridViewCheckBoxCell)(dataGridView2.Rows[e.RowIndex].Cells["CHECK"]));

                if (((System.Windows.Forms.DataGridViewCell)(chk)).State == DataGridViewElementStates.None || ((System.Windows.Forms.DataGridViewCell)(chk)).State == DataGridViewElementStates.Selected)
                {
                    dataGridView2.Rows[e.RowIndex].Cells["CHECK"].Value = dataGridView2.Rows[e.RowIndex].Cells["CHECK"].Value.ToString().Equals("true") ? "false" : "true";
                    (dataGridView2.DataSource as DataTable).AcceptChanges();
                    dataGridView2.Rows[e.RowIndex].Selected = true;
                }
            }
            catch { }
        }

        #endregion

        private void DoGetFocus(string id)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["sfdlb"].Value.ToString().Equals(id))
                {
                    dr.Selected = true;
                }
                else
                {
                    dr.Selected = false;
                }
            }
        }
    }
}