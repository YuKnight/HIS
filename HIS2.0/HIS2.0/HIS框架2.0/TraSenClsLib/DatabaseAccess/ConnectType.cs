using System;
using System.Collections.Generic;
using System.Text;

namespace TrasenClasses.DatabaseAccess
{
    /// <summary>
    /// 数据库连接类型
    /// </summary>
    public enum ConnectType
    {
        /// <summary>微软SQLSERVER数据库</summary>
        SQLSERVER ,
        /// <summary>IBMDB2数据库</summary>
        IBMDB2 ,
        /// <summary>Oracle数据库</summary>
        ORACLE ,
        /// <summary>微软Access数据库</summary>
        MSACCESS ,
        /// <summary>其他类型</summary>
        OTHER = -1
    }
}
