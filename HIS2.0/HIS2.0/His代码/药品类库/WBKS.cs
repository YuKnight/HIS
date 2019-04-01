using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenFrame.Forms;
using System.Windows.Forms;
using System.Drawing;
using TrasenFrame.Classes;

namespace YpClass
{
    public class WBKS
    {
        /// <summary>
        /// 判断是否为外部科室
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool IsWbks(int deptid, RelationalDatabase db)
        {
            //外部科室判断
            string sql = string.Format(" select ID from YP_YJKS where iswbks = 1 and DEPTID = {0}", deptid);
            DataTable tab = db.GetDataTable(sql);
            return tab != null && tab.Rows.Count > 0 ? true : false;
        }

        /// <summary>
        /// FrmShowCard查询窗口
        /// </summary>
        /// <param name="sender">引发的控件</param>
        /// <param name="_ShowCardType">查询类型权举</param>
        /// <param name="Fid">其它条件ID</param>
        /// <param name="point">位置 </param>
        public static void frmShowCard_wbks(object sender, ShowCardType _ShowCardType, long Fid, Point point, int deptid, RelationalDatabase _DataBase)
        {
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }


            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            Fshowcard f;

            if (_ShowCardType == ShowCardType.剂型)
            {
                GrdMappingName = new string[] { "id", "药品剂型", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,mc,pym,wbm from yp_ypjx where id<>0 ";//yplx="+Convert.ToInt32(Convertor.IsNull(Fid,"0"))+" ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品剂型";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["mc"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.单位)
            {
                GrdMappingName = new string[] { "标识", "名称" };
                GrdWidth = new int[] { 100, 200 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,dwmc from yp_ypdw where id<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品单位";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["dwmc"].ToString();
                    control.Tag = row["ID"].ToString();
                }
            }
            if (_ShowCardType == ShowCardType.厂家)
            {
                GrdMappingName = new string[] { "id", "生产厂家", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                sfield = new string[] { "wbm", "pym", "", "", "" };
                ssql = "select id,sccj,pym,wbm from yp_sccj where id<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "生产厂家";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["sccj"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }
            if (_ShowCardType == ShowCardType.用法)
            {
                GrdMappingName = new string[] { "id", "使用方法", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wb_code", "py_code", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,name,py_code,wb_code from jc_usagediction where name is not null ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品用法";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["name"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.药理分类)
            {
                GrdMappingName = new string[] { "id", "货位编号", "药品分类", "父分类", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 60, 150, 150, 100, 100 };
                //				if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //				else
                //					sfield=new string[] {"","","","",""};
                ssql = "select id,hwbh,flmc,(select flmc from yp_ylfl where id=a.fid),pym,wbm from yp_ylfl a where yjdbz=1 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Width = 600;
                f.Text = "药理分类";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["flmc"].ToString();
                    control.Tag = row["id"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.供货单位)
            {
                GrdMappingName = new string[] { "id", "供货商", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                sfield = new string[] { "wbm", "pym", "", "", "" };
                ssql = "select ID,ghdwmc,pym,wbm from yp_ghdw WHERE ID<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "供货单位";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["ghdwmc"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.包含在科室管理类型中的药品字典)
            {
                //SystemCfg cfg = new SystemCfg(8002, _DataBase);
                //string tablename = "YK_KCMX";
                //if (cfg.Config == "1")
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);

                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "上次进价", "进货价", "批发价", "零售价", "货号", "基药" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 0, 70, 60, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                ssql = @"select distinct top 100  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw,1 dwbl,
                (case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,
                a.mrjj,
                pfj,lsj,shh,(case when GJJBYW=1 then '是' else '' end) 基药 from vi_yp_ypcd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid left join " + tablename + " c on a.cjid=c.cjid and c.deptid=" + deptid + "  where cjbdelete=0  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);

                f.Location = point;
                f.Text = "药品输入";
                f.Width = 800;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.所有药品字典)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 0, 70, 60, 60, 100 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                ssql = "select distinct top 100  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from yp_ypcjd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid  ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);

                f.Location = point;
                f.Text = "药品输入";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.库存批号列表)
            {
                GrdMappingName = new string[] { "行号", "库存量", "单位", "批号", "效期", "库位", "kwid" };
                GrdWidth = new int[] { 0, 80, 40, 75, 100, 0, 0 };
                sfield = new string[] { "", "", "", "", "" };

                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    ssql = "select 0, kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,'' kwmc,kwid  from yk_kcph " +
                    " where deptid=" + deptid + " and cjid=" + Fid + " and bdelete=0 ";
                else
                    ssql = "select 0, kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,'' kwmc,kwid  from yf_kcph " +
                        " where deptid=" + deptid + " and cjid=" + Fid + " and bdelete=0 ";

                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "", ssql, _DataBase);
                f.Location = point;
                f.Text = "批号列表";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["ypph"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.库存药品)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                /*
                 * update code by pengy 7-2 10:17   
                 * 按系统参数设置获取库存是否大于等于0的数据
                 */
                ssql = "select config from jc_config where id = '8200'";
                DataTable paramTable = _DataBase.GetDataTable(ssql);
                bool ypkc = paramTable != null && paramTable.Rows.Count > 0 && paramTable.Rows[0][0].ToString().Trim() == "1" ? true : false;
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                {
                    if (ypkc)
                        ssql = @"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh 
                                 from vi_yK_kcmx a,yp_ypbm b
                                 where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0 and a.cjid in (select cjid from YP_YPCJD where iswbyp =1)";

                    else
                        ssql = @"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0  and a.cjid in (select cjid from YP_YPCJD where iswbyp =1)";
                }
                else
                {
                    if (ypkc)
                        ssql = @"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0  and a.cjid in (select cjid from YP_YPCJD where iswbyp =1)";
                    else
                        ssql = @"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0  and a.cjid in (select cjid from YP_YPCJD where iswbyp =1)";
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "库存药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.库存药品_不区分禁用)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0  and deptid=" + deptid + " ";
                else
                    ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + "  ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "库存药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.库存药品_外用药品)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    ssql = "select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and wyyp=1   and deptid=" + deptid + " and bdelete_kc=0 ";
                else
                    ssql = "select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid  and wyyp=1 and deptid=" + deptid + " and bdelete_kc=0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "外用药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            #region 加工成品的药品字典
            if (_ShowCardType == ShowCardType.加工成品的药品字典)
            {
                //SystemCfg cfg = new SystemCfg(8002, _DataBase);
                //string tablename = "YK_KCMX";
                //if (cfg.Config == "1")
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);

                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "子类型", "DWBL", "上次进价", "批发价", "零售价", "货号", "基药" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 60, 0, 70, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                string strWhere = "";
                DataTable dtConfig = _DataBase.GetDataTable(string.Format(" select config from jc_config where id = 8042 ", 8042));
                if (dtConfig.Rows.Count > 0)
                {
                    string strCfg = dtConfig.Rows[0][0].ToString();

                    string[] strs = strCfg.Split('|');
                    string strCp = strs[0];
                    string[] scps = strCp.Split(',');


                    for (int i = 0; i < scps.Length; i++)
                    {
                        if (i == 0)
                            strWhere += string.Format(" and a.n_ypzlx in ({0},", scps[i]);
                        else
                            strWhere += string.Format("{0},", scps[i]);
                        if (i == scps.Length - 1)
                        {
                            strWhere = (strWhere.Substring(0, strWhere.Length - 1)) + ") ";
                        }
                    }
                }

                ssql = "select distinct top 80  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw, d.mc zlxmc, 1 dwbl,(case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,pfj,lsj,shh,(case when GJJBYW=1 then '是' else '' end) 基药 from vi_yp_ypcd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid left join " + tablename + " c on a.cjid=c.cjid and c.deptid=" + deptid + " inner join yp_ypzlx d on a.ypzlx=d.id  where cjbdelete=0" + strWhere + "  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";
                try
                {
                    f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                }
                catch
                {
                    throw new Exception(" 8042参数设置有误！ ");
                    return;
                }

                f.Location = point;
                f.Text = "药品输入";
                f.Width = 750;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            #endregion

            #region 制剂成品的药品字典
            if (_ShowCardType == ShowCardType.制剂成品的药品字典)
            {
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "子类型", "DWBL", "上次进价", "批发价", "零售价", "货号", "基药" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 60, 0, 70, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };
                string strWhere = "";

                ssql = "select distinct top 80  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw, d.mc zlxmc, 1 dwbl,(case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,pfj,lsj,shh,(case when GJJBYW=1 then '是' else '' end) 基药 from vi_yp_ypcd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid left join " + tablename + " c on a.cjid=c.cjid and c.deptid=" + deptid + " inner join yp_ypzlx d on a.ypzlx=d.id  where cjbdelete=0" + strWhere + "  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品输入";
                f.Width = 750;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            #endregion
        }


        /// <summary>
        /// FrmShowCard查询窗口
        /// </summary>
        /// <param name="sender">引发的控件</param>
        /// <param name="_ShowCardType">查询类型权举</param>
        /// <param name="Fid">其它条件ID</param>
        /// <param name="point">位置 </param>
        public static void frmShowCard(object sender, ShowCardType _ShowCardType, string functionName, long Fid, Point point, int deptid, RelationalDatabase _DataBase)
        {
            //SystemCfg sc = new SystemCfg(8201);
            //if (sc.Config == "0")
            //{
            //    frmShowCard(sender, _ShowCardType, Fid, point, deptid, _DataBase);
            //    return;
            //}

            Control control = (Control)sender;
            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }
            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            Fshowcard f;

            if (_ShowCardType == ShowCardType.库存药品)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                /*
                   * update code by pengy 7-2 10:17   
                   * 按系统参数设置获取库存是否大于等于0的数据
                  */
                ssql = "select config from jc_config where id = '8200'";
                DataTable paramTable = _DataBase.GetDataTable(ssql);
                bool ypkc = paramTable != null && paramTable.Rows.Count > 0 && paramTable.Rows[0][0].ToString().Trim() == "1" ? true : false;
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                {
                    if (ypkc)
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL >= 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0}) and cjid in (select cjid from YP_YPCJD where iswbyp =1)", deptid);
                    else
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL > 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0}) and cjid in (select cjid from YP_YPCJD where iswbyp =1)", deptid);
                }
                else
                {
                    if (ypkc)
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL >= 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0}) and cjid in (select cjid from YP_YPCJD where iswbyp =1)", deptid);
                    else
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL > 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0}) and cjid in (select cjid from YP_YPCJD where iswbyp =1)", deptid);
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "库存药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            else if (_ShowCardType == ShowCardType.库存药品_不区分禁用)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                {
                    ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                    a.ggid=b.ggid and KCL > 0  and deptid={0}  and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                }
                else
                {
                    ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b 
                    where a.ggid=b.ggid and KCL > 0 and deptid={0}  and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "库存药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            else if (_ShowCardType == ShowCardType.库存药品_外用药品)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    ssql = string.Format(@"select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                          a.ggid=b.ggid and wyyp=1   and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                          where DEPTID = {0})  ", deptid);
                else
                    ssql = string.Format(@"select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                          a.ggid=b.ggid  and wyyp=1 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID                           
                          where DEPTID = {0})", deptid);
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "外用药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
        }
    }
}
