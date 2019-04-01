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

namespace ts_mz_kgl
{
    public partial class Frmjhkqr : Form
    {
        public bool Bok = false;
        public Frmjhkqr()
        {
            InitializeComponent();
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
        }

        private void butcancel_Click(object sender, EventArgs e)
        {
            Bok = false;
            this.Close();
        }

        private void butok_Click(object sender, EventArgs e)
        {
            if (txtyj.Text.Trim() != "" && Convertor.IsNumeric(txtyj.Text) == false)
            {
                MessageBox.Show("押金请输入数字", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string xkh = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtxkh.Text, InstanceForm.BDatabase);
            if (txtxkh.Text.Length != xkh.Length)
            {
                MessageBox.Show("请确认卡长度是否正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bok = true;
            this.Close();
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                //this.SelectNextControl(control, true,false, false,false);
                if (control.Name == "txtxkh")
                    txtxkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(txtxkh.Tag, "0")), txtxkh.Text, InstanceForm.BDatabase);

                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void Frmjhkqr_Load(object sender, EventArgs e)
        {
            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(InstanceForm._menuTag.Function_Name, cmbklx, txtxkh);
        }

        private void txtxkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtxkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtxkh.Text, InstanceForm.BDatabase);
                ReadCard rd = new ReadCard(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtxkh.Text, InstanceForm.BDatabase);
                if (rd.kdjid != Guid.Empty)
                {
                    string zt=" 正常";
                    if (rd.zfbz==true)zt="已作废";
                    if (rd.sdbz==1)zt=zt+" 已冻结";
                    if (rd.sdbz == 2) zt = zt + " 已挂失";
                    MessageBox.Show(txtxkh.Text + "这张卡正在被人使用,卡状态:" + zt, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtxkh.Focus();
                }
            }
        }

        private void Language_Off(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.KatakanaHalf;
            Fun.SetInputLanguageOff();

        }

        private void Language_On(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.KatakanaHalf;
            Fun.SetInputLanguageOn();
        }
    }
}