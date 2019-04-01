using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace Ts_Hlyy_Interface
{
    public class MK_HlyyClass : HlyyInterface
    {
        //*******美康嵌入代码开始（DLL函数声明）*****************************
       // [DllImport("ShellRunAs.dll.dll")]
        //public static extern int RegisterServer();
        //注册服务器

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassInit(string UserName, string DepartMentName, int WorkstationType);
        //PASS初始化

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassSetControlParam(int SaveCheckResult, int AllowAllegen, int CheckMode, int DisqMode, int UseDisposeIdea);
        //PASS运行模式设置

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassSetPatientInfo(string PatientId, string VisitID, string Name, string Sex, string Birthday, string Weight, string Height, string DepartMentName, string Doctor, string LeaveHospitalDate);
        //传病人基本信息

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassSetRecipeInfo(string OrderUniqueCode, string DrugCode, string DrugName, string SingleDose, string DoseUnit, string Frequency, string StartOrderDate, string StopOrderDate, string RouteName, string GroupTag, string OrderType, string OrderDoctor);
        //传病人药品信息

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassSetAllergenInfo(string AllergenIndex, string AllergenCode, string AllergenDesc, string AllergenType, string Reaction);
        //传入病人过敏史

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassSetMedCond(string MedCondIndex, string MedCondCode, string MedCondDesc, string MedCondType, string StartDate, string EndDate);
        //传入病生状态

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassSetQueryDrug(string DrugCode, string DrugName, string DoseUnit, string RouteName);
        //信息查询药品传入

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassGetState(string QueryItemNo);
        //获取右键菜单是否可用值

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassDoCommand(int CommandNo);
        //PASS功能调用

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassGetWarn(string DrugUniqueCode);
        //获取药品警示级别

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassSetFloatWinPos(int left, int top, int right, int bottom); //设置药品浮动窗口位置

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassSetWarnDrug(string DrugUniqueCode);
        //设置需要进行单药警告的药品

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern int PassQuit();//PASS退出函数

        [DllImport("C:\\passclient\\DIFPassDll.dll")]
        public static extern bool GetWindowRect(); //Windows API取坐标
        //*******美康嵌入代码结束（DLL函数声明）******************************




        #region HlyyInterface 成员
        /// <summary>
        /// 公共函数 
        /// </summary>
        /// <param name="commmandno"></param>
        /// <param name="ss">"用逗号隔开,分别为 药品id，药品名称，单位，用法"</param>
        /// <returns></returns>
        public int Pub_function(int commmandno,string ss)
        {

            

            try
            {
                if (PassGetState("0") == 0)//判断服务程序是否正在运行
                    throw new Exception("PASS服务未正常，请检查相关配置！！");
                string[] kk = ss.Split(',');
                PassSetQueryDrug(Getggid(kk[0]), kk[1], kk[2], kk[3]);
                return PassDoCommand(commmandno);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 获得菜单状态
        /// </summary>
        /// <param name="commandno"></param>
        /// <param name="ss">"用逗号隔开,分别为 药品id，药品名称，单位，用法"</param>
        /// <returns></returns>
        public int GetCszt(int commandno,string ss)
        {
            
             string[] kk = ss.Split(',');
             PassSetQueryDrug(Getggid(kk[0]), kk[1], kk[2], kk[3]);
             return  PassGetState(commandno.ToString());
        }
        public void UNRegisterServer()
        {
            //PassDoCommand(102);
            PassQuit();
        }
        public int RegisterServer_fun(object[] _values)
        {
            if(!Directory.Exists("C:\\passclient"))
            {
                ProcessStartInfo psi=new ProcessStartInfo("passclient.exe");
                Process.Start(psi);
                Thread.Sleep(1000);
                //判断是否已经解压完成               
                while (true)
                {
                    Process[] pr = Process.GetProcesses();
                    int j=0;
                    for ( j = 0; j < pr.Length; j++)
                    {
                        if (pr[j].ProcessName.ToUpper() == "PASSCLIENT")
                            break;
                    }
                    if (j == pr.Length)
                        break;
                    
                }
            }
            //0=用户 1=科室 2=模块 3=住院号 4=住院次数 5=病人姓名 6=性别 7=出生日期 8=体重  9=身高 10=出院日期
            int Module_id=0;
           try
           {
            Module_id =int.Parse(_values[3].ToString());
           }
           catch(Exception ex)
           {
               Module_id=0;
           }
           //int i= RegisterServer();
           int i = 0;
           //调用PassInit()函数进行初始化成功

           PassInit(_values[0].ToString(), _values[1].ToString(), 10);//Module_id 默认都改为10 Modify by zouchihua 2012-5-22t
           if (PassGetState("0") == 0)//判断服务程序是否正在运行
               throw new Exception("PASS服务未正常，请检查相关配置！！");
          
           PassSetControlParam(1,2,0,2,1); 
           PassDoCommand(402);//传入病人基本信息之前，402关闭已经显示的浮动窗口
	      //传入病人基本信息之前，清除审查结果警告信息
           if (PassGetState("0") != 0)//判断服务程序是否正在运行
               PassSetPatientInfo(_values[3].ToString(), _values[4].ToString(), _values[5].ToString(), _values[6].ToString(), _values[7].ToString(), _values[8].ToString(), _values[9].ToString(), _values[1].ToString(), _values[0].ToString(), _values[10].ToString());
           else
               throw new Exception("PASS服务未正常，请检查相关配置！！");
           return i;
        }
        public void Refresh()
        {
            
        }

        public void ShowPoint(StringBuilder sb)
        {
            if (PassGetState("0") == 0)//判断服务程序是否正在运行
                throw new Exception("PASS服务未正常，请检查相关配置！！");
            try
            {
                string[] ss = sb.ToString().Split(',');
                int ll_axtoscreen = int.Parse(ss[0]);//
                int ll_aytoscreen = int.Parse(ss[1]);
                int ll_bxtoscreen = int.Parse(ss[2]);
                int ll_bytoscreen = int.Parse(ss[3]);
                string ls_drugcode = Getggid(ss[4]);
                string ls_Drugname = ss[5];
                PassSetQueryDrug(ls_drugcode, ls_Drugname, "", "");
                PassSetFloatWinPos(ll_axtoscreen, ll_aytoscreen, ll_bxtoscreen, ll_bytoscreen);
                //PassSetFloatWinPos(200, 300, 300, 300);
                PassDoCommand(401);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DrugAnalysis(StringBuilder sb, int ZyOrMz)
        {
            int i = 0;
           
            //throw new Exception("The method or operation is not implemented.");
            return i;
        }

        public int SaveDrug(StringBuilder sb, int ZyOrMz)
        {
            int i = 0;
            //throw new Exception("The method or operation is not implemented.");
            return i;
        }

        public void SaveXml(StringBuilder sb)
        {
            
            //throw new Exception("The method or operation is not implemented.");
            
        }
        /// <summary>
        /// 过敏史管理
        /// </summary>
        /// <param name="_valuues"></param>
        /// <returns></returns>
        public int Gmsgl(object[] _valuues)
        {
           int i=0;
           if (PassGetState("0") != 0)
              i= PassDoCommand(22);
          else
              throw new Exception("PASS服务未正常，请检查相关配置！！");
           return i;
        }
        public void ClosePoint(StringBuilder sb)
        {
            if (PassGetState("0") == 0)//判断服务程序是否正在运行
                // throw new Exception("PASS服务未正常，请检查相关配置！！");
                return;
            //关闭PASS浮动窗口
           PassDoCommand(402);

        }
        /// <summary>
        /// 获得警告信息
        /// </summary>
        /// <param name="sb"></param>
        public void GetYpjgxx(DataGridEx mydatagrid)
        {
            if (PassGetState("0") == 0)//判断服务程序是否正在运行
                throw new Exception("PASS服务未正常，请检查相关配置！！");
             DataTable tb=(DataTable)mydatagrid.DataSource;
            try
            { 
                int row=mydatagrid.CurrentCell.RowNumber;
                int iRowTag =int.Parse(Convertor.IsNull( tb.Rows[row]["警示灯"],"-1").ToString());
                if ((iRowTag == 1) || (iRowTag == 2) || (iRowTag == 3) || (iRowTag == 4))
                {
                    PassSetWarnDrug(Getggid(tb.Rows[row]["hoitem_id"].ToString()));
                    //PassDoCommand(6);
                    PassDoCommand(403);
                   // iCurrentRow = e.RowIndex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            PassDoCommand(403);
        }
        #endregion
        /*
      函数：int recipe_check(int aitem)
      参数：aitem具体取值下：
       1：住院医生工作站保存自动审查；
      33：门诊医生工作站保存自动审查；
       3：手工审查；
      12：用药研究；
      6：警告查询；
     功能：PASS自动审查、手动审查、用药研究、警告值查询
     */
        /// <summary>
        /// PASS自动审查、手动审查、用药研究、警告值查询
        /// </summary>
        /// <param name="aitem">
        /// aitem具体取值下：
        /// 1：住院医生工作站保存自动审查；
        /// 33：门诊医生工作站保存自动审查；
        /// 3：手工审查；
        ///12：用药研究；
        ///6：警告查询；</param>
        /// <returns>警告值</returns>

        public  int recipe_check(int aitem, DataGridEx[] mydatagrid,DateTime dt,int type,ref CfInfo[] cfinfo,int curindex)
        {
             if (PassGetState("0") == 0)//判断服务程序是否正在运行
                throw new Exception("PASS服务未正常，请检查相关配置！！");
            DateTime severtime = dt;//取数据库时间;
            int iRow, iRowcount;
            int iCurrentrow;
            DataTable Yztable;//长期医嘱
            DataTable Yztable1;//临时医嘱
            int count = 0;
            
           

            //传处方用药清单
            //string ls_isdrug;   //医嘱类别
            //string ls_iscancel;  //是否作废
            //string ls_isstop;    //是否停嘱
            string sStartDate ="";   //开嘱日期
            string sStopDate;     //停嘱日期
            string sOrderUniqueCode;   //医嘱唯一码
            string sDrugCode;    //药品唯一码
            string sDrugName;   //药品名称
            string sSingleDose;   //单次剂量值
            string sDoseUnit;     //单次剂量单位
            string sFrequency;    //用药频次
            string sRouteName;   //给药途径名称
            string sGroupTag="-1";    //成组医嘱标记
            string sOrderType;   //医嘱类型（长期/临时）
            string sDoctorCodeAndName; //医生编码/姓名
            string sCurrow_OrderUniqueCode;

            int iWarn, iMaxWarn = -1;

            //PASS系统不调动或异常，则返回
            if (PassGetState("0") == 0)
            {
                MessageBox.Show("PASS服务未正常，请检查相关配置！！");
                return 0;
            }


            try
            {

                /*循环传入病人当天所有用药信息，具体要求如下：
                    1、如果是门诊处方，则要求处方内的所有用药记录信息（非药品类信息不传）；
                    2、如果是病区医嘱，则要求传入所有未停长期药品类医嘱和当天开立的临时药品类医嘱。注意以下医嘱不能传入：
                    （）、非药品类医嘱不能传入；
                    （）、已停长期医嘱不能传入；
                    （）、已作废医嘱不能传入；
                    （）、非当天开的临时医嘱不能传入；
                */
                int I = 0;
                //用于保存一组的信息
                string pc = "";//频次
                string yf = "";//用法
                string kyzsj = "";//开医嘱时间
                // int   hx = iRow;
                int zflag = 0;//组标记
                int flag = 0;//记录这组医嘱是否符合要求
                if (type == 0)
                {
                    Yztable = (DataTable)mydatagrid[0].DataSource;
                    count = Yztable.Rows.Count;

                    iRowcount = count;//病人用药清单数据的行数
                    int[] laRow = new int[count];
                    string[] laOrderUniqueCode = new string[count];
                    if (iRowcount != 0)
                    {
                        //取当前行号
                        iCurrentrow = mydatagrid[0].CurrentCell.RowNumber;
                        #region 住院
                        for (iRow = 0; iRow < iRowcount; iRow++)
                        {
                            //ls_isdrug = dgvDrugList.Rows[ll_row].Cells["colType"].Value.ToString();//是否是药品类医嘱
                            //ls_isstop = "";//是否已停嘱
                            //ls_iscancel = "";//是否已作废
                            //如果当前医嘱为非药品类医嘱或已停或已作废，则不能传入此记录，而应进入下一循环。
                            //if (ls_isdrug != "药品类医嘱" || ls_isstop == "已停" || ls_iscancel == "已作废")
                            //{
                            //    continue;
                            //}
                            //[开嘱日期]：字符串类型，传入参数，表示开立医嘱日期。格式为"yyyy-mm-dd"，例如开嘱日期为年月日，则应传入"1999-03-12"。
                            if (Yztable.Rows[iRow]["开始时间"].ToString().Trim()!="")
                                sStartDate = Convert.ToDateTime(Yztable.Rows[iRow]["开始时间"].ToString()).ToString("yyyy-MM-dd");

                            //ls_StopDate [停嘱日期]：字符串类型，传入参数，表示停嘱日期，格式为"yyyy-mm-dd"，例如开嘱日期为年月日，
                            //                        则应传入"1999-03-12"。临嘱停嘱日期等于开嘱日期，未停长期医嘱停嘱日期取当天。
                            // ls_StopDate = dgvDrugList.Rows[ll_row].Cells[18].Value.ToString();
                            //[医嘱类型]：指是长期医嘱还是临时医嘱，ls_OrderType='0'表示长期医嘱；ls_OrderType='1'，表示临时医嘱；
                            try
                            {
                                if (Yztable.Rows[iRow]["类"].ToString() == "长")
                                {
                                    sOrderType = "0";
                                }
                                else
                                {
                                    sOrderType = "1";
                                }
                            }
                            catch (Exception ex)
                            {
                                sOrderType = "1";
                            }


                            if (sOrderType == "1")
                            {
                                sStopDate = sStartDate;//如果为临时医嘱，则停嘱日期等于开嘱日期
                            }
                            else
                            //如果为长期医嘱，则取停嘱日期，如果未停，则停嘱日期为当天
                            {
                                 
                                sStopDate =Yztable.Rows[iRow]["停嘱时间"].ToString() ;
                                if (sStopDate == string.Empty || sStopDate.Trim() == "")
                                {
                                    sStopDate = dt.ToString("yyyy-MM-dd"); //DateManager.ServerDateTimeByDBType(frmm);//取数据库时间; 
                                }
                                else
                                    sStopDate = Convert.ToDateTime(sStopDate).ToString("yyyy-MM-dd");
                            }
                            //非药品
                            if (Yztable.Rows[iRow]["xmly"].ToString() != "1")
                                continue;
                            //如果为非当天用药，则进入下一循环
                            //if (DateTime.Compare(DateTime.Parse(ls_StopDate), System.DateTime.Today) < 0)
                            //{
                            //    continue;
                            //}
                            //[药品唯一码]：字符串类型，传入参数，表示药品唯一码，要求与PASS系统配对时采用的药品唯一码完全一致，否则PASS系统无法
                            //识别药品信息。此参数不能为空。
                            sDrugCode = Getggid(Yztable.Rows[iRow]["hoitem_id"].ToString());
                            //如果药药品唯一码为空,医嘱内容为空，则进入下一循环
                            if (Yztable.Rows[iRow]["医嘱内容"].ToString().Trim() == "" || sDrugCode == string.Empty)
                            {
                                continue;
                            }

                            if (Yztable.Rows[iRow]["xmly"].ToString() == "1")
                            {
                                //如果是一组医嘱的话
                                if (Yztable.Rows[iRow]["开始时间"].ToString() != "")
                                {

                                    if (sOrderType == "0")
                                    {
                                        #region 长期医嘱
                                        string tzsj = Yztable.Rows[iRow]["停嘱时间"].ToString() == "" ? severtime.AddDays(2).ToShortDateString() : Convert.ToDateTime(Yztable.Rows[iRow]["停嘱时间"].ToString()).ToShortDateString();
                                        if (((Convert.ToDateTime(tzsj) >= Convert.ToDateTime(severtime.ToShortDateString()) && Yztable.Rows[iRow]["status_flag"].ToString() == "5") || Yztable.Rows[iRow]["status_flag"].ToString() != "5"))
                                        {
                                            zflag++;
                                            flag = 1;
                                            pc = Yztable.Rows[iRow]["频率"].ToString().Trim();
                                            yf = Yztable.Rows[iRow]["用法"].ToString().Trim();
                                            kyzsj = (Convert.ToDateTime(Yztable.Rows[iRow]["开始时间"])).ToString("yyyy-MM-dd");
                                            sGroupTag = zflag.ToString();
                                        }
                                        else
                                        {
                                            flag = 0;
                                            continue;
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region 临时医嘱
                                        if ((Convert.ToDateTime(Convert.ToDateTime(Yztable.Rows[iRow]["开始时间"].ToString()).ToShortDateString()) == Convert.ToDateTime(severtime.ToShortDateString()))//今天开的所有临时医嘱
                                             )
                                        {
                                            pc = Yztable.Rows[iRow]["频率"].ToString().Trim();
                                            yf = Yztable.Rows[iRow]["用法"].ToString().Trim();
                                            kyzsj = (Convert.ToDateTime(Yztable.Rows[iRow]["开始时间"])).ToString("yyyy-MM-dd");
                                            zflag++;
                                            flag = 1;
                                            sGroupTag = zflag.ToString();
                                        }
                                        else
                                        {
                                            flag = 0;
                                            continue;
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    if (flag == 1)
                                        sGroupTag = zflag.ToString();
                                    else
                                        continue;//跳出本次循环

                                }
                            }

                            //[医嘱唯一码]:字符串类型，传入参数，表示医嘱唯一码，PASS系统将根据此参数来识别和区分传入的各条医嘱记录，
                            //审查后HIS系统只能通过此参数来获取PASS审查的结果值。在同一循环传入时，要求各记录的ls_OrderUniqueCodee值
                            //必须唯一，例如，可传入记录的行号值。
                            sOrderUniqueCode = Yztable.Rows[iRow]["id"].ToString();
                            //将行号和医嘱唯一码保存到动态数组中
                            I++;
                            laRow[iRow] = iRow;
                            laOrderUniqueCode[iRow] = sOrderUniqueCode;
                            //[药品名称]：符串类型，传入参数，表示药品名称。
                            sDrugName = Yztable.Rows[iRow]["医嘱内容"].ToString();
                            sSingleDose = Yztable.Rows[iRow]["剂量"].ToString();
                            //[单次剂量单位]：字符串类型，传入参数，表示每次服用剂量单位，要求与药品配对剂量单位完全一致单位完全一致，否则可能造成
                            //剂量审查不正确。
                            sDoseUnit = Yztable.Rows[iRow]["单位"].ToString();
                            if (Yztable.Rows[iRow]["dwlx"].ToString().IndexOf("1") < 0 && Yztable.Rows[iRow]["dwlx"].ToString().Trim() != "9")//不是含量单位
                            {
                                string dwlx = Yztable.Rows[iRow]["dwlx"].ToString().Replace("9", "");
                                //单位转换 2012-6-6
                                DataTable dv = GetDrugDw(sDrugCode, Yztable.Rows[iRow]["EXEC_DEPT"].ToString());
                                if (dv.Rows.Count > 0)
                                {
                                    Decimal jl = 0;
                                    switch (Yztable.Rows[iRow]["dwlx"].ToString())
                                    {
                                        case "1"://含量单位
                                            jl = Convert.ToDecimal(Yztable.Rows[iRow]["剂量"]);
                                            break;
                                        case "2"://包装单位
                                            jl = Convert.ToDecimal(Yztable.Rows[iRow]["剂量"]) * Convert.ToDecimal(dv.Rows[0]["dwhl"]);
                                            break;
                                        case "3"://药库单位
                                            jl = Convert.ToDecimal(Yztable.Rows[iRow]["剂量"]) * Convert.ToDecimal(dv.Rows[0]["bzsl"]) * Convert.ToDecimal(dv.Rows[0]["dwhl"]);
                                            break;
                                        case "4"://药房单位
                                            jl = (Convert.ToDecimal(Yztable.Rows[iRow]["剂量"]) / Convert.ToDecimal(dv.Rows[0]["dwbl"])) * Convert.ToDecimal(dv.Rows[0]["bzsl"]) * Convert.ToDecimal(dv.Rows[0]["dwhl"]);
                                            break;
                                    }
                                    sSingleDose = jl.ToString();
                                    sDoseUnit = dv.Rows[0]["dwmc"].ToString();
                                }
                            }


                            //[用药频次]:字符串类型，传入参数，表示药品服用频次信息。
                            //传入要求：n天m次，传"m/n"，例如：天次，传"3/1"；天次，传"2/7"。
                            string pcsql = "select * from JC_FREQUENCY where name='" + pc + "'";
                            DataTable temp = FrmMdiMain.Database.GetDataTable(pcsql);
                            if (temp != null && temp.Rows.Count > 0)
                            {
                                if (temp.Rows[0]["lx"].ToString() == "1")
                                    pc = temp.Rows[0]["EXECNUM"].ToString() + "/" + "1";
                                else
                                    pc = temp.Rows[0]["EXECNUM"].ToString() + "/" + temp.Rows[0]["CYCLENUM"].ToString();
                            }
                            sFrequency = pc;//这里需要修改**************************************88888*
                            //[给药途径名称]：字符串类型，传入参数，表示给药途径名称，例如"口服"、"静滴"等。注意，由于PASS系统审查与给药途径关系密切，
                            //此参数传入错误，将直接导致审查错误；如果传空，则导致PASS系统不作任何审查。
                            sRouteName = yf;
                            //  **************
                            //sGroupTag = Yztable.Rows[iRow]["嘱号"].ToString();
                            //[医生编码/名称]：字符串类型，传入参数，表示医生姓名，主要用于PASS审查结果数据采集与查询统计。格式为"科室编码/名称"，例如"04/王彬"，其中"04"为医生编码。
                            //传入一条药品信息
                            sDoctorCodeAndName = Yztable.Rows[iRow]["ORDER_DOC"].ToString() + "/" + Yztable.Rows[iRow]["下嘱医生"].ToString();
                            if (sDoctorCodeAndName == "/")
                                sDoctorCodeAndName = FrmMdiMain.CurrentUser.EmployeeId + "/" + FrmMdiMain.CurrentUser.Name;
                            //如果为单药警告信息查询时，要求调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                            PassSetRecipeInfo(sOrderUniqueCode, sDrugCode, sDrugName, sSingleDose, sDoseUnit, sFrequency, sStartDate, sStopDate, sRouteName, sGroupTag, sOrderType, sDoctorCodeAndName);
                        }

                        //如果为单药警告信息查询时，要求调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                        if (aitem == 6)
                        {
                            //ls_Currow_OrderUniqueCode：字符串类型，要求获当前药品记录对应的医嘱唯一码（即ls_OrderUniqueCode）值。
                            sCurrow_OrderUniqueCode = Yztable.Rows[mydatagrid[0].CurrentCell.RowNumber]["id"].ToString();
                            //调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                            PassSetWarnDrug(sCurrow_OrderUniqueCode);
                        }


                        // return iMaxWarn;
                        #endregion
                    }
                    Yztable1 = (DataTable)mydatagrid[1].DataSource;

                    int[] laRowls = new int[Yztable1.Rows.Count];
                    string[] laOrderUniqueCodels = new string[Yztable1.Rows.Count];
                    #region 临时医嘱
                    #region 住院临时
                    for (iRow = 0; iRow < Yztable1.Rows.Count; iRow++)
                    {
                        if (Yztable1.Rows[iRow]["开始时间"].ToString().Trim()!="")
                        sStartDate =Convert.ToDateTime( Yztable1.Rows[iRow]["开始时间"].ToString()).ToString("yyyy-MM-dd");
                        sOrderType = "1";



                        if (sOrderType == "1")
                        {
                            sStopDate = sStartDate;//如果为临时医嘱，则停嘱日期等于开嘱日期
                        }
                        else
                        //如果为长期医嘱，则取停嘱日期，如果未停，则停嘱日期为当天
                        {
                            sStopDate = Yztable1.Rows[iRow]["停嘱时间"].ToString();
                            if (sStopDate == string.Empty || sOrderType.Trim() == "")
                            {
                                sStopDate = dt.ToString("yyyy-MM-dd"); //DateManager.ServerDateTimeByDBType(frmm);//取数据库时间;
                            }
                            else
                                sStopDate = Convert.ToDateTime(sStopDate).ToString("yyyy-MM-dd");
                        }
                        //非药品
                        if (Yztable1.Rows[iRow]["xmly"].ToString() != "1")
                            continue;
                        //如果为非当天用药，则进入下一循环
                        //if (DateTime.Compare(DateTime.Parse(ls_StopDate), System.DateTime.Today) < 0)
                        //{
                        //    continue;
                        //}
                        //[药品唯一码]：字符串类型，传入参数，表示药品唯一码，要求与PASS系统配对时采用的药品唯一码完全一致，否则PASS系统无法
                        //识别药品信息。此参数不能为空。
                        sDrugCode = Getggid(Yztable1.Rows[iRow]["hoitem_id"].ToString());
                        //如果药药品唯一码为空,医嘱内容为空，则进入下一循环
                        if (Yztable1.Rows[iRow]["医嘱内容"].ToString().Trim() == "" || sDrugCode == string.Empty)
                        {
                            continue;
                        }

                        if (Yztable1.Rows[iRow]["xmly"].ToString() == "1")
                        {
                            //如果是一组医嘱的话
                            if (Yztable1.Rows[iRow]["开始时间"].ToString() != "")
                            {


                                #region 临时医嘱
                                if ((Convert.ToDateTime(Convert.ToDateTime(Yztable1.Rows[iRow]["开始时间"].ToString()).ToShortDateString()) == Convert.ToDateTime(severtime.ToShortDateString()))//今天开的所有临时医嘱
                                     )
                                {
                                    pc = Yztable1.Rows[iRow]["频率"].ToString().Trim();
                                    yf = Yztable1.Rows[iRow]["用法"].ToString().Trim();
                                    kyzsj = (Convert.ToDateTime(Yztable1.Rows[iRow]["开始时间"])).ToString("yyyy-MM-dd");
                                    zflag++;
                                    flag = 1;
                                    sGroupTag = zflag.ToString();
                                }
                                else
                                {
                                    flag = 0;
                                    continue;
                                }
                                #endregion
                            }
                            else
                            {
                                if (flag == 1)
                                    sGroupTag = zflag.ToString();
                                else
                                    continue;//跳出本次循环

                            }
                        }

                        //[医嘱唯一码]:字符串类型，传入参数，表示医嘱唯一码，PASS系统将根据此参数来识别和区分传入的各条医嘱记录，
                        //审查后HIS系统只能通过此参数来获取PASS审查的结果值。在同一循环传入时，要求各记录的ls_OrderUniqueCodee值
                        //必须唯一，例如，可传入记录的行号值。
                        sOrderUniqueCode = Yztable1.Rows[iRow]["id"].ToString();
                        //将行号和医嘱唯一码保存到动态数组中
                        I++;
                        laRowls[iRow] = iRow;
                        laOrderUniqueCodels[iRow] = sOrderUniqueCode;
                        //[药品名称]：符串类型，传入参数，表示药品名称。
                        sDrugName = Yztable1.Rows[iRow]["医嘱内容"].ToString();
                        sSingleDose = Yztable1.Rows[iRow]["剂量"].ToString();
                        //[单次剂量单位]：字符串类型，传入参数，表示每次服用剂量单位，要求与药品配对剂量单位完全一致单位完全一致，否则可能造成
                        //剂量审查不正确。
                        sDoseUnit = Yztable1.Rows[iRow]["单位"].ToString();
                        string ssdwlx = "";
                        if (Yztable1.Rows[iRow]["jldwlx"].ToString().Trim() != "")
                            ssdwlx = Yztable1.Rows[iRow]["jldwlx"].ToString();
                        else
                            ssdwlx = Yztable1.Rows[iRow]["dwlx"].ToString();
                        if (ssdwlx.IndexOf("1") < 0 && ssdwlx.Trim() != "9")//不是含量单位
                        {
                            string dwlx = ssdwlx.Replace("9", "");
                            //单位转换 2012-6-6
                            DataTable dv = GetDrugDw(sDrugCode, Yztable1.Rows[iRow]["EXEC_DEPT"].ToString());
                            if (dv.Rows.Count > 0)
                            {
                                Decimal jl = 0;
                                switch (Yztable1.Rows[iRow]["dwlx"].ToString())
                                {
                                    case "1"://含量单位
                                        jl = Convert.ToDecimal(Yztable1.Rows[iRow]["剂量"]);
                                        break;
                                    case "2"://包装单位
                                        jl = Convert.ToDecimal(Yztable1.Rows[iRow]["剂量"]) * Convert.ToDecimal(dv.Rows[0]["dwhl"]);
                                        break;
                                    case "3"://药库单位
                                        jl = Convert.ToDecimal(Yztable1.Rows[iRow]["剂量"]) * Convert.ToDecimal(dv.Rows[0]["bzsl"]) * Convert.ToDecimal(dv.Rows[0]["dwhl"]);
                                        break;
                                    case "4"://药房单位
                                        jl = (Convert.ToDecimal(Yztable1.Rows[iRow]["剂量"]) / Convert.ToDecimal(dv.Rows[0]["dwbl"])) * Convert.ToDecimal(dv.Rows[0]["bzsl"]) * Convert.ToDecimal(dv.Rows[0]["dwhl"]);
                                        break;
                                }
                                sSingleDose = jl.ToString();
                                sDoseUnit = dv.Rows[0]["dwmc"].ToString();
                            }
                        }
                        //[用药频次]:字符串类型，传入参数，表示药品服用频次信息。
                        //传入要求：n天m次，传"m/n"，例如：天次，传"3/1"；天次，传"2/7"。
                        string pcsql = "select * from JC_FREQUENCY where name='" + pc + "'";
                        DataTable temp = FrmMdiMain.Database.GetDataTable(pcsql);
                        if (temp != null && temp.Rows.Count > 0)
                        {
                            if (temp.Rows[0]["lx"].ToString() == "1")
                                pc = temp.Rows[0]["EXECNUM"].ToString() + "/" + "1";
                            else
                                pc = temp.Rows[0]["EXECNUM"].ToString() + "/" + temp.Rows[0]["CYCLENUM"].ToString();
                        }
                        else
                        {
                            pc = "1/1";
                        }
                        sFrequency = pc;//这里需要修改**************************************88888*
                        //[给药途径名称]：字符串类型，传入参数，表示给药途径名称，例如"口服"、"静滴"等。注意，由于PASS系统审查与给药途径关系密切，
                        //此参数传入错误，将直接导致审查错误；如果传空，则导致PASS系统不作任何审查。
                        sRouteName = yf;
                        //  **************
                        //sGroupTag = Yztable.Rows[iRow]["嘱号"].ToString();
                        //[医生编码/名称]：字符串类型，传入参数，表示医生姓名，主要用于PASS审查结果数据采集与查询统计。格式为"科室编码/名称"，例如"04/王彬"，其中"04"为医生编码。
                        //传入一条药品信息
                        sDoctorCodeAndName = Yztable1.Rows[iRow]["ORDER_DOC"].ToString() + "/" + Yztable1.Rows[iRow]["下嘱医生"].ToString();
                        if (sDoctorCodeAndName == "/")
                            sDoctorCodeAndName = FrmMdiMain.CurrentUser.EmployeeId + "/" + FrmMdiMain.CurrentUser.Name;
                        //如果为单药警告信息查询时，要求调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                        PassSetRecipeInfo(sOrderUniqueCode, sDrugCode, sDrugName, sSingleDose, sDoseUnit, sFrequency, sStartDate, sStopDate, sRouteName, sGroupTag, sOrderType, sDoctorCodeAndName);
                    }

                    //如果为单药警告信息查询时，要求调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                    if (aitem == 6)
                    {
                        //ls_Currow_OrderUniqueCode：字符串类型，要求获当前药品记录对应的医嘱唯一码（即ls_OrderUniqueCode）值。
                        sCurrow_OrderUniqueCode = Yztable1.Rows[mydatagrid[1].CurrentCell.RowNumber]["id"].ToString();
                        //调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                        PassSetWarnDrug(sCurrow_OrderUniqueCode);
                    }



                    #endregion
                    #endregion

                    //调用审查函数
                    PassDoCommand(aitem);

                    iMaxWarn = 0;
                    if ((aitem == 1) || (aitem == 2) || (aitem == 3) || (aitem == 33) || (aitem == 34))
                    {
                        //如果为住院（门诊）医生工作站保存、提交自动审查，则返回审查结果值并在HIS界面亮灯。
                        for (I = 0; I < laRow.Length; I++)
                        {
                            if (laOrderUniqueCode[I] == null)
                                continue;
                            iWarn = PassGetWarn(laOrderUniqueCode[I].Trim().ToString());
                            if (iWarn == 3)
                            {
                                iMaxWarn = 3;  //给数据窗口警告列赋值
                            }
                            iRow = laRow[I];
                            //给警告列赋值后，将状态改为非修改状态，用户可以考虑实际情况是否需要修改状态。
                            //dgvDrugList.Rows[ll_row].Cells[1].Value = li_Warn;
                            switch (iWarn)
                            {
                                case 0:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._0;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 0;
                                    Yztable.Rows[iRow]["警示灯"] = 0;
                                    break;
                                case 1:
                                    // ((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._1;
                                    // ((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 1;
                                    Yztable.Rows[iRow]["警示灯"] = 1;
                                    break;
                                case 2:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._2;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 2;
                                    Yztable.Rows[iRow]["警示灯"] = 2;
                                    break;
                                case 3:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._3;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 3;
                                    Yztable.Rows[iRow]["警示灯"] = 3;
                                    break;
                                case 4:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._4;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 4;
                                    Yztable.Rows[iRow]["警示灯"] = 4;
                                    break;
                                default:
                                    break;

                            }
                            // dgvDrugList.Rows[I].Cells[1].ReadOnly = true;
                        }
                        mydatagrid[0].DataSource = Yztable;
                    }
                    if ((aitem == 1) || (aitem == 2) || (aitem == 3) || (aitem == 33) || (aitem == 34))
                    {
                        //如果为住院（门诊）医生工作站保存、提交自动审查，则返回审查结果值并在HIS界面亮灯。
                        for (I = 0; I < laRowls.Length; I++)
                        {
                            if (laOrderUniqueCodels[I] == null)
                                continue;
                            iWarn = PassGetWarn(laOrderUniqueCodels[I].Trim().ToString());
                            if (iWarn == 3)
                            {
                                iMaxWarn = 3;  //给数据窗口警告列赋值
                            }
                            iRow = laRowls[I];
                            //给警告列赋值后，将状态改为非修改状态，用户可以考虑实际情况是否需要修改状态。
                            //dgvDrugList.Rows[ll_row].Cells[1].Value = li_Warn;
                            switch (iWarn)
                            {
                                case 0:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._0;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 0;
                                    Yztable1.Rows[iRow]["警示灯"] = 0;
                                    break;
                                case 1:
                                    // ((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._1;
                                    // ((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 1;
                                    Yztable1.Rows[iRow]["警示灯"] = 1;
                                    break;
                                case 2:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._2;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 2;
                                    Yztable1.Rows[iRow]["警示灯"] = 2;
                                    break;
                                case 3:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._3;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 3;
                                    Yztable1.Rows[iRow]["警示灯"] = 3;
                                    break;
                                case 4:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._4;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 4;
                                    Yztable1.Rows[iRow]["警示灯"] = 4;
                                    break;
                                default:
                                    break;

                            }
                            // dgvDrugList.Rows[I].Cells[1].ReadOnly = true;
                        }
                    }
                    mydatagrid[1].DataSource = Yztable1;
                    return iMaxWarn;
                }
                else
                {
                    //门诊
                    #region
                    int[] laRow = new int[cfinfo.Length];
                    string[] laOrderUniqueCode = new string[cfinfo.Length];
                    for (iRow = 0; iRow < cfinfo.Length; iRow++)
                    {
                        sStartDate = cfinfo[iRow].kyzsj.ToString("yyyy-MM-dd");
                        sStopDate = cfinfo[iRow].kyzsj.ToString("yyyy-MM-dd"); //取空
                        if (cfinfo[iRow].xmly == 2)
                            continue;

                        sOrderUniqueCode = cfinfo[iRow].yzid;
                        laOrderUniqueCode[iRow] = sOrderUniqueCode;
                        laRow[iRow] = iRow;
                        sGroupTag = cfinfo[iRow].zh.ToString();
                        sDrugName = cfinfo[iRow].yzmc;
                        sSingleDose = cfinfo[iRow].jl;
                        sDrugCode = Getggid(cfinfo[iRow].xmid);
                        //[单次剂量单位]：字符串类型，传入参数，表示每次服用剂量单位，要求与药品配对剂量单位完全一致单位完全一致，否则可能造成
                        //剂量审查不正确。
                        sDoseUnit = cfinfo[iRow].dwmc;

                        string pcsql = "select * from JC_FREQUENCY where name='" + cfinfo[iRow].pc + "'";
                        DataTable temp = FrmMdiMain.Database.GetDataTable(pcsql);
                        if (temp != null && temp.Rows.Count > 0)
                        {
                            if (temp.Rows[0]["lx"].ToString() == "1")
                                pc = temp.Rows[0]["EXECNUM"].ToString() + "/" + "1";
                            else
                                pc = temp.Rows[0]["EXECNUM"].ToString() + "/" + temp.Rows[0]["CYCLENUM"].ToString();
                        }
                        sFrequency = pc;
                        sRouteName = cfinfo[iRow].yf;
                        sOrderType = "1";
                        sDoctorCodeAndName = cfinfo[iRow].kyzysid + "/" + cfinfo[iRow].kyzysmc;
                        //如果为单药警告信息查询时，要求调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                        PassSetRecipeInfo(sOrderUniqueCode, sDrugCode
                            , sDrugName, sSingleDose, sDoseUnit, sFrequency, sStartDate, sStopDate, sRouteName, sGroupTag, sOrderType, sDoctorCodeAndName);

                    }
                    //如果为单药警告信息查询时，要求调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                    if (aitem == 6)
                    {
                        //ls_Currow_OrderUniqueCode：字符串类型，要求获当前药品记录对应的医嘱唯一码（即ls_OrderUniqueCode）值。
                        sCurrow_OrderUniqueCode = cfinfo[curindex].yzid.ToString();
                        //调用PassSetWarnDrug()函数传入当前行对应的医嘱唯一码值。
                        PassSetWarnDrug(sCurrow_OrderUniqueCode);
                    }
                    //调用审查函数
                    PassDoCommand(aitem);
                    if ((aitem == 1) || (aitem == 2) || (aitem == 3) || (aitem == 33) || (aitem == 34))
                    {
                        //如果为住院（门诊）医生工作站保存、提交自动审查，则返回审查结果值并在HIS界面亮灯。
                        for (I = 0; I < laRow.Length; I++)
                        {
                            if (laOrderUniqueCode[I] == null)
                                continue;
                            iWarn = PassGetWarn(laOrderUniqueCode[I].Trim().ToString());
                            if (iWarn == 3)
                            {
                                iMaxWarn = 3;  //给数据窗口警告列赋值
                            }
                            iRow = laRow[I];
                            //给警告列赋值后，将状态改为非修改状态，用户可以考虑实际情况是否需要修改状态。
                            //dgvDrugList.Rows[ll_row].Cells[1].Value = li_Warn;
                            switch (iWarn)
                            {
                                case 0:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._0;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 0;
                                    cfinfo[iRow].jsd = 0;
                                    break;
                                case 1:
                                    // ((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._1;
                                    // ((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 1;
                                    cfinfo[iRow].jsd = 1;
                                    break;
                                case 2:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._2;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 2;
                                    cfinfo[iRow].jsd = 2;
                                    break;
                                case 3:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._3;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 3;
                                    cfinfo[iRow].jsd = 3;
                                    break;
                                case 4:
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Value = DifTest.Properties.Resources._4;
                                    //((DataGridViewImageCell)dgvDrugList.Rows[iRow].Cells[1]).Tag = 4;
                                    cfinfo[iRow].jsd = 4;
                                    break;
                                default:
                                    break;

                            }
                            // dgvDrugList.Rows[I].Cells[1].ReadOnly = true;
                        }
                    }
                    #endregion
                    return iMaxWarn;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("合理用药分析错误：" + ex.Message);
            }
        }
        private string GetDocname(string docid)
        {
            try
            {
                string sql="select NAME from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID="+docid+"";
                DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                if(tb.Rows.Count>0)
                    return tb.Rows[0]["NAME"].ToString();
            }
            catch
            {
                return "";
            }
            return "";
        }
        private DataTable GetDrugDw(string ggid,string exedept)
        {
             string ss ="";
            if(exedept.Trim()=="")
             ss = "select  HLXS as dwhl,BZSL,DWBL ,c.DWMC  from YP_YPGGD a left join YF_KCMX b on a.GGID=b.GGID left join yp_ypdw c on a.HLDW=c.ID where a.ggid=" + ggid + " ";
            else
             ss = "select  HLXS as dwhl,BZSL,DWBL ,c.DWMC  from YP_YPGGD a left join YF_KCMX b on a.GGID=b.GGID left join yp_ypdw c on a.HLDW=c.ID where a.ggid=" + ggid + " and DEPTID=" + exedept;
            try
            {
                DataTable tb = FrmMdiMain.Database.GetDataTable(ss);
                return tb;
            }
            catch (Exception ex)
            {
                throw new Exception("单位转换错误：" + ex.Message+ss);
            }
        }
        /// <summary>
        /// 通过厂家id获得ggid
        /// </summary>
        /// <param name="cjid"></param>
        /// <returns></returns>
        private string Getggid(string cjid)
        {
            string sql = "select b.ggid from YP_YPCJD a join YP_YPGGD b on a.GGID=b.GGID  where  a.BDELETE=0 and b.BDELETE=0 and a.CJID=" + cjid + "";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            if (tb == null || tb.Rows.Count == 0)    
            {
                //MessageBox.Show("没有找到该药品！！");
                return null;
            }
            string ggid = tb.Rows[0]["ggid"].ToString().Trim();
            return ggid;
        }
    }
}
