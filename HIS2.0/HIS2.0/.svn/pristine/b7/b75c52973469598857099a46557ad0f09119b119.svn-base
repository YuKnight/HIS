using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenClasses.GeneralClasses;
using System.Reflection;

namespace TrasenFrame.Classes
{
    public class LISMessageReader : IMessageReader
    {
        private RelationalDatabase database;
        private User currentUser;
        private Department currentDept;
        private DataTable tbNewMessage;
        private string path;
        private List<MessageStruct> lstMessages;
        #region IMessageReader 成员
        /// <summary>
        /// 获取未读的消息
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            try
            {
                //读取当前科室的未读消息
                string sql = @"select *,dbo.fun_getempname(send_examiner) as sender 
                ,(select top 1 REG_NO from LS_AS_REPORT where REP_NO =LS_AS_READREPORT.REP_NO) as regno
                from LS_AS_READREPORT
                where flag = 0 and delete_bit=0 and dept_code=" + currentDept.DeptId + " order by bed_code,name";
                //是否只允许开单医生可以查看
                bool kdys = false;
                if ( kdys )
                    sql += " and SEND_EXAMINER = " + currentUser.EmployeeId;

                tbNewMessage = database.GetDataTable( sql );
                return tbNewMessage.Rows.Count == 0 ? false : true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        public void Show(MessageStruct message)
        {
            try
            {
                //调用LIS的DLL
                string dllName = "ts_lis_mzzyQuery.dll";
                string strNameSpace = "ts_lis_mzzyQuery";
                string className = "Frm_Query";
                string fullPath = path + "\\" + dllName;
                if ( System.IO.File.Exists( fullPath ) )
                {
                    Assembly assembly = Assembly.LoadFile( fullPath );

                    object objInstance = assembly.CreateInstance( strNameSpace + "." + "InstanceForm" );
                    objInstance.GetType().GetProperty( "CurrentUser" ).SetValue( objInstance , currentUser , null );
                    objInstance.GetType().GetProperty( "CurrentDept" ).SetValue( objInstance , currentDept , null );
                    objInstance.GetType().GetProperty( "Database" ).SetValue( objInstance , TrasenFrame.Forms.FrmMdiMain.Database , null ); //传框架连接

                    object[] args = new object[] { currentUser.EmployeeId , currentDept.DeptId , "报告查询" };
                    object objForm = assembly.CreateInstance( strNameSpace + "." + className , true , BindingFlags.CreateInstance , null , args , null , null );

                    if ( objForm != null )
                    {
                        Type type = objForm.GetType();
                        string funcationName = "GetRepNoInfo";
                        args = new object[] { message.KeyFieldValue, message.Reg_No };//-jianqg  2012-6-26 修改 增加参数Reg_No
                        object obj = type.InvokeMember( funcationName , BindingFlags.InvokeMethod , null , objForm , args );

                        //需要先执行GetRepNoInfo，再显示数据，--jianqg  2012-6-26 修改
                        type.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, objForm, null);

                        
                        //设置查看状态
                        string sql = "update LS_AS_READREPORT set flag=1, look_dr='" + currentUser.Name + "' where id=" + message.MsgId.ToString();
                        database.DoCommand( sql );
                    }
                }
            }
            catch ( Exception err )
            {
                //Console.WriteLine( err.Message );
                throw err;
            }
            
        }
        
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        public RelationalDatabase Database
        {
            get
            {
                return database;
            }
            set
            {
                database = value;
            }
        }
        /// <summary>
        /// 当前用户
        /// </summary>
        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }

        public string EnvironmentPath
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
        
        public List<MessageStruct> Messages
        {
            get
            {
                lstMessages = new List<MessageStruct>();
                if (tbNewMessage != null && tbNewMessage.Rows.Count != 0)
                {
                    foreach (DataRow dr in tbNewMessage.Rows)
                    {
                        string temp = "";
                        string note = dr["note"].ToString().Trim();
                        string sendDate = Convert.IsDBNull( dr["send_date"] ) ? "" : Convert.ToDateTime( dr["send_date"] ).ToString( "yyyy-MM-dd HH:mm" );
                        string rep_no = dr["REP_NO"].ToString().Trim();
                        string reg_no = dr["REGNO"].ToString().Trim();  // dr["REG_NO"].ToString().Trim(); 2012-6-28 jianqg 改 REGNO 是LS_AS_REPORT 表的REG_NO
                        string group_no = dr["GROUP_NO"].ToString().Trim();
                        string name = dr["name"].ToString().Trim();
                        string bedNo = Convertor.IsNull(dr["bed_code"], "");
                        string sender = dr["sender"].ToString().Trim();
                        int id = Convert.ToInt32( dr["id"]);

                        MessageStruct message = new MessageStruct();
                        message.KeyFieldValue = rep_no;
                        message.MsgId = id;
                        temp = note;
                        if (bedNo != "")
                            temp = temp + " " + bedNo + "床  ";
                        temp += name + "  " + group_no + " [时间：" + sendDate + "]";
                        message.Content = temp;
                        message.IsRead = false;
                        if (reg_no == null) reg_no = "";
                        message.Reg_No = reg_no;
                        lstMessages.Add(message);
                    }
                    
                }
                return lstMessages;
            }
        }

        public Department CurrentDept
        {
            get
            {
                return currentDept;
            }
            set
            {
                currentDept = value;
            }
        }

        #endregion
    }
}
