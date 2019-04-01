using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using TrasenFrame.Classes;

namespace TrasenFrame.Forms
{
    public partial class FrmReportView : Form
    {
        //2013-1-18 增加 将对象销毁，不要在temp文件中产生垃圾 jianqg
        //2013-2-20 考虑本窗口不使用，该为控件特重命名 做备份FrmReportView_old 将原报表窗口改为控件，此窗口改调用控件 jianqg
        //2013-4-3  原窗口的静态方法，GetCustomReportPath与DirectPrint 重新发布  jianqg
        /// <summary>
        /// CrystalReportViewer
        /// </summary>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CryRepViw;
        /// <summary>
        /// 报表是否加载成功
        /// </summary>
        public bool LoadReportSuccess;
        /// <summary>
        /// 该字符串用于点击打印后执行
        /// </summary>
        /// <remarks>Add By Tany 2010-09-25 增加一个SQLSTR用于点击打印后执行该语句</remarks>
        public string[] _sqlStr;
        /// <summary>
        /// 是否在点击打印后成功执行该字符串
        /// </summary>
        public bool _isExecSuccess = false;
        public ToolBar tbMain; 

        #region 构造函数
 


            

        public FrmReportView()
        {
            InitializeComponent();
            Init0();
            LoadReportSuccess = this.ucReportView1.Init();
            
     
            
        }


        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        public FrmReportView(object reportDataSource, string reportFilePath, ParameterEx[] parameters)
        {
            InitializeComponent();
            Init0();
            LoadReportSuccess=this.ucReportView1.Init(reportDataSource, reportFilePath, parameters);
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        public FrmReportView(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter)
        {
            InitializeComponent();
            Init0();
            LoadReportSuccess=this.ucReportView1.Init(reportDataSource, reportFilePath, parameters, toPrinter);
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="printName">打印机名称</param>
        public FrmReportView(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string printName)
        {
            InitializeComponent();
            Init0();
            
            LoadReportSuccess=this.ucReportView1.Init(reportDataSource, reportFilePath, parameters, toPrinter, printName);
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="localLogin">是否本机数据库报表打印</param>
        public FrmReportView(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool localLogin)
        {
            InitializeComponent();
            Init0();
            LoadReportSuccess=this.ucReportView1.Init(reportDataSource, reportFilePath, parameters, toPrinter, localLogin);
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="localLogin">是否本机数据库报表打印</param>
        /// <param name="printName">打印机名称</param>
        public FrmReportView(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool localLogin, string printName)
        {
            InitializeComponent();
            Init0();
            LoadReportSuccess=this.ucReportView1.Init(reportDataSource, reportFilePath, parameters, toPrinter, localLogin, printName);
        }
        //Add By Tany 2010-09-25 新增一个构造函数，用于直接打印时，可以执行sql语句
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="sqlStr">打印后执行字符串</param>
        public FrmReportView(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string[] sqlStr)
        {
            InitializeComponent();
            Init0();
            LoadReportSuccess=this.ucReportView1.Init(reportDataSource, reportFilePath, parameters, toPrinter, sqlStr);
        }
        //Add By Tany 2010-10-25 新增一个构造函数，用于直接打印时，可以执行sql语句，可以更改数据连接
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="sqlStr">打印后执行字符串</param>
        /// <param name="database">数据库</param>
        public FrmReportView(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string[] sqlStr, TrasenClasses.DatabaseAccess.RelationalDatabase database)
        {
            InitializeComponent();
            Init0();
            LoadReportSuccess=this.ucReportView1.Init(reportDataSource, reportFilePath, parameters, toPrinter, sqlStr, database);
        }
        //Add By Tany 2012-03-06 新增一个构造函数，用于是否显示导出、刷新、关闭、树状目录等按钮
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        public FrmReportView(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool isShowExport, bool isShowRefresh, bool isShowCloseButton, bool isShowTree)
        {
            InitializeComponent();
            Init0();
            
            LoadReportSuccess=this.ucReportView1.Init(reportDataSource, reportFilePath, parameters, toPrinter, isShowExport, isShowRefresh, isShowCloseButton, isShowTree);
        }
        #endregion


        #region 属性 IsPrinted，ShowPrintButton
        /// <summary>
        /// 判断用户是否点击了打印按钮
        /// </summary>
        public bool IsPrinted
        {
            get
            {
                return this.ucReportView1.IsPrinted;
            }
        }


        public bool ShowPrintButton
        {
            get
            {
                return this.ucReportView1.ShowPrintButton;
            }
            set
            {
                this.ucReportView1.ShowPrintButton = value;
            }
        }
        /// <summary>
        /// 是否显示导出按钮,add by wangzhi 2013-09-13
        /// </summary>
        public bool ShowExportButton
        {
            get
            {
                return this.ucReportView1.CryRepViw_Uc.ShowExportButton;
            }
            set
            {
                this.ucReportView1.CryRepViw_Uc.ShowExportButton = value;
            }
        }
        #endregion
        #region 处理原来窗口级的全局变量 jianqg 2013-2-20
        private void Init0()
        {
            CryRepViw = this.ucReportView1.CryRepViw_Uc;
            tbMain = this.ucReportView1.tbMain_Uc;
            if (_sqlStr != null && _sqlStr.Length > 0 ) this.ucReportView1.sqlStr_Uc=_sqlStr;
            this.ucReportView1.IsExecSuccessChanged +=new EventHandler(ucReportView1_IsExecSuccessChanged);

                
        }
        private void ucReportView1_IsExecSuccessChanged(object sender,EventArgs e)
        {
            this._isExecSuccess = this.ucReportView1.isExecSuccess_Uc;
        }

        #endregion
        #region 构造函数Load,FormClosed
        private void FrmReportView_Load(object sender, EventArgs e)
        {
            try
            {
                //if ( TrasenFrame.Forms.FrmMdiMain.InitCryptEnd == false )
                //    throw new Exception( "水晶报表组件正在初始化，请稍后再试" );
                this.Init0();
                this.ucReportView1.Control_Load(sender, e);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message , "");
            }
        }

        private void FrmReportView_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.ucReportView1.Control_Closed(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message , "");
            }
        }
        #endregion

        #region 处理原来窗口的的静态方法 jianqg 2013-4-3
        /// <summary>
        /// 取得用户自定义报表文件路径，如果不存在则从path拷贝只自定义路径下
        /// </summary>
        /// <param name="path">当前报表路径</param>
        /// <param name="localLogin">是否为本机登录</param>
        /// <returns></returns>
        public static string GetCustomReportPath(string path, bool localLogin)
        {
            return  UcReportView.GetCustomReportPath(path, localLogin);
        }
        /// <summary>
        /// 直接打印
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="localLogin">是否本机登录</param>
        /// <param name="printName">打印机名称</param>
        /// <param name="actualReportFilePath">报表文件路径是否为实际路径</param>
        /// <returns>打印是否成功</returns>
        public static bool DirectPrint(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool localLogin, string printName, bool actualReportFilePath)
        {
            return UcReportView.DirectPrint(reportDataSource, reportFilePath, parameters, localLogin, printName, actualReportFilePath);
        }
        #endregion









    }
}