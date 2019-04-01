using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Classes;
using System.Threading;
using TrasenFrame.Forms;

namespace ts_mz_tjbb
{
    public partial class FrmMZYSJZLTJ : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据
        private FrmExportFlash flash = new FrmExportFlash();

        public FrmMZYSJZLTJ( MenuTag menuTag , string chineseName , Form mdiParent )
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            this.Load += new EventHandler( FrmMZYSJZLTJ_Load );
        }

        void FrmMZYSJZLTJ_Load( object sender , EventArgs e )
        {
            dtp1.Value = Convert.ToDateTime( DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToShortDateString() + " 00:00:00" );
            dtp2.Value = Convert.ToDateTime( DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToShortDateString() + " 23:59:59" );
            FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            cmbjgbm.Enabled = false;

            FunAddComboBox.AddGhjb(true, 0, cmbghjb, InstanceForm.BDatabase);

            Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);

            cmbpx.SelectedIndex = 0;
        }

        private void buttj_Click( object sender , EventArgs e )
        {
            Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
            this.buttj.Enabled = false;
            this.butprint.Enabled = false;
            this.butquit.Enabled = false;
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@jgbm";
                parameters[2].Value = Convert.ToInt32( Convertor.IsNull( cmbjgbm.SelectedValue , "0" ) );

                parameters[3].Text = "@jzks";
                parameters[3].Value = txtks.Text.Trim()==""?"0":Convertor.IsNull(txtks.Tag, "0");

                parameters[4].Text = "@jzys";
                parameters[4].Value = txtys.Text.Trim() == "" ? "0" : Convertor.IsNull(txtys.Tag, "0");

                parameters[5].Text = "@ghjb";
                parameters[5].Value = Convertor.IsNull(cmbghjb.SelectedValue, "0");

                parameters[6].Text = "@sortid";
                parameters[6].Value = cmbpx.SelectedIndex;

                DataTable tb;
               
                tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( "SP_MZSF_TJ_YSJZLTJ" , parameters , 30 );
                Fun.AddRowtNo(tb);
                this.dgvList.DataSource = tb;

            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                Cursor = Cursors.Default;
                buttj.Enabled = true;
                this.butprint.Enabled = true;
                this.butquit.Enabled = true;
            }
        }

        private void butprint_Click( object sender , EventArgs e )
        {
            if ( dgvList.DataSource == null )
                return;
            try
            {
                DataTable tbmx = (DataTable)dgvList.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
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


                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "统计时间";
                parameters[1].Value = this.dtp1.Value.ToString("yyyy-MM-dd HH:mm:ss") + " ～ " + this.dtp2.Value.ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "制表人";
                parameters[2].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;

                string ss = "";
                if (txtks.Text.Trim() != "") ss = " 接诊科室：" + txtks.Text.Trim();
                if (cmbghjb.SelectedIndex!=0) ss =ss+ " 接诊级别：" + cmbghjb.Text.Trim();
                if (txtys.Text.Trim() != "") ss =ss+ " 接诊医生：" + txtys.Text.Trim();

                parameters[3].Text = "其它条件";
                parameters[3].Value = ss;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_门诊医生接诊量统计.rpt", parameters);

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

        private void butquit_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void btnExcel_Click( object sender , EventArgs e )
        {
            if ( dgvList.DataSource == null )
                return;
            try
            {
                if ( dgvList.DataSource == null )
                    return;
                if ( dgvList.Rows.Count == 0 )
                    return;

                this.Cursor = PubStaticFun.WaitCursor();
                this.btnExcel.Enabled = false;
                ExportToExcel();
                 
            }
            catch ( System.Exception err )
            {
                
                MessageBox.Show( err.Message );
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                this.btnExcel.Enabled = true;
            }
        }

        /// <summary>
        /// 导出到EXCEL
        /// </summary>
        private void ExportToExcel()
        {
            DataTable dtData = (DataTable)this.dgvList.DataSource;

            int SumColCount = dtData.Columns.Count;
            int rowCount = dtData.Rows.Count;


            Excel.Application myExcel = new Excel.Application();
            myExcel.Application.Workbooks.Add( true );
            
            string xm = "";
            xm = "   院区:" + cmbjgbm.Text;
            string swhere = "日期从:" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString() + xm;

            string title = Constant.HospitalName + label1.Text;

            //写标题行
            int excelRowIndex = 1;
            myExcel.Cells[excelRowIndex , 1] = title;
            myExcel.get_Range( myExcel.Cells[excelRowIndex , 1] , myExcel.Cells[excelRowIndex , SumColCount] ).Merge( Type.Missing );
            myExcel.get_Range( myExcel.Cells[excelRowIndex , 1] , myExcel.Cells[excelRowIndex , SumColCount] ).Font.Bold = true;
            myExcel.get_Range( myExcel.Cells[excelRowIndex , 1] , myExcel.Cells[excelRowIndex , SumColCount] ).Font.Size = 16;

            //写收费员及日期
            excelRowIndex++;

            myExcel.Cells[excelRowIndex , 1] = swhere;
            myExcel.get_Range( myExcel.Cells[excelRowIndex , 1] , myExcel.Cells[excelRowIndex , SumColCount] ).Merge( Type.Missing );

            //写表格列头
            excelRowIndex++;
            int grdStartRow = excelRowIndex;

            int excelColIndex = 0;
            for ( int i = 0 ; i < dgvList.Columns.Count ; i++ )
            {
                excelColIndex = i + 1;
                myExcel.Cells[excelRowIndex , excelColIndex] = dgvList.Columns[i].HeaderText;                
            }
            

            //写数据
            excelRowIndex ++;
            //excelColIndex = 1;
            //for ( int i = 0 ; i < dgvList.Rows.Count ; i++ )
            //{
            //    excelColIndex = 1;
            //    for ( int j = 0 ; j < dgvList.Columns.Count ; j++ )
            //    {
            //        myExcel.Cells[excelRowIndex , excelColIndex] = dgvList[j , i].Value;
            //        excelColIndex++;
            //    }
            //    excelRowIndex++;
            //}
            ExcelDataExport export = new ExcelDataExport( myExcel , dgvList , excelRowIndex );
            export.Exporting += new ExportingHandle( export_Exporting );
            int r , c;
            export.Export( out r , out c );
            excelRowIndex = r;
            excelColIndex = c;

            //选中明细网格
            myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Select();
            myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Columns.AutoFit();
            //居中
            myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).HorizontalAlignment = Excel.Constants.xlCenter;
            myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).VerticalAlignment = Excel.Constants.xlCenter;
            //网格线
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Select();
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.Constants.xlNone;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.Constants.xlNone;

            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;

            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
            myExcel.get_Range( myExcel.Cells[grdStartRow , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;

            myExcel.ActiveWindow.DisplayGridlines = false;

            myExcel.Visible = true;

        }

        void export_Exporting( int totalRow , int row )
        {
            try
            {
                if ( !flash.Visible )
                {
                    flash.Show();
                    flash.Refresh();
                }

                if ( row <= totalRow )
                {
                    flash.TotalCount = totalRow;
                    flash.CurrentCount = row;
                    if ( totalRow == row )
                        flash.Hide();
                }
                else
                {
                    flash.Hide();
                }
            }
            catch
            {
            }
        }


        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {

            Control control = (Control)sender;
            if ((int)e.KeyChar == 8) { txtys.Text = ""; txtys.Tag = ""; return; }
            if ((int)e.KeyChar == 8) { txtks.Text = ""; txtks.Tag = ""; return; }
            if ((int)e.KeyChar == 46) { txtys.Text = ""; txtys.Tag = ""; return; }
            if ((int)e.KeyChar == 46) { txtks.Text = ""; txtks.Tag = ""; return; }

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
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtks.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtks.Text = f.SelectDataRow["name"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtks.Text.Trim() == "")
                {
                    txtks.Focus();
                    return;
                }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtys_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8) { txtys.Text = ""; txtys.Tag = ""; return; }
            if ((int)e.KeyChar == 8) { txtks.Text = ""; txtks.Tag = ""; return; }
            if ((int)e.KeyChar == 46) { txtys.Text = ""; txtys.Tag = ""; return; }
            if ((int)e.KeyChar == 46) { txtks.Text = ""; txtks.Tag = ""; return; }
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
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtys.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtys.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtys.Text = f.SelectDataRow["name"].ToString().Trim();
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }

            }
            else
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }

        }


    }
}