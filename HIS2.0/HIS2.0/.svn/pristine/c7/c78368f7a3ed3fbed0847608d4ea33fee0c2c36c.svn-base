using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_tjbb
{
    public partial class FrmMzzffp : Form
    {
        System.Data.DataTable dtMzzffp;

        public FrmMzzffp(string chineseName)
        {
            InitializeComponent();
            this.Text = chineseName;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmMzzffp_Load(object sender, EventArgs e)
        {
            dateTimePickerBegin.Value = DateTime.Today.AddDays(-1);
            dateTimePickerEnd.Value = Convert.ToDateTime(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd 23:59:59"));
        }


        private void rdoSk_CheckedChanged(object sender, EventArgs e)
        {
            dgvMzzffp.DataSource = null;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string StrSql;
            if (rdoSk.Checked == true)
            {
                StrSql = "select dbo.fun_getempname(sfy) as 退费人员,fph as 发票号码,zje as 发票金额,sfrq as 退费日期 from vi_mz_fpb where jlzt = 2 and sfrq between '" + dateTimePickerBegin.Value.ToString() + "' and '" + dateTimePickerEnd.Value.ToString() + "' order by sfy,sfrq";
            }
            else
            {
                StrSql = "select dbo.fun_getempname(sfy) as 退费人员,fph as 发票号码,zje as 发票金额,sfrq as 退费日期 from vi_mz_fpb where jlzt = 2 and jkid is not null and sfrq between '" + dateTimePickerBegin.Value.ToString() + "' and '" + dateTimePickerEnd.Value.ToString() + "' order by sfy,sfrq";
            }
            dtMzzffp = InstanceForm.BDatabase.GetDataTable(StrSql);
            dgvMzzffp.DataSource = dtMzzffp;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application myExcel = new Excel.ApplicationClass();

                //设置不显示
                myExcel.ScreenUpdating = false;

                //添加工作簿
                myExcel.Workbooks.Add(true);

                //设置工作表
                Excel.Worksheet mySheet = (Excel.Worksheet)myExcel.ActiveWorkbook.ActiveSheet;
                mySheet.Name = "TrasenHis";

                //设置标题
                Excel.Range myTitle = mySheet.get_Range(mySheet.Cells[1, 1], mySheet.Cells[1, dgvMzzffp.Columns.Count]);
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
                Excel.Range myNote = mySheet.get_Range(mySheet.Cells[2, 1], mySheet.Cells[2, dgvMzzffp.Columns.Count]);
                myNote.Merge(true);
                myNote.Value2 = dateTimePickerBegin.Value.ToLongDateString() + " " + dateTimePickerBegin.Value.ToLongTimeString() + " —— " + dateTimePickerEnd.Value.ToLongDateString() + " " + dateTimePickerEnd.Value.ToLongTimeString();
                myNote.Font.Name = "宋体";
                myNote.Font.Size = 12;
                myNote.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                myNote.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //写入表头
                for (int i = 0; i < dgvMzzffp.Columns.Count; i++)
                {
                    myExcel.Cells[3, i + 1] = dgvMzzffp.Columns[i].HeaderText;
                }

                //设置表头
                Excel.Range myHeader = mySheet.get_Range(mySheet.Cells[3, 1], mySheet.Cells[3, dgvMzzffp.Columns.Count]);
                myHeader.Font.Size = 12;
                myHeader.Font.Bold = true;
                myHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //写入数据
                for (int i = 0; i < dgvMzzffp.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvMzzffp.Columns.Count; j++)
                    {
                        myExcel.Cells[i + 4, j + 1] = dgvMzzffp[j, i].Value;
                    }
                }

                //设置表格
                Excel.Range myTable = mySheet.get_Range(mySheet.Cells[3, 1], mySheet.Cells[dgvMzzffp.Rows.Count + 3, dgvMzzffp.Columns.Count]);
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
    }
}