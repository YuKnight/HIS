using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
namespace ts_mz_hzxs
{
    public class xsClass
    {
        private string[] _GetGroupName;
        private string[] _GetColumnName;
        private int _PanelColCount;
        private int _PanelRowCount;
        private DataSet _Dset;
        private DataTable _tbGroup;
        public string[] GetGroupName
        {
            get
            {
                return _GetGroupName;
            }
            set
            {
                _GetGroupName = value;
            }
        }
        public string[] GetColumnName
        {
            get
            {
                return _GetColumnName;
            }
            set
            {
                _GetColumnName = value;
            }
        }

        public int PanelColCount
        {
            get
            {
                return _PanelColCount;
            }
            set
            {
                _PanelColCount = value;
            }
        }

        public int PanelRowCount
        {
            get
            {
                return _PanelRowCount;
            }
            set
            {
                _PanelRowCount = value;
            }
        }

        public DataSet Dset
        {
            get
            {
                return _Dset;
            }
            set
            {
                _Dset = value;
            }
        }
        public DataTable tbGroup
        {
            get
            {
                return _tbGroup;
            }
            set
            {
                _tbGroup = value;
            }
        }

        public xsClass(string zqip,RelationalDatabase database)
        {
            _GetGroupName= new string[] { "科室" };
            _GetColumnName = new string[] { "姓名","就诊时间"};
            _PanelColCount = 3;
            _PanelRowCount = 2;

            string ssql = @"select dbo.fun_getdeptname(fzks) 科室,dbo.fun_getghjb(ghjb) 级别,brxm 姓名,pdxh 候诊号,
                        yysd 候诊时段 ,dbo.fun_getzsmc(zsid) 诊室,'' 备注 from mz_ghxx a inner join mzhs_fzjl b on a.ghxxid=b.ghxxid 
                        inner join yy_brxx c on a.brxxid=c.brxxid 
                         where fzsj>='2013-01-26 00:00:00' and fzsj<='2013-01-31 23:00:00'";
            _Dset = new DataSet();
            database.AdapterFillDataSet(ssql, Dset, "ghxx", 30);

            //计算分组
            DataTable tb = Dset.Tables[0];
            string[] GroupbyField3 = _GetGroupName;
            string[] ComputeField3 ={  };
            string[] CField3 ={ "count" };
            _tbGroup = GroupbyDataTable(tb, GroupbyField3, ComputeField3, CField3, null);

            

        }



        public static DataTable GroupbyDataTable(DataTable tb, string[] GroupbyField, string[] ComputeField, string[] CField, DataTable hz)
        {


            //生成汇总空表
            if (hz == null)
            {
                hz = new DataTable();
                for (int i = 0; i <= GroupbyField.Length - 1; i++)
                    hz.Columns.Add(GroupbyField[i]);
                for (int i = 0; i <= ComputeField.Length - 1; i++)
                    hz.Columns.Add(ComputeField[i]);
            }

            if (tb.Rows.Count == 0) return hz;
            //生成查询条件
            string Sel = "";


            try
            {
                for (int i = 0; i <= GroupbyField.Length - 1; i++)
                {
                    if (Sel == "")
                        Sel = GroupbyField[i] + "='" + tb.Rows[0][GroupbyField[i].Trim()] + "'";
                    else
                        Sel = Sel + " and " + GroupbyField[i] + "='" + tb.Rows[0][GroupbyField[i].Trim()] + "'";
                }


                DataRow[] Selrow = tb.Select(Sel);

                if (Selrow.Length == 0) throw new Exception("GroupbyDataTable发生异常");

                //在汇总表添加一条记录,该记录的值等于第一行的记录值
                DataRow hzNewRow = hz.NewRow();
                for (int i = 0; i <= hz.Columns.Count - 1; i++)
                    hzNewRow[hz.Columns[i].ColumnName] = tb.Rows[0][hz.Columns[i].ColumnName];

                //记算
                for (int i = 0; i <= ComputeField.Length - 1; i++)
                {
                    string compute = CField[i] + "(" + ComputeField[i] + ")";
                    decimal nvalue = Convert.IsDBNull(tb.Compute(compute, Sel)) == true ? 0 : Convert.ToDecimal(tb.Compute(compute, Sel));

                    hzNewRow[ComputeField[i]] = nvalue;
                }
                hz.Rows.Add(hzNewRow);


                //移除计算过的行
                if (Selrow.Length != 0)
                {
                    for (int i = 0; i <= Selrow.Length - 1; i++)
                        tb.Rows.Remove(Selrow[i]);
                }
                if (tb.Rows.Count != 0)
                    GroupbyDataTable(tb, GroupbyField, ComputeField, CField, hz);

            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
            return hz;

        }

        
    }

}
