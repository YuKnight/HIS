using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes; 

namespace ts_mz_rizhi
{
    /// <summary>
    /// InstanceForm 的摘要说明。
    /// 该类是每个DLL供外界访问的接口函数类
    /// 名称不能改（包括大小写）
    /// </summary>
    public class InstanceForm : IInnerCommunicate
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
        private object[] _communicateValue;
        public InstanceForm()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
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
                Trasen.DbAcc.InstanceBaseForm.BDatabase = BDatabase;
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
            GetObject();
        }
        /// <summary>
        /// 返回一个FORM对象
        /// </summary>
        /// <returns></returns>
        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            MZ_RZ yymzrz = new MZ_RZ();
            string strBlh = "";
            if (_communicateValue != null)
            {
                strBlh = _communicateValue[0].ToString();
            }

            switch (_functionName)
            {
                case "Fun_mz_rizhi":  
                    MZ_RZNew yymzrznew = new MZ_RZNew(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        yymzrznew.MdiParent = _mdiParent;
                    }
                    //YYMZRZ = new MZ_RZ(_menuTag, _chineseName, _mdiParent);
                    yymzrznew.Show();
                    yymzrznew.WindowState = FormWindowState.Maximized;
                    break; 
                    
                case "Fun_mz_rz_one":
                    //strBlh = "2012092110125";
                    yymzrz = new MZ_RZ(this._chineseName, _menuTag, strBlh);
                    yymzrz.Show();
                    break;
                case "Fun_FrmMzrzCx":
                    FrmMzrzCx yymzrzcx = new FrmMzrzCx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        yymzrzcx.MdiParent = _mdiParent;
                    }
                    yymzrzcx.StartPosition = FormStartPosition.CenterScreen;
                    yymzrzcx.Show();
                    break;
                case "Fun_FrmPWS":
                    FrmPatientWaitingSituation frm_pws = new FrmPatientWaitingSituation(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_pws.MdiParent = _mdiParent;
                    }
                    frm_pws.StartPosition = FormStartPosition.CenterScreen;
                    frm_pws.Show();
                    break;

                default:
                    throw new Exception("引出函数名称错误！");
            }

            return yymzrz;


        }

        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo info;
            info.Name = "ts_mz_rizhi";
            info.Text = "门诊日志";
            info.Remark = "";
            return info;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
    
            ObjectInfo[] infoArray = new ObjectInfo[4];
            infoArray[0].Name = "Fun_mz_rizhi";
            infoArray[0].Text = "门急诊日志";
            infoArray[0].Remark = "";
            infoArray[1].Name = "Fun_mz_rz_one";
            infoArray[1].Text = "门急诊日志单个输入";
            infoArray[1].Remark = "";
            infoArray[2].Name = "Fun_FrmMzrzCx";
            infoArray[2].Text = "门急诊日志补录查询";
            infoArray[2].Remark = "";
            infoArray[3].Name = "Fun_FrmPWS";
            infoArray[3].Text = "门诊病人候诊情况查询";
            infoArray[3].Remark = "";
            return infoArray;

        }
        #endregion

        #endregion
    }
}


