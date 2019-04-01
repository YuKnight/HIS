using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrasenFrame.Forms
{
    public partial class FrmSelectTarget : Form
    {
        public delegate void OnAfterSelectedHandler( TrasenFrame.Classes.ReportPaper.PrinterTargetType type , string printName );

        private event OnAfterSelectedHandler onAfterSelected;
        public event OnAfterSelectedHandler OnAfterSelected
        {
            add
            {
                onAfterSelected += value;
            }
            remove
            {
                onAfterSelected -= value;
            }
        }

        private string _reportName;

        private FrmSelectTarget()
        {
            InitializeComponent();
        }

        private string __printerName  ;
        private int __printType;
        private bool bLoad = false;
        
        public FrmSelectTarget( string printerName , int printType )
        {
            InitializeComponent();
            __printType = printType;
            __printerName = printerName;
            bLoad = true;
        }

        private FrmSelectTarget( string reportName )
        {
            InitializeComponent();
            _reportName = reportName;
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmSelectTarget_Load( object sender , EventArgs e )
        {
            foreach ( object obj in Enum.GetValues( typeof( TrasenFrame.Classes.ReportPaper.PrinterTargetType ) ) )
            {
                cboType.Items.Add( obj );
            }
            cboType.SelectedIndexChanged += new EventHandler( cboType_SelectedIndexChanged );

            TrasenFrame.Classes.PrinterManager pm = new TrasenFrame.Classes.PrinterManager();
            List<TrasenFrame.Classes.Printer> printers = pm.GetConfiguredPrinters();
            foreach ( TrasenFrame.Classes.Printer p in printers )
                cboPrinter.Items.Add( p.Name );
            if ( !cboPrinter.Items.Contains( "" ) )
                cboPrinter.Items.Insert( 0 , "" );

            if ( bLoad )
            {
                this.cboType.SelectedItem = (TrasenFrame.Classes.ReportPaper.PrinterTargetType)__printType;
                this.cboPrinter.Text = __printerName;
            }
        }

        void cboType_SelectedIndexChanged( object sender , EventArgs e )
        {
            if ( cboType.SelectedItem != null )
            {
                TrasenFrame.Classes.ReportPaper.PrinterTargetType t = (TrasenFrame.Classes.ReportPaper.PrinterTargetType)cboType.SelectedItem;
                if ( t != TrasenFrame.Classes.ReportPaper.PrinterTargetType.自定义打印机 )
                {
                    cboPrinter.Enabled = false;
                    if ( t == TrasenFrame.Classes.ReportPaper.PrinterTargetType.报表打印机 )
                        cboPrinter.Text = TrasenFrame.Classes.Constant.CReportPrinterName;
                    else if ( t == TrasenFrame.Classes.ReportPaper.PrinterTargetType.发票打印机 )
                        cboPrinter.Text = TrasenFrame.Classes.Constant.CInvoicePrinterName;
                }
                else
                {
                    cboPrinter.Enabled = true;
                }
            }
        }

        private void btnOK_Click( object sender , EventArgs e )
        {
            if ( cboType.SelectedIndex == -1 )
                return;

            if ( onAfterSelected != null )
            {
                onAfterSelected( (TrasenFrame.Classes.ReportPaper.PrinterTargetType)cboType.SelectedItem ,
                    cboPrinter.Text );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public static bool SetReportPaperPrinterConfig( string reportName ,out int Type,out string PrintName )
        {
            int _Type = 0;
            string _PrintName = "";
            FrmSelectTarget dlgSelected = new FrmSelectTarget( reportName );
            dlgSelected.OnAfterSelected += delegate( TrasenFrame.Classes.ReportPaper.PrinterTargetType type , string printName )
            {                
                TrasenFrame.Classes.ReportPaper.SetReportPaperPrinter( reportName , printName , (int)type );
                _Type = (int)type;
                _PrintName = printName;
            };
            Type = 0;
            PrintName = "";
            if ( dlgSelected.ShowDialog() == DialogResult.OK )
            {
                Type = _Type;
                PrintName = _PrintName;
                dlgSelected.Close();
                return true;
            }
            else
            {
                dlgSelected.Close();
                return false;
            }
        }
    }
}