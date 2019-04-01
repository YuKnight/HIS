using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ts_MzcfdySocket
{
    public class ClientUser
    {
        public ClientUser(TcpClient client)
        {
            this._tcpClient = client;
            this._loginGuid = Guid.NewGuid().ToString();
            NetworkStream networkStream = client.GetStream();
            this._br = new BinaryReader(networkStream);
            this._bw = new BinaryWriter(networkStream);
        }

        private string _winNum;
        public string WindowNum
        {
            get
            {
                return _winNum;
            }
            set
            {
                _winNum = value;
            }
        }

        private string _loginGuid;
        public  string LoginGuid 
        {
            get
            {
                return _loginGuid;
            }
            set
            {
                _loginGuid = value;
            }
        }

        private TcpClient _tcpClient;
        public TcpClient Client
        {
            get
            {
                return _tcpClient;
            }
            set
            {
                _tcpClient = value;
            }
        }
        private BinaryReader _br;
        public BinaryReader br
        {
            get
            {
                return _br;
            }
            set
            {
                _br = value;
            }
        }
        private BinaryWriter _bw;
        public BinaryWriter bw
        {
            get
            {
                return _bw;
            }
            set
            {
                _bw = value;
            }
        }

        private bool _IsNormalExit;
        public bool IsNormalExit
        {
            get
            {
                return _IsNormalExit;
            }
            set
            {
                IsNormalExit = value;
            }
        }

        private Thread _td;
        public Thread ThreadReceive
        {
            get
            {
                return _td;
            }
            set
            {
                _td = value;
            }
        }

        public void Close()
        {            
            br.Close();
            bw.Close();
            if (Client != null)
            {
                if (Client.Client != null)
                    Client.Client.Shutdown(SocketShutdown.Both);
                Client.Close();
            }
            if (ThreadReceive != null && ThreadReceive.IsAlive)
            {
                ThreadReceive.Abort();
            }
        }     
    }
}
