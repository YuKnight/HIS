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
using System.Collections.Generic;

namespace ts_mz_tjbb
{
    public partial class FrmzxkssrByDate : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//统计时发票记录张数
        private long Jkid = 0;//交款ID
        private DataTable depttb;
        /// <summary>
        /// 门诊病人数据转移天数 Add by zp 2013-07-18
        /// </summary>
        public SystemCfg cfg13 = new SystemCfg(13);
        /// <summary>
        /// 日期条件List 
        /// </summary>
        private List<DateTimePicker> list_datewhere = new List<DateTimePicker>();
        /// <summary>
        /// 启用视图(过程参数)
        /// </summary>
        private bool isview = true;

        public FrmzxkssrByDate(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            label1.Text = _chineseName;


        }

        private void Frmsk_jktj_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            dtpqrrq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpqrrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");


            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtp1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtp2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);

                dtpqrrq1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtpqrrq2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);
            }


            cmbFG.Items.Add("列宽适应网格内容");
            cmbFG.Items.Add("列宽仅适应有数据的区域");
            cmbFG.SelectedIndex = 0;

            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            depttb = InstanceForm.BDatabase.GetDataTable("select DEPT_ID,NAME,PY_CODE,WB_CODE from JC_DEPT_PROPERTY where LAYER=3  and deleted=0");
            list_datewhere.Add(this.dtp1);
            list_datewhere.Add(this.dtp2);

        }



        private void buttj_Click(object sender, EventArgs e)
        {
            SelectData(); 
        }

       
        /// <summary>
        /// 统计数据
        /// </summary>
        private void SelectData()
        {
            try
            {

                string where_date = "";
                if(chksfrq.Checked )
                    where_date = TjMeans.GetDateWhere("a.sfrq",this.list_datewhere);
                else
                    where_date = TjMeans.GetDateWhere("qrsj", this.list_datewhere);
                int _isview = 0;
                if (this.isview)
                    _isview = 1;

                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "@isview";
                parameters[0].Value = _isview;//chksfrq.Checked == true ? dtp1.Value.ToString() : "";

                parameters[1].Text = "@datewhere";
                parameters[1].Value = where_date;//chksfrq.Checked == true ? dtp2.Value.ToString() : "";

                parameters[2].Text = "@type";
                parameters[2].Value = rdJg.Checked == true ? 0 : 1;

                int _jsfs = 0;
                if (rbYb.Checked)
                {
                    _jsfs = 1;
                }
                else if (rbZf.Checked)
                {
                    _jsfs = 2;
                }
                else
                {
                    _jsfs = 0;
                }

                parameters[3].Text = "@jsfs";
                parameters[3].Value = _jsfs;

                parameters[4].Text = "@jgbm";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                parameters[5].Text = "@include_kdks";
                parameters[5].Value = checkBox2.Checked == true ? 0 : 1;

                //parameters[6].Text = "@qsfrq1";
                //parameters[6].Value = chkqfrq.Checked == true ? where_date : "";//chkqfrq.Checked == true ? dtpqrrq1.Value.ToString() : "";

                //parameters[7].Text = "@qsfrq2";
                //parameters[7].Value = chkqfrq.Checked == true ? dtpqrrq2.Value.ToString() : "";

                parameters[6].Text = "@zxksdm";
                parameters[6].Value = Convertor.IsNull(txtzxks.Tag, "0").ToString();

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_ZxkssrtjByDate", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);


                this.dataGridView1.DataSource = dset.Tables[0];

            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void cmbFG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFG.SelectedIndex == 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 30;
                dataGridView1.Refresh();
            }
            if (cmbFG.SelectedIndex == 1)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butexcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);
                Excel._Worksheet ws = (Excel._Worksheet)myExcel.ActiveSheet;
                //查询条件
                string xm = "";
                if (rdJg.Checked == true)
                    xm = "   统计分类:经管项目";
                else
                    xm = "   统计分类:会计项目";
                //Modify By Zj 2012-10-15
                string swhere = "";
                if (chksfrq.Checked)
                    swhere = "收费日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm + "  部门名称:" + cmbjgbm.Text;
                else
                    swhere = "确费日期从:" + dtpqrrq1.Value.ToString() + " 到:" + dtpqrrq2.Value.ToString() + xm + "  部门名称:" + cmbjgbm.Text;

                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    if (checkBox1.Checked == true)
                    {
                        if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "")
                        {
                            SumColCount = SumColCount + 1;
                            myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName.Trim();
                        }
                    }
                    else
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName.Trim();

                    }

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 9;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        if (checkBox1.Checked == true)
                        {
                            if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "")
                            {
                                ncol = ncol + 1;
                                myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                            }
                        }
                        else
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                        }
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Font.Size = 9;

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = Constant.HospitalName + label1.Text;
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
                this.butexcel.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butexcel.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)dataGridView1.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.收费项目.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }


                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                string jsfs = "";
                if (rbAll.Checked == true) jsfs = rbAll.Text;
                if (rbYb.Checked == true) jsfs = rbYb.Text;
                if (rbZf.Checked == true) jsfs = rbZf.Text;

                string ssql = rdJg.Checked == true ? "统计:按经管项目分类" : "统计:按会计项目分类";
                parameters[2].Text = "备注";
                parameters[2].Value = dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString() + "  " + ssql + " 部门名称:" + cmbjgbm.Text + " 结算方式:" + jsfs;

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";

                TrasenFrame.Forms.FrmReportView f;
                if (rdJg.Checked == true)
                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_科室收入报表(经管).rpt", parameters);
                else
                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_科室收入报表(会计).rpt", parameters);

                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb != null)
                tb.Rows.Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb == null) return;
                if (dataGridView1.CurrentCell == null) return;

                int nrow = dataGridView1.CurrentCell.RowIndex;
                string ksdm = Convert.ToString(tb.Rows[nrow]["ksdm"]);
                string flcode = Convert.ToString(tb.Rows[nrow]["flcode"]);
                if (flcode == "0" || flcode == "") return;
                //ts_mz_tjbb.Frmzxkssrtj_mx frm = new Frmzxkssrtj_mx(_menuTag, _chineseName, _mdiParent);
                Frmzxkssrtj_mxByDate frm = new Frmzxkssrtj_mxByDate(_menuTag, _chineseName, _mdiParent);
                frm.fl_code = flcode;
                frm.ksdm = ksdm;
                frm.dtp1.Value = dtp1.Value;
                frm.dtp2.Value = dtp2.Value;

                frm.dtpqrrq1.Value = dtp1.Value;
                frm.dtpqrrq2.Value = dtp2.Value;
                frm.cmbjgbm.SelectedValue = cmbjgbm.SelectedValue;


                //frm.txtks.Text = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                //frm.txtks.Tag = ksdm.ToString();


                //frm.txtks.Enabled = false;
                frm.cmbjgbm.Enabled = false;

                frm.Show();

                frm.btref_Click(sender, e);
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
            chkqfrq.Checked = false;
            if (chkqfrq.Checked)
            {
                list_datewhere.Clear();
                list_datewhere.Add(this.dtp1);
                list_datewhere.Add(this.dtp2);
            }
            else
            {
                chkqfrq.Checked = false;
            }
        }

        private void chkqfrq_CheckedChanged(object sender, EventArgs e)
        {
            dtpqrrq1.Enabled = chkqfrq.Checked == true ? true : false;
            dtpqrrq2.Enabled = chkqfrq.Checked == true ? true : false;
            chksfrq.Checked = false;
            if (chkqfrq.Checked)
            {
                list_datewhere.Clear();
                list_datewhere.Add(this.dtpqrrq1);
                list_datewhere.Add(this.dtpqrrq2);
            }
            else
            {
                chkqfrq.Checked = false;
            }
        }


        private void txtzxks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "拼音码", "五笔码", "dept_id" };
                string[] mappingname = new string[] { "name", "py_code", "wb_code", "dept_id" };
                string[] searchfields = new string[] { "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = depttb;
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                    //this.SelectNextControl(control, true, false, true, true);
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (control.Text.Trim() == "") { control.Focus(); return; }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }

        }

        private void Link_AddDateWhere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*新增日期查询条件*/
            Frm_AddDateWhere frm = new Frm_AddDateWhere(this.list_datewhere);
            frm.ShowDialog();

            list_datewhere = frm.ListDateWhere;
            if (frm.ListDateWhere.Count == 0)
            {
                if (chksfrq.Checked)
                {
                    list_datewhere.Add(this.dtp1);
                    list_datewhere.Add(this.dtp2);
                }
                else
                {
                    list_datewhere.Add(this.dtpqrrq1);
                    list_datewhere.Add(this.dtpqrrq2);
                }
            }
        }

        private void linkL_Clear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.list_datewhere.Clear();
            if (chksfrq.Checked)
            {
                list_datewhere.Add(this.dtp1);
                list_datewhere.Add(this.dtp2);
            }
            else
            {
                list_datewhere.Add(this.dtpqrrq1);
                list_datewhere.Add(this.dtpqrrq2);
            }
        }



    }
}