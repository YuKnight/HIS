using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TrasenFrame.Classes;

namespace TrasenMessageDetector
{
    internal class HideOnStartupApplicationContext : ApplicationContext
    {
        private int _systemId;
        private int _deptId;
        private int _employeeId;
        private IntPtr _MW_Handle;
        private int _mainProcessId;
        private static object _objLock = new object();
        private TrasenMessage.DlgImmediatelyMessage dlgMsg;
        private System.Timers.Timer timerExit;
        private TrasenMessage.MessageController messageControler;
        public HideOnStartupApplicationContext( Form mainForm , int systemId , int deptId , int employeeId , IntPtr MW_Handle , int port ,int mainProcessId)
        {
            _systemId = systemId;
            _deptId = deptId;
            _employeeId = employeeId;
            _MW_Handle = MW_Handle;
            _mainProcessId = mainProcessId;

            mainForm.Closed += delegate( object sender , EventArgs e )
            {
                Application.Exit();
            };

            messageControler = new TrasenMessage.MessageController();
            messageControler.RecivedMessage += new TrasenMessage.ReceviedMessageHandler( messageControler_RecivedMessage );
            messageControler.StartListen( port );

            DisplayUnDealMessage( systemId , deptId , employeeId );

            timerExit = new System.Timers.Timer( 1000 );
            timerExit.Elapsed += new System.Timers.ElapsedEventHandler( timerExit_Elapsed );
            timerExit.Start();
        }

