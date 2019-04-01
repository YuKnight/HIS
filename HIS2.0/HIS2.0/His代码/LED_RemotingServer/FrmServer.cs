using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemoteObj;
using ICommon;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using System.Collections;
using System.Diagnostics;

namespace LED_RemotingServer
{
    public partial class FrmServer : Form
    {
        public FrmServer(RelationalDatabase db)
        {
            InitializeComponent();
            BDatabase = db;
            this.Icon = new System.Drawing.Icon("recourse/network computer.ico");
            notifyIcon1.Icon = new Icon("recourse/my computer.ico");
            this.toolStripStatusLabel1.ForeColor = Color.Red;
        }

        RelationalDatabase BDatabase;
        private static int state = 0;
        /// <summary>
        /// 清屏时间，默认5分
        /// </summary>
        private static int _qingpingshijian=5;
        /// <summary>
        /// 控制的所有窗体
        /// </summary>
        public static readonly string showwindowstring = ApiFunction.GetIniString("LED服务器", "显示窗体", Constant.ApplicationDirectory + "//LedCalling.ini");
        /// <summary>
        /// 呼叫次数
        /// </summary>
        public static readonly int calltimes = Convert.ToInt32(ApiFunction.GetIniString("LED服务器", "呼叫次数", Constant.ApplicationDirectory + "//LedCalling.ini"));
        /// <summary>
        /// 等候窗体索引
        /// </summary>
        public static readonly string orderwindows = ApiFunction.GetIniString("LED服务器", "等候窗体索引", Constant.ApplicationDirectory + "//LedCalling.ini");
        /// <summary>
        /// 规定暂时等待人数
        /// </summary>
        public static readonly string perCount = ApiFunction.GetIniString("LED服务器", "规定显示等待人数", Constant.ApplicationDirectory + "//LedCalling.ini");

        public static string sentens = ApiFunction.GetIniString("LED服务器", "窗体标语", Constant.ApplicationDirectory + "//LedCalling.ini");
        private SpeechCall speCall = new SpeechCall();
        private LED_Operate ledOper = new LED_Operate();
        IList<WindowsInfo> windows = new List<WindowsInfo>();
        private System.Timers.Timer myTimer;
 

        //窗体列
        string[] strs;
        /// <summary>
        /// 已被叫号的人姓名队列
        /// </summary>
        ArrayList List = new ArrayList();

        private void FrmServer_Load(object sender, EventArgs e)
        {
            try
            {
                LED_Operate.DeleteFile_Log("错误日志");
                LED_Operate.DeleteFile_Log("操作日志");
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Constant.ApplicationDirectory + "\\" + "LED_RemotingServer.exe");

                this.Text = "LED服务端  版本：" + myFileVersionInfo.FileMajorPart + "." + myFileVersionInfo.FileMinorPart + "." + myFileVersionInfo.FileBuildPart + "." + myFileVersionInfo.FilePrivatePart;

               
                TcpServerChannel server = new TcpServerChannel(8080);
                string se = server.GetChannelUri();                
                ChannelServices.RegisterChannel(server, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(LedShow), "LED", WellKnownObjectMode.Singleton);
                //RemotingObj.UsersInfo.SendEventArgs += new RemotingObj.UsersInfo.SendEventHandler(ListBox_Add);
                //RemotingObj.UsersInfo.SendEventArgs += delegate(string s) { MessageBox.Show(s); };
                LedShow.LedShowedEvent += new ICommon.LedShowEventHandler(LedShowMothed);
                listBox1.Items.Add("服务器TCP地址：" + se);
                listBox1.Items.Add("服务器开启时间：" + DateTime.Now.ToString());
                strs = showwindowstring.Split('|');
                if (strs != null)
                {
                    for (int i = 0; i < strs.Length; i++)
                    {
                        WindowsInfo window = new WindowsInfo(i.ToString());
                        window.WinName = strs[i];
                        window.CallTime = DateTime.Now;
                        windows.Add(window);
                        listBox1.Items.Add("窗口" + i.ToString() + "：" + window.WinName);
                    }
                }
                this.toolStripStatusLabel1.Text = "服务启动成功！";
                if (sentens == "")
                {
                    //sentens = "谢谢惠顾";
                }
                //清屏时间
                if (TrasenClasses.GeneralClasses.Convertor.IsInteger(LED_Operate.qingpingshijian))
                {

                    int qingpingshijian = int.Parse(LED_Operate.qingpingshijian);
                    if (qingpingshijian >= 1) _qingpingshijian = qingpingshijian;

                }

                this.WindowState = FormWindowState.Normal;
                myTimer = new System.Timers.Timer(1000*30);//(30000);
                myTimer.Elapsed += Timer_Tick;
                myTimer.Enabled = true;
                myTimer.Start();



            }
            catch (Exception ex) 
            { 
                this.toolStripStatusLabel1.Text = ex.Message;
            }
        }

