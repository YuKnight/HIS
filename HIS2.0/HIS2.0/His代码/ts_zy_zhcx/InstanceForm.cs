using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_zy_zhcx
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

        //Modify by Kevin 2012-10-10
        private object[] _communicateValue;


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

            //_communicateValue[0] = "";
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

        //Modify by Kevin 2012-10-10
        public object[] communicateValue
        {
            get { return _communicateValue; }
            set { _communicateValue = value; }
        }
        #endregion

        #region 函数
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            FrmZybrzhcx frmZybrzhcx;
            switch (_functionName)
            {
                case "Fun_ts_zy_zhcx":
                    frmZybrzhcx = new FrmZybrzhcx(false);
                    if (_mdiParent != null)
                    {
                        frmZybrzhcx.MdiParent = _mdiParent;
                    }
                    frmZybrzhcx.Show();
                    break;
                case "Fun_ts_zy_zhcx_all":
                    frmZybrzhcx = new FrmZybrzhcx(true);
                    if (_mdiParent != null)
                    {
                        frmZybrzhcx.MdiParent = _mdiParent;
                    }
                    frmZybrzhcx.Show();
                    break;
                case "Fun_ts_zy_zhcx_all_OrdDetail":
                    frmZybrzhcx = new FrmZybrzhcx(true,true);
                    if (_mdiParent != null)
                    {
                        frmZybrzhcx.MdiParent = _mdiParent;
                    }
                    frmZybrzhcx.Show();
                    break;
                case "Fun_ts_zy_zhcx_bw":  //Modify by Kevin 2012-10-10 增加病危，病重引出函数                   
                    frmZybrzhcx = new FrmZybrzhcx(communicateValue);
                    if (_mdiParent != null)
                    {
                        frmZybrzhcx.MdiParent = _mdiParent;
                    }
                    frmZybrzhcx.Show();
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }
        }
        public TrasenClasses.GeneralClasses.ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[4];
            objectInfos[0].Name = "Fun_ts_zy_zhcx";
            objectInfos[0].Text = "住院病人综合查询";
            objectInfos[0].Remark = "住院病人综合查询";

            objectInfos[1].Name = "Fun_ts_zy_zhcx_all";
            objectInfos[1].Text = "住院病人综合查询(全部病区)";
            objectInfos[1].Remark = "住院病人综合查询(全部病区)";

            //Modify by Kevin 2012-10-10
            objectInfos[2].Name = "Fun_ts_zy_zhcx_bw";
            objectInfos[2].Text = "住院病人综合查询(病危,病重)";
            objectInfos[2].Remark = "住院病人综合查询(病危,病重)";



            objectInfos[3].Name = "Fun_ts_zy_zhcx_all_OrdDetail";
            objectInfos[3].Text = "住院医嘱查询(全部病区)";
            objectInfos[3].Remark = "住院医嘱查询(全部病区)";

            return objectInfos;

        }
        public TrasenClasses.GeneralClasses.ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "Ts_zy_zhcx";
            objectInfo.Text = "住院病人综合查询";
            objectInfo.Remark = "住院病人综合查询";
            return objectInfo;
        }
        #endregion
        #endregion
    }
}
