using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
namespace TrasenHIS.BLL
{
    /// <summary>
    /// 检查老系统与新系统病人信息是否匹配
    /// </summary>
    public class CheckPatientInfo
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        private static TrasenClasses.DatabaseAccess.RelationalDatabase InFomixDb;
        private static object lockob = new object();

        public CheckPatientInfo(TrasenClasses.DatabaseAccess.RelationalDatabase _Database)
        {
            Database = _Database;
        }

        /// <summary>
        /// 实例化老系统连接
        /// </summary>
        private static void InstanceOldHISDb()
        {
            if (InFomixDb == null)
            {
                lock (lockob)
                {
                    if (InFomixDb == null)
                        InFomixDb = TrasenHIS.DAL.BaseDal.GetDb_InFormix();
                }
            }
        }

        /// <summary>
        /// 检查并修正病人信息
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool Check(string zyh, RelationalDatabase db)
        {
            //Modify By Tany 2015-01-30 如果连接不是正式库，则不验证
            string conn = db.ConnectionString;
            string[] s = conn.Split(';');
            if (s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].IndexOf("initial catalog=") >= 0)
                    {
                        if (s[i].Replace("initial catalog=", "").ToLower() != "trasen")
                        {
                            return true;
                        }
                    }
                }
            }

            InstanceOldHISDb();

            string oldzyh = "";
            string sql = "";

            try
            {
                if (zyh.Trim() == "")
                {
                    throw new Exception("住院号为空，请检查！");
                }
                oldzyh = Convert.ToInt64(zyh).ToString();
                sql = "select * from vi_zy_vinpatient_all where flag<>10 and inpatient_no='" + zyh + "' and dept_id in (select deptid from vi_zy_newhishsz)";
                DataTable newPatTb = db.GetDataTable(sql);
                //上线新护士站的病人才进行验证
                if (newPatTb != null && newPatTb.Rows.Count > 0)
                {
                    sql = "select * from zy_zybrxx where zyh='" + oldzyh + "'";
                    DataTable oldPatTb = InFomixDb.GetDataTable(sql);
                    if (oldPatTb == null || oldPatTb.Rows.Count == 0)
                    {
                        throw new Exception("在老系统未找到住院号为【" + oldzyh + "】的病人！");
                    }
                    string oldKs = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, oldPatTb.Rows[0]["ks"].ToString().Trim(), db);
                    if (oldKs == "")
                    {
                        throw new Exception("未找到该科室[" + oldPatTb.Rows[0]["ks"].ToString().Trim() + "]对应的科室信息！");
                    }
                    string oldCwh = oldPatTb.Rows[0]["cwh"].ToString().Trim();

                    bool isTs = false;
                    //如果老系统科室和新系统不一样，则调用新系统到老系统的转科事件
                    if (oldKs != newPatTb.Rows[0]["dept_id"].ToString())
                    {
                        isTs = true;
                        MessageBox.Show("该病人在新系统中的科室与老系统的科室不符，系统将尝试修复老系统数据！\r\n\r\n点击确定后将继续操作......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //不能调用转科WS，只能直接更新数据
                        string _ks = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, newPatTb.Rows[0]["dept_id"].ToString(), db); ;
                        sql = "SELECT BQ FROM zy_bqksdzb Where KS = '" + _ks + "'";
                        string _bq = Convertor.IsNull(InFomixDb.GetDataResult(sql), "");

                        System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                        System.Data.Odbc.OdbcTransaction tx = null;
                        System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                        try
                        {
                            connection.Open();
                            cmd.Connection = connection;
                            tx = connection.BeginTransaction();
                            cmd.Transaction = tx;

                            //清空老床位信息
                            sql = "UPDATE ZY_CWXX Set zyh = '',xm = '',APZ = '',ZT = '空闲' Where zyh = '" + oldzyh + "'";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            //更新病人信息
                            sql = "UPDATE ZY_ZYBRXX SET CWH='',BQ='" + _bq + "',ks='" + _ks + "',bf='',sfapcw='N' WHERE ZYH='" + oldzyh + "'";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            tx.Commit();
                        }
                        catch (Exception err)
                        {
                            tx.Rollback();
                            throw err;
                        }
                        finally
                        {
                            cmd.Dispose();
                            connection.Close();
                        }
                    }
                    //这里需要在检查一下这个病人的床位号如果不为空的情况下，在老系统床位表上是不是有信息 Modify By Tany 2015-01-22
                    string cwZyh = "";
                    if (oldCwh != "")
                    {
                        sql = "select zyh from zy_cwxx where ks='" + oldPatTb.Rows[0]["ks"].ToString() + "' and cwh='" + oldCwh + "'";
                        cwZyh = Convertor.IsNull(InFomixDb.GetDataResult(sql), "");
                    }
                    //如果老系统科室和新系统或者床位不一样，则调用新系统到老系统的转床事件
                    //if (oldKs != newPatTb.Rows[0]["dept_id"].ToString() || oldCwh != newPatTb.Rows[0]["bed_no"].ToString() || cwZyh != oldzyh)
                    //Modify By Tany 2015-05-05 修正这里的判断，因为新老系统床位名称可能不一致，判断床位的时候，需要通过对应关系去验证床号是否正确
                    string mapCwh = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.ZY_BEDDICTION, newPatTb.Rows[0]["bed_id"].ToString(), db);
                    string[] ss = mapCwh.Replace("||", "|").Split("|".ToCharArray());
                    if (ss.Length > 1)
                    {
                        mapCwh = ss[1];
                    }
                    if (oldKs != newPatTb.Rows[0]["dept_id"].ToString() || oldCwh != mapCwh || cwZyh != oldzyh)
                    {
                        if (!isTs)
                        {
                            isTs = true;
                            MessageBox.Show("该病人在新系统中的床位与老系统的床位不符，系统将尝试修复老系统数据！\r\n\r\n点击确定后将继续操作......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                        string strXML = "";
                        strXML = ws.GetXml("n2oZc.HIS", newPatTb.Rows[0]["inpatient_id"].ToString());
                        strXML = ws.ExeWebService("n2oZc.HIS", strXML);
                        DataSet dset = HisFunctions.ConvertXmlToDataSet(strXML);
                        if (dset.Tables["HEAD"].Rows.Count > 0)
                        {
                            if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                            {
                                throw new Exception("调用WS转床时出现错误：" + dset.Tables["HEAD"].Rows[0]["ERRTEXT"].ToString());
                            }
                        }
                    }
                    if (isTs)
                    {
                        MessageBox.Show("老系统数据修复完成，将继续完成您的操作！");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("检查新老系统病人状态时出错，您的操作将不能继续！\r\n\r\n" + ex.Message);
                return false;
            }
        }

        //Add By Tany 2015-04-28
        /// <summary>
        /// 是否在老系统出院审核了
        /// </summary>
        /// <returns></returns>
        public static bool isCysh(string zyh)
        {
            InstanceOldHISDb();

            bool iscysh = false;

            string sql = "select * from yw_zybrzh where zyh='" + Convert.ToInt64(zyh) + "'";
            DataTable tb = InFomixDb.GetDataTable(sql);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (Convertor.IsNull(tb.Rows[0]["shbz"], "").ToUpper() == "Y")
                {
                    iscysh = true;
                }
            }

            return iscysh;
        }

        //Add By Tany 2016-04-13
        /// <summary>
        ///  检查病人老系统是否结算，如果老系统结算新系统未结算，则同步调用结算方法
        /// </summary>
        /// <param name="zyh">住院号</param>
        /// <param name="db">新系统数据库连接</param>
        public static void CheckPatJszt(string zyh, RelationalDatabase db)
        {
            try
            {
                InstanceOldHISDb();

                bool iscyjs = false;

                string sql = "select * from yw_zybrzh where zyh='" + Convert.ToInt64(zyh) + "'";
                DataTable tb = InFomixDb.GetDataTable(sql);
                if (tb != null && tb.Rows.Count > 0)
                {
                    if (Convertor.IsNull(tb.Rows[0]["bz"], "").ToUpper() == "Y")
                    {
                        iscyjs = true;
                    }
                }
                if (!iscyjs)
                {
                    MessageBox.Show("住院号【" + zyh + "】的病人在老系统还未结算！");
                    return;
                }
                else
                {
                    sql = "select * from vi_zy_vinpatient_all where convert(bigint,inpatient_no)='" + Convert.ToInt64(zyh) + "'";
                    tb = db.GetDataTable(sql);
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        MessageBox.Show("住院号【" + zyh + "】的病人在新系统未找到信息！");
                        return;
                    }
                    int flag = Convert.ToInt32(tb.Rows[0]["flag"]);
                    if (flag == 2 || flag == 6)
                    {
                        MessageBox.Show("住院号【" + zyh + "】的病人在新系统已经结算！");
                        return;
                    }
                    else
                    {
                        //调用WS同步结算状态
                        string xml = "";
                        sql = "select zyh,id as patientid,xm,zt as jszt,jsdjh,cyrq,ryrq as ksrq,jsrq,0 as yjj,zfy as ylzfy,gfje as ybzf,zfje,djrq,czy as djybm from v_brfy where zyh='" + Convert.ToInt64(zyh) + "'";
                        tb = InFomixDb.GetDataTable(sql);
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            xml = ConvertToXML.DataTableToXmlEx(tb, "message");
                            TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                            string strXML = "";
                            strXML = ws.ExeWebService("SaveCyzt", xml);
                            DataSet dset = HisFunctions.ConvertXmlToDataSet(strXML);
                            if (dset.Tables["HEAD"].Rows.Count > 0)
                            {
                                if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                                {
                                    throw new Exception("调用WS出院结算时出现错误：" + dset.Tables["HEAD"].Rows[0]["ERRTEXT"].ToString());
                                }
                            }
                            MessageBox.Show("同步结算状态成功，请继续您的操作！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
