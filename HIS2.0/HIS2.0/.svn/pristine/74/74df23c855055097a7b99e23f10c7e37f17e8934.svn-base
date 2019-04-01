using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Xml;
using System.Management;
 

namespace TrasenFrame.Classes
{
    public delegate void OnProcessingEventHandler(string message );
    public delegate void OnDetectingPrinterChanged(string message);
    public class Printer
    {
        public string Name;
        public PrinterType Type;
        public string Port;
        public bool IsNetPrinter;
    }
    public enum PrinterType : int
    {
        未知类型 = 0,
        针式打印机 = 1,
        喷墨打印机 = 2,
        激光打印机 = 3
    }
    /// <summary>
    /// 打印机管理器
    /// </summary>
    public class PrinterManager
    {
        private string xmlPath = System.Windows.Forms.Application.StartupPath + "\\InstalledPrinter.xml";        
        public event OnProcessingEventHandler OnProcessing;
        public event OnDetectingPrinterChanged DetectingPrinterChanged;
        /// <summary>
        /// 获取已安装的打印机列表
        /// </summary>
        public List<string> GetInstanlledPrinters()
        {
            PrintDocument pd = new PrintDocument();
            List<string> printers = new List<string>();
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                printers.Add(printerName);
            }
            return printers;




        }
        /// <summary>
        /// 获取本地配置中的打印机列表
        /// </summary>
        /// <returns></returns>
        public List<Printer> GetConfiguredPrinters()
        {
            XmlDocument document = new XmlDocument();
            if ( !System.IO.File.Exists( xmlPath ) )
                return new List<Printer>();
            document.Load( xmlPath );
            List<Printer> printers = new List<Printer>();
            XmlNodeList xnlstPrinters = document.GetElementsByTagName( "Printer" );
            foreach( XmlNode xn in xnlstPrinters )
            {
                Printer printer = new Printer();
                printer.Name = xn.Attributes["name"].Value;
                printer.Type = (PrinterType)Convert.ToInt32( xn.Attributes["printertype"].Value );
                printer.Port = xn.Attributes["port"].Value;
                printer.IsNetPrinter = Convert.ToBoolean( xn.Attributes["netprinter"].Value );
                printers.Add( printer );
            }

            return printers;
        }
        /// <summary>
        /// 根据名称获取配置中的打印机
        /// </summary>
        /// <param name="PrinterName"></param>
        /// <returns></returns>
        public Printer GetConfiguredPrinter( string PrinterName )
        {
            List<Printer> lstPrinters = GetConfiguredPrinters();
            Printer printer = lstPrinters.Find( delegate( Printer p )
            {
                return p.Name == PrinterName;
            } );
            return printer;
        }
        /// <summary>
        /// 检测本机安装的打印机，并创建配置信息
        /// </summary>
        public void Detecting()
        {
            //已安装的打印机
            List<string> installedPrinters = GetInstanlledPrinters();
            if( !System.IO.File.Exists( xmlPath ) )
            {
                if( !CreateXmlConfig( installedPrinters , xmlPath ) )
                {
                    throw new Exception( "创建打印机配置文件发生错误" );
                }
                else
                {
                    if( DetectingPrinterChanged != null )
                        DetectingPrinterChanged( "初始化打印机配置完成,请在菜单栏的[系统]=>[参数设置]中进行配置" );
                    return;
                }
            }

            //已配置的打印机
            List<Printer> configuedPrinters = GetConfiguredPrinters();

            //检测安装的打印机与配置中是否一致
            StringBuilder sbInfo = new StringBuilder();
            bool haschanged = false;
            foreach( string printer in installedPrinters )
            {
                if( configuedPrinters.Find( delegate( Printer p )
                {
                    return p.Name == printer;
                } ) == null )
                {
                    sbInfo.Append( "安装的打印机[" + printer + "]没有在配置中设置\r" );
                    haschanged = true;
                }
            }

            if( haschanged )
            {
                if( DetectingPrinterChanged != null )
                {
                    sbInfo.Append( "请在菜单栏的[系统]=>[参数设置]中进行配置" );
                    DetectingPrinterChanged( sbInfo.ToString() );
                }
            }
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="Printers"></param>
        public void Save( List<Printer> Printers )
        {
            if( !System.IO.File.Exists( xmlPath ) )
            {
                CreateXmlConfig( new List<string>() , xmlPath );
            }

            XmlDocument document = new XmlDocument();
            document.Load( xmlPath );
            XmlNodeList lst = document.GetElementsByTagName( "InstalledPrinter" );
            XmlNode root = document.GetElementsByTagName( "InstalledPrinter" )[0];
            root.RemoveAll();
            foreach( Printer printer in Printers )
            {
                XmlNode xnPrinter = document.CreateNode( XmlNodeType.Element , "Printer" , "" );
                XmlAttribute attrName = document.CreateAttribute( "name" );
                attrName.Value = printer.Name;
                XmlAttribute attrType = document.CreateAttribute( "printertype" );
                attrType.Value = Convert.ToString( (int)printer.Type );
                XmlAttribute attrPort = document.CreateAttribute( "port" );
                attrPort.Value = printer.Port;
                XmlAttribute attrNet = document.CreateAttribute( "netprinter" );
                attrNet.Value = printer.IsNetPrinter ? "true" : "false";
                xnPrinter.Attributes.Append( attrName );
                xnPrinter.Attributes.Append( attrType );
                xnPrinter.Attributes.Append( attrPort );
                xnPrinter.Attributes.Append( attrNet );

                root.AppendChild( xnPrinter );
            }
            document.AppendChild( root );
            try
            {
                document.Save( xmlPath );
            }
            catch( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 删除打印机配置
        /// </summary>
        /// <param name="PrintName"></param>
        public void Delete( string PrinterName )
        {
            XmlDocument document = new XmlDocument();
            document.Load( xmlPath );
            XmlNode printers = document.GetElementsByTagName( "InstalledPrinter" )[0];
            XmlNodeList xnlstPrinters = document.GetElementsByTagName( "Printer" );
            foreach( XmlNode xn in xnlstPrinters )
            {
                if( PrinterName == xn.Attributes["name"].Value )
                {
                    printers.RemoveChild( xn );
                    break;
                }

            }
            document.Save( xmlPath );
        }
        /// <summary>
        /// 创建打印机配置文件
        /// </summary>
        /// <param name="printers"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool CreateXmlConfig( List<string> printers , string path )
        {
            XmlDocument document = new XmlDocument();

            XmlNode root = document.CreateNode( XmlNodeType.Element , "InstalledPrinter" , "" );
            
            foreach( string name in printers )
            {
                XmlNode xnPrinter = document.CreateNode( XmlNodeType.Element , "Printer" , "" );
                XmlAttribute attrName = document.CreateAttribute( "name" );
                attrName.Value = name;
                XmlAttribute attrType = document.CreateAttribute( "printertype" );
                attrType.Value = "0";
                XmlAttribute attrPort = document.CreateAttribute( "port" );
                attrPort.Value = "unknown";
                XmlAttribute attrNet = document.CreateAttribute( "netprinter" );
                attrNet.Value = "false";

                xnPrinter.Attributes.Append( attrName );
                xnPrinter.Attributes.Append( attrType );
                xnPrinter.Attributes.Append( attrPort );
                xnPrinter.Attributes.Append( attrNet );

                root.AppendChild( xnPrinter );
            }
            document.AppendChild( root );
            try
            {
                document.Save( path );
                return true;
            }
            catch( Exception err )
            {
                throw err;
            }
            
        }

        public static string CurrentDefaultPrinter
        {
            get
            {
                PrintDocument printDocument = new PrintDocument();
                return printDocument.PrinterSettings.PrinterName;
            }
        }
    }
}
