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

namespace ts_mz_cx
{
    public partial class Frmghxxcx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据
        private int Fplx;//发票类型 0 挂号票 1 收费票
        private string ghlb_ini="";
        private string klx_ini = "";
        private string kh_ini = "";
        private string xm_ini = "";
        private string xb_ini = "";
        private string nl_ini = "";
        private string lxfs_ini = "";
        private string jtdz_ini = "";
        private string brlx_ini = "";
        private string ghks_ini = "";
        private string ghjb_ini = "";
        private string ghys_ini = "";
        private string yblx_ini = "";
        private string readcard_ini = "";
        private string blb_ini = "";
        private string sfplx_ini = "";

        private string syk_ini = "";

        private string Bview = "";

        public Frmghxxcx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void Frmghdj_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            FunAddComboBox.AddBrlx(true, 0, cmbbrlx, InstanceForm.BDatabase);
            FunAddComboBox.AddGhlx(true, 0, cmbghlx, InstanceForm.BDatabase);
            FunAddComboBox.AddKlx(true, 0, cmbklx, InstanceForm.BDatabase);
            FunAddComboBox.AddGhjb(true, 0, cmbghjb, InstanceForm.BDatabase);
            FunAddComboBox.AddOperator(true, cmbsky, InstanceForm.BDatabase);
            Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
           
    
            #region 窗口输入项的控制
             //ghlb_ini = ApiFunction.GetIniString("挂号屏蔽项", "诊别", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //klx_ini = ApiFunction.GetIniString("挂号屏蔽项", "卡类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //kh_ini = ApiFunction.GetIniString("挂号屏蔽项", "卡号", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //xm_ini = ApiFunction.GetIniString("挂号屏蔽项", "姓名", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //xb_ini = ApiFunction.GetIniString("挂号屏蔽项", "性别", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //nl_ini = ApiFunction.GetIniString("挂号屏蔽项", "年龄", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //lxfs_ini = ApiFunction.GetIniString("挂号屏蔽项", "联系方式", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //jtdz_ini = ApiFunction.GetIniString("挂号屏蔽项", "家庭地址", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //brlx_ini = ApiFunction.GetIniString("挂号屏蔽项", "病人类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //ghks_ini = ApiFunction.GetIniString("挂号屏蔽项", "挂号科室", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //ghjb_ini = ApiFunction.GetIniString("挂号屏蔽项", "挂号级别", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //ghys_ini = ApiFunction.GetIniString("挂号屏蔽项", "挂号医生", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //yblx_ini = ApiFunction.GetIniString("挂号屏蔽项", "医保类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //readcard_ini = ApiFunction.GetIniString("挂号屏蔽项", "读卡", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //blb_ini = ApiFunction.GetIniString("挂号屏蔽项", "病历本", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //sfplx_ini = ApiFunction.GetIniString("划价收费", "挂号使用收费票", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //syk_ini = ApiFunction.GetIniString("挂号收费", "挂号时必须使用卡", Constant.ApplicationDirectory + "//ClientWindow.ini");
             //Bview = ApiFunction.GetIniString("划价收费", "发票预览", Constant.ApplicationDirectory + "//ClientWindow.ini");

            //Fplx = sfplx_ini == "true" ? 1 : 0;
            //cmbghlx.Enabled = ghlb_ini == "true" ? false : true;
            //cmbklx.Enabled = klx_ini == "true" ? false : true;
            //txtkh.Enabled = kh_ini == "true" ? false : true;
            //txtxm.Enabled = xm_ini == "true" ? false : true;

            //txtgrlxfs.Enabled = lxfs_ini == "true" ? false : true;
            //txtjtdz.Enabled = jtdz_ini == "true" ? false : true;
            //cmbbrlx.Enabled = brlx_ini == "true" ? false : true;
            //txtks.Enabled = ghks_ini == "true" ? false : true;
            //cmbghjb.Enabled = ghjb_ini == "true" ? false : true;
            //txtys.Enabled = ghys_ini == "true" ? false : true;

