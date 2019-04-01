using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_yp_kjbb
{
    /// <summary>
    /// InstanceBForm 的摘要说明
    /// 实例化业务窗体
    /// </summary>
    public class InstanceForm : IInnerCommunicate
    {
        //公共静态变量
        public static RelationalDatabase BDatabase;
        public static TrasenFrame.Classes.User BCurrentUser;
        public static Department BCurrentDept;

        public static MenuTag _menuTag;
        private string _functionName;
        private string _chineseName;
        private long _menuId;
        private System.Windows.Forms.Form _mdiParent;
        private object[] _communicateValue;
        /// <summary>
        /// 构造函数
        /// </summary>
        public InstanceForm()
        {
            BDatabase = null;
            BCurrentUser = null;
            BCurrentDept = null;

            _functionName = "";
            _chineseName = "";
            _menuId = -1;
            _mdiParent = null;
        }

        #region IDllInformation 成员(一定要在此实现)

        #region 属性
        /// <summary>
        /// 实例化窗体函数名称
        /// </summary>
        public string FunctionName
        {
            get
            {
                return _functionName;
            }
            set
            {
                _functionName = value;
            }
        }
        /// <summary>
        /// 窗体中文名称
        /// </summary>
        public string ChineseName
        {
            get
            {
                return _chineseName;
            }
            set
            {
                _chineseName = value;
            }
        }
        /// <summary>
        /// 当前操作员ID
        /// </summary>
        public TrasenFrame.Classes.User CurrentUser
        {
            get
            {
                return BCurrentUser;
            }
            set
            {
                BCurrentUser = value;
            }
        }
        /// <summary>
        /// 当前操作科室ID
        /// </summary>
        public Department CurrentDept
        {
            get
            {
                return BCurrentDept;
            }
            set
            {
                BCurrentDept = value;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public long MenuId
        {
            get
            {
                return _menuId;
            }
            set
            {
                _menuId = value;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public System.Windows.Forms.Form MdiParent
        {
            get
            {
                return _mdiParent;
            }
            set
            {
                _mdiParent = value;
            }
        }
        public RelationalDatabase Database
        {
            get
            {
                return InstanceForm.BDatabase;
            }
            set
            {
                InstanceForm.BDatabase = value;
            }
        }
        public MenuTag FunctionTag
        {
            get
            {
                return _menuTag;
            }
            set
            {
                _menuTag = value;
            }
        }
        /// <summary>
        /// 内部通信参数
        /// </summary>
        public object[] CommunicateValue
        {
            get
            {
                return _communicateValue;
            }
            set
            {
                _communicateValue = value;
            }
        }
        #endregion

        #region 函数
        /// <summary>
        /// 根据函数名称实例化窗体
        /// </summary>
        public void InstanceWorkForm()
        {
            if ( _functionName == "" )
            {
                throw new Exception( "引出函数名不能为空！" );
            }

            switch ( _functionName )
            {

                case "Fun_ts_yp_kjbb":
                    FrmReportFrame frmReport = new FrmReportFrame( InstanceForm.BDatabase );
                    if ( _mdiParent != null )
                    {
                        frmReport.MdiParent = _mdiParent;
                    }

                    frmReport.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    frmReport.BringToFront();
                    frmReport.Show();
                    break;                
                default:
                    throw new Exception( "引出函数名错误！" );
            }
        }
        /// <summary>
        /// 返回一个FORM对象
        /// </summary>
        /// <returns></returns>
        public object GetObject()
        {
            return null;
        }

        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_yp_kjbb";
            objectInfo.Text = "药品会计报表";
            objectInfo.Remark = "药品会计报表";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[1];

            objectInfos[0].Name = "Fun_ts_yp_kjbb";
            objectInfos[0].Text = "药品会计报表";
            objectInfos[0].Remark = "";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}
