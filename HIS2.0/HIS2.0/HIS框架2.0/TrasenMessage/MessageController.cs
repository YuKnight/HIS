using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace TrasenMessage
{
   
    //即时消息控制器类
    public class MessageController
    {
        private readonly int portNum = 4667;
        private bool listen;///侦听标志
        //private TcpListener listener;
        private Socket socket;
        private EndPoint ep;
        private string path;  //声音文件路径
        private static Mutex muxConsole = new Mutex();
        private string s;
        private static IMessageProcessor msgProcess;

        public event ReceviedMessageHandler RecivedMessage;

        public MessageController()
        {
        }
        /// <summary>
        /// 开始监听
        /// </summary>
        public void StartListen()
        {
            listen = true;
            Thread threadls = new Thread(new ThreadStart(ThreadListener));
            threadls.IsBackground = true;
            threadls.Start();
        }
        public void StartListen(int port)
        {
            if ( TrasenFrame.Forms.FrmMdiMain.PortNum == 0 )
                TrasenFrame.Forms.FrmMdiMain.PortNum = port;
            listen = true;
            Thread threadls = new Thread( new ThreadStart( ThreadListener ) );
            threadls.IsBackground = true;
            threadls.Start();
        }
        /// <summary>
        /// 停止监听
        /// </summary>
        public void StopListen()
        {
            listen = false;
            socket.Close();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="host"></param>
        /// <param name="txt"></param>
        public void Send(string HostIP, IMessageProcessor MessageObject)
        {
            Send( HostIP , portNum , MessageObject );
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="host"></param>
        /// <param name="txt"></param>
        public void Send( string HostIP , int PortNum, IMessageProcessor MessageObject )
        {
            msgProcess = MessageObject;
            try
            {
                //只能用UDP协议发送广播，所以ProtocolType设置为UDP
                Socket socket = new Socket( AddressFamily.InterNetwork , SocketType.Dgram , ProtocolType.Udp );
                //让其自动提供子网中的IP地址
                IPEndPoint iep = new IPEndPoint( IPAddress.Parse( HostIP ) , PortNum );
                //设置broadcast值为1，允许套接字发送广播信息
                socket.SetSocketOption( SocketOptionLevel.Socket , SocketOptionName.Broadcast , 1 );
                //将发送内容转换为字节数组
                MemoryStream ms = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize( ms , msgProcess );
                byte[] bt = ms.GetBuffer();

                //向子网发送信息
                socket.SendTo( bt , iep );
                socket.Close();
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format( "消息已发送至{0}:{1}" , HostIP , PortNum ) } , true );
            }
            catch ( Exception err )
            {
                //throw err; 
                string[] sInfos = new string[4];
                sInfos[0] = err.Message;
                sInfos[1] = err.Source;
                sInfos[2] = err.StackTrace;
                sInfos[3] = err.TargetSite.Name;
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( sInfos , true );

            }
        }

        public void SendTo( string HostIP , string parameter , string Sender , int ShowtType , int ShowTime )
        {
            SendTo( HostIP , 0 , parameter , Sender , ShowtType , ShowTime );
        }

        public void SendTo( string HostIP , int PortNum, string parameter , string Sender , int ShowtType , int ShowTime )
        {
            MessageCommunication message = new MessageCommunication(Guid.Empty, parameter , Sender , ShowtType , ShowTime );
            IMessageProcessor im = (IMessageProcessor)message;
            if ( PortNum == 0 )
                Send( HostIP , im );
            else
                Send( HostIP , PortNum , im );
        }

        public void SendTo( string HostIP , int PortNum , TrasenFrame.Classes.MessageInfo msgInfo )
        {
            MessageCommunication message = new MessageCommunication( msgInfo.MessageId , msgInfo.Summary , msgInfo.SenderName , ( msgInfo.IsMustRead ? 1 : 0 ) , msgInfo.ShowTime );
            message.SendTime = DateTime.Now;
            message.Color = msgInfo.FontColor;
            IMessageProcessor im = (IMessageProcessor)message;

            if ( PortNum == 0 )
                Send( HostIP , im );
            else
                Send( HostIP , PortNum , im );
        }

        private void ThreadListener()
        {
            int _portNum = TrasenFrame.Forms.FrmMdiMain.PortNum; //取登录时获取到的端口号，如果没有则指定端口号来监听
            if ( _portNum == 0 )
                _portNum = portNum;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, _portNum);
                socket.Bind(iep);
                ep = (EndPoint)iep;
            }
            catch
            {
                return;
            }

            try
            {
                while (listen)
                {
                    if (!listen)
                    {
                        TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format( "终止监听端口{0}" , _portNum ) }, true );
                        break;
                    }
                    TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format( "正在监听端口{0}" , _portNum ) }, true );

                    byte[] bt = new byte[10240 * 2];
                    socket.ReceiveFrom(bt, ref ep);
                    object obj;
                    TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format( "端口{0}接收到数据,EndPoint:{1}" , _portNum , ep.AddressFamily.ToString() ) }, true );

                    try
                    {
                        //反序列化
                        using (MemoryStream ms = new MemoryStream(bt))
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            IFormatter formatter = new BinaryFormatter();

                            obj = formatter.Deserialize(ms);

                            ms.Close();
                        }
                        msgProcess = (IMessageProcessor)obj;
                       
                        if ( this.RecivedMessage != null )
                            this.RecivedMessage( msgProcess  );
                    }
                    catch(Exception error)
                    {
                        TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format("反序列化接收到的数据时发生错误：{0}",error.Message) }, true );
                        break;
                    }
                }
                socket.Close();
            }
            catch(Exception err)
            {
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format( "监听过程中发生错误：{0}" , err.Message ) }, true );
                StopListen();
            }

            //屏蔽，使用新的方式，UDP广播 Modify By Tany 2009-12-30
            #region Tcp端口监听
            //listener = new TcpListener(portNum);
            //try
            //{
            //    listener.Start();
            //}
            //catch
            //{
            //    return;
            //}
            //string s;
            //try
            //{
            //    while (listen)
            //    {
            //        TcpClient client = listener.AcceptTcpClient();

            //        if (!listen)
            //            break;
            //        NetworkStream ns = client.GetStream();
            //        byte[] bt = new byte[1024];
            //        int btlength = ns.Read(bt, 0, bt.Length);
            //        object obj;
            //        try
            //        {
            //            //反序列化
            //            using (MemoryStream ms = new MemoryStream(bt))
            //            {
            //                ms.Seek(0, SeekOrigin.Begin);
            //                IFormatter formatter = new BinaryFormatter();

            //                obj = formatter.Deserialize(ms);
            //            }
            //            msgProcess = (IMessageProcessor)obj;

            //            new Thread(new ThreadStart(msgProcess.Process)).Start();
            //            //可以在这里添加LED显示控制(一般LED厂家会提供相应的接口程序)

            //            ns.Close();
            //            client.Close();
            //        }
            //        catch
            //        {
            //            break;
            //        }
            //    }
            //}
            //catch//(Exception err)
            //{
            //    listener.Stop();
            //}
            #endregion
        }
    }
}
