using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using System.Collections;
using System.Windows.Forms;
namespace Ts_Clinicalpathway_Factory
{
    /// <summary>
    /// 曼德罗临床路径接口
    /// </summary>
    public  class Ts_Manadal_path
    {
        public  static DataView view;
        public static int GetCpstatus(string inpateint_id, string baby_id,string dept_br, string wardbr,string inpatient_no,string in_date)
        {
            try
            {
                string strWorker = "WORKER_ID@" + FrmMdiMain.CurrentUser.LoginCode + "|WORKER_NAME@" + FrmMdiMain.CurrentUser.Name + "|WORKER_MEDIC_DEGREE@|WORKER_MEDIC_DUTY@|WORKER_MEDIC_DEPARTMENT@" + FrmMdiMain.CurrentDept.WardName + "|WORKER_MEDIC_DIVISION@|WORKER_MEDIC_GROUP@|WORKER_MEDIC_OFFICE@" + FrmMdiMain.CurrentDept.DeptName + "|WORKER_MEDIC_DEPARTMENT_ID@" + FrmMdiMain.CurrentDept.WardId + "|WORKER_MEDIC_OFFICE_ID@" + FrmMdiMain.CurrentDept.DeptId + "";
                //设置病人的索引信息
                string strPatientIndex = "UHID@|DATE_VALIDATED@"+in_date+"|CELL_ID@|OUTPATIENT_ID@|INPATIENT_ID@" + inpatient_no + "|MEDICAL_RECORD_ID@|HIS_INSIDE_ID@|HIS_OUTSIDE_ID@|SOCIAL_SECURITY_ID@|Tag@";
                //初始化接口
                Inscription.Manadal.EmrPlugIn.epiFunctionBase Function = Inscription.Manadal.EmrPlugIn.epiManager.GetEmrPlugInFunction("HIS", "", strWorker, strPatientIndex);
                string RunInfo = Function.Cell("是否入径", new string[] { "All" });
                if (RunInfo.Trim() == "" || RunInfo == string.Empty)
                {
                    return 0;//代表没有进入路径
                }
                else
                    return 1;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 医嘱验证
        /// </summary>
        /// <param name="inpateint_id"></param>
        /// <param name="baby_id"></param>
        /// <param name="dept_br"></param>
        /// <param name="wardbr"></param>
        /// <param name="inpatient_no"></param>
        /// <param name="tb"></param>
        public static string Yzyz(string inpateint_id, string baby_id, string dept_br, string wardbr, string inpatient_no, DataTable tb, string in_date)
        {
            try
            {
                if (GetCpstatus(inpateint_id, baby_id, dept_br, wardbr, inpatient_no,in_date) != 0)
                {
                    string strWorker = "WORKER_ID@" + FrmMdiMain.CurrentUser.LoginCode + "|WORKER_NAME@" + FrmMdiMain.CurrentUser.Name + "|WORKER_MEDIC_DEGREE@|WORKER_MEDIC_DUTY@|WORKER_MEDIC_DEPARTMENT@" + FrmMdiMain.CurrentDept.WardName + "|WORKER_MEDIC_DIVISION@|WORKER_MEDIC_GROUP@|WORKER_MEDIC_OFFICE@" + FrmMdiMain.CurrentDept.DeptName + "|WORKER_MEDIC_DEPARTMENT_ID@" + FrmMdiMain.CurrentDept.WardId + "|WORKER_MEDIC_OFFICE_ID@" + FrmMdiMain.CurrentDept.DeptId + "";
                    //设置病人的索引信息
                    string strPatientIndex = "UHID@|DATE_VALIDATED@"+in_date+"|CELL_ID@|OUTPATIENT_ID@|INPATIENT_ID@" + inpatient_no + "|MEDICAL_RECORD_ID@|HIS_INSIDE_ID@|HIS_OUTSIDE_ID@|SOCIAL_SECURITY_ID@|Tag@";
                    //初始化接口
                    Inscription.Manadal.EmrPlugIn.epiFunctionBase Function = Inscription.Manadal.EmrPlugIn.epiManager.GetEmrPlugInFunction("HIS", "", strWorker, strPatientIndex);
                    string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Group>";
                    DataTable tbnew = tb.Copy();

                    tbnew.DefaultView.RowFilter = " (status_flag is null or status_flag<=0 ) and 医嘱内容 is not null";
                    tbnew = tbnew.DefaultView.ToTable();
                    if(tbnew.Rows.Count==0)
                         return "";
                    int flag = 0;
                    for (int i = 0; i < tbnew.Rows.Count; i++)
                    {
                        //第医嘱的第一行
                        if (tbnew.Rows[i]["医嘱内容"].ToString().Trim() != "" && IsGroupFirstRow(tbnew, i))
                        {
                            //if (xml != "<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                            //    xml += "</Group>";
                            xml += "<ITEM ADVICE_CODE='" + (tbnew.Rows[i]["xmly"].ToString().Trim() == "1" ? "yp":"xm")+ tbnew.Rows[i]["hoitem_id"].ToString().Trim() + "' ADVICE_NAME_A='" + tbnew.Rows[i]["医嘱内容"].ToString().Trim() + "' PRICE_DOSE_SPECS='" + tbnew.Rows[i]["剂量"].ToString().Trim() + tbnew.Rows[i]["单位"].ToString().Trim() + "' PRICE_DOSE_VALUE='0'/>";

                        }
                        else
                        {
                            xml += "<ITEM ADVICE_CODE='" + (tbnew.Rows[i]["xmly"].ToString().Trim() == "1" ? "yp" : "xm") + tbnew.Rows[i]["hoitem_id"].ToString().Trim() + "' ADVICE_NAME_A='" + tbnew.Rows[i]["医嘱内容"].ToString().Trim() + "' PRICE_DOSE_SPECS='" + tbnew.Rows[i]["剂量"].ToString().Trim() + tbnew.Rows[i]["单位"].ToString().Trim() + "' PRICE_DOSE_VALUE='0'/>";
                        }
                     
                        //if(i==tbnew.Rows.Count-1)
                        //    xml += "</Group>";
                      
                    }
                    xml += "</Group>";
                    string RunInfo = Function.Cell("医嘱验证", new string[] { xml });
                   
                    return RunInfo;
                }
                return "";
            }
            catch (Exception ex)
            {
                return "操作取消";
                throw new Exception(ex.Message+" 医嘱验证错误");
               
            }
        }
        //判断是否是一组的第一列
        private static bool IsGroupFirstRow(DataTable myTb, int nrow)
        {
            if (nrow == 0) return true;
            if (myTb.Rows[nrow]["开始时间"].ToString().Trim() != ""
                || myTb.Rows[nrow]["医嘱内容"].ToString().Trim() == "术后医嘱"
                || myTb.Rows[nrow]["医嘱内容"].ToString().Trim() == "产后医嘱")
            {
                return true;//上一列无内容
            }
            else
            {
                return false;
            }
        }
        public static bool ShowCpform(string _inpatient_id, string _baby_id, string dept_br, string wardbr, string inpatient_no)
        {
            return false;
        }
        public static bool ShowCpform(string _inpatient_id, string _baby_id, string dept_br, string wardbr, string inpatient_no, string in_date)
        {
           string strWorker = "WORKER_ID@"+FrmMdiMain.CurrentUser.LoginCode+"|WORKER_NAME@"+FrmMdiMain.CurrentUser.Name+"|WORKER_MEDIC_DEGREE@|WORKER_MEDIC_DUTY@|WORKER_MEDIC_DEPARTMENT@"+FrmMdiMain.CurrentDept.WardName+"|WORKER_MEDIC_DIVISION@|WORKER_MEDIC_GROUP@|WORKER_MEDIC_OFFICE@"+FrmMdiMain.CurrentDept.DeptName+"|WORKER_MEDIC_DEPARTMENT_ID@"+FrmMdiMain.CurrentDept.WardId+"|WORKER_MEDIC_OFFICE_ID@"+FrmMdiMain.CurrentDept.DeptId+"";
            //设置病人的索引信息
           string strPatientIndex = "UHID@|DATE_VALIDATED@" + in_date + "|CELL_ID@|OUTPATIENT_ID@|INPATIENT_ID@" + inpatient_no + "|MEDICAL_RECORD_ID@|HIS_INSIDE_ID@|HIS_OUTSIDE_ID@|SOCIAL_SECURITY_ID@|Tag@";

           //strPatientIndex = "UHID@2[测试医生2]431517619234.375|DATE_VALIDATED@2013-09-03 10:00:19|CELL_ID@|OUTPATIENT_ID@|INPATIENT_ID@131017533|MEDICAL_RECORD_ID@|HIS_INSIDE_ID@|HIS_OUTSIDE_ID@|SOCIAL_SECURITY_ID@|Tag@";

          // strWorker = "WORKER_ID@guest1|WORKER_NAME@Guest1|WORKER_MEDIC_DEGREE@院长|WORKER_MEDIC_DUTY@|WORKER_MEDIC_DEPARTMENT@%|WORKER_MEDIC_DIVISION@系统用户|WORKER_MEDIC_GROUP@系统用户|WORKER_MEDIC_OFFICE@系统用户|WORKER_MEDIC_DEPARTMENT_ID@|WORKER_MEDIC_OFFICE_ID@";
            //初始化接口
            Inscription.Manadal.EmrPlugIn.epiFunctionBase Function = Inscription.Manadal.EmrPlugIn.epiManager.GetEmrPlugInFunction("HIS", "", strWorker, strPatientIndex);         
            //获取路径医嘱套餐
            string RunInfo = Function.Cell("获取医嘱套餐", new string[] { });
            //MessageBox.Show(RunInfo);
            //return true;
            DataView newview = new DataView();
            //newview = view;
            DataTable tbview = new DataTable();
            int yf = 0;
            //选择药房 Modify By zouchihua 2012-9-28 0表示所有药房
            if (yf != 0)
            {
                tbview = view.Table;
                tbview.DefaultView.RowFilter = " ((type in (1,2,3) and default_dept=" + yf.ToString() + ") or type not in (1,2,3))";
            }
            else
            {

                tbview = view.Table;
                tbview.DefaultView.RowFilter = " ";
            }
            newview = new DataView(tbview.DefaultView.ToTable());
            string xmlstr = RunInfo;
            DataTable tb= GetTable(xmlstr);
            if (tb == null)
                return false;
            //更改列名
            tb.Columns["ADVICE_TYPE_CODE"].ColumnName = "xmly";
            tb.Columns["GROUP_ID"].ColumnName = "fzxh";
            tb.Columns["OPEN_TYPE_CODE"].ColumnName = "mngtype";//临时或者长期医嘱
            tb.Columns["USAGE_NAME"].ColumnName = "yf";
            tb.Columns["FREQ_NAME"].ColumnName = "pc";

            tb.Columns["base_dose_value"].ColumnName = "jl";//剂量
            tb.Columns["BASE_DOSE_UNITNAME"].ColumnName = "jldw";
            tb.Columns["ADVICE_CODE"].ColumnName = "xmid";//项目为hotiem_id ,药品为cjid;
            tb.Columns["ADVICE_NAME_A"].ColumnName = "content";

            ArrayList ArCfxh=new ArrayList();
            try
            {
                SaveCporder(newview, tb, _inpatient_id, _baby_id, dept_br, wardbr, Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), ref ArCfxh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存临床路径医嘱
        /// </summary>
        /// <param name="view"></param>
        /// <param name="Cporder"></param>
        public static void SaveCporder(DataView view, DataTable Cporder, string inpatient_id, string bayby_id, string dept_br, string ward_id, string pathway_id,
            string PATHWAY_EXE_ID, string PATH_STEP_ID, string EXE_STEP_ID, ref ArrayList Arcfxh)
        {
            ArrayList Arlong = new ArrayList();
            ArrayList Artemp = new ArrayList();
            string sslong = "";
            string sstemp = "";
            //长期医嘱
            Cporder.DefaultView.RowFilter = "mngtype like '0%'";
            DataTable Longorder = Cporder.DefaultView.ToTable();
            //临时医嘱
            Cporder.DefaultView.RowFilter = "mngtype not like '0%'";
            DataTable temporder = Cporder.DefaultView.ToTable();
            try
            {

                Commitorder(Longorder, view, inpatient_id, bayby_id, dept_br, ward_id, pathway_id, PATHWAY_EXE_ID, PATH_STEP_ID, EXE_STEP_ID, ref  Arlong, ref sslong);
                Commitorder(temporder, view, inpatient_id, bayby_id, dept_br, ward_id, pathway_id, PATHWAY_EXE_ID, PATH_STEP_ID, EXE_STEP_ID, ref Artemp, ref sstemp);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                for (int i = 0; i < Arlong.Count; i++)
                {
                    Arcfxh.Add(Arlong[i]);
                }
                for (int i = 0; i < Artemp.Count; i++)
                {
                    Arcfxh.Add(Artemp[i]);
                }
                if (sslong + sstemp != "")
                    throw new Exception(sslong + "\n" + sstemp);
            }

        }
        /// <summary>
        /// 提交医嘱到数据库
        /// </summary>
        /// <param name="tb"></param>
        private static void Commitorder(DataTable tb, DataView view, string inpatient_id, string bayby_id, string dept_br, string ward_id, string pathway_id,
     string PATHWAY_EXE_ID, string PATH_STEP_ID, string EXE_STEP_ID, ref ArrayList Arcfxh, ref string sslog)
        {
            string PATH_STEP_ITEM_ID = "";
            string strmsg = "";
            DataTable Longorder = tb;
            ArrayList psorderidarr = new ArrayList();
            ArrayList path_itemexe_idarr = new ArrayList();
            DateTime tempDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            //获得表结构
            DataTable Hisorder = FrmMdiMain.Database.GetDataTable("select * from zy_orderrecord where 1=2");
            Guid path_itemexe_id = Guid.Empty;

            int temgroup = 0;
            int SERIAL_NO = 0;
            string oldgroupid = "";

            //第一步
            string erStr = "";
            try
            {
                erStr = CommitOrderrecord(Guid.Empty, 0, new Guid(inpatient_id), 0, "", 0, 0, 0, 0, "", 1, "", 0, 0, "", "", tempDate, tempDate, 0, "", "", 0, 0, 0, 0, 0, 0, "", 0, -1, Guid.Empty, 0, 0, 0, 1, "", FrmMdiMain.Jgbm, 0, Guid.Empty, 0, -1, 1, 0, "", "1"
                    , Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), 0);
            }
            catch (Exception err)
            {
                MessageBox.Show(erStr + err.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            #region//第二步
            for (int i = 0; i < Longorder.Rows.Count; i++)
            {

                string oldmngtyype = Longorder.Rows[i]["mngtype"].ToString();
                Longorder.Rows[i]["xmid"] = Longorder.Rows[i]["xmid"].ToString().Replace("xm", "");
                Longorder.Rows[i]["xmid"] = Longorder.Rows[i]["xmid"].ToString().Replace("yp", "");
                //测试用
                //if (i == 0)
                //    Longorder.Rows[i]["xmid"] = 1338;
                try
                {
                    if (Longorder.Rows[i]["mngtype"].ToString().Trim().Substring(0, 1) == "6")//表示是术后医嘱
                        Longorder.Rows[i]["mngtype"] = 0;//也是长期医嘱
                    else
                        Longorder.Rows[i]["mngtype"] = Longorder.Rows[i]["mngtype"].ToString().Trim().Substring(0, 1);
                }
                catch
                {
                    MessageBox.Show(Longorder.Rows[i]["mngtype"].ToString());
                }
                DataRow hisrow = Hisorder.NewRow();
                //获得执行科室，等信息
                DataRow[] selrow;
                if (Longorder.Rows[i]["xmly"].ToString() == "1")
                {
                  
                        //先找cjid的药品
                        selrow = view.Table.Select("order_id=" + Longorder.Rows[i]["xmid"].ToString() + " and xmly=1");
                    try
                    {
                        //如果没有找到，找一个规格相同的药品
                        if (selrow == null || selrow.Length == 0)
                        {
                            DataTable tempYP = FrmMdiMain.Database.GetDataTable("select cjid,GGID,lsj from VI_YP_YPCD where cjid=" + Longorder.Rows[i]["xmid"].ToString() + " and BDELETE=0");
                            if (tempYP.Rows.Count > 0)
                            {
                                selrow = view.Table.Select("项目代码=" + tempYP.Rows[0]["ggid"].ToString() + " and 单价=" + tempYP.Rows[0]["lsj"].ToString() + "  and xmly=1");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("zheli sdfsdfs");//测试用
                    }
                }
                else
                {
                    
                    selrow = view.Table.Select("order_id=" + Longorder.Rows[i]["xmid"].ToString() + " and xmly=2");

                }
               
                //找到对应记录
                if ((selrow != null && selrow.Length > 0) || (Longorder.Rows[i]["xmly"].ToString() != "1" && int.Parse(Longorder.Rows[i]["xmid"].ToString()) <= 0))
                {

                    if (!(selrow.Length <= 0 || int.Parse(Longorder.Rows[i]["xmid"].ToString()) <= 0))
                    {
                        try
                        {
                           
                            hisrow["MNGTYPE"] = Longorder.Rows[i]["mngtype"].ToString();
                            hisrow["ntype"] = selrow[0]["type"];
                            hisrow["ORDER_DOC"] = FrmMdiMain.CurrentUser.EmployeeId;
                            hisrow["HOITEM_ID"] = selrow[0]["order_id"];
                            hisrow["ITEM_CODE"] = selrow[0]["order_id"];
                            hisrow["XMLY"] = selrow[0]["XMLY"];

                            hisrow["ORDER_CONTEXT"] = selrow[0]["医嘱内容"];
                            hisrow["NUM"] = Longorder.Rows[i]["jl"];
                            hisrow["DOSAGE"] = 1;// Longorder.Rows[i]["js"];
                            hisrow["UNIT"] = Longorder.Rows[i]["jldw"].ToString().Trim();
                            hisrow["order_spec"] = selrow[0]["规格"];//Longorder.Rows[i]["order_spec"];
                            hisrow["ORDER_USAGE"] = Longorder.Rows[i]["yf"];
                            hisrow["FREQUENCY"] = Longorder.Rows[i]["pc"];
                            hisrow["OPERATOR"] = FrmMdiMain.CurrentUser.EmployeeId;
                            hisrow["STATUS_FLAG"] = 0;
                            hisrow["BABY_ID"] = 0;
                            hisrow["DEPT_BR"] = dept_br;
                            hisrow["EXEC_DEPT"] = selrow[0]["DEFAULT_DEPT"];
                            hisrow["DROPSPER"] = "";//嘱托
                            hisrow["SERIAL_NO"] = 1; //Longorder.Rows[i]["sort"].ToString();
                            hisrow["unit"] = Longorder.Rows[i]["jldw"].ToString();//selrow[0]["单位"].ToString().Trim();

                            hisrow["FIRST_TIMES"] = PublicFunction.GetFirsttimes(Longorder.Rows[i]["pc"].ToString(), tempDate);

                            hisrow["ps_flag"] = selrow[0]["psyp"];
                            hisrow["dwlx"] = "1";
                            //hisrow["FIRST_TIMES"]=GetFirsttimes(Longorder.Rows[i]["pc"].ToString(),tempDate);
                            PATH_STEP_ITEM_ID = Guid.Empty.ToString();// PATH_STEP_ITEM_ID

                            if (hisrow["ntype"].ToString() == "5")
                            {
                                hisrow["dwlx"] = Convert.ToInt16(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select bbid from jc_assay where yzid=" + selrow[0]["order_id"].ToString()), "0"));
                            }
                        }
                        catch(Exception ex)
                        {
                            throw new Exception("zhelicuo 11" + ex.Message);
                        }

                    }
                    else//说明医嘱
                    {

                        hisrow["MNGTYPE"] = Longorder.Rows[i]["mngtype"].ToString();
                        hisrow["ntype"] = 7;
                        hisrow["ORDER_DOC"] = FrmMdiMain.CurrentUser.EmployeeId;
                        hisrow["HOITEM_ID"] = -1;
                        hisrow["ITEM_CODE"] = -1;
                        hisrow["XMLY"] = 2;
                        hisrow["ORDER_CONTEXT"] = Longorder.Rows[i]["content"];
                        hisrow["NUM"] = Longorder.Rows[i]["jl"];
                        hisrow["DOSAGE"] = 1;// Longorder.Rows[i]["js"];
                        hisrow["UNIT"] = Longorder.Rows[i]["jldw"].ToString().Trim();
                        hisrow["order_spec"] = selrow[0]["规格"];// Longorder.Rows[i]["order_spec"];
                        hisrow["ORDER_USAGE"] = Longorder.Rows[i]["yf"];
                        hisrow["FREQUENCY"] = Longorder.Rows[i]["pc"];
                        hisrow["OPERATOR"] = FrmMdiMain.CurrentUser.EmployeeId;
                        hisrow["STATUS_FLAG"] = 0;
                        hisrow["BABY_ID"] = 0;
                        hisrow["DEPT_BR"] = dept_br;
                        hisrow["EXEC_DEPT"] = FrmMdiMain.CurrentDept.DeptId;
                        hisrow["DROPSPER"] = "";//嘱托
                        hisrow["SERIAL_NO"] = 1; //Longorder.Rows[i]["sort"].ToString();
                        hisrow["unit"] = Longorder.Rows[i]["jldw"].ToString();//selrow[0]["单位"].ToString().Trim();
                        hisrow["FIRST_TIMES"] =PublicFunction.GetFirsttimes(Longorder.Rows[i]["pc"].ToString(), tempDate);
                        hisrow["ps_flag"] = -1;
                        hisrow["dwlx"] = Longorder.Rows[i]["dwlx"].ToString();
                        //hisrow["FIRST_TIMES"]=GetFirsttimes(Longorder.Rows[i]["pc"].ToString(),tempDate);
                        PATH_STEP_ITEM_ID = Guid.Empty.ToString();// PATH_STEP_ITEM_ID

                    }
                   
                    if (Longorder.Rows[i]["mngtype"].ToString() != "0")
                    {
                        try
                        {
                            //临时医嘱
                            hisrow["FIRST_TIMES"] = 1;
                            hisrow["ts"] = 1;
                            hisrow["zsldw"] = Longorder.Rows[i]["jldw"].ToString();//总数量单位 就是剂量单位
                            //if (selrow == null || selrow.Length == 0)
                            //    hisrow["zsldw"] = Longorder.Rows[i]["jldw"].ToString();
                            //else
                            //    hisrow["zsldw"] = selrow[0]["单位"].ToString().Trim();
                            hisrow["zsl"] = decimal.Parse(hisrow["num"].ToString()) *PublicFunction.GetPc(Longorder.Rows[i]["pc"].ToString().Trim());
                        }
                        catch
                        {
                            throw new Exception("这里出错");
                        }
                    }
                    else
                    {
                        hisrow["zsl"] = 0;
                        hisrow["ts"] = 1;
                    }
                    try
                    {
                        //判断是否计费
                        if (oldmngtyype.Trim().Substring(1, 1) == "0")//表示不计费
                        {
                            hisrow["cjid"] = -1;
                            hisrow["hoitem_id"] = -1;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(Longorder.Rows[i]["mngtype"].ToString().Trim()+"自复选"); }
                }
                else
                {
                    string ss = Longorder.Rows[i]["xmid"].ToString();
                    if (Longorder.Rows[i]["xmly"].ToString() == "1")
                        strmsg += "药品医嘱名称【" + Longorder.Rows[i]["content"].ToString() + "】cjid 为【" + Longorder.Rows[i]["xmid"].ToString() + "】已经停用，可能需要重新选择药房\n";
                    else
                        strmsg += "项目医嘱名称【" + Longorder.Rows[i]["content"].ToString() + "】order_id为【" + Longorder.Rows[i]["xmid"].ToString() + "】已经停用，可能需要重新选择药房\n";
                    Arcfxh.Add(Longorder.Rows[i]["fzxh"].ToString());
                    continue;
                }
           
                if (i == 0)
                {
                    temgroup++;
                    oldgroupid = Longorder.Rows[i]["fzxh"].ToString();
                    SERIAL_NO = 0;
                }
                else
                {
                    //如果不等于上 Oldgroupid 组号
                    if (oldgroupid != Longorder.Rows[i]["fzxh"].ToString())
                    {
                        oldgroupid = Longorder.Rows[i]["fzxh"].ToString();
                        SERIAL_NO = 0;
                        temgroup++;
                    }
                    else
                    {
                        SERIAL_NO++;
                        //temgroup++;
                    }
                }

                hisrow["SERIAL_NO"] = SERIAL_NO;
                //hisrow["FLAG"] = 1;
                path_itemexe_id = Guid.NewGuid();//项目执行id
                short ps_flag = -1;
                Guid psorderid = Guid.NewGuid();
                if (selrow.Length == 0 || selrow[0]["psyp"].ToString() != "1")
                    psorderid = Guid.Empty;
                if (selrow.Length == 0 || selrow[0]["psyp"].ToString() == "1")
                    ps_flag = 0;
                decimal price = 0;
                try
                {
                    price = decimal.Parse(Longorder.Rows[i]["price"].ToString());
                }
                catch { }
                //第二步
                CommitOrderrecord(Guid.Empty, 0, new Guid(inpatient_id), FrmMdiMain.CurrentDept.DeptId, ward_id, int.Parse(hisrow["mngtype"].ToString())
                     , int.Parse(hisrow["ntype"].ToString()), long.Parse(hisrow["order_doc"].ToString()), int.Parse(hisrow["hoitem_id"].ToString()), hisrow["item_code"].ToString()
                     , int.Parse(hisrow["xmly"].ToString()), hisrow["ORDER_CONTEXT"].ToString(), decimal.Parse(hisrow["num"].ToString()), decimal.Parse(hisrow["DOSAGE"].ToString()), hisrow["unit"].ToString(), hisrow["order_spec"].ToString(), tempDate, tempDate, int.Parse(hisrow["FIRST_TIMES"].ToString())
                     , hisrow["ORDER_USAGE"].ToString(), hisrow["FREQUENCY"].ToString(), FrmMdiMain.CurrentUser.EmployeeId, 0, int.Parse(hisrow["STATUS_FLAG"].ToString()), int.Parse(bayby_id), int.Parse(dept_br), int.Parse(hisrow["EXEC_DEPT"].ToString()), hisrow["DROPSPER"].ToString(),
                     int.Parse(hisrow["SERIAL_NO"].ToString()), short.Parse(ps_flag.ToString()), psorderid, short.Parse(hisrow["dwlx"].ToString()), 0, temgroup, 2, "", FrmMdiMain.Jgbm, 0, Guid.Empty, 0, -1, 1, decimal.Parse(hisrow["zsl"].ToString()), hisrow["zsldw"].ToString(), hisrow["dwlx"].ToString(), pathway_id, PATHWAY_EXE_ID,
                     PATH_STEP_ITEM_ID, PATH_STEP_ID, path_itemexe_id.ToString(), EXE_STEP_ID, price);

                 
                //皮试药品
                if (selrow.Length > 0 && selrow[0]["psyp"].ToString() == "1")
                {

                    path_itemexe_idarr.Add(path_itemexe_id);
                    psorderidarr.Add(psorderid);//保存皮试id

                    long groupid =PublicFunction.GetYzNum(new Guid(inpatient_id), 0);
                    string sql = "insert into zy_orderrecord(order_id ,GROUP_ID,INPATIENT_ID,DEPT_ID ,WARD_ID,MNGTYPE, NTYPE , ORDER_DOC,HOITEM_ID,ITEM_CODE,ORDER_CONTEXT,NUM ,DOSAGE,"
+ " UNIT ,order_SPEC,BOOK_DATE ,ORDER_BDATE ,FIRST_TIMES , ORDER_USAGE ,FREQUENCY ,OPERATOR ,DELETE_BIT, STATUS_FLAG ,BABY_ID,"
+ " DEPT_BR , EXEC_DEPT , DROPSPER ,SERIAL_NO ,PS_FLAG ,PS_ORDERID ,DWLX,JZ_flag,xmly ,jgbm) ";
                    sql += " values (newid()," + groupid + ",'" + inpatient_id + "'," + FrmMdiMain.CurrentDept.DeptId + ",'" + (ward_id == "" ? "0" : ward_id) + "',1," + hisrow["ntype"].ToString() + "," + FrmMdiMain.CurrentUser.EmployeeId + ",-1,-1,'" + hisrow["ORDER_CONTEXT"].ToString() + "',0,1 ,"
                  + "'','',getdate(),'" + tempDate + "',0,'皮试',' '," + FrmMdiMain.CurrentUser.EmployeeId + ",0,0,0,"
                  + dept_br + "," + FrmMdiMain.CurrentDept.DeptId.ToString() + ",'',1,0,'" + psorderid + "',1,0,2," + FrmMdiMain.Jgbm + ")";
                    // MessageBox.Show(sql);
                    int j = FrmMdiMain.Database.DoCommand(sql);
                }
            }
            #endregion
            if (strmsg.Trim() != "")
            {
                if (Longorder.Rows[0]["mngtype"].ToString() != "0")
                    //MessageBox.Show(strmsg + "\n本次所有临时医嘱发送失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sslog = strmsg + "\n本次所有临时医嘱发送失败！";
                else
                    // MessageBox.Show(strmsg + "\n本次所有长期医嘱发送失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sslog = strmsg + "\n本次所有长期医嘱发送失败！\n\n";
                return;
            }

            #region 第三步
            // if (flag == 3)
            {
                CommitOrderrecord(Guid.Empty, 0, new Guid(inpatient_id), 0, "", 0, 0, 0, 0, "", 1, "", 0, 0, "", "", tempDate, tempDate, 0, "", "", 0, 0, 0, 0, 0, 0, "", 0, -1, Guid.Empty, 0, 0, 0, 3, "", FrmMdiMain.Jgbm, 0, Guid.Empty, 0, -1,
                   1, 0, "", "1", Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), 0);

                for (int x = 0; x < psorderidarr.Count; x++)
                {
                    // decimal strDate = Convert.ToDecimal(System.DateTime.Now.ToString("yyyyMMddHHmmss.ffffff"));
                    string updatesql = " update zy_orderrecord   set  ps_orderid ='" + psorderidarr[x].ToString() + "'  where order_id in (select order_id from path_itemexe where path_itemexe_id='" + path_itemexe_idarr[x].ToString() + "') ";
                    int j = FrmMdiMain.Database.DoCommand(updatesql);
                    if (j == 0)
                    {
                        throw new Exception("系统自动生成皮试医嘱失败");
                    }
                }
            }
            #endregion

        }
        private static string CommitOrderrecord(Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
          long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
          DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
          long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
          int ts, decimal zsl, string zsldw, string jldwlx, string path_id, string PATHWAY_EXE_ID, string PATH_STEP_ITEM_ID, string PATH_STEP_ID, string path_itemexe_id, string EXE_STEP_ID, decimal price)
        {
            RelationalDatabase _Database = FrmMdiMain.Database;
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("项目来源必须等于1、2、3，请检查！");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_path_ORDERCOMMIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 区分本次申请产生的医嘱
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 合理用药警示灯
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 临时医嘱改造，增加天数，总用量
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));

                cmd.Parameters.Add(_Database.GetParameter("@path_id", new Guid(path_id)));
                cmd.Parameters.Add(_Database.GetParameter("@PATHWAY_EXE_ID", new Guid(PATHWAY_EXE_ID)));
                cmd.Parameters.Add(_Database.GetParameter("@PATH_STEP_ITEM_ID", new Guid(PATH_STEP_ITEM_ID)));
                cmd.Parameters.Add(_Database.GetParameter("@PATH_STEP_ID", new Guid(PATH_STEP_ID)));
                cmd.Parameters.Add(_Database.GetParameter("@path_itemexe_id", new Guid(path_itemexe_id)));
                cmd.Parameters.Add(_Database.GetParameter("@EXE_STEP_ID", new Guid(EXE_STEP_ID)));
                cmd.Parameters.Add(_Database.GetParameter("@price", price));

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = FrmMdiMain.Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message+"插入临时表");
                return "错误";
            }
        }
        private static DataTable GetTable(string strxml)
        {
            DataTable tb = new DataTable();
            try
            {
                string nodename = "ITEM";
                //string srrxml = "<?xml version='1.0' encoding='utf-8' ?><GROUP><ITEM Id='唯一号' ORDER_ID='医嘱序号' GROUP_ID='分组号' ADVICE_CODE='医嘱号' ADVICE_NAME_A='医嘱的通用名' ADVICE_NAME_O='医嘱的商品名' ADVICE_PY='医嘱拼音码' ADVICE_WB='医嘱五笔码' NATIVE_CODE='药品的产地编码' NATIVE_NAME='药品的产地名' ADVICE_TYPE_CODE='1药品2非药品3检验4检查' ADVICE_TYPE_NAME='项目类别（中药、西药、成药、处置、护理、卫材，检验，检查）' USAGE_TYPE_CODE='用法类别编码' USAGE_TYPE_NAME='用法类别' PURVIEW_TYPE_CODE='药品权限分类号' PURVIEW_TYPE_NAME='药品权限分类' ST_FLAG='是否皮试医嘱（0表示不是皮试，1表示是）' BASE_DOSE_VALUE='药品基本剂量' BASE_DOSE_UNITCODE='药品基本剂量单位编码' BASE_DOSE_UNITNAME='药品基本剂量单位' MIN_DOSE_UNITCODE='最小开立单位编码' MIN_DOSE_UNITNAME='最小开立单位' PRICE_DOSE_VALUE='价格' PRICE_DOSE_UNITCODE='计价单位编码' PRICE_DOSE_UNITNAME='计价单位' PRICE_DOSE_PACK_QUANTITY='计价数量' PRICE_DOSE_SPECS='计价规格' EXEC_OFFICE_CODE='执行科室编码' EXEC_OFFICE_NAME='执行科室' KV_INFO='扩展信息' FREQ_CODE='频次编码' FREQ_NAME='频次信息' FREQ_REMARK='频次说明' USAGE_CODE='用法编码' USAGE_NAME='用法（给药途径）' CREATE_WORKER_NAME='开立医生' CREATE_DATE='开立时间' BEGIN_DATE='医嘱开立时间' DC_WORKER_ID='停止医生工号' DC_WORKER_NAME='停止医生' DC_DATE='停止时间' DC_FLAG='未停止、已停止' DC_REASON_CODE='停止原因编码' DC_REASON_INFO='停止原因' HIS_FLAG='接口标识：0开立 1HIS导入成功 2HIS导入失败' CHECK_FLAG='成功、失败：原因'> </ITEM></GROUP>";
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(strxml);
                XmlNode xl1 = xml.SelectSingleNode("GROUP");// SelectSingleNode(nodename);//( SelectSingleNode(nodename).ChildNodes;
                //XmlNodeList xllist = xml.SelectSingleNode("Request").ChildNodes; ;
              

                //创建内存表
                foreach (XmlNode xn in xl1)
                {
                    if (xn.Name == nodename)
                    {
                        // xn.Attributes[0] 
                        //xn.InnerText=
                        XmlElement xe2 = (XmlElement)xn;
                        //xe2.InnerText
                        // xe1.InnerText
                        for (int i = 0; i < xn.Attributes.Count; i++)
                        {
                            tb.Columns.Add(xn.Attributes[i].Name.ToString(), typeof(System.String));
                        }
                        //foreach (XmlNode subxn in xn.Attributes)
                        //{
                        //    XmlElement xe1 = (XmlElement)subxn;
                        //    tb.Columns.Add(xe1.Name, typeof(System.String));
                        //}
                        break;
                    }

                }
                foreach (XmlNode xn in xl1)
                {
                    if (xn.Name == nodename)
                    {
                        DataRow row = tb.NewRow();
                        for (int i = 0; i < xn.Attributes.Count; i++)
                        {
                            //tb.Columns.Add(xn.Attributes[i].Name.ToString(), typeof(System.String));
                            // XmlElement xe1 = (XmlElement)subxn;
                            row[xn.Attributes[i].Name.ToString()] = xn.Attributes[i].Value.ToString();
                        }
                        //foreach (XmlNode subxn in xn)
                        //{
                        //    XmlElement xe1 = (XmlElement)subxn;
                        //    row[xe1.Name] = xe1.InnerText;
                        //}
                        tb.Rows.Add(row);
                    }
                }
                tb.TableName = "dd";
                // tb.WriteXml("d:\\test.xml");
            }
            catch {
                return null;
            }
            return tb;
        }
    }
}
