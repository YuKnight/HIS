using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_yf_tjbb
{
    public partial class FrmMedSaleOrd : Form
    {
        string _mzFlag = "0";
        string _zyFlag = "0";
        string _deptid = "0";


        public FrmMedSaleOrd()
        {
            InitializeComponent();
        }

        private void txtghdw_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int nkey = Convert.ToInt32(e.KeyCode);
                Control control = (Control)sender;

                if (control.Text.Trim() == "")
                {
                    control.Text = "";
                    control.Tag = "0";
                    _mzFlag = "0";
                    _zyFlag = "0";
                    _deptid = "0";
                    return;
                }
                if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
                { }
                else
                {
                    return;
                }
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);


                string[] GrdMappingName = new string[] { "科室", "拼音码", "五笔码", "DEPT_ID", "MZ_FLAG", "ZY_FLAG" };
                int[] GrdWidth = new int[] { 140, 60, 60, 0, 0, 0 };
                string[] sfield = new string[] { "", "PY_CODE", "WB_CODE", "", "" };

                string ssql = "select NAME ,PY_CODE ,WB_CODE ,DEPT_ID,MZ_FLAG,ZY_FLAG from JC_DEPT_PROPERTY where (MZ_FLAG=1 or ZY_FLAG=1) and DELETED=0";
                Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "科室";
                f.Width = 500;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    (sender as Control).Tag = row["DEPT_ID"].ToString();
                    (sender as Control).Text = row["NAME"].ToString();
                    _mzFlag = row["MZ_FLAG"].ToString();
                    _zyFlag = row["ZY_FLAG"].ToString();
                    _deptid = row["DEPT_ID"].ToString();
                    this.SelectNextControl((Control)sender, true, false, true, true);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void btnTj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convertor.IsNull(txtghdw.Tag, "")))
            {
                MessageBox.Show("请选择 科室", "提示");
                txtghdw.Focus();
                return;
            }

            int iNum = 0;

            if (!int.TryParse(txtNum.Text, out iNum))
            {
                MessageBox.Show("请选择 条数", "提示");
                txtNum.Focus();
                return;
            }

            DataTable dt = DoQuery();

            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;

                (this.dataGridView1.DataSource as DataTable).AcceptChanges();
            }

        }

        private void FrmMedSaleOrd_Load(object sender, EventArgs e)
        {

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;

            dtp1.Value = DateTime.Now.AddMonths(-1);
        }

        private DataTable DoQuery()
        {


            ParameterEx[] parameters = new ParameterEx[6];
            parameters[0].Text = "@dept_id";
            parameters[0].Value = int.Parse(_deptid);
            parameters[1].Text = "@CHARGE_bDATE";
            parameters[1].Value = dtp1.Value.ToString("yyyy-MM-dd");
            parameters[2].Text = "@CHARGE_eDATE";
            parameters[2].Value = dtp2.Value.ToString("yyyy-MM-dd");
            parameters[3].Text = "@no";
            parameters[3].Value = int.Parse(txtNum.Text); ;
            parameters[4].Text = "@zy_flag";
            parameters[4].Value = _zyFlag;
            parameters[5].Text = "@mz_flag";
            parameters[5].Value = _mzFlag;

            DataTable dt = InstanceForm.BDatabase.GetDataTable("SP_YF_SELECT_MEDSALE_ORDER", parameters, 30);

            return dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void ExportExcel(DataTable dt, string table)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                return;
            }
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            //Excel.Workbook workbook = xlApp.Workbooks.Open(table, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Excel.Worksheet worksheet = workbook.Sheets[1] as Excel.Worksheet; //第一个sheet页
            worksheet.Name = "武汉市公费"; //这里修改sheet名称

            try
            {
                Excel.Range range;
                long totalCount = dt.Rows.Count;
                long rowRead = 0;
                float percent = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    range = (Excel.Range)worksheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                    //range.NumberFormat = "0.00";
                }

                DataTable dtDec = DecCol();

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string strValue = dt.Rows[r][i].ToString();
                        decimal dm = 0M;
                        if (dtDec.Columns.Contains(dt.Columns[i].ColumnName))
                        {
                            ((Excel.Range)worksheet.Cells[r + 2, i + 1]).NumberFormat = "0.00";
                            worksheet.Cells[r + 2, i + 1] = strValue;
                        }
                        else
                        {
                            worksheet.Cells[r + 2, i + 1] = "'" + strValue;
                            //worksheet.Cells[r + 2, i + 1] = strValue;
                        }
                    }
                    rowRead++;
                    percent = ((float)(100 * rowRead)) / totalCount;
                }
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                workbook.Saved = true;

                if (System.IO.File.Exists(table))
                {
                    System.IO.File.Delete(table);
                }
                workbook.SaveCopyAs(table);
                workbook.Close(true, Type.Missing, Type.Missing);
                workbook = null;
                xlApp.Quit();
                xlApp = null;
            }
        }

        private DataTable DecCol()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("cjid", typeof(string));
            dt.Columns.Add("s_yppm", typeof(string));
            dt.Columns.Add("YPGG", typeof(string));
            dt.Columns.Add("zje", typeof(decimal));

            return dt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有数据需要导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //saveFileDialog1.OverwritePrompt
                string table = @"";

                //设置文件类型
                //书写规则例如：txt files(*.txt)|*.txt  dBase(*.dbf)
                saveFileDialog1.Filter = "Excel files(*.xls)|*.xls|All files(*.*)|*.*";
                //设置默认文件名（可以不设置）
                saveFileDialog1.FileName = "1";
                //主设置默认文件extension（可以不设置）
                saveFileDialog1.DefaultExt = "xls";
                //获取或设置一个值，该值指示如果用户省略扩展名，文件对话框是否自动在文件名中添加扩展名。（可以不设置）
                saveFileDialog1.AddExtension = true;

                //设置默认文件类型显示顺序（可以不设置）
                saveFileDialog1.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录
                saveFileDialog1.RestoreDirectory = true;

                // Show save file dialog box
                DialogResult result = saveFileDialog1.ShowDialog();
                //点了保存按钮进入
                if (result == DialogResult.OK)
                {

                    //获得文件路径
                    table = saveFileDialog1.FileName.ToString();
                }
                else
                {
                    return;
                }

                ExportExcel(dt, table);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作出错! \n\t " + ex.Message + " \n\t " + ex.StackTrace);
                return;
            }
        }
    }
}