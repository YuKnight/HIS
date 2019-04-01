using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Trasen.Print
{
    /// <summary>
    /// 基本打印类
    /// </summary>
    public abstract class BaseReportPrinter
    {
        private string printerName;
        private string reportTemplateFile;
        private bool preview;
        private string fullReportTemplateFileName;

        public string PrinterName
        {
            get { return printerName; }
            set { printerName = value; }
        }

        public string ReportTemplateFile
        {
            get { return reportTemplateFile; }
            set { reportTemplateFile = value; }
        }

        public bool Preview
        {
            get { return preview; }
            set { preview = value; }
        }

        protected string FullReportTemplateFileName
        {
            get
            {
                string folder = System.IO.Path.Combine(Environment.CurrentDirectory, "Templates");
                return System.IO.Path.Combine( folder , ReportTemplateFile );
                //return System.IO.Path.Combine( "C:\\Report" , ReportTemplateFile );
            }
        }
        /// <summary>
        /// 打印 
        /// </summary>
        /// <param name="parameters">报表参数</param>
        public abstract void Print( ReportParameter[] parameters );
        /// <summary>
        /// 打印 
        /// </summary>
        /// <param name="parameters">报表参数</param>
        /// <param name="dataTable">报表数据表</param>
        public abstract void Print( ReportParameter[] parameters , DataTable dataTable );
        
        public static BaseReportPrinter GetReportPrinter( Mode mode )
        {
            switch( mode )
            {
                case Mode.Grid十十:
                    return new Implement.Grid__.Grid十十ReportPrinter();
                default:
                    throw new NotImplementedException();
            }
        }

        public static void ShowDesigner( Mode mode )
        {
            switch( mode )
            {
                case Mode.Grid十十:
                    ( (IReportDesigner)( new Implement.Grid__.FrmReportDesigner() ) ).OpenDesigner();
                    break;
            }
        }
    }
}
