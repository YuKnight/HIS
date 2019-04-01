using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenClasses.GeneralClasses;
using System.Xml;

namespace TrasenFrame.Classes
{
    public class ReportPaper : System.Drawing.Printing.PaperSize
    {
        public enum PrinterTargetType
        {
            自定义打印机=0,
            发票打印机=1,
            报表打印机=2
        }
        private static string reportSettingXml = System.Windows.Forms.Application.StartupPath + "\\ReportPaperConfig.xml";
        private static readonly string ROOT_NODE_NAME = "REPORT_PAPER_DEFINE";
        private string defaultPrinterName;
        private string reportName;
        private PrinterTargetType printerTagType;
        /// <summary>
        /// 打印机类型 0-默认打印机 1-发票打印机 2-报表打印机
        /// </summary>
        public PrinterTargetType PrinterTagType
        {
            get
            {
                return printerTagType;
            }
            set
            {
                printerTagType = value;
            }
        }

        public string ReportName
        {
            get
            {
                return reportName;
            }
            private set
            {
                reportName = value;
            }
        }
        /// <summary>
        /// 当前报表的默认打印机名
        /// </summary>
        public string DefaultPrinterName
        {
            get
            {
                return defaultPrinterName;
            }
            private set
            {
                defaultPrinterName = value;
            }
        }
        /// <summary>
        /// 内部构造函数
        /// </summary>
        private ReportPaper()
        {
        }
        /// <summary>
        /// 设置报表在本地打印时的打印机名称
        /// </summary>
        /// <param name="printerName"></param>
        public void SetPrinter( string printerName )
        {
            SetReportPaperPrinter( this , printerName );
            this.defaultPrinterName = printerName;
        }

        public override string ToString()
        {
            return string.Format( "{0},{1},{2}" , reportName , PaperName , defaultPrinterName );
        }

