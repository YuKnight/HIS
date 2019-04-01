using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace YpClass
{
    /// <summary>
    /// 药品规格类
    /// </summary>
    public class Ypgg
    {
        private int _GGID;
        private int _YPLX;
        private int _YPZLX;
        private string _GJBM;
        private string _YPPM;
        private string _YPSPM;
        private string _YPSPMBZ;
        private int _YPDW;
        private int _YLFL;
        private int _YPJX;
        private decimal _HLXS;
        private int _HLDW;
        private int _BZSL;
        private int _BZDW;
        private decimal _SYXL;//限量
        private string _YPGG;
        private string _ZZBZ;
        private string _GGBZ;
        private int _GGBDELETE;
        private string _PYM;
        private string _WBM;
        private int _SYFF;
        private string _GGDJSJ;
        private int _CFJB;
        private bool _DJYP;
        private bool _MZYP;
        private bool _PSYP;
        private bool _JSYP;
        private bool _GZYP;
        private bool _CFYP;
        private bool _WYYP;
        private bool _RSYP;
        private int _LYFS;
        private string _TLFL;
        private string _HWJXBM;//货位剂型编码
        private string _HHJSQ;
        private string _YPYWM;
        private string _XGSJ;
        private int _XGR;
        private string _ZT;
        private bool _GWYP;
        private int _JSYPFL; //精神药品分类
        private bool _DPZYP; //单品种药品 add by ncq 2014-04-24
        private decimal _DDDJL; //ddd剂量
        private int _DDDJLDW;//ddd剂量单位 

        private int _JBYWLX;//基本药物类型 jc_jbywzd.id Add By Tany 2015-05-25
        private int _GWYPJB;  //高危药品级别  add by pengy 2015-07-02
        private int _FZYY;  //辅助用药  add by jchl 2016-10-11
        private int _FSX;//放射性 add by zhujh 2017-02-18
        private int _HLYW;//肿瘤药物  add by chenl 2017-03-23

        public int FZYY
        {
            get { return _FZYY; }
            set { _FZYY = value; }
        }

        public int FSX
        {
            get { return _FSX; }
            set { _FSX = value; }
        }

        public int HLYW
        {
            get { return _HLYW; }
            set { _HLYW = value; }
        }

        //Modify by lwl 2011-10-12 11:00:02
        #region 抗生素
        private int _KSSDJ;
        private decimal _DDD;
        private bool _GJJBYW;

        public int KSSDJ
        {
            get { return _KSSDJ; }
            set { _KSSDJ = value; }
        }

        public decimal DDD
        {
            get { return _DDD; }
            set { _DDD = value; }
        }


        public bool GJJBYW
        {
            get { return _GJJBYW; }
            set { _GJJBYW = value; }
        }

        //Add By Tany 2015-05-25
        /// <summary>
        /// 基本药物类型
        /// </summary>
        public int JBYWLX
        {
            get { return _JBYWLX; }
            set { _JBYWLX = value; }
        }
        #endregion

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

        public int YPLX
        {
            get
            {
                return _YPLX;
            }
            set
            {
                _YPLX = value;
            }
        }

        public int YPZLX
        {
            get
            {
                return _YPZLX;
            }
            set
            {
                _YPZLX = value;
            }
        }

        public string GJBM
        {
            get
            {
                return _GJBM;
            }
            set
            {
                _GJBM = value;
            }
        }

        public string YPPM
        {
            get
            {
                return _YPPM;
            }
            set
            {
                _YPPM = value;
            }
        }

        public string YPSPM
        {
            get
            {
                return _YPSPM;
            }
            set
            {
                _YPSPM = value;
            }
        }

        public string YPSPMBZ
        {
            get
            {
                return _YPSPMBZ;
            }
            set
            {
                _YPSPMBZ = value;
            }
        }

        public int YPDW
        {
            get
            {
                return _YPDW;
            }
            set
            {
                _YPDW = value;
            }
        }

        public int YLFL
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

        public int YPJX
        {
            get
            {
                return _YPJX;
            }
            set
            {
                _YPJX = value;
            }
        }

        public decimal HLXS
        {
            get
            {
                return _HLXS;
            }
            set
            {
                _HLXS = value;
            }
        }

        public int HLDW
        {
            get
            {
                return _HLDW;
            }
            set
            {
                _HLDW = value;
            }
        }

        public int BZSL
        {
            get
            {
                return _BZSL;
            }
            set
            {
                _BZSL = value;
            }
        }

        public int BZDW
        {
            get
            {
                return _BZDW;
            }
            set
            {
                _BZDW = value;
            }
        }

        public decimal SYXL
        {
            get
            {
                return _SYXL;
            }
            set
            {
                _SYXL = value;
            }
        }

        public string YPGG
        {
            get
            {
                return _YPGG;
            }
            set
            {
                _YPGG = value;
            }
        }

        public string ZZBZ
        {
            get
            {
                return _ZZBZ;
            }
            set
            {
                _ZZBZ = value;
            }
        }

        public string GGBZ
        {
            get
            {
                return _GGBZ;
            }
            set
            {
                _GGBZ = value;
            }
        }

        public int GGBDELETE
        {
            get
            {
                return _GGBDELETE;
            }
            set
            {
                _GGBDELETE = value;
            }
        }
        public string PYM
        {
            get
            {
                return _PYM;
            }
            set
            {
                _PYM = value;
            }
        }
        public string WBM
        {
            get
            {
                return _WBM;
            }
            set
            {
                _WBM = value;
            }
        }

        public int SYFF
        {
            get
            {
                return _SYFF;
            }
            set
            {
                _SYFF = value;
            }
        }

        public string GGDJSJ
        {
            get
            {
                return _GGDJSJ;
            }
            set
            {
                _GGDJSJ = value;
            }
        }

        public int CFJB
        {
            get
            {
                return _CFJB;
            }
            set
            {
                _CFJB = value;
            }
        }

        public bool DJYP
        {
            get
            {
                return _DJYP;
            }
            set
            {
                _DJYP = value;
            }
        }
        public bool MZYP
        {
            get
            {
                return _MZYP;
            }
            set
            {
                _MZYP = value;
            }
        }
        public bool PSYP
        {
            get
            {
                return _PSYP;
            }
            set
            {
                _PSYP = value;
            }
        }
        public bool JSYP
        {
            get
            {
                return _JSYP;
            }
            set
            {
                _JSYP = value;
            }
        }
        public bool GZYP
        {
            get
            {
                return _GZYP;
            }
            set
            {
                _GZYP = value;
            }
        }
        public bool CFYP
        {
            get
            {
                return _CFYP;
            }
            set
            {
                _CFYP = value;
            }
        }
        public bool WYYP
        {
            get
            {
                return _WYYP;
            }
            set
            {
                _WYYP = value;
            }
        }
        public bool RSYP
        {
            get
            {
                return _RSYP;
            }
            set
            {
                _RSYP = value;
            }
        }
        public int LYFS
        {
            get
            {
                return _LYFS;
            }
            set
            {
                _LYFS = value;
            }
        }
        public string TLFL
        {
            get
            {
                return _TLFL;
            }
            set
            {
                _TLFL = value;
            }
        }

        public string HWJXBM
        {
            get
            {
                return _HWJXBM;
            }
            set
            {
                _HWJXBM = value;
            }
        }

        public string HHJSQ
        {
            get
            {
                return _HHJSQ;
            }
            set
            {
                _HHJSQ = value;
            }
        }

        public string YPYWM
        {
            get
            {
                return _YPYWM;
            }
            set
            {
                _YPYWM = value;
            }
        }

        public string XGSJ
        {
            get
            {
                return _XGSJ;
            }
            set
            {
                _XGSJ = value;
            }
        }

        public int XGR
        {
            get
            {
                return _XGR;
            }
            set
            {
                _XGR = value;
            }
        }

        public string ZT
        {
            get
            {
                return _ZT;
            }
            set
            {
                _ZT = value;
            }
        }
        public bool GWYP
        {
            get
            {
                return _GWYP;
            }
            set
            {
                _GWYP = value;
            }
        }
        public int JSYPFL
        {
            get
            {
                return _JSYPFL;
            }
            set
            {
                _JSYPFL = value;
            }
        }

        public bool DPZYP
        {
            get { return _DPZYP; }
            set { _DPZYP = value; }
        }

        public decimal DDDJL
        {
            get { return _DDDJL; }
            set { _DDDJL = value; }
        }

        public int DDDJLDW
        {
            get { return _DDDJLDW; }
            set { _DDDJLDW = value; }
        }

        public int GWYPJB
        {
            get { return _GWYPJB; }
            set { _GWYPJB = value; }
        }
        #endregion

        /// <summary>
        /// 空的构造函数
        /// </summary>
        public Ypgg()
        {
            _GGID = 0;
            _YPLX = 0;
            _YPZLX = 0;
            _GJBM = "";
            _YPPM = "";
            _YPSPM = "";
            _YPSPMBZ = "";
            _YPDW = 0;
            _YLFL = 0;
            _YPJX = 0;
            _HLXS = 0;
            _HLDW = 0;
            _BZSL = 0;
            _BZDW = 0;
            _SYXL = 0;
            _YPGG = "";
            _ZZBZ = "";
            _GGBZ = "";
            _GGBDELETE = -1;
            _PYM = "";
            _WBM = "";
            _SYFF = 0;
            _GGDJSJ = "";
            _CFJB = 0;
            _DJYP = false;
            _MZYP = false;
            _PSYP = false;
            _JSYP = false;
            _GZYP = false;
            _CFYP = false;
            _WYYP = false;
            _RSYP = false;
            _LYFS = 0;
            _TLFL = "";
            _HWJXBM = "";
            _HHJSQ = "";
            _YPYWM = "";
            _XGSJ = "";
            _XGR = 0;
            _ZT = "";

            _KSSDJ = 0;
            _DDD = 0;
            _GJJBYW = false;
            _GWYP = false;
            _JSYPFL = 0;

            _DPZYP = false;
            _DDDJL = 0;
            _DDDJLDW = 0;

            //Add By Tany 2015-05-25
            _JBYWLX = 0;
            _GWYPJB = 0;
            _FZYY = 0;
            _FSX = 0;
            _HLYW = 0;
        }


        /// <summary>
        /// 带规格ID的构造函数
        /// </summary>
        /// <param name="ggid"></param>
        public Ypgg(int ggid, RelationalDatabase database)
        {
            string ssql = "select * from yp_ypggd where GGID=" + ggid + "";
            DataRow row = database.GetDataRow(ssql);
            if (row != null)
            {
                _GGID = Convert.ToInt32(row["GGID"]);
                _YPLX = Convert.ToInt32(row["yplx"]);
                _YPZLX = Convert.ToInt32(row["ypzlx"]);
                _GJBM = row["gjbm"].ToString().Trim();
                _YPPM = row["yppm"].ToString().Trim();
                _YPSPM = row["ypspm"].ToString().Trim();
                _YPSPMBZ = row["ypspmbz"].ToString().Trim();
                _YPDW = Convert.ToInt32(row["ypdw"]);
                _YLFL = Convert.ToInt32(row["ylfl"]);
                _YPJX = Convert.ToInt32(row["ypjx"]);
                _HLXS = Convert.ToDecimal(row["hlxs"]);
                _HLDW = Convert.ToInt32(row["hldw"]);
                _BZSL = Convert.ToInt32(row["bzsl"]);
                _BZDW = Convert.ToInt32(row["bzdw"]);
                _SYXL = Convert.ToDecimal(row["SYXL"]);
                _YPGG = row["ypgg"].ToString().Trim();
                _ZZBZ = row["zzbz"].ToString().Trim();
                _GGBZ = row["bz"].ToString().Trim();
                _GGBDELETE = Convert.ToInt32(row["bdelete"]);
                _SYFF = Convert.ToInt32(row["SYFF"]);
                _GGDJSJ = Convert.ToString(row["DJSJ"]);
                _CFJB = Convert.ToInt32(row["CFJB"]);
                _DJYP = Convert.ToBoolean(row["DJYP"]);
                _MZYP = Convert.ToBoolean(row["MZYP"]);
                _PSYP = Convert.ToBoolean(row["PSYP"]);
                _JSYP = Convert.ToBoolean(row["JSYP"]);
                _GZYP = Convert.ToBoolean(row["GZYP"]);
                _CFYP = Convert.ToBoolean(row["CFYP"]);
                _WYYP = Convert.ToBoolean(row["WYYP"]);
                _RSYP = Convert.ToBoolean(row["RSYP"]);
                _LYFS = Convert.ToInt32(row["LYFS"]);
                _PYM = row["PYM"].ToString();
                _WBM = row["WBM"].ToString();
                _TLFL = row["TLFL"].ToString();
                _HWJXBM = row["HWJXBM"].ToString();
                _HHJSQ = row["HHJSQ"].ToString();
                _YPYWM = row["YPYWM"].ToString();
                _XGSJ = row["XGSJ"].ToString();
                _XGR = Convert.ToInt32(row["XGR"]);
                _ZT = Convertor.IsNull(row["zt"], "");
                _GWYP = Convert.ToBoolean(row["gwyp"]);
                //抗生素信息 modify by lwl 2011-10-12
                _KSSDJ = Convert.ToInt32(Convertor.IsNull(row["KSSDJID"], "0"));
                _DDD = Convert.ToDecimal(Convertor.IsNull(row["DDD"], "0"));
                _GJJBYW = Convert.ToBoolean(Convertor.IsNull(row["GJJBYW"], "false"));
                _JSYPFL = Convert.ToInt32(Convertor.IsNull(row["JSYPFL"], "0"));

                //Add By Tany 2015-05-25
                _JBYWLX = _GJJBYW ? Convert.ToInt32(Convertor.IsNull(row["JBYWLX"], "0")) : 0;

                _DPZYP = Convert.ToBoolean(row["DPZYP"]);//单品种药品

                _DDDJL = Convert.ToDecimal(Convertor.IsNull(row["DDDJL"], "0"));//ddd剂量
                _DDDJLDW = Convert.ToInt32(Convertor.IsNull(row["DDDJLDW"], "0"));//ddd剂量单位
                _GWYPJB = row["GWYPJB"] != null && row["GWYPJB"] != DBNull.Value ? Convert.ToInt32(row["GWYPJB"]) : 0; //高危药品级别


                _FZYY = Convert.ToInt32(Convertor.IsNull(row["FZYY"], "0"));//辅助用药 Modify by jchl
                _FSX = Convert.ToInt32(Convertor.IsNull(row["FSX"], "0"));//放射性 Modify by Zhujh 2017-02-18
                _HLYW = Convert.ToInt32(Convertor.IsNull(row["HLYW"], "0"));//肿瘤药物 Modify by chenli 2017-03-23

                ssql = "select * from YP_YPBM where GGID=" + ggid + " AND SPMBZ=1";
                DataRow rowbm = database.GetDataRow(ssql);
                if (rowbm != null)
                {
                    _PYM = rowbm["pym"].ToString();
                    _WBM = rowbm["wbm"].ToString();
                }
            }

        }


        /// <summary>
        /// 保存规格方法
        /// </summary>
        /// <param name="ggid">规格ID</param>
        /// <param name="errcode">错误输出代码</param>
        /// <param name="errtext">错误输出文本</param>
        public void SaveGG(out int ggid, out int errcode, out string errtext, RelationalDatabase database)
        {

            try
            {
                ParameterEx[] parameters = new ParameterEx[53];
                parameters[0].Text = "@GGID";
                parameters[0].Value = this._GGID;

                parameters[1].Text = "@YPLX";
                parameters[1].Value = this._YPLX;

                parameters[2].Text = "@YPZLX";
                parameters[2].Value = this._YPZLX;

                parameters[3].Text = "@GJBM";
                parameters[3].Value = this._GJBM;

                parameters[4].Text = "@YPPM";
                parameters[4].Value = this._YPPM;

                parameters[5].Text = "@YPSPM";
                parameters[5].Value = this._YPSPM;

                parameters[6].Text = "@YPSPMBZ";
                parameters[6].Value = this._YPSPMBZ;

                parameters[7].Text = "@YPDW";
                parameters[7].Value = this._YPDW;

                parameters[8].Text = "@YLFL";
                parameters[8].Value = this._YLFL;

                parameters[9].Text = "@YPJX";
                parameters[9].Value = this._YPJX;

                parameters[10].Text = "@HLXS";
                parameters[10].Value = this._HLXS;

                parameters[11].Text = "@HLDW";
                parameters[11].Value = this._HLDW;

                parameters[12].Text = "@BZSL";
                parameters[12].Value = this._BZSL;

                parameters[13].Text = "@BZDW";
                parameters[13].Value = this._BZDW;

                parameters[14].Text = "@SYXL";
                parameters[14].Value = this._SYXL;

                parameters[15].Text = "@YPGG";
                parameters[15].Value = this._YPGG;

                parameters[16].Text = "@ZZBZ";
                parameters[16].Value = this._ZZBZ;

                parameters[17].Text = "@BZ";
                parameters[17].Value = this._GGBZ;

                parameters[18].Text = "@BDELETE";
                parameters[18].Value = this._GGBDELETE;

                parameters[19].Text = "@SYFF";
                parameters[19].Value = this._SYFF;

                parameters[20].Text = "@CFJB";
                parameters[20].Value = this._CFJB;

                parameters[21].Text = "@DJYP";
                parameters[21].Value = this._DJYP;

                parameters[22].Text = "@MZYP";
                parameters[22].Value = this._MZYP;

                parameters[23].Text = "@PSYP";
                parameters[23].Value = this._PSYP;

                parameters[24].Text = "@JSYP";
                parameters[24].Value = this._JSYP;

                parameters[25].Text = "@GZYP";
                parameters[25].Value = this._GZYP;

                parameters[26].Text = "@CFYP";
                parameters[26].Value = this._CFYP;

                parameters[27].Text = "@WYYP";
                parameters[27].Value = this._WYYP;

                parameters[28].Text = "@LYFS";
                parameters[28].Value = this._LYFS;

                parameters[29].Text = "@PYM";
                parameters[29].Value = this._PYM;

                parameters[30].Text = "@WBM";
                parameters[30].Value = this._WBM;

                parameters[31].Text = "@TLFL";
                parameters[31].Value = this._TLFL;

                parameters[32].Text = "@hwjxbm";
                parameters[32].Value = this._HWJXBM.Trim();

                parameters[33].Text = "@YPYWM";
                parameters[33].Value = this._YPYWM.Trim();

                parameters[34].Text = "@XGR";
                parameters[34].Value = this._XGR;

                parameters[35].Text = "@RSYP";
                parameters[35].Value = this._RSYP;


                parameters[36].Text = "@Newggid";
                parameters[36].ParaDirection = ParameterDirection.Output;
                parameters[36].DataType = System.Data.DbType.Int32;
                parameters[36].ParaSize = 100;

                parameters[37].Text = "@err_code";
                parameters[37].ParaDirection = ParameterDirection.Output;
                parameters[37].DataType = System.Data.DbType.Int32;
                parameters[37].ParaSize = 100;

                parameters[38].Text = "@err_text";
                parameters[38].ParaDirection = ParameterDirection.Output;
                parameters[38].ParaSize = 100;

                parameters[39].Text = "@ZT";
                parameters[39].Value = this._ZT;

                parameters[40].Text = "@KSSDJ";
                parameters[40].Value = this._KSSDJ;

                parameters[41].Text = "@DDD";
                parameters[41].Value = this._DDD;

                parameters[42].Text = "@JBYW";
                parameters[42].Value = this._GJJBYW;

                parameters[43].Text = "@GWYP";
                parameters[43].Value = this._GWYP;

                parameters[44].Text = "@JSYPFL";
                parameters[44].Value = this._JSYPFL;

                parameters[45].Text = "@DPZYP";
                parameters[45].Value = this._DPZYP; //单品种药品


                parameters[46].Text = "@DDDJL";
                parameters[46].Value = this._DDDJL;

                parameters[47].Text = "@DDDJLDW";
                parameters[47].Value = this._DDDJLDW;

                //Add By Tany 2015-05-25
                parameters[48].Text = "@JBYWLX";
                parameters[48].Value = this._JBYWLX;

                //Add By pengy 2015-07-2
                parameters[49].Text = "@GWYPJB";
                parameters[49].Value = this._GWYPJB;

                //Add By jchl 2016-10-11
                parameters[50].Text = "@FZYY";
                parameters[50].Value = this._FZYY;

                //Add By zhujh 2017-02-18
                parameters[51].Text = "@FSX";
                parameters[51].Value = this._FSX;

                //Add By chenl 2017-03-23
                parameters[52].Text = "@HLYW";
                parameters[52].Value = this._HLYW;

                database.DoCommand("sp_yp_ypgg", parameters, 30);
                ggid = Convert.ToInt32(parameters[36].Value);
                errcode = Convert.ToInt32(parameters[37].Value);
                errtext = Convert.ToString(parameters[38].Value);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }



    }
}