        /// <summary>
        /// 计时器
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            while (state == 1)
            {

            }
            lock ((object)state)
            {
                 state = 1;
                 try
                 {
                     for (int i = 0; i < windows.Count; i++)
                     {
                         TimeSpan sp = DateTime.Now - windows[i].CallTime;
                         if (sp.TotalMinutes > _qingpingshijian)
                         {
                             windows[i].CallTime = DateTime.Now;
                             ledOper.Display(sentens, Convert.ToInt32(windows[i].WinCode));
                             break;
                         }
                     }
                 }
                 catch (Exception err)
                 {
                     LED_Operate.toText("错误日志", "显示报错：" + err.Message);
                 }
                 state = 0;
            }
        }

        /// <summary>
        /// 语音
        /// </summary>
        private void SpeechCalled(string callString)
        {
            speCall.SpeechCalling(callString);
        }

        
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="name"></param>
        /// <param name="winname"></param>
        /// <param name="wincode"></param>
        /// <param name="deptid"></param>
        private void LedShowMothed(string name, string winname,string wincode,string deptid)
        {
            LED_Operate.toText("操作日志", "LedShowMothed：while begin ");
            while (state == 1)
            {

            }
            
            lock ((object)state)
            {
                LED_Operate.toText("操作日志", "lock：begin ");
                state = 1;
                //System.Threading.Thread.Sleep(1000);
                //MessageBox.Show("ddddd");
                string showstring = "请" + name + "取药";
                //string callstring = "请" + name + "到" + winname + "来取药";
                string callstring = "请" + name.Trim() + "" + winname.Trim() + "取药";
                // jianqg 2014-6-11 先显示，再呼叫
                #region 语音 呼叫
                try
                {
                    //改线程
                    LED_Operate.toText("操作日志", "语音：begin ");
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(SpeechCalled_thread));
                    thread.Start(callstring);
                    ////toText(name, deptname);
                    //int cs = calltimes;//释放资源
                    //if (cs <= 0) cs = 1;
                    //for (int i = 0; i < cs - 1; i++)
                    //{
                    //    SpeechCalled(callstring);
                    //}


                }
                catch (Exception ex)
                {
                    LED_Operate.toText("错误日志", "叫号错误：" + ex.Message);
                }
                #endregion
                #region //输出显示
                try
                {
                    //一个窗口叫同一个人姓名，则不再往已叫号队列中插入该人姓名
                    for (int i = 0; i < windows.Count; i++)
                    {
                        //if (windows[i].WinCode == wincode && windows[i].Calling == name)
                        //    return;
                        if (windows[i].WinCode == wincode && windows[i].Calling != name)
                        {
                            //MessageBox.Show(name);
                            windows[i].Calling = name;
                            windows[i].CallTime = DateTime.Now;//记录叫号时间
                            ledOper.Display(showstring.Trim(), Convert.ToInt32(wincode));
                            //int j = List.IndexOf(name);
                            //if (j == -1)
                            //    List.Add(name);
                            //MessageBox.Show(i.ToString() + windows[i].WinCode + windows[i].Calling + showstring);
                            break;
                        }
                    }
                    //ShowCalled(showstring, winname);
                    //释放资源
                    //ShiFangZiYuan();
                }
                catch (Exception ex)
                {
                    LED_Operate.toText("错误日志", "显示错误：" + ex.Message);
                }
                #endregion
                #region //配置了未发药窗口的编号，就执行叫号未发药的流程
                try
                {
                    //配置了未发药窗口的编号，就执行叫号未发药的流程
                    if (orderwindows != "")
                    {
                        string orderShow = CallOrder(deptid);
                        ledOper.Display(orderShow, Convert.ToInt32(orderwindows));
                        
                    }
                }
                catch (Exception err)
                {
                    LED_Operate.toText("错误日志", "排序错误：" + err.Message);
                }
                #endregion

                LED_Operate.toText("操作日志", "LedShowMothed：end ");
                state = 0;
                //释放资源
                LED_Operate.ShiFangZiYuan();
             
                
                
            }
       
        }

        /// <summary>
        /// 语音呼叫
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void SpeechCalled_thread(object callstring)
        {

            if (callstring == null || callstring.ToString()=="") return;
            #region 语音 呼叫
            
            try
            {
                //toText(name, deptname);
                int cs = calltimes;//释放资源
                if (cs <= 0) cs = 1;
                string callString = callstring.ToString();
                LED_Operate.toText("操作日志", "SpeechCalled_thread：begin ");
                for (int i = 0; i < cs - 1; i++)
                {
                   
                    callString +=  "，" + callstring.ToString();
                    
                   
                }
                SpeechCalled(callString);
                LED_Operate.toText("操作日志", "SpeechCalled_thread：end ");


            }
            catch (Exception ex)
            {
                LED_Operate.toText("错误日志", "叫号错误：" + ex.Message);
            }
            #endregion
        }


        /// <summary>
        /// 生成正在等候的病人名单
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="winindex"></param>
        /// <returns></returns>
        private string CallOrder(string deptid)
        {
            string strsql = ""; //"  AND a.BRXM NOT IN (''";
            //for (int i = 0; i < windows.Count; i++)
            //{
            //    if (!string.IsNullOrEmpty(windows[i].Calling))
            //        strsql += ",'" + windows[i].Calling + "'";
            //}
            //strsql += ") ";
            CallAccess ca = new CallAccess(BDatabase);
            //所有打印处方，但未处理的发药的信息
            DataTable dt = ca.OrderArry(deptid, strsql,perCount);
            StringBuilder callOrder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                //callOrder.Append("呼叫未取药患者：");
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    callOrder.Append(dt.Rows[i]["姓名"].ToString());
                //    callOrder.Append(" ");
                //}
                callOrder.Append("呼叫未取药患者：");
                //打印了发药单，但未发药的患者姓名
                ArrayList _list = new ArrayList();
                //生成打印发药处方，但未发药的患者数据列
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _list.Add(dt.Rows[i]["姓名"].ToString());
                }
                //判断已叫号队列中存在未发药患者数列中
                for (int i = 0; i < List.Count; i++)
                {
                    //如果已经发药，就删除叫号队列中的姓名
                    int j = _list.IndexOf(List[i].ToString());
                    //如果已叫号人中没有在未发药患者数列中，就把名称设为空
                    if (j == -1)
                    {                      
                        List[i] = "";
                    }
                    else
                    {
                        //过滤掉正在叫号人的名字
                        if (windows.Count > 0)
                        {
                            int a=0;
                            //判断队列里面是否有正在叫号的数据
                            foreach (WindowsInfo windinfo in windows)
                            {
                                if (windinfo.Calling == List[i].ToString())
                                {
                                    a = 1;
                                    break;
                                }
                            }
                            if (a == 0)
                            {
                                callOrder.Append(List[i].ToString());
                                callOrder.Append(",");
                            }
                        }

                    }
                }
                List.Remove("");
            }
            else
            {
                callOrder.Append("暂无呼叫未取药患者！");
            }
            return callOrder.ToString();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;  //显示在系统任务栏
            this.WindowState = FormWindowState.Normal;  //还原窗体
            notifyIcon1.Visible = false;  //托盘图标隐藏
        }

        private void FrmServer_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
                {
                    notifyIcon1.Visible = true;  //托盘图标可见
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("关闭窗体将无法完成发药呼叫功能，是否继续？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 测试叫号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            SpeechCalled(textBox1.Text);
        }

        /// <summary>
        /// 服务显示频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            ledOper.Send_Reset();
        }

        //private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        //{
        //    LedShowMothed("胡汉三", "窗口1", "166");
        //}
    }
}