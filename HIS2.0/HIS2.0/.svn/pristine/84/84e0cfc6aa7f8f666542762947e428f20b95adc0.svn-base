using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using ts_yp_kjbb.Condiction;
using grproLib;

namespace ts_yp_kjbb
{

    public partial class UCReport : UserControl
    {
        public UCReport()
        {
            InitializeComponent();
        }
        
        private ReportInfo ri;
        public event OnCloseReportHandle CloseReport;
        public void InitializeControl(ReportInfo info)
        {
            object objControl = this.GetType().Assembly.CreateInstance(info.CondictionControlName);
            UserControl uc = (UserControl)objControl;
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(uc);
            ri = info;
            if (!InstanceForm.BCurrentUser.IsAdministrator)
                checkBox1.Visible = false;
        }

        private void CreateReportTemplate( ReportInfo info , DataTable printTable )
        {
            GridppReport Report = new GridppReport();
            Report.InsertReportHeader();
            Report.InsertDetailGrid();
            foreach ( DataColumn col in printTable.Columns )
            {
                GRFieldType grFieldType = ConvertToGRFieldType( col.DataType );
                
                Report.DetailGrid.Recordset.AddField( col.ColumnName , grFieldType );
                IGRColumn c = Report.DetailGrid.Columns.Add();
                c.Name = col.ColumnName;
                c.TitleCell.Text = col.ColumnName;
                c.ContentCell.DataField = col.ColumnName;
            }
            if ( info.ReportParameters != null )
            {
                for ( int i = 0 ; i < info.ReportParameters.Length ; i++ )
                {
                    if ( Report.Parameters.IndexByName( info.ReportParameters[i].Text ) < 0 )
                    {
                        IGRParameter p = Report.Parameters.Add();
                        p.Name = info.ReportParameters[i].Text;
                        p.DataType = GRParameterDataType.grptString;
                    }
                }
            }            
            Report.SaveToFile( info.TemplateFile );
        }

        private void UpdateReportTemplate( ReportInfo info , DataTable printTable )
        {
            if ( !this.checkBox1.Checked )
                return;

            GridppReport Report = new GridppReport();
            bool bChanged = false;
            Report.LoadFromFile( ri.TemplateFile );
            if ( ri.ReportParameters != null )
            {
                for ( int i = 0 ; i < ri.ReportParameters.Length ; i++ )
                {
                    if ( Report.Parameters.IndexByName( ri.ReportParameters[i].Text ) < 0 )
                    {
                        IGRParameter p = Report.Parameters.Add();
                        p.Name = ri.ReportParameters[i].Text;
                        p.DataType = GRParameterDataType.grptString;
                        bChanged = true;
                    }                    
                }
            }
            if ( printTable != null )
            {
                if ( Report.DetailGrid == null )
                    Report.InsertDetailGrid();

                foreach ( DataColumn dtcol in printTable.Columns )
                {
                    GRFieldType grFieldType = ConvertToGRFieldType( dtcol.DataType );
                    if ( Report.DetailGrid.Recordset.Fields.IndexByName( dtcol.ColumnName ) < 0 )
                    {
                        Report.DetailGrid.Recordset.AddField( dtcol.ColumnName , grFieldType );
                        IGRColumn c = Report.DetailGrid.Columns.Add();
                        c.Name = dtcol.ColumnName;
                        c.TitleCell.Text = dtcol.ColumnName;
                        c.ContentCell.DataField = dtcol.ColumnName;
                        bChanged = true;
                    }
                }
            }

            if ( bChanged )
                Report.SaveToFile( ri.TemplateFile ); 
        }

        private GRFieldType ConvertToGRFieldType(Type type )
        {
            GRFieldType grFieldType = GRFieldType.grftString;
            if ( type == typeof( System.Int16 ) || type == typeof( System.Int32 ) || type == typeof( System.Int64 ) )
                grFieldType = GRFieldType.grftInteger;
            if ( type == typeof( System.DateTime ) )
                grFieldType = GRFieldType.grftDateTime;
            if ( type == typeof( float ) || type == typeof( double ) || type == typeof( System.Decimal ) )
                grFieldType = GRFieldType.grftFloat;
            if ( type == typeof( System.Byte[] ) )
                grFieldType = GRFieldType.grftBinary;
            if ( type == typeof( bool ) )
                grFieldType = GRFieldType.grftBoolean;
            return grFieldType;
        }

