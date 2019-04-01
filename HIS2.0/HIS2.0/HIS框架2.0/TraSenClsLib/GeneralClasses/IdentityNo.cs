using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.GeneralClasses
{
    public class IdentityNo
    {
        private IdentityNo()
        {
        }

        /// <summary>
        /// 得到当前号码
        /// </summary>
        /// <param name="type"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static int GetNowNo(Identity type, RelationalDatabase database)
        {
            return Convert.ToInt32(Convertor.IsNull(database.GetDataResult("select no from JC_IDENTITY where rowtype=" + (int)type), "0"));
        }

        /// <summary>
        /// 得到当前号码+1并更新当前号码+1
        /// </summary>
        /// <param name="type"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static int UpdateNowNoAndGetNewNo(Identity type, RelationalDatabase database)
        {
            //Modify By Tany 2012-02-13 不能使用组合字符串
            string sql = "";
            int _no = 0;
            sql = "select no + 1 from JC_IDENTITY where rowtype=" + (int)type;
            _no = Convert.ToInt32(Convertor.IsNull(database.GetDataResult(sql), "0"));
            sql = "update JC_IDENTITY set no = no + 1 where rowtype=" + (int)type;
            database.DoCommand(sql);
            //return Convert.ToInt32(Convertor.IsNull(database.GetDataResult("select no + 1 from JC_IDENTITY where rowtype=" + (int)type + ";update JC_IDENTITY set no = no + 1 where rowtype=" + (int)type), "0"));
            return _no;
        }

        /// <summary>
        /// 更新当前号码+1
        /// </summary>
        /// <param name="type"></param>
        /// <param name="database"></param>
        public static void UpdateNowNo(Identity type, RelationalDatabase database)
        {
            database.DoCommand("update JC_IDENTITY set no = no + 1 where rowtype=" + (int)type);
        }
        /// <summary>
        /// 更新当前号码到一个固定数+1
        /// </summary>
        /// <param name="type"></param>
        /// <param name="database"></param>
        public static void UpdateNowNo(Identity type, long no, RelationalDatabase database)
        {
            database.DoCommand("update JC_IDENTITY set no = " + no + " + 1 where rowtype=" + (int)type + " and " + no + " >=no");
        }
    }
}
