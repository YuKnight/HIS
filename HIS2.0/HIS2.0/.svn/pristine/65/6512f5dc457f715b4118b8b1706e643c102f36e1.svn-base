using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
namespace ts_yj_class
{
    public class Fun
    {
        //添加病区
        public static void AddcmbWardDept(System.Windows.Forms.ComboBox cmb, int all, string wardid,int jgbm, RelationalDatabase _DataBase)
        {
            //string swhere = "";
            //if (all == 1)
            //    swhere = "select name,ward_id,ward_id from (select  '全部' name,'0' dept_id,'' ward_id ) a union all";
            //string ssql = swhere + " select ward_name name,dept_id,ward_id from JC_WARD  ";
            //ssql = ssql + " where  jgbm=" + jgbm + " ";
            //if (wardid.Trim() != "") ssql = ssql + " and  ward_id='" + wardid.Trim() + "'";

            //ssql = ssql + " order by ward_id";
            //DataTable tb = _DataBase.GetDataTable(ssql);
            //cmb.ValueMember = "ward_id";
            //cmb.DisplayMember = "name";
            //cmb.DataSource = tb;

            string swhere = "";
            if (all == 1)
                swhere = "select name,ward_id from (select  '全部' name,'0'  ward_id ) a union all";
            string ssql = swhere + " select ward_name name,dept_id as ward_id from JC_WARD  ";
            ssql = ssql + " where  jgbm=" + jgbm + " ";
            if (wardid.Trim() != "") ssql = ssql + " and  ward_id='" + wardid.Trim() + "'";

            ssql = ssql + " order by ward_id";
            DataTable tb = _DataBase.GetDataTable(ssql);
            cmb.ValueMember = "ward_id";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;

        }
        //添加住院科室
        public static void AddcmbZyks(System.Windows.Forms.ComboBox cmb, int all, int dept_id, int jgbm, RelationalDatabase _DataBase)
        {
            string swhere = "";
            if (all == 1)
                swhere = "select name, dept_id from (select  '全部' name,'0' dept_id) a union all";

            string ssql = swhere + " select name,a.dept_id from jc_wardrdept a inner join JC_DEPT_property b "+
               "  on a.dept_id=b.dept_id "+
               "  where a.dept_id not in(select dept_id from jc_ward) and b.jgbm="+jgbm+" "+
               " ";
            DataTable tb =_DataBase.GetDataTable(ssql);
            cmb.ValueMember = "dept_id";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;

        }
        //添加医技科室
        public static void AddcmbYjks(System.Windows.Forms.ComboBox cmb, int all, int dept_id, long jgbm, RelationalDatabase _DataBase)
        {
            string swhere = "";
            if (all == 1)
                swhere = "select name, dept_id from (select  '全部' name,'0' dept_id) a union all";

            string ssql = swhere + " select name,a.dept_id from JC_DEPT_TYPE_RELATION a inner join JC_DEPT_property b " +
               "  on a.dept_id=b.dept_id " +
               "  where a.type_code='005'  " +  //and jgbm="+jgbm+" " +
               " ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            cmb.ValueMember = "dept_id";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;

        }

        public static string returnZyh(string zyh)
        {
            int i = Convert.ToInt32(new SystemCfg(5026).Config); 
            string tmp1 = "0000000000000000000000";
            if (zyh.Length == 0)
                return zyh;
            else
                return tmp1.Substring(0, i - zyh.Length) + zyh;
        }

        public static void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }
    }
}
