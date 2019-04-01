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
namespace ts_mzys_class
{
    /// <summary>
    /// 门诊护士分诊类
    /// </summary>
    public class MZHS_FZJL
    {

        #region 字段定义 add by zp 2013-06-06
        private string fzid;
        private string ghxxid;
        private int zsid;
        private int fzksid;
        private int fzysid;
        private string fzsj;
        private int jlzt;
        private string pdsj;
        private string djsj;
        private string yysd;
        private string patname;
        private string patghzkname;
        private string roomname;
        private int patdlxh;
        private string patGhjb;
        private string patGHJBName;
        private string patzqName;
        private int patzqid;
        private object tvtag;
        private string kssj;
        private string jssj;
        private string sjnc;
        private string ghrq;
        private string tvtext;

        private int pdxh;

        private string patzjjc;  
        /// <summary>
        /// 诊室简称 Add by zp 2014-06-13
        /// </summary>
        public string Patzjjc
        {
            get
            {
                return patzjjc;
            }
            set
            {
                patzjjc = value;
            }
        }

        public static SystemCfg _cfg3076 = null;//获取其他级别 Add By zp 2013-09-25
        public static SystemCfg _cfg3066 =null;//分诊医生呼叫是否限制呼叫级别0限制1不限制  Add By zp 2013-09-25
        
        public static DataTable Dt_Fzjb;
        /// <summary>
        /// 对应电视机上显示的值 Add by zp 2013-12-01
        /// </summary>
        public int Pdxh
        {
            get { return pdxh; }
            set { pdxh = value; }
        }
        /// <summary>
        /// 对应电视机上显示的值 Add by zp 2013-12-01
        /// </summary>
        public string Tvtext
        {
            get { return tvtext; }
            set { tvtext = value; }
        }

        /// <summary>
        /// 对应电视机显示屏上的Label的tag值
        /// </summary>
        public object Tvtag
        {
            get { return tvtag; }
            set { tvtag = value; }
        }
        /// <summary>
        /// 病人所在诊区ID
        /// </summary>
        public int Patzqid
        {
            get { return patzqid; }
            set { patzqid = value; }
        }
        /// <summary>
        /// 病人所在诊区名称
        /// </summary>
        public string PatzqName
        {
            get { return patzqName; }
            set { patzqName = value; }
        }
        /// <summary>
        /// 挂号级别名称
        /// </summary>
        public string PatGHJBName
        {
            get { return patGHJBName; }
            set { patGHJBName = value; }
        }
        /// <summary>
        /// 挂号级别
        /// </summary>
        public string PatGhjb
        {
            get { return patGhjb; }
            set { patGhjb = value; }
        }

        /// <summary>
        /// 诊室名称
        /// </summary>
        public string roomName
        {
            get { return roomname; }
            set { roomname = value; }
        }
        /// <summary>
        /// 病人挂号科室名称
        /// </summary>
        public string patGHZKName
        {
            get { return patghzkname; }
            set { patghzkname = value; }
        }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string patName
        {
            get { return patname; }
            set { patname = value; }
        }

        /// <summary>
        /// 排队序号 对应挂号表的PDXH
        /// </summary>
        public int Patdlxh
        {
            get { return patdlxh; }
            set { patdlxh = value; }
        }
        /// <summary>
        /// 挂号信息id
        /// </summary>
        public string Ghxxid
        {
            get { return ghxxid; }
            set { ghxxid = value; }
        }
        /// <summary>
        /// 诊室id
        /// </summary>
        public int Zsid
        {
            get { return zsid; }
            set { zsid = value; }
        }
        /// <summary>
        /// 分诊科室id
        /// </summary>
        public int Fzksid
        {
            get { return fzksid; }
            set { fzksid = value; }
        }
        /// <summary>
        /// 分诊医生id
        /// </summary>
        public int Fzysid
        {
            get { return fzysid; }
            set { fzysid = value; }
        }
        /// <summary>
        /// 分诊时间
        /// </summary>
        public string Fzsj
        {
            get { return fzsj; }
            set { fzsj = value; }
        }
        /// <summary>
        /// 记录状态0未分诊 1已分诊 2已叫号 3已接诊 4已踢出队列 5已完成
        /// </summary>
        public int Jlzt
        {
            get { return jlzt; }
            set { jlzt = value; }
        }
        /// <summary>
        /// 排队时间 
        /// </summary>
        public string Pdsj
        {
            get { return pdsj; }
            set { pdsj = value; }
        }
        /// <summary>
        /// 登记时间
        /// </summary>
        public string Djsj
        {
            get { return djsj; }
            set { djsj = value; }
        }

        /// <summary>
        /// 预约时段
        /// </summary>
        public string Yysd
        {
            get { return yysd; }
            set { yysd = value; }
        }
        /// <summary>
        /// 分诊id
        /// </summary>
        public string Fzid
        {
            get { return fzid; }
            set { fzid = value; }
        }
        /// <summary>
        /// 时段昵称
        /// </summary>
        public string Sjnc
        {
            get { return sjnc; }
            set { sjnc = value; }
        }
        /// <summary>
        /// 时段开始时间
        /// </summary>
        public string Jssj
        {
            get { return jssj; }
            set { jssj = value; }
        }
        /// <summary>
        /// 时段结束时间
        /// </summary>
        public string Kssj
        {
            get { return kssj; }
            set { kssj = value; }
        }
        /// <summary>
        /// 挂号日期
        /// </summary>
        public string Ghrq
        {
            get { return ghrq; }
            set { ghrq = value; }
        }
        #endregion

