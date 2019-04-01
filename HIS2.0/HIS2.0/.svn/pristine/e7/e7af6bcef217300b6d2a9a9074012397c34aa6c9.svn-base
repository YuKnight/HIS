using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using ts_PrintProcess;

namespace ts_MzcfdySocket
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        delegate void ReceiveMessageDelegate(ClientUser user, out string receiveMessage);
        delegate void SendToClientDelegate(ClientUser user, string message);
        delegate void ListenClientDelegate(out TcpClient client);
         //<summary>
         //保存连接的所有用户
         //</summary>
        private List<ClientUser> userList = new List<ClientUser>();
        private TcpListener myListener;
        /// <summary>
        ///监听用户连接的线程与处理线程之间的同步管理
        /// </summary>
        //private static ManualResetEvent allDone = new ManualResetEvent(false);
        private void btnStart_Click(object sender, EventArgs e)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, int.Parse(Utility.ReadConfig("Port", "ts_MzcfdySocket.exe.config")));
            myListener = new TcpListener(4999);
            myListener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            myListener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
            myListener.Start();            
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

         //<summary>
         //接收客户端连接
         //</summary>
        private void ListenClientConnect()
        {
            TcpClient newClient = null;
            while (true)
            {
                //allDone.Reset();               
                Application.DoEvents();
                ListenClientDelegate d = new ListenClientDelegate(ListenClient);
                IAsyncResult result = d.BeginInvoke(out newClient, null, null);
                //使用轮询方式来判断异步操作是否完成
                if (result.IsCompleted == false)
                {
                    //获取Begin 方法的返回值和所有输入/输出参数
                    d.EndInvoke(out newClient, result);
                }
                //allDone.WaitOne();
                if (newClient != null)
                {
                    //RegisterSession(newClient.Client);
                    //每接受一个客户端连接，就创建一个对应的线程循环接收该客户端发来的信息
                    ClientUser user = new ClientUser(newClient);
                    user.ThreadReceive = new Thread(ReceiveData);
                    user.ThreadReceive.Start(user);
                }
                else
                {
                    break;
                }
            }
        }
       
         //<summary>
         //接受挂起的客户端连接请求
         //</summary>
         //<param name="newClient"></param>
        private void ListenClient(out TcpClient newClient)
        {
            try
            {
                newClient = myListener.AcceptTcpClient();            
            }
            catch
            {
                newClient = null;
            }
        }

        private void RegisterSession(Socket client)
        {
            try
            {
                if (ServerConfiguration.ReceiveTimeOut > 0)
                    client.ReceiveTimeout = ServerConfiguration.ReceiveTimeOut;
                if (ServerConfiguration.SendTimeOut > 0)
                    client.SendTimeout = ServerConfiguration.SendTimeOut;
                if (ServerConfiguration.ReceiveBufferSize > 0)
                    client.ReceiveBufferSize = ServerConfiguration.ReceiveBufferSize;
                if (ServerConfiguration.SendBufferSize > 0)
                    client.SendBufferSize = ServerConfiguration.SendBufferSize;
            }
            catch { }
        }

        public static Object objlock = new Object();
         //<summary>
         //处理接收的客户端信息
         //</summary>
         //<param name="userState">客户端信息</param>
        private void ReceiveData(object obj)
        {
            ClientUser user = (ClientUser)obj;
            TcpClient client = user.Client;
            while (user.IsNormalExit == false)
            {
                string receiveString = null;
                lock (objlock)
                {
                    AddUser(user);
                    ReceiveMessageDelegate d = new ReceiveMessageDelegate(ReceiveMessage);
                    IAsyncResult result = d.BeginInvoke(user, out receiveString, null, null);                   
                    if (!result.IsCompleted)
                    {                        
                        d.EndInvoke(out receiveString, result);
                    }
                }
            }
        }

        private void AddUser(ClientUser user)
        {
            if (userList != null && userList.Count > 0)
            {
                ClientUser retUser = userList.Find(delegate(ClientUser c) { return c.LoginGuid == user.LoginGuid; });
                if (retUser != null)
                {
                    userList.RemoveAll(delegate(ClientUser c) { return c.LoginGuid == retUser.LoginGuid; });
                }
            }
            userList.Add(user);
        }

        private void RemoveUser(ClientUser user)
        {
            if (user != null && userList.Count > 0)
            {
                user.IsNormalExit = true;
                user.Close();
                userList.Remove(user);
            }
        }

         //<summary>
         //异步发送message给user
         //</summary>
         //<param name="user"></param>
         //<param name="message"></param>
        private void AsyncSendToClient(ClientUser user, string message)
        {
            SendToClientDelegate d = new SendToClientDelegate(SendToClient);
            IAsyncResult result = d.BeginInvoke(user, message, null, null);
            while (result.IsCompleted == false)
            {
                d.EndInvoke(result);
            }
        }

         //<summary>
         //发送message给user
         //</summary>
         //<param name="user"></param>
         //<param name="message"></param>
        private void SendToClient(ClientUser user, string message)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                user.bw.Write(message);
                user.bw.Flush();
            }
            catch
            {
                //throw new Exception("回发消息出现异常");
            }
        }

         //<summary>
         //接收客户端发来的信息
         //</summary>
         //<param name="user"></param>
         //<param name="receiveMessage"></param>
        private void ReceiveMessage(ClientUser user, out string receiveMessage)
        {
            try
            {
                //allDone.Set();
                string[] splitString = null;
                byte[] buffer = new byte[1024];
                int byteCount = user.Client.Client.Receive(buffer);
                receiveMessage = Encoding.Default.GetString(buffer);
                if (string.IsNullOrEmpty(receiveMessage))
                {
                    if (!user.IsNormalExit)
                    {
                        RemoveUser(user);
                    }
                    return;
                }
                splitString = receiveMessage.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                if (splitString == null || splitString.Length == 0)
                {
                    receiveMessage = null;
                    return;
                }
                if (!string.IsNullOrEmpty(splitString[0]) && !string.IsNullOrEmpty(splitString[1]) && !string.IsNullOrEmpty(splitString[2]))
                {
                    if (this.IsDisposed == false)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            user.WindowNum = splitString[2];
                            ListViewItem lstViewItem = new ListViewItem();
                            lstViewItem.SubItems[0].Text = splitString[0];
                            lstViewItem.SubItems.Add(splitString[1]);
                            if (user.Client != null && user.Client.Client != null)
                                lstViewItem.SubItems.Add(user.Client.Client.RemoteEndPoint.ToString());
                            lstViewItem.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            ts_PrintProcess.PrescriptionPrint p = new ts_PrintProcess.PrescriptionPrint();
                            string resultMsg = string.Empty;
                            bool isPrint = false;
                            try
                            {
                                isPrint = p.Print(splitString[0], Convert.ToInt32(splitString[1]), out resultMsg);
                            }
                            catch
                            { }
                            lstViewItem.SubItems.Add(isPrint ? "成功" : "失败");
                            lstViewItem.SubItems.Add(resultMsg);
                            this.listView1.Items.Add(lstViewItem);
                            if (splitString.Length > 3 && !string.IsNullOrEmpty(splitString[3]) && isPrint)
                            {
                                string sql = string.Format("update mz_mzkf set isprint = 1 where id = '{0}'", splitString[3]);
                                PrescriptionPrint.DB.DoCommand(sql);
                            }
                            if (splitString.Length > 4 && !string.IsNullOrEmpty(splitString[4]))
                            {
                                string message = string.Format("正在打印{0}处方单", splitString[4]);
                                this.notifyIcon1.ShowBalloonTip(2000, "提示", message, System.Windows.Forms.ToolTipIcon.Info);
                            }
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                receiveMessage = null;
            }
        }

         //<summary>
         //读取消息
         //</summary>
         //<param name="stream"></param>
         //<returns></returns>
        private string ReadMessage(NetworkStream stream)
        {
            string result = "";
            int messageLength = 0;
            byte[] resultbyte = new byte[500 * 1024];
            //读取数据大小
            int index = 0;
            int count = GetSize(stream);
            byte[] data = new byte[count];
            while (index < count && (messageLength = stream.Read(data, 0, count - index)) != 0)
            {
                data.CopyTo(resultbyte, index);
                index += messageLength;
            }
            result = Encoding.UTF8.GetString(resultbyte, 0, index);
            return result;
        }

         //<summary>
         //获取要读取的数据的大小
         //</summary>
         //<param name="stream"></param>
         //<returns></returns>
        private int GetSize(NetworkStream stream)
        {
            int count = 0;
            byte[] countBytes = new byte[8];
            try
            {
                if (stream.Read(countBytes, 0, 8) == 8)
                {
                    count = BitConverter.ToInt32(countBytes, 0);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

            }
            return count;
        }

        private void btlLog_Click(object sender, EventArgs e)
        {
            string ErrPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, "ErrorLog");
            if (!Directory.Exists(ErrPath))
            {
                Directory.CreateDirectory(ErrPath);
            }
            string filePath = string.Format(@"{0}\{1}-ErrLog.txt", ErrPath, DateTime.Now.ToString("yyyy-MM-dd"));
            if (File.Exists(filePath))
                Process.Start(filePath);
            else
                MessageBox.Show("没有程序异常记录");
        }

        bool IsAutoRun = false;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            notifyIcon1.Visible = false;
            SetExeRegistry();
            btnStart_Click(null, null);
        }

        private void SetExeRegistry()
        {
            try
            {
                RegistryKey loca_chek = Registry.LocalMachine;
                RegistryKey run_Check = loca_chek.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                object autoRun = run_Check.GetValue("MzcfdySocket");
                if (autoRun == null || autoRun.ToString().ToLower() == "false")
                {
                    IsAutoRun = true;
                    btnAutoStart.Text = "开机启动服务";
                }
                else
                {
                    IsAutoRun = false;
                    btnAutoStart.Text = "取消开机启动";
                }
            }
            catch
            { }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                for (int i = userList.Count - 1; i >= 0; i--)
                {
                    //userList[i].IsNormalExit = true;
                    if (!string.IsNullOrEmpty(userList[i].WindowNum))
                        AsyncSendToClient(userList[i], string.Format("#Exit#{0}#", userList[i].WindowNum));
                    userList[i].Close();
                    userList.Remove(userList[i]);
                }
            }
            catch
            {
            }
            finally
            {
                //通过停止监听让 myListener.AcceptTcpClient() 产生异常退出监听线程
                if (myListener != null)
                    myListener.Stop();
                listView1.Items.Clear();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("您确认要退出门诊处方打印监听程序吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    for (int i = userList.Count - 1; i >= 0; i--)
                    {
                        //userList[i].IsNormalExit = true;
                        if (!string.IsNullOrEmpty(userList[i].WindowNum))
                            AsyncSendToClient(userList[i], string.Format("#Exit#{0}#", userList[i].WindowNum));
                        userList[i].Close();
                        userList.Remove(userList[i]);
                    }
                }
                catch
                { }
                finally
                {
                    //通过停止监听让 myListener.AcceptTcpClient() 产生异常退出监听线程
                    if (myListener != null)
                        myListener.Stop();
                    listView1.Items.Clear();
                    System.Environment.Exit(System.Environment.ExitCode);
                    this.Dispose();
                    this.Close();
                }
            }
        }

        private void btnAutoStart_Click(object sender, EventArgs e)
        {
            AutoRunExe are = new AutoRunExe();
            are.AutoRun(IsAutoRun);
        }

        private void btnTray_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("请确认是否最小化到系统托盘区？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Hide();
            this.ShowInTaskbar = false; 
            notifyIcon1.Visible = true;
        }

        private void 打开主程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            this.notifyIcon1.Visible = false;
        }

        private void 退出监听服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStop_Click(null, null);
        }

        private void btnCfdgl_Click(object sender, EventArgs e)
        {
            Control[] chrildControl = null;
            if (panel1.Controls.ContainsKey("Prescription"))
            {
                chrildControl = panel1.Controls.Find("Prescription", true);
                if (chrildControl != null && chrildControl.Length > 0)
                {
                    chrildControl[0].BringToFront();
                }
            }
            else
            {
                Prescription pre = new Prescription();
                chrildControl = new Control[] { pre };
                pre.Name = "Prescription";
                pre.Dock = DockStyle.Fill;
                panel1.Controls.Add(chrildControl[0]);
                chrildControl[0].BringToFront();
            }
        }

        private void btnSsdymx_Click(object sender, EventArgs e)
        {
            Control[] chrildControl = null;
            if (panel1.Controls.ContainsKey("listView1"))
            {
                chrildControl = panel1.Controls.Find("listView1", true);
                if (chrildControl != null && chrildControl.Length > 0)
                {
                    chrildControl[0].BringToFront();
                }
            }
        }
 
        
    }
}