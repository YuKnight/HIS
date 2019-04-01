using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using ts_mzys_class;

namespace ts_mzys_yjsqd
{
    public partial class Frmhysqd : Form
    {

        public string ddd;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable _jcItemTB;
        public struct Cf
        {
            public Guid  brxxid;
            public Guid  ghxxid;
            public Guid  jzid;
            public string brxm;
            public string xb;
            public string nl;
            public string gzdw;
            public string lxfs;
            public string tz;
            public string mzh;
            public Guid  yjsqid;
            public Guid  yzid;
            public int sqys ;
            public int sqks ;
        }
        public bool Issfy = false;
        public bool IsDoc = false;
        public bool IsXg = false; //对于修改项目,不需要将老的医技项目填充到网格控件上 Add by zp 2013-10-13 
        
        public Cf Dqcf = new Cf();
        public DataTable dt_mzsf_order;

        public SystemCfg _cfg3087 = new SystemCfg(3087);//化验项目是否根据化验分类进行自动分方0不自动分 1自动分 默认为0 Add by zp
        public Frmhysqd(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
           
            this.Text = _chineseName;
            //add by tany 2013-8-13
            this.control_jysq1.Close += new Ts_zyys_jysq.DelClose(control_jysq1_Close);
            this.control_jysq1.typely = Ts_zyys_jysq.Typely.门诊;         
        }


        //private void SetJydt(DataRow drs,decimal je,int zxksid)
        //{
        //    DataTable tbjy = CreateYjDt();
        //    tbjy.Rows.Add(drs.ItemArray);
        //     mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbjy, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 1,
        //         DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(),InstanceForm.BCurrentUser.EmployeeId, 
        //         InstanceForm.BCurrentDept.DeptId, control_jysq1.richTextBoxEx1.Text, control_jysq1.TextLczd.textBox1.Text.ToString(),
        //        zxksid, control_jysq1.richTextBoxEx2.Text, 0, je, 0, Issfy, InstanceForm.BDatabase);
        //        tbjy.Clear();   
        //}

        private DataTable CreateYjDt()
        {
            DataTable tbjy = new DataTable();
            tbjy.Columns.Add("套餐id");
            tbjy.Columns.Add("医嘱项目id");
            tbjy.Columns.Add("名称");
            tbjy.Columns.Add("单价");
            tbjy.Columns.Add("数量");
            tbjy.Columns.Add("金额");
            tbjy.Columns.Add("单位");
            tbjy.Columns.Add("标本");
            tbjy.Columns.Add("频次");
            tbjy.Columns.Add("附加说明");
            tbjy.Columns.Add("项目分类");
            return tbjy;
        }

