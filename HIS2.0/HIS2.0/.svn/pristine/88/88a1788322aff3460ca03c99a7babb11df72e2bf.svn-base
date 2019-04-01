using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using grproLib;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_Mzghsf_Tj
{
    public class Utility
    {

        //此函数用来注册Grid++Report，你必须在你的应用程序启动时调用此函数       
        //public static void RegisterGridppReport()
        //{
        //    GridppReport TempGridppReport = new GridppReport();
        //    bool Succeeded = TempGridppReport.Register("XXXX123");
        //    if (!Succeeded)
        //        System.Windows.Forms.MessageBox.Show("Register Grid++Report Failed, Grid++Report will run in trial mode.", "Register"
        //            , System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
        //}

        /// <summary>
        /// 挂号收费现金支付汇总统计
        /// </summary>
        /// <param name="StartDate">收费开始时间</param>
        /// <param name="EndDate">收费结束时间</param>
        /// <param name="GhyId">挂号员ID</param>
        /// <returns>数据表</returns>
        public static DataTable GetInfo_Ghyjk_XJ1(string StartDate, string EndDate, int GhyId)
        {
            DataTable tb = null;
            //try
            //{
            //    ParameterEntities ps = new ParameterEntities();
            //    ps.Add(new ParameterEntity("@STARTDATE", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss")));
            //    ps.Add(new ParameterEntity("@ENDDATE", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss")));
            //    ps.Add(new ParameterEntity("@DJY", GhyId));
            //    ObjectDal dal = new ObjectDal();
            //    tb = dal.GetData("SP_MZ_GHYJK_XJ", CommandTypeEnum.StoredProcedure, ps);
            //}
            //catch (System.Exception err)
            //{
            //    throw new System.Exception(err.ToString());
            //}
            return tb;
        }

        /// <summary>
        /// 挂号收费银行卡支付方式汇总统计
        /// </summary>
        /// <param name="StartDate">收费开始时间</param>
        /// <param name="EndDate">收费结束时间</param>
        /// <param name="GhyId">收费员ID</param>
        /// <returns>数据表</returns>
        public static DataTable GetInfo_Ghyjk_YHK1(string StartDate, string EndDate, int GhyId)
        {
            DataTable tb = null;
            //try
            //{
            //    ParameterEntities ps = new ParameterEntities();
            //    ps.Add(new ParameterEntity("@STARTDATE", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss")));
            //    ps.Add(new ParameterEntity("@ENDDATE", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss")));
            //    ps.Add(new ParameterEntity("@DJY", GhyId));
            //    ObjectDal dal = new ObjectDal();
            //    tb = dal.GetData("SP_MZ_GHYJK_YHK", CommandTypeEnum.StoredProcedure, ps);
            //}
            //catch (System.Exception err)
            //{
            //    throw new System.Exception(err.ToString());
            //}
            return tb;
        }

        /// <summary>
        /// 挂号收费人员其他收费支付方式汇总统计
        /// </summary>
        /// <param name="StartDate">收费开始时间</param>
        /// <param name="EndDate">收费结束时间</param>
        /// <param name="GhyId">挂号员id</param>
        /// <returns>数据表</returns>
        public static DataTable GetInfo_Ghyjk_QTZF1(string StartDate, string EndDate, int GhyId)
        {
            DataTable tb = null;
            //try
            //{
            //    ParameterEntities ps = new ParameterEntities();
            //    ps.Add(new ParameterEntity("@STARTDATE", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss")));
            //    ps.Add(new ParameterEntity("@ENDDATE", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss")));
            //    ps.Add(new ParameterEntity("@DJY", GhyId));
            //    ObjectDal dal = new ObjectDal();
            //    tb = dal.GetData("SP_MZ_GHYJK_QTZF", CommandTypeEnum.StoredProcedure, ps);
            //}
            //catch (System.Exception err)
            //{
            //    throw new System.Exception(err.ToString());
            //}
            return tb;
        }

        public static DataTable GetInfo_Ghyjk_YHK(string StartDate, string EndDate, int GhyId,string strYQID,  RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@STARTDATE";
                parameters[0].Value = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "@DJY";
                parameters[2].Value = GhyId;

                parameters[3].Text = "@YQID";
                parameters[3].Value = strYQID;

                tb = _DataBase.GetDataTable("SP_MZ_GHYJK_YHK", parameters);

                /* ParameterEntities ps = new ParameterEntities();
                 ps.Add(new ParameterEntity("@STARTDATE", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@ENDDATE", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@DJY", GhyId));
                 ObjectDal dal = new ObjectDal();
                 tb = dal.GetData("SP_MZ_GHYJK_YHK", CommandTypeEnum.StoredProcedure, ps);*/
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
            return tb;
        }

        public static DataTable GetInfo_Ghyjk_QTZF(string StartDate, string EndDate, int GhyId, string strYQID, RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@STARTDATE";
                parameters[0].Value = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "@DJY";
                parameters[2].Value = GhyId;

                parameters[3].Text = "@YQID";
                parameters[3].Value = strYQID;
                tb = _DataBase.GetDataTable("SP_MZ_GHYJK_QTZF", parameters);

                /* ParameterEntities ps = new ParameterEntities();
                 ps.Add(new ParameterEntity("@STARTDATE", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@ENDDATE", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@DJY", GhyId));
                 ObjectDal dal = new ObjectDal();
                 tb = dal.GetData("SP_MZ_GHYJK_YHK", CommandTypeEnum.StoredProcedure, ps);*/
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
            return tb;
        }

        public static DataTable GetInfo_Ghyjk_YHK(string StartDate, string EndDate, int GhyId,  RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@STARTDATE";
                parameters[0].Value = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "@DJY";
                parameters[2].Value = GhyId;


                tb = _DataBase.GetDataTable("SP_MZ_GHYJK_YHK_TH", parameters);

                /* ParameterEntities ps = new ParameterEntities();
                 ps.Add(new ParameterEntity("@STARTDATE", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@ENDDATE", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@DJY", GhyId));
                 ObjectDal dal = new ObjectDal();
                 tb = dal.GetData("SP_MZ_GHYJK_YHK", CommandTypeEnum.StoredProcedure, ps);*/
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
            return tb;
        }

        public static DataTable GetInfo_Ghyjk_QTZF(string StartDate, string EndDate, int GhyId,  RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@STARTDATE";
                parameters[0].Value = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "@DJY";
                parameters[2].Value = GhyId;

               
                tb = _DataBase.GetDataTable("SP_MZ_GHYJK_QTZF_TH", parameters);

                /* ParameterEntities ps = new ParameterEntities();
                 ps.Add(new ParameterEntity("@STARTDATE", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@ENDDATE", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@DJY", GhyId));
                 ObjectDal dal = new ObjectDal();
                 tb = dal.GetData("SP_MZ_GHYJK_YHK", CommandTypeEnum.StoredProcedure, ps);*/
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
            return tb;
        }

        public static DataTable GetInfo_Ghyjk_XJ(string StartDate, string EndDate, int GhyId,string strYQID, RelationalDatabase _DataBase)
        {
            DataTable tb = new DataTable();
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@STARTDATE";
                parameters[0].Value = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "@DJY";
                parameters[2].Value = GhyId;

                parameters[3].Text = "@YQID";
                parameters[3].Value = strYQID;

                tb = _DataBase.GetDataTable("SP_MZ_GHYJK_XJ", parameters);

                /* ParameterEntities ps = new ParameterEntities();
                 ps.Add(new ParameterEntity("@STARTDATE", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@ENDDATE", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss")));
                 ps.Add(new ParameterEntity("@DJY", GhyId));
                 ObjectDal dal = new ObjectDal();
                 tb = dal.GetData("SP_MZ_GHYJK_YHK", CommandTypeEnum.StoredProcedure, ps);*/
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
            return tb;
        }


        private struct MatchFieldPairType
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
                Report.DetailGrid.Recordset.Append();

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

        public static string GetSampleRootPath()
        {
            string FileName = Application.StartupPath.ToLower();
            int Index = FileName.LastIndexOf("samples");
            FileName = FileName.Substring(0, Index);
            return FileName + @"samples\";
        }

        public static string GetReportTemplatePath()
        {
            return GetSampleRootPath() + @"Reports\";
        }

        public static string GetReportDataPath()
        {
            return GetSampleRootPath() + @"Data\";
        }

        public static string GetReportDataPathFile()
        {
            return GetReportDataPath() + @"NorthWind.mdb";
        }

        public static string GetDatabaseConnectionString()
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + GetReportDataPathFile();
        }
    }
}