        private void btnState_Click( object sender , EventArgs e )
        {
            try
            {
                
                btnState.Enabled = false;
                btnPrint.Enabled = false;
                string message = "";
                bool bOk = ( (ISelectionItemValidate)this.panel3.Controls[0] ).Validing( out message );
                if ( !bOk )
                    throw new Exception( message );

                ParameterEx[] parameters = ( (IParameterEx)this.panel3.Controls[0] ).GetStoreProcedureParameters();
                ri.ReportParameters = ( (IParameterEx)this.panel3.Controls[0] ).GetReportParameters();

                DataTable printTable = InstanceForm.BDatabase.GetDataTable( ri.StoreProcudeName , parameters );

                if ( !System.IO.File.Exists( ri.TemplateFile ) )
                    CreateReportTemplate( ri , printTable );
                else
                    UpdateReportTemplate( ri , printTable );

                GridppReport Report = new GridppReport();

                Report.LoadFromFile( ri.TemplateFile );
                if ( ri.ReportParameters != null )
                {
                    for ( int i = 0 ; i < ri.ReportParameters.Length ; i++ )
                    {
                        if ( Report.Parameters.IndexByName( ri.ReportParameters[i].Text ) >= 0 )
                            Report.ParameterByName( ri.ReportParameters[i].Text ).AsString = ri.ReportParameters[i].Value.ToString();
                    }
                }

                Report.FetchRecord += delegate()
                {
                    int index;
                    MatchFieldPairType[] typeArray = new MatchFieldPairType[printTable.Columns.Count];
                    int num = 0;
                    for ( index = 0 ; index < printTable.Columns.Count ; index++ )
                    {
                        foreach ( grproLib.IGRField field in Report.DetailGrid.Recordset.Fields )
                        {
                            if ( string.Compare( field.Name , printTable.Columns[index].ColumnName , true ) == 0 )
                            {
                                typeArray[num].grField = field;
                                typeArray[num].MatchColumnIndex = index;
                                num++;
                                break;
                            }
                        }
                    }
                    foreach ( DataRow row in printTable.Rows )
                    {
                        Report.DetailGrid.Recordset.Append();
                        for ( index = 0 ; index < num ; index++ )
                        {
                            if ( !row.IsNull( typeArray[index].MatchColumnIndex ) )
                            {
                                typeArray[index].grField.Value = row[typeArray[index].MatchColumnIndex];
                            }
                        }
                        Report.DetailGrid.Recordset.Post();
                    }
                };
                
                this.axGRDisplayViewer1.Stop();
                this.axGRDisplayViewer1.Report = Report;
                this.axGRDisplayViewer1.ResizeColumnToFitPage();
                this.axGRDisplayViewer1.Start();

                btnState.Enabled = true;
                btnPrint.Enabled = true;
            }
            catch ( Exception error )
            {
                MessageBox.Show( error.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                btnState.Enabled = true;
                btnPrint.Enabled = true;
            }
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (chkpreview.Checked)
            {
                if (this.axGRDisplayViewer1.Report != null)
                    this.axGRDisplayViewer1.Report.PrintPreview(true);
            }
            else
            {
                if (this.axGRDisplayViewer1.Report != null)
                    this.axGRDisplayViewer1.Report.Print(true);
            }

        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            CloseReport( ri );
        }

        private void btnImportOut_Click(object sender, EventArgs e)
        {
            if (this.axGRDisplayViewer1.Report != null)
                this.axGRDisplayViewer1.Report.ExportDirect(GRExportType.gretXLS, string.Format("{0}{1}", ri.ReportName, DateTime.Now.ToShortDateString()), true, true);
        }

    }
}
