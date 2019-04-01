using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes
{
    //消息结构体
    public class MessageInfo
    {

        private Guid messageId = Guid.Empty;
        private string summary = "";
        private int senderId = 0;
        private string senderName = "";
        private string ipAddr = "";
        private DateTime sendTime;
        private Color fontColor = Color.Black;
        private bool isMustRead = false;
        private int showTime = 3;
        private SystemModule? reciveSystem = null;
        private int reciveDeptId = 0;
        private string reciveWardId = "";
        private int reciveStaffer = 0;
        private string assemblyDLL = "";
        private string assemblyFuncationName = "";
        private string assemblyFormText = "";
        private string assemblyTag = "";
        private string assemblyInvokeMethod = "";
        private string assemblyParameter = "";
        private int dealStatus = 0;
        private int readerId = 0;
        private DateTime? readTime = null;
        private string readbyIP = "";


        /// <summary>
        /// 消息ID(只读)
        /// </summary>
        public Guid MessageId
        {
            get
            {
                return messageId;
            }
        }
        /// <summary>
        /// 消息摘要,用于显示的字符串，建议不宜太长
        /// </summary>
        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                summary = value;
            }
        }
        /// <summary>
        /// 发送人ID(只读)
        /// </summary>
        public int SenderId
        {
            get
            {
                return senderId;
            }
        }
        /// <summary>
        /// 发送人姓名
        /// </summary>
        public string SenderName
        {
            get
            {
                return senderName;
            }
        }
        /// <summary>
        /// 发送消息时的机器IP(只读)
        /// </summary>
        public string IpAddr
        {
            get
            {
                return ipAddr;
            }
        }
        /// <summary>
        /// 发送时间(只读)
        /// </summary>
        public DateTime SendTime
        {
            get
            {
                return sendTime;
            }
        }
        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color FontColor
        {
            get
            {
                return fontColor;
            }
            set
            {
                fontColor = value;
            }
        }
        /// <summary>
        /// 是否必须读取该消息，如果为True，则以窗口方式显示，否则以气泡方式显示
        /// </summary>
        public bool IsMustRead
        {
            get
            {
                return isMustRead;
            }
            set
            {
                isMustRead = value;
            }
        }
        /// <summary>
        /// 消息显示时间，仅作用于气泡方式显示的消息，对弹窗显示的消息无效
        /// </summary>        
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
        /// <summary>
        /// 接收消息的子模块系统
        /// </summary>       
        public SystemModule? ReciveSystem
        {
            get
            {
                return reciveSystem;
            }
            set
            {
                reciveSystem = value;
            }
        }
        /// <summary>
        /// 能接收消息的科室ID
        /// </summary>        
        public int ReciveDeptId
        {
            get
            {
                return reciveDeptId;
            }
            set
            {
                reciveDeptId = value;
            }
        }
        /// <summary>
        /// 能接收消息的病区ID
        /// </summary>        
        public string ReciveWardId
        {
            get
            {
                return reciveWardId;
            }
            set
            {
                reciveWardId = value;
            }
        }
        /// <summary>
        /// 能接收消息的操作员
        /// </summary>        
        public int ReciveStaffer
        {
            get
            {
                return reciveStaffer;
            }
            set
            {
                reciveStaffer = value;
            }
        }
        /// <summary>
        /// 显示消息详细内容所需的DLL名称,不包含文件的后缀名
        /// </summary>        
        public string AssemblyDLL
        {
            get
            {
                return assemblyDLL;
            }
            set
            {
                assemblyDLL = value;
            }
        }
        /// <summary>
        /// 显示消息详细内容所需的类库名称，该类库需要实现TrasenFrame.Classes.IInnerCommunicate接口
        /// </summary>        
        public string AssemblyFuncationName
        {
            get
            {
                return assemblyFuncationName;
            }
            set
            {
                assemblyFuncationName = value;
            }
        }
        /// <summary>
        /// 程序集窗体名称
        /// </summary>
        public string AssemblyFormText
        {
            get
            {
                return assemblyFormText;
            }
            set
            {
                assemblyFormText = value;
            }
        }
        /// <summary>
        /// 程序集附带的Tag值
        /// </summary>
        public string AssemblyTag
        {
            get
            {
                return assemblyTag;
            }
            set
            {
                assemblyTag = value;
            }
        }
        /// <summary>
        /// 指定的调用方法
        /// </summary>
        [Obsolete("不再使用")]
        public string AssemblyInvokeMethod
        {
            get
            {
                return assemblyInvokeMethod;
            }
            set
            {
                assemblyInvokeMethod = value;
            }
        }
        /// <summary>
        /// 调用的程序集所需的内部参数，消息显示机制不会对该部分进行修改，只传递到调用的程序集中
        /// </summary>
        public string AssemblyParameter
        {
            get
            {
                return assemblyParameter;
            }
            set
            {
                assemblyParameter = value;
            }
        }
        /// <summary>
        /// 读取消息时的使用的机器IP(只读)
        /// </summary>
        public string ReadbyIP
        {
            get
            {
                return readbyIP;
            }
        }
        /// <summary>
        /// 消息阅读时间(只读)
        /// </summary>
        public DateTime? ReadTime
        {
            get
            {
                return readTime;
            }
        }
        /// <summary>
        /// 第一个读取消息的操作员ID(只读)
        /// </summary>
        public int ReaderId
        {
            get
            {
                return readerId;
            }
        }
        /// <summary>
        /// 是否已读(只读)
        /// </summary>
        public int DealStatus
        {
            get
            {
                return dealStatus;
            }
        }
        /// <summary>
        /// 根据当前用户、机器IP，时间构造一个空的消息对象
        /// </summary>
        public MessageInfo()
        {
            this.senderId = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
            this.senderName = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;

            System.Net.IPHostEntry ipe = System.Net.Dns.GetHostEntry( System.Net.Dns.GetHostName() );
            this.ipAddr = "127.0.0.1";
            foreach ( System.Net.IPAddress ip in ipe.AddressList )
            {
                if ( ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
                {
                    this.ipAddr = ip.ToString();
                    break;
                }
            }
            this.sendTime = TrasenClasses.GeneralClasses.DateManager.ServerDateTimeByDBType( TrasenFrame.Forms.FrmMdiMain.Database );
        }
        /// <summary>
        /// 根据ID构造消息对象
        /// </summary>
        /// <param name="MsgId"></param>
        /// <param name="database"></param>
        public MessageInfo( Guid MsgId , RelationalDatabase database )
        {
            string sql = string.Format( "select *,dbo.fun_getempname(SendStaff) as SendStaffName from Pub_Message_Record Where MsgId = '{0}'" , MsgId.ToString() );
            DataRow row = database.GetDataRow( sql );
            if ( row == null )
                return;

            SetMessagePropertyValue( row );
        }

        private MessageInfo( DataRow row )
        {
            SetMessagePropertyValue( row );
        }

        private void SetMessagePropertyValue( DataRow row )
        {
            messageId = new Guid( row["MsgId"].ToString() );
            summary = Convertor.IsNull( row["Summary"] , "" );
            senderId = Convert.ToInt32( Convertor.IsNull( row["SendStaff"] , "0" ) );
            senderName = Convertor.IsNull( row["SendStaffName"] , "" );
            ipAddr = Convertor.IsNull( row["SendByIP"] , "" );
            sendTime = Convert.ToDateTime( row["SendTime"] );
            fontColor = Color.FromName( Convertor.IsNull( row["FontColor"] , "" ) == "" ? Color.Black.Name : row["FontColor"].ToString() );
            isMustRead = Convert.ToInt32( row["ShowType"] ) == 0 ? false : true; //0-气泡，不是必读消息
            showTime = Convert.ToInt32( row["ShowTime"] );  //消息显示时间，仅对气泡弹出有效
            if ( Convert.ToInt32( row["ReciveSystem"] ) == 0 )
                reciveSystem = null;
            else
                reciveSystem = (SystemModule)Convert.ToInt32( row["ReciveSystem"] );
            reciveDeptId = Convert.ToInt32( row["ReciveDept"] );
            reciveWardId = Convertor.IsNull( row["ReciveWard"] , "" );
            reciveStaffer = Convert.ToInt32( row["ReciveStaff"] );
            assemblyDLL = Convertor.IsNull( row["DllName"] , "" );
            assemblyFuncationName = Convertor.IsNull( row["FuncationName"] , "" );
            assemblyFormText = Convertor.IsNull( row["FormText"] , "" );
            assemblyTag = Convertor.IsNull( row["FuncationTag"] , "" );
            assemblyInvokeMethod = Convertor.IsNull( row["InvokMethod"] , "" );
            assemblyParameter = Convertor.IsNull( row["Parameter"] , "" );
            dealStatus = Convert.ToInt32( row["DealStatus"] );
            readerId = Convert.ToInt32( row["FirstReader"] );
            if ( Convert.IsDBNull( row["ReadTime"] ) )
                readTime = null;
            else
                readTime = Convert.ToDateTime( row["ReadTime"] );
            readbyIP = Convertor.IsNull( row["ReadByIP"] , "" );
        }
        
        /// <summary>
        /// 保存消息，在调用发送方法后调用
        /// </summary>
        /// <param name="database"></param>
        public void Save( RelationalDatabase database )
        {
            Guid tempId = Guid.NewGuid();
            string sql = @"insert into Pub_Message_Record( MsgId,Summary,SendTime,SendStaff,SendByIP,FontColor,ShowType,ShowTime,
                                    ReciveSystem,ReciveStaff,ReciveDept,ReciveWard,DealStatus,FirstReader,	ReadTime,ReadByIP,DllName,FuncationName,FormText,FuncationTag,InvokMethod,Parameter)
                            values (@MsgId,@Summary,getdate(),@SendStaff,@SendByIP,@FontColor,@ShowType,@ShowTime,
                                    @ReciveSystem,@ReciveStaff,@ReciveDept,@ReciveWard,@DealStatus,@FirstReader,@ReadTime,@ReadByIP,@DllName,@FuncationName,@FormText,@FuncationTag,@InvokMethod,@Parameter)";
            using ( IDbCommand cmd = database.GetCommand() )
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add( NewParameter( "@MsgId" , tempId ) );
                cmd.Parameters.Add( NewParameter( "@Summary" , this.summary ) );
                cmd.Parameters.Add( NewParameter( "@SendStaff" , this.senderId ) );
                cmd.Parameters.Add( NewParameter( "@SendByIP" , this.ipAddr ) );
                cmd.Parameters.Add( NewParameter( "@FontColor" , this.fontColor.Name ) );
                cmd.Parameters.Add( NewParameter( "@ShowType" , ( this.isMustRead ? 1 : 0 ) ) );
                cmd.Parameters.Add( NewParameter( "@ShowTime" , this.showTime ) );
                cmd.Parameters.Add( NewParameter( "@ReciveSystem" , ( this.reciveSystem == null ? 0 : (int)this.reciveSystem.Value ) ) );
                cmd.Parameters.Add( NewParameter( "@ReciveStaff" , this.reciveStaffer ) );
                cmd.Parameters.Add( NewParameter( "@ReciveDept" , this.reciveDeptId ) );
                cmd.Parameters.Add( NewParameter( "@ReciveWard" , this.reciveWardId ) );
                cmd.Parameters.Add( NewParameter( "@DealStatus" , 0 ) );
                cmd.Parameters.Add( NewParameter( "@FirstReader" , 0 ) );
                cmd.Parameters.Add( NewParameter( "@ReadTime" , DBNull.Value ) );
                cmd.Parameters.Add( NewParameter( "@ReadByIP" , "" ) );
                cmd.Parameters.Add( NewParameter( "@DllName" , this.assemblyDLL ) );
                cmd.Parameters.Add( NewParameter( "@FuncationName" , this.assemblyFuncationName ) );
                cmd.Parameters.Add( NewParameter( "@FormText" , this.assemblyFormText ) );
                cmd.Parameters.Add( NewParameter( "@FuncationTag" , this.assemblyTag ) );
                cmd.Parameters.Add( NewParameter( "@InvokMethod" , this.assemblyInvokeMethod ) );
                cmd.Parameters.Add( NewParameter( "@Parameter" , this.assemblyParameter ) );

                int ret = cmd.ExecuteNonQuery();
                if ( ret == 1 )
                    this.messageId = tempId;
                else
                    throw new System.Data.DataException( sql );
            }
        }

        private IDataParameter NewParameter( string name , object _value )
        {
            System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter( name , _value );
            return parameter;
        }
        /// <summary>
        /// 设置消息状态
        /// </summary>
        /// <param name="IsDeal"></param>
        /// <param name="EmployeeId"></param>
        /// <param name="IpAddress"></param>
        public void SetStatus( bool IsDeal , int EmployeeId , string IpAddress )
        {
            //0，未处理，1、仅标记为已读，2、已做处理
            string sql = "update pub_message_record set DealStatus = {0},FirstReader={1},ReadTime=getdate(),ReadByIP = '{2}'  where MsgId = '{3}'";
            sql += " and FirstReader=0 and ReadTime is null and ReadByIP=''";
            if ( IsDeal )
                sql = string.Format( sql , 2 , EmployeeId , IpAddress , this.messageId.ToString() );
            else
                sql = string.Format( sql , 1 , EmployeeId , IpAddress , this.messageId.ToString() );
            try
            {
                RelationalDatabase database = new TrasenClasses.DatabaseAccess.MsSqlServer();
                database.Initialize( TrasenFrame.Classes.WorkStaticFun.GetConnnectionString_Default( TrasenFrame.Classes.ConnectionType.SQLSERVER ) );
                database.Open();
                database.DoCommand( sql );
                database.Close();
            }
            catch ( Exception error )
            {
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { "更改消息状态失败！" , error.Message ,error.StackTrace }, true );
            }
        }
        /// <summary>
        /// 获取未处理的消息列表
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public static List<MessageInfo> GetUnDealMessageList( RelationalDatabase database )
        {
            ////发给自己的消息
            //string str1 = string.Format( "select * from Pub_Message_Record Where DealStatus=0 and ReciveStaff = {0} and ( (ReciveSystem>0 and ReciveSystem = {1}) or (ReciveWard<>'' and ReciveWard = (select ward_id from JC_WARD where dept_id = {2})) or (ReciveDept> 0 and ReciveDept = {2}))" ,
            //    TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId , TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId , TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId );

            ////发给自己所在病区或科室的消息
            //string str2 = string.Format( "select * from Pub_Message_Record Where DealStatus=0 and ReciveStaff = 0 and ( (ReciveWard<>'' and ReciveWard = (select ward_id from JC_WARD where dept_id = {0})) or (ReciveDept> 0 and ReciveDept = {0} ))" , TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId );
            ////发给自己当前登录的系统的消息
            //string str3 = string.Format( "select * from Pub_Message_Record where DealStatus=0 and ReciveStaff = 0 and ( ReciveSystem> 0 and ReciveSystem In (select Module_id from pub_system where System_Id ={0} )  )" , TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId );

            //StringBuilder sb = new StringBuilder();
            //sb.Append( "select *,dbo.fun_getempname(SendStaff) as SendStaffName from ( " );
            //sb.Append( str1 );
            //sb.Append( " union " );
            //sb.Append( str2 );
            //sb.Append( " union " );
            //sb.Append( str3 );
            //sb.Append( " ) A " );
            //sb.Append( " order by SendTime" );
            //DataTable tbMsg = database.GetDataTable( sb.ToString() );

            return GetUnDealMessageList( TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId , TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId ,
                TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId , database );
        }

        /// <summary>
        /// 获取未处理的消息列表
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public static List<MessageInfo> GetUnDealMessageList(int CurrentSystemId,int CurrentDeptId,int CurrentEmployeeId, RelationalDatabase database )
        {
            string strEmpty = "select *,dbo.fun_getempname(SendStaff) as SendStaffName from Pub_Message_Record where 1=2";
            DataTable tbMsg = database.GetDataTable( strEmpty );//取空的消息表结构
            tbMsg.PrimaryKey = new DataColumn[] { tbMsg.Columns["MsgId"] };

            #region 发给自己的消息
            string str1 = string.Format( "select *,dbo.fun_getempname(SendStaff) as SendStaffName from Pub_Message_Record Where DealStatus=0 and ReciveStaff = {0}" , CurrentEmployeeId );
            DataTable tbPersonMsg = database.GetDataTable( str1 );

            foreach ( DataRow row in tbPersonMsg.Rows )
            {
                Guid msgId = new Guid( row["MsgId"].ToString() );
                if ( tbMsg.Rows.Find( msgId ) != null )
                    continue;

                int reciveSystem = Convert.ToInt32( row["ReciveSystem"] );
                int reciveDept = Convert.ToInt32( row["ReciveDept"] );
                //发送人指定了接收人要在指定的系统和指定的科室接收
                if ( reciveSystem > 0 && reciveDept > 0 )
                {
                    if ( reciveSystem == CurrentSystemId && reciveDept == CurrentDeptId )
                    {
                        tbMsg.Rows.Add( row.ItemArray );
                    }
                }
                else
                {
                    //仅指定接收人要在指定的系统接收
                    if ( reciveSystem > 0 )
                    {
                        if ( reciveSystem == CurrentSystemId )
                        {
                            tbMsg.Rows.Add( row.ItemArray );
                        }
                    }
                    else
                    {
                        //仅指定接收人要在指定的科室接收
                        if ( reciveDept > 0 )
                        {
                            if ( reciveDept == CurrentDeptId )
                            {
                                tbMsg.Rows.Add( row.ItemArray );
                            }
                        }
                        else
                        {
                            tbMsg.Rows.Add( row.ItemArray );
                        }
                    }
                }
            }
            #endregion

            #region 发给自己所在病区或科室的消息
            string str2 = string.Format( "select * from Pub_Message_Record Where DealStatus=0 and ReciveStaff = 0 and ( (ReciveWard<>'' and ReciveWard = (select ward_id from JC_WARD where dept_id = {0})) or (ReciveDept> 0 and ReciveDept = {0} ))" , CurrentDeptId );
            DataTable tbWardmsg = database.GetDataTable( str2 );
            foreach ( DataRow row in tbWardmsg.Rows )
            {
                Guid msgId = new Guid( row["MsgId"].ToString() );
                if ( tbMsg.Rows.Find( msgId ) != null )
                    continue;
                else
                    tbMsg.Rows.Add( row.ItemArray );
            }
            #endregion

            #region 发给自己当前登录的系统的消息
            string str3 = string.Format( "select * from Pub_Message_Record where DealStatus=0 and ReciveStaff = 0 and ( ReciveSystem> 0 and ReciveSystem In (select Module_id from pub_system where System_Id ={0} )  )" , CurrentSystemId );
            DataTable tbSystemMsg = database.GetDataTable( str2 );
            foreach ( DataRow row in tbSystemMsg.Rows )
            {
                Guid msgId = new Guid( row["MsgId"].ToString() );
                if ( tbMsg.Rows.Find( msgId ) != null )
                    continue;
                else
                    tbMsg.Rows.Add( row.ItemArray );
            }
            #endregion

            List<MessageInfo> messages = new List<MessageInfo>();
            foreach ( DataRow row in tbMsg.Rows )
            {
                MessageInfo msg = new MessageInfo( row );
                messages.Add( msg );
            }
            return messages;
        }
    }
}
