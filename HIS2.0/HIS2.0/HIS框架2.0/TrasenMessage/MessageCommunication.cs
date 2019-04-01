using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace TrasenMessage
{
    /// <summary>
    /// 用户框架间互通及时消息类
    /// </summary>
    [Serializable]
    public class MessageCommunication : IMessageProcessor
    {
        private string messageString;
        private string sender;
        private int showtType;//消息弹出方式0=气泡1=窗体
        private int showTime;//消息显示时间
        private Guid messageId;
        private DateTime sendTime;

        private System.Drawing.Color color = System.Drawing.Color.Black;//默认是黑色
        /// <summary>
        /// 消息颜色
        /// </summary>
        public System.Drawing.Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public Guid MessageId
        {
            get
            {
                return messageId;
            }
            set
            {
                messageId = value;
            }
        }
        public int ShowType
        {
            get
            {
                return showtType;
            }
            set
            {
                showtType = value;
            }
        }
        public int ShowTime
        {
            get
            {
                return showTime;
            }
            set
            {
                showTime = value;
            }
        }
        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }
        public string MessageString
        {
            get
            {
                return messageString;
            }
            set
            {
                messageString = value;
            }
        }
        public DateTime SendTime
        {
            get
            {
                return sendTime;
            }
            set
            {
                sendTime = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public MessageCommunication()
        {
        }
        /// <summary>
        /// 用户框架间互通及时消息
        /// </summary>
        /// <param name="parameter">消息内容</param>
        /// <param name="Sender">发送者</param>
        /// <param name="ShowtType">消息弹出方式0=气泡1=窗体</param>
        public MessageCommunication( Guid msgId , string parameter , string Sender , int ShowtType , int ShowTime )
        {
            messageString = parameter;
            sender = Sender;
            showtType = ShowtType;
            showTime = ShowTime;
            messageId = msgId;
        }
        /// <summary>
        /// 用户框架间互通及时消息
        /// </summary>
        /// <param name="parameter">消息内容</param>
        /// <param name="Sender">发送者</param>
        /// <param name="ShowtType">消息弹出方式0=气泡1=窗体</param>
        public MessageCommunication( Guid msgId , string parameter , string Sender ,DateTime SendTime,System.Drawing.Color FontColor, int ShowtType , int ShowTime )
        {
            messageString = parameter;
            sender = Sender;
            showtType = ShowtType;
            showTime = ShowTime;
            messageId = msgId;
            sendTime = SendTime;
            color = FontColor;
        }

        

        void TrasenMessage.IMessageProcessor.Process()
        {
            /*
            该对象仅作消息内容的载体，自身不做任何操作，这里的方法屏蔽，相关处理移植到主界面FrmMdiMainWindow处理
             
            //Modify By Tany 2009-12-25 如果数据库连接关闭了，不论何种原因，都不再接收消息
            if (TrasenFrame.Forms.FrmMdiMain.Database == null
                || TrasenFrame.Forms.FrmMdiMain.Database.ConnectionStates != System.Data.ConnectionState.Open)
            {
                return;
            }

            //Modify By Tany 2009-12-24
            WriteMessage();
            showtType = 1;
            if (showtType == 0)
            {
                TrasenFrame.Forms.FrmMdiMain.newMsg = true;
                TrasenFrame.Forms.FrmMdiMain.msgSender = sender;
                TrasenFrame.Forms.FrmMdiMain.msgContents = messageString;
                TrasenFrame.Forms.FrmMdiMain.showTime = showTime;
                TrasenFrame.Forms.FrmMdiMain.showMsg = false;
            }
            else
            {                
                DlgImmediatelyMessage message = new DlgImmediatelyMessage(messageString, sender, showTime);
                message.TopMost = true;
                message.BringToFront();
                message.ShowDialog();//这里有问题，ShowDialog会使线程阻塞
                
            }
            */
        }

        public void WriteMessage()
        {

            //记录消息到本地 Add By Tany 2009-12-23
            DateTime date = DateTime.Now;
            string cd = Constant.CustomDirectory;

            string path = cd + "\\消息记录\\" + "MSG" + date.ToString("yyyyMMdd") + ".txt";

            if (!System.IO.Directory.Exists(cd + "\\消息记录"))
            {
                Directory.CreateDirectory(cd + "\\消息记录");
            }
            if (!File.Exists(path))//如果文件不存在 
            {
                File.Create(path).Close();
            }

            //新的消息写在前面，老的在后面
            StreamReader sr = new StreamReader(path);
            string oldStr = sr.ReadToEnd();
            sr.Close();

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("时  间：" + date.ToString());
            sw.WriteLine("发送者：" + sender);
            sw.WriteLine("内  容：" + messageString);
            sw.WriteLine("-------------------------------------------------");
            sw.WriteLine(oldStr);
            sw.Close();
        }

        public void WriteMessage(string cd)
        {

            //记录消息到本地 Add By Tany 2009-12-23
            DateTime date = DateTime.Now;
             

            string path = cd + "\\消息记录\\" + "MSG" + date.ToString( "yyyyMMdd" ) + ".txt";

            if ( !System.IO.Directory.Exists( cd + "\\消息记录" ) )
            {
                Directory.CreateDirectory( cd + "\\消息记录" );
            }
            if ( !File.Exists( path ) )//如果文件不存在 
            {
                File.Create( path ).Close();
            }

            //新的消息写在前面，老的在后面
            StreamReader sr = new StreamReader( path );
            string oldStr = sr.ReadToEnd();
            sr.Close();

            StreamWriter sw = new StreamWriter( path );
            sw.WriteLine( "时  间：" + date.ToString() );
            sw.WriteLine( "发送者：" + sender );
            sw.WriteLine( "内  容：" + messageString );
            sw.WriteLine( "-------------------------------------------------" );
            sw.WriteLine( oldStr );
            sw.Close();
        }

    }
}
