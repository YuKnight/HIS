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
    public class mz_ghxx
    {
        private int _ghlx;
        private int _ghks;
        private int _ghys;
        private bool _blbf;
        private bool _mfh;
        private int _ghjb;
        private int _zsid;
        private Guid _ghxxid = Guid.Empty;
        private int _yhbz;
        private Guid _kdjid;

        public Guid kdjid
        {
            get
            {
                return _kdjid;
            }
            set
            {
                _kdjid = value;
            }
        }
        /// <summary>
        /// 有号或无号标志
        /// </summary>
        public int yhbz
        {
            get
            {
                return _yhbz;
            }
            set
            {
                _yhbz = value;
            }
        }
        /// <summary>
        /// 挂号信息ID
        /// </summary>
        public Guid ghxxid
        {
            get
            {
                return _ghxxid;
            }
            set
            {
                _ghxxid = value;
            }
        }
        /// <summary>
        /// 诊室ID
        /// </summary>
        public int zsid
        {
            get
            {
                return _zsid;
            }
            set
            {
                _zsid = value;
            }
        }
        /// <summary>
        /// 挂号级别
        /// </summary>
        public int ghjb
        {
            get
            {
                return _ghjb;
            }
            set
            {
                _ghjb = value;
            }
        }
        /// <summary>
        /// 是否是免费号
        /// </summary>
        public bool mfh
        {
            get
            {
                return _mfh;
            }
            set
            {
                 _mfh= value ;
            }
        }
        /// <summary>
        /// 是否收取病历本费
        /// </summary>
        public bool blbf
        {
            get
            {
                return _blbf;
            }
            set
            {
                _blbf = value;
            }
        }
        /// <summary>
        /// 挂号医生
        /// </summary>
        public int ghys
        {
            get
            {
                return _ghys;
            }
            set
            {
                _ghys = value;
            }
        }
        /// <summary>
        /// 挂号科室
        /// </summary>
        public int ghks
        {
            get
            {
                return _ghks;
            }
            set
            {
                _ghks = value;
            }
        }
        /// <summary>
        /// 挂号类型
        /// </summary>
        public int ghlx
        {
            get
            {
                return _ghlx;
            }
            set
            {
                _ghlx = value;
            }
        }
        
        
        /// <summary>
        /// 获取挂号收费明细
        /// </summary>
        /// <param name="ghlx">挂号类型</param>
        /// <param name="brlx">病人类型</param>
        /// <param name="brlx">医保类型</param>
        /// <param name="ghks">挂号科室</param>
        /// <param name="ghjb">挂号级别</param>
        /// <param name="ghys">挂号医生</param>
        /// <param name="blb">病历本</param>
        /// <param name="ybzf">医保支付</param>
        /// <param name="err_code">错误号</param>
        /// <param name="err_text">错误文本</param>
        /// <returns></returns>
        public static DataSet mzgh_get_sfmx(int ghlx, int brlx, int yblx, int ghks, int ghjb, int ghys, string blb, decimal ybzf, int klx, Guid yhlxid, long jgbm, out int err_code, out string err_text, string funname, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[14];
                parameters[0].Text = "@ghlx";
                parameters[0].Value = ghlx;

                parameters[1].Text = "@brlx";
                parameters[1].Value = brlx;

                parameters[2].Text = "@yblx";
                parameters[2].Value = yblx;

                parameters[3].Text = "@ghks";
                parameters[3].Value = ghks;

                parameters[4].Text = "@ghjb";
                parameters[4].Value = ghjb;

                parameters[5].Text = "@ghys";
                parameters[5].Value = ghys;

                parameters[6].Text = "@blb";
                parameters[6].Value = blb;

                parameters[7].Text = "@ybzf";
                parameters[7].Value = ybzf;

                parameters[8].Text = "@klx";
                parameters[8].Value = klx;

                parameters[9].Text = "@yhlxid";
                parameters[9].Value = yhlxid;

                parameters[10].Text = "@jgbm";
                parameters[10].Value = jgbm;

                parameters[11].Text = "@err_code";
                parameters[11].ParaDirection = ParameterDirection.Output;
                parameters[11].DataType = System.Data.DbType.Int32;
                parameters[11].ParaSize = 100;

                parameters[12].Text = "@err_text";
                parameters[12].ParaDirection = ParameterDirection.Output;
                parameters[12].ParaSize = 100;

                parameters[13].Text = "@funname";
                parameters[13].Value = funname;

                DataSet dset = new DataSet();
                _DataBase.AdapterFillDataSet("SP_MZGH_get_sfmx", parameters, dset, "ghsfxx", 30);
                err_code = Convert.ToInt32(parameters[11].Value);
                err_text = Convert.ToString(parameters[12].Value);
                return dset;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        /// <summary>
        /// 保存或修改挂号信息
        /// </summary>
        /// <param name="ghxxid">挂号信息id</param>
        /// <param name="brxxid">病人信息ID</param>
        /// <param name="ghlb">挂号类别</param>
        /// <param name="klx">卡类型</param>
        /// <param name="kh">卡号</param>
        /// <param name="blh">病历号</param>
        /// <param name="ghks">挂号科室</param>
        /// <param name="ghys">挂号医生</param>
        /// <param name="ghjb">挂号级别</param>
        /// <param name="ghje">挂号金额</param>
        /// <param name="djy">登记员</param>
        /// <param name="byhbz">有号标志</param>
        /// <param name="ghck">挂号窗口</param>
        /// <param name="pdxh">排队序号</param>
        /// <param name="pdxh">机构编码</param>
        /// <param name="NewGhxxid">返回新挂号信息ID</param>
        /// <param name="err_code">返回错误号 当错误<>0 时需抛出错误</param>
        /// <param name="err_text">返回错误文件</param>
        public static void GhxxDj(Guid ghxxid, Guid brxxid, int ghlb, Guid kdjid, string blh, int ghks, int ghys, int ghjb, decimal ghje, int djy, int byhbz, string ghck, ref int pdxh, long dnlxh, string fph, long jgbm, out Guid NewGhxxid, out int err_code, out string err_text, int htdwlx, int htdwid, int yb_lx, string yb_dylx, string yb_dylxmc, string yb_bzxx, int yylx, string yysd, string yyqtxx, string ghsj, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[29];
                parameters[0].Text = "@ghxxid";
                parameters[0].Value = ghxxid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghlb";
                parameters[2].Value = ghlb;

                parameters[3].Text = "@kdjid";
                parameters[3].Value = kdjid;

                parameters[4].Text = "@blh";
                parameters[4].Value = blh;

                parameters[5].Text = "@ghks";
                parameters[5].Value = ghks;

                parameters[6].Text = "@ghys";
                parameters[6].Value = ghys;

                parameters[7].Text = "@ghjb";
                parameters[7].Value = ghjb;

                parameters[8].Text = "@ghje";
                parameters[8].Value = ghje;

                parameters[9].Text = "@djy";
                parameters[9].Value = djy;

                parameters[10].Text = "@byhbz";
                parameters[10].Value = byhbz;

                parameters[11].Text = "@ghck";
                parameters[11].Value = ghck;


                parameters[12].Text = "@pdxh";
                parameters[12].ParaDirection = ParameterDirection.InputOutput;
                parameters[12].DataType = System.Data.DbType.Int32;
                parameters[12].ParaSize = 100;
                parameters[12].Value = pdxh;

                parameters[13].Text = "@dnlxh";
                parameters[13].Value = dnlxh;

                parameters[14].Text = "@fph";
                parameters[14].Value = fph;

                parameters[15].Text = "@jgbm";
                parameters[15].Value = jgbm;

                parameters[16].Text = "@NewGhxxid";
                parameters[16].ParaDirection = ParameterDirection.Output;
                parameters[16].DataType = System.Data.DbType.Guid;
                parameters[16].ParaSize = 100;

                parameters[17].Text = "@err_code";
                parameters[17].ParaDirection = ParameterDirection.Output;
                parameters[17].DataType = System.Data.DbType.Int32;
                parameters[17].ParaSize = 100;

                parameters[18].Text = "@err_text";
                parameters[18].ParaDirection = ParameterDirection.Output;
                parameters[18].ParaSize = 100;

                parameters[19].Text = "@htdwlx";
                parameters[19].Value = htdwlx;

                parameters[20].Text = "@htdwid";
                parameters[20].Value = htdwid;

                parameters[21].Text = "@yb_lx";
                parameters[21].Value = yb_lx;

                parameters[22].Text = "@yb_dylx";
                parameters[22].Value = Convertor.IsNull(yb_dylx, "");

                parameters[23].Text = "@yb_dylxmc";
                parameters[23].Value = Convertor.IsNull(yb_dylxmc, "");

                parameters[24].Text = "@yb_bzxx";
                parameters[24].Value = Convertor.IsNull(yb_bzxx, "");

                parameters[25].Text = "@yylx";
                parameters[25].Value = Convertor.IsNull(yylx, "");

                parameters[26].Text = "@yysd";
                parameters[26].Value = Convertor.IsNull(yysd, "");

                parameters[27].Text = "@yyqtxx";
                parameters[27].Value = Convertor.IsNull(yyqtxx, "");

                parameters[28].Text = "@ghsj";
                parameters[28].Value = Convertor.IsNull(ghsj, "");


                _DataBase.DoCommand("SP_MZGH_ghxxdj", parameters, 30);

                pdxh = Convert.ToInt32(parameters[12].Value);
                NewGhxxid = new Guid(parameters[16].Value.ToString());
                err_code = Convert.ToInt32(parameters[17].Value);
                err_text = Convert.ToString(parameters[18].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }

        /// <summary>
        /// 取消挂号
        /// </summary>
        /// <param name="ghxxid">挂号信息id</param>
        /// <param name="sdate">取消挂号时间</param>
        /// <param name="czy">操作员</param>
        /// <param name="NRows">影响行数</param>
        /// <param name="err_code">错误号</param>
        /// <param name="err_text">错误文本</param>
        public static void CancelGh(Guid ghxxid, string sdate, int czy, out int NRows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            string ssql = "update mz_ghxx set bqxghbz=1,qxghsj='" + sdate + "',qxghczy=" + czy + " where ghxxid='" + ghxxid + "' and bqxghbz=0";
            NRows = _DataBase.DoCommand(ssql);
            err_code = 0;
            err_text = "";
        }

        //public static void GetXhs(int ysdm, out int yghs, out int xhs, out int swxhs, out int xwxhs, out int lsjh, RelationalDatabase _DataBase)
        //{
        //    string ssql = "select isnull(count(pdxh),0) as yghs,xhs,swxhs,xwxhs,lsjh from jc_ysxhsz a left  join MZ_GHXX b " +
        //    " on a.ysdm=b.ghys and ghsj>=convert(datetime,convert(varchar,getdate(),112)) and bqxghbz=0 where ysdm="+ysdm+" "+
        //    " group by xhs,swxhs,xwxhs,lsjh";
        //    DataTable tb = _DataBase.GetDataTable(ssql);
        //    if (tb.Rows.Count > 0)
        //    {
        //        yghs = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["yghs"], "0"));
        //        xhs = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["xhs"], "0"));
        //        swxhs = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["swxhs"], "0"));
        //        xwxhs = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["xwxhs"], "0"));
        //        lsjh = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["lsjh"], "0"));
        //    }
        //    else
        //    {
        //        yghs = 0;
        //        xhs = 0;
        //        swxhs = 0;
        //        xwxhs = 0;
        //        lsjh = 0;
        //    }
        //}

        public static void UpdateHtdw(Guid ghxxid, int htdwlx, int htdwid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "@ghxxid";
                parameters[0].Value = ghxxid;

                parameters[1].Text = "@htdwlx";
                parameters[1].Value = htdwlx;

                parameters[2].Text = "@htdwid";
                parameters[2].Value = htdwid;

                parameters[3].Text = "@err_code";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].DataType = System.Data.DbType.Int32;
                parameters[3].ParaSize = 100;

                parameters[4].Text = "@err_text";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].ParaSize = 100;

                _DataBase.DoCommand("SP_MZGH_UPDATE_HTDW", parameters, 30);
                err_code = Convert.ToInt32(parameters[3].Value);
                err_text = Convert.ToString(parameters[4].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }


        /// <summary>
        /// 保存预约号
        /// </summary>
        /// <param name="yyid"></param>
        /// <param name="yylx"></param>
        /// <param name="kh"></param>
        /// <param name="brxm"></param>
        /// <param name="xb"></param>
        /// <param name="csrq"></param>
        /// <param name="jtdz"></param>
        /// <param name="lxdh"></param>
        /// <param name="sfzh"></param>
        /// <param name="yzm"></param>
        /// <param name="ghks"></param>
        /// <param name="ghjb"></param>
        /// <param name="ghys"></param>
        /// <param name="pdxh"></param>
        /// <param name="djsj"></param>
        /// <param name="djy"></param>
        /// <param name="yyrq"></param>
        /// <param name="yysd"></param>
        /// <param name="sxsj"></param>
        /// <param name="bscbz"></param>
        /// <param name="newYzm"></param>
        /// <param name="newPdxh"></param>
        /// <param name="newYYid"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        public static void YYGH_save(Guid yyid, int yylx, string kh, string brxm, string xb, string csrq, string jtdz, string lxdh, string sfzh, string yzm, int ghks, int ghjb, int ghys, int pdxh, string djsj, int djy, string yyrq, string yysd, string sxsj, int bscbz, out string newYzm, out string newPdxh, out Guid newYYid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[25];
                parameters[0].Text = "@yyid";
                parameters[0].Value = yyid;

                parameters[1].Text = "@yylx";
                parameters[1].Value = yylx;

                parameters[2].Text = "@kh";
                parameters[2].Value = kh;

                parameters[3].Text = "@brxm";
                parameters[3].Value = brxm;

                parameters[4].Text = "@xb";
                parameters[4].Value = xb;

                parameters[5].Text = "@csrq";
                parameters[5].Value = csrq;

                parameters[6].Text = "@jtdz";
                parameters[6].Value = jtdz;

                parameters[7].Text = "@lxdh";
                parameters[7].Value = lxdh;

                parameters[8].Text = "@sfzh";
                parameters[8].Value = sfzh;

                parameters[9].Text = "@yzm";
                parameters[9].Value = yzm;

                parameters[10].Text = "@ghks";
                parameters[10].Value = ghks;

                parameters[11].Text = "@ghjb";
                parameters[11].Value = ghjb;

                parameters[12].Text = "@ghys";
                parameters[12].Value = ghys;

                parameters[13].Text = "@pdxh";
                parameters[13].Value = pdxh;

                parameters[14].Text = "@djsj";
                parameters[14].Value = djsj;

                parameters[15].Text = "@djy";
                parameters[15].Value = djy;

                parameters[16].Text = "@yyrq";
                parameters[16].Value = yyrq;

                parameters[17].Text = "@yysd";
                parameters[17].Value = yysd;

                parameters[18].Text = "@sxsj";
                parameters[18].Value = sxsj;

                parameters[19].Text = "@bscbz";
                parameters[19].Value = bscbz;

                parameters[20].Text = "@NEWYZM";
                parameters[20].ParaDirection = ParameterDirection.Output;
                parameters[20].ParaSize = 100;

                parameters[21].Text = "@NEWPDXH";
                parameters[21].ParaDirection = ParameterDirection.Output;
                parameters[21].ParaSize = 100;

                parameters[22].Text = "@Newyyid";
                parameters[22].ParaDirection = ParameterDirection.Output;
                parameters[22].DataType = System.Data.DbType.Guid;
                parameters[22].ParaSize = 100;

                parameters[23].Text = "@err_code";
                parameters[23].ParaDirection = ParameterDirection.Output;
                parameters[23].DataType = System.Data.DbType.Int32;
                parameters[23].ParaSize = 100;

                parameters[24].Text = "@err_text";
                parameters[24].ParaDirection = ParameterDirection.Output;
                parameters[24].ParaSize = 100;


                _DataBase.DoCommand("SP_MZSF_saveYYGH", parameters, 30);

                newYzm = Convert.ToString(parameters[20].Value);
                newPdxh = Convert.ToString(parameters[21].Value);
                newYYid = new Guid(parameters[22].Value.ToString());
                err_code = Convert.ToInt32(parameters[23].Value);
                err_text = Convert.ToString(parameters[24].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }

        /// <summary>
        /// 预约取号
        /// </summary>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="_DataBase"></param>
        public static DataTable YYQH(string sfzh, string kh, string brxm, string yzm, string lxdh, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                err_code = -1;
                err_text = "";
                //DlgInputBox Inputbox = new DlgInputBox("", "请输入取号验证码","取号验证");
                //Inputbox.NumCtrl = false;
                //Inputbox.ShowDialog();
                //if (DlgInputBox.DlgResult == false) { DataRow row = null; return row; }

                try
                {
                    ParameterEx[] parameters = new ParameterEx[7];

                    parameters[0].Text = "@YYID";
                    parameters[0].Value = Guid.Empty;

                    parameters[1].Text = "@YZM";
                    parameters[1].Value = yzm;

                    parameters[2].Text = "@sfzh";
                    parameters[2].Value = sfzh;

                    parameters[3].Text = "@kh";
                    parameters[3].Value = kh;

                    parameters[4].Text = "@brxm";
                    parameters[4].Value = brxm;

                    parameters[5].Text = "@err_code";
                    parameters[5].ParaDirection = ParameterDirection.Output;
                    parameters[5].DataType = System.Data.DbType.Int32;
                    parameters[5].ParaSize = 100;

                    parameters[6].Text = "@err_text";
                    parameters[6].ParaDirection = ParameterDirection.Output;
                    parameters[6].ParaSize = 100;

                    DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZSF_GetYYGH", parameters, 30);

                    err_code = Convert.ToInt32(parameters[5].Value);
                    err_text = Convert.ToString(parameters[6].Value);
                    if (err_code != 0) throw new Exception(err_text);
                    //if (tb.Rows.Count == 0) throw new Exception("没有找到预约记录,请确认验证码是否输入正确");
                    //Frmyyjl f = new Frmyyjl( "取预约号");
                    //f.dataGridView1.DataSource = tb;
                    //f.ShowDialog();
                    //if (f.Bok == false) { DataRow row =null; return row; }

                    //return f.ReturnRow;
                    return tb;

                }
                catch (System.Exception err)
                {
                    throw new System.Exception(err.Message);
                }

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        //更新预约取号状态
        public static void UpateYyghxx(Guid YYID, Guid ghxxid, string sdate, RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Text = "@YYID";
            parameters[0].Value = YYID;

            parameters[1].Text = "@qhsj";
            parameters[1].Value = sdate;

            parameters[2].Text = "@ghxxid";
            parameters[2].Value = ghxxid;

            parameters[3].Text = "@err_code";
            parameters[3].ParaDirection = ParameterDirection.Output;
            parameters[3].DataType = System.Data.DbType.Int32;
            parameters[3].ParaSize = 100;

            parameters[4].Text = "@err_text";
            parameters[4].ParaDirection = ParameterDirection.Output;
            parameters[4].ParaSize = 100;

            _DataBase.DoCommand("SP_MZGH_Update_Yyxx", parameters, 30);
            if (Convert.ToInt32(parameters[3].Value) != 0)
                throw new Exception(parameters[4].Value.ToString());

        }
        //通过挂号信息id获取挂号记录 Add by zp 2013-11-20 
        public static DataTable GetGhxx(Guid ghxxid, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM MZ_GHXX WHERE GHXXID='"+ghxxid+"'";
            dt = _DataBase.GetDataTable(sql);
            return dt;
        }
        //三医院　挂号登记增加安全员信息
        public static void GhxxDj(Guid ghxxid, Guid brxxid, int ghlb, Guid kdjid, string blh, int ghks, int ghys, int ghjb, decimal ghje, int djy, int byhbz, string ghck, ref int pdxh, long dnlxh, string fph, long jgbm, out Guid NewGhxxid, out int err_code, out string err_text, int htdwlx, int htdwid, int yb_lx, string yb_dylx, string yb_dylxmc, string yb_bzxx, int yylx, string yysd, string yyqtxx, string ghsj, int aqyid, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[30];
                parameters[0].Text = "@ghxxid";
                parameters[0].Value = ghxxid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghlb";
                parameters[2].Value = ghlb;

                parameters[3].Text = "@kdjid";
                parameters[3].Value = kdjid;

                parameters[4].Text = "@blh";
                parameters[4].Value = blh;

                parameters[5].Text = "@ghks";
                parameters[5].Value = ghks;

                parameters[6].Text = "@ghys";
                parameters[6].Value = ghys;

                parameters[7].Text = "@ghjb";
                parameters[7].Value = ghjb;

                parameters[8].Text = "@ghje";
                parameters[8].Value = ghje;

                parameters[9].Text = "@djy";
                parameters[9].Value = djy;

                parameters[10].Text = "@byhbz";
                parameters[10].Value = byhbz;

                parameters[11].Text = "@ghck";
                parameters[11].Value = ghck;


                parameters[12].Text = "@pdxh";
                parameters[12].ParaDirection = ParameterDirection.InputOutput;
                parameters[12].DataType = System.Data.DbType.Int32;
                parameters[12].ParaSize = 100;
                parameters[12].Value = pdxh;

                parameters[13].Text = "@dnlxh";
                parameters[13].Value = dnlxh;

                parameters[14].Text = "@fph";
                parameters[14].Value = fph;

                parameters[15].Text = "@jgbm";
                parameters[15].Value = jgbm;

                parameters[16].Text = "@NewGhxxid";
                parameters[16].ParaDirection = ParameterDirection.Output;
                parameters[16].DataType = System.Data.DbType.Guid;
                parameters[16].ParaSize = 100;

                parameters[17].Text = "@err_code";
                parameters[17].ParaDirection = ParameterDirection.Output;
                parameters[17].DataType = System.Data.DbType.Int32;
                parameters[17].ParaSize = 100;

                parameters[18].Text = "@err_text";
                parameters[18].ParaDirection = ParameterDirection.Output;
                parameters[18].ParaSize = 100;

                parameters[19].Text = "@htdwlx";
                parameters[19].Value = htdwlx;

                parameters[20].Text = "@htdwid";
                parameters[20].Value = htdwid;

                parameters[21].Text = "@yb_lx";
                parameters[21].Value = yb_lx;

                parameters[22].Text = "@yb_dylx";
                parameters[22].Value = Convertor.IsNull(yb_dylx, "");

                parameters[23].Text = "@yb_dylxmc";
                parameters[23].Value = Convertor.IsNull(yb_dylxmc, "");

                parameters[24].Text = "@yb_bzxx";
                parameters[24].Value = Convertor.IsNull(yb_bzxx, "");

                parameters[25].Text = "@yylx";
                parameters[25].Value = Convertor.IsNull(yylx, "");

                parameters[26].Text = "@yysd";
                parameters[26].Value = Convertor.IsNull(yysd, "");

                parameters[27].Text = "@yyqtxx";
                parameters[27].Value = Convertor.IsNull(yyqtxx, "");

                parameters[28].Text = "@ghsj";
                parameters[28].Value = Convertor.IsNull(ghsj, "");

                parameters[29].Text = "@aqyid";
                parameters[29].Value = aqyid;


                _DataBase.DoCommand("SP_MZGH_ghxxdj_aqy", parameters, 30);

                pdxh = Convert.ToInt32(parameters[12].Value);
                NewGhxxid = new Guid(parameters[16].Value.ToString());
                err_code = Convert.ToInt32(parameters[17].Value);
                err_text = Convert.ToString(parameters[18].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }

        //通过卡号获取上次挂号记录和就诊信息 Add by jiangzf 2014-8-1 
        public static DataTable GetLastestGhxx(string kh,int klx, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            string sql = @"select top 1 dbo.fun_getDeptname(a.GHKS) ghks,ghsj,b.JSKSDM jzks,dbo.fun_getEmpName(b.JSYSDM) jzys 
                            from MZ_GHXX a
                            inner join MZYS_JZJL b on a.GHXXID = b.GHXXID
                            inner join YY_KDJB c on a.KDJID = c.KDJID

                        where b.BSCBZ =0 and b.BJSBZ = 1
                                and c.KLX =" +klx+" and c.KH ='"+kh+"' order by JSSJ desc";
            dt = _DataBase.GetDataTable(sql);
            return dt;
        }
 
        /// <summary>
        /// 验证挂号科室限制条件
        /// </summary>
        /// <param name="xb">性别代码 1-男 2-女</param>
        /// <param name="bornDay">出生日期</param>
        /// <param name="regDeptId">挂号科室</param>
        /// <param name="database"></param>
        /// <param name="message">验证失败时返回的错误信息</param>
        /// <returns></returns>
        public static bool ValidingRestrictiveConditions( int? xb , DateTime? bornDay, int regDeptId , RelationalDatabase database ,out string message )
        {
            try
            {
                message = "";

                SystemCfg cfg1141 = new SystemCfg( 1141 , database ); //男性不允许挂号的科室
                SystemCfg cfg1142 = new SystemCfg( 1142 , database ); //女性不允许挂号的科室
                SystemCfg cfg1143 = new SystemCfg( 1143 , database ); //各年龄段不允许挂号的科室

                string[] man = cfg1141.Config.Split( new char[] { ',' } );
                string[] women = cfg1142.Config.Split( new char[] { ',' } );
                string[] data = cfg1143.Config.Split( new char[] { '|' } );
                DataTable dtAge = new DataTable();
                dtAge.Columns.Add( "AgeFrom" , typeof( System.Int32 ) );
                dtAge.Columns.Add( "AgeTo" , typeof( System.Int32 ) );
                dtAge.Columns.Add( "DeptId" , typeof( System.Int32 ) );
                foreach ( string str in data )
                {
                    //str: 0-3:xxx,xxx,xxx
                    if ( !string.IsNullOrEmpty( str ) )
                    {
                        string[] patrs = str.Split( new char[] { ':' } );
                        string[] ages = patrs[0].Split( new char[] { '-' } );
                        int ageFrom = Convert.ToInt32( ages[0] );
                        int ageTo = Convert.ToInt32( ages[1] );
                        string[] depts = patrs[1].Split( new char[] { ',' } );
                        foreach ( string strId in depts )
                            dtAge.Rows.Add( new object[] { ageFrom , ageTo , Convert.ToInt32( strId ) } );
                    }
                }
                string deptName = Fun.SeekDeptName( regDeptId , database );
                if ( xb != null )
                {
                    int index = -1;
                    if ( xb.Value == 1 )
                    {
                        index = cfg1141.Config.IndexOf( regDeptId.ToString() );
                        if ( index > -1 )
                        {
                            message = "男性不允许选择[" + deptName + "]科室挂号";
                            return false;
                        }
                    }
                    else
                    {
                        index = cfg1142.Config.IndexOf( regDeptId.ToString() );
                        if ( index > -1 )
                        {
                            message = "女性不允许选择[" + deptName + "]科室挂号";
                            return false;
                        }
                    }
                }
                if ( bornDay != null )
                {
                    Age age = DateManager.DateToAge( bornDay.Value , database );
                    DataRow[] row = dtAge.Select( string.Format( "{0}>=AgeFrom and {0}<=AgeTo and DeptId ={1}" , age.AgeNum , regDeptId ) );
                    if ( row.Length > 0 )
                    {
                        message = string.Format( "{0}岁不允许选择[{1}]科室挂号" , age.AgeNum , Fun.SeekDeptName( Convert.ToInt32( row[0]["DeptId"] ),database ) );
                        return false;
                    }
                }

                return true;
            }
            catch ( Exception error )
            {
                message = error.Message;
                return true;
            }
        }
        /// <summary>
        /// 验证病人信息与持卡人信息是否相同
        /// </summary>
        /// <param name="klx"></param>
        /// <param name="kh"></param>
        /// <param name="brxxid"></param>
        /// <param name="Database"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool ValidingPatInfoAndCardInfo(int klx,string kh,Guid brxxid,RelationalDatabase Database,out string message )
        {
            string sql = string.Format( "select a.brxxid,b.brxm from yy_kdjb a left join yy_brxx b on a.brxxid=b.brxxid where a.zfbz=0 and a.klx={0} and a.kh='{1}'" , klx , kh );
            DataRow rowCard = Database.GetDataRow( sql );
            message = "";
            //如果没有找到卡，并且病人信息ID是空，则表示是新卡和新病人
            if ( rowCard == null && brxxid == Guid.Empty )
                return true;

            Guid bindBrxxid = new Guid( rowCard["brxxid"].ToString() );
            if ( bindBrxxid != Guid.Empty && brxxid != Guid.Empty && bindBrxxid != brxxid )
            {
                message = string.Format( "当前卡对应的持卡人是[{0}],与当前病人姓名不一致,请重新刷卡" , rowCard["brxm"] );
                return false;
            }

            return true;
        }
    }
}
