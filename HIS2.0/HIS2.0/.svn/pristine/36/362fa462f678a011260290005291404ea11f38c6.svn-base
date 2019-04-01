using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ts_MzcfdySocket;

namespace ts_MzcfdySocket
{
    public class SocketServer
    {
        private Socket listener;
        private int _port = 4999;
        private int _MaxQueue = 10000;
        private bool _IsRuning = false;
        private double _sessionTimeOut = 3;
        private static ManualResetEvent allDone = new ManualResetEvent(false);//监听用户连接的线程与处理线程之间的同步管理
        private IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, 4999);
        private SocketSession[] sessionList;

        /// <summary>
        ///  使用指定的端口初始化Socket对象。
        /// </summary>
        /// <param name=”ListenPort”>指定端口</param>
        public SocketServer(int ListenPort)
        {
            if (ListenPort <= 0 || ListenPort > 65535)
            {
                OnError(new Exception("端口超出范围，重置端口为：4999"), this);
                _port = 4999;
            }
            else
                _port = ListenPort;
            _MaxQueue = 10000;
            ipLocal = new IPEndPoint(IPAddress.Any, _port);
        }
        /// <summary>
        /// 使用指定的端口，及最大链接数初始化Socket对象。
        /// </summary>
        /// <param name=”ListenPort”>需要监听的端口</param>
        /// <param name=”maxQueue”>最大链接数</param>
        public SocketServer(int ListenPort, int maxQueue)
        {
            if (ListenPort <= 0 || ListenPort > 65535)
            {
                OnError(new Exception("端口超出范围，重置端口为：4999"), this);
                _port = 4999;
            }
            else
            {
                _port = ListenPort;
            }
            _MaxQueue = maxQueue;
            ipLocal = new IPEndPoint(IPAddress.Any, _port);
        }

        /// <summary>
        /// 使用指定的端口，队列长度，需要监听的IP地址创建Scoket服务器。
        /// </summary>
        /// <param name=”ListenPort”>监听的端口</param>
        /// <param name=”maxQueue”>队列长度</param>
        /// <param name=”ipStr”>IP地址</param>
        public SocketServer(int ListenPort, int maxQueue, string ipStr)
        {
            if (ListenPort <= 0 || ListenPort > 65535)
            {
                OnError(new Exception("端口超出范围，重置端口为：4999"), this);
                _port = 4999;
            }
            else
                _port = ListenPort;
            _MaxQueue = maxQueue;
            ipLocal = new IPEndPoint(IPAddress.Parse(ipStr), _port);
        }

        /// <summary>
        /// 会话列表
        /// </summary>
        public SocketSession[] SessionList
        {
            get { return sessionList; }
        }

        /// <summary>
        /// 获取服务器是否运行
        /// </summary>
        public bool IsRuning
        {
            get { return _IsRuning; }
        }

        /// <summary>
        /// 获取或设置会话超时
        /// </summary>
        public double SessionTimeOut
        {
            get { return _sessionTimeOut; }
            set { _sessionTimeOut = value; }
        }

        /// <summary>
        /// 获取最大链接数
        /// </summary>
        public int MaxQueue
        {
            get { return _MaxQueue; }
        }

        /// <summary>
        /// 获取当前连接数
        /// </summary>
        public int CurrentClientCount
        {
            get
            {
                int n = 0;
                for (int i = 0; i < this.MaxQueue; i++)
                {
                    if (this.sessionList[i] != null)
                        n++;
                }
                return n;
            }
        }

        /// <summary>
        /// 获取监听端口。
        /// </summary>
        public int Port
        {
            get { return _port; }
        }

        /// <summary>
        /// 服务启动 Event
        /// </summary>
        public event TcpServerEvent OnServerStart;
        /// <summary>
        /// 服务停止 Event
        /// </summary>
        public event TcpServerEvent OnServerStop;
        /// <summary>
        /// 当产生异常时触发
        /// </summary>
        public event ThrowError OnError;
        /// <summary>
        /// 当会话创建时发生
        /// </summary>
        public event TcpServerEvent OnSessionCreated;
        /// <summary>
        /// 当会话关闭时发生
        /// </summary>
        public event TcpServerEvent OnSessionClosed;
        /// <summary>
        /// 当会话已达到最大上限时发生。
        /// </summary>
        public event TcpServerEvent OnSessionFull;

