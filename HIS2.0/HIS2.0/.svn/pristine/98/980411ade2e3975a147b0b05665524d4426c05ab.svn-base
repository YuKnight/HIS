using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_mz_class;

namespace ts_mz_xtsz
{
    
    public partial class FrmLgXmsz : Form
    {

        #region  变量声明
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string lx="";
        
        DataTable tbOld;
        DataTable tbNow;
        #endregion

        #region 构造函数
        public FrmLgXmsz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
           
            this.Text = chineseName;

        }
        #endregion

        #region Load事件
        private void FrmItem_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ItemLoad();
        }
        #endregion

        #region
        private void ItemLoad()
        {
            QueryItem(1);
            QueryItem(2);
        }
        #endregion

        #region 网格双击事件
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;

                DataTable tb = (DataTable)dataGridView1.DataSource;
                DataTable tb2 = (DataTable)dataGridView2.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                long jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                if (nrow >= tb.Rows.Count) return;

                DataRow mRow;
                mRow = tb.Rows[nrow];

                long xmid = Convert.ToInt64(mRow["item_id"]);
                int tcbz = Convert.ToInt32(mRow["tcbz"]);
                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                try
                {
                    string sql1 = "insert into MZHS_LGFXM(jgbm,xmid,tcbz,djsj,djy) values ('" + jgbm + "'," + xmid + "," + tcbz + ",'" + _sDate + "'," + InstanceForm.BCurrentUser.EmployeeId + ")";
                    InstanceForm.BDatabase.GetDataTable(sql1);

                    tb2.ImportRow(mRow);
                    tb.Rows.RemoveAt(nrow);
                    
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    ItemLoad();
                }
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView2.CurrentCell == null) return;

                DataTable tb = (DataTable)dataGridView2.DataSource;
                DataTable tb2 = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView2.CurrentCell.RowIndex;
                long jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                if (nrow >= tb.Rows.Count) return;

                DataRow mRow;
                mRow = tb.Rows[nrow];

                long xmid = Convert.ToInt64(mRow["item_id"]);
                int tcbz = Convert.ToInt32(mRow["tcbz"]);
                //string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                try
                {
                    string sql1 = "delete MZHS_LGFXM where xmid=" + xmid + " and tcbz=" + tcbz + "";
                    InstanceForm.BDatabase.GetDataTable(sql1);

                    tb2.ImportRow(mRow);
                    tb.Rows.RemoveAt(nrow);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ItemLoad();
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        #region 获取数据的过程
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Flag">1:原有项目,2:现有项目</param>
        public void QueryItem(int Flag)
        {
            string sql;

            if (Flag == 1)//原有项目
            {
                sql = @"select  rtrim(item_name) 项目名称,rtrim(item_unit) 单位,cost_price 单价,py_code 拼音码,0 tcbz,item_id
                            from jc_hsitemdiction where delete_bit=0  and jgbm="+InstanceForm._menuTag.Jgbm+
                            @" and item_id not in(select xmid from MZHS_LGFXM where tcbz=0)
                            and (item_name like '%" + txt_OldQuery.Text + "%' or py_code like '%" + txt_OldQuery.Text + "%')" +
                       @"union all 
                            select  '[套餐] '+rtrim(item_name) 项目名称,rtrim(item_unit) 单位,price 单价,py_code 拼音码,1 tcbz,item_id 
                            from jc_tc  where delete_bit=0  and jgbm="+InstanceForm._menuTag.Jgbm+
                           @" and item_id not in(select item_id from MZHS_LGFXM where tcbz=1)
                            and (item_name like '%" + txt_OldQuery.Text + "%' or py_code like '%" + txt_OldQuery.Text + "%')";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                dataGridView1.DataSource = tb;
            }
            else //现有项目
            {
                sql = @"select  rtrim(item_name) 项目名称,rtrim(item_unit) 单位,cost_price 单价,py_code 拼音码,0 tcbz,item_id
                            from jc_hsitemdiction where delete_bit=0   and jgbm="+InstanceForm._menuTag.Jgbm+
                           @" and item_id  in(select xmid from MZHS_LGFXM where tcbz=0)
                            and (item_name like '%" + txt_NowQuery.Text + "%' or py_code like '%" + txt_NowQuery.Text + "%')" +
                           @"union all 
                            select  '[套餐] '+ rtrim(item_name) 项目名称,rtrim(item_unit) 单位,price 单价,py_code 拼音码,1 tcbz,item_id 
                            from jc_tc  where delete_bit=0  and jgbm="+InstanceForm._menuTag.Jgbm+
                           @" and item_id  in(select xmid from MZHS_LGFXM where tcbz=1)
                            and (item_name like '%" + txt_NowQuery.Text + "%' or py_code like '%" + txt_NowQuery.Text + "%')";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                    dataGridView2.DataSource = tb;
            }


        }
        #endregion

        #region
        private void btn_Oldquery_Click(object sender, EventArgs e)
        {
            try
            {
                QueryItem(1);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_NowQuery_Click(object sender, EventArgs e)
        {
            try
            {
                QueryItem(2);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void txt_OldQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                btn_Oldquery_Click(sender, null);
        }

        private void txt_NowQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                btn_NowQuery_Click(sender, null);
        }

    
    }
}
