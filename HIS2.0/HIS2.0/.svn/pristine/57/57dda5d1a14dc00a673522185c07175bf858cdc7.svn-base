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

namespace ts_mz_cx		//★修改为约定的命名空间
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

        private MenuTag _menuTag;
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
                case "Fun_ts_mz_cx_ghxxcx":
                    Frmghxxcx Frmghxxcx = new Frmghxxcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmghxxcx.MdiParent = _mdiParent; 
                    }
                    Frmghxxcx.Show();
                    break;
                case "Fun_ts_mz_cx_cfcx":
                    Frmcfcx Frmcfcx = new Frmcfcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmcfcx.MdiParent = _mdiParent;
                    }
                    Frmcfcx.WindowState = FormWindowState.Maximized;
                    Frmcfcx.Show();
                    break;
                case "Fun_ts_mz_cx_fpcx":
                case "Fun_ts_mz_cx_fpcx_bd":
                    Frmfpcx Frmfpcx = new Frmfpcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmfpcx.WindowState = FormWindowState.Maximized;
                        Frmfpcx.MdiParent = _mdiParent;
                        
                    }
                    Frmfpcx.Show();
                    break;
                case "Fun_ts_mz_cx_fpcx_bd_fp":
                    Frmfpcx Frmfpcx1 = new Frmfpcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmfpcx1.WindowState = FormWindowState.Maximized;
                        Frmfpcx1.MdiParent = _mdiParent;
                        Frmfpcx1.flag_fp = "1";

                    }
                    Frmfpcx1.Show();
                    break;
                case "Fun_ts_mz_mzrztj"://Add By zp 2013-08-26
                    Frm_Mzrz frmmzrz = new Frm_Mzrz();
                    if (_mdiParent != null)
                    {
                        frmmzrz.WindowState = FormWindowState.Maximized;
                        frmmzrz.MdiParent = _mdiParent;
                    }
                    frmmzrz.Show();
                    break;
                case "Fun_ts_mz_Yyghxxcx"://Add By jiangzf 2014-03-07                    
                    Frm_Yyghxxcx frmyyghxxcx = new Frm_Yyghxxcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmyyghxxcx.WindowState = FormWindowState.Maximized;
                        frmyyghxxcx.MdiParent = _mdiParent;
                    }
                    frmyyghxxcx.Show();
                    break;
                case "Fun_ts_mz_Mzyspbqkcx":
                    Frm_mzyspbqkcx frmmzyspbqkcx = new Frm_mzyspbqkcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmmzyspbqkcx.WindowState = FormWindowState.Maximized;
                        frmmzyspbqkcx.MdiParent = _mdiParent;
                    }
                    frmmzyspbqkcx.Show();
                    break;
                case "Fun_ts_mz_sjtflccx"://Add By jiangzf 2014-4-11                    
                    FrmSjtflccx frmSjtflccx = new FrmSjtflccx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmSjtflccx.WindowState = FormWindowState.Maximized;
                        frmSjtflccx.MdiParent = _mdiParent;
                    }
                    frmSjtflccx.Show();
                    break;
                case "Fun_ts_mz_cx_DetailsOfCharges":      //2014-12-31 cc/
                    Frm_DetailsOfCharges detailsofcharges = new Frm_DetailsOfCharges(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        detailsofcharges.WindowState = FormWindowState.Maximized;
                        detailsofcharges.MdiParent = _mdiParent;
                    }
                    detailsofcharges.Show();
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
            objectInfo.Name = "ts_mz_cx";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "门诊查询";								//★中文描述,可以为空
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
            objectInfos[0].Name = "Fun_ts_mz_cx_ghxxcx";
            objectInfos[0].Text = "门诊挂号信息查询";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_mz_cx_cfcx";
            objectInfos[1].Text = "门诊病人处方查询";
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_mz_cx_fpcx";
            objectInfos[2].Text = "门诊发票查询";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_mz_cx_fpcx_bd";
            objectInfos[3].Text = "门诊发票查询(可补打任何人的发票)";
            objectInfos[3].Remark = "";
            objectInfos[4].Name = "Fun_ts_mz_mzrztj";
            objectInfos[4].Text = "门诊日志统计";
            objectInfos[4].Remark = "";
            objectInfos[5].Name = "Fun_ts_mz_Yyghxxcx";
            objectInfos[5].Text = "门诊预约挂号信息查询";
            objectInfos[5].Remark = "";
            objectInfos[6].Name = "Fun_ts_mz_Mzyspbqkcx";
            objectInfos[6].Text = "门诊医生排班信息查询";
            objectInfos[6].Remark = "";

            objectInfos[7].Name = "Fun_ts_mz_cx_fpcx_bd_fp";
            objectInfos[7].Text = "门诊发票查询(无条件补打发票)";
            objectInfos[7].Remark = "";//Fun_ts_mz_sjtflccx

            objectInfos[8].Name = "Fun_ts_mz_sjtflccx";
            objectInfos[8].Text = "三级退费流程查询";
            objectInfos[8].Remark = "";

            objectInfos[9].Name = "Fun_ts_mz_cx_DetailsOfCharges";
            objectInfos[9].Text = "120/110病人费用查询";
            objectInfos[9].Remark = "";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
