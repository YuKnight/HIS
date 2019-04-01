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
using Ts_zyys_public;
using TrasenFrame.Forms;

namespace ts_mz_tjbb
{
    public partial class Frmyyzlkbktjmx : Form
    {
        public Frmyyzlkbktjmx()
        {
            InitializeComponent();
        }

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string ksrq;
        private string jsrq;

        public Frmyyzlkbktjmx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void Frmyyzlkbktjmx_Load(object sender, EventArgs e)
        {
        }

        public void FillTj(string starttime, string endtime, int tjlx, int row, int djy)
        {
            try
            {
                ksrq = starttime;
                jsrq = endtime;
                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "@rq1";
                parameters[0].Value = starttime;

                parameters[1].Text = "@rq2";
                parameters[1].Value = endtime;

                parameters[2].Text = "@tjlx";
                parameters[2].Value = tjlx;

                parameters[3].Text = "@row";
                parameters[3].Value = row;

                parameters[4].Text = "@djy";
                parameters[4].Value = djy;

                DataSet dset = new DataSet();
                if (_menuTag.Function_Name != "Fun_ts_mz_tjbb_yyzlkbk_all")
                    InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_CX_ZLKBKTJMX", parameters, dset, "bktjmx", 30);
                else
                    InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_CX_ZLKBKTJMX_ALL", parameters, dset, "bktjmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                this.dataGridView1.DataSource = dset.Tables[0];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmiExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count < 1)
                {
                    return;
                }

                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件

                string swhere = "";

                swhere = "办卡日期从:" + ksrq.ToString() + " 到:" + jsrq.ToString();

                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    SumColCount = SumColCount + 1;
                    myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
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
                        myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
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

                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

    }
}


















































































