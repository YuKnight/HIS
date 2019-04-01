using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mzys_class;
using TrasenClasses.GeneralClasses;
using ts_mzys_blcflr;
using TrasenFrame.Classes;

namespace ts_mz_sf
{
    public partial class Frm_SFMb_Select : Form
    {
        private string Fun_mbtype = ""; //模板类型
        private DataTable dt_cf = new DataTable();
        public DataTable dt_mbmx = new DataTable();
        public bool isff_check = false;
        public Frm_SFMb_Select(DataTable dt)
        {
            InitializeComponent();
            dt_cf = dt;
            rdomb_gr.Checked = true;
            Select_Mb();
        }
        //常用模板 
        private void Select_Mb()
        {
            try
            {
                treeView1.Nodes.Clear();
                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                int mbjb = -1;
                if (rdomb_gr.Checked == true) mbjb = 2;
                //add by jiangzf 20140410
                SystemCfg cfg3096 = new SystemCfg(3096);
                if (cfg3096.Config.Trim() == "1")
                    mbjb = 0;
                Fun_mbtype = "Fun_ts_mzys_blcflr_grmb";
                DataTable tb = mzys.Select_Mb(InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, mbjb, InstanceForm.BDatabase);
                TreeNode tn = new TreeNode();
                tn.Text = "全部分类";
                tn.Tag = Guid.Empty.ToString();
                tn.ToolTipText = "1";
                tn.ImageIndex = 0;
                bool bol = tn.IsExpanded;
                tn.Expand();
                this.treeView1.ImageList = this.imageList3;
                AddTreeMbfl(tb, tn, Guid.Empty);
                treeView1.Nodes.Add(tn);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //加载模板分类子项
        public static void AddTreeMbfl(DataTable tb, TreeNode treeNode, Guid fid)
        {
            treeNode.Nodes.Clear();
            bool bol = treeNode.IsExpanded;
            DataRow[] rows = tb.Select(" fid='" + fid + "'");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                TreeNode Cnode = treeNode.Nodes.Add(rows[i]["模板名称"].ToString());
                Cnode.Tag = "" + (Guid)(rows[i]["mbid"]) + " ";
                Cnode.ToolTipText = rows[i]["BTree"].ToString();
                if (rows[i]["BTree"].ToString() == "1") Cnode.ImageIndex = 0; else Cnode.ImageIndex = 1;
                Cnode.Expand();
                AddTreeMbfl(tb, Cnode, (Guid)rows[i]["mbid"]);
            }
        }

        private void rdomb_all_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Control ctr=(Control)sender;
                switch (ctr.Name)
                {
                
                    case "rdomb_yj":
                        Fun_mbtype = "Fun_ts_mzys_blcflr_yjmb";
                        break;
                    case "rdomb_kj":
                        Fun_mbtype = "Fun_ts_mzys_blcflr_kjmb";
                        break;
                    case "rdomb_gr":
                        Fun_mbtype = "Fun_ts_mzys_blcflr_grmb";
                        break;
                    default:
                           Fun_mbtype = "Fun_ts_mzys_blcflr";
                           break;
                }
                Select_Mb();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.ToolTipText.ToString() == "1")
                    return;
 
