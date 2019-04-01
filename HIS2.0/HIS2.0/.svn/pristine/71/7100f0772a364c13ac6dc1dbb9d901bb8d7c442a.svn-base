using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using ts_mz_class;
using ts_mzys_class;

namespace ts_mzys_blcflr
{
    /// <summary>
    /// 门诊院感处置 add by zp 2013-07-10
    /// </summary>
    public partial class FrmYgcz_Mz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public ts_mzys_blcflr.Frmzyz.Cf Dqcf = new ts_mzys_blcflr.Frmzyz.Cf();
        public Guid _GHID;

        public FrmYgcz_Mz()
        {
            InitializeComponent();
        }

        public FrmYgcz_Mz(MenuTag menuTag, string chineseName, Form mdiParent, Guid _brxxid,Guid ghxxid)
        {   
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            _GHID=ghxxid;
            this.Text = _chineseName;
            BindCmb();
            if (_brxxid != Guid.Empty)
            {
                GetBrxx(0, "", _brxxid, Guid.Empty);
            }
           
            if (ghxxid != Guid.Empty)
            {
                BindYgInfo(ghxxid);
            } 
        }

        private void FrmYgcz_Mz_Load(object sender, EventArgs e)
        {
            if (new SystemCfg(3104).Config == "1") this.Text = "门诊日志";
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
            this.Rdb_cz.Checked = true;
        }

        private void BindYgInfo(Guid ghxx)
        {
            try
            {
                string sql = @"select YGCZID,YGBYBZ,KSDM,YSDM,BSCBZ,MEMO from MZ_YGINFO WHERE GHXXID='"+ghxx+"'";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                if (dt.Rows.Count < 1) return;

                this.cmbhzcz.SelectedValue = dt.Rows[0]["YGCZID"];
                this.Rtxt_Memo.Text = dt.Rows[0]["MEMO"].ToString();
                if (dt.Rows[0]["YGBYBZ"].ToString().Trim() == "0")
                    this.check_isby.Checked = true;
                else
                    this.check_isby.Checked = false;

            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void BindCmb()
        {
            try
            {
                string sql = @"SELECT ID,NAME FROM JC_YGCZCD WHERE BSCBZ=0";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                this.cmbhzcz.DisplayMember = "NAME";
                this.cmbhzcz.ValueMember = "ID";
                this.cmbhzcz.DataSource = dt;
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        //获得病人信息
        private void GetBrxx(int klx, string kh, Guid brxxid, Guid kdjid)
        {
            Dqcf.brxxid = Guid.Empty;

            lblxm.Text = "";
            txtkh.Text = "";
            lblgzdw.Text = "";
            lbldwdh.Text = "";
            lbljtdz.Text = "";
            lbljtdh.Text = "";
            lblsfzh.Text = "";

            if (klx == 0 && kh.Trim() != "") MessageBox.Show("请选择卡类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (klx != 0 && kh.Trim() == "" && brxxid == Guid.Empty && kdjid == Guid.Empty) return;

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

            string ssql = "select brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,a.brxxid,gzdw 工作单位,gzdwdh 联系电话,jtdz 家庭地址,jtdh 家庭电话,brlxfs 本人联系方式,KLX,KH 卡号,a.pym,a.wbm,sfzh,brlxfs from YY_BRXX a  left join YY_KDJB b on a.brxxid=b.brxxid and zfbz=0   ";

            ssql = ssql + "  where a.brxxid='" + Dqcf.brxxid + "'";


            if (kdjid != Guid.Empty)
            {
                ssql = ssql + " and kdjid='" + kdjid + "'";
            }

            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("没有找到病人信息", "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblxm.Text = tb.Rows[0]["姓名"].ToString();

            txtkh.Text = tb.Rows[0]["卡号"].ToString();
            if (Convertor.IsNull(tb.Rows[0]["klx"].ToString(), "0") != "0")
            {
                cmbklx.SelectedValue = tb.Rows[0]["klx"].ToString();
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

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                if ((int)e.KeyChar == 13)
                {
                    txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), control.Text.Trim(), InstanceForm.BDatabase);
                    GetBrxx(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text, Guid.Empty, Guid.Empty);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
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
                f.txtbrxm.Text = "";
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

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butsave_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _id = Guid.NewGuid();
                int czid = int.Parse(this.cmbhzcz.SelectedValue.ToString());
                int isby = Convert.ToInt32(this.check_isby.Checked);//0不报疫 1报疫 ; == true ? 0 : 1; //0报疫
                string memo = this.Rtxt_Memo.Text.Trim();
                //Modify By zp 2013-07-27 新增初复诊、发病日期
                int iscz = this.Rdb_cz.Checked == true ? 0 : 1;//0初诊1复诊
                string fbrq = this.Dtp_Fbrq.Value.ToString("yyyy-MM-dd HH:mm:ss"); //发病日期

                #region 执行数据库命令
                ParameterEx[] parm = new ParameterEx[12];
                parm[0].Text = "@ID";
                parm[0].Value = _id;

                parm[1].Text = "@GHXXID";
                parm[1].Value = _GHID;

                parm[2].Text = "@YGCZID";
                parm[2].Value = czid;
                
                parm[3].Text = "@YGBYBZ";
                parm[3].Value = isby;
                
                parm[4].Text = "@KSDM";
                parm[4].Value = InstanceForm.BCurrentDept.DeptId;

                parm[5].Text = "@YSDM";
                parm[5].Value = InstanceForm.BCurrentUser.EmployeeId;

                parm[6].Text = "@MEMO";
                parm[6].Value = memo;

                parm[7].Text = "@SCBZ";
                parm[7].Value = 0;

                parm[8].Text = "@CFZBZ";
                parm[8].Value = iscz;

                parm[9].Text = "@FBRQ";
                parm[9].Value = fbrq;

                parm[10].Text = "@outcode";
                parm[10].Value = 0;
                parm[10].ParaDirection = ParameterDirection.Output;

                parm[11].Text = "@outmsg";
                parm[11].Value = "";
                parm[11].ParaDirection = ParameterDirection.Output;
                parm[11].ParaSize = 100;
                InstanceForm.BDatabase.DoCommand("SP_SetMzYgInfo", parm, 20);
                #endregion

                if (Convert.ToInt32(parm[10].Value) == 0)
                    MessageBox.Show("保存成功!", "提示");
                else
                    MessageBox.Show("保存失败!原因:" + parm[11].Value.ToString(), "提示");
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }
     
    }
}
