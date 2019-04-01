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
    public partial class Frmyjjdz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Guid kdjid = Guid.Empty;
        public Guid brxxid = Guid.Empty;
        public DataSet dset = new DataSet();

        public Frmyjjdz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;


            dtpjsrq1.Enabled = true;
        }


        private void buttj_Click(object sender, EventArgs e)
        {

            try
            {

                ParameterEx[] parameters1 = new ParameterEx[4];

                parameters1[0].Text = "@rq1";
                parameters1[0].Value = dtpjsrq1.Value.ToString();

                parameters1[1].Text = "@rq2";
                parameters1[1].Value = dtpjsrq2.Value.ToString();

                parameters1[2].Text = "@kdjid";
                parameters1[2].Value = kdjid;

                parameters1[3].Text = "@brxxid";
                parameters1[3].Value = brxxid;

                dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZ_YJJDZ", parameters1, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);

                this.dataGridView1.DataSource = dset.Tables[0];

                return;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmyjjjk_Load(object sender, EventArgs e)
        {
            //卡类型
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            this.WindowState = FormWindowState.Maximized;
            dtpjsrq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpjsrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }


        private void butprint_pos_Click(object sender, EventArgs e)
        {

            try
            {
                if (dset.Tables.Count == 0) return;
                DataTable tbmx = dset.Tables[0];

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                int x = 0;
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    //if (dataGridView1.Columns[i].Visible == true)
                    //{
                    x = x + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                    //}
                }
                Dset.收费项目.Rows.Add(myrow);

                x = 0;
                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        //if (dataGridView1.Columns[i].Visible == true)
                        //{
                        x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                        //}
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }



                ParameterEx[] parameters = new ParameterEx[15];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "填报人";
                parameters[2].Value = InstanceForm.BCurrentUser.Name;

                parameters[3].Text = "rq1";
                parameters[3].Value = dtpjsrq1.Value.ToString();

                parameters[4].Text = "rq2";
                parameters[4].Value = dtpjsrq2.Value.ToString();

                parameters[5].Text = "卡号";
                parameters[5].Value = lblkh.Text;

                parameters[6].Text = "姓名";
                parameters[6].Value = lblxm.Text;

                parameters[7].Text = "性别";
                parameters[7].Value = lblxb.Text;

                parameters[8].Text = "年龄";
                parameters[8].Value = lblnl.Text;

                parameters[9].Text = "联系电话";
                parameters[9].Value = lbllxdh.Text;

                parameters[10].Text = "家庭地址";
                parameters[10].Value = lbljtdz.Text;

                parameters[11].Text = "家庭电话";
                parameters[11].Value = lbljtdh.Text;

                parameters[12].Text = "工作单位";
                parameters[12].Value = lblgzdw.Text;

                parameters[13].Text = "身份证号";
                parameters[13].Value = lblsfzh.Text;

                parameters[14].Text = "当前余额";
                parameters[14].Value = lblye.Text;

                bool bprint = chkprint.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_预交款对帐单.rpt", parameters, bprint);

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

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {

                DataTable tb = (DataTable)this.dataGridView1.DataSource;

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
                string swhere = "卡号:" + lblkh.Text + " 姓名:" + lblxm.Text + " 身份证号:" + lblsfzh.Text + " 日期从:" + dtpjsrq1.Value.ToString() + "　到 " + dtpjsrq2.Value.ToString();


                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "预交款对帐明细单";
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

        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                kdjid = Guid.Empty;
                brxxid = Guid.Empty;
                if ((int)e.KeyChar == 13)
                {
                    DataTable tb = (DataTable)dataGridView1.DataSource;
                    if (tb != null) tb.Rows.Clear();

                    txtkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
                    ReadCard readcard = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
                    if (readcard.kdjid != Guid.Empty)
                    {
                        kdjid = readcard.kdjid;
                        brxxid = readcard.brxxid;
                        lblye.Text = readcard.kye.ToString();
                        lblkh.Text = readcard.kh;
                        lblgrzhbh.Text = readcard.grzhbh;
                    }
                    else
                    {
                        kdjid = Guid.Empty;
                        brxxid = Guid.Empty;
                        lblye.Text = "";
                        lblkh.Text = "";
                        lblgrzhbh.Text = "";
                    }

                    FillBrxx(brxxid);
                    buttj_Click(sender, e);
                    SendKeys.Send("{TAB}");
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillBrxx(Guid brxxid)
        {
            YY_BRXX brxx = new YY_BRXX(brxxid, InstanceForm.BDatabase);

            lblxm.Text = brxx.Brxm;
            lblxb.Text = brxx.Xb;
            if (brxx.Csrq.Trim() != "")
            {
                //Modify By Zj 2012-03-28 获得年龄统一使用函数获得
                //lblnl.Text = DateManager.DateToAge(Convert.ToDateTime(brxx.Csrq), TrasenFrame.Forms.FrmMdiMain.Database).AgeNum.ToString();
                lblnl.Text = InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_AGE('" + Convert.ToDateTime(brxx.Csrq).ToString("yyyy-MM-dd 00:00:00") + "',3,getdate())").ToString();
            }
            else
            {
                lblnl.Text = "";
            }

            lbllxdh.Text = brxx.Brlxfs;

            lblsfzh.Text = brxx.Sfzh;
            lbljtdz.Text = brxx.Jtdz;
            lbljtdh.Text = brxx.Jtdh;

            lblgzdw.Text = brxx.Gzdw;
            lbljksj.Text = brxx.Djsj;

            lblxb.Text = InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_SEEKSEXNAME(" + brxx.Xb + ")").ToString();


        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {

                MenuTag tag = new MenuTag();
                tag = _menuTag;
                ts_mz_kgl.Frmbrxxcx f = new ts_mz_kgl.Frmbrxxcx(tag, "病人查询", null);
                f.chkdjsj.Checked = true;
                f.txtbrxm.Focus();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();

                ReadCard card = new ReadCard(f.return_kdjid, InstanceForm.BDatabase);
                if (card.kdjid != Guid.Empty)
                {
                    cmbklx.SelectedValue = card.klx;
                    txtkh.Text = card.kh;
                    txtkh.Focus();
                    txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    if (f.bok == true)
                    {
                        MessageBox.Show("只能检索有卡的病人", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}