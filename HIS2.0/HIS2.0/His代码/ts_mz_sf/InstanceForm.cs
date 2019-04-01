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

namespace ts_mz_sf			//★修改为约定的命名空间
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
                case "Fun_ts_mz_sf"://新增参数关闭门诊收费划价功能
                    //SystemCfg cfg1121 = new SystemCfg(1121);
                    //if (cfg1121.Config == "1")
                    //{
                    //    int err_code = 0;
                    //    string err_text = "";
                    //    ts_mz_class.Fun.Isjz(BCurrentUser.EmployeeId, out err_code, out err_text, BDatabase);
                    //    if (err_code == -1)
                    //    {
                    //        MessageBox.Show(err_text);
                    //        return;
                    //    }
                    //}
                    if (new SystemCfg(1112).Config == "1")
                    {
                        Frmsf_only frmsf = new Frmsf_only(_menuTag, _chineseName, _mdiParent);
                        if (_mdiParent != null)
                        {
                            frmsf.MdiParent = _mdiParent;
                        }
                        frmsf.Show();
                    }
                    else
                    {
                        Frmhjsf Frmhjsf = new Frmhjsf(_menuTag, _chineseName, _mdiParent);
                        if (_mdiParent != null)
                        {
                            Frmhjsf.MdiParent = _mdiParent;
                        }
                        Frmhjsf.Show();
                    }
                    break;
                    //Frmhjsf Frmhjsf = new Frmhjsf(_menuTag, _chineseName, _mdiParent);
                    //if (_mdiParent != null)
                    //{
                    //    Frmhjsf.MdiParent = _mdiParent;
                    //}
                    //Frmhjsf.Show();
                    //break;
                case "Fun_ts_mz_sf_not1112"://不受参数控制的门诊收费划价菜单
                    Frmhjsf frmhjsf = new Frmhjsf(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmhjsf.MdiParent = _mdiParent;
                    }
                    frmhjsf.Show();
                    break;
                case "Fun_ts_mz_hj":
                case "Fun_ts_mz_hj_Lg":
                case "Fun_ts_mz_hj_ypxmhj":
                    Frmhjsf frmhj = new Frmhjsf(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmhj.MdiParent = _mdiParent;
                    }
                    frmhj.Show();
                    break;
                case "Fun_ts_mz_tf_not1021"://Add ByZj 2012-12-27
                case "Fun_ts_mz_tf":  //Modify By Zp 2014-02-07
                    //string config=new SystemCfg(1105).Config.Trim();
                    //if (config == "0")
                    //{
                        Frmtf Frmtf = new Frmtf(_menuTag, _chineseName, _mdiParent);
                        if (_mdiParent != null)
                        {
                            Frmtf.MdiParent = _mdiParent;
                        }
                        Frmtf.Show();
                        break;
                    //}
                    //else if (config == "1")
                    //{
                    //    Frmtf_sjsh Frmtf = new Frmtf_sjsh(_menuTag, _chineseName, _mdiParent);
                    //    if (_mdiParent != null)
                    //    {
                    //        Frmtf.MdiParent = _mdiParent;
                    //    }
                    //    Frmtf.Show();
                    //}
                    //else
                     //   throw new Exception("1105参数值设置错误！");
                //case "Fun_ts_mz_sf_ghxxid":
                //    Frmhjsf frmhjsf2 = new Frmhjsf(_menuTag, _chineseName, _mdiParent, new Guid("279DAFAD-D4D2-4C43-815C-A30101248124"));
                //    if (_mdiParent != null)
                //    {
                //        frmhjsf2.MdiParent = _mdiParent;
                //    }
                //    frmhjsf2.Show();
                //    break;
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
            objectInfo.Name = "ts_mz_sf";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "门诊收费";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[7];
            objectInfos[0].Name = "Fun_ts_mz_sf";
            objectInfos[0].Text = "门诊收费";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fun_ts_mz_hj";
            objectInfos[1].Text = "门诊划价";
            objectInfos[1].Remark = "药房划从";

            objectInfos[2].Name = "Fun_ts_mz_hj_Lg";
            objectInfos[2].Text = "门诊留观划价";
            objectInfos[2].Remark = "";

            objectInfos[3].Name = "Fun_ts_mz_tf";
            objectInfos[3].Text = "门诊退费";
            objectInfos[3].Remark = "";

            objectInfos[4].Name = "Fun_ts_mz_hj_ypxmhj";
            objectInfos[4].Text = "门诊划价";
            objectInfos[4].Remark = "药品和项目";

            objectInfos[5].Name = "Fun_ts_mz_tf_not1021";
            objectInfos[5].Text = "门诊退费(不受1021参数控制)";
            objectInfos[5].Remark = "";

            objectInfos[6].Name = "Fun_ts_mz_sf_not1112";
            objectInfos[6].Text = "门诊收费(不受1112参数控制)";
            objectInfos[6].Remark = "";

            //objectInfos[7].Name = "Fun_ts_mz_sf_ghxxid";
            //objectInfos[7].Text = "门诊收费(GHXXID)";
            //objectInfos[7].Remark = "";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
