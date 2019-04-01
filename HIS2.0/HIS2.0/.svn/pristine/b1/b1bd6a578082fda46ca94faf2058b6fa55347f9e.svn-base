using System;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_zygl_tjbb
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

        private MenuTag _menuTag;
        private string _functionName;
        private string _chineseName;
        private long _menuId;
        private Form _mdiParent;



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

        /// <summary>
        /// TestMethod
        /// </summary>

        #region IDllInformation 成员
        /// <summary>
        /// 当前用户
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

        #region 方法
        TrasenClasses.GeneralClasses.ObjectInfo[] TrasenFrame.Classes.IDllInformation.GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[23];
            objectInfos[0].Name = "Fun_ts_zygl_tjbb_jkhz";
            objectInfos[0].Text = "住院交款汇总统计";
            objectInfos[0].Remark = "住院交款汇总统计";
            objectInfos[1].Name = "Fun_ts_zygl_tjbb_yjjtj";
            objectInfos[1].Text = "住院预交金统计";
            objectInfos[1].Remark = "住院预交金统计";
            objectInfos[2].Name = "Fun_ts_zygl_tjbb_jstj";
            objectInfos[2].Text = "住院结算统计";
            objectInfos[2].Remark = "住院结算统计";
            objectInfos[3].Name = "Fun_ts_zygl_tjbb_zykssrtj";
            objectInfos[3].Text = "住院科室收入统计";
            objectInfos[3].Remark = "住院科室收入统计";
            objectInfos[4].Name = "Fun_ts_zygl_tjbb_zyyssrtj";
            objectInfos[4].Text = "住院医生收入统计";
            objectInfos[4].Remark = "住院医生收入统计";
            objectInfos[5].Name = "Fun_ts_zygl_tjbb_sfxmtj";
            objectInfos[5].Text = "收费项目统计";
            objectInfos[5].Remark = "收费项目统计";
            objectInfos[6].Name = "Fun_ts_zygl_tjbb_brsrtj";
            objectInfos[6].Text = "住院病人收入统计";
            objectInfos[6].Remark = "住院病人收入统计";
            objectInfos[7].Name = "Fun_ts_zygl_tjbb_zyzxkssrtj";
            objectInfos[7].Text = "住院执行科室收入统计";
            objectInfos[7].Remark = "住院执行科室收入统计";
            objectInfos[8].Name = "Fun_ts_zygl_tjbb_brsrtjxm";
            objectInfos[8].Text = "住院病人收入统计(项目分类)";
            objectInfos[8].Remark = "住院病人收入统计(项目分类)";
            objectInfos[9].Name = "Fun_ts_zygl_tjbb_zykssrtjex";
            objectInfos[9].Text = "住院多科室收入统计";
            objectInfos[9].Remark = "住院多科室收入统计";
            objectInfos[10].Name = "Fun_ts_zygl_tjbb_zkbrsrtj";
            objectInfos[10].Text = "住院转科病人收入统计";
            objectInfos[10].Remark = "住院转科病人收入统计";
            objectInfos[11].Name = "Fun_ts_zygl_tjbb_sfxmtj_mb";
            objectInfos[11].Text = "收费项目统计(仅模板)";
            objectInfos[11].Remark = "收费项目统计(仅模板)";
            objectInfos[12].Name = "Fun_ts_zygl_tjbb_ybbrsrtj";
            objectInfos[12].Text = "住院医保病人收入统计";
            objectInfos[12].Remark = "住院医保病人收入统计";
            //Add By Tany 2011-12-07
            objectInfos[13].Name = "Fun_ts_zygl_tjbb_brsrtjxm_ks";
            objectInfos[13].Text = "住院病人收入统计(项目分类_本科室)";
            objectInfos[13].Remark = "住院病人收入统计(项目分类_本科室)";
            //Add By Tany 2012-05-07
            objectInfos[14].Name = "Fun_ts_zygl_tjbb_jstj_ky";
            objectInfos[14].Text = "住院结算统计（仅跨院）";
            objectInfos[14].Remark = "住院结算统计（仅跨院）";
            objectInfos[15].Name = "Fun_ts_zygl_tjbb_zykssrtj_ky";
            objectInfos[15].Text = "住院科室收入统计（仅跨院）";
            objectInfos[15].Remark = "住院科室收入统计（仅跨院）";
            //Add By Kevin 2012-12-25
            objectInfos[16].Name = "Fun_ts_zygl_tjbb_zyyssrtj_dqks";
            objectInfos[16].Text = "住院医生收入统计（当前科室）";
            objectInfos[16].Remark = "住院医生收入统计（当前科室）";
            //Add By Kevin 2012-12-25
            objectInfos[17].Name = "Fun_ts_zygl_tjbb_zykssrtj_dqks";
            objectInfos[17].Text = "住院科室收入统计（当前科室）";
            objectInfos[17].Remark = "住院科室收入统计（当前科室）";
            //Add by Kevin 2013-03-01
            objectInfos[18].Name = "Fun_ts_zygl_tjbb_zykssrtj_ypfl";
            objectInfos[18].Text = "住院科室收入统计（药品分类）";
            objectInfos[18].Remark = "住院科室收入统计（药品分类）";
            //Add By Kevin 2013-07-23
            objectInfos[19].Name = "Fun_ts_zygl_tjbb_cybrxxtj";
            objectInfos[19].Text = "出院病人信息统计";
            objectInfos[19].Remark = "出院病人信息统计";
            //Add By Kevin 2014-01-23
            objectInfos[20].Name = "Fun_ts_zygl_tjbb_zysssqkstj";
            objectInfos[20].Text = "住院手术申请科室收入统计";
            objectInfos[20].Remark = "住院手术申请科室收入统计";
            //Add By tck 2014-04-22
            objectInfos[21].Name = "Fun_ts_zygl_tjbb_zkbrsrtj_ICU";
            objectInfos[21].Text = "科室转科病人收入费用统计";
            objectInfos[21].Remark = "科室转科病人收入费用统计";

            //Add By yaokx 2014-05-14
            objectInfos[22].Name = "Fun_ts_zygl_tjbb_sfxmtjother";
            objectInfos[22].Text = "收费项目统计(其他)";
            objectInfos[22].Remark = "收费项目统计(其他)";
            return objectInfos;
        }

        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            switch (_functionName)
            {
                case "Fun_ts_zygl_tjbb_jkhz":
                    FrmJkhz frmJkhz = new FrmJkhz();
                    if (_mdiParent != null)
                    {
                        frmJkhz.MdiParent = _mdiParent;
                    }
                    frmJkhz.Show();
                    break;
                case "Fun_ts_zygl_tjbb_yjjtj":
                    FrmYjjtj frmYjjtj = new FrmYjjtj();
                    if (_mdiParent != null)
                    {
                        frmYjjtj.MdiParent = _mdiParent;
                    }
                    frmYjjtj.Show();
                    break;
                case "Fun_ts_zygl_tjbb_jstj":
                    FrmJstj frmJstj = new FrmJstj();
                    if (_mdiParent != null)
                    {
                        frmJstj.MdiParent = _mdiParent;
                    }
                    frmJstj.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zykssrtj":
                    FrmZykssrtj frmZykssrtj = new FrmZykssrtj();
                    if (_mdiParent != null)
                    {
                        frmZykssrtj.MdiParent = _mdiParent;
                    }
                    frmZykssrtj.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zyyssrtj":
                    FrmZyyssrtj frmZyyssrtj = new FrmZyyssrtj(0);
                    if (_mdiParent != null)
                    {
                        frmZyyssrtj.MdiParent = _mdiParent;
                    }
                    frmZyyssrtj.Show();
                    break;
                case "Fun_ts_zygl_tjbb_sfxmtj":
                    FrmSfxmtj frmSfxmtj = new FrmSfxmtj(false);
                    if (_mdiParent != null)
                    {
                        frmSfxmtj.MdiParent = _mdiParent;
                    }
                    frmSfxmtj.Show();
                    break;
                case "Fun_ts_zygl_tjbb_sfxmtj_mb":
                    FrmSfxmtj frmSfxmtjmb = new FrmSfxmtj(true);
                    if (_mdiParent != null)
                    {
                        frmSfxmtjmb.MdiParent = _mdiParent;
                    }
                    frmSfxmtjmb.Show();
                    break;
                case "Fun_ts_zygl_tjbb_brsrtj":
                    FrmBrsrtj frmBrsrtj = new FrmBrsrtj();
                    if (_mdiParent != null)
                    {
                        frmBrsrtj.MdiParent = _mdiParent;
                    }
                    frmBrsrtj.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zyzxkssrtj":
                    FrmZyzxkssrtj frmZyzxkssrtj = new FrmZyzxkssrtj();
                    if (_mdiParent != null)
                    {
                        frmZyzxkssrtj.MdiParent = _mdiParent;
                    }
                    frmZyzxkssrtj.Show();
                    break;
                case "Fun_ts_zygl_tjbb_brsrtjxm":
                case "Fun_ts_zygl_tjbb_brsrtjxm_ks"://Add By Tany 2011-12-07
                    bool isAll = true;
                    if (_functionName == "Fun_ts_zygl_tjbb_brsrtjxm_ks")
                    {
                        isAll = false;
                    }
                    FrmBrsrtjxm frmBrsrtjxm = new FrmBrsrtjxm(isAll);
                    if (_mdiParent != null)
                    {
                        frmBrsrtjxm.MdiParent = _mdiParent;
                    }
                    frmBrsrtjxm.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zykssrtjex":
                    FrmZykssrtjEx frmZykssrtjEx = new FrmZykssrtjEx();
                    if (_mdiParent != null)
                    {
                        frmZykssrtjEx.MdiParent = _mdiParent;
                    }
                    frmZykssrtjEx.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zkbrsrtj":
                    FrmZkbrsrtj frmZkbrsrtj = new FrmZkbrsrtj();
                    if (_mdiParent != null)
                    {
                        frmZkbrsrtj.MdiParent = _mdiParent;
                    }
                    frmZkbrsrtj.Show();
                    break;
                case "Fun_ts_zygl_tjbb_ybbrsrtj":
                    FrmYbbrsrtj frmYbbrsrtj = new FrmYbbrsrtj();
                    if (_mdiParent != null)
                    {
                        frmYbbrsrtj.MdiParent = _mdiParent;
                    }
                    frmYbbrsrtj.Show();
                    break;
                //Add By Tany 2012-05-07
                case "Fun_ts_zygl_tjbb_jstj_ky":
                    FrmJstj frmJstj_ky = new FrmJstj(1);
                    if (_mdiParent != null)
                    {
                        frmJstj_ky.MdiParent = _mdiParent;
                    }
                    frmJstj_ky.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zykssrtj_ky":
                    FrmZykssrtj frmZykssrtj_ky = new FrmZykssrtj(1);
                    if (_mdiParent != null)
                    {
                        frmZykssrtj_ky.MdiParent = _mdiParent;
                    }
                    frmZykssrtj_ky.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zyyssrtj_dqks":
                    FrmZyyssrtj frm = new FrmZyyssrtj(1);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zykssrtj_dqks":
                    FrmZykssrtj frmks = new FrmZykssrtj(true);
                    if (_mdiParent != null)
                    {
                        frmks.MdiParent = _mdiParent;
                    }
                    frmks.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zykssrtj_ypfl":
                    FrmZykssrtj frmypfl = new FrmZykssrtj("111");
                    if (_mdiParent != null)
                    {
                        frmypfl.MdiParent = _mdiParent;
                    }
                    frmypfl.Show();
                    break;
                    //Add By Kevin 2013-07-23
                case "Fun_ts_zygl_tjbb_cybrxxtj":
                    FrmCybrxxtj frmcybrxx = new FrmCybrxxtj();
                    if (_mdiParent != null)
                    {
                        frmcybrxx.MdiParent = _mdiParent;
                    }
                    frmcybrxx.Show();
                    break;
                //Add By Kevin 2014-01-23
                case "Fun_ts_zygl_tjbb_zysssqkstj":
                    FrmZysskstj frmzyssks = new FrmZysskstj();
                    if(_mdiParent != null)
                    {
                        frmzyssks.MdiParent = _mdiParent;
                    }
                    frmzyssks.Show();
                    break;
                case "Fun_ts_zygl_tjbb_zkbrsrtj_ICU":
                    FrmZkbrsrtj frmZkbrsrtjs = new FrmZkbrsrtj(1);
                    if (_mdiParent != null)
                    {
                        frmZkbrsrtjs.MdiParent = _mdiParent;
                    }
                    frmZkbrsrtjs.Show();
                    break;
                case "Fun_ts_zygl_tjbb_sfxmtjother":
                    FrmSfxmtjOther frmSfxmtjOther = new FrmSfxmtjOther(false);
                    if (_mdiParent != null)
                    {
                        frmSfxmtjOther.MdiParent = _mdiParent;
                    }
                    frmSfxmtjOther.Show();
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }
        }

        TrasenClasses.GeneralClasses.ObjectInfo TrasenFrame.Classes.IDllInformation.GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "Ts_zygl_tjbb";
            objectInfo.Text = "统计报表";
            objectInfo.Remark = "统计报表";
            return objectInfo;
        }
        #endregion
        #endregion

    }
}