        /// <summary>
        ///  开启服务
        /// </summary>
        public void Start()
        {
            if (_IsRuning)
                return;
            _IsRuning = true;
            //连接上线列表
            sessionList = new SocketSession[_MaxQueue];
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(ipLocal);
                listener.Listen(_MaxQueue);
                ThreadPool.QueueUserWorkItem(new WaitCallback(BeginAcceptConn));
                StartSession();
                OnServerStart(this, "");
            }
            catch (Exception e)
            {
                OnError(e, this);
            }
        }

        private void BeginAcceptConn(object obj)
        {
            try
            {
                while (true)
                {
                    if (!this.IsRuning)
                        return;
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            }
            catch (System.Exception e)
            {
                OnError(e, this);
            }
        }
        /// <summary>
        /// 接收用户连接，开启新线程处理新的连接
        /// </summary>
        /// <param name=”ar”>新链接的socket对象</param>
        private void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();
            try
            {
                bool IsNeedWait = true;
                do
                {
                    if (!_IsRuning)
                        return;
                    //if (this.sessionList.Count < this._MaxQueue)
                    //{
                    //    Socket handler = listener.EndAccept(ar);
                    //    if (handler != null)
                    //    {
                    //        //获取客户端链接,创建会话。
                    //        SocketSession sckObj = new SocketSession(handler);
                    //        this.sessionList.Add(sckObj);
                    //        OnSessionCreated(sckObj, "");
                    //        IsNeedWait = false;
                    //    }
                    //}
                    #region
                    for (int i = 0; i < this._MaxQueue; i++)
                    {
                        if (!_IsRuning)
                            return;
                        //查找队列空余
                        if (this.sessionList[i] == null)
                        {
                            Socket handler = listener.EndAccept(ar);
                            //获取客户端链接,创建会话。
                            SocketSession sckObj = new SocketSession(handler);
                            this.sessionList[i] = sckObj;
                            OnSessionCreated(sckObj, "");
                            IsNeedWait = false;
                            break;
                        }
                    }
                    #endregion
                    if (IsNeedWait)//队列已满，排队等待。
                    {
                        OnSessionFull(this, "");
                        Thread.Sleep(600);
                    }
                  
                } 
                while(IsNeedWait);
            }
            catch (System.Exception e)
            {
                OnError(e, this);
            }
        }
        /// <summary>
        /// 停止服务。
        /// </summary>
        public void Stop()
        {
            if (!_IsRuning)
                return;
            _IsRuning = false;
            try
            {   //停止监听的socket
                this.listener.Close();
            }
            catch (System.Exception e)
            {
                OnError(e, this);
            }
            //停止所有的会话连接及线程。
            for (int i = 0; i < this.sessionList.Length; i++)
            {
                SocketSession session = this.sessionList[i];
                StopSession(ref session);
            }
            OnServerStop(this, "");
        }

        private void StartSession()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(SessionFor));
        }

        private void SessionFor(object obj)
        {
            do
            {
                for (int i = 0; i < this.sessionList.Length; i++)
                {
                    if (sessionList[i] != null)
                    {
                        //清除超时的
                        DateTime outT = sessionList[i].LastActively.AddSeconds(this.SessionTimeOut);
                        int n = DateTime.Now.CompareTo(outT);
                        if (n > 0)//超时
                        {
                            if (OnSessionClosed != null)
                                OnSessionClosed(sessionList[i], "");
                            SocketSession session = this.sessionList[i];
                            StopSession(ref session);
                        }
                        //清除连接已关闭的。
                        if (sessionList[i] != null && !sessionList[i].ClientSocket.Connected)
                        {
                            if (OnSessionClosed != null)
                                OnSessionClosed(sessionList[i], "");
                            SocketSession session = this.sessionList[i];
                            StopSession(ref session);
                        }
                    }
                }
                Thread.Sleep(400); //session过期时间单位为秒，停顿400毫秒遍历一次Session
            } while (true);
        }

        /// <summary>
        /// 停止某个会话。
        /// </summary>
        /// <param name=”scs”></param>
        private void StopSession(ref SocketSession scs)
        {
            if (scs != null)
                scs.StopSession();
            scs = null;
        }
    }
}
 

 


