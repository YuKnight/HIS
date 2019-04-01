using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_yzgl
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
        private long _currentUserId;
        private long _currentDeptId;
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
            _currentUserId = -1;
            _currentDeptId = -1;
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
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            frmYZGL frmYzgl = null;
            FrmCzxx frmczxx = null;
            FrmCzhz frmczhz = null;
            string sSql = "";
            int nType = 0;
            Guid inpatientID = Guid.Empty;
            if (_communicateValue != null)
            {
                sSql = _communicateValue[0].ToString();
                nType = Convert.ToInt32(_communicateValue[1]);
            }
            switch (_functionName)
            {
                case "Fun_ts_zyhs_yzgl":
                    frmYzgl = new frmYZGL(_chineseName, 0);
                    if (_mdiParent != null)
                    {
                        frmYzgl.MdiParent = _mdiParent;
                    }
                    frmYzgl.Show();
                    break;
                case "Fun_ts_zyhs_yzgl_ssmz":
                case "Fun_ts_zyhs_yzgl_ssmz_noexe": //Add By Tany 2015-05-04 手麻引出一个不能发送的界面
                    frmYzgl = new frmYZGL(_chineseName, sSql, nType, _functionName);
                    if (_mdiParent != null)
                    {
                        frmYzgl.MdiParent = _mdiParent;
                    }
                    frmYzgl.Show();
                    break;
                case "Fun_ts_zyhs_yzgl_cx":
                    frmYzgl = new frmYZGL(_chineseName, true);
                    if (_mdiParent != null)
                    {
                        frmYzgl.MdiParent = _mdiParent;
                    }
                    frmYzgl.Show();
                    break;
                case "Fun_ts_zyhs_yzgl_tszl":
                    frmYzgl = new frmYZGL(_chineseName, 1);
                    if (_mdiParent != null)
                    {
                        frmYzgl.MdiParent = _mdiParent;
                    }
                    frmYzgl.Show();
                    break;
                case "Fun_ts_zyhs_yzgl_fycz"://静脉配置费用冲正
                    FrmPvsCostoffset FrmPvsCostoffset = new FrmPvsCostoffset();
                    if (_mdiParent != null)
                    {
                        FrmPvsCostoffset.MdiParent = _mdiParent;
                    }
                    if (BCurrentDept.DeptId == 598)
                    {
                        FrmPvsCostoffset.Show();
                        FrmPvsCostoffset.WindowState = FormWindowState.Maximized;
                    } 
                    break;
                case "Fun_ts_zyhs_yzgl_inpatient":
                    inpatientID = new Guid(_communicateValue[2].ToString());
                    frmYzgl = new frmYZGL(_chineseName, 1, inpatientID);
                    if (_mdiParent != null)
                    {
                        frmYzgl.MdiParent = _mdiParent;
                    }
                    frmYzgl.Show();
                    break;
                //add by zouchihua 2013-1-17 单病人查询
                case "Fun_ts_zyhs_yzgl_inpatient_cx":
                    inpatientID = new Guid(_communicateValue[2].ToString());
                    frmYzgl = new frmYZGL(_chineseName, 0, inpatientID, true);
                    if (_mdiParent != null)
                    {
                        frmYzgl.MdiParent = _mdiParent;
                        // frmYzgl.WindowState = FormWindowState.Maximized;
                    }
                    frmYzgl.Show();
                    frmYzgl.Activate();
                    break;
                case "Fun_ts_zyhs_czxxcx":
                    frmczxx = new FrmCzxx();
                    if (_mdiParent != null)
                    {
                        frmczxx.MdiParent = _mdiParent;
                    }
                    frmczxx.Show();
                    break;
                case "Fun_ts_zyhs_czxx_ypbcslyxx":
                    frmYzgl = new frmYZGL(_chineseName, 0, true);
                    if (_mdiParent != null)
                    {
                        frmYzgl.MdiParent = _mdiParent;
                    }
                    frmYzgl.Show();
                    break;
                case "Fun_ts_zyhs_czxx_hzcx":
                    frmczhz = new FrmCzhz();
                    if (_mdiParent != null)
                    {
                        frmczhz.MdiParent = _mdiParent;
                    }
                    frmczhz.Show();
                    break;
                case "Fun_ts_zyhs_qfzx":
                    FrmQFZX frmQFZX = new FrmQFZX();
                    if (_mdiParent != null)
                    {
                        frmQFZX.MdiParent = _mdiParent;
                    }
                    frmQFZX.Show();
                    break;
                case "Fun_ts_zyhs_PvsCancelScn":
                    FrmPvsCancelScn frmCcS = new FrmPvsCancelScn();
                    if (_mdiParent != null)
                    {
                        frmCcS.MdiParent = _mdiParent;
                    }
                    if (BCurrentDept.DeptId == 598)
                    {
                        frmCcS.Show();
                    }
                    break;
                case "Fun_ts_zyhs_Ybznsh":
                    FrmYbZnSh fymYbznsh = new FrmYbZnSh();
                    fymYbznsh.Show();
                    if (_mdiParent != null)
                    {
                        fymYbznsh.MdiParent = _mdiParent;
                    }
                    break;
                case "Fun_ts_zyhs_Ybznsh_hs":
                    FrmYbZnSh fymYbznshhs = new FrmYbZnSh(1);
                    fymYbznshhs.Show();
                    if (_mdiParent != null)
                    {
                        fymYbznshhs.MdiParent = _mdiParent;
                    }
                    break;
                case "Fun_ts_zyhs_Ybznsh_SC":
                    FrmYbZnSh fymYbznsh_SC = new FrmYbZnSh(true);
                    fymYbznsh_SC.Show();
                    if (_mdiParent != null)
                    {
                        fymYbznsh_SC.MdiParent = _mdiParent;
                    }
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
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
                return null;

            }
            frmYZGL frmYzgl = null;
            FrmCzxx frmczxx = null;
            string sSql = "";
            int nType = 0;
            Guid inpatientID = Guid.Empty;
            if (_communicateValue != null)
            {
                sSql = _communicateValue[0].ToString();
                nType = Convert.ToInt32(_communicateValue[1]);
            }
            Form frm = null;
            switch (_functionName)
            {

                //add by zouchihua 2013-1-17 单病人查询
                case "Fun_ts_zyhs_yzgl_inpatient_cx":
                    inpatientID = new Guid(_communicateValue[2].ToString());
                    frm = new frmYZGL(_chineseName, 0, inpatientID, true);
                    break;
            }
            return frm;


        }

        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_zyhs_yzgl";
            objectInfo.Text = "医嘱管理";
            objectInfo.Remark = "管理、查看病人医嘱及详细信息";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[14];
            objectInfos[0].Name = "Fun_ts_zyhs_yzgl";
            objectInfos[0].Text = "医嘱管理";
            objectInfos[0].Remark = "管理、查看病人医嘱及详细信息";
            objectInfos[1].Name = "Fun_ts_zyhs_yzgl_ssmz";
            objectInfos[1].Text = "医嘱管理";
            objectInfos[1].Remark = "管理、查看病人医嘱及详细信息";
            objectInfos[2].Name = "Fun_ts_zyhs_yzgl_cx";
            objectInfos[2].Text = "医嘱查询";
            objectInfos[2].Remark = "查看病人医嘱及详细信息";
            objectInfos[3].Name = "Fun_ts_zyhs_yzgl_tszl";
            objectInfos[3].Text = "医嘱查询(特殊治疗)";
            objectInfos[3].Remark = "查看特殊治疗病人医嘱及详细信息";
            objectInfos[4].Name = "Fun_ts_zyhs_yzgl_inpatient";
            objectInfos[4].Text = "医嘱查询(单病人)";
            objectInfos[4].Remark = "查看特殊治疗单病人医嘱及详细信息";

            objectInfos[5].Name = "Fun_ts_zyhs_czxxcx";
            objectInfos[5].Text = "冲正信息查询";
            objectInfos[5].Remark = "冲正信息查询";

            //add by zouchihua 2013-9-11  出区病人冲正（不产生领药信息）
            objectInfos[6].Name = "Fun_ts_zyhs_czxx_ypbcslyxx";
            objectInfos[6].Text = "出区病人冲正（不产生领药信息）";
            objectInfos[6].Remark = "出区病人冲正（不产生领药信息）";

            //add by zouchihua 2013-9-29 冲正汇总查询
            objectInfos[7].Name = "Fun_ts_zyhs_czxx_hzcx";
            objectInfos[7].Text = "冲正汇总查询";
            objectInfos[7].Remark = "冲正汇总查询";

            //add by yaokx 2-14-03-24  欠费病人停医嘱（长期医嘱和长期账单）预算>0不能执行，预算小于0通过执行
            objectInfos[8].Name = "Fun_ts_zyhs_qfzx";
            objectInfos[8].Text = "欠费病人医嘱执行";
            objectInfos[8].Remark = "欠费病人医嘱执行";

            objectInfos[9].Name = "Fun_ts_zyhs_PvsCancelScn";
            objectInfos[9].Text = "Pivas取消配药状态";
            objectInfos[9].Remark = "Pivas取消配药状态";

            objectInfos[10].Name = "Fun_ts_zyhs_Ybznsh";//默认医生站
            objectInfos[10].Text = "医保智能审核";
            objectInfos[10].Remark = "医保智能审核";

            objectInfos[11].Name = "Fun_ts_zyhs_Ybznsh_SC";
            objectInfos[11].Text = "医保智能审核_上传";
            objectInfos[11].Remark = "医保智能审核_上传";

            objectInfos[12].Name = "Fun_ts_zyhs_Ybznsh_hs";//护士站
            objectInfos[12].Text = "医保智能审核";
            objectInfos[12].Remark = "医保智能审核";

            objectInfos[13].Name = "Fun_ts_zyhs_yzgl_fycz";//护士站
            objectInfos[13].Text = "PIVAS配置费冲减";
            objectInfos[13].Remark = "PIVAS配置费冲减";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}