        /// <summary>
        /// 点提交，保存数据，并关闭窗口
        /// </summary>
        void control_jysq1_Close()
        {
            try
            {
                //DataSet ds_jy = new DataSet();
                DataTable tbmx = ((DataTable)control_jysq1.dataGridView1.DataSource).Copy();
                DataTable tb_hjinfo = new DataTable();
                if (tbmx == null) return;

                if (tbmx.Rows.Count == 0)
                {
                    MessageBox.Show("请选择相应的项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbmx.Rows.Count == 1)
                {
                    if (tbmx.Rows[0]["orderid"].ToString() == "0")
                    {
                        MessageBox.Show("请选择相应的项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (Dqcf.yzid != Guid.Empty) //如果是更新 需要判断当前明细的执行科室和原有的执行科室 不同则提示 并返回
                    tb_hjinfo = mz_hj.GetHjInfo(Dqcf.yzid, InstanceForm.BDatabase);
                double price = 0;
                DataTable tbjy = CreateYjDt();
                try
                {
                    tbmx.Columns.Add("项目分类");
                    if (_cfg3087.Config.Trim()=="1")
                    {
                        for (int y = 0; y < tbmx.Rows.Count; y++)
                        {
                            string sql = "select HYLXID from JC_ASSAY a join JC_JCCLASSDICTION b on a.HYLXID=b.ID where YZID=" + tbmx.Rows[y]["orderid"].ToString() + "";
                            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                            if (tb.Rows.Count > 0)
                            {
                                tbmx.Rows[y]["项目分类"] = tb.Rows[0]["HYLXID"].ToString();
                            }
                        }
                        if (tbmx.Rows.Count > 1)
                        {
                            DataRow[] _row = tbmx.Copy().Select("", "zksid desc,项目分类");
                            tbmx.Clear();
                            for (int j = 0; j < _row.Length; j++)
                            {
                                tbmx.Rows.Add(_row[j].ItemArray);
                            }
                        }
                    }
                }
                catch { }
                if (tbmx.Rows.Count > 1)
                {
                    //不循环最后一行
                    for (int i = 0; i < tbmx.Rows.Count - 1; i++)
                    {
                        DataRow dr = tbjy.NewRow();
                        dr["医嘱项目id"] = tbmx.Rows[i]["orderid"].ToString();
                        dr["名称"] = tbmx.Rows[i]["name"].ToString();
                        dr["单价"] = tbmx.Rows[i]["dj"].ToString();
                        dr["数量"] = tbmx.Rows[i]["sl"].ToString();
                        dr["单位"] = tbmx.Rows[i]["dw"].ToString();
                        dr["金额"] = tbmx.Rows[i]["je"].ToString();
                        dr["频次"] = "st";
                        dr["标本"] = tbmx.Rows[i]["bbmc"].ToString();
                        dr["附加说明"] = tbmx.Rows[i]["fjsm"].ToString();
                        DataTable dttc = mzys_yjsq.GetYjTcId(tbmx.Rows[i]["orderid"].ToString(), InstanceForm.BDatabase);
                        if (dttc.Rows.Count > 0 && int.Parse(dttc.Rows[0]["TCID"].ToString())>0)
                            dr["套餐id"] = dttc.Rows[0]["TCID"].ToString(); 
                        tbjy.Rows.Add(dr);

                       

                        if (Dqcf.yzid != Guid.Empty && tb_hjinfo.Rows.Count>0) //如果是更新 需要判断当前明细的执行科室和原有的执行科室 不同则提示 并返回
                        {
                            if (tbmx.Rows[i]["zksid"].ToString().Trim() != tb_hjinfo.Rows[0]["zxks"].ToString().Trim())
                            {
                                MessageBox.Show("当前执行科室与原处方执行科室不同!不允许修改!", "提示");
                                return;
                            }
                        }
                        //价格累加
                        price = price + Convert.ToDouble(tbmx.Rows[i]["je"].ToString());
                        if (i <= tbmx.Rows.Count - 2)
                        {
                            if (Convertor.IsNull(dr["套餐id"], "") != "")//或者有相同的套餐
                            {
                                /*如果该行的套餐在其他行也有 则分方*/
                                DataRow[] drs = tbjy.Select(string.Format("套餐id={0}", dr["套餐id"]));
                                if (drs.Length > 1)
                                {
                                    tbjy.Rows.RemoveAt(tbjy.Rows.Count - 1);
                                    mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbjy, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 1, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(),
                                        Dqcf.sqys ==0 ? InstanceForm.BCurrentUser.EmployeeId : Dqcf.sqys,
                                        Dqcf.sqks == 0 ? InstanceForm.BCurrentDept.DeptId : Dqcf.sqks, control_jysq1.richTextBoxEx1.Text, control_jysq1.TextLczd.textBox1.Text.ToString(), Convert.ToInt32(tbmx.Rows[i]["zksid"].ToString()),
                                                                               control_jysq1.richTextBoxEx2.Text, 0, Convert.ToDecimal(price), 0, Issfy, InstanceForm.BDatabase);
                                    tbjy.Clear();
                                    price = 0;
                                    i--;
                                }
                            }

                            //如果不是倒数第二行，且当前行的执行科室与下一行执行科室不同
                            if (tbmx.Rows[i]["zksid"].ToString() != tbmx.Rows[i + 1]["zksid"].ToString()||
                                  tbmx.Rows[i]["项目分类"].ToString() != tbmx.Rows[i + 1]["项目分类"].ToString())
                            {
                                mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbjy, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 1, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(),
                                             Dqcf.sqys == 0 ? InstanceForm.BCurrentUser.EmployeeId : Dqcf.sqys ,
                                        Dqcf.sqks == 0 ? InstanceForm.BCurrentDept.DeptId : Dqcf.sqks , control_jysq1.richTextBoxEx1.Text , control_jysq1.TextLczd.textBox1.Text.ToString() , Convert.ToInt32( tbmx.Rows[i]["zksid"].ToString() ) ,
                                             control_jysq1.richTextBoxEx2.Text, 0, Convert.ToDecimal(price), 0, Issfy, InstanceForm.BDatabase);
                                tbjy.Clear();
                                price = 0;
                            }
                        }
                        else if (i == tbmx.Rows.Count - 1)
                        {
                            mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbjy, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 1, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(),
                                         Dqcf.sqys == 0 ? InstanceForm.BCurrentUser.EmployeeId : Dqcf.sqys ,
                                        Dqcf.sqks == 0 ? InstanceForm.BCurrentDept.DeptId : Dqcf.sqks , control_jysq1.richTextBoxEx1.Text , control_jysq1.TextLczd.textBox1.Text.ToString() , Convert.ToInt32( tbmx.Rows[i]["zksid"].ToString() ) ,
                                          control_jysq1.richTextBoxEx2.Text, 0, Convert.ToDecimal(price), 0, Issfy, InstanceForm.BDatabase);
                            tbjy.Clear();
                            price = 0;
                        }   
                    }
                }
                //修改时，为一行的情况执行
                else if (tbmx.Rows.Count == 1)
                {
                    //Modfiy By zp 2013-10-23 限制执行科室一致
                    if (Dqcf.yzid != Guid.Empty && tb_hjinfo.Rows.Count>0) //如果是更新 需要判断当前明细的执行科室和原有的执行科室 不同则提示 并返回
                    {
                        if (tbmx.Rows[0]["zksid"].ToString().Trim() != tb_hjinfo.Rows[0]["zxks"].ToString().Trim())
                        {
                            MessageBox.Show("当前执行科室与原处方执行科室不同!不允许修改!", "提示");
                            return;
                        }
                    }
                    DataRow dr = tbjy.NewRow();
                    dr["医嘱项目id"] = tbmx.Rows[0]["orderid"].ToString();
                    dr["名称"] = tbmx.Rows[0]["name"].ToString();
                    dr["单价"] = tbmx.Rows[0]["dj"].ToString();
                    dr["数量"] = tbmx.Rows[0]["sl"].ToString();
                    dr["单位"] = tbmx.Rows[0]["dw"].ToString();
                    dr["金额"] = tbmx.Rows[0]["je"].ToString();
                    dr["频次"] = "st";
                    dr["标本"] = tbmx.Rows[0]["bbmc"].ToString();
                    dr["附加说明"] = tbmx.Rows[0]["fjsm"].ToString();
                    DataTable dttc = mzys_yjsq.GetYjTcId(tbmx.Rows[0]["orderid"].ToString(), InstanceForm.BDatabase);
                    if (dttc.Rows.Count > 0)
                        dr["套餐id"] = dttc.Rows[0]["TCID"].ToString(); 
                    tbjy.Rows.Add(dr);
                    //价格累加
                    price = price + Convert.ToDouble(tbmx.Rows[0]["je"].ToString());
                    mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbjy, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 1, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(),
                                     Dqcf.sqys == 0 ? InstanceForm.BCurrentUser.EmployeeId : Dqcf.sqys ,
                                        Dqcf.sqks == 0 ? InstanceForm.BCurrentDept.DeptId : Dqcf.sqks , control_jysq1.richTextBoxEx1.Text , control_jysq1.TextLczd.textBox1.Text.ToString() , Convert.ToInt32( tbmx.Rows[0]["zksid"].ToString() ) ,
                                     control_jysq1.richTextBoxEx2.Text, 0, Convert.ToDecimal(price), 0, Issfy, InstanceForm.BDatabase);
                    tbjy.Clear();
                    price = 0;
                }
        
                //if (Dqcf.yjsqid == Guid.Empty)
                //    MessageBox.Show("申请发送成功");
                //else
                //    MessageBox.Show("申请修改成功");
                this.Close();
            }

            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmjcsqd_Load(object sender, EventArgs e)
        {

            //string ssql = "select '' 名称,0 医嘱项目id,0 单价,0 数量,'' 单位,0 金额 ,0 套餐id,'' 频次 where 1=2";
            //DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            //this.dataGridView1.DataSource = tb;

           // LoadJCDeptDic();
            //初始化病人基础信息
            try
            {
                lblxm.Text = Dqcf.brxm;
                lblxb.Text = Dqcf.xb;
                lblnl.Text = Dqcf.nl;
                lblgzdw.Text = Dqcf.gzdw;
                lbllxdh.Text = Dqcf.lxfs;
                lbltz.Text = Dqcf.tz;
                lblmzh.Text = Dqcf.mzh;

                if (Issfy)
                    this.control_jysq1.IsSfy = true;
                if (Dqcf.yjsqid != Guid.Empty && (!IsXg)) //修改医技申请项目
                    SetYjControlByUpdate();
                if (dt_mzsf_order!=null)
                    SetYjControl();

                this.ActiveControl = this.control_jysq1.textBoxEx1;
                this.control_jysq1.textBoxEx1.Focus();
            }
            catch (Exception ea)
            {
                MessageBox.Show("初始化窗口出现错误!" + ea.Message);
            }
        }
        //通过收费项目id获取医嘱记录填充界面 (收费界面开医技项目所调用)
        private void SetYjControl()
        {
            /*通过项目id获取医技项目填充到dgv上*/
            //control_jysq1.Xg = true;  //此处屏蔽掉Xg=true  可以让用户选择多项医技项目
            DataTable tab = dt_mzsf_order;
            if (tab.Rows.Count == 0) return;
            //总金额
            double totalprice = 0;
            //项目表
            DataTable dtxm = (DataTable)control_jysq1.dataGridView1.DataSource;
            for (int i = 0; i < tab.Rows.Count; i++)
            {
              //  control_jysq1.IsSfy = true;

                DataRow dr = dtxm.NewRow();
                dr["checked"] = "1";
                dr["name"] = tab.Rows[i]["ORDER_NAME"].ToString();
             
                dr["sl"] = 1;
                dr["dw"] = tab.Rows[i]["ORDER_UNIT"].ToString();
                if (!string.IsNullOrEmpty(tab.Rows[i]["PRICE"].ToString()))
                    dr["dj"] = decimal.Parse(tab.Rows[i]["PRICE"].ToString());
                if (!string.IsNullOrEmpty(tab.Rows[i]["PRICE"].ToString()))
                {
                    dr["je"] = decimal.Parse(tab.Rows[i]["PRICE"].ToString());
                    totalprice = totalprice + Convert.ToDouble(tab.Rows[i]["PRICE"].ToString());
                }
                else
                    dr["je"] = "0.00";
                dr["fjsm"] = "";
                if (!string.IsNullOrEmpty(Convertor.IsNull(tab.Rows[i]["DEFAULT_DEPT"], "")))
                {
                    dr["zksid"] = tab.Rows[i]["DEFAULT_DEPT"].ToString();
                    dr["zxksmc"] = tab.Rows[i]["执行科室名称"].ToString();
                }
                if (!string.IsNullOrEmpty(tab.Rows[i]["BBID"].ToString()))
                {
                    dr["bb"] = Convert.ToInt32(tab.Rows[i]["BBID"].ToString());
                    dr["bbmc"] = tab.Rows[i]["SAMP_NAME"].ToString();
                }

                dr["orderid"] = tab.Rows[i]["HOITEM_ID"].ToString();
                dr["fjsm"] = "";
                dtxm.Rows.Add(dr);
            }
            //获得附加说明
            control_jysq1.dataGridView1.DataSource = dtxm;
        }
        private void SetYjControlByUpdate()
        {
            //if(IsDoc)//医生站打开Xg不为true   如果为医生处方录入界面开 则默认组件为修改状态 允许选择多项目
            //    control_jysq1.Xg = true;
            DataTable tab = mzys_yjsq.GetYjsqInfo(Dqcf.yjsqid, InstanceForm.BDatabase);
            //如果修改
            if (tab.Rows.Count > 0)
            {
                //control_jysq1.Xg = true;
                //总金额
                double totalprice = 0;
                //项目表
                DataTable dtxm = (DataTable)control_jysq1.dataGridView1.DataSource;
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    DataRow dr = dtxm.NewRow();
                    dr["checked"] = "1";
                    dr["name"] = tab.Rows[i]["名称"].ToString();
                    if (!string.IsNullOrEmpty(tab.Rows[i]["标本ID"].ToString()))
                        dr["bb"] = Convert.ToInt32(tab.Rows[i]["标本ID"].ToString());
                    if (!string.IsNullOrEmpty(tab.Rows[i]["数量"].ToString()))
                        dr["sl"] = Convert.ToDouble(tab.Rows[i]["数量"].ToString());
                    dr["dw"] = tab.Rows[i]["单位"].ToString();
                    if (!string.IsNullOrEmpty(tab.Rows[i]["单价"].ToString()))
                        dr["dj"] = decimal.Parse(tab.Rows[i]["单价"].ToString());
                    if (!string.IsNullOrEmpty(tab.Rows[i]["金额"].ToString()))
                    {
                        dr["je"] = decimal.Parse(tab.Rows[i]["金额"].ToString());
                        totalprice = totalprice + Convert.ToDouble(tab.Rows[i]["金额"].ToString());
                    }
                    else
                        dr["je"] = "0.00";
                    dr["fjsm"] = "";
                    dr["zksid"] = tab.Rows[i]["执行科室"].ToString();
                    dr["zxksmc"] = tab.Rows[i]["执行科室名称"].ToString();
                    dr["bbmc"] = tab.Rows[i]["标本名称"].ToString();
                    dr["orderid"] = tab.Rows[i]["医嘱项目id"].ToString();
                    dr["fjsm"] = tab.Rows[i]["备注"].ToString();
                    dtxm.Rows.Add(dr);
                }
                //获得附加说明
                control_jysq1.dataGridView1.DataSource = dtxm;
                //this.dataGridView1.DataSource = tab;
                DataTable tab1 = mzys_yjsq.Select_E(Dqcf.yjsqid, InstanceForm.BDatabase);
                if (tab1.Rows.Count == 1)
                {
                    control_jysq1.richTextBoxEx1.Text = tab1.Rows[0]["bsjc"].ToString();
                    control_jysq1.TextLczd.Text = tab1.Rows[0]["lczd"].ToString();
                    control_jysq1.richTextBoxEx2.Text = tab1.Rows[0]["zysx"].ToString();
                }
            }
        }



        ///// <summary>
        ///// 加载检查科室词典
        ///// </summary>
        //private void LoadJCDeptDic()
        //{
        //    //部门词典
        //    DataTable tb = PubStaticFun.GetBaseTableInfo(InstanceForm.BDatabase, SelectBaseTable.BASE_DEPT_PROPERTY_HY);
        //    if (tb != null)
        //    {
        //        if (tb.Rows.Count > 0)
        //        {
        //            //add by zouchihua 2013-6-17 增加全部选项
        //            DataRow r = tb.NewRow();
        //            r["ITEMCODE"] = 0;
        //            r["ITEMNAME"] = "全部";
        //            tb.Rows.Add(r);
        //            tb.TableName = "JC_DEPT_DICTIONARY";

        //           // _dataSet.Tables.Add(tb);
        //            cmbjcks.ValueMember = "ITEMCODE";
        //            cmbjcks.DisplayMember = "ITEMNAME";
        //            cmbjcks.DataSource = tb;// _dataSet.Tables["JC_DEPT_DICTIONARY"];
        //            cmbjcks.SelectedIndex = tb.Rows.Count-1;
        //        }
        //    }

        //}

        //private DataTable GetItems(int type, long statItemID, long deptID)
        //{
        //    ParameterEx[] parameters = new ParameterEx[5];
        //    parameters[0].Value = type;
        //    parameters[1].Value = statItemID;
        //    parameters[2].Value = deptID;
        //    parameters[3].Value = "";
        //    parameters[4].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

        //    parameters[0].Text = "@type";
        //    parameters[1].Text = "@statItem_ID";
        //    parameters[2].Text = "@deptID";
        //    parameters[3].Text = "@bm";
        //    parameters[4].Text = "@jgbm";

        //    try
        //    {
        //        DataTable myTb = InstanceForm.BDatabase.GetDataTable("SP_MZYS_GET_JCHYITEMS", parameters, 30);
        //        return myTb;
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return null;
        //    }
        //}

        //private void cmbDeptJC_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ParameterEx[] parameters = new ParameterEx[3];
        //        parameters[0].Value = 1;
        //        parameters[1].Value = Convert.ToInt64(cmbjcks.SelectedValue);
        //        parameters[2].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

        //        parameters[0].Text = "@type";
        //        parameters[1].Text = "@deptid";
        //        parameters[2].Text = "@jgbm";

        //        DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZYS_GET_JCHYCLASS ", parameters, 30);
        //        DataRow dr = tb.NewRow();
        //        dr["ITEMCODE"] = 0;
        //        dr["ITEMNAME"] = "全部";
        //        tb.Rows.Add(dr);
        //        //数据绑定
        //        cmbClassJC.DisplayMember = "ITEMNAME";
        //        cmbClassJC.ValueMember = "ITEMCODE";
        //        cmbClassJC.DataSource = tb;
        //        if (cmbjcks.Text.Trim() == "全部")
        //            cmbClassJC.SelectedIndex = tb.Rows.Count - 1;
        //        else
        //            cmbClassJC.SelectedIndex = 0;
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}



