using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame;
using TrasenFrame.Forms;

namespace ts_fzyy_zd
{
    public partial class FrmFZYY_ZDWH : Form
    {
        bool _isys = false;
        public DataTable dt_yp_list;
        public DataTable dt_zd_list;
        public FrmFZYY_ZDWH()
        {
            InitializeComponent();
        }
        public FrmFZYY_ZDWH(string isys)
        {
            InitializeComponent();
            _isys =true;
        }

        private void FrmFZYY_ZDWH_Load(object sender, EventArgs e)
        {
            if (_isys)
            {
                //tabControl1.DeselectTab(tabPage1);

                tabControl1.TabPages[0].Hide();
            }
            dv_yp.AllowUserToAddRows = false;
            dv_yp.AllowUserToDeleteRows = false;
            this.dv_yp.AutoGenerateColumns = false;
            dv_zd.AllowUserToAddRows = false;
            dv_zd.AllowUserToDeleteRows = false;
            this.dv_zd.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.ReadOnly = true;
            this.dataGridView3.AutoGenerateColumns = false;
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AutoGenerateColumns = false;
            get_fzyy(dv_yp);
            get_fzyy(dataGridView1);
            get_zd_list();
            if (_isys)
            {
                //tabControl1.DeselectTab(tabPage1);

                //tabControl1.TabPages[0].Hide();

                //tabPage1.Hide();
                tabControl1.Controls.Remove(tabPage1);
            }
        }
        /// <summary>
        /// 获取辅助用药列表
        /// </summary>
        /// <param name="dv_yp"></param>
        /// <returns></returns>
        private void get_fzyy(DataGridView dv_yp)
        {
            DataTable dt = new DataTable();
            string strSql = string.Format(@"select lsj ,cjid ,PYM  ,S_YPJX ,S_YPPM ,S_SCCJ ,S_YPGG from VI_YP_YPCD a where a.BDELETE=0 and a.fzyy=1  and a.cjbdelete=0");
            dt = FrmMdiMain.Database.GetDataTable(strSql);
            dt_yp_list = dt.Copy();
            dv_yp.DataSource = dt;
        }
        /// <summary>
        /// 药品列表行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dv_yp_CurrentCellChanged(object sender, EventArgs e)
        {
            get_fzyy_zd(dv_zd);
        }
        /// <summary>
        /// 获取当前药品已匹配诊断
        /// </summary>
        /// <param name="dv_zd"></param>
        /// <returns></returns>
        private void get_fzyy_zd(DataGridView dv_zd)
        {
            if (dv_yp.CurrentCell == null)
            {
                return;
            }
            else
            {
                string mystr = dv_yp.CurrentRow.Cells["CJID"].Value.ToString();
                DataTable dt = new DataTable();
                try
                {
                    string strSql = string.Format(@"select b.DIAGNOSE,b.DIAG_CODE,b.DIAG_TYPE,a.ypid  from
                                                 jc_yp_fzyywh_new a 
                                                inner join tr_jc_fzyy_zd_new b on a.coding=b.DIAG_CODE  
                                                where  a.ypid='{0}'", mystr);
                    dt = FrmMdiMain.Database.GetDataTable(strSql);
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                        this.dv_zd.DataSource = dt;
                    //}


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            get_fzyy_zd(dv_zd);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmSearch FrmSearch = new FrmSearch();
            FrmSearch.ypid = dv_yp.CurrentRow.Cells["CJID"].Value.ToString();
            FrmSearch.Show();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {

            DataTable dtGrid = dv_zd.DataSource as DataTable;

            if (dtGrid == null || dtGrid.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("是否删除?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }

            if (!checkItemChecking())
            {
                MessageBox.Show("请勾选要删除的诊断信息");
                return;
            }
            try
            {
                FrmMdiMain.Database.BeginTransaction();
                for (int i = 0; i < dv_zd.RowCount; i++)
                {
                    int iReturn = 0;
                    int mod_man = FrmMdiMain.CurrentUser.EmployeeId;
                    DateTime mod_date = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                    string chk_value = dv_zd.Rows[i].Cells[0].EditedFormattedValue.ToString();
                    if (chk_value == "True")
                    {
                        #region
                        string strSql = string.Empty;
                        string coding = dv_zd.Rows[i].Cells["CODING"].Value.ToString().Trim();
                        string ypid = dv_zd.Rows[i].Cells["YPID"].Value.ToString().Trim();
                        int deletebit = 1;
                        Convertor.IsNull(dv_zd.Rows[i].Cells["CODING"].Value, "").ToString().Trim();
                        Convertor.IsNull(dv_zd.Rows[i].Cells["YPID"].Value, "").ToString().Trim();
                        #endregion
                        strSql = string.Format(@" delete  jc_yp_fzyywh_new where ypid ='{0}' and CODING='{1}' ",
                                         ypid, coding, deletebit, mod_man, mod_date);

                        iReturn = FrmMdiMain.Database.DoCommand(strSql);

                        if (iReturn != 1)
                        {
                            throw new Exception("删除失败");
                        }
                    }
                }
                FrmMdiMain.Database.CommitTransaction();
                MessageBox.Show("删除成功 ");

            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
            get_fzyy_zd(dv_zd);
        }
        /// <summary>
        /// 是否勾选诊断(删除时判断)
        /// </summary>
        /// <returns></returns>
        private bool checkItemChecking()
        {
            bool strFlag = false;
            for (int i = 0; i < dv_zd.RowCount; i++)
            {
                string chk_value = dv_zd.Rows[i].Cells[0].EditedFormattedValue.ToString();
                if (chk_value == "True")
                {
                    strFlag = true;
                }
            }
            return strFlag;
        }

        private void dv_yp_CurrentCellChanged_1(object sender, EventArgs e)
        {
            get_fzyy_zd(dv_zd);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            get_fzyy(dv_yp);
            DataTable dtBind = dv_yp.DataSource as DataTable;
            if (!string.IsNullOrEmpty(txtsearch.Text.Trim()))
            {
                dtBind.DefaultView.RowFilter = " PYM like '%" + txtsearch.Text.Trim() + "%'";
            }
            else
            {
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt_yp_list;
            DataTable dtBind = dataGridView1.DataSource as DataTable;
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                dtBind.DefaultView.RowFilter = " PYM like '%" + textBox1.Text.Trim() + "%'";
            }
            else
            {
                return;
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                return;
            }
            else
            {
                string mystr = dataGridView1.CurrentRow.Cells["CJID_yp"].Value.ToString();
                DataTable dt = new DataTable();
                try
                {
                    string strSql = string.Format(@"select b.DIAGNOSE,b.DIAG_CODE,b.DIAG_TYPE,a.ypid  from
                                                 jc_yp_fzyywh_new a 
                                                inner join tr_jc_fzyy_zd_new b on a.coding=b.DIAG_CODE  
                                                where  a.ypid='{0}'", mystr);
                    dt = FrmMdiMain.Database.GetDataTable(strSql);
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    this.dataGridView2.DataSource = dt;
                    //}


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }

        }

        private void get_zd_list()
        {
            DataTable dt = new DataTable();
            try
            {
                string strSql = string.Format("select distinct a.* from tr_jc_fzyy_zd_new a  inner  join  jc_yp_fzyywh_new b  on  a.DIAG_CODE=b.coding");
                dt = InstanceForm._database.GetDataTable(strSql);
                if (dt != null)
                {
                    this.dataGridView3.DataSource = dt;
                    dt_zd_list = dt;

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = dt_zd_list;
            DataTable dtBind = dataGridView3.DataSource as DataTable;
            if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                dtBind.DefaultView.RowFilter = " PY_SEARCH like '%" + textBox2.Text.Trim() + "%'";
            }
            else
            {
                return;
            }
        }

        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentCell == null)
            {
                dataGridView4.DataSource = null;
            }
            else
            {

                string mystr = dataGridView3.CurrentRow.Cells["DIAG_CODE"].Value.ToString();
                DataTable dt = new DataTable();
                try
                {
                    string strSql = string.Format(@"select lsj,CJID,S_YPJX,S_YPPM,S_SCCJ,S_YPGG,PYM from VI_YP_YPCD a
                                                    inner join jc_yp_fzyywh_new b on a.CJID=b.ypid 
                                                    inner join tr_jc_fzyy_zd_new c on b.coding=c.DIAG_CODE  where a.BDELETE=0 and b.coding='{0}'", mystr);
                    dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt != null)
                    {
                        this.dataGridView4.DataSource = dt;
                    }
                }
                catch { }
            }
        }


    }
}