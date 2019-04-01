using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using ts_yb_interface;
using ts_yb_ybpp;

namespace ts_mz_xtsz
{
    public partial class Frmzfbl : Form
    {
        public RelationalDatabase YBDB = null;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frmzfbl(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = chineseName;
            this.WindowState = FormWindowState.Maximized;

            Addcmblx(cmbjklx);
        }

        private void Addcmblx(ComboBox cmb)
        {
            string ssql = "select id,name,ybjklx from jc_yblx where delete_bit=0 and ybjklx>0";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";
            cmb.DataSource = tb;
        }

        public static RelationalDatabase Database(int ybjklx)
        {
            string constr = "";
            string ssql = "select * from jc_ybjklx where ybjklx=" + ybjklx + " ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0) throw new Exception("没有该接口类型");
            if (Convertor.IsNull(tb.Rows[0]["servername"], "") == "") throw new Exception("没有设置医保数据库服务器名");
            string servername = Convertor.IsNull(tb.Rows[0]["servername"], "");
            string username = Convertor.IsNull(tb.Rows[0]["username"], "");
            string password = Convertor.IsNull(tb.Rows[0]["password"], "");
            string portname = Convertor.IsNull(tb.Rows[0]["portname"], "");
            string dbname = Convertor.IsNull(tb.Rows[0]["dbname"], "");
            int dbtype = Convert.ToInt32((tb.Rows[0]["dbtype"]));
            if (dbtype == 1)
                constr = @"packet size=4096;user id=" + username + ";password=" + password + ";data source=" + servername + ";persist security info=True;initial catalog=" + dbname;
            else if (dbtype == 3)
                constr = @"Provider=OraOLEDB.Oracle;Data Source=" + servername + ";User Id=" + username + ";Password=" + password + "";
            else
                constr = "";

            RelationalDatabase database = null;
            //连接数据库
            if (dbtype == 1)
                database = new MsSqlServer();
            if (dbtype == 2)
                database = new IbmDb2();
            if (dbtype == 3)
                database = new Oracle();
            if (dbtype == 4)
                database = new MsAccess();

            //初始化数据库连接
            if (database != null)
                database.Initialize(constr);
            else
                throw new Exception("初始化医保数据库时没有成功，连接失败");
            return database;

        }
        private void butmodif_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = PubStaticFun.WaitCursor();
                butmodif.Enabled = false;
                DataTable tb = (DataTable)this.dataGridView2.DataSource;
                string ssql = "";
                int yblx = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                ts_mz_class.Yblx _yblx = new ts_mz_class.Yblx(yblx);
                pb.Value = 0;
                pb.Minimum = 0;
                pb.Maximum = tb.Rows.Count;
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string msg = "";
               
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    try
                    {
                        #region 屏幕
                        //if (tb.Rows[i]["备注"].ToString() == "新增的匹配")
                        //{
                        //    ssql = "insert into jc_yb_bl(yblx,hsbm,ybbm,ybmc,xmly,xmid,zybz,gxsj,zfbl,ybdl,ybxl)" +
                        //    "select " + yblx + ",'" + tb.Rows[i]["医院编码"].ToString() + "','" + tb.Rows[i]["医保编码"].ToString() + "','" +
                        //    tb.Rows[i]["医保名称"].ToString().Replace("'", "") + "',xmly,xmid,1,getdate()," + Convertor.IsNull(tb.Rows[i]["自付比例"], "0") +
                        //    " ,'" + tb.Rows[i]["YBDL"].ToString() + "','" + tb.Rows[i]["YBXL"].ToString() + 
                        //    "' from JC_YB_MATCH_RECORD where yydm='" + tb.Rows[i]["医院编码"].ToString() + "' and ybjklx="+_yblx.ybjklx+" ";
                        //    InstanceForm.BDatabase.DoCommand(ssql);

                        //    ssql = "INSERT INTO JC_YB_PPGXSJ (YBLX,YYDM,YYMC,YBBM,YBMC,YYFL,YBDL,YBXL,DJY,DJSJ,BZ,zfbl,bzt)"+
                        //        "select top 1 " + yblx + ",'" + tb.Rows[i]["医院编码"].ToString() + "','"+tb.Rows[i]["医院名称"].ToString()+"','" + tb.Rows[i]["医保编码"].ToString() + "','" +
                        //    tb.Rows[i]["医保名称"].ToString().Replace("'", "") + "',(case when tjdxm in('01','02','03') then tjdxm else '00' end) ,"+
                        //    " '" + tb.Rows[i]["YBDL"].ToString() + "','" + tb.Rows[i]["YBXL"].ToString() + "',"+InstanceForm.BCurrentUser.EmployeeId+
                        //    ",getdate(),'',"+ Convertor.IsNull(tb.Rows[i]["自付比例"], "0")+",1 from JC_YB_MATCH_RECORD where yydm='" + tb.Rows[i]["医院编码"].ToString() + "' and ybjklx="+_yblx.ybjklx+" ";
                        //    InstanceForm.BDatabase.DoCommand(ssql);
                        //}
                        //if (tb.Rows[i]["备注"].ToString() == "修改匹配")
                        //{
                        //    ssql = "update jc_yb_bl set ybbm='" + tb.Rows[i]["医保编码"].ToString() + "'," +
                        //        " ybmc='" + tb.Rows[i]["医保名称"].ToString().Replace("'", "") + "',YBDL='" + tb.Rows[i]["YBDL"].ToString() + "',YBXL='" + tb.Rows[i]["YBXL"].ToString() + "' " +
                        //        " where yblx=" + yblx + " and hsbm='" + tb.Rows[i]["医院编码"].ToString() + "'  ";
                        //    InstanceForm.BDatabase.DoCommand(ssql);

                        //    ssql = "update a set ybbm='" + tb.Rows[i]["医保编码"].ToString() + "'," +
                        //        " ybmc='" + tb.Rows[i]["医保名称"].ToString().Replace("'", "") + "',YBDL='" + tb.Rows[i]["YBDL"].ToString() + "',YBXL='" + tb.Rows[i]["YBXL"].ToString() + "' " +
                        //        " yyfl=(case when tjdxm in('01','02','03') then tjdxm else '00' end) from JC_YB_PPGXSJ a,jc_yb_match_record b where a.yydm=b.yydm " +
                        //        " and  a.yblx=" + yblx + " and b.ybjklx="+_yblx.ybjklx+" and a.yydm='" + tb.Rows[i]["医院编码"].ToString() + "' ";
                        //    InstanceForm.BDatabase.DoCommand(ssql);

                        //}
                        //if (tb.Rows[i]["备注"].ToString() == "已解除匹配")
                        //{
                        //    ssql = "delete from jc_yb_bl  where yblx=" + yblx + " and hsbm='" + tb.Rows[i]["医院编码"].ToString() + "' ";
                        //    InstanceForm.BDatabase.DoCommand(ssql);

                        //    ssql = "update JC_YB_PPGXSJ set bscbz=1   where yblx=" + yblx + " and yydm='" + tb.Rows[i]["医院编码"].ToString() + "'and bscbz=0 and bzt=1 ";
                        //    InstanceForm.BDatabase.DoCommand(ssql);
                        //}

                        //if (tb.Rows[i]["备注"].ToString() == "修改比例")
                        //{
                        //    ssql = "update jc_yb_bl set zfbl=" + Convertor.IsNull(tb.Rows[i]["自付比例"],"0")  + " " +
                        //       " where yblx=" + yblx + " and hsbm='" + tb.Rows[i]["医院编码"].ToString() + "' ";
                        //}
                        #endregion

                        int err_code = -1;
                        string err_text = "";

                        if (tb.Rows[i]["备注"].ToString() != "已解除匹配")
                        {
                            Fun.Czlx _czlx = Fun.Czlx.待审核;
                            if (tb.Rows[i]["备注"].ToString() == "新增的匹配")
                                _czlx = Fun.Czlx.已通过;
                            if (tb.Rows[i]["备注"].ToString() == "修改匹配")
                                _czlx = Fun.Czlx.已通过;
      
                            //保存匹配关系到HIS
                            long newid = 0;
                            DataTable tbhs = Fun.GetHsXm(_yblx.yblx, tb.Rows[i]["医院编码"].ToString(), InstanceForm.BDatabase);
                            string tjdxm = tbhs.Rows[0]["tjdxm"].ToString();
                            string yyfl = "00";
                            if (tjdxm == "01") yyfl = "01";
                            if (tjdxm == "02") yyfl = "02";
                            if (tjdxm == "03") yyfl = "03";//yblx,
                            bool bok = ts_yb_ybpp.Fun.SavePPGX(yblx, tb.Rows[i]["医院编码"].ToString(), tb.Rows[i]["医院名称"].ToString(), "", tb.Rows[i]["医保编码"].ToString(), tb.Rows[i]["医保名称"].ToString(), "",
                                yyfl, tb.Rows[i]["YBDL"].ToString(), tb.Rows[i]["YBXL"].ToString(), InstanceForm.BCurrentUser.EmployeeId, djsj, "", -1,
                                 tb.Rows[i]["匹配序号"].ToString(), _czlx, _yblx.ybjklx,
                                (decimal)999999.99, djsj, ref newid, ref err_code, ref err_text, InstanceForm.BDatabase);
                            if (bok == false) msg = msg + "项目编码:" + tb.Rows[i]["医院编码"].ToString() + " " + err_text + "\n";
                             
                        }
                        else
                        {
                            //保存匹配关系到HIS
                            bool bok = Fun.DeletePPGX(yblx, tb.Rows[i]["医院编码"].ToString(), tb.Rows[i]["医院名称"].ToString(), tb.Rows[i]["医保编码"].ToString(), tb.Rows[i]["医保名称"].ToString(), InstanceForm.BCurrentUser.EmployeeId, djsj, "", ref err_code, ref err_text, InstanceForm.BDatabase);
                            if (bok == false) msg = msg + err_text;
                        }


                        pb.Value = pb.Value + 1;
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("修改成功" + msg, "导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
                butcx_Click(sender, e);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                Cursor = Cursors.Default;
            }
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                butmodif.Enabled = true;

                string zxbm = "";
                string yybm = "";
                int ybjklx = 0;
                int yblx = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                string ssql = "select * from jc_yblx where id=" + yblx + "";
                DataTable tb_yblx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb_yblx.Rows.Count > 0)
                {
                    zxbm = Convertor.IsNull(tb_yblx.Rows[0]["insurecentral"], "");
                    yybm = Convertor.IsNull(tb_yblx.Rows[0]["hosp_id"], "");
                    ybjklx = Convert.ToInt32(Convertor.IsNull(tb_yblx.Rows[0]["ybjklx"], "0"));
                }