        //private void SelectXm(int type, int statitem_id, int zxks, string bm)
        //{
        //    try
        //    {
        //        ParameterEx[] parameters = new ParameterEx[5];

        //        parameters[0].Text = "@type";
        //        parameters[0].Value = type;

        //        parameters[1].Text = "@statitem_id";
        //        parameters[1].Value = statitem_id;

        //        parameters[2].Text = "@DEPTID";
        //        parameters[2].Value = zxks;

        //        parameters[3].Text = "@bm";
        //        parameters[3].Value = bm;

        //        parameters[4].Text = "@jgbm";
        //        parameters[4].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

        //        DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZYS_GET_JCHYITEMS", parameters, 30);
        //        //dataGridView2.DataSource = tb;
        //    }
        //    catch (System.Exception err)
        //    {
        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void cmbClassHY_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SelectXm(1,
        //        Convert.ToInt32(Convertor.IsNull(cmbClassJC.SelectedValue, "0")),
        //        Convert.ToInt32(Convertor.IsNull(cmbjcks.SelectedValue, "0")), "");
        //    DataTable tb = (DataTable)this.dataGridView1.DataSource;
        //    tb.Rows.Clear();
        //}

        //private void txtdm_TextChanged(object sender, EventArgs e)
        //{
        //    SelectXm(1,
        //    Convert.ToInt32(Convertor.IsNull(cmbClassJC.SelectedValue, "0")),
        //    Convert.ToInt32(Convertor.IsNull(cmbjcks.SelectedValue, "0")), txtdm.Text.Trim());
        //    DataTable tb = (DataTable)this.dataGridView1.DataSource;
        //    tb.Rows.Clear();

        //    string ssql = "select name,comment from JC_JCCLASSDICTION where name='" + cmbClassJC.Text.Trim() + "'";
        //    DataTable tbitem = InstanceForm.BDatabase.GetDataTable(ssql);
        //    cmbbw.Items.Clear();
        //    if (tbitem.Rows.Count > 0)
        //    {
        //        string[] arr = tbitem.Rows[0]["comment"].ToString().Split(new char[1] { '/' });
        //        cmbbw.Items.AddRange(arr);
        //    }

        //}

        //private void dataGridView2_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //DataTable tb = (DataTable)this.dataGridView2.DataSource;
        //        //if (tb.Rows.Count == 0) return;
        //        //int nrow = this.dataGridView2.CurrentCell.RowIndex;
        //        //DataTable tbxm = (DataTable)this.dataGridView1.DataSource;


        //        string yzid =tb.Rows[nrow]["yzid"].ToString();

        //        if (Dqcf.yjsqid !=Guid.Empty && tbxm.Rows.Count == 1)
        //        {
        //            MessageBox.Show("在修改单个申请内容时,不能添加多个项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        DataRow[] rows = tbxm.Select("医嘱项目id=" + yzid + "");
        //        if (rows.Length > 0) { MessageBox.Show("您已经添加了该项目", "选择项目", MessageBoxButtons.OK); return; }

        //        //add by zouchihua 2013-5-22
        //        cmbjcks.SelectedValue = tb.Rows[nrow]["EXEC_DEPT"];
        //        cmbClassJC.SelectedValue = tb.Rows[nrow]["jclxid"];

        //        DataRow row = tbxm.NewRow();
        //        row["名称"] = tb.Rows[nrow]["项目名称"];
        //        row["医嘱项目id"] = tb.Rows[nrow]["yzid"];
        //        row["套餐id"] = tb.Rows[nrow]["tcid"];
        //        row["单位"] = tb.Rows[nrow]["单位"];
        //        row["单价"] = tb.Rows[nrow]["单价"];
        //        row["数量"] = "1";
        //        row["金额"] = tb.Rows[nrow]["单价"];
        //        row["频次"] = "st";
        //        tbxm.Rows.Add(row);

        //        sumje();
        //    }
        //    catch (System.Exception err)
        //    {
        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void dataGridView1_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable tb = (DataTable)this.dataGridView1.DataSource;
        //        if (tb.Rows.Count == 0) return;
        //        int nrow = this.dataGridView1.CurrentCell.RowIndex;
        //        tb.Rows.Remove(tb.Rows[nrow]);
        //        sumje();
        //    }
        //    catch (System.Exception err)
        //    {
        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        //private void btOkJC_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable tbmx = (DataTable)this.dataGridView1.DataSource;
        //        if (tbmx.Rows.Count == 0) { MessageBox.Show("请选择相应的项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        //        mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbmx, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 1, dtpsqrq.Value.ToString(),
        //            InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId,txtbs.Text, txtzd.Text, Convert.ToInt32(cmbjcks.SelectedValue),
        //            cmbbw.Text, txtbz.Text, 0, Convert.ToDecimal(lblPrice.Text), 0, InstanceForm.BDatabase);
        //        DataTable tb = (DataTable)this.dataGridView1.DataSource;
        //        tb.Clear();
        //        if (Dqcf.yjsqid==Guid.Empty )
        //            MessageBox.Show("申请发送成功");
        //        else 
        //            MessageBox.Show("申请修改成功");
        //        this.Close();
        //    }
        //    catch (System.Exception err)
        //    {
        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndy_Click(object sender, EventArgs e)
        {
            try
            {
                //获得卡号信息
                string sql = "  select  kh from YY_KDJB where brxxid='" + Dqcf.brxxid + "'";
                DataTable tbPat = FrmMdiMain.Database.GetDataTable(sql);
                string brkh = "";
                if (tbPat.Rows.Count > 0)
                    brkh = tbPat.Rows[0]["KH"].ToString();
                DsJyJc.rptAPPDataTable tb = new DsJyJc.rptAPPDataTable();
                DataTable dt = (DataTable)this.control_jysq1.dataGridView1.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = tb.NewRow();
                    dr["binname"] = lblxm.Text;
                    dr["sex"] = lblxb.Text;
                    dr["age"] = lblnl.Text;
                    dr["yqDoc"] = FrmMdiMain.CurrentUser.Name;
                    dr["yqDate"] = dtpsqrq.Value;
                    dr["deptName"] = FrmMdiMain.CurrentDept.DeptName;
                    dr["wardName"] = FrmMdiMain.CurrentDept.DeptName;
                    dr["bedID"] = "";
                    dr["symptom"] = control_jysq1.richTextBoxEx1.Text.Trim();
                    dr["diagnosis"] = control_jysq1.TextLczd.textBox1.Text.Trim(); //this.txtzd.Text.Trim();
                    dr["place"] = cmbbw.Text;//this.cmbPlace.Text.Trim();
                    dr["itemName"] = dt.Rows[i]["name"].ToString();// chkListBox.CheckedItems;
                    dr["inpatientid"] = lblmzh.Text;// 门诊号
                    dr["price"] = "      " + dt.Rows[i]["je"].ToString();

                    for (int j = 4; j < 7; j++)
                    {
                        dr["col" + j.ToString()] = "";
                    }
                    if (i < dt.Rows.Count - 1)
                    {
                        dr["bz"] = "  标本名称:" + dt.Rows[i]["bbmc"].ToString();
                        dr["col3"] = "附加说明:" + dt.Rows[i]["fjsm"].ToString(); 
                    }

                    
                    dr["yymc"] = (new SystemCfg(2)).Config;
                    dr["lxmc"] = "门诊病人" + this.cmbClassJC.Text.Trim() + "申请单";
                    dr["col1"] = brkh;
                    dr["col2"] = dt.Rows[i]["zxksmc"].ToString();  //cmbjcks.Text;//检查科室
                
                    tb.Rows.Add(dr);
                }
                string printFile = "Mz_化验申请.rpt";
                FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
                rv.ShowDialog();
            }
            catch (Exception ea)
            {
                MessageBox.Show("打印出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void Frmhysqd_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

    }
}