        private void timerExit_Elapsed( object sender , System.Timers.ElapsedEventArgs e )
        {
            //定时监测所属的主窗体被关闭了            
            System.Diagnostics.Process process = null;
            try
            {
                process = System.Diagnostics.Process.GetProcessById( _mainProcessId );                
            }
            catch ( Exception error )
            {
                timerExit.Stop();
                messageControler.StopListen();
                Application.Exit();
            }
        }
        /// <summary>
        /// 显示未处理的消息
        /// </summary>
        private void DisplayUnDealMessage( int systemId , int deptId , int employeeId )
        {
            TrasenClasses.DatabaseAccess.RelationalDatabase database = new TrasenClasses.DatabaseAccess.MsSqlServer();
            database.Initialize( TrasenFrame.Classes.WorkStaticFun.GetConnnectionString_Default( TrasenFrame.Classes.ConnectionType.SQLSERVER ) );

            List<TrasenFrame.Classes.MessageInfo> undealMessages = TrasenFrame.Classes.MessageInfo.GetUnDealMessageList( systemId , deptId , employeeId , database );
            if ( undealMessages.Count > 0 )
            {
                foreach ( TrasenFrame.Classes.MessageInfo msg in undealMessages )
                {
                    TrasenMessage.MessageCommunication message = new TrasenMessage.MessageCommunication( msg.MessageId , msg.Summary , msg.SenderName , msg.IsMustRead ? 1 : 0 , msg.ShowTime );
                    message.SendTime = msg.SendTime;
                    message.Color = msg.FontColor;
                    ShowReciveMessage( message );
                }
            }
        }
        /// <summary>
        /// 用于接收到消息后的事件处理
        /// </summary>
        /// <param name="message"></param>
        private void messageControler_RecivedMessage( TrasenMessage.IMessageProcessor message )
        {
            //接收到消息后，异步委托调用消息显示
            ShowRecivedMessageHandler handler = new ShowRecivedMessageHandler( ShowReciveMessage );
            handler.BeginInvoke( message , new AsyncCallback( ReciveMessageCallback ) , "" );
        }
        /// <summary>
        /// 显示即时消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="MsgParamter"></param>
        private void ShowReciveMessage( TrasenMessage.IMessageProcessor IMessage )
        {
            TrasenMessage.MessageCommunication msg = (TrasenMessage.MessageCommunication)IMessage;
            lock ( _objLock )
            {
                msg.WriteMessage(Application.StartupPath);

                if ( msg.ShowType == 0 )
                {
                    ////如果是气泡方式显示。对变量赋值后，由定时器去处理消息（待改进)
                    //this.newMsg = true;
                    //this.msgSender = msg.Sender;
                    //this.msgContents = msg.MessageString;
                    //this.showTime = msg.ShowTime;
                    //this.showMsg = false;

                    //向主窗口发消息
                    SendMessageToMainForm( msg );
                }
                else
                {
                    lock ( _objLock )
                    {
                        //this.Invoke( new ShowMessageFormHandler( showMessagePopForm ) , msg );
                        showMessagePopForm( msg );
                    }
                }
            }
        }
        /// <summary>
        /// 异步委托的回调函数
        /// </summary>
        /// <param name="result"></param>
        private void ReciveMessageCallback( IAsyncResult result )
        {
            ShowRecivedMessageHandler hander = (ShowRecivedMessageHandler)( (System.Runtime.Remoting.Messaging.AsyncResult)result ).AsyncDelegate;
            hander.EndInvoke( result );
        }
        /// <summary>
        /// 显示接收到的消息的委托
        /// </summary>
        /// <param name="message"></param>
        /// <param name="MsgParamter"></param>
        private delegate void ShowRecivedMessageHandler( TrasenMessage.IMessageProcessor message );        
        /// <summary>
        /// 显示消息弹出窗口
        /// </summary>
        /// <param name="message"></param>
        private void showMessagePopForm( TrasenMessage.MessageCommunication message )
        {
            if ( dlgMsg == null )
            {
                dlgMsg = new TrasenMessage.DlgImmediatelyMessage();
                dlgMsg.MessageContentClicked += new TrasenMessage.OnMessageContentClickedHander( dlgMsg_MessageContentClicked );
                dlgMsg.SetCheckedMessageStatus += new TrasenMessage.OnSetCheckedMessageStautsHandler( dlgMsg_SetCheckedMessageStatus );
                dlgMsg.TopMost = true;
            }
            dlgMsg.Show();
            dlgMsg.BringToFront();
            while ( !dlgMsg.IsHandleCreated )
            {
                //空循环，防止窗口句柄还未创建就执行Invoke方法
            }
            dlgMsg.AddMessage( message );
        }
        /// <summary>
        /// 点击消息弹出窗上的消息事件
        /// </summary>
        /// <param name="MessageId"></param>
        private void dlgMsg_MessageContentClicked( Guid MessageId , TrasenMessage.Action action , ref bool cancel )
        {

            try
            {
                TrasenClasses.DatabaseAccess.RelationalDatabase database = new TrasenClasses.DatabaseAccess.MsSqlServer();
                database.Initialize( TrasenFrame.Classes.WorkStaticFun.GetConnnectionString_Default( TrasenFrame.Classes.ConnectionType.SQLSERVER ) );

                if ( action == TrasenMessage.Action.ViewDetail )
                {
                    TrasenFrame.Classes.MessageInfo msgInfo = new TrasenFrame.Classes.MessageInfo( MessageId , database );
                    //调用Read方法，记录阅读人
                    msgInfo.SetStatus( true , _employeeId ,
                        System.Net.Dns.GetHostByName( System.Net.Dns.GetHostName() ).AddressList[0].ToString() );

                    //向主窗口发消息进行消息处理，需要处理消息内容的操作,
                    SendMessageToMainForm( MessageId );
                }
                else
                {
                    //DialogResult result = (DialogResult)this.Invoke( new OnShowMessageBoxHandler( ShowMessageBox ) , true );
                    DialogResult result = ShowMessageBox( true );
                    if ( result == DialogResult.No )
                    {
                        cancel = true;
                        return;
                    }
                    if ( MessageId != Guid.Empty )
                    {
                        //标记为已读的操作
                        TrasenFrame.Classes.MessageInfo msgInfo = new TrasenFrame.Classes.MessageInfo( MessageId , database );
                        //调用Read方法，记录阅读人
                        msgInfo.SetStatus( false , _employeeId ,
                            System.Net.Dns.GetHostByName( System.Net.Dns.GetHostName() ).AddressList[0].ToString() );
                    }
                }
            }
            catch ( Exception error )
            {
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">目标窗口的handle</param>
        /// <param name="Msg">消息</param>
        /// <param name="wParam">第一个消息参数</param>
        /// <param name="lParam"><第二个消息参数/param>
        /// <returns></returns>
        [DllImport( "User32.dll" , EntryPoint = "SendMessage" )]
        private static extern int SendMessage( int hWnd , int Msg , int wParam , ref COPYDATASTRUCT lParam );

        [DllImport( "User32.dll" , EntryPoint = "FindWindow" )]
        private static extern int FindWindow( string lpClassName , string lpWindowName );
        
        const int WM_COPYDATA = 0x004A;
        /// <summary>
        /// 向主窗口发送消息
        /// </summary>
        /// <param name="content"></param>
        private void SendMessageToMainForm( object content )
        {
            string msgString = "";
            if ( content.GetType() == typeof( Guid ) )
            {
                msgString = "0$" + ( new Guid( content.ToString() ) ).ToString();
            }
            else
            {
                TrasenMessage.MessageCommunication msg = (TrasenMessage.MessageCommunication)content;
                msgString = string.Format( "1${0},{1},{2}" , msg.Sender , msg.MessageString , msg.ShowTime );
            }

            byte[] sarr = System.Text.Encoding.Default.GetBytes( msgString );
            int len = sarr.Length;
            COPYDATASTRUCT cds;
            cds.dwData = (IntPtr)100;
            cds.lpData = msgString;
            cds.cbData = len + 1;
            SendMessage( _MW_Handle.ToInt32() , WM_COPYDATA , 0 , ref cds );
        }
        /// <summary>
        /// 点击全部标记为已读的事件处理
        /// </summary>
        /// <param name="lstMessageId"></param>
        /// <param name="action"></param>
        /// <param name="cancel"></param>
        private void dlgMsg_SetCheckedMessageStatus( List<Guid> lstMessageId , TrasenMessage.Action action , ref bool cancel )
        {
             
            DialogResult result = ShowMessageBox( false );
            if ( result == DialogResult.No )
            {
                cancel = true;
                return;
            }

            try
            {
                TrasenClasses.DatabaseAccess.RelationalDatabase database = new TrasenClasses.DatabaseAccess.MsSqlServer();
                database.Initialize( TrasenFrame.Classes.WorkStaticFun.GetConnnectionString_Default( TrasenFrame.Classes.ConnectionType.SQLSERVER ) );

                foreach ( Guid MessageId in lstMessageId )
                {
                    //标记为已读的操作
                    TrasenFrame.Classes.MessageInfo msgInfo = new TrasenFrame.Classes.MessageInfo( MessageId , database );
                    //调用Read方法，记录阅读人
                    msgInfo.SetStatus( false , this._employeeId ,
                        System.Net.Dns.GetHostByName( System.Net.Dns.GetHostName() ).AddressList[0].ToString() );
                }
            }
            catch ( Exception error )
            {
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
            }
        }
        /// <summary>
        /// 消息处理询问
        /// </summary>
        /// <param name="IsSingleMessage"></param>
        /// <returns></returns>
        private DialogResult ShowMessageBox( bool IsSingleMessage )
        {
            string questionString = "是否忽略该消息？";
            if ( !IsSingleMessage )
                questionString = "是否忽略选中的消息？";

            DialogResult result = MessageBox.Show( questionString , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question );

            return result;
        }


    }
}
