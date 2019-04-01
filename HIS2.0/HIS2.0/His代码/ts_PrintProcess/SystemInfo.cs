using System;
using System.Collections.Generic;
using System.Text;

namespace ts_PrintProcess
{
    /// <summary>
    /// SystemInfo 的摘要说明。
    /// </summary>
    public class SystemInfo
    {
        /// <summary>
        /// 系统信息
        /// </summary>
        public SystemInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 系统信息
        /// </summary>
        /// <param name="systemId">系统编号</param>
        /// <param name="database">database</param>
        public SystemInfo(int systemId, TrasenClasses.DatabaseAccess.RelationalDatabase database)
        {
            string sql = "select * from pub_system where system_id=" + systemId;
            System.Data.DataRow dr = database.GetDataRow(sql);
            if (dr != null)
            {
                _systemId = Convert.ToInt32(dr["system_id"]);
                _systemName = dr["name"].ToString().Trim();
                //add by wangzhi 2010-11-27
                autoLocktime = Convert.IsDBNull(dr["auto_lock_time"]) ? 0 : Convert.ToInt32(dr["auto_lock_time"]);
            }
        }

        private int _systemId;
        private string _systemName;

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SystemId
        {
            get
            {
                return _systemId;
            }
            set
            {
                _systemId = value;
            }
        }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName
        {
            get
            {
                return _systemName;
            }
            set
            {
                _systemName = value;
            }
        }
        //add by wangzhi 2010-11-27
        private int autoLocktime;
        /// <summary>
        /// 系统自动锁屏时间，单位（分钟）
        /// </summary>
        public int AutoLockTime
        {
            get
            {
                return autoLocktime;
            }
        }
        //end add

        public static System.Data.DataTable GetList(string filter, TrasenClasses.DatabaseAccess.RelationalDatabase database)
        {
            string sql = "select * from pub_system where 1=1";
            if (!string.IsNullOrEmpty(filter))
                sql += filter;
            return database.GetDataTable(sql);
        }
    }
}
