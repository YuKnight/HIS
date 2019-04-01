using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class FrmMZGHBLBZLKTJ : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private FrmExportFlash flash = new FrmExportFlash();

        public FrmMZGHBLBZLKTJ( MenuTag menuTag , string chineseName , Form mdiParent )
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Load += new EventHandler( FrmMZGHBLBZLKTJ_Load );
        }

        void FrmMZGHBLBZLKTJ_Load( object sender , EventArgs e )
        {
            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
            cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if ( cmbuser.SelectedValue == null )
                cmbuser.SelectedValue = "0";

            FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            dtp1.Value = Convert.ToDateTime( DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToShortDateString() + " 00:00:00" );
            dtp2.Value = Convert.ToDateTime( DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToShortDateString() + " 23:59:59" );

            CreatGridHeader();
        }

        private void buttj_Click( object sender , EventArgs e )
        {
            Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
            this.buttj.Enabled = false;
            this.butprint.Enabled = false;
            this.butquit.Enabled = false;
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@sfy";
                parameters[2].Value = Convert.ToInt32( Convertor.IsNull( cmbuser.SelectedValue , "0" ) );

                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt32( Convertor.IsNull( cmbjgbm.SelectedValue , "0" ) );

                DataTable tb;
                tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( "SP_MZTJ_BLB" , parameters , 30 );

                Fun.AddRowtNo( tb ,"NO",true);

                DataRow[] drs = tb.Select("收费员 is null");
                for (int i = 0; i < drs.Length; i++)
                    drs[i]["收费员"] = "合计";

                this.dgvList.DataSource = tb;
                CreatGridHeader();

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

        private void CreatGridHeader()
        {
            string cfgBlb = ( new SystemCfg( 1018 )).Config.Trim();

            DataTable dtKfy = InstanceForm.BDatabase.GetDataTable( "select sfxmid from jc_klx where sfxmid > 0 " );

            List<string> lstXMID = new List<string>();

            if ( cfgBlb.Trim().Length > 0 )
                lstXMID.AddRange( cfgBlb.Split( ",".ToCharArray() ) );

            foreach ( DataRow dr in dtKfy.Rows )
            {
                lstXMID.Add( dr["sfxmid"].ToString().Trim() );
            }

            string blb = "";
            foreach ( string s in lstXMID )
                blb += (s + ",");
            if ( !string.IsNullOrEmpty( blb ) )
            {
                blb = blb.Remove( blb.Length - 1 , 1 );
            }
            if ( blb.Trim() == "" )
                blb = "0";
            DataTable dtSFXM = InstanceForm.BDatabase.GetDataTable("select item_name from jc_hsitem where item_id in (" + blb + ")" );

            dgvList.Columns.Clear();
            this.dgvList.ColumnHeadersHeight = 50;
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvList.MultiSelect = false;

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.DataPropertyName = "NO";
            colId.HeaderText = "序号";
            colId.Width = 35;
            dgvList.Columns.Add( colId );

            DataGridViewTextBoxColumn colSfy = new DataGridViewTextBoxColumn();
            colSfy.DataPropertyName = "收费员";
            colSfy.HeaderText = "收费员";
            dgvList.Columns.Add( colSfy );

            foreach ( DataRow dr in dtSFXM.Rows )
            {
                string item_name = dr["item_name"].ToString().Trim();

                DataGridViewTextBoxColumn colSQ = new DataGridViewTextBoxColumn();
                colSQ.DataPropertyName = "收取_" + item_name;
                colSQ.HeaderText = "收取";
                

                DataGridViewTextBoxColumn colZF = new DataGridViewTextBoxColumn();
                colZF.DataPropertyName = "作废_" + item_name;
                colZF.HeaderText = "作废";
                
                DataGridViewTextBoxColumn colYX = new DataGridViewTextBoxColumn();
                colYX.DataPropertyName = "有效_" + item_name;
                colYX.HeaderText = "有效";

                dgvList.Columns.Add( colSQ );
                dgvList.Columns.Add( colZF );
                dgvList.Columns.Add( colYX );
            }
            int colIndex = 2;
            foreach ( DataRow dr in dtSFXM.Rows )
            {
                string item_name = dr["item_name"].ToString().Trim();
                dgvList.AddSpanHeader( colIndex , 3 , item_name );
                colIndex += 3;
            }
        }

        private void butquit_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void butprint_Click( object sender , EventArgs e )
        {
            try
            {
                if ( dgvList.DataSource == null )
                    return;
                if ( dgvList.Rows.Count == 0 )
                    return;

                this.Cursor = PubStaticFun.WaitCursor();
                this.butprint.Enabled = false;
                ExportToExcel();
                return;
            }
            catch ( System.Exception err )
            {
                
                MessageBox.Show( err.Message );
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                this.butprint.Enabled = true;
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
            xm = "   收费员:" + cmbuser.Text;
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
            excelRowIndex ++;
            int excelColIndex = 0;
            List<string> lstCatalog = new List<string>();
            for ( int i = 0 ; i < dgvList.Columns.Count ; i++ )
            {
                excelColIndex = i + 1;
                if ( i < 2 )
                {
                    myExcel.Cells[excelRowIndex , excelColIndex] = dgvList.Columns[i].DataPropertyName;
                    myExcel.get_Range( myExcel.Cells[excelRowIndex , excelColIndex] , myExcel.Cells[excelRowIndex + 1 , excelColIndex] ).Merge( Type.Missing );
                }
                else
                {
                    string temp = dgvList.Columns[i].DataPropertyName;
                    string[] temps = temp.Split( "_".ToCharArray() );

                    if ( !lstCatalog.Contains( temps[1] ) )
                    {
                        lstCatalog.Add( temps[1] );
                        myExcel.Cells[excelRowIndex , excelColIndex] = temps[1];
                    }
                    myExcel.Cells[excelRowIndex + 1 , excelColIndex] = temps[0];

                    
                }
            }
            for ( int i = 0 ; i < lstCatalog.Count ; i++ )
            {
                excelColIndex = 3 * ( i + 1 ) ;
                myExcel.get_Range( myExcel.Cells[excelRowIndex , excelColIndex] , myExcel.Cells[excelRowIndex , excelColIndex + 2] ).Select();
                myExcel.get_Range( myExcel.Cells[excelRowIndex , excelColIndex] , myExcel.Cells[excelRowIndex , excelColIndex + 2] ).Merge( Type.Missing );
            }

            //写数据
            excelRowIndex += 2;
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
            export.Export(out r,out c);
            excelRowIndex = r;
            excelColIndex = c;

            #region 网格样式调整
            myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[excelRowIndex-1 , excelColIndex -1] ).Select();
            //居中
            myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).HorizontalAlignment = Excel.Constants.xlCenter;
            myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).VerticalAlignment = Excel.Constants.xlCenter;
            //网格线
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Select();
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.Constants.xlNone;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.Constants.xlNone;

            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;

            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;

            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
            myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[excelRowIndex - 1 , excelColIndex - 1] ).Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;

            myExcel.ActiveWindow.DisplayGridlines = false;
            #endregion
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
    }
}