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
using System.Data;

namespace ts_yf_zyfy			//★修改为约定的命名空间
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
            }				//★需要调用的窗口类
            switch (_functionName)
            {
                case "Fun_ts_yf_zyfy_tld":
                case "Fun_ts_yf_zyfy_tld_by":
                case "Fun_ts_yf_zyfy_tld_bq":
                case "Fun_ts_yf_zyfy_ly":
                case "Fun_ts_yf_zyfy_tld_jz": //Add By Tany 2015-05-04 增加引出函数，仅仅记账
                case "Fun_ts_yf_zyfy_tld_by_jz": //Add By Tany 2015-05-04 增加引出函数，仅仅记账
                    Frmtlfy Frmtlfy = new Frmtlfy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmtlfy.MdiParent = _mdiParent;
                    }
                    Frmtlfy.Show();
                    break;
                case "Fun_ts_yf_zyfy_cf":
                case "Fun_ts_yf_zyfy_cf_ZCY":
                case "Fun_ts_yf_zyfy_cf_YFFY":
                case "Fun_ts_yf_zyfy_cf_cx":
                case "Fun_ts_yf_zyfy_cf_jy":
                    Frmcffy Frmcffy = new Frmcffy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmcffy.MdiParent = _mdiParent;
                    }
                    Frmcffy.Show();
                    break;
                case "Fun_ts_yf_zyfy_tld_cx":
                case "Fun_ts_yf_zyfy_tld_by_cx":
                    Frmtlfy_cx Frmtlfy_cx = new Frmtlfy_cx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmtlfy_cx.MdiParent = _mdiParent;
                    }
                    Frmtlfy_cx.Show();
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
            objectInfo.Name = "ts_yf_zyfy";
            objectInfo.Text = "";
            objectInfo.Remark = "";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[13];
            objectInfos[0].Name = "Fun_ts_yf_zyfy_tld";
            objectInfos[0].Text = "住院药品统领单";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_yf_zyfy_cf";
            objectInfos[1].Text = "住院处方发药";
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_yf_zyfy_cf_cx";
            objectInfos[2].Text = "住院处方查询";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_yf_zyfy_tld_bq";
            objectInfos[3].Text = "病区住院药品统领";
            objectInfos[3].Remark = "";
            objectInfos[4].Name = "Fun_ts_yf_zyfy_ly";
            objectInfos[4].Text = "病区住院药品统领(嫁接专用)";
            objectInfos[4].Remark = "";
            objectInfos[5].Name = "Fun_ts_yf_zyfy_cf_jy";
            objectInfos[5].Text = "住院处方发药(标记发药但实际不发药)";
            objectInfos[5].Remark = "";
            objectInfos[6].Name = "Fun_ts_yf_zyfy_tld_by";
            objectInfos[6].Text = "住院药品摆药单";
            objectInfos[6].Remark = "";
            objectInfos[7].Name = "Fun_ts_yf_zyfy_tld_cx";
            objectInfos[7].Text = "病区住院药品统领查询";
            objectInfos[7].Remark = "";
            objectInfos[8].Name = "Fun_ts_yf_zyfy_tld_by_cx";
            objectInfos[8].Text = "住院药品摆药单查询";
            objectInfos[8].Remark = "";
            objectInfos[9].Name = "Fun_ts_yf_zyfy_tld_jz"; //Add By Tany 2015-05-04 增加引出函数，仅仅记账
            objectInfos[9].Text = "住院药品统领单(记账)";
            objectInfos[9].Remark = "";
            objectInfos[10].Name = "Fun_ts_yf_zyfy_tld_by_jz"; //Add By Tany 2015-05-05 增加引出函数，仅仅记账
            objectInfos[10].Text = "住院药品摆药单(记账)";
            objectInfos[10].Remark = "";

            objectInfos[11].Name = "Fun_ts_yf_zyfy_cf_ZCY";
            objectInfos[11].Text = "住院处方发药【天济】";
            objectInfos[11].Remark = "";
            objectInfos[12].Name = "Fun_ts_yf_zyfy_cf_YFFY";
            objectInfos[12].Text = "住院处方发药【药房】";
            objectInfos[12].Remark = "";

            return objectInfos;
        }
        #endregion

        #endregion

        internal static void DebugView(DataTable table)
        {
            return;
            Form f = new Form();
            DataGrid grd = new DataGrid();
            grd.DataSource = table;
            grd.Dock = DockStyle.Fill;
            f.Controls.Add(grd);
            f.ShowDialog();
        }
    }
}
