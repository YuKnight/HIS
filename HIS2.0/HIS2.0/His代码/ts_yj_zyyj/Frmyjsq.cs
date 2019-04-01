using System;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_yj_class;
using TrasenHIS.Notice;

namespace ts_yj_zyyj
{
    public partial class Frmyjsq : Form
    {

        public User _currentUser;			//当前操作员
        public Department _currentDept;		//当前登录科室
        public int _jgbm;
        public DataTable tb;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public DataTable TbOrderItem;
        public int jcys_id = 0;//检查医生
        public string jcys_name = "";
        public bool BDelRow = false;
        private SystemCfg cfg10013 = new SystemCfg(10013);
        public int _type = -1;//Add By Tany 2010-11-26 查询方式-1=全部0=正费用1=负费用
        private bool _isCj = true;//Add By Tany 2016-01-08 是否允许冲减

        public Frmyjsq(MenuTag menuTag, string chineseName, Form mdiParent, int type, bool isCj)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            _type = type;
            _isCj = isCj;//Add By Tany 2016-01-08
        }

        /// 载入数据
        /// </summary>
        /// <param name="txm">条形码</param>
        /// <param name="zyh">住院号</param>
        /// <param name="ks">科室</param>
        /// <param name="brxm">病人姓名</param>
        /// <param name="yzxmid">医嘱项目ID</param>
        /// <param name="cwh">床位号</param>
        /// <param name="type">查询方式-1=全部0=正费用1=负费用</param>
        public void LoadData(string txm, string zyh, int ks, string brxm, string yzxmid, string cwh, int type)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[9];
                parameters[0].Text = "@JGBM";
                parameters[1].Text = "@ZXKS";
                parameters[2].Text = "@TXM";
                parameters[3].Text = "@ZYH";
                parameters[4].Text = "@SQKS";
                parameters[5].Text = "@BRXM";
                parameters[6].Text = "@YZXMID";
                parameters[7].Text = "@CWH";
                parameters[8].Text = "@TYPE";
                parameters[0].Value = Convert.ToInt32(cmbjgbm.SelectedValue);
                parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                parameters[2].Value = txttxm.Text.Trim();
                parameters[3].Value = txtzyh.Text.Trim();
                parameters[4].Value = Convertor.IsNull(cmbks.SelectedValue, "0");
                parameters[5].Value = brxm;
                parameters[6].Value = yzxmid;
                parameters[7].Value = cwh;
                parameters[8].Value = type;
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YJ_APPLYREADX", parameters, 60);
                Fun.AddRowtNo(tb);
                dgvyjsq.DataSource = tb;

