using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using ts_mzys_class;

namespace ts_mzys_yjsqd
{
    public partial class Frmwt : Form
    {

        public string ddd;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable _jcItemTB;
        public struct Cf
        {
            public Guid  brxxid;
            public Guid  ghxxid;
            public Guid  jzid;
            public string brxm;
            public string xb;
            public string nl;
            public string gzdw;
            public string lxfs;
            public string tz;
            public string mzh;
            public Guid  yjsqid;
            public Guid  yzid;
        }
        public Cf Dqcf = new Cf();

        public Frmwt(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

           
        }

        private void Frmjcsqd_Load(object sender, EventArgs e)
        {
            try
            {
                SystemCfg cg = new SystemCfg(3014);
                string ssql = @"select 0 选择,order_name 内容,c.name 执行科室,exec_dept ,a.order_id yzid
                            from jc_hoitemdiction a,jc_hoi_dept b,jc_dept_property c  where a.order_id=b.order_id  
                            and b.exec_dept=c.dept_id and c.jgbm=" + _menuTag.Jgbm + " and a.order_id in " + cg.Config + "";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                this.dataGridView2.DataSource = tb;

                if (tb.Rows.Count == 1)
                    tb.Rows[0]["选择"] = "1";

                lblxm.Text = Dqcf.brxm;
                lblxb.Text = Dqcf.xb;
                lblnl.Text = Dqcf.nl;
                lblgzdw.Text = Dqcf.gzdw;
                lbllxdh.Text = Dqcf.lxfs;
                lbltz.Text = Dqcf.tz;
                lblmzh.Text = Dqcf.mzh;
            }

            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btOkJC_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)this.dataGridView2.DataSource;

                DataRow[] rows = tbmx.Select("选择=true");
                if (rows.Length == 0) { MessageBox.Show("请选择相应的项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    string err_text = "";
                    int err_code = -1;
                    string order_name = rows[i]["内容"].ToString();
                    long order_id = Convert.ToInt64(rows[i]["yzid"].ToString());
                    int zxks = Convert.ToInt32(rows[i]["exec_dept"]);
                    Guid NewYjsqid = Guid.Empty;
                    mzys_yjsq.Save(Guid.Empty, _menuTag.Jgbm, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 3, _sDate, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, order_name, 0, 0, "", 0, "","", "", zxks,"", "", 0,Guid.Empty, order_id,null, out NewYjsqid,
                        out err_code, out err_text, InstanceForm.BDatabase);
                    if (err_code != 0) throw new Exception(err_text);
                }
                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("申请发送成功");
                this.Close();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)dataGridView2.DataSource;
            if (tb == null) return;
            if (tb.Rows.Count == 0) return;
            if (dataGridView2.CurrentCell == null) return;
            int nrow = dataGridView2.CurrentCell.RowIndex;
            if (tb.Rows[nrow]["选择"].ToString() == "1")
                tb.Rows[nrow]["选择"] = "0";
            else
                tb.Rows[nrow]["选择"] = "1";
        }

    }
}