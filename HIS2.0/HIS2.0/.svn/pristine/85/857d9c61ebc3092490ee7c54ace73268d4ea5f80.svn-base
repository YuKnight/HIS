using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Trasen.Print.Implement.Grid__
{
    public class Grid十十ReportPrinter : BaseReportPrinter
    {
        [System.Runtime.InteropServices.StructLayout( System.Runtime.InteropServices.LayoutKind.Sequential )]
        internal struct MatchFieldPairType
        {
            public grproLib.IGRField grField;
            public int MatchColumnIndex;
        }

        grproLib.GridppReport grdrpt;

        DataTable printTable;

        public Grid十十ReportPrinter()
        {
            grdrpt = new grproLib.GridppReport();
            grdrpt.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler( grdrpt_FetchRecord );
        }

        void grdrpt_FetchRecord()
        {
            if( printTable == null )
                return;

            int index;
            MatchFieldPairType[] typeArray = new MatchFieldPairType[printTable.Columns.Count];
            int num = 0;
            for( index = 0 ; index < printTable.Columns.Count ; index++ )
            {
                foreach( grproLib.IGRField field in grdrpt.DetailGrid.Recordset.Fields )
                {
                    if( string.Compare( field.Name , printTable.Columns[index].ColumnName , true ) == 0 )
                    {
                        typeArray[num].grField = field;
                        typeArray[num].MatchColumnIndex = index;
                        num++;
                        break;
                    }
                }
            }
            foreach( DataRow row in printTable.Rows )
            {
                grdrpt.DetailGrid.Recordset.Append();
                for( index = 0 ; index < num ; index++ )
                {
                    if( !row.IsNull( typeArray[index].MatchColumnIndex ) )
                    {
                        typeArray[index].grField.Value = row[typeArray[index].MatchColumnIndex];
                    }
                }
                grdrpt.DetailGrid.Recordset.Post();
            }

        }

        void SetParameters( ReportParameter[] parameters )
        {
            bool changed = false;
            if( parameters != null )
            {
                for( int i = 0 ; i < parameters.Length ; i++ )
                {
                    if( grdrpt.Parameters.IndexByName( parameters[i].Name ) == -1 )
                    {
                        grproLib.IGRParameter parameter = grdrpt.Parameters.Add();
                        parameter.Name = parameters[i].Name;
                        changed = true;
                    }
                    //else
                        grdrpt.ParameterByName( parameters[i].Name ).AsString = parameters[i].Value.ToString();
                }
                if( changed )
                    grdrpt.SaveToFile( FullReportTemplateFileName );
            }
        }

        public override void Print( ReportParameter[] parameters  )
        {
            grdrpt.LoadFromFile(FullReportTemplateFileName);
            grdrpt.Printer.PrinterName = PrinterName;

            SetParameters( parameters );

            if( Preview )
                grdrpt.PrintPreview( true );
            else
                grdrpt.Print( false );
        }

        public override void Print( ReportParameter[] parameters , DataTable dataTable )
        {
            grdrpt.LoadFromFile(FullReportTemplateFileName);
            grdrpt.Printer.PrinterName = PrinterName;

            SetParameters( parameters );

            printTable = dataTable;

            if( Preview )
                grdrpt.PrintPreview( true );
            else
                grdrpt.Print( false );
        }

        private grproLib.IGRParameter ValidateParameter( string name , string reportFileName )
        {
            grproLib.IGRParameter parameter = grdrpt.ParameterByName( name );
            if( parameter == null )
            {
                parameter = grdrpt.Parameters.Add();
                parameter.Name = name;
                grdrpt.SaveToFile( reportFileName );
            }
            return parameter;
        }
    }
}
