using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using ts_mzys_class;

namespace ts_mzys_fzgl
{

    /// <summary>
    /// 体征录入 add by zouchihua 2013-6-28
    /// </summary>
    public partial class FrmFz_Tzlr : Form
    {
        /// <summary>
        /// 体征字符窜
        /// </summary>
        public string Tzinfo = "";
        /// <summary>
        /// 挂号信息id 
        /// </summary>
        //private Guid _ghxxid;
        //private Guid _brxxid;
        private DataTable tb;
        BindingManagerBase bm;
        private Mzys_Brtz _current_brtz = new Mzys_Brtz();

        public FrmFz_Tzlr(string xm, string kh, string ks, string xb, string nl, Guid ghxxid, Guid brxxid)
        {
            InitializeComponent();
            this.txtkh.Text = kh;
            this.txtdeptname.Text = ks;
            this.txtage.Text = nl;
            this.txtname.Text = xm;
            this.txtxb.Text = xb;
            _current_brtz.Ghxxid = ghxxid;
            _current_brtz.Brxxid = brxxid;
            //_ghxxid = ghxxid;
            //_brxxid = brxxid;
        }

        private void FrmTzlr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmTzlr_Load(object sender, EventArgs e)
        {
            try
            {
                // string sql = "select * from MZ_BRTZ where delete_bit=0 and ghxxid='" + _ghxxid + "'";

                tb = _current_brtz.GetMzbrTzInfo(_current_brtz.Ghxxid, Guid.Empty, Mzys_Brtz.BrtzDataStatus.未作废, FrmMdiMain.Database); //FrmMdiMain.Database.GetDataTable(sql);
                bm = this.BindingContext[tb, ""];
                Ts_Clinicalpathway_Factory.PublicFunction.Bindtext(this.groupBox3, tb);
                SetControl();
                this.ActiveControl = textBox7;
                textBox7.Focus();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void SetControl()
        {
            try
            {
                if (tb == null || tb.Rows.Count <= 0) return;
                this.txt_yxjb.Text = Convertor.IsNull(tb.Rows[0]["YXJB"], "");
                this.txt_ryfs.Text = Convertor.IsNull(tb.Rows[0]["RYFS"], "");
                this.txt_hzsz.Text = Convertor.IsNull(tb.Rows[0]["BRZT"], "");
                this.Cmb_Ztfj.Text = tb.Rows[0]["ZTFJ"] == null ? null : tb.Rows[0]["ZTFJ"].ToString();
                this.dtpFbsj.Text = tb.Rows[0]["FBSJ"].ToString();
                if (tb.Rows[0]["SFFR"] == null)
                    this.Cmb_Sffr.Text = "";
                else
                    this.Cmb_Sffr.SelectedIndex = int.Parse(tb.Rows[0]["SFFR"].ToString());
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        private void txtxy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{TAB}");
                //this.DialogResult = DialogResult.No;
                //if ((sender as TextBox).Name == "textBox2")
                //    this.SelectNextControl((sender as TextBox), true, false, false, true);
            }
        }
        /// <summary>
        /// 值类型判断
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        private void Typepd(Control ct, string type, string value)
        {
            if (value.Trim() == "")
                return;
            switch (type)
            {
                case "System.Decimal":
                    if (!System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), @"(^[0-9]+(.[0-9]{1,3})?$)"))
                    {
                        ct.Focus();
                        MessageBox.Show("请输入数字类型");
                    }
                    break;
                case "System.Int32":
                    if (!System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), @"(^\d{0,4}$)"))
                    {
                        ct.Focus();
                        MessageBox.Show("请输入整数类型");
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetzInfo();
        }
        /// <summary>
        /// Modify By zp 2013-09-11 
        /// </summary>
        private void SetzInfo()
        {
            try
            {
                this.BindingContext[tb, ""].EndCurrentEdit();
                // bm.Position = bm.Position + 1;
                string sql = "select * from MZ_BRTZ where delete_bit=0 and ghxxid='" + this._current_brtz.Ghxxid + "'";
                _current_brtz.Tzid = Guid.NewGuid(); ;
                //_current_brtz.GetMzbrTzInfo(_ghxxid, Guid.Empty, Mzys_Brtz.BrtzDataStatus.未作废, InstanceForm.BDatabase);
                if (tb.Rows.Count == 0)
                {
                    DataRow r = tb.NewRow();

                    r["tzid"] = _current_brtz.Tzid;//tb.Rows[0]["tzid"];

                    r["ghxxid"] = _current_brtz.Ghxxid;
                    r["brxxid"] = _current_brtz.Brxxid;
                    //给内存表添加值
                    for (int i = 0; i < this.groupBox3.Controls.Count; i++)
                    {
                        if ((this.groupBox3.Controls[i] as TextBox) != null)
                        {
                            string name = (this.groupBox3.Controls[i] as TextBox).Tag.ToString();
                            string value = (this.groupBox3.Controls[i] as TextBox).Text;//this.textBox7.Text
                            r[name] = value;
                        }
                    }
                    tb.Rows.Add(r);
                }
                else
                    _current_brtz.Tzid = new Guid(tb.Rows[0]["tzid"].ToString());
                Tzinfo = "";
                Tzinfo = "血压(mmHg)：" + this.textBox7.Text.Trim() + " || 血糖(mmoL/L )：" + this.textBox6.Text.Trim()
                     + "|| 体温(℃)：" + this.textBox5.Text.Trim() + "|| 呼吸(次数)：" + this.textBox4.Text.Trim()
                     + "|| 脉搏：" + this.textBox3.Text.Trim() + "|| 体重(kg)：" + this.textBox2.Text.Trim();

                Ts_Clinicalpathway_Factory.PublicFunction.databaseupdate(sql, tb);

                //_current_brtz.Tzid = _tzid;
                _current_brtz.Sffr = this.Cmb_Sffr.SelectedIndex == 0 ? false : true;
                _current_brtz.Yxjb = this.txt_yxjb.Text.Trim();
                _current_brtz.Ztfj = this.Cmb_Ztfj.Text.Trim();
                _current_brtz.Brzt = this.txt_hzsz.Text.Trim();
                _current_brtz.Ryfs = this.txt_ryfs.Text.Trim();
                //Add by CC 2014-03-19
                _current_brtz.Fbsj = this.dtpFbsj.Value.ToShortDateString();
                _current_brtz.UpdateTz(_current_brtz, FrmMdiMain.Database);

                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            Typepd((sender as Control), "System.Int32", (sender as Control).Text);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            Typepd((sender as Control), "System.Decimal", (sender as Control).Text);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            Typepd((sender as Control), "System.Int32", (sender as Control).Text);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            Typepd((sender as Control), "System.Decimal", (sender as Control).Text);
        }
    }
}