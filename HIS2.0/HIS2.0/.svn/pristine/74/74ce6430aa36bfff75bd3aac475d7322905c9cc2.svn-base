using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;

namespace TrasenFrame.Forms
{
    public partial class FrmLocalReportPaperConfig : Form
    {
        private List<TrasenFrame.Classes.ReportPaper> reportPapers;

        private void AddRow( TrasenFrame.Classes.ReportPaper rp )
        {
            int row = dgvReport.Rows.Add();
            dgvReport[COL_REPORT_NAME.Name , row].Value = rp.ReportName;
            dgvReport[COL_PAPER_NAME.Name , row].Value = rp.PaperName;
            dgvReport[COL_WIDTH.Name , row].Value = rp.Width;
            dgvReport[COL_HEIGHT.Name , row].Value = rp.Height;
            dgvReport[COL_TYPE.Name , row].Value = rp.PrinterTagType.ToString();
            dgvReport[COL_PRINTER_NAME.Name , row].Value = rp.DefaultPrinterName;
        }

        public FrmLocalReportPaperConfig()
        {
            InitializeComponent();

            this.Load += new EventHandler( FrmLocalReportPaperConfig_Load );
            this.dgvReport.CellContentClick += new DataGridViewCellEventHandler( dgvReport_CellContentClick );
            this.dgvReport.RowPostPaint += new DataGridViewRowPostPaintEventHandler( dgvReport_RowPostPaint );
            cboSearchOption.SelectedIndexChanged += new EventHandler( cboSearchOption_SelectedIndexChanged );
        }

