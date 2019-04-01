using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class FrmYjKsGzlTj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public FrmYjKsGzlTj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            this.Text = chineseName;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            dtp1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 0:00:00"));
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmYjKsGzlTj_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddJgbm(true, cmbJgbm, InstanceForm.BDatabase);
            cmbJgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtp1.Value > dtp2.Value)
                {
                    MessageBox.Show("开始日期不能大于结束日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnTj.Enabled = false;
                this.Cursor = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@KSRQ";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@JSRQ";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@JGBM";
                parameters[2].Value = cmbJgbm.SelectedValue;

                parameters[3].Text = "@TJBZ";
                if (rbDxm.Checked)
                {
                    parameters[3].Value = 1;
                }
                else if (rbJzrs.Checked)
                {
                    parameters[3].Value = 2;
                }

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZ_YJKSGZLTJ", parameters, dset,
                    "yjksgzltj", 40);

                dgvData.Columns.Clear();
                DataTable dt = dset.Tables[0];
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("统计时发生错误：" + Environment.NewLine + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnTj.Enabled = true;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.btnExcel.Enabled = false;
                DataTable tb = dgvData.DataSource as DataTable;
                string swhere = string.Format("部门名称：{0}  收费时间：{1} 到 {2}", cmbJgbm.Text, dtp1.Text, dtp2.Text);
                ExportToExcel(tb, Constant.HospitalName + " " + this.Text, swhere);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("导出Excel时发生错误：" + Environment.NewLine + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.btnExcel.Enabled = true;
            }
        }

        /// <summary>
        /// 导出数据表到Excel
        /// </summary>
        /// <param name="table">数据表</param>
        /// <param name="title">标题</param>
        /// <param name="info">相关信息</param>
        private void ExportToExcel(DataTable table, string title, string info)
        {
            if (table == null)
                return;

            Excel.Application myExcel = new Excel.Application();
            myExcel.Application.Workbooks.Add(true);

            //写入行头
            int sumRowCount = table.Rows.Count;
            int sumColCount = 0;

            for (int j = 0; j < table.Columns.Count; j++)
            {
                sumColCount += 1;
                myExcel.Cells[5, sumColCount] = table.Columns[j].ColumnName;
            }
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, sumColCount]).Font.Bold = true;
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, sumColCount]).Font.Size = 10;

            //逐行写入数据
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int ncol = 0;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    ncol = ncol + 1;
                    myExcel.Cells[6 + i, ncol] = "'" + table.Rows[i][j].ToString().Trim();
                }
            }

            //设置报表表格为最适应宽度
            myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Columns.AutoFit();

            //加边框
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Borders.LineStyle = 1;

            //报表名称
            myExcel.Cells[1, 1] = title;
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Font.Bold = true;
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Font.Size = 16;
            //报表名称跨行居中
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

            //报表条件
            myExcel.Cells[3, 1] = info.Trim();
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, sumColCount]).Font.Size = 10;
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, sumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            //最后一行为黄色
            myExcel.get_Range(myExcel.Cells[5 + sumRowCount, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Interior.ColorIndex = 19;

            //让Excel文件可见
            myExcel.Visible = true;
        }
    }
}