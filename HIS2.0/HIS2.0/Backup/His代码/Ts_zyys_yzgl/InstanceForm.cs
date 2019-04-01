using System;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace Ts_zyys_yzgl
{
    /// <summary>
    /// InstanceForm 的摘要说明。
    /// 该类是每个DLL供外界访问的接口函数类
    /// 名称不能改（包括大小写）
    /// </summary>
    public class InstanceForm : IInnerCommunicate
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
            switch (_functionName)
            {
                case "Fun_Ts_zyys_dlwh":
                    FrmYZDLList f = new FrmYZDLList();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    f.WindowState = FormWindowState.Maximized;
                    f.Show();
                    break;

                case "Fun_Ts_zyys_qxwh":
                    FrmScheme frm = new FrmScheme();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_qxmxwh":
                    FrmSchemeRelation frmMx = new FrmSchemeRelation();
                    if (_mdiParent != null)
                    {
                        frmMx.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frmMx.WindowState = FormWindowState.Maximized;
                    frmMx.Show();
                    break;

                case "Fun_Ts_zyys_qxmxwh_ks":
                    FrmSchemeRltDpt frmMxKs = new FrmSchemeRltDpt();
                    if (_mdiParent != null)
                    {
                        frmMxKs.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frmMxKs.WindowState = FormWindowState.Maximized;
                    frmMxKs.Show();
                    break;
                case "Fun_Ts_ksSpr":
                    FrmKsSpr fm = new FrmKsSpr();
                    if (_mdiParent != null)
                    {
                        fm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    fm.WindowState = FormWindowState.Maximized;
                    fm.Show();
                    break;
                case "Fun_Ts_SsYp":
                    FrmSsYp frmsy = new FrmSsYp();
                    if (_mdiParent != null)
                    {
                        frmsy.MdiParent = _mdiParent;
                    }
                    frmsy.WindowState = FormWindowState.Maximized;
                    frmsy.Show();
                    break;
                case "Fun_Ts_ksssh":
                    Frmksssh fmksh = new Frmksssh();
                    if (_mdiParent != null)
                    {
                        fmksh.MdiParent = _mdiParent;
                    }
                    fmksh.WindowState = FormWindowState.Maximized;
                    fmksh.Show();
                    break;
                case "Fun_Ts_zyys_kjwdy":
                    FrmKssSqbPrint frmKjw = new FrmKssSqbPrint();
                    if (_mdiParent != null)
                    {
                        frmKjw.MdiParent = _mdiParent;
                    }
                    frmKjw.WindowState = FormWindowState.Maximized;
                    frmKjw.Show();
                    break;
                case "Fun_Ts_zyys_tsksShr":
                    FrmSpecialKssChk frmTsksShr = new FrmSpecialKssChk();
                    if (_mdiParent != null)
                    {
                        frmTsksShr.MdiParent = _mdiParent;
                    }
                    frmTsksShr.WindowState = FormWindowState.Maximized;
                    frmTsksShr.Show();
                    break;
                case "Fun_Ts_zyys_tsksSh":
                    FrmSpecialKssChkSh frmTsksSh = new FrmSpecialKssChkSh();
                    if (_mdiParent != null)
                    {
                        frmTsksSh.MdiParent = _mdiParent;
                    }
                    frmTsksSh.WindowState = FormWindowState.Maximized;
                    frmTsksSh.Show();
                    break;
                case "Fun_Ts_zyys_KssYymd":
                    FrmKssDetailMemo fKssYymd = new FrmKssDetailMemo();
                    if (_mdiParent != null)
                    {
                        fKssYymd.MdiParent = _mdiParent;
                    }
                    fKssYymd.WindowState = FormWindowState.Maximized;
                    fKssYymd.Show();
                    break;
                case "Fun_Ts_zyys_QueryDisease":
                    FrmQueryDisease fDiseaseQuery = new FrmQueryDisease();
                    if (_mdiParent != null)
                    {
                        fDiseaseQuery.MdiParent = _mdiParent;
                    }
                    fDiseaseQuery.WindowState = FormWindowState.Maximized;
                    fDiseaseQuery.Show();
                    break;
                case "Fun_Ts_zyys_KssItem":
                    FrmKssItem fKssItem = new FrmKssItem();
                    if (_mdiParent != null)
                    {
                        fKssItem.MdiParent = _mdiParent;
                    }
                    fKssItem.WindowState = FormWindowState.Maximized;
                    fKssItem.Show();
                    break;
                case "Fun_Ts_zyys_H7N9":
                    FormDoctorH7N9Maintain fDoctorH7N9Maintain = new FormDoctorH7N9Maintain();
                    if (_mdiParent != null)
                    {
                        fDoctorH7N9Maintain.MdiParent = _mdiParent;
                    }
                    fDoctorH7N9Maintain.WindowState = FormWindowState.Maximized;
                    fDoctorH7N9Maintain.Show();
                    break;  
            }
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
            FrmYZGL frmyzgl = null;
            Form f=null;
            string _hszd = "";
            string sSql;
            switch (_functionName)
            {
                case "Fun_Ts_zyys_yzgl":   //医生工作站医嘱函数
                    if (_communicateValue != null)
                    {
                        frmyzgl = new FrmYZGL(_currentUser.UserID, _currentDept.DeptId, _chineseName, _communicateValue);
                    }
                    if (_mdiParent != null)
                    {
                        frmyzgl.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    break;

                case "Fun_Ts_zyys_hszd":   //护士账单医嘱函数
                    if (_communicateValue != null)
                    {
                        frmyzgl = new FrmYZGL(_currentUser.UserID, _currentDept.DeptId, _chineseName, _functionName, _hszd, _communicateValue);
                    }
                    if (_mdiParent != null)
                    {
                        frmyzgl.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    break;

                case "Fun_Ts_zyys_hsyz":   //护士医嘱函数(长期、临时医嘱，长期、临时账单)
                    if (_communicateValue != null)
                    {
                        frmyzgl = new FrmYZGL(_currentUser.UserID, _currentDept.DeptId, _communicateValue);
                    }
                    if (_mdiParent != null)
                    {
                        frmyzgl.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    break;

                case "Fun_Ts_zyys_mzyz":    //手术麻醉医嘱函数
                    if (_communicateValue != null)
                    {
                        sSql = _communicateValue[7].ToString();
                        frmyzgl = new FrmYZGL(_currentUser.UserID, _currentDept.DeptId, _chineseName, sSql, _communicateValue);
                    }
                    break;
                case "Fun_Ts_zyys_dlwh":
                    f = new FrmYZDLList();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    return f;
                    break;
                case "Fun_Ts_ksssh":
                    f = new Frmksssh();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                    }
                    break;
                case "Fun_Ts_SsYp":
                    f = new FrmSsYp();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                    }
                    break;
                case "Fun_Ts_zyys_H7N9":
                    f = new FormDoctorH7N9Maintain();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                    }
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }
            return frmyzgl;
        }
        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "Ts_zyys_yzgl";
            objectInfo.Text = "医嘱管理";
            objectInfo.Remark = "医嘱管理";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            
            ObjectInfo[] objectInfos = new ObjectInfo[18];

            objectInfos[0].Name = "Fun_Ts_zyys_yzgl";
            objectInfos[0].Text = "医嘱管理";
            objectInfos[0].Remark = "医嘱管理";
            objectInfos[1].Name = "Fun_Ts_zyys_mzyz";
            objectInfos[1].Text = "医嘱录入";
            objectInfos[1].Remark = "医嘱录入";
            objectInfos[2].Name = "Fun_Ts_zyys_hsyz";
            objectInfos[2].Text = "护士医嘱";
            objectInfos[2].Remark = "护士医嘱";
            objectInfos[3].Name = "Fun_Ts_zyys_hszd";
            objectInfos[3].Text = "护士账单";
            objectInfos[3].Remark = "护士账单";

            objectInfos[4].Name = "Fun_Ts_zyys_dlwh";
            objectInfos[4].Text = "医嘱滴量维护";
            objectInfos[4].Remark = "医嘱滴量维护";

            objectInfos[5].Name = "Fun_Ts_zyys_qxwh";
            objectInfos[5].Text = "医嘱权限维护";
            objectInfos[5].Remark = "医嘱权限维护";

            objectInfos[6].Name = "Fun_Ts_zyys_qxmxwh";
            objectInfos[6].Text = "医嘱权限明细维护";
            objectInfos[6].Remark = "医嘱权限明细维护";

            objectInfos[7].Name = "Fun_Ts_zyys_qxmxwh_ks";
            objectInfos[7].Text = "医嘱开立权限控制";
            objectInfos[7].Remark = "医嘱开立权限控制";

            objectInfos[8].Name = "Fun_Ts_ksSpr";
            objectInfos[8].Text = "科室审核人管理";
            objectInfos[8].Remark = "科室审核人管理";

            objectInfos[9].Name = "Fun_Ts_ksssh";
            objectInfos[9].Text = "限制级抗菌药物审核";
            objectInfos[9].Remark = "限制级抗菌药物审核";

            objectInfos[10].Name = "Fun_Ts_zyys_kjwdy";
            objectInfos[10].Text = "特殊抗菌物打印";
            objectInfos[10].Remark = "特殊抗菌物打印";

            objectInfos[11].Name = "Fun_Ts_SsYp";
            objectInfos[11].Text = "手术药品管理";
            objectInfos[11].Remark = "手术药品管理";

            objectInfos[12].Name = "Fun_Ts_zyys_tsksShr";
            objectInfos[12].Text = "特殊级抗菌药物维护人员";
            objectInfos[12].Remark = "特殊级抗菌药物维护人员";

            objectInfos[13].Name = "Fun_Ts_zyys_tsksSh";
            objectInfos[13].Text = "特殊级抗菌药物审核";
            objectInfos[13].Remark = "特殊级抗菌药物审核";

            objectInfos[14].Name = "Fun_Ts_zyys_KssYymd";
            objectInfos[14].Text = "用药目的维护";
            objectInfos[14].Remark = "用药目的维护";

            objectInfos[15].Name = "Fun_Ts_zyys_QueryDisease";
            objectInfos[15].Text = "诊断查询";
            objectInfos[15].Remark = "诊断查询";

            objectInfos[16].Name = "Fun_Ts_zyys_KssItem";
            objectInfos[16].Text = "切口等级对应抗生素";
            objectInfos[16].Remark = "切口等级对应抗生素";

            objectInfos[17].Name = "Fun_Ts_zyys_H7N9";
            objectInfos[17].Text = "H7N9开单权限控制";
            objectInfos[17].Remark = "H7N9开单权限控制";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
