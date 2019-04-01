using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_PrintProcess
{
    /// <summary>
    /// IDllInformation 的摘要说明。
    /// </summary>
    public interface IDllInformation
    {
        /// <summary>
        /// 实例化窗体函数名称	
        /// </summary>
        string FunctionName { get;set;}
        /// <summary>
        /// 窗体中文名称
        /// </summary>
        string ChineseName { get;set;}
        /// <summary>
        /// 当前操作员ID
        /// </summary>
        User CurrentUser { get;set;}
        /// <summary>
        /// 当前操作科室ID
        /// </summary>
        Department CurrentDept { get;set;}
        /// <summary>
        /// 菜单ID
        /// </summary>
        long MenuId { get;set;}
        /// <summary>
        /// Mdi父窗体
        /// </summary>
        Form MdiParent { get;set;}
        /// <summary>
        /// 数据库访问类
        /// </summary>
        RelationalDatabase Database { get;set;}
        /// <summary>
        /// 实例化工作窗体
        /// </summary>
        void InstanceWorkForm();
        /// <summary>
        /// 获得所有引出函数信息
        /// </summary>
        /// <returns></returns>
        ObjectInfo[] GetFunctionsInfo();
        /// <summary>
        /// 获得Dll信息
        /// </summary>
        /// <returns></returns>
        ObjectInfo GetDllInfo();
        /// <summary>
        /// 菜单附加值
        /// </summary>
        MenuTag FunctionTag { get;set;}
    }
}
