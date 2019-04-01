using System;
using System.Collections.Generic;
using System.Text;

namespace SystemUpdate
{
    /// <summary>
    /// 数据库连接类型
    /// </summary>
    public enum ConnectionType
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

    public enum Action
    {
        /// <summary>
        /// 检查升级文件
        /// </summary>
        LoadingUpdateFile,
        /// <summary>
        /// 比较版本
        /// </summary>
        CompareVersion,
        /// <summary>
        /// 升级中
        /// </summary>
        Updating,
        /// <summary>
        /// 下载文件内容
        /// </summary>
        DownLoadContent,
        /// <summary>
        /// 下载完成
        /// </summary>
        DownLoadComplete,

        UpdateComplete,

        UpdateFailed
    }

    public delegate void UpdateProcessingHandle(Action action ,string message);

    public delegate void FileUpdateHandle(string fileName,long fileLength,long current);

    public delegate void LoadingUpdateFileListHandle( Action action , bool complated ,int fileCount);

}
