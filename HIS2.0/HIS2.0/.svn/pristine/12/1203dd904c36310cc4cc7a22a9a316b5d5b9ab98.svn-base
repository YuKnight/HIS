using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace ts_mz_txyy
{
    class OutPatientBackNumDAL
    {
        public static void OutPatientBackNum(string YQID, string deptid, string starttime, string endtime, DataGridView dv)
        {
            DataTable dt = new DataTable();
            string sql = string.Format(@"select (case when t.医生名称 is null then '普通门诊' else t.医生名称 end) as 名称,COUNT(退号数) as 退号数
                                        from 
                                        (select c.NAME as 医生名称,a.GHXXID as 退号数 from  MZ_GHXX  a   
                                        left join JC_DEPT_PROPERTY b on  a.GHKS=b.DEPT_ID
                                        left join JC_EMPLOYEE_PROPERTY c on a.GHYS=c.EMPLOYEE_ID
                                        where BQXGHBZ=1  and b.YQID='{0}' and a.QXGHSJ>='{2} ' and a.QXGHSJ<'{3} ' and  b.DEPT_ID ='{1}') as  t
                                        group  by  医生名称",YQID,deptid,starttime,endtime);
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            if(dt==null||dt.Rows.Count<=0)
            {
                MessageBox.Show("当前查询条件下数据为空！");
            }
            dv.DataSource = dt;
        }

        public static void YQ(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            DataRow row ;
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "yqmc";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "yqid";
            dt.Columns.Add(column);
            row = dt.NewRow();
            row["yqmc"] = "南院";
            row["yqid"] = "1001";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["yqmc"] = "后湖";
            row["yqid"] = "1002";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["yqmc"] = "花桥门诊";
            row["yqid"] = "1001";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["yqmc"] = "谌家矶";
            row["yqid"] = "1001";
            dt.Rows.Add(row);
            cmb.DataSource = dt;
            cmb.DisplayMember = "yqmc";
            cmb.ValueMember = "yqid";

        }
    }
}