                //update pengyang 2015-8-1
                //if (txtzyh.Text.Trim() != "" || txttxm.Text.Trim() != "")
                //{
                //    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                //        tb.Rows[i]["SELECTED"] = (short)1;
                //} 
                DataTable tbmx = (DataTable)dataGridView1.DataSource;
                if (tbmx != null)
                {
                    tbmx.Rows.Clear();
                    return;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #region  按钮事件
        //刷新按钮
        private void btrefresh_Click(object sender, EventArgs e)
        {
            try
            {
                cfg10013 = new SystemCfg(10013, InstanceForm.BDatabase);
                if (cfg10013.Config == "1")
                    this.dgvyjsq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

                Cursor.Current = PubStaticFun.WaitCursor();
                LoadData(txttxm.Text, txtzyh.Text, Convert.ToInt32(Convertor.IsNull(cmbks.SelectedValue, "0")), txtbrxm.Text.Trim(), Convertor.IsNull(txtjcxm.Tag, "0"), txtcwh.Text.Trim(), _type);
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
        //关闭按钮
        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //全选
        private void btQX_Click(object sender, EventArgs e)
        {
            SelectAll(0, dgvyjsq);
        }
        //反选
        private void btFX_Click(object sender, EventArgs e)
        {
            SelectAll(1, dgvyjsq);
        }
        //kind 0 全选   1反选  2全部不选
        private void SelectAll(int kind, DataGridView myDataGrid)
        {
            if (myDataGrid.DataSource == null)
                return;

            DataTable tb = ((DataTable)myDataGrid.DataSource);
            if (tb == null)
                return;
            if (tb.Rows.Count <= 0)
                return;

            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (kind == 0)
                {
                    tb.Rows[i]["SELECTED"] = true;
                }
                else if (kind == 1)
                {
                    tb.Rows[i]["SELECTED"] = tb.Rows[i]["SELECTED"].ToString() == "1" ? false : true;
                }
                else
                {
                    tb.Rows[i]["SELECTED"] = false;
                }
            }
            myDataGrid.DataSource = tb;
        }

        //确定按钮事件
        private void dgvyjsq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dgvyjsq.DataSource;
                int nrow = e.RowIndex;
                if (tb.Columns[e.ColumnIndex].ColumnName == "FEE")
                {
                    string YZID = tb.Rows[nrow]["yzid"].ToString();
                    string YZZXID = tb.Rows[nrow]["yzzxid"].ToString();
                    string YJSQID = tb.Rows[nrow]["YJSQID"].ToString();
                    string YJQRID = "";
                    string btfbz = tb.Rows[nrow]["btfbz"].ToString();
                    int zxks = Convert.ToInt32(tb.Rows[nrow]["zxks"]);
                    frmfy frmfy = new frmfy(YZID.ToString(), Convertor.IsNull(YZZXID, Guid.Empty.ToString()), YJSQID.ToString(), YJQRID.ToString(), zxks, InstanceForm.BDatabase, Convert.ToInt32(cmbjgbm.SelectedValue));
                    if (btfbz == "1")
                    {
                        frmfy.btcancel.Enabled = false;
                        frmfy.btadd.Enabled = false;
                        frmfy.btdel.Enabled = false;
                    }
                    //Modify By Tany 2016-01-08 是否允许冲减
                    if (!_isCj)
                    {
                        frmfy.btdel.Enabled = false;
                    }
                    frmfy.ShowDialog();
                    DataTable tbfee = select.SelectFee(0, new Guid(YZID), new Guid(YZZXID), new Guid(Convertor.IsNull(YJQRID, Guid.Empty.ToString())), InstanceForm.BDatabase);
                    decimal zje = Convert.ToDecimal(Convertor.IsNull(tbfee.Compute("sum(ACVALUE)", ""), "0"));
                    tb.Rows[nrow]["je"] = zje.ToString();
                    dataGridView1.DataSource = tbfee;
                }
                else if (tb.Columns[e.ColumnIndex].ColumnName == "SELECTED")
                {
                    int selected = Convert.IsDBNull(tb.Rows[nrow]["SELECTED"]) ? 0 : Convert.ToInt32(tb.Rows[nrow]["SELECTED"]);
                    if (selected == 1)
                        selected = 0;
                    else
                        selected = 1;

                    //Modify by jchl 2016-12-28-----------------------------------------
                    if (selected == 1)
                    {
                        //勾选  确认
                        string order_id = tb.Rows[nrow]["yzid"].ToString();
                        string ssql = "select * from zy_inpatient(nolock) where inpatient_id in (select INPATIENT_ID from ZY_ORDERRECORD(nolock) where ORDER_ID='" + order_id + "')";
                        DataTable tbpa = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tbpa == null || tbpa.Rows.Count <= 0)
                        {
                            MessageBox.Show("未找到该医嘱对应的病人信息！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //年底大调价,医保病人不允许跨年冲正2016记账费用   modify by jchl 2016-12-28
                        string _yblx = tbpa.Rows[0]["YBLX"].ToString().Trim();
                        if (_yblx.Trim().Equals("1"))
                        {
                            DateTime serDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                            DateTime dtMin = DateTime.Parse("2016-12-31 18:00:00");
                            DateTime dtMax = DateTime.Parse("2017-01-01 00:10:00");
                            if (serDate >= dtMin && serDate <= dtMax)
                            {
                                MessageBox.Show("因为年底大调价，根据医院的统一部署安排，12月31日 18点 至 次日0:10分 医保病人不允许操作费用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    tb.Rows[nrow]["SELECTED"] = selected;
                    //tb.AcceptChanges();
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btApplyAffirm_Click(object sender, EventArgs e)
        {
            if (btApplyAffirm.Enabled == false) return;
            try
            {
                if (dgvyjsq.DataSource == null)
                    return;

                DataTable tb = (DataTable)dgvyjsq.DataSource;


                DataRow[] rows = tb.Select("SELECTED=true");
                if (rows.Length == 0)
                {
                    MessageBox.Show("请选择申请记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable newtb = tb.Clone();
                for (int i = 0; i <= rows.Length - 1; i++)
                    newtb.ImportRow(rows[i]);


                frmqr formyjqr = new frmqr(InstanceForm.BDatabase);

                if (newtb.Rows.Count == 1)
                {
                    formyjqr.lbName.Text = newtb.Rows[0]["brxm"].ToString();
                    formyjqr.lbSex.Text = newtb.Rows[0]["xb"].ToString();
                    formyjqr.lbPatientNo.Text = newtb.Rows[0]["INPATIENT_NO"].ToString();
                    formyjqr.txtDoctor.Tag = jcys_id.ToString();
                    formyjqr.txtDoctor.Text = jcys_name.ToString();
                }
                formyjqr.ShowDialog();
                if (formyjqr.bok == false)
                    return;

                //add by wangzhi 2010-12-07 确认负费需要密码验证
                if (_type == 1)
                {
                    SystemCfg cfg10004 = new SystemCfg(10004);
                    //密码验证
                    if (cfg10004.Config == "1")
                    {
                        ts_yj_class.FrmPasswordCheck fcheck = new FrmPasswordCheck(_currentUser);
                        if (fcheck.DialogResult == DialogResult.Cancel)
                            return;
                    }
                }
                //end add

                jcys_id = Convert.ToInt32(Convertor.IsNull(formyjqr.txtDoctor.Tag, "0"));
                jcys_name = formyjqr.txtDoctor.Text;

                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//登记时间
                int jcys = Convert.ToInt32(Convertor.IsNull(formyjqr.txtDoctor.Tag, "0"));
                string jcrq = formyjqr.dtp.Value.ToShortDateString();
                string jgwz = "";
                int err_code = -1;
                string err_text = "";

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();

                    for (int i = 0; i <= newtb.Rows.Count - 1; i++)
                    {
                        Guid orderid = new Guid(newtb.Rows[i]["yzid"].ToString());
                        Guid orderexec_id = new Guid(newtb.Rows[i]["yzzxid"].ToString());
                        Guid yjsqid = new Guid(newtb.Rows[i]["yjsqid"].ToString());
                        decimal je = Convert.ToDecimal(newtb.Rows[i]["je"].ToString());
                        int btfbz = Convert.ToInt16(newtb.Rows[i]["btfbz"].ToString());
                        int bscqrbz = btfbz == 1 ? 0 : 1;
                        Guid newqrid = Guid.Empty;
                        yjqr.yj_zysq_qrjl(orderid, orderexec_id, yjsqid, je, InstanceForm.BCurrentDept.DeptId, sDate, InstanceForm.BCurrentUser.EmployeeId, bscqrbz,
                            jcrq, jcys, jgwz, out newqrid, out err_code, out err_text, 0, InstanceForm.BDatabase);
                        if (err_code != 0 || newqrid == Guid.Empty)
                            throw new Exception(err_text);
                    }
                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    throw new Exception(err.Message);
                }

                BDelRow = true;
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    DataRow row = rows[i];
                    tb.Rows.Remove(row);
                }
                BDelRow = false;
            }
            catch (Exception ee)
            {
                BDelRow = false;
                MessageBox.Show(ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void txttxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar != 13)
                    return;
                Control control = (Control)sender;
                if (control.Name == "txtzyh")
                {
                    control.Text = Fun.returnZyh(txtzyh.Text);
                }
                btrefresh_Click(sender, null);
                txtzyh.SelectionStart = txtzyh.Text.Length;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btrefresh_Click(sender, null);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Frmyjsq_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Cursor.Current = PubStaticFun.WaitCursor();
                btrefresh_Click(sender, e);
                Cursor.Current = Cursors.Default;
            }
            if (e.KeyCode == Keys.F2)
            {
                btApplyAffirm_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Frmyjsq_Load(object sender, EventArgs e)
        {
            ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);

            //解决多院刷新报错问题 add by cc 
            //ts_mz_class.Fun.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;
            cmbjgbm.SelectedIndexChanged += new EventHandler(cmbjgbm_SelectedIndexChanged);
            //end add 
            //cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;

            TbOrderItem = select.SelectOrderItem(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);

            SystemCfg cfg10009 = new SystemCfg(10009);
            if (cfg10009.Config.Trim() != "")
            {
                string[] sArray = cfg10009.Config.ToString().Split(new char[1] { ',' });
                for (int j = 0; j <= sArray.Length - 1; j++)
                {
                    if (InstanceForm.BCurrentDept.DeptId.ToString() == Convertor.IsNull(sArray[j], ""))
                        btApplyAffirm.Enabled = false;
                }
            }

            this.WindowState = FormWindowState.Maximized;
        }

        //行改变时,查找明细
        private void dgvyjsq_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (BDelRow == true)
                    return;

                DataTable tbmx = null;
                if (dataGridView1.DataSource != null)
                    tbmx = (DataTable)dataGridView1.DataSource;

                DataTable tb = (DataTable)dgvyjsq.DataSource;

                if (dgvyjsq.CurrentCell == null)
                {
                    if (tbmx != null)
                        tbmx.Rows.Clear();
                    return;
                }
                int nrow = dgvyjsq.CurrentCell.RowIndex;
                if (nrow >= tb.Rows.Count)
                {
                    if (tbmx != null)
                        tbmx.Rows.Clear();
                    return;
                }

                if (tb.Columns[dgvyjsq.CurrentCell.ColumnIndex].ColumnName == "FEE")
                    return;

                Guid orderid = new Guid(tb.Rows[nrow]["yzid"].ToString());
                Guid orderexexid = new Guid(tb.Rows[nrow]["yzzxid"].ToString());
                DataTable tab = select.SelectFee(0, orderid, orderexexid, Guid.Empty, InstanceForm.BDatabase);
                Fun.AddRowtNo(tab);
                dataGridView1.DataSource = tab;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtjcxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                if ((int)e.KeyChar == 13)
                {
                    return;
                };
                if ((int)e.KeyChar == 8)
                {
                    txtjcxm.Text = "";
                    txtjcxm.Tag = "0";
                    return;
                };

                string[] headtext = new string[] { "项目名称", "单位", "orderid", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "item_name", "item_unit", "orderid", "py_code", "wb_code" };
                string[] searchfields = new string[] { "item_name", "py_code", "wb_code" };
                int[] colwidth = new int[] { 300, 50, 0, 100, 80 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = TbOrderItem;
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 600;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    this.txtjcxm.Text = f.SelectDataRow["item_name"].ToString().Trim();
                    this.txtjcxm.Tag = f.SelectDataRow["orderid"].ToString().Trim();
                    btrefresh_Click(sender, null);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvyjsq_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (new SystemCfg(10012).Config == "0") return;

                DataTable tb = (DataTable)dgvyjsq.DataSource;

                if (dataGridView1.CurrentCell == null)
                    return;
                //add by wangzhi
                if (dgvyjsq.DataSource == null)
                    return;
                //end add
                if (tb.Rows.Count <= 0)
                    return;

                int nrow = dgvyjsq.CurrentCell.RowIndex;
                Guid yzid = new Guid(tb.Rows[nrow]["yzid"].ToString());
                string ssql = " select a.inpatient_id,a.baby_id,a.ward_id,a.dept_br,0 dept_ly,flag, " +
                    " CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.dept_br AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                    "from zy_orderrecord a inner join VI_ZY_VINPATIENT b " +
                    " on a.inpatient_id=b.inpatient_id   " +
                    " where order_id='" + yzid + "' ";
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbmx.Rows.Count == 0)
                    return;

                int _flag = Convert.ToInt32(tbmx.Rows[0]["flag"]);
                if (_flag == 2 || _flag == 4 || _flag == 5 || _flag == 6)
                {
                    MessageBox.Show("该病人已经出院，不能进行医嘱录入！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                object[] communicateValue = new object[9];
                //病人ID
                communicateValue[0] = tbmx.Rows[0]["inpatient_id"].ToString();
                //病区
                communicateValue[1] = tbmx.Rows[0]["ward_id"].ToString();
                //病人所在科室
                communicateValue[2] = tbmx.Rows[0]["dept_br"].ToString();
                //TAG
                communicateValue[3] = tbmx.Rows[0]["stag"].ToString();
                //是否出院
                communicateValue[4] = false;
                //医生权限
                communicateValue[5] = 1;
                //病区所在科室
                communicateValue[6] = 0;
                //是否开单科室领药
                communicateValue[7] = 1;
                //是否特殊治疗
                communicateValue[8] = 1;

                Frmyjsq_cx.GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_yzgl", "医嘱管理", InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, communicateValue, true);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void butjj_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvyjsq.DataSource == null)
                    return;
                DataTable tb = (DataTable)dgvyjsq.DataSource;
                DataRow[] rows = tb.Select("SELECTED=true");
                if (rows.Length == 0)
                {
                    MessageBox.Show("请选择申请记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable newtb = tb.Clone();
                for (int i = 0; i <= rows.Length - 1; i++)
                    newtb.ImportRow(rows[i]);


                if (MessageBox.Show(this, "您确定要拒绝这 " + rows.Length.ToString() + " 条申请记录吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                // frmqr formyjqr = new frmqr();
                //  if (newtb.Rows.Count == 1)
                //  {
                //formyjqr.lbName.Text = newtb.Rows[0]["brxm"].ToString();
                //formyjqr.lbSex.Text = newtb.Rows[0]["xb"].ToString();
                //formyjqr.lbPatientNo.Text = newtb.Rows[0]["INPATIENT_NO"].ToString();
                //formyjqr.txtDoctor.Tag = jcys_id.ToString();
                //formyjqr.txtDoctor.Text = jcys_name.ToString();
                //}
                //formyjqr.ShowDialog();
                //if (formyjqr.bok == false) return;

                //jcys_id = Convert.ToInt32(Convertor.IsNull(formyjqr.txtDoctor.Tag, "0"));
                //jcys_name = formyjqr.txtDoctor.Text;

                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//登记时间
                int jcys = 0;// Convert.ToInt32(Convertor.IsNull(formyjqr.txtDoctor.Tag, "0"));
                string jcrq = "";// formyjqr.dtp.Value.ToShortDateString();
                string jgwz = "";
                int err_code = -1;
                string err_text = "";

                System.Collections.Generic.List<NoticeBindingModel> datalist = new System.Collections.Generic.List<NoticeBindingModel>();
                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    for (int i = 0; i <= newtb.Rows.Count - 1; i++)
                    {
                        Guid orderid = new Guid(newtb.Rows[i]["yzid"].ToString());
                        Guid orderexec_id = new Guid(newtb.Rows[i]["yzzxid"].ToString());
                        Guid yjsqid = new Guid(newtb.Rows[i]["yjsqid"].ToString());
                        decimal je = Convert.ToDecimal(newtb.Rows[i]["je"].ToString());
                        int btfbz = Convert.ToInt16(newtb.Rows[i]["btfbz"].ToString());
                        int bscqrbz = btfbz == 1 ? 0 : 1;
                        Guid newqrid = Guid.Empty;
                        yjqr.yj_zysq_qrjl(orderid, orderexec_id, yjsqid, je, InstanceForm.BCurrentDept.DeptId, sDate, InstanceForm.BCurrentUser.EmployeeId, bscqrbz,
                            jcrq, jcys, jgwz, out newqrid, out err_code, out err_text, 1, InstanceForm.BDatabase);
                        if (err_code != 0 || newqrid == Guid.Empty)
                            throw new Exception(err_text);
                        TrasenHIS.Notice.NoticeBindingModel model = new TrasenHIS.Notice.NoticeBindingModel();
                        model.Title = "医技拒绝确认通知";
                        model.Content = "【" + FrmMdiMain.CurrentDept.DeptName + "】操作员【" + FrmMdiMain.CurrentUser.Name + "】拒绝了【" + newtb.Rows[i]["SQKS"].ToString() + "】【住院号" + newtb.Rows[i]["inpatient_no"].ToString() + "】【" + newtb.Rows[i]["bedno"].ToString() + "床】【" + newtb.Rows[i]["brxm"].ToString() + "】的医技申请：" + newtb.Rows[i]["SQNR"].ToString();
                        //model.ReceiverType = ReceiveType.WorkCode;
                        model.ReceiverType = ReceiveType.WorkCode;
                        model.Receiver = newtb.Rows[i]["sqid"].ToString();
                        //model.Receiver = "5161";
                        datalist.Add(model);
                    }
                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    throw new Exception(err.Message);
                }
                SystemCfg sc = new SystemCfg(10024);
                if (sc != null && sc.Config == "0")
                {
                    //调用i呼接口 Modify By Tany 2015-06-30
                    if (datalist.Count > 0)
                    {
                        TrasenHIS.Notice.Notice im = new Notice();
                        foreach (NoticeBindingModel model in datalist)
                        {
                            DataResult dr = im.SendIM(model);
                        }
                    }
                }
                BDelRow = true;
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    DataRow row = rows[i];
                    tb.Rows.Remove(row);
                }
                BDelRow = false;
            }
            catch (Exception ee)
            {
                BDelRow = false;
                MessageBox.Show(ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                InstanceForm.BDatabase = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(cmbjgbm.SelectedValue));

                if (new SystemCfg(10015, InstanceForm.BDatabase).Config == "1")
                    Fun.AddcmbWardDept(cmbks, 1, "", Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);
                else
                    Fun.AddcmbZyks(cmbks, 1, 0, Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);
                btrefresh_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}