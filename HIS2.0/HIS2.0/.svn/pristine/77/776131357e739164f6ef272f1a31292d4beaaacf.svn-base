using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using System.Windows.Forms;
using YpClass;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_yf_cx
{
    public class PubClass
    {

        public PubClass()
        {
        }

        public static void PrintCf(string inpatient_id, string mngtype, string groupid, RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            string ssql = "select top 1  presc_no,execdept_id,cz_flag from zy_orderrecord a,zy_fee_speci b " +
            " where a.inpatient_id=b.inpatient_id and  a.order_id=b.order_id and a.inpatient_id='" + inpatient_id +
                "' and (mngtype=" + mngtype + " or mngtype=5 ) and a.group_id=" + groupid + "  and cz_flag in(0,1) order by cz_flag ";
            DataTable tbcx = _DataBase.GetDataTable(ssql, 30);
            decimal cfh = 0;
            int zxks = 0;
            int cz_flag = 0;
            if (tbcx.Rows.Count > 0)
            {

                cfh = Convert.ToDecimal(tbcx.Rows[0]["presc_no"].ToString());
                zxks = Convert.ToInt32(tbcx.Rows[0]["execdept_id"].ToString());
                cz_flag = Convert.ToInt32(tbcx.Rows[0]["cz_flag"].ToString());
                if (cz_flag == 1)
                {
                    MessageBox.Show("该处方已冲正,不能打印", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("请确认处方已执行", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cfh == 0) return;

            tb = ZY_FY.SelectCF("0", new Guid(inpatient_id), "", "", "", "", "", "", "0", 0, 0, 0, cfh, _DataBase, 2);
            if (tb.Rows.Count == 0)
                tb = ZY_FY.SelectCF("0", new Guid(inpatient_id), "", "", "", "", "", "", "1", 0, 0, 0, cfh, _DataBase, 2);



            if (new SystemCfg(8021).Config == "0")
            {
                #region 不区分中药
                try
                {
                    if (tb.Rows.Count == 0) return;

                    DataRow[] rows;
                    rows = tb.Select("ypsl<>0");

                    ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                    DataRow myrow;
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        myrow = Dset.发药明细单.NewRow();
                        myrow["rowno"] = Convert.ToString(rows[i]["序号"]);
                        myrow["yppm"] = Convert.ToString(rows[i]["品名"]);
                        myrow["ypspm"] = Convert.ToString(rows[i]["商品名"]);
                        myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                        myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                        myrow["lsj"] = Convert.ToDecimal(rows[i]["单价"]);
                        myrow["ypsl"] = Convert.ToDecimal(rows[i]["数量"]);
                        if (Convert.ToDecimal(rows[i]["剂数"]) > 1 || Convert.ToString(rows[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                            myrow["cfts"] = "剂数:" + rows[i]["剂数"].ToString() + " 剂   " + rows[i]["煎药"].ToString();
                        myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                        myrow["lsje"] = Convert.ToDecimal(rows[i]["金额"]);
                        myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                        myrow["bed_no"] = Convert.ToString(rows[i]["床号"]);
                        myrow["name"] = Convert.ToString(rows[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows[i]["处方日期"]).Trim();
                        myrow["inpatient_no"] = Convert.ToString(rows[i]["住院号"]);
                        myrow["lydw"] = Convert.ToString(rows[i]["发药科室"]) + "  医生:" + Convert.ToString(rows[i]["医生"]);
                        myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows[i]["dept_id"]), _DataBase);
                        myrow["presc_no"] = rows[i]["处方号"].ToString().Trim();
                        myrow["order_usage"] = rows[i]["用法"].ToString().Trim() + " " + rows[i]["频次"].ToString().Trim();
                        myrow["xb"] = Convert.ToString(rows[i]["性别"]);
                        myrow["nl"] = Convert.ToString(rows[i]["年龄"]);

                        myrow["JTDZ"] = "";
                        myrow["LXDH"] = "";
                        myrow["SFZH"] = "";
                        myrow["bz1"] = Convert.ToString(rows[i]["诊断"]);
                        myrow["bz2"] = Convert.ToString(rows[i]["中医诊断"]);
                        myrow["bz3"] = Convert.ToString(rows[i]["中医症型"]);

                        Dset.发药明细单.Rows.Add(myrow);
                    }

                    ParameterEx[] parameters = new ParameterEx[2];
                    parameters[0].Text = "titletext";
                    string ss = "";
                    //if (chkcydy.Checked == false)
                    ss = "住院处方清单";
                    // else
                    //    ss = "出院带药清单";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + Yp.SeekDeptName(zxks, _DataBase) + ")" + ss.Trim();
                    parameters[1].Text = "BZ";
                    parameters[1].Value = "";
                    bool bview = false;
                    TrasenFrame.Forms.FrmReportView f;
                    f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单医生站用.rpt", parameters, bview);
                    if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }

            else
            {
                try
                {


                    DataRow[] rows;
                    rows = tb.Select(" ypsl<>0");


                    DataRow[] rows_xy = null;
                    DataRow[] rows_zy = null;

                    rows_xy = tb.Select(" STATITEM_CODE not like '%03%' ");
                    rows_zy = tb.Select(" STATITEM_CODE like '%03%' ");



                    ts_Yk_ReportView.Dataset2 Dset;
                    DataRow myrow;

                    if (rows_xy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_xy.Length - 1; i++)
                        {
                            myrow = Dset.发药明细单.NewRow();
                            myrow["rowno"] = Convert.ToString(rows_xy[i]["序号"]);
                            myrow["yppm"] = Convert.ToString(rows_xy[i]["品名"]);
                            myrow["ypspm"] = Convert.ToString(rows_xy[i]["商品名"]);
                            myrow["ypgg"] = Convert.ToString(rows_xy[i]["规格"]);
                            myrow["sccj"] = Convert.ToString(rows_xy[i]["厂家"]);
                            myrow["lsj"] = Convert.ToDecimal(rows_xy[i]["单价"]);
                            myrow["ypsl"] = Convert.ToDecimal(rows_xy[i]["数量"]);
                            if (Convert.ToDecimal(rows_xy[i]["剂数"]) > 1 || Convert.ToString(rows_xy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                myrow["cfts"] = "剂数:" + rows_xy[i]["剂数"].ToString() + " 剂   " + rows_xy[i]["煎药"].ToString();
                            myrow["ypdw"] = Convert.ToString(rows_xy[i]["单位"]);
                            myrow["lsje"] = Convert.ToDecimal(rows_xy[i]["金额"]);
                            myrow["shh"] = Convert.ToString(rows_xy[i]["货号"]);
                            myrow["bed_no"] = Convert.ToString(rows_xy[i]["床号"]);
                            myrow["name"] = Convert.ToString(rows_xy[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows_xy[i]["处方日期"]).Trim();
                            myrow["inpatient_no"] = Convert.ToString(rows_xy[i]["住院号"]);
                            myrow["lydw"] = Convert.ToString(rows_xy[i]["发药科室"]) + "  医生:" + Convert.ToString(rows_xy[i]["医生"]);
                            myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_xy[i]["dept_id"]), _DataBase);
                            myrow["presc_no"] = rows_xy[i]["处方号"].ToString().Trim();
                            myrow["order_usage"] = rows_xy[i]["用法"].ToString().Trim() + " " + rows_xy[i]["频次"].ToString().Trim();
                            myrow["xb"] = Convert.ToString(rows_xy[i]["性别"]);
                            myrow["nl"] = Convert.ToString(rows_xy[i]["年龄"]);

                            myrow["JTDZ"] = "";
                            myrow["LXDH"] = "";
                            myrow["SFZH"] = "";
                            myrow["bz1"] = Convert.ToString(rows_xy[i]["诊断"]);
                            myrow["bz2"] = Convert.ToString(rows_xy[i]["中医诊断"]);
                            myrow["bz3"] = Convert.ToString(rows_xy[i]["中医症型"]);

                            Dset.发药明细单.Rows.Add(myrow);
                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        //if (chkcydy.Checked == false)
                        ss = "住院处方清单";
                        //else
                        //    ss = "出院带药清单";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + Yp.SeekDeptName(zxks, _DataBase) + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = false;
                        TrasenFrame.Forms.FrmReportView f;

                        f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单医生站用.rpt", parameters, bview);
                        if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                    }

                    if (rows_zy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_zy.Length - 1; i++)
                        {
                            myrow = Dset.发药明细单.NewRow();
                            myrow["rowno"] = Convert.ToString(rows_zy[i]["序号"]);
                            myrow["yppm"] = Convert.ToString(rows_zy[i]["品名"]);
                            myrow["ypspm"] = Convert.ToString(rows_zy[i]["商品名"]);
                            myrow["ypgg"] = Convert.ToString(rows_zy[i]["规格"]);
                            myrow["sccj"] = Convert.ToString(rows_zy[i]["厂家"]);
                            myrow["lsj"] = Convert.ToDecimal(rows_zy[i]["单价"]);
                            myrow["ypsl"] = Convert.ToDecimal(rows_zy[i]["数量"]);
                            if (Convert.ToDecimal(rows_zy[i]["剂数"]) > 1 || Convert.ToString(rows_zy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                myrow["cfts"] = "剂数:" + rows_zy[i]["剂数"].ToString() + " 剂   " + rows_zy[i]["煎药"].ToString();
                            myrow["ypdw"] = Convert.ToString(rows_zy[i]["单位"]);
                            myrow["lsje"] = Convert.ToDecimal(rows_zy[i]["金额"]);
                            myrow["shh"] = Convert.ToString(rows_zy[i]["货号"]);
                            myrow["bed_no"] = Convert.ToString(rows_zy[i]["床号"]);
                            myrow["name"] = Convert.ToString(rows_zy[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows_zy[i]["处方日期"]).Trim();
                            myrow["inpatient_no"] = Convert.ToString(rows_zy[i]["住院号"]);
                            myrow["lydw"] = Convert.ToString(rows_zy[i]["发药科室"]) + "  医生:" + Convert.ToString(rows_zy[i]["医生"]);
                            myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_zy[i]["dept_id"]), _DataBase);
                            myrow["presc_no"] = rows_zy[i]["处方号"].ToString().Trim();
                            myrow["order_usage"] = rows_zy[i]["用法"].ToString().Trim() + " " + rows_zy[i]["频次"].ToString().Trim();
                            myrow["xb"] = Convert.ToString(rows_zy[i]["性别"]);
                            myrow["nl"] = Convert.ToString(rows_zy[i]["年龄"]);

                            myrow["JTDZ"] = "";
                            myrow["LXDH"] = "";
                            myrow["SFZH"] = "";
                            myrow["bz1"] = Convert.ToString(rows_zy[i]["诊断"]);
                            myrow["bz2"] = Convert.ToString(rows_zy[i]["中医诊断"]);
                            myrow["bz3"] = Convert.ToString(rows_zy[i]["中医症型"]);
                            Dset.发药明细单.Rows.Add(myrow);
                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        //if (chkcydy.Checked == false)
                        ss = "住院处方清单";
                        //else
                        //    ss = "出院带药清单";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + Yp.SeekDeptName(zxks, _DataBase) + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = false;
                        TrasenFrame.Forms.FrmReportView f;

                        f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单(中药)医生站用.rpt", parameters, bview);
                        if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                    }

                }
                catch (System.Exception err)
                {

                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static ColumnDefine NewColumnDefine(string headerText, string mappinName, int colWidth, bool colReadonly, int colBoolButton)
        {
            ColumnDefine define = new ColumnDefine();
            define.HeaderText = headerText;
            define.MappingName = mappinName;
            define.ColWidth = colWidth;
            define.ColReadOnly = colReadonly;
            define.ColBoolButton = colBoolButton;
            return define;
        }

    }

    public struct ColumnDefine
    {
        public string HeaderText;
        public string MappingName;
        public int ColWidth;
        public bool ColReadOnly;
        public int ColBoolButton;
    }
}
