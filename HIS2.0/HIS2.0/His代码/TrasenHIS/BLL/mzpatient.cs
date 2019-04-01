using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenHIS.BLL;
using TrasenFrame.Classes;
using ts_mz_class;

namespace TrasenHIS.BLL
{
    public class mzpatient
    {

        public static string SaveMzcf(DataSet dset, RelationalDatabase db)
        {
            RelationalDatabase old_db = DAL.BaseDal.GetDb_InFormix();

            try
            {
                db.BeginTransaction();
                DataTable tb = dset.Tables["examReqInfoType"];
                string ssql = "";
                DataRow row = tb.Rows[0];
                string examReqId = row["examReqId"].ToString();
                string id = row["id"].ToString();

                

                List<System.String[]> listInsert;

                ssql = "select * from mz_brjbxxb where id='" + id + "'";
                DataTable tbpatient = old_db.GetDataTable(ssql);
                listInsert = HisFunctions.GetInsertSql("whzxyy_mz_brjbxxb", tbpatient);
                for (int i = 0; i <= listInsert.Count - 1; i++)
                {
                    ssql = "select * from whzxyy_mz_brjbxxb where id='" + id + "'";
                    DataTable tbpa = db.GetDataTable(ssql);
                    if (tbpa.Rows.Count == 0)
                        db.DoCommand(listInsert[i][0]);
                }

                ssql = "select * from mz_cfd_zb where djhm='" + examReqId + "'";
                DataTable tb_zb = old_db.GetDataTable(ssql);
                listInsert = HisFunctions.GetInsertSql("whzxyy_mz_cfb_zb", tb_zb);
                for (int i = 0; i <= listInsert.Count - 1; i++)
                {
                    db.DoCommand(listInsert[i][0]);
                }

                ssql = " select  b.* from mz_cfd_zb a inner join mz_cfd_cb b on a.dh=b.dh where djhm='" + examReqId + "'";
                DataTable tb_cb = old_db.GetDataTable(ssql);
                listInsert = HisFunctions.GetInsertSql("whzxyy_mz_cfb_cb", tb_cb);
                for (int i = 0; i <= listInsert.Count - 1; i++)
                {
                    db.DoCommand(listInsert[i][0]);
                }


                ParameterEx[] parameters = new ParameterEx[4];

                string sSql = "SP_WHZXYY_mz_cfb";
                parameters[0].Value = examReqId;
                parameters[0].Text = "@jsdjh";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].Text = "@Err_Code";
                parameters[1].ParaSize = 50;
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].Text = "@err_text";
                parameters[2].ParaSize = 1000;
                parameters[3].Value = id;
                parameters[3].Text = "@id";

                db.DoCommand(sSql, parameters, 60);

                int errocde = Convert.ToInt32(parameters[1].Value);
                string errtext = parameters[2].Value.ToString();
                if (errocde != 0) throw new Exception(errtext);

                db.CommitTransaction();

                System.String[] str = { errocde.ToString(), "保存成功" };
                return HisFunctions.GetResponseString("SaveMzcf", str);
            }
            catch (Exception err)
            {
               db.RollbackTransaction();
                throw err;
            }
            finally
            {
                old_db.Close();
            }
        }

        public static string SaveMztf(DataSet dset, RelationalDatabase db)
        {

            try
            {
                db.BeginTransaction();
                DataTable tb = dset.Tables["examReqInfoType"];
                string ssql = "";
                DataRow row = tb.Rows[0];
                string examReqId = row["examReqId"].ToString();
                string id = row["id"].ToString();

                ParameterEx[] parameters = new ParameterEx[4];

                string sSql = "SP_WHZXYY_mz_cfb_tf";
                parameters[0].Value = examReqId;
                parameters[0].Text = "@jsdjh";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].Text = "@Err_Code";
                parameters[1].ParaSize = 50;
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].Text = "@err_text";
                parameters[2].ParaSize = 1000;
                parameters[3].Value = "";
                parameters[3].Text = "@tfy";
                db.DoCommand(sSql, parameters, 60);

                int errocde = Convert.ToInt32(parameters[1].Value);
                string errtext = parameters[2].Value.ToString();
                if (errocde != 0) throw new Exception(errtext);

                db.CommitTransaction();

                System.String[] str = { errocde.ToString(), "保存成功" };
                return HisFunctions.GetResponseString("SaveMzcf", str);
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                throw err;
            }
            finally
            {

            }
        }

    }
}
