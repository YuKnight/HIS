using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.DbAcc;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
namespace ts_mz_rizhi
{
    public partial class MZ_RZ : Form
    {
        public MZ_RZ()
        {
            InitializeComponent();

        }
        DataTable Tbzy, Tbdz;
        private MenuTag _menuTag;
        private string _blh;
        private DataRow _dr;

        public MZ_RZ(string chineseName, MenuTag menuTag, DataRow row)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _dr = row;
        }

        public MZ_RZ(string chineseName, MenuTag menuTag, string blh)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _blh = blh;
        }

        private void MZ_RZ_Load(object sender, EventArgs e)
        {
            Tbdz = FrmMdiMain.Database.GetDataTable("SELECT CODE,NAME,PY_CODE,WB_CODE FROM JC_DISTRICTFORFZJH");
            Tbzy = FrmMdiMain.Database.GetDataTable("SELECT CODE ,NAME,PY_CODE,WB_CODE FROM dbo.JC_OCCUPATI");
            InstanceForm.BDatabase = TrasenFrame.Forms.FrmMdiMain.Database;
            InstanceForm.BCurrentDept = TrasenFrame.Forms.FrmMdiMain.CurrentDept;
            InstanceForm.BCurrentUser = TrasenFrame.Forms.FrmMdiMain.CurrentUser;
            InitPage();
            InitData();
        }

        /// <summary>
        /// 初始化病人数据  modify by fangke 2014.11.18
        /// </summary>
        private void InitData()
        {
            try
            {
                string strKh = string.Empty;
                string strSql = string.Empty;
                DataTable dt;

                if (!string.IsNullOrEmpty(_blh))
                {
                    //根据BLH获取病人基本信息
                    strSql = string.Format(@"SELECT a.BRXM,a.XB,a.CSRQ,c.KH,b.GHSJ,dbo.fun_getDeptname(b.JZKS) JZKS,d.JSSJ
                                                          FROM  MZ_GHXX b INNER JOIN dbo.YY_BRXX a   
                                                        ON b.BRXXID = a.BRXXID LEFT JOIN dbo.YY_KDJB c ON b.KDJID = c.KDJID
                                                        LEFT JOIN MZYS_JZJL d ON B.GHXXID = d.GHXXID
                                                                                WHERE b.BLH='{0}'
                                                                                ", _blh);
                    dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null) return;
                    if (dt.Rows.Count == 0) return;
                    strKh = Convertor.IsNull(dt.Rows[0]["KH"], "");
                    txtMzh.Text = _blh;
                    txtBrxm.Text = dt.Rows[0]["BRXM"].ToString();
                    dtpCsrq.Value = Convert.ToDateTime(dt.Rows[0]["CSRQ"]);
                    this.cmbXb.SelectedValue = dt.Rows[0]["XB"].ToString();
                    dtpFbrq.Value =    System.DateTime.Now.AddDays(-1);
                    txtGhsj.Text = dt.Rows[0]["GHSJ"].ToString();
                    txtJzks.Text = dt.Rows[0]["JZKS"].ToString();
                    txtZdsj.Text = dt.Rows[0]["JSSJ"].ToString();
                    txtJzrq.Text = Convert.ToDateTime(dt.Rows[0]["JSSJ"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    txtKh.Text = dt.Rows[0]["KH"].ToString();
                }
                else if (_dr != null)
                {
                    strKh = _dr["kahao"] == DBNull.Value ? "" : _dr["kahao"].ToString();
                    txtKh.Text = strKh;
                    txtGhsj.Text = _dr["ghsj"] == DBNull.Value ? "" : _dr["ghsj"].ToString();
                    txtZdsj.Text = _dr["JSSJ"] == DBNull.Value ? "" : _dr["JSSJ"].ToString();
                    txtJzrq.Text = _dr["JSSJ"] == DBNull.Value ? "" : Convert.ToDateTime(_dr["JSSJ"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    _blh = _dr["blh"].ToString();
                    txtMzh.Text = _blh;
                    txtBrxm.Text = _dr["brxm"].ToString();
                    dtpCsrq.Value = Convert.ToDateTime(_dr["csrq"]);
                    if (_dr["xb"].ToString() == "男")
                        this.cmbXb.SelectedValue = 1;
                    else if (_dr["xb"].ToString() == "女")
                        this.cmbXb.SelectedValue = 2;
                    dtpFbrq.Value =  System.DateTime.Now.AddDays(-1);
                    txtJzks.Text = _dr["ksname"] == DBNull.Value ? "" : _dr["ksname"].ToString();
                }
                txtBgr.Text = InstanceForm.BCurrentUser.Name;
                txtBbrqx.Tag = InstanceForm.BCurrentUser.EmployeeId;

                //BLH判断门诊日志表中是否存在记录
                strSql = string.Format(@"SELECT *,(SELECT jo.NAME FROM JC_OCCUPATI jo WHERE jo.CODE=a.zy ) zyname,
                                                        c.JSKSDM,c.JSSJ,dbo.fun_getDeptname(c.JSKSDM) jsksname 
                                                         FROM dbo.MZ_MZRZ a 
                                                        INNER JOIN dbo.MZ_GHXX b ON a.blh = b.BLH LEFT JOIN dbo.MZYS_JZJL c ON b.GHXXID = c.GHXXID
                                                        WHERE a.blh='{0}'", _blh);
                dt = FrmMdiMain.Database.GetDataTable(strSql);

                if (dt.Rows.Count > 0)
                {
                    this.txtZy.Tag = dt.Rows[0]["zy"].ToString();
                    this.txtZy.Text = dt.Rows[0]["zyname"].ToString();
                    this.txtXzdz.Text = dt.Rows[0]["xzdz"].ToString();
                    this.txtlxdh.Text = dt.Rows[0]["lxdh"].ToString();
                    this.txtJzks.Tag = dt.Rows[0]["JSKSDM"].ToString();
                    this.txtJzks.Text = dt.Rows[0]["jsksname"].ToString();
                    //this.dtpJzrq.Text = dt.Rows[0]["zdsj"].ToString();

                    this.dtpFbrq.Value = Convert.ToDateTime(dt.Rows[0]["fbrq"]);
                    //this.dtpGhsj.Value = Convert.ToDateTime(dt.Rows[0]["ghsj"]);
                    txtXinlv.Text = Convertor.IsNull(dt.Rows[0]["xinlv"], "");
                    //txtKh.Text = strKh;//Convertor.IsNull(dt.Rows[0]["kh"], "");
                    txtRyfs.Text = Convertor.IsNull(dt.Rows[0]["ryfs"], "");
                    // this.dtpZdsj.Value = Convert.ToDateTime(dt.Rows[0]["zdsj"]);
                    txtMb.Text = Convertor.IsNull(dt.Rows[0]["maibo"], "");
                    txtHuxi.Text = Convertor.IsNull(dt.Rows[0]["huxi"], "");
                    cmbFj.SelectedValue = Convert.ToInt32(dt.Rows[0]["fenji"]);
                    txtShenzhi.Text = Convertor.IsNull(dt.Rows[0]["shenzhi"], "");
                    txtMEWSdf.Text = Convertor.IsNull(dt.Rows[0]["MEWSdf"], "");
                    txtXy.Text = Convertor.IsNull(dt.Rows[0]["xueya"], "");
                    txtYs.Text = Convertor.IsNull(dt.Rows[0]["yishi"], "");
                    txtBbrqx.Text = Convertor.IsNull(dt.Rows[0]["brqx"], "");
                    txtFenqu.Text = Convertor.IsNull(dt.Rows[0]["fenqu"], "");
                    txtKsxt.Text = Convertor.IsNull(dt.Rows[0]["ksxt"], "");
                    txtYxjb.Text = Convertor.IsNull(dt.Rows[0]["yxjb"], "");
                    txtLxbxjcs.Text = Convertor.IsNull(dt.Rows[0]["lxbxjcs"], "");
                    txtXybhd.Text = Convertor.IsNull(dt.Rows[0]["xybhd"], "");
                    txtZhusu.Text = Convertor.IsNull(dt.Rows[0]["zhusu"], "");
                    txtTw.Text = Convertor.IsNull(dt.Rows[0]["tiwen"], "");
                    txtCrbyq.Text = Convertor.IsNull(dt.Rows[0]["crbyq"], "");
                    txtBgr.Text = Convertor.IsNull(dt.Rows[0]["bgr"], "");
                    txtJzxm.Text = Convertor.IsNull(dt.Rows[0]["jzxm"], "");
                    txtSffr.SelectedValue = Convertor.IsNull(dt.Rows[0]["sffr"], "0");
                    cmbCfz.SelectedValue = Convertor.IsNull(dt.Rows[0]["cfz"], "0");
                }
                /*else
                {
                    strSql = string.Format(@"SELECT A.brxm ,xb,xzdz,zy,(SELECT jo.NAME FROM JC_OCCUPATI jo WHERE jo.CODE=a.zy ) zyname,lxdh FROM  dbo.MZ_MZRZ  a WHERE kahao='{0}'", strKh);

                    dt = DbOpt.GetDataTable(strSql);
                    if (dt.Rows.Count > 0)
                    {
                        txtZy.Text = Convertor.IsNull(dt.Rows[0]["zyname"], "");
                        txtZy.Tag = Convertor.IsNull(dt.Rows[0]["zy"], "");
                        txtXzdz.Text = Convertor.IsNull(dt.Rows[0]["xzdz"], "");
                        txtXzdz.Tag = Convertor.IsNull(dt.Rows[0]["xzdz"], "");
                        txtlxdh.Text = Convertor.IsNull(dt.Rows[0]["lxdh"], "");
                    }
                }*/
            }
            catch (Exception)
            {
                return;
            }
        }

        private void InitPage()
        {
            //性别 
            DataTable dtsex = FrmMdiMain.Database.GetDataTable(" select 1 CODE,'男' NAME union all  select 2 CODE,'女' NAME union all  select 9 CODE,'未知' NAME");
            cmbXb.DataSource = dtsex;
            cmbXb.DisplayMember = "name";
            cmbXb.ValueMember = "code";

            //分级
            // object[][] RowItemfj = new object[][] { new object[] { (byte)1, "1级", "1j", "1x" }, new object[] { (byte)2, "2级", "2j", "2x" }, new object[] { (byte)3, "3级", "3j", "3x" } };
            DataTable dtfj = FrmMdiMain.Database.GetDataTable("select 1 CODE,'1级' NAME union all  select 2 CODE,'2级' NAME union ALL SELECT  3  CODE ,'3级' NAME");
            cmbFj.DataSource = dtfj;
            cmbFj.DisplayMember = "name";
            cmbFj.ValueMember = "code";

            //初复诊
            //object[][] RowItemfz = new object[][] { new object[] { (byte)0, "初诊", "cz", "py" }, new object[] { (byte)1, "复诊", "fz", "ty" } };
            DataTable dtfz = FrmMdiMain.Database.GetDataTable("select 0 CODE,'初诊' NAME union all  select 1 CODE,'复诊' NAME ");
            cmbCfz.DataSource = dtfz.Copy();
            cmbCfz.DisplayMember = "NAME";
            cmbCfz.ValueMember = "CODE";

            //发热
            string strSqlfr = @"select 0 CODE,'否' NAME union all  select 1 CODE,'是' NAME ";
            DataTable dtfr = FrmMdiMain.Database.GetDataTable(strSqlfr);
            txtSffr.DataSource = dtfr;
            txtSffr.DisplayMember = "NAME";
            txtSffr.ValueMember = "CODE";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtZy.Text))
                {
                    MessageBox.Show("请输入病人职业！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtZy.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtXzdz.Text))
                {
                    MessageBox.Show("请输入病人现地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtXzdz.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtlxdh.Text))
                {
                    MessageBox.Show("请输入病人联系电话!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtlxdh.Focus();
                    return;
                }
                if (this.dtpFbrq.Value >= Convert.ToDateTime(txtGhsj.Text))
                {
                    MessageBox.Show("发病日期不能大于挂号时间");
                    this.dtpFbrq.Focus();
                    return;
                }

                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    // modify by fangke 2014.11.18
                    FrmMdiMain.Database.DoCommand("delete mz_mzrz where blh='" + this.txtMzh.Text + "'");
                    string strSql = string.Format(@"INSERT INTO dbo.MZ_MZRZ
                                                                                    (rzid,kahao,jzrq,blh,brxm ,
                                                                                      xb,csrq,zy,xzdz,jzxm ,
                                                                                      lxdh,tiwen,xueya,maibo,yxjb , 
                                                                                      fenji,fbrq,zdsj,lxbxjcs,cfz ,
                                                                                      crbyq,bgr,xinlv,huxi,ssy ,
                                                                                      yishi,MEWSdf,ksxt,xybhd,shenzhi ,
                                                                                      ryfs,fenqu,zhusu,brqx,sffr ,
                                                                                      bgrid,deptid,deleted,wbm,pym,ghsj,klx )
                                                                     VALUES  ( '{0}' , '{1}' , '{41}' , '{2}' ,  '{3}' ,
                                                                                      '{4}' ,'{5}' ,  '{6}' ,  '{7}' , '{8}' ,
                                                                                      '{9}' ,{10} , '{11}' ,  '{12}' , '{13}' ,
                                                                                      '{14}' ,  '{15}',  '{16}' ,'{17}' ,  '{18}' ,
                                                                                      '{19}' , '{20}' , {21}, {22} ,  {23} ,  
                                                                                      '{24}' , '{25}' , {26} ,'{27}' ,'{28}' ,   
                                                                                       '{29}' ,  '{30}' ,  '{31}' ,'{32}' ,  '{33}' ,   
                                                                                        {34},  {35},  {36} ,  '{37}' ,  '{38}' , '{39}'  ,{40}  )",
                                                                                          Guid.NewGuid().ToString(), this.txtKh.Text, this.txtMzh.Text, txtBrxm.Text,
                                                                                          cmbXb.Text, dtpCsrq.Value, this.txtZy.Tag, this.txtXzdz.Text, this.txtJzxm.Text,
                                                                                          this.txtlxdh.Text, Convertor.IsNull(txtTw.Text, "0"), this.txtXy.Text, string.IsNullOrEmpty(txtMb.Text) ? "0" : txtMb.Text, txtYxjb.Text,
                                                                                          cmbFj.SelectedValue, dtpFbrq.Value, txtZdsj.Text, txtLxbxjcs.Text, Convertor.IsNull(cmbCfz.SelectedValue, "0"),
                                                                                          txtCrbyq.Text, txtBgr.Text, Convertor.IsNull(txtXinlv.Text, "0"), Convertor.IsNull(txtHuxi.Text, "0"), 0,
                                                                                          txtYs.Text, Convertor.IsNull(txtMEWSdf.Text, "0"), Convertor.IsNull(txtKsxt.Text, "0"), txtXybhd.Text, txtShenzhi.Text,
                                                                                          txtRyfs.Text, txtFenqu.Text, txtZhusu.Text, txtBbrqx.Text, Convertor.IsNull(txtSffr.SelectedValue, "0"),
                                                                                          InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, 0, PubStaticFun.GetPYWBM(this.txtBrxm.Text.Trim(), 1), PubStaticFun.GetPYWBM(this.txtBrxm.Text.Trim(), 0), txtGhsj.Text, 1, txtJzrq.Text);
                    int i = FrmMdiMain.Database.DoCommand(strSql);

                    if (i == 0)
                        throw new Exception("影响的行为0");
                    FrmMdiMain.Database.CommitTransaction();
                }
                catch (Exception ex)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    throw ex;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + Environment.NewLine + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtZy_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8) { control.Text = ""; control.Tag = "0"; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "职业名称", "拼音码", "五笔码", "编码" };
                string[] mappingname = new string[] { "NAME", "PY_CODE", "WB_CODE", "CODE" };
                string[] searchfields = new string[] { "PY_CODE", "WB_CODE", "CODE" };
                int[] colwidth = new int[] { 150, 90, 90, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbzy;
                f.WorkForm = this;
                f.srcControl = txtZy;
                f.Font = txtZy.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtZy.Focus();
                }
                else
                {
                    txtZy.Tag = f.SelectDataRow["CODE"];
                    txtZy.Text = f.SelectDataRow["NAME"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtZy.Text.Trim() == "") { txtZy.Focus(); return; }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtXzdz_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8) { control.Text = ""; control.Tag = "0"; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "地址名称", "拼音码", "五笔码", "编码" };
                string[] mappingname = new string[] { "NAME", "PY_CODE", "WB_CODE", "CODE" };
                string[] searchfields = new string[] { "PY_CODE", "WB_CODE", "CODE" };
                int[] colwidth = new int[] { 150, 90, 90, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbdz;
                f.WorkForm = this;
                f.srcControl = txtXzdz;
                f.Font = txtXzdz.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtXzdz.Focus();
                }
                else
                {
                    txtXzdz.Tag = f.SelectDataRow["NAME"];
                    txtXzdz.Text = f.SelectDataRow["NAME"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtXzdz.Text.Trim() == "") { txtXzdz.Focus(); return; }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}
