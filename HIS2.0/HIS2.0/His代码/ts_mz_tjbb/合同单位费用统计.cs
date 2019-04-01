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
    public partial class Frmsk_htdw : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmsk_htdw(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.label1.Text = _chineseName;

            if (menuTag.Function_Name == "Fun_ts_mz_tjbb_jk_htdw")
            {
                label4.Text = "缴款员";
                label2.Text = "缴款日期";
                label1.Text = "合同单位费用统计(缴款)";
            }
            else
            {
                label4.Text = "收款员";
                label2.Text = "收款日期";
                label1.Text = "合同单位费用统计(收款)";
            }
            
        }

        private void Frmxjsrtj_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
            this.WindowState = FormWindowState.Maximized;

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            FunAddComboBox.AddHtdwLx(true, cmbhtdwlx, InstanceForm.BDatabase);
            butprint.Visible = true;

            
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@sky";
                parameters[2].Value =Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue,"0")) ;

                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                parameters[4].Text = "@htdwlx";
                parameters[4].Value =Convert.ToInt32(Convertor.IsNull(cmbhtdwlx.SelectedValue,"0"));

                parameters[5].Text = "@htdwmc";
                parameters[5].Value = txthtdw.Text.Trim();

                parameters[6].Text = "@type";
                if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_jk_htdw")
                    parameters[6].Value = 1;
                else
                    parameters[6].Value = 0;

                DataTable tb;
                tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZSF_TJ_SK_HTDW", parameters, 30);
                Fun.AddRowtNo(tb);
                this.dataGridView1.DataSource = tb;
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || ((DataTable)this.dataGridView1.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("没有数据！");
                return;
            }
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butprint.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);
                Excel._Worksheet ws = (Excel._Worksheet)myExcel.ActiveSheet;   

                //查询条件
                string swhere = "";

                if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_jk_htdw")
                {
                     swhere = "统计部门:" + cmbjgbm.Text + "  缴款日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + " 缴款员:" + cmbuser.Text;
                }
                else
                {
                    swhere = "统计部门:" + cmbjgbm.Text + "  收费日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + " 收费员:" + cmbuser.Text;
                }

                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {

                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                        if (tb.Columns[j].ColumnName=="单位名称")
                             ws.get_Range(myExcel.Cells[5, SumColCount], myExcel.Cells[5, SumColCount]).ColumnWidth = 24;
                        else
                            ws.get_Range(myExcel.Cells[5, SumColCount], myExcel.Cells[5, SumColCount]).ColumnWidth = 9;

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
                            if (tb.Columns[j].ColumnName == "日期")
                                 myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                            else
                                 myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                    }
                }

                //设置报表表格为最适应宽度
                //myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                //myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

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
                this.butprint.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || ((DataTable)this.dataGridView1.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("没有数据！");
                return;
            }
            try
            {
                DataTable tbsk = (DataTable)dataGridView1.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();
                DataRow myrow;
                for (int i = 0; i <= tbsk.Rows.Count - 1; i++)
                {

                    myrow = Dset.合同单位汇总.NewRow();
                    int x = i + 1;
                    //myrow["序号"] = Convert.ToString(tbsk.Rows[i]["序号"]);
                    myrow["单位类型"] = Convert.ToString(tbsk.Rows[i]["单位性质"]);
                    myrow["合同单位名称"] = Convert.ToString(tbsk.Rows[i]["单位名称"]);
                    myrow["应收"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["应收"],"0")); 
                    myrow["优惠"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["优惠"],"0")); 
                    myrow["实收"] = Convert.ToDecimal(Convertor.IsNull(tbsk.Rows[i]["实收"],"0"));
                    myrow["dwmc"] = Convertor.IsNull(tbsk.Rows[i]["dwmc"], "");
                    Dset.合同单位汇总.Rows.Add(myrow);
                }

                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;


                parameters[1].Text = "统计条件";
                if (_menuTag.Function_Name == "Fun_ts_mz_tjbb_jk_htdw")
                {
                    parameters[1].Value = "缴款日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + " 缴款员:"+cmbuser.Text+ "   统计部门:" + cmbjgbm.Text   ;
                    
                }
                else
                {
                    parameters[1].Value = "收款日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + " 收费员:" + cmbuser.Text + "   统计部门:" + cmbjgbm.Text;
                }
                

                parameters[2].Text = "备注";
                parameters[2].Value = cmbjgbm.Text;



                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_合同单位汇总.rpt", parameters);
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

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb!=null)
            tb.Rows.Clear();
        }

        private void txthtdwmc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;

            if ((int)e.KeyChar == 8) { control.Text = ""; return; }
            if ((int)e.KeyChar != 13 && (int)e.KeyChar != 8)
            {
                string[] headtext = new string[] { "单位名称", "数字码", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "dwmc", "szm", "pym", "wbm" };
                string[] searchfields = new string[] { "dwmc", "szm", "pym", "wbm" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = InstanceForm.BDatabase.GetDataTable("select * from jc_htdw");
                f.WorkForm = this;
                f.srcControl = txthtdw;
                f.Font = txthtdw.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txthtdw.Focus();
                }
                else
                {
                    txthtdw.Tag = Convert.ToInt32(f.SelectDataRow["id"]);
                    txthtdw.Text = f.SelectDataRow["dwmc"].ToString().Trim();
                    //this.SelectNextControl(control, true, false, true, true);
                    buttj.Focus();
                }
            }
            else
            {
                if (txthtdw.Text.Trim() == "") { txthtdw.Focus(); return; }
                buttj.Focus();
            }
            e.Handled = true;
        }

 
    }
}