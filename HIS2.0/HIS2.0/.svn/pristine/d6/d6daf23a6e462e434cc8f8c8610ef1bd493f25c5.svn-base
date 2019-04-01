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

namespace ts_mz_tjbb			//★修改为约定的命名空间
{
    /// <summary>
    /// InstanceBForm 的摘要说明
    /// 实例化业务窗体
    /// </summary>
    public class InstanceForm : IDllInformation
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
            FrmBaseDateGrid frmReport;
            switch (_functionName)
            {
                case "Fun_ts_mz_tjbb_mzsk_zffs":
                case "Fun_ts_mz_tjbb_mzjk_zffs":
                    Frmsk_zffs Frmxjsrtj = new Frmsk_zffs(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmxjsrtj.MdiParent = _mdiParent;
                    }
                    Frmxjsrtj.Show();
                    break;
                case "Fun_ts_mz_tjbb_mzsk_xmsrtj":
                case "Fun_ts_mz_tjbb_mzjk_xmsrtj":
                    Frmsk_xmsrtj Frmsk_xmsrtj = new Frmsk_xmsrtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmsk_xmsrtj.MdiParent = _mdiParent;
                    }
                    Frmsk_xmsrtj.Show();
                    break;
                case "Fun_ts_mz_tjbb_yssrtj":
                    Frmyssrtj Frmyssrtj = new Frmyssrtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmyssrtj.MdiParent = _mdiParent;
                    }
                    Frmyssrtj.Show();
                    break;
                case "Fun_ts_mz_tjbb_kssrtj":
                    //case "Fun_ts_mz_tjbb_kssrtj_zxks":
                    Frmkssrtj Frmkssrtj = new Frmkssrtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmkssrtj.MdiParent = _mdiParent;
                    }
                    Frmkssrtj.Show();
                    break;
                case "Fun_ts_mz_tjbb_kssrtj_zxks":
                    Frmzxkssr Frmzxkssr = new Frmzxkssr(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzxkssr.MdiParent = _mdiParent;
                    }
                    Frmzxkssr.Show();
                    break;

                case "Fun_ts_mz_jk_tj":
                case "Fun_ts_mz_jk_tj_date"://Add By Zj 2012-09-24 多加引出函数
                    ts_mzsf_grjkb.InstanceForm.BDatabase = InstanceForm.BDatabase;
                    ts_mzsf_grjkb.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
                    ts_mzsf_grjkb.InstanceForm.BCurrentDept = InstanceForm.BCurrentDept;
                    ts_mzsf_grjkb.Frmsk_jktj Frmsk_jktj = new ts_mzsf_grjkb.Frmsk_jktj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmsk_jktj.MdiParent = _mdiParent;
                    }
                    Frmsk_jktj.Show();
                    break;
                case "Fun_ts_mz_jk_tj_cx":
                case "Fun_ts_mz_jk_tj_cx_qr"://Add By Zj 2012-10-10 增加交款确认函数
                    ts_mzsf_grjkb.InstanceForm.BDatabase = InstanceForm.BDatabase;
                    ts_mzsf_grjkb.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
                    ts_mzsf_grjkb.InstanceForm.BCurrentDept = InstanceForm.BCurrentDept;
                    ts_mzsf_grjkb.Frmsk_jktj_cx Frmsk_jktj_cx = new ts_mzsf_grjkb.Frmsk_jktj_cx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmsk_jktj_cx.MdiParent = _mdiParent;
                    }
                    Frmsk_jktj_cx.Show();
                    break;
                case "Fun_ts_mz_tjbb_ghrctj":
                    Frmghrctj Frmghrctj = new Frmghrctj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmghrctj.MdiParent = _mdiParent;
                    }
                    Frmghrctj.Show();
                    break;
                case "Fun_ts_mz_tjbb_jk_pos":
                case "Fun_ts_mz_tjbb_sk_pos":
                    Frmsk_pos Frmsk_pos = new Frmsk_pos(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmsk_pos.MdiParent = _mdiParent;
                    }
                    Frmsk_pos.Show();
                    break;
                case "Fun_ts_mz_tjbb_sk_htdw":
                case "Fun_ts_mz_tjbb_jk_htdw":
                    Frmsk_htdw Frmsk_htdw = new Frmsk_htdw(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmsk_htdw.MdiParent = _mdiParent;
                    }
                    Frmsk_htdw.Show();
                    break;
                case "Fun_ts_mz_tjbb_yb_rtj":
                case "Fun_ts_mz_tjbb_yb_rtj_jk":
                    Frmsk_ybrtj Frmsk_ybrtj = new Frmsk_ybrtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmsk_ybrtj.MdiParent = _mdiParent;
                    }
                    Frmsk_ybrtj.Show();
                    break;
                case "Fun_ts_mz_tjbb_kssrtj_zxks_mx":
                    Frmzxksmxsr Frmzxksmxsr = new Frmzxksmxsr(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzxksmxsr.MdiParent = _mdiParent;
                    }
                    Frmzxksmxsr.Show();
                    break;
                case "Fun_ts_mz_tjbb_zdyzdcx":
                    Frmzdyzdcx Frmzdyzdcx = new Frmzdyzdcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzdyzdcx.MdiParent = _mdiParent;
                    }
                    Frmzdyzdcx.Show();
                    break;
                case "Fun_ts_mz_tjbb_sfygzltj":
                    FrmSfygzltj frmgzltj = new FrmSfygzltj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmgzltj.MdiParent = _mdiParent;
                    }
                    frmgzltj.Show();
                    break;
                case "Fun_ts_mz_tjbb_ysjzltj":
                    FrmMZYSJZLTJ frmysjzltj = new FrmMZYSJZLTJ(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmysjzltj.WindowState = FormWindowState.Maximized;
                        frmysjzltj.MdiParent = _mdiParent;
                    }
                    frmysjzltj.Show();
                    break;
                case "Fun_ts_mz_tjbb_blbzlktj":
                    FrmMZGHBLBZLKTJ frmmzghblbzlktj = new FrmMZGHBLBZLKTJ(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmmzghblbzlktj.WindowState = FormWindowState.Maximized;
                        frmmzghblbzlktj.MdiParent = _mdiParent;
                    }
                    frmmzghblbzlktj.Show();
                    break;
                case "Fun_ts_mz_jk_tj_yjj":
                    Frmyjjjk Frmyjjjk = new Frmyjjjk(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmyjjjk.MdiParent = _mdiParent;
                    }
                    Frmyjjjk.Show();
                    break;
                case "Fun_ts_mz_sk_tj_yjjcx":
                    Frmyjjmx Frmyjjmx = new Frmyjjmx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmyjjmx.MdiParent = _mdiParent;
                    }
                    Frmyjjmx.Show();
                    break;
                case "Fun_ts_mz_yjjdz":
                    Frmyjjdz Frmyjjdz = new Frmyjjdz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmyjjdz.MdiParent = _mdiParent;
                    }
                    Frmyjjdz.Show();
                    break;
                case "Fun_ts_mz_yjjjcqk":
                    Frmyjjjyqkb Frmyjjjyqkb = new Frmyjjjyqkb(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmyjjjyqkb.MdiParent = _mdiParent;
                    }
                    Frmyjjjyqkb.Show();
                    break;
                case "Fun_ts_mz_yjtj":
                    FrmMzyj FrmMzyj = new FrmMzyj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmMzyj.MdiParent = _mdiParent;
                    }
                    FrmMzyj.Show();
                    break;
                case "Fun_ts_mz_tjbb_DeptSrbl":
                case "Fun_ts_mz_tjbb_DeptSrbl_ks":
                    FrmMzysXmtj xmtjDept = new FrmMzysXmtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        xmtjDept.MdiParent = _mdiParent;
                    }
                    xmtjDept.Show();
                    break;
                case "Fun_ts_mz_tjbb_UserSrbl":
                    FrmMzysXmtj xmtjUser = new FrmMzysXmtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        xmtjUser.MdiParent = _mdiParent;
                    }
                    xmtjUser.Show();
                    break;
                case "Fun_ts_mz_tjbb_mzwjk_zffs":
                    Frmwjk_zffs Frmwjk_zffs = new Frmwjk_zffs(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmwjk_zffs.MdiParent = _mdiParent;
                    }
                    Frmwjk_zffs.Show();
                    break;
                case "Fun_ts_mz_tjbb_ybjstj":
                    Frmybhzmxtj Frmybhzmxtj = new Frmybhzmxtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmybhzmxtj.MdiParent = _mdiParent;
                    }
                    Frmybhzmxtj.Show();
                    break;
                case "Fun_ts_mz_zffp":
                    FrmMzzffp frmMzzffp = new FrmMzzffp(_chineseName);
                    if (_mdiParent != null)
                    {
                        frmMzzffp.MdiParent = _mdiParent;
                    }
                    frmMzzffp.Show();
                    break;
                case "Fun_ts_mz_tjbb_mzsrrbb":
                    Frmmzsrrbb Frmmzsrrbb = new Frmmzsrrbb(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmmzsrrbb.MdiParent = _mdiParent;
                    }
                    Frmmzsrrbb.Show();
                    break;
                case "Fun_ts_mz_tjbb_mzkssrrbb": //Add By Zj 2012-05-10
                    FrmMzSrRbbKs Frmmzkssrrbb = new FrmMzSrRbbKs(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmmzkssrrbb.MdiParent = _mdiParent;
                    }
                    Frmmzkssrrbb.Show();
                    break;
                case "Fun_ts_mz_tjbb_ysypbl"://Add By Zj 2012-05-14
                    frmmzysypbl frmypbl = new frmmzysypbl(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmypbl.MdiParent = _mdiParent;
                    }
                    frmypbl.Show();
                    break;
                case "Fun_ts_mz_tjbb_yyzlkbk_all"://Add By Zj 2012-12-28
                case "Fun_ts_mz_tjbb_yyzlkbk":  //Add by Kevin 2012-06-07
                    Frmyyzlkbktj frmbk = new Frmyyzlkbktj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmbk.WindowState = FormWindowState.Maximized;
                        frmbk.MdiParent = _mdiParent;
                    }
                    frmbk.Show();
                    break;
                case "Fun_ts_mz_tjbb_yyzlkzffs":  //Add by Kevin 2012-06-07
                    Frmzlkzffstj frmzffs = new Frmzlkzffstj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmzffs.WindowState = FormWindowState.Maximized;
                        frmzffs.MdiParent = _mdiParent;
                    }
                    frmzffs.Show();
                    break;
                case "Fun_ts_mz_tjbb_yytktyyj":  //Add by Kevin 2012-06-07
                    Frmyytktyjtj frmtk = new Frmyytktyjtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmtk.WindowState = FormWindowState.Maximized;
                        frmtk.MdiParent = _mdiParent;
                    }
                    frmtk.Show();
                    break;
                case "Fun_ts_mz_tjbb_icbcdztj":
                    ts_mz_tjbb_zz.InstanceForm.BDatabase = InstanceForm.BDatabase;
                    ts_mz_tjbb_zz.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
                    ts_mz_tjbb_zz.InstanceForm.BCurrentDept = InstanceForm.BCurrentDept;
                    ts_mz_tjbb_zz.FrmICBCRec frmICBC = new ts_mz_tjbb_zz.FrmICBCRec(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmICBC.WindowState = FormWindowState.Maximized;
                        frmICBC.MdiParent = _mdiParent;
                    }
                    frmICBC.Show();
                    break;
                case "Fun_ts_mz_tjbb_mzyjjxfdz":
                    Frmyyjxfdz frm = new Frmyyjxfdz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        //frm.WindowState = FormWindowState.Maximized;
                        frm.MdiParent = _mdiParent;
                    }
                    frm.Show();
                    break;
                case "Fun_ts_mz_tjbb_zlkbktj":
                    Frmzlktj frmzlktj = new Frmzlktj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {

                        frmzlktj.MdiParent = _mdiParent;
                    }
                    frmzlktj.Show();
                    break;
                case "Fun_ts_mz_tjbb_kssrtjypfl"://Add By Zj 2013-02-20
                    Frmkssrtjypfl frmypfl = new Frmkssrtjypfl(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {

                        frmypfl.MdiParent = _mdiParent;
                    }
                    frmypfl.WindowState = FormWindowState.Maximized;
                    frmypfl.Show();
                    break;
                    //add by zouchihua 2013-4-27
                case "Fun_ts_mz_tjbb_yjjszqktj":
                    门诊预交金收支情况统计 frmyjjsz = new 门诊预交金收支情况统计(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {

                        frmyjjsz.MdiParent = _mdiParent;
                    }
                    frmyjjsz.WindowState = FormWindowState.Maximized;
                    frmyjjsz.Show();
                    break;
                //add by zouchihua 2013-4-27
                case "Fun_ts_mz_tjbb_zlksrtj":
                    诊疗卡收入统计 frmyzlkjjsz = new 诊疗卡收入统计(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {

                        frmyzlkjjsz.MdiParent = _mdiParent;
                    }
                    frmyzlkjjsz.WindowState = FormWindowState.Maximized;
                    frmyzlkjjsz.Show();
                    break;
                //add by zp 2013-07-18 八医院需求 新增节假日科室收入统计查询 可动态新增日期时段条件
                case "Fun_ts_mz_tjbb_jjrsrtjbydate":
                    FrmkssrtjByDate frmkstjbydate = new FrmkssrtjByDate(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmkstjbydate.MdiParent = _mdiParent;
                    }
                    frmkstjbydate.WindowState = FormWindowState.Maximized;
                    frmkstjbydate.Show();
                    break;
                //add by zp 2013-07-19 八医院需求 新增节假日科室收入统计查询 可动态新增日期时段条件
                case "Fun_ts_mz_tjbb_yssrtjBydate":
                    Frmyssrtj_ByDate frmystjBydate = new Frmyssrtj_ByDate(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmystjBydate.MdiParent = _mdiParent;
                    }
                    frmystjBydate.WindowState = FormWindowState.Maximized;
                    frmystjBydate.Show();
                    break;
                //add by zp 2013-07-19 八医院需求 新增节假日门诊执行科室收入统计 可动态新增日期时段条件
                case "Fun_ts_mz_tjbb_kssrtj_zxksBydate":
                    FrmzxkssrByDate frmzxkstjBydate = new FrmzxkssrByDate(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmzxkstjBydate.MdiParent = _mdiParent;
                    }
                    frmzxkstjBydate.WindowState = FormWindowState.Maximized;
                    frmzxkstjBydate.Show();
                    break;
                //add by zp 2013-07-19 八医院需求 门诊执行科室节假日收入明细统计
                //case "Fun_ts_mz_tjbb_kssrtj_zxks_mxBydate":
                //    Frmzxkssrtj_mxByDate frm_kssrt_jmxbydate = new Frmzxkssrtj_mxByDate(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        frm_kssrt_jmxbydate.MdiParent = _mdiParent;
                //    }
                //    frm_kssrt_jmxbydate.WindowState = FormWindowState.Maximized;
                //    frm_kssrt_jmxbydate.Show();
                //    break;
                // add by zp 2013-07-19 八医院需求  门诊医生接诊量多时段统计
                case "Fun_ts_mz_tjbb_ysjzltjBydate":
                    FrmMZYSJZLTJByDate frm_mzys_jztjbydate = new FrmMZYSJZLTJByDate(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_mzys_jztjbydate.MdiParent = _mdiParent;
                    }
                    frm_mzys_jztjbydate.WindowState = FormWindowState.Maximized;
                    frm_mzys_jztjbydate.Show();
                    break;
                     //by jiangzf
                case "Fun_MZ_GH_ZL_JC":
                    frmReport = new FrmBaseDateGrid(_menuTag, _chineseName, _mdiParent, "门诊医生日常工作量.grf");
                    frmReport.QuerySQL = "execute dbo.SP_MZ_GH_ZL_JC '{0}','{1}','{2}'";
                    if (_mdiParent != null)
                    {
                        frmReport.MdiParent = _mdiParent;
                    }
                    frmReport.WindowState = FormWindowState.Maximized;
                    frmReport.Show();
                    break;
                case "Fun_ts_mz_yjjyeqk":
                    Frmyjjyeqkb Frmyjjyeqkb = new Frmyjjyeqkb(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmyjjyeqkb.MdiParent = _mdiParent;
                    }
                    Frmyjjyeqkb.Show();
                    break;
                //Add By Kevin 2014-06-10 建设银行自助机对账统计
                case "Fun_ts_mz_tjbb_ccbdztj":
                    FrmCCBRec frmccbrec = new FrmCCBRec(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmccbrec.MdiParent = _mdiParent;
                    }
                    frmccbrec.Show();
                    break;
                //Add By Kevin 2014-06-27 儿童子科室收入统计
                case "Fun_ts_mz_tjbb_etzkssrtj":
                    Frmzkssrtj frmzkssrtj = new Frmzkssrtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmzkssrtj.MdiParent = _mdiParent;
                    }
                    frmzkssrtj.Show();
                    break;
                case "Fun_ts_mz_tjbb_ksybsrtj": // add by fangke
                    FrmYbsrtj frmYbsrtj = new FrmYbsrtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmYbsrtj.MdiParent = _mdiParent;
                    }
                    frmYbsrtj.Show();
                    break;
                case "Fun_ts_mz_tjbb_yjksgzltj":// add by fangke
                    FrmYjKsGzlTj frmYjkszgltj = new FrmYjKsGzlTj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmYjkszgltj.MdiParent = _mdiParent;
                    }
                    frmYjkszgltj.Show();
                    break;
                case "Fun_ts_mz_tjbb_jkpjtj":// add by fangke
                    FrmJkpjtj frmJkpjtj = new FrmJkpjtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmJkpjtj.MdiParent = _mdiParent;
                    }
                    frmJkpjtj.Show();
                    break;
                case "Fun_ts_tjbb_sfygrjkfptj":
                    FrmGrJkfpCx frmGrJkfpCx = new FrmGrJkfpCx();
                    if (_mdiParent != null)
                    {
                        frmGrJkfpCx.MdiParent = _mdiParent;
                    }
                    frmGrJkfpCx.Show();
                    break;
                case "Fun_ts_tjbb_htdw_dzqr":
                    frmHtdwjedz FrmDzqr = new frmHtdwjedz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmDzqr.MdiParent = _mdiParent;
                    }
                    FrmDzqr.Show();
                    FrmDzqr.WindowState = FormWindowState.Maximized;
                    break;
                case "Fun_ts_mz_tjbb_ylzjjdztj":
                    FrmCUPBankChecking frmCUPBankChecking = new FrmCUPBankChecking(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmCUPBankChecking.MdiParent = _mdiParent;
                    }
                    frmCUPBankChecking.WindowState = FormWindowState.Maximized;
                    frmCUPBankChecking.Show();
                    break;

                //*****************************Add By leidong*******************************//

                case "Fun_ts_jg_DepartmentGroup":
                    FrmDepartments frmDepartment = new FrmDepartments();
                    frmDepartment.ShowDialog();
                    break;

                case "Fun_ts_jg_IncomeReport":
                    BusinessIncomeReport frmIcome = new BusinessIncomeReport(_menuTag, _chineseName, _mdiParent, 0);
                    if (_mdiParent != null)
                    {
                        frmIcome.MdiParent = _mdiParent;
                    }
                    frmIcome.Show();
                    break;
                case "Fun_ts_jg_itemGroup":
                    Frm_ItemGroup frm_itemGroup = new Frm_ItemGroup();
                    frm_itemGroup.ShowDialog();
                    break;
                case "Fun_ts_jg_IncomeReport_Drugs":
                    FrmBussinessReportOfItem frmIcomeDrugs = new FrmBussinessReportOfItem(0, _menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmIcomeDrugs.MdiParent = _mdiParent;
                    }
                    frmIcomeDrugs.Show();
                    break;

                case "Fun_ts_jg_IncomeReport_Drugs_1":
                    FrmBussinessReportOfItem frmIcomeDrugs1 = new FrmBussinessReportOfItem(3, _menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmIcomeDrugs1.MdiParent = _mdiParent;
                    }
                    frmIcomeDrugs1.Show();
                    break;

                case "Fun_ts_jg_IncomeReport_Drugs_2":
                    FrmBussinessReportOfItem frmIcomeDrugs2 = new FrmBussinessReportOfItem(4, _menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmIcomeDrugs2.MdiParent = _mdiParent;
                    }
                    frmIcomeDrugs2.Show();
                    break;

                case "Fun_ts_jg_IncomeReport_MedicalTechnology":
                    FrmBussinessReportOfItem frmIcomeMedicalTechnology = new FrmBussinessReportOfItem(1, _menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmIcomeMedicalTechnology.MdiParent = _mdiParent;
                    }
                    frmIcomeMedicalTechnology.Show();
                    break;
                case "Fun_ts_jg_IncomeReport_MedicalService":
                    FrmBussinessReportOfItem frmIcomeMedicalService = new FrmBussinessReportOfItem(2, _menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmIcomeMedicalService.MdiParent = _mdiParent;
                    }
                    frmIcomeMedicalService.Show();
                    break;
                case "Fun_ts_jg_IcomeReport_Operation":
                    FrmBussinessReportOfOperation frmOperation = new FrmBussinessReportOfOperation(0, _menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmOperation.MdiParent = _mdiParent;
                    }
                    frmOperation.Show();
                    break;

                case "Fun_ts_jg_IcomeReport_Anesthesia":
                    FrmBussinessReportOfOperation frmAnesthesia = new FrmBussinessReportOfOperation(1, _menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmAnesthesia.MdiParent = _mdiParent;
                    }
                    frmAnesthesia.Show();
                    break;

                case "Fun_ts_jg_IcomeReport_Chinese":
                    Frm_BussinessReportChinese frmChinese = new Frm_BussinessReportChinese(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmChinese.MdiParent = _mdiParent;
                    }
                    frmChinese.Show();
                    break;

                case "Fun_ts_MZ_BussinessReport":
                    Frm_MZ_BusinessReport frm_MZ_BussinessReport = new Frm_MZ_BusinessReport(_menuTag, _chineseName, _mdiParent, 0);
                    if (_mdiParent != null)
                    {
                        frm_MZ_BussinessReport.MdiParent = _mdiParent;
                    }
                    frm_MZ_BussinessReport.Show();
                    break;


                case "Fun_ts_MZ_QueryHighAmount":
                    Frm_MZ_HighAmountQuery frm_MZ_HighAmountQuery = new Frm_MZ_HighAmountQuery(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_MZ_HighAmountQuery.MdiParent = _mdiParent;
                    }
                    frm_MZ_HighAmountQuery.Show();
                    break;

                case "Fun_ts_MZ_BussinessOfZXKS":
                    Frm_MZ_BussinessOfZXKS frm_MZ_BussinessOfZXKS = new Frm_MZ_BussinessOfZXKS(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_MZ_BussinessOfZXKS.MdiParent = _mdiParent;
                    }
                    frm_MZ_BussinessOfZXKS.Show();
                    break;

                case "Fun_ts_MZ_RecipelofDrugsQuery":
                    Frm_MZ_RecipelofDrugsQuery frm_MZ_RecipelofDrugsQuery = new Frm_MZ_RecipelofDrugsQuery(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_MZ_RecipelofDrugsQuery.MdiParent = _mdiParent;
                    }
                    frm_MZ_RecipelofDrugsQuery.Show();
                    break;

                case "Fun_ts_MZ_QueryBussinessOfDoc":
                    Frm_QueryBussinessOfdoc frm_QueryBussinessOfdoc = new Frm_QueryBussinessOfdoc(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_QueryBussinessOfdoc.MdiParent = _mdiParent;
                    }
                    frm_QueryBussinessOfdoc.Show();
                    break;

                case "Fun_ts_MZ_QueryBRCount":
                    Frm_MZ_QueryBRCount frm_MZ_QueryBRCount = new Frm_MZ_QueryBRCount(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_MZ_QueryBRCount.MdiParent = _mdiParent;
                    }
                    frm_MZ_QueryBRCount.Show();
                    break;

                case "Fun_ts_ZY_WorkLogOfWard":
                    Frm_WorkLogOfWard frm_WorkLogOfWard = new Frm_WorkLogOfWard(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_WorkLogOfWard.MdiParent = _mdiParent;
                    }
                    frm_WorkLogOfWard.Show();
                    break;


                //
                case "Fun_ts_QuerySomeYJItemCount":
                    Frm_QuerySomeYJItemCount frm_QuerySomeYJItemCount = new Frm_QuerySomeYJItemCount(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_QuerySomeYJItemCount.MdiParent = _mdiParent;
                    }
                    frm_QuerySomeYJItemCount.Show();
                    break;


                case "Fun_ts_jg_IncomeReport_Dept":
                    BusinessIncomeReport frmIcomedept = new BusinessIncomeReport(_menuTag, _chineseName, _mdiParent, 1);
                    if (_mdiParent != null)
                    {
                        frmIcomedept.MdiParent = _mdiParent;
                    }
                    frmIcomedept.Show();
                    break;


                case "Fun_ts_ZY_BussinessReport":
                    Frm_ZY_BusinessReport frm_ZY_BusinessReport = new Frm_ZY_BusinessReport(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_ZY_BusinessReport.MdiParent = _mdiParent;
                    }
                    frm_ZY_BusinessReport.Show();
                    break;

                case "Fun_ts_ReportBuessinessQuerybyDoc":
                    Frm_ReportBuessinessQuerybyDoc frm_ReportBuessinessQuerybyDoc = new Frm_ReportBuessinessQuerybyDoc(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_ReportBuessinessQuerybyDoc.MdiParent = _mdiParent;
                    }
                    frm_ReportBuessinessQuerybyDoc.Show();
                    break;

                case "Fun_ts_ReportBuessinessQuerybyDept":
                    Frm_ReportBuessinessQuerybyDept frm_ReportBuessinessQuerybyDept = new Frm_ReportBuessinessQuerybyDept(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_ReportBuessinessQuerybyDept.MdiParent = _mdiParent;
                    }
                    frm_ReportBuessinessQuerybyDept.Show();
                    break;

                case "Fun_ts_QueryBussinessOfOperation":
                    Frm_MZ_QueryBussinessOfOperation frm_MZ_QueryBussinessOfOperation = new Frm_MZ_QueryBussinessOfOperation(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_MZ_QueryBussinessOfOperation.MdiParent = _mdiParent;
                    }
                    frm_MZ_QueryBussinessOfOperation.Show();
                    break;

                case "Fun_ts_QueryBuessinessOfTransfer":
                    Frm_QueryBuessinessOfTransfer frm_QueryBuessinessOfTransfer = new Frm_QueryBuessinessOfTransfer(_menuTag, _chineseName, _mdiParent,0);
                    if (_mdiParent != null)
                    {
                        frm_QueryBuessinessOfTransfer.MdiParent = _mdiParent;
                    }
                    frm_QueryBuessinessOfTransfer.Show();
                    break;

                case "Fun_ts_QueryBuessinessOfOperation":
                    Frm_QueryBuessinessOfOperation frm_QueryBuessinessOfOperation = new Frm_QueryBuessinessOfOperation(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_QueryBuessinessOfOperation.MdiParent = _mdiParent;
                    }
                    frm_QueryBuessinessOfOperation.Show();
                    break;

                case "Fun_ts_QueryBuessinessOfSingleItem":
                    Frm_QueryBuessinessOfSingleItem frm_QueryBuessinessOfSingleItem = new Frm_QueryBuessinessOfSingleItem(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_QueryBuessinessOfSingleItem.MdiParent = _mdiParent;
                    }
                    frm_QueryBuessinessOfSingleItem.Show();
                    break;

                case "Fun_ts_MZ_QueryMZQK":
                    Frm_MZ_QueryMZQK frm_MZ_QueryMZQK = new Frm_MZ_QueryMZQK(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_MZ_QueryMZQK.MdiParent = _mdiParent;
                    }
                    frm_MZ_QueryMZQK.Show();
                    break;

                case "Fun_ts_Zy_LackDisChargeReport":
                    Frm_Zy_LackDisChargeReport frm_Zy_LackDisChargeReport = new Frm_Zy_LackDisChargeReport(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_Zy_LackDisChargeReport.MdiParent = _mdiParent;
                    }
                    frm_Zy_LackDisChargeReport.Show();
                    break;


                case "Fun_ts_Zy_ZXSRTJ":
                    Frm_Zy_ZXSRTJEx frm_Zy_ZXSRTJEx = new Frm_Zy_ZXSRTJEx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_Zy_ZXSRTJEx.MdiParent = _mdiParent;
                    }
                    frm_Zy_ZXSRTJEx.Show();
                    break;

                case "Fun_ts_QueryBuessinessOfSingleDrugItem":
                    Frm_QueryBuessinessOfSingleDrugItem frm_QueryBuessinessOfSingleDrugItem = new Frm_QueryBuessinessOfSingleDrugItem(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_QueryBuessinessOfSingleDrugItem.MdiParent = _mdiParent;
                    }
                    frm_QueryBuessinessOfSingleDrugItem.Show();
                    break;

                case "Fun_ts_MZ_BussinessReport_mx":
                    Frm_MZ_BusinessReport frm_MZ_BussinessReportmx = new Frm_MZ_BusinessReport(_menuTag, _chineseName, _mdiParent, 1);
                    if (_mdiParent != null)
                    {
                        frm_MZ_BussinessReportmx.MdiParent = _mdiParent;
                    }
                    frm_MZ_BussinessReportmx.Show();
                    break;


                case "Fun_ts_zy_zkbrsrtj":
                    Frm_zkbrsrtj frm_zkbrsrtj = new Frm_zkbrsrtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_zkbrsrtj.MdiParent = _mdiParent;
                    }
                    frm_zkbrsrtj.Show();
                    break;

                case "Fun_ts_QueryBillJZToZy":
                    Frm_QueryBillJZToZy frm_QueryBillJZToZy = new Frm_QueryBillJZToZy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_QueryBillJZToZy.MdiParent = _mdiParent;
                    }
                    frm_QueryBillJZToZy.Show();
                    break;

                case "Fun_ts_QueryICUBillFromJZ":
                    Frm_QueryBuessinessOfTransfer frm_QueryICUBillFromJZ = new Frm_QueryBuessinessOfTransfer(_menuTag, _chineseName, _mdiParent, 1);
                    if (_mdiParent != null)
                    {
                        frm_QueryICUBillFromJZ.MdiParent = _mdiParent;
                    }
                    frm_QueryICUBillFromJZ.Show();
                    break;
                case "Fun_ts_DrugCostStatistics":
                    DrugCostStatistics DrugCostStatistics = new DrugCostStatistics(_menuTag, _chineseName, _mdiParent, 1);
                    if (_mdiParent != null)
                    {
                        DrugCostStatistics.MdiParent = _mdiParent;
                    }
                    DrugCostStatistics.Show();
                    break;
                case "Fun_ts_Hospital_BedDays":
                    Frm_ZY_Days frm_ZY_Days = new Frm_ZY_Days(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_ZY_Days.MdiParent = _mdiParent;
                    }
                    frm_ZY_Days.Show();
                    break;
                    
                //*************************************************************************//
                default:
                    throw new Exception("引出函数名称错误！");
            }

        }
        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mz_tjbb";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "门诊统计报表";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[97];
            objectInfos[0].Name = "Fun_ts_mz_tjbb_mzsk_zffs";
            objectInfos[0].Text = "门诊收款汇总统计";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_mz_jk_tj";
            objectInfos[1].Text = "收款员交款表";
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_mz_jk_tj_cx";
            objectInfos[2].Text = "收款员交款记录查询";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_mz_tjbb_mzsk_xmsrtj";
            objectInfos[3].Text = "门诊收费项目收款统计";
            objectInfos[3].Remark = "";
            objectInfos[4].Name = "Fun_ts_mz_tjbb_mzjk_xmsrtj";
            objectInfos[4].Text = "门诊收费项目缴款统计";
            objectInfos[4].Remark = "";
            objectInfos[5].Name = "Fun_ts_mz_tjbb_yssrtj";
            objectInfos[5].Text = "门诊医生收入统计";
            objectInfos[5].Remark = "";
            objectInfos[6].Name = "Fun_ts_mz_tjbb_kssrtj";
            objectInfos[6].Text = "门诊科室收入统计";
            objectInfos[6].Remark = "";
            objectInfos[7].Name = "Fun_ts_mz_tjbb_ghrctj";
            objectInfos[7].Text = "挂号人次统计";
            objectInfos[7].Remark = "";
            objectInfos[8].Name = "Fun_ts_mz_tjbb_jk_pos";
            objectInfos[8].Text = "门诊POS缴款情况统计";
            objectInfos[8].Remark = "";
            objectInfos[9].Name = "Fun_ts_mz_tjbb_sk_pos";
            objectInfos[9].Text = "门诊POS收款情况统计";
            objectInfos[9].Remark = "";
            objectInfos[10].Name = "Fun_ts_mz_tjbb_sk_htdw";
            objectInfos[10].Text = "门诊合同单位统计(收款)";
            objectInfos[10].Remark = "";
            objectInfos[11].Name = "Fun_ts_mz_tjbb_mzjk_zffs";
            objectInfos[11].Text = "门诊缴款汇总统计";
            objectInfos[11].Remark = "";
            objectInfos[12].Name = "Fun_ts_mz_tjbb_yb_rtj";
            objectInfos[12].Text = "门诊医保日统计(收款)";
            objectInfos[12].Remark = "";
            objectInfos[13].Name = "Fun_ts_mz_tjbb_yb_rtj_jk";
            objectInfos[13].Text = "门诊医保日统计(缴款)";
            objectInfos[13].Remark = "";
            objectInfos[14].Name = "Fun_ts_mz_tjbb_jk_htdw";
            objectInfos[14].Text = "门诊合同单位统计(缴款)";
            objectInfos[14].Remark = "";
            objectInfos[15].Name = "Fun_ts_mz_tjbb_kssrtj_zxks";
            objectInfos[15].Text = "门诊执行科室收入统计";
            objectInfos[15].Remark = "";
            objectInfos[16].Name = "Fun_ts_mz_tjbb_kssrtj_zxks_mx";
            objectInfos[16].Text = "门诊执行科室收入明细统计";
            objectInfos[16].Remark = "";
            objectInfos[17].Name = "Fun_ts_mz_tjbb_zdyzdcx";
            objectInfos[17].Text = "门诊自定义诊断查询";
            objectInfos[17].Remark = "";

            objectInfos[18].Name = "Fun_ts_mz_tjbb_sfygzltj";
            objectInfos[18].Text = "门诊收费员工作量统计";
            objectInfos[18].Remark = "";

            objectInfos[19].Name = "Fun_ts_mz_tjbb_ysjzltj";
            objectInfos[19].Text = "门诊医生接诊量统计";
            objectInfos[19].Remark = "";

            objectInfos[20].Name = "Fun_ts_mz_tjbb_blbzlktj";
            objectInfos[20].Text = "门诊病历本及诊疗卡统计";
            objectInfos[20].Remark = "";

            objectInfos[21].Name = "Fun_ts_mz_jk_tj_yjj";
            objectInfos[21].Text = "门诊自助机交款表";
            objectInfos[21].Remark = "";

            objectInfos[22].Name = "Fun_ts_mz_sk_tj_yjjcx";
            objectInfos[22].Text = "预交金明细查询";
            objectInfos[22].Remark = "";

            objectInfos[23].Name = "Fun_ts_mz_yjjdz";
            objectInfos[23].Text = "预交金消费对帐";
            objectInfos[23].Remark = "";

            objectInfos[24].Name = "Fun_ts_mz_yjjjcqk";
            objectInfos[24].Text = "预交金结存情况";
            objectInfos[24].Remark = "";

            objectInfos[25].Name = "Fun_ts_mz_yjtj";
            objectInfos[25].Text = "门诊预交统计";
            objectInfos[25].Remark = "";

            objectInfos[26].Name = "Fun_ts_mz_tjbb_DeptSrbl";
            objectInfos[26].Text = "门诊医生医疗/药品收入统计(全部)";
            objectInfos[26].Remark = "";

            objectInfos[27].Name = "Fun_ts_mz_tjbb_UserSrbl";
            objectInfos[27].Text = "门诊医生医疗/药品收入统计(医生)";
            objectInfos[27].Remark = "";

            objectInfos[28].Name = "Fun_ts_mz_tjbb_DeptSrbl_ks";
            objectInfos[28].Text = "门诊医生医疗/药品收入统计(科室)";
            objectInfos[28].Remark = "";

            objectInfos[29].Name = "Fun_ts_mz_tjbb_mzwjk_zffs";
            objectInfos[29].Text = "门诊未缴款汇总统计";
            objectInfos[29].Remark = "";

            objectInfos[30].Name = "Fun_ts_mz_tjbb_ybjstj";
            objectInfos[30].Text = "门诊医保结算情况统计";
            objectInfos[30].Remark = "";

            objectInfos[31].Name = "Fun_ts_mz_zffp";
            objectInfos[31].Text = "门诊废票统计";
            objectInfos[31].Remark = "";

            objectInfos[32].Name = "Fun_ts_mz_tjbb_mzsrrbb";
            objectInfos[32].Text = "门诊收入日报表";
            objectInfos[32].Remark = "";
            //Add By Zj 2012-05-10 门诊科室日收入报表
            objectInfos[33].Name = "Fun_ts_mz_tjbb_mzkssrrbb";
            objectInfos[33].Text = "门诊科室收入日报表";
            objectInfos[33].Remark = "";
            //Add By Zj 2012-05-14 医生收入药品比例
            objectInfos[33].Name = "Fun_ts_mz_tjbb_ysypbl";
            objectInfos[33].Text = "医生药品比例";
            objectInfos[33].Remark = "";

            //Add by Kevin 2012-06-07  银医诊疗卡办卡数统计
            objectInfos[34].Name = "Fun_ts_mz_tjbb_yyzlkbk";
            objectInfos[34].Text = "银医诊疗卡办卡数统计";
            objectInfos[34].Remark = "";

            //Add by Kevin 2012-06-07  银医诊疗卡支付方式统计
            objectInfos[35].Name = "Fun_ts_mz_tjbb_yyzlkzffs";
            objectInfos[35].Text = "银医诊疗卡支付方式统计";
            objectInfos[35].Remark = "";

            //Add by Kevin 2012-06-07  银医退卡退预交金统计
            objectInfos[36].Name = "Fun_ts_mz_tjbb_yytktyyj";
            objectInfos[36].Text = "银医退卡退预交金统计";
            objectInfos[36].Remark = "";

            //Add By kevin 2012-07-27 工商隐含自助机对账统计
            objectInfos[37].Name = "Fun_ts_mz_tjbb_icbcdztj";
            objectInfos[37].Text = "工商银行自助机对账统计";
            objectInfos[37].Remark = "";

            objectInfos[38].Name = "Fun_ts_mz_tjbb_mzyjjxfdz";
            objectInfos[38].Text = "预交金消费对账统计";
            objectInfos[38].Remark = "";

            //Add By Kevin 2012-09-24 湘东交款表 特殊要求
            objectInfos[39].Name = "Fun_ts_mz_jk_tj_date";
            objectInfos[39].Text = "收款员交款表(按时间点加载收费员)";
            objectInfos[39].Remark = "";
            //Add By Kevin 2012-10-10 马王堆医院 要求交款确认报表
            objectInfos[40].Name = "Fun_ts_mz_jk_tj_cx_qr";
            objectInfos[40].Text = "收款员交款记录查询(需确认交款记录)";
            objectInfos[40].Remark = "";

            //Add by zj 2012-12-27  诊疗卡办卡数统计
            objectInfos[41].Name = "Fun_ts_mz_tjbb_yyzlkbk_all";
            objectInfos[41].Text = "诊疗卡办卡数统计";
            objectInfos[41].Remark = "";

            //Add by zj 2013-01-05  诊疗卡办卡数统计
            objectInfos[42].Name = "Fun_ts_mz_tjbb_zlkbktj";
            objectInfos[42].Text = "诊疗卡办卡数统计";
            objectInfos[42].Remark = "";
            //Add by zj 2013-02-20  门诊科室收入药品分类统计
            objectInfos[43].Name = "Fun_ts_mz_tjbb_kssrtjypfl";
            objectInfos[43].Text = "门诊科室收入药品分类统计";
            objectInfos[43].Remark = "";
            //add by zouchihua 2013-4-27
            objectInfos[44].Name = "Fun_ts_mz_tjbb_yjjszqktj";
            objectInfos[44].Text = "门诊预交金收支情况统计";
            objectInfos[44].Remark = "";
            //add by zouchihua 2013-4-27
            objectInfos[45].Name = "Fun_ts_mz_tjbb_zlksrtj";
            objectInfos[45].Text = "门诊诊疗卡收入统计";
            objectInfos[45].Remark = "";
            //add by zp 2013-07-18 八医院需求 允许通过多个时间段统计数据
            objectInfos[46].Name = "Fun_ts_mz_tjbb_jjrsrtjbydate";
            objectInfos[46].Text = "门诊科室节假日收入统计";
            objectInfos[46].Remark = "";
            //add by zp 2013-07-19 八医院需求 允许通过多个时间段统计数据
            objectInfos[47].Name = "Fun_ts_mz_tjbb_yssrtjBydate";
            objectInfos[47].Text = "门诊医生节假日收入统计";
            objectInfos[47].Remark = "";
            //add by zp 2013-07-19 八医院需求 允许通过多个时间段统计数据
            objectInfos[48].Name = "Fun_ts_mz_tjbb_kssrtj_zxksBydate";
            objectInfos[48].Text = "门诊执行科室节假日收入统计";
            objectInfos[48].Remark = "";

            ////add by zp 2013-07-19 八医院需求 允许通过多个时间段统计数据
            //objectInfos[49].Name = "Fun_ts_mz_tjbb_kssrtj_zxks_mxBydate";
            //objectInfos[49].Text = "门诊执行科室节假日收入明细统计";
            //objectInfos[49].Remark = "";

            objectInfos[49].Name = "Fun_ts_mz_tjbb_ysjzltjBydate";
            objectInfos[49].Text = "门诊医生接诊量多时段统计";
            objectInfos[49].Remark = "";

            objectInfos[50].Name = "Fun_MZ_GH_ZL_JC";
            objectInfos[50].Text = "门诊医生日常工作量统计";
            objectInfos[50].Remark = "";

            //Fun_ts_mz_yjjyeqk
            objectInfos[51].Name = "Fun_ts_mz_yjjyeqk";
            objectInfos[51].Text = "预交款余额情况表";
            objectInfos[51].Remark = "";

            //Add By Kevin 2014-06-10 建设银行自助机对账统计
            objectInfos[52].Name = "Fun_ts_mz_tjbb_ccbdztj";
            objectInfos[52].Text = "建设银行自助机对账统计";
            objectInfos[52].Remark = "";

            //Add By Kevin 2014-06-27 儿童子科室收入统计
            objectInfos[53].Name = "Fun_ts_mz_tjbb_etzkssrtj";
            objectInfos[53].Text = "门诊儿童保健子科室收入统计";
            objectInfos[53].Remark = "";

            //Add By Fangke 2014-10-29 门诊科室医保收入统计
            objectInfos[54].Name = "Fun_ts_mz_tjbb_ksybsrtj";
            objectInfos[54].Text = "门诊科室医保收入统计";
            objectInfos[54].Remark = "";
       
            //Add By Fangke 2014-11-3
            objectInfos[55].Name = "Fun_ts_mz_tjbb_yjksgzltj";
            objectInfos[55].Text = "医技科室工作量统计";
            objectInfos[55].Remark = "";

            //Add By Fangke 2014-11-13
            objectInfos[56].Name = "Fun_ts_mz_tjbb_jkpjtj";
            objectInfos[56].Text = "交款票据统计";
            objectInfos[56].Remark = ""; 

             //Add By 2014 2014-12-20
            objectInfos[57].Name = "Fun_ts_tjbb_sfygrjkfptj";
            objectInfos[57].Text = "收费员个人交款发票统计";
            objectInfos[57].Remark = "";

            objectInfos[58].Name = "Fun_ts_tjbb_htdw_dzqr";
            objectInfos[58].Text = "合同单位到账确认";
            objectInfos[58].Remark = "";
            //Add by Hxy 2015-02-02
            objectInfos[59].Name = "Fun_ts_mz_tjbb_ylzjjdztj";
            objectInfos[59].Text = "交通银行自助机对账统计";
            objectInfos[59].Remark = "";

            //**********************************************Add By leidong***************************//
            //Add By leidong 2014-12-16
            objectInfos[60].Name = "Fun_ts_jg_DepartmentGroup";
            objectInfos[60].Text = "部门三级归组";
            objectInfos[60].Remark = "部门三级归组";

            //Add By leidong 2014-12-16
            objectInfos[61].Name = "Fun_ts_jg_IncomeReport";
            objectInfos[61].Text = "业务收入情况分析报表";
            objectInfos[61].Remark = "业务收入情况分析报表";

            //Add By leidong 2014-12-17
            objectInfos[62].Name = "Fun_ts_jg_itemGroup";
            objectInfos[62].Text = "收入项目分类";
            objectInfos[62].Remark = "收入项目分类";

            //Add By leidong 2014-12-19
            objectInfos[63].Name = "Fun_ts_jg_IncomeReport_Drugs";
            objectInfos[63].Text = "药品业务收入情况分析报表";
            objectInfos[63].Remark = "药品业务收入情况分析报表";



            //Add By leidong 2014-12-23
            objectInfos[64].Name = "Fun_ts_jg_IncomeReport_MedicalTechnology";
            objectInfos[64].Text = "医技业务收入情况分析报表";
            objectInfos[64].Remark = "医技业务收入情况分析报表";

            //Add By leidong 2014-12-23
            objectInfos[65].Name = "Fun_ts_jg_IncomeReport_MedicalService";
            objectInfos[65].Text = "医疗业务收入情况分析报表";
            objectInfos[65].Remark = "医疗业务收入情况分析报表";

            //Add By leidong 2015-01-04
            objectInfos[66].Name = "Fun_ts_jg_IcomeReport_Operation";
            objectInfos[66].Text = "手术室业务收入情况分析报表（住院）";
            objectInfos[66].Remark = "手术室业务收入情况分析报表（住院）";

            //Add By leidong 2015-01-04
            objectInfos[67].Name = "Fun_ts_jg_IcomeReport_Anesthesia";
            objectInfos[67].Text = "麻醉科业务收入情况分析报表";
            objectInfos[67].Remark = "麻醉科业务收入情况分析报表";

            //Add By leidong 2015-01-06
            objectInfos[68].Name = "Fun_ts_jg_IcomeReport_Chinese";
            objectInfos[68].Text = "中医特色治疗项目绩效明细表";
            objectInfos[68].Remark = "中医特色治疗项目绩效明细表";

            //Add By leidong 2015-01-08
            objectInfos[69].Name = "Fun_ts_jg_IncomeReport_Drugs_1";
            objectInfos[69].Text = "药品业务收入情况分析报表(含自制药比例)";
            objectInfos[69].Remark = "药品业务收入情况分析报表(含自制药比例)";

            //Add By leidong 2015-01-08
            objectInfos[70].Name = "Fun_ts_jg_IncomeReport_Drugs_2";
            objectInfos[70].Text = "药品业务收入情况分析报表(非自制药比例)";
            objectInfos[70].Remark = "药品业务收入情况分析报表(非自制药比例)";

            //Add By leidong 2015-01-12
            objectInfos[71].Name = "Fun_ts_MZ_BussinessReport";
            objectInfos[71].Text = "门诊业务收入统计";
            objectInfos[71].Remark = "门诊业务收入统计";


            //Add By leidong 2015-01-12
            objectInfos[72].Name = "Fun_ts_MZ_QueryHighAmount";
            objectInfos[72].Text = "门诊大额处方统计";
            objectInfos[72].Remark = "门诊大额处方统计";

            //Add By leidong 2015-01-13
            objectInfos[73].Name = "Fun_ts_MZ_BussinessOfZXKS";
            objectInfos[73].Text = "门诊执行收入统计";
            objectInfos[73].Remark = "门诊执行收入统计";

            //Add By leidong 2015-01-14
            objectInfos[74].Name = "Fun_ts_MZ_RecipelofDrugsQuery";
            objectInfos[74].Text = "门诊药品处方统计";
            objectInfos[74].Remark = "门诊药品处方统计";



            //Add By leidong 2015-01-15
            objectInfos[75].Name = "Fun_ts_MZ_QueryBussinessOfDoc";
            objectInfos[75].Text = "医生收入统计查询";
            objectInfos[75].Remark = "医生收入统计查询";

            //Add By leidong 2015-01-16
            objectInfos[76].Name = "Fun_ts_MZ_QueryBRCount";
            objectInfos[76].Text = "门急诊人次统计";
            objectInfos[76].Remark = "门急诊人次统计";


            //Add By leidong 2015-01-16
            objectInfos[77].Name = "Fun_ts_ZY_WorkLogOfWard";
            objectInfos[77].Text = "病房工作日志";
            objectInfos[77].Remark = "病房工作日志";

            //Add By leidong 2015-01-16
            objectInfos[78].Name = "Fun_ts_QuerySomeYJItemCount";
            objectInfos[78].Text = "医技科室项目人次统计";
            objectInfos[78].Remark = "医技科室项目人次统计";

            //Add By leidong 2015-01-22
            objectInfos[79].Name = "Fun_ts_jg_IncomeReport_Dept";
            objectInfos[79].Text = "科室业务收入情况统计";
            objectInfos[79].Remark = "科室业务收入情况统计";

            //Add By leidong 2015-02-03
            objectInfos[80].Name = "Fun_ts_ZY_BussinessReport";
            objectInfos[80].Text = "住院业务收入统计";
            objectInfos[80].Remark = "住院业务收入统计";

            //Add By leidong 2015-02-10
            objectInfos[81].Name = "Fun_ts_ReportBuessinessQuerybyDoc";
            objectInfos[81].Text = "医生业务收入统计";
            objectInfos[81].Remark = "医生业务收入统计";


            //Add By leidong 2015-02-10
            objectInfos[82].Name = "Fun_ts_ReportBuessinessQuerybyDept";
            objectInfos[82].Text = "科室业务收入统计";
            objectInfos[82].Remark = "科室业务收入统计";


            //Add By leidong 2015-02-11
            objectInfos[83].Name = "Fun_ts_QueryBussinessOfOperation";
            objectInfos[83].Text = "门诊手术麻醉收入统计";
            objectInfos[83].Remark = "门诊手术麻醉收入统计";


            //Add By leidong 2015-03-04
            objectInfos[84].Name = "Fun_ts_QueryBuessinessOfTransfer";
            objectInfos[84].Text = "ICU转科收入统计";
            objectInfos[84].Remark = "ICU转科收入统计";


            //Add By leidong 2015-03-04
            objectInfos[85].Name = "Fun_ts_QueryBuessinessOfOperation";
            objectInfos[85].Text = "手术室计入病人科室收入查询";
            objectInfos[85].Remark = "手术室计入病人科室收入查询";

            //Fun_ts_QueryBuessinessOfSingleItem
            //Add By leidong 2015-03-09
            objectInfos[86].Name = "Fun_ts_QueryBuessinessOfSingleItem";
            objectInfos[86].Text = "单个项目收入统计查询";
            objectInfos[86].Remark = "单个项目收入统计查询";


            //Add By leidong 2015-03-10
            objectInfos[87].Name = "Fun_ts_MZ_QueryMZQK";
            objectInfos[87].Text = "门诊接诊情况统计";
            objectInfos[87].Remark = "门诊接诊情况统计";

            //Add By leidong 2015-03-11
            objectInfos[88].Name = "Fun_ts_Zy_LackDisChargeReport";
            objectInfos[88].Text = "住院欠费结算明细报表";
            objectInfos[88].Remark = "住院欠费结算明细报表";

            //Add By leidong 2015-03-13
            objectInfos[89].Name = "Fun_ts_Zy_ZXSRTJ";
            objectInfos[89].Text = "住院执行收入统计";
            objectInfos[89].Remark = "住院执行收入统计";


            //Add By leidong 2015-03-17
            objectInfos[90].Name = "Fun_ts_QueryBuessinessOfSingleDrugItem";
            objectInfos[90].Text = "中药饮片收入统计查询";
            objectInfos[90].Remark = "中药饮片收入统计查询";

            //Add By leidong 2015-03-19
            objectInfos[91].Name = "Fun_ts_MZ_BussinessReport_mx";
            objectInfos[91].Text = "门诊业务收入明细";
            objectInfos[91].Remark = "门诊业务收入明细";

            //   
            //Add By leidong 2015-03-26
            objectInfos[92].Name = "Fun_ts_zy_zkbrsrtj";
            objectInfos[92].Text = "转科病人收入统计";
            objectInfos[92].Remark = "转科病人收入统计";

            //Add By leidong 2015-04-01
            objectInfos[93].Name = "Fun_ts_QueryBillJZToZy";
            objectInfos[93].Text = "急诊转住院费用查询";
            objectInfos[93].Remark = "急诊转住院费用查询";

            //Add By leidong 2015-04-01
            objectInfos[94].Name = "Fun_ts_QueryICUBillFromJZ";
            objectInfos[94].Text = "ICU收入查询（急诊转入）";
            objectInfos[94].Remark = "ICU收入查询（急诊转入）";

            //Add By bill 2015-08-21
            objectInfos[95].Name = "Fun_ts_DrugCostStatistics";
            objectInfos[95].Text = "药品费用统计";
            objectInfos[95].Remark = "药品费用统计";

            //Add By bill 2015-08-21
            objectInfos[96].Name = "Fun_ts_Hospital_BedDays";
            objectInfos[96].Text = "住院病人床位日统计";
            objectInfos[96].Remark = "住院病人床位日统计";
            //**************************************************************************************//



            return objectInfos;
        }
        #endregion

        #endregion
    }
}
