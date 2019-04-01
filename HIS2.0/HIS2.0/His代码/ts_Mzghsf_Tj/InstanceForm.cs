using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_Mzghsf_Tj
{
    public class InstanceForm : IDllInformation, IInnerCommunicate
    {
        //公共静态变量
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        public static MenuTag _menuTag;
        private string _functionName;
        private string _chineseName;
        private long _menuId;
        private Form _mdiParent;
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
        public User CurrentUser
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
        /// 根据函数名称实例化窗体 FrmMzghsfghyrjbd
        /// </summary>
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
              				        //★需要调用的窗口类 FrmMzghsfghyrjbd
            switch (_functionName)
            {
                case "Fun_ts_MzGhsf_TJ":
                    FrmMzGhySfStaticReport frmMzgh = new FrmMzGhySfStaticReport(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmMzgh.MdiParent = _mdiParent;
                    }
                    frmMzgh.WindowState = FormWindowState.Maximized;
                    frmMzgh.Show();
                    break;

                case "Fun_ts_MzGhsf_RJTJ":
                    FrmMzghsfghyrjbd frmMzghRJ = new FrmMzghsfghyrjbd(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmMzghRJ.MdiParent = _mdiParent;
                    }
                    frmMzghRJ.WindowState = FormWindowState.Maximized;
                    frmMzghRJ.Show();
                    break;

                default:
                    throw new Exception("引出函数名称错误！");
            }

        }
        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_Mzgh_Tj";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "门诊挂号收费统计";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }

        public object GetObject()
        {
            //if (_functionName == "")
            //{
            //    throw new Exception("引出函数名不能为空！");
            //}
            //Form f = null;
            //switch (_functionName)
            //{
            //    case "Fun_ts_yp_tj_cx":
            //        Frmyptj Frmyptj = new Frmyptj((MenuTag)CommunicateValue[0], Convert.ToString(CommunicateValue[1]), _mdiParent);
            //        if (_mdiParent != null)
            //        {
            //            Frmyptj.MdiParent = _mdiParent;
            //        }
            //        Frmyptj.FillDj(new Guid(Convert.ToString(CommunicateValue[2])), true);
            //        Frmyptj.Show();
            //        Frmyptj.FindRecord((int)CommunicateValue[4], 0);
            //        return Frmyptj;
            //    default:
            //        throw new Exception("引出函数名称错误！");
            //}
            //return f;
            return null;
        }


        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[2];
            objectInfos[0].Name = "Fun_ts_MzGhsf_TJ";
            objectInfos[0].Text = "门诊挂号收费报表统计";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fun_ts_MzGhsf_RJTJ";
            objectInfos[1].Text = "门诊挂号收费员日缴报表";
            objectInfos[1].Remark = "";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}
