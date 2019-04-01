using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Trasen.Base;
namespace ts_Clinical_Class
{
    public class function
    {

        public static DataTable GetPathwayInfo()
        {
            string sql = "  select PATHWAY_NAME 名称,PATHWAY_ID,pym,wbm from PATH_WAY where STATUS<>31";
            DataTable tb = Trasen.Base.DbOpt.GetDataTable(sql);
            return tb;
        }
        public static DataTable GetPathtable_step(int  _path_table_id)
        {
            string sql = "select *  from PATHTABLE_STEP where path_table_id=" + _path_table_id;
            DataTable tb = Trasen.Base.DbOpt.GetDataTable(sql);
            return tb;
        }
        public static DataTable GetPATHTABLE(int path_table_id)
        {
            string sql = "select * from PATHTABLE  where path_table_id=" + path_table_id;
            DataTable tb = Trasen.Base.DbOpt.GetDataTable(sql);
            return tb;
        }
        /// <summary>
        /// 获得路径阶段
        /// </summary>
        /// <param name="pathway_id"></param>
        /// <returns></returns>
        public static DataTable GetPathstep(string pathway_id)
        {
            string sql = "select * from PATH_STEP  where PATHWAY_ID='"+pathway_id+"' order by TIME_DOWN "; 
            DataTable tb = Trasen.Base.DbOpt.GetDataTable(sql);
            return tb;
        }
        public static int SavePathtable(string name, string note, int path_table_id)
        {
            if (path_table_id == 0)
            {
                string sql = string.Format("insert into PATHTABLE(PATH_TABLE_NAME,NOTE,DELETED,CREATE_DATE) values('{0}','{1}',0,getdate())", name, note);
                Trasen.Base.DbOpt.ExecuteNonQuery(sql);
                path_table_id = int.Parse(Trasen.Base.DbOpt.GetFieldValue("select @@IDENTITY path_table_id", "path_table_id"));

                return path_table_id;
            }
            else
            {
                string sql = string.Format("update PATHTABLE set PATH_TABLE_NAME='{0}',NOTE='{1}' where PATH_TABLE_ID={2}", name, note,path_table_id);
                Trasen.Base.DbOpt.ExecuteNonQuery(sql);
                return path_table_id;
            }
        }

        public static DataTable GetPathtableitem(int _path_table_id, int TABLE_STEP_ID)
        {
            string sql = " select  '0' 选择, newid() KEYID, TABLE_STEP_ITEM_NAME 项目名称, case when MNGTYPE=0 then '长期' else '临时' end 类型,TABLE_STEP_ITEM_NAME TABLE_STEP_ITEM_NAME1,*   from  PATHTABLE_STEP_ITEM where ITEMKIND=2  and TABLE_STEP_ID=" + TABLE_STEP_ID + " and PATH_TABLE_ID=" + _path_table_id
                       + "  union all  "
                       + "   select   top 1 '0' 选择, newid() KEYID , '长期'  项目名称, '0' 类型,'长期' TABLE_STEP_ITEM_NAME1,null TABLE_STEP_ID,null TABLE_STEP_ITEM_ID,null PATH_TABLE_ID,null ITEMKIND,null MNGTYPE,null TABLE_STEP_ITEM_NAME,null NOTE,null SORT     "
                       + "  union all   "
                       + "  select   top 1 '0' 选择, newid() KEYID , '临时' 项目名称, '1' 类型, '临时' TABLE_STEP_ITEM_NAME1,null TABLE_STEP_ID,null TABLE_STEP_ITEM_ID,null PATH_TABLE_ID,null ITEMKIND,null MNGTYPE,null TABLE_STEP_ITEM_NAME,null NOTE,null SORT    order by  SORT ";
            DataTable tb = Trasen.Base.DbOpt.GetDataTable(sql);
            return tb;
        }
    }
}
