using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using ts_mz_class;
using ts_mzys_class;

namespace ts_mzys_blcflr
{
    public partial class Frmzyz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private ts_jc_disease.BllHandler diseaseHandler;
        public struct Cf
        {
            public Guid brxxid;
            public Guid ghxxid;
        }

        public Cf Dqcf = new Cf(); 
        public Guid _ID;
        public bool bok = false;
        private DataTable Tbks;
        private DataTable Tbys;
        private string Blh;
        private string funName = "";
        public Frmzyz(MenuTag menuTag, string chineseName, Form mdiParent,Guid _brxxid)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            //入院途径
            string ssql = "select id,name from jc_rytj";
            DataTable tbry = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbrytj.DisplayMember = "name";
            cmbrytj.ValueMember = "id";
            cmbrytj.DataSource = tbry;

            this.Text = _chineseName;
            txttjys.Text = InstanceForm.BCurrentUser.Name;
            txttjys.Tag = InstanceForm.BCurrentUser.EmployeeId.ToString();
            chkrq.Checked = false;

            if (_brxxid != Guid.Empty)
            {
                //Blh = InstanceForm.BDatabase.GetDataResult("SELECT BLH FROM dbo.MZ_GHXX WHERE GHXXID='" + Dqcf.ghxxid + "'").ToString();
                GetBrxx(0, "", _brxxid, Guid.Empty);
                DataTable tb = mzys_zyz.GetRecord("", "", InstanceForm.BCurrentUser.EmployeeId,-1,0,"","", _brxxid, InstanceForm.BDatabase);
                dataGridView1.DataSource = tb;

                DataTable tb2 = mzys_zyz.GetRecord("", "", InstanceForm.BCurrentUser.EmployeeId, 0, 0, "", "", _brxxid, InstanceForm.BDatabase);
                if (tb2.Rows.Count > 0)
                {
                    mzys_zyz s = new mzys_zyz(new Guid(tb2.Rows[tb2.Rows.Count-1]["ID"].ToString()), InstanceForm.BDatabase);
                    _ID = new Guid(tb2.Rows[tb2.Rows.Count - 1]["ID"].ToString());
                    txttjys.Text = Fun.SeekEmpName(s.tjys, InstanceForm.BDatabase);
                    txttjys.Tag = s.tjys;
                    txtmzzd.Text = s.mzzdmc;
                    txtmzzd.Tag = s.mzzd;
                    txtryks.Text = Fun.SeekDeptName(s.dryks, InstanceForm.BDatabase);
                    txtryks.Tag = s.dryks;
                    txtyjj.Text = s.jyyj.ToString();
                    txtbz.Text = s.bz;
                    cmbrytj.SelectedValue = s.rytj.ToString();
                    lbldjsj.Text = s.djsj.ToString();
                    butsave.Text = "修改(&F2)";
                }

            }
            else
            {
                chkrq.Checked = true;
            }
            funName = "ys";


        }
        public Frmzyz(MenuTag menuTag, string chineseName, Form mdiParent, Guid _brxxid, string _blh)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            Blh = _blh;
            //入院途径（选项初始化）
            string ssql = "select id,name from jc_rytj";
            DataTable tbry = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbrytj.DisplayMember = "name";
            cmbrytj.ValueMember = "id";
            cmbrytj.DataSource = tbry;

            this.Text = _chineseName;
            txttjys.Text = InstanceForm.BCurrentUser.Name;
            txttjys.Tag = InstanceForm.BCurrentUser.EmployeeId.ToString();
            chkrq.Checked = false;

            if (_brxxid != Guid.Empty)
            {
                GetBrxx(0, "", _brxxid, Guid.Empty);
                DataTable tb = mzys_zyz.GetRecord("", "", InstanceForm.BCurrentUser.EmployeeId, -1, 0, "", "", _brxxid, InstanceForm.BDatabase);
                dataGridView1.DataSource = tb;

                DataTable tb2 = mzys_zyz.GetRecord("", "", InstanceForm.BCurrentUser.EmployeeId, 0, 0, "", "", _brxxid, InstanceForm.BDatabase);
                if (tb2.Rows.Count > 0)
                {
                    mzys_zyz s = new mzys_zyz(new Guid(tb2.Rows[tb2.Rows.Count - 1]["ID"].ToString()), InstanceForm.BDatabase);
                    _ID = new Guid(tb2.Rows[tb2.Rows.Count - 1]["ID"].ToString());
                    txttjys.Text = Fun.SeekEmpName(s.tjys, InstanceForm.BDatabase);
                    txttjys.Tag = s.tjys;
                    txtmzzd.Text = s.mzzdmc;
                    txtmzzd.Tag = s.mzzd;
                    txtryks.Text = Fun.SeekDeptName(s.dryks, InstanceForm.BDatabase);
                    txtryks.Tag = s.dryks;
                    txtyjj.Text = s.jyyj.ToString();
                    txtbz.Text = s.bz;
                    cmbrytj.SelectedValue = s.rytj.ToString();
                    lbldjsj.Text = s.djsj.ToString();
                    butsave.Text = "修改(&F2)";
                }
                else if (!String.IsNullOrEmpty(_blh))
                {
                    //150310  chencan 初始化门诊诊断
                    string sql = string.Format("select ZDBM,ZDMC from MZ_GHXX where BLH='{0}'", _blh);
                    DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        txtmzzd.Tag = dt.Rows[0]["ZDBM"].ToString();
                        txtmzzd.Text = dt.Rows[0]["ZDMC"].ToString();
                    }
                }
            }
            else
            {
                chkrq.Checked = true;
            }
            funName = "ys";
        }
        public Frmzyz(MenuTag menuTag, string chineseName, Form mdiParent, Guid _brxxid,int shbz)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            //入院途径
            string ssql = "select id,name from jc_rytj";
            DataTable tbry = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbrytj.DisplayMember = "name";
            cmbrytj.ValueMember = "id";
            cmbrytj.DataSource = tbry;

            this.Text = _chineseName;
            txttjys.Text = InstanceForm.BCurrentUser.Name;
            txttjys.Tag = InstanceForm.BCurrentUser.EmployeeId.ToString();
            funName = "ryk";
            if (_brxxid != Guid.Empty)
            {
               // Blh = InstanceForm.BDatabase.GetDataResult("SELECT BLH FROM dbo.MZ_GHXX WHERE GHXXID='" + Dqcf.ghxxid + "'").ToString();
                GetBrxx(0, "", _brxxid, Guid.Empty);
                DataTable tb = mzys_zyz.GetRecord("", "", 0, shbz,0,"","", _brxxid, InstanceForm.BDatabase);
                dataGridView1.DataSource = tb;

                tabControl1.TabPages.Remove(tabPage1);
                panel_tj.Visible = false;
            }

        }

        private void Frmcfsh_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            FunAddComboBox.AddKlx(false, 0, cmbklx1, InstanceForm.BDatabase);  
            FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = InstanceForm.BCurrentDept.Jgbm;
            //入院科室
             Tbks = Fun.GetRyks(Convert.ToInt64(cmbjgbm.SelectedValue), InstanceForm.BDatabase);
            //入院医生
             Tbys = Fun.GetGhys(0, InstanceForm.BDatabase); 
            diseaseHandler = new ts_jc_disease.BllHandler( InstanceForm.BDatabase , InstanceForm.BCurrentUser );

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                if ((int)e.KeyChar == 13)
                {
                    txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), control.Text.Trim(), InstanceForm.BDatabase);
                    GetBrxx( Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")),txtkh.Text, Guid.Empty, Guid.Empty);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        } 

        //获得病人信息
        private void GetBrxx(int klx, string kh,Guid brxxid,Guid kdjid)
        {
            Dqcf.brxxid = Guid.Empty;

            _ID = Guid.Empty;
            lblxm.Text = "";
            txtkh.Text = "";
            lblgzdw.Text = "";
            lbldwdh.Text = "";
            lbljtdz.Text = "";
            lbljtdh.Text = "";
            lblsfzh.Text = "";

            txtmzzd.Text = "";
            txtmzzd.Tag = "";
            txtryks.Text = "";
            txtryks.Tag = "";
            txtyjj.Text = "";
            txtbz.Text = "";

            if (klx == 0 && kh.Trim() != "") MessageBox.Show("请选择卡类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (klx != 0 && kh.Trim() == "" && brxxid==Guid.Empty && kdjid==Guid.Empty) return;

            DataTable Tab = null;

            string _kh = kh.Trim() == "" ? "" : Fun.returnKh(klx, kh, InstanceForm.BDatabase);
            Dqcf.brxxid = brxxid;

            if (kh.Trim() != "")
            {
                string ssq = "select * from YY_KDJB where klx=" + klx + " and kh='" + _kh.Trim() + "'  and ZFBZ=0 ";
                DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssq); 
                if (tbk.Rows.Count == 0)
                {
                    MessageBox.Show("没有找到卡信息，请确认卡号是否正确或卡没有作废");
                    return;
                }
                if (tbk.Rows.Count > 1)
                {
                    MessageBox.Show("找到多张同时有效的卡,请和系统管理员联系");
                    return;
                }
                lblxm.Text = tbk.Rows[0]["ckrxm"].ToString();
                Dqcf.brxxid = new Guid(tbk.Rows[0]["brxxid"].ToString());
            }
            string ssql = @"select brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,
                                          a.brxxid,gzdw 工作单位,gzdwdh 联系电话,jtdz 家庭地址,jtdh 家庭电话,
                                          brlxfs 本人联系方式,KLX,KH 卡号,a.pym,a.wbm,sfzh,brlxfs 
                                   from YY_BRXX a  left join YY_KDJB b on a.brxxid=b.brxxid and zfbz=0   ";
            ssql = ssql + "  where a.brxxid='"+Dqcf.brxxid+"'";
            if (kdjid!=Guid.Empty)
            {
                ssql = ssql + " and kdjid='"+kdjid+"'";
            }
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0 )
            {
                MessageBox.Show("没有找到病人信息", "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblxm.Text = tb.Rows[0]["姓名"].ToString();
            txtkh.Text = tb.Rows[0]["卡号"].ToString();
            txtkh1.Text = txtkh.Text;
            if (Convertor.IsNull(tb.Rows[0]["klx"].ToString(), "0") != "0")
            {
                cmbklx.SelectedValue = tb.Rows[0]["klx"].ToString();
                cmbklx1.SelectedValue = tb.Rows[0]["klx"].ToString();
            }
            lblxb.Text = tb.Rows[0]["性别"].ToString();
            lblnl.Text = tb.Rows[0]["年龄"].ToString();
            lblgzdw.Text = tb.Rows[0]["工作单位"].ToString();
            lbldwdh.Text = tb.Rows[0]["联系电话"].ToString();
            lbljtdz.Text = tb.Rows[0]["家庭地址"].ToString();
            lbljtdh.Text = tb.Rows[0]["家庭电话"].ToString();
            lblsfzh.Text = tb.Rows[0]["sfzh"].ToString();
            lblgrlxfs.Text = tb.Rows[0]["brlxfs"].ToString();
            butsave.Text = "保存";            
        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {

                MenuTag tag = new MenuTag();
                tag = _menuTag;
                tag.Function_Name = "Fun_ts_mz_kgl_kdj";
                tag.DllName = "ts_mz_gh";
                ts_mz_kgl.Frmbrxxcx f = new ts_mz_kgl.Frmbrxxcx(tag, "病人查询", null);
                f.txtbrxm.Text ="";
                f.txtbrxm.Focus();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();

                ReadCard card = new ReadCard(f.return_kdjid, InstanceForm.BDatabase);
                if (card.kdjid != Guid.Empty)
                {
                    cmbklx.SelectedValue = card.klx;
                    txtkh.Text = card.kh;
                    txtkh.Focus();
                    txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                }
                if (f.return_brxxid != Guid.Empty)
                    GetBrxx(0, "", f.return_brxxid, f.return_kdjid);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtmzzd_TextChanged(object sender, EventArgs e)
        {

        }

        private void butref_Click(object sender, EventArgs e)
        {
            try
            {
                string rq1 = chkrq.Checked==true?dtp1.Value.ToShortDateString():"";
                string rq2 = chkrq.Checked == true ? dtp2.Value.ToShortDateString() : "";

                DataTable tb = mzys_zyz.GetRecord(rq1, rq2,InstanceForm.BCurrentUser.EmployeeId,-1,
                    Convert.ToInt32(Convertor.IsNull(cmbklx1.SelectedValue,"0")),txtkh1.Text.Trim(),txtbrxm.Text.Trim(), Guid.Empty,InstanceForm.BDatabase);
                dataGridView1.DataSource = tb;
                this.tabPage2.Text = "查询(" + tb.Rows.Count.ToString() + ")";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dqcf.brxxid == Guid.Empty)
                {
                    MessageBox.Show("请输入病人信息", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbrytj.Text.Trim() == "")
                {
                    MessageBox.Show("入院途径必填", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtmzzd.Text == "")
                {
                    MessageBox.Show("请输入门诊诊断", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtryks.Text == "")
                {
                    MessageBox.Show("请输入待入院的科室", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convertor.IsNumeric(txtyjj.Text) == false)
                {
                    MessageBox.Show("入院押金请输入数字", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int err_code = -1;
                string err_text = "";
                Guid newid = Guid.Empty;
                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                mzys_zyz zyz = new mzys_zyz(_ID, InstanceForm.BDatabase);
                if (zyz.brybz == true)
                {
                    MessageBox.Show("该住院证已入院,您不能修改", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (zyz.djy != InstanceForm.BCurrentUser.EmployeeId && zyz.djy > 0)
                {
                    MessageBox.Show("该住院证不是您登记的,您不能修改", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                zyz.id = _ID;
                zyz.jgbm = InstanceForm._menuTag.Jgbm;
                zyz.brxxid = Dqcf.brxxid;
                zyz.mzzd = Convertor.IsNull(txtmzzd.Tag, "");
                zyz.mzzdmc = txtmzzd.Text.Trim();
                zyz.dryks = Convert.ToInt32(Convertor.IsNull(txtryks.Tag, "0"));
                zyz.tjys = Convert.ToInt32(Convertor.IsNull(txttjys.Tag, "0"));
                zyz.jyyj = Convert.ToDecimal(Convertor.IsNull(txtyjj.Text, "0"));
                zyz.bz = txtbz.Text;
                zyz.djsj = djsj;
                zyz.djy = InstanceForm.BCurrentUser.EmployeeId;
                zyz.rytj = Convert.ToInt32(Convertor.IsNull(cmbrytj.SelectedValue, "0"));
                zyz.tjks = InstanceForm.BCurrentDept.DeptId; //Modify By zp 2013-10-22 
                zyz.mzh = Blh;
                zyz.Save(out newid, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0) throw new Exception(err_text);
                MessageBox.Show(err_text);
                _ID = newid;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txttjys_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {

                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "py_code", "wb_code", "code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                    //Fun.GetDocZyks(Convert.ToInt64(cmbjgbm.SelectedValue), InstanceForm.BDatabase); ;
                f.WorkForm = this;
                f.srcControl = txttjys;
                f.Font = txttjys.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txttjys.Focus();
                }
                else
                {
                    txttjys.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txttjys.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtmzzd.Focus();
                }
            }
            else
            {
                if (Convert.ToInt32(txttjys.Tag) == 0 || txttjys.Text.Trim() == "") return;
                
                
            }
        }

        private void txtryks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Fun.GetRyks(Convert.ToInt64(cmbjgbm.SelectedValue), InstanceForm.BDatabase); ;
                f.WorkForm = this;
                f.srcControl = txtryks;
                f.Font = txtryks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtryks.Focus();
                    return;
                }
                else
                {
                    txtryks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtryks.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtyjj.Focus();
                }
            }
            else
            {
                if (txtryks.Text.Trim() != "") txtyjj.Focus();
            }
        }

        private void txtyjj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                txtbz.Focus();
        }

        private void txtmzzd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                //if (control.Text.Trim() == "") return;

                frmzd frm = new frmzd(this.diseaseHandler);
                frm.txtdm.Text = e.KeyChar.ToString();
                frm.txtdm.Select(frm.txtdm.Text.Length, 0);

                SystemCfg syszdwh = new SystemCfg(3008);
                if (syszdwh.Config == "0")
                {
                    frm.txtmc.Enabled = false;
                    frm.txtpym.Enabled = false;
                    frm.txtwb.Enabled = false;
                    frm.txtzy.Enabled = false;
                    frm.butadd.Enabled = false;
                }

                frm.ShowDialog();
                if (frm.bok == false) return;

                e.Handled = true;
                txtmzzd.Text = frm.returnValues;
                txtmzzd.Tag = frm.returnCode;

                txtryks.Focus();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butclose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                bool shbz = Convert.ToBoolean(tb.Rows[nrow]["已入院"]);
               _ID = new Guid(tb.Rows[nrow]["id"].ToString());
               if (funName == "ryk")
               {
                   if (shbz == true)
                   {
                       MessageBox.Show("该住院证已审核入院,不能再次入院", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   }
                   bok = true;

                   if (InstanceForm._communicateValue.Length > 4)
                   {
                       InstanceForm._communicateValue[2] = _ID;
                       InstanceForm._communicateValue[3] = true;
                       InstanceForm._communicateValue[4] = tb;

                   }
                   this.Close();
               }
               else
               {
                   tabControl1.SelectedTab = tabPage1;
                   mzys_zyz s = new mzys_zyz(_ID, InstanceForm.BDatabase);
                   txttjys.Text = Fun.SeekEmpName(s.tjys, InstanceForm.BDatabase);
                   txttjys.Tag = s.tjys;
                   txtmzzd.Text = s.mzzdmc;
                   txtmzzd.Tag = s.mzzd;
                   txtryks.Text = Fun.SeekDeptName(s.dryks, InstanceForm.BDatabase);
                   txtryks.Tag = s.dryks;
                   txtyjj.Text = s.jyyj.ToString();
                   txtbz.Text = s.bz;
                   cmbrytj.SelectedValue = s.rytj.ToString();
                   lbldjsj.Text = s.djsj.ToString();
                   butsave.Text = "修改(&F2)";
               }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkrq_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = chkrq.Checked == true ? true : false;
            dtp2.Enabled = chkrq.Checked == true ? true : false;
 
        }

        private void txtbz_KeyPress(object sender, KeyPressEventArgs e)
        {
            butsave.Focus();
        }

        private void Frmzyz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && butsave.Enabled == true)
            {
                butsave_Click(sender, e);
            }

            if (e.KeyCode == Keys.F3 )
            {
                butadd_Click(sender, e);
            }
        }

        private void mnubtg_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您确定要作废当前住院证吗？ ", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;

                
                Guid zyzid = new Guid(tb.Rows[nrow]["id"].ToString());
                mzys_zyz s = new mzys_zyz(zyzid, InstanceForm.BDatabase);
                if (s.djy!=InstanceForm.BCurrentUser.EmployeeId)
                    throw new Exception("该住院证不是您登记的,您不能删除");
                if (s.brybz == true)
                    throw new Exception("该住院证已审核入院,您不能删除");
                else
                    s.Delete(zyzid, InstanceForm.BDatabase);
                butref_Click(sender, e);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtkh1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtkh1.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh1.Text.Trim(), InstanceForm.BDatabase);
                butref_Click(sender, e);
            }
        }

        private void txtbrxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butref_Click(sender, e);
        }

        private void butadd_Click(object sender, EventArgs e)
        {
            txttjys.Text = "";
            txttjys.Tag = "0";
            txtmzzd.Text = "";
            txtmzzd.Tag = "0";
            txtryks.Text = "";
            txtryks.Tag = "0";
            txtyjj.Text = "";
            txtbz.Text = "";
            lbldjsj.Text = "";
            butsave.Text = "保存(&F2)";
            _ID = Guid.Empty;
            cmbrytj.SelectedIndex = 0;
            txttjys.Focus();

        }

        /// <summary>
        /// 打印住院证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butprint_Click(object sender, EventArgs e)
        {
            ParameterEx[] paramters = new ParameterEx[11];
            paramters[0].Text = "医院名称";
            paramters[0].Value = Constant.HospitalName;
            paramters[1].Text = "门诊号";
            paramters[1].Value = Blh;
            paramters[2].Text = "姓名";
            paramters[2].Value = lblxm.Text;
            paramters[3].Text = "临时诊断";
            paramters[3].Value = txtmzzd.Text;
            paramters[4].Text = "申请科室";
            paramters[4].Value = InstanceForm.BCurrentDept.DeptName;
            paramters[5].Text = "申请医师";
            paramters[5].Value = txttjys.Text;
            paramters[6].Text = "申请时间";
            paramters[6].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            paramters[7].Text = "护士注意事项";
            paramters[7].Value = txtbz.Text;
            paramters[8].Text = "年龄";
            paramters[8].Value = lblnl.Text;
            paramters[9].Text = "性别";
            paramters[9].Value = lblxb.Text;
            paramters[10].Text = "入院科室";
            paramters[10].Value = txtryks.Text;
            DataSet _dset = new DataSet(); 
            DataTable dt = new DataTable("收费明细"); 
            dt.Columns.Add("item_name", Type.GetType("System.String"));
            dt.Columns.Add("je", Type.GetType("System.String"));
            _dset.Tables.Add(dt);
            string reportFile = Constant.ApplicationDirectory + "\\Report\\MZ_住院证.rpt";
            TrasenFrame.Forms.FrmReportView fView = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);
        }

        private void butexport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;
            ts_jc_log.ExcelOper.ExportData_ForDataTable(dataGridView1, "住院证查询");
        }
    }
}