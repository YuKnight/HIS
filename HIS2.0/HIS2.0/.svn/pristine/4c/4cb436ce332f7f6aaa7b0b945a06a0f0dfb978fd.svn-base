using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;

namespace TrasenHIS.BLL
{
    public class SyncPatientInfo
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        private static TrasenClasses.DatabaseAccess.RelationalDatabase InFomixDb;
        private static object lockob = new object();

        public SyncPatientInfo(TrasenClasses.DatabaseAccess.RelationalDatabase _Database)
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

        public static void SyncPat(RelationalDatabase db)
        {
            TrasenFrame.Forms.DlgInputBox dlgInput = new TrasenFrame.Forms.DlgInputBox("", "请输入住院号：", "同步病人信息");
            dlgInput.NumCtrl = true;
            dlgInput.ShowDialog();
            if (DlgInputBox.DlgResult)
            {
                string zyh = DlgInputBox.DlgValue;
                GetOldHISInpatientInfo(zyh, db);
            }
        }

        public static bool GetOldHISInpatientInfo(string zyh, RelationalDatabase db)
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
            string msg = "";
            string xml = "";

            try
            {
                if (zyh.Trim() == "")
                {
                    throw new Exception("住院号为空，请检查！");
                }
                oldzyh = Convert.ToInt64(zyh).ToString();
                sql = @" select a.zyh zyh,b.id as patientid,b.xm xm,b.xb xb,b.rq as csrq,b.jg jg,b.mz mz,
                        b.hk hk,b.zycs zycs,b.zy zy,b.csd csd,b.blh blh,b.gj gj,1 zjlx,b.sfzh sfzh,b.dwmc dwmc,b.dwdz dwdz,
                        b.dwdh dwdh,b.dwyzbm dwyzbm,b.jtdz jtdz,b.jtdh jtdh,b.jtyzbm jtyzbm,b.lxr lxr,b.gx gx,b.lxrdz lxrdz,
                        b.lxrdh lxrdh,b.gfdwbm gfdwbm,b.ylzh ylzh,b.gflb as gflbmc,a.ks as deptid,a.rybq as szbq,
                        a.ryrq as inhostime,a.cyrq as outhostime,a.ryzd ryzd,a.cwh as bedno,a.zrys zrys,'Pat_In' as event
                        from zy_zybrxx a inner join zy_brjbxx b on a.zyh=b.zyh
                        inner join yw_zybrzh AS C on a.zyh=c.zyh 
                        where a.ks not in ('000041','000034','000172') and c.bz='N' and  a.zyh='" + oldzyh + "'";
                DataTable oldPatTb = InFomixDb.GetDataTable(sql);
                if (oldPatTb == null || oldPatTb.Rows.Count == 0)
                {
                    throw new Exception("在老系统未找到住院号为【" + oldzyh + "】的病人信息！");
                }
                else
                {
                    string ss = "在老系统找到病人信息如下：\r\n";
                    ss += "住院号：" + oldPatTb.Rows[0]["zyh"].ToString().Trim() + "\r\n";
                    ss += "姓名：" + oldPatTb.Rows[0]["xm"].ToString().Trim() + "\r\n";
                    ss += "入院日期：" + oldPatTb.Rows[0]["inhostime"].ToString().Trim() + "\r\n";
                    ss += "\r\n请核对病人信息是否正确，以及病人姓名是否乱码（如果是乱码请点否退出操作）\r\n是否继续？";
                    if (MessageBox.Show(ss, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return false;
                    }
                }

                msg = GetPatMsg(oldPatTb);

                sql = "select * from vi_zy_vinpatient_all where flag<>10 and inpatient_no like '%" + zyh + "%'";
                DataTable newPatTb = db.GetDataTable(sql);

                TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                if (newPatTb == null || newPatTb.Rows.Count == 0)
                {
                    //如果没有找到病人信息，则要调用WS获取
                    xml = ws.ExeWebService("SaveInpatient", msg);
                    DataSet dset = HisFunctions.ConvertXmlToDataSet(xml);
                    if (dset.Tables["HEAD"].Rows.Count > 0)
                    {
                        if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                        {
                            throw new Exception("调用WS保存病人信息时出现错误，消息格式：" + msg);
                        }
                        else if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "0")
                        {
                            MessageBox.Show("同步成功，请刷新病人列表！");
                        }
                    }
                }
                else
                {
                    //如果有病人信息，也调用WS Add By Tany 2015-02-11
                    ws.ExeWebService("SaveInpatient", msg);//只是调用，不管结果

                    //如果找到了，则需要验证新老系统病人一致性
                    sql = "select deptid from vi_zy_newhishsz where deptid=" + newPatTb.Rows[0]["dept_id"].ToString();
                    DataTable hszTb = db.GetDataTable(sql);
                    if (hszTb != null && hszTb.Rows.Count > 0)
                    {
                        //throw new Exception("该病人已经在上了新护士站的科室，请以新系统的数据为准！");
                        //如果上了新系统，则调用检查病人信息
                        if (CheckPatientInfo.Check(newPatTb.Rows[0]["inpatient_no"].ToString(), db))
                        {
                            MessageBox.Show("同步到老系统成功，请在老系统中检查病人信息！");
                        }
                    }
                    string oldKs = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, oldPatTb.Rows[0]["deptid"].ToString().Trim(), db);
                    if (oldKs == "")
                    {
                        throw new Exception("未找到该科室[" + oldPatTb.Rows[0]["deptid"].ToString().Trim() + "]对应的科室信息！");
                    }
                    string oldCwh = oldPatTb.Rows[0]["bedno"].ToString().Trim();

                    //如果老系统科室和新系统不一样，则调用老系统到新系统的转科事件
                    if (oldKs != newPatTb.Rows[0]["dept_id"].ToString())
                    {
                        MessageBox.Show("该病人在新系统中的科室与老系统的科室不符，系统将尝试修复新系统数据！\r\n\r\n点击确定后将继续操作......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        xml = ws.ExeWebService("TransDept", msg);
                        DataSet dset = HisFunctions.ConvertXmlToDataSet(xml);
                        if (dset.Tables["HEAD"].Rows.Count > 0)
                        {
                            if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                            {
                                throw new Exception("调用WS病人转科时出现错误，消息格式：" + msg);
                            }
                            else if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "0")
                            {
                                MessageBox.Show("同步成功，请刷新病人列表！");
                            }
                        }
                    }
                    else if (oldCwh != "" && oldCwh != newPatTb.Rows[0]["bed_no"].ToString())
                    {
                        //如果床位不同，则调用转床
                        MessageBox.Show("该病人在新系统中的床位与老系统的床位不符，系统将尝试修复新系统数据！\r\n\r\n点击确定后将继续操作......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        xml = ws.ExeWebService("ChangeBed", msg);
                        DataSet dset = HisFunctions.ConvertXmlToDataSet(xml);
                        if (dset.Tables["HEAD"].Rows.Count > 0)
                        {
                            if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                            {
                                throw new Exception("调用WS病人转床时出现错误，消息格式：" + msg);
                            }
                            else if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "0")
                            {
                                MessageBox.Show("同步成功，请刷新病人列表！");
                            }
                        }
                    }
                }

