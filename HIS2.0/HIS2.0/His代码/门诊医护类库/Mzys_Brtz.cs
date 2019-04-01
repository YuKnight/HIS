using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;

namespace ts_mzys_class
{
    /// <summary>
    /// 病人体征类 Add By zp 2013-10-12
    /// </summary>
    public class Mzys_Brtz
    {

        #region 字段定义
        private Guid _tzid;
        /// <summary>
        /// 体征ID
        /// </summary>
        public Guid Tzid
        {
            get { return _tzid; }
            set { _tzid = value; }
        }

        private Guid _ghxxid;
        /// <summary>
        /// 挂号信息ID
        /// </summary>
        public Guid Ghxxid
        {
            get { return _ghxxid; }
            set { _ghxxid = value; }
        }
        private Guid _brxxid;
        /// <summary>
        /// 病人信息ID
        /// </summary>
        public Guid Brxxid
        {
            get { return _brxxid; }
            set { _brxxid = value; }
        }
        private string _xy;
        /// <summary>
        /// 血压
        /// </summary>
        public string Xy
        {
            get { return _xy; }
            set { _xy = value; }
        }
      
        private string _xt;

        /// <summary>
        /// 血糖
        /// </summary>
        public string Xt
        {
            get { return _xt; }
            set { _xt = value; }
        }
        private string _tw;

        /// <summary>
        ///体温
        /// </summary>
        public string Tw
        {
            get { return _tw; }
            set { _tw = value; }
        }

        private string _hx;

        /// <summary>
        /// 呼吸
        /// </summary>
        public string Hx
        {
            get { return _hx; }
            set { _hx = value; }
        }

        private string _mb;

        /// <summary>
        /// 脉搏
        /// </summary>
        public string Mb
        {
            get { return _mb; }
            set { _mb = value; }
        }

        private string _tz;
        /// <summary>
        /// 体重
        /// </summary>
        public string Tz
        {
            get { return _tz; }
            set { _tz = value; }
        }
        
        private bool _isdel; //0 false未删除 1 true已删除 

        /// <summary>
        /// 是否已删除 0 false未删除 1 true已删除 
        /// </summary>
        public bool Isdel
        {
            get { return _isdel; }
            set { _isdel = value; }
        }

        private string _yxjb;

        /// <summary>
        /// 印象疾病
        /// </summary>
        public string Yxjb
        {
            get { return _yxjb; }
            set { _yxjb = value; }
        }

        private string _ztfj; //状态分级

        /// <summary>
        /// 状态分级
        /// </summary>
        public string Ztfj
        {
            get { return _ztfj; }
            set { _ztfj = value; }
        }

        private string _brzt; //病人状态

        /// <summary>
        /// 病人状态、神志
        /// </summary>
        public string Brzt
        {
            get { return _brzt; }
            set { _brzt = value; }
        }

       
        private bool _sffr; //是否发热 0false 未发热 true已发热

        /// <summary>
        /// 是否发热  0 false 未发热  1 true已发热
        /// </summary>
        public bool Sffr
        {
            get { return _sffr; }
            set { _sffr = value; }
        }

        
        private DateTime _lrrq; //录入日期

        /// <summary>
        /// 录入日期
        /// </summary>
        public DateTime Lrrq
        {
            get { return _lrrq; }
            set { _lrrq = value; }
        }

        private string _ryfs;

        public string Ryfs
        {
            get { return _ryfs; }
            set { _ryfs = value; }
        }

        private string _fbsj;

        public string Fbsj
        {
            get { return _fbsj; }
            set { _fbsj = value; }
        }
          

        #endregion

        public enum BrtzDataStatus
        {
            未作废,
            已作废,
            所有记录
        }
        /// <summary>
        /// 获取体征信息
        /// </summary>
        /// <param name="ghxxid"></param>
        /// <param name="tzid"></param>
        /// <param name="_status"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetMzbrTzInfo(Guid ghxxid, Guid tzid, BrtzDataStatus _status, RelationalDatabase db)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from MZ_BRTZ where 1=1 ";
                switch (_status)
                {
                    case BrtzDataStatus.未作废:
                        sql += " and delete_bit=0";
                        break;
                    case BrtzDataStatus .已作废:
                        sql += " and delete_bit=1";
                        break; 
                  
                }
                if (ghxxid != Guid.Empty)
                    sql += " and ghxxid='" + ghxxid + "'";
                if (tzid != Guid.Empty)
                    sql += " and tzid='" + tzid + "' ";
                dt = db.GetDataTable(sql);
            }
            catch(Exception ea)
            {
                throw ea;
            }
            return dt;
        }

        /// <summary>
        /// 更新体征 当前只更新是否发热  后期有需要在加 Add by zp 2013-10-21
        /// </summary>
        /// <param name="_brtz"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public bool UpdateTz(Mzys_Brtz _brtz,RelationalDatabase _DataBase)
        {
            try
            {
                if(_brtz.Tzid == Guid.Empty && _brtz.Ghxxid == Guid.Empty)
                    throw new Exception("体征id或挂号信息id不能同时为空!");
                string sql=@"update MZ_BRTZ set  SFFR="+Convert.ToInt32( _brtz.Sffr)+",YXJB='"+_brtz.Yxjb+@"',
                BRZT='"+_brtz.Brzt+"',RYFS='"+_brtz.Ryfs+"',ZTFJ='"+_brtz.Ztfj+"',LRRQ=GETDATE(),FBSJ='"+_brtz.Fbsj+"' where delete_bit=0 and 1=1 ";
                if (_brtz.Tzid != Guid.Empty)
                    sql += " and tzid='" + _brtz.Tzid + "'";
                if (_brtz.Ghxxid != Guid.Empty)
                    sql += " and ghxxid='" + _brtz.Ghxxid + "'";
                _DataBase.DoCommand(sql);
         
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return true;
        }
    }
}