        public MZHS_FZJL() { }

        public MZHS_FZJL(Guid ghxxid,RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"SELECT A.*,B.YYSD,C.BRXM,DBO.FUN_GETDEPTNAME(B.GHKS) KSMC,
                dbo.fun_getzsmc(A.ZSID) ZSMC,B.PDXH,B.GHJB,dbo.fun_getghjb(B.GHJB) GHJBMC,
                B.GHSJ,DBO.FUN_GETZQNAME(A.ZQID) ZQNAME                  
                FROM MZHS_FZJL A 
                INNER JOIN MZ_GHXX B ON A.GHXXID=B.GHXXID 
                INNER JOIN YY_BRXX C ON B.BRXXID=C.BRXXID
                 WHERE A.GHXXID='" + ghxxid + "'";
                DataTable dt = _DataBase.GetDataTable(sql);
                SetFieldValues(dt);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        private void SetFieldValues(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count <= 0) return;
                fzid=dt.Rows[0]["FZID"].ToString();
                ghxxid=dt.Rows[0]["GHXXID"].ToString();
                zsid=Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["ZSID"],"0"));
                fzksid=Convert.ToInt32(dt.Rows[0]["FZKS"]);
                fzysid=Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["FZYS"],"0"));
                fzsj=Convertor.IsNull(dt.Rows[0]["FZSJ"],"");
                jlzt=Convert.ToInt32(dt.Rows[0]["BJZBZ"]);
                pdsj=Convertor.IsNull(dt.Rows[0]["PDSJ"],"");
                djsj=Convertor.IsNull(dt.Rows[0]["DJSJ"],"");
                yysd = Convertor.IsNull(dt.Rows[0]["YYSD"], "");
                patname = dt.Rows[0]["BRXM"].ToString();
                patghzkname = Convertor.IsNull(dt.Rows[0]["KSMC"], "");
                roomname = Convertor.IsNull(dt.Rows[0]["ZSMC"], "");
                patdlxh = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["PDXH"], "0"));
                patGhjb = dt.Rows[0]["GHJB"].ToString();
                patGHJBName = dt.Rows[0]["GHJBMC"].ToString();
                patzqName = dt.Rows[0]["ZQNAME"].ToString();
                patzqid = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["ZQID"], "0"));
                tvtag = null;
                kssj = Convertor.IsNull(dt.Rows[0]["KSSJ"], "");
                jssj = Convertor.IsNull(dt.Rows[0]["JSSJ"], "");
                sjnc = Convertor.IsNull(dt.Rows[0]["SJNC"], "");
                ghrq = Convertor.IsNull(dt.Rows[0]["GHSJ"], "");
                if(new SystemCfg(3103).Config=="1")
                    pdxh = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["PXXH"], "0"));
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        /// <summary>
        /// 查询未候诊的病人Old
        /// </summary>
        /// <param name="ksdm">科室代码</param>
        /// <param name="rq1">开始日期</param>
        /// <param name="rq2">结束日期</param>
        /// <param name="klx">卡类型</param>
        /// <param name="kh">卡号</param>
        /// <param name="blh">病历号</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataSet Select_whzbr(int ksdm, string rq1, string rq2, int klx, string kh, string blh, RelationalDatabase _DataBase)
        {

            try
            {
                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "@ksdm";
                parameters[0].Value = ksdm;

                parameters[1].Text = "@rq1";
                parameters[1].Value = rq1;

                parameters[2].Text = "@rq2";
                parameters[2].Value = rq2;

                parameters[3].Text = "@klx";
                parameters[3].Value = klx;

                parameters[4].Text = "@kh";
                parameters[4].Value = kh;

                parameters[5].Text = "@blh";
                parameters[5].Value = blh;

                DataSet dset = new DataSet();
                _DataBase.AdapterFillDataSet("SP_mzys_fz_whzbr", parameters, dset, "sfmx", 30);
                return dset;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// 通过诊区id获取未分诊病人 Modify by zp 2013-06-27
        /// </summary>
        /// <param name="zqid">诊区id</param>
        /// <param name="rq1">开始日期</param>
        /// <param name="rq2">结束日期</param>
        /// <param name="klx">卡类型</param>
        /// <param name="kh">卡号</param>
        /// <param name="blh">病历号</param>
        /// <param name="sort">检索方式 0全天1上午2下午</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataSet Select_WfzPat(int zqid, string rq1, string rq2, int klx, string kh, string blh, int sort, RelationalDatabase _DataBase)
        {

            try
            {
                ParameterEx[] parameters = new ParameterEx[7];

                parameters[0].Text = "@zqid";
                parameters[0].Value = zqid;

                parameters[1].Text = "@rq1";
                parameters[1].Value = rq1;

                parameters[2].Text = "@rq2";
                parameters[2].Value = rq2;

                parameters[3].Text = "@klx";
                parameters[3].Value = klx;

                parameters[4].Text = "@kh";
                parameters[4].Value = kh;

                parameters[5].Text = "@blh";
                parameters[5].Value = blh;

                parameters[6].Text = "@sort";
                parameters[6].Value = sort;

                DataSet dset = new DataSet();//Modify by zp 2013-11-05 SP_mzys_fz_wfzpat
                _DataBase.AdapterFillDataSet("SP_mzhs_fz_wfzpat", parameters, dset, "sfmx", 30);
                return dset;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// 查询已候诊的病人Old
        /// </summary>
        /// <param name="ksdm">科室代码</param>
        /// <param name="rq1">开始日期</param>
        /// <param name="rq2">结束日期</param>
        /// <param name="klx">卡类型</param>
        /// <param name="kh">卡号</param>
        /// <param name="blh">病历号</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataSet Select_yhzbr(int ksdm, string rq1, string rq2, int klx, string kh, string blh, RelationalDatabase _DataBase)
        {

            try
            {
                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "@ksdm";
                parameters[0].Value = ksdm;

                parameters[1].Text = "@rq1";
                parameters[1].Value = rq1;

                parameters[2].Text = "@rq2";
                parameters[2].Value = rq2;

                parameters[3].Text = "@klx";
                parameters[3].Value = klx;

                parameters[4].Text = "@kh";
                parameters[4].Value = kh;

                parameters[5].Text = "@blh";
                parameters[5].Value = blh;

                DataSet dset = new DataSet();
                _DataBase.AdapterFillDataSet("SP_mzys_fz_yhzbr", parameters, dset, "sfmx", 30);
                return dset;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// 查询已分诊的病人 Modify by zp 2013-11-05 
        /// </summary>
        /// <param name="zqid">诊区id</param>
        /// <param name="rq1">开始日期</param>
        /// <param name="rq2">结束日期</param>
        /// <param name="klx">卡类型</param>
        /// <param name="kh">卡号</param>
        /// <param name="blh">病历号</param>
        /// <param name="sort">检索方式0检索全天1检索上午2检索下午</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataSet Select_yfzpat(int zqid, string rq1, string rq2, int klx, string kh, string blh, int sort, RelationalDatabase _DataBase)
        { 
            try
            {
                System.Data.SqlClient.SqlParameter[] parameters =new System.Data.SqlClient.SqlParameter [7];
                //ParameterEx[]  
                parameters[0] = new System.Data.SqlClient.SqlParameter("@zqid", zqid);
                //parameters[0].Text = "@zqid";
                //parameters[0].Value = zqid;
                parameters[1] = new System.Data.SqlClient.SqlParameter("@rq1", rq1);
                //parameters[1].Text = "@rq1";
                //parameters[1].Value = rq1;
                parameters[2] = new System.Data.SqlClient.SqlParameter("@rq2", rq2);
                //parameters[2].Text = "@rq2";
                //parameters[2].Value = rq2;
                parameters[3] = new System.Data.SqlClient.SqlParameter("@klx", klx);
                //parameters[3].Text = "@klx";
                //parameters[3].Value = klx;
                parameters[4] = new System.Data.SqlClient.SqlParameter("@kh", kh);
                //parameters[4].Text = "@kh";
                //parameters[4].Value = kh;
                parameters[5] = new System.Data.SqlClient.SqlParameter("@blh", blh);
                //parameters[5].Text = "@blh";
                //parameters[5].Value = blh;
                parameters[6] = new System.Data.SqlClient.SqlParameter("@sort", sort);
                //parameters[6].Text = "@sort";
                //parameters[6].Value = sort; 
                DataSet dset = new DataSet();
                Ts_dataBase_jqg.DBHelper.Connstr = _DataBase.ConnectionString;

                //public static DataSet GetDataSet(string sql, CommandType commandType, params SqlParameter[] sqlParams)
                dset = Ts_dataBase_jqg.DBHelper.GetDataSet("SP_mzhs_fz_yfzpat", CommandType.StoredProcedure, parameters); 
                //_DataBase.AdapterFillDataSet("SP_mzhs_fz_yfzpat", parameters, dset, "sfmx", 30);
                return dset;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// 新增分诊记录Old
        /// </summary>
        /// <param name="jgbm"></param>
        /// <param name="ghxxid">挂号信息id</param>
        /// <param name="fzks">分诊科室</param>
        /// <param name="NewFzid">分诊id</param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="_DataBase"></param>
        public static void AddHz(long jgbm, Guid ghxxid, int fzks, out Guid NewFzid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = jgbm;

                parameters[1].Text = "@GHXXID";
                parameters[1].Value = ghxxid;

                parameters[2].Text = "@fzks";
                parameters[2].Value = fzks;

                parameters[3].Text = "@newfzid";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].DataType = System.Data.DbType.Guid;
                parameters[3].ParaSize = 100;

                parameters[4].Text = "@err_code";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].DataType = System.Data.DbType.Int32;
                parameters[4].ParaSize = 100;

                parameters[5].Text = "@err_text";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].ParaSize = 100;

                _DataBase.DoCommand("SP_mzys_fz_addhz", parameters, 30);
                NewFzid = new Guid(Convertor.IsNull(parameters[3].Value.ToString(),Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[4].Value);
                err_text = Convert.ToString(parameters[5].Value);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }
       
        /// <summary>
        /// 分诊操作  Modify by cc 2014-05-07
        /// </summary>
        /// <param name="jgbm">机构编码</param>
        /// <param name="ghxxid">挂号信息id</param>
        /// <param name="fzks">分诊科室</param>
        /// <param name="NewFzid"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="_DataBase"></param>
        public static void AddHz(long jgbm, Guid ghxxid, int fzks,int Pxxh, FzStatus status, out Guid NewFzid,
            out int err_code, out string err_text, string btime, string etime, string sjnc, int zqid, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[12];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = jgbm;

                parameters[1].Text = "@GHXXID";
                parameters[1].Value = ghxxid;

                parameters[2].Text = "@fzks";
                parameters[2].Value = fzks;

                parameters[3].Text = "@JLZT";
                parameters[3].Value = (int)status;
                parameters[3].DataType = System.Data.DbType.Int32;

                parameters[4].Text = "@newfzid";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].DataType = System.Data.DbType.Guid;
                parameters[4].ParaSize = 100;

                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;

                parameters[7].Text = "@KSSJ";
                parameters[7].Value = btime;

                parameters[8].Text = "@JSSJ";
                parameters[8].Value = etime;

                parameters[9].Text = "@SJNC";
                parameters[9].Value = sjnc;

                parameters[10].Text = "@ZQID";
                parameters[10].Value = zqid;

                parameters[11].Text = "@PXXH";
                parameters[11].Value = Pxxh;

                _DataBase.DoCommand("SP_mzhs_hsfzNew", parameters, 30);
                NewFzid = new Guid(Convertor.IsNull(parameters[4].Value.ToString(), Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// 分诊操作  Modify by zp 2013-10-30 
        /// </summary>
        /// <param name="jgbm">机构编码</param>
        /// <param name="ghxxid">挂号信息id</param>
        /// <param name="fzks">分诊科室</param>
        /// <param name="NewFzid"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="_DataBase"></param>
        public static void AddHz(long jgbm, Guid ghxxid, int fzks, FzStatus status, out Guid NewFzid,
            out int err_code, out string err_text,string btime,string etime,string sjnc,int zqid, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[11];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = jgbm;

                parameters[1].Text = "@GHXXID";
                parameters[1].Value = ghxxid;

                parameters[2].Text = "@fzks";
                parameters[2].Value = fzks;

                parameters[3].Text = "@JLZT";
                parameters[3].Value = (int)status;
                parameters[3].DataType = System.Data.DbType.Int32;

                parameters[4].Text = "@newfzid";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].DataType = System.Data.DbType.Guid;
                parameters[4].ParaSize = 100;

                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;

                parameters[7].Text = "@KSSJ";
                parameters[7].Value = btime;

                parameters[8].Text = "@JSSJ";
                parameters[8].Value = etime;

                parameters[9].Text = "@SJNC";
                parameters[9].Value = sjnc;

                parameters[10].Text = "@ZQID";
                parameters[10].Value = zqid;

                _DataBase.DoCommand("SP_mzhs_hsfz", parameters, 30);
                NewFzid = new Guid(Convertor.IsNull(parameters[4].Value.ToString(), Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static void AddHz(long jgbm, Guid ghxxid, int fzks, FzStatus status, out Guid NewFzid,
        out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = jgbm;

                parameters[1].Text = "@GHXXID";
                parameters[1].Value = ghxxid;

                parameters[2].Text = "@fzks";
                parameters[2].Value = fzks;

                parameters[3].Text = "@JLZT";
                parameters[3].Value = (int)status;
                parameters[3].DataType = System.Data.DbType.Int32;

                parameters[4].Text = "@newfzid";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].DataType = System.Data.DbType.Guid;
                parameters[4].ParaSize = 100;

                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;

               

                _DataBase.DoCommand("SP_mzys_hsfz", parameters, 30);
                NewFzid = new Guid(Convertor.IsNull(parameters[4].Value.ToString(), Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// 取消候诊 Modfi By zp 2013-06-18
        /// </summary>
        /// <param name="fzid">分诊id</param>
        /// <param name="_DataBase"></param>
        public static void Delete_Hz(Guid fzid, SystemCfg _cfg3070, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (_cfg3070.Config == "1") //如果是老的分诊系统(未采用分时段叫号) 则更新删除标记
            {
                ssql = "update mzhs_fzjl set bscbz=1 where fzid='" + fzid + "' and bjzbz=0 ";
            }
            else //新分诊更新接诊标志 新分诊系统里 bjzbz=0：未分诊1：已分诊2：已呼叫 3：已接诊 4:踢出队列 5：已结束就诊
            {
                ssql = "update mzhs_fzjl set bjzbz=4,pxxh=9999 where fzid='" + fzid + "' and bjzbz in(1,2) ";
            }
            int i = _DataBase.DoCommand(ssql);
            if (i != 1) throw new Exception("没有取消成功,可能医生已接诊");
        }

        /// <summary>
        /// 取消候诊 Old
        /// </summary>
        /// <param name="fzid"></param>
        /// <param name="_DataBase"></param>
        public static void Delete_Hz(Guid fzid, RelationalDatabase _DataBase)
        {
            string ssql = "update mzhs_fzjl set bscbz=1 where fzid='" + fzid + "' and bjzbz=0 ";
            int i = _DataBase.DoCommand(ssql);
            if (i != 1) throw new Exception("没有取消成功,可能医生已接诊");
        }

        /// <summary>
        /// 医生站踢出队列 
        /// </summary>
        /// <param name="fzid">分诊id</param>
        /// <param name="_DataBase"></param>
        public static void DocUpdat_Hz(Guid fzid, SystemCfg _cfg3071, RelationalDatabase _DataBase)
        {
            /*通过参数3071判断是更新分诊记录表的接诊标志还是更新为现场病人 报到时间为当前最大值*/
            string ssql = "";
            if (_cfg3071.Config.Trim() == "1") //更新为现场挂号最后一位候诊记录
            {
                //Modifi By zp 2013-07-05
                ssql = @"SELECT TOP 1 ISNULL(A.PDSJ,DBO.FUN_GETDBTIME()) FROM MZHS_FZJL AS A 
                INNER JOIN MZ_GHXX AS B ON A.GHXXID=B.GHXXID 
                WHERE A.BSCBZ=0 AND A.BJZBZ=1 AND B.BQXGHBZ=0 AND B.YYLX=0  
                and convert(varchar(30),a.djsj,112) =convert(varchar(30),getdate(),112)
                ORDER BY A.PDSJ DESC";
                long value = (Convert.ToInt64(_DataBase.GetDataResult(ssql))) + 1;

                ssql = @"UPDATE MZHS_FZJL SET BJZBZ=1,BZ='医生踢出队列',PDSJ=" + value + @" 
                      WHERE FZID='" + fzid + @"' AND BJZBZ = 2 ";
            }
            else
            {
                ssql = "update mzhs_fzjl set bjzbz=4 where fzid='" + fzid + "' and bjzbz in(1,2) ";
            }
            int i = _DataBase.DoCommand(ssql);
            if (i != 1) throw new Exception("没有操作成功!,可能医生已接诊");
        }

        ///<summary>
        /// 获取待呼叫列表 Modify By zp 2013-09-24 不带级别限制后进行验证 针对某些特殊级别 不受到上下级别控制
        /// </summary>
        /// <param name="rqbegin">开始日期</param>
        /// <param name="rqend">结束日期</param>
        /// <param name="docid">医生id</param>
        /// <param name="ghjb">挂号级别</param>
        /// <param name="zqid">诊区编号</param>
        /// <param name="ghxxid">挂号信息id</param>
        /// <param name="sort">类型0呼叫1查询当前待呼叫病人</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetDocCallPatient(string rqbegin, string rqend, int docid, int ghjb,
            int zqid, string ghxxid, int sort, int ksdm,int zjdm, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                ParameterEx[] parameters = new ParameterEx[10];

                parameters[0].Text = "@zqid";
                parameters[0].Value = zqid;//1

                parameters[1].Text = "@ghjb";//"@zsid";  挂号级别需要根据排班来
                parameters[1].Value = ghjb;//1

                parameters[2].Text = "@ysdm";
                parameters[2].Value = docid;//20

                parameters[3].Text = "@rq1";
                parameters[3].Value = rqbegin;//2013-11-07 00:00:00

                parameters[4].Text = "@rq2";
                parameters[4].Value = rqend;//2013-11-07 23:59:59

                parameters[5].Text = "@sort";
                parameters[5].Value = sort;//0

                parameters[6].Text = "@ghxxid";
                parameters[6].Value = ghxxid;//''

                parameters[7].Text = "@ksdm";
                parameters[7].Value = ksdm;//27

                parameters[8].Text = "@ZJDM";
                parameters[8].Value = zjdm;//

                parameters[9].Text = "@out_text";
                parameters[9].Value = "";

                //parameters[10].ParaSize = 2000;
                //parameters[10].ParaDirection = ParameterDirection.Output;
                DataSet dset = new DataSet();
                dt=  _DataBase.GetDataTable("SP_mzys_fz_GetPat", parameters);//Modify by zp 2013-11-05 SP_mzys_fz_GetCallPat
            }
            catch (Exception ea)
            {
                throw ea;
            }

            DataTable dtb = dt;
            if (new SystemCfg(3103).Config == "1" && zqid > 0)
            {
                string strSql = string.Format(@"select xsfs from jc_fz_zq where zq_id={0}", zqid);
                string strXsfs = _DataBase.GetDataResult(strSql).ToString();
                if ((strXsfs == "2")||(strXsfs == "3"))
                {
                    return dtb;
                }
            }
            dtb = FindPatientByFzjb(dt, sort, ghjb, _DataBase);
            return dtb;
        }

        ///<summary>
        /// 获取待呼叫列表 Modify By zp 2013-09-24 不带级别限制后进行验证 针对某些特殊级别 不受到上下级别控制
        /// </summary>
        /// <param name="rqbegin">开始日期</param>
        /// <param name="rqend">结束日期</param>
        /// <param name="docid">医生id</param>
        /// <param name="ghjb">挂号级别</param>
        /// <param name="zqid">诊区编号</param>
        /// <param name="ghxxid">挂号信息id</param>
        /// <param name="sort">类型0呼叫1查询当前待呼叫病人</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetDocCallPatient(string rqbegin, string rqend, int docid, int ghjb,
            int zqid, string ghxxid, int sort, int ksdm, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                ParameterEx[] parameters = new ParameterEx[9];

                parameters[0].Text = "@zqid";
                parameters[0].Value = zqid;//1

                parameters[1].Text = "@ghjb";//"@zsid";  挂号级别需要根据排班来
                parameters[1].Value = ghjb;//1

                parameters[2].Text = "@ysdm";
                parameters[2].Value = docid;//20

                parameters[3].Text = "@rq1";
                parameters[3].Value = rqbegin;//2013-11-07 00:00:00

                parameters[4].Text = "@rq2";
                parameters[4].Value = rqend;//2013-11-07 23:59:59

                parameters[5].Text = "@sort";
                parameters[5].Value = sort;//0

                parameters[6].Text = "@ghxxid";
                parameters[6].Value = ghxxid;//''

                parameters[7].Text = "@ksdm";
                parameters[7].Value = ksdm;//27

                parameters[8].Text = "@out_text";
                parameters[8].Value = "";
                parameters[8].ParaSize = 2000;
                parameters[8].ParaDirection = ParameterDirection.Output;
                DataSet dset = new DataSet();
                dt = _DataBase.GetDataTable("SP_mzys_fz_GetPat", parameters);//Modify by zp 2013-11-05 SP_mzys_fz_GetCallPat
            }
            catch (Exception ea)
            {
                throw ea;
            }
            DataTable dtb = FindPatientByFzjb(dt, sort, ghjb, _DataBase);
            return dtb;
            
        }

        //Add by zp 2013-11-05
        //public static DataTable SetDataTableRow(DataTable dt_send,DataTable dt_apply)
        //{
        //    if (dt_apply == null || dt_send == null) return null;
        //    for (int i = 0; i < dt_apply.Rows.Count; i++)
        //        dt_send.Rows.Add(dt_apply.Rows[i].ItemArray);
        //    return dt_send;
        //}
     
        /// <summary>
        /// 通过级别验证获取医生的候诊病人
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sort">0呼叫</param>
        /// <param name="ghjb"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable FindPatientByFzjb(DataTable dt, int sort, int ghjb, RelationalDatabase _DataBase)
        {
            DataTable dtb = new DataTable();
            if (dt.Rows.Count > 0)
            {
                dtb = dt.Clone();
                if (_cfg3076 == null)
                    _cfg3076 = new SystemCfg(3076, _DataBase);
                if (_cfg3066 == null)
                    _cfg3066 = new SystemCfg(3066, _DataBase);
                string dept_par = _cfg3076.Config.Trim();
                if (Dt_Fzjb == null) FillDt_Fzjb(_DataBase);
                int fzjb = 0;
                for (int y = 0; y < Dt_Fzjb.Rows.Count; y++)
                {
                    if (Convert.ToInt32(Dt_Fzjb.Rows[y]["TYPE_ID"]) == ghjb)
                    {
                        fzjb = Convert.ToInt32(Convertor.IsNull( Dt_Fzjb.Rows[y]["FZ_HJJB"],"0")); //得到当前医生的分诊呼叫级别
                        break;
                    }
                }


                if (string.IsNullOrEmpty(dept_par))/*如果未设置其他级别 则选择小于当前级别挂号级别*/
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int _hjjb = Convert.ToInt32(Convertor.IsNull( dt.Rows[i]["FZ_HJJB"],"0"));
                        if (_cfg3066.Config.Trim() != "2") 
                        {
                            if (_hjjb <= fzjb && _cfg3066.Config.Trim() == "1") //
                            {
                                dtb.Rows.Add(dt.Rows[i].ItemArray);
                                if (sort == 0) //呼叫
                                    return dtb;
                            }
                            if (_hjjb == fzjb && _cfg3066.Config.Trim() == "0")
                            {
                                dtb.Rows.Add(dt.Rows[i].ItemArray);
                                if (sort == 0) //呼叫
                                    return dtb;
                            }
                        }
                        else //所有级别都允许呼叫 某些医院低级别也允许呼叫高级别的挂号记录
                        {
                            dtb.Rows.Add(dt.Rows[i].ItemArray);
                            if (sort == 0) //呼叫
                                return dtb;
                        }
                    }

                }
                else
                {
                    /*允许选择挂号级别小于当前级别的记录 也可以为包含在其他级别内的级别*/
                    string[] par = dept_par.Split(',');
                    List<string> _list = new List<string>();
                    foreach (string p in par)
                        _list.Add(p);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int _hjjb = Convert.ToInt32(Convertor.IsNull( dt.Rows[i]["FZ_HJJB"],"0"));//int _ghjb = Convert.ToInt32(dt.Rows[i]["GHJB"]);
                        if (_cfg3066.Config.Trim() != "2") 
                        {
                            if ((_hjjb <= fzjb || (_list.Contains(dt.Rows[i]["GHJB"].ToString()))) && _cfg3066.Config.Trim() == "1")
                            {
                                dtb.Rows.Add(dt.Rows[i].ItemArray);
                                if (sort == 0) //呼叫
                                    return dtb;
                            }
                            if ((_hjjb == fzjb || (_list.Contains(dt.Rows[i]["GHJB"].ToString()))) && _cfg3066.Config.Trim() == "0")
                            {
                                dtb.Rows.Add(dt.Rows[i].ItemArray);
                                if (sort == 0) //呼叫
                                    return dtb;
                            }
                        }
                        else//所有级别都允许呼叫 某些医院低级别也允许呼叫高级别的挂号记录 Modify By zp 2013-09-27
                        {
                            dtb.Rows.Add(dt.Rows[i].ItemArray);
                            if (sort == 0) //呼叫
                                return dtb;
                        }
                    }

                }
            }
            return dtb;
        }

        /// <summary>
        /// 填充Dt_Fzjb Add By Zp 2013-09-25
        /// </summary>
        /// <param name="db"></param>
        public static void FillDt_Fzjb(RelationalDatabase db)
        {
            try
            {
                string sql = @"SELECT TYPE_ID,FZ_HJJB FROM JC_DOCTOR_TYPE";
                Dt_Fzjb = db.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        /// <summary>
        /// 将datarow实例化为分诊病人对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static MZHS_FZJL DataRowToFZjl(DataRow dr)
        {
            MZHS_FZJL fz_br = new MZHS_FZJL();
            try
            {
                fz_br.Djsj = Convertor.IsNull(dr["登记时间"], "");
                fz_br.Fzid = dr["FZID"].ToString();
                fz_br.Fzksid = int.Parse(Convertor.IsNull(dr["fzks"], "-1"));
                fz_br.Fzsj = dr["分诊时间"].ToString();
                fz_br.Fzysid = int.Parse(Convertor.IsNull(dr["分诊医生ID"], "-1"));
                fz_br.Ghxxid = dr["ghxxid"].ToString();
                fz_br.Jlzt = int.Parse(Convertor.IsNull(dr["记录状态"], "0"));
                fz_br.Patdlxh = Convert.ToInt32(Convertor.IsNull(dr["候诊号"],"0"));
                fz_br.PatGhjb = dr["ghjb"].ToString();
                fz_br.PatGHJBName = dr["挂号级别"].ToString();
                fz_br.patGHZKName = dr["挂号科室"].ToString();
                fz_br.patName = dr["姓名"].ToString();
                fz_br.roomName = Convertor.IsNull(dr["候诊诊室"], "");
                fz_br.Yysd = Convertor.IsNull(dr["预约时段"], "");
                fz_br.patzqName = Convertor.IsNull(dr["诊区名称"], "");
                fz_br.Zsid = int.Parse(Convertor.IsNull(dr["zsid"], "0"));
                fz_br.Patzqid = int.Parse(Convertor.IsNull(dr["诊区ID"], "-1"));
                fz_br.Sjnc = Convertor.IsNull(dr["时段昵称"], "");
                fz_br.pdxh = int.Parse(Convertor.IsNull(dr["排队序号"], "0"));
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return fz_br;
        }

        /// <summary>
        /// 通过挂号信息id获取 转诊确认所需要的挂号信息和病人信息 Add By zp 2013-10-21
        /// </summary>
        /// <param name="ghxxid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetMzGhxxToZz(Guid ghxxid,RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"select brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,ghsj 挂号时间,blh 门诊号,
		            dbo.fun_getdeptname(ghks) 挂号科室,type_name 挂号级别,dbo.fun_getempname(ghys) 挂号医生,a.ghxxid,ghks,ghys,ghjb,pdxh,A.GHLB
                from mz_ghxx a inner join yy_brxx b on a.brxxid=b.brxxid 
	            left join yy_kdjb c on a.kdjid=c.kdjid left join jc_doctor_type d 
	            on a.ghjb= d.type_id where ghxxid='" + ghxxid + "' and bqxghbz=0 ";
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }

        /// <summary>
        /// 护士转诊保存
        /// </summary>
        /// <param name="ksid"></param>
        /// <param name="ysid"></param>
        /// <param name="ghxxid"></param>
        /// <param name="_DataBase"></param>
        public static void HsZzSave(int ksid,int ysid,Guid ghxxid,RelationalDatabase _DataBase)
        {
            try
            {
                /*不更新挂号表的记录 更新MZHS_FZJL表的pdsj、fzks、fzys 更新对应医生坐诊的诊间 Modify by zp 2014-06-21*/
                string sql = @"SELECT TOP 1 ZJID FROM JC_ZJSZ WHERE ZZYS= " + ysid + " order by dlsj desc";
                int zjid = Convert.ToInt32(Convertor.IsNull(_DataBase.GetDataResult(sql), "0"));

                sql = string.Format(@"UPDATE MZHS_FZJL SET PDSJ=DBO.FUN_GETDBTIME(),FZKS={0},FZYS={1},ZSID={3} WHERE GHXXID='{2}'",
                    ksid, ysid, ghxxid, zjid);
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        /// <summary>
        /// 插入MZ_ZZJL记录 Add by zp 2013-10-22
        /// </summary>
        /// <param name="APPLYDEPT_ID">申请科室id</param>
        /// <param name="APPLYEMP_ID">申请医生Emp id</param>
        /// <param name="RECEIVEDEPT_ID">接收科室id</param>
        /// <param name="RECEIVEEMP_ID">接收医生id</param>
        /// <param name="CZY">操作员</param>
        /// <param name="ZZID">转诊id</param>
        /// <param name="GHXXID">挂号信息id</param>
        /// <param name="_DataBase"></param>
        public static void SetMzZzJl(int APPLYDEPT_ID, int APPLYEMP_ID, int RECEIVEDEPT_ID, int RECEIVEEMP_ID, int CZY, Guid ZZID,Guid GHXXID,RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"INSERT INTO MZ_ZZJL(ZZID,GHXXID,APPLYDEPT_ID,APPLYEMP_ID,RECEIVEDEPT_ID,RECEIVEEMP_ID,CZY)
                VALUES('" + ZZID + "','"+GHXXID+"'," + APPLYDEPT_ID + "," + APPLYEMP_ID + "," + RECEIVEDEPT_ID + "," + RECEIVEEMP_ID + "," + CZY + ")";
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        public static bool KzzZz(int zqid, int ksid, string blh, RelationalDatabase _DataBase)
        {
         
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@blh";
                parameters[0].Value = blh;

                parameters[1].Text = "@zqid";
                parameters[1].Value = zqid;

                parameters[2].Text = "@ksid";
                parameters[2].Value = ksid;

                _DataBase.DoCommand("sp_mzhs_kzqfz", parameters,120);
                return true;
            }
            catch (Exception ea)
            {
                return false;
            }
           
        }

        #region zp 株洲中医院

        /// <summary>
        /// Add By zp 2014-06-14
        /// </summary>
        /// <param name="Fz_Br"></param>
        /// <param name="_cfg3080"></param>
        /// <returns></returns>
        public static string GetShowLabString(MZHS_FZJL Fz_Br, SystemCfg _cfg3080, SystemCfg _cfg3117)
        {
            string result = ""; //Fz_Br.patName.Trim() + "(" + Fz_Br.roomName + ")" + Fz_Br.patGHZKName;
            string xsgs = _cfg3080.Config.Trim();
            string[] par = xsgs.Split('+');

            for (int i = 0; i < par.Length; i++)
            {
                //Add by zp 2014-11-05
                if (par[i] == "候诊号")
                {
                    result += "[" + Fz_Br.patdlxh + "]";
                    continue;
                }
                //End Add By zp 2014-10-30
                if (par[i] == "姓名")
                {
                    result += Fz_Br.patName.Trim();
                    continue;
                }
                if (par[i] == "科室")
                {
                    result += "  " + Fz_Br.patGHZKName.Trim();
                    continue;
                }
                if (par[i] == "时段" && (!string.IsNullOrEmpty(Fz_Br.Sjnc.Trim())))
                {
                    result += "(" + Fz_Br.Sjnc.Trim() + ")";
                    continue;
                }
                if (par[i] == "诊室" && (!string.IsNullOrEmpty(Fz_Br.roomName.Trim())))
                {
                    if (_cfg3117.Config.Trim() == "0")
                        result += "(" + Fz_Br.roomName.Trim() + ")";
                    else
                        result += "(" + Fz_Br.patzjjc.Trim() + ")";
                    continue;
                }
                //湘潭妇幼需求 Add by zp 2014-10-23
                if (par[i] == "预约标识" && (!string.IsNullOrEmpty(Fz_Br.yysd.Trim())))
                {
                    result += " 预约";
                }

            }
            if (string.IsNullOrEmpty(result))
                result = Fz_Br.patName.Trim() + "(" + Fz_Br.roomName + ")" + Fz_Br.patGHZKName;
            return result;
        }


        /// <summary>
        /// 通过诊间id获取诊间简称 Add by zp 2014-06-23
        /// </summary>
        /// <param name="zjid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static string GetZjjc( string zjid , RelationalDatabase _DataBase )
        {
            try
            {
                string sql = @"SELECT isnull(ZJJC,'') FROM JC_ZJSZ WHERE ZJID=" + zjid + "";
                string zjjc = _DataBase.GetDataResult( sql ).ToString();
                return zjjc;
            }
            catch ( Exception ea )
            {
                throw ea;
            }
        }
        #endregion 

        /// <summary>
        /// 分诊病人状态
        /// </summary>
        public enum FzStatus : int
        {
            未分诊 = 0,
            已分诊 = 1,
            已呼叫 = 2,
            已接诊 = 3,
            已踢出队列 = 4,
            已完成 = 5
        }  
    }
}
