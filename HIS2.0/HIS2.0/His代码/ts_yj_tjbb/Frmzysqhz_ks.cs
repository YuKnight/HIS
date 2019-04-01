using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_yj_class;


namespace ts_yj_tjbb
{
    public partial class Frmzysqhz_ks : Form
    {
        public  User _currentUser;			//当前操作员
        public  Department _currentDept;		//当前登录科室
        public int _jgbm;
        public DataTable tb;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbitem;
        public Frmzysqhz_ks(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            
        }


        #region  按钮事件
        //刷新按钮
        private void btrefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@JGBM";
                parameters[1].Text = "@ZXKS";
                parameters[2].Text = "@SQKS";
                parameters[3].Text = "@QRRQ1";
                parameters[4].Text = "@QRRQ2";
                parameters[5].Text = "@YZXMID";

                parameters[0].Value = Convert.ToInt32(cmbjgbm.SelectedValue);
                parameters[1].Value = Convert.ToInt32(Convertor.IsNull(cmbzxks.SelectedValue,"0"));
                parameters[2].Value = Convert.ToInt32(Convertor.IsNull(cmbks.SelectedValue, "0"));
                parameters[3].Value = dtpqrrq1.Value.ToShortDateString() ;
                parameters[4].Value = dtpqrrq2.Value.ToShortDateString();
                parameters[5].Value = Convertor.IsNull(txtjcxm.Tag, "0");
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YJ_tj_zyhz_ks", parameters, 60);
                Fun.AddRowtNo(tb);
                dgvyjsq.DataSource = tb;

                //decimal je =Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(金额)", ""),"0"));
                //this.statusBar1.Panels[0].Text ="总金额:"+ je.ToString();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        #endregion


        private void Frmyjsq_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm,InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;
            Tbitem = select.SelectOrderItem(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);
        }

       

        private void txtjcxm_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                Control control = (Control)sender;
                if ((int)e.KeyChar == 13) { return; };
                if ((int)e.KeyChar == 8) { txtjcxm.Text = ""; txtjcxm.Tag = "0"; return; };

                string[] headtext = new string[] { "项目名称", "单位", "orderid", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "item_name", "item_unit", "orderid", "py_code", "wb_code" };
                string[] searchfields = new string[] { "item_name", "py_code", "wb_code" };
                int[] colwidth = new int[] { 300, 50, 0, 100, 80 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbitem;
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 600;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    this.txtjcxm.Text = f.SelectDataRow["item_name"].ToString().Trim();
                    this.txtjcxm.Tag = f.SelectDataRow["orderid"].ToString().Trim();

                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btApplyAffirm_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)dgvyjsq.DataSource;

                DataSet1 Dset = new DataSet1();

                DataRow myrow = Dset.项目.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.项目.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.项目内容.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                    }
                    Dset.项目内容.Rows.Add(myrow1);
                }


                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "备注";
                parameters[1].Value = "医技科室:" + cmbzxks.Text+"  申请科室:"+cmbks.Text;

                string bz1= "确认日期从:" + dtpqrrq1.Value.ToShortDateString() + " 到 " + dtpqrrq2.Value.ToShortDateString() + "  ";
                if (txtjcxm.Text.Trim()!="") bz1=bz1+" 项目名称:"+txtjcxm.Text.Trim();
                parameters[2].Text = "备注1";
                parameters[2].Value = bz1;

                TrasenFrame.Forms.FrmReportView f;

                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\YJ_项目科室汇总统计.rpt", parameters);

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

        private void butexcel_Click(object sender, EventArgs e)
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
                swhere = "医技科室:" + cmbzxks.Text + "  申请科室:" + cmbks.Text;

                string swhere1 = "确认日期从:" + dtpqrrq1.Value.ToShortDateString() + " 到 " + dtpqrrq2.Value.ToShortDateString() + "  ";
                if (txtjcxm.Text.Trim()!="")
                swhere1 = swhere1 + " 项目名称:" + txtjcxm.Text.Trim();


                //写入行头
                DataTable tb = (DataTable)this.dgvyjsq.DataSource;
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
                string ss = this.Text;
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

                myExcel.Cells[4, 1] = swhere1.Trim();
                myExcel.get_Range(myExcel.Cells[4, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[4, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[4, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

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

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                InstanceForm.BDatabase = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(cmbjgbm.SelectedValue));

                Fun.AddcmbYjks(cmbzxks, 1, 0, Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);
                Fun.AddcmbZyks(cmbks, 1, 0, Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);
                cmbzxks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                btrefresh_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}