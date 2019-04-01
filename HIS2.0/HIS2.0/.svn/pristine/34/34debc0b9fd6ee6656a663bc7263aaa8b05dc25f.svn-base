using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YpClass;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
 

namespace ts_PrintProcess
{
    /// <summary>
    /// 处方打印
    /// </summary>
    public class PrescriptionPrint
    {

        public PrescriptionPrint()
        {

        }

        private static TrasenClasses.DatabaseAccess.RelationalDatabase database;
        public static TrasenClasses.DatabaseAccess.RelationalDatabase DB
        {
            get
            {
                database = new TrasenClasses.DatabaseAccess.MsSqlServer();
                string serverName = "mydb_svr";
                serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", Constant.ApplicationDirectory + "\\ClientConfig.ini");
                if (serverName == "")
                {
                    //System.Windows.Forms.MessageBox.Show("ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器", "错误");
                    return null;
                }
                string connectionString = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER, serverName);
                database.Initialize(connectionString);
                return database;
            }
            set
            {
                database = value;
            }
        }
    
        DataTable cfmxTable = null;
        bool isExecSuccess;
        string brxxid = null;
        string deptName = null;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cryRepViw;
        private ToolBar tbMain;
        private string[] printReportInfo = null;
        public bool Print(string brkh, int Dept_Id,out string reslutMsg)
        {
            int fybz = 0;
            string sfrq1 = "";
            string sfrq2 = "";
            string fyrq1 = "";
            string fyrq2 = "";
            string fph = "";
            sfrq1 = DateTime.Now.ToShortDateString();
            sfrq2 = DateTime.Now.ToShortDateString(); 
            fyrq1 = "";
            fyrq2 = "";
            string sql = string.Format("select distinct BRXXID from YY_KDJB where KH= '{0}'", brkh);
            DataTable brxxInfo = DB.GetDataTable(sql);
            if (brxxInfo == null || brxxInfo.Rows.Count == 0)
            {
                reslutMsg = "未找到病人信息";
                return false;
            }
            brxxid = brxxInfo.Rows[0][0].ToString();

            sql = string.Format("select NAME from JC_DEPT_PROPERTY where DEPT_ID = {0}", Dept_Id);
            DataTable deptInfo = DB.GetDataTable(sql);
            if (deptInfo == null || deptInfo.Rows.Count == 0)
            {
                reslutMsg = "未找到科室";
                return false;
            }
            deptName = deptInfo.Rows[0][0].ToString();

            //this.cfmxTable = MZYF.SelectMzcfk("Fun_ts_yf_mzfy", Dept_Id, Guid.Empty, "", fph, 0, fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, new Guid(brxxid), 0, DB);
            this.cfmxTable = MZYF.PrintMzcfk("Fun_ts_yf_mzfy", Dept_Id, Guid.Empty, "", fph, 0, fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, new Guid(brxxid), 0, DB);

            DataRow[] retRows=  cfmxTable.Select("  byscf = 1");       //只打印电子处方  2014-12-16     
            DataTable datalist = this.cfmxTable.Clone();
            if (retRows != null && retRows.Length > 0)
            {
                foreach (DataRow tmpRow in retRows)
                    datalist.ImportRow(tmpRow);
            }
            else
            {
                reslutMsg = "未找到电子处方明细";
                return false;
            }
         
            #region
            //this.AddPresc(dataSouce);       
            //YpConfig ypconfig = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            ////分组处方
            //DataRow[] selrow;
            //if (ypconfig.门诊发药后才能打印处方 == true)
            //    selrow = tb.Select("( 发药='√') and ypid<>''");
            //else
            //    selrow = tb.Select("(发药='◆' or  发药='√') and ypid<>''");
            //DataTable tbsel = tb.Clone();
            //for (int w = 0; w <= selrow.Length - 1; w++)
            //    tbsel.ImportRow(selrow[w]);
            #endregion

            //if (cbyfyjs.Checked == false) //如果为未发药就取总金额，已发药则取求和值
            //{
            string[] GroupbyField ={ "cfxh", "发票号", "总金额", "诊断", "门诊号" };
            string[] ComputeField ={ };
            string[] CField ={ };
            DataTable tbcf = FunBase.GroupbyDataTable(datalist, GroupbyField, ComputeField, CField, null);
            //}
            //else
            //{
            //    string[] GroupbyField ={ "cfxh", "发票号", "诊断", "门诊号" };
            //    string[] ComputeField ={ "金额" };
            //    string[] CField ={ "sum" };
            //    tbcf = FunBase.GroupbyDataTable(datalist, GroupbyField, ComputeField, CField, null);
            //}

            //SystemCfg cfg8035 = new SystemCfg(8035);
            //if (cfg8035.Config == "1")
            //{
            //处方     

            int number = 0;
            for (int i = 0; i < tbcf.Rows.Count; i++)
            {
                UcReportView urv = new UcReportView();
                urv.db = PrescriptionPrint.DB;
                if (this.PrintCf(tbcf.Rows[i], 1, urv) == false)
                    number++;
            }
            reslutMsg = "";
            if (number == tbcf.Rows.Count)
                return false;
            else
                return true;
            //}
            //else
            //{
            //    //处方
            //    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            //    {
            //        this.PrintCf(tbcf.Rows[i], 1);
            //    }
            //}            
        }

