using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace Ts_zyys_yzgl
{
    public partial class FrmKssLoad : Form
    {
        private DataTable _dtInKss;//所有待审核抗生素

        private 病人信息.PatientInfo _patientInfo;
        private Doctor _CurDoc;
        public bool _isOk = false;
        private string _BinID;
        private string _BabyID;

        public SystemCfg _cfg6204;
        public SystemCfg _cfg6205;
        public SystemCfg _cfg6206;
        public SystemCfg _cfg6223;//允许主治医师以上级别越级用药开始时间点 【如果不开启则维护为空 如开启则按照格式维护如(20:00)】
        public SystemCfg _cfg6224;//允许主治医师以上级别越级用药的时长【默认格式“HH$mm”】

        public FrmKssLoad()
        {
            InitializeComponent();
        }

        //未审核 病人信息 医生信息
        public FrmKssLoad(string binID, string babyID, DataTable dtApplyKss, 病人信息.PatientInfo patientInfo)
        {
            InitializeComponent();

            //_doc = doc;
            _dtInKss = dtApplyKss;
            _patientInfo = patientInfo;
            _BinID = binID;
            _BabyID = babyID;

            DoInit();
        }

        private void DoInit()
        {
            txtSsItem.KeyPress += new KeyPressEventHandler(txtSsItem_KeyPress);

            cmbYyMd.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            cmbMemo.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            cmbYySx.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            txtBcMemo.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            //txtSsItem.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            cmbIsSj.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            cmbYmJg.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            txtByj.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            cmbIsMg.KeyPress += new KeyPressEventHandler(ctr_KeyPress);
            txtMemo.KeyPress += new KeyPressEventHandler(ctr_KeyPress);


            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoGenerateColumns = false;

            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            //dataGridView3.ReadOnly = true;
            this.dataGridView3.AutoGenerateColumns = false;

            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            //dataGridView4.ReadOnly = true;
            this.dataGridView4.AutoGenerateColumns = false;
            this.ControlBox = false;   // 设置不出现关闭按钮
            this.MaximizeBox = false;
        }

        private void FrmKssLoad_Load(object sender, EventArgs e)
        {
            _cfg6204 = new SystemCfg(6204);
            _cfg6205 = new SystemCfg(6205);
            _cfg6206 = new SystemCfg(6206);
            _cfg6223 = new SystemCfg(6223);
            _cfg6224 = new SystemCfg(6224);
            string strSql = "";

            //病人信息
            try
            {
                txtZyZd.ReadOnly = false;

                txtXm.Text = _patientInfo.lbName.Text;
                txtZyh.Text = _patientInfo.lbID.Text;
                txtNn.Text = _patientInfo.lbAge.Text;
                txtXb.Text = _patientInfo.lbSex.Text;
                txtCh.Text = _patientInfo.lbBed.Text;
                txtZyZd.Text = _patientInfo.lbRYZD.Text;
            }
            catch { }

            //医生信息
            try
            {
                if (_CurDoc != null)
                {
                    txtYsName.Text = _CurDoc.Name;
                    txtDept.Text = InstanceForm._currentDept.DeptName;
                    txtYsType.Text = _CurDoc.TypeID.ToString();
                }
            }
            catch { }

            //
            try
            {
                strSql = string.Format(@"select 'false' as IS_HZCHK,b.NAME as HZ_NAME,b.EMPLOYEE_ID as HZ_ID from
                                        jc_kss_tsshr a
                                        inner join jc_employee_property b on a.Employee_Id=b.EMPLOYEE_ID
                                        where  DEPT_ID='{0}' and b.DELETE_BIT=0", InstanceForm._currentDept.DeptId);

                DataTable dtYjys = InstanceForm._database.GetDataTable(strSql);

                dataGridView3.DataSource = dtYjys;


            }
            catch { }

            //越级医生
            try
            {
                strSql = string.Format(@"select 'false' as IS_YJCHK,b.NAME as YJ_NAME,b.EMPLOYEE_ID as YJ_ID from
                                            JC_ROLE_DOCTOR a
                                            inner join jc_employee_property b on a.Employee_Id=b.EMPLOYEE_ID
                                            inner join JC_EMP_DEPT_ROLE c on a.EMPLOYEE_ID=c.EMPLOYEE_ID and c.DEPT_ID='{0}'
                                          where  a.YS_TYPEID<=3 and b.DELETE_BIT=0 ", InstanceForm._currentDept.DeptId);

                DataTable dtYjys = InstanceForm._database.GetDataTable(strSql);

                dataGridView4.DataSource = dtYjys;
            }
            catch { }

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "--请选择用药目的*--" });
                dt.Rows.Add(new object[] { "1", "预防 - 内科高危人群" });
                dt.Rows.Add(new object[] { "2", "预防 - I类清洁切口手术" });
                dt.Rows.Add(new object[] { "3", "预防 - II类清洁污染切口手术" });
                dt.Rows.Add(new object[] { "4", "治疗 - 经验用药" });
                dt.Rows.Add(new object[] { "5", "治疗 - 药敏依据" });
                dt.Rows.Add(new object[] { "6", "治疗 - III类污染切口手术" });
                dt.Rows.Add(new object[] { "7", "治疗 - IV类污秽感染切口" });

                Addcmb(cmbYyMd, dt, "id", "name");
            }
            catch { }

            try
            {
                strSql = string.Format(@"select -1 as ID,'' as  name
                                            union all
                                            select ID,context as name from jc_kss_yymdMemo where delete_bit=0 ");
                DataTable dt = InstanceForm._database.GetDataTable(strSql);
                //dt.Columns.Add("id", typeof(string));
                //dt.Columns.Add("name", typeof(string));

                //dt.Rows.Add(new object[] { "-1", "" });
                //dt.Rows.Add(new object[] { "1", "aaaa" });

                Addcmb(cmbMemo, dt, "id", "name");
            }
            catch { }

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "--预防性长期医嘱用药时请选择--" });
                dt.Rows.Add(new object[] { "1", "24H" });
                dt.Rows.Add(new object[] { "2", "48H" });
                dt.Rows.Add(new object[] { "3", "48H以上" });

                Addcmb(cmbYySx, dt, "id", "name");
            }
            catch { }

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "--是否送检--" });
                dt.Rows.Add(new object[] { "0", "否" });
                dt.Rows.Add(new object[] { "1", "是" });

                Addcmb(cmbIsSj, dt, "id", "name");//是否送检
            }
            catch { }

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "--是否有药敏结果--" });
                dt.Rows.Add(new object[] { "0", "否" });
                dt.Rows.Add(new object[] { "1", "是" });

                Addcmb(cmbYmJg, dt, "id", "name");//药敏结果
            }
            catch { }

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "--申请药物是否对病原菌敏感--" });
                dt.Rows.Add(new object[] { "0", "否" });
                dt.Rows.Add(new object[] { "1", "是" });

                Addcmb(cmbIsMg, dt, "id", "name");//申请药物是否对病原菌敏感
            }
            catch { }

            //绑定datatable
            DoQuery();

            cmbYyMd.Focus();
            cmbYyMd.Select();

            chkTsKj_CheckedChanged(null, null);
            chkYjSy_CheckedChanged(null, null);

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab != tabPage1)
                    return;

                if (dataGridView1.CurrentRow == null)
                    return;
                this.dataGridView1.EndEdit();

                DataGridViewRow dgvr = dataGridView1.CurrentRow;

                string status = dgvr.Cells["STATUS_FLAG"].Value.ToString();

                int iKssDj = int.Parse(dgvr.Cells["kssdjid"].Value.ToString());
                lblIsSj.Visible = iKssDj >= 2;

                if (status.Trim().Equals("0") || status.Trim().Equals("9"))
                {
                    grpDJ.Enabled = true;
                }
                else
                {
                    grpDJ.Enabled = false;
                }

                string orderType = dgvr.Cells["MNGTYPE"].Value.ToString();

                if (orderType.Trim().Equals("0") &&
                    (cmbYyMd.SelectedValue.ToString().Equals("1") || cmbYyMd.SelectedValue.ToString().Equals("2") || cmbYyMd.SelectedValue.ToString().Equals("3"))
                    )
                {
                    pnlLng.Enabled = true;
                    lblLngOrder.Visible = true;
                }
                else
                {
                    pnlLng.Enabled = false;
                    lblLngOrder.Visible = false;
                }

                txtSsItem.Text = "";
                txtSsItem.Tag = "";

                cmbYyMd.SelectedIndex = 0;
                cmbYySx.SelectedIndex = 0;
                cmbMemo.SelectedIndex = 0;
                txtBcMemo.Text = "";
                cmbIsSj.SelectedIndex = 0;
                cmbYmJg.SelectedIndex = 0;
                txtByj.Text = "";
                cmbIsMg.SelectedIndex = 0;
                txtMemo.Text = "";

                txtYp.Text = dgvr.Cells["order_context"].Value.ToString();
                txtSpec.Text = dgvr.Cells["spec"].Value.ToString();
                txtKssDj.Text = dgvr.Cells["kssdj_name"].Value.ToString();
                txtYpType.Text = dgvr.Cells["cfjb_name"].Value.ToString();
                txtKssDj.Tag = dgvr.Cells["kssdjid"].Value.ToString();
                txtYpType.Tag = dgvr.Cells["cfjb_id"].Value.ToString();

                _CurDoc = new Doctor(long.Parse(dgvr.Cells["order_doc"].Value.ToString().Trim()), InstanceForm._database);
                txtYsName.Text = _CurDoc.Name;
                txtDept.Text = InstanceForm._currentDept.DeptName;
                txtYsType.Text = ((CfLvl)(((int)_CurDoc.TypeID))).ToString();
                txtYsType.Tag = _CurDoc.TypeID;

                chkYjSy.Checked = dgvr.Cells["is_yj"].Value.ToString().Trim().Equals("是");
                chkTsKj.Checked = dgvr.Cells["is_ts"].Value.ToString().Trim().Equals("是");
            }
            catch { }

            cmbYyMd.Focus();
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab != tabPage2)
                    return;

                if (dataGridView2.CurrentRow == null)
                    return;
                this.dataGridView2.EndEdit();

                DataGridViewRow dgvr = dataGridView2.CurrentRow;

                string status = dgvr.Cells["colSTATUS_FLAG"].Value.ToString();

                //if (status.Trim().Equals("0"))
                if (status.Trim().Equals("0") || status.Trim().Equals("9"))
                {
                    grpDJ.Enabled = true;
                }
                else
                {
                    grpDJ.Enabled = false;
                    btnClose.Enabled = true;
                }

                txtYp.Text = dgvr.Cells["colorder_context"].Value.ToString();
                txtSpec.Text = dgvr.Cells["colspec"].Value.ToString();
                txtKssDj.Text = dgvr.Cells["colkssdj_name"].Value.ToString();
                txtYpType.Text = dgvr.Cells["colcfjb_name"].Value.ToString();
                txtKssDj.Tag = dgvr.Cells["colkssdjid"].Value.ToString();
                txtYpType.Tag = dgvr.Cells["colcfjb_id"].Value.ToString();

                //txtYsName.Text = _doc.Name;
                //txtDept.Text = InstanceForm._currentDept.DeptName;
                //txtYsType.Text = (((CfLvl)((int)_doc.TypeID))).ToString();
                //txtYsType.Tag = _doc.TypeID;

                chkYjSy.Checked = dgvr.Cells["colis_yj"].Value.ToString().Trim().Equals("是");
                chkTsKj.Checked = dgvr.Cells["colis_ts"].Value.ToString().Trim().Equals("是");

                txtSsItem.Text = dgvr.Cells["ssitem_name"].Value.ToString().Trim();
                txtSsItem.Tag = dgvr.Cells["ssitem_id"].Value.ToString().Trim();

                cmbYyMd.SelectedValue = dgvr.Cells["yymd_xx"].Value.ToString().Trim();
                cmbYySx.SelectedValue = dgvr.Cells["yy_sx"].Value.ToString().Trim();
                cmbMemo.SelectedValue = dgvr.Cells["yymd_memo"].Value.ToString().Trim();
                txtBcMemo.Text = dgvr.Cells["yymd_bc"].Value.ToString().Trim();
                cmbIsSj.SelectedValue = dgvr.Cells["byjc_bit"].Value.ToString().Trim();
                cmbYmJg.SelectedValue = dgvr.Cells["ymjg"].Value.ToString().Trim();
                txtByj.Text = dgvr.Cells["ymjg_memo"].Value.ToString().Trim();
                cmbIsMg.SelectedValue = dgvr.Cells["byj_gm"].Value.ToString().Trim();
                txtMemo.Text = dgvr.Cells["memo"].Value.ToString().Trim();
            }
            catch
            { }
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            try
            {
                string ssql = "select ID,NAME,PY_CODE,WB_CODE from JC_DISEASE where BSCBZ=0 ";

                TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "ID", "NAME", "PY_CODE", "WB_CODE" },
                                                                                   new string[] { "代码", "主要诊断", "拼音码", "五笔码" },
                                                                                   new string[] { "ID", "NAME", "PY_CODE", "WB_CODE" },
                                                                                   new int[] { 80, 150, 80, 80 });

                frmSelectCard.sourceDataTable = InstanceForm._database.GetDataTable(ssql);
                frmSelectCard.srcControl = txtZyZd;
                frmSelectCard.WorkForm = this;
                //frmSelectCard.ReciveString = cmbbs1.Text;
                if (frmSelectCard.ShowDialog() == DialogResult.OK)
                {
                    txtZyZd.Text += string.IsNullOrEmpty(txtZyZd.Text.Trim()) ? (frmSelectCard.SelectDataRow["NAME"].ToString() + ";") : (";" + frmSelectCard.SelectDataRow["NAME"].ToString() + ";");
                }
            }
            catch { }
        }

        void txtSsItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                int nkey = (int)e.KeyChar;
                if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
                if (nkey == 13)
                {
                    this.SelectNextControl(control, true, false, true, true);

                    if (!string.IsNullOrEmpty(control.Tag == null ? "" : control.Tag.ToString().Trim()))
                    {
                        return;
                    }
                }
                if ((int)e.KeyChar != 13)
                {
                    string[] headtext = new string[] { "名称", "数字码", "拼音码", "五笔码" };
                    string[] mappingname = new string[] { "ORDER_NAME", "ORDER_ID", "PY_CODE", "WB_CODE" };
                    string[] searchfields = new string[] { "ORDER_NAME", "ORDER_ID", "PY_CODE", "WB_CODE" };
                    int[] colwidth = new int[] { 150, 100, 100, 100 };

                    string ssql = string.Format(@"select ORDER_NAME,cast(ORDER_ID as varchar) as ORDER_ID,PY_CODE,WB_CODE from JC_HOITEMDICTION 
                                                    where ORDER_TYPE='6' and DELETE_BIT=0");

                    DataTable dtSrc = InstanceForm._database.GetDataTable(ssql);

                    TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);

                    f.sourceDataTable = dtSrc;

                    f.WorkForm = this;

                    f.srcControl = control;
                    f.Font = control.Font;
                    f.Width = 400;
                    f.ReciveString = e.KeyChar.ToString();
                    e.Handled = true;
                    if (f.ShowDialog() == DialogResult.Cancel)
                    {
                        control.Focus();
                        return;
                    }
                    else
                    {
                        control.Tag = f.SelectDataRow["ORDER_ID"].ToString().Trim();
                        control.Text = f.SelectDataRow["ORDER_NAME"].ToString().Trim();
                        this.SelectNextControl(control, true, false, true, true);
                    }
                }
            }
            catch { }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            //1、未登记  或者  已登记未审核
            //2、
            if (dataGridView1.CurrentRow == null)
                return;
            this.dataGridView1.EndEdit();

            DataGridViewRow dgvr = dataGridView1.CurrentRow;

            string id = dgvr.Cells["order_id"].Value.ToString();

            int iCfjb = int.Parse(dgvr.Cells["cfjb_id"].Value.ToString());
            int iKssDj = int.Parse(dgvr.Cells["kssdjid"].Value.ToString());

            Doctor _doc = new Doctor(long.Parse(dgvr.Cells["order_doc"].Value.ToString().Trim()), InstanceForm._database);

            //用药目的
            if (cmbYyMd.SelectedValue.ToString().Equals("-1"))
            {
                MessageBox.Show("抗菌药物登记操作时,必须选择【用药目的】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbYyMd.Focus();
                return;
            }

            //限制级抗菌药物和特殊抗菌药物必须录入 是否送检 
            if (iKssDj >= 2)
            {
                //该病人的预防用药次数大于0
                //并且用药目的选择为预防性用药
                if (cmbIsSj.SelectedValue.ToString().Equals("-1"))
                {
                    MessageBox.Show("【限制级抗菌物】或【特殊抗菌物】,必须选择【是否送检】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbIsSj.Focus();
                    return;
                }
            }

            ////特殊抗菌药物开启管理：不允许越多级登记医嘱
            //if (_cfg6206.Config.Trim().Equals("1") && iKssDj == 3)
            //{
            //    //只有主治医生以上权限才具备开立特殊抗菌药物
            //    if (_doc.TypeID == 4 || _doc.TypeID == 3)
            //    {
            //        //(CfLvl)iCfjb.ToString()
            //        //MessageBox.Show("【特殊抗菌物】不允许跨多级权限开立！\r\r药品处方级别：" + (CfLvl)iCfjb.ToString() + "！\r\r医生处方级别：" + (CfLvl)iCfjb.ToString() + "！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        MessageBox.Show("【副高】及以上权限才允许开立【特殊抗菌药物】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            if (_cfg6206.Config.Trim().Equals("1") && iKssDj == 3 && _cfg6205.Config.Trim().Equals("1") && iCfjb < _doc.TypeID)
            {
                //越级不允许开立 特殊抗菌药物 
                MessageBox.Show("【越级】不允许开立【特殊抗菌药物】,请删除该医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                //if (dgvr.Cells["mngtype"].Value.ToString().Trim().Equals("0"))
                //{
                //    //越级 特殊抗菌药物医嘱  不允许开长期医嘱
                //    MessageBox.Show("【越级】开立【特殊抗菌药物】,不允许开立【长嘱】,请删除该医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
            }

            string ssql = "";

            ssql = string.Format(@"select count(1) as Num from zy_kss_dj where order_id='{0}' and del_bit=0", id);

            int iNum = int.Parse(InstanceForm._database.GetDataResult(ssql).ToString().Trim());

            if (iNum == 0)
            {
                //未登记过
                //1 新增zy_kss_dj
                //2 如果是特殊抗菌药物,新增zy_kss_sqb
                //3 如果是越级的抗菌药物,新增zy_kss_sh

                #region"新增"

                //当本次选择为预防用药的抗菌药物
                if (DoRetYymdLvl(cmbYyMd.SelectedValue.ToString()).Equals("1"))
                {
                    //1、是否为长期医嘱【需要维护用药时限】
                    if (dgvr.Cells["mngtype"].Value.ToString().Trim().Equals("0"))
                    {
                        if (cmbYySx.SelectedValue.ToString().Equals("-1"))
                        {
                            MessageBox.Show("长期医嘱选择为预防性用药时，必须选择【用药时限】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbYySx.Focus();
                            return;
                        }

                        //选择为大于48小时的长嘱时
                        if (cmbYySx.SelectedValue.ToString().Equals("3"))
                        {
                            if (string.IsNullOrEmpty(txtBcMemo.Text.Trim()))
                            {
                                MessageBox.Show("预防性用药的长期医嘱时限大于48H，必须填写【长时限说明】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtBcMemo.Focus();
                                return;
                            }
                        }
                    }

                    //2、是否第一次预防性用药(一个病人原则上只允许选择一次预防用药，若选择第二次，则弹出原因填写框)
                    ssql = string.Format(@"select count(1) as num from zy_kss_dj 
                                        where inpatient_id='{0}' and baby_id='{1}' and del_bit=0 and yymd='1'", _BinID, _BabyID);

                    int iYfYy = int.Parse(InstanceForm._database.GetDataResult(ssql).ToString().Trim());

                    if (iYfYy > 0)
                    {
                        //该病人的预防用药次数大于0
                        //并且用药目的选择为预防性用药
                        if (cmbMemo.SelectedValue.ToString().Equals("-1"))
                        {
                            MessageBox.Show("该病人已经登记【预防性治疗】的抗生素，重复登记【预防性治疗】必须选择【目的说明】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbMemo.Focus();
                            return;
                        }
                    }
                }

                InstanceForm._database.BeginTransaction();
                try
                {
                    string guid = PubStaticFun.NewGuid().ToString();

                    //1、新增抗生素登记
                    //                    ssql = string.Format(@"insert into zy_kss_dj (id,inpatient_id,baby_id,zyzd,ssitem_id,group_id,order_id,order_type,dept_id,
                    //                                                            yymd,yymd_memo,yymd_bc,yy_sx,byjc_bit,byjc_memo,dj_man,dj_date,del_bit,memo,type_id,cfjb_id,kssdjid)
                    //                                             values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'
                    //                                                    ,'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')"
                    //                                   , guid, _BinID, _BabyID, txtZyZd.Text, Convertor.IsNull(txtSsItem.Tag, "-1"),
                    //                                   dgvr.Cells["grp_no"].Value.ToString(), id, dgvr.Cells["mngtype"].Value.ToString(), InstanceForm._currentDept.DeptId,
                    //                                   cmbYyMd.SelectedValue.ToString(), Convertor.IsNull(cmbMemo.SelectedValue.ToString(), "-1"), txtBcMemo.Text, cmbYySx.SelectedValue.ToString(),
                    //                                   cmbIsSj.SelectedValue.ToString(), txtByj.Text, InstanceForm._currentUser.Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", txtMemo.Text,
                    //                                   _doc.TypeID, dgvr.Cells["cfjb_id"].Value.ToString(), dgvr.Cells["kssdjid"].Value.ToString());
                    ssql = string.Format(@"insert into zy_kss_dj (id,inpatient_id,baby_id,zyzd,ssitem_id,group_id,order_id,order_type,dept_id,
                                                            yymd,yymd_xx,yymd_memo,yymd_bc,yy_sx,byjc_bit,byjc_memo,dj_man,dj_date,del_bit,memo,type_id,cfjb_id,kssdjid)
                                             values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'
                                                    ,'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')"
                                   , guid, _BinID, _BabyID, txtZyZd.Text, "-1",
                                   dgvr.Cells["grp_no"].Value.ToString(), id, dgvr.Cells["mngtype"].Value.ToString(), InstanceForm._currentDept.DeptId,
                                   DoRetYymdLvl(cmbYyMd.SelectedValue.ToString().Trim()), cmbYyMd.SelectedValue.ToString(), Convertor.IsNull(cmbMemo.SelectedValue.ToString(), "-1"), txtBcMemo.Text, cmbYySx.SelectedValue.ToString(),
                                   cmbIsSj.SelectedValue.ToString(), txtByj.Text, _doc.Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", txtMemo.Text,
                                   _doc.TypeID, iCfjb, iKssDj);
                    int iReturn = InstanceForm._database.DoCommand(ssql);
                    if (iReturn != 1)
                    {
                        throw new Exception(" 【新增抗生素登记信息】新增失败");
                    }

                    //参数打开并且越级才新增
                    if (_cfg6205.Config.Trim().Equals("1") && iCfjb < _doc.TypeID)
                    {
                        string shbz = "0";
                        string bdate = _cfg6223.Config.Trim();
                        if (!string.IsNullOrEmpty(bdate))
                        {
                            bdate = DateTime.Now.ToString("yyyy-MM-dd") + " " + bdate;

                            try
                            {
                                string[] strs = _cfg6224.Config.Split('$');
                                int iHour = int.Parse(strs[0].Trim());
                                int iMin = int.Parse(strs[1].Trim());

                                DateTime kssBDate = DateTime.Parse(bdate);
                                DateTime kssEDate = kssBDate.AddHours(iHour).AddMinutes(iMin);

                                //在设置时限内的【非特殊抗菌药物】的临时医嘱：启用自动审核功能
                                if (dgvr.Cells["mngtype"].Value.ToString().Trim().Equals("1"))
                                {
                                    if (DateTime.Compare(kssBDate, DateTime.Now) < 0 && DateTime.Compare(kssEDate, DateTime.Now) > 0 && iKssDj != 3)
                                    {
                                        shbz = "1";
                                    }
                                }
                            }
                            catch { }
                        }

                        //2、新增抗生素待越级审核信息
                        ssql = string.Format(@"insert into zy_kss_sh (ID,ORDER_ID,CJID,S_YPPM,CFJB,EMPLOYEE_ID,YS_TYPEID,SHBZ,DJR,DJSJ,DEPT_ID,INPATIENT_ID,BABY_ID,GROUP_ID) values 
                                            ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')"
                                                , PubStaticFun.NewGuid().ToString(), id, dgvr.Cells["cjid"].Value.ToString().Trim(),
                                                dgvr.Cells["order_context"].Value.ToString().Trim(), dgvr.Cells["cfjb_id"].Value.ToString().Trim(),
                                                _doc.EmployeeId, _doc.TypeID, shbz,
                                                _doc.EmployeeId, DateTime.Now, InstanceForm._currentDept.DeptId,
                                                _BinID, _BabyID, dgvr.Cells["grp_no"].Value.ToString());

                        iReturn = InstanceForm._database.DoCommand(ssql);
                        if (iReturn != 1)
                        {
                            throw new Exception("【新增抗生素待越级审核信息】新增失败");
                        }
                    }

                    //启用特殊抗菌药物管理
                    if (_cfg6206.Config.Trim().Equals("1") && iKssDj == 3)
                    {
                        string shbz = "0";//审核标志
                        string bsbz = "-1";//补审标志【默认插入-1】

                        //1、判断开单医生是否为审核人
                        //2、临嘱不需要审核
                        if (dgvr.Cells["mngtype"].Value.ToString().Trim().Equals("1"))
                        {
                            shbz = "1";//审核标志
                        }
                        else if (dgvr.Cells["mngtype"].Value.ToString().Trim().Equals("0"))
                        {
                            //长期医嘱判断开单医生是否审核人

                            ssql = string.Format(@"select count(1) as Num from jc_kss_tsshr where employee_id='{0}' and dept_id='{1}'", _doc.EmployeeId, InstanceForm._currentDept.DeptId);

                            int iKssShr = int.Parse(InstanceForm._database.GetDataResult(ssql).ToString().Trim());

                            if (iKssShr > 0)
                            {
                                shbz = "1";//审核标志
                            }
                        }

                        //3、新增审核抗生素待申请信息
                        ssql = string.Format(@"insert into zy_kss_sqb(DJID          ,
                                                                   INPATIENT_ID		,
                                                                   baby_id			,
                                                                   order_id			,
                                                                   group_id			,
                                                                   dept_id			,
                                                                   zyzd				,
                                                                   shyj				,
                                                                   apply_man		,
                                                                   apply_time		,
                                                                   shbz	        	,

                                                                    bqbz            ,
                                                                   ssitem_id        ,

                                                                   yymd             ,
                                                                   yymd_xx          ,
                                                                   yymd_memo        ,
                                                                   yymd_bc          ,
                                                                   yy_sx            ,

                                                                   byjc_bit         ,
                                                                   byjc_memo        ,
                                                                   ymjg             ,
                                                                   ymjg_memo        ,
                                                                   byj_gm           ,
                                                                   memo             ,
                                                                   del_bit)
                                                            VALUES
                                                    ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')"
                                                        , PubStaticFun.NewGuid().ToString(), _BinID, _BabyID, id, dgvr.Cells["grp_no"].Value.ToString(),
                                                        InstanceForm._currentDept.DeptId, txtZyZd.Text, "", _doc.EmployeeId, DateTime.Now,
                                                        shbz,
                                                        bsbz,
                                                        Convertor.IsNull(txtSsItem.Tag, "-1"),
                                                        DoRetYymdLvl(cmbYyMd.SelectedValue.ToString()), cmbYyMd.SelectedValue.ToString(), cmbMemo.SelectedValue.ToString(), txtBcMemo.Text, cmbYySx.SelectedValue.ToString(),
                                                        cmbIsSj.SelectedValue.ToString(), txtByj.Text, cmbYmJg.SelectedValue.ToString(), txtByj.Text, cmbIsMg.SelectedValue.ToString(), txtMemo.Text, "0");

                        iReturn = InstanceForm._database.DoCommand(ssql);
                        if (iReturn != 1)
                        {
                            throw new Exception("【新增审核抗生素待申请信息】新增失败");
                        }
                    }

                    InstanceForm._database.CommitTransaction();

                    MessageBox.Show("操作成功", "提示");

                    DoQuery();

                }
                catch (Exception ex)
                {
                    InstanceForm._database.RollbackTransaction();
                    MessageBox.Show("抗生素登记操作出错\r\r" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion
            }
            else if (iNum == 1)
            {
                return;

                /*

                #region"修改"
                //已登记过：如果已审核
                //1 zy_kss_dj
                //2 如果是特殊抗菌药物,新增zy_kss_sqb
                //3 如果是越级的抗菌药物,新增zy_kss_sh

                //校验特殊抗菌药物是否已经审核
                ssql = string.Format(@"select count(1) as num from zy_kss_sqb 
                                        where order_id='{0}' and del_bit=0 and shbz='1'", _BinID, _BabyID);

                int iSh = int.Parse(InstanceForm._database.GetDataTable(ssql).ToString().Trim());

                if (iSh > 0)
                {
                    MessageBox.Show("该医嘱 的特殊抗菌药物申请已经被审核,不能进行修改操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //当本次选择为预防性的抗菌药物
                if (DoRetYymdLvl(cmbYyMd.SelectedValue.ToString()).Equals("1"))
                {
                    //1、是否为长期医嘱【需要维护用药时限】
                    if (dgvr.Cells["mngtype"].Value.ToString().Trim().Equals("0"))
                    {
                        if (cmbYySx.SelectedValue.ToString().Equals("-1"))
                        {
                            MessageBox.Show("长期医嘱选择为预防性用药时，必须选择【用药时限】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbYySx.Focus();
                            return;
                        }

                        //选择为大于48小时的长嘱时
                        if (cmbYySx.SelectedValue.ToString().Equals("3"))
                        {
                            if (string.IsNullOrEmpty(txtBcMemo.Text.Trim()))
                            {
                                MessageBox.Show("预防性用药的长期医嘱时限大于48H，必须填写【长时限说明】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtBcMemo.Focus();
                                return;
                            }
                        }
                    }

                    //2、是否第一次预防性用药(一个病人原则上只允许选择一次预防用药，若选择第二次，则弹出原因填写框)
                    ssql = string.Format(@"select count(1) as num from zy_kss_dj 
                                        where inpatient_id='{0}' and baby_id='{1}' and del_bit=0 and yymd='1' and order_id<>'{2}'", _BinID, _BabyID, id);

                    int iYfYy = int.Parse(InstanceForm._database.GetDataResult(ssql).ToString().Trim());

                    if (iYfYy > 0)
                    {
                        //该病人的预防用药次数大于0
                        //并且用药目的选择为预防性用药
                        if (cmbMemo.SelectedValue.ToString().Equals("-1"))
                        {
                            MessageBox.Show("该病人已经登记【预防性治疗】的抗生素，重复登记【预防性治疗】必须选择【目的说明】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbMemo.Focus();
                            return;
                        }
                    }
                }

                InstanceForm._database.BeginTransaction();
                try
                {

                    //1、修改抗生素登记信息
                    ssql = string.Format(@"update zy_kss_dj set  zyzd	='{0}', ssitem_id='{1}',yymd='{2}',yymd_xx='{12}',yymd_memo='{3}',yymd_bc='{4}',yy_sx='{5}',byjc_bit='{6}',
                                                                   byjc_memo='{7}',memo='{8}',Mod_man='{9}',Mod_time='{10}'
                                                                    where order_id='{11}'", txtZyZd.Text, Convertor.IsNull(txtSsItem.Tag, "-1"),
                                          DoRetYymdLvl(cmbYyMd.SelectedValue.ToString().Trim()), cmbMemo.SelectedValue.ToString(), txtBcMemo.Text, cmbYySx.SelectedValue.ToString(),
                                          cmbIsSj.SelectedValue.ToString(), txtByj.Text, txtMemo.Text, InstanceForm._currentUser.Name, DateTime.Now, id, cmbYyMd.SelectedValue.ToString());

                    int iReturn = InstanceForm._database.DoCommand(ssql);


                    if (_cfg6206.Config.Trim().Equals("1") && iKssDj == 3)
                    {
                        //3、新增审核抗生素待申请信息
                        ssql = string.Format(@"update zy_kss_sqb set  zyzd	='{0}', ssitem_id='{1}',yymd='{2}',yymd_xx='{15}',yymd_memo='{3}',yymd_bc='{4}',yy_sx='{5}',byjc_bit='{6}',
                                                                   byjc_memo='{7}',ymjg='{8}',ymjg_memo='{9}',byj_gm='{10}',memo='{11}',Mod_man='{12}',Mod_time='{13}'
                                                                    where order_id='{14}'", txtZyZd.Text, Convertor.IsNull(txtSsItem.Tag, "-1"),
                                                                                              DoRetYymdLvl(cmbYyMd.SelectedValue.ToString()), cmbMemo.SelectedValue.ToString(), txtBcMemo.Text, cmbYySx.SelectedValue.ToString(),
                                                                                              cmbIsSj.SelectedValue.ToString(), txtByj.Text, cmbYmJg.SelectedValue.ToString(), txtByj.Text, cmbIsMg.SelectedValue.ToString(), txtMemo.Text,
                                                                                              InstanceForm._currentUser.Name, DateTime.Now, id, cmbYyMd.SelectedValue.ToString());
                        iReturn = InstanceForm._database.DoCommand(ssql);
                    }

                    InstanceForm._database.CommitTransaction();

                    DoQuery();
                }
                catch (Exception ex)
                {
                    InstanceForm._database.RollbackTransaction();
                    MessageBox.Show("抗生素登记操作出错\r\r" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion

                */
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("order_context", typeof(string));
            dt.Columns.Add("order_bdate", typeof(string));
            dt.Columns.Add("memo", typeof(string));

            //提示未登记抗生素
            string strSql = string.Format(@"select b.order_bdate,b.order_context,
                                                case when c.shbz='0' then '越级未审' else '' end as CHK_YJ, 
                                                case when d.shbz='0' then '特殊抗生素未审' else '' end as CHK_TS 
	                                            from zy_kss_dj a 
	                                            inner join ZY_ORDERRECORD b on a.order_id=b.ORDER_ID and b.DELETE_BIT=0 
	                                            left join ZY_KSS_SH c on a.order_id=c.ORDER_ID and c.DEL_BIT=0
	                                            left join zy_kss_sqb d on a.order_id=d.ORDER_ID and d.DEL_BIT=0
	                                            where a.inpatient_id='{0}'
	                                            and a.baby_id='{1}'
                                            and a.del_bit=0  
                                            and (c.SHBZ=0 or d.shbz=0)", _BinID, _BabyID);

            DataTable dtUnVal = InstanceForm._database.GetDataTable(strSql);

            DataTable dtUnDj = dataGridView1.DataSource as DataTable;

            if (dtUnVal != null && dtUnVal.Rows.Count > 0)
            {
                for (int i = 0; i < dtUnVal.Rows.Count; i++)
                {
                    DataRow drNew = dt.NewRow();
                    drNew["order_context"] = dtUnVal.Rows[i]["order_context"];
                    drNew["order_bdate"] = dtUnVal.Rows[i]["order_bdate"];
                    drNew["memo"] = dtUnVal.Rows[i]["CHK_YJ"].ToString().Trim() + "  " + dtUnVal.Rows[i]["CHK_TS"].ToString().Trim();
                    dt.Rows.Add(drNew);
                }
            }

            if (dtUnDj != null && dtUnDj.Rows.Count > 0)
            {
                for (int i = 0; i < dtUnDj.Rows.Count; i++)
                {
                    DataRow drNew = dt.NewRow();
                    drNew["order_context"] = dtUnDj.Rows[i]["order_context"];
                    drNew["order_bdate"] = dtUnDj.Rows[i]["order_bdate"];
                    drNew["memo"] = "未登记";
                    dt.Rows.Add(drNew);
                }
            }

            if (dt.Rows.Count > 0)
            {
                string strShow = "\n\n有下面医嘱组不能被发送,是否继续退出：\n";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strShow += "\n\n     " + dt.Rows[i]["order_bdate"].ToString().Trim() + "  " + dt.Rows[i]["order_context"].ToString().Trim() + "  原因：" + dt.Rows[i]["memo"].ToString().Trim();
                }

                if (MessageBox.Show(strShow, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
            }

            this.Close();
        }

        /// <summary>
        /// 处理医嘱DataTable 绑定到 抗生素登记界面
        /// </summary>
        private DataTable BindData(DataTable dtYz)
        {
            //string[] GrdHeaderText =   { "ID*", "类*", "嘱号*", "录入时间", "类型*", "警示灯", "医嘱内容", "规格", "剂量", "单位*", "用法", "频率", "首次", "末次", "剂数", "滴量", "执行人", "执行时间*", "停嘱时间*", "下嘱医生", "停嘱医生", "执行科室*", "打印", "打印规格" };
            //string[] GrdHeaderText =   { "ID*", "类*", "嘱号*", "录入时间", "类型*", "警示灯", "医嘱内容", "规格", "剂量", "单位*", "用法", "频率", "首日数", "付数", "滴量", "天数", "总量", "总单位", "执行护士*", "执行时间*", "停嘱时间*", "下嘱医生", "执行科室*", "DEL_PRINT", "IsprintYPGG", "实际执行" };
            DataTable dt = new DataTable();
            dt.Columns.Add("inpatient_id", typeof(string));
            dt.Columns.Add("baby_id", typeof(string));
            dt.Columns.Add("order_id", typeof(string));
            dt.Columns.Add("grp_no", typeof(string));
            dt.Columns.Add("mngtype", typeof(string));
            dt.Columns.Add("order_bdate", typeof(string));
            dt.Columns.Add("cjid", typeof(string));
            dt.Columns.Add("order_context", typeof(string));
            dt.Columns.Add("spec", typeof(string));
            dt.Columns.Add("cfjb_id", typeof(string));
            dt.Columns.Add("cfjb_name", typeof(string));
            dt.Columns.Add("kssdjid", typeof(string));
            dt.Columns.Add("kssdj_name", typeof(string));
            dt.Columns.Add("is_yj", typeof(string));
            dt.Columns.Add("IS_TS", typeof(string));
            dt.Columns.Add("status_flag", typeof(string));
            dt.Columns.Add("order_doc", typeof(string));
            //dt.Columns.Add("chk_yj", typeof(string));
            //dt.Columns.Add("chk_ts", typeof(string));

            foreach (DataRow drYz in dtYz.Rows)
            {
                string cjid = drYz["HOITEM_ID"].ToString().Trim();
                string id = drYz["ID"].ToString().Trim();//医嘱id

                Doctor _doc = new Doctor(long.Parse(drYz["order_doc"].ToString().Trim()), InstanceForm._database);
                long ysType = _doc.TypeID;

                //判断该医嘱是否登记
                string strSql = string.Format(@"select count(1) as Num from zy_kss_dj where order_id='{0}' and  del_bit=0 ", id);
                int iCnt = int.Parse(InstanceForm._database.GetDataResult(strSql).ToString());
                if (iCnt > 0)
                {
                    continue;
                }

                DataRow dr = dt.NewRow();

                dr["cjid"] = cjid;
                dr["inpatient_id"] = _BinID;
                dr["baby_id"] = _BabyID;
                dr["order_id"] = id;
                dr["grp_no"] = drYz["嘱号"].ToString().Trim();
                dr["mngtype"] = drYz["mngtype"].ToString().Trim();
                dr["order_context"] = drYz["医嘱内容"].ToString().Trim();
                dr["spec"] = drYz["规格"].ToString().Trim();
                dr["order_bdate"] = drYz["开始时间"].ToString().Trim();
                dr["status_flag"] = drYz["status_flag"].ToString().Trim();
                dr["order_doc"] = drYz["order_doc"].ToString().Trim();

                try
                {
                    string ssql = string.Format(@"select CFJB,kssdjid from VI_YP_YPCD where cjid='{0}' and BDELETE=0", cjid);
                    DataTable dtYp = InstanceForm._database.GetDataTable(ssql);

                    if (dtYp != null && dtYp.Rows.Count > 0)
                    {
                        int cfjb = int.Parse(dtYp.Rows[0]["CFJB"].ToString().Trim());
                        int kssdjid = int.Parse(dtYp.Rows[0]["kssdjid"].ToString().Trim());
                        string cfjb_name = ((CfLvl)cfjb).ToString();
                        string kss_name = ((KssLvl)kssdjid).ToString();

                        dr["cfjb_id"] = cfjb;
                        dr["cfjb_name"] = cfjb_name;
                        dr["kssdjid"] = kssdjid;
                        dr["kssdj_name"] = kss_name;
                        dr["is_yj"] = cfjb < ysType ? "是" : "否";
                        dr["IS_TS"] = kssdjid == 3 ? "是" : "否";
                    }
                }
                catch { }

                //try
                //{
                //    string ssql = string.Format(@"select count(1) as NUM from zy_kss_sh where order_id='{0}' and SHBZ=1 and del_bit=0", id);
                //    int iNum = int.Parse(InstanceForm._database.GetDataResult(ssql).ToString().Trim());
                //    dr["chk_yj"] = iNum > 0 ? "是" : "否";
                //}
                //catch { }

                //try
                //{
                //    string ssql = string.Format(@"select count(1) as NUM from zy_kss_sqb where order_id='{0}' and SHBZ=1 and del_bit=0", id);
                //    int iNum = int.Parse(InstanceForm._database.GetDataResult(ssql).ToString().Trim());
                //    dr["chk_ts"] = iNum > 0 ? "是" : "否";
                //}
                //catch { }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        private DataTable BindDjData()
        {
            try
            {
                string ssql = string.Format(@"select 
                                             a.inpatient_id,
                                             a.baby_id,
                                             a.order_id,
                                             b.GROUP_ID as grp_no,
                                             b.MNGTYPE,
                                             b.order_bdate,
                                             b.HOITEM_ID as cjid,
                                             b.ORDER_CONTEXT ,
                                             b.ORDER_SPEC as spec,
                                             b.STATUS_FLAG,
                                             a.cfjb_id,
                                             case a.cfjb_id when 1 then '主任医生' when 2 then '副主任医生' when 3 then '主治医生' when 4 then '经治医生' end as cfjb_name,
                                             a.kssdjid as kssdjid,
                                             case a.kssdjid when 1 then '非限制级' when 2 then '限制级' when 3 then '特殊级'  end as kssdj_name,
                                             case when a.type_id>a.cfjb_id and '{2}'='1' then '是' else '否' end as is_yj,
                                             case when a.kssdjid=3 and '{3}'='1' then '是' else '否' end as IS_TS,
                                             case when c.shbz='0' then '待审' when c.shbz='1' then '已审' else '' end as chk_yj,
                                             case when d.shbz='0' then '待审' when d.shbz='1'  then '已审' else '' end as chk_ts,
                                             a.ssitem_id,
                                             dbo.FUN_ZY_SEEKITEMNAME(a.ssitem_id) as ssitem_name,
                                             a.yymd,
                                             a.yymd_xx,
                                             a.yymd_memo,
                                             a.yymd_bc,
                                             a.yy_sx,
                                             a.byjc_bit,
                                             a.byjc_memo,
                                             isnull(d.ymjg,'-1') as ymjg,
                                             isnull(d.ymjg_memo,'') as ymjg_memo,
                                             isnull(d.byj_gm,'-1') as byj_gm,
                                             a.memo
                                            from zy_kss_dj a 
                                            inner join ZY_ORDERRECORD b on a.order_id=b.ORDER_ID and b.DELETE_BIT=0
                                            inner join VI_YP_YPCD e on b.HOITEM_ID=e.cjid and e.BDELETE=0
                                            left join ZY_KSS_SH c on a.order_id=c.ORDER_ID and c.DEL_BIT=0
                                            left join zy_kss_sqb d on a.order_id=d.ORDER_ID and d.DEL_BIT=0
                                            where a.inpatient_id='{0}'
                                            and a.baby_id='{1}'
                                            and a.del_bit=0 order by is_yj desc,IS_TS desc,chk_yj asc,chk_ts asc",
                                            _BinID, _BabyID, _cfg6205.Config.Trim(), _cfg6206.Config.Trim());

                DataTable dt = InstanceForm._database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        private void DoQuery()
        {
            try
            {
                DataTable dt = BindData(_dtInKss);
                dataGridView1.DataSource = dt;
                (dataGridView1.DataSource as DataTable).AcceptChanges();

                dataGridView1_CurrentCellChanged(null, null);
            }
            catch { }

            try
            {
                DataTable dt = BindDjData();
                dataGridView2.DataSource = dt;
                (dataGridView2.DataSource as DataTable).AcceptChanges();
            }
            catch { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                dataGridView1_CurrentCellChanged(null, null);
                btnSure.Enabled = true;
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                dataGridView2_CurrentCellChanged(null, null);
                btnSure.Enabled = false;
            }
        }

        private void cmbYySx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //48H以上   
            if (cmbYySx.SelectedValue.ToString().Trim().Equals("3"))
            {
                lblShow.Visible = true;
            }
            else
            {

                lblShow.Visible = false;
            }
        }

        private void chkTsKj_CheckedChanged(object sender, EventArgs e)
        {

            grpZrSh.Enabled = chkTsKj.Checked;

            dataGridView3.BackgroundColor = chkTsKj.Checked ? dataGridView1.BackgroundColor : Color.White;

            try
            {
                DataTable dt = dataGridView3.DataSource as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["IS_HZCHK"] = chkTsKj.Checked.ToString();
                }

                dataGridView3.DataSource = dt;
            }
            catch
            { }

        }

        private void chkYjSy_CheckedChanged(object sender, EventArgs e)
        {
            grpYjSh.Enabled = chkYjSy.Checked;

            dataGridView4.BackgroundColor = chkYjSy.Checked ? dataGridView1.BackgroundColor : Color.White;

            try
            {
                DataTable dt = dataGridView4.DataSource as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["IS_YJCHK"] = chkYjSy.Checked.ToString();
                }

                dataGridView4.DataSource = dt;
            }
            catch
            { }
        }

        private void ctr_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            this.SelectNextControl(control, true, false, true, true);
        }

        private string DoRetYymdLvl(string strLvl)
        {
            string sRet = "";
            switch (strLvl)
            {
                case "1":
                case "2":
                case "3":
                    sRet = "1";
                    break;
                case "4":
                case "5":
                case "6":
                case "7":
                    sRet = "2";
                    break;
            }
            return sRet;
        }

        private void cmbYyMd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab != tabPage1)
                    return;

                if (dataGridView1.CurrentRow == null)
                    return;
                this.dataGridView1.EndEdit();

                DataGridViewRow dgvr = dataGridView1.CurrentRow;

                string orderType = dgvr.Cells["MNGTYPE"].Value.ToString();
                string cjid = dgvr.Cells["cjid"].Value.ToString();


                bool bEnable = DoCheckKssEnable(cmbYyMd.SelectedValue.ToString(), cjid);
                if (!bEnable)
                {
                    //不属于用药范围   则置"-1"  重新选择
                    cmbYyMd.SelectedIndex = 0;
                }

                if (orderType.Trim().Equals("0") &&
                    (cmbYyMd.SelectedValue.ToString().Equals("1") || cmbYyMd.SelectedValue.ToString().Equals("2") || cmbYyMd.SelectedValue.ToString().Equals("3"))
                    )
                {
                    pnlLng.Enabled = true;
                    lblLngOrder.Visible = true;
                }
                else
                {
                    pnlLng.Enabled = false;
                    lblLngOrder.Visible = false;
                }
            }
            catch { }
        }

        /// <summary>
        /// 校验该  抗生素  是否属于该  用药目的目录
        /// </summary>
        /// <param name="yymd"></param>
        /// <param name="cjid"></param>
        /// <returns></returns>
        private bool DoCheckKssEnable(string yymd, string cjid)
        {
            bool userOne = yymd.Equals("2");
            bool userTwo = yymd.Equals("3");

            string strSql = "";

            if (userOne)
            {
                strSql = string.Format(@" select count(1) as num from jc_kssitem where xmid={0} and xmly=1 and use_one=1 and del_bit=0", cjid);


                int iNum = Convert.ToInt32(InstanceForm._database.GetDataResult(strSql).ToString());

                if (iNum <= 0)
                {
                    //抗生素不属于用药范围
                    strSql = string.Format(@" select S_YPPM,S_YPGG from jc_kssitem a
                                                inner join YP_YPCJD b on a.xmid=b.CJID and a.xmly=1
                                                where a.Use_one=1 and a.del_bit=0 and b.BDELETE=0");

                    DataTable dt = InstanceForm._database.GetDataTable(strSql);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("该医嘱所用药品不属于一类切口手术用药范围,请删除医嘱！", "提示");
                        return false;
                    }

                    string strMsg = "该医嘱所用药品不属于一类切口手术用药范围,请删除医嘱！\n  可用药范围：\n";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strMsg += "品名：" + Convertor.IsNull(dt.Rows[i]["S_YPPM"], "") + "  规格：" + Convertor.IsNull(dt.Rows[i]["S_YPGG"], "") + "\n";
                    }
                    MessageBox.Show(strMsg, "提示");

                    return false;
                }

            }

            if (userTwo)
            {
                strSql = string.Format(@" select count(1) as num from jc_kssitem where xmid={0} and xmly=1 and use_two=1 and del_bit=0", cjid);
                int iNum = Convert.ToInt32(InstanceForm._database.GetDataResult(strSql).ToString());

                if (iNum <= 0)
                {
                    //抗生素不属于用药范围
                    strSql = string.Format(@" select S_YPPM,S_YPGG from jc_kssitem a
                                                inner join YP_YPCJD b on a.xmid=b.CJID and a.xmly=1
                                                where a.use_two=1 and a.del_bit=0 and b.BDELETE=0");

                    DataTable dt = InstanceForm._database.GetDataTable(strSql);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("该医嘱所用药品不属于一类切口手术用药范围,请删除医嘱！", "提示");
                        return false;
                    }

                    string strMsg = "该医嘱所用药品不属于二类切口手术用药范围,请删除医嘱！\n  可用药范围：\n";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strMsg += "品名：" + Convertor.IsNull(dt.Rows[i]["S_YPPM"], "") + "  规格：" + Convertor.IsNull(dt.Rows[i]["S_YPGG"], "") + "\n";
                    }

                    MessageBox.Show(strMsg, "提示");
                    return false;
                }
            }

            return true;
        }

    }

    /// <summary>
    /// 药品处方级别
    /// </summary>
    public enum CfLvl
    {
        经治医生 = 4,
        主治医生 = 3,
        副主任医生 = 2,
        主任医生 = 1
    }

    /// <summary>
    /// 药品处方级别
    /// </summary>
    public enum KssLvl
    {
        非限制级 = 1,
        限制级 = 2,
        特殊级 = 3
    }
}