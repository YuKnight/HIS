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
using TrasenFrame.Forms;
using ts_mz_class;
namespace ts_mz_tjbb
{
    public partial class FrmMzyj : Form
    {
        public DataSet dset = new DataSet();
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public FrmMzyj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            this.Text = chineseName;
            this.WindowState = FormWindowState.Maximized;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void FrmMzyj_Load(object sender, EventArgs e)
        {
            dateTimePickerBegin.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd 00:00:00"));
            dateTimePickerEnd.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd 23:59:59"));

            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            string ssql = @" select '' code,'全部' name 
union select '3' code,'收款员' name
union select '8' code,'自助机' name";
            DataTable dt = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(ssql);
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "code";
            comboBox1.DataSource = dt;
            comboBox1.SelectedValue = "";
        }


        private void rdoSk_CheckedChanged(object sender, EventArgs e)
        {
            dgvMzyj.DataSource = null;
            lab1.Text = "收款日期从";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            try
            {
                //Modify by Kevin 2012-06-14
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@type";
                parameters[0].Value = rdoSk.Checked == true ? 1 : 2;

                parameters[1].Text = "@ksrq";
                parameters[1].Value = dateTimePickerBegin.Value.ToString();

                parameters[2].Text = "@jsrq";
                parameters[2].Value = dateTimePickerEnd.Value.ToString();


                parameters[3].Text = "@jgbm";
                parameters[3].Value = _menuTag.Jgbm;

                parameters[4].Text = "@rylx";
                parameters[4].Value = Convertor.IsNull(comboBox1.SelectedValue, "");

                dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_mzsf_yjjtj", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);


                this.dgvMzyj.DataSource = dset.Tables[0];

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMzyj.DataSource == null) return;

                Excel.Application myExcel = new Excel.ApplicationClass();

                //设置不显示
                myExcel.ScreenUpdating = false;

                //添加工作簿
                myExcel.Workbooks.Add(true);

                //设置工作表
                Excel.Worksheet mySheet = (Excel.Worksheet)myExcel.ActiveWorkbook.ActiveSheet;
                mySheet.Name = "TrasenHis";

                //设置标题
                Excel.Range myTitle = mySheet.get_Range(mySheet.Cells[1, 1], mySheet.Cells[1, dgvMzyj.Columns.Count]);
                myTitle.Merge(true);
                if (rdoSk.Checked == true)
                {
                    myTitle.Value2 = this.Text + "(" + rdoSk.Text + ")";
                }
                else
                {
                    myTitle.Value2 = this.Text + "(" + rdoJk.Text + ")";
                }
                myTitle.Font.Name = "黑体";
                myTitle.Font.Size = 20;
                myTitle.Font.Bold = true;
                myTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                myTitle.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //设置条件
                Excel.Range myNote = mySheet.get_Range(mySheet.Cells[2, 1], mySheet.Cells[2, dgvMzyj.Columns.Count]);
                myNote.Merge(true);
                myNote.Value2 = dateTimePickerBegin.Value.ToLongDateString() + " " + dateTimePickerBegin.Value.ToLongTimeString() + " —— " + dateTimePickerEnd.Value.ToLongDateString() + " " + dateTimePickerEnd.Value.ToLongTimeString();
                myNote.Font.Name = "宋体";
                myNote.Font.Size = 12;
                myNote.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                myNote.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //写入表头
                for (int i = 0; i < dgvMzyj.Columns.Count; i++)
                {
                    myExcel.Cells[3, i + 1] = dgvMzyj.Columns[i].HeaderText;
                }

                //设置表头
                Excel.Range myHeader = mySheet.get_Range(mySheet.Cells[3, 1], mySheet.Cells[3, dgvMzyj.Columns.Count]);
                myHeader.Font.Size = 12;
                myHeader.Font.Bold = false;
                myHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //写入数据
                for (int i = 0; i < dgvMzyj.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvMzyj.Columns.Count; j++)
                    {
                        myExcel.Cells[i + 4, j + 1] = dgvMzyj[j, i].Value;
                    }
                }

                //设置表格
                Excel.Range myTable = mySheet.get_Range(mySheet.Cells[3, 1], mySheet.Cells[dgvMzyj.Rows.Count + 3, dgvMzyj.Columns.Count]);
                myTable.Columns.AutoFit();
                myTable.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                myTable.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                myTable.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                //设置显示
                myExcel.Visible = true;
                myExcel.ScreenUpdating = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMzyj.DataSource==null) return;
                DataTable tbmx = dset.Tables[0];

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                int x = 0;
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    if (dgvMzyj.Columns[i].Visible == true)
                    {
                        x = x + 1;
                        string nm = "T" + x.ToString();
                        myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                    }
                }
                Dset.收费项目.Rows.Add(myrow);

                x = 0;
                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    x = 0;
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        if (dgvMzyj.Columns[i].Visible == true)
                        {
                            x = x + 1;
                            string nm = "JE" + x.ToString();
                            myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                        }
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }



                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "填报人";
                parameters[2].Value = InstanceForm.BCurrentUser.Name;

                parameters[3].Text = "rq1";
                parameters[3].Value = dateTimePickerBegin.Value.ToString();

                parameters[4].Text = "rq2";
                parameters[4].Value = dateTimePickerEnd.Value.ToString();

                parameters[5].Text = "院区";
                parameters[5].Value = cmbjgbm.Text;


                bool bprint = false;// chkprint.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView f;
                if (rdoSk.Checked==true)
                     f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_预交款按收费员汇总.rpt", parameters, bprint);
                else
                     f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_预交款按缴款员汇总.rpt", parameters, bprint);
                if (f.LoadReportSuccess)
                {
                    f.Show();
                }
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void rdoSk_CheckedChanged_1(object sender, EventArgs e)
        {
            dgvMzyj.DataSource = null;
            lab1.Text = "缴款日期从";
        }
    }
}