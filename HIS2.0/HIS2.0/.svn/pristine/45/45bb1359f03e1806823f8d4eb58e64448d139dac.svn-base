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
    public partial class Frmzxksmxsr : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//统计时发票记录张数
        private long Jkid = 0;//交款ID
        public Frmzxksmxsr(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            label1.Text = _chineseName;
            
            
        }

        private void Frmsk_jktj_Load(object sender, EventArgs e)
        {
          

            //FunAddComboBox.AddOperator(true, cmbuser);
            this.WindowState = FormWindowState.Maximized;

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            //cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            //if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            //if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
            //    this.cmbuser.SelectedValue = "0";
            cmbFG.Items.Add("列宽适应网格内容");
            cmbFG.Items.Add("列宽仅适应有数据的区域");
            cmbFG.SelectedIndex = 0;

            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            txtksdm.Text = InstanceForm.BCurrentDept.DeptName;
            txtksdm.Tag = InstanceForm.BCurrentDept.DeptId.ToString();
        }

       

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@BEGINDATE";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@tjly";
                parameters[2].Value =rdmz.Checked==true?0:1;


                parameters[3].Text = "@KSDM";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(txtksdm.Tag,"0"));

                parameters[4].Text = "@TJFS";
                parameters[4].Value = rdoqr.Checked == true ? 0 : 1;

                parameters[5].Text = "@jgbm";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_TJ_KSSRTJ_ZXKS_MX", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);

                this.dataGridView1.DataSource =dset.Tables[0] ;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void cmbFG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFG.SelectedIndex == 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 30;
                dataGridView1.Refresh();
            }
            if (cmbFG.SelectedIndex == 1)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butexcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);
                Excel._Worksheet ws = (Excel._Worksheet)myExcel.ActiveSheet;   
                //查询条件
                string xm="";
                if (rdmz.Checked == true)
                    xm = "   统计分类:经管项目";
                else
                    xm ="   统计分类:会计项目";
                string swhere = "日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm+"  部门名称:"+cmbjgbm.Text;;


                //写入行头
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    if (checkBox1.Checked == true)
                    {
                        if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" )
                        {
                            SumColCount = SumColCount + 1;
                            myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName.Trim();
                        }
                    }
                    else
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName.Trim();
                        
                    }

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 9;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        if (checkBox1.Checked == true)
                        {
                            if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" )
                            {
                                ncol = ncol + 1;
                                myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                            }
                        }
                        else
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                        }
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Font.Size = 9;

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = Constant.HospitalName+label1.Text;
                myExcel.Cells[1, 1] = ss ;
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
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                DataTable tbmx = (DataTable)dataGridView1.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow  myrow = Dset.收费项目.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.收费项目.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }
                

                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "统计来源";
                parameters[1].Value = rdmz.Checked == true ? "门诊" : "住院";

                parameters[2].Text = "统计类型";
                parameters[2].Value = rdoqr.Checked == true ? "确认情况" : "开单情况";

                parameters[3].Text = "rq1";
                parameters[3].Value = dtp1.Value.ToShortDateString();

                parameters[4].Text = "rq2";
                parameters[4].Value = dtp2.Value.ToShortDateString();

                parameters[5].Text = "jgbm";
                parameters[5].Value = cmbjgbm.Text;


                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\YY_执行科室收入明细情况.rpt", parameters);
               
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

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb!=null)
               tb.Rows.Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable tb = (DataTable)dataGridView1.DataSource;
            //    if (tb == null) return;
            //    if (dataGridView1.CurrentCell == null) return;

            //    int nrow = dataGridView1.CurrentCell.RowIndex;
            //    int ksdm = Convert.ToInt32(tb.Rows[nrow]["ksdm"]);
            //    ts_mz_tjbb.Frmkssrtj_mx frm = new Frmkssrtj_mx(_menuTag, _chineseName, _mdiParent);
            //    frm.dtp1.Value = dtp1.Value;
            //    frm.dtp2.Value = dtp2.Value;
            //    frm.cmbjgbm.SelectedValue = cmbjgbm.SelectedValue;
            //    frm.txtks.Text = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
            //    frm.txtks.Tag = ksdm.ToString();
            //    frm.btref_Click(sender, e);

            //    frm.txtks.Enabled = false;
            //    frm.cmbjgbm.Enabled = false;
                
            //    frm.ShowDialog();
            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtksdm_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtksdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            int nkey = (int)e.KeyChar;
            if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = InstanceForm.BDatabase.GetDataTable( "select * from jc_dept_property where deleted=0 and layer=3 ");
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                    return;
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                }
            }
        }

        private void rdmz_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null) return;
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb == null) return;
            tb.Rows.Clear();
        }



    }
}