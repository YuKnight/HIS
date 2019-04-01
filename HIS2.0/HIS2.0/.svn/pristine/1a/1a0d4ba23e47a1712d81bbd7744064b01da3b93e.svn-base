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

namespace ts_mzys_blcflr	//★修改为约定的命名空间
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

        public static MenuTag _menuTag;
        public static string _functionName;
        public static string _chineseName;
        public static long _menuId;
        public static Form _mdiParent;
        public static object[] _communicateValue;
        public static bool IsSfy;
     
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
                case "Fun_ts_mzys_blcflr":
                case "Fun_ts_mzys_blcflr_grmb":
                case "Fun_ts_mzys_blcflr_kjmb":
                case "Fun_ts_mzys_blcflr_yjmb":
                case "Fun_ts_mzys_blcflr_xdcf_yj":
                case "Fun_ts_mzys_blcflr_xdcf_kj":
                case "Fun_ts_zyys_blcflr":
                    DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    //验证科室是否需要分诊
                    string ssql = "select * from MZYS_FZKS where ksdm=" + InstanceForm.BCurrentDept.DeptId + "";
                    bool IsSelect_Room = IsSelectRoom(djsj);
                    DataTable tbks = InstanceForm.BDatabase.GetDataTable(ssql);
                    if ( tbks.Rows.Count == 0 || ( !IsSelect_Room ) || ( _functionName != "Fun_ts_zyys_blcflr" && _functionName != "Fun_ts_mzys_blcflr" ) )
                    {
                        Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, 0);
                        if (_mdiParent != null)
                        {
                            Frmhjsf.MdiParent = _mdiParent;
                        }
                        Frmhjsf.Show();
                        return;
                    }
                    //如果需要分诊
                    SystemCfg cg = new SystemCfg(3001);
                    ssql = "select * from jc_zjsz where wkdz='" + PubStaticFun.GetMacAddress() + "'";
                    DataTable tbjz = InstanceForm.BDatabase.GetDataTable(ssql);
                    //判断是否启用分时段叫号系统 如果未启用则用老的选择诊室模式 Modify By zp 2013-06-18
                    if (new SystemCfg(3070).Config == "1")
                    {
                        #region 未用新分诊系统 则用老的模式选择诊室
                        if (tbjz.Rows.Count == 1)
                        {
                            if (Convert.ToInt16(cg.Config) == 0)
                                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ", wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                            else
                                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' , ksdm=" + InstanceForm.BCurrentDept.DeptId + " where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                            InstanceForm.BDatabase.DoCommand(ssql);

                            Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, Convert.ToInt32(tbjz.Rows[0]["zjid"]));
                            if (_mdiParent != null)
                            {
                                Frmhjsf.MdiParent = _mdiParent;
                            }
                            Frmhjsf.Show();
                            break;
                        }
                        else
                        {
                            Frmzjqr f = new Frmzjqr(_menuTag, _chineseName, _mdiParent);
                            f.ShowDialog();
                            break;
                        }
                        #endregion
                    }
                    else
                    {
                        #region 启用新分诊系统
                        if (tbjz.Rows.Count == 1 && int.Parse(Convertor.IsNull(tbjz.Rows[0]["ZZYS"], "-1")) == InstanceForm.BCurrentUser.EmployeeId
                           && int.Parse(Convertor.IsNull(tbjz.Rows[0]["KSDM"], "-1")) == InstanceForm.BCurrentDept.DeptId)  //得到结果后需要判断诊室记录的科室代码和医生代码与当前坐诊科室、坐诊医生是否一致
                        {
                            if (Convert.ToInt16(cg.Config) == 0)
                                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ", wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                            else
                                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' , ksdm=" + InstanceForm.BCurrentDept.DeptId + " where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                            InstanceForm.BDatabase.DoCommand(ssql);

                            Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, Convert.ToInt32(tbjz.Rows[0]["zjid"]));
                            if (_mdiParent != null)
                            {
                                Frmhjsf.MdiParent = _mdiParent;
                            }
                            Frmhjsf.Show();
                            break;
                        }
                        else  //通过参数3065决定诊室选择模式
                        {
                            DataTable dt = BindRoom();
                            Frmzjqr f = new Frmzjqr(_menuTag, _chineseName, _mdiParent, dt);
                            f.ShowDialog();
                            break;
                        }
                        #endregion
                    }
                #region 注释代码 Modify By zp 2013-07-09
                //if (tbjz.Rows.Count == 1)
                    //{
                    //    if (Convert.ToInt16(cg.Config) == 0)
                    //        ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ", wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                    //    else
                    //        ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' , ksdm=" + InstanceForm.BCurrentDept.DeptId + " where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                    //    InstanceForm.BDatabase.DoCommand(ssql);

                    //    Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, Convert.ToInt32(tbjz.Rows[0]["zjid"]));
                    //    if (_mdiParent != null)
                    //    {
                    //        Frmhjsf.MdiParent = _mdiParent;
                    //    }
                    //    Frmhjsf.Show();
                    //    break;
                    //}
                    //else
                    //{
                    //    Frmzjqr f = new Frmzjqr(_menuTag, _chineseName, _mdiParent);
                    //    f.ShowDialog();
                    //    break;
                //}
                #endregion
                case "Fun_ts_mzys_jzlscx":
                case "Fun_ts_mzys_jzlscx_all":
                    Frmjzlscx Frmjzlscx = new Frmjzlscx(_menuTag, _chineseName, _mdiParent);

                    if (_mdiParent != null)
                    {
                        Frmjzlscx.MdiParent = _mdiParent;
                    }
                    Frmjzlscx.Show();
                    break;
                case "Fun_ts_mzys_blcflr_wtsq":
                    Frmwtsqcx Frmwtsqcx = new Frmwtsqcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmwtsqcx.MdiParent = _mdiParent;
                    }
                    Frmwtsqcx.Show();
                    break;
                case "Fun_ts_mzys_zymbwh":
                    FrmZyMbWh frmzymbwh = new FrmZyMbWh(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmzymbwh.MdiParent = _mdiParent;
                    }
                    frmzymbwh.Show();
                    break;
                case "Fun_ts_mztfsh":
                case "Fun_ts_mztfsq_ys"://add by zouchihua 2014-9-14 医生申请也可以挂菜单
                    Frm_TF_Apply frm_tfsq = new Frm_TF_Apply(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_tfsq.MdiParent = _mdiParent;
                    } 
                    frm_tfsq.Show();
                    break;
                case "Fun_ts_mztfsq_hj"://add by zouchihua 2014-9-14 如果是划价的话，也可以挂菜单
                    Frm_TF_Apply frm_tfsq1 = new Frm_TF_Apply(_menuTag, _chineseName, _mdiParent);
                      frm_tfsq1.Show();
                    break;
                case "Fun_ts_mzys_yyjbsh":
                    用药级别审核 Frmyyjbsh = new 用药级别审核(_menuTag, _chineseName, _mdiParent);

                    if (_mdiParent != null)
                    {
                        Frmyyjbsh.MdiParent = _mdiParent;
                    }
                    Frmyyjbsh.Show();
                    break;
                case "Fun_ts_zyzCx":
                    frmZyzCx frmActon = new frmZyzCx();
                    if (frmActon != null)
                    {
                        frmActon.MdiParent = _mdiParent;
                    }
                    frmActon.Show();
                    frmActon.WindowState = FormWindowState.Maximized;
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
                case "Fun_ts_mzys_blcflr_lscx":
                    Frmblcf_cx Frmblcf_cx = new Frmblcf_cx(_menuTag, _chineseName, _mdiParent, new Guid(CommunicateValue[0].ToString()), Guid.Empty);

                    if (_mdiParent != null)
                    {
                        Frmblcf_cx.MdiParent = _mdiParent;
                    }
                    //Frmblcf_cx.Show();
                    f = Frmblcf_cx;
                    break;
                case "Fun_ts_mzys_blcflr_zyz":
                    Frmzyz Frmzyz = new Frmzyz(_menuTag, _chineseName, _mdiParent, new Guid(CommunicateValue[0].ToString()), Convert.ToInt32(CommunicateValue[1]));
                    f = Frmzyz;
                    break;
                case "Fun_ts_mztfsh":
                case "Fun_ts_mztfsq_ys"://add by zouchihua 2014-9-14 医生申请也可以挂菜单
                    Frm_TF_Apply frm_tfsq = new Frm_TF_Apply(_menuTag, _chineseName, _mdiParent);
                    f = frm_tfsq;
                    break;
                case "Fun_ts_mztfsq_hj"://add by zouchihua 2014-9-14 如果是划价的话，也可以挂菜单
                    Frm_TF_Apply frm_tfsq1 = new Frm_TF_Apply(_menuTag, _chineseName, _mdiParent);
                    f = frm_tfsq1;
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
            objectInfo.Name = "ts_mzys_blcflr";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "病历处方";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[17];
            objectInfos[0].Name = "Fun_ts_mzys_blcflr";
            objectInfos[0].Text = "病历处方";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_mzys_jzlscx";
            objectInfos[1].Text = "病人就诊历史查询";
            objectInfos[1].Remark = "仅查询当前医生登陆科室的接诊历史";
            objectInfos[2].Name = "Fun_ts_mzys_jzlscx_all";
            objectInfos[2].Text = "病人就诊历史查询";
            objectInfos[2].Remark = "查询所有医生接诊历史";
            objectInfos[3].Name = "Fun_ts_mzys_blcflr_grmb";
            objectInfos[3].Text = "个人模板维护";
            objectInfos[3].Remark = "个人模板维护";
            objectInfos[4].Name = "Fun_ts_mzys_blcflr_kjmb";
            objectInfos[4].Text = "科级模板维护";
            objectInfos[4].Remark = "院级模板维护";
            objectInfos[5].Name = "Fun_ts_mzys_blcflr_yjmb";
            objectInfos[5].Text = "院级模板维护";
            objectInfos[5].Remark = "院级模板维护";
            objectInfos[6].Name = "Fun_ts_mzys_blcflr_zyzdj";
            objectInfos[6].Text = "住院证登记";
            objectInfos[6].Remark = "住院证登记";
            objectInfos[7].Name = "Fun_ts_mzys_blcflr_wtsq";
            objectInfos[7].Text = "委托申请";
            objectInfos[7].Remark = "委托申请";
            objectInfos[8].Name = "Fun_ts_zyys_blcflr";
            objectInfos[8].Text = "住院医生门诊处方录入";
            objectInfos[8].Remark = "住院医生门诊处方录入";
            objectInfos[9].Name = "Fun_ts_mzys_zymbwh";
            objectInfos[9].Text = "处方备注模板维护";
            objectInfos[9].Remark = "处方备注模板维护";
            //Add By zp 2014-02-07
            objectInfos[10].Name = "Fun_ts_mztfsh";
            objectInfos[10].Text = "门诊退费审核";
            objectInfos[10].Remark = "门诊退费审核";//Fun_ts_mzys_yyjbsh

            objectInfos[11].Name = "Fun_ts_mzys_yyjbsh";
            objectInfos[11].Text = "用药级别审核";
            objectInfos[11].Remark = "用药级别审核";

            objectInfos[12].Name = "Fun_ts_zyzCx";
            objectInfos[12].Text = "住院证查询";
            objectInfos[12].Remark = "住院证查询";

            //add by zouchihua 医生退费申请可以挂菜单，由本科室医生进行申请 2014-9-14
            objectInfos[13].Name = "Fun_ts_mztfsq_ys";
            objectInfos[13].Text = "门诊退费申请";
            objectInfos[13].Remark = "门诊退费申请";//Fun_ts_mzys_yyjbsh

            //add by zouchihua 医生退费申请可以挂菜单，由本科室医生进行申请 2014-9-14
            objectInfos[14].Name = "Fun_ts_mztfsq_hj";
            objectInfos[14].Text = "门诊退费申请(划价)";
            objectInfos[14].Remark = "门诊退费申请(划价)";//Fun_ts_mzys_yyjbsh

            objectInfos[15].Name = "Fun_ts_mzys_blcflr_xdcf_yj";
            objectInfos[15].Text = "院级协定处方维护";
            objectInfos[15].Remark = "院级协定处方维护";

            objectInfos[16].Name = "Fun_ts_mzys_blcflr_xdcf_kj";
            objectInfos[16].Text = "科级协定处方维护";
            objectInfos[16].Remark = "科级协定处方维护";
            return objectInfos;
        }
        #endregion

        /// <summary>
        /// 绑定诊室 add by zp 2013-06
        /// </summary>
        private DataTable BindRoom()
        {
            DataTable tb = new DataTable();
            try
            {
                SystemCfg _cfg3065 = new SystemCfg(3065);//医生选择诊室模式1通过科室+排班级别 2通过IP获取诊室 
                string sql = "";
                if (_cfg3065.Config == "1")
                {
                    int time = 1; //上下午 1上午2下午
                    DateTime date_Now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    if (date_Now.Hour > 12)
                    {
                        time = 2;
                    }
                    sql = @"SELECT A.ZJID,A.ZJMC,A.bz,A.KSDM FROM JC_ZJSZ AS A
                            INNER JOIN JC_FZ_ZQ AS B ON A.ZQID=B.ZQ_ID
                            INNER JOIN JC_FZ_ZQ_DEPT AS C ON A.KSDM=C.DEPT_ID
                            INNER JOIN JC_MZ_YSPB AS D ON D.PBKSID=A.KSDM
                            INNER JOIN JC_FZ_KSDYJB AS E ON E.GHJB=D.ZZJBID
                            WHERE D.YSID=" + InstanceForm.BCurrentUser.EmployeeId + @" 
                            AND CONVERT(VARCHAR(10),PBSJ,120)= CONVERT(VARCHAR(10),GETDATE(),120) 
                            AND D.PBLX=" + time + @"
                            GROUP BY A.ZJMC,A.bz,A.ZJID,A.KSDM";
                }
                else  //通过IP获取指定的诊室
                {
                    ts_mzys_class.Fz_Zq zq = new ts_mzys_class.Fz_Zq();
                    string ip = zq.GetLoacalHostIP();
                    sql = @"SELECT A.ZJID,A.ZJMC,A.bz ,a.ksdm FROM JC_ZJSZ a WHERE TXIP='" + ip + "'";
                }
                tb = InstanceForm.BDatabase.GetDataTable(sql);

            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message);
            }
            return tb;
        }

        /// <summary>
        /// 是否需要选择诊间 true需要选 false不需要选 Add by zp 2014-08-22
        /// </summary>
        /// <returns></returns>
        private bool IsSelectRoom(DateTime _date)
        {
            try
            {
                SystemCfg _cfg3142 = new SystemCfg(3142);
                if (_cfg3142.Config.Trim() == "0")
                    return true; //不要求要有排班也要选诊间
                else
                {
                    /*从排班表里查询是否当前医生有排班信息,没有则返回false 即不需要选择诊间*/
                    int pblx=0;
                    if (_date.Hour >= 12 && _date.Hour <= 18)
                        pblx = 2;
                    if (_date.Hour >= 7 && _date.Hour <= 11)
                        pblx = 1;
               
                    string sql = @"SELECT isnull(id,0) FROM jc_mz_yspb WHERE PBKSID="+InstanceForm.BCurrentDept.DeptId+@" AND 
                    YSID="+InstanceForm.BCurrentUser.EmployeeId+@" AND CONVERT(VARCHAR(10),PBSJ,120)='"+_date.ToString("yyyy-MM-dd")+@"' 
                    AND PBLX="+pblx+@" AND BSCBZ=0";
                    if (Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sql)) == 0) //没有排班
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        #endregion
    }
}
