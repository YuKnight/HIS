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
using Ts_zyys_public;
using TrasenFrame.Forms;
namespace ts_mz_tjbb
{
    public partial class Frmyjjjk : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Guid Jkid = Guid.Empty;//交款ID
        public int yjjrow = 0;
        public int fpbrow = 0;
        public DataSet dset = new DataSet();

        public Frmyjjjk(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            lbltitle.Text = _chineseName;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dtpjsrq2.Enabled = radioButton1.Checked == true ? true : false;
            buttj.Enabled = true;
            butjk.Enabled = radioButton1.Checked == true ? true : false;
            dtp1.Enabled = radioButton2.Checked == true ? true : false;
            dtp2.Enabled = radioButton2.Checked == true ? true : false;
            Jkid = Guid.Empty;
            yjjrow = 0;
            fpbrow = 0;
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb != null) tb.Rows.Clear();

        }

        private void buttj_Click(object sender, EventArgs e) 
        {

            try
            {
                if (radioButton2.Checked == true)
                {
                    ParameterEx[] parameters1 = new ParameterEx[3];

                    parameters1[0].Text = "@KSRQ";
                    parameters1[0].Value = dtp1.Value.ToString();

                    parameters1[1].Text = "@JSRQ";
                    parameters1[1].Value = dtp2.Value.ToString();

                    parameters1[2].Text = "@jky";
                    parameters1[2].Value = 0;

                    dset = new DataSet();
                    InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_TJ_JK_TJ_YJJCX", parameters1, dset, "sfmx", 30);
                    Fun.AddRowtNo(dset.Tables[0]);
                    this.dataGridView1.DataSource = dset.Tables[0];

                    for (int i = 0; i <= dset.Tables[0].Columns.Count - 1; i++)
                    {
                        if (i > 1)
                            dataGridView1.Columns[i].Width = 70;
                        if (dataGridView1.Columns[i].HeaderText == "缴款日期")
                            dataGridView1.Columns[i].Width = 120;
                    }

                    //Mod by Hxy 20150110 设置金额以及数量列靠右。
                    this.DGVFormat();
                    return;
                }


                if (dtpjsrq2.Value > DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) && radioButton1.Checked == true)
                {
                    MessageBox.Show("统计时间不能大于当前系统时间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@sky";
                parameters[0].Value = 0;

                parameters[1].Text = "@jsrq";
                parameters[1].Value = dtpjsrq2.Value.ToString();

                parameters[2].Text = "@err_text";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZSF_TJ_JK_TJ_YJJ", parameters, dset, "sfmx", 30);

                string err_text = Convertor.IsNull(parameters[2].Value, "");

                if (err_text != "")
                {
                    MessageBox.Show(err_text, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    butjk.Enabled = false;
                }
                dset.Tables[0].Columns.Add("jkid"); //add by wangzhi 2014-08-05 加jkid列，与历史查询保持输出到报表的列一致，不然会导致打印时收费员列显示不正确
                Fun.AddRowtNo(dset.Tables[0]);

                this.dataGridView1.DataSource = dset.Tables[0];
                yjjrow = Convert.ToInt32(Convertor.IsNull(dset.Tables[2].Rows[0][0], "0"));
                fpbrow = Convert.ToInt32(Convertor.IsNull(dset.Tables[2].Rows[0][1], "0"));

                for (int i = 0; i <= dset.Tables[0].Columns.Count - 1; i++)
                {
                    if (i > 1)
                        dataGridView1.Columns[i].Width = 70;
                }
                //Mod by Hxy 20150110 设置金额以及数量列靠右。
                this.DGVFormat();

                butjk.Enabled = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVFormat()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Name.Trim() != "收款员")
                {
                    this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void Frmyjjjk_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");


            string ssql = "select top 1 jsrq from mz_jkb where jky in(select employee_id from jc_employee_property where rylx=8) order by jsrq desc";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
                dtpjsrq1.Value = Convert.ToDateTime("1900-01-01 00:00:00");
            else
                dtpjsrq1.Value = Convert.ToDateTime(tb.Rows[0]["jsrq"]);
            //Mod by Hxy 2015-3-23 屏蔽设置结束时间为零点。
            //dtpjsrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
        }

        private void butjk_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {

                if (Jkid != Guid.Empty)
                {
                    MessageBox.Show("已点击交账,不能重复操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpjsrq2.Value > DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase))
                {
                    MessageBox.Show("统计时间不能大于当前系统时间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (yjjrow == 0 && fpbrow == 0)
                {
                    MessageBox.Show("没有需要交款的记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                #region 权限确认
                try
                {
                    string dlgvalue = DlgPW.Show();
                    string pwStr = dlgvalue; //YS.Password;
                    bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                    if (!bOk)
                    {
                        FrmMessageBox.Show("你没有通过权限确认，不能交帐！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                        return;
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                int _yjjrow = 0;
                int _fpbrow = 0;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                DataRow[] rows = tb.Select("sfy>0");

                try
                {
                    butjk.Enabled = false;
                    buttj.Enabled = false;
                    InstanceForm.BDatabase.BeginTransaction();

                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        int sfy = Convert.ToInt32(Convertor.IsNull(rows[i]["sfy"], "0"));
                        string sfyxm = Fun.SeekEmpName(sfy, InstanceForm.BDatabase);
                        string ksrq = Scjksj(sfy).ToString();
                        string jsrq = dtpjsrq2.Value.ToString();

                        long yxzs = 0;
                        long zfzs = 0;
                        decimal fpje = Convert.ToDecimal(Convertor.IsNull(rows[i]["刷卡消费"], "0"));// + Convert.ToDecimal(Convertor.IsNull(rows[i]["银联卡消费"], "0"));
                        decimal xjzf = 0;
                        decimal zpzf = 0;
                        decimal ylkzf = 0;// Convert.ToDecimal(Convertor.IsNull(rows[i]["银联卡消费"], "0"));
                        decimal ybzf = 0;
                        decimal cwjz = Convert.ToDecimal(Convertor.IsNull(rows[i]["刷卡消费"], "0"));
                        decimal qfgz = 0;
                        decimal yhje = Convert.ToDecimal(Convertor.IsNull(rows[i]["优惠金额"], "0")); ;
                        decimal zfje = 0;
                        string fpd = "";
                        string zffpd = "";

                        if ((fpje - xjzf - zpzf - ylkzf - ybzf - cwjz - qfgz - yhje) != 0)
                        {
                            MessageBox.Show("消费总额,与各支付项不等,请检查数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //缴款日期为收费结束日期，新增加操作日期
                        string ssql = "select dbo.FUN_GETGUID(newid(),getdate()) ";
                        Jkid = new Guid(InstanceForm.BDatabase.GetDataResult(ssql).ToString());

                        ssql = "insert into mz_jkb(jkid,jgbm,ksrq,jsrq,jkrq,jky,yxfpzs,fpje,zfzs,zfje,xjzf,zpzf,ylkzf,ybzf,cwjz,qfgz,yhje,sffpd,ZFFPH,czrq)values('" +
                           Jkid + "'," + _menuTag.Jgbm + ",'" + ksrq + "','" + jsrq + "','" + jsrq + "'," + sfy + "," + yxzs + "," + fpje + "," + zfzs + "," + (-1) * zfje +
                           "," + xjzf + "," + zpzf + "," + ylkzf + "," + ybzf + "," + cwjz + "," + qfgz + "," + yhje + ",'" + fpd + "','" + zffpd + "','" + sDate + "')";
                        int x = InstanceForm.BDatabase.DoCommand(ssql);
                        if (x == 0) throw new Exception("插入交款记录时失败");
                        if (Jkid == Guid.Empty || Jkid == null) throw new Exception("交款id为零，请和管理员联系");

                        ssql = "update mz_fpb set jkid='" + Jkid + "' where (BGHPBZ <> 2 or ZJE > 0) and sfy=" + sfy + " and  sfrq>='" + ksrq + "' and sfrq<='" + jsrq + "' and bscbz=0 and  isnull(jkid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()";
//                        ssql = string.Format(@"update mz_fpb set jkid='{0}' where ZJE>0 and sfy= {1} and  sfrq>='{2}' and sfrq<='{3}' 
//                        and bscbz=0 and  isnull(jkid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()", Jkid, sfy, ksrq, jsrq);
                        x = InstanceForm.BDatabase.DoCommand(ssql);
                        _fpbrow = _fpbrow + x;

                    
                        ssql = "update mz_skjl set jkid='" + Jkid + "' where ZJE > 0 and sfy=" + sfy + " and  sfrq>='" + ksrq + "' and sfrq<='" + jsrq + "' and bscbz=0 and  isnull(jkid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()";
                        x = InstanceForm.BDatabase.DoCommand(ssql);
                        ssql = "update yy_kdjb_je set jkid='" + Jkid + "' where CRJE > 0 and dzrq>='" + ksrq + "' and dzrq<='" + jsrq + "' and dzy=" + sfy + " and bdzbz=1 and bzfbz=0 and isnull(jkid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID() ";
                        x = InstanceForm.BDatabase.DoCommand(ssql);
                        _yjjrow = _yjjrow + x;
                        rows[i]["缴款日期"] = sDate;
                        rows[i]["jkid"] = Jkid;//add by wangzhi 2014-08-05

                    }

                    if (_fpbrow != fpbrow) throw new Exception("统计的发票记录为" + fpbrow + "条,交款更新影响到" + _fpbrow + "行。请刷新后重试");
                    if (_yjjrow != yjjrow) throw new Exception("统计的预交款记录为" + yjjrow + "条,交款更新影响到" + _yjjrow + "行。请刷新后重试");
                    
                    InstanceForm.BDatabase.CommitTransaction();

                    MessageBox.Show("交账成功");
                }
                catch (System.Exception err)
                {
                    butjk.Enabled = true;
                    buttj.Enabled = true;
                    Jkid = Guid.Empty;
                    InstanceForm.BDatabase.RollbackTransaction();
                    throw new Exception(err.Message);
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private DateTime Scjksj(int sky)
        {
            string ssql = "select top 1 * from mz_jkb where jky=" + sky + " order by jkrq desc";//先取交款表的最后交款时间
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)//如果没有记录
            {
                ssql = "select top 1 sfrq from vi_mz_fpb(nolock) where sfy=" + sky + " and (jkid is null or isnull(jkid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID() ) order by sfrq"; //就先取发票表里面的第一条收费记录
                DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
                DataRow dr = tab.NewRow();
                dr["sfrq"] = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select top 1 dzrq as sfrq from yy_kdjb_je (nolock) where dzy=" + sky + " and (jkid is null or isnull(jkid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID() )  order by dzrq "), "2099-12-10 00:00:00");//再取预交金表里面的第一条存款记录
                tab.Rows.Add(dr);
                DataView dv = tab.DefaultView;
                dv.Sort = "sfrq asc";//按收费日期排序
                tab = dv.ToTable();
                if (tab.Rows.Count != 0)//如果有记录
                    return Convert.ToDateTime(tab.Rows[0]["sfrq"]);//取第一条最前面的时间
                else
                    return Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");//否则当前时间

            }
            else
                return Convert.ToDateTime(tb.Rows[0]["jsrq"]);

        }

        private void butprint_Click(object sender, EventArgs e)
        {
            if (Jkid == Guid.Empty && radioButton1.Checked == true)
            {
                MessageBox.Show("点击交款后才能打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataTable tbmx = dset.Tables[0];

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                int x = 0;
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                    {
                        x = x + 1;
                        string nm = "T" + x.ToString();
                        myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                    }
                }
                Dset.收费项目.Rows.Add(myrow);

                x = 0;
                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    x = 0;
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        if (dataGridView1.Columns[i].Visible == true)
                        {
                            x = x + 1;
                            string nm = "JE" + x.ToString();
                            myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                        }
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }



                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "填报人";
                parameters[2].Value = InstanceForm.BCurrentUser.Name;

                parameters[3].Text = "rq1";
                parameters[3].Value = radioButton1.Checked == true ? dtpjsrq1.Value.ToString() : dtp1.Value.ToString();

                parameters[4].Text = "rq2";
                parameters[4].Value = radioButton1.Checked == true ? dtpjsrq2.Value.ToString() : dtp2.Value.ToString();

                parameters[5].Text = "院区";
                parameters[5].Value = cmbjgbm.Text;


                bool bprint = chkprint.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_预交款缴款汇总表.rpt", parameters, bprint);

                if (f.LoadReportSuccess)
                {
                    f.Show();
                }
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            if (Jkid == Guid.Empty && radioButton1.Checked == true)
            {
                MessageBox.Show("点击交款后才能打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                DataTable tbmx = dset.Tables[1];

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                int x = 0;
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    //if (dataGridView1.Columns[i].Visible == true)
                    //{
                    x = x + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                    //}
                }
                Dset.收费项目.Rows.Add(myrow);

                x = 0;
                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        //if (dataGridView1.Columns[i].Visible == true)
                        //{
                        x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                        //}
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }



                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "填报人";
                parameters[2].Value = InstanceForm.BCurrentUser.Name;

                parameters[3].Text = "rq1";
                parameters[3].Value = dtpjsrq1.Value.ToString();

                parameters[4].Text = "rq2";
                parameters[4].Value = dtpjsrq2.Value.ToString();

                parameters[5].Text = "院区";
                parameters[5].Value = cmbjgbm.Text;

                bool bprint = chkprint.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\mz_预交款缴款明细表.rpt", parameters, bprint);

                if (f.LoadReportSuccess)
                {
                    f.Show();
                }
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}