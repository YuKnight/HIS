using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace ts_HospData_Share
{
    public class ts_update_type
    {
        public ts_update_type(int lxid, RelationalDatabase database)
        {
            if (lxid == 0)
            {
                _czlx = 0;
                _fid = 0;
                _lxmc = "";
                _pym = "";
                _wbm = "";
                _djsj = "";
                _djy = 0;
                _bz = "";
                _bscbz = 0;
                _bzx = 0;
            }
            else
            {
                string ssql = "select * from ts_update_type where czlx='" + lxid + "'";
                DataTable tb = database.GetDataTable(ssql);
                if (tb.Rows.Count != 0)
                {
                    _czlx =Convert.ToInt32(tb.Rows[0]["czlx"]);
                    _fid = Convert.ToInt32(tb.Rows[0]["fid"]);
                    _lxmc = Convertor.IsNull(tb.Rows[0]["lxmc"], "");
                    _pym = Convertor.IsNull(tb.Rows[0]["pym"], "");
                    _wbm = Convertor.IsNull(tb.Rows[0]["wbm"], "");
                    _djsj = Convertor.IsNull(tb.Rows[0]["djsj"], "");
                    _djy = Convert.ToInt32(tb.Rows[0]["djy"]);
                    _bz = Convertor.IsNull(tb.Rows[0]["bz"], "");
                    _bscbz = Convert.ToInt16(tb.Rows[0]["bscbz"]);
                    _bzx = Convert.ToInt16(tb.Rows[0]["bzx"]);
                }

            }
        }

        private int _czlx;
        /// <summary>
        /// Ö÷¼ü×Ö¶Î
        /// </summary> 
        public int Czlx
        {
            get { return _czlx; }
            set { _czlx = value; }
        }

        private int  _fid;
        /// <summary>
        /// 
        /// </summary> 
        public int  Fid
        {
            get { return _fid; }
            set { _fid = value; }
        }

        private string _lxmc;
        /// <summary>
        /// 
        /// </summary> 
        public string Lxmc
        {
            get { return _lxmc; }
            set { _lxmc = value; }
        }

        private string _pym;
        /// <summary>
        /// 
        /// </summary> 
        public string Pym
        {
            get { return _pym; }
            set { _pym = value; }
        }

        private string _wbm;
        /// <summary>
        /// 
        /// </summary> 
        public string Wbm
        {
            get { return _wbm; }
            set { _wbm = value; }
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

        private int _bscbz;
        /// <summary>
        /// 
        /// </summary> 
        public int BscBz
        {
            get { return _bscbz; }
            set { _bscbz = value; }
        }

        private string _bz;
        /// <summary>
        /// 
        /// </summary> 
        public string Bz
        {
            get { return _bz; }
            set { _bz = value; }
        }

        private int _bzx;
        /// <summary>
        /// 
        /// </summary> 
        public int Bzx
        {
            get { return _bzx; }
            set { _bzx = value; }
        }


    }
}