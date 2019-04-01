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

namespace ts_mz_kgl				//★修改为约定的命名空间
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
        private string _functionName;
        private string _chineseName;
        private long _menuId;
        private Form _mdiParent;
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
                case "Fun_ts_mz_kgl_klxsz":
                    Frmklxsz Frmklxsz = new Frmklxsz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmklxsz.MdiParent = _mdiParent;
                    }
                    Frmklxsz.Show();
                    break;
                case "Fun_ts_mz_kgl_kdj":
                    Frmbrxxcx Frmbrxxdj = new Frmbrxxcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmbrxxdj.MdiParent = _mdiParent;
                    }
                    Frmbrxxdj.Show();
                    break;
                case "Fun_ts_mz_kgl_cx":
                    Frmbrxxcx Frmbrxxcx = new Frmbrxxcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmbrxxcx.MdiParent = _mdiParent;
                    }
                    Frmbrxxcx.Show();
                    break;
                case "Fun_ts_mz_kgl_jhk_tf"://Add By ZJ 2012-12-26
                case "Fun_ts_mz_kgl_jhk":
                    FrmHkJk FrmHkJk = new FrmHkJk(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmHkJk.MdiParent = _mdiParent;
                    }
                    FrmHkJk.Show();
                    break;
                case "Fun_ts_mz_kgl_je":
                    Frmbrkcz Frmbrkcz = new Frmbrkcz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmbrkcz.MdiParent = _mdiParent;
                    }
                    Frmbrkcz.Show();
                    break;
                case "Fun_ts_mz_kgl_kyhsz":
                    FrmKyhsz FrmKyhsz = new FrmKyhsz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmKyhsz.MdiParent = _mdiParent;
                    }
                    FrmKyhsz.Show();
                    break;
                case "Fun_ts_mz_xtsz_klygl": //诊疗卡领用管理 Add By Zj 2012-06-28
                    FrmKly frmkly = new FrmKly(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmkly.MdiParent = _mdiParent;
                    }
                    frmkly.Show();
                    break;
                case "Fun_kyh_ksyz":
                    FrmKyhKsyz frmKyhKsyz = new FrmKyhKsyz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmKyhKsyz.MdiParent = _mdiParent;
                    }
                    frmKyhKsyz.Show();
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
            objectInfo.Name = "ts_mz_kgl";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "门诊卡管理";								//★中文描述,可以为空
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
            objectInfos[0].Name = "Fun_ts_mz_kgl_klxsz";
            objectInfos[0].Text = "卡类型设置";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_mz_kgl_kdj";
            objectInfos[1].Text = "病人信息查询与登记";
            objectInfos[2].Name = "Fun_ts_mz_kgl_cx";
            objectInfos[2].Text = "病人信息查询";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_mz_kgl_jhk";
            objectInfos[3].Text = "借卡与换卡";
            objectInfos[3].Remark = "";
            objectInfos[4].Name = "Fun_ts_mz_kgl_je";
            objectInfos[4].Text = "卡充值";
            objectInfos[4].Remark = "";
            objectInfos[5].Name = "Fun_ts_mz_kgl_kyhsz";
            objectInfos[5].Text = "病人卡优惠设置";
            objectInfos[5].Remark = "";
            objectInfos[6].Name = "Fun_ts_mz_xtsz_klygl";
            objectInfos[6].Text = "诊疗卡领用管理";
            objectInfos[6].Remark = "";
            objectInfos[7].Name = "Fun_ts_mz_kgl_jhk_tf";//Add By Zj 2012-12-26 
            objectInfos[7].Text = "借卡与换卡(卡作废会产生退费金额)";
            objectInfos[7].Remark = "";
            objectInfos[8].Name = "Fun_kyh_ksyz";
            objectInfos[8].Text = "优惠方案科室限制";
            objectInfos[8].Remark = "";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}
