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



namespace ts_mzys_yjsqd			//★修改为约定的命名空间
{
    /// <summary>
    /// InstanceBForm 的摘要说明
    /// 实例化业务窗体
    /// </summary>
    public class InstanceForm : IDllInformation, IInnerCommunicate
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
  
            switch (_functionName)
            {
                case "Fun_ts_mzys_yjsqd_jcsq":
                    //Frmjcsqd Frmjcsqd = new Frmjcsqd(_menuTag, _chineseName, _mdiParent);
                    //if (_mdiParent != null)
                    //{
                    //    Frmjcsqd.MdiParent = _mdiParent;
                    //}
                    //Frmjcsqd.Show();
                    Ts_zyys_jcsq.FrmJCSQ frmjcsq = new Ts_zyys_jcsq.FrmJCSQ(BCurrentUser.UserID, BCurrentDept.DeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmjcsq.MdiParent = _mdiParent;
                    }
                    frmjcsq.BringToFront();
                    frmjcsq.ShowDialog();
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }

        }

        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            Form f = null;
            switch (_functionName)
            {
                case "Fun_ts_mzys_yjsqd_jcsq":
                    //Frmjcsqd ff = new Frmjcsqd(_menuTag, _chineseName, _mdiParent);
                    //ff.Dqcf.brxxid = new Guid(CommunicateValue[0].ToString());
                    //ff.Dqcf.ghxxid = new Guid(CommunicateValue[1].ToString());
                    //ff.Dqcf.jzid = new Guid(CommunicateValue[2].ToString());
                    //ff.Dqcf.brxm = Convert.ToString(CommunicateValue[3]);
                    //ff.Dqcf.xb = Convert.ToString(CommunicateValue[4]);
                    //ff.Dqcf.nl = Convert.ToString(CommunicateValue[5]);
                    //ff.Dqcf.tz = Convert.ToString(CommunicateValue[6]);
                    //ff.Dqcf.gzdw = Convert.ToString(CommunicateValue[7]);
                    //ff.Dqcf.lxfs = Convert.ToString(CommunicateValue[8]);
                    //ff.Dqcf.mzh = Convert.ToString(CommunicateValue[9]);
                    //ff.Dqcf.yjsqid = new Guid(CommunicateValue[10].ToString());
                    //ff.Dqcf.yzid = new Guid(CommunicateValue[11].ToString());
                    //ff.txtzd.Text = CommunicateValue[12].ToString();
                    Ts_zyys_jcsq.FrmJCSQ ff = new Ts_zyys_jcsq.FrmJCSQ(BCurrentUser.UserID, BCurrentDept.DeptId, _chineseName);
                    ff.Dqcf.brxxid = new Guid(CommunicateValue[0].ToString());
                    ff.Dqcf.ghxxid = new Guid(CommunicateValue[1].ToString());
                    ff.Dqcf.jzid = new Guid(CommunicateValue[2].ToString());
                    ff.Dqcf.brxm = Convert.ToString(CommunicateValue[3]);
                    ff.Dqcf.xb = Convert.ToString(CommunicateValue[4]);
                    ff.Dqcf.nl = Convert.ToString(CommunicateValue[5]);
                    ff.Dqcf.tz = Convert.ToString(CommunicateValue[6]);
                    ff.Dqcf.gzdw = Convert.ToString(CommunicateValue[7]);
                    ff.Dqcf.lxfs = Convert.ToString(CommunicateValue[8]);
                    ff.Dqcf.mzh = Convert.ToString(CommunicateValue[9]);
                    ff.Dqcf.yjsqid = new Guid(CommunicateValue[10].ToString());
                    ff.Dqcf.yzid = new Guid(CommunicateValue[11].ToString());
                    ff.txtDiag.Text = CommunicateValue[12].ToString();
                    ff.BrLy = Ts_zyys_jcsq.Typely.门诊;
                    ff.lg = 1;
                    try
                    {
                        //add by zouchihua 2014-9-30 在划价的时候，必须要传入申请科室，和医生，不能取当前科室
                        ff.sqks = Convert.ToInt32( CommunicateValue[13].ToString() );
                        ff.sqys = Convert.ToInt32( CommunicateValue[14].ToString() );
                    }
                    catch
                    {
                    }
                    string sql = @"select sqnr as 名称,yzxmid as 医嘱项目id,dj as 单价,sl as 数量,dw as 单位,je as 金额 ,tcid as 套餐id,pcmc as  频次
                                ,a.ZXKS execDept,dbo.fun_getDeptname(a.ZXKS) AS 执行科室,a.BBMC as 标本,f.JCLXID as JcxmId,c.NAME AS 项目分类
                                FROM YJ_MZSQ a inner join  jc_hoi_hdi b  on a.YZXMID=b.HOITEM_ID
                                INNER JOIN JC_JC_ITEM f ON f.YZID=b.HOITEM_ID
                                LEFT JOIN JC_JCCLASSDICTION c ON f.JCLXID=c.ID
                                where a.YJSQID = '" + ff.Dqcf.yjsqid.ToString() + "'";
                    ff.tbxg = InstanceForm.BDatabase.GetDataTable(sql);
                    if (ff.tbxg.Rows.Count > 0)
                    {
                        ff.Xg = true;
                    }
                    DataTable tab1 = ts_mzys_class.mzys_yjsq.Select_E(ff.Dqcf.yjsqid, InstanceForm.BDatabase);
                    if (tab1.Rows.Count == 1)
                    {
                        ff.richRecord.Text = tab1.Rows[0]["bsjc"].ToString();
                        ff.txtDiag.Text = tab1.Rows[0]["lczd"].ToString();
                    }
                    //ff.txtzd.Text = CommunicateValue[12].ToString();
                    if (_mdiParent != null)
                    {
                        ff.MdiParent = _mdiParent;
                    }
                    f = ff;
                    break;
                case "Fun_ts_mzys_yjsqd_hysq":
                    Frmhysqd ff1 = new Frmhysqd(_menuTag, _chineseName, _mdiParent);
                    ff1.Dqcf.brxxid = new Guid(CommunicateValue[0].ToString());
                    ff1.Dqcf.ghxxid = new Guid(CommunicateValue[1].ToString());
                    ff1.Dqcf.jzid = new Guid(CommunicateValue[2].ToString());
                    ff1.Dqcf.brxm = Convert.ToString(CommunicateValue[3]);
                    ff1.Dqcf.xb = Convert.ToString(CommunicateValue[4]);
                    ff1.Dqcf.nl = Convert.ToString(CommunicateValue[5]);
                    ff1.Dqcf.tz = Convert.ToString(CommunicateValue[6]);
                    ff1.Dqcf.gzdw = Convert.ToString(CommunicateValue[7]);
                    ff1.Dqcf.lxfs = Convert.ToString(CommunicateValue[8]);
                    ff1.Dqcf.mzh = Convert.ToString(CommunicateValue[9]);
                    ff1.Dqcf.yjsqid = new Guid(CommunicateValue[10].ToString());
                    ff1.Dqcf.yzid = new Guid(CommunicateValue[11].ToString());
                    ff1.txtzd.Text = CommunicateValue[12].ToString();
                    ff1.Dqcf.sqks = 0;
                    ff1.Dqcf.sqys = 0;
                    try {
                        //add by zouchihua 2014-9-30 在划价的时候，必须要传入申请科室，和医生，不能取当前科室
                        ff1.Dqcf.sqks =Convert.ToInt32( CommunicateValue[13].ToString());
                        ff1.Dqcf.sqys = Convert.ToInt32(CommunicateValue[14].ToString());
                    }
                    catch { }
                    if (_mdiParent != null)
                    {
                        ff1.MdiParent = _mdiParent;
                    }
                    f = ff1;
                    break;
                case "Fun_ts_mzys_yjsqd_wtsq":
                    Frmwt ff2 = new Frmwt(_menuTag, _chineseName, _mdiParent);
                    ff2.Dqcf.brxxid = new Guid(CommunicateValue[0].ToString());
                    ff2.Dqcf.ghxxid = new Guid(CommunicateValue[1].ToString());
                    ff2.Dqcf.jzid = new Guid(CommunicateValue[2].ToString());
                    ff2.Dqcf.brxm = Convert.ToString(CommunicateValue[3]);
                    ff2.Dqcf.xb = Convert.ToString(CommunicateValue[4]);
                    ff2.Dqcf.nl = Convert.ToString(CommunicateValue[5]);
                    ff2.Dqcf.tz = Convert.ToString(CommunicateValue[6]);
                    ff2.Dqcf.gzdw = Convert.ToString(CommunicateValue[7]);
                    ff2.Dqcf.lxfs = Convert.ToString(CommunicateValue[8]);
                    ff2.Dqcf.mzh = Convert.ToString(CommunicateValue[9]);
                    ff2.Dqcf.yjsqid = new Guid(CommunicateValue[10].ToString());
                    ff2.Dqcf.yzid = new Guid(CommunicateValue[11].ToString());
                    if (_mdiParent != null)
                    {
                        ff2.MdiParent = _mdiParent;
                    }
                    f = ff2;
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }
            return f;
        }

        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mzys_yjsqd";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "医技申请单据";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[1];
            objectInfos[0].Name = "Fun_ts_mzys_yjsqd_jcsq";
            objectInfos[0].Text = "检查申请单";
            objectInfos[0].Remark = "";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
