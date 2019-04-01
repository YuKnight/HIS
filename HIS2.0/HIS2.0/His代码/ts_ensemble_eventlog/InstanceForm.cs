using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_ensemble_eventlog
{
    /// <summary>
    /// InstanceForm 的摘要说明。
    /// 该类是每个DLL供外界访问的接口函数类
    /// 名称不能改（包括大小写）
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
        private Form _mdiParent;
        private object[] _communicateValue;
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

        #region IInnerCommunicate 成员(一定要在此实现)

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
        public Form MdiParent
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
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            Form frm = null;
            switch (_functionName)
            {
                case "Fun_ts_ensemble_eventlog":
                    frm = new FrmMain(_chineseName, BCurrentUser, BCurrentDept);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }

                    frm.WindowState = FormWindowState.Maximized;
                    frm.BringToFront();
                    frm.Show();
                    break;
                case "Fun_ts_ensemble_tools":
                    frm = new FrmTools();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }

                    frm.WindowState = FormWindowState.Maximized;
                    frm.BringToFront();
                    frm.Show();	
                    break;
                case "Fun_ts_sync_patientinfo":
                    TrasenHIS.BLL.SyncPatientInfo.SyncPat(FrmMdiMain.Database);
                    break;
                case "Fun_ts_ensemble_eventmessagelog":
                    frm = new FrmMessageMain(_chineseName, BCurrentUser, BCurrentDept);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }

                    frm.WindowState = FormWindowState.Maximized;
                    frm.BringToFront();
                    frm.Show();
                    break;
                default:
                    throw new Exception("引出函数名错误！");
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
            objectInfo.Name = "ts_ensemble_eventlog";
            objectInfo.Text = "平台事件查询";
            objectInfo.Remark = "平台事件查询";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[4];
            objectInfos[0].Name = "Fun_ts_ensemble_eventlog";
            objectInfos[0].Text = "平台事件查询";
            objectInfos[0].Remark = "平台事件查询";
            objectInfos[1].Name = "Fun_ts_ensemble_tools";
            objectInfos[1].Text = "交互小工具";
            objectInfos[1].Remark = "交互小工具";
            objectInfos[2].Name = "Fun_ts_sync_patientinfo";
            objectInfos[2].Text = "同步新老病人信息";
            objectInfos[2].Remark = "同步新老病人信息";
            objectInfos[3].Name = "Fun_ts_ensemble_eventmessagelog";
            objectInfos[3].Text = "门诊事件查询";
            objectInfos[3].Remark = "门诊事件查询";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}
