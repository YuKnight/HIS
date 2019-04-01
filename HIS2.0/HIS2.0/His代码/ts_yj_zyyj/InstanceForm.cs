/*
 * 命名空间:默认为程序集名称,与编译后的dll文件同名
 * 需要修改的部分为
 *		InstanceWorkForm方法的实现
 *		GetDllInfo 方法内的信息
 *		GetFunctionsInfo 方法内的信息
 * 具体参见代码中带号的注释
*/
using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_yj_zyyj				//★修改为约定的命名空间
{
    /// <summary>
    /// InstanceBForm 的摘要说明
    /// 实例化业务窗体
    /// </summary>
    public class InstanceForm : IDllInformation
    {
        //公共静态变量
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        public static MenuTag _menuTag;
        public static string _functionName;
        public static string _chineseName;
        public static long _menuId;
        public static Form _mdiParent;
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
            bool isCj = true;
            switch (_functionName)
            {
                //Modify By tany 2010-11-26
                case "Fun_ts_yj_zyyj":
                case "Fun_ts_yj_zyyj_zfy":
                case "Fun_ts_yj_zyyj_ffy":
                case "Fun_ts_yj_zyyj_uncj"://Modify By Tany 2016-01-08 不允许冲减
                    int type = -1;
                    if (_functionName == "Fun_ts_yj_zyyj_zfy")
                    {
                        type = 0;
                    }
                    else if (_functionName == "Fun_ts_yj_zyyj_ffy")
                    {
                        type = 1;
                    }
                    else
                    {
                        type = -1;
                    }
                    if (_functionName == "Fun_ts_yj_zyyj_uncj")
                    {
                        isCj = false;
                    }
                    Frmyjsq Frmyjsq = new Frmyjsq(_menuTag, _chineseName, _mdiParent, type, isCj);
                    if (_mdiParent != null)
                    {
                        Frmyjsq.MdiParent = _mdiParent;
                    }
                    Frmyjsq.Show();
                    break;
                case "Fun_ts_yj_zyyj_cx":
                case "Fun_ts_yj_zyyj_xg":
                case "Fun_ts_yj_zyyj_xg_addfee":
                case "Fun_ts_yj_zyyj_cx_uncj"://Modify By Tany 2016-01-21 不允许冲减
                    if (_functionName == "Fun_ts_yj_zyyj_cx_uncj")
                    {
                        isCj = false;
                    }
                    Frmyjsq_cx Frmyjsq_cx = new Frmyjsq_cx(_menuTag, _chineseName, _mdiParent, isCj);
                    if (_mdiParent != null)
                    {
                        Frmyjsq_cx.MdiParent = _mdiParent;
                    }
                    Frmyjsq_cx.Show();
                    break;
                case "Fun_ts_yj_zyyj_mag":
                    FrmMessage frmAction = new FrmMessage();
                    if (_mdiParent != null)
                    {
                        frmAction.MdiParent = _mdiParent;
                    }
                    frmAction.Show();
                    frmAction.WindowState = FormWindowState.Maximized;
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
            objectInfo.Name = "ts_yj_zyyj";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "住院医技";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[9];
            objectInfos[0].Name = "Fun_ts_yj_zyyj";
            objectInfos[0].Text = "住院医技确认";
            objectInfos[0].Remark = "住院医技确认";
            objectInfos[1].Name = "Fun_ts_yj_zyyj_cx";
            objectInfos[1].Text = "住院医技查询";
            objectInfos[1].Remark = "住院医技查询";
            objectInfos[2].Name = "Fun_ts_yj_zyyj_xg";
            objectInfos[2].Text = "住院医技查询与修改";
            objectInfos[2].Remark = "住院医技查询与修改";
            objectInfos[3].Name = "Fun_ts_yj_zyyj_xg_addfee";
            objectInfos[3].Text = "住院医技查询与修改(费用录入)";
            objectInfos[3].Remark = "住院医技查询与修改(费用录入)";
            objectInfos[4].Name = "Fun_ts_yj_zyyj_zfy";
            objectInfos[4].Text = "住院医技确认(正费)";
            objectInfos[4].Remark = "住院医技确认(正费)";
            objectInfos[5].Name = "Fun_ts_yj_zyyj_ffy";
            objectInfos[5].Text = "住院医技确认(负费)";
            objectInfos[5].Remark = "住院医技确认(负费)";
            objectInfos[6].Name = "Fun_ts_yj_zyyj_mag";
            objectInfos[6].Text = "住院医技危机预警";
            objectInfos[6].Remark = "住院医技危机预警";
            objectInfos[7].Name = "Fun_ts_yj_zyyj_uncj";
            objectInfos[7].Text = "住院医技确认(无冲减)";
            objectInfos[7].Remark = "住院医技确认(无冲减)";
            objectInfos[8].Name = "Fun_ts_yj_zyyj_cx_uncj";
            objectInfos[8].Text = "住院医技查询与修改(无冲减)";
            objectInfos[8].Remark = "住院医技查询与修改(无冲减)";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
