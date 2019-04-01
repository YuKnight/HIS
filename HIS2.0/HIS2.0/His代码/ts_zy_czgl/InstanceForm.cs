using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_zy_czgl
{
    /// <summary>
    /// InstanceForm 的摘要说明。
    /// 该类是每个DLL供外界访问的接口函数类
    /// 名称不能改（包括大小写）
    /// </summary>
    public class InstanceForm : IDllInformation
    {
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        private string _functionName;
        private string _chineseName;
        private long _menuId;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public InstanceForm()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            BCurrentUser = null;
            BCurrentDept = null;

            _functionName = "";
            _chineseName = "";
            _menuId = -1;
            _mdiParent = null;
        }

        #region IDllInformation 成员

        #region 属性
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

        public RelationalDatabase Database
        {
            get
            {
                return BDatabase;
            }
            set
            {
                BDatabase = value;
            }
        }
        #endregion

        #region 函数
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            FrmCzgl frmCzgl;
            switch (_functionName)
            {
                case "Fun_ts_zy_czgl":
                case "Fun_ts_zy_czgl_all":
                case "Fun_ts_zy_czgl_cx":
                case "Fun_ts_zy_czgl_cx_all":
                case "Fun_ts_zy_czgl_sh":
                case "Fun_ts_zy_czgl_sh_all":
                    frmCzgl = new FrmCzgl(_functionName, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmCzgl.MdiParent = _mdiParent;
                    }
                    frmCzgl.Show();
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }
        }
        public TrasenClasses.GeneralClasses.ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[6];
            objectInfos[0].Name = "Fun_ts_zy_czgl";
            objectInfos[0].Text = "住院病人冲账确认";
            objectInfos[0].Remark = "住院病人冲账确认";
            objectInfos[1].Name = "Fun_ts_zy_czgl_all";
            objectInfos[1].Text = "住院病人冲账确认(全部)";
            objectInfos[1].Remark = "住院病人冲账确认(全部)";
            objectInfos[2].Name = "Fun_ts_zy_czgl_cx";
            objectInfos[2].Text = "住院病人冲账查询";
            objectInfos[2].Remark = "住院病人冲账查询";
            objectInfos[3].Name = "Fun_ts_zy_czgl_cx_all";
            objectInfos[3].Text = "住院病人冲账查询(全部)";
            objectInfos[3].Remark = "住院病人冲账查询(全部)";
            objectInfos[4].Name = "Fun_ts_zy_czgl_sh";
            objectInfos[4].Text = "住院病人冲账审核";
            objectInfos[4].Remark = "住院病人冲账审核";
            objectInfos[5].Name = "Fun_ts_zy_czgl_sh_all";
            objectInfos[5].Text = "住院病人冲账审核(全部)";
            objectInfos[5].Remark = "住院病人冲账审核(全部)";
            return objectInfos;

        }
        public TrasenClasses.GeneralClasses.ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "Ts_zy_czgl";
            objectInfo.Text = "住院病人冲账管理";
            objectInfo.Remark = "住院病人冲账管理";
            return objectInfo;
        }
        #endregion
        #endregion
    }
}
