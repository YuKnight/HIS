using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
namespace ts_mz_class
{
    public class Fun
    {
        /// <summary>
        /// 产生新门诊号
        /// </summary>
        /// <returns>门诊号</returns>
        public static string GetNewMzh(RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@JGBM";
                parameters[0].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                parameters[1].Text = "@MZH";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].ParaSize = 100;

                _DataBase.DoCommand("SP_MZGH_NEWMZH", parameters, 30);

                string mzh = Convert.ToString(parameters[1].Value);
                return mzh;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        /// <summary>
        /// 产生新的电脑流水号
        /// </summary>
        /// <returns></returns>
        public static string GetNewDnlsh(RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@JGBM";
                parameters[0].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                parameters[1].Text = "@DNLSH";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].ParaSize = 100;

                _DataBase.DoCommand("SP_MZ_NEW_DNLSH", parameters, 30);

                string dnlsh = Convert.ToString(parameters[1].Value);
                return dnlsh;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        /// <summary>
        /// 获取新的个人帐户编号
        /// </summary>
        /// <returns></returns>
        public static string GetNewGrzhbh(RelationalDatabase _DataBase)
        {
            string ssql = "update JC_IDENTITY set no=no+1 where rowtype=12";
            int result = Convert.ToInt32(_DataBase.GetDataResult(ssql));
            string ssql1 = "select '9'+left('00000000',8-len([NO]))+cast([no] as varchar(30)) from JC_IDENTITY where rowtype=12";
            return Convert.ToInt64(Convertor.IsNull(_DataBase.GetDataResult(ssql1), "")).ToString();
        }

