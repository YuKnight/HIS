using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;

namespace ts_PrintProcess
{
    /// <summary>
    /// 标准模型接口
    /// </summary>
    public interface IStdObject
    {
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        bool Save();
        /// <summary>
        /// 恢复
        /// </summary>
        /// <returns></returns>
        bool Retrieve();
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <returns></returns>
        bool Delete();
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        RelationalDatabase Database { get;set;}

    }/* END INTERFACE DEFINITION IStdObject */
}
