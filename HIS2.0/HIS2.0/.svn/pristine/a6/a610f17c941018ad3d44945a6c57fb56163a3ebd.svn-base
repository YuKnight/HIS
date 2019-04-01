using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace ts_PrintProcess
{
    /// <summary>
    /// 操作员类
    /// </summary>
    public class User : Employee
    {
        private long _userID;
        private string _loginCode;
        private string _password;
        private bool _locked;
        private bool _isAdministrator;
        /// <summary>
        /// jianqg 2012-10月 emr-his框架整合 增加 是否带实习生
        /// </summary>
        private bool _IsHouseman;
        /// <summary>
        /// jianqg 2012-10月 emr-his框架整合 增加 公有密码
        /// </summary>
        private string _PublicPwd;
        /// <summary>
        /// jianqg 2012-10月 emr-his框架整合 增加 使用公用密码登陆
        /// </summary>
        private bool _loginUsePublicPwd;
        private string _certificateCA;
        #region 属性
        /// <summary>
        /// CA证书
        /// </summary>
        public string CertificateCA
        {
            get
            {
                return _certificateCA;
            }
            set
            {
                _certificateCA = value;
            }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }
        /// <summary>
        /// 用户的登录代码
        /// </summary>
        public string LoginCode
        {
            get
            {
                return _loginCode;
            }
            set
            {
                _loginCode = value;
            }
        }
        /// <summary>
        /// 返回密码的属性（得到密码的明文）
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
        }
        /// <summary>
        /// 表示该用户是否被锁定
        /// </summary>
        public bool Locked
        {
            get
            {
                return _locked;
            }
            set
            {
                _locked = value;
            }
        }
        /// <summary>
        /// 是否为超级用户
        /// </summary>
        public bool IsAdministrator
        {
            get
            {
                return _isAdministrator;
            }
        }
        /// <summary>
        /// 是否带实习医生 jianqg 2012-10月 emr-his框架整合 增加
        /// </summary>
        public bool IsHouseman
        {
            get
            {
                return _IsHouseman;
            }
        }
        /// <summary>
        ///得到公共密码，该密码专为实习医生使用 jianqg 2012-10月 emr-his框架整合 增加
        /// </summary>
        public string PulicPassword
        {
            get
            {
                return _PublicPwd;
            }
        }
        /// <summary>
        ///使用公用密码登陆 jianqg 2012-10月 emr-his框架整合 增加
        /// </summary>
        public bool LoginUsePublicPwd
        {
            get
            {
                return _loginUsePublicPwd;
            }
        }
        #endregion
        /// <summary>
        /// 构造一空员工对象
        /// </summary>
        public User()
        {
            _userID = -1;
            _loginCode = "";
            _password = "";
            _locked = false;
            _isAdministrator = false;
            // jianqg 2012-10月 emr-his框架整合 增加
            _IsHouseman = false;
            _PublicPwd = "";
            _loginUsePublicPwd = false;
        }
        #region //jianqg 不需要 特注释 2012-10月emr-his框架整合

        /// <summary>
        /// 构造一操作员对象
        /// </summary>
        /// <param name="userID">操作员ID</param>
        /// <param name="database">数据库访问对象</param>
        public User(int userID, RelationalDatabase database)
            : this()
        {
            this.Database = database;
            //GetUserInfo(userID);
            //jianqg 2012-10月 emr-his框架整合 启用过程up_GetUserInfo
            GetUserInfo("", userID.ToString());
        }
        /// <summary>
        /// 构造一操作员对象
        /// </summary>
        /// <param name="userID">操作员ID</param>
        /// <param name="database">数据库访问对象</param>
        public User(long userID, RelationalDatabase database)
            : this()
        {
            this.Database = database;
            //GetUserInfo(userID);
            //jianqg 2012-10月 emr-his框架整合 启用过程up_GetUserInfo
            GetUserInfo("", userID.ToString());
        }

        #endregion
        /// <summary>
        /// 构造一操作员对象
        /// </summary>
        /// <param name="loginCode">操作员登录名</param>
        /// <param name="database">数据库访问对象</param>
        public User(string loginCode, RelationalDatabase database)
            : this()
        {
            this.Database = database;
            //将原 处理用户信息的部分 独立成为过程
            GetUserInfo(loginCode, "0");

        }
        /// <summary>
        ///jianqg 2012-10月 emr-his框架整合 增加 参数userId
        /// </summary>
        /// <param name="loginCode"></param>
        /// <param name="userId"></param>
        private void GetUserInfo(string loginCode, string userId)
        {
            try
            {
                IDbCommand cmd = this.Database.GetCommand();
                //jianqg 2012-10月 emr-his框架整合 启用过程up_GetUserInfo，可以用UserCode，UserID，原来使用up_GetUserInfobyCode，只用UserCode
                cmd.CommandText = "up_GetUserInfo";// "up_GetUserInfobyCode"; 
                cmd.CommandType = CommandType.StoredProcedure;
                ParameterEx[] paras = new ParameterEx[2];
                paras[0].Text = "@UserCode";
                loginCode = Convertor.IsNull(loginCode, "");
                paras[0].Value = loginCode.ToUpper();
                paras[1].Text = "@UserID";
                userId = Convertor.IsNumeric(userId) ? userId : "0";

                paras[1].Value = userId;

                this.Database.SetParameters(cmd, paras);
                DataRow dataRow = this.Database.GetDataRow(cmd);

                if (dataRow != null)
                {
                    _userID = Convert.ToInt32(Convertor.IsNull(dataRow["userid"], "-1"));
                    _loginCode = Convertor.IsNull(dataRow["code"], "");
                    _password = Crypto.Instance().Decrypto(Convertor.IsNull(dataRow["password"], ""));
                    _locked = Convert.ToInt16(Convertor.IsNull(dataRow["locked_bit"], "0")) > 0 ? true : false;
                    _isAdministrator = Convert.ToInt16(Convertor.IsNull(dataRow["administrator_bit"], "0")) > 0 ? true : false;
                    //jianqg 2012-10月 emr-his框架整合 增加
                    _IsHouseman = dataRow["H_id"].ToString().Length > 0 ? true : false;
                    _PublicPwd = Crypto.Instance().Decrypto(Convertor.IsNull(dataRow["public_pwd"], ""));
                    base.InitEmployee(Convert.ToInt32(Convertor.IsNull(dataRow["employee_id"], "-1")));
                }
                else
                {
                    throw new Exception("用户编码为" + loginCode.ToString() + "的用户不存在");
                }
                //获取对应的CA证书
                //try
                //{
                //    string sql = string.Format( "select Certificate from Pub_User_CA_Certificate where Employee_Id={0}" , EmployeeId );
                //    object obj = this.Database.GetDataResult( sql );
                //    _certificateCA = Convertor.IsNull( obj , "" );
                //}
                //catch
                //{
                //    _certificateCA = "";
                //}
            }
            catch (Exception err)
            {
                throw new Exception("User\\" + err.Message);
            }
        }

        #region //jianqg 不需要 特注释 2012-10月emr-his框架整合
        /*
        /// <summary>
        /// 获得操作员信息
        /// </summary>
        /// <param name="userID">操作员ID</param>
        protected void GetUserInfo(long userID)
        {
            try
            {
                IDbCommand cmd = this.Database.GetCommand();
                cmd.CommandText = "up_GetUserInfobyUID";
                cmd.CommandType = CommandType.StoredProcedure;
                ParameterEx[] paras = new ParameterEx[1];
                paras[0].Text = "@UID";
                paras[0].Value = userID;
                this.Database.SetParameters(cmd, paras);
                DataRow dataRow = this.Database.GetDataRow(cmd);

                if (dataRow != null)
                {
                    _userID = userID;
                    _loginCode = Convertor.IsNull(dataRow["code"], "");
                    _password = Crypto.Instance().Decrypto(Convertor.IsNull(dataRow["password"], ""));
                    _locked = Convert.ToInt16(Convertor.IsNull(dataRow["locked_bit"], "0")) > 0 ? true : false;
                    _isAdministrator = Convert.ToInt16(Convertor.IsNull(dataRow["administrator_bit"], "0")) > 0 ? true : false;
                    base.InitEmployee(Convert.ToInt32(Convertor.IsNull(dataRow["employee_id"], "-1")));
                }
                else
                {
                    throw new Exception("用户ID为" + userID.ToString() + "的用户不存在");
                }
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetUserInfo\\" + err.Message);
            }
        }
         */
        #endregion
        /// <summary>
        /// 核对密码是否相符合
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool CheckPassword(string pwd)
        {
            //return _password == pwd;
            //jianqg 2012-10月 emr-his框架整合 修改 
            //增加公用密码的处理，带实习生的情况，优先匹配 公用密码

            _loginUsePublicPwd = false;
            if (_IsHouseman)
            {
                if (_PublicPwd == pwd)
                {
                    _loginUsePublicPwd = true;
                    return true;
                }
            }
            if (_password == pwd)
            {
                return true;
            }
            return false;
        }

        public bool CheckPassword(string pwd, bool IsCA)
        {
            if (!IsCA)
            {
                return CheckPassword(pwd);
            }
            else
            {
                try
                {
                    string ca_user_id = "";//txtName.Text;
                    string ca_password = pwd;
                    //使用CA验证密码
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\ts_ca_Interface.dll");
                    object obj = assembly.CreateInstance("ts_ca_Interface.CAFactory");
                    System.Reflection.MethodInfo mi = obj.GetType().GetMethod("CreateCA");
                    object objInstance = mi.Invoke(obj, null);
                    if (objInstance != null)
                    {
                        mi = objInstance.GetType().GetInterface("ts_ca_Interface.InterfaceCA").GetMethod("VerifyLogin", new Type[]{
                                typeof( string ) , typeof( string ) , typeof( string ).MakeByRefType() });
                        try
                        {
                            string message = "";
                            object[] paramters = new object[] { ca_user_id, ca_password, message };
                            object objRet = mi.Invoke(objInstance, paramters);
                            if (Convert.ToBoolean(objRet) == false)
                            {
                                message = paramters[2].ToString();
                                MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        catch (Exception error)
                        {
                            throw error;
                        }
                    }
                    return false;
                }
                catch (Exception error)
                {
                    throw error;
                }
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="ComputerName"></param>
        /// <param name="IPAddr"></param>
        /// <param name="MacAddr"></param>
        /// <param name="PortNum"></param>
        public void Login(string ComputerName, string IPAddr, string MacAddr, int PortNum)
        {
            string sql = "update pub_user set login_bit=1,login_time=getdate(),login_ip='{0}',login_mac='{1}',login_pcname='{2}',login_port={3} where id={4}";
            sql = string.Format(sql, IPAddr, MacAddr, ComputerName, PortNum, this._userID);
            this.Database.DoCommand(sql);
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        public void Loginout()
        {
            string sql = @"update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null ,login_port = 0
                            where id={0} ";
            sql = string.Format(sql, this.UserID);
            int ret = this.Database.DoCommand(sql);
        }
        /// <summary>
        /// 清除用户在线状态
        /// </summary>
        /// <param name="database"></param>
        public static int ClearOnlineStatus(long UserId, int EmployeeId, string LoginCode, RelationalDatabase database)
        {
            string sql = @"update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null,login_port = 0 where 1=1";
            if (UserId != 0)
                sql += " and id=" + UserId.ToString();
            if (EmployeeId != 0)
                sql += " and employee_id=" + EmployeeId.ToString();
            if (!string.IsNullOrEmpty(LoginCode))
                sql += " and code = '" + LoginCode + "'";

            int ret = database.DoCommand(sql);
            return ret;
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="oldPWD">原来密码</param>
        /// <param name="newPWD">新密码</param>
        public bool ChangePassword(string oldPWD, string newPWD)
        {
            //if (oldPWD != _password)
            //{
            //    throw new Exception("User\\ChangePassword\\原始密码输入错误！");
            //}

            ////定义多院操作日志 Modify By Tany 2010-01-21
            //ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            //Guid log_djid = Guid.Empty;

            //this.Database.BeginTransaction();
            //try
            //{
            //    string sql = "update pub_user set password='" + Crypto.Instance().Encrypto(newPWD) + "' where id=" + _userID;
            //    if (this.Database.DoCommand(sql) <= 0)
            //    {
            //        throw new Exception("密码修改失败！");
            //    }

            //    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-21
            //    string cznr = "修改用户密码:【" + _loginCode + "】";
            //    ts.Save_log(ts_HospData_Share.czlx.jc_用户修改, cznr, "pub_user", "id", _userID.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, -999, "", out log_djid, this.Database);

            //    this.Database.CommitTransaction();
            //}
            //catch (Exception err)
            //{
            //    this.Database.RollbackTransaction();
            //    throw new Exception("User\\ChangePassword\\" + err.Message);
            //}

            //try
            //{
            //    //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-21
            //    string errtext = "";
            //    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_用户修改, this.Database);
            //    if (ty.Bzx == 1 && log_djid != Guid.Empty)
            //    {
            //        //立即执行该操作 Modify By Tany 2010-01-21
            //        ts.Pexec_log(log_djid, this.Database, out errtext);
            //    }
            //    if (errtext != "")
            //    {
            //        throw new Exception(errtext);
            //    }
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //this.Retrieve();
            //return true;
            return true;
        }
        /// <summary>
        /// 获取用户可以使用的系统
        /// </summary>
        /// <returns></returns>
        public DataTable GetSystemInfo()
        {
            try
            {
                ParameterEx[] paras = new ParameterEx[3];
                paras[0].Text = "@UserCode";
                paras[0].Value = this._loginCode;
                paras[1].Text = "@UserID";
                paras[1].Value = this._userID;
                paras[2].Text = "@AdminFlag";
                if (_isAdministrator)		//如果是系统管理员则可以操作全部系统
                {
                    paras[2].Value = 1;
                }
                else
                {
                    paras[2].Value = 0;
                }
                IDbCommand cmd = this.Database.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_GetSystemOfUser";
                this.Database.SetParameters(cmd, paras);
                return this.Database.GetDataTable(cmd);
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetSystemInfo\\" + err.Message);
            }
        }
        /// <summary>
        /// 获取用户可以使用的模块
        /// </summary>
        /// <returns></returns>
        public DataTable GetModuleInfo()
        {
            try
            {
                string sql = "";
                if (_isAdministrator)		//如果是系统管理员则可以操作全部模块
                {
                    sql = "select id as module_id,name as module_name,module_image,system_id from pub_module where delete_bit=0 order by sort_id";
                }
                else
                {
                    sql = @"select a.id as module_id,a.name as module_name,a.module_image,a.system_id
							from pub_module as a
							inner join 
							(select distinct module_id
								from pub_module_menu as b
								inner join pub_group_access as c
								on b.id=c.module_menu_id
								inner join pub_group_user as d
								on c.group_id=d.group_id
								where d.user_id=" + _userID + @" and b.delete_bit=0 and c.delete_bit=0 and d.delete_bit=0
							) as f
							on a.id=f.module_id
							where a.delete_bit=0
							order by a.sort_id";
                }
                return this.Database.GetDataTable(sql);
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetModuleInfo\\" + err.Message);
            }
        }
        /// <summary>
        /// 获取用户的菜单使用权限
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserRight()
        {
            try
            {
                string sql = "";
                if (_isAdministrator)		//如果是系统管理员则可以操作全部菜单
                {
                    sql = @"select a.id as menu_id,a.name as menu_name,a.dll_name,a.function_name,a.icon,b.module_id,b.parent_id
							from pub_menu as a
							inner join pub_module_menu as b
							on a.id=b.menu_id
							where a.delete_bit=0 and b.delete_bit=0
							order by b.module_id,b.sort_id";
                }
                else
                {
                    sql = @"select a.id as menu_id,a.name as menu_name,a.dll_name,a.function_name,a.icon,b.module_id,b.parent_id
							from pub_menu as a
							inner join pub_module_menu as b
							on a.id=b.menu_id
							inner join pub_group_access as c
							on b.id=c.module_menu_id
							inner join pub_group_user as d
							on c.group_id=d.group_id
							where d.user_id=" + _userID + @" and a.delete_bit=0 and b.delete_bit=0 and c.delete_bit=0 and d.delete_bit=0
							order by b.module_id,b.sort_id";
                }
                return this.Database.GetDataTable(sql);
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetUserRight\\" + err.Message);
            }
        }
        /// <summary>
        /// 取得该操作员的角色科室
        /// </summary>
        /// <returns></returns>
        public override DataTable GetEmpRoleDept()
        {
            try
            {
                if (_isAdministrator)
                {
                    string sql = @"select dept_id,NAME AS dept_name,py_code,wb_code,d_code,0 as default_bit 
							from JC_DEPT_PROPERTY where scbz=0 ";
                    return this.Database.GetDataTable(sql);
                }
                else
                {
                    return base.GetEmpRoleDept();
                }
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetEmpRoleDept\\" + err.Message);
            }

        }

        #region 接口IStdObject成员
        /// <summary>
        /// 保存对象
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            return false;
        }
        /// <summary>
        /// 刷新信息
        /// </summary>
        /// <returns></returns>
        public override bool Retrieve()
        {
            //GetUserInfo(_userID);
            //base.Retrieve();
            //jianqg 2012-10月 emr-his框架整合 修改 同一一个取用户信息 使用_loginCode 将原有代码注释 ，只返回true

            return true;
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns></returns>
        public override bool Delete()
        {
            return false;
        }
        #endregion



    }
}
