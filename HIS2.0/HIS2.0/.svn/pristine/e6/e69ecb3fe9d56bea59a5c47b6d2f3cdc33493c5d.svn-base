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
    public class mz_card
    {
        private int _klx;
        private string _klxmc;
        private bool _bjebz;
        private bool _bqfgz;
        private bool _bqybz;
        private bool _bmm;
        private string _mrmm;
        private int _kcd;
        private int _xh;
        private long _sfmxid;
        private int _ybjklx;
        private string _dkqxh;
        private bool _binput;

        #region//属性定义
        public int klx
        {
            get
            {
                return _klx;
            }
            set
            {
                _klx = value;
            }
        }

        public string klxmc
        {
            get
            {
                return _klxmc;
            }
            set
            {
                _klxmc = value;
            }

        }

        public bool bjebz
        {
            get
            {
                return _bjebz;
            }
            set
            {
                _bjebz = value;
            }
        }

        public bool bqfgz
        {
            get
            {
                return _bqfgz;
            }
            set
            {
                _bqfgz = value;
            }
        }

        public bool bqybz
        {
            get
            {
                return _bqybz;
            }
            set
            {
                _bqybz = value;
            }
        }
        public bool bmm
        {
            get
            {
                return _bmm;
            }
            set
            {
                _bmm = value;
            }
        }
        public string mrmm
        {
            get
            {
                return _mrmm;
            }
            set
            {
                _mrmm  = value;
            }
        }
        public int kcd
        {
            get
            {
                return _kcd;
            }
            set
            {
                _kcd = value;
            }
        }

        public int xh
        {
            get
            {
                return xh;
            }
            set
            {
                xh = value;
            }
        }
        public  long sfxmid
        {
            get
            {
                return _sfmxid;
            }
            set
            {
                _sfmxid = value;
            }
        }
        public int ybjklx
        {
            get
            {
                return _ybjklx;
            }
            set
            {
                _ybjklx = value;
            }
        }
        public string  dkyxh
        {
            get
            {
                return _dkqxh;
            }
            set
            {
                _dkqxh = value;
            }
        }
        public bool binput
        {
            get
            {
                return _binput;
            }
            set
            {
                _binput = value;
            }
        }

        #endregion

        public mz_card(long klx, RelationalDatabase _DataBase)
        {
            _klx = 0;
            _klxmc = "";
            _bjebz = false;
            _bqfgz = false;
            _bqybz = false;
            _bmm = false;
            _mrmm = "";
            _kcd = 0;
            _xh = 0;
            _sfmxid = 0;
            _ybjklx = 0;
            _dkqxh = "";
            _binput = false;

            string ssql = "select * from JC_KLX where klx=" + klx + "";
            DataRow row = _DataBase.GetDataRow(ssql);
            if (row != null)
            {
                _klx = Convert.ToInt32(row["klx"]);
                _klxmc = Convert.ToString(row["klxmc"]);
                _bjebz = Convert.ToBoolean(row["bjebz"]);
                _bqfgz = Convert.ToBoolean(row["bqfgz"]);
                _bqybz = Convert.ToBoolean(row["bqybz"]);
                _bmm = Convert.ToBoolean(row["bmm"]);
                _mrmm = Convert.ToString(Convertor.IsNull(row["mrmm"],""));
                _kcd = Convert.ToInt32(row["kcd"]);
                _xh = Convert.ToInt32(row["xh"]);
                _sfmxid = Convert.ToInt64(row["sfxmid"]);
                _ybjklx = Convert.ToInt32(row["ybjklx"]);
                _dkqxh = Convert.ToString(Convertor.IsNull(row["dkqxh"],""));
                _binput = Convert.ToBoolean(row["binput"]);
            }


        }
        public mz_card(Yblx yblx, RelationalDatabase _DataBase)
        {
            _klx = 0;
            _klxmc = "";
            _bjebz = false;
            _bqfgz = false;
            _bqybz = false;
            _bmm = false;
            _mrmm = "";
            _kcd = 0;
            _xh = 0;
            _sfmxid = 0;
            _ybjklx = 0;
            _dkqxh = "";
            _binput = false;
            string ssql = "select * from JC_KLX where ybjklx=" + yblx.ybjklx + "";
            DataRow row = _DataBase.GetDataRow(ssql);
            if (row != null)
            {
                _klx = Convert.ToInt32(row["klx"]);
                _klxmc = Convert.ToString(row["klxmc"]);
                _bjebz = Convert.ToBoolean(row["bjebz"]);
                _bqfgz = Convert.ToBoolean(row["bqfgz"]);
                _bqybz = Convert.ToBoolean(row["bqybz"]);
                _bmm = Convert.ToBoolean(row["bmm"]);
                _mrmm = Convert.ToString(Convertor.IsNull(row["mrmm"], ""));
                _kcd = Convert.ToInt32(row["kcd"]);
                _xh = Convert.ToInt32(row["xh"]);
                _sfmxid = Convert.ToInt64(row["sfxmid"]);
                _ybjklx = Convert.ToInt32(row["ybjklx"]);
                _dkqxh = Convert.ToString(Convertor.IsNull(row["dkqxh"], ""));
                _binput = Convert.ToBoolean(row["binput"]);
            }


        }

    }

    public class Yblx
    {
        private int _yblx;
        private string _name;
        private string _driver;
        private string _insureCentral;
        private string _hospid;
        private string _defaults;
        private bool _isry;
        private bool _iscy;
        private bool _isgh;
        private bool _issf;
        private int _ybjklx;
        private int _isuseiccard;
        private string _xmbm;
        private string _ypbm;
        #region//属性定义
        public int yblx
        {
            get
            {
                return _yblx;
            }
            set
            {
                _yblx = value;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }

        }

        public string driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }

        public string insureCentral
        {
            get
            {
                return _insureCentral;
            }
            set
            {
                _insureCentral = value;
            }
        }
        public string hospid
        {
            get
            {
                return _hospid;
            }
            set
            {
                _hospid = value;
            }
        }

        public string defaults
        {
            get
            {
                return _defaults;
            }
            set
            {
                _defaults = value;
            }
        }

        public bool isry
        {
            get
            {
                return _isry;
            }
            set
            {
                _isry = value;
            }
        }
        public bool iscy
        {
            get
            {
                return _iscy;
            }
            set
            {
                _iscy = value;
            }
        }
        public bool isgh
        {
            get
            {
                return _isgh;
            }
            set
            {
                _isgh = value;
            }
        }
        public bool issf
        {
            get
            {
                return _issf;
            }
            set
            {
                _issf = value;
            }
        }
        /// <summary>
        /// 1长信 2桑达 3洞氮 4创智 5 泰阳农合 6清华同方居民 7创智铁路老接口 isuseiccard
        /// </summary>
        public int ybjklx
        {
            get
            {
                return _ybjklx;
            }
            set
            {
                _ybjklx = value;
            }
        }

        public int isuseiccard
        {
            get
            {
                return _isuseiccard;
            }
            set
            {
                _isuseiccard = value;
            }
        }

        public string xmbm
        {
            get
            {
                return _xmbm;
            }
            set
            {
                _xmbm = value;
            }
        }
        public string ypbm
        {
            get
            {
                return _ypbm;
            }
            set
            {
                _ypbm = value;
            }
        }

        #endregion

        public Yblx(long yblx, RelationalDatabase _DataBase)
        {
            _yblx = 0;
            _name = "";
            _driver = "";
            _insureCentral = "";
            _hospid = "";
            _defaults = "";
            _isry = false;
            _iscy = false;
            _isgh = false;
            _issf = false;
            _ybjklx = 0;
            _isuseiccard = 0;
            _xmbm = "";
            _ypbm = "";

            string ssql = "select a.*,xmbm,ypbm from jc_yblx a left join jc_ybjklx b on a.ybjklx=b.ybjklx where id=" + yblx + "";
            DataRow row = _DataBase.GetDataRow(ssql);
            if (row != null)
            {
                _yblx = Convert.ToInt32(row["id"]);
                _name = Convert.ToString(row["name"]);
                _driver = Convert.ToString(row["driver"]);
                _insureCentral = Convert.ToString(row["insureCentral"]);
                _hospid = Convert.ToString(row["hosp_id"]);
                _defaults = Convert.ToString(row["defaults"]);
                _isry = Convert.ToBoolean(row["isry"]);
                _iscy = Convert.ToBoolean(row["iscy"]);
                _isgh = Convert.ToBoolean(row["isghsf"]);
                _issf = Convert.ToBoolean(row["issf"]);
                _ybjklx = Convert.ToInt32(row["ybjklx"]);
                _isuseiccard = Convert.ToInt32(row["isuseiccard"]);
                _xmbm = Convert.ToString(row["xmbm"]);
                _ypbm = Convert.ToString(row["ypbm"]);
            }


        }
        public Yblx(long yblx)
        {
            _yblx = 0;
            _name = "";
            _driver = "";
            _insureCentral = "";
            _hospid = "";
            _defaults = "";
            _isry = false;
            _iscy = false;
            _isgh = false;
            _issf = false;
            _ybjklx = 0;
            _isuseiccard = 0;
            _xmbm = "";
            _ypbm = "";

            string ssql = "select a.*,xmbm,ypbm from jc_yblx a left join jc_ybjklx b on a.ybjklx=b.ybjklx where id=" + yblx + "";
            DataRow row = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(ssql);
            if (row != null)
            {
                _yblx = Convert.ToInt32(row["id"]);
                _name = Convert.ToString(row["name"]);
                _driver = Convert.ToString(row["driver"]);
                _insureCentral = Convert.ToString(row["insureCentral"]);
                _hospid = Convert.ToString(row["hosp_id"]);
                _defaults = Convert.ToString(row["defaults"]);
                _isry = Convert.ToBoolean(row["isry"]);
                _iscy = Convert.ToBoolean(row["iscy"]);
                _isgh = Convert.ToBoolean(row["isghsf"]);
                _issf = Convert.ToBoolean(row["issf"]);
                _ybjklx = Convert.ToInt32(row["ybjklx"]);
                _isuseiccard = Convert.ToInt32(row["isuseiccard"]);
                _xmbm = Convert.ToString(row["xmbm"]);
                _ypbm = Convert.ToString(row["ypbm"]);
            }


        }

    }

    public class ReadCard
    {
        private int _klx;
        private string _kh;
        private decimal _kye;
        private int _sdbz;
        private Guid  _kdjid;
        private bool _zfbz;
        private string _kmm;
        private Guid _brxxid;
        private string _grzhbh;
        private string _kxym;
        private string _kxlh;
        

        public int klx
        {
            get
            {
                return _klx;
            }
            set
            {
                _klx = value;
            }
        }
        public string kh
        {
            get
            {
                return _kh;
            }
            set
            {
                _kh = value;
            }
        }
        public decimal kye
        {
            get
            {
                return _kye;
            }
            set
            {
                _kye = value;
            }
        }
        public int sdbz
        {
            get
            {
                return _sdbz;
            }
            set
            {
                _sdbz = value;
            }
        }
        public Guid  kdjid
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
        public bool zfbz
        {
            get
            {
                return _zfbz;
            }
            set
            {
                _zfbz = value;
            }
        }
        public string kmm
        {
            get
            {
                return _kmm;
            }
            set
            {
                _kmm = value;
            }
        }
        public Guid brxxid
        {
            get
            {
                return _brxxid ;
            }
            set
            {
                _brxxid  = value;
            }
        }
        public string grzhbh
        {
            get
            {
                return _grzhbh;
            }
            set
            {
                _grzhbh = value;
            }
        }
        public string kxym
        {
            get
            {
                return _kxym;
            }
            set
            {
                _kxym = value;
            }
        }
        public string kxlh
        {
            get
            {
                return _kxlh;
            }
            set
            {
                _kxlh = value;
            }
        }


        public ReadCard(int klx, string kh, RelationalDatabase _DataBase)
        {
            _klx = 0;
            _kh = "";
            _kye = 0;
            _sdbz = 0;
            _kdjid = Guid.Empty;
            _zfbz = false;
            _kmm = "";
            _brxxid = Guid.Empty;
            _grzhbh = "";
            _kxym = "";
            _kxlh = "";
            string ssql = "select * from YY_KDJB where klx=" + klx + " and kh='" + kh.Trim() + "' and zfbz=0";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count == 1 && kh!="")
            {
                _klx = Convert.ToInt32(tb.Rows[0]["klx"]);
                _kh = Convert.ToString(tb.Rows[0]["kh"]);
                _kye = Convert.ToDecimal(tb.Rows[0]["kye"]);
                _sdbz = Convert.ToInt16(tb.Rows[0]["sdbz"]);
                _kdjid = new Guid(tb.Rows[0]["kdjid"].ToString());
                _zfbz = Convert.ToBoolean(tb.Rows[0]["zfbz"]);
                _kmm = Convert.ToString(tb.Rows[0]["KMM"]);
                _brxxid  = new Guid(tb.Rows[0]["brxxid"].ToString());
                _grzhbh = Convert.ToString(tb.Rows[0]["grzhbh"]);
                _kxym = Convert.ToString(tb.Rows[0]["kxym"]);
                _kxlh = Convert.ToString(tb.Rows[0]["kxlh"]);
            }
        }
        public ReadCard(Guid kdjid, RelationalDatabase _DataBase)
        {
            _klx = 0;
            _kh = "";
            _kye = 0;
            _sdbz = 0;
            _kdjid = Guid.Empty;
            _zfbz = true;
            _kmm = "";
            _brxxid = Guid.Empty;
            _grzhbh = "";
            _kxym = "";
            _kxlh = "";
            string ssql = "select * from YY_KDJB(nolock) where kdjid='" + kdjid + "'";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count == 1)
            {
                _klx = Convert.ToInt32(tb.Rows[0]["klx"]);
                _kh = Convert.ToString(tb.Rows[0]["kh"]);
                _kye = Convert.ToDecimal(tb.Rows[0]["kye"]);
                _sdbz = Convert.ToInt16(tb.Rows[0]["sdbz"]);
                _kdjid = new Guid(tb.Rows[0]["kdjid"].ToString());
                _zfbz = Convert.ToBoolean(tb.Rows[0]["zfbz"]);
                _kmm = Convert.ToString(tb.Rows[0]["KMM"]);
                _brxxid = new Guid(tb.Rows[0]["brxxid"].ToString());
                _grzhbh = Convert.ToString(tb.Rows[0]["grzhbh"]);
                _kxym = Convert.ToString(tb.Rows[0]["kxym"]);
                _kxlh = Convert.ToString(tb.Rows[0]["kxlh"]);
            }
        }

        public void UpdateKye(decimal xfje, RelationalDatabase _DataBase)
        {
            string ssql = "update YY_KDJB set kye=kye-(" + xfje + "),ljxfje=ljxfje+(" + xfje + ") where kdjid='" + _kdjid + "' and (kye-(" + xfje + "))>=0 and kye=" + _kye + "";
            int i = _DataBase.DoCommand(ssql);
            if (i == 0) throw new Exception("在更新卡余额时出现错误,可能卡余额不足或数据已更改");
        }
    }

    public class pc
    {
        private int _pcid;
        private string _name;
        private int _zxcs;
        private int _jgts;
        private string _pym;

        #region//属性定义
        public int pcid
        {
            get
            {
                return _pcid;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
        }

        public int zxcs
        {
            get
            {
                return _zxcs;
            }
        }

        public int jgts
        {
            get
            {
                return _jgts;
            }
        }

        public string pym
        {
            get
            {
                return _pym ;
            }
        }


        #endregion

        public pc(long pcid, RelationalDatabase _DataBase)
        {
            _pcid = 0;
            _name = "";
            _zxcs = 1;
            _jgts = 1;
            _pym = "";

            string ssql = "select * from JC_FREQUENCY where id=" + pcid + "";
            DataRow row = _DataBase.GetDataRow(ssql);
            if (row != null)
            {
                _pcid = Convert.ToInt32(row["id"]);
                _name = Convert.ToString(row["name"]);
                _zxcs = Convert.ToInt32(row["execnum"]);
                _jgts = Convert.ToInt32(row["cycleday"]);
                _pym = Convert.ToString(row["py_code"]);
            }


        }

    }
}
