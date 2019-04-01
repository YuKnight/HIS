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
using System.Runtime.InteropServices;

namespace ts_mz_xtsz
{
    public partial class frmexportYb : Form
    {
        public RelationalDatabase YBDB = null;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public static readonly string configIniFilePath = System.Windows.Forms.Application.StartupPath + "\\InsureConfig.ini";
        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        public frmexportYb(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = chineseName;
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmexportYb_Load(object sender, EventArgs e)
        {
            AddcmbJklx(cmbjklx);
        }

        private void AddcmbJklx(ComboBox cmb)
        {
            string ssql = "select ybjklx,jkmc from jc_ybjklx where ybjklx in(select ybjklx from jc_yblx)";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            cmb.DisplayMember = "jkmc";
            cmb.ValueMember = "ybjklx";
            cmb.DataSource = tb;
        }




        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                //新增
                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "@ybjklx";
                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                parameters[1].Text = "@xgzt";
                parameters[1].Value = 0;
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YB_InsertUpdate_Select", parameters, 120);

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;

                this.dataGridView1.DataSource = tb;


                //修改
                ParameterEx[] parameters1 = new ParameterEx[2];
                parameters1[0].Text = "@ybjklx";
                parameters1[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                parameters1[1].Text = "@xgzt";
                parameters1[1].Value = 1;
                DataTable tb1 = InstanceForm.BDatabase.GetDataTable("SP_YB_InsertUpdate_Select", parameters1, 120);

                for (int i = 0; i <= tb1.Rows.Count - 1; i++)
                    tb1.Rows[i]["序号"] = i + 1;

                this.dataGridView2.DataSource = tb1;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            else if (dbtype == 2)
            {
                constr = @"Provider=IBMDADB2.1;hostname=" + servername + ";Data Source=" + dbname + ";Persist Security Info=True;User ID=" + username + " ;Password=" + password + ";CurrentSchema=SDDT; ";
            }
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

        private void cmbjklx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tb1 = (DataTable)dataGridView1.DataSource;
                DataTable tb2 = (DataTable)dataGridView2.DataSource;

                if (tb1 != null) tb1.Rows.Clear();
                if (tb2 != null) tb2.Rows.Clear();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butexport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = PubStaticFun.WaitCursor();
                butexport.Enabled = false;
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                ParameterEx[] parameters;
                int err_code = -1;
                string err_text = "";
                string ssql = "";
                string zxbm = "";
                string yybm = "";
                ssql = "select * from jc_yblx where ybjklx=" + Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, "")) + "";
                DataTable tb_yblx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb_yblx.Rows.Count > 0)
                {
                    zxbm = Convertor.IsNull(tb_yblx.Rows[0]["insurecentral"], "");
                    yybm = Convertor.IsNull(tb_yblx.Rows[0]["hosp_id"], "");
                }

                string code = "";
                string xmfl = "";
                string jx = "";
                string pm = "";
                string gg = "";
                string dw = "";
                string cj = "";
                string pym = "";
                string wbm = "";
                decimal lsj = 0;
                string xmly = "0";
                string yplx = "0";
                string tjdxm = "";
                string gjbm = "";
                DataTable tbcx = null;

                ts_yb_interface.Parameter[] inputParameters = new ts_yb_interface.Parameter[6];
                ParameterSet outputParameterSets = new ParameterSet();
                string[] outparNames = { "errmsg" };
                string cwfdm = "";

