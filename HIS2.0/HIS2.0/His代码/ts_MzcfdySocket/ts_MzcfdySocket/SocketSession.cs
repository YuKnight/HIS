using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ts_MzcfdySocket
{
    public class SocketSession
    {
        /// <summary>
        /// 当接收到数据时触发。
        /// </summary>
        public event RecData OnRecData;
        /// <summary>
        /// SocketSession产生异常
        /// </summary>
        public event ThrowError OnError;
        private string clientIp;
        /// <summary>
        /// 工作Socket
        /// </summary>
        private Socket _ClientSocket = null;
        /// <summary>
        /// Socket每次接收的字节数
        /// </summary>
        public const int BufferSize = 2048;
        /// <summary>
        /// Soket 接收字节的数组
        /// </summary>
        public byte[] buffer = new byte[BufferSize];
        /// <summary>
        /// 最后活跃时间。
        /// </summary>
        public DateTime LastActively = DateTime.Now;
        /// <summary>
        /// 客户端的IP信息
        /// </summary>
        public string ClientIp
        {
            get { return clientIp; }
        }
        /// <summary>
        /// 接收到的数据
        /// </summary>
        public StringBuilder AcceptContent = new StringBuilder();
        /// <summary>
        /// 客户端Socket
        /// </summary>
        public Socket ClientSocket
        {
            get { return _ClientSocket; }
        }
        /// <summary>
        /// 每一个会话的唯一ID
        /// </summary>
        public string SessionID
        {
            get
            {
                return _sessionId;
            }
        }
        private string _sessionId;
        /// <summary>
        /// 客户端连接会话对象
        /// </summary>
        /// <param name=”clientSckt”></param>
        public SocketSession(Socket clientSckt)
        {
            this.LastActively = DateTime.Now;
            this._sessionId = Guid.NewGuid().ToString();
            if (clientSckt == null)
                throw new Exception("请指定客户端链接的Socket!");
            this._ClientSocket = clientSckt;
            this.clientIp = ClientSocket.RemoteEndPoint.ToString();
            RecData(clientSckt);
        }

        /// <summary>
        /// 开始接收每个线程中的数据
        /// </summary>
        /// <param name=”socketObj”>数据接收的socket</param>
        private void RecData(object socketObj)
        {
            Socket socketAccept = (Socket)socketObj;
            bool ret = socketAccept.Connected;
            try
            {              
                socketAccept.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReadCallback), socketAccept);
            }
            catch (System.Exception e)
            {
                OnError(e, this);
            }
        }

        /// <summary>
        /// 开始处理Socket中接收到的buffer,每次接受到数据都会调用数据处理委托
        /// </summary>
        /// <param name=”ar”></param>
        private void ReadCallback(IAsyncResult ar)
        {
            //修改最后激活时间
            this.LastActively = DateTime.Now;
            Socket sc = (Socket)ar.AsyncState;
            int bytesRead = 0;
            try
            {
                if (this.ClientSocket.Connected)
                    bytesRead = this.ClientSocket.EndReceive(ar);
            }
            catch (System.Exception e)
            {
                OnError(e, this);
            }

            if (bytesRead > 0)
            {
                string tmp = System.Text.Encoding.Default.GetString(buffer, 0, bytesRead);
                AcceptContent.Append(tmp);
                //处理接收到的数据。
                OnRecData(AcceptContent.ToString(), this);
                if (sc.Connected)
                {
                    ClientSocket.BeginReceive(buffer, 0, BufferSize, 0, new AsyncCallback(ReadCallback), sc);
                }
                else
                {
                    return;
                }
            }
            else
            {
                //重置收到的数据对象
                AcceptContent = new StringBuilder();
                return;
            }
        }

        /// <summary>
        /// 从指定的客户链接的Socket返回信息。（一般在接收到数据的处理委托中调用）
        /// </summary>
        /// <param name=”ReSend”>需要返回的信息</param>
        public void SendBackData(string ReSend)
        {
            try
            {
                byte[] byteData = System.Text.Encoding.ASCII.GetBytes(ReSend);
                this.ClientSocket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), this.ClientSocket);
            }
            catch (Exception ee)
            {
                OnError(ee, this);
            }
        }

        private void SendCallback(System.IAsyncResult ar)
        {
            try
            {
                Socket skBk = (Socket)ar.AsyncState;
                int bytesSent = skBk.EndSend(ar);
            }
            catch (System.Exception e)
            {
                OnError(e, this);
            }
        }

        /// <summary>
        /// 停止会话，将关闭ClientSocket
        /// </summary>
        public void StopSession()
        {
            try
            {
                this.ClientSocket.Shutdown(SocketShutdown.Both);
                this.ClientSocket.Close();
            }
            catch (System.Exception e)
            {
                OnError(e, this);
            }
        }

    }
}