                //查询HIS目录到网格
                ssql = "select '' 序号,a.yydm 医院编码,a.pm 医院名称,ybbm 医保编码,ybmc 医保名称,zfbl 自付比例 " +
                                " from JC_YB_MATCH_RECORD a left join jc_yb_bl b " +
                                " on a.yydm=b.hsbm  and b.yblx=" + yblx + " where a.ybjklx=" + ybjklx + " ";
                if (txtxm.Text.Trim() != "")
                    ssql = ssql + " and (a.yydm like '%" + txtxm.Text.Trim() + "%' or a.pm like '%" + txtxm.Text.Trim() + "%')";
                ssql = ssql + " order by a.yydm ";
                DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                    tab.Rows[i]["序号"] = i + 1;
                dataGridView1.DataSource = tab;

                //用于循环对比的HIS目录
                ssql = "select '' 序号,a.yydm 医院编码,a.pm 医院名称,ybbm 医保编码,ybmc 医保名称,zfbl 自付比例,YBDL,YBXL,a.xmly,a.tjdxm,b.id " +
                    " from JC_YB_MATCH_RECORD a left join jc_yb_bl b " +
                    " on a.yydm=b.hsbm and b.yblx=" + yblx + "  where a.ybjklx=" + ybjklx + "    order by a.yydm ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);