        /// <summary>
        /// 获取挂号科室 001 普通挂号科室 003 急诊挂号科室
        /// </summary>
        /// <param name="jzks">急诊挂号</param>
        /// <returns></returns>
        public static DataTable GetGhks(bool jzks, RelationalDatabase _DataBase)
        {
            string ssql = "";
            SystemCfg cfg = new SystemCfg(1057, _DataBase);
            if (jzks == false)
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where layer=3 and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in(" + cfg.Config + "))";
            else
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where layer=3 and  jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in('003'))";
            return _DataBase.GetDataTable(ssql);
        }

        /// <summary>
        /// 入院科室
        /// </summary>
        /// <param name="jgbm"></param>
        /// <returns></returns>
        public static DataTable GetRyks(long jgbm, RelationalDatabase _DataBase)
        {
            string ssql = "";
            ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where jgbm=" + jgbm + " and deleted=0 " +
                         " and dept_id in (select dept_id from jc_dept_type_relation where type_code in('004'))";

            return _DataBase.GetDataTable(ssql);
        }

        /// <summary>
        /// 获取挂号医生 
        /// </summary>
        /// <param name="jb">按级别检索</param>
        /// <returns></returns>
        public static DataTable GetGhys(int jb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            ssql = @"select a.employee_id,a.name,b.ys_code,isnull(c.code,'') code,a.py_code,a.wb_code " +
                     " from jc_employee_property a " +
                     " inner join jc_role_doctor b on a.employee_id=b.employee_id " +
                     " left join pub_user c on a.employee_id=c.employee_id " + //Modify By Tany 2008-12-19 不一定有工号
                     " where a.delete_bit=0";
            if (jb > 0)
                ssql = ssql + " and ys_typeid=" + jb + "";
            return _DataBase.GetDataTable(ssql);
        }
        /// <summary>
        /// 获取挂号医生 
        /// </summary>
        /// <param name="jb">按科室和级别检索</param>
        /// <returns></returns>
        public static DataTable GetGhys(int ksdm, int jb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            ssql = @"select a.employee_id,a.name,b.ys_code,isnull(c.code,'') code,a.py_code,a.wb_code " +
                     " from jc_employee_property a " +
                     " inner join jc_role_doctor b on a.employee_id=b.employee_id " +
                     " left join pub_user c on a.employee_id=c.employee_id " + //Modify By Tany 2008-12-19 不一定有工号
                     " where a.delete_bit=0";
            if (jb > 0)
                ssql = ssql + " and ys_typeid=" + jb + "";
            if (ksdm > 0)
                ssql = ssql + " and a.employee_id in(select employee_id from JC_EMP_DEPT_ROLE where dept_id=" + ksdm + ")";
            return _DataBase.GetDataTable(ssql);
        }

        /// <summary>
        ///  获取挂号级别 Add By zp 2013-10-28
        /// </summary>
        /// <param name="all">是否新增全部 true新增行全部</param>
        /// <param name="ghjb">为0表示获取所有级别 否则获取指定级别</param>
        /// <param name="_DataBase"></param>
        public static DataTable GetGhjb(bool all, int ghjb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (ghjb == 0)
                ssql = "SELECT TYPE_ID,type_name,WB_CODE,PY_CODE from jc_doctor_type order by type_id";
            else
                ssql = "SELECT TYPE_ID,type_name,WB_CODE,PY_CODE from jc_doctor_type where type_id=" + ghjb;
            DataTable tb = _DataBase.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["TYPE_ID"] = "0";
                row["type_name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            return tb;
        }
        //获取医生职称级别 Add by zp 2013-12-16
        public static DataTable GetZcjb(bool all, int zcjb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (zcjb == 0)
                ssql = "SELECT zcjb,type_name,WB_CODE,PY_CODE from jc_doctor_type order by zcjb";
            else
                ssql = "SELECT zcjb,type_name,WB_CODE,PY_CODE from jc_doctor_type where zcjb=" + zcjb;
            DataTable tb = _DataBase.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["zcjb"] = "0";
                row["type_name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            return tb;
        }
        //获取医生对应的职称级别 Add by zp 2013-12-16
        public static int GetDocZcjb(int Employee_id, RelationalDatabase _DataBase)
        {
            int zcjb = 0;
            string sql = @"select YS_TYPEID as zcjb  from JC_ROLE_DOCTOR  where EMPLOYEE_ID =" + Employee_id + "";
            zcjb = Convert.ToInt32(Convertor.IsNull(_DataBase.GetDataResult(sql), "0"));
            return zcjb;
        }
        //获取jc_doct_type表信息 add by zp 2013-12-16
        public static DataTable GetJC_Doc_Type(RelationalDatabase _DataBase)
        {
            string sql = @"SELECT * FROM JC_DOCTOR_TYPE";
            DataTable dt = _DataBase.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 格式化门诊号
        /// </summary>
        /// <param name="mzh"></param>
        /// <returns></returns>
        public static string returnMzh(string mzh, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@JGBM";
                parameters[0].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                parameters[1].Text = "@input";
                parameters[1].Value = mzh;

                parameters[2].Text = "@MZH";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                _DataBase.DoCommand("SP_MZGH_GETMZH", parameters, 30);

                string smzh = Convert.ToString(parameters[2].Value);
                return smzh;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        public static string returnMzh(string mzh)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@JGBM";
                parameters[0].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                parameters[1].Text = "@input";
                parameters[1].Value = mzh;

                parameters[2].Text = "@MZH";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("SP_MZGH_GETMZH", parameters, 30);

                string smzh = Convert.ToString(parameters[2].Value);
                return smzh;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        public static string returnKh(int klx, string kh, RelationalDatabase _DataBase)
        {
            if (klx == 0) return "";
            string ssql = "select kcd from JC_KLX where klx=" + klx + "";
            DataTable tb = _DataBase.GetDataTable(ssql);
            string temp = "00000000000000000000000000000000000000000000000";
            int N = Convert.ToInt32(tb.Rows[0][0]);
            if (kh.Length > N) return kh;
            return temp.Substring(0, N - kh.Length) + kh;
        }
        public static string returnKh(int klx, string kh)
        {
            if (klx == 0) return "";
            string ssql = "select kcd from JC_KLX where klx=" + klx + "";
            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(ssql);
            string temp = "00000000000000000000000000000000000000000000000";
            int N = Convert.ToInt32(tb.Rows[0][0]);
            if (kh.Length > N) return kh;
            return temp.Substring(0, N - kh.Length) + kh;
        }
        /// <summary>
        /// 格式化发票号
        /// </summary>
        /// <param name="fph"></param>
        /// <returns></returns>
        public static string returnFph(string fph, RelationalDatabase _DataBase)
        {
            string n = new SystemCfg(1016).Config;
            string temp = "0000000000000000";
            int N = Convert.ToInt32(n);
            if (fph.Length > N) return fph;
            return temp.Substring(0, N - fph.Length) + fph;
        }

        public static string returnDnlsh(string lsh, RelationalDatabase _DataBase)
        {
            string date = DateManager.ServerDateTimeByDBType(_DataBase).ToString("yyMMdd");
            string ss = date + TrasenFrame.Forms.FrmMdiMain.JgYybm.ToString() + "000000";
            ss = ss.Remove(ss.Length - lsh.Length, lsh.Length);
            ss = ss + lsh;
            return ss;
        }

        /// <summary>
        /// 通过科室ID返回名称
        /// </summary>
        /// <param name="deptid">科室ID</param>
        /// <returns></returns>
        public static string SeekDeptName(int deptid, RelationalDatabase _DataBase)
        {
            string ssql = "select dbo.fun_getDeptname(" + deptid + ") name ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return tb.Rows[0]["name"].ToString();
            else
                return "";
        }
        /// <summary>
        /// 通过科室ID获得科室类型 Add By Zj 2012-05-15
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static string SeekDeptType(int deptid, RelationalDatabase _DataBase)
        {
            string ssql = "select * from JC_DEPT_TYPE_RELATION where TYPE_CODE='003' AND DEPT_ID=" + deptid + "";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return "2"; //急诊
            else
                return "1";//门诊
        }
        /// <summary>
        /// 通过人员ID返回名称
        /// </summary>
        /// <param name="employeeid">人员ID</param>
        /// <returns></returns>
        public static string SeekEmpName(int employeeid, RelationalDatabase _DataBase)
        {
            string ssql = "select dbo.fun_getEmpName(" + employeeid + ") name ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return tb.Rows[0]["name"].ToString();
            else
                return "";
        }
        /// <summary>
        /// 卡类型名称
        /// </summary>
        /// <param name="klx">卡类型</param>
        /// <returns></returns>
        public static string SeekKlxmc(int klx, RelationalDatabase _DataBase)
        {
            string ssql = "select  klxmc from JC_KLX where klx=" + klx + " ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return tb.Rows[0]["klxmc"].ToString();
            else
                return "";
        }

        /// <summary>
        /// 挂号级别
        /// </summary>
        /// <param name="ghjb">挂号级别</param>
        /// <returns></returns>
        public static string SeekGhjbName(int ghjb, RelationalDatabase _DataBase)
        {
            string ssql = "select  type_name from jc_doctor_type where type_id=" + ghjb + " ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return tb.Rows[0]["type_name"].ToString();
            else
                return "";
        }

        /// <summary>
        /// 获得优惠类型的名称
        /// </summary>
        /// <param name="yhlxid"></param>
        /// <returns></returns>
        public static string SeekYhlxMc(Guid yhlxid, RelationalDatabase _DataBase)
        {
            string ssql = "select yhmc from JC_yhlx where id='" + yhlxid + "' ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return tb.Rows[0]["yhmc"].ToString();
            else
                return "";
        }
        /// <summary>
        /// 获得文化程度的名称
        /// </summary>
        /// <param name="whcddm"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static string SeekWhcd(int whcddm, RelationalDatabase _DataBase)
        {
            string ssql = "select NAME from JC_WHCD where CODE=" + whcddm + " ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return tb.Rows[0]["NAME"].ToString();
            else
                return "";
        }
        /// <summary>
        /// 合同单位类型
        /// </summary>
        /// <param name="htdwlx"></param>
        /// <returns></returns>
        public static string SeekHtdwLx(int htdwlx, RelationalDatabase _DataBase)
        {
            string ssql = "select lxmc from jc_htdwlx where id='" + htdwlx + "' ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return tb.Rows[0]["lxmc"].ToString();
            else
                return "";
        }
        /// <summary>
        /// 合同单位名称
        /// </summary>
        /// <param name="htdwlx"></param>
        /// <returns></returns>
        public static string SeekHtdwMc(int htdwid, RelationalDatabase _DataBase)
        {
            string ssql = "select dwmc from jc_htdw where id='" + htdwid + "' ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return tb.Rows[0]["dwmc"].ToString();
            else
                return "";
        }

        /// <summary>
        /// 获取选定医生的门诊坐诊科室
        /// </summary>
        /// <param name="employee_id"></param>
        /// <returns></returns>
        public static int GetDocMzks(int employee_id, long jgbm, RelationalDatabase _DataBase)
        {
            SystemCfg cfg = new SystemCfg(1057, _DataBase);
            string ssql = @"select * from JC_EMP_DEPT_ROLE a ,jc_dept_property b  where a.dept_id=b.dept_id and employee_id=" + employee_id +
                "and a.dept_id in(select dept_id from jc_dept_type_relation  " +
                "where type_code in(" + cfg.Config + ")) and b.jgbm=" + jgbm + " order by [default] desc";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
                return 0;
            else
                return Convert.ToInt32(tb.Rows[0]["dept_id"]);
        }
        /// <summary>
        /// 获取选定医生的住院坐诊科室
        /// </summary>
        /// <param name="employee_id"></param>
        /// <returns></returns>
        public static int GetDocZyks(int employee_id, long jgbm, RelationalDatabase _DataBase)
        {
            string ssql = @"select * from JC_EMP_DEPT_ROLE a ,jc_dept_property b  where a.dept_id=b.dept_id and  employee_id=" + employee_id +
              "  and a.dept_id in(select dept_id from jc_dept_type_relation" +
              " where type_code in('004','008'))  and b.jgbm=" + jgbm + "";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
                return 0;
            else
                return Convert.ToInt32(tb.Rows[0]["dept_id"]);
        }
        /// <summary>
        /// 获取人员类型
        /// Add By Zj 2012-06-06
        /// </summary>
        /// <param name="employee_id"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static int GetEmpType(int employee_id, RelationalDatabase _DataBase)
        {
            string ssql = "select RYLX from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + employee_id + " and delete_bit=0";
            int result = Convert.ToInt32(_DataBase.GetDataResult(ssql));
            return result;
        }
        /// <summary>
        /// 通过挂号信息id获取病人信息id Add by zp 2013-10-21
        /// </summary>
        /// <param name="ghxxid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static Guid GetBrxxId(Guid ghxxid, RelationalDatabase _DataBase)
        {
            string ssql = string.Format(@"select brxxid from mz_ghxx where ghxxid='{0}'", ghxxid);
            string brxxid = _DataBase.GetDataResult(ssql).ToString();
            return new Guid(brxxid);
        }
        /// <summary>
        /// 通过科室代码获取人员信息 Add By zp 2013-10-21
        /// </summary>
        /// <param name="ksdm"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetEmpInfo(int ksdm, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"select a.* from 
                        jc_employee_property a ,JC_EMP_DEPT_ROLE b
                    where a.employee_id=b.employee_id ";
                if (ksdm > 0)
                    sql += " and dept_id=" + ksdm + "";
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        /// <summary>
        /// 获取诊间名称
        /// </summary>
        /// <param name="zjid"></param>
        /// <returns></returns>
        public static string GetZsMc(int zjid, RelationalDatabase _DataBase)
        {
            string ssql = @"select zjmc from jc_zjsz where zjid=" + zjid + "";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
                return "";
            else
                return Convertor.IsNull(tb.Rows[0]["zjmc"], "");
        }
        /// <summary>
        /// 获得发票号结果集
        /// </summary>
        /// <param name="sfy">收费员</param>
        /// <param name="fpzs">发票张数</param>
        /// <param name="fplx">发票类型</param>
        /// <param name="err_code">错误号</param>
        /// <param name="err_text">错误文本</param>
        /// <returns></returns>
        public static DataTable GetFph(int sfy, int fpzs, int fplx, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@sfy";
                parameters[0].Value = sfy;

                parameters[1].Text = "@fpzs";
                parameters[1].Value = fpzs;

                parameters[2].Text = "@fplx";
                parameters[2].Value = fplx;

                parameters[3].Text = "@err_code";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].DataType = System.Data.DbType.Int32;
                parameters[3].ParaSize = 100;

                parameters[4].Text = "@err_text";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].ParaSize = 100;

                DataTable tb = _DataBase.GetDataTable("SP_MZSF_GetFph", parameters, 30);
                err_code = Convert.ToInt32(parameters[3].Value);
                err_text = Convert.ToString(parameters[4].Value);
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        #region 输入法开与关
        /// <summary>
        /// 关闭输入法
        /// </summary>
        public static void SetInputLanguageOff()
        {
            InputLanguageCollection ilc = InputLanguage.InstalledInputLanguages;

            string ilName = Constant.CustomImeMode;

            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                InputLanguage il = InputLanguage.InstalledInputLanguages[i];
                if (il.LayoutName == ilName)
                {
                    InputLanguage.CurrentInputLanguage = il;

                    return;
                }
            }

        }

        /// <summary>
        /// 打开输入法
        /// </summary>
        public static void SetInputLanguageOn()
        {
            InputLanguageCollection ilc = InputLanguage.InstalledInputLanguages;
            string customInputLanguage = ApiFunction.GetIniString("INPUTLANGUAGE", "N" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode, Constant.ApplicationDirectory + "//CustomInputLanguage.ini");
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                InputLanguage il = InputLanguage.InstalledInputLanguages[i];
                if (il.LayoutName == customInputLanguage)
                {
                    InputLanguage.CurrentInputLanguage = il;
                    return;
                }
            }
        }

        /// <summary>
        /// 获取收费项目和药品
        /// </summary>
        /// <param name="all">下载药品和项目  1 下载 0  实时查询 以下各项 @all=0 时有效</param>
        /// <param name="xmly">0 全部 1 药品 2 项目 </param>
        /// <param name="zyyf">是否查找住院药房 1 查找</param>
        /// <param name="execdept">执行科室</param>
        /// <param name="deptid">当前科室</param>
        /// <param name="pym"></param>
        /// <param name="wbm"></param>
        /// <param name="itemname"></param>
        /// <returns></returns>
        public static DataTable GetXmYp(int all, int xmly, int zyyf, int execdept, int deptid, string pym, string wbm, string itemname, string Funname, long jgbm, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[10];

                parameters[0].Text = "@all";
                parameters[0].Value = all;
                parameters[1].Text = "@xmly";
                parameters[1].Value = xmly;
                parameters[2].Text = "@zyyf";
                parameters[2].Value = zyyf;
                parameters[3].Text = "@execdept";
                parameters[3].Value = execdept;
                parameters[4].Text = "@deptid";
                parameters[4].Value = deptid;
                parameters[5].Text = "@pym";
                parameters[5].Value = pym;
                parameters[6].Text = "@wbm";
                parameters[6].Value = wbm;
                parameters[7].Text = "@itemname";
                parameters[7].Value = itemname;
                parameters[8].Text = "@FunName";
                parameters[8].Value = Funname;
                parameters[9].Text = "@jgbm";
                parameters[9].Value = jgbm;


                DataTable tb = _DataBase.GetDataTable("SP_MZSF_SelectXmYp", parameters, 30);
                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }
        public static DataTable GetXmYp_YZ(int all, int xmly, int zyyf, int execdept, int deptid, string pym, string wbm, string itemname, long jgbm, int sjkz, RelationalDatabase _DataBase, string funname)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[11];

                parameters[0].Text = "@all";
                parameters[0].Value = all;
                parameters[1].Text = "@xmly";
                parameters[1].Value = xmly;
                parameters[2].Text = "@zyyf";
                parameters[2].Value = zyyf;
                parameters[3].Text = "@execdept";
                parameters[3].Value = execdept;
                parameters[4].Text = "@deptid";
                parameters[4].Value = deptid;
                parameters[5].Text = "@pym";
                parameters[5].Value = pym;
                parameters[6].Text = "@wbm";
                parameters[6].Value = wbm;
                parameters[7].Text = "@itemname";
                parameters[7].Value = itemname;
                parameters[8].Text = "@jgbm";
                parameters[8].Value = jgbm;
                parameters[9].Text = "@kzsj";
                parameters[9].Value = sjkz;
                parameters[10].Text = "@funname";
                parameters[10].Value = funname;

                DataTable tb = _DataBase.GetDataTable("SP_MZYS_SelectYZxm", parameters, 30);
                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }
        #endregion

        /// <summary>
        /// 创建序号列，传入的表的列名中必须包含列名“序号”
        /// </summary>
        /// <param name="tb"></param>
        public static void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }
        /// <summary>
        /// 创建序号
        /// </summary>
        /// <param name="tb">要创建的表</param>
        /// <param name="idFieldName">指定用于生成序号的列的名称</param>
        /// <param name="create">标识如果用于生成序号的列的名称不在表的列中，是否自动创建</param>
        public static void AddRowtNo(DataTable tb, string idFieldName, bool create)
        {

            if (!tb.Columns.Contains(idFieldName) && create)
            {
                DataColumn col = new DataColumn();
                col.ColumnName = idFieldName;
                tb.Columns.Add(col);
            }

            if (tb.Columns.Contains(idFieldName))
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i][idFieldName] = i + 1;
            }
        }

        /// <summary>
        /// 创建指定列 Add by zp 2013-11-24 用于门诊收费新增模板录入功能 内存表动态新增自动分方列
        /// </summary>
        /// <param name="tb">要创建的表</param>
        /// <param name="idFieldName">指定用于生成列的名称</param>
        /// <param name="value">初始化值</param>
        public static void AddDataTableColumn(DataTable tb, string idFieldName, string value)
        {

            if (!tb.Columns.Contains(idFieldName))
            {
                DataColumn col = new DataColumn();
                col.ColumnName = idFieldName;
                tb.Columns.Add(col);
            }

            if (tb.Columns.Contains(idFieldName))
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i][idFieldName] = value;
            }
        }

        /// <summary>
        /// 获取机构编码
        /// </summary>
        /// <returns></returns>
        public static long GetJgbm()
        {
            string Jgbm = ApiFunction.GetIniString("医院信息", "机构编码", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (Convertor.IsNumeric(Jgbm) == false)
                throw new Exception("机构编码必须为数字");
            return Convert.ToInt64(Jgbm);
        }

        /// <summary>
        /// 产生新医保流水号
        /// </summary>
        /// <returns>医保流水号</returns>
        public static string GetNewYbh(RelationalDatabase _DataBase)
        {
            string ssql = "update jc_identity set ybh=ybh+1;select convert(varchar,getdate(),112)+left('00000',5-len(ybh))+rtrim(ybh) from jc_identity ";
            string ybh = Convert.ToString(_DataBase.GetDataResult(ssql));
            return ybh;
        }

        //病人登记来源
        public static string SeekDjly(int djly)
        {
            string ss = "";
            switch (djly)
            {
                case 0:
                    ss = "门诊登记";
                    break;
                case 1:
                    ss = "急诊登记";
                    break;
                case 2:
                    ss = "住院登记";
                    break;
                default:
                    break;
            }
            return ss;

        }

        public static DataTable SeekHoitemPrice(long order_id, int tcid, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (tcid <= 0)
                ssql = @"select d.dept_id,d.name 科室,b.price 单价 from jc_hoi_hdi a  inner join jc_hsitemprice b on a.hditem_id=b.hsitemid and tcid<=0
                    inner join jc_hoi_dept c  on a.hoitem_id=c.order_id  inner join jc_dept_property d 
                    on c.exec_dept=d.dept_id and b.jgbm=d.jgbm
                      where  order_id=" + order_id + "";
            else
                ssql = @"select d.dept_id,d.name 科室,b.price 单价 from jc_hoi_hdi a  inner join jc_tcprice b on a.hditem_id=b.tcid and a.tcid>0
                        inner join jc_hoi_dept c  on a.hoitem_id=c.order_id  inner join jc_dept_property d 
                        on c.exec_dept=d.dept_id and b.jgbm=d.jgbm
                      where  order_id=" + order_id + "";
            return _DataBase.GetDataTable(ssql);
        }

        public static void CreateGrid(DataTable tb, ref System.Windows.Forms.DataGridViewColumn[] col)
        {

            for (int i = 0; i <= tb.Columns.Count - 1; i++)
            {
                if (tb.Columns[i].ColumnName == "选择" || tb.Columns[i].ColumnName == "打印")
                {
                    System.Windows.Forms.DataGridViewCheckBoxColumn Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
                    Column1.HeaderText = tb.Columns[i].ColumnName;
                    Column1.DataPropertyName = tb.Columns[i].ColumnName;
                    Column1.Width = 40;
                    Column1.Name = tb.Columns[i].ColumnName;
                    col[i] = Column1;
                }
                else
                {
                    System.Windows.Forms.DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    Column1.HeaderText = tb.Columns[i].ColumnName;
                    Column1.DataPropertyName = tb.Columns[i].ColumnName;
                    Column1.Name = tb.Columns[i].ColumnName;
                    #region 列宽及可见性
                    switch (tb.Columns[i].ColumnName)
                    {
                        case "序号":
                            Column1.Width = 50;
                            break;
                        case "dept_id":
                            Column1.Visible = false;
                            break;
                        case "科室":
                            Column1.Width = 80;
                            break;
                        case "单价":
                            Column1.Width = 60;
                            break;
                        default:
                            break;
                    }
                    #endregion
                    col[i] = Column1;
                }

            }

        }
        /// <summary>
        /// 修改药品虚拟库存
        /// </summary>
        /// <param name="hjmxid"></param>
        /// <param name="cjid"></param>
        /// <param name="zxksdm"></param>
        /// <param name="ydwbl"></param>
        /// <param name="xnkcl"></param>
        /// <param name="_DataBase"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <returns></returns>
        public static int UpdateYpXnkcl(string hjmxid, long cjid, int zxksdm, int ydwbl, decimal xnkcl, RelationalDatabase _DataBase, ref int err_code, ref string err_text)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "@hjmxid";
                parameters[0].Value = hjmxid;

                parameters[1].Text = "@cjid";
                parameters[1].Value = cjid;

                parameters[2].Text = "@ypsl";
                parameters[2].Value = xnkcl;

                parameters[3].Text = "@ydwbl";
                parameters[3].Value = ydwbl;

                parameters[4].Text = "@deptid";
                parameters[4].Value = zxksdm;

                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;

                int result = Convert.ToInt32(_DataBase.GetDataResult("SP_MZYS_UpdateXnKcl", parameters, 60));
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);
                return result;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        /// <summary>
        /// 添加模板分类
        /// </summary>
        /// <param name="mbxh"></param>
        /// <param name="mbflmc"></param>
        /// <param name="jgbm"></param>
        /// <param name="mbjb"></param>
        /// <param name="ksdm"></param>
        /// <param name="ysdm"></param>
        /// <param name="djy"></param>
        /// <param name="fid"></param>
        /// <param name="_DataBase"></param>
        public static void AddMbFlMc(string mbxh, string mbflmc, int jgbm, int mbjb, int ksdm, int ysdm, int djy, string fid, int BTree, RelationalDatabase _DataBase)
        {
            //string sql = "insert into jc_cfmb values ('" + mbxh + "'," + jgbm + ",'" + mbflmc + "','','',''," + mbjb + "," + ksdm + "," + ysdm + ",getdate()," + djy + ",0,'" + fid + "'," + BTree + ")";
            // 上行代码错误 已修改 by fangke 2014.11.28
            string sql = string.Format(@"INSERT INTO JC_CFMB
                        (
	                        MBXH,JGBM,MBMC,PYM,WBM,BZ,MBJB,KSDM,YSDM,DJSJ,DJY,BSCBZ,FID,BTree
                        )
                        VALUES
                        (
                            '{0}','{1}','{2}','{3}','{4}',' ',{5},{6},{7},getdate(),{8},0,'{9}',{10}
                        )", mbxh, jgbm, mbflmc, PubStaticFun.GetPYWBM(mbflmc, 0), PubStaticFun.GetPYWBM(mbflmc, 1), mbjb, ksdm, ysdm, djy, fid, BTree);

            _DataBase.DoCommand(sql);
        }

        public static void UpdateMbFl(string str, string updatembtag, RelationalDatabase _DataBase)
        {
            string sql = "update jc_cfmb set Fid='" + updatembtag + "' " + str + " ";
            _DataBase.DoCommand(sql);
        }
        /// <summary>
        /// 修改模板分类名称
        /// </summary>
        public static void UpdateMbFlMc(string mbmc, string mbxh, RelationalDatabase _DataBase)
        {
            string sql = "update jc_cfmb set mbmc='" + mbmc + "' where mbxh='" + mbxh + "' and bscbz=0 ";
            _DataBase.DoCommand(sql);
        }
        /// <summary>
        /// 获得门诊病人就诊信息
        /// </summary>
        /// <param name="Mzh">门诊号</param>
        /// <param name="Kh">卡号</param>
        /// <param name="Name">病人姓名</param>
        /// <param name="BeginTime">就诊开始时间</param>
        /// <param name="EndTime">就诊结束时间</param>
        /// <param name="issf">是否收费  0 未收费 1已收费</param>
        /// <param name="isold">是否是历史数据 0 不是 1是</param>
        /// <returns></returns>
        public static DataTable GetMzBrxx(string Mzh, string Kh, string Name, string BeginTime, string EndTime, int IsSf, int IsOld, RelationalDatabase _DataBase)
        {
            string sql = "select from ";
            return _DataBase.GetDataTable(sql);
        }
        //将字符串转换为数字
        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        /// <summary>
        /// 通过参数1091获取需要年龄自动对应挂号级别的记录 Add By zp 2013-09-04
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static DataTable FillDocLevelByPatAge()
        {
            DataTable dt_cfg1091 = null;
            try
            {
                SystemCfg cfg1091 = new SystemCfg(1091);
                if (string.IsNullOrEmpty(cfg1091.Config)) return dt_cfg1091;
                dt_cfg1091 = new DataTable();
                DataColumn dc = new DataColumn("AGE");
                dt_cfg1091.Columns.Add(dc);
                dc = new DataColumn("GHJB");
                dt_cfg1091.Columns.Add(dc);
                dc = new DataColumn("Equals");
                dt_cfg1091.Columns.Add(dc);

                string[] par = cfg1091.Config.Split(',');
                for (int i = 0; i < par.Length; i++)
                {
                    string[] _par = par[i].Split(':');
                    DataRow dr = dt_cfg1091.NewRow();

                    dr["Equals"] = _par[0].Substring(0, 1);
                    dr["AGE"] = _par[0].Substring(1);
                    dr["GHJB"] = _par[1].ToString();

                    dt_cfg1091.Rows.Add(dr);
                }
            }
            catch (Exception ea)
            {
                throw new Exception("初始化参数1091出现异常!检查是否参数格式设置错误!异常信息:" + ea.Message);
            }
            return dt_cfg1091;
        }

        /// <summary>
        /// 通过年龄返回其对应的自动选择的挂号级别 Add By zp 2013-09-04
        /// </summary>
        /// <param name="age">年龄岁数</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int SelectDocLevelByPatAge(int age, DataTable dt)
        {
            try
            {
                if (dt == null) return -1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["Equals"].ToString().Trim())
                    {
                        case "=":
                            if (age == int.Parse(dt.Rows[i]["AGE"].ToString()))
                                return int.Parse(dt.Rows[i]["GHJB"].ToString());
                            break;
                        case "+":
                            if (age >= int.Parse(dt.Rows[i]["AGE"].ToString()))
                                return int.Parse(dt.Rows[i]["GHJB"].ToString());
                            break;
                        case "-":
                            if (age <= int.Parse(dt.Rows[i]["AGE"].ToString()))
                                return int.Parse(dt.Rows[i]["GHJB"].ToString());
                            break;
                    }
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return -1;
        }

        /// <summary>
        /// 获取医技项目 Add By zp 2013-10-08
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable GetYJItemInfo(RelationalDatabase db)
        {
            DataTable tb = new DataTable();
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "@ntype";
                parameters[0].Value = 0;
                parameters[1].Text = "@jgbm";
                parameters[1].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                tb = db.GetDataTable("SP_MZYS_GET_YJXM", parameters, 30);
                tb.TableName = "ITEM_YJ";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tb;
        }

        /// <summary>
        /// 获取门诊交款流水号  Add By Zp 2013-10-25
        /// </summary>
        /// <param name="jkid">交款id 为空表示产生新的交款id</param>
        /// <param name="jkrq">交款日期</param>
        /// <param name="jky">交款员</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static int GetMzJkLsh(Guid jkid, string jkrq, string jky, RelationalDatabase _DataBase)
        {
            int djh = 0;
            string ss = "";

            if (jkid == Guid.Empty)
            {
                #region 产生新的交款流水号
                SystemCfg cfg1089 = new SystemCfg(1089);
                if (cfg1089.Config == "0")
                {
                    ss = "select count(*) from mz_jkb where jkrq<'" + jkrq + "' and jky=" + jky + "";
                    djh = (Convert.ToInt32(_DataBase.GetDataResult(ss))) + 1;
                }
                else
                {
                    SystemCfg cfg1090 = new SystemCfg(1090);
                    ss = @"update jc_config set config=" + (int.Parse(cfg1090.Config.Trim()) + 1) + " where id=1090";
                    _DataBase.DoCommand(ss);
                    djh = int.Parse(cfg1090.Config.Trim());
                }
                #endregion
            }
            else
            {
                string sql = string.Format(@"SELECT LSH FROM MZ_JKB WHERE JKID='{0}'", jkid);
                djh = Convert.ToInt32(Convertor.IsNull(_DataBase.GetDataResult(sql), "0"));
            }
            return djh;
        }
        /// <summary>
        /// 通过挂号科室获取挂号类别 急诊|门诊 Add by zp 2013-11-15
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static int GetGhLxByDept(int deptid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"SELECT A.TYPE_CODE 类型代码,B.NAME 类型名称,C.NAME 科室名称 FROM JC_DEPT_TYPE_RELATION A 
                INNER JOIN JC_DEPT_TYPE B ON A.TYPE_CODE=B.CODE 
                INNER JOIN JC_DEPT_PROPERTY C ON A.DEPT_ID=C.DEPT_ID
                WHERE C.DEPT_ID=" + deptid + "";
                DataTable dt = _DataBase.GetDataTable(sql);
                DataRow[] drs = dt.Select("类型代码=002");
                if (drs.Length > 0)
                    return 1;
                else
                    return 2;
            }
            catch (Exception ea)
            {
                throw new Exception("GetGhLxByDept函数出现异常!原因:" + ea.Message);
            }
        }
        /// <summary>
        /// 获取挂号科室限制信息 Add by zp 2013-12-14
        /// </summary>
        /// <param name="search"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetGhKsXz(string search, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT ID,IPADDRESS,GHKSID,dbo.fun_getDeptname(GHKSID) KSMC,DJRQ,MEMO,XGRQ FROM JC_GHKSXZ WHERE 1=1 ";
                if (!string.IsNullOrEmpty(search))
                    sql += " AND IPADDRESS= '" + search + "' OR dbo.fun_getDeptname(GHKSID) LIKE '%" + search + "%'";

                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        //保存挂号科室限制 id由外部传入 Add by zp 2013-12-14
        public static void SaveGhKsXz(Guid id, string ip, int ghks, string memo,bool isAdd,int czy, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = "";
                if (!isAdd)//更新
                    sql = @"UPDATE JC_GHKSXZ SET IPADDRESS='" + ip + "',GHKSID=" + ghks + ",XGRQ=GETDATE(),MEMO='" + memo + "',CZY=" + czy + " WHERE ID='" + id + "'";
                else
                {
                    sql = @"INSERT INTO JC_GHKSXZ(ID,IPADDRESS,GHKSID,MEMO,CZY)
                    VALUES('" + id + "','" + ip + "'," + ghks + ",'" + memo + "'," + czy + ")";
                }
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        //删除挂号科室限制  Add by zp 2013-12-14
        public static void DelGhKsXz(Guid id, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"DELETE FROM JC_GHKSXZ WHERE ID='" + id + "'";
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        //保存开单科室限制禁用指定执行科室内项目 Add by zp 2013-12-14
        public static void SaveKdksXz(Guid id, int zxksid, int kdksid, int djy, string memo, bool isAdd, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = "";
                if (!isAdd)
                    sql = @"UPDATE JC_KDKSXZ SET ZXKSID=" + zxksid + ",KDKSID=" + kdksid + ",XGSJ=GETDATE(),DJY=" + djy + ",MEMO='" + memo + "' WHERE ID='" + id + "'";
                else
                    sql = @"INSERT INTO JC_KDKSXZ(ID,ZXKSID,KDKSID,DJY,MEMO)
                    VALUES('" + id + "'," + zxksid + "," + kdksid + "," + djy + ",'" + memo + "')";
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        //获取开单科室限制禁用指定执行科室内项目 记录 Add by zp 2013-12-14
        public static DataTable GetKdksXz(int kdksid, int zxksid, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT ID,ZXKSID,KDKSID,dbo.fun_getDeptname(ZXKSID) ZXKSMC,dbo.fun_getDeptname(KDKSID) KDKSMC,DJY,dbo.fun_getempname(DJY) DJYNAME,XGSJ,MEMO,DJSJ FROM JC_KDKSXZ
                WHERE 1=1";
                if (kdksid > 0)
                    sql += " AND KDKSID=" + kdksid + "";
                if (zxksid > 0)
                    sql += " AND ZXKSID=" + zxksid + "";
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }


        //删除开单科室限制禁用指定执行科室内项目 记录 Add by zp 2013-12-14
        public static void DelKdksXz(Guid id, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"DELETE FROM JC_KDKSXZ WHERE ID='" + id + "'";
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        //获取医技执行科室
        public static DataTable GetYjDeptInfo(RelationalDatabase _DataBase)
        {
            try
            {
                string sql = "select * from JC_DEPT_PROPERTY  where YJ_FLAG=1 AND DELETED=0";
                DataTable dt = _DataBase.GetDataTable(sql);
                return dt;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        //保存日志
        public static void SaveHisLog(int ksdm, int czy,string type,string memo,string workstation,int module_id,RelationalDatabase _DataBase)
        {
            try
            {
                string sSql = @"insert into his_log (dept_ID,operator_id,operator_type,Contents,starttime,errlevel,workstation,module_id)
                values(" + ksdm.ToString() + "," + czy.ToString() + ",'" + type + "','" + memo + "',GetDate(),0,'" + workstation + "', " + module_id + ")";
                _DataBase.DoCommand(sSql);
            }
            catch (Exception ea)
            {
                throw ea;
            }

        }

        public static DataTable GetKsdyYfInfo(int dept_id, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT dbo.fun_getDeptname(DEPT_ID) 科室名称,dbo.fun_getDeptname(DRUGSTORE_ID) 药房名称,* FROM JC_DEPT_DRUGSTORE where 1=1";
                if (dept_id > 0)
                    sql += " and DEPT_ID='" + dept_id + "'";
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        //验证病人是否为留观病人 Add by zp 2014-01-02
        public static bool CheckIsLgbr(Guid _Ghxxid, RelationalDatabase _DataBase)
        {
            try
            {
                string lg = @"select * from dbo.MZ_QUARTERS where GHXXID='" + _Ghxxid + "' and  isnull([STATE],0)=0";
                DataTable tblg = _DataBase.GetDataTable(lg);
                //留观病人才判断 
                if (tblg.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }


        /// <summary>
        /// 获取留观病人详细信息 Add by zp 2014-01-02
        /// </summary>
        /// <param name="_Ghxxid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetLgbrInfo(Guid _Ghxxid, RelationalDatabase _DataBase)
        {
            try
            {
                string lg = @"select * from dbo.MZ_QUARTERS where GHXXID='" + _Ghxxid + "' and  isnull([STATE],0)=0";
                DataTable tblg = _DataBase.GetDataTable(lg);
                //留观病人才判断 
                if (tblg.Rows.Count > 0)
                    return tblg;
                else
                    return null;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        /// <summary>
        /// 获取默认科室
        /// </summary>
        /// <param name="yzid"></param>
        /// <returns></returns>
        public static DataTable GetDefualtUserType(string yzid, RelationalDatabase _DataBase)
        {
            string strSql = string.Format(@"SELECT b.ID,b.NAME FROM JC_HOITEMDICTION a LEFT JOIN dbo.JC_USAGEDICTION b 
                                                                ON  a.DEFAULT_USAGE=b.NAME 
                                                                WHERE ORDER_ID={0}", yzid);
            DataTable td = _DataBase.GetDataTable(strSql);
            return td;
        }

        public static string GetMzh(Guid ghxxid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"select blh from mz_ghxx where GHXXID='" + ghxxid + "'";
                DataTable tb = _DataBase.GetDataTable(sql);

                if (tb.Rows.Count > 0)
                    return tb.Rows[0]["blh"].ToString();
                else return "";
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        public static string GetJshm(string kshm, int zs)
        {
            //return Convert.ToString(Convert.ToDecimal(kshm) + zs-1).PadLeft(len,'0');
            return Convert.ToString(Convert.ToDecimal(kshm) + zs - 1);
        }

        public static int GetZs( string kshm , string jshm )
        {
            decimal ks = Convert.ToDecimal( kshm );
            decimal js = Convert.ToDecimal( jshm );
            if ( js >= ks )
                return Convert.ToInt32( js - ks ) + 1;
            else
                return -1;
        }

        public static void Isjz(int sfy, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@sfy";
                parameters[0].Value = sfy;

                parameters[1].Text = "@out_code";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].DataType = System.Data.DbType.Int32;
                parameters[1].ParaSize = 100;

                parameters[2].Text = "@out_text";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                _DataBase.DoCommand("sp_mzsf_jkxz", parameters, 30);

                err_code = Convert.ToInt32(parameters[1].Value);
                err_text = Convert.ToString(parameters[2].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        /// <summary>
        /// 通过卡号获取病人详细信息
        /// </summary>
        /// <param name="kh"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetBrxx(string kh, RelationalDatabase _DataBase)
        {
            string strSql = string.Format(@"select a.BRXXID,KH,BRXM,
            (case when XB=1 then '男'  when xb=2 then '女' else '未知' end) xb 
            from YY_KDJB a inner join YY_BRXX  b on a.BRXXID = b.BRXXID where a.KH = '{0}'", kh);
            DataTable dt = _DataBase.GetDataTable(strSql);
            return dt;
        }

        public static DataTable GetZjList(string dept, RelationalDatabase _DataBase)
        {
            string strSql = string.Format(@"select ZJMC,d.NAME,b.PYM,b.WBM,b.ZJID, d.EMPLOYEE_ID from JC_FZ_ZQ a  
                                                            inner join JC_ZJSZ b on a.ZQ_ID = b.ZQID  
                                                            inner join JC_FZ_ZQ_DEPT c  on a.ZQ_ID = c.ZQ_ID 
                                                            inner join JC_EMPLOYEE_PROPERTY d on b.ZZYS = d.EMPLOYEE_ID 
                                                            where  c.DEPT_ID = {0} and b.ZZYS !=0", dept);
            DataTable dt = _DataBase.GetDataTable(strSql);
            return dt;
        }

        public static string GetYbdjxx(string kh, RelationalDatabase _DataBase)
        {
            string sql = @"select DJID from MZ_YB_DJXX a,YY_KDJB b where a.KDJID = b.KDJID and b.KH ='" + kh + "' and isnull(DELETE_BIT,0) = 0 ";
            DataTable tb = _DataBase.GetDataTable(sql);
            if (tb.Rows.Count > 0)
                return Convertor.IsNull(tb.Rows[0]["DJID"], "");
            else
                return "";
        }
        /// <summary>
        /// 使用指定的连接从数据库返回Guid值
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public static Guid GetGuidFromDB(RelationalDatabase database)
        {
            try
            {
                string strSql = "select dbo.FUN_GETGUID(newid(),getdate())";
                object objGuid = database.GetDataResult(strSql);
                return new Guid(objGuid.ToString());
            }
            catch
            {
                throw new Exception("方法“ts_mz_class.Fun.GetGuidFromDB”从数据库返回GUID失败");
            }
        }
        /// <summary>
        /// 获取一个CommandParameter
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static IDbDataParameter NewCommandParameter(IDbCommand cmd, string pName , object pValue)
        {
            IDbDataParameter p = cmd.CreateParameter();
            p.ParameterName = pName;
            if (pValue == null || Convert.IsDBNull(pValue))
                p.Value = DBNull.Value;
            else
                p.Value = pValue;
            return p;
        }

        /// <summary>
        /// 护士站门诊取号生成候诊号 Add by zp 2014-08-25
        /// </summary>
        /// <param name="dept_id">科室id</param>
        /// <param name="ys_id">医生id</param>
        /// <param name="ghjb_id">挂号级别id</param>
        /// <param name="is_yy">是否预约挂号登记 0非预约挂号登记 1是预约挂号登记</param>
        /// <param name="is_jz">是否为急诊 1门诊 不为1则是急诊  如果为急诊则永恒不区分上下午  </param>
        /// <param name="ghrq">挂号日期</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static int MZQH_GET_HZH(int dept_id, int ys_id, int ghjb_id, int is_yy, int is_jz, string ghrq, RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[6];

            parameters[0].Text = "@GHKS";
            parameters[0].Value = dept_id;

            parameters[1].Text = "@ghys";
            parameters[1].Value = ys_id;

            parameters[2].Text = "@ghjb";
            parameters[2].Value = ghjb_id;

            parameters[3].Text = "@isyydj";
            parameters[3].Value = is_yy;

            parameters[4].Text = "@isjz";
            parameters[4].Value = is_jz;

            parameters[5].Text = "@ghrq";
            parameters[5].Value = ghrq;

            DataSet dset = new DataSet();
            DataTable dt = _DataBase.GetDataTable("SP_MZQH_GET_HZH", parameters, 30);
            //Fun.DebugView(dt);
            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("存储过程SP_MZQH_GET_HZH出现异常!返回值为NULL");
            else
                return int.Parse(dt.Rows[0][0].ToString());
           
        }

        #region 调试用
        public static void DebugView(DataSet dset)
        {
            Form f = new Form();
            System.Windows.Forms.TabControl tbc = new TabControl();
            tbc.Dock = DockStyle.Fill;
            foreach (DataTable tb in dset.Tables)
            {
                TabPage tp = new TabPage();
                DataGridView dgv = new DataGridView();
                dgv.Dock = DockStyle.Fill;
                dgv.DataSource = tb;
                tp.Controls.Add(dgv);
                tp.Text = tb.TableName;
                tbc.TabPages.Add(tp);
            }
            f.Controls.Add(tbc);
            f.ShowDialog();
        }
        public static void DebugView(DataRow[] rows)
        {
            if (rows.Length > 0)
            {
                DataTable tb = rows[0].Table.Clone();
                foreach (DataRow r in rows)
                    tb.Rows.Add(r.ItemArray);
                DebugView(tb);
            }
        }
        public static void DebugView(DataTable table)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(table.Copy());
            DebugView(ds);
        }
        #endregion
    }
}