            #endregion


            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }


        /// <summary>
        /// 回车跳至下一个文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                //this.SelectNextControl(control, true,false, false,false);
                    SendKeys.Send("{TAB}");
                e.Handled = true;   
            }
        }


        private void ReadGhxx()
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[13];

                parameters[0].Text = "@djy";
                parameters[0].Value = InstanceForm.BCurrentUser.EmployeeId;

                parameters[1].Text = "@rq1";
                parameters[1].Value = DateTime.Now.ToShortDateString()+" 00:00:00";

                parameters[2].Text = "@rq2";
                parameters[2].Value = DateTime.Now.ToShortDateString() + " 23:59:59";

                parameters[3].Text = "@GHLB";
                parameters[3].Value = 0;

                parameters[4].Text = "@BRLX";
                parameters[4].Value = 0;

                parameters[5].Text = "@GHKS";
                parameters[5].Value = 0;

                parameters[6].Text = "@GHJB";
                parameters[6].Value = 0;

                parameters[7].Text = "@GHYS";
                parameters[7].Value = 0;

                parameters[8].Text = "@KLX";
                parameters[8].Value = 0;

                parameters[9].Text = "@kh";
                parameters[9].Value = "";

                parameters[10].Text = "@brxm";
                parameters[10].Value = "";

                parameters[11].Text = "@blh";
                parameters[11].Value = "";

                parameters[12].Text = "@px";
                parameters[12].Value = " DESC ";


                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_GHXX", parameters, 30);

                Fun.AddRowtNo(tb);
                this.dataGridView1.DataSource = tb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[14];

                parameters[0].Text = "@djy";
                parameters[0].Value =Convert.ToInt32(cmbsky.SelectedValue);

                parameters[1].Text = "@rq1";
                parameters[1].Value = dtp1.Value.ToShortDateString() + " 00:00:00";

                parameters[2].Text = "@rq2";
                parameters[2].Value = dtp2.Value.ToShortDateString() + " 23:59:59" ;

                parameters[3].Text = "@GHLB";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(cmbghlx.SelectedValue,"0"));

                parameters[4].Text = "@BRLX";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0")); ;

                parameters[5].Text = "@GHKS";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));

                parameters[6].Text = "@GHJB";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0")); ;

                parameters[7].Text = "@GHYS";
                parameters[7].Value = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));

                parameters[8].Text = "@KLX";
                parameters[8].Value = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")); ;

                parameters[9].Text = "@kh";
                parameters[9].Value = txtkh.Text.Trim();

                parameters[10].Text = "@brxm";
                parameters[10].Value = txtxm.Text.Trim();

                parameters[11].Text = "@blh";
                parameters[11].Value = txtmzh.Text.Trim();

                parameters[12].Text = "@px";
                parameters[12].Value = " ASC ";

                parameters[13].Text = "@fph";
                parameters[13].Value = txtfph.Text.Trim();

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_GHXX", parameters, 30);

                Fun.AddRowtNo(tb);
                this.dataGridView1.DataSource = tb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {

            Control control = (Control)sender;
            if ((int)e.KeyChar == 8) { control.Text = ""; control.Tag = "0"; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtks;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtks.Focus();
                }
                else
                {
                    txtks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtks.Text = f.SelectDataRow["name"].ToString().Trim();
                    //this.SelectNextControl(control, true, false, true, true);
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtks.Text.Trim() == "") { txtks.Focus(); return; }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtys_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8) { control.Text = ""; control.Tag = "0"; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtys;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtys.Focus();
                }
                else
                {
                    txtys.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtys.Text = f.SelectDataRow["name"].ToString().Trim();
                    //this.SelectNextControl(control, true, false, true, true);
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtys.Text.Trim() == "") { txtys.Focus(); return; }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtmzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar==13 && txtmzh.Text.Trim()!="")
                txtmzh.Text = Fun.returnMzh(txtmzh.Text, InstanceForm.BDatabase);
        }

        private void txtfph_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((int)e.KeyChar == 13 && txtfph.Text.Trim() != "")
            //txtfph.Text = Fun.returnFph(txtfph.Text);
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 && txtkh.Text.Trim() != "")
                txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
        }

        private void cmbklx_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtkh.Enabled = Convertor.IsNull(cmbklx.SelectedValue, "0") == "0" ? false : true;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["取消日期"].Value, "") != "")
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butdc_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butexcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string swhere = "";


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
                            myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();

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

        private void 修改合同单位信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;
            int nrow = this.dataGridView1.CurrentCell.RowIndex;
            Guid ghxxid = new Guid(tb.Rows[nrow]["ghxxid"].ToString());
            Frmxghtdw f = new Frmxghtdw(ghxxid);
            f.ShowDialog();
        }
 
    }
}