                ssql = "select '' 序号,'' 医院编码,'' 医院名称,'' 医保编码,'' 医保名称,'' 自付比例,'' 备注,'' YBDL, '' YBXL,'' 匹配序号 where 1=2";
                DataTable tb_xg = InstanceForm.BDatabase.GetDataTable(ssql);
                dataGridView2.DataSource = tb_xg;


                //查询需要修改的匹配关系
                DataTable tb_pp = null;
                DataRow[] rows = null;
                DataRow newrow = null;

                DataTable tb_zfbl = null;
                DataRow rows_zfbl = null;

                SystemCfg syscfg = new SystemCfg(18);
                int X = 0;
                switch (ybjklx)
                {
                    case 7:
                    case 9:
                        #region 老的铁路、区医保
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        YBDB = Database(ybjklx);
                        ssql = "select his_code yybm,hy_code ybbm,hy_name ybmc from his_relation  where center_id=" + zxbm + " and valid_flag=1 and csbz=1";
                        tb_pp = YBDB.GetDataTable(ssql);
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {

                            rows = tb_pp.Select("yybm='" + tb.Rows[i]["医院编码"].ToString() + "'");
                            if (rows.Length > 0)
                            {
                                if (tb.Rows[i]["id"].ToString() == "" ||
                                    (tb.Rows[i]["医保编码"].ToString() != rows[0]["ybbm"].ToString() && tb.Rows[i]["id"].ToString() != ""))
                                {
                                    newrow = tb_xg.NewRow();
                                    newrow["序号"] = Convert.ToString(i + 1);
                                    newrow["医院编码"] = tb.Rows[i]["医院编码"];
                                    newrow["医院名称"] = tb.Rows[i]["医院名称"];
                                    newrow["医保编码"] = rows[0]["ybbm"];
                                    newrow["医保名称"] = rows[0]["ybmc"];
                                    if (tb.Rows[i]["id"].ToString() == "")
                                        newrow["备注"] = "新增的匹配";
                                    if (tb.Rows[i]["医保编码"].ToString() != rows[0]["ybbm"].ToString() && tb.Rows[i]["id"].ToString() != "")
                                        newrow["备注"] = "修改匹配";
                                    tb_xg.Rows.Add(newrow);
                                }
                            }
                            else
                            {
                                if (tb.Rows[i]["id"].ToString() != "" && tb.Rows[i]["医保编码"].ToString() != "")
                                {
                                    newrow = tb_xg.NewRow();
                                    newrow["序号"] = i.ToString();
                                    newrow["医院编码"] = tb.Rows[i]["医院编码"];
                                    newrow["医院名称"] = tb.Rows[i]["医院名称"];
                                    newrow["医保编码"] = "";
                                    newrow["医保名称"] = "";
                                    if (syscfg.Config == "1")
                                        newrow["备注"] = "修改匹配";
                                    else
                                        newrow["备注"] = "已解除匹配";
                                    tb_xg.Rows.Add(newrow);
                                }
                            }

                            pb.Value = pb.Value + 1;
                        }

                        #endregion
                        break;
                    case 4:
                    case 8:
                    case 11:
                    case 13:
                    case 17:
                    case 28://Add By Zj 2012-08-13
                    case 30://Add By Zj 2013-03-12 创智工伤
                        #region 湖南省和长沙市医保
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        YBDB = Database(ybjklx);

                        string iscenter = "0";
                        iscenter = Convertor.IsNull(ApiFunction.GetIniString(zxbm, "iscenter", Constant.ApplicationDirectory + "//InsureConfig.ini"), "0");
                        if (ybjklx == 11)
                            zxbm = ApiFunction.GetIniString(zxbm, "CENTER_ID", Constant.ApplicationDirectory + "//InsureConfig.ini");
                        if (ybjklx == 4 || ybjklx == 13 || ybjklx == 17 || ybjklx == 11 || ybjklx == 28 || ybjklx == 30)
                        {
                            //Modify By Zj 2013-03-01 因为有些县 使用市 的编码，所以在数据库中，只有市的编码。要查询到县的项目的话 就要使用 市的编码 通过ini来设置   Modify by zp 2013-11-06 
                            ssql = "select hosp_code yybm,item_code ybbm,item_name ybmc,'' item_type,'' fee_type,serial_match from BS_CATALOG_MATCH  where ( expire_date>='1900-04-01 00:00:00' or expire_date is null) ";
                            if (iscenter == "0")
                                ssql += " and center_id=" + zxbm + " ";
                            else
                                ssql += " and center_id=" + iscenter + " ";

                        }
                        else
                        {
                            ssql = "select hosp_code yybm,item_code ybbm,item_name ybmc,item_type,fee_type ,serial_match from BS_CATALOG_MATCH  where center_id=" + zxbm + " ";
                             
                        }
                        tb_pp = YBDB.GetDataTable(ssql);


                        X = 0;
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {

                            rows = tb_pp.Select("yybm='" + tb.Rows[i]["医院编码"].ToString() + "'");

                            if (rows.Length > 0)
                            {
                                #region
                                if (
                                    tb.Rows[i]["医保编码"].ToString() == ""
                                    ||
                                    (tb.Rows[i]["医保编码"].ToString() != rows[0]["ybbm"].ToString() && tb.Rows[i]["医保编码"].ToString() != "")
                                    ||
                                    (
                                        (tb.Rows[i]["YBDL"].ToString() != rows[0]["item_type"].ToString()
                                        || tb.Rows[i]["YBXL"].ToString() != rows[0]["fee_type"].ToString()) && tb.Rows[i]["医保编码"].ToString() != "" && ybjklx == 8
                                    )
                                    //||
                                    //( Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["自付比例"],"0")) != Convert.ToDecimal(Convertor.IsNull(rows[0]["self_scale"],"0"))  )

                                    )
                                {
                                    X = X + 1;
                                    newrow = tb_xg.NewRow();
                                    newrow["序号"] = X.ToString();
                                    newrow["医院编码"] = tb.Rows[i]["医院编码"];
                                    newrow["医院名称"] = tb.Rows[i]["医院名称"];
                                    newrow["医保编码"] = rows[0]["ybbm"];
                                    newrow["医保名称"] = rows[0]["ybmc"];
                                    newrow["YBDL"] = rows[0]["item_type"];
                                    newrow["YBXL"] = rows[0]["fee_type"];
                                    newrow["匹配序号"] = rows[0]["serial_match"];
                                    //newrow["自付比例"] = rows[0]["self_scale"];
                                    if (tb.Rows[i]["id"].ToString() == "")
                                        newrow["备注"] = "新增的匹配";
                                    if (tb.Rows[i]["医保编码"].ToString() != rows[0]["ybbm"].ToString() && tb.Rows[i]["id"].ToString() != "")
                                        newrow["备注"] = "修改匹配";
                                    if ((tb.Rows[i]["YBDL"].ToString() != rows[0]["item_type"].ToString() || tb.Rows[i]["YBXL"].ToString() != rows[0]["fee_type"].ToString()) && tb.Rows[i]["医保编码"].ToString() != "" && ybjklx == 8)
                                        newrow["备注"] = "修改匹配";
                                    //if (tb.Rows[i]["医保编码"].ToString() != "" && Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["自付比例"], "0")) != Convert.ToDecimal(Convertor.IsNull(rows[0]["self_scale"], "0")) )
                                    //    newrow["备注"] = "修改比例";
                                    tb_xg.Rows.Add(newrow);
                                }
                                #endregion
                            }
                            else
                            {
                                if (tb.Rows[i]["id"].ToString() != "" && tb.Rows[i]["医保编码"].ToString() != "")
                                {
                                    newrow = tb_xg.NewRow();
                                    newrow["序号"] = X.ToString();
                                    newrow["医院编码"] = tb.Rows[i]["医院编码"];
                                    newrow["医院名称"] = tb.Rows[i]["医院名称"];
                                    newrow["医保编码"] = "";
                                    newrow["医保名称"] = "";
                                    //newrow["备注"] = "已解除匹配";
                                    if (syscfg.Config == "1")
                                        newrow["备注"] = "修改匹配";
                                    else
                                        newrow["备注"] = "已解除匹配";
                                    tb_xg.Rows.Add(newrow);
                                    X = X + 1;
                                }
                            }
                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;
                    case 1:
                    case 12://Add By Tany 2010-09-07
                        #region 老长信
                        //Add By tany 2010-07-06 增加长信的匹配信息
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        YBDB = Database(ybjklx);
                        //Add By Zj 2012-03-06 添加ybyy表头
                        ssql = "select yyypbm yybm,ybymbm ybbm,ypmc ybmc from ybyy.tab_hospital_ypbm where ybymbm is not null " +
                            " union all " +
                            " select yycwlbbm yybm,ybcwlbbm ybbm,yycwlbmc ybmc from ybyy.tab_hospital_bclbbm where ybcwlbbm is not null " +
                            " union all " +
                            " select yyzzxmbm yybm,ybzzxmbm ybbm,zzxmmc ybmc from ybyy.tab_hospital_zzxmbm where ybzzxmbm is not null";
                        tb_pp = YBDB.GetDataTable(ssql);
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {

                            rows = tb_pp.Select("yybm='" + tb.Rows[i]["医院编码"].ToString() + "'");
                            if (rows.Length > 0)
                            {
                                if (tb.Rows[i]["id"].ToString() == "" ||
                                    (tb.Rows[i]["医保编码"].ToString() != rows[0]["ybbm"].ToString() && tb.Rows[i]["id"].ToString() != ""))
                                {
                                    newrow = tb_xg.NewRow();
                                    newrow["序号"] = Convert.ToString(i + 1);
                                    newrow["医院编码"] = tb.Rows[i]["医院编码"];
                                    newrow["医院名称"] = tb.Rows[i]["医院名称"];
                                    newrow["医保编码"] = rows[0]["ybbm"];
                                    newrow["医保名称"] = rows[0]["ybmc"];
                                    if (tb.Rows[i]["id"].ToString() == "")
                                        newrow["备注"] = "新增的匹配";
                                    if (tb.Rows[i]["医保编码"].ToString() != rows[0]["ybbm"].ToString() && tb.Rows[i]["id"].ToString() != "")
                                        newrow["备注"] = "修改匹配";
                                    tb_xg.Rows.Add(newrow);
                                }
                            }
                            else
                            {
                                if (tb.Rows[i]["id"].ToString() != "" && tb.Rows[i]["医保编码"].ToString() != "")
                                {
                                    newrow = tb_xg.NewRow();
                                    newrow["序号"] = i.ToString();
                                    newrow["医院编码"] = tb.Rows[i]["医院编码"];
                                    newrow["医院名称"] = tb.Rows[i]["医院名称"];
                                    newrow["医保编码"] = "";
                                    newrow["医保名称"] = "";
                                    if (syscfg.Config == "1")
                                        newrow["备注"] = "修改匹配";
                                    else
                                        newrow["备注"] = "已解除匹配";
                                    tb_xg.Rows.Add(newrow);
                                }
                            }

                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;
                    case 10:
                        #region 新长信
                        throw new Exception("没有提供此功能");
                        #endregion
                        break;
                    #region 老的湖南省工商医保屏蔽 Modify By Zj 2012-02-22
                    //case 11:
                    //    #region 湖南省工伤
                    //    pb.Value = 0;
                    //    pb.Minimum = 0;
                    //    pb.Maximum = tb.Rows.Count;

                    //    IntPtr intptr = HG_Interface_Sgs.GetInterfaceHandler(zxbm);
                    //    ParameterSet[] outParaSet = new ParameterSet[1];
                    //    outParaSet[0] = new ParameterSet();
                    //    outParaSet[0].ParameterSetName = "ItemMatch";
                    //    string[][] outPara = new string[1][];
                    //    outPara[0] = new string[] { "hosp_code", "hosp_name", "hosp_model", "item_code", "item_name", "model_name", "serial_match", "valid_flag", "audit_flag", "match_type" };
                    //    string[] columns = new string[] { "hospital_id", "audit_status", "item_type" };
                    //    Parameter[] parameter = new Parameter[columns.Length];
                    //    //初始化参数
                    //    for (int j = 0; j < parameter.Length; j++)
                    //    {
                    //        parameter[j] = new Parameter();
                    //        parameter[j].ParameterName = columns[j];
                    //    }

                    //    try
                    //    {
                    //        yybm = HG_Interface_Sgs.GetIniString(zxbm + "SGS", "HOSP_ID", HG_Interface_Sgs.configIniFilePath); //Modify By Tany 2010-03-30 读取INI的医院编码，用于同中心不同医院使用
                    //        parameter[0].Value = new StringBuilder(yybm);
                    //        parameter[1].Value = new StringBuilder("1");
                    //        parameter[2].Value = new StringBuilder("0");
                    //        HG_Interface_Sgs.Execute(intptr, 100103, parameter, outPara, ref outParaSet, zxbm, yybm);
                    //        tb_pp = outParaSet[0].ConvertToDataTable();

                    //        outParaSet[0] = new ParameterSet();
                    //        outParaSet[0].ParameterSetName = "ItemMatch";
                    //        parameter[2].Value = new StringBuilder("1");
                    //        HG_Interface_Sgs.Execute(intptr, 100103, parameter, outPara, ref outParaSet, zxbm, yybm);

                    //        if (outParaSet[0].ConvertToDataTable() != null && outParaSet[0].ConvertToDataTable().Rows.Count > 0)
                    //        {
                    //            foreach (DataRow dr in outParaSet[0].ConvertToDataTable().Rows)
                    //            {
                    //                tb_pp.Rows.Add(dr.ItemArray);
                    //            }
                    //        }
                    //    }
                    //    catch (Exception err)
                    //    {
                    //        tb_pp = new DataTable();
                    //    }

                    //    X = 0;
                    //    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    //    {
                    //        if (tb_pp != null && tb_pp.Rows.Count > 0)
                    //        {
                    //            rows = tb_pp.Select("hosp_code='" + tb.Rows[i]["医院编码"].ToString() + "'");

                    //            if (rows.Length > 0)
                    //            {
                    //                if (
                    //                    tb.Rows[i]["id"].ToString() == ""
                    //                    ||
                    //                    (tb.Rows[i]["医保编码"].ToString() != rows[0]["item_code"].ToString() && tb.Rows[i]["id"].ToString() != "")
                    //                    )
                    //                {
                    //                    X = X + 1;
                    //                    newrow = tb_xg.NewRow();
                    //                    newrow["序号"] = X.ToString();
                    //                    newrow["医院编码"] = tb.Rows[i]["医院编码"];
                    //                    newrow["医院名称"] = tb.Rows[i]["医院名称"];
                    //                    newrow["医保编码"] = rows[0]["item_code"];
                    //                    newrow["医保名称"] = rows[0]["item_name"];
                    //                    newrow["YBDL"] = rows[0]["match_type"];
                    //                    //newrow["YBXL"] = rows[0]["fee_type"];
                    //                    //newrow["自付比例"] = rows[0]["self_scale"];
                    //                    if (tb.Rows[i]["id"].ToString() == "")
                    //                        newrow["备注"] = "新增的匹配";
                    //                    if (tb.Rows[i]["医保编码"].ToString() != rows[0]["item_code"].ToString() && tb.Rows[i]["id"].ToString() != "")
                    //                        newrow["备注"] = "修改匹配";
                    //                    //if (tb.Rows[i]["医保编码"].ToString() != "" && Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["自付比例"], "0")) != Convert.ToDecimal(Convertor.IsNull(rows[0]["self_scale"], "0")) )
                    //                    //    newrow["备注"] = "修改比例";
                    //                    tb_xg.Rows.Add(newrow);
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            if (tb.Rows[i]["id"].ToString() != "" && tb.Rows[i]["医保编码"].ToString() != "")
                    //            {
                    //                newrow = tb_xg.NewRow();
                    //                newrow["序号"] = X.ToString();
                    //                newrow["医院编码"] = tb.Rows[i]["医院编码"];
                    //                newrow["医院名称"] = tb.Rows[i]["医院名称"];
                    //                newrow["医保编码"] = "";
                    //                newrow["医保名称"] = "";
                    //                if (syscfg.Config == "1")
                    //                    newrow["备注"] = "修改匹配";
                    //                else
                    //                    newrow["备注"] = "已解除匹配";
                    //                tb_xg.Rows.Add(newrow);
                    //                X = X + 1;
                    //            }
                    //        }
                    //        pb.Value = pb.Value + 1;
                    //        this.Refresh();
                    //    }
                    //    #endregion
                    //    break;
                    #endregion
                    default:
                        throw new Exception("没有接口处理方法,不能导出");
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbjklx_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb1 = (DataTable)dataGridView1.DataSource;
            DataTable tb2 = (DataTable)dataGridView2.DataSource;

            if (tb1 != null) tb1.Rows.Clear();
            if (tb2 != null) tb2.Rows.Clear();
        }
    }
}