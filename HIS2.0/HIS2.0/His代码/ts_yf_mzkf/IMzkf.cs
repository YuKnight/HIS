using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;

namespace ts_yf_mzkf
{
    public interface IMzkf
    {
        RelationalDatabase DataBase
        {
            get;
            set;
        }

        string Brxm
        {
            get;
            set;
        }

        string Brxxid
        {
            get;
            set;
        }       
       
 

        /// <summary>
        /// 处方开始发药
        /// </summary>
        /// <param name="tbInfo">处方信息</param>
        /// <param name="strWinid">窗口号</param>
        /// <param name="strManno">操作员编号</param>
        /// <param name="strManname">操作员</param>
        /// <param name="strIP">IP地址</param>
        int SendMedicine(DataTable tbInfo, string strWinid, string strManno, string strManname, string strIP,int deptid,string str_HH_Flag);

        /// <summary>
        /// 处方结束发药
        /// </summary>
        /// <param name="tbInfo">处方信息</param>
        /// <param name="strWinid">窗口号</param>
        /// <param name="strManno">操作员编号</param>
        /// <param name="strManname">操作员</param>
        /// <param name="strIP">IP地址</param>
        string EndToMedicine(DataTable tbInfo, string strWinid, string strManno, string strManname, string strIP, int deptid, string str_HH_Flag);


    }
}
