using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using TrasenClasses.DatabaseAccess;

namespace ts_yk_zwtz
{
    public class yk_cwtz_temp
    {
        private Guid _id;
        private Guid _djid;
        private Guid _djmxid;
        private Guid _kcid;
        private int _djh;
        private int _wldw;
        private int _deptid;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Guid Djid
        {
            get { return _djid; }
            set { _djid = value; }
        }
        public Guid Djmxid
        {
            get { return _djmxid; }
            set { _djmxid = value; }
        }
        public Guid Kcid
        {
            get { return _kcid; }
            set { _kcid = value; }
        }
        public int djh
        {
            get { return _djh; }
            set { _djh = value; }
        }
        public int wldw
        {
            get { return _wldw; }
            set { _wldw = value; }
        }
        public int deptid
        {
            get { return _deptid; }
            set { _deptid = value; }
        }
        private DateTime _RQ;
        public DateTime RQ
        {
            get { return _RQ; }
            set { _RQ = value; }
        }
        private decimal _tzjg;
        public decimal tzjg
        {
            get { return _tzjg; }
            set { _tzjg = value; }
        }
        private decimal _tzsl;
        public decimal tzsl
        {
            get { return _tzsl; }
            set { _tzsl = value; }
        }
        private decimal _tzje;
        public decimal tzje
        {
            get { return _tzje; }
            set { _tzje = value; }
        }
        private string _yppch;
        public string yppch
        {
            get { return _yppch; }
            set { _yppch = value; }
        }
        private int _cjid;
        public int cjid
        {
            get { return _cjid; }
            set { _cjid = value; }
        }
        private string _SHH;
        public string SHH
        {
            get { return _SHH; }
            set { _SHH = value; }
        }
        private string _SHDH;
        public string SHDH
        {
            get { return _SHDH; }
            set { _SHDH = value; }
        }
        private string _YPDW;
        public string YPDW
        {
            get { return _YPDW; }
            set { _YPDW = value; }
        }
        private string _FPH;
        public string FPH
        {
            get { return _FPH; }
            set { _FPH = value; }
        }
        private string _FPRQ;
        public string FPRQ
        {
            get { return _FPRQ; }
            set{_FPRQ=value;}
        }
        private int _djy;
        public int djy
        {
            get { return _djy; }
            set { _djy = value; }
        }
        private DateTime _djrq;
        public DateTime djrq
        {
            get { return _djrq; }
            set { _djrq = value; }
        }
        private int _shr;
        public int shr
        {
            get { return _shr; }
            set { _shr = value; }
        }
        private DateTime _shrq;
        public DateTime shrq
        {
            get { return _shrq; }
            set { _shrq = value; }
        }
        private int _cjr;
        public int cjr
        {
            get { return _cjr; }
            set { _cjr = value; }
        }
        private DateTime _cjrq;
        public DateTime cjrq
        {
            get { return _cjrq; }
            set { _cjrq = value; }
        }
        private string _ywlx;
        public string ywlx
        {
            get { return _ywlx; }
            set { _ywlx = value; }
        }

        private string _ypph;
        public string ypph
        {
            get { return _ypph; }
            set { _ypph = value; }
        }
        private long _jgbm;
        public long jgbm
        {
            get { return _jgbm; }
            set { _jgbm = value; }
        }
        private long _xdjh;
        public long xdjh
        {
            get { return _xdjh; }
            set { _xdjh = value; }
        }
        private Guid _xdjid;
        public Guid xdjid
        {
            get { return _xdjid; }
            set { _xdjid = value; }
        }
        private string _xfph;
        public string xfph
        {
            get { return _xfph; }
            set { _xfph = value; }
        }
        private RelationalDatabase _db;
        public yk_cwtz_temp(RelationalDatabase database)
        {
            _db = database;
        }
        public yk_cwtz_temp()
        {
 
        }
        public void Add(yk_cwtz_temp cwtzet)
        {
            Type t = typeof(yk_cwtz_temp);
            PropertyInfo[] pros = t.GetProperties();
            string strName=null;
            string strValue=null;
            foreach (PropertyInfo pro in pros)
            {
                strName += pro.Name.ToString() + ",";
                if (pro.Name.Trim() == "Id")
                {
                    strValue += "newid(),";
                }
                else
                {
                    strValue += "'" + pro.GetValue(cwtzet, null).ToString() + "',";
                }
                //strValue.Append(strValue.ToString() + "'" + pro.GetValue(cwtzet, null) + "',");
            }
            //ºÏ²¢
           // string str1 = strName.ToString().Substring(0, strName.ToString().LastIndexOf(','));
           //string str2 = strValue.ToString().Substring(0, strValue.ToString().LastIndexOf(','));
           _db.DoCommand("insert into yk_cwtz_temp("+strName.ToString().Substring(0, strName.ToString().LastIndexOf(','))+") values ("+strValue.ToString().Substring(0, strValue.ToString().LastIndexOf(','))+")");

        }

    }
}
