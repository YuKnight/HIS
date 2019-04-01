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

namespace ts_mz_xtsz				//★修改为约定的命名空间
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

            switch (_functionName)
            {
                case "Fun_ts_mz_xtsz_fpgl":
                    Frmfpgl Frmfpgl = new Frmfpgl(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmfpgl.MdiParent = _mdiParent;
                    }
                    Frmfpgl.Show();
                    break;
                case "Fun_ts_mz_xtsz_fpgl_grsz":
                    Frmfpgl Frmfpgl_grsz = new Frmfpgl(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmfpgl_grsz.MdiParent = _mdiParent;
                    }
                    Frmfpgl_grsz.Show();
                    break;
                //case "Fun_ts_mz_xtsz_yhlx":
                //    Frmyhlx Frmyhlx = new Frmyhlx(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        Frmyhlx.MdiParent = _mdiParent;
                //    }
                //    Frmyhlx.Show();
                //    break;
                //case "Fun_ts_mz_xtsz_cfmb_qy":
                //    Frmblcf Frmblcf_qy = new Frmblcf(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        Frmblcf_qy.MdiParent = _mdiParent;
                //    }
                //    Frmblcf_qy.Show();
                //    break;
                //case "Fun_ts_mz_xtsz_cfmb_ks":
                //    Frmblcf Frmblcf_ks = new Frmblcf(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        Frmblcf_ks.MdiParent = _mdiParent;
                //    }
                //    Frmblcf_ks.Show();
                //    break;
                //case "Fun_ts_mz_xtsz_cfmb_ys":
                //    Frmblcf Frmblcf_ys = new Frmblcf(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        Frmblcf_ys.MdiParent = _mdiParent;
                //    }
                //    Frmblcf_ys.Show();
                //    break;
                case "Fun_ts_xtsz_cyzd":
                    FrmDiagnose FrmDiagnose = new FrmDiagnose(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmDiagnose.MdiParent = _mdiParent;
                    }
                    FrmDiagnose.Show();
                    break;
                case "Fun_ts_xtsz_cyypxm":
                    FrmItem FrmItem = new FrmItem(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmItem.MdiParent = _mdiParent;
                    }
                    FrmItem.Show();
                    break;
                case "Fun_ts_xtsz_LgXmsz":
                    FrmLgXmsz FrmLgXmsz = new FrmLgXmsz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmLgXmsz.MdiParent = _mdiParent;
                    }
                    FrmLgXmsz.Show();
                    break;
                case "Fun_ts_jc_export_yb":
                    frmexportYb frmexportYb = new frmexportYb(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmexportYb.MdiParent = _mdiParent;
                    }
                    frmexportYb.Show();
                    break;
                case "Fun_ts_jc_zfbl_yb":
                    Frmzfbl Frmzfbl = new Frmzfbl(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzfbl.MdiParent = _mdiParent;
                    }
                    Frmzfbl.Show();
                    break;
                case "Fun_ts_jc_ypksxz":
                    Frmypksxz frmypksxz = new Frmypksxz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmypksxz.MdiParent = _mdiParent;
                    }
                    frmypksxz.Show();
                    break;
                case "Fun_ts_jc_mzyfglfy"://门诊用法关联费用
                    Frmmzyfglfy frmmzyfglfy = new Frmmzyfglfy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmmzyfglfy.MdiParent = _mdiParent;
                    }
                    frmmzyfglfy.Show();
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
            objectInfo.Name = "ts_mz_xtsz";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "门诊系统设置";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[10];
            objectInfos[0].Name = "Fun_ts_mz_xtsz_fpgl";
            objectInfos[0].Text = "发票领用管理";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_mz_xtsz_fpgl_grsz";
            objectInfos[1].Text = "个人发票设置";
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_xtsz_cyzd";
            objectInfos[2].Text = "医生常用诊断维护";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_xtsz_cyypxm";
            objectInfos[3].Text = "医生常用药品/项目维护";
            objectInfos[3].Remark = "";
            objectInfos[4].Name = "Fun_ts_xtsz_LgXmsz";
            objectInfos[4].Text = "留观项目设置";
            objectInfos[4].Remark = "";
            objectInfos[5].Name = "Fun_ts_jc_export_yb";
            objectInfos[5].Text = "导出HIS目录到医保";
            objectInfos[5].Remark = "";
            objectInfos[6].Name = "Fun_ts_jc_zfbl_yb";
            objectInfos[6].Text = "刷新医保匹配关系到HIS";
            objectInfos[6].Remark = "";
            objectInfos[7].Name = "Fun_ts_jc_ypksxz";
            objectInfos[7].Text = "药品科室限制";
            objectInfos[7].Remark = "";
            objectInfos[8].Name = "Fun_ts_jc_mzyfglfy";
            objectInfos[8].Text = "门诊用法关联费用";
            objectInfos[8].Remark = "";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
