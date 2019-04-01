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
    public class YY_BRXX
    {


        #region 属性
        private Guid _brxxid;
        /// <summary>
        /// 主键字段
        /// </summary> 
        public Guid Brxxid
        {
            get { return _brxxid; }
            set { _brxxid = value; }
        }

        private string _brxm;
        /// <summary>
        /// 
        /// </summary> 
        public string Brxm
        {
            get
            {
                return _brxm;
            }
            set
            {
                _brxm = value;
            }
        }

        private string _xb;
        /// <summary>
        /// 
        /// </summary> 
        public string Xb
        {
            get { return _xb; }
            set { _xb = value; }
        }

        private string _csrq;
        /// <summary>
        /// 
        /// </summary> 
        public string Csrq
        {
            get { return _csrq; }
            set { _csrq = value; }
        }

        private string _hyzk;
        /// <summary>
        /// 
        /// </summary> 
        public string Hyzk
        {
            get { return _hyzk; }
            set { _hyzk = value; }
        }

        private string _gj;
        /// <summary>
        /// 
        /// </summary> 
        public string Gj
        {
            get { return _gj; }
            set { _gj = value; }
        }

        private string _mz;
        /// <summary>
        /// 
        /// </summary> 
        public string Mz
        {
            get { return _mz; }
            set { _mz = value; }
        }

        private string _zy;
        /// <summary>
        /// 
        /// </summary> 
        public string Zy
        {
            get { return _zy; }
            set { _zy = value; }
        }

        private string _csdz;
        /// <summary>
        /// 
        /// </summary> 
        public string Csdz
        {
            get { return _csdz; }
            set { _csdz = value; }
        }

        private string _jtdz;
        /// <summary>
        /// 
        /// </summary> 
        public string Jtdz
        {
            get { return _jtdz; }
            set { _jtdz = value; }
        }

        private string _jtyb;
        /// <summary>
        /// 
        /// </summary> 
        public string Jtyb
        {
            get { return _jtyb; }
            set { _jtyb = value; }
        }

        private string _jtdh;
        /// <summary>
        /// 
        /// </summary> 
        public string Jtdh
        {
            get { return _jtdh; }
            set { _jtdh = value; }
        }

        private string _jtlxr;
        /// <summary>
        /// 
        /// </summary> 
        public string Jtlxr
        {
            get { return _jtlxr; }
            set { _jtlxr = value; }
        }

        private string _brlxfs;
        /// <summary>
        /// 
        /// </summary> 
        public string Brlxfs
        {
            get { return _brlxfs; }
            set { _brlxfs = value; }
        }

        private string _dzyj;
        /// <summary>
        /// 
        /// </summary> 
        public string Dzyj
        {
            get { return _dzyj; }
            set { _dzyj = value; }
        }

        private string _gzdw;
        /// <summary>
        /// 
        /// </summary> 
        public string Gzdw
        {
            get { return _gzdw; }
            set { _gzdw = value; }
        }

        private string _gzdwdz;
        /// <summary>
        /// 
        /// </summary> 
        public string Gzdwdz
        {
            get { return _gzdwdz; }
            set { _gzdwdz = value; }
        }

        private string _gzdwyb;
        /// <summary>
        /// 
        /// </summary> 
        public string Gzdwyb
        {
            get { return _gzdwyb; }
            set { _gzdwyb = value; }
        }

        private string _gzdwdh;
        /// <summary>
        /// 
        /// </summary> 
        public string Gzdwdh
        {
            get { return _gzdwdh; }
            set { _gzdwdh = value; }
        }

        private string _gzdwlxr;
        /// <summary>
        /// 
        /// </summary> 
        public string Gzdwlxr
        {
            get { return _gzdwlxr; }
            set { _gzdwlxr = value; }
        }

        private string _sfzh;
        /// <summary>
        /// 
        /// </summary> 
        public string Sfzh
        {
            get { return _sfzh; }
            set { _sfzh = value; }
        }

        private int _brlx;
        /// <summary>
        /// 
        /// </summary> 
        public int Brlx
        {
            get { return _brlx; }
            set { _brlx = value; }
        }

        private int _yblx;
        /// <summary>
        /// 
        /// </summary> 
        public int Yblx
        {
            get { return _yblx; }
            set { _yblx = value; }
        }

        private string _cbkh;
        /// <summary>
        /// 
        /// </summary> 
        public string Cbkh
        {
            get { return _cbkh; }
            set { _cbkh = value; }
        }

        private string _djsj;
        /// <summary>
        /// 
        /// </summary> 
        public string Djsj
        {
            get { return _djsj; }
            set { _djsj = value; }
        }

        private int _djy;
        /// <summary>
        /// 
        /// </summary> 
        public int Djy
        {
            get { return _djy; }
            set { _djy = value; }
        }

        private string _scxgsj;
        /// <summary>
        /// 
        /// </summary> 
        public string ScxgSj
        {
            get { return _scxgsj; }
            set { _scxgsj = value; }
        }

        private int _scxgczy;
        /// <summary>
        /// 
        /// </summary> 
        public int Scxgczy
        {
            get { return _scxgczy; }
            set { _scxgczy = value; }
        }

        private int _djly;
        /// <summary>
        /// 
        /// </summary> 
        public int Djly
        {
            get { return _djly; }
            set { _djly = value; }
        }

        private bool _bscbz;
        /// <summary>
        /// 
        /// </summary> 
        public bool BscBz
        {
            get { return _bscbz; }
        }

        private string _qtzjlx;
        /// <summary>
        /// 其他证件类型  //Add By Zj 2012-07-16
        /// </summary>
        public string Qtzjlx
        {
            get { return _qtzjlx; }
            set { _qtzjlx = value; }
        }
        private string _qtzjhm;
        /// <summary>
        /// 其他证件号码  //Add By Zj 2012-07-16
        /// </summary>
        public string Qtzjhm
        {
            get { return _qtzjhm; }
            set { _qtzjhm = value; }
        }
        private string _jkdah;
        /// <summary>
        /// 健康档案号  //Add By Zj 2012-07-16
        /// </summary>
        public string Jkdah
        {
            get { return _jkdah; }
            set { _jkdah = value; }
        }
        private string _whcddm;
        /// <summary>
        /// 文化程度代码  //Add By Zj 2012-07-16
        /// </summary>
        public string Whcddm
        {
            get { return _whcddm; }
            set { _whcddm = value; }
        }
        private string _lxrxm;
        /// <summary>
        /// 联系人姓名  //Add By Zj 2012-07-16
        /// </summary>
        public string Lxrxm
        {
            get { return _lxrxm; }
            set { _lxrxm = value; }
        }
        private string _lxrgx;
        /// <summary>
        /// 联系人关系  //Add By Zj 2012-07-16
        /// </summary>
        public string Lxrgx
        {
            get { return _lxrgx; }
            set { _lxrgx = value; }
        }
        private string _lxrdh;
        /// <summary>
        /// 联系人电话  //Add By Zj 2012-07-16
        /// </summary>

        public string Lxrdh
        {
            get { return _lxrdh; }
            set { _lxrdh = value; }
        }
        #endregion


        public YY_BRXX()
        {
            _brxxid = Guid.Empty;
            _brxm = "";
            _xb = "";
            _csrq = "";
            _hyzk = "";
            _gj = "";
            _mz = "";
            _zy = "";
            _csdz = "";
            _jtdz = "";
            _jtyb = "";
            _jtdh = "";
            _jtlxr = "";
            _brlxfs = "";
            _dzyj = "";
            _gzdw = "";
            _gzdwdz = "";
            _gzdwyb = "";
            _gzdwdh = "";
            _gzdwlxr = "";
            _sfzh = "";
            _brlx = 0;
            _yblx = 0;
            _cbkh = "";
            _djsj = "";
            _djy = 0;
            _scxgsj = "";
            _scxgczy = 0;
            _djly = 0;
            _bscbz = false;
            //Add By Zj 2012-07-16
            _qtzjlx = "";
            _qtzjhm = "";
            _jkdah = "";
            _whcddm = "";
            _lxrxm = "";
            _lxrgx = "";
            _lxrdh = "";
        }
        public YY_BRXX(Guid brxxid, RelationalDatabase _DataBase)
        {
            _brxxid = Guid.Empty;
            _brxm = "";
            _xb = "";
            _csrq = "";
            _hyzk = "";
            _gj = "";
            _mz = "";
            _zy = "";
            _csdz = "";
            _jtdz = "";
            _jtyb = "";
            _jtdh = "";
            _jtlxr = "";
            _brlxfs = "";
            _dzyj = "";
            _gzdw = "";
            _gzdwdz = "";
            _gzdwyb = "";
            _gzdwdh = "";
            _gzdwlxr = "";
            _sfzh = "";
            _brlx = 0;
            _yblx = 0;
            _cbkh = "";
            _djsj = "";
            _djy = 0;
            _scxgsj = "";
            _scxgczy = 0;
            _djly = 0;
            _bscbz = false;
            //Add By Zj 2012-07-16
            _qtzjlx = "";
            _qtzjhm = "";
            _jkdah = "";
            _whcddm = "";
            _lxrxm = "";
            _lxrgx = "";
            _lxrdh = "";
            //Modify By Zj 2012-07-16 关联病人信息补充表 获取关联信息 
            string SSQL = "SELECT * FROM YY_BRXX a (nolock) Left join YY_BRXX_BC b on a.BRXXID=b.BRXXID WHERE a.BRXXID='" + brxxid + "'";
            DataTable tb = _DataBase.GetDataTable(SSQL);
            if (tb.Rows.Count == 0)
            {
                SSQL = "SELECT * FROM YY_BRXX_H a (nolock) Left join YY_BRXX_BC b on a.BRXXID=b.BRXXID WHERE a.BRXXID='" + brxxid + "'";
                tb = _DataBase.GetDataTable(SSQL);
            }
            if (tb.Rows.Count == 0) return;

            _brxxid = new Guid(tb.Rows[0]["brxxid"].ToString());
            _brxm = tb.Rows[0]["brxm"].ToString();
            _xb = Convertor.IsNull(tb.Rows[0]["xb"], "");
            _csrq = Convertor.IsNull(tb.Rows[0]["csrq"], "");
            _hyzk = Convertor.IsNull(tb.Rows[0]["hyzk"], "");
            _gj = Convertor.IsNull(tb.Rows[0]["gj"], "");
            _mz = Convertor.IsNull(tb.Rows[0]["mz"], "");
            _zy = Convertor.IsNull(tb.Rows[0]["zy"], "");
            _csdz = Convertor.IsNull(tb.Rows[0]["csdz"], "");
            _jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
            _jtyb = Convertor.IsNull(tb.Rows[0]["jtyb"], "");
            _jtdh = Convertor.IsNull(tb.Rows[0]["jtdh"], "");
            _jtlxr = Convertor.IsNull(tb.Rows[0]["jtlxr"], "");
            _brlxfs = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
            _dzyj = Convertor.IsNull(tb.Rows[0]["dzyj"], "");
            _gzdw = Convertor.IsNull(tb.Rows[0]["gzdw"], "");
            _gzdwdz = Convertor.IsNull(tb.Rows[0]["gzdwdz"], "");
            _gzdwyb = Convertor.IsNull(tb.Rows[0]["gzdwyb"], "");
            _gzdwdh = Convertor.IsNull(tb.Rows[0]["gzdwdh"], "");
            _gzdwlxr = Convertor.IsNull(tb.Rows[0]["gzdwlxr"], "");
            _sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
            _brlx = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["brlx"], "0"));
            _yblx = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["yblx"], "0"));
            _cbkh = Convertor.IsNull(tb.Rows[0]["cbkh"], "");
            _djsj = Convertor.IsNull(tb.Rows[0]["djsj"], "");
            _djy = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["djy"], "0"));
            if (Convertor.IsNull(tb.Rows[0]["csrq"], "") == "")
                _scxgsj = Convertor.IsNull(tb.Rows[0]["scxgsj"], "");
            _scxgczy = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["scxgczy"], "0"));
            _djly = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["djly"], "0"));
            _bscbz = Convert.ToBoolean(tb.Rows[0]["bscbz"]);
            //Add By Zj 2012-07-16
            _qtzjlx = Convertor.IsNull(tb.Rows[0]["qtzjlx"], "");
            _qtzjhm = Convertor.IsNull(tb.Rows[0]["qtzjhm"], "");
            _jkdah = Convertor.IsNull(tb.Rows[0]["jkdah"], "");

            _whcddm = ts_mz_class.Fun.SeekWhcd(Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["whcddm"], "0")), _DataBase);
            _lxrxm = Convertor.IsNull(tb.Rows[0]["lxrxm"], "");
            _lxrgx = Convertor.IsNull(tb.Rows[0]["lxrgx"], "");
            _lxrdh = Convertor.IsNull(tb.Rows[0]["lxrdh"], "");

        }

        public static void BrxxDj( Guid BRXXID , string BRXM , string XB , string CSRQ , string HYZK , string GJ , string MZ , string ZY , string CSDZ , string JTDZ , string JTYB , string JTDH , string JTLXR , string BRLXFS , string DZYJ , string GZDW , string GZDWDZ , string GZDWYB , string GZDWDH , string GZDWLXR , string SFZH , int BRLX , int YBLX , string CBKH , int DJY , int DJLY , out Guid NewBrxxid , out int err_code , out string err_text , RelationalDatabase _DataBase )
        {
            BrxxDj( BRXXID , BRXM , XB , CSRQ , HYZK , GJ , MZ , ZY , CSDZ , JTDZ , JTYB , JTDH , JTLXR , BRLXFS , DZYJ ,
                 GZDW , GZDWDZ , GZDWYB , GZDWDH , GZDWLXR , SFZH , BRLX , YBLX , CBKH , DJY , DJLY ,
                 out  NewBrxxid , out  err_code , out  err_text , "", _DataBase ); 
            /*
            NewBrxxid =Guid.Empty;
            err_code=-1;
            err_text ="";
            if ( !ValidingNameString( BRXM ) )
            {
                err_text = "姓名中不能包含特殊字符";
                return;
            }
            try
            {

                ParameterEx[] parameters = new ParameterEx[30];

                parameters[0].Text = "@BRXXID";
                parameters[0].Value = BRXXID;

                parameters[1].Text = "@BRXM";
                parameters[1].Value = BRXM;

                parameters[2].Text = "@XB";
                parameters[2].Value = XB;

                parameters[3].Text = "@CSRQ";
                parameters[3].Value = CSRQ;

                parameters[4].Text = "@HYZK";
                parameters[4].Value = HYZK;

                parameters[5].Text = "@GJ";
                parameters[5].Value = GJ;

                parameters[6].Text = "@MZ";
                parameters[6].Value = MZ;

                parameters[7].Text = "@ZY";
                parameters[7].Value = ZY;

                parameters[8].Text = "@CSDZ";
                parameters[8].Value = CSDZ;

                parameters[9].Text = "@JTDZ";
                parameters[9].Value = JTDZ;

                parameters[10].Text = "@JTYB";
                parameters[10].Value = JTYB;

                parameters[11].Text = "@JTDH";
                parameters[11].Value = JTDH;

                parameters[12].Text = "@JTLXR";
                parameters[12].Value = JTLXR;

                parameters[13].Text = "@BRLXFS";
                parameters[13].Value = BRLXFS;

                parameters[14].Text = "@DZYJ";
                parameters[14].Value = DZYJ;

                parameters[15].Text = "@GZDW";
                parameters[15].Value = GZDW;

                parameters[16].Text = "@GZDWDZ";
                parameters[16].Value = GZDWDZ;

                parameters[17].Text = "@GZDWYB";
                parameters[17].Value = GZDWYB;

                parameters[18].Text = "@GZDWDH";
                parameters[18].Value = GZDWDH;

                parameters[19].Text = "@GZDWLXR";
                parameters[19].Value = GZDWLXR;

                parameters[20].Text = "@SFZH";
                parameters[20].Value = SFZH;//

                parameters[21].Text = "@BRLX";
                parameters[21].Value = BRLX;

                parameters[22].Text = "@YBLX";
                parameters[22].Value = YBLX;

                parameters[23].Text = "@CBKH";
                parameters[23].Value = CBKH;

                parameters[24].Text = "@DJY";
                parameters[24].Value = DJY;

                parameters[25].Text = "@DJLY";
                parameters[25].Value = DJLY;


                parameters[26].Text = "@Newbrxxid";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].DataType = System.Data.DbType.Guid;
                parameters[26].ParaSize = 100;

                parameters[27].Text = "@err_code";
                parameters[27].ParaDirection = ParameterDirection.Output;
                parameters[27].DataType = System.Data.DbType.Int32;
                parameters[27].ParaSize = 100;

                parameters[28].Text = "@err_text";
                parameters[28].ParaDirection = ParameterDirection.Output;
                parameters[28].ParaSize = 100;

                _DataBase.DoCommand( "SP_YY_BRXX_SAVE" , parameters , 30 );
                NewBrxxid = new Guid( Convertor.IsNull( parameters[26].Value , Guid.Empty.ToString() ) );
                err_code = Convert.ToInt32( parameters[27].Value );
                err_text = Convert.ToString( parameters[28].Value );
            }
            catch ( System.Exception err )
            {
                throw err;
            }


            */
        }
        
        public static void BrxxDj( Guid BRXXID , string BRXM , string XB , string CSRQ , string HYZK , string GJ , string MZ , string ZY , string CSDZ , string JTDZ , string JTYB , string JTDH , string JTLXR , string BRLXFS , string DZYJ , string GZDW , string GZDWDZ , string GZDWYB , string GZDWDH , string GZDWLXR , string SFZH , int BRLX , int YBLX , string CBKH , int DJY , int DJLY , out Guid NewBrxxid , out int err_code , out string err_text ,string IDCardSerNo, RelationalDatabase _DataBase )
        {

            try
            {

                if ( !ValidingNameString( BRXM ) )
                {
                    NewBrxxid = Guid.Empty;
                    err_code = -1;
                    err_text = "姓名中不能包含特殊字符";
                    return;
                }
                
                ParameterEx[] parameters = new ParameterEx[30];

                parameters[0].Text = "@BRXXID";
                parameters[0].Value = BRXXID;

                parameters[1].Text = "@BRXM";
                parameters[1].Value = BRXM;

                parameters[2].Text = "@XB";
                parameters[2].Value = XB;

                parameters[3].Text = "@CSRQ";
                parameters[3].Value = CSRQ;

                parameters[4].Text = "@HYZK";
                parameters[4].Value = HYZK;

                parameters[5].Text = "@GJ";
                parameters[5].Value = GJ;

                parameters[6].Text = "@MZ";
                parameters[6].Value = MZ;

                parameters[7].Text = "@ZY";
                parameters[7].Value = ZY;

                parameters[8].Text = "@CSDZ";
                parameters[8].Value = CSDZ;

                parameters[9].Text = "@JTDZ";
                parameters[9].Value = JTDZ;

                parameters[10].Text = "@JTYB";
                parameters[10].Value = JTYB;

                parameters[11].Text = "@JTDH";
                parameters[11].Value = JTDH;

                parameters[12].Text = "@JTLXR";
                parameters[12].Value = JTLXR;

                parameters[13].Text = "@BRLXFS";
                parameters[13].Value = BRLXFS;

                parameters[14].Text = "@DZYJ";
                parameters[14].Value = DZYJ;

                parameters[15].Text = "@GZDW";
                parameters[15].Value = GZDW;

                parameters[16].Text = "@GZDWDZ";
                parameters[16].Value = GZDWDZ;

                parameters[17].Text = "@GZDWYB";
                parameters[17].Value = GZDWYB;

                parameters[18].Text = "@GZDWDH";
                parameters[18].Value = GZDWDH;

                parameters[19].Text = "@GZDWLXR";
                parameters[19].Value = GZDWLXR;

                parameters[20].Text = "@SFZH";
                parameters[20].Value = SFZH;//

                parameters[21].Text = "@BRLX";
                parameters[21].Value = BRLX;

                parameters[22].Text = "@YBLX";
                parameters[22].Value = YBLX;

                parameters[23].Text = "@CBKH";
                parameters[23].Value = CBKH;

                parameters[24].Text = "@DJY";
                parameters[24].Value = DJY;

                parameters[25].Text = "@DJLY";
                parameters[25].Value = DJLY;


                parameters[26].Text = "@Newbrxxid";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].DataType = System.Data.DbType.Guid;
                parameters[26].ParaSize = 100;

                parameters[27].Text = "@err_code";
                parameters[27].ParaDirection = ParameterDirection.Output;
                parameters[27].DataType = System.Data.DbType.Int32;
                parameters[27].ParaSize = 100;

                parameters[28].Text = "@err_text";
                parameters[28].ParaDirection = ParameterDirection.Output;
                parameters[28].ParaSize = 100;

                parameters[29].Text = "@IDCardSerNo";
                parameters[29].Value = IDCardSerNo;

                _DataBase.DoCommand( "SP_YY_BRXX_SAVE" , parameters , 30 );
                NewBrxxid = new Guid( Convertor.IsNull( parameters[26].Value , Guid.Empty.ToString() ) );
                err_code = Convert.ToInt32( parameters[27].Value );
                err_text = Convert.ToString( parameters[28].Value );
            }
            catch ( System.Exception err )
            {
                throw new System.Exception( err.Message );
            }
        }
        /// <summary>
        /// 病人信息补充登记
        /// </summary>
        /// <param name="BRXXID"></param>
        /// <param name="QTZJLX">其他证件类型</param>
        /// <param name="QTZJHM">其他证件号码</param>
        /// <param name="JKDAH">健康档案号</param>
        /// <param name="WHCDDM">文化程度代码</param>
        /// <param name="LXRXM">联系人姓名</param>
        /// <param name="LXRGX">联系人关系</param>
        /// <param name="LXRDH">联系人电话</param>
        public static void BrxxBcDj(Guid BRXXID, string QTZJLX, string QTZJHM, string JKDAH, string WHCDDM, string LXRXM, string LXRGX, string LXRDH, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            err_code = -1;
            err_text = "";
            try
            {
                string selectsql = "select count(*) from  yy_brxx_bc where BrxxID='" + BRXXID.ToString() + "'";
                int count = Convert.ToInt32(_DataBase.GetDataResult(selectsql));
                if (count > 0)
                {
                    string updatesql = @"update YY_BRXX_BC set QTZJLX='" + QTZJLX + "',QTZJHM='" + QTZJHM + "',JKDAH='" + JKDAH + "',WHCDDM='" + WHCDDM + "',LXRXM='" + LXRXM + "',LXRGX='" + LXRGX + "',LXRDH='" + LXRDH + "' where BRXXID='" + BRXXID.ToString() + "' ";
                    _DataBase.DoCommand(updatesql);
                    err_code = 0;
                    err_text = "修改成功!";
                }
                else
                {
                    err_code = -1;
                    err_text = "";
                    string sql = "INSERT INTO YY_BRXX_BC (BRXXID,QTZJLX,QTZJHM,JKDAH,WHCDDM,LXRXM,LXRGX,LXRDH)VALUES('"
                        + BRXXID.ToString() + "','" + QTZJLX + "','" + QTZJHM + "','" + JKDAH + "','" + WHCDDM + "','" + LXRXM + "','" + LXRGX + "','" + LXRDH + "')";
                    _DataBase.DoCommand(sql);
                    err_code = 0;
                    err_text = "添加成功!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SetValues(DataRow dr,RelationalDatabase _DataBase)
        {
            _brxxid = new Guid(dr["brxxid"].ToString());
            _brxm = dr["brxm"].ToString();
            _xb = Convertor.IsNull(dr["xb"], "");
            _csrq = Convertor.IsNull(dr["csrq"], "");
            _hyzk = Convertor.IsNull(dr["hyzk"], "");
            _gj = Convertor.IsNull(dr["gj"], "");
            _mz = Convertor.IsNull(dr["mz"], "");
            _zy = Convertor.IsNull(dr["zy"], "");
            _csdz = Convertor.IsNull(dr["csdz"], "");
            _jtdz = Convertor.IsNull(dr["jtdz"], "");
            _jtyb = Convertor.IsNull(dr["jtyb"], "");
            _jtdh = Convertor.IsNull(dr["jtdh"], "");
            _jtlxr = Convertor.IsNull(dr["jtlxr"], "");
            _brlxfs = Convertor.IsNull(dr["brlxfs"], "");
            _dzyj = Convertor.IsNull(dr["dzyj"], "");
            _gzdw = Convertor.IsNull(dr["gzdw"], "");
            _gzdwdz = Convertor.IsNull(dr["gzdwdz"], "");
            _gzdwyb = Convertor.IsNull(dr["gzdwyb"], "");
            _gzdwdh = Convertor.IsNull(dr["gzdwdh"], "");
            _gzdwlxr = Convertor.IsNull(dr["gzdwlxr"], "");
            _sfzh = Convertor.IsNull(dr["sfzh"], "");
            _brlx = Convert.ToInt32(Convertor.IsNull(dr["brlx"], "0"));
            _yblx = Convert.ToInt32(Convertor.IsNull(dr["yblx"], "0"));
            _cbkh = Convertor.IsNull(dr["cbkh"], "");
            _djsj = Convertor.IsNull(dr["djsj"], "");
            _djy = Convert.ToInt32(Convertor.IsNull(dr["djy"], "0"));
            if (Convertor.IsNull(dr["csrq"], "") == "")
                _scxgsj = Convertor.IsNull(dr["scxgsj"], "");
            _scxgczy = Convert.ToInt32(Convertor.IsNull(dr["scxgczy"], "0"));
            _djly = Convert.ToInt32(Convertor.IsNull(dr["djly"], "0"));
            _bscbz = Convert.ToBoolean(dr["bscbz"]);
            //Add By Zj 2012-07-16
            _qtzjlx = Convertor.IsNull(dr["qtzjlx"], "");
            _qtzjhm = Convertor.IsNull(dr["qtzjhm"], "");
            _jkdah = Convertor.IsNull(dr["jkdah"], "");

            _whcddm = ts_mz_class.Fun.SeekWhcd(Convert.ToInt32(Convertor.IsNull(dr["whcddm"], "0")), _DataBase);
            _lxrxm = Convertor.IsNull(dr["lxrxm"], "");
            _lxrgx = Convertor.IsNull(dr["lxrgx"], "");
            _lxrdh = Convertor.IsNull(dr["lxrdh"], "");
        }

        //public static YY_BRXX GetYYbrxxInfo(string cardno, Guid brxxid, RelationalDatabase _DataBase)
        //{
        //    YY_BRXX _brxx = new YY_BRXX();
        //    string sql = @"SELECT * FROM YY_BRXX a (nolock) Left join YY_BRXX_BC b on a.BRXXID=b.BRXXID WHERE 1=1 ";
        //    if (brxxid != Guid.Empty)
        //        sql += " and a.BRXXID='" + brxxid + "'";
        //    if (!string.IsNullOrEmpty(cardno) && brxxid==Guid.Empty)
        //    {
        //        string _sql = @"select BRXXID FROM YY_KDJB WHERE KH='"+cardno+"' and zfbz=0";
        //        brxxid = new Guid(_DataBase.GetDataResult(sql).ToString());
        //        sql += " and a.BRXXID='" + brxxid + "'";
        //    }
        //    DataTable dt = _DataBase.GetDataTable(sql);
        //    if (dt.Rows.Count > 0)
        //        _brxx.SetValues(dt.Rows[0],_DataBase);
        //    else
        //    {
        //        sql = @"SELECT * FROM YY_BRXX_H a (nolock) Left join YY_BRXX_BC b on a.BRXXID=b.BRXXID WHERE a.BRXXID='" + brxxid + "'";
        //        dt = _DataBase.GetDataTable(sql);
        //        if(dt.Rows.Count>0)
        //            _brxx.SetValues(dt.Rows[0],_DataBase);
        //    }
        //    return _brxx;
        //}

        /// <summary>
        /// 验证姓名中是否有特殊字符
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValidingNameString( string name )
        {
            string strSpeciChars = "'!@#$%^&*{}[]\\/:.,";
            for ( int i = 0 ; i < name.Length ; i++ )
            {
                if ( strSpeciChars.IndexOf( name[i] ) >= 0 )
                    return false;
            }
            return true;
        }
    }
}
