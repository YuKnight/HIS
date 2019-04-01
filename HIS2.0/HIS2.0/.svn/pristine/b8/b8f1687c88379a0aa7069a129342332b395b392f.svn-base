using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using ts_mz_class;

namespace ts_mzys_blcflr
{
    public partial class Frmzzsq : Form
    {
        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据
        private Guid _ghxxid;

        public Frmzzsq(Guid brxxid, Guid ghxxid, RelationalDatabase _DataBase)
        {
            _ghxxid = ghxxid;
            InitializeComponent();
            YY_BRXX brxx = new YY_BRXX(brxxid, _DataBase);

            lblxm.Text = brxx.Brxm;
            lblxb.Text = InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_SEEKSEXNAME('1')").ToString();
            lblnl.Text = InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_AGE('" + brxx.Csrq + "',3,getdate())").ToString();
            lblgzdw.Text = brxx.Gzdw;
            lbldwdh.Text = brxx.Gzdwdh;
            lbljtdz.Text = brxx.Jtdz;
            lbljtdh.Text = brxx.Jtdh;
            lblsfzh.Text = brxx.Sfzh;
            lblgrlxfs.Text = brxx.Brlxfs;


            //挂号科室
            Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            //挂号医生
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
        }

        private void txtzzks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtzzks;
                f.Font = txtzzks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtzzks.Focus();
                    return;
                }
                else
                {
                    txtzzks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtzzks.Text = f.SelectDataRow["name"].ToString().Trim();
                    txttjys.Focus();
                    e.Handled = true;
                }
            }
            else
            {
                txttjys.Focus();
            }
        }

        private void txttjys_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;

            if ((int)e.KeyChar == 8)
            {
                txttjys.Tag = "0";
                txttjys.Text = "";
                e.Handled = true;
                return;
            }

            if ((int)e.KeyChar == 13 && Convertor.IsNumeric(txttjys.Text.Trim()) == true)
            {
                DataRow[] rows = Tbys.Select("code='" + txttjys.Text.Trim() + "'", "");
                if (rows.Length == 1)
                {
                    txttjys.Tag = rows[0]["employee_id"].ToString();
                    txttjys.Text = rows[0]["name"].ToString().Trim();

                    txtbz.Focus();
                    e.Handled = true;

                    return;
                }
                else
                {
                    txttjys.Tag = "0";
                    txttjys.Text = "";
                    e.Handled = true;
                    return;
                }
            }


            if ((int)e.KeyChar != 13 && Convertor.IsNumeric(e.KeyChar.ToString()) == false)
            {

                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "py_code", "wb_code", "code" };//, "code" Modify By Tany 2008-12-19 不一定有工号
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
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
                    txtbz.Focus();
                    e.Handled = true;
                }
            }

            if ((int)e.KeyChar == 13)
            {
                if (Convert.ToInt32(txttjys.Tag) == 0 || txttjys.Text.Trim() == "") return;
                txtbz.Focus();
            }


        }

        private void txtbz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13) butsave.Focus();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            if ( Convertor.IsNull( txtzzks.Tag , "0" ) == "0" )
            {
                MessageBox.Show( "请输入接收科室" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            SystemCfg cfg3022 = new SystemCfg( 3022 );//转诊申请推荐医生输入状态  1 必填 2 不可输入 0 可不填 
            if (Convertor.IsNull(txttjys.Tag, "0") == "0" && cfg3022.Config == "1")
            {
                MessageBox.Show("请输入接收医生", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(Convertor.IsNull(txttjys.Tag, "0")) == InstanceForm.BCurrentUser.EmployeeId) //Add By Zj 2013-02-27 防止跨科室接诊时，医生自己转诊给自己获取转诊记录接诊。
            {
                MessageBox.Show("转诊医生不能是自己!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string message = "";
            if ( ts_mzys_class.mzys_jzjl.AllowReferral( _ghxxid , Convert.ToInt32( Convertor.IsNull( txtzzks.Tag , "0" ) ) , InstanceForm.BCurrentDept.DeptId ,
                InstanceForm.BCurrentUser.EmployeeId , out message, InstanceForm.BDatabase ) == false )
            {
                MessageBox.Show( message, "提示" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            if ( new SystemCfg( 3051 ).Config == "1" )
            {
                string ssql = "select ghys from mz_ghxx where ghxxid='" + _ghxxid + "' and bqxghbz=0";
                string ghys = Convert.ToString( InstanceForm.BDatabase.GetDataResult( ssql ) );
                ssql = "select jsysdm from mzys_jzjl where ghxxid='" + _ghxxid + "' and jsysdm=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + " and bz='转诊' and bscbz=0";//查找转诊记录 add by zj 2013-03-13
                string jsys = Convert.ToString( InstanceForm.BDatabase.GetDataResult( ssql ) );
                if ( ghys != InstanceForm.BCurrentUser.EmployeeId.ToString() )
                {
                    if ( jsys == "" && jsys != InstanceForm.BCurrentUser.EmployeeId.ToString() )
                    {
                        MessageBox.Show( "您没有权利转诊!" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }
                }
            }


            try
            {

                InstanceForm.BDatabase.BeginTransaction();

                int err_code = -1;
                string err_text = "";
                Guid jzid = Guid.Empty;
                //Modify By ZJ 2012-11-13 登记时间加格式化处理
                ts_mzys_class.mzys_jzjl.jz(InstanceForm._menuTag.Jgbm, _ghxxid, Convert.ToInt32(Convertor.IsNull(txttjys.Tag, "0")),
                    Convert.ToInt32(Convertor.IsNull(txtzzks.Tag, "0")), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss"),
                    "转诊", out jzid, out err_code, out err_text, 0, InstanceForm.BDatabase);
                if (err_code != 0) throw new Exception(err_text);
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("转诊成功");

                string str = InstanceForm.BCurrentDept.DeptName + "  " + InstanceForm.BCurrentUser.Name + "" + " 向本科发送了一个转诊 \n" +
                    "病人姓名:" + lblxm.Text.Trim() + "";
                TrasenFrame.Classes.WorkStaticFun.SendMessage(false, TrasenFrame.Classes.SystemModule.门诊医生站, "", Convert.ToInt32(Convertor.IsNull(txtzzks.Tag, "0")), InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, str);


                this.Close();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmzzsq_Load(object sender, EventArgs e)
        {
            SystemCfg cfg = new SystemCfg(3022);
            if (cfg.Config == "2")
                txttjys.Enabled = false;

        }

        

    }
}