        private static XmlNode GetNodeByReportName(XmlDocument document, string reportName )
        {
            XmlNodeList nodelist = document.GetElementsByTagName( "REPORT" );
            foreach ( XmlNode node in nodelist )
            {
                if ( node.Attributes["reportname"].Value.ToUpper() == reportName.ToUpper() )
                {
                    return node;
                }
            }
            return null;
        }
        /// <summary>
        /// 根据文件完全路径获取文件名
        /// </summary>
        /// <param name="_reportFilePath"></param>
        /// <returns></returns>
        private static string GetReportFileName( string _reportFilePath )
        {
            string _reportName = _reportFilePath;
            int _idx = 0;
            //从_reportFilePath取出报表文件名
            while ( _reportName.IndexOf( @"\" ) >= 0 )
            {
                _idx = _reportName.IndexOf( @"\" );
                _reportName = _reportName.Substring( _idx + 1 );
            }
            _reportName = _reportName.Substring( 0 , _reportName.Length - 4 );
            return _reportName;
        }
        /// <summary>
        /// 从服务器同步纸张定义到本地
        /// </summary>
        /// <param name="database"></param>
        public static void SyncPaperDefineFromServer( RelationalDatabase database )
        {
            string sql = "select id,reportname,papername,paperwidth,paperheight,printername,lx from jc_reportpaper";
            DataTable tbServerData = database.GetDataTable( sql );
            tbServerData.PrimaryKey = new DataColumn[] { tbServerData.Columns["ID"] };

            XmlDocument document = new XmlDocument();
            XmlNode rootNode = null;
            if ( System.IO.File.Exists( reportSettingXml ) )
            {
                document.Load( reportSettingXml );
                rootNode = document.SelectSingleNode( ReportPaper.ROOT_NODE_NAME );
            }
            else
            {
                //创建xml
                XmlDeclaration declareNode = document.CreateXmlDeclaration( "1.0" , "UTF-8" , "yes" );
                document.AppendChild( declareNode );
                rootNode = document.CreateElement( ReportPaper.ROOT_NODE_NAME );
                document.AppendChild( rootNode );
            }
            List<XmlNode> list = new List<XmlNode>();
            foreach ( XmlNode nodePaper in rootNode.ChildNodes )
                list.Add( nodePaper );

            foreach ( DataRow row in tbServerData.Rows )
            {
                XmlNode node = list.Find( delegate( XmlNode nd )
                {
                    return nd.Attributes["reportname"].Value.ToUpper() == row["REPORTNAME"].ToString().ToUpper();
                } );
                if ( node == null )
                {
                    //服务器上定义的报表不在本地列表中，添加到本地列表
                    XmlNode newPaperNode = document.CreateElement( "REPORT" );

                    XmlAttribute attrReportName = document.CreateAttribute( "reportname" );
                    attrReportName.Value = row["REPORTNAME"].ToString();
                    XmlAttribute attrPaperName = document.CreateAttribute( "papername" );
                    attrPaperName.Value = row["papername"].ToString();
                    XmlAttribute attrWeight = document.CreateAttribute( "paperwidth" );
                    attrWeight.Value = row["paperwidth"].ToString();
                    XmlAttribute attrHeight = document.CreateAttribute( "paperheight" );
                    attrHeight.Value = row["paperheight"].ToString();
                    XmlAttribute attrType = document.CreateAttribute( "type" );
                    attrType.Value = row["lx"].ToString();

                    newPaperNode.Attributes.Append( attrReportName );
                    newPaperNode.Attributes.Append( attrPaperName );
                    newPaperNode.Attributes.Append( attrWeight );
                    newPaperNode.Attributes.Append( attrHeight );
                    newPaperNode.Attributes.Append( attrType );
                    //首次添加默认服务器端设置的打印机名
                    newPaperNode.InnerText = Convertor.IsNull( row["printername"].ToString() , "" );

                    rootNode.AppendChild( newPaperNode );
                }
                else
                {
                    XmlNodeList subNodeList = document.GetElementsByTagName( "REPORT" );
                    foreach ( XmlNode subNode in subNodeList )
                    {
                        if ( subNode.Attributes["papername"].Value == row["papername"].ToString() )
                        {
                            subNode.Attributes["paperwidth"].Value = row["paperwidth"].ToString();
                            subNode.Attributes["paperheight"].Value = row["paperheight"].ToString();
                            subNode.Attributes["type"].Value = row["lx"].ToString();
                            if ( string.IsNullOrEmpty( subNode.InnerText ) )
                                subNode.InnerText = Convertor.IsNull( row["printername"].ToString() , "" );
                        }
                    }
                }
            }
            document.Save( ReportPaper.reportSettingXml );
        }
        /// <summary>
        /// 根据报表名称获取报表纸张
        /// </summary>
        /// <param name="reportName">报表名</param>
        /// <param name="bIncludePath">报表名中是否包含路径</param>
        /// <param name="database">数据访问对象</param>
        /// <returns></returns>
        public static ReportPaper GetReportPapterConfigFromLocalXml( string reportName , bool bIncludePath , RelationalDatabase database )
        {
            string _reportName = "";
            if ( bIncludePath )
                _reportName = GetReportFileName( reportName );
            else
                _reportName = reportName;            

            if ( !System.IO.File.Exists( ReportPaper.reportSettingXml ) )
                SyncPaperDefineFromServer( database );

            XmlDocument document = new XmlDocument();
            document.Load( ReportPaper.reportSettingXml );

            XmlNode nodeReportPaper = GetNodeByReportName(document, reportName ) ;
            ReportPaper rp = new ReportPaper();
            rp.reportName = reportName;
            if ( nodeReportPaper != null )
            {
                rp = CreateReportPaperFromXmlNode( nodeReportPaper );                
            }
            else
            {
                //没有找到xml中的配置，设置默认值
                rp.PaperName = "";
                rp.Height = 0;
                rp.Width = 0;
            }
            return rp;
        }
        /// <summary>
        /// 设置报表在本地打印时的打印机名称
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="printerName"></param>
        public static void SetReportPaperPrinter( string reportName , string printerName ,int type)
        {
            if ( !System.IO.File.Exists( ReportPaper.reportSettingXml ) )
                throw new Exception( "reportSettingXml配置文件不存在，请先调用同步功能创建" );
            XmlDocument document = new XmlDocument();
            document.Load( ReportPaper.reportSettingXml );

            XmlNode nodeReportPaper = GetNodeByReportName( document, reportName );
            if ( nodeReportPaper != null )
            {
                nodeReportPaper.Attributes["type"].Value = type.ToString();
                nodeReportPaper.InnerText = printerName;
            }
            document.Save( reportSettingXml );

           
        }
        /// <summary>
        /// 设置报表在本地打印时的打印机名称
        /// </summary>
        /// <param name="reportPaper"></param>
        /// <param name="printerName"></param>
        public static void SetReportPaperPrinter( ReportPaper reportPaper , string printerName )
        {
            SetReportPaperPrinter( reportPaper.PaperName , printerName ,(int)reportPaper.PrinterTagType);
        }
        /// <summary>
        /// 加载本地报表纸张配置列表
        /// </summary>
        /// <returns></returns>
        public static List<ReportPaper> LoadLocalReportPapers( RelationalDatabase database )
        {
            if( !System.IO.File.Exists(ReportPaper.reportSettingXml ) )
                SyncPaperDefineFromServer( database );
            XmlDocument document = new XmlDocument();
            document.Load( reportSettingXml );
            XmlNode rootNode = document.SelectSingleNode( ReportPaper.ROOT_NODE_NAME );
            List<ReportPaper> reportPapers = new List<ReportPaper>();
            foreach ( XmlNode nodePaper in rootNode.ChildNodes )
            {
                ReportPaper rp = CreateReportPaperFromXmlNode( nodePaper );
                reportPapers.Add( rp );
            }
            return reportPapers;
        }

        private static ReportPaper CreateReportPaperFromXmlNode( XmlNode nodePaper )
        {
            ReportPaper rp = new ReportPaper();
            rp.ReportName = nodePaper.Attributes["reportname"].Value;
            rp.PaperName = nodePaper.Attributes["papername"].Value;
            rp.Height = Convert.ToInt32( nodePaper.Attributes["paperheight"].Value );
            rp.Width = Convert.ToInt32( nodePaper.Attributes["paperwidth"].Value );

            int lx = 0;
            if ( !string.IsNullOrEmpty( nodePaper.Attributes["type"].Value ) )
                lx = Convert.ToInt32( nodePaper.Attributes["type"].Value );
            switch ( lx )
            {
                case 0:
                    //默认打印机，需要去获取打印机名,先从本地的xml配置中读取，本地没有再去读服务器的
                    rp.DefaultPrinterName = nodePaper.InnerText;
                    break;
                case 1:
                    //这里需要根据类型获取特定的发票打印机，该设置通过Constant类维护，保存在ClientConfig.ini中
                    rp.DefaultPrinterName = Constant.CInvoicePrinterName;
                    break;
                case 2:
                    //这里需要根据类型获取特定的报表打印机，该设置通过Constant类维护，保存在ClientConfig.ini中
                    rp.DefaultPrinterName = Constant.CReportPrinterName;
                    break;
            }
            rp.PrinterTagType = (PrinterTargetType)lx;
            return rp;
        }


        
    }

}