                string mbmc = e.Node.Text;
                string mbxh = e.Node.Tag.ToString();
                Guid mbid = new Guid(Convertor.IsNull(mbxh, Guid.Empty.ToString()));
                dt_mbmx = AddMbmx(mbid, mbmc, dt_cf);
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //模板明细的加载 划价收费界面调用 Add by zp 2013-11-20
        public DataTable AddMbmx(Guid mbid, string mbmc,DataTable tb)
        {
            DataTable tab = null;
            try
            {        
                //DataTable tb = (DataTable)dataGridView1.DataSource;
                
                //if (_menuTag.Function_Name == "Fun_ts_mzys_blcflr" || _menuTag.Function_Name == "Fun_ts_mzys_blcflr_wtsq" || _menuTag.Function_Name == "Fun_ts_zyys_blcflr")
                //{
                    //if (Dqcf.jzid == Guid.Empty) { MessageBox.Show("请选择相应的病人", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                ts_mzys_blcflr.InstanceForm.BDatabase = InstanceForm.BDatabase;
                ts_mzys_blcflr.InstanceForm.IsSfy = true;
                    FrmSelectMb frmmb = new FrmSelectMb(mbid);
                    frmmb.ShowDialog();
                    tab = frmmb.tb;
                    isff_check = frmmb.check;//true合并处方 false不合并处方
                    return tab;
                    //if (tab == null) return;
                //}
         
                //butnew_Click(null, null);
                /*****************************************在处方明细表中通过处方序号得到处方头表******************************************************/
                /*
                string[] GroupbyField = { "CFXH" };
                string[] ComputeField = { };
                string[] CField = { };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tab;
                DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "序号<>'小计'");//处方头表

                int nrow = 0;
                //add by zouchihua 2013-7-11 获得改科室对应的门诊药房
                string mzyf = "select drugstore_id,ksmc from   jc_dept_drugstore a join YP_YJKS b on a.DRUGSTORE_ID=b.DEPTID  where delete_bit=0 and dept_id=" + InstanceForm.BCurrentDept.DeptId + " and  convert(nvarchar,getdate(),108)>=convert(nvarchar,a.kssj,108)  "
                      + "  and convert(nvarchar,getdate(),108)<=convert(nvarchar,a.jssj,108) and  KSLX2='门诊药房'";
                DataTable tbmzyf = InstanceForm.BDatabase.GetDataTable(mzyf);
                //循环处方
                for (int x = 0; x <= tbcf.Rows.Count - 1; x++)
                {
                    DataRow[] rows_cf = tab.Select("CFXH='" + tbcf.Rows[x]["CFXH"].ToString().Trim() + "'"); //得到选中的处方明细

                    bool Badd = false;

                    #region 添加每个处方明细
                    bool b_ks = false;
                    decimal cfje = 0;
                    for (int i = 0; i <= rows_cf.Length - 1; i++)
                    {
                        if (Convertor.IsNull(rows_cf[i]["序号"], "").Trim() == "小计") //Add by zp 2013-10-22 出现小计行就continue 
                            continue;
                        nrow = cell.nrow;//获得当前的行下标
                        int xmly = Convert.ToInt32(rows_cf[i]["项目来源"]);
                        long xmid = Convert.ToInt64(rows_cf[i]["项目id"]);
                        int cjid = Convert.ToInt32(rows_cf[i]["cjid"]);
                        string zxksmc = Convertor.IsNull(rows_cf[i]["执行科室"], "");
                        int zxksid = Convert.ToInt32(rows_cf[i]["执行科室id"]);

                        DataRow[] rows = null;
                        if (xmly == 1)
                        {
                            #region 药品
                            int flagzd = 0;//找到
                            string where = "";
                            //add by zouchihua 2013-7-11 优先考虑门诊药房
                            if (rdomzyf.Checked && tbmzyf.Rows.Count > 0)
                            {
                                DataRow[] drmzyf = tbmzyf.Select("drugstore_id=" + zxksid + "");
                                #region//如果没有找到门诊药房，优先门诊
                                if (drmzyf.Length <= 0)
                                {

                                    for (int j = 0; j < tbmzyf.Rows.Count; j++)
                                    {
                                        zxksid = Convert.ToInt32(tbmzyf.Rows[j]["drugstore_id"]);
                                        where = "项目id=" + cjid + " AND 项目来源=" + xmly + " and zxksid=" + zxksid + "";
                                        rows = PubDset.Tables["ITEM"].Select(where, "zxksid");
                                        if (rows.Length == 0)
                                        {
                                            where = "ggid=" + xmid + " AND 项目来源=" + xmly + " and zxksid=" + zxksid + "";
                                            rows = PubDset.Tables["ITEM"].Select(where, "zxksid");

                                        }
                                        if (rows.Length == 0)
                                        {
                                            where = "项目id=" + cjid + " AND 项目来源=" + xmly + "";
                                            rows = PubDset.Tables["ITEM"].Select(where, "zxksid");

                                        }
                                        if (rows.Length == 0)
                                        {
                                            where = "ggid=" + xmid + " AND 项目来源=" + xmly + "";
                                            rows = PubDset.Tables["ITEM"].Select(where, "zxksid");

                                        }
                                        if (rows.Length > 0)
                                        {
                                            flagzd = 1;
                                            break;
                                        }
                                    }
                                }
                                #endregion
                            }

                            //如果还是没有找到就找原科室的
                            if (flagzd == 0)
                            {
                                #region 在原执行科室寻找指定的项目
                                zxksid = Convert.ToInt32(rows_cf[i]["执行科室id"]);
                                where = "项目id=" + cjid + " AND 项目来源=" + xmly + " and zxksid=" + zxksid + "";
                                rows = PubDset.Tables["ITEM"].Select(where, "zxksid");
                                if (rows.Length == 0)
                                {
                                    where = "ggid=" + xmid + " AND 项目来源=" + xmly + " and zxksid=" + zxksid + "";
                                    rows = PubDset.Tables["ITEM"].Select(where, "zxksid");

                                }
                                if (rows.Length == 0)
                                {
                                    where = "项目id=" + cjid + " AND 项目来源=" + xmly + "";
                                    rows = PubDset.Tables["ITEM"].Select(where, "zxksid");

                                }
                                if (rows.Length == 0)
                                {
                                    where = "ggid=" + xmid + " AND 项目来源=" + xmly + "";
                                    rows = PubDset.Tables["ITEM"].Select(where, "zxksid");

                                }
                                if (rows.Length == 0)
                                {
                                    string ss = "";
                                    Ypgg gg = new Ypgg(Convert.ToInt32(xmid.ToString()), InstanceForm.BDatabase);
                                    ss = "没有找到药品 [" + gg.YPPM + " " + gg.YPGG + " ] 可能没有库存或已停用";
                                    MessageBox.Show(ss, "导入模板", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if (tb.Rows.Count > 1 && tb.Rows[nrow]["项目id"].ToString() == "" && tb.Rows[nrow]["序号"].ToString() != "小计" && i == rows_cf.Length - 1 && i != 0)
                                        tb.Rows.Remove(tb.Rows[nrow]);
                                    continue;
                                }
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            #region 非药品
                            string where = "";
                            where = "yzid=" + xmid + " AND 项目来源=" + xmly + "  and zxksid=" + zxksid + "";
                            rows = PubDset.Tables["ITEM"].Select(where);
                            if (InstanceForm.IsSfy) //Modify by zp 2013-11-19 获取收费项目模板
                            {
                                where = "项目id=" + xmid + " AND 项目来源=" + xmly + " ";//and 执行科室id=" + zxksid + "";
                                rows = PubDset.Tables["ITEM_SF"].Select(where);
                            }
                            if (rows.Length == 0)
                            {
                                where = "yzid=" + xmid + " AND 项目来源=" + xmly + " ";
                                rows = PubDset.Tables["ITEM"].Select(where);
                            }
                            if (rows.Length == 0)
                            {
                                MessageBox.Show("没有找到" + rows_cf[i]["医嘱内容"].ToString() + ",可能已停用", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (tb.Rows.Count > 1 && tb.Rows[nrow]["项目id"].ToString() == "" && tb.Rows[nrow]["序号"].ToString() != "小计" && i == rows_cf.Length - 1 && i != 0)
                                    tb.Rows.Remove(tb.Rows[nrow]);
                                continue;
                            }
                            #endregion
                        }


                        if (rows.Length > 0) //如果查到了模板内的项目
                        {
                            int nrowX = nrow; //得到当前下标
                            Addrow(rows[0], ref nrow);
                            DataRow[] SelRow = tb.Select("项目id=" + rows[0]["项目id"].ToString() + " and 项目来源=" + rows[0]["项目来源"].ToString() + " and hjmxid='" + Guid.Empty.ToString() + "'");
                            if (SelRow.Length == 0) continue;
                            Badd = true;
                            SelRow[SelRow.Length - 1]["剂量"] = rows_cf[i]["剂量"];
                            SelRow[SelRow.Length - 1]["剂量单位"] = rows_cf[i]["剂量单位"];
                            SelRow[SelRow.Length - 1]["剂量单位id"] = rows_cf[i]["剂量单位id"];
                            SelRow[SelRow.Length - 1]["dwlx"] = rows_cf[i]["dwlx"];
                            SelRow[SelRow.Length - 1]["用法"] = rows_cf[i]["用法"];
                            SelRow[SelRow.Length - 1]["用法id"] = rows_cf[i]["用法id"];
                            SelRow[SelRow.Length - 1]["频次"] = rows_cf[i]["频次"];
                            SelRow[SelRow.Length - 1]["频次id"] = rows_cf[i]["频次id"];
                            SelRow[SelRow.Length - 1]["天数"] = rows_cf[i]["天数"];
                            SelRow[SelRow.Length - 1]["嘱托"] = rows_cf[i]["嘱托"];
                            SelRow[SelRow.Length - 1]["处方分组序号"] = rows_cf[i]["处方分组序号"];
                            if (check && cfg3039.Config == "1")
                            {
                                string[] GroupbyField1 = { "分方状态", "项目来源", "收费", "修改" };
                                string[] ComputeField1 = { };
                                string[] CField1 = { };
                                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                                xcset1.TsDataTable = tb;
                                DataTable wsfcftb1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "序号<>'小计'  and 项目来源=1 ");
                                DataRow[] wsfdr = wsfcftb1.Select("收费=0 and 修改=1");
                                //Add By Zj 2012-05-25
                                if (rows_cf[i]["统计大项目"] != SelRow[SelRow.Length - 1]["统计大项目"])
                                {
                                    if (rows_cf[i]["统计大项目"].ToString() == "01" || rows_cf[i]["统计大项目"].ToString() == "02")
                                    {
                                        if (SelRow[SelRow.Length - 1]["统计大项目"].ToString() != "01" && SelRow[SelRow.Length - 1]["统计大项目"].ToString() != "02")
                                        {
                                            SelRow[SelRow.Length - 1]["分方状态"] = rows_cf[i]["CFXH"];
                                        }
                                        else
                                        {
                                            SelRow[SelRow.Length - 1]["分方状态"] = wsfdr[0]["分方状态"];
                                        }
                                    }
                                    else if (rows_cf[i]["统计大项目"].ToString() == "03" && wsfdr[0]["统计大项目"].ToString() == "03")
                                    {
                                        SelRow[SelRow.Length - 1]["分方状态"] = wsfdr[0]["分方状态"];
                                        if (wsfdr[0]["分方状态"].ToString() != "")
                                            rows_cf[0]["CFXH"] = Convertor.IsNull(wsfdr[0]["分方状态"], "");

                                        SelRow[SelRow.Length - 1]["剂数"] = wsfdr[0]["剂数"];//Add By Zj 2012-04-10

                                    }
                                    else
                                    {
                                        SelRow[SelRow.Length - 1]["分方状态"] = rows_cf[i]["CFXH"];
                                    }
                                }
                                else
                                    SelRow[SelRow.Length - 1]["分方状态"] = wsfdr[0]["分方状态"];
                            }
                            else
                            {
                                if (cfg3048.Config == "0")//Add By Zj 2013-01-09 begin 
                                    SelRow[SelRow.Length - 1]["分方状态"] = rows_cf[i]["cfxh"].ToString();
                                else
                                {
                                    string sql = "select HYLXID from JC_ASSAY where YZID=" + SelRow[SelRow.Length - 1]["yzid"].ToString();
                                    SelRow[SelRow.Length - 1]["分方状态"] = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sql), "");
                                }
                                //Add By Zj 2013-01-09 end 
                                //SelRow[SelRow.Length - 1]["分方状态"] = rows_cf[i]["cfxh"].ToString(); Modify By ZJ 2013-01-09
                                SelRow[SelRow.Length - 1]["剂数"] = rows_cf[i]["剂数"].ToString();//Add By Zj 2012-04-10
                            }

                            SelRow[SelRow.Length - 1]["排序序号"] = rows_cf[i]["排序序号"];
                            SelRow[SelRow.Length - 1]["自备药"] = rows_cf[i]["自备药"];
                            //SelRow[SelRow.Length - 1]["分方状态"] = rows_cf[i]["cfxh"].ToString(); By Zj 2012-05-25

                            if (_menuTag.Function_Name == "Fun_ts_mzys_blcflr_grmb"
                                || _menuTag.Function_Name == "Fun_ts_mzys_blcflr_yjmb"
                                || _menuTag.Function_Name == "Fun_ts_mzys_blcflr_kjmb")
                                SelRow[SelRow.Length - 1]["hjid"] = rows_cf[i]["cfxh"];


                            if (rows_cf[i]["自备药"].ToString() == "1") SelRow[SelRow.Length - 1]["医嘱内容"] = SelRow[SelRow.Length - 1]["医嘱内容"] + " 【自备】";
                            if (rows_cf[i]["处方分组序号"].ToString() == "1") { b_ks = true; SelRow[SelRow.Length - 1]["医嘱内容"] = "┌" + SelRow[SelRow.Length - 1]["医嘱内容"].ToString(); }
                            if (rows_cf[i]["处方分组序号"].ToString() == "2" && b_ks == true) { SelRow[SelRow.Length - 1]["医嘱内容"] = "│" + SelRow[SelRow.Length - 1]["医嘱内容"].ToString(); }
                            if (rows_cf[i]["处方分组序号"].ToString() == "-1" && b_ks == true) { b_ks = false; SelRow[SelRow.Length - 1]["医嘱内容"] = "└" + SelRow[SelRow.Length - 1]["医嘱内容"].ToString(); }

                            bool bok = false;
                            Seek_Price(SelRow[SelRow.Length - 1], out bok);
                            cfje = cfje + Convert.ToDecimal(SelRow[SelRow.Length - 1]["金额"]);


                            if (i < rows_cf.Length - 1 && rows_cf[i]["项目id"].ToString() != "")
                            {
                                DataRow row = tb.NewRow();
                                tb.Rows[tb.Rows.Count - 1]["序号"] = "";
                                row["修改"] = true;
                                row["收费"] = false;

                                if (cfg3048.Config == "0")//Add By Zj 2013-01-09
                                    row["分方状态"] = rows_cf[i]["cfxh"].ToString();
                                else
                                {
                                    string sql = "select HYLXID from JC_ASSAY where YZID=" + SelRow[SelRow.Length - 1]["yzid"].ToString();
                                    row["分方状态"] = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sql), "");
                                }
                                tb.Rows.Add(row);
                                dataGridView1.DataSource = tb;
                                dataGridView1.CurrentCell = dataGridView1["医嘱内容", tb.Rows.Count - 1];
                            }
                            else
                            {
                                dataGridView1.CurrentCell = dataGridView1["剂量", tb.Rows.Count - 1];
                            }

                        }


                    }
                    #endregion
                    if (tbcf.Rows.Count == 1)
                    {

                        DataRow row = tb.NewRow();
                        tb.Rows[tb.Rows.Count - 1]["序号"] = "";
                        row["修改"] = true;
                        row["收费"] = false;
                        row["分方状态"] = rows_cf[0]["cfxh"].ToString();
                        tb.Rows.Add(row);
                        dataGridView1.DataSource = tb;
                        dataGridView1.CurrentCell = dataGridView1["医嘱内容", tb.Rows.Count - 1];
                    }
                    if (rows_cf.Length > 0 && Badd == true && x < tbcf.Rows.Count && tbcf.Rows.Count != 1)
                    {

                        DataRow row = tb.NewRow();
                        row["序号"] = "小计";
                        row["修改"] = true;
                        row["收费"] = false;
                        row["选择"] = false;
                        row["金额"] = cfje.ToString();

                        if (_menuTag.Function_Name == "Fun_ts_mzys_blcflr_grmb"
                                || _menuTag.Function_Name == "Fun_ts_mzys_blcflr_yjmb"
                                || _menuTag.Function_Name == "Fun_ts_mzys_blcflr_kjmb")
                            row["hjid"] = rows_cf[0]["cfxh"];
                        else
                            row["hjid"] = Guid.Empty.ToString();
                        row["分方状态"] = rows_cf[0]["cfxh"].ToString();
                        cfje = 0;
                        tb.Rows.Add(row);
                        dataGridView1.DataSource = tb;
                        dataGridView1.CurrentCell = dataGridView1["医嘱内容", tb.Rows.Count - 1];

                        if (x < tbcf.Rows.Count - 1)
                        {
                            DataRow row1 = tb.NewRow();
                            tb.Rows[tb.Rows.Count - 1]["序号"] = "";
                            row1["修改"] = true;
                            row1["收费"] = false;
                            tb.Rows.Add(row1);
                            dataGridView1.DataSource = tb;
                            dataGridView1.CurrentCell = dataGridView1["医嘱内容", tb.Rows.Count - 1];
                        }
                    }
                }
                ModifCfje(tb, "");
                butnew_Click(null, null);
                 */
            }
            catch (Exception ex)
            {
                MessageBox.Show("AddMbmx函数出现异常!原因:" + ex.Message, "错误");
            }
            return tab;
        }
    }
}
