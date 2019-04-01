using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

/*
 * 作者：Kevin
 * 名称：儿童保健子科室收入统计
 * 日期：2014-06
 */


namespace ts_mz_tjbb
{
    public partial class Frmzkssrtjmx : Form
    {

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private Guid ghxxid = Guid.Empty;
        private Guid brxxid = Guid.Empty;

        public string fl_code = "";
        public string ksdm = "";
        public int kstype = 0;

        public Frmzkssrtjmx()
        {
            InitializeComponent();
        }

        public Frmzkssrtjmx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            dtpqrrq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpqrrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
        }

        private void Frmzkssrtjmx_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);

            AddTree(fl_code, ksdm);
        }

        public void btref_Click(object sender, EventArgs e)
        {
            try
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
                    MessageBox.Show("请选择科室", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



                ParameterEx[] parameters = new ParameterEx[9];
                parameters[0].Text = "@execdept";
                parameters[0].Value = execdept;

                parameters[1].Text = "@RQ1";
                parameters[1].Value = chksfrq.Checked == true ? dtp1.Value.ToString() : "";

                parameters[2].Text = "@RQ2";
                parameters[2].Value = chksfrq.Checked == true ? dtp2.Value.ToString() : "";


                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt64(cmbjgbm.SelectedValue);

                parameters[4].Text = "@qrrq1";
                parameters[4].Value = chkqfrq.Checked == true ? dtpqrrq1.Value.ToString() : "";

                parameters[5].Text = "@qrrq2";
                parameters[5].Value = chkqfrq.Checked == true ? dtpqrrq2.Value.ToString() : "";

                parameters[6].Text = "@tjdxm";
                parameters[6].Value = tjdxm;

                parameters[7].Text = "@zxr";
                parameters[7].Value = 0;

                parameters[8].Text = "@kstype";
                parameters[8].Value = kstype;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_rtzkssrtj_mx", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                Fun.AddRowtNo(dset.Tables[1]);
                Fun.AddRowtNo(dset.Tables[2]);
                Fun.AddRowtNo(dset.Tables[3]);

                decimal je = Convert.ToDecimal(Convertor.IsNull(dset.Tables[0].Compute("sum(金额)", ""), "0"));
                decimal je1 = Convert.ToDecimal(Convertor.IsNull(dset.Tables[1].Compute("sum(金额)", ""), "0"));
                decimal je2 = Convert.ToDecimal(Convertor.IsNull(dset.Tables[2].Compute("sum(金额)", ""), "0"));
                //add by zouchihua 2013-6-25 
                decimal je3 = Convert.ToDecimal(Convertor.IsNull(dset.Tables[3].Compute("sum(金额)", ""), "0"));

                DataRow row = dset.Tables[0].NewRow();
                row["序号"] = "合计";
                row["金额"] = je.ToString();
                dset.Tables[0].Rows.Add(row);

                DataRow row1 = dset.Tables[1].NewRow();
                row1["序号"] = "合计";
                row1["金额"] = je1.ToString();
                dset.Tables[1].Rows.Add(row1);

                DataRow row2 = dset.Tables[2].NewRow();
                row2["序号"] = "合计";
                row2["金额"] = je2.ToString();
                dset.Tables[2].Rows.Add(row2);


                DataRow row3 = dset.Tables[3].NewRow();
                row3["序号"] = "合计";
                row3["金额"] = je3.ToString();
                dset.Tables[3].Rows.Add(row3);


                dataGridView1.DataSource = dset.Tables[0];
                dataGridView2.DataSource = dset.Tables[2];
                dataGridView3.DataSource = dset.Tables[1];
                //add by zouchihua 2013-6-25 
                dataGridView4.DataSource = dset.Tables[3];



            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTree(string flocode, string ksdm)
        {

            TreeDept.Nodes.Clear();
            TreeXm.Nodes.Clear();

            string ssql = "";
            if (ksdm != "0")
            {
                ssql = "select dept_id,a.name ,b.name zdymc   from jc_dept_property a   left join (select * from jc_bb_ksmx a     " +
                       " inner join JC_BB_KSMC b on a.zdyksdm=b.code and b.fl_code='" + flocode +
                       "') b on a.dept_id=b.yyksdm    ";
                ssql = ssql + " where (case when b.code is null then a.dept_id else 999+b.pxxh end)='" + ksdm + "'"; //Modify By Zj 2012-08-08 存储过程里面是加PXXH现修改程序也加pxxh 原为code
            }
            else
            {
                ssql = "select 0 dept_id,'未确认科室' as name,'未确认科室' zdymc ";
            }

            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

            System.Windows.Forms.TreeNode tnTopDept = new System.Windows.Forms.TreeNode();
            tnTopDept.Text = Convertor.IsNull(tb.Rows[0]["zdymc"], "");
            tnTopDept.Tag = 0;

            tnTopDept.Checked = true;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                System.Windows.Forms.TreeNode tnDept = new System.Windows.Forms.TreeNode();
                tnDept.Text = Convertor.IsNull(tb.Rows[i]["name"], "");
                tnDept.Tag = Convertor.IsNull(tb.Rows[i]["dept_id"], "");
                tnDept.Checked = true;
                tnTopDept.Nodes.Add(tnDept);
            }
            TreeDept.Nodes.Add(tnTopDept);
            TreeDept.ExpandAll();



            ssql = "select * from jc_stat_item order by code";
            DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);

            System.Windows.Forms.TreeNode tnTopXM = new System.Windows.Forms.TreeNode();
            tnTopXM.Text = "统计大项目分类";
            tnTopXM.Tag = 0;
            for (int i = 0; i <= tab.Rows.Count - 1; i++)
            {
                System.Windows.Forms.TreeNode tnTopXM_C = new System.Windows.Forms.TreeNode();
                tnTopXM_C.Text = Convertor.IsNull(tab.Rows[i]["item_name"], "");
                tnTopXM_C.Tag = Convertor.IsNull(tab.Rows[i]["code"], "");
                tnTopXM.Nodes.Add(tnTopXM_C);
            }
            TreeXm.Nodes.Add(tnTopXM);
            TreeXm.ExpandAll();



        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {

                DataTable tb = null;
                string ss = "";
                if (tabControl1.SelectedTab == tabPage1)
                {
                    tb = (DataTable)this.dataGridView1.DataSource;
                    ss = "执行科室项目汇总表(" + TreeDept.Nodes[0].Text + ")";
                }
                if (tabControl1.SelectedTab == tabPage2)
                {
                    tb = (DataTable)this.dataGridView2.DataSource;
                    ss = "执行科室项目汇总表(" + TreeDept.Nodes[0].Text + ")";
                }
                if (tabControl1.SelectedTab == tabPage3)
                {
                    tb = (DataTable)this.dataGridView3.DataSource;
                    ss = "执行科室项目明细表(" + TreeDept.Nodes[0].Text + ")";
                }


                // 创建Excel对象                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count + 1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    colCount = colCount + 1;
                }


                //查询条件
                string swhere = "";
                if (chksfrq.Checked == true) swhere = " 记费日期从:" + dtp1.Value.ToString() + "　到 " + dtp2.Value.ToString();
                if (chkqfrq.Checked == true) swhere = " 确费日期从:" + dtpqrrq1.Value.ToString() + "　到 " + dtpqrrq2.Value.ToString();

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = ss;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 设置条件
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;
                //xlApp.ActiveCell.FormulaR1C1 = swhere;
                //xlApp.ActiveCell.Font.Size = 20;
                //xlApp.ActiveCell.Font.Bold = true;
                //xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    objData[1, colIndex++] = tb.Columns[i].Caption;
                }
                // 获取数据
                objData[0, 0] = swhere;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        //if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width>0)
                        //{
                        if (tb.Columns[j].Caption == "门诊号")
                            objData[i + 2, colIndex++] = "'" + tb.Rows[i][j].ToString();
                        else
                            objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                        //}
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
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
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chksfrq_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = chksfrq.Checked == true ? true : false;
            dtp2.Enabled = chksfrq.Checked == true ? true : false;
        }

        private void chkqfrq_CheckedChanged(object sender, EventArgs e)
        {
            dtpqrrq1.Enabled = chkqfrq.Checked == true ? true : false;
            dtpqrrq2.Enabled = chkqfrq.Checked == true ? true : false;
        }

        private void Frmzkssrtjmx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Cursor.Current = PubStaticFun.WaitCursor();
                btref_Click(sender, e);
                Cursor.Current = Cursors.Default;
            }
        }
    }
}