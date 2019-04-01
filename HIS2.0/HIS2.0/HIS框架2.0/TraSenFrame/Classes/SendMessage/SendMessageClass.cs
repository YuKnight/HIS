using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets; 
using System.IO; 
using System.Threading;
using System.Text;
using System.Data;

using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace TrasenFrame.Classes.SendMessage
{
    /// <summary>
    /// 消息的类型
    /// </summary>
    public enum SendMessageType
    {
        消息,
        通知
    }
    /// <summary>
    /// SendMessageClass 的摘要说明。
    /// </summary>
    public class SendMessageClass
    {
        //		private WebClient client = new WebClient(); 
        private static upForm uf;
        private static TcpClient tpc;
        private static TcpListener serverListener;
        private static NetworkStream netStream;
        private static StreamWriter sw;
        private static StreamReader sr;
        private static Thread th;
        private static bool listenerRun = false;
        private static int temport;//待侦听端口
        private static bool _ShowMessageForm = true;
        private static string _CustomDirectory = "";

        private static System.Timers.Timer timer = new System.Timers.Timer();

        /// <summary>
        /// 消息管理类
        /// </summary>
        public SendMessageClass()
        {
        }

        /// <summary>
        /// 获取或设置是否可以显示消息窗体
        /// </summary>
        public static bool ShowMessageForm
        {
            get { return _ShowMessageForm; }
            set
            {
                AcceptMessage = value;
                upForm.IsOpen = value;
            }
        }
        /// <summary>
        ///  运行过程中是否接收消息
        /// </summary>
        public static bool AcceptMessage
        {
            get
            {
                string svalue = Crypto.Instance().UnCryp(ApiFunction.GetIniString("MESSAGE", "ACCEPTMESSAGE", _CustomDirectory + "\\Server.ini"));
                if (Convertor.IsNumeric(svalue))
                    return svalue == "1" ? true : false;
                else
                    return true;		//默认接收消息
            }
            set
            {
                string acceptMessage = value ? "1" : "0";
                ApiFunction.WriteIniString("MESSAGE", "ACCEPTMESSAGE", Crypto.Instance().Cryp(acceptMessage), _CustomDirectory + "\\Server.ini");
            }
        }
        /// <summary>
        ///  是否有新通知
        /// </summary>
        public static bool NewInFormation
        {
            get
            {
                string svalue = Crypto.Instance().UnCryp(ApiFunction.GetIniString("MESSAGE", "INFORM", _CustomDirectory + "\\Server.ini"));
                if (Convertor.IsNumeric(svalue))
                    return svalue == "1" ? true : false;
                else
                    return true;		//默认接收消息
            }
            set
            {
                string inform = value ? "1" : "0";
                ApiFunction.WriteIniString("MESSAGE", "INFORM", Crypto.Instance().Cryp(inform), _CustomDirectory + "\\Server.ini");
            }
        }
        /// <summary>
        ///  是否有新消息
        /// </summary>
        public static bool NewMessage
        {
            get
            {
                string svalue = Crypto.Instance().UnCryp(ApiFunction.GetIniString("MESSAGE", "NEWMESSAGE", _CustomDirectory + "\\Server.ini"));
                if (Convertor.IsNumeric(svalue))
                    return svalue == "1" ? true : false;
                else
                    return true;		//默认接收消息
            }
            set
            {
                string newMessage = value ? "1" : "0";
                ApiFunction.WriteIniString("MESSAGE", "NEWMESSAGE", Crypto.Instance().Cryp(newMessage), _CustomDirectory + "\\Server.ini");
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="hostname">远程IP或机器名</param>
        /// <param name="port">远程机器端口</param>
        /// <param name="content">发送内容（主题）</param>
        /// <param name="sType">内容类型（消息、通知）</param>
        public static void SendMeg(string hostname, int port, string content, SendMessageType sType)
        {
            TcpClient tempTpc;
            try
            {
                tempTpc = new TcpClient(hostname, port);
            }
            catch (Exception le)
            {
                le.GetType();
                //				MessageBox.Show("连接被拒绝！\n"+le.Message,"提示：",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
                return;
            }
            try
            {
                //				DateTime NowTime=XcDate.ServerDateTime;
                string strDateLine = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();//得到发送时客户端时间 
                netStream = tempTpc.GetStream();//得到网络流 
                sw = new StreamWriter(netStream);//创建TextWriter,向流中写字符 
                string words = content;//待发送的内容 
                string contentStr = sType.ToString() + System.Environment.NewLine +
                                  strDateLine + " " + System.Environment.NewLine + words;//待发送内容

                sw.Write(contentStr);//写入流 
                sw.Close();//关闭流写入器 
                netStream.Close();//关闭网络流 
                tempTpc.Close();//关闭客户端连接 
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送消息失败!" + ex.Message, "提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void StartListen()
        {
            //			listenerRun=true; //连接标志 			
            try
            {
                serverListener = new TcpListener(temport);//创建TcpListener对象实例 
                serverListener.Start(); //启动侦听 
            }
            catch (Exception ex)
            {
                MessageBox.Show("不能启动侦听服务！" + ex.Message, "提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _CustomDirectory = TrasenFrame.Classes.Constant.CustomDirectory;

            timer.Enabled = true;//启动接收信息
            #region
            //			while(listenerRun)//进入无限循环等待用户端连接 	 
            //			{ 
            //				if(serverListener.Pending()==true)
            //				{
            //					try 	 
            //					{ 					
            //						tpc=serverListener.AcceptTcpClient();//侦听到连接后创建客户端连接对象 
            //						netStream=tpc.GetStream();//得到网络流 
            //						sr=new StreamReader(netStream);//流读写器
            //					} 	 
            //					catch(Exception re)	 
            //					{ 
            //						MessageBox.Show("接受连接失败！\n"+re.Message+"\n请重新”启动“系统。","提示：",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
            //						sr.Close(); 
            //						netStream.Close(); 
            //						tpc.Close();
            //						return;
            //					} 
            //					try
            //					{
            //						string sendType="";
            //						string received="";
            //						string receivedStr="";
            //						//读流中一行 
            //						if((sendType=sr.ReadLine())!=null)
            //						{
            //							while((received=sr.ReadLine())!=null) 	 
            //							{ 							
            //								receivedStr+=received;
            //							} 	
            //							if(receivedStr!="")//不是空消息
            //							{
            //								switch(sendType)
            //								{
            //									case "消息":
            //									{
            //										ApiFunction.WriteIniString("MESSAGE","NEWMESSAGE",Crypto.Instance().Cryp("1"),Constant.ApplicationDirectory+"\\Server.ini");
            //										upForm.IsUp=true;//是否弹出消息框
            //										break;
            //									}
            //									case "通知":
            //									{
            //										ApiFunction.WriteIniString("MESSAGE","INFORM",Crypto.Instance().Cryp("1"),Constant.ApplicationDirectory+"\\Server.ini");
            //										break;
            //									}
            //								}
            //								_ShowMessageForm=Constant.AcceptMessage;
            //								upForm.IsOpen=_ShowMessageForm;//是否显示闪烁图标
            ////			                   	upForm.IsUp=true;//是否弹出消息框
            //								upForm.title=receivedStr;//内容主题								
            //							}
            //						}
            //					}
            //					catch(Exception re)	 
            //					{ 
            //						MessageBox.Show("读取消息有错误！\n"+re.Message,"提示：",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
            //					}
            //					finally
            //					{
            //						//关闭 
            //						sr.Close(); 
            //						netStream.Close(); 
            //						tpc.Close(); 
            //					}
            //				}
            //			} 
            #endregion
        }

        #region 接收信息
        private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (serverListener.Pending() == true)
            {
                try
                {
                    tpc = serverListener.AcceptTcpClient();//侦听到连接后创建客户端连接对象 
                    netStream = tpc.GetStream();//得到网络流 
                    sr = new StreamReader(netStream);//流读写器
                }
                catch (Exception re)
                {
                    MessageBox.Show("接受连接失败！\n" + re.Message + "\n请重新”启动“系统。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sr.Close();
                    netStream.Close();
                    tpc.Close();
                    return;
                }
                try
                {
                    string sendType = "";
                    string received = "";
                    string receivedStr = "";
                    //读流中一行 
                    if ((sendType = sr.ReadLine()) != null)
                    {
                        while ((received = sr.ReadLine()) != null)
                        {
                            receivedStr += received;
                        }
                        if (receivedStr != "")//不是空消息
                        {
                            switch (sendType)
                            {
                                case "消息":
                                    {
                                        NewMessage = true;
                                        upForm.IsUp = true;//是否弹出消息框
                                        break;
                                    }
                                case "通知":
                                    {
                                        NewInFormation = true;
                                        break;
                                    }
                            }
                            _ShowMessageForm = AcceptMessage;
                            upForm.IsOpen = _ShowMessageForm;//是否显示闪烁图标
                            //			                   	upForm.IsUp=true;//是否弹出消息框
                            upForm.title = receivedStr;//内容主题								
                        }
                    }
                }
                catch (Exception re)
                {
                    MessageBox.Show("读取消息有错误！\n" + re.Message, "提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    //关闭 
                    sr.Close();
                    netStream.Close();
                    tpc.Close();
                }
            }

        }
        #endregion

        /// <summary>
        /// 侦听特定端口的用户请求
        /// </summary>
        /// <param name="port">/本地待侦听端口</param>		
        /// <param name="FormStr">弹出窗体的标题</param>
        /// <param name="deptID">科室ID</param>
        /// <param name="operate">操作员</param>
        /// <param name="mtype">消息类型（归属）</param>
        /// <param name="interval">弹出的间隔时间</param>
        /// <param name="formicon">闪烁的图标</param>
        public static void StartListen(int port, string FormStr, long deptID, long operate, int mtype, int interval, System.Drawing.Icon formicon)
        {
            temport = port;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = false;
            timer.Interval = 2000;
            ChangeIPInfo(1, deptID, operate, mtype);
            th = new Thread(new ThreadStart(StartListen));
            th.IsBackground = true;
            th.Start();
            DataTable myTb = upForm.selMessage(SendMessageType.通知, mtype, deptID);
            if (myTb.Rows.Count > 0)
            {
                FrmInform fi = new FrmInform("");
                fi.dt = myTb;
                fi.ShowDialog();
            }
            if (uf == null) showupform(FormStr, deptID, operate, mtype, interval, formicon);
            else
            {
                uf.groupBox1.Text = FormStr.Trim();
                uf.DeptID = deptID;
                uf.YS = operate;
                uf.mtype = mtype;
                uf.JGSJ = interval;
                if (formicon != null) uf.Icon = formicon;
            }

        }
        /// <summary>
        /// 停止侦听
        /// </summary>
        public static void StopListen()
        {
            try
            {
                listenerRun = false;
                timer.Enabled = false;
                if (th != null)
                {
                    //终止线程
                    th.Abort();
                    th.Join();
                    th = null;
                }
                if (serverListener != null) serverListener.Stop();
                if (tpc != null) tpc.Close();

                upForm.IsOpen = false;//不显示闪烁的图标
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        /// <summary>
        /// 检测是否可以向对方的某个端口发送消息
        /// </summary>
        /// <param name="hostname">远程IP或机器名</param>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public static bool IsListen(string hostname, int port)
        {
            TcpClient tempTpc = new TcpClient();
            try
            {
                tempTpc.ReceiveTimeout = 1000;
                tempTpc.Connect(hostname, port);
            }
            catch
            {
                return false;
            }
            tempTpc.Close();
            return true;

            //			IPHostEntry iphe = null;    
            //			try
            //			{
            //				iphe = Dns.Resolve(hostname);
            //				IPEndPoint ipe = new IPEndPoint(iphe.AddressList[0],port);
            //				Socket tmpS = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //				tmpS.Connect(ipe);
            //				if(tmpS.Connected)
            //				{
            //					return true;
            //				}
            //				else return false;
            //			}
            //			catch
            //			{
            //				return false;
            //			}

        }

        /// <summary>
        /// 获取指定IP的机器名
        /// </summary>
        /// <param name="IPStr">表示IP地址的字符串</param>
        /// <returns>机器名</returns>
        public static string GetIPHostName(string IPStr)
        {
            try
            {
                System.Net.IPHostEntry iphe = Dns.GetHostByAddress(IPStr);
                return iphe.HostName;
            }
            catch
            {
                return "<未知>";
            }
        }
        /// <summary>
        /// 获取指定IP的机器名
        /// </summary>
        /// <param name="address">一个System.Net.IPAddress</param>
        /// <returns>机器名</returns>
        public static string GetIPHostName(System.Net.IPAddress address)
        {
            try
            {
                System.Net.IPHostEntry iphe = Dns.GetHostByAddress(address.ToString());
                return iphe.HostName;
            }
            catch
            {
                return "<未知>";
            }
        }
        /// <summary>
        /// 获取与主机相关的IP地址列表
        /// </summary>
        /// <param name="Hostname">主机名</param>
        /// <returns></returns>
        public static IPAddress[] GetIPAddress(string Hostname)
        {
            try
            {
                System.Net.IPHostEntry iphe = Dns.GetHostByName(Hostname.Trim());
                return iphe.AddressList;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 显示upForm
        /// </summary>
        /// <param name="MessageStr">upForm的标题</param>
        /// <param name="deptID">科室ID</param>
        /// <param name="operate">操作员</param>
        /// <param name="type">消息类型（归属）</param>
        /// <param name="interval">弹出的间隔时间</param>
        /// <param name="formicon">闪烁的图标</param>
        /// <returns></returns>		
        private static void showupform(string MessageStr, long deptID, long operate, int type, int interval, System.Drawing.Icon formicon)
        {
            uf = new upForm();
            uf.groupBox1.Text = MessageStr.Trim();
            uf.DeptID = deptID;
            uf.YS = operate;
            uf.mtype = type;
            uf.JGSJ = interval;
            if (formicon != null) uf.Icon = formicon;
            uf.Show();
        }


        /// <summary>
        /// 改变主机使用系统模块的状态信息
        /// </summary>
        /// <param name="sign">1=系统模块被使用 2=停止使用系统模块 </param>
        /// <param name="deptID">登入科室</param>
        /// <param name="operate">登入者</param>
        /// <param name="mtype">系统模块ID</param>
        public static void ChangeIPInfo(int sign, long deptID, long operate, int mtype)
        {
            ParameterEx[] parameters = new ParameterEx[6];
            parameters[0].Text = "@SIGN";
            parameters[0].Value = (short)sign;
            parameters[1].Text = "@IP_ADDRESS";
            parameters[1].Value = upForm.AddressIP;
            parameters[2].Text = "@HOSTNAME";
            parameters[2].Value = Dns.GetHostName();
            parameters[3].Text = "@MTYPE";
            parameters[3].Value = (short)mtype;
            parameters[4].Text = "@DEPT_ID";
            parameters[4].Value = deptID;
            parameters[5].Text = "@USER_ID";
            parameters[5].Value = operate;
            try
            {
                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("SP_XX_CHANGEIPINFO", parameters, 30);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 改变主机使用系统模块的状态信息
        /// </summary>
        /// <param name="sign">1=系统模块被使用 2=停止使用系统模块 </param>
        /// <param name="ipAddress">主机IP地址</param>
        /// <param name="deptID">登入科室</param>
        /// <param name="operate">登入者</param>
        /// <param name="mtype">系统模块ID</param>
        public static void ChangeIPInfo(int sign, string ipAddress, long deptID, long operate, int mtype)
        {
            ParameterEx[] parameters = new ParameterEx[6];
            parameters[0].Text = "@SIGN";
            parameters[0].Value = (short)sign;
            parameters[1].Text = "@IP_ADDRESS";
            parameters[1].Value = ipAddress;
            parameters[2].Text = "@HOSTNAME";
            parameters[2].Value = Dns.GetHostName();
            parameters[3].Text = "@MTYPE";
            parameters[3].Value = (short)mtype;
            parameters[4].Text = "@DEPT_ID";
            parameters[4].Value = deptID;
            parameters[5].Text = "@USER_ID";
            parameters[5].Value = operate;
            try
            {
                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("SP_XX_CHANGEIPINFO", parameters, -1);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// 消息保存到数据库（主表）——保存消息信息
        /// </summary>
        /// <param name="BDATE">开始时间</param>
        /// <param name="EDATE">结束时间</param>
        /// <param name="TITLE">主题</param>
        /// <param name="CONTENT">内容</param>
        /// <param name="BOOK_USER">录入操作员</param>
        /// <param name="MTYPE">接收模块（0=所有模块 1=  2=  3=  （模块ID））</param>
        /// <param name="MEMO">备注</param>
        /// <param name="SDEPT_ID">源科室</param>
        /// <param name="LEVEL">级别（0普通，1系统）</param>
        /// <returns>记录行号</returns>
        public static long SaveMessageMain(DateTime BDATE, DateTime EDATE, string TITLE, string CONTENT, long BOOK_USER, short MTYPE, string MEMO, long SDEPT_ID, short LEVEL)
        {
            ParameterEx[] parameters = new ParameterEx[14];
            parameters[0].Value = 0;
            parameters[1].Value = BDATE;
            parameters[2].Value = EDATE;
            parameters[3].Value = TITLE;
            parameters[4].Value = CONTENT;
            parameters[5].Value = BOOK_USER;
            parameters[6].Value = MTYPE;
            parameters[7].Value = MEMO;
            parameters[8].Value = SDEPT_ID;
            parameters[9].Value = LEVEL;
            parameters[10].Value = 0;
            parameters[11].Value = 0;
            parameters[12].Value = "";

            parameters[0].Text = "@SIGN";
            parameters[1].Text = "@BDATE";
            parameters[2].Text = "@EDATE";
            parameters[3].Text = "@TITLE";
            parameters[4].Text = "@CONTENT";
            parameters[5].Text = "@BOOK_USER";
            parameters[6].Text = "@MTYPE";
            parameters[7].Text = "@MEMO";
            parameters[8].Text = "@SDEPT_ID";
            parameters[9].Text = "@LEVEL";
            parameters[10].Text = "@MAIN_ID";
            parameters[11].Text = "@DEPT_ID";
            parameters[12].Text = "@IP_ADDRESS";

            parameters[13].ParaDirection = ParameterDirection.Output;
            parameters[13].Text = "@TEMPID";
            parameters[13].Value = "";
            parameters[13].ParaSize = 18;

            try
            {
                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("SP_XX_SENDMESSAGE", parameters, -1);
                return Convert.ToInt64(parameters[13].Value);
            }
            catch (Exception err)
            {
                MessageBox.Show("消息保存失败！\n" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        /// <summary>
        /// 消息保存到数据库（从表）——保存接收消息的地址信息
        /// </summary>
        /// <param name="MainID">主表ID</param>
        /// <param name="DeptID">目标科室</param>
        /// <param name="IPAddress">IP地址</param>
        public static void SaveMessageSub(long MainID, long DeptID, string IPAddress)
        {
            ParameterEx[] parameters = new ParameterEx[14];
            parameters[0].Value = 1;
            parameters[1].Value = System.DateTime.Now;
            parameters[2].Value = System.DateTime.Now;
            parameters[3].Value = "";
            parameters[4].Value = "";
            parameters[5].Value = 0;
            parameters[6].Value = 0;
            parameters[7].Value = "";
            parameters[8].Value = 0;
            parameters[9].Value = 0;
            parameters[10].Value = MainID;
            parameters[11].Value = DeptID;
            parameters[12].Value = IPAddress;

            parameters[0].Text = "@SIGN";
            parameters[1].Text = "@BDATE";
            parameters[2].Text = "@EDATE";
            parameters[3].Text = "@TITLE";
            parameters[4].Text = "@CONTENT";
            parameters[5].Text = "@BOOK_USER";
            parameters[6].Text = "@MTYPE";
            parameters[7].Text = "@MEMO";
            parameters[8].Text = "@SDEPT_ID";
            parameters[9].Text = "@LEVEL";
            parameters[10].Text = "@MAIN_ID";
            parameters[11].Text = "@DEPT_ID";
            parameters[12].Text = "@IP_ADDRESS";

            parameters[13].ParaDirection = ParameterDirection.Output;
            parameters[13].Text = "@TEMPID";
            parameters[13].Value = "";
            parameters[13].ParaSize = 18;

            try
            {
                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("SP_XX_SENDMESSAGE", parameters, -1);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 系统模块间传递消息
        /// </summary>
        /// <param name="BDATE">开始时间</param>
        /// <param name="EDATE">结束时间</param>
        /// <param name="TITLE">主题</param>
        /// <param name="CONTENT">内容</param>
        /// <param name="LEVEL">消息级别（0=普通，1=系统）</param>
        /// <param name="MTYPE">接收模块（0=所有模块 1=  2=  3=  （模块ID））</param>
        /// <param name="BOOK_USER">录入操作员</param>
        /// <param name="SDEPT_ID">源科室</param>
        public static void PassMessage(DateTime BDATE, DateTime EDATE, string TITLE, string CONTENT, short LEVEL, short MTYPE, long BOOK_USER, long SDEPT_ID)
        {
            //先保存消息
            long MainID = SaveMessageMain(BDATE, EDATE, TITLE, CONTENT, BOOK_USER, MTYPE, "", SDEPT_ID, LEVEL);
            if (MainID != -1) SaveMessageSub(MainID, 0, "");
            else return;
            //获取接收模块所有正在使用的主机
            DataTable ipTb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("select * from mz_ipinformation where dtype=" + MTYPE.ToString() + " and use_flag=1");
            for (int i = 0; i < ipTb.Rows.Count; i++)
            {
                //发送
                SendMeg(ipTb.Rows[i]["ip_address"].ToString(), Convert.ToInt32(ipTb.Rows[i]["port"]), TITLE, SendMessageType.消息);
            }
        }
        /// <summary>
        /// 向使用某模块的科室发送消息
        /// </summary>
        /// <param name="BDATE">开始时间</param>
        /// <param name="EDATE">结束时间</param>
        /// <param name="TITLE">主题</param>
        /// <param name="CONTENT">内容</param>
        /// <param name="LEVEL">消息级别（0=普通，1=系统）</param>
        /// <param name="MTYPE">接收模块（0=所有模块 1=  2=  3=  （模块ID））</param>
        /// <param name="BOOK_USER">录入操作员</param>
        /// <param name="SDEPT_ID">源科室</param>
        /// <param name="DEPTID">目标科室</param>
        public static void PassMessage(DateTime BDATE, DateTime EDATE, string TITLE, string CONTENT, short LEVEL, short MTYPE, long BOOK_USER, long SDEPT_ID, long[] DEPTID)
        {
            //先保存消息
            long MainID = SaveMessageMain(BDATE, EDATE, TITLE, CONTENT, BOOK_USER, MTYPE, "", SDEPT_ID, LEVEL);
            string deptStr = "";
            if (MainID != -1)
            {
                string str = "";
                for (int i = 0; i < DEPTID.Length; i++)
                {
                    SaveMessageSub(MainID, DEPTID[i], "");
                    str = i > 0 ? ("," + DEPTID[i].ToString()) : DEPTID[i].ToString();
                    deptStr += str;
                }
            }
            else return;

            //获取接收模块所有正在使用的主机
            DataTable ipTb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("select * from mz_ipinformation where dtype=" + MTYPE.ToString() + " and d_dept_id in (" + deptStr + ") and use_flag=1");
            for (int i = 0; i < ipTb.Rows.Count; i++)
            {
                //发送
                SendMeg(ipTb.Rows[i]["ip_address"].ToString(), Convert.ToInt32(ipTb.Rows[i]["port"]), TITLE, SendMessageType.消息);
            }
        }

        /// <summary>
        /// 显示通知
        /// </summary>
        /// <param name="mType">通知的归属类型（0=所有模块，1=，2=，3= (模块ID)）</param>
        /// <param name="deptID">通知归属的科室ID</param>
        /// <param name="ysID">操作用户ID</param>
        public static void ShowInform(int mType, long deptID, long ysID)
        {
            FrmInform fi = new FrmInform(mType, deptID, ysID);
            fi.ShowDialog();
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="mType">消息的归属类型（0=所有模块 1=  2=  3= (模块ID)）</param>
        /// <param name="deptID">消息归属的科室ID</param>
        /// <param name="ysID">操作用户ID</param>
        public static void ShowMessage(int mType, long deptID, long ysID)
        {
            FrmMessage fm = new FrmMessage(mType, deptID, ysID);
            fm.ShowDialog();
        }
        /// <summary>
        /// 显示消息(属于本机的单前模块的消息)
        /// </summary>
        /// <param name="ysID">操作用户ID</param>
        public static void ShowMessage(long ysID)
        {
            FrmMessage fm = new FrmMessage(ysID);
            fm.ShowDialog();
        }

    }
}
