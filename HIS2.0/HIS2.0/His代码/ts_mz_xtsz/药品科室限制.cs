using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;

namespace ts_mz_xtsz
{
    public partial class Frmypksxz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frmypksxz(MenuTag menuTag, string chineseName, Form mdiParent)
        {

            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Frmypksxz_Load(object sender, EventArgs e)
        {

            SelectYp();

            string ssql = @"select NAME 科室名称,DEPT_ID 科室ID,PY_CODE 拼音码,WB_CODE 五笔码 
    from JC_DEPT_PROPERTY where  DELETED=0 and  ZY_FLAG=1 or MZ_FLAG=1 ";
            DataTable tbb = InstanceForm.BDatabase.GetDataTable(ssql);
            dataGridView2.DataSource = tbb;


        }

        private void SelectYp()
        {
            string sql = @"select yppm 品名,ypspmbz 备注,ypgg 规格,s_ypdw 单位,s_sccj 厂家,
pfj 批发价,lsj 零售价,b.djsj 登记时间,a.pym 拼音码,a.wbm 五笔码,
 a.ggid,cjid from yp_ypggd a inner join yp_ypcjd b on a.ggid=b.ggid 
                  left join yp_tlfl c on a.tlfl=c.code where a.ggid>0 and b.BDELETE=0 order by YPPM";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            dataGridView1.DataSource = tb;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cjid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CJID"].Value);
            string sql = "select DEPT_ID from JC_YP_DEPT where CJID=" + cjid;

            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                int deptid = Convert.ToInt32(dataGridView2.Rows[i].Cells["科室ID"].Value);
                DataRow[] arr = tb.Select("dept_id=" + deptid + "");
                if (arr.Length > 0)
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                else
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int deptid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["科室ID"].Value);
            int cjid = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["CJID"].Value);
            string sql = "select count(*) from  jc_yp_dept where dept_id=" + deptid + " and cjid=" + cjid + " ";

            if (Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sql)) > 0)
            {
                sql = "delete from jc_yp_dept where dept_id=" + deptid + " and cjid=" + cjid + " ";
                if (Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sql)) == 0)
                {
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            else
            {
                sql = "insert into jc_yp_dept values (" + deptid + "," + cjid + ") ";
                if (Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sql)) == 0)
                {
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void txtypmc_TextChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            tb.DefaultView.RowFilter = "拼音码 like '%" + txtypmc.Text.Trim() + "%' or 五笔码 like '%" + txtypmc.Text.Trim() + "%'";
        }

        private void txtks_TextChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView2.DataSource;
            tb.DefaultView.RowFilter = "拼音码 like '%" + txtks.Text.Trim() + "%' or 五笔码 like '%" + txtks.Text.Trim() + "%'";
        }
    }
}