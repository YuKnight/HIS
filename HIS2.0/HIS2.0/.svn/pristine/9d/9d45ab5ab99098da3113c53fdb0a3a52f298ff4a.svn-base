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
    public partial class FrmPrinterSetting : Form
    {
        public FrmPrinterSetting()
        {
            InitializeComponent();
            foreach( object obj in Enum.GetValues( typeof( PrinterType ) ) )
                COL_PRINTER_TYPE.Items.Add( ( (PrinterType)obj ).ToString() );

            dgvConfig.DataError += new DataGridViewDataErrorEventHandler( dgvConfig_DataError );
        }

        void dgvConfig_DataError( object sender , DataGridViewDataErrorEventArgs e )
        {
            e.Cancel = true;
        }

        private void FrmPrinterSetting_Load( object sender , EventArgs e )
        {
            //加载打印机
            List<Printer> printers = ( new PrinterManager() ).GetConfiguredPrinters();
            foreach( Printer pt in printers )
            {
                AddPrinterToGrid( pt );
            }
        }

        private void AddPrinterToGrid( Printer pt )
        {
            int row = dgvConfig.Rows.Add();
            dgvConfig[COL_PRINTERNAME.Name , row].Value = pt.Name;
            dgvConfig[COL_PRINTER_TYPE.Name , row].Value = pt.Type.ToString();
            dgvConfig[COL_PORT.Name , row].Value = pt.Port;
            dgvConfig[COL_NET_PRINT.Name , row].Value = pt.IsNetPrinter;
        }
        
        private void btnDetect_Click( object sender , EventArgs e )
        {
            PrinterManager printerManager = new PrinterManager();
            List<string> installedPrinters = printerManager.GetInstanlledPrinters();
            List<Printer> printers = ( new PrinterManager() ).GetConfiguredPrinters();
            dgvConfig.Rows.Clear();
            foreach( string name in installedPrinters )
            {
                Printer printer = printers.Find( delegate( Printer p )
                {
                    return p.Name == name;
                } );
                if( printer != null )
                {
                    AddPrinterToGrid( printer );
                    printers.Remove( printer );
                }
                else
                {
                    Printer newprinter = new Printer();
                    newprinter.Name = name;
                    newprinter.Type = PrinterType.未知类型;
                    newprinter.Port = "";
                    AddPrinterToGrid( newprinter );
                }
            }
            if( printers.Count != 0 )
            {
                foreach( Printer p in printers )
                {
                    AddPrinterToGrid( p );
                    int row = dgvConfig.Rows.Count - 1;
                    for( int i = 0 ; i < dgvConfig.Columns.Count ; i++ )
                    {
                        dgvConfig[i , row].Style.ForeColor = Color.DarkGray;
                    }
                }
                
            }
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            
            List<Printer> printers = new List<Printer>();
            foreach( DataGridViewRow row in dgvConfig.Rows )
            {
                Printer p = new Printer();
                p.Name = row.Cells[COL_PRINTERNAME.Name].Value.ToString();
                p.Type = GetPrinterType( row.Cells[COL_PRINTER_TYPE.Name].Value.ToString() );
                p.Port = row.Cells[COL_PORT.Name].Value.ToString();
                p.IsNetPrinter = Convert.ToBoolean( row.Cells[COL_NET_PRINT.Name].Value );
                printers.Add( p );
            }

            ( new PrinterManager() ).Save( printers );
            MessageBox.Show( "设置已保存!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
        }

        private PrinterType GetPrinterType( string typeName )
        {
            foreach( object obj in Enum.GetValues( typeof( PrinterType ) ) )
            {
                if( ( (PrinterType)obj ).ToString() == typeName )
                    return (PrinterType)obj;
            }
            return PrinterType.未知类型;
        }

        private void btnDel_Click( object sender , EventArgs e )
        {
            if( dgvConfig.CurrentCell != null )
            {
                
                string name = dgvConfig[COL_PRINTERNAME.Name , dgvConfig.CurrentCell.RowIndex].Value.ToString();
                if( MessageBox.Show( "确定要删除打印机" + name + "的配置吗?" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
                {
                    ( new PrinterManager() ).Delete( name );
                    dgvConfig.Rows.Remove( dgvConfig.Rows[dgvConfig.CurrentCell.RowIndex] );
                }
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (dgvConfig.RowCount > 0)
            {
                if (MessageBox.Show("确定要删除所有的打印机配置吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rows = dgvConfig.RowCount;
                    for (int i = rows; i > 0; i--)
                    {
                        string name = dgvConfig[COL_PRINTERNAME.Name,i-1].Value.ToString();
                        (new PrinterManager()).Delete(name);
                        dgvConfig.Rows.Remove(dgvConfig.Rows[i-1]);
                    }
                }
            }
        }

        private void btnReportPrinter_Click( object sender , EventArgs e )
        {
            FrmLocalReportPaperConfig frmReportPrint = new FrmLocalReportPaperConfig();
            frmReportPrint.ShowDialog( this );
        }
    }
}