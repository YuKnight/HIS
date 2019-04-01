using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;

namespace ts_mzys_class
{
    /// <summary>
    /// 门诊医生接诊类 最后修改时间:2013-06-19
    /// </summary>
    public class mzys_jzjl
    {

        public static void jz(long jgbm, Guid ghxxid, int jzys, int jzks, string jzsj, string bz, out Guid jzid, out int err_code, out string err_text,int bjsbz, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[10];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = jgbm;

                parameters[1].Text = "@ghxxid";
                parameters[1].Value = ghxxid;

                parameters[2].Text = "@jzys";
                parameters[2].Value = jzys;

                parameters[3].Text = "@jzks";
                parameters[3].Value = jzks;

                parameters[4].Text = "@jzsj";
                parameters[4].Value = jzsj;

                parameters[5].Text = "@bz";
                parameters[5].Value = bz;

                parameters[6].Text = "@jzid";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].DataType = System.Data.DbType.Guid ;
                parameters[6].ParaSize = 100;

                parameters[7].Text = "@err_code";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].DataType = System.Data.DbType.Int32;
                parameters[7].ParaSize = 100;

                parameters[8].Text = "@err_text";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].ParaSize = 100;

                parameters[9].Text = "@bjsbz";
                parameters[9].Value = bjsbz;

                _DataBase.DoCommand("SP_mzys_jz", parameters, 30);
               jzid = new Guid (parameters[6].Value.ToString());
               err_code = Convert.ToInt32(parameters[7].Value);
               err_text = Convert.ToString(parameters[8].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }



        }

        /// <summary>
        /// 门诊医生接诊 add by 2013-06-19
        /// </summary>
        /// <param name="jgbm">机构编码</param>
        /// <param name="ghxxid">挂号信息id</param>
        /// <param name="jzys">接诊医生</param>
        /// <param name="jzks">接诊科室</param>
        /// <param name="jzsj">急诊时间</param>
        /// <param name="bz"></param>
        /// <param name="jzid"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="bjsbz"></param>
        /// <param name="_DataBase"></param>
        public static void Mzysjz(long jgbm, Guid ghxxid, int jzys, int jzks, string jzsj, string bz, out Guid jzid, out int err_code, out string err_text, int bjsbz, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[10];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = jgbm;

                parameters[1].Text = "@ghxxid";
                parameters[1].Value = ghxxid;

                parameters[2].Text = "@jzys";
                parameters[2].Value = jzys;

                parameters[3].Text = "@jzks";
                parameters[3].Value = jzks;

                parameters[4].Text = "@jzsj";
                parameters[4].Value = jzsj;

                parameters[5].Text = "@bz";
                parameters[5].Value = bz;

                parameters[6].Text = "@jzid";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].DataType = System.Data.DbType.Guid;
                parameters[6].ParaSize = 100;

                parameters[7].Text = "@err_code";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].DataType = System.Data.DbType.Int32;
                parameters[7].ParaSize = 100;

                parameters[8].Text = "@err_text";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].ParaSize = 100;

                parameters[9].Text = "@bjsbz";
                parameters[9].Value = bjsbz;

                _DataBase.DoCommand("SP_mzys_jz_New", parameters, 30);
                jzid = new Guid(parameters[6].Value.ToString());
                err_code = Convert.ToInt32(parameters[7].Value);
                err_text = Convert.ToString(parameters[8].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static void Ujz(long jgbm, Guid ghxxid, int jzys, int jzks, string jzsj, string bz, Guid jzid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[9];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = jgbm;  //1000

                parameters[1].Text = "@ghxxid";
                parameters[1].Value = ghxxid;  //5fc8210e-9e21-4a9b-8831-a2a100e748bd

                parameters[2].Text = "@jzys";
                parameters[2].Value = jzys; //74

                parameters[3].Text = "@jzks";
                parameters[3].Value = jzks;//95

                parameters[4].Text = "@jzsj";
                parameters[4].Value = jzsj;//2013-12-27 14:05:28

                parameters[5].Text = "@bz";
                parameters[5].Value = bz;//''

                parameters[6].Text = "@jzid";
                parameters[6].Value = jzid;//e8c789d0-7ae2-4c94-8d24-a2a100e811bc

                parameters[7].Text = "@err_code";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].DataType = System.Data.DbType.Int32;
                parameters[7].ParaSize = 100;

                parameters[8].Text = "@err_text";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].ParaSize = 100;

                _DataBase.DoCommand("SP_mzys_jz_qx", parameters, 30);
                //jzid = new Guid(parameters[6].Value.ToString());
                err_code = Convert.ToInt32(parameters[7].Value);
                err_text = Convert.ToString(parameters[8].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            } 
        }

        public static void wcjz(Guid jzid, string sdate, RelationalDatabase _DataBase)
        {
            string ssql = "update mzys_jzjl set bwcbz=1,wcsj='"+sdate+"' where bwcbz=0 and bscbz=0 and jzid='"+jzid+"'";
            int iii = _DataBase.DoCommand(ssql);
            if (iii != 1)
                throw new Exception("更新到数据"+iii.ToString()+"行,请刷新后重试");
        }

        //无条件取消接诊记录 当前用于收费员开医技项目后未保存 撤销挂号记录和接诊记录 Add By zp 2013-10-11
        public static void Ujz(Guid jzid,RelationalDatabase db)
        {
            try
            {
                string sql = string.Format("update MZYS_JZJL set BSCBZ=1 where JZID='{0}'", jzid);
                db.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
    }
}
