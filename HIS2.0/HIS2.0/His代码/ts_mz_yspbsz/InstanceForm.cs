using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_yspbsz
{
    //InstanceForm 的摘要说明：该类是每个DLL供外界访问的接口函数类，名称不能改（包括大小写）
    public class InstanceForm : IDllInformation
    {
        //公共静态变量
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        private Form _mdiParent;
        public static MenuTag _menuTag;
        private long _menuId;
        private string _functionName;
        private string _chineseName;
        private object[] _communicateValue;

        public InstanceForm()
        {
            //在此处添加构造函数逻辑
            BDatabase = null;
            BCurrentUser = null;
            BCurrentDept = null;

            _functionName = "";
            _chineseName = "";
            _menuId = -1;
            _mdiParent = null;
        }

        #region IInnerCommunicate 成员(一定要在此实现)

        #region 属性
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

        //实例化窗体函数名称
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

        //窗体中文名称
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

        //当前操作员ID
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

        //当前操作科室ID
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

        //菜单ID
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

        //内部通信参数
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
        //根据函数名称实例化窗体
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }

            switch (_functionName)
            {
                case "Fun_ts_mz_yspb_flsz":
                    Frm_yspb_flsz frm = new Frm_yspb_flsz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.WindowState = FormWindowState.Maximized;

                    frm.Show();
                    break;
                case "Fun_ts_mz_yspb_ksflmx":
                    Frm_yspb_ksflmx frm_mx = new Frm_yspb_ksflmx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_mx.MdiParent = _mdiParent;
                    }
                    frm_mx.WindowState = FormWindowState.Maximized;
                    frm_mx.Show();
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }

        }

        //返回一个FORM对象
        public object GetObject()
        {
            return null;
        }

        //获得该Dll的信息
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mz_yspbsz";
            objectInfo.Text = "门诊医生排班设置";
            objectInfo.Remark = "门诊医生排班设置";
            return objectInfo;
        }

        /// 获得该Dll所有引出函数信息
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[2];
            objectInfos[0].Name = "Fun_ts_mz_yspb_flsz";
            objectInfos[0].Text = "门诊排班分类设置";
            objectInfos[0].Remark = "门诊排班分类设置";
            objectInfos[1].Name = "Fun_ts_mz_yspb_ksflmx";
            objectInfos[1].Text = "门诊排班科室分类明细";
            objectInfos[1].Remark = "门诊排班科室分类明细";

            return objectInfos;
        }
        #endregion

        #endregion

    }
}
