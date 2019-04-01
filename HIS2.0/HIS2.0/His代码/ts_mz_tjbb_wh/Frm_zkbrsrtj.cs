using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
//using GoldPrinter;
using TrasenFrame.Classes;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class Frm_zkbrsrtj : Form
    {
        int speci = 0;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_zkbrsrtj()
        {
            InitializeComponent();
        }

        public Frm_zkbrsrtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            label1.Text = _chineseName;
            groupBox1.Visible = true;
            Init();
        }

        private void FrmZkbrsrtj_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            try
            {
                //转入转出科室
                DataTable tb = InstanceForm.BDatabase.GetDataTable(@"SELECT DEPT_ID AS ITEMCODE,NAME AS ITEMNAME FROM JC_DEPT_PROPERTY WHERE ZY_FLAG = 1 and jgbm=" + FrmMdiMain.Jgbm
                               + " AND DELETED = 0 AND DEPT_ID in (select DEPT_ID from jc_dept_type_relation where type_code = '004') ORDER BY SORT_ID ASC");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得科室信息！", "提示");
                }
                DataRow rowKs = tb.NewRow();
                rowKs["ITEMCODE"] = -1;
                rowKs["ITEMNAME"] = "全部";
                tb.Rows.Add(rowKs);
                cmbZcDept.DataSource = tb;
                cmbZcDept.DisplayMember = "ITEMNAME";
                cmbZcDept.ValueMember = "ITEMCODE";
                cmbZcDept.SelectedValue = -1;

                DataTable tb1 = tb.Copy();
                cmbZrDept.DataSource = tb1;
                cmbZrDept.DisplayMember = "ITEMNAME";
                cmbZrDept.ValueMember = "ITEMCODE";
                cmbZrDept.SelectedValue = -1;

                //日期
                DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //检查系统是否控制了交帐时间 Modify By Tany 2012-01-11
                if (Convert.ToInt32(new SystemCfg(5016).Config) == 1)
                {
                    if (new SystemCfg(5017).Config.Trim() == "00:00:00")
                    {
                        this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + "" + Convert.ToDateTime(new SystemCfg(5017).Config.Trim()).ToString(" HH:mm:ss"));
                        this.dtp2.Value = Convert.ToDateTime(now.ToShortDateString() + " " + Convert.ToDateTime(new SystemCfg(5017).Config.Trim()).AddSeconds(-1).ToString(" HH:mm:ss"));
                    }
                    else
                    {
                        this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " " + Convert.ToDateTime(new SystemCfg(5017).Config.Trim()).AddSeconds(1).ToString(" HH:mm:ss"));
                        this.dtp2.Value = Convert.ToDateTime(now.ToShortDateString() + " " + new SystemCfg(5017).Config.Trim());
                    }
                }
                else
                {
                    this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 00:00:00");
                    this.dtp2.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 23:59:59");
                }
                //this.dtp2.MaxDate = now;//Modify By Daniel 2014-12-16 因马王堆医院要求把结束时间改为"23:59:59",故注释掉
                this.dataGridView1.Width = this.Width - 20;
                this.dataGridView1.Height = this.panel1.Height - this.dataGridView1.Top - 20;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = PubStaticFun.WaitCursor();
                int count = 10;
                if(speci.Equals(1))
                {
                    count = 9;
                }             
                //Modify By Kevin 2013-10-16
                ParameterEx[] parameters = new ParameterEx[count];

                parameters[0].Text = "@RQ1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@RQ2";
                parameters[1].Value = dtp2.Value.ToString();

                int type = 0;
                if (rbJg.Checked)
                    type = 0;
                else
                    type = 1;
                parameters[2].Text = "@TYPE";
                parameters[2].Value = type;

                int tj_type = 0;
                if (rbJsrq.Checked)
                    tj_type = 1;
                if (rbDqzy.Checked)
                    tj_type = 2;
                
                parameters[3].Text = "@TJ_TYPE";
                parameters[3].Value = tj_type;

                parameters[4].Text = "@YKS";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbZcDept.SelectedValue, "0"));

                parameters[5].Text = "@XKS";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbZrDept.SelectedValue, "0"));

                //Add By Tany 2011-07-04
                parameters[6].Text = "@ISBRMX";
                parameters[6].Value = chkBrmx.Checked ? 1 : 0;

                //Modify By Tany 2011-12-06 增加机构编码过滤
                parameters[7].Text = "@JGBM";
                parameters[7].Value = FrmMdiMain.Jgbm;

                parameters[8].Text = "@ISZRKS";
                parameters[8].Value = chkZrks.Checked ? 1 : 0;

                if (!speci.Equals(1))
                {
                    //Modify By Daniel 2015-01-22 增加住院号
                    parameters[9].Text = "@ZYH";
                    parameters[9].Value = txtInp_NO.Text.Trim();
                }

                string Sp_name = "[SP_ZY_TJ_BRSRTJ_ZKBR_zyf2]";
                if (speci == 1)
                {
                    Sp_name = "[SP_ZY_TJ_BRSRTJ_ZKBR_ICU]"; 
                }

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet(Sp_name, parameters, dset, "sfmx", 60);
                Fun.AddRowtNo(dset.Tables[0]);
                DataTable tb = dset.Tables[0];

                tb.Columns["病人科室"].ColumnName = "计费科室";
                //DataTable tb = InstanceForm.BDatabase.GetDataTable(Sp_name, parameters, 120);
                //AddRowtNo(tb);
                if (tb.Columns.Contains("序号") && tb.Rows.Count > 0)
                {
                    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                }
                tb.Columns[3].SetOrdinal(5);
                //tb.Columns[3].SetOrdinal(4);


                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = tb;
                //Modify By Daniel 2015-01-22 当病人科室与转入科室不一致时，该行背景色变为淡蓝色
                //Begin
                //if (chkBrmx.Checked == true)
                //{
                //    for (int i = 0; i < tb.Rows.Count; i++)
                //    {
                //        if (tb.Rows[i]["病人科室"].ToString() != tb.Rows[i]["转入科室"].ToString())
                //        {
                //            this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                //        }
                //    }
                //}
                //End
                //Modify By Daniel 2015-02-11 修改转入科室的背景色为淡蓝色，转出科室的背景色为黄绿色
                this.dataGridView1.Columns["转入科室"].DefaultCellStyle.BackColor = Color.Blue;
                this.dataGridView1.Columns["转出科室"].DefaultCellStyle.BackColor = Color.Yellow;
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    if (this.dataGridView1.Columns[i].Name == "sort")
                    {
                        this.dataGridView1.Columns[i].Visible = false;
                        break;
                    }
                }
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
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

        private void CleanInfo()
        {
            dataGridView1.DataSource = null;
        }

        private void rbJg_CheckedChanged(object sender, EventArgs e)
        {
            CleanInfo();
            dtp1.Enabled = !rbDqzy.Checked;
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                #region 简单打印
                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                this.btExcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string type = "";
                if (rbJg.Checked)
                    type = "统计项目:" + rbJg.Text;
                else
                    type = "统计项目:" + rbKj.Text;

                string zcks = "    转出科室:" + cmbZcDept.Text;
                string zrks = "    转入科室:" + cmbZrDept.Text;

                string rq = "    日期:" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                string swhere = type + zcks + zrks + rq;


                //写入行头

                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    if (this.dataGridView1.Columns[j].Visible)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = "" + this.dataGridView1.Columns[j].HeaderText;
                    }
                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        ncol = ncol + 1;
                        myExcel.Cells[6 + i, ncol] = tb.Rows[i][j].ToString().Trim();//"'" + 
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = TrasenFrame.Classes.Constant.HospitalName + this.label1.Text;
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;


                //让Excel文件可见
                myExcel.Visible = true;

                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butdy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未提供打印固定格式！");
        }

        //Add By tany 2011-04-13
        private void 冻结当前列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int ncol = dataGridView1.CurrentCell.ColumnIndex;

                    if (dataGridView1.Columns[ncol].Frozen)
                    {
                        for (int i = 0; i < ncol; i++)
                        {
                            dataGridView1.Columns[i].Frozen = false;
                        }
                    }
                    else
                    {
                        dataGridView1.Columns[ncol].Frozen = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int ncol = dataGridView1.CurrentCell.ColumnIndex;

                    if (dataGridView1.Columns[ncol].Frozen)
                    {
                        冻结当前列ToolStripMenuItem.Text = "解冻当前列";
                    }
                    else
                    {
                        冻结当前列ToolStripMenuItem.Text = "冻结当前列";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Frm_zkbrsrtj_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            this.dataGridView1.Width = this.Width - 20;
            this.dataGridView1.Height = this.panel1.Height - this.dataGridView1.Top - 20;
        }

        private void Frm_zkbrsrtj_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 20;
            this.dataGridView1.Height = this.panel1.Height - this.dataGridView1.Top - 20;
        }





    }
}