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

namespace ts_mz_cx
{
    public partial class Frmxghtdw : Form
    {
        private Guid _ghxxid = Guid.Empty;
        private string  old_htdwlx = "0";
        private string old_htdwmc = "0";

        public Frmxghtdw(Guid ghxxid)
        {
            InitializeComponent();

            FunAddComboBox.AddHtdwLx(false, cmbhtdwlx, InstanceForm.BDatabase);

            _ghxxid = ghxxid;

            string ssql = "select * from vi_mz_ghxx where ghxxid='"+ghxxid+"'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0) { butok.Enabled = false; return; }

            cmbhtdwlx.SelectedValue = Convertor.IsNull(tb.Rows[0]["htdwlx"].ToString(),"0");
            txthtdwmc.Tag = Convertor.IsNull(tb.Rows[0]["htdwid"].ToString(), "0");
            txthtdwmc.Text =Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dwmc from jc_htdw where id="+Convertor.IsNull(tb.Rows[0]["htdwid"].ToString(), "0")+" "),"");

            old_htdwlx = Convertor.IsNull(tb.Rows[0]["htdwlx"].ToString(), "0") == "0" ? "" : Convertor.IsNull(cmbhtdwlx.Text, "");
            old_htdwmc = Convertor.IsNull(txthtdwmc.Text, "");

            if (tb.Rows[0]["bqxghbz"].ToString() == "1") { butok.Enabled = false; return; groupBox1.Text = "修改  病人已退签不能修改"; }


        }

        private void Frmghdj_Load(object sender, EventArgs e)
        {

           
           
        }


        /// <summary>
        /// 回车跳至下一个文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                //this.SelectNextControl(control, true,false, false,false);
                    SendKeys.Send("{TAB}");
                e.Handled = true;   
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txthtdwmc_KeyUp(object sender, KeyEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyData != 13)
            {
                string[] headtext = new string[] { "单位名称", "数字码", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "dwmc", "szm", "pym", "wbm" };
                string[] searchfields = new string[] { "dwmc", "szm", "pym", "wbm" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = InstanceForm.BDatabase.GetDataTable("select * from jc_htdw");
                f.WorkForm = this;
                f.srcControl = txthtdwmc;
                f.Font = txthtdwmc.Font;
                f.Width = 400;
                f.ReciveString = txthtdwmc.Text;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txthtdwmc.Focus();
                }
                else
                {
                    txthtdwmc.Tag = Convert.ToInt32(f.SelectDataRow["id"]);
                    txthtdwmc.Text = f.SelectDataRow["dwmc"].ToString().Trim();
                    butok.Focus();
                }
            }
            else
            {
                butok.Focus();
            }
            e.Handled = true;
        }

        private void butok_Click(object sender, EventArgs e)
        {
            try
            {
                int htdwlx=Convert.ToInt32(Convertor.IsNull(cmbhtdwlx.SelectedValue,"0"));
                int htdwid=Convert.ToInt32(Convertor.IsNull(txthtdwmc.Tag,"0"));
                int err_code=-1;
                string err_text="";
                ts_mz_class.mz_ghxx.UpdateHtdw(_ghxxid, htdwlx, htdwid, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0) throw new Exception(err_text);

                MessageBox.Show("修改成功","",MessageBoxButtons.OK,MessageBoxIcon.Information);

                string str_old = "";
                str_old = "原合同单位信息:"+old_htdwlx.Trim()+" "+old_htdwmc.ToString() +"   修改后为:"+cmbhtdwlx.Text+"  "+txthtdwmc.Text;
                SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "修改合同单位", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 2);
                systemLog.Save();
                systemLog = null;

                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


 
    }
}