using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using System.Windows.Forms;
using Ts_zyys_yzgl;
using TrasenClasses.GeneralClasses;

namespace ts_jc_gfbl
{
    /// <summary>
    /// InstanceForm 的摘要说明。
    /// 该类是每个DLL供外界访问的接口函数类
    /// 名称不能改（包括大小写）
    /// </summary>
    public class InstanceForm : IDllInformation
    {

        private string _functionName;
        private string _chineseName;
        public static User _currentUser;
        public static Department _currentDept;
        private long _menuId;
        public static RelationalDatabase _database;
        private MenuTag _functions;
        private Form _mdiParent;
        private object[] _communicateValue;

        public InstanceForm()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            _functionName = "";
            _chineseName = "";
            _database = null;
            _currentUser = null;
            _currentDept = null;
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
                return _currentUser;
            }
            set
            {
                _currentUser = value;
            }
        }

        /// <summary>
        /// 当前操作科室ID
        /// </summary>
        public Department CurrentDept
        {
            get
            {
                return _currentDept;
            }
            set
            {
                _currentDept = value;
            }
        }

        /// <summary>
        /// Database数据库实体类
        /// </summary>
        public RelationalDatabase Database
        {
            get
            {
                return _database;
            }
            set
            {
                _database = value;
            }
        }

        /// <summary>
        /// FuncationTag用来传附加值
        /// </summary>
        public MenuTag FunctionTag
        {
            get
            {
                return _functions;
            }
            set
            {
                _functions = value;
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
        /// MDI父窗体
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
                case "Fun_Ts_zyys_sflb":
                    frm = new FrmSflb();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_sflbmx":
                    frm = new FrmSflbMx();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_gflb":
                    frm = new FrmGflb();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_gflbmx":
                    frm = new FrmGflbMx();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_GfBcBl":
                    frm = new FrmGfBcBl();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_PatRcrds":
                    frm = new FrmPatRcrds();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_PfWrkUnits":
                    frm = new FrmPfWrkUnits();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_MatSflb":
                    frm = new FrmMatSflb();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_PubFeeQuery":
                    frm = new FrmPubFeeQuery();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_ExpPubFee":
                    frm = new FrmExpPubFee();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_JAQExpPubFee":
                    string jaq_yblx = "22";
                    frm = new FrmExpPubFee(jaq_yblx);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_MzGfSh":
                    frm = new FrmGfChk();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_GfItem":
                    frm = new FrmGfItem();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                default:
                    throw new Exception("引出函数名错误！");
            }
        }

        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[13];
            objectInfos[0].Name = "Fun_Ts_zyys_sflb";
            objectInfos[0].Text = "收费类别";
            objectInfos[0].Remark = "收费类别";
            objectInfos[1].Name = "Fun_Ts_zyys_sflbmx";
            objectInfos[1].Text = "收费类别明细";
            objectInfos[1].Remark = "收费类别明细";
            objectInfos[2].Name = "Fun_Ts_zyys_gflb";
            objectInfos[2].Text = "公费类别";
            objectInfos[2].Remark = "公费类别";
            objectInfos[3].Name = "Fun_Ts_zyys_gflbmx";
            objectInfos[3].Text = "公费类别明细";
            objectInfos[3].Remark = "公费类别明细";

            objectInfos[4].Name = "Fun_Ts_zyys_GfBcBl";
            objectInfos[4].Text = "公费补充比例";
            objectInfos[4].Remark = "公费补充比例";

            objectInfos[5].Name = "Fun_Ts_zyys_PatRcrds";
            objectInfos[5].Text = "公费病员档案";
            objectInfos[5].Remark = "公费病员档案";

            objectInfos[6].Name = "Fun_Ts_zyys_PfWrkUnits";
            objectInfos[6].Text = "公费企业单位维护";
            objectInfos[6].Remark = "公费企业单位维护";

            objectInfos[7].Name = "Fun_Ts_zyys_MatSflb";
            objectInfos[7].Text = "收费大类别匹配";
            objectInfos[7].Remark = "收费大类别匹配";

            objectInfos[8].Name = "Fun_Ts_zyys_PubFeeQuery";
            objectInfos[8].Text = "公费联单查询";
            objectInfos[8].Remark = "公费联单查询";

            objectInfos[9].Name = "Fun_Ts_zyys_ExpPubFee";
            objectInfos[9].Text = "市公费导出";
            objectInfos[9].Remark = "市公费导出";

            objectInfos[10].Name = "Fun_Ts_zyys_MzGfSh";
            objectInfos[10].Text = "门诊公费审核";
            objectInfos[10].Remark = "门诊公费审核";

            objectInfos[11].Name = "Fun_Ts_zyys_GfItem";
            objectInfos[11].Text = "公费项目维护";
            objectInfos[11].Remark = "公费项目维护";

            objectInfos[12].Name = "Fun_Ts_zyys_JAQExpPubFee";
            objectInfos[12].Text = "江岸区公费导出";
            objectInfos[12].Remark = "江岸区公费导出";

            return objectInfos;
        }
        #endregion

        #endregion

        #region IDllInformation 成员


        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_jc_gfbl";
            objectInfo.Text = "公费基础维护";
            objectInfo.Remark = "公费基础维护";
            return objectInfo;
        }

        #endregion
    }
}
