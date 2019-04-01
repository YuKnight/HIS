using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Runtime.InteropServices;

namespace ts_PrintProcess
{
    /// <summary>
    ///  数据库表字段信息
    /// </summary>
    public struct TableField
    {
        /// <summary>
        /// 数据库字段名称
        /// </summary>
        public string DatabaseName;
        /// <summary>
        /// 显示列标题
        /// </summary>
        public string ChineseName;
        /// <summary>
        /// 显示宽度
        /// </summary>
        public int ViewWidth;
        /// <summary>
        /// 弹出ShowCard选项卡SQL语句(必须有item_id,item_name,py_code,wb_code,d_code列)
        /// </summary>
        public string ShowCardSql;
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue;
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string RegularExpressions;
        /// <summary>
        /// 是否为唯一索引字段
        /// </summary>
        public bool IsUniqueKey;
        /// <summary>
        /// 是否为删除标记字段
        /// </summary>
        public bool IsDeleteField;
        /// <summary>
        /// 是否自动增长字段
        /// </summary>
        public bool IsAutoIncrease;
        /// <summary>
        /// 拼音码字段
        /// </summary>
        public bool IsPYField;
        /// <summary>
        /// 五笔码字段
        /// </summary>
        public bool IsWBField;
        /// <summary>
        /// 需要生成五笔拼音的字段
        /// </summary>
        public bool IsNameField;
        /// <summary>
        /// 是否不允许重复
        /// </summary>	
        public bool UnAllowRepeat;
        /// <summary>
        /// 字段特殊类型
        /// </summary>
        public FieldSpeciType SpeciType;
        /// <summary>
        /// 字段类型
        /// </summary>
        public Type FieldType;
    }
    /// <summary>
    /// 自定义菜单的附加值结构
    /// </summary>
    public struct MenuTag
    {
        /// <summary>
        /// 对应的dll名称
        /// </summary>
        public string DllName;
        /// <summary>
        /// 引出函数名称
        /// </summary>
        public string Function_Name;
        /// <summary>
        /// 引出函数附加值
        /// </summary>
        public string FunctionTag;
        /// <summary>
        /// 所属模块编号
        /// </summary>
        public int ModuleId;
        /// <summary>
        /// 菜单中文名
        /// </summary>
        public string MenuName;
        /// <summary>
        /// 系统菜单编号
        /// </summary>
        public SystemInfo System;
        /// <summary>
        /// 菜单数据库指向机构编码
        /// </summary>
        public int Jgbm;
        /// <summary>
        /// 可以使用 公用密码 jianqg 2012-10-6 emr-his框架整合  增加
        /// </summary>
        public bool CanUsePublicPwd;
        /// <summary>
        /// 菜单授权码
        /// </summary>
        public string AuthCode;

        public static MenuTag GetTag(string dllName, string functionName, string functionTag, string name, RelationalDatabase database)
        {
            string sql = string.Format("select * from pub_menu where Name='{0}' and Dll_Name = '{1}' and Function_Name='{2}'", name, dllName, functionName);
            if (!string.IsNullOrEmpty(functionTag))
                sql += string.Format(" and Function_Tag = '{0}'", functionTag);
            else
                sql += " and ( Function_Tag = '' or Function_Tag is null) ";
            System.Data.DataRow row = database.GetDataRow(sql);

            MenuTag tag = new MenuTag();
            if (row != null)
            {
                tag.Function_Name = row["Function_Name"].ToString().Trim();
                tag.FunctionTag = row["function_tag"].ToString().Trim();
                tag.DllName = row["Dll_name"].ToString().Trim();
                tag.MenuName = row["name"].ToString().Trim();
                tag.System = new SystemInfo(Convert.ToInt32(row["menu_id"]), database);
                tag.Jgbm = Convert.ToInt32(row["jgbm"]) == -1 ? FrmMdiMain.Jgbm : Convert.ToInt32(row["jgbm"]);//Add By Tany 2010-01-14 Modify By Tany 如果没有设置机构编码，则默认机构编码设置为登录机构编码
                //jianqg emr-his 整合暂时注释
                tag.CanUsePublicPwd = Convert.ToInt32(row["CanUsePublicPwd"]) == 1 ? true : false;//是否可以用公用密码 jianqg 2012-10-6 emr-his框架整合  增加

                if (row.Table.Columns.Contains("AuthCode"))
                    tag.AuthCode = Convert.IsDBNull(row["AuthCode"]) ? "" : row["AuthCode"].ToString();
                else
                    tag.AuthCode = "";
            }
            return tag;
        }
    }

    /// <summary>
    /// TextBoxTag
    /// </summary>
    public struct TEXTBOXTAG
    {
        /// <summary>
        /// 字段属性
        /// </summary>
        public TableField FieldProperty;
        /// <summary>
        /// 字段当前值
        /// </summary>
        public object Value;
    }


    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public int cbData;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }
}
