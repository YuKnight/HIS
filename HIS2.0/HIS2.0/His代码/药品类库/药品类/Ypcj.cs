using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace YpClass
{

    //20131230 ncq 添加 FKBL(付款比例) 字段

    /// <summary>
    /// 药品产地类
    /// </summary>
    public class Ypcj
    {
        private int _GGID;
        private int _CJID;
        private string _SHH;
        private int _N_YPLX;
        private int _N_YPZLX;
        private string _S_YPJX;
        private string _S_YPPM;
        private string _S_YPSPM;
        private string _S_YPSPMBZ;
        private string _S_YPGG;
        private string _S_SCCJ;
        private string _S_YPDW;
        private string _TXM;
        private int _SCCJ;
        private decimal _ZBJ;
        private decimal _PFJ;
        private decimal _LSJ;
        private decimal _ZGLSJ;
        private string _PZWH;
        private int _YXQ;
        private string _YBLX;
        private decimal _ZFBL;
        private decimal _MRKL;
        private decimal _MRJJ;
        private bool _CJBDELETE;
        private int _ZBZT;
        private string _ZBDW;
        private string _ZBQH;
        private string _CJBZ;
        private string _CJDJSJ;
        private long _YLFL;
        private string _S_YPYWM;
        private string _CGLSH;
        private int _MRGHDW;
        private decimal _FKBL;

        private bool _BHTDW;//是否合同单位

        private bool _BWBYP;//是否外部药品 Add By Tany 2015-11-24

        #region//属性定义
        public int GGID
        {
            get
            {
                return _GGID;
            }
            set
            {
                _GGID = value;
            }
        }

        public int CJID
        {
            get
            {
                return _CJID;
            }
            set
            {
                _CJID = value;
            }
        }

        public string SHH
        {
            get
            {
                return _SHH;
            }
            set
            {
                _SHH = value;
            }
        }

        public int N_YPLX
        {
            get
            {
                return _N_YPLX;
            }
            set
            {
                _N_YPLX = value;
            }
        }

        public int N_YPZLX
        {
            get
            {
                return _N_YPZLX;
            }
            set
            {
                _N_YPZLX = value;
            }
        }


        public string S_YPJX
        {
            get
            {
                return _S_YPJX;
            }
            set
            {
                _S_YPJX = value;
            }
        }

        public string S_YPPM
        {
            get
            {
                return _S_YPPM;
            }
            set
            {
                _S_YPPM = value;
            }
        }

        public string S_YPSPM
        {
            get
            {
                return _S_YPSPM;
            }
            set
            {
                _S_YPSPM = value;
            }
        }

        public string S_YPSPMBZ
        {
            get
            {
                return _S_YPSPMBZ;
            }
            set
            {
                _S_YPSPMBZ = value;
            }
        }


        public string S_YPGG
        {
            get
            {
                return _S_YPGG;
            }
            set
            {
                _S_YPGG = value;
            }
        }

        public string S_SCCJ
        {
            get
            {
                return _S_SCCJ;
            }
            set
            {
                _S_SCCJ = value;
            }
        }

        public string S_YPDW
        {
            get
            {
                return _S_YPDW;
            }
            set
            {
                _S_YPDW = value;
            }
        }


        public string TXM
        {
            get
            {
                return _TXM;
            }
            set
            {
                _TXM = value;
            }
        }

        public int SCCJ
        {
            get
            {
                return _SCCJ;
            }
            set
            {
                _SCCJ = value;
            }
        }

        public decimal ZBJ
        {
            get
            {
                return _ZBJ;
            }
            set
            {
                _ZBJ = value;
            }
        }

        public decimal PFJ
        {
            get
            {
                return _PFJ;
            }
            set
            {
                _PFJ = value;
            }
        }

        public decimal LSJ
        {
            get
            {
                return _LSJ;
            }
            set
            {
                _LSJ = value;
            }
        }

        public string PZWH
        {
            get
            {
                return _PZWH;
            }
            set
            {
                _PZWH = value;
            }
        }

        public int YXQ
        {
            get
            {
                return _YXQ;
            }
            set
            {
                _YXQ = value;
            }
        }

        public string YBLX
        {
            get
            {
                return _YBLX;
            }
            set
            {
                _YBLX = value;
            }
        }

        public decimal ZFBL
        {
            get
            {
                return _ZFBL;
            }
            set
            {
                _ZFBL = value;
            }
        }

        public decimal MRKL
        {
            get
            {
                return _MRKL;
            }
            set
            {
                _MRKL = value;
            }
        }

        public decimal MRJJ
        {
            get
            {
                return _MRJJ;
            }
            set
            {
                _MRJJ = value;
            }
        }

        public bool CJBDELETE
        {
            get
            {
                return _CJBDELETE;
            }
            set
            {
                _CJBDELETE = value;
            }
        }

        public int ZBZT
        {
            get
            {
                return _ZBZT;
            }
            set
            {
                _ZBZT = value;
            }
        }

        public string ZBDW
        {
            get
            {
                return _ZBDW;
            }
            set
            {
                _ZBDW = value;
            }
        }

        public string ZBQH
        {
            get
            {
                return _ZBQH;
            }
            set
            {
                _ZBQH = value;
            }
        }

        public string CJBZ
        {
            get
            {
                return _CJBZ;
            }
            set
            {
                _CJBZ = value;
            }
        }

        public decimal ZGLSJ
        {
            get
            {
                return _ZGLSJ;
            }
            set
            {
                _ZGLSJ = value;
            }
        }

        public string CJDJSJ
        {
            get
            {
                return _CJDJSJ;
            }
            set
            {
                _CJDJSJ = value;
            }
        }

        public long YLFL
        {
            get
            {
                return _YLFL;
            }
            set
            {
                _YLFL = value;
            }
        }
        public string S_YPYWM
        {
            get
            {
                return _S_YPYWM;
            }
            set
            {
                _S_YPYWM = value;
            }
        }
        public string CGLSH
        {
            get
            {
                return _CGLSH;
            }
            set
            {
                _CGLSH = value;
            }
        }
        public int MRGHDW
        {
            get
            {
                return _MRGHDW;
            }
            set
            {
                _MRGHDW = value;
            }
        }

        public decimal FKBL
        {
            get
            {
                return _FKBL;
            }
            set
            {
                _FKBL = value;
            }
        }

        public bool BHTDW
        {
            get { return _BHTDW; }
            set { _BHTDW = value; }
        }

        //Add By Tany 2015-11-24
        /// <summary>
        /// 是否外部药品
        /// </summary>
        public bool BWBYP
        {
            get { return _BWBYP; }
            set { _BWBYP = value; }
        }


        #endregion

        /// <summary>
        /// 空的构造函数
        /// </summary>
        public Ypcj()
        {
            _GGID = 0;
            _CJID = 0;
            _SHH = "";
            _N_YPLX = 0;
            _N_YPZLX = 0;
            _S_YPJX = "";
            _S_YPPM = "";
            _S_YPSPM = "";
            _S_YPSPMBZ = "";
            _S_YPGG = "";
            _S_SCCJ = "";
            _S_YPDW = "";
            _TXM = "";
            _SCCJ = 0;
            _ZBJ = 0;
            _PFJ = 0;
            _LSJ = 0;
            _PZWH = "";
            _YXQ = 0;
            _YBLX = "";
            _ZFBL = 0;
            _MRKL = 0;
            _MRJJ = 0;
            _CJBDELETE = false;
            _ZBZT = 0;
            _ZBDW = "";
            _ZBQH = "";
            _CJBZ = "";
            _ZGLSJ = 0;
            _CJDJSJ = "";
            _YLFL = 0;
            _S_YPYWM = "";
            _CGLSH = "";
            _MRGHDW = 0;
            _FKBL = 1;

        }


        /// <summary>
        /// 带厂家ID的构造函数
        /// </summary>
        /// <param name="cjid"></param>
        public Ypcj(int cjid, RelationalDatabase database)
        {
            _GGID = 0;
            _CJID = 0;
            _SHH = "";
            _N_YPLX = 0;
            _N_YPZLX = 0;
            _S_YPJX = "";
            _S_YPPM = "";
            _S_YPSPM = "";
            _S_YPSPMBZ = "";
            _S_YPGG = "";
            _S_SCCJ = "";
            _S_YPDW = "";
            _TXM = "";
            _SCCJ = 0;
            _ZBJ = 0;
            _PFJ = 0;
            _LSJ = 0;
            _PZWH = "";
            _YXQ = 0;
            _YBLX = "";
            _ZFBL = 0;
            _MRKL = 0;
            _MRJJ = 0;
            _CJBDELETE = false;
            _ZBZT = 0;
            _ZBDW = "";
            _ZBQH = "";
            _CJBZ = "";
            _ZGLSJ = 0;
            _CJDJSJ = "";
            _YLFL = 0;
            _S_YPYWM = "";
            _CGLSH = "";
            _MRGHDW = 0;
            _FKBL = 1;
            _BHTDW = false;
            _BWBYP = false;//是否外部药品 Add By Tany 2015-11-24

            string ssql = "select * from yp_ypcjd where CJID=" + cjid + "";
            DataRow row = database.GetDataRow(ssql);
            if (row != null)
            {
                _GGID = Convert.ToInt32(row["GGID"]);
                _CJID = Convert.ToInt32(row["CJID"]);
                _SHH = Convert.ToString(row["SHH"]);
                _N_YPLX = Convert.ToInt32(row["N_YPLX"]);
                _N_YPZLX = Convert.ToInt32(row["N_YPZLX"]);
                _S_YPJX = Convert.ToString(row["S_YPJX"]);
                _S_YPPM = Convert.ToString(row["S_YPPM"]);
                _S_YPSPM = Convert.ToString(row["S_YPSPM"]);
                _S_YPSPMBZ = Convert.ToString(row["S_YPSPMBZ"]);
                _S_YPGG = Convert.ToString(row["S_YPGG"]);
                _S_SCCJ = Convert.ToString(row["S_SCCJ"]);
                _S_YPDW = Convert.ToString(row["S_YPDW"]);
                _TXM = Convert.ToString(row["TXM"]);
                _SCCJ = Convert.ToInt32(row["SCCJ"]);
                _ZBJ = Convert.ToDecimal(row["ZBJ"]);
                _PFJ = Convert.ToDecimal(row["PFJ"]);
                _LSJ = Convert.ToDecimal(row["LSJ"]);
                _PZWH = Convert.ToString(row["PZWH"]);
                _YXQ = Convert.ToInt32(row["YXQ"]);
                _YBLX = Convert.ToString(row["YBLX"]);
                _ZFBL = Convert.ToDecimal(row["ZFBL"]);
                _MRKL = Convert.ToDecimal(row["MRKL"]);
                _MRJJ = Convert.ToDecimal(row["MRJJ"]);
                _CJBDELETE = Convert.ToBoolean(row["BDELETE"]);
                _ZBZT = Convert.ToInt32(row["ZBZT"]);
                _ZBDW = Convert.ToString(row["ZBDW"]);
                _ZBQH = Convert.ToString(row["ZBQH"]);
                _CJBZ = Convert.ToString(row["BZ"]);
                _ZGLSJ = Convert.ToDecimal(row["ZGLSJ"]);
                _CJDJSJ = Convert.ToString(row["DJSJ"]);
                _S_YPYWM = Convert.ToString(row["S_YPYWM"]);
                _CGLSH = Convert.ToString(row["CGLSH"]);
                _MRGHDW = Convert.ToInt32(row["MRGHDW"]);
                _FKBL = Convert.ToDecimal(row["FKBL"]);//付款比例
                _BHTDW = Convert.ToBoolean(row["BHTDW"]);//是否合同单位
                _BWBYP = Convertor.IsNull(row["iswbyp"], "0") == "1" ? true : false;//是否外部药品 Add By Tany 2015-11-24
            }


        }


        /// <summary>
        /// 保存规格方法
        /// </summary>
        /// <param name="ggid"></param>CJID</param>
        /// <param name="errcode">错误输出代码</param>
        /// <param name="errtext">错误输出文本</param>
        public void SaveCJ(out int Newcjid, out int errcode, out string errtext, RelationalDatabase database)
        {


            try
            {
                if (_GGID == 0)
                {
                    throw new System.Exception("没有规格ID");
                }

                ParameterEx[] parameters = new ParameterEx[38];
                parameters[0].Text = "@CJID";
                parameters[0].Value = this._CJID;

                parameters[1].Text = "@GGID";
                parameters[1].Value = this._GGID;

                parameters[2].Text = "@N_YPLX";
                parameters[2].Value = this.N_YPLX;

                parameters[3].Text = "@N_YPZLX";
                parameters[3].Value = this._N_YPZLX;

                parameters[4].Text = "@S_YPJX";
                parameters[4].Value = this._S_YPJX;

                parameters[5].Text = "@S_YPPM";
                parameters[5].Value = this._S_YPPM;

                parameters[6].Text = "@S_YPSPM";
                parameters[6].Value = this._S_YPSPM;

                parameters[7].Text = "@S_YPSPMBZ";
                parameters[7].Value = this._S_YPSPMBZ;

                parameters[8].Text = "@S_YPGG";
                parameters[8].Value = this._S_YPGG;

                parameters[9].Text = "@S_SCCJ";
                parameters[9].Value = this._S_SCCJ;

                parameters[10].Text = "@S_YPDW";
                parameters[10].Value = this._S_YPDW;


                parameters[11].Text = "@TXM";
                parameters[11].Value = this._TXM;

                parameters[12].Text = "@SCCJ";
                parameters[12].Value = this._SCCJ;

                parameters[13].Text = "@ZBJ";
                parameters[13].Value = this._ZBJ;

                parameters[14].Text = "@PFJ";
                parameters[14].Value = this._PFJ;

                parameters[15].Text = "@LSJ";
                parameters[15].Value = this._LSJ;

                parameters[16].Text = "@PZWH";
                parameters[16].Value = this._PZWH;

                parameters[17].Text = "@YXQ";
                parameters[17].Value = this._YXQ;

                parameters[18].Text = "@YBLX";
                parameters[18].Value = this._YBLX;

                parameters[19].Text = "@ZFBL";
                parameters[19].Value = this._ZFBL / 100;

                parameters[20].Text = "@MRKL";
                parameters[20].Value = this._MRKL;

                parameters[21].Text = "@MRJJ";
                parameters[21].Value = this._MRJJ;

                parameters[22].Text = "@BDELETE";
                parameters[22].Value = this._CJBDELETE;

                parameters[23].Text = "@ZBZT";
                parameters[23].Value = this._ZBZT;

                parameters[24].Text = "@ZBDW";
                parameters[24].Value = this._ZBDW;

                parameters[25].Text = "@ZBQH";
                parameters[25].Value = this._ZBQH;

                parameters[26].Text = "@BZ";
                parameters[26].Value = this._CJBZ;

                parameters[27].Text = "@ZGLSJ";
                parameters[27].Value = this._ZGLSJ;

                parameters[28].Text = "@YLFL";
                parameters[28].Value = this._YLFL;

                parameters[29].Text = "@S_YPYWM";
                parameters[29].Value = this._S_YPYWM;

                parameters[30].Text = "@shh";
                parameters[30].Value = this.SHH;

                parameters[31].Text = "@Newcjid";
                parameters[31].Value = 0;
                parameters[31].ParaDirection = ParameterDirection.Output;

                parameters[32].Text = "@err_code";
                parameters[32].Value = 0;
                parameters[32].ParaDirection = ParameterDirection.Output;

                parameters[33].Text = "@err_text";
                parameters[33].Value = "";
                parameters[33].ParaDirection = ParameterDirection.Output;
                parameters[33].ParaSize = 100;

                parameters[34].Text = "@CGLSH";
                parameters[34].Value = this.CGLSH;

                parameters[35].Text = "@MRGHDW";
                parameters[35].Value = this._MRGHDW;

                parameters[36].Text = "@FKBL";
                parameters[36].Value = this._FKBL;

                parameters[37].Text = "@BHTDW";
                parameters[37].Value = this._BHTDW;

                database.DoCommand("sp_yp_ypcj", parameters, 30);

                Newcjid = Convert.ToInt32(parameters[31].Value);
                errcode = Convert.ToInt32(parameters[32].Value);
                errtext = Convert.ToString(parameters[33].Value);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }

        }


        /// <summary>
        /// 删除厂家方法
        /// </summary>
        /// <param name="ggid">规格ID</param>
        /// <param name="cjid">厂家ID</param>
        public static void DeleteCJ(int ggid, int cjid, RelationalDatabase database)
        {
            string ssql = "select * from yk_kcmx where CJID=" + cjid + "";
            DataRow row = database.GetDataRow(ssql);
            if (row != null) throw new Exception("该药品已有使用记录,不能删除");

            ssql = "select * from yf_kcmx where CJID=" + cjid + "";
            row = database.GetDataRow(ssql);
            if (row != null) throw new Exception("该药品已有使用记录,不能删除");

            ssql = "delete  from yp_ypcjd where CJID=" + cjid + "";
            database.DoCommand(ssql);

            ssql = "select * from yp_ypcjd where GGID=" + ggid + "";
            row = database.GetDataRow(ssql);
            if (row == null)
            {
                ssql = "delete  from yp_ypggd where GGID=" + ggid + "";
                database.DoCommand(ssql);

                ssql = "delete  from yp_ypbm where GGID=" + ggid + "";
                database.DoCommand(ssql);

            }
        }

        /// <summary>
        /// 查询当前规格下是否添加个这个厂家
        /// </summary>
        /// <param name="ggid">规格ID</param>
        /// <param name="sccj">生产厂家ID</param>
        /// <returns></returns>
        public static bool SelectGG_SCCJ(int ggid, int sccj, RelationalDatabase database)
        {
            string ssql = "select * from yp_ypcjd where ggid=" + ggid + " and sccj=" + sccj + "";
            DataTable tb = database.GetDataTable(ssql);
            if (tb.Rows.Count > 0) return true; else return false;
        }



        public void Update_shh(int ggid, out int errcode, out string errtext, RelationalDatabase database)
        {


            try
            {

                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@GGID";
                parameters[0].Value = ggid;

                parameters[1].Text = "@err_code";
                parameters[1].Value = 0;
                parameters[1].ParaDirection = ParameterDirection.Output;

                parameters[2].Text = "@err_text";
                parameters[2].Value = "";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                database.DoCommand("sp_yp_ypcjd_update_shh", parameters, 30);

                errcode = Convert.ToInt32(parameters[1].Value);
                errtext = Convert.ToString(parameters[2].Value);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }

        }


    }
}