                switch (Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, "")))
                {
                    case 3:
                        #region 洞氮医保
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;

                        Parameter[] param = new Parameter[1];
                        param[0] = new Parameter("Hospital_ID", yybm);
                        ParameterSet ps = new ParameterSet();
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region 导入洞氮医保

                            Parameter[] par = new Parameter[9];
                            par[0] = new Parameter("sfxmbm", Convertor.IsNull(tb.Rows[i]["编码"], "0"));
                            par[1] = new Parameter("xmmc", Convertor.IsNull(tb.Rows[i]["项目名称"], "0"));
                            par[2] = new Parameter("jldw", Convertor.IsNull(tb.Rows[i]["单位"], "0"));
                            par[3] = new Parameter("gg", Convertor.IsNull(tb.Rows[i]["规格"], "0"));
                            par[4] = new Parameter("zjf", Convertor.IsNull(tb.Rows[i]["拼音码"], "0"));
                            par[5] = new Parameter("fylbbm", Convertor.IsNull(tb.Rows[i]["统计大项"], "0"));
                            par[6] = new Parameter("dj", Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                            par[7] = new Parameter("jx", Convertor.IsNull(tb.Rows[i]["剂型"], "0"));
                            par[8] = new Parameter("yplb", "0");  //药品类别（国产0,合资1，进口2）

                            ps.Rows.Add(par);

                            #endregion


                        }
                        DD_Interface dd = new DD_Interface();
                        bool b = dd.Send_sfxm_pl(param, ps);
                        if (b == false)
                            return;

                        #endregion

                        #region HIS记录
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = Convertor.IsNull(tb.Rows[i]["编码"], "");
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = Convertor.IsNull(tb.Rows[i]["XMLY"], "0");
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pb.Value = pb.Value + 1;

                        }
                        #endregion
                        break;
                    case 7:
                    case 9:
                        #region 老的铁路、区医保
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        YBDB = Database(Convert.ToInt32(cmbjklx.SelectedValue));
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region 导入医保
                            code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                            xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                            jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                            pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                            dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                            cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                            pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                            wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                            lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                            xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                            yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                            tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                            gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                            if (xmly == "1")
                            {
                                tbcx = YBDB.GetDataTable("select * from ih_ypml where mc_code='" + code + "'");
                                if (tbcx.Rows.Count == 0)
                                {
                                    ssql = "insert into ih_ypml(mc_code,mc_name,mc_type,class_id,code_py,code_wb," +
                                    "factory,model,standard,unit,price)values('" + code + "','" + pm + "','" + yplx + "','" + yplx + "','" +
                                    pym + "','" + wbm + "','" + cj + "','" + jx + "','" + gg + "','" + dw + "'," + lsj + ")";
                                    YBDB.DoCommand(ssql);
                                }
                            }
                            else
                            {
                                tbcx = YBDB.GetDataTable("select * from lc_craft where ITEM_CODE='" + code + "'");
                                if (tbcx.Rows.Count == 0)
                                {
                                    ssql = "INSERT INTO lc_craft(ITEM_CODE,item_name,five_input,nature_input,item_unit,item_price)" +
                                        "values('" + code + "','" + pm + "','" + wbm + "','" + pym + "','" + dw + "'," + lsj + ")";
                                    YBDB.DoCommand(ssql);
                                }
                            }
                            #endregion

                            #region HIS记录
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = tb.Rows[i]["编码"].ToString();
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code == -1) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            #endregion

                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;
                    case 4:
                    case 8:
                    case 11:
                    case 13:
                    case 17:
                    case 28://Add By Zj 2012-08-13 新的创智医保接口
                    case 30://Add By Zj 2013-03-12 创智工伤
                        #region 湖南省和长沙市医保
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        YBDB = Database(Convert.ToInt32(cmbjklx.SelectedValue));
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region 导入医保
                            code = Convertor.IsNull(tb.Rows[i]["编码"], "").Trim();
                            xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                            jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                            pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "").Replace("'", "''").Trim(); //Modify By Zj 2012-07-10 防止SQL注释
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                            dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                            cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                            pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                            wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                            lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                            xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                            tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                            yplx = "0";
                            if (tjdxm == "01") yplx = "1";
                            if (tjdxm == "02") yplx = "2";
                            if (tjdxm == "03") yplx = "3";
                            gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");
                            //获得剂型编码
                            tbcx = YBDB.GetDataTable("select top 1 model_code from mt_medi_model where model_name='" + jx.Trim() + "'");
                            if (tbcx.Rows.Count > 0) jx = Convertor.IsNull(tbcx.Rows[0][0], "");

                            tbcx = YBDB.GetDataTable("select * from mt_hosp_medi where medi_code='" + code + "' ");
                            if (tbcx.Rows.Count == 0)
                            {
                                ssql = "insert into mt_hosp_medi(medi_code, type_code, medi_name, code_wb,code_py, factory, standard, medi_unit,medi_price,MODEL_CODE,VALID_FLAG) values ('" + code + "','" + yplx + "','" + pm + "','" + wbm + "','" + pym + "','" + cj + "','" + gg + "','" + dw + "'," + lsj + ",'" + jx + "','1')";
                                YBDB.DoCommand(ssql);
                            }

                            #endregion

                            #region HIS记录
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = tb.Rows[i]["编码"].ToString();
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code == -1) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            #endregion

                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;
                    case 1:
                        #region 老长信
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        inputParameters = new ts_yb_interface.Parameter[6];
                        outputParameterSets = new ParameterSet();
                        outparNames = new string[] { "errmsg" };
                        cwfdm = new SystemCfg(7029).Config;
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region  导入长信
                            code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                            xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                            jx = Convertor.IsNull(tb.Rows[i]["剂型"], "").Trim();
                            if (jx.Length > 3)
                                jx = jx.Substring(0, 3);
                            pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "").Trim();
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "").Trim();
                            dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                            cj = Convertor.IsNull(tb.Rows[i]["厂家"], "").Trim();
                            pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "").Trim();
                            wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "").Trim();
                            lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                            xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                            yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                            tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                            gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                            string cxlb = xmly;
                            if (tjdxm == cwfdm) cxlb = "3";

                            inputParameters[0] = new ts_yb_interface.Parameter("", zxbm);//医保机构编码(保留位)
                            inputParameters[1] = new ts_yb_interface.Parameter("", yybm);//医院编码(保留位)
                            inputParameters[2] = new ts_yb_interface.Parameter("", cxlb);//类别（1 药品 2诊治项目 3 床位费 0疾病）
                            inputParameters[3] = new ts_yb_interface.Parameter("", code);//医院项目编码
                            inputParameters[4] = new ts_yb_interface.Parameter("", pm);//医院项目名称
                            if (cxlb == "3")
                                inputParameters[5] = new ts_yb_interface.Parameter("", zxbm);
                            else
                                inputParameters[5] = new ts_yb_interface.Parameter("", gjbm);
                            bool rtn = CX_Interface.Wyyglxx(inputParameters, outparNames, ref outputParameterSets);
                            if (!rtn) MessageBox.Show("接口报错：" + outputParameterSets.Rows[0][0].Value, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            #endregion

                            #region HIS记录
                            if (rtn == true)
                            {
                                parameters = new ParameterEx[6];
                                parameters[0].Text = "@ybjklx";
                                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                                parameters[1].Text = "@yydm";
                                parameters[1].Value = code;
                                parameters[2].Text = "@djy";
                                parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                                parameters[3].Text = "@err_code";
                                parameters[3].ParaDirection = ParameterDirection.Output;
                                parameters[3].DataType = System.Data.DbType.Int32;
                                parameters[3].ParaSize = 100;
                                parameters[4].Text = "@err_text";
                                parameters[4].ParaDirection = ParameterDirection.Output;
                                parameters[4].ParaSize = 100;
                                parameters[5].Text = "@xmly";
                                parameters[5].Value = xmly;
                                InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                                err_code = Convert.ToInt32(parameters[3].Value);
                                err_text = Convert.ToString(parameters[4].Value);
                                if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion

                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;
                    case 10:
                        #region 新长信
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        ts_yb_interface.Parameter[] inputParameters1 = new ts_yb_interface.Parameter[6];
                        ParameterSet outputParameterSets1 = new ParameterSet();
                        string[] outparNames1 = { "errmsg" };


                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region 导入长信
                            code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                            xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                            jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                            pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                            dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                            cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                            pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                            wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                            lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                            xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                            yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                            tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                            gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                            inputParameters1[0] = new ts_yb_interface.Parameter("", zxbm);
                            inputParameters1[1] = new ts_yb_interface.Parameter("", "E");
                            inputParameters1[2] = new ts_yb_interface.Parameter("", yybm);
                            inputParameters1[4] = new ts_yb_interface.Parameter("", "");
                            string parm1 = "";
                            parm1 += code + "\t";
                            parm1 += pm + "\t";
                            parm1 += "" + "\t";
                            parm1 += gg + "\t";
                            parm1 += "" + "\t";
                            parm1 += lsj.ToString() + "\t";
                            parm1 += "";
                            inputParameters1[3] = new ts_yb_interface.Parameter("", parm1);

                            //调用接口
                            bool rtn = false;
                            if (xmly == "1")
                                rtn = CX_Interface_new.Zjyp(inputParameters1, outparNames1, ref outputParameterSets1);
                            else
                                rtn = CX_Interface_new.Zjxm(inputParameters1, outparNames1, ref outputParameterSets1);
                            if (!rtn)
                            {
                                MessageBox.Show("接口报错：" + outputParameterSets1.Rows[0][0].Value, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion

                            #region HIS记录
                            if (rtn == true)
                            {
                                parameters = new ParameterEx[6];
                                parameters[0].Text = "@ybjklx";
                                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                                parameters[1].Text = "@yydm";
                                parameters[1].Value = code;
                                parameters[2].Text = "@djy";
                                parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                                parameters[3].Text = "@err_code";
                                parameters[3].ParaDirection = ParameterDirection.Output;
                                parameters[3].DataType = System.Data.DbType.Int32;
                                parameters[3].ParaSize = 100;
                                parameters[4].Text = "@err_text";
                                parameters[4].ParaDirection = ParameterDirection.Output;
                                parameters[4].ParaSize = 100;
                                parameters[5].Text = "@xmly";
                                parameters[5].Value = xmly;
                                InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                                err_code = Convert.ToInt32(parameters[3].Value);
                                err_text = Convert.ToString(parameters[4].Value);
                                if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion

                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;
                    case 12:
                        #region 老长信城居
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        inputParameters = new ts_yb_interface.Parameter[6];
                        outputParameterSets = new ParameterSet();
                        outparNames = new string[] { "errmsg" };
                        cwfdm = new SystemCfg(7029).Config;
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region  导入长信
                            code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                            xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                            jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                            pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                            dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                            cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                            pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                            wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                            lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                            xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                            yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                            tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                            gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                            string cxlb = xmly;
                            if (tjdxm == cwfdm) cxlb = "3";

                            inputParameters[0] = new ts_yb_interface.Parameter("", zxbm);//医保机构编码(保留位)
                            inputParameters[1] = new ts_yb_interface.Parameter("", yybm);//医院编码(保留位)
                            inputParameters[2] = new ts_yb_interface.Parameter("", cxlb);//类别（1 药品 2诊治项目 3 床位费 0疾病）
                            inputParameters[3] = new ts_yb_interface.Parameter("", code);//医院项目编码
                            inputParameters[4] = new ts_yb_interface.Parameter("", pm);//医院项目名称
                            if (cxlb == "3")
                                inputParameters[5] = new ts_yb_interface.Parameter("", zxbm);
                            else
                                inputParameters[5] = new ts_yb_interface.Parameter("", gjbm);
                            bool rtn = CXCJ_Interface.Wyyglxx(inputParameters, outparNames, ref outputParameterSets);
                            if (!rtn) MessageBox.Show("接口报错：" + outputParameterSets.Rows[0][0].Value, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            #endregion

                            #region HIS记录
                            if (rtn == true)
                            {
                                parameters = new ParameterEx[6];
                                parameters[0].Text = "@ybjklx";
                                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                                parameters[1].Text = "@yydm";
                                parameters[1].Value = code;
                                parameters[2].Text = "@djy";
                                parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                                parameters[3].Text = "@err_code";
                                parameters[3].ParaDirection = ParameterDirection.Output;
                                parameters[3].DataType = System.Data.DbType.Int32;
                                parameters[3].ParaSize = 100;
                                parameters[4].Text = "@err_text";
                                parameters[4].ParaDirection = ParameterDirection.Output;
                                parameters[4].ParaSize = 100;
                                parameters[5].Text = "@xmly";
                                parameters[5].Value = xmly;
                                InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                                err_code = Convert.ToInt32(parameters[3].Value);
                                err_text = Convert.ToString(parameters[4].Value);
                                if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion

                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;
                    case 14:
                    case 16:
                        #region 株洲东软
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        YBDB = Database(Convert.ToInt32(cmbjklx.SelectedValue));
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region 导入医保
                            code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                            xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                            jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                            pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                            dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                            cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                            pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                            wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                            lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                            xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                            yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                            tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                            gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");
                            ////获得剂型编码
                            //tbcx = YBDB.GetDataTable("select top 1 model_code from mt_medi_model where model_name='" + jx.Trim() + "'");
                            //if (tbcx.Rows.Count > 0) jx = Convertor.IsNull(tbcx.Rows[0][0], "");

                            //tbcx = YBDB.GetDataTable("select * from mt_hosp_medi where medi_code='" + code + "'");
                            //if (tbcx.Rows.Count == 0)
                            //{
                            //    ssql = "insert into mt_hosp_medi(medi_code, type_code, medi_name, code_wb, " +
                            //        "code_py, factory, standard, medi_unit,medi_price,MODEL_CODE)values('" + code + "','" +
                            //        yplx + "','" + pm + "','" + wbm + "','" + pym + "','" + cj + "','" + gg + "','" + dw + "'," + lsj + ",'" + jx + "')";
                            //    YBDB.DoCommand(ssql);
                            //}

                            #endregion

                            #region HIS记录
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = tb.Rows[i]["编码"].ToString();
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code == -1) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            #endregion

                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;
                    case 20://Add By HX 2012-08-27
                        #region 网通兴城职

                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        //WTX_Interface.InParameterStruct inStr = new WTX_Interface.InParameterStruct();
                        //modify by Kevin 2012-03-13
                        WTX_Interface.InParameterStruct inStr = WTX_Interface.GetInStruct();
                        outputParameterSets = new ParameterSet();

                        //函数名称   医保地区编码   医院编码   医院项目编码    医院项目名称   剂型   规格   类别   国标码

                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region 导入网通兴
                            code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                            pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                            jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                            xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                            yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                            //string lb = "";  //类别
                            //if (xmly == "1")
                            //    lb = yplx;
                            //else
                            //    lb = yplx;
                            string lb = yplx;
                            gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                            inStr.instr1 = "wddxmzd";  //函数名称
                            inStr.instr2 = zxbm;
                            inStr.instr3 = yybm;
                            inStr.instr4 = code;  //医院项目编码
                            inStr.instr5 = pm;  //医院项目名称
                            inStr.instr6 = jx;  //剂型
                            inStr.instr7 = gg;  //规格
                            inStr.instr8 = lb;  //类别
                            inStr.instr9 = gjbm;  //国标码

                            string str = WTX_Interface.M_InStr(inStr);
                            string outStr = "".PadRight(500, ' ');
                            int result = WTX_Interface.Process_new(str, ref outStr);
                            if (result == 0)
                                MessageBox.Show("接口报错：" + outStr.ToString().Trim(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            //MessageBox.Show(str);
                            //MessageBox.Show(outStr);


                            #endregion

                            #region HIS记录
                            if (result > 0)
                            {
                                parameters = new ParameterEx[6];
                                parameters[0].Text = "@ybjklx";
                                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                                parameters[1].Text = "@yydm";
                                parameters[1].Value = code;
                                parameters[2].Text = "@djy";
                                parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                                parameters[3].Text = "@err_code";
                                parameters[3].ParaDirection = ParameterDirection.Output;
                                parameters[3].DataType = System.Data.DbType.Int32;
                                parameters[3].ParaSize = 100;
                                parameters[4].Text = "@err_text";
                                parameters[4].ParaDirection = ParameterDirection.Output;
                                parameters[4].ParaSize = 100;
                                parameters[5].Text = "@xmly";
                                parameters[5].Value = xmly;
                                InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                                err_code = Convert.ToInt32(parameters[3].Value);
                                err_text = Convert.ToString(parameters[4].Value);
                                if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion
                            pb.Value = pb.Value + 1;

                        }
                        #endregion
                        break;
                    //Add by Kevin 2012-08-13

                    default:
                        #region 没有提供接口的
                        pb.Value = 0;
                        pb.Minimum = 0;
                        pb.Maximum = tb.Rows.Count;
                        //YBDB = Database(Convert.ToInt32(cmbjklx.SelectedValue));
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            #region HIS记录
                            xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = tb.Rows[i]["编码"].ToString();
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code == -1) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            #endregion

                            pb.Value = pb.Value + 1;
                        }
                        #endregion
                        break;

                    //default:
                    //    throw new Exception("没有接口处理方法,不能导出");
                    //    break;
                }

                MessageBox.Show("导出成功", "导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
                butcx_Click(sender, e);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                butexport.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == this.tabPage1)
            {
                butexport.Enabled = true;
                butmodif.Enabled = false;
            }
            else
            {
                butexport.Enabled = false;
                butmodif.Enabled = true;
            }
        }
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }
        private void butmodif_Click(object sender, EventArgs e)
        {
            //try
            //{
            Cursor = PubStaticFun.WaitCursor();
            butexport.Enabled = false;
            DataTable tb = (DataTable)this.dataGridView2.DataSource;
            ParameterEx[] parameters;
            int err_code = -1;
            string err_text = "";
            string ssql = "";
            string zxbm = "";
            string yybm = "";
            ssql = "select * from jc_yblx where ybjklx=" + Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, "")) + "";
            DataTable tb_yblx = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb_yblx.Rows.Count > 0)
            {
                zxbm = Convertor.IsNull(tb_yblx.Rows[0]["insurecentral"], "");
                yybm = Convertor.IsNull(tb_yblx.Rows[0]["hosp_id"], "");
            }
            zxbm = GetIniString(zxbm, "CENTER_ID", configIniFilePath);//Add By Zj 2012-08-08
            bool rtn = false;
            string code = "";
            string xmfl = "";
            string jx = "";
            string pm = "";
            string gg = "";
            string dw = "";
            string cj = "";
            string pym = "";
            string wbm = "";
            decimal lsj = 0;
            string xmly = "0";
            string yplx = "0";
            string tjdxm = "";
            string gjbm = "";
            DataTable tbcx = null;

            SystemLog systemLog = null;

            switch (Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, "")))
            {
                case 7:
                case 9:
                    #region 老的铁路、区医保
                    pb.Value = 0;
                    pb.Minimum = 0;
                    pb.Maximum = tb.Rows.Count;
                    YBDB = Database(Convert.ToInt32(cmbjklx.SelectedValue));
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        #region 导入医保
                        rtn = false;
                        code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                        xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                        jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                        pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                        gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                        dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                        cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                        pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                        wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                        lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                        xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                        yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                        tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                        gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                        if (xmly == "1")
                        {
                            tbcx = YBDB.GetDataTable("select * from his_relation where  his_code='" + code + "' and valid_flag<>0 ");
                            if (tbcx.Rows.Count == 0)
                            {
                                ssql = "update ih_ypml set  mc_name='" + pm + "',mc_type='" + yplx + "',class_id='" + yplx + "'," +
                                    "code_py='" + pym + "',code_wb='" + wbm + "',factory='" + cj + "',model='" + jx + "'," +
                                    "standard='" + gg + "',unit='" + dw + "',price=" + lsj + " where   mc_code='" + code + "'";
                                YBDB.DoCommand(ssql);
                                rtn = true;
                            }
                            else
                            {
                                if (tbcx.Rows[0]["valid_flag"].ToString() == "1" && tbcx.Rows[0]["csbz"].ToString() == "1") tb.Rows[i]["备注"] = "错误,已匹配,取消匹配后才能更新";
                                if (tbcx.Rows[0]["valid_flag"].ToString() == "2" && tbcx.Rows[0]["csbz"].ToString() == "1") tb.Rows[i]["备注"] = "错误,待审核,取消匹配后才能更新";
                                if (tbcx.Rows[0]["valid_flag"].ToString() == "3" && tbcx.Rows[0]["csbz"].ToString() == "1") tb.Rows[i]["备注"] = "错误,未通过审核,取消匹配后才能更新";
                            }
                        }
                        else
                        {
                            tbcx = YBDB.GetDataTable("select * from his_relation where  his_CODE='" + code + "'  and valid_flag<>0 ");
                            if (tbcx.Rows.Count == 0)
                            {
                                ssql = "update lc_craft set item_name='" + pm + "',five_input='" + wbm + "',nature_input='" + pym + "'," +
                                    " item_unit='" + dw + "',item_price=" + lsj + " where item_code='" + code + "'";
                                YBDB.DoCommand(ssql);
                                rtn = true;
                            }
                            else
                            {
                                if (tbcx.Rows[0]["valid_flag"].ToString() == "1" && tbcx.Rows[0]["csbz"].ToString() == "1") tb.Rows[i]["备注"] = "错误,已匹配,取消匹配后才能更新";
                                if (tbcx.Rows[0]["valid_flag"].ToString() == "2" && tbcx.Rows[0]["csbz"].ToString() == "1") tb.Rows[i]["备注"] = "错误,待审核,取消匹配后才能更新";
                                if (tbcx.Rows[0]["valid_flag"].ToString() == "3" && tbcx.Rows[0]["csbz"].ToString() == "1") tb.Rows[i]["备注"] = "错误,未通过审核,取消匹配后才能更新";
                            }
                        }

                        #endregion

                        #region HIS记录
                        if (rtn == true)
                        {
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = code;
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code == -1) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

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
                    YBDB = Database(Convert.ToInt32(cmbjklx.SelectedValue));
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        #region 导入医保
                        rtn = false;
                        code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                        xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                        jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                        pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                        if (Convertor.IsNull(tb.Rows[i]["规格"], "").Length > 5)
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "").Substring(0, 5);
                        else
                            gg = Convertor.IsNull(tb.Rows[i]["规格"], "");

                        dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                        cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                        pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                        wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                        lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                        xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                        yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                        tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                        gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");
                        yplx = "0";
                        if (tjdxm == "01") yplx = "1";
                        if (tjdxm == "02") yplx = "2";
                        if (tjdxm == "03") yplx = "3";
                        //获得剂型编码
                        tbcx = YBDB.GetDataTable("select top 1 MODEL_code from mt_medi_model where model_name='" + jx.Trim() + "'");
                        if (tbcx.Rows.Count > 0) jx = Convertor.IsNull(tbcx.Rows[0][0], "");
                        ssql = "select * from BS_CATALOG_MATCH where HOSP_code='" + code + "'";
                        //if (Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, "")) != 8)//Add By Zj 2012-10-22 除东软医保全部加中心 Modify By Zj 2013-01-22 东软也会存在多个中心，所以加中心判断
                        ssql += "  and center_id=" + zxbm + " ";

                        tbcx = YBDB.GetDataTable(ssql);
                        if (tbcx.Rows.Count == 0)
                        {
                            ssql = "update mt_hosp_medi set type_code='" + yplx + "', medi_name='" + pm + "', code_wb='" + wbm + "', " +
                                "code_py='" + pym + "', factory='" + cj + "', standard='" + gg + "', medi_unit='" + dw + "'," +
                                " medi_price=" + lsj + ",MODEL_CODE='" + jx + "' where medi_code='" + code + "'";
                            int ncount = YBDB.DoCommand(ssql);
                            if (ncount > 0)
                            {
                                systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "修改医保HIS目录库", pm + "  " + code, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, _menuTag.ModuleId);
                                systemLog.Save();
                                systemLog = null;
                                rtn = true;
                            }
                        }
                        else
                        {
                           // tb.Rows[i]["备注"] = "错误,已匹配,取消匹配后才能更新";
                            //Modify By Kevin 2013-09-26 如果发现有记录再查看是否是失效记录,如果是失效记录也允许他修改HIS目录
                            //Begin
                            ssql = " SELECT * FROM BS_CATALOG_MATCH WHERE HOSP_CODE = '" + code + "' AND CENTER_ID = " + zxbm + " AND EXPIRE_DATE > GETDATE()";  //有效
                            tbcx = YBDB.GetDataTable(ssql);
                            if (tbcx.Rows.Count == 0)  //确保只有一条记录，如果是1条记录就去修改MT_HOSP_MEDI 如果有多条记录，因为不能确定是否申请作废，则手工处理
                            {
                                ssql = "update mt_hosp_medi set type_code='" + yplx + "', medi_name='" + pm + "', code_wb='" + wbm + "', " +
                                    "code_py='" + pym + "', factory='" + cj + "', standard='" + gg + "', medi_unit='" + dw + "'," +
                                    " medi_price=" + lsj + ",MODEL_CODE='" + jx + "' where medi_code='" + code + "'";
                                int ncount = YBDB.DoCommand(ssql);
                                if (ncount > 0)
                                {
                                    systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "修改医保HIS目录库", pm + "  " + code, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, _menuTag.ModuleId);
                                    systemLog.Save();
                                    systemLog = null;
                                    rtn = true;
                                }
                            }
                            else
                            {
                                tb.Rows[i]["备注"] = "错误,已匹配,取消匹配后才能更新";
                            }
                            //End 2013-09-26

                        }

                        #endregion

                        #region HIS记录
                        if (rtn == true)
                        {
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = code;
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        pb.Value = pb.Value + 1;
                    }
                    #endregion
                    break;
                case 1:
                    #region 老长信
                    pb.Value = 0;
                    pb.Minimum = 0;
                    pb.Maximum = tb.Rows.Count;
                    ts_yb_interface.Parameter[] inputParameters = new ts_yb_interface.Parameter[6];
                    ParameterSet outputParameterSets = new ParameterSet();
                    string[] outparNames = { "errmsg" };
                    string cwfdm = new SystemCfg(7029).Config;
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        #region  导入长信
                        code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                        xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                        jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                        pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                        gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                        dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                        cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                        pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                        wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                        lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                        xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                        yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                        tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                        gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                        string cxlb = xmly;
                        if (tjdxm == cwfdm) cxlb = "3";

                        inputParameters[0] = new ts_yb_interface.Parameter("", zxbm);//医保机构编码(保留位)
                        inputParameters[1] = new ts_yb_interface.Parameter("", yybm);//医院编码(保留位)
                        inputParameters[2] = new ts_yb_interface.Parameter("", cxlb);//类别（1 药品 2诊治项目 3 床位费 0疾病）
                        inputParameters[3] = new ts_yb_interface.Parameter("", code);//医院项目编码
                        inputParameters[4] = new ts_yb_interface.Parameter("", pm);//医院项目名称
                        if (cxlb == "3")
                            inputParameters[5] = new ts_yb_interface.Parameter("", zxbm);
                        else
                            inputParameters[5] = new ts_yb_interface.Parameter("", gjbm);
                        rtn = CX_Interface.Wyyglxx(inputParameters, outparNames, ref outputParameterSets);
                        if (!rtn) MessageBox.Show("接口报错：" + outputParameterSets.Rows[0][0].Value, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        #endregion

                        #region HIS记录
                        if (rtn == true)
                        {
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = code;
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        pb.Value = pb.Value + 1;
                    }
                    #endregion
                    break;
                case 10:
                    #region 新长信
                    pb.Value = 0;
                    pb.Minimum = 0;
                    pb.Maximum = tb.Rows.Count;
                    ts_yb_interface.Parameter[] inputParameters1 = new ts_yb_interface.Parameter[6];
                    ParameterSet outputParameterSets1 = new ParameterSet();
                    string[] outparNames1 = { "errmsg" };


                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        #region 导入长信
                        code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                        xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                        jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                        pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                        gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                        dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                        cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                        pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                        wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                        lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                        xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                        yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                        tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                        gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                        inputParameters1[0] = new ts_yb_interface.Parameter("", zxbm);
                        inputParameters1[1] = new ts_yb_interface.Parameter("", "E");
                        inputParameters1[2] = new ts_yb_interface.Parameter("", yybm);
                        inputParameters1[4] = new ts_yb_interface.Parameter("", "");
                        string parm1 = "";
                        parm1 += code + "\t";
                        parm1 += pm + "\t";
                        parm1 += "" + "\t";
                        parm1 += gg + "\t";
                        parm1 += "" + "\t";
                        parm1 += lsj.ToString() + "\t";
                        parm1 += "";
                        inputParameters1[3] = new ts_yb_interface.Parameter("", parm1);

                        //调用接口
                        rtn = false;
                        if (xmly == "1")
                            rtn = CX_Interface_new.Zjyp(inputParameters1, outparNames1, ref outputParameterSets1);
                        else
                            rtn = CX_Interface_new.Zjxm(inputParameters1, outparNames1, ref outputParameterSets1);
                        if (!rtn)
                        {
                            MessageBox.Show("接口报错：" + outputParameterSets1.Rows[0][0].Value, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region HIS记录
                        if (rtn == true)
                        {
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = code;
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        pb.Value = pb.Value + 1;
                    }
                    #endregion
                    break;
                case 20:
                    #region 网通兴
                    pb.Value = 0;
                    pb.Minimum = 0;
                    pb.Maximum = tb.Rows.Count;
                    WTX_Interface.InParameterStruct inStr = WTX_Interface.GetInStruct();
                    outputParameterSets = new ParameterSet();
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        #region 导入网通兴
                        code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                        pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                        jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                        gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                        xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                        yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                        string lb = "";  //类别
                        if (xmly == "1")
                            lb = yplx;
                        else
                            lb = xmly;
                        gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                        inStr.instr1 = "Uddxmzd";  //函数名称
                        inStr.instr2 = zxbm;
                        inStr.instr3 = yybm;
                        inStr.instr4 = code;  //医院项目编码
                        inStr.instr5 = pm;  //医院项目名称
                        inStr.instr6 = jx;  //剂型
                        inStr.instr7 = gg;  //规格
                        inStr.instr8 = lb;  //类别
                        inStr.instr9 = gjbm;  //国标码
                        //MessageBox.Show(zxbm + "|" + yybm + "|" + code + "|" + pm + "|" + jx + "|" + gg + "|" + lb + "|" + gjbm + "|");
                        string str = WTX_Interface.M_InStr(inStr);
                        //string str = M_InStr(inStr);
                        //MessageBox.Show("1");
                        string outStr = "".PadRight(500, ' ');
                        int result = WTX_Interface.Process_new(str, ref outStr);
                        if (result == 0)
                            MessageBox.Show("接口报错：" + outStr.ToString().Trim(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        #endregion

                        //MessageBox.Show("2");

                        #region HIS记录
                        if (result > 0)
                        {
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = code;
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            //MessageBox.Show("3");
                        }
                        #endregion

                        pb.Value = pb.Value + 1;
                    }
                    #endregion
                    break;
                default:
                    #region 其他医保
                    pb.Value = 0;
                    pb.Minimum = 0;
                    pb.Maximum = tb.Rows.Count;
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        #region 导入医保
                        rtn = false;
                        code = Convertor.IsNull(tb.Rows[i]["编码"], "");
                        xmfl = Convertor.IsNull(tb.Rows[i]["类型"], "");
                        jx = Convertor.IsNull(tb.Rows[i]["剂型"], "");
                        pm = Convertor.IsNull(tb.Rows[i]["项目名称"], "");
                        gg = Convertor.IsNull(tb.Rows[i]["规格"], "");
                        dw = Convertor.IsNull(tb.Rows[i]["单位"], "");
                        cj = Convertor.IsNull(tb.Rows[i]["厂家"], "");
                        pym = Convertor.IsNull(tb.Rows[i]["拼音码"], "");
                        wbm = Convertor.IsNull(tb.Rows[i]["五笔码"], "");
                        lsj = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                        xmly = Convertor.IsNull(tb.Rows[i]["xmly"], "");
                        yplx = Convertor.IsNull(tb.Rows[i]["yplx"], "");
                        tjdxm = Convertor.IsNull(tb.Rows[i]["统计大项"], "");
                        gjbm = Convertor.IsNull(tb.Rows[i]["标准编码"], "");

                        tbcx = InstanceForm.BDatabase.GetDataTable("select * from jc_yb_ppgxsj a,jc_yblx b where a.yblx=b.id and ybjklx=" + Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, "")) + " and yydm='" + code + "' and bscbz=0 and bzt in(0,1) ");
                        if (tbcx.Rows.Count == 0)
                        {
                            rtn = true;
                        }
                        else
                        {
                            tb.Rows[i]["备注"] = "错误,已匹配,取消匹配后才能更新";
                        }

                        #endregion

                        #region HIS记录
                        if (rtn == true)
                        {
                            parameters = new ParameterEx[6];
                            parameters[0].Text = "@ybjklx";
                            parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbjklx.SelectedValue, ""));
                            parameters[1].Text = "@yydm";
                            parameters[1].Value = code;
                            parameters[2].Text = "@djy";
                            parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;
                            parameters[3].Text = "@err_code";
                            parameters[3].ParaDirection = ParameterDirection.Output;
                            parameters[3].DataType = System.Data.DbType.Int32;
                            parameters[3].ParaSize = 100;
                            parameters[4].Text = "@err_text";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@xmly";
                            parameters[5].Value = xmly;
                            InstanceForm.BDatabase.DoCommand("SP_YB_InsertUpdate_Medi", parameters, 30);
                            err_code = Convert.ToInt32(parameters[3].Value);
                            err_text = Convert.ToString(parameters[4].Value);
                            if (err_code != 0) MessageBox.Show(err_text + " 请点[确定]续续导入!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        pb.Value = pb.Value + 1;
                    }
                    #endregion
                    break;
            }

            MessageBox.Show("导出成功", "导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor = Cursors.Default;
            //butcx_Click(sender, e);

            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    butexport.Enabled = true;
            //    Cursor = Cursors.Default;
            //}
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dv;
                if (tabControl1.SelectedTab == tabPage1)
                    dv = dataGridView1;
                else
                    dv = dataGridView2;

                DataTable tb = (DataTable)dv.DataSource;

                // 创建Excel对象                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= dv.ColumnCount - 1; i++)
                {
                    if (dv.Columns[i].Visible == true)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = tabControl1.SelectedTab == tabPage1 ? "医院新增目录" : "医院修改目录";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= dv.ColumnCount - 1; i++)
                {
                    if (dv.Columns[i].Visible == true)
                        objData[0, colIndex++] = dv.Columns[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= dv.ColumnCount - 1; j++)
                    {
                        if (dv.Columns[j].Visible == true)
                        {

                            objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }




    }
}