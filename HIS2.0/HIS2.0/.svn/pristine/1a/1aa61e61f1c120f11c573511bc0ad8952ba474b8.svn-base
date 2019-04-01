using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

/*
 * 功能:预约挂号的功能、查询
 * 作者:周鹏
 */
namespace Ts_OrderRegist
{
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

            switch (_functionName)
            {
                case "Fun_ts_mz_yygh_regist":
                    Frm_OrderRegist frm = new Frm_OrderRegist(_menuTag, _chineseName, _mdiParent, CurrentUser, ts_mz_class.Mz_YYgh.YYgh_Sort.院内预约);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.Show();
                    break;
                case "Fun_ts_mz_yygh_regist_Doc":
                    Frm_OrderRegist frm_doc = new Frm_OrderRegist(_menuTag, _chineseName, _mdiParent, CurrentUser, ts_mz_class.Mz_YYgh.YYgh_Sort.医生站预约, CurrentDept.DeptId, "", "", null);
                    if (_mdiParent != null)
                    {
                        frm_doc.MdiParent = _mdiParent;
                    }
                    frm_doc.Show();
                    break;
                case "Fun_ts_mz_yygh_tj":
                    Frm_TJ_YYGH frm_tj = new Frm_TJ_YYGH(_menuTag, _chineseName, _mdiParent, CurrentUser);
                    if (_mdiParent != null)
                    {
                        frm_tj.MdiParent = _mdiParent;
                    }
                    frm_tj.Show();
                    break;
                    //Modify By zp 2014-10-21
                case "Fun_ts_mz_yygh_yyptsz":
                    Frm_YYPTSZ frm_ptsz = new Frm_YYPTSZ(_menuTag, _chineseName, _mdiParent, CurrentUser);
                    if (_mdiParent != null)
                    {
                        frm_ptsz.MdiParent = _mdiParent;
                    }
                    frm_ptsz.Show();
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
            objectInfo.Name = "Ts_OrderRegist";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "门诊预约挂号";				       //★中文描述,可以为空
            objectInfo.Remark = "";							      //★描述,可以为空
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[4];
            objectInfos[0].Name = "Fun_ts_mz_yygh_regist";
            objectInfos[0].Text = "预约挂号登记";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fun_ts_mz_yygh_regist_Doc";
            objectInfos[1].Text = "医生站预约挂号登记";
            objectInfos[1].Remark = "";

            objectInfos[2].Name = "Fun_ts_mz_yygh_tj";
            objectInfos[2].Text = "预约挂号统计";
            objectInfos[2].Remark = "";

            objectInfos[3].Name = "Fun_ts_mz_yygh_yyptsz";
            objectInfos[3].Text = "预约平台设置";
            objectInfos[3].Remark = "";
            return objectInfos;
        }
        #endregion

        #endregion  
    }
}