                try
                {
                    //调用一下EMR的方法 Modify By Tany 2016-01-20
                    sql = "select inpatient_id from zy_inpatient where flag<>10 and inpatient_no like '%" + zyh + "%'";
                    msg = ws.GetXml("n2oFpcw.EMR", Convertor.IsNull(db.GetDataResult(sql), Guid.Empty.ToString()));
                    xml = ws.ExeWebService("n2oFpcw.EMR", msg);

                    MessageBox.Show("同步EMR成功，请刷新EMR病人信息！");
                }
                catch
                {
                    throw new Exception("同步EMR时出错，请手工同步！");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static string GetPatMsg(DataTable oldPatTb)
        {
            string msg = "<message>";
            msg += "<zyh>" + oldPatTb.Rows[0]["zyh"].ToString().Trim() + "</zyh>";
            msg += "<patientid>" + oldPatTb.Rows[0]["patientid"].ToString().Trim() + "</patientid>";
            msg += "<xm>" + oldPatTb.Rows[0]["xm"].ToString().Trim() + "</xm>";
            msg += "<xb>" + oldPatTb.Rows[0]["xb"].ToString().Trim() + "</xb>";
            string csrq = "";
            if (oldPatTb.Rows[0]["csrq"].ToString().Trim() != "")
            {
                csrq = Convert.ToDateTime(oldPatTb.Rows[0]["csrq"]).ToString("yyyyMMdd");
            }
            msg += "<csrq>" + csrq + "</csrq>";
            msg += "<jg>" + oldPatTb.Rows[0]["jg"].ToString().Trim() + "</jg>";
            msg += "<mz>" + oldPatTb.Rows[0]["mz"].ToString().Trim() + "</mz>";
            msg += "<hk>" + oldPatTb.Rows[0]["hk"].ToString().Trim() + "</hk>";
            msg += "<zycs>" + oldPatTb.Rows[0]["zycs"].ToString().Trim() + "</zycs>";
            msg += "<zy>" + oldPatTb.Rows[0]["zy"].ToString().Trim() + "</zy>";
            msg += "<csd>" + oldPatTb.Rows[0]["csd"].ToString().Trim() + "</csd>";
            msg += "<blh>" + oldPatTb.Rows[0]["blh"].ToString().Trim() + "</blh>";
            msg += "<gj>" + oldPatTb.Rows[0]["gj"].ToString().Trim() + "</gj>";
            msg += "<zjlx>" + oldPatTb.Rows[0]["zjlx"].ToString().Trim() + "</zjlx>";
            msg += "<sfzh>" + oldPatTb.Rows[0]["sfzh"].ToString().Trim() + "</sfzh>";
            msg += "<dwmc>" + oldPatTb.Rows[0]["dwmc"].ToString().Trim() + "</dwmc>";
            msg += "<dwdz>" + oldPatTb.Rows[0]["dwdz"].ToString().Trim() + "</dwdz>";
            msg += "<dwdh>" + oldPatTb.Rows[0]["dwdh"].ToString().Trim() + "</dwdh>";
            msg += "<dwyzbm>" + oldPatTb.Rows[0]["dwyzbm"].ToString().Trim() + "</dwyzbm>";
            msg += "<jtdz>" + oldPatTb.Rows[0]["jtdz"].ToString().Trim() + "</jtdz>";
            msg += "<jtdh>" + oldPatTb.Rows[0]["jtdh"].ToString().Trim() + "</jtdh>";
            msg += "<jtyzbm>" + oldPatTb.Rows[0]["jtyzbm"].ToString().Trim() + "</jtyzbm>";
            msg += "<lxr>" + oldPatTb.Rows[0]["lxr"].ToString().Trim() + "</lxr>";
            msg += "<gx>" + oldPatTb.Rows[0]["gx"].ToString().Trim() + "</gx>";
            msg += "<lxrdz>" + oldPatTb.Rows[0]["lxrdz"].ToString().Trim() + "</lxrdz>";
            msg += "<lxrdh>" + oldPatTb.Rows[0]["lxrdh"].ToString().Trim() + "</lxrdh>";
            msg += "<gfdwbm>" + oldPatTb.Rows[0]["gfdwbm"].ToString().Trim() + "</gfdwbm>";
            msg += "<ylzh>" + oldPatTb.Rows[0]["ylzh"].ToString().Trim() + "</ylzh>";
            msg += "<gflbmc>" + oldPatTb.Rows[0]["gflbmc"].ToString().Trim() + "</gflbmc>";
            msg += "<deptid>" + oldPatTb.Rows[0]["deptid"].ToString().Trim() + "</deptid>";
            msg += "<szbq>" + oldPatTb.Rows[0]["szbq"].ToString().Trim() + "</szbq>";
            string indate = "";
            if (oldPatTb.Rows[0]["inhostime"].ToString().Trim() != "")
            {
                indate = Convert.ToDateTime(oldPatTb.Rows[0]["inhostime"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            msg += "<inhostime>" + indate + "</inhostime>";
            string outdate = "";
            if (oldPatTb.Rows[0]["outhostime"].ToString().Trim() != "")
            {
                outdate = Convert.ToDateTime(oldPatTb.Rows[0]["outhostime"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            msg += "<outhostime>" + outdate + "</outhostime>";
            msg += "<ryzd>" + oldPatTb.Rows[0]["ryzd"].ToString().Trim() + "</ryzd>";
            msg += "<bedno>" + oldPatTb.Rows[0]["bedno"].ToString().Trim() + "</bedno>";
            msg += "<zrys>" + oldPatTb.Rows[0]["zrys"].ToString().Trim() + "</zrys>";
            msg += "</message>";

            return msg;
        }

        //Add BY Tany 2015-04-01
        /// <summary>
        /// 同步新系统的医生给老系统
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static void SyncDoc(Guid inpatientId, RelationalDatabase db)
        {
            string ssql = @"select inpatient_no,inpatient_id,zy_doc doc_id from zy_inpatient where inpatient_id='" + inpatientId + "'";
            DataTable tb = db.GetDataTable(ssql);
            if (tb == null || tb.Rows.Count == 0)
            {
                throw new Exception("【同步老系统责任医生出错】在新系统中未找到该病人信息，请检查！");
            }
            string zyh = Convert.ToInt64(tb.Rows[0]["inpatient_no"].ToString()).ToString();
            string zrys = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, tb.Rows[0]["doc_id"].ToString(), db);
            if (zrys == "")
            {
                throw new Exception("【同步老系统责任医生出错】未找到对应的责任医生，请检查！");
            }

            InstanceOldHISDb();
            ssql = "UPDATE ZY_ZYBRXX SET zrys='" + zrys + "' WHERE ZYH='" + zyh + "'";
            InFomixDb.DoCommand(ssql);
        }
    }
}
