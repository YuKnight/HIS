using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_txyy
{
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
        public static User _currentUser;
        public static Department _currentDept;
        public static RelationalDatabase _database;
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
            FrmTxYy frm = null;

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
                case "Fun_ts_mz_txyy":
                    frm = new FrmTxYy();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.Show();
                    break;
                case "Fun_ts_mz_ChangeGhInfo":
                    //FrmChangeGhInfo frmChange = new FrmChangeGhInfo();
                    //if (_mdiParent != null)
                    //{
                    //    frmChange.MdiParent = _mdiParent;
                    //}
                    //frmChange.Show();
                    try
                    {
                        string path = @"D:\bsoft\portal\360\360chrome.exe";
                        string url = @"http://192.168.0.59:7005/RegisterRoomToChangeNumber.aspx";

                        System.Diagnostics.Process[] myProcesses;
                        myProcesses = System.Diagnostics.Process.GetProcessesByName("360chrome");
                        foreach (System.Diagnostics.Process instance in myProcesses)
                        {
                            //instance.CloseMainWindow();
                            instance.Kill();
                        }

                        System.Diagnostics.Process pro = System.Diagnostics.Process.Start(path, url);
                    }
                    catch
                    {
                    }
                    break;



                case "Fun_ts_mz_ksdz":
                    Frm_mz_ksdzwh frmKsdz = new Frm_mz_ksdzwh();
                    if (_mdiParent != null)
                    {
                        frmKsdz.MdiParent = _mdiParent;
                    }
                    frmKsdz.WindowState = FormWindowState.Maximized;
                    frmKsdz.Show();
                    break;

                case "Fun_ts_jc_PersonTel":

                    FrmUrgentOrdMsg frmPerTel = new FrmUrgentOrdMsg();
                    if (_mdiParent != null)
                    {
                        frmPerTel.MdiParent = _mdiParent;

                    }
                    frmPerTel.Show();
                    frmPerTel.WindowState = FormWindowState.Maximized;
                    break;

                case "Fun_ts_jc_fzyyzd_ys":

                    Frm_yp_fzyywh frmFzYyZd_ys = new Frm_yp_fzyywh("");
                    if (_mdiParent != null)
                    {
                        frmFzYyZd_ys.MdiParent = _mdiParent;

                    }
                    frmFzYyZd_ys.Show();
                    frmFzYyZd_ys.WindowState = FormWindowState.Maximized;
                    break;

                case "Fun_ts_jc_fzyyzd":

                    Frm_yp_fzyywh frmFzYyZd = new Frm_yp_fzyywh();
                    if (_mdiParent != null)
                    {
                        frmFzYyZd.MdiParent = _mdiParent;

                    }
                    frmFzYyZd.Show();
                    frmFzYyZd.WindowState = FormWindowState.Maximized;
                    break;

                case "Fun_ts_jc_ksssh":

                    Frmksssh _Frmksssh = new Frmksssh();
                    if (_mdiParent != null)
                    {
                        _Frmksssh.MdiParent = _mdiParent;

                    }
                    _Frmksssh.Show();
                    _Frmksssh.WindowState = FormWindowState.Maximized;
                    break;

                case "Fun_ts_jc_ksssh_ys":

                    Frmksssh _Frmksssh_ys = new Frmksssh("");
                    if (_mdiParent != null)
                    {
                        _Frmksssh_ys.MdiParent = _mdiParent;

                    }
                    _Frmksssh_ys.Show();
                    _Frmksssh_ys.WindowState = FormWindowState.Maximized;
                    break;

                case "Fun_ts_jc_yygzl":

                    yygzltj yygzltj = new yygzltj();
                    if (_mdiParent != null)
                    {
                        yygzltj.MdiParent = _mdiParent;

                    }
                    yygzltj.Show();
                    yygzltj.WindowState = FormWindowState.Maximized;
                    break;

                case "Fun_ts_jc_subks":

                    subks subks = new subks();
                    if (_mdiParent != null)
                    {
                        subks.MdiParent = _mdiParent;

                    }
                    subks.Show();
                    subks.WindowState = FormWindowState.Maximized;
                    break;

                case "Fun_ts_jc_syfytj":

                    Frmmz_syffjl Frmmz_syffjl = new Frmmz_syffjl();
                    if (_mdiParent != null)
                    {
                        Frmmz_syffjl.MdiParent = _mdiParent;

                    }
                    Frmmz_syffjl.Show();
                    Frmmz_syffjl.WindowState = FormWindowState.Maximized;
                    break;
                case "Fun_ts_jc_OutPatientBackNum":

                    OutPatientBackNum OutPatientBackNum = new OutPatientBackNum();
                    if (_mdiParent != null)
                    {
                        OutPatientBackNum.MdiParent = _mdiParent;

                    }
                    OutPatientBackNum.Show();
                    OutPatientBackNum.WindowState = FormWindowState.Maximized;
                    break;
                case "Fun_ts_jc_GrantCard":

                    GrantCard GrantCard = new GrantCard();
                    if (_mdiParent != null)
                    {
                        GrantCard.MdiParent = _mdiParent;

                    }
                    GrantCard.Show();
                    GrantCard.WindowState = FormWindowState.Maximized;
                    break;

                default:
                    throw new Exception("引出函数名称错误！");
            }

        }

        public object GetObject()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mz_txyy";
            objectInfo.Text = "弹性预约";
            objectInfo.Remark = "弹性预约";
            return objectInfo;
        }

        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mz_txyy";
            objectInfo.Text = "弹性预约";
            objectInfo.Remark = "弹性预约";
            return objectInfo;
        }

        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[13];
            objectInfos[0].Name = "Fun_ts_mz_txyy";
            objectInfos[0].Text = "弹性预约";
            objectInfos[0].Remark = "弹性预约";

            objectInfos[1].Name = "Fun_ts_mz_ChangeGhInfo";
            objectInfos[1].Text = "门诊换号";
            objectInfos[1].Remark = "门诊换号";

            objectInfos[2].Name = "Fun_ts_mz_ksdz";
            objectInfos[2].Text = "科室看诊地址维护";
            objectInfos[2].Remark = "科室看诊地址维护";

            objectInfos[3].Name = "Fun_ts_jc_PersonTel";
            objectInfos[3].Text = "人员电话号码维护";
            objectInfos[3].Remark = "";

            objectInfos[4].Name = "Fun_ts_jc_fzyyzd";
            objectInfos[4].Text = "辅助用药对应诊断";
            objectInfos[4].Remark = "辅助用药对应诊断";

            objectInfos[5].Name = "Fun_ts_jc_ksssh";
            objectInfos[5].Text = "辅助用药审核";
            objectInfos[5].Remark = "辅助用药审核";

            objectInfos[6].Name = "Fun_ts_jc_yygzl";
            objectInfos[6].Text = "科室预约工作量查询";
            objectInfos[6].Remark = "科室预约工作量查询";

            objectInfos[7].Name = "Fun_ts_jc_subks";
            objectInfos[7].Text = "科室关系对照";
            objectInfos[7].Remark = "科室关系对照";

            objectInfos[8].Name = "Fun_ts_jc_fzyyzd_ys";
            objectInfos[8].Text = "辅助用药对应诊断(医生)";
            objectInfos[8].Remark = "辅助用药对应诊断(医生)";

            objectInfos[9].Name = "Fun_ts_jc_ksssh_ys";
            objectInfos[9].Text = "辅助用药查询";
            objectInfos[9].Remark = "辅助用药查询";

            objectInfos[10].Name = "Fun_ts_jc_syfytj";
            objectInfos[10].Text = "门诊输液药品发放次数统计";
            objectInfos[10].Remark = "门诊输液药品发放次数统计";

            objectInfos[11].Name = "Fun_ts_jc_OutPatientBackNum";
            objectInfos[11].Text = "门诊科室退号查询";
            objectInfos[11].Remark = "门诊科室退号查询";

            objectInfos[12].Name = "Fun_ts_jc_GrantCard";
            objectInfos[12].Text = "挂号室发卡量报表";
            objectInfos[12].Remark = "挂号室发卡量报表";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
