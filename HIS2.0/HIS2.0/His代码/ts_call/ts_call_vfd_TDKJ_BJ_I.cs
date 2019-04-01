using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using System.IO;
using System.Data;
using TrasenFrame.Forms;


namespace ts_call
{
    /// <summary>
    /// 上海通导语音报价器
    /// 作者:钟金
    /// 编写日期:2012-04-23 
    /// </summary>
    public class ts_call_vfd_TDKJ_BJ_I : Icall
    {
        /// <summary>
        /// 通导语音报价器型号，1,4默认为1
        /// 
        /// </summary>
        public static int kind = 1;
        public static string _namecode = "";//员工编码

        [DllImport("Tdbjq.dll", EntryPoint = "dsbdll")]
        private static extern int dsbdll(int hPort, string ss);


        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        #region Icall 成员
        private string _empname = "";
        private Thread currentThread;
        public System.Threading.Thread CurrentThread
        {
            get
            {
                return currentThread;
            }
            set
            {
                currentThread = value;
            }
        }

        public void Call(DmType dmtype, string callstring)
        {
            try
            {
                int ncom = Convert.ToInt32(com);
                string[] par = callstring.Split(',');
                if (dmtype == DmType.姓名)
                {
                    //dsbdll(1, "&Sc$");//重新刷姓名的时候都清除掉
                    //2013-8-7修改 原来写死了端口号1
                    dsbdll(ncom, "&Sc$");//重新刷姓名的时候都清除掉
                    dsbdll(ncom, "$1");
                    dsbdll(ncom, "#姓名:" + callstring + "#");
                    dsbdll(ncom, "&C11姓名：" + callstring + "$");//add by zouchihua 2013-6-24
                }
                if (dmtype == DmType.应收)
                {

                    if (par.Length == 1) //卡余额小于应收金额
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + callstring + "J");
                    }
                    else
                    {
                        /*第一行：姓名(科室)，第二行：卡余额，第三行：应收，
                         * 第四行：实收，第五行：找零 Modify by zp 2013-10-25 */
                        dsbdll(ncom, "&Sc$"); //先清除
                        dsbdll(ncom, "$1");
                        dsbdll(ncom, "#姓名:" + par[0] + "#");
                        dsbdll(ncom, "&C11姓名：" + par[0] + par[1] + "$"); //姓名(科室)

                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "&C21卡余额：" + par[2] + "$"); //卡余额 "&C21" + callstring + "$"
                        //dsbdll(ncom, "EE");
                        //dsbdll(ncom, "" + par[2] + "P");
                        //"&C21本院竭诚为您服务$
                        //dsbdll(ncom, "&C11" + par[0].ToString() + "$");  //姓名
                        //dsbdll(ncom, "&C21" + par[1].ToString() + "$"); //总费用

                        //dsbdll(ncom, "$C3");
                        //dsbdll(ncom, "&C31卡余额支付：" + par[3] + "$");//卡余额支付
                        //dsbdll(ncom, "EF");
                        //dsbdll(ncom, "" + par[3] + "P");

                        dsbdll(ncom, "$C3");
                        dsbdll(ncom, "&C31应收现金：" + par[3] + "$");//应收
                        dsbdll(ncom, "D1");
                        dsbdll(ncom, "" + par[3].Substring(0, par[3].Length - 1) + "P");

                    }
                }
                if (dmtype == DmType.实收)
                {

                    if (par.Length == 1) //卡余额小于应收金额
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + callstring + "Y");
                    }
                    else
                    {
                        dsbdll(ncom, "$5");
                        // dsbdll(ncom, "" + par[4] + "Y");
                        dsbdll(ncom, "&C41实收现金：" + par[4] + "$");
                        dsbdll(ncom, "D2");
                        dsbdll(ncom, "" + par[4].Substring(0, par[4].Length - 1) + "P");
                    }
                }
                if (dmtype == DmType.找零)
                {
                    //if (par.Length == 1) //卡余额小于应收金额
                    //{
                    dsbdll(ncom, "$2");
                    dsbdll(ncom, "" + callstring + "Z");
                    //}
                    //else
                    //{
                    //    dsbdll(ncom, "$5");
                    //    dsbdll(ncom, "&C51找零：" + par[5] + "$");
                    //}

                }
                if (dmtype == DmType.欢迎)
                {
                    if (kind == 4)
                    {
                        dsbdll(ncom, "&Sc$"); //清屏  先处理清屏
                        if (callstring == null || callstring == "") callstring = "本院竭诚为您服务";
                        dsbdll(ncom, "&C21" + callstring + "$");
                    }
                    else
                    {
                        if (callstring == "抱歉,暂停工作")
                            dsbdll(ncom, "W");
                        else
                            dsbdll(ncom, "F");
                    }



                }
                if (dmtype == DmType.清除)
                {
                    dsbdll(ncom, "F");
                    //add by zouchihua 2013-6-24
                    dsbdll(ncom, "&Sc$"); //清屏
                }
                if (dmtype == DmType.卡充值)
                {
                    dsbdll(ncom, "$2");
                    dsbdll(ncom, "" + callstring + "" + "Y"); //收您:XXXX元.
                    //dsbdll(ncom, callstring + "P"); //播报 XXX元
                    //dsbdll(ncom, "&C21卡充值：" + callstring+"元$");
                }
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public void Call(string ss, string zl)
        {
            try
            {
                int ncom = Convert.ToInt32(com);

                dsbdll(ncom, "$1");
                dsbdll(ncom, "" + ss.ToString() + "Y");

                //System.Threading.Thread.Sleep(1 * 2000);

                dsbdll(ncom, "$3");
                dsbdll(ncom, "" + zl.ToString() + "Z");
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// 报价显示 Modify By zp 2013-09-16
        /// </summary>
        /// <param name="dmtype">枚举类型</param>
        /// <param name="callstring">显示字符串</param>
        /// <param name="je">金额</param>
        public void Call(DmType dmtype, string callstring, double je)
        {
            try
            {
                int ncom = Convert.ToInt32(com);

                if (dmtype == DmType.姓名)
                {
                    dsbdll(ncom, "$1");
                    dsbdll(ncom, "#姓名:" + callstring + "#");
                }
                else if (dmtype == DmType.找零)
                {
                    #region 注释 2013-09-16
                    //if (callstring == "退款")
                    //{
                    //    dsbdll(ncom, "$2");
                    //    //dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "G");
                    //    dsbdll(ncom, "#退您: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    //}
                    //if (callstring == "补收")
                    //{
                    //    dsbdll(ncom, "$2");
                    //    // dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "J");
                    //    dsbdll(ncom, "#请您补交: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    //}
                    //if (callstring == "暂存")
                    //{
                    //    dsbdll(ncom, "$2");
                    //    //dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "H");
                    //    dsbdll(ncom, "#暂存: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    //}
                    //if (callstring == "欠费")
                    //{
                    //    dsbdll(ncom, "$2");
                    //    // dsbdll(ncom, "-" + Convert.ToString(Math.Abs(je)) + "H");
                    //    dsbdll(ncom, "#您欠费: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    //}
                    //if (callstring == "预交") //Modify By zp 2013-09-16
                    //{
                    //    dsbdll(ncom, "$2");
                    //    dsbdll(ncom, "#您预收: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    //}
                    #endregion
                    string[] par = callstring.Split('|');
                    //dsbdll(ncom, "$2");
                    //for (int i = 0; i < par.Length; i++)
                    //{
                    //    dsbdll(ncom, String.Format("{0}J", par[i]));
                    //}

                    //Modify By Kevin 2013-09-17
                    //Modify By Kevin 2013-10-25
                    //Begin
                    string isVoice = "";
                    isVoice = "P";

                    if (par.Length <= 1)
                    {
                        dsbdll(ncom, "&Sc$");
                        string[] p0 = par[0].ToString().Split('：');
                        string calling = "E7";
                        if (p0[0].ToString() == "退款")
                        {
                            calling = "ED";
                        }
                        dsbdll(ncom, "&C11" + par[0].ToString() + "$");
                        dsbdll(ncom, calling);
                        dsbdll(ncom, par[0].Substring(3) + isVoice);
                    }
                    else
                    {
                        dsbdll(ncom, "&Sc$");
                        dsbdll(ncom, "&C11" + par[0].ToString() + "$");  //姓名
                        dsbdll(ncom, "&C21" + par[1].ToString() + "$"); //总费用
                        dsbdll(ncom, "E1");
                        dsbdll(ncom, par[1].Substring(4) + isVoice);
                        dsbdll(ncom, "&C31" + par[2].ToString() + "$");  //总预交
                        dsbdll(ncom, "E5");
                        dsbdll(ncom, par[2].Substring(4) + isVoice);
                        dsbdll(ncom, "&C41" + par[3].ToString() + "$");  //医保
                        dsbdll(ncom, "EB");
                        dsbdll(ncom, par[3].Substring(5) + isVoice);  //退款，补交
                        string[] p4 = par[4].ToString().Split('：');
                        string calling = "E7";
                        if (p4[0].ToString() == "退款")
                        {
                            calling = "ED";
                        }
                        dsbdll(ncom, "&C51" + par[4].ToString() + "$");
                        dsbdll(ncom, calling);
                        dsbdll(ncom, par[4].Substring(3) + isVoice);
                    }
                    dsbdll(ncom, "D5");

                    //End
                }
                else if (dmtype == DmType.实收)
                {
                    string ss = "";
                    if (je >= 0)
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "J");
                    }
                    else
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "G");
                    }

                }
                else
                {
                    Call(dmtype, callstring);
                }
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            try
            {
                int ncom = Convert.ToInt32(com);

                if (dmtype == DmType.姓名)
                {
                    dsbdll(ncom, "$1");
                    dsbdll(ncom, "#姓名:" + callstring + "#");
                }
                else if (dmtype == DmType.找零)
                {

                    if (callstring == "退款")
                    {
                        dsbdll(ncom, "$2");
                        //dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "G");
                        dsbdll(ncom, "#退您: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "补收")
                    {
                        dsbdll(ncom, "$2");
                        // dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "J");
                        dsbdll(ncom, "#请您补交: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "暂存")
                    {
                        dsbdll(ncom, "$2");
                        //dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "H");
                        dsbdll(ncom, "#暂存: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "欠费")
                    {
                        dsbdll(ncom, "$2");
                        // dsbdll(ncom, "-" + Convert.ToString(Math.Abs(je)) + "H");
                        dsbdll(ncom, "#您欠费: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }

                }
                else if (dmtype == DmType.实收)
                {
                    string ss = "";
                    if (je >= 0)
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "J");
                    }
                    else
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "G");
                    }

                }
                else
                {
                    Call(dmtype, callstring);
                }
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        #endregion


        /// <summary>
        /// 报价器为上海通道4号型，加载操作人图片
        /// </summary>
        /// <param name="ncom">医院工作人员编码</param>
        public void SetPicture(string name)
        {
            try
            {
                //获取医院工作人员员工号 Add by tck 2013-11-20
                string sql = "SELECT CODE FROM Pub_User WHERE Employee_Id='" + name + "'";
                DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                    _empname = dt.Rows[0]["CODE"].ToString();
                if (_namecode == "" || _namecode != _empname)
                {
                    _namecode = _empname;
                    //启用线程加载图片 Add by zp 2013-10-31
                    CurrentThread = new Thread(SetImage);
                    currentThread.IsBackground = true;
                    currentThread.Start();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SetImage()
        {
            try
            {
                int ncom = Convert.ToInt32(com);
                if (kind == 4)
                {
                    string filename = ApiFunction.GetIniString("报价器文件路径", "相册文件夹", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    if (File.Exists(Constant.ApplicationDirectory + "\\" + filename + "//" + _empname + ".bmp"))
                    {
                        dsbdll(ncom, "&B0,0," + Constant.ApplicationDirectory + "\\" + filename + "//" + _empname + ".bmp$");//在0,0位置,显示bmp类型图片
                    }
                    else
                    {
                        dsbdll(ncom, "&B0,0," + Constant.ApplicationDirectory + "\\" + filename + "//默认.bmp$");
                    }
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
            finally
            {
                if (currentThread != null && currentThread.ThreadState==ThreadState.Running)
                   currentThread.Abort();
            }
        }
    }
}
