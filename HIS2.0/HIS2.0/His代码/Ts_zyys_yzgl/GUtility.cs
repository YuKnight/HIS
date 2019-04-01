using System;
using System.Collections.Generic;
using System.Text;
using grproLib;
using System.Data;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{

    public class GUtility
    {
        //数据库连接字符串
        //public static string DbConnectString = Trasen.DbAcc.InstanceBaseForm.BDatabase.ConnectionString;

        //此函数用来注册Grid++Report，你必须在你的应用程序启动时调用此函数
        //用你自己的序列号代替"AAAAAAA"，"AAAAAAA"是一个无效的序列号
        public static void RegisterGridppReport()
        {
            GridppReport TempGridppReport = new GridppReport();
            bool Succeeded = TempGridppReport.Register("YJM672NKEJ64");
            if (!Succeeded)
                System.Windows.Forms.MessageBox.Show("Register Grid++Report Failed, Grid++Report will run in trial mode.", "Register"
                    , System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
        }

        private  struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }

        // 将 DataReader 的数据转储到 Grid++Report 的数据集中
        public static void FillRecordToReport(IGridppReport Report, IDataReader dr)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dr.FieldCount)];
            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dr.FieldCount; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.RunningDBField, dr.GetName(i), true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }
            // Loop through the contents of the OleDbDataReader object.
            // 将 DataReader 中的每一条记录转储到Grid++Report 的数据集中去
            while (dr.Read())
            {
                Report.DetailGrid.Recordset.Append();
                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsDBNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr.GetValue(MatchFieldPairs[i].MatchColumnIndex);
                }
                Report.DetailGrid.Recordset.Post();
            }
        }

        // 将 DataTable 的数据转储到 Grid++Report 的数据集中
        public static void FillRecordToReport(IGridppReport Report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
            foreach (DataRow dr in dt.Rows)
            {
                Report.RunningDetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                }

                Report.RunningDetailGrid.Recordset.Post();
            }
        }

        // 将 DataTable 的数据转储到 Grid++Report 的数据集中(jchl)
        public static void FillDataTableToReport(IGridppReport Report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.DBFieldName, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }

            //Report.DetailGrid.Recordset.
            // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
            foreach (DataRow dr in dt.Rows)
            {
                Report.DetailGrid.Recordset.Append();
                //Report.DetailGrid.AppendBlankRowAtLast = true;
                //Report.DetailGrid.Recordset.Assign
                //Report.

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                }

                Report.DetailGrid.Recordset.Post();
            }
        }

        public static uint RGBToOleColor(byte r, byte g, byte b)
        {
            return ((uint)b) * 256 * 256 + ((uint)g) * 256 + r;
        }

        public static uint ColorToOleColor(System.Drawing.Color val)
        {
            return RGBToOleColor(val.R, val.G, val.B);
        }

        //获得报表路径
        public static string GetReportPath(string rptName)
        {
            string strStartPaht = Application.StartupPath;
            return strStartPaht + @"\Report\" + rptName;
        }

        /// <summary>
        /// 根据报表文件名获取报表
        /// </summary>
        /// <param name="rptName"></param>
        public static GridppReport GetReport(string rptName)
        {
            GridppReport rpt = new GridppReport();
            string path = GetReportPath(rptName);
            rpt.LoadFromFile(path);
            return rpt;
        }

        //public static bool SetReportPageSizeFromDB(IGridppReport rpt, string rptName, RelationalDatabase db)
        //{
        //    //首先判断服务器上是否有该纸张
        //    string ssql = string.Format(" select * from JC_REPORTPAPER where reportname ='{0}'", rptName);
        //    DataTable dt = db.GetDataTable(ssql);
        //    if (dt.Rows.Count <= 0) return false;
        //    DataRow row = dt.Rows[0];
        //    //求得用报表使用的计量单位表示的纸张尺寸值
        //    double Width = Convert.ToDouble(row["paperwidth"]);
        //    double Length = Convert.ToDouble(row["paperheight"]);
        //    if (rpt.Unit == GRUnit.grmuInch)
        //    {
        //        Width /= 25.4;
        //        Length /= 25.4;
        //    }
        //    rpt.PrintAsDesignPaper = true; //设定总是按设计时页面设置参数生成打印页面
        //    rpt.PrintToStretch = false;    //当输出打印机的页面设置与页面数据不一致时，不进行伸缩平铺输出
        //    rpt.DesignPaperSize = 256;     //256代表自定义纸张
        //    rpt.DesignPaperWidth = Width;
        //    rpt.DesignPaperLength = Length;
        //    //rpt.DesignPaperOrientation = ckbLandScape.Checked ? GRPaperOrientation.grpoLandscape : GRPaperOrientation.grpoPortrait;//横向 或者纵向
        //    return true;
        //}
    }
}
