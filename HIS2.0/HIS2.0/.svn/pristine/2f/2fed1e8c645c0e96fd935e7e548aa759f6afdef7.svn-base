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
    
    public partial class FrmItem : Form
    {

        #region
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string lx="";
        
        DataTable tbOld;
        DataTable tbNow;
        #endregion

        #region
        public FrmItem(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
           
            this.Text = chineseName;

        }
        #endregion

        #region
        private void FrmItem_Load(object sender, EventArgs e)
        {
            this.cmb_ItemType.Text = "项目";
            this.WindowState = FormWindowState.Maximized;

            ItemLoad();

            string ssql = "select id,mc from yp_yplx ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            DataRow row = tb.NewRow();

            row["id"] = "0";
            row["mc"] = "全部";
            tb.Rows.InsertAt(row, 0);

            tb.TableName = "tb";
            cmbyplx.DisplayMember = "mc";
            cmbyplx.ValueMember = "id";
            cmbyplx.DataSource = tb;
        }
        #endregion

        #region
        private void ItemLoad()
        {
            QueryItem(1);
            QueryItem(2);
        }
        #endregion

        #region 
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;

                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                long jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                int lxtag;
                if (lx == "项目")
                {
                    lxtag = 2;
                }
                else if (lx == "药品")
                {
                    lxtag = 1;
                }
                else
                {
                    MessageBox.Show("获取类型错误!");
                    return;
                }
                DataRow mRow;
                mRow = tb.Rows[nrow];
                if (nrow > tb.Rows.Count) return;
                string sql1 = "insert into MZYS_CYYPXM(jgbm,lx,xmid,btc,ysdm,djsj,cjid) values ('" + jgbm + "','" + lxtag + "','" + mRow["item_id"] + "','" + mRow["tcbz"] + "','" + InstanceForm.BCurrentUser.EmployeeId + "',getdate(),"+Convertor.IsNull(mRow["cjid"],"0")+")";
                InstanceForm.BDatabase.GetDataTable(sql1);
                ItemLoad();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView2.CurrentCell == null) return;
            DataTable tb = (DataTable)dataGridView2.DataSource;
            int nrow = dataGridView2.CurrentCell.RowIndex;
            long jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            int lxtag;
            if (lx == "项目")
            {
                lxtag = 2;
            }
            else if (lx == "药品")
            {
                lxtag = 1;
            }
            else
            {
                MessageBox.Show("获取类型错误!");
                return;
            }
            DataRow mRow;
            mRow = tb.Rows[nrow];
            if (nrow > tb.Rows.Count) return;
            string sql1 = "delete from mzys_cyypxm where xmid='" + mRow["item_id"] + "' and lx='" + lxtag + "'  and btc='" + mRow["tcbz"] + "' and ysdm='" + InstanceForm.BCurrentUser.EmployeeId + "'";
            int ii= InstanceForm.BDatabase.DoCommand(sql1);
            ItemLoad();
        }
        #endregion

        #region
        private void cmb_ItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ItemLoad();

                if (cmb_ItemType.Text == "药品")
                {
                    lblyplx.Visible = true;
                    cmbyplx.Visible = true;
                }
                else
                {
                    lblyplx.Visible = false;
                    cmbyplx.Visible = false;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region
        private void txt_OldQuery_Click(object sender, EventArgs e)
        {
            txt_OldQuery.Text = "";
        }

        private void txt_NowQuery_Click(object sender, EventArgs e)
        {
            txt_NowQuery.Text = "";
        }
        #endregion

        #region
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Flag">1:原有项目,2:现有项目</param>
        public void QueryItem(int Flag)
        {
            string sql1, sql2;
           
            lx = cmb_ItemType.Text.Trim();
            if (Flag == 1)//原有项目
            {
                if (lx == "项目")
                {
                    sql1 = @"select a.order_id as item_id,rtrim(a.order_name) item_name,
                            rtrim(a.py_code) py_code,0 tcbz,cost_price as dj,'' cj,order_unit ypgg,0 cjid 
                             from jc_hoitemdiction a inner join jc_hoi_hdi b
                            on a.order_id=b.hoitem_id and tc_flag=0  and a.delete_bit=0
                             inner join jc_hsitemdiction c
                            on b.hditem_id=c.item_id and c.jgbm="+TrasenFrame.Forms.FrmMdiMain.Jgbm +@"and 
                            a.order_id not in (select xmid from mzys_cyypxm where lx=2 and BTC=0 and ysdm="+InstanceForm.BCurrentUser.EmployeeId+@" and jgbm="+TrasenFrame.Forms.FrmMdiMain.Jgbm+@" )
                            where (a.order_name like '%" + txt_OldQuery.Text + "%' or a.py_code like '%" + txt_OldQuery.Text + "%')" +
                            @"union all 
                            select a.order_id as item_id,'[套餐]'+rtrim(a.order_name) item_name,
                            rtrim(a.py_code) py_code,1 tcbz,price as dj,'' cj,item_unit ypgg,0 cjid 
                             from jc_hoitemdiction a inner join jc_hoi_hdi b
                            on a.order_id=b.hoitem_id and tc_flag=1  and a.delete_bit=0
                             inner join jc_tc c
                            on b.tcid=c.item_id  and c.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + @"and 
                            a.order_id not in (select xmid from mzys_cyypxm where lx=2 and BTC=1 and ysdm=" + InstanceForm.BCurrentUser.EmployeeId + @" and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + @")
                           where (a.order_name like '%" + txt_OldQuery.Text + "%' or a.py_code like '%" + txt_OldQuery.Text + "%')";
                }
                else
                {
                    sql1 = @"select a.ggid as item_id,a.yppm as item_name,a.pym as py_code,'0' as tcbz,lsj as dj,s_sccj cj, ypgg,cjid 
                                from yp_ypggd a inner join yp_ypcjd b on a.ggid=b.ggid  
                                where b.bdelete=0 and b.ggid not in (select xmid from mzys_cyypxm where lx=1 and ysdm=" + InstanceForm.BCurrentUser.EmployeeId + @" and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + @" ) and
                            a.ggid in(select ggid from yp_ypbm where pym like '%" + txt_OldQuery.Text.Trim() + "%'  or ypbm like '%" + txt_OldQuery.Text.Trim() + "%')";
                    if (Convertor.IsNull(cmbyplx.SelectedValue, "0") != "0")
                        sql1 = sql1 + " and yplx= " + Convertor.IsNull(cmbyplx.SelectedValue, "0")+"" ;
                }
                tbOld = InstanceForm.BDatabase.GetDataTable(sql1);
                dataGridView1.DataSource = tbOld;
            }
            if (Flag == 2)//现有项目
            {
                if (lx == "项目")
                {
                    sql2 = @"select a.order_id as item_id,rtrim(a.order_name) item_name,
                            rtrim(a.py_code) py_code,0 tcbz,cost_price as dj,'' cj,order_unit ypgg,0 cjid 
                             from jc_hoitemdiction a inner join jc_hoi_hdi b
                            on a.order_id=b.hoitem_id and tc_flag=0  and a.delete_bit=0
                             inner join jc_hsitemdiction c
                            on b.hditem_id=c.item_id  and c.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + @" and  
                            a.order_id  in (select xmid from mzys_cyypxm where lx=2 and BTC=0 and ysdm=" + InstanceForm.BCurrentUser.EmployeeId + @" and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + @")
                            where (a.order_name like '%" + txt_NowQuery.Text + "%' or a.py_code like '%" + txt_NowQuery.Text + "%')" +
                            @"union all 
                            select a.order_id as item_id,'[套餐]'+rtrim(a.order_name) item_name,
                            rtrim(a.py_code) py_code,1 tcbz,price as dj,'' cj,item_unit ypgg,0 cjid 
                             from jc_hoitemdiction a inner join jc_hoi_hdi b
                            on a.order_id=b.hoitem_id and tc_flag=1  and a.delete_bit=0
                             inner join jc_tc c
                            on b.tcid=c.item_id and c.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + @"and  
                            a.order_id  in (select xmid from mzys_cyypxm where lx=2 and BTC=1 and ysdm=" + InstanceForm.BCurrentUser.EmployeeId + @" and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + @")
                           where (a.order_name like '%" + txt_NowQuery.Text + "%' or a.py_code like '%" + txt_NowQuery.Text + "%')";
                }
                else
                {
                    sql2 = @"select b.ggid as item_id,yppm as item_name,b.pym as py_code,'0' as tcbz,lsj as dj,s_sccj cj, ypgg,a.cjid 
                        from mzys_cyypxm a inner  join yp_ypggd b on a.xmid=b.ggid and lx=1 left join yp_ypcjd c 
                         on a.cjid=c.cjid and c.bdelete=0 
                        where  a.ysdm=" + InstanceForm.BCurrentUser.EmployeeId + @" and a.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm +@" and b.ggid in(select ggid from yp_ypbm where pym like '%"+txt_NowQuery.Text.Trim()+"%' or ypbm like '%"+txt_NowQuery.Text.Trim()+"%' )";

                    if (Convertor.IsNull(cmbyplx.SelectedValue, "0") != "0")
                        sql2 = sql2 + " and yplx= " + Convertor.IsNull(cmbyplx.SelectedValue, "0") + "";
                }
                tbNow = InstanceForm.BDatabase.GetDataTable(sql2);
                dataGridView2.DataSource = tbNow;
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

        private void dataGridView2_DockChanged(object sender, EventArgs e)
        {

        }

        private void cmbyplx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemLoad();
        }

    
    }
}