        private bool PrintCf(DataRow row, int cfgs, UcReportView reportView)
        {
            DataRow[] rows;
            if (cfgs == 1)
                rows = cfmxTable.Select(" cfxh='" + row["cfxh"] + "' ");
            else
                rows = cfmxTable.Select(" cfxh='" + row["cfxh"] + "' and zsyp=1 ");
            if (rows.Length == 0)
                return false;
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            string jtdz = "";
            string grlxdh = "";
            string sfzh = "";
            string brxm = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + row["cfxh"].ToString() + "'";
            DataTable tb = DB.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
                brxm = Convertor.IsNull(tb.Rows[0]["brxm"], "");
            }
            SystemCfg sc = new SystemCfg(10026);
            List<string> yflist = new List<string>();
            yflist.Add("H");
            yflist.Add("iv");
            yflist.Add("im");
            yflist.Add("iv drip");
            yflist.Add("iv pump");
            yflist.Add("静脉泵入");
            yflist.Add("皮下注射");

            for (int i = 0; i <= rows.Length - 1; i++)
            {
                if (sc.Config == "0")
                {
                    if (!string.IsNullOrEmpty(yflist.Find(delegate(string s) { return s.ToUpper() == Convertor.IsNull(rows[i]["用法"], "").Trim().ToUpper(); })))
                    {
                        #region  非中药处方格式
                        myrow = Dset.病人处方清单.NewRow();
                        myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                        myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                        myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                        myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                        myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                        myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                        myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                        myrow["cfts"] = rows[i]["剂数"].ToString();
                        myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                        myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");
                        myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                        myrow["syjl"] = "";
                        myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                        myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                        myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                        myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                        myrow["PSZT"] = rows[i]["皮试"].ToString();
                        myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                        myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                        myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                        myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                        myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                        myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                        //myrow["pyr"] = rows[i]["配药人"];           
                        if (Convert.ToString(rows[i]["发药员"]) != string.Empty)
                            myrow["fyr"] = Convert.ToString(rows[i]["发药员"]);
                        myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"], "") == "" ? "" : Convertor.IsNull(rows[i]["配药窗口"], "");
                        myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], ""); //Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                        myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                        myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                        myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                        myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                        myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                        myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                        myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");

                        if (rows[i]["组标志"].ToString() == "1")
                        {
                            yzzh = yzzh + 1;
                        }
                        myrow["yzzh"] = yzzh;
                        myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                        myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                        myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                        myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                        //myrow["sfrq"] = PrintRq.ToLongDateString();
                        //myrow["cfrq"] = PrintRq.ToLongDateString();
                        //myrow["blh"] =PrintRq.Year.ToString()+"0"+PrintRq.Month.ToString()+PrintRq.Day.ToString()+ Convert.ToString(rows[i]["门诊号"]).Substring(8,Convert.ToString(rows[i]["门诊号"]).Length-8);
                        myrow["fzbz"] = rows[i]["组标志"].ToString();

                        myrow["JTDZ"] = jtdz;
                        myrow["LXDH"] = grlxdh;
                        myrow["SFZH"] = sfzh;
                        myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                        myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                        myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                        //myrow["dyr"] =  InstanceForm.BCurrentUser.Name;
                        myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                        myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                        Dset.病人处方清单.Rows.Add(myrow);
                        #endregion
                    }
                }
                else
                {
                    #region  非中药处方格式
                    myrow = Dset.病人处方清单.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                    myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                    myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                    myrow["cfts"] = rows[i]["剂数"].ToString();
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                    myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");
                    myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                    myrow["syjl"] = "";
                    myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                    myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                    myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                    myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                    myrow["PSZT"] = rows[i]["皮试"].ToString();
                    myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                    myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                    myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                    myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                    myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                    myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                    //myrow["pyr"] = rows[i]["配药人"];           
                    if (Convert.ToString(rows[i]["发药员"]) != string.Empty)
                        myrow["fyr"] = Convert.ToString(rows[i]["发药员"]);
                    myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"], "") == "" ? "" : Convertor.IsNull(rows[i]["配药窗口"], "");
                    myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], ""); //Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                    myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                    myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                    myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                    myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                    myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");

                    if (rows[i]["组标志"].ToString() == "1")
                    {
                        yzzh = yzzh + 1;
                    }
                    myrow["yzzh"] = yzzh;
                    myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                    myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                    myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                    myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                    //myrow["sfrq"] = PrintRq.ToLongDateString();
                    //myrow["cfrq"] = PrintRq.ToLongDateString();
                    //myrow["blh"] =PrintRq.Year.ToString()+"0"+PrintRq.Month.ToString()+PrintRq.Day.ToString()+ Convert.ToString(rows[i]["门诊号"]).Substring(8,Convert.ToString(rows[i]["门诊号"]).Length-8);
                    myrow["fzbz"] = rows[i]["组标志"].ToString();

                    myrow["JTDZ"] = jtdz;
                    myrow["LXDH"] = grlxdh;
                    myrow["SFZH"] = sfzh;
                    myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                    myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                    myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                    //myrow["dyr"] =  InstanceForm.BCurrentUser.Name;
                    myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.病人处方清单.Rows.Add(myrow);
                    #endregion
                }
            }
            if (Dset.病人处方清单.Rows.Count == 0)
                return false;
            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["剂数"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["总金额"], "0"));
            parameters[2].Text = "TITLETEXT";
             sc = new SystemCfg(2, DB);
            parameters[2].Value = "武汉市中心医院";
            parameters[3].Text = "text1";
            parameters[3].Value = "发药单位:" + deptName + "    诊断:" + rows[0]["诊断"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]) != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = deptName;

            initReportTemp(reportView);
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                this.initReportData(reportView, Dset.病人处方清单, GetLocalPath() + "\\Report\\YF_病人处方清单_中药处方.rpt", parameters, false);
            else
                this.initReportData(reportView, Dset.病人处方清单, GetLocalPath() + "\\Report\\YF_快发病人处方清单(处方格式).rpt", parameters, false);


            ToolBarButtonClickEventArgs clickEvent = new ToolBarButtonClickEventArgs(new ToolBarButton());
            clickEvent.Button.Tag = 0;
            reportView.tbMain_ButtonClick(null, clickEvent);
            return true;
            //string sql = string.Format("update mz_cfb set dybz = 1 where cfid = '{0}'", row["cfxh"]);
            //InstanceForm.BDatabase.DoCommand(sql);
        }

        private string GetLocalPath()
        {
            string path = "";
            string temppath = System.Environment.CurrentDirectory + "\\";
            if (string.Compare(temppath, AppDomain.CurrentDomain.BaseDirectory, true) == 0 ||
                string.Compare(System.Environment.CurrentDirectory, AppDomain.CurrentDomain.BaseDirectory, true) == 0)
            {
                path = temppath;
            }
            else
            {
                path = AppDomain.CurrentDomain.BaseDirectory + "bin\\";
            }
            return path;
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            try
            {
                string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
                DataTable tb = DB.GetDataTable(ss);
                if (tb == null || tb.Rows.Count == 0 || tb.Rows[0]["sign"].GetType().ToString() == "System.DBNull")
                    return null;
                else
                    return ((byte[])tb.Rows[0]["sign"]);
            }
            catch (Exception err)
            {
                return null;
            }
        }

        private void initReportTemp(UcReportView reportView)
        {
            cryRepViw = reportView.CryRepViw_Uc;
            tbMain = reportView.tbMain_Uc;
            if (printReportInfo != null && printReportInfo.Length > 0)
                reportView.sqlStr_Uc = printReportInfo;
            reportView.IsExecSuccessChanged += new EventHandler(ucReportView1_IsExecSuccessChanged);
        }

        private bool initReportData(UcReportView reportView, object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter)
        {
            return reportView.Init(reportDataSource, reportFilePath, parameters, toPrinter);
        }

        private void ucReportView1_IsExecSuccessChanged(object sender, EventArgs e)
        {
            if (sender is UcReportView)
                this.isExecSuccess = (sender as UcReportView).isExecSuccess_Uc;
        }

        private bool IsVisable(string columnName, bool defaultVisable)
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("门诊处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("门诊处方发药网格列", columnName, defaultVisable ? "1" : "0", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("门诊处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }
    }

    public struct ColumnDefine
    {
        public string HeaderText;
        public string MappingName;
        public int ColWidth;
        public bool ColReadOnly;
        public int ColBoolButton;

        public static ColumnDefine NewColumnDefine(string headerText, string mappinName, int colWidth, bool colReadonly, int colBoolButton)
        {
            ColumnDefine define = new ColumnDefine();
            define.HeaderText = headerText;
            define.MappingName = mappinName;
            define.ColWidth = colWidth;
            define.ColReadOnly = colReadonly;
            define.ColBoolButton = colBoolButton;
            return define;
        }
    }
}