        void dgvReport_RowPostPaint( object sender , DataGridViewRowPostPaintEventArgs e )
        {
             Color color = dgvReport.RowHeadersDefaultCellStyle.ForeColor;
             if ( dgvReport.Rows[e.RowIndex].Selected )
                 color = dgvReport.RowHeadersDefaultCellStyle.SelectionForeColor;
            else
                 color = dgvReport.RowHeadersDefaultCellStyle.ForeColor;
            using (SolidBrush b = new SolidBrush(color))
            {
                e.Graphics.DrawString((e.RowIndex+1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X+20, e.RowBounds.Location.Y+6);
            }
        }

        void cboSearchOption_SelectedIndexChanged( object sender , EventArgs e )
        {
            cboEqute.Items.Clear();
            if ( cboSearchOption.Text == COL_REPORT_NAME.HeaderText || cboSearchOption.Text == COL_PAPER_NAME.HeaderText
                || cboSearchOption.Text == COL_PRINTER_NAME.HeaderText )
            {
                cboEqute.Items.AddRange( new string[] { "等于" , "包含字符" } );
            }
            else
            {
                cboEqute.Items.AddRange( new string[] { "大于" , "大于等于" , "等于" , "小于等于" , "小于" } );
            }

            cboValue.Items.Clear();
            foreach ( ReportPaper rp in reportPapers )
            {
                if ( cboSearchOption.Text == COL_REPORT_NAME.HeaderText )
                {
                    cboValue.Items.Add( rp.ReportName );
                }
                else if ( cboSearchOption.Text == COL_PAPER_NAME.HeaderText )
                {
                    if ( !cboValue.Items.Contains( rp.PaperName ) )
                        cboValue.Items.Add( rp.PaperName );
                }
                else if ( cboSearchOption.Text == COL_PRINTER_NAME.HeaderText )
                {
                    if ( !cboValue.Items.Contains( rp.DefaultPrinterName ) )
                        cboValue.Items.Add( rp.DefaultPrinterName );
                }
                else if ( cboSearchOption.Text == COL_WIDTH.HeaderText )
                {
                    if ( !cboValue.Items.Contains( rp.Width.ToString() ) )
                        cboValue.Items.Add( rp.Width.ToString() );
                }
                else
                {
                    if ( !cboValue.Items.Contains( rp.Height.ToString() ) )
                        cboValue.Items.Add( rp.Height.ToString() );
                }
            }
            cboValue.Text = "";
        }

        void dgvReport_CellContentClick( object sender , DataGridViewCellEventArgs e )
        {
            if ( e.RowIndex == -1 || e.ColumnIndex == -1 )
                return;

            if ( dgvReport.Columns[e.ColumnIndex].Name == COL_BUTTON.Name )
            {
                string reportName = dgvReport[COL_REPORT_NAME.Name , e.RowIndex].Value.ToString();
                int t = (int)TrasenFrame.Classes.ReportPaper.PrinterTargetType.自定义打印机;
                if ( dgvReport[COL_TYPE.Name , e.RowIndex].Value.ToString() == TrasenFrame.Classes.ReportPaper.PrinterTargetType.报表打印机.ToString() )
                    t = (int)TrasenFrame.Classes.ReportPaper.PrinterTargetType.报表打印机;
                if ( dgvReport[COL_TYPE.Name , e.RowIndex].Value.ToString() == TrasenFrame.Classes.ReportPaper.PrinterTargetType.发票打印机.ToString() )
                    t = (int)TrasenFrame.Classes.ReportPaper.PrinterTargetType.发票打印机;
                string pname = dgvReport[COL_PRINTER_NAME.Name , e.RowIndex].Value.ToString();

                FrmSelectTarget dlgSelected = new FrmSelectTarget( pname , t );

                dlgSelected.OnAfterSelected += delegate( TrasenFrame.Classes.ReportPaper.PrinterTargetType type , string printName )
                {

                    ReportPaper.SetReportPaperPrinter( reportName , printName , (int)type );
                    dgvReport[COL_TYPE.Name , e.RowIndex].Value = type.ToString();
                    dgvReport[COL_PRINTER_NAME.Name , e.RowIndex].Value = printName;
                    reportPapers = TrasenFrame.Classes.ReportPaper.LoadLocalReportPapers( TrasenFrame.Forms.FrmMdiMain.Database );
                };
                dlgSelected.ShowDialog();
                
                //静态方法调用测试
                //int t;
                //string name;
                //if ( FrmSelectTarget.SetReportPaperPrinterConfig( reportName , out t , out name ) )
                //{
                //    dgvReport[COL_TYPE.Name , e.RowIndex].Value = ((TrasenFrame.Classes.ReportPaper.PrinterTargetType)t).ToString();
                //    dgvReport[COL_PRINTER_NAME.Name , e.RowIndex].Value = name;
                //}
            }
        }

        void FrmLocalReportPaperConfig_Load( object sender , EventArgs e )
        {
            reportPapers = TrasenFrame.Classes.ReportPaper.LoadLocalReportPapers( TrasenFrame.Forms.FrmMdiMain.Database );
            foreach ( TrasenFrame.Classes.ReportPaper rp in reportPapers )
            {
                AddRow( rp );
            }

            cboSearchOption.Items.Add( COL_REPORT_NAME.HeaderText );
            cboSearchOption.Items.Add( COL_PAPER_NAME.HeaderText );
            cboSearchOption.Items.Add( COL_PRINTER_NAME.HeaderText );
            cboSearchOption.Items.Add( COL_WIDTH.HeaderText );
            cboSearchOption.Items.Add( COL_HEIGHT.HeaderText );
        }

        private void btnReset_Click( object sender , EventArgs e )
        {
            dgvReport.Rows.Clear();
            foreach ( TrasenFrame.Classes.ReportPaper rp in reportPapers )
            {
                AddRow( rp );
            }
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( cboSearchOption.Text.Trim() == "" )
            {
                MessageBox.Show( "查询项没有选择" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                cboSearchOption.Focus();
                return;
            }
            if ( cboEqute.Text.Trim() == "" )
            {
                MessageBox.Show( "条件没有选择" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                cboEqute.Focus();
                return;
            }
            dgvReport.Rows.Clear();
            foreach ( ReportPaper rp in reportPapers )
            {
                if ( cboSearchOption.Text == COL_REPORT_NAME.HeaderText )
                {
                    if ( rp.ReportName.IndexOf( cboValue.Text ) != -1 && cboEqute.Text == "包含字符" )
                        AddRow( rp );
                    else
                        if ( rp.ReportName == cboValue.Text )
                            AddRow( rp );
                }
                else if ( cboSearchOption.Text == COL_PAPER_NAME.HeaderText )
                {
                    if ( rp.PaperName.IndexOf( cboValue.Text ) != -1 && cboEqute.Text == "包含字符" )
                        AddRow( rp );
                    else
                        if ( rp.PaperName == cboValue.Text )
                            AddRow( rp );
                }
                else if ( cboSearchOption.Text == COL_PRINTER_NAME.HeaderText )
                {
                    if ( rp.DefaultPrinterName.IndexOf( cboValue.Text ) != -1 && cboEqute.Text == "包含字符" )
                        AddRow( rp );
                    else
                        if ( rp.DefaultPrinterName == cboValue.Text )
                            AddRow( rp );
                }
                else if ( cboSearchOption.Text == COL_WIDTH.HeaderText || cboSearchOption.Text == COL_HEIGHT.HeaderText)
                {
                    #region ...........
                    try
                    {
                        int val = Convert.ToInt32( cboValue.Text );
                        switch ( cboEqute.Text )
                        {
                            case "大于":
                                if ( ( cboSearchOption.Text == COL_WIDTH.HeaderText && rp.Width > val ) || ( cboSearchOption.Text == COL_HEIGHT.HeaderText && rp.Height > val ) )
                                    AddRow( rp );
                                break;
                            case "大于等于":
                                if ( ( cboSearchOption.Text == COL_WIDTH.HeaderText && rp.Width >= val ) || ( cboSearchOption.Text == COL_HEIGHT.HeaderText && rp.Height >= val ) )
                                    AddRow( rp );
                                break;
                            case "等于":
                                if ( ( cboSearchOption.Text == COL_WIDTH.HeaderText && rp.Width == val ) || ( cboSearchOption.Text == COL_HEIGHT.HeaderText && rp.Height == val ) )
                                    AddRow( rp );
                                break;
                            case "小于等于":
                                if ( ( cboSearchOption.Text == COL_WIDTH.HeaderText && rp.Width >= val ) || ( cboSearchOption.Text == COL_HEIGHT.HeaderText && rp.Height >= val ) )
                                    AddRow( rp );
                                break;
                            case "小于":
                                if ( ( cboSearchOption.Text == COL_WIDTH.HeaderText && rp.Width < val ) || ( cboSearchOption.Text == COL_HEIGHT.HeaderText && rp.Height < val ) )
                                    AddRow( rp );
                                break;
                        }
                    }
                    catch ( Exception error )
                    {
                        MessageBox.Show( error.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    }
                    #endregion
                }                
            }
        }

        private void btnSync_Click( object sender , EventArgs e )
        {
            TrasenFrame.Classes.ReportPaper.SyncPaperDefineFromServer( TrasenFrame.Forms.FrmMdiMain.Database );
            reportPapers = TrasenFrame.Classes.ReportPaper.LoadLocalReportPapers( TrasenFrame.Forms.FrmMdiMain.Database );
            dgvReport.Rows.Clear();
            foreach ( TrasenFrame.Classes.ReportPaper rp in reportPapers )
                AddRow( rp );            
            MessageBox.Show( "同步完成" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close();
        }
        
    }

}