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

namespace ts_zygl_tjbb
{
    public partial class FrmZyzxkssrtj_mx : Form
    {
        public string _deptId;
        public DateTime _dtp1;
        public DateTime _dtp2;
        public string _tjXm;
        public string _tjKsLx;
        public string _tjRqFs;

        public FrmZyzxkssrtj_mx()
        {
            InitializeComponent();

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
        }

        private void FrmZyzxkssrtj_mx_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadTree(_deptId);

        }

        private void LoadTree(string deptId)
        {
            TreeDept.Nodes.Clear();
            TreeXm.Nodes.Clear();
            string sSql = "";
            if (deptId != "0")
            {
                sSql = " SELECT DEPT_ID,NAME FROM JC_DEPT_PROPERTY WHERE DEPT_ID = '" + deptId + "'";
            }
            else
            {
                sSql = " SELECT 0 DEPT_ID,'未确认科室' NAME ";
            }
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sSql);
            TreeNode tnTopDept = new TreeNode();
            tnTopDept.Text = "所有科室";
            tnTopDept.Tag = 0;

            tnTopDept.Checked = true;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode tnDept = new TreeNode();
                tnDept.Text = Convertor.IsNull(tb.Rows[i]["NAME"], "");
                tnDept.Tag = Convertor.IsNull(tb.Rows[i]["DEPT_ID"], "");
                tnDept.Checked = true;
                tnTopDept.Nodes.Add(tnDept);
            }
            TreeDept.Nodes.Add(tnTopDept);
            TreeDept.ExpandAll();

            sSql = " SELECT * FROM JC_STAT_ITEM ORDER BY CODE ";
            DataTable tab = InstanceForm.BDatabase.GetDataTable(sSql);
            TreeNode tnTopXM = new TreeNode();
            tnTopXM.Text = "统计大项目分类";
            tnTopXM.Tag = 0;
            for (int i = 0; i <= tab.Rows.Count - 1; i++)
            {
                TreeNode tnTopXM_C = new TreeNode();
                tnTopXM_C.Text = Convertor.IsNull(tab.Rows[i]["ITEM_NAME"], "");
                tnTopXM_C.Tag = Convertor.IsNull(tab.Rows[i]["CODE"], "");
                tnTopXM.Nodes.Add(tnTopXM_C);
            }
            TreeXm.Nodes.Add(tnTopXM);
            TreeXm.ExpandAll();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btref_Click(object sender, EventArgs e)
        {
            string execdept = "";
            for (int i = 0; i <= TreeDept.Nodes[0].Nodes.Count - 1; i++)
            {
                if (TreeDept.Nodes[0].Nodes[i].Checked == true)
                    execdept = execdept + TreeDept.Nodes[0].Nodes[i].Tag + ",";
            }
            if (execdept != "")
                execdept = "(" + execdept.Substring(0, execdept.Length - 1) + ")";
            else
            {
                MessageBox.Show("请选择科室");
                return;
            }

            string tjdxm = "";
            for (int i = 0; i <= TreeXm.Nodes[0].Nodes.Count - 1; i++)
            {
                if (TreeXm.Nodes[0].Nodes[i].Checked == true)
                    tjdxm = tjdxm + "'" + TreeXm.Nodes[0].Nodes[i].Tag + "',";
            }
            if (tjdxm != "")
                tjdxm = "(" + tjdxm.Substring(0, tjdxm.Length - 1) + ")";

            int isMX = 1;
            if (tabControl1.SelectedIndex == 0)
                isMX = 0;


            ParameterEx[] parameters = new ParameterEx[9];

            parameters[0].Text = "@RQ1";
            parameters[0].Value = dtp1.Value.ToString();
            parameters[1].Text = "@RQ2";
            parameters[1].Value = dtp2.Value.ToString();
            parameters[2].Text = "@TYPE";
            parameters[2].Value = Convert.ToInt32(_tjXm);
            parameters[3].Text = "@DEPT_TYPE";
            parameters[3].Value = Convert.ToInt32(_tjKsLx);
            parameters[4].Text = "@TJ_TYPE";
            parameters[4].Value = Convert.ToInt32(_tjRqFs);
            parameters[5].Text = "@EXECDEPT_ID";
            parameters[5].Value = execdept;
            parameters[6].Text = "@HZ_MX";
            parameters[6].Value = isMX;
            parameters[7].Text = "@STAT_CODE";
            parameters[7].Value = tjdxm;
            parameters[8].Text = "@JGBM";
            parameters[8].Value = FrmMdiMain.Jgbm;
            DataSet dset = new DataSet();
            TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_ZY_TJ_ZXKSSRTJ_MX", parameters, dset, "sfmx", 30);

            AddRowtNo(dset.Tables[0]);
            AddRowtNo(dset.Tables[1]);

            decimal je = Convert.ToDecimal(Convertor.IsNull(dset.Tables[0].Compute("sum(金额)", ""), "0"));
            decimal je1 = Convert.ToDecimal(Convertor.IsNull(dset.Tables[1].Compute("sum(金额)", ""), "0"));

            DataRow row = dset.Tables[0].NewRow();
            row["序号"] = "合计";
            row["金额"] = je.ToString();
            dset.Tables[0].Rows.Add(row);

            DataRow row1 = dset.Tables[1].NewRow();
            row1["序号"] = "合计";
            row1["金额"] = je1.ToString();
            dset.Tables[1].Rows.Add(row1);


            dataGridView1.DataSource = dset.Tables[0];
            dataGridView3.DataSource = dset.Tables[1];
        }

        private void TreeDept_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                for (int i = 0; i <= e.Node.Nodes.Count - 1; i++)
                {
                    if (e.Node.Checked == true)
                        e.Node.Nodes[i].Checked = true;
                    else
                        e.Node.Nodes[i].Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TreeXm_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                for (int i = 0; i <= e.Node.Nodes.Count - 1; i++)
                {
                    if (e.Node.Checked == true)
                        e.Node.Nodes[i].Checked = true;
                    else
                        e.Node.Nodes[i].Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {

            string rq = "    日期:" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
            string swhere = rq;
            if (tabControl1.SelectedIndex == 0)
            {
                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + "住院执行科室收入统计明细(汇总信息)", swhere, true, true, false, false);
            }
            else
            {
                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView3, Constant.HospitalName + "住院执行科室收入统计明细(明细信息)", swhere, true, true, false, false);
            }
        }

    }
}