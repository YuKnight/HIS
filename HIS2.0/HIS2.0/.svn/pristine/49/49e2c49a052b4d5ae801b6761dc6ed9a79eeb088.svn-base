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

namespace ts_mz_tjbb
{
    public partial class Frmsk_jktj_cx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//统计时发票记录张数
        private long Jkid = 0;//交款ID
        public Frmsk_jktj_cx(MenuTag menuTag, string chineseName, Form mdiParent)
        {


            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            if (_menuTag.Function_Name == "Fun_ts_mz_jk_tj_cx_qr")//Add By Zj 2012-10-10
            {
                btnqrjk.Visible = true;
                checkBox1.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                btn_total.Visible = true;
                DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                //设定列的名字
                column.Name = "选择";
                //如果不是Icon型，就表示Image型的数据
                column.DisplayIndex = 1;
                column.Width = 30;
                // Image的说明
                //向DataGridView追加
                dataGridView1.Columns.Add(column);
                // Image列取得
                DataGridViewCheckBoxColumn checkColumn = (DataGridViewCheckBoxColumn)dataGridView1.Columns["选择"];
                //单元格Style的NullValue设定为null
                checkColumn.DefaultCellStyle.NullValue = false;
            }
        }

        private void Frmsk_jktj_Load(object sender, EventArgs e)
        {


            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
            this.WindowState = FormWindowState.Maximized;

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtp1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtp2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);
            }

            cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
                this.cmbuser.SelectedValue = "0";

            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            buttj_Click(sender, e);
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            try
            {
                ParameterEx[] parameters = null;

                int bzt = 0;
                if (radioButton2.Checked)
                    bzt = 1;
                if (radioButton3.Checked)
                    bzt = 2;
                parameters = new ParameterEx[5];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@sky";
                parameters[2].Value = Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue, "0"));

                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                parameters[4].Text = "@bzt";
                parameters[4].Value = bzt;


                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_JKJL", parameters, 30);

                Fun.AddRowtNo(tb);
                if (tb.Rows.Count > 0)
                    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                this.dataGridView1.DataSource = tb;


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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                Guid jkid = new Guid(Convertor.IsNull(tb.Rows[nrow]["交款id"], Guid.Empty.ToString()));
                int sfy = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["sfy"], "0"));
                if (jkid == Guid.Empty) return;
                Frmsk_jktj f = new Frmsk_jktj(_menuTag, "交款历史查询", _mdiParent);
                f.MdiParent = _mdiParent;
                f.Jkid = jkid;
                f.cmbuser.SelectedValue = sfy.ToString();
                f.butjk.Visible = false;
                f.buttj.Enabled = false;
                f.Show();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butexcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string xm = "    缴款员:" + cmbuser.Text;
                string swhere = "缴款日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm;


                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    //if (checkBox1.Checked == true)
                    //{
                    //    if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "科室" )
                    //    {
                    //        SumColCount = SumColCount + 1;
                    //        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    //    }
                    //}
                    //else
                    //{
                    if (dataGridView1.Columns[j].Visible == true)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    }
                    //}

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        //if (checkBox1.Checked == true)
                        //{
                        //    if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "科室" && tb.Columns[j].ColumnName != "医生")
                        //    {
                        //        ncol = ncol + 1;
                        //        myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                        //    }
                        //}
                        //else
                        //{
                        if (dataGridView1.Columns[j].Visible == true)
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                        }
                        //}
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

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
                DataTable tbsk = (DataTable)dataGridView1.DataSource;
                if (tbsk == null) return;
                if (tbsk.Rows.Count == 1 && tbsk.Rows[0]["序号"].ToString().Trim() == "合计") return;
                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();
                DataRow myrow;
                for (int i = 0; i <= tbsk.Rows.Count - 1; i++)
                {

                    myrow = Dset.交款表.NewRow();
                    int x = i + 1;
                    myrow["序号"] = Convert.ToString(tbsk.Rows[i]["序号"]);
                    myrow["收费员"] = Convert.ToString(tbsk.Rows[i]["收费员"]);
                    myrow["交款时间"] = Convert.ToString(tbsk.Rows[i]["缴款时间"]);
                    myrow["发票金额"] = Convert.ToString(tbsk.Rows[i]["发票金额"]); ;
                    myrow["有效张数"] = Convert.ToString(tbsk.Rows[i]["有效张数"]);
                    myrow["废票张数"] = Convert.ToString(tbsk.Rows[i]["废票张数"]);
                    myrow["现金支付"] = Convert.ToString(tbsk.Rows[i]["现金支付"]);
                    myrow["支票支付"] = Convert.ToString(tbsk.Rows[i]["支票支付"]);
                    myrow["银联支付"] = Convert.ToString(tbsk.Rows[i]["银联支付"]);
                    myrow["医保支付"] = Convert.ToString(tbsk.Rows[i]["医保支付"]);
                    myrow["财务记账"] = Convert.ToString(tbsk.Rows[i]["财务记账"]);
                    myrow["欠费挂账"] = Convert.ToString(tbsk.Rows[i]["欠费挂账"]);
                    myrow["优惠金额"] = Convert.ToString(tbsk.Rows[i]["优惠金额"]);
                    myrow["发票段"] = Convert.ToString(tbsk.Rows[i]["收费票段"]) + " " + Convert.ToString(Convertor.IsNull(tbsk.Rows[i]["作废票号"], ""));
                    myrow["作废票号"] = Convert.ToString(tbsk.Rows[i]["作废票号"]);
                    myrow["作废金额"] = Convert.ToString(tbsk.Rows[i]["废票金额"]);
                    if (tbsk.Columns.Contains("缴款科室") == true)
                        myrow["缴款科室"] = Convert.ToString(tbsk.Rows[i]["缴款科室"]);
                    if (tbsk.Columns.Contains("离休老干"))
                        myrow["离休老干"] = Convert.ToString(tbsk.Rows[i]["离休老干"]);
                    if (tbsk.Columns.Contains("职工血透"))
                        myrow["职工血透"] = Convert.ToString(tbsk.Rows[i]["职工血透"]);
                    Dset.交款表.Rows.Add(myrow);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "备注";
                parameters[2].Value = dtp1.Value.ToString() + " 到 " + dtp2.Value.ToString() + "  收费员:" + cmbuser.Text.Trim();

                parameters[3].Text = "现金大写";
                parameters[3].Value = "";


                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_操作员缴款汇总表.rpt", parameters);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_menuTag.Function_Name == "Fun_ts_mz_jk_tj_cx_qr")//Add By Zj 2012-10-10
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                DataView dv = tb.DefaultView;
                if (dv.Count == 0) return;
                if (dv.Table.Rows.Count == 0) return;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                if (Convert.ToBoolean(dataGridView1.Rows[nrow].Cells["选择"].Value) == true)
                {
                    dataGridView1.Rows[nrow].Cells["选择"].Value = false;
                }
                else
                {
                    dataGridView1.Rows[nrow].Cells["选择"].Value = true;
                }
            }
        }

        private void btnqrjk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(Convertor.IsNull(dataGridView1.Rows[i].Cells["选择"].Value, "false")) && dataGridView1.Rows[i].Cells["序号"].Value.ToString() != "合计" && dataGridView1.Rows[i].Cells["确认人"].Value.ToString() == "")
                    {
                        string jkid = dataGridView1.Rows[i].Cells["交款iD"].Value.ToString();
                        string qrr = InstanceForm.BCurrentUser.EmployeeId.ToString();
                        string qrsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                        string usql = "update MZ_JKB set QRR=" + qrr + ",qrsj='" + qrsj + "' where jkid='" + jkid + "'";
                        InstanceForm.BDatabase.DoCommand(usql);
                    }
                }
                MessageBox.Show("确认成功!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in this.dataGridView1.Rows)
            {
                if (!Convert.ToBoolean(dgvRow.Cells["选择"].Value))
                {
                    dgvRow.Cells["选择"].Value = true;
                }
                else
                {
                    dgvRow.Cells["选择"].Value = false;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            buttj_Click(sender, e);

        }

        private void btn_total_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                DataTable dt_total = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string str_qrr = dataGridView1.Rows[i].Cells["确认人"].Value != null ? dataGridView1.Rows[i].Cells["确认人"].Value.ToString() : "";
                    if (Convert.ToBoolean(Convertor.IsNull(dataGridView1.Rows[i].Cells["选择"].Value, "false")) && dataGridView1.Rows[i].Cells["序号"].Value.ToString() != "合计" && String.IsNullOrEmpty(str_qrr))
                    {
                        DataRow dr = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
                        dt_total.ImportRow(dr);
                    }
                }
                if (dt_total.Rows.Count > 0)
                {
                    Frmsk_jktj_total f = new Frmsk_jktj_total(dt_total);
                    f.ShowDialog();
                    if (f.DialogResult == DialogResult.OK)
                    {
                        buttj_Click(buttj, null);
                    }
                }
                else
                {
                    MessageBox.Show("请选择未确认的交款